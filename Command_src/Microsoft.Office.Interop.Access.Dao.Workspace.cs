using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Access.Dao;

[ComImport]
[CompilerGenerated]
[DefaultMember("Databases")]
[Guid("00000039-0000-0010-8000-00AA006D2EA4")]
[TypeIdentifier]
public interface Workspace : _DAO
{
	void _VtblGap1_8();

	[DispId(0)]
	Databases Databases
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(0)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}
}
