using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace Command_Core.SendFileTo;

public sealed class MAPI
{
	public enum howTo
	{
		MAPI_ORIG,
		MAPI_TO,
		MAPI_CC,
		MAPI_BCC
	}

	private readonly string[] string_0;

	private List<MapiRecipDesc> list_0;

	private List<string> list_1;

	private int int_0;

	public MAPI()
	{
		string_0 = new string[27]
		{
			"OK [0]", "User abort [1]", "General MAPI failure [2]", "MAPI login failure [3]", "Disk full [4]", "Insufficient memory [5]", "Access denied [6]", "-unknown- [7]", "Too many sessions [8]", "Too many files were specified [9]",
			"Too many recipients were specified [10]", "A specified attachment was not found [11]", "Attachment open failure [12]", "Attachment write failure [13]", "Unknown recipient [14]", "Bad recipient type [15]", "No messages [16]", "Invalid message [17]", "Text too large [18]", "Invalid session [19]",
			"Type not supported [20]", "A recipient was specified ambiguously [21]", "Message in use [22]", "Network failure [23]", "Invalid edit fields [24]", "Invalid recipients [25]", "Not supported [26]"
		};
		list_0 = new List<MapiRecipDesc>();
		list_1 = new List<string>();
		int_0 = 0;
	}

	internal bool AddRecipientTo(string email)
	{
		return method_1(email, howTo.MAPI_TO);
	}

	internal bool AddRecipientCC(string email)
	{
		return method_1(email, howTo.MAPI_TO);
	}

	internal bool AddRecipientBCC(string email)
	{
		return method_1(email, howTo.MAPI_TO);
	}

	public void AddAttachment(string strAttachmentFileName)
	{
		list_1.Add(strAttachmentFileName);
	}

	internal int SendMailPopup(string strSubject, string strBody)
	{
		return method_0(strSubject, strBody, 9);
	}

	internal int SendMailDirect(string strSubject, string strBody)
	{
		return method_0(strSubject, strBody, 1);
	}

	[DllImport("MAPI32.DLL")]
	private static extern int MAPISendMail(IntPtr intptr_0, IntPtr intptr_1, MapiMessage mapiMessage_0, int int_1, int int_2);

	private int method_0(string string_1, string string_2, int int_1)
	{
		MapiMessage mapiMessage_ = new MapiMessage();
		mapiMessage_.subject = string_1;
		mapiMessage_.noteText = string_2;
		mapiMessage_.recips = method_2(ref mapiMessage_.recipCount);
		mapiMessage_.files = method_3(ref mapiMessage_.fileCount);
		int_0 = MAPISendMail(new IntPtr(0), new IntPtr(0), mapiMessage_, int_1, 0);
		if (int_0 > 1)
		{
			GameGeneral.SendMessageBoxToUI("MAPISendMail failed! " + GetLastError(), null);
		}
		method_4(ref mapiMessage_);
		return int_0;
	}

	private bool method_1(string string_1, howTo howTo_0)
	{
		MapiRecipDesc mapiRecipDesc = new MapiRecipDesc();
		mapiRecipDesc.recipClass = (int)howTo_0;
		mapiRecipDesc.name = string_1;
		list_0.Add(mapiRecipDesc);
		return true;
	}

	private IntPtr method_2(ref int int_1)
	{
		int_1 = 0;
		if (list_0.Count == 0)
		{
			return (IntPtr)0;
		}
		int num = Marshal.SizeOf(typeof(MapiRecipDesc));
		IntPtr intPtr = Marshal.AllocHGlobal(list_0.Count * num);
		int num2 = (int)intPtr;
		foreach (MapiRecipDesc item in list_0)
		{
			Marshal.StructureToPtr(item, (IntPtr)num2, fDeleteOld: false);
			num2 += num;
		}
		int_1 = list_0.Count;
		return intPtr;
	}

	private IntPtr method_3(ref int int_1)
	{
		int_1 = 0;
		if (list_1 != null)
		{
			if (!((list_1.Count <= 0) | (list_1.Count > 20)))
			{
				int num = Marshal.SizeOf(typeof(MapiFileDesc));
				IntPtr intPtr = Marshal.AllocHGlobal(list_1.Count * num);
				MapiFileDesc mapiFileDesc = new MapiFileDesc();
				mapiFileDesc.position = -1;
				int num2 = (int)intPtr;
				foreach (string item in list_1)
				{
					mapiFileDesc.name = Path.GetFileName(item);
					mapiFileDesc.path = item;
					Marshal.StructureToPtr(mapiFileDesc, (IntPtr)num2, fDeleteOld: false);
					num2 += num;
				}
				int_1 = list_1.Count;
				return intPtr;
			}
			return (IntPtr)0;
		}
		return (IntPtr)0;
	}

	private void method_4(ref MapiMessage mapiMessage_0)
	{
		int num = Marshal.SizeOf(typeof(MapiRecipDesc));
		int num2 = 0;
		if (mapiMessage_0.recips != IntPtr.Zero)
		{
			num2 = (int)mapiMessage_0.recips;
			int num3 = mapiMessage_0.recipCount - 1;
			int num5 = default(int);
			int num4 = num5 + 1;
			for (num5 = 0; ((num4 >> 31) ^ num5) <= ((num4 >> 31) ^ num3); num5 += num4)
			{
				Marshal.DestroyStructure((IntPtr)num2, typeof(MapiRecipDesc));
				num2 += num;
			}
			Marshal.FreeHGlobal(mapiMessage_0.recips);
		}
		if (mapiMessage_0.files != IntPtr.Zero)
		{
			num = Marshal.SizeOf(typeof(MapiFileDesc));
			num2 = (int)mapiMessage_0.files;
			int num6 = mapiMessage_0.fileCount - 1;
			int num8 = default(int);
			int num7 = num8 + 1;
			for (num8 = 0; ((num7 >> 31) ^ num8) <= ((num7 >> 31) ^ num6); num8 += num7)
			{
				Marshal.DestroyStructure((IntPtr)num2, typeof(MapiFileDesc));
				num2 += num;
			}
			Marshal.FreeHGlobal(mapiMessage_0.files);
		}
		list_0.Clear();
		list_1.Clear();
		int_0 = 0;
	}

	internal string GetLastError()
	{
		if (int_0 > 26)
		{
			return "MAPI error [" + int_0 + "]";
		}
		return string_0[int_0];
	}

	static MAPI()
	{
		Class72.smethod_20();
	}
}
