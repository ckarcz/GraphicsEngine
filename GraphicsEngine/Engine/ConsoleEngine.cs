#region Imports

using System;
using System.Threading;
using GraphicsEngine.Graphics.Console;

#endregion

namespace GraphicsEngine.Engine
{
	public class ConsoleEngine
		: IConsoleEngine
	{
		private readonly IConsoleGraphicsRenderer renderer;
		private readonly IScene scene;

		public ConsoleEngine(IConsoleGraphicsRenderer renderer, IScene scene)
		{
			this.renderer = renderer;
			this.scene = scene;
		}

		public bool IsRunning { get; private set; }
		public int FPS { get; private set; }

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
				scene.Render();

				Thread.Sleep(22);
			}
		}
	}
}