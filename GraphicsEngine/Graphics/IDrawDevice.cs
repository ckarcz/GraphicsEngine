#region Imports

using System.Collections;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace GraphicsEngine.Graphics
{
	public interface IDrawDevice
	{
		int Width { get; }
		int Height { get; }
		int Renderings { get; }

		void Draw(IFrameBuffer frame);

		void Clear(byte? character = null, uint? color = null);
	}

	public interface INewRasterizer
	{
		IFrameBuffer Rasterize(IRenderable renderable);
	}

	public interface IRenderable
	{
		IRendered Render(IRenderer renderer);
	}

	public interface IRenderer
	{
		IRendered RenderLine();
	}

	public interface IRendered
		: IEnumerable<RenderedPoint>
	{
	}

	public class Rendered
		: IRendered
	{
		private readonly IEnumerable<RenderedPoint> renderedPoints; 

		public Rendered(IEnumerable<RenderedPoint> renderedPoints)
		{
			this.renderedPoints = renderedPoints ?? Enumerable.Empty<RenderedPoint>();
		}

		public IEnumerator<RenderedPoint> GetEnumerator()
		{
			return renderedPoints.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}

	public struct RenderedPoint
	{
		public float X;
		public float Y;
		public float Z;

		public char Character;
		public short Color;
	}

	public struct Colour
	{
		
	}
}