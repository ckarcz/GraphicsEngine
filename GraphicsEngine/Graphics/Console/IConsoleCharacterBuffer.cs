namespace GraphicsEngine.Graphics.Console
{
	public interface IConsoleCharacterBuffer
	{
		byte this[int x, int y] { get; }
		int Width { get; }
		int Height { get; }

		byte[,] GetScreenCharacterBufferCopy();

		byte[] GetBytesCopy();
	}
}