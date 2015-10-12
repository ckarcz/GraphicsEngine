#region Imports

using System;
using System.Collections.Generic;
using GraphicsEngine.Engine;
using GraphicsEngine.Graphics.Console;
using GraphicsEngine.Math;

#endregion

namespace GraphicsEngine.Graphics
{
	public class Rasterizer
	{
		private static readonly byte halfPixelChar = 219; // '▄'
		private static readonly byte horizontalWireFrameChar = 95; // '-'
		private static readonly byte upLeftWireFrameChar = 92; // '/'
		private static readonly byte upRightWireFrameChar = 47; // '\'
		private static readonly byte verticleWireFrameChar = 124; // '|'
		private readonly ConsoleGraphicsFrame frameBuffer;
		private readonly List<Action> rasterizingActions;

		public Rasterizer(int width, int height)
		{
			frameBuffer = new ConsoleGraphicsFrame(width, height);

			rasterizingActions = new List<Action>();
		}

		public void DrawWiredMesh(ITransformation transformation, IMesh mesh, bool drawWireFrame = false, bool clip = true)
		{
			var action = new Action(() => DrawWiredMesh(frameBuffer, transformation, mesh, drawWireFrame, clip));
			rasterizingActions.Add(action);
		}

		public void DrawWiredMesh(ITransformation transformation, IEnumerable<IMesh> meshes, bool drawWireFrame = false, bool clip = true)
		{
			var action = new Action(() => DrawWiredMesh(frameBuffer, transformation, meshes, drawWireFrame, clip));
			rasterizingActions.Add(action);
		}

		public void DrawWiredPolygon(ITransformation transformation, IEnumerable<Vector2> vectors, bool drawWireFrame = false, bool clip = true)
		{
			var action = new Action(() => DrawWiredPolygon(frameBuffer, transformation, vectors, drawWireFrame, clip));
			rasterizingActions.Add(action);
		}

		public void DrawWiredTriangle(ITransformation transformation, Vector2 point1, Vector2 point2, Vector2 point3, bool drawWireFrame = false, bool clip = true)
		{
			var action = new Action(() => DrawWiredTriangle(frameBuffer, transformation, point1, point2, point3, drawWireFrame, clip));
			rasterizingActions.Add(action);
		}

		public void DrawWiredTriangle(ITransformation transformation, Vector3 point1, Vector3 point2, Vector3 point3, bool drawWireFrame = false, bool clip = true)
		{
			var action = new Action(() => DrawWiredTriangle(frameBuffer, transformation, point1, point2, point3, drawWireFrame, clip));
			rasterizingActions.Add(action);
		}

		public void DrawAxes(ITransformation transformation, bool drawWireFrame = true)
		{
			var action = new Action(() => DrawAxes(frameBuffer, transformation, drawWireFrame));
			rasterizingActions.Add(action);
		}

		public void DrawLine(ITransformation transformation, Vector3 point1, Vector3 point2, bool drawWireFrame = false, bool clip = true)
		{
			var action = new Action(() => DrawLine(frameBuffer, transformation, point1, point2, drawWireFrame, clip));
			rasterizingActions.Add(action);
		}

		public void DrawLine(ITransformation transformation, Vector2 point1, Vector2 point2, bool drawWireFrame = false, bool clip = true)
		{
			var action = new Action(() => DrawLine(frameBuffer, transformation, point1, point2, drawWireFrame, clip));
			rasterizingActions.Add(action);
		}

		public void DrawPoints(ITransformation transformation, IEnumerable<Vector2> points)
		{
			var action = new Action(() => DrawPoints(frameBuffer, transformation, points));
			rasterizingActions.Add(action);
		}

		public void DrawPoints(ITransformation transformation, IEnumerable<Vector3> points)
		{
			var action = new Action(() => DrawPoints(frameBuffer, transformation, points));
			rasterizingActions.Add(action);
		}

		public void DrawPoint(ITransformation transformation, Vector2 point)
		{
			var action = new Action(() => DrawPoint(frameBuffer, transformation, point));
			rasterizingActions.Add(action);
		}

		public void DrawPoint(ITransformation transformation, Vector3 point)
		{
			var action = new Action(() => DrawPoint(frameBuffer, transformation, point));
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

		public void ClearImage()
		{
			Reset();
			ClearImage(frameBuffer);
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

		public static void DrawWiredMesh(ConsoleGraphicsFrame frame, ITransformation transformation, IMesh mesh, bool drawWireFrame = false, bool clip = true)
		{
			foreach (var face in mesh.Faces)
			{
				var points = new List<Vector2>();
				foreach (var vector in face.Points)
				{
					var point = new Vector2(vector.X, vector.Y);
					points.Add(point);
				}

				DrawWiredPolygon(frame, transformation, points, drawWireFrame, clip);
			}
		}

		public static void DrawWiredMesh(ConsoleGraphicsFrame frame, ITransformation transformation, IEnumerable<IMesh> meshes, bool drawWireFrame = false, bool clip = true)
		{
			foreach (var mesh in meshes)
			{
				DrawWiredMesh(frame, transformation, mesh, drawWireFrame, clip);
			}
		}

		public static void DrawWiredPolygon(ConsoleGraphicsFrame frame, ITransformation transformation, IEnumerable<Vector2> vectors, bool drawWireFrame = false, bool clip = true)
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

				DrawLine(frame, transformation, point1, point2, drawWireFrame, clip);
			}

			DrawLine(frame, transformation, point2, firstPoint, drawWireFrame, clip);
		}

		public static void DrawWiredTriangle(ConsoleGraphicsFrame frame, ITransformation transformation, Vector2 point1, Vector2 point2, Vector2 point3, bool drawWireFrame = false, bool clip = true)
		{
			DrawLine(frame, transformation, point1, point2, drawWireFrame, clip);
			DrawLine(frame, transformation, point2, point3, drawWireFrame, clip);
			DrawLine(frame, transformation, point1, point3, drawWireFrame, clip);
		}

		public static void DrawWiredTriangle(ConsoleGraphicsFrame frame, ITransformation transformation, Vector3 point1, Vector3 point2, Vector3 point3, bool drawWireFrame = false, bool clip = true)
		{
			DrawLine(frame, transformation, point1, point2, drawWireFrame, clip);
			DrawLine(frame, transformation, point2, point3, drawWireFrame, clip);
			DrawLine(frame, transformation, point1, point3, drawWireFrame, clip);
		}

		public static void DrawAxes(ConsoleGraphicsFrame frame, ITransformation transformation, bool drawWireFrame = true)
		{
			DrawLine(frame, transformation, new Vector2(0, -frame.Height / 2), new Vector2(0, frame.Height / 2), drawWireFrame);
			DrawLine(frame, transformation, new Vector2(-frame.Width / 2, 0), new Vector2(frame.Width / 2, 0), drawWireFrame);
		}

		public static void DrawLine(ConsoleGraphicsFrame frame, ITransformation transformation, Vector3 point1, Vector3 point2, bool drawWireFrame = false, bool clip = true)
		{
			point1.X /= point1.Z;
			point1.Y /= point1.Z;
			point2.X /= point2.Z;
			point2.Y /= point2.Z;

			DrawLine(frame, transformation, new Vector2(point1.X, point1.Y), new Vector2(point2.X, point2.Y), drawWireFrame, clip);
		}

		public static void DrawLine(ConsoleGraphicsFrame frame, ITransformation transformation, Vector2 point1, Vector2 point2, bool drawWireFrame = false, bool clip = true)
		{
			transformation.Transform(ref point1);
			transformation.Transform(ref point2);

			var rise = point2.Y - point1.Y;
			var run = point2.X - point1.X;

			var pixelChar = halfPixelChar;

			if (run == 0) // so we don't divide by zero when calculating slope
			{
				if (drawWireFrame)
				{
					pixelChar = verticleWireFrameChar;
				}

				var currentPoint = new Vector2(point1.X, System.Math.Min(point1.Y, point2.Y));
				var endPoint = new Vector2(point2.X, System.Math.Max(point1.Y, point2.Y));

				while (currentPoint.Y < endPoint.Y)
				{
					var offetX = (frame.Width / 2) + currentPoint.X;
					var offsetY = (frame.Height / 2) - currentPoint.Y;

					var pixelX = (int) offetX;
					var pixelY = (int) offsetY;

					if (clip && pixelX >= 0 && pixelX < frame.Width && pixelY >= 0 && pixelY < frame.Height)
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

				if (drawWireFrame)
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

						if (clip && pixelX >= 0 && pixelX < frame.Width && pixelY >= 0 && pixelY < frame.Height)
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

						if (clip && pixelX >= 0 && pixelX < frame.Width && pixelY >= 0 && pixelY < frame.Height)
						{
							frame.CharacterBuffer[pixelX, pixelY] = pixelChar;
						}

						currentPoint.Y++;
						currentPoint.X += invSlope;
					}
				}
			}
		}

		public static void DrawPoints(ConsoleGraphicsFrame frame, ITransformation transformation, IEnumerable<Vector2> points)
		{
			foreach (var point in points)
			{
				DrawPoint(frame, transformation, point);
			}
		}

		public static void DrawPoints(ConsoleGraphicsFrame frame, ITransformation transformation, IEnumerable<Vector3> points)
		{
			foreach (var point in points)
			{
				DrawPoint(frame, transformation, point);
			}
		}

		public static void DrawPoint(ConsoleGraphicsFrame frame, ITransformation transformation, Vector2 point)
		{
			transformation.Transform(ref point);

			var offetX = (frame.Width / 2) + point.X;
			var offsetY = (frame.Height / 2) - point.Y;

			var pixelX = (int) offetX;
			var pixelY = (int) offsetY;

			frame.CharacterBuffer[pixelX, pixelY] = halfPixelChar;
		}

		public static void DrawPoint(ConsoleGraphicsFrame frame, ITransformation transformation, Vector3 point)
		{
			transformation.Transform(ref point);

			if (point.Z > 0)
			{
				var offetX = (frame.Width / 2) + point.X / point.Z;
				var offsetY = (frame.Height / 2) - point.Y / point.Z;

				var pixelX = (int) offetX;
				var pixelY = (int) offsetY;

				frame.CharacterBuffer[pixelX, pixelY] = halfPixelChar;
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

		public static void ClearImage(ConsoleGraphicsFrame frame)
		{
			frame.ClearBuffers();
		}
	}
}