#region Imports

using System.Collections.Generic;
using System.Linq;
using GraphicsEngine.Common.Extensions;
using GraphicsEngine.Wavefront.Models;

#endregion

namespace GraphicsEngine.Wavefront.Datastore
{
	public class DataStore
		: IDataStore, IGroupDataStore, IGeometricVertexDataStore, ITextureCoordinateDataStore, IVertexNormalDataStore, IFaceGroup, IMaterialLibrary, IElementGroup
	{
		private Group _currentGroup;
		private readonly List<Group> _groups = new List<Group>();
		private readonly List<Material> _materials = new List<Material>();
		private readonly List<VertexNormal> _normals = new List<VertexNormal>();
		private readonly List<TextureCoordinate> _textures = new List<TextureCoordinate>();
		private readonly List<GeometricVertex> _vertices = new List<GeometricVertex>();

		public IList<GeometricVertex> Vertices
		{
			get { return _vertices; }
		}

		public IList<TextureCoordinate> Textures
		{
			get { return _textures; }
		}

		public IList<VertexNormal> Normals
		{
			get { return _normals; }
		}

		public IList<Material> Materials
		{
			get { return _materials; }
		}

		public IList<Group> Groups
		{
			get { return _groups; }
		}

		public void SetMaterial(string materialName)
		{
			var material = _materials.SingleOrDefault(x => x.Name.EqualsInvariantCultureIgnoreCase(materialName));
			PushGroupIfNeeded();
			_currentGroup.Material = material;
		}

		public void AddFace(Face face)
		{
			PushGroupIfNeeded();

			_currentGroup.AddFace(face);
		}

		public void AddVertex(GeometricVertex vertex)
		{
			_vertices.Add(vertex);
		}

		public void PushGroup(string groupName)
		{
			_currentGroup = new Group(groupName);
			_groups.Add(_currentGroup);
		}

		public void Push(Material material)
		{
			_materials.Add(material);
		}

		public void AddTexture(TextureCoordinate texture)
		{
			_textures.Add(texture);
		}

		public void AddNormal(VertexNormal normal)
		{
			_normals.Add(normal);
		}

		private void PushGroupIfNeeded()
		{
			if (_currentGroup == null)
			{
				PushGroup("default");
			}
		}
	}
}