using System;

namespace Command;

public class Field_Delta
{
	public string ID;

	public bool Editable;

	public HashTable_Row Row;

	public Hashtable Table;

	public string Column;

	public string OriginalValue;

	public string TargetValue;

	public Type Type;

	public Field_Delta(Hashtable _Table, string _Column, string _ID, string _OriginalValue, string _TargetValue, Type TheType, bool _Editable = true)
	{
		Column = null;
		OriginalValue = null;
		TargetValue = null;
		ID = _ID;
		Table = _Table;
		Editable = _Editable;
		Column = _Column;
		OriginalValue = _OriginalValue;
		TargetValue = _TargetValue;
		Type = TheType;
	}

	static Field_Delta()
	{
		Class72.smethod_20();
	}
}
