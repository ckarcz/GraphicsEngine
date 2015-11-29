namespace GraphicsEngine.Graphics
{
	public interface IGraphicsBuffer
	{
		int Width { get; }
		int Height { get; }
		ICharacterBuffer CharacterBuffer { get; }
		IColorBuffer ColorBuffer { get; }
	}
}