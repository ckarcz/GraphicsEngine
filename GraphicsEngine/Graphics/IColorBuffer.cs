namespace GraphicsEngine.Graphics
{
	public interface IColorBuffer
	{
		ushort this[int x, int y] { get; }
		int Width { get; }
		int Height { get; }

		ushort[,] GetMultiArrayAsCopy();
	}
}