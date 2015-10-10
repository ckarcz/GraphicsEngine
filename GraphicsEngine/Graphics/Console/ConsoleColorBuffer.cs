namespace GraphicsEngine.Graphics.Console
{
	public class ConsoleColorBuffer
		: IConsoleColorBuffer
	{
		private readonly byte[,] consoleColorBuffer;

		public ConsoleColorBuffer(int width, int height)
		{
			consoleColorBuffer = new byte[width, height];
			Width = width;
			Height = height;
		}

		public byte this[int x, int y]
		{
			get { return consoleColorBuffer[x, y]; }
			set { consoleColorBuffer[x, y] = value; }
		}

		public int Width { get; }
		public int Height { get; }

		public byte[,] GetMultiArrayAsCopy()
		{
			var copy = new byte[Width, Height];
			consoleColorBuffer.CopyTo(copy, 0);

			return copy;
		}
	}
}