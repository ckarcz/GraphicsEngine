#region Imports

using System;
using System.IO;
using System.Text;
using GraphicsEngine.Graphics;
using GraphicsEngine.Graphics.Console;
using GraphicsEngine.Math;
using GraphicsEngine.Wavefront.Loaders;

#endregion

namespace GraphicsEngine
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			var consoleScreenWidth = 300;
			var consoleScreenHeight = 100;

			var renderer = new SimpleConsoleImageRenderer(consoleScreenWidth, consoleScreenHeight);
			var rasterizer = new SimpleRasterizer(consoleScreenWidth, consoleScreenHeight);

			var wavefrontObjLoaderFactory = new WavefrontObjLoaderFactory();
			var wavefrontObjLoader = wavefrontObjLoaderFactory.Create();
			var wavefrontObjFilePathString = "triangle.obj";
			var wavefrontObjFileStream = File.Open(wavefrontObjFilePathString, FileMode.Open, FileAccess.Read);
			var wavefrontObj = wavefrontObjLoader.LoadWavefrontObj(wavefrontObjFileStream);
			var wavefrontObjToMeshConverter = new WavefrontObjToMeshConverter();
			var meshes = wavefrontObjToMeshConverter.ConvertToMesh(wavefrontObj);

			Console.ReadLine();

			loop:
			rasterizer.ClearImage();
			rasterizer.DrawAxes();
			renderer.RenderImage(rasterizer.RasterizeImage());

			var linePoint1 = new Vector2(0, 0);
			var linePoint2 = new Vector2(50, 50);
			var rise = linePoint2.Y - linePoint1.Y;
			var run = linePoint2.X - linePoint1.X;
			var lineSlope = run == 0 ? 1 : rise / run;
			rasterizer.DrawStringHorizontal(new Vector2(-50, -10), string.Format("SLOPE: {0}", lineSlope));
			rasterizer.DrawLine(linePoint1, linePoint2);

			renderer.RenderImage(rasterizer.RasterizeImage());

			Console.ReadLine();

			rasterizer.ClearImage();
			rasterizer.DrawAxes();
			renderer.RenderImage(rasterizer.RasterizeImage());

			linePoint1 = new Vector2(0, 0);
			linePoint2 = new Vector2(75, 50);
			rise = linePoint2.Y - linePoint1.Y;
			run = linePoint2.X - linePoint1.X;
			lineSlope = run == 0 ? 1 : rise / run;
			rasterizer.DrawStringHorizontal(new Vector2(-50, -10), string.Format("SLOPE: {0}", lineSlope));
			rasterizer.DrawLine(linePoint1, linePoint2);

			renderer.RenderImage(rasterizer.RasterizeImage());

			Console.ReadLine();

			rasterizer.ClearImage();
			rasterizer.DrawAxes();
			renderer.RenderImage(rasterizer.RasterizeImage());

			linePoint1 = new Vector2(0, 0);
			linePoint2 = new Vector2(5, 50);
			rise = linePoint2.Y - linePoint1.Y;
			run = linePoint2.X - linePoint1.X;
			lineSlope = run == 0 ? 1 : rise / run;
			rasterizer.DrawStringHorizontal(new Vector2(-50, -10), string.Format("SLOPE: {0}", lineSlope));
			rasterizer.DrawLine(linePoint1, linePoint2);

			renderer.RenderImage(rasterizer.RasterizeImage());

			Console.ReadLine();

			rasterizer.ClearImage();
			rasterizer.DrawAxes();
			renderer.RenderImage(rasterizer.RasterizeImage());

			linePoint1 = new Vector2(0, 0);
			linePoint2 = new Vector2(-10, 50);
			rise = linePoint2.Y - linePoint1.Y;
			run = linePoint2.X - linePoint1.X;
			lineSlope = run == 0 ? 1 : rise / run;
			rasterizer.DrawStringHorizontal(new Vector2(-50, -10), string.Format("SLOPE: {0}", lineSlope));
			rasterizer.DrawLine(linePoint1, linePoint2);

			renderer.RenderImage(rasterizer.RasterizeImage());

			Console.ReadLine();

			rasterizer.ClearImage();
			rasterizer.DrawAxes();
			renderer.RenderImage(rasterizer.RasterizeImage());

			linePoint1 = new Vector2(0, 0);
			linePoint2 = new Vector2(10, -50);
			rise = linePoint2.Y - linePoint1.Y;
			run = linePoint2.X - linePoint1.X;
			lineSlope = run == 0 ? 1 : rise / run;
			rasterizer.DrawStringHorizontal(new Vector2(-50, -10), string.Format("SLOPE: {0}", lineSlope));
			rasterizer.DrawLine(linePoint1, linePoint2);

			renderer.RenderImage(rasterizer.RasterizeImage());

			Console.ReadLine();

			rasterizer.ClearImage();
			rasterizer.DrawAxes();
			renderer.RenderImage(rasterizer.RasterizeImage());

			var linePoint3 = new Vector3(0, 0, 1);
			var linePoint4 = new Vector3(50, 50, 2);
			rasterizer.DrawStringHorizontal(new Vector2(-50, -10), "3D->2D PROJECTED LINE");
			rasterizer.DrawLine(linePoint3, linePoint4);

			renderer.RenderImage(rasterizer.RasterizeImage());

			Console.ReadLine();

			rasterizer.ClearImage();
			rasterizer.DrawAxes();
			rasterizer.DrawStringHorizontal(new Vector2(-50, -10), "WAVEFRONT OBJ RENDER");
			rasterizer.DrawWiredMesh(meshes);
			renderer.RenderImage(rasterizer.RasterizeImage());

			Console.ReadLine();

			rasterizer.ClearImage();
			rasterizer.DrawAxes();
			rasterizer.DrawWiredMesh(meshes, true);
			renderer.RenderImage(rasterizer.RasterizeImage());

			Console.ReadLine();

			rasterizer.ClearImage();
			rasterizer.DrawAxes();

			var a = new Vector2(-140, -45);
			var b = new Vector2(-100, -45);
			var c = new Vector2(-85, -25);
			var d = new Vector2(-125, -25);

			var spacer = 1;
			for (int i = 0; i < 50; i++)
			{
				rasterizer.DrawWiredPolygon(new [] {a, b, c, d}, true, true);

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

			renderer.RenderImage(rasterizer.RasterizeImage());

			Console.ReadLine();

			goto loop;
		}
	}
}