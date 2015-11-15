namespace GraphicsEngine.Graphics
{
	public interface ICharacterBuffer
	{
		byte this[int x, int y] { get; }
		int Width { get; }
		int Height { get; }

		byte[,] GetMultiArrayAsCopy();

		byte[] GetBytesCopy();
	}
}