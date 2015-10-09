#region Imports

using GraphicsEngine.Wavefront.Models;

#endregion

namespace GraphicsEngine.Wavefront.Datastore
{
	public interface IGeometricVertexDataStore
	{
		void AddVertex(GeometricVertex vertex);
	}
}