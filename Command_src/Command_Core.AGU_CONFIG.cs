using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;

namespace Command_Core;

[Serializable]
public class AGU_CONFIG
{
	private static AGU_CONFIG agu_CONFIG_0;

	private static readonly LockObject lockObject_0;

	public bool Enabled;

	public bool Logging;

	public float RadiusOfInfluence;

	public float BaseAGUTurnrate;

	public float FriendlyBaseFriction;

	public float HostileBaseFriction;

	public float UnknownBaseFriction;

	public float FrictionSpeedModifier;

	public float FrictionElasticity;

	public float BaseCombatIntensity;

	public float TurnLength_Sec;

	public float WeaponImpactDirectHitThreshold_Meter;

	public float WeaponImpactDirectHitBaseProbability;

	public float SuppressionFactor;

	public float SuppressionFactor_IndirectFire;

	public float SuppressionRecoverySpeed;

	public float Entrenchment_Full_Sec;

	public float Entrenchment_Minimal_Sec;

	public float Entrenchment_Minimal_Efficiency;

	public float Entrenchment_BaseCoverModifier;

	public float DirectionalModifier_Defense;

	public float DirectionalModifier_Offense;

	public float DirectionalOffset_Degrees;

	public float HostileAngleMaskPerContactPoint;

	public float EscapeRouteConfidence;

	public float AGUSpeedModifier;

	public float RoadUsageDistanceThreshold_Nm;

	public float Facility_Control_RatePerTurn;

	public bool Morale_Enable;

	public float Morale_RetreatThreshold;

	public float Morale_HQ;

	public float Morale_HQ_DirectProximity;

	public float Morale_HQ_Suppression;

	public float Morale_HQ_Losses;

	public float Morale_HQ_EchelonDiscrepency;

	public float Morale_HQ_Distance;

	public float Morale_HQ_Distance_IncrementPerNm;

	public float Morale_HQ_Proficiency;

	public bool UI_TooltipDisplay_Terrain;

	public bool UI_TooltipDisplay_CombatMatrix;

	public bool UI_TooltipDisplay_Effects;

	public bool UI_DrawFrontline;

	public bool UI_DrawFrontlineEngagement;

	public bool UI_AGULossBark;

	public bool UI_AGULossExplosion;

	[NonSerialized]
	public TerrainConfig TerrainModifiers;

	[NonSerialized]
	public float[,] CombatMatrix_Offense;

	[NonSerialized]
	public float[,] CombatMatrix_Defence;

	[NonSerialized]
	public Dictionary<Warhead.WarheadCaliber, int> WarheadCaliber_IndexMapping;

	[NonSerialized]
	public Dictionary<GlobalVariables.ArmorRating, int> ArmorRating_IndexMapping;

	[NonSerialized]
	public ToolTip _toolTip;

	public static AGU_CONFIG Instance
	{
		get
		{
			if (agu_CONFIG_0 == null)
			{
				lock (lockObject_0)
				{
					if (agu_CONFIG_0 == null)
					{
						agu_CONFIG_0 = new AGU_CONFIG();
					}
				}
			}
			return agu_CONFIG_0;
		}
		set
		{
			agu_CONFIG_0 = value;
		}
	}

	public static string HannibalDataPath => Path.Combine(GameGeneral.TopLevelWritablePath + Conversions.ToString(Path.DirectorySeparatorChar) + "Resources", "Hannibal");

	public static string HannibalDatabasePath => Path.Combine(HannibalDataPath, "Database");

	[JsonIgnore]
	public ToolTip toolTip
	{
		get
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Expected O, but got Unknown
			//IL_009f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a9: Expected O, but got Unknown
			//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c0: Expected O, but got Unknown
			if (_toolTip == null)
			{
				_toolTip = new ToolTip();
				_toolTip.UseFading = false;
				_toolTip.UseAnimation = false;
				_toolTip.AutomaticDelay = 0;
				_toolTip.AutoPopDelay = 0;
				_toolTip.AutoPopDelay = int.MaxValue;
				_toolTip.InitialDelay = 0;
				_toolTip.ReshowDelay = 0;
				_toolTip.ShowAlways = true;
				_toolTip.OwnerDraw = true;
				_toolTip.OwnerDraw = true;
				_toolTip.Draw += new DrawToolTipEventHandler(_toolTip_Draw);
				_toolTip.Popup += new PopupEventHandler(_toolTip_Popup);
			}
			return _toolTip;
		}
	}

	static AGU_CONFIG()
	{
		Class72.smethod_20();
		lockObject_0 = new LockObject();
	}

	public AGU_CONFIG()
	{
		Enabled = false;
		Logging = true;
		RadiusOfInfluence = 1f;
		BaseAGUTurnrate = 1f;
		FriendlyBaseFriction = 0.3f;
		HostileBaseFriction = 4f;
		UnknownBaseFriction = 1f;
		FrictionSpeedModifier = 1f;
		FrictionElasticity = 1f;
		BaseCombatIntensity = 0.001f;
		TurnLength_Sec = 30f;
		WeaponImpactDirectHitThreshold_Meter = 10f;
		WeaponImpactDirectHitBaseProbability = 0.1f;
		SuppressionFactor = 5f;
		SuppressionFactor_IndirectFire = 0.25f;
		SuppressionRecoverySpeed = 0.05f;
		Entrenchment_Full_Sec = 21600f;
		Entrenchment_Minimal_Sec = 600f;
		Entrenchment_Minimal_Efficiency = 0.1f;
		Entrenchment_BaseCoverModifier = 0.65f;
		DirectionalModifier_Defense = 0.8f;
		DirectionalModifier_Offense = 0.4f;
		DirectionalOffset_Degrees = 30f;
		HostileAngleMaskPerContactPoint = 60f;
		EscapeRouteConfidence = 0.2f;
		AGUSpeedModifier = 0.8f;
		RoadUsageDistanceThreshold_Nm = 2f;
		Facility_Control_RatePerTurn = 0.005f;
		Morale_Enable = true;
		Morale_RetreatThreshold = -0.5f;
		Morale_HQ = 0.6f;
		Morale_HQ_DirectProximity = 0.2f;
		Morale_HQ_Suppression = 0.3f;
		Morale_HQ_Losses = 0.8f;
		Morale_HQ_EchelonDiscrepency = 0.1f;
		Morale_HQ_Distance = 0.3f;
		Morale_HQ_Distance_IncrementPerNm = 0.01f;
		Morale_HQ_Proficiency = 0.6f;
		UI_TooltipDisplay_Terrain = true;
		UI_TooltipDisplay_CombatMatrix = true;
		UI_TooltipDisplay_Effects = true;
		UI_DrawFrontline = true;
		UI_DrawFrontlineEngagement = true;
		UI_AGULossBark = true;
		UI_AGULossExplosion = true;
		WarheadCaliber_IndexMapping = new Dictionary<Warhead.WarheadCaliber, int>();
		ArmorRating_IndexMapping = new Dictionary<GlobalVariables.ArmorRating, int>();
	}

	private void _toolTip_Draw(object sender, DrawToolTipEventArgs e)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Expected O, but got Unknown
		e.Graphics.FillRectangle((Brush)new SolidBrush(Color.FromArgb(255, 43, 43, 43)), e.Bounds);
		e.Graphics.DrawRectangle(Pens.White, e.Bounds);
		e.Graphics.DrawString(e.ToolTipText, new Font("Segoe UI", 9f), Brushes.White, (RectangleF)e.Bounds);
	}

	private void _toolTip_Popup(object sender, PopupEventArgs e)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected O, but got Unknown
		e.ToolTipSize = TextRenderer.MeasureText(toolTip.GetToolTip(e.AssociatedControl), new Font("Segoe UI", 9f));
	}

	public static void LoadSettings()
	{
		string path = Path.Combine(HannibalDataPath, "Settings.json");
		if (File.Exists(path))
		{
			Instance = JsonConvert.DeserializeObject<AGU_CONFIG>(File.ReadAllText(path));
			LoadTerrains();
			LoadDamageRules();
		}
	}

	public static void LoadTerrains()
	{
		string path = Path.Combine(HannibalDataPath, "Terrain.json");
		if (File.Exists(path))
		{
			Instance.TerrainModifiers = JsonConvert.DeserializeObject<TerrainConfig>(File.ReadAllText(path));
			Instance.TerrainModifiers.Initialize();
		}
	}

	public static void LoadDamageRules()
	{
		string path = Path.Combine(HannibalDataPath, "CombatMatrix.json");
		if (!File.Exists(path))
		{
			return;
		}
		CombatMatrixRules combatMatrixRules = JsonConvert.DeserializeObject<CombatMatrixRules>(File.ReadAllText(path));
		int length = Enum.GetValues(typeof(CombatPowerType)).Length;
		Warhead.WarheadCaliber[] array = Enum.GetValues(typeof(Warhead.WarheadCaliber)).Cast<Warhead.WarheadCaliber>().ToArray();
		GlobalVariables.ArmorRating[] array2 = Enum.GetValues(typeof(GlobalVariables.ArmorRating)).Cast<GlobalVariables.ArmorRating>().ToArray();
		AGU_CONFIG instance = Instance;
		Instance.CombatMatrix_Offense = new float[array.Length - 1 + 1, length - 1 + 1];
		Instance.CombatMatrix_Defence = new float[array2.Length - 1 + 1, length - 1 + 1];
		int num = 0;
		Warhead.WarheadCaliber[] array3 = array;
		foreach (Warhead.WarheadCaliber key in array3)
		{
			Instance.WarheadCaliber_IndexMapping.Add(key, num);
			num++;
		}
		num = 0;
		GlobalVariables.ArmorRating[] array4 = array2;
		foreach (GlobalVariables.ArmorRating key2 in array4)
		{
			Instance.ArmorRating_IndexMapping.Add(key2, num);
			num++;
		}
		foreach (CombatMatrixItem item in combatMatrixRules.Offence)
		{
			if (Enum.TryParse<Warhead.WarheadCaliber>(item.Type, ignoreCase: true, out var result))
			{
				instance.CombatMatrix_Offense[instance.WarheadCaliber_IndexMapping[result], 0] = item.HeavyArmor;
				instance.CombatMatrix_Offense[instance.WarheadCaliber_IndexMapping[result], 1] = item.LightArmor;
				instance.CombatMatrix_Offense[instance.WarheadCaliber_IndexMapping[result], 2] = item.NoArmor;
			}
			else if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
		}
		foreach (CombatMatrixItem item2 in combatMatrixRules.Defense)
		{
			if (Enum.TryParse<GlobalVariables.ArmorRating>(item2.Type, ignoreCase: true, out var result2))
			{
				instance.CombatMatrix_Defence[instance.ArmorRating_IndexMapping[result2], 0] = item2.HeavyArmor;
				instance.CombatMatrix_Defence[instance.ArmorRating_IndexMapping[result2], 1] = item2.LightArmor;
				instance.CombatMatrix_Defence[instance.ArmorRating_IndexMapping[result2], 2] = item2.NoArmor;
			}
			else if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
		}
	}

	public void SaveSettings()
	{
		File.WriteAllText(Path.Combine(HannibalDataPath, "Settings.json"), JsonConvert.SerializeObject(this, Formatting.Indented));
	}
}
