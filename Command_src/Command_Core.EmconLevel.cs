using System;
using System.Drawing;

namespace Command_Core;

public sealed class EmconLevel
{
	private Alertlevels alertlevels_0;

	public Alertlevels Level
	{
		get
		{
			return alertlevels_0;
		}
		set
		{
			alertlevels_0 = value;
		}
	}

	public static Alertlevels GetAlertEnumWithString(string str)
	{
		str = str.ToLower();
		return str switch
		{
			"yellow" => Alertlevels.Yellow, 
			"orange" => Alertlevels.Orange, 
			"custom" => Alertlevels.Custom, 
			"red" => Alertlevels.Red, 
			"blue" => Alertlevels.Blue, 
			"green" => Alertlevels.Green, 
			_ => Alertlevels.Green, 
		};
	}

	public static Color GetAlertColor(Alertlevels _AlertLevel, bool DarkenedColor = false)
	{
		Color result = default(Color);
		switch (_AlertLevel)
		{
		case Alertlevels.Green:
			result = Color.FromArgb(0, 255, 0);
			break;
		case Alertlevels.Blue:
			result = Color.FromArgb(0, 0, 255);
			break;
		case Alertlevels.Yellow:
			result = Color.FromArgb(255, 255, 0);
			break;
		case Alertlevels.Orange:
			result = Color.FromArgb(255, 125, 0);
			break;
		case Alertlevels.Red:
			result = Color.FromArgb(255, 0, 0);
			break;
		case Alertlevels.Custom:
			result = Color.FromArgb(50, 50, 50);
			break;
		}
		if (DarkenedColor)
		{
			result = Color.FromArgb((int)Math.Round((double)(int)result.R / 4.0), (int)Math.Round((double)(int)result.G / 4.0), (int)Math.Round((double)(int)result.B / 4.0));
		}
		return result;
	}

	static EmconLevel()
	{
		Class72.smethod_20();
	}
}
