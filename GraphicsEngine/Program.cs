#region Imports

using System;
using System.Drawing;
using System.Windows.Forms;
using GraphicsEngine.Engine;
using GraphicsEngine.Graphics.Console;
using GraphicsEngine.Win32;

#endregion

namespace GraphicsEngine
{
	internal class Program
	{
		[STAThread]
		private static void Main(string[] args)
		{
			var consoleScreenWidth = 300;
			var consoleScreenHeight = 120;

			//MessageBox.Show("Top row digits 1-8 switches models.\n\nUp & Down & Left & Right translation.\n[ & ] scale.\n\n, & . & K & L & O & P rotate.");

			var screen = new Kernel32ConsoleScreen(consoleScreenWidth, consoleScreenHeight, "Graphics Engine Test", 0x0000);
			//var screen = new SimpleConsoleScreen(consoleScreenWidth, consoleScreenHeight, "Graphics Engine Test", ConsoleColor.DarkBlue, ConsoleColor.Cyan);

			var renderer = new ConsoleGraphicsRenderer(screen);
			var scene = new TestScene(consoleScreenWidth, consoleScreenHeight);
			var engine = new ConsoleEngine(renderer, scene);

			engine.Start();

			Console.ReadLine();
		}
	}
}