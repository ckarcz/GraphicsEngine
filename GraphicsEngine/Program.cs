#region Imports

using System;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
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

			var wavefrontObjLoaderFactory = new WavefrontObjLoaderFactory();
			var wavefrontObjLoader = wavefrontObjLoaderFactory.Create();

			var wavefrontObjFilePathString = "triangle.obj";
			var wavefrontObjFileStream = File.Open(wavefrontObjFilePathString, FileMode.Open, FileAccess.Read);
			var wavefrontObj = wavefrontObjLoader.LoadWavefrontObj(wavefrontObjFileStream);

			var wavefrontObjToMeshConverter = new WavefrontObjToMeshConverter();
			var meshes = wavefrontObjToMeshConverter.ConvertToMesh(wavefrontObj);

			var mesh = meshes.First();

			var simpleRasterizer = new SimpleRasterizer(consoleScreenWidth, consoleScreenHeight);
			var rasterizedPoints = simpleRasterizer.RasterizePoints(new[] {new Vector2(0, 0), new Vector2(60, 50) , new Vector2(70, 50) , new Vector2(80, 50) });

			var meshRasterizer = new MeshRasterizer(consoleScreenWidth, consoleScreenHeight);
			var meshRasterizedAsVertices = meshRasterizer.RasterizeAsVertices(mesh);

			var consoleImageRenderer = new SimpleConsoleImageRenderer(consoleScreenWidth, consoleScreenHeight);
			consoleImageRenderer.RenderImage(rasterizedPoints);

			Console.ReadLine();
		}
	}
}