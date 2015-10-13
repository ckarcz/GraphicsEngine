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

			System.Windows.Forms.MessageBox.Show("Top row digits 1-8 load models.\n\nUp/Down/Left/Right translation.\n[/] scale.");

			var screen = new SimpleConsoleScreen(consoleScreenWidth, consoleScreenHeight, "Graphics Engine Test", ConsoleColor.Black, ConsoleColor.Cyan);
			//var screen = new Kernel32ConsoleScreen(consoleScreenWidth, consoleScreenHeight);

			var renderer = new ConsoleGraphicsRenderer(screen);
			var scene = new TestScene(consoleScreenWidth, consoleScreenHeight);
			var engine = new ConsoleEngine(renderer, scene);

			engine.Start();
		}
	}
}