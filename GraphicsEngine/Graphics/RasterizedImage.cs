using GraphicsEngine.Graphics.Console;

namespace GraphicsEngine.Graphics
{
	public class RasterizedImage
		: IRasterizedImage
	{
		public RasterizedImage(IConsoleScreenConfig consoleScreenConfig)
		{
			Width = consoleScreenConfig.Width;
			Height = consoleScreenConfig.Height;
		}

		public RasterizedImage(int width, int height)
		{
			Width = width;
			Height = height;
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