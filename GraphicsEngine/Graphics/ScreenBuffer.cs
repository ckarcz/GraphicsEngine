namespace GraphicsEngine.Graphics
{
	public class ScreenBuffer
		: IScreenBuffer
	{
		private readonly byte[,] screenBuffer;

		public ScreenBuffer(int width, int height)
		{
			screenBuffer = new byte[width, height];
			Width = width;
			Height = height;
		}

		public byte this[int x, int y]
		{
			get { return screenBuffer[x, y]; }
			set { screenBuffer[x, y] = value; }
		}

		public int Width { get; }
		public int Height { get; }

		public byte[,] GetScreenBufferBytes()
		{
			return screenBuffer;
		}
	}
}