using System;
using System.Data.OleDb;

namespace Command.mdb2sq3;

public class ColumnMetaData
{
	public string columnName;

	public string columnDescription;

	public int ordinalPosition;

	public int maxCharSize;

	public int numericPrecision;

	public int numericScale;

	public int datetimePrecision;

	public bool hasDefault;

	public bool isNullable;

	public string defaultValue;

	public OleDbType columnType;

	public bool isPrimaryKey;

	public bool hasForeignKey;

	public string fkTable;

	public string fkColumn;

	public ColumnMetaData()
	{
		isNullable = true;
		isPrimaryKey = false;
		hasForeignKey = false;
	}

	public static int CompareColumnOrder(ColumnMetaData x, ColumnMetaData y)
	{
		if (x != null)
		{
			if (y == null)
			{
				return 1;
			}
			return x.ordinalPosition.CompareTo(y.ordinalPosition);
		}
		if (y == null)
		{
			return 0;
		}
		return -1;
	}

	public override string ToString()
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected I4, but got Unknown
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Invalid comparison between Unknown and I4
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Invalid comparison between Unknown and I4
		string text = $"{maxCharSize}";
		OleDbType val = columnType;
		switch (val - 2)
		{
		default:
			if ((int)val != 131 && (int)val != 139)
			{
				break;
			}
			goto case 0;
		case 0:
		case 1:
		case 2:
		case 3:
		case 4:
		case 12:
		case 14:
		case 15:
		case 16:
		case 17:
		case 18:
		case 19:
			text = $"{numericPrecision},{numericScale}";
			break;
		case 5:
		case 6:
		case 7:
		case 8:
		case 9:
		case 10:
		case 11:
		case 13:
			break;
		}
		return string.Format("{1}){5}\"{0}\":\t{2}({4})\t [{3}]\t {6} {7}", columnName, ordinalPosition, columnType, columnDescription, text, (!isPrimaryKey) ? "" : "*", (!hasDefault) ? "" : (Convert.ToString("{") + defaultValue + "}"), hasForeignKey ? (Convert.ToString(Convert.ToString("\n\tFK: ") + fkTable + ".") + fkColumn) : "");
	}

	static ColumnMetaData()
	{
		Class72.smethod_20();
	}
}
