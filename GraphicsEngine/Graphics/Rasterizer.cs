#region Imports

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using GraphicsEngine.Graphics.Console;
using GraphicsEngine.Math;
using GraphicsEngine.Win32;

#endregion

namespace GraphicsEngine.Graphics
{
	public class Rasterizer
	{
		public const byte HalfPixelChar = 219; //						'▄'
		private static readonly byte horizontalWireFrameChar = 95; //	'-'
		private static readonly byte upLeftWireFrameChar = 92; //		'/'
		private static readonly byte upRightWireFrameChar = 47; //		'\'
		private static readonly byte verticleWireFrameChar = 124; //	'|'
		private readonly ConsoleGraphicsFrame frameBuffer;
		private readonly List<Action> rasterizingActions;

		private static short[] colors = new short[] { Kernel32Console.Colors.FOREGROUND_BLUE, Kernel32Console.Colors.FOREGROUND_CYAN, Kernel32Console.Colors.FOREGROUND_GREEN, Kernel32Console.Colors.FOREGROUND_MAGENTA, Kernel32Console.Colors.FOREGROUND_RED, Kernel32Console.Colors.FOREGROUND_YELLOW, Kernel32Console.Colors.FOREGROUND_GREY };

		public Rasterizer(int width, int height)
		{
			frameBuffer = new ConsoleGraphicsFrame(width, height);

			rasterizingActions = new List<Action>();
		}

		public void DrawMeshWired(ITransformation transformation, IMesh mesh, short? colorOverride = null, byte? pixelOverride = null)
		{
			var action = new Action(() => DrawMeshWired(frameBuffer, transformation, mesh, colorOverride, pixelOverride));
			rasterizingActions.Add(action);
		}

		public void DrawMeshWired(ITransformation transformation, IEnumerable<IMesh> meshes, short? colorOverride = null, byte? pixelOverride = null)
		{
			var action = new Action(() => DrawMeshWired(frameBuffer, transformation, meshes, colorOverride, pixelOverride));
			rasterizingActions.Add(action);
		}

		public void DrawMeshFilled(ITransformation transformation, IMesh mesh, short? colorOverride = null, byte? pixelOverride = null)
		{
			var action = new Action(() => DrawMeshFilled(frameBuffer, transformation, mesh, colorOverride, pixelOverride));
			rasterizingActions.Add(action);
		}

		public void DrawMeshFilled(ITransformation transformation, IEnumerable<IMesh> meshes, short? colorOverride = null, byte? pixelOverride = null)
		{
			var action = new Action(() => DrawMeshFilled(frameBuffer, transformation, meshes, colorOverride, pixelOverride));
			rasterizingActions.Add(action);
		}

		public void DrawMeshVertices(ITransformation transformation, IMesh mesh, short? colorOverride = null, byte? pixelOverride = null)
		{
			var action = new Action(() => DrawMeshVertices(frameBuffer, transformation, mesh, colorOverride, pixelOverride));
			rasterizingActions.Add(action);
		}

		public void DrawMeshVertices(ITransformation transformation, IEnumerable<IMesh> meshes, short? colorOverride = null, byte? pixelOverride = null)
		{
			var action = new Action(() => DrawMeshVertices(frameBuffer, transformation, meshes, colorOverride, pixelOverride));
			rasterizingActions.Add(action);
		}

		public void DrawMeshCenters(ITransformation transformation, IMesh mesh, short? colorOverride = null, byte? pixelOverride = null)
		{
			var action = new Action(() => DrawMeshCenters(frameBuffer, transformation, mesh, colorOverride, pixelOverride));
			rasterizingActions.Add(action);
		}

		public void DrawMeshCenters(ITransformation transformation, IEnumerable<IMesh> meshes, short? colorOverride = null, byte? pixelOverride = null)
		{
			var action = new Action(() => DrawMeshCenters(frameBuffer, transformation, meshes, colorOverride, pixelOverride));
			rasterizingActions.Add(action);
		}

		public void DrawMeshBoundingBox(ITransformation transformation, IMesh mesh, short? colorOverride = null, byte? pixelOverride = null)
		{
			var action = new Action(() => DrawMeshBoundingBox(frameBuffer, transformation, mesh, colorOverride, pixelOverride));
			rasterizingActions.Add(action);
		}

		public void DrawMeshBoundingBox(ITransformation transformation, IEnumerable<IMesh> meshes, short? colorOverride = null, byte? pixelOverride = null)
		{
			var action = new Action(() => DrawMeshBoundingBox(frameBuffer, transformation, meshes, colorOverride, pixelOverride));
			rasterizingActions.Add(action);
		}

		public void DrawPolygonWired(ITransformation transformation, IEnumerable<Vector2> vectors, short? colorOverride = null, byte? pixelOverride = null)
		{
			var action = new Action(() => DrawPolygonWired(frameBuffer, transformation, vectors, colorOverride, pixelOverride));
			rasterizingActions.Add(action);
		}

		public void DrawPolygonWired(ITransformation transformation, IEnumerable<Vector3> vectors, short? colorOverride = null, byte? pixelOverride = null)
		{
			var action = new Action(() => DrawPolygonWired(frameBuffer, transformation, vectors, colorOverride, pixelOverride));
			rasterizingActions.Add(action);
		}

		public void DrawPolygonFilled(ITransformation transformation, IEnumerable<Vector2> vectors, short? colorOverride = null, byte? pixelOverride = null)
		{
			var action = new Action(() => DrawPolygonFilled(frameBuffer, transformation, vectors, colorOverride, pixelOverride));
			rasterizingActions.Add(action);
		}

		public void DrawPolygonFilled(ITransformation transformation, IEnumerable<Vector3> vectors, short? colorOverride = null, byte? pixelOverride = null)
		{
			var action = new Action(() => DrawPolygonFilled(frameBuffer, transformation, vectors, colorOverride, pixelOverride));
			rasterizingActions.Add(action);
		}

		public void DrawAxes(ITransformation transformation, short? colorOverride = null, byte? pixelOverride = null)
		{
			var action = new Action(() => DrawAxes(frameBuffer, transformation, colorOverride, pixelOverride));
			rasterizingActions.Add(action);
		}

		public void DrawLine(ITransformation transformation, Vector3 point1, Vector3 point2, short? colorOverride = null, byte? pixelOverride = null)
		{
			var action = new Action(() => DrawLine(frameBuffer, transformation, point1, point2, colorOverride, pixelOverride));
			rasterizingActions.Add(action);
		}

		public void DrawLine(ITransformation transformation, Vector2 point1, Vector2 point2, short? colorOverride = null, byte? pixelOverride = null)
		{
			var action = new Action(() => DrawLine(frameBuffer, transformation, point1, point2, colorOverride, pixelOverride));
			rasterizingActions.Add(action);
		}

		public void DrawPoints(ITransformation transformation, IEnumerable<Vector2> points, short? colorOverride = null, byte? pixelOverride = null)
		{
			var action = new Action(() => DrawPoints(frameBuffer, transformation, points, colorOverride, pixelOverride));
			rasterizingActions.Add(action);
		}

		public void DrawPoints(ITransformation transformation, IEnumerable<Vector3> points, short? colorOverride = null, byte? pixelOverride = null)
		{
			var action = new Action(() => DrawPoints(frameBuffer, transformation, points, colorOverride, pixelOverride));
			rasterizingActions.Add(action);
		}

		public void DrawPoint(ITransformation transformation, Vector2 point, short? colorOverride = null, byte? pixelOverride = null)
		{
			var action = new Action(() => DrawPoint(frameBuffer, transformation, point, colorOverride, pixelOverride));
			rasterizingActions.Add(action);
		}

		public void DrawPoint(ITransformation transformation, Vector3 point, short? colorOverride = null, byte? pixelOverride = null)
		{
			var action = new Action(() => DrawPoint(frameBuffer, transformation, point, colorOverride, pixelOverride));
			rasterizingActions.Add(action);
		}

		public void DrawStringHorizontal(ITransformation transformation, Vector2 location, string messageString, short? colorOverride = null)
		{
			var action = new Action(() => DrawStringHorizontal(frameBuffer, transformation, location, messageString, colorOverride));
			rasterizingActions.Add(action);
		}

		public void DrawStringVertical(ITransformation transformation, Vector2 location, string messageString, short? colorOverride = null)
		{
			var action = new Action(() => DrawStringHorizontal(frameBuffer, transformation, location, messageString, colorOverride));
			rasterizingActions.Add(action);
		}

		public void ClearImage(byte? clearCharacter = null, byte? clearColor = null)
		{
			Reset();
			ClearImage(frameBuffer, clearCharacter, clearColor);
		}

		public void Reset()
		{
			rasterizingActions.Clear();
		}

		public ConsoleGraphicsFrame Rasterize()
		{
			foreach (var rasterizationAction in rasterizingActions)
			{
				rasterizationAction();
			}

			Reset();

			return frameBuffer;
		}

		public static void DrawMeshWired(ConsoleGraphicsFrame frame, ITransformation transformation, IMesh mesh, short? colorOverride = null, byte? pixelOverride = null)
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

				var color = colorOverride ?? (short)(colors[i % colors.Length]);
				DrawPolygonWired(frame, transformation, points, color, pixelOverride);
				i++;
			}
		}

		public static void DrawMeshWired(ConsoleGraphicsFrame frame, ITransformation transformation, IEnumerable<IMesh> meshes, short? colorOverride = null, byte? pixelOverride = null)
		{
			foreach (var mesh in meshes)
			{
				DrawMeshWired(frame, transformation, mesh, colorOverride, pixelOverride);
			}
		}

		public static void DrawMeshFilled(ConsoleGraphicsFrame frame, ITransformation transformation, IMesh mesh, short? colorOverride = null, byte? pixelOverride = null)
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

				var color = colorOverride ?? (short)(colors[i % colors.Length]);
				DrawPolygonFilled(frame, transformation, points, color, pixelOverride);
				i++;
			}
		}

		public static void DrawMeshFilled(ConsoleGraphicsFrame frame, ITransformation transformation, IEnumerable<IMesh> meshes, short? colorOverride = null, byte? pixelOverride = null)
		{
			foreach (var mesh in meshes)
			{
				DrawMeshFilled(frame, transformation, mesh, colorOverride, pixelOverride);
			}
		}

		public static void DrawMeshVertices(ConsoleGraphicsFrame frame, ITransformation transformation, IMesh mesh, short? colorOverride = null, byte? pixelOverride = null)
		{
			foreach (var face in mesh.Faces)
			{
				DrawPoints(frame, transformation, face.Points, colorOverride, pixelOverride);
			}
		}

		public static void DrawMeshVertices(ConsoleGraphicsFrame frame, ITransformation transformation, IEnumerable<IMesh> meshes, short? colorOverride = null, byte? pixelOverride = null)
		{
			foreach (var mesh in meshes)
			{
				DrawMeshVertices(frame, transformation, mesh, colorOverride, pixelOverride);
			}
		}

		public static void DrawMeshCenters(ConsoleGraphicsFrame frame, ITransformation transformation, IMesh mesh, short? colorOverride = null, byte? pixelOverride = null)
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
				DrawLine(frame, transformation, meshCenterLineXStart, meshCenterLineXEnd, colorOverride, pixelOverride);

				var meshCenterLineYStart = new Vector3(meshCenters.X, meshMinimums.Y - maxDistance / 4, meshCenters.Z);
				var meshCenterLineYEnd = new Vector3(meshCenters.X, meshMaximums.Y + maxDistance / 4, meshCenters.Z);
				DrawLine(frame, transformation, meshCenterLineYStart, meshCenterLineYEnd, colorOverride, pixelOverride);

				var meshCenterLineZStart = new Vector3(meshCenters.X, meshCenters.Y, meshMinimums.Z - maxDistance / 4);
				var meshCenterLineZEnd = new Vector3(meshCenters.X, meshCenters.Y, meshMaximums.Z + maxDistance / 4);
				DrawLine(frame, transformation, meshCenterLineZStart, meshCenterLineZEnd, colorOverride, pixelOverride);
			}
		}

		public static void DrawMeshCenters(ConsoleGraphicsFrame frame, ITransformation transformation, IEnumerable<IMesh> meshes, short? colorOverride = null, byte? pixelOverride = null)
		{
			foreach (var mesh in meshes)
			{
				DrawMeshCenters(frame, transformation, mesh, colorOverride, pixelOverride);
			}
		}

		public static void DrawMeshBoundingBox(ConsoleGraphicsFrame frame, ITransformation transformation, IMesh mesh, short? colorOverride = null, byte? pixelOverride = null)
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

				DrawLine(frame, transformation, nearBottomLeftPoint, farBottomLeftPoint, colorOverride, pixelOverride);
				DrawLine(frame, transformation, nearBottomRightPoint, farBottomRightPoint, colorOverride, pixelOverride);
				DrawLine(frame, transformation, nearTopRightPoint, farTopRightPoint, colorOverride, pixelOverride);
				DrawLine(frame, transformation, nearTopLeftPoint, farTopLeftPoint, colorOverride, pixelOverride);

				DrawLine(frame, transformation, nearBottomLeftPoint, nearBottomRightPoint, colorOverride, pixelOverride);
				DrawLine(frame, transformation, nearBottomRightPoint, nearTopRightPoint, colorOverride, pixelOverride);
				DrawLine(frame, transformation, nearTopRightPoint, nearTopLeftPoint, colorOverride, pixelOverride);
				DrawLine(frame, transformation, nearTopLeftPoint, nearBottomLeftPoint, colorOverride, pixelOverride);

				DrawLine(frame, transformation, farBottomLeftPoint, farBottomRightPoint, colorOverride, pixelOverride);
				DrawLine(frame, transformation, farBottomRightPoint, farTopRightPoint, colorOverride, pixelOverride);
				DrawLine(frame, transformation, farTopRightPoint, farTopLeftPoint, colorOverride, pixelOverride);
				DrawLine(frame, transformation, farTopLeftPoint, farBottomLeftPoint, colorOverride, pixelOverride);
			}
		}

		public static void DrawMeshBoundingBox(ConsoleGraphicsFrame frame, ITransformation transformation, IEnumerable<IMesh> meshes, short? colorOverride = null, byte? pixelOverride = null)
		{
			foreach (var mesh in meshes)
			{
				DrawMeshBoundingBox(frame, transformation, mesh, colorOverride, pixelOverride);
			}
		}

		public static void DrawPolygonWired(ConsoleGraphicsFrame frame, ITransformation transformation, IEnumerable<Vector2> vectors, short? colorOverride = null, byte? pixelOverride = null)
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

				DrawLine(frame, transformation, point1, point2, colorOverride, pixelOverride);
			}

			DrawLine(frame, transformation, point2, firstPoint, colorOverride, pixelOverride);
		}

		public static void DrawPolygonWired(ConsoleGraphicsFrame frame, ITransformation transformation, IEnumerable<Vector3> vectors, short? colorOverride = null, byte? pixelOverride = null)
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

				DrawLine(frame, transformation, point1, point2, colorOverride, pixelOverride);
			}

			DrawLine(frame, transformation, point2, firstPoint, colorOverride, pixelOverride);
		}

		public static void DrawPolygonFilled(ConsoleGraphicsFrame frame, ITransformation transformation, IEnumerable<Vector2> vectors, short? colorOverride = null, byte? pixelOverride = null)
		{
			// TODO
		}

		public static void DrawPolygonFilled(ConsoleGraphicsFrame frame, ITransformation transformation, IEnumerable<Vector3> vectors, short? colorOverride = null, byte? pixelOverride = null)
		{
			var transformedVectors = vectors
				.Select(transformation.Transform)
				.ToList();
			var yMax = transformedVectors.Max(vector => vector.Y);
			var yMin = transformedVectors.Min(vector => vector.Y);
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
						DrawPoint(frame, Transformation.None, point, colorOverride, pixelOverride);
					}
					
					index1 += 2;
					index2 += 2;
				}
			}

			//DrawPolygonWired(frame, transformation, vectors, colorOverride, pixelOverride);
		}

		public static void DrawAxes(ConsoleGraphicsFrame frame, ITransformation transformation, short? colorOverride = null, byte? pixelOverride = null)
		{
			DrawLine(frame, transformation, new Vector2(0, -frame.Height / 2), new Vector2(0, frame.Height / 2), colorOverride, pixelOverride);
			DrawLine(frame, transformation, new Vector2(-frame.Width / 2, 0), new Vector2(frame.Width / 2, 0), colorOverride, pixelOverride);
		}

		public static void DrawLine(ConsoleGraphicsFrame frame, ITransformation transformation, Vector3 point1, Vector3 point2, short? colorOverride = null, byte? pixelOverride = null)
		{
			transformation.Transform(ref point1);
			transformation.Transform(ref point2);

			var rise = point2.Y - point1.Y;
			var run = point2.X - point1.X;

			var pixelChar = verticleWireFrameChar;
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
					var offetX = (frame.Width / 2) + currentPoint.X;
					var offsetY = (frame.Height / 2) - currentPoint.Y;

					var pixelX = (int) offetX;
					var pixelY = (int) offsetY;

					if (pixelX >= 0 && pixelX < frame.Width && pixelY >= 0 && pixelY < frame.Height && (frame.ZBuffer[pixelX, pixelY] == null || frame.ZBuffer[pixelX, pixelY].Value < currentPoint.Z))
					{
						frame.ZBuffer[pixelX, pixelY] = currentPoint.Z;
						frame.CharacterBuffer[pixelX, pixelY] = pixelChar;
						if (colorOverride != null)
						{
							frame.ColorBuffer[pixelX, pixelY] = (short) (colorOverride.Value | Kernel32Console.Colors.FOREGROUND_INTENSITY);
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
							pixelChar = verticleWireFrameChar;
						}
						else if (slope > 0.5)
						{
							pixelChar = upRightWireFrameChar;
						}
						else
						{
							pixelChar = horizontalWireFrameChar;
						}
					}
					else
					{
						if (slope < -1)
						{
							pixelChar = verticleWireFrameChar;
						}
						else if (slope < -0.5)
						{
							pixelChar = upLeftWireFrameChar;
						}
						else
						{
							pixelChar = horizontalWireFrameChar;
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
						var offetX = (frame.Width / 2) + currentPoint.X;
						var offsetY = (frame.Height / 2) - currentPoint.Y;

						var pixelX = (int) offetX;
						var pixelY = (int) offsetY;

						if (pixelX >= 0 && pixelX < frame.Width && pixelY >= 0 && pixelY < frame.Height && (frame.ZBuffer[pixelX, pixelY] == null || frame.ZBuffer[pixelX, pixelY].Value < currentPoint.Z))
						{
							frame.ZBuffer[pixelX, pixelY] = currentPoint.Z;
							frame.CharacterBuffer[pixelX, pixelY] = pixelChar;
							if (colorOverride != null)
							{
								frame.ColorBuffer[pixelX, pixelY] = (short) (colorOverride.Value | Kernel32Console.Colors.FOREGROUND_INTENSITY);
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
						var offetX = (frame.Width / 2) + currentPoint.X;
						var offsetY = (frame.Height / 2) - currentPoint.Y;

						var pixelX = (int) offetX;
						var pixelY = (int) offsetY;

						if (pixelX >= 0 && pixelX < frame.Width && pixelY >= 0 && pixelY < frame.Height && (frame.ZBuffer[pixelX, pixelY] == null || frame.ZBuffer[pixelX, pixelY].Value < currentPoint.Z))
						{
							frame.ZBuffer[pixelX, pixelY] = currentPoint.Z;
							frame.CharacterBuffer[pixelX, pixelY] = pixelChar;
							if (colorOverride != null)
							{
								frame.ColorBuffer[pixelX, pixelY] = (short) (colorOverride.Value | Kernel32Console.Colors.FOREGROUND_INTENSITY);
							}
						}

						currentPoint.Y++;
						currentPoint.X += invSlope;
					}
				}
			}
		}

		public static void DrawLine(ConsoleGraphicsFrame frame, ITransformation transformation, Vector2 point1, Vector2 point2, short? colorOverride = null, byte? pixelOverride = null)
		{
			transformation.Transform(ref point1);
			transformation.Transform(ref point2);

			var rise = point2.Y - point1.Y;
			var run = point2.X - point1.X;

			var pixelChar = verticleWireFrameChar;
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
					var offetX = (frame.Width / 2) + currentPoint.X;
					var offsetY = (frame.Height / 2) - currentPoint.Y;

					var pixelX = (int) offetX;
					var pixelY = (int) offsetY;

					if (pixelX >= 0 && pixelX < frame.Width && pixelY >= 0 && pixelY < frame.Height)
					{
						frame.CharacterBuffer[pixelX, pixelY] = pixelChar;
						if (colorOverride != null)
						{
							frame.ColorBuffer[pixelX, pixelY] = (short) (colorOverride.Value | Kernel32Console.Colors.FOREGROUND_INTENSITY);
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
							pixelChar = verticleWireFrameChar;
						}
						else if (slope > 0.5)
						{
							pixelChar = upRightWireFrameChar;
						}
						else
						{
							pixelChar = horizontalWireFrameChar;
						}
					}
					else
					{
						if (slope < -1)
						{
							pixelChar = verticleWireFrameChar;
						}
						else if (slope < -0.5)
						{
							pixelChar = upLeftWireFrameChar;
						}
						else
						{
							pixelChar = horizontalWireFrameChar;
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
						var offetX = (frame.Width / 2) + currentPoint.X;
						var offsetY = (frame.Height / 2) - currentPoint.Y;

						var pixelX = (int) offetX;
						var pixelY = (int) offsetY;

						if (pixelX >= 0 && pixelX < frame.Width && pixelY >= 0 && pixelY < frame.Height)
						{
							frame.CharacterBuffer[pixelX, pixelY] = pixelChar;
							if (colorOverride != null)
							{
								frame.ColorBuffer[pixelX, pixelY] = (short) (colorOverride.Value | Kernel32Console.Colors.FOREGROUND_INTENSITY);
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
						var offetX = (frame.Width / 2) + currentPoint.X;
						var offsetY = (frame.Height / 2) - currentPoint.Y;

						var pixelX = (int) offetX;
						var pixelY = (int) offsetY;

						if (pixelX >= 0 && pixelX < frame.Width && pixelY >= 0 && pixelY < frame.Height)
						{
							frame.CharacterBuffer[pixelX, pixelY] = pixelChar;
							if (colorOverride != null)
							{
								frame.ColorBuffer[pixelX, pixelY] = (short) (colorOverride.Value | Kernel32Console.Colors.FOREGROUND_INTENSITY);
							}
						}

						currentPoint.Y++;
						currentPoint.X += invSlope;
					}
				}
			}
		}

		public static void DrawPoints(ConsoleGraphicsFrame frame, ITransformation transformation, IEnumerable<Vector2> points, short? colorOverride = null, byte? pixelOverride = null)
		{
			foreach (var point in points)
			{
				DrawPoint(frame, transformation, point, colorOverride, pixelOverride);
			}
		}

		public static void DrawPoints(ConsoleGraphicsFrame frame, ITransformation transformation, IEnumerable<Vector3> points, short? colorOverride = null, byte? pixelOverride = null)
		{
			foreach (var point in points)
			{
				DrawPoint(frame, transformation, point, colorOverride, pixelOverride);
			}
		}

		public static void DrawPoint(ConsoleGraphicsFrame frame, ITransformation transformation, Vector2 point, short? colorOverride = null, byte? pixelOverride = null)
		{
			transformation.Transform(ref point);

			var offetX = (frame.Width / 2) + point.X;
			var offsetY = (frame.Height / 2) - point.Y;

			var pixelX = (int) offetX;
			var pixelY = (int) offsetY;

			if (pixelX >= 0 && pixelX < frame.Width && pixelY >= 0 && pixelY < frame.Height)
			{
				frame.CharacterBuffer[pixelX, pixelY] = pixelOverride.HasValue ? pixelOverride.Value : HalfPixelChar;
				if (colorOverride != null)
				{
					frame.ColorBuffer[pixelX, pixelY] = (short) (colorOverride.Value | Kernel32Console.Colors.FOREGROUND_INTENSITY);
				}
			}
		}

		public static void DrawPoint(ConsoleGraphicsFrame frame, ITransformation transformation, Vector3 point, short? colorOverride = null, byte? pixelOverride = null)
		{
			transformation.Transform(ref point);

			var offetX = (frame.Width / 2) + point.X;
			var offsetY = (frame.Height / 2) - point.Y;

			var pixelX = (int) offetX;
			var pixelY = (int) offsetY;

			if (pixelX >= 0 && pixelX < frame.Width && pixelY >= 0 && pixelY < frame.Height && (frame.ZBuffer[pixelX, pixelY] == null || frame.ZBuffer[pixelX, pixelY].Value < point.Z))
			{
				frame.ZBuffer[pixelX, pixelY] = point.Z;
				frame.CharacterBuffer[pixelX, pixelY] = pixelOverride.HasValue ? pixelOverride.Value : HalfPixelChar;
				if (colorOverride != null)
				{
					frame.ColorBuffer[pixelX, pixelY] = (short) (colorOverride.Value | Kernel32Console.Colors.FOREGROUND_INTENSITY);
				}
			}
		}

		public static void DrawStringHorizontal(ConsoleGraphicsFrame frame, ITransformation transformation, Vector2 location, string messageString, short? colorOverride = null)
		{
			transformation.Transform(ref location);

			var offetX = (frame.Width / 2) + location.X;
			var offsetY = (frame.Height / 2) - location.Y;

			var currentPixelX = (int) offetX;
			var constPixelY = (int) offsetY;

			foreach (var messageChar in messageString)
			{
				frame.CharacterBuffer[currentPixelX, constPixelY] = (byte) messageChar;
				if (colorOverride != null)
				{
					frame.ColorBuffer[currentPixelX, constPixelY] = (short) (colorOverride.Value | Kernel32Console.Colors.FOREGROUND_INTENSITY);
				}
				currentPixelX++;
			}
		}

		public static void DrawStringVertical(ConsoleGraphicsFrame frame, ITransformation transformation, Vector2 location, string messageString, short? colorOverride = null)
		{
			transformation.Transform(ref location);

			var offetX = (frame.Width / 2) + location.X;
			var offsetY = (frame.Height / 2) - location.Y;

			var currentPixelY = (int) offsetY;
			var constPixelX = (int) offetX;

			foreach (var messageChar in messageString)
			{
				frame.CharacterBuffer[constPixelX, currentPixelY] = (byte) messageChar;
				if (colorOverride != null)
				{
					frame.ColorBuffer[constPixelX, currentPixelY] = (short) (colorOverride.Value | Kernel32Console.Colors.FOREGROUND_INTENSITY);
				}
				currentPixelY++;
			}
		}

		public static void ClearImage(ConsoleGraphicsFrame frame, byte? clearCharacter = null, byte? clearColor = null)
		{
			frame.ClearBuffers(clearCharacter, clearColor);
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
	}
}