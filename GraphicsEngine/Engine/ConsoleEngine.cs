#region Imports

using System;
using GraphicsEngine.Graphics;
using GraphicsEngine.Math;

#endregion

namespace GraphicsEngine.Engine
{
	public class ConsoleEngine
		: IConsoleEngine
	{
		private readonly IGraphicsRenderer renderer;
		private readonly IScene scene;

		public ConsoleEngine(IGraphicsRenderer renderer, IScene scene)
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
				var frame = scene.Rasterize();
				Render(frame);
			}
		}

		private void Render(GraphicsFrame frame)
		{
			renderer.Render(frame);
		}
	}
}