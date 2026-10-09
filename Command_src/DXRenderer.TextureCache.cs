using System.Collections.Generic;
using DirectN;

namespace DXRenderer;

public class TextureCache
{
	private Dictionary<string, IComObject<ID3D11ShaderResourceView>> dictionary_0;

	public Dictionary<string, IComObject<ID3D11ShaderResourceView>> ShaderResourceViews => dictionary_0;

	public TextureCache()
	{
		dictionary_0 = new Dictionary<string, IComObject<ID3D11ShaderResourceView>>();
	}

	static TextureCache()
	{
		Class72.smethod_20();
	}
}
