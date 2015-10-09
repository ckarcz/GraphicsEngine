namespace GraphicsEngine.Graphics
{
	public class Rasterizer
		: IRasterizer
	{
		private readonly int height;
		private readonly int width;

		public Rasterizer(int width, int height)
		{
			this.width = width;
			this.height = height;
		}

		public IScreenBuffer RasterizeVertices(IMesh mesh)
		{
			var screenBuffer = new ScreenBuffer(width, height);

			return screenBuffer;
		}
	}
}