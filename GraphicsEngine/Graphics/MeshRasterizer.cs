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

		public IRasterizedImage RasterizeAsVertices(IMesh mesh)
		{
			var rasterizedImage = new RasterizedImage(width, height);

			return rasterizedImage;
		}
	}
}