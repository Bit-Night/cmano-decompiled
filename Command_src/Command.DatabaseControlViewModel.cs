using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using Command_Core;
using Command.My;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

public sealed class DatabaseControlViewModel : CommandViewModel
{
	public static LockObject InternalDBViewer_LockObj;

	private string string_0;

	private DatabaseControl databaseControl_0;

	private string string_1;

	private int int_0;

	private string string_2;

	private string string_3;

	private List<DatabaseControlTypeViewModel> list_0;

	private DataView hAxceBgvik;

	private long long_0;

	private long long_1;

	private DataView dataView_0;

	private string string_4;

	private DataView dataView_1;

	private long long_2;

	private bool bool_0;

	private DatabaseControlTypeViewModel databaseControlTypeViewModel_0;

	private bool bool_1;

	public string WindowTitle
	{
		get
		{
			return string_0;
		}
		set
		{
			SetProperty(ref string_0, value, "WindowTitle");
		}
	}

	public DatabaseControl DatabaseControl
	{
		get
		{
			return databaseControl_0;
		}
		set
		{
			SetProperty(ref databaseControl_0, value, "DatabaseControl");
		}
	}

	public string SelectedObjectType
	{
		get
		{
			return string_1;
		}
		set
		{
			SetProperty(ref string_1, value, "SelectedObjectType");
			OnPropertyChanged("SelectedType");
		}
	}

	public int SelectedObjectID
	{
		get
		{
			return int_0;
		}
		set
		{
			SetProperty(ref int_0, value, "SelectedObjectID");
		}
	}

	public string SelectedObjectName
	{
		get
		{
			return string_2;
		}
		set
		{
			SetProperty(ref string_2, value, "SelectedObjectName");
		}
	}

	public string HighlightTarget
	{
		get
		{
			return string_3;
		}
		set
		{
			SetProperty(ref string_3, value, "HighlightTarget");
		}
	}

	public List<DatabaseControlTypeViewModel> Types
	{
		get
		{
			return list_0;
		}
		set
		{
			SetProperty(ref list_0, value, "Types");
		}
	}

	public DataView Countries
	{
		get
		{
			return hAxceBgvik;
		}
		set
		{
			SetProperty(ref hAxceBgvik, value, "Countries");
		}
	}

	public long UnitsDataViewSelectedUnitID
	{
		get
		{
			return long_0;
		}
		set
		{
			if (SetProperty(ref long_0, value, "UnitsDataViewSelectedUnitID"))
			{
				SelectedObjectID = (int)value;
				OnPropertyChanged("SelectedObjectID");
			}
		}
	}

	public long SelectedCountryID
	{
		get
		{
			return long_1;
		}
		set
		{
			SetProperty(ref long_1, value, "SelectedCountryID");
		}
	}

	public DataView UnitsDataView
	{
		get
		{
			return dataView_0;
		}
		set
		{
			SetProperty(ref dataView_0, value, "UnitsDataView");
		}
	}

	public string SearchString
	{
		get
		{
			return string_4;
		}
		set
		{
			SetProperty(ref string_4, value, "SearchString");
		}
	}

	public DataView UnitTypes
	{
		get
		{
			return dataView_1;
		}
		set
		{
			SetProperty(ref dataView_1, value, "UnitTypes");
		}
	}

	public long SelectedUnitTypeID
	{
		get
		{
			return long_2;
		}
		set
		{
			SetProperty(ref long_2, value, "SelectedUnitTypeID");
		}
	}

	public bool ShowHypothetical
	{
		get
		{
			return bool_0;
		}
		set
		{
			SetProperty(ref bool_0, value, "ShowHypothetical");
		}
	}

	public DatabaseControlTypeViewModel SelectedType
	{
		get
		{
			return databaseControlTypeViewModel_0;
		}
		set
		{
			if (SetProperty(ref databaseControlTypeViewModel_0, value, "SelectedType"))
			{
				SelectedObjectType = value.Name;
				OnPropertyChanged("SelectedObjectType");
			}
		}
	}

	static DatabaseControlViewModel()
	{
		Class72.smethod_20();
		InternalDBViewer_LockObj = new LockObject();
	}

	public DatabaseControlViewModel()
	{
		string_3 = null;
	}

	public void Populate()
	{
		if (bool_1)
		{
			return;
		}
		bool_1 = true;
		if (Types == null)
		{
			Types = new List<DatabaseControlTypeViewModel>();
			Types.Add(new DatabaseControlTypeViewModel
			{
				Name = "Aircraft"
			});
			Types.Add(new DatabaseControlTypeViewModel
			{
				Name = "Ship"
			});
			Types.Add(new DatabaseControlTypeViewModel
			{
				Name = "Submarine"
			});
			Types.Add(new DatabaseControlTypeViewModel
			{
				Name = "Facility"
			});
			Types.Add(new DatabaseControlTypeViewModel
			{
				Name = "Satellite"
			});
			Types.Add(new DatabaseControlTypeViewModel
			{
				Name = "Weapon"
			});
		}
		if (string.IsNullOrWhiteSpace(SelectedObjectType))
		{
			SelectedObjectType = "Aircraft";
		}
		SelectedType = Types.FirstOrDefault([SpecialName] (DatabaseControlTypeViewModel F) => Operators.CompareString(F.Name, SelectedObjectType, true) == 0);
		Countries = Client.CurrentScenario.Cache_OperatorCountries_DT.DefaultView;
		if (SelectedCountryID == 0L)
		{
			SelectedCountryID = 1001L;
		}
		string theQuery = "";
		string selectedObjectType = SelectedObjectType;
		if (Operators.CompareString(selectedObjectType, "Aircraft", true) != 0 && Operators.CompareString(selectedObjectType, "Ship", true) != 0 && Operators.CompareString(selectedObjectType, "Submarine", true) != 0 && Operators.CompareString(selectedObjectType, "Satellite", true) != 0 && Operators.CompareString(selectedObjectType, "Weapon", true) != 0)
		{
			if (Operators.CompareString(selectedObjectType, "Facility", true) == 0)
			{
				theQuery = $"SELECT ID, Description from Enum{SelectedObjectType}Category ORDER BY CASE WHEN ID >= 2000 THEN Description END ASC, CASE WHEN ID < 2000 THEN ID END ASC ";
			}
		}
		else
		{
			theQuery = $"SELECT ID, Description from Enum{SelectedObjectType}Type ORDER BY CASE WHEN ID >= 2000 THEN Description END ASC, CASE WHEN ID < 2000 THEN ID END ASC ";
		}
		UnitTypes = DBCache.GetDatatable(new SQLiteHelper(Client.CurrentScenario.DBConnection), theQuery).DefaultView;
		if (SelectedUnitTypeID == 0L)
		{
			SelectedUnitTypeID = 1001L;
		}
		string name = SelectedType.Name;
		DataTable table;
		if (Operators.CompareString(name, "Aircraft", true) == 0)
		{
			table = Client.CurrentScenario.Cache_Aircraft_DT;
		}
		else if (Operators.CompareString(name, "Ship", true) == 0)
		{
			table = Client.CurrentScenario.Cache_Ships_DT;
		}
		else if (Operators.CompareString(name, "Submarine", true) == 0)
		{
			table = Client.CurrentScenario.Cache_Subs_DT;
		}
		else if (Operators.CompareString(name, "Facility", true) != 0)
		{
			if (Operators.CompareString(name, "Satellite", true) == 0)
			{
				table = Client.CurrentScenario.Cache_Satellites_DT;
			}
			else
			{
				if (Operators.CompareString(name, "Weapon", true) != 0)
				{
					throw new Exception();
				}
				table = Client.CurrentScenario.Cache_Weapons_DT;
			}
		}
		else
		{
			table = Client.CurrentScenario.Cache_Facilities_DT;
		}
		DataView dataView = new DataView(table);
		dataView.Sort = "LongName ASC";
		if (!string.IsNullOrWhiteSpace(SearchString) || SelectedCountryID != 1001L || SelectedUnitTypeID != 1001L)
		{
			string text = "1=1 ";
			if (!string.IsNullOrWhiteSpace(SearchString))
			{
				string arg = SearchString.Replace("'", "''");
				text += $" AND LongName LIKE '%{arg}%' ";
			}
			if (SelectedCountryID != 1001L)
			{
				text += $" AND OperatorCountry={SelectedCountryID}";
			}
			if (!ShowHypothetical)
			{
				text += " AND Hypothetical=FALSE";
			}
			text = text.Replace("[", "[[");
			text = text.Replace("]", "]]");
			text = text.Replace("[[", "[[]");
			text = text.Replace("]]", "[]]");
			dataView.RowFilter = text;
		}
		UnitsDataView = dataView;
		lock (InternalDBViewer_LockObj)
		{
			if (SelectedObjectID == 0)
			{
				DatabaseControl.WebBrowser1.NavigateToString("<html><body style='background-color:#555555;color:white;'></body></html>");
			}
			else
			{
				MyProject.Forms.InternalDBViewer.SelectedObjectType = SelectedObjectType;
				MyProject.Forms.InternalDBViewer.SelectedObjectID = SelectedObjectID;
				MyProject.Forms.InternalDBViewer.HighlightTarget = HighlightTarget;
				MyProject.Forms.InternalDBViewer.DisplaySelection(ApplyKeywordFilter: false);
				SelectedObjectName = MyProject.Forms.InternalDBViewer.DatabaseObjectName;
				WindowTitle = $"DB: {SelectedObjectName}";
				DatabaseControl.WebBrowser1.NavigateToString($"<html><body style='background-color:#555555;color:white;'>{MyProject.Forms.InternalDBViewer.string_0}</body></html>");
			}
		}
		bool_1 = false;
	}
}
