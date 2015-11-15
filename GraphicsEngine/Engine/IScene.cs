#region Imports

using GraphicsEngine.Graphics;

#endregion

namespace GraphicsEngine.Engine
{
	public interface IScene
	{
		int Width { get; }
		int Height { get; }

		void Update();

		GraphicsFrame Rasterize();
	}
}