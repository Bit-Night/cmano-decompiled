using System.Runtime.InteropServices;
using DirectN;

namespace DXRenderer;

public class ConstantBufferHelper<T>
{
	private DXDevice dxdevice_0;

	private IComObject<ID3D11Buffer> icomObject_0;

	private static object object_0;

	public ConstantBufferHelper(DXDevice device)
	{
		dxdevice_0 = device;
		D3D11_BUFFER_DESC desc = new D3D11_BUFFER_DESC
		{
			ByteWidth = (uint)Marshal.SizeOf<T>(),
			Usage = D3D11_USAGE.D3D11_USAGE_DYNAMIC,
			BindFlags = 4u,
			CPUAccessFlags = 65536u,
			MiscFlags = 0u,
			StructureByteStride = 0u
		};
		icomObject_0 = dxdevice_0.CreateConstantBuffer(desc);
	}

	public void UpdateToDevice<U>(uint index, U buffer)
	{
		dxdevice_0.Context.WithMap(icomObject_0, 0, D3D11_MAP.D3D11_MAP_WRITE_DISCARD, delegate(ref D3D11_MAPPED_SUBRESOURCE mapped, ref U resultBuffer)
		{
			resultBuffer = buffer;
		});
		dxdevice_0.Context.Object.VSSetConstantBuffers(index, 1, new ID3D11Buffer[1] { icomObject_0.Object });
		dxdevice_0.Context.Object.PSSetConstantBuffers(index, 1, new ID3D11Buffer[1] { icomObject_0.Object });
	}

	static ConstantBufferHelper()
	{
		Class72.smethod_20();
	}

	internal static bool smethod_0()
	{
		return object_0 == null;
	}

	internal static object smethod_1()
	{
		return object_0;
	}
}
