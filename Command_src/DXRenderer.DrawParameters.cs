using DirectN;

namespace DXRenderer;

public struct DrawParameters
{
	internal Projection Projection;

	internal IComObject<ID3D11Buffer> VertexBuffer;

	internal IComObject<ID3D11Buffer> IndexBuffer;

	internal uint NumberIndices;

	internal IComObject<ID3D11ShaderResourceView> ShaderResourceView;

	internal float u;

	internal float v;

	internal float uWidth;

	internal float vWidth;

	internal Layer Layer;

	internal uint Level;

	internal uint Row;

	internal bool Disposable;

	internal bool Draw;

	internal bool Hold;

	internal D3D_PRIMITIVE_TOPOLOGY Topology;

	internal int Priority;

	internal float Hint;

	internal bool Undrawable;
}
