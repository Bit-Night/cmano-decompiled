using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Command_Core;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[StandardModule]
internal sealed class CargoUICommon
{
	public static string c0000;

	public static string c1000;

	public static string c2000;

	public static string c3000;

	public static string c4000;

	public static string c5000;

	public static string[] CargoTypeString;

	public static string[] CargoTypeAsStringForEvent;

	static CargoUICommon()
	{
		Class72.smethod_20();
		c0000 = "None";
		c1000 = "Personnel";
		c2000 = "Small";
		c3000 = "Medium";
		c4000 = "Large";
		c5000 = "Very Large";
		CargoTypeString = new string[7] { "None", "Mount", "Ground Unit", "Mobile Facility", "Cargo Container", "Cargo Container Contents", "Aircraft" };
		CargoTypeAsStringForEvent = new string[7] { "ANY", "Mount", "Ground Unit", "Mobile Facility", "Cargo Container", "(UNUSED!)", "Aircraft" };
	}

	public static string GetSizeString(int sizeValue)
	{
		switch (sizeValue)
		{
		case 0:
			return c0000;
		case 2000:
			return c2000;
		case 1000:
			return c1000;
		default:
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			return c0000;
		case 5000:
			return c5000;
		case 4000:
			return c4000;
		case 3000:
			return c3000;
		}
	}

	public static int GetSizeValueFromString(string sizeString)
	{
		if (Operators.CompareString(sizeString, c0000, true) != 0)
		{
			if (Operators.CompareString(sizeString, c1000, true) == 0)
			{
				return 1000;
			}
			if (Operators.CompareString(sizeString, c2000, true) != 0)
			{
				if (Operators.CompareString(sizeString, c3000, true) == 0)
				{
					return 3000;
				}
				if (Operators.CompareString(sizeString, c4000, true) == 0)
				{
					return 4000;
				}
				if (Operators.CompareString(sizeString, c5000, true) != 0)
				{
					return 0;
				}
				return 5000;
			}
			return 2000;
		}
		return 0;
	}

	public static List<Cargo> GetGroupCargo(ActiveUnit theUnit)
	{
		List<Cargo> list = new List<Cargo>();
		if (theUnit != null)
		{
			if (theUnit.IsGroup)
			{
				List<ActiveUnit> list2 = ((Group)theUnit).Units.Values.ToList();
				foreach (ActiveUnit item in list2)
				{
					list.AddRange(item.OnboardCargo);
				}
			}
			else
			{
				list.AddRange(theUnit.OnboardCargo);
			}
		}
		return list;
	}

	public static void AddGridViewCargoFromManfiest(DarkDataGridView theGridView, List<CargoManifestItem> Manifest, List<Cargo> CargoList, bool GroupByUnitType = false, bool InsertAtBegining = false)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 1;
		int num4 = 1;
		int num5 = 2;
		int num6 = 3;
		bool flag;
		if (flag = ((DataGridView)theGridView).ColumnCount > 4)
		{
			num4++;
			num5++;
			num6++;
		}
		foreach (CargoManifestItem item in Manifest)
		{
			if (!InsertAtBegining)
			{
				num = ((DataGridView)theGridView).Rows.Add();
			}
			else
			{
				((DataGridView)theGridView).Rows.Insert(0, 1);
				num = 0;
			}
			DataGridViewRow val = ((DataGridView)theGridView).Rows[num];
			if (item.objectType != Cargo.CargoObjectType.Mount && item.quantity >= 2)
			{
				val.Cells[num2].Value = item.quantity + "x " + item.Name;
			}
			else
			{
				val.Cells[num2].Value = item.Name;
			}
			val.Cells[num2].ToolTipText = item.Name;
			((DataGridViewBand)val).Tag = item;
			if (!GroupByUnitType)
			{
				if (item.objectType == Cargo.CargoObjectType.Mount)
				{
					int num7 = CargoList.Count - 1;
					for (int i = 0; i <= num7; i++)
					{
						Cargo cargo = CargoList[i];
						if (cargo.InternalObjectType == item.objectType && cargo.CargoObjectDBID == item.DBID)
						{
							if (!SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo)
							{
								val.Cells[num4].Value = (cargo.RequiredMass * (float)item.quantity).ToString("N");
								val.Cells[num5].Value = (cargo.RequiredArea * (float)item.quantity).ToString("N");
							}
							else
							{
								val.Cells[num4].Value = Cargo.DisplayValueMass(cargo.RequiredMass * (float)item.quantity, USUnits: true).ToString("N");
								val.Cells[num5].Value = Cargo.DisplayValueArea(cargo.RequiredArea * (float)item.quantity, USUnits: true).ToString("N");
							}
							val.Cells[num6].Value = (cargo.RequiredCrewSpace * (float)item.quantity).ToString();
							if (flag)
							{
								val.Cells[num3].Value = GetSizeString((int)cargo.RequiredCargoType);
								val.Cells[num3].Tag = (int)cargo.RequiredCargoType;
							}
							break;
						}
					}
					continue;
				}
				int num8 = CargoList.Count - 1;
				for (int j = 0; j <= num8; j++)
				{
					Cargo cargo = CargoList[j];
					if (cargo.InternalObjectType == item.objectType && cargo.CargoObjectDBID == item.DBID && Operators.CompareString(cargo.CargoObjectID, item.ObjectID, true) == 0)
					{
						if (!SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo)
						{
							val.Cells[num4].Value = cargo.RequiredMass.ToString("N");
							val.Cells[num5].Value = cargo.RequiredArea.ToString("N");
						}
						else
						{
							val.Cells[num4].Value = Cargo.DisplayValueMass(cargo.RequiredMass, USUnits: true).ToString("N");
							val.Cells[num5].Value = Cargo.DisplayValueArea(cargo.RequiredArea, USUnits: true).ToString("N");
						}
						val.Cells[num6].Value = cargo.RequiredCrewSpace.ToString();
						if (flag)
						{
							val.Cells[num3].Value = GetSizeString((int)cargo.RequiredCargoType);
							val.Cells[num3].Tag = (int)cargo.RequiredCargoType;
						}
						((DataGridViewBand)val).Tag = cargo;
					}
				}
				continue;
			}
			int num9 = CargoList.Count - 1;
			for (int k = 0; k <= num9; k++)
			{
				Cargo cargo = CargoList[k];
				if (cargo.InternalObjectType == item.objectType && cargo.CargoObjectDBID == item.DBID)
				{
					if (!SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo)
					{
						val.Cells[num4].Value = (cargo.RequiredMass * (float)item.quantity).ToString("N");
						val.Cells[num5].Value = (cargo.RequiredArea * (float)item.quantity).ToString("N");
					}
					else
					{
						val.Cells[num4].Value = Cargo.DisplayValueMass(cargo.RequiredMass * (float)item.quantity, USUnits: true).ToString("N");
						val.Cells[num5].Value = Cargo.DisplayValueArea(cargo.RequiredArea * (float)item.quantity, USUnits: true).ToString("N");
					}
					val.Cells[num6].Value = (cargo.RequiredCrewSpace * (float)item.quantity).ToString();
					if (flag)
					{
						val.Cells[num3].Value = GetSizeString((int)cargo.RequiredCargoType);
						val.Cells[num3].Tag = (int)cargo.RequiredCargoType;
					}
					break;
				}
			}
		}
	}

	public static void PopulateGridViewCargoInventory(DarkDataGridView theGridView, ActiveUnit theUnit, List<Cargo> CargoList, bool GroupByUnitType = false)
	{
		int num = -1;
		if (((BaseCollection)((DataGridView)theGridView).SelectedRows).Count > 0)
		{
			num = ((DataGridViewBand)((DataGridView)theGridView).SelectedRows[0]).Index;
		}
		((DataGridView)theGridView).Rows.Clear();
		if (CargoList == null || CargoList.Count < 1)
		{
			return;
		}
		bool flag = false;
		int num2 = -1;
		List<ActiveUnit> list = new List<ActiveUnit>();
		List<Cargo> list2 = new List<Cargo>();
		if (theUnit != null)
		{
			if (theUnit.IsGroup)
			{
				list.AddRange(((Group)theUnit).Units.Values);
				flag = true;
				list2.AddRange(CargoList);
			}
			else
			{
				list.Add(theUnit);
			}
		}
		else
		{
			list2.AddRange(CargoList);
		}
		foreach (ActiveUnit item in list)
		{
			theUnit = item;
			if (theUnit == null || !(theUnit is ICargoHost))
			{
				continue;
			}
			List<CargoManifestItem> list3;
			if (!flag)
			{
				list3 = Cargo.GenerateCargoManifest(CargoList, GroupByUnitType);
			}
			else
			{
				List<Cargo> list4 = new List<Cargo>();
				foreach (Cargo Cargo in CargoList)
				{
					if (theUnit.OnboardCargo.Contains(Cargo))
					{
						list4.Add(Cargo);
						list2.Remove(Cargo);
					}
				}
				if (list4.Count > 0)
				{
					num2 = ((DataGridView)theGridView).Rows.Add();
					DataGridViewRow obj = ((DataGridView)theGridView).Rows[num2];
					obj.Cells[0].Value = theUnit.Name + " [Group Member]";
					obj.Cells[0].ToolTipText = theUnit.Name;
					((DataGridViewBand)obj).Tag = theUnit;
				}
				list3 = Cargo.GenerateCargoManifest(list4, GroupByUnitType);
			}
			if (list3.Count > 0)
			{
				AddGridViewCargoFromManfiest(theGridView, list3, CargoList, GroupByUnitType);
			}
		}
		if (list2.Count > 0)
		{
			List<CargoManifestItem> list3 = Cargo.GenerateCargoManifest(list2, GroupByUnitType);
			AddGridViewCargoFromManfiest(theGridView, list3, list2, GroupByUnitType, InsertAtBegining: true);
		}
		((Control)theGridView).Refresh();
		if (((DataGridView)theGridView).Rows.Count > 0 && num > -1)
		{
			((DataGridView)theGridView).ClearSelection();
			if (num >= ((DataGridView)theGridView).Rows.Count)
			{
				num = ((DataGridView)theGridView).Rows.Count - 1;
			}
			((DataGridView)theGridView).Rows[num].Selected = true;
		}
	}

	public static void UpdateCapacityLabels(ActiveUnit theUnit, DarkLabel SizeLabel, DarkUIProgressBar MassBar, float AvailableMass, DarkUIProgressBar AreaBar, float AvailableArea, DarkUIProgressBar CrewBar, float AvailableCrew, Loadout UseLoadoutForCapacity = null)
	{
		if (theUnit == null)
		{
			if (SizeLabel != null)
			{
				((Label)SizeLabel).Text = "Max Size: Unlimted";
			}
			((Control)MassBar).Text = "Mass: " + AvailableMass.ToString("N") + " " + Cargo.CargoMassLabel(SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo);
			((Control)MassBar).ForeColor = Color.White;
			((Control)AreaBar).Text = "Area: " + AvailableArea.ToString("N") + " " + Cargo.CargoAreaLabel(SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo);
			((Control)AreaBar).ForeColor = Color.White;
			((Control)CrewBar).Text = "PAX: " + AvailableCrew + " Pers.";
			((Control)CrewBar).ForeColor = Color.White;
			return;
		}
		float num = default(float);
		float num2 = default(float);
		float num3 = default(float);
		float num4 = default(float);
		if (UseLoadoutForCapacity == null)
		{
			if (theUnit.IsGroup)
			{
				foreach (ActiveUnit value in ((Group)theUnit).Units.Values)
				{
					if (value is ICargoHost)
					{
						ICargoHost cargoHost = (ICargoHost)value;
						if ((float)cargoHost.GetCargo_Type() > num)
						{
							num = (float)cargoHost.GetCargo_Type();
						}
						num2 += cargoHost.GetCargo_Mass();
						num3 += cargoHost.GetCargo_Area();
						num4 += cargoHost.GetCargo_Crew();
					}
				}
			}
			else if (theUnit is ICargoHost)
			{
				ICargoHost obj = (ICargoHost)theUnit;
				num = (float)obj.GetCargo_Type();
				num2 = obj.GetCargo_Mass();
				num3 = obj.GetCargo_Area();
				num4 = obj.GetCargo_Crew();
			}
		}
		else
		{
			num = (float)UseLoadoutForCapacity.Cargo_Type;
			num2 = UseLoadoutForCapacity.GetCargoMass();
			num3 = UseLoadoutForCapacity.GetCargoArea();
			num4 = UseLoadoutForCapacity.Cargo_Crew;
		}
		if (SizeLabel != null)
		{
			((Label)SizeLabel).Text = "Max Size: ";
			float num5 = num;
			if (num5 == 0f)
			{
				((Label)SizeLabel).Text = ((Label)SizeLabel).Text + CargoHostHelper.c0000;
			}
			else if (num5 == 1000f)
			{
				((Label)SizeLabel).Text = ((Label)SizeLabel).Text + CargoHostHelper.c1000;
			}
			else if (num5 == 2000f)
			{
				((Label)SizeLabel).Text = ((Label)SizeLabel).Text + CargoHostHelper.c2000;
			}
			else if (num5 == 3000f)
			{
				((Label)SizeLabel).Text = ((Label)SizeLabel).Text + CargoHostHelper.c3000;
			}
			else if (num5 == 4000f)
			{
				((Label)SizeLabel).Text = ((Label)SizeLabel).Text + CargoHostHelper.c4000;
			}
			else if (num5 == 5000f)
			{
				((Label)SizeLabel).Text = ((Label)SizeLabel).Text + CargoHostHelper.c5000;
			}
		}
		float num6 = num2;
		float num7 = Cargo.DisplayValueMass(num6 - AvailableMass, SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo);
		float num8 = Cargo.DisplayValueMass(num6, SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo);
		((Control)MassBar).Text = "Mass: " + num7.ToString("N") + " / " + num8.ToString("N") + " " + Cargo.CargoMassLabel(SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo);
		if (num6 == 0f)
		{
			MassBar.Value = 100;
		}
		else
		{
			MassBar.Value = (int)Math.Round(100f * ((num6 - AvailableMass) / num6));
		}
		if (AvailableMass == 0f)
		{
			((Control)MassBar).ForeColor = Color.LightGray;
			((Control)MassBar).Text = "[FULL] " + ((Control)MassBar).Text;
		}
		else
		{
			((Control)MassBar).ForeColor = Color.White;
		}
		num6 = num3;
		num7 = Cargo.DisplayValueArea(num6 - AvailableArea, SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo);
		num8 = Cargo.DisplayValueArea(num6, SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo);
		((Control)AreaBar).Text = "Area: " + num7.ToString("N") + " / " + num8.ToString("N") + " " + Cargo.CargoAreaLabel(SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo);
		if (num6 == 0f)
		{
			AreaBar.Value = 100;
		}
		else
		{
			AreaBar.Value = (int)Math.Round(100f * ((num6 - AvailableArea) / num6));
		}
		if (AvailableArea == 0f)
		{
			((Control)AreaBar).ForeColor = Color.LightGray;
			((Control)AreaBar).Text = "[FULL] " + ((Control)AreaBar).Text;
		}
		else
		{
			((Control)AreaBar).ForeColor = Color.White;
		}
		num6 = num4;
		((Control)CrewBar).Text = "PAX: " + (num6 - AvailableCrew) + " / " + num6.ToString("N0") + " Pers.";
		if (num6 == 0f)
		{
			CrewBar.Value = 100;
		}
		else
		{
			CrewBar.Value = (int)Math.Round(100f * ((num6 - AvailableCrew) / num6));
		}
		if (AvailableCrew == 0f)
		{
			((Control)CrewBar).ForeColor = Color.LightGray;
			((Control)CrewBar).Text = "[FULL] " + ((Control)CrewBar).Text;
		}
		else
		{
			((Control)CrewBar).ForeColor = Color.White;
		}
	}
}
