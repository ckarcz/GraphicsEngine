namespace GraphicsEngine.Graphics
{
	public interface IColorBuffer
	{
		short this[int x, int y] { get; }
		int Width { get; }
		int Height { get; }

		short[,] GetMultiArrayAsCopy();
	}
}