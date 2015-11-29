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

			//MessageBox.Show("Top row digits 1-8 switches models.\n\nUp & Down & Left & Right translation.\n[ & ] scale.\n\DefaultColors & K & L & O & P rotate.");

			var screen = new Kernel32ConsoleWindow(consoleScreenWidth, consoleScreenHeight, "Graphics Engine Test", 0x0000);
			var renderer = new Renderer(screen);
			var meshTestScene = new MeshTestScene(consoleScreenWidth, consoleScreenHeight);
			var engine = new ConsoleEngine(renderer, meshTestScene);
			engine.Start();

			Console.ReadLine();
		}
	}
}