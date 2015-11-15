#region Imports

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Input;
using GraphicsEngine.Engine;
using GraphicsEngine.Graphics;
using GraphicsEngine.Math;
using GraphicsEngine.Wavefront.Loaders;
using GraphicsEngine.Win32;

#endregion

namespace GraphicsEngine.Scenes
{
	public class MeshTestScene
		: IScene
	{
		private string currentWavefrontObjectFilePath;
		private IEnumerable<IMesh> meshes;
		private float scaleFactor = 0.5f;
		private readonly InputStateService inputStateService;
		private readonly IRasterizer rasterizer;
		private readonly Transformation transformation;
		private readonly string[] wavefrontObjectFilePaths = new[] {"Models\\triangle.obj", "Models\\cube.obj", "Models\\sphere.obj", "Models\\conf.obj", "Models\\gourd.obj", "Models\\link.obj", "Models\\monkey.obj", "Models\\bunny.obj", "Models\\f1.obj", "Models\\woman1.obj" };

		public MeshTestScene(int width, int height)
		{
			Width = width;
			Height = height;

			rasterizer = new Rasterizer(Width, Height);
			inputStateService = new InputStateService();
			transformation = new Transformation();

			currentWavefrontObjectFilePath = "Models\\woman1.obj";

			InitScene(currentWavefrontObjectFilePath);
		}

		public int Width { get; private set; }
		public int Height { get; private set; }

		public void Update()
		{
			UpdateMeshes();
			UpdateTransformation();
		}

		public IFrameBuffer Rasterize()
		{
			rasterizer.ClearImage((byte)' ', (byte)Kernel32Console.Colors.BACKGROUND_BLACK | Kernel32Console.Colors.FOREGROUND_GREY | Kernel32Console.Colors.FOREGROUND_INTENSITY);

			//rasterizer.DrawMeshFilled(transformation, meshes);//, Kernel32Console.Colors.FOREGROUND_CYAN, Rasterizer.ShadePixelChar1);
			//rasterizer.DrawMeshVertices(transformation, meshes, Kernel32Console.Colors.FOREGROUND_CYAN, (byte)'X');
			rasterizer.DrawMeshWired(transformation, meshes, Kernel32Console.Colors.FOREGROUND_CYAN);

			rasterizer.DrawMeshCenters(transformation, meshes, Kernel32Console.Colors.FOREGROUND_RED);
			//rasterizer.DrawMeshBoundingBox(transformation, meshes, Kernel32Console.Colors.FOREGROUND_MAGENTA);

			rasterizer.DrawAxes(Transformation.None, Kernel32Console.Colors.FOREGROUND_YELLOW);

			rasterizer.DrawStringHorizontal(Transformation.None, new Vector2(-Width / 2 + 1, Height / 2 - 2), string.Format("MODEL: '{0}'", currentWavefrontObjectFilePath));
			rasterizer.DrawStringHorizontal(Transformation.None, new Vector2(-Width / 2 + 1, Height / 2 - 3), string.Format("# POLYGONS: {0}", meshes.Sum(mesh => mesh.Faces.Count())));

			rasterizer.DrawStringHorizontal(Transformation.None, new Vector2(-Width / 2 + 1, 10), string.Format("TRANSLATION: {0}", transformation.Translation));
			rasterizer.DrawStringHorizontal(Transformation.None, new Vector2(-Width / 2 + 1, 9), string.Format("SCALE: {0}", transformation.Scale));
			rasterizer.DrawStringHorizontal(Transformation.None, new Vector2(-Width / 2 + 1, 8), string.Format("ROTATION: {0}", transformation.Rotation));

			rasterizer.DrawStringHorizontal(Transformation.None, new Vector2(-Width / 2 + 1, 6), string.Format("MODEL CENTER: {0}", transformation.Transform(meshes.First().Centers.Value)));

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
			var wavefrontObjToMeshConverter = new WavefrontObjConverter();
			meshes = wavefrontObjToMeshConverter.ConvertToMesh(wavefrontObj);
			meshes = MeshCenterer.Instance.Transform(meshes);
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
			else if (inputStateService.IsKeyDown(Key.D0))
			{
				newModelToLoad = wavefrontObjectFilePaths[9];
			}

			if (newModelToLoad != string.Empty && currentWavefrontObjectFilePath != newModelToLoad)
			{
				InitScene(newModelToLoad);
			}
		}

		private void UpdateTransformation()
		{
			var translateX = transformation.Translation.X;
			var translateY = transformation.Translation.Y;
			var translateZ = transformation.Translation.Z;
			var scaleX = transformation.Scale.X;
			var scaleY = transformation.Scale.Y;
			var scaleZ = transformation.Scale.Z;
			var rotateX = transformation.Rotation.X;
			var rotateY = transformation.Rotation.Y;
			var rotateZ = transformation.Rotation.Z;

			if (inputStateService.IsKeyDown(Key.Right))
			{
				translateX += 1f * scaleFactor;
			}
			else if (inputStateService.IsKeyDown(Key.Left))
			{
				translateX += -1f * scaleFactor;
			}

			if (inputStateService.IsKeyDown(Key.Up))
			{
				translateY += 1f * scaleFactor;
			}
			else if (inputStateService.IsKeyDown(Key.Down))
			{
				translateY += -1f * scaleFactor;
			}

			if (inputStateService.IsKeyDown(Key.PageUp))
			{
				translateZ += 1f * scaleFactor;
			}
			else if (inputStateService.IsKeyDown(Key.PageDown))
			{
				translateZ += -1f * scaleFactor;
			}

			if (inputStateService.IsKeyDown(Key.OemComma))
			{
				rotateX -= 0.01f * scaleFactor;
			}
			else if (inputStateService.IsKeyDown(Key.OemPeriod))
			{
				rotateX += 0.01f * scaleFactor;
			}

			if (inputStateService.IsKeyDown(Key.K))
			{
				rotateY -= 0.01f * scaleFactor;
			}
			else if (inputStateService.IsKeyDown(Key.L))
			{
				rotateY += 0.01f * scaleFactor;
			}

			if (inputStateService.IsKeyDown(Key.I))
			{
				rotateZ -= 0.01f * scaleFactor;
			}
			else if (inputStateService.IsKeyDown(Key.O))
			{
				rotateZ += 0.01f * scaleFactor;
			}

			if (inputStateService.IsKeyDown(Key.OemCloseBrackets))
			{
				scaleX += 0.1f * scaleFactor;
				scaleY += 0.1f * scaleFactor;
				scaleZ += 0.1f * scaleFactor;
			}
			else if (inputStateService.IsKeyDown(Key.OemOpenBrackets))
			{
				scaleX += -0.1f * scaleFactor;
				scaleY += -0.1f * scaleFactor;
				scaleZ += -0.1f * scaleFactor;
			}

			if (inputStateService.IsKeyToggled(Key.CapsLock))
			{
				scaleFactor = 3;
			}
			else
			{
				scaleFactor = 1;
			}

			transformation.Translation = new Vector3(translateX, translateY, translateZ);
			transformation.Scale = new Vector3(scaleX, scaleY, scaleZ);
			transformation.Rotation = new Vector3(rotateX, rotateY, rotateZ);
		}
	}

	public class RenderableObject
	{
		
	}
}