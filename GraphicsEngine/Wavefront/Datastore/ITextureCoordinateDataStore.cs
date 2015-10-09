#region Imports

using GraphicsEngine.Wavefront.Models;

#endregion

namespace GraphicsEngine.Wavefront.Datastore
{
	public interface ITextureCoordinateDataStore
	{
		void AddTexture(TextureCoordinate texture);
	}
}