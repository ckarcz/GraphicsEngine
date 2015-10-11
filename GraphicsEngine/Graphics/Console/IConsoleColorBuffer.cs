namespace GraphicsEngine.Graphics.Console
{
	public interface IConsoleColorBuffer
	{
		short this[int x, int y] { get; }
		int Width { get; }
		int Height { get; }

		short[,] GetMultiArrayAsCopy();
	}
}