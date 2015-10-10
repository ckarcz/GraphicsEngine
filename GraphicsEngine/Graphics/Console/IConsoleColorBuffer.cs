namespace GraphicsEngine.Graphics.Console
{
	public interface IConsoleColorBuffer
	{
		byte this[int x, int y] { get; }
		int Width { get; }
		int Height { get; }

		byte[,] GetMultiArrayAsCopy();
	}
}