namespace GraphicsEngine.Graphics
{
	public interface IRenderer
	{
		int Width { get; }
		int Height { get; }
		int Renderings { get; }

		void Render(IGraphicsBuffer frame);
	}
}