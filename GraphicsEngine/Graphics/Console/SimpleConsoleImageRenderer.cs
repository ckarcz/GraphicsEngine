﻿#region Imports

using System;
using System.IO;

#endregion

namespace GraphicsEngine.Graphics.Console
{
	public class SimpleConsoleImageRenderer
	{
		private int lastTime;
		private int numRenderings;
		private readonly int width;
		private readonly int height;
		private readonly Stream stdOutputStream = System.Console.OpenStandardOutput();

		public SimpleConsoleImageRenderer(int width, int height)
		{
			this.width = width;
			this.height = height;

			System.Console.Title = "Graphics Engine Test";
			System.Console.CursorVisible = false;
			System.Console.BackgroundColor = ConsoleColor.Black;
			reTry:
			try
			{
				System.Console.SetWindowSize(width, height + 15);
				System.Console.SetBufferSize(width, height + 15);
			}
			catch (ArgumentOutOfRangeException)
			{
				System.Console.WriteLine("Decrease your font size and press enter");
				System.Console.ReadLine();
				goto reTry;
			}
			System.Console.Clear();
			System.Console.SetCursorPosition(0, height);
			System.Console.ForegroundColor = ConsoleColor.Magenta;
			System.Console.Write(new String('▄', width));
			System.Console.ForegroundColor = ConsoleColor.Cyan;
		}

		public void RenderImage(IConsoleGraphicsBuffer rasterizedImage)
		{
			var bufImg = new byte[rasterizedImage.Width * rasterizedImage.Height];
			for (var x = 0; x < rasterizedImage.Width; x++)
			{
				for (var y = 0; y < rasterizedImage.Height; y++)
				{
					bufImg[x + y * rasterizedImage.Width] = rasterizedImage.CharacterBuffer[x, y];
				}
			}
			var beginRender = Environment.TickCount;

			System.Console.SetCursorPosition(0, 0);
			stdOutputStream.Write(bufImg, 0, bufImg.Length);

			var endRender = Environment.TickCount - beginRender;

			//VSync(MAX_FPS, endRender, beginRender);

			if (numRenderings == 0)
			{
				lastTime = Environment.TickCount;
			}

			numRenderings++;
		}
	}
}