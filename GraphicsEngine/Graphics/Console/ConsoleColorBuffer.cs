namespace GraphicsEngine.Graphics.Console
{
	public class ConsoleColorBuffer
		: IConsoleColorBuffer
	{
		public ConsoleColorBuffer(int width, int height)
		{
			Width = width;
			Height = height;
		}

		public int Width { get; }
		public int Height { get; }
	}
}