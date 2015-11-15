namespace GraphicsEngine.Graphics
{
	public interface IGraphicsFrame
	{
		int Width { get; }
		int Height { get; }
		ICharacterBuffer CharacterBuffer { get; }
		IColorBuffer ColorBuffer { get; }
	}
}