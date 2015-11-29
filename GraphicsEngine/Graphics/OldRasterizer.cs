#region Imports

using System.Collections.Generic;
using System.Linq;
using GraphicsEngine.Math;
using GraphicsEngine.Win32;

#endregion

namespace GraphicsEngine.Graphics
{
	public class OldRasterizer
		: IOldRasterizer
	{
		public const byte HalfPixelChar = 219; //						'▄'
		public const byte ShadePixelChar1 = 176; //							'░'
		public const byte ShadePixelChar2 = 177; //								'▒'
		public const byte ShadePixelChar3 = 178; //									'▓'
		public static readonly byte HorizontalWireFrameChar = 95; //	'-'
		public static readonly byte UpLeftWireFrameChar = 92; //		'/'
		public static readonly byte UpRightWireFrameChar = 47; //		'\'
		public static readonly byte VerticleWireFrameChar = 124; //	'|'
		public static readonly ushort[] Colors = new ushort[] {Kernel32Console.DefaultColors.Foreground.BLUE, Kernel32Console.DefaultColors.Foreground.CYAN, Kernel32Console.DefaultColors.Foreground.GREEN, Kernel32Console.DefaultColors.Foreground.MAGENTA, Kernel32Console.DefaultColors.Foreground.RED, Kernel32Console.DefaultColors.Foreground.WHITE, Kernel32Console.DefaultColors.Foreground.YELLOW /*, Kernel32Console.DefaultColors.Foreground.GRAY, Kernel32Console.DefaultColors.Foreground.DARKBLUE, Kernel32Console.DefaultColors.Foreground.DARKCYAN, Kernel32Console.DefaultColors.Foreground.DARKGRAY, Kernel32Console.DefaultColors.Foreground.DARKGREEN, Kernel32Console.DefaultColors.Foreground.DARKMAGENTA, Kernel32Console.DefaultColors.Foreground.DARKRED, Kernel32Console.DefaultColors.Foreground.DARKYELLOW*/ };
		private readonly GrahpicsBuffer frameBuffer;

		public OldRasterizer(int width, int height)
		{
			frameBuffer = new GrahpicsBuffer(width, height);
        }

		public void DrawMeshWired(ITransformation transformation, IMesh mesh, ushort? colorOverride = null, byte? pixelOverride = null)
		{
			var i = 0;

			foreach (var face in mesh.Faces)
			{
				var points = new List<Vector3>();
				foreach (var vector in face.Points)
				{
					var point = new Vector3(vector.X, vector.Y, vector.Z);
					points.Add(point);
				}

				var color = colorOverride ?? (ushort) (Colors[i % Colors.Length]);
				DrawPolygonWired(transformation, points, color, pixelOverride);
				i++;
			}
		}

		public void DrawMeshWired(ITransformation transformation, IEnumerable<IMesh> meshes, ushort? colorOverride = null, byte? pixelOverride = null)
		{
			foreach (var mesh in meshes)
			{
				DrawMeshWired(transformation, mesh, colorOverride, pixelOverride);
			}
		}

		public void DrawMeshFilled(ITransformation transformation, IMesh mesh, ushort? colorOverride = null, byte? pixelOverride = null)
		{
			var i = 0;

			foreach (var face in mesh.Faces)
			{
				var points = new List<Vector3>();
				foreach (var vector in face.Points)
				{
					var point = new Vector3(vector.X, vector.Y, vector.Z);
					points.Add(point);
				}

				var color = colorOverride ?? (ushort) (Colors[i % Colors.Length]);
				DrawPolygonFilled(transformation, points, color, pixelOverride);
				i++;
			}
		}

		public void DrawMeshFilled(ITransformation transformation, IEnumerable<IMesh> meshes, ushort? colorOverride = null, byte? pixelOverride = null)
		{
			foreach (var mesh in meshes)
			{
				DrawMeshFilled(transformation, mesh, colorOverride, pixelOverride);
			}
		}

		public void DrawMeshVertices(ITransformation transformation, IMesh mesh, ushort? colorOverride = null, byte? pixelOverride = null)
		{
			foreach (var face in mesh.Faces)
			{
				DrawPoints(transformation, face.Points, colorOverride, pixelOverride);
			}
		}

		public void DrawMeshVertices(ITransformation transformation, IEnumerable<IMesh> meshes, ushort? colorOverride = null, byte? pixelOverride = null)
		{
			foreach (var mesh in meshes)
			{
				DrawMeshVertices(transformation, mesh, colorOverride, pixelOverride);
			}
		}

		public void DrawMeshCenters(ITransformation transformation, IMesh mesh, ushort? colorOverride = null, byte? pixelOverride = null)
		{
			if (mesh.Centers.HasValue && mesh.Minimums.HasValue && mesh.Maximums.HasValue)
			{
				var meshMinimums = mesh.Minimums.Value;
				var meshMaximums = mesh.Maximums.Value;
				var meshCenters = mesh.Centers.Value;

				var distanceX = meshMaximums.X - meshMinimums.X;
				var distanceY = meshMaximums.Y - meshMinimums.Y;
				var distanceZ = meshMaximums.Z - meshMinimums.Z;

				var maxDistance = System.Math.Max(distanceX, System.Math.Max(distanceY, distanceZ));

				var meshCenterLineXStart = new Vector3(meshMinimums.X - maxDistance / 4, meshCenters.Y, meshCenters.Z);
				var meshCenterLineXEnd = new Vector3(meshMaximums.X + maxDistance / 4, meshCenters.Y, meshCenters.Z);
				DrawLine(transformation, meshCenterLineXStart, meshCenterLineXEnd, colorOverride, pixelOverride);

				var meshCenterLineYStart = new Vector3(meshCenters.X, meshMinimums.Y - maxDistance / 4, meshCenters.Z);
				var meshCenterLineYEnd = new Vector3(meshCenters.X, meshMaximums.Y + maxDistance / 4, meshCenters.Z);
				DrawLine(transformation, meshCenterLineYStart, meshCenterLineYEnd, colorOverride, pixelOverride);

				var meshCenterLineZStart = new Vector3(meshCenters.X, meshCenters.Y, meshMinimums.Z - maxDistance / 4);
				var meshCenterLineZEnd = new Vector3(meshCenters.X, meshCenters.Y, meshMaximums.Z + maxDistance / 4);
				DrawLine(transformation, meshCenterLineZStart, meshCenterLineZEnd, colorOverride, pixelOverride);
			}
		}

		public void DrawMeshCenters(ITransformation transformation, IEnumerable<IMesh> meshes, ushort? colorOverride = null, byte? pixelOverride = null)
		{
			foreach (var mesh in meshes)
			{
				DrawMeshCenters(transformation, mesh, colorOverride, pixelOverride);
			}
		}

		public void DrawMeshBoundingBox(ITransformation transformation, IMesh mesh, ushort? colorOverride = null, byte? pixelOverride = null)
		{
			if (mesh.Minimums.HasValue && mesh.Maximums.HasValue)
			{
				var meshMinimums = mesh.Minimums.Value;
				var meshMaximums = mesh.Maximums.Value;

				var nearBottomLeftPoint = new Vector3(meshMinimums.X, meshMinimums.Y, meshMaximums.Z);
				var farBottomLeftPoint = new Vector3(meshMinimums.X, meshMinimums.Y, meshMinimums.Z);
				var nearBottomRightPoint = new Vector3(meshMaximums.X, meshMinimums.Y, meshMaximums.Z);
				var farBottomRightPoint = new Vector3(meshMaximums.X, meshMinimums.Y, meshMinimums.Z);
				var nearTopRightPoint = new Vector3(meshMaximums.X, meshMaximums.Y, meshMaximums.Z);
				var farTopRightPoint = new Vector3(meshMaximums.X, meshMaximums.Y, meshMinimums.Z);
				var nearTopLeftPoint = new Vector3(meshMinimums.X, meshMaximums.Y, meshMaximums.Z);
				var farTopLeftPoint = new Vector3(meshMinimums.X, meshMaximums.Y, meshMinimums.Z);

				DrawLine(transformation, nearBottomLeftPoint, farBottomLeftPoint, colorOverride, pixelOverride);
				DrawLine(transformation, nearBottomRightPoint, farBottomRightPoint, colorOverride, pixelOverride);
				DrawLine(transformation, nearTopRightPoint, farTopRightPoint, colorOverride, pixelOverride);
				DrawLine(transformation, nearTopLeftPoint, farTopLeftPoint, colorOverride, pixelOverride);

				DrawLine(transformation, nearBottomLeftPoint, nearBottomRightPoint, colorOverride, pixelOverride);
				DrawLine(transformation, nearBottomRightPoint, nearTopRightPoint, colorOverride, pixelOverride);
				DrawLine(transformation, nearTopRightPoint, nearTopLeftPoint, colorOverride, pixelOverride);
				DrawLine(transformation, nearTopLeftPoint, nearBottomLeftPoint, colorOverride, pixelOverride);

				DrawLine(transformation, farBottomLeftPoint, farBottomRightPoint, colorOverride, pixelOverride);
				DrawLine(transformation, farBottomRightPoint, farTopRightPoint, colorOverride, pixelOverride);
				DrawLine(transformation, farTopRightPoint, farTopLeftPoint, colorOverride, pixelOverride);
				DrawLine(transformation, farTopLeftPoint, farBottomLeftPoint, colorOverride, pixelOverride);
			}
		}

		public void DrawMeshBoundingBox(ITransformation transformation, IEnumerable<IMesh> meshes, ushort? colorOverride = null, byte? pixelOverride = null)
		{
			foreach (var mesh in meshes)
			{
				DrawMeshBoundingBox(transformation, mesh, colorOverride, pixelOverride);
			}
		}

		public void DrawPolygonWired(ITransformation transformation, IEnumerable<Vector2> vectors, ushort? colorOverride = null, byte? pixelOverride = null)
		{
			var vectorsEnumerator = vectors.GetEnumerator();

			vectorsEnumerator.MoveNext();
			var firstPoint = vectorsEnumerator.Current;
			var point1 = firstPoint;
			var point2 = firstPoint;

			while (vectorsEnumerator.MoveNext())
			{
				point1 = point2;
				point2 = vectorsEnumerator.Current;

				DrawLine(transformation, point1, point2, colorOverride, pixelOverride);
			}

			DrawLine(transformation, point2, firstPoint, colorOverride, pixelOverride);
		}

		public void DrawPolygonWired(ITransformation transformation, IEnumerable<Vector3> vectors, ushort? colorOverride = null, byte? pixelOverride = null)
		{
			var vectorsEnumerator = vectors.GetEnumerator();

			vectorsEnumerator.MoveNext();
			var firstPoint = vectorsEnumerator.Current;
			var point1 = firstPoint;
			var point2 = firstPoint;

			while (vectorsEnumerator.MoveNext())
			{
				point1 = point2;
				point2 = vectorsEnumerator.Current;

				DrawLine(transformation, point1, point2, colorOverride, pixelOverride);
			}

			DrawLine(transformation, point2, firstPoint, colorOverride, pixelOverride);
		}

		public void DrawPolygonFilled(ITransformation transformation, IEnumerable<Vector2> vectors, ushort? colorOverride = null, byte? pixelOverride = null)
		{
			var transformedVectors = vectors
				.Select(transformation.Transform)
				.ToList();
			var yMax = (int) System.Math.Ceiling(transformedVectors.Max(vector => vector.Y));
			var yMin = (int) System.Math.Floor(transformedVectors.Min(vector => vector.Y));
			var edges = GetPolygonEdges(transformedVectors);
			for (var scanlineY = yMin; scanlineY <= yMax; scanlineY++)
			{
				var yEdgeIntersections = edges
					.Where(edge => edge.IsYValueOnEdge(scanlineY))
					.Select(edge => edge.GetPointFromY(scanlineY))
					.ToList();
				var xSortedIntersections = yEdgeIntersections.OrderBy(vector => vector.X).ToList();
				var index1 = 0;
				var index2 = 1;
				while (index2 < xSortedIntersections.Count)
				{
					var point1 = xSortedIntersections[index1];
					var point2 = xSortedIntersections[index2];
					var line = new Edge2(point1, point2);
					var startX = point1.X;
					var endX = point2.X;
					for (var x = startX; x <= endX; x++)
					{
						var point = new Vector2(x, scanlineY);
						DrawPoint(Transformation.None, point, colorOverride, pixelOverride);
					}

					index1 += 2;
					index2 += 2;
				}
			}
		}

		public void DrawPolygonFilled(ITransformation transformation, IEnumerable<Vector3> vectors, ushort? colorOverride = null, byte? pixelOverride = null)
		{
			var transformedVectors = vectors
				.Select(transformation.Transform)
				.ToList();
			var yMax = (int) System.Math.Ceiling(transformedVectors.Max(vector => vector.Y));
			var yMin = (int) System.Math.Floor(transformedVectors.Min(vector => vector.Y));
			var edges = GetPolygonEdges(transformedVectors);
			for (var scanlineY = yMin; scanlineY <= yMax; scanlineY++)
			{
				var yEdgeIntersections = edges
					.Where(edge => edge.IsYValueOnEdge(scanlineY))
					.Select(edge => edge.GetPointFromY(scanlineY))
					.ToList();
				var xSortedIntersections = yEdgeIntersections.OrderBy(vector => vector.X).ToList();
				var index1 = 0;
				var index2 = 1;
				while (index2 < xSortedIntersections.Count)
				{
					var point1 = xSortedIntersections[index1];
					var point2 = xSortedIntersections[index2];
					var line = new Edge3(point1, point2);
					var startX = point1.X;
					var endX = point2.X;
					for (var x = startX; x <= endX; x++)
					{
						// Z ALGO IS BUGGY
						var point = new Vector3(x, scanlineY, line.GetPointFromX(x).Z);
						//var point = new Vector2(x, scanlineY);
						DrawPoint(Transformation.None, point, colorOverride, pixelOverride);
					}

					index1 += 2;
					index2 += 2;
				}
			}
		}

		public void DrawAxes(ITransformation transformation, ushort? colorOverride = null, byte? pixelOverride = null)
		{
			DrawLine(transformation, new Vector2(0, -frameBuffer.Height / 2), new Vector2(0, frameBuffer.Height / 2), colorOverride, pixelOverride);
			DrawLine(transformation, new Vector2(-frameBuffer.Width / 2, 0), new Vector2(frameBuffer.Width / 2, 0), colorOverride, pixelOverride);
		}

		public void DrawLine(ITransformation transformation, Vector3 point1, Vector3 point2, ushort? colorOverride = null, byte? pixelOverride = null)
		{
			transformation.Transform(ref point1);
			transformation.Transform(ref point2);

			var rise = point2.Y - point1.Y;
			var run = point2.X - point1.X;

			var pixelChar = VerticleWireFrameChar;
			if (pixelOverride.HasValue)
			{
				pixelChar = pixelOverride.Value;
			}

			if (run == 0) // so we don't divide by zero when calculating slope
			{
				var currentPoint = new Vector3(point1.X, System.Math.Min(point1.Y, point2.Y), point1.Z);
				var endPoint = new Vector3(point2.X, System.Math.Max(point1.Y, point2.Y), point2.Z);

				while (currentPoint.Y < endPoint.Y)
				{
					var offetX = (frameBuffer.Width / 2) + currentPoint.X;
					var offsetY = (frameBuffer.Height / 2) - currentPoint.Y;

					var pixelX = (int) offetX;
					var pixelY = (int) offsetY;

					if (IsNotCulled(pixelX, pixelY, currentPoint.Z))
					{
						frameBuffer.ZBuffer[pixelX, pixelY] = currentPoint.Z;
						frameBuffer.CharacterBuffer[pixelX, pixelY] = pixelChar;
						if (colorOverride != null)
						{
							frameBuffer.ColorBuffer[pixelX, pixelY] = colorOverride.Value;
						}
					}

					currentPoint.Y++;
				}
			}
			else
			{
				var slope = rise / run;
				var invSlope = run / rise;

				if (!pixelOverride.HasValue)
				{
					if (slope > 0)
					{
						if (slope > 1)
						{
							pixelChar = VerticleWireFrameChar;
						}
						else if (slope > 0.5)
						{
							pixelChar = UpRightWireFrameChar;
						}
						else
						{
							pixelChar = HorizontalWireFrameChar;
						}
					}
					else
					{
						if (slope < -1)
						{
							pixelChar = VerticleWireFrameChar;
						}
						else if (slope < -0.5)
						{
							pixelChar = UpLeftWireFrameChar;
						}
						else
						{
							pixelChar = HorizontalWireFrameChar;
						}
					}
				}

				var currentPoint = new Vector3(point1.X, point1.Y, point1.Z);
				var endPoint = new Vector3(point2.X, point2.Y, point2.Z);

				if (System.Math.Abs(slope) <= 1) // for more horizontal or 45deg lines, draw horizontally
				{
					// start with left most point
					if (point1.X > point2.X)
					{
						currentPoint = new Vector3(point2.X, point2.Y, point2.Z);
						endPoint = new Vector3(point1.X, point1.Y, point1.Z);
					}

					// draw along x, left to right
					while (currentPoint.X <= endPoint.X)
					{
						var offetX = (frameBuffer.Width / 2) + currentPoint.X;
						var offsetY = (frameBuffer.Height / 2) - currentPoint.Y;

						var pixelX = (int) offetX;
						var pixelY = (int) offsetY;

						if (IsNotCulled(pixelX, pixelY, currentPoint.Z))
						{
							frameBuffer.ZBuffer[pixelX, pixelY] = currentPoint.Z;
							frameBuffer.CharacterBuffer[pixelX, pixelY] = pixelChar;
							if (colorOverride != null)
							{
								frameBuffer.ColorBuffer[pixelX, pixelY] = colorOverride.Value;
							}
						}

						currentPoint.X++;
						currentPoint.Y += slope;
					}
				}
				else // for more vertical lines, draw vertically
				{
					// start with bottom most point
					if (point1.Y > point2.Y)
					{
						currentPoint = new Vector3(point2.X, point2.Y, point2.Z);
						endPoint = new Vector3(point1.X, point1.Y, point1.Z);
					}

					// draw along y, bottom to top
					while (currentPoint.Y <= endPoint.Y)
					{
						var offetX = (frameBuffer.Width / 2) + currentPoint.X;
						var offsetY = (frameBuffer.Height / 2) - currentPoint.Y;

						var pixelX = (int) offetX;
						var pixelY = (int) offsetY;

						if (IsNotCulled(pixelX, pixelY, currentPoint.Z))
						{
							frameBuffer.ZBuffer[pixelX, pixelY] = currentPoint.Z;
							frameBuffer.CharacterBuffer[pixelX, pixelY] = pixelChar;
							if (colorOverride != null)
							{
								frameBuffer.ColorBuffer[pixelX, pixelY] = colorOverride.Value;
							}
						}

						currentPoint.Y++;
						currentPoint.X += invSlope;
					}
				}
			}
		}

		public void DrawLine(ITransformation transformation, Vector2 point1, Vector2 point2, ushort? colorOverride = null, byte? pixelOverride = null)
		{
			transformation.Transform(ref point1);
			transformation.Transform(ref point2);

			var rise = point2.Y - point1.Y;
			var run = point2.X - point1.X;

			var pixelChar = VerticleWireFrameChar;
			if (pixelOverride.HasValue)
			{
				pixelChar = pixelOverride.Value;
			}

			if (run == 0) // so we don't divide by zero when calculating slope
			{
				var currentPoint = new Vector2(point1.X, System.Math.Min(point1.Y, point2.Y));
				var endPoint = new Vector2(point2.X, System.Math.Max(point1.Y, point2.Y));

				while (currentPoint.Y < endPoint.Y)
				{
					var offetX = (frameBuffer.Width / 2) + currentPoint.X;
					var offsetY = (frameBuffer.Height / 2) - currentPoint.Y;

					var pixelX = (int) offetX;
					var pixelY = (int) offsetY;

					if (IsNotCulled(pixelX, pixelY, 0))
					{
						frameBuffer.CharacterBuffer[pixelX, pixelY] = pixelChar;
						if (colorOverride != null)
						{
							frameBuffer.ColorBuffer[pixelX, pixelY] = colorOverride.Value;
						}
					}

					currentPoint.Y++;
				}
			}
			else
			{
				var slope = rise / run;
				var invSlope = run / rise;

				if (!pixelOverride.HasValue)
				{
					if (slope > 0)
					{
						if (slope > 1)
						{
							pixelChar = VerticleWireFrameChar;
						}
						else if (slope > 0.5)
						{
							pixelChar = UpRightWireFrameChar;
						}
						else
						{
							pixelChar = HorizontalWireFrameChar;
						}
					}
					else
					{
						if (slope < -1)
						{
							pixelChar = VerticleWireFrameChar;
						}
						else if (slope < -0.5)
						{
							pixelChar = UpLeftWireFrameChar;
						}
						else
						{
							pixelChar = HorizontalWireFrameChar;
						}
					}
				}

				var currentPoint = new Vector2(point1.X, point1.Y);
				var endPoint = new Vector2(point2.X, point2.Y);

				if (System.Math.Abs(slope) <= 1) // for more horizontal or 45deg lines, draw horizontally
				{
					// start with left most point
					if (point1.X > point2.X)
					{
						currentPoint = new Vector2(point2.X, point2.Y);
						endPoint = new Vector2(point1.X, point1.Y);
					}

					// draw along x, left to right
					while (currentPoint.X <= endPoint.X)
					{
						var offetX = (frameBuffer.Width / 2) + currentPoint.X;
						var offsetY = (frameBuffer.Height / 2) - currentPoint.Y;

						var pixelX = (int) offetX;
						var pixelY = (int) offsetY;

						if (IsNotCulled(pixelX, pixelY, 0))
						{
							frameBuffer.CharacterBuffer[pixelX, pixelY] = pixelChar;
							if (colorOverride != null)
							{
								frameBuffer.ColorBuffer[pixelX, pixelY] = colorOverride.Value;
							}
						}

						currentPoint.X++;
						currentPoint.Y += slope;
					}
				}
				else // for more vertical lines, draw vertically
				{
					// start with bottom most point
					if (point1.Y > point2.Y)
					{
						currentPoint = new Vector2(point2.X, point2.Y);
						endPoint = new Vector2(point1.X, point1.Y);
					}

					// draw along y, bottom to top
					while (currentPoint.Y <= endPoint.Y)
					{
						var offetX = (frameBuffer.Width / 2) + currentPoint.X;
						var offsetY = (frameBuffer.Height / 2) - currentPoint.Y;

						var pixelX = (int) offetX;
						var pixelY = (int) offsetY;

						if (IsNotCulled(pixelX, pixelY, 0))
						{
							frameBuffer.CharacterBuffer[pixelX, pixelY] = pixelChar;
							if (colorOverride != null)
							{
								frameBuffer.ColorBuffer[pixelX, pixelY] = colorOverride.Value;
							}
						}

						currentPoint.Y++;
						currentPoint.X += invSlope;
					}
				}
			}
		}

		public void DrawPoints(ITransformation transformation, IEnumerable<Vector2> points, ushort? colorOverride = null, byte? pixelOverride = null)
		{
			foreach (var point in points)
			{
				DrawPoint(transformation, point, colorOverride, pixelOverride);
			}
		}

		public void DrawPoints(ITransformation transformation, IEnumerable<Vector3> points, ushort? colorOverride = null, byte? pixelOverride = null)
		{
			foreach (var point in points)
			{
				DrawPoint(transformation, point, colorOverride, pixelOverride);
			}
		}

		public void DrawPoint(ITransformation transformation, Vector2 point, ushort? colorOverride = null, byte? pixelOverride = null)
		{
			transformation.Transform(ref point);

			var offetX = (frameBuffer.Width / 2) + point.X;
			var offsetY = (frameBuffer.Height / 2) - point.Y;

			var pixelX = (int) offetX;
			var pixelY = (int) offsetY;

			if (IsNotCulled(pixelX, pixelY, 0))
			{
				frameBuffer.CharacterBuffer[pixelX, pixelY] = pixelOverride.HasValue ? pixelOverride.Value : HalfPixelChar;
				if (colorOverride != null)
				{
					frameBuffer.ColorBuffer[pixelX, pixelY] = colorOverride.Value;
				}
			}
		}

		public void DrawPoint(ITransformation transformation, Vector3 point, ushort? colorOverride = null, byte? pixelOverride = null)
		{
			transformation.Transform(ref point);

			var offetX = (frameBuffer.Width / 2) + point.X;
			var offsetY = (frameBuffer.Height / 2) - point.Y;

			var pixelX = (int) offetX;
			var pixelY = (int) offsetY;

			if (IsNotCulled(pixelX, pixelY, point.Z))
			{
				frameBuffer.ZBuffer[pixelX, pixelY] = point.Z;
				frameBuffer.CharacterBuffer[pixelX, pixelY] = pixelOverride.HasValue ? pixelOverride.Value : HalfPixelChar;
				if (colorOverride != null)
				{
					frameBuffer.ColorBuffer[pixelX, pixelY] = colorOverride.Value;
				}
			}
		}

		public void DrawStringHorizontal(ITransformation transformation, Vector2 location, string messageString, ushort? colorOverride = null)
		{
			transformation.Transform(ref location);

			var offetX = (frameBuffer.Width / 2) + location.X;
			var offsetY = (frameBuffer.Height / 2) - location.Y;

			var pixelX = (int) offetX;
			var pixelY = (int) offsetY;

			if (IsNotCulled(pixelX, pixelY, 0))
			{
				foreach (var messageChar in messageString)
				{
					frameBuffer.CharacterBuffer[pixelX, pixelY] = (byte) messageChar;
					if (colorOverride != null)
					{
						frameBuffer.ColorBuffer[pixelX, pixelY] = colorOverride.Value;
					}
					pixelX++;
				}
			}
		}

		public void DrawStringVertical(ITransformation transformation, Vector2 location, string messageString, ushort? colorOverride = null)
		{
			transformation.Transform(ref location);

			var offetX = (frameBuffer.Width / 2) + location.X;
			var offsetY = (frameBuffer.Height / 2) - location.Y;

			var pixelX = (int)offetX;
			var pixelY = (int)offsetY;

			if (IsNotCulled(pixelX, pixelY, 0))
			{
				foreach (var messageChar in messageString)
				{
					frameBuffer.CharacterBuffer[pixelX, pixelY] = (byte)messageChar;
					if (colorOverride != null)
					{
						frameBuffer.ColorBuffer[pixelX, pixelY] = colorOverride.Value;
					}
					pixelY++;
				}
			}
		}

		public byte? GetPixelCharacter(int x, int y)
		{
			return frameBuffer.CharacterBuffer[x, y];
		}

		public ushort? GetPixelColor(int x, int y)
		{
			return frameBuffer.ColorBuffer[x, y];
		}

		public void ClearImage(byte? clearCharacter = null, byte? clearColor = null)
		{
			frameBuffer.Reset(clearCharacter, clearColor);
		}

		public IGraphicsBuffer Rasterize()
		{
			return frameBuffer;
		}

		private bool IsNotCulled(int x, int y, float z, bool ignoreZ = false)
		{
			return (x >= 0 && x < frameBuffer.Width && y >= 0 && y < frameBuffer.Height) &&
				   (ignoreZ || (frameBuffer.ZBuffer[x, y] == null || z <= frameBuffer.ZBuffer[x, y].Value));
		}

		private static IEnumerable<Edge3> GetPolygonEdges(IEnumerable<Vector3> vectors)
		{
			var edges = new List<Edge3>();

			var vectorsEnumerator = vectors.GetEnumerator();

			vectorsEnumerator.MoveNext();
			var firstPoint = vectorsEnumerator.Current;
			var point1 = firstPoint;
			var point2 = firstPoint;

			while (vectorsEnumerator.MoveNext())
			{
				point1 = point2;
				point2 = vectorsEnumerator.Current;

				var edge = new Edge3(point1, point2);
				edges.Add(edge);
			}

			var lastEdge = new Edge3(point2, firstPoint);
			edges.Add(lastEdge);

			return edges;
		}

		private static IEnumerable<Edge2> GetPolygonEdges(IEnumerable<Vector2> vectors)
		{
			var edges = new List<Edge2>();

			var vectorsEnumerator = vectors.GetEnumerator();

			vectorsEnumerator.MoveNext();
			var firstPoint = vectorsEnumerator.Current;
			var point1 = firstPoint;
			var point2 = firstPoint;

			while (vectorsEnumerator.MoveNext())
			{
				point1 = point2;
				point2 = vectorsEnumerator.Current;

				var edge = new Edge2(point1, point2);
				edges.Add(edge);
			}

			var lastEdge = new Edge2(point2, firstPoint);
			edges.Add(lastEdge);

			return edges;
		}
	}
}