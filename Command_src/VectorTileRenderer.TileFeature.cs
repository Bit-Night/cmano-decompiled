using System.Collections.Generic;

namespace VectorTileRenderer;

public class TileFeature
{
	public ulong Id;

	public GeometryType Type;

	public TileGeometry Geometry;

	public Dictionary<string, TileValue> Tags = new Dictionary<string, TileValue>();

	public string GetString(string key)
	{
		if (!Tags.TryGetValue(key, out var value))
		{
			return null;
		}
		return value.ToString();
	}

	public bool HasTag(string key, string value)
	{
		string text = GetString(key);
		if (text != null)
		{
			return text == value;
		}
		return false;
	}

	public bool HasTag(string key)
	{
		return Tags.ContainsKey(key);
	}

	static TileFeature()
	{
		Class72.smethod_20();
	}
}
