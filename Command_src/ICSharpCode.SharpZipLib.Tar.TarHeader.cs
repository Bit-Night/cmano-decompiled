using System;
using System.Buffers;
using System.Text;
using ICSharpCode.SharpZipLib.Core;

namespace ICSharpCode.SharpZipLib.Tar;

public class TarHeader
{
	public const int NAMELEN = 100;

	public const int MODELEN = 8;

	public const int UIDLEN = 8;

	public const int GIDLEN = 8;

	public const int CHKSUMLEN = 8;

	public const int CHKSUMOFS = 148;

	public const int SIZELEN = 12;

	public const int MAGICLEN = 6;

	public const int VERSIONLEN = 2;

	public const int MODTIMELEN = 12;

	public const int UNAMELEN = 32;

	public const int GNAMELEN = 32;

	public const int DEVLEN = 8;

	public const int PREFIXLEN = 155;

	public const byte LF_OLDNORM = 0;

	public const byte LF_NORMAL = 48;

	public const byte LF_LINK = 49;

	public const byte LF_SYMLINK = 50;

	public const byte LF_CHR = 51;

	public const byte LF_BLK = 52;

	public const byte LF_DIR = 53;

	public const byte LF_FIFO = 54;

	public const byte LF_CONTIG = 55;

	public const byte LF_GHDR = 103;

	public const byte LF_XHDR = 120;

	public const byte LF_ACL = 65;

	public const byte LF_GNU_DUMPDIR = 68;

	public const byte LF_EXTATTR = 69;

	public const byte LF_META = 73;

	public const byte LF_GNU_LONGLINK = 75;

	public const byte LF_GNU_LONGNAME = 76;

	public const byte LF_GNU_MULTIVOL = 77;

	public const byte LF_GNU_NAMES = 78;

	public const byte LF_GNU_SPARSE = 83;

	public const byte LF_GNU_VOLHDR = 86;

	public const string TMAGIC = "ustar";

	public const string GNU_TMAGIC = "ustar  ";

	private static readonly DateTime dateTime_0;

	private string string_0;

	private int int_0;

	private int int_1;

	private int int_2;

	private long long_0;

	private DateTime dateTime_1;

	private int int_3;

	private bool bool_0;

	private byte byte_0;

	private string string_1;

	private string fLyyVfFdxto;

	private string string_2;

	private string string_3;

	private string string_4;

	private int KuxyVnvheDP;

	private int int_4;

	internal static int userIdAsSet;

	internal static int groupIdAsSet;

	internal static string userNameAsSet;

	internal static string groupNameAsSet;

	internal static int defaultUserId;

	internal static int defaultGroupId;

	internal static string defaultGroupName;

	internal static string defaultUser;

	public string Name
	{
		get
		{
			return string_0;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			string_0 = value;
		}
	}

	public int Mode
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	public int UserId
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

	public int GroupId
	{
		get
		{
			return int_2;
		}
		set
		{
			int_2 = value;
		}
	}

	public long Size
	{
		get
		{
			return long_0;
		}
		set
		{
			if (value < 0L)
			{
				throw new ArgumentOutOfRangeException("value", "Cannot be less than zero");
			}
			long_0 = value;
		}
	}

	public DateTime ModTime
	{
		get
		{
			return dateTime_1;
		}
		set
		{
			if (value < dateTime_0)
			{
				throw new ArgumentOutOfRangeException("value", "ModTime cannot be before Jan 1st 1970");
			}
			dateTime_1 = new DateTime(value.Year, value.Month, value.Day, value.Hour, value.Minute, value.Second);
		}
	}

	public int Checksum => int_3;

	public bool IsChecksumValid => bool_0;

	public byte TypeFlag
	{
		get
		{
			return byte_0;
		}
		set
		{
			byte_0 = value;
		}
	}

	public string LinkName
	{
		get
		{
			return string_1;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			string_1 = value;
		}
	}

	public string Magic
	{
		get
		{
			return fLyyVfFdxto;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			fLyyVfFdxto = value;
		}
	}

	public string Version
	{
		get
		{
			return string_2;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			string_2 = value;
		}
	}

	public string UserName
	{
		get
		{
			return string_3;
		}
		set
		{
			if (value == null)
			{
				string text = "user";
				if (text.Length > 32)
				{
					text = text.Substring(0, 32);
				}
				string_3 = text;
			}
			else
			{
				string_3 = value.Substring(0, Math.Min(32, value.Length));
			}
		}
	}

	public string GroupName
	{
		get
		{
			return string_4;
		}
		set
		{
			if (value != null)
			{
				string_4 = value;
			}
			else
			{
				string_4 = "None";
			}
		}
	}

	public int DevMajor
	{
		get
		{
			return KuxyVnvheDP;
		}
		set
		{
			KuxyVnvheDP = value;
		}
	}

	public int DevMinor
	{
		get
		{
			return int_4;
		}
		set
		{
			int_4 = value;
		}
	}

	public TarHeader()
	{
		Magic = "ustar";
		Version = " ";
		Name = "";
		LinkName = "";
		UserId = defaultUserId;
		GroupId = defaultGroupId;
		UserName = defaultUser;
		GroupName = defaultGroupName;
		Size = 0L;
	}

	[Obsolete("Use the Name property instead", true)]
	public string GetName()
	{
		return string_0;
	}

	public object Clone()
	{
		return MemberwiseClone();
	}

	public void ParseBuffer(byte[] header, Encoding nameEncoding)
	{
		if (header != null)
		{
			int num = 0;
			Span<byte> span = MemoryExtensions.AsSpan(header);
			string_0 = ParseName(span.Slice(0, 100), nameEncoding);
			num = 100;
			int_0 = (int)ParseOctal(header, 100, 8);
			num = 108;
			UserId = (int)ParseOctal(header, 108, 8);
			num = 116;
			GroupId = (int)ParseOctal(header, 116, 8);
			num = 124;
			Size = smethod_0(header, 124, 12);
			num = 136;
			ModTime = smethod_6(ParseOctal(header, 136, 12));
			num = 148;
			int_3 = (int)ParseOctal(header, 148, 8);
			num = 156;
			num = 157;
			TypeFlag = header[156];
			LinkName = ParseName(span.Slice(157, 100), nameEncoding);
			num = 257;
			Magic = ParseName(span.Slice(257, 6), nameEncoding);
			num = 263;
			if (Magic == "ustar")
			{
				Version = ParseName(span.Slice(num, 2), nameEncoding);
				num += 2;
				UserName = ParseName(span.Slice(num, 32), nameEncoding);
				num += 32;
				GroupName = ParseName(span.Slice(num, 32), nameEncoding);
				num += 32;
				DevMajor = (int)ParseOctal(header, num, 8);
				num += 8;
				DevMinor = (int)ParseOctal(header, num, 8);
				num += 8;
				string text = ParseName(span.Slice(num, 155), nameEncoding);
				if (!string.IsNullOrEmpty(text))
				{
					Name = text + "/" + Name;
				}
			}
			bool_0 = Checksum == smethod_4(header);
			return;
		}
		throw new ArgumentNullException("header");
	}

	[Obsolete("No Encoding for Name field is specified, any non-ASCII bytes will be discarded")]
	public void ParseBuffer(byte[] header)
	{
		ParseBuffer(header, null);
	}

	[Obsolete("No Encoding for Name field is specified, any non-ASCII bytes will be discarded")]
	public void WriteHeader(byte[] outBuffer)
	{
		WriteHeader(outBuffer, null);
	}

	public void WriteHeader(byte[] outBuffer, Encoding nameEncoding)
	{
		if (outBuffer != null)
		{
			int num = 0;
			num = GetNameBytes(Name, outBuffer, 0, 100, nameEncoding);
			num = GetOctalBytes(int_0, outBuffer, num, 8);
			num = GetOctalBytes(UserId, outBuffer, num, 8);
			num = GetOctalBytes(GroupId, outBuffer, num, 8);
			num = smethod_1(Size, outBuffer, num, 12);
			num = GetOctalBytes(smethod_5(ModTime), outBuffer, num, 12);
			int int_ = num;
			for (int i = 0; i < 8; i++)
			{
				outBuffer[num++] = 32;
			}
			outBuffer[num++] = TypeFlag;
			num = GetNameBytes(LinkName, outBuffer, num, 100, nameEncoding);
			num = GetAsciiBytes(Magic, 0, outBuffer, num, 6, nameEncoding);
			num = GetNameBytes(Version, outBuffer, num, 2, nameEncoding);
			num = GetNameBytes(UserName, outBuffer, num, 32, nameEncoding);
			num = GetNameBytes(GroupName, outBuffer, num, 32, nameEncoding);
			if (TypeFlag == 51 || TypeFlag == 52)
			{
				num = GetOctalBytes(DevMajor, outBuffer, num, 8);
				num = GetOctalBytes(DevMinor, outBuffer, num, 8);
			}
			while (num < outBuffer.Length)
			{
				outBuffer[num++] = 0;
			}
			int_3 = smethod_3(outBuffer);
			smethod_2(int_3, outBuffer, int_, 8);
			bool_0 = true;
			return;
		}
		throw new ArgumentNullException("outBuffer");
	}

	public override int GetHashCode()
	{
		return Name.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		int result;
		if (obj is TarHeader tarHeader)
		{
			if (!(string_0 == tarHeader.string_0) || int_0 != tarHeader.int_0 || UserId != tarHeader.UserId || GroupId != tarHeader.GroupId || Size != tarHeader.Size)
			{
				goto IL_012b;
			}
			if (!(ModTime == tarHeader.ModTime))
			{
				result = 0;
			}
			else
			{
				if (Checksum != tarHeader.Checksum || TypeFlag != tarHeader.TypeFlag || !(LinkName == tarHeader.LinkName))
				{
					goto IL_012b;
				}
				if (!(Magic == tarHeader.Magic))
				{
					result = 0;
				}
				else if (!(Version == tarHeader.Version))
				{
					result = 0;
				}
				else if (!(UserName == tarHeader.UserName))
				{
					result = 0;
				}
				else if (!(GroupName == tarHeader.GroupName))
				{
					result = 0;
				}
				else
				{
					if (DevMajor != tarHeader.DevMajor)
					{
						goto IL_012b;
					}
					result = ((DevMinor == tarHeader.DevMinor) ? 1 : 0);
				}
			}
			goto IL_012c;
		}
		return false;
		IL_012b:
		result = 0;
		goto IL_012c;
		IL_012c:
		return (byte)result != 0;
	}

	internal static void SetValueDefaults(int userId, string userName, int groupId, string groupName)
	{
		defaultUserId = (userIdAsSet = userId);
		defaultUser = (userNameAsSet = userName);
		defaultGroupId = (groupIdAsSet = groupId);
		defaultGroupName = (groupNameAsSet = groupName);
	}

	internal static void RestoreSetValues()
	{
		defaultUserId = userIdAsSet;
		defaultUser = userNameAsSet;
		defaultGroupId = groupIdAsSet;
		defaultGroupName = groupNameAsSet;
	}

	private static long smethod_0(byte[] byte_1, int int_5, int int_6)
	{
		if (byte_1[int_5] >= 128)
		{
			long num = 0L;
			for (int i = int_6 - 8; i < int_6; i++)
			{
				num = (num << 8) | byte_1[int_5 + i];
			}
			return num;
		}
		return ParseOctal(byte_1, int_5, int_6);
	}

	public static long ParseOctal(byte[] header, int offset, int length)
	{
		if (header != null)
		{
			long num = 0L;
			bool flag = true;
			int num2 = offset + length;
			for (int i = offset; i < num2 && header[i] != 0; i++)
			{
				int num3;
				if (header[i] != 32 && header[i] != 48)
				{
					num3 = 0;
				}
				else
				{
					if (flag)
					{
						continue;
					}
					if (header[i] == 32)
					{
						break;
					}
					num3 = 0;
				}
				flag = (byte)num3 != 0;
				num = (num << 3) + (header[i] - 48);
			}
			return num;
		}
		throw new ArgumentNullException("header");
	}

	[Obsolete("No Encoding for Name field is specified, any non-ASCII bytes will be discarded")]
	public static string ParseName(byte[] header, int offset, int length)
	{
		return ParseName(MemoryExtensions.AsSpan(header).Slice(offset, length), null);
	}

	public static string ParseName(ReadOnlySpan<byte> header, Encoding encoding)
	{
		StringBuilder stringBuilder = StringBuilderPool.Instance.Rent();
		int num = 0;
		if (encoding != null)
		{
			int num2 = 0;
			while (num2 < header.Length && header[num2] != 0)
			{
				num2++;
				num++;
			}
			string value = encoding.GetString(header.ToArray(), 0, num);
			stringBuilder.Append(value);
		}
		else
		{
			for (int i = 0; i < header.Length; i++)
			{
				byte b = header[i];
				if (b == 0)
				{
					break;
				}
				stringBuilder.Append((char)b);
			}
		}
		string result = stringBuilder.ToString();
		StringBuilderPool.Instance.Return(stringBuilder);
		return result;
	}

	public static int GetNameBytes(StringBuilder name, int nameOffset, byte[] buffer, int bufferOffset, int length)
	{
		return GetNameBytes(name.ToString(), nameOffset, buffer, bufferOffset, length, null);
	}

	public static int GetNameBytes(string name, int nameOffset, byte[] buffer, int bufferOffset, int length)
	{
		return GetNameBytes(name, nameOffset, buffer, bufferOffset, length, null);
	}

	public static int GetNameBytes(string name, int nameOffset, byte[] buffer, int bufferOffset, int length, Encoding encoding)
	{
		if (name == null)
		{
			throw new ArgumentNullException("name");
		}
		if (buffer == null)
		{
			throw new ArgumentNullException("buffer");
		}
		int i;
		if (encoding == null)
		{
			for (i = 0; i < length && nameOffset + i < name.Length; i++)
			{
				buffer[bufferOffset + i] = (byte)name[nameOffset + i];
			}
		}
		else
		{
			ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(name).Slice(nameOffset, Math.Min(name.Length - nameOffset, length));
			char[] array = ArrayPool<char>.Shared.Rent(readOnlySpan.Length);
			readOnlySpan.CopyTo(array);
			int bytes = encoding.GetBytes(array, 0, readOnlySpan.Length, buffer, bufferOffset);
			ArrayPool<char>.Shared.Return(array);
			i = Math.Min(bytes, length);
		}
		for (; i < length; i++)
		{
			buffer[bufferOffset + i] = 0;
		}
		return bufferOffset + length;
	}

	[Obsolete("No Encoding for Name field is specified, any non-ASCII bytes will be discarded")]
	public static int GetNameBytes(StringBuilder name, byte[] buffer, int offset, int length)
	{
		return GetNameBytes(name, buffer, offset, length, null);
	}

	public static int GetNameBytes(StringBuilder name, byte[] buffer, int offset, int length, Encoding encoding)
	{
		if (name != null)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			return GetNameBytes(name.ToString(), 0, buffer, offset, length, encoding);
		}
		throw new ArgumentNullException("name");
	}

	[Obsolete("No Encoding for Name field is specified, any non-ASCII bytes will be discarded")]
	public static int GetNameBytes(string name, byte[] buffer, int offset, int length)
	{
		return GetNameBytes(name, buffer, offset, length, null);
	}

	public static int GetNameBytes(string name, byte[] buffer, int offset, int length, Encoding encoding)
	{
		if (name == null)
		{
			throw new ArgumentNullException("name");
		}
		if (buffer == null)
		{
			throw new ArgumentNullException("buffer");
		}
		return GetNameBytes(name, 0, buffer, offset, length, encoding);
	}

	[Obsolete("No Encoding for Name field is specified, any non-ASCII bytes will be discarded")]
	public static int GetAsciiBytes(string toAdd, int nameOffset, byte[] buffer, int bufferOffset, int length)
	{
		return GetAsciiBytes(toAdd, nameOffset, buffer, bufferOffset, length, null);
	}

	public static int GetAsciiBytes(string toAdd, int nameOffset, byte[] buffer, int bufferOffset, int length, Encoding encoding)
	{
		if (toAdd == null)
		{
			throw new ArgumentNullException("toAdd");
		}
		if (buffer != null)
		{
			int i;
			if (encoding != null)
			{
				char[] chars = toAdd.ToCharArray();
				byte[] bytes = encoding.GetBytes(chars, nameOffset, Math.Min(toAdd.Length - nameOffset, length));
				i = Math.Min(bytes.Length, length);
				Array.Copy(bytes, 0, buffer, bufferOffset, i);
			}
			else
			{
				for (i = 0; i < length && nameOffset + i < toAdd.Length; i++)
				{
					buffer[bufferOffset + i] = (byte)toAdd[nameOffset + i];
				}
			}
			for (; i < length; i++)
			{
				buffer[bufferOffset + i] = 0;
			}
			return bufferOffset + length;
		}
		throw new ArgumentNullException("buffer");
	}

	public static int GetOctalBytes(long value, byte[] buffer, int offset, int length)
	{
		if (buffer != null)
		{
			int num = length - 1;
			buffer[offset + num] = 0;
			num--;
			if (value > 0L)
			{
				long num2 = value;
				while (num >= 0 && num2 > 0L)
				{
					buffer[offset + num] = (byte)(48 + (byte)(num2 & 7L));
					num2 >>= 3;
					num--;
				}
			}
			while (num >= 0)
			{
				buffer[offset + num] = 48;
				num--;
			}
			return offset + length;
		}
		throw new ArgumentNullException("buffer");
	}

	private static int smethod_1(long long_1, byte[] byte_1, int int_5, int int_6)
	{
		if (long_1 <= 8589934591L)
		{
			return GetOctalBytes(long_1, byte_1, int_5, int_6);
		}
		for (int num = int_6 - 1; num > 0; num--)
		{
			byte_1[int_5 + num] = (byte)long_1;
			long_1 >>= 8;
		}
		byte_1[int_5] = 128;
		return int_5 + int_6;
	}

	private static void smethod_2(long long_1, byte[] byte_1, int int_5, int int_6)
	{
		GetOctalBytes(long_1, byte_1, int_5, int_6 - 1);
	}

	private static int smethod_3(object object_0)
	{
		int num = 0;
		for (int i = 0; i < ((Array)object_0).Length; i++)
		{
			num += ((byte[])object_0)[i];
		}
		return num;
	}

	private static int smethod_4(object object_0)
	{
		int num = 0;
		for (int i = 0; i < 148; i++)
		{
			num += ((byte[])object_0)[i];
		}
		for (int j = 0; j < 8; j++)
		{
			num += 32;
		}
		for (int k = 156; k < ((Array)object_0).Length; k++)
		{
			num += ((byte[])object_0)[k];
		}
		return num;
	}

	private static int smethod_5(DateTime dateTime_2)
	{
		long ticks = dateTime_2.Ticks;
		DateTime dateTime = dateTime_0;
		return (int)((ticks - dateTime.Ticks) / 10000000L);
	}

	private static DateTime smethod_6(long long_1)
	{
		try
		{
			DateTime dateTime = dateTime_0;
			return new DateTime(dateTime.Ticks + long_1 * 10000000L);
		}
		catch (ArgumentOutOfRangeException)
		{
			return dateTime_0;
		}
	}

	static TarHeader()
	{
		Class72.smethod_20();
		dateTime_0 = new DateTime(1970, 1, 1, 0, 0, 0, 0);
		groupNameAsSet = "None";
		defaultGroupName = "None";
	}
}
