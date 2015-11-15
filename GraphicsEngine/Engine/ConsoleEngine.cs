#region Imports

using GraphicsEngine.Graphics;

#endregion

namespace GraphicsEngine.Engine
{
	public class ConsoleEngine
		: IConsoleEngine
	{
		private readonly IRenderer renderer;
		private readonly IScene scene;

		public ConsoleEngine(IRenderer renderer, IScene scene)
		{
			this.renderer = renderer;
			this.scene = scene;
		}

		public bool IsRunning { get; private set; }
		public bool VSyncEnabled { get; private set; }
		public int CurrentFPS { get; private set; }
		public int AverageFPS { get; private set; }

		public int Renderings
		{
			get { return renderer.Renderings; }
		}

		public void Start()
		{
			if (!IsRunning)
			{
				Run();
			}
		}

		public void Stop()
		{
			IsRunning = false;
		}

		private void Run()
		{
			IsRunning = true;

			while (IsRunning)
			{
				scene.Update();
				Render(scene);
			}
		}

		private void Render(IScene scene)
		{
			var frameBuffer = scene.Rasterize();
			renderer.Render(frameBuffer);
		}
	}
}