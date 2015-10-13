#region Imports

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Input;
using GraphicsEngine.Graphics;
using GraphicsEngine.Graphics.Console;
using GraphicsEngine.Math;
using GraphicsEngine.Wavefront.Loaders;

#endregion

namespace GraphicsEngine.Engine
{
	public class TestScene
		: IScene
	{
		private string currentWavefrontObjectFilePath;
		private IEnumerable<IMesh> meshes;
		private float scaleFactor = 0.5f;
		private readonly InputStateService inputStateService;
		private readonly Rasterizer rasterizer;
		private readonly Transformation transformation;
		private readonly string[] wavefrontObjectFilePaths = new[] {"Models\\triangle.obj", "Models\\cube.obj", "Models\\sphere.obj", "Models\\conf.obj", "Models\\gourd.obj", "Models\\link.obj", "Models\\monkey.obj", "Models\\bunny.obj", "Models\\f1.obj" };

		public TestScene(int width, int height)
		{
			Width = width;
			Height = height;

			rasterizer = new Rasterizer(Width, Height);
			inputStateService = new InputStateService();
			transformation = new Transformation();

			currentWavefrontObjectFilePath = "Models\\link.obj";

			InitScene(currentWavefrontObjectFilePath);

			transformation.Scale *= 50;
		}

		public int Width { get; private set; }
		public int Height { get; private set; }

		public void Update()
		{
			UpdateMeshes();
			UpdateTransformation();
		}

		public void Draw()
		{
			rasterizer.ClearImage();

			rasterizer.DrawAxes(Transformation.None);

			rasterizer.DrawWiredMesh(transformation, meshes, true);

			rasterizer.DrawStringHorizontal(Transformation.None, new Vector2(-Width / 2 + 1, Height / 2 - 2), string.Format("MODEL: '{0}'", currentWavefrontObjectFilePath));
			rasterizer.DrawStringHorizontal(Transformation.None, new Vector2(-Width / 2 + 1, Height / 2 - 3), string.Format("# POLYGONS: {0}", meshes.Sum(mesh => mesh.Faces.Count())));
		}

		public ConsoleGraphicsFrame Rasterize()
		{
			var rasterizedFrame = rasterizer.Rasterize();
			return rasterizedFrame;
		}

		private void InitScene(string wavefrontObjFilePath)
		{
			var wavefrontObjLoaderFactory = new WavefrontObjLoaderFactory();
			var wavefrontObjLoader = wavefrontObjLoaderFactory.Create(new MaterialNullStreamProvider());
			var wavefrontObjFilePathString = wavefrontObjFilePath;
			var wavefrontObjFileStream = File.Open(wavefrontObjFilePathString, FileMode.Open, FileAccess.Read);
			var wavefrontObj = wavefrontObjLoader.LoadWavefrontObj(wavefrontObjFileStream);
			wavefrontObjFileStream.Close();
			var wavefrontObjToMeshConverter = new WavefrontObjToMeshConverter();
			meshes = wavefrontObjToMeshConverter.ConvertToMesh(wavefrontObj);
			currentWavefrontObjectFilePath = wavefrontObjFilePath;
			transformation.Reset();
		}

		private void UpdateMeshes()
		{
			string newModelToLoad = string.Empty;
			if (inputStateService.IsKeyDown(Key.D1))
			{
				newModelToLoad = wavefrontObjectFilePaths[0];
			}
			else if (inputStateService.IsKeyDown(Key.D2))
			{
				newModelToLoad = wavefrontObjectFilePaths[1];
			}
			else if (inputStateService.IsKeyDown(Key.D3))
			{
				newModelToLoad = wavefrontObjectFilePaths[2];
			}
			else if (inputStateService.IsKeyDown(Key.D4))
			{
				newModelToLoad = wavefrontObjectFilePaths[3];
			}
			else if (inputStateService.IsKeyDown(Key.D5))
			{
				newModelToLoad = wavefrontObjectFilePaths[4];
			}
			else if (inputStateService.IsKeyDown(Key.D6))
			{
				newModelToLoad = wavefrontObjectFilePaths[5];
			}
			else if (inputStateService.IsKeyDown(Key.D7))
			{
				newModelToLoad = wavefrontObjectFilePaths[6];
			}
			else if (inputStateService.IsKeyDown(Key.D8))
			{
				newModelToLoad = wavefrontObjectFilePaths[7];
			}
			else if (inputStateService.IsKeyDown(Key.D9))
			{
				newModelToLoad = wavefrontObjectFilePaths[8];
			}

			if (newModelToLoad != string.Empty && currentWavefrontObjectFilePath != newModelToLoad)
			{
				InitScene(newModelToLoad);
			}
		}

		private void UpdateTransformation()
		{
			float translateX = transformation.Translation.X;
			float translateY = transformation.Translation.Y;
			float translateZ = transformation.Translation.Z;
			float scaleX = transformation.Scale.X;
			float scaleY = transformation.Scale.Y;
			float scaleZ = transformation.Scale.Z;

			if (inputStateService.IsKeyDown(Key.Right))
			{
				translateX += 2;
			}
			else if (inputStateService.IsKeyDown(Key.Left))
			{
				translateX += -2;
			}

			if (inputStateService.IsKeyDown(Key.Up))
			{
				translateY += 2;
			}
			else if (inputStateService.IsKeyDown(Key.Down))
			{
				translateY += -2;
			}

			if (inputStateService.IsKeyDown(Key.OemComma))
			{
				translateY += 2;
			}
			else if (inputStateService.IsKeyDown(Key.OemPeriod))
			{
				translateY += -2;
			}

			if (inputStateService.IsKeyDown(Key.OemCloseBrackets))
			{
				scaleX += scaleFactor;
				scaleY += scaleFactor;
			}
			else if (inputStateService.IsKeyDown(Key.OemOpenBrackets))
			{
				scaleX += -scaleFactor;
				scaleY += -scaleFactor;
			}

			if (inputStateService.IsKeyToggled(Key.CapsLock))
			{
				scaleFactor = 2;
			}
			else
			{
				scaleFactor = 0.5f;
			}

			transformation.Translation = new Vector3(translateX, translateY, translateZ);
			transformation.Scale = new Vector3(scaleX, scaleY, scaleZ);
		}

		private void OldTests()
		{
			//Console.ReadLine();

			//bool renderThinWires = true;

			//loop:
			//rasterizer.ClearImage();
			//rasterizer.DrawAxes();

			//var linePoint1 = new Vector2(0, 0);
			//var linePoint2 = new Vector2(50, 50);
			//var rise = linePoint2.Y - linePoint1.Y;
			//var run = linePoint2.X - linePoint1.X;
			//var lineSlope = run == 0 ? 1 : rise / run;
			//rasterizer.DrawStringHorizontal(new Vector2(-50, -10), string.Format("SLOPE: {0}", lineSlope));
			//rasterizer.DrawLine(linePoint1, linePoint2, renderThinWires);

			//Console.ReadLine();

			//rasterizer.ClearImage();
			//rasterizer.DrawAxes();

			//linePoint1 = new Vector2(0, 0);
			//linePoint2 = new Vector2(75, 50);
			//rise = linePoint2.Y - linePoint1.Y;
			//run = linePoint2.X - linePoint1.X;
			//lineSlope = run == 0 ? 1 : rise / run;
			//rasterizer.DrawStringHorizontal(new Vector2(-50, -10), string.Format("SLOPE: {0}", lineSlope));
			//rasterizer.DrawLine(linePoint1, linePoint2, renderThinWires);

			//Console.ReadLine();

			//rasterizer.ClearImage();
			//rasterizer.DrawAxes();

			//linePoint1 = new Vector2(0, 0);
			//linePoint2 = new Vector2(5, 50);
			//rise = linePoint2.Y - linePoint1.Y;
			//run = linePoint2.X - linePoint1.X;
			//lineSlope = run == 0 ? 1 : rise / run;
			//rasterizer.DrawStringHorizontal(new Vector2(-50, -10), string.Format("SLOPE: {0}", lineSlope));
			//rasterizer.DrawLine(linePoint1, linePoint2, renderThinWires);

			//Console.ReadLine();

			//rasterizer.ClearImage();
			//rasterizer.DrawAxes();

			//linePoint1 = new Vector2(0, 0);
			//linePoint2 = new Vector2(-10, 50);
			//rise = linePoint2.Y - linePoint1.Y;
			//run = linePoint2.X - linePoint1.X;
			//lineSlope = run == 0 ? 1 : rise / run;
			//rasterizer.DrawStringHorizontal(new Vector2(-50, -10), string.Format("SLOPE: {0}", lineSlope));
			//rasterizer.DrawLine(linePoint1, linePoint2, renderThinWires);

			//Console.ReadLine();

			//rasterizer.ClearImage();
			//rasterizer.DrawAxes();

			//linePoint1 = new Vector2(0, 0);
			//linePoint2 = new Vector2(10, -50);
			//rise = linePoint2.Y - linePoint1.Y;
			//run = linePoint2.X - linePoint1.X;
			//lineSlope = run == 0 ? 1 : rise / run;
			//rasterizer.DrawStringHorizontal(new Vector2(-50, -10), string.Format("SLOPE: {0}", lineSlope));
			//rasterizer.DrawLine(linePoint1, linePoint2, renderThinWires);

			//Console.ReadLine();

			//rasterizer.ClearImage();
			//rasterizer.DrawAxes();

			//var linePoint3 = new Vector3(0, 0, 1);
			//var linePoint4 = new Vector3(50, 50, 2);
			//rasterizer.DrawStringHorizontal(new Vector2(-50, -10), "3D->2D PROJECTED LINE");
			//rasterizer.DrawLine(linePoint3, linePoint4, renderThinWires);

			//Console.ReadLine();

			//rasterizer.ClearImage();
			//rasterizer.DrawAxes();

			//rasterizer.DrawWiredPolygon(new[] {new Vector2(-100, -45), new Vector2(-45, -45), new Vector2(-20, -5), new Vector2(15, -27), new Vector2(36, -2), new Vector2(45, 15), new Vector2(25, 45), new Vector2(5, 15), new Vector2(-35, 10)}, renderThinWires, true);

			//Console.ReadLine();

			//rasterizer.ClearImage();
			//rasterizer.DrawAxes();

			//var a = new Vector2(-140, -45);
			//var b = new Vector2(-100, -45);
			//var c = new Vector2(-85, -25);
			//var d = new Vector2(-125, -25);

			//var spacer = 1;
			//for (var i = 0; i < 50; i++)
			//{
			//	rasterizer.DrawWiredPolygon(new[] {a, b, c, d}, renderThinWires, true);

			//	a.X += spacer;
			//	a.Y += spacer * 0.25f;
			//	b.X += spacer;
			//	b.Y += spacer * 0.25f;
			//	c.X += spacer;
			//	c.Y += spacer * 0.25f;
			//	d.X += spacer;
			//	d.Y += spacer * 0.25f;

			//	spacer++;
			//}

			//Console.ReadLine();

			//rasterizer.ClearImage();
			//rasterizer.DrawAxes();
			//rasterizer.DrawStringHorizontal(new Vector2(-50, -10), "WAVEFRONT OBJ RENDER");
			//rasterizer.DrawWiredMesh(meshes, 1, 0, 0, renderThinWires, true);

			//Console.ReadLine();

			//rasterizer.ClearImage();
			//rasterizer.DrawAxes();
			//rasterizer.DrawWiredMesh(meshes, 5, 0, 0, renderThinWires, true);

			//Console.ReadLine();

			//rasterizer.ClearImage();
			//rasterizer.DrawAxes();
			//rasterizer.DrawWiredMesh(meshes, 10, 0, -10, renderThinWires, true);

			//Console.ReadLine();

			//rasterizer.ClearImage();
			//rasterizer.DrawAxes();
			//rasterizer.DrawWiredMesh(meshes, 25, 0, -50, renderThinWires, true);

			//Console.ReadLine();

			//rasterizer.ClearImage();
			//rasterizer.DrawAxes();
			//rasterizer.DrawWiredMesh(meshes, 100, 0, -50, renderThinWires, true);

			//Console.ReadLine();

			//rasterizer.ClearImage();
			//rasterizer.DrawAxes();
			//rasterizer.DrawWiredMesh(meshes, 100, 0, -100, renderThinWires, true);

			//Console.ReadLine();

			//rasterizer.ClearImage();
			//rasterizer.DrawAxes();
			//rasterizer.DrawWiredMesh(meshes, 100, 0, -150, renderThinWires, true);

			//Console.ReadLine();

			//rasterizer.ClearImage();
			//rasterizer.DrawAxes();
			//rasterizer.DrawWiredMesh(meshes, 100, 0, -300, renderThinWires, true);

			//Console.ReadLine();

			//rasterizer.ClearImage();
			//rasterizer.DrawAxes();
			//rasterizer.DrawWiredMesh(meshes, 100, 0, -400, renderThinWires, true);

			//Console.ReadLine();

			//renderThinWires = !renderThinWires;

			//goto loop;
		}
	}
}