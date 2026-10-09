using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.VisualBasic.CompilerServices;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

namespace Command_Core;

[StandardModule]
internal sealed class NPOI
{
	internal static DataTable ExcelSheetToDataTable(string theFileName, int SheetIndex = 0)
	{
		DataTable result = default(DataTable);
		try
		{
			IWorkbook workbook;
			using (FileStream s = new FileStream(theFileName, FileMode.Open, FileAccess.Read))
			{
				workbook = new HSSFWorkbook(s);
			}
			ISheet sheetAt = workbook.GetSheetAt(SheetIndex);
			DataTable dataTable = new DataTable(sheetAt.SheetName);
			IRow row = sheetAt.GetRow(0);
			foreach (ICell item in row)
			{
				dataTable.Columns.Add(item.ToString());
			}
			int num = row.Count();
			bool flag = true;
			foreach (IRow item2 in sheetAt)
			{
				if (flag)
				{
					flag = false;
					continue;
				}
				DataRow dataRow = dataTable.NewRow();
				try
				{
					List<string> list = new List<string>();
					int num2 = num - 1;
					for (int i = 0; i <= num2; i++)
					{
						if (item2.GetCell(i, MissingCellPolicy.RETURN_NULL_AND_BLANK) == null)
						{
							list.Add("");
							continue;
						}
						string text = item2.GetCell(i, MissingCellPolicy.RETURN_NULL_AND_BLANK).ToString();
						if (!string.IsNullOrEmpty(text))
						{
							list.Add(text);
						}
						else
						{
							list.Add("");
						}
					}
					if (list.Count > 0 && Operators.CompareString(list.Last(), "", false) == 0)
					{
						list.RemoveAt(list.Count - 1);
					}
					dataRow.ItemArray = list.ToArray();
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
					continue;
				}
				dataTable.Rows.Add(dataRow);
			}
			result = dataTable;
			return result;
		}
		catch (Exception projectError2)
		{
			ProjectData.SetProjectError(projectError2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				throw;
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	static NPOI()
	{
		Class72.smethod_20();
	}
}
