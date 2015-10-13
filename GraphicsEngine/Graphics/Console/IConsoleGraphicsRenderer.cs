namespace GraphicsEngine.Graphics.Console
{
	public interface IConsoleGraphicsRenderer
	{
		int Width { get; }

		int Height { get; }

		int Renderings { get; }

		void Render(IConsoleGraphicsFrame frame);

		void Clear();
	}
}