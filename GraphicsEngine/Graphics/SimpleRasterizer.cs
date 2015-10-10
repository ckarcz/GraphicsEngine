using System.Collections.Generic;
using GraphicsEngine.Math;

namespace GraphicsEngine.Graphics
{
	public class SimpleRasterizer
	{
		private readonly int width;
		private readonly int height;

		public SimpleRasterizer(int width, int height)
		{
			this.width = width;
			this.height = height;
		}

		public IRasterizedImage RasterizePoints(IEnumerable<Vector2> points)
		{
			var rasterizedImage = new RasterizedImage(width, height);

			foreach (var point in points)
			{
				rasterizedImage.CharacterBuffer[(int)point.X, (int)point.Y] = (byte)'*';
			}

			return rasterizedImage;
		}

		public IRasterizedImage RasterizeTriangle()
		{
			var rasterizedImage = new RasterizedImage(width, height);

			return rasterizedImage;
		}
	}
}