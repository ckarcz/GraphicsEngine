namespace GraphicsEngine.Graphics.Console
{
	public interface IConsoleGraphicsRenderer
	{
		int NumberRenderings { get; }

		void Render(IConsoleGraphicsFrame frame);

		void Clear();
	}
}