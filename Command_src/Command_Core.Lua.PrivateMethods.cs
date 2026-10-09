using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Collections.Pooled;
using Command_Core.DAL;
using Command_Core.LoadSave;
using DarkUI.Collections;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Nini.Config;
using NLua;

namespace Command_Core.Lua;

[StandardModule]
public sealed class PrivateMethods
{
	public delegate void LuaMessageBoxEventHandler(string theMsg, int theStyle, bool RunningHeadless, ref string pressed);

	public delegate void LuaInputBoxEventHandler(string theMsg, bool RunningHeadless, ref string pressed);

	public delegate void LuaLocalVideoEventHandler(string theFileName, bool RunningHeadless, bool FullScreen, int Delay);

	public delegate void LuaLocalSoundEventHandler(string theFileName, int Delay);

	public delegate void LuaGameEventHandler(ref byte status, ref byte mode);

	public delegate void LuaSelectUnitsPrompt_OwnSideEventHandler(ref LuaTable result, bool MultipleSelect);

	public delegate void LuaSelectUnitsPrompt_FromSidesEventHandler(ref LuaTable result, LuaTable SidesNameOrID, bool MultipleSelect);

	public delegate void LuaCallAdvancedDialogEventHandler(string Title, string HTML, LuaTable Interactions, ref string returnValue);

	public delegate void LuaOpenNewDatabaseWindowEventHandler(string SelectedObjectType, int selectedObjectID);

	public delegate void LuaUI_ShowWindowEventHandler(string Window, LuaTable Args);

	public delegate void LuaCallSetCameraViewEventHandler(double latitude, double longitude, int zoom);

	public delegate void LuaCallSelectThisUnitEventHandler(string unit, bool ThisUnitOnly, bool clearWaypointSelection);

	public delegate void LuaNewBlankScenarioEventHandler(string dbHashed);

	public delegate void LuaResetMessageLogEventHandler(Scenario obj, bool dumpToFile);

	public delegate void LuaCallAdvancedHTMLDialogEventHandler(string Title, string Html, LuaTable Interactions);

	[CompilerGenerated]
	internal sealed class _Closure$__101-0
	{
		public string $VB$Local_SideNameOrID;

		public _Closure$__101-0(_Closure$__101-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_SideNameOrID = arg0.$VB$Local_SideNameOrID;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(Side s)
		{
			if (string.Equals(s.ObjectID, $VB$Local_SideNameOrID, StringComparison.OrdinalIgnoreCase))
			{
				return true;
			}
			return string.Equals(s.Name, $VB$Local_SideNameOrID, StringComparison.OrdinalIgnoreCase);
		}

		static _Closure$__101-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__142-0
	{
		public FuelRec._FuelType $VB$Local_e;

		public _Closure$__142-0(_Closure$__142-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_e = arg0.$VB$Local_e;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(FuelRec F)
		{
			return F.FuelType == $VB$Local_e;
		}

		static _Closure$__142-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__143-0
	{
		public int $VB$Local_moveCargoType;

		public int $VB$Local_moveDBID;

		public string $VB$Local_moveGUID;

		public _Closure$__143-0(_Closure$__143-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_moveCargoType = arg0.$VB$Local_moveCargoType;
				$VB$Local_moveDBID = arg0.$VB$Local_moveDBID;
				$VB$Local_moveGUID = arg0.$VB$Local_moveGUID;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(Cargo C)
		{
			return C.CurrentType == (Cargo.CargoObjectType)$VB$Local_moveCargoType;
		}

		[SpecialName]
		internal bool _Lambda$__1(Cargo C)
		{
			return C.CargoObjectDBID == $VB$Local_moveDBID;
		}

		[SpecialName]
		internal bool _Lambda$__3(Cargo C)
		{
			return Operators.CompareString(C.CargoObjectID, $VB$Local_moveGUID, false) == 0;
		}

		static _Closure$__143-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__147-0
	{
		public string $VB$Local_Name;

		public _Closure$__147-0(_Closure$__147-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_Name = arg0.$VB$Local_Name;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(ActiveUnit s)
		{
			return string.Equals(s.Name, $VB$Local_Name, StringComparison.OrdinalIgnoreCase) | string.Equals(s.ObjectID, $VB$Local_Name, StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__1(ActiveUnit s)
		{
			return string.Equals(s.Name, $VB$Local_Name, StringComparison.OrdinalIgnoreCase) | string.Equals(s.ObjectID, $VB$Local_Name, StringComparison.OrdinalIgnoreCase);
		}

		static _Closure$__147-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__148-0
	{
		public string $VB$Local_Name;

		public _Closure$__148-0(_Closure$__148-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_Name = arg0.$VB$Local_Name;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(ActiveUnit s)
		{
			return string.Equals(s.Name, $VB$Local_Name, StringComparison.OrdinalIgnoreCase) | string.Equals(s.ObjectID, $VB$Local_Name, StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__1(ActiveUnit s)
		{
			return string.Equals(s.Name, $VB$Local_Name, StringComparison.OrdinalIgnoreCase) | string.Equals(s.ObjectID, $VB$Local_Name, StringComparison.OrdinalIgnoreCase);
		}

		static _Closure$__148-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__150-0
	{
		public string $VB$Local_Name;

		public _Closure$__150-0(_Closure$__150-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_Name = arg0.$VB$Local_Name;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(ActiveUnit s)
		{
			if (!string.Equals(s.Name, $VB$Local_Name, StringComparison.OrdinalIgnoreCase))
			{
				return string.Equals(s.ObjectID, $VB$Local_Name, StringComparison.OrdinalIgnoreCase);
			}
			return true;
		}

		[SpecialName]
		internal bool _Lambda$__1(ActiveUnit s)
		{
			if (!string.Equals(s.Name, $VB$Local_Name, StringComparison.OrdinalIgnoreCase))
			{
				return string.Equals(s.ObjectID, $VB$Local_Name, StringComparison.OrdinalIgnoreCase);
			}
			return true;
		}

		static _Closure$__150-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__150-1
	{
		public FuelRec._FuelType $VB$Local_e;

		public _Closure$__150-1(_Closure$__150-1 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_e = arg0.$VB$Local_e;
			}
		}

		[SpecialName]
		internal bool _Lambda$__2(FuelRec F)
		{
			return F.FuelType == $VB$Local_e;
		}

		static _Closure$__150-1()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__153-0
	{
		public string $VB$Local_Name;

		public _Closure$__153-0(_Closure$__153-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_Name = arg0.$VB$Local_Name;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(ActiveUnit s)
		{
			if (!string.Equals(s.Name, $VB$Local_Name, StringComparison.OrdinalIgnoreCase))
			{
				return string.Equals(s.ObjectID, $VB$Local_Name, StringComparison.OrdinalIgnoreCase);
			}
			return true;
		}

		[SpecialName]
		internal bool _Lambda$__1(ActiveUnit s)
		{
			if (!string.Equals(s.Name, $VB$Local_Name, StringComparison.OrdinalIgnoreCase))
			{
				return string.Equals(s.ObjectID, $VB$Local_Name, StringComparison.OrdinalIgnoreCase);
			}
			return true;
		}

		static _Closure$__153-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__155-0
	{
		public string $VB$Local_Name;

		public _Closure$__155-0(_Closure$__155-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_Name = arg0.$VB$Local_Name;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(ActiveUnit s)
		{
			if (string.Equals(s.Name, $VB$Local_Name, StringComparison.OrdinalIgnoreCase))
			{
				return true;
			}
			return string.Equals(s.ObjectID, $VB$Local_Name, StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__1(ActiveUnit s)
		{
			return string.Equals(s.Name, $VB$Local_Name, StringComparison.OrdinalIgnoreCase) | string.Equals(s.ObjectID, $VB$Local_Name, StringComparison.OrdinalIgnoreCase);
		}

		static _Closure$__155-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__156-0
	{
		public string $VB$Local_Name;

		public _Closure$__156-0(_Closure$__156-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_Name = arg0.$VB$Local_Name;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(ActiveUnit s)
		{
			return string.Equals(s.Name, $VB$Local_Name, StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__1(ActiveUnit s)
		{
			return string.Equals(s.Name, $VB$Local_Name, StringComparison.OrdinalIgnoreCase);
		}

		static _Closure$__156-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__158-0
	{
		public string $VB$Local_Name;

		public _Closure$__158-0(_Closure$__158-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_Name = arg0.$VB$Local_Name;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(ActiveUnit s)
		{
			return string.Equals(s.Name, $VB$Local_Name, StringComparison.OrdinalIgnoreCase) | string.Equals(s.ObjectID, $VB$Local_Name, StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__1(ActiveUnit s)
		{
			return string.Equals(s.Name, $VB$Local_Name, StringComparison.OrdinalIgnoreCase) | string.Equals(s.ObjectID, $VB$Local_Name, StringComparison.OrdinalIgnoreCase);
		}

		static _Closure$__158-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__158-1
	{
		public LockRandom $VB$Local_rng;

		public int $VB$Local_dbid;

		public Func<WeaponRec, bool> $I3;

		public _Closure$__158-1(_Closure$__158-1 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_rng = arg0.$VB$Local_rng;
				$VB$Local_dbid = arg0.$VB$Local_dbid;
			}
		}

		[SpecialName]
		internal int _Lambda$__2(ActiveUnit F)
		{
			return $VB$Local_rng.Next();
		}

		[SpecialName]
		internal bool _Lambda$__3(WeaponRec F)
		{
			return F.int_3 == $VB$Local_dbid;
		}

		static _Closure$__158-1()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__163-0
	{
		public object $VB$Local_o;

		public _Closure$__163-0(_Closure$__163-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_o = arg0.$VB$Local_o;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(ReferencePoint s)
		{
			if (!string.Equals(s.Name, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase))
			{
				return string.Equals(s.ObjectID, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
			}
			return true;
		}

		[SpecialName]
		internal bool _Lambda$__1(ReferencePoint s)
		{
			if (!string.Equals(s.Name, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase))
			{
				return string.Equals(s.ObjectID, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
			}
			return true;
		}

		static _Closure$__163-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__166-0
	{
		public object $VB$Local_o;

		public _Closure$__166-0(_Closure$__166-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_o = arg0.$VB$Local_o;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(ReferencePoint s)
		{
			if (!string.Equals(s.Name, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase))
			{
				return string.Equals(s.ObjectID, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
			}
			return true;
		}

		[SpecialName]
		internal bool _Lambda$__1(ReferencePoint s)
		{
			if (string.Equals(s.Name, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase))
			{
				return true;
			}
			return string.Equals(s.ObjectID, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		static _Closure$__166-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__166-1
	{
		public ReferencePoint $VB$Local_z;

		public _Closure$__166-1(_Closure$__166-1 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_z = arg0.$VB$Local_z;
			}
		}

		[SpecialName]
		internal bool _Lambda$__2(ReferencePoint s)
		{
			if (s.Longitude == 1.79769313486231E+308)
			{
				if (!string.Equals(s.Name, $VB$Local_z.Name, StringComparison.OrdinalIgnoreCase))
				{
					return string.Equals(s.ObjectID, $VB$Local_z.Name, StringComparison.OrdinalIgnoreCase);
				}
				return true;
			}
			return false;
		}

		static _Closure$__166-1()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__166-2
	{
		public ReferencePoint $VB$Local_z;

		public _Closure$__166-2(_Closure$__166-2 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_z = arg0.$VB$Local_z;
			}
		}

		[SpecialName]
		internal bool _Lambda$__3(ReferencePoint s)
		{
			if (s.Longitude == 1.79769313486231E+308)
			{
				if (!string.Equals(s.Name, $VB$Local_z.Name, StringComparison.OrdinalIgnoreCase))
				{
					return string.Equals(s.ObjectID, $VB$Local_z.Name, StringComparison.OrdinalIgnoreCase);
				}
				return true;
			}
			return false;
		}

		static _Closure$__166-2()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__166-3
	{
		public ReferencePoint $VB$Local_z;

		public _Closure$__166-3(_Closure$__166-3 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_z = arg0.$VB$Local_z;
			}
		}

		[SpecialName]
		internal bool _Lambda$__4(ReferencePoint s)
		{
			if (s.Longitude == 1.79769313486231E+308)
			{
				if (string.Equals(s.Name, $VB$Local_z.Name, StringComparison.OrdinalIgnoreCase))
				{
					return true;
				}
				return string.Equals(s.ObjectID, $VB$Local_z.Name, StringComparison.OrdinalIgnoreCase);
			}
			return false;
		}

		static _Closure$__166-3()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__171-0
	{
		public string $VB$Local_Name;

		public _Closure$__171-0(_Closure$__171-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_Name = arg0.$VB$Local_Name;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(ActiveUnit s)
		{
			return string.Equals(s.Name, $VB$Local_Name, StringComparison.OrdinalIgnoreCase) | string.Equals(s.ObjectID, $VB$Local_Name, StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__1(ActiveUnit s)
		{
			return string.Equals(s.Name, $VB$Local_Name, StringComparison.OrdinalIgnoreCase) | string.Equals(s.ObjectID, $VB$Local_Name, StringComparison.OrdinalIgnoreCase);
		}

		static _Closure$__171-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__175-0
	{
		public string $VB$Local_o_name;

		public Func<ReferencePoint, bool> $I1;

		public Func<ReferencePoint, bool> $I2;

		public Func<ReferencePoint, bool> $I4;

		public Func<ReferencePoint, bool> $I5;

		public _Closure$__175-0(_Closure$__175-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_o_name = arg0.$VB$Local_o_name;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(ReferencePoint s)
		{
			if (!string.Equals(s.ObjectID, $VB$Local_o_name, StringComparison.OrdinalIgnoreCase))
			{
				return string.Equals(s.Name, $VB$Local_o_name, StringComparison.OrdinalIgnoreCase);
			}
			return true;
		}

		[SpecialName]
		internal bool _Lambda$__1(ReferencePoint s)
		{
			if (!string.Equals(s.ObjectID, $VB$Local_o_name, StringComparison.OrdinalIgnoreCase))
			{
				return string.Equals(s.Name, $VB$Local_o_name, StringComparison.OrdinalIgnoreCase);
			}
			return true;
		}

		[SpecialName]
		internal bool _Lambda$__2(ReferencePoint s)
		{
			if (!string.Equals(s.ObjectID, $VB$Local_o_name, StringComparison.OrdinalIgnoreCase))
			{
				return string.Equals(s.Name, $VB$Local_o_name, StringComparison.OrdinalIgnoreCase);
			}
			return true;
		}

		[SpecialName]
		internal bool _Lambda$__3(ReferencePoint s)
		{
			if (!string.Equals(s.ObjectID, $VB$Local_o_name, StringComparison.OrdinalIgnoreCase))
			{
				return string.Equals(s.Name, $VB$Local_o_name, StringComparison.OrdinalIgnoreCase);
			}
			return true;
		}

		[SpecialName]
		internal bool _Lambda$__4(ReferencePoint s)
		{
			if (string.Equals(s.ObjectID, $VB$Local_o_name, StringComparison.OrdinalIgnoreCase))
			{
				return true;
			}
			return string.Equals(s.Name, $VB$Local_o_name, StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__5(ReferencePoint s)
		{
			if (string.Equals(s.ObjectID, $VB$Local_o_name, StringComparison.OrdinalIgnoreCase))
			{
				return true;
			}
			return string.Equals(s.Name, $VB$Local_o_name, StringComparison.OrdinalIgnoreCase);
		}

		static _Closure$__175-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__176-0
	{
		public Side $VB$Local_SideObject;

		public _Closure$__176-0(_Closure$__176-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_SideObject = arg0.$VB$Local_SideObject;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(UnguidedWeapon theUW)
		{
			if (theUW.IsMine)
			{
				return theUW.get_UnitSide(SetSideOnly: false) == $VB$Local_SideObject;
			}
			return false;
		}

		static _Closure$__176-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__176-1
	{
		public string $VB$Local_o_name;

		public Func<ReferencePoint, bool> $I2;

		public Func<ReferencePoint, bool> $I3;

		public Func<ReferencePoint, bool> $I5;

		public Func<ReferencePoint, bool> $I6;

		public _Closure$__176-1(_Closure$__176-1 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_o_name = arg0.$VB$Local_o_name;
			}
		}

		[SpecialName]
		internal bool _Lambda$__1(ReferencePoint s)
		{
			if (!string.Equals(s.ObjectID, $VB$Local_o_name, StringComparison.OrdinalIgnoreCase))
			{
				return string.Equals(s.Name, $VB$Local_o_name, StringComparison.OrdinalIgnoreCase);
			}
			return true;
		}

		[SpecialName]
		internal bool _Lambda$__2(ReferencePoint s)
		{
			if (!string.Equals(s.ObjectID, $VB$Local_o_name, StringComparison.OrdinalIgnoreCase))
			{
				return string.Equals(s.Name, $VB$Local_o_name, StringComparison.OrdinalIgnoreCase);
			}
			return true;
		}

		[SpecialName]
		internal bool _Lambda$__3(ReferencePoint s)
		{
			if (string.Equals(s.ObjectID, $VB$Local_o_name, StringComparison.OrdinalIgnoreCase))
			{
				return true;
			}
			return string.Equals(s.Name, $VB$Local_o_name, StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__4(ReferencePoint s)
		{
			if (!string.Equals(s.ObjectID, $VB$Local_o_name, StringComparison.OrdinalIgnoreCase))
			{
				return string.Equals(s.Name, $VB$Local_o_name, StringComparison.OrdinalIgnoreCase);
			}
			return true;
		}

		[SpecialName]
		internal bool _Lambda$__5(ReferencePoint s)
		{
			if (string.Equals(s.ObjectID, $VB$Local_o_name, StringComparison.OrdinalIgnoreCase))
			{
				return true;
			}
			return string.Equals(s.Name, $VB$Local_o_name, StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__6(ReferencePoint s)
		{
			if (!string.Equals(s.ObjectID, $VB$Local_o_name, StringComparison.OrdinalIgnoreCase))
			{
				return string.Equals(s.Name, $VB$Local_o_name, StringComparison.OrdinalIgnoreCase);
			}
			return true;
		}

		static _Closure$__176-1()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__177-0
	{
		public Side $VB$Local_SideObject;

		public _Closure$__177-0(_Closure$__177-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_SideObject = arg0.$VB$Local_SideObject;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(UnguidedWeapon theUW)
		{
			if (theUW.IsMine)
			{
				return theUW.get_UnitSide(SetSideOnly: false) == $VB$Local_SideObject;
			}
			return false;
		}

		static _Closure$__177-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__177-1
	{
		public string $VB$Local_o_name;

		public Func<ReferencePoint, bool> $I2;

		public Func<ReferencePoint, bool> $I3;

		public Func<ReferencePoint, bool> $I5;

		public Func<ReferencePoint, bool> $I6;

		public _Closure$__177-1(_Closure$__177-1 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_o_name = arg0.$VB$Local_o_name;
			}
		}

		[SpecialName]
		internal bool _Lambda$__1(ReferencePoint s)
		{
			if (string.Equals(s.ObjectID, $VB$Local_o_name, StringComparison.OrdinalIgnoreCase))
			{
				return true;
			}
			return string.Equals(s.Name, $VB$Local_o_name, StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__2(ReferencePoint s)
		{
			if (string.Equals(s.ObjectID, $VB$Local_o_name, StringComparison.OrdinalIgnoreCase))
			{
				return true;
			}
			return string.Equals(s.Name, $VB$Local_o_name, StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__3(ReferencePoint s)
		{
			if (!string.Equals(s.ObjectID, $VB$Local_o_name, StringComparison.OrdinalIgnoreCase))
			{
				return string.Equals(s.Name, $VB$Local_o_name, StringComparison.OrdinalIgnoreCase);
			}
			return true;
		}

		[SpecialName]
		internal bool _Lambda$__4(ReferencePoint s)
		{
			if (!string.Equals(s.ObjectID, $VB$Local_o_name, StringComparison.OrdinalIgnoreCase))
			{
				return string.Equals(s.Name, $VB$Local_o_name, StringComparison.OrdinalIgnoreCase);
			}
			return true;
		}

		[SpecialName]
		internal bool _Lambda$__5(ReferencePoint s)
		{
			if (string.Equals(s.ObjectID, $VB$Local_o_name, StringComparison.OrdinalIgnoreCase))
			{
				return true;
			}
			return string.Equals(s.Name, $VB$Local_o_name, StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__6(ReferencePoint s)
		{
			if (string.Equals(s.ObjectID, $VB$Local_o_name, StringComparison.OrdinalIgnoreCase))
			{
				return true;
			}
			return string.Equals(s.Name, $VB$Local_o_name, StringComparison.OrdinalIgnoreCase);
		}

		static _Closure$__177-1()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__186-0
	{
		public string $VB$Local_Name;

		public _Closure$__186-0(_Closure$__186-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_Name = arg0.$VB$Local_Name;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(ActiveUnit s)
		{
			if (string.Equals(s.Name, $VB$Local_Name, StringComparison.OrdinalIgnoreCase))
			{
				return true;
			}
			return string.Equals(s.ObjectID, $VB$Local_Name, StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__1(ActiveUnit s)
		{
			if (string.Equals(s.Name, $VB$Local_Name, StringComparison.OrdinalIgnoreCase))
			{
				return true;
			}
			return string.Equals(s.ObjectID, $VB$Local_Name, StringComparison.OrdinalIgnoreCase);
		}

		static _Closure$__186-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__209-0
	{
		public string $VB$Local_NameOrID;

		public Func<ReferencePoint, bool> $I1;

		public Func<ReferencePoint, bool> $I2;

		public _Closure$__209-0(_Closure$__209-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_NameOrID = arg0.$VB$Local_NameOrID;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(ReferencePoint s)
		{
			if (string.Equals(s.ObjectID, $VB$Local_NameOrID, StringComparison.OrdinalIgnoreCase))
			{
				return true;
			}
			return string.Equals(s.Name, $VB$Local_NameOrID, StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__1(ReferencePoint s)
		{
			if (!string.Equals(s.ObjectID, $VB$Local_NameOrID, StringComparison.OrdinalIgnoreCase))
			{
				return string.Equals(s.Name, $VB$Local_NameOrID, StringComparison.OrdinalIgnoreCase);
			}
			return true;
		}

		[SpecialName]
		internal bool _Lambda$__2(ReferencePoint s)
		{
			if (string.Equals(s.ObjectID, $VB$Local_NameOrID, StringComparison.OrdinalIgnoreCase))
			{
				return true;
			}
			return string.Equals(s.Name, $VB$Local_NameOrID, StringComparison.OrdinalIgnoreCase);
		}

		static _Closure$__209-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	private static LuaMessageBoxEventHandler luaMessageBoxEventHandler_0;

	[CompilerGenerated]
	private static LuaInputBoxEventHandler luaInputBoxEventHandler_0;

	[CompilerGenerated]
	private static LuaLocalVideoEventHandler luaLocalVideoEventHandler_0;

	[CompilerGenerated]
	private static LuaLocalSoundEventHandler luaLocalSoundEventHandler_0;

	[CompilerGenerated]
	private static LuaGameEventHandler luaGameEventHandler_0;

	[CompilerGenerated]
	private static LuaSelectUnitsPrompt_OwnSideEventHandler luaSelectUnitsPrompt_OwnSideEventHandler_0;

	[CompilerGenerated]
	private static LuaSelectUnitsPrompt_FromSidesEventHandler luaSelectUnitsPrompt_FromSidesEventHandler_0;

	[CompilerGenerated]
	private static LuaCallAdvancedDialogEventHandler luaCallAdvancedDialogEventHandler_0;

	[CompilerGenerated]
	private static LuaOpenNewDatabaseWindowEventHandler luaOpenNewDatabaseWindowEventHandler_0;

	[CompilerGenerated]
	private static LuaUI_ShowWindowEventHandler luaUI_ShowWindowEventHandler_0;

	[CompilerGenerated]
	private static LuaCallSetCameraViewEventHandler luaCallSetCameraViewEventHandler_0;

	[CompilerGenerated]
	private static LuaCallSelectThisUnitEventHandler luaCallSelectThisUnitEventHandler_0;

	[CompilerGenerated]
	private static LuaNewBlankScenarioEventHandler luaNewBlankScenarioEventHandler_0;

	[CompilerGenerated]
	private static LuaResetMessageLogEventHandler luaResetMessageLogEventHandler_0;

	public static Dictionary<string, string> ReturnTable;

	public static TaskCompletionSource<LuaTable> ReturnTableCompletionSource;

	[CompilerGenerated]
	private static LuaCallAdvancedHTMLDialogEventHandler luaCallAdvancedHTMLDialogEventHandler_0;

	public static event LuaMessageBoxEventHandler LuaMessageBox
	{
		[CompilerGenerated]
		add
		{
			LuaMessageBoxEventHandler luaMessageBoxEventHandler = luaMessageBoxEventHandler_0;
			LuaMessageBoxEventHandler luaMessageBoxEventHandler2;
			do
			{
				luaMessageBoxEventHandler2 = luaMessageBoxEventHandler;
				LuaMessageBoxEventHandler value2 = (LuaMessageBoxEventHandler)Delegate.Combine(luaMessageBoxEventHandler2, value);
				luaMessageBoxEventHandler = Interlocked.CompareExchange(ref luaMessageBoxEventHandler_0, value2, luaMessageBoxEventHandler2);
			}
			while ((object)luaMessageBoxEventHandler != luaMessageBoxEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			LuaMessageBoxEventHandler luaMessageBoxEventHandler = luaMessageBoxEventHandler_0;
			LuaMessageBoxEventHandler luaMessageBoxEventHandler2;
			do
			{
				luaMessageBoxEventHandler2 = luaMessageBoxEventHandler;
				LuaMessageBoxEventHandler value2 = (LuaMessageBoxEventHandler)Delegate.Remove(luaMessageBoxEventHandler2, value);
				luaMessageBoxEventHandler = Interlocked.CompareExchange(ref luaMessageBoxEventHandler_0, value2, luaMessageBoxEventHandler2);
			}
			while ((object)luaMessageBoxEventHandler != luaMessageBoxEventHandler2);
		}
	}

	public static event LuaInputBoxEventHandler LuaInputBox
	{
		[CompilerGenerated]
		add
		{
			LuaInputBoxEventHandler luaInputBoxEventHandler = luaInputBoxEventHandler_0;
			LuaInputBoxEventHandler luaInputBoxEventHandler2;
			do
			{
				luaInputBoxEventHandler2 = luaInputBoxEventHandler;
				LuaInputBoxEventHandler value2 = (LuaInputBoxEventHandler)Delegate.Combine(luaInputBoxEventHandler2, value);
				luaInputBoxEventHandler = Interlocked.CompareExchange(ref luaInputBoxEventHandler_0, value2, luaInputBoxEventHandler2);
			}
			while ((object)luaInputBoxEventHandler != luaInputBoxEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			LuaInputBoxEventHandler luaInputBoxEventHandler = luaInputBoxEventHandler_0;
			LuaInputBoxEventHandler luaInputBoxEventHandler2;
			do
			{
				luaInputBoxEventHandler2 = luaInputBoxEventHandler;
				LuaInputBoxEventHandler value2 = (LuaInputBoxEventHandler)Delegate.Remove(luaInputBoxEventHandler2, value);
				luaInputBoxEventHandler = Interlocked.CompareExchange(ref luaInputBoxEventHandler_0, value2, luaInputBoxEventHandler2);
			}
			while ((object)luaInputBoxEventHandler != luaInputBoxEventHandler2);
		}
	}

	public static event LuaLocalVideoEventHandler LuaLocalVideo
	{
		[CompilerGenerated]
		add
		{
			LuaLocalVideoEventHandler luaLocalVideoEventHandler = luaLocalVideoEventHandler_0;
			LuaLocalVideoEventHandler luaLocalVideoEventHandler2;
			do
			{
				luaLocalVideoEventHandler2 = luaLocalVideoEventHandler;
				LuaLocalVideoEventHandler value2 = (LuaLocalVideoEventHandler)Delegate.Combine(luaLocalVideoEventHandler2, value);
				luaLocalVideoEventHandler = Interlocked.CompareExchange(ref luaLocalVideoEventHandler_0, value2, luaLocalVideoEventHandler2);
			}
			while ((object)luaLocalVideoEventHandler != luaLocalVideoEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			LuaLocalVideoEventHandler luaLocalVideoEventHandler = luaLocalVideoEventHandler_0;
			LuaLocalVideoEventHandler luaLocalVideoEventHandler2;
			do
			{
				luaLocalVideoEventHandler2 = luaLocalVideoEventHandler;
				LuaLocalVideoEventHandler value2 = (LuaLocalVideoEventHandler)Delegate.Remove(luaLocalVideoEventHandler2, value);
				luaLocalVideoEventHandler = Interlocked.CompareExchange(ref luaLocalVideoEventHandler_0, value2, luaLocalVideoEventHandler2);
			}
			while ((object)luaLocalVideoEventHandler != luaLocalVideoEventHandler2);
		}
	}

	public static event LuaLocalSoundEventHandler LuaLocalSound
	{
		[CompilerGenerated]
		add
		{
			LuaLocalSoundEventHandler luaLocalSoundEventHandler = luaLocalSoundEventHandler_0;
			LuaLocalSoundEventHandler luaLocalSoundEventHandler2;
			do
			{
				luaLocalSoundEventHandler2 = luaLocalSoundEventHandler;
				LuaLocalSoundEventHandler value2 = (LuaLocalSoundEventHandler)Delegate.Combine(luaLocalSoundEventHandler2, value);
				luaLocalSoundEventHandler = Interlocked.CompareExchange(ref luaLocalSoundEventHandler_0, value2, luaLocalSoundEventHandler2);
			}
			while ((object)luaLocalSoundEventHandler != luaLocalSoundEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			LuaLocalSoundEventHandler luaLocalSoundEventHandler = luaLocalSoundEventHandler_0;
			LuaLocalSoundEventHandler luaLocalSoundEventHandler2;
			do
			{
				luaLocalSoundEventHandler2 = luaLocalSoundEventHandler;
				LuaLocalSoundEventHandler value2 = (LuaLocalSoundEventHandler)Delegate.Remove(luaLocalSoundEventHandler2, value);
				luaLocalSoundEventHandler = Interlocked.CompareExchange(ref luaLocalSoundEventHandler_0, value2, luaLocalSoundEventHandler2);
			}
			while ((object)luaLocalSoundEventHandler != luaLocalSoundEventHandler2);
		}
	}

	public static event LuaGameEventHandler LuaGame
	{
		[CompilerGenerated]
		add
		{
			LuaGameEventHandler luaGameEventHandler = luaGameEventHandler_0;
			LuaGameEventHandler luaGameEventHandler2;
			do
			{
				luaGameEventHandler2 = luaGameEventHandler;
				LuaGameEventHandler value2 = (LuaGameEventHandler)Delegate.Combine(luaGameEventHandler2, value);
				luaGameEventHandler = Interlocked.CompareExchange(ref luaGameEventHandler_0, value2, luaGameEventHandler2);
			}
			while ((object)luaGameEventHandler != luaGameEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			LuaGameEventHandler luaGameEventHandler = luaGameEventHandler_0;
			LuaGameEventHandler luaGameEventHandler2;
			do
			{
				luaGameEventHandler2 = luaGameEventHandler;
				LuaGameEventHandler value2 = (LuaGameEventHandler)Delegate.Remove(luaGameEventHandler2, value);
				luaGameEventHandler = Interlocked.CompareExchange(ref luaGameEventHandler_0, value2, luaGameEventHandler2);
			}
			while ((object)luaGameEventHandler != luaGameEventHandler2);
		}
	}

	public static event LuaSelectUnitsPrompt_OwnSideEventHandler LuaSelectUnitsPrompt_OwnSide
	{
		[CompilerGenerated]
		add
		{
			LuaSelectUnitsPrompt_OwnSideEventHandler luaSelectUnitsPrompt_OwnSideEventHandler = luaSelectUnitsPrompt_OwnSideEventHandler_0;
			LuaSelectUnitsPrompt_OwnSideEventHandler luaSelectUnitsPrompt_OwnSideEventHandler2;
			do
			{
				luaSelectUnitsPrompt_OwnSideEventHandler2 = luaSelectUnitsPrompt_OwnSideEventHandler;
				LuaSelectUnitsPrompt_OwnSideEventHandler value2 = (LuaSelectUnitsPrompt_OwnSideEventHandler)Delegate.Combine(luaSelectUnitsPrompt_OwnSideEventHandler2, value);
				luaSelectUnitsPrompt_OwnSideEventHandler = Interlocked.CompareExchange(ref luaSelectUnitsPrompt_OwnSideEventHandler_0, value2, luaSelectUnitsPrompt_OwnSideEventHandler2);
			}
			while ((object)luaSelectUnitsPrompt_OwnSideEventHandler != luaSelectUnitsPrompt_OwnSideEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			LuaSelectUnitsPrompt_OwnSideEventHandler luaSelectUnitsPrompt_OwnSideEventHandler = luaSelectUnitsPrompt_OwnSideEventHandler_0;
			LuaSelectUnitsPrompt_OwnSideEventHandler luaSelectUnitsPrompt_OwnSideEventHandler2;
			do
			{
				luaSelectUnitsPrompt_OwnSideEventHandler2 = luaSelectUnitsPrompt_OwnSideEventHandler;
				LuaSelectUnitsPrompt_OwnSideEventHandler value2 = (LuaSelectUnitsPrompt_OwnSideEventHandler)Delegate.Remove(luaSelectUnitsPrompt_OwnSideEventHandler2, value);
				luaSelectUnitsPrompt_OwnSideEventHandler = Interlocked.CompareExchange(ref luaSelectUnitsPrompt_OwnSideEventHandler_0, value2, luaSelectUnitsPrompt_OwnSideEventHandler2);
			}
			while ((object)luaSelectUnitsPrompt_OwnSideEventHandler != luaSelectUnitsPrompt_OwnSideEventHandler2);
		}
	}

	public static event LuaSelectUnitsPrompt_FromSidesEventHandler LuaSelectUnitsPrompt_FromSides
	{
		[CompilerGenerated]
		add
		{
			LuaSelectUnitsPrompt_FromSidesEventHandler luaSelectUnitsPrompt_FromSidesEventHandler = luaSelectUnitsPrompt_FromSidesEventHandler_0;
			LuaSelectUnitsPrompt_FromSidesEventHandler luaSelectUnitsPrompt_FromSidesEventHandler2;
			do
			{
				luaSelectUnitsPrompt_FromSidesEventHandler2 = luaSelectUnitsPrompt_FromSidesEventHandler;
				LuaSelectUnitsPrompt_FromSidesEventHandler value2 = (LuaSelectUnitsPrompt_FromSidesEventHandler)Delegate.Combine(luaSelectUnitsPrompt_FromSidesEventHandler2, value);
				luaSelectUnitsPrompt_FromSidesEventHandler = Interlocked.CompareExchange(ref luaSelectUnitsPrompt_FromSidesEventHandler_0, value2, luaSelectUnitsPrompt_FromSidesEventHandler2);
			}
			while ((object)luaSelectUnitsPrompt_FromSidesEventHandler != luaSelectUnitsPrompt_FromSidesEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			LuaSelectUnitsPrompt_FromSidesEventHandler luaSelectUnitsPrompt_FromSidesEventHandler = luaSelectUnitsPrompt_FromSidesEventHandler_0;
			LuaSelectUnitsPrompt_FromSidesEventHandler luaSelectUnitsPrompt_FromSidesEventHandler2;
			do
			{
				luaSelectUnitsPrompt_FromSidesEventHandler2 = luaSelectUnitsPrompt_FromSidesEventHandler;
				LuaSelectUnitsPrompt_FromSidesEventHandler value2 = (LuaSelectUnitsPrompt_FromSidesEventHandler)Delegate.Remove(luaSelectUnitsPrompt_FromSidesEventHandler2, value);
				luaSelectUnitsPrompt_FromSidesEventHandler = Interlocked.CompareExchange(ref luaSelectUnitsPrompt_FromSidesEventHandler_0, value2, luaSelectUnitsPrompt_FromSidesEventHandler2);
			}
			while ((object)luaSelectUnitsPrompt_FromSidesEventHandler != luaSelectUnitsPrompt_FromSidesEventHandler2);
		}
	}

	public static event LuaCallAdvancedDialogEventHandler LuaCallAdvancedDialog
	{
		[CompilerGenerated]
		add
		{
			LuaCallAdvancedDialogEventHandler luaCallAdvancedDialogEventHandler = luaCallAdvancedDialogEventHandler_0;
			LuaCallAdvancedDialogEventHandler luaCallAdvancedDialogEventHandler2;
			do
			{
				luaCallAdvancedDialogEventHandler2 = luaCallAdvancedDialogEventHandler;
				LuaCallAdvancedDialogEventHandler value2 = (LuaCallAdvancedDialogEventHandler)Delegate.Combine(luaCallAdvancedDialogEventHandler2, value);
				luaCallAdvancedDialogEventHandler = Interlocked.CompareExchange(ref luaCallAdvancedDialogEventHandler_0, value2, luaCallAdvancedDialogEventHandler2);
			}
			while ((object)luaCallAdvancedDialogEventHandler != luaCallAdvancedDialogEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			LuaCallAdvancedDialogEventHandler luaCallAdvancedDialogEventHandler = luaCallAdvancedDialogEventHandler_0;
			LuaCallAdvancedDialogEventHandler luaCallAdvancedDialogEventHandler2;
			do
			{
				luaCallAdvancedDialogEventHandler2 = luaCallAdvancedDialogEventHandler;
				LuaCallAdvancedDialogEventHandler value2 = (LuaCallAdvancedDialogEventHandler)Delegate.Remove(luaCallAdvancedDialogEventHandler2, value);
				luaCallAdvancedDialogEventHandler = Interlocked.CompareExchange(ref luaCallAdvancedDialogEventHandler_0, value2, luaCallAdvancedDialogEventHandler2);
			}
			while ((object)luaCallAdvancedDialogEventHandler != luaCallAdvancedDialogEventHandler2);
		}
	}

	public static event LuaOpenNewDatabaseWindowEventHandler LuaOpenNewDatabaseWindow
	{
		[CompilerGenerated]
		add
		{
			LuaOpenNewDatabaseWindowEventHandler luaOpenNewDatabaseWindowEventHandler = luaOpenNewDatabaseWindowEventHandler_0;
			LuaOpenNewDatabaseWindowEventHandler luaOpenNewDatabaseWindowEventHandler2;
			do
			{
				luaOpenNewDatabaseWindowEventHandler2 = luaOpenNewDatabaseWindowEventHandler;
				LuaOpenNewDatabaseWindowEventHandler value2 = (LuaOpenNewDatabaseWindowEventHandler)Delegate.Combine(luaOpenNewDatabaseWindowEventHandler2, value);
				luaOpenNewDatabaseWindowEventHandler = Interlocked.CompareExchange(ref luaOpenNewDatabaseWindowEventHandler_0, value2, luaOpenNewDatabaseWindowEventHandler2);
			}
			while ((object)luaOpenNewDatabaseWindowEventHandler != luaOpenNewDatabaseWindowEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			LuaOpenNewDatabaseWindowEventHandler luaOpenNewDatabaseWindowEventHandler = luaOpenNewDatabaseWindowEventHandler_0;
			LuaOpenNewDatabaseWindowEventHandler luaOpenNewDatabaseWindowEventHandler2;
			do
			{
				luaOpenNewDatabaseWindowEventHandler2 = luaOpenNewDatabaseWindowEventHandler;
				LuaOpenNewDatabaseWindowEventHandler value2 = (LuaOpenNewDatabaseWindowEventHandler)Delegate.Remove(luaOpenNewDatabaseWindowEventHandler2, value);
				luaOpenNewDatabaseWindowEventHandler = Interlocked.CompareExchange(ref luaOpenNewDatabaseWindowEventHandler_0, value2, luaOpenNewDatabaseWindowEventHandler2);
			}
			while ((object)luaOpenNewDatabaseWindowEventHandler != luaOpenNewDatabaseWindowEventHandler2);
		}
	}

	public static event LuaUI_ShowWindowEventHandler LuaUI_ShowWindow
	{
		[CompilerGenerated]
		add
		{
			LuaUI_ShowWindowEventHandler luaUI_ShowWindowEventHandler = luaUI_ShowWindowEventHandler_0;
			LuaUI_ShowWindowEventHandler luaUI_ShowWindowEventHandler2;
			do
			{
				luaUI_ShowWindowEventHandler2 = luaUI_ShowWindowEventHandler;
				LuaUI_ShowWindowEventHandler value2 = (LuaUI_ShowWindowEventHandler)Delegate.Combine(luaUI_ShowWindowEventHandler2, value);
				luaUI_ShowWindowEventHandler = Interlocked.CompareExchange(ref luaUI_ShowWindowEventHandler_0, value2, luaUI_ShowWindowEventHandler2);
			}
			while ((object)luaUI_ShowWindowEventHandler != luaUI_ShowWindowEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			LuaUI_ShowWindowEventHandler luaUI_ShowWindowEventHandler = luaUI_ShowWindowEventHandler_0;
			LuaUI_ShowWindowEventHandler luaUI_ShowWindowEventHandler2;
			do
			{
				luaUI_ShowWindowEventHandler2 = luaUI_ShowWindowEventHandler;
				LuaUI_ShowWindowEventHandler value2 = (LuaUI_ShowWindowEventHandler)Delegate.Remove(luaUI_ShowWindowEventHandler2, value);
				luaUI_ShowWindowEventHandler = Interlocked.CompareExchange(ref luaUI_ShowWindowEventHandler_0, value2, luaUI_ShowWindowEventHandler2);
			}
			while ((object)luaUI_ShowWindowEventHandler != luaUI_ShowWindowEventHandler2);
		}
	}

	public static event LuaCallSetCameraViewEventHandler LuaCallSetCameraView
	{
		[CompilerGenerated]
		add
		{
			LuaCallSetCameraViewEventHandler luaCallSetCameraViewEventHandler = luaCallSetCameraViewEventHandler_0;
			LuaCallSetCameraViewEventHandler luaCallSetCameraViewEventHandler2;
			do
			{
				luaCallSetCameraViewEventHandler2 = luaCallSetCameraViewEventHandler;
				LuaCallSetCameraViewEventHandler value2 = (LuaCallSetCameraViewEventHandler)Delegate.Combine(luaCallSetCameraViewEventHandler2, value);
				luaCallSetCameraViewEventHandler = Interlocked.CompareExchange(ref luaCallSetCameraViewEventHandler_0, value2, luaCallSetCameraViewEventHandler2);
			}
			while ((object)luaCallSetCameraViewEventHandler != luaCallSetCameraViewEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			LuaCallSetCameraViewEventHandler luaCallSetCameraViewEventHandler = luaCallSetCameraViewEventHandler_0;
			LuaCallSetCameraViewEventHandler luaCallSetCameraViewEventHandler2;
			do
			{
				luaCallSetCameraViewEventHandler2 = luaCallSetCameraViewEventHandler;
				LuaCallSetCameraViewEventHandler value2 = (LuaCallSetCameraViewEventHandler)Delegate.Remove(luaCallSetCameraViewEventHandler2, value);
				luaCallSetCameraViewEventHandler = Interlocked.CompareExchange(ref luaCallSetCameraViewEventHandler_0, value2, luaCallSetCameraViewEventHandler2);
			}
			while ((object)luaCallSetCameraViewEventHandler != luaCallSetCameraViewEventHandler2);
		}
	}

	public static event LuaCallSelectThisUnitEventHandler LuaCallSelectThisUnit
	{
		[CompilerGenerated]
		add
		{
			LuaCallSelectThisUnitEventHandler luaCallSelectThisUnitEventHandler = luaCallSelectThisUnitEventHandler_0;
			LuaCallSelectThisUnitEventHandler luaCallSelectThisUnitEventHandler2;
			do
			{
				luaCallSelectThisUnitEventHandler2 = luaCallSelectThisUnitEventHandler;
				LuaCallSelectThisUnitEventHandler value2 = (LuaCallSelectThisUnitEventHandler)Delegate.Combine(luaCallSelectThisUnitEventHandler2, value);
				luaCallSelectThisUnitEventHandler = Interlocked.CompareExchange(ref luaCallSelectThisUnitEventHandler_0, value2, luaCallSelectThisUnitEventHandler2);
			}
			while ((object)luaCallSelectThisUnitEventHandler != luaCallSelectThisUnitEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			LuaCallSelectThisUnitEventHandler luaCallSelectThisUnitEventHandler = luaCallSelectThisUnitEventHandler_0;
			LuaCallSelectThisUnitEventHandler luaCallSelectThisUnitEventHandler2;
			do
			{
				luaCallSelectThisUnitEventHandler2 = luaCallSelectThisUnitEventHandler;
				LuaCallSelectThisUnitEventHandler value2 = (LuaCallSelectThisUnitEventHandler)Delegate.Remove(luaCallSelectThisUnitEventHandler2, value);
				luaCallSelectThisUnitEventHandler = Interlocked.CompareExchange(ref luaCallSelectThisUnitEventHandler_0, value2, luaCallSelectThisUnitEventHandler2);
			}
			while ((object)luaCallSelectThisUnitEventHandler != luaCallSelectThisUnitEventHandler2);
		}
	}

	public static event LuaNewBlankScenarioEventHandler LuaNewBlankScenario
	{
		[CompilerGenerated]
		add
		{
			LuaNewBlankScenarioEventHandler luaNewBlankScenarioEventHandler = luaNewBlankScenarioEventHandler_0;
			LuaNewBlankScenarioEventHandler luaNewBlankScenarioEventHandler2;
			do
			{
				luaNewBlankScenarioEventHandler2 = luaNewBlankScenarioEventHandler;
				LuaNewBlankScenarioEventHandler value2 = (LuaNewBlankScenarioEventHandler)Delegate.Combine(luaNewBlankScenarioEventHandler2, value);
				luaNewBlankScenarioEventHandler = Interlocked.CompareExchange(ref luaNewBlankScenarioEventHandler_0, value2, luaNewBlankScenarioEventHandler2);
			}
			while ((object)luaNewBlankScenarioEventHandler != luaNewBlankScenarioEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			LuaNewBlankScenarioEventHandler luaNewBlankScenarioEventHandler = luaNewBlankScenarioEventHandler_0;
			LuaNewBlankScenarioEventHandler luaNewBlankScenarioEventHandler2;
			do
			{
				luaNewBlankScenarioEventHandler2 = luaNewBlankScenarioEventHandler;
				LuaNewBlankScenarioEventHandler value2 = (LuaNewBlankScenarioEventHandler)Delegate.Remove(luaNewBlankScenarioEventHandler2, value);
				luaNewBlankScenarioEventHandler = Interlocked.CompareExchange(ref luaNewBlankScenarioEventHandler_0, value2, luaNewBlankScenarioEventHandler2);
			}
			while ((object)luaNewBlankScenarioEventHandler != luaNewBlankScenarioEventHandler2);
		}
	}

	public static event LuaResetMessageLogEventHandler LuaResetMessageLog
	{
		[CompilerGenerated]
		add
		{
			LuaResetMessageLogEventHandler luaResetMessageLogEventHandler = luaResetMessageLogEventHandler_0;
			LuaResetMessageLogEventHandler luaResetMessageLogEventHandler2;
			do
			{
				luaResetMessageLogEventHandler2 = luaResetMessageLogEventHandler;
				LuaResetMessageLogEventHandler value2 = (LuaResetMessageLogEventHandler)Delegate.Combine(luaResetMessageLogEventHandler2, value);
				luaResetMessageLogEventHandler = Interlocked.CompareExchange(ref luaResetMessageLogEventHandler_0, value2, luaResetMessageLogEventHandler2);
			}
			while ((object)luaResetMessageLogEventHandler != luaResetMessageLogEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			LuaResetMessageLogEventHandler luaResetMessageLogEventHandler = luaResetMessageLogEventHandler_0;
			LuaResetMessageLogEventHandler luaResetMessageLogEventHandler2;
			do
			{
				luaResetMessageLogEventHandler2 = luaResetMessageLogEventHandler;
				LuaResetMessageLogEventHandler value2 = (LuaResetMessageLogEventHandler)Delegate.Remove(luaResetMessageLogEventHandler2, value);
				luaResetMessageLogEventHandler = Interlocked.CompareExchange(ref luaResetMessageLogEventHandler_0, value2, luaResetMessageLogEventHandler2);
			}
			while ((object)luaResetMessageLogEventHandler != luaResetMessageLogEventHandler2);
		}
	}

	public static event LuaCallAdvancedHTMLDialogEventHandler LuaCallAdvancedHTMLDialog
	{
		[CompilerGenerated]
		add
		{
			LuaCallAdvancedHTMLDialogEventHandler luaCallAdvancedHTMLDialogEventHandler = luaCallAdvancedHTMLDialogEventHandler_0;
			LuaCallAdvancedHTMLDialogEventHandler luaCallAdvancedHTMLDialogEventHandler2;
			do
			{
				luaCallAdvancedHTMLDialogEventHandler2 = luaCallAdvancedHTMLDialogEventHandler;
				LuaCallAdvancedHTMLDialogEventHandler value2 = (LuaCallAdvancedHTMLDialogEventHandler)Delegate.Combine(luaCallAdvancedHTMLDialogEventHandler2, value);
				luaCallAdvancedHTMLDialogEventHandler = Interlocked.CompareExchange(ref luaCallAdvancedHTMLDialogEventHandler_0, value2, luaCallAdvancedHTMLDialogEventHandler2);
			}
			while ((object)luaCallAdvancedHTMLDialogEventHandler != luaCallAdvancedHTMLDialogEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			LuaCallAdvancedHTMLDialogEventHandler luaCallAdvancedHTMLDialogEventHandler = luaCallAdvancedHTMLDialogEventHandler_0;
			LuaCallAdvancedHTMLDialogEventHandler luaCallAdvancedHTMLDialogEventHandler2;
			do
			{
				luaCallAdvancedHTMLDialogEventHandler2 = luaCallAdvancedHTMLDialogEventHandler;
				LuaCallAdvancedHTMLDialogEventHandler value2 = (LuaCallAdvancedHTMLDialogEventHandler)Delegate.Remove(luaCallAdvancedHTMLDialogEventHandler2, value);
				luaCallAdvancedHTMLDialogEventHandler = Interlocked.CompareExchange(ref luaCallAdvancedHTMLDialogEventHandler_0, value2, luaCallAdvancedHTMLDialogEventHandler2);
			}
			while ((object)luaCallAdvancedHTMLDialogEventHandler != luaCallAdvancedHTMLDialogEventHandler2);
		}
	}

	static PrivateMethods()
	{
		Class72.smethod_20();
		ReturnTable = null;
		ReturnTableCompletionSource = new TaskCompletionSource<LuaTable>();
	}

	public static void UI_SelectThisUnit(string string_0, bool ThisUnitOnly, bool clearWaypointSelection = true)
	{
		luaCallSelectThisUnitEventHandler_0?.Invoke(string_0, ThisUnitOnly, clearWaypointSelection);
	}

	public static LuaTable UI_CallAdvancedHTMLDialog(string Title, string Html, LuaTable Interactions)
	{
		luaCallAdvancedHTMLDialogEventHandler_0?.Invoke(Title, Html, Interactions);
		LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
		if (ReturnTable != null)
		{
			foreach (KeyValuePair<string, string> item in ReturnTable)
			{
				luaTable[item.Key] = item.Value;
			}
		}
		return luaTable;
	}

	public static void UI_SetCameraView(double latitude, double longitude, int zoom)
	{
		luaCallSetCameraViewEventHandler_0?.Invoke(latitude, longitude, zoom);
	}

	public static string UI_CallAdvancedDialog(string Title, string HTML, LuaTable Interactions)
	{
		string returnValue = "";
		luaCallAdvancedDialogEventHandler_0?.Invoke(Title, HTML, Interactions, ref returnValue);
		return returnValue;
	}

	public static void UI_OpenNewDatabaseWindow(string SelectedObjectType, int selectedObjectID)
	{
		luaOpenNewDatabaseWindowEventHandler_0?.Invoke(SelectedObjectType, selectedObjectID);
	}

	public static void UI_ShowWindow(string Window, LuaTable Args)
	{
		luaUI_ShowWindowEventHandler_0?.Invoke(Window, Args);
	}

	public static LuaTable UI_SelectUnitsPrompt_OwnSide(ref LuaTable result, bool MultipleSelect)
	{
		luaSelectUnitsPrompt_OwnSideEventHandler_0?.Invoke(ref result, MultipleSelect);
		return result;
	}

	public static LuaTable UI_SelectUnitsPrompt_FromSides(ref LuaTable result, LuaTable SidesNameOrID, bool MultipleSelect)
	{
		luaSelectUnitsPrompt_FromSidesEventHandler_0?.Invoke(ref result, SidesNameOrID, MultipleSelect);
		return result;
	}

	public static string ScenEdit_TransformZone(string SideNameOrID, string ZoneNameOrID, string TargetType, Scenario ScenarioContext)
	{
		Side side = (from s in ScenarioContext.Sides_ReadOnly
			where string.Equals(s.ObjectID, SideNameOrID, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Name, SideNameOrID, StringComparison.OrdinalIgnoreCase)
			select (s)).First();
		if (side != null)
		{
			Zone zone = (from s in side.StandardZones
				where string.Equals(s.ObjectID, ZoneNameOrID, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Description, ZoneNameOrID, StringComparison.OrdinalIgnoreCase)
				select (s)).FirstOrDefault();
			ExclusionZone exclusionZone = (from s in side.ExclusionZones
				where string.Equals(s.ObjectID, ZoneNameOrID, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Description, ZoneNameOrID, StringComparison.OrdinalIgnoreCase)
				select (s)).FirstOrDefault();
			NoNavZone noNavZone = (from s in side.NoNavZones
				where string.Equals(s.ObjectID, ZoneNameOrID, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Description, ZoneNameOrID, StringComparison.OrdinalIgnoreCase)
				select (s)).FirstOrDefault();
			CustomEnvironmentZone customEnvironmentZone = null;
			if (zone == null && exclusionZone == null && noNavZone == null && side == ScenarioContext.GetNatureSide())
			{
				customEnvironmentZone = (from s in side.CustomEnvironmentZones
					where string.Equals(s.ObjectID, ZoneNameOrID, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Description, ZoneNameOrID, StringComparison.OrdinalIgnoreCase)
					select (s)).FirstOrDefault();
			}
			TargetType = TargetType.ToLowerInvariant();
			switch (TargetType)
			{
			case "nonav":
				if (Information.IsNothing((object)zone))
				{
					if (Information.IsNothing((object)exclusionZone))
					{
						if (customEnvironmentZone != null)
						{
							NoNavZone.TransformTo(customEnvironmentZone, side, ScenarioContext);
						}
					}
					else
					{
						NoNavZone.TransformTo(exclusionZone, side, ScenarioContext);
					}
				}
				else
				{
					NoNavZone.TransformTo(zone, side, ScenarioContext);
				}
				break;
			case "standard":
				if (!Information.IsNothing((object)noNavZone))
				{
					Zone.TransformTo(noNavZone, side, ScenarioContext);
				}
				else if (Information.IsNothing((object)exclusionZone))
				{
					if (customEnvironmentZone != null)
					{
						Zone.TransformTo(customEnvironmentZone, side, ScenarioContext);
					}
				}
				else
				{
					Zone.TransformTo(exclusionZone, side, ScenarioContext);
				}
				break;
			default:
				return "Zone type does not exist.";
			case "customenvironment":
				if (Information.IsNothing((object)zone))
				{
					if (Information.IsNothing((object)noNavZone))
					{
						if (!Information.IsNothing((object)exclusionZone))
						{
							CustomEnvironmentZone.TransformTo(exclusionZone, side, ScenarioContext);
						}
					}
					else
					{
						CustomEnvironmentZone.TransformTo(noNavZone, side, ScenarioContext);
					}
				}
				else
				{
					CustomEnvironmentZone.TransformTo(zone, side, ScenarioContext);
				}
				break;
			case "exclusion":
				if (!Information.IsNothing((object)zone))
				{
					ExclusionZone.TransformTo(zone, side, ScenarioContext);
				}
				else if (Information.IsNothing((object)noNavZone))
				{
					if (customEnvironmentZone != null)
					{
						ExclusionZone.TransformTo(customEnvironmentZone, side, ScenarioContext);
					}
				}
				else
				{
					ExclusionZone.TransformTo(noNavZone, side, ScenarioContext);
				}
				break;
			}
			return "";
		}
		return "Side not found.";
	}

	public static string ScenEdit_SetSimulationFidelity(float Fidelity, Scenario ScenarioContext)
	{
		if (!ScenarioContext.SetSimulationFidelity(Fidelity, Lock: true))
		{
			return "Fidelity argument must either be 0.1, 1 or 5";
		}
		string result = default(string);
		return result;
	}

	public static void ScenEdit_LockSimulationFidelity(bool IsLocked, Scenario ScenarioContext)
	{
		ScenarioContext.LockFidelityResolution = IsLocked;
	}

	public static void Command_SaveScen(string FilePath, Scenario ScenarioContext)
	{
		Command_Core.LoadSave.LoadSave.SaveScenario(ScenarioContext, ScenarioContext.GetCurrentSide(), FilePath, SBR: false);
	}

	public static LuaTable ScenEdit_GetUnitIntermittentEmissionConfig(string PresetAlertID, string string_0, Scenario ScenarioContext)
	{
		LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
		ActiveUnit activeUnitByNameOrID = Misc.GetActiveUnitByNameOrID(string_0, ScenarioContext);
		if (!Information.IsNothing((object)activeUnitByNameOrID))
		{
			if (activeUnitByNameOrID.Sensory.IntermittentEmission != null)
			{
				ActiveEmissionInterval intermittentEmission = activeUnitByNameOrID.Sensory.GetIntermittentEmission();
				Alertlevels selectedIntermittentEmissionConfig_ByString = Misc.GetSelectedIntermittentEmissionConfig_ByString(PresetAlertID);
				if (selectedIntermittentEmissionConfig_ByString == Alertlevels.Unknown)
				{
					return null;
				}
				luaTable["EMISSIONDURATION"] = intermittentEmission.Configs[selectedIntermittentEmissionConfig_ByString].EmissionDuration;
				luaTable["EMISSIONINTERVAL"] = intermittentEmission.Configs[selectedIntermittentEmissionConfig_ByString].EmissionInterval;
				luaTable["EMISSIONINTERVALVARIATION"] = intermittentEmission.Configs[selectedIntermittentEmissionConfig_ByString].EmissionIntervalVariation;
				luaTable["SLEEPMODEDELAY"] = intermittentEmission.Configs[selectedIntermittentEmissionConfig_ByString].SleepModeDelay;
				luaTable["USEEMISSIONINTERVAL"] = intermittentEmission.Configs[selectedIntermittentEmissionConfig_ByString].UseEmissionInterval;
				luaTable["FOLLOWWRAFORWAKEBEHAVIOR"] = intermittentEmission.Configs[selectedIntermittentEmissionConfig_ByString].FollowWRAforWakeBehavior;
				luaTable["WAKEWHENDETECTINGTHREAT"] = intermittentEmission.Configs[selectedIntermittentEmissionConfig_ByString].WakeWhenDetectingThreat;
				luaTable["WAKEID_UNKNOWN"] = intermittentEmission.Configs[selectedIntermittentEmissionConfig_ByString].Wake_IncludesContactID[Contact_Base.IdentificationStatus.Unknown];
				luaTable["WAKEID_PRECISEID"] = intermittentEmission.Configs[selectedIntermittentEmissionConfig_ByString].Wake_IncludesContactID[Contact_Base.IdentificationStatus.PreciseID];
				luaTable["WAKEID_KNWONTYPE"] = intermittentEmission.Configs[selectedIntermittentEmissionConfig_ByString].Wake_IncludesContactID[Contact_Base.IdentificationStatus.KnownType];
				luaTable["WAKEIDKNOWNDOMAIN"] = intermittentEmission.Configs[selectedIntermittentEmissionConfig_ByString].Wake_IncludesContactID[Contact_Base.IdentificationStatus.KnownDomain];
				luaTable["WAKEIDKNOWNCLASS"] = intermittentEmission.Configs[selectedIntermittentEmissionConfig_ByString].Wake_IncludesContactID[Contact_Base.IdentificationStatus.KnownClass];
				luaTable["WAKESTANCE_FRIENDLY"] = intermittentEmission.Configs[selectedIntermittentEmissionConfig_ByString].Wake_IncludesContactStance[Misc.PostureStance.Friendly];
				luaTable["WAKESTANCE_HOSTILE"] = intermittentEmission.Configs[selectedIntermittentEmissionConfig_ByString].Wake_IncludesContactStance[Misc.PostureStance.Hostile];
				luaTable["WAKESTANCE_NEUTRAL"] = intermittentEmission.Configs[selectedIntermittentEmissionConfig_ByString].Wake_IncludesContactStance[Misc.PostureStance.Neutral];
				luaTable["WAKESTANCE_UNFRIENDLY"] = intermittentEmission.Configs[selectedIntermittentEmissionConfig_ByString].Wake_IncludesContactStance[Misc.PostureStance.Unfriendly];
				luaTable["WAKESTANCE_UNKNOWN"] = intermittentEmission.Configs[selectedIntermittentEmissionConfig_ByString].Wake_IncludesContactStance[Misc.PostureStance.Unknown];
				return luaTable;
			}
			return null;
		}
		return null;
	}

	public static bool ScenEdit_SetUnitIntermittentEmissionConfig(string string_0, string PresetAlertID, LuaTable ConfigurationTable, Scenario ScenarioContext)
	{
		ActiveUnit activeUnitByNameOrID = Misc.GetActiveUnitByNameOrID(string_0, ScenarioContext);
		if (Information.IsNothing((object)activeUnitByNameOrID))
		{
			return false;
		}
		if (!Information.IsNothing((object)ConfigurationTable))
		{
			if (activeUnitByNameOrID.Sensors_Cached.Length == 0)
			{
				return false;
			}
			ActiveEmissionInterval intermittentEmission = activeUnitByNameOrID.Sensory.GetIntermittentEmission();
			Alertlevels key = default(Alertlevels);
			switch (PresetAlertID.ToUpper())
			{
			case "CUSTOM":
				key = Alertlevels.Custom;
				break;
			case "ALL":
				ScenEdit_SetUnitIntermittentEmissionConfig(string_0, "Green", ConfigurationTable, ScenarioContext);
				ScenEdit_SetUnitIntermittentEmissionConfig(string_0, "Blue", ConfigurationTable, ScenarioContext);
				ScenEdit_SetUnitIntermittentEmissionConfig(string_0, "Yellow", ConfigurationTable, ScenarioContext);
				ScenEdit_SetUnitIntermittentEmissionConfig(string_0, "Orange", ConfigurationTable, ScenarioContext);
				ScenEdit_SetUnitIntermittentEmissionConfig(string_0, "Red", ConfigurationTable, ScenarioContext);
				ScenEdit_SetUnitIntermittentEmissionConfig(string_0, "Custom", ConfigurationTable, ScenarioContext);
				return true;
			case "BLUE":
				key = Alertlevels.Blue;
				break;
			case "ORANGE":
				key = Alertlevels.Orange;
				break;
			case "RED":
				key = Alertlevels.Red;
				break;
			case "YELLOW":
				key = Alertlevels.Yellow;
				break;
			case "GREEN":
				key = Alertlevels.Green;
				break;
			}
			Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(ConfigurationTable.GetEnumerator());
			if (dictionary.ContainsKey("USEEMISSIONINTERVAL"))
			{
				intermittentEmission.Configs[key].UseEmissionInterval = Conversions.ToBoolean(dictionary["USEEMISSIONINTERVAL"]);
			}
			if (dictionary.ContainsKey("EMISSIONDURATION"))
			{
				intermittentEmission.Configs[key].EmissionDuration = Conversions.ToSingle(dictionary["EMISSIONDURATION"]);
			}
			if (dictionary.ContainsKey("EMISSIONINTERVALVARIATION"))
			{
				intermittentEmission.Configs[key].EmissionIntervalVariation = Conversions.ToSingle(dictionary["EMISSIONINTERVALVARIATION"]);
			}
			if (dictionary.ContainsKey("SLEEPMODEDELAY"))
			{
				intermittentEmission.Configs[key].SleepModeDelay = Conversions.ToSingle(dictionary["SLEEPMODEDELAY"]);
			}
			if (dictionary.ContainsKey("EMISSIONINTERVAL"))
			{
				intermittentEmission.Configs[key].EmissionInterval = Conversions.ToSingle(dictionary["EMISSIONINTERVAL"]);
			}
			if (dictionary.ContainsKey("FOLLOWWRAFORWAKEBEHAVIOR"))
			{
				intermittentEmission.Configs[key].FollowWRAforWakeBehavior = Conversions.ToBoolean(dictionary["FOLLOWWRAFORWAKEBEHAVIOR"]);
			}
			if (dictionary.ContainsKey("WAKEWHENDETECTINGTHREAT"))
			{
				intermittentEmission.Configs[key].WakeWhenDetectingThreat = Conversions.ToBoolean(dictionary["WAKEWHENDETECTINGTHREAT"]);
			}
			if (dictionary.ContainsKey("WAKEID_UNKNOWN"))
			{
				intermittentEmission.Configs[key].Wake_IncludesContactID[Contact_Base.IdentificationStatus.Unknown] = Conversions.ToBoolean(dictionary["WAKEID_UNKNOWN"]);
			}
			if (dictionary.ContainsKey("WAKEID_PRECISEID"))
			{
				intermittentEmission.Configs[key].Wake_IncludesContactID[Contact_Base.IdentificationStatus.PreciseID] = Conversions.ToBoolean(dictionary["WAKEID_PRECISEID"]);
			}
			if (dictionary.ContainsKey("WAKEID_KNWONTYPE"))
			{
				intermittentEmission.Configs[key].Wake_IncludesContactID[Contact_Base.IdentificationStatus.KnownType] = Conversions.ToBoolean(dictionary["WAKEID_KNWONTYPE"]);
			}
			if (dictionary.ContainsKey("WAKEIDKNOWNDOMAIN"))
			{
				intermittentEmission.Configs[key].Wake_IncludesContactID[Contact_Base.IdentificationStatus.KnownDomain] = Conversions.ToBoolean(dictionary["WAKEIDKNOWNDOMAIN"]);
			}
			if (dictionary.ContainsKey("WAKEIDKNOWNCLASS"))
			{
				intermittentEmission.Configs[key].Wake_IncludesContactID[Contact_Base.IdentificationStatus.KnownClass] = Conversions.ToBoolean(dictionary["WAKEIDKNOWNCLASS"]);
			}
			if (dictionary.ContainsKey("WAKESTANCE_FRIENDLY"))
			{
				intermittentEmission.Configs[key].Wake_IncludesContactStance[Misc.PostureStance.Friendly] = Conversions.ToBoolean(dictionary["WAKESTANCE_FRIENDLY"]);
			}
			if (dictionary.ContainsKey("WAKESTANCE_HOSTILE"))
			{
				intermittentEmission.Configs[key].Wake_IncludesContactStance[Misc.PostureStance.Hostile] = Conversions.ToBoolean(dictionary["WAKESTANCE_HOSTILE"]);
			}
			if (dictionary.ContainsKey("WAKESTANCE_NEUTRAL"))
			{
				intermittentEmission.Configs[key].Wake_IncludesContactStance[Misc.PostureStance.Neutral] = Conversions.ToBoolean(dictionary["WAKESTANCE_NEUTRAL"]);
			}
			if (dictionary.ContainsKey("WAKESTANCE_UNFRIENDLY"))
			{
				intermittentEmission.Configs[key].Wake_IncludesContactStance[Misc.PostureStance.Unfriendly] = Conversions.ToBoolean(dictionary["WAKESTANCE_UNFRIENDLY"]);
			}
			int result;
			if (dictionary.ContainsKey("WAKESTANCE_UNKNOWN"))
			{
				intermittentEmission.Configs[key].Wake_IncludesContactStance[Misc.PostureStance.Unknown] = Conversions.ToBoolean(dictionary["WAKESTANCE_UNKNOWN"]);
				result = 1;
			}
			else
			{
				result = 1;
			}
			return (byte)result != 0;
		}
		return false;
	}

	public static bool ScenEdit_DuplicateEmconConfigToUnit(string PresetAlertID, string SourceAUNameOrID, string TargetAUNameOrID, Scenario ScenarioContext)
	{
		ActiveUnit activeUnitByNameOrID = Misc.GetActiveUnitByNameOrID(SourceAUNameOrID, ScenarioContext);
		ActiveUnit activeUnitByNameOrID2 = Misc.GetActiveUnitByNameOrID(TargetAUNameOrID, ScenarioContext);
		ActiveEmissionInterval intermittentEmission;
		ActiveEmissionInterval intermittentEmission2;
		int result;
		Alertlevels alert;
		int result2;
		if (activeUnitByNameOrID != null)
		{
			if (activeUnitByNameOrID2 != null)
			{
				if (activeUnitByNameOrID.Sensors_Cached.Length != 0 && activeUnitByNameOrID2.Sensors_Cached.Length != 0)
				{
					intermittentEmission = activeUnitByNameOrID.Sensory.GetIntermittentEmission();
					intermittentEmission2 = activeUnitByNameOrID2.Sensory.GetIntermittentEmission();
					string text = PresetAlertID.ToUpper();
					uint num = <PrivateImplementationDetails>{A835D9A0-0EE4-445E-BC69-5FEB38C502A4}.ComputeStringHash(text);
					if (num <= 2203911150u)
					{
						if (num != 750204685)
						{
							if (num != 1432457764)
							{
								if (num != 2203911150u)
								{
									result = 0;
									goto IL_01cd;
								}
								if (Operators.CompareString(text, "CUSTOM", false) == 0)
								{
									alert = Alertlevels.Custom;
									goto IL_01be;
								}
							}
							else if (Operators.CompareString(text, "ALL", false) == 0)
							{
								ScenEdit_DuplicateEmconConfigToUnit("Green", SourceAUNameOrID, TargetAUNameOrID, ScenarioContext);
								ScenEdit_DuplicateEmconConfigToUnit("Blue", SourceAUNameOrID, TargetAUNameOrID, ScenarioContext);
								ScenEdit_DuplicateEmconConfigToUnit("Yellow", SourceAUNameOrID, TargetAUNameOrID, ScenarioContext);
								ScenEdit_DuplicateEmconConfigToUnit("Orange", SourceAUNameOrID, TargetAUNameOrID, ScenarioContext);
								ScenEdit_DuplicateEmconConfigToUnit("Red", SourceAUNameOrID, TargetAUNameOrID, ScenarioContext);
								ScenEdit_DuplicateEmconConfigToUnit("Custom", SourceAUNameOrID, TargetAUNameOrID, ScenarioContext);
								return true;
							}
						}
						else if (Operators.CompareString(text, "BLUE", false) == 0)
						{
							alert = Alertlevels.Blue;
							goto IL_01be;
						}
						goto IL_01cc;
					}
					if (num > 2443363051u)
					{
						if (num != 2875364188u)
						{
							if (num != 2964049737u)
							{
								result = 0;
							}
							else
							{
								if (Operators.CompareString(text, "YELLOW", false) == 0)
								{
									alert = Alertlevels.Yellow;
									goto IL_01be;
								}
								result = 0;
							}
						}
						else
						{
							if (Operators.CompareString(text, "GREEN", false) == 0)
							{
								alert = Alertlevels.Green;
								goto IL_01be;
							}
							result = 0;
						}
					}
					else
					{
						if (num == 2211354620u)
						{
							if (Operators.CompareString(text, "RED", false) == 0)
							{
								alert = Alertlevels.Red;
								goto IL_01be;
							}
							goto IL_01cc;
						}
						if (num != 2443363051u)
						{
							result = 0;
						}
						else
						{
							if (Operators.CompareString(text, "ORANGE", false) == 0)
							{
								alert = Alertlevels.Orange;
								goto IL_01be;
							}
							result = 0;
						}
					}
					goto IL_01cd;
				}
				return false;
			}
			result2 = 0;
		}
		else
		{
			result2 = 0;
		}
		return (byte)result2 != 0;
		IL_01cc:
		result = 0;
		goto IL_01cd;
		IL_01be:
		intermittentEmission2.PasteConfig(alert, intermittentEmission);
		return true;
		IL_01cd:
		return (byte)result != 0;
	}

	public static bool ScenEdit_DuplicateEmconConfigToSide(string PresetAlertID, string SourceAUNameOrID, string TargetSideNameOrID, Scenario ScenarioContext)
	{
		ActiveUnit activeUnitByNameOrID = Misc.GetActiveUnitByNameOrID(SourceAUNameOrID, ScenarioContext);
		ActiveEmissionInterval intermittentEmission;
		Side side;
		int result;
		Alertlevels alert;
		if (!Information.IsNothing((object)activeUnitByNameOrID))
		{
			if (activeUnitByNameOrID.Sensors_Cached.Length != 0)
			{
				intermittentEmission = activeUnitByNameOrID.Sensory.GetIntermittentEmission();
				side = (from s in ScenarioContext.Sides_ReadOnly
					where string.Equals(s.ObjectID, TargetSideNameOrID, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Name, TargetSideNameOrID, StringComparison.OrdinalIgnoreCase)
					select (s)).First();
				if (!Information.IsNothing((object)side))
				{
					string text = PresetAlertID.ToUpper();
					uint num = <PrivateImplementationDetails>{A835D9A0-0EE4-445E-BC69-5FEB38C502A4}.ComputeStringHash(text);
					if (num > 2203911150u)
					{
						if (num > 2443363051u)
						{
							if (num != 2875364188u)
							{
								if (num != 2964049737u)
								{
									result = 0;
								}
								else
								{
									if (Operators.CompareString(text, "YELLOW", false) == 0)
									{
										alert = Alertlevels.Yellow;
										goto IL_0235;
									}
									result = 0;
								}
							}
							else
							{
								if (Operators.CompareString(text, "GREEN", false) == 0)
								{
									alert = Alertlevels.Green;
									goto IL_0235;
								}
								result = 0;
							}
							goto IL_022f;
						}
						if (num != 2211354620u)
						{
							if (num != 2443363051u)
							{
								result = 0;
								goto IL_022f;
							}
							if (Operators.CompareString(text, "ORANGE", false) != 0)
							{
								goto IL_021c;
							}
							alert = Alertlevels.Orange;
						}
						else
						{
							if (Operators.CompareString(text, "RED", false) != 0)
							{
								goto IL_021c;
							}
							alert = Alertlevels.Red;
						}
					}
					else
					{
						if (num != 750204685)
						{
							if (num != 1432457764)
							{
								if (num != 2203911150u)
								{
									result = 0;
									goto IL_022f;
								}
								if (Operators.CompareString(text, "CUSTOM", false) == 0)
								{
									alert = Alertlevels.Custom;
									goto IL_0235;
								}
							}
							else if (Operators.CompareString(text, "ALL", false) == 0)
							{
								ScenEdit_DuplicateEmconConfigToSide("Green", SourceAUNameOrID, TargetSideNameOrID, ScenarioContext);
								ScenEdit_DuplicateEmconConfigToSide("Blue", SourceAUNameOrID, TargetSideNameOrID, ScenarioContext);
								ScenEdit_DuplicateEmconConfigToSide("Yellow", SourceAUNameOrID, TargetSideNameOrID, ScenarioContext);
								ScenEdit_DuplicateEmconConfigToSide("Orange", SourceAUNameOrID, TargetSideNameOrID, ScenarioContext);
								ScenEdit_DuplicateEmconConfigToSide("Red", SourceAUNameOrID, TargetSideNameOrID, ScenarioContext);
								ScenEdit_DuplicateEmconConfigToSide("Custom", SourceAUNameOrID, TargetSideNameOrID, ScenarioContext);
								return true;
							}
							goto IL_021c;
						}
						if (Operators.CompareString(text, "BLUE", false) != 0)
						{
							result = 0;
							goto IL_022f;
						}
						alert = Alertlevels.Blue;
					}
					goto IL_0235;
				}
				return false;
			}
			return false;
		}
		return false;
		IL_0235:
		side.PasteIntermittentConfig(alert, intermittentEmission);
		return true;
		IL_021c:
		result = 0;
		goto IL_022f;
		IL_022f:
		return (byte)result != 0;
	}

	public static bool ScenEdit_SwitchUnitIntermittentEmission(string string_0, string PresetAlertID, float Switch, Scenario ScenarioContext)
	{
		LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
		luaTable["USEEMISSIONINTERVAL"] = Switch;
		return ScenEdit_SetUnitIntermittentEmissionConfig(string_0, PresetAlertID, luaTable, ScenarioContext);
	}

	public static bool ScenEdit_CreateBarkNotification_Unit(string string_0, string text, int R, int G, int B, bool MoveUpward, bool Fades, float Lifetime, float FontSize, Scenario ScenarioContext)
	{
		ActiveUnit activeUnitByNameOrID = Misc.GetActiveUnitByNameOrID(string_0, ScenarioContext);
		Color color = Color.FromArgb(R, G, B);
		if (activeUnitByNameOrID != null)
		{
			Notification_Bark.Create(activeUnitByNameOrID, text, color, MoveUpward, Fades, Lifetime, FontSize);
			return true;
		}
		return false;
	}

	public static bool ScenEdit_CreateBarkNotification_Geo(float Longitude, float Latitude, string text, int R, int G, int B, bool MoveUpward, bool Fades, float Lifetime, float FontSize, Scenario ScenarioContext)
	{
		Color color = Color.FromArgb(R, G, B);
		Notification_Bark.Create(Longitude, Latitude, text, color, MoveUpward, Fades, Lifetime, FontSize);
		return true;
	}

	public static bool ScenEdit_CreateBarkNotification_Unit_Bulk(string string_0, LuaTable text, int R, int G, int B, bool MoveUpward, bool Fades, float Lifetime, float FontSize, Scenario ScenarioContext)
	{
		ActiveUnit activeUnitByNameOrID = Misc.GetActiveUnitByNameOrID(string_0, ScenarioContext);
		Color color = Color.FromArgb(R, G, B);
		List<object> list = new List<object>();
		if (!Information.IsNothing((object)text))
		{
			list = LuaUtility.ToArray(text.GetEnumerator());
			List<string> list2 = new List<string>();
			foreach (object item in list)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(item);
				list2.Add(objectValue.ToString());
			}
			if (activeUnitByNameOrID != null)
			{
				Notification_Bark.Create(activeUnitByNameOrID, list2, color, MoveUpward, Fades, Lifetime, FontSize);
				return true;
			}
			return false;
		}
		return false;
	}

	public static bool ScenEdit_CreateBarkNotification_Geo_Bulk(float Longitude, float Latitude, LuaTable text, int R, int G, int B, bool MoveUpward, bool Fades, float Lifetime, float FontSize, Scenario ScenarioContext)
	{
		Color color = Color.FromArgb(R, G, B);
		List<object> list = new List<object>();
		if (Information.IsNothing((object)text))
		{
			return false;
		}
		list = LuaUtility.ToArray(text.GetEnumerator());
		List<string> list2 = new List<string>();
		foreach (object item in list)
		{
			object objectValue = RuntimeHelpers.GetObjectValue(item);
			list2.Add(objectValue.ToString());
		}
		Notification_Bark.Create(Longitude, Latitude, list2, color, MoveUpward, Fades, Lifetime, FontSize);
		return true;
	}

	public static bool ScenEdit_SetSideEmconAlertness(string SideNameOrID, string AlertID, Scenario ScenarioContext)
	{
		Side side = (from s in ScenarioContext.Sides_ReadOnly
			where string.Equals(s.ObjectID, SideNameOrID, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Name, SideNameOrID, StringComparison.OrdinalIgnoreCase)
			select (s)).First();
		if (!Information.IsNothing((object)side))
		{
			int result;
			switch (AlertID)
			{
			case "Green":
				side.EmconAlertness.Level = Alertlevels.Green;
				result = 1;
				break;
			case "Yellow":
				side.EmconAlertness.Level = Alertlevels.Yellow;
				result = 1;
				break;
			default:
				return false;
			case "Custom":
				side.EmconAlertness.Level = Alertlevels.Custom;
				result = 1;
				break;
			case "Red":
				side.EmconAlertness.Level = Alertlevels.Red;
				result = 1;
				break;
			case "Orange":
				side.EmconAlertness.Level = Alertlevels.Orange;
				result = 1;
				break;
			case "Blue":
				side.EmconAlertness.Level = Alertlevels.Blue;
				result = 1;
				break;
			}
			return (byte)result != 0;
		}
		return false;
	}

	public static bool ScenEdit_ClearAllSideUnitsEmconConfigs(string SideNameOrID, Scenario ScenarioContext)
	{
		_Closure$__101-0 arg = default(_Closure$__101-0);
		_Closure$__101-0 CS$<>8__locals3 = new _Closure$__101-0(arg);
		CS$<>8__locals3.$VB$Local_SideNameOrID = SideNameOrID;
		Side side = (from s in ScenarioContext.Sides_ReadOnly
			where string.Equals(s.ObjectID, CS$<>8__locals3.$VB$Local_SideNameOrID, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Name, CS$<>8__locals3.$VB$Local_SideNameOrID, StringComparison.OrdinalIgnoreCase)
			select (s)).First();
		if (Information.IsNothing((object)side))
		{
			return false;
		}
		foreach (ActiveUnit unit in side.Units)
		{
			if (unit.IsActiveUnit)
			{
				ActiveUnit activeUnit = unit;
				if (activeUnit.Sensory.IntermittentEmission != null)
				{
					unit.Sensory.GetIntermittentEmission().Initialize(activeUnit.Sensory, Reinitialise: true);
				}
			}
		}
		bool result = default(bool);
		return result;
	}

	public static bool ScenEdit_ClearUnitEmconConfigs(string UnitNameorID, Scenario ScenarioContext)
	{
		ActiveUnit activeUnitByNameOrID = Misc.GetActiveUnitByNameOrID(UnitNameorID, ScenarioContext);
		if (!Information.IsNothing((object)activeUnitByNameOrID))
		{
			if (activeUnitByNameOrID.Sensors_Cached.Length == 0)
			{
				return false;
			}
			if (activeUnitByNameOrID.Sensory.IntermittentEmission != null)
			{
				activeUnitByNameOrID.Sensory.GetIntermittentEmission().Initialize(activeUnitByNameOrID.Sensory, Reinitialise: true);
				return true;
			}
			return false;
		}
		return false;
	}

	public static bool Exporter_SetSetting(string Category, string Setting, string Value, Scenario ScenarioContext)
	{
		bool result = false;
		if (FileExistsNative.FileExistsFast(Exporter_General.EventExporter_ConfigFileName))
		{
			IniConfigSource iniConfigSource = new IniConfigSource(Exporter_General.EventExporter_ConfigFileName);
			if (Operators.CompareString(Category, "General", false) != 0)
			{
				if (Operators.CompareString(Category, "CSV Settings", false) != 0)
				{
					if (Operators.CompareString(Category, "XML Settings", false) != 0)
					{
						switch (Category)
						{
						case "Tacview Settings":
							switch (Setting)
							{
							case "UseCustomUnitExportFrequency":
							{
								if (bool.TryParse(Value, out var result7))
								{
									iniConfigSource.Configs[Category].Set(Setting, result7);
									result = true;
								}
								break;
							}
							case "SpeedBandFrequency160To320":
							case "SpeedBandFrequency1280To2560":
							case "SpeedBandFrequency80To160":
							case "SpeedBandFrequencyOver2560":
							case "SpeedBandFrequencyDynamic":
							case "SpeedBandFrequency40To80":
							case "SpeedBandFrequency640To1280":
							case "SpeedBandFrequency20To40":
							case "SpeedBandFrequency0To20":
							case "SpeedBandFrequency320To640":
							{
								int num;
								if (int.TryParse(Value, out var result6))
								{
									iniConfigSource.Configs[Category].Set(Setting, result6);
									num = 1;
								}
								else
								{
									num = 1;
								}
								result = (byte)num != 0;
								break;
							}
							}
							break;
						case "SQLServer Settings":
						case "SQLite Settings":
							switch (Setting)
							{
							case "ConnectionString":
								iniConfigSource.Configs[Category].Set(Setting, Value);
								result = true;
								break;
							case "SpeedBandFrequency320To640":
							case "BatchSize":
							case "SpeedBandFrequency20To40":
							case "SpeedBandFrequency0To20":
							case "SpeedBandFrequency640To1280":
							case "SpeedBandFrequencyDynamic":
							case "SpeedBandFrequency40To80":
							case "SpeedBandFrequency80To160":
							case "SpeedBandFrequency160To320":
							case "SpeedBandFrequency1280To2560":
							case "SpeedBandFrequencyOver2560":
							{
								if (int.TryParse(Value, out var result5))
								{
									iniConfigSource.Configs[Category].Set(Setting, result5);
									result = true;
								}
								break;
							}
							case "ExportEngagementCycle":
							case "ExportAirOps":
							case "ConsolidateCSV":
							case "ExportSensorDetectionFailure":
							case "ExportDockingOps":
							case "ExportFuelTransfer":
							case "ExportSensorDetectionSuccess":
							case "ExportUnitDestroyed":
							case "ExportUnitPositions":
							case "ExportCargoTransfer":
							case "SplitFilesBySide":
							case "ExportFuelConsumed":
							case "ExportUnitDamaged":
							case "UseZeroHour":
							case "ExportWeaponEndgame":
							case "ExportWeaponFired":
							case "UseCustomUnitExportFrequency":
							{
								if (bool.TryParse(Value, out var result4))
								{
									iniConfigSource.Configs[Category].Set(Setting, result4);
									result = true;
								}
								break;
							}
							}
							break;
						case "XML Settings":
						case "MSAccess Settings":
							switch (Setting)
							{
							case "ExportSensorDetectionFailure":
							case "ExportDockingOps":
							case "ExportAirOps":
							case "ConsolidateCSV":
							case "ExportEngagementCycle":
							case "ExportUnitPositions":
							case "ExportCargoTransfer":
							case "ExportSensorDetectionSuccess":
							case "ExportUnitDestroyed":
							case "ExportFuelTransfer":
							case "SplitFilesBySide":
							case "ExportFuelConsumed":
							case "ExportUnitDamaged":
							case "UseZeroHour":
							case "ExportWeaponFired":
							case "UseCustomUnitExportFrequency":
							case "ExportWeaponEndgame":
							{
								if (bool.TryParse(Value, out var result3))
								{
									iniConfigSource.Configs[Category].Set(Setting, result3);
									result = true;
								}
								break;
							}
							case "SpeedBandFrequencyDynamic":
							case "SpeedBandFrequency320To640":
							case "SpeedBandFrequency0To20":
							case "SpeedBandFrequency20To40":
							case "SpeedBandFrequency160To320":
							case "SpeedBandFrequency40To80":
							case "SpeedBandFrequency640To1280":
							case "SpeedBandFrequencyOver2560":
							case "SpeedBandFrequency1280To2560":
							case "SpeedBandFrequency80To160":
							{
								if (int.TryParse(Value, out var result2))
								{
									result = true;
									iniConfigSource.Configs[Category].Set(Setting, result2);
								}
								break;
							}
							}
							break;
						}
					}
					else
					{
						switch (Setting)
						{
						case "ExportFuelTransfer":
						case "ExportSensorDetectionSuccess":
						case "ExportUnitDestroyed":
						case "ExportUnitPositions":
						case "ExportCargoTransfer":
						case "ExportEngagementCycle":
						case "ExportAirOps":
						case "ConsolidateCSV":
						case "ExportSensorDetectionFailure":
						case "ExportDockingOps":
						case "ExportWeaponEndgame":
						case "ExportWeaponFired":
						case "UseCustomUnitExportFrequency":
						case "UseZeroHour":
						case "ExportUnitDamaged":
						case "SplitFilesBySide":
						case "ExportFuelConsumed":
						{
							if (bool.TryParse(Value, out var result9))
							{
								iniConfigSource.Configs[Category].Set(Setting, result9);
								result = true;
							}
							break;
						}
						case "SpeedBandFrequency20To40":
						case "SpeedBandFrequency0To20":
						case "SpeedBandFrequency320To640":
						case "SpeedBandFrequencyDynamic":
						case "SpeedBandFrequency1280To2560":
						case "SpeedBandFrequency80To160":
						case "SpeedBandFrequencyOver2560":
						case "SpeedBandFrequency640To1280":
						case "SpeedBandFrequency40To80":
						case "SpeedBandFrequency160To320":
						{
							if (int.TryParse(Value, out var result8))
							{
								iniConfigSource.Configs[Category].Set(Setting, result8);
								result = true;
							}
							break;
						}
						}
					}
				}
				else
				{
					switch (Setting)
					{
					case "ExportEngagementCycle":
					case "ExportAirOps":
					case "ConsolidateCSV":
					case "ExportSensorDetectionFailure":
					case "ExportDockingOps":
					case "ExportUnitPositions":
					case "ExportCargoTransfer":
					case "ExportSensorDetectionSuccess":
					case "ExportUnitDestroyed":
					case "ExportFuelTransfer":
					case "ExportWeaponEndgame":
					case "ExportWeaponFired":
					case "UseCustomUnitExportFrequency":
					case "ExportUnitDamaged":
					case "UseZeroHour":
					case "SplitFilesBySide":
					case "ExportFuelConsumed":
					{
						if (bool.TryParse(Value, out var result11))
						{
							iniConfigSource.Configs[Category].Set(Setting, result11);
							result = true;
						}
						break;
					}
					case "SpeedBandFrequency320To640":
					case "SpeedBandFrequencyDynamic":
					case "SpeedBandFrequency0To20":
					case "SpeedBandFrequency20To40":
					case "SpeedBandFrequency1280To2560":
					case "SpeedBandFrequency80To160":
					case "SpeedBandFrequencyOver2560":
					case "SpeedBandFrequency40To80":
					case "SpeedBandFrequency640To1280":
					case "SpeedBandFrequency160To320":
					{
						if (int.TryParse(Value, out var result10))
						{
							iniConfigSource.Configs[Category].Set(Setting, result10);
							result = true;
						}
						break;
					}
					}
				}
			}
			else
			{
				switch (Setting)
				{
				case "AutoStartExporter":
				{
					bool result12 = false;
					if (bool.TryParse(Value, out result12))
					{
						iniConfigSource.Configs[Category].Set(Setting, Value);
						result = true;
					}
					break;
				}
				case "OutputSeparated":
				{
					bool result13 = false;
					if (bool.TryParse(Value, out result13))
					{
						iniConfigSource.Configs[Category].Set(Setting, Value);
						result = true;
					}
					break;
				}
				case "OutputRoot":
					if (Misc.Dir_WritePermission(Value))
					{
						iniConfigSource.Configs[Category].Set(Setting, Value);
						result = true;
					}
					break;
				case "ActiveExporter":
				{
					string[] array = Value.Split(Conversions.ToCharArrayRankOne(","));
					foreach (string text in array)
					{
						if (!string.IsNullOrEmpty(text))
						{
							switch (text)
							{
							case "CSV":
							case "Tacview1x":
							case "Tacview2x":
							case "XML":
							case "MSAccess":
							case "SQLServer":
							case "SQLite":
							case "SIMDIS":
								continue;
							}
							return false;
						}
					}
					iniConfigSource.Configs[Category].Set(Setting, Value);
					result = true;
					break;
				}
				}
			}
			iniConfigSource.Save();
			Exporter_General.StartEventExporters_Interactive(ScenarioContext, HotAdjunctionMode: true);
			IEventExporter[] eventExporters_Interactive = Exporter_General.EventExporters_Interactive;
			foreach (IEventExporter eventExporter in eventExporters_Interactive)
			{
				eventExporter.Common.GetCommonConfig(eventExporter.Common.GetExporterTypeAsCategoryString());
			}
			IEventExporter[] eventExporters_MonteCarlo = Exporter_General.EventExporters_MonteCarlo;
			foreach (IEventExporter eventExporter2 in eventExporters_MonteCarlo)
			{
				eventExporter2.Common.GetCommonConfig(eventExporter2.Common.GetExporterTypeAsCategoryString());
			}
		}
		return result;
	}

	public static void Exporter_AddUnitPositionFrequency(string Category, string Setting, string Value)
	{
	}

	public static void Exporter_RemoveUnitPositionFrequency(string Category, string Setting, string Value)
	{
	}

	public static void Exporter_GetUnitPositionFrequency(string Category, string Setting, string Value)
	{
	}

	public static string ScenEdit_AddAircraft(string SideNameOrID, string ACName, int DBID, int LoadoutID, string CoordsFormat, string Lat, string Lon, Scenario ScenarioContext)
	{
		Side theSide = (from s in ScenarioContext.Sides_ReadOnly
			where string.Equals(s.ObjectID, SideNameOrID, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Name, SideNameOrID, StringComparison.OrdinalIgnoreCase)
			select (s)).First();
		double longitude = default(double);
		double latitude = default(double);
		if (Operators.CompareString(CoordsFormat, "DEC", false) == 0)
		{
			Lon = Lon.Replace(",", ".");
			Lat = Lat.Replace(",", ".");
			longitude = XmlConvert.ToDouble(Lon);
			latitude = XmlConvert.ToDouble(Lat);
		}
		else if (Operators.CompareString(CoordsFormat, "DEG", false) == 0)
		{
			longitude = LuaUtility.ParseLongitudeString(Lon);
			latitude = LuaUtility.ParseLatitudeString(Lat);
		}
		return ScenarioContext.AddNewAircraft(theSide, ACName, longitude, latitude, DBID, LoadoutID, 1000f).ObjectID;
	}

	public static string ScenEdit_AddShip(string SideNameOrID, string ShipName, int DBID, string CoordsFormat, string Lat, string Lon, Scenario ScenarioContext)
	{
		Side theSide = (from s in ScenarioContext.Sides_ReadOnly
			where string.Equals(s.ObjectID, SideNameOrID, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Name, SideNameOrID, StringComparison.OrdinalIgnoreCase)
			select (s)).First();
		double longitude = default(double);
		double latitude = default(double);
		if (Operators.CompareString(CoordsFormat, "DEC", false) != 0)
		{
			if (Operators.CompareString(CoordsFormat, "DEG", false) == 0)
			{
				longitude = LuaUtility.ParseLongitudeString(Lon);
				latitude = LuaUtility.ParseLatitudeString(Lat);
			}
		}
		else
		{
			Lon = Lon.Replace(",", ".");
			Lat = Lat.Replace(",", ".");
			longitude = XmlConvert.ToDouble(Lon);
			latitude = XmlConvert.ToDouble(Lat);
		}
		return ScenarioContext.AddNewShip(theSide, DBID, ShipName, longitude, latitude).ObjectID;
	}

	public static string ScenEdit_AddSubmarine(string SideNameOrID, string SubName, int DBID, string CoordsFormat, string Lat, string Lon, Scenario ScenarioContext)
	{
		Side theSide = (from s in ScenarioContext.Sides_ReadOnly
			where string.Equals(s.ObjectID, SideNameOrID, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Name, SideNameOrID, StringComparison.OrdinalIgnoreCase)
			select (s)).First();
		double longitude = default(double);
		double latitude = default(double);
		if (Operators.CompareString(CoordsFormat, "DEC", false) == 0)
		{
			Lon = Lon.Replace(",", ".");
			Lat = Lat.Replace(",", ".");
			longitude = XmlConvert.ToDouble(Lon);
			latitude = XmlConvert.ToDouble(Lat);
		}
		else if (Operators.CompareString(CoordsFormat, "DEG", false) == 0)
		{
			longitude = LuaUtility.ParseLongitudeString(Lon);
			latitude = LuaUtility.ParseLatitudeString(Lat);
		}
		return ScenarioContext.AddNewSubmarine(theSide, DBID, SubName, longitude, latitude).ObjectID;
	}

	public static bool ScenEdit_AddExplosion(LuaTable table, Scenario ScenarioContext)
	{
		Weapon._WeaponType theWeaponType = Weapon._WeaponType.IronBomb;
		Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(table.GetEnumerator());
		if (dictionary.ContainsKey("WARHEADID"))
		{
			int warheadID = Conversions.ToInteger(dictionary["WARHEADID"]);
			if (dictionary.ContainsKey("WEAPONTYPE") && (Enum.TryParse<Weapon._WeaponType>(Conversions.ToString(dictionary["WEAPONTYPE"]), ignoreCase: true, out var result) & Enum.IsDefined(typeof(Weapon._WeaponType), result)))
			{
				theWeaponType = result;
			}
			double? num = LuaUtility.QueryLatitude(dictionary);
			if (num.HasValue)
			{
				double? num2 = LuaUtility.QueryLongitude(dictionary);
				if (num2.HasValue)
				{
					int num3 = 0;
					if (dictionary.ContainsKey("ALTITUDE") && Operators.CompareString(dictionary["ALTITUDE"].ToString().ToUpper(), "SURFACE", false) != 0)
					{
						float? num4 = LuaUtility.QueryAltitude(dictionary);
						if (Information.IsNothing((object)num4))
						{
							short elevation = Terrain.GetElevation(num.Value, num2.Value, RequestIsFromGUI: false, ScenarioContext);
							num3 = ((elevation >= 0) ? elevation : 0);
						}
						else
						{
							num3 = (int)Math.Round(num4.Value);
						}
					}
					else
					{
						short elevation2 = Terrain.GetElevation(num.Value, num2.Value, RequestIsFromGUI: false, ScenarioContext);
						num3 = ((elevation2 >= 0) ? elevation2 : 0);
					}
					Warhead warhead = DBFunctions.GetWarhead(ScenarioContext, warheadID);
					Contact thePrimaryTarget = null;
					new Explosion(ref ScenarioContext, null, ref thePrimaryTarget, num2.Value, num.Value, num2.Value, num.Value, 0f, num3, theWeaponType, warhead.DP, warhead.DP, warhead.Type, warhead.ExplosivesType, null, null, null, null, null, warhead.ClusterBombDispersionAreaLength, warhead.ClusterBombDispersionAreaWidth, warhead.NumberOfWarheads);
					return true;
				}
				throw new LuaError("Missing 'Longitude'");
			}
			throw new LuaError("Missing 'Latitude'");
		}
		throw new LuaError("Missing mandatory variable 'WarheadID'");
	}

	public static string ScenEdit_AddFacility(string SideNameOrID, string FacName, int DBID, int FacilityOrientation, string CoordsFormat, string Lat, string Lon, Scenario ScenarioContext)
	{
		Side theSide = (from s in ScenarioContext.Sides_ReadOnly
			where string.Equals(s.ObjectID, SideNameOrID, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Name, SideNameOrID, StringComparison.OrdinalIgnoreCase)
			select (s)).First();
		double longitude = default(double);
		double latitude = default(double);
		if (Operators.CompareString(CoordsFormat, "DEC", false) != 0)
		{
			if (Operators.CompareString(CoordsFormat, "DEG", false) == 0)
			{
				longitude = LuaUtility.ParseLongitudeString(Lon);
				latitude = LuaUtility.ParseLatitudeString(Lat);
			}
		}
		else
		{
			Lon = Lon.Replace(",", ".");
			Lat = Lat.Replace(",", ".");
			longitude = XmlConvert.ToDouble(Lon);
			latitude = XmlConvert.ToDouble(Lat);
		}
		Facility facility = ScenarioContext.AddNewFacility(theSide, DBID, FacName, longitude, latitude);
		facility.CurrentHeading = FacilityOrientation;
		return facility.ObjectID;
	}

	public static object ScenEdit_HostUnitToParent(LuaTable table, Scenario ScenarioContext, ActiveUnit UnitX)
	{
		try
		{
			Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(table.GetEnumerator());
			ActiveUnit activeUnit = null;
			ActiveUnit activeUnit2 = null;
			ActiveUnit activeUnit3 = null;
			bool flag = false;
			bool flag2 = false;
			List<object> list = new List<object>();
			string text;
			if (dictionary.ContainsKey("HostedUnitNameOrID".ToUpper()))
			{
				text = Conversions.ToString(dictionary["HostedUnitNameOrID".ToUpper()]);
			}
			else if (!dictionary.ContainsKey("UnitName".ToUpper()))
			{
				if (!dictionary.ContainsKey("GUID".ToUpper()))
				{
					throw new LuaError("HostedUnitNameOrID/Unit has not been defined!");
				}
				text = Conversions.ToString(dictionary["GUID".ToUpper()]);
			}
			else
			{
				text = Conversions.ToString(dictionary["UnitName".ToUpper()]);
			}
			if (Operators.CompareString(text, "UnitX", false) != 0)
			{
				activeUnit = smethod_1(text, ScenarioContext);
			}
			else
			{
				if (UnitX == null)
				{
					throw new LuaError("Unit:UnitX has not been defined!");
				}
				activeUnit = UnitX;
			}
			string text2 = default(string);
			if (!dictionary.ContainsKey("SelectedHostNameOrID".ToUpper()))
			{
				if (dictionary.ContainsKey("HostBaseNameOrID".ToUpper()))
				{
					text2 = Conversions.ToString(dictionary["HostBaseNameOrID".ToUpper()]);
				}
			}
			else
			{
				text2 = Conversions.ToString(dictionary["SelectedHostNameOrID".ToUpper()]);
			}
			if (Operators.CompareString(text2, "UnitX", false) != 0)
			{
				activeUnit2 = smethod_1(text2, ScenarioContext);
			}
			else
			{
				if (Information.IsNothing((object)UnitX))
				{
					throw new LuaError("Host Base:UnitX has not been defined!");
				}
				activeUnit2 = UnitX;
			}
			string text3 = default(string);
			if (!dictionary.ContainsKey("SelectedBaseNameOrID".ToUpper()))
			{
				if (dictionary.ContainsKey("AssignedBaseNameOrID".ToUpper()))
				{
					text3 = Conversions.ToString(dictionary["AssignedBaseNameOrID".ToUpper()]);
				}
			}
			else
			{
				text3 = Conversions.ToString(dictionary["SelectedBaseNameOrID".ToUpper()]);
			}
			if (Operators.CompareString(text3, "UnitX", false) != 0)
			{
				activeUnit3 = smethod_1(text3, ScenarioContext);
			}
			else
			{
				if (Information.IsNothing((object)UnitX))
				{
					throw new LuaError("Assigned Base:UnitX has not been defined!");
				}
				activeUnit3 = UnitX;
			}
			if (Information.IsNothing((object)activeUnit))
			{
				throw new LuaError("Couldn't find the hosted unit " + text);
			}
			if (Information.IsNothing((object)activeUnit2) && Information.IsNothing((object)activeUnit3))
			{
				throw new LuaError("Couldn't find any host/assigned base ");
			}
			if (activeUnit.IsAircraft)
			{
				if (!Information.IsNothing((object)activeUnit2) && activeUnit2.AirOps != null)
				{
					if (activeUnit2.AirOps.CanHostThisAircraft((Aircraft)activeUnit) != AirOpsAttemptResult.Success)
					{
						flag = false;
					}
					else
					{
						((Aircraft)activeUnit).AirOps.HostAirFacility = null;
						activeUnit2.AirOps.AddThisAircraft((Aircraft)activeUnit, GameIsRunning: false);
						activeUnit.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
						flag = true;
					}
				}
				if (activeUnit3 != null && activeUnit.AirOps != null)
				{
					Aircraft_AirOps aircraft_AirOps = (Aircraft_AirOps)activeUnit.AirOps;
					if (!aircraft_AirOps.ThisUnitCanHostMe(activeUnit3, HumanFeedbackNeeded: false).ResponseBoolean)
					{
						flag2 = false;
					}
					else
					{
						aircraft_AirOps.set_AssignedHostUnit(PickNewAssignedHost: false, activeUnit3);
						flag2 = true;
					}
				}
			}
			else
			{
				if (activeUnit2 != null && activeUnit2.DockingOps != null)
				{
					ActiveUnit_DockingOps dockingOps = activeUnit2.DockingOps;
					ActiveUnit theBoat = activeUnit;
					DockFacility bestFacility = null;
					if (dockingOps.CanHostThisBoat(theBoat, ref bestFacility))
					{
						activeUnit.DockingOps.HostDockFacility = null;
						activeUnit2.DockingOps.AddThisBoat(activeUnit);
						activeUnit.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
						flag = true;
					}
					else
					{
						flag = false;
					}
				}
				if (activeUnit3 != null && activeUnit.DockingOps != null)
				{
					ActiveUnit_DockingOps dockingOps2 = activeUnit.DockingOps;
					if (!dockingOps2.ThisUnitCanHostMe(activeUnit3, HumanFeedBackNeeded: false).ResponseBoolean)
					{
						flag2 = false;
					}
					else
					{
						dockingOps2.set_AssignedHostUnit(PickNewAssignedHost: false, activeUnit3);
						flag2 = true;
					}
				}
			}
			if (activeUnit2 != null)
			{
				if (activeUnit3 != null)
				{
					list.Add(flag);
					list.Add(flag2);
					return list;
				}
				return flag;
			}
			return flag2;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at PM1", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static string ScenEdit_ExportScenarioToXML(Scenario theScen, LuaTable theTable)
	{
		MemoryStream scenarioClone = GameGeneral.GetScenarioClone(theScen);
		Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(theTable.GetEnumerator());
		if (dictionary.ContainsKey("FILENAME".ToUpper()))
		{
			if (!GameGeneral.PE_Lua_AllowIO)
			{
				throw new LuaError("I/O Operations are not allowed");
			}
			string path = Conversions.ToString(dictionary["FILENAME".ToUpper()]);
			try
			{
				FileStream fileStream = File.Create(Path.Combine(GameGeneral.TopLevelWritablePath, path));
				using (scenarioClone)
				{
					fileStream.Write(scenarioClone.ToArray(), 0, (int)scenarioClone.Position);
					fileStream.Close();
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at PM208", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("Error during File write: " + ex2.Message);
			}
		}
		using (scenarioClone)
		{
			return Misc.ConvertToString(scenarioClone);
		}
	}

	public static string ScenEdit_ExportTagsToXML(string parentNode, Scenario theScen)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		XmlDocument val = new XmlDocument();
		MemoryStream scenarioClone = GameGeneral.GetScenarioClone(theScen);
		string text;
		using (scenarioClone)
		{
			text = Misc.ConvertToString(scenarioClone);
		}
		val.LoadXml(text);
		string text2 = null;
		XmlNode val2 = ((XmlNode)val).SelectSingleNode("/Scenario");
		text2 = ((val2 == null) ? "ContentScenario" : "Scenario");
		val2 = ((XmlNode)val).SelectSingleNode("/" + text2 + "/" + parentNode);
		if (val2 == null)
		{
			return null;
		}
		return val2.InnerXml.ToString();
	}

	public static bool ScenEdit_ImportScenarioFromXML(ref Scenario theScenarioContext, LuaTable theTable)
	{
		Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(theTable.GetEnumerator());
		if (!dictionary.ContainsKey("XML".ToUpper()))
		{
			if (dictionary.ContainsKey("FILENAME".ToUpper()))
			{
				if (GameGeneral.PE_Lua_AllowIO)
				{
					string path = Conversions.ToString(dictionary["FILENAME".ToUpper()]);
					string ErrorFeedback = "";
					try
					{
						Scenario.ChangeCurrentScenarioOnClient(theScenarioContext = Scenario.smethod_0(Path.Combine(GameGeneral.TopLevelWritablePath, path), ref ErrorFeedback, null));
						return true;
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						ex2?.Data.Add("Error at PM2", "");
						GameGeneral.WriteExceptionsToLog(ex2);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						throw new LuaError("Error during File parse: " + ex2.Message);
					}
				}
				throw new LuaError("I/O Operations are not allowed");
			}
			throw new LuaError("XML string not present!");
		}
		string string_ = Conversions.ToString(dictionary["XML".ToUpper()]);
		try
		{
			string ErrorFeedback2 = null;
			Scenario.ChangeCurrentScenarioOnClient(theScenarioContext = Scenario.FromXmlText(string_, ref ErrorFeedback2, null));
			return true;
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			ex4?.Data.Add("Error at PM207", "");
			GameGeneral.WriteExceptionsToLog(ex4);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw new LuaError("Error during XML parse: " + ex4.Message);
		}
	}

	public static bool ScenEdit_AssignUnitToMission(string string_0, string MissionNameOrID, Scenario ScenarioContext, ActiveUnit UnitX, bool Escort, bool MissionPlanner)
	{
		try
		{
			ActiveUnit value = null;
			Mission theMission = null;
			Side side = null;
			bool isEscort = Escort;
			bool flag = MissionPlanner;
			if (Operators.CompareString(string_0, "UnitX", false) != 0)
			{
				ScenarioContext.ActiveUnits.TryGetValue(string_0, out value);
				if (value == null)
				{
					foreach (ActiveUnit value2 in ScenarioContext.ActiveUnits.Values)
					{
						if (value2 != null && string.Equals(value2.Name, string_0, StringComparison.OrdinalIgnoreCase))
						{
							value = value2;
							side = value.get_UnitSide(SetSideOnly: false);
							break;
						}
					}
				}
				else
				{
					side = value.get_UnitSide(SetSideOnly: false);
				}
			}
			else
			{
				if (UnitX == null)
				{
					throw new LuaError("UnitX has not been defined!");
				}
				value = UnitX;
				side = UnitX.get_UnitSide(SetSideOnly: false);
			}
			if (side == null)
			{
				throw new LuaError("UnitX was not found in the scenario unit list!");
			}
			foreach (Mission mission in side.Missions)
			{
				if (string.Equals(mission.Name, MissionNameOrID, StringComparison.OrdinalIgnoreCase) || string.Equals(mission.ObjectID, MissionNameOrID, StringComparison.OrdinalIgnoreCase))
				{
					theMission = mission;
					break;
				}
			}
			if (value != null)
			{
				if (!string.IsNullOrEmpty(MissionNameOrID) && !string.Equals(MissionNameOrID, "NONE", StringComparison.OrdinalIgnoreCase))
				{
					if (theMission != null)
					{
						if (!(isEscort & value.IsGroup))
						{
							value.AssignToMission(ref value.ParentScen, ref value, ref theMission, ref isEscort);
						}
						else
						{
							value.AssignToMission(ref value.ParentScen, ref value, ref theMission, ref isEscort);
							foreach (ActiveUnit value3 in ((Group)value).Units.Values)
							{
								ActiveUnit theAU = value3;
								value.AssignToMission(ref value.ParentScen, ref theAU, ref theMission, ref isEscort);
							}
						}
						if (flag && value.IsAircraft && value.IsOperating())
						{
							List<ActiveUnit> theSelectedUnits = new List<ActiveUnit>();
							theSelectedUnits.Add(value);
							Command_Core.MissionPlanner.GenerateFlightPlan_Strike_AirborneAircraft(value.ParentScen, theMission, ref theSelectedUnits, isManual: false);
						}
						theMission.TimeSincePlayerNotification = 0;
						return true;
					}
					throw new LuaError("Couldn't find the mission " + MissionNameOrID);
				}
				ActiveUnit activeUnit = value;
				Mission.MissionAssignmentAttemptResult Result = Mission.MissionAssignmentAttemptResult.None;
				activeUnit.Set_AssignedMissionOrPackage(null, SetMissionOnly: false, IgnoreCommsState: false, ref Result);
				return true;
			}
			throw new LuaError("Couldn't find the unit " + string_0);
		}
		catch (LuaError projectError)
		{
			ProjectData.SetProjectError((Exception)projectError);
			throw;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at PM3", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static bool ScenEdit_SetLoadout(LuaTable table, Scenario ScenarioContext, ActiveUnit UnitX)
	{
		try
		{
			Dictionary<string, object> dict = LuaUtility.ToDictUpper(table.GetEnumerator());
			Aircraft theAircraft = null;
			LuaUtility.ParseUnitDict(ref dict);
			if (!dict.ContainsKey("UnitName".ToUpper()))
			{
				throw new LuaError("UnitName has not been defined!");
			}
			string text = Conversions.ToString(dict["UnitName".ToUpper()]);
			if (Operators.CompareString(text, "UnitX", false) != 0)
			{
				if (ScenarioContext.ActiveUnits.ContainsKey(text))
				{
					theAircraft = (Aircraft)ScenarioContext.ActiveUnits[text];
				}
				if (theAircraft == null)
				{
					foreach (ActiveUnit value in ScenarioContext.ActiveUnits.Values)
					{
						if (value != null && string.Equals(value.Name, text, StringComparison.OrdinalIgnoreCase))
						{
							theAircraft = (Aircraft)value;
							break;
						}
					}
				}
			}
			else
			{
				if (Information.IsNothing((object)UnitX))
				{
					throw new LuaError("UnitX has not been defined!");
				}
				if (!UnitX.IsAircraft)
				{
					throw new LuaError("UnitX is not an aircraft!");
				}
				theAircraft = (Aircraft)UnitX;
			}
			if (theAircraft != null)
			{
				int num = 0;
				if (dict.ContainsKey("LOADOUTID"))
				{
					num = Conversions.ToInteger(dict["LOADOUTID"]);
				}
				Loadout loadout;
				if (num == 0)
				{
					num = theAircraft.Loadout.DBID;
					loadout = theAircraft.Loadout;
				}
				else
				{
					try
					{
						loadout = DBFunctions.GetLoadout(ref ScenarioContext, num, ExcludeOptionalWeapons: true, GetPayloadWeight: true);
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						ex2?.Data.Add("Error at PM4", "");
						GameGeneral.WriteExceptionsToLog(ex2);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						throw new LuaError(ex2.Message);
					}
				}
				if (loadout.DBID != num && !(theAircraft.IsParked() | (theAircraft.AirOps.Condition == Aircraft_AirOps._AirOpsCondition.Readying)))
				{
					throw new LuaError("Aircraft is not parked, cannot change loadout!");
				}
				if (!(theAircraft.IsParked() | (theAircraft.AirOps.Condition == Aircraft_AirOps._AirOpsCondition.Readying)))
				{
					int num2 = 0;
					bool flag = false;
					int num3 = 0;
					string text2 = null;
					if (dict.ContainsKey("WPN_DBID"))
					{
						num3 = Conversions.ToInteger(dict["WPN_DBID"]);
					}
					if (dict.ContainsKey("WPN_GUID"))
					{
						text2 = Conversions.ToString(dict["WPN_GUID"]);
					}
					if (text2 == null && num3 == 0)
					{
						throw new LuaError("No weapon defined.");
					}
					if (dict.ContainsKey("NUMBER"))
					{
						num2 = Math.Abs(Conversions.ToInteger(dict["NUMBER"]));
					}
					if (dict.ContainsKey("REMOVE"))
					{
						flag = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(dict["REMOVE"])).Value;
					}
					WeaponRec[] weapons = loadout.Weapons;
					int num4 = 0;
					int result;
					while (true)
					{
						if (num4 < weapons.Length)
						{
							WeaponRec weaponRec = weapons[num4];
							if (num2 > 0)
							{
								if (text2 == null || string.Equals(weaponRec.ObjectID, text2, StringComparison.OrdinalIgnoreCase))
								{
									if (num3 == 0)
									{
										num3 = weaponRec.int_3;
									}
									if (num3 == weaponRec.int_3)
									{
										if (flag)
										{
											if (weaponRec.CurrentLoad > 0)
											{
												int num5 = Math.Min(num2, weaponRec.CurrentLoad);
												weaponRec.CurrentLoad -= num5;
												num2 -= num5;
											}
										}
										else if (weaponRec.CurrentLoad < weaponRec.MaxLoad)
										{
											int num6 = Math.Min(num2, weaponRec.MaxLoad - weaponRec.CurrentLoad);
											weaponRec.CurrentLoad += num6;
											num2 -= num6;
										}
									}
								}
								num4 = checked(num4 + 1);
								continue;
							}
							result = 1;
							break;
						}
						result = 1;
						break;
					}
					return (byte)result != 0;
				}
				int num7 = loadout.ReadyTime;
				int num8;
				if (!dict.ContainsKey("TIMETOREADY_MINUTES"))
				{
					num8 = 0;
				}
				else
				{
					num7 = Conversions.ToInteger(dict["TIMETOREADY_MINUTES"]);
					num8 = 0;
				}
				bool flag2 = (byte)num8 != 0;
				if (dict.ContainsKey("IGNOREMAGAZINES"))
				{
					try
					{
						flag2 = Conversions.ToBoolean(dict["IGNOREMAGAZINES"]);
					}
					catch (Exception ex3)
					{
						ProjectData.SetProjectError(ex3);
						Exception ex4 = ex3;
						ex4?.Data.Add("Error at PM5", "");
						GameGeneral.WriteExceptionsToLog(ex4);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						throw new LuaError("Unable to parse IgnoreMagazines to true/false!");
					}
				}
				bool excludeOptionalWeapons = false;
				if (dict.ContainsKey("EXCLUDEOPTIONALWEAPONS"))
				{
					try
					{
						excludeOptionalWeapons = Conversions.ToBoolean(dict["EXCLUDEOPTIONALWEAPONS"]);
					}
					catch (Exception ex5)
					{
						ProjectData.SetProjectError(ex5);
						Exception ex6 = ex5;
						ex6?.Data.Add("Error at PM6", "");
						GameGeneral.WriteExceptionsToLog(ex6);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						throw new LuaError("Unable to parse ExcludeOptionalWeapons to true/false!");
					}
				}
				if (ScenarioContext.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.UnlimitedBaseMagazines))
				{
					flag2 = true;
				}
				if (!flag2)
				{
					theAircraft.AirOps.UnloadStores();
				}
				ActiveUnit currentHostUnit = theAircraft.AirOps.CurrentHostUnit;
				currentHostUnit.AirOps.OutfitAC(ref theAircraft, num, 0, ReadyImmediately: false, excludeOptionalWeapons, !flag2, ManualAction: false, PlayerFeedback: true);
				theAircraft.AirOps.ConditionTimer = num7 * 60;
				currentHostUnit.AirOps.RefuelAC_Simple(ref theAircraft);
				currentHostUnit.AirOps.RepairAC(ref theAircraft);
				int result2;
				if (num == 4 && !theAircraft.IsParked())
				{
					theAircraft.AirOps.Condition = Aircraft_AirOps._AirOpsCondition.Parked;
					result2 = 1;
				}
				else
				{
					result2 = 1;
				}
				return (byte)result2 != 0;
			}
			throw new LuaError("Aircraft has not been found!");
		}
		catch (Exception ex7)
		{
			ProjectData.SetProjectError(ex7);
			Exception ex8 = ex7;
			if (Debugger.IsAttached)
			{
				ex8?.Data.Add("Error at PM7", "");
				GameGeneral.WriteExceptionsToLog(ex8);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				Debugger.Break();
			}
			throw;
		}
	}

	public static LuaWrapper_Loadout ScenEdit_GetLoadout(LuaTable table, Scenario ScenarioContext, ActiveUnit UnitX)
	{
		try
		{
			Dictionary<string, object> dict = LuaUtility.ToDictUpper(table.GetEnumerator());
			Aircraft aircraft = null;
			LuaUtility.ParseUnitDict(ref dict);
			if (!dict.ContainsKey("UnitName".ToUpper()))
			{
				throw new LuaError("UnitName has not been defined!");
			}
			string text = Conversions.ToString(dict["UnitName".ToUpper()]);
			if (Operators.CompareString(text, "UnitX", false) != 0)
			{
				foreach (ActiveUnit activeUnits_ in ScenarioContext.ActiveUnits_List)
				{
					if (!Information.IsNothing((object)activeUnits_) && (object)activeUnits_.GetType() == typeof(Aircraft) && (string.Equals(activeUnits_.Name, text, StringComparison.OrdinalIgnoreCase) || string.Equals(activeUnits_.ObjectID, text, StringComparison.OrdinalIgnoreCase)))
					{
						aircraft = (Aircraft)activeUnits_;
						break;
					}
				}
			}
			else
			{
				if (Information.IsNothing((object)UnitX))
				{
					throw new LuaError("UnitX has not been defined!");
				}
				if (!UnitX.IsAircraft)
				{
					throw new LuaError("UnitX is not an aircraft!");
				}
				aircraft = (Aircraft)UnitX;
			}
			if (Information.IsNothing((object)aircraft))
			{
				throw new LuaError("Aircraft has not been found!");
			}
			int num = 0;
			if (dict.ContainsKey("LOADOUTID"))
			{
				num = Conversions.ToInteger(dict["LOADOUTID"]);
			}
			Loadout a;
			try
			{
				a = ((num == 0) ? aircraft.Loadout : DBFunctions.GetLoadout(ref ScenarioContext, num, ExcludeOptionalWeapons: true, GetPayloadWeight: true));
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at PM8", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError(ex2.Message);
			}
			return new LuaWrapper_Loadout(a, ScenarioContext);
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			if (Debugger.IsAttached)
			{
				ex4?.Data.Add("Error at PM9", "");
				GameGeneral.WriteExceptionsToLog(ex4);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
			}
			throw;
		}
	}

	public static bool ScenEdit_SetWeather(int AvgTemp, int RainfallRate, float FractionUnderRain, int SeaState, Scenario ScenarioContext)
	{
		try
		{
			if (RainfallRate >= 0 && RainfallRate <= 50)
			{
				if (!(FractionUnderRain < 0f) && FractionUnderRain <= 1f)
				{
					if (SeaState < 0 || SeaState > 9)
					{
						throw new LuaError("Invalid SeaState (0 - 9)");
					}
					ScenarioContext.GlobalWeather.AverageTemp = AvgTemp;
					ScenarioContext.GlobalWeather.RainfallRate = RainfallRate;
					ScenarioContext.GlobalWeather.FractionUnderRain = FractionUnderRain;
					ScenarioContext.GlobalWeather.SeaState = SeaState;
					return true;
				}
				throw new LuaError("Invalid fraction of cloudcover (0.0 - 1.0)");
			}
			throw new LuaError("Invalid rainfall (0 - 50)");
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at PM10", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static LuaTable ScenEdit_GetWeather(Scenario ScenarioContext)
	{
		LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
		try
		{
			luaTable["temp"] = ScenarioContext.GlobalWeather.AverageTemp;
			luaTable["rainfall"] = ScenarioContext.GlobalWeather.RainfallRate;
			luaTable["undercloud"] = ScenarioContext.GlobalWeather.FractionUnderRain;
			luaTable["seastate"] = ScenarioContext.GlobalWeather.SeaState;
			return luaTable;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at PM11", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static LuaTable ScenEdit_FillMagsForLoadout(LuaTable table, Scenario ScenarioContext)
	{
		try
		{
			Dictionary<string, object> dict = LuaUtility.ToDictUpper(table.GetEnumerator());
			ActiveUnit activeUnit = null;
			LuaSandBox.Singleton().CreateTable();
			LuaUtility.ParseUnitDict(ref dict);
			string text = LuaUtility.QueryUnit(dict, ScenarioContext);
			if (text.Length != 0)
			{
				throw new LuaError(text);
			}
			if (dict.ContainsKey("GUID"))
			{
				string key;
				try
				{
					key = Conversions.ToString(dict["GUID"]);
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error at PM16", "");
					GameGeneral.WriteExceptionsToLog(ex2);
					throw new LuaError("guid must be a string");
				}
				try
				{
					activeUnit = ScenarioContext.ActiveUnits[key];
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
			}
			if (activeUnit != null)
			{
				if (dict.ContainsKey("LOADOUTID"))
				{
					int num = Conversions.ToInteger(dict["LOADOUTID"]);
					Loadout loadout;
					try
					{
						loadout = DBFunctions.GetLoadout(ref ScenarioContext, num, ExcludeOptionalWeapons: false, GetPayloadWeight: true);
					}
					catch (Exception ex3)
					{
						ProjectData.SetProjectError(ex3);
						Exception ex4 = ex3;
						ex4?.Data.Add("Error at PM17", "");
						GameGeneral.WriteExceptionsToLog(ex4);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						throw new LuaError("Must provide a valid loadout ID");
					}
					if (dict.ContainsKey("QUANTITY") && Conversions.ToInteger(dict["QUANTITY"]) > 0)
					{
						int num2 = Conversions.ToInteger(dict["QUANTITY"]);
						LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
						luaTable[1] = "Attempting to add " + Conversions.ToString(num2) + "x packs of loadout: #" + Conversions.ToString(num) + " - " + loadout.Name + " to the magazines of unit: " + activeUnit.Name;
						int num3 = 1;
						WeaponRec[] weapons = loadout.Weapons;
						foreach (WeaponRec weaponRec in weapons)
						{
							weaponRec.MaxLoad *= num2;
							weaponRec.CurrentLoad *= num2;
							int num4 = 0;
							int num5 = 0;
							if (weaponRec.CurrentLoad <= 0)
							{
								continue;
							}
							int currentLoad = weaponRec.CurrentLoad;
							for (int j = 1; j <= currentLoad; j++)
							{
								if (Operators.CompareString(activeUnit.Weaponry.AddWeaponToMagazines(weaponRec.int_3, PriorityToAviationMags: true, AllowAddingNewWeaponRec: true), "OK", false) == 0)
								{
									num4++;
								}
								else
								{
									num5++;
								}
							}
							if (num4 > 0)
							{
								num3++;
								luaTable[num3] = "Successfully added " + Conversions.ToString(num4) + "x stores of type: " + weaponRec.get_ReferenceWeapon(ScenarioContext).Name;
							}
							if (num5 > 0)
							{
								num3++;
								luaTable[num3] = "Failed to add " + Conversions.ToString(num5) + "x stores of type: " + weaponRec.get_ReferenceWeapon(ScenarioContext).Name;
							}
						}
						return luaTable;
					}
					throw new LuaError("Must provide a valid (>0) quantity number");
				}
				throw new LuaError("Must provide a valid loadout ID");
			}
			throw new LuaError("Need to define a Name or Guid to identify a unit. Preferably a Guid or Side & Name.");
		}
		catch (Exception ex5)
		{
			ProjectData.SetProjectError(ex5);
			Exception ex6 = ex5;
			ex6?.Data.Add("Error at PM18", "");
			GameGeneral.WriteExceptionsToLog(ex6);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static LuaTable ScenEdit_SetUnitDamage(LuaTable table, Scenario ScenarioContext)
	{
		try
		{
			Dictionary<string, object> dict = LuaUtility.ToDictUpper(table.GetEnumerator());
			ActiveUnit activeUnit = null;
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			LuaUtility.ParseUnitDict(ref dict);
			string text = LuaUtility.QueryUnit(dict, ScenarioContext);
			if (text.Length == 0)
			{
				if (dict.ContainsKey("GUID"))
				{
					string key;
					try
					{
						key = Conversions.ToString(dict["GUID"]);
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						ex2?.Data.Add("Error at PM19", "");
						GameGeneral.WriteExceptionsToLog(ex2);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						throw new LuaError("guid must be a string");
					}
					activeUnit = ScenarioContext.ActiveUnits[key];
				}
				if (activeUnit != null)
				{
					ActiveUnit_Damage damage = activeUnit.Damage;
					ActiveUnit_Damage.FireIntensityLevel result = ActiveUnit_Damage.FireIntensityLevel.NoFire;
					ActiveUnit_Damage.FloodingIntensityLevel result2 = ActiveUnit_Damage.FloodingIntensityLevel.NoFlooding;
					float num = 0f;
					if (dict.ContainsKey("FIRES"))
					{
						try
						{
							if (Enum.TryParse<ActiveUnit_Damage.FireIntensityLevel>(Conversions.ToString(dict["FIRES"]), ignoreCase: true, out result) && Enum.IsDefined(typeof(ActiveUnit_Damage.FireIntensityLevel), result))
							{
								damage.FireIntensity = result;
							}
						}
						catch (Exception ex3)
						{
							ProjectData.SetProjectError(ex3);
							Exception ex4 = ex3;
							ex4?.Data.Add("Error at PM20", "");
							GameGeneral.WriteExceptionsToLog(ex4);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
					}
					if (dict.ContainsKey("FLOOD"))
					{
						try
						{
							if (Enum.TryParse<ActiveUnit_Damage.FloodingIntensityLevel>(Conversions.ToString(dict["FLOOD"]), ignoreCase: true, out result2) && Enum.IsDefined(typeof(ActiveUnit_Damage.FloodingIntensityLevel), result2))
							{
								damage.FloodIntensity = result2;
							}
						}
						catch (Exception ex5)
						{
							ProjectData.SetProjectError(ex5);
							Exception ex6 = ex5;
							ex6?.Data.Add("Error at PM21", "");
							GameGeneral.WriteExceptionsToLog(ex6);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
					}
					if (dict.ContainsKey("DP"))
					{
						try
						{
							num = Conversions.ToSingle(dict["DP"]);
						}
						catch (Exception ex7)
						{
							ProjectData.SetProjectError(ex7);
							Exception ex8 = ex7;
							ex8?.Data.Add("Error at PM22", "");
							GameGeneral.WriteExceptionsToLog(ex8);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
						activeUnit.get_DamagePts(ScenEditAction: false, (Weapon)null) -= num;
					}
					if (dict.ContainsKey("COMPONENTS"))
					{
						List<object> list = LuaUtility.ToArray(((LuaTable)dict["COMPONENTS"]).GetEnumerator());
						foreach (object item in list)
						{
							object objectValue = RuntimeHelpers.GetObjectValue(item);
							if (objectValue is LuaTable)
							{
								Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(((LuaTable)objectValue).GetEnumerator());
								if (dictionary.Count <= 0)
								{
									continue;
								}
								PlatformComponent platformComponent = null;
								int num2 = 0;
								bool flag = false;
								bool flag2 = false;
								string text2 = Conversions.ToString(dictionary["1"]);
								PlatformComponent._DamageSeverityFactor result3 = PlatformComponent._DamageSeverityFactor.Light;
								if (Operators.CompareString(Conversions.ToString(dictionary["2"]).ToLower(), "none", false) != 0)
								{
									if (Operators.CompareString(Conversions.ToString(dictionary["2"]).ToLower(), "destroyed", false) != 0)
									{
										if (!(Enum.TryParse<PlatformComponent._DamageSeverityFactor>(Conversions.ToString(dictionary["2"]), ignoreCase: true, out result3) & Enum.IsDefined(typeof(PlatformComponent._DamageSeverityFactor), result3)))
										{
											throw new LuaError("Error in damage level for  '" + text2 + "' in ScenEdit_SetUnitDamage.");
										}
										if (result3 > PlatformComponent._DamageSeverityFactor.Heavy)
										{
											result3 = PlatformComponent._DamageSeverityFactor.Heavy;
										}
										else if (result3 < PlatformComponent._DamageSeverityFactor.Light)
										{
											result3 = PlatformComponent._DamageSeverityFactor.Light;
										}
									}
									else
									{
										flag2 = true;
										result3 = PlatformComponent._DamageSeverityFactor.Heavy;
									}
								}
								else
								{
									flag = true;
								}
								string text3 = null;
								num2 = activeUnit.Components().Count;
								int index = GameGeneral.GlobalRNG.Next(0, num2);
								if (Operators.CompareString(text2.ToUpperInvariant(), "TYPE", false) == 0)
								{
									if (!dictionary.ContainsKey("TYPE"))
									{
										PlatformComponent._DamageSeverityFactor damageSeverity = activeUnit.Components()[index].DamageSeverity;
										activeUnit.Components()[index].Damage(result3);
										if (result3 == PlatformComponent._DamageSeverityFactor.Light && (flag || damageSeverity != PlatformComponent._DamageSeverityFactor.Light))
										{
											activeUnit.Components()[index].Repair();
										}
										continue;
									}
									text3 = Conversions.ToString(dictionary["TYPE"]);
									if (num2 <= 0)
									{
										continue;
									}
									PlatformComponent[] array = new PlatformComponent[num2 + 1];
									int num3 = 0;
									foreach (PlatformComponent item2 in activeUnit.Components())
									{
										platformComponent = item2;
										if (Operators.CompareString(platformComponent.GetType().Name.ToUpperInvariant(), text3.ToUpperInvariant(), false) == 0)
										{
											array[num3] = platformComponent;
											num3++;
										}
									}
									if (num3 <= 0)
									{
										continue;
									}
									index = GameGeneral.GlobalRNG.Next(0, num3);
									_ = array[index].DamageSeverity;
									if (!flag)
									{
										if (flag2)
										{
											array[index].Damage(PlatformComponent._DamageSeverityFactor.Heavy);
											array[index].Destroy(activeUnit.get_UnitSide(SetSideOnly: false), ScenEditAction: true, IsAimpointFacility: false);
										}
										else
										{
											array[index].Damage(result3);
										}
									}
									else
									{
										array[index].Damage(PlatformComponent._DamageSeverityFactor.Light);
										array[index].Repair();
									}
									LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
									luaTable2["guid"] = array[index].ObjectID;
									luaTable2["dbid"] = array[index].DBID;
									luaTable2["name"] = array[index].Name;
									luaTable2["type"] = array[index].GetType().Name;
									luaTable2["status"] = array[index].Status.ToString();
									if (platformComponent.Status != PlatformComponent._ComponentStatus.Operational)
									{
										luaTable2["damage"] = array[index].DamageSeverity.ToString();
									}
									luaTable[luaTable.Keys.Count + 1] = luaTable2;
									continue;
								}
								LuaTable luaTable3 = LuaSandBox.Singleton().CreateTable();
								bool flag3 = false;
								switch (activeUnit.GetType().ToString())
								{
								case "Command_Core.Ship":
								{
									Ship ship = (Ship)activeUnit;
									if (Operators.CompareString(text2.ToUpperInvariant(), "RUDDER", false) != 0)
									{
										if (Operators.CompareString(text2.ToUpperInvariant(), "CARGO", false) == 0 || Operators.CompareString(text2.ToUpperInvariant(), "PRESSUREHULL", false) == 0 || Operators.CompareString(text2.ToUpperInvariant(), "CIC", false) != 0)
										{
											break;
										}
										if (!flag)
										{
											if (!flag2)
											{
												ship.CIC.Damage(result3);
											}
											else
											{
												ship.CIC.Damage(PlatformComponent._DamageSeverityFactor.Heavy);
												ship.CIC.Destroy(activeUnit.get_UnitSide(SetSideOnly: false), ScenEditAction: true, IsAimpointFacility: false);
											}
										}
										else
										{
											ship.CIC.Damage(PlatformComponent._DamageSeverityFactor.Light);
											ship.CIC.Repair();
										}
										luaTable3["name"] = text2.ToUpperInvariant();
										luaTable3["status"] = ((Ship)activeUnit).CIC.Status.ToString();
										if (((Ship)activeUnit).CIC.Status != PlatformComponent._ComponentStatus.Operational)
										{
											luaTable3["damage"] = ((Ship)activeUnit).CIC.DamageSeverity.ToString();
										}
										luaTable[luaTable.Keys.Count + 1] = luaTable3;
										flag3 = true;
										break;
									}
									if (!flag)
									{
										if (flag2)
										{
											ship.Rudder.Damage(PlatformComponent._DamageSeverityFactor.Heavy);
											ship.Rudder.Destroy(activeUnit.get_UnitSide(SetSideOnly: false), ScenEditAction: true, IsAimpointFacility: false);
										}
										else
										{
											ship.Rudder.Damage(result3);
										}
									}
									else
									{
										ship.Rudder.Damage(PlatformComponent._DamageSeverityFactor.Light);
										ship.Rudder.Repair();
									}
									luaTable3["name"] = text2.ToUpperInvariant();
									luaTable3["status"] = ((Ship)activeUnit).Rudder.Status.ToString();
									if (((Ship)activeUnit).Rudder.Status != PlatformComponent._ComponentStatus.Operational)
									{
										luaTable3["damage"] = ((Ship)activeUnit).Rudder.DamageSeverity.ToString();
									}
									luaTable[luaTable.Keys.Count + 1] = luaTable3;
									flag3 = true;
									break;
								}
								case "Command_Core.Submarine":
								{
									Submarine submarine = (Submarine)activeUnit;
									if (Operators.CompareString(text2.ToUpperInvariant(), "RUDDER", false) != 0)
									{
										if (Operators.CompareString(text2.ToUpperInvariant(), "CARGO", false) != 0)
										{
											if (Operators.CompareString(text2.ToUpperInvariant(), "PRESSUREHULL", false) == 0)
											{
												if (flag)
												{
													submarine.PressureHull.Damage(PlatformComponent._DamageSeverityFactor.Light);
													submarine.PressureHull.Repair();
												}
												else if (!flag2)
												{
													submarine.PressureHull.Damage(result3);
												}
												else
												{
													submarine.PressureHull.Damage(PlatformComponent._DamageSeverityFactor.Heavy);
													submarine.PressureHull.Destroy(activeUnit.get_UnitSide(SetSideOnly: false), ScenEditAction: true, IsAimpointFacility: false);
												}
												luaTable3["name"] = text2.ToUpperInvariant();
												luaTable3["status"] = ((Submarine)activeUnit).PressureHull.Status.ToString();
												if (((Submarine)activeUnit).PressureHull.Status != PlatformComponent._ComponentStatus.Operational)
												{
													luaTable3["damage"] = ((Submarine)activeUnit).PressureHull.DamageSeverity.ToString();
												}
												luaTable[luaTable.Keys.Count + 1] = luaTable3;
												flag3 = true;
											}
											else if (Operators.CompareString(text2.ToUpperInvariant(), "CIC", false) == 0)
											{
												if (flag)
												{
													submarine.CIC.Damage(PlatformComponent._DamageSeverityFactor.Light);
													submarine.CIC.Repair();
												}
												else if (flag2)
												{
													submarine.CIC.Damage(PlatformComponent._DamageSeverityFactor.Heavy);
													submarine.CIC.Destroy(activeUnit.get_UnitSide(SetSideOnly: false), ScenEditAction: true, IsAimpointFacility: false);
												}
												else
												{
													submarine.CIC.Damage(result3);
												}
												luaTable3["name"] = text2.ToUpperInvariant();
												luaTable3["status"] = ((Submarine)activeUnit).CIC.Status.ToString();
												if (((Submarine)activeUnit).CIC.Status != PlatformComponent._ComponentStatus.Operational)
												{
													luaTable3["damage"] = ((Submarine)activeUnit).CIC.DamageSeverity.ToString();
												}
												luaTable[luaTable.Keys.Count + 1] = luaTable3;
												flag3 = true;
											}
										}
										else
										{
											if (flag)
											{
												submarine.Cargo.Damage(PlatformComponent._DamageSeverityFactor.Light);
												submarine.Cargo.Repair();
											}
											else if (flag2)
											{
												submarine.Cargo.Damage(PlatformComponent._DamageSeverityFactor.Heavy);
												submarine.Cargo.Destroy(activeUnit.get_UnitSide(SetSideOnly: false), ScenEditAction: true, IsAimpointFacility: false);
											}
											else
											{
												submarine.Cargo.Damage(result3);
											}
											luaTable3["name"] = text2.ToUpperInvariant();
											luaTable3["status"] = ((Submarine)activeUnit).Cargo.Status.ToString();
											if (((Submarine)activeUnit).Cargo.Status != PlatformComponent._ComponentStatus.Operational)
											{
												luaTable3["damage"] = ((Submarine)activeUnit).Cargo.DamageSeverity.ToString();
											}
											luaTable[luaTable.Keys.Count + 1] = luaTable3;
											flag3 = true;
										}
										break;
									}
									if (!flag)
									{
										if (!flag2)
										{
											submarine.Rudder.Damage(result3);
										}
										else
										{
											submarine.Rudder.Damage(PlatformComponent._DamageSeverityFactor.Heavy);
											submarine.Rudder.Destroy(activeUnit.get_UnitSide(SetSideOnly: false), ScenEditAction: true, IsAimpointFacility: false);
										}
									}
									else
									{
										submarine.Rudder.Damage(PlatformComponent._DamageSeverityFactor.Light);
										submarine.Rudder.Repair();
									}
									luaTable3["name"] = text2.ToUpperInvariant();
									luaTable3["status"] = ((Submarine)activeUnit).Rudder.Status.ToString();
									if (((Submarine)activeUnit).Rudder.Status != PlatformComponent._ComponentStatus.Operational)
									{
										luaTable3["damage"] = ((Submarine)activeUnit).Rudder.DamageSeverity.ToString();
									}
									luaTable[luaTable.Keys.Count + 1] = luaTable3;
									flag3 = true;
									break;
								}
								case "Command_Core.Facility":
								{
									Facility facility = (Facility)activeUnit;
									if (Operators.CompareString(text2.ToUpperInvariant(), "RUDDER", false) == 0)
									{
										break;
									}
									if (Operators.CompareString(text2.ToUpperInvariant(), "CARGO", false) == 0)
									{
										if (flag)
										{
											facility.Cargo.Damage(PlatformComponent._DamageSeverityFactor.Light);
											facility.Cargo.Repair();
										}
										else if (!flag2)
										{
											facility.Cargo.Damage(result3);
										}
										else
										{
											facility.Cargo.Damage(PlatformComponent._DamageSeverityFactor.Heavy);
											facility.Cargo.Destroy(activeUnit.get_UnitSide(SetSideOnly: false), ScenEditAction: true, IsAimpointFacility: false);
										}
										luaTable3["name"] = text2.ToUpperInvariant();
										luaTable3["status"] = ((Facility)activeUnit).Cargo.Status.ToString();
										if (((Facility)activeUnit).Cargo.Status != PlatformComponent._ComponentStatus.Operational)
										{
											luaTable3["damage"] = ((Facility)activeUnit).Cargo.DamageSeverity.ToString();
										}
										luaTable[luaTable.Keys.Count + 1] = luaTable3;
										flag3 = true;
									}
									else
									{
										if (Operators.CompareString(text2.ToUpperInvariant(), "PRESSUREHULL", false) == 0 || Operators.CompareString(text2.ToUpperInvariant(), "CIC", false) != 0)
										{
											break;
										}
										if (!flag)
										{
											if (!flag2)
											{
												facility.CIC.Damage(result3);
											}
											else
											{
												facility.CIC.Damage(PlatformComponent._DamageSeverityFactor.Heavy);
												facility.CIC.Destroy(activeUnit.get_UnitSide(SetSideOnly: false), ScenEditAction: true, IsAimpointFacility: false);
											}
										}
										else
										{
											facility.CIC.Damage(PlatformComponent._DamageSeverityFactor.Light);
											facility.CIC.Repair();
										}
										luaTable3["name"] = text2.ToUpperInvariant();
										luaTable3["status"] = ((Facility)activeUnit).CIC.Status.ToString();
										if (((Facility)activeUnit).CIC.Status != PlatformComponent._ComponentStatus.Operational)
										{
											luaTable3["damage"] = ((Facility)activeUnit).CIC.DamageSeverity.ToString();
										}
										luaTable[luaTable.Keys.Count + 1] = luaTable3;
										flag3 = true;
									}
									break;
								}
								}
								if (!(num2 > 0 && !flag3))
								{
									continue;
								}
								foreach (PlatformComponent item3 in activeUnit.Components())
								{
									if (!string.Equals(item3.Name, text2, StringComparison.OrdinalIgnoreCase) && !string.Equals(item3.ObjectID, text2, StringComparison.OrdinalIgnoreCase))
									{
										continue;
									}
									_ = item3.DamageSeverity;
									if (!flag)
									{
										if (flag2)
										{
											item3.Damage(PlatformComponent._DamageSeverityFactor.Heavy);
											item3.Destroy(activeUnit.get_UnitSide(SetSideOnly: false), ScenEditAction: true, IsAimpointFacility: false);
										}
										else
										{
											item3.Damage(result3);
										}
									}
									else
									{
										item3.Damage(PlatformComponent._DamageSeverityFactor.Light);
										item3.Repair();
									}
									LuaTable luaTable4 = LuaSandBox.Singleton().CreateTable();
									luaTable4["guid"] = item3.ObjectID;
									luaTable4["dbid"] = item3.DBID;
									luaTable4["name"] = item3.Name;
									luaTable4["type"] = item3.GetType().Name;
									luaTable4["status"] = item3.Status.ToString();
									if (item3.Status != PlatformComponent._ComponentStatus.Operational)
									{
										luaTable4["damage"] = item3.DamageSeverity.ToString();
									}
									luaTable[luaTable.Keys.Count + 1] = luaTable4;
									break;
								}
								continue;
							}
							throw new LuaError("Error at " + LuaUtility.LuaInterpret(RuntimeHelpers.GetObjectValue(objectValue)) + " in ScenEdit_SetUnitDamage.");
						}
					}
					return luaTable;
				}
				return null;
			}
			throw new LuaError(text);
		}
		catch (Exception ex9)
		{
			ProjectData.SetProjectError(ex9);
			Exception ex10 = ex9;
			ex10?.Data.Add("Error at PM23", "");
			GameGeneral.WriteExceptionsToLog(ex10);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static bool ScenEdit_SetExportOutputRate(string exportType, string rate)
	{
		if (string.Compare(exportType, "UNITPOSITIONS", ignoreCase: true) == 0)
		{
			IEventExporter.EventExportOutputRate eventExportOutputRate = Exporter_General.ParseOutputRateString(rate);
			if (eventExportOutputRate == IEventExporter.EventExportOutputRate.Unknown)
			{
				throw new LuaError("Unrecognized event export output rate. Valid values are: 'MatchSimSpeed', 'Continuous', '1Second', '2Seconds', '5Seconds', '15Seconds', '30Seconds', '1Minute', '5Minutes', '15Minutes', '30Minutes', '1Hour', '6Hours', '12Hours', or '24Hours'");
			}
			Exporter_General.SetEventOutputRate(IEventExporter.ExportedEventType.UnitPositions, eventExportOutputRate);
			return true;
		}
		throw new LuaError("Only the 'UnitPositions' export type is currently supported.");
	}

	public static bool ScenEdit_SetEMCON(string EMCONSubjectType, string string_0, string EMCONSettings, Scenario ScenarioContext)
	{
		Doctrine doctrine = null;
		EMCONSubjectType = Strings.Trim(EMCONSubjectType);
		string_0 = Strings.Trim(string_0);
		EMCONSettings = Strings.Trim(EMCONSettings);
		try
		{
			ActiveUnit activeUnit = null;
			switch (EMCONSubjectType.ToUpper())
			{
			case "MISSION":
			{
				Side[] sides_ReadOnly2 = ScenarioContext.Sides_ReadOnly;
				foreach (Side side2 in sides_ReadOnly2)
				{
					foreach (Mission mission in side2.Missions)
					{
						if (string.Equals(mission.Name, string_0, StringComparison.OrdinalIgnoreCase) || string.Equals(mission.ObjectID, string_0, StringComparison.OrdinalIgnoreCase))
						{
							doctrine = mission.Doctrine;
							break;
						}
					}
				}
				break;
			}
			case "GROUP":
				foreach (ActiveUnit activeUnits_ in ScenarioContext.ActiveUnits_List)
				{
					if (activeUnits_ != null && activeUnits_.IsGroup && (string.Equals(activeUnits_.Name, string_0, StringComparison.OrdinalIgnoreCase) || string.Equals(activeUnits_.ObjectID, string_0, StringComparison.OrdinalIgnoreCase)))
					{
						doctrine = activeUnits_.Doctrine;
						activeUnit = activeUnits_;
						break;
					}
				}
				break;
			case "UNIT":
				foreach (ActiveUnit activeUnits_2 in ScenarioContext.ActiveUnits_List)
				{
					if (activeUnits_2 != null && (string.Equals(activeUnits_2.Name, string_0, StringComparison.OrdinalIgnoreCase) || string.Equals(activeUnits_2.ObjectID, string_0, StringComparison.OrdinalIgnoreCase)))
					{
						doctrine = activeUnits_2.Doctrine;
						activeUnit = activeUnits_2;
						break;
					}
				}
				break;
			default:
				throw new LuaError("Unable to identify EMCON subject type! Valid inputs are: Side / Mission /Group / Unit");
			case "SIDE":
			{
				Side[] sides_ReadOnly = ScenarioContext.Sides_ReadOnly;
				foreach (Side side in sides_ReadOnly)
				{
					if (string.Equals(side.Name, string_0, StringComparison.OrdinalIgnoreCase) || string.Equals(side.ObjectID, string_0, StringComparison.OrdinalIgnoreCase))
					{
						doctrine = side.Doctrine;
						break;
					}
				}
				break;
			}
			}
			if (doctrine == null)
			{
				throw new LuaError("Unable to identify subject of EMCON change! Please verify the subject-type and subject-name/ID strings.");
			}
			string[] array = EMCONSettings.Split(new char[1] { ';' });
			foreach (string text in array)
			{
				if (Operators.CompareString(text.ToUpperInvariant(), "INHERIT", false) != 0)
				{
					KeyValuePair<string, string> keyValuePair = new KeyValuePair<string, string>(text.Split(new char[1] { '=' })[0], text.Split(new char[1] { '=' })[1]);
					switch (keyValuePair.Key.ToUpper())
					{
					case "SONAR":
						if (Operators.CompareString(keyValuePair.Value.ToUpper(), "ACTIVE", false) != 0)
						{
							if (Operators.CompareString(keyValuePair.Value.ToUpper(), "PASSIVE", false) != 0)
							{
								throw new LuaError("Invalid value for sonar EMCON setting (Valid values: Active / Passive).");
							}
							if (doctrine.EMCON_Inherits)
							{
								doctrine.EMCON_Inherits = false;
							}
							doctrine.SetEMCON_Sonar(Doctrine.EMCONSettings._EMCONSetting.Passive, ScenarioContext);
						}
						else
						{
							if (doctrine.EMCON_Inherits)
							{
								doctrine.EMCON_Inherits = false;
							}
							doctrine.SetEMCON_Sonar(Doctrine.EMCONSettings._EMCONSetting.Active, ScenarioContext);
						}
						break;
					case "OECM":
						if (Operators.CompareString(keyValuePair.Value.ToUpper(), "ACTIVE", false) != 0)
						{
							if (Operators.CompareString(keyValuePair.Value.ToUpper(), "PASSIVE", false) != 0)
							{
								throw new LuaError("Invalid value for OECM EMCON setting (Valid values: Active / Passive).");
							}
							if (doctrine.EMCON_Inherits)
							{
								doctrine.EMCON_Inherits = false;
							}
							doctrine.SetEMCON_OECM(Doctrine.EMCONSettings._EMCONSetting.Passive, ScenarioContext);
						}
						else
						{
							if (doctrine.EMCON_Inherits)
							{
								doctrine.EMCON_Inherits = false;
							}
							doctrine.SetEMCON_OECM(Doctrine.EMCONSettings._EMCONSetting.Active, ScenarioContext);
						}
						break;
					case "RADAR":
						if (Operators.CompareString(keyValuePair.Value.ToUpper(), "ACTIVE", false) == 0)
						{
							if (doctrine.EMCON_Inherits)
							{
								doctrine.EMCON_Inherits = false;
							}
							doctrine.SetEMCON_Radar(Doctrine.EMCONSettings._EMCONSetting.Active, ScenarioContext);
							break;
						}
						if (Operators.CompareString(keyValuePair.Value.ToUpper(), "PASSIVE", false) == 0)
						{
							if (doctrine.EMCON_Inherits)
							{
								doctrine.EMCON_Inherits = false;
							}
							doctrine.SetEMCON_Radar(Doctrine.EMCONSettings._EMCONSetting.Passive, ScenarioContext);
							break;
						}
						throw new LuaError("Invalid value for radar EMCON setting (Valid values: Active / Passive).");
					}
				}
				else
				{
					doctrine.EMCON_Inherits = true;
				}
			}
			int result;
			if (activeUnit == null)
			{
				result = 1;
			}
			else
			{
				activeUnit.Sensory.ObeysEMCON = true;
				result = 1;
			}
			return (byte)result != 0;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at PM24", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static string ScenEdit_MsgBox(string str, int style, Scenario ScenarioContext)
	{
		string pressed = "";
		luaMessageBoxEventHandler_0?.Invoke(str, style, ScenarioContext.RunningHeadless, ref pressed);
		return pressed;
	}

	public static string ScenEdit_InputBox(string str, Scenario ScenarioContext)
	{
		string pressed = "";
		luaInputBoxEventHandler_0?.Invoke(str, ScenarioContext.RunningHeadless, ref pressed);
		return pressed;
	}

	public static string ScenEdit_LocalVideo(string theFileName, Scenario ScenarioContext, bool FullScreen, int Delay)
	{
		if (!FileExistsNative.FileExistsFast(theFileName))
		{
			if (!FileExistsNative.FileExistsFast(GameGeneral.TopLevelWritablePath + Conversions.ToString(Path.DirectorySeparatorChar) + "Video" + Conversions.ToString(Path.DirectorySeparatorChar) + theFileName))
			{
				return "N";
			}
			theFileName = GameGeneral.TopLevelWritablePath + Conversions.ToString(Path.DirectorySeparatorChar) + "Video" + Conversions.ToString(Path.DirectorySeparatorChar) + theFileName;
		}
		luaLocalVideoEventHandler_0?.Invoke(theFileName, ScenarioContext?.RunningHeadless ?? false, FullScreen, Delay);
		return "";
	}

	public static bool ScenEdit_LocalSound(string theFileName, int Delay)
	{
		if (!FileExistsNative.FileExistsFast(theFileName))
		{
			if (!FileExistsNative.FileExistsFast(Application.StartupPath + "\\Sound\\Effects\\" + theFileName))
			{
				return false;
			}
			theFileName = Application.StartupPath + "\\Sound\\Effects\\" + theFileName;
		}
		else if (!theFileName.Contains(":"))
		{
			theFileName = FileSystem.CurDir() + "\\" + theFileName;
		}
		LuaLocalSoundEventHandler luaLocalSoundEventHandler = luaLocalSoundEventHandler_0;
		int result;
		if (luaLocalSoundEventHandler == null)
		{
			result = 1;
		}
		else
		{
			luaLocalSoundEventHandler(theFileName, Delay);
			result = 1;
		}
		return (byte)result != 0;
	}

	public static int ScenEdit_GetScore(string SideNameOrID, Scenario ScenarioContext)
	{
		Side side = LuaUtility.QuerySideObject(SideNameOrID, ScenarioContext);
		if (Information.IsNothing((object)side))
		{
			throw new LuaError("Unable to identify Side!");
		}
		return side.get_TotalScore(ScenarioContext, (string)null);
	}

	public static string ScenEdit_GetSidePosture(string SideANameOrID, string SideBNameOrID, Scenario ScenarioContext)
	{
		try
		{
			Side side = null;
			Side side2 = null;
			Side[] sides_ReadOnly = ScenarioContext.Sides_ReadOnly;
			foreach (Side side3 in sides_ReadOnly)
			{
				if (string.Equals(side3.ObjectID, SideANameOrID, StringComparison.OrdinalIgnoreCase) || string.Equals(side3.Name, SideANameOrID, StringComparison.OrdinalIgnoreCase))
				{
					side = side3;
				}
				if (string.Equals(side3.ObjectID, SideBNameOrID, StringComparison.OrdinalIgnoreCase) || string.Equals(side3.Name, SideBNameOrID, StringComparison.OrdinalIgnoreCase))
				{
					side2 = side3;
				}
			}
			if (Information.IsNothing((object)side))
			{
				throw new LuaError("Unable to identify Side-A!");
			}
			if (Information.IsNothing((object)side2))
			{
				throw new LuaError("Unable to identify Side-B!");
			}
			switch (side.get_ConsidersThisSideToBe(side2, (Scenario)null))
			{
			case Misc.PostureStance.Neutral:
				return "N";
			case Misc.PostureStance.Friendly:
				return "F";
			case Misc.PostureStance.Unfriendly:
				return "U";
			case Misc.PostureStance.Hostile:
				return "H";
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at PM25", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
		return "";
	}

	public static LuaTable ScenEdit_GetSideOptions(LuaTable table, Scenario ScenarioContext)
	{
		try
		{
			Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(table.GetEnumerator());
			Side side = null;
			if (dictionary.ContainsKey("SIDE"))
			{
				string text = null;
				try
				{
					text = Conversions.ToString(dictionary["SIDE"]);
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error at PM26", "");
					GameGeneral.WriteExceptionsToLog(ex2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("side must be a string");
				}
				try
				{
					side = LuaUtility.QuerySide(dictionary, ScenarioContext);
				}
				catch (Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					Exception ex4 = ex3;
					ex4?.Data.Add("Error at PM27", "");
					GameGeneral.WriteExceptionsToLog(ex4);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("Can't find Side '" + text + "'");
				}
			}
			dictionary["SIDE"] = side.Name;
			dictionary["GUID"] = side.ObjectID;
			dictionary["AWARENESS"] = side.AwarenessLevel.ToString();
			dictionary["PROFICIENCY"] = side.Proficiency.ToString();
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			LuaUtility.FromDict(dictionary, luaTable);
			return luaTable;
		}
		catch (Exception ex5)
		{
			ProjectData.SetProjectError(ex5);
			Exception ex6 = ex5;
			ex6?.Data.Add("Error at PM28", "");
			GameGeneral.WriteExceptionsToLog(ex6);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static string ScenEdit_RunToTimeAndHalt(LuaTable table, Scenario ScenarioContext)
	{
		LuaUtility.DateFormat theDateFormat = LuaUtility.DateFormat.DDMMYYYY;
		Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(table.GetEnumerator());
		string text = "DDMMYYYY";
		string text2 = "MMDDYYYY";
		string text3 = "YYYYMMDD";
		try
		{
			if (dictionary.ContainsKey("DATEFORMAT"))
			{
				string text4 = Conversions.ToString(dictionary["DATEFORMAT"]);
				if (Operators.CompareString(text4, text, false) != 0 && Operators.CompareString(text4, text2, false) != 0 && Operators.CompareString(text4, text3, false) != 0)
				{
					throw new LuaError("Invalid date format '" + text4 + "'");
				}
				string text5 = text4;
				if (Operators.CompareString(text5, text, false) == 0)
				{
					theDateFormat = LuaUtility.DateFormat.DDMMYYYY;
				}
				else if (Operators.CompareString(text5, text2, false) != 0)
				{
					if (Operators.CompareString(text5, text3, false) == 0)
					{
						theDateFormat = LuaUtility.DateFormat.YYYYMMDD;
					}
				}
				else
				{
					theDateFormat = LuaUtility.DateFormat.MMDDYYYY;
				}
			}
			if (dictionary.ContainsKey("DATE"))
			{
				(bool, int, int, int) tuple = LuaUtility.ParseDate_String(Conversions.ToString(dictionary["DATE"]), theDateFormat);
				if (!tuple.Item1)
				{
					ScenarioContext.TimeToHalt = new DateTime(tuple.Item4, tuple.Item3, tuple.Item2, ScenarioContext.Time.Hour, ScenarioContext.Time.Minute, ScenarioContext.Time.Second);
				}
			}
			int num;
			if (!dictionary.ContainsKey("TIME"))
			{
				num = 5;
			}
			else
			{
				(bool, int, int, int) tuple2 = LuaUtility.ParseTime_String(Conversions.ToString(dictionary["TIME"]));
				if (!tuple2.Item1)
				{
					ScenarioContext.TimeToHalt = new DateTime(ScenarioContext.Time.Year, ScenarioContext.Time.Month, ScenarioContext.Time.Day, tuple2.Item2, tuple2.Item3, tuple2.Item4);
					num = 5;
				}
				else
				{
					num = 5;
				}
			}
			string[] array = new string[num];
			array[0] = "OK - Scenario will run to ";
			array[1] = ScenarioContext.TimeToHalt.Value.ToShortDateString();
			array[2] = " - ";
			array[3] = ScenarioContext.TimeToHalt.Value.ToLongTimeString();
			array[4] = " and then halt.";
			return string.Concat(array);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at PM29", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			if (!(ex2 is LuaError))
			{
				throw new LuaError("Error in VP_RunToTimeAndHalt: " + ex2.Message);
			}
			throw new LuaError("Error in VP_RunToTimeAndHalt: " + ((LuaError)ex2).sMessage);
		}
	}

	public static string ScenEdit_RunForTimeAndHalt(LuaTable table, Scenario ScenarioContext)
	{
		Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(table.GetEnumerator());
		try
		{
			if (!dictionary.ContainsKey("TIME"))
			{
				throw new LuaError("Error in VP_RunForTimeAndHalt: No 'Time' value provided");
			}
			string text = Conversions.ToString(dictionary["TIME"]);
			(bool, int, int, int) tuple = LuaUtility.ParseTime_String(text);
			TimeSpan value = new TimeSpan(tuple.Item2, tuple.Item3, tuple.Item4);
			if (value.TotalSeconds <= 0.0)
			{
				throw new LuaError("Error in VP_RunForTimeAndHalt: Unable to parse provided time figure '" + text + "'");
			}
			ScenarioContext.TimeToHalt = ScenarioContext.Time.Add(value);
			return "OK - Scenario will run to " + ScenarioContext.TimeToHalt.Value.ToShortDateString() + " - " + ScenarioContext.TimeToHalt.Value.ToLongTimeString() + " and then halt.";
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at PM30", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			if (ex2 is LuaError)
			{
				throw new LuaError("Error in VP_RunForTimeAndHalt: " + ((LuaError)ex2).sMessage);
			}
			throw new LuaError("Error in VP_RunForTimeAndHalt: " + ex2.Message);
		}
	}

	public static string EpochToUTC_Date(int epoch)
	{
		return Conversions.ToDate("1.1.1970 00:00:00").AddSeconds(epoch).ToString("dd:MM:yyyy");
	}

	public static string EpochToUTC_Time(int epoch)
	{
		return Conversions.ToDate("1.1.1970 00:00:00").AddSeconds(epoch).ToString("HH:mm:ss");
	}

	public static double ScenEdit_SetTime(LuaTable table, Scenario ScenarioContext)
	{
		Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(table.GetEnumerator());
		bool flag = false;
		string text = "DDMMYYYY";
		string text2 = "MMDDYYYY";
		string text3 = "YYYYMMDD";
		LuaUtility.DateFormat dateFormat = LuaUtility.DateFormat.DDMMYYYY;
		if (!dictionary.ContainsKey("DATEFORMAT"))
		{
			dateFormat = LuaUtility.DateFormat.MMDDYYYY;
			dictionary.Add("DATEFORMAT", dateFormat.ToString());
		}
		if (dictionary.ContainsKey("DATEFORMAT"))
		{
			string text4 = Conversions.ToString(dictionary["DATEFORMAT"]);
			if (Operators.CompareString(text4, text, false) != 0 && Operators.CompareString(text4, text2, false) != 0 && Operators.CompareString(text4, text3, false) != 0)
			{
				throw new LuaError("Invalid date format '" + text4 + "'");
			}
			string text5 = text4;
			if (Operators.CompareString(text5, text, false) != 0)
			{
				if (Operators.CompareString(text5, text2, false) == 0)
				{
					dateFormat = LuaUtility.DateFormat.MMDDYYYY;
				}
				else if (Operators.CompareString(text5, text3, false) == 0)
				{
					dateFormat = LuaUtility.DateFormat.YYYYMMDD;
				}
			}
			else
			{
				dateFormat = LuaUtility.DateFormat.DDMMYYYY;
			}
		}
		if (!dictionary.ContainsKey("DATETIME_START") && !dictionary.ContainsKey("DATETIME_NOW"))
		{
			(bool, int, int, int) tuple = default((bool, int, int, int));
			(bool, int, int, int) tuple2 = default((bool, int, int, int));
			if (dictionary.ContainsKey("STARTTIME"))
			{
				tuple2 = LuaUtility.ParseTime_String(Conversions.ToString(dictionary["STARTTIME"]));
				int num;
				if (tuple2.Item1)
				{
					num = 1;
				}
				else
				{
					ScenarioContext.StartTime = new DateTime(ScenarioContext.StartTime.Year, ScenarioContext.StartTime.Month, ScenarioContext.StartTime.Day, tuple2.Item2, tuple2.Item3, tuple2.Item4);
					num = 1;
				}
				flag = (byte)num != 0;
			}
			if (dictionary.ContainsKey("TIME"))
			{
				tuple2 = LuaUtility.ParseTime_String(Conversions.ToString(dictionary["TIME"]));
				int num2;
				if (tuple2.Item1)
				{
					num2 = 0;
				}
				else
				{
					ScenarioContext.set_Time(ManualChange: true, new DateTime(ScenarioContext.Time.Year, ScenarioContext.Time.Month, ScenarioContext.Time.Day, tuple2.Item2, tuple2.Item3, tuple2.Item4));
					num2 = 0;
				}
				flag = (byte)num2 != 0;
			}
			if (dictionary.ContainsKey("STARTDATE"))
			{
				tuple = LuaUtility.ParseDate_String(Conversions.ToString(dictionary["STARTDATE"]), dateFormat);
				int num3;
				if (!tuple.Item1)
				{
					ScenarioContext.StartTime = new DateTime(tuple.Item4, tuple.Item3, tuple.Item2, ScenarioContext.StartTime.Hour, ScenarioContext.StartTime.Minute, ScenarioContext.StartTime.Second);
					num3 = 1;
				}
				else
				{
					num3 = 1;
				}
				flag = (byte)num3 != 0;
			}
			if (dictionary.ContainsKey("DATE"))
			{
				tuple = LuaUtility.ParseDate_String(Conversions.ToString(dictionary["DATE"]), dateFormat);
				int num4;
				if (!tuple.Item1)
				{
					ScenarioContext.set_Time(ManualChange: true, new DateTime(tuple.Item4, tuple.Item3, tuple.Item2, ScenarioContext.Time.Hour, ScenarioContext.Time.Minute, ScenarioContext.Time.Second));
					num4 = 0;
				}
				else
				{
					num4 = 0;
				}
				flag = (byte)num4 != 0;
			}
		}
		else
		{
			if (dictionary.ContainsKey("DATETIME_START"))
			{
				DateTime? dateTime = LuaUtility.ParseDateTime_String(Conversions.ToString(dictionary["DATETIME_START"]), dateFormat);
				if (dateTime.HasValue)
				{
					ScenarioContext.StartTime = dateTime.Value;
					flag = true;
				}
			}
			if (dictionary.ContainsKey("DATETIME_NOW"))
			{
				DateTime? dateTime2 = LuaUtility.ParseDateTime_String(Conversions.ToString(dictionary["DATETIME_NOW"]), dateFormat);
				if (dateTime2.HasValue)
				{
					ScenarioContext.set_Time(ManualChange: true, dateTime2.Value);
					flag = false;
				}
			}
		}
		if (dictionary.ContainsKey("DURATION"))
		{
			(bool, int, int, int) tuple3 = LuaUtility.ParseTime_Duration(Conversions.ToString(dictionary["DURATION"]));
			ScenarioContext.Duration = new TimeSpan(tuple3.Item2, tuple3.Item3, tuple3.Item4);
			flag = true;
		}
		if (flag)
		{
			ScenarioContext.set_Time(ManualChange: true, ScenarioContext.Time);
		}
		return (ScenarioContext.Time - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds;
	}

	public static double ScenEdit_SetStartTime(LuaTable table, Scenario ScenarioContext)
	{
		Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(table.GetEnumerator());
		string text = "DDMMYYYY";
		string text2 = "MMDDYYYY";
		string text3 = "YYYYMMDD";
		LuaUtility.DateFormat dateFormat = LuaUtility.DateFormat.MMDDYYYY;
		if (dictionary.ContainsKey("DATEFORMAT"))
		{
			string text4 = Conversions.ToString(dictionary["DATEFORMAT"]);
			if (Operators.CompareString(text4, text, false) != 0 && Operators.CompareString(text4, text2, false) != 0 && Operators.CompareString(text4, text3, false) != 0)
			{
				throw new LuaError("Invalid date format '" + text4 + "'");
			}
			string text5 = text4;
			if (Operators.CompareString(text5, text, false) != 0)
			{
				if (Operators.CompareString(text5, text2, false) != 0)
				{
					if (Operators.CompareString(text5, text3, false) == 0)
					{
						dateFormat = LuaUtility.DateFormat.YYYYMMDD;
					}
				}
				else
				{
					dateFormat = LuaUtility.DateFormat.MMDDYYYY;
				}
			}
			else
			{
				dateFormat = LuaUtility.DateFormat.DDMMYYYY;
			}
		}
		(bool, int, int, int) tuple = default((bool, int, int, int));
		(bool, int, int, int) tuple2 = default((bool, int, int, int));
		if (dictionary.ContainsKey("DATE"))
		{
			tuple = LuaUtility.ParseDate_String(Conversions.ToString(dictionary["DATE"]), dateFormat);
			if (!tuple.Item1)
			{
				ScenarioContext.StartTime = new DateTime(tuple.Item4, tuple.Item3, tuple.Item2, ScenarioContext.StartTime.Hour, ScenarioContext.StartTime.Minute, ScenarioContext.StartTime.Second);
			}
		}
		if (dictionary.ContainsKey("TIME"))
		{
			tuple2 = LuaUtility.ParseTime_String(Conversions.ToString(dictionary["TIME"]));
			if (!tuple2.Item1)
			{
				ScenarioContext.StartTime = new DateTime(ScenarioContext.StartTime.Year, ScenarioContext.StartTime.Month, ScenarioContext.StartTime.Day, tuple2.Item2, tuple2.Item3, tuple2.Item4);
			}
		}
		if (dictionary.ContainsKey("DATETIME"))
		{
			DateTime? dateTime = LuaUtility.ParseDateTime_String(Conversions.ToString(dictionary["DATETIME"]), dateFormat);
			if (dateTime.HasValue)
			{
				ScenarioContext.StartTime = dateTime.Value;
			}
		}
		if (dictionary.ContainsKey("DURATION"))
		{
			(bool, int, int, int) tuple3 = LuaUtility.ParseTime_Duration(Conversions.ToString(dictionary["DURATION"]));
			if (!tuple3.Item1)
			{
				ScenarioContext.Duration = new TimeSpan(tuple3.Item2, tuple3.Item3, tuple3.Item4);
			}
		}
		ScenarioContext.set_Time(ManualChange: true, ScenarioContext.Time);
		return (ScenarioContext.StartTime - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds;
	}

	public static int ScenEdit_SetScore(string SideNameOrID, int Score, Scenario ScenarioContext, string ReasonForChange)
	{
		Side side = LuaUtility.QuerySideObject(SideNameOrID, ScenarioContext);
		if (Information.IsNothing((object)side))
		{
			throw new LuaError("Unable to identify Side!");
		}
		side.set_TotalScore(ScenarioContext, ReasonForChange, Score);
		return side.get_TotalScore(ScenarioContext, (string)null);
	}

	public static int ScenEdit_SpecialMessage(string SideNameOrID, string Text, Scenario ScenarioContext, LuaTable location, bool ForceMapRecentre)
	{
		Side side = LuaUtility.QuerySideObject(SideNameOrID, ScenarioContext);
		if (side != null)
		{
			Geopoint_Struct? geopoint_Struct = null;
			if (location != null)
			{
				Dictionary<string, object> dict = LuaUtility.ToDictUpper(location.GetEnumerator());
				double? num = LuaUtility.QueryLatitude(dict);
				if (!num.HasValue)
				{
					throw new LuaError("Missing 'Latitude'");
				}
				double? num2 = LuaUtility.QueryLongitude(dict);
				if (!num2.HasValue)
				{
					throw new LuaError("Missing 'Longitude'");
				}
				geopoint_Struct = new Geopoint_Struct(num2.Value, num.Value);
			}
			else if (!geopoint_Struct.HasValue && ForceMapRecentre)
			{
				throw new LuaError("No valid location identified. A valid location is required if setting forceMapRecentre to true.");
			}
			ScenarioContext.AddMessage(Text, Text, LoggedMessage.MessageType.SpecialMessage, 0, null, side, geopoint_Struct.GetValueOrDefault(), ForceMapRecentre);
			return 1;
		}
		throw new LuaError("Unable to identify Side-A!");
	}

	public static int ScenEdit_CustomUI(string SideNameOrID, string Text, Scenario ScenarioContext, LuaTable location, bool ForceMapRecentre)
	{
		Side side = LuaUtility.QuerySideObject(SideNameOrID, ScenarioContext);
		if (side == null)
		{
			throw new LuaError("Unable to identify Side-A!");
		}
		Geopoint_Struct? geopoint_Struct = null;
		if (location == null)
		{
			if (!geopoint_Struct.HasValue && ForceMapRecentre)
			{
				throw new LuaError("No valid location identified. A valid location is required if setting forceMapRecentre to true.");
			}
		}
		else
		{
			Dictionary<string, object> dict = LuaUtility.ToDictUpper(location.GetEnumerator());
			double? num = LuaUtility.QueryLatitude(dict);
			if (!num.HasValue)
			{
				throw new LuaError("Missing 'Latitude'");
			}
			double? num2 = LuaUtility.QueryLongitude(dict);
			if (!num2.HasValue)
			{
				throw new LuaError("Missing 'Longitude'");
			}
			geopoint_Struct = new Geopoint_Struct(num2.Value, num.Value);
		}
		ScenarioContext.AddMessage(Text, Text, LoggedMessage.MessageType.CustomUI, 0, null, side, geopoint_Struct.GetValueOrDefault(), ForceMapRecentre);
		return 1;
	}

	public static LuaWrapper_ActiveUnit_SE ScenEdit_AddUnit(LuaTable table, Scenario ScenarioContext)
	{
		ActiveUnit activeUnit = null;
		int orbitIndex = 1;
		Dictionary<string, object> dict = LuaUtility.ToDictUpper(table.GetEnumerator());
		LuaUtility.ParseUnitDict(ref dict);
		if (dict.ContainsKey("TYPE"))
		{
			string text = Conversions.ToString(dict["TYPE"]).ToUpperInvariant();
			Side side = null;
			try
			{
				side = LuaUtility.QuerySideOrFail(dict, ScenarioContext);
			}
			catch (LuaError projectError)
			{
				ProjectData.SetProjectError((Exception)projectError);
				throw;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at PM31", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("Side not found");
			}
			if (dict.ContainsKey("DBID"))
			{
				int num = Conversions.ToInteger(dict["DBID"]);
				if (!dict.ContainsKey("UNITNAME"))
				{
					throw new LuaError("Missing 'Name'");
				}
				string theName = Conversions.ToString(dict["UNITNAME"]);
				double? num2 = LuaUtility.QueryLatitude(dict);
				double? num3 = LuaUtility.QueryLongitude(dict);
				string text2 = null;
				string text3 = null;
				bool ignoreElevationCheck = false;
				if (dict.ContainsKey("BASE"))
				{
					text2 = Conversions.ToString(dict["BASE"]);
					if (!LuaUtility.QueryBaseUnit(dict, ScenarioContext))
					{
						throw new LuaError("Invalid base unit");
					}
					text3 = Conversions.ToString(dict["BASE"]);
					ActiveUnit activeUnit2 = smethod_1(Conversions.ToString(dict["BASE"]), ScenarioContext);
					string aUGUID = text3;
					int num4 = 0;
					Platform platform = null;
					switch (text)
					{
					default:
					{
						if (!((Operators.CompareString(text, "SUB", false) == 0) | (Operators.CompareString(text, "SUBMARINE", false) == 0)))
						{
							num4 = 1000;
							break;
						}
						platform = new Submarine(ref ScenarioContext);
						Submarine theSub = (Submarine)platform;
						DBFunctions.GetSubmarine(ref ScenarioContext, ref theSub, num);
						break;
					}
					case "SHIP":
					{
						platform = new Ship(ref ScenarioContext);
						Ship theShip = (Ship)platform;
						DBFunctions.GetShip(ref ScenarioContext, ref theShip, num);
						break;
					}
					case "AIR":
					case "AIRCRAFT":
					{
						platform = new Aircraft(ref ScenarioContext);
						Aircraft theAircraft = (Aircraft)platform;
						DBFunctions.GetAircraft(ref ScenarioContext, ref theAircraft, num);
						break;
					}
					}
					while (num4 < 100)
					{
						switch (text)
						{
						default:
							if (!((Operators.CompareString(text, "SUB", false) == 0) | (Operators.CompareString(text, "SUBMARINE", false) == 0)))
							{
								continue;
							}
							goto case "SHIP";
						case "SHIP":
						{
							ActiveUnit_DockingOps dockingOps = activeUnit2.DockingOps;
							Platform theBoat = platform;
							DockFacility bestFacility = null;
							if (!dockingOps.CanHostThisBoat(theBoat, ref bestFacility))
							{
								num4++;
								activeUnit2 = NextAUBySceanrio(aUGUID, text2, ScenarioContext);
								if (activeUnit2 != null)
								{
									aUGUID = activeUnit2.ObjectID;
									continue;
								}
								if (text3 != null)
								{
									dict["BASE"] = text3;
								}
							}
							else if (!num3.HasValue | !num2.HasValue)
							{
								dict["LONGITUDE"] = activeUnit2.get_Longitude((GlobalVariables.BooleanObject)null);
								dict["LATITUDE"] = activeUnit2.get_Latitude((GlobalVariables.BooleanObject)null);
								num3 = activeUnit2.get_Longitude((GlobalVariables.BooleanObject)null);
								num2 = activeUnit2.get_Latitude((GlobalVariables.BooleanObject)null);
								dict["BASE"] = activeUnit2.ObjectID;
								ignoreElevationCheck = true;
							}
							break;
						}
						case "AIR":
						case "AIRCRAFT":
							if (activeUnit2.AirOps.CanHostThisAircraft((Aircraft)platform) != AirOpsAttemptResult.Success)
							{
								num4++;
								activeUnit2 = NextAUBySceanrio(aUGUID, text2, ScenarioContext);
								if (activeUnit2 != null)
								{
									aUGUID = activeUnit2.ObjectID;
									continue;
								}
								if (text3 != null)
								{
									dict["BASE"] = text3;
								}
							}
							else if (!num3.HasValue | !num2.HasValue)
							{
								dict["ALTITUDE"] = activeUnit2.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
								dict["LONGITUDE"] = activeUnit2.get_Longitude((GlobalVariables.BooleanObject)null);
								dict["LATITUDE"] = activeUnit2.get_Latitude((GlobalVariables.BooleanObject)null);
								num3 = activeUnit2.get_Longitude((GlobalVariables.BooleanObject)null);
								num2 = activeUnit2.get_Latitude((GlobalVariables.BooleanObject)null);
								dict["BASE"] = activeUnit2.ObjectID;
							}
							break;
						}
						break;
					}
				}
				else if (Operators.CompareString(text, "SATELLITE", false) != 0)
				{
					if (!num2.HasValue)
					{
						throw new LuaError("Missing 'Latitude'");
					}
					if (!num3.HasValue)
					{
						throw new LuaError("Missing 'Longitude'");
					}
				}
				string theGUID = null;
				if (dict.ContainsKey("GUID"))
				{
					theGUID = Conversions.ToString(dict["GUID"]);
				}
				try
				{
					switch (text)
					{
					case "WEAPON":
					{
						float? num6 = LuaUtility.QueryAltitude(dict);
						activeUnit = ScenarioContext.AddNewWeapon(side, theName, num3.Value, num2.Value, num, (short)Math.Round(num6.Value), Module_Unit.Unit.RemoteSimEntityTypeEnum.Local, theGUID);
						((Weapon)activeUnit).LaunchPoint = new GeoPoint(activeUnit.get_Longitude((GlobalVariables.BooleanObject)null), activeUnit.get_Latitude((GlobalVariables.BooleanObject)null));
						dict["TYPE"] = "WEAPON";
						break;
					}
					case "SATELLITE":
						if (dict.ContainsKey("ORBIT"))
						{
							orbitIndex = Conversions.ToInteger(dict["ORBIT"]);
						}
						activeUnit = ScenarioContext.AddNewSatellite(side, theName, num, orbitIndex, Module_Unit.Unit.RemoteSimEntityTypeEnum.Local, theGUID);
						dict["TYPE"] = "SATELLITE";
						if (activeUnit != null)
						{
							Satellite satellite = (Satellite)activeUnit;
							if (DateTime.Compare(satellite.DeOrbitDate, ScenarioContext.Time) < 0 && DateTime.Compare(satellite.DeOrbitDate, new DateTime(1900, 1, 1)) > 0)
							{
								throw new LuaError("Has already de-orbited on " + satellite.DeOrbitDate.ToLongDateString());
							}
							if (DateTime.Compare(satellite.LaunchDate, ScenarioContext.Time) >= 0 && (satellite.LaunchDate - ScenarioContext.Time).Ticks > 0L)
							{
								throw new LuaError("Not vailable until " + satellite.LaunchDate.ToLongDateString());
							}
						}
						dict["LATITUDE"] = activeUnit.get_Latitude((GlobalVariables.BooleanObject)null);
						dict["LONGITUDE"] = activeUnit.get_Longitude((GlobalVariables.BooleanObject)null);
						break;
					case "FACILITY":
					case "LAND":
						activeUnit = ScenarioContext.AddNewFacility(side, num, theName, num3.Value, num2.Value, ignoreElevationCheck, Module_Unit.Unit.RemoteSimEntityTypeEnum.Local, theGUID);
						dict["TYPE"] = "FACILITY";
						break;
					case "SUB":
					case "SUBMARINE":
						activeUnit = ScenarioContext.AddNewSubmarine(side, num, theName, num3.Value, num2.Value, ignoreElevationCheck, Module_Unit.Unit.RemoteSimEntityTypeEnum.Local, theGUID);
						dict["TYPE"] = "SUBMARINE";
						break;
					case "SHIP":
						activeUnit = ScenarioContext.AddNewShip(side, num, theName, num3.Value, num2.Value, ignoreElevationCheck, Module_Unit.Unit.RemoteSimEntityTypeEnum.Local, theGUID);
						dict["TYPE"] = "SHIP";
						break;
					case "GROUND UNIT":
					case "VEHICLE":
						activeUnit = ScenarioContext.AddNewVehicle(side, num, theName, num3.Value, num2.Value, ignoreElevationCheck, Module_Unit.Unit.RemoteSimEntityTypeEnum.Local, theGUID);
						dict["TYPE"] = "GROUND UNIT";
						break;
					default:
						throw new LuaError("Type cannot be " + text + " please choose one of the following: SHIP, SUB, AIRCRAFT, FACILITY, GROUND UNIT, SATELLITE, WEAPON");
					case "AIR":
					case "AIRCRAFT":
						if (dict.ContainsKey("LOADOUTID"))
						{
							int loadoutID = Conversions.ToInteger(dict["LOADOUTID"]);
							float? num5 = LuaUtility.QueryAltitude(dict);
							if (num5.HasValue)
							{
								activeUnit = ScenarioContext.AddNewAircraft(side, theName, num3.Value, num2.Value, num, loadoutID, (short)Math.Round(num5.Value), Module_Unit.Unit.RemoteSimEntityTypeEnum.Local, theGUID);
								dict["TYPE"] = "AIRCRAFT";
								break;
							}
							throw new LuaError("Missing 'Altitude'");
						}
						throw new LuaError("Missing 'LoadoutID'");
					}
				}
				catch (Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					Exception ex4 = ex3;
					ex4?.Data.Add("Error at PM32", "");
					GameGeneral.WriteExceptionsToLog(ex4);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					if (!(ex4 is LuaError))
					{
						throw new LuaError(ex4.Message);
					}
					throw;
				}
				if (activeUnit != null)
				{
					theGUID = activeUnit.ObjectID;
					dict["GUID"] = theGUID;
					if (dict.ContainsKey("BASE"))
					{
						LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
						luaTable["HostedUnitNameOrID"] = activeUnit.ObjectID;
						luaTable["SelectedHostNameOrID"] = Conversions.ToString(dict["BASE"]);
						if (!Conversions.ToBoolean(ScenEdit_HostUnitToParent(luaTable, ScenarioContext, null)))
						{
							throw new LuaError("Unable to host unit");
						}
						activeUnit.CurrentSpeed = 0f;
						activeUnit.SetThrottle(ActiveUnit.Throttle.FullStop);
					}
					if (dict.ContainsKey("HEADING") && !dict.ContainsKey("DESIREDHEADING"))
					{
						dict["DESIREDHEADING"] = RuntimeHelpers.GetObjectValue(dict["HEADING"]);
					}
					LuaTable table2 = LuaSandBox.Singleton().CreateTable();
					LuaUtility.FromDict(dict, table2);
					return ScenEdit_SetUnit(table2, ScenarioContext);
				}
				throw new LuaError("Unable to create new unit");
			}
			throw new LuaError("Missing 'DBID'");
		}
		throw new LuaError("Missing 'Type' please choose one of SHIP, SUB, AIRCRAFT, FACILITY, GROUND UNIT, SATELLITE, WEAPON");
	}

	public static LuaWrapper_ActiveUnit_SE ScenEdit_UpdateUnit(LuaTable table, Scenario ScenarioContext)
	{
		//IL_1191: Unknown result type (might be due to invalid IL or missing references)
		//IL_1198: Expected O, but got Unknown
		//IL_12a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_12ae: Expected O, but got Unknown
		ActiveUnit theParentPlatform = null;
		string text = null;
		int num = 0;
		PlatformComponent._Coverage coverage = null;
		PlatformComponent._Coverage coverage2 = null;
		PlatformComponent._Coverage coverage3 = null;
		Dictionary<string, object> dict = LuaUtility.ToDictUpper(table.GetEnumerator());
		LuaUtility.ParseUnitDict(ref dict);
		if (dict.ContainsKey("GUID"))
		{
			string text2 = null;
			try
			{
				text2 = Conversions.ToString(dict["GUID"]);
				theParentPlatform = ScenarioContext.ActiveUnits[text2];
				if (theParentPlatform == null)
				{
					throw new LuaError("Can't find unit guid " + text2);
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at PM33", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				if (!(ex2 is LuaError))
				{
					throw new LuaError("Can't find unit guid " + text2);
				}
				throw;
			}
		}
		if (dict.ContainsKey("MODE"))
		{
			try
			{
				text = Conversions.ToString(dict["MODE"]).ToUpper();
				switch (text)
				{
				default:
					throw new LuaError("function should be 'add_sensor', 'remove_sensor', 'add_mount', 'remove_mount', 'add_weapon', 'remove_weapon','add_comms', 'remove_comms', 'add_magazine', 'add_magazine_only', 'remove_magazine','add_fuel', 'remove_fuel','add_dock_facility', 'remove_dock_facility','add_air_facility', 'remove_air_facility', 'delta'");
				case "REMOVE_SENSOR":
					break;
				case "UPDATE_SENSOR_ARC":
					break;
				case "ADD_COMMS":
					break;
				case "REMOVE_COMMS":
					break;
				case "ADD_MOUNT":
					break;
				case "REMOVE_MOUNT":
					break;
				case "UPDATE_MOUNT_ARC":
					break;
				case "ADD_WEAPON":
					break;
				case "REMOVE_WEAPON":
					break;
				case "ADD_MAGAZINE":
					break;
				case "REMOVE_MAGAZINE":
					break;
				case "ADD_MAGAZINE_ONLY":
					break;
				case "ADD_FUEL":
					break;
				case "REMOVE_FUEL":
					break;
				case "ADD_AIR_FACILITY":
					break;
				case "REMOVE_AIR_FACILITY":
					break;
				case "ADD_DOCK_FACILITY":
					break;
				case "REMOVE_DOCK_FACILITY":
					break;
				case "DELTA":
					break;
				}
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				ex4?.Data.Add("Error at PM35", "");
				GameGeneral.WriteExceptionsToLog(ex4);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
		if (dict.ContainsKey("DBID"))
		{
			try
			{
				num = Conversions.ToInteger(dict["DBID"]);
			}
			catch (Exception ex5)
			{
				ProjectData.SetProjectError(ex5);
				Exception ex6 = ex5;
				ex6?.Data.Add("Error at PM36", "");
				GameGeneral.WriteExceptionsToLog(ex6);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("Missing dbid");
			}
		}
		if (dict.ContainsKey("ARC_DETECT"))
		{
			LuaTable luaTable = (LuaTable)dict["ARC_DETECT"];
			PlatformComponent._Coverage coverage4 = new PlatformComponent._Coverage();
			Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(luaTable.GetEnumerator());
			if (dictionary.Count != 0)
			{
				Conversions.ToString(dictionary["1"]);
				List<object> list = LuaUtility.ToArray(luaTable.GetEnumerator());
				try
				{
					foreach (object item in list)
					{
						string text3 = Conversions.ToString(item);
						switch (text3.ToUpper())
						{
						case "PMF1":
							coverage4.PMF1 = true;
							continue;
						case "PS2":
							coverage4.PS2 = true;
							continue;
						case "PMA1":
							coverage4.PMA1 = true;
							continue;
						case "PMF2":
							coverage4.PMF2 = true;
							continue;
						case "SS2":
							coverage4.SS2 = true;
							continue;
						case "PMA2":
							coverage4.PMA2 = true;
							continue;
						case "PB2":
							coverage4.PB2 = true;
							continue;
						case "SS1":
							coverage4.SS1 = true;
							continue;
						case "SMF1":
							coverage4.SMF1 = true;
							continue;
						case "PB1":
							coverage4.PB1 = true;
							continue;
						case "SMA1":
							coverage4.SMA1 = true;
							continue;
						case "SMF2":
							coverage4.SMF2 = true;
							continue;
						case "SMA2":
							coverage4.SMA2 = true;
							continue;
						case "PS1":
							coverage4.PS1 = true;
							continue;
						case "SB2":
							coverage4.SB2 = true;
							continue;
						case "SB1":
							coverage4.SB1 = true;
							continue;
						case "360":
							coverage4.PB1 = true;
							coverage4.PMA1 = true;
							coverage4.PMF1 = true;
							coverage4.PS1 = true;
							coverage4.SB1 = true;
							coverage4.SMA1 = true;
							coverage4.SMF1 = true;
							coverage4.SS1 = true;
							coverage4.PB2 = true;
							coverage4.PMA2 = true;
							coverage4.PMF2 = true;
							coverage4.PS2 = true;
							coverage4.SB2 = true;
							coverage4.SMA2 = true;
							coverage4.SMF2 = true;
							coverage4.SS2 = true;
							break;
						default:
							throw new LuaError("Invalid arc in arc_detect " + text3);
						}
						break;
					}
					coverage = coverage4;
				}
				catch (Exception ex7)
				{
					ProjectData.SetProjectError(ex7);
					Exception ex8 = ex7;
					ex8?.Data.Add("Error at PM37", "");
					GameGeneral.WriteExceptionsToLog(ex8);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw;
				}
			}
			else
			{
				coverage = coverage4;
			}
		}
		if (dict.ContainsKey("ARC_TRACK"))
		{
			LuaTable luaTable2 = (LuaTable)dict["ARC_TRACK"];
			PlatformComponent._Coverage coverage5 = new PlatformComponent._Coverage();
			Dictionary<string, object> dictionary2 = LuaUtility.ToDictUpper(luaTable2.GetEnumerator());
			if (dictionary2.Count != 0)
			{
				Conversions.ToString(dictionary2["1"]);
				List<object> list2 = LuaUtility.ToArray(luaTable2.GetEnumerator());
				try
				{
					foreach (object item2 in list2)
					{
						string text4 = Conversions.ToString(item2);
						switch (text4.ToUpper())
						{
						case "SMF1":
							coverage5.SMF1 = true;
							continue;
						case "PB1":
							coverage5.PB1 = true;
							continue;
						case "SMA1":
							coverage5.SMA1 = true;
							continue;
						case "SMF2":
							coverage5.SMF2 = true;
							continue;
						case "SMA2":
							coverage5.SMA2 = true;
							continue;
						case "PS1":
							coverage5.PS1 = true;
							continue;
						case "SB2":
							coverage5.SB2 = true;
							continue;
						case "SB1":
							coverage5.SB1 = true;
							continue;
						case "PMF1":
							coverage5.PMF1 = true;
							continue;
						case "PS2":
							coverage5.PS2 = true;
							continue;
						case "PMA1":
							coverage5.PMA1 = true;
							continue;
						case "PMF2":
							coverage5.PMF2 = true;
							continue;
						case "SS2":
							coverage5.SS2 = true;
							continue;
						case "PMA2":
							coverage5.PMA2 = true;
							continue;
						case "PB2":
							coverage5.PB2 = true;
							continue;
						case "SS1":
							coverage5.SS1 = true;
							continue;
						case "360":
							coverage5.PB1 = true;
							coverage5.PMA1 = true;
							coverage5.PMF1 = true;
							coverage5.PS1 = true;
							coverage5.SB1 = true;
							coverage5.SMA1 = true;
							coverage5.SMF1 = true;
							coverage5.SS1 = true;
							coverage5.PB2 = true;
							coverage5.PMA2 = true;
							coverage5.PMF2 = true;
							coverage5.PS2 = true;
							coverage5.SB2 = true;
							coverage5.SMA2 = true;
							coverage5.SMF2 = true;
							coverage5.SS2 = true;
							break;
						default:
							throw new LuaError("Invalid arc in arc_track " + text4);
						}
						break;
					}
					coverage2 = coverage5;
				}
				catch (Exception ex9)
				{
					ProjectData.SetProjectError(ex9);
					Exception ex10 = ex9;
					ex10?.Data.Add("Error at PM38", "");
					GameGeneral.WriteExceptionsToLog(ex10);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw;
				}
			}
			else
			{
				coverage2 = coverage5;
			}
		}
		if (dict.ContainsKey("ARC_MOUNT"))
		{
			LuaTable obj = (LuaTable)dict["ARC_MOUNT"];
			PlatformComponent._Coverage coverage6 = new PlatformComponent._Coverage();
			Conversions.ToString(LuaUtility.ToDictUpper(obj.GetEnumerator())["1"]);
			List<object> list3 = LuaUtility.ToArray(obj.GetEnumerator());
			try
			{
				foreach (object item3 in list3)
				{
					string text5 = Conversions.ToString(item3);
					switch (text5.ToUpper())
					{
					case "SS2":
						coverage6.SS2 = true;
						continue;
					case "PMA2":
						coverage6.PMA2 = true;
						continue;
					case "PB2":
						coverage6.PB2 = true;
						continue;
					case "SS1":
						coverage6.SS1 = true;
						continue;
					case "PMF1":
						coverage6.PMF1 = true;
						continue;
					case "PS2":
						coverage6.PS2 = true;
						continue;
					case "PMA1":
						coverage6.PMA1 = true;
						continue;
					case "PMF2":
						coverage6.PMF2 = true;
						continue;
					case "SMF1":
						coverage6.SMF1 = true;
						continue;
					case "PB1":
						coverage6.PB1 = true;
						continue;
					case "SMA1":
						coverage6.SMA1 = true;
						continue;
					case "SMF2":
						coverage6.SMF2 = true;
						continue;
					case "SMA2":
						coverage6.SMA2 = true;
						continue;
					case "PS1":
						coverage6.PS1 = true;
						continue;
					case "SB2":
						coverage6.SB2 = true;
						continue;
					case "SB1":
						coverage6.SB1 = true;
						continue;
					case "360":
						coverage6.PB1 = true;
						coverage6.PMA1 = true;
						coverage6.PMF1 = true;
						coverage6.PS1 = true;
						coverage6.SB1 = true;
						coverage6.SMA1 = true;
						coverage6.SMF1 = true;
						coverage6.SS1 = true;
						coverage6.PB2 = true;
						coverage6.PMA2 = true;
						coverage6.PMF2 = true;
						coverage6.PS2 = true;
						coverage6.SB2 = true;
						coverage6.SMA2 = true;
						coverage6.SMF2 = true;
						coverage6.SS2 = true;
						break;
					default:
						throw new LuaError("Invalid arc in arc_mount " + text5);
					}
					break;
				}
				coverage3 = coverage6;
			}
			catch (Exception ex11)
			{
				ProjectData.SetProjectError(ex11);
				Exception ex12 = ex11;
				ex12?.Data.Add("Error at PM39", "");
				GameGeneral.WriteExceptionsToLog(ex12);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
		switch (text)
		{
		case "DELTA":
		{
			if (!dict.ContainsKey("FILE"))
			{
				throw new LuaError("Missing file on applying delta ");
			}
			int ErrorCount = 0;
			string path = GameGeneral.ScenariosRootPath + "\\" + Conversions.ToString(dict["FILE"]);
			FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			XmlDocument val = new XmlDocument();
			new Dictionary<string, ScenarioObject>();
			string m2;
			using (fileStream)
			{
				try
				{
					val.Load((Stream)fileStream);
				}
				catch (Exception ex67)
				{
					ProjectData.SetProjectError(ex67);
					Exception ex68 = ex67;
					ex68?.Data.Add("Error at PM40", "");
					GameGeneral.WriteExceptionsToLog(ex68);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					m2 = "File Is improperly formatted, read failed!";
					throw new LuaError(m2);
				}
				fileStream.Close();
			}
			XmlNode val2 = ((XmlNode)val).SelectSingleNode("/ScenarioUnits");
			if (val2 == null)
			{
				break;
			}
			XmlNodeList childNodes = val2.ChildNodes;
			m2 = "\r\n" + DateAndTime.Now.ToString() + " Lua update to " + ScenarioContext.Title + " Platform list: \r\n  DBID -- Unit name  ----  Class Info  ----  ObjectID";
			StreamWriter streamWriter = File.AppendText(GameGeneral.LogsPath + Conversions.ToString(Path.DirectorySeparatorChar) + "SBR log file.txt");
			streamWriter.Write(m2);
			streamWriter.Close();
			foreach (XmlNode item4 in childNodes)
			{
				XmlNode val3 = item4;
				string text16 = val3.Name.Split(new char[1] { '_' })[1];
				string innerText = Misc.GetNodeByName(val3.ChildNodes, "#comment").InnerText;
				ActiveUnit activeUnit = ScenarioContext.ActiveUnits[text16];
				if (activeUnit != null)
				{
					if (Operators.CompareString(activeUnit.ObjectID, theParentPlatform.ObjectID, false) == 0)
					{
						SBR.ApplyDeltaToThisUnit(val3, theParentPlatform, ScenarioContext, null, null, IsUnitCloningOperation: false, ref ErrorCount);
						break;
					}
					if (innerText.StartsWith(theParentPlatform.Name))
					{
						SBR.ApplyDeltaToThisUnit(val3, theParentPlatform, ScenarioContext, null, null, IsUnitCloningOperation: false, ref ErrorCount);
						break;
					}
				}
				else if (innerText.StartsWith(theParentPlatform.Name))
				{
					SBR.ApplyDeltaToThisUnit(val3, theParentPlatform, ScenarioContext, null, null, IsUnitCloningOperation: false, ref ErrorCount);
					break;
				}
				if (activeUnit == null)
				{
					m2 = "ERROR: UNIT # " + text16 + " DOES NOT EXIST IN SCENARIO!";
					throw new LuaError(m2);
				}
			}
			break;
		}
		case "ADD_SENSOR":
		case "UPDATE_SENSOR_ARC":
		case "REMOVE_SENSOR":
			switch (text)
			{
			case "ADD_SENSOR":
				try
				{
					int int_ = num;
					SQLiteConnection sqliteConnection_ = theParentPlatform.ParentScen.DBConnection;
					Sensor sensor4 = DBFunctions.GetSensor(int_, ref sqliteConnection_);
					if (sensor4 == null)
					{
						throw new LuaError("Unknown sensor " + Conversions.ToString(num));
					}
					if (!sensor4.Coverage.HasDefinedArcs && coverage == null && !sensor4.Coverage_Illuminate.HasDefinedArcs && coverage2 == null)
					{
						throw new LuaError("Neither type of arc supplied for sensor " + sensor4.Name);
					}
					if (coverage != null && (!coverage.HasDefinedArcs || (coverage.HasDefinedArcs && !coverage.Equals(sensor4.Coverage))))
					{
						sensor4.Coverage = coverage;
					}
					if (coverage2 != null && (!coverage2.HasDefinedArcs || (coverage2.HasDefinedArcs && !coverage2.Equals(sensor4.Coverage_Illuminate))))
					{
						sensor4.Coverage_Illuminate = coverage2;
					}
					sensor4.ParentPlatform = theParentPlatform;
					theParentPlatform.AddSensor(sensor4);
				}
				catch (Exception ex35)
				{
					ProjectData.SetProjectError(ex35);
					Exception ex36 = ex35;
					ex36?.Data.Add("Error at PM41", "");
					GameGeneral.WriteExceptionsToLog(ex36);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw;
				}
				break;
			case "UPDATE_SENSOR_ARC":
				if (dict.ContainsKey("SENSORID"))
				{
					string text10 = null;
					Sensor sensor5 = null;
					try
					{
						text10 = Conversions.ToString(dict["SENSORID"]);
						Sensor[] sensors_Cached3 = theParentPlatform.Sensors_Cached;
						foreach (Sensor sensor6 in sensors_Cached3)
						{
							if (Operators.CompareString(sensor6.ObjectID, text10, false) == 0)
							{
								sensor5 = sensor6;
								break;
							}
						}
						if (sensor5 == null)
						{
							throw new LuaError("Can't find sensor " + text10);
						}
					}
					catch (Exception ex37)
					{
						ProjectData.SetProjectError(ex37);
						Exception ex38 = ex37;
						ex38?.Data.Add("Error at PM44", "");
						GameGeneral.WriteExceptionsToLog(ex38);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						throw new LuaError("Can't find sensor " + text10);
					}
					try
					{
						if (coverage != null && (!coverage.HasDefinedArcs || (coverage.HasDefinedArcs && !coverage.Equals(sensor5.Coverage))))
						{
							sensor5.Coverage = coverage;
						}
						if (coverage2 != null && (!coverage2.HasDefinedArcs || (coverage2.HasDefinedArcs && !coverage2.Equals(sensor5.Coverage_Illuminate))))
						{
							sensor5.Coverage_Illuminate = coverage2;
						}
					}
					catch (Exception ex39)
					{
						ProjectData.SetProjectError(ex39);
						Exception ex40 = ex39;
						ex40?.Data.Add("Error at PM43", "");
						GameGeneral.WriteExceptionsToLog(ex40);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						throw new LuaError("Unable to update " + sensor5.Name);
					}
					break;
				}
				throw new LuaError("Sensor to update not defined");
			case "REMOVE_SENSOR":
				if (!dict.ContainsKey("SENSORID") && num > 0)
				{
					Sensor[] sensors_Cached = theParentPlatform.Sensors_Cached;
					foreach (Sensor sensor in sensors_Cached)
					{
						if (sensor.DBID == num)
						{
							dict["SENSORID"] = sensor.ObjectID;
							break;
						}
					}
				}
				if (dict.ContainsKey("SENSORID"))
				{
					string text9 = null;
					Sensor sensor2 = null;
					try
					{
						text9 = Conversions.ToString(dict["SENSORID"]);
						Sensor[] sensors_Cached2 = theParentPlatform.Sensors_Cached;
						foreach (Sensor sensor3 in sensors_Cached2)
						{
							if (Operators.CompareString(sensor3.ObjectID, text9, false) == 0)
							{
								sensor2 = sensor3;
								break;
							}
						}
						if (sensor2 == null)
						{
							throw new LuaError("Can't find sensor " + text9);
						}
					}
					catch (Exception ex31)
					{
						ProjectData.SetProjectError(ex31);
						Exception ex32 = ex31;
						ex32?.Data.Add("Error at PM42", "");
						GameGeneral.WriteExceptionsToLog(ex32);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						throw new LuaError("Can't find sensor " + text9);
					}
					try
					{
						theParentPlatform.RemoveSensor(sensor2);
					}
					catch (Exception ex33)
					{
						ProjectData.SetProjectError(ex33);
						Exception ex34 = ex33;
						ex34?.Data.Add("Error at PM43", "");
						GameGeneral.WriteExceptionsToLog(ex34);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						throw new LuaError("Unable to remove " + sensor2.Name);
					}
					break;
				}
				throw new LuaError("Sensor to remove not defined");
			}
			break;
		case "REMOVE_COMMS":
		case "ADD_COMMS":
			if (Operators.CompareString(text, "ADD_COMMS", false) != 0)
			{
				if (Operators.CompareString(text, "REMOVE_COMMS", false) != 0)
				{
					break;
				}
				if (!dict.ContainsKey("COMMSID") && num > 0)
				{
					CommDevice[] comms_ReadOnly = theParentPlatform.Comms_ReadOnly;
					foreach (CommDevice commDevice in comms_ReadOnly)
					{
						if (commDevice.DBID == num)
						{
							dict["COMMSID"] = commDevice.ObjectID;
							break;
						}
					}
				}
				if (dict.ContainsKey("COMMSID"))
				{
					string text7 = null;
					CommDevice commDevice2 = null;
					try
					{
						text7 = Conversions.ToString(dict["COMMSID"]);
						CommDevice[] comms_ReadOnly2 = theParentPlatform.Comms_ReadOnly;
						foreach (CommDevice commDevice3 in comms_ReadOnly2)
						{
							if (Operators.CompareString(commDevice3.ObjectID, text7, false) == 0)
							{
								commDevice2 = commDevice3;
								break;
							}
						}
						if (commDevice2 == null)
						{
							throw new LuaError("Can't find comms " + text7);
						}
					}
					catch (Exception ex19)
					{
						ProjectData.SetProjectError(ex19);
						Exception ex20 = ex19;
						ex20?.Data.Add("Error at PM55", "");
						GameGeneral.WriteExceptionsToLog(ex20);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						throw new LuaError("Can't find comms " + text7);
					}
					try
					{
						theParentPlatform.RemoveCommDevice(commDevice2);
					}
					catch (Exception ex21)
					{
						ProjectData.SetProjectError(ex21);
						Exception ex22 = ex21;
						ex22?.Data.Add("Error at PM56", "");
						GameGeneral.WriteExceptionsToLog(ex22);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						throw new LuaError("Unable to remove " + commDevice2.Name);
					}
					break;
				}
				throw new LuaError("Comms to remove not defined");
			}
			try
			{
				CommDevice commDevice4 = DBFunctions.GetCommDevice(num, ref theParentPlatform);
				if (commDevice4 == null)
				{
					throw new LuaError("Unknown comms " + Conversions.ToString(num));
				}
				commDevice4.ParentPlatform = theParentPlatform;
				theParentPlatform.AddCommDevice(commDevice4);
			}
			catch (Exception ex23)
			{
				ProjectData.SetProjectError(ex23);
				Exception ex24 = ex23;
				ex24?.Data.Add("Error at PM55", "");
				GameGeneral.WriteExceptionsToLog(ex24);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("Unknown comms " + Conversions.ToString(num));
			}
			break;
		case "ADD_MOUNT":
		case "REMOVE_MOUNT":
		case "UPDATE_MOUNT_ARC":
			switch (text)
			{
			case "UPDATE_MOUNT_ARC":
			{
				if (!dict.ContainsKey("MOUNTID"))
				{
					throw new LuaError("Sensor to update not defined");
				}
				string text13 = null;
				Mount mount3 = null;
				try
				{
					text13 = Conversions.ToString(dict["MOUNTID"]);
					foreach (Mount mount5 in theParentPlatform.Mounts)
					{
						if (Operators.CompareString(mount5.ObjectID, text13, false) == 0)
						{
							mount3 = mount5;
							break;
						}
					}
					if (mount3 == null)
					{
						throw new LuaError("Can't find Mount " + text13);
					}
				}
				catch (Exception ex53)
				{
					ProjectData.SetProjectError(ex53);
					Exception ex54 = ex53;
					ex54?.Data.Add("Error at PM48", "");
					GameGeneral.WriteExceptionsToLog(ex54);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("Can't find mount " + text13);
				}
				try
				{
					if (coverage3.HasDefinedArcs && !coverage3.Equals(mount3.Coverage))
					{
						mount3.Coverage = coverage3;
					}
				}
				catch (Exception ex55)
				{
					ProjectData.SetProjectError(ex55);
					Exception ex56 = ex55;
					ex56?.Data.Add("Error at PM49", "");
					GameGeneral.WriteExceptionsToLog(ex56);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("Unable to update " + mount3.Name);
				}
				break;
			}
			case "REMOVE_MOUNT":
			{
				if (!dict.ContainsKey("MOUNTID") && num > 0)
				{
					foreach (Mount mount6 in theParentPlatform.Mounts)
					{
						if (mount6.DBID == num)
						{
							dict["MOUNTID"] = mount6.ObjectID;
							break;
						}
					}
				}
				if (!dict.ContainsKey("MOUNTID"))
				{
					throw new LuaError("mount to remove not defined");
				}
				string text12 = null;
				Mount mount2 = null;
				try
				{
					text12 = Conversions.ToString(dict["MOUNTID"]);
					foreach (Mount mount7 in theParentPlatform.Mounts)
					{
						if (Operators.CompareString(mount7.ObjectID, text12, false) == 0)
						{
							mount2 = mount7;
							break;
						}
					}
					if (mount2 == null)
					{
						throw new LuaError("Can't find mount " + text12);
					}
				}
				catch (Exception ex49)
				{
					ProjectData.SetProjectError(ex49);
					Exception ex50 = ex49;
					ex50?.Data.Add("Error at PM46", "");
					GameGeneral.WriteExceptionsToLog(ex50);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("Can't find mount " + text12);
				}
				try
				{
					theParentPlatform.Mounts.Remove(mount2);
				}
				catch (Exception ex51)
				{
					ProjectData.SetProjectError(ex51);
					Exception ex52 = ex51;
					ex52?.Data.Add("Error at PM47", "");
					GameGeneral.WriteExceptionsToLog(ex52);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("Unable to remove " + mount2.Name);
				}
				break;
			}
			case "ADD_MOUNT":
				try
				{
					Mount mount = DBFunctions.GetMount(num, ref ScenarioContext);
					if (mount != null && coverage3 != null)
					{
						if (coverage3.HasDefinedArcs && !coverage3.Equals(mount.Coverage))
						{
							mount.Coverage = coverage3;
						}
						mount.ParentPlatform = theParentPlatform;
						if (mount.Sensors_ReadOnly.Count() > 0)
						{
							Sensor[] sensors_ReadOnly = mount.Sensors_ReadOnly;
							foreach (Sensor sensor7 in sensors_ReadOnly)
							{
								if (coverage2 != null && coverage2.HasDefinedArcs)
								{
									sensor7.Coverage_Illuminate = coverage2;
								}
								else
								{
									sensor7.Coverage_Illuminate = coverage3;
								}
								sensor7.ParentPlatform = theParentPlatform;
							}
						}
						theParentPlatform.Mounts.Add(mount);
					}
					else
					{
						if (mount == null)
						{
							throw new LuaError("Unknown mount " + Conversions.ToString(num));
						}
						if (coverage3 == null)
						{
							throw new LuaError("No targeting arcs supplied for mount " + mount.Name);
						}
					}
				}
				catch (Exception ex47)
				{
					ProjectData.SetProjectError(ex47);
					Exception ex48 = ex47;
					ex48?.Data.Add("Error at PM 45", "");
					GameGeneral.WriteExceptionsToLog(ex48);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw;
				}
				break;
			}
			break;
		case "ADD_AIR_FACILITY":
		case "REMOVE_AIR_FACILITY":
			if (Operators.CompareString(text, "ADD_AIR_FACILITY", false) != 0)
			{
				if (Operators.CompareString(text, "REMOVE_AIR_FACILITY", false) != 0)
				{
					break;
				}
				if (!dict.ContainsKey("AIRFACID") && num > 0)
				{
					AirFacility[] airFacilities_ReadOnly = theParentPlatform.AirFacilities_ReadOnly;
					foreach (AirFacility airFacility in airFacilities_ReadOnly)
					{
						if (airFacility.DBID == num)
						{
							dict["AIRFACID"] = airFacility.ObjectID;
							break;
						}
					}
				}
				if (dict.ContainsKey("AIRFACID"))
				{
					string text11 = null;
					AirFacility airFacility2 = null;
					try
					{
						text11 = Conversions.ToString(dict["AIRFACID"]);
						AirFacility[] airFacilities_ReadOnly2 = theParentPlatform.AirFacilities_ReadOnly;
						foreach (AirFacility airFacility3 in airFacilities_ReadOnly2)
						{
							if (Operators.CompareString(airFacility3.ObjectID, text11, false) == 0)
							{
								airFacility2 = airFacility3;
								break;
							}
						}
						if (airFacility2 == null)
						{
							throw new LuaError("Can't find air facility " + text11);
						}
					}
					catch (Exception ex41)
					{
						ProjectData.SetProjectError(ex41);
						Exception ex42 = ex41;
						ex42?.Data.Add("Error at PM220", "");
						GameGeneral.WriteExceptionsToLog(ex42);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						throw new LuaError("Can't find air facility " + text11);
					}
					try
					{
						theParentPlatform.RemoveAirFacility(airFacility2);
					}
					catch (Exception ex43)
					{
						ProjectData.SetProjectError(ex43);
						Exception ex44 = ex43;
						ex44?.Data.Add("Error at PM230", "");
						GameGeneral.WriteExceptionsToLog(ex44);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						throw new LuaError("Unable to remove " + airFacility2.Name);
					}
					break;
				}
				throw new LuaError("Air facility to remove not defined");
			}
			try
			{
				int facilityDBID2 = num;
				SQLiteConnection sqliteConnection_ = ScenarioContext.DBConnection;
				AirFacility airFacility4 = DBFunctions.GetAirFacility(facilityDBID2, ref sqliteConnection_);
				if (airFacility4 == null)
				{
					throw new LuaError("Unknown air facility " + Conversions.ToString(num));
				}
				theParentPlatform.AddAirFacility(airFacility4);
				airFacility4.ParentPlatform = theParentPlatform;
			}
			catch (Exception ex45)
			{
				ProjectData.SetProjectError(ex45);
				Exception ex46 = ex45;
				ex46?.Data.Add("Error at PM210", "");
				GameGeneral.WriteExceptionsToLog(ex46);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("Unknown air facility " + Conversions.ToString(num));
			}
			break;
		case "ADD_FUEL":
		case "REMOVE_FUEL":
		{
			if (!dict.ContainsKey("FUEL"))
			{
				break;
			}
			List<object> list4 = LuaUtility.ToArray(((LuaTable)dict["FUEL"]).GetEnumerator());
			if (!theParentPlatform.IsFixedFacility)
			{
				throw new LuaError("Can't modify Fuel source on this type of unit.");
			}
			try
			{
				_Closure$__142-0 closure$__142- = default(_Closure$__142-0);
				foreach (object item5 in list4)
				{
					object objectValue = RuntimeHelpers.GetObjectValue(item5);
					if (!(objectValue is LuaTable))
					{
						continue;
					}
					Dictionary<string, object> dictionary3 = LuaUtility.ToDictUpper(((LuaTable)objectValue).GetEnumerator());
					if (dictionary3.ContainsKey("1") & dictionary3.ContainsKey("2"))
					{
						string value = Conversions.ToString(dictionary3["1"]);
						int result = int.MaxValue;
						if (int.TryParse(Conversions.ToString(dictionary3["2"]), out result))
						{
							closure$__142- = new _Closure$__142-0(closure$__142-);
							if (Enum.TryParse<FuelRec._FuelType>(value, ignoreCase: true, out closure$__142-.$VB$Local_e) & Enum.IsDefined(typeof(FuelRec._FuelType), closure$__142-.$VB$Local_e))
							{
								FuelRec fuelRec = theParentPlatform.Fuel_ReadOnly.FirstOrDefault(closure$__142-._Lambda$__0);
								if (Operators.CompareString(text, "ADD_FUEL", false) == 0 && fuelRec == null)
								{
									FuelRec fuelRec2 = new FuelRec(result, (short)closure$__142-.$VB$Local_e);
									fuelRec2.CurrentQuantity = fuelRec2.MaxQuantity;
									theParentPlatform.AddFuelRec(fuelRec2);
									continue;
								}
								if (Operators.CompareString(text, "REMOVE_FUEL", false) == 0 && fuelRec != null)
								{
									theParentPlatform.RemoveFuelRec(fuelRec);
									continue;
								}
								throw new LuaError("Fuel type " + closure$__142-.$VB$Local_e.ToString() + ((Operators.CompareString(text, "ADD_FUEL", false) != 0) ? " does not exist" : " exists") + " on unit.");
							}
							throw new LuaError("Error in fuel type at " + LuaUtility.LuaInterpret(RuntimeHelpers.GetObjectValue(objectValue)));
						}
						throw new LuaError("Error in amount at " + LuaUtility.LuaInterpret(RuntimeHelpers.GetObjectValue(objectValue)));
					}
					throw new LuaError("Error in table " + LuaUtility.LuaInterpret(RuntimeHelpers.GetObjectValue(objectValue)));
				}
			}
			catch (Exception ex69)
			{
				ProjectData.SetProjectError(ex69);
				Exception ex70 = ex69;
				ex70?.Data.Add("Error at PM60", "");
				GameGeneral.WriteExceptionsToLog(ex70);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
			break;
		}
		case "REMOVE_WEAPON":
		case "ADD_WEAPON":
		{
			Mount mount4 = null;
			if (dict.ContainsKey("MOUNTID"))
			{
				string text14 = null;
				try
				{
					text14 = Conversions.ToString(dict["MOUNTID"]);
					foreach (Mount mount8 in theParentPlatform.Mounts)
					{
						if (Operators.CompareString(mount8.ObjectID, text14, false) == 0)
						{
							mount4 = mount8;
							break;
						}
					}
				}
				catch (Exception ex57)
				{
					ProjectData.SetProjectError(ex57);
					Exception ex58 = ex57;
					ex58?.Data.Add("Error at PM50", "");
					GameGeneral.WriteExceptionsToLog(ex58);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("Can't find weapon mount " + text14);
				}
				if (mount4 == null)
				{
					throw new LuaError("Can't find weapon mount " + text14);
				}
			}
			if (Operators.CompareString(text, "ADD_WEAPON", false) == 0)
			{
				try
				{
					WeaponRec weaponRec = DBFunctions.GetWeaponRec(num, ScenarioContext);
					if (weaponRec == null)
					{
						throw new LuaError("Unknown weapon record " + Conversions.ToString(num));
					}
					mount4.MountWeapons.Add(weaponRec);
				}
				catch (Exception ex59)
				{
					ProjectData.SetProjectError(ex59);
					Exception ex60 = ex59;
					ex60?.Data.Add("Error at PM51", "");
					GameGeneral.WriteExceptionsToLog(ex60);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("Unknown weapon record " + Conversions.ToString(num));
				}
			}
			else
			{
				if (Operators.CompareString(text, "REMOVE_WEAPON", false) != 0)
				{
					break;
				}
				if (!dict.ContainsKey("WEAPONID"))
				{
					throw new LuaError("mount to remove not defined");
				}
				string text15 = null;
				WeaponRec weaponRec2 = null;
				try
				{
					text15 = Conversions.ToString(dict["WEAPONID"]);
					foreach (WeaponRec mountWeapon in mount4.MountWeapons)
					{
						if (Operators.CompareString(mountWeapon.ObjectID, text15, false) == 0)
						{
							weaponRec2 = mountWeapon;
							break;
						}
					}
					if (weaponRec2 == null)
					{
						throw new LuaError("Can't find weapon " + text15 + " on mount " + mount4.ObjectID);
					}
				}
				catch (Exception ex61)
				{
					ProjectData.SetProjectError(ex61);
					Exception ex62 = ex61;
					ex62?.Data.Add("Error at PM52", "");
					GameGeneral.WriteExceptionsToLog(ex62);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("Can't find weapon " + text15 + " on mount " + mount4.ObjectID);
				}
				try
				{
					try
					{
						mount4.MountWeapons.Remove(weaponRec2);
					}
					catch (Exception ex63)
					{
						ProjectData.SetProjectError(ex63);
						Exception ex64 = ex63;
						ex64?.Data.Add("Error at PM53", "");
						GameGeneral.WriteExceptionsToLog(ex64);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						throw new LuaError("Unable to remove " + weaponRec2.Name);
					}
				}
				catch (Exception ex65)
				{
					ProjectData.SetProjectError(ex65);
					Exception ex66 = ex65;
					ex66?.Data.Add("Error at PM54", "");
					GameGeneral.WriteExceptionsToLog(ex66);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("Unable to remove " + weaponRec2.Name);
				}
			}
			break;
		}
		case "ADD_MAGAZINE_ONLY":
		case "REMOVE_MAGAZINE":
		case "ADD_MAGAZINE":
			switch (text)
			{
			case "REMOVE_MAGAZINE":
			{
				if (!dict.ContainsKey("MAGID") && num > 0)
				{
					Magazine[] sharedMagazines = theParentPlatform.SharedMagazines;
					foreach (Magazine magazine2 in sharedMagazines)
					{
						if (magazine2.DBID == num)
						{
							dict["MAGID"] = magazine2.ObjectID;
							break;
						}
					}
				}
				if (!dict.ContainsKey("MAGID"))
				{
					throw new LuaError("Magazine to remove not defined");
				}
				string text8 = null;
				Magazine magazine3 = null;
				try
				{
					text8 = Conversions.ToString(dict["MAGID"]);
					Magazine[] sharedMagazines2 = theParentPlatform.SharedMagazines;
					foreach (Magazine magazine4 in sharedMagazines2)
					{
						if (Operators.CompareString(magazine4.ObjectID, text8, false) == 0)
						{
							magazine3 = magazine4;
							break;
						}
					}
					if (magazine3 == null)
					{
						throw new LuaError("Can't find magazine " + text8);
					}
				}
				catch (Exception ex27)
				{
					ProjectData.SetProjectError(ex27);
					Exception ex28 = ex27;
					ex28?.Data.Add("Error at PM58", "");
					GameGeneral.WriteExceptionsToLog(ex28);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("Can't find magazine " + text8);
				}
				try
				{
					((Platform)theParentPlatform).RemoveSharedMagazine(magazine3);
				}
				catch (Exception ex29)
				{
					ProjectData.SetProjectError(ex29);
					Exception ex30 = ex29;
					ex30?.Data.Add("Error at PM59", "");
					GameGeneral.WriteExceptionsToLog(ex30);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("Unable to remove " + magazine3.Name);
				}
				break;
			}
			case "ADD_MAGAZINE":
			case "ADD_MAGAZINE_ONLY":
				try
				{
					bool loadComponents = true;
					if (Operators.CompareString(text, "ADD_MAGAZINE_ONLY", false) == 0)
					{
						loadComponents = false;
					}
					Magazine magazine = DBFunctions.GetMagazine(num, ref ScenarioContext, loadComponents);
					if (magazine == null)
					{
						throw new LuaError("Unknown magazine " + Conversions.ToString(num));
					}
					magazine.ParentPlatform = theParentPlatform;
					((Platform)theParentPlatform).AddSharedMagazine(magazine);
				}
				catch (Exception ex25)
				{
					ProjectData.SetProjectError(ex25);
					Exception ex26 = ex25;
					ex26?.Data.Add("Error at PM57", "");
					GameGeneral.WriteExceptionsToLog(ex26);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("Unknown magazine " + Conversions.ToString(num));
				}
				break;
			}
			break;
		case "ADD_DOCK_FACILITY":
		case "REMOVE_DOCK_FACILITY":
			if (Operators.CompareString(text, "ADD_DOCK_FACILITY", false) != 0)
			{
				if (Operators.CompareString(text, "REMOVE_DOCK_FACILITY", false) != 0)
				{
					break;
				}
				if (!dict.ContainsKey("DOCKFACID") && num > 0)
				{
					DockFacility[] dockFacilities_ReadOnly = theParentPlatform.DockFacilities_ReadOnly;
					foreach (DockFacility dockFacility in dockFacilities_ReadOnly)
					{
						if (dockFacility.DBID == num)
						{
							dict["DOCKFACID"] = dockFacility.ObjectID;
							break;
						}
					}
				}
				if (!dict.ContainsKey("DOCKFACID"))
				{
					throw new LuaError("Dock facility to remove not defined");
				}
				string text6 = null;
				DockFacility dockFacility2 = null;
				try
				{
					text6 = Conversions.ToString(dict["DOCKFACID"]);
					DockFacility[] dockFacilities_ReadOnly2 = theParentPlatform.DockFacilities_ReadOnly;
					foreach (DockFacility dockFacility3 in dockFacilities_ReadOnly2)
					{
						if (Operators.CompareString(dockFacility3.ObjectID, text6, false) == 0)
						{
							dockFacility2 = dockFacility3;
							break;
						}
					}
					if (dockFacility2 == null)
					{
						throw new LuaError("Can't find dock facility " + text6);
					}
				}
				catch (Exception ex13)
				{
					ProjectData.SetProjectError(ex13);
					Exception ex14 = ex13;
					ex14?.Data.Add("Error at PM250", "");
					GameGeneral.WriteExceptionsToLog(ex14);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("Can't find dock facility " + text6);
				}
				try
				{
					theParentPlatform.RemoveDockFacility(dockFacility2);
				}
				catch (Exception ex15)
				{
					ProjectData.SetProjectError(ex15);
					Exception ex16 = ex15;
					ex16?.Data.Add("Error at PM260", "");
					GameGeneral.WriteExceptionsToLog(ex16);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("Unable to remove " + dockFacility2.Name);
				}
				break;
			}
			try
			{
				int facilityDBID = num;
				SQLiteConnection sqliteConnection_ = ScenarioContext.DBConnection;
				DockFacility dockFacility4 = DBFunctions.GetDockFacility(facilityDBID, ref sqliteConnection_);
				if (dockFacility4 == null)
				{
					throw new LuaError("Unknown dock facility " + Conversions.ToString(num));
				}
				theParentPlatform.AddDockFacility(dockFacility4);
				dockFacility4.ParentPlatform = theParentPlatform;
			}
			catch (Exception ex17)
			{
				ProjectData.SetProjectError(ex17);
				Exception ex18 = ex17;
				ex18?.Data.Add("Error at PM240", "");
				GameGeneral.WriteExceptionsToLog(ex18);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("Unknown dock facility " + Conversions.ToString(num));
			}
			break;
		}
		if (dict.ContainsKey("FUEL"))
		{
			dict.Remove("FUEL");
		}
		LuaTable table2 = LuaSandBox.Singleton().CreateTable();
		LuaUtility.FromDict(dict, table2);
		return ScenEdit_SetUnit(table2, ScenarioContext);
	}

	public static LuaWrapper_ActiveUnit_SE ScenEdit_UpdateUnitCargo(LuaTable table, Scenario ScenarioContext)
	{
		ActiveUnit activeUnit = null;
		string text = null;
		ICargoHost theParent = (ICargoHost)activeUnit;
		Cargo cargo = null;
		LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
		List<Cargo> list = new List<Cargo>();
		Dictionary<string, object> dict = LuaUtility.ToDictUpper(table.GetEnumerator());
		LuaUtility.ParseUnitDict(ref dict);
		if (dict.ContainsKey("GUID"))
		{
			string text2 = null;
			try
			{
				text2 = Conversions.ToString(dict["GUID"]);
				activeUnit = ScenarioContext.ActiveUnits[text2];
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at PM61", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("Can't find guid " + text2);
			}
		}
		if (dict.ContainsKey("MODE"))
		{
			try
			{
				text = Conversions.ToString(dict["MODE"]).ToUpper();
				if (Operators.CompareString(text, "ADD_CARGO", false) != 0 && Operators.CompareString(text, "REMOVE_CARGO", false) != 0)
				{
					throw new LuaError("function should be 'add_cargo', 'remove_cargo' ");
				}
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				ex4?.Data.Add("Error at PM62", "");
				GameGeneral.WriteExceptionsToLog(ex4);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
		if (dict.ContainsKey("DBID"))
		{
			try
			{
				Conversions.ToInteger(dict["DBID"]);
			}
			catch (Exception ex5)
			{
				ProjectData.SetProjectError(ex5);
				Exception ex6 = ex5;
				ex6?.Data.Add("Error at PM63", "");
				GameGeneral.WriteExceptionsToLog(ex6);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("Missing dbid");
			}
		}
		if (dict.ContainsKey("CARGO"))
		{
			try
			{
				luaTable = (LuaTable)dict["CARGO"];
			}
			catch (Exception ex7)
			{
				ProjectData.SetProjectError(ex7);
				Exception ex8 = ex7;
				ex8?.Data.Add("Error at PM64", "");
				GameGeneral.WriteExceptionsToLog(ex8);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("Error in cargo list");
			}
		}
		if (!activeUnit.IsGroup)
		{
			List<object> list2 = new List<object>();
			if (Information.IsNothing((object)luaTable))
			{
				throw new LuaError("Missing cargo list");
			}
			list2 = LuaUtility.ToArray(luaTable.GetEnumerator());
			if (list2.Count == 0)
			{
				throw new LuaError("Missing cargo list");
			}
			_Closure$__143-0 closure$__143- = default(_Closure$__143-0);
			foreach (object item in list2)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(item);
				closure$__143- = new _Closure$__143-0(closure$__143-);
				int num = 0;
				closure$__143-.$VB$Local_moveDBID = 0;
				closure$__143-.$VB$Local_moveGUID = null;
				closure$__143-.$VB$Local_moveCargoType = 1;
				if (objectValue is LuaTable)
				{
					List<object> list3 = LuaUtility.ToArray(((LuaTable)objectValue).GetEnumerator());
					if (list3.Count == 1)
					{
						closure$__143-.$VB$Local_moveDBID = Conversions.ToInteger(list3[0]);
						num = 1;
					}
					else if (list3.Count == 3)
					{
						closure$__143-.$VB$Local_moveCargoType = Conversions.ToInteger(list3[2]);
						closure$__143-.$VB$Local_moveDBID = Conversions.ToInteger(list3[1]);
						num = Conversions.ToInteger(list3[0]);
					}
					else
					{
						closure$__143-.$VB$Local_moveDBID = Conversions.ToInteger(list3[1]);
						num = Conversions.ToInteger(list3[0]);
					}
				}
				else
				{
					closure$__143-.$VB$Local_moveGUID = Conversions.ToString(objectValue);
					num = 1;
				}
				if (num < 1 || (closure$__143-.$VB$Local_moveDBID < 1 && Information.IsNothing((object)closure$__143-.$VB$Local_moveGUID)))
				{
					continue;
				}
				IEnumerator<Cargo> enumerator2;
				if (!Information.IsNothing((object)closure$__143-.$VB$Local_moveGUID))
				{
					enumerator2 = (from C in activeUnit.OnboardCargo.Where(closure$__143-._Lambda$__3)
						select (C)).GetEnumerator();
					enumerator2.MoveNext();
				}
				else
				{
					enumerator2 = (from C in activeUnit.OnboardCargo.Where(closure$__143-._Lambda$__0).Where(closure$__143-._Lambda$__1)
						select (C)).GetEnumerator();
				}
				for (int num2 = num; num2 > 0; num2--)
				{
					if (Information.IsNothing((object)closure$__143-.$VB$Local_moveGUID))
					{
						if (enumerator2.MoveNext() & (Operators.CompareString(text, "REMOVE_CARGO", false) == 0))
						{
							list.Add(enumerator2.Current);
						}
						else if (closure$__143-.$VB$Local_moveCargoType == 4)
						{
							CargoContainer cargoContainer = DBFunctions.GetCargoContainer(closure$__143-.$VB$Local_moveDBID, ref ScenarioContext);
							cargo = new Cargo(activeUnit, cargoContainer, theParent);
							list.Add(cargo);
						}
						else
						{
							cargo = Cargo.CreateNewCargo((Cargo.CargoObjectType)closure$__143-.$VB$Local_moveCargoType, closure$__143-.$VB$Local_moveDBID, activeUnit, activeUnit.ParentScen);
							list.Add(cargo);
						}
					}
					else
					{
						int num3;
						if (Operators.CompareString(text, "REMOVE_CARGO", false) == 0)
						{
							list.Add(enumerator2.Current);
							num3 = 1;
						}
						else
						{
							num3 = 1;
						}
						num2 = num3;
					}
				}
			}
			if (list.Count != 0)
			{
				if (Operators.CompareString(text, "ADD_CARGO", false) != 0)
				{
					if (Operators.CompareString(text, "REMOVE_CARGO", false) == 0)
					{
						try
						{
							foreach (Cargo item2 in list)
							{
								if (!activeUnit.OnboardCargo.Contains(item2))
								{
									continue;
								}
								ArrayExtensions.Remove(ref activeUnit.OnboardCargo, item2);
								if (item2.CargoObjectActiveUnit != null)
								{
									ActiveUnit cargoObjectActiveUnit = item2.CargoObjectActiveUnit;
									if (!ScenarioContext.ExecutionInProgress)
									{
										ScenarioContext.DeleteUnitImmediately(cargoObjectActiveUnit.ObjectID, ScenEditAction: true, "Deleted via Lua command.", null, RegisterAsLosses: false);
									}
									else
									{
										ScenarioContext.DeleteThisUnit(cargoObjectActiveUnit);
									}
								}
							}
						}
						catch (Exception ex9)
						{
							ProjectData.SetProjectError(ex9);
							Exception ex10 = ex9;
							ex10?.Data.Add("Error at PM66", "");
							GameGeneral.WriteExceptionsToLog(ex10);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							throw new LuaError("Error removing cargo.");
						}
					}
				}
				else
				{
					try
					{
						ICargoHost obj = (ICargoHost)activeUnit;
						double num4 = 0.0;
						double num5 = 0.0;
						double num6 = 0.0;
						CargoType cargoType = CargoType.NoCargo;
						num4 = CargoHostHelper.GetAvailableMass(obj, activeUnit.OnboardCargo);
						num5 = CargoHostHelper.GetAvailableArea(obj, activeUnit.OnboardCargo);
						num6 = CargoHostHelper.GetAvailableCrewSpace(obj, activeUnit.OnboardCargo);
						cargoType = obj.GetCargo_Type();
						foreach (Cargo item3 in list)
						{
							if (item3.RequiredCargoType <= cargoType && num4 >= (double)item3.RequiredMass && num5 >= (double)item3.RequiredArea && num6 >= (double)item3.RequiredCrewSpace)
							{
								num4 -= (double)item3.RequiredMass;
								num5 -= (double)item3.RequiredArea;
								num6 -= (double)item3.RequiredCrewSpace;
								ArrayExtensions.Add(ref activeUnit.OnboardCargo, item3);
								if (item3.CargoObjectActiveUnit != null)
								{
									item3.CargoObjectActiveUnit.DockingOps.LoadIntoCargo(activeUnit);
								}
							}
						}
					}
					catch (Exception ex11)
					{
						ProjectData.SetProjectError(ex11);
						Exception ex12 = ex11;
						ex12?.Data.Add("Error at PM65", "");
						GameGeneral.WriteExceptionsToLog(ex12);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						throw new LuaError("Error adding cargo.");
					}
				}
				LuaTable table2 = LuaSandBox.Singleton().CreateTable();
				LuaUtility.FromDict(dict, table2);
				return ScenEdit_SetUnit(table2, ScenarioContext);
			}
			throw new LuaError("No cargo list to action");
		}
		throw new LuaError("Group can't host cargo");
	}

	public static LuaWrapper_ActiveUnit_SE ScenEdit_GetUnit(LuaTable table, Scenario ScenarioContext)
	{
		Dictionary<string, object> dict = LuaUtility.ToDictUpper(table.GetEnumerator());
		ActiveUnit value = null;
		Side side = null;
		string text = null;
		string text2 = null;
		string text3 = null;
		LuaUtility.ParseUnitDict(ref dict);
		if (dict.ContainsKey("GUID"))
		{
			try
			{
				text3 = Conversions.ToString(dict["GUID"]);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at PM67", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("guid must be a string");
			}
			if (!ScenarioContext.ActiveUnits.TryGetValue(text3, out value))
			{
				_ = Debugger.IsAttached;
				text = "Can't find guid " + text3;
			}
		}
		else if (dict.ContainsKey("UNITNAME"))
		{
			try
			{
				text2 = Conversions.ToString(dict["UNITNAME"]);
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				ex4?.Data.Add("Error at PM69", "");
				GameGeneral.WriteExceptionsToLog(ex4);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("name must be a string");
			}
			if (dict.ContainsKey("SIDE"))
			{
				string text4;
				try
				{
					text4 = Conversions.ToString(dict["SIDE"]);
				}
				catch (Exception ex5)
				{
					ProjectData.SetProjectError(ex5);
					Exception ex6 = ex5;
					ex6?.Data.Add("Error at PM70", "");
					GameGeneral.WriteExceptionsToLog(ex6);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("side must be a string");
				}
				try
				{
					side = LuaUtility.QuerySide(dict, ScenarioContext);
				}
				catch (Exception ex7)
				{
					ProjectData.SetProjectError(ex7);
					Exception ex8 = ex7;
					ex8?.Data.Add("Error at PM71", "");
					GameGeneral.WriteExceptionsToLog(ex8);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					text = "Can't find Side '" + text4 + "'";
					ProjectData.ClearProjectError();
				}
				try
				{
					if (side != null)
					{
						value = side.Units.FirstOrDefault([SpecialName] (ActiveUnit s) => string.Equals(s.Name, text2, StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, text2, StringComparison.OrdinalIgnoreCase));
					}
				}
				catch (Exception ex9)
				{
					ProjectData.SetProjectError(ex9);
					Exception ex10 = ex9;
					ex10?.Data.Add("Error at PM72", "");
					GameGeneral.WriteExceptionsToLog(ex10);
					int num;
					if (Debugger.IsAttached)
					{
						Debugger.Break();
						num = 5;
					}
					else
					{
						num = 5;
					}
					string[] array = new string[num];
					array[0] = "Can't find Unit '";
					array[1] = text2;
					array[2] = "' on Side '";
					array[3] = text4;
					array[4] = "'";
					text = string.Concat(array);
					ProjectData.ClearProjectError();
				}
			}
			else
			{
				try
				{
					value = ScenarioContext.ActiveUnits_List.FirstOrDefault([SpecialName] (ActiveUnit s) => string.Equals(s.Name, text2, StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, text2, StringComparison.OrdinalIgnoreCase));
				}
				catch (Exception ex11)
				{
					ProjectData.SetProjectError(ex11);
					Exception ex12 = ex11;
					ex12?.Data.Add("Error at PM73", "");
					GameGeneral.WriteExceptionsToLog(ex12);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					text = "Can't find Unit '" + text2 + "'";
					ProjectData.ClearProjectError();
				}
			}
		}
		if (value == null)
		{
			if (LuaSandBox.Singleton().RunInteractive && text != null)
			{
				throw new LuaError(text);
			}
			return null;
		}
		return new LuaWrapper_ActiveUnit_SE(value, ScenarioContext);
	}

	public static string ScenEdit_GetDBFileHash(LuaTable table)
	{
		Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(table.GetEnumerator());
		if (!dictionary.ContainsKey("FILENAME"))
		{
			throw new LuaError("Mandatory paramater 'Filename' is not provided");
		}
		string text = Conversions.ToString(dictionary["FILENAME"]);
		if (!FileExistsNative.FileExistsFast(text))
		{
			throw new LuaError("File: " + text + " does not exist");
		}
		return Crypto.GetFileHashFromFilename(text);
	}

	public static LuaTable ScenEdit_GetSensorData(int DBID, Scenario ScenarioContext)
	{
		throw new LuaError("ERROR - This scenario or script uses ScenEdit_GetSensorData which is a PRO edition feature.");
	}

	public static void ScenEdit_ClearAllMagazines(LuaTable table, Scenario ScenarioContext)
	{
		Dictionary<string, object> dict = LuaUtility.ToDictUpper(table.GetEnumerator());
		ActiveUnit activeUnit = null;
		LuaUtility.ParseUnitDict(ref dict);
		if (dict.ContainsKey("GUID"))
		{
			string text;
			try
			{
				text = Conversions.ToString(dict["GUID"]);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at PM75", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("guid must be a string");
			}
			try
			{
				activeUnit = ScenarioContext.ActiveUnits[text];
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				ex4?.Data.Add("Error at PM76", "");
				GameGeneral.WriteExceptionsToLog(ex4);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("Can't find guid " + text);
			}
		}
		else if (dict.ContainsKey("UNITNAME"))
		{
			_Closure$__147-0 arg = default(_Closure$__147-0);
			_Closure$__147-0 CS$<>8__locals7 = new _Closure$__147-0(arg);
			try
			{
				CS$<>8__locals7.$VB$Local_Name = Conversions.ToString(dict["UNITNAME"]);
			}
			catch (Exception ex5)
			{
				ProjectData.SetProjectError(ex5);
				Exception ex6 = ex5;
				ex6?.Data.Add("Error at PM77", "");
				GameGeneral.WriteExceptionsToLog(ex6);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("name must be a string");
			}
			if (dict.ContainsKey("SIDE"))
			{
				string text2;
				try
				{
					text2 = Conversions.ToString(dict["SIDE"]);
				}
				catch (Exception ex7)
				{
					ProjectData.SetProjectError(ex7);
					Exception ex8 = ex7;
					ex8?.Data.Add("Error at PM78", "");
					GameGeneral.WriteExceptionsToLog(ex8);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("side must be a string");
				}
				Side side;
				try
				{
					side = LuaUtility.QuerySide(dict, ScenarioContext);
				}
				catch (Exception ex9)
				{
					ProjectData.SetProjectError(ex9);
					Exception ex10 = ex9;
					ex10?.Data.Add("Error at PM79", "");
					GameGeneral.WriteExceptionsToLog(ex10);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("Can't find Side '" + text2 + "'");
				}
				try
				{
					activeUnit = side.Units.First([SpecialName] (ActiveUnit s) => string.Equals(s.Name, CS$<>8__locals7.$VB$Local_Name, StringComparison.OrdinalIgnoreCase) | string.Equals(s.ObjectID, CS$<>8__locals7.$VB$Local_Name, StringComparison.OrdinalIgnoreCase));
				}
				catch (Exception ex11)
				{
					ProjectData.SetProjectError(ex11);
					Exception ex12 = ex11;
					ex12?.Data.Add("Error at PM80", "");
					GameGeneral.WriteExceptionsToLog(ex12);
					int num;
					if (!Debugger.IsAttached)
					{
						num = 5;
					}
					else
					{
						Debugger.Break();
						num = 5;
					}
					string[] array = new string[num];
					array[0] = "Can't find Unit '";
					array[1] = CS$<>8__locals7.$VB$Local_Name;
					array[2] = "' on Side '";
					array[3] = text2;
					array[4] = "'";
					throw new LuaError(string.Concat(array));
				}
			}
			else
			{
				try
				{
					activeUnit = ScenarioContext.ActiveUnits_List.First([SpecialName] (ActiveUnit s) => string.Equals(s.Name, CS$<>8__locals7.$VB$Local_Name, StringComparison.OrdinalIgnoreCase) | string.Equals(s.ObjectID, CS$<>8__locals7.$VB$Local_Name, StringComparison.OrdinalIgnoreCase));
				}
				catch (Exception ex13)
				{
					ProjectData.SetProjectError(ex13);
					Exception ex14 = ex13;
					ex14?.Data.Add("Error at PM81", "");
					GameGeneral.WriteExceptionsToLog(ex14);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("Can't find Unit '" + CS$<>8__locals7.$VB$Local_Name + "'");
				}
			}
		}
		if (activeUnit != null)
		{
			List<ActiveUnit> list = new List<ActiveUnit>();
			list.Add(activeUnit);
			if (activeUnit is Group)
			{
				foreach (KeyValuePair<string, ActiveUnit> unit in ((Group)activeUnit).Units)
				{
					list.Add(unit.Value);
				}
			}
			{
				foreach (ActiveUnit item in list)
				{
					Magazine[] totalMagazines = item.TotalMagazines;
					foreach (Magazine magazine in totalMagazines)
					{
						foreach (WeaponRec weapon in magazine.Weapons)
						{
							weapon.CurrentLoad = 0;
						}
					}
				}
				return;
			}
		}
		throw new LuaError("Need to define a Name or Guid to identify a unit. Preferably a Guid or Side & Name.");
	}

	public static void ScenEdit_ClearAllAircraft(LuaTable table, Scenario ScenarioContext)
	{
		Dictionary<string, object> dict = LuaUtility.ToDictUpper(table.GetEnumerator());
		ActiveUnit activeUnit = null;
		LuaUtility.ParseUnitDict(ref dict);
		if (dict.ContainsKey("GUID"))
		{
			string text;
			try
			{
				text = Conversions.ToString(dict["GUID"]);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at PM82", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("guid must be a string");
			}
			try
			{
				activeUnit = ScenarioContext.ActiveUnits[text];
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				ex4?.Data.Add("Error at PM83", "");
				GameGeneral.WriteExceptionsToLog(ex4);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("Can't find guid " + text);
			}
		}
		else if (dict.ContainsKey("UNITNAME"))
		{
			_Closure$__148-0 arg = default(_Closure$__148-0);
			_Closure$__148-0 CS$<>8__locals7 = new _Closure$__148-0(arg);
			try
			{
				CS$<>8__locals7.$VB$Local_Name = Conversions.ToString(dict["UNITNAME"]);
			}
			catch (Exception ex5)
			{
				ProjectData.SetProjectError(ex5);
				Exception ex6 = ex5;
				ex6?.Data.Add("Error at PM84", "");
				GameGeneral.WriteExceptionsToLog(ex6);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("name must be a string");
			}
			if (dict.ContainsKey("SIDE"))
			{
				string text2;
				try
				{
					text2 = Conversions.ToString(dict["SIDE"]);
				}
				catch (Exception ex7)
				{
					ProjectData.SetProjectError(ex7);
					Exception ex8 = ex7;
					ex8?.Data.Add("Error at PM85", "");
					GameGeneral.WriteExceptionsToLog(ex8);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("side must be a string");
				}
				Side side;
				try
				{
					side = LuaUtility.QuerySide(dict, ScenarioContext);
				}
				catch (Exception ex9)
				{
					ProjectData.SetProjectError(ex9);
					Exception ex10 = ex9;
					ex10?.Data.Add("Error at PM86", "");
					GameGeneral.WriteExceptionsToLog(ex10);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("Can't find Side '" + text2 + "'");
				}
				try
				{
					activeUnit = side.Units.First([SpecialName] (ActiveUnit s) => string.Equals(s.Name, CS$<>8__locals7.$VB$Local_Name, StringComparison.OrdinalIgnoreCase) | string.Equals(s.ObjectID, CS$<>8__locals7.$VB$Local_Name, StringComparison.OrdinalIgnoreCase));
				}
				catch (Exception ex11)
				{
					ProjectData.SetProjectError(ex11);
					Exception ex12 = ex11;
					ex12?.Data.Add("Error at PM87", "");
					GameGeneral.WriteExceptionsToLog(ex12);
					int num;
					if (!Debugger.IsAttached)
					{
						num = 5;
					}
					else
					{
						Debugger.Break();
						num = 5;
					}
					string[] array = new string[num];
					array[0] = "Can't find Unit '";
					array[1] = CS$<>8__locals7.$VB$Local_Name;
					array[2] = "' on Side '";
					array[3] = text2;
					array[4] = "'";
					throw new LuaError(string.Concat(array));
				}
			}
			else
			{
				try
				{
					activeUnit = ScenarioContext.ActiveUnits_List.First([SpecialName] (ActiveUnit s) => string.Equals(s.Name, CS$<>8__locals7.$VB$Local_Name, StringComparison.OrdinalIgnoreCase) | string.Equals(s.ObjectID, CS$<>8__locals7.$VB$Local_Name, StringComparison.OrdinalIgnoreCase));
				}
				catch (Exception ex13)
				{
					ProjectData.SetProjectError(ex13);
					Exception ex14 = ex13;
					ex14?.Data.Add("Error at PM88", "");
					GameGeneral.WriteExceptionsToLog(ex14);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("Can't find Unit '" + CS$<>8__locals7.$VB$Local_Name + "'");
				}
			}
		}
		if (activeUnit == null)
		{
			throw new LuaError("Need to define a Name or Guid to identify a unit. Preferably a Guid or Side & Name.");
		}
		List<ActiveUnit> list = new List<ActiveUnit>();
		list.Add(activeUnit);
		if (activeUnit is Group)
		{
			foreach (KeyValuePair<string, ActiveUnit> unit in ((Group)activeUnit).Units)
			{
				list.Add(unit.Value);
			}
		}
		foreach (ActiveUnit item in list)
		{
			foreach (Aircraft item2 in item.AirOps.EmbarkedAircraft_ReadOnly.ToList())
			{
				ScenarioContext.DeleteUnitImmediately(item2.ObjectID, ScenEditAction: true, "Script action (clear all aircraft)", null, RegisterAsLosses: false);
			}
		}
	}

	public static LuaWrapper_Contact ScenEdit_GetContact(LuaTable table, Scenario ScenarioContext)
	{
		Dictionary<string, object> dict = LuaUtility.ToDictUpper(table.GetEnumerator());
		Contact contact = null;
		Side side = null;
		string text = null;
		LuaUtility.ParseUnitDict(ref dict);
		int num = default(int);
		if (dict.ContainsKey("GUID"))
		{
			try
			{
				text = Conversions.ToString(dict["GUID"]);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at PM89", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("guid must be a string");
			}
		}
		else if (dict.ContainsKey("UNITNAME"))
		{
			try
			{
				text = Conversions.ToString(dict["UNITNAME"]);
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				ex4?.Data.Add("Error at PM90", "");
				GameGeneral.WriteExceptionsToLog(ex4);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("name must be a string");
			}
		}
		else if (dict.ContainsKey("TRACKNUMBER"))
		{
			try
			{
				num = Conversions.ToInteger(dict["TRACKNUMBER"]);
			}
			catch (Exception ex5)
			{
				ProjectData.SetProjectError(ex5);
				Exception ex6 = ex5;
				ex6?.Data.Add("Error at PM349027349857", "");
				GameGeneral.WriteExceptionsToLog(ex6);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("tracknumber must be a number");
			}
		}
		if (dict.ContainsKey("SIDE"))
		{
			string text2;
			try
			{
				text2 = Conversions.ToString(dict["SIDE"]);
			}
			catch (Exception ex7)
			{
				ProjectData.SetProjectError(ex7);
				Exception ex8 = ex7;
				ex8?.Data.Add("Error at PM91", "");
				GameGeneral.WriteExceptionsToLog(ex8);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("side must be a string");
			}
			try
			{
				side = LuaUtility.QuerySide(dict, ScenarioContext);
			}
			catch (Exception ex9)
			{
				ProjectData.SetProjectError(ex9);
				Exception ex10 = ex9;
				ex10?.Data.Add("Error at PM92", "");
				GameGeneral.WriteExceptionsToLog(ex10);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("Can't find Side '" + text2 + "'");
			}
			if (side == null)
			{
				throw new LuaError("Can't find Side '" + text2 + "'");
			}
		}
		if (side != null)
		{
			contact = ValidateContactBySide(text, num, side);
			if (contact == null)
			{
				foreach (string key in side.NewContactsQueue.Keys)
				{
					Contact contact2 = side.NewContactsQueue[key];
					if ((num > 0 && contact2.AutoIncrement == num) || string.Equals(contact2.Name, text, StringComparison.OrdinalIgnoreCase) || string.Equals(contact2.ObjectID, text, StringComparison.OrdinalIgnoreCase))
					{
						contact = contact2;
						break;
					}
				}
				if (contact == null)
				{
					foreach (string key2 in side.NewBaseContactsQueue.Keys)
					{
						Contact contact3 = side.NewBaseContactsQueue[key2];
						if ((num > 0 && contact3.AutoIncrement == num) || string.Equals(contact3.Name, text, StringComparison.OrdinalIgnoreCase) || string.Equals(contact3.ObjectID, text, StringComparison.OrdinalIgnoreCase))
						{
							contact = contact3;
							break;
						}
					}
				}
			}
			if (contact == null)
			{
				throw new LuaError("Need to define a Side and Guid to identify a contact '" + text + "'");
			}
			return new LuaWrapper_Contact(contact, ScenarioContext, side);
		}
		throw new LuaError("Can't find Side ");
	}

	public static LuaWrapper_ActiveUnit_SE ScenEdit_SetUnit(LuaTable table, Scenario ScenarioContext)
	{
		Dictionary<string, object> dict = LuaUtility.ToDictUpper(table.GetEnumerator());
		ActiveUnit value = null;
		Side side = null;
		string Results = null;
		bool flag = false;
		LuaUtility.ParseUnitDict(ref dict);
		if (dict.ContainsKey("GUID"))
		{
			string text;
			try
			{
				text = Conversions.ToString(dict["GUID"]);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at PM93", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("guid must be a string");
			}
			if (!ScenarioContext.ActiveUnits.TryGetValue(text, out value))
			{
				throw new LuaError("Can't find guid " + text);
			}
			dict["SIDE"] = value.get_UnitSide(SetSideOnly: false).Name;
			dict["UNITNAME"] = value.Name;
		}
		else if (dict.ContainsKey("UNITNAME"))
		{
			_Closure$__150-0 arg = default(_Closure$__150-0);
			_Closure$__150-0 CS$<>8__locals7 = new _Closure$__150-0(arg);
			try
			{
				CS$<>8__locals7.$VB$Local_Name = Conversions.ToString(dict["UNITNAME"]);
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				ex4?.Data.Add("Error at PM95", "");
				GameGeneral.WriteExceptionsToLog(ex4);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("name must be a string");
			}
			if (dict.ContainsKey("SIDE"))
			{
				string text2;
				try
				{
					text2 = Conversions.ToString(dict["SIDE"]);
				}
				catch (Exception ex5)
				{
					ProjectData.SetProjectError(ex5);
					Exception ex6 = ex5;
					ex6?.Data.Add("Error at PM96", "");
					GameGeneral.WriteExceptionsToLog(ex6);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("side must be a string");
				}
				try
				{
					side = LuaUtility.QuerySide(dict, ScenarioContext);
				}
				catch (Exception ex7)
				{
					ProjectData.SetProjectError(ex7);
					Exception ex8 = ex7;
					ex8?.Data.Add("Error at PM97", "");
					GameGeneral.WriteExceptionsToLog(ex8);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("Can't find Side '" + text2 + "'");
				}
				try
				{
					value = side.Units.FirstOrDefault([SpecialName] (ActiveUnit s) => string.Equals(s.Name, CS$<>8__locals7.$VB$Local_Name, StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, CS$<>8__locals7.$VB$Local_Name, StringComparison.OrdinalIgnoreCase));
					if (value == null)
					{
						throw new Exception();
					}
				}
				catch (Exception ex9)
				{
					ProjectData.SetProjectError(ex9);
					Exception ex10 = ex9;
					ex10?.Data.Add("Error at PM98", "");
					GameGeneral.WriteExceptionsToLog(ex10);
					int num;
					if (!Debugger.IsAttached)
					{
						num = 5;
					}
					else
					{
						Debugger.Break();
						num = 5;
					}
					string[] array = new string[num];
					array[0] = "Can't find Unit '";
					array[1] = CS$<>8__locals7.$VB$Local_Name;
					array[2] = "' on Side '";
					array[3] = text2;
					array[4] = "'";
					throw new LuaError(string.Concat(array));
				}
				dict["GUID"] = value.ObjectID;
			}
			else
			{
				try
				{
					value = ScenarioContext.ActiveUnits_List.FirstOrDefault([SpecialName] (ActiveUnit s) => string.Equals(s.Name, CS$<>8__locals7.$VB$Local_Name, StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, CS$<>8__locals7.$VB$Local_Name, StringComparison.OrdinalIgnoreCase));
				}
				catch (Exception ex11)
				{
					ProjectData.SetProjectError(ex11);
					Exception ex12 = ex11;
					ex12?.Data.Add("Error at PM99", "");
					GameGeneral.WriteExceptionsToLog(ex12);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("Can't find Unit '" + CS$<>8__locals7.$VB$Local_Name + "'");
				}
				if (value == null)
				{
					throw new LuaError("Need to define a Name or Guid to identify a unit. Preferably a Guid or Side & Name.");
				}
				dict["GUID"] = value.ObjectID;
				dict["SIDE"] = value.get_UnitSide(SetSideOnly: false).Name;
			}
		}
		if (value != null)
		{
			if (side == null)
			{
				side = LuaUtility.QuerySide(dict, ScenarioContext);
			}
			dict["TYPE"] = value.UnitType.ToString();
			if (dict.ContainsKey("NEWNAME"))
			{
				string text3 = Conversions.ToString(dict["NEWNAME"]);
				if (Operators.CompareString(value.Name, text3, false) != 0)
				{
					value.Name = text3;
				}
			}
			if (!value.IsGroup)
			{
				if (!dict.ContainsKey("GROUP"))
				{
					if (value.get_ParentGroup(UsingMissionPlanner: false) != null)
					{
						dict["GROUP"] = value.get_ParentGroup(UsingMissionPlanner: false).Name;
					}
				}
				else
				{
					Group obj = LuaUtility.QueryGroup(dict, side, ScenarioContext);
					if (obj == null)
					{
						List<ActiveUnit> list = new List<ActiveUnit>();
						list.Add(value);
						ActiveUnit activeUnit;
						Side theSide = (activeUnit = value).get_UnitSide(SetSideOnly: false);
						Group obj2 = new Group(ref ScenarioContext, ref theSide, list);
						activeUnit.set_UnitSide(SetSideOnly: false, theSide);
						obj = obj2;
						obj.Name = Conversions.ToString(dict["GROUP"]);
						value.set_ParentGroup(UsingMissionPlanner: false, obj);
					}
					else if (obj != value.get_ParentGroup(UsingMissionPlanner: false))
					{
						value.set_ParentGroup(UsingMissionPlanner: false, obj);
					}
				}
			}
			if (!dict.ContainsKey("MISSION"))
			{
				if (value.ActiveMissionOrPackage() != null)
				{
					dict["MISSION"] = value.ActiveMissionOrPackage().Name;
				}
			}
			else
			{
				object objectValue = RuntimeHelpers.GetObjectValue(dict["MISSION"]);
				if (objectValue is string)
				{
					try
					{
						ScenEdit_AssignUnitToMission(value.ObjectID, Conversions.ToString(objectValue), ScenarioContext, null, Escort: false, MissionPlanner: false);
					}
					catch (Exception ex13)
					{
						ProjectData.SetProjectError(ex13);
						Exception ex14 = ex13;
						ex14?.Data.Add("Error at PM100", "");
						GameGeneral.WriteExceptionsToLog(ex14);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						throw new LuaError(ex14.GetType().Name + " " + ex14.Message);
					}
				}
			}
			if (dict.ContainsKey("COURSE"))
			{
				LuaTable obj3 = (LuaTable)dict["COURSE"];
				value.Navigator.ClearPlottedCourse();
				List<object> list2 = LuaUtility.ToArray(obj3.GetEnumerator());
				foreach (object item in list2)
				{
					object objectValue2 = RuntimeHelpers.GetObjectValue(item);
					if (objectValue2 is LuaTable)
					{
						Waypoint theWP = new Waypoint(0.0, 0.0, 0f, Waypoint.WaypointType.ManualPlottedCourseWaypoint, Waypoint.WaypointCreator.Manual, Waypoint.WaypointCategory.PlottedCourse);
						if (LuaWrapper_Waypoint.FromTable((LuaTable)objectValue2, theWP, ScenarioContext))
						{
							Dictionary<string, object> dict2 = LuaUtility.ToDictUpper(((LuaTable)objectValue2).GetEnumerator());
							double? num2 = LuaUtility.QueryLongitude(dict2);
							LuaUtility.QueryLatitude(dict2);
							if (!num2.HasValue | !num2.HasValue)
							{
								throw new LuaError("Course object " + LuaUtility.LuaInterpret(RuntimeHelpers.GetObjectValue(objectValue2)) + " needs latitude or longitude.");
							}
						}
						value.Navigator.AddWaypoint(theWP);
						continue;
					}
					throw new LuaError("Error at " + LuaUtility.LuaInterpret(RuntimeHelpers.GetObjectValue(objectValue2)) + " in ScenEdit_SetUnit.");
				}
			}
			if (dict.ContainsKey("SPEED") & dict.ContainsKey("THROTTLE"))
			{
				throw new LuaError("Use either SPEED or THROTTLE.");
			}
			if (dict.ContainsKey("FORCESPEED"))
			{
				flag = Conversions.ToBoolean(dict["FORCESPEED"]);
			}
			if (dict.ContainsKey("SPEED"))
			{
				float num3 = Conversions.ToSingle(dict["SPEED"]);
				if (!(num3 > value.MaxSpeed && !flag))
				{
					if (num3 < 0f)
					{
						num3 = 0f;
					}
					else if (flag)
					{
						value.SetThrottle(ActiveUnit.Throttle.External);
					}
				}
				else
				{
					num3 = value.MaxSpeed;
				}
				value.CurrentSpeed = num3;
			}
			else
			{
				dict["SPEED"] = value.CurrentSpeed;
			}
			if (dict.ContainsKey("THROTTLE"))
			{
				ActiveUnit.Throttle? throttle = LuaUtility.QueryThrottle(dict);
				byte? b = (byte?)throttle;
				byte maxPossibleThrottleSetting = (byte)value.MaxPossibleThrottleSetting;
				if (((!b.HasValue) ? ((bool?)null) : new bool?((uint)b.GetValueOrDefault() > (uint)maxPossibleThrottleSetting)) == true)
				{
					throttle = value.MaxPossibleThrottleSetting;
				}
				else
				{
					b = (byte?)throttle;
					maxPossibleThrottleSetting = (byte)value.MinPossibleThrottleSetting;
					if (((!b.HasValue) ? ((bool?)null) : new bool?((uint)b.GetValueOrDefault() < (uint)maxPossibleThrottleSetting)) == true)
					{
						throttle = value.MinPossibleThrottleSetting;
					}
				}
				value.SetThrottle(throttle.Value);
			}
			else
			{
				dict["THROTTLE"] = value.ThrottleSetting;
			}
			if (dict.ContainsKey("LAUNCH"))
			{
				if (LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(dict["LAUNCH"])) != true)
				{
					if (!value.IsAircraft)
					{
						if (value.DockingOps != null && value.DockingOps.IsDeploying)
						{
							value.DockingOps.AttemptToStartDocking(value.DockingOps.CurrentHostUnit, CancelDeployment: true);
						}
					}
					else if (value.AirOps != null)
					{
						Aircraft aircraft = (Aircraft)value;
						if (aircraft.AirOps.IsTakingOff)
						{
							aircraft.AirOps.AttemptToPark(NormalLandingSequence: true, RearmRefuel: false, AbortLaunch: true);
							if (aircraft.Navigator.HasFlight)
							{
								((ActiveUnit_Navigator)aircraft.Navigator).get_Flight(HierarchySearch: true).set_Status(ScenarioContext, Mission._FlightStatus.None);
							}
						}
					}
				}
				else if (!value.IsAircraft)
				{
					if (value.DockingOps != null && value.IsParkedAndReady())
					{
						value.DockingOps.Condition = ActiveUnit_DockingOps._DockingOpsCondition.DeployingUnderway;
					}
				}
				else
				{
					Aircraft aircraft2 = (Aircraft)value;
					if (value.AirOps != null && aircraft2.IsReadyForTakeOff())
					{
						aircraft2.AirOps.AttemptToMoveToRunway(ActualAirlaunchPreparation: true);
					}
				}
			}
			if (dict.ContainsKey("RTB"))
			{
				if (LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(dict["RTB"])) == true)
				{
					if (value.IsAircraft)
					{
						if (!GlobalVariables.AI_REWORK)
						{
							((Aircraft)value).AirOps.AttemptToRTB(ManuallyOrdered: false, ActiveUnit._ActiveUnitStatus.RTB_Manual, GroupMembersRTB: false, ActiveUnit._ActiveUnitStatus.Unassigned, DetachFromGroup: true, ClearPlottedCourse: true);
						}
						else
						{
							((Aircraft)value).AI.StatusRelatedEvents.method_0(manuallyOrdered: false, ActiveUnit._ActiveUnitStatus.RTB_Manual, groupMembersRTB: false, ActiveUnit._ActiveUnitStatus.Unassigned, detachFromGroup: true, clearPlottedCourse: true);
						}
					}
					else
					{
						value.DockingOps.AttemptToRTB(ManuallyOrdered: false, ActiveUnit._ActiveUnitStatus.RTB_Manual, GroupMembersRTB: false, ActiveUnit._ActiveUnitStatus.Unassigned, DetachFromGroup: true, ClearPlottedCourse: true);
					}
				}
				else
				{
					value.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
				}
			}
			if (dict.ContainsKey("JETTISON"))
			{
				if (!value.IsAircraft)
				{
					throw new LuaError("Unit is not an aircraft and cannot jettison ordnance.");
				}
				Aircraft aircraft3 = (Aircraft)value;
				string text4 = dict["JETTISON"].ToString().ToUpper();
				if (Strings.Len(text4) > 6 && Operators.CompareString(Strings.Left(text4, 6), "STORE_", false) == 0)
				{
					int int_ = Conversions.ToInteger(Strings.Mid(text4, 7));
					aircraft3.Weaponry.JettisonSpecificOrdnance(ExecuteImmediately: true, int_);
				}
				else
				{
					switch (text4)
					{
					case "HEAVYONLY":
						aircraft3.Weaponry.JettisonOrdnance(ExecuteImmediately: true, JettisonDropTanks: true, JettisonUnguidedAG: true, JettisonGuidedAG: true, bool_12: false, JettisonPod: false, JettisonInternalWeapons: false);
						break;
					case "ALLEXTERNAL":
						aircraft3.Weaponry.JettisonOrdnance(ExecuteImmediately: true, JettisonDropTanks: true, JettisonUnguidedAG: true, JettisonGuidedAG: true, bool_12: true, JettisonPod: true, JettisonInternalWeapons: false);
						break;
					default:
						throw new LuaError("Unrecognized value for 'jettison.' Valid values are \"HeavyOnly\", \"WeaponsOnly\", \"AllExternal\", \"All\", or  \"store_<dbid>\"");
					case "ALL":
						aircraft3.Weaponry.JettisonOrdnance(ExecuteImmediately: true, JettisonDropTanks: true, JettisonUnguidedAG: true, JettisonGuidedAG: true, bool_12: true, JettisonPod: true, JettisonInternalWeapons: true);
						break;
					case "WEAPONSONLY":
						aircraft3.Weaponry.JettisonOrdnance(ExecuteImmediately: true, JettisonDropTanks: false, JettisonUnguidedAG: true, JettisonGuidedAG: true, bool_12: true, JettisonPod: false, JettisonInternalWeapons: false);
						break;
					}
				}
			}
			if (dict.ContainsKey("REFUEL") && LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(dict["REFUEL"])) == true && value != null && value.IsActiveUnit && (value.get_UnitSide(SetSideOnly: false) == side || Module_Side.IsAlliedWithThisSide(value.get_UnitSide(SetSideOnly: false), side)) && (object)value.GetType() != typeof(Weapon))
			{
				Scenario theScen = ScenarioContext;
				ActiveUnit theUnit = value;
				string ResultCategory = null;
				CoreClientCode.RefuelIfPossible_Core(theScen, (Module_Unit.Unit)theUnit, (ActiveUnit)null, (Mission)null, ref Results, ref ResultCategory);
			}
			if (dict.ContainsKey("UNASSIGN") && LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(dict["UNASSIGN"])) == true && !Information.IsNothing((object)value) && value.IsActiveUnit)
			{
				ActiveUnit activeUnit2 = value;
				Mission.MissionAssignmentAttemptResult Result = Mission.MissionAssignmentAttemptResult.None;
				activeUnit2.Set_AssignedMissionOrPackage(null, SetMissionOnly: false, IgnoreCommsState: false, ref Result);
			}
			dict["DBID"] = value.DBID;
			bool? flag2 = false;
			if (dict.ContainsKey("MOVETO"))
			{
				flag2 = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(dict["MOVETO"]));
			}
			switch (value.UnitType)
			{
			case GlobalVariables.ActiveUnitType.Submarine:
			{
				float? num5 = LuaUtility.QueryDepth(dict);
				if (!num5.HasValue)
				{
					dict["DEPTH"] = value.get_CurrentAltitude(DoSanityCheck: true, (GlobalVariables.BooleanObject)null);
					break;
				}
				float num6 = (int)Math.Round(num5.Value);
				if (num6 > 0f && num6 <= 6f)
				{
					float num7 = num6;
					float num8 = default(float);
					if (num7 == 6f)
					{
						num8 = 0f;
					}
					else if (num7 == 1f)
					{
						num8 = -20f;
					}
					else if (num7 == 2f)
					{
						num8 = -40f;
					}
					else if (num7 == 3f)
					{
						num8 = Submarine_AI.OverLayerDepth(value);
					}
					else if (num7 == 4f)
					{
						num8 = Submarine_AI.UnderLayerDepth(value);
					}
					else if (num7 == 5f)
					{
						num8 = value.Kinematics.GetMinimumAltitude();
					}
					num6 = num8;
				}
				if (num6 < value.Kinematics.GetMinimumAltitude())
				{
					num6 = value.Kinematics.GetMinimumAltitude();
				}
				if (num6 > 0f)
				{
					num6 = 0f;
				}
				if (flag2 == true)
				{
					value.DesiredAltitude = (short)Math.Round(num6);
				}
				else
				{
					value.set_CurrentAltitude(DoSanityCheck: true, (GlobalVariables.BooleanObject)null, (float)(short)Math.Round(num6));
				}
				break;
			}
			case GlobalVariables.ActiveUnitType.Aircraft:
			{
				dict["LOADOUTID"] = ((Aircraft)value).LoadoutDBID;
				dict["LOADOUTNAME"] = ((Aircraft)value).LoadoutName;
				object obj4 = LuaUtility.QueryAltitude(dict);
				if ((object)obj4?.GetType() == typeof(ActiveUnit_AI.AircraftAltitudePreset))
				{
					float num4 = ActiveUnit_AI.ConvertAltitudePresetToValue((ActiveUnit_AI.AircraftAltitudePreset)Conversions.ToByte(obj4));
					if (num4 < value.Kinematics.GetMinimumAltitude())
					{
						num4 = value.Kinematics.GetMinimumAltitude();
					}
					if (num4 > value.Kinematics.GetMaximumAltitude())
					{
						num4 = value.Kinematics.GetMaximumAltitude();
					}
					if (flag2 != true)
					{
						value.set_CurrentAltitude(DoSanityCheck: true, (GlobalVariables.BooleanObject)null, (float)(short)Math.Round(num4));
					}
					else
					{
						value.DesiredAltitude = (short)Math.Round(num4);
					}
				}
				else
				{
					dict["ALTITUDE"] = value.get_CurrentAltitude(DoSanityCheck: true, (GlobalVariables.BooleanObject)null);
				}
				break;
			}
			}
			if (!dict.ContainsKey("HEADING"))
			{
				dict["HEADING"] = value.CurrentHeading;
			}
			else
			{
				float currentHeading = Conversions.ToSingle(dict["HEADING"]);
				value.CurrentHeading = currentHeading;
				value.set_DesiredHeading(value.DesiredTurnRate, value.CurrentHeading);
			}
			if (!dict.ContainsKey("DESIREDHEADING"))
			{
				dict["DESIREDHEADING"] = value.DesiredHeading;
			}
			else
			{
				float value2 = Conversions.ToSingle(dict["DESIREDHEADING"]);
				value.set_DesiredHeading(ActiveUnit.TurnRate.Max, value2);
			}
			double? num9 = LuaUtility.QueryLatitude(dict);
			if (num9.HasValue)
			{
				value.set_Latitude((GlobalVariables.BooleanObject)null, num9.Value);
			}
			else
			{
				dict["LONGITUDE"] = value.get_Longitude((GlobalVariables.BooleanObject)null);
			}
			double? num10 = LuaUtility.QueryLongitude(dict);
			if (num10.HasValue)
			{
				value.set_Longitude((GlobalVariables.BooleanObject)null, num10.Value);
			}
			else
			{
				dict["LONGITUDE"] = value.get_Longitude((GlobalVariables.BooleanObject)null);
			}
			if (dict.ContainsKey("AUTODETECTABLE"))
			{
				bool? flag3 = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(dict["AUTODETECTABLE"]));
				if (flag3.HasValue)
				{
					if (flag3.Value)
					{
						if (!value.get_IsAutoDetectable((Side)null))
						{
							value.set_IsAutoDetectable((Side)null, value: true);
							value.get_UnitSide(SetSideOnly: false).ProcessAutoDetectableUnits(ScenarioContext, ScenarioContext.GameResolution);
						}
					}
					else
					{
						value.set_IsAutoDetectable((Side)null, value: false);
					}
				}
			}
			if (ScenarioContext.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.CommsDisruption) && dict.ContainsKey("OUTOFCOMMS"))
			{
				bool? flag4 = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(dict["OUTOFCOMMS"]));
				if (flag4.HasValue)
				{
					if (!flag4.Value)
					{
						value.CommStuff.set_IsConnectedToSideNetwork(ActiveUnit_CommStuff.ReasonForGoingOffGrid.None, value: true);
					}
					else
					{
						value.CommStuff.set_IsConnectedToSideNetwork(ActiveUnit_CommStuff.ReasonForGoingOffGrid.ChangeOfInternalStatus, value: false);
					}
				}
			}
			if (dict.ContainsKey("HOLDPOSITION"))
			{
				bool? flag5 = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(dict["HOLDPOSITION"]));
				if (flag5.HasValue)
				{
					value.AI.HoldPosition = flag5.Value;
				}
			}
			if (dict.ContainsKey("HOLDFIRE"))
			{
				bool? flag6 = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(dict["HOLDFIRE"]));
				if (flag6.HasValue)
				{
					if (flag6 != true)
					{
						value.Doctrine.set_WeaponControlStatus_Air(ScenarioContext, MultipleUnits: false, (bool?)false, ViaDoctrineForm: false, ViaRightColumn: false, (Doctrine._WCS?)Doctrine._WCS.Tight);
						value.Doctrine.set_WeaponControlStatus_Surface(ScenarioContext, MultipleUnits: false, (bool?)false, ViaDoctrineForm: false, ViaRightColumn: false, (Doctrine._WCS?)Doctrine._WCS.Tight);
						value.Doctrine.set_WeaponControlStatus_Submarine(ScenarioContext, MultipleUnits: false, (bool?)false, ViaDoctrineForm: false, ViaRightColumn: false, (Doctrine._WCS?)Doctrine._WCS.Tight);
						value.Doctrine.set_WeaponControlStatus_Land(ScenarioContext, MultipleUnits: false, (bool?)false, ViaDoctrineForm: false, ViaRightColumn: false, (Doctrine._WCS?)Doctrine._WCS.Tight);
					}
					else
					{
						value.Doctrine.set_WeaponControlStatus_Air(ScenarioContext, MultipleUnits: false, (bool?)false, ViaDoctrineForm: false, ViaRightColumn: false, (Doctrine._WCS?)Doctrine._WCS.Hold);
						value.Doctrine.set_WeaponControlStatus_Surface(ScenarioContext, MultipleUnits: false, (bool?)false, ViaDoctrineForm: false, ViaRightColumn: false, (Doctrine._WCS?)Doctrine._WCS.Hold);
						value.Doctrine.set_WeaponControlStatus_Submarine(ScenarioContext, MultipleUnits: false, (bool?)false, ViaDoctrineForm: false, ViaRightColumn: false, (Doctrine._WCS?)Doctrine._WCS.Hold);
						value.Doctrine.set_WeaponControlStatus_Land(ScenarioContext, MultipleUnits: false, (bool?)false, ViaDoctrineForm: false, ViaRightColumn: false, (Doctrine._WCS?)Doctrine._WCS.Hold);
					}
				}
			}
			if (dict.ContainsKey("PROFICIENCY"))
			{
				string text5 = Conversions.ToString(dict["PROFICIENCY"]);
				if (!(Enum.TryParse<GlobalVariables.ProficiencyLevel>(text5, ignoreCase: true, out var result) & Enum.IsDefined(typeof(GlobalVariables.ProficiencyLevel), result)))
				{
					text5 = text5.ToUpperInvariant();
					switch (text5)
					{
					case "REGULAR":
						value.Proficiency = GlobalVariables.ProficiencyLevel.Regular;
						break;
					case "ACE":
						value.Proficiency = GlobalVariables.ProficiencyLevel.Ace;
						break;
					default:
						throw new LuaError("Unable to understand '" + text5 + "' as a Proficiency Level");
					case "VETERAN":
						value.Proficiency = GlobalVariables.ProficiencyLevel.Veteran;
						break;
					case "CADET":
						value.Proficiency = GlobalVariables.ProficiencyLevel.Cadet;
						break;
					case "NOVICE":
						value.Proficiency = GlobalVariables.ProficiencyLevel.Novice;
						break;
					}
				}
				else
				{
					value.Proficiency = result;
				}
			}
			if (dict.ContainsKey("MANUALTHROTTLE"))
			{
				float num11 = 0f;
				switch (Conversions.ToString(dict["MANUALTHROTTLE"]).ToUpperInvariant())
				{
				case "DESIRED":
					num11 = value.DesiredSpeed;
					value.Kinematics.DesiredSpeedOverride = num11;
					break;
				case "OFF":
					value.Kinematics.DesiredSpeedOverride = null;
					break;
				default:
				{
					string value3 = Conversions.ToString(dict["MANUALTHROTTLE"]);
					if (Enum.TryParse<ActiveUnit_Kinematics.UnitThrottlePreset>(value3, ignoreCase: true, out var result2) && Enum.IsDefined(typeof(ActiveUnit_Kinematics.UnitThrottlePreset), result2))
					{
						value.Kinematics.ThrottlePreset = result2;
						value.Kinematics.DesiredSpeedOverride = value.Kinematics.GetMaximumSpeed(value.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), (ActiveUnit.Throttle)value.Kinematics.ThrottlePreset, ValidateAndFixAltitude: false);
					}
					break;
				}
				case "CURRENT":
					num11 = value.CurrentSpeed;
					value.Kinematics.DesiredSpeedOverride = num11;
					break;
				}
			}
			if (dict.ContainsKey("MANUALSPEED"))
			{
				float num12 = 0f;
				switch (Conversions.ToString(dict["MANUALSPEED"]).ToUpperInvariant())
				{
				case "CURRENT":
					num12 = value.CurrentSpeed;
					value.Kinematics.DesiredSpeedOverride = num12;
					break;
				case "DESIRED":
					num12 = value.DesiredSpeed;
					value.Kinematics.DesiredSpeedOverride = num12;
					break;
				default:
				{
					float? num13 = null;
					try
					{
						num13 = float.Parse(Conversions.ToString(dict["MANUALSPEED"]));
					}
					catch (Exception ex15)
					{
						ProjectData.SetProjectError(ex15);
						Exception ex16 = ex15;
						ex16?.Data.Add("Error at PM101", "");
						GameGeneral.WriteExceptionsToLog(ex16);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
					if (num13.HasValue)
					{
						value.Kinematics.DesiredSpeedOverride = num13.Value;
						value.Kinematics.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.None;
					}
					break;
				}
				case "OFF":
					value.Kinematics.DesiredSpeedOverride = null;
					break;
				}
				float? desiredSpeedOverride = value.Kinematics.DesiredSpeedOverride;
				if (desiredSpeedOverride.HasValue)
				{
					if (value.IsGroup && ((Group)value).GroupLead != null)
					{
						ActiveUnit groupLead = ((Group)value).GroupLead;
						groupLead.SetThrottle(groupLead.Kinematics.GetThrottleSuitableForThisSpeed(value.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), desiredSpeedOverride.Value));
						value.ThrottleSetting = groupLead.ThrottleSetting;
						float? num14 = desiredSpeedOverride;
						float num15 = groupLead.Kinematics.GetMaximumSpeed(groupLead.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), groupLead.ThrottleSetting, ValidateAndFixAltitude: false);
						if ((num14.HasValue ? new bool?(num14.GetValueOrDefault() > num15) : ((bool?)null)) == true)
						{
							value.Kinematics.DesiredSpeedOverride = groupLead.Kinematics.GetMaximumSpeed(groupLead.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), groupLead.ThrottleSetting, ValidateAndFixAltitude: false);
						}
					}
					else
					{
						value.SetThrottle(value.Kinematics.GetThrottleSuitableForThisSpeed(value.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), desiredSpeedOverride.Value));
						float? num14 = desiredSpeedOverride;
						float num15 = value.Kinematics.GetMaximumSpeed(value.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), value.ThrottleSetting, ValidateAndFixAltitude: false);
						if ((num14.HasValue ? new bool?(num14.GetValueOrDefault() > num15) : ((bool?)null)) == true)
						{
							value.Kinematics.DesiredSpeedOverride = value.Kinematics.GetMaximumSpeed(value.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), value.ThrottleSetting, ValidateAndFixAltitude: false);
						}
					}
				}
			}
			if (dict.ContainsKey("MANUALALTITUDE"))
			{
				switch (Conversions.ToString(dict["MANUALALTITUDE"]).ToUpperInvariant())
				{
				case "DESIRED":
					_ = value.DesiredAltitude;
					value.Kinematics.DesiredAltitudeOverride = true;
					break;
				default:
				{
					if (value.IsSubmarine)
					{
						ActiveUnit_AI.SubmarineDepthPreset? submarineDepthPreset = LuaUtility.QueryDepthPresetObject(Conversions.ToString(dict["MANUALALTITUDE"]));
						if (submarineDepthPreset.HasValue)
						{
							((Submarine)value).AI.DepthPreset = submarineDepthPreset.Value;
							((Submarine)value).AI.FollowDepthPreset(CheckThreats: false);
							value.Kinematics.DesiredAltitudeOverride = true;
						}
						else
						{
							float? num16 = LuaUtility.QueryDepthObject(Conversions.ToString(dict["MANUALALTITUDE"]));
							value.DesiredAltitude = num16.Value;
							((Submarine)value).AI.DepthPreset = ActiveUnit_AI.SubmarineDepthPreset.None;
							value.Kinematics.DesiredAltitudeOverride = true;
						}
						break;
					}
					if (!value.IsAircraft)
					{
						float result3 = 0f;
						if (!float.TryParse(Conversions.ToString(dict["MANUALALTITUDE"]), out result3))
						{
							break;
						}
						value.DesiredAltitude = result3;
						value.Kinematics.DesiredAltitudeOverride = true;
						if (!value.IsSubmarine)
						{
							if (value.IsAircraft)
							{
								((Aircraft)value).AI.AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.None;
							}
						}
						else
						{
							((Submarine)value).AI.DepthPreset = ActiveUnit_AI.SubmarineDepthPreset.None;
						}
						break;
					}
					ActiveUnit_AI.AircraftAltitudePreset? aircraftAltitudePreset = LuaUtility.QueryAltitudePresetObject(Conversions.ToString(dict["MANUALALTITUDE"]));
					if (!aircraftAltitudePreset.HasValue)
					{
						string altitudeObject = Conversions.ToString(dict["MANUALALTITUDE"]);
						ActiveUnit_AI.AircraftAltitudePreset? AltitudePreset = null;
						object obj5 = LuaUtility.QueryAltitudeObject(altitudeObject, ref AltitudePreset);
						if (obj5 != null && (object)obj5.GetType() == typeof(float))
						{
							value.DesiredAltitude = Conversions.ToSingle(obj5);
							((Aircraft)value).AI.AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.None;
							value.Kinematics.DesiredAltitudeOverride = true;
						}
					}
					else
					{
						((Aircraft)value).AI.AltitudePreset = aircraftAltitudePreset.Value;
						((Aircraft)value).AI.FollowAltitudePreset();
						value.Kinematics.DesiredAltitudeOverride = true;
					}
					break;
				}
				case "OFF":
					value.Kinematics.DesiredAltitudeOverride = false;
					break;
				case "CURRENT":
					value.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
					value.Kinematics.DesiredAltitudeOverride = true;
					break;
				}
			}
			if (dict.ContainsKey("FUEL"))
			{
				List<object> list3 = LuaUtility.ToArray(((LuaTable)dict["FUEL"]).GetEnumerator());
				try
				{
					_Closure$__150-1 closure$__150- = default(_Closure$__150-1);
					foreach (object item2 in list3)
					{
						object objectValue3 = RuntimeHelpers.GetObjectValue(item2);
						if (!(objectValue3 is LuaTable))
						{
							continue;
						}
						Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(((LuaTable)objectValue3).GetEnumerator());
						if (dictionary.ContainsKey("1") & dictionary.ContainsKey("2"))
						{
							string value4 = Conversions.ToString(dictionary["1"]);
							int result4 = int.MaxValue;
							if (int.TryParse(Conversions.ToString(dictionary["2"]), out result4))
							{
								closure$__150- = new _Closure$__150-1(closure$__150-);
								if (Enum.TryParse<FuelRec._FuelType>(value4, ignoreCase: true, out closure$__150-.$VB$Local_e) & Enum.IsDefined(typeof(FuelRec._FuelType), closure$__150-.$VB$Local_e))
								{
									if (value.Fuel_ReadOnly.FirstOrDefault(closure$__150-._Lambda$__2) != null)
									{
										int num17 = result4;
										if (value.IsAircraft)
										{
											((Aircraft)value).FuelCapacitySet(num17);
											continue;
										}
										foreach (FuelRec item3 in value.Fuel_ReadOnly)
										{
											if (item3.FuelType == closure$__150-.$VB$Local_e)
											{
												int val = Math.Min(item3.MaxQuantity, num17);
												val = Math.Max(0, val);
												item3.CurrentQuantity = val;
												num17 -= val;
											}
										}
										continue;
									}
									throw new LuaError("Missing fuel type at " + LuaUtility.LuaInterpret(RuntimeHelpers.GetObjectValue(objectValue3)) + " in ScenEdit_SetUnit.");
								}
								throw new LuaError("Error in fuel type at " + LuaUtility.LuaInterpret(RuntimeHelpers.GetObjectValue(objectValue3)) + " in ScenEdit_SetUnit.");
							}
							throw new LuaError("Error in amount at " + LuaUtility.LuaInterpret(RuntimeHelpers.GetObjectValue(objectValue3)) + " in ScenEdit_SetUnit.");
						}
						throw new LuaError("Error at " + LuaUtility.LuaInterpret(RuntimeHelpers.GetObjectValue(objectValue3)) + " in ScenEdit_SetUnit.");
					}
				}
				catch (Exception ex17)
				{
					ProjectData.SetProjectError(ex17);
					Exception ex18 = ex17;
					ex18?.Data.Add("Error at PM102", "");
					GameGeneral.WriteExceptionsToLog(ex18);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw;
				}
			}
			if (dict.ContainsKey("BASE"))
			{
				string text6 = Conversions.ToString(dict["BASE"]);
				ActiveUnit activeUnit3 = null;
				if (Operators.CompareString(text6, "", false) != 0)
				{
					activeUnit3 = smethod_1(text6, ScenarioContext);
				}
				if (activeUnit3 == null)
				{
					if (activeUnit3 == null && Operators.CompareString(text6, "", false) == 0)
					{
						if (!value.IsAircraft)
						{
							if (value.DockingOps != null)
							{
								value.DockingOps.PickNewAssignedHost_Nearest();
							}
						}
						else if (value.AirOps != null)
						{
							((Aircraft_AirOps)value.AirOps).PickNewAssignedHost_Nearest();
						}
					}
				}
				else if (value.IsAircraft)
				{
					if (value.AirOps != null)
					{
						Aircraft_AirOps aircraft_AirOps = (Aircraft_AirOps)value.AirOps;
						if (aircraft_AirOps.ThisUnitCanHostMe(activeUnit3, HumanFeedbackNeeded: false).ResponseBoolean)
						{
							aircraft_AirOps.set_AssignedHostUnit(PickNewAssignedHost: false, activeUnit3);
						}
					}
				}
				else if (value.DockingOps != null)
				{
					ActiveUnit_DockingOps dockingOps = value.DockingOps;
					if (dockingOps.ThisUnitCanHostMe(activeUnit3, HumanFeedBackNeeded: false).ResponseBoolean)
					{
						dockingOps.set_AssignedHostUnit(PickNewAssignedHost: false, activeUnit3);
					}
				}
			}
			if (dict.ContainsKey("SPRINTDRIFT"))
			{
				bool? flag7 = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(dict["SPRINTDRIFT"]));
				if (!flag7.HasValue)
				{
					dict.Remove("SPRINTDRIFT");
				}
				else
				{
					value.Navigator.SprintDrift = flag7.Value;
				}
			}
			if (dict.ContainsKey("AVOIDCAVITATION"))
			{
				bool? flag8 = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(dict["AVOIDCAVITATION"]));
				if (!flag8.HasValue)
				{
					dict.Remove("AVOIDCAVITATION");
				}
				else
				{
					if (value.IsGroup && ((Group)value).Units.Count > 0)
					{
						foreach (ActiveUnit value5 in ((Group)value).Units.Values)
						{
							value5.Navigator.AvoidCavitation = flag8.Value;
						}
					}
					value.Navigator.AvoidCavitation = flag8.Value;
				}
			}
			if (dict.ContainsKey("CSAR"))
			{
				bool? flag9 = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(dict["CSAR"]));
				if (!flag9.HasValue)
				{
					dict.Remove("CSAR");
				}
				else
				{
					value.EligibleForSAR = flag9.Value;
				}
			}
			if (dict.ContainsKey("TIMETOREADY_MINUTES"))
			{
				int num18 = 0;
				num18 = int.Parse(Conversions.ToString(dict["TIMETOREADY_MINUTES"]));
				if ((object)value.GetType() == typeof(Aircraft))
				{
					if (((Aircraft)value).IsParked() | (((Aircraft)value).AirOps.Condition == Aircraft_AirOps._AirOpsCondition.Readying))
					{
						((Aircraft)value).AirOps.ConditionTimer = num18 * 60;
						if (((Aircraft)value).AirOps.Condition == Aircraft_AirOps._AirOpsCondition.Readying)
						{
							((Aircraft)value).AirOps.OverrideConditionTimer = num18 * 60;
						}
					}
				}
				else if (value.DockingOps != null)
				{
					value.DockingOps.ConditionTimer = num18 * 60;
				}
			}
			value.updateLastReportedInfo();
			return new LuaWrapper_ActiveUnit_SE(value, ScenarioContext);
		}
		throw new LuaError("Need to define a Name or Guid to identify a unit. Preferably a Guid or Side & Name.");
	}

	public static bool ScenEdit_DeleteUnit(LuaTable table, bool withGroup, Scenario ScenarioContext)
	{
		Dictionary<string, object> dict = LuaUtility.ToDictUpper(table.GetEnumerator());
		ActiveUnit value = null;
		LuaUtility.ParseUnitDict(ref dict);
		if (!dict.ContainsKey("GUID"))
		{
			if (dict.ContainsKey("UNITNAME"))
			{
				if (!dict.TryGetValue("UNITNAME", out var value2))
				{
					throw new LuaError("name must be a string");
				}
				string text = Conversions.ToString(value2);
				if (!dict.ContainsKey("SIDE"))
				{
					foreach (ActiveUnit activeUnits_ in ScenarioContext.ActiveUnits_List)
					{
						if (string.Equals(activeUnits_.Name, text, StringComparison.OrdinalIgnoreCase))
						{
							value = activeUnits_;
							break;
						}
					}
					if (value == null)
					{
						throw new LuaError("Can't find Unit '" + text);
					}
					dict["GUID"] = value.ObjectID;
					dict["SIDE"] = value.get_UnitSide(SetSideOnly: false).Name;
				}
				else
				{
					if (!dict.TryGetValue("SIDE", out var value3))
					{
						throw new LuaError("side must be a string");
					}
					string text2 = Conversions.ToString(value3);
					Side side;
					try
					{
						side = LuaUtility.QuerySide(dict, ScenarioContext);
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						ex2?.Data.Add("Error at PM107", "");
						GameGeneral.WriteExceptionsToLog(ex2);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						throw new LuaError("Can't find Side '" + text2 + "'");
					}
					foreach (ActiveUnit unit in side.Units)
					{
						if (string.Equals(unit.Name, text, StringComparison.OrdinalIgnoreCase))
						{
							value = unit;
							break;
						}
					}
					if (value == null)
					{
						throw new LuaError("Can't find Unit '" + text + "' on Side '" + text2 + "'");
					}
					dict["GUID"] = value.ObjectID;
				}
			}
		}
		else
		{
			if (!dict.TryGetValue("GUID", out var value4))
			{
				throw new LuaError("guid must be a string");
			}
			string text3 = Conversions.ToString(value4);
			if (!ScenarioContext.ActiveUnits.TryGetValue(text3, out value))
			{
				throw new LuaError("Can't find guid " + text3);
			}
			dict["SIDE"] = value.get_UnitSide(SetSideOnly: false).Name;
			dict["UNITNAME"] = value.Name;
		}
		if (value != null)
		{
			int result;
			if (!ScenarioContext.ExecutionInProgress)
			{
				if (value.IsGroup && withGroup)
				{
					List<ActiveUnit> list = new List<ActiveUnit>();
					list.AddRange(((Group)value).Units.Values);
					foreach (ActiveUnit item in list)
					{
						ScenarioContext.DeleteUnitImmediately(item.ObjectID, ScenEditAction: true, "Deleted via Lua command.", null, RegisterAsLosses: false);
					}
				}
				ScenarioContext.DeleteUnitImmediately(value.ObjectID, ScenEditAction: true, "Deleted via Lua command.", null, RegisterAsLosses: false);
				result = 1;
			}
			else
			{
				if (value.IsGroup && withGroup)
				{
					List<ActiveUnit> list2 = new List<ActiveUnit>();
					list2.AddRange(((Group)value).Units.Values);
					foreach (ActiveUnit item2 in list2)
					{
						ScenarioContext.DeleteThisUnit(item2);
					}
				}
				ScenarioContext.DeleteThisUnit(value);
				result = 1;
			}
			return (byte)result != 0;
		}
		throw new LuaError("Need to define a Name or Guid to identify a unit. Preferably a Guid or Side & Name.");
	}

	public static bool ScenEdit_KillUnit(LuaTable table, Scenario ScenarioContext)
	{
		Dictionary<string, object> dict = LuaUtility.ToDictUpper(table.GetEnumerator());
		ActiveUnit activeUnit = null;
		LuaUtility.ParseUnitDict(ref dict);
		if (dict.ContainsKey("GUID"))
		{
			string text;
			try
			{
				text = Conversions.ToString(dict["GUID"]);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at PM110", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("guid must be a string");
			}
			try
			{
				activeUnit = ScenarioContext.ActiveUnits[text];
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				ex4?.Data.Add("Error at PM111", "");
				GameGeneral.WriteExceptionsToLog(ex4);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("Can't find guid " + text);
			}
			dict["SIDE"] = activeUnit.get_UnitSide(SetSideOnly: false).Name;
			dict["UNITNAME"] = activeUnit.Name;
		}
		else if (dict.ContainsKey("UNITNAME"))
		{
			string text2;
			try
			{
				text2 = Conversions.ToString(dict["UNITNAME"]);
			}
			catch (Exception ex5)
			{
				ProjectData.SetProjectError(ex5);
				Exception ex6 = ex5;
				ex6?.Data.Add("Error at PM112", "");
				GameGeneral.WriteExceptionsToLog(ex6);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("name must be a string");
			}
			if (dict.ContainsKey("SIDE"))
			{
				string text3;
				try
				{
					text3 = Conversions.ToString(dict["SIDE"]);
				}
				catch (Exception ex7)
				{
					ProjectData.SetProjectError(ex7);
					Exception ex8 = ex7;
					ex8?.Data.Add("Error at PM113", "");
					GameGeneral.WriteExceptionsToLog(ex8);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("side must be a string");
				}
				Side side;
				try
				{
					side = LuaUtility.QuerySide(dict, ScenarioContext);
				}
				catch (Exception ex9)
				{
					ProjectData.SetProjectError(ex9);
					Exception ex10 = ex9;
					ex10?.Data.Add("Error at PM114", "");
					GameGeneral.WriteExceptionsToLog(ex10);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("Can't find Side '" + text3 + "'");
				}
				try
				{
					activeUnit = side.Units.First([SpecialName] (ActiveUnit s) => string.Equals(s.Name, text2, StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, text2, StringComparison.OrdinalIgnoreCase));
				}
				catch (Exception ex11)
				{
					ProjectData.SetProjectError(ex11);
					Exception ex12 = ex11;
					ex12?.Data.Add("Error at PM115", "");
					GameGeneral.WriteExceptionsToLog(ex12);
					int num;
					if (!Debugger.IsAttached)
					{
						num = 5;
					}
					else
					{
						Debugger.Break();
						num = 5;
					}
					string[] array = new string[num];
					array[0] = "Can't find Unit '";
					array[1] = text2;
					array[2] = "' on Side '";
					array[3] = text3;
					array[4] = "'";
					throw new LuaError(string.Concat(array));
				}
				dict["GUID"] = activeUnit.ObjectID;
			}
			else
			{
				try
				{
					activeUnit = ScenarioContext.ActiveUnits_List.First([SpecialName] (ActiveUnit s) => string.Equals(s.Name, text2, StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, text2, StringComparison.OrdinalIgnoreCase));
				}
				catch (Exception ex13)
				{
					ProjectData.SetProjectError(ex13);
					Exception ex14 = ex13;
					ex14?.Data.Add("Error at PM116", "");
					GameGeneral.WriteExceptionsToLog(ex14);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("Can't find Unit '" + text2 + "'");
				}
				dict["GUID"] = activeUnit.ObjectID;
				dict["SIDE"] = activeUnit.get_UnitSide(SetSideOnly: false).Name;
			}
		}
		if (activeUnit == null)
		{
			throw new LuaError("Need to define a Name or Guid to identify a unit. Preferably a Guid or Side & Name.");
		}
		ScenarioContext.DestroyThisUnit(activeUnit, "Unit destroyed by Lua script", "Script");
		return true;
	}

	public static bool ScenEdit_SetUnitSide(LuaTable table, Scenario ScenarioContext)
	{
		Dictionary<string, object> dict = LuaUtility.ToDictUpper(table.GetEnumerator());
		ActiveUnit activeUnit = null;
		LuaUtility.ParseUnitDict(ref dict);
		if (dict.ContainsKey("GUID"))
		{
			string text;
			try
			{
				text = Conversions.ToString(dict["GUID"]);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at PM117", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("guid must be a string");
			}
			try
			{
				activeUnit = ScenarioContext.ActiveUnits[text];
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				ex4?.Data.Add("Error at PM118", "");
				GameGeneral.WriteExceptionsToLog(ex4);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("Can't find guid " + text);
			}
			dict["SIDE"] = activeUnit.get_UnitSide(SetSideOnly: false).Name;
			dict["UNITNAME"] = activeUnit.Name;
		}
		else if (dict.ContainsKey("UNITNAME"))
		{
			_Closure$__153-0 arg = default(_Closure$__153-0);
			_Closure$__153-0 CS$<>8__locals7 = new _Closure$__153-0(arg);
			try
			{
				CS$<>8__locals7.$VB$Local_Name = Conversions.ToString(dict["UNITNAME"]);
			}
			catch (Exception ex5)
			{
				ProjectData.SetProjectError(ex5);
				Exception ex6 = ex5;
				ex6?.Data.Add("Error at PM119", "");
				GameGeneral.WriteExceptionsToLog(ex6);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("name must be a string");
			}
			if (dict.ContainsKey("SIDE"))
			{
				string text2;
				try
				{
					text2 = Conversions.ToString(dict["SIDE"]);
				}
				catch (Exception ex7)
				{
					ProjectData.SetProjectError(ex7);
					Exception ex8 = ex7;
					ex8?.Data.Add("Error at PM120", "");
					GameGeneral.WriteExceptionsToLog(ex8);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("side must be a string");
				}
				Side side;
				try
				{
					side = LuaUtility.QuerySide(dict, ScenarioContext);
				}
				catch (Exception ex9)
				{
					ProjectData.SetProjectError(ex9);
					Exception ex10 = ex9;
					ex10?.Data.Add("Error at PM121", "");
					GameGeneral.WriteExceptionsToLog(ex10);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("Can't find Side '" + text2 + "'");
				}
				try
				{
					activeUnit = side.Units.First([SpecialName] (ActiveUnit s) => string.Equals(s.Name, CS$<>8__locals7.$VB$Local_Name, StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, CS$<>8__locals7.$VB$Local_Name, StringComparison.OrdinalIgnoreCase));
				}
				catch (Exception ex11)
				{
					ProjectData.SetProjectError(ex11);
					Exception ex12 = ex11;
					ex12?.Data.Add("Error at PM122", "");
					GameGeneral.WriteExceptionsToLog(ex12);
					int num;
					if (!Debugger.IsAttached)
					{
						num = 5;
					}
					else
					{
						Debugger.Break();
						num = 5;
					}
					string[] array = new string[num];
					array[0] = "Can't find Unit '";
					array[1] = CS$<>8__locals7.$VB$Local_Name;
					array[2] = "' on Side '";
					array[3] = text2;
					array[4] = "'";
					throw new LuaError(string.Concat(array));
				}
				dict["GUID"] = activeUnit.ObjectID;
			}
			else
			{
				try
				{
					activeUnit = ScenarioContext.ActiveUnits_List.First([SpecialName] (ActiveUnit s) => string.Equals(s.Name, CS$<>8__locals7.$VB$Local_Name, StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, CS$<>8__locals7.$VB$Local_Name, StringComparison.OrdinalIgnoreCase));
				}
				catch (Exception ex13)
				{
					ProjectData.SetProjectError(ex13);
					Exception ex14 = ex13;
					ex14?.Data.Add("Error at PM123", "");
					GameGeneral.WriteExceptionsToLog(ex14);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("Can't find Unit '" + CS$<>8__locals7.$VB$Local_Name + "'");
				}
				dict["GUID"] = activeUnit.ObjectID;
				dict["SIDE"] = activeUnit.get_UnitSide(SetSideOnly: false).Name;
			}
		}
		if (activeUnit == null)
		{
			throw new LuaError("Need to define a Name or Guid to identify a unit. Preferably a Guid or Side & Name.");
		}
		Side newSide = null;
		try
		{
			Side[] sides_ReadOnly = ScenarioContext.Sides_ReadOnly;
			foreach (Side side2 in sides_ReadOnly)
			{
				if (Operators.CompareString(side2.Name.ToUpper(), dict["NEWSIDE"].ToString().ToUpper(), false) == 0)
				{
					newSide = side2;
					break;
				}
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			throw new LuaError("Invalid new-side name!");
		}
		return activeUnit.SetSide(newSide, ScenarioContext);
	}

	public static bool ScenEdit_SetLoadoutAvailable(LuaTable table, Scenario ScenarioContext)
	{
		Dictionary<string, object> dict = LuaUtility.ToDictUpper(table.GetEnumerator());
		LuaUtility.ParseUnitDict(ref dict);
		if (dict.ContainsKey("LOADOUTDBID"))
		{
			int item;
			try
			{
				item = Conversions.ToInteger(dict["LOADOUTDBID"]);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at PM124", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("'LoadoutDBID' must be an integer");
			}
			if (dict.ContainsKey("AVAILABLE"))
			{
				bool flag;
				try
				{
					flag = Conversions.ToBoolean(dict["AVAILABLE"]);
				}
				catch (Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					Exception ex4 = ex3;
					ex4?.Data.Add("Error at PM125", "");
					GameGeneral.WriteExceptionsToLog(ex4);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("'Available' must be a boolean value (0 or 1,'True' or 'False')");
				}
				int result;
				if (flag)
				{
					try
					{
						ScenarioContext.Cache_DisabledLoadouts.Remove(item);
					}
					catch (Exception ex5)
					{
						ProjectData.SetProjectError(ex5);
						Exception ex6 = ex5;
						ex6?.Data.Add("Error at PM126", "");
						GameGeneral.WriteExceptionsToLog(ex6);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
					result = 1;
				}
				else
				{
					ScenarioContext.Cache_DisabledLoadouts.Add(item);
					result = 1;
				}
				return (byte)result != 0;
			}
			throw new LuaError("Mandatory value 'Available' not provided");
		}
		throw new LuaError("Mandatory value 'LoadoutDBID' not provided");
	}

	public static int ScenEdit_AddReloadsToUnit(LuaTable table, Scenario ScenarioContext)
	{
		Dictionary<string, object> dict = LuaUtility.ToDictUpper(table.GetEnumerator());
		ActiveUnit activeUnit = null;
		Side side = null;
		LuaUtility.ParseUnitDict(ref dict);
		int result;
		if (dict.ContainsKey("GUID"))
		{
			string key;
			try
			{
				key = Conversions.ToString(dict["GUID"]);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at PM127", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("guid must be a string");
			}
			try
			{
				activeUnit = ScenarioContext.ActiveUnits[key];
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				ex4?.Data.Add("Error at PM128", "");
				GameGeneral.WriteExceptionsToLog(ex4);
				int num;
				if (!Debugger.IsAttached)
				{
					num = 0;
				}
				else
				{
					Debugger.Break();
					num = 0;
				}
				result = num;
				ProjectData.ClearProjectError();
				goto IL_0935;
			}
			if (activeUnit == null)
			{
				result = 0;
				goto IL_0935;
			}
			dict["SIDE"] = activeUnit.get_UnitSide(SetSideOnly: false).Name;
			dict["UNITNAME"] = activeUnit.Name;
		}
		else if (dict.ContainsKey("UNITNAME"))
		{
			_Closure$__155-0 arg = default(_Closure$__155-0);
			_Closure$__155-0 CS$<>8__locals7 = new _Closure$__155-0(arg);
			try
			{
				CS$<>8__locals7.$VB$Local_Name = Conversions.ToString(dict["UNITNAME"]);
			}
			catch (Exception ex5)
			{
				ProjectData.SetProjectError(ex5);
				Exception ex6 = ex5;
				ex6?.Data.Add("Error at PM129", "");
				GameGeneral.WriteExceptionsToLog(ex6);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("name must be a string");
			}
			if (dict.ContainsKey("SIDE"))
			{
				string text;
				try
				{
					text = Conversions.ToString(dict["SIDE"]);
				}
				catch (Exception ex7)
				{
					ProjectData.SetProjectError(ex7);
					Exception ex8 = ex7;
					ex8?.Data.Add("Error at PM130", "");
					GameGeneral.WriteExceptionsToLog(ex8);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("side must be a string");
				}
				try
				{
					side = LuaUtility.QuerySide(dict, ScenarioContext);
				}
				catch (Exception ex9)
				{
					ProjectData.SetProjectError(ex9);
					Exception ex10 = ex9;
					ex10?.Data.Add("Error at PM131", "");
					GameGeneral.WriteExceptionsToLog(ex10);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("Can't find Side '" + text + "'");
				}
				try
				{
					activeUnit = side.Units.FirstOrDefault([SpecialName] (ActiveUnit s) => string.Equals(s.Name, CS$<>8__locals7.$VB$Local_Name, StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, CS$<>8__locals7.$VB$Local_Name, StringComparison.OrdinalIgnoreCase));
				}
				catch (Exception ex11)
				{
					ProjectData.SetProjectError(ex11);
					Exception ex12 = ex11;
					ex12?.Data.Add("Error at PM132", "");
					GameGeneral.WriteExceptionsToLog(ex12);
					int num2;
					if (Debugger.IsAttached)
					{
						Debugger.Break();
						num2 = 5;
					}
					else
					{
						num2 = 5;
					}
					string[] array = new string[num2];
					array[0] = "Can't find Unit '";
					array[1] = CS$<>8__locals7.$VB$Local_Name;
					array[2] = "' on Side '";
					array[3] = text;
					array[4] = "'";
					throw new LuaError(string.Concat(array));
				}
				dict["GUID"] = activeUnit.ObjectID;
			}
			else
			{
				try
				{
					activeUnit = ScenarioContext.ActiveUnits_List.FirstOrDefault([SpecialName] (ActiveUnit s) => string.Equals(s.Name, CS$<>8__locals7.$VB$Local_Name, StringComparison.OrdinalIgnoreCase) | string.Equals(s.ObjectID, CS$<>8__locals7.$VB$Local_Name, StringComparison.OrdinalIgnoreCase));
				}
				catch (Exception ex13)
				{
					ProjectData.SetProjectError(ex13);
					Exception ex14 = ex13;
					ex14?.Data.Add("Error at PM133", "");
					GameGeneral.WriteExceptionsToLog(ex14);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("Can't find Unit '" + CS$<>8__locals7.$VB$Local_Name + "'");
				}
				dict["GUID"] = activeUnit.ObjectID;
				dict["SIDE"] = activeUnit.get_UnitSide(SetSideOnly: false).Name;
			}
		}
		if (activeUnit != null)
		{
			if (side == null)
			{
				side = LuaUtility.QuerySide(dict, ScenarioContext);
			}
			if (dict.ContainsKey("WPN_DBID"))
			{
				int num3 = Conversions.ToInteger(dict["WPN_DBID"]);
				Mount mount = null;
				if (dict.ContainsKey("MOUNT_GUID"))
				{
					if (activeUnit.Mounts.Count == 0)
					{
						throw new LuaError("No mount present in unit.");
					}
					foreach (Mount mount2 in activeUnit.Mounts)
					{
						if (Operators.CompareString(mount2.ObjectID, Conversions.ToString(dict["MOUNT_GUID"]), false) == 0)
						{
							mount = mount2;
						}
					}
				}
				if (!((mount == null) & (activeUnit.Mounts.Count == 0)))
				{
					string text2 = null;
					int num4;
					if (dict.ContainsKey("WPN_GUID"))
					{
						text2 = Conversions.ToString(dict["WPN_GUID"]);
						num4 = 0;
					}
					else
					{
						num4 = 0;
					}
					int num5 = num4;
					bool flag = false;
					bool flag2 = true;
					bool flag3 = false;
					int num6 = 0;
					bool flag4 = true;
					if (dict.ContainsKey("ADDASCELL"))
					{
						flag4 = Conversions.ToBoolean(dict["ADDASCELL"]);
					}
					if (dict.ContainsKey("NUMBER"))
					{
						num5 = Conversions.ToInteger(dict["NUMBER"]);
					}
					if (dict.ContainsKey("REMOVE"))
					{
						flag = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(dict["REMOVE"])).Value;
					}
					if (dict.ContainsKey("FILLOUT"))
					{
						flag3 = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(dict["FILLOUT"])).Value;
					}
					if (flag3)
					{
						flag2 = false;
						flag = false;
						num5 = 9999999;
						flag4 = true;
					}
					if (num5 > 0)
					{
						if (Information.IsNothing((object)mount))
						{
							foreach (Mount mount3 in activeUnit.Mounts)
							{
								foreach (WeaponRec mountWeapon in mount3.MountWeapons)
								{
									int num7 = mountWeapon.Multiple;
									int num8;
									if (num7 >= 1)
									{
										if (flag4)
										{
											goto IL_0768;
										}
										num8 = 1;
									}
									else
									{
										num8 = 1;
									}
									num7 = num8;
									goto IL_0768;
									IL_0768:
									int num9 = num7 * num5;
									if ((text2 != null && Operators.CompareString(text2, mountWeapon.ObjectID, false) != 0) || mountWeapon.int_3 != num3)
									{
										continue;
									}
									if (!flag)
									{
										if (mountWeapon.CurrentLoad + num9 > mountWeapon.MaxLoad)
										{
											if (mountWeapon.CurrentLoad != mountWeapon.MaxLoad)
											{
												while (mountWeapon.CurrentLoad < mountWeapon.MaxLoad && num9 > 0)
												{
													num9 -= num7;
													num5--;
													mountWeapon.CurrentLoad += num7;
													num6++;
												}
												mountWeapon.CurrentLoad = mountWeapon.MaxLoad;
											}
											continue;
										}
										mountWeapon.CurrentLoad += num9;
										num6 += num5;
										num5 = 0;
										break;
									}
									if (mountWeapon.CurrentLoad < num9)
									{
										if (mountWeapon.CurrentLoad > 0)
										{
											while (mountWeapon.CurrentLoad >= num7 && num9 > 0)
											{
												num9 -= num7;
												num5--;
												mountWeapon.CurrentLoad -= num7;
												num6++;
											}
											mountWeapon.CurrentLoad = 0;
										}
										continue;
									}
									mountWeapon.CurrentLoad -= num9;
									num6 += num5;
									num5 = 0;
									break;
								}
								if (num5 <= 0)
								{
									break;
								}
							}
						}
						else
						{
							foreach (WeaponRec mountWeapon2 in mount.MountWeapons)
							{
								int num10 = mountWeapon2.Multiple;
								int num11;
								if (num10 >= 1)
								{
									if (flag4)
									{
										goto IL_05a0;
									}
									num11 = 1;
								}
								else
								{
									num11 = 1;
								}
								num10 = num11;
								goto IL_05a0;
								IL_05a0:
								int num12 = num10 * num5;
								if ((text2 != null && Operators.CompareString(text2, mountWeapon2.ObjectID, false) != 0) || mountWeapon2.int_3 != num3)
								{
									continue;
								}
								if (!flag)
								{
									if (mountWeapon2.CurrentLoad + num12 > mountWeapon2.MaxLoad)
									{
										if (mountWeapon2.CurrentLoad != mountWeapon2.MaxLoad)
										{
											while (mountWeapon2.CurrentLoad < mountWeapon2.MaxLoad && num12 > 0)
											{
												num12 -= num10;
												num5--;
												mountWeapon2.CurrentLoad += num10;
												num6++;
											}
											mountWeapon2.CurrentLoad = mountWeapon2.MaxLoad;
										}
										continue;
									}
									mountWeapon2.CurrentLoad += num12;
									num6 += num5;
									num5 = 0;
									break;
								}
								if (mountWeapon2.CurrentLoad < num12)
								{
									if (mountWeapon2.CurrentLoad > 0)
									{
										while (mountWeapon2.CurrentLoad >= num10 && num12 > 0)
										{
											num12 -= num10;
											num5--;
											mountWeapon2.CurrentLoad -= num10;
											num6++;
										}
										mountWeapon2.CurrentLoad = 0;
									}
									continue;
								}
								mountWeapon2.CurrentLoad -= num12;
								num6 += num5;
								num5 = 0;
								break;
							}
						}
					}
					if (!(num5 > 0 && !flag && !flag3 && flag2) || Information.IsNothing((object)mount))
					{
					}
					result = num6;
					goto IL_0935;
				}
				throw new LuaError("No mount present in unit.");
			}
			throw new LuaError("No weapon defined.");
		}
		throw new LuaError("Need to define a Name or Guid to identify a unit. Preferably a Guid or Side & Name.");
		IL_0935:
		return result;
	}

	public static int ScenEdit_AddWeaponToUnitMagazine(LuaTable table, Scenario ScenarioContext)
	{
		Dictionary<string, object> dict = LuaUtility.ToDictUpper(table.GetEnumerator());
		ActiveUnit myUnit = null;
		Side side = null;
		LuaUtility.ParseUnitDict(ref dict);
		int result;
		if (dict.ContainsKey("GUID"))
		{
			string key;
			try
			{
				key = Conversions.ToString(dict["GUID"]);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at PM134", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("guid must be a string");
			}
			try
			{
				myUnit = ScenarioContext.ActiveUnits[key];
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				ex4?.Data.Add("Error at PM135", "");
				GameGeneral.WriteExceptionsToLog(ex4);
				int num;
				if (!Debugger.IsAttached)
				{
					num = 0;
				}
				else
				{
					Debugger.Break();
					num = 0;
				}
				result = num;
				ProjectData.ClearProjectError();
				goto IL_09c4;
			}
			if (myUnit == null)
			{
				result = 0;
				goto IL_09c4;
			}
			dict["SIDE"] = myUnit.get_UnitSide(SetSideOnly: false).Name;
			dict["UNITNAME"] = myUnit.Name;
		}
		else if (dict.ContainsKey("UNITNAME"))
		{
			_Closure$__156-0 arg = default(_Closure$__156-0);
			_Closure$__156-0 CS$<>8__locals5 = new _Closure$__156-0(arg);
			try
			{
				CS$<>8__locals5.$VB$Local_Name = Conversions.ToString(dict["UNITNAME"]);
			}
			catch (Exception ex5)
			{
				ProjectData.SetProjectError(ex5);
				Exception ex6 = ex5;
				ex6?.Data.Add("Error at PM136", "");
				GameGeneral.WriteExceptionsToLog(ex6);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("name must be a string");
			}
			if (dict.ContainsKey("SIDE"))
			{
				string text = null;
				try
				{
					text = Conversions.ToString(dict["SIDE"]);
				}
				catch (Exception ex7)
				{
					ProjectData.SetProjectError(ex7);
					Exception ex8 = ex7;
					ex8?.Data.Add("Error at PM137", "");
					GameGeneral.WriteExceptionsToLog(ex8);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("side must be a string");
				}
				try
				{
					side = LuaUtility.QuerySide(dict, ScenarioContext);
				}
				catch (Exception ex9)
				{
					ProjectData.SetProjectError(ex9);
					Exception ex10 = ex9;
					ex10?.Data.Add("Error at PM138", "");
					GameGeneral.WriteExceptionsToLog(ex10);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("Can't find Side '" + text + "'");
				}
				try
				{
					myUnit = side.Units.FirstOrDefault([SpecialName] (ActiveUnit s) => string.Equals(s.Name, CS$<>8__locals5.$VB$Local_Name, StringComparison.OrdinalIgnoreCase));
				}
				catch (Exception ex11)
				{
					ProjectData.SetProjectError(ex11);
					Exception ex12 = ex11;
					ex12?.Data.Add("Error at PM139", "");
					GameGeneral.WriteExceptionsToLog(ex12);
					int num2;
					if (!Debugger.IsAttached)
					{
						num2 = 5;
					}
					else
					{
						Debugger.Break();
						num2 = 5;
					}
					string[] array = new string[num2];
					array[0] = "Can't find Unit '";
					array[1] = CS$<>8__locals5.$VB$Local_Name;
					array[2] = "' on Side '";
					array[3] = text;
					array[4] = "'";
					throw new LuaError(string.Concat(array));
				}
				dict["GUID"] = myUnit.ObjectID;
			}
			else
			{
				try
				{
					myUnit = ScenarioContext.ActiveUnits_List.FirstOrDefault([SpecialName] (ActiveUnit s) => string.Equals(s.Name, CS$<>8__locals5.$VB$Local_Name, StringComparison.OrdinalIgnoreCase));
				}
				catch (Exception ex13)
				{
					ProjectData.SetProjectError(ex13);
					Exception ex14 = ex13;
					ex14?.Data.Add("Error at PM140", "");
					GameGeneral.WriteExceptionsToLog(ex14);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("Can't find Unit '" + CS$<>8__locals5.$VB$Local_Name + "'");
				}
				dict["GUID"] = myUnit.ObjectID;
				dict["SIDE"] = myUnit.get_UnitSide(SetSideOnly: false).Name;
			}
		}
		if (myUnit == null)
		{
			throw new LuaError("Need to define a Name or Guid to identify a unit. Preferably a Guid or Side & Name.");
		}
		if (side == null)
		{
			side = LuaUtility.QuerySide(dict, ScenarioContext);
		}
		Magazine mag = null;
		if (dict.ContainsKey("MAG_GUID"))
		{
			if (myUnit.TotalMagazines.Count() == 0)
			{
				throw new LuaError("No magazine present in unit.");
			}
			Magazine[] totalMagazines = myUnit.TotalMagazines;
			foreach (Magazine magazine in totalMagazines)
			{
				if (string.Equals(Conversions.ToString(dict["MAG_GUID"]), magazine.ObjectID, StringComparison.OrdinalIgnoreCase))
				{
					mag = magazine;
					break;
				}
			}
		}
		if ((mag == null) & (myUnit.TotalMagazines.Count() == 0))
		{
			throw new LuaError("No magazine present in unit.");
		}
		if (dict.ContainsKey("WPN_DBID"))
		{
			int num4 = Conversions.ToInteger(dict["WPN_DBID"]);
			int num5 = 0;
			int capacity = 0;
			bool flag = false;
			bool allowAddingNewWeaponRec = true;
			bool flag2 = false;
			int num6 = 0;
			if (dict.ContainsKey("NUMBER"))
			{
				num5 = Conversions.ToInteger(dict["NUMBER"]);
			}
			if (dict.ContainsKey("MAXCAP"))
			{
				capacity = Conversions.ToInteger(dict["MAXCAP"]);
			}
			if (dict.ContainsKey("REMOVE"))
			{
				flag = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(dict["REMOVE"])).Value;
			}
			if (dict.ContainsKey("NEW"))
			{
				allowAddingNewWeaponRec = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(dict["NEW"])).Value;
			}
			if (dict.ContainsKey("FILLOUT"))
			{
				flag2 = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(dict["FILLOUT"])).Value;
			}
			if (flag2)
			{
				allowAddingNewWeaponRec = false;
				flag = false;
				num5 = 9999999;
			}
			if (num5 > 0)
			{
				if (mag != null)
				{
					foreach (WeaponRec weapon in mag.Weapons)
					{
						if (weapon.int_3 != num4)
						{
							continue;
						}
						if (!flag)
						{
							if (weapon.CurrentLoad + num5 <= weapon.MaxLoad)
							{
								weapon.CurrentLoad += num5;
								num6 += num5;
								num5 = 0;
								break;
							}
							if (weapon.CurrentLoad != weapon.MaxLoad)
							{
								num5 -= weapon.MaxLoad - weapon.CurrentLoad;
								num6 += weapon.MaxLoad - weapon.CurrentLoad;
								weapon.CurrentLoad = weapon.MaxLoad;
							}
						}
						else
						{
							if (weapon.CurrentLoad >= num5)
							{
								weapon.CurrentLoad -= num5;
								num6 += num5;
								num5 = 0;
								break;
							}
							if (weapon.CurrentLoad > 0)
							{
								num5 -= weapon.CurrentLoad;
								num6 += weapon.CurrentLoad;
								weapon.CurrentLoad = 0;
							}
						}
					}
				}
				else
				{
					Magazine[] totalMagazines2 = myUnit.TotalMagazines;
					foreach (Magazine magazine2 in totalMagazines2)
					{
						foreach (WeaponRec weapon2 in magazine2.Weapons)
						{
							if (weapon2.int_3 != num4)
							{
								continue;
							}
							if (!flag)
							{
								if (weapon2.CurrentLoad + num5 <= weapon2.MaxLoad)
								{
									weapon2.CurrentLoad += num5;
									num6 += num5;
									num5 = 0;
									break;
								}
								if (weapon2.CurrentLoad != weapon2.MaxLoad)
								{
									num5 -= weapon2.MaxLoad - weapon2.CurrentLoad;
									num6 += weapon2.MaxLoad - weapon2.CurrentLoad;
									weapon2.CurrentLoad = weapon2.MaxLoad;
								}
							}
							else
							{
								if (weapon2.CurrentLoad >= num5)
								{
									weapon2.CurrentLoad -= num5;
									num6 += num5;
									num5 = 0;
									break;
								}
								if (weapon2.CurrentLoad > 0)
								{
									num5 -= weapon2.CurrentLoad;
									num6 += weapon2.CurrentLoad;
									weapon2.CurrentLoad = 0;
								}
							}
						}
						if (num5 <= 0)
						{
							break;
						}
					}
				}
			}
			while (num5 > 0 && !flag && !flag2)
			{
				if (mag == null)
				{
					Magazine magazine3 = null;
					Magazine mag2 = null;
					magazine3 = AddWeaponToMagazines(ref myUnit, num4, ref mag2, PriorityToAviationMags: false, allowAddingNewWeaponRec, capacity);
					if (magazine3 == null)
					{
						break;
					}
					num5--;
					num6++;
					foreach (WeaponRec weapon3 in magazine3.Weapons)
					{
						if (weapon3.int_3 == num4)
						{
							if (weapon3.CurrentLoad + num5 <= weapon3.MaxLoad)
							{
								weapon3.CurrentLoad += num5;
								num6 += num5;
								num5 = 0;
								break;
							}
							if (weapon3.CurrentLoad != weapon3.MaxLoad)
							{
								num5 -= weapon3.MaxLoad - weapon3.CurrentLoad;
								num6 += weapon3.MaxLoad - weapon3.CurrentLoad;
								weapon3.CurrentLoad = weapon3.MaxLoad;
							}
						}
					}
					magazine3.RaiseEventStatusChanged();
					continue;
				}
				if (AddWeaponToMagazines(ref myUnit, num4, ref mag, PriorityToAviationMags: false, allowAddingNewWeaponRec, capacity) == null)
				{
					break;
				}
				num5--;
				num6++;
				foreach (WeaponRec weapon4 in mag.Weapons)
				{
					if (weapon4.int_3 == num4)
					{
						if (weapon4.CurrentLoad + num5 <= weapon4.MaxLoad)
						{
							weapon4.CurrentLoad += num5;
							num6 += num5;
							num5 = 0;
							break;
						}
						if (weapon4.CurrentLoad != weapon4.MaxLoad)
						{
							num5 -= weapon4.MaxLoad - weapon4.CurrentLoad;
							num6 += weapon4.MaxLoad - weapon4.CurrentLoad;
							weapon4.CurrentLoad = weapon4.MaxLoad;
						}
					}
				}
				mag.RaiseEventStatusChanged();
				break;
			}
			result = num6;
			goto IL_09c4;
		}
		throw new LuaError("No weapon defined.");
		IL_09c4:
		return result;
	}

	public static Magazine AddWeaponToMagazines(ref ActiveUnit myUnit, int int_0, ref Magazine mag, bool PriorityToAviationMags, bool AllowAddingNewWeaponRec, int Capacity)
	{
		Magazine[] totalMagazines = myUnit.TotalMagazines;
		if (AllowAddingNewWeaponRec)
		{
			if (mag != null)
			{
				Magazine obj = mag;
				int theQty_FullyLoadedCells = 0;
				int theQty_PartiallyLoadedCells = 0;
				if (obj.CurrentCapacity(ref theQty_FullyLoadedCells, ref theQty_PartiallyLoadedCells) <= mag.Capacity)
				{
					int theMaxLoad = Capacity;
					if (Capacity == 0)
					{
						theMaxLoad = mag.Capacity;
					}
					mag.Weapons.Add(new WeaponRec(ref myUnit.ParentScen, int_0, 0, theMaxLoad, 1, 1, ExcludeOptionalWeapons: false, AircraftInternalWeapons: false));
					if (string.CompareOrdinal(mag.AddWeapon(int_0), "OK") == 0)
					{
						return mag;
					}
				}
			}
			else if (myUnit.SharedMagazines.Length > 0)
			{
				totalMagazines = myUnit.SharedMagazines;
				if (PriorityToAviationMags)
				{
					totalMagazines = totalMagazines.OrderByDescending([SpecialName] (Magazine theMaga) => theMaga.IsAviationMag.ToString()).ToArray();
				}
				Magazine[] array = totalMagazines;
				foreach (Magazine magazine in array)
				{
					int theQty_PartiallyLoadedCells = 0;
					int theQty_FullyLoadedCells = 0;
					if (magazine.CurrentCapacity(ref theQty_PartiallyLoadedCells, ref theQty_FullyLoadedCells) <= magazine.Capacity)
					{
						int theMaxLoad2 = Capacity;
						if (Capacity == 0)
						{
							theMaxLoad2 = magazine.Capacity;
						}
						magazine.Weapons.Add(new WeaponRec(ref myUnit.ParentScen, int_0, 0, theMaxLoad2, 1, 1, ExcludeOptionalWeapons: false, AircraftInternalWeapons: false));
						if (string.CompareOrdinal(magazine.AddWeapon(int_0), "OK") == 0)
						{
							return magazine;
						}
					}
				}
			}
		}
		return null;
	}

	public static void ScenEdit_DistributeWeaponAtAirbase(LuaTable table, Scenario ScenarioContext)
	{
		_Closure$__158-1 arg = default(_Closure$__158-1);
		_Closure$__158-1 CS$<>8__locals13 = new _Closure$__158-1(arg);
		Dictionary<string, object> dict = LuaUtility.ToDictUpper(table.GetEnumerator());
		ActiveUnit activeUnit = null;
		LuaUtility.ParseUnitDict(ref dict);
		if (dict.ContainsKey("GUID"))
		{
			string text;
			try
			{
				text = Conversions.ToString(dict["GUID"]);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at PM141", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("guid must be a string");
			}
			try
			{
				activeUnit = ScenarioContext.ActiveUnits[text];
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				ex4?.Data.Add("Error at PM142", "");
				GameGeneral.WriteExceptionsToLog(ex4);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("Can't find guid " + text);
			}
		}
		else if (dict.ContainsKey("UNITNAME"))
		{
			_Closure$__158-0 arg2 = default(_Closure$__158-0);
			_Closure$__158-0 CS$<>8__locals11 = new _Closure$__158-0(arg2);
			try
			{
				CS$<>8__locals11.$VB$Local_Name = Conversions.ToString(dict["UNITNAME"]);
			}
			catch (Exception ex5)
			{
				ProjectData.SetProjectError(ex5);
				Exception ex6 = ex5;
				ex6?.Data.Add("Error at PM143", "");
				GameGeneral.WriteExceptionsToLog(ex6);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("name must be a string");
			}
			if (dict.ContainsKey("SIDE"))
			{
				string text2;
				try
				{
					text2 = Conversions.ToString(dict["SIDE"]);
				}
				catch (Exception ex7)
				{
					ProjectData.SetProjectError(ex7);
					Exception ex8 = ex7;
					ex8?.Data.Add("Error at PM144", "");
					GameGeneral.WriteExceptionsToLog(ex8);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("side must be a string");
				}
				Side side;
				try
				{
					side = LuaUtility.QuerySide(dict, ScenarioContext);
				}
				catch (Exception ex9)
				{
					ProjectData.SetProjectError(ex9);
					Exception ex10 = ex9;
					ex10?.Data.Add("Error at PM145", "");
					GameGeneral.WriteExceptionsToLog(ex10);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("Can't find Side '" + text2 + "'");
				}
				try
				{
					activeUnit = side.Units.First([SpecialName] (ActiveUnit s) => string.Equals(s.Name, CS$<>8__locals11.$VB$Local_Name, StringComparison.OrdinalIgnoreCase) | string.Equals(s.ObjectID, CS$<>8__locals11.$VB$Local_Name, StringComparison.OrdinalIgnoreCase));
				}
				catch (Exception ex11)
				{
					ProjectData.SetProjectError(ex11);
					Exception ex12 = ex11;
					ex12?.Data.Add("Error at PM146", "");
					GameGeneral.WriteExceptionsToLog(ex12);
					int num;
					if (!Debugger.IsAttached)
					{
						num = 5;
					}
					else
					{
						Debugger.Break();
						num = 5;
					}
					string[] array = new string[num];
					array[0] = "Can't find Unit '";
					array[1] = CS$<>8__locals11.$VB$Local_Name;
					array[2] = "' on Side '";
					array[3] = text2;
					array[4] = "'";
					throw new LuaError(string.Concat(array));
				}
			}
			else
			{
				try
				{
					activeUnit = ScenarioContext.ActiveUnits_List.First([SpecialName] (ActiveUnit s) => string.Equals(s.Name, CS$<>8__locals11.$VB$Local_Name, StringComparison.OrdinalIgnoreCase) | string.Equals(s.ObjectID, CS$<>8__locals11.$VB$Local_Name, StringComparison.OrdinalIgnoreCase));
				}
				catch (Exception ex13)
				{
					ProjectData.SetProjectError(ex13);
					Exception ex14 = ex13;
					ex14?.Data.Add("Error at PM147", "");
					GameGeneral.WriteExceptionsToLog(ex14);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("Can't find Unit '" + CS$<>8__locals11.$VB$Local_Name + "'");
				}
			}
		}
		if (activeUnit != null)
		{
			if (!(activeUnit is Group))
			{
				throw new LuaError("This function needs to be run on a non-single-unit airbase, one with more than a single seperate magazine.");
			}
			List<ActiveUnit> list = new List<ActiveUnit>();
			list.Add(activeUnit);
			if (activeUnit is Group)
			{
				foreach (KeyValuePair<string, ActiveUnit> unit in ((Group)activeUnit).Units)
				{
					if (unit.Value.TotalMagazines.Any())
					{
						list.Add(unit.Value);
					}
				}
			}
			if (!list.Any())
			{
				throw new LuaError("No magazines in group!");
			}
			if (dict.ContainsKey("WPN_DBID"))
			{
				CS$<>8__locals13.$VB$Local_dbid = Conversions.ToInteger(dict["WPN_DBID"]);
				if (!dict.ContainsKey("NUMBER"))
				{
					throw new LuaError("No NUMBER defined.");
				}
				int num2 = Conversions.ToInteger(dict["NUMBER"]);
				if (num2 <= 0)
				{
					throw new LuaError("NUMBER must be positive.");
				}
				CS$<>8__locals13.$VB$Local_rng = GameGeneral.GlobalRNG;
				list = list.OrderBy([SpecialName] (ActiveUnit F) => CS$<>8__locals13.$VB$Local_rng.Next()).ToList();
				int num3 = (int)Math.Round((double)num2 / (double)list.Count);
				if (num3 <= 0)
				{
					num3 = 1;
				}
				{
					foreach (ActiveUnit item in list)
					{
						if (num2 > 0)
						{
							Magazine magazine = item.TotalMagazines.First();
							WeaponRec weaponRec = magazine.Weapons.FirstOrDefault([SpecialName] (WeaponRec F) => F.int_3 == CS$<>8__locals13.$VB$Local_dbid);
							if (weaponRec == null)
							{
								weaponRec = new WeaponRec(ref ScenarioContext, CS$<>8__locals13.$VB$Local_dbid, 0, 10000, 15, 1, ExcludeOptionalWeapons: false, AircraftInternalWeapons: false);
								magazine.Weapons.Add(weaponRec);
							}
							weaponRec.MaxLoad = 10000;
							num3 = Math.Min(num2, num3);
							weaponRec.CurrentLoad += num3;
							num2 -= num3;
							if (num2 <= 0)
							{
								break;
							}
							continue;
						}
						break;
					}
					return;
				}
			}
			throw new LuaError("No WPN_DBID defined.");
		}
		throw new LuaError("Need to define a Name or Guid to identify a unit. Preferably a Guid or Side & Name.");
	}

	public static string ScenEdit_RefuelUnit(LuaTable table, Scenario ScenarioContext)
	{
		LuaSandBox.Singleton().CreateTable();
		ActiveUnit activeUnit = null;
		Side side = null;
		string Results = "";
		ActiveUnit activeUnit2 = null;
		List<Mission> list = null;
		Dictionary<string, object> dict = LuaUtility.ToDictUpper(table.GetEnumerator());
		LuaUtility.ParseUnitDict(ref dict);
		if (dict.ContainsKey("SIDE"))
		{
			side = LuaUtility.QuerySide(dict, ScenarioContext);
		}
		string text = LuaUtility.QueryUnit(dict, ScenarioContext);
		if (text.Length == 0)
		{
			if (dict.ContainsKey("GUID"))
			{
				activeUnit = smethod_1(Conversions.ToString(dict["GUID"]), ScenarioContext);
				if (side == null)
				{
					side = activeUnit.get_UnitSide(SetSideOnly: false);
				}
				if (dict.ContainsKey("TANKER"))
				{
					activeUnit2 = ValidateAUBySide(Conversions.ToString(dict["TANKER"]), side);
				}
				if (dict.ContainsKey("MISSIONS"))
				{
					list = new List<Mission>();
					List<object> list2 = LuaUtility.ToArray(((LuaTable)dict["MISSIONS"]).GetEnumerator());
					foreach (object item in list2)
					{
						Mission mission = LuaMission.ValidateMissionBySide(Conversions.ToString(RuntimeHelpers.GetObjectValue(item)), side);
						if (mission != null)
						{
							list.Add(mission);
						}
					}
				}
				if (activeUnit != null && activeUnit.IsActiveUnit)
				{
					if (!activeUnit.IsOperating())
					{
						throw new LuaError("The specified unit is not operative.");
					}
					if ((activeUnit.get_UnitSide(SetSideOnly: false) == side || Module_Side.IsAlliedWithThisSide(activeUnit.get_UnitSide(SetSideOnly: false), side)) && (object)activeUnit.GetType() != typeof(Weapon))
					{
						ActiveUnit theU = activeUnit;
						ActiveUnit theSelectedTanker = activeUnit2;
						List<Mission> theSelectedMissions = list;
						string ResultCategory = null;
						CoreClientCode.RefuelIfPossible_Core(ScenarioContext, theU, theSelectedTanker, theSelectedMissions, ref Results, ref ResultCategory);
					}
				}
			}
			if (activeUnit != null)
			{
				return Results;
			}
			return null;
		}
		throw new LuaError(text);
	}

	public static LuaTable ScenEdit_GetContacts(string side, Scenario ScenarioContext)
	{
		Side side2 = null;
		Side[] sides_ReadOnly = ScenarioContext.Sides_ReadOnly;
		foreach (Side side3 in sides_ReadOnly)
		{
			if (string.Equals(side3.Name, side, StringComparison.OrdinalIgnoreCase) || string.Equals(side3.ObjectID, side, StringComparison.OrdinalIgnoreCase))
			{
				side2 = side3;
				break;
			}
		}
		if (side2 != null)
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			foreach (Contact contacts_ in side2.Contacts_List)
			{
				LuaWrapper_Contact value = new LuaWrapper_Contact(contacts_, ScenarioContext, side2);
				luaTable[luaTable.Keys.Count + 1] = value;
			}
			foreach (Contact baseContacts_ in side2.BaseContacts_List)
			{
				LuaWrapper_Contact value2 = new LuaWrapper_Contact(baseContacts_, ScenarioContext, side2);
				luaTable[luaTable.Keys.Count + 1] = value2;
			}
			foreach (string key in side2.NewContactsQueue.Keys)
			{
				Contact theContact = side2.NewContactsQueue[key];
				LuaWrapper_Contact value3 = new LuaWrapper_Contact(theContact, ScenarioContext, side2);
				luaTable[luaTable.Keys.Count + 1] = value3;
			}
			foreach (string key2 in side2.NewBaseContactsQueue.Keys)
			{
				Contact theContact2 = side2.NewBaseContactsQueue[key2];
				LuaWrapper_Contact value4 = new LuaWrapper_Contact(theContact2, ScenarioContext, side2);
				luaTable[luaTable.Keys.Count + 1] = value4;
			}
			return luaTable;
		}
		return null;
	}

	public static bool ScenEdit_AttackContact(string attacker, string defender, LuaTable options, Scenario ScenarioContext)
	{
		ActiveUnit activeUnit = null;
		Contact contact = null;
		ActiveUnit_AI.TargetingEntry._TargetingBehavior targetingBehavior = ActiveUnit_AI.TargetingEntry._TargetingBehavior.AutoTargeted;
		string text = null;
		double num = 0.0;
		List<Waypoint> list = new List<Waypoint>();
		Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(options.GetEnumerator());
		activeUnit = smethod_1(attacker, ScenarioContext);
		if (activeUnit == null)
		{
			return false;
		}
		contact = ValidateContactBySceanrio(defender, ScenarioContext);
		if (contact == null)
		{
			if (Operators.CompareString(defender.ToUpper(), "BOL", false) != 0)
			{
				return false;
			}
			string latitudeString = null;
			if (dictionary.ContainsKey("LATITUDE"))
			{
				latitudeString = Conversions.ToString(dictionary["LATITUDE"]);
			}
			double lat = LuaUtility.ParseLatitudeString(latitudeString);
			latitudeString = "";
			if (dictionary.ContainsKey("LONGITUDE"))
			{
				latitudeString = Conversions.ToString(dictionary["LONGITUDE"]);
			}
			num = LuaUtility.ParseLongitudeString(latitudeString);
			contact = new ActivationPointContact(lat, num);
		}
		if (dictionary.ContainsKey("COURSE"))
		{
			List<object> list2 = LuaUtility.ToArray(((LuaTable)dictionary["COURSE"]).GetEnumerator());
			foreach (object item in list2)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(item);
				if (objectValue is LuaTable)
				{
					Waypoint waypoint = new Waypoint(0.0, 0.0, 0f, Waypoint.WaypointType.TurningPoint, Waypoint.WaypointCreator.Manual, Waypoint.WaypointCategory.PlottedCourse);
					if (LuaWrapper_Waypoint.FromTable((LuaTable)objectValue, waypoint, ScenarioContext))
					{
						list.Add(waypoint);
					}
					continue;
				}
				throw new LuaError("Weapon Waypoint error");
			}
		}
		if (dictionary.ContainsKey("MODE"))
		{
			text = Conversions.ToString(dictionary["MODE"]);
		}
		Weapon theWeapon;
		Mount mount;
		WeaponRec weaponRec;
		Loadout loadout;
		int num2;
		int num3;
		int num4;
		int? theShooterQty;
		int num5;
		DateTime value = default(DateTime);
		WeaponSalvo weaponSalvo;
		int result3;
		switch (text)
		{
		case "3":
			targetingBehavior = ActiveUnit_AI.TargetingEntry._TargetingBehavior.AutoSelfDefence;
			break;
		case "0":
			targetingBehavior = ActiveUnit_AI.TargetingEntry._TargetingBehavior.AutoTargeted;
			goto IL_08ab;
		case "1":
			targetingBehavior = ActiveUnit_AI.TargetingEntry._TargetingBehavior.ManualWeaponAlloc;
			goto IL_0286;
		case "ManualWeaponAlloc":
			targetingBehavior = ActiveUnit_AI.TargetingEntry._TargetingBehavior.ManualWeaponAlloc;
			goto IL_0286;
		case "2":
		case "ManualTargeted":
			targetingBehavior = ActiveUnit_AI.TargetingEntry._TargetingBehavior.ManualTargeted;
			break;
		case "AutoTargeted":
			targetingBehavior = ActiveUnit_AI.TargetingEntry._TargetingBehavior.AutoTargeted;
			goto IL_08ab;
		default:
			throw new LuaError("Invalid targeting behaviour");
		case "AutoSelfDefence":
			{
				targetingBehavior = ActiveUnit_AI.TargetingEntry._TargetingBehavior.AutoSelfDefence;
				break;
			}
			IL_0286:
			theWeapon = null;
			mount = null;
			weaponRec = null;
			loadout = null;
			num2 = 0;
			num3 = 0;
			num4 = 0;
			theShooterQty = 1;
			num5 = 0;
			weaponSalvo = null;
			if (dictionary.ContainsKey("MOUNT"))
			{
				num2 = Conversions.ToInteger(dictionary["MOUNT"]);
			}
			if (dictionary.ContainsKey("WEAPON"))
			{
				num3 = Conversions.ToInteger(dictionary["WEAPON"]);
			}
			if (dictionary.ContainsKey("QTY"))
			{
				num4 = Conversions.ToInteger(dictionary["QTY"]);
			}
			if (dictionary.ContainsKey("DATETIME"))
			{
				DateTime? dateTime = LuaUtility.ParseDateTime_String(Conversions.ToString(dictionary["DATETIME"]), null);
				if (dateTime.HasValue)
				{
					value = dateTime.Value;
				}
			}
			if (activeUnit.IsAircraft)
			{
				loadout = ((Aircraft)activeUnit).Loadout;
			}
			else if (num2 == 0)
			{
				foreach (Mount mount2 in activeUnit.Mounts)
				{
					if (num2 == mount2.DBID)
					{
						break;
					}
					if (mount2.Status == PlatformComponent._ComponentStatus.Destroyed)
					{
						continue;
					}
					foreach (WeaponRec mountWeapon in mount2.MountWeapons)
					{
						if (mountWeapon.int_3 == num3 && mountWeapon.CurrentLoad > 0)
						{
							num2 = mount2.DBID;
							break;
						}
					}
				}
			}
			if ((num2 != 0 || loadout != null) && num3 != 0)
			{
				if (num4 != 0)
				{
					bool flag = false;
					if (num2 > 0)
					{
						foreach (Mount mount3 in activeUnit.Mounts)
						{
							if (!((mount3.DBID == num2) & (mount3.Status != PlatformComponent._ComponentStatus.Destroyed)))
							{
								continue;
							}
							foreach (WeaponRec mountWeapon2 in mount3.MountWeapons)
							{
								if (mountWeapon2.int_3 != num3)
								{
									continue;
								}
								if (mountWeapon2.CurrentLoad > 0)
								{
									if (theWeapon == null)
									{
										theWeapon = mountWeapon2.get_ReferenceWeapon(ScenarioContext);
										weaponRec = mountWeapon2;
										mount = mount3;
									}
									num5 += mountWeapon2.CurrentLoad;
									if (mount3.ReloadPriority.Contains(mountWeapon2.int_3))
									{
										mount3.ReloadPriority.Remove(mountWeapon2.int_3);
									}
								}
								else
								{
									_ = activeUnit.Weaponry;
									if (mount3.MountMagazine.Weapons.Count > 0 && mount3.MountMagazine.Weapons.Count > 1 && !mountWeapon2.get_HasManualReloadPriority(mount3) && !mountWeapon2.get_ReferenceWeapon(activeUnit.ParentScen).IsDecoy && activeUnit.Weaponry.HowManyOfThisWeaponOnMountMagazine(mount3, mountWeapon2.int_3) != 0 && theWeapon == null && !mount3.ReloadPriority.Contains(mountWeapon2.int_3))
									{
										mount3.ReloadPriority.Add(mountWeapon2.int_3);
										theWeapon = mountWeapon2.get_ReferenceWeapon(ScenarioContext);
										weaponRec = mountWeapon2;
										mount = mount3;
										flag = true;
										break;
									}
								}
							}
							if (theWeapon != null)
							{
								break;
							}
						}
					}
					else if (loadout != null)
					{
						WeaponRec[] weapons = loadout.Weapons;
						foreach (WeaponRec weaponRec2 in weapons)
						{
							if (weaponRec2.int_3 == num3 && weaponRec2.CurrentLoad > 0)
							{
								if (theWeapon == null)
								{
									theWeapon = weaponRec2.get_ReferenceWeapon(ScenarioContext);
									weaponRec = weaponRec2;
								}
								num5 += weaponRec2.CurrentLoad;
							}
						}
					}
					int result;
					if (theWeapon == null)
					{
						result = 0;
					}
					else
					{
						if (num4 != 0 && !(num5 == 0 && !flag))
						{
							List<WeaponSalvo> list3 = activeUnit.get_UnitSide(SetSideOnly: false).WeaponSalvosForThisTarget(contact);
							foreach (WeaponSalvo item2 in list3)
							{
								if (item2.Target != contact || num3 != item2.int_1)
								{
									continue;
								}
								List<WeaponSalvo.Shooter> list4 = item2.ShootersList.ToList();
								foreach (WeaponSalvo.Shooter item3 in list4)
								{
									if (Operators.CompareString(item3.ShooterObjectID, activeUnit.ObjectID, false) == 0)
									{
										if (item2.WpnQuantityAssigned - item2.WpnQuantityFired + num4 > num5)
										{
											return true;
										}
										break;
									}
								}
							}
							activeUnit.AI.TargetThisContact(contact, AddedManually: true, PriorityTarget: true, targetingBehavior);
							if (Operators.CompareString(defender.ToUpper(), "BOL", false) == 0)
							{
								weaponSalvo = activeUnit.get_UnitSide(SetSideOnly: false).AssignSalvoToTarget(activeUnit.ParentScen, ref theWeapon, ref contact, num4, 0, num4, theManualFire: true, ref activeUnit.ObjectID, ref theShooterQty, value, DateTime.MinValue);
								if (list.Count > 0)
								{
									foreach (Waypoint item4 in list)
									{
										ArrayExtensions.Add(ref weaponSalvo.PlottedCourse, item4);
									}
								}
							}
							else
							{
								weaponSalvo = activeUnit.get_UnitSide(SetSideOnly: false).AssignSalvoToTarget(activeUnit.ParentScen, ref theWeapon, ref contact, num4, 0, num4, theManualFire: true, ref activeUnit.ObjectID, ref theShooterQty, value, DateTime.MinValue);
								if (list.Count > 0)
								{
									foreach (Waypoint item5 in list)
									{
										ArrayExtensions.Add(ref weaponSalvo.PlottedCourse, item5);
									}
								}
								else
								{
									activeUnit.AI.ManouverTowardsTarget(0f);
								}
							}
							int result2;
							if (!flag)
							{
								result2 = 1;
							}
							else
							{
								mount.ReloadPriority.Remove(weaponRec.int_3);
								result2 = 1;
							}
							return (byte)result2 != 0;
						}
						result = 0;
					}
					return (byte)result != 0;
				}
				result3 = 0;
			}
			else
			{
				result3 = 0;
			}
			return (byte)result3 != 0;
			IL_08ab:
			activeUnit.AI.TargetThisContact(contact, AddedManually: true, PriorityTarget: true, ActiveUnit_AI.TargetingEntry._TargetingBehavior.AutoTargeted);
			return true;
		}
		activeUnit.AI.TargetThisContact(contact, AddedManually: true, PriorityTarget: true, targetingBehavior);
		return true;
	}

	public static List<object> ScenEdit_AttackContact_Extra(string attacker, string defender, LuaTable options, Scenario ScenarioContext)
	{
		ActiveUnit activeUnit = null;
		Contact contact = null;
		ActiveUnit_AI.TargetingEntry._TargetingBehavior targetingBehavior = ActiveUnit_AI.TargetingEntry._TargetingBehavior.AutoTargeted;
		string text = null;
		double num = 0.0;
		List<Waypoint> list = new List<Waypoint>();
		List<object> list2 = new List<object>();
		Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(options.GetEnumerator());
		activeUnit = smethod_1(attacker, ScenarioContext);
		if (activeUnit != null)
		{
			contact = ValidateContactBySceanrio(defender, ScenarioContext);
			if (contact == null)
			{
				if (Operators.CompareString(defender.ToUpper(), "BOL", false) != 0)
				{
					list2.Add(false);
					return list2;
				}
				string latitudeString = null;
				if (dictionary.ContainsKey("LATITUDE"))
				{
					latitudeString = Conversions.ToString(dictionary["LATITUDE"]);
				}
				double lat = LuaUtility.ParseLatitudeString(latitudeString);
				latitudeString = "";
				if (dictionary.ContainsKey("LONGITUDE"))
				{
					latitudeString = Conversions.ToString(dictionary["LONGITUDE"]);
				}
				num = LuaUtility.ParseLongitudeString(latitudeString);
				contact = new ActivationPointContact(lat, num);
			}
			if (dictionary.ContainsKey("COURSE"))
			{
				List<object> list3 = LuaUtility.ToArray(((LuaTable)dictionary["COURSE"]).GetEnumerator());
				foreach (object item in list3)
				{
					object objectValue = RuntimeHelpers.GetObjectValue(item);
					if (objectValue is LuaTable)
					{
						Waypoint waypoint = new Waypoint(0.0, 0.0, 0f, Waypoint.WaypointType.TurningPoint, Waypoint.WaypointCreator.Manual, Waypoint.WaypointCategory.PlottedCourse);
						if (LuaWrapper_Waypoint.FromTable((LuaTable)objectValue, waypoint, ScenarioContext))
						{
							list.Add(waypoint);
						}
						continue;
					}
					throw new LuaError("Weapon Waypoint error");
				}
			}
			if (dictionary.ContainsKey("MODE"))
			{
				text = Conversions.ToString(dictionary["MODE"]);
			}
			Weapon theWeapon;
			Mount mount;
			WeaponRec weaponRec;
			Loadout loadout;
			int num2;
			int num3;
			int num4;
			int? theShooterQty;
			int num5;
			DateTime value = default(DateTime);
			WeaponSalvo weaponSalvo;
			switch (text)
			{
			case "0":
				targetingBehavior = ActiveUnit_AI.TargetingEntry._TargetingBehavior.AutoTargeted;
				goto IL_0920;
			case "1":
				targetingBehavior = ActiveUnit_AI.TargetingEntry._TargetingBehavior.ManualWeaponAlloc;
				goto IL_0299;
			case "2":
				targetingBehavior = ActiveUnit_AI.TargetingEntry._TargetingBehavior.ManualTargeted;
				goto IL_0952;
			case "3":
				targetingBehavior = ActiveUnit_AI.TargetingEntry._TargetingBehavior.AutoSelfDefence;
				goto IL_0952;
			case "ManualWeaponAlloc":
				targetingBehavior = ActiveUnit_AI.TargetingEntry._TargetingBehavior.ManualWeaponAlloc;
				goto IL_0299;
			case "ManualTargeted":
				targetingBehavior = ActiveUnit_AI.TargetingEntry._TargetingBehavior.ManualTargeted;
				goto IL_0952;
			case "AutoTargeted":
				targetingBehavior = ActiveUnit_AI.TargetingEntry._TargetingBehavior.AutoTargeted;
				goto IL_0920;
			case "AutoSelfDefence":
				targetingBehavior = ActiveUnit_AI.TargetingEntry._TargetingBehavior.AutoSelfDefence;
				goto IL_0952;
			default:
				{
					throw new LuaError("Invalid targeting behaviour");
				}
				IL_0952:
				activeUnit.AI.TargetThisContact(contact, AddedManually: true, PriorityTarget: true, targetingBehavior);
				list2.Add(true);
				return list2;
				IL_0299:
				theWeapon = null;
				mount = null;
				weaponRec = null;
				loadout = null;
				num2 = 0;
				num3 = 0;
				num4 = 0;
				theShooterQty = 1;
				num5 = 0;
				weaponSalvo = null;
				if (dictionary.ContainsKey("MOUNT"))
				{
					num2 = Conversions.ToInteger(dictionary["MOUNT"]);
				}
				if (dictionary.ContainsKey("WEAPON"))
				{
					num3 = Conversions.ToInteger(dictionary["WEAPON"]);
				}
				if (dictionary.ContainsKey("QTY"))
				{
					num4 = Conversions.ToInteger(dictionary["QTY"]);
				}
				if (dictionary.ContainsKey("DATETIME"))
				{
					DateTime? dateTime = LuaUtility.ParseDateTime_String(Conversions.ToString(dictionary["DATETIME"]), null);
					if (dateTime.HasValue)
					{
						value = dateTime.Value;
					}
				}
				if (!activeUnit.IsAircraft)
				{
					if (num2 == 0)
					{
						foreach (Mount mount2 in activeUnit.Mounts)
						{
							if (num2 == mount2.DBID)
							{
								break;
							}
							if (mount2.Status == PlatformComponent._ComponentStatus.Destroyed)
							{
								continue;
							}
							foreach (WeaponRec mountWeapon in mount2.MountWeapons)
							{
								if (mountWeapon.int_3 == num3 && mountWeapon.CurrentLoad > 0)
								{
									num2 = mount2.DBID;
									break;
								}
							}
						}
					}
				}
				else
				{
					loadout = ((Aircraft)activeUnit).Loadout;
				}
				if ((num2 != 0 || loadout != null) && num3 != 0 && num4 != 0)
				{
					bool flag = false;
					if (num2 > 0)
					{
						foreach (Mount mount3 in activeUnit.Mounts)
						{
							if (!((mount3.DBID == num2) & (mount3.Status != PlatformComponent._ComponentStatus.Destroyed)))
							{
								continue;
							}
							foreach (WeaponRec mountWeapon2 in mount3.MountWeapons)
							{
								if (mountWeapon2.int_3 != num3)
								{
									continue;
								}
								if (mountWeapon2.CurrentLoad > 0)
								{
									if (theWeapon == null)
									{
										theWeapon = mountWeapon2.get_ReferenceWeapon(ScenarioContext);
										weaponRec = mountWeapon2;
										mount = mount3;
									}
									num5 += mountWeapon2.CurrentLoad;
									if (mount3.ReloadPriority.Contains(mountWeapon2.int_3))
									{
										mount3.ReloadPriority.Remove(mountWeapon2.int_3);
									}
								}
								else
								{
									_ = activeUnit.Weaponry;
									if (mount3.MountMagazine.Weapons.Count > 0 && mount3.MountMagazine.Weapons.Count > 1 && !mountWeapon2.get_HasManualReloadPriority(mount3) && !mountWeapon2.get_ReferenceWeapon(activeUnit.ParentScen).IsDecoy && activeUnit.Weaponry.HowManyOfThisWeaponOnMountMagazine(mount3, mountWeapon2.int_3) != 0 && theWeapon == null && !mount3.ReloadPriority.Contains(mountWeapon2.int_3))
									{
										mount3.ReloadPriority.Add(mountWeapon2.int_3);
										theWeapon = mountWeapon2.get_ReferenceWeapon(ScenarioContext);
										weaponRec = mountWeapon2;
										mount = mount3;
										flag = true;
										break;
									}
								}
							}
							if (theWeapon != null)
							{
								break;
							}
						}
					}
					else if (loadout != null)
					{
						WeaponRec[] weapons = loadout.Weapons;
						foreach (WeaponRec weaponRec2 in weapons)
						{
							if (weaponRec2.int_3 == num3 && weaponRec2.CurrentLoad > 0)
							{
								if (theWeapon == null)
								{
									theWeapon = weaponRec2.get_ReferenceWeapon(ScenarioContext);
									weaponRec = weaponRec2;
								}
								num5 += weaponRec2.CurrentLoad;
							}
						}
					}
					if (theWeapon != null && num4 != 0 && !(num5 == 0 && !flag))
					{
						List<WeaponSalvo> list4 = activeUnit.get_UnitSide(SetSideOnly: false).WeaponSalvosForThisTarget(contact);
						foreach (WeaponSalvo item2 in list4)
						{
							if (item2.Target != contact || num3 != item2.int_1)
							{
								continue;
							}
							List<WeaponSalvo.Shooter> list5 = item2.ShootersList.ToList();
							foreach (WeaponSalvo.Shooter item3 in list5)
							{
								if (Operators.CompareString(item3.ShooterObjectID, activeUnit.ObjectID, false) == 0)
								{
									if (item2.WpnQuantityAssigned - item2.WpnQuantityFired + num4 > num5)
									{
										list2.Add(false);
										list2.Add(new LuaWrapper_WeaponSalvo(item2, ScenarioContext));
										return list2;
									}
									break;
								}
							}
						}
						activeUnit.AI.TargetThisContact(contact, AddedManually: true, PriorityTarget: true, targetingBehavior);
						if (Operators.CompareString(defender.ToUpper(), "BOL", false) == 0)
						{
							weaponSalvo = activeUnit.get_UnitSide(SetSideOnly: false).AssignSalvoToTarget(activeUnit.ParentScen, ref theWeapon, ref contact, num4, 0, num4, theManualFire: true, ref activeUnit.ObjectID, ref theShooterQty, value, DateTime.MinValue);
							if (weaponSalvo != null && list.Count > 0)
							{
								foreach (Waypoint item4 in list)
								{
									ArrayExtensions.Add(ref weaponSalvo.PlottedCourse, item4);
								}
							}
						}
						else
						{
							weaponSalvo = activeUnit.get_UnitSide(SetSideOnly: false).AssignSalvoToTarget(activeUnit.ParentScen, ref theWeapon, ref contact, num4, 0, num4, theManualFire: true, ref activeUnit.ObjectID, ref theShooterQty, value, DateTime.MinValue);
							if (weaponSalvo != null && list.Count > 0)
							{
								foreach (Waypoint item5 in list)
								{
									ArrayExtensions.Add(ref weaponSalvo.PlottedCourse, item5);
								}
							}
							else
							{
								activeUnit.AI.ManouverTowardsTarget(0f);
							}
						}
						if (flag)
						{
							mount.ReloadPriority.Remove(weaponRec.int_3);
						}
						list2.Add(true);
						list2.Add(new LuaWrapper_WeaponSalvo(weaponSalvo, ScenarioContext));
						return list2;
					}
					list2.Add(false);
					return list2;
				}
				list2.Add(false);
				return list2;
				IL_0920:
				activeUnit.AI.TargetThisContact(contact, AddedManually: true, PriorityTarget: true, ActiveUnit_AI.TargetingEntry._TargetingBehavior.AutoTargeted);
				list2.Add(true);
				return list2;
			}
		}
		list2.Add(false);
		return list2;
	}

	public static LuaWrapper_Zone ScenEdit_AddZone(string sideName, int zoneType, LuaTable table, Scenario ScenarioContext)
	{
		Dictionary<string, object> dict = LuaUtility.ToDictUpper(table.GetEnumerator());
		string text = null;
		Side side = null;
		Zone zone = new Zone();
		List<ReferencePoint> list = new List<ReferencePoint>();
		List<GlobalVariables.ActiveUnitType> list2 = new List<GlobalVariables.ActiveUnitType>();
		bool isLocked = false;
		bool flag = false;
		Module_Unit.Unit unit = null;
		LuaUtility.ParseUnitDict(ref dict);
		if (zoneType != 2)
		{
			side = ValidateSide(sideName, ScenarioContext);
			if (side == null)
			{
				throw new LuaError("Side " + text + " missing");
			}
		}
		if (dict.ContainsKey("DESCRIPTION"))
		{
			text = Conversions.ToString(dict["DESCRIPTION"]);
			zone.Description = text;
		}
		if (dict.ContainsKey("ISACTIVE"))
		{
			text = Conversions.ToString(dict["ISACTIVE"]);
			zone.IsActive = Conversions.ToBoolean(text);
		}
		if (dict.ContainsKey("LOCKED"))
		{
			text = Conversions.ToString(dict["LOCKED"]);
			isLocked = Conversions.ToBoolean(text);
		}
		if (dict.ContainsKey("AFFECTS"))
		{
			list2.Clear();
			List<object> list3 = LuaUtility.ToArray(((LuaTable)dict["AFFECTS"]).GetEnumerator());
			foreach (object item in list3)
			{
				string a = RuntimeHelpers.GetObjectValue(item).ToString();
				GlobalVariables.ActiveUnitType activeUnitType = GlobalVariables.ActiveUnitType.None;
				byte[] array = (byte[])Enum.GetValues(typeof(GlobalVariables.ActiveUnitType));
				int num = 0;
				while (num < array.Length)
				{
					byte b = array[num];
					if (!string.Equals(a, b.ToString(), StringComparison.OrdinalIgnoreCase))
					{
						GlobalVariables.ActiveUnitType activeUnitType2 = (GlobalVariables.ActiveUnitType)b;
						if (!string.Equals(a, activeUnitType2.ToString(), StringComparison.OrdinalIgnoreCase))
						{
							num = checked(num + 1);
							continue;
						}
					}
					activeUnitType = (GlobalVariables.ActiveUnitType)b;
					break;
				}
				if (activeUnitType != GlobalVariables.ActiveUnitType.None)
				{
					list2.Add(activeUnitType);
					continue;
				}
				throw new LuaError("Error in Affected UnitTypes!");
			}
		}
		if (dict.ContainsKey("RELATIVETO"))
		{
			string text2 = Conversions.ToString(dict["RELATIVETO"]);
			unit = ValidateAUBySide(text2, side);
			if (unit == null)
			{
				throw new LuaError("Missing unit " + text2 + " from relative bearing");
			}
		}
		if (dict.ContainsKey("AREA"))
		{
			ReferencePoint referencePoint = null;
			list.Clear();
			List<object> list4 = LuaUtility.ToArray(((LuaTable)dict["AREA"]).GetEnumerator());
			using (List<object>.Enumerator enumerator2 = list4.GetEnumerator())
			{
				_Closure$__163-0 closure$__163- = default(_Closure$__163-0);
				while (enumerator2.MoveNext())
				{
					closure$__163- = new _Closure$__163-0(closure$__163-);
					closure$__163-.$VB$Local_o = RuntimeHelpers.GetObjectValue(enumerator2.Current);
					if (!(closure$__163-.$VB$Local_o.GetType() == typeof(LuaTable)))
					{
						if (!Information.IsNothing((object)side.RefPoints.FirstOrDefault(closure$__163-._Lambda$__0)))
						{
							referencePoint = side.RefPoints.First(closure$__163-._Lambda$__1);
						}
						if (Information.IsNothing((object)referencePoint))
						{
							referencePoint = new ReferencePoint();
							referencePoint.Name = closure$__163-.$VB$Local_o.ToString();
							referencePoint.Longitude = 1.79769313486231E+308;
							referencePoint.Latitude = 1.79769313486231E+308;
							list.Add(referencePoint);
						}
						else
						{
							list.Add(referencePoint);
						}
					}
					else
					{
						LuaSandBox.Singleton().CreateTable();
						Dictionary<string, object> dict2 = LuaUtility.ToDictUpper(((LuaTable)closure$__163-.$VB$Local_o).GetEnumerator());
						Dictionary<string, object> parentDict = dict;
						ReferencePoint thisRP = null;
						referencePoint = LuaReferencePoint.ParseReferencePoint(dict2, parentDict, ScenarioContext, ref thisRP, unit);
						if (Information.IsNothing((object)referencePoint))
						{
							throw new LuaError("Can't create RP");
						}
						list.Add(referencePoint);
					}
				}
			}
			if (list == null)
			{
				throw new LuaError("Error in RP!");
			}
		}
		Misc.PostureStance theMarkViolatorAs = default(Misc.PostureStance);
		if (dict.ContainsKey("MARKAS"))
		{
			text = Conversions.ToString(dict["MARKAS"]);
			Misc.PostureStance result = Misc.PostureStance.Unknown;
			switch (text.ToUpper())
			{
			case "N":
				text = "neutral";
				break;
			case "U":
				text = "unfriendly";
				break;
			case "H":
				text = "hostile";
				break;
			case "F":
				text = "friendly";
				break;
			}
			if (Enum.TryParse<Misc.PostureStance>(text, ignoreCase: true, out result) & Enum.IsDefined(typeof(Misc.PostureStance), result))
			{
				theMarkViolatorAs = result;
			}
			else
			{
				byte[] array2 = (byte[])Enum.GetValues(typeof(Misc.PostureStance));
				int num2 = 0;
				while (num2 < array2.Length)
				{
					byte b2 = array2[num2];
					if (!string.Equals(text, b2.ToString(), StringComparison.OrdinalIgnoreCase))
					{
						string a2 = text;
						GlobalVariables.ActiveUnitType activeUnitType2 = (GlobalVariables.ActiveUnitType)b2;
						if (!string.Equals(a2, activeUnitType2.ToString(), StringComparison.OrdinalIgnoreCase))
						{
							num2 = checked(num2 + 1);
							continue;
						}
					}
					theMarkViolatorAs = (Misc.PostureStance)b2;
					break;
				}
			}
		}
		float? num3 = default(float?);
		if (dict.ContainsKey("ALTITUDEENVELOPEMIN"))
		{
			object objectValue = RuntimeHelpers.GetObjectValue(dict["ALTITUDEENVELOPEMIN"]);
			num3 = ((!(objectValue is string) || Operators.CompareString(Conversions.ToString(objectValue), "nil", false) != 0) ? new float?(Conversions.ToSingle(objectValue)) : ((float?)null));
		}
		float? num4 = default(float?);
		if (dict.ContainsKey("ALTITUDEENVELOPEMAX"))
		{
			object objectValue2 = RuntimeHelpers.GetObjectValue(dict["ALTITUDEENVELOPEMAX"]);
			num4 = ((!(objectValue2 is string) || Operators.CompareString(Conversions.ToString(objectValue2), "nil", false) != 0) ? new float?(Conversions.ToSingle(objectValue2)) : ((float?)null));
		}
		if (dict.ContainsKey("HIDDEN") && LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(dict["HIDDEN"])) == true)
		{
			flag = true;
		}
		if (dict.ContainsKey("AREACOLOR"))
		{
			zone.AreaColor = smethod_0(Conversions.ToString(dict["AREACOLOR"]).Trim());
		}
		switch (zoneType)
		{
		case -925:
		{
			Zone zone2 = new Zone(zone.Description, list);
			zone2.IsActive = zone.IsActive;
			zone2.IsLocked = isLocked;
			zone2.AreaColor = zone.AreaColor;
			zone2.AltitudeEnvelopeMin = num3;
			zone2.AltitudeEnvelopeMax = num4;
			side.StandardZones.Add(zone2);
			foreach (ReferencePoint item2 in list)
			{
				if (!flag)
				{
					if (!side.RefPoints.Contains(item2))
					{
						side.RefPoints.Add(item2);
					}
				}
				else if (side.RefPoints.Contains(item2))
				{
					side.RefPoints.Remove(item2);
				}
			}
			return new LuaWrapper_Zone(zone2, ScenarioContext, side);
		}
		case 2:
		{
			ScenarioContext.CreateNatureSideIfNeeded();
			Side natureSide = ScenarioContext.GetNatureSide();
			if (natureSide != null)
			{
				CustomEnvironmentZone customEnvironmentZone = new CustomEnvironmentZone(zone.Description, list, ScenarioContext, natureSide, new Weather.WeatherProfile());
				customEnvironmentZone.AltitudeEnvelopeMin = num3;
				customEnvironmentZone.AltitudeEnvelopeMax = num4;
				if (customEnvironmentZone != null)
				{
					customEnvironmentZone.AreaColor = zone.AreaColor;
					ArrayExtensions.Add(ref natureSide.CustomEnvironmentZones, customEnvironmentZone);
					foreach (ReferencePoint item3 in list)
					{
						if (flag)
						{
							if (natureSide.RefPoints.Contains(item3))
							{
								natureSide.RefPoints.Remove(item3);
							}
						}
						else if (!natureSide.RefPoints.Contains(item3))
						{
							natureSide.RefPoints.Add(item3);
						}
					}
					return new LuaWrapper_Zone(customEnvironmentZone, ScenarioContext, natureSide);
				}
			}
			return null;
		}
		default:
		{
			ExclusionZone exclusionZone = new ExclusionZone(zone.Description, ScenarioContext, side, list, theMarkViolatorAs, list2, num3, num4);
			exclusionZone.IsActive = zone.IsActive;
			exclusionZone.AreaColor = zone.AreaColor;
			side.ExclusionZones.Add(exclusionZone);
			foreach (ReferencePoint item4 in list)
			{
				if (flag)
				{
					if (side.RefPoints.Contains(item4))
					{
						side.RefPoints.Remove(item4);
					}
				}
				else if (!side.RefPoints.Contains(item4))
				{
					side.RefPoints.Add(item4);
				}
			}
			return new LuaWrapper_Zone(exclusionZone, ScenarioContext, side);
		}
		case 0:
		{
			NoNavZone noNavZone = new NoNavZone(zone.Description, list, ScenarioContext, side, list2);
			noNavZone.IsActive = zone.IsActive;
			noNavZone.IsLocked = isLocked;
			noNavZone.AreaColor = zone.AreaColor;
			noNavZone.AltitudeEnvelopeMin = num3;
			noNavZone.AltitudeEnvelopeMax = num4;
			side.NoNavZones.Add(noNavZone);
			foreach (ReferencePoint item5 in list)
			{
				if (!flag)
				{
					if (!side.RefPoints.Contains(item5))
					{
						side.RefPoints.Add(item5);
					}
				}
				else if (side.RefPoints.Contains(item5))
				{
					side.RefPoints.Remove(item5);
				}
			}
			return new LuaWrapper_Zone(noNavZone, ScenarioContext, side);
		}
		}
	}

	private static Color smethod_0(string string_0)
	{
		Color color = Color.FromArgb(120, 120, 120, 120);
		color = Color.FromName(string_0);
		if (!color.IsKnownColor)
		{
			Color result = default(Color);
			try
			{
				if (!string_0.StartsWith("#"))
				{
					if (string_0.Length != 6 && string_0.Length != 8)
					{
						int[] array = (from p in string_0.Split(new char[1] { ',' })
							select int.Parse(p.Trim())).ToArray();
						switch (array.Length)
						{
						default:
							throw new FormatException("Invalid color format.");
						case 4:
							result = Color.FromArgb(array[0], array[1], array[2], array[3]);
							return result;
						case 3:
							result = Color.FromArgb(255, array[0], array[1], array[2]);
							return result;
						}
					}
					result = ColorTranslator.FromHtml("#" + string_0);
					return result;
				}
				result = ColorTranslator.FromHtml(string_0);
				return result;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at PM154", "Invalid color format: " + string_0);
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			return result;
		}
		return color;
	}

	public static LuaWrapper_Zone ScenEdit_GetZone(string sideNameId, string zoneNameId, int? zoneType, Scenario ScenarioContext)
	{
		Side side = null;
		new Zone();
		try
		{
			int? num = zoneType;
			if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 2)) == true)
			{
				side = ScenarioContext.GetNatureSide();
				if (side == null)
				{
					throw new LuaError("No Nature Side ");
				}
			}
			else
			{
				side = ValidateSide(sideNameId, ScenarioContext);
			}
			if (side == null)
			{
				throw new LuaError("Side " + sideNameId + " missing");
			}
			num = zoneType;
			if (((!num.HasValue) ? ((bool?)null) : new bool?(num.GetValueOrDefault() == 0)) == true || !zoneType.HasValue)
			{
				NoNavZone noNavZone = null;
				foreach (NoNavZone noNavZone2 in side.NoNavZones)
				{
					if (Operators.CompareString(noNavZone2.ObjectID, zoneNameId, false) == 0 || Operators.CompareString(noNavZone2.Name, zoneNameId, false) == 0 || Operators.CompareString(noNavZone2.Description, zoneNameId, false) == 0)
					{
						noNavZone = noNavZone2;
						break;
					}
				}
				if (noNavZone == null && zoneType.HasValue)
				{
					throw new LuaError("No no-nav zone exists with this name or ID.");
				}
				return new LuaWrapper_Zone(noNavZone, ScenarioContext, side);
			}
			num = zoneType;
			if ((num.HasValue ? new bool?(num == 1) : ((bool?)null)) == true || !zoneType.HasValue)
			{
				ExclusionZone exclusionZone = null;
				foreach (ExclusionZone exclusionZone2 in side.ExclusionZones)
				{
					if (Operators.CompareString(exclusionZone2.ObjectID, zoneNameId, false) == 0 || Operators.CompareString(exclusionZone2.Name, zoneNameId, false) == 0 || Operators.CompareString(exclusionZone2.Description, zoneNameId, false) == 0)
					{
						exclusionZone = exclusionZone2;
						break;
					}
				}
				if (exclusionZone == null && zoneType.HasValue)
				{
					throw new LuaError("No exclusion zone exists with this name or ID.");
				}
				return new LuaWrapper_Zone(exclusionZone, ScenarioContext, side);
			}
			num = zoneType;
			if ((num.HasValue ? new bool?(num == 2) : ((bool?)null)) == true || !zoneType.HasValue)
			{
				Zone zone = null;
				CustomEnvironmentZone[] customEnvironmentZones = side.CustomEnvironmentZones;
				foreach (Zone zone2 in customEnvironmentZones)
				{
					if (Operators.CompareString(zone2.ObjectID, zoneNameId, false) == 0 || Operators.CompareString(zone2.Name, zoneNameId, false) == 0 || Operators.CompareString(zone2.Description, zoneNameId, false) == 0)
					{
						zone = zone2;
						break;
					}
				}
				if (zone == null && zoneType.HasValue)
				{
					throw new LuaError("No environment zone exists with this name or ID.");
				}
				return new LuaWrapper_Zone(zone, ScenarioContext, side);
			}
			num = zoneType;
			if ((num.HasValue ? new bool?(num == -925) : ((bool?)null)) == true || !zoneType.HasValue)
			{
				Zone zone3 = null;
				foreach (Zone standardZone in side.StandardZones)
				{
					if (Operators.CompareString(standardZone.ObjectID, zoneNameId, false) == 0 || Operators.CompareString(standardZone.Name, zoneNameId, false) == 0 || Operators.CompareString(standardZone.Description, zoneNameId, false) == 0)
					{
						zone3 = standardZone;
						break;
					}
				}
				if (zone3 == null && zoneType.HasValue)
				{
					throw new LuaError("No standard zone exists with this name or ID.");
				}
				return new LuaWrapper_Zone(zone3, ScenarioContext, side);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			if (ex2 is LuaError)
			{
				object[] array = new object[2];
				array[1] = ((LuaError)ex2).sMessage;
				array[0] = ((LuaError)ex2).sFunctionName + " " + ((LuaError)ex2).sLine + " : ";
			}
			ProjectData.ClearProjectError();
		}
		return null;
	}

	public static LuaWrapper_Zone ScenEdit_SetZone(string sideName, int zoneType, LuaTable table, Scenario ScenarioContext)
	{
		Dictionary<string, object> dict = LuaUtility.ToDictUpper(table.GetEnumerator());
		string text = null;
		Side side = null;
		Zone zone = new Zone();
		List<ReferencePoint> list = new List<ReferencePoint>();
		List<GlobalVariables.ActiveUnitType> list2 = new List<GlobalVariables.ActiveUnitType>();
		bool isLocked = false;
		bool flag = false;
		LuaUtility.ParseUnitDict(ref dict);
		side = ValidateSide(sideName, ScenarioContext);
		if (side != null)
		{
			if (dict.ContainsKey("LAYER"))
			{
				zone.set_Layer(side, Conversions.ToInteger(dict["LAYER"]));
			}
			if (dict.ContainsKey("DESCRIPTION"))
			{
				text = Conversions.ToString(dict["DESCRIPTION"]);
				zone.Description = text;
			}
			if (dict.ContainsKey("AREACOLOR"))
			{
				zone.AreaColor = smethod_0(Conversions.ToString(dict["AREACOLOR"]));
			}
			if (dict.ContainsKey("ISACTIVE"))
			{
				text = Conversions.ToString(dict["ISACTIVE"]);
				zone.IsActive = Conversions.ToBoolean(text);
			}
			if (dict.ContainsKey("LOCKED"))
			{
				text = Conversions.ToString(dict["LOCKED"]);
				isLocked = Conversions.ToBoolean(text);
			}
			if (dict.ContainsKey("RENAME"))
			{
				text = Conversions.ToString(dict["RENAME"]);
				zone.Name = text;
			}
			if (dict.ContainsKey("AFFECTS"))
			{
				list2.Clear();
				List<object> list3 = LuaUtility.ToArray(((LuaTable)dict["AFFECTS"]).GetEnumerator());
				foreach (object item in list3)
				{
					string a = RuntimeHelpers.GetObjectValue(item).ToString().ToLower();
					GlobalVariables.ActiveUnitType activeUnitType = GlobalVariables.ActiveUnitType.None;
					byte[] array = (byte[])Enum.GetValues(typeof(GlobalVariables.ActiveUnitType));
					int num = 0;
					while (num < array.Length)
					{
						byte b = array[num];
						if (!string.Equals(a, b.ToString(), StringComparison.OrdinalIgnoreCase))
						{
							GlobalVariables.ActiveUnitType activeUnitType2 = (GlobalVariables.ActiveUnitType)b;
							if (!string.Equals(a, activeUnitType2.ToString(), StringComparison.OrdinalIgnoreCase))
							{
								num = checked(num + 1);
								continue;
							}
						}
						activeUnitType = (GlobalVariables.ActiveUnitType)b;
						break;
					}
					if (activeUnitType != GlobalVariables.ActiveUnitType.None)
					{
						list2.Add(activeUnitType);
						continue;
					}
					throw new LuaError("Error in Affected UnitTypes!");
				}
			}
			if (dict.ContainsKey("AREA"))
			{
				list.Clear();
				List<object> list4 = LuaUtility.ToArray(((LuaTable)dict["AREA"]).GetEnumerator());
				using (List<object>.Enumerator enumerator2 = list4.GetEnumerator())
				{
					_Closure$__166-0 closure$__166- = default(_Closure$__166-0);
					while (enumerator2.MoveNext())
					{
						closure$__166- = new _Closure$__166-0(closure$__166-);
						closure$__166-.$VB$Local_o = RuntimeHelpers.GetObjectValue(enumerator2.Current);
						ReferencePoint referencePoint = null;
						if (!(closure$__166-.$VB$Local_o is LuaTable))
						{
							if (!Information.IsNothing((object)side.RefPoints.FirstOrDefault(closure$__166-._Lambda$__0)))
							{
								referencePoint = side.RefPoints.First(closure$__166-._Lambda$__1);
							}
							if (!Information.IsNothing((object)referencePoint))
							{
								list.Add(referencePoint);
								continue;
							}
							referencePoint = new ReferencePoint();
							referencePoint.Name = closure$__166-.$VB$Local_o.ToString();
							referencePoint.Longitude = 1.79769313486231E+308;
							referencePoint.Latitude = 1.79769313486231E+308;
							list.Add(referencePoint);
							continue;
						}
						string text2 = "";
						double? num2 = null;
						double? num3 = null;
						Module_Unit.Unit unit = null;
						double? num4 = null;
						double? num5 = null;
						Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(((LuaTable)closure$__166-.$VB$Local_o).GetEnumerator());
						if (dictionary.ContainsKey("HIDDEN"))
						{
							flag = true;
						}
						text2 = (string)(dictionary.ContainsKey("NAME") ? Conversions.ToString(dictionary["NAME"]) : (dictionary["NAME"] = "RP-" + Conversions.ToString(Interlocked.Increment(ref ScenarioContext.UnitsAutoIncrement))));
						int assignObjectID;
						if (dictionary.ContainsKey("BEARING") && dictionary.ContainsKey("DISTANCE"))
						{
							if (Information.IsNothing((object)unit))
							{
								throw new LuaError("No unit defined for relative bearing");
							}
							num4 = Conversions.ToDouble(dictionary["BEARING"]);
							num5 = Conversions.ToDouble(dictionary["DISTANCE"]);
							Geodesic_Vincenty.TCoord Pt = new Geodesic_Vincenty.TCoord(unit.get_Latitude((GlobalVariables.BooleanObject)null), unit.get_Longitude((GlobalVariables.BooleanObject)null));
							Geodesic_Vincenty.TCoord Ret = default(Geodesic_Vincenty.TCoord);
							Geodesic_Vincenty.fw_vincenty_wgs84(ref Pt, ref Ret, num4.Value, num5.Value);
							num2 = Ret.Lat;
							num3 = Ret.Lon;
							assignObjectID = 1;
						}
						else
						{
							num2 = LuaUtility.QueryLatitude(dictionary);
							if (!num2.HasValue)
							{
								throw new LuaError("Missing 'Latitude'");
							}
							num3 = LuaUtility.QueryLongitude(dictionary);
							if (!num3.HasValue)
							{
								throw new LuaError("Missing 'Longitude'");
							}
							assignObjectID = 1;
						}
						referencePoint = new ReferencePoint((byte)assignObjectID != 0);
						referencePoint.Longitude = num3.Value;
						referencePoint.Latitude = num2.Value;
						referencePoint.Name = text2;
						list.Add(referencePoint);
					}
				}
				if (list == null)
				{
					throw new LuaError("Error in RP!");
				}
				if (!flag)
				{
					foreach (ReferencePoint item2 in list)
					{
						if (item2.Longitude != 1.79769313486231E+308 && !side.RefPoints.Contains(item2))
						{
							side.RefPoints.Add(item2);
						}
					}
				}
			}
			Misc.PostureStance markViolatorAs = default(Misc.PostureStance);
			if (dict.ContainsKey("MARKAS"))
			{
				text = Conversions.ToString(dict["MARKAS"]);
				Misc.PostureStance result = Misc.PostureStance.Unknown;
				if (!(Enum.TryParse<Misc.PostureStance>(text, ignoreCase: true, out result) & Enum.IsDefined(typeof(Misc.PostureStance), result)))
				{
					byte[] array2 = (byte[])Enum.GetValues(typeof(Misc.PostureStance));
					int num6 = 0;
					while (num6 < array2.Length)
					{
						byte b2 = array2[num6];
						if (!string.Equals(text, b2.ToString(), StringComparison.OrdinalIgnoreCase))
						{
							string a2 = text;
							GlobalVariables.ActiveUnitType activeUnitType2 = (GlobalVariables.ActiveUnitType)b2;
							if (!string.Equals(a2, activeUnitType2.ToString(), StringComparison.OrdinalIgnoreCase))
							{
								num6 = checked(num6 + 1);
								continue;
							}
						}
						markViolatorAs = (Misc.PostureStance)b2;
						break;
					}
				}
				else
				{
					markViolatorAs = result;
				}
			}
			float? altitudeEnvelopeMin = default(float?);
			if (dict.ContainsKey("ALTITUDEENVELOPEMIN"))
			{
				object objectValue = RuntimeHelpers.GetObjectValue(dict["ALTITUDEENVELOPEMIN"]);
				altitudeEnvelopeMin = ((!(objectValue is string) || Operators.CompareString(Conversions.ToString(objectValue), "nil", false) != 0) ? new float?(Conversions.ToSingle(objectValue)) : ((float?)null));
			}
			float? altitudeEnvelopeMax = default(float?);
			if (dict.ContainsKey("ALTITUDEENVELOPEMAX"))
			{
				object objectValue2 = RuntimeHelpers.GetObjectValue(dict["ALTITUDEENVELOPEMAX"]);
				altitudeEnvelopeMax = ((!(objectValue2 is string) || Operators.CompareString(Conversions.ToString(objectValue2), "nil", false) != 0) ? new float?(Conversions.ToSingle(objectValue2)) : ((float?)null));
			}
			switch (zoneType)
			{
			case 0:
			{
				NoNavZone noNavZone = null;
				foreach (NoNavZone noNavZone2 in side.NoNavZones)
				{
					if (Operators.CompareString(noNavZone2.ObjectID, zone.Description, false) == 0 || Operators.CompareString(noNavZone2.Name, zone.Description, false) == 0 || Operators.CompareString(noNavZone2.Description, zone.Description, false) == 0)
					{
						noNavZone = noNavZone2;
						break;
					}
				}
				if (Information.IsNothing((object)noNavZone))
				{
					throw new LuaError("No no-nav zone exists with this name or ID.");
				}
				if (dict.ContainsKey("DESCRIPTION"))
				{
					noNavZone.Description = zone.Description;
				}
				if (dict.ContainsKey("AREACOLOR"))
				{
					noNavZone.AreaColor = zone.AreaColor;
				}
				if (dict.ContainsKey("ISACTIVE"))
				{
					noNavZone.IsActive = zone.IsActive;
				}
				if (dict.ContainsKey("LOCKED"))
				{
					noNavZone.IsLocked = isLocked;
				}
				if (dict.ContainsKey("RENAME"))
				{
					noNavZone.Description = zone.Name;
				}
				if (dict.ContainsKey("AFFECTS"))
				{
					noNavZone.AffectedUnitTypes = new ObservableList<GlobalVariables.ActiveUnitType>();
					foreach (GlobalVariables.ActiveUnitType item3 in list2)
					{
						noNavZone.AffectedUnitTypes.Add(item3);
					}
				}
				if (dict.ContainsKey("ALTITUDEENVELOPEMIN"))
				{
					noNavZone.AltitudeEnvelopeMin = altitudeEnvelopeMin;
				}
				if (dict.ContainsKey("ALTITUDEENVELOPEMAX"))
				{
					noNavZone.AltitudeEnvelopeMax = altitudeEnvelopeMax;
				}
				if (dict.ContainsKey("AREA"))
				{
					using (List<ReferencePoint>.Enumerator enumerator9 = noNavZone.Area.GetEnumerator())
					{
						_Closure$__166-1 closure$__166-3 = default(_Closure$__166-1);
						while (enumerator9.MoveNext())
						{
							closure$__166-3 = new _Closure$__166-1(closure$__166-3);
							closure$__166-3.$VB$Local_z = enumerator9.Current;
							if (list.First(closure$__166-3._Lambda$__2) != null)
							{
							}
						}
					}
					noNavZone.Area = new ObservableList<ReferencePoint>(list);
				}
				return new LuaWrapper_Zone(noNavZone, ScenarioContext, side);
			}
			case -925:
			{
				Zone zone2 = null;
				foreach (Zone standardZone in side.StandardZones)
				{
					if (Operators.CompareString(standardZone.ObjectID, zone.Description, false) == 0 || Operators.CompareString(standardZone.Name, zone.Description, false) == 0 || Operators.CompareString(standardZone.Description, zone.Description, false) == 0)
					{
						zone2 = standardZone;
						break;
					}
				}
				if (!Information.IsNothing((object)zone2))
				{
					if (dict.ContainsKey("DESCRIPTION"))
					{
						zone2.Description = zone.Description;
					}
					if (dict.ContainsKey("AREACOLOR"))
					{
						zone2.AreaColor = zone.AreaColor;
					}
					if (dict.ContainsKey("ISACTIVE"))
					{
						zone2.IsActive = zone.IsActive;
					}
					if (dict.ContainsKey("LOCKED"))
					{
						zone2.IsLocked = isLocked;
					}
					if (dict.ContainsKey("RENAME"))
					{
						zone2.Description = zone.Name;
					}
					if (dict.ContainsKey("AFFECTS"))
					{
						zone2.AffectedUnitTypes = new ObservableList<GlobalVariables.ActiveUnitType>();
						foreach (GlobalVariables.ActiveUnitType item4 in list2)
						{
							zone2.AffectedUnitTypes.Add(item4);
						}
					}
					if (dict.ContainsKey("ALTITUDEENVELOPEMIN"))
					{
						zone2.AltitudeEnvelopeMin = altitudeEnvelopeMin;
					}
					if (dict.ContainsKey("ALTITUDEENVELOPEMAX"))
					{
						zone2.AltitudeEnvelopeMax = altitudeEnvelopeMax;
					}
					if (dict.ContainsKey("AREA"))
					{
						using (List<ReferencePoint>.Enumerator enumerator12 = zone2.Area.GetEnumerator())
						{
							_Closure$__166-2 closure$__166-4 = default(_Closure$__166-2);
							while (enumerator12.MoveNext())
							{
								closure$__166-4 = new _Closure$__166-2(closure$__166-4);
								closure$__166-4.$VB$Local_z = enumerator12.Current;
								if (list.First(closure$__166-4._Lambda$__3) == null)
								{
								}
							}
						}
						zone2.Area = new ObservableList<ReferencePoint>(list);
					}
					return new LuaWrapper_Zone(zone2, ScenarioContext, side);
				}
				throw new LuaError("No no-nav zone exists with this name or ID.");
			}
			case 2:
				throw new LuaError("Use scenario side object function side:getcustomenvironmentzone() to change values on CustomEnvironmentZones.");
			default:
			{
				ExclusionZone exclusionZone = null;
				foreach (ExclusionZone exclusionZone2 in side.ExclusionZones)
				{
					if (Operators.CompareString(exclusionZone2.ObjectID, zone.Description, false) == 0 || Operators.CompareString(exclusionZone2.Name, zone.Description, false) == 0 || Operators.CompareString(exclusionZone2.Description, zone.Description, false) == 0)
					{
						exclusionZone = exclusionZone2;
						break;
					}
				}
				if (!Information.IsNothing((object)exclusionZone))
				{
					if (dict.ContainsKey("DESCRIPTION"))
					{
						exclusionZone.Description = zone.Description;
					}
					if (dict.ContainsKey("AREACOLOR"))
					{
						exclusionZone.AreaColor = zone.AreaColor;
					}
					if (dict.ContainsKey("ISACTIVE"))
					{
						exclusionZone.IsActive = zone.IsActive;
					}
					if (dict.ContainsKey("RENAME"))
					{
						exclusionZone.Description = zone.Name;
					}
					if (dict.ContainsKey("AFFECTS"))
					{
						exclusionZone.AffectedUnitTypes = new ObservableList<GlobalVariables.ActiveUnitType>();
						foreach (GlobalVariables.ActiveUnitType item5 in list2)
						{
							exclusionZone.AffectedUnitTypes.Add(item5);
						}
					}
					if (dict.ContainsKey("MARKAS"))
					{
						exclusionZone.MarkViolatorAs = markViolatorAs;
					}
					if (dict.ContainsKey("ALTITUDEENVELOPEMIN"))
					{
						exclusionZone.AltitudeEnvelopeMin = altitudeEnvelopeMin;
					}
					if (dict.ContainsKey("ALTITUDEENVELOPEMAX"))
					{
						exclusionZone.AltitudeEnvelopeMax = altitudeEnvelopeMax;
					}
					if (dict.ContainsKey("AREA"))
					{
						using (List<ReferencePoint>.Enumerator enumerator6 = exclusionZone.Area.GetEnumerator())
						{
							_Closure$__166-3 closure$__166-2 = default(_Closure$__166-3);
							while (enumerator6.MoveNext())
							{
								closure$__166-2 = new _Closure$__166-3(closure$__166-2);
								closure$__166-2.$VB$Local_z = enumerator6.Current;
								if (list.First(closure$__166-2._Lambda$__4) == null)
								{
								}
							}
						}
						exclusionZone.Area = new ObservableList<ReferencePoint>(list);
					}
					return new LuaWrapper_Zone(exclusionZone, ScenarioContext, side);
				}
				throw new LuaError("No exclusion zone exists with this name or ID.");
			}
			}
		}
		throw new LuaError("Side " + text + " missing");
	}

	public static LuaWrapper_Zone ScenEdit_RemoveZone(string sideName, int zoneType, LuaTable table, Scenario ScenarioContext)
	{
		Dictionary<string, object> dict = LuaUtility.ToDictUpper(table.GetEnumerator());
		string text = null;
		Side side = null;
		Zone zone = new Zone();
		new List<ReferencePoint>();
		new List<GlobalVariables.ActiveUnitType>();
		LuaUtility.ParseUnitDict(ref dict);
		side = ValidateSide(sideName, ScenarioContext);
		if (side != null)
		{
			if (dict.ContainsKey("DESCRIPTION"))
			{
				text = Conversions.ToString(dict["DESCRIPTION"]);
				zone.Description = text;
			}
			switch (zoneType)
			{
			case 2:
				if (side == ScenarioContext.GetNatureSide())
				{
					CustomEnvironmentZone customEnvironmentZone = null;
					CustomEnvironmentZone[] customEnvironmentZones = side.CustomEnvironmentZones;
					foreach (CustomEnvironmentZone customEnvironmentZone2 in customEnvironmentZones)
					{
						if (Operators.CompareString(customEnvironmentZone2.ObjectID, zone.Description, false) == 0 || Operators.CompareString(customEnvironmentZone2.Name, zone.Description, false) == 0 || Operators.CompareString(customEnvironmentZone2.Description, zone.Description, false) == 0)
						{
							customEnvironmentZone = customEnvironmentZone2;
						}
					}
					if (customEnvironmentZone == null)
					{
						throw new LuaError("No Custom Environment Zone exists with this name or ID.");
					}
					ArrayExtensions.Remove(ref side.CustomEnvironmentZones, customEnvironmentZone);
					return null;
				}
				throw new LuaError("Custom Environment Zones side must be scenario 'nature' side.");
			case -925:
			{
				Zone zone2 = null;
				foreach (Zone standardZone in side.StandardZones)
				{
					if (Operators.CompareString(standardZone.ObjectID, zone.Description, false) == 0 || Operators.CompareString(standardZone.Name, zone.Description, false) == 0 || Operators.CompareString(standardZone.Description, zone.Description, false) == 0)
					{
						zone2 = standardZone;
						break;
					}
				}
				if (!Information.IsNothing((object)zone))
				{
					side.StandardZones.Remove(zone2);
					return new LuaWrapper_Zone(zone2, ScenarioContext, side);
				}
				throw new LuaError("No standard zone exists with this name or ID.");
			}
			default:
			{
				ExclusionZone exclusionZone = null;
				foreach (ExclusionZone exclusionZone2 in side.ExclusionZones)
				{
					if (Operators.CompareString(exclusionZone2.ObjectID, zone.Description, false) == 0 || Operators.CompareString(exclusionZone2.Name, zone.Description, false) == 0 || Operators.CompareString(exclusionZone2.Description, zone.Description, false) == 0)
					{
						exclusionZone = exclusionZone2;
						break;
					}
				}
				if (Information.IsNothing((object)zone))
				{
					throw new LuaError("No exclusion zone exists with this name or ID.");
				}
				side.ExclusionZones.Remove(exclusionZone);
				return new LuaWrapper_Zone(exclusionZone, ScenarioContext, side);
			}
			case 0:
			{
				NoNavZone noNavZone = null;
				foreach (NoNavZone noNavZone2 in side.NoNavZones)
				{
					if (Operators.CompareString(noNavZone2.ObjectID, zone.Description, false) == 0 || Operators.CompareString(noNavZone2.Name, zone.Description, false) == 0 || Operators.CompareString(noNavZone2.Description, zone.Description, false) == 0)
					{
						noNavZone = noNavZone2;
						break;
					}
				}
				if (!Information.IsNothing((object)zone))
				{
					side.NoNavZones.Remove(noNavZone);
					return new LuaWrapper_Zone(noNavZone, ScenarioContext, side);
				}
				throw new LuaError("No no-nav zone exists with this name or ID.");
			}
			}
		}
		throw new LuaError("Side " + text + " missing");
	}

	public static bool ScenEdit_IsUnitInZone(string TheUnit_NameOrID, string TheZone_NameOrID, string Side_NameOrID, Scenario ScenarioContext)
	{
		ActiveUnit theUnit = smethod_1(TheUnit_NameOrID, ScenarioContext);
		Side side = LuaUtility.QuerySideObject(Side_NameOrID, ScenarioContext);
		Zone zone = null;
		foreach (Zone standardZone in side.StandardZones)
		{
			if (Operators.CompareString(TheZone_NameOrID, standardZone.Description, false) == 0 || Operators.CompareString(TheZone_NameOrID, standardZone.ObjectID, false) == 0)
			{
				zone = standardZone;
				break;
			}
		}
		if (Information.IsNothing((object)zone))
		{
			return false;
		}
		return zone.IsInArea(theUnit);
	}

	public static bool ScenEdit_TransferCargo(string fromName, string toName, LuaTable cargoList, Scenario ScenarioContext)
	{
		bool result = false;
		List<Cargo> list = new List<Cargo>();
		new List<ActiveUnit>();
		ActiveUnit activeUnit = null;
		ActiveUnit activeUnit2 = null;
		try
		{
			activeUnit = smethod_1(fromName, ScenarioContext);
			activeUnit2 = smethod_1(toName, ScenarioContext);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at PM156", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		if (!Information.IsNothing((object)activeUnit))
		{
			if (Information.IsNothing((object)activeUnit2))
			{
				throw new LuaError("To unit not found!");
			}
			ActiveUnit activeUnit3 = null;
			ActiveUnit activeUnit4 = null;
			switch (activeUnit.UnitType)
			{
			case GlobalVariables.ActiveUnitType.Aircraft:
				if (((Aircraft_AirOps)activeUnit.AirOps).CanBeRearmedRightNow())
				{
					activeUnit3 = ((Aircraft)activeUnit).AirOps.CurrentHostUnit;
					break;
				}
				throw new LuaError("From unit not available: not parked!");
			case GlobalVariables.ActiveUnitType.Ship:
			case GlobalVariables.ActiveUnitType.Submarine:
				if (activeUnit.DockingOps.CurrentHostUnit != null)
				{
					activeUnit3 = activeUnit.DockingOps.CurrentHostUnit;
					break;
				}
				throw new LuaError("From unit not available: Not docked!");
			default:
				throw new LuaError("From unit is not cargo capable.");
			case GlobalVariables.ActiveUnitType.Facility:
			case GlobalVariables.ActiveUnitType.Vehicle:
				if (activeUnit.DockingOps.Condition == ActiveUnit_DockingOps._DockingOpsCondition.LoadedAsCargo)
				{
					throw new LuaError("From unit not available: it is in cargo!");
				}
				if (activeUnit.DockingOps.Condition == ActiveUnit_DockingOps._DockingOpsCondition.Docked)
				{
					activeUnit3 = activeUnit.DockingOps.CurrentHostUnit;
				}
				break;
			}
			if (activeUnit3 != null && activeUnit3.IsFixedFacility && activeUnit3.IsGroupMember())
			{
				activeUnit3 = activeUnit3.get_ParentGroup(UsingMissionPlanner: false);
			}
			switch (activeUnit2.UnitType)
			{
			case GlobalVariables.ActiveUnitType.Aircraft:
				if (!((Aircraft_AirOps)activeUnit2.AirOps).CanBeRearmedRightNow())
				{
					throw new LuaError("To unit not available: not parked!");
				}
				activeUnit4 = ((Aircraft)activeUnit2).AirOps.CurrentHostUnit;
				break;
			case GlobalVariables.ActiveUnitType.Ship:
			case GlobalVariables.ActiveUnitType.Submarine:
				if (activeUnit2.DockingOps.CurrentHostUnit != null)
				{
					activeUnit4 = activeUnit2.DockingOps.CurrentHostUnit;
					break;
				}
				throw new LuaError("To unit not available: Not docked!");
			default:
				throw new LuaError("To unit is not cargo capable.");
			case GlobalVariables.ActiveUnitType.Facility:
			case GlobalVariables.ActiveUnitType.Vehicle:
				if (activeUnit2.DockingOps.Condition == ActiveUnit_DockingOps._DockingOpsCondition.LoadedAsCargo)
				{
					throw new LuaError("To unit not available: it is in cargo!");
				}
				if (activeUnit.DockingOps.Condition == ActiveUnit_DockingOps._DockingOpsCondition.Docked)
				{
					activeUnit4 = activeUnit2.DockingOps.CurrentHostUnit;
				}
				break;
			}
			if (activeUnit4 != null && activeUnit4.IsFixedFacility && activeUnit4.IsGroupMember())
			{
				activeUnit4 = activeUnit4.get_ParentGroup(UsingMissionPlanner: false);
			}
			if (activeUnit4 != null && activeUnit3 != null)
			{
				if (activeUnit4 != activeUnit3)
				{
					throw new LuaError("From unit and To unit are at different host facilities!");
				}
			}
			else if (activeUnit.RangeToUnit_Horiz(activeUnit2) > 2f)
			{
				throw new LuaError("From unit and To unit are beyond 2nm cargo transfer range!");
			}
			try
			{
				List<object> list2 = LuaUtility.ToArray(cargoList.GetEnumerator());
				ICargoHost obj = (ICargoHost)activeUnit2;
				double num = 0.0;
				double num2 = 0.0;
				double num3 = 0.0;
				CargoType cargoType = CargoType.NoCargo;
				num = CargoHostHelper.GetAvailableMass(obj, obj.CargoArray);
				num2 = CargoHostHelper.GetAvailableArea(obj, obj.CargoArray);
				num3 = CargoHostHelper.GetAvailableCrewSpace(obj, obj.CargoArray);
				cargoType = obj.GetCargo_Type();
				foreach (object item in list2)
				{
					object objectValue = RuntimeHelpers.GetObjectValue(item);
					int num4 = 0;
					int num5 = 0;
					string text = null;
					if (!(objectValue is LuaTable))
					{
						text = Conversions.ToString(objectValue);
						num4 = 1;
					}
					else
					{
						List<object> list3 = LuaUtility.ToArray(((LuaTable)objectValue).GetEnumerator());
						if (list3.Count == 1)
						{
							num5 = Conversions.ToInteger(list3[0]);
							num4 = 1;
						}
						else
						{
							num5 = Conversions.ToInteger(list3[1]);
							num4 = Conversions.ToInteger(list3[0]);
						}
					}
					if (num4 < 1 || (num5 < 1 && Information.IsNothing((object)text)))
					{
						continue;
					}
					Cargo[] onboardCargo = activeUnit.OnboardCargo;
					foreach (Cargo cargo in onboardCargo)
					{
						if (cargo.RequiredCargoType <= cargoType && (num5 <= 0 || cargo.CargoObjectDBID == num5) && (Information.IsNothing((object)text) || Operators.CompareString(text, cargo.CargoObjectID, false) == 0))
						{
							if (num4 > 0 && ((num >= (double)cargo.RequiredMass) & (num2 >= (double)cargo.RequiredArea) & (num3 >= (double)cargo.RequiredCrewSpace)))
							{
								list.Add(cargo);
								num -= (double)cargo.RequiredMass;
								num2 -= (double)cargo.RequiredArea;
								num3 -= (double)cargo.RequiredCrewSpace;
								num4--;
							}
							if (num4 < 1)
							{
								break;
							}
						}
					}
				}
				int num6 = activeUnit.OnboardCargo.Count();
				if (list.Count > 0)
				{
					ActiveUnit_DockingOps.PerformCargoTransferBetweenHostAndTarget(activeUnit, activeUnit2, list);
					if (!(activeUnit2 is Ship))
					{
						if (!(activeUnit2 is Aircraft))
						{
							if (activeUnit2 is Vehicle)
							{
								if (activeUnit2.DockingOps.Condition == ActiveUnit_DockingOps._DockingOpsCondition.Docked)
								{
									activeUnit2.DockingOps.Condition = ActiveUnit_DockingOps._DockingOpsCondition.Readying;
								}
								else
								{
									activeUnit2.DockingOps.Condition = ActiveUnit_DockingOps._DockingOpsCondition.TransferringCargo;
								}
								activeUnit2.DockingOps.ConditionTimer = Math.Max(activeUnit2.DockingOps.ConditionTimer, ActiveUnit_DockingOps.TimeToLoadCargo(activeUnit2, list));
							}
						}
						else
						{
							((Aircraft)activeUnit2).AirOps.Condition = Aircraft_AirOps._AirOpsCondition.Readying;
							((Aircraft)activeUnit2).AirOps.ConditionTimer = Math.Max(((Aircraft)activeUnit2).AirOps.ConditionTimer, ActiveUnit_DockingOps.TimeToLoadCargo(activeUnit2, list));
						}
					}
					else
					{
						activeUnit2.DockingOps.Condition = ActiveUnit_DockingOps._DockingOpsCondition.Readying;
						activeUnit2.DockingOps.ConditionTimer = Math.Max(activeUnit2.DockingOps.ConditionTimer, ActiveUnit_DockingOps.TimeToLoadCargo(activeUnit2, list));
					}
					if (num6 > activeUnit.OnboardCargo.Count())
					{
						result = true;
					}
				}
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				ex4?.Data.Add("Error at PM157", "");
				GameGeneral.WriteExceptionsToLog(ex4);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
			return result;
		}
		throw new LuaError("From unit not found!");
	}

	public static bool ScenEdit_UnloadCargo(string fromName, LuaTable cargoList, Scenario ScenarioContext)
	{
		bool flag = false;
		List<Cargo> list = new List<Cargo>();
		ActiveUnit activeUnit = null;
		try
		{
			activeUnit = smethod_1(fromName, ScenarioContext);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at PM158", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		if (!Information.IsNothing((object)activeUnit))
		{
			if (activeUnit.HasCargo)
			{
				List<object> list2 = new List<object>();
				if (!Information.IsNothing((object)cargoList))
				{
					list2 = LuaUtility.ToArray(cargoList.GetEnumerator());
				}
				try
				{
					if (list2.Count > 0)
					{
						foreach (object item in list2)
						{
							object objectValue = RuntimeHelpers.GetObjectValue(item);
							int num = 0;
							int num2 = 0;
							string text = null;
							if (!(objectValue is LuaTable))
							{
								text = Conversions.ToString(objectValue);
								num = 1;
							}
							else
							{
								List<object> list3 = LuaUtility.ToArray(((LuaTable)objectValue).GetEnumerator());
								if (list3.Count == 1)
								{
									num2 = Conversions.ToInteger(list3[0]);
									num = 1;
								}
								else
								{
									num2 = Conversions.ToInteger(list3[1]);
									num = Conversions.ToInteger(list3[0]);
								}
							}
							if (num < 1 || (num2 < 1 && Information.IsNothing((object)text)))
							{
								continue;
							}
							Cargo[] onboardCargo = activeUnit.OnboardCargo;
							foreach (Cargo cargo in onboardCargo)
							{
								if ((num2 <= 0 || cargo.CargoObjectDBID == num2) && (Information.IsNothing((object)text) || Operators.CompareString(text, cargo.CargoObjectID, false) == 0))
								{
									if (num > 0)
									{
										list.Add(cargo);
										num--;
									}
									if (num < 1)
									{
										break;
									}
								}
							}
						}
					}
					int result;
					if (!activeUnit.IsActiveUnit)
					{
						result = 1;
					}
					else
					{
						List<Module_Unit.Unit> unitList = new List<Module_Unit.Unit> { activeUnit };
						if (list.Count <= 0)
						{
							CoreClientCode.UnloadCargoAction_Core(unitList);
							result = 1;
						}
						else
						{
							CoreClientCode.UnloadCargoAction_Core(unitList, list);
							result = 1;
						}
					}
					return (byte)result != 0;
				}
				catch (Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					Exception ex4 = ex3;
					ex4?.Data.Add("Error at PM159", "");
					GameGeneral.WriteExceptionsToLog(ex4);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw;
				}
			}
			throw new LuaError(activeUnit.Name + " has no onboard cargo!");
		}
		throw new LuaError("From unit not found!");
	}

	public static LuaTable ScenEdit_GetFormation(LuaTable table, Scenario ScenarioContext)
	{
		Dictionary<string, object> dict = LuaUtility.ToDictUpper(table.GetEnumerator());
		ActiveUnit activeUnit = null;
		LuaUtility.ParseUnitDict(ref dict);
		if (dict.ContainsKey("GUID"))
		{
			string text;
			try
			{
				text = Conversions.ToString(dict["GUID"]);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at PM160", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("guid must be a string");
			}
			try
			{
				activeUnit = ScenarioContext.ActiveUnits[text];
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				ex4?.Data.Add("Error at PM161", "");
				GameGeneral.WriteExceptionsToLog(ex4);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("Can't find guid " + text);
			}
		}
		else if (dict.ContainsKey("UNITNAME"))
		{
			_Closure$__171-0 arg = default(_Closure$__171-0);
			_Closure$__171-0 CS$<>8__locals7 = new _Closure$__171-0(arg);
			try
			{
				CS$<>8__locals7.$VB$Local_Name = Conversions.ToString(dict["UNITNAME"]);
			}
			catch (Exception ex5)
			{
				ProjectData.SetProjectError(ex5);
				Exception ex6 = ex5;
				ex6?.Data.Add("Error at PM162", "");
				GameGeneral.WriteExceptionsToLog(ex6);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("name must be a string");
			}
			if (dict.ContainsKey("SIDE"))
			{
				string text2;
				try
				{
					text2 = Conversions.ToString(dict["SIDE"]);
				}
				catch (Exception ex7)
				{
					ProjectData.SetProjectError(ex7);
					Exception ex8 = ex7;
					ex8?.Data.Add("Error at PM163", "");
					GameGeneral.WriteExceptionsToLog(ex8);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("side must be a string");
				}
				Side side;
				try
				{
					side = LuaUtility.QuerySide(dict, ScenarioContext);
				}
				catch (Exception ex9)
				{
					ProjectData.SetProjectError(ex9);
					Exception ex10 = ex9;
					ex10?.Data.Add("Error at PM164", "");
					GameGeneral.WriteExceptionsToLog(ex10);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("Can't find Side '" + text2 + "'");
				}
				try
				{
					activeUnit = side.Units.First([SpecialName] (ActiveUnit s) => string.Equals(s.Name, CS$<>8__locals7.$VB$Local_Name, StringComparison.OrdinalIgnoreCase) | string.Equals(s.ObjectID, CS$<>8__locals7.$VB$Local_Name, StringComparison.OrdinalIgnoreCase));
				}
				catch (Exception ex11)
				{
					ProjectData.SetProjectError(ex11);
					Exception ex12 = ex11;
					ex12?.Data.Add("Error at PM165", "");
					GameGeneral.WriteExceptionsToLog(ex12);
					int num;
					if (!Debugger.IsAttached)
					{
						num = 5;
					}
					else
					{
						Debugger.Break();
						num = 5;
					}
					string[] array = new string[num];
					array[0] = "Can't find Unit '";
					array[1] = CS$<>8__locals7.$VB$Local_Name;
					array[2] = "' on Side '";
					array[3] = text2;
					array[4] = "'";
					throw new LuaError(string.Concat(array));
				}
			}
			else
			{
				try
				{
					activeUnit = ScenarioContext.ActiveUnits_List.First([SpecialName] (ActiveUnit s) => string.Equals(s.Name, CS$<>8__locals7.$VB$Local_Name, StringComparison.OrdinalIgnoreCase) | string.Equals(s.ObjectID, CS$<>8__locals7.$VB$Local_Name, StringComparison.OrdinalIgnoreCase));
				}
				catch (Exception ex13)
				{
					ProjectData.SetProjectError(ex13);
					Exception ex14 = ex13;
					ex14?.Data.Add("Error at PM166", "");
					GameGeneral.WriteExceptionsToLog(ex14);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("Can't find Unit '" + CS$<>8__locals7.$VB$Local_Name + "'");
				}
			}
		}
		if (activeUnit == null)
		{
			throw new LuaError("Need to define a Name or Guid to identify a unit. Preferably a Guid or Side & Name.");
		}
		if (activeUnit.IsGroup)
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			Group obj = (Group)activeUnit;
			ActiveUnit groupLead = obj.GroupLead;
			foreach (ActiveUnit value in obj.Units.Values)
			{
				if (!value.IsGroupLead())
				{
					LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
					ActiveUnit_Navigator.FormationStation unitFormationStation = value.Navigator.UnitFormationStation;
					luaTable2["guid"] = value.ObjectID;
					luaTable2["bearing"] = unitFormationStation.Bearing;
					luaTable2["type"] = unitFormationStation.BearingType.ToString();
					luaTable2["distance"] = unitFormationStation.Distance;
					luaTable2["sprint"] = value.Navigator.SprintDrift.ToString();
					(double, double) tuple = unitFormationStation.get_LatitudeAndLongitude(value, groupLead);
					luaTable2["latitude"] = tuple.Item1;
					luaTable2["longitude"] = tuple.Item2;
					luaTable[luaTable.Keys.Count.ToString()] = luaTable2;
				}
				else
				{
					luaTable["lead"] = value.ObjectID;
				}
			}
			luaTable["name"] = obj.LastFormationSet;
			luaTable["spacing"] = obj.LastFormationSpacing;
			luaTable["spacing_unit"] = obj.LastFormationSpacingUnits;
			return luaTable;
		}
		throw new LuaError("Unit needs to be a group.");
	}

	public static bool ScenEdit_SetFormation(LuaTable table, Scenario ScenarioContext)
	{
		bool result = false;
		ActiveUnit activeUnit = null;
		string lastFormationSet = "";
		float lastFormationSpacing = 0f;
		byte lastFormationSpacingUnits = 0;
		ActiveUnit activeUnit2 = null;
		List<object> list = new List<object>();
		Dictionary<string, object> dict = LuaUtility.ToDictUpper(table.GetEnumerator());
		LuaUtility.ParseUnitDict(ref dict);
		if (dict.ContainsKey("NAME"))
		{
			try
			{
				lastFormationSet = Conversions.ToString(dict["NAME"]);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at PM1601", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("name must be a string");
			}
		}
		if (dict.ContainsKey("SPACING"))
		{
			try
			{
				lastFormationSpacing = Conversions.ToSingle(dict["UNITNAME"]);
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				ex4?.Data.Add("Error at PM1602", "");
				GameGeneral.WriteExceptionsToLog(ex4);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("spacing must be a single");
			}
		}
		if (dict.ContainsKey("SPACING_UNIT"))
		{
			try
			{
				lastFormationSpacingUnits = Conversions.ToByte(dict["SPACING_UNIT"]);
			}
			catch (Exception ex5)
			{
				ProjectData.SetProjectError(ex5);
				Exception ex6 = ex5;
				ex6?.Data.Add("Error at PM1603", "");
				GameGeneral.WriteExceptionsToLog(ex6);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("spacing unit must be 0 or 1");
			}
		}
		if (dict.ContainsKey("GROUP"))
		{
			try
			{
				string key = Conversions.ToString(dict["GROUP"]);
				ActiveUnit activeUnit3 = ScenarioContext.ActiveUnits[key];
				if (activeUnit3 == null || !activeUnit3.IsGroup)
				{
					throw new LuaError("missing group");
				}
				activeUnit2 = ((Group)activeUnit3).GroupLead;
			}
			catch (Exception ex7)
			{
				ProjectData.SetProjectError(ex7);
				Exception ex8 = ex7;
				ex8?.Data.Add("Error at PM1604", "");
				GameGeneral.WriteExceptionsToLog(ex8);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("missing lead");
			}
		}
		if (dict.ContainsKey("UNITS"))
		{
			list.Clear();
			List<object> list2 = LuaUtility.ToArray(((LuaTable)dict["UNITS"]).GetEnumerator());
			try
			{
				(double, double) item2 = default((double, double));
				foreach (object item3 in list2)
				{
					object objectValue = RuntimeHelpers.GetObjectValue(item3);
					string text = null;
					bool item = false;
					ActiveUnit_Navigator.FormationStation formationStation = new ActiveUnit_Navigator.FormationStation();
					if (!(objectValue is LuaTable))
					{
						continue;
					}
					Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(((LuaTable)objectValue).GetEnumerator());
					if (dictionary.ContainsKey("GUID"))
					{
						text = Conversions.ToString(dictionary["GUID"]);
						activeUnit = ScenarioContext.ActiveUnits[text];
						if (activeUnit.get_ParentGroup(UsingMissionPlanner: false) != activeUnit2.get_ParentGroup(UsingMissionPlanner: false))
						{
							throw new LuaError("error in unit group defintion");
						}
					}
					if (dictionary.ContainsKey("SPRINT"))
					{
						item = Conversions.ToBoolean(dictionary["SPRINT"]);
					}
					if (dictionary.ContainsKey("TYPE"))
					{
						formationStation.BearingType = (ReferencePoint.OrientationType)Conversions.ToByte(dictionary["TYPE"]);
					}
					if (dictionary.ContainsKey("TRANSPOSE"))
					{
						Conversions.ToBoolean(dictionary["TRANSPOSE"]);
					}
					if (dictionary.ContainsKey("BEARING") && dictionary.ContainsKey("DISTANCE"))
					{
						formationStation.Bearing = Conversions.ToSingle(dictionary["BEARING"]);
						formationStation.Distance = Conversions.ToSingle(dictionary["DISTANCE"]);
						item2 = formationStation.get_LatitudeAndLongitude(activeUnit, activeUnit2);
					}
					list.Add((text, formationStation, item2, item));
				}
			}
			catch (Exception ex9)
			{
				ProjectData.SetProjectError(ex9);
				Exception ex10 = ex9;
				ex10?.Data.Add("Error at PM1605", "");
				GameGeneral.WriteExceptionsToLog(ex10);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("error in unit defintions");
			}
		}
		if (list != null)
		{
			Group obj = activeUnit2.get_ParentGroup(UsingMissionPlanner: false);
			foreach (object item4 in list)
			{
				(string, ActiveUnit_Navigator.FormationStation, (double, double), bool, bool) tuple = ((item4 != null) ? (((string, ActiveUnit_Navigator.FormationStation, (double, double), bool, bool))item4) : default((string, ActiveUnit_Navigator.FormationStation, (double, double), bool, bool)));
				activeUnit = ScenarioContext.ActiveUnits[tuple.Item1];
				if (activeUnit != null && activeUnit.get_ParentGroup(UsingMissionPlanner: false) == activeUnit2.get_ParentGroup(UsingMissionPlanner: false) && !activeUnit.IsGroupLead())
				{
					activeUnit.Navigator.UnitFormationStation = tuple.Item2;
					activeUnit.Navigator.SprintDrift = tuple.Item4;
					if (!tuple.Item5)
					{
						activeUnit.Navigator.ClearPlottedCourse();
						activeUnit.Navigator.CalculateFormationStationRelativeData(tuple.Item3.Item2, tuple.Item3.Item1, ResetValues: true);
					}
					else
					{
						activeUnit.Teleport(ref activeUnit.ParentScen, tuple.Item3.Item2, tuple.Item3.Item1);
					}
				}
			}
			obj.LastFormationSet = lastFormationSet;
			obj.LastFormationSpacing = lastFormationSpacing;
			obj.LastFormationSpacingUnits = lastFormationSpacingUnits;
		}
		return result;
	}

	public static LuaTable ScenEdit_SelectedUnits(Scenario ScenarioContext)
	{
		Side currentSide = ScenarioContext.GetCurrentSide();
		LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
		LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
		LuaTable luaTable3 = LuaSandBox.Singleton().CreateTable();
		if (currentSide.SelectedUnits.Count > 0)
		{
			foreach (Module_Unit.Unit selectedUnit in currentSide.SelectedUnits)
			{
				LuaTable luaTable4 = LuaSandBox.Singleton().CreateTable();
				luaTable4["name"] = selectedUnit.Name;
				luaTable4["guid"] = selectedUnit.ObjectID;
				if (selectedUnit.IsContact())
				{
					luaTable3[luaTable3.Keys.Count + 1] = luaTable4;
				}
				else if (selectedUnit.IsActiveUnit)
				{
					luaTable2[luaTable2.Keys.Count + 1] = luaTable4;
				}
			}
		}
		if (luaTable2.Keys.Count > 0)
		{
			luaTable["units"] = luaTable2;
		}
		if (luaTable3.Keys.Count > 0)
		{
			luaTable["contacts"] = luaTable3;
		}
		return luaTable;
	}

	public static LuaTable ScenEdit_GetTimeOfDay(LuaTable table, Scenario ScenarioContext)
	{
		LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
		try
		{
			Dictionary<string, object> dict = LuaUtility.ToDictUpper(table.GetEnumerator());
			ActiveUnit activeUnit = null;
			Side side = null;
			DateTime zuluTime = ScenarioContext.Time;
			LuaUtility.ParseUnitDict(ref dict);
			string text = "DDMMYYYY";
			string text2 = "MMDDYYYY";
			string text3 = "YYYYMMDD";
			LuaUtility.DateFormat theDateFormat = LuaUtility.DateFormat.DDMMYYYY;
			if (dict.ContainsKey("DATEFORMAT"))
			{
				string text4 = Conversions.ToString(dict["DATEFORMAT"]);
				if (Operators.CompareString(text4, text, false) != 0 && Operators.CompareString(text4, text2, false) != 0 && Operators.CompareString(text4, text3, false) != 0)
				{
					throw new LuaError("Invalid date format '" + text4 + "'");
				}
				string text5 = text4;
				if (Operators.CompareString(text5, text, false) == 0)
				{
					theDateFormat = LuaUtility.DateFormat.DDMMYYYY;
				}
				else if (Operators.CompareString(text5, text2, false) != 0)
				{
					if (Operators.CompareString(text5, text3, false) == 0)
					{
						theDateFormat = LuaUtility.DateFormat.YYYYMMDD;
					}
				}
				else
				{
					theDateFormat = LuaUtility.DateFormat.MMDDYYYY;
				}
			}
			if (dict.ContainsKey("DATE"))
			{
				(bool, int, int, int) tuple = LuaUtility.ParseDate_String(Conversions.ToString(dict["DATE"]), theDateFormat);
				if (!tuple.Item1)
				{
					zuluTime = new DateTime(tuple.Item4, tuple.Item3, tuple.Item2, zuluTime.Hour, zuluTime.Minute, zuluTime.Second);
				}
			}
			if (dict.ContainsKey("TIME"))
			{
				(bool, int, int, int) tuple2 = LuaUtility.ParseTime_String(Conversions.ToString(dict["TIME"]));
				if (!tuple2.Item1)
				{
					zuluTime = new DateTime(zuluTime.Year, zuluTime.Month, zuluTime.Day, tuple2.Item2, tuple2.Item3, tuple2.Item4);
				}
			}
			if (dict.ContainsKey("GUID"))
			{
				string text6;
				try
				{
					text6 = Conversions.ToString(dict["GUID"]);
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error at PM167", "");
					GameGeneral.WriteExceptionsToLog(ex2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("guid must be a string");
				}
				try
				{
					activeUnit = ScenarioContext.ActiveUnits[text6];
				}
				catch (Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					Exception ex4 = ex3;
					ex4?.Data.Add("Error at PM168", "");
					GameGeneral.WriteExceptionsToLog(ex4);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("Can't find guid " + text6);
				}
			}
			else if (dict.ContainsKey("UNITNAME"))
			{
				string text7;
				try
				{
					text7 = Conversions.ToString(dict["UNITNAME"]);
				}
				catch (Exception ex5)
				{
					ProjectData.SetProjectError(ex5);
					Exception ex6 = ex5;
					ex6?.Data.Add("Error at PM169", "");
					GameGeneral.WriteExceptionsToLog(ex6);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("name must be a string");
				}
				if (dict.ContainsKey("SIDE"))
				{
					string text8;
					try
					{
						text8 = Conversions.ToString(dict["SIDE"]);
					}
					catch (Exception ex7)
					{
						ProjectData.SetProjectError(ex7);
						Exception ex8 = ex7;
						ex8?.Data.Add("Error at PM170", "");
						GameGeneral.WriteExceptionsToLog(ex8);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						throw new LuaError("side must be a string");
					}
					try
					{
						side = LuaUtility.QuerySide(dict, ScenarioContext);
					}
					catch (Exception ex9)
					{
						ProjectData.SetProjectError(ex9);
						Exception ex10 = ex9;
						ex10?.Data.Add("Error at PM171", "");
						GameGeneral.WriteExceptionsToLog(ex10);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						throw new LuaError("Can't find Side '" + text8 + "'");
					}
					try
					{
						activeUnit = side.Units.First([SpecialName] (ActiveUnit s) => string.Equals(s.Name, text7, StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, text7, StringComparison.Ordinal));
					}
					catch (Exception ex11)
					{
						ProjectData.SetProjectError(ex11);
						Exception ex12 = ex11;
						ex12?.Data.Add("Error at PM172", "");
						GameGeneral.WriteExceptionsToLog(ex12);
						int num;
						if (Debugger.IsAttached)
						{
							Debugger.Break();
							num = 5;
						}
						else
						{
							num = 5;
						}
						string[] array = new string[num];
						array[0] = "Can't find Unit '";
						array[1] = text7;
						array[2] = "' on Side '";
						array[3] = text8;
						array[4] = "'";
						throw new LuaError(string.Concat(array));
					}
					dict["GUID"] = activeUnit.ObjectID;
				}
			}
			if (activeUnit != null)
			{
				dict["LATITUDE"] = activeUnit.get_Latitude((GlobalVariables.BooleanObject)null);
				dict["LONGITUDE"] = activeUnit.get_Longitude((GlobalVariables.BooleanObject)null);
			}
			double? num2 = LuaUtility.QueryLatitude(dict);
			if (num2.HasValue)
			{
				double? num3 = LuaUtility.QueryLongitude(dict);
				if (num3.HasValue)
				{
					bool use_DST = ScenarioContext.Use_DST;
					string dST_Start = ScenarioContext.DST_Start;
					string dST_End = ScenarioContext.DST_End;
					string value = Misc.LocalTime(zuluTime, num3.Value, use_DST, dST_Start, dST_End).ToShortTimeString();
					Weather.TTimeOfDayType timeOfDay = SunModule.GetTimeOfDay(ScenarioContext, zuluTime.Year, zuluTime.Month, zuluTime.Day, zuluTime.Hour, zuluTime.Minute, zuluTime.Second, UseCurrentScenarioTime: false, num2.Value, num3.Value, 0.0);
					switch (timeOfDay)
					{
					case Weather.TTimeOfDayType.tod_Day:
						luaTable["tod"] = (int)timeOfDay;
						luaTable["TOD"] = "day";
						break;
					case Weather.TTimeOfDayType.tod_Twilight:
						if (Misc.LocalTime(zuluTime, num3.Value, use_DST, dST_Start, dST_End).Hour < 12)
						{
							luaTable["tod"] = 3;
							luaTable["TOD"] = "dawn";
						}
						else
						{
							luaTable["tod"] = 4;
							luaTable["TOD"] = "dusk";
						}
						break;
					case Weather.TTimeOfDayType.tod_Night:
						luaTable["tod"] = (int)timeOfDay;
						luaTable["TOD"] = "night";
						break;
					}
					luaTable["localtime"] = value;
					luaTable["zulutime"] = zuluTime.Hour.ToString("D2") + ":" + zuluTime.Minute.ToString("D2") + ":" + zuluTime.Second.ToString("D2");
					return luaTable;
				}
				throw new LuaError("Missing 'Longitude'");
			}
			throw new LuaError("Missing 'Latitude'");
		}
		catch (Exception ex13)
		{
			ProjectData.SetProjectError(ex13);
			Exception ex14 = ex13;
			ex14?.Data.Add("Error at PM173", "");
			GameGeneral.WriteExceptionsToLog(ex14);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static int ScenEdit_AddMinefield(LuaTable table, Scenario ScenarioContext)
	{
		Dictionary<string, object> dict = LuaUtility.ToDictUpper(table.GetEnumerator());
		Side side = null;
		LuaUtility.ParseUnitDict(ref dict);
		if (dict.ContainsKey("SIDE"))
		{
			string text = Conversions.ToString(dict["SIDE"]);
			try
			{
				side = LuaUtility.QuerySide(dict, ScenarioContext);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at PM174", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("Can't find Side '" + text + "'");
			}
		}
		List<ReferencePoint> list = new List<ReferencePoint>();
		if (dict.ContainsKey("AREA"))
		{
			list.Clear();
			try
			{
				List<object> list2 = LuaUtility.ToArray(((LuaTable)dict["AREA"]).GetEnumerator());
				_Closure$__175-0 closure$__175- = default(_Closure$__175-0);
				foreach (object item in list2)
				{
					object objectValue = RuntimeHelpers.GetObjectValue(item);
					closure$__175- = new _Closure$__175-0(closure$__175-);
					closure$__175-.$VB$Local_o_name = null;
					ReferencePoint referencePoint = null;
					if (!(objectValue.GetType() == typeof(LuaTable)))
					{
						closure$__175-.$VB$Local_o_name = objectValue.ToString().ToUpperInvariant();
						referencePoint = side.RefPoints.FirstOrDefault(closure$__175-._Lambda$__3);
						if (Information.IsNothing((object)referencePoint))
						{
							foreach (NoNavZone noNavZone in side.NoNavZones)
							{
								referencePoint = noNavZone.Area.FirstOrDefault((closure$__175-.$I4 != null) ? closure$__175-.$I4 : (closure$__175-.$I4 = closure$__175-._Lambda$__4));
								if (!Information.IsNothing((object)referencePoint))
								{
									break;
								}
							}
						}
						if (Information.IsNothing((object)referencePoint))
						{
							foreach (ExclusionZone exclusionZone in side.ExclusionZones)
							{
								referencePoint = exclusionZone.Area.FirstOrDefault((closure$__175-.$I5 != null) ? closure$__175-.$I5 : (closure$__175-.$I5 = closure$__175-._Lambda$__5));
								if (!Information.IsNothing((object)referencePoint))
								{
									break;
								}
							}
						}
					}
					else
					{
						Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(((LuaTable)objectValue).GetEnumerator());
						if (dictionary.ContainsKey("GUID"))
						{
							closure$__175-.$VB$Local_o_name = Conversions.ToString(dictionary["GUID"]).ToUpperInvariant();
						}
						else if (dict.ContainsKey("NAME"))
						{
							closure$__175-.$VB$Local_o_name = Conversions.ToString(dictionary["NAME"]).ToUpperInvariant();
						}
						referencePoint = side.RefPoints.FirstOrDefault(closure$__175-._Lambda$__0);
						if (Information.IsNothing((object)referencePoint))
						{
							foreach (NoNavZone noNavZone2 in side.NoNavZones)
							{
								referencePoint = noNavZone2.Area.FirstOrDefault(closure$__175-._Lambda$__1);
								if (!Information.IsNothing((object)referencePoint))
								{
									break;
								}
							}
						}
						if (Information.IsNothing((object)referencePoint))
						{
							foreach (ExclusionZone exclusionZone2 in side.ExclusionZones)
							{
								referencePoint = exclusionZone2.Area.FirstOrDefault(closure$__175-._Lambda$__2);
								if (!Information.IsNothing((object)referencePoint))
								{
									break;
								}
							}
						}
					}
					if (!Information.IsNothing((object)referencePoint))
					{
						list.Add(referencePoint);
					}
				}
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				ex4?.Data.Add("Error at PM175", "");
				GameGeneral.WriteExceptionsToLog(ex4);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
		if (list.Count == 0)
		{
			throw new LuaError("No valid area defined");
		}
		if (dict.ContainsKey("DBID"))
		{
			int mineDBID = Conversions.ToInteger(dict["DBID"]);
			if (!dict.ContainsKey("NUMBER"))
			{
				throw new LuaError("No number of mines defined.");
			}
			int num = Conversions.ToInteger(dict["NUMBER"]);
			float num2 = 0f;
			if (dict.ContainsKey("DELAY"))
			{
				num2 = Conversions.ToSingle(dict["DELAY"]);
			}
			int num3 = 0;
			int num4 = num;
			int num5;
			for (num5 = 0; num5 <= num4; num5++)
			{
				num5++;
				Side theSide = side;
				string AttemptMessage = null;
				UnguidedWeapon unguidedWeapon = ScenarioContext.AddNewMine(theSide, mineDBID, list, ref AttemptMessage);
				if (!Information.IsNothing((object)unguidedWeapon))
				{
					if (num2 > 0f)
					{
						unguidedWeapon.TimeToDetonate = num2;
					}
					num3++;
				}
			}
			return num3;
		}
		throw new LuaError("No mine DB type defined.");
	}

	public static LuaTable ScenEdit_GetMinefield(LuaTable table, Scenario ScenarioContext)
	{
		_Closure$__176-0 arg = default(_Closure$__176-0);
		_Closure$__176-0 CS$<>8__locals10 = new _Closure$__176-0(arg);
		Dictionary<string, object> dict = LuaUtility.ToDictUpper(table.GetEnumerator());
		CS$<>8__locals10.$VB$Local_SideObject = null;
		LuaUtility.ParseUnitDict(ref dict);
		if (dict.ContainsKey("SIDE"))
		{
			string text = Conversions.ToString(dict["SIDE"]);
			try
			{
				CS$<>8__locals10.$VB$Local_SideObject = LuaUtility.QuerySide(dict, ScenarioContext);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at PM176", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("Can't find Side '" + text + "'");
			}
		}
		List<UnguidedWeapon> list = ScenarioContext.UnguidedWeapons.Values.Where([SpecialName] (UnguidedWeapon theUW) => theUW.IsMine && theUW.get_UnitSide(SetSideOnly: false) == CS$<>8__locals10.$VB$Local_SideObject).ToList();
		if (list.Count < 1)
		{
			return LuaSandBox.Singleton().CreateTable();
		}
		List<ReferencePoint> list2 = new List<ReferencePoint>();
		if (dict.ContainsKey("AREA"))
		{
			list2.Clear();
			try
			{
				List<object> list3 = LuaUtility.ToArray(((LuaTable)dict["AREA"]).GetEnumerator());
				_Closure$__176-1 closure$__176- = default(_Closure$__176-1);
				foreach (object item in list3)
				{
					object objectValue = RuntimeHelpers.GetObjectValue(item);
					closure$__176- = new _Closure$__176-1(closure$__176-);
					closure$__176-.$VB$Local_o_name = null;
					ReferencePoint referencePoint = null;
					if (!(objectValue.GetType() == typeof(LuaTable)))
					{
						closure$__176-.$VB$Local_o_name = objectValue.ToString().ToUpperInvariant();
						referencePoint = CS$<>8__locals10.$VB$Local_SideObject.RefPoints.FirstOrDefault(closure$__176-._Lambda$__4);
						if (Information.IsNothing((object)referencePoint))
						{
							foreach (NoNavZone noNavZone in CS$<>8__locals10.$VB$Local_SideObject.NoNavZones)
							{
								referencePoint = noNavZone.Area.FirstOrDefault((closure$__176-.$I5 != null) ? closure$__176-.$I5 : (closure$__176-.$I5 = closure$__176-._Lambda$__5));
								if (!Information.IsNothing((object)referencePoint))
								{
									break;
								}
							}
						}
						if (Information.IsNothing((object)referencePoint))
						{
							foreach (ExclusionZone exclusionZone in CS$<>8__locals10.$VB$Local_SideObject.ExclusionZones)
							{
								referencePoint = exclusionZone.Area.FirstOrDefault((closure$__176-.$I6 != null) ? closure$__176-.$I6 : (closure$__176-.$I6 = closure$__176-._Lambda$__6));
								if (!Information.IsNothing((object)referencePoint))
								{
									break;
								}
							}
						}
					}
					else
					{
						Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(((LuaTable)objectValue).GetEnumerator());
						if (!dictionary.ContainsKey("GUID"))
						{
							if (dict.ContainsKey("NAME"))
							{
								closure$__176-.$VB$Local_o_name = Conversions.ToString(dictionary["NAME"]).ToUpperInvariant();
							}
						}
						else
						{
							closure$__176-.$VB$Local_o_name = Conversions.ToString(dictionary["GUID"]).ToUpperInvariant();
						}
						referencePoint = CS$<>8__locals10.$VB$Local_SideObject.RefPoints.FirstOrDefault(closure$__176-._Lambda$__1);
						if (Information.IsNothing((object)referencePoint))
						{
							foreach (NoNavZone noNavZone2 in CS$<>8__locals10.$VB$Local_SideObject.NoNavZones)
							{
								referencePoint = noNavZone2.Area.FirstOrDefault((closure$__176-.$I2 != null) ? closure$__176-.$I2 : (closure$__176-.$I2 = closure$__176-._Lambda$__2));
								if (!Information.IsNothing((object)referencePoint))
								{
									break;
								}
							}
						}
						if (Information.IsNothing((object)referencePoint))
						{
							foreach (ExclusionZone exclusionZone2 in CS$<>8__locals10.$VB$Local_SideObject.ExclusionZones)
							{
								referencePoint = exclusionZone2.Area.FirstOrDefault((closure$__176-.$I3 != null) ? closure$__176-.$I3 : (closure$__176-.$I3 = closure$__176-._Lambda$__3));
								if (!Information.IsNothing((object)referencePoint))
								{
									break;
								}
							}
						}
					}
					if (!Information.IsNothing((object)referencePoint))
					{
						list2.Add(referencePoint);
					}
				}
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				ex4?.Data.Add("Error at PM177", "");
				GameGeneral.WriteExceptionsToLog(ex4);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
		if (list2.Count == 0)
		{
			throw new LuaError("No valid area defined");
		}
		LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
		int num = 1;
		foreach (UnguidedWeapon item2 in list)
		{
			if ((item2.get_UnitSide(SetSideOnly: false) == CS$<>8__locals10.$VB$Local_SideObject) & ((Module_Unit.Unit)item2).get_IsInsideThisArea(list2, ScenarioContext, UseCache: false))
			{
				LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
				luaTable2["guid"] = item2.ObjectID;
				luaTable2["type"] = item2.AnnexAndDBID;
				luaTable2["delay"] = item2.TimeToDetonate;
				luaTable2["longitude"] = ((Module_Unit.Unit)item2).get_Longitude((GlobalVariables.BooleanObject)null);
				luaTable2["latitude"] = ((Module_Unit.Unit)item2).get_Latitude((GlobalVariables.BooleanObject)null);
				luaTable2["depth"] = ((Module_Unit.Unit)item2).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
				luaTable[num] = luaTable2;
				num++;
			}
		}
		return luaTable;
	}

	public static int ScenEdit_DeleteMinefield(LuaTable table, Scenario ScenarioContext)
	{
		_Closure$__177-0 arg = default(_Closure$__177-0);
		_Closure$__177-0 CS$<>8__locals10 = new _Closure$__177-0(arg);
		Dictionary<string, object> dict = LuaUtility.ToDictUpper(table.GetEnumerator());
		CS$<>8__locals10.$VB$Local_SideObject = null;
		LuaUtility.ParseUnitDict(ref dict);
		if (dict.ContainsKey("SIDE"))
		{
			string text = Conversions.ToString(dict["SIDE"]);
			try
			{
				CS$<>8__locals10.$VB$Local_SideObject = LuaUtility.QuerySide(dict, ScenarioContext);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at PM178", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("Can't find Side '" + text + "'");
			}
		}
		List<UnguidedWeapon> list = ScenarioContext.UnguidedWeapons.Values.Where([SpecialName] (UnguidedWeapon theUW) => theUW.IsMine && theUW.get_UnitSide(SetSideOnly: false) == CS$<>8__locals10.$VB$Local_SideObject).ToList();
		if (list.Count >= 1)
		{
			List<ReferencePoint> list2 = new List<ReferencePoint>();
			if (dict.ContainsKey("AREA"))
			{
				list2.Clear();
				try
				{
					List<object> list3 = LuaUtility.ToArray(((LuaTable)dict["AREA"]).GetEnumerator());
					_Closure$__177-1 closure$__177- = default(_Closure$__177-1);
					foreach (object item in list3)
					{
						object objectValue = RuntimeHelpers.GetObjectValue(item);
						closure$__177- = new _Closure$__177-1(closure$__177-);
						closure$__177-.$VB$Local_o_name = null;
						ReferencePoint referencePoint = null;
						if (!(objectValue.GetType() == typeof(LuaTable)))
						{
							closure$__177-.$VB$Local_o_name = objectValue.ToString().ToUpperInvariant();
							referencePoint = CS$<>8__locals10.$VB$Local_SideObject.RefPoints.FirstOrDefault(closure$__177-._Lambda$__4);
							if (Information.IsNothing((object)referencePoint))
							{
								foreach (NoNavZone noNavZone in CS$<>8__locals10.$VB$Local_SideObject.NoNavZones)
								{
									referencePoint = noNavZone.Area.FirstOrDefault((closure$__177-.$I5 != null) ? closure$__177-.$I5 : (closure$__177-.$I5 = closure$__177-._Lambda$__5));
									if (!Information.IsNothing((object)referencePoint))
									{
										break;
									}
								}
							}
							if (Information.IsNothing((object)referencePoint))
							{
								foreach (ExclusionZone exclusionZone in CS$<>8__locals10.$VB$Local_SideObject.ExclusionZones)
								{
									referencePoint = exclusionZone.Area.FirstOrDefault((closure$__177-.$I6 != null) ? closure$__177-.$I6 : (closure$__177-.$I6 = closure$__177-._Lambda$__6));
									if (!Information.IsNothing((object)referencePoint))
									{
										break;
									}
								}
							}
						}
						else
						{
							Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(((LuaTable)objectValue).GetEnumerator());
							if (!dictionary.ContainsKey("GUID"))
							{
								if (dict.ContainsKey("NAME"))
								{
									closure$__177-.$VB$Local_o_name = Conversions.ToString(dictionary["NAME"]).ToUpperInvariant();
								}
							}
							else
							{
								closure$__177-.$VB$Local_o_name = Conversions.ToString(dictionary["GUID"]).ToUpperInvariant();
							}
							referencePoint = CS$<>8__locals10.$VB$Local_SideObject.RefPoints.FirstOrDefault(closure$__177-._Lambda$__1);
							if (Information.IsNothing((object)referencePoint))
							{
								foreach (NoNavZone noNavZone2 in CS$<>8__locals10.$VB$Local_SideObject.NoNavZones)
								{
									referencePoint = noNavZone2.Area.FirstOrDefault(closure$__177-._Lambda$__2);
									if (!Information.IsNothing((object)referencePoint))
									{
										break;
									}
								}
							}
							if (Information.IsNothing((object)referencePoint))
							{
								foreach (ExclusionZone exclusionZone2 in CS$<>8__locals10.$VB$Local_SideObject.ExclusionZones)
								{
									referencePoint = exclusionZone2.Area.FirstOrDefault(closure$__177-._Lambda$__3);
									if (!Information.IsNothing((object)referencePoint))
									{
										break;
									}
								}
							}
						}
						if (!Information.IsNothing((object)referencePoint))
						{
							list2.Add(referencePoint);
						}
					}
				}
				catch (Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					Exception ex4 = ex3;
					ex4?.Data.Add("Error at PM179", "");
					GameGeneral.WriteExceptionsToLog(ex4);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
			if (list2.Count != 0)
			{
				int num = 0;
				List<UnguidedWeapon> list4 = new List<UnguidedWeapon>();
				foreach (UnguidedWeapon item2 in list)
				{
					if ((item2.get_UnitSide(SetSideOnly: false) == CS$<>8__locals10.$VB$Local_SideObject) & ((Module_Unit.Unit)item2).get_IsInsideThisArea(list2, ScenarioContext, UseCache: false))
					{
						list4.Add(item2);
					}
				}
				foreach (UnguidedWeapon item3 in list4)
				{
					item3.DestroyMe(ref ScenarioContext, "Deleted minefield");
					num++;
				}
				return num;
			}
			throw new LuaError("No valid area defined");
		}
		return 0;
	}

	public static bool ScenEdit_SetMine(LuaTable table, Scenario ScenarioContext)
	{
		Dictionary<string, object> dict = LuaUtility.ToDictUpper(table.GetEnumerator());
		LuaUtility.ParseUnitDict(ref dict);
		if (dict.ContainsKey("SIDE"))
		{
			Conversions.ToString(dict["SIDE"]);
			LuaUtility.QuerySide(dict, ScenarioContext);
		}
		string text = null;
		if (dict.ContainsKey("GUID"))
		{
			text = Conversions.ToString(dict["GUID"]);
		}
		float? num = null;
		if (dict.ContainsKey("DELAY"))
		{
			num = Conversions.ToSingle(dict["DELAY"]);
		}
		int result2;
		if (text != null)
		{
			if (num.HasValue)
			{
				bool result = false;
				ScenarioContext.UnguidedWeapons.Values.Where([SpecialName] (UnguidedWeapon theUW) => theUW.IsMine).ToList();
				if (ScenarioContext.UnguidedWeapons.ContainsKey(text))
				{
					UnguidedWeapon unguidedWeapon = ScenarioContext.UnguidedWeapons[text];
					if (unguidedWeapon.IsMine)
					{
						unguidedWeapon.TimeToDetonate = num.Value;
						result = true;
					}
				}
				return result;
			}
			result2 = 0;
		}
		else
		{
			result2 = 0;
		}
		return (byte)result2 != 0;
	}

	public static bool ScenEdit_DeleteMine(LuaTable table, Scenario ScenarioContext)
	{
		Dictionary<string, object> dict = LuaUtility.ToDictUpper(table.GetEnumerator());
		LuaUtility.ParseUnitDict(ref dict);
		if (dict.ContainsKey("SIDE"))
		{
			string text = Conversions.ToString(dict["SIDE"]);
			try
			{
				LuaUtility.QuerySide(dict, ScenarioContext);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at PM181", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("Can't find Side '" + text + "'");
			}
		}
		string text2 = null;
		if (dict.ContainsKey("GUID"))
		{
			text2 = Conversions.ToString(dict["GUID"]);
		}
		if (text2 == null)
		{
			return false;
		}
		bool result = false;
		ScenarioContext.UnguidedWeapons.Values.Where([SpecialName] (UnguidedWeapon theUW) => theUW.IsMine).ToList();
		if (ScenarioContext.UnguidedWeapons.ContainsKey(text2))
		{
			UnguidedWeapon unguidedWeapon = ScenarioContext.UnguidedWeapons[text2];
			if (unguidedWeapon.IsMine)
			{
				unguidedWeapon.DestroyMe(ref ScenarioContext, "Deleted mine");
				result = true;
			}
		}
		return result;
	}

	public static string ScenEdit_GetDateTimeTicks(Scenario ScenarioContext)
	{
		return ScenarioContext.Time.Ticks.ToString();
	}

	public static object ScenEdit_QueryDB(string objectType, int DBID, Scenario ScenarioContext)
	{
		try
		{
			switch (objectType.ToLower())
			{
			case "submarine":
			{
				Submarine theSub = new Submarine(ref ScenarioContext, "");
				DBFunctions.GetSubmarine(ref ScenarioContext, ref theSub, DBID);
				break;
			}
			case "weapon":
			{
				Weapon newWeapon = Weapon.GetNewWeapon(ref ScenarioContext, DBID, bool_5: false);
				DBFunctions.GetWeapon(ScenarioContext.DBConnection, newWeapon, DBID, ScenarioContext, LoadComponents: false);
				return new LuaWrapper_Device_Weapon(newWeapon, ScenarioContext);
			}
			case "mount":
				return new LuaWrapper_Device_Mount(DBFunctions.GetMount(DBID, ref ScenarioContext, LoadComponents: false), ScenarioContext);
			case "facility":
			{
				Facility theFac = new Facility(ref ScenarioContext, "");
				DBFunctions.GetFacility(ref ScenarioContext, ref theFac, DBID);
				break;
			}
			case "aircraft":
			{
				Aircraft theAircraft = new Aircraft(ref ScenarioContext, "");
				DBFunctions.GetAircraft(ref ScenarioContext, ref theAircraft, DBID);
				break;
			}
			case "satellite":
			{
				Satellite theSatellite = new Satellite(ref ScenarioContext);
				DBFunctions.GetSatellite(ref ScenarioContext, ref theSatellite, DBID);
				break;
			}
			case "ship":
			{
				Ship theShip = new Ship(ref ScenarioContext, "");
				DBFunctions.GetShip(ref ScenarioContext, ref theShip, DBID);
				break;
			}
			case "sensor":
			{
				SQLiteConnection sqliteConnection_ = ScenarioContext.DBConnection;
				return new LuaWrapper_Device_Sensor(DBFunctions.GetSensor(DBID, ref sqliteConnection_), ScenarioContext);
			}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at PM182", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
		return null;
	}

	public static bool ScenEdit_AddCustomLoss(string side, LuaTable table, Scenario ScenarioContext)
	{
		bool result = false;
		LuaUtility.ToDictUpper(table.GetEnumerator());
		Side side2 = null;
		try
		{
			side2 = LuaUtility.QuerySideObject(side, ScenarioContext);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at PM183", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw new LuaError("Can't find Side '" + side + "'");
		}
		List<object> list = LuaUtility.ToArray(table.GetEnumerator());
		using List<object>.Enumerator enumerator = list.GetEnumerator();
		int num2;
		for (; enumerator.MoveNext(); result = (byte)num2 != 0)
		{
			object objectValue = RuntimeHelpers.GetObjectValue(enumerator.Current);
			string text = null;
			int num = 1;
			if (objectValue.GetType() == typeof(LuaTable))
			{
				if (!(objectValue is LuaTable))
				{
					text = Conversions.ToString(objectValue);
					num = 1;
				}
				else
				{
					List<object> list2 = LuaUtility.ToArray(((LuaTable)objectValue).GetEnumerator());
					if (list2.Count == 2)
					{
						num = Conversions.ToInteger(list2[1]);
					}
					text = list2[0].ToString();
				}
			}
			else
			{
				text = Conversions.ToString(objectValue);
				num = 1;
			}
			if (Information.IsNothing((object)side2.AAR.Losses))
			{
				side2.AAR.Losses = new ConcurrentDictionary<string, HashSet<string>>();
			}
			ConcurrentDictionary<string, HashSet<string>> losses = side2.AAR.Losses;
			string key = "Custom_" + text;
			if (losses.ContainsKey(key))
			{
				losses[key].Clear();
				if (num > 0)
				{
					losses[key].Add(Conversions.ToString(num));
					num2 = 1;
					continue;
				}
			}
			else if (num > 0)
			{
				HashSet<string> value = new HashSet<string> { Conversions.ToString(num) };
				losses.TryAdd(key, value);
				num2 = 1;
				continue;
			}
			num2 = 1;
		}
		return result;
	}

	public static LuaWrapper_ActiveUnit VP_GetUnit(LuaTable table, Scenario ScenarioContext)
	{
		Dictionary<string, object> dict = LuaUtility.ToDictUpper(table.GetEnumerator());
		ActiveUnit value = null;
		string text = null;
		string text2 = null;
		LuaUtility.ParseUnitDict(ref dict);
		if (dict.TryGetValue("GUID", out var value2))
		{
			try
			{
				text2 = Conversions.ToString(value2);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at PM184", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("guid must be a string");
			}
			if (!ScenarioContext.ActiveUnits.TryGetValue(text2, out value))
			{
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("Can't find guid " + text2);
			}
		}
		else if (dict.TryGetValue("UNITNAME", out value2))
		{
			try
			{
				text = Conversions.ToString(value2);
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				ex4?.Data.Add("Error at PM186", "");
				GameGeneral.WriteExceptionsToLog(ex4);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("name must be a string");
			}
			foreach (ActiveUnit activeUnits_ in ScenarioContext.ActiveUnits_List)
			{
				if (string.Equals(activeUnits_.Name, text, StringComparison.OrdinalIgnoreCase) || string.Equals(activeUnits_.ObjectID, text, StringComparison.OrdinalIgnoreCase))
				{
					value = activeUnits_;
					break;
				}
			}
			if (value == null)
			{
				throw new LuaError("Unable to find unit matching name: " + text);
			}
		}
		if (value == null)
		{
			Contact contact = null;
			if (text2 != null)
			{
				string nameOrId = text2;
				Side Side = null;
				contact = LuaUtility.ValidAsContact(nameOrId, ScenarioContext, ref Side);
			}
			else if (text != null)
			{
				string nameOrId2 = text;
				Side Side = null;
				contact = LuaUtility.ValidAsContact(nameOrId2, ScenarioContext, ref Side);
			}
			if (contact != null)
			{
				value = contact.ActualUnit;
			}
		}
		if (value == null)
		{
			throw new LuaError("Unable to find unit");
		}
		return new LuaWrapper_ActiveUnit(value, ScenarioContext);
	}

	public static LuaWrapper_Contact VP_GetContact(LuaTable table, Scenario ScenarioContext)
	{
		Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(table.GetEnumerator());
		Contact contact = null;
		Side fromSide = null;
		string text = default(string);
		if (dictionary.ContainsKey("GUID"))
		{
			try
			{
				text = Conversions.ToString(dictionary["GUID"]);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at PM187", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("guid must be a string");
			}
		}
		int tracknumber = default(int);
		if (dictionary.ContainsKey("TRACKNUMBER"))
		{
			try
			{
				tracknumber = Conversions.ToInteger(dictionary["TRACKNUMBER"]);
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				ex4?.Data.Add("Error at PM2314095743298573456", "");
				GameGeneral.WriteExceptionsToLog(ex4);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("tracknumber must be a number");
			}
		}
		try
		{
			Side[] sides_ReadOnly = ScenarioContext.Sides_ReadOnly;
			foreach (Side side in sides_ReadOnly)
			{
				fromSide = side;
				contact = ValidateContactBySide(text, tracknumber, side);
				if (contact != null)
				{
					break;
				}
				foreach (string key in side.NewContactsQueue.Keys)
				{
					Contact contact2 = side.NewContactsQueue[key];
					if (string.Equals(contact2.ObjectID, text, StringComparison.OrdinalIgnoreCase))
					{
						fromSide = side;
						contact = contact2;
						break;
					}
				}
				if (contact != null)
				{
					break;
				}
				foreach (string key2 in side.NewBaseContactsQueue.Keys)
				{
					Contact contact3 = side.NewBaseContactsQueue[key2];
					if (string.Equals(contact3.ObjectID, text, StringComparison.OrdinalIgnoreCase))
					{
						fromSide = side;
						contact = contact3;
						break;
					}
				}
			}
		}
		catch (Exception ex5)
		{
			ProjectData.SetProjectError(ex5);
			Exception ex6 = ex5;
			ex6?.Data.Add("Error at PM188", "");
			GameGeneral.WriteExceptionsToLog(ex6);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw new LuaError("Can't find guid " + text);
		}
		if (Information.IsNothing((object)contact))
		{
			throw new LuaError("Unable to find contact");
		}
		return new LuaWrapper_Contact(contact, ScenarioContext, fromSide);
	}

	public static LuaWrapper_Scenario VP_GetScenario(Scenario ScenarioContext)
	{
		byte status = default(byte);
		byte mode = default(byte);
		luaGameEventHandler_0?.Invoke(ref status, ref mode);
		return new LuaWrapper_Scenario(ScenarioContext)
		{
			GameMode = mode,
			GameStatus = status
		};
	}

	public static LuaTable ScenEdit_SplitUnit(LuaTable table, Scenario ScenarioContext)
	{
		_Closure$__186-0 arg = default(_Closure$__186-0);
		_Closure$__186-0 CS$<>8__locals9 = new _Closure$__186-0(arg);
		Dictionary<string, object> dict = LuaUtility.ToDictUpper(table.GetEnumerator());
		ActiveUnit activeUnit = null;
		Side side = null;
		string text = null;
		CS$<>8__locals9.$VB$Local_Name = null;
		string text2 = null;
		new Dictionary<Mount, Mount>();
		LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
		LuaUtility.ParseUnitDict(ref dict);
		if (dict.ContainsKey("GUID"))
		{
			try
			{
				text2 = Conversions.ToString(dict["GUID"]);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at PM191", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("guid must be a string");
			}
			try
			{
				activeUnit = ScenarioContext.ActiveUnits[text2];
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				ex4?.Data.Add("Error at PM192", "");
				GameGeneral.WriteExceptionsToLog(ex4);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				text = "Can't find guid " + text2;
				ProjectData.ClearProjectError();
			}
		}
		else if (dict.ContainsKey("UNITNAME"))
		{
			try
			{
				CS$<>8__locals9.$VB$Local_Name = Conversions.ToString(dict["UNITNAME"]);
			}
			catch (Exception ex5)
			{
				ProjectData.SetProjectError(ex5);
				Exception ex6 = ex5;
				ex6?.Data.Add("Error at PM193", "");
				GameGeneral.WriteExceptionsToLog(ex6);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("name must be a string");
			}
			if (dict.ContainsKey("SIDE"))
			{
				string text3;
				try
				{
					text3 = Conversions.ToString(dict["SIDE"]);
				}
				catch (Exception ex7)
				{
					ProjectData.SetProjectError(ex7);
					Exception ex8 = ex7;
					ex8?.Data.Add("Error at PM194", "");
					GameGeneral.WriteExceptionsToLog(ex8);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("side must be a string");
				}
				try
				{
					side = LuaUtility.QuerySide(dict, ScenarioContext);
				}
				catch (Exception ex9)
				{
					ProjectData.SetProjectError(ex9);
					Exception ex10 = ex9;
					ex10?.Data.Add("Error at PM195", "");
					GameGeneral.WriteExceptionsToLog(ex10);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					text = "Can't find Side '" + text3 + "'";
					ProjectData.ClearProjectError();
				}
				try
				{
					activeUnit = side.Units.First([SpecialName] (ActiveUnit s) => string.Equals(s.Name, CS$<>8__locals9.$VB$Local_Name, StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, CS$<>8__locals9.$VB$Local_Name, StringComparison.OrdinalIgnoreCase));
				}
				catch (Exception ex11)
				{
					ProjectData.SetProjectError(ex11);
					Exception ex12 = ex11;
					ex12?.Data.Add("Error at PM196", "");
					GameGeneral.WriteExceptionsToLog(ex12);
					int num;
					if (Debugger.IsAttached)
					{
						Debugger.Break();
						num = 5;
					}
					else
					{
						num = 5;
					}
					string[] array = new string[num];
					array[0] = "Can't find Unit '";
					array[1] = CS$<>8__locals9.$VB$Local_Name;
					array[2] = "' on Side '";
					array[3] = text3;
					array[4] = "'";
					text = string.Concat(array);
					ProjectData.ClearProjectError();
				}
			}
			else
			{
				try
				{
					activeUnit = ScenarioContext.ActiveUnits_List.First([SpecialName] (ActiveUnit s) => string.Equals(s.Name, CS$<>8__locals9.$VB$Local_Name, StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, CS$<>8__locals9.$VB$Local_Name, StringComparison.OrdinalIgnoreCase));
				}
				catch (Exception ex13)
				{
					ProjectData.SetProjectError(ex13);
					Exception ex14 = ex13;
					ex14?.Data.Add("Error at PM197", "");
					GameGeneral.WriteExceptionsToLog(ex14);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					text = "Can't find Unit '" + CS$<>8__locals9.$VB$Local_Name + "'";
					ProjectData.ClearProjectError();
				}
			}
		}
		if (activeUnit != null)
		{
			if (activeUnit.IsSplittable() && activeUnit.Mounts.Count >= 2)
			{
				Cargo[] theArray = new Cargo[0];
				for (int num2 = activeUnit.Mounts.Count - 1; num2 >= 1; num2 += -1)
				{
					ArrayExtensions.Add(ref theArray, new Cargo(activeUnit, activeUnit.Mounts.ElementAt(num2)));
					activeUnit.Mounts.RemoveAt(num2);
					List<ActiveUnit> list = Cargo.UnloadCargoAtLocation(activeUnit, ref theArray, null, activeUnit.get_Latitude((GlobalVariables.BooleanObject)null), activeUnit.get_Longitude((GlobalVariables.BooleanObject)null), activeUnit.ParentScen, activeUnit.get_UnitSide(SetSideOnly: false), paradropOnly: false, ByUser: true);
					if (list.Count > 0)
					{
						list.ElementAt(0).Name = "New Detachment";
					}
					luaTable[luaTable.Keys.Count + 1] = list.ElementAt(0);
				}
				return luaTable;
			}
			return null;
		}
		if (LuaSandBox.Singleton().RunInteractive && text != null)
		{
			throw new LuaError(text);
		}
		if (text2 == null && CS$<>8__locals9.$VB$Local_Name == null)
		{
			throw new LuaError("Need to define a Name or Guid to identify a unit. Preferably a Guid or Side & Name.");
		}
		return null;
	}

	public static LuaWrapper_ActiveUnit_SE ScenEdit_MergeUnits(Scenario ScenarioContext)
	{
		ActiveUnit a = null;
		Side currentSide = ScenarioContext.GetCurrentSide();
		if (currentSide.SelectedUnits.Count > 1)
		{
			foreach (Module_Unit.Unit selectedUnit in currentSide.SelectedUnits)
			{
				ActiveUnit activeUnit = (ActiveUnit)selectedUnit;
				if (selectedUnit.get_UnitSide(SetSideOnly: false) == currentSide && activeUnit.IsSplittable())
				{
					if (!(currentSide.SelectedUnits.ElementAt(0).RangeToUnit_Horiz(selectedUnit) <= 0.05f))
					{
						return null;
					}
					continue;
				}
				return null;
			}
			if (currentSide.SelectedUnits.Count > 1)
			{
				foreach (Module_Unit.Unit selectedUnit2 in currentSide.SelectedUnits)
				{
					ActiveUnit activeUnit2 = (ActiveUnit)selectedUnit2;
					if (selectedUnit2.get_UnitSide(SetSideOnly: false) != currentSide || !activeUnit2.IsSplittable() || !(currentSide.SelectedUnits.ElementAt(0).RangeToUnit_Horiz(selectedUnit2) <= 0.2f))
					{
						return null;
					}
				}
				ActiveUnit activeUnit3 = (ActiveUnit)currentSide.SelectedUnits.ElementAt(0);
				a = activeUnit3;
				for (int i = currentSide.SelectedUnits.Count - 1; i >= 1; i += -1)
				{
					foreach (Mount item in ((ActiveUnit)currentSide.SelectedUnits.ElementAt(i)).Mounts.ToList())
					{
						activeUnit3.Mounts.Add(item);
						((ActiveUnit)currentSide.SelectedUnits.ElementAt(i)).Mounts.Remove(item);
					}
					((ActiveUnit)currentSide.SelectedUnits.ElementAt(i)).Destroy(ScenEditAction: true, IsFacilityAimpoint: true, DestroyUnitNow: true, "Unit Merged", null, RegisterAsLosses: false);
				}
			}
			return new LuaWrapper_ActiveUnit_SE(a, ScenarioContext);
		}
		return null;
	}

	public static object Tool_QuerySoundLevel(LuaTable table, Scenario ScenarioContext)
	{
		Dictionary<string, object> dict = LuaUtility.ToDictUpper(table.GetEnumerator());
		ActiveUnit activeUnit = null;
		int num = 2;
		LuaUtility.ParseUnitDict(ref dict);
		Sensor.FrequencyBand theBand = Sensor.FrequencyBand.LF_Sonar;
		if (dict.ContainsKey("FREQUENCY"))
		{
			theBand = dict["FREQUENCY"].ToString().ToUpper() switch
			{
				"LF" => Sensor.FrequencyBand.LF_Sonar, 
				"MF" => Sensor.FrequencyBand.MF_Sonar, 
				"HF" => Sensor.FrequencyBand.HF_Sonar, 
				"VLF" => Sensor.FrequencyBand.VLF_Sonar, 
				_ => throw new LuaError("Invalid type for sonar frequency"), 
			};
		}
		if (dict.ContainsKey("ASPECT"))
		{
			num = dict["ASPECT"].ToString().ToUpper() switch
			{
				"FRONT" => 0, 
				"REAR" => 2, 
				"ALL" => -1, 
				"SIDE" => 1, 
				_ => throw new LuaError("Invalid aspect"), 
			};
		}
		if (dict.ContainsKey("TARGETUNITNAME"))
		{
			string b = Conversions.ToString(dict["TARGETUNITNAME"]);
			activeUnit = ((!dict.ContainsKey("TARGETSIDE")) ? ScenarioContext.ActiveUnits_List.FirstOrDefault([SpecialName] (ActiveUnit s) => string.Equals(s.Name, b, StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, b, StringComparison.OrdinalIgnoreCase)) : LuaUtility.QueryTargetSide(dict, ScenarioContext).Units.FirstOrDefault([SpecialName] (ActiveUnit s) => string.Equals(s.Name, b, StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, b, StringComparison.OrdinalIgnoreCase)));
		}
		if (activeUnit == null)
		{
			throw new Exception("No valid target unit found");
		}
		if (!activeUnit.IsNavalUnit())
		{
			throw new Exception("Specified unit is not naval");
		}
		(float, float, float) tuple = Sensor.NavalUnitNoiseInDecibels(activeUnit, theBand);
		float num2 = default(float);
		switch (num)
		{
		case -1:
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			luaTable["front"] = (float)Math.Round(tuple.Item1, 1);
			luaTable["side"] = (float)Math.Round(tuple.Item2, 1);
			luaTable["rear"] = (float)Math.Round(tuple.Item3, 1);
			return luaTable;
		}
		case 1:
			num2 = (float)Math.Round(tuple.Item2, 1);
			break;
		case 2:
			num2 = (float)Math.Round(tuple.Item3, 1);
			break;
		case 0:
			num2 = (float)Math.Round(tuple.Item1, 1);
			break;
		}
		return num2;
	}

	public static float Tool_QueryRCS(LuaTable table, Scenario ScenarioContext)
	{
		Dictionary<string, object> dict = LuaUtility.ToDictUpper(table.GetEnumerator());
		LuaUtility.ParseUnitDict(ref dict);
		ActiveUnit activeUnit = default(ActiveUnit);
		if (dict.ContainsKey("SENSORUNITNAME"))
		{
			string b = Conversions.ToString(dict["SENSORUNITNAME"]);
			activeUnit = ((!dict.ContainsKey("SENSORSIDE")) ? ScenarioContext.ActiveUnits_List.FirstOrDefault([SpecialName] (ActiveUnit s) => string.Equals(s.Name, b, StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, b, StringComparison.OrdinalIgnoreCase)) : LuaUtility.QuerySensorSide(dict, ScenarioContext).Units.FirstOrDefault([SpecialName] (ActiveUnit s) => string.Equals(s.Name, b, StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, b, StringComparison.OrdinalIgnoreCase)));
		}
		ActiveUnit activeUnit2 = default(ActiveUnit);
		if (dict.ContainsKey("TARGETUNITNAME"))
		{
			string b2 = Conversions.ToString(dict["TARGETUNITNAME"]);
			activeUnit2 = (dict.ContainsKey("TARGETSIDE") ? LuaUtility.QueryTargetSide(dict, ScenarioContext).Units.FirstOrDefault([SpecialName] (ActiveUnit s) => string.Equals(s.Name, b2, StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, b2, StringComparison.OrdinalIgnoreCase)) : ScenarioContext.ActiveUnits_List.FirstOrDefault([SpecialName] (ActiveUnit s) => string.Equals(s.Name, b2, StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, b2, StringComparison.OrdinalIgnoreCase)));
		}
		if (!(activeUnit == null || activeUnit2 == null))
		{
			ActiveUnit myUnit = activeUnit;
			ActiveUnit observerUnit = activeUnit2;
			string feedbackMessage = "";
			float targetAspect = Math2.NormalizeBearing(Module_Unit.AngleOffThisUnitsBoresight(myUnit, observerUnit, DistinguishBetweenStarboardAndPort: false, ref feedbackMessage, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue));
			XSection._SignatureType desiredSignatureType = default(XSection._SignatureType);
			if (dict.ContainsKey("SIGNATURETYPE"))
			{
				desiredSignatureType = (XSection._SignatureType)Enum.Parse(typeof(XSection._SignatureType), Conversions.ToString(dict["SIGNATURETYPE"]));
			}
			XSection xSection = Sensor.smethod_0(activeUnit2, desiredSignatureType);
			float desiredXSectionValue = RadarModel.GetDesiredXSectionValue(xSection, activeUnit2, targetAspect);
			if (xSection.isDBInvisible(activeUnit2))
			{
				return 0f;
			}
			return desiredXSectionValue;
		}
		throw new Exception("auSensor Is Nothing Or auTarget Is Nothing");
	}

	public static bool ScenEdit_TransferMount(string fromName, string toName, LuaTable mountList, Scenario ScenarioContext)
	{
		bool flag = false;
		new List<Mount>();
		new List<ActiveUnit>();
		ActiveUnit activeUnit = null;
		ActiveUnit activeUnit2 = null;
		try
		{
			activeUnit = smethod_1(fromName, ScenarioContext);
			activeUnit2 = smethod_1(toName, ScenarioContext);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at PM198", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		if (!Information.IsNothing((object)activeUnit))
		{
			if (Information.IsNothing((object)activeUnit2))
			{
				throw new LuaError("To unit not found!");
			}
			int result;
			if ((object)activeUnit.get_UnitSide(SetSideOnly: false).ObjectID == activeUnit2.get_UnitSide(SetSideOnly: false).ObjectID && activeUnit2.IsSplittable() && activeUnit.IsSplittable())
			{
				if (activeUnit.RangeToUnit_Horiz(activeUnit2) < 0.2f)
				{
					try
					{
						List<object> list = LuaUtility.ToArray(mountList.GetEnumerator());
						foreach (object item in list)
						{
							object? objectValue = RuntimeHelpers.GetObjectValue(item);
							string text = null;
							text = Conversions.ToString(objectValue);
							foreach (Mount item2 in activeUnit.Mounts.ToList())
							{
								if (Operators.CompareString(item2.ObjectID, text, false) == 0)
								{
									activeUnit2.Mounts.Add(item2);
									activeUnit.Mounts.Remove(item2);
								}
							}
						}
						int num;
						if (activeUnit.Mounts.Count == 0)
						{
							activeUnit.Destroy(ScenEditAction: true, IsFacilityAimpoint: true, DestroyUnitNow: true, "Unit Merged", null, RegisterAsLosses: false);
							num = 1;
						}
						else
						{
							num = 1;
						}
						flag = (byte)num != 0;
					}
					catch (Exception ex3)
					{
						ProjectData.SetProjectError(ex3);
						Exception ex4 = ex3;
						ex4?.Data.Add("Error at PM199", "");
						GameGeneral.WriteExceptionsToLog(ex4);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						throw;
					}
					return flag;
				}
				result = 0;
			}
			else
			{
				result = 0;
			}
			return (byte)result != 0;
		}
		throw new LuaError("From unit not found!");
	}

	public static bool VP_ExportUnits(LuaTable table, string fileName, Scenario ScenarioContext)
	{
		//IL_02e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e8: Expected O, but got Unknown
		Dictionary<string, object> dict = LuaUtility.ToDictUpper(table.GetEnumerator());
		Side side = null;
		new HashSet<string>();
		List<GlobalVariables.ActiveUnitType> list = new List<GlobalVariables.ActiveUnitType>();
		List<int> list2 = new List<int>();
		List<int> list3 = new List<int>();
		List<string> list4 = new List<string>();
		string text = null;
		LuaUtility.ParseUnitDict(ref dict);
		if (dict.ContainsKey("TARGETSIDE"))
		{
			try
			{
				text = Conversions.ToString(dict["TARGETSIDE"]);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at PM200", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("name must be a string");
			}
			side = ValidateSide(text, ScenarioContext);
			if (Information.IsNothing((object)side))
			{
				throw new LuaError("Unable to find side matching name: " + text);
			}
		}
		if (dict.ContainsKey("TARGETTYPE"))
		{
			List<object> list5 = LuaUtility.ToArray(((LuaTable)dict["TARGETTYPE"]).GetEnumerator());
			foreach (object item in list5)
			{
				string a = Conversions.ToString(RuntimeHelpers.GetObjectValue(item));
				byte[] array = (byte[])Enum.GetValues(typeof(GlobalVariables.ActiveUnitType));
				int num = 0;
				while (num < array.Length)
				{
					byte b = array[num];
					if (!string.Equals(a, b.ToString(), StringComparison.OrdinalIgnoreCase))
					{
						GlobalVariables.ActiveUnitType activeUnitType = (GlobalVariables.ActiveUnitType)b;
						if (!string.Equals(a, activeUnitType.ToString(), StringComparison.OrdinalIgnoreCase))
						{
							num = checked(num + 1);
							continue;
						}
					}
					list.Add((GlobalVariables.ActiveUnitType)b);
					break;
				}
			}
		}
		if (dict.ContainsKey("TARGETSUBTYPE"))
		{
			List<object> list6 = LuaUtility.ToArray(((LuaTable)dict["TARGETSUBTYPE"]).GetEnumerator());
			foreach (object item2 in list6)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(item2);
				list2.Add(Conversions.ToInteger(objectValue));
			}
		}
		if (dict.ContainsKey("SPECIFICUNITCLASS"))
		{
			List<object> list7 = LuaUtility.ToArray(((LuaTable)dict["SPECIFICUNITCLASS"]).GetEnumerator());
			foreach (object item3 in list7)
			{
				object objectValue2 = RuntimeHelpers.GetObjectValue(item3);
				list3.Add(Conversions.ToInteger(objectValue2));
			}
		}
		if (dict.ContainsKey("SPECIFICUNIT"))
		{
			List<object> list8 = LuaUtility.ToArray(((LuaTable)dict["SPECIFICUNIT"]).GetEnumerator());
			foreach (object item4 in list8)
			{
				object objectValue3 = RuntimeHelpers.GetObjectValue(item4);
				list4.Add(Conversions.ToString(objectValue3));
			}
		}
		XmlWriterSettings val = new XmlWriterSettings();
		val.Indent = true;
		val.IndentChars = "    ";
		val.ConformanceLevel = (ConformanceLevel)0;
		string text2 = GameGeneral.ScenariosRootPath;
		string text3 = text2 + "\\" + fileName;
		if (ScenarioContext.IsRunningInCampaignMode)
		{
			List<string> list9 = new List<string>();
			Campaign.GetCampaignsInFolder(GameGeneral.ScenariosRootPath, list9);
			foreach (string item5 in list9)
			{
				if (Operators.CompareString(Campaign.ReadFromFile(item5).ID, ScenarioContext.CampaignID, false) == 0)
				{
					text3 = Path.Combine(text2 = Path.GetDirectoryName(item5), ScenarioContext.CampaignSessionID) + ScenarioContext.ObjectID;
					break;
				}
			}
		}
		using (MemoryStream memoryStream = RCMS.recyclableMemoryStreamManager_0.GetStream())
		{
			XmlWriter val2 = XmlWriter.Create((Stream)memoryStream, val);
			string text4 = "Scenario: " + ScenarioContext.Title + "\r\nScenario file: " + text2 + "\\" + ScenarioContext.FileName + ".scen";
			StreamWriter streamWriter = File.AppendText(GameGeneral.LogsPath + Conversions.ToString(Path.DirectorySeparatorChar) + "LuaExport.txt");
			streamWriter.Write("\r\n\r\n" + text4);
			DBOps.DBFileCheckResult theResult = default(DBOps.DBFileCheckResult);
			DBRecord dBRecordByHash = DBOps.GetDBRecordByHash(ScenarioContext.DBUsed, ref theResult);
			val2.WriteStartElement("ContentScenario");
			val2.WriteElementString("CampaignID", ScenarioContext.CampaignID);
			val2.WriteElementString("CampaignSessionID", ScenarioContext.CampaignSessionID);
			val2.WriteElementString("CampaignScore", ScenarioContext.CampaignScore.ToString());
			val2.WriteElementString("DBused", ScenarioContext.DBUsed);
			val2.WriteElementString("DBfilename", dBRecordByHash.FileName);
			val2.WriteElementString("ScenarioID", ScenarioContext.ObjectID);
			val2.WriteElementString("Title", ScenarioContext.Title);
			val2.WriteElementString("Description", ScenarioContext.Description);
			val2.WriteElementString("FileName", ScenarioContext.FileName);
			val2.WriteElementString("FileNamePath", ScenarioContext.FileNamePath);
			val2.WriteStartElement("ActiveUnits");
			using (PooledList<ActiveUnit>.Enumerator enumerator6 = ScenarioContext.ActiveUnits_List.GetEnumerator())
			{
				int ErrorCount = default(int);
				for (; enumerator6.MoveNext(); streamWriter.Flush())
				{
					ActiveUnit current2 = enumerator6.Current;
					ActiveUnit activeUnit = null;
					if (current2.IsGroup)
					{
						continue;
					}
					bool flag = false;
					bool? flag2 = null;
					if (!Information.IsNothing((object)side))
					{
						flag2 = ((!current2.get_UnitSide(SetSideOnly: false).Equals(side)) ? new bool?(false) : new bool?(true));
					}
					if (list.Count > 0)
					{
						foreach (GlobalVariables.ActiveUnitType item6 in list)
						{
							if (item6 == current2.UnitType)
							{
								flag = true;
								break;
							}
						}
					}
					if (list2.Count > 0)
					{
						foreach (int item7 in list2)
						{
							if (item7 == current2.SubType)
							{
								flag = true;
								break;
							}
						}
					}
					if (list3.Count > 0)
					{
						foreach (int item8 in list3)
						{
							if (item8 == current2.DBID)
							{
								flag = true;
								break;
							}
						}
					}
					if (list4.Count > 0)
					{
						foreach (string item9 in list4)
						{
							if (Operators.CompareString(item9, current2.ObjectID, false) == 0)
							{
								flag = true;
								break;
							}
						}
					}
					if (!flag)
					{
						if (current2.IsAircraft)
						{
							Aircraft_AirOps aircraft_AirOps = (Aircraft_AirOps)current2.AirOps;
							if (aircraft_AirOps.CurrentHostUnit == null)
							{
								if (aircraft_AirOps.ActualDestinationHost != null)
								{
									activeUnit = aircraft_AirOps.ActualDestinationHost;
								}
							}
							else
							{
								activeUnit = aircraft_AirOps.CurrentHostUnit;
							}
						}
						if (current2.IsShip || current2.IsSubmarine)
						{
							ActiveUnit_DockingOps dockingOps = current2.DockingOps;
							if (dockingOps.CurrentHostUnit != null && Operators.CompareString(dockingOps.CurrentHostUnit.ObjectID, current2.ObjectID, false) == 0)
							{
								activeUnit = dockingOps.CurrentHostUnit;
							}
							else if (dockingOps.ActualDestinationHost != null && Operators.CompareString(dockingOps.ActualDestinationHost.ObjectID, current2.ObjectID, false) == 0)
							{
								activeUnit = dockingOps.ActualDestinationHost;
							}
						}
						if (activeUnit != null)
						{
							if (list.Count > 0)
							{
								foreach (GlobalVariables.ActiveUnitType item10 in list)
								{
									if (item10 == activeUnit.UnitType)
									{
										flag = true;
										break;
									}
								}
							}
							if (list2.Count > 0)
							{
								foreach (int item11 in list2)
								{
									if (item11 == activeUnit.SubType)
									{
										flag = true;
										break;
									}
								}
							}
							if (list3.Count > 0)
							{
								foreach (int item12 in list3)
								{
									if (item12 == activeUnit.DBID)
									{
										flag = true;
										break;
									}
								}
							}
							if (list4.Count > 0)
							{
								foreach (string item13 in list4)
								{
									if (Operators.CompareString(item13, activeUnit.ObjectID, false) == 0)
									{
										flag = true;
										break;
									}
								}
							}
						}
					}
					if (!flag)
					{
						continue;
					}
					if (!Information.IsNothing((object)flag2))
					{
						bool? flag3 = flag2;
						flag3 = flag3;
						if (flag3 != true)
						{
							continue;
						}
					}
					val2.WriteStartElement("ActiveUnit");
					val2.WriteElementString("ID", current2.ObjectID);
					val2.WriteElementString("Name", current2.Name);
					val2.WriteComment(current2.Name + " (" + current2.UnitClass + " [" + Conversions.ToString(current2.DBID) + "])");
					val2.WriteElementString("DBID", current2.DBID.ToString());
					val2.WriteElementString("UnitSubtype", current2.SubType.ToString());
					val2.WriteElementString("UnitType", current2.UnitType.ToString());
					val2.WriteElementString("SideName", current2.get_UnitSide(SetSideOnly: false).Name);
					if (activeUnit != null)
					{
						val2.WriteElementString("Hosted", activeUnit.ObjectID);
					}
					SBR.GenerateDeltaFragmentForThisUnit(current2, current2.ParentScen, val2, streamWriter, ref ErrorCount);
					val2.WriteStartElement("Damage");
					if (current2.get_DamagePts(ScenEditAction: false, (Weapon)null) != (float)current2.InitialDP)
					{
						val2.WriteElementString("DamagePts", XmlConvert.ToString(current2.get_DamagePts(ScenEditAction: false, (Weapon)null)));
					}
					if ((int)current2.Damage.FireIntensity > 0)
					{
						val2.WriteElementString("Fire", ((byte)current2.Damage.FireIntensity).ToString());
					}
					if ((int)current2.Damage.FloodIntensity > 0)
					{
						val2.WriteElementString("Flood", ((byte)current2.Damage.FloodIntensity).ToString());
					}
					switch (current2.UnitType)
					{
					case GlobalVariables.ActiveUnitType.Ship:
					{
						Ship ship = (Ship)current2;
						if (ship.CIC.Status != PlatformComponent._ComponentStatus.Operational)
						{
							val2.WriteElementString("CIC_St", ((byte)ship.CIC.Status).ToString());
						}
						if (ship.CIC.DamageSeverity != PlatformComponent._DamageSeverityFactor.Light)
						{
							val2.WriteElementString("CIC_DamageSeverity", ((byte)ship.CIC.DamageSeverity).ToString());
						}
						if (ship.Rudder.Status != PlatformComponent._ComponentStatus.Operational)
						{
							val2.WriteElementString("Rudder_St", ((byte)ship.Rudder.Status).ToString());
						}
						if (ship.Rudder.DamageSeverity != PlatformComponent._DamageSeverityFactor.Light)
						{
							val2.WriteElementString("Rudder_DamageSeverity", ((byte)ship.Rudder.DamageSeverity).ToString());
						}
						break;
					}
					case GlobalVariables.ActiveUnitType.Submarine:
					{
						Submarine submarine = (Submarine)current2;
						if (submarine.CIC.Status != PlatformComponent._ComponentStatus.Operational)
						{
							val2.WriteElementString("CIC_St", ((byte)submarine.CIC.Status).ToString());
						}
						if (submarine.CIC.DamageSeverity != PlatformComponent._DamageSeverityFactor.Light)
						{
							val2.WriteElementString("CIC_DamageSeverity", ((byte)submarine.CIC.DamageSeverity).ToString());
						}
						if (submarine.Rudder.Status != PlatformComponent._ComponentStatus.Operational)
						{
							val2.WriteElementString("Rudder_St", ((byte)submarine.Rudder.Status).ToString());
						}
						if (submarine.Rudder.DamageSeverity != PlatformComponent._DamageSeverityFactor.Light)
						{
							val2.WriteElementString("Rudder_DamageSeverity", ((byte)submarine.Rudder.DamageSeverity).ToString());
						}
						if (submarine.PressureHull.Status != PlatformComponent._ComponentStatus.Operational)
						{
							val2.WriteElementString("PressureHull_St", ((byte)submarine.PressureHull.Status).ToString());
						}
						if (submarine.PressureHull.DamageSeverity != PlatformComponent._DamageSeverityFactor.Light)
						{
							val2.WriteElementString("PressureHull_DamageSeverity", ((byte)submarine.PressureHull.DamageSeverity).ToString());
						}
						if (submarine.Cargo.Status != PlatformComponent._ComponentStatus.Operational)
						{
							val2.WriteElementString("Cargo_St", ((byte)submarine.Cargo.Status).ToString());
						}
						if (submarine.Cargo.DamageSeverity != PlatformComponent._DamageSeverityFactor.Light)
						{
							val2.WriteElementString("Cargo_DamageSeverity", ((byte)submarine.Cargo.DamageSeverity).ToString());
						}
						break;
					}
					case GlobalVariables.ActiveUnitType.Facility:
					{
						Facility facility = (Facility)current2;
						if (facility.CIC.Status != PlatformComponent._ComponentStatus.Operational)
						{
							val2.WriteElementString("CIC_St", ((byte)facility.CIC.Status).ToString());
						}
						if (facility.CIC.DamageSeverity != PlatformComponent._DamageSeverityFactor.Light)
						{
							val2.WriteElementString("CIC_DamageSeverity", ((byte)facility.CIC.DamageSeverity).ToString());
						}
						if (facility.Cargo.Status != PlatformComponent._ComponentStatus.Operational)
						{
							val2.WriteElementString("Cargo_St", ((byte)facility.Cargo.Status).ToString());
						}
						if (facility.Cargo.DamageSeverity != PlatformComponent._DamageSeverityFactor.Light)
						{
							val2.WriteElementString("Cargo_DamageSeverity", ((byte)facility.Cargo.DamageSeverity).ToString());
						}
						break;
					}
					}
					val2.WriteStartElement("Sensors");
					Sensor[] sensors_Cached = current2.Sensors_Cached;
					foreach (Sensor sensor in sensors_Cached)
					{
						if (sensor.Status != PlatformComponent._ComponentStatus.Operational || sensor.DamageSeverity != PlatformComponent._DamageSeverityFactor.Light)
						{
							val2.WriteStartElement("Sensor");
							val2.WriteElementString("ID", sensor.ObjectID);
							val2.WriteElementString("Name", sensor.Name);
							val2.WriteElementString("DBID", sensor.DBID.ToString());
							if (sensor.Status != PlatformComponent._ComponentStatus.Operational)
							{
								val2.WriteElementString("St", ((byte)sensor.Status).ToString());
							}
							if (sensor.DamageSeverity != PlatformComponent._DamageSeverityFactor.Light)
							{
								val2.WriteElementString("DamageSeverity", ((byte)sensor.DamageSeverity).ToString());
							}
							val2.WriteEndElement();
						}
					}
					val2.WriteEndElement();
					val2.WriteStartElement("Comms");
					CommDevice[] comms_ReadOnly = current2.Comms_ReadOnly;
					foreach (CommDevice commDevice in comms_ReadOnly)
					{
						if (commDevice.Status != PlatformComponent._ComponentStatus.Operational || commDevice.DamageSeverity != PlatformComponent._DamageSeverityFactor.Light)
						{
							val2.WriteStartElement("CD");
							val2.WriteElementString("ID", commDevice.ObjectID);
							val2.WriteElementString("Name", commDevice.Name);
							val2.WriteElementString("DBID", commDevice.DBID.ToString());
							if (commDevice.Status != PlatformComponent._ComponentStatus.Operational)
							{
								val2.WriteElementString("St", ((byte)commDevice.Status).ToString());
							}
							if (commDevice.DamageSeverity != PlatformComponent._DamageSeverityFactor.Light)
							{
								val2.WriteElementString("DamageSeverity", ((byte)commDevice.DamageSeverity).ToString());
							}
							val2.WriteEndElement();
						}
					}
					val2.WriteEndElement();
					val2.WriteStartElement("Propulsion");
					foreach (Engine item14 in current2.Propulsion)
					{
						if (item14.Status != PlatformComponent._ComponentStatus.Operational || item14.DamageSeverity != PlatformComponent._DamageSeverityFactor.Light)
						{
							val2.WriteStartElement("Engine");
							val2.WriteElementString("ID", item14.ObjectID);
							val2.WriteElementString("Name", item14.Name);
							val2.WriteElementString("DBID", item14.DBID.ToString());
							if (item14.Status != PlatformComponent._ComponentStatus.Operational)
							{
								val2.WriteElementString("Status", ((byte)item14.Status).ToString());
							}
							if (item14.DamageSeverity != PlatformComponent._DamageSeverityFactor.Light)
							{
								val2.WriteElementString("DamageSeverity", ((byte)item14.DamageSeverity).ToString());
							}
							val2.WriteEndElement();
						}
					}
					val2.WriteEndElement();
					val2.WriteStartElement("Mounts");
					foreach (Mount mount in current2.Mounts)
					{
						if (mount.Status != PlatformComponent._ComponentStatus.Operational || mount.DamageSeverity != PlatformComponent._DamageSeverityFactor.Light)
						{
							val2.WriteStartElement("Mount");
							val2.WriteElementString("ID", mount.ObjectID);
							val2.WriteElementString("Name", mount.Name);
							val2.WriteElementString("DBID", mount.DBID.ToString());
							if (mount.Status != PlatformComponent._ComponentStatus.Operational)
							{
								val2.WriteElementString("St", ((byte)mount.Status).ToString());
							}
							if (mount.DamageSeverity != PlatformComponent._DamageSeverityFactor.Light)
							{
								val2.WriteElementString("DamageSeverity", ((byte)mount.DamageSeverity).ToString());
							}
							val2.WriteEndElement();
						}
					}
					val2.WriteEndElement();
					val2.WriteStartElement("Magazines");
					Magazine[] sharedMagazines = current2.SharedMagazines;
					foreach (Magazine magazine in sharedMagazines)
					{
						if (magazine.Status != PlatformComponent._ComponentStatus.Operational || magazine.DamageSeverity != PlatformComponent._DamageSeverityFactor.Light)
						{
							val2.WriteStartElement("Mag");
							val2.WriteElementString("ID", magazine.ObjectID);
							val2.WriteElementString("Name", magazine.Name);
							val2.WriteElementString("DBID", magazine.DBID.ToString());
							if (magazine.Status != PlatformComponent._ComponentStatus.Operational)
							{
								val2.WriteElementString("St", ((byte)magazine.Status).ToString());
							}
							if (magazine.DamageSeverity != PlatformComponent._DamageSeverityFactor.Light)
							{
								val2.WriteElementString("DamageSeverity", ((byte)magazine.DamageSeverity).ToString());
							}
							val2.WriteEndElement();
						}
					}
					val2.WriteEndElement();
					val2.WriteStartElement("OnboardCargo");
					Cargo[] onboardCargo = current2.OnboardCargo;
					foreach (Cargo cargo in onboardCargo)
					{
						if (cargo.Status != PlatformComponent._ComponentStatus.Operational || cargo.DamageSeverity != PlatformComponent._DamageSeverityFactor.Light)
						{
							val2.WriteStartElement("Cargo");
							val2.WriteElementString("ID", cargo.ObjectID);
							val2.WriteElementString("Name", cargo.Name);
							val2.WriteElementString("DBID", cargo.DBID.ToString());
							if (cargo.Status != PlatformComponent._ComponentStatus.Operational)
							{
								val2.WriteElementString("St", ((byte)cargo.Status).ToString());
							}
							if (cargo.DamageSeverity != PlatformComponent._DamageSeverityFactor.Light)
							{
								val2.WriteElementString("DamageSeverity", ((byte)cargo.DamageSeverity).ToString());
							}
							val2.WriteEndElement();
						}
					}
					val2.WriteEndElement();
					val2.WriteEndElement();
					val2.WriteEndElement();
				}
			}
			streamWriter.Close();
			val2.WriteEndElement();
			val2.WriteEndElement();
			val2.Flush();
			val2.Close();
			StreamWriter streamWriter2 = new StreamWriter(text3 + ".exu");
			using (streamWriter2)
			{
				streamWriter2.Write(Misc.ConvertToString(memoryStream));
				streamWriter2.Flush();
				streamWriter2.Close();
			}
		}
		return true;
	}

	public static int World_GetElevation(LuaTable table, Scenario ScenarioContext)
	{
		Dictionary<string, object> dict = LuaUtility.ToDictUpper(table.GetEnumerator());
		double? num = LuaUtility.QueryLatitude(dict);
		if (!num.HasValue)
		{
			throw new LuaError("Missing 'Latitude'");
		}
		double? num2 = LuaUtility.QueryLongitude(dict);
		if (!num2.HasValue)
		{
			throw new LuaError("Missing 'Longitude'");
		}
		num = Math2.NormalizeLatitude(num.Value);
		num2 = Math2.NormalizeLongitude(num2.Value);
		return Terrain.GetElevation(num.Value, num2.Value, RequestIsFromGUI: false, ScenarioContext);
	}

	public static LuaTable GetLocationLuaTable(double Latitude, double Longitude, Scenario TheScen)
	{
		LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
		Geopoint_Struct geopoint_Struct = default(Geopoint_Struct);
		geopoint_Struct.Latitude = Latitude;
		geopoint_Struct.Longitude = Longitude;
		geopoint_Struct.Altitude = Terrain.GetElevation(Latitude, Longitude, RequestIsFromGUI: false, TheScen);
		if (geopoint_Struct.Latitude <= 90.0 && geopoint_Struct.Latitude >= -90.0 && geopoint_Struct.Longitude <= 180.0 && geopoint_Struct.Longitude >= -180.0)
		{
			luaTable["altitude"] = geopoint_Struct.Altitude;
			if (geopoint_Struct.Altitude < 0f)
			{
				int LayerCeiling = default(int);
				int LayerFloor = default(int);
				float LayerStrengthPercentage = default(float);
				SonarModel.GetThermalLayerAtThisLocation(geopoint_Struct.Latitude, geopoint_Struct.Longitude, (int)Math.Round(geopoint_Struct.Altitude), ref LayerCeiling, ref LayerFloor, ref LayerStrengthPercentage, RequestIsFromGUI: true, TheScen);
				LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
				luaTable2["ceiling"] = LayerCeiling;
				luaTable2["floor"] = LayerFloor;
				luaTable2["strength"] = Math.Round(LayerStrengthPercentage, 2);
				luaTable["layer"] = luaTable2;
				if (geopoint_Struct.Altitude < (float)SonarModel.MinimumDepthForCZ_m(geopoint_Struct.Latitude))
				{
					int num = (int)Math.Round(SonarModel.smethod_0(geopoint_Struct.Latitude, geopoint_Struct.Longitude, null, TheScen));
					luaTable2 = LuaSandBox.Singleton().CreateTable();
					luaTable2["1"] = num;
					luaTable2["2"] = 2 * num;
					luaTable2["3"] = 3 * num;
					luaTable2["4"] = 4 * num;
					luaTable["cz"] = luaTable2;
				}
			}
			else
			{
				luaTable["slope"] = (int)Math.Round(100f * Terrain.GetMaxSlope(geopoint_Struct.Latitude, geopoint_Struct.Longitude, RequestIsFromGUI: true, TheScen));
				string text = "";
				LandCover.LandCoverType landCoverAtThisPoint = LandCover.GetLandCoverAtThisPoint(geopoint_Struct.Latitude, geopoint_Struct.Longitude, TheScen);
				text = LandCover.GetUILabelText_LandCover(landCoverAtThisPoint);
				LuaTable luaTable3 = LuaSandBox.Singleton().CreateTable();
				luaTable3["text"] = text;
				luaTable3["value"] = (int)landCoverAtThisPoint;
				luaTable["cover"] = luaTable3;
			}
		}
		return luaTable;
	}

	public static LuaTable World_GetLocation(LuaTable table, Scenario theScen)
	{
		Dictionary<string, object> dict = LuaUtility.ToDictUpper(table.GetEnumerator());
		double? num = LuaUtility.QueryLatitude(dict);
		if (num.HasValue)
		{
			double? num2 = LuaUtility.QueryLongitude(dict);
			if (!num2.HasValue)
			{
				throw new LuaError("Missing 'Longitude'");
			}
			return GetLocationLuaTable(num.Value, num2.Value, theScen);
		}
		throw new LuaError("Missing 'Latitude'");
	}

	public static LuaTable World_GetCircleFromPoint(LuaTable table)
	{
		try
		{
			int num = 45;
			Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(table.GetEnumerator());
			double? num2 = LuaUtility.QueryLatitude(dictionary);
			if (!num2.HasValue)
			{
				throw new LuaError("Missing 'Latitude'");
			}
			double? num3 = LuaUtility.QueryLongitude(dictionary);
			if (!num3.HasValue)
			{
				throw new LuaError("Missing 'Longitude'");
			}
			if (dictionary.ContainsKey("NUMPOINTS"))
			{
				try
				{
					num = Conversions.ToInteger(dictionary["NUMPOINTS"]);
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error at PM201", "");
					GameGeneral.WriteExceptionsToLog(ex2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("Numpoints must be an integer");
				}
			}
			if (dictionary.ContainsKey("RADIUS"))
			{
				float num4;
				try
				{
					num4 = Conversions.ToSingle(dictionary["RADIUS"]);
				}
				catch (Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					Exception ex4 = ex3;
					ex4?.Data.Add("Error at PM202", "");
					GameGeneral.WriteExceptionsToLog(ex4);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("Radius must be a number");
				}
				Geodesic_Vincenty.Point3D[] CirclePoints = new Geodesic_Vincenty.Point3D[num + 1];
				Geodesic_Vincenty.CircleFromPoint(num2.Value, num3.Value, num4, num, ref CirclePoints);
				LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
				int num5 = 1;
				Geodesic_Vincenty.Point3D[] array = CirclePoints;
				for (int i = 0; i < array.Length; i = checked(i + 1))
				{
					Geodesic_Vincenty.Point3D point3D = array[i];
					LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
					luaTable2["latitude"] = point3D.Y;
					luaTable2["longitude"] = point3D.X;
					luaTable2["Latitude"] = point3D.Y;
					luaTable2["Longitude"] = point3D.X;
					luaTable[num5] = luaTable2;
					num5++;
				}
				return luaTable;
			}
			throw new LuaError("Radius is not specified");
		}
		catch (Exception ex5)
		{
			ProjectData.SetProjectError(ex5);
			Exception ex6 = ex5;
			ex6?.Data.Add("Error at PM203", "");
			GameGeneral.WriteExceptionsToLog(ex6);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static LuaTable World_GetPointFromBearing(LuaTable table)
	{
		double? num = null;
		double? num2 = null;
		Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(table.GetEnumerator());
		double? num3 = LuaUtility.QueryLatitude(dictionary);
		if (num3.HasValue)
		{
			double? num4 = LuaUtility.QueryLongitude(dictionary);
			if (num4.HasValue)
			{
				if (dictionary.ContainsKey("BEARING"))
				{
					try
					{
						num2 = Conversions.ToDouble(dictionary["BEARING"]);
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						ex2?.Data.Add("Error at PM204", "");
						GameGeneral.WriteExceptionsToLog(ex2);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						throw new LuaError("Bearing must be number");
					}
				}
				if (dictionary.ContainsKey("DISTANCE"))
				{
					try
					{
						num = Conversions.ToDouble(dictionary["DISTANCE"]);
					}
					catch (Exception ex3)
					{
						ProjectData.SetProjectError(ex3);
						Exception ex4 = ex3;
						ex4?.Data.Add("Error at PM205", "");
						GameGeneral.WriteExceptionsToLog(ex4);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						throw new LuaError("Dstance must be a number");
					}
				}
				if (!Information.IsNothing((object)num2) && !Information.IsNothing((object)num))
				{
					Geodesic_Vincenty.TCoord Pt = new Geodesic_Vincenty.TCoord(num3.Value, num4.Value);
					Geodesic_Vincenty.TCoord Ret = default(Geodesic_Vincenty.TCoord);
					Geodesic_Vincenty.fw_vincenty_wgs84(ref Pt, ref Ret, num2.Value, num.Value);
					LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
					luaTable["Latitude"] = Ret.Lat;
					luaTable["Longitude"] = Ret.Lon;
					luaTable["latitude"] = Ret.Lat;
					luaTable["longitude"] = Ret.Lon;
					luaTable["latitudeDMS"] = ((Math.Sign(Ret.Lat) < 0) ? "S" : "N") + LuaUtility.DecimalDegrees_To_DMS(Math.Abs(Ret.Lat));
					luaTable["longitudeDMS"] = ((Math.Sign(Ret.Lon) < 0) ? "W" : "E") + LuaUtility.DecimalDegrees_To_DMS(Math.Abs(Ret.Lon));
					return luaTable;
				}
				throw new LuaError("Bearing and distance not defined");
			}
			throw new LuaError("Missing 'Longitude'");
		}
		throw new LuaError("Missing 'Latitude'");
	}

	public static bool? ScenEdit_UpdateRSetting(object theSetting, bool? theOption, Scenario ScenarioContext)
	{
		try
		{
			Scenario.ScenarioFeatureOption scenarioFeatureOption = (Scenario.ScenarioFeatureOption)Enum.Parse(typeof(Scenario.ScenarioFeatureOption), Conversions.ToString(theSetting));
			bool? flag = LuaUtility.ParseBoolean(theOption);
			bool flag2 = false;
			if ((object)scenarioFeatureOption != null)
			{
				if (!flag.HasValue)
				{
					return ScenarioContext.DeclaredFeatures.Contains(scenarioFeatureOption);
				}
				flag2 = true;
				if (ScenarioContext.GameContext.IsScenEditGameMode)
				{
					if (!flag2)
					{
						return false;
					}
					int value;
					if (theOption == true)
					{
						ScenarioContext.DeclaredFeatures.Add(scenarioFeatureOption);
						value = 1;
					}
					else
					{
						ScenarioContext.DeclaredFeatures.Remove(scenarioFeatureOption);
						value = 1;
					}
					return (byte)value != 0;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at PM206", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
		return null;
	}

	public static bool Tool_BuildBlankScenario(string dbHash)
	{
		bool result;
		try
		{
			LuaNewBlankScenarioEventHandler luaNewBlankScenarioEventHandler = luaNewBlankScenarioEventHandler_0;
			int num;
			if (luaNewBlankScenarioEventHandler == null)
			{
				num = 1;
			}
			else
			{
				luaNewBlankScenarioEventHandler(dbHash);
				num = 1;
			}
			result = (byte)num != 0;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static bool Tool_ResetMessageLog(bool dumpToFile, Scenario theScen)
	{
		bool result;
		try
		{
			LuaResetMessageLogEventHandler luaResetMessageLogEventHandler = luaResetMessageLogEventHandler_0;
			int num;
			if (luaResetMessageLogEventHandler == null)
			{
				num = 1;
			}
			else
			{
				luaResetMessageLogEventHandler(theScen, dumpToFile);
				num = 1;
			}
			result = (byte)num != 0;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static bool Tool_Scen_Migration(string scenarioFilePath, string configFilePath, DBRecord useThisDB)
	{
		object objectValue = RuntimeHelpers.GetObjectValue(SBR.MigrateScenario(scenarioFilePath, configFilePath, useThisDB));
		if (!(objectValue is bool))
		{
			return false;
		}
		return Conversions.ToBoolean(objectValue);
	}

	public static string Tool_ConvertToDMS(double myLat, double myLon)
	{
		string result;
		try
		{
			string text = ((Math.Sign(myLat) < 0) ? "S" : "N") + LuaUtility.DecimalDegrees_To_DMS(Math.Abs(myLat));
			string text2 = ((Math.Sign(myLon) < 0) ? "W" : "E") + LuaUtility.DecimalDegrees_To_DMS(Math.Abs(myLon));
			result = text + " , " + text2;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static LuaTable ScenEdit_WeaponAllocation(string attacker, string contact, string side, Scenario ScenarioContext)
	{
		ActiveUnit theAttacker = null;
		Contact theTarget = null;
		Side theSide = null;
		if (!string.IsNullOrEmpty(side))
		{
			theSide = ValidateSide(side, ScenarioContext);
		}
		if (!string.IsNullOrEmpty(attacker))
		{
			theAttacker = smethod_1(attacker, ScenarioContext);
		}
		if (!string.IsNullOrEmpty(contact))
		{
			theTarget = ValidateContactBySceanrio(contact, ScenarioContext);
		}
		if (!(theAttacker == null && theTarget == null))
		{
			List<WeaponSalvo> list = default(List<WeaponSalvo>);
			if (theAttacker != null && theTarget != null)
			{
				list = theAttacker.get_UnitSide(SetSideOnly: false).WeaponSalvosFromThisUnitToThisTarget(ref theAttacker, theTarget).ToList();
			}
			else if (theTarget == null)
			{
				list = theAttacker.get_UnitSide(SetSideOnly: false).WeaponSalvosFromThisUnitToAnyTarget(ref theAttacker);
			}
			else if (theTarget != null && theSide != null)
			{
				list = theSide.WeaponSalvosFromAnyUnitToThisTarget(ref theTarget, ref theSide);
			}
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			if (list != null && list.Count > 0)
			{
				foreach (WeaponSalvo item in list)
				{
					WeaponSalvo.Shooter[] shootersList = item.ShootersList;
					foreach (WeaponSalvo.Shooter shooter in shootersList)
					{
						LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
						luaTable2["shooter"] = shooter.ShooterObjectID;
						luaTable2["target"] = item.Target.ObjectID;
						luaTable2["qtyAssigned"] = shooter.QuantityAssigned;
						luaTable2["qtyFired"] = shooter.QuantityFired;
						luaTable2["weapon"] = item.int_1;
						luaTable2["weaponName"] = item.get_ReferenceWeapon(ScenarioContext).Name;
						if (shooter.QuantityAssigned <= 2147473647)
						{
							_ = Conversions.ToString(shooter.QuantityAssigned - shooter.QuantityFired) + "x ";
						}
						luaTable2["salvo"] = new LuaWrapper_WeaponSalvo(item, ScenarioContext);
						luaTable[luaTable.Keys.Count + 1] = luaTable2;
					}
				}
			}
			return luaTable;
		}
		return null;
	}

	public static Side ValidateSide(string SideName, Scenario theScen)
	{
		Side result = null;
		Side[] sides_ReadOnly = theScen.Sides_ReadOnly;
		foreach (Side side in sides_ReadOnly)
		{
			if (string.Equals(side.Name, SideName, StringComparison.OrdinalIgnoreCase) || string.Equals(side.ObjectID, SideName, StringComparison.OrdinalIgnoreCase))
			{
				result = side;
				break;
			}
		}
		return result;
	}

	public static ActiveUnit smethod_1(string string_0, Scenario theScen)
	{
		ActiveUnit result = null;
		KeyValuePair<string, ActiveUnit>[] array = theScen.ActiveUnits.ToArray();
		int num = 0;
		ActiveUnit value;
		while (true)
		{
			if (num < array.Length)
			{
				KeyValuePair<string, ActiveUnit> keyValuePair = array[num];
				value = keyValuePair.Value;
				if (value != null && (string.Equals(value?.Name, string_0, StringComparison.OrdinalIgnoreCase) || string.Equals(value?.ObjectID, string_0, StringComparison.OrdinalIgnoreCase)))
				{
					break;
				}
				num = checked(num + 1);
				continue;
			}
			return result;
		}
		return value;
	}

	public static ActiveUnit ValidateAUBySide(string string_0, Side theSide)
	{
		ActiveUnit result = null;
		foreach (ActiveUnit unit in theSide.Units)
		{
			if (string.Equals(unit.Name, string_0, StringComparison.OrdinalIgnoreCase) || string.Equals(unit.ObjectID, string_0, StringComparison.OrdinalIgnoreCase))
			{
				result = unit;
				break;
			}
		}
		return result;
	}

	public static Contact ValidateContactBySceanrio(string string_0, Scenario theScen)
	{
		Contact result = null;
		Side[] sides_ReadOnly = theScen.Sides_ReadOnly;
		foreach (Side side in sides_ReadOnly)
		{
			foreach (Contact contacts_ in side.Contacts_List)
			{
				if (string.Equals(contacts_.Name, string_0, StringComparison.OrdinalIgnoreCase) || string.Equals(contacts_.ObjectID, string_0, StringComparison.OrdinalIgnoreCase))
				{
					result = contacts_;
					return result;
				}
			}
			foreach (Contact baseContacts_ in side.BaseContacts_List)
			{
				if (string.Equals(baseContacts_.Name, string_0, StringComparison.OrdinalIgnoreCase) || string.Equals(baseContacts_.ObjectID, string_0, StringComparison.OrdinalIgnoreCase))
				{
					result = baseContacts_;
					return result;
				}
			}
			foreach (string key in side.NewContactsQueue.Keys)
			{
				Contact contact = side.NewContactsQueue[key];
				if (string.Equals(contact.Name, string_0, StringComparison.OrdinalIgnoreCase) || string.Equals(contact.ObjectID, string_0, StringComparison.OrdinalIgnoreCase))
				{
					result = contact;
					return result;
				}
			}
			foreach (string key2 in side.NewBaseContactsQueue.Keys)
			{
				Contact contact2 = side.NewBaseContactsQueue[key2];
				if (string.Equals(contact2.Name, string_0, StringComparison.OrdinalIgnoreCase) || string.Equals(contact2.ObjectID, string_0, StringComparison.OrdinalIgnoreCase))
				{
					result = contact2;
					return result;
				}
			}
		}
		return result;
	}

	public static Contact ValidateContactBySide(string string_0, int tracknumber, Side theSide)
	{
		Contact contact = null;
		foreach (Contact contacts_ in theSide.Contacts_List)
		{
			if ((tracknumber > 0 && contacts_.AutoIncrement == tracknumber) || string.Equals(contacts_.Name, string_0, StringComparison.OrdinalIgnoreCase) || string.Equals(contacts_.ObjectID, string_0, StringComparison.OrdinalIgnoreCase))
			{
				contact = contacts_;
				return contact;
			}
		}
		if (contact == null)
		{
			foreach (Contact baseContacts_ in theSide.BaseContacts_List)
			{
				if ((tracknumber > 0 && baseContacts_.AutoIncrement == tracknumber) || string.Equals(baseContacts_.Name, string_0, StringComparison.OrdinalIgnoreCase) || string.Equals(baseContacts_.ObjectID, string_0, StringComparison.OrdinalIgnoreCase))
				{
					contact = baseContacts_;
					return contact;
				}
			}
		}
		return contact;
	}

	public static ActiveUnit NextAUBySceanrio(string AUGUID, string AUName, Scenario theScen, bool useParentGroup = true)
	{
		ActiveUnit result = null;
		bool flag = false;
		Group obj = null;
		foreach (ActiveUnit activeUnits_ in theScen.ActiveUnits_List)
		{
			if (Information.IsNothing((object)activeUnits_))
			{
				continue;
			}
			if (string.Equals(activeUnits_.ObjectID, AUGUID, StringComparison.OrdinalIgnoreCase))
			{
				flag = true;
				if (useParentGroup)
				{
					obj = activeUnits_.get_ParentGroup(UsingMissionPlanner: false);
				}
			}
			else if (flag && string.Equals(activeUnits_.Name, AUName, StringComparison.OrdinalIgnoreCase) && (obj == null || Operators.CompareString(obj.ObjectID, activeUnits_.get_ParentGroup(UsingMissionPlanner: false).ObjectID, false) == 0))
			{
				result = activeUnits_;
				break;
			}
		}
		return result;
	}

	public static ReferencePoint ValidateRPBySide(string NameOrID, Side theSide)
	{
		_Closure$__209-0 arg = default(_Closure$__209-0);
		_Closure$__209-0 CS$<>8__locals13 = new _Closure$__209-0(arg);
		CS$<>8__locals13.$VB$Local_NameOrID = NameOrID;
		ReferencePoint referencePoint = theSide.RefPoints.FirstOrDefault([SpecialName] (ReferencePoint s) => string.Equals(s.ObjectID, CS$<>8__locals13.$VB$Local_NameOrID, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Name, CS$<>8__locals13.$VB$Local_NameOrID, StringComparison.OrdinalIgnoreCase));
		if (Information.IsNothing((object)referencePoint))
		{
			foreach (NoNavZone noNavZone in theSide.NoNavZones)
			{
				referencePoint = noNavZone.Area.FirstOrDefault((CS$<>8__locals13.$I1 != null) ? CS$<>8__locals13.$I1 : (CS$<>8__locals13.$I1 = [SpecialName] (ReferencePoint s) => string.Equals(s.ObjectID, CS$<>8__locals13.$VB$Local_NameOrID, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Name, CS$<>8__locals13.$VB$Local_NameOrID, StringComparison.OrdinalIgnoreCase)));
				if (!Information.IsNothing((object)referencePoint))
				{
					break;
				}
			}
		}
		if (Information.IsNothing((object)referencePoint))
		{
			foreach (ExclusionZone exclusionZone in theSide.ExclusionZones)
			{
				referencePoint = exclusionZone.Area.FirstOrDefault((CS$<>8__locals13.$I2 != null) ? CS$<>8__locals13.$I2 : (CS$<>8__locals13.$I2 = [SpecialName] (ReferencePoint s) => string.Equals(s.ObjectID, CS$<>8__locals13.$VB$Local_NameOrID, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Name, CS$<>8__locals13.$VB$Local_NameOrID, StringComparison.OrdinalIgnoreCase)));
				if (!Information.IsNothing((object)referencePoint))
				{
					break;
				}
			}
		}
		return referencePoint;
	}

	public static bool UserHasLicenseForThisFeature(Scenario.ScenarioFeatureOption theFeature)
	{
		return true;
	}
}
