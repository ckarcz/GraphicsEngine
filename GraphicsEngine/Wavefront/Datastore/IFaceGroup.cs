#region Imports

using GraphicsEngine.Wavefront.Models;

#endregion

namespace GraphicsEngine.Wavefront.Datastore
{
	public interface IFaceGroup
	{
		void AddFace(Face face);
	}
}