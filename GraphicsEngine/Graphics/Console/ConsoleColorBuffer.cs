namespace GraphicsEngine.Graphics.Console
{
	public class ConsoleColorBuffer
		: IConsoleColorBuffer
	{
		private readonly short[,] consoleColorBuffer;

		public ConsoleColorBuffer(int width, int height)
		{
			consoleColorBuffer = new short[width, height];
			Width = width;
			Height = height;
		}

		public short this[int x, int y]
		{
			get { return consoleColorBuffer[x, y]; }
			set { consoleColorBuffer[x, y] = value; }
		}

		public int Width { get; private set; }
		public int Height { get; private set; }

		public short[,] GetMultiArrayAsCopy()
		{
			var copy = new short[Width, Height];
			consoleColorBuffer.CopyTo(copy, 0);

			return copy;
		}
	}
}