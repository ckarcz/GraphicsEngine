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
			var points = new List<Vector3>();
			for (var i = 0; i < face.Count; i++)
			{
				var faceVertex = face[i];
				var geoVertex = wavefrontObj.Vertices[faceVertex.VertexIndex - 1];
				var point = new Vector3(geoVertex.X, geoVertex.Y, geoVertex.Z);
				points.Add(point);
			}

			var polygon = new Polygon(points);

			mesh.Faces.Add(polygon);
		}
	}
}