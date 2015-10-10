#region Imports

using System;
using System.IO;
using System.Linq;
using GraphicsEngine.Graphics;
using GraphicsEngine.Graphics.Console;
using GraphicsEngine.Wavefront.Loaders;

#endregion

namespace GraphicsEngine
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			var consoleScreenConfig = new ConsoleScreenConfig(300, 100);

			var wavefrontObjLoaderFactory = new WavefrontObjLoaderFactory();
			var wavefrontObjLoader = wavefrontObjLoaderFactory.Create();

			var wavefrontObjFilePathString = "triangle.obj";
			var wavefrontObjFileStream = File.Open(wavefrontObjFilePathString, FileMode.Open, FileAccess.Read);
			var wavefrontObj = wavefrontObjLoader.LoadWavefrontObj(wavefrontObjFileStream);

			var wavefrontObjToMeshConverter = new WavefrontObjToMeshConverter();
			var meshes = wavefrontObjToMeshConverter.ConvertToMesh(wavefrontObj);

			var mesh = meshes.First();

			var rasterizer = new MeshRasterizer(consoleScreenConfig);
			var rasterizedImage = rasterizer.RasterizeAsVertices(mesh);

			var consoleImageRenderer = new MonochromeConsoleImageRenderer(consoleScreenConfig);
			consoleImageRenderer.RenderImage(rasterizedImage);

			Console.ReadLine();
		}
	}
}