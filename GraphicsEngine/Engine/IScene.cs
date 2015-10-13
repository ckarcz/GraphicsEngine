#region Imports

using GraphicsEngine.Graphics.Console;

#endregion

namespace GraphicsEngine.Engine
{
	public interface IScene
	{
		int Width { get; }
		int Height { get; }

		void Update();

		void Draw();

		ConsoleGraphicsFrame Rasterize();
	}
}