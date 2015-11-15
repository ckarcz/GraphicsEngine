#region Imports

using System.Collections.Generic;
using GraphicsEngine.Math;

#endregion

namespace GraphicsEngine.Graphics
{
	public interface IRasterizer
	{
		void DrawMeshWired(ITransformation transformation, IMesh mesh, short? colorOverride = null, byte? pixelOverride = null);

		void DrawMeshWired(ITransformation transformation, IEnumerable<IMesh> meshes, short? colorOverride = null, byte? pixelOverride = null);

		void DrawMeshFilled(ITransformation transformation, IMesh mesh, short? colorOverride = null, byte? pixelOverride = null);

		void DrawMeshFilled(ITransformation transformation, IEnumerable<IMesh> meshes, short? colorOverride = null, byte? pixelOverride = null);

		void DrawMeshVertices(ITransformation transformation, IMesh mesh, short? colorOverride = null, byte? pixelOverride = null);

		void DrawMeshVertices(ITransformation transformation, IEnumerable<IMesh> meshes, short? colorOverride = null, byte? pixelOverride = null);

		void DrawMeshCenters(ITransformation transformation, IMesh mesh, short? colorOverride = null, byte? pixelOverride = null);

		void DrawMeshCenters(ITransformation transformation, IEnumerable<IMesh> meshes, short? colorOverride = null, byte? pixelOverride = null);

		void DrawMeshBoundingBox(ITransformation transformation, IMesh mesh, short? colorOverride = null, byte? pixelOverride = null);

		void DrawMeshBoundingBox(ITransformation transformation, IEnumerable<IMesh> meshes, short? colorOverride = null, byte? pixelOverride = null);

		void DrawPolygonWired(ITransformation transformation, IEnumerable<Vector2> vectors, short? colorOverride = null, byte? pixelOverride = null);

		void DrawPolygonWired(ITransformation transformation, IEnumerable<Vector3> vectors, short? colorOverride = null, byte? pixelOverride = null);

		void DrawPolygonFilled(ITransformation transformation, IEnumerable<Vector2> vectors, short? colorOverride = null, byte? pixelOverride = null);

		void DrawPolygonFilled(ITransformation transformation, IEnumerable<Vector3> vectors, short? colorOverride = null, byte? pixelOverride = null);

		void DrawAxes(ITransformation transformation, short? colorOverride = null, byte? pixelOverride = null);

		void DrawLine(ITransformation transformation, Vector3 point1, Vector3 point2, short? colorOverride = null, byte? pixelOverride = null);

		void DrawLine(ITransformation transformation, Vector2 point1, Vector2 point2, short? colorOverride = null, byte? pixelOverride = null);

		void DrawPoints(ITransformation transformation, IEnumerable<Vector2> points, short? colorOverride = null, byte? pixelOverride = null);

		void DrawPoints(ITransformation transformation, IEnumerable<Vector3> points, short? colorOverride = null, byte? pixelOverride = null);

		void DrawPoint(ITransformation transformation, Vector2 point, short? colorOverride = null, byte? pixelOverride = null);

		void DrawPoint(ITransformation transformation, Vector3 point, short? colorOverride = null, byte? pixelOverride = null);

		void DrawStringHorizontal(ITransformation transformation, Vector2 location, string messageString, short? colorOverride = null);

		void DrawStringVertical(ITransformation transformation, Vector2 location, string messageString, short? colorOverride = null);

		byte? GetPixelCharacter(int x, int y);

		short? GetPixelColor(int x, int y);

		void ClearImage(byte? clearCharacter = null, byte? clearColor = null);

		GraphicsFrame Rasterize();
	}
}