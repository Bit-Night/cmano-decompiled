namespace CommandNetcode.RT;

public interface InOutDisplay
{
	string IncommingData { get; set; }

	string OutgoingData { get; set; }

	string OutgoingSummary { get; set; }

	string IncommingSummary { get; set; }
}
