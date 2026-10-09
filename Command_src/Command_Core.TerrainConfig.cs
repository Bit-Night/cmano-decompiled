using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[Serializable]
public class TerrainConfig
{
	public GClass7 DefaultModifier;

	public GClass7[] TerrainModifiers;

	[NonSerialized]
	public Dictionary<LandCover.LandCoverType, GClass7> Modifiers;

	public TerrainConfig()
	{
		Modifiers = new Dictionary<LandCover.LandCoverType, GClass7>();
	}

	public void Initialize()
	{
		try
		{
			GClass7[] terrainModifiers = TerrainModifiers;
			foreach (GClass7 gClass in terrainModifiers)
			{
				Modifiers.Add((LandCover.LandCoverType)Conversions.ToByte(Enum.Parse(typeof(LandCover.LandCoverType), gClass.Name, ignoreCase: true)), gClass);
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		foreach (object value in Enum.GetValues(typeof(LandCover.LandCoverType)))
		{
			LandCover.LandCoverType key = (LandCover.LandCoverType)Conversions.ToByte(value);
			if (!Modifiers.ContainsKey(key))
			{
				Modifiers.Add(key, DefaultModifier);
			}
		}
	}

	static TerrainConfig()
	{
		Class72.smethod_20();
	}
}
