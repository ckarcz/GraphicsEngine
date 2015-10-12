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

		public int FPS { get; private set; }
		public int Renderings { get; private set; }

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

			var currentTick = Environment.TickCount;
			var lastTick = currentTick;
			var deltaTick = currentTick - lastTick;

			var lastUpdateTick = currentTick;
			var deltaUpdateTick = currentTick - lastUpdateTick;

			var lastRenderTick = currentTick;
			var deltaRenderTick = currentTick - lastRenderTick;

			var updateRate = 1;
			var renderRate = 35;

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
                    FPS = secondsElapsed == 0 ? secondsElapsed : Renderings / secondsElapsed;
				}
			}
		}

		private void Render(ConsoleGraphicsFrame frame)
		{
			Renderings++;
			Rasterizer.DrawStringHorizontal(frame, Transformation.None, new Vector2(-scene.Width / 2, -(scene.Height) / 2) + 1, string.Format("FRAMES RENDERED: {0}\tFPS: {1}", Renderings, FPS));
			renderer.Render(frame);
		}
	}
}