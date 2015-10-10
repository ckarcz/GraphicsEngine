#region Imports

using System;
using GraphicsEngine.Common.Extensions;
using GraphicsEngine.Wavefront.Datastore;
using GraphicsEngine.Wavefront.Models;
using GraphicsEngine.Wavefront.Parsers.Interfaces;

#endregion

namespace GraphicsEngine.Wavefront.Parsers
{
	public class VertexNormalParser
		: TypeParserBase, IVertexNormalParser
	{
		private readonly IVertexNormalDataStore _normalDataStore;

		public VertexNormalParser(IVertexNormalDataStore normalDataStore)
		{
			_normalDataStore = normalDataStore;
		}

		protected override string Keyword
		{
			get { return "vn"; }
		}

		public override void Parse(string line)
		{
			var parts = line.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

			var x = parts[0].ParseInvariantFloat();
			var y = parts[1].ParseInvariantFloat();
			var z = parts[2].ParseInvariantFloat();

			var normal = new VertexNormal(x, y, z);
			_normalDataStore.AddNormal(normal);
		}
	}
}