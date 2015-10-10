namespace GraphicsEngine.Graphics
{
	public class ShapeRasterizer
	{
		private readonly IConsoleScreenConfig consoleScreenConfig;

		public ShapeRasterizer(IConsoleScreenConfig consoleScreenConfig)
		{
			this.consoleScreenConfig = consoleScreenConfig;
		}

		public IRasterizedImage RasterizeTriangle()
		{
			var rasterizedImage = new RasterizedImage(consoleScreenConfig.Width, consoleScreenConfig.Height);

			return rasterizedImage;
		}
	}
}