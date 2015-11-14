#region Imports

using System.Collections.Generic;
using GraphicsEngine.Common;
using GraphicsEngine.Math;

#endregion

namespace GraphicsEngine.Graphics
{
	public class MeshNormalizer
		: SingletonBase<MeshCenterer>, IMeshFormatter
	{
		public IEnumerable<IMesh> Transform(IEnumerable<IMesh> meshes)
		{
			var normalizedMeshes = new List<IMesh>();
			foreach (var mesh in meshes)
			{
				var normalizedMesh = Transform(mesh);
				normalizedMeshes.Add(normalizedMesh);
			}
			return normalizedMeshes;
		}

		public IMesh Transform(IMesh mesh)
		{
			var meshMinimums = mesh.Minimums;
			var meshMaximums = mesh.Maximums;

			var normalizedMesh = new Mesh();
			if (meshMinimums.HasValue && meshMaximums.HasValue)
			{
				foreach (var face in mesh.Faces)
				{
					var normalizedFace = Normalize(face, meshMinimums.Value, meshMaximums.Value);
					normalizedMesh.Faces.Add(normalizedFace);
				}
			}
			return normalizedMesh;
		}

		private Polygon Normalize(IPolygon face, Vector3 minimums, Vector3 maximums)
		{
			var normalizedPolygon = new Polygon();
			foreach (var point in face.Points)
			{
				var normalizedPoint = Normalize(point, minimums, maximums);
				normalizedPolygon.Points.Add(normalizedPoint);
			}
			return normalizedPolygon;
		}

		private Vector3 Normalize(Vector3 point, Vector3 minimums, Vector3 maximums)
		{
            var normalizedX = point.X / (maximums.X - minimums.X);
			var normalizedY = point.Y / (maximums.Y - minimums.Y);
			var normalizedZ = point.Z / (maximums.Z - minimums.Z);
			var normalizedVector = new Vector3(normalizedX, normalizedY, normalizedZ);
			return normalizedVector;
		}
	}
}