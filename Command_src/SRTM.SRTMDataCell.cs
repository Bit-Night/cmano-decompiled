using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Runtime.CompilerServices;
using SevenZip;

namespace SRTM;

public sealed class SRTMDataCell : ISRTMDataCell
{
	public string filename;

	private byte[] byte_0;

	public int PointsPerCell;

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

	public SRTMDataCell(string filepath)
	{
		if (!FileExistsNative.FileExistsFast(filepath))
		{
			throw new FileNotFoundException("File not found.", filepath);
		}
		filename = Path.GetFileName(filepath);
		filename = filename.Substring(0, filename.IndexOf('.')).ToLower();
		string[] array = filename.Split('e', 'w');
		if (array.Length != 2)
		{
			throw new ArgumentException("Invalid filename.", filepath);
		}
		array[0] = array[0].TrimStart('n', 's');
		Latitude = int.Parse(array[0]);
		if (filename.Contains("s"))
		{
			Latitude *= -1;
		}
		Longitude = int.Parse(array[1]);
		if (filename.Contains("w"))
		{
			Longitude *= -1;
		}
		if (filepath.EndsWith(".7z"))
		{
			using SevenZipExtractor sevenZipExtractor = new SevenZipExtractor(filepath);
			using MemoryStream memoryStream = RCMS.recyclableMemoryStreamManager_0.GetStream();
			sevenZipExtractor.ExtractFile(0, memoryStream);
			byte_0 = memoryStream.ToArray();
		}
		else if (filepath.EndsWith(".zip"))
		{
			try
			{
				byte_0 = ReadZipFileContents(filepath);
			}
			catch (OutOfMemoryException)
			{
				GC.Collect();
				byte_0 = ReadZipFileContents(filepath);
			}
			catch (Exception)
			{
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
		else
		{
			using FileStream fileStream = File.Open(filepath, FileMode.Open, FileAccess.Read, FileShare.Read);
			long length = new FileInfo(filepath).Length;
			byte[] array2 = new byte[length];
			int num = (int)length;
			int num2 = 0;
			while (num > 0)
			{
				int num3 = fileStream.Read(array2, num2, num);
				if (num3 == 0)
				{
					break;
				}
				num2 += num3;
				num -= num3;
			}
			num = array2.Length;
			byte_0 = array2;
		}
		switch (byte_0.Length)
		{
		default:
			throw new ArgumentException("Invalid file size.", filepath);
		case 25934402:
			PointsPerCell = 3601;
			break;
		case 2884802:
			PointsPerCell = 1201;
			break;
		}
	}

	public static byte[] ReadZipFileContents(string zipFilePath)
	{
		using ZipArchive zipArchive = ZipFile.OpenRead(zipFilePath);
		ZipArchiveEntry zipArchiveEntry = zipArchive.Entries[0];
		if (zipArchiveEntry != null)
		{
			using (Stream stream = zipArchiveEntry.Open())
			{
				using MemoryStream memoryStream = RCMS.recyclableMemoryStreamManager_0.GetStream();
				stream.CopyTo(memoryStream);
				return memoryStream.ToArray();
			}
		}
		throw new FileNotFoundException("No file found in the ZIP archive.");
	}

	public SRTMDataCell(string archivePath, string theFile)
	{
		if (FileExistsNative.FileExistsFast(archivePath))
		{
			string text = theFile;
			text = text.Substring(0, text.IndexOf('.')).ToLower();
			string[] array = text.Split('e', 'w');
			if (array.Length != 2)
			{
				throw new ArgumentException("Invalid filename.", theFile);
			}
			array[0] = array[0].TrimStart('n', 's');
			Latitude = int.Parse(array[0]);
			if (text.Contains("s"))
			{
				Latitude *= -1;
			}
			Longitude = int.Parse(array[1]);
			if (text.Contains("w"))
			{
				Longitude *= -1;
			}
			if (!archivePath.EndsWith(".7z"))
			{
				throw new ArgumentException("Unsupported archive format.", archivePath);
			}
			using (SevenZipExtractor sevenZipExtractor = new SevenZipExtractor(archivePath))
			{
				using MemoryStream memoryStream = RCMS.recyclableMemoryStreamManager_0.GetStream();
				sevenZipExtractor.ExtractFile(theFile, memoryStream);
				byte_0 = memoryStream.ToArray();
			}
			switch (byte_0.Length)
			{
			default:
				throw new ArgumentException("Invalid file size.", theFile);
			case 25934402:
				PointsPerCell = 3601;
				break;
			case 2884802:
				PointsPerCell = 1201;
				break;
			}
			return;
		}
		throw new FileNotFoundException("Archive not found.", archivePath);
	}

	public int? GetElevation(double latitude, double longitude)
	{
		int num = (int)((latitude - (double)Latitude) * (double)PointsPerCell);
		int num2 = (int)((longitude - (double)Longitude) * (double)PointsPerCell);
		if (num == PointsPerCell)
		{
			num = PointsPerCell - 1;
		}
		if (num2 == PointsPerCell)
		{
			num2 = PointsPerCell - 1;
		}
		int? result = ReadByteData(num, num2);
		if (!result.HasValue)
		{
			int num3 = 0;
			while (true)
			{
				if (num3 < 10)
				{
					result = CheckAdjacentCells(num3, num, num2);
					if (result.HasValue)
					{
						break;
					}
					num3++;
					continue;
				}
				return null;
			}
			return result;
		}
		return result;
	}

	public int? CheckAdjacentCells(int Distance, int LocalLat, int LocalLon)
	{
		int num = -Distance;
		int? result;
		while (true)
		{
			int num2;
			if (num < Distance * 2 + 1)
			{
				num2 = LocalLat + num;
				if (num2 >= 0)
				{
					result = ReadByteData(num2, LocalLon, AllowOutOfBoundCheck: true);
					if (result.HasValue)
					{
						break;
					}
				}
				num++;
				continue;
			}
			int num3 = LocalLon - Distance;
			if (num3 >= 0)
			{
				for (int i = -Distance; i < Distance * 2 + 1; i++)
				{
					num2 = LocalLat + i;
					if (num2 >= 0)
					{
						result = ReadByteData(num2, num3, AllowOutOfBoundCheck: true);
						if (result.HasValue)
						{
							return result;
						}
					}
				}
			}
			for (int j = -Distance; j < Distance * 2 + 1; j++)
			{
				num3 = LocalLon + j;
				if (num3 >= 0)
				{
					result = ReadByteData(LocalLat, num3, AllowOutOfBoundCheck: true);
					if (result.HasValue)
					{
						return result;
					}
				}
			}
			num2 = LocalLat - Distance;
			if (num2 >= 0)
			{
				for (int k = -Distance; k < Distance * 2 + 1; k++)
				{
					num3 = LocalLon + k;
					if (num3 >= 0)
					{
						result = ReadByteData(num2, num3, AllowOutOfBoundCheck: true);
						if (result.HasValue)
						{
							return result;
						}
					}
				}
			}
			return null;
		}
		return result;
	}

	public double? GetElevationBilinear(double latitude, double longitude)
	{
		double num = (latitude - (double)Latitude) * (double)PointsPerCell;
		double num2 = (longitude - (double)Longitude) * (double)PointsPerCell;
		int localLat = (int)Math.Floor(num);
		int localLon = (int)Math.Floor(num2);
		int num3 = (int)Math.Ceiling(num);
		int num4 = (int)Math.Ceiling(num2);
		int? num5 = ReadByteData(localLat, localLon);
		int? num6 = ReadByteData(num3, localLon);
		int? num7 = ReadByteData(localLat, num4);
		int? num8 = ReadByteData(num3, num4);
		if (num5.HasValue && num6.HasValue && num7.HasValue && num8.HasValue)
		{
			double double_ = (double)num3 - num;
			double double_2 = (double)num4 - num2;
			return method_3(num5.Value, num6.Value, num7.Value, num8.Value, double_, double_2);
		}
		return GetElevation(latitude, longitude).Value;
	}

	public bool WriteBytesToFile(FileStream fs)
	{
		if (fs == null)
		{
			return false;
		}
		fs.Write(byte_0, 0, byte_0.Length);
		return true;
	}

	public int? ReadByteData(int localLat, int localLon, bool AllowOutOfBoundCheck = false)
	{
		int num = (PointsPerCell - localLat - 1) * PointsPerCell * 2 + localLon * 2;
		if (num >= 0 && num <= byte_0.Length)
		{
			if (num < byte_0.Length)
			{
				if (byte_0[num] == 128 && byte_0[num + 1] == 0)
				{
					return null;
				}
				return (byte_0[num] << 8) | byte_0[num + 1];
			}
			return null;
		}
		if (!AllowOutOfBoundCheck)
		{
			throw new ArgumentOutOfRangeException("Coordinates out of range. Byte " + num + " lat " + localLat + "lon " + localLon + " " + filename, "coordinates");
		}
		return null;
	}

	private double method_2(double double_0, double double_1, double double_2)
	{
		return double_0 + (double_1 - double_0) * double_2;
	}

	private double method_3(double double_0, double double_1, double double_2, double double_3, double double_4, double double_5)
	{
		return method_2(method_2(double_3, double_2, double_4), method_2(double_1, double_0, double_4), double_5);
	}

	static SRTMDataCell()
	{
		Class72.smethod_20();
	}
}
