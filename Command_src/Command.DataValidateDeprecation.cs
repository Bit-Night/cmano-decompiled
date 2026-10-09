using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[StandardModule]
internal sealed class DataValidateDeprecation
{
	public static void ValidateDeprecationWeapons()
	{
		//IL_0252: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			DataTable dataTable = Common.get_DataWeapon(Common.mySourceDB_Helper);
			DataRow[] array = Common.get_DataWarhead(Common.mySourceDB_Helper).Select("Type=5002");
			IEnumerator enumerator = dataTable.Rows.GetEnumerator();
			try
			{
				while (true)
				{
					if (!enumerator.MoveNext())
					{
						return;
					}
					object objectValue = RuntimeHelpers.GetObjectValue(enumerator.Current);
					long num = Conversions.ToLong(NewLateBinding.LateIndexGet(objectValue, new object[1] { "ID" }, (string[])null));
					if (!DataValidateAllInOne.DeprecationImplemented)
					{
						break;
					}
					if (!Conversions.ToBoolean(NewLateBinding.LateIndexGet(objectValue, new object[1] { "Deprecated" }, (string[])null)))
					{
						continue;
					}
					DataRow[] array2 = Common.get_DataWeaponRecord(Common.mySourceDB_Helper).Select("ComponentID=" + Conversions.ToString(num));
					foreach (DataRow dataRow in array2)
					{
						string text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"Weapon Record ", dataRow["ID"]), (object)" points to a deprecated weapon!"));
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					DataRow[] array3 = array;
					foreach (DataRow dataRow2 in array3)
					{
						if (Operators.ConditionalCompareObjectEqual(dataRow2["ExplosivesWeight"], (object)num, true))
						{
							string text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"Warhead ", dataRow2["ID"]), (object)" points to a deprecated weapon!"));
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
					}
				}
				Interaction.MsgBox((object)"Deprecation has not been implemented on this database, therefore deprecation checks will not be performed. To implement deprecation run the Update Schema function.", (MsgBoxStyle)64, (object)"Deprecation Not Implemented");
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at Validation D100100", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateDeprecationWarheads()
	{
		try
		{
			DataTable dataTable = Common.get_DataWarhead(Common.mySourceDB_Helper);
			foreach (object row in dataTable.Rows)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(row);
				long num = Conversions.ToLong(NewLateBinding.LateIndexGet(objectValue, new object[1] { "ID" }, (string[])null));
				if (!DataValidateAllInOne.DeprecationImplemented)
				{
					break;
				}
				if (Conversions.ToBoolean(NewLateBinding.LateIndexGet(objectValue, new object[1] { "Deprecated" }, (string[])null)))
				{
					DataRow[] array = Common.get_DataWeaponWarheads(Common.mySourceDB_Helper).Select("ComponentID=" + Conversions.ToString(num));
					foreach (DataRow dataRow in array)
					{
						string text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"Weapon ", dataRow["ID"]), (object)" points to a deprecated Warhead!"));
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Warhead" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at Validation D200100", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	static DataValidateDeprecation()
	{
		Class72.smethod_20();
	}
}
