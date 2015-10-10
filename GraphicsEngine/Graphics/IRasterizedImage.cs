using GraphicsEngine.Graphics.Console;

namespace GraphicsEngine.Graphics
{
	public interface IRasterizedImage
	{
		int Width { get; }
		int Height { get; }
		IConsoleCharacterBuffer CharacterBuffer { get; }
		IConsoleColorBuffer ColorBuffer { get; }
	}
}