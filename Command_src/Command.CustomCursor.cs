using System.Collections.Generic;
using System.Windows.Forms;
using Command.My.Resources;

namespace Command;

public sealed class CustomCursor
{
	private static CustomCursor customCursor_0;

	public Dictionary<CursorType, Cursor> Cursors;

	static CustomCursor()
	{
		Class72.smethod_20();
		customCursor_0 = null;
	}

	private CustomCursor()
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected O, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected O, but got Unknown
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Expected O, but got Unknown
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected O, but got Unknown
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Expected O, but got Unknown
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Expected O, but got Unknown
		Cursors = new Dictionary<CursorType, Cursor>();
		Cursors.Add(CursorType.RedCrossHair, new Cursor(Resources.CrossHairRedCursor_32.GetHicon()));
		Cursors.Add(CursorType.Radar, new Cursor(Resources.Radar32.GetHicon()));
		Cursors.Add(CursorType.Refuel, new Cursor(Resources.RefuelCursor32.GetHicon()));
		Cursors.Add(CursorType.Rebase, new Cursor(Resources.Rebase32.GetHicon()));
		Cursors.Add(CursorType.RTB, new Cursor(Resources.RTB32.GetHicon()));
		Cursors.Add(CursorType.Escort, new Cursor(Resources.Escort32.GetHicon()));
	}

	public static CustomCursor GetInstance()
	{
		if (customCursor_0 == null)
		{
			customCursor_0 = new CustomCursor();
		}
		return customCursor_0;
	}

	public static Cursor GetCursor(CursorType Type)
	{
		return GetInstance().Cursors[Type];
	}
}
