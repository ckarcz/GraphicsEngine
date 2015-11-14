namespace GraphicsEngine.Graphics.Console
{
	public class ConsoleGraphicsRenderer
		: IConsoleGraphicsRenderer
	{
		private readonly IConsoleScreen consoleScreen;

		public ConsoleGraphicsRenderer(IConsoleScreen consoleScreen)
		{
			this.consoleScreen = consoleScreen;
		}

		public int Width
		{
			get { return consoleScreen.Width; }
		}

		public int Height
		{
			get { return consoleScreen.Height; }
		}

		public int Renderings { get; private set; }

		public void Render(IConsoleGraphicsFrame frame)
		{
			for (int x = 0; x < frame.Width; x++)
			{
				for (int y = 0; y < frame.Height; y++)
				{
					consoleScreen.SetPixel(x, y, frame.CharacterBuffer[x, y], frame.ColorBuffer[x, y]);
				}
			}

			consoleScreen.Write();

			Renderings++;
		}

		public void Clear(byte? character = null, short? color = null)
		{
			consoleScreen.Clear(character, color);
		}
	}
}