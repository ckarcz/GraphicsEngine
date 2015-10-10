namespace GraphicsEngine.Graphics
{
	public class MeshRasterizer
	{
		private readonly IConsoleScreenConfig consoleScreenConfig;

		public MeshRasterizer(IConsoleScreenConfig consoleScreenConfig)
		{
			this.consoleScreenConfig = consoleScreenConfig;
		}

		public IRasterizedImage RasterizeAsVertices(IMesh mesh)
		{
			var rasterizedImage = new RasterizedImage(consoleScreenConfig.Width, consoleScreenConfig.Height);

			return rasterizedImage;
		}
	}
}