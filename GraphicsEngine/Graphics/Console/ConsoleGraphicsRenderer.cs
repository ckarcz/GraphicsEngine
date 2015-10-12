#region Imports

using System;
using System.IO;

#endregion

namespace GraphicsEngine.Graphics.Console
{
	public class ConsoleGraphicsRenderer
		: IConsoleGraphicsRenderer
	{
		private readonly IConsoleScreen consoleScreen;

		public ConsoleGraphicsRenderer(IConsoleScreen consoleScreen)
		{
			this.consoleScreen = consoleScreen;
		}

		public int Width
		{
			get { return consoleScreen.Width; }
		}

		public int Height
		{
			get { return consoleScreen.Height; }
		}

		public int NumberRenderings { get; private set; }

		public void Render(IConsoleGraphicsFrame frame)
		{
			consoleScreen.SetFrame(frame);
			consoleScreen.Draw();

			NumberRenderings++;
		}

		public void Clear()
		{
			System.Console.Clear();
		}
	}
}