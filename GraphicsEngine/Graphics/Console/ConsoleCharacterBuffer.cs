namespace GraphicsEngine.Graphics.Console
{
	public class ConsoleCharacterBuffer
		: IConsoleCharacterBuffer
	{
		private readonly byte[,] screenCharacterBuffer;

		public ConsoleCharacterBuffer(int width, int height)
		{
			screenCharacterBuffer = new byte[width, height];
			Width = width;
			Height = height;
		}

		public byte this[int x, int y]
		{
			get { return screenCharacterBuffer[x, y]; }
			set { screenCharacterBuffer[x, y] = value; }
		}

		public int Width { get; }
		public int Height { get; }

		public byte[,] GetScreenCharacterBufferCopy()
		{
			var screenBufferCopy = new byte[Width, Height];
			screenCharacterBuffer.CopyTo(screenBufferCopy, 0);

			return screenBufferCopy;
		}

		public byte[] GetBytesCopy()
		{
			var screenBufferBytes = new byte[Width * Height];
			for (var x = 0; x < Width; x++)
			{
				for (var y = 0; y < Height; y++)
				{
					screenBufferBytes[x + y * Width] = screenCharacterBuffer[x, y];
				}
			}

			return screenBufferBytes;
		}
	}
}