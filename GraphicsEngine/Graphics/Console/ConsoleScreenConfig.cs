namespace GraphicsEngine.Graphics
{
	public class ConsoleScreenConfig
		: IConsoleScreenConfig
	{
		public ConsoleScreenConfig(int width, int height)
		{
			Width = width;
			Height = height;
		}

		public int Width { get; private set; }

		public int Height { get; private set; }
	}
}