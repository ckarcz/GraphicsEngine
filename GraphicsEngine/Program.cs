#region Imports

using System;
using GraphicsEngine.Engine;
using GraphicsEngine.Graphics.Console;

#endregion

namespace GraphicsEngine
{
	internal class Program
	{
		[STAThread]
		private static void Main(string[] args)
		{
			var consoleScreenWidth = 330;
			var consoleScreenHeight = 130;

			var screen = new SimpleConsoleScreen(consoleScreenWidth, consoleScreenHeight, "Graphics Engine Test", ConsoleColor.DarkBlue, ConsoleColor.Cyan);
			//var screen = new Kernel32ConsoleScreen(consoleScreenWidth, consoleScreenHeight);

			var renderer = new ConsoleGraphicsRenderer(screen);
			var scene = new LinkTestScene(renderer);
			var engine = new ConsoleEngine(renderer, scene);

			engine.Start();
		}
	}
}