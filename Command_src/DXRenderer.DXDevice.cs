using System.Collections.Generic;
using System.Numerics;
using System.Windows.Forms;
using DirectN;

namespace DXRenderer;

public class DXDevice
{
	public Matrix4x4 ViewMatrix;

	public Matrix4x4 ProjMatrix;

	public IComObject<ID3D11RenderTargetView> mRenderTargetView;

	public IComObject<ID3D11DepthStencilView> mDepthStencilView;

	public IComObject<IDXGISwapChain1> mSwapChain;

	private DXAdapter dxadapter_0;

	private TileCache tileCache_0;

	private Dictionary<uint, object> dictionary_0 = new Dictionary<uint, object>();

	public IComObject<ID3D11Device> Device => dxadapter_0.Device;

	public IComObject<ID3D11DeviceContext> Context => dxadapter_0.Context;

	public string AdapterDescription => dxadapter_0.Description;

	public TextureCache TextureCache => dxadapter_0.TextureCache;

	public TileCache TileCache => tileCache_0;

	public IComObject<ID3D11RenderTargetView> RenderTargetView => mRenderTargetView;

	public IComObject<ID3D11DepthStencilView> DepthStencilView => mDepthStencilView;

	public IComObject<IDXGISwapChain1> SwapChain => mSwapChain;

	public ShaderManager ShaderManager => dxadapter_0.ShaderManager;

	public uint CreateRasterizerState(D3D11_RASTERIZER_DESC desc)
	{
		return dxadapter_0.CreateRasterizerState(desc);
	}

	public void SetRasterizerState(uint id)
	{
		dxadapter_0.SetRasterizerState(id);
	}

	public uint CreateDepthStencilState(D3D11_DEPTH_STENCIL_DESC desc)
	{
		return dxadapter_0.CreateDepthStencilState(desc);
	}

	public void SetDepthStencilState(uint id)
	{
		dxadapter_0.SetDepthStencilState(id);
	}

	public void SetAdapter(DXAdapter adapter, RenderState renderState)
	{
		dxadapter_0 = adapter;
		tileCache_0 = new TileCache(this, renderState);
	}

	public void SetAdapter(DXAdapter adapter)
	{
		dxadapter_0 = adapter;
	}

	public void CreateConstantBuffer<T>(uint id)
	{
		if (!dictionary_0.ContainsKey(id))
		{
			ConstantBufferHelper<T> value = new ConstantBufferHelper<T>(this);
			dictionary_0.Add(id, value);
		}
	}

	public void UpdateConstantBuffer<T>(uint id, uint index, T buffer)
	{
		if (!dictionary_0.ContainsKey(id))
		{
			CreateConstantBuffer<T>(id);
		}
		if (dictionary_0.TryGetValue(id, out var value))
		{
			(value as ConstantBufferHelper<T>).UpdateToDevice(index, buffer);
		}
	}

	public IComObject<ID3D11Buffer> CreateConstantBuffer(D3D11_BUFFER_DESC desc)
	{
		IComObject<ID3D11Buffer> result = null;
		if (desc.ByteWidth % 16 == 0)
		{
			result = Device.CreateBuffer(desc);
		}
		return result;
	}

	public bool CreateSwapChainAndBackBuffers(Control control)
	{
		IComObject<IDXGIFactory2> factory = DXGIFunctions.CreateDXGIFactory2();
		DXGI_SWAP_CHAIN_DESC1 desc = new DXGI_SWAP_CHAIN_DESC1
		{
			Format = DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_UNORM,
			BufferUsage = 32u,
			BufferCount = 1u
		};
		desc.SampleDesc.Count = 1u;
		desc.SampleDesc.Quality = 0u;
		mSwapChain = factory.CreateSwapChainForHwnd<IDXGISwapChain1>(Device, control.Handle, desc);
		if (SwapChain == null)
		{
			return false;
		}
		IComObject<ID3D11Texture2D> buffer = SwapChain.GetBuffer<ID3D11Texture2D>(0u);
		buffer.Object.GetDesc(out var pDesc);
		int result;
		if (pDesc.Width == control.ClientRectangle.Width)
		{
			if (pDesc.Height == control.ClientRectangle.Height)
			{
				mRenderTargetView = Device.CreateRenderTargetView(buffer);
				buffer.Dispose();
				if (RenderTargetView == null)
				{
					return false;
				}
				pDesc.Format = DXGI_FORMAT.DXGI_FORMAT_D24_UNORM_S8_UINT;
				pDesc.BindFlags = 64u;
				IComObject<ID3D11Texture2D> comObject = Device.CreateTexture2D<ID3D11Texture2D>(pDesc);
				if (comObject == null)
				{
					return false;
				}
				mDepthStencilView = Device.CreateDepthStencilView(comObject);
				comObject.Dispose();
				if (DepthStencilView != null)
				{
					Context.Object.OMSetRenderTargets(1, new ID3D11RenderTargetView[1] { RenderTargetView.Object }, DepthStencilView.Object);
					return true;
				}
				return false;
			}
			result = 0;
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	public void OnResize(Control control, int screenTopLeftX, int screenTopLeftY, int clientRectangleTopMargin, int clientRectangeBottomMargin)
	{
		int width = control.ClientRectangle.Width;
		int num = control.ClientRectangle.Height - clientRectangleTopMargin - clientRectangeBottomMargin;
		RenderTargetView.Dispose();
		DepthStencilView.Dispose();
		if (!SwapChain.Object.ResizeBuffers(1u, (uint)control.ClientRectangle.Width, (uint)control.ClientRectangle.Height, DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_UNORM, 0u).IsOk)
		{
			return;
		}
		IComObject<ID3D11Texture2D> buffer = SwapChain.GetBuffer<ID3D11Texture2D>(0u);
		buffer.Object.GetDesc(out var pDesc);
		if (pDesc.Width != control.ClientRectangle.Width || pDesc.Height != control.ClientRectangle.Height)
		{
			return;
		}
		mRenderTargetView = Device.CreateRenderTargetView(buffer);
		buffer.Dispose();
		if (RenderTargetView == null)
		{
			return;
		}
		pDesc.Format = DXGI_FORMAT.DXGI_FORMAT_D24_UNORM_S8_UINT;
		pDesc.BindFlags = 64u;
		IComObject<ID3D11Texture2D> comObject = Device.CreateTexture2D<ID3D11Texture2D>(pDesc);
		if (comObject != null)
		{
			mDepthStencilView = Device.CreateDepthStencilView(comObject);
			comObject.Dispose();
			if (DepthStencilView != null)
			{
				Context.Object.OMSetRenderTargets(1, new ID3D11RenderTargetView[1] { RenderTargetView.Object }, DepthStencilView.Object);
				D3D11_VIEWPORT d3D11_VIEWPORT = new D3D11_VIEWPORT
				{
					Width = width,
					Height = num,
					MinDepth = 0f,
					MaxDepth = 1f,
					TopLeftX = screenTopLeftX,
					TopLeftY = screenTopLeftY
				};
				Context.Object.RSSetViewports(1, new D3D11_VIEWPORT[1] { d3D11_VIEWPORT });
			}
		}
	}

	static DXDevice()
	{
		Class72.smethod_20();
	}
}
