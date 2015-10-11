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

			CalculateNormals(mesh);

			return mesh;
		}

		private void ConvertFace(IWavefrontObj wavefrontObj, Face face, Mesh mesh)
		{
			if (face.Count != 3)
			{
				throw new DataException("Only triangles are supported");
			}

			for (var i = 0; i < face.Count; i++)
			{
				var faceVertex = face[i];

				var vertex = wavefrontObj.Vertices[faceVertex.VertexIndex - 1];
				mesh.Vectors.Add(new Vector3(vertex.X, vertex.Y, vertex.Z));
			}
		}

		private void CalculateNormals(Mesh mesh)
		{
			for (var i = 0; i < mesh.Vectors.Count; i += 3)
			{
				var a = mesh.Vectors[i];
				var b = mesh.Vectors[i + 1];
				var c = mesh.Vectors[i + 2];

				var normal = (b - a).Cross(c - a);

				mesh.Normals.Add(normal);
				mesh.Normals.Add(normal);
				mesh.Normals.Add(normal);
			}
		}
	}
}