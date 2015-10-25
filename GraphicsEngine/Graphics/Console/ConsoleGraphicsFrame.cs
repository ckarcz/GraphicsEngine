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

			ZBuffer = new float?[width, height];
			CharacterBuffer = new ConsoleCharacterBuffer(width, height);
			ColorBuffer = new ConsoleColorBuffer(width, height);
		}

		public float?[,] ZBuffer { get; private set; }
		public ConsoleCharacterBuffer CharacterBuffer { get; }
		public ConsoleColorBuffer ColorBuffer { get; }
		public int Width { get; }
		public int Height { get; }

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
					ZBuffer[x, y] = null;
					CharacterBuffer[x, y] = clearCharacter.HasValue ? clearCharacter.Value : DefaultClearCharacter;
					ColorBuffer[x, y] = clearColor.HasValue ? clearColor.Value : DefaultClearColor;
				}
			}
		}
	}
}