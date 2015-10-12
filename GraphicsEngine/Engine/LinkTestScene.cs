#region Imports

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Input;
using GraphicsEngine.Graphics;
using GraphicsEngine.Graphics.Console;
using GraphicsEngine.Math;
using GraphicsEngine.Wavefront.Loaders;

#endregion

namespace GraphicsEngine.Engine
{
	public class InputStateService
	{
		public InputStateService()
		{

		}

		public bool IsKeyDown(Key thisKey)
		{
			return Keyboard.IsKeyDown(thisKey);
		}
	}

	public class LinkTestScene
		: IScene
	{
		private IEnumerable<IMesh> meshes;
		private readonly Rasterizer rasterizer;
		private readonly IConsoleGraphicsRenderer renderer;
		private readonly InputStateService inputStateService;
		private readonly Transformation transformation;

		public LinkTestScene(IConsoleGraphicsRenderer renderer)
		{
			this.renderer = renderer;
			rasterizer = new Rasterizer(renderer.Width, renderer.Height);
			inputStateService = new InputStateService();
			transformation = new Transformation();
			
			InitScene();
		}

		public void Update()
		{
			UpdateTransformation();
			rasterizer.ClearImage();
			rasterizer.DrawAxes(Transformation.None);
			rasterizer.DrawWiredMesh(transformation, meshes, true);
		}

		public IConsoleGraphicsFrame Render()
		{
			var rasterizedFrame = rasterizer.Rasterize();

			renderer.Render(rasterizedFrame);

			return rasterizedFrame;
		}

		private void InitScene()
		{
			var wavefrontObjLoaderFactory = new WavefrontObjLoaderFactory();
			var wavefrontObjLoader = wavefrontObjLoaderFactory.Create(new MaterialNullStreamProvider());
			var wavefrontObjFilePathString = "link.obj";
			var wavefrontObjFileStream = File.Open(wavefrontObjFilePathString, FileMode.Open, FileAccess.Read);
			var wavefrontObj = wavefrontObjLoader.LoadWavefrontObj(wavefrontObjFileStream);
			var wavefrontObjToMeshConverter = new WavefrontObjToMeshConverter();
			meshes = wavefrontObjToMeshConverter.ConvertToMesh(wavefrontObj);
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
				translateX += 1;
			}
			else if (inputStateService.IsKeyDown(Key.Left))
			{
				translateX += -1;
			}

			if (inputStateService.IsKeyDown(Key.Up))
			{
				translateY += 1;
			}
			else if (inputStateService.IsKeyDown(Key.Down))
			{
				translateY += -1;
			}

			if (inputStateService.IsKeyDown(Key.PageUp))
			{
				scaleX += 0.1f;
				scaleY += 0.1f;
			}
			else if (inputStateService.IsKeyDown(Key.PageDown))
			{
				scaleX += -0.1f;
				scaleY += -0.1f;
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

	public interface ITransformation
	{
		Vector3 Scale { get; }
		Vector3 Translation { get; }

		void Transform(ref Vector2 point);

		void Transform(ref Vector3 point);
	}

	public class Transformation
		: ITransformation
	{
		public Transformation()
		{
			Scale = Vector3.OneVector;
			Translation = Vector3.ZeroVector;
		}

		public Vector3 Scale { get; set; }

		public Vector3 Translation { get; set; }

		public static ITransformation None { get; } = new Transformation();

		public void Transform(ref Vector2 point)
		{
			Transform(this, ref point);
		}

		public void Transform(ref Vector3 point)
		{
			Transform(this, ref point);
		}

		public static void Transform(ITransformation transformation, ref Vector2 point)
		{
			point.X = point.X * transformation.Scale.X + transformation.Translation.X;
			point.Y = point.Y * transformation.Scale.Y + transformation.Translation.Y;
		}

		public static void Transform(ITransformation transformation, ref Vector3 point)
		{
			point.X = point.X * transformation.Scale.X + transformation.Translation.X;
			point.Y = point.Y * transformation.Scale.Y + transformation.Translation.Y;
			point.Z = point.Z * transformation.Scale.Z + transformation.Translation.Z;
		}
	}
}