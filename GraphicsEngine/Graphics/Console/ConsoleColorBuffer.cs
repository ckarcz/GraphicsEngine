namespace GraphicsEngine.Graphics.Console
{
	public class ConsoleColorBuffer
		: IConsoleColorBuffer
	{
		public ConsoleColorBuffer(IConsoleScreenConfig consoleScreenConfig)
		{
			Width = consoleScreenConfig.Width;
			Height = consoleScreenConfig.Height;
		}

		public int Width { get; }
		public int Height { get; }
	}
}