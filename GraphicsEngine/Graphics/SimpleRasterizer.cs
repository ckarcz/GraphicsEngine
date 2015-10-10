using System.Collections.Generic;
using GraphicsEngine.Graphics.Console;
using GraphicsEngine.Math;

namespace GraphicsEngine.Graphics
{
	public class SimpleRasterizer
	{
		private readonly byte halfPixelChar = 219;
		private readonly int height;
		private readonly ConsoleGraphicsBuffer rasterizedImage;
		private readonly byte verticleWireFrameChar = 124; // '|'
		private readonly int width;

		public SimpleRasterizer(int width, int height)
		{
			this.width = width;
			this.height = height;

			rasterizedImage = new ConsoleGraphicsBuffer(width, height);
		}

		public void DrawLine(Vector2 point1, Vector2 point2, bool drawWireFrame = false)
		{
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
					var pixelX = (int) currentPoint.X;
					var pixelY = (int) currentPoint.Y;

					if (pixelX >= 0 && pixelX < width && pixelY >= 0 && pixelY < height)
					{
						rasterizedImage.CharacterBuffer[pixelX, pixelY] = pixelChar;
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
					if (slope > 0.5)
					{
						pixelChar = 92; // /
					}
					else if (slope < -0.5)
					{
						pixelChar = 47; // \
					}
					else
					{
						pixelChar = 95; // -
					}
				}

				var currentPoint = new Vector2(point1.X, point1.Y);
				var endPoint = new Vector2(point2.X, point2.Y);

				if (point1.X > point2.X)
				{
					currentPoint = new Vector2(point2.X, point2.Y);
					endPoint = new Vector2(point1.X, point1.Y);
				}

				while (currentPoint.X <= endPoint.X)
				{
					var pixelX = (int) currentPoint.X;
					var pixelY = (int) currentPoint.Y;

					if (pixelX >= 0 && pixelX < width && pixelY >= 0 && pixelY < height)
					{
						rasterizedImage.CharacterBuffer[pixelX, pixelY] = pixelChar;
					}

					currentPoint.X++;
					currentPoint.Y += slope;
				}
			}
		}

		public void DrawPoints(IEnumerable<Vector2> points)
		{
			foreach (var point in points)
			{
				var pixelX = (int) point.X;
				var pixelY = (int) point.Y;

				rasterizedImage.CharacterBuffer[pixelX, pixelY] = halfPixelChar;
			}
		}

		public void DrawPoints(IEnumerable<Vector3> points)
		{
			foreach (var point in points)
			{
				var pixelX = (int) (point.X / point.Z);
				var pixelY = (int) (point.Y / point.Z);

				rasterizedImage.CharacterBuffer[pixelX, pixelY] = halfPixelChar;
			}
		}

		public void DrawStringHorizontal(Vector2 location, string messageString)
		{
			var currentPixelX = (int) location.X;
			var constPixelY = (int) location.Y;

			foreach (var messageChar in messageString)
			{
				rasterizedImage.CharacterBuffer[currentPixelX, constPixelY] = (byte) messageChar;
				currentPixelX++;
			}
		}

		public void DrawStringVertical(Vector2 location, string messageString)
		{
			var currentPixelY = (int) location.Y;
			var constPixelX = (int) location.X;

			foreach (var messageChar in messageString)
			{
				rasterizedImage.CharacterBuffer[constPixelX, currentPixelY] = (byte) messageChar;
				currentPixelY++;
			}
		}

		public void ClearImage()
		{
			rasterizedImage.ClearBuffers();
		}

		public ConsoleGraphicsBuffer RasterizeImage()
		{
			return rasterizedImage;
		}
	}
}