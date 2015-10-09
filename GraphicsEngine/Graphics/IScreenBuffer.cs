namespace GraphicsEngine.Graphics
{
	public interface IScreenBuffer
	{
		byte this[int x, int y] { get; set; }
		int Width { get; }
		int Height { get; }

		byte[,] GetScreenBufferBytes();
	}
}