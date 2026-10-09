using System.Collections.Generic;

namespace baileysoft.Wmi;

internal interface IWMI
{
	IList<string> GetPropertyValues();
}
