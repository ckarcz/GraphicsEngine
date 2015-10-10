namespace GraphicsEngine.Graphics.Console
{
	public class ConsoleGraphicsBuffer
		: IConsoleGraphicsBuffer
	{
		public ConsoleGraphicsBuffer(int width, int height)
		{
			Width = width;
			Height = height;

			CharacterBuffer = new ConsoleCharacterBuffer(width, height);
			ColorBuffer = new ConsoleColorBuffer(width, height);
		}

		public ConsoleCharacterBuffer CharacterBuffer { get; private set; }
		public ConsoleColorBuffer ColorBuffer { get; private set; }
		public int Width { get; }
		public int Height { get; }

		IConsoleCharacterBuffer IConsoleGraphicsBuffer.CharacterBuffer
		{
			get { return CharacterBuffer; }
		}

		IConsoleColorBuffer IConsoleGraphicsBuffer.ColorBuffer
		{
			get { return ColorBuffer; }
		}

		public void ClearBuffers()
		{
			for (var x = 0; x < Width; x++)
			{
				for (var y = 0; y < Height; y++)
				{
					CharacterBuffer[x, y] = 32;
					ColorBuffer[x, y] = 32;
				}
			}
		}
	}
}