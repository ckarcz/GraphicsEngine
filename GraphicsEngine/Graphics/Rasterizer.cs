#region Imports

using System;
using System.Collections.Generic;
using System.Linq;
using GraphicsEngine.Graphics.Console;
using GraphicsEngine.Math;
using GraphicsEngine.Win32;

#endregion

namespace GraphicsEngine.Graphics
{
	public class Rasterizer
	{
		public const byte HalfPixelChar = 219; // '▄'
		private static readonly byte horizontalWireFrameChar = 95; // '-'
		private static readonly byte upLeftWireFrameChar = 92; // '/'
		private static readonly byte upRightWireFrameChar = 47; // '\'
		private static readonly byte verticleWireFrameChar = 124; // '|'
		private readonly ConsoleGraphicsFrame frameBuffer;
		private readonly List<Action> rasterizingActions;

		// TEST
		private static short[] colors = new short[] { Kernel32Console.Colors.FOREGROUND_BLUE, Kernel32Console.Colors.FOREGROUND_CYAN, Kernel32Console.Colors.FOREGROUND_GREEN, Kernel32Console.Colors.FOREGROUND_MAGENTA, Kernel32Console.Colors.FOREGROUND_RED, Kernel32Console.Colors.FOREGROUND_YELLOW, Kernel32Console.Colors.FOREGROUND_GREY };


		public Rasterizer(int width, int height)
		{
			frameBuffer = new ConsoleGraphicsFrame(width, height);

			rasterizingActions = new List<Action>();
		}

		public void DrawMeshWired(ITransformation transformation, IMesh mesh, byte? pixelOverride = null)
		{
			var action = new Action(() => DrawMeshWired(frameBuffer, transformation, mesh, pixelOverride));
			rasterizingActions.Add(action);
		}

		public void DrawMeshWired(ITransformation transformation, IEnumerable<IMesh> meshes, byte? pixelOverride = null)
		{
			var action = new Action(() => DrawMeshWired(frameBuffer, transformation, meshes, pixelOverride));
			rasterizingActions.Add(action);
		}

		public void DrawMeshFilled(ITransformation transformation, IMesh mesh, byte? pixelOverride = null)
		{
			var action = new Action(() => DrawMeshFilled(frameBuffer, transformation, mesh, pixelOverride));
			rasterizingActions.Add(action);
		}

		public void DrawMeshFilled(ITransformation transformation, IEnumerable<IMesh> meshes, byte? pixelOverride = null)
		{
			var action = new Action(() => DrawMeshFilled(frameBuffer, transformation, meshes, pixelOverride));
			rasterizingActions.Add(action);
		}

		public void DrawMeshVertices(ITransformation transformation, IMesh mesh, byte? pixelOverride = null)
		{
			var action = new Action(() => DrawMeshVertices(frameBuffer, transformation, mesh, pixelOverride));
			rasterizingActions.Add(action);
		}

		public void DrawMeshVertices(ITransformation transformation, IEnumerable<IMesh> meshes, byte? pixelOverride = null)
		{
			var action = new Action(() => DrawMeshVertices(frameBuffer, transformation, meshes, pixelOverride));
			rasterizingActions.Add(action);
		}

		public void DrawMeshCenters(ITransformation transformation, IMesh mesh, byte? pixelOverride = null)
		{
			var action = new Action(() => DrawMeshCenters(frameBuffer, transformation, mesh, pixelOverride));
			rasterizingActions.Add(action);
		}

		public void DrawMeshCenters(ITransformation transformation, IEnumerable<IMesh> meshes, byte? pixelOverride = null)
		{
			var action = new Action(() => DrawMeshCenters(frameBuffer, transformation, meshes, pixelOverride));
			rasterizingActions.Add(action);
		}

		public void DrawMeshBoundingBox(ITransformation transformation, IMesh mesh, byte? pixelOverride = null)
		{
			var action = new Action(() => DrawMeshBoundingBox(frameBuffer, transformation, mesh, pixelOverride));
			rasterizingActions.Add(action);
		}

		public void DrawMeshBoundingBox(ITransformation transformation, IEnumerable<IMesh> meshes, byte? pixelOverride = null)
		{
			var action = new Action(() => DrawMeshBoundingBox(frameBuffer, transformation, meshes, pixelOverride));
			rasterizingActions.Add(action);
		}

		public void DrawPolygonWired(ITransformation transformation, IEnumerable<Vector2> vectors, byte? pixelOverride = null)
		{
			var action = new Action(() => DrawPolygonWired(frameBuffer, transformation, vectors, pixelOverride));
			rasterizingActions.Add(action);
		}

		public void DrawPolygonWired(ITransformation transformation, IEnumerable<Vector3> vectors, byte? pixelOverride = null)
		{
			var action = new Action(() => DrawPolygonWired(frameBuffer, transformation, vectors, pixelOverride));
			rasterizingActions.Add(action);
		}

		public void DrawPolygonFilled(ITransformation transformation, IEnumerable<Vector2> vectors, byte? pixelOverride = null)
		{
			var action = new Action(() => DrawPolygonFilled(frameBuffer, transformation, vectors, pixelOverride));
			rasterizingActions.Add(action);
		}

		public void DrawPolygonFilled(ITransformation transformation, IEnumerable<Vector3> vectors, byte? pixelOverride = null)
		{
			var action = new Action(() => DrawPolygonFilled(frameBuffer, transformation, vectors, pixelOverride));
			rasterizingActions.Add(action);
		}

		public void DrawAxes(ITransformation transformation, byte? pixelOverride = null)
		{
			var action = new Action(() => DrawAxes(frameBuffer, transformation, pixelOverride));
			rasterizingActions.Add(action);
		}

		public void DrawLine(ITransformation transformation, Vector3 point1, Vector3 point2, byte? pixelOverride = null)
		{
			var action = new Action(() => DrawLine(frameBuffer, transformation, point1, point2, pixelOverride));
			rasterizingActions.Add(action);
		}

		public void DrawLine(ITransformation transformation, Vector2 point1, Vector2 point2, byte? pixelOverride = null)
		{
			var action = new Action(() => DrawLine(frameBuffer, transformation, point1, point2, pixelOverride));
			rasterizingActions.Add(action);
		}

		public void DrawPoints(ITransformation transformation, IEnumerable<Vector2> points, byte? pixelOverride = null)
		{
			var action = new Action(() => DrawPoints(frameBuffer, transformation, points, pixelOverride));
			rasterizingActions.Add(action);
		}

		public void DrawPoints(ITransformation transformation, IEnumerable<Vector3> points, byte? pixelOverride = null)
		{
			var action = new Action(() => DrawPoints(frameBuffer, transformation, points, pixelOverride));
			rasterizingActions.Add(action);
		}

		public void DrawPoint(ITransformation transformation, Vector2 point, byte? pixelOverride = null)
		{
			var action = new Action(() => DrawPoint(frameBuffer, transformation, point, pixelOverride));
			rasterizingActions.Add(action);
		}

		public void DrawPoint(ITransformation transformation, Vector3 point, byte? pixelOverride = null)
		{
			var action = new Action(() => DrawPoint(frameBuffer, transformation, point, pixelOverride));
			rasterizingActions.Add(action);
		}

		public void DrawStringHorizontal(ITransformation transformation, Vector2 location, string messageString)
		{
			var action = new Action(() => DrawStringHorizontal(frameBuffer, transformation, location, messageString));
			rasterizingActions.Add(action);
		}

		public void DrawStringVertical(ITransformation transformation, Vector2 location, string messageString)
		{
			var action = new Action(() => DrawStringHorizontal(frameBuffer, transformation, location, messageString));
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

		public static void DrawMeshWired(ConsoleGraphicsFrame frame, ITransformation transformation, IMesh mesh, byte? pixelOverride = null)
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

				var color = (short)(colors[i % colors.Length] | Kernel32Console.Colors.FOREGROUND_INTENSITY);
				DrawPolygonWired(frame, transformation, points, color, pixelOverride);
				i++;
			}
		}

		public static void DrawMeshWired(ConsoleGraphicsFrame frame, ITransformation transformation, IEnumerable<IMesh> meshes, byte? pixelOverride = null)
		{
			foreach (var mesh in meshes)
			{
				DrawMeshWired(frame, transformation, mesh, pixelOverride);
			}
		}

		public static void DrawMeshFilled(ConsoleGraphicsFrame frame, ITransformation transformation, IMesh mesh, byte? pixelOverride = null)
		{
			foreach (var face in mesh.Faces)
			{
				var points = new List<Vector3>();
				foreach (var vector in face.Points)
				{
					var point = new Vector3(vector.X, vector.Y, vector.Z);
					points.Add(point);
				}

				DrawPolygonFilled(frame, transformation, points, pixelOverride);
			}
		}

		public static void DrawMeshFilled(ConsoleGraphicsFrame frame, ITransformation transformation, IEnumerable<IMesh> meshes, byte? pixelOverride = null)
		{
			foreach (var mesh in meshes)
			{
				DrawMeshFilled(frame, transformation, mesh, pixelOverride);
			}
		}

		public static void DrawMeshVertices(ConsoleGraphicsFrame frame, ITransformation transformation, IMesh mesh, byte? pixelOverride = null)
		{
			foreach (var face in mesh.Faces)
			{
				DrawPoints(frame, transformation, face.Points, pixelOverride);
			}
		}

		public static void DrawMeshVertices(ConsoleGraphicsFrame frame, ITransformation transformation, IEnumerable<IMesh> meshes, byte? pixelOverride = null)
		{
			foreach (var mesh in meshes)
			{
				DrawMeshVertices(frame, transformation, mesh, pixelOverride);
			}
		}

		public static void DrawMeshCenters(ConsoleGraphicsFrame frame, ITransformation transformation, IMesh mesh, byte? pixelOverride = null)
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
				DrawLine(frame, transformation, meshCenterLineXStart, meshCenterLineXEnd, pixelOverride);

				var meshCenterLineYStart = new Vector3(meshCenters.X, meshMinimums.Y - maxDistance / 4, meshCenters.Z);
				var meshCenterLineYEnd = new Vector3(meshCenters.X, meshMaximums.Y + maxDistance / 4, meshCenters.Z);
				DrawLine(frame, transformation, meshCenterLineYStart, meshCenterLineYEnd, pixelOverride);

				var meshCenterLineZStart = new Vector3(meshCenters.X, meshCenters.Y, meshMinimums.Z - maxDistance / 4);
				var meshCenterLineZEnd = new Vector3(meshCenters.X, meshCenters.Y, meshMaximums.Z + maxDistance / 4);
				DrawLine(frame, transformation, meshCenterLineZStart, meshCenterLineZEnd, pixelOverride);
			}
		}

		public static void DrawMeshCenters(ConsoleGraphicsFrame frame, ITransformation transformation, IEnumerable<IMesh> meshes, byte? pixelOverride = null)
		{
			foreach (var mesh in meshes)
			{
				DrawMeshCenters(frame, transformation, mesh, pixelOverride);
			}
		}

		public static void DrawMeshBoundingBox(ConsoleGraphicsFrame frame, ITransformation transformation, IMesh mesh, byte? pixelOverride = null)
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

				DrawLine(frame, transformation, nearBottomLeftPoint, farBottomLeftPoint, pixelOverride);
				DrawLine(frame, transformation, nearBottomRightPoint, farBottomRightPoint, pixelOverride);
				DrawLine(frame, transformation, nearTopRightPoint, farTopRightPoint, pixelOverride);
				DrawLine(frame, transformation, nearTopLeftPoint, farTopLeftPoint, pixelOverride);

				DrawLine(frame, transformation, nearBottomLeftPoint, nearBottomRightPoint, pixelOverride);
				DrawLine(frame, transformation, nearBottomRightPoint, nearTopRightPoint, pixelOverride);
				DrawLine(frame, transformation, nearTopRightPoint, nearTopLeftPoint, pixelOverride);
				DrawLine(frame, transformation, nearTopLeftPoint, nearBottomLeftPoint, pixelOverride);

				DrawLine(frame, transformation, farBottomLeftPoint, farBottomRightPoint, pixelOverride);
				DrawLine(frame, transformation, farBottomRightPoint, farTopRightPoint, pixelOverride);
				DrawLine(frame, transformation, farTopRightPoint, farTopLeftPoint, pixelOverride);
				DrawLine(frame, transformation, farTopLeftPoint, farBottomLeftPoint, pixelOverride);
			}
		}

		public static void DrawMeshBoundingBox(ConsoleGraphicsFrame frame, ITransformation transformation, IEnumerable<IMesh> meshes, byte? pixelOverride = null)
		{
			foreach (var mesh in meshes)
			{
				DrawMeshBoundingBox(frame, transformation, mesh, pixelOverride);
			}
		}

		public static void DrawPolygonWired(ConsoleGraphicsFrame frame, ITransformation transformation, IEnumerable<Vector2> vectors, byte? pixelOverride = null)
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

				DrawLine(frame, transformation, point1, point2, pixelOverride);
			}

			DrawLine(frame, transformation, point2, firstPoint, pixelOverride);
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

		public static void DrawPolygonFilled(ConsoleGraphicsFrame frame, ITransformation transformation, IEnumerable<Vector2> vectors, byte? pixelOverride = null)
		{
			// TODO
		}

		public static void DrawPolygonFilled(ConsoleGraphicsFrame frame, ITransformation transformation, IEnumerable<Vector3> vectors, byte? pixelOverride = null)
		{
			// TODO
		}

		public static void DrawAxes(ConsoleGraphicsFrame frame, ITransformation transformation, byte? pixelOverride = null)
		{
			DrawLine(frame, transformation, new Vector2(0, -frame.Height / 2), new Vector2(0, frame.Height / 2), pixelOverride);
			DrawLine(frame, transformation, new Vector2(-frame.Width / 2, 0), new Vector2(frame.Width / 2, 0), pixelOverride);
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
							frame.ColorBuffer[pixelX, pixelY] = colorOverride.Value;
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
								frame.ColorBuffer[pixelX, pixelY] = colorOverride.Value;
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
								frame.ColorBuffer[pixelX, pixelY] = colorOverride.Value;
							}
						}

						currentPoint.Y++;
						currentPoint.X += invSlope;
					}
				}
			}
		}

		public static void DrawLine(ConsoleGraphicsFrame frame, ITransformation transformation, Vector2 point1, Vector2 point2, byte? pixelOverride = null)
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
						}

						currentPoint.Y++;
						currentPoint.X += invSlope;
					}
				}
			}
		}

		public static void DrawPoints(ConsoleGraphicsFrame frame, ITransformation transformation, IEnumerable<Vector2> points, byte? pixelOverride = null)
		{
			foreach (var point in points)
			{
				DrawPoint(frame, transformation, point, pixelOverride);
			}
		}

		public static void DrawPoints(ConsoleGraphicsFrame frame, ITransformation transformation, IEnumerable<Vector3> points, byte? pixelOverride = null)
		{
			foreach (var point in points)
			{
				DrawPoint(frame, transformation, point, pixelOverride);
			}
		}

		public static void DrawPoint(ConsoleGraphicsFrame frame, ITransformation transformation, Vector2 point, byte? pixelOverride = null)
		{
			transformation.Transform(ref point);

			var offetX = (frame.Width / 2) + point.X;
			var offsetY = (frame.Height / 2) - point.Y;

			var pixelX = (int) offetX;
			var pixelY = (int) offsetY;

			if (pixelX >= 0 && pixelX < frame.Width && pixelY >= 0 && pixelY < frame.Height)
			{
				frame.CharacterBuffer[pixelX, pixelY] = pixelOverride.HasValue ? pixelOverride.Value : HalfPixelChar;
			}
		}

		public static void DrawPoint(ConsoleGraphicsFrame frame, ITransformation transformation, Vector3 point, byte? pixelOverride = null)
		{
			transformation.Transform(ref point);

			var offetX = (frame.Width / 2) + point.X;
			var offsetY = (frame.Height / 2) - point.Y;

			var pixelX = (int) offetX;
			var pixelY = (int) offsetY;

			if (pixelX >= 0 && pixelX < frame.Width && pixelY >= 0 && pixelY < frame.Height)
			{
				frame.CharacterBuffer[pixelX, pixelY] = pixelOverride.HasValue ? pixelOverride.Value : HalfPixelChar;
			}
		}

		public static void DrawStringHorizontal(ConsoleGraphicsFrame frame, ITransformation transformation, Vector2 location, string messageString)
		{
			transformation.Transform(ref location);

			var offetX = (frame.Width / 2) + location.X;
			var offsetY = (frame.Height / 2) - location.Y;

			var currentPixelX = (int) offetX;
			var constPixelY = (int) offsetY;

			foreach (var messageChar in messageString)
			{
				frame.CharacterBuffer[currentPixelX, constPixelY] = (byte) messageChar;
				currentPixelX++;
			}
		}

		public static void DrawStringVertical(ConsoleGraphicsFrame frame, ITransformation transformation, Vector2 location, string messageString)
		{
			transformation.Transform(ref location);

			var offetX = (frame.Width / 2) + location.X;
			var offsetY = (frame.Height / 2) - location.Y;

			var currentPixelY = (int) offsetY;
			var constPixelX = (int) offetX;

			foreach (var messageChar in messageString)
			{
				frame.CharacterBuffer[constPixelX, currentPixelY] = (byte) messageChar;
				currentPixelY++;
			}
		}

		public static void ClearImage(ConsoleGraphicsFrame frame, byte? clearCharacter = null, byte? clearColor = null)
		{
			frame.ClearBuffers(clearCharacter, clearColor);
		}
	}
}