#region Imports

using System;
using GraphicsEngine.Engine;
using GraphicsEngine.Graphics;
using GraphicsEngine.Scenes;

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

			var renderer = new GraphicsRenderer(screen);

			var randomLinesScene = new RandomLinesScene(consoleScreenWidth, consoleScreenHeight);
			var randomCharactersScene = new RandomCharactersScene(consoleScreenWidth, consoleScreenHeight);
			var meshTestScene = new MeshTestScene(consoleScreenWidth, consoleScreenHeight);

			var engine = new ConsoleEngine(renderer, meshTestScene);

			engine.Start();

			Console.ReadLine();
		}
	}
}