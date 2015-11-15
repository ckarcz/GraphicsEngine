namespace GraphicsEngine.Graphics
{
	public interface IFrameBuffer
	{
		int Width { get; }
		int Height { get; }
		ICharacterBuffer CharacterBuffer { get; }
		IColorBuffer ColorBuffer { get; }
	}
}