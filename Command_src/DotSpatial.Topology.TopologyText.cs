using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace DotSpatial.Topology;

[CompilerGenerated]
[DebuggerNonUserCode]
[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
internal class TopologyText
{
	private static ResourceManager resourceManager_0;

	private static CultureInfo cultureInfo_0;

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static ResourceManager ResourceManager
	{
		get
		{
			if (resourceManager_0 == null)
			{
				resourceManager_0 = new ResourceManager("DotSpatial.Topology.TopologyText", typeof(TopologyText).Assembly);
			}
			return resourceManager_0;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static CultureInfo Culture
	{
		get
		{
			return cultureInfo_0;
		}
		set
		{
			cultureInfo_0 = value;
		}
	}

	internal static string ArgumentCannotBeNegative_S => ResourceManager.GetString("ArgumentCannotBeNegative_S", cultureInfo_0);

	internal static string ArgumentCouldNotBeCast_S1_S2 => ResourceManager.GetString("ArgumentCouldNotBeCast_S1_S2", cultureInfo_0);

	internal static string ArgumentOutOfRangeException_S => ResourceManager.GetString("ArgumentOutOfRangeException_S", cultureInfo_0);

	internal static string ClassNotSupportedException_S => ResourceManager.GetString("ClassNotSupportedException_S", cultureInfo_0);

	internal static string CoordinateMismatchException => ResourceManager.GetString("CoordinateMismatchException", cultureInfo_0);

	internal static string DuplicateEdgeException => ResourceManager.GetString("DuplicateEdgeException", cultureInfo_0);

	internal static string GeometryCollectionNotSupportedException => ResourceManager.GetString("GeometryCollectionNotSupportedException", cultureInfo_0);

	internal static string InsufficientDimensions => ResourceManager.GetString("InsufficientDimensions", cultureInfo_0);

	internal static string InsufficientDimensions_S => ResourceManager.GetString("InsufficientDimensions_S", cultureInfo_0);

	internal static string InvalidOctantException_S => ResourceManager.GetString("InvalidOctantException_S", cultureInfo_0);

	internal static string KeyDuplicateException => ResourceManager.GetString("KeyDuplicateException", cultureInfo_0);

	internal static string KeyMissingException => ResourceManager.GetString("KeyMissingException", cultureInfo_0);

	internal static string KeySizeException => ResourceManager.GetString("KeySizeException", cultureInfo_0);

	internal static string NullEdgeException => ResourceManager.GetString("NullEdgeException", cultureInfo_0);

	internal static string PolygonException_HoleElementNull => ResourceManager.GetString("PolygonException_HoleElementNull", cultureInfo_0);

	internal static string PolygonException_ShellEmptyButHolesNot => ResourceManager.GetString("PolygonException_ShellEmptyButHolesNot", cultureInfo_0);

	internal static string ReadOnlyException => ResourceManager.GetString("ReadOnlyException", cultureInfo_0);

	internal static string ShellHoleIdentityException => ResourceManager.GetString("ShellHoleIdentityException", cultureInfo_0);

	internal static string ShouldNeverReachHereException => ResourceManager.GetString("ShouldNeverReachHereException", cultureInfo_0);

	internal static string SideLocationConflict => ResourceManager.GetString("SideLocationConflict", cultureInfo_0);

	internal static string SingleNullSide => ResourceManager.GetString("SingleNullSide", cultureInfo_0);

	internal static string TopologyException_Depth => ResourceManager.GetString("TopologyException_Depth", cultureInfo_0);

	internal static string TwoHorizontalEdgesException => ResourceManager.GetString("TwoHorizontalEdgesException", cultureInfo_0);

	internal static string UnsupportedGeometryException => ResourceManager.GetString("UnsupportedGeometryException", cultureInfo_0);

	internal TopologyText()
	{
	}

	static TopologyText()
	{
		Class72.smethod_20();
		Class77.smethod_3();
	}
}
