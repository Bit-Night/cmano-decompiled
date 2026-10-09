using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;
using Command_Core.SmartAssembly.Attributes;
using DarkUI.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[DoNotObfuscate]
[DoNotPrune]
[DoNotPruneType]
public class AggregateUnitTemplate
{
	public string NameAndID;

	public int Category;

	public int Echelon;

	public float Friction;

	public List<string> AssignedRoster;

	public List<string> AssignedRoster_Detached;

	public List<string> ActualRoster;

	public AggregateUnitTemplate()
	{
		AssignedRoster = new List<string>();
		AssignedRoster_Detached = new List<string>();
		ActualRoster = new List<string>();
	}

	public void SaveToFile(bool RebuildAGUatabase = false, bool bool_0 = false)
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			using (FileStream fileStream = File.Create(AGU_CONFIG.HannibalDatabasePath + Conversions.ToString(Path.DirectorySeparatorChar) + NameAndID + ".template"))
			{
				new XmlSerializer(typeof(AggregateUnitTemplate)).Serialize((Stream)fileStream, (object)this);
			}
			if (bool_0)
			{
				DarkMessageBox.ShowInformation("Template saved as " + NameAndID, "Save as template", DarkDialogButton.Close);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error in AggregateUnitCreator", "Button_SaveTemplate_Click");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			if (bool_0)
			{
				DarkMessageBox.ShowError("Error: " + ex2.Message, "Error during export");
			}
			ProjectData.ClearProjectError();
		}
		if (RebuildAGUatabase)
		{
			AGU_DATABASE.smethod_0();
		}
	}

	public static string[] FetchAllTemplateFiles(string NameAndID = "*")
	{
		string searchPattern = NameAndID + ".template";
		if (!Directory.Exists(AGU_CONFIG.HannibalDatabasePath))
		{
			return new string[0];
		}
		return Directory.GetFiles(AGU_CONFIG.HannibalDatabasePath, searchPattern, SearchOption.AllDirectories);
	}

	public static AggregateUnitTemplate LoadFromFile(string NameAndID, bool bool_0 = false)
	{
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		AggregateUnitTemplate aggregateUnitTemplate = null;
		AggregateUnitTemplate result;
		try
		{
			string[] array = FetchAllTemplateFiles(NameAndID);
			if (array.Length == 0)
			{
				if (bool_0)
				{
					DarkMessageBox.ShowError("File not found " + NameAndID, "Error during import");
				}
				result = null;
				goto IL_00df;
			}
			using (FileStream fileStream = File.OpenRead(array[0]))
			{
				aggregateUnitTemplate = (AggregateUnitTemplate)new XmlSerializer(typeof(AggregateUnitTemplate)).Deserialize((Stream)fileStream);
			}
			if (bool_0)
			{
				DarkMessageBox.ShowInformation("Template loaded", "Load from template", DarkDialogButton.Close);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error in AggregateUnitCreator", "Button_LoadTemplate_Click");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			if (bool_0)
			{
				DarkMessageBox.ShowError("Error: " + ex2.Message, "Error during import");
			}
			result = aggregateUnitTemplate;
			ProjectData.ClearProjectError();
			goto IL_00df;
		}
		result = aggregateUnitTemplate;
		goto IL_00df;
		IL_00df:
		return result;
	}

	public AggregateUnitTemplate(AggregateGroundUnit theUnit)
	{
		AssignedRoster = new List<string>();
		AssignedRoster_Detached = new List<string>();
		ActualRoster = new List<string>();
		NameAndID = theUnit.Name;
		Category = (int)theUnit.MobileUnitCategory;
		Echelon = (int)theUnit.Echelon;
		Friction = theUnit._FrictionModifier;
		foreach (KeyValuePair<string, int> item in theUnit.GetAssignedRoster_Readonly())
		{
			AssignedRoster.Add(item.Key + "_" + Conversions.ToString(item.Value));
		}
		foreach (KeyValuePair<string, (ActiveUnit, int)> item2 in theUnit.GetActualRoster_Readonly())
		{
			ActualRoster.Add(item2.Key + "_" + Conversions.ToString(item2.Value.Item2));
		}
	}

	public AggregateGroundUnit ToAggregateUnit(Scenario scen)
	{
		AggregateGroundUnit aggregateGroundUnit = new AggregateGroundUnit(scen);
		aggregateGroundUnit.Name = NameAndID;
		((ActiveUnit)aggregateGroundUnit).set_UnitSide(SetSideOnly: false, scen.GetCurrentSide());
		aggregateGroundUnit.MobileUnitCategory = (IMobileGroundUnit._MobileUnitCategory)Category;
		aggregateGroundUnit.Echelon = (AggregateGroundUnit.GroundEchelonLevel)Echelon;
		aggregateGroundUnit._FrictionModifier = Friction;
		foreach (string item in AssignedRoster)
		{
			string[] array = item.Split(new char[1] { '_' });
			string annexAndDBID = array[0] + "_" + array[1];
			int amount = Conversions.ToInteger(array[2]);
			aggregateGroundUnit.AddOrRemoveAssignedRoster(annexAndDBID, amount);
		}
		foreach (string item2 in ActualRoster)
		{
			string[] array2 = item2.Split(new char[1] { '_' });
			string annexAndDBID2 = array2[0] + "_" + array2[1];
			int amount2 = Conversions.ToInteger(array2[2]);
			aggregateGroundUnit.AddOrRemoveActualRoster(annexAndDBID2, amount2, AutomaticallyAlignAssignedRoster: true);
		}
		foreach (string item3 in AssignedRoster_Detached)
		{
			string[] array3 = item3.Split(new char[1] { '_' });
			string annexAndDBID3 = array3[0] + "_" + array3[1];
			int amount3 = Conversions.ToInteger(array3[2]);
			aggregateGroundUnit.AddOrRemoveAssignedRoster(annexAndDBID3, amount3, DetachedUnit: true);
		}
		return aggregateGroundUnit;
	}

	static AggregateUnitTemplate()
	{
		Class72.smethod_20();
	}
}
