using GraphicsEngine.Graphics.Console;

namespace GraphicsEngine.Graphics
{
	public class MeshRasterizer
	{
		private readonly int width;
		private readonly int height;

		public MeshRasterizer(int width, int height)
		{
			this.width = width;
			this.height = height;
		}

		public IConsoleGraphicsFrame RasterizeAsVertices(IMesh mesh)
		{
			var rasterizedImage = new ConsoleGraphicsFrame(width, height);

			return rasterizedImage;
		}
	}
}