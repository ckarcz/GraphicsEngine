#region Imports

using System;
using GraphicsEngine.Common.Extensions;
using GraphicsEngine.Wavefront.Datastore;
using GraphicsEngine.Wavefront.Models;
using GraphicsEngine.Wavefront.Parsers.Interfaces;

#endregion

namespace GraphicsEngine.Wavefront.Parsers
{
	public class GeometricVertexParser
		: TypeParserBase, IGeometricVertexParser
	{
		private readonly IGeometricVertexDataStore _vertexDataStore;

		public GeometricVertexParser(IGeometricVertexDataStore vertexDataStore)
		{
			_vertexDataStore = vertexDataStore;
		}

		protected override string Keyword
		{
			get { return "v"; }
		}

		public override void Parse(string line)
		{
			string[] parts = line.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

			var x = parts[0].ParseInvariantFloat();
			var y = parts[1].ParseInvariantFloat();
			var z = parts[2].ParseInvariantFloat();

			var vertex = new GeometricVertex(x, y, z);
			_vertexDataStore.AddVertex(vertex);
		}
	}
}