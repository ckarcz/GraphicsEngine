namespace GraphicsEngine.Graphics
{
	public interface IRenderer
	{
		int Width { get; }
		int Height { get; }
		int Renderings { get; }

		void Render(IFrameBuffer frame);

		void Clear(byte? character = null, short? color = null);
	}
}