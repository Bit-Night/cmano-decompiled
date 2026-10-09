using DirectN;

namespace DXRenderer;

public class DXAdapter
{
	private static DXAdapterCache dxadapterCache_0;

	private IComObject<ID3D11Device> icomObject_0;

	private IComObject<ID3D11DeviceContext> icomObject_1;

	private ShaderManager shaderManager_0;

	private IComObject<IDXGIAdapter> icomObject_2;

	private string string_0 = "";

	private RasterizerCache rasterizerCache_0;

	private DepthStencilCache depthStencilCache_0;

	private TextureCache textureCache_0;

	private TileCache tileCache_0;

	public static DXAdapterCache Cache => dxadapterCache_0;

	public IComObject<ID3D11Device> Device => icomObject_0;

	public IComObject<ID3D11DeviceContext> Context => icomObject_1;

	public TextureCache TextureCache => textureCache_0;

	public IComObject<IDXGIAdapter> Adapter => icomObject_2;

	public ShaderManager ShaderManager => shaderManager_0;

	public string Description
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public DXAdapter(IComObject<ID3D11Device> device, IComObject<ID3D11DeviceContext> context)
	{
		icomObject_0 = device;
		icomObject_1 = context;
		shaderManager_0 = new ShaderManager(this);
		rasterizerCache_0 = new RasterizerCache(this);
		depthStencilCache_0 = new DepthStencilCache(this);
		textureCache_0 = new TextureCache();
	}

	public uint CreateRasterizerState(D3D11_RASTERIZER_DESC desc)
	{
		return rasterizerCache_0.CreateRasterizerState(desc);
	}

	public void SetRasterizerState(uint id)
	{
		IComObject<ID3D11RasterizerState> rasterizerState = rasterizerCache_0.GetRasterizerState(id);
		if (rasterizerState != null)
		{
			Context.Object.RSSetState(rasterizerState.Object);
		}
	}

	public uint CreateDepthStencilState(D3D11_DEPTH_STENCIL_DESC desc)
	{
		return depthStencilCache_0.CreateDepthStencilState(desc);
	}

	public void SetDepthStencilState(uint id)
	{
		IComObject<ID3D11DepthStencilState> depthStencilState = depthStencilCache_0.GetDepthStencilState(id);
		if (depthStencilState != null)
		{
			Context.Object.OMSetDepthStencilState(depthStencilState.Object, 0u);
		}
	}

	public void SetAdapter(IComObject<IDXGIAdapter> adapter)
	{
		icomObject_2 = adapter;
	}

	static DXAdapter()
	{
		Class72.smethod_20();
		dxadapterCache_0 = new DXAdapterCache();
	}
}
