using System.Collections.Generic;
using System.Diagnostics;

namespace Command_Core;

internal class AltBandComparer_SortyByMaxAltAscending : IComparer<AltBand>
{
	internal int Compare(AltBand x, AltBand y)
	{
		if (x == null || y == null)
		{
			_ = Debugger.IsAttached;
			if (x == null && y == null)
			{
				return 0;
			}
			if (x == null)
			{
				return -1;
			}
			if (y == null)
			{
				return 1;
			}
		}
		return x.MaxAlt.CompareTo(y.MaxAlt);
	}

	int IComparer<AltBand>.Compare(AltBand x, AltBand y)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Compare
		return this.Compare(x, y);
	}

	static AltBandComparer_SortyByMaxAltAscending()
	{
		Class72.smethod_20();
	}
}
