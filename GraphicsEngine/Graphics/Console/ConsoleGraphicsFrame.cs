namespace GraphicsEngine.Graphics.Console
{
	public class ConsoleGraphicsFrame
		: IConsoleGraphicsFrame
	{
		public const byte DefaultClearCharacter = 32;
		public const byte DefaultClearColor = 0;

		public ConsoleGraphicsFrame(int width, int height)
		{
			Width = width;
			Height = height;

			CharacterBuffer = new ConsoleCharacterBuffer(width, height);
			ColorBuffer = new ConsoleColorBuffer(width, height);
		}

		public ConsoleCharacterBuffer CharacterBuffer { get; private set; }
		public ConsoleColorBuffer ColorBuffer { get; private set; }
		public int Width { get; private set; }
		public int Height { get; private set; }

		IConsoleCharacterBuffer IConsoleGraphicsFrame.CharacterBuffer
		{
			get { return CharacterBuffer; }
		}

		IConsoleColorBuffer IConsoleGraphicsFrame.ColorBuffer
		{
			get { return ColorBuffer; }
		}

		public void ClearBuffers(byte? clearCharacter = null, byte? clearColor = null)
		{
			for (var x = 0; x < Width; x++)
			{
				for (var y = 0; y < Height; y++)
				{
					CharacterBuffer[x, y] = clearCharacter.HasValue ? clearCharacter.Value : DefaultClearCharacter;
					ColorBuffer[x, y] = clearColor.HasValue ? clearColor.Value : DefaultClearColor;
				}
			}
		}
	}
}