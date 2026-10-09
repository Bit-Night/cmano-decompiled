using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Access.Dao;

[ComImport]
[CompilerGenerated]
[Guid("00000031-0000-0010-8000-00AA006D2EA4")]
[DefaultMember("Fields")]
[TypeIdentifier]
public interface Recordset : _DAO
{
	void _VtblGap1_6();

	[DispId(105)]
	bool EOF
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(105)]
		get;
	}

	void _VtblGap2_31();

	[DispId(0)]
	Fields Fields
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(0)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	void _VtblGap3_3();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(133)]
	void Close();

	void _VtblGap4_9();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(143)]
	void MoveNext();
}
