using System;

namespace Command_Core;

[Serializable]
public class GClass7
{
	public string Name;

	public float Cover_Personel;

	public float Cover_Vehicle;

	public float Agility_Personel;

	public float Agility_Vehicle;

	public float Speed_Personel;

	public float Speed_Vehicle;

	public float Firepower_Personel;

	public float Firepower_Vehicle;

	public void Reset()
	{
		Cover_Personel = 0f;
		Cover_Vehicle = 0f;
		Agility_Personel = 0f;
		Agility_Vehicle = 0f;
		Speed_Personel = 0f;
		Speed_Vehicle = 0f;
		Firepower_Personel = 0f;
		Firepower_Vehicle = 0f;
	}

	static GClass7()
	{
		Class72.smethod_20();
	}
}
