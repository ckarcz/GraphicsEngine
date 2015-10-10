#region Imports

using System;
using System.Collections.Generic;
using System.IO;
using GraphicsEngine.Common.Extensions;
using GraphicsEngine.Wavefront.Datastore;
using GraphicsEngine.Wavefront.Models;

#endregion

namespace GraphicsEngine.Wavefront.Loaders
{
	public class MaterialLibraryLoader
		: LoaderBase, IMaterialLibraryLoader
	{
		private readonly IMaterialLibrary _materialLibrary;
		private readonly Dictionary<string, Action<string>> _parseActionDictionary = new Dictionary<string, Action<string>>();
		private readonly List<string> _unrecognizedLines = new List<string>();

		public MaterialLibraryLoader(IMaterialLibrary materialLibrary)
		{
			_materialLibrary = materialLibrary;

			AddParseAction("newmtl", PushMaterial);
			AddParseAction("Ka", d => CurrentMaterial.AmbientColor = ParseColour(d));
			AddParseAction("Kd", d => CurrentMaterial.DiffuseColor = ParseColour(d));
			AddParseAction("Ks", d => CurrentMaterial.SpecularColor = ParseColour(d));
			AddParseAction("Ns", d => CurrentMaterial.SpecularCoefficient = d.ParseInvariantFloat());

			AddParseAction("d", d => CurrentMaterial.Transparency = d.ParseInvariantFloat());
			AddParseAction("Tr", d => CurrentMaterial.Transparency = d.ParseInvariantFloat());

			AddParseAction("illum", i => CurrentMaterial.IlluminationModel = i.ParseInvariantInt());

			AddParseAction("map_Ka", m => CurrentMaterial.AmbientTextureMap = m);
			AddParseAction("map_Kd", m => CurrentMaterial.DiffuseTextureMap = m);

			AddParseAction("map_Ks", m => CurrentMaterial.SpecularTextureMap = m);
			AddParseAction("map_Ns", m => CurrentMaterial.SpecularHighlightTextureMap = m);

			AddParseAction("map_d", m => CurrentMaterial.AlphaTextureMap = m);

			AddParseAction("map_bump", m => CurrentMaterial.BumpMap = m);
			AddParseAction("bump", m => CurrentMaterial.BumpMap = m);

			AddParseAction("disp", m => CurrentMaterial.DisplacementMap = m);

			AddParseAction("decal", m => CurrentMaterial.StencilDecalMap = m);
		}

		private Material CurrentMaterial { get; set; }

		public void Load(Stream lineStream)
		{
			StartLoad(lineStream);
		}

		private void AddParseAction(string key, Action<string> action)
		{
			_parseActionDictionary.Add(key.ToLowerInvariant(), action);
		}

		protected override void ParseLine(string keyword, string data)
		{
			var parseAction = GetKeywordAction(keyword);

			if (parseAction == null)
			{
				_unrecognizedLines.Add(keyword + " " + data);
				return;
			}

			parseAction(data);
		}

		private Action<string> GetKeywordAction(string keyword)
		{
			Action<string> action;
			_parseActionDictionary.TryGetValue(keyword.ToLowerInvariant(), out action);

			return action;
		}

		private void PushMaterial(string materialName)
		{
			CurrentMaterial = new Material(materialName);
			_materialLibrary.Push(CurrentMaterial);
		}

		private Colour ParseColour(string data)
		{
			var parts = data.Split(' ');

			var r = parts[0].ParseInvariantFloat();
			var g = parts[1].ParseInvariantFloat();
			var b = parts[2].ParseInvariantFloat();

			return new Colour(r, g, b);
		}
	}
}