namespace GraphicsEngine.Graphics
{
	public interface IRasterizer
	{
		IScreenBuffer RasterizeVertices(IMesh mesh);
	}
}