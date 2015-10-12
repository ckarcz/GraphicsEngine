#region Imports

using GraphicsEngine.Graphics.Console;

#endregion

namespace GraphicsEngine.Engine
{
	public interface IScene
	{
		void Update();

		IConsoleGraphicsFrame Render();
	}
}