using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using Collections.Pooled;
using Command_Core.DAL;
using Command_Core.SmartAssembly.Attributes;
using DarkUI.Collections;
using MapReduce.NET.CollectionsB;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ObservableCollections;
using ServiceStack.Text;
using ThreadSafeCollections;

namespace Command_Core;

public sealed class Side : ScenarioObject
{
	public class SlugTrail
	{
		public Module_Unit.Unit lastReferenceToTrailedUnit;

		public ConcurrentQueue<ReferencePoint> refPoints;

		public SlugTrail()
		{
			refPoints = new ConcurrentQueue<ReferencePoint>();
		}

		static SlugTrail()
		{
			Class72.smethod_20();
		}
	}

	public delegate void SelectedUnitsChangedEventHandler();

	public delegate void ScoreChangedEventHandler(Side theSide);

	public delegate void MissionsChangedEventHandler(Side theSide);

	public delegate void ContactAddedEventHandler(string theSideID, string ContactActualUnitID);

	public delegate void ContactRemovedEventHandler(string theSideID, string ContactActualUnitID);

	public delegate void BaseContactAddedEventHandler(string theSideID, string ContactActualUnitID);

	public delegate void BaseContactRemovedEventHandler(string theSideID, string ContactActualUnitID);

	private struct Struct14
	{
		public string string_0;

		public string string_1;

		public Struct14(string string_2, string string_3)
		{
			this = default(Struct14);
			string_0 = string_2;
			string_1 = string_3;
		}

		public override int GetHashCode()
		{
			return string_0.GetHashCode() ^ string_1.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (!(obj is Struct14 @struct))
			{
				return false;
			}
			return string.Equals(string_0, @struct.string_0) && string.Equals(string_1, @struct.string_1);
		}

		static Struct14()
		{
			Class72.smethod_20();
		}
	}

	public class _AAR
	{
		public ConcurrentDictionary<int, int> Expenditures;

		public ConcurrentDictionary<int, int> WeaponsLost;

		public ConcurrentDictionary<string, HashSet<string>> Losses;

		public _AAR()
		{
			Losses = new ConcurrentDictionary<string, HashSet<string>>();
			Expenditures = new ConcurrentDictionary<int, int>();
			WeaponsLost = new ConcurrentDictionary<int, int>();
		}

		public void AddToExpenditures(int int_0, int WeaponExpenditure)
		{
			if (Expenditures == null)
			{
				Expenditures = new ConcurrentDictionary<int, int>();
			}
			if (!Expenditures.ContainsKey(int_0))
			{
				Expenditures.TryAdd(int_0, WeaponExpenditure);
				return;
			}
			lock (Expenditures)
			{
				Expenditures[int_0] += WeaponExpenditure;
			}
		}

		public void AddToWeaponsLost(int int_0, int QuantityLost)
		{
			if (WeaponsLost == null)
			{
				WeaponsLost = new ConcurrentDictionary<int, int>();
			}
			if (WeaponsLost.ContainsKey(int_0))
			{
				lock (WeaponsLost)
				{
					WeaponsLost[int_0] += QuantityLost;
					return;
				}
			}
			WeaponsLost.TryAdd(int_0, QuantityLost);
		}

		public static string GetKillsString(ActiveUnit Killer)
		{
			if (Killer == null)
			{
				return "";
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("Kills: ");
			foreach (var kill in Killer.Kills)
			{
				stringBuilder.AppendLine(GetLossUnitName(Killer.ParentScen, kill.Item1) + " (" + kill.Item2.ToString() + ") ");
			}
			return stringBuilder.ToString();
		}

		public static void AddKillToUnit(ActiveUnit Killer, string string_0, int Amount = 1)
		{
			if (Killer != null)
			{
				for (int i = 1; i <= Amount; i++)
				{
					Killer.Kills.Add((string_0, Killer.ParentScen.Time));
				}
			}
		}

		public void AddToLosses(string AnnexAndDBID, string ObjectID, int Amount = 1, bool TreatAsAimpoint = false, ActiveUnit Killer = null)
		{
			if (Information.IsNothing((object)Losses))
			{
				Losses = new ConcurrentDictionary<string, HashSet<string>>();
			}
			string text = AnnexAndDBID;
			string[] array = text.Split(new char[1] { '_' });
			string text2 = array[0];
			string text3 = array[1];
			if (TreatAsAimpoint)
			{
				text = "FacilityAimpoint_" + text3;
			}
			if (Operators.CompareString(text2, "AGU", false) == 0 || string.IsNullOrEmpty(text))
			{
				return;
			}
			AddKillToUnit(Killer, AnnexAndDBID, Amount);
			if (Losses.ContainsKey(text))
			{
				string item = ObjectID;
				int num = 1;
				while (Losses[text].Contains(item))
				{
					item = $"{ObjectID}_{num}";
					num++;
				}
				Losses[text].Add(item);
				int num2 = Amount - 1;
				for (int i = 1; i <= num2; i++)
				{
					string item2 = $"{ObjectID}_{num}";
					Losses[text].Add(item2);
					num++;
				}
			}
			else
			{
				HashSet<string> hashSet = new HashSet<string>();
				int num3 = Amount - 1;
				for (int j = 0; j <= num3; j++)
				{
					string item3 = ((j == 0) ? ObjectID : $"{ObjectID}_{j}");
					hashSet.Add(item3);
				}
				Losses.TryAdd(text, hashSet);
			}
		}

		public void AddToLosses(ScenarioObject theTarget, bool TreatAsAimpoint, ActiveUnit Killer = null)
		{
			int num;
			if (Information.IsNothing((object)Losses))
			{
				Losses = new ConcurrentDictionary<string, HashSet<string>>();
				num = 1;
			}
			else
			{
				num = 1;
			}
			int num2 = num;
			string text = default(string);
			if (theTarget.IsActiveUnit && ((ActiveUnit)theTarget).IsDecoy)
			{
				text += "_[DECOY]";
				num2 = -1;
			}
			if (!theTarget.IsAircraft)
			{
				if (!theTarget.IsShip)
				{
					if (theTarget.IsSubmarine)
					{
						text = "Submarine_" + Conversions.ToString(num2 * ((Submarine)theTarget).DBID);
					}
					else if (theTarget.IsFacility)
					{
						text = "Facility_" + Conversions.ToString(num2 * ((Facility)theTarget).DBID);
					}
					else
					{
						if (theTarget.IsAggregatedUnit)
						{
							return;
						}
						if (theTarget.IsMobileGroundUnit)
						{
							text = "GroundUnit_" + Conversions.ToString(num2 * ((Vehicle)theTarget).DBID);
						}
						else if (TreatAsAimpoint)
						{
							text = "FacilityAimpoint_" + Conversions.ToString(((Mount)theTarget).DBID);
						}
						else if (theTarget.IsSatellite)
						{
							text = "Satellite_" + Conversions.ToString(((Satellite)theTarget).DBID);
						}
						else if (theTarget is UnguidedWeapon && ((UnguidedWeapon)theTarget).IsMine)
						{
							text = "Weapon_" + Conversions.ToString(((UnguidedWeapon)theTarget).DBID());
						}
						else if (theTarget is Cargo)
						{
							text = ((Cargo)theTarget).CargoObjectLossString;
						}
						else if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
					}
				}
				else
				{
					text = "Ship_" + Conversions.ToString(num2 * ((Ship)theTarget).DBID);
				}
			}
			else
			{
				text = "Aircraft_" + Conversions.ToString(num2 * ((Aircraft)theTarget).DBID);
			}
			if (!string.IsNullOrEmpty(text))
			{
				AddKillToUnit(Killer, text);
				if (!Losses.ContainsKey(text))
				{
					HashSet<string> hashSet = new HashSet<string>();
					hashSet.Add(theTarget.ObjectID);
					Losses.TryAdd(text, hashSet);
				}
				else
				{
					Losses[text].Add(theTarget.ObjectID);
				}
			}
		}

		public string ToCSV(Scenario TheScen, string theSeparator)
		{
			string result = default(string);
			try
			{
				string text = "";
				string text2 = "";
				if (Losses == null)
				{
					Losses = new ConcurrentDictionary<string, HashSet<string>>();
				}
				foreach (KeyValuePair<string, HashSet<string>> loss in Losses)
				{
					text2 = "Loss".Replace(theSeparator, "") + theSeparator;
					text2 = text2 + loss.Key.ToString().Replace(theSeparator, "") + theSeparator;
					text2 = text2 + loss.Value.ToString().Replace(theSeparator, "") + theSeparator;
					text2 = text2 + GetLossUnitName(TheScen, loss).Replace(theSeparator, "") + theSeparator;
					text = ((Operators.CompareString(text, "", false) == 0) ? text2 : (text + Environment.NewLine + text2));
				}
				if (Expenditures == null)
				{
					Expenditures = new ConcurrentDictionary<int, int>();
				}
				foreach (KeyValuePair<int, int> expenditure in Expenditures)
				{
					text2 = "Expenditure".Replace(theSeparator, "") + theSeparator;
					text2 = text2 + expenditure.Key.ToString().Replace(theSeparator, "") + theSeparator;
					text2 = text2 + expenditure.Value.ToString().Replace(theSeparator, "") + theSeparator;
					text2 = text2 + GetWeaponItemName(TheScen, expenditure).Replace(theSeparator, "") + theSeparator;
					text = ((Operators.CompareString(text, "", false) != 0) ? (text + Environment.NewLine + text2) : text2);
				}
				if (WeaponsLost == null)
				{
					WeaponsLost = new ConcurrentDictionary<int, int>();
				}
				foreach (KeyValuePair<int, int> item in WeaponsLost)
				{
					text2 = "Weapon Loss".Replace(theSeparator, "") + theSeparator;
					text2 = text2 + item.Key.ToString().Replace(theSeparator, "") + theSeparator;
					text2 = text2 + item.Value.ToString().Replace(theSeparator, "") + theSeparator;
					text2 = text2 + GetWeaponItemName(TheScen, item).Replace(theSeparator, "") + theSeparator;
					text = ((Operators.CompareString(text, "", false) == 0) ? text2 : (text + Environment.NewLine + text2));
				}
				result = text;
				return result;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 987651321563", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			return result;
		}

		public void ToXML(ref XmlWriter theWriter, Scenario TheScen = null)
		{
			if (TheScen != null)
			{
				try
				{
					theWriter.WriteStartElement("AAR");
					if (Losses == null)
					{
						Losses = new ConcurrentDictionary<string, HashSet<string>>();
					}
					theWriter.WriteStartElement("Losses");
					foreach (KeyValuePair<string, HashSet<string>> loss in Losses)
					{
						theWriter.WriteStartElement("Unit");
						theWriter.WriteElementString("ID", loss.Key.ToString());
						theWriter.WriteElementString("Quantity", loss.Value.ToString());
						theWriter.WriteElementString("Name", GetLossUnitName(TheScen, loss) + "\r\n");
						theWriter.WriteEndElement();
					}
					theWriter.WriteEndElement();
					if (Expenditures == null)
					{
						Expenditures = new ConcurrentDictionary<int, int>();
					}
					theWriter.WriteStartElement("Expenditures");
					foreach (KeyValuePair<int, int> expenditure in Expenditures)
					{
						theWriter.WriteStartElement("Weapon");
						theWriter.WriteElementString("ID", expenditure.Key.ToString());
						theWriter.WriteElementString("Quantity", expenditure.Value.ToString());
						theWriter.WriteElementString("Name", GetWeaponItemName(TheScen, expenditure) + "\r\n");
						theWriter.WriteEndElement();
					}
					theWriter.WriteEndElement();
					if (WeaponsLost == null)
					{
						WeaponsLost = new ConcurrentDictionary<int, int>();
					}
					theWriter.WriteStartElement("WeaponsLost");
					foreach (KeyValuePair<int, int> item in WeaponsLost)
					{
						theWriter.WriteStartElement("Weapon");
						theWriter.WriteElementString("ID", item.Key.ToString());
						theWriter.WriteElementString("Quantity", item.Value.ToString());
						theWriter.WriteElementString("Name", GetWeaponItemName(TheScen, item) + "\r\n");
						theWriter.WriteEndElement();
					}
					theWriter.WriteEndElement();
					theWriter.WriteEndElement();
					return;
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error at 987651321564", "");
					GameGeneral.WriteExceptionsToLog(ex2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
					return;
				}
			}
			try
			{
				theWriter.WriteStartElement("AAR");
				if (Losses == null)
				{
					Losses = new ConcurrentDictionary<string, HashSet<string>>();
				}
				if (Losses.Count > 0)
				{
					theWriter.WriteStartElement("Losses");
					IEnumerator<KeyValuePair<string, HashSet<string>>> enumerator4 = Losses.GetEnumerator();
					try
					{
						while (enumerator4.MoveNext())
						{
							KeyValuePair<string, HashSet<string>> current4 = enumerator4.Current;
							if (current4.Value.Count > 0)
							{
								theWriter.WriteElementString(current4.Key.ToString(), string.Join("_", current4.Value));
							}
						}
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						ProjectData.ClearProjectError();
					}
					theWriter.WriteEndElement();
				}
				if (Expenditures == null)
				{
					Expenditures = new ConcurrentDictionary<int, int>();
				}
				if (Expenditures.Count > 0)
				{
					theWriter.WriteStartElement("Expenditures");
					IEnumerator<KeyValuePair<int, int>> enumerator5 = Expenditures.GetEnumerator();
					try
					{
						while (enumerator5.MoveNext())
						{
							KeyValuePair<int, int> current5 = enumerator5.Current;
							theWriter.WriteElementString("Weapon_" + current5.Key, current5.Value.ToString());
						}
					}
					catch (Exception projectError2)
					{
						ProjectData.SetProjectError(projectError2);
						ProjectData.ClearProjectError();
					}
					theWriter.WriteEndElement();
				}
				if (WeaponsLost == null)
				{
					WeaponsLost = new ConcurrentDictionary<int, int>();
				}
				if (WeaponsLost.Count > 0)
				{
					theWriter.WriteStartElement("WeaponsLost");
					IEnumerator<KeyValuePair<int, int>> enumerator6 = WeaponsLost.GetEnumerator();
					try
					{
						KeyValuePair<int, int> current6 = enumerator6.Current;
						theWriter.WriteElementString("Weapon_" + current6.Key, current6.Value.ToString());
					}
					catch (Exception projectError3)
					{
						ProjectData.SetProjectError(projectError3);
						ProjectData.ClearProjectError();
					}
					theWriter.WriteEndElement();
				}
				theWriter.WriteEndElement();
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				ex4?.Data.Add("Error at 101068", "");
				GameGeneral.WriteExceptionsToLog(ex4);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}

		public static _AAR FromXML(ref XmlNode theNode)
		{
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0028: Expected O, but got Unknown
			//IL_0220: Unknown result type (might be due to invalid IL or missing references)
			//IL_0227: Expected O, but got Unknown
			//IL_0070: Unknown result type (might be due to invalid IL or missing references)
			//IL_0077: Expected O, but got Unknown
			//IL_0151: Unknown result type (might be due to invalid IL or missing references)
			//IL_0158: Expected O, but got Unknown
			_AAR aAR = new _AAR();
			_AAR result;
			try
			{
				foreach (XmlNode childNode in theNode.ChildNodes)
				{
					XmlNode val = childNode;
					switch (val.Name)
					{
					case "Expenditures":
						foreach (XmlNode childNode2 in val.ChildNodes)
						{
							XmlNode val4 = childNode2;
							string[] array2 = val4.Name.Split(new char[1] { '_' });
							int key2 = Conversions.ToInteger(array2[1]);
							int num5 = Conversions.ToInteger(val4.InnerText);
							if (!aAR.Expenditures.ContainsKey(key2))
							{
								aAR.Expenditures.TryAdd(Conversions.ToInteger(array2[1]), Conversions.ToInteger(val4.InnerText));
							}
							else
							{
								aAR.Expenditures[key2] += num5;
							}
						}
						break;
					case "WeaponsLost":
						foreach (XmlNode childNode3 in val.ChildNodes)
						{
							XmlNode val3 = childNode3;
							string[] array = val3.Name.Split(new char[1] { '_' });
							int key = Conversions.ToInteger(array[1]);
							int num4 = Conversions.ToInteger(val3.InnerText);
							if (aAR.WeaponsLost.ContainsKey(key))
							{
								aAR.WeaponsLost[key] += num4;
							}
							else
							{
								aAR.WeaponsLost.TryAdd(Conversions.ToInteger(array[1]), Conversions.ToInteger(val3.InnerText));
							}
						}
						break;
					case "Losses":
						foreach (XmlNode childNode4 in val.ChildNodes)
						{
							XmlNode val2 = childNode4;
							if (Operators.CompareString(val2.Name.ToString().Split(new char[1] { '_' })[0], "Custom", false) != 0)
							{
								if (!Versioned.IsNumeric((object)val2.InnerText))
								{
									List<string> list = val2.InnerText.Split(new char[1] { '_' }).ToList();
									int count = list.Count;
									HashSet<string> hashSet = new HashSet<string>();
									int num = count - 1;
									for (int i = 0; i <= num; i++)
									{
										hashSet.Add(list[i]);
									}
									aAR.Losses.TryAdd(val2.Name, hashSet);
								}
								else
								{
									int num2 = Conversions.ToInteger(val2.InnerText);
									HashSet<string> hashSet2 = new HashSet<string>();
									int num3 = num2;
									for (int j = 1; j <= num3; j++)
									{
										hashSet2.Add(Guid.NewGuid().ToString());
									}
									aAR.Losses.TryAdd(val2.Name, hashSet2);
								}
							}
							else if (val2.InnerText.Length != 0 && Operators.CompareString(val2.InnerText, "0", false) != 0)
							{
								HashSet<string> value = new HashSet<string> { val2.InnerText };
								aAR.Losses.TryAdd(val2.Name, value);
							}
						}
						break;
					}
				}
				result = aAR;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 101069", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = new _AAR();
				ProjectData.ClearProjectError();
			}
			return result;
		}

		internal string GetWeaponItemName(Scenario theScen, KeyValuePair<int, int> theKVP)
		{
			DataRow[] array = theScen.Cache_Weapons_DT.Select("ID=" + Conversions.ToString(theKVP.Key));
			if (array.Count() > 0)
			{
				return Misc.RemoveHiddenString(array[0]["Name"].ToString());
			}
			return string.Empty;
		}

		internal static string GetLossUnitName(Scenario theScen, string ANNEXDBID)
		{
			string[] array = ANNEXDBID.Split(new char[1] { '_' });
			string result = "";
			switch (array[0].ToString())
			{
			case "Aircraft":
				result = Misc.RemoveHiddenString(theScen.Cache_Aircraft_DT.Select("ID=" + array[1])[0]["Name"].ToString());
				break;
			case "FacilityAimpointCargo":
			case "FacilityAimpoint":
				result = ((Operators.CompareString(array[1], "0", false) != 0) ? Misc.RemoveHiddenString(DBFunctions.GetMountName(Conversions.ToInteger(array[1]), ref theScen)) : "Non-identifiable land aimpoint - sorry!");
				break;
			case "Weapon":
				result = Misc.RemoveHiddenString(theScen.Cache_Weapons_DT.Select("ID=" + array[1])[0]["Name"].ToString());
				break;
			case "Submarine":
				result = Misc.RemoveHiddenString(theScen.Cache_Subs_DT.Select("ID=" + array[1])[0]["Name"].ToString());
				break;
			case "Ship":
				result = Misc.RemoveHiddenString(theScen.Cache_Ships_DT.Select("ID=" + array[1])[0]["Name"].ToString());
				break;
			case "GroundUnit":
			case "Vehicle":
				result = Misc.RemoveHiddenString(theScen.Cache_GroundUnits_DT.Select("ID=" + array[1])[0]["Name"].ToString());
				break;
			case "Facility":
				result = Misc.RemoveHiddenString(theScen.Cache_Facilities_DT.Select("ID=" + array[1])[0]["Name"].ToString());
				break;
			case "Custom":
				result = array[1];
				break;
			}
			return result;
		}

		internal static string GetLossUnitName(Scenario theScen, KeyValuePair<string, HashSet<string>> theKVP)
		{
			return GetLossUnitName(theScen, theKVP.Key.ToString());
		}

		static _AAR()
		{
			Class72.smethod_20();
		}
	}

	[DoNotObfuscate]
	public enum AwarenessLevel_Enum
	{
		Blind = -1,
		Normal,
		AutoSideID,
		AutoSideAndUnitID,
		Omniscient
	}

	[CompilerGenerated]
	internal sealed class _Closure$__184-0
	{
		public Scenario $VB$Local_theScen;

		public float $VB$Local_elapsedTime;

		public _Closure$__184-0(_Closure$__184-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theScen = arg0.$VB$Local_theScen;
				$VB$Local_elapsedTime = arg0.$VB$Local_elapsedTime;
			}
		}

		[SpecialName]
		internal void _Lambda$__0(FiringProposal firingProposal_0)
		{
			if (!firingProposal_0.FiringUnit.IsAircraft)
			{
				if (Needs_To_Recalculate_Weapon_ETA(firingProposal_0))
				{
					firingProposal_0.ETA = ((ActiveUnit)firingProposal_0.FiringUnit).Weaponry.RetrieveWeaponETA(firingProposal_0.Target, firingProposal_0.get_ReferenceWeapon($VB$Local_theScen));
					firingProposal_0.Distance = Module_Unit.RangeToUnit_Slant(firingProposal_0.FiringUnit, firingProposal_0.Target);
				}
				else
				{
					firingProposal_0.ETA = firingProposal_0.ETA.AddSeconds($VB$Local_elapsedTime);
				}
			}
		}

		static _Closure$__184-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__261-0
	{
		public Weapon $VB$Local_theW;

		public _Closure$__261-0(_Closure$__261-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theW = arg0.$VB$Local_theW;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(WeaponSalvo.Shooter x)
		{
			return Operators.CompareString(x.ShooterObjectID, $VB$Local_theW.FiringParent.ObjectID, false) == 0;
		}

		[SpecialName]
		internal bool _Lambda$__1(WeaponSalvo.Shooter x)
		{
			return Operators.CompareString(x.ShooterObjectID, $VB$Local_theW.ObjectID, false) == 0;
		}

		static _Closure$__261-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__278-0
	{
		public string $VB$Local_sideHash;

		public _Closure$__278-0(_Closure$__278-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_sideHash = arg0.$VB$Local_sideHash;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(Side F)
		{
			return Operators.CompareString(F.ObjectID, $VB$Local_sideHash, false) == 0;
		}

		static _Closure$__278-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__301-0
	{
		public string $VB$Local_theWeaponObjectID;

		public Func<UnguidedWeapon, bool> $I0;

		public _Closure$__301-0(_Closure$__301-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theWeaponObjectID = arg0.$VB$Local_theWeaponObjectID;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(UnguidedWeapon theW)
		{
			return Operators.CompareString(theW.ObjectID, $VB$Local_theWeaponObjectID, false) == 0;
		}

		static _Closure$__301-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__326-0
	{
		public ActiveUnit $VB$Local_senderUnit;

		public Func<TransmittedContactData, bool> $I1;

		public _Closure$__326-0(_Closure$__326-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_senderUnit = arg0.$VB$Local_senderUnit;
			}
		}

		[SpecialName]
		internal bool _Lambda$__1(TransmittedContactData x)
		{
			return Operators.CompareString(x.TheTransmittingUnit.ObjectID, $VB$Local_senderUnit.ObjectID, false) == 0;
		}

		static _Closure$__326-0()
		{
			Class72.smethod_20();
		}
	}

	private string string_1;

	private byte byte_0;

	private FastDictionary<Side, Misc.PostureStance> fastDictionary_0;

	private Dictionary<string, Misc.PostureStance> dictionary_0;

	public Color? AssignedFixedColor;

	internal int IndexAtSidesList;

	public bool IsHumanControlled;

	public bool IsPlayerControlled;

	public SideEnablers Enablers;

	internal List<ActiveUnit> PotentialContacts;

	internal List<ActiveUnit> PotentialBaseContacts;

	private string string_2;

	private string string_3;

	private List<Module_Unit.Unit> list_0;

	private GeoPoint geoPoint_0;

	public double CameraAlt;

	private List<Mission> list_1;

	private List<ScenarioGoal> list_2;

	private int int_1;

	public int? Scoring_Disaster;

	public int? Scoring_Triumph;

	public AwarenessLevel_Enum AwarenessLevel;

	private GlobalVariables.ProficiencyLevel? nullable_0;

	public Dictionary<string, SpecialAction> SpecialActions;

	[AccessedThroughProperty("_Contacts")]
	[CompilerGenerated]
	private ObservableCollections.ObservableDictionary<string, Contact> observableDictionary_0;

	[CompilerGenerated]
	[AccessedThroughProperty("_BaseContacts")]
	private System.Collections.ObjectModel.ObservableDictionary<string, Contact> observableDictionary_1;

	public HashSet<string> Contacts_NonAU;

	internal int ContactAutoIncrement;

	internal int BaseContactAutoIncrement;

	internal TDictionary<string, Contact> NewContactsQueue_Forced;

	internal TDictionary<string, Contact> NewContactsQueue;

	internal TDictionary<string, Contact> NewBaseContactsQueue;

	internal TDictionary<string, Contact> DroppedContactsQueue;

	internal TDictionary<string, Contact> DroppedBaseContactsQueue;

	private bool bool_0;

	public PooledList<ActiveUnit> Units;

	internal HashSet<Side> FriendlySidesThisPulse;

	public List<ActiveUnit> _AutodetectableUnitsThisPulse;

	[CompilerGenerated]
	[AccessedThroughProperty("PerUnitSlugtrail")]
	private Dictionary<string, SlugTrail> dictionary_1;

	[AccessedThroughProperty("RefPoints")]
	[CompilerGenerated]
	private ObservableList<ReferencePoint> observableList_0;

	[AccessedThroughProperty("RefPointsTag_raw")]
	[CompilerGenerated]
	private Dictionary<string, ReferencePointFlag> dictionary_2;

	public Dictionary<ReferencePointFlag, Dictionary<ReferencePoint, ReferencePoint>> RefPointsTag;

	public int TagsCumulativeCount;

	private List<ActiveUnit> list_3;

	public Doctrine Doctrine;

	public _AAR AAR;

	public List<ExclusionZone> ExclusionZones;

	public List<NoNavZone> NoNavZones;

	public CustomEnvironmentZone[] CustomEnvironmentZones;

	public List<Zone> StandardZones;

	public bool AssignsCollectiveResponsibility;

	public bool CanAutoTrackCivs;

	public Dictionary<int, QuickJumpSlot> QuickJumpSlots;

	[AccessedThroughProperty("WeaponSalvos")]
	[CompilerGenerated]
	private ObservableList<WeaponSalvo> observableList_1;

	internal ConcurrentDictionary<string, FiringProposal> FiringProposals;

	public Scenario ParentScen;

	public List<string> ScoringLog;

	private int int_2;

	public TDictionary<string, Misc.PostureStance> Cache_ContactStancesOnThisPulse;

	internal TDictionary<string, int> Cache_ContactIncomingWeapons;

	private TDictionary<Contact, List<WeaponSalvo>> tdictionary_0;

	internal TDictionary<string, bool> Cache_ContactsInsideNoNavZones;

	internal TDictionary<(Contact, Patrol), bool> Cache_ContactsInsidePatrolAreas;

	internal TDictionary<(Contact, Patrol), bool> Cache_ContactsInsideProsecutionAreas;

	internal TDictionary<Mission, List<ActiveUnit>> Cache_UnitsAssignedToMissionOrPackage;

	private MapProfile mapProfile_0;

	private List<ActiveUnit> list_4;

	private List<ActiveUnit> list_5;

	private PooledList<Contact> pooledList_0;

	private List<Contact> list_6;

	private List<ActiveUnit> list_7;

	private ActiveUnit[] activeUnit_0;

	private HashSet<string> hashSet_0;

	private HashSet<string> hashSet_1;

	internal Queue<(Contact, ActiveUnit, List<Sensor>, float, ActiveUnit_Sensory.SpecialDetectionMode, DateTime, List<Geopoint_Struct>)> SpecialDetections;

	[CompilerGenerated]
	private SelectedUnitsChangedEventHandler selectedUnitsChangedEventHandler_0;

	[CompilerGenerated]
	private static ScoreChangedEventHandler scoreChangedEventHandler_0;

	[CompilerGenerated]
	private static MissionsChangedEventHandler missionsChangedEventHandler_0;

	[CompilerGenerated]
	private static ContactAddedEventHandler contactAddedEventHandler_0;

	[CompilerGenerated]
	private static ContactRemovedEventHandler contactRemovedEventHandler_0;

	[CompilerGenerated]
	private static BaseContactAddedEventHandler baseContactAddedEventHandler_0;

	[CompilerGenerated]
	private static BaseContactRemovedEventHandler baseContactRemovedEventHandler_0;

	public List<AggregateGroundUnit_Frontline> AGU_Frontline;

	private List<Module_Unit.Unit> list_8;

	public EmconLevel EmconAlertness;

	public string HQ_ID;

	public System.Collections.ObjectModel.ObservableDictionary<string, CommNetwork> CommNetworks;

	public List<CommNetwork> SelectedNetworks;

	public Dictionary<string, Color> NetworkColorMap;

	public ConcurrentDictionary<string, bool> IsUnitInContactWithTheLeaderInthisPulse;

	public ObservableCollection<string> NetworkLog;

	[CompilerGenerated]
	private NetworkRuleRegistry networkRuleRegistry_0;

	public bool IsNature;

	public List<Chalk> Chalks;

	private List<Chalk> list_9;

	private Operation operation_0;

	public List<LandingPlan> LandingPlans;

	public bool DisableMultiDomainTOT;

	public HashSet<string> ContactsJustSharedWithMe;

	[ThreadStatic]
	private static StringBuilder stringBuilder_0;

	private ReadOnlyCollection<Mission> readOnlyCollection_0;

	private LockObject lockObject_0;

	private Misc.PostureStance[] postureStance_0;

	public LockObject AddShooter;

	internal ConcurrentDictionary<DateTime, SalvoMaxDistanceToTarget> SalvoMaxDistanceToTargetList;

	public TList<TransmissionWithFeedback> FeedbackList;

	public TList<TransmissionWithFeedback> MinuteFeedbackList;

	public TDictionary<string, List<Transmission>> TransmissionQueue;

	public TDictionary<string, TList<Transmission>> MinuteTransmissionQueue;

	private ConcurrentQueue<TransmittedContactData> concurrentQueue_0;

	public virtual Dictionary<string, SlugTrail> PerUnitSlugtrail
	{
		[CompilerGenerated]
		get
		{
			return dictionary_1;
		}
		[CompilerGenerated]
		set
		{
			dictionary_1 = value;
		}
	}

	public virtual ObservableList<ReferencePoint> RefPoints
	{
		[CompilerGenerated]
		get
		{
			return observableList_0;
		}
		[CompilerGenerated]
		set
		{
			EventHandler<ObservableListModified<ReferencePoint>> value2 = method_3;
			ObservableList<ReferencePoint> observableList = observableList_0;
			if (observableList != null)
			{
				observableList.ItemsRemoved -= value2;
			}
			observableList_0 = value;
			observableList = observableList_0;
			if (observableList != null)
			{
				observableList.ItemsRemoved += value2;
			}
		}
	}

	public virtual Dictionary<string, ReferencePointFlag> RefPointsTag_raw
	{
		[CompilerGenerated]
		get
		{
			return dictionary_2;
		}
		[CompilerGenerated]
		set
		{
			dictionary_2 = value;
		}
	}

	public virtual ObservableList<WeaponSalvo> WeaponSalvos
	{
		[CompilerGenerated]
		get
		{
			return observableList_1;
		}
		[CompilerGenerated]
		set
		{
			EventHandler<ObservableListModified<WeaponSalvo>> value2 = method_4;
			ObservableList<WeaponSalvo> observableList = observableList_1;
			if (observableList != null)
			{
				observableList.ItemsAdded -= value2;
			}
			observableList_1 = value;
			observableList = observableList_1;
			if (observableList != null)
			{
				observableList.ItemsAdded += value2;
			}
		}
	}

	public NetworkRuleRegistry NetworkRuleRegistry
	{
		[CompilerGenerated]
		get
		{
			return networkRuleRegistry_0;
		}
		[CompilerGenerated]
		set
		{
			networkRuleRegistry_0 = value;
		}
	}

	public Operation Operation
	{
		get
		{
			if (Information.IsNothing((object)operation_0))
			{
				operation_0 = new Operation(this);
			}
			return operation_0;
		}
		set
		{
			operation_0 = value;
		}
	}

	public ReadOnlyCollection<KeyValuePair<Side, Misc.PostureStance>> Postures_ReadOnly
	{
		get
		{
			List<KeyValuePair<Side, Misc.PostureStance>> list = new List<KeyValuePair<Side, Misc.PostureStance>>(fastDictionary_0.Count);
			FastDictionary<Side, Misc.PostureStance>.Enumerator enumerator = fastDictionary_0.GetEnumerator();
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.Key != null)
				{
					list.Add(new KeyValuePair<Side, Misc.PostureStance>(enumerator.Current.Key, enumerator.Current.Value));
				}
			}
			return list.AsReadOnly();
		}
	}

	public ObservableCollections.ObservableDictionary<string, Contact> Contacts => vmethod_0();

	public System.Collections.ObjectModel.ObservableDictionary<string, Contact> BaseContacts => vmethod_2();

	public string Briefing
	{
		get
		{
			if (string.IsNullOrEmpty(string_3))
			{
				return string_2;
			}
			if (!string.IsNullOrEmpty(string_3))
			{
				return Crypto.DecryptStringAES(string_3, "DaltonTrumbo");
			}
			return string.Empty;
		}
		set
		{
			string_2 = string.Empty;
			if (!string.IsNullOrEmpty(value))
			{
				string_3 = Crypto.EncryptStringAES(value, "DaltonTrumbo");
			}
			else
			{
				string_3 = value;
			}
		}
	}

	public int TotalScore
	{
		get
		{
			return int_1;
		}
		set
		{
			try
			{
				bool num = value != int_1;
				int num2 = int_1;
				int_1 = value;
				if (!num)
				{
					return;
				}
				ScoringLog.Add(theScen.Time.ToString("MM/dd/yyyy HH:mm") + ": Score changed from " + Conversions.ToString(num2) + " to " + Conversions.ToString(value) + ". Reason: " + ReasonForChange);
				List<EventTrigger> list = new List<EventTrigger>();
				foreach (EventTrigger value2 in theScen.EventTriggers.Values)
				{
					if (value2.Type == EventTrigger.EventTriggerType.Points && ((EventTrigger_Points)value2).get_IsFulfilled(this, num2, value))
					{
						list.Add(value2);
					}
				}
				theScen.FireEvents(list);
				scoreChangedEventHandler_0?.Invoke(this);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 101058", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	public GlobalVariables.ProficiencyLevel Proficiency
	{
		get
		{
			if (!nullable_0.HasValue)
			{
				nullable_0 = GlobalVariables.ProficiencyLevel.Regular;
			}
			return nullable_0.Value;
		}
		set
		{
			nullable_0 = value;
		}
	}

	public GeoPoint MapCenter
	{
		get
		{
			if (geoPoint_0 == null)
			{
				if (Units.Count > 0)
				{
					geoPoint_0 = new GeoPoint(Units[0].get_Longitude((GlobalVariables.BooleanObject)null), Units[0].get_Latitude((GlobalVariables.BooleanObject)null));
				}
				else
				{
					geoPoint_0 = new GeoPoint(0.0, 0.0);
				}
			}
			return geoPoint_0;
		}
		set
		{
			geoPoint_0 = value;
		}
	}

	public int Scoring_MajorDefeat
	{
		get
		{
			int result;
			if (!Scoring_Disaster.HasValue)
			{
				result = 0;
			}
			else
			{
				if (Scoring_Triumph.HasValue)
				{
					return (int)Math.Round(((double)Scoring_Average - (double?)((Scoring_Triumph - Scoring_Average) * 2) / 3.0).Value);
				}
				result = 0;
			}
			return result;
		}
	}

	public int Scoring_MinorDefeat
	{
		get
		{
			int result;
			if (Scoring_Disaster.HasValue)
			{
				if (Scoring_Triumph.HasValue)
				{
					return (int)Math.Round(((double)Scoring_Average - (double?)((Scoring_Triumph - Scoring_Average) * 1) / 3.0).Value);
				}
				result = 0;
			}
			else
			{
				result = 0;
			}
			return result;
		}
	}

	public int Scoring_Average
	{
		get
		{
			int result;
			if (!Scoring_Disaster.HasValue)
			{
				result = 0;
			}
			else
			{
				if (Scoring_Triumph.HasValue)
				{
					return (int)Math.Round(((double?)Scoring_Triumph - (double?)(Scoring_Triumph - Scoring_Disaster) / 2.0).Value);
				}
				result = 0;
			}
			return result;
		}
	}

	public int Scoring_MinorVictory
	{
		get
		{
			int result;
			if (!Scoring_Disaster.HasValue)
			{
				result = 0;
			}
			else
			{
				if (Scoring_Triumph.HasValue)
				{
					return (int)Math.Round(((double)Scoring_Average + (double?)((Scoring_Triumph - Scoring_Average) * 1) / 3.0).Value);
				}
				result = 0;
			}
			return result;
		}
	}

	public int Scoring_MajorVictory
	{
		get
		{
			int result;
			if (Scoring_Disaster.HasValue)
			{
				if (Scoring_Triumph.HasValue)
				{
					return (int)Math.Round(((double)Scoring_Average + (double?)((Scoring_Triumph - Scoring_Average) * 2) / 3.0).Value);
				}
				result = 0;
			}
			else
			{
				result = 0;
			}
			return result;
		}
	}

	public ReadOnlyCollection<Mission> Missions => list_1.AsReadOnly();

	public ReadOnlyCollection<Mission> MissionsTotal
	{
		get
		{
			ReadOnlyCollection<Mission> result;
			try
			{
				if (Information.IsNothing((object)readOnlyCollection_0))
				{
					List<Mission> list = new List<Mission>();
					list.AddRange(list_1);
					try
					{
						foreach (Group group in theScen.Groups)
						{
							if (group.get_UnitSide(SetSideOnly: false) == this)
							{
								list.AddRange(group.Patrols);
							}
						}
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						ex2?.Data.Add("Error at 200063", ex2.Message);
						GameGeneral.WriteExceptionsToLog(ex2);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
					readOnlyCollection_0 = list.AsReadOnly();
				}
				result = readOnlyCollection_0;
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				ex4?.Data.Add("Error at 101059", "");
				GameGeneral.WriteExceptionsToLog(ex4);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = null;
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public List<ActiveUnit> UnitsEngagedInOECM
	{
		get
		{
			List<ActiveUnit> result;
			try
			{
				if (list_3 == null || Refresh)
				{
					PooledList<ActiveUnit> pooledList = new PooledList<ActiveUnit>();
					PooledList<ActiveUnit> pooledList2 = PooledExtensions.ToPooledList(Units);
					ActiveUnit[] array = pooledList2.InternalArray();
					int num = pooledList2.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						ActiveUnit activeUnit = array[i];
						if (activeUnit != null && !activeUnit.IsGroup && activeUnit.IsOperating() && ActiveUnit_Sensory.smethod_0(activeUnit))
						{
							pooledList.Add(activeUnit);
						}
					}
					list_3 = new List<ActiveUnit>(pooledList);
					pooledList.Dispose();
					pooledList2.Dispose();
				}
				result = list_3;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 101060", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = list_3;
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public MapProfile SideMapProfile
	{
		get
		{
			if (mapProfile_0 == null)
			{
				mapProfile_0 = MapProfile.GetDefaultProfile();
			}
			return mapProfile_0;
		}
		set
		{
			mapProfile_0 = value;
		}
	}

	public List<Module_Unit.Unit> KnownActiveNuclearWeapons
	{
		set
		{
			list_8 = value;
		}
	}

	public List<Module_Unit.Unit> KnownActiveNuclearWeapons
	{
		get
		{
			if (list_8 == null)
			{
				list_8 = new List<Module_Unit.Unit>();
				List<ActiveUnit> list = new List<ActiveUnit>();
				foreach (KeyValuePair<string, ActiveUnit> activeUnit in scen.ActiveUnits)
				{
					list.Add(activeUnit.Value);
				}
				foreach (ActiveUnit item in list)
				{
					if (item != null && item.get_UnitSide(SetSideOnly: false) == this && item.IsWeapon && ((Weapon)item).IsNuke.Value)
					{
						list_8.Add(item);
					}
				}
				List<UnguidedWeapon> list2 = new List<UnguidedWeapon>();
				foreach (KeyValuePair<string, UnguidedWeapon> unguidedWeapon in scen.UnguidedWeapons)
				{
					list2.Add(unguidedWeapon.Value);
				}
				foreach (UnguidedWeapon item2 in list2)
				{
					if (item2 != null && item2.get_UnitSide(SetSideOnly: false) == this && item2.ReferenceWeapon.IsNuke.Value && !item2.IsMine)
					{
						list_8.Add(item2);
					}
				}
				List<Contact> list3 = new List<Contact>(Contacts.Values);
				foreach (Contact item3 in list3)
				{
					if (item3.IsWeaponContact && item3.IDStatus >= Contact_Base.IdentificationStatus.KnownClass && item3.ActualUnit != null && item3.ActualUnit.IsWeapon && ((Weapon)item3.ActualUnit).IsNuke.Value)
					{
						list_8.Add(item3);
					}
				}
				List<Explosion> list4 = new List<Explosion>(scen.Explosions);
				foreach (Explosion item4 in list4)
				{
					if (item4.ExplosiveType == Warhead.WarheadExplosivesType.Nuclear)
					{
						list_8.Add(item4);
					}
				}
			}
			return list_8;
		}
	}

	public Contact[] Contacts_List_As_Array_Threadsafe
	{
		get
		{
			lock (lockObject_0)
			{
				return Contacts_List.InternalArray();
			}
		}
	}

	public PooledList<Contact> Contacts_List
	{
		get
		{
			if (pooledList_0 == null && Contacts != null)
			{
				lock (lockObject_0)
				{
					pooledList_0 = new PooledList<Contact>(Contacts.Values);
				}
			}
			return pooledList_0;
		}
		set
		{
			pooledList_0 = value;
		}
	}

	public List<Contact> BaseContacts_List
	{
		get
		{
			if (BaseContacts == null)
			{
				return null;
			}
			if (list_6 != null)
			{
				if (list_6.Count != BaseContacts.Count)
				{
					list_6 = new List<Contact>();
					list_6.AddRange(BaseContacts.Values);
				}
				return list_6;
			}
			list_6 = new List<Contact>();
			list_6.AddRange(BaseContacts.Values);
			return list_6;
		}
		set
		{
			list_6 = value;
		}
	}

	public List<ActiveUnit> FriendlyUnits_OperativeOnly
	{
		get
		{
			List<ActiveUnit> list = this.get_FriendlyUnits(theScen, IncludeWeapons);
			List<ActiveUnit> list2 = new List<ActiveUnit>();
			foreach (ActiveUnit item in list)
			{
				if (item != null && item.IsOperating())
				{
					list2.Add(item);
				}
			}
			return list2;
		}
	}

	public List<ActiveUnit> FriendlyUnits
	{
		get
		{
			List<ActiveUnit> result;
			try
			{
				if (list_7 == null)
				{
					List<ActiveUnit> list = new List<ActiveUnit>();
					Side[] sides_ReadOnly = theScen.Sides_ReadOnly;
					foreach (Side side in sides_ReadOnly)
					{
						if (side != this && this.get_ConsidersThisSideToBe(side, (Scenario)null) != Misc.PostureStance.Friendly)
						{
							continue;
						}
						if (!IncludeWeapons)
						{
							list.AddRange(side.Units.Where([SpecialName] (ActiveUnit theAU) => !theAU.IsWeapon));
						}
						else
						{
							list.AddRange(side.Units);
						}
					}
					list_7 = list;
				}
				result = list_7;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 101061", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = list_7;
				ProjectData.ClearProjectError();
			}
			return result;
		}
		set
		{
			list_7 = value;
		}
	}

	public new string Name
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
		}
	}

	public byte DIS_ForceId => byte_0;

	public bool IsAIOnly
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public (PooledList<LoggedMessage>, PooledList<LoggedMessage>) MessageLog_Hybrid_Separated
	{
		get
		{
			(PooledList<LoggedMessage>, PooledList<LoggedMessage>) result;
			if (theScen != null && theScen.MessageLog != null)
			{
				int count = theScen.MessageLog.Count;
				PooledList<LoggedMessage> pooledList = new PooledList<LoggedMessage>(count);
				PooledList<LoggedMessage> pooledList2 = new PooledList<LoggedMessage>(count);
				try
				{
					int num = count - 1;
					for (int i = 0; i <= num; i++)
					{
						try
						{
							LoggedMessage loggedMessage = theScen.MessageLog[i];
							if (loggedMessage != null)
							{
								if (loggedMessage.Side == null)
								{
									pooledList.Add(loggedMessage);
								}
								else if (loggedMessage.Side == this)
								{
									pooledList2.Add(loggedMessage);
								}
							}
						}
						catch (Exception projectError)
						{
							ProjectData.SetProjectError(projectError);
							ProjectData.ClearProjectError();
						}
					}
					return (pooledList, pooledList2);
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error at 2000645", ex2.Message);
					GameGeneral.WriteExceptionsToLog(ex2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					result = (pooledList, pooledList2);
					ProjectData.ClearProjectError();
				}
			}
			else
			{
				result = (new PooledList<LoggedMessage>(), new PooledList<LoggedMessage>());
			}
			return result;
		}
	}

	public List<LoggedMessage> MessageLog_Hybrid
	{
		get
		{
			List<LoggedMessage> result;
			if (theScen != null && theScen.MessageLog != null)
			{
				int count = theScen.MessageLog.Count;
				List<LoggedMessage> list = new List<LoggedMessage>(count);
				LoggedMessage[] array = theScen.MessageLog.ToArray();
				try
				{
					LoggedMessage[] array2 = array;
					foreach (LoggedMessage loggedMessage in array2)
					{
						if (loggedMessage != null && (loggedMessage.Side == null || loggedMessage.Side == this))
						{
							list.Add(loggedMessage);
						}
					}
					result = list;
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error at 200065", ex2.Message);
					GameGeneral.WriteExceptionsToLog(ex2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					result = list;
					ProjectData.ClearProjectError();
				}
			}
			else
			{
				result = new List<LoggedMessage>();
			}
			return result;
		}
	}

	public ReadOnlyCollection<Module_Unit.Unit> SelectedUnits => list_0.AsReadOnly();

	public Misc.PostureStance ConsidersThisSideToBe
	{
		get
		{
			if (TargetSide != null)
			{
				if (TargetSide == this)
				{
					return Misc.PostureStance.Friendly;
				}
				if (TargetSide.IndexAtSidesList == -1 && ScenarioContext != null)
				{
					TargetSide.IndexAtSidesList = Array.IndexOf(ScenarioContext.Sides_ReadOnly, TargetSide);
				}
				Misc.PostureStance value;
				if (TargetSide.IndexAtSidesList <= -1)
				{
					if (fastDictionary_0.TryGetValue(TargetSide, out value))
					{
						return value;
					}
					return Misc.PostureStance.Neutral;
				}
				if (TargetSide.IndexAtSidesList > postureStance_0.Length - 1)
				{
					Array.Resize(ref postureStance_0, TargetSide.IndexAtSidesList + 1);
					ResetPostureCacheArray();
				}
				if (postureStance_0[TargetSide.IndexAtSidesList] == Misc.PostureStance.Unknown)
				{
					if (!fastDictionary_0.TryGetValue(TargetSide, out value))
					{
						postureStance_0[TargetSide.IndexAtSidesList] = Misc.PostureStance.Neutral;
					}
					else
					{
						postureStance_0[TargetSide.IndexAtSidesList] = value;
					}
					return postureStance_0[TargetSide.IndexAtSidesList];
				}
				return postureStance_0[TargetSide.IndexAtSidesList];
			}
			return Misc.PostureStance.Unknown;
		}
		set
		{
			try
			{
				if (TargetSide == null)
				{
					return;
				}
				bool? flag;
				if (!fastDictionary_0.ContainsKey(TargetSide))
				{
					flag = true;
					fastDictionary_0.Add(TargetSide, value);
				}
				else
				{
					flag = fastDictionary_0[TargetSide] != value;
					if (flag == true)
					{
						fastDictionary_0[TargetSide] = value;
					}
				}
				if (flag != true)
				{
					return;
				}
				ResetPostureCacheArray();
				foreach (Contact value2 in Contacts.Values)
				{
					if (value2.SideIsKnown && value2.ActualUnit != null && value2.ActualUnit.get_UnitSide(SetSideOnly: false) != null && value2.ActualUnit.get_UnitSide(SetSideOnly: false) == TargetSide)
					{
						value2.set_Stance(this, MarkManually: false, value);
						value2.RetreivedPostureOnThisPulse = false;
					}
				}
				foreach (Contact value3 in BaseContacts.Values)
				{
					if (value3.SideIsKnown && value3.ActualUnit != null && value3.ActualUnit.get_UnitSide(SetSideOnly: false) != null && value3.ActualUnit.get_UnitSide(SetSideOnly: false) == TargetSide)
					{
						value3.set_Stance(this, MarkManually: false, value);
						value3.RetreivedPostureOnThisPulse = false;
					}
				}
				if (Contacts.Count > 0 && Contacts.Values.ElementAtOrDefault(0).ActualUnit != null)
				{
					Scenario parentScen = Contacts.Values.ElementAtOrDefault(0).ActualUnit.ParentScen;
					FastDictionary<string, HashSet<string>> fastDictionary = new FastDictionary<string, HashSet<string>>();
					Side[] sides_ReadOnly = parentScen.Sides_ReadOnly;
					foreach (Side side in sides_ReadOnly)
					{
						HashSet<string> FriendsList = new HashSet<string>();
						side.GetAllFriendlySides(parentScen, ref FriendsList);
						FriendsList.Remove(side.ObjectID);
						fastDictionary.Add(side.ObjectID, FriendsList);
					}
					GameGeneral.DeconflictContactsBetweenAllies(parentScen);
				}
				if ((value == Misc.PostureStance.Unfriendly || value == Misc.PostureStance.Hostile) && Units.Count > 0)
				{
					switch (value)
					{
					case Misc.PostureStance.Unfriendly:
						Units[0].ParentScen.AddMessage("Side '" + TargetSide.Name + "' is now considered UNFRIENDLY to " + Name, TargetSide.Name + " is now UNFRIENDLY to " + Name, LoggedMessage.MessageType.ContactChange, 0, null);
						break;
					case Misc.PostureStance.Hostile:
						Units[0].ParentScen.AddMessage("Side '" + TargetSide.Name + "' is now considered HOSTILE to " + Name, TargetSide.Name + " is now HOSTILE to " + Name, LoggedMessage.MessageType.ContactChange, 0, null);
						break;
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 101065", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	public int PackageID
	{
		get
		{
			if (int_2 >= 1000)
			{
				if (int_2 > 9999)
				{
					int_2 = 1000;
				}
			}
			else
			{
				int_2 = GameGeneral.GlobalRNG.Next(1000, 8000);
			}
			return int_2;
		}
		set
		{
			int_2 = value;
		}
	}

	public event SelectedUnitsChangedEventHandler SelectedUnitsChanged
	{
		[CompilerGenerated]
		add
		{
			SelectedUnitsChangedEventHandler selectedUnitsChangedEventHandler = selectedUnitsChangedEventHandler_0;
			SelectedUnitsChangedEventHandler selectedUnitsChangedEventHandler2;
			do
			{
				selectedUnitsChangedEventHandler2 = selectedUnitsChangedEventHandler;
				SelectedUnitsChangedEventHandler value2 = (SelectedUnitsChangedEventHandler)Delegate.Combine(selectedUnitsChangedEventHandler2, value);
				selectedUnitsChangedEventHandler = Interlocked.CompareExchange(ref selectedUnitsChangedEventHandler_0, value2, selectedUnitsChangedEventHandler2);
			}
			while ((object)selectedUnitsChangedEventHandler != selectedUnitsChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			SelectedUnitsChangedEventHandler selectedUnitsChangedEventHandler = selectedUnitsChangedEventHandler_0;
			SelectedUnitsChangedEventHandler selectedUnitsChangedEventHandler2;
			do
			{
				selectedUnitsChangedEventHandler2 = selectedUnitsChangedEventHandler;
				SelectedUnitsChangedEventHandler value2 = (SelectedUnitsChangedEventHandler)Delegate.Remove(selectedUnitsChangedEventHandler2, value);
				selectedUnitsChangedEventHandler = Interlocked.CompareExchange(ref selectedUnitsChangedEventHandler_0, value2, selectedUnitsChangedEventHandler2);
			}
			while ((object)selectedUnitsChangedEventHandler != selectedUnitsChangedEventHandler2);
		}
	}

	public static event ScoreChangedEventHandler ScoreChanged
	{
		[CompilerGenerated]
		add
		{
			ScoreChangedEventHandler scoreChangedEventHandler = scoreChangedEventHandler_0;
			ScoreChangedEventHandler scoreChangedEventHandler2;
			do
			{
				scoreChangedEventHandler2 = scoreChangedEventHandler;
				ScoreChangedEventHandler value2 = (ScoreChangedEventHandler)Delegate.Combine(scoreChangedEventHandler2, value);
				scoreChangedEventHandler = Interlocked.CompareExchange(ref scoreChangedEventHandler_0, value2, scoreChangedEventHandler2);
			}
			while ((object)scoreChangedEventHandler != scoreChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ScoreChangedEventHandler scoreChangedEventHandler = scoreChangedEventHandler_0;
			ScoreChangedEventHandler scoreChangedEventHandler2;
			do
			{
				scoreChangedEventHandler2 = scoreChangedEventHandler;
				ScoreChangedEventHandler value2 = (ScoreChangedEventHandler)Delegate.Remove(scoreChangedEventHandler2, value);
				scoreChangedEventHandler = Interlocked.CompareExchange(ref scoreChangedEventHandler_0, value2, scoreChangedEventHandler2);
			}
			while ((object)scoreChangedEventHandler != scoreChangedEventHandler2);
		}
	}

	public static event MissionsChangedEventHandler MissionsChanged
	{
		[CompilerGenerated]
		add
		{
			MissionsChangedEventHandler missionsChangedEventHandler = missionsChangedEventHandler_0;
			MissionsChangedEventHandler missionsChangedEventHandler2;
			do
			{
				missionsChangedEventHandler2 = missionsChangedEventHandler;
				MissionsChangedEventHandler value2 = (MissionsChangedEventHandler)Delegate.Combine(missionsChangedEventHandler2, value);
				missionsChangedEventHandler = Interlocked.CompareExchange(ref missionsChangedEventHandler_0, value2, missionsChangedEventHandler2);
			}
			while ((object)missionsChangedEventHandler != missionsChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			MissionsChangedEventHandler missionsChangedEventHandler = missionsChangedEventHandler_0;
			MissionsChangedEventHandler missionsChangedEventHandler2;
			do
			{
				missionsChangedEventHandler2 = missionsChangedEventHandler;
				MissionsChangedEventHandler value2 = (MissionsChangedEventHandler)Delegate.Remove(missionsChangedEventHandler2, value);
				missionsChangedEventHandler = Interlocked.CompareExchange(ref missionsChangedEventHandler_0, value2, missionsChangedEventHandler2);
			}
			while ((object)missionsChangedEventHandler != missionsChangedEventHandler2);
		}
	}

	public static event ContactAddedEventHandler ContactAdded
	{
		[CompilerGenerated]
		add
		{
			ContactAddedEventHandler contactAddedEventHandler = contactAddedEventHandler_0;
			ContactAddedEventHandler contactAddedEventHandler2;
			do
			{
				contactAddedEventHandler2 = contactAddedEventHandler;
				ContactAddedEventHandler value2 = (ContactAddedEventHandler)Delegate.Combine(contactAddedEventHandler2, value);
				contactAddedEventHandler = Interlocked.CompareExchange(ref contactAddedEventHandler_0, value2, contactAddedEventHandler2);
			}
			while ((object)contactAddedEventHandler != contactAddedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ContactAddedEventHandler contactAddedEventHandler = contactAddedEventHandler_0;
			ContactAddedEventHandler contactAddedEventHandler2;
			do
			{
				contactAddedEventHandler2 = contactAddedEventHandler;
				ContactAddedEventHandler value2 = (ContactAddedEventHandler)Delegate.Remove(contactAddedEventHandler2, value);
				contactAddedEventHandler = Interlocked.CompareExchange(ref contactAddedEventHandler_0, value2, contactAddedEventHandler2);
			}
			while ((object)contactAddedEventHandler != contactAddedEventHandler2);
		}
	}

	public static event ContactRemovedEventHandler ContactRemoved
	{
		[CompilerGenerated]
		add
		{
			ContactRemovedEventHandler contactRemovedEventHandler = contactRemovedEventHandler_0;
			ContactRemovedEventHandler contactRemovedEventHandler2;
			do
			{
				contactRemovedEventHandler2 = contactRemovedEventHandler;
				ContactRemovedEventHandler value2 = (ContactRemovedEventHandler)Delegate.Combine(contactRemovedEventHandler2, value);
				contactRemovedEventHandler = Interlocked.CompareExchange(ref contactRemovedEventHandler_0, value2, contactRemovedEventHandler2);
			}
			while ((object)contactRemovedEventHandler != contactRemovedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ContactRemovedEventHandler contactRemovedEventHandler = contactRemovedEventHandler_0;
			ContactRemovedEventHandler contactRemovedEventHandler2;
			do
			{
				contactRemovedEventHandler2 = contactRemovedEventHandler;
				ContactRemovedEventHandler value2 = (ContactRemovedEventHandler)Delegate.Remove(contactRemovedEventHandler2, value);
				contactRemovedEventHandler = Interlocked.CompareExchange(ref contactRemovedEventHandler_0, value2, contactRemovedEventHandler2);
			}
			while ((object)contactRemovedEventHandler != contactRemovedEventHandler2);
		}
	}

	public static event BaseContactAddedEventHandler BaseContactAdded
	{
		[CompilerGenerated]
		add
		{
			BaseContactAddedEventHandler baseContactAddedEventHandler = baseContactAddedEventHandler_0;
			BaseContactAddedEventHandler baseContactAddedEventHandler2;
			do
			{
				baseContactAddedEventHandler2 = baseContactAddedEventHandler;
				BaseContactAddedEventHandler value2 = (BaseContactAddedEventHandler)Delegate.Combine(baseContactAddedEventHandler2, value);
				baseContactAddedEventHandler = Interlocked.CompareExchange(ref baseContactAddedEventHandler_0, value2, baseContactAddedEventHandler2);
			}
			while ((object)baseContactAddedEventHandler != baseContactAddedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			BaseContactAddedEventHandler baseContactAddedEventHandler = baseContactAddedEventHandler_0;
			BaseContactAddedEventHandler baseContactAddedEventHandler2;
			do
			{
				baseContactAddedEventHandler2 = baseContactAddedEventHandler;
				BaseContactAddedEventHandler value2 = (BaseContactAddedEventHandler)Delegate.Remove(baseContactAddedEventHandler2, value);
				baseContactAddedEventHandler = Interlocked.CompareExchange(ref baseContactAddedEventHandler_0, value2, baseContactAddedEventHandler2);
			}
			while ((object)baseContactAddedEventHandler != baseContactAddedEventHandler2);
		}
	}

	public static event BaseContactRemovedEventHandler BaseContactRemoved
	{
		[CompilerGenerated]
		add
		{
			BaseContactRemovedEventHandler baseContactRemovedEventHandler = baseContactRemovedEventHandler_0;
			BaseContactRemovedEventHandler baseContactRemovedEventHandler2;
			do
			{
				baseContactRemovedEventHandler2 = baseContactRemovedEventHandler;
				BaseContactRemovedEventHandler value2 = (BaseContactRemovedEventHandler)Delegate.Combine(baseContactRemovedEventHandler2, value);
				baseContactRemovedEventHandler = Interlocked.CompareExchange(ref baseContactRemovedEventHandler_0, value2, baseContactRemovedEventHandler2);
			}
			while ((object)baseContactRemovedEventHandler != baseContactRemovedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			BaseContactRemovedEventHandler baseContactRemovedEventHandler = baseContactRemovedEventHandler_0;
			BaseContactRemovedEventHandler baseContactRemovedEventHandler2;
			do
			{
				baseContactRemovedEventHandler2 = baseContactRemovedEventHandler;
				BaseContactRemovedEventHandler value2 = (BaseContactRemovedEventHandler)Delegate.Remove(baseContactRemovedEventHandler2, value);
				baseContactRemovedEventHandler = Interlocked.CompareExchange(ref baseContactRemovedEventHandler_0, value2, baseContactRemovedEventHandler2);
			}
			while ((object)baseContactRemovedEventHandler != baseContactRemovedEventHandler2);
		}
	}

	[SpecialName]
	[CompilerGenerated]
	private virtual ObservableCollections.ObservableDictionary<string, Contact> vmethod_0()
	{
		return observableDictionary_0;
	}

	[SpecialName]
	[CompilerGenerated]
	private virtual void vmethod_1(ObservableCollections.ObservableDictionary<string, Contact> WithEventsValue)
	{
		EventHandler<DictionaryChangedEventArgs<string, Contact>> value = method_5;
		ObservableCollections.ObservableDictionary<string, Contact> observableDictionary = observableDictionary_0;
		if (observableDictionary != null)
		{
			observableDictionary.DictionaryChanged -= value;
		}
		observableDictionary_0 = WithEventsValue;
		observableDictionary = observableDictionary_0;
		if (observableDictionary != null)
		{
			observableDictionary.DictionaryChanged += value;
		}
	}

	[SpecialName]
	[CompilerGenerated]
	private virtual System.Collections.ObjectModel.ObservableDictionary<string, Contact> vmethod_2()
	{
		return observableDictionary_1;
	}

	[SpecialName]
	[CompilerGenerated]
	private virtual void vmethod_3(System.Collections.ObjectModel.ObservableDictionary<string, Contact> WithEventsValue)
	{
		INotifyDictionaryChanged<string, Contact>.DictionaryChangedEventHandler obj = method_2;
		System.Collections.ObjectModel.ObservableDictionary<string, Contact> observableDictionary = observableDictionary_1;
		if (observableDictionary != null)
		{
			observableDictionary.DictionaryChanged -= obj;
		}
		observableDictionary_1 = WithEventsValue;
		observableDictionary = observableDictionary_1;
		if (observableDictionary != null)
		{
			observableDictionary.DictionaryChanged += obj;
		}
	}

	public void AddWeaponSalvo(WeaponSalvo theWS)
	{
		if (WeaponSalvos == null)
		{
			WeaponSalvos = new ObservableList<WeaponSalvo>();
		}
		WeaponSalvos.Add(theWS);
	}

	public void RemoveWeaponSalvo(WeaponSalvo theWS)
	{
		if (WeaponSalvos == null)
		{
			return;
		}
		try
		{
			WeaponSalvos.Remove(theWS);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void ClearWeaponSalvos()
	{
		if (WeaponSalvos != null)
		{
			WeaponSalvos.Clear();
		}
	}

	internal new void Reinitialize()
	{
		AssignedFixedColor = null;
		fastDictionary_0.Clear();
		RefPoints.Clear();
		Doctrine = null;
		ExclusionZones.Clear();
		NoNavZones.Clear();
		AssignsCollectiveResponsibility = false;
		CanAutoTrackCivs = false;
		QuickJumpSlots.Clear();
		string_2 = "";
		string_3 = "";
		geoPoint_0 = null;
		ScoringLog.Clear();
		Scoring_Disaster = null;
		Scoring_Triumph = null;
		vmethod_0().Clear();
		vmethod_2().Clear();
		Contacts_NonAU.Clear();
		list_1.Clear();
		SpecialActions.Clear();
		IsAIOnly = false;
		ClearWeaponSalvos();
	}

	public int GetControllableUnitCount()
	{
		int num = 0;
		int result;
		if (IsNature)
		{
			result = 0;
		}
		else
		{
			if (!bool_0)
			{
				foreach (ActiveUnit unit in Units)
				{
					if (!unit.IsDumbAU)
					{
						num++;
					}
				}
				return num;
			}
			result = 0;
		}
		return result;
	}

	public List<ActiveUnit> GetAllCargoCapableUnits()
	{
		List<ActiveUnit> list = new List<ActiveUnit>();
		foreach (ActiveUnit unit in Units)
		{
			if (unit.CanCarryCargo())
			{
				list.Add(unit);
			}
		}
		return list;
	}

	public void ReleaseReferences()
	{
		try
		{
			QuickJumpSlots.Clear();
			foreach (Contact value in vmethod_0().Values)
			{
				value.ActualUnit = null;
				value.LastDetections.Clear();
			}
			vmethod_1(null);
			foreach (Contact value2 in vmethod_2().Values)
			{
				value2.ActualUnit = null;
				value2.LastDetections.Clear();
			}
			vmethod_3(null);
			foreach (Mission item in list_1)
			{
				item.ReleaseReferences();
			}
			list_1.Clear();
			PotentialContacts = null;
			PotentialBaseContacts = null;
			list_0.Clear();
			list_3 = null;
			ClearWeaponSalvos();
			FiringProposals = null;
			list_4 = null;
			list_5 = null;
			pooledList_0 = null;
			list_6 = null;
			list_7 = null;
			ArrayExtensions.Clear(ref activeUnit_0);
			hashSet_0.Clear();
			hashSet_1.Clear();
			SpecialDetections.Clear();
			operation_0 = null;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	public string ToXML(ref HashSet<string> ObjectsAlreadySerialized, ref Scenario theScen)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Expected O, but got Unknown
		if (stringBuilder_0 == null)
		{
			stringBuilder_0 = new StringBuilder();
		}
		else
		{
			stringBuilder_0.Clear();
		}
		stringBuilder_0.Append("<Side>");
		try
		{
			XmlWriterSettings val = new XmlWriterSettings();
			val.ConformanceLevel = (ConformanceLevel)0;
			stringBuilder_0.Append("<ID>").Append(ObjectID).Append("</ID>");
			if (ObjectsAlreadySerialized != null)
			{
				if (ObjectsAlreadySerialized.Contains(ObjectID))
				{
					stringBuilder_0.Append("</Side>");
					return stringBuilder_0.ToString();
				}
				ObjectsAlreadySerialized.Add(ObjectID);
			}
			stringBuilder_0.Append("<Name>").Append(SecurityElement.Escape(Name)).Append("</Name>");
			stringBuilder_0.Append("<Nature>").Append(SecurityElement.Escape(IsNature.ToString())).Append("</Nature>");
			if (Chalks.Count > 0)
			{
				stringBuilder_0.Append("<Chalks>");
				foreach (Chalk chalk in Chalks)
				{
					if (chalk != null && chalk.AssociatedMothership != null)
					{
						stringBuilder_0.Append(chalk.ToXML(ref ObjectsAlreadySerialized));
					}
				}
				stringBuilder_0.Append("</Chalks>");
			}
			if (Operation != null)
			{
				stringBuilder_0.Append(Operation.ToXML(ref ObjectsAlreadySerialized));
			}
			if (LandingPlans.Count > 0)
			{
				stringBuilder_0.Append("<LandingPlan>");
				try
				{
					XmlWriter theWriter = XmlWriter.Create(stringBuilder_0, val);
					XmlWriter val2 = theWriter;
					try
					{
						foreach (LandingPlan landingPlan in LandingPlans)
						{
							landingPlan.ToXML(ref theWriter, ref ObjectsAlreadySerialized);
						}
					}
					finally
					{
						((IDisposable)val2)?.Dispose();
					}
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				stringBuilder_0.Append("</LandingPlan>");
			}
			if (AssignedFixedColor.HasValue)
			{
				stringBuilder_0.Append("<Color>").Append(Conversions.ToString(AssignedFixedColor.Value.ToArgb())).Append("</Color>");
			}
			if (fastDictionary_0.Count > 0)
			{
				stringBuilder_0.Append("<Postures>");
				FastDictionary<Side, Misc.PostureStance>.Enumerator enumerator3 = fastDictionary_0.GetEnumerator();
				while (enumerator3.MoveNext())
				{
					if (enumerator3.Current.Key != null)
					{
						stringBuilder_0.Append("<Posture_").Append(enumerator3.Current.Key.ObjectID).Append(">")
							.Append(((int)enumerator3.Current.Value).ToString())
							.Append("</Posture_")
							.Append(enumerator3.Current.Key.ObjectID)
							.Append(">");
					}
				}
				stringBuilder_0.Append("</Postures>");
			}
			if (RefPoints.Count > 0)
			{
				stringBuilder_0.Append("<ReferencePoints>");
				List<ReferencePoint> list = RefPoints.ToList();
				foreach (ReferencePoint item in list)
				{
					if (item != null)
					{
						stringBuilder_0.Append(item.ToXML(ref ObjectsAlreadySerialized));
					}
				}
				stringBuilder_0.Append("</ReferencePoints>");
			}
			if (PerUnitSlugtrail.Count > 0)
			{
				stringBuilder_0.Append("<PerUnitSlugtrail>");
				foreach (KeyValuePair<string, SlugTrail> item2 in PerUnitSlugtrail)
				{
					stringBuilder_0.Append("<TrailedUnitID_" + item2.Key + ">");
					stringBuilder_0.Append("<RefPoints>");
					foreach (ReferencePoint refPoint in item2.Value.refPoints)
					{
						if (refPoint != null)
						{
							stringBuilder_0.Append(refPoint.ToXML(ref ObjectsAlreadySerialized));
						}
					}
					stringBuilder_0.Append("</RefPoints>");
					stringBuilder_0.Append("</TrailedUnitID_" + item2.Key + ">");
				}
				stringBuilder_0.Append("</PerUnitSlugtrail>");
			}
			if (RefPointsTag.Count > 0)
			{
				stringBuilder_0.Append("<ReferencePointFlag>");
				List<ReferencePointFlag> list2 = RefPointsTag.Keys.ToList();
				foreach (ReferencePointFlag item3 in list2)
				{
					if (item3 != null)
					{
						stringBuilder_0.Append(item3.ToXML(ref ObjectsAlreadySerialized));
					}
				}
				stringBuilder_0.Append("</ReferencePointFlag>");
			}
			if (Doctrine != null)
			{
				XmlWriter theWriter2 = XmlWriter.Create(stringBuilder_0, val);
				XmlWriter val3 = theWriter2;
				try
				{
					Doctrine.ToXML(ref theWriter2, ref theScen);
				}
				finally
				{
					((IDisposable)val3)?.Dispose();
				}
				theWriter2 = null;
			}
			if (StandardZones.Count > 0)
			{
				stringBuilder_0.Append("<StandardZones>");
				List<Zone> list3 = StandardZones.ToList();
				XmlWriter theWriter3 = XmlWriter.Create(stringBuilder_0, val);
				XmlWriter val4 = theWriter3;
				try
				{
					foreach (Zone item4 in list3)
					{
						item4.ToXML(ref theWriter3, ref ObjectsAlreadySerialized, ref theScen);
					}
				}
				finally
				{
					((IDisposable)val4)?.Dispose();
				}
				theWriter3 = null;
				stringBuilder_0.Append("</StandardZones>");
			}
			if (ExclusionZones.Count > 0)
			{
				stringBuilder_0.Append("<ExclusionZones>");
				List<ExclusionZone> list4 = ExclusionZones.ToList();
				XmlWriter theWriter4 = XmlWriter.Create(stringBuilder_0, val);
				XmlWriter val5 = theWriter4;
				try
				{
					foreach (ExclusionZone item5 in list4)
					{
						item5.ToXML(ref theWriter4, ref ObjectsAlreadySerialized, ref theScen);
					}
				}
				finally
				{
					((IDisposable)val5)?.Dispose();
				}
				theWriter4 = null;
				stringBuilder_0.Append("</ExclusionZones>");
			}
			if (NoNavZones.Count > 0)
			{
				stringBuilder_0.Append("<NoNavZones>");
				List<NoNavZone> list5 = NoNavZones.ToList();
				XmlWriter theWriter5 = XmlWriter.Create(stringBuilder_0, val);
				XmlWriter val6 = theWriter5;
				try
				{
					foreach (NoNavZone item6 in list5)
					{
						item6.ToXML(ref theWriter5, ref ObjectsAlreadySerialized, ref theScen);
					}
				}
				finally
				{
					((IDisposable)val6)?.Dispose();
				}
				theWriter5 = null;
				stringBuilder_0.Append("</NoNavZones>");
			}
			if (CustomEnvironmentZones.Count() > 0)
			{
				stringBuilder_0.Append("<CustomEnvironmentZones>");
				List<CustomEnvironmentZone> list6 = CustomEnvironmentZones.ToList();
				XmlWriter theWriter6 = XmlWriter.Create(stringBuilder_0, val);
				XmlWriter val7 = theWriter6;
				try
				{
					foreach (CustomEnvironmentZone item7 in list6)
					{
						item7.ToXML(ref theWriter6, ref ObjectsAlreadySerialized, ref theScen);
					}
				}
				finally
				{
					((IDisposable)val7)?.Dispose();
				}
				theWriter6 = null;
				stringBuilder_0.Append("</CustomEnvironmentZones>");
			}
			if (AssignsCollectiveResponsibility)
			{
				stringBuilder_0.Append("<CollectiveResponsibility>True</CollectiveResponsibility>");
			}
			else
			{
				stringBuilder_0.Append("<CollectiveResponsibility>False</CollectiveResponsibility>");
			}
			if (CanAutoTrackCivs)
			{
				stringBuilder_0.Append("<CATC>True</CATC>");
			}
			if (QuickJumpSlots.Count > 0)
			{
				stringBuilder_0.Append("<QuickJumpSlots>");
				XmlWriter theWriter7 = XmlWriter.Create(stringBuilder_0, val);
				XmlWriter val8 = theWriter7;
				try
				{
					foreach (QuickJumpSlot value in QuickJumpSlots.Values)
					{
						value.ToXML(ref theWriter7);
					}
				}
				finally
				{
					((IDisposable)val8)?.Dispose();
				}
				theWriter7 = null;
				stringBuilder_0.Append("</QuickJumpSlots>");
			}
			if (!string.IsNullOrEmpty(string_2))
			{
				stringBuilder_0.Append("<Briefing>").Append(string_2).Append("</Briefing>");
			}
			stringBuilder_0.Append("<Defcon>").Append((int)EmconAlertness.Level).Append("</Defcon>");
			if (!string.IsNullOrEmpty(string_3))
			{
				stringBuilder_0.Append("<Briefing_Encrypted>").Append(string_3).Append("</Briefing_Encrypted>");
			}
			if (geoPoint_0 != null)
			{
				stringBuilder_0.Append("<MapCenter>");
				stringBuilder_0.Append(geoPoint_0.ToXML(ObjectsAlreadySerialized));
				stringBuilder_0.Append("</MapCenter>");
			}
			stringBuilder_0.Append("<CameraAlt>").Append(XmlConvert.ToString(CameraAlt)).Append("</CameraAlt>");
			stringBuilder_0.Append("<TotalScore>").Append(XmlConvert.ToString(int_1)).Append("</TotalScore>");
			if (ScoringLog.Count > 0)
			{
				stringBuilder_0.Append("<ScoringLog>");
				foreach (string item8 in ScoringLog)
				{
					stringBuilder_0.Append("<msg>").Append(SecurityElement.Escape(item8)).Append("</msg>");
				}
				stringBuilder_0.Append("</ScoringLog>");
			}
			if (Scoring_Disaster.HasValue)
			{
				stringBuilder_0.Append("<Scoring_Disaster>").Append(XmlConvert.ToString(Scoring_Disaster.Value)).Append("</Scoring_Disaster>");
			}
			if (Scoring_Triumph.HasValue)
			{
				stringBuilder_0.Append("<Scoring_Triumph>").Append(XmlConvert.ToString(Scoring_Triumph.Value)).Append("</Scoring_Triumph>");
			}
			stringBuilder_0.Append("<AwarenessLevel>").Append(Conversions.ToString((int)AwarenessLevel)).Append("</AwarenessLevel>");
			if (CommNetworks.Count > 0)
			{
				stringBuilder_0.Append("<CommNetworks>");
				XmlWriter.Create(stringBuilder_0, val);
				foreach (CommNetwork value2 in CommNetworks.Values)
				{
					stringBuilder_0.Append(value2.ToXML(ObjectsAlreadySerialized, theScen));
				}
				stringBuilder_0.Append("</CommNetworks>");
			}
			if (Contacts.Count > 0)
			{
				stringBuilder_0.Append("<Contacts>");
				try
				{
					List<Contact> list7 = Contacts_List.ToList();
					foreach (Contact item9 in list7)
					{
						if (item9.ActualUnit != null)
						{
							stringBuilder_0.Append(item9.ToXML(ObjectsAlreadySerialized, this));
						}
					}
				}
				catch (Exception projectError2)
				{
					ProjectData.SetProjectError(projectError2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				stringBuilder_0.Append("</Contacts>");
			}
			stringBuilder_0.Append("<ContactAutoIncrement>").Append(ContactAutoIncrement.ToString()).Append("</ContactAutoIncrement>");
			if (BaseContacts.Count > 0)
			{
				stringBuilder_0.Append("<BaseContacts>");
				try
				{
					List<Contact> list8 = BaseContacts_List.ToList();
					foreach (Contact item10 in list8)
					{
						if (item10.ActualUnit != null)
						{
							stringBuilder_0.Append(item10.ToXML(ObjectsAlreadySerialized, this));
						}
					}
				}
				catch (Exception projectError3)
				{
					ProjectData.SetProjectError(projectError3);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				stringBuilder_0.Append("</BaseContacts>");
			}
			if (Contacts_NonAU.Count > 0)
			{
				stringBuilder_0.Append("<Contacts_NonAU>");
				try
				{
					List<string> list9 = Contacts_NonAU.ToList();
					foreach (string item11 in list9)
					{
						stringBuilder_0.Append("<ID>").Append(item11).Append("</ID>");
					}
				}
				catch (Exception projectError4)
				{
					ProjectData.SetProjectError(projectError4);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				stringBuilder_0.Append("</Contacts_NonAU>");
			}
			if (list_1.Count > 0)
			{
				stringBuilder_0.Append("<Missions>");
				try
				{
					XmlWriter theWriter8 = XmlWriter.Create(stringBuilder_0, val);
					XmlWriter val9 = theWriter8;
					try
					{
						foreach (Mission item12 in list_1)
						{
							item12?.ToXML(ref theWriter8, ref ObjectsAlreadySerialized, ref theScen);
						}
					}
					finally
					{
						((IDisposable)val9)?.Dispose();
					}
					theWriter8 = null;
				}
				catch (Exception projectError5)
				{
					ProjectData.SetProjectError(projectError5);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				stringBuilder_0.Append("</Missions>");
			}
			if (SpecialActions.Any())
			{
				stringBuilder_0.Append("<SpecialActions>");
				try
				{
					XmlWriter val10 = XmlWriter.Create(stringBuilder_0, val);
					XmlWriter val11 = val10;
					try
					{
						foreach (SpecialAction value3 in SpecialActions.Values)
						{
							value3.ToXML(val10, ObjectsAlreadySerialized, theScen);
						}
					}
					finally
					{
						((IDisposable)val11)?.Dispose();
					}
					val10 = null;
				}
				catch (Exception projectError6)
				{
					ProjectData.SetProjectError(projectError6);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				stringBuilder_0.Append("</SpecialActions>");
			}
			stringBuilder_0.Append("<Prof>").Append(Conversions.ToString((byte)Proficiency)).Append("</Prof>");
			stringBuilder_0.Append("<PackageID>").Append(Conversions.ToString(int_2)).Append("</PackageID>");
			stringBuilder_0.Append(SideMapProfile.ToXML());
			if (IsAIOnly)
			{
				stringBuilder_0.Append("<IsAIOnly>True</IsAIOnly>");
			}
			XmlWriter theWriter9 = XmlWriter.Create(stringBuilder_0, val);
			XmlWriter val12 = theWriter9;
			try
			{
				AAR.ToXML(ref theWriter9);
			}
			finally
			{
				((IDisposable)val12)?.Dispose();
			}
			theWriter9 = null;
			ObservableList<WeaponSalvo> weaponSalvos = WeaponSalvos;
			if (weaponSalvos != null && weaponSalvos.Count > 0)
			{
				stringBuilder_0.Append("<WeaponSalvos>");
				try
				{
					XmlWriter theWriter10 = XmlWriter.Create(stringBuilder_0, val);
					XmlWriter val13 = theWriter10;
					try
					{
						foreach (WeaponSalvo weaponSalvo in WeaponSalvos)
						{
							weaponSalvo.ToXML(ref theWriter10, ref ObjectsAlreadySerialized);
						}
					}
					finally
					{
						((IDisposable)val13)?.Dispose();
					}
				}
				catch (Exception projectError7)
				{
					ProjectData.SetProjectError(projectError7);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				stringBuilder_0.Append("</WeaponSalvos>");
			}
			ConcurrentDictionary<string, FiringProposal> firingProposals = FiringProposals;
			if (firingProposals != null && firingProposals.Count > 0)
			{
				stringBuilder_0.Append("<FiringProposal>");
				try
				{
					XmlWriter theWriter11 = XmlWriter.Create(stringBuilder_0, val);
					XmlWriter val14 = theWriter11;
					try
					{
						List<FiringProposal> list10 = new List<FiringProposal>(FiringProposals.Values);
						foreach (FiringProposal item13 in list10)
						{
							item13.ToXML(ref theWriter11, ref ObjectsAlreadySerialized);
						}
					}
					finally
					{
						((IDisposable)val14)?.Dispose();
					}
				}
				catch (Exception projectError8)
				{
					ProjectData.SetProjectError(projectError8);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				stringBuilder_0.Append("</FiringProposal>");
			}
			stringBuilder_0.Append("<Enablers>");
			if (!Enablers.GNSS_GPS)
			{
				stringBuilder_0.Append("<GPS_False/>");
			}
			if (!Enablers.GNSS_GLONASS)
			{
				stringBuilder_0.Append("<GLONASS_False/>");
			}
			if (!Enablers.GNSS_BeiDou)
			{
				stringBuilder_0.Append("<BeiDou_False/>");
			}
			if (!Enablers.GNSS_NavIC)
			{
				stringBuilder_0.Append("<NavIC_False/>");
			}
			stringBuilder_0.Append("</Enablers>");
			if (Operators.CompareString(HQ_ID, string.Empty, false) != 0)
			{
				stringBuilder_0.Append("<HQ_ID>");
				stringBuilder_0.Append(HQ_ID);
				stringBuilder_0.Append("</HQ_ID>");
			}
			if (TransmissionQueue != null && TransmissionQueue.Count > 0)
			{
				XmlWriter val15 = XmlWriter.Create(stringBuilder_0, val);
				try
				{
					val15.WriteStartElement("TransmissionQueue");
					foreach (KeyValuePair<string, List<Transmission>> item14 in TransmissionQueue)
					{
						val15.WriteStartElement("TransmissionGroup");
						val15.WriteElementString("Key", item14.Key);
						val15.WriteStartElement("ContactTransmission");
						foreach (Transmission item15 in item14.Value)
						{
							item15.ToXML(val15);
						}
						val15.WriteEndElement();
						val15.WriteEndElement();
					}
					val15.WriteEndElement();
				}
				finally
				{
					((IDisposable)val15)?.Dispose();
				}
			}
			if (NetworkLog.Count > 0)
			{
				stringBuilder_0.Append("<NetworkLog>");
				foreach (string item16 in NetworkLog)
				{
					if (item16 != null)
					{
						stringBuilder_0.Append(item16);
					}
				}
				stringBuilder_0.Append("</NetworkLog>");
			}
			if (NetworkRuleRegistry != null && NetworkRuleRegistry.Rules.Count > 0)
			{
				StringWriter stringWriter = new StringWriter();
				XmlWriter val16 = XmlWriter.Create(stringBuilder_0, val);
				try
				{
					NetworkRuleRegistry.ToXML(val16);
				}
				finally
				{
					((IDisposable)val16)?.Dispose();
				}
				stringBuilder_0.Append(stringWriter.ToString());
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101048", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		finally
		{
			stringBuilder_0.Append("</Side>");
		}
		return stringBuilder_0.ToString();
	}

	private Side(Scenario theScen)
	{
		fastDictionary_0 = new FastDictionary<Side, Misc.PostureStance>();
		dictionary_0 = new Dictionary<string, Misc.PostureStance>();
		IndexAtSidesList = -1;
		Enablers = default(SideEnablers);
		list_0 = new List<Module_Unit.Unit>();
		list_1 = new List<Mission>();
		list_2 = new List<ScenarioGoal>();
		SpecialActions = new Dictionary<string, SpecialAction>();
		vmethod_1(new ObservableCollections.ObservableDictionary<string, Contact>());
		vmethod_3(new System.Collections.ObjectModel.ObservableDictionary<string, Contact>());
		Contacts_NonAU = new HashSet<string>();
		NewContactsQueue_Forced = new TDictionary<string, Contact>(StringComparer.Ordinal);
		NewContactsQueue = new TDictionary<string, Contact>(StringComparer.Ordinal, useReadLock: false);
		NewBaseContactsQueue = new TDictionary<string, Contact>(StringComparer.Ordinal, useReadLock: false);
		DroppedContactsQueue = new TDictionary<string, Contact>(StringComparer.Ordinal, useReadLock: false);
		DroppedBaseContactsQueue = new TDictionary<string, Contact>(StringComparer.Ordinal);
		Units = new PooledList<ActiveUnit>();
		FriendlySidesThisPulse = new HashSet<Side>();
		PerUnitSlugtrail = new Dictionary<string, SlugTrail>();
		RefPoints = new ObservableList<ReferencePoint>();
		RefPointsTag_raw = new Dictionary<string, ReferencePointFlag>();
		RefPointsTag = new Dictionary<ReferencePointFlag, Dictionary<ReferencePoint, ReferencePoint>>();
		AAR = new _AAR();
		ExclusionZones = new List<ExclusionZone>();
		NoNavZones = new List<NoNavZone>();
		CustomEnvironmentZones = new CustomEnvironmentZone[0];
		StandardZones = new List<Zone>();
		AssignsCollectiveResponsibility = true;
		CanAutoTrackCivs = false;
		QuickJumpSlots = new Dictionary<int, QuickJumpSlot>();
		WeaponSalvos = new ObservableList<WeaponSalvo>();
		ScoringLog = new List<string>();
		Cache_ContactStancesOnThisPulse = new TDictionary<string, Misc.PostureStance>(StringComparer.Ordinal, useReadLock: false);
		Cache_ContactIncomingWeapons = new TDictionary<string, int>(StringComparer.Ordinal);
		tdictionary_0 = new TDictionary<Contact, List<WeaponSalvo>>();
		Cache_ContactsInsideNoNavZones = new TDictionary<string, bool>(StringComparer.Ordinal, useReadLock: false);
		Cache_ContactsInsidePatrolAreas = new TDictionary<(Contact, Patrol), bool>();
		Cache_ContactsInsideProsecutionAreas = new TDictionary<(Contact, Patrol), bool>();
		Cache_UnitsAssignedToMissionOrPackage = new TDictionary<Mission, List<ActiveUnit>>();
		activeUnit_0 = new ActiveUnit[0];
		hashSet_0 = new HashSet<string>();
		hashSet_1 = new HashSet<string>();
		SpecialDetections = new Queue<(Contact, ActiveUnit, List<Sensor>, float, ActiveUnit_Sensory.SpecialDetectionMode, DateTime, List<Geopoint_Struct>)>();
		AGU_Frontline = new List<AggregateGroundUnit_Frontline>();
		EmconAlertness = new EmconLevel();
		CommNetworks = new System.Collections.ObjectModel.ObservableDictionary<string, CommNetwork>();
		SelectedNetworks = new List<CommNetwork>();
		NetworkColorMap = new Dictionary<string, Color>();
		IsUnitInContactWithTheLeaderInthisPulse = new ConcurrentDictionary<string, bool>();
		NetworkLog = new ObservableCollection<string>();
		NetworkRuleRegistry = null;
		IsNature = false;
		Chalks = new List<Chalk>();
		list_9 = new List<Chalk>();
		LandingPlans = new List<LandingPlan>();
		DisableMultiDomainTOT = false;
		ContactsJustSharedWithMe = new HashSet<string>();
		lockObject_0 = new LockObject();
		postureStance_0 = new Misc.PostureStance[0];
		AddShooter = new LockObject();
		SalvoMaxDistanceToTargetList = new ConcurrentDictionary<DateTime, SalvoMaxDistanceToTarget>();
		FeedbackList = new TList<TransmissionWithFeedback>();
		MinuteFeedbackList = new TList<TransmissionWithFeedback>();
		TransmissionQueue = new TDictionary<string, List<Transmission>>();
		MinuteTransmissionQueue = new TDictionary<string, TList<Transmission>>();
		concurrentQueue_0 = new ConcurrentQueue<TransmittedContactData>();
		List<ActiveUnit> DoctrineSelectedUnits = null;
		Doctrine = new Doctrine(theScen, this, ref DoctrineSelectedUnits);
		Enablers.GNSS_GPS = true;
		Enablers.GNSS_GLONASS = true;
		Enablers.GNSS_BeiDou = true;
		Enablers.GNSS_NavIC = true;
	}

	public static Side FromXML_ByName(string theSideName, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, Scenario theScen)
	{
		Side result;
		try
		{
			Side[] sides_ReadOnly = theScen.Sides_ReadOnly;
			int num = 0;
			while (true)
			{
				if (num < sides_ReadOnly.Length)
				{
					Side side = sides_ReadOnly[num];
					if (Operators.CompareString(side.Name, theSideName, false) != 0)
					{
						num = checked(num + 1);
						continue;
					}
					result = side;
					break;
				}
				List<ScenarioObject> list = new List<ScenarioObject>(theDictionary.Values);
				foreach (ScenarioObject item in list)
				{
					if ((object)item.GetType() == typeof(Side) && Operators.CompareString(((Side)item).Name, theSideName, false) == 0)
					{
						result = (Side)item;
						goto end_IL_0029;
					}
				}
				result = null;
				break;
				continue;
				end_IL_0029:
				break;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101049", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static Side FromXML_ByObjectID(string theSideObjectID, ref ConcurrentDictionary<string, ScenarioObject> theDictionary)
	{
		Side result = null;
		if (theDictionary.ContainsKey(theSideObjectID))
		{
			result = (Side)theDictionary[theSideObjectID];
		}
		return result;
	}

	public static Side FromXML(ref XmlNode theNode, ref Scenario theScen, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, Side existingObject = null)
	{
		//IL_1465: Unknown result type (might be due to invalid IL or missing references)
		//IL_146c: Expected O, but got Unknown
		//IL_0a73: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a7a: Expected O, but got Unknown
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected O, but got Unknown
		//IL_0818: Unknown result type (might be due to invalid IL or missing references)
		//IL_081f: Expected O, but got Unknown
		//IL_17fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_1801: Expected O, but got Unknown
		//IL_1360: Unknown result type (might be due to invalid IL or missing references)
		//IL_1367: Expected O, but got Unknown
		//IL_1186: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f01: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f08: Expected O, but got Unknown
		//IL_0da8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0daf: Expected O, but got Unknown
		//IL_077f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0786: Expected O, but got Unknown
		//IL_1987: Unknown result type (might be due to invalid IL or missing references)
		//IL_198e: Expected O, but got Unknown
		//IL_1781: Unknown result type (might be due to invalid IL or missing references)
		//IL_1788: Expected O, but got Unknown
		//IL_168b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1692: Expected O, but got Unknown
		//IL_156a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1571: Expected O, but got Unknown
		//IL_12dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_12e4: Expected O, but got Unknown
		//IL_1095: Unknown result type (might be due to invalid IL or missing references)
		//IL_109c: Expected O, but got Unknown
		//IL_0fc9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fd7: Expected O, but got Unknown
		//IL_0d23: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d2a: Expected O, but got Unknown
		//IL_0c25: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c2c: Expected O, but got Unknown
		//IL_0b6c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b73: Expected O, but got Unknown
		//IL_0715: Unknown result type (might be due to invalid IL or missing references)
		//IL_071c: Expected O, but got Unknown
		//IL_03fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0405: Expected O, but got Unknown
		//IL_189a: Unknown result type (might be due to invalid IL or missing references)
		//IL_18a1: Expected O, but got Unknown
		//IL_0578: Unknown result type (might be due to invalid IL or missing references)
		//IL_0582: Expected O, but got Unknown
		//IL_04c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d0: Expected O, but got Unknown
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Expected O, but got Unknown
		//IL_0dfe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e05: Expected O, but got Unknown
		//IL_10e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_10ef: Expected O, but got Unknown
		//IL_0e31: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e38: Expected O, but got Unknown
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_016e: Expected O, but got Unknown
		Side result;
		try
		{
			bool flag;
			Side side;
			if (!(flag = existingObject != null))
			{
				side = new Side(theScen);
			}
			else
			{
				side = existingObject;
				side.Reinitialize();
			}
			side.IsAIOnly = false;
			IEnumerator enumerator18 = default(IEnumerator);
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode theNode2 = childNode;
				switch (theNode2.Name)
				{
				case "TransmissionQueue":
				{
					if (flag)
					{
						side.TransmissionQueue.Clear();
					}
					Dictionary<string, List<Transmission>> dictionary = null;
					foreach (XmlNode childNode2 in theNode2.ChildNodes)
					{
						XmlNode val = childNode2;
						if (Operators.CompareString(val.Name, "TransmissionGroup", false) != 0)
						{
							continue;
						}
						XmlNode val2 = val.SelectSingleNode("Key");
						XmlNode val3 = val.SelectSingleNode("ContactTransmission");
						if (val2 == null || val3 == null)
						{
							continue;
						}
						string innerText = val2.InnerText;
						List<Transmission> list = new List<Transmission>();
						foreach (XmlNode item3 in val3.SelectNodes("ContactTransmission"))
						{
							Transmission transmission = Transmission.FromXML(item3, theDictionary);
							if (transmission != null)
							{
								list.Add(transmission);
								if (theScen.LastTransmissionId < transmission.ID)
								{
									theScen.LastTransmissionId = transmission.ID;
								}
							}
						}
						if (dictionary == null)
						{
							dictionary = new Dictionary<string, List<Transmission>>();
						}
						dictionary.Add(innerText, list);
					}
					if (dictionary != null)
					{
						side.TransmissionQueue.Clear();
						if (dictionary != null)
						{
							side.TransmissionQueue = new TDictionary<string, List<Transmission>>(dictionary);
						}
					}
					break;
				}
				case "Name":
					side.Name = theNode2.InnerText;
					break;
				case "Scoring_Triumph":
					side.Scoring_Triumph = XmlConvert.ToInt32(theNode2.InnerText);
					break;
				case "NetworkRules":
					try
					{
						NetworkRuleRegistry networkRuleRegistry = new NetworkRuleRegistry();
						networkRuleRegistry.FromXML(theNode2);
						side.NetworkRuleRegistry = networkRuleRegistry;
					}
					catch (Exception ex5)
					{
						ProjectData.SetProjectError(ex5);
						Exception ex6 = ex5;
						ex6?.Data.Add("Error at NetworkRules deserialization", "");
						side.NetworkRuleRegistry = null;
						GameGeneral.WriteExceptionsToLog(ex6);
						ProjectData.ClearProjectError();
					}
					break;
				case "HQ_ID":
					side.HQ_ID = theNode2.InnerText;
					break;
				case "Nature":
					side.IsNature = Conversions.ToBoolean(theNode2.InnerText);
					break;
				case "CameraAlt":
					side.CameraAlt = XmlConvert.ToDouble(theNode2.InnerText.Replace(", ", "."));
					break;
				case "ReferencePoints":
					if (flag)
					{
						side.RefPoints.Clear();
					}
					foreach (XmlNode childNode3 in theNode2.ChildNodes)
					{
						XmlNode theNode7 = childNode3;
						side.RefPoints.Add(ReferencePoint.FromXML(ref theNode7, ref theDictionary, theScen));
					}
					break;
				case "Operation":
					side.Operation = Operation.FromXML(ref theNode2, ref theDictionary, side);
					break;
				case "Missions":
					if (flag)
					{
						side.list_1.Clear();
					}
					foreach (XmlNode childNode4 in theNode2.ChildNodes)
					{
						XmlNode theNode16 = childNode4;
						side.list_1.Add(Mission.FromXML(ref theNode16, ref theDictionary, ref theScen));
					}
					break;
				case "QuickJumpSlots":
					if (flag)
					{
						side.QuickJumpSlots.Clear();
					}
					foreach (XmlNode childNode5 in theNode2.ChildNodes)
					{
						QuickJumpSlot quickJumpSlot = QuickJumpSlot.FromXML(childNode5);
						side.QuickJumpSlots.Add(quickJumpSlot.Index, quickJumpSlot);
					}
					break;
				case "Scoring_Disaster":
					side.Scoring_Disaster = XmlConvert.ToInt32(theNode2.InnerText);
					break;
				case "ID":
					if (!theDictionary.ContainsKey(theNode2.InnerText))
					{
						side.ObjectID_Set(theNode2.InnerText);
						theDictionary.TryAdd(side.ObjectID, side);
						break;
					}
					result = (Side)theDictionary[theNode2.InnerText];
					goto end_IL_0001;
				case "Prof":
					side.Proficiency = (GlobalVariables.ProficiencyLevel)Conversions.ToInteger(theNode2.InnerText);
					break;
				case "Doctrine":
					side.Doctrine = Doctrine.FromXML(theScen, ref theNode2, side);
					break;
				case "CustomEnvironmentZones":
					foreach (XmlNode childNode6 in theNode2.ChildNodes)
					{
						XmlNode theNode9 = childNode6;
						ArrayExtensions.Add(ref side.CustomEnvironmentZones, CustomEnvironmentZone.FromXML(ref theNode9, ref theDictionary, ref theScen));
					}
					break;
				case "StandardZones":
					foreach (XmlNode childNode7 in theNode2.ChildNodes)
					{
						XmlNode theNode6 = childNode7;
						side.StandardZones.Add(Zone.FromXML(ref theNode6, ref theDictionary, ref theScen));
					}
					break;
				case "Postures":
					if (flag)
					{
						side.dictionary_0.Clear();
					}
					foreach (XmlNode childNode8 in theNode2.ChildNodes)
					{
						XmlNode theNode4 = childNode8;
						if (Operators.CompareString(theNode4.Name, "Posture", false) != 0)
						{
							string key = theNode4.Name.Split(new char[1] { '_' })[1];
							Misc.PostureStance value = (Misc.PostureStance)Conversions.ToByte(theNode4.InnerText);
							try
							{
								if (!side.dictionary_0.ContainsKey(key))
								{
									side.dictionary_0.Add(key, value);
								}
							}
							catch (Exception ex)
							{
								ProjectData.SetProjectError(ex);
								Exception ex2 = ex;
								ex2?.Data.Add("Error at 200590", ex2.Message);
								GameGeneral.WriteExceptionsToLog(ex2);
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
								ProjectData.ClearProjectError();
							}
							continue;
						}
						Posture.FromXML(ref theNode4, ref theDictionary);
						string innerText2 = Misc.GetNodeByName(theNode4.ChildNodes, "PostureTarget").InnerText;
						Misc.PostureStance value2 = (Misc.PostureStance)Conversions.ToByte(Misc.GetNodeByName(theNode4.ChildNodes, "PostureType").InnerText);
						try
						{
							if (!side.dictionary_0.ContainsKey(innerText2))
							{
								side.dictionary_0.Add(innerText2, value2);
							}
						}
						catch (Exception ex3)
						{
							ProjectData.SetProjectError(ex3);
							Exception ex4 = ex3;
							ex4?.Data.Add("Error at 200058", ex4.Message);
							GameGeneral.WriteExceptionsToLog(ex4);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
					}
					break;
				case "CollectiveResponsibility":
					side.AssignsCollectiveResponsibility = Misc.ParseBool(theNode2.InnerText);
					break;
				case "Briefing":
					side.Briefing = theNode2.InnerText;
					side.Briefing = side.Briefing.Replace("<HR>", "");
					break;
				case "BaseContacts":
					if (flag)
					{
						side.hashSet_1.Clear();
						side.vmethod_2().Clear();
					}
					foreach (XmlNode childNode9 in theNode2.ChildNodes)
					{
						XmlNode theNode21 = childNode9;
						Contact contact2 = Contact.FromXML(ref theNode21, ref theDictionary);
						if (!Information.IsNothing((object)contact2))
						{
							try
							{
								side.vmethod_2().Add(contact2._ActualUnitID, contact2);
							}
							catch (Exception projectError2)
							{
								ProjectData.SetProjectError(projectError2);
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
								ProjectData.ClearProjectError();
							}
						}
						else
						{
							side.hashSet_1.Add(theNode21.ChildNodes[0].InnerText);
						}
					}
					break;
				case "ReferencePointFlag":
					foreach (XmlNode childNode10 in theNode2.ChildNodes)
					{
						XmlNode theNode20 = childNode10;
						ReferencePointFlag referencePointFlag = ReferencePointFlag.FromXML(ref theNode20, ref theDictionary);
						side.RefPointsTag_raw.Add(referencePointFlag.ObjectID, referencePointFlag);
					}
					break;
				case "IsAIOnly":
					side.IsAIOnly = Misc.ParseBool(theNode2.InnerText);
					break;
				case "LandingPlan":
					foreach (XmlNode childNode11 in theNode2.ChildNodes)
					{
						XmlNode theNode19 = childNode11;
						LandingPlan item2 = LandingPlan.FromXML(ref theNode19, theDictionary, side, ref theScen);
						side.LandingPlans.Add(item2);
					}
					break;
				case "Briefing_Encrypted":
					side.string_3 = theNode2.InnerText;
					side.string_3 = side.string_3.Replace("<HR>", "");
					break;
				case "FiringProposals":
					foreach (XmlNode childNode12 in theNode2.ChildNodes)
					{
						XmlNode theNode18 = childNode12;
						FiringProposal firingProposal = FiringProposal.FromXML(ref theNode18, theDictionary, ref theScen);
						side.FiringProposals.TryAdd(firingProposal.ObjectID, firingProposal);
					}
					break;
				case "PerUnitSlugtrail":
					side.PerUnitSlugtrail = new Dictionary<string, SlugTrail>();
					foreach (XmlNode childNode13 in theNode2.ChildNodes)
					{
						XmlNode val8 = childNode13;
						string text2 = val8.Name;
						if (text2.StartsWith("TrailedUnitID_"))
						{
							text2 = text2.Substring(14);
						}
						side.PerUnitSlugtrail.Add(text2, new SlugTrail());
						foreach (XmlNode childNode14 in val8.ChildNodes)
						{
							XmlNode val9 = childNode14;
							if (Operators.CompareString(val9.Name, "RefPoints", false) != 0)
							{
								continue;
							}
							foreach (XmlNode childNode15 in val9.ChildNodes)
							{
								XmlNode theNode17 = childNode15;
								side.PerUnitSlugtrail[text2].refPoints.Enqueue(ReferencePoint.FromXML(ref theNode17, ref theDictionary, theScen));
							}
						}
					}
					break;
				case "Contacts_NonAU":
					if (flag)
					{
						side.Contacts_NonAU.Clear();
					}
					foreach (XmlNode childNode16 in theNode2.ChildNodes)
					{
						XmlNode val7 = childNode16;
						side.Contacts_NonAU.Add(val7.InnerText);
					}
					break;
				case "TotalScore":
					side.int_1 = XmlConvert.ToInt32(theNode2.InnerText);
					break;
				case "SpecialActions":
					if (flag)
					{
						side.SpecialActions.Clear();
					}
					foreach (XmlNode childNode17 in theNode2.ChildNodes)
					{
						SpecialAction specialAction = SpecialAction.FromXML(childNode17, theDictionary, theScen);
						side.SpecialActions.Add(specialAction.ObjectID, specialAction);
					}
					break;
				case "RefPoints_PerUnitSlugtrail":
					side.PerUnitSlugtrail = new Dictionary<string, SlugTrail>();
					foreach (XmlNode childNode18 in theNode2.ChildNodes)
					{
						XmlNode val6 = childNode18;
						string text = val6.Name;
						if (text.StartsWith("TrailedUnitID_"))
						{
							text = text.Substring(14);
						}
						side.PerUnitSlugtrail.Add(text, new SlugTrail());
						foreach (XmlNode childNode19 in val6.ChildNodes)
						{
							XmlNode theNode15 = childNode19;
							side.PerUnitSlugtrail[text].refPoints.Enqueue(ReferencePoint.FromXML(ref theNode15, ref theDictionary, theScen));
						}
					}
					break;
				case "Enablers":
					{
						enumerator18 = theNode2.ChildNodes.GetEnumerator();
						try
						{
							while (enumerator18.MoveNext())
							{
								switch (((XmlNode)enumerator18.Current).Name)
								{
								case "GLONASS_False":
									side.Enablers.GNSS_GLONASS = false;
									break;
								case "BeiDou_False":
									side.Enablers.GNSS_BeiDou = false;
									break;
								case "NavIC_False":
									side.Enablers.GNSS_NavIC = false;
									break;
								case "GPS_False":
									side.Enablers.GNSS_GPS = false;
									break;
								}
							}
						}
						finally
						{
							IDisposable disposable = enumerator18 as IDisposable;
							if (disposable != null)
							{
								disposable.Dispose();
							}
						}
					}
					break;
				case "AAR":
					side.AAR = _AAR.FromXML(ref theNode2);
					break;
				case "PackageID":
					side.int_2 = Conversions.ToShort(theNode2.InnerText);
					break;
				case "ScoringLog":
					if (flag)
					{
						side.ScoringLog.Clear();
					}
					foreach (XmlNode childNode20 in theNode2.ChildNodes)
					{
						XmlNode val5 = childNode20;
						side.ScoringLog.Add(val5.InnerText);
					}
					break;
				case "CommClusters":
				case "CommNetworks":
					foreach (XmlNode childNode21 in theNode2.ChildNodes)
					{
						XmlNode theNode14 = childNode21;
						CommNetwork commNetwork = CommNetwork.FromXML(ref theNode14, theDictionary, side, ref theScen);
						if (commNetwork != null)
						{
							side.CommNetworks.Add(commNetwork.ID, commNetwork);
						}
					}
					break;
				case "ContactAutoIncrement":
					side.ContactAutoIncrement = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "Contacts":
					if (flag)
					{
						side.hashSet_0.Clear();
						side.vmethod_0().Clear();
					}
					foreach (XmlNode childNode22 in theNode2.ChildNodes)
					{
						XmlNode theNode13 = childNode22;
						Contact contact = Contact.FromXML(ref theNode13, ref theDictionary);
						if (Information.IsNothing((object)contact))
						{
							if (!side.hashSet_0.Contains(theNode13.ChildNodes[0].InnerText))
							{
								side.hashSet_0.Add(theNode13.ChildNodes[0].InnerText);
							}
							continue;
						}
						try
						{
							if (!side.vmethod_0().ContainsKey(contact._ActualUnitID))
							{
								side.vmethod_0().Add(contact._ActualUnitID, contact);
							}
						}
						catch (Exception projectError)
						{
							ProjectData.SetProjectError(projectError);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
					}
					break;
				case "NoNavZones":
				case "NavZones":
					if (flag)
					{
						side.NoNavZones.Clear();
					}
					foreach (XmlNode childNode23 in theNode2.ChildNodes)
					{
						XmlNode theNode12 = childNode23;
						side.NoNavZones.Add(NoNavZone.FromXML(ref theNode12, ref theDictionary, ref theScen));
					}
					break;
				case "Defcon":
					side.EmconAlertness.Level = (Alertlevels)Conversions.ToInteger(theNode2.InnerText);
					break;
				case "MapProfile":
					side.SideMapProfile = MapProfile.FromXML(theNode2);
					break;
				case "CATC":
					side.CanAutoTrackCivs = Misc.ParseBool(theNode2.InnerText);
					break;
				case "Chalks":
					foreach (XmlNode childNode24 in theNode2.ChildNodes)
					{
						XmlNode theNode11 = childNode24;
						Chalk item = Chalk.FromXML(ref theNode11, ref theDictionary);
						side.list_9.Add(item);
					}
					break;
				case "MapCenter":
				{
					Side side2 = side;
					XmlNode theNode10 = theNode2.ChildNodes[0];
					side2.geoPoint_0 = GeoPoint.FromXML(ref theNode10, ref theDictionary);
					break;
				}
				case "WeaponSalvos":
					if (flag)
					{
						side.ClearWeaponSalvos();
					}
					foreach (XmlNode childNode25 in theNode2.ChildNodes)
					{
						XmlNode theNode8 = childNode25;
						WeaponSalvo weaponSalvo = WeaponSalvo.FromXML(ref theNode8, theDictionary, ref theScen);
						if (!Information.IsNothing((object)weaponSalvo.Target))
						{
							side.AddWeaponSalvo(weaponSalvo);
						}
					}
					break;
				case "ClusterLog":
				case "NetworkLog":
					foreach (XmlNode childNode26 in theNode2.ChildNodes)
					{
						XmlNode val4 = childNode26;
						side.NetworkLog.Add(val4.InnerText);
					}
					break;
				case "Goals":
					if (flag)
					{
						side.list_2.Clear();
					}
					foreach (XmlNode childNode27 in theNode2.ChildNodes)
					{
						XmlNode theNode5 = childNode27;
						side.list_2.Add(ScenarioGoal.FromXML(theNode5, theDictionary, theScen));
					}
					break;
				case "Color":
					side.AssignedFixedColor = Color.FromArgb(Conversions.ToInteger(theNode2.InnerText));
					break;
				case "AwarenessLevel":
					side.AwarenessLevel = (AwarenessLevel_Enum)Conversions.ToInteger(theNode2.InnerText);
					break;
				case "ForbiddenZones":
				case "ExclusionZones":
					if (flag)
					{
						side.ExclusionZones.Clear();
					}
					foreach (XmlNode childNode28 in theNode2.ChildNodes)
					{
						XmlNode theNode3 = childNode28;
						side.ExclusionZones.Add(ExclusionZone.FromXML(ref theNode3, ref theDictionary, ref theScen));
					}
					break;
				}
			}
			side.ParentScen = theScen;
			result = side;
			end_IL_0001:;
		}
		catch (Exception ex7)
		{
			ProjectData.SetProjectError(ex7);
			Exception ex8 = ex7;
			ex8?.Data.Add("Error at 101050", "");
			GameGeneral.WriteExceptionsToLog(ex8);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new Side(theScen);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public void PostDeserializationHousekeeping(ref Scenario theScen, ConcurrentDictionary<string, ScenarioObject> theDictionary, bool GameIsRunning)
	{
		try
		{
			if (RefPoints.Count > 0)
			{
				for (int i = RefPoints.Count - 1; i >= 0; i += -1)
				{
					RefPoints[i].RenderGroup = ReferencePoint_Group.Generic;
				}
			}
			if (PerUnitSlugtrail.Count > 0)
			{
				for (int j = PerUnitSlugtrail.Count - 1; j >= 0; j += -1)
				{
					for (int k = PerUnitSlugtrail.ElementAt(j).Value.refPoints.Count - 1; k >= 0; k += -1)
					{
						PerUnitSlugtrail.ElementAt(j).Value.refPoints.ElementAtOrDefault(k).RenderGroup = ReferencePoint_Group.Slugtrail;
					}
				}
			}
			foreach (Chalk item in list_9)
			{
				if (!theDictionary.ContainsKey(item._AssociatedMothershipID))
				{
					continue;
				}
				Chalks.Add(item);
				item.AssociatedMothership = (ActiveUnit)theDictionary[item._AssociatedMothershipID];
				foreach (string cargoID in item._CargoIDs)
				{
					if (theDictionary.ContainsKey(cargoID))
					{
						item.Cargo.Add((Cargo)theDictionary[cargoID], 0);
					}
				}
			}
			if (theDictionary.ContainsKey(Operation._HHourMissionID))
			{
				Operation.HHourMission = (Mission)theDictionary[Operation._HHourMissionID];
			}
			if (theDictionary.ContainsKey(Operation._LHourMissionID))
			{
				Operation.LHourMission = (Mission)theDictionary[Operation._LHourMissionID];
			}
			foreach (LandingPlan item2 in LandingPlans.ToList())
			{
				foreach (string serializedMissionsGUID in item2._SerializedMissionsGUIDS)
				{
					item2.AddMission((Mission)theDictionary[serializedMissionsGUID]);
				}
			}
			foreach (Mission mission2 in Missions)
			{
				foreach (string item3 in mission2._MissionStartTrigger_MissionCompletedID)
				{
					if (theDictionary.ContainsKey(item3))
					{
						Mission mission = (Mission)theDictionary[item3];
						mission2.MissionStartTrigger_MissionCompleted.Add(mission, mission);
					}
				}
			}
			foreach (KeyValuePair<string, Misc.PostureStance> item4 in dictionary_0)
			{
				Side side = FromXML_ByObjectID(item4.Key, ref theDictionary);
				if (side != null)
				{
					fastDictionary_0.Add(side, item4.Value);
				}
			}
			foreach (ReferencePointFlag value in RefPointsTag_raw.Values)
			{
				if (!RefPointsTag.ContainsKey(value))
				{
					RefPointsTag.Add(value, new Dictionary<ReferencePoint, ReferencePoint>());
				}
			}
			foreach (ReferencePoint refPoint in RefPoints)
			{
				if (refPoint.TagsByGuid_Raw.Count == 0)
				{
					continue;
				}
				foreach (string item5 in refPoint.TagsByGuid_Raw)
				{
					if (RefPointsTag_raw.ContainsKey(item5) && !refPoint.Tags.ContainsKey(RefPointsTag_raw[item5]))
					{
						refPoint.Tags.Add(RefPointsTag_raw[item5], RefPointsTag_raw[item5]);
						RefPointsTag[RefPointsTag_raw[item5]].Add(refPoint, refPoint);
					}
				}
			}
			foreach (string item6 in hashSet_0)
			{
				try
				{
					Contact contact = (Contact)theDictionary[item6];
					Contacts.Add(contact._ActualUnitID, contact);
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error at 200059", ex2.Message);
					GameGeneral.WriteExceptionsToLog(ex2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
			foreach (string item7 in hashSet_1)
			{
				try
				{
					Contact contact2 = (Contact)theDictionary[item7];
					BaseContacts.Add(contact2._ActualUnitID, contact2);
				}
				catch (Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					Exception ex4 = ex3;
					ex4?.Data.Add("Error at 200060", ex4.Message);
					GameGeneral.WriteExceptionsToLog(ex4);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
		}
		catch (Exception ex5)
		{
			ProjectData.SetProjectError(ex5);
			Exception ex6 = ex5;
			ex6?.Data.Add("Error at 101051", "");
			GameGeneral.WriteExceptionsToLog(ex6);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void AddContact(Contact theC, bool Forced = false)
	{
		try
		{
			NewContactsQueue_Forced.AddIfNotExistsElseUpdate(theC.ActualUnit.ObjectID, theC);
			NewContactsQueue.AddIfNotExistsElseUpdate(theC.ActualUnit.ObjectID, theC);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101052", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal void DistributeWeaponQuantityInSalvos()
	{
		try
		{
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 1034560437990", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void AddBaseContact(Contact theC)
	{
		try
		{
			NewBaseContactsQueue.Add(theC.ActualUnit.ObjectID, theC);
			theC.ActualUnit.Name.Contains("Wierd");
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101053", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void DropContact(Contact theC, ref Scenario theScen, bool LogMessage)
	{
		int count = default(int);
		try
		{
			if (!Contacts.ContainsKey(theC.ActualUnit.ObjectID))
			{
				return;
			}
			DroppedContactsQueue.AddIfNotExists(theC.ActualUnit.ObjectID, theC);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			string theObjectID = "";
			foreach (KeyValuePair<string, Contact> item in vmethod_0())
			{
				if (item.Value == theC)
				{
					theObjectID = item.Key;
					break;
				}
			}
			vmethod_0().Remove(theObjectID);
			count = Units.Count;
			Units.InternalArray();
			int num = count - 1;
			for (int i = 0; i <= num; i++)
			{
				try
				{
					Units[i].Sensory.RemoveContact_Local(ref theObjectID);
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
			}
			ex2?.Data.Add("Error at 200061", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		ActiveUnit_AI.ExportTargetingChangeEvent("Dropping contact", theC, null, this, theScen, "");
		if (LogMessage)
		{
			if (theScen.GetCurrentSide() == this)
			{
				theScen.AddMessage("Contact " + theC.Name + " has been lost.", theC.Name + " vanished", LoggedMessage.MessageType.ContactChange, 5, null, this, new Geopoint_Struct(((Module_Unit.Unit)theC).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theC).get_Latitude((GlobalVariables.BooleanObject)null)));
			}
			else
			{
				theScen.AddMessage(Name + " :Contact " + theC.Name + " has been lost.", theC.Name + " vanished", LoggedMessage.MessageType.ContactChange, 5, null, this, new Geopoint_Struct(((Module_Unit.Unit)theC).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theC).get_Latitude((GlobalVariables.BooleanObject)null)));
			}
		}
		int num2 = count - 1;
		for (int j = 0; j <= num2; j++)
		{
			try
			{
				Units[j].Sensory.HandleContactLoss(theC);
			}
			catch (Exception projectError2)
			{
				ProjectData.SetProjectError(projectError2);
				ProjectData.ClearProjectError();
			}
		}
	}

	public void CleanFiringProposals()
	{
		List<FiringProposal> list = new List<FiringProposal>();
		ConcurrentDictionary<string, FiringProposal> firingProposals = FiringProposals;
		bool? flag = ((firingProposals == null) ? ((bool?)null) : new bool?(Misc.IsEmpty_LockFreeCheck(firingProposals)));
		if (((!flag) ?? flag) == true)
		{
			List<FiringProposal> list2 = new List<FiringProposal>(FiringProposals.Values);
			foreach (FiringProposal item in list2)
			{
				if (item.FiringUnit.IsActiveUnit)
				{
					Mission mission = ((ActiveUnit)item.FiringUnit).ActiveMissionOrPackage();
					if (mission != null && mission.MissionClass == Mission._MissionClass.Strike)
					{
						Strike strike = (Strike)mission;
						IReadOnlyCollection<Module_Unit.Unit> specificTargets = strike.SpecificTargets;
						if (specificTargets.Count > 0 && (specificTargets.Contains(item.Target) || specificTargets.Contains(item.Target.ActualUnit)) && strike.TimeOnTarget.HasValue)
						{
							DateTime? timeOnTarget = strike.TimeOnTarget;
							DateTime time = item.Target.ActualUnit.ParentScen.Time;
							if (((!timeOnTarget.HasValue) ? ((bool?)null) : new bool?(DateTime.Compare(timeOnTarget.GetValueOrDefault(), time) > 0)) == true)
							{
								continue;
							}
						}
					}
				}
				list.Add(item);
			}
		}
		foreach (FiringProposal item2 in list)
		{
			FiringProposal value = item2;
			if (value != null)
			{
				FiringProposals.TryRemove(value.ObjectID, out value);
			}
		}
	}

	public void RebuildSalvoCache()
	{
		if (tdictionary_0.Count > 0)
		{
			tdictionary_0.Clear();
		}
		if (WeaponSalvos.Count <= 0)
		{
			return;
		}
		List<WeaponSalvo> list = new List<WeaponSalvo>();
		foreach (WeaponSalvo weaponSalvo in WeaponSalvos)
		{
			if (weaponSalvo.ShootersList.Count() == 0)
			{
				list.Add(weaponSalvo);
			}
		}
		foreach (WeaponSalvo item in list)
		{
			RemoveWeaponSalvo(item);
		}
		foreach (WeaponSalvo weaponSalvo2 in WeaponSalvos)
		{
			if (!tdictionary_0.ContainsKey(weaponSalvo2.Target))
			{
				tdictionary_0.Add(weaponSalvo2.Target, new List<WeaponSalvo>(new WeaponSalvo[1] { weaponSalvo2 }));
			}
			else
			{
				tdictionary_0[weaponSalvo2.Target].Add(weaponSalvo2);
			}
		}
	}

	public void PrePulseHousekeeping(Scenario theScen)
	{
		ResetPostureCacheArray();
		Contacts_List = null;
		PooledList<Contact> contacts_List = Contacts_List;
		this.KnownActiveNuclearWeapons = null;
		try
		{
			CleanFiringProposals();
			RebuildSalvoCache();
			Cache_ContactStancesOnThisPulse.Clear();
			Cache_ContactIncomingWeapons.Clear();
			Cache_ContactsInsideNoNavZones.Clear();
			Cache_ContactsInsidePatrolAreas.Clear();
			Cache_ContactsInsideProsecutionAreas.Clear();
			Cache_UnitsAssignedToMissionOrPackage.Clear();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 10104444544", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		foreach (Contact item in contacts_List)
		{
			item.HasBeenCheckedForDestructionThisPulse = false;
		}
		List<WeaponSalvo> list = new List<WeaponSalvo>();
		try
		{
			if (WeaponSalvos != null)
			{
				foreach (WeaponSalvo weaponSalvo in WeaponSalvos)
				{
					bool flag = false;
					WeaponSalvo.Shooter[] shootersList = weaponSalvo.ShootersList;
					foreach (WeaponSalvo.Shooter shooter in shootersList)
					{
						if (shooter == null || string.IsNullOrEmpty(shooter.ShooterObjectID))
						{
							continue;
						}
						try
						{
							if (!theScen.ActiveUnits.TryGetValue(shooter.ShooterObjectID, out var value) || value == null || weaponSalvo.int_1 == 0 || value.Weaponry.TotalAvailableInventoryForThisWeapon(weaponSalvo.int_1, IncludeNonOperationalMountsAndMags: false) <= 0)
							{
								continue;
							}
							flag = true;
							break;
						}
						catch (Exception projectError)
						{
							ProjectData.SetProjectError(projectError);
							ProjectData.ClearProjectError();
						}
					}
					if (!flag)
					{
						list.Add(weaponSalvo);
					}
				}
			}
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			ex4?.Data.Add("Error at 101044445444", "");
			GameGeneral.WriteExceptionsToLog(ex4);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			foreach (WeaponSalvo item2 in list)
			{
				AttemptToRemoveWeaponSalvo(ref theScen, item2);
			}
		}
		catch (Exception ex5)
		{
			ProjectData.SetProjectError(ex5);
			Exception ex6 = ex5;
			ex6?.Data.Add("Error at 101044445445", "");
			GameGeneral.WriteExceptionsToLog(ex6);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			foreach (Mission mission in Missions)
			{
				mission.PrePulseHousekeeping(theScen);
			}
		}
		catch (Exception ex7)
		{
			ProjectData.SetProjectError(ex7);
			Exception ex8 = ex7;
			ex8?.Data.Add("Error at 101044445446", "");
			GameGeneral.WriteExceptionsToLog(ex8);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			if (theScen.AnyActiveWeaponEffectThreats)
			{
				this.get_KnownActiveNuclearWeapons(theScen);
			}
		}
		catch (Exception ex9)
		{
			ProjectData.SetProjectError(ex9);
			Exception ex10 = ex9;
			ex10?.Data.Add("Error at 101044445446", "");
			GameGeneral.WriteExceptionsToLog(ex10);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void DropBaseContact(Contact theC, ref Scenario theScen, bool LogMessage = true)
	{
		try
		{
			if (!BaseContacts.ContainsKey(theC.ActualUnit.ObjectID))
			{
				return;
			}
			DroppedBaseContactsQueue.AddIfNotExists(theC.ActualUnit.ObjectID, theC);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			string key = "";
			foreach (KeyValuePair<string, Contact> item in vmethod_2())
			{
				if (item.Value == theC)
				{
					key = item.Key;
				}
			}
			vmethod_2().Remove(key);
			ex2?.Data.Add("Error at 200062", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		if (LogMessage)
		{
			if (theScen.GetCurrentSide() == this)
			{
				theScen.AddMessage("Base contact " + theC.Name + " has been lost.", theC.Name + " vanished", LoggedMessage.MessageType.ContactChange, 5, null, this, new Geopoint_Struct(((Module_Unit.Unit)theC).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theC).get_Latitude((GlobalVariables.BooleanObject)null)));
			}
			else
			{
				theScen.AddMessage(Name + " :Base contact " + theC.Name + " has been lost.", theC.Name + " vanished", LoggedMessage.MessageType.ContactChange, 5, null, this, new Geopoint_Struct(((Module_Unit.Unit)theC).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theC).get_Latitude((GlobalVariables.BooleanObject)null)));
			}
		}
	}

	private void method_0(ActiveUnit activeUnit_1, Scenario scenario_0)
	{
		Contact value = null;
		if (vmethod_0().TryGetValue(activeUnit_1.ObjectID, out value))
		{
			value.IsAutoDetection = true;
			value.IsPreciselyLocatedOnThisPulse = true;
			value.set_IDStatus(scenario_0, this, (Sensor)null, (float?)null, IsNCTRupdate: false, StatusUpdateIsOnCommsGrid: true, bool_5: false, GenerateMessage: true, Contact_Base.IdentificationStatus.PreciseID);
		}
		else
		{
			ActiveUnit_Sensory.ProcessNewContact(ref value, ref activeUnit_1.ParentScen, this, activeUnit_1, ActiveUnit_Sensory.SpecialDetectionMode.AutoDetection, null, Contact_Base.IdentificationStatus.PreciseID);
		}
	}

	public void ProcessAutoDetectableUnits(Scenario theScen, float elapsedTime)
	{
		if (!theScen.UnitAutodetectionValidation.Contains(this))
		{
			return;
		}
		try
		{
			if (!theScen.GenerateAutoDetectableUnitsOnThisPulse)
			{
				return;
			}
			if (_AutodetectableUnitsThisPulse != null)
			{
				foreach (ActiveUnit item in _AutodetectableUnitsThisPulse)
				{
					method_0(item, theScen);
				}
				return;
			}
			KeyValuePair<string, ActiveUnit>[] array = theScen.ActiveUnits.ToArray();
			foreach (KeyValuePair<string, ActiveUnit> keyValuePair in array)
			{
				ActiveUnit value = keyValuePair.Value;
				if (value != null && value.get_UnitSide(SetSideOnly: false) != null && value.IsOperating())
				{
					HashSet<Side> friendlySidesThisPulse = value.get_UnitSide(SetSideOnly: false).FriendlySidesThisPulse;
					if (value.get_UnitSide(SetSideOnly: false) != this && (!FriendlySidesThisPulse.Contains(value.get_UnitSide(SetSideOnly: false)) || !friendlySidesThisPulse.Contains(this)) && value.get_IsEligibleForAutodetection(this))
					{
						method_0(value, theScen);
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101054", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void ProcessBaseContacts(ref Scenario theScen)
	{
		try
		{
			List<ActiveUnit> potentialBaseContacts = PotentialBaseContacts;
			if (potentialBaseContacts == null || potentialBaseContacts.Count <= 0)
			{
				return;
			}
			bool flag = default(bool);
			foreach (ActiveUnit potentialBaseContact in PotentialBaseContacts)
			{
				ActiveUnit theUnit = potentialBaseContact;
				Group obj = (Group)theUnit;
				if (obj.Type == Group.GroupType.MobileGroup)
				{
					foreach (ActiveUnit value in obj.Units.Values)
					{
						if (Contacts.ContainsKey(value.ObjectID))
						{
							flag = true;
							break;
						}
					}
					if (flag)
					{
						ActiveUnit_Sensory sensory = theUnit.Sensory;
						Side theSide = this;
						sensory.PerformBaseDetections(ref theUnit, ref theSide);
					}
				}
				else
				{
					ActiveUnit_Sensory sensory2 = theUnit.Sensory;
					Side theSide = this;
					sensory2.PerformBaseDetections(ref theUnit, ref theSide);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101055", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal void FiringProposalEvaluationAndSalvoCreation(Scenario theScen, float elapsedTime)
	{
		_Closure$__184-0 arg = default(_Closure$__184-0);
		_Closure$__184-0 CS$<>8__locals8 = new _Closure$__184-0(arg);
		CS$<>8__locals8.$VB$Local_theScen = theScen;
		CS$<>8__locals8.$VB$Local_elapsedTime = elapsedTime;
		new List<Contact>();
		PooledList<FiringProposal> pooledList;
		try
		{
			pooledList = new PooledList<FiringProposal>(FiringProposals.Values);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			pooledList = new PooledList<FiringProposal>(FiringProposals.Values);
			ProjectData.ClearProjectError();
		}
		if (!DisableMultiDomainTOT)
		{
			Parallel.ForEach(pooledList, [SpecialName] (FiringProposal firingProposal_0) =>
			{
				if (!firingProposal_0.FiringUnit.IsAircraft)
				{
					if (Needs_To_Recalculate_Weapon_ETA(firingProposal_0))
					{
						firingProposal_0.ETA = ((ActiveUnit)firingProposal_0.FiringUnit).Weaponry.RetrieveWeaponETA(firingProposal_0.Target, firingProposal_0.get_ReferenceWeapon(CS$<>8__locals8.$VB$Local_theScen));
						firingProposal_0.Distance = Module_Unit.RangeToUnit_Slant(firingProposal_0.FiringUnit, firingProposal_0.Target);
					}
					else
					{
						firingProposal_0.ETA = firingProposal_0.ETA.AddSeconds(CS$<>8__locals8.$VB$Local_elapsedTime);
					}
				}
			});
		}
		ActiveUnit activeUnit = default(ActiveUnit);
		foreach (IGrouping<Contact, FiringProposal> item in (from theTargetGroup in pooledList
			where theTargetGroup != null
			group theTargetGroup by theTargetGroup.Target).ToList())
		{
			foreach (IGrouping<int, FiringProposal> item2 in (from theWeaponGroup in item
				where theWeaponGroup != null
				group theWeaponGroup by theWeaponGroup.int_1).ToList())
			{
				foreach (FiringProposal item3 in item2.OrderBy([SpecialName] (FiringProposal theFP3) => theFP3.ETA).ToList())
				{
					bool flag = false;
					try
					{
						if (DisableMultiDomainTOT)
						{
							goto IL_0473;
						}
						Mission mission = ((ActiveUnit)item3.FiringUnit).ActiveMissionOrPackage();
						if (!((mission != null) & !item3.FiringUnit.IsAircraft))
						{
							if (!((mission != null) & item3.FiringUnit.IsAircraft) || mission.MissionClass != Mission._MissionClass.Strike)
							{
								goto IL_0473;
							}
							Aircraft aircraft = (Aircraft)item3.FiringUnit;
							if (aircraft.AI.IsEscort)
							{
								goto IL_0473;
							}
							Strike strike = (Strike)mission;
							if (strike.Type == Strike.StrikeType.Air_Intercept || !strike.get_FocusEntirelyOnStrikeTargets((ActiveUnit)aircraft) || item3.Target.get_IsSpecificTargetForThisStrike(strike))
							{
								goto IL_0473;
							}
							continue;
						}
						if (DateTime.Compare(item3.ETA, DateTime.MinValue) == 0)
						{
							int num;
							if (Debugger.IsAttached)
							{
								Debugger.Break();
								num = 5;
							}
							else
							{
								num = 5;
							}
							string[] array = new string[num];
							array[0] = "ETA for weapon ";
							array[1] = item3.get_ReferenceWeapon(CS$<>8__locals8.$VB$Local_theScen).Name;
							array[2] = " ";
							array[3] = item3.int_1.ToString();
							array[4] = " was miscalculated";
							GameGeneral.WriteExceptionsToLog(new Exception(string.Concat(array)));
						}
						if (mission.MissionClass != Mission._MissionClass.Strike)
						{
							goto IL_0473;
						}
						Strike strike2 = (Strike)mission;
						DateTime? timeOnTarget;
						DateTime eTA;
						foreach (Module_Unit.Unit specificTarget in strike2.SpecificTargets)
						{
							if (!specificTarget.IsContact())
							{
								if (specificTarget.IsActiveUnit)
								{
									activeUnit = (ActiveUnit)specificTarget;
								}
							}
							else
							{
								activeUnit = ((Contact)specificTarget).ActualUnit;
							}
							if (activeUnit != null && item3.Target.ActualUnit != null && string.CompareOrdinal(activeUnit.ObjectID, item3.Target.ActualUnit.ObjectID) == 0)
							{
								timeOnTarget = mission.TimeOnTarget;
								eTA = item3.ETA;
								if ((timeOnTarget.HasValue ? new bool?(DateTime.Compare(timeOnTarget.GetValueOrDefault(), eTA) > 0) : ((bool?)null)) == true)
								{
									flag = true;
									break;
								}
							}
						}
						timeOnTarget = mission.TimeOnTarget;
						eTA = item3.ETA;
						if (((!timeOnTarget.HasValue) ? ((bool?)null) : new bool?(DateTime.Compare(timeOnTarget.GetValueOrDefault(), eTA) > 0)) == true && !(item3.Target.IsWeapon & item3.Target.IsAircraftContact))
						{
							switch (strike2.Type)
							{
							case Strike.StrikeType.Land_Strike:
								if (item3.Target.IsLandContact)
								{
									flag = true;
								}
								break;
							case Strike.StrikeType.Maritime_Strike:
								if (item3.Target.IsShipContact)
								{
									flag = true;
								}
								break;
							case Strike.StrikeType.Sub_Strike:
								if (item3.Target.IsSubmergedContact)
								{
									flag = true;
								}
								break;
							}
						}
						if (!flag)
						{
							goto IL_0473;
						}
						goto end_IL_018e;
						IL_0473:
						if (item3.FiringUnit != null && item3.FiringUnit.IsActiveUnit)
						{
							ActiveUnit activeUnit2 = (ActiveUnit)item3.FiringUnit;
							int num2 = WRAQuantityRemainingForWeaponVsTarget_ExistingSalvos(activeUnit2, item3.Target, item3.get_ReferenceWeapon(CS$<>8__locals8.$VB$Local_theScen));
							if (num2 > 0)
							{
								bool flag2 = false;
								int num3 = activeUnit2.Weaponry.HowManyOfThisWeapon(item3.int_1);
								num3 -= GetCountOfUnfiredWeaponsFromThisShooter_ExistingSalvos(activeUnit2, item3.int_1);
								if (num3 < 1)
								{
									RemoveFireProposal(item3);
									continue;
								}
								if (num3 > num2)
								{
									num3 = num2;
								}
								foreach (WeaponSalvo weaponSalvo in WeaponSalvos)
								{
									WeaponSalvo theSalvo = weaponSalvo;
									if (theSalvo.int_1 == item3.int_1 && (theSalvo.Target == item3.Target || Operators.CompareString(theSalvo.Target.ObjectID, item3.Target.ObjectID, false) == 0))
									{
										AddShooterToExistingSalvo(ref theSalvo, num2, 0, num3, item3.ManualFire, ref activeUnit2.ObjectID);
										RemoveFireProposal(item3);
										flag2 = true;
										break;
									}
								}
								if (!flag2)
								{
									Scenario theScen2 = CS$<>8__locals8.$VB$Local_theScen;
									Weapon theWeapon = item3.get_ReferenceWeapon(CS$<>8__locals8.$VB$Local_theScen);
									AssignSalvoToTarget(theScen2, ref theWeapon, ref item3.Target, num2, 0, num3, item3.ManualFire, ref item3.FiringUnit.ObjectID, ref item3.ShooterQuantity, DateTime.MinValue, item3.ETA);
									RemoveFireProposal(item3);
								}
							}
							else
							{
								RemoveFireProposal(item3);
							}
						}
						else
						{
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							RemoveFireProposal(item3);
						}
						end_IL_018e:;
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						ex2?.Data.Add("Error at 98746524324654", "");
						GameGeneral.WriteExceptionsToLog(ex2);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
				}
			}
		}
		pooledList.Dispose();
		DistributeWeaponQuantityInSalvos();
	}

	public static bool Needs_To_Recalculate_Weapon_ETA(FiringProposal theProposal)
	{
		int result;
		int result2;
		if (theProposal.FiringUnit != null)
		{
			if (theProposal.Target != null)
			{
				if (theProposal.FiringUnit.HasMoved() || theProposal.Target.HasMoved())
				{
					ActiveUnit activeUnit = (ActiveUnit)theProposal.FiringUnit;
					if (activeUnit.ActiveMissionOrPackage() != null && activeUnit.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Strike)
					{
						Strike strike = (Strike)activeUnit.ActiveMissionOrPackage();
						if (!strike.TimeOnTarget.HasValue)
						{
							result = 0;
							goto IL_0112;
						}
						double totalSeconds = (strike.TimeOnTarget.Value - activeUnit.ParentScen.Time).TotalSeconds;
						double totalSeconds2 = (theProposal.ETA - activeUnit.ParentScen.Time).TotalSeconds;
						if (totalSeconds2 <= 0.0)
						{
							return true;
						}
						totalSeconds2 *= (double)Module_Unit.RangeToUnit_Slant(activeUnit, theProposal.Target) / theProposal.Distance;
						if (totalSeconds < 1.1 * totalSeconds2)
						{
							return true;
						}
					}
				}
				result = 0;
				goto IL_0112;
			}
			result2 = 0;
		}
		else
		{
			result2 = 0;
		}
		return (byte)result2 != 0;
		IL_0112:
		return (byte)result != 0;
	}

	public static bool Needs_To_Recalculate_Weapon_ETA(Module_Unit.Unit FiringUnit, ScenarioObject Target)
	{
		int result;
		if (!(FiringUnit.HasMoved() | Target.HasMoved()))
		{
			result = 0;
		}
		else
		{
			ActiveUnit activeUnit = (ActiveUnit)FiringUnit;
			if (activeUnit.ActiveMissionOrPackage() != null && activeUnit.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Strike)
			{
				Strike strike = (Strike)activeUnit.ActiveMissionOrPackage();
				if (strike.TimeOnTarget.HasValue && (strike.TimeOnTarget.Value - activeUnit.ParentScen.Time).TotalSeconds < (double)ActiveUnit.FP_RECALC_THREASHOLD)
				{
					return true;
				}
			}
			result = 0;
		}
		return (byte)result != 0;
	}

	private void method_1(TDictionary<string, Contact> tdictionary_1)
	{
		if (tdictionary_1.Count <= 0)
		{
			return;
		}
		foreach (string key in tdictionary_1.Keys)
		{
			if (!DroppedContactsQueue.ContainsKey(key))
			{
				if (!vmethod_0().ContainsKey(key))
				{
					vmethod_0().Add(key, tdictionary_1[key]);
				}
				if (vmethod_0().TryGetValue(key, out var value) && value.OriginalDetectorSide != this)
				{
					value.RetreivedPostureOnThisPulse = false;
				}
			}
		}
		tdictionary_1.Clear();
	}

	public void ProcessContactListChanges(Scenario theScen)
	{
		try
		{
			method_1(NewContactsQueue);
			if (DroppedContactsQueue.Count > 0)
			{
				List<string> list = new List<string>(DroppedContactsQueue.Keys);
				List<ActiveUnit> list2 = new List<ActiveUnit>(Units);
				foreach (string item in list)
				{
					string theObjectID = item;
					Contact theContact = DroppedContactsQueue[theObjectID];
					RemoveWeaponSalvosForThisTarget(ref theScen, theContact);
					foreach (ActiveUnit item2 in list2)
					{
						ActiveUnit_AI aI = item2.AI;
						Side theSide = this;
						aI.HandleContactBeingDropped(ref theContact, ref theSide);
						item2.Sensory.RemoveContact_Local(ref theObjectID);
					}
					OnContactRemoved(theContact);
					vmethod_0().Remove(theObjectID);
					if (SelectedUnits.Contains(theContact))
					{
						SelectedUnits_Remove(theContact);
					}
				}
				DroppedContactsQueue.Clear();
			}
			method_1(NewContactsQueue_Forced);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101056", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void OnContactRemoved(Contact theContact)
	{
		foreach (Mission mission in Missions)
		{
			if (mission.Category == Mission.MissionCategory.TaskPool)
			{
				TaskPool taskPool = (TaskPool)mission;
				foreach (Mission package in taskPool.PackageList)
				{
					if (package.MissionClass == Mission._MissionClass.Strike)
					{
						Strike strike = (Strike)package;
						if (strike.SpecificTargets.Contains(theContact) && strike.SpecificTargetWasAutomaticallyAdded(theContact))
						{
							strike.RemoveFromSpecificTargets(theContact);
						}
					}
				}
			}
			else if (mission.MissionClass == Mission._MissionClass.Strike)
			{
				Strike strike2 = (Strike)mission;
				if (strike2.SpecificTargets.Contains(theContact) && strike2.SpecificTargetWasAutomaticallyAdded(theContact))
				{
					strike2.RemoveFromSpecificTargets(theContact);
				}
			}
		}
		foreach (ActiveUnit unit in Units)
		{
			if (theContact == unit.AI.PrimaryTarget)
			{
				unit.AI.DropTarget(theContact);
			}
		}
	}

	public void ProcessBaseContactListChanges(Scenario theScen)
	{
		try
		{
			if (NewBaseContactsQueue.Count > 0)
			{
				foreach (string key in NewBaseContactsQueue.Keys)
				{
					if (!vmethod_2().ContainsKey(key))
					{
						vmethod_2().Add(key, NewBaseContactsQueue[key]);
					}
				}
				NewBaseContactsQueue.Clear();
			}
			if (DroppedBaseContactsQueue.Count <= 0)
			{
				return;
			}
			foreach (string key2 in DroppedBaseContactsQueue.Keys)
			{
				Contact contact = DroppedBaseContactsQueue[key2];
				vmethod_2().Remove(key2);
				if (SelectedUnits.Contains(contact))
				{
					SelectedUnits_Remove(contact);
				}
			}
			DroppedBaseContactsQueue.Clear();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101057", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void MissionsTotal_Reset()
	{
		readOnlyCollection_0 = null;
	}

	public void Missions_Add(Mission theM)
	{
		if (!list_1.Contains(theM))
		{
			list_1.Add(theM);
			MissionsTotal_Reset();
			missionsChangedEventHandler_0?.Invoke(this);
		}
	}

	public void Missions_Remove(Mission theM)
	{
		switch (theM.Category)
		{
		case Mission.MissionCategory.Package:
			foreach (Mission item in list_1)
			{
				if (item.Category == Mission.MissionCategory.TaskPool)
				{
					TaskPool taskPool2 = (TaskPool)item;
					if (taskPool2.PackageList.Contains(theM))
					{
						taskPool2.PackageList.Remove(theM);
						break;
					}
				}
			}
			break;
		case Mission.MissionCategory.TaskPool:
		{
			TaskPool taskPool = (TaskPool)theM;
			for (int i = taskPool.PackageList.Count - 1; i >= 0; i += -1)
			{
				Mission theM2 = taskPool.PackageList[i];
				Missions_Remove(theM2);
			}
			break;
		}
		}
		foreach (ActiveUnit unit in Units)
		{
			if (unit != null && unit.ActiveMissionOrPackage() == theM)
			{
				Mission.MissionAssignmentAttemptResult Result = Mission.MissionAssignmentAttemptResult.None;
				unit.Set_AssignedMissionOrPackage(null, SetMissionOnly: false, IgnoreCommsState: true, ref Result);
			}
		}
		if (list_1.Remove(theM))
		{
			MissionsTotal_Reset();
			missionsChangedEventHandler_0?.Invoke(this);
		}
	}

	public void ScrubMissions(Scenario theScen)
	{
		List<Mission> list = new List<Mission>();
		foreach (Mission mission in Missions)
		{
			if (mission.ScrubIfSideIsHuman)
			{
				list.Add(mission);
			}
		}
		foreach (Mission item in list)
		{
			List<ActiveUnit> list2 = Module_Mission.UnitsAssignedToMissionOrPackage(item, theScen);
			foreach (ActiveUnit item2 in list2)
			{
				Mission.MissionAssignmentAttemptResult Result = Mission.MissionAssignmentAttemptResult.None;
				item2.Set_AssignedMissionOrPackage(null, SetMissionOnly: false, IgnoreCommsState: true, ref Result);
			}
			Missions_Remove(item);
		}
	}

	public List<ActiveUnit> Units_OperativeOnly(bool IncludeGroups)
	{
		List<ActiveUnit> list = new List<ActiveUnit>();
		List<ActiveUnit> list2 = new List<ActiveUnit>(Units);
		foreach (ActiveUnit item in list2)
		{
			if (item != null && (!item.IsGroup || IncludeGroups) && item.IsOperating())
			{
				list.Add(item);
			}
		}
		return list;
	}

	public Side(string theName, ref Scenario theScen)
	{
		fastDictionary_0 = new FastDictionary<Side, Misc.PostureStance>();
		dictionary_0 = new Dictionary<string, Misc.PostureStance>();
		IndexAtSidesList = -1;
		Enablers = default(SideEnablers);
		list_0 = new List<Module_Unit.Unit>();
		list_1 = new List<Mission>();
		list_2 = new List<ScenarioGoal>();
		SpecialActions = new Dictionary<string, SpecialAction>();
		vmethod_1(new ObservableCollections.ObservableDictionary<string, Contact>());
		vmethod_3(new System.Collections.ObjectModel.ObservableDictionary<string, Contact>());
		Contacts_NonAU = new HashSet<string>();
		NewContactsQueue_Forced = new TDictionary<string, Contact>(StringComparer.Ordinal);
		NewContactsQueue = new TDictionary<string, Contact>(StringComparer.Ordinal, useReadLock: false);
		NewBaseContactsQueue = new TDictionary<string, Contact>(StringComparer.Ordinal, useReadLock: false);
		DroppedContactsQueue = new TDictionary<string, Contact>(StringComparer.Ordinal, useReadLock: false);
		DroppedBaseContactsQueue = new TDictionary<string, Contact>(StringComparer.Ordinal);
		Units = new PooledList<ActiveUnit>();
		FriendlySidesThisPulse = new HashSet<Side>();
		PerUnitSlugtrail = new Dictionary<string, SlugTrail>();
		RefPoints = new ObservableList<ReferencePoint>();
		RefPointsTag_raw = new Dictionary<string, ReferencePointFlag>();
		RefPointsTag = new Dictionary<ReferencePointFlag, Dictionary<ReferencePoint, ReferencePoint>>();
		AAR = new _AAR();
		ExclusionZones = new List<ExclusionZone>();
		NoNavZones = new List<NoNavZone>();
		CustomEnvironmentZones = new CustomEnvironmentZone[0];
		StandardZones = new List<Zone>();
		AssignsCollectiveResponsibility = true;
		CanAutoTrackCivs = false;
		QuickJumpSlots = new Dictionary<int, QuickJumpSlot>();
		WeaponSalvos = new ObservableList<WeaponSalvo>();
		ScoringLog = new List<string>();
		Cache_ContactStancesOnThisPulse = new TDictionary<string, Misc.PostureStance>(StringComparer.Ordinal, useReadLock: false);
		Cache_ContactIncomingWeapons = new TDictionary<string, int>(StringComparer.Ordinal);
		tdictionary_0 = new TDictionary<Contact, List<WeaponSalvo>>();
		Cache_ContactsInsideNoNavZones = new TDictionary<string, bool>(StringComparer.Ordinal, useReadLock: false);
		Cache_ContactsInsidePatrolAreas = new TDictionary<(Contact, Patrol), bool>();
		Cache_ContactsInsideProsecutionAreas = new TDictionary<(Contact, Patrol), bool>();
		Cache_UnitsAssignedToMissionOrPackage = new TDictionary<Mission, List<ActiveUnit>>();
		activeUnit_0 = new ActiveUnit[0];
		hashSet_0 = new HashSet<string>();
		hashSet_1 = new HashSet<string>();
		SpecialDetections = new Queue<(Contact, ActiveUnit, List<Sensor>, float, ActiveUnit_Sensory.SpecialDetectionMode, DateTime, List<Geopoint_Struct>)>();
		AGU_Frontline = new List<AggregateGroundUnit_Frontline>();
		EmconAlertness = new EmconLevel();
		CommNetworks = new System.Collections.ObjectModel.ObservableDictionary<string, CommNetwork>();
		SelectedNetworks = new List<CommNetwork>();
		NetworkColorMap = new Dictionary<string, Color>();
		IsUnitInContactWithTheLeaderInthisPulse = new ConcurrentDictionary<string, bool>();
		NetworkLog = new ObservableCollection<string>();
		NetworkRuleRegistry = null;
		IsNature = false;
		Chalks = new List<Chalk>();
		list_9 = new List<Chalk>();
		LandingPlans = new List<LandingPlan>();
		DisableMultiDomainTOT = false;
		ContactsJustSharedWithMe = new HashSet<string>();
		lockObject_0 = new LockObject();
		postureStance_0 = new Misc.PostureStance[0];
		AddShooter = new LockObject();
		SalvoMaxDistanceToTargetList = new ConcurrentDictionary<DateTime, SalvoMaxDistanceToTarget>();
		FeedbackList = new TList<TransmissionWithFeedback>();
		MinuteFeedbackList = new TList<TransmissionWithFeedback>();
		TransmissionQueue = new TDictionary<string, List<Transmission>>();
		MinuteTransmissionQueue = new TDictionary<string, TList<Transmission>>();
		concurrentQueue_0 = new ConcurrentQueue<TransmittedContactData>();
		Scenario scenarioContext = theScen;
		List<ActiveUnit> DoctrineSelectedUnits = null;
		Doctrine = new Doctrine(scenarioContext, this, ref DoctrineSelectedUnits);
		Name = theName;
		Enablers.GNSS_GPS = true;
		Enablers.GNSS_GLONASS = true;
		Enablers.GNSS_BeiDou = true;
		Enablers.GNSS_NavIC = true;
	}

	internal void AllocatePallettizedSalvoToPalletWeapons()
	{
		lock (GameGeneral._TakeBackMySalvo_LockObj)
		{
			_Closure$__261-0 closure$__261- = default(_Closure$__261-0);
			foreach (WeaponSalvo item in GetWeaponSalvos().ToList())
			{
				WeaponSalvo theSalvo = item;
				if (DateTime.Compare(theSalvo.ScheduledFireTime, WeaponSalvo.SCHEDULE_AS_PALLETIZED_WEAPON) != 0)
				{
					continue;
				}
				int num = theSalvo.MaxNumberOfWeapons;
				try
				{
					int num2 = 0;
					WeaponSalvo.Shooter[] shootersList = theSalvo.ShootersList;
					foreach (WeaponSalvo.Shooter shooter in shootersList)
					{
						num -= shooter.QuantityFired;
						if (num2 > 0)
						{
							num -= shooter.QuantityAssigned;
						}
						num2++;
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error at 10106244", "");
					GameGeneral.WriteExceptionsToLog(ex2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				foreach (ActiveUnit item2 in Units.ToList())
				{
					ActiveUnit theAttacker = item2;
					try
					{
						if (!theAttacker.IsWeapon)
						{
							continue;
						}
						closure$__261- = new _Closure$__261-0(closure$__261-);
						closure$__261-.$VB$Local_theW = (Weapon)theAttacker;
						if (!closure$__261-.$VB$Local_theW.IsWeaponPallet || theSalvo.ShootersList.Where(closure$__261-._Lambda$__0).FirstOrDefault() == null || theSalvo.ShootersList.Where(closure$__261-._Lambda$__1).FirstOrDefault() != null)
						{
							continue;
						}
						if (closure$__261-.$VB$Local_theW.WeaponWeapons == null || closure$__261-.$VB$Local_theW.WeaponWeapons.Count == 0)
						{
							closure$__261-.$VB$Local_theW.InitializeWeaponWeaponsPallet();
						}
						foreach (WeaponRec weaponWeapon in closure$__261-.$VB$Local_theW.WeaponWeapons)
						{
							if (weaponWeapon.get_ReferenceWeapon(theAttacker.ParentScen).DBID != theSalvo.int_1 || weaponWeapon.CurrentLoad <= 0)
							{
								continue;
							}
							int num3 = weaponWeapon.CurrentLoad;
							List<WeaponSalvo> list = WeaponSalvosFromThisUnitToAnyTarget(ref theAttacker);
							foreach (WeaponSalvo item3 in list)
							{
								if (item3.int_1 != theSalvo.int_1)
								{
									continue;
								}
								WeaponSalvo.Shooter[] shootersList2 = item3.ShootersList;
								foreach (WeaponSalvo.Shooter shooter2 in shootersList2)
								{
									if (Operators.CompareString(shooter2.ShooterObjectID, closure$__261-.$VB$Local_theW.ObjectID, false) == 0)
									{
										num3 -= shooter2.QuantityAssigned + shooter2.QuantityFired;
									}
								}
							}
							if (!(num3 <= 0 || num == 0))
							{
								if (num3 < num)
								{
									theAttacker.get_UnitSide(SetSideOnly: false).AddShooterToExistingSalvo(ref theSalvo, num3, 0, num3, theManualFire: false, ref closure$__261-.$VB$Local_theW.ObjectID);
									theSalvo.ShootersList.Last().QuantityAssigned = num3;
									theSalvo.ShootersList[0].QuantityAssigned = theSalvo.ShootersList[0].QuantityAssigned - num3;
									theSalvo.MaxNumberOfShooters = theSalvo.ShootersList.Count();
									num -= num3;
								}
								else
								{
									theAttacker.get_UnitSide(SetSideOnly: false).AddShooterToExistingSalvo(ref theSalvo, num, 0, num3, theManualFire: false, ref closure$__261-.$VB$Local_theW.ObjectID);
									theSalvo.ShootersList.Last().QuantityAssigned = num;
									theSalvo.ShootersList[0].QuantityAssigned = theSalvo.ShootersList[0].QuantityAssigned - num;
									theSalvo.MaxNumberOfShooters = theSalvo.ShootersList.Count();
									num = 0;
								}
							}
						}
					}
					catch (Exception ex3)
					{
						ProjectData.SetProjectError(ex3);
						Exception ex4 = ex3;
						ex4?.Data.Add("Error at 101062444416", "");
						GameGeneral.WriteExceptionsToLog(ex4);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
				}
			}
			foreach (WeaponSalvo item4 in GetWeaponSalvos().ToList())
			{
				try
				{
					if (DateTime.Compare(item4.ScheduledFireTime, WeaponSalvo.SCHEDULE_AS_PALLETIZED_WEAPON) != 0 || item4.ShootersList.Count() == 1)
					{
						continue;
					}
					WeaponSalvo.Shooter shooter3 = item4.ShootersList.ElementAt(0);
					_ = item4.WpnQuantityAssigned;
					List<int> list2 = new List<int>();
					WeaponSalvo.Shooter[] shootersList3 = item4.ShootersList;
					foreach (WeaponSalvo.Shooter shooter4 in shootersList3)
					{
						if (Operators.CompareString(shooter4.ShooterObjectID, shooter3.ShooterObjectID, false) != 0)
						{
							list2.Add(shooter4.QuantityAssigned);
						}
					}
					if (shooter3.QuantityAssigned == 0)
					{
						ArrayExtensions.Remove(ref item4.ShootersList, shooter3);
						int num4 = 0;
						WeaponSalvo.Shooter[] shootersList4 = item4.ShootersList;
						for (int l = 0; l < shootersList4.Length; l = checked(l + 1))
						{
							shootersList4[l].QuantityAssigned = list2[num4];
							num4++;
						}
						item4.MaxNumberOfShooters = item4.ShootersList.Count();
						item4.ScheduledFireTime = WeaponSalvo.SCHEDULE_IMMEDIATELY;
					}
				}
				catch (Exception ex5)
				{
					ProjectData.SetProjectError(ex5);
					Exception ex6 = ex5;
					ex6?.Data.Add("Error at 101062440000", "");
					GameGeneral.WriteExceptionsToLog(ex6);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
		}
	}

	public void HandleUnitHasFiredWeapon(ActiveUnit theFiringUnit, Contact theTarget, WeaponRec theWR)
	{
		if (Information.IsNothing((object)theTarget))
		{
			return;
		}
		try
		{
			if (theTarget.Type == Contact_Base.ContactType.Aimpoint || theTarget.Type == Contact_Base.ContactType.ActivationPoint || theWR.get_ReferenceWeapon(theFiringUnit.ParentScen).IsDecoy || theTarget.ActualUnit == null || (theTarget.ActualUnit.get_UnitSide(SetSideOnly: false) != this && theTarget.ActualUnit.get_UnitSide(SetSideOnly: false).get_ConsidersThisSideToBe(this, (Scenario)null) != Misc.PostureStance.Friendly))
			{
				return;
			}
			using IEnumerator<Contact> enumerator = Contacts.Values.GetEnumerator();
			Contact current;
			do
			{
				if (enumerator.MoveNext())
				{
					current = enumerator.Current;
					continue;
				}
				return;
			}
			while (current.get_IsDestroyed(theFiringUnit.ParentScen) || current.ActualUnit != theFiringUnit);
			if (current.get_Stance(this) != Misc.PostureStance.Hostile && !current.ActualUnit.IsWeapon)
			{
				bool flag = false;
				string text = "";
				if (!Information.IsNothing((object)current.TimeSinceDetection_Visual) && current.TimeSinceDetection_Visual < 30f)
				{
					flag = true;
					text = " (Reason: Weapon launch was spotted visually)";
				}
				if (!flag && !Information.IsNothing((object)current.TimeSinceDetection_Infrared) && current.TimeSinceDetection_Infrared < 30f)
				{
					flag = true;
					text = " (Reason: Weapon launch was spotted via infrared)";
				}
				if (!flag && !Information.IsNothing((object)current.TimeSinceDetection_SonarPassive) && current.TimeSinceDetection_SonarPassive < 30f)
				{
					flag = true;
					text = " (Reason: Weapon launch was detected by passive sonar)";
				}
				if (flag)
				{
					current.set_Stance(this, MarkManually: false, Misc.PostureStance.Hostile);
					theFiringUnit.ParentScen.AddMessage("Contact: " + current.Name + " was observed attacking a friendly unit and is now considered as hostile!" + text, current.Name + " is HOSTILE!", LoggedMessage.MessageType.ContactChange, 0, null, this, new Geopoint_Struct(((Module_Unit.Unit)current).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)current).get_Latitude((GlobalVariables.BooleanObject)null)));
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101062", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void PasteIntermittentConfig(Alertlevels alert, ActiveEmissionInterval sourceConfig)
	{
		foreach (ActiveUnit unit in Units)
		{
			if (unit.Sensors_Cached.Length > 0)
			{
				unit.Sensory.GetIntermittentEmission().PasteConfig(alert, sourceConfig);
			}
		}
	}

	public void HandleUnitGoingInoperative(ActiveUnit theUnit)
	{
		try
		{
			if (Contacts.TryGetValue(theUnit.ObjectID, out var value))
			{
				DropContact(value, ref theUnit.ParentScen, LogMessage: true);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101063", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void SelectedUnits_Add(Module_Unit.Unit theUnit, bool WillRaiseEvent = true)
	{
		if (!list_0.Contains(theUnit))
		{
			list_0.Add(theUnit);
		}
		if (WillRaiseEvent)
		{
			selectedUnitsChangedEventHandler_0?.Invoke();
		}
	}

	public void SelectedUnits_Remove(Module_Unit.Unit theUnit)
	{
		list_0.Remove(theUnit);
		selectedUnitsChangedEventHandler_0?.Invoke();
	}

	public void SelectedUnits_Clear(bool WillRaiseEvent = true)
	{
		list_0.Clear();
		if (WillRaiseEvent)
		{
			selectedUnitsChangedEventHandler_0?.Invoke();
		}
	}

	public void RaiseSelectedUnitsChanged()
	{
		selectedUnitsChangedEventHandler_0?.Invoke();
	}

	public void HandleUnitDestruction(ActiveUnit theUnit, bool IsScenEditAction)
	{
		if (theUnit.get_UnitSide(SetSideOnly: false) == this)
		{
			return;
		}
		List<Mission.Flight> list = new List<Mission.Flight>();
		if (theUnit.IsAircraft)
		{
			Aircraft aircraft = (Aircraft)theUnit;
			if (aircraft.ActiveMissionOrPackage() != null)
			{
				if (aircraft.Navigator.HasFlight)
				{
					foreach (Mission.Flight flight in aircraft.ActiveMissionOrPackage().FlightList)
					{
						if (flight.get_Item(aircraft.ActiveMissionOrPackage(), aircraft.ParentScen).Count <= 0)
						{
							list.Add(flight);
						}
					}
				}
				foreach (Mission.Flight item in list)
				{
					Mission.Flight theSelectedFlight = item;
					Mission mission = aircraft.ActiveMissionOrPackage();
					ref Scenario parentScen = ref aircraft.ParentScen;
					Aircraft aircraft2;
					Side theSide = ((ActiveUnit)(aircraft2 = aircraft)).get_UnitSide(SetSideOnly: false);
					mission.DeleteFlight(ref parentScen, ref theSide, ref theSelectedFlight, theSelectedFlight.ObjectID);
					((ActiveUnit)aircraft2).set_UnitSide(SetSideOnly: false, theSide);
				}
			}
		}
		PooledList<Contact> pooledList = new PooledList<Contact>();
		PooledList<Contact> pooledList2 = new PooledList<Contact>();
		try
		{
			foreach (Contact value in Contacts.Values)
			{
				if (value.ActualUnit == theUnit)
				{
					pooledList.Add(value);
				}
			}
			foreach (Contact item2 in pooledList)
			{
				DropContact(item2, ref theUnit.ParentScen, !IsScenEditAction);
				if (SelectedUnits.Contains(item2))
				{
					SelectedUnits_Remove(item2);
				}
			}
			foreach (Contact value2 in BaseContacts.Values)
			{
				if (value2.ActualUnit == theUnit)
				{
					pooledList2.Add(value2);
				}
			}
			foreach (Contact item3 in pooledList2)
			{
				DropBaseContact(item3, ref theUnit.ParentScen, !IsScenEditAction);
				if (SelectedUnits.Contains(item3))
				{
					SelectedUnits_Remove(item3);
				}
			}
			ref Scenario parentScen2 = ref theUnit.ParentScen;
			Side theSide = this;
			MissionPlanner.UpdateMissionWaypoints_AirborneAircraft(0f, ref parentScen2, ref theSide, ref theUnit);
			pooledList.Dispose();
			pooledList2.Dispose();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101064", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void DiscardExpiredContacts(Scenario theScen)
	{
		try
		{
			PooledList<Contact> pooledList = new PooledList<Contact>();
			foreach (Contact value in Contacts.Values)
			{
				if (value.IsDueToExpire())
				{
					pooledList.Add(value);
				}
			}
			foreach (Contact item in pooledList)
			{
				DropContact(item, ref theScen, this == theScen.GetCurrentSide());
			}
			pooledList.Dispose();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 300011", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal bool HasDetectedThisUnit(ActiveUnit theUnit)
	{
		return Contacts.Values.Where([SpecialName] (Contact theC) => theC.ActualUnit == theUnit).Count() > 0;
	}

	public void ResetPostureCacheArray()
	{
		int num = postureStance_0.Length - 1;
		for (int i = 0; i <= num; i++)
		{
			postureStance_0[i] = Misc.PostureStance.Unknown;
		}
	}

	public void GetAllAlliedSides(Scenario theScen, HashSet<string> AlliesList)
	{
		try
		{
			Side[] sides_ReadOnly = theScen.Sides_ReadOnly;
			foreach (Side side in sides_ReadOnly)
			{
				if (side != this && Module_Side.IsAlliedWithThisSide(this, side))
				{
					AlliesList.Add(side.ObjectID);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101066", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void GetAllFriendlySides(Scenario theScen, ref HashSet<string> FriendsList)
	{
		try
		{
			Side[] sides_ReadOnly = theScen.Sides_ReadOnly;
			foreach (Side side in sides_ReadOnly)
			{
				if (side != this && this.get_ConsidersThisSideToBe(side, (Scenario)null) == Misc.PostureStance.Friendly)
				{
					FriendsList.Add(side.ObjectID);
				}
			}
			string[] array = FriendsList.ToArray();
			_Closure$__278-0 closure$__278- = default(_Closure$__278-0);
			for (int j = 0; j < array.Length; j = checked(j + 1))
			{
				closure$__278- = new _Closure$__278-0(closure$__278-);
				closure$__278-.$VB$Local_sideHash = array[j];
				Misc.PostureStance value = default(Misc.PostureStance);
				Side side2 = theScen.Sides_ReadOnly.First(closure$__278-._Lambda$__0);
				if (fastDictionary_0.TryGetValue(side2, out value) && value != Misc.PostureStance.Friendly)
				{
					FriendsList.Remove(side2.ObjectID);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101066", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void GetAllFriendlySides(Scenario theScen, ref HashSet<Side> FriendsList)
	{
		try
		{
			Side[] sides_ReadOnly = theScen.Sides_ReadOnly;
			foreach (Side side in sides_ReadOnly)
			{
				if (side != this && this.get_ConsidersThisSideToBe(side, (Scenario)null) == Misc.PostureStance.Friendly)
				{
					FriendsList.Add(side);
				}
			}
			foreach (Side Friends in FriendsList)
			{
				Misc.PostureStance value = default(Misc.PostureStance);
				if (fastDictionary_0.TryGetValue(Friends, out value) && value != Misc.PostureStance.Friendly)
				{
					FriendsList.Remove(Friends);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101066", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_2(object sender, NotifyDictionaryChangedEventArgs<string, Contact> e)
	{
		BaseContacts_List = null;
		switch (e.Action)
		{
		case NotifyCollectionChangedAction.Add:
			baseContactAddedEventHandler_0?.Invoke(ObjectID, e.NewItem.Value.ActualUnit.ObjectID);
			break;
		case NotifyCollectionChangedAction.Remove:
			baseContactRemovedEventHandler_0?.Invoke(ObjectID, e.OldItem.Value.ActualUnit.ObjectID);
			break;
		case NotifyCollectionChangedAction.Reset:
		{
			foreach (KeyValuePair<string, Contact> oldItem in e.OldItems)
			{
				baseContactRemovedEventHandler_0?.Invoke(ObjectID, oldItem.Value.ActualUnit.ObjectID);
			}
			break;
		}
		case NotifyCollectionChangedAction.Replace:
		case NotifyCollectionChangedAction.Move:
			break;
		}
	}

	public ReadOnlyCollection<WeaponSalvo> GetWeaponSalvos()
	{
		List<WeaponSalvo> list = new List<WeaponSalvo>();
		list.AddRange(WeaponSalvos);
		return list.AsReadOnly();
	}

	public void AddFiringProposal(ActiveUnit theUnit, Weapon theWeapon, int? theWeaponQuantityToFire, int? theWeaponQuantityAvailable, Contact theTarget, DateTime theETA)
	{
		try
		{
			if (FiringProposals == null)
			{
				FiringProposals = new ConcurrentDictionary<string, FiringProposal>(StringComparer.Ordinal);
			}
			if (FiringProposals.Count > 0)
			{
				List<FiringProposal> list = new List<FiringProposal>(FiringProposals.Values);
				foreach (FiringProposal item in list)
				{
					if (Operators.CompareString(item.FiringUnit.ObjectID, theUnit.ObjectID, false) == 0 && Operators.CompareString(item.Target.ObjectID, theTarget.ObjectID, false) == 0)
					{
						return;
					}
				}
			}
			FiringProposal firingProposal = new FiringProposal();
			firingProposal.FiringUnit = theUnit;
			firingProposal.QuantityToFire = theWeaponQuantityToFire;
			firingProposal.QuantityAvailable = theWeaponQuantityAvailable;
			firingProposal.Target = theTarget;
			firingProposal.int_1 = theWeapon.DBID;
			if (theETA.Equals(DateTime.MinValue))
			{
				firingProposal.Distance = Module_Unit.RangeToUnit_Slant(theUnit, theTarget);
			}
			else
			{
				firingProposal.ETA = theETA;
				firingProposal.Distance = Module_Unit.RangeToUnit_Slant(theUnit, theTarget);
			}
			GlobalVariables.BooleanObject EmitterClassificable = null;
			Doctrine._WRA_WeaponTargetType theTargetType = Contact.WRA_DetermineTargetType(ref theTarget, theWeapon, ref EmitterClassificable);
			Doctrine._WRA_WeaponTargetType selectedNodeTargetType = Doctrine.WRA_ConvertWeaponTargetTypeToWRA_TargetType(ref theWeapon, ref theTarget, ref theTargetType, ObjectID);
			Doctrine doctrine = theUnit.Doctrine;
			Scenario parentScen = theUnit.ParentScen;
			Weapon theWeapon2 = theWeapon;
			int? TargetType_InheritedShooterQty = null;
			int? TargetType_UnspecifiedShooterQty = null;
			int? num = Doctrine.WRA_ShooterQty_AnyTargetType(doctrine, parentScen, theWeapon2, selectedNodeTargetType, FindInheritedValuesOnly: false, ref TargetType_InheritedShooterQty, ref TargetType_UnspecifiedShooterQty);
			TargetType_UnspecifiedShooterQty = num;
			if (((!TargetType_UnspecifiedShooterQty.HasValue) ? ((bool?)null) : new bool?(TargetType_UnspecifiedShooterQty == -99)) == true)
			{
				num = int.MaxValue;
			}
			if (!num.HasValue)
			{
				num = 1;
			}
			firingProposal.ShooterQuantity = num;
			FiringProposals.TryAdd(firingProposal.ObjectID, firingProposal);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 5452154874321324447", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void RemoveFireProposal(ActiveUnit theUnit, Contact theTarget)
	{
		if (theUnit == null || theTarget == null || FiringProposals == null)
		{
			return;
		}
		IEnumerator<KeyValuePair<string, FiringProposal>> enumerator = FiringProposals.GetEnumerator();
		while (enumerator.MoveNext())
		{
			FiringProposal value = enumerator.Current.Value;
			if (Operators.CompareString(value.FiringUnit.ObjectID, theUnit.ObjectID, false) == 0 && Operators.CompareString(value.Target.ObjectID, theTarget.ObjectID, false) == 0)
			{
				FiringProposals.TryRemove(value.ObjectID, out value);
				break;
			}
		}
	}

	public void RemoveFireProposal(FiringProposal theFPToRemove)
	{
		Module_Unit.Unit firingUnit = theFPToRemove.FiringUnit;
		Contact target = theFPToRemove.Target;
		if ((firingUnit != null && target != null) & (FiringProposals != null))
		{
			FiringProposal value = new List<FiringProposal>(FiringProposals.Values).Where([SpecialName] (FiringProposal theFP) => (Operators.CompareString(theFP.FiringUnit.ObjectID, firingUnit.ObjectID, false) == 0) & (Operators.CompareString(theFP.Target.ObjectID, target.ObjectID, false) == 0)).FirstOrDefault();
			if (value != null)
			{
				FiringProposals.TryRemove(value.ObjectID, out value);
			}
		}
	}

	public List<WeaponSalvo> WeaponSalvosForThisTarget(Contact theTarget)
	{
		List<WeaponSalvo> result;
		try
		{
			result = ((theTarget == null) ? new List<WeaponSalvo>() : ((!tdictionary_0.TryGetValue(theTarget, out var value)) ? new List<WeaponSalvo>() : value));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200549", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new List<WeaponSalvo>();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public List<Weapon> WeaponsLeftToFireAtThisTarget(ref ActiveUnit theAttacker, ref Contact theTarget)
	{
		List<Weapon> list = new List<Weapon>();
		List<Weapon> result;
		try
		{
			List<WeaponSalvo> list2 = new List<WeaponSalvo>(theAttacker.get_UnitSide(SetSideOnly: false).WeaponSalvos);
			for (int i = list2.Count - 1; i >= 0; i += -1)
			{
				WeaponSalvo weaponSalvo = list2[i];
				if (theTarget != weaponSalvo?.Target)
				{
					continue;
				}
				WeaponSalvo.Shooter[] shootersList = weaponSalvo.ShootersList;
				for (int j = 0; j < shootersList.Length; j = checked(j + 1))
				{
					if (Operators.CompareString(shootersList[j].ShooterObjectID, theAttacker.ObjectID, false) == 0)
					{
						list.Add(weaponSalvo.get_ReferenceWeapon(theAttacker.ParentScen));
					}
				}
			}
			result = list;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200550", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new List<Weapon>();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public int NumberOfAnyWeaponTypesOnThisUnitLeftToFireAtThisTarget(ref ActiveUnit theAttacker, ref Contact theTarget, [Optional][DefaultParameterValue(0)] ref ActiveUnit_AI.TargetingEntry._TargetingBehavior theTargetBehaviour)
	{
		int count = theAttacker.get_UnitSide(SetSideOnly: false).WeaponSalvos.Count;
		int result;
		try
		{
			int num = count - 1;
			int num2 = default(int);
			while (true)
			{
				WeaponSalvo weaponSalvo;
				if (num >= 0)
				{
					try
					{
						if (theAttacker.get_UnitSide(SetSideOnly: false).WeaponSalvos.Count != 0)
						{
							if (theAttacker.get_UnitSide(SetSideOnly: false).WeaponSalvos.Count - 1 < num)
							{
								num = theAttacker.get_UnitSide(SetSideOnly: false).WeaponSalvos.Count - 1;
							}
							weaponSalvo = theAttacker.get_UnitSide(SetSideOnly: false).WeaponSalvos[num];
							goto IL_00bd;
						}
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						ex2?.Data.Add("Error at 200651", ex2.Message);
						GameGeneral.WriteExceptionsToLog(ex2);
						_ = Debugger.IsAttached;
						ProjectData.ClearProjectError();
					}
					goto IL_01bd;
				}
				result = num2;
				break;
				IL_01bd:
				num += -1;
				continue;
				IL_00bd:
				if (weaponSalvo != null && theTarget == weaponSalvo.Target)
				{
					for (int i = weaponSalvo.ShootersList.Length - 1; i >= 0; i += -1)
					{
						WeaponSalvo.Shooter shooter;
						try
						{
							if (weaponSalvo.ShootersList.Length != 0)
							{
								if (weaponSalvo.ShootersList.Length - 1 < i)
								{
									i = weaponSalvo.ShootersList.Length - 1;
								}
								shooter = weaponSalvo.ShootersList[i];
								goto IL_015c;
							}
						}
						catch (Exception ex3)
						{
							ProjectData.SetProjectError(ex3);
							Exception ex4 = ex3;
							ex4?.Data.Add("Error at 200467", ex4.Message);
							GameGeneral.WriteExceptionsToLog(ex4);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
						continue;
						IL_015c:
						if (Information.IsNothing((object)shooter) || Operators.CompareString(shooter.ShooterObjectID, theAttacker.ObjectID, false) != 0)
						{
							continue;
						}
						if (shooter.QuantityAssigned != int.MaxValue)
						{
							if (shooter.QuantityAssigned - shooter.QuantityFired > 0)
							{
								num2 += shooter.QuantityAssigned - shooter.QuantityFired;
								if (weaponSalvo.ManualFire)
								{
									theTargetBehaviour = ActiveUnit_AI.TargetingEntry._TargetingBehavior.ManualWeaponAlloc;
								}
							}
							continue;
						}
						result = shooter.QuantityAssigned;
						goto end_IL_0018;
					}
				}
				goto IL_01bd;
				continue;
				end_IL_0018:
				break;
			}
		}
		catch (Exception ex5)
		{
			ProjectData.SetProjectError(ex5);
			Exception ex6 = ex5;
			ex6?.Data.Add("Error at 200551", ex6.Message);
			GameGeneral.WriteExceptionsToLog(ex6);
			int num3;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num3 = 0;
			}
			else
			{
				num3 = 0;
			}
			result = num3;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public int NumberOfThisWeaponOnThisUnitLeftToFireAtAnyTarget(ref ActiveUnit theAttacker, Weapon theWeapon, bool PalletWeaponQuantity = false, bool bool_1 = false)
	{
		int result;
		try
		{
			int num = default(int);
			foreach (WeaponSalvo weaponSalvo in theAttacker.get_UnitSide(SetSideOnly: false).WeaponSalvos)
			{
				if (theWeapon.DBID == weaponSalvo.int_1)
				{
					WeaponSalvo.Shooter[] shootersList = weaponSalvo.ShootersList;
					foreach (WeaponSalvo.Shooter shooter in shootersList)
					{
						if (Operators.CompareString(shooter.ShooterObjectID, theAttacker.ObjectID, false) != 0)
						{
							continue;
						}
						if (shooter.QuantityAssigned != int.MaxValue)
						{
							if (shooter.QuantityAssigned - shooter.QuantityFired > 0)
							{
								num += shooter.QuantityAssigned - shooter.QuantityFired;
							}
							continue;
						}
						result = shooter.QuantityAssigned;
						goto end_IL_0001;
					}
					continue;
				}
				if (num == 0 && !bool_1 && theWeapon.Warheads.Count() > 0)
				{
					Warhead[] warheads = weaponSalvo.get_ReferenceWeapon(theAttacker.ParentScen).Warheads;
					foreach (Warhead warhead in warheads)
					{
						if (warhead.get_CarriedWeapon(theAttacker.ParentScen) == null)
						{
							continue;
						}
						int num2 = NumberOfThisWeaponOnThisUnitLeftToFireAtAnyTarget(ref theAttacker, warhead.get_CarriedWeapon(theAttacker.ParentScen), PalletWeaponQuantity: false, bool_1: true);
						if (num2 <= 0)
						{
							continue;
						}
						result = num2;
						goto end_IL_0001;
					}
				}
				if (!theAttacker.IsPalletWeapon || ((Weapon)theAttacker).Warheads.Count() <= 0)
				{
					continue;
				}
				foreach (WeaponRec weaponWeapon in ((Weapon)theAttacker).WeaponWeapons)
				{
					if (weaponWeapon.get_ReferenceWeapon(theAttacker.ParentScen).DBID == theWeapon.DBID)
					{
						_ = weaponWeapon.CurrentLoad;
					}
				}
			}
			result = num;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200552", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			int num3;
			if (!Debugger.IsAttached)
			{
				num3 = 0;
			}
			else
			{
				Debugger.Break();
				num3 = 0;
			}
			result = num3;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public int NumberOfAnyWeaponTypesOnThisUnitLeftToFireAtAnyTarget(ref ActiveUnit theAttacker)
	{
		int result;
		try
		{
			PooledList<WeaponSalvo> pooledList = new PooledList<WeaponSalvo>(theAttacker.get_UnitSide(SetSideOnly: false).WeaponSalvos);
			int num = default(int);
			foreach (WeaponSalvo item in pooledList)
			{
				WeaponSalvo.Shooter[] shootersList = item.ShootersList;
				foreach (WeaponSalvo.Shooter shooter in shootersList)
				{
					if (Operators.CompareString(shooter.ShooterObjectID, theAttacker.ObjectID, false) != 0)
					{
						continue;
					}
					if (shooter.QuantityAssigned != int.MaxValue)
					{
						if (shooter.QuantityAssigned - shooter.QuantityFired > 0)
						{
							num += shooter.QuantityAssigned - shooter.QuantityFired;
						}
						continue;
					}
					result = shooter.QuantityAssigned;
					goto end_IL_0001;
				}
			}
			pooledList.Dispose();
			result = num;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200553", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			int num2;
			if (!Debugger.IsAttached)
			{
				num2 = 0;
			}
			else
			{
				Debugger.Break();
				num2 = 0;
			}
			result = num2;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public PooledList<WeaponSalvo> WeaponSalvosFromThisUnitToThisTarget(ref ActiveUnit theAttacker, Module_Unit.Unit theTarget, bool CompareTargetID = false)
	{
		PooledList<WeaponSalvo> pooledList = null;
		PooledList<WeaponSalvo> result;
		try
		{
			ObservableList<WeaponSalvo> weaponSalvos = theAttacker.get_UnitSide(SetSideOnly: false).WeaponSalvos;
			for (int i = weaponSalvos.Count - 1; i >= 0; i += -1)
			{
				try
				{
					WeaponSalvo weaponSalvo = weaponSalvos[i];
					if (theTarget != weaponSalvo?.Target && (!CompareTargetID || Operators.CompareString(theTarget.ObjectID, weaponSalvo?.Target.ObjectID, false) != 0))
					{
						continue;
					}
					WeaponSalvo.Shooter[] shootersList = weaponSalvo.ShootersList;
					for (int j = 0; j < shootersList.Length; j = checked(j + 1))
					{
						if (Operators.CompareString(shootersList[j].ShooterObjectID, theAttacker.ObjectID, false) == 0)
						{
							if (pooledList == null)
							{
								pooledList = new PooledList<WeaponSalvo>();
							}
							pooledList.Add(weaponSalvo);
						}
					}
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
			}
			result = pooledList;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200554", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new PooledList<WeaponSalvo>();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public List<WeaponSalvo> WeaponSalvosFromThisUnitToAnyTarget(ref ActiveUnit theAttacker)
	{
		List<WeaponSalvo> list = new List<WeaponSalvo>();
		List<WeaponSalvo> result;
		try
		{
			List<WeaponSalvo> list2 = new List<WeaponSalvo>(theAttacker.get_UnitSide(SetSideOnly: false).WeaponSalvos);
			foreach (WeaponSalvo item in list2)
			{
				if (item == null)
				{
					continue;
				}
				WeaponSalvo.Shooter[] shootersList = item.ShootersList;
				foreach (WeaponSalvo.Shooter shooter in shootersList)
				{
					if (shooter != null && string.CompareOrdinal(shooter.ShooterObjectID, theAttacker.ObjectID) == 0)
					{
						list.Add(item);
					}
				}
			}
			result = list;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200555", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new List<WeaponSalvo>();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public List<WeaponSalvo> WeaponSalvosFromAnyUnitToThisTarget(ref Contact theTarget, ref Side theSide)
	{
		List<WeaponSalvo> list = new List<WeaponSalvo>();
		List<WeaponSalvo> result;
		try
		{
			foreach (WeaponSalvo weaponSalvo in theSide.WeaponSalvos)
			{
				if (theTarget == weaponSalvo.Target)
				{
					list.Add(weaponSalvo);
				}
			}
			result = list;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200556", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new List<WeaponSalvo>();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public int? ConvertSalvoWeaponQty_To_ActualQuantity(int? theWeaponQty_ToFire, ref ActiveUnit myUnit, ref Contact theTarget, ref Weapon theWeapon)
	{
		int? num = theWeaponQty_ToFire;
		int? num2 = num;
		int? result;
		int? TargetType_UnspecifiedWeaponQty;
		if ((num2.HasValue ? new bool?(num2 == -2) : ((bool?)null)) == true)
		{
			theWeaponQty_ToFire = myUnit.Weaponry.GetMissileDefenceForContact(ref theTarget);
		}
		else
		{
			num2 = num;
			if (((!num2.HasValue) ? ((bool?)null) : new bool?(num2 == -5)) == true)
			{
				theWeaponQty_ToFire = myUnit.Weaponry.GetMissileDefenceForContact(ref theTarget);
				num2 = theWeaponQty_ToFire;
				if ((num2.HasValue ? new bool?(num2 == 1) : ((bool?)null)) != true)
				{
					num2 = theWeaponQty_ToFire;
					if ((num2.HasValue ? new bool?(num2 == 2) : ((bool?)null)) != true)
					{
						num2 = theWeaponQty_ToFire;
						if (((!num2.HasValue) ? ((bool?)null) : new bool?(num2.GetValueOrDefault() > 2)) == true)
						{
							theWeaponQty_ToFire = (int)Math.Round(Math.Round((double)theWeaponQty_ToFire.Value / 2.0, 0));
						}
						goto IL_03d0;
					}
				}
				result = 1;
				goto IL_0420;
			}
			num2 = num;
			if ((num2.HasValue ? new bool?(num2 == -6) : ((bool?)null)) == true)
			{
				theWeaponQty_ToFire = myUnit.Weaponry.GetMissileDefenceForContact(ref theTarget);
				num2 = theWeaponQty_ToFire;
				bool? flag = ((!num2.HasValue) ? ((bool?)null) : new bool?(num2.GetValueOrDefault() >= 1));
				if (flag ?? true)
				{
					num2 = theWeaponQty_ToFire;
					if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() <= 4) : ((bool?)null)) == true && flag.HasValue)
					{
						result = 1;
						goto IL_0420;
					}
				}
				num2 = theWeaponQty_ToFire;
				if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() > 4) : ((bool?)null)) == true)
				{
					theWeaponQty_ToFire = (int)Math.Round(Math.Round((double)theWeaponQty_ToFire.Value / 4.0, 0));
				}
			}
			else
			{
				num2 = num;
				if ((num2.HasValue ? new bool?(num2 == -3) : ((bool?)null)) != true)
				{
					num2 = num;
					if (((!num2.HasValue) ? ((bool?)null) : new bool?(num2 == -4)) != true)
					{
						num2 = num;
						if (((!num2.HasValue) ? ((bool?)null) : new bool?(num2 == -1)) == true)
						{
							if (theWeapon.IsWeaponPallet)
							{
								theWeapon.InitializeWeaponWeaponsPallet();
								theWeapon = theWeapon.WeaponWeapons[0].get_ReferenceWeapon(myUnit.ParentScen);
							}
							GlobalVariables.BooleanObject EmitterClassificable = null;
							Doctrine doctrine = myUnit.Doctrine;
							Scenario parentScen = myUnit.ParentScen;
							Weapon theWeapon2 = theWeapon;
							Doctrine._WRA_WeaponTargetType selectedNodeTargetType = Contact.WRA_DetermineTargetType(ref theTarget, theWeapon, ref EmitterClassificable);
							num2 = null;
							TargetType_UnspecifiedWeaponQty = null;
							theWeaponQty_ToFire = Doctrine.WRA_WeaponQty_AnyTargetType(doctrine, parentScen, theWeapon2, selectedNodeTargetType, FindInheritedValuesOnly: false, ref num2, ref TargetType_UnspecifiedWeaponQty);
						}
					}
					else
					{
						theWeaponQty_ToFire = Convert.ToInt32(Math.Round(new decimal(myUnit.Weaponry.GetMissileDefenceForContact(ref theTarget) * 4), 0));
					}
				}
				else
				{
					theWeaponQty_ToFire = Convert.ToInt32(Math.Round(new decimal(myUnit.Weaponry.GetMissileDefenceForContact(ref theTarget) * 2), 0));
				}
			}
		}
		goto IL_03d0;
		IL_03d0:
		TargetType_UnspecifiedWeaponQty = theWeaponQty_ToFire;
		if (((!TargetType_UnspecifiedWeaponQty.HasValue) ? ((bool?)null) : new bool?(TargetType_UnspecifiedWeaponQty.GetValueOrDefault() < 0)) == true)
		{
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			theWeaponQty_ToFire = 1;
		}
		return theWeaponQty_ToFire;
		IL_0420:
		return result;
	}

	public bool UnassignSalvoFromTarget(WeaponSalvo theSalvo)
	{
		int result;
		if (Information.IsNothing((object)theSalvo))
		{
			result = 0;
		}
		else
		{
			if (tdictionary_0.ContainsKey(theSalvo.Target))
			{
				tdictionary_0[theSalvo.Target].Remove(theSalvo);
				return true;
			}
			result = 0;
		}
		return (byte)result != 0;
	}

	public WeaponSalvo AssignSalvoToTarget(Scenario theScen, ref Weapon theWeapon, ref Contact theTarget, int? theQuantity_ToFire, int theQuantity_Fired, int? theQuantity_Available, bool theManualFire, ref string theShooter_ObjectID, ref int? theShooterQty, [Optional][DateTimeConstant(0L)] DateTime ScheduledTime, [Optional][DateTimeConstant(0L)] DateTime ETA)
	{
		if (Information.IsNothing((object)theShooterQty))
		{
			theShooterQty = 1;
		}
		if (Information.IsNothing((object)theQuantity_ToFire))
		{
			theQuantity_ToFire = int.MaxValue;
		}
		if (Information.IsNothing((object)theQuantity_Available))
		{
			theQuantity_Available = int.MaxValue;
		}
		int? num = theQuantity_ToFire;
		int num2;
		if (((!num.HasValue) ? ((bool?)null) : new bool?(num == int.MaxValue)) == true)
		{
			theQuantity_Available = theQuantity_ToFire;
			num2 = 1;
		}
		else
		{
			num2 = 1;
		}
		bool theFireSimultaneouslyFromMultipleMounts = (byte)num2 != 0;
		int num3;
		if (theWeapon.IsTorpedo)
		{
			num3 = 0;
		}
		else if (theWeapon.IsReEntryVehicle)
		{
			num3 = 0;
		}
		else
		{
			if (!theWeapon.IsVehicleDecoy)
			{
				goto IL_00b5;
			}
			num3 = 0;
		}
		theFireSimultaneouslyFromMultipleMounts = (byte)num3 != 0;
		goto IL_00b5;
		IL_00b5:
		WeaponSalvo weaponSalvo = new WeaponSalvo(ref theWeapon.DBID, theQuantity_ToFire.Value, theQuantity_Fired, theQuantity_Available.Value, ref theTarget, ref theManualFire, theShooter_ObjectID, theShooterQty.Value, theFireSimultaneouslyFromMultipleMounts, ScheduledTime);
		AddWeaponSalvo(weaponSalvo);
		if (tdictionary_0.ContainsKey(weaponSalvo.Target))
		{
			tdictionary_0[weaponSalvo.Target].Add(weaponSalvo);
		}
		else
		{
			List<WeaponSalvo> list = new List<WeaponSalvo>();
			list.Add(weaponSalvo);
			tdictionary_0.Add(weaponSalvo.Target, list);
		}
		weaponSalvo.ETA = ETA;
		return weaponSalvo;
	}

	public void AddShooterToExistingSalvo(ref WeaponSalvo theSalvo, int? theToFireQuantity, int theQuantity_Fired, int? theAvailableQuantity, bool theManualFire, ref string theShooterObjectID, bool OverWriteSalvoQuantity = false)
	{
		lock (AddShooter)
		{
			try
			{
				if (!theAvailableQuantity.HasValue)
				{
					theAvailableQuantity = int.MaxValue;
				}
				if (!theToFireQuantity.HasValue)
				{
					theToFireQuantity = int.MaxValue;
				}
				int? num = theToFireQuantity;
				if ((num.HasValue ? new bool?(num == int.MaxValue) : ((bool?)null)) == true)
				{
					theAvailableQuantity = theToFireQuantity;
				}
				if (!theManualFire)
				{
					int wpnQuantityAssigned = theSalvo.WpnQuantityAssigned;
					int maxNumberOfWeapons = theSalvo.MaxNumberOfWeapons;
					if (!OverWriteSalvoQuantity)
					{
						if (maxNumberOfWeapons != -99)
						{
							num = theAvailableQuantity;
							int num2 = maxNumberOfWeapons - wpnQuantityAssigned;
							bool? flag = ((!num.HasValue) ? ((bool?)null) : new bool?(num.GetValueOrDefault() > num2));
							if (flag ?? true)
							{
								num = theAvailableQuantity;
								bool? flag2 = ((!num.HasValue) ? ((bool?)null) : new bool?(num == int.MaxValue));
								if (((!flag2) ?? flag2) == true && flag.HasValue)
								{
									theAvailableQuantity = maxNumberOfWeapons - wpnQuantityAssigned;
								}
							}
						}
						WeaponSalvo.Shooter theAC = new WeaponSalvo.Shooter(theShooterObjectID, theAvailableQuantity.Value, theQuantity_Fired);
						ArrayExtensions.Add(ref theSalvo.ShootersList, theAC);
					}
					else
					{
						int num3 = 0;
						WeaponSalvo.Shooter[] shootersList = theSalvo.ShootersList;
						foreach (WeaponSalvo.Shooter shooter in shootersList)
						{
							num3 = ((shooter.QuantityAssigned != int.MaxValue) ? (num3 + shooter.QuantityAssigned) : int.MaxValue);
							shooter.QuantityAssigned = 0;
						}
						WeaponSalvo.Shooter theAC2 = new WeaponSalvo.Shooter(theShooterObjectID, Math.Min(theToFireQuantity.Value, theAvailableQuantity.Value), theQuantity_Fired);
						ArrayExtensions.Add(ref theSalvo.ShootersList, theAC2);
						theSalvo.ShootersList[0].QuantityAssigned = num3;
					}
					return;
				}
				WeaponSalvo.Shooter[] shootersList2 = theSalvo.ShootersList;
				foreach (WeaponSalvo.Shooter shooter2 in shootersList2)
				{
					if (Operators.CompareString(shooter2.ShooterObjectID, theShooterObjectID, false) == 0)
					{
						if (shooter2.QuantityAssigned < int.MaxValue)
						{
							shooter2.QuantityAssigned += theToFireQuantity.Value;
						}
						break;
					}
				}
				theSalvo.MaxNumberOfWeapons += theToFireQuantity.Value;
				theSalvo.ManualFire = theManualFire;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 200557", ex2.Message);
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	public void StopShootingSalvo(ref Scenario theScen, ref ActiveUnit theAU, ref Contact theTarget, ref WeaponSalvo theSalvo)
	{
		PooledList<WeaponSalvo> pooledList = new PooledList<WeaponSalvo>();
		try
		{
			List<WeaponSalvo> list = theAU.get_UnitSide(SetSideOnly: false).WeaponSalvos.ToList();
			if (list == null || list.Count == 0)
			{
				return;
			}
			int count = list.Count;
			PooledList<WeaponSalvo> pooledList2 = new PooledList<WeaponSalvo>(list);
			for (int i = count - 1; i >= 0; i += -1)
			{
				WeaponSalvo theWS = pooledList2[i];
				if (theWS == null || (theTarget != null && theWS.Target != theTarget) || (theSalvo != null && theWS != theSalvo))
				{
					continue;
				}
				List<WeaponSalvo.Shooter> list2 = new List<WeaponSalvo.Shooter>();
				WeaponSalvo.Shooter[] shootersList = theWS.ShootersList;
				for (int j = shootersList.Length - 1; j >= 0; j += -1)
				{
					WeaponSalvo.Shooter shooter = shootersList[j];
					if (theAU != null && shooter != null && Operators.CompareString(theAU.ObjectID, shooter.ShooterObjectID, false) == 0)
					{
						if (shooter.QuantityFired != 0)
						{
							shooter.QuantityAssigned = shooter.QuantityFired;
							break;
						}
						DetonateSalvoWeapons(ref theScen, null, shooter.ShooterObjectID, ref theWS);
						list2.Add(shooter);
						break;
					}
				}
				foreach (WeaponSalvo.Shooter item in list2)
				{
					ArrayExtensions.Remove(ref theWS.ShootersList, item);
					pooledList.Add(theWS);
				}
			}
			for (int k = pooledList.Count - 1; k >= 0; k += -1)
			{
				WeaponSalvo theWS = pooledList[k];
				AttemptToRemoveWeaponSalvo(ref theScen, theWS);
			}
			pooledList2.Dispose();
			pooledList.Dispose();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200558", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void RemoveWeaponFromSalvos(ref Scenario theScen, ref string theWeapon_ObjectID)
	{
		try
		{
			List<WeaponSalvo> list = new List<WeaponSalvo>();
			if (WeaponSalvos == null)
			{
				return;
			}
			foreach (WeaponSalvo weaponSalvo in WeaponSalvos)
			{
				if (weaponSalvo == null)
				{
					continue;
				}
				List<string> list2 = new List<string>();
				if (weaponSalvo.WeaponList != null)
				{
					foreach (string key in weaponSalvo.WeaponList.Keys)
					{
						if (key != null && Operators.CompareString(key, theWeapon_ObjectID, false) == 0)
						{
							list2.Add(theWeapon_ObjectID);
							break;
						}
					}
				}
				if (list2 == null)
				{
					continue;
				}
				foreach (string item in list2)
				{
					if (item != null)
					{
						if (weaponSalvo.WeaponList != null)
						{
							ConcurrentDictionary<string, byte> weaponList = weaponSalvo.WeaponList;
							byte value = 0;
							weaponList.TryRemove(item, out value);
						}
						if (list == null)
						{
							list = new List<WeaponSalvo>();
						}
						list.Add(weaponSalvo);
					}
				}
			}
			foreach (WeaponSalvo item2 in list)
			{
				AttemptToRemoveWeaponSalvo(ref theScen, item2);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200559", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void DetonateSalvoWeapons(ref Scenario theScen, Contact theTarget, string theShooter, ref WeaponSalvo theWS)
	{
		if (theTarget == null || theTarget.ActualUnit == null)
		{
			return;
		}
		_Closure$__301-0 arg = default(_Closure$__301-0);
		_Closure$__301-0 CS$<>8__locals5 = new _Closure$__301-0(arg);
		string[] array = theWS.WeaponList.Keys.ToArray();
		string theReason = default(string);
		for (int i = array.Length - 1; i >= 0; i += -1)
		{
			CS$<>8__locals5.$VB$Local_theWeaponObjectID = array[i];
			if (!(string.IsNullOrEmpty(CS$<>8__locals5.$VB$Local_theWeaponObjectID) | string.IsNullOrWhiteSpace(CS$<>8__locals5.$VB$Local_theWeaponObjectID)) && theScen.UnguidedWeapons.ContainsKey(CS$<>8__locals5.$VB$Local_theWeaponObjectID))
			{
				UnguidedWeapon unguidedWeapon = theScen.UnguidedWeapons.Values.Where([SpecialName] (UnguidedWeapon theW) => Operators.CompareString(theW.ObjectID, CS$<>8__locals5.$VB$Local_theWeaponObjectID, false) == 0).ElementAtOrDefault(0);
				if (unguidedWeapon != null && (unguidedWeapon.Type == Weapon._WeaponType.IronBomb || unguidedWeapon.Type == Weapon._WeaponType.Rocket || unguidedWeapon.Type == Weapon._WeaponType.DepthCharge))
				{
					ActiveUnit actualUnit = theTarget.ActualUnit;
					LockRandom theRNG = GameGeneral.GlobalRNG;
					unguidedWeapon.Impact_CEP(actualUnit, theTarget, ref theScen, ref theRNG, theReason);
					unguidedWeapon.DestroyMe(ref theScen, theReason);
				}
			}
		}
	}

	public void RemoveWeaponSalvosForThisTarget(ref Scenario theScen, Contact theTarget)
	{
		try
		{
			List<WeaponSalvo> list = new List<WeaponSalvo>();
			if (WeaponSalvos == null)
			{
				return;
			}
			for (int i = WeaponSalvos.Count - 1; i >= 0; i += -1)
			{
				WeaponSalvo theWS = WeaponSalvos[i];
				if (theWS == null || theWS.Target != theTarget)
				{
					continue;
				}
				try
				{
					DetonateSalvoWeapons(ref theScen, theTarget, null, ref theWS);
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error at 2005641", ex2.Message);
					GameGeneral.WriteExceptionsToLog(ex2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				if (WeaponSalvos.Contains(theWS))
				{
					list.Add(theWS);
				}
			}
			for (int j = list.Count - 1; j >= 0; j += -1)
			{
				WeaponSalvo theWS = list[j];
				if (WeaponSalvos != null)
				{
					RemoveWeaponSalvo(theWS);
					continue;
				}
				break;
			}
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			ex4?.Data.Add("Error at 200564", ex4.Message);
			GameGeneral.WriteExceptionsToLog(ex4);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void RemoveUnitFromSalvos(ref Scenario theScen, string theUnit_ObjectID)
	{
		try
		{
			List<WeaponSalvo> list = new List<WeaponSalvo>();
			if (WeaponSalvos == null)
			{
				return;
			}
			WeaponSalvo theWS = default(WeaponSalvo);
			for (int i = WeaponSalvos.Count - 1; i >= 0; i += -1)
			{
				theWS = WeaponSalvos[i];
				if (theWS == null)
				{
					continue;
				}
				List<WeaponSalvo.Shooter> list2 = new List<WeaponSalvo.Shooter>();
				for (int j = theWS.ShootersList.Length - 1; j >= 0; j += -1)
				{
					WeaponSalvo.Shooter shooter = theWS.ShootersList[j];
					if (shooter == null || Operators.CompareString(shooter.ShooterObjectID, theUnit_ObjectID, false) != 0)
					{
						continue;
					}
					try
					{
						DetonateSalvoWeapons(ref theScen, null, theUnit_ObjectID, ref theWS);
						if (theWS.ShootersList.Contains(shooter))
						{
							list2.Add(shooter);
						}
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						ex2?.Data.Add("Error at 2005631", ex2.Message);
						GameGeneral.WriteExceptionsToLog(ex2);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
						continue;
					}
					break;
				}
				foreach (WeaponSalvo.Shooter item in list2)
				{
					ArrayExtensions.Remove(ref theWS.ShootersList, item);
					if (list == null)
					{
						list = new List<WeaponSalvo>();
					}
					list.Add(theWS);
				}
			}
			if (list == null)
			{
				return;
			}
			for (int k = list.Count - 1; k >= 0; k += -1)
			{
				if (theWS == null)
				{
					continue;
				}
				theWS = list[k];
				try
				{
					AttemptToRemoveWeaponSalvo(ref theScen, theWS);
				}
				catch (Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					Exception ex4 = ex3;
					ex4?.Data.Add("Error at 2005632", ex4.Message);
					GameGeneral.WriteExceptionsToLog(ex4);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
		}
		catch (Exception ex5)
		{
			ProjectData.SetProjectError(ex5);
			Exception ex6 = ex5;
			ex6?.Data.Add("Error at 200563", ex6.Message);
			GameGeneral.WriteExceptionsToLog(ex6);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void RemoveThisUnitFromThisSalvos(ref Scenario theScen, string theUnit_ObjectID, ref WeaponSalvo theSalvo)
	{
		try
		{
			List<WeaponSalvo> list = new List<WeaponSalvo>();
			for (int i = WeaponSalvos.Count - 1; i >= 0; i += -1)
			{
				WeaponSalvo theWS = WeaponSalvos[i];
				if (theWS != theSalvo)
				{
					continue;
				}
				List<WeaponSalvo.Shooter> list2 = new List<WeaponSalvo.Shooter>();
				for (int j = theWS.ShootersList.Length - 1; j >= 0; j += -1)
				{
					WeaponSalvo.Shooter shooter = theWS.ShootersList[j];
					if (Operators.CompareString(shooter.ShooterObjectID, theUnit_ObjectID, false) == 0)
					{
						DetonateSalvoWeapons(ref theScen, null, theUnit_ObjectID, ref theWS);
						if (theWS.ShootersList.Contains(shooter))
						{
							list2.Add(shooter);
						}
						break;
					}
				}
				foreach (WeaponSalvo.Shooter item in list2)
				{
					ArrayExtensions.Remove(ref theWS.ShootersList, item);
					list.Add(theWS);
				}
			}
			for (int k = list.Count - 1; k >= 0; k += -1)
			{
				WeaponSalvo theWS = list[k];
				AttemptToRemoveWeaponSalvo(ref theScen, theWS);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200562", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void AttemptToRemoveWeaponSalvo(ref Scenario theScen, WeaponSalvo theWS, bool byUser = false)
	{
		try
		{
			if (theWS.WeaponList.Count > 0)
			{
				return;
			}
			if (theWS.WpnQuantityFired < theWS.WpnQuantityAssigned)
			{
				if (theWS.ShootersList.Length > 0)
				{
					if (theWS.WeaponList.Count != 0 || theWS.WpnQuantityFired <= 0 || (theWS.ManualFire && (!theWS.ManualFire || !SimConfiguration.DefaultGamePreferences.SalvoTimeout)))
					{
						return;
					}
					if (theWS.FireSimultaneouslyFromMultipleMounts)
					{
						if (!theWS.ManualFire)
						{
							lock (WeaponSalvos)
							{
								RemoveWeaponSalvo(theWS);
								return;
							}
						}
						return;
					}
					WeaponSalvo.Shooter[] shootersList = theWS.ShootersList;
					for (int i = 0; i < shootersList.Length; i = checked(i + 1))
					{
						if (shootersList[i].TimeToNextLaunch > 0)
						{
							return;
						}
					}
					if (!theWS.ManualFire || theWS.get_ReferenceWeapon(theScen).Guidance != Weapon.WeaponGuidanceType.CommandGuided_Datalinked)
					{
						lock (WeaponSalvos)
						{
							RemoveWeaponSalvo(theWS);
							return;
						}
					}
					return;
				}
				lock (WeaponSalvos)
				{
					RemoveWeaponSalvo(theWS);
					return;
				}
			}
			if (byUser)
			{
				UnassignSalvoFromTarget(theWS);
			}
			lock (WeaponSalvos)
			{
				RemoveWeaponSalvo(theWS);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 2132145751324", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public bool ExecuteManualSalvos(string RequiredTag = "")
	{
		bool result;
		try
		{
			bool flag = !string.IsNullOrEmpty(RequiredTag);
			bool flag2 = false;
			List<WeaponSalvo> list;
			lock (WeaponSalvos)
			{
				list = WeaponSalvos.ToList();
			}
			if (list != null)
			{
				foreach (WeaponSalvo item in list)
				{
					if (DateTime.Compare(item.ScheduledFireTime, WeaponSalvo.SCHEDULE_AS_MANUAL) == 0 && (!flag || Operators.CompareString(item.Tag, RequiredTag, false) == 0))
					{
						item.ScheduledFireTime = WeaponSalvo.SCHEDULE_IMMEDIATELY;
						flag2 = true;
					}
				}
				result = flag2;
			}
			else
			{
				result = false;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 2132145751324B", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			int num;
			if (!Debugger.IsAttached)
			{
				num = 0;
			}
			else
			{
				Debugger.Break();
				num = 0;
			}
			result = (byte)num != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public void MissionSalvoWeaponQty()
	{
		try
		{
			foreach (Mission mission in Missions)
			{
				if (mission.MissionClass != Mission._MissionClass.Strike)
				{
					continue;
				}
				Strike strike = (Strike)mission;
				if (strike.Type != Strike.StrikeType.Land_Strike && strike.Type != Strike.StrikeType.Maritime_Strike)
				{
					continue;
				}
				foreach (Module_Unit.Unit specificTarget in strike.SpecificTargets)
				{
					_ = specificTarget;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200561", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public int GetCountOfUnfiredWeaponsFromThisShooter_ExistingSalvos(ActiveUnit theShooter, int theWeaponDBID)
	{
		if (theShooter == null)
		{
			return 0;
		}
		int num = 0;
		int num2 = 0;
		int result = default(int);
		try
		{
			PooledList<WeaponSalvo> pooledList;
			lock (WeaponSalvos)
			{
				pooledList = new PooledList<WeaponSalvo>(WeaponSalvos);
			}
			foreach (WeaponSalvo item in pooledList)
			{
				if (item.int_1 != theWeaponDBID)
				{
					continue;
				}
				WeaponSalvo.Shooter[] shootersList = item.ShootersList;
				foreach (WeaponSalvo.Shooter shooter in shootersList)
				{
					if (Operators.CompareString(shooter.ShooterObjectID, theShooter.ObjectID, false) == 0)
					{
						num2 = shooter.QuantityAssigned - shooter.QuantityFired;
						if (num2 > 0 && num2 <= int.MaxValue - num)
						{
							num += num2;
						}
					}
				}
			}
			pooledList.Dispose();
			result = num;
			return result;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public int WRAQuantityRemainingForWeaponVsTarget_ExistingSalvos(ActiveUnit theShooter, Contact TheTarget, Weapon TheWeapon)
	{
		int result;
		if (theShooter == null)
		{
			result = 0;
		}
		else if (TheTarget != null)
		{
			if (TheWeapon != null)
			{
				Weapon theW = TheWeapon;
				GlobalVariables.BooleanObject EmitterClassificable = null;
				Doctrine._WRA_WeaponTargetType theTargetType = Contact.WRA_DetermineTargetType(ref TheTarget, theW, ref EmitterClassificable);
				Doctrine._WRA_WeaponTargetType selectedNodeTargetType = Doctrine.WRA_ConvertWeaponTargetTypeToWRA_TargetType(ref TheWeapon, ref TheTarget, ref theTargetType, theShooter.get_UnitSide(SetSideOnly: false).ObjectID);
				Doctrine doctrine = theShooter.Doctrine;
				Scenario parentScen = theShooter.ParentScen;
				Weapon theWeapon = TheWeapon;
				int? TargetType_InheritedWeaponQty = null;
				int? TargetType_UnspecifiedWeaponQty = null;
				int? theWeaponQty_ToFire = Doctrine.WRA_WeaponQty_AnyTargetType(doctrine, parentScen, theWeapon, selectedNodeTargetType, FindInheritedValuesOnly: false, ref TargetType_InheritedWeaponQty, ref TargetType_UnspecifiedWeaponQty);
				if (!theWeaponQty_ToFire.HasValue)
				{
					int result2;
					if (!Debugger.IsAttached)
					{
						result2 = 0;
					}
					else
					{
						Debugger.Break();
						result2 = 0;
					}
					return result2;
				}
				int num = theWeaponQty_ToFire.Value;
				if (num != 0)
				{
					if (num == -99)
					{
						num = int.MaxValue;
					}
					else if (num < 0)
					{
						theWeaponQty_ToFire = ConvertSalvoWeaponQty_To_ActualQuantity(theWeaponQty_ToFire, ref theShooter, ref TheTarget, ref TheWeapon);
						if (!theWeaponQty_ToFire.HasValue)
						{
							int result3;
							if (!Debugger.IsAttached)
							{
								result3 = 0;
							}
							else
							{
								Debugger.Break();
								result3 = 0;
							}
							return result3;
						}
						num = theWeaponQty_ToFire.Value;
					}
					Doctrine doctrine2 = theShooter.Doctrine;
					Scenario parentScen2 = theShooter.ParentScen;
					Weapon theWeapon2 = TheWeapon;
					TargetType_UnspecifiedWeaponQty = null;
					TargetType_InheritedWeaponQty = null;
					int? num2 = Doctrine.WRA_ShooterQty_AnyTargetType(doctrine2, parentScen2, theWeapon2, selectedNodeTargetType, FindInheritedValuesOnly: false, ref TargetType_UnspecifiedWeaponQty, ref TargetType_InheritedWeaponQty);
					if (!num2.HasValue)
					{
						int result4;
						if (Debugger.IsAttached)
						{
							Debugger.Break();
							result4 = 0;
						}
						else
						{
							result4 = 0;
						}
						return result4;
					}
					int num3 = num2.Value;
					if (num3 == -99)
					{
						if (num == int.MaxValue)
						{
							return int.MaxValue;
						}
						num3 = int.MaxValue;
					}
					if (num3 >= 1)
					{
						List<WeaponSalvo> list;
						lock (WeaponSalvos)
						{
							list = WeaponSalvos.ToList();
						}
						int num4 = 0;
						int num5 = 0;
						bool flag = false;
						if (TheWeapon.IsGuidedWeapon())
						{
							int? elementState = theShooter.Doctrine.GetElementState(Doctrine.DoctrineItem_E.MissileEngagement_WRACounting);
							if (elementState.HasValue)
							{
								switch (elementState.Value)
								{
								case 1:
									flag = TheTarget.Type == Contact_Base.ContactType.Air || TheTarget.Type == Contact_Base.ContactType.Missile;
									break;
								case 2:
									flag = TheTarget.Type == Contact_Base.ContactType.Air;
									break;
								case 3:
									flag = TheTarget.Type == Contact_Base.ContactType.Missile;
									break;
								}
							}
						}
						foreach (WeaponSalvo item in list)
						{
							if (item == null)
							{
								continue;
							}
							if (item.int_1 != TheWeapon.DBID)
							{
								if (!flag)
								{
									continue;
								}
								Weapon weapon = item.get_ReferenceWeapon(theShooter.ParentScen);
								if (weapon == null || !weapon.IsGuidedWeapon())
								{
									continue;
								}
							}
							if (item.Target == TheTarget || Operators.CompareString(item.Target.ObjectID, TheTarget.ObjectID, false) == 0)
							{
								num4 += item.ShootersList.Count();
								if (num4 >= num3)
								{
									return 0;
								}
								num5 += item.WpnQuantityAssigned;
								if (num5 >= num)
								{
									return 0;
								}
							}
						}
						if (flag)
						{
							int num6 = TheTarget.IncomingGuidedWeapons.Count();
							if (num6 > num5)
							{
								num5 = num6;
							}
						}
						return num - num5;
					}
					return 0;
				}
				return 0;
			}
			result = 0;
		}
		else
		{
			result = 0;
		}
		return result;
	}

	public int WRAQuantityRemainingForWeaponVsTarget_IncomingWeapons(ActiveUnit theShooter, Contact TheTarget, Weapon TheWeapon, bool MatchIncomingWeaponsOfAllTypes = false)
	{
		int result;
		if (theShooter == null)
		{
			result = 0;
		}
		else if (TheTarget == null)
		{
			result = 0;
		}
		else
		{
			if (TheWeapon != null)
			{
				Weapon theW = TheWeapon;
				GlobalVariables.BooleanObject EmitterClassificable = null;
				Doctrine._WRA_WeaponTargetType selectedNodeTargetType = Contact.WRA_DetermineTargetType(ref TheTarget, theW, ref EmitterClassificable);
				Doctrine doctrine = theShooter.Doctrine;
				Scenario parentScen = theShooter.ParentScen;
				Weapon theWeapon = TheWeapon;
				int? TargetType_InheritedWeaponQty = null;
				int? TargetType_UnspecifiedWeaponQty = null;
				int? theWeaponQty_ToFire = Doctrine.WRA_WeaponQty_AnyTargetType(doctrine, parentScen, theWeapon, selectedNodeTargetType, FindInheritedValuesOnly: false, ref TargetType_InheritedWeaponQty, ref TargetType_UnspecifiedWeaponQty);
				if (theWeaponQty_ToFire.HasValue)
				{
					int value = theWeaponQty_ToFire.Value;
					if (value == 0)
					{
						return 0;
					}
					if (value == -99)
					{
						return int.MaxValue;
					}
					if (value < 0)
					{
						theWeaponQty_ToFire = ConvertSalvoWeaponQty_To_ActualQuantity(theWeaponQty_ToFire, ref theShooter, ref TheTarget, ref TheWeapon);
						if (!theWeaponQty_ToFire.HasValue)
						{
							int result2;
							if (!Debugger.IsAttached)
							{
								result2 = 0;
							}
							else
							{
								Debugger.Break();
								result2 = 0;
							}
							return result2;
						}
						value = theWeaponQty_ToFire.Value;
					}
					List<Weapon> list = TheTarget.IncomingGuidedWeapons.ToList();
					if (!MatchIncomingWeaponsOfAllTypes)
					{
						int num = 0;
						foreach (Weapon item in list)
						{
							if (item.DBID == TheWeapon.DBID)
							{
								num++;
								if (num >= value)
								{
									return 0;
								}
							}
						}
						return value - num;
					}
					if (list.Count < value)
					{
						return value - list.Count;
					}
					return 0;
				}
				int result3;
				if (Debugger.IsAttached)
				{
					Debugger.Break();
					result3 = 0;
				}
				else
				{
					result3 = 0;
				}
				return result3;
			}
			result = 0;
		}
		return result;
	}

	internal int GetNextPackageNumber()
	{
		int_2++;
		return int_2;
	}

	private void method_3(object object_0, ObservableListModified<ReferencePoint> observableListModified_0)
	{
		try
		{
			foreach (ReferencePoint item in observableListModified_0.Items)
			{
				foreach (Mission item2 in list_1)
				{
					switch (item2.MissionClass)
					{
					case Mission._MissionClass.Patrol:
					{
						Patrol patrol = (Patrol)item2;
						if (patrol.PatrolArea.Contains(item))
						{
							patrol.PatrolArea.Remove(item);
						}
						if (patrol.ProsecutionArea.Contains(item))
						{
							patrol.ProsecutionArea.Remove(item);
						}
						break;
					}
					case Mission._MissionClass.Support:
					{
						SupportMission supportMission = (SupportMission)item2;
						if (supportMission.NavigationCourse.Contains(item))
						{
							supportMission.NavigationCourse.Remove(item);
						}
						break;
					}
					case Mission._MissionClass.Mining:
					{
						MiningMission miningMission = (MiningMission)item2;
						if (miningMission.Area.Contains(item))
						{
							miningMission.Area.Remove(item);
						}
						break;
					}
					case Mission._MissionClass.MineClearing:
					{
						MineClearingMission mineClearingMission = (MineClearingMission)item2;
						if (mineClearingMission.Area.Contains(item))
						{
							mineClearingMission.Area.Remove(item);
						}
						break;
					}
					case Mission._MissionClass.Cargo:
					{
						CargoMission cargoMission = (CargoMission)item2;
						if (cargoMission.Area.Contains(item))
						{
							cargoMission.Area.Remove(item);
						}
						break;
					}
					}
				}
				foreach (Zone standardZone in StandardZones)
				{
					if (standardZone.Area.Contains(item))
					{
						standardZone.Area.Remove(item);
					}
				}
				foreach (ExclusionZone exclusionZone in ExclusionZones)
				{
					if (exclusionZone.Area.Contains(item))
					{
						exclusionZone.Area.Remove(item);
					}
				}
				foreach (NoNavZone noNavZone in NoNavZones)
				{
					if (noNavZone.Area.Contains(item))
					{
						noNavZone.Area.Remove(item);
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101067", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public Side(string theName, ref Scenario theScen, bool IsNatureSide = true)
	{
		fastDictionary_0 = new FastDictionary<Side, Misc.PostureStance>();
		dictionary_0 = new Dictionary<string, Misc.PostureStance>();
		IndexAtSidesList = -1;
		Enablers = default(SideEnablers);
		list_0 = new List<Module_Unit.Unit>();
		list_1 = new List<Mission>();
		list_2 = new List<ScenarioGoal>();
		SpecialActions = new Dictionary<string, SpecialAction>();
		vmethod_1(new ObservableCollections.ObservableDictionary<string, Contact>());
		vmethod_3(new System.Collections.ObjectModel.ObservableDictionary<string, Contact>());
		Contacts_NonAU = new HashSet<string>();
		NewContactsQueue_Forced = new TDictionary<string, Contact>(StringComparer.Ordinal);
		NewContactsQueue = new TDictionary<string, Contact>(StringComparer.Ordinal, useReadLock: false);
		NewBaseContactsQueue = new TDictionary<string, Contact>(StringComparer.Ordinal, useReadLock: false);
		DroppedContactsQueue = new TDictionary<string, Contact>(StringComparer.Ordinal, useReadLock: false);
		DroppedBaseContactsQueue = new TDictionary<string, Contact>(StringComparer.Ordinal);
		Units = new PooledList<ActiveUnit>();
		FriendlySidesThisPulse = new HashSet<Side>();
		PerUnitSlugtrail = new Dictionary<string, SlugTrail>();
		RefPoints = new ObservableList<ReferencePoint>();
		RefPointsTag_raw = new Dictionary<string, ReferencePointFlag>();
		RefPointsTag = new Dictionary<ReferencePointFlag, Dictionary<ReferencePoint, ReferencePoint>>();
		AAR = new _AAR();
		ExclusionZones = new List<ExclusionZone>();
		NoNavZones = new List<NoNavZone>();
		CustomEnvironmentZones = new CustomEnvironmentZone[0];
		StandardZones = new List<Zone>();
		AssignsCollectiveResponsibility = true;
		CanAutoTrackCivs = false;
		QuickJumpSlots = new Dictionary<int, QuickJumpSlot>();
		WeaponSalvos = new ObservableList<WeaponSalvo>();
		ScoringLog = new List<string>();
		Cache_ContactStancesOnThisPulse = new TDictionary<string, Misc.PostureStance>(StringComparer.Ordinal, useReadLock: false);
		Cache_ContactIncomingWeapons = new TDictionary<string, int>(StringComparer.Ordinal);
		tdictionary_0 = new TDictionary<Contact, List<WeaponSalvo>>();
		Cache_ContactsInsideNoNavZones = new TDictionary<string, bool>(StringComparer.Ordinal, useReadLock: false);
		Cache_ContactsInsidePatrolAreas = new TDictionary<(Contact, Patrol), bool>();
		Cache_ContactsInsideProsecutionAreas = new TDictionary<(Contact, Patrol), bool>();
		Cache_UnitsAssignedToMissionOrPackage = new TDictionary<Mission, List<ActiveUnit>>();
		activeUnit_0 = new ActiveUnit[0];
		hashSet_0 = new HashSet<string>();
		hashSet_1 = new HashSet<string>();
		SpecialDetections = new Queue<(Contact, ActiveUnit, List<Sensor>, float, ActiveUnit_Sensory.SpecialDetectionMode, DateTime, List<Geopoint_Struct>)>();
		AGU_Frontline = new List<AggregateGroundUnit_Frontline>();
		EmconAlertness = new EmconLevel();
		CommNetworks = new System.Collections.ObjectModel.ObservableDictionary<string, CommNetwork>();
		SelectedNetworks = new List<CommNetwork>();
		NetworkColorMap = new Dictionary<string, Color>();
		IsUnitInContactWithTheLeaderInthisPulse = new ConcurrentDictionary<string, bool>();
		NetworkLog = new ObservableCollection<string>();
		NetworkRuleRegistry = null;
		IsNature = false;
		Chalks = new List<Chalk>();
		list_9 = new List<Chalk>();
		LandingPlans = new List<LandingPlan>();
		DisableMultiDomainTOT = false;
		ContactsJustSharedWithMe = new HashSet<string>();
		lockObject_0 = new LockObject();
		postureStance_0 = new Misc.PostureStance[0];
		AddShooter = new LockObject();
		SalvoMaxDistanceToTargetList = new ConcurrentDictionary<DateTime, SalvoMaxDistanceToTarget>();
		FeedbackList = new TList<TransmissionWithFeedback>();
		MinuteFeedbackList = new TList<TransmissionWithFeedback>();
		TransmissionQueue = new TDictionary<string, List<Transmission>>();
		MinuteTransmissionQueue = new TDictionary<string, TList<Transmission>>();
		concurrentQueue_0 = new ConcurrentQueue<TransmittedContactData>();
		Scenario scenarioContext = theScen;
		List<ActiveUnit> DoctrineSelectedUnits = null;
		Doctrine = new Doctrine(scenarioContext, this, ref DoctrineSelectedUnits);
		Name = theName;
		IsNature = IsNatureSide;
		Enablers.GNSS_GPS = true;
		Enablers.GNSS_GLONASS = true;
		Enablers.GNSS_BeiDou = true;
		Enablers.GNSS_NavIC = true;
	}

	private void method_4(object object_0, ObservableListModified<WeaponSalvo> observableListModified_0)
	{
		foreach (WeaponSalvo item in observableListModified_0.Items)
		{
			_ = item;
		}
	}

	public void ReceiveContactDataFromUnit(TransmittedContactData ContactInfo)
	{
		concurrentQueue_0.Enqueue(ContactInfo);
	}

	public void ProcessIncomingDetections()
	{
		if (concurrentQueue_0.Count == 0)
		{
			return;
		}
		List<TransmittedContactData> list = new List<TransmittedContactData>();
		TransmittedContactData result;
		while (concurrentQueue_0.TryDequeue(out result))
		{
			list.Add(result);
		}
		if (list.Count == 0)
		{
			return;
		}
		using PooledList<ActiveUnit>.Enumerator enumerator = Units.GetEnumerator();
		_Closure$__326-0 closure$__326- = default(_Closure$__326-0);
		while (enumerator.MoveNext())
		{
			closure$__326- = new _Closure$__326-0(closure$__326-);
			closure$__326-.$VB$Local_senderUnit = enumerator.Current;
			if (!closure$__326-.$VB$Local_senderUnit.CommStuff.CanTransmitOrReceiveContactsData())
			{
				continue;
			}
			IOrderedEnumerable<CommDevice> orderedEnumerable = closure$__326-.$VB$Local_senderUnit.Comms_ReadOnly.OrderBy([SpecialName] (CommDevice theCD) => theCD.QualityGrade);
			foreach (CommDevice item in orderedEnumerable)
			{
				if (item.LastTransmissionTime.HasValue && DateTime.Compare(item.LastTransmissionTime.Value.AddSeconds(item.GetLatencyGradeinSeconds()), closure$__326-.$VB$Local_senderUnit.ParentScen.Time) >= 0)
				{
					continue;
				}
				List<TransmittedContactData> list2 = new List<TransmittedContactData>(list.Where(closure$__326-._Lambda$__1));
				if (list2 == null || list2.Count == 0)
				{
					continue;
				}
				int num = list2.Count - 1;
				for (int num2 = 0; num2 <= num; num2++)
				{
					TransmittedContactData transmittedContactData = list2[num2];
					if (transmittedContactData.TheSensor != null && transmittedContactData.TheContact != null && transmittedContactData.TheTransmittingUnit != null)
					{
						list2[num2] = new TransmittedContactData(transmittedContactData.TheSensor, transmittedContactData.TheContact, transmittedContactData.TheTransmittingUnit);
					}
				}
				Transmission transmission = new Transmission(closure$__326-.$VB$Local_senderUnit, item, list2, list2[0].TheSensor.ParentPlatform, list2[0].TheSensor.ObjectID, "", closure$__326-.$VB$Local_senderUnit.ParentScen.Time, 0.0, item.GetLatencyGradeinSeconds(), 0.0);
				closure$__326-.$VB$Local_senderUnit.SetLastTransmissionTime(item, closure$__326-.$VB$Local_senderUnit.ParentScen.Time);
				closure$__326-.$VB$Local_senderUnit.get_UnitSide(SetSideOnly: false).AddMessageToTransmissionQueue(transmission);
			}
		}
	}

	public void AddMessageToTransmissionQueue(Transmission transmission)
	{
		if (transmission != null && transmission.TheCommDevice != null)
		{
			string objectID = transmission.TheCommDevice.ObjectID;
			List<Transmission> value = null;
			if (!TransmissionQueue.TryGetValue(objectID, out value))
			{
				List<Transmission> list = new List<Transmission>();
				list.Add(transmission);
				TransmissionQueue.AddIfNotExistsElseUpdate(objectID, list);
			}
			else
			{
				value.Add(transmission);
			}
			TList<Transmission> value2 = null;
			if (MinuteTransmissionQueue.TryGetValue(objectID, out value2))
			{
				value2.Add(transmission);
				return;
			}
			TList<Transmission> tList = new TList<Transmission>();
			tList.Add(transmission);
			MinuteTransmissionQueue.AddIfNotExistsElseUpdate(objectID, tList);
		}
	}

	internal void ExportContactTransmissionWithFeedback(TransmissionWithFeedback theTf)
	{
		try
		{
			Scenario parentScen = theTf.senderUnitList.First().ParentScen;
			IEventExporter[] applicableEventExporters = parentScen.ApplicableEventExporters;
			foreach (IEventExporter eventExporter in applicableEventExporters)
			{
				if (!eventExporter.IsOperating)
				{
					continue;
				}
				PooledDictionary<string, IEventExporter.EventNotificationParameter> pooledDictionary = new PooledDictionary<string, IEventExporter.EventNotificationParameter>(30, ClearMode.Always);
				if (parentScen.MonteCarloIteration > 0)
				{
					pooledDictionary.Add("Scenario", new IEventExporter.EventNotificationParameter(parentScen.Title, typeof(string), 500));
					pooledDictionary.Add("MC_Run", new IEventExporter.EventNotificationParameter(parentScen.MonteCarloIteration, typeof(int)));
				}
				pooledDictionary.Add("TimelineID", new IEventExporter.EventNotificationParameter(parentScen.TimelineID, typeof(string), 40));
				if (eventExporter.UseZeroHour)
				{
					pooledDictionary.Add("Time", new IEventExporter.EventNotificationParameter(parentScen.Time.Subtract(parentScen.ZeroHour).ToString("c"), typeof(TimeSpan), 30));
				}
				else
				{
					pooledDictionary.Add("Time", new IEventExporter.EventNotificationParameter(parentScen.Time.ToString("MM/dd/yyyy HH:mm:ss") + "." + parentScen.Time.Millisecond.ToString("D3"), typeof(DateTime)));
				}
				pooledDictionary.Add("TransmissionID", new IEventExporter.EventNotificationParameter(theTf.theTransmission.ID, typeof(string), 40));
				pooledDictionary.Add("ContactName", new IEventExporter.EventNotificationParameter(theTf.theContact.Name, typeof(string), 40));
				pooledDictionary.Add("ContactID", new IEventExporter.EventNotificationParameter(theTf.theContact.ObjectID, typeof(string), 40));
				pooledDictionary.Add("TransmittingSide", new IEventExporter.EventNotificationParameter(Name, typeof(string), 40));
				pooledDictionary.Add("SenderUnitID", new IEventExporter.EventNotificationParameter(theTf.senderUnitList.First().ObjectID, typeof(string), 40));
				pooledDictionary.Add("SenderUnitName", new IEventExporter.EventNotificationParameter(theTf.senderUnitList.First().Name, typeof(string), 40));
				pooledDictionary.Add("ReceiverUnitID", new IEventExporter.EventNotificationParameter(theTf.receiver.ObjectID, typeof(string), 40));
				pooledDictionary.Add("ReceiverUnitName", new IEventExporter.EventNotificationParameter(theTf.receiver.Name, typeof(string), 40));
				pooledDictionary.Add("TransmissionTime", new IEventExporter.EventNotificationParameter(theTf.theTransmission.OriginalTransmissionTime.ToString("MM/dd/yyyy HH:mm:ss"), typeof(string), 40));
				pooledDictionary.Add("CommDeviceID", new IEventExporter.EventNotificationParameter(theTf.theTransmission.TheCommDevice.ObjectID, typeof(string), 40));
				pooledDictionary.Add("CommDeviceName", new IEventExporter.EventNotificationParameter(theTf.theTransmission.TheCommDevice.Name, typeof(string), 40));
				pooledDictionary.Add("Bandwidth", new IEventExporter.EventNotificationParameter(theTf.theTransmission.TheCommDevice.QualityGradeinfo.GetDescriptionASSlide(), typeof(string), 40));
				pooledDictionary.Add("RefreshGrade ", new IEventExporter.EventNotificationParameter(theTf.theTransmission.TheCommDevice.LatencyGradenfo.GetDescriptionASSlide(), typeof(string), 40));
				pooledDictionary.Add("TransmissionWithFeedback", new IEventExporter.EventNotificationParameter(theTf.result.ToString(), typeof(string), 40));
				Contact theContact = theTf.theContact;
				pooledDictionary.Add("TargetID", new IEventExporter.EventNotificationParameter(theContact.ObjectID, typeof(string), 40));
				pooledDictionary.Add("TargetName", new IEventExporter.EventNotificationParameter(theContact.Name, typeof(string), 500));
				pooledDictionary.Add("TargetSide", new IEventExporter.EventNotificationParameter(theContact.ActualUnit.get_UnitSide(SetSideOnly: false).Name, typeof(string), 500));
				pooledDictionary.Add("TargetLongitude", new IEventExporter.EventNotificationParameter(((Module_Unit.Unit)theContact).get_Longitude((GlobalVariables.BooleanObject)null), typeof(double)));
				pooledDictionary.Add("TargetLatitude", new IEventExporter.EventNotificationParameter(((Module_Unit.Unit)theContact).get_Latitude((GlobalVariables.BooleanObject)null), typeof(double)));
				pooledDictionary.Add("TargetAltitude_ASL_m", new IEventExporter.EventNotificationParameter(((Module_Unit.Unit)theContact).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), typeof(float)));
				pooledDictionary.Add("TargetAltitude_AGL_m", new IEventExporter.EventNotificationParameter(theContact.CurrentAltitude_AGL, typeof(float)));
				pooledDictionary.Add("TargetHeading", new IEventExporter.EventNotificationParameter(theContact.CurrentHeading, typeof(float)));
				pooledDictionary.Add("TargetSpeed", new IEventExporter.EventNotificationParameter(theContact.CurrentSpeed, typeof(float)));
				pooledDictionary.Add("HeadingisKnown", new IEventExporter.EventNotificationParameter(theContact.HeadingIsKnown, typeof(bool)));
				pooledDictionary.Add("SpeedisKnown", new IEventExporter.EventNotificationParameter(theContact.SpeedIsKnown, typeof(bool)));
				pooledDictionary.Add("AltitudeisKnown", new IEventExporter.EventNotificationParameter(theContact.AltitudeIsKnown, typeof(bool)));
				pooledDictionary.Add("ActualUnitName", new IEventExporter.EventNotificationParameter(theContact.ActualUnit.Name, typeof(string)));
				if (Information.IsNothing((object)theContact.UncertaintyArea))
				{
					pooledDictionary.Add("DetectionAOU", new IEventExporter.EventNotificationParameter("-", typeof(string)));
				}
				else
				{
					StringBuilder stringBuilder = StringBuilderCache.Allocate();
					foreach (Geopoint_Struct item in theContact.UncertaintyArea)
					{
						stringBuilder.Append("{Lon:").Append(item.Longitude).Append(" - Lat:")
							.Append(item.Latitude)
							.Append("}");
					}
					pooledDictionary.Add("DetectionAOU", new IEventExporter.EventNotificationParameter(stringBuilder.ToString(), typeof(string)));
					StringBuilderCache.Free(stringBuilder);
				}
				eventExporter.ExportEvent(IEventExporter.ExportedEventType.ContactTransmission, pooledDictionary, parentScen);
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal void LogActionIntoNetworkLog(string v, Side theSide)
	{
		NetworkLog.Add(v + " - TOD: " + DateTime.Now.ToString("HH:mm:ss") + " - SCEN TIME: " + ParentScen.Time.ToString("HH:mm:ss"));
	}

	internal void AddUnitsToNetwork(string iD, List<Module_Unit.Unit> units)
	{
		if (!CommNetworks.ContainsKey(iD))
		{
			return;
		}
		foreach (Module_Unit.Unit unit in units)
		{
			AddUnitToNetwork(iD, unit);
		}
	}

	internal void AddUnitToNetwork(string iD, Module_Unit.Unit theU)
	{
		if (CommNetworks.ContainsKey(iD) && !CommNetworks[iD].Members.Contains(theU))
		{
			CommNetworks[iD].Members.Add(theU);
			LogActionIntoNetworkLog("Adding Unit " + theU.Name + " To network " + CommNetworks[iD].Name, this);
		}
	}

	internal void RemoveUnitFromNetwork(string iD, Module_Unit.Unit theU)
	{
		if (CommNetworks.ContainsKey(iD) && CommNetworks[iD].Members.Contains(theU))
		{
			CommNetworks[iD].Members.Remove(theU);
			LogActionIntoNetworkLog("Removing Unit " + theU.Name + " From network " + CommNetworks[iD].Name, this);
		}
	}

	internal void RemoveUnitsFromNetwork(string iD, List<Module_Unit.Unit> units)
	{
		if (!CommNetworks.ContainsKey(iD))
		{
			return;
		}
		foreach (Module_Unit.Unit unit in units)
		{
			RemoveUnitFromNetwork(iD, unit);
		}
	}

	public CommNetwork CreateGroupCommNetwork(ActiveUnit theGroup)
	{
		HashSet<Module_Unit.Unit> hashSet = ((Group)theGroup).Units.Values.Cast<Module_Unit.Unit>().ToHashSet();
		CommNetwork result = default(CommNetwork);
		if (!hashSet.All([SpecialName] (Module_Unit.Unit x) => x.IsFixedFacility))
		{
			ActiveUnit groupLead = ((Group)theGroup).GroupLead;
			ActiveUnit activeUnit = default(ActiveUnit);
			if (!groupLead.IsAircraft)
			{
				if (groupLead.IsShip)
				{
					activeUnit = ((Ship)groupLead).DockingOps.get_AssignedHostUnit(PickNewAssignedHost: false);
				}
				else if (groupLead.IsSubmarine)
				{
					activeUnit = ((Submarine)groupLead).DockingOps.get_AssignedHostUnit(PickNewAssignedHost: false);
				}
			}
			else
			{
				activeUnit = ((Aircraft)groupLead).AirOps.get_AssignedHostUnit(PickNewAssignedHost: false);
			}
			if (activeUnit != null && groupLead.CommStuff.Networks != null)
			{
				foreach (CommNetwork network in groupLead.CommStuff.Networks)
				{
					if (network.Members == null || network.Members.Count != ((Group)theGroup).Units.Count)
					{
						continue;
					}
					bool flag = false;
					foreach (Module_Unit.Unit member in network.Members)
					{
						if (!((Group)theGroup).Units.ContainsKey(member.ObjectID))
						{
							flag = true;
						}
					}
					if (!flag)
					{
						AddUnitToNetwork(network.ID, activeUnit);
						result = network;
						return result;
					}
				}
			}
			CommNetwork commNetwork = CreateNextNetworkUnitsReason(hashSet, CommNetwork.NetworkCreationReason.Group);
			LogActionIntoNetworkLog("Created Network " + commNetwork.Name + " for Group" + theGroup.Name, this);
		}
		return result;
	}

	public void AddCommNetwork(CommNetwork theCC)
	{
		if (CommNetworks == null)
		{
			CommNetworks = new System.Collections.ObjectModel.ObservableDictionary<string, CommNetwork>();
		}
		if (!CommNetworks.ContainsKey(theCC.ID))
		{
			CommNetworks.Add(theCC.ID, theCC);
		}
	}

	public void RemoveCommNetwork(string Id)
	{
		if (CommNetworks != null && CommNetworks.ContainsKey(Id))
		{
			CommNetwork commNetwork = CommNetworks[Id];
			CommNetworks.Remove(Id);
			LogActionIntoNetworkLog("Removed Network " + commNetwork.Name, this);
		}
	}

	public CommNetwork CreateNextNetworkUnitsReason(HashSet<Module_Unit.Unit> Members, CommNetwork.NetworkCreationReason theReason, string theRefObjectID = null, string PassedName = "")
	{
		if (Members != null && Members.Count != 0)
		{
			CommNetwork commNetwork = new CommNetwork(name: (Operators.CompareString(PassedName, "", false) != 0) ? PassedName : (theReason.ToString() + " # " + GetNextCommNetworkID().Split(new char[1] { '_' })[1]), ParentSide: this, iD: GetNextCommNetworkID(), members: Members, theReason: theReason, theRefObjectID: theRefObjectID);
			AddCommNetwork(commNetwork);
			LogActionIntoNetworkLog("Create Network " + commNetwork.Name, this);
			return commNetwork;
		}
		return null;
	}

	public string GetNextCommNetworkID()
	{
		if (CommNetworks != null && CommNetworks.Count != 0)
		{
			return ObjectID + "_" + Conversions.ToString(CommNetworks.Count + 1);
		}
		return ObjectID + "_" + 0;
	}

	public bool HasCommPath(string sourceUnitID, string targetUnitID)
	{
		if (Operators.CompareString(sourceUnitID, targetUnitID, false) == 0)
		{
			return true;
		}
		Dictionary<string, HashSet<string>> dictionary = new Dictionary<string, HashSet<string>>();
		foreach (KeyValuePair<string, CommNetwork> commNetwork in CommNetworks)
		{
			List<string> list = (from u in commNetwork.Value.Members
				where u != null
				select u.ObjectID).ToList();
			foreach (string item in list)
			{
				if (!dictionary.ContainsKey(item))
				{
					dictionary.Add(item, new HashSet<string>());
				}
				foreach (string item2 in list)
				{
					if (Operators.CompareString(item, item2, false) != 0)
					{
						dictionary[item].Add(item2);
					}
				}
			}
		}
		int result;
		if (!dictionary.ContainsKey(sourceUnitID))
		{
			result = 0;
		}
		else
		{
			if (dictionary.ContainsKey(targetUnitID))
			{
				Queue<string> queue = new Queue<string>();
				HashSet<string> hashSet = new HashSet<string>();
				queue.Enqueue(sourceUnitID);
				hashSet.Add(sourceUnitID);
				while (queue.Count > 0)
				{
					string text = queue.Dequeue();
					if (Operators.CompareString(text, targetUnitID, false) != 0)
					{
						if (!dictionary.ContainsKey(text))
						{
							continue;
						}
						foreach (string item3 in dictionary[text])
						{
							if (!hashSet.Contains(item3))
							{
								hashSet.Add(item3);
								queue.Enqueue(item3);
							}
						}
						continue;
					}
					return true;
				}
				return false;
			}
			result = 0;
		}
		return (byte)result != 0;
	}

	private void method_5(object sender, DictionaryChangedEventArgs<string, Contact> e)
	{
		Contacts_List = null;
		switch (e.Action)
		{
		case NotifyCollectionChangedAction.Add:
			contactAddedEventHandler_0?.Invoke(ObjectID, e.NewValue.ActualUnit.ObjectID);
			break;
		case NotifyCollectionChangedAction.Remove:
			contactRemovedEventHandler_0?.Invoke(ObjectID, e.OldValue.ActualUnit.ObjectID);
			break;
		case NotifyCollectionChangedAction.Reset:
		{
			foreach (KeyValuePair<string, Contact> item in e.Items)
			{
				contactRemovedEventHandler_0?.Invoke(ObjectID, item.Value.ActualUnit.ObjectID);
			}
			break;
		}
		case NotifyCollectionChangedAction.Replace:
		case NotifyCollectionChangedAction.Move:
			break;
		}
	}

	static Side()
	{
		Class72.smethod_20();
	}
}
