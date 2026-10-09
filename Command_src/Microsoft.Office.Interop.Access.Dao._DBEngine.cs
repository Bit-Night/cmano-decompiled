using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Access.Dao;

[ComImport]
[TypeIdentifier]
[DefaultMember("Workspaces")]
[CompilerGenerated]
[Guid("00000021-0000-0010-8000-00AA006D2EA4")]
public interface _DBEngine : _DAO
{
	void _VtblGap1_8();

	[DispId(0)]
	Workspaces Workspaces
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(0)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	void _VtblGap2_6();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610809358)]
	[return: MarshalAs(UnmanagedType.Interface)]
	Database OpenDatabase([In][MarshalAs(UnmanagedType.BStr)] string Name, [Optional][In][MarshalAs(UnmanagedType.Struct)] object Options, [Optional][In][MarshalAs(UnmanagedType.Struct)] object ReadOnly, [Optional][In][MarshalAs(UnmanagedType.Struct)] object Connect);
}
