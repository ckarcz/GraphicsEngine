namespace GraphicsEngine.Graphics
{
	public class ColorBuffer
		: IColorBuffer
	{
		private readonly ushort[,] consoleColorBuffer;

		public ColorBuffer(int width, int height)
		{
			consoleColorBuffer = new ushort[width, height];
			Width = width;
			Height = height;
		}

		public ushort this[int x, int y]
		{
			get { return consoleColorBuffer[x, y]; }
			set { consoleColorBuffer[x, y] = value; }
		}

		public int Width { get; private set; }
		public int Height { get; private set; }

		public ushort[,] GetMultiArrayAsCopy()
		{
			var copy = new ushort[Width, Height];
			consoleColorBuffer.CopyTo(copy, 0);

			return copy;
		}
	}
}