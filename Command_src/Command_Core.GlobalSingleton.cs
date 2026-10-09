using System.Collections.Generic;

namespace Command_Core;

public sealed class GlobalSingleton
{
	public LockRandom Random;

	private static GlobalSingleton globalSingleton_0;

	public Dictionary<GlobalVariables.TechGenerationClass, Str_ChaffEffectivness> ChaffEffectivnessConstants;

	public Dictionary<Sensor.FrequencyBand, Str_ConcurrentFrequencyWrapper> NormalizedNatoFrequencyBand;

	public List<string> CrossThreadErrorDispatch_str;

	public List<(ExceptionEntry, string)> CrossThreadErrorDispatch_entry;

	static GlobalSingleton()
	{
		Class72.smethod_20();
		globalSingleton_0 = null;
	}

	private GlobalSingleton()
	{
		ChaffEffectivnessConstants = new Dictionary<GlobalVariables.TechGenerationClass, Str_ChaffEffectivness>();
		NormalizedNatoFrequencyBand = new Dictionary<Sensor.FrequencyBand, Str_ConcurrentFrequencyWrapper>();
		CrossThreadErrorDispatch_str = new List<string>();
		CrossThreadErrorDispatch_entry = new List<(ExceptionEntry, string)>();
		Random = new LockRandom();
		ChaffEffectivnessConstants.Add(GlobalVariables.TechGenerationClass.const_2, new Str_ChaffEffectivness(100f, 100f, 90f, 80f, 70f, 100f));
		ChaffEffectivnessConstants.Add(GlobalVariables.TechGenerationClass.const_3, new Str_ChaffEffectivness(100f, 100f, 90f, 75f, 70f, 100f));
		ChaffEffectivnessConstants.Add(GlobalVariables.TechGenerationClass.const_4, new Str_ChaffEffectivness(100f, 90f, 80f, 60f, 40f, 100f));
		ChaffEffectivnessConstants.Add(GlobalVariables.TechGenerationClass.const_5, new Str_ChaffEffectivness(70f, 50f, 40f, 30f, 20f, 70f));
		ChaffEffectivnessConstants.Add(GlobalVariables.TechGenerationClass.const_6, new Str_ChaffEffectivness(50f, 30f, 20f, 10f, 5f, 50f));
		ChaffEffectivnessConstants.Add(GlobalVariables.TechGenerationClass.const_7, new Str_ChaffEffectivness(25f, 20f, 10f, 5f, 0f, 25f));
		ChaffEffectivnessConstants.Add(GlobalVariables.TechGenerationClass.const_8, new Str_ChaffEffectivness(20f, 15f, 8f, 2f, 0f, 20f));
		ChaffEffectivnessConstants.Add(GlobalVariables.TechGenerationClass.const_9, new Str_ChaffEffectivness(20f, 15f, 8f, 2f, 0f, 20f));
		ChaffEffectivnessConstants.Add(GlobalVariables.TechGenerationClass.const_10, new Str_ChaffEffectivness(15f, 12f, 5f, 0f, 0f, 15f));
		ChaffEffectivnessConstants.Add(GlobalVariables.TechGenerationClass.const_11, new Str_ChaffEffectivness(15f, 12f, 5f, 0f, 0f, 15f));
		ChaffEffectivnessConstants.Add(GlobalVariables.TechGenerationClass.const_12, new Str_ChaffEffectivness(13f, 10f, 0f, 0f, 0f, 13f));
		ChaffEffectivnessConstants.Add(GlobalVariables.TechGenerationClass.const_13, new Str_ChaffEffectivness(11f, 8f, 0f, 0f, 0f, 11f));
		ChaffEffectivnessConstants.Add(GlobalVariables.TechGenerationClass.const_14, new Str_ChaffEffectivness(8f, 6f, 0f, 0f, 0f, 8f));
		ChaffEffectivnessConstants.Add(GlobalVariables.TechGenerationClass.const_15, new Str_ChaffEffectivness(6f, 4f, 0f, 0f, 0f, 6f));
		ChaffEffectivnessConstants.Add(GlobalVariables.TechGenerationClass.const_16, new Str_ChaffEffectivness(4f, 2f, 0f, 0f, 0f, 4f));
		NormalizedNatoFrequencyBand.Add(Sensor.FrequencyBand.A_Band, new Str_ConcurrentFrequencyWrapper());
		NormalizedNatoFrequencyBand.Add(Sensor.FrequencyBand.B_Band, new Str_ConcurrentFrequencyWrapper());
		NormalizedNatoFrequencyBand.Add(Sensor.FrequencyBand.C_Band, new Str_ConcurrentFrequencyWrapper());
		NormalizedNatoFrequencyBand.Add(Sensor.FrequencyBand.D_Band, new Str_ConcurrentFrequencyWrapper());
		NormalizedNatoFrequencyBand.Add(Sensor.FrequencyBand.E_Band, new Str_ConcurrentFrequencyWrapper());
		NormalizedNatoFrequencyBand.Add(Sensor.FrequencyBand.F_Band, new Str_ConcurrentFrequencyWrapper());
		NormalizedNatoFrequencyBand.Add(Sensor.FrequencyBand.G_Band, new Str_ConcurrentFrequencyWrapper());
		NormalizedNatoFrequencyBand.Add(Sensor.FrequencyBand.H_Band, new Str_ConcurrentFrequencyWrapper());
		NormalizedNatoFrequencyBand.Add(Sensor.FrequencyBand.I_Band, new Str_ConcurrentFrequencyWrapper());
		NormalizedNatoFrequencyBand.Add(Sensor.FrequencyBand.J_Band, new Str_ConcurrentFrequencyWrapper());
		NormalizedNatoFrequencyBand.Add(Sensor.FrequencyBand.K_Band, new Str_ConcurrentFrequencyWrapper());
		NormalizedNatoFrequencyBand.Add(Sensor.FrequencyBand.L_Band, new Str_ConcurrentFrequencyWrapper());
		NormalizedNatoFrequencyBand.Add(Sensor.FrequencyBand.M_Band, new Str_ConcurrentFrequencyWrapper());
		NormalizedNatoFrequencyBand[Sensor.FrequencyBand.A_Band].NonNatoFrequencies.Add(Sensor.FrequencyBand.ELF_Radio);
		NormalizedNatoFrequencyBand[Sensor.FrequencyBand.A_Band].NonNatoFrequencies.Add(Sensor.FrequencyBand.SLF_Radio);
		NormalizedNatoFrequencyBand[Sensor.FrequencyBand.A_Band].NonNatoFrequencies.Add(Sensor.FrequencyBand.ULF_Radio);
		NormalizedNatoFrequencyBand[Sensor.FrequencyBand.A_Band].NonNatoFrequencies.Add(Sensor.FrequencyBand.VLF_Radio);
		NormalizedNatoFrequencyBand[Sensor.FrequencyBand.A_Band].NonNatoFrequencies.Add(Sensor.FrequencyBand.LF_Radio);
		NormalizedNatoFrequencyBand[Sensor.FrequencyBand.A_Band].NonNatoFrequencies.Add(Sensor.FrequencyBand.MF_Radio);
		NormalizedNatoFrequencyBand[Sensor.FrequencyBand.A_Band].NonNatoFrequencies.Add(Sensor.FrequencyBand.HF_Radio);
		NormalizedNatoFrequencyBand[Sensor.FrequencyBand.A_Band].NonNatoFrequencies.Add(Sensor.FrequencyBand.VHF_Radio);
		NormalizedNatoFrequencyBand[Sensor.FrequencyBand.B_Band].NonNatoFrequencies.Add(Sensor.FrequencyBand.VHF_Radio);
		NormalizedNatoFrequencyBand[Sensor.FrequencyBand.B_Band].NonNatoFrequencies.Add(Sensor.FrequencyBand.UHF_Radio);
		NormalizedNatoFrequencyBand[Sensor.FrequencyBand.C_Band].NonNatoFrequencies.Add(Sensor.FrequencyBand.UHF_Radio);
		NormalizedNatoFrequencyBand[Sensor.FrequencyBand.D_Band].NonNatoFrequencies.Add(Sensor.FrequencyBand.UHF_Radio);
		NormalizedNatoFrequencyBand[Sensor.FrequencyBand.E_Band].NonNatoFrequencies.Add(Sensor.FrequencyBand.UHF_Radio);
		NormalizedNatoFrequencyBand[Sensor.FrequencyBand.F_Band].NonNatoFrequencies.Add(Sensor.FrequencyBand.SHF_Radio);
		NormalizedNatoFrequencyBand[Sensor.FrequencyBand.G_Band].NonNatoFrequencies.Add(Sensor.FrequencyBand.SHF_Radio);
		NormalizedNatoFrequencyBand[Sensor.FrequencyBand.H_Band].NonNatoFrequencies.Add(Sensor.FrequencyBand.SHF_Radio);
		NormalizedNatoFrequencyBand[Sensor.FrequencyBand.I_Band].NonNatoFrequencies.Add(Sensor.FrequencyBand.SHF_Radio);
		NormalizedNatoFrequencyBand[Sensor.FrequencyBand.J_Band].NonNatoFrequencies.Add(Sensor.FrequencyBand.SHF_Radio);
		NormalizedNatoFrequencyBand[Sensor.FrequencyBand.K_Band].NonNatoFrequencies.Add(Sensor.FrequencyBand.SHF_Radio);
		NormalizedNatoFrequencyBand[Sensor.FrequencyBand.K_Band].NonNatoFrequencies.Add(Sensor.FrequencyBand.EHF_Radio);
		NormalizedNatoFrequencyBand[Sensor.FrequencyBand.L_Band].NonNatoFrequencies.Add(Sensor.FrequencyBand.EHF_Radio);
		NormalizedNatoFrequencyBand[Sensor.FrequencyBand.M_Band].NonNatoFrequencies.Add(Sensor.FrequencyBand.EHF_Radio);
	}

	public static GlobalSingleton GetInstance()
	{
		if (globalSingleton_0 == null)
		{
			globalSingleton_0 = new GlobalSingleton();
		}
		return globalSingleton_0;
	}
}
