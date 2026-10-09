using System;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class MapProfile
{
	public delegate void GodsEyeStatusChangedEventHandler(MapProfile theProfile);

	public struct _RangeSymbol_Colors
	{
		public Color AASensor;

		public Color AAWeapon;

		public Color ASSensor;

		public Color ASWeapon;

		public Color AGWeapon;

		public Color color_0;

		public Color color_1;

		public Color ACRange;

		public Color CommsRangeColor;
	}

	public enum _ShowElement : short
	{
		All,
		SelectedUnit,
		DontShow
	}

	public enum _ShowDataBlocksTypes : short
	{
		TrackNumberAndClass,
		TrackingAndKinematic,
		Everything
	}

	public enum _ShowEmissionTypes : short
	{
		All,
		FireControlOnly,
		All_SelectedUnitOnly
	}

	public enum MapViewMode : byte
	{
		GroupView,
		UnitView
	}

	private bool bool_0;

	private bool bool_1;

	private bool bool_2;

	private bool bool_3;

	private bool bool_4;

	private bool bool_5;

	private bool bool_6;

	private bool bool_7;

	private bool bool_8;

	private bool bool_9;

	private bool bool_10;

	private bool bool_11;

	private bool bool_12;

	private bool bool_13;

	private bool bool_14;

	private bool bool_15;

	private bool bool_16;

	private _ShowElement _ShowElement_0;

	private _ShowEmissionTypes _ShowEmissionTypes_0;

	public _RangeSymbol_Colors RangeSymbol_Colors;

	private _ShowElement _ShowElement_1;

	private _ShowElement _ShowElement_2;

	private _ShowElement _ShowElement_3;

	private _ShowDataBlocksTypes _ShowDataBlocksTypes_0;

	private _ShowElement _ShowElement_4;

	private _ShowElement _ShowElement_5;

	public MapViewMode ViewMode;

	private bool bool_17;

	private string string_0;

	private bool bool_18;

	private Color color_0;

	private Color color_1;

	private bool bool_19;

	private Color color_2;

	private bool bool_20;

	private Color color_3;

	internal string SelectedVectorMapStyle;

	[CompilerGenerated]
	private static GodsEyeStatusChangedEventHandler godsEyeStatusChangedEventHandler_0;

	[ThreadStatic]
	private static StringBuilder stringBuilder_0;

	private _ShowElement _ShowElement_6;

	private _ShowElement _ShowElement_7;

	private _ShowElement _ShowElement_8;

	private _ShowElement _ShowElement_9;

	private _ShowElement _ShowElement_10;

	private _ShowElement _ShowElement_11;

	private _ShowElement _ShowElement_12;

	private _ShowElement _ShowElement_13;

	private _ShowElement _ShowElement_14;

	public bool GodsEye
	{
		get
		{
			return bool_17;
		}
		set
		{
			bool num = bool_17 != value;
			bool_17 = value;
			if (num)
			{
				godsEyeStatusChangedEventHandler_0?.Invoke(this);
			}
		}
	}

	public bool ShowDynamicNoiseSignature
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
		}
	}

	public bool ShowLatLonGrid
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public bool ShowBaseEarth
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	public bool Layer_Sentinel2
	{
		get
		{
			return bool_3;
		}
		set
		{
			bool_3 = value;
		}
	}

	public bool Layer_VirtualEarth
	{
		get
		{
			return bool_13;
		}
		set
		{
			bool_13 = value;
		}
	}

	public bool Layer_BMNG
	{
		get
		{
			return bool_4;
		}
		set
		{
			bool_4 = value;
		}
	}

	public bool Layer_Relief
	{
		get
		{
			return bool_5;
		}
		set
		{
			bool_5 = value;
		}
	}

	public bool Layer_StamenTerrain
	{
		get
		{
			return bool_6;
		}
		set
		{
			bool_6 = value;
		}
	}

	public bool Layer_StamenRoads
	{
		get
		{
			return bool_7;
		}
		set
		{
			bool_7 = value;
		}
	}

	public bool Layer_Borders
	{
		get
		{
			return bool_8;
		}
		set
		{
			bool_8 = value;
		}
	}

	public bool Layer_Placenames
	{
		get
		{
			return bool_9;
		}
		set
		{
			bool_9 = value;
		}
	}

	public bool Layer_LandCover
	{
		get
		{
			return bool_10;
		}
		set
		{
			bool_10 = value;
		}
	}

	public bool Layer_OpenTopoMap
	{
		get
		{
			return bool_11;
		}
		set
		{
			bool_11 = value;
		}
	}

	public bool Layer_OSMVector
	{
		get
		{
			return bool_12;
		}
		set
		{
			bool_12 = value;
		}
	}

	public bool DayNightLighting
	{
		get
		{
			return bool_14;
		}
		set
		{
			bool_14 = value;
		}
	}

	public bool MergeRangeSymbols
	{
		get
		{
			return bool_15;
		}
		set
		{
			bool_15 = value;
		}
	}

	public bool ShowNonFriendly
	{
		get
		{
			return bool_16;
		}
		set
		{
			bool_16 = value;
		}
	}

	public bool ColorDatablocks
	{
		get
		{
			return bool_18;
		}
		set
		{
			bool_18 = value;
		}
	}

	public _ShowElement RangeSymbol_AASensor
	{
		get
		{
			return _ShowElement_6;
		}
		set
		{
			if (value == (_ShowElement)255)
			{
				value = _ShowElement.DontShow;
			}
			if (value == (_ShowElement)3)
			{
				value = _ShowElement.All;
			}
			_ShowElement_6 = value;
		}
	}

	public _ShowElement RangeSymbol_AAWeapon
	{
		get
		{
			return _ShowElement_7;
		}
		set
		{
			if (value == (_ShowElement)255)
			{
				value = _ShowElement.DontShow;
			}
			if (value == (_ShowElement)3)
			{
				value = _ShowElement.All;
			}
			_ShowElement_7 = value;
		}
	}

	public _ShowElement RangeSymbol_ASSensor
	{
		get
		{
			return _ShowElement_8;
		}
		set
		{
			if (value == (_ShowElement)255)
			{
				value = _ShowElement.DontShow;
			}
			if (value == (_ShowElement)3)
			{
				value = _ShowElement.All;
			}
			_ShowElement_8 = value;
		}
	}

	public _ShowElement RangeSymbol_ASWeapon
	{
		get
		{
			return _ShowElement_9;
		}
		set
		{
			if (value == (_ShowElement)255)
			{
				value = _ShowElement.DontShow;
			}
			if (value == (_ShowElement)3)
			{
				value = _ShowElement.All;
			}
			_ShowElement_9 = value;
		}
	}

	public _ShowElement RangeSymbol_AGWeapon
	{
		get
		{
			return _ShowElement_10;
		}
		set
		{
			if (value == (_ShowElement)255)
			{
				value = _ShowElement.DontShow;
			}
			if (value == (_ShowElement)3)
			{
				value = _ShowElement.All;
			}
			_ShowElement_10 = value;
		}
	}

	public _ShowElement RangeSymbol_ASWSensor
	{
		get
		{
			return _ShowElement_11;
		}
		set
		{
			if (value == (_ShowElement)255)
			{
				value = _ShowElement.DontShow;
			}
			if (value == (_ShowElement)3)
			{
				value = _ShowElement.All;
			}
			_ShowElement_11 = value;
		}
	}

	public _ShowElement RangeSymbol_ASWWeapon
	{
		get
		{
			return _ShowElement_12;
		}
		set
		{
			if (value == (_ShowElement)255)
			{
				value = _ShowElement.DontShow;
			}
			if (value == (_ShowElement)3)
			{
				value = _ShowElement.All;
			}
			_ShowElement_12 = value;
		}
	}

	public _ShowElement RangeSymbol_ACRange
	{
		get
		{
			return _ShowElement_13;
		}
		set
		{
			if (value == (_ShowElement)255)
			{
				value = _ShowElement.DontShow;
			}
			if (value == (_ShowElement)3)
			{
				value = _ShowElement.All;
			}
			_ShowElement_13 = value;
		}
	}

	public _ShowElement RangeSymbol_COMMS
	{
		get
		{
			return _ShowElement_14;
		}
		set
		{
			if (value == (_ShowElement)255)
			{
				value = _ShowElement.DontShow;
			}
			if (value == (_ShowElement)3)
			{
				value = _ShowElement.All;
			}
			_ShowElement_14 = value;
		}
	}

	public Color RPColor
	{
		get
		{
			return color_0;
		}
		set
		{
			color_0 = value;
		}
	}

	public Color WPColor
	{
		get
		{
			return color_1;
		}
		set
		{
			color_1 = value;
		}
	}

	public Color BorderColor
	{
		get
		{
			return color_2;
		}
		set
		{
			color_2 = value;
			BorderColorChanged = true;
		}
	}

	public bool BorderColorChanged
	{
		get
		{
			return bool_19;
		}
		set
		{
			bool_19 = value;
		}
	}

	public Color SeaIceColor
	{
		get
		{
			return color_3;
		}
		set
		{
			color_3 = value;
			SeaIceColorChanged = true;
		}
	}

	public bool SeaIceColorChanged
	{
		get
		{
			return bool_20;
		}
		set
		{
			bool_20 = value;
		}
	}

	public _ShowElement ShowDatalinks
	{
		get
		{
			return _ShowElement_2;
		}
		set
		{
			if (value == (_ShowElement)255)
			{
				value = _ShowElement.DontShow;
			}
			if (value == (_ShowElement)3)
			{
				value = _ShowElement.All;
			}
			_ShowElement_2 = value;
		}
	}

	public _ShowElement ShowDatablocks
	{
		get
		{
			return _ShowElement_3;
		}
		set
		{
			if (value == (_ShowElement)3)
			{
				value = _ShowElement.All;
			}
			_ShowElement_3 = value;
		}
	}

	public _ShowElement ShowTargetingVectors
	{
		get
		{
			return _ShowElement_1;
		}
		set
		{
			if (value == (_ShowElement)3)
			{
				value = _ShowElement.All;
			}
			_ShowElement_1 = value;
		}
	}

	public _ShowElement ShowIlluminationVectors
	{
		get
		{
			return _ShowElement_4;
		}
		set
		{
			if (value == (_ShowElement)3)
			{
				value = _ShowElement.All;
			}
			_ShowElement_4 = value;
		}
	}

	public _ShowElement ShowContactEmissions
	{
		get
		{
			return _ShowElement_0;
		}
		set
		{
			_ShowElement_0 = value;
		}
	}

	public _ShowEmissionTypes ShowContactEmissions_Details
	{
		get
		{
			return _ShowEmissionTypes_0;
		}
		set
		{
			_ShowEmissionTypes_0 = value;
		}
	}

	public _ShowElement ShowRangeSymbols
	{
		get
		{
			return _ShowElement_5;
		}
		set
		{
			_ShowElement_5 = value;
		}
	}

	public string IsolatedPOVObjectID
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public _ShowDataBlocksTypes ShowDataBlockType
	{
		get
		{
			if (_ShowDataBlocksTypes_0 == (_ShowDataBlocksTypes)3)
			{
				_ShowDataBlocksTypes_0 = _ShowDataBlocksTypes.TrackNumberAndClass;
			}
			return _ShowDataBlocksTypes_0;
		}
		set
		{
			if (value == (_ShowDataBlocksTypes)3)
			{
				value = _ShowDataBlocksTypes.TrackNumberAndClass;
			}
			_ShowDataBlocksTypes_0 = value;
		}
	}

	public static event GodsEyeStatusChangedEventHandler GodsEyeStatusChanged
	{
		[CompilerGenerated]
		add
		{
			GodsEyeStatusChangedEventHandler godsEyeStatusChangedEventHandler = godsEyeStatusChangedEventHandler_0;
			GodsEyeStatusChangedEventHandler godsEyeStatusChangedEventHandler2;
			do
			{
				godsEyeStatusChangedEventHandler2 = godsEyeStatusChangedEventHandler;
				GodsEyeStatusChangedEventHandler value2 = (GodsEyeStatusChangedEventHandler)Delegate.Combine(godsEyeStatusChangedEventHandler2, value);
				godsEyeStatusChangedEventHandler = Interlocked.CompareExchange(ref godsEyeStatusChangedEventHandler_0, value2, godsEyeStatusChangedEventHandler2);
			}
			while ((object)godsEyeStatusChangedEventHandler != godsEyeStatusChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			GodsEyeStatusChangedEventHandler godsEyeStatusChangedEventHandler = godsEyeStatusChangedEventHandler_0;
			GodsEyeStatusChangedEventHandler godsEyeStatusChangedEventHandler2;
			do
			{
				godsEyeStatusChangedEventHandler2 = godsEyeStatusChangedEventHandler;
				GodsEyeStatusChangedEventHandler value2 = (GodsEyeStatusChangedEventHandler)Delegate.Remove(godsEyeStatusChangedEventHandler2, value);
				godsEyeStatusChangedEventHandler = Interlocked.CompareExchange(ref godsEyeStatusChangedEventHandler_0, value2, godsEyeStatusChangedEventHandler2);
			}
			while ((object)godsEyeStatusChangedEventHandler != godsEyeStatusChangedEventHandler2);
		}
	}

	public string ToXML()
	{
		string result = default(string);
		try
		{
			if (stringBuilder_0 == null)
			{
				stringBuilder_0 = new StringBuilder();
			}
			else
			{
				stringBuilder_0.Clear();
			}
			stringBuilder_0.Append("<MapProfile>");
			stringBuilder_0.Append("<ShowLatLonGrid>").Append(bool_0.ToString()).Append("</ShowLatLonGrid>");
			stringBuilder_0.Append("<ShowBaseEarth>").Append(bool_1.ToString()).Append("</ShowBaseEarth>");
			stringBuilder_0.Append("<ShowDynamicNoiseSignature>").Append(bool_2.ToString()).Append("</ShowDynamicNoiseSignature>");
			stringBuilder_0.Append("<Layer_Sentinel2>").Append(bool_3.ToString()).Append("</Layer_Sentinel2>");
			stringBuilder_0.Append("<Layer_BMNG>").Append(bool_4.ToString()).Append("</Layer_BMNG>");
			stringBuilder_0.Append("<Layer_Relief>").Append(bool_5.ToString()).Append("</Layer_Relief>");
			stringBuilder_0.Append("<Layer_StamenTerrain>").Append(bool_6.ToString()).Append("</Layer_StamenTerrain>");
			stringBuilder_0.Append("<Layer_StamenRoads>").Append(bool_7.ToString()).Append("</Layer_StamenRoads>");
			stringBuilder_0.Append("<Layer_Borders>").Append(bool_8.ToString()).Append("</Layer_Borders>");
			stringBuilder_0.Append("<Layer_Placenames>").Append(bool_9.ToString()).Append("</Layer_Placenames>");
			stringBuilder_0.Append("<Layer_LandCover>").Append(bool_10.ToString()).Append("</Layer_LandCover>");
			stringBuilder_0.Append("<Layer_VirtualEarth>").Append(bool_13.ToString()).Append("</Layer_VirtualEarth>");
			stringBuilder_0.Append("<Layer_OpenTopoMap>").Append(bool_11.ToString()).Append("</Layer_OpenTopoMap>");
			stringBuilder_0.Append("<Layer_OSMVector>").Append(bool_12.ToString()).Append("</Layer_OSMVector>");
			stringBuilder_0.Append("<DayNightLighting>").Append(bool_14.ToString()).Append("</DayNightLighting>");
			stringBuilder_0.Append("<RSVisible_AASensor>").Append(((short)RangeSymbol_AASensor).ToString()).Append("</RSVisible_AASensor>");
			stringBuilder_0.Append("<RSVisible_ASSensor>").Append(((short)RangeSymbol_ASSensor).ToString()).Append("</RSVisible_ASSensor>");
			stringBuilder_0.Append("<RSVisible_ASWSensor>").Append(((short)RangeSymbol_ASWSensor).ToString()).Append("</RSVisible_ASWSensor>");
			stringBuilder_0.Append("<RSVisible_AAWeapon>").Append(((short)RangeSymbol_AAWeapon).ToString()).Append("</RSVisible_AAWeapon>");
			stringBuilder_0.Append("<RSVisible_ASWeapon>").Append(((short)RangeSymbol_ASWeapon).ToString()).Append("</RSVisible_ASWeapon>");
			stringBuilder_0.Append("<RSVisible_AGWeapon>").Append(((short)RangeSymbol_AGWeapon).ToString()).Append("</RSVisible_AGWeapon>");
			stringBuilder_0.Append("<RSVisible_ASWWeapon>").Append(((short)RangeSymbol_ASWWeapon).ToString()).Append("</RSVisible_ASWWeapon>");
			stringBuilder_0.Append("<RSVisible_ACRange>").Append(((short)RangeSymbol_ACRange).ToString()).Append("</RSVisible_ACRange>");
			stringBuilder_0.Append("<RSVisible_COMMS>").Append(((short)RangeSymbol_COMMS).ToString()).Append("</RSVisible_COMMS>");
			stringBuilder_0.Append("<ShowRangeSymbols>").Append(((byte)_ShowElement_5).ToString()).Append("</ShowRangeSymbols>");
			if (MergeRangeSymbols)
			{
				stringBuilder_0.Append("<MergeRangeSymbols>True</MergeRangeSymbols>");
			}
			if (ShowNonFriendly)
			{
				stringBuilder_0.Append("<ShowNonFriendly>True</ShowNonFriendly>");
			}
			if (ColorDatablocks)
			{
				stringBuilder_0.Append("<ColorDatablocks>True</ColorDatablocks>");
			}
			stringBuilder_0.Append("<ShowTargetingVectors>").Append(((byte)ShowTargetingVectors).ToString()).Append("</ShowTargetingVectors>");
			stringBuilder_0.Append("<ShowDatalinks>").Append(((byte)ShowDatalinks).ToString()).Append("</ShowDatalinks>");
			stringBuilder_0.Append("<ShowDatablocks>").Append(((byte)ShowDatablocks).ToString()).Append("</ShowDatablocks>");
			stringBuilder_0.Append("<ShowDataBlocks_Details>").Append(((byte)ShowDataBlockType).ToString()).Append("</ShowDataBlocks_Details>");
			stringBuilder_0.Append("<ShowIlluminationVectors>").Append(((byte)ShowIlluminationVectors).ToString()).Append("</ShowIlluminationVectors>");
			stringBuilder_0.Append("<ShowContactEmissions>").Append(((byte)ShowContactEmissions).ToString()).Append("</ShowContactEmissions>");
			stringBuilder_0.Append("<ShowContactEmissions_Details>").Append(((byte)ShowContactEmissions_Details).ToString()).Append("</ShowContactEmissions_Details>");
			StringBuilder stringBuilder = stringBuilder_0.Append("<ViewMode>");
			byte viewMode = (byte)ViewMode;
			stringBuilder.Append(viewMode.ToString()).Append("</ViewMode>");
			if (GodsEye)
			{
				stringBuilder_0.Append("<GodsEye>True</GodsEye>");
			}
			if (!string.IsNullOrEmpty(string_0))
			{
				stringBuilder_0.Append("<IsolatedPOVObjectID>").Append(string_0).Append("</IsolatedPOVObjectID>");
			}
			stringBuilder_0.Append("<RPColor>").Append(XmlConvert.ToString(color_0.ToArgb())).Append("</RPColor>");
			stringBuilder_0.Append("<WPColor>").Append(XmlConvert.ToString(color_1.ToArgb())).Append("</WPColor>");
			stringBuilder_0.Append("<LandBorderColor>").Append(XmlConvert.ToString(color_2.ToArgb())).Append("</LandBorderColor>");
			stringBuilder_0.Append("<IceBorderColor>").Append(XmlConvert.ToString(color_3.ToArgb())).Append("</IceBorderColor>");
			if (!string.IsNullOrEmpty(SelectedVectorMapStyle))
			{
				stringBuilder_0.Append("<SelectedVectorMapStyle>").Append(SelectedVectorMapStyle).Append("</SelectedVectorMapStyle>");
			}
			stringBuilder_0.Append("</MapProfile>");
			result = stringBuilder_0.ToString();
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101013", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static MapProfile FromXML(XmlNode theNode)
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		MapProfile result = default(MapProfile);
		try
		{
			MapProfile mapProfile = new MapProfile();
			mapProfile.bool_2 = true;
			bool flag = false;
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "Layer_Placenames":
					mapProfile.bool_9 = Misc.ParseBool(val.InnerText);
					break;
				case "RSVisible_AGWeapon":
				{
					string innerText8 = val.InnerText;
					if (Operators.CompareString(innerText8, "True", false) != 0)
					{
						if (Operators.CompareString(innerText8, "False", false) != 0)
						{
							mapProfile.RangeSymbol_AGWeapon = (_ShowElement)Conversions.ToShort(val.InnerText);
						}
						else
						{
							mapProfile.RangeSymbol_AGWeapon = _ShowElement.DontShow;
						}
					}
					else
					{
						mapProfile.RangeSymbol_AGWeapon = _ShowElement.All;
					}
					break;
				}
				case "ShowContactEmissions_Details":
					mapProfile._ShowEmissionTypes_0 = (_ShowEmissionTypes)Conversions.ToShort(val.InnerText);
					break;
				case "Layer_Relief":
					mapProfile.bool_5 = Misc.ParseBool(val.InnerText);
					break;
				case "RSVisible_ACRange":
				{
					string innerText3 = val.InnerText;
					if (Operators.CompareString(innerText3, "True", false) == 0)
					{
						mapProfile.RangeSymbol_ACRange = _ShowElement.All;
					}
					else if (Operators.CompareString(innerText3, "False", false) != 0)
					{
						mapProfile.RangeSymbol_ACRange = (_ShowElement)Conversions.ToShort(val.InnerText);
					}
					else
					{
						mapProfile.RangeSymbol_ACRange = _ShowElement.DontShow;
					}
					break;
				}
				case "Layer_OpenTopoMap":
					mapProfile.bool_11 = Misc.ParseBool(val.InnerText);
					break;
				case "Layer_VirtualEarth":
					mapProfile.bool_13 = Misc.ParseBool(val.InnerText);
					break;
				case "ShowDatablocks":
					mapProfile._ShowElement_3 = (_ShowElement)Conversions.ToShort(val.InnerText);
					break;
				case "RSVisible_AASensor":
				{
					string innerText6 = val.InnerText;
					if (Operators.CompareString(innerText6, "True", false) == 0)
					{
						mapProfile.RangeSymbol_AASensor = _ShowElement.All;
					}
					else if (Operators.CompareString(innerText6, "False", false) != 0)
					{
						mapProfile.RangeSymbol_AASensor = (_ShowElement)Conversions.ToShort(val.InnerText);
					}
					else
					{
						mapProfile.RangeSymbol_AASensor = _ShowElement.DontShow;
					}
					break;
				}
				case "MergeRangeSymbols":
					mapProfile.MergeRangeSymbols = Misc.ParseBool(val.InnerText);
					break;
				case "Layer_Borders":
					mapProfile.bool_8 = Misc.ParseBool(val.InnerText);
					break;
				case "IceBorderColor":
					mapProfile.method_0("SeaIceColor", Color.FromArgb(XmlConvert.ToInt32(val.InnerText)));
					break;
				case "ShowBaseEarth":
					mapProfile.bool_1 = Misc.ParseBool(val.InnerText);
					break;
				case "ShowContactEmissions":
					mapProfile._ShowElement_0 = (_ShowElement)Conversions.ToShort(val.InnerText);
					break;
				case "ColorDatablocks":
					mapProfile.ColorDatablocks = Misc.ParseBool(val.InnerText);
					break;
				case "RSVisible_AAWeapon":
				{
					string innerText2 = val.InnerText;
					if (Operators.CompareString(innerText2, "True", false) != 0)
					{
						if (Operators.CompareString(innerText2, "False", false) == 0)
						{
							mapProfile.RangeSymbol_AAWeapon = _ShowElement.DontShow;
						}
						else
						{
							mapProfile.RangeSymbol_AAWeapon = (_ShowElement)Conversions.ToShort(val.InnerText);
						}
					}
					else
					{
						mapProfile.RangeSymbol_AAWeapon = _ShowElement.All;
					}
					break;
				}
				case "ShowDatalinks":
					mapProfile._ShowElement_2 = (_ShowElement)Conversions.ToShort(val.InnerText);
					break;
				case "ShowDataBlocks_Details":
					mapProfile.ShowDataBlockType = (_ShowDataBlocksTypes)Conversions.ToShort(val.InnerText);
					break;
				case "ShowRangeSymbols":
					mapProfile._ShowElement_5 = (_ShowElement)Conversions.ToShort(val.InnerText);
					break;
				case "Layer_StamenRoads":
					mapProfile.bool_7 = Misc.ParseBool(val.InnerText);
					break;
				case "ShowDinamicNoiseSignature":
				case "ShowDynamicNoiseSignature":
					mapProfile.bool_2 = Misc.ParseBool(val.InnerText);
					break;
				case "Layer_StamenTerrain":
					mapProfile.bool_6 = Misc.ParseBool(val.InnerText);
					break;
				case "RSVisible_ASWSensor":
				{
					string innerText7 = val.InnerText;
					if (Operators.CompareString(innerText7, "True", false) == 0)
					{
						mapProfile.RangeSymbol_ASWSensor = _ShowElement.All;
					}
					else if (Operators.CompareString(innerText7, "False", false) != 0)
					{
						mapProfile.RangeSymbol_ASWSensor = (_ShowElement)Conversions.ToShort(val.InnerText);
					}
					else
					{
						mapProfile.RangeSymbol_ASWSensor = _ShowElement.DontShow;
					}
					break;
				}
				case "ShowIlluminationVectors":
					mapProfile._ShowElement_4 = (_ShowElement)Conversions.ToShort(val.InnerText);
					break;
				case "IsolatedPOVObjectID":
					mapProfile.string_0 = val.InnerText;
					break;
				case "ShowTargetingVectors":
					mapProfile._ShowElement_1 = (_ShowElement)Conversions.ToShort(val.InnerText);
					break;
				case "WPColor":
					mapProfile.method_0("WPColor", Color.FromArgb(XmlConvert.ToInt32(val.InnerText)));
					break;
				case "Layer_BMNG":
					mapProfile.bool_4 = Misc.ParseBool(val.InnerText);
					break;
				case "SelectedVectorMapStyle":
					mapProfile.SelectedVectorMapStyle = val.InnerText;
					break;
				case "LandBorderColor":
					mapProfile.method_0("BorderColor", Color.FromArgb(XmlConvert.ToInt32(val.InnerText)));
					break;
				case "RSVisible_ASWeapon":
				{
					string innerText5 = val.InnerText;
					if (Operators.CompareString(innerText5, "True", false) != 0)
					{
						if (Operators.CompareString(innerText5, "False", false) != 0)
						{
							mapProfile.RangeSymbol_ASWeapon = (_ShowElement)Conversions.ToShort(val.InnerText);
						}
						else
						{
							mapProfile.RangeSymbol_ASWeapon = _ShowElement.DontShow;
						}
					}
					else
					{
						mapProfile.RangeSymbol_ASWeapon = _ShowElement.All;
					}
					break;
				}
				case "RSVisible_ASWWeapon":
				{
					string innerText4 = val.InnerText;
					if (Operators.CompareString(innerText4, "True", false) == 0)
					{
						mapProfile.RangeSymbol_ASWWeapon = _ShowElement.All;
					}
					else if (Operators.CompareString(innerText4, "False", false) == 0)
					{
						mapProfile.RangeSymbol_ASWWeapon = _ShowElement.DontShow;
					}
					else
					{
						mapProfile.RangeSymbol_ASWWeapon = (_ShowElement)Conversions.ToShort(val.InnerText);
					}
					break;
				}
				case "ShowNonFriendly":
					mapProfile.ShowNonFriendly = Misc.ParseBool(val.InnerText);
					break;
				case "GodsEye":
					mapProfile.bool_17 = Misc.ParseBool(val.InnerText);
					break;
				case "Layer_Sentinel2":
					mapProfile.bool_3 = Misc.ParseBool(val.InnerText);
					break;
				case "ShowLatLonGrid":
					mapProfile.bool_0 = Misc.ParseBool(val.InnerText);
					break;
				case "RPColor":
					mapProfile.method_0("RPColor", Color.FromArgb(XmlConvert.ToInt32(val.InnerText)));
					break;
				case "RSVisible_COMMS":
					flag = true;
					switch (val.InnerText)
					{
					default:
						mapProfile.RangeSymbol_COMMS = (_ShowElement)Conversions.ToShort(val.InnerText);
						break;
					case "False":
					case "0":
						mapProfile.RangeSymbol_COMMS = _ShowElement.DontShow;
						break;
					case "True":
					case "1":
						mapProfile.RangeSymbol_COMMS = _ShowElement.All;
						break;
					}
					break;
				case "DayNightLighting":
					mapProfile.bool_14 = Misc.ParseBool(val.InnerText);
					break;
				case "Layer_OSMVector":
					mapProfile.bool_12 = Misc.ParseBool(val.InnerText);
					break;
				case "Layer_LandCover":
					mapProfile.bool_10 = Misc.ParseBool(val.InnerText);
					break;
				case "ViewMode":
					mapProfile.ViewMode = (MapViewMode)Conversions.ToByte(val.InnerText);
					break;
				case "RSVisible_ASSensor":
				{
					string innerText = val.InnerText;
					if (Operators.CompareString(innerText, "True", false) != 0)
					{
						if (Operators.CompareString(innerText, "False", false) == 0)
						{
							mapProfile.RangeSymbol_ASSensor = _ShowElement.DontShow;
						}
						else
						{
							mapProfile.RangeSymbol_ASSensor = (_ShowElement)Conversions.ToShort(val.InnerText);
						}
					}
					else
					{
						mapProfile.RangeSymbol_ASSensor = _ShowElement.All;
					}
					break;
				}
				}
			}
			if (!flag)
			{
				mapProfile.RangeSymbol_COMMS = _ShowElement.DontShow;
			}
			result = mapProfile;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101014", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private void method_0(string string_1, Color color_4)
	{
		if (color_4 == default(Color) || Operators.CompareString(color_4.Name, "0", false) == 0)
		{
			color_4 = Color.White;
		}
		PropertyInfo property = GetType().GetProperty(string_1);
		if ((object)property != null && property.CanWrite)
		{
			property.SetValue(this, color_4, null);
		}
	}

	public static MapProfile FromXML(string theString)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		XmlDocument val = new XmlDocument();
		val.LoadXml(theString);
		return FromXML((XmlNode)(object)val.DocumentElement);
	}

	public static MapProfile GetDefaultProfile()
	{
		return new MapProfile();
	}

	private MapProfile()
	{
		RangeSymbol_Colors = default(_RangeSymbol_Colors);
		_ShowElement_1 = default(_ShowElement);
		_ShowElement_2 = default(_ShowElement);
		_ShowElement_3 = default(_ShowElement);
		_ShowDataBlocksTypes_0 = default(_ShowDataBlocksTypes);
		ViewMode = default(MapViewMode);
		color_2 = Color.FromArgb(255, 255, 255, 0);
		color_3 = Color.FromArgb(255, 255, 255, 0);
		RangeSymbol_Colors.AASensor = Color.White;
		RangeSymbol_AASensor = _ShowElement.All;
		RangeSymbol_Colors.AAWeapon = Color.FromArgb(255, 105, 105);
		RangeSymbol_AAWeapon = _ShowElement.All;
		RangeSymbol_Colors.ASSensor = Color.Yellow;
		RangeSymbol_ASSensor = _ShowElement.All;
		RangeSymbol_Colors.ASWeapon = Color.Red;
		RangeSymbol_ASWeapon = _ShowElement.All;
		RangeSymbol_Colors.AGWeapon = Color.Chocolate;
		RangeSymbol_AGWeapon = _ShowElement.All;
		RangeSymbol_Colors.color_0 = Color.FromArgb(123, 199, 123);
		RangeSymbol_ASWSensor = _ShowElement.All;
		RangeSymbol_Colors.color_1 = Color.Green;
		RangeSymbol_ASWWeapon = _ShowElement.All;
		RangeSymbol_Colors.ACRange = Color.DodgerBlue;
		RangeSymbol_Colors.CommsRangeColor = Color.Fuchsia;
		RangeSymbol_ACRange = _ShowElement.SelectedUnit;
		_ShowElement_3 = _ShowElement.SelectedUnit;
		_ShowDataBlocksTypes_0 = _ShowDataBlocksTypes.Everything;
		_ShowElement_2 = _ShowElement.DontShow;
		_ShowElement_4 = _ShowElement.All;
		_ShowElement_1 = _ShowElement.DontShow;
		_ShowElement_0 = _ShowElement.All;
		_ShowEmissionTypes_0 = _ShowEmissionTypes.All;
		bool_3 = false;
		bool_4 = true;
		bool_5 = false;
		bool_8 = true;
		bool_11 = false;
		bool_12 = false;
		bool_9 = true;
		bool_1 = true;
		bool_14 = false;
		bool_0 = false;
		bool_2 = true;
		bool_15 = true;
		bool_16 = true;
		ViewMode = MapViewMode.GroupView;
	}

	static MapProfile()
	{
		Class72.smethod_20();
	}
}
