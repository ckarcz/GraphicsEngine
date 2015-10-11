#region Imports

using System;
using System.IO;
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
			var consoleScreenWidth = 200;
			var consoleScreenHeight = 75;

			var renderer = new SimpleConsoleImageRenderer(consoleScreenWidth, consoleScreenHeight);
			var rasterizer = new SimpleRasterizer(consoleScreenWidth, consoleScreenHeight);

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
			linePoint2 = new Vector2(10, 50);
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

			// wavefront obj mesh test
			var wavefrontObjLoaderFactory = new WavefrontObjLoaderFactory();
			var wavefrontObjLoader = wavefrontObjLoaderFactory.Create();
			var wavefrontObjFilePathString = "triangle.obj";
			var wavefrontObjFileStream = File.Open(wavefrontObjFilePathString, FileMode.Open, FileAccess.Read);
			var wavefrontObj = wavefrontObjLoader.LoadWavefrontObj(wavefrontObjFileStream);
			var wavefrontObjToMeshConverter = new WavefrontObjToMeshConverter();
			var meshes = wavefrontObjToMeshConverter.ConvertToMesh(wavefrontObj);

			rasterizer.ClearImage();
			rasterizer.DrawAxes();
			rasterizer.DrawStringHorizontal(new Vector2(-50, -10), "WAVEFRONT OBJ RENDER");
			rasterizer.DrawWired(wavefrontObj);
			renderer.RenderImage(rasterizer.RasterizeImage());

			Console.ReadLine();

			rasterizer.ClearImage();
			rasterizer.DrawAxes();
			rasterizer.DrawWired(wavefrontObj, true);
			renderer.RenderImage(rasterizer.RasterizeImage());

			Console.ReadLine();
		}
	}
}