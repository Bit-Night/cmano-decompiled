using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace CommandNetcode.RT;

public class OutgoingPacketStatisticsTracker
{
	public Dictionary<string, int> AllPacketCounts = new Dictionary<string, int>();

	public Dictionary<string, int> AllByteCounts = new Dictionary<string, int>();

	private Dictionary<string, int> hToLaKfMlKe = new Dictionary<string, int>();

	private Dictionary<string, int> dictionary_0 = new Dictionary<string, int>();

	[CompilerGenerated]
	private IReadOnlyDictionary<string, int> ireadOnlyDictionary_0 = new Dictionary<string, int>();

	[CompilerGenerated]
	private IReadOnlyDictionary<string, int> ireadOnlyDictionary_1 = new Dictionary<string, int>();

	[CompilerGenerated]
	private readonly List<int> list_0 = new List<int>();

	[CompilerGenerated]
	private readonly List<int> list_1 = new List<int>();

	[CompilerGenerated]
	private int int_0;

	public IReadOnlyDictionary<string, int> PreviousPacketCounts
	{
		[CompilerGenerated]
		get
		{
			return ireadOnlyDictionary_0;
		}
		[CompilerGenerated]
		private set
		{
			ireadOnlyDictionary_0 = value;
		}
	}

	public IReadOnlyDictionary<string, int> PreviousByteCounts
	{
		[CompilerGenerated]
		get
		{
			return ireadOnlyDictionary_1;
		}
		[CompilerGenerated]
		private set
		{
			ireadOnlyDictionary_1 = value;
		}
	}

	public List<int> PacketCountHistory
	{
		[CompilerGenerated]
		get
		{
			return list_0;
		}
	}

	public List<int> ByteCountHistory
	{
		[CompilerGenerated]
		get
		{
			return list_1;
		}
	}

	public int TickCount
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

	public void RecordTick()
	{
		TickCount++;
		PreviousPacketCounts = new Dictionary<string, int>(hToLaKfMlKe);
		PreviousByteCounts = new Dictionary<string, int>(dictionary_0);
		PacketCountHistory.Add(hToLaKfMlKe.Values.Sum());
		ByteCountHistory.Add(dictionary_0.Values.Sum());
		if (PacketCountHistory.Count > 5)
		{
			PacketCountHistory.RemoveAt(0);
		}
		if (ByteCountHistory.Count > 5)
		{
			ByteCountHistory.RemoveAt(0);
		}
		hToLaKfMlKe.Clear();
		dictionary_0.Clear();
	}

	public void TrackOutgoingPacket(string category, int byteSize)
	{
		if (category != null)
		{
			hToLaKfMlKe[category] = ((!hToLaKfMlKe.TryGetValue(category, out var value)) ? 1 : (value + 1));
			AllPacketCounts[category] = ((!AllPacketCounts.TryGetValue(category, out var value2)) ? 1 : (value2 + 1));
			dictionary_0[category] = (dictionary_0.TryGetValue(category, out var value3) ? (value3 + byteSize) : byteSize);
			AllByteCounts[category] = (AllByteCounts.TryGetValue(category, out var value4) ? (value4 + byteSize) : byteSize);
		}
	}

	static OutgoingPacketStatisticsTracker()
	{
		Class72.smethod_20();
	}
}
