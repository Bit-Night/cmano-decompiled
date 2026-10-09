using System.Collections.Generic;
using DirectN;

namespace DXRenderer;

internal class DepthStencilCache
{
	private class Class24
	{
		public D3D11_DEPTH_STENCIL_DESC d3D11_DEPTH_STENCIL_DESC_0;

		public IComObject<ID3D11DepthStencilState> icomObject_0;

		static Class24()
		{
			Class72.smethod_20();
		}
	}

	private List<Class24> list_0 = new List<Class24>();

	private DXAdapter dxadapter_0;

	public DepthStencilCache(DXAdapter device)
	{
		dxadapter_0 = device;
	}

	public IComObject<ID3D11DepthStencilState> GetDepthStencilState(uint id)
	{
		if (id >= list_0.Count)
		{
			return null;
		}
		return list_0[(int)id].icomObject_0;
	}

	public uint CreateDepthStencilState(D3D11_DEPTH_STENCIL_DESC desc)
	{
		int num = 0;
		while (true)
		{
			if (num < list_0.Count)
			{
				if (desc.Equals(list_0[num].d3D11_DEPTH_STENCIL_DESC_0))
				{
					break;
				}
				num++;
				continue;
			}
			Class24 @class = new Class24();
			@class.d3D11_DEPTH_STENCIL_DESC_0 = desc;
			@class.icomObject_0 = dxadapter_0.Device.CreateDepthStencilState(desc);
			list_0.Add(@class);
			return (uint)(list_0.Count - 1);
		}
		return (uint)num;
	}

	static DepthStencilCache()
	{
		Class72.smethod_20();
	}
}
