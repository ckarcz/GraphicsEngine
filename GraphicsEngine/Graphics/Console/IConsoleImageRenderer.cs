namespace GraphicsEngine.Graphics.Console
{
	public interface IConsoleImageRenderer
	{
		int NumberRenderings { get; }

		void Render(IConsoleGraphicsBuffer rasterizedImage);

		void Clear();
	}
}