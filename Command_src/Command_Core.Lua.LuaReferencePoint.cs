using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using NLua;

namespace Command_Core.Lua;

[StandardModule]
internal sealed class LuaReferencePoint
{
	[CompilerGenerated]
	internal sealed class _Closure$__2-0
	{
		public string $VB$Local_nameGUID;

		public Func<ReferencePoint, bool> $I1;

		public Func<ReferencePoint, bool> $I2;

		public _Closure$__2-0(_Closure$__2-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_nameGUID = arg0.$VB$Local_nameGUID;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(ReferencePoint s)
		{
			if (string.Equals(s.ObjectID, $VB$Local_nameGUID, StringComparison.OrdinalIgnoreCase))
			{
				return true;
			}
			return string.Equals(s.Name, $VB$Local_nameGUID, StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__1(ReferencePoint s)
		{
			if (!string.Equals(s.ObjectID, $VB$Local_nameGUID, StringComparison.OrdinalIgnoreCase))
			{
				return string.Equals(s.Name, $VB$Local_nameGUID, StringComparison.OrdinalIgnoreCase);
			}
			return true;
		}

		[SpecialName]
		internal bool _Lambda$__2(ReferencePoint s)
		{
			if (!string.Equals(s.ObjectID, $VB$Local_nameGUID, StringComparison.OrdinalIgnoreCase))
			{
				return string.Equals(s.Name, $VB$Local_nameGUID, StringComparison.OrdinalIgnoreCase);
			}
			return true;
		}

		static _Closure$__2-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__3-0
	{
		public string $VB$Local_nameGUID;

		public Func<ReferencePoint, bool> $I1;

		public Func<ReferencePoint, bool> $I2;

		public _Closure$__3-0(_Closure$__3-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_nameGUID = arg0.$VB$Local_nameGUID;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(ReferencePoint s)
		{
			if (!string.Equals(s.ObjectID, $VB$Local_nameGUID, StringComparison.OrdinalIgnoreCase))
			{
				return string.Equals(s.Name, $VB$Local_nameGUID, StringComparison.OrdinalIgnoreCase);
			}
			return true;
		}

		[SpecialName]
		internal bool _Lambda$__1(ReferencePoint s)
		{
			if (!string.Equals(s.ObjectID, $VB$Local_nameGUID, StringComparison.OrdinalIgnoreCase))
			{
				return string.Equals(s.Name, $VB$Local_nameGUID, StringComparison.OrdinalIgnoreCase);
			}
			return true;
		}

		[SpecialName]
		internal bool _Lambda$__2(ReferencePoint s)
		{
			if (string.Equals(s.ObjectID, $VB$Local_nameGUID, StringComparison.OrdinalIgnoreCase))
			{
				return true;
			}
			return string.Equals(s.Name, $VB$Local_nameGUID, StringComparison.OrdinalIgnoreCase);
		}

		static _Closure$__3-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__3-1
	{
		public string $VB$Local_o_name;

		public Func<ReferencePoint, bool> $I4;

		public Func<ReferencePoint, bool> $I5;

		public Func<ReferencePoint, bool> $I7;

		public Func<ReferencePoint, bool> $I8;

		public _Closure$__3-1(_Closure$__3-1 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_o_name = arg0.$VB$Local_o_name;
			}
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
			if (!string.Equals(s.ObjectID, $VB$Local_o_name, StringComparison.OrdinalIgnoreCase))
			{
				return string.Equals(s.Name, $VB$Local_o_name, StringComparison.OrdinalIgnoreCase);
			}
			return true;
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

		[SpecialName]
		internal bool _Lambda$__7(ReferencePoint s)
		{
			if (!string.Equals(s.ObjectID, $VB$Local_o_name, StringComparison.OrdinalIgnoreCase))
			{
				return string.Equals(s.Name, $VB$Local_o_name, StringComparison.OrdinalIgnoreCase);
			}
			return true;
		}

		[SpecialName]
		internal bool _Lambda$__8(ReferencePoint s)
		{
			if (string.Equals(s.ObjectID, $VB$Local_o_name, StringComparison.OrdinalIgnoreCase))
			{
				return true;
			}
			return string.Equals(s.Name, $VB$Local_o_name, StringComparison.OrdinalIgnoreCase);
		}

		static _Closure$__3-1()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__3-2
	{
		public ReferencePoint $VB$Local_theRP;

		public _Closure$__3-2(_Closure$__3-2 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theRP = arg0.$VB$Local_theRP;
			}
		}

		[SpecialName]
		internal bool _Lambda$__9(Side s)
		{
			return s.RefPoints.Contains($VB$Local_theRP);
		}

		static _Closure$__3-2()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__4-0
	{
		public string $VB$Local_nameGUID;

		public Func<ReferencePoint, bool> $I1;

		public Func<ReferencePoint, bool> $I2;

		public _Closure$__4-0(_Closure$__4-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_nameGUID = arg0.$VB$Local_nameGUID;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(ReferencePoint s)
		{
			if (!string.Equals(s.ObjectID, $VB$Local_nameGUID, StringComparison.OrdinalIgnoreCase))
			{
				return string.Equals(s.Name, $VB$Local_nameGUID, StringComparison.OrdinalIgnoreCase);
			}
			return true;
		}

		[SpecialName]
		internal bool _Lambda$__1(ReferencePoint s)
		{
			if (string.Equals(s.ObjectID, $VB$Local_nameGUID, StringComparison.OrdinalIgnoreCase))
			{
				return true;
			}
			return string.Equals(s.Name, $VB$Local_nameGUID, StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__2(ReferencePoint s)
		{
			if (!string.Equals(s.ObjectID, $VB$Local_nameGUID, StringComparison.OrdinalIgnoreCase))
			{
				return string.Equals(s.Name, $VB$Local_nameGUID, StringComparison.OrdinalIgnoreCase);
			}
			return true;
		}

		static _Closure$__4-0()
		{
			Class72.smethod_20();
		}
	}

	public static LuaWrapper_ReferencePoint ScenEdit_AddReferencePoint(LuaTable table, Scenario ScenarioContext)
	{
		LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
		ScenarioObject theRelativeObject = null;
		Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(table.GetEnumerator());
		ReferencePoint referencePoint = null;
		Side side = LuaUtility.QuerySideOrFail(dictionary, ScenarioContext);
		if (dictionary.ContainsKey("RELATIVETO"))
		{
			string text = Conversions.ToString(dictionary["RELATIVETO"]);
			theRelativeObject = PrivateMethods.ValidateAUBySide(text, side) ?? throw new LuaError("Missing unit " + text + " from relative bearing");
		}
		else if (dictionary.ContainsKey("RELATIVETO_CONTACT"))
		{
			string text2 = Conversions.ToString(dictionary["RELATIVETO_CONTACT"]);
			theRelativeObject = PrivateMethods.ValidateContactBySide(text2, 0, side) ?? throw new LuaError("Missing contact " + text2 + " from relative bearing");
		}
		else if (dictionary.ContainsKey("RELATIVETO_RP"))
		{
			string text3 = Conversions.ToString(dictionary["RELATIVETO_RP"]);
			theRelativeObject = PrivateMethods.ValidateRPBySide(text3, side) ?? throw new LuaError("Missing RP " + text3 + " from relative bearing");
		}
		if (!dictionary.ContainsKey("AREA"))
		{
			ReferencePoint thisRP = null;
			referencePoint = ParseReferencePoint(dictionary, null, ScenarioContext, ref thisRP, theRelativeObject);
			if (Information.IsNothing((object)referencePoint))
			{
				throw new LuaError("Can't create RP");
			}
			side.RefPoints.Add(referencePoint);
			string objectID = referencePoint.ObjectID;
			dictionary["GUID"] = objectID;
		}
		else
		{
			List<object> list = LuaUtility.ToArray(((LuaTable)dictionary["AREA"]).GetEnumerator());
			foreach (LuaTable item in list)
			{
				LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
				Dictionary<string, object> dictionary2 = LuaUtility.ToDictUpper(item.GetEnumerator());
				ReferencePoint thisRP = null;
				referencePoint = ParseReferencePoint(dictionary2, dictionary, ScenarioContext, ref thisRP, theRelativeObject);
				if (!Information.IsNothing((object)referencePoint))
				{
					side.RefPoints.Add(referencePoint);
					string objectID2 = referencePoint.ObjectID;
					dictionary2["GUID"] = objectID2;
					LuaUtility.FromDict(dictionary2, luaTable2);
					luaTable[luaTable.Keys.Count.ToString()] = luaTable2;
					continue;
				}
				throw new LuaError("Can't create RP");
			}
			dictionary["AREA"] = luaTable;
		}
		return new LuaWrapper_ReferencePoint(referencePoint, side, ScenarioContext);
	}

	public static LuaWrapper_ReferencePoint ScenEdit_SetReferencePoint(LuaTable table, Scenario ScenarioContext)
	{
		double? num = null;
		double? num2 = null;
		LuaSandBox.Singleton().CreateTable();
		ScenarioObject theRelativeObject = null;
		Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(table.GetEnumerator());
		ReferencePoint thisRP = null;
		Side side = LuaUtility.QuerySideOrFail(dictionary, ScenarioContext);
		if (dictionary.ContainsKey("RELATIVETO"))
		{
			string text = Conversions.ToString(dictionary["RELATIVETO"]);
			theRelativeObject = PrivateMethods.ValidateAUBySide(text, side) ?? throw new LuaError("Missing unit " + text + " from relative bearing");
		}
		else if (dictionary.ContainsKey("RELATIVETO_CONTACT"))
		{
			string text2 = Conversions.ToString(dictionary["RELATIVETO_CONTACT"]);
			theRelativeObject = PrivateMethods.ValidateContactBySide(text2, 0, side) ?? throw new LuaError("Missing contact " + text2 + " from relative bearing");
		}
		else if (dictionary.ContainsKey("RELATIVETO_RP"))
		{
			string text3 = Conversions.ToString(dictionary["RELATIVETO_RP"]);
			theRelativeObject = PrivateMethods.ValidateRPBySide(text3, side) ?? throw new LuaError("Missing RP " + text3 + " from relative bearing");
		}
		List<(ReferencePoint, LuaTable)> list = new List<(ReferencePoint, LuaTable)>();
		string text4 = null;
		if (dictionary.ContainsKey("GUID"))
		{
			text4 = Conversions.ToString(dictionary["GUID"]).ToUpperInvariant();
		}
		else if (dictionary.ContainsKey("NAME"))
		{
			text4 = Conversions.ToString(dictionary["NAME"]).ToUpperInvariant();
		}
		if (string.IsNullOrEmpty(text4) && !dictionary.ContainsKey("AREA"))
		{
			throw new LuaError("Need to define a Side and Name to modify an RP. Or a Side and Guid. Or a set of RPs");
		}
		if (!string.IsNullOrEmpty(text4))
		{
			thisRP = PrivateMethods.ValidateRPBySide(text4, side);
			if (thisRP == null)
			{
				throw new LuaError("RP '" + text4 + "' not found");
			}
			ParseReferencePoint(dictionary, null, ScenarioContext, ref thisRP, theRelativeObject);
		}
		else
		{
			if (!dictionary.ContainsKey("AREA"))
			{
				throw new LuaError("Need to define a Side and Name to modify an RP. Or a Side and Guid. Or a set of RPs");
			}
			List<object> list2 = LuaUtility.ToArray(((LuaTable)dictionary["AREA"]).GetEnumerator());
			foreach (object item in list2)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(item);
				ReferencePoint referencePoint = null;
				if (!(objectValue.GetType() == typeof(LuaTable)))
				{
					text4 = objectValue.ToString().ToUpperInvariant();
					referencePoint = PrivateMethods.ValidateRPBySide(text4, side);
					if (referencePoint != null)
					{
						if (referencePoint != null)
						{
							list.Add((referencePoint, null));
						}
						continue;
					}
					throw new LuaError("Can't find RP");
				}
				Dictionary<string, object> dictionary2 = LuaUtility.ToDictUpper(((LuaTable)objectValue).GetEnumerator());
				if (!dictionary2.ContainsKey("GUID"))
				{
					if (dictionary2.ContainsKey("NAME"))
					{
						text4 = Conversions.ToString(dictionary2["NAME"]).ToUpperInvariant();
					}
				}
				else
				{
					text4 = Conversions.ToString(dictionary2["GUID"]).ToUpperInvariant();
				}
				referencePoint = PrivateMethods.ValidateRPBySide(text4, side);
				if (referencePoint != null)
				{
					if (referencePoint != null)
					{
						list.Add((referencePoint, (LuaTable)objectValue));
					}
					continue;
				}
				throw new LuaError("Can't find RP");
			}
			foreach (var item2 in list)
			{
				(ReferencePoint, LuaTable) current = item2;
				if (current.Item2 != null)
				{
					ParseReferencePoint(LuaUtility.ToDictUpper(current.Item2.GetEnumerator()), dictionary, ScenarioContext, ref current.Item1, theRelativeObject);
				}
				else
				{
					ParseReferencePoint(dictionary, null, ScenarioContext, ref current.Item1, theRelativeObject);
				}
			}
		}
		if (list.Count == 0 && thisRP == null)
		{
			throw new LuaError("Need to define a Side and Name to modify an RP. Or a Side and Guid. Or a set of RPs");
		}
		if (thisRP != null)
		{
			if (dictionary.ContainsKey("NEWNAME"))
			{
				string text5 = Conversions.ToString(dictionary["NEWNAME"]);
				if (Operators.CompareString(thisRP.Name, text5, false) != 0)
				{
					thisRP.Name = text5;
				}
			}
			if (num.HasValue)
			{
				thisRP.Latitude = num.Value;
			}
			if (num2.HasValue)
			{
				thisRP.Longitude = num2.Value;
			}
		}
		if (thisRP == null)
		{
			thisRP = list[0].Item1;
		}
		return new LuaWrapper_ReferencePoint(thisRP, side, ScenarioContext);
	}

	public static LuaWrapper_ReferencePoint ScenEdit_GetReferencePoint(LuaTable table, Scenario ScenarioContext)
	{
		_Closure$__2-0 arg = default(_Closure$__2-0);
		_Closure$__2-0 CS$<>8__locals16 = new _Closure$__2-0(arg);
		Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(table.GetEnumerator());
		ReferencePoint referencePoint = null;
		CS$<>8__locals16.$VB$Local_nameGUID = null;
		Side side = LuaUtility.QuerySideOrFail(dictionary, ScenarioContext);
		if (dictionary.ContainsKey("GUID"))
		{
			CS$<>8__locals16.$VB$Local_nameGUID = Conversions.ToString(dictionary["GUID"]).ToUpperInvariant();
		}
		else if (dictionary.ContainsKey("NAME"))
		{
			CS$<>8__locals16.$VB$Local_nameGUID = Conversions.ToString(dictionary["NAME"]).ToUpperInvariant();
		}
		if (Information.IsNothing((object)CS$<>8__locals16.$VB$Local_nameGUID) && !dictionary.ContainsKey("AREA"))
		{
			throw new LuaError("Need to define a Side and Name to modify an RP. Or a Side and Guid");
		}
		referencePoint = side.RefPoints.FirstOrDefault([SpecialName] (ReferencePoint s) => string.Equals(s.ObjectID, CS$<>8__locals16.$VB$Local_nameGUID, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Name, CS$<>8__locals16.$VB$Local_nameGUID, StringComparison.OrdinalIgnoreCase));
		if (Information.IsNothing((object)referencePoint))
		{
			foreach (NoNavZone noNavZone in side.NoNavZones)
			{
				referencePoint = noNavZone.Area.FirstOrDefault((CS$<>8__locals16.$I1 != null) ? CS$<>8__locals16.$I1 : (CS$<>8__locals16.$I1 = [SpecialName] (ReferencePoint s) => string.Equals(s.ObjectID, CS$<>8__locals16.$VB$Local_nameGUID, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Name, CS$<>8__locals16.$VB$Local_nameGUID, StringComparison.OrdinalIgnoreCase)));
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
				referencePoint = exclusionZone.Area.FirstOrDefault((CS$<>8__locals16.$I2 != null) ? CS$<>8__locals16.$I2 : (CS$<>8__locals16.$I2 = [SpecialName] (ReferencePoint s) => string.Equals(s.ObjectID, CS$<>8__locals16.$VB$Local_nameGUID, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Name, CS$<>8__locals16.$VB$Local_nameGUID, StringComparison.OrdinalIgnoreCase)));
				if (!Information.IsNothing((object)referencePoint))
				{
					break;
				}
			}
		}
		if (referencePoint == null)
		{
			throw new LuaError("RP not found.");
		}
		return new LuaWrapper_ReferencePoint(referencePoint, side, ScenarioContext);
	}

	public static LuaTable ScenEdit_GetReferencePoints(LuaTable table, Scenario ScenarioContext)
	{
		_Closure$__3-0 arg = default(_Closure$__3-0);
		_Closure$__3-0 CS$<>8__locals11 = new _Closure$__3-0(arg);
		Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(table.GetEnumerator());
		ReferencePoint referencePoint = null;
		List<ReferencePoint> list = new List<ReferencePoint>();
		CS$<>8__locals11.$VB$Local_nameGUID = null;
		LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
		Side side = LuaUtility.QuerySideOrFail(dictionary, ScenarioContext);
		if (!dictionary.ContainsKey("GUID"))
		{
			if (dictionary.ContainsKey("NAME"))
			{
				CS$<>8__locals11.$VB$Local_nameGUID = Conversions.ToString(dictionary["NAME"]).ToUpperInvariant();
			}
		}
		else
		{
			CS$<>8__locals11.$VB$Local_nameGUID = Conversions.ToString(dictionary["GUID"]).ToUpperInvariant();
		}
		if (Information.IsNothing((object)CS$<>8__locals11.$VB$Local_nameGUID) && !dictionary.ContainsKey("AREA"))
		{
			throw new LuaError("Need to define a Side and Name to modify an RP. Or a Side and Guid. Or a set of RPs");
		}
		if (Information.IsNothing((object)CS$<>8__locals11.$VB$Local_nameGUID))
		{
			if (!dictionary.ContainsKey("AREA"))
			{
				throw new LuaError("Need to define a Side and Name to modify an RP. Or a Side and Guid. Or a set of RPs");
			}
			List<object> list2 = LuaUtility.ToArray(((LuaTable)dictionary["AREA"]).GetEnumerator());
			_Closure$__3-1 closure$__3- = default(_Closure$__3-1);
			foreach (object item in list2)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(item);
				closure$__3- = new _Closure$__3-1(closure$__3-);
				closure$__3-.$VB$Local_o_name = null;
				ReferencePoint referencePoint2 = null;
				if (objectValue.GetType() == typeof(LuaTable))
				{
					Dictionary<string, object> dictionary2 = LuaUtility.ToDictUpper(((LuaTable)objectValue).GetEnumerator());
					if (!dictionary2.ContainsKey("GUID"))
					{
						if (dictionary.ContainsKey("NAME"))
						{
							closure$__3-.$VB$Local_o_name = Conversions.ToString(dictionary2["NAME"]).ToUpperInvariant();
						}
					}
					else
					{
						closure$__3-.$VB$Local_o_name = Conversions.ToString(dictionary2["GUID"]).ToUpperInvariant();
					}
					referencePoint2 = side.RefPoints.FirstOrDefault(closure$__3-._Lambda$__3);
					if (Information.IsNothing((object)referencePoint2))
					{
						foreach (NoNavZone noNavZone in side.NoNavZones)
						{
							referencePoint2 = noNavZone.Area.FirstOrDefault((closure$__3-.$I4 != null) ? closure$__3-.$I4 : (closure$__3-.$I4 = closure$__3-._Lambda$__4));
							if (!Information.IsNothing((object)referencePoint2))
							{
								break;
							}
						}
					}
					if (Information.IsNothing((object)referencePoint2))
					{
						foreach (ExclusionZone exclusionZone in side.ExclusionZones)
						{
							referencePoint2 = exclusionZone.Area.FirstOrDefault((closure$__3-.$I5 != null) ? closure$__3-.$I5 : (closure$__3-.$I5 = closure$__3-._Lambda$__5));
							if (!Information.IsNothing((object)referencePoint2))
							{
								break;
							}
						}
					}
				}
				else
				{
					closure$__3-.$VB$Local_o_name = objectValue.ToString();
					referencePoint2 = side.RefPoints.FirstOrDefault(closure$__3-._Lambda$__6);
					if (Information.IsNothing((object)referencePoint2))
					{
						foreach (NoNavZone noNavZone2 in side.NoNavZones)
						{
							referencePoint2 = noNavZone2.Area.FirstOrDefault((closure$__3-.$I7 != null) ? closure$__3-.$I7 : (closure$__3-.$I7 = closure$__3-._Lambda$__7));
							if (!Information.IsNothing((object)referencePoint2))
							{
								break;
							}
						}
					}
					if (Information.IsNothing((object)referencePoint2))
					{
						foreach (ExclusionZone exclusionZone2 in side.ExclusionZones)
						{
							referencePoint2 = exclusionZone2.Area.FirstOrDefault((closure$__3-.$I8 != null) ? closure$__3-.$I8 : (closure$__3-.$I8 = closure$__3-._Lambda$__8));
							if (!Information.IsNothing((object)referencePoint2))
							{
								break;
							}
						}
					}
				}
				if (!Information.IsNothing((object)referencePoint2))
				{
					list.Add(referencePoint2);
				}
			}
		}
		else
		{
			referencePoint = side.RefPoints.FirstOrDefault([SpecialName] (ReferencePoint s) => string.Equals(s.ObjectID, CS$<>8__locals11.$VB$Local_nameGUID, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Name, CS$<>8__locals11.$VB$Local_nameGUID, StringComparison.OrdinalIgnoreCase));
			if (Information.IsNothing((object)referencePoint))
			{
				foreach (NoNavZone noNavZone3 in side.NoNavZones)
				{
					referencePoint = noNavZone3.Area.FirstOrDefault([SpecialName] (ReferencePoint s) => string.Equals(s.ObjectID, CS$<>8__locals11.$VB$Local_nameGUID, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Name, CS$<>8__locals11.$VB$Local_nameGUID, StringComparison.OrdinalIgnoreCase));
					if (!Information.IsNothing((object)referencePoint))
					{
						break;
					}
				}
			}
			if (Information.IsNothing((object)referencePoint))
			{
				foreach (ExclusionZone exclusionZone3 in side.ExclusionZones)
				{
					referencePoint = exclusionZone3.Area.FirstOrDefault([SpecialName] (ReferencePoint s) => string.Equals(s.ObjectID, CS$<>8__locals11.$VB$Local_nameGUID, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Name, CS$<>8__locals11.$VB$Local_nameGUID, StringComparison.OrdinalIgnoreCase));
					if (!Information.IsNothing((object)referencePoint))
					{
						break;
					}
				}
			}
		}
		if (list.Count == 0 && referencePoint == null)
		{
			throw new LuaError("Need to define a Side and Name to modify an RP. Or a Side and Guid. Or a set of RPs");
		}
		LuaSandBox.Singleton().CreateTable();
		int num = 1;
		using List<ReferencePoint>.Enumerator enumerator8 = list.GetEnumerator();
		_Closure$__3-2 closure$__3-2 = default(_Closure$__3-2);
		while (enumerator8.MoveNext())
		{
			closure$__3-2 = new _Closure$__3-2(closure$__3-2);
			closure$__3-2.$VB$Local_theRP = enumerator8.Current;
			LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
			luaTable2["name"] = closure$__3-2.$VB$Local_theRP.Name;
			luaTable2["latitude"] = closure$__3-2.$VB$Local_theRP.Latitude.ToString();
			luaTable2["longitude"] = closure$__3-2.$VB$Local_theRP.Longitude.ToString();
			luaTable2["guid"] = closure$__3-2.$VB$Local_theRP.ObjectID.ToString();
			luaTable2["side"] = ScenarioContext.Sides_ReadOnly.First(closure$__3-2._Lambda$__9).Name;
			luaTable2["highlighted"] = closure$__3-2.$VB$Local_theRP.IsHighlighted.ToString();
			luaTable2["visible"] = closure$__3-2.$VB$Local_theRP.IsVisible.ToString();
			luaTable2["locked"] = closure$__3-2.$VB$Local_theRP.IsLocked.ToString();
			if (closure$__3-2.$VB$Local_theRP.IsRelativeTo != null)
			{
				luaTable2["bearingtype"] = closure$__3-2.$VB$Local_theRP.BearingType.ToString();
				luaTable2["relativeto"] = closure$__3-2.$VB$Local_theRP.IsRelativeTo.Name;
			}
			luaTable[num] = luaTable2;
			num++;
		}
		return luaTable;
	}

	public static bool ScenEdit_DeleteReferencePoint(LuaTable table, Scenario ScenarioContext)
	{
		_Closure$__4-0 arg = default(_Closure$__4-0);
		_Closure$__4-0 CS$<>8__locals16 = new _Closure$__4-0(arg);
		Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(table.GetEnumerator());
		Zone zone = null;
		CS$<>8__locals16.$VB$Local_nameGUID = null;
		Side side = LuaUtility.QuerySideOrFail(dictionary, ScenarioContext);
		if (!dictionary.ContainsKey("GUID"))
		{
			if (dictionary.ContainsKey("NAME"))
			{
				CS$<>8__locals16.$VB$Local_nameGUID = Conversions.ToString(dictionary["NAME"]).ToUpperInvariant();
			}
		}
		else
		{
			CS$<>8__locals16.$VB$Local_nameGUID = Conversions.ToString(dictionary["GUID"]).ToUpperInvariant();
		}
		if (Information.IsNothing((object)CS$<>8__locals16.$VB$Local_nameGUID))
		{
			throw new LuaError("Need to define a Side and Name to modify an RP. Or a Side and Guid");
		}
		ReferencePoint referencePoint = side.RefPoints.FirstOrDefault([SpecialName] (ReferencePoint s) => string.Equals(s.ObjectID, CS$<>8__locals16.$VB$Local_nameGUID, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Name, CS$<>8__locals16.$VB$Local_nameGUID, StringComparison.OrdinalIgnoreCase));
		if (Information.IsNothing((object)referencePoint))
		{
			foreach (NoNavZone noNavZone in side.NoNavZones)
			{
				referencePoint = noNavZone.Area.FirstOrDefault((CS$<>8__locals16.$I1 != null) ? CS$<>8__locals16.$I1 : (CS$<>8__locals16.$I1 = [SpecialName] (ReferencePoint s) => string.Equals(s.ObjectID, CS$<>8__locals16.$VB$Local_nameGUID, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Name, CS$<>8__locals16.$VB$Local_nameGUID, StringComparison.OrdinalIgnoreCase)));
				if (!Information.IsNothing((object)referencePoint))
				{
					zone = noNavZone;
					break;
				}
			}
		}
		if (Information.IsNothing((object)referencePoint))
		{
			foreach (ExclusionZone exclusionZone in side.ExclusionZones)
			{
				referencePoint = exclusionZone.Area.FirstOrDefault((CS$<>8__locals16.$I2 != null) ? CS$<>8__locals16.$I2 : (CS$<>8__locals16.$I2 = [SpecialName] (ReferencePoint s) => string.Equals(s.ObjectID, CS$<>8__locals16.$VB$Local_nameGUID, StringComparison.OrdinalIgnoreCase) || string.Equals(s.Name, CS$<>8__locals16.$VB$Local_nameGUID, StringComparison.OrdinalIgnoreCase)));
				if (!Information.IsNothing((object)referencePoint))
				{
					zone = exclusionZone;
					break;
				}
			}
		}
		if (Information.IsNothing((object)referencePoint))
		{
			return false;
		}
		if (!Information.IsNothing((object)zone))
		{
			zone.Area.Remove(referencePoint);
			return true;
		}
		side.RefPoints.Remove(referencePoint);
		return true;
	}

	public static ReferencePoint ParseReferencePoint(Dictionary<string, object> dict, Dictionary<string, object> parentDict, Scenario ScenarioContext, ref ReferencePoint thisRP, object theRelativeObject = null)
	{
		string text = "";
		double? num = null;
		double? num2 = null;
		double? num3 = null;
		double? num4 = null;
		ReferencePoint referencePoint = null;
		Module_Unit.Unit unit = null;
		Contact contact = null;
		ReferencePoint referencePoint2 = null;
		ReferencePoint.OrientationType? orientationType = null;
		text = (dict.ContainsKey("NAME") ? Conversions.ToString(dict["NAME"]) : ("RP-" + Conversions.ToString(Interlocked.Increment(ref ScenarioContext.UnitsAutoIncrement))));
		num = LuaUtility.QueryLatitude(dict);
		num2 = LuaUtility.QueryLongitude(dict);
		if (dict.ContainsKey("RELATIVETO") || dict.ContainsKey("RELATIVETO_CONTACT") || dict.ContainsKey("RELATIVETO_RP") || (parentDict != null && (parentDict.ContainsKey("RELATIVETO") || parentDict.ContainsKey("RELATIVETO_CONTACT") || parentDict.ContainsKey("RELATIVETO_RP"))))
		{
			ReferencePoint.OrientationType result2;
			if (!dict.ContainsKey("BEARINGTYPE"))
			{
				if (!Information.IsNothing((object)parentDict) && parentDict.ContainsKey("BEARINGTYPE") && Enum.TryParse<ReferencePoint.OrientationType>(Conversions.ToString(parentDict["BEARINGTYPE"]), ignoreCase: true, out var result) && Enum.IsDefined(typeof(ReferencePoint.OrientationType), result))
				{
					orientationType = result;
				}
			}
			else if (Enum.TryParse<ReferencePoint.OrientationType>(Conversions.ToString(dict["BEARINGTYPE"]), ignoreCase: true, out result2) && Enum.IsDefined(typeof(ReferencePoint.OrientationType), result2))
			{
				orientationType = result2;
			}
			if (dict.ContainsKey("BEARING") && dict.ContainsKey("DISTANCE"))
			{
				num3 = Conversions.ToDouble(dict["BEARING"]);
				num4 = Conversions.ToDouble(dict["DISTANCE"]);
			}
			else if (!Information.IsNothing((object)parentDict) && parentDict.ContainsKey("BEARING") && parentDict.ContainsKey("DISTANCE"))
			{
				num3 = Conversions.ToDouble(parentDict["BEARING"]);
				num4 = Conversions.ToDouble(parentDict["DISTANCE"]);
			}
		}
		if (num3.HasValue)
		{
			if (theRelativeObject == null)
			{
				throw new LuaError("No unit defined for relative bearing");
			}
			ScenarioObject scenarioObject = (ScenarioObject)theRelativeObject;
			if (!scenarioObject.IsUnit() && !scenarioObject.IsActiveUnit)
			{
				if (!scenarioObject.IsContact())
				{
					if (scenarioObject.IsReferencePoint())
					{
						referencePoint2 = (ReferencePoint)theRelativeObject;
						Geodesic_Vincenty.TCoord Pt = new Geodesic_Vincenty.TCoord(referencePoint2.Latitude, referencePoint2.Longitude);
						Geodesic_Vincenty.TCoord Ret = default(Geodesic_Vincenty.TCoord);
						Geodesic_Vincenty.fw_vincenty_wgs84(ref Pt, ref Ret, num3.Value, num4.Value);
						num = Ret.Lat;
						num2 = Ret.Lon;
					}
				}
				else
				{
					contact = (Contact)theRelativeObject;
					Geodesic_Vincenty.TCoord Pt2 = new Geodesic_Vincenty.TCoord(((Module_Unit.Unit)contact).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)contact).get_Longitude((GlobalVariables.BooleanObject)null));
					Geodesic_Vincenty.TCoord Ret2 = default(Geodesic_Vincenty.TCoord);
					Geodesic_Vincenty.fw_vincenty_wgs84(ref Pt2, ref Ret2, num3.Value, num4.Value);
					num = Ret2.Lat;
					num2 = Ret2.Lon;
				}
			}
			else
			{
				unit = (Module_Unit.Unit)theRelativeObject;
				Geodesic_Vincenty.TCoord Pt3 = new Geodesic_Vincenty.TCoord(unit.get_Latitude((GlobalVariables.BooleanObject)null), unit.get_Longitude((GlobalVariables.BooleanObject)null));
				Geodesic_Vincenty.TCoord Ret3 = default(Geodesic_Vincenty.TCoord);
				Geodesic_Vincenty.fw_vincenty_wgs84(ref Pt3, ref Ret3, num3.Value, num4.Value);
				num = Ret3.Lat;
				num2 = Ret3.Lon;
			}
			if (unit == null && contact == null && referencePoint2 == null)
			{
				throw new LuaError("No unit defined for relative bearing");
			}
		}
		if (thisRP == null)
		{
			if (Information.IsNothing((object)num) || Information.IsNothing((object)num2))
			{
				throw new LuaError("No longitude/latitude setting");
			}
			referencePoint = new ReferencePoint();
			referencePoint.Longitude = num2.Value;
			referencePoint.Latitude = num.Value;
			referencePoint.Name = text;
			referencePoint.color = Color.White;
		}
		else
		{
			referencePoint = thisRP;
		}
		if (dict.ContainsKey("HIGHLIGHTED"))
		{
			bool? flag = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(dict["HIGHLIGHTED"]));
			if (flag.HasValue)
			{
				referencePoint.IsHighlighted = flag.Value;
			}
		}
		else if (!Information.IsNothing((object)parentDict) && parentDict.ContainsKey("HIGHLIGHTED"))
		{
			bool? flag2 = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(parentDict["HIGHLIGHTED"]));
			if (flag2.HasValue)
			{
				referencePoint.IsHighlighted = flag2.Value;
			}
		}
		if (dict.ContainsKey("VISIBLE"))
		{
			bool? flag3 = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(dict["VISIBLE"]));
			if (flag3.HasValue)
			{
				referencePoint.IsVisible = flag3.Value;
			}
		}
		else if (!Information.IsNothing((object)parentDict) && parentDict.ContainsKey("VISIBLE"))
		{
			bool? flag4 = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(parentDict["VISIBLE"]));
			if (flag4.HasValue)
			{
				referencePoint.IsVisible = flag4.Value;
			}
		}
		if (dict.ContainsKey("LOCKED"))
		{
			referencePoint.IsLocked = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(dict["LOCKED"])).Value;
		}
		else if (!Information.IsNothing((object)parentDict) && parentDict.ContainsKey("LOCKED"))
		{
			referencePoint.IsLocked = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(parentDict["LOCKED"])).Value;
		}
		if (dict.ContainsKey("COLOR"))
		{
			Color color = Color.FromName(Conversions.ToString(dict["COLOR"]));
			if (!color.IsKnownColor)
			{
				try
				{
					referencePoint.color = ColorTranslator.FromHtml("#" + Conversions.ToString(dict["COLOR"]));
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
			}
			else
			{
				referencePoint.color = color;
			}
		}
		else if (!Information.IsNothing((object)parentDict) && parentDict.ContainsKey("COLOR"))
		{
			Color color2 = Color.FromName(Conversions.ToString(parentDict["COLOR"]));
			if (color2.IsKnownColor)
			{
				referencePoint.color = color2;
			}
			else
			{
				try
				{
					referencePoint.color = ColorTranslator.FromHtml("#" + Conversions.ToString(parentDict["COLOR"]));
				}
				catch (Exception projectError2)
				{
					ProjectData.SetProjectError(projectError2);
					ProjectData.ClearProjectError();
				}
			}
		}
		if (orientationType.HasValue)
		{
			referencePoint.BearingType = orientationType.Value;
		}
		if (dict.ContainsKey("CLEAR"))
		{
			bool? flag5 = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(dict["CLEAR"]));
			if (flag5.HasValue)
			{
				bool? flag6 = flag5;
				flag6 = flag6;
				if (flag6 == true)
				{
					referencePoint.IsRelativeTo = null;
					referencePoint.BearingType = ReferencePoint.OrientationType.Fixed;
					referencePoint.RelativeBearing = 0f;
					referencePoint.RelativeDistance = 0f;
				}
			}
		}
		else if (!Information.IsNothing((object)parentDict) && parentDict.ContainsKey("CLEAR"))
		{
			bool? flag7 = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(parentDict["CLEAR"]));
			if (flag7.HasValue)
			{
				bool? flag6 = flag7;
				flag6 = flag6;
				if (flag6 == true)
				{
					referencePoint.IsRelativeTo = null;
					referencePoint.BearingType = ReferencePoint.OrientationType.Fixed;
					referencePoint.RelativeBearing = 0f;
					referencePoint.RelativeDistance = 0f;
				}
			}
		}
		else if (num3.HasValue && theRelativeObject != null)
		{
			if (num.HasValue && num2.HasValue)
			{
				referencePoint.Latitude = num.Value;
				referencePoint.Longitude = num2.Value;
				referencePoint.IsRelativeTo = (ScenarioObject)theRelativeObject;
				referencePoint.AdjustForRelativeHooking();
			}
		}
		else if (theRelativeObject != null)
		{
			if (num.HasValue && num2.HasValue)
			{
				referencePoint.Latitude = num.Value;
				referencePoint.Longitude = num2.Value;
				referencePoint.IsRelativeTo = (ScenarioObject)theRelativeObject;
				referencePoint.AdjustForRelativeHooking();
			}
		}
		else
		{
			if (num.HasValue)
			{
				referencePoint.Latitude = num.Value;
			}
			if (num2.HasValue)
			{
				referencePoint.Longitude = num2.Value;
			}
		}
		if (dict.ContainsKey("NEWNAME"))
		{
			string text2 = Conversions.ToString(dict["NEWNAME"]);
			if (Operators.CompareString(referencePoint.Name, text2, false) != 0)
			{
				referencePoint.Name = text2;
			}
		}
		return referencePoint;
	}

	static LuaReferencePoint()
	{
		Class72.smethod_20();
	}
}
