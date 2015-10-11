using System.Collections.Generic;
using GraphicsEngine.Graphics.Console;
using GraphicsEngine.Math;
using GraphicsEngine.Wavefront.Loaders;

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

		public void DrawWired(IWavefrontObj wavefrontObj, bool drawWireFrame = false)
		{
			foreach (var group in wavefrontObj.Groups)
			{
				foreach (var face in group.Faces)
				{
					var faceVertex1 = face[0];
					var faceVertex2 = face[1];
					var faceVertex3 = face[2];

					var geoVertex1 = wavefrontObj.Vertices[faceVertex1.VertexIndex - 1];
					var geoVertex2 = wavefrontObj.Vertices[faceVertex2.VertexIndex - 1];
					var geoVertex3 = wavefrontObj.Vertices[faceVertex3.VertexIndex - 1];

					var point1 = new Vector2(geoVertex1.X, geoVertex1.Y);
					var point2 = new Vector2(geoVertex2.X, geoVertex2.Y);
					var point3 = new Vector2(geoVertex3.X, geoVertex3.Y);

					DrawWiredTriangle(point1, point2, point3, drawWireFrame);
				}
			}
		}

		public void DrawWiredTriangle(Vector2 point1, Vector2 point2, Vector2 point3, bool drawWireFrame = false, bool clip = true)
		{
			DrawLine(point1, point2, drawWireFrame, clip);
			DrawLine(point2, point3, drawWireFrame, clip);
			DrawLine(point1, point3, drawWireFrame, clip);
		}

		public void DrawWiredTriangle(Vector3 point1, Vector3 point2, Vector3 point3, bool drawWireFrame = false, bool clip = true)
		{
			DrawLine(point1, point2, drawWireFrame, clip);
			DrawLine(point2, point3, drawWireFrame, clip);
			DrawLine(point1, point3, drawWireFrame, clip);
		}


		public void DrawAxes(bool drawWireFrame = true)
		{
			DrawLine(new Vector2(0, -height / 2), new Vector2(0, height / 2), drawWireFrame);
			DrawLine(new Vector2(-width / 2, 0), new Vector2(width / 2, 0), drawWireFrame);
		}

		public void DrawLine(Vector3 point1, Vector3 point2, bool drawWireFrame = false, bool clip = true)
		{
			point1.X /= point1.Z;
			point1.Y /= point1.Z;
			point2.X /= point2.Z;
			point2.Y /= point2.Z;

			DrawLine(new Vector2(point1.X, point1.Y), new Vector2(point2.X, point2.Y), drawWireFrame, clip);
		}

		public void DrawLine(Vector2 point1, Vector2 point2, bool drawWireFrame = false, bool clip = true)
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
					var offetX = (width / 2) + currentPoint.X;
					var offsetY = (height / 2) - currentPoint.Y;

					var pixelX = (int) offetX;
					var pixelY = (int) offsetY;

					if (clip && pixelX >= 0 && pixelX < width && pixelY >= 0 && pixelY < height)
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
						pixelChar = 47; // /
					}
					else if (slope < -0.5)
					{
						pixelChar = 92; // \
					}
					else
					{
						pixelChar = 95; // -
					}
				}

				var currentPoint = new Vector2(point1.X, point1.Y);
				var endPoint = new Vector2(point2.X, point2.Y);

				// start with left most point
				if (point1.X > point2.X)
				{
					currentPoint = new Vector2(point2.X, point2.Y);
					endPoint = new Vector2(point1.X, point1.Y);
				}

				// draw along x, left to right
				while (currentPoint.X <= endPoint.X)
				{
					var offetX = (width / 2) + currentPoint.X;
					var offsetY = (height / 2) - currentPoint.Y;

					var pixelX = (int)offetX;
					var pixelY = (int)offsetY;

					if (clip && pixelX >= 0 && pixelX < width && pixelY >= 0 && pixelY < height)
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
				DrawPoint(point);
			}
		}

		public void DrawPoints(IEnumerable<Vector3> points)
		{
			foreach (var point in points)
			{
				DrawPoint(point);
			}
		}

		public void DrawPoint(Vector2 point)
		{
			var offetX = (width / 2) + point.X;
			var offsetY = (height / 2) - point.Y;

			var pixelX = (int)offetX;
			var pixelY = (int)offsetY;

			rasterizedImage.CharacterBuffer[pixelX, pixelY] = halfPixelChar;
		}

		public void DrawPoint(Vector3 point)
		{
			if (point.Z > 0)
			{
				var offetX = (width / 2) + point.X / point.Z;
				var offsetY = (height / 2) - point.Y / point.Z;

				var pixelX = (int)offetX;
				var pixelY = (int)offsetY;

				rasterizedImage.CharacterBuffer[pixelX, pixelY] = halfPixelChar;
			}
		}

		public void DrawStringHorizontal(Vector2 location, string messageString)
		{
			var offetX = (width / 2) + location.X;
			var offsetY = (height / 2) - location.Y;

			var currentPixelX = (int)offetX;
			var constPixelY = (int)offsetY;

			foreach (var messageChar in messageString)
			{
				rasterizedImage.CharacterBuffer[currentPixelX, constPixelY] = (byte) messageChar;
				currentPixelX++;
			}
		}

		public void DrawStringVertical(Vector2 location, string messageString)
		{
			var offetX = (width / 2) + location.X;
			var offsetY = (height / 2) - location.Y;

			var currentPixelY = (int)offsetY;
			var constPixelX = (int)offetX;

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