#region Imports

using System;
using System.IO;
using System.Linq;
using GraphicsEngine.Graphics;
using GraphicsEngine.Wavefront.Loaders;

#endregion

namespace GraphicsEngine
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			var width = 300;
			var height = 100;

			Console.Title = "Graphics Engine Test";
			Console.CursorVisible = false;
			Console.BackgroundColor = ConsoleColor.Black;
			reTry:
			try
			{
				Console.SetWindowSize(width, height + 15);
				Console.SetBufferSize(width, height + 15);
			}
			catch (ArgumentOutOfRangeException)
			{
				Console.WriteLine("Decrease your font size and press enter");
				Console.ReadLine();
				goto reTry;
			}
			Console.Clear(); //clear colors from user preset.
			Console.SetCursorPosition(0, height);
			Console.Write(new String('▄', width));
			Console.ForegroundColor = ConsoleColor.Cyan;

			var wavefrontObjLoaderFactory = new WavefrontObjLoaderFactory();
			var wavefrontObjLoader = wavefrontObjLoaderFactory.Create();

			var wavefrontObjFilePathString = "triangle.obj";
			var wavefrontObjFileStream = File.Open(wavefrontObjFilePathString, FileMode.Open, FileAccess.Read);
			var wavefrontObj = wavefrontObjLoader.LoadWavefrontObj(wavefrontObjFileStream);

			var wavefrontObjToMeshConverter = new WavefrontObjToMeshConverter();
			var meshes = wavefrontObjToMeshConverter.ConvertToMesh(wavefrontObj);

			var mesh = meshes.First();

			var rasterizer = new Rasterizer(300, 100);
			var rasterizedMesh = rasterizer.RasterizeVertices(mesh);

			var renderer = new Renderer();
			renderer.Render(rasterizedMesh);

			Console.ReadLine();
		}
	}
}