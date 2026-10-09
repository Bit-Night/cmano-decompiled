using System;
using System.Collections.Generic;
using System.Text;
using OpenDis.Dis1998;

namespace OpenDis.Core;

public static class DIS1998ChunkConverter
{
	public static List<EightByteChunk> ArrayToEightByteChunks(Array data)
	{
		if (data.Length != 0)
		{
			EightByteChunk eightByteChunk = new EightByteChunk();
			int num = eightByteChunk.OtherParameters.Length;
			int num2 = Convert.ToInt32(Math.Ceiling((double)data.Length / (double)num));
			byte[] array = new byte[num2 * num];
			Buffer.BlockCopy(data, 0, array, 0, data.Length);
			List<EightByteChunk> list = new List<EightByteChunk>();
			for (int i = 0; i < num2; i++)
			{
				eightByteChunk = new EightByteChunk();
				Buffer.BlockCopy(array, i * num, eightByteChunk.OtherParameters, 0, num);
				list.Add(eightByteChunk);
			}
			return list;
		}
		return null;
	}

	public static List<FourByteChunk> ArrayToFourByteChunks(Array data)
	{
		if (data.Length != 0)
		{
			FourByteChunk fourByteChunk = new FourByteChunk();
			int num = fourByteChunk.OtherParameters.Length;
			int num2 = Convert.ToInt32(Math.Ceiling((double)data.Length / (double)num));
			byte[] array = new byte[num2 * num];
			Buffer.BlockCopy(data, 0, array, 0, data.Length);
			List<FourByteChunk> list = new List<FourByteChunk>();
			for (int i = 0; i < num2; i++)
			{
				fourByteChunk = new FourByteChunk();
				Buffer.BlockCopy(array, i * num, fourByteChunk.OtherParameters, 0, num);
				list.Add(fourByteChunk);
			}
			return list;
		}
		return null;
	}

	public static List<TwoByteChunk> ArrayToTwoByteChunks(Array data)
	{
		if (data.Length == 0)
		{
			return null;
		}
		TwoByteChunk twoByteChunk = new TwoByteChunk();
		int num = twoByteChunk.OtherParameters.Length;
		int num2 = Convert.ToInt32(Math.Ceiling((double)data.Length / (double)num));
		byte[] array = new byte[num2 * num];
		Buffer.BlockCopy(data, 0, array, 0, data.Length);
		List<TwoByteChunk> list = new List<TwoByteChunk>();
		for (int i = 0; i < num2; i++)
		{
			twoByteChunk = new TwoByteChunk();
			Buffer.BlockCopy(array, i * num, twoByteChunk.OtherParameters, 0, num);
			list.Add(twoByteChunk);
		}
		return list;
	}

	public static Array EightByteChunksToArray(List<EightByteChunk> chunkList)
	{
		int num = new EightByteChunk().OtherParameters.Length;
		if (chunkList.Count == 0)
		{
			return null;
		}
		byte[] array = new byte[chunkList.Count * num];
		for (int i = 0; i < chunkList.Count; i++)
		{
			Buffer.BlockCopy(chunkList[i].OtherParameters, 0, array, i * num, num);
		}
		return array;
	}

	public static Array FourByteChunksToArray(List<FourByteChunk> chunkList)
	{
		int num = new FourByteChunk().OtherParameters.Length;
		if (chunkList.Count != 0)
		{
			byte[] array = new byte[chunkList.Count * num];
			for (int i = 0; i < chunkList.Count; i++)
			{
				Buffer.BlockCopy(chunkList[i].OtherParameters, 0, array, i * num, num);
			}
			return array;
		}
		return null;
	}

	public static List<EightByteChunk> StringToEightByteChunks(string data)
	{
		if (data.Length == 0)
		{
			return null;
		}
		return ArrayToEightByteChunks(new ASCIIEncoding().GetBytes(data));
	}

	public static List<FourByteChunk> StringToFourByteChunks(string data)
	{
		if (data.Length == 0)
		{
			return null;
		}
		return ArrayToFourByteChunks(new ASCIIEncoding().GetBytes(data));
	}

	public static List<TwoByteChunk> StringToTwoByteChunks(string data)
	{
		if (data.Length == 0)
		{
			return null;
		}
		return ArrayToTwoByteChunks(new ASCIIEncoding().GetBytes(data));
	}

	public static Array TwoByteChunksToArray(List<TwoByteChunk> chunkList)
	{
		int num = new TwoByteChunk().OtherParameters.Length;
		if (chunkList.Count != 0)
		{
			byte[] array = new byte[chunkList.Count * num];
			for (int i = 0; i < chunkList.Count; i++)
			{
				Buffer.BlockCopy(chunkList[i].OtherParameters, 0, array, i * num, num);
			}
			return array;
		}
		return null;
	}

	static DIS1998ChunkConverter()
	{
		Class72.smethod_20();
	}
}
