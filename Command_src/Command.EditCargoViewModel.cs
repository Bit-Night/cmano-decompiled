using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Forms;
using System.Windows.Media;
using Command_Core;
using Command_Core.DAL;
using Command_Core.SmartAssembly.Attributes;
using Command.My;
using DarkUI.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DoNotPruneType]
[DoNotPrune]
[DoNotObfuscate]
public sealed class EditCargoViewModel : CommandViewModel
{
	[CompilerGenerated]
	internal sealed class _Closure$__61-0
	{
		public CargoManifestItem $VB$Local_item;

		public _Closure$__61-0(_Closure$__61-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_item = arg0.$VB$Local_item;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(Cargo C)
		{
			return C.CurrentType == $VB$Local_item.objectType;
		}

		[SpecialName]
		internal bool _Lambda$__1(Cargo C)
		{
			return C.CargoObjectDBID == $VB$Local_item.DBID;
		}

		static _Closure$__61-0()
		{
			Class72.smethod_20();
		}
	}

	private ActiveUnit sykNeyBqei;

	private ObservableCollection<CargoManifestItem> observableCollection_0;

	private DataTable dataTable_0;

	private DataRowView dataRowView_0;

	private int int_0;

	private CargoManifestItem cargoManifestItem_0;

	private EditCargo editCargo_0;

	private EditCargoControl editCargoControl_0;

	private string string_0;

	[CompilerGenerated]
	private RelayCommand relayCommand_0;

	[CompilerGenerated]
	private RelayCommand relayCommand_1;

	[CompilerGenerated]
	private RelayCommand relayCommand_2;

	[CompilerGenerated]
	private RelayCommand relayCommand_3;

	private static string string_1;

	private static string string_2;

	private static string string_3;

	private static string string_4;

	private static string string_5;

	private static string string_6;

	public ActiveUnit ActiveUnit
	{
		get
		{
			return sykNeyBqei;
		}
		set
		{
			SetProperty(ref sykNeyBqei, value, "ActiveUnit");
		}
	}

	public ObservableCollection<CargoManifestItem> Inventory
	{
		get
		{
			return observableCollection_0;
		}
		set
		{
			SetProperty(ref observableCollection_0, value, "Inventory");
		}
	}

	public DataTable AllCargoItems
	{
		get
		{
			return dataTable_0;
		}
		set
		{
			SetProperty(ref dataTable_0, value, "AllCargoItems");
		}
	}

	public DataRowView SelectedMountToAdd
	{
		get
		{
			return dataRowView_0;
		}
		set
		{
			SetProperty(ref dataRowView_0, value, "SelectedMountToAdd");
		}
	}

	public int Quantity
	{
		get
		{
			return int_0;
		}
		set
		{
			SetProperty(ref int_0, value, "Quantity");
		}
	}

	public CargoManifestItem SelectedCargoToRemove
	{
		get
		{
			return cargoManifestItem_0;
		}
		set
		{
			SetProperty(ref cargoManifestItem_0, value, "SelectedCargoToRemove");
		}
	}

	public EditCargo Form
	{
		get
		{
			return editCargo_0;
		}
		set
		{
			SetProperty(ref editCargo_0, value, "Form");
		}
	}

	public EditCargoControl parentControl
	{
		get
		{
			return editCargoControl_0;
		}
		set
		{
			SetProperty(ref editCargoControl_0, value, "parentControl");
		}
	}

	public string LastError
	{
		get
		{
			return string_0;
		}
		set
		{
			SetProperty(ref string_0, value, "LastError");
		}
	}

	public RelayCommand AddCargoCommand
	{
		[CompilerGenerated]
		get
		{
			return relayCommand_0;
		}
		[CompilerGenerated]
		set
		{
			relayCommand_0 = value;
		}
	}

	public RelayCommand RemoveCargoCommand
	{
		[CompilerGenerated]
		get
		{
			return relayCommand_1;
		}
		[CompilerGenerated]
		set
		{
			relayCommand_1 = value;
		}
	}

	public RelayCommand OKCommand
	{
		[CompilerGenerated]
		get
		{
			return relayCommand_2;
		}
		[CompilerGenerated]
		set
		{
			relayCommand_2 = value;
		}
	}

	public RelayCommand CancelCommand
	{
		[CompilerGenerated]
		get
		{
			return relayCommand_3;
		}
		[CompilerGenerated]
		set
		{
			relayCommand_3 = value;
		}
	}

	static EditCargoViewModel()
	{
		Class72.smethod_20();
		string_1 = "Not Cargo Capable";
		string_2 = "Personnel (Squads, MANPADS, ATGM)";
		string_3 = "Small Cargo (Cars, AAA Guns)";
		string_4 = "Medium Cargo (APC, Towed Arty)";
		string_5 = "Large Cargo (Tank, TEL, Trailer)";
		string_6 = "Very Large Cargo (IRBM / ICBM TEL)";
	}

	public void AddCargo()
	{
		if (SelectedMountToAdd == null)
		{
			return;
		}
		Cargo.CargoObjectType cargoObjectType = Cargo.CargoObjectType.None;
		int num = Conversions.ToInteger(SelectedMountToAdd["ID"]);
		CargoType cargoType = CargoType.NoCargo;
		object obj = SelectedMountToAdd["UnitType"];
		if (!Operators.ConditionalCompareObjectEqual(obj, (object)"Mount", true))
		{
			if (Operators.ConditionalCompareObjectEqual(obj, (object)"Ground Unit", true))
			{
				cargoObjectType = Cargo.CargoObjectType.Vehicle;
			}
			else if (Operators.ConditionalCompareObjectEqual(obj, (object)"Mobile Facility", true))
			{
				cargoObjectType = Cargo.CargoObjectType.Facility;
			}
		}
		else
		{
			cargoObjectType = Cargo.CargoObjectType.Mount;
		}
		if (cargoObjectType == Cargo.CargoObjectType.None)
		{
			return;
		}
		CargoManifestItem cargoManifestItem = Inventory.Where([SpecialName] (CargoManifestItem i) => (i.objectType == cargoObjectType) & (i.DBID == num)).FirstOrDefault();
		if (cargoManifestItem != null)
		{
			cargoManifestItem.quantity += Quantity;
		}
		else
		{
			object obj2 = SelectedMountToAdd["Cargo_Type"];
			if (!Operators.ConditionalCompareObjectEqual(obj2, (object)string_2, true))
			{
				if (Operators.ConditionalCompareObjectEqual(obj2, (object)string_3, true))
				{
					cargoType = CargoType.SmallCargo;
				}
				else if (Operators.ConditionalCompareObjectEqual(obj2, (object)string_4, true))
				{
					cargoType = CargoType.MediumCargo;
				}
				else if (Operators.ConditionalCompareObjectEqual(obj2, (object)string_5, true))
				{
					cargoType = CargoType.LargeCargo;
				}
				else if (Operators.ConditionalCompareObjectEqual(obj2, (object)string_6, true))
				{
					cargoType = CargoType.const_5;
				}
			}
			else
			{
				cargoType = CargoType.Personnel;
			}
			ICargoHost cargoHost = (ICargoHost)ActiveUnit;
			if (cargoType > cargoHost.GetCargo_Type())
			{
				LastError = "Unable to add cargo to platform, due to cargo type limitations.";
				return;
			}
			CargoManifestItem cargoManifestItem2 = new CargoManifestItem(cargoObjectType, num);
			cargoManifestItem2.quantity = Quantity;
			cargoManifestItem2.GenerateName(ActiveUnit.ParentScen);
			Inventory.Add(cargoManifestItem2);
		}
		ObservableCollection<CargoManifestItem> inventory = Inventory;
		Inventory = null;
		Inventory = inventory;
	}

	public void RemoveCargo()
	{
		if (SelectedCargoToRemove != null)
		{
			SelectedCargoToRemove.quantity -= Quantity;
			if (SelectedCargoToRemove.quantity <= 0)
			{
				Inventory.Remove(SelectedCargoToRemove);
			}
			ObservableCollection<CargoManifestItem> inventory = Inventory;
			Inventory = null;
			Inventory = inventory;
		}
	}

	public void OK()
	{
		Cargo[] theArray = ActiveUnit.OnboardCargo;
		Cargo[] theArray2 = new Cargo[0];
		using (IEnumerator<CargoManifestItem> enumerator = Inventory.GetEnumerator())
		{
			_Closure$__61-0 closure$__61- = default(_Closure$__61-0);
			while (enumerator.MoveNext())
			{
				closure$__61- = new _Closure$__61-0(closure$__61-);
				closure$__61-.$VB$Local_item = enumerator.Current;
				IEnumerator<Cargo> enumerator2 = (from C in ActiveUnit.OnboardCargo.Where(closure$__61-._Lambda$__0).Where(closure$__61-._Lambda$__1)
					select (C)).GetEnumerator();
				for (int num = closure$__61-.$VB$Local_item.quantity; num > 0; num--)
				{
					if (!enumerator2.MoveNext())
					{
						ArrayExtensions.Add(ref theArray2, Cargo.CreateNewCargo(closure$__61-.$VB$Local_item.objectType, closure$__61-.$VB$Local_item.DBID, ActiveUnit, ActiveUnit.ParentScen));
					}
					else
					{
						ArrayExtensions.Add(ref theArray2, enumerator2.Current);
					}
				}
			}
		}
		ICargoHost obj = (ICargoHost)ActiveUnit;
		float num2 = obj.GetCargo_Mass();
		float num3 = obj.GetCargo_Area();
		float num4 = obj.GetCargo_Crew();
		Cargo[] array = theArray2;
		foreach (Cargo cargo in array)
		{
			num2 -= cargo.RequiredMass;
			num3 -= cargo.RequiredArea;
			num4 -= cargo.RequiredCrewSpace;
		}
		if (!(num2 < 0f || num3 < 0f || num4 < 0f))
		{
			ArrayExtensions.Clear(ref theArray);
			ActiveUnit.OnboardCargo = theArray2;
			MyProject.Forms.MainForm.RightColumn1.AdjustToSelectionChange(Client.SelectedUnit, Client.SelectedUnit);
			((Form)Form).Close();
		}
		else
		{
			LastError = "The cargo limits on this unit have been exceeded.";
		}
	}

	public void Cancel()
	{
		((Form)Form).Close();
	}

	private DataTrigger method_0(object object_0)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Expected O, but got Unknown
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected O, but got Unknown
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		DataTrigger val = new DataTrigger
		{
			Binding = (BindingBase)new Binding("Cargo_Type"),
			Value = RuntimeHelpers.GetObjectValue(object_0)
		};
		Setter val2 = new Setter();
		((Collection<SetterBase>)(object)val.Setters).Add((SetterBase)(object)val2);
		val2.Property = Control.BackgroundProperty;
		val2.Value = Brushes.Red;
		return val;
	}

	public EditCargoViewModel(EditCargo Form, EditCargoControl Control, ActiveUnit selectedHost)
	{
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Expected O, but got Unknown
		//IL_04e6: Unknown result type (might be due to invalid IL or missing references)
		observableCollection_0 = new ObservableCollection<CargoManifestItem>();
		AddCargoCommand = new RelayCommand([SpecialName] (object a0) =>
		{
			AddCargo();
		});
		RemoveCargoCommand = new RelayCommand([SpecialName] (object a0) =>
		{
			RemoveCargo();
		});
		OKCommand = new RelayCommand([SpecialName] (object a0) =>
		{
			OK();
		});
		CancelCommand = new RelayCommand([SpecialName] (object a0) =>
		{
			Cancel();
		});
		this.Form = Form;
		Quantity = 1;
		ActiveUnit = selectedHost;
		ICargoHost cargoHost = (ICargoHost)ActiveUnit;
		Style val = new Style();
		if (cargoHost.GetCargo_Type() < CargoType.const_5)
		{
			((Collection<TriggerBase>)(object)val.Triggers).Add((TriggerBase)(object)method_0(RuntimeHelpers.GetObjectValue(string_6)));
		}
		if (cargoHost.GetCargo_Type() < CargoType.LargeCargo)
		{
			((Collection<TriggerBase>)(object)val.Triggers).Add((TriggerBase)(object)method_0(RuntimeHelpers.GetObjectValue(string_5)));
		}
		if (cargoHost.GetCargo_Type() < CargoType.MediumCargo)
		{
			((Collection<TriggerBase>)(object)val.Triggers).Add((TriggerBase)(object)method_0(RuntimeHelpers.GetObjectValue(string_4)));
		}
		if (cargoHost.GetCargo_Type() < CargoType.SmallCargo)
		{
			((Collection<TriggerBase>)(object)val.Triggers).Add((TriggerBase)(object)method_0(RuntimeHelpers.GetObjectValue(string_3)));
		}
		if (cargoHost.GetCargo_Type() < CargoType.Personnel)
		{
			((Collection<TriggerBase>)(object)val.Triggers).Add((TriggerBase)(object)method_0(RuntimeHelpers.GetObjectValue(string_2)));
		}
		if (cargoHost.GetCargo_Type() < CargoType.NoCargo)
		{
			((Collection<TriggerBase>)(object)val.Triggers).Add((TriggerBase)(object)method_0(RuntimeHelpers.GetObjectValue(string_1)));
		}
		Control.MyDataGrid.RowStyle = val;
		((Form)Form).Text = "Edit Cargo for " + selectedHost.Name;
		bool flag = false;
		DataTable allCargoItems = default(DataTable);
		try
		{
			SQLiteConnection sqliteConnection_ = Client.CurrentScenario.DBConnection;
			allCargoItems = DBFunctions.GetAllCargoItems(ref sqliteConnection_);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			flag = true;
			ProjectData.ClearProjectError();
		}
		if (!flag && allCargoItems.Rows.Count != 0)
		{
			AllCargoItems = allCargoItems.Clone();
			AllCargoItems.Columns["Cargo_Type"].DataType = typeof(string);
			AllCargoItems.Columns["Cargo_Type"].Caption = "Cargo Type";
			AllCargoItems.Columns["Cargo_Mass"].Caption = "Mass (tons)";
			AllCargoItems.Columns["Cargo_Area"].Caption = "Area (sq. m)";
			AllCargoItems.Columns["Cargo_Crew"].Caption = "Personnel";
			AllCargoItems.Columns["Cargo_ParadropCapable"].Caption = "Paradrop Capable";
			foreach (DataRow row in allCargoItems.Rows)
			{
				AllCargoItems.ImportRow(row);
			}
			foreach (DataRow row2 in AllCargoItems.Rows)
			{
				string text = Conversions.ToString(row2["Cargo_Type"]);
				if (Operators.CompareString(text, "0", true) != 0)
				{
					if (Operators.CompareString(text, "1000", true) == 0)
					{
						row2["Cargo_Type"] = RuntimeHelpers.GetObjectValue(string_2);
					}
					else if (Operators.CompareString(text, "2000", true) != 0)
					{
						if (Operators.CompareString(text, "3000", true) == 0)
						{
							row2["Cargo_Type"] = RuntimeHelpers.GetObjectValue(string_4);
						}
						else if (Operators.CompareString(text, "4000", true) != 0)
						{
							if (Operators.CompareString(text, "5000", true) == 0)
							{
								row2["Cargo_Type"] = RuntimeHelpers.GetObjectValue(string_6);
							}
							else if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
						}
						else
						{
							row2["Cargo_Type"] = RuntimeHelpers.GetObjectValue(string_5);
						}
					}
					else
					{
						row2["Cargo_Type"] = RuntimeHelpers.GetObjectValue(string_3);
					}
				}
				else
				{
					row2["Cargo_Type"] = RuntimeHelpers.GetObjectValue(string_1);
				}
			}
			List<CargoManifestItem> list = Cargo.GenerateCargoManifest(ActiveUnit);
			foreach (CargoManifestItem item in list)
			{
				item.GenerateName(ActiveUnit.ParentScen);
				Inventory.Add(item);
			}
			if (cargoHost.GetCargo_Type() == CargoType.NoCargo)
			{
				LastError = "This unit is unable to host cargo.";
			}
		}
		else
		{
			DarkMessageBox.ShowError("Unable to use currently loaded database for cargo related tasks. Please upgrade scenario to latest database.", "Error");
			((Form)Form).Close();
		}
	}
}
