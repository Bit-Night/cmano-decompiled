using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using DirectN;

namespace DXRenderer;

public class ShaderManager
{
	private int int_0 = -1;

	private DXAdapter dxadapter_0;

	private List<ShaderManagerEntry> list_0 = new List<ShaderManagerEntry>();

	public int DefaultMeshShader => int_0;

	public ShaderManager(DXAdapter device)
	{
		dxadapter_0 = device;
		int_0 = LoadShader("shaders3D.hlsl", "vs_mesh_main", "ps_mesh_main", forceColor8Bit: true);
	}

	public void SetShader(int handle)
	{
		if (handle >= 0 && handle < list_0.Count)
		{
			ShaderManagerEntry shaderManagerEntry = list_0[handle];
			dxadapter_0.Context.Object.IASetInputLayout(shaderManagerEntry.inputLayout.Object);
			dxadapter_0.Context.Object.PSSetShader(shaderManagerEntry.pixelShader.Object, null, 0);
			dxadapter_0.Context.Object.VSSetShader(shaderManagerEntry.vertexShader.Object, null, 0);
		}
	}

	public int LoadShader(string filename, string vsMain, string psMain, bool forceColor8Bit = false)
	{
		ShaderManagerEntry entry = new ShaderManagerEntry();
		CreateVertexShader(filename, vsMain, ref entry, forceColor8Bit);
		CreatePixelShader(filename, psMain, ref entry);
		list_0.Add(entry);
		return list_0.Count - 1;
	}

	[DllImport("D3DCompiler_47", CharSet = CharSet.Ansi, ExactSpelling = true)]
	public static extern HRESULT D3DReflect(IntPtr pSrcData, IntPtr SrcDataSize, ref Guid pInterface, out IntPtr ppReflector);

	protected void CreateVertexShader(string filename, string vsMain, ref ShaderManagerEntry entry, bool forceColor8Bit)
	{
		IComObject<ID3D11VertexShader> comObject = null;
		IComObject<ID3D10Blob> comObject2 = D3D11Functions.D3DCompileFromFile(filename, vsMain, "vs_5_0");
		comObject = dxadapter_0.Device.CreateVertexShader(comObject2);
		if (comObject == null)
		{
			return;
		}
		Guid pInterface = new Guid(2371054753u, 3274, 18774, 168, 55, 120, 105, 99, 117, 85, 132);
		IntPtr ppReflector = IntPtr.Zero;
		ID3D11ShaderReflection iD3D11ShaderReflection = null;
		if (D3DReflect(comObject2.Object.GetBufferPointer(), comObject2.Object.GetBufferSize(), ref pInterface, out ppReflector).IsError)
		{
			return;
		}
		iD3D11ShaderReflection = (ID3D11ShaderReflection)Marshal.GetObjectForIUnknown(ppReflector);
		iD3D11ShaderReflection.GetDesc(out var pDesc);
		List<D3D11_INPUT_ELEMENT_DESC> list = new List<D3D11_INPUT_ELEMENT_DESC>();
		for (uint num = 0u; num < pDesc.InputParameters; num++)
		{
			iD3D11ShaderReflection.GetInputParameterDesc(num, out var pDesc2);
			D3D11_INPUT_ELEMENT_DESC item = new D3D11_INPUT_ELEMENT_DESC
			{
				SemanticName = pDesc2.SemanticName,
				SemanticIndex = pDesc2.SemanticIndex,
				InputSlot = 0u,
				AlignedByteOffset = uint.MaxValue,
				InputSlotClass = D3D11_INPUT_CLASSIFICATION.D3D11_INPUT_PER_VERTEX_DATA,
				InstanceDataStepRate = 0u
			};
			if (forceColor8Bit && pDesc2.SemanticName == "COLOR")
			{
				item.Format = DXGI_FORMAT.DXGI_FORMAT_R8G8B8A8_UNORM;
			}
			else if (pDesc2.Mask == 1)
			{
				if (pDesc2.ComponentType == D3D_REGISTER_COMPONENT_TYPE.D3D_REGISTER_COMPONENT_UINT32)
				{
					item.Format = DXGI_FORMAT.DXGI_FORMAT_R32_UINT;
				}
				else if (pDesc2.ComponentType == D3D_REGISTER_COMPONENT_TYPE.D3D_REGISTER_COMPONENT_SINT32)
				{
					item.Format = DXGI_FORMAT.DXGI_FORMAT_R32_SINT;
				}
				else if (pDesc2.ComponentType == D3D_REGISTER_COMPONENT_TYPE.D3D_REGISTER_COMPONENT_FLOAT32)
				{
					item.Format = DXGI_FORMAT.DXGI_FORMAT_R32_FLOAT;
				}
			}
			else if (pDesc2.Mask > 3)
			{
				if (pDesc2.Mask <= 7)
				{
					if (pDesc2.ComponentType == D3D_REGISTER_COMPONENT_TYPE.D3D_REGISTER_COMPONENT_UINT32)
					{
						item.Format = DXGI_FORMAT.DXGI_FORMAT_R32G32B32_UINT;
					}
					else if (pDesc2.ComponentType == D3D_REGISTER_COMPONENT_TYPE.D3D_REGISTER_COMPONENT_SINT32)
					{
						item.Format = DXGI_FORMAT.DXGI_FORMAT_R32G32B32_SINT;
					}
					else if (pDesc2.ComponentType == D3D_REGISTER_COMPONENT_TYPE.D3D_REGISTER_COMPONENT_FLOAT32)
					{
						item.Format = DXGI_FORMAT.DXGI_FORMAT_R32G32B32_FLOAT;
					}
				}
				else if (pDesc2.Mask <= 15)
				{
					if (pDesc2.ComponentType == D3D_REGISTER_COMPONENT_TYPE.D3D_REGISTER_COMPONENT_UINT32)
					{
						item.Format = DXGI_FORMAT.DXGI_FORMAT_R32G32B32A32_UINT;
					}
					else if (pDesc2.ComponentType == D3D_REGISTER_COMPONENT_TYPE.D3D_REGISTER_COMPONENT_SINT32)
					{
						item.Format = DXGI_FORMAT.DXGI_FORMAT_R32G32B32A32_SINT;
					}
					else if (pDesc2.ComponentType == D3D_REGISTER_COMPONENT_TYPE.D3D_REGISTER_COMPONENT_FLOAT32)
					{
						item.Format = DXGI_FORMAT.DXGI_FORMAT_R32G32B32A32_FLOAT;
					}
				}
			}
			else if (pDesc2.ComponentType == D3D_REGISTER_COMPONENT_TYPE.D3D_REGISTER_COMPONENT_UINT32)
			{
				item.Format = DXGI_FORMAT.DXGI_FORMAT_R32G32_UINT;
			}
			else if (pDesc2.ComponentType == D3D_REGISTER_COMPONENT_TYPE.D3D_REGISTER_COMPONENT_SINT32)
			{
				item.Format = DXGI_FORMAT.DXGI_FORMAT_R32G32_SINT;
			}
			else if (pDesc2.ComponentType == D3D_REGISTER_COMPONENT_TYPE.D3D_REGISTER_COMPONENT_FLOAT32)
			{
				item.Format = DXGI_FORMAT.DXGI_FORMAT_R32G32_FLOAT;
			}
			list.Add(item);
		}
		Marshal.ReleaseComObject(iD3D11ShaderReflection);
		D3D11_INPUT_ELEMENT_DESC[] inputElements = list.ToArray();
		entry.inputLayout = dxadapter_0.Device.CreateInputLayout(inputElements, comObject2);
		entry.vertexShader = comObject;
	}

	protected void CreatePixelShader(string filename, string psMain, ref ShaderManagerEntry entry)
	{
		IComObject<ID3D10Blob> blob = D3D11Functions.D3DCompileFromFile(filename, psMain, "ps_5_0");
		IComObject<ID3D11PixelShader> comObject = dxadapter_0.Device.CreatePixelShader(blob);
		if (comObject == null)
		{
			throw new ShaderCreationException();
		}
		entry.pixelShader = comObject;
	}

	static ShaderManager()
	{
		Class72.smethod_20();
	}
}
