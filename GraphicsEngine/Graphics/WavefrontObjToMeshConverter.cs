#region Imports

using System.Collections.Generic;
using System.Data;
using GraphicsEngine.Math;
using GraphicsEngine.Wavefront.Loaders;
using GraphicsEngine.Wavefront.Models;

#endregion

namespace GraphicsEngine.Graphics
{
	public class WavefrontObjToMeshConverter
		: IWavefrontObjToMeshConverter
	{
		public IList<IMesh> ConvertToMesh(IWavefrontObj wavefrontObj)
		{
			var meshes = ConvertGroups(wavefrontObj);

			return meshes;
		}

		private IList<IMesh> ConvertGroups(IWavefrontObj wavefrontObj)
		{
			var meshes = new List<IMesh>();

			foreach (var group in wavefrontObj.Groups)
			{
				var mesh = ConvertGroup(wavefrontObj, group);
				meshes.Add(mesh);
			}

			return meshes;
		}

		private IMesh ConvertGroup(IWavefrontObj wavefrontObj, Group group)
		{
			var mesh = new Mesh();

			foreach (var face in group.Faces)
			{
				ConvertFace(wavefrontObj, face, mesh);
				mesh.Name = group.Name;
			}

			return mesh;
		}

		private void ConvertFace(IWavefrontObj wavefrontObj, Face face, Mesh mesh)
		{
			if (face.Count != 3)
			{
				throw new DataException("Only triangles are supported");
			}

			var faceVertex1 = face[0];
			var faceVertex2 = face[1];
			var faceVertex3 = face[2];

			var geoVertex1 = wavefrontObj.Vertices[faceVertex1.VertexIndex - 1];
			var geoVertex2 = wavefrontObj.Vertices[faceVertex2.VertexIndex - 1];
			var geoVertex3 = wavefrontObj.Vertices[faceVertex3.VertexIndex - 1];

			var point1 = new Vector3(geoVertex1.X, geoVertex1.Y, geoVertex1.Z);
			var point2 = new Vector3(geoVertex2.X, geoVertex2.Y, geoVertex2.Z);
			var point3 = new Vector3(geoVertex3.X, geoVertex3.Y, geoVertex3.Z);

			var triangle = new Polygon(point1, point2, point3);

			mesh.Faces.Add(triangle);
		}
	}
}