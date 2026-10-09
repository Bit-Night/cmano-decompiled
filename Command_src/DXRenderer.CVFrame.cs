using System.Collections.Generic;
using System.Numerics;

namespace DXRenderer;

public class CVFrame
{
	private CVMesh cvmesh_0;

	private List<CVFrame> list_0 = new List<CVFrame>();

	private CVFrame cvframe_0;

	public string mName;

	public Matrix4x4 mWorld = Matrix4x4.Identity;

	public Matrix4x4 mLocal = Matrix4x4.Identity;

	public CVFrame(CVFrame parent = null)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		parent?.AddChild(this);
		cvframe_0 = parent;
	}

	public void Render()
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		InitTransform();
		if (cvmesh_0 != null)
		{
			cvmesh_0.Render(mWorld);
		}
		foreach (CVFrame item in list_0)
		{
			item.Render();
		}
	}

	public void SetMesh(CVMesh mesh)
	{
		cvmesh_0 = mesh;
	}

	public void AddChild(CVFrame child)
	{
		list_0.Add(child);
	}

	public void SetName(string name)
	{
		mName = name;
	}

	public void InitTransform()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		mWorld = mLocal;
		if (cvframe_0 != null)
		{
			mWorld = cvframe_0.mWorld * mLocal;
		}
	}

	static CVFrame()
	{
		Class72.smethod_20();
	}
}
