using System;
using System.Windows.Forms;

namespace ScintillaNET.Demo.Utils;

public sealed class HotKeyManager
{
	public static bool Enable;

	public static void AddHotKey(Form form, Action function, Keys key, bool ctrl = false, bool shift = false, bool alt = false)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		form.KeyPreview = true;
		((Control)form).KeyDown += (KeyEventHandler)delegate(object sender, KeyEventArgs e)
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			if (IsHotkey(e, key, ctrl, shift, alt))
			{
				function();
			}
		};
	}

	public static bool IsHotkey(KeyEventArgs eventData, Keys key, bool ctrl = false, bool shift = false, bool alt = false)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		if (eventData.KeyCode == key && eventData.Control == ctrl && eventData.Shift == shift)
		{
			return eventData.Alt == alt;
		}
		return false;
	}

	static HotKeyManager()
	{
		Class72.smethod_20();
		Enable = true;
	}
}
