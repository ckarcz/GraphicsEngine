namespace GraphicsEngine.Graphics
{
	public class Renderer
		: IRenderer
	{
		private readonly IConsoleWindow consoleScreen;

		public Renderer(IConsoleWindow consoleScreen)
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

		public void Render(IFrameBuffer frame)
		{
			for (int x = 0; x < frame.Width; x++)
			{
				for (int y = 0; y < frame.Height; y++)
				{
					consoleScreen.SetPixel(x, y, frame.CharacterBuffer[x, y], frame.ColorBuffer[x, y]);
				}
			}

			consoleScreen.Draw();

			Renderings++;
		}

		public void Clear(byte? character = null, ushort? color = null)
		{
			consoleScreen.Clear(character, color);
		}
	}
}