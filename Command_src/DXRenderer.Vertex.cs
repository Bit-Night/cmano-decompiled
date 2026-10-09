using System.Numerics;

namespace DXRenderer;

public struct Vertex
{
	internal Vector3 position;

	internal Vector4 color;

	internal Vector2 textureCoordinate;

	internal Vertex(Vector3 p, Vector4 c, Vector2 t)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		position = p;
		color = c;
		textureCoordinate = t;
	}

	public Vertex(Vector3 p, Vector4 c)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		position = p;
		color = c;
		textureCoordinate = default(Vector2);
	}

	static Vertex()
	{
		Class72.smethod_20();
	}
}
