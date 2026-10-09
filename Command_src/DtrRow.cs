public sealed class DtrRow
{
	private readonly object[] object_0;

	private readonly DataTableTyped dataTableTyped_0;

	public object this[string columnName]
	{
		get
		{
			int index = dataTableTyped_0.Columns.GetIndex(columnName);
			return object_0[index];
		}
		set
		{
			int index = dataTableTyped_0.Columns.GetIndex(columnName);
			object_0[index] = value;
		}
	}

	public object this[int columnIndex]
	{
		get
		{
			return object_0[columnIndex];
		}
		set
		{
			object_0[columnIndex] = value;
		}
	}

	public DtrRow(DataTableTyped dtr)
	{
		dataTableTyped_0 = dtr;
		int count = dataTableTyped_0.Columns.Count;
		object_0 = new object[count];
	}

	public object[] ToArray()
	{
		return object_0;
	}

	static DtrRow()
	{
		Class72.smethod_20();
	}
}
