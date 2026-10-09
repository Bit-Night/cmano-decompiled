using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Access.Dao;

[ComImport]
[CompilerGenerated]
[Guid("0000003B-0000-0010-8000-00AA006D2EA4")]
[TypeIdentifier]
public interface Workspaces : _DynaCollection
{
	void _VtblGap1_5();

	[DispId(0)]
	Workspace this[[In][MarshalAs(UnmanagedType.Struct)] object Item]
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(0)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}
}
