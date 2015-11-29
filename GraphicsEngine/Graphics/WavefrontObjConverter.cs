#region Imports

using System.Collections.Generic;
using System.IO;
using GraphicsEngine.Math;
using GraphicsEngine.Wavefront.Loaders;
using GraphicsEngine.Wavefront.Models;

#endregion

namespace GraphicsEngine.Graphics
{
	public class WavefrontObjConverter
		: IWavefrontObjConverter
	{
		public IEnumerable<IMesh> ConvertToMesh(IWavefrontObj wavefrontObj)
		{
			var meshes = ConvertGroups(wavefrontObj);

			return meshes;
		}

		private IEnumerable<IMesh> ConvertGroups(IWavefrontObj wavefrontObj)
		{
			var meshes = new List<Mesh>();

			foreach (var group in wavefrontObj.Groups)
			{
				var mesh = ConvertGroup(wavefrontObj, group);
				meshes.Add(mesh);
			}

			return meshes;
		}

		private Mesh ConvertGroup(IWavefrontObj wavefrontObj, Group group)
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
			var points = new List<Vector3>();
			var verticesCount = wavefrontObj.Vertices.Count;
            for (var i = 0; i < face.Count; i++)
			{
				var faceVertex = face[i];
				var actualVertexIndex = 0;
				if (faceVertex.VertexIndex > 0)
				{
					actualVertexIndex = faceVertex.VertexIndex - 1;
				}
				else if (faceVertex.VertexIndex < 0)
				{
					actualVertexIndex = verticesCount + faceVertex.VertexIndex;
				}
				else
				{
					throw new InvalidDataException("Obj model contains a vertex index of 0.");
				}
				var geoVertex = wavefrontObj.Vertices[actualVertexIndex];
				var point = new Vector3(geoVertex.X, geoVertex.Y, geoVertex.Z);
				points.Add(point);
			}

			var polygon = new Polygon(points);

			mesh.Faces.Add(polygon);
		}
	}
}