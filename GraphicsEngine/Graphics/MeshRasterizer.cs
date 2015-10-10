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

		public IConsoleGraphicsBuffer RasterizeAsVertices(IMesh mesh)
		{
			var rasterizedImage = new ConsoleGraphicsBuffer(width, height);

			return rasterizedImage;
		}
	}
}