using System.Collections.Generic;
using DirectN;

namespace DXRenderer;

internal class RasterizerCache
{
	private class Class25
	{
		public D3D11_RASTERIZER_DESC d3D11_RASTERIZER_DESC_0;

		public IComObject<ID3D11RasterizerState> icomObject_0;

		static Class25()
		{
			Class72.smethod_20();
		}
	}

	private List<Class25> list_0 = new List<Class25>();

	private DXAdapter dxadapter_0;

	public RasterizerCache(DXAdapter device)
	{
		dxadapter_0 = device;
	}

	public IComObject<ID3D11RasterizerState> GetRasterizerState(uint id)
	{
		if (id >= list_0.Count)
		{
			return null;
		}
		return list_0[(int)id].icomObject_0;
	}

	public uint CreateRasterizerState(D3D11_RASTERIZER_DESC desc)
	{
		int num = 0;
		while (true)
		{
			if (num < list_0.Count)
			{
				if (desc.Equals(list_0[num].d3D11_RASTERIZER_DESC_0))
				{
					break;
				}
				num++;
				continue;
			}
			Class25 @class = new Class25();
			@class.d3D11_RASTERIZER_DESC_0 = desc;
			@class.icomObject_0 = dxadapter_0.Device.CreateRasterizerState(desc);
			list_0.Add(@class);
			return (uint)(list_0.Count - 1);
		}
		return (uint)num;
	}

	static RasterizerCache()
	{
		Class72.smethod_20();
	}
}
