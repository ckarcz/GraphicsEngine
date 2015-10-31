#region Imports

using System;
using GraphicsEngine.Graphics;
using GraphicsEngine.Graphics.Console;
using GraphicsEngine.Math;

#endregion

namespace GraphicsEngine.Engine
{
	public class ConsoleEngine
		: IConsoleEngine
	{
		private readonly IConsoleGraphicsRenderer renderer;
		private readonly IScene scene;

		public ConsoleEngine(IConsoleGraphicsRenderer renderer, IScene scene, bool vsync = true)
		{
			this.renderer = renderer;
			this.scene = scene;

			VSyncEnabled = vsync;
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

			var startTick = Environment.TickCount;
			var currentTick = startTick;
			var lastTick = currentTick;
			var deltaTick = currentTick - lastTick;

			var lastUpdateTick = currentTick;
			var deltaUpdateTick = currentTick - lastUpdateTick;

			var lastRenderTick = currentTick;
			var deltaRenderTick = currentTick - lastRenderTick;

			var updateRate = 1;
			var renderRate = 1;

			var shouldUpdate = true;
			var shouldRender = true;

			var startTime = DateTime.UtcNow;

			while (IsRunning)
			{
				lastTick = currentTick;
				currentTick = Environment.TickCount;
				deltaTick = currentTick - lastTick;
				deltaUpdateTick = currentTick - lastUpdateTick;
				deltaRenderTick = currentTick - lastRenderTick;

				if (deltaUpdateTick >= updateRate)
				{
					shouldUpdate = true;
				}

				if (deltaRenderTick >= renderRate)
				{
					shouldRender = true;
				}

				if (shouldUpdate)
				{
					scene.Update();
					lastUpdateTick = currentTick;
					shouldUpdate = false;
				}

				if (shouldRender)
				{
					scene.Draw();
					var frame = scene.Rasterize();
					Render(frame);
					lastRenderTick = currentTick;
					shouldRender = false;
					var secondsElapsed = (DateTime.UtcNow - startTime).Seconds;
					AverageFPS = secondsElapsed == 0 ? secondsElapsed : Renderings / secondsElapsed;
				}
			}
		}

		private void Render(ConsoleGraphicsFrame frame)
		{
			LazyRasterizer.DrawStringHorizontal(frame, Transformation.None, new Vector2(-scene.Width / 2, -(scene.Height) / 2) + 1, string.Format("FRAMES RENDERED: {0} AVG FPS: {1} CURRENT FPS: {2}", Renderings, AverageFPS, CurrentFPS));
			renderer.Render(frame);
		}
	}
}