namespace GraphicsEngine.Wavefront.Loaders
{
	public interface IWavefrontObjLoaderFactory
	{
		IWavefrontObjLoader Create(IMaterialStreamProvider materialStreamProvider);

		IWavefrontObjLoader Create();
	}
}