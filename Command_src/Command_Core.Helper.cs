using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class Helper
{
	internal static Color Color_Friendly;

	internal static Color Color_Unknown;

	internal static Color Color_Neutral;

	internal static Color Color_Unfriendly;

	internal static Color Color_Hostile;

	internal static Color Color_LOSShade;

	internal static Color Color_RPShade;

	internal static Color Color_PC_WPShade;

	internal static Color ColorFromStance
	{
		get
		{
			Color color = default(Color);
			return theStance switch
			{
				Misc.PostureStance.Neutral => Color_Neutral, 
				Misc.PostureStance.Friendly => Color_Friendly, 
				Misc.PostureStance.Unfriendly => Color_Unfriendly, 
				Misc.PostureStance.Hostile => Color_Hostile, 
				Misc.PostureStance.Unknown => Color_Unknown, 
				_ => color, 
			};
		}
	}

	static Helper()
	{
		Class72.smethod_20();
		Color_Friendly = Color.FromArgb(255, 82, 255, 255);
		Color_Unknown = Color.Yellow;
		Color_Neutral = Color.LightGreen;
		Color_Unfriendly = Color.Orange;
		Color_Hostile = Color.Red;
		Color_LOSShade = Color.FromArgb(75, Color.DodgerBlue);
		Color_RPShade = Color.FromArgb(255, Color.White);
		Color_PC_WPShade = Color.FromArgb(255, Color.White);
	}

	public static string PickRandomElement(Dictionary<string, int> elements)
	{
		int num = elements.Values.Sum();
		int num2 = new Random().Next(1, num + 1);
		int num3 = 0;
		foreach (KeyValuePair<string, int> element in elements)
		{
			num3 += element.Value;
			if (num2 <= num3)
			{
				return element.Key;
			}
		}
		return null;
	}

	public static int GetLikelyIncreaseInteger(float value, int Seed = -1)
	{
		float eval = value;
		if (value >= 1f)
		{
			eval = value % (float)(int)Math.Round(value);
		}
		if (!RollDice(eval, Seed))
		{
			return (int)Math.Round(value);
		}
		return (int)Math.Round(value) + 1;
	}

	public static bool RollDice(float Eval, int Seed = -1)
	{
		return new Random((Seed == -1) ? Environment.TickCount : Seed).NextDouble() < (double)Eval;
	}
}
