using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using Command_Core;
using CSMaterial;
using Cysharp.Text;
using DirectN;
using ExWorldWind;
using MapReduce.NET.CollectionsB;

namespace DXRenderer;

public class Main : Main3DBaseClass
{
	private struct Struct38
	{
		internal Matrix4x4 matrix4x4_0;

		internal float float_0;

		internal float float_1;

		internal float float_2;

		internal float float_3;

		internal uint uint_0;

		internal uint Row;

		internal int int_0;

		internal float float_4;
	}

	private struct Struct39
	{
		internal uint uint_0;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		internal float[] Padding;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
		internal float[] float_0;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
		internal float[] float_1;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
		internal float[] float_2;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
		internal float[] float_3;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
		internal uint[] uint_1;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
		internal uint[] Row;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
		internal int[] int_0;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
		internal float[] lreyQaRqbOC;
	}

	internal enum MeshRebuildingStatus
	{
		idle,
		processing_async,
		waiting_apply,
		applying
	}

	public struct SegmentVect
	{
		public Vector3 A;

		public Vector3 B;

		public int int_0;

		public SegmentVect(Vector3 _A, Vector3 _B, int _ARGBColor)
		{
			//IL_0003: Unknown result type (might be due to invalid IL or missing references)
			//IL_0004: Unknown result type (might be due to invalid IL or missing references)
			//IL_000a: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			A = _A;
			B = _B;
			int_0 = _ARGBColor;
		}

		static SegmentVect()
		{
			Class72.smethod_20();
		}
	}

	public struct Segment_Points
	{
		public Point A;

		public Point B;

		public Segment_Points(Point _A, Point _B)
		{
			A = _A;
			B = _B;
		}

		static Segment_Points()
		{
			Class72.smethod_20();
		}
	}

	public struct BatchDrawKey
	{
		public Color color;

		public int thickness;

		public BatchDrawKey(Color _color, int _thickness)
		{
			color = _color;
			thickness = _thickness;
		}

		static BatchDrawKey()
		{
			Class72.smethod_20();
		}
	}

	public static Main Instance;

	internal Interface0 RenderEventHandler;

	internal const float PI = (float)Math.PI;

	public const float EARTH_MEAN_RADIUS = 6378137f;

	private Vector4 vector4_0 = new Vector4(0f, 0f, 0f, 1f);

	private Vector4 vector4_1 = new Vector4(1f, 0f, 0f, 1f);

	private Vector4 vector4_2 = new Vector4(0f, 0f, 1f, 1f);

	public Borders Borders = Borders.Newer;

	private uint mabygpqLth1;

	private uint uint_0;

	public static bool AggressiveTileManagement;

	public static string TopLevelWritableRoot;

	private readonly int int_0;

	private readonly int int_1;

	private readonly int int_2;

	private readonly int int_3;

	public int ScreenWidth;

	public int ScreenHeight;

	public bool Ready;

	public bool Drawing;

	private D2D1_RENDER_TARGET_PROPERTIES d2D1_RENDER_TARGET_PROPERTIES_0;

	private readonly IComObject<IWICImagingFactory> icomObject_0;

	private readonly FastDictionary<string, ID2D1Bitmap> fastDictionary_0;

	private ID3DUserDefinedAnnotation id3DUserDefinedAnnotation_0;

	private IComObject<ID2D1Factory1> icomObject_1;

	public IComObject<ID3D11Buffer> ConstantBuffer;

	public IComObject<ID3D11Buffer> ConstantBufferArray;

	private int int_4 = -1;

	private int int_5 = -1;

	private int int_6 = -1;

	private int int_7 = -1;

	private int int_8 = -1;

	private int int_9 = -1;

	private uint uint_1;

	private uint uint_2;

	private IComObject<ID2D1RenderTarget> icomObject_2;

	private ID2D1RenderTarget id2D1RenderTarget_0;

	private IComObject<IDWriteFactory> icomObject_3;

	public static DrawParameters WorldDrawParameters;

	public static DrawParameters BackgroundWorldDrawParameters;

	public static DrawParameters ForegroundWorldDrawParameters_DayNight;

	public static DrawParameters ForegroundWorldDrawParameters_Stamen;

	public static DrawParameters OcclusionPlaneDrawParameters;

	private readonly OrderedDictionary orderedDictionary_0;

	private readonly Dictionary<string, DrawParameters> dictionary_0;

	private readonly float[] float_0 = new float[4];

	private readonly IComObject<ID3D11BlendState> icomObject_4;

	private uint uint_3;

	private readonly IComObject<ID3D11BlendState> icomObject_5;

	private readonly bool bool_0;

	internal uint TesselationLevel = 10u;

	private readonly float float_1 = (float)Math.PI / 4f;

	private Matrix4x4 matrix4x4_0;

	private Matrix4x4 matrix4x4_1;

	private readonly Dictionary<int, (IComObject<ID2D1SolidColorBrush>, ID2D1SolidColorBrush)> dictionary_1;

	public RenderState RenderState = new RenderState
	{
		BingMap = false,
		SentinelMap = false,
		ReliefBathymetryMap = false,
		BMNGMap = false,
		bool_0 = false,
		LandCoverOverlay = false,
		StamenTerrainOverlay = false,
		StamenLinesOverlay = false,
		PlacenamesOverlay = false,
		BaseEarth = false
	};

	private readonly IComObject<ID3D11BlendState> icomObject_6;

	internal bool EnableTileLoadingIndicator;

	internal uint Frame;

	public bool Initialized;

	public bool Resizing;

	public readonly DrawArgs DrawArgs = DrawArgs.Instance;

	private readonly LatLongGrid latLongGrid_0;

	private readonly Scale scale_0;

	private readonly ID2D1StrokeStyle id2D1StrokeStyle_0;

	private readonly ID2D1StrokeStyle id2D1StrokeStyle_1;

	private readonly Dictionary<Color, ID2D1LinearGradientBrush> dictionary_2 = new Dictionary<Color, ID2D1LinearGradientBrush>();

	private object object_0 = new object();

	private MeshRebuildingStatus meshRebuildingStatus_0;

	private Mesh mesh_0;

	private ushort? nullable_0;

	private Utf16ValueStringBuilder utf16ValueStringBuilder_0 = ZString.CreateStringBuilder();

	private readonly float[] float_2 = new float[4];

	private List<KeyValuePair<string, DrawParameters>> list_0 = new List<KeyValuePair<string, DrawParameters>>();

	private List<DrawParameters> list_1 = new List<DrawParameters>();

	private Dictionary<(string, float), IComObject<IDWriteTextFormat>> dictionary_3 = new Dictionary<(string, float), IComObject<IDWriteTextFormat>>();

	private Dictionary<(IComObject<IDWriteTextFormat>, string), IComObject<IDWriteTextLayout>> dictionary_4 = new Dictionary<(IComObject<IDWriteTextFormat>, string), IComObject<IDWriteTextLayout>>();

	private LRUCache<(string, float), Rectangle> lrucache_0 = new LRUCache<(string, float), Rectangle>(3, disposeDiscardedObjects: true);

	private IComObject<ID3D11Texture2D> icomObject_7;

	private IComObject<ID3D11ShaderResourceView> icomObject_8;

	private ID3D11Texture2D id3D11Texture2D_0;

	private ID3D11Buffer id3D11Buffer_0;

	private ID3D11Buffer id3D11Buffer_1;

	private D2D_POINT_2F[] d2D_POINT_2F_0 = Array.Empty<D2D_POINT_2F>();

	private List<ID2D1Geometry> list_2 = new List<ID2D1Geometry>();

	public IComObject<ID3D11Device> Device => DXDevice.Device;

	public IComObject<ID3D11DeviceContext> Context => DXDevice.Context;

	public ShaderManager ShaderManager => DXDevice.ShaderManager;

	internal MeshRebuildingStatus meshRebuildingStatus_readOnly => meshRebuildingStatus_0;

	public Main(string topLevelWriteableRoot, Control control, int clientRectangleTopMargin, int clientRectangleBottomMargin)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0289: Unknown result type (might be due to invalid IL or missing references)
		//IL_028e: Unknown result type (might be due to invalid IL or missing references)
		Instance = this;
		TopLevelWritableRoot = topLevelWriteableRoot;
		int_0 = clientRectangleTopMargin;
		int_1 = clientRectangleBottomMargin;
		int_3 = int_0;
		ScreenWidth = control.ClientRectangle.Width;
		ScreenHeight = control.ClientRectangle.Height - int_0 - int_1;
		orderedDictionary_0 = new OrderedDictionary();
		dictionary_1 = new Dictionary<int, (IComObject<ID2D1SolidColorBrush>, ID2D1SolidColorBrush)>();
		dictionary_0 = new Dictionary<string, DrawParameters>();
		try
		{
			Init(RenderState);
		}
		catch (Exception ex)
		{
			ex?.Data.Add("Error at 447488: ", ex.Message);
			throw ex;
		}
		try
		{
			Ready = method_0(control);
		}
		catch (Exception ex2)
		{
			ex2?.Data.Add("Error at 447494: ", ex2.Message);
			throw ex2;
		}
		try
		{
			icomObject_0 = new ComObject<IWICImagingFactory>((IWICImagingFactory)new WicImagingFactory());
			fastDictionary_0 = new FastDictionary<string, ID2D1Bitmap>();
			matrix4x4_1 = method_12();
		}
		catch (Exception ex3)
		{
			ex3?.Data.Add("Error at 447517: ", ex3.Message);
			throw ex3;
		}
		try
		{
			WorldDrawParameters.Projection = Projection.Globe;
			WorldDrawParameters.Topology = D3D_PRIMITIVE_TOPOLOGY.D3D_PRIMITIVE_TOPOLOGY_TRIANGLELIST;
			WorldDrawParameters.Disposable = false;
			OcclusionPlaneDrawParameters = WorldDrawParameters;
			OcclusionPlaneDrawParameters.Projection = Projection.Globe;
			OcclusionPlaneDrawParameters.Topology = D3D_PRIMITIVE_TOPOLOGY.D3D_PRIMITIVE_TOPOLOGY_TRIANGLELIST;
			OcclusionPlaneDrawParameters.Disposable = false;
			BackgroundWorldDrawParameters = WorldDrawParameters;
			BackgroundWorldDrawParameters.ShaderResourceView = DXDevice.TileCache.BuildTexture(TopLevelWritableRoot + "/WW/Data/Earth/BmngBathy/world.topo.bathy.200407.jpg", synchronous: true);
			BackgroundWorldDrawParameters.Layer = Layer.BaseEarth;
			ForegroundWorldDrawParameters_DayNight.Projection = Projection.Globe;
			ForegroundWorldDrawParameters_DayNight.Topology = D3D_PRIMITIVE_TOPOLOGY.D3D_PRIMITIVE_TOPOLOGY_TRIANGLELIST;
			ForegroundWorldDrawParameters_DayNight.Disposable = false;
			ForegroundWorldDrawParameters_DayNight.Layer = Layer.DayNight;
			ForegroundWorldDrawParameters_Stamen.Projection = Projection.Globe;
			ForegroundWorldDrawParameters_Stamen.Topology = D3D_PRIMITIVE_TOPOLOGY.D3D_PRIMITIVE_TOPOLOGY_TRIANGLELIST;
			ForegroundWorldDrawParameters_Stamen.Disposable = false;
			ForegroundWorldDrawParameters_Stamen.Layer = Layer.StamenLabels;
		}
		catch (Exception ex4)
		{
			ex4?.Data.Add("Error at 447544: ", ex4.Message);
			throw ex4;
		}
		D3D11_BLEND_DESC desc = new D3D11_BLEND_DESC
		{
			AlphaToCoverageEnable = false,
			IndependentBlendEnable = false
		};
		try
		{
			desc.RenderTarget = new D3D11_RENDER_TARGET_BLEND_DESC[8];
			desc.RenderTarget[0] = new D3D11_RENDER_TARGET_BLEND_DESC
			{
				BlendEnable = true,
				SrcBlend = D3D11_BLEND.D3D11_BLEND_SRC_ALPHA,
				DestBlend = D3D11_BLEND.D3D11_BLEND_SRC_ALPHA,
				BlendOp = D3D11_BLEND_OP.D3D11_BLEND_OP_ADD,
				SrcBlendAlpha = D3D11_BLEND.D3D11_BLEND_ONE,
				DestBlendAlpha = D3D11_BLEND.D3D11_BLEND_ZERO,
				BlendOpAlpha = D3D11_BLEND_OP.D3D11_BLEND_OP_ADD,
				RenderTargetWriteMask = 15
			};
			icomObject_4 = Device.CreateBlendState(desc);
		}
		catch (Exception ex5)
		{
			ex5?.Data.Add("Error at 447572: ", ex5.Message);
			throw ex5;
		}
		try
		{
			desc.RenderTarget[0] = new D3D11_RENDER_TARGET_BLEND_DESC
			{
				BlendEnable = true,
				SrcBlend = D3D11_BLEND.D3D11_BLEND_SRC_ALPHA,
				DestBlend = D3D11_BLEND.D3D11_BLEND_DEST_ALPHA,
				BlendOp = D3D11_BLEND_OP.D3D11_BLEND_OP_ADD,
				SrcBlendAlpha = D3D11_BLEND.D3D11_BLEND_ONE,
				DestBlendAlpha = D3D11_BLEND.D3D11_BLEND_ONE,
				BlendOpAlpha = D3D11_BLEND_OP.D3D11_BLEND_OP_MAX,
				RenderTargetWriteMask = 15
			};
			icomObject_6 = Device.CreateBlendState(desc);
			D3D11_RASTERIZER_DESC desc2 = new D3D11_RASTERIZER_DESC
			{
				FillMode = D3D11_FILL_MODE.D3D11_FILL_SOLID,
				CullMode = D3D11_CULL_MODE.D3D11_CULL_BACK,
				DepthBias = 0,
				DepthBiasClamp = 0f,
				SlopeScaledDepthBias = -1f
			};
			uint_0 = DXDevice.CreateRasterizerState(desc2);
			D3D11_DEPTH_STENCIL_DESC desc3 = new D3D11_DEPTH_STENCIL_DESC
			{
				DepthEnable = true,
				DepthWriteMask = D3D11_DEPTH_WRITE_MASK.D3D11_DEPTH_WRITE_MASK_ZERO,
				DepthFunc = D3D11_COMPARISON_FUNC.D3D11_COMPARISON_GREATER,
				StencilEnable = false
			};
			mabygpqLth1 = DXDevice.CreateDepthStencilState(desc3);
		}
		catch (Exception ex6)
		{
			ex6?.Data.Add("Error at 447615: ", ex6.Message);
			throw ex6;
		}
		try
		{
			D3D11_DEPTH_STENCIL_DESC desc4 = new D3D11_DEPTH_STENCIL_DESC
			{
				DepthFunc = D3D11_COMPARISON_FUNC.D3D11_COMPARISON_ALWAYS
			};
			uint_3 = DXDevice.CreateDepthStencilState(desc4);
			desc.RenderTarget[0] = new D3D11_RENDER_TARGET_BLEND_DESC
			{
				BlendEnable = true,
				SrcBlend = D3D11_BLEND.D3D11_BLEND_SRC_ALPHA,
				DestBlend = D3D11_BLEND.D3D11_BLEND_INV_SRC_ALPHA,
				BlendOp = D3D11_BLEND_OP.D3D11_BLEND_OP_ADD,
				SrcBlendAlpha = D3D11_BLEND.D3D11_BLEND_ONE,
				DestBlendAlpha = D3D11_BLEND.D3D11_BLEND_ONE,
				BlendOpAlpha = D3D11_BLEND_OP.D3D11_BLEND_OP_MAX,
				RenderTargetWriteMask = 15
			};
			icomObject_5 = Device.CreateBlendState(desc);
		}
		catch (Exception ex7)
		{
			ex7?.Data.Add("Error at 447647: ", ex7.Message);
			throw ex7;
		}
		try
		{
			D2D1_STROKE_STYLE_PROPERTIES strokeStyleProperties = new D2D1_STROKE_STYLE_PROPERTIES
			{
				startCap = D2D1_CAP_STYLE.D2D1_CAP_STYLE_FLAT,
				endCap = D2D1_CAP_STYLE.D2D1_CAP_STYLE_FLAT,
				dashCap = D2D1_CAP_STYLE.D2D1_CAP_STYLE_FLAT,
				lineJoin = D2D1_LINE_JOIN.D2D1_LINE_JOIN_MITER,
				miterLimit = 0f,
				dashStyle = D2D1_DASH_STYLE.D2D1_DASH_STYLE_SOLID,
				dashOffset = 0f
			};
			_ = icomObject_1.Object.CreateStrokeStyle(ref strokeStyleProperties, null, 0, out id2D1StrokeStyle_0).IsOk;
			strokeStyleProperties.dashStyle = D2D1_DASH_STYLE.D2D1_DASH_STYLE_DASH;
			_ = icomObject_1.Object.CreateStrokeStyle(ref strokeStyleProperties, null, 0, out id2D1StrokeStyle_1).IsOk;
			latLongGrid_0 = new LatLongGrid();
			scale_0 = new Scale();
		}
		catch (Exception ex8)
		{
			ex8?.Data.Add("Error at 447685: ", ex8.Message);
			throw ex8;
		}
		Initialized = true;
	}

	private bool method_0(Control control_0)
	{
		if (Device == null)
		{
			return false;
		}
		id3DUserDefinedAnnotation_0 = (ID3DUserDefinedAnnotation)Context.Object;
		try
		{
			DXDevice.CreateSwapChainAndBackBuffers(control_0);
		}
		catch (Exception ex)
		{
			ex?.Data.Add("Error at 961718: ", ex.Message);
			throw ex;
		}
		D3D11_VIEWPORT d3D11_VIEWPORT = new D3D11_VIEWPORT
		{
			Width = ScreenWidth,
			Height = ScreenHeight,
			MinDepth = 0f,
			MaxDepth = 1f,
			TopLeftX = int_2,
			TopLeftY = int_3
		};
		try
		{
			Context.Object.RSSetViewports(1, new D3D11_VIEWPORT[1] { d3D11_VIEWPORT });
		}
		catch (Exception ex2)
		{
			ex2?.Data.Add("Error at 961736: ", ex2.Message);
			throw ex2;
		}
		try
		{
			if (!method_1())
			{
				return false;
			}
		}
		catch (Exception ex3)
		{
			ex3?.Data.Add("Error at 961749: ", ex3.Message);
			throw ex3;
		}
		try
		{
			if (!method_7())
			{
				return false;
			}
		}
		catch (Exception ex4)
		{
			ex4?.Data.Add("Error at 961762: ", ex4.Message);
			throw ex4;
		}
		try
		{
			if (!method_8())
			{
				return false;
			}
		}
		catch (Exception ex5)
		{
			ex5?.Data.Add("Error at 961775: ", ex5.Message);
			throw ex5;
		}
		try
		{
			if (!method_4())
			{
				return false;
			}
		}
		catch (Exception ex6)
		{
			ex6?.Data.Add("Error at 961788: ", ex6.Message);
			throw ex6;
		}
		try
		{
			if (!method_9())
			{
				return false;
			}
		}
		catch (Exception ex7)
		{
			ex7?.Data.Add("Error at 961800: ", ex7.Message);
			throw ex7;
		}
		try
		{
			icomObject_3 = DWriteFunctions.DWriteCreateFactory();
		}
		catch (Exception ex8)
		{
			ex8?.Data.Add("Error at 961809: ", ex8.Message);
			throw ex8;
		}
		if (icomObject_3 != null)
		{
			try
			{
				icomObject_1 = D2D1Functions.D2D1CreateFactory1(D2D1_FACTORY_TYPE.D2D1_FACTORY_TYPE_MULTI_THREADED, default(D2D1_FACTORY_OPTIONS));
			}
			catch (Exception ex9)
			{
				ex9?.Data.Add("Error at 961: ", ex9.Message);
				throw ex9;
			}
			if (icomObject_1 != null)
			{
				d2D1_RENDER_TARGET_PROPERTIES_0 = new D2D1_RENDER_TARGET_PROPERTIES
				{
					pixelFormat = new D2D1_PIXEL_FORMAT
					{
						alphaMode = D2D1_ALPHA_MODE.D2D1_ALPHA_MODE_PREMULTIPLIED
					}
				};
				IComObject<IDXGISurface> buffer;
				try
				{
					buffer = DXDevice.SwapChain.GetBuffer<IDXGISurface>(0u);
				}
				catch (Exception ex10)
				{
					ex10?.Data.Add("Error at 961864: ", ex10.Message);
					throw ex10;
				}
				if (buffer != null)
				{
					try
					{
						icomObject_2 = icomObject_1.CreateDxgiSurfaceRenderTarget(buffer, d2D1_RENDER_TARGET_PROPERTIES_0);
						id2D1RenderTarget_0 = icomObject_2.Object;
						buffer.Dispose();
					}
					catch (Exception ex11)
					{
						ex11?.Data.Add("Error at 961884: ", ex11.Message);
						throw ex11;
					}
					if (icomObject_2 != null)
					{
						return true;
					}
					return false;
				}
				return false;
			}
			return false;
		}
		return false;
	}

	public void OnResize(Control control)
	{
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		Resizing = true;
		ScreenWidth = control.ClientRectangle.Width;
		ScreenHeight = control.ClientRectangle.Height - int_0 - int_1;
		icomObject_2.Dispose();
		DXDevice.OnResize(control, int_2, int_3, int_0, int_1);
		d2D1_RENDER_TARGET_PROPERTIES_0 = new D2D1_RENDER_TARGET_PROPERTIES
		{
			pixelFormat = new D2D1_PIXEL_FORMAT
			{
				alphaMode = D2D1_ALPHA_MODE.D2D1_ALPHA_MODE_PREMULTIPLIED
			}
		};
		IComObject<IDXGISurface> buffer = DXDevice.SwapChain.GetBuffer<IDXGISurface>(0u);
		if (buffer != null)
		{
			icomObject_2 = icomObject_1.CreateDxgiSurfaceRenderTarget(buffer, d2D1_RENDER_TARGET_PROPERTIES_0);
			id2D1RenderTarget_0 = icomObject_2.Object;
			buffer.Dispose();
			if (icomObject_2 != null)
			{
				matrix4x4_1 = method_12();
				Resizing = false;
			}
		}
	}

	private bool method_1()
	{
		D3D11_RASTERIZER_DESC desc = new D3D11_RASTERIZER_DESC
		{
			FillMode = D3D11_FILL_MODE.D3D11_FILL_SOLID,
			CullMode = D3D11_CULL_MODE.D3D11_CULL_BACK
		};
		uint_1 = DXDevice.CreateRasterizerState(desc);
		desc.FillMode = D3D11_FILL_MODE.D3D11_FILL_WIREFRAME;
		uint_2 = DXDevice.CreateRasterizerState(desc);
		return true;
	}

	public void requestMeshRebuild(bool show3DTerrain, ushort verticalScaling)
	{
		if (!show3DTerrain)
		{
			verticalScaling = 0;
		}
		lock (object_0)
		{
			if (meshRebuildingStatus_0 != MeshRebuildingStatus.idle)
			{
				nullable_0 = verticalScaling;
				return;
			}
			meshRebuildingStatus_0 = MeshRebuildingStatus.processing_async;
			nullable_0 = null;
			new Task(delegate
			{
				mesh_0 = method_5(0f, verticalScaling);
				lock (object_0)
				{
					if (meshRebuildingStatus_0 == MeshRebuildingStatus.processing_async)
					{
						meshRebuildingStatus_0 = MeshRebuildingStatus.waiting_apply;
					}
					else
					{
						Debugger.Break();
					}
				}
			}).Start();
		}
	}

	private bool method_2()
	{
		bool flag = false;
		lock (object_0)
		{
			if (meshRebuildingStatus_0 == MeshRebuildingStatus.waiting_apply)
			{
				flag = true;
				meshRebuildingStatus_0 = MeshRebuildingStatus.applying;
			}
		}
		if (flag)
		{
			bool result = method_6(mesh_0, ref WorldDrawParameters);
			BackgroundWorldDrawParameters.VertexBuffer = WorldDrawParameters.VertexBuffer;
			BackgroundWorldDrawParameters.IndexBuffer = WorldDrawParameters.IndexBuffer;
			BackgroundWorldDrawParameters.NumberIndices = WorldDrawParameters.NumberIndices;
			for (int num = orderedDictionary_0.Count - 1; num >= 0; num--)
			{
				List<DrawParameters> list = (List<DrawParameters>)orderedDictionary_0[num];
				for (int num2 = list.Count - 1; num2 >= 0; num2--)
				{
					DrawParameters value = list[num2];
					value.VertexBuffer = WorldDrawParameters.VertexBuffer;
					value.IndexBuffer = WorldDrawParameters.IndexBuffer;
					value.NumberIndices = WorldDrawParameters.NumberIndices;
					list[num2] = value;
				}
			}
			lock (object_0)
			{
				if (meshRebuildingStatus_0 == MeshRebuildingStatus.applying)
				{
					meshRebuildingStatus_0 = MeshRebuildingStatus.idle;
					if (nullable_0.HasValue)
					{
						requestMeshRebuild(nullable_0 > 0, nullable_0.Value);
					}
				}
				else
				{
					Debugger.Break();
				}
			}
			return result;
		}
		return false;
	}

	private bool method_3()
	{
		TesselationLevel++;
		return method_4();
	}

	private bool method_4()
	{
		Mesh mesh_ = method_5(0f, 0);
		bool num = method_6(mesh_, ref WorldDrawParameters);
		Mesh mesh_2 = method_5(0f, 0);
		bool flag = method_6(mesh_2, ref ForegroundWorldDrawParameters_Stamen);
		Mesh mesh_3 = method_5(1000f, 0);
		bool flag2 = method_6(mesh_3, ref ForegroundWorldDrawParameters_DayNight);
		bool flag3 = method_6(method_27(), ref OcclusionPlaneDrawParameters);
		return num && flag && flag2 && flag3;
	}

	internal double NormalizeLatitude(double X)
	{
		X = (X + 90.0) % 360.0 - 90.0;
		if (!(X > 90.0))
		{
			if (!(X < -90.0))
			{
				return X;
			}
			return -180.0 - X;
		}
		return 180.0 - X;
	}

	internal double NormalizeLongitude(double X)
	{
		if (X > 180.0)
		{
			return X - 360.0;
		}
		if (X <= -180.0)
		{
			return X + 360.0;
		}
		return X;
	}

	private Mesh method_5(float float_3, ushort ushort_0)
	{
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		uint num = (uint)Math.Pow(2.0, TesselationLevel);
		if (num < 2)
		{
			return default(Mesh);
		}
		uint uint_0 = num * 2;
		uint num2 = 2 + (num - 1) * (uint_0 + 1);
		float num3 = 6378137f + float_3;
		float float_4 = (float)Math.PI / (float)num;
		float float_5 = (float)Math.PI * 2f / (float)uint_0;
		Vertex vertex = new Vertex(new Vector3(0f, num3, 0f), vector4_2, new Vector2(0.5f, 0f));
		Vertex vertex2 = new Vertex(new Vector3(0f, 0f - num3, 0f), vector4_1, new Vector2(0.5f, 1f));
		Vertex[] vertex_0 = new Vertex[num2];
		uint num4 = 0u;
		Vertex[] array = vertex_0;
		num4 = 1u;
		array[0] = vertex;
		double double_0 = 180.0 / Math.PI;
		Parallel.For(1L, num, delegate(long i)
		{
			//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_0100: Unknown result type (might be due to invalid IL or missing references)
			uint num14 = (uint)(1 + (int)(i - 1L) * (int)(uint_0 + 1));
			float num15 = (float)i * float_4;
			Vector3 p = default(Vector3);
			for (uint num16 = 0u; num16 <= uint_0; num16++)
			{
				float num17 = (float)num16 * float_5;
				float num18 = 6378137f;
				if (ushort_0 > 0)
				{
					double theLon = NormalizeLongitude(-180.0 + (double)num17 * double_0);
					double theLat = NormalizeLatitude(90.0 - (double)num15 * double_0);
					num18 += (float)(ushort_0 * Terrain.GetElevationForGlobeDeformation(theLat, theLon));
				}
				((Vector3)(ref p))..ctor(num18 * (float)(Math.Sin(num15) * Math.Cos(num17 + (float)Math.PI / 2f)), num18 * (float)Math.Cos(num15), num18 * (float)(Math.Sin(num15) * Math.Sin(num17 + (float)Math.PI / 2f)));
				Vertex vertex3 = new Vertex(p, vector4_0, new Vector2(num17 / ((float)Math.PI * 2f), num15 / (float)Math.PI));
				uint num19 = num14 + num16;
				vertex_0[num19] = vertex3;
			}
		});
		uint num5 = 1 + (num - 2) * (uint_0 + 1) + uint_0 + 1;
		vertex_0[num5] = vertex2;
		uint[] array2 = new uint[((num - 2) * uint_0 * 2 + uint_0 * 2) * 3];
		uint num6 = 0u;
		for (uint num7 = 1u; num7 <= uint_0; num7++)
		{
			array2[num6++] = 0u;
			array2[num6++] = num7 + 1;
			array2[num6++] = num7;
		}
		uint num8 = 1u;
		uint num9 = uint_0 + 1;
		for (uint num10 = 0u; num10 < num - 2; num10++)
		{
			for (uint num11 = 0u; num11 < uint_0; num11++)
			{
				array2[num6++] = num8 + num10 * num9 + num11;
				array2[num6++] = num8 + num10 * num9 + num11 + 1;
				array2[num6++] = num8 + (num10 + 1) * num9 + num11;
				array2[num6++] = num8 + (num10 + 1) * num9 + num11;
				array2[num6++] = num8 + num10 * num9 + num11 + 1;
				array2[num6++] = num8 + (num10 + 1) * num9 + num11 + 1;
			}
		}
		uint num12 = num4 - 1;
		num8 = num12 - num9;
		for (uint num13 = 0u; num13 < uint_0; num13++)
		{
			array2[num6++] = num12;
			array2[num6++] = num8 + num13;
			array2[num6++] = num8 + num13 + 1;
		}
		return new Mesh
		{
			vertices = vertex_0,
			indices = array2
		};
	}

	private bool method_6(Mesh mesh_1, ref DrawParameters drawParameters_0)
	{
		int num = 2;
		if (drawParameters_0.Topology == D3D_PRIMITIVE_TOPOLOGY.D3D_PRIMITIVE_TOPOLOGY_TRIANGLELIST)
		{
			num = 3;
		}
		int result;
		if (mesh_1.vertices == null)
		{
			result = 0;
		}
		else if (mesh_1.vertices.Length < num)
		{
			result = 0;
		}
		else if (mesh_1.indices != null)
		{
			if (mesh_1.indices.Length >= num)
			{
				D3D11_BUFFER_DESC desc = new D3D11_BUFFER_DESC
				{
					ByteWidth = (uint)mesh_1.vertices.SizeOf(),
					Usage = D3D11_USAGE.D3D11_USAGE_IMMUTABLE,
					BindFlags = 1u,
					CPUAccessFlags = 0u,
					MiscFlags = 0u,
					StructureByteStride = 0u
				};
				GCHandle gCHandle = GCHandle.Alloc(mesh_1.vertices, GCHandleType.Pinned);
				D3D11_SUBRESOURCE_DATA value = new D3D11_SUBRESOURCE_DATA
				{
					pSysMem = gCHandle.AddrOfPinnedObject(),
					SysMemPitch = 0u,
					SysMemSlicePitch = 0u
				};
				drawParameters_0.VertexBuffer = Device.CreateBuffer(desc, value);
				gCHandle.Free();
				if (drawParameters_0.VertexBuffer != null)
				{
					D3D11_BUFFER_DESC desc2 = new D3D11_BUFFER_DESC
					{
						ByteWidth = (uint)mesh_1.indices.SizeOf(),
						Usage = D3D11_USAGE.D3D11_USAGE_IMMUTABLE,
						BindFlags = 2u,
						CPUAccessFlags = 0u,
						MiscFlags = 0u,
						StructureByteStride = 0u
					};
					gCHandle = GCHandle.Alloc(mesh_1.indices, GCHandleType.Pinned);
					D3D11_SUBRESOURCE_DATA value2 = new D3D11_SUBRESOURCE_DATA
					{
						pSysMem = gCHandle.AddrOfPinnedObject(),
						SysMemPitch = 0u,
						SysMemSlicePitch = 0u
					};
					drawParameters_0.IndexBuffer = Device.CreateBuffer(desc2, value2);
					gCHandle.Free();
					drawParameters_0.NumberIndices = (uint)mesh_1.indices.Length;
					if (drawParameters_0.IndexBuffer == null)
					{
						return false;
					}
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

	private bool method_7()
	{
		D3D11_BUFFER_DESC desc = new D3D11_BUFFER_DESC
		{
			ByteWidth = (uint)Marshal.SizeOf<Struct38>(),
			Usage = D3D11_USAGE.D3D11_USAGE_DYNAMIC,
			BindFlags = 4u,
			CPUAccessFlags = 65536u,
			MiscFlags = 0u,
			StructureByteStride = 0u
		};
		if (desc.ByteWidth % 16 != 0)
		{
			return false;
		}
		ConstantBuffer = Device.CreateBuffer(desc);
		if (ConstantBuffer == null)
		{
			return false;
		}
		return true;
	}

	private bool method_8()
	{
		D3D11_BUFFER_DESC desc = new D3D11_BUFFER_DESC
		{
			ByteWidth = (uint)Marshal.SizeOf<Struct39>(),
			Usage = D3D11_USAGE.D3D11_USAGE_DYNAMIC,
			BindFlags = 4u,
			CPUAccessFlags = 65536u,
			MiscFlags = 0u,
			StructureByteStride = 0u
		};
		if (desc.ByteWidth % 16 != 0)
		{
			return false;
		}
		ConstantBufferArray = Device.CreateBuffer(desc);
		if (ConstantBufferArray != null)
		{
			return true;
		}
		return false;
	}

	private bool method_9()
	{
		int_4 = ShaderManager.LoadShader("shaders.hlsl", "vs_main", "ps_main");
		int_5 = ShaderManager.LoadShader("shaders.hlsl", "vs_main", "ps_tile");
		int_6 = ShaderManager.LoadShader("shaders.hlsl", "vs_main", "ps_array");
		int_7 = ShaderManager.LoadShader("shaders.hlsl", "vs_main", "ps_line");
		int_8 = ShaderManager.LoadShader("shaders.hlsl", "vs_main", "ps_blendable_line");
		int_9 = ShaderManager.LoadShader("shaders.hlsl", "vs_main", "ps_daynight");
		D3D11_SAMPLER_DESC desc = new D3D11_SAMPLER_DESC
		{
			Filter = D3D11_FILTER.D3D11_FILTER_ANISOTROPIC,
			MaxAnisotropy = 4u,
			AddressU = D3D11_TEXTURE_ADDRESS_MODE.D3D11_TEXTURE_ADDRESS_CLAMP,
			AddressV = D3D11_TEXTURE_ADDRESS_MODE.D3D11_TEXTURE_ADDRESS_CLAMP,
			AddressW = D3D11_TEXTURE_ADDRESS_MODE.D3D11_TEXTURE_ADDRESS_CLAMP
		};
		IComObject<ID3D11SamplerState> comObject = Device.CreateSamplerState(desc);
		Context.Object.PSSetSamplers(0u, 1, new ID3D11SamplerState[1] { comObject.Object });
		return true;
	}

	private unsafe ID2D1Bitmap method_10(string string_0, int int_10, int int_11, bool bool_1 = false)
	{
		utf16ValueStringBuilder_0.Clear();
		utf16ValueStringBuilder_0.Append(string_0);
		utf16ValueStringBuilder_0.Append(".");
		utf16ValueStringBuilder_0.Append(int_10);
		utf16ValueStringBuilder_0.Append(".");
		utf16ValueStringBuilder_0.Append(int_11);
		if (bool_1)
		{
			utf16ValueStringBuilder_0.Append(".shadow");
		}
		string key = utf16ValueStringBuilder_0.ToString();
		if (!fastDictionary_0.TryGetValue(key, out var value))
		{
			if (icomObject_0.Object.CreateDecoderFromFilename(string_0, (IntPtr)(void*)null, 2147483648u, WICDecodeOptions.WICDecodeMetadataCacheOnDemand, out var ppIDecoder).IsOk)
			{
				_ = ppIDecoder.GetFrame(0u, out var ppIBitmapFrame).IsOk;
				icomObject_0.Object.CreateFormatConverter(out var ppIFormatConverter);
				Guid dstFormat = WICConstants.GUID_WICPixelFormat32bppPBGRA;
				ppIFormatConverter.Initialize(ppIBitmapFrame, ref dstFormat, WICBitmapDitherType.WICBitmapDitherTypeNone, null, 0.0, WICBitmapPaletteType.WICBitmapPaletteTypeCustom);
				icomObject_0.Object.CreateBitmapFromSource(ppIFormatConverter, WICBitmapCreateCacheOption.WICBitmapNoCache, out var ppIBitmap);
				WICRect structure = new WICRect
				{
					X = 0,
					Y = 0,
					Width = (int)ppIBitmap.GetSize().width,
					Height = (int)ppIBitmap.GetSize().height
				};
				ppIBitmap.Lock(structure.StructureToPtr(), 1u, out var ppILock);
				ppILock.GetDataPointer(out var pcbBufferSize, out var ppbData);
				byte[] array = new byte[pcbBufferSize];
				Marshal.Copy(ppbData, array, 0, (int)pcbBufferSize);
				ppILock.GetStride(out var pcbStride);
				ComObject.Release(ppILock);
				if (int_11 != -1)
				{
					int num = (int_10 << 24) | (int_11 & 0xFFFFFF);
					byte b = (byte)((num & 0xFF000000L) >> 24);
					byte b2 = (byte)((num & 0xFF0000) >> 16);
					byte b3 = (byte)((num & 0xFF00) >> 8);
					byte b4 = (byte)(num & 0xFF);
					b2 = (byte)(b2 * b / 255);
					b3 = (byte)(b3 * b / 255);
					b4 = (byte)(b4 * b / 255);
					for (int i = 0; i < pcbBufferSize; i += 4)
					{
						if (array[i] == byte.MaxValue && array[i + 1] == byte.MaxValue && array[i + 2] == byte.MaxValue)
						{
							array[i] = b4;
							array[i + 1] = b3;
							array[i + 2] = b2;
							array[i + 3] = b;
						}
					}
				}
				if (bool_1)
				{
					for (int j = 0; j < pcbBufferSize; j += 4)
					{
						if (array[j] != 0 || array[j + 1] != 0 || array[j + 2] != 0)
						{
							array[j] = 0;
							array[j + 1] = 0;
							array[j + 2] = 0;
							array[j + 3] = byte.MaxValue;
						}
					}
				}
				icomObject_0.Object.CreateBitmapFromMemory((uint)structure.Width, (uint)structure.Height, ref dstFormat, pcbStride, (int)pcbBufferSize, array, out var ppIBitmap2);
				if (id2D1RenderTarget_0 == null)
				{
					id2D1RenderTarget_0 = icomObject_2.Object;
				}
				id2D1RenderTarget_0.CreateBitmapFromWicBitmap(ppIBitmap2, (IntPtr)(void*)null, out var bitmap);
				fastDictionary_0[key] = bitmap;
				return bitmap;
			}
			return null;
		}
		return value;
	}

	public void SetDateTime(DateTime dateTime_0)
	{
		double num = dateTime_0.ToOADate() + 2415018.5;
		ForegroundWorldDrawParameters_Stamen.Hint = (float)num;
		ForegroundWorldDrawParameters_DayNight.Hint = (float)num;
	}

	public void SetProjection(float longitude, float latitude, float altitude)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		latitude = Math.Min(89.9f, latitude);
		latitude = Math.Max(-89.9f, latitude);
		matrix4x4_0 = method_11(longitude, latitude, altitude);
		DrawArgs.Update(latitude, longitude, altitude, ScreenWidth, ScreenHeight, float_1);
		if (RenderState.BordersCoasts)
		{
			DXDevice.TileCache.BordersCoastsAlpha = 1f;
		}
	}

	public void ManageTiles(float longitude, float latitude, float altitude)
	{
		DXDevice.TileCache.ManageTiles(longitude, latitude, altitude);
	}

	private Matrix4x4 method_11(float float_3, float float_4, float float_5)
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Unknown result type (might be due to invalid IL or missing references)
		//IL_019b: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		float num = 6378137f;
		float num2 = num + float_5;
		float num3 = (float)Math.Sqrt((double)(num2 * num2) - 40680631590769.0);
		CurrentCameraAltitude = float_5;
		Matrix4x4 identity = Matrix4x4.Identity;
		float num4 = method_14(float_3);
		float num5 = method_13(float_4);
		float num6 = (float)ScreenWidth / (float)ScreenHeight;
		float num7 = float_5 * 0.01f;
		Matrix4x4 val = Matrix4x4.CreatePerspectiveFieldOfView(float_1, num6, num7, num3);
		val.M33 *= -1f;
		val.M34 *= -1f;
		float num8 = (float)((double)num2 * Math.Sin(num5) * Math.Cos(num4));
		float num9 = (float)((double)num2 * Math.Sin(num5) * Math.Sin(num4));
		float num10 = (float)((double)num2 * Math.Cos(num5));
		Vector3 val2 = new Vector3(num8, num10, num9);
		Vector3 zero = Vector3.Zero;
		Vector3 val3 = default(Vector3);
		((Vector3)(ref val3))..ctor(0f, 1f, 0f);
		Matrix4x4 val4 = Matrix4x4.CreateLookAt(val2, zero, val3);
		val4.M11 *= -1f;
		val4.M13 *= -1f;
		val4.M21 *= -1f;
		val4.M23 *= -1f;
		val4.M31 *= -1f;
		val4.M33 *= -1f;
		val4.M41 *= -1f;
		val4.M43 *= -1f;
		DXDevice.ViewMatrix = val4;
		DXDevice.ProjMatrix = val;
		return identity * val4 * val;
	}

	private Matrix4x4 method_12()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		Matrix4x4 val = Matrix4x4.CreateOrthographic((float)ScreenWidth, (float)ScreenHeight, -1f, 1f);
		val.M33 *= -1f;
		Matrix4x4 val2 = Matrix4x4.CreateTranslation(new Vector3((float)(-ScreenWidth) / 2f, (float)(-ScreenHeight) / 2f, 0f));
		return Matrix4x4.Identity * val2 * val;
	}

	private float method_13(float float_3)
	{
		float_3 += 90f;
		float_3.Clamp(2.938736E-39f, 180f);
		return (1f - float_3 / 180f) * (float)Math.PI;
	}

	private float method_14(float float_3)
	{
		float_3 += 180f;
		float_3.Clamp(2.938736E-39f, 180f);
		return (0.5f + float_3 / 360f * 2f) * (float)Math.PI;
	}

	public void BeginDrawing()
	{
		//IL_0601: Unknown result type (might be due to invalid IL or missing references)
		//IL_0606: Unknown result type (might be due to invalid IL or missing references)
		//IL_0664: Unknown result type (might be due to invalid IL or missing references)
		//IL_0630: Unknown result type (might be due to invalid IL or missing references)
		//IL_0692: Unknown result type (might be due to invalid IL or missing references)
		//IL_0697: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b9: Unknown result type (might be due to invalid IL or missing references)
		id3DUserDefinedAnnotation_0.BeginEvent("BeginDrawing");
		RenderEventHandler?.Handle(RenderEvent.BeginDrawing);
		Context.Object.OMSetRenderTargets(1, new ID3D11RenderTargetView[1] { DXDevice.RenderTargetView.Object }, DXDevice.DepthStencilView.Object);
		D3D11_VIEWPORT d3D11_VIEWPORT = new D3D11_VIEWPORT
		{
			Width = ScreenWidth,
			Height = ScreenHeight,
			MinDepth = 0f,
			MaxDepth = 1f,
			TopLeftX = int_2,
			TopLeftY = int_3
		};
		Context.Object.RSSetViewports(1, new D3D11_VIEWPORT[1] { d3D11_VIEWPORT });
		ID3D11RenderTargetView pRenderTargetView = DXDevice.RenderTargetView.Object;
		((Vector4)(ref vector4_0)).CopyTo(float_2);
		Context.Object.ClearRenderTargetView(pRenderTargetView, float_2);
		method_15();
		if (bool_0 && Frame != 0)
		{
			method_3();
		}
		method_2();
		DXDevice.SetRasterizerState(uint_1);
		Context.Object.IASetPrimitiveTopology(D3D_PRIMITIVE_TOPOLOGY.D3D_PRIMITIVE_TOPOLOGY_TRIANGLELIST);
		icomObject_2.BeginDraw();
		for (int num = orderedDictionary_0.Count - 1; num >= 0; num--)
		{
			foreach (DrawParameters item in (List<DrawParameters>)orderedDictionary_0[num])
			{
				if (item.Draw)
				{
					method_20(item);
				}
			}
		}
		id3DUserDefinedAnnotation_0.BeginEvent("DrawTiles");
		DXDevice.TileCache.TilesDrawn = 0;
		int num2 = Math.Max(DXDevice.TileCache.Levels.Length, DXDevice.TileCache.SlippyLevels.Length);
		list_1.Clear();
		list_0.Clear();
		list_0.AddRange(DXDevice.TileCache.Tiles);
		int[,] array = new int[4, num2];
		int[] array2 = new int[4];
		foreach (KeyValuePair<string, DrawParameters> item2 in list_0)
		{
			DrawParameters value = item2.Value;
			if (value.Draw && value.ShaderResourceView != null)
			{
				array[value.Priority, value.Level]++;
				array2[value.Priority]++;
			}
		}
		for (int i = 0; i < 4; i++)
		{
			id3DUserDefinedAnnotation_0.BeginEvent("DrawTilesPriority" + i);
			if (array2[i] > 0)
			{
				int[] array3 = new int[num2];
				for (int num3 = num2 - 2; num3 >= 0; num3--)
				{
					array3[num3] = array[i, num3 + 1] + array3[num3 + 1];
				}
				DrawParameters[] array4 = new DrawParameters[array2[i]];
				int count = list_0.Count;
				for (int j = 0; j < count; j++)
				{
					KeyValuePair<string, DrawParameters> keyValuePair = list_0[j];
					DrawParameters value2 = keyValuePair.Value;
					if (value2.Priority == i)
					{
						if (value2.Draw && value2.ShaderResourceView != null)
						{
							int level = (int)value2.Level;
							array4[array3[level]] = value2;
							array3[level]++;
						}
						value2.Draw = false;
					}
					DXDevice.TileCache.Tiles[keyValuePair.Key] = value2;
					list_0[j] = new KeyValuePair<string, DrawParameters>(keyValuePair.Key, value2);
				}
				List<DrawParameters> list = new List<DrawParameters>(array4);
				for (int k = 0; k < list.Count; k++)
				{
					if (list[k].Layer == Layer.StamenLabels)
					{
						list_1.Add(list[k]);
						list.RemoveAt(k);
						k--;
					}
				}
				if (list.Count > 0)
				{
					method_19(list, WorldDrawParameters);
				}
			}
			id3DUserDefinedAnnotation_0.EndEvent();
		}
		id3DUserDefinedAnnotation_0.EndEvent();
		ShaderManager.SetShader(int_4);
		if (RenderState.BaseEarth)
		{
			id3DUserDefinedAnnotation_0.BeginEvent("DrawBackground");
			method_20(BackgroundWorldDrawParameters);
			id3DUserDefinedAnnotation_0.EndEvent();
		}
		Drawing = true;
		RenderEventHandler?.Handle(RenderEvent.DrawingEnabled, DXDevice.TileCache.Tiles);
		if (RenderState.Scale)
		{
			id3DUserDefinedAnnotation_0.BeginEvent("DrawScale");
			scale_0.Render(DrawArgs);
			id3DUserDefinedAnnotation_0.EndEvent();
		}
		if (RenderState.DayNight)
		{
			id3DUserDefinedAnnotation_0.BeginEvent("DrawForegroundDayNight");
			method_15();
			method_20(ForegroundWorldDrawParameters_DayNight);
			id3DUserDefinedAnnotation_0.EndEvent();
		}
		if (!RenderState.DayNight)
		{
			method_16();
		}
		if (RenderState.LatitudeLongitudeGrid)
		{
			id3DUserDefinedAnnotation_0.BeginEvent("DrawLatitudeLongitude");
			latLongGrid_0.Render(DrawArgs);
			id3DUserDefinedAnnotation_0.EndEvent();
		}
		if (RenderState.BordersCoasts)
		{
			id3DUserDefinedAnnotation_0.BeginEvent("DrawBordersCoasts");
			method_15();
			Vector4 color = IntToVector4(RenderState.BorderColor.ToArgb());
			if (Borders != Borders.Older)
			{
				DXDevice.TileCache.BordersCoastNewer.Render(DXDevice.TileCache.BordersCoastsAlpha, color, RenderState.BorderColorChanged);
			}
			else
			{
				DXDevice.TileCache.BordersCoastOlder.Render(DXDevice.TileCache.BordersCoastsAlpha, color, RenderState.BorderColorChanged);
			}
			RenderState.BorderColorChanged = false;
			Vector4 color2 = IntToVector4(RenderState.SeaIceColor.ToArgb());
			DXDevice.TileCache.ArcticIce.Render(DXDevice.TileCache.BordersCoastsAlpha, color2, RenderState.SeaIceColorChanged);
			RenderState.SeaIceColorChanged = false;
			id3DUserDefinedAnnotation_0.EndEvent();
		}
		method_15();
		method_19(list_1, ForegroundWorldDrawParameters_Stamen);
		Render();
	}

	private void method_15()
	{
		Context.Object.ClearDepthStencilView(DXDevice.DepthStencilView.Object, 1u, 1f, 0);
	}

	private void method_16()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		method_15();
		Matrix4x4 val = matrix4x4_0;
		Matrix4x4 viewMatrix = DXDevice.ViewMatrix;
		Matrix4x4 val2 = Matrix4x4.CreateTranslation(0f, 0f, 1275627.4f);
		matrix4x4_0 = val2 * viewMatrix;
		method_20(OcclusionPlaneDrawParameters);
		matrix4x4_0 = val;
	}

	private KeyValuePair<string, DrawParameters>[] method_17(ConcurrentDictionary<string, DrawParameters> concurrentDictionary_0)
	{
		KeyValuePair<string, DrawParameters>[] array = new KeyValuePair<string, DrawParameters>[concurrentDictionary_0.Count];
		IEnumerator<KeyValuePair<string, DrawParameters>> enumerator = concurrentDictionary_0.GetEnumerator();
		int num = 0;
		while (enumerator.MoveNext())
		{
			array[num] = enumerator.Current;
			num++;
		}
		return array;
	}

	public void DrawText(string text, int x, int y)
	{
		DrawText(text, 12f, Color.White, x, y);
	}

	public void DrawText(string text, float size, Color color, int x, int y, bool rightJustify = false, bool outlineText = false)
	{
		if (!Drawing || size == 0f)
		{
			return;
		}
		D2D1_BRUSH_PROPERTIES value = new D2D1_BRUSH_PROPERTIES
		{
			opacity = 1f
		};
		int key = color.ToArgb();
		ID2D1SolidColorBrush iD2D1SolidColorBrush;
		if (dictionary_1.TryGetValue(key, out var value2))
		{
			IComObject<ID2D1SolidColorBrush> comObject;
			(comObject, iD2D1SolidColorBrush) = value2;
		}
		else
		{
			_D3DCOLORVALUE color2 = _D3DCOLORVALUE.FromArgb(color.A, color.R, color.G, color.B);
			IComObject<ID2D1SolidColorBrush> comObject = icomObject_2.CreateSolidColorBrush(color2, value);
			iD2D1SolidColorBrush = comObject.Object;
			dictionary_1.Add(key, (comObject, iD2D1SolidColorBrush));
		}
		color = Color.FromArgb(color.A, Color.Black.R, Color.Black.G, Color.Black.B);
		IComObject<ID2D1SolidColorBrush> comObject2 = null;
		ID2D1SolidColorBrush iD2D1SolidColorBrush2 = null;
		if (outlineText)
		{
			if (dictionary_1.TryGetValue(color.ToArgb(), out value2))
			{
				(comObject2, iD2D1SolidColorBrush2) = value2;
			}
			else
			{
				_D3DCOLORVALUE color3 = _D3DCOLORVALUE.FromArgb(color.A, color.R, color.G, color.B);
				comObject2 = icomObject_2.CreateSolidColorBrush(color3, value);
				iD2D1SolidColorBrush2 = comObject2.Object;
				dictionary_1.Add(color.ToArgb(), (comObject2, iD2D1SolidColorBrush2));
			}
		}
		(string, float) key2 = ("Segoe UI", size);
		if (!dictionary_3.TryGetValue(key2, out var value3))
		{
			value3 = icomObject_3.CreateTextFormat("Segoe UI", size);
			dictionary_3.Add(key2, value3);
		}
		(IComObject<IDWriteTextFormat>, string) key3 = (value3, text);
		if (!dictionary_4.TryGetValue(key3, out var value4))
		{
			value4 = icomObject_3.CreateTextLayout(value3, text);
			dictionary_4.Add(key3, value4);
		}
		D2D_POINT_2F origin = new D2D_POINT_2F(int_2 + x, int_3 + y);
		IDWriteTextLayout textLayout = value4.Object;
		ID2D1SolidColorBrush defaultFillBrush = ((comObject2 == null) ? null : iD2D1SolidColorBrush2);
		if (id2D1RenderTarget_0 == null)
		{
			id2D1RenderTarget_0 = icomObject_2.Object;
		}
		id2D1RenderTarget_0.SetTextAntialiasMode(D2D1_TEXT_ANTIALIAS_MODE.D2D1_TEXT_ANTIALIAS_MODE_GRAYSCALE);
		origin.y += 1f;
		if (outlineText)
		{
			id2D1RenderTarget_0.DrawTextLayout(origin, textLayout, defaultFillBrush, D2D1_DRAW_TEXT_OPTIONS.D2D1_DRAW_TEXT_OPTIONS_NONE);
		}
		origin.x += 1f;
		if (outlineText)
		{
			id2D1RenderTarget_0.DrawTextLayout(origin, textLayout, defaultFillBrush, D2D1_DRAW_TEXT_OPTIONS.D2D1_DRAW_TEXT_OPTIONS_NONE);
		}
		origin.x -= 2f;
		if (outlineText)
		{
			id2D1RenderTarget_0.DrawTextLayout(origin, textLayout, defaultFillBrush, D2D1_DRAW_TEXT_OPTIONS.D2D1_DRAW_TEXT_OPTIONS_NONE);
		}
		origin.y -= 2f;
		if (outlineText)
		{
			id2D1RenderTarget_0.DrawTextLayout(origin, textLayout, defaultFillBrush, D2D1_DRAW_TEXT_OPTIONS.D2D1_DRAW_TEXT_OPTIONS_NONE);
		}
		origin.x += 1f;
		origin.y += 1f;
		id2D1RenderTarget_0.DrawTextLayout(origin, textLayout, iD2D1SolidColorBrush, D2D1_DRAW_TEXT_OPTIONS.D2D1_DRAW_TEXT_OPTIONS_NONE);
	}

	internal float MeasureTextHeight(string text)
	{
		int num = 12;
		D2D_RECT_F d2D_RECT_F = new D2D_RECT_F
		{
			left = int_2 + 0,
			right = float.MaxValue,
			top = int_3 + 0,
			bottom = float.MaxValue
		};
		(string, float) key = ("Segoe UI", 12f);
		if (!dictionary_3.TryGetValue(key, out var value))
		{
			value = icomObject_3.CreateTextFormat("Segoe UI", num);
			dictionary_3.Add(key, value);
		}
		IComObject<IDWriteTextLayout> comObject = icomObject_3.CreateTextLayout(value, text, text.Length, d2D_RECT_F.right, d2D_RECT_F.bottom);
		comObject.Object.GetMetrics(out var textMetrics);
		comObject.Dispose();
		return textMetrics.height;
	}

	internal float MeasureTextWidth(string text)
	{
		int num = 12;
		D2D_RECT_F d2D_RECT_F = new D2D_RECT_F
		{
			left = int_2 + 0,
			right = float.MaxValue,
			top = int_3 + 0,
			bottom = float.MaxValue
		};
		(string, float) key = ("Segoe UI", 12f);
		if (!dictionary_3.TryGetValue(key, out var value))
		{
			value = icomObject_3.CreateTextFormat("Segoe UI", num);
			dictionary_3.Add(key, value);
		}
		IComObject<IDWriteTextLayout> comObject = icomObject_3.CreateTextLayout(value, text, text.Length, d2D_RECT_F.right, d2D_RECT_F.bottom);
		comObject.Object.GetMetrics(out var textMetrics);
		comObject.Dispose();
		return textMetrics.width;
	}

	public Rectangle MeasureText(string text, float size, int x, int y)
	{
		(string, float) key = (text, size);
		Rectangle rectangle = default(Rectangle);
		rectangle = lrucache_0.get(key);
		if (rectangle.Width > 0)
		{
			return rectangle;
		}
		D2D_RECT_F d2D_RECT_F = new D2D_RECT_F
		{
			left = int_2 + x,
			right = float.MaxValue,
			top = int_3 + y,
			bottom = float.MaxValue
		};
		(string, float) key2 = ("Segoe UI", size);
		if (!dictionary_3.TryGetValue(key2, out var value))
		{
			value = icomObject_3.CreateTextFormat("Segoe UI", size);
			dictionary_3.Add(key2, value);
		}
		IComObject<IDWriteTextLayout> comObject = icomObject_3.CreateTextLayout(value, text, text.Length, d2D_RECT_F.right, d2D_RECT_F.bottom);
		comObject.Object.GetMetrics(out var textMetrics);
		rectangle.Height = (int)textMetrics.height;
		rectangle.Width = (int)textMetrics.width;
		comObject.Dispose();
		lrucache_0.add(key, rectangle);
		return rectangle;
	}

	public Rectangle MeasureTextLayout(IComObject<IDWriteTextLayout> icomObject_9)
	{
		icomObject_9.Object.GetMetrics(out var textMetrics);
		return new Rectangle((int)textMetrics.left, (int)textMetrics.top, (int)textMetrics.width, (int)textMetrics.height);
	}

	private void method_18()
	{
		PointF[] points = new PointF[4]
		{
			new PointF
			{
				X = ScreenWidth - 20,
				Y = 10f
			},
			new PointF
			{
				X = ScreenWidth - 10,
				Y = 10f
			},
			new PointF
			{
				X = ScreenWidth - 10,
				Y = 20f
			},
			new PointF
			{
				X = ScreenWidth - 20,
				Y = 20f
			}
		};
		Color color = Color.FromArgb(128, 0, 255, 0);
		if (DXDevice.TileCache.TileTasks.Count != 0)
		{
			color = Color.FromArgb(128, 255, 0, 0);
			DrawText(DXDevice.TileCache.TileTasks.Count.ToString(), ScreenWidth - 22, 22);
		}
		FillGeometry(points, color);
		DrawText($"F{DXDevice.TileCache.FileSystemLevel,2} / B{DXDevice.TileCache.BMNGOSMLevel,2} / O{DXDevice.TileCache.OSMLevel,2}", ScreenWidth - 93, 34);
	}

	public void FinishDrawing()
	{
		if (EnableTileLoadingIndicator)
		{
			method_18();
		}
		RenderEventHandler?.Handle(RenderEvent.Present);
		Drawing = false;
		id3DUserDefinedAnnotation_0.BeginEvent("Draw2DEnd");
		icomObject_2.EndDraw();
		id3DUserDefinedAnnotation_0.EndEvent();
		_ = DXDevice.SwapChain.Object.Present(0u, 0u).IsOk;
		Context.Object.OMSetRenderTargets(1, new ID3D11RenderTargetView[1] { DXDevice.RenderTargetView.Object }, DXDevice.DepthStencilView.Object);
		Frame++;
		DXDevice.TileCache.TilesLoaded = 0;
		RenderEventHandler?.Handle(RenderEvent.FinishedDrawing);
		id3DUserDefinedAnnotation_0.EndEvent();
	}

	private void method_19(List<DrawParameters> list_3, DrawParameters drawParameters_0)
	{
		int num = 0;
		int num2 = list_3.Count / 256;
		int num3 = list_3.Count % 256;
		while (num < num2)
		{
			DrawTiles(list_3, 256, num++ * 256, drawParameters_0);
		}
		if (num3 > 0)
		{
			DrawTiles(list_3, num3, num * 256, drawParameters_0);
		}
	}

	private unsafe void DrawTiles(List<DrawParameters> parameters_array, int number, int from, DrawParameters referenceParameters)
	{
		ID3D11DeviceContext iD3D11DeviceContext = Context.Object;
		int int_2 = number + from;
		if (icomObject_7 == null)
		{
			D3D11_TEXTURE2D_DESC desc = new D3D11_TEXTURE2D_DESC
			{
				Width = 256u,
				Height = 256u,
				MipLevels = 1u,
				ArraySize = 256u,
				Format = DXGI_FORMAT.DXGI_FORMAT_B8G8R8A8_UNORM,
				Usage = D3D11_USAGE.D3D11_USAGE_DEFAULT,
				BindFlags = 8u
			};
			desc.SampleDesc.Count = 1u;
			icomObject_7 = Device.CreateTexture2D<ID3D11Texture2D>(desc);
		}
		int num;
		if (id3D11Texture2D_0 == null)
		{
			id3D11Texture2D_0 = icomObject_7.Object;
			num = 0;
		}
		else
		{
			num = 0;
		}
		uint num2 = (uint)num;
		for (int i = from; i < int_2; i++)
		{
			DrawParameters drawParameters = parameters_array[i];
			if (drawParameters.ShaderResourceView != null)
			{
				drawParameters.ShaderResourceView.Object.GetResource(out var ppResource);
				iD3D11DeviceContext.CopySubresourceRegion(id3D11Texture2D_0, num2++, 0u, 0u, 0u, ppResource, 0u, (IntPtr)(void*)null);
			}
		}
		Context.WithMap(ConstantBuffer, 0, D3D11_MAP.D3D11_MAP_WRITE_DISCARD, delegate(ref D3D11_MAPPED_SUBRESOURCE mapped, ref Struct38 buffer)
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			buffer.matrix4x4_0 = matrix4x4_0;
		});
		Context.WithMap(ConstantBufferArray, 0, D3D11_MAP.D3D11_MAP_WRITE_DISCARD, delegate(ref D3D11_MAPPED_SUBRESOURCE mapped, ref Struct39 buffer)
		{
			buffer.uint_0 = (uint)number;
			int num3 = 0;
			for (int j = from; j < int_2; j++)
			{
				DrawParameters drawParameters2 = parameters_array[j];
				buffer.float_0[num3] = drawParameters2.u;
				buffer.float_1[num3] = drawParameters2.v;
				buffer.float_2[num3] = drawParameters2.uWidth;
				buffer.float_3[num3] = drawParameters2.vWidth;
				buffer.Row[num3] = drawParameters2.Row;
				buffer.uint_1[num3] = drawParameters2.Level;
				buffer.int_0[num3] = (int)drawParameters2.Layer;
				buffer.lreyQaRqbOC[num3] = drawParameters2.Hint;
				num3++;
			}
		});
		iD3D11DeviceContext.IASetVertexBuffers(0u, 1, new ID3D11Buffer[1] { referenceParameters.VertexBuffer.Object }, new uint[1] { 36u }, new uint[1] { 0u });
		iD3D11DeviceContext.IASetIndexBuffer(referenceParameters.IndexBuffer.Object, DXGI_FORMAT.DXGI_FORMAT_R32_UINT, 0u);
		iD3D11DeviceContext.IASetPrimitiveTopology(referenceParameters.Topology);
		if (id3D11Buffer_0 == null)
		{
			id3D11Buffer_0 = ConstantBuffer.Object;
		}
		iD3D11DeviceContext.VSSetConstantBuffers(0u, 1, new ID3D11Buffer[1] { id3D11Buffer_0 });
		iD3D11DeviceContext.PSSetConstantBuffers(0u, 1, new ID3D11Buffer[1] { id3D11Buffer_0 });
		if (id3D11Buffer_1 == null)
		{
			id3D11Buffer_1 = ConstantBufferArray.Object;
		}
		iD3D11DeviceContext.VSSetConstantBuffers(1u, 1, new ID3D11Buffer[1] { id3D11Buffer_1 });
		iD3D11DeviceContext.PSSetConstantBuffers(1u, 1, new ID3D11Buffer[1] { id3D11Buffer_1 });
		if (icomObject_8 == null)
		{
			icomObject_8 = Device.CreateShaderResourceView(icomObject_7);
		}
		iD3D11DeviceContext.PSSetShaderResources(1u, 1, new ID3D11ShaderResourceView[1] { icomObject_8.Object });
		ShaderManager.SetShader(int_6);
		iD3D11DeviceContext.DrawIndexed(referenceParameters.NumberIndices, 0u, 0);
	}

	private void method_20(DrawParameters drawParameters_0)
	{
		Context.Object.IASetVertexBuffers(0u, 1, new ID3D11Buffer[1] { drawParameters_0.VertexBuffer.Object }, new uint[1] { 36u }, new uint[1] { 0u });
		if (drawParameters_0.Disposable)
		{
			drawParameters_0.VertexBuffer.Dispose();
		}
		Context.Object.IASetIndexBuffer(drawParameters_0.IndexBuffer.Object, DXGI_FORMAT.DXGI_FORMAT_R32_UINT, 0u);
		if (drawParameters_0.Disposable)
		{
			drawParameters_0.IndexBuffer.Dispose();
		}
		Context.WithMap(ConstantBuffer, 0, D3D11_MAP.D3D11_MAP_WRITE_DISCARD, delegate(ref D3D11_MAPPED_SUBRESOURCE mapped, ref Struct38 buffer)
		{
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			switch (drawParameters_0.Projection)
			{
			case Projection.Globe:
				buffer.matrix4x4_0 = matrix4x4_0;
				break;
			case Projection.Icon:
				buffer.matrix4x4_0 = matrix4x4_1;
				break;
			}
			buffer.float_0 = drawParameters_0.u;
			buffer.float_1 = drawParameters_0.v;
			buffer.float_2 = drawParameters_0.uWidth;
			buffer.float_3 = drawParameters_0.vWidth;
			buffer.Row = drawParameters_0.Row;
			buffer.uint_0 = drawParameters_0.Level;
			buffer.int_0 = (int)drawParameters_0.Layer;
			buffer.float_4 = drawParameters_0.Hint;
		});
		Context.Object.IASetPrimitiveTopology(drawParameters_0.Topology);
		Context.Object.VSSetConstantBuffers(0u, 1, new ID3D11Buffer[1] { ConstantBuffer.Object });
		Context.Object.PSSetConstantBuffers(0u, 1, new ID3D11Buffer[1] { ConstantBuffer.Object });
		if (drawParameters_0.ShaderResourceView != null)
		{
			Context.Object.PSSetShaderResources(0u, 1, new ID3D11ShaderResourceView[1] { drawParameters_0.ShaderResourceView.Object });
		}
		if (drawParameters_0.Layer == Layer.DayNight)
		{
			Context.Object.OMSetBlendState(icomObject_4.Object, float_0, uint.MaxValue);
		}
		if (drawParameters_0.Layer == Layer.BlendableLine)
		{
			Context.Object.OMSetBlendState(icomObject_6.Object, float_0, uint.MaxValue);
		}
		if (drawParameters_0.Projection == Projection.Icon)
		{
			DXDevice.SetDepthStencilState(uint_3);
			Context.Object.OMSetBlendState(icomObject_5.Object, float_0, uint.MaxValue);
		}
		if (drawParameters_0.Projection == Projection.Icon)
		{
			ShaderManager.SetShader(int_4);
		}
		else
		{
			switch (drawParameters_0.Layer)
			{
			case Layer.Line:
				ShaderManager.SetShader(int_7);
				break;
			case Layer.DayNight:
				ShaderManager.SetShader(int_9);
				break;
			default:
				ShaderManager.SetShader(int_5);
				break;
			case Layer.BlendableLine:
				ShaderManager.SetShader(int_8);
				break;
			case Layer.BaseEarth:
				ShaderManager.SetShader(int_4);
				break;
			}
		}
		Context.Object.DrawIndexed(drawParameters_0.NumberIndices, 0u, 0);
		Context.Object.OMSetDepthStencilState(null, 0u);
		Context.Object.OMSetBlendState(null, null, uint.MaxValue);
	}

	public void DrawIcon(string path, int alpha, int x, int y, int width, int height, bool DrawOutline, int color = -1, float heading = 0f)
	{
		ID2D1Bitmap iD2D1Bitmap = method_10(path, alpha, color);
		if (iD2D1Bitmap != null)
		{
			if (DrawOutline)
			{
				ID2D1Bitmap d2dBitMapToDraw = method_10(path, alpha, color, bool_1: true);
				DrawD2DBitmap(d2dBitMapToDraw, alpha, x, y, width + 4, height + 4, heading);
				DrawD2DBitmap(d2dBitMapToDraw, alpha, x, y, width - 4, height - 4, heading);
			}
			DrawD2DBitmap(iD2D1Bitmap, alpha, x, y, width, height, heading);
		}
	}

	public unsafe void DrawD2DBitmap(ID2D1Bitmap d2dBitMapToDraw, int alpha, int x, int y, int width, int height, float heading)
	{
		y = ScreenHeight - y + int_3;
		float num = (float)width * 0.5f;
		float num2 = (float)height * 0.5f;
		if (id2D1RenderTarget_0 == null)
		{
			id2D1RenderTarget_0 = icomObject_2.Object;
		}
		id2D1RenderTarget_0.GetTransform(out var transform);
		float num3 = (float)x * transform._11 + (float)y * transform._21 + transform._31;
		float num4 = (float)x * transform._12 + (float)y * transform._22 + transform._32;
		D2D_MATRIX_3X2_F transform2 = D2D_MATRIX_3X2_F.Identity();
		id2D1RenderTarget_0.SetTransform(ref transform2);
		IntPtr pointer = new D2D_RECT_F
		{
			left = num3 - num,
			right = num3 + num,
			top = num4 - num2,
			bottom = num4 + num2
		}.StructureToMemory().Pointer;
		float opacity = (float)alpha / 255f;
		if (heading != 0f)
		{
			D2D_MATRIX_3X2_F transform3 = D2D_MATRIX_3X2_F.Rotation(heading, num3, num4);
			id2D1RenderTarget_0.SetTransform(ref transform3);
		}
		id2D1RenderTarget_0.DrawBitmap(d2dBitMapToDraw, pointer, opacity, D2D1_BITMAP_INTERPOLATION_MODE.D2D1_BITMAP_INTERPOLATION_MODE_LINEAR, (IntPtr)(void*)null);
		id2D1RenderTarget_0.SetTransform(ref transform);
	}

	public unsafe void DrawBitmap(Bitmap bitmap)
	{
		IntPtr pointer = new D2D_RECT_F
		{
			left = 0f,
			right = ((Image)bitmap).Width,
			top = ((Image)bitmap).Height,
			bottom = 0f
		}.StructureToMemory().Pointer;
		ID2D1Bitmap bitmap2 = method_21(bitmap);
		if (id2D1RenderTarget_0 == null)
		{
			id2D1RenderTarget_0 = icomObject_2.Object;
		}
		id2D1RenderTarget_0.DrawBitmap(bitmap2, pointer, 1f, D2D1_BITMAP_INTERPOLATION_MODE.D2D1_BITMAP_INTERPOLATION_MODE_LINEAR, (IntPtr)(void*)null);
	}

	private ID2D1Bitmap method_21(Bitmap bitmap_0)
	{
		int num = ((Image)bitmap_0).Width * 4;
		byte[] array = new byte[num * ((Image)bitmap_0).Height];
		for (int i = 0; i < ((Image)bitmap_0).Height; i++)
		{
			for (int j = 0; j < ((Image)bitmap_0).Width; j++)
			{
				Color pixel = bitmap_0.GetPixel(j, i);
				int num2 = i * num + j * 4;
				array[num2] = (byte)(pixel.B * pixel.A / 255);
				array[num2 + 1] = (byte)(pixel.G * pixel.A / 255);
				array[num2 + 2] = (byte)(pixel.R * pixel.A / 255);
				array[num2 + 3] = pixel.A;
			}
		}
		D2D_SIZE_U size = new D2D_SIZE_U((uint)((Image)bitmap_0).Width, (uint)((Image)bitmap_0).Height);
		D2D1_BITMAP_PROPERTIES bitmapProperties = new D2D1_BITMAP_PROPERTIES
		{
			pixelFormat = new D2D1_PIXEL_FORMAT
			{
				format = DXGI_FORMAT.DXGI_FORMAT_B8G8R8A8_UNORM,
				alphaMode = D2D1_ALPHA_MODE.D2D1_ALPHA_MODE_PREMULTIPLIED
			}
		};
		GCHandle gCHandle = GCHandle.Alloc(array, GCHandleType.Pinned);
		if (id2D1RenderTarget_0 == null)
		{
			id2D1RenderTarget_0 = icomObject_2.Object;
		}
		id2D1RenderTarget_0.CreateBitmap(size, gCHandle.AddrOfPinnedObject(), (uint)(((Image)bitmap_0).Width * 4), ref bitmapProperties, out var bitmap);
		gCHandle.Free();
		return bitmap;
	}

	public void DrawLines_FAST(int line_thickness, Color color, List<Segment_Points> segmentVects, bool dashed = false)
	{
		id2D1RenderTarget_0.GetFactory(out var factory);
		int key = color.ToArgb();
		LineBatch lineBatch = new LineBatch(factory, 0f);
		ID2D1StrokeStyle strokeStyle = ((!dashed) ? id2D1StrokeStyle_0 : id2D1StrokeStyle_1);
		if (!dictionary_1.TryGetValue(key, out var value))
		{
			_D3DCOLORVALUE color2 = _D3DCOLORVALUE.FromArgb(color.A, color.R, color.G, color.B);
			D2D1_BRUSH_PROPERTIES value2 = new D2D1_BRUSH_PROPERTIES
			{
				opacity = 1f
			};
			IComObject<ID2D1SolidColorBrush> comObject = icomObject_2.CreateSolidColorBrush(color2, value2);
			value = (comObject, comObject.Object);
			dictionary_1[key] = value;
		}
		ID2D1SolidColorBrush item = value.Item2;
		for (int i = 0; i < segmentVects.Count; i++)
		{
			Segment_Points segment_Points = segmentVects[i];
			lineBatch.Add(segment_Points.A.X, segment_Points.A.Y, segment_Points.B.X, segment_Points.B.Y);
		}
		lineBatch.Draw(id2D1RenderTarget_0, item, line_thickness, strokeStyle);
	}

	public void DrawLines_FAST(int line_thickness, Color color, Segment_Points[] segmentVects, bool dashed = false)
	{
		id2D1RenderTarget_0.GetFactory(out var factory);
		int key = color.ToArgb();
		LineBatch lineBatch = new LineBatch(factory, 0f);
		ID2D1StrokeStyle strokeStyle = ((!dashed) ? id2D1StrokeStyle_0 : id2D1StrokeStyle_1);
		if (!dictionary_1.TryGetValue(key, out var value))
		{
			_D3DCOLORVALUE color2 = _D3DCOLORVALUE.FromArgb(color.A, color.R, color.G, color.B);
			D2D1_BRUSH_PROPERTIES value2 = new D2D1_BRUSH_PROPERTIES
			{
				opacity = 1f
			};
			IComObject<ID2D1SolidColorBrush> comObject = icomObject_2.CreateSolidColorBrush(color2, value2);
			value = (comObject, comObject.Object);
			dictionary_1[key] = value;
		}
		ID2D1SolidColorBrush item = value.Item2;
		for (int i = 0; i < segmentVects.Length; i++)
		{
			Segment_Points segment_Points = segmentVects[i];
			lineBatch.Add(segment_Points.A.X, segment_Points.A.Y, segment_Points.B.X, segment_Points.B.Y);
		}
		lineBatch.Draw(id2D1RenderTarget_0, item, line_thickness, strokeStyle);
	}

	public void DrawCrenelatedLine(Color color, float thickness, float startX, float startY, float endX, float endY, float step = 12f, float crenelSize = 6f)
	{
		if (!Drawing)
		{
			return;
		}
		int key = color.ToArgb();
		if (!dictionary_1.TryGetValue(key, out var value))
		{
			_D3DCOLORVALUE color2 = _D3DCOLORVALUE.FromArgb(color.A, color.R, color.G, color.B);
			D2D1_BRUSH_PROPERTIES value2 = new D2D1_BRUSH_PROPERTIES
			{
				opacity = 1f
			};
			IComObject<ID2D1SolidColorBrush> comObject = icomObject_2.CreateSolidColorBrush(color2, value2);
			value = (comObject, comObject.Object);
			dictionary_1[key] = value;
		}
		ID2D1SolidColorBrush item = value.Item2;
		float num = endX - startX;
		float num2 = endY - startY;
		float num3 = (float)Math.Sqrt(num * num + num2 * num2);
		if (num3 < step * 2f)
		{
			return;
		}
		float num4 = num / num3;
		float num5 = num2 / num3;
		float num6 = 0f - num5;
		float num7 = num4;
		float num8 = startX;
		float num9 = startY;
		bool flag = true;
		id2D1RenderTarget_0.GetFactory(out var factory);
		factory.CreatePathGeometry(out var pathGeometry);
		pathGeometry.Open(out var geometrySink);
		ID2D1GeometrySink iD2D1GeometrySink = geometrySink;
		iD2D1GeometrySink.BeginFigure(new D2D_POINT_2F(num8, num9 + (float)int_3), D2D1_FIGURE_BEGIN.D2D1_FIGURE_BEGIN_HOLLOW);
		while (true)
		{
			float num10 = num8 + num4 * step;
			float num11 = num9 + num5 * step;
			if (!((num10 - startX) * (num10 - startX) + (num11 - startY) * (num11 - startY) <= num3 * num3))
			{
				break;
			}
			if (!flag)
			{
				float num12 = num8 + num4 * step;
				float num13 = num9 + num5 * step;
				iD2D1GeometrySink.AddLine(new D2D_POINT_2F(num12, num13 + (float)int_3));
				num8 = num12;
				num9 = num13;
			}
			else
			{
				float num14 = num8 + num6 * crenelSize;
				float num15 = num9 + num7 * crenelSize;
				float num16 = num14 + num4 * step;
				float num17 = num15 + num5 * step;
				float num18 = num16 - num6 * crenelSize;
				float num19 = num17 - num7 * crenelSize;
				iD2D1GeometrySink.AddLine(new D2D_POINT_2F(num14, num15 + (float)int_3));
				iD2D1GeometrySink.AddLine(new D2D_POINT_2F(num16, num17 + (float)int_3));
				iD2D1GeometrySink.AddLine(new D2D_POINT_2F(num18, num19 + (float)int_3));
				num8 = num18;
				num9 = num19;
			}
			flag = !flag;
		}
		iD2D1GeometrySink.EndFigure(D2D1_FIGURE_END.D2D1_FIGURE_END_OPEN);
		iD2D1GeometrySink.Close();
		id2D1RenderTarget_0.DrawGeometry(pathGeometry, item, thickness, id2D1StrokeStyle_0);
	}

	public void DrawLine(Color color, float thickness, float startX, float startY, float endX, float endY, bool dashed = false)
	{
		if (Drawing)
		{
			D2D_POINT_2F point = new D2D_POINT_2F(startX, startY + (float)int_3);
			D2D_POINT_2F point2 = new D2D_POINT_2F(endX, endY + (float)int_3);
			int key = color.ToArgb();
			if (!dictionary_1.TryGetValue(key, out var value))
			{
				_D3DCOLORVALUE color2 = _D3DCOLORVALUE.FromArgb(color.A, color.R, color.G, color.B);
				D2D1_BRUSH_PROPERTIES value2 = new D2D1_BRUSH_PROPERTIES
				{
					opacity = 1f
				};
				IComObject<ID2D1SolidColorBrush> comObject = icomObject_2.CreateSolidColorBrush(color2, value2);
				value = (comObject, comObject.Object);
				dictionary_1[key] = value;
			}
			ID2D1SolidColorBrush item = value.Item2;
			ID2D1StrokeStyle strokeStyle = (dashed ? id2D1StrokeStyle_1 : id2D1StrokeStyle_0);
			id2D1RenderTarget_0.DrawLine(point, point2, item, thickness, strokeStyle);
		}
	}

	public void DrawDashedLine(Color color, Point[] points)
	{
		if (!Drawing)
		{
			return;
		}
		bool flag = true;
		for (uint num = 0u; num < points.Length; num++)
		{
			if (flag)
			{
				Point point = points[num];
				uint num2 = ((num < points.Length - 1) ? (num + 1) : 0u);
				Point point2 = points[num2];
				DrawLine(color, 1.5f, point.X, point.Y, point2.X, point2.Y);
			}
			flag = !flag;
		}
	}

	public unsafe void DrawGradientLine(Color color, float thickness, bool dashed, float startX, float startY, float endX, float endY)
	{
		if (!Drawing)
		{
			return;
		}
		startY += (float)int_3;
		endY += (float)int_3;
		D2D_POINT_2F d2D_POINT_2F = new D2D_POINT_2F(startX, startY);
		D2D_POINT_2F d2D_POINT_2F2 = new D2D_POINT_2F(endX, endY);
		if (!dictionary_2.TryGetValue(color, out var value))
		{
			D2D1_GRADIENT_STOP[] array = new D2D1_GRADIENT_STOP[2];
			array[0].position = 0f;
			array[0].color = _D3DCOLORVALUE.FromArgb(0, color.R, color.G, color.B);
			array[1].position = 1f;
			array[1].color = _D3DCOLORVALUE.FromArgb(byte.MaxValue, color.R, color.G, color.B);
			if (id2D1RenderTarget_0 == null)
			{
				id2D1RenderTarget_0 = icomObject_2.Object;
			}
			id2D1RenderTarget_0.CreateGradientStopCollection(array, 2, D2D1_GAMMA.D2D1_GAMMA_2_2, D2D1_EXTEND_MODE.D2D1_EXTEND_MODE_CLAMP, out var gradientStopCollection);
			D2D1_LINEAR_GRADIENT_BRUSH_PROPERTIES linearGradientBrushProperties = new D2D1_LINEAR_GRADIENT_BRUSH_PROPERTIES
			{
				startPoint = d2D_POINT_2F,
				endPoint = d2D_POINT_2F2
			};
			if (id2D1RenderTarget_0 == null)
			{
				id2D1RenderTarget_0 = icomObject_2.Object;
			}
			id2D1RenderTarget_0.CreateLinearGradientBrush(ref linearGradientBrushProperties, (IntPtr)(void*)null, gradientStopCollection, out value);
			new ComObject<ID2D1GradientStopCollection>(gradientStopCollection).Dispose();
			dictionary_2.Add(color, value);
		}
		value.SetStartPoint(d2D_POINT_2F);
		value.SetEndPoint(d2D_POINT_2F2);
		if (id2D1RenderTarget_0 == null)
		{
			id2D1RenderTarget_0 = icomObject_2.Object;
		}
		id2D1RenderTarget_0.DrawLine(d2D_POINT_2F, d2D_POINT_2F2, value, thickness, (!dashed) ? id2D1StrokeStyle_0 : id2D1StrokeStyle_1);
	}

	public void FillGeometry(PointF[] points, Color color)
	{
		if (Drawing)
		{
			IComObject<ID2D1PathGeometry1> comObject = icomObject_1.CreatePathGeometry();
			IComObject<ID2D1SimplifiedGeometrySink> comObject2 = comObject.Open();
			D2D_POINT_2F startPoint = new D2D_POINT_2F(points[0].X + (float)int_2, points[0].Y + (float)int_3);
			comObject2.Object.BeginFigure(startPoint, D2D1_FIGURE_BEGIN.D2D1_FIGURE_BEGIN_FILLED);
			for (uint num = 1u; num < points.Length; num++)
			{
				startPoint = new D2D_POINT_2F(points[num].X + (float)int_2, points[num].Y + (float)int_3);
				comObject2.AddLine(startPoint);
			}
			comObject2.Object.EndFigure(D2D1_FIGURE_END.D2D1_FIGURE_END_CLOSED);
			comObject2.Object.Close();
			comObject2.Dispose();
			D2D1_BRUSH_PROPERTIES value = new D2D1_BRUSH_PROPERTIES
			{
				opacity = 1f
			};
			_D3DCOLORVALUE color2 = _D3DCOLORVALUE.FromArgb(color.A, color.R, color.G, color.B);
			IComObject<ID2D1SolidColorBrush> comObject3 = icomObject_2.CreateSolidColorBrush(color2, value);
			if (id2D1RenderTarget_0 == null)
			{
				id2D1RenderTarget_0 = icomObject_2.Object;
			}
			id2D1RenderTarget_0.FillGeometry(comObject.Object, comObject3.Object, null);
			comObject.Dispose();
			comObject3.Dispose();
		}
	}

	public void FillRing(Point[] outer, Point[] inner, Color color)
	{
		if (!Drawing)
		{
			return;
		}
		IComObject<ID2D1PathGeometry1> comObject = icomObject_1.CreatePathGeometry();
		IComObject<ID2D1SimplifiedGeometrySink> comObject2 = comObject.Open();
		D2D_POINT_2F startPoint = new D2D_POINT_2F(outer[0].X + int_2, outer[0].Y + int_3);
		comObject2.Object.BeginFigure(startPoint, D2D1_FIGURE_BEGIN.D2D1_FIGURE_BEGIN_FILLED);
		for (uint num = 1u; num < outer.Length; num++)
		{
			startPoint = new D2D_POINT_2F(outer[num].X + int_2, outer[num].Y + int_3);
			comObject2.AddLine(startPoint);
		}
		comObject2.Object.EndFigure(D2D1_FIGURE_END.D2D1_FIGURE_END_CLOSED);
		comObject2.Object.Close();
		IComObject<ID2D1PathGeometry1> comObject3 = icomObject_1.CreatePathGeometry();
		IComObject<ID2D1SimplifiedGeometrySink> comObject4 = comObject3.Open();
		startPoint = new D2D_POINT_2F(inner[0].X + int_2, inner[0].Y + int_3);
		comObject4.Object.BeginFigure(startPoint, D2D1_FIGURE_BEGIN.D2D1_FIGURE_BEGIN_FILLED);
		for (uint num2 = 1u; num2 < inner.Length; num2++)
		{
			startPoint = new D2D_POINT_2F(inner[num2].X + int_2, inner[num2].Y + int_3);
			comObject4.AddLine(startPoint);
		}
		comObject4.Object.EndFigure(D2D1_FIGURE_END.D2D1_FIGURE_END_CLOSED);
		comObject4.Object.Close();
		IComObject<ID2D1PathGeometry1> comObject5 = icomObject_1.CreatePathGeometry();
		IComObject<ID2D1SimplifiedGeometrySink> comObject6 = comObject5.Open();
		comObject.Object.CombineWithGeometry(comObject3.Object, D2D1_COMBINE_MODE.D2D1_COMBINE_MODE_XOR, IntPtr.Zero, 1f, comObject6.Object);
		comObject6.Object.Close();
		D2D1_BRUSH_PROPERTIES value = new D2D1_BRUSH_PROPERTIES
		{
			opacity = 1f
		};
		_D3DCOLORVALUE color2 = _D3DCOLORVALUE.FromArgb(color.A, color.R, color.G, color.B);
		int key = color.ToArgb();
		ID2D1SolidColorBrush iD2D1SolidColorBrush = null;
		if (dictionary_1.TryGetValue(key, out var value2))
		{
			IComObject<ID2D1SolidColorBrush> comObject7;
			(comObject7, iD2D1SolidColorBrush) = value2;
		}
		else
		{
			IComObject<ID2D1SolidColorBrush> comObject7 = icomObject_2.CreateSolidColorBrush(color2, value);
			if (comObject7 != null)
			{
				iD2D1SolidColorBrush = comObject7.Object;
				dictionary_1.Add(key, (comObject7, iD2D1SolidColorBrush));
			}
		}
		if (id2D1RenderTarget_0 == null)
		{
			id2D1RenderTarget_0 = icomObject_2.Object;
		}
		id2D1RenderTarget_0.FillGeometry(comObject5.Object, iD2D1SolidColorBrush, null);
		comObject2.Dispose();
		comObject.Dispose();
		comObject3.Dispose();
		comObject4.Dispose();
		comObject5.Dispose();
		comObject6.Dispose();
	}

	private IComObject<ID2D1PathGeometry> method_22(Point[] point_0)
	{
		IComObject<ID2D1PathGeometry1> comObject = icomObject_1.CreatePathGeometry();
		IComObject<ID2D1SimplifiedGeometrySink> comObject2 = comObject.Open();
		try
		{
			if (comObject2 == null)
			{
				return comObject;
			}
			ID2D1SimplifiedGeometrySink iD2D1SimplifiedGeometrySink = comObject2.Object;
			D2D_POINT_2F startPoint = new D2D_POINT_2F(point_0[0].X + int_2, point_0[0].Y + int_3);
			iD2D1SimplifiedGeometrySink.BeginFigure(startPoint, D2D1_FIGURE_BEGIN.D2D1_FIGURE_BEGIN_FILLED);
			int num = point_0.Length - 1;
			int num2;
			if (d2D_POINT_2F_0.Length < num)
			{
				d2D_POINT_2F_0 = new D2D_POINT_2F[num];
				num2 = 1;
			}
			else
			{
				num2 = 1;
			}
			for (uint num3 = (uint)num2; num3 < point_0.Length; num3++)
			{
				d2D_POINT_2F_0[num3 - 1] = new D2D_POINT_2F(point_0[num3].X + int_2, point_0[num3].Y + int_3);
			}
			iD2D1SimplifiedGeometrySink.AddLines(d2D_POINT_2F_0, num);
			iD2D1SimplifiedGeometrySink.EndFigure(D2D1_FIGURE_END.D2D1_FIGURE_END_CLOSED);
			iD2D1SimplifiedGeometrySink.Close();
		}
		catch (Exception ex)
		{
			ex.Data.Add("Error at 342986743589674398567", ex.Message);
			GameGeneral.WriteExceptionsToLog(ex);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
		}
		finally
		{
			comObject2.Dispose();
		}
		return comObject;
	}

	public void DrawFilledCombined(List<Point[]> polygons, Color color)
	{
		RenderEventHandler?.Handle(RenderEvent.CombinePolygons, polygons);
		if (Drawing && polygons.Count != 0)
		{
			D2D1_BRUSH_PROPERTIES value = new D2D1_BRUSH_PROPERTIES
			{
				opacity = 1f
			};
			_D3DCOLORVALUE color2 = _D3DCOLORVALUE.FromArgb(color.A, color.R, color.G, color.B);
			IComObject<ID2D1SolidColorBrush> comObject = icomObject_2.CreateSolidColorBrush(color2, value);
			IComObject<ID2D1PathGeometry1> comObject2 = method_23(polygons);
			if (id2D1RenderTarget_0 == null)
			{
				id2D1RenderTarget_0 = icomObject_2.Object;
			}
			id2D1RenderTarget_0.FillGeometry(comObject2.Object, comObject.Object, null);
			comObject2.Dispose();
			comObject.Dispose();
		}
	}

	public void DrawCombinedPolygon(List<Point[]> polygons, Color color, float thickness, bool dashed)
	{
		RenderEventHandler?.Handle(RenderEvent.CombinePolygons, polygons);
		if (Drawing && polygons.Count != 0)
		{
			thickness *= 1.5f;
			D2D1_BRUSH_PROPERTIES value = new D2D1_BRUSH_PROPERTIES
			{
				opacity = 1f
			};
			_D3DCOLORVALUE color2 = _D3DCOLORVALUE.FromArgb(color.A, color.R, color.G, color.B);
			IComObject<ID2D1SolidColorBrush> comObject = icomObject_2.CreateSolidColorBrush(color2, value);
			IComObject<ID2D1PathGeometry1> comObject2 = method_23(polygons);
			ID2D1StrokeStyle strokeStyle = (dashed ? id2D1StrokeStyle_1 : id2D1StrokeStyle_0);
			if (id2D1RenderTarget_0 == null)
			{
				id2D1RenderTarget_0 = icomObject_2.Object;
			}
			id2D1RenderTarget_0.DrawGeometry(comObject2.Object, comObject.Object, thickness, strokeStyle);
			comObject2.Dispose();
			comObject.Dispose();
		}
	}

	private IComObject<ID2D1PathGeometry1> method_23(List<Point[]> list_3)
	{
		List<IComObject<ID2D1Geometry>> list = new List<IComObject<ID2D1Geometry>>();
		int num = 8;
		int num2 = 0;
		while (list_3.Count > num2 * num)
		{
			int num3 = num2++ * num;
			List<Point[]> range = list_3.GetRange(num3, Math.Min(num, list_3.Count - num3));
			list.Add(method_24(range));
		}
		return method_25(list);
	}

	private IComObject<ID2D1PathGeometry1> method_24(List<Point[]> list_3)
	{
		List<IComObject<ID2D1Geometry>> list = new List<IComObject<ID2D1Geometry>>(list_3.Count);
		for (int i = 0; i < list_3.Count; i++)
		{
			IComObject<ID2D1PathGeometry> item = method_22(list_3[i]);
			list.Add(item);
		}
		return method_25(list);
	}

	private unsafe IComObject<ID2D1PathGeometry1> method_25(List<IComObject<ID2D1Geometry>> list_3)
	{
		int count = list_3.Count;
		for (int i = 0; i < count; i++)
		{
			list_2.Add(list_3[i].Object);
		}
		IComObject<ID2D1GeometryGroup> comObject = icomObject_1.CreateGeometryGroup(D2D1_FILL_MODE.D2D1_FILL_MODE_WINDING, list_2);
		for (int j = 0; j < count; j++)
		{
			list_3[j].Dispose();
		}
		IComObject<ID2D1PathGeometry1> comObject2 = icomObject_1.CreatePathGeometry();
		IComObject<ID2D1SimplifiedGeometrySink> comObject3 = comObject2.Open();
		try
		{
			comObject.Object.Outline((IntPtr)(void*)null, 0f, comObject3.Object);
		}
		catch (Exception ex)
		{
			ex.Data.Add("Error at 34905683476940356843908750968", ex.Message);
			GameGeneral.WriteExceptionsToLog(ex);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
		}
		finally
		{
			comObject3.Object.Close();
			comObject3.Dispose();
			comObject.Dispose();
			list_2.Clear();
		}
		return comObject2;
	}

	private void DrawLine(Vertex[] vertices, uint[] indices, D3D_PRIMITIVE_TOPOLOGY topology)
	{
		DrawLine(null, vertices, indices, topology, blendable: false, 1f);
	}

	private void DrawLine(string id, Vertex[] vertices, uint[] indices, D3D_PRIMITIVE_TOPOLOGY topology, bool blendable, float alpha)
	{
		id3DUserDefinedAnnotation_0.BeginEvent("DrawLine");
		DrawParameters drawParameters_ = ((id == null || !dictionary_0.ContainsKey(id)) ? CreateLineDrawParemeters(id, vertices, indices, topology, blendable) : dictionary_0[id]);
		drawParameters_.Hint = alpha;
		method_20(drawParameters_);
		id3DUserDefinedAnnotation_0.EndEvent();
	}

	internal DrawParameters CreateLineDrawParemeters(string id, Vertex[] vertices, uint[] indices, D3D_PRIMITIVE_TOPOLOGY topology, bool blendable)
	{
		Mesh mesh_ = new Mesh
		{
			vertices = vertices,
			indices = indices
		};
		DrawParameters drawParameters_ = WorldDrawParameters;
		method_6(mesh_, ref drawParameters_);
		drawParameters_.Layer = (blendable ? Layer.BlendableLine : Layer.Line);
		drawParameters_.Topology = topology;
		if (id == null)
		{
			drawParameters_.Disposable = true;
		}
		else
		{
			drawParameters_.Disposable = false;
			dictionary_0[id] = drawParameters_;
		}
		return drawParameters_;
	}

	public void DrawLineStrip(Vertex[] vertices, uint[] indices)
	{
		DrawLine(vertices, indices, D3D_PRIMITIVE_TOPOLOGY.D3D_PRIMITIVE_TOPOLOGY_LINESTRIP);
	}

	public void DrawLineStrip(string id, Vertex[] vertices, uint[] indices)
	{
		DrawLine(id, vertices, indices, D3D_PRIMITIVE_TOPOLOGY.D3D_PRIMITIVE_TOPOLOGY_LINESTRIP, blendable: false, 1f);
	}

	public void DrawLineList(Vertex[] vertices, uint[] indices)
	{
		DrawLine(vertices, indices, D3D_PRIMITIVE_TOPOLOGY.D3D_PRIMITIVE_TOPOLOGY_LINELIST);
	}

	public void DrawLineList(string id, Vertex[] vertices, uint[] indices, float alpha)
	{
		DrawLine(id, vertices, indices, D3D_PRIMITIVE_TOPOLOGY.D3D_PRIMITIVE_TOPOLOGY_LINELIST, blendable: true, alpha);
	}

	public void RemoveDrawLineList(string id)
	{
		if (dictionary_0.ContainsKey(id))
		{
			dictionary_0.Remove(id);
		}
	}

	public static Vector4 IntToVector4(int value)
	{
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		Color color = Color.FromArgb(value);
		return new Vector4((float)(int)color.R / 256f, (float)(int)color.G / 256f, (float)(int)color.B / 256f, (float)(int)color.A / 256f);
	}

	private int method_26(int int_10)
	{
		return int_10 - int_10 % 4;
	}

	public void LoadCustomOverlay(string key, Bitmap bitmap, double geolocation_pxLenghtX, double geoLocation_pxLenghtY, double geoLocation_startX, double geoLocation_startY)
	{
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		List<(Bitmap, double, double, double, double)> list = new List<(Bitmap, double, double, double, double)>();
		int num = ((Image)bitmap).Height;
		int num2 = ((Image)bitmap).Width;
		if (num2 < 10000 && num < 10000)
		{
			if (num > 4)
			{
				num = method_26(num);
			}
			if (num2 > 4)
			{
				num2 = method_26(num2);
			}
			if (num2 != ((Image)bitmap).Width || num != ((Image)bitmap).Height)
			{
				bitmap = bitmap.Clone(new Rectangle(0, 0, num2, num), ((Image)bitmap).PixelFormat);
			}
			list = new List<(Bitmap, double, double, double, double)> { (bitmap, geolocation_pxLenghtX, geoLocation_pxLenghtY, geoLocation_startX, geoLocation_startY) };
		}
		else
		{
			int num3 = (int)Math.Ceiling((double)num2 / 10000.0);
			int num4 = (int)Math.Ceiling((double)num / 10000.0);
			int num5 = method_26((int)Math.Round((double)num2 / (double)num3));
			int num6 = method_26((int)Math.Round((double)num / (double)num4));
			for (int i = 0; i < num3; i++)
			{
				for (int j = 0; j < num4; j++)
				{
					int width = num5;
					if (i == num3 - 1)
					{
						width = method_26(num2 - i * num5);
					}
					int height = num6;
					if (j == num4 - 1)
					{
						height = method_26(num - j * num6);
					}
					Bitmap item = bitmap.Clone(new Rectangle(num5 * i, num6 * j, width, height), ((Image)bitmap).PixelFormat);
					list.Add((item, geolocation_pxLenghtX, geoLocation_pxLenghtY, geoLocation_startX + (double)i * geolocation_pxLenghtX * (double)num5, geoLocation_startY + (double)j * geoLocation_pxLenghtY * (double)num6));
				}
			}
		}
		LoadCustomOverlay(key, list);
		for (int k = 0; k < list.Count; k++)
		{
			((Image)list[k].Item1).Dispose();
		}
	}

	public void LoadCustomOverlay(string key, List<(Bitmap bmp, double a, double e, double c, double f)> bitmapsWithGeolocationData)
	{
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		List<DrawParameters> list = new List<DrawParameters>();
		for (int i = 0; i < bitmapsWithGeolocationData.Count; i++)
		{
			(Bitmap, double, double, double, double) tuple = bitmapsWithGeolocationData[i];
			IComObject<ID3D11ShaderResourceView> comObject = DXDevice.TileCache.BuildTexture(key + i.ToString("000"), tuple.Item1, synchronous: true, shadow: false);
			if (comObject == null)
			{
				MessageBox.Show("An error occurred while building texture", "");
				continue;
			}
			DrawParameters worldDrawParameters = WorldDrawParameters;
			worldDrawParameters.ShaderResourceView = comObject;
			worldDrawParameters.uWidth = (float)(tuple.Item2 * (double)((Image)tuple.Item1).Width) / 360f;
			worldDrawParameters.u = (float)(tuple.Item4 + 180.0) / 360f;
			worldDrawParameters.vWidth = (float)((0.0 - tuple.Item3) * (double)((Image)tuple.Item1).Height) / 180f;
			worldDrawParameters.v = 1f - (float)(tuple.Item5 + 90.0) / 180f;
			worldDrawParameters.Disposable = false;
			worldDrawParameters.Draw = true;
			worldDrawParameters.Level = 1u;
			list.Add(worldDrawParameters);
		}
		orderedDictionary_0[key] = list;
	}

	public void ToggleCustomOverlay(string imageFile)
	{
		if (orderedDictionary_0.Contains(imageFile))
		{
			List<DrawParameters> list = (List<DrawParameters>)orderedDictionary_0[imageFile];
			for (int i = 0; i < list.Count; i++)
			{
				DrawParameters value = list[i];
				value.Draw = !value.Draw;
				list[i] = value;
			}
			return;
		}
		throw new Exception("Unrecognized custom overlay: " + imageFile);
	}

	public void RemoveCustomOverlay(string imageFile)
	{
		if (orderedDictionary_0.Contains(imageFile))
		{
			List<DrawParameters> list = (List<DrawParameters>)orderedDictionary_0[imageFile];
			for (int i = 0; i < list.Count; i++)
			{
				DXDevice.TextureCache.ShaderResourceViews.Remove(imageFile + i.ToString("000"));
				DrawParameters drawParameters = list[i];
				drawParameters.ShaderResourceView.Object.GetResource(out var ppResource);
				((IDisposable)new ComObject<ID3D11Resource>(ppResource)).Dispose();
				drawParameters.ShaderResourceView.Dispose();
				drawParameters.ShaderResourceView = null;
			}
			orderedDictionary_0.Remove(imageFile);
			return;
		}
		throw new Exception("Unrecognized custom overlay: " + imageFile);
	}

	public string[] CustomOverlayNames()
	{
		ICollection keys = orderedDictionary_0.Keys;
		string[] array = new string[orderedDictionary_0.Count];
		keys.CopyTo(array, 0);
		return array;
	}

	public bool IsVisibleCustomOverlay(string imageFile)
	{
		if (!orderedDictionary_0.Contains(imageFile))
		{
			throw new Exception("Unrecognized custom overlay: " + imageFile);
		}
		return ((List<DrawParameters>)orderedDictionary_0[imageFile])[0].Draw;
	}

	public void MoveUpCustomOverlay(string imageFile)
	{
		if (orderedDictionary_0.Contains(imageFile))
		{
			ICollection keys = orderedDictionary_0.Keys;
			int num = 0;
			foreach (string item in keys)
			{
				if (!(imageFile == item))
				{
					num++;
					continue;
				}
				break;
			}
			object value = orderedDictionary_0[num];
			orderedDictionary_0.RemoveAt(num);
			num = Math.Max(0, num - 1);
			orderedDictionary_0.Insert(num, imageFile, value);
			return;
		}
		throw new Exception("Unrecognized custom overlay: " + imageFile);
	}

	public void MoveDownCustomOverlay(string imageFile)
	{
		if (!orderedDictionary_0.Contains(imageFile))
		{
			throw new Exception("Unrecognized custom overlay: " + imageFile);
		}
		ICollection keys = orderedDictionary_0.Keys;
		int num = 0;
		foreach (string item in keys)
		{
			if (!(imageFile == item))
			{
				num++;
				continue;
			}
			break;
		}
		object value = orderedDictionary_0[num];
		orderedDictionary_0.RemoveAt(num);
		num = Math.Min(orderedDictionary_0.Count, ++num);
		orderedDictionary_0.Insert(num, imageFile, value);
	}

	internal static float ReadWorldFileParameterAsFloat(StreamReader reader)
	{
		return float.Parse(reader.ReadLine(), CultureInfo.InvariantCulture);
	}

	internal int CountTiles()
	{
		return DXDevice.TileCache.Tiles.Count;
	}

	internal int CountLoadedTiles()
	{
		return DXDevice.TileCache.TilesLoaded;
	}

	internal int CountDrawingTiles()
	{
		return DXDevice.TileCache.TilesDrawn;
	}

	public void ClearTiles()
	{
		for (int i = 0; i < DXDevice.TileCache.TileTasks.Count; i++)
		{
			DXDevice.TileCache.TileTasks[i].TokenSource.Cancel();
		}
		while (DXDevice.TileCache.TileTasks.Count > 0)
		{
			for (int j = 0; j < DXDevice.TileCache.TileTasks.Count; j++)
			{
				if (DXDevice.TileCache.TileTasks[j].Task.Status >= TaskStatus.RanToCompletion)
				{
					DXDevice.TileCache.TileTasks.RemoveAt(j);
				}
			}
		}
		TextureParameters result;
		while (DXDevice.TileCache.TileTextures.TryDequeue(out result))
		{
			result.Collector.Free();
		}
		foreach (KeyValuePair<string, DrawParameters> tile in DXDevice.TileCache.Tiles)
		{
			DXDevice.TileCache.TryRemoveTile(tile.Key);
		}
		DXDevice.TileCache.TileHistory.Clear();
	}

	public void HandleKeypress(char key)
	{
		RenderEventHandler?.Handle(RenderEvent.Keypress, key);
	}

	public int CountDrawnTiles()
	{
		return CountDrawingTiles();
	}

	public int CountLoadTiles()
	{
		return CountLoadedTiles();
	}

	public int CountAllTiles()
	{
		return CountTiles();
	}

	private Mesh method_27()
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		float num = 25512548f;
		Vertex[] vertices = new Vertex[4]
		{
			new Vertex(new Vector3(-25512548f, -25512548f, 0f), new Vector4(0f, 0f, 0f, 0f), new Vector2(0f, 0f)),
			new Vertex(new Vector3(-25512548f, num, 0f), new Vector4(0f, 0f, 0f, 0f), new Vector2(0f, 1f)),
			new Vertex(new Vector3(num, num, 0f), new Vector4(0f, 0f, 0f, 0f), new Vector2(1f, 1f)),
			new Vertex(new Vector3(num, -25512548f, 0f), new Vector4(0f, 0f, 0f, 0f), new Vector2(1f, 0f))
		};
		uint[] indices = new uint[6] { 0u, 1u, 2u, 0u, 2u, 3u };
		return new Mesh
		{
			vertices = vertices,
			indices = indices
		};
	}

	static Main()
	{
		Class72.smethod_20();
	}
}
