using System;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
internal sealed class EnumCommExtensions
{
	public static string GetDescriptionAsSlide(this CommDevice.EnumCommQuality q)
	{
		if (q <= CommDevice.EnumCommQuality.None)
		{
			return "Q:None";
		}
		if (q > CommDevice.EnumCommQuality.GLoc)
		{
			if (q > CommDevice.EnumCommQuality.TacP)
			{
				if (q > CommDevice.EnumCommQuality.AAW)
				{
					if (q > CommDevice.EnumCommQuality.BMD)
					{
						if (q <= CommDevice.EnumCommQuality.FMV)
						{
							return "Q:5";
						}
						int num = (int)q;
						return num.ToString();
					}
					return "Q:4";
				}
				return "Q:3";
			}
			return "Q:2";
		}
		return "Q:1";
	}

	public static string GetCommQualitySlide(int theID)
	{
		return GetDescriptionAsSlide((CommDevice.EnumCommQuality)theID);
	}

	public static string GetDescriptionAsSlide(this CommDevice.EnumCommLatency l)
	{
		if (l > CommDevice.EnumCommLatency.None)
		{
			if (l > CommDevice.EnumCommLatency.Slow)
			{
				if (l > CommDevice.EnumCommLatency.Norm)
				{
					if (l <= CommDevice.EnumCommLatency.Fast)
					{
						return "L:3";
					}
					if (l <= CommDevice.EnumCommLatency.Instnt)
					{
						return "L:4";
					}
					if (l > CommDevice.EnumCommLatency.BMD)
					{
						int num = (int)l;
						return num.ToString();
					}
					return "L:5";
				}
				return "L:2";
			}
			return "L:1";
		}
		return "L:None";
	}

	public static string GetCommLatencySlide(int theID)
	{
		return GetDescriptionAsSlide((CommDevice.EnumCommLatency)theID);
	}

	public static int GetQualityID<EnumCommQuality>(EnumCommQuality enumVal)
	{
		return Convert.ToInt32(enumVal);
	}

	public static int GetLatencyID<EnumCommLatency>(EnumCommLatency enumVal)
	{
		return Convert.ToInt32(enumVal);
	}

	static EnumCommExtensions()
	{
		Class72.smethod_20();
	}
}
