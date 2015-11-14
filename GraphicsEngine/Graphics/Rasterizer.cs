#region Imports

using System.Collections.Generic;
using GraphicsEngine.Graphics.Console;
using GraphicsEngine.Math;

#endregion

namespace GraphicsEngine.Graphics
{
	public class Rasterizer
		: BaseRasterizer
	{
		public Rasterizer(int width, int height)
			: base(width, height)
		{
		}

		public override void DrawMeshWired(ITransformation transformation, IMesh mesh, short? colorOverride = null, byte? pixelOverride = null)
		{
			DrawMeshWired(FrameBuffer, transformation, mesh, colorOverride, pixelOverride);
		}

		public override void DrawMeshWired(ITransformation transformation, IEnumerable<IMesh> meshes, short? colorOverride = null, byte? pixelOverride = null)
		{
			DrawMeshWired(FrameBuffer, transformation, meshes, colorOverride, pixelOverride);
		}

		public override void DrawMeshFilled(ITransformation transformation, IMesh mesh, short? colorOverride = null, byte? pixelOverride = null)
		{
			DrawMeshFilled(FrameBuffer, transformation, mesh, colorOverride, pixelOverride);
		}

		public override void DrawMeshFilled(ITransformation transformation, IEnumerable<IMesh> meshes, short? colorOverride = null, byte? pixelOverride = null)
		{
			DrawMeshFilled(FrameBuffer, transformation, meshes, colorOverride, pixelOverride);
		}

		public override void DrawMeshVertices(ITransformation transformation, IMesh mesh, short? colorOverride = null, byte? pixelOverride = null)
		{
			DrawMeshVertices(FrameBuffer, transformation, mesh, colorOverride, pixelOverride);
		}

		public override void DrawMeshVertices(ITransformation transformation, IEnumerable<IMesh> meshes, short? colorOverride = null, byte? pixelOverride = null)
		{
			DrawMeshVertices(FrameBuffer, transformation, meshes, colorOverride, pixelOverride);
		}

		public override void DrawMeshCenters(ITransformation transformation, IMesh mesh, short? colorOverride = null, byte? pixelOverride = null)
		{
			DrawMeshCenters(FrameBuffer, transformation, mesh, colorOverride, pixelOverride);
		}

		public override void DrawMeshCenters(ITransformation transformation, IEnumerable<IMesh> meshes, short? colorOverride = null, byte? pixelOverride = null)
		{
			DrawMeshCenters(FrameBuffer, transformation, meshes, colorOverride, pixelOverride);
		}

		public override void DrawMeshBoundingBox(ITransformation transformation, IMesh mesh, short? colorOverride = null, byte? pixelOverride = null)
		{
			DrawMeshBoundingBox(FrameBuffer, transformation, mesh, colorOverride, pixelOverride);
		}

		public override void DrawMeshBoundingBox(ITransformation transformation, IEnumerable<IMesh> meshes, short? colorOverride = null, byte? pixelOverride = null)
		{
			DrawMeshBoundingBox(FrameBuffer, transformation, meshes, colorOverride, pixelOverride);
		}

		public override void DrawPolygonWired(ITransformation transformation, IEnumerable<Vector2> vectors, short? colorOverride = null, byte? pixelOverride = null)
		{
			DrawPolygonWired(FrameBuffer, transformation, vectors, colorOverride, pixelOverride);
		}

		public override void DrawPolygonWired(ITransformation transformation, IEnumerable<Vector3> vectors, short? colorOverride = null, byte? pixelOverride = null)
		{
			DrawPolygonWired(FrameBuffer, transformation, vectors, colorOverride, pixelOverride);
		}

		public override void DrawPolygonFilled(ITransformation transformation, IEnumerable<Vector2> vectors, short? colorOverride = null, byte? pixelOverride = null)
		{
			DrawPolygonFilled(FrameBuffer, transformation, vectors, colorOverride, pixelOverride);
		}

		public override void DrawPolygonFilled(ITransformation transformation, IEnumerable<Vector3> vectors, short? colorOverride = null, byte? pixelOverride = null)
		{
			DrawPolygonFilled(FrameBuffer, transformation, vectors, colorOverride, pixelOverride);
		}

		public override void DrawAxes(ITransformation transformation, short? colorOverride = null, byte? pixelOverride = null)
		{
			DrawAxes(FrameBuffer, transformation, colorOverride, pixelOverride);
		}

		public override void DrawLine(ITransformation transformation, Vector3 point1, Vector3 point2, short? colorOverride = null, byte? pixelOverride = null)
		{
			DrawLine(FrameBuffer, transformation, point1, point2, colorOverride, pixelOverride);
		}

		public override void DrawLine(ITransformation transformation, Vector2 point1, Vector2 point2, short? colorOverride = null, byte? pixelOverride = null)
		{
			DrawLine(FrameBuffer, transformation, point1, point2, colorOverride, pixelOverride);
		}

		public override void DrawPoints(ITransformation transformation, IEnumerable<Vector2> points, short? colorOverride = null, byte? pixelOverride = null)
		{
			DrawPoints(FrameBuffer, transformation, points, colorOverride, pixelOverride);
		}

		public override void DrawPoints(ITransformation transformation, IEnumerable<Vector3> points, short? colorOverride = null, byte? pixelOverride = null)
		{
			DrawPoints(FrameBuffer, transformation, points, colorOverride, pixelOverride);
		}

		public override void DrawPoint(ITransformation transformation, Vector2 point, short? colorOverride = null, byte? pixelOverride = null)
		{
			DrawPoint(FrameBuffer, transformation, point, colorOverride, pixelOverride);
		}

		public override void DrawPoint(ITransformation transformation, Vector3 point, short? colorOverride = null, byte? pixelOverride = null)
		{
			DrawPoint(FrameBuffer, transformation, point, colorOverride, pixelOverride);
		}

		public override void DrawStringHorizontal(ITransformation transformation, Vector2 location, string messageString, short? colorOverride = null)
		{
			DrawStringHorizontal(FrameBuffer, transformation, location, messageString, colorOverride);
		}

		public override void DrawStringVertical(ITransformation transformation, Vector2 location, string messageString, short? colorOverride = null)
		{
			DrawStringHorizontal(FrameBuffer, transformation, location, messageString, colorOverride);
		}

		public override byte? GetPixelCharacter(int x, int y)
		{
			return FrameBuffer.CharacterBuffer[x, y];
		}

		public override short? GetPixelColor(int x, int y)
		{
			return FrameBuffer.ColorBuffer[x, y];
		}

		public override void ClearImage(byte? clearCharacter = null, byte? clearColor = null)
		{
			ClearImage(FrameBuffer, clearCharacter, clearColor);
		}

		public override ConsoleGraphicsFrame Rasterize()
		{
			return FrameBuffer;
		}
	}
}