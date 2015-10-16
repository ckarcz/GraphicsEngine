#region Imports

using System;
using System.Windows.Forms;
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
			var consoleScreenWidth = Console.LargestWindowWidth - 10;
			var consoleScreenHeight = Console.LargestWindowHeight - 10;

			MessageBox.Show("Top row digits 1-8 switches models.\n\nUp & Down & Left & Right translation.\n[ & ] scale.\n\n, & . & K & L & O & P rotate.");

			var screen = new SimpleConsoleScreen(consoleScreenWidth, consoleScreenHeight, "Graphics Engine Test", ConsoleColor.DarkBlue, ConsoleColor.Cyan);
			//var screen = new Kernel32ConsoleScreen(consoleScreenWidth, consoleScreenHeight);

			var renderer = new ConsoleGraphicsRenderer(screen);
			var scene = new TestScene(consoleScreenWidth, consoleScreenHeight);
			var engine = new ConsoleEngine(renderer, scene);

			engine.Start();
		}
	}
}