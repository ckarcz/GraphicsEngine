#region Imports

using System;
using System.Collections.Generic;
using GraphicsEngine.Graphics.Console;
using GraphicsEngine.Math;

#endregion

namespace GraphicsEngine.Graphics
{
	public class LazyRasterizer
		: BaseRasterizer
	{
		private readonly Queue<Action> rasterizingActions;

		public LazyRasterizer(int width, int height)
			: base(width, height)
		{
			rasterizingActions = new Queue<Action>();
		}

		public override void DrawMeshWired(ITransformation transformation, IMesh mesh, short? colorOverride = null, byte? pixelOverride = null)
		{
			var action = new Action(() => DrawMeshWired(FrameBuffer, transformation, mesh, colorOverride, pixelOverride));
			rasterizingActions.Enqueue(action);
		}

		public override void DrawMeshWired(ITransformation transformation, IEnumerable<IMesh> meshes, short? colorOverride = null, byte? pixelOverride = null)
		{
			var action = new Action(() => DrawMeshWired(FrameBuffer, transformation, meshes, colorOverride, pixelOverride));
			rasterizingActions.Enqueue(action);
		}

		public override void DrawMeshFilled(ITransformation transformation, IMesh mesh, short? colorOverride = null, byte? pixelOverride = null)
		{
			var action = new Action(() => DrawMeshFilled(FrameBuffer, transformation, mesh, colorOverride, pixelOverride));
			rasterizingActions.Enqueue(action);
		}

		public override void DrawMeshFilled(ITransformation transformation, IEnumerable<IMesh> meshes, short? colorOverride = null, byte? pixelOverride = null)
		{
			var action = new Action(() => DrawMeshFilled(FrameBuffer, transformation, meshes, colorOverride, pixelOverride));
			rasterizingActions.Enqueue(action);
		}

		public override void DrawMeshVertices(ITransformation transformation, IMesh mesh, short? colorOverride = null, byte? pixelOverride = null)
		{
			var action = new Action(() => DrawMeshVertices(FrameBuffer, transformation, mesh, colorOverride, pixelOverride));
			rasterizingActions.Enqueue(action);
		}

		public override void DrawMeshVertices(ITransformation transformation, IEnumerable<IMesh> meshes, short? colorOverride = null, byte? pixelOverride = null)
		{
			var action = new Action(() => DrawMeshVertices(FrameBuffer, transformation, meshes, colorOverride, pixelOverride));
			rasterizingActions.Enqueue(action);
		}

		public override void DrawMeshCenters(ITransformation transformation, IMesh mesh, short? colorOverride = null, byte? pixelOverride = null)
		{
			var action = new Action(() => DrawMeshCenters(FrameBuffer, transformation, mesh, colorOverride, pixelOverride));
			rasterizingActions.Enqueue(action);
		}

		public override void DrawMeshCenters(ITransformation transformation, IEnumerable<IMesh> meshes, short? colorOverride = null, byte? pixelOverride = null)
		{
			var action = new Action(() => DrawMeshCenters(FrameBuffer, transformation, meshes, colorOverride, pixelOverride));
			rasterizingActions.Enqueue(action);
		}

		public override void DrawMeshBoundingBox(ITransformation transformation, IMesh mesh, short? colorOverride = null, byte? pixelOverride = null)
		{
			var action = new Action(() => DrawMeshBoundingBox(FrameBuffer, transformation, mesh, colorOverride, pixelOverride));
			rasterizingActions.Enqueue(action);
		}

		public override void DrawMeshBoundingBox(ITransformation transformation, IEnumerable<IMesh> meshes, short? colorOverride = null, byte? pixelOverride = null)
		{
			var action = new Action(() => DrawMeshBoundingBox(FrameBuffer, transformation, meshes, colorOverride, pixelOverride));
			rasterizingActions.Enqueue(action);
		}

		public override void DrawPolygonWired(ITransformation transformation, IEnumerable<Vector2> vectors, short? colorOverride = null, byte? pixelOverride = null)
		{
			var action = new Action(() => DrawPolygonWired(FrameBuffer, transformation, vectors, colorOverride, pixelOverride));
			rasterizingActions.Enqueue(action);
		}

		public override void DrawPolygonWired(ITransformation transformation, IEnumerable<Vector3> vectors, short? colorOverride = null, byte? pixelOverride = null)
		{
			var action = new Action(() => DrawPolygonWired(FrameBuffer, transformation, vectors, colorOverride, pixelOverride));
			rasterizingActions.Enqueue(action);
		}

		public override void DrawPolygonFilled(ITransformation transformation, IEnumerable<Vector2> vectors, short? colorOverride = null, byte? pixelOverride = null)
		{
			var action = new Action(() => DrawPolygonFilled(FrameBuffer, transformation, vectors, colorOverride, pixelOverride));
			rasterizingActions.Enqueue(action);
		}

		public override void DrawPolygonFilled(ITransformation transformation, IEnumerable<Vector3> vectors, short? colorOverride = null, byte? pixelOverride = null)
		{
			var action = new Action(() => DrawPolygonFilled(FrameBuffer, transformation, vectors, colorOverride, pixelOverride));
			rasterizingActions.Enqueue(action);
		}

		public override void DrawAxes(ITransformation transformation, short? colorOverride = null, byte? pixelOverride = null)
		{
			var action = new Action(() => DrawAxes(FrameBuffer, transformation, colorOverride, pixelOverride));
			rasterizingActions.Enqueue(action);
		}

		public override void DrawLine(ITransformation transformation, Vector3 point1, Vector3 point2, short? colorOverride = null, byte? pixelOverride = null)
		{
			var action = new Action(() => DrawLine(FrameBuffer, transformation, point1, point2, colorOverride, pixelOverride));
			rasterizingActions.Enqueue(action);
		}

		public override void DrawLine(ITransformation transformation, Vector2 point1, Vector2 point2, short? colorOverride = null, byte? pixelOverride = null)
		{
			var action = new Action(() => DrawLine(FrameBuffer, transformation, point1, point2, colorOverride, pixelOverride));
			rasterizingActions.Enqueue(action);
		}

		public override void DrawPoints(ITransformation transformation, IEnumerable<Vector2> points, short? colorOverride = null, byte? pixelOverride = null)
		{
			var action = new Action(() => DrawPoints(FrameBuffer, transformation, points, colorOverride, pixelOverride));
			rasterizingActions.Enqueue(action);
		}

		public override void DrawPoints(ITransformation transformation, IEnumerable<Vector3> points, short? colorOverride = null, byte? pixelOverride = null)
		{
			var action = new Action(() => DrawPoints(FrameBuffer, transformation, points, colorOverride, pixelOverride));
			rasterizingActions.Enqueue(action);
		}

		public override void DrawPoint(ITransformation transformation, Vector2 point, short? colorOverride = null, byte? pixelOverride = null)
		{
			var action = new Action(() => DrawPoint(FrameBuffer, transformation, point, colorOverride, pixelOverride));
			rasterizingActions.Enqueue(action);
		}

		public override void DrawPoint(ITransformation transformation, Vector3 point, short? colorOverride = null, byte? pixelOverride = null)
		{
			var action = new Action(() => DrawPoint(FrameBuffer, transformation, point, colorOverride, pixelOverride));
			rasterizingActions.Enqueue(action);
		}

		public override void DrawStringHorizontal(ITransformation transformation, Vector2 location, string messageString, short? colorOverride = null)
		{
			var action = new Action(() => DrawStringHorizontal(FrameBuffer, transformation, location, messageString, colorOverride));
			rasterizingActions.Enqueue(action);
		}

		public override void DrawStringVertical(ITransformation transformation, Vector2 location, string messageString, short? colorOverride = null)
		{
			var action = new Action(() => DrawStringHorizontal(FrameBuffer, transformation, location, messageString, colorOverride));
			rasterizingActions.Enqueue(action);
		}

		public override byte? GetPixelCharacter(int x, int y)
		{
			Rasterize();
            return FrameBuffer.CharacterBuffer[x, y];
		}

		public override short? GetPixelColor(int x, int y)
		{
			Rasterize();
            return FrameBuffer.ColorBuffer[x, y];
		}

		public override void ClearImage(byte? clearCharacter = null, byte? clearColor = null)
		{
			Reset();
			ClearImage(FrameBuffer, clearCharacter, clearColor);
		}

		public void Reset()
		{
			rasterizingActions.Clear();
		}

		public override ConsoleGraphicsFrame Rasterize()
		{
			foreach (var rasterizationAction in rasterizingActions)
			{
				rasterizationAction();
			}

			Reset();

			return FrameBuffer;
		}
	}
}