using DirectN;

namespace DXRenderer;

public class ShaderManagerEntry
{
	public IComObject<ID3D11VertexShader> vertexShader;

	public IComObject<ID3D11PixelShader> pixelShader;

	public IComObject<ID3D11InputLayout> inputLayout;

	static ShaderManagerEntry()
	{
		Class72.smethod_20();
	}
}
