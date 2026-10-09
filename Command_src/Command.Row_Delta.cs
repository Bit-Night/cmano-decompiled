using Microsoft.VisualBasic;

namespace Command;

public class Row_Delta
{
	public Hashtable Table;

	public bool Editable;

	public string ID;

	public HashTable_Row Value;

	public MethodDelta Method;

	public string Name;

	public Row_Delta(Hashtable _Table, string _ID, MethodDelta _Method, bool _Editable = true, string _Name = "")
	{
		Table = _Table;
		Editable = _Editable;
		ID = _ID;
		Method = _Method;
		Name = _Name;
		method_0();
	}

	public Row_Delta(Hashtable _Table, string _ID, MethodDelta _Method, HashTable_Row CopyOverRow, bool _Editable = true, string _Name = "")
	{
		Editable = _Editable;
		Value = CopyOverRow;
		ID = _ID;
		Method = _Method;
		Table = _Table;
		Name = _Name;
		method_0();
	}

	private void method_0()
	{
		if (string.IsNullOrEmpty(Name) && !Information.IsNothing((object)Value))
		{
			Name = Value.Name;
		}
	}

	static Row_Delta()
	{
		Class72.smethod_20();
	}
}
