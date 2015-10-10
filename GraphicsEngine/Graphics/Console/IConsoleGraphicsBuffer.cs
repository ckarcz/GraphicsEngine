namespace GraphicsEngine.Graphics.Console
{
	public interface IConsoleGraphicsBuffer
	{
		int Width { get; }
		int Height { get; }
		IConsoleCharacterBuffer CharacterBuffer { get; }
		IConsoleColorBuffer ColorBuffer { get; }
	}
}