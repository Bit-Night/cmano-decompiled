using System;
using System.IO;
using ICSharpCode.SharpZipLib.Core;

namespace ICSharpCode.SharpZipLib.Zip;

public sealed class ZipExtraData : IDisposable
{
	private int int_0;

	private int int_1;

	private int int_2;

	private MemoryStream memoryStream_0;

	private byte[] byte_0;

	public int Length => byte_0.Length;

	public int ValueLength => int_2;

	public int CurrentReadIndex => int_0;

	public int UnreadCount
	{
		get
		{
			if (int_1 > byte_0.Length || int_1 < 4)
			{
				throw new ZipException("Find must be called before calling a Read method");
			}
			return int_1 + int_2 - int_0;
		}
	}

	public ZipExtraData()
	{
		Clear();
	}

	public ZipExtraData(byte[] data)
	{
		if (data != null)
		{
			byte_0 = data;
		}
		else
		{
			byte_0 = Empty.Array<byte>();
		}
	}

	public byte[] GetEntryData()
	{
		if (Length > 65535)
		{
			throw new ZipException("Data exceeds maximum length");
		}
		return (byte[])byte_0.Clone();
	}

	public void Clear()
	{
		if (byte_0 == null || byte_0.Length != 0)
		{
			byte_0 = Empty.Array<byte>();
		}
	}

	public Stream GetStreamForTag(int tag)
	{
		Stream result = null;
		if (Find(tag))
		{
			result = new MemoryStream(byte_0, int_0, int_2, writable: false);
		}
		return result;
	}

	public T GetData<T>() where T : class, ITaggedData, new()
	{
		T val = new T();
		if (Find(val.TagID))
		{
			val.SetData(byte_0, int_1, int_2);
			return val;
		}
		return null;
	}

	public bool Find(int headerID)
	{
		int_1 = byte_0.Length;
		int_2 = 0;
		int_0 = 0;
		int num = int_1;
		int num2 = headerID - 1;
		while (num2 != headerID && int_0 < byte_0.Length - 3)
		{
			num2 = method_1();
			num = method_1();
			if (num2 != headerID)
			{
				int_0 += num;
			}
		}
		int num3;
		if (num2 == headerID)
		{
			num3 = ((int_0 + num <= byte_0.Length) ? 1 : 0);
			if (num3 != 0)
			{
				int_1 = int_0;
				int_2 = num;
			}
		}
		else
		{
			num3 = 0;
		}
		return (byte)num3 != 0;
	}

	public void AddEntry(ITaggedData taggedData)
	{
		if (taggedData == null)
		{
			throw new ArgumentNullException("taggedData");
		}
		AddEntry(taggedData.TagID, taggedData.GetData());
	}

	public void AddEntry(int headerID, byte[] fieldData)
	{
		if (headerID <= 65535 && headerID >= 0)
		{
			int num = ((fieldData != null) ? fieldData.Length : 0);
			if (num > 65535)
			{
				throw new ArgumentOutOfRangeException("fieldData", "exceeds maximum length");
			}
			int num2 = byte_0.Length + num + 4;
			if (Find(headerID))
			{
				num2 -= ValueLength + 4;
			}
			if (num2 <= 65535)
			{
				Delete(headerID);
				byte[] array = new byte[num2];
				byte_0.CopyTo(array, 0);
				int int_ = byte_0.Length;
				byte_0 = array;
				method_2(ref int_, headerID);
				method_2(ref int_, num);
				fieldData?.CopyTo(array, int_);
				return;
			}
			throw new ZipException("Data exceeds maximum length");
		}
		throw new ArgumentOutOfRangeException("headerID");
	}

	public void StartNewEntry()
	{
		memoryStream_0 = new MemoryStream();
	}

	public void AddNewEntry(int headerID)
	{
		byte[] fieldData = memoryStream_0.ToArray();
		memoryStream_0 = null;
		AddEntry(headerID, fieldData);
	}

	public void AddData(byte data)
	{
		memoryStream_0.WriteByte(data);
	}

	public void AddData(byte[] data)
	{
		if (data == null)
		{
			throw new ArgumentNullException("data");
		}
		memoryStream_0.Write(data, 0, data.Length);
	}

	public void AddLeShort(int toAdd)
	{
		memoryStream_0.WriteByte((byte)toAdd);
		memoryStream_0.WriteByte((byte)(toAdd >> 8));
	}

	public void AddLeInt(int toAdd)
	{
		AddLeShort((short)toAdd);
		AddLeShort((short)(toAdd >> 16));
	}

	public void AddLeLong(long toAdd)
	{
		AddLeInt((int)(toAdd & 0xFFFFFFFFL));
		AddLeInt((int)(toAdd >> 32));
	}

	public bool Delete(int headerID)
	{
		bool result = false;
		if (Find(headerID))
		{
			result = true;
			int num = int_1 - 4;
			byte[] destinationArray = new byte[byte_0.Length - (ValueLength + 4)];
			Array.Copy(byte_0, 0, destinationArray, 0, num);
			int num2 = num + ValueLength + 4;
			Array.Copy(byte_0, num2, destinationArray, num, byte_0.Length - num2);
			byte_0 = destinationArray;
		}
		return result;
	}

	public long ReadLong()
	{
		method_0(8);
		return (ReadInt() & 0xFFFFFFFFL) | ((long)ReadInt() << 32);
	}

	public int ReadInt()
	{
		method_0(4);
		int result = byte_0[int_0] + (byte_0[int_0 + 1] << 8) + (byte_0[int_0 + 2] << 16) + (byte_0[int_0 + 3] << 24);
		int_0 += 4;
		return result;
	}

	public int ReadShort()
	{
		method_0(2);
		int result = byte_0[int_0] + (byte_0[int_0 + 1] << 8);
		int_0 += 2;
		return result;
	}

	public int ReadByte()
	{
		int result = -1;
		if (int_0 < byte_0.Length && int_1 + int_2 > int_0)
		{
			result = byte_0[int_0];
			int_0++;
		}
		return result;
	}

	public void Skip(int amount)
	{
		method_0(amount);
		int_0 += amount;
	}

	private void method_0(int int_3)
	{
		if (int_1 <= byte_0.Length && int_1 >= 4)
		{
			if (int_0 <= int_1 + int_2 - int_3)
			{
				if (int_0 + int_3 < 4)
				{
					throw new ZipException("Cannot read before start of tag");
				}
				return;
			}
			throw new ZipException("End of extra data");
		}
		throw new ZipException("Find must be called before calling a Read method");
	}

	private int method_1()
	{
		if (int_0 > byte_0.Length - 2)
		{
			throw new ZipException("End of extra data");
		}
		int result = byte_0[int_0] + (byte_0[int_0 + 1] << 8);
		int_0 += 2;
		return result;
	}

	private void method_2(ref int int_3, int int_4)
	{
		byte_0[int_3] = (byte)int_4;
		byte_0[int_3 + 1] = (byte)(int_4 >> 8);
		int_3 += 2;
	}

	public void Dispose()
	{
		if (memoryStream_0 != null)
		{
			memoryStream_0.Dispose();
		}
	}

	static ZipExtraData()
	{
		Class72.smethod_20();
	}
}
