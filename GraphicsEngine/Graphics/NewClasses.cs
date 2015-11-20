#region Imports

using System;
using System.Collections.Generic;
using GraphicsEngine.Math;

#endregion

namespace GraphicsEngine.Graphics
{
	public interface IDrawDevice
	{
		void Draw(IRenderable renderable);
	}

	public class ConsoleDrawDevice
		: IDrawDevice
	{
		private readonly IRasterizer _rasterizer;
		private readonly IConsoleWindow _consoleWindow;

		public ConsoleDrawDevice(IRasterizer rasterizer, IConsoleWindow consoleWindow)
		{
			_rasterizer = rasterizer;
			_consoleWindow = consoleWindow;
		}

		public void Draw(IRenderable renderable)
		{
			ClearConsoleWindow();
			RasterizeToConsoleWindow(renderable);
			UpdateConsoleWindow();
		}

		private void RasterizeToConsoleWindow(IRenderable renderable)
		{
			if (renderable != null)
			{
				var image = _rasterizer.Rasterize(renderable);

				var imageMinX = image.LocationX;
				var imageMinY = image.LocationY;
				var imageMaxX = image.LocationX + image.Width;
				var imageMaxY = image.LocationY + image.Height;

				for (int x = imageMinX; x < imageMaxX; x++)
				{
					for (int y = imageMinY; y < imageMaxY; y++)
					{
						var character = image.GraphicsBuffer.CharacterBuffer[x, y];
						var color = image.GraphicsBuffer.ColorBuffer[x, y];
						_consoleWindow.Set(x, y, character, color);
					}
				}
			}
		}

		private void UpdateConsoleWindow()
		{
			_consoleWindow.Update();
		}
		private void ClearConsoleWindow()
		{
			_consoleWindow.Clear();
		}
	}

	public interface IRasterizer
	{
		IRasterizedImage Rasterize(IRenderable renderable);
	}

	public interface IRasterizedImage
	{
		int LocationX { get; }

		int LocationY { get; }

		int Width { get; }

		int Height { get; }

		IGraphicsBuffer GraphicsBuffer { get; }
	}

	public interface IRenderable
	{
		IEnumerable<RenderablePoint> Points { get; }
	}

	public class SimpleRenderable
		: IRenderable
	{
		public IEnumerable<RenderablePoint> Points { get; set; }
	}

	public class ZSortedRenderable
		: IRenderable
	{
		public IEnumerable<RenderablePoint> Points { get; set; }
	}

	public struct RenderablePoint
		: IEquatable<RenderablePoint>
	{
		public Vector3 Position;
		public byte Character;
		public ushort Color;

		public bool Equals(RenderablePoint other)
		{
			throw new NotImplementedException();
		}
	}
}