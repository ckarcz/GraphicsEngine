#region Imports

using System;
using System.IO;
using System.Text;
using GraphicsEngine.Graphics;
using GraphicsEngine.Graphics.Console;
using GraphicsEngine.Math;
using GraphicsEngine.Wavefront.Loaders;
using GraphicsEngine.Win32;

#endregion

namespace GraphicsEngine
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			var consoleScreenWidth = 300;
			var consoleScreenHeight = 100;

			//var screen = new SimpleConsoleScreen(consoleScreenWidth, consoleScreenHeight, "Graphics Engine Test", ConsoleColor.DarkBlue, ConsoleColor.Cyan);
			var screen = new Kernel32ConsoleScreen(consoleScreenWidth, consoleScreenHeight);

			var renderer = new ConsoleGraphicsRenderer(screen);
			var rasterizer = new SimpleRasterizer(consoleScreenWidth, consoleScreenHeight);

			// color test
			screen.SetPixel(50, 50, (short)(Kernel32Console.DefaultColors.BACKGROUND_MAGENTA));
			screen.SetPixel(55, 50, (short)(Kernel32Console.DefaultColors.BACKGROUND_YELLOW));
			screen.SetPixel(60, 50, (short)(Kernel32Console.DefaultColors.BACKGROUND_CYAN));
			screen.SetPixel(65, 50, (short)(Kernel32Console.DefaultColors.BACKGROUND_GREY));
			screen.Draw();

			var wavefrontObjLoaderFactory = new WavefrontObjLoaderFactory();
			var wavefrontObjLoader = wavefrontObjLoaderFactory.Create(new MaterialNullStreamProvider()); 
			var wavefrontObjFilePathString = "f1.obj";
			var wavefrontObjFileStream = File.Open(wavefrontObjFilePathString, FileMode.Open, FileAccess.Read);
			var wavefrontObj = wavefrontObjLoader.LoadWavefrontObj(wavefrontObjFileStream);
			var wavefrontObjToMeshConverter = new WavefrontObjToMeshConverter();
			var meshes = wavefrontObjToMeshConverter.ConvertToMesh(wavefrontObj);

			Console.ReadLine();

			bool renderThinWires = true;

			loop:
			rasterizer.ClearImage();
			rasterizer.DrawAxes();
			renderer.Render(rasterizer.RasterizeImage());

			var linePoint1 = new Vector2(0, 0);
			var linePoint2 = new Vector2(50, 50);
			var rise = linePoint2.Y - linePoint1.Y;
			var run = linePoint2.X - linePoint1.X;
			var lineSlope = run == 0 ? 1 : rise / run;
			rasterizer.DrawStringHorizontal(new Vector2(-50, -10), string.Format("SLOPE: {0}", lineSlope));
			rasterizer.DrawLine(linePoint1, linePoint2, renderThinWires);

			renderer.Render(rasterizer.RasterizeImage());

			Console.ReadLine();

			rasterizer.ClearImage();
			rasterizer.DrawAxes();
			renderer.Render(rasterizer.RasterizeImage());

			linePoint1 = new Vector2(0, 0);
			linePoint2 = new Vector2(75, 50);
			rise = linePoint2.Y - linePoint1.Y;
			run = linePoint2.X - linePoint1.X;
			lineSlope = run == 0 ? 1 : rise / run;
			rasterizer.DrawStringHorizontal(new Vector2(-50, -10), string.Format("SLOPE: {0}", lineSlope));
			rasterizer.DrawLine(linePoint1, linePoint2, renderThinWires);

			renderer.Render(rasterizer.RasterizeImage());

			Console.ReadLine();

			rasterizer.ClearImage();
			rasterizer.DrawAxes();
			renderer.Render(rasterizer.RasterizeImage());

			linePoint1 = new Vector2(0, 0);
			linePoint2 = new Vector2(5, 50);
			rise = linePoint2.Y - linePoint1.Y;
			run = linePoint2.X - linePoint1.X;
			lineSlope = run == 0 ? 1 : rise / run;
			rasterizer.DrawStringHorizontal(new Vector2(-50, -10), string.Format("SLOPE: {0}", lineSlope));
			rasterizer.DrawLine(linePoint1, linePoint2, renderThinWires);

			renderer.Render(rasterizer.RasterizeImage());

			Console.ReadLine();

			rasterizer.ClearImage();
			rasterizer.DrawAxes();
			renderer.Render(rasterizer.RasterizeImage());

			linePoint1 = new Vector2(0, 0);
			linePoint2 = new Vector2(-10, 50);
			rise = linePoint2.Y - linePoint1.Y;
			run = linePoint2.X - linePoint1.X;
			lineSlope = run == 0 ? 1 : rise / run;
			rasterizer.DrawStringHorizontal(new Vector2(-50, -10), string.Format("SLOPE: {0}", lineSlope));
			rasterizer.DrawLine(linePoint1, linePoint2, renderThinWires);

			renderer.Render(rasterizer.RasterizeImage());

			Console.ReadLine();

			rasterizer.ClearImage();
			rasterizer.DrawAxes();
			renderer.Render(rasterizer.RasterizeImage());

			linePoint1 = new Vector2(0, 0);
			linePoint2 = new Vector2(10, -50);
			rise = linePoint2.Y - linePoint1.Y;
			run = linePoint2.X - linePoint1.X;
			lineSlope = run == 0 ? 1 : rise / run;
			rasterizer.DrawStringHorizontal(new Vector2(-50, -10), string.Format("SLOPE: {0}", lineSlope));
			rasterizer.DrawLine(linePoint1, linePoint2, renderThinWires);

			renderer.Render(rasterizer.RasterizeImage());

			Console.ReadLine();

			rasterizer.ClearImage();
			rasterizer.DrawAxes();
			renderer.Render(rasterizer.RasterizeImage());

			var linePoint3 = new Vector3(0, 0, 1);
			var linePoint4 = new Vector3(50, 50, 2);
			rasterizer.DrawStringHorizontal(new Vector2(-50, -10), "3D->2D PROJECTED LINE");
			rasterizer.DrawLine(linePoint3, linePoint4, renderThinWires);

			renderer.Render(rasterizer.RasterizeImage());

			Console.ReadLine();

			rasterizer.ClearImage();
			rasterizer.DrawAxes();
			renderer.Render(rasterizer.RasterizeImage());

			rasterizer.DrawWiredPolygon(new [] {new Vector2(-100, -45), new Vector2(-45, -45), new Vector2(-20, -5), new Vector2(15, -27), new Vector2(36, -2), new Vector2(45, 15), new Vector2(25, 45), new Vector2(5, 15), new Vector2(-35, 10)}, renderThinWires, true);

			renderer.Render(rasterizer.RasterizeImage());

			Console.ReadLine();

			rasterizer.ClearImage();
			rasterizer.DrawAxes();

			var a = new Vector2(-140, -45);
			var b = new Vector2(-100, -45);
			var c = new Vector2(-85, -25);
			var d = new Vector2(-125, -25);

			var spacer = 1;
			for (var i = 0; i < 50; i++)
			{
				rasterizer.DrawWiredPolygon(new[] {a, b, c, d}, renderThinWires, true);

				a.X += spacer;
				a.Y += spacer * 0.25f;
				b.X += spacer;
				b.Y += spacer * 0.25f;
				c.X += spacer;
				c.Y += spacer * 0.25f;
				d.X += spacer;
				d.Y += spacer * 0.25f;

				spacer++;
			}

			renderer.Render(rasterizer.RasterizeImage());

			Console.ReadLine();

			rasterizer.ClearImage();
			rasterizer.DrawAxes();
			rasterizer.DrawStringHorizontal(new Vector2(-50, -10), "WAVEFRONT OBJ RENDER");
			rasterizer.DrawWiredMesh(meshes, 1, 0, 0, renderThinWires, true);
			renderer.Render(rasterizer.RasterizeImage());

			Console.ReadLine();

			rasterizer.ClearImage();
			rasterizer.DrawAxes();
			rasterizer.DrawWiredMesh(meshes, 5, 0, 0, renderThinWires, true);
			renderer.Render(rasterizer.RasterizeImage());

			Console.ReadLine();

			rasterizer.ClearImage();
			rasterizer.DrawAxes();
			rasterizer.DrawWiredMesh(meshes, 10, 0, -10, renderThinWires, true);
			renderer.Render(rasterizer.RasterizeImage());

			Console.ReadLine();

			rasterizer.ClearImage();
			rasterizer.DrawAxes();
			rasterizer.DrawWiredMesh(meshes, 25, 0, -50, renderThinWires, true);
			renderer.Render(rasterizer.RasterizeImage());

			Console.ReadLine();

			rasterizer.ClearImage();
			rasterizer.DrawAxes();
			rasterizer.DrawWiredMesh(meshes, 100, 0, -50, renderThinWires, true);
			renderer.Render(rasterizer.RasterizeImage());

			Console.ReadLine();

			rasterizer.ClearImage();
			rasterizer.DrawAxes();
			rasterizer.DrawWiredMesh(meshes, 100, 0, -100, renderThinWires, true);
			renderer.Render(rasterizer.RasterizeImage());

			Console.ReadLine();

			rasterizer.ClearImage();
			rasterizer.DrawAxes();
			rasterizer.DrawWiredMesh(meshes, 100, 0, -150, renderThinWires, true);
			renderer.Render(rasterizer.RasterizeImage());

			Console.ReadLine();

			renderThinWires = !renderThinWires;

			goto loop;
		}
	}
}