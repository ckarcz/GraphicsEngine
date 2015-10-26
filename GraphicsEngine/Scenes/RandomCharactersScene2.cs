#region Imports

using System;
using System.Threading;
using GraphicsEngine.Graphics;
using GraphicsEngine.Graphics.Console;
using GraphicsEngine.Math;
using GraphicsEngine.Win32;

#endregion

namespace GraphicsEngine.Engine
{
	public class RandomCharactersScene2
		: IScene
	{
		private static readonly short[] colors = new short[] {Kernel32Console.Colors.FOREGROUND_BLUE, Kernel32Console.Colors.FOREGROUND_CYAN, Kernel32Console.Colors.FOREGROUND_GREEN, Kernel32Console.Colors.FOREGROUND_MAGENTA, Kernel32Console.Colors.FOREGROUND_RED, Kernel32Console.Colors.FOREGROUND_YELLOW, Kernel32Console.Colors.FOREGROUND_GREY};
		private readonly Random random = new Random(1000);
		private readonly Rasterizer rasterizer;

		public RandomCharactersScene2(int width, int height)
		{
			Width = width;
			Height = height;

			rasterizer = new Rasterizer(Width, Height);
		}

		public int Width { get; }
		public int Height { get; }

		public void Update()
		{
		}

		public void Draw()
		{
			Thread.Sleep(50);

			rasterizer.ClearImage((byte) ' ', (byte) Kernel32Console.Colors.BACKGROUND_BLACK | Kernel32Console.Colors.FOREGROUND_GREY | Kernel32Console.Colors.FOREGROUND_INTENSITY);

			// TODO
		}

		public ConsoleGraphicsFrame Rasterize()
		{
			var rasterizedFrame = rasterizer.Rasterize();
			return rasterizedFrame;
		}

		private void InitScene(string wavefrontObjFilePath)
		{
		}
	}
}