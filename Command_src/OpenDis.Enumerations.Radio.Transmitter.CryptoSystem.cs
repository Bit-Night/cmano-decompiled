using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Radio.Transmitter;

[Serializable]
public enum CryptoSystem : ushort
{
	[Description("Other.")]
	Other,
	[Description("KY-28.")]
	KY28,
	[Description("VINSON (KY-57, KY-58, SINCGARS ICOM).")]
	VINSON,
	[Description("Narrow Spectrum Secure Voice (NSVE).")]
	NarrowSpectrumSecureVoice,
	[Description("Wide Spectrum Secure Voice (WSVE).")]
	WideSpectrumSecureVoice
}
