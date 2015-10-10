using GraphicsEngine.Graphics.Console;

namespace GraphicsEngine.Graphics
{
	public class RasterizedImage
		: IRasterizedImage
	{
		public RasterizedImage(int width, int height)
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

		IConsoleCharacterBuffer IRasterizedImage.CharacterBuffer
		{
			get { return CharacterBuffer; }
		}

		IConsoleColorBuffer IRasterizedImage.ColorBuffer
		{
			get { return ColorBuffer; }
		}
	}
}