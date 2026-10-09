using System;
using System.IO;

namespace ICSharpCode.SharpZipLib.Zip;

public class ZipEntry
{
	[Flags]
	private enum Enum13 : byte
	{
		None = 0
	}

	private Enum13 enum13_0;

	private int int_0 = -1;

	private ushort ushort_0;

	private string string_0;

	private ulong ulong_0;

	private ulong ulong_1;

	private ushort ushort_1;

	private uint uint_0;

	private DateTime dateTime_0;

	private CompressionMethod compressionMethod_0 = CompressionMethod.Deflated;

	private byte[] byte_0;

	private string string_1;

	private int int_1;

	private long long_0 = -1L;

	private long long_1;

	private bool bool_0;

	private byte byte_1;

	private int int_2;

	private int int_3;

	public bool HasCrc => (enum13_0 & (Enum13)4) != 0;

	public bool IsCrypted
	{
		get
		{
			return this.HasFlag(GeneralBitFlags.Encrypted);
		}
		set
		{
			this.SetFlag(GeneralBitFlags.Encrypted, value);
		}
	}

	public bool IsUnicodeText
	{
		get
		{
			return this.HasFlag(GeneralBitFlags.UnicodeText);
		}
		set
		{
			this.SetFlag(GeneralBitFlags.UnicodeText, value);
		}
	}

	internal byte CryptoCheckValue
	{
		get
		{
			return byte_1;
		}
		set
		{
			byte_1 = value;
		}
	}

	public int Flags
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
		}
	}

	public long ZipFileIndex
	{
		get
		{
			return long_0;
		}
		set
		{
			long_0 = value;
		}
	}

	public long Offset
	{
		get
		{
			return long_1;
		}
		set
		{
			long_1 = value;
		}
	}

	public int ExternalFileAttributes
	{
		get
		{
			if ((enum13_0 & (Enum13)16) == 0)
			{
				return -1;
			}
			return int_0;
		}
		set
		{
			int_0 = value;
			enum13_0 |= (Enum13)16;
		}
	}

	public int VersionMadeBy => ushort_0 & 0xFF;

	public bool IsDOSEntry
	{
		get
		{
			if (HostSystem == 0)
			{
				return true;
			}
			return HostSystem == 10;
		}
	}

	public int HostSystem
	{
		get
		{
			return (ushort_0 >> 8) & 0xFF;
		}
		set
		{
			ushort_0 &= 255;
			ushort_0 |= (ushort)((value & 0xFF) << 8);
		}
	}

	public int Version
	{
		get
		{
			if (ushort_1 != 0)
			{
				return ushort_1 & 0xFF;
			}
			if (AESKeySize <= 0)
			{
				if (CompressionMethod.BZip2 == compressionMethod_0)
				{
					return 46;
				}
				if (!CentralHeaderRequiresZip64)
				{
					int result;
					if (CompressionMethod.Deflated != compressionMethod_0)
					{
						if (IsDirectory)
						{
							result = 20;
						}
						else
						{
							if (!IsCrypted)
							{
								if (!method_0(8))
								{
									return 10;
								}
								return 11;
							}
							result = 20;
						}
					}
					else
					{
						result = 20;
					}
					return result;
				}
				return 45;
			}
			return 51;
		}
	}

	public bool CanDecompress
	{
		get
		{
			if (Version <= 51 && (Version == 10 || Version == 11 || Version == 20 || Version == 45 || Version == 46 || Version == 51))
			{
				return IsCompressionMethodSupported();
			}
			return false;
		}
	}

	public bool LocalHeaderRequiresZip64
	{
		get
		{
			bool result;
			if (!(result = bool_0))
			{
				ulong num = ulong_1;
				if (ushort_1 == 0 && IsCrypted)
				{
					num += (ulong)EncryptionOverheadSize;
				}
				result = (ulong_0 >= 4294967295L || num >= 4294967295L) && (ushort_1 == 0 || ushort_1 >= 45);
			}
			return result;
		}
	}

	public bool CentralHeaderRequiresZip64
	{
		get
		{
			if (!LocalHeaderRequiresZip64)
			{
				return long_1 >= 4294967295L;
			}
			return true;
		}
	}

	public long DosTime
	{
		get
		{
			if ((enum13_0 & (Enum13)8) == 0)
			{
				return 0L;
			}
			uint num = (uint)DateTime.Year;
			uint num2 = (uint)DateTime.Month;
			uint num3 = (uint)DateTime.Day;
			uint num4 = (uint)DateTime.Hour;
			uint num5 = (uint)DateTime.Minute;
			uint num6 = (uint)DateTime.Second;
			if (num >= 1980)
			{
				if (num > 2107)
				{
					num = 2107u;
					num2 = 12u;
					num3 = 31u;
					num4 = 23u;
					num5 = 59u;
					num6 = 59u;
				}
			}
			else
			{
				num = 1980u;
				num2 = 1u;
				num3 = 1u;
				num4 = 0u;
				num5 = 0u;
				num6 = 0u;
			}
			return (((num - 1980) & 0x7F) << 25) | (num2 << 21) | (num3 << 16) | (num4 << 11) | (num5 << 5) | (num6 >> 1);
		}
		set
		{
			uint num = (uint)value;
			uint second = Math.Min(59u, 2 * (num & 0x1F));
			uint minute = Math.Min(59u, (num >> 5) & 0x3F);
			uint hour = Math.Min(23u, (num >> 11) & 0x1F);
			uint month = Math.Max(1u, Math.Min(12u, (uint)((int)(value >> 21) & 0xF)));
			uint year = ((num >> 25) & 0x7F) + 1980;
			int day = Math.Max(1, Math.Min(DateTime.DaysInMonth((int)year, (int)month), (int)((value >> 16) & 0x1FL)));
			DateTime = new DateTime((int)year, (int)month, day, (int)hour, (int)minute, (int)second, DateTimeKind.Unspecified);
		}
	}

	public DateTime DateTime
	{
		get
		{
			return dateTime_0;
		}
		set
		{
			dateTime_0 = value;
			enum13_0 |= (Enum13)8;
		}
	}

	public string Name
	{
		get
		{
			return string_0;
		}
		internal set
		{
			string_0 = value;
		}
	}

	public long Size
	{
		get
		{
			if ((enum13_0 & (Enum13)1) != Enum13.None)
			{
				return (long)ulong_0;
			}
			return -1L;
		}
		set
		{
			ulong_0 = (ulong)value;
			enum13_0 |= (Enum13)1;
		}
	}

	public long CompressedSize
	{
		get
		{
			if ((enum13_0 & (Enum13)2) == 0)
			{
				return -1L;
			}
			return (long)ulong_1;
		}
		set
		{
			ulong_1 = (ulong)value;
			enum13_0 |= (Enum13)2;
		}
	}

	public long Crc
	{
		get
		{
			if ((enum13_0 & (Enum13)4) != Enum13.None)
			{
				return (long)uint_0 & 0xFFFFFFFFL;
			}
			return -1L;
		}
		set
		{
			uint_0 = (uint)value;
			enum13_0 |= (Enum13)4;
		}
	}

	public CompressionMethod CompressionMethod
	{
		get
		{
			return compressionMethod_0;
		}
		set
		{
			compressionMethod_0 = value;
		}
	}

	internal CompressionMethod CompressionMethodForHeader
	{
		get
		{
			if (AESKeySize > 0)
			{
				return CompressionMethod.const_6;
			}
			return compressionMethod_0;
		}
	}

	public byte[] ExtraData
	{
		get
		{
			return byte_0;
		}
		set
		{
			if (value != null)
			{
				if (value.Length > 65535)
				{
					throw new ArgumentOutOfRangeException("value");
				}
				byte_0 = new byte[value.Length];
				Array.Copy(value, 0, byte_0, 0, value.Length);
			}
			else
			{
				byte_0 = null;
			}
		}
	}

	public int AESKeySize
	{
		get
		{
			return int_3 switch
			{
				0 => 0, 
				1 => 128, 
				2 => 192, 
				3 => 256, 
				_ => throw new ZipException("Invalid AESEncryptionStrength " + int_3), 
			};
		}
		set
		{
			switch (value)
			{
			default:
				throw new ZipException("AESKeySize must be 0, 128 or 256: " + value);
			case 256:
				int_3 = 3;
				break;
			case 128:
				int_3 = 1;
				break;
			case 0:
				int_3 = 0;
				break;
			}
		}
	}

	internal byte AESEncryptionStrength => (byte)int_3;

	internal int AESSaltLen => AESKeySize / 16;

	internal int AESOverheadSize => 12 + AESSaltLen;

	internal int EncryptionOverheadSize
	{
		get
		{
			if (!IsCrypted)
			{
				return 0;
			}
			if (int_3 == 0)
			{
				return 12;
			}
			return AESOverheadSize;
		}
	}

	public string Comment
	{
		get
		{
			return string_1;
		}
		set
		{
			if (value != null && value.Length > 65535)
			{
				throw new ArgumentOutOfRangeException("value", "cannot exceed 65535");
			}
			string_1 = value;
		}
	}

	public bool IsDirectory
	{
		get
		{
			if (string_0.Length > 0 && (string_0[string_0.Length - 1] == '/' || string_0[string_0.Length - 1] == '\\'))
			{
				return true;
			}
			return method_0(16);
		}
	}

	public bool IsFile
	{
		get
		{
			if (!IsDirectory)
			{
				return !method_0(8);
			}
			return false;
		}
	}

	public ZipEntry(string name)
		: this(name, 0, 51, CompressionMethod.Deflated, unicode: true)
	{
	}

	internal ZipEntry(string name, int versionRequiredToExtract)
		: this(name, versionRequiredToExtract, 51, CompressionMethod.Deflated, unicode: true)
	{
	}

	internal ZipEntry(string name, int versionRequiredToExtract, int madeByInfo, CompressionMethod method, bool unicode)
	{
		if (name == null)
		{
			throw new ArgumentNullException("name");
		}
		if (name.Length > 65535)
		{
			throw new ArgumentException("Name is too long", "name");
		}
		if (versionRequiredToExtract != 0 && versionRequiredToExtract < 10)
		{
			throw new ArgumentOutOfRangeException("versionRequiredToExtract");
		}
		DateTime = DateTime.Now;
		string_0 = name;
		ushort_0 = (ushort)madeByInfo;
		ushort_1 = (ushort)versionRequiredToExtract;
		compressionMethod_0 = method;
		IsUnicodeText = unicode;
	}

	[Obsolete("Use Clone instead")]
	public ZipEntry(ZipEntry entry)
	{
		if (entry != null)
		{
			enum13_0 = entry.enum13_0;
			string_0 = entry.string_0;
			ulong_0 = entry.ulong_0;
			ulong_1 = entry.ulong_1;
			uint_0 = entry.uint_0;
			dateTime_0 = entry.DateTime;
			compressionMethod_0 = entry.compressionMethod_0;
			string_1 = entry.string_1;
			ushort_1 = entry.ushort_1;
			ushort_0 = entry.ushort_0;
			int_0 = entry.int_0;
			int_1 = entry.int_1;
			long_0 = entry.long_0;
			long_1 = entry.long_1;
			bool_0 = entry.bool_0;
			if (entry.byte_0 != null)
			{
				byte_0 = new byte[entry.byte_0.Length];
				Array.Copy(entry.byte_0, 0, byte_0, 0, entry.byte_0.Length);
			}
			return;
		}
		throw new ArgumentNullException("entry");
	}

	private bool method_0(int int_4)
	{
		bool flag = false;
		if ((enum13_0 & (Enum13)16) != Enum13.None)
		{
			flag |= (HostSystem == 0 || HostSystem == 10) && (ExternalFileAttributes & int_4) == int_4;
		}
		return flag;
	}

	public void method_1()
	{
		bool_0 = true;
	}

	public bool IsZip64Forced()
	{
		return bool_0;
	}

	internal void ProcessExtraData(bool localHeader)
	{
		ZipExtraData zipExtraData = new ZipExtraData(byte_0);
		if (zipExtraData.Find(1))
		{
			bool_0 = true;
			if (zipExtraData.ValueLength < 4)
			{
				throw new ZipException("Extra data extended Zip64 information length is invalid");
			}
			if (ulong_0 == 4294967295L)
			{
				ulong_0 = (ulong)zipExtraData.ReadLong();
			}
			if (ulong_1 == 4294967295L)
			{
				ulong_1 = (ulong)zipExtraData.ReadLong();
			}
			if (!localHeader && long_1 == 4294967295L)
			{
				long_1 = zipExtraData.ReadLong();
			}
		}
		else if ((ushort_1 & 0xFF) >= 45 && (ulong_0 == 4294967295L || ulong_1 == 4294967295L))
		{
			throw new ZipException("Zip64 Extended information required but is missing.");
		}
		DateTime = smethod_0(zipExtraData) ?? DateTime;
		if (compressionMethod_0 == CompressionMethod.const_6)
		{
			method_2(zipExtraData);
		}
	}

	private static DateTime? smethod_0(ZipExtraData zipExtraData_0)
	{
		ExtendedUnixData data = zipExtraData_0.GetData<ExtendedUnixData>();
		if (data != null && data.Include.HasFlag(ExtendedUnixData.Flags.ModificationTime))
		{
			return data.ModificationTime;
		}
		return null;
	}

	private void method_2(ZipExtraData zipExtraData_0)
	{
		if (!zipExtraData_0.Find(39169))
		{
			throw new ZipException("AES Extra Data missing");
		}
		ushort_1 = 51;
		int valueLength = zipExtraData_0.ValueLength;
		if (valueLength < 7)
		{
			throw new ZipException("AES Extra Data Length " + valueLength + " invalid.");
		}
		int num = zipExtraData_0.ReadShort();
		zipExtraData_0.ReadShort();
		int num2 = zipExtraData_0.ReadByte();
		int num3 = zipExtraData_0.ReadShort();
		int_2 = num;
		int_3 = num2;
		compressionMethod_0 = (CompressionMethod)num3;
	}

	public bool IsCompressionMethodSupported()
	{
		return IsCompressionMethodSupported(CompressionMethod);
	}

	public object Clone()
	{
		ZipEntry zipEntry = (ZipEntry)MemberwiseClone();
		if (byte_0 != null)
		{
			zipEntry.byte_0 = new byte[byte_0.Length];
			Array.Copy(byte_0, 0, zipEntry.byte_0, 0, byte_0.Length);
		}
		return zipEntry;
	}

	public override string ToString()
	{
		return string_0;
	}

	public static bool IsCompressionMethodSupported(CompressionMethod method)
	{
		int result;
		switch (method)
		{
		default:
			return method == CompressionMethod.BZip2;
		case CompressionMethod.Stored:
			result = 1;
			break;
		case CompressionMethod.Deflated:
			result = 1;
			break;
		}
		return (byte)result != 0;
	}

	public static string CleanName(string name)
	{
		if (name == null)
		{
			return string.Empty;
		}
		if (Path.IsPathRooted(name))
		{
			name = name.Substring(Path.GetPathRoot(name).Length);
		}
		name = name.Replace("\\", "/");
		while (name.Length > 0 && name[0] == '/')
		{
			name = name.Remove(0, 1);
		}
		return name;
	}

	static ZipEntry()
	{
		Class72.smethod_20();
	}
}
