#region Imports

using System;
using GraphicsEngine.Graphics;
using GraphicsEngine.Graphics.Console;
using GraphicsEngine.Math;

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

			Console.ReadLine();

			rasterizer.DrawLine(new Vector2(0, 0), new Vector2(0, consoleScreenWidth - 1), false);
			renderer.RenderImage(rasterizer.RasterizeImage());

			Console.ReadLine();

			rasterizer.DrawLine(new Vector2(0, 0), new Vector2(consoleScreenWidth - 1, 0), false);
			renderer.RenderImage(rasterizer.RasterizeImage());

			Console.ReadLine();

			rasterizer.DrawLine(new Vector2(consoleScreenWidth - 1, 0), new Vector2(consoleScreenWidth - 1, consoleScreenHeight - 1), false);
			renderer.RenderImage(rasterizer.RasterizeImage());

			Console.ReadLine();

			rasterizer.DrawLine(new Vector2(0, consoleScreenHeight - 1), new Vector2(consoleScreenWidth - 1, consoleScreenHeight - 1), false);
			renderer.RenderImage(rasterizer.RasterizeImage());

			Console.ReadLine();

			rasterizer.DrawLine(new Vector2(0, 0), new Vector2(consoleScreenWidth - 1, consoleScreenHeight - 1), false);
			renderer.RenderImage(rasterizer.RasterizeImage());

			Console.ReadLine();

			rasterizer.DrawLine(new Vector2(0, consoleScreenHeight - 1), new Vector2(consoleScreenWidth - 1, 0), false);
			renderer.RenderImage(rasterizer.RasterizeImage());

			Console.ReadLine();

			rasterizer.DrawLine(new Vector2(0, 0), new Vector2(consoleScreenWidth / 2 - 1, consoleScreenHeight - 1), false);
			renderer.RenderImage(rasterizer.RasterizeImage());

			Console.ReadLine();

			rasterizer.DrawLine(new Vector2(0, consoleScreenHeight - 1), new Vector2(consoleScreenWidth / 2 - 1, 0), false);
			renderer.RenderImage(rasterizer.RasterizeImage());

			Console.ReadLine();

			rasterizer.DrawLine(new Vector2(0, 0), new Vector2(0, consoleScreenWidth - 1), true);
			renderer.RenderImage(rasterizer.RasterizeImage());

			Console.ReadLine();

			rasterizer.DrawLine(new Vector2(0, 0), new Vector2(consoleScreenWidth - 1, 0), true);
			renderer.RenderImage(rasterizer.RasterizeImage());

			Console.ReadLine();

			rasterizer.DrawLine(new Vector2(consoleScreenWidth - 1, 0), new Vector2(consoleScreenWidth - 1, consoleScreenHeight - 1), true);
			renderer.RenderImage(rasterizer.RasterizeImage());

			Console.ReadLine();

			rasterizer.DrawLine(new Vector2(0, consoleScreenHeight - 1), new Vector2(consoleScreenWidth - 1, consoleScreenHeight - 1), true);
			renderer.RenderImage(rasterizer.RasterizeImage());

			Console.ReadLine();

			rasterizer.DrawLine(new Vector2(0, 0), new Vector2(consoleScreenWidth - 1, consoleScreenHeight - 1), true);
			renderer.RenderImage(rasterizer.RasterizeImage());

			Console.ReadLine();

			rasterizer.DrawLine(new Vector2(0, consoleScreenHeight - 1), new Vector2(consoleScreenWidth - 1, 0), true);
			renderer.RenderImage(rasterizer.RasterizeImage());

			Console.ReadLine();

			rasterizer.DrawLine(new Vector2(0, 0), new Vector2(consoleScreenWidth / 2 - 1, consoleScreenHeight - 1), true);
			renderer.RenderImage(rasterizer.RasterizeImage());

			Console.ReadLine();

			rasterizer.DrawLine(new Vector2(0, consoleScreenHeight - 1), new Vector2(consoleScreenWidth / 2 - 1, 0), true);
			renderer.RenderImage(rasterizer.RasterizeImage());

			// wavefront obj mesh test
			//var wavefrontObjLoaderFactory = new WavefrontObjLoaderFactory();
			//var wavefrontObjLoader = wavefrontObjLoaderFactory.Create();
			//var wavefrontObjFilePathString = "triangle.obj";
			//var wavefrontObjFileStream = File.Open(wavefrontObjFilePathString, FileMode.Open, FileAccess.Read);
			//var wavefrontObj = wavefrontObjLoader.LoadWavefrontObj(wavefrontObjFileStream);
			//var wavefrontObjToMeshConverter = new WavefrontObjToMeshConverter();
			//var meshes = wavefrontObjToMeshConverter.ConvertToMesh(wavefrontObj);

			Console.ReadLine();
		}
	}
}