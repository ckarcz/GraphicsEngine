#region Imports

using System.Collections.Generic;
using GraphicsEngine.Common;
using GraphicsEngine.Math;

#endregion

namespace GraphicsEngine.Graphics
{
	public class MeshCenterer
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
			var meshCenters = mesh.Centers;

			var centeredMesh = new Mesh();
			if (meshCenters.HasValue)
			{
				foreach (var face in mesh.Faces)
				{
					var centeredFace = Center(face, meshCenters.Value);
					centeredMesh.Faces.Add(centeredFace);
				}
			}
			return centeredMesh;
		}

		private Polygon Center(IPolygon face, Vector3 centers)
		{
			var centeredPolygon = new Polygon();
			foreach (var point in face.Points)
			{
				var centeredPoint = Center(point, centers);
				centeredPolygon.Points.Add(centeredPoint);
			}
			return centeredPolygon;
		}

		private Vector3 Center(Vector3 point, Vector3 centers)
		{
			var newX = point.X - centers.X;
			var newY = point.Y - centers.Y;
			var newZ = point.Z - centers.Z;
			var newVector = new Vector3(newX, newY, newZ);
			return newVector;
		}
	}
}