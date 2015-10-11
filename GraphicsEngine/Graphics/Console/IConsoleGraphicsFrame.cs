namespace GraphicsEngine.Graphics.Console
{
	public interface IConsoleGraphicsFrame
	{
		int Width { get; }
		int Height { get; }
		IConsoleCharacterBuffer CharacterBuffer { get; }
		IConsoleColorBuffer ColorBuffer { get; }
	}
}