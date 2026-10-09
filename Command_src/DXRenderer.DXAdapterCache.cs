using System.Collections.Generic;
using DirectN;

namespace DXRenderer;

public class DXAdapterCache
{
	private static List<DXAdapter> list_0;

	public static IComObject<IDXGIAdapter> ChoosePhysicalAdapter()
	{
		IComObject<IDXGIFactory2> factory = DXGIFunctions.CreateDXGIFactory2();
		IComObject<IDXGIAdapter> comObject = null;
		IEnumerator<IComObject<IDXGIAdapter>> enumerator = factory.EnumAdapters().GetEnumerator();
		while (enumerator.MoveNext())
		{
			IComObject<IDXGIAdapter> current = enumerator.Current;
			IEnumerator<IComObject<IDXGIOutput1>> enumerator2 = current.EnumOutputs().GetEnumerator();
			bool flag = false;
			while (enumerator2.MoveNext())
			{
				flag = enumerator2.Current.GetDesc().AttachedToDesktop;
			}
			uint vendorId = current.GetDesc().VendorId;
			bool flag2 = 4098 == vendorId || 4318 == vendorId;
			if (comObject == null && flag && flag2)
			{
				comObject = current;
			}
		}
		if (comObject == null)
		{
			comObject = factory.GetAdapter1(0);
		}
		return comObject;
	}

	public static DXAdapter FindOrCreateAdapterEntry(IComObject<IDXGIAdapter> adapter)
	{
		DXGI_ADAPTER_DESC desc = adapter.GetDesc();
		for (int i = 0; i < list_0.Count; i++)
		{
			DXGI_ADAPTER_DESC desc2 = list_0[i].Adapter.GetDesc();
			if (desc.AdapterLuid.Equals(desc2.AdapterLuid))
			{
				return list_0[i];
			}
		}
		DXAdapter dXAdapter = smethod_0(adapter);
		list_0.Add(dXAdapter);
		return dXAdapter;
	}

	private static DXAdapter smethod_0(IComObject<IDXGIAdapter> icomObject_0)
	{
		IComObject<ID3D11Device> comObject = null;
		DXAdapter dXAdapter = null;
		string text = "<Bad Adapter>";
		IComObject<ID3D11DeviceContext> deviceContext = null;
		try
		{
			comObject = D3D11Functions.D3D11CreateDevice(icomObject_0.Object, D3D_DRIVER_TYPE.D3D_DRIVER_TYPE_UNKNOWN, D3D11_CREATE_DEVICE_FLAG.D3D11_CREATE_DEVICE_BGRA_SUPPORT, out deviceContext, new D3D_FEATURE_LEVEL[1] { D3D_FEATURE_LEVEL.D3D_FEATURE_LEVEL_11_0 });
			text = icomObject_0.GetDesc().Description;
		}
		catch
		{
			comObject = D3D11Functions.D3D11CreateDevice(null, D3D_DRIVER_TYPE.D3D_DRIVER_TYPE_WARP, D3D11_CREATE_DEVICE_FLAG.D3D11_CREATE_DEVICE_BGRA_SUPPORT, out deviceContext, new D3D_FEATURE_LEVEL[1] { D3D_FEATURE_LEVEL.D3D_FEATURE_LEVEL_11_0 });
			text = "SOFTWARE RENDERER";
		}
		if (comObject != null)
		{
			dXAdapter = new DXAdapter(comObject, deviceContext);
			dXAdapter.Description = text;
			dXAdapter.SetAdapter(icomObject_0);
		}
		return dXAdapter;
	}

	static DXAdapterCache()
	{
		Class72.smethod_20();
		list_0 = new List<DXAdapter>();
	}
}
