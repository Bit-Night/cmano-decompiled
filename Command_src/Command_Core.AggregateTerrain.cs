using System;
using System.Collections.Generic;
using System.Linq;

namespace Command_Core;

public class AggregateTerrain
{
	public float Slope;

	public Dictionary<LandCover.LandCoverType, float> TerrainProportion;

	public List<(LandCover.LandCoverType, float)> Samples;

	public GClass7 TerrainModifier;

	public AggregateTerrain()
	{
		TerrainProportion = new Dictionary<LandCover.LandCoverType, float>();
		Samples = new List<(LandCover.LandCoverType, float)>();
		TerrainModifier = new GClass7();
	}

	public void SampleTerrain(double Latitude, double Longitude, double Radius, short Resolution, Scenario Scen)
	{
		TerrainProportion.Clear();
		Samples.Clear();
		Slope = 0f;
		float num = 360f / (float)Resolution;
		float num2 = 1f / (float)(Resolution + 1);
		TerrainProportion.Add(LandCover.GetLandCoverAtThisPoint(Latitude, Longitude, Scen), num2);
		double out_lon = default(double);
		double out_lat = default(double);
		for (int i = 1; i <= Resolution; i++)
		{
			Geodesic_EdWilliams.CalcPoint_Williams(Longitude, Latitude, ref out_lon, ref out_lat, Radius * 0.5, num * (float)i);
			LandCover.LandCoverType landCoverAtThisPoint = LandCover.GetLandCoverAtThisPoint(out_lat, out_lon, Scen);
			if (TerrainProportion.ContainsKey(landCoverAtThisPoint))
			{
				TerrainProportion[landCoverAtThisPoint] += num2;
			}
			else
			{
				TerrainProportion.Add(landCoverAtThisPoint, num2);
			}
			Slope += Terrain.GetMaxSlope(out_lat, out_lon, RequestIsFromGUI: false, Scen) * num2;
			Samples.Add((landCoverAtThisPoint, Slope));
		}
		ComputeModifiers();
	}

	public void ComputeModifiers()
	{
		TerrainModifier.Reset();
		if (TerrainProportion.Count == 0)
		{
			return;
		}
		float num = 0.4f / (float)TerrainProportion.Count;
		foreach (KeyValuePair<LandCover.LandCoverType, float> item in TerrainProportion)
		{
			GClass7 gClass = AGU_CONFIG.Instance.TerrainModifiers.Modifiers[item.Key];
			TerrainModifier.Agility_Personel += gClass.Agility_Personel * item.Value * (1f - Slope * 0.4f);
			TerrainModifier.Agility_Vehicle += gClass.Agility_Vehicle * item.Value * (1f - Slope * 0.9f);
			TerrainModifier.Cover_Personel += gClass.Cover_Personel * item.Value * (0.5f + Slope * 0.5f);
			TerrainModifier.Cover_Vehicle += gClass.Cover_Vehicle * item.Value * (0.5f + Slope * 0.5f);
			if (item.Key != LandCover.LandCoverType.Water)
			{
				TerrainModifier.Speed_Personel += gClass.Speed_Personel * item.Value * (1f - Slope * 0.5f);
				TerrainModifier.Speed_Vehicle += gClass.Speed_Vehicle * item.Value * (1f - Slope * 0.9f);
			}
			else
			{
				TerrainModifier.Speed_Personel -= num * item.Value;
				TerrainModifier.Cover_Vehicle -= num * item.Value;
			}
			TerrainModifier.Firepower_Personel += gClass.Firepower_Personel * item.Value;
			TerrainModifier.Firepower_Vehicle += gClass.Firepower_Vehicle * item.Value;
		}
		if (TerrainProportion.ElementAt(0).Key != LandCover.LandCoverType.Water)
		{
			if (TerrainModifier.Speed_Personel <= 0f)
			{
				TerrainModifier.Speed_Personel = 0.1f;
			}
			else
			{
				TerrainModifier.Speed_Personel = Math.Max(TerrainModifier.Speed_Personel, 0f);
			}
			if (TerrainModifier.Speed_Vehicle <= 0f)
			{
				TerrainModifier.Speed_Vehicle = 0.1f;
			}
			else
			{
				TerrainModifier.Speed_Vehicle = Math.Max(TerrainModifier.Speed_Vehicle, 0f);
			}
		}
		else
		{
			TerrainModifier.Speed_Personel = 0f;
			TerrainModifier.Speed_Vehicle = 0f;
		}
	}

	static AggregateTerrain()
	{
		Class72.smethod_20();
	}
}
