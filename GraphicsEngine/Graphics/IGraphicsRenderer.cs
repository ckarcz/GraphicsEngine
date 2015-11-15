namespace GraphicsEngine.Graphics
{
	public interface IGraphicsRenderer
	{
		int Width { get; }
		int Height { get; }
		int Renderings { get; }

		void Render(IGraphicsFrame frame);

		void Clear(byte? character = null, short? color = null);
	}
}