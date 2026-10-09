using System.Collections;
using System.Collections.Generic;
using System.Data;

public sealed class DtrRowCollection : IEnumerable<DtrRow>, IEnumerable
{
	private readonly List<DtrRow> list_0;

	public DtrRow this[int i] => list_0[i];

	public DtrRowCollection()
	{
		list_0 = new List<DtrRow>();
	}

	public int Count()
	{
		return list_0.Count;
	}

	public void Add(DtrRow newRow)
	{
		list_0.Add(newRow);
	}

	public void CreateRows(DataTable dt)
	{
		foreach (DtrRow item in list_0)
		{
			dt.Rows.Add(item.ToArray());
		}
	}

	public IEnumerator<DtrRow> GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	static DtrRowCollection()
	{
		Class72.smethod_20();
	}
}
