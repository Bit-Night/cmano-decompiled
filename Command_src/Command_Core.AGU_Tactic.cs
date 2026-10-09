using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public class AGU_Tactic
{
	public ManoeuverBehaviour Manoeuver;

	public ClashManoeuverBehaviour ManoeuverOnClash;

	public AGU_Integrity Integrity;

	public AGUFormation Formation;

	public float CurrentAreaOfInfluence;

	private RoadSystem.Node node_0;

	private bool bool_0;

	private static AGU_Tactic agu_Tactic_0;

	private static AGU_Tactic agu_Tactic_1;

	public bool IsFullyPrepared => CurrentAreaOfInfluence == AreaOfInfluenceModifier;

	public float AreaOfInfluenceModifier => Formation switch
	{
		AGUFormation.Sparse => 2f, 
		AGUFormation.Normal => 1f, 
		AGUFormation.Dense => 0.5f, 
		AGUFormation.Strategic => 0.1f, 
		_ => 1f, 
	};

	public float FrictionModifier => Manoeuver switch
	{
		ManoeuverBehaviour.HoldPosition => 1f, 
		ManoeuverBehaviour.Careful => 0.5f, 
		ManoeuverBehaviour.Normal => 1f, 
		ManoeuverBehaviour.Aggressive => 2f, 
		ManoeuverBehaviour.Routing => 1f, 
		_ => 1f, 
	};

	public float SpeedModifier => Manoeuver switch
	{
		ManoeuverBehaviour.HoldPosition => 0f, 
		ManoeuverBehaviour.Careful => 0.5f, 
		ManoeuverBehaviour.Normal => 1f, 
		ManoeuverBehaviour.Aggressive => 1.5f, 
		ManoeuverBehaviour.Routing => 4f, 
		_ => 1f, 
	};

	public float CoverModifier => Manoeuver switch
	{
		ManoeuverBehaviour.HoldPosition => 1f, 
		ManoeuverBehaviour.Careful => 2f, 
		ManoeuverBehaviour.Normal => 1f, 
		ManoeuverBehaviour.Aggressive => 0.25f, 
		ManoeuverBehaviour.Routing => 0f, 
		_ => 1f, 
	};

	public float AgilityModifier => Manoeuver switch
	{
		ManoeuverBehaviour.HoldPosition => 1f, 
		ManoeuverBehaviour.Careful => 1f, 
		ManoeuverBehaviour.Normal => 1f, 
		ManoeuverBehaviour.Aggressive => 1f, 
		ManoeuverBehaviour.Routing => 0.05f, 
		_ => 1f, 
	};

	public static AGU_Tactic DefaultTactic
	{
		get
		{
			if (agu_Tactic_0 == null)
			{
				agu_Tactic_0 = new AGU_Tactic();
				agu_Tactic_0.Manoeuver = ManoeuverBehaviour.Normal;
				agu_Tactic_0.ManoeuverOnClash = ClashManoeuverBehaviour.PushThrough;
				agu_Tactic_0.Integrity = AGU_Integrity.Consolidate;
				agu_Tactic_0.Formation = AGUFormation.Normal;
			}
			return agu_Tactic_0;
		}
	}

	public static AGU_Tactic StrategicMove
	{
		get
		{
			if (agu_Tactic_1 == null)
			{
				agu_Tactic_1 = new AGU_Tactic();
				agu_Tactic_1.Manoeuver = ManoeuverBehaviour.Normal;
				agu_Tactic_1.ManoeuverOnClash = ClashManoeuverBehaviour.StopMovement;
				agu_Tactic_1.Integrity = AGU_Integrity.Consolidate;
				agu_Tactic_1.Formation = AGUFormation.Strategic;
			}
			return agu_Tactic_1;
		}
	}

	public AGU_Tactic(AGU_Tactic AGU_Tactic)
	{
		CurrentAreaOfInfluence = 1f;
		node_0 = null;
		bool_0 = false;
		Manoeuver = AGU_Tactic.Manoeuver;
		ManoeuverOnClash = AGU_Tactic.ManoeuverOnClash;
		Integrity = AGU_Tactic.Integrity;
		Formation = AGU_Tactic.Formation;
	}

	public AGU_Tactic()
	{
		CurrentAreaOfInfluence = 1f;
		node_0 = null;
		bool_0 = false;
	}

	public void ToXML(ref XmlWriter theWriter)
	{
		theWriter.WriteStartElement("AGU_Tactic");
		XmlWriter obj = theWriter;
		int manoeuver = (int)Manoeuver;
		obj.WriteElementString("Manoeuver", manoeuver.ToString());
		XmlWriter obj2 = theWriter;
		manoeuver = (int)ManoeuverOnClash;
		obj2.WriteElementString("ManoeuverOnClash", manoeuver.ToString());
		XmlWriter obj3 = theWriter;
		manoeuver = (int)Integrity;
		obj3.WriteElementString("Integrity", manoeuver.ToString());
		XmlWriter obj4 = theWriter;
		manoeuver = (int)Formation;
		obj4.WriteElementString("Formation", manoeuver.ToString());
		theWriter.WriteElementString("C_AOI", ((int)Math.Round(CurrentAreaOfInfluence)).ToString());
		theWriter.WriteEndElement();
	}

	public static AGU_Tactic FromXML(ref XmlNode theNode)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected O, but got Unknown
		AGU_Tactic aGU_Tactic = new AGU_Tactic();
		foreach (XmlNode childNode in theNode.ChildNodes)
		{
			XmlNode val = childNode;
			switch (val.Name)
			{
			case "ManoeuverOnClash":
				aGU_Tactic.ManoeuverOnClash = (ClashManoeuverBehaviour)Conversions.ToInteger(val.InnerText);
				break;
			case "Integrity":
				aGU_Tactic.Integrity = (AGU_Integrity)Conversions.ToInteger(val.InnerText);
				break;
			case "C_AOI":
				aGU_Tactic.CurrentAreaOfInfluence = XmlConvert.ToSingle(val.InnerText.Replace(",", "."));
				break;
			case "Formation":
				aGU_Tactic.Formation = (AGUFormation)Conversions.ToInteger(val.InnerText);
				break;
			case "Manoeuver":
				aGU_Tactic.Manoeuver = (ManoeuverBehaviour)Conversions.ToInteger(val.InnerText);
				break;
			}
		}
		return aGU_Tactic;
	}

	public override string ToString()
	{
		string text = text + "Area of Influence " + (AreaOfInfluenceModifier * 100f).ToString("0.0") + "%" + Environment.NewLine;
		text = text + "Friction " + (FrictionModifier * 100f).ToString("0.0") + "%" + Environment.NewLine;
		text = text + "Speed " + (SpeedModifier * 100f).ToString("0.0") + "%" + Environment.NewLine;
		return text + "Cover " + (CoverModifier * 100f).ToString("0.0") + "%" + Environment.NewLine;
	}

	public void Cycle(float ElapsedTimeInSeconds, AggregateGroundUnit AGU)
	{
		if (AGU.IsAttachedToRoadSystem && !AGU.IsAttachedToDefensiveSystem)
		{
			AGU.CurrentTactic = StrategicMove;
		}
		float areaOfInfluenceModifier = AreaOfInfluenceModifier;
		float num = areaOfInfluenceModifier - CurrentAreaOfInfluence;
		float num2 = 0.01f;
		float num3 = (0.1f + AGU.CurrentMorale * 0.9f) * ElapsedTimeInSeconds * (num2 / (float)(AGU.Echelon + 1));
		if (AGU.HostileFrictionProportion.Count > 0)
		{
			num3 *= 0.1f;
		}
		if (num > 0f)
		{
			CurrentAreaOfInfluence = Math.Min(CurrentAreaOfInfluence + num3, areaOfInfluenceModifier);
		}
		else if (num < 0f)
		{
			CurrentAreaOfInfluence = Math.Max(CurrentAreaOfInfluence - num3, areaOfInfluenceModifier);
		}
	}

	public void FindDefensivePosition(AggregateGroundUnit AGU)
	{
		if (AGU.IsAttachedToRoadSystem || AGU.Navigator.PlottedCourse.Length > 0 || AGU.GetClosestAttachedRoadSystemNode != null)
		{
			return;
		}
		if (node_0 != null)
		{
			AGU.AttachToRoadSystem(node_0);
			node_0 = null;
			bool_0 = false;
		}
		else if (!bool_0)
		{
			bool_0 = true;
			Task.Run([SpecialName] () =>
			{
				RoadSystem.Node closestNode = AGU.GetClosestNode(AGU.ParentScen, AGU.GetInfluenceRadius() * 0.5f, -1, RoadSystem.SegmentEnum.Fortifications);
				node_0 = closestNode;
				bool_0 = false;
				return closestNode;
			});
		}
	}

	static AGU_Tactic()
	{
		Class72.smethod_20();
	}
}
