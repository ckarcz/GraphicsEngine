#region Imports

using GraphicsEngine.Wavefront.Models;

#endregion

namespace GraphicsEngine.Wavefront.Datastore
{
	public interface IVertexNormalDataStore
	{
		void AddNormal(VertexNormal normal);
	}
}