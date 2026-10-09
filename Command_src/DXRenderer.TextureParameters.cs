using System.Runtime.InteropServices;
using DirectN;

namespace DXRenderer;

public struct TextureParameters
{
	internal string Path;

	internal D3D11_TEXTURE2D_DESC Description;

	internal D3D11_SUBRESOURCE_DATA Data;

	internal GCHandle Collector;

	internal uint[] RentedBuffer;
}
