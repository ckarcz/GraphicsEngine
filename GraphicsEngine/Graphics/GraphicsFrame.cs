namespace GraphicsEngine.Graphics
{
	public class GraphicsFrame
		: IGraphicsFrame
	{
		public const byte DefaultClearCharacter = 32;
		public const byte DefaultClearColor = 0;

		public GraphicsFrame(int width, int height)
		{
			Width = width;
			Height = height;

			ZBuffer = new float?[width, height];
			CharacterBuffer = new CharacterBuffer(width, height);
			ColorBuffer = new ColorBuffer(width, height);
		}

		public float?[,] ZBuffer { get; private set; }
		public CharacterBuffer CharacterBuffer { get; }
		public ColorBuffer ColorBuffer { get; }
		public int Width { get; }
		public int Height { get; }

		ICharacterBuffer IGraphicsFrame.CharacterBuffer
		{
			get { return CharacterBuffer; }
		}

		IColorBuffer IGraphicsFrame.ColorBuffer
		{
			get { return ColorBuffer; }
		}

		public void Reset(byte? clearCharacter = null, byte? clearColor = null)
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