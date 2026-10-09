using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace Zeptomoby.OrbitTools;

public sealed class OmmXmlElements : OrbitalElements
{
	public OmmXmlElements(XmlNode ommNode)
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		if (ommNode.Name != "omm")
		{
			throw new XmlException("Node \"omm\" expected, found \"" + ommNode.Name + "\"");
		}
		XmlNode xmlNode_ = method_0(ommNode, "body/segment/metadata");
		base.SatelliteName = method_2(xmlNode_, "OBJECT_NAME");
		base.IntlDesignatorStr = method_2(xmlNode_, "OBJECT_ID");
		XmlNode xmlNode_2 = method_0(ommNode, "body/segment/data/meanElements");
		base.InclinationDeg = method_1(xmlNode_2, "INCLINATION");
		base.Eccentricity = method_1(xmlNode_2, "ECCENTRICITY");
		base.RAANodeDeg = method_1(xmlNode_2, "RA_OF_ASC_NODE");
		base.ArgPerigeeDeg = method_1(xmlNode_2, "ARG_OF_PERICENTER");
		base.MeanAnomalyDeg = method_1(xmlNode_2, "MEAN_ANOMALY");
		base.MeanMotion = method_1(xmlNode_2, "MEAN_MOTION");
		base.InclinationRad = Globals.ToRadians(base.InclinationDeg);
		base.RAANodeRad = Globals.ToRadians(base.RAANodeDeg);
		base.ArgPerigeeRad = Globals.ToRadians(base.ArgPerigeeDeg);
		base.MeanAnomalyRad = Globals.ToRadians(base.MeanAnomalyDeg);
		string s = method_2(xmlNode_2, "EPOCH");
		base.Epoch = new Julian(DateTime.Parse(s));
		XmlNode xmlNode_3 = method_0(ommNode, "body/segment/data/tleParameters");
		base.BStar = method_1(xmlNode_3, "BSTAR");
		base.MeanMotionDt = method_1(xmlNode_3, "MEAN_MOTION_DOT");
		base.RevAtEpoch = (int)method_1(xmlNode_3, "REV_AT_EPOCH");
		base.SetNumber = (int)method_1(xmlNode_3, "ELEMENT_SET_NO");
		base.NoradIdStr = method_2(xmlNode_3, "NORAD_CAT_ID");
	}

	private XmlNode method_0(XmlNode xmlNode_0, string string_3)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		XmlNode val = xmlNode_0.SelectSingleNode(string_3);
		if (val == null)
		{
			throw new XmlException("Could not find node \"" + string_3 + "\"");
		}
		return val;
	}

	public static List<OmmXmlElements> CreateElements(TextReader xmlText)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Expected O, but got Unknown
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		List<OmmXmlElements> list = new List<OmmXmlElements>();
		XmlDocument val = new XmlDocument();
		val.Load(xmlText);
		foreach (XmlNode childNode in ((XmlNode)val.DocumentElement).ChildNodes)
		{
			XmlNode ommNode = childNode;
			list.Add(new OmmXmlElements(ommNode));
		}
		if (list.Count == 0)
		{
			throw new XmlException("Valid \"omm\" node(s) not found");
		}
		return list;
	}

	private double method_1(XmlNode xmlNode_0, string string_3)
	{
		return double.Parse(method_2(xmlNode_0, string_3));
	}

	private string method_2(XmlNode xmlNode_0, string string_3)
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		XmlNode val = (XmlNode)(object)xmlNode_0[string_3];
		if (val == null || string.IsNullOrEmpty(val.InnerText))
		{
			throw new XmlException("Error parsing node \"" + string_3 + "\"");
		}
		return val.InnerText;
	}

	static OmmXmlElements()
	{
		Class72.smethod_20();
	}
}
