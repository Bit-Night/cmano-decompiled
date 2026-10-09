using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace SRTM;

public sealed class EmptySRTMDataCell : ISRTMDataCell
{
	[CompilerGenerated]
	private int int_0;

	[CompilerGenerated]
	private int int_1;

	public int Latitude
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
		[CompilerGenerated]
		private set
		{
			int_0 = value;
		}
	}

	public int Longitude
	{
		[CompilerGenerated]
		get
		{
			return int_1;
		}
		[CompilerGenerated]
		private set
		{
			int_1 = value;
		}
	}

	public EmptySRTMDataCell(string filepath)
	{
		if (FileExistsNative.FileExistsFast(filepath))
		{
			string fileName = Path.GetFileName(filepath);
			fileName = fileName.Substring(0, fileName.IndexOf('.')).ToLower();
			string[] array = fileName.Split('e', 'w');
			if (array.Length != 2)
			{
				throw new ArgumentException("Invalid filename.", filepath);
			}
			array[0] = array[0].TrimStart('n', 's');
			Latitude = int.Parse(array[0]);
			if (fileName.Contains("s"))
			{
				Latitude *= -1;
			}
			Longitude = int.Parse(array[1]);
			if (fileName.Contains("w"))
			{
				Longitude *= -1;
			}
			return;
		}
		throw new FileNotFoundException("File not found.", filepath);
	}

	public int? GetElevation(double latitude, double longitude)
	{
		return null;
	}

	public double? GetElevationBilinear(double latitude, double longitude)
	{
		return null;
	}

	public bool WriteBytesToFile(FileStream fs)
	{
		return false;
	}

	static EmptySRTMDataCell()
	{
		Class72.smethod_20();
	}
}
