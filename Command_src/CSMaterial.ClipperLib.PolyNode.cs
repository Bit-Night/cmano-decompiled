using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSMaterial.ClipperLib;

public class PolyNode
{
	internal PolyNode m_Parent;

	internal List<IntPoint> m_polygon = new List<IntPoint>();

	internal int m_Index;

	internal JoinType m_jointype;

	internal EndType m_endtype;

	internal List<PolyNode> m_Childs = new List<PolyNode>();

	[CompilerGenerated]
	private bool bool_0;

	public int ChildCount => m_Childs.Count;

	public List<IntPoint> Contour => m_polygon;

	public List<PolyNode> Childs => m_Childs;

	public PolyNode Parent => m_Parent;

	public bool IsHole => method_0();

	public bool IsOpen
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
		[CompilerGenerated]
		set
		{
			bool_0 = value;
		}
	}

	private bool method_0()
	{
		bool flag = true;
		for (PolyNode parent = m_Parent; parent != null; parent = parent.m_Parent)
		{
			flag = !flag;
		}
		return flag;
	}

	internal void AddChild(PolyNode Child)
	{
		int count = m_Childs.Count;
		m_Childs.Add(Child);
		Child.m_Parent = this;
		Child.m_Index = count;
	}

	public PolyNode GetNext()
	{
		if (m_Childs.Count <= 0)
		{
			return GetNextSiblingUp();
		}
		return m_Childs[0];
	}

	internal PolyNode GetNextSiblingUp()
	{
		if (m_Parent == null)
		{
			return null;
		}
		if (m_Index == m_Parent.m_Childs.Count - 1)
		{
			return m_Parent.GetNextSiblingUp();
		}
		return m_Parent.m_Childs[m_Index + 1];
	}

	static PolyNode()
	{
		Class72.smethod_20();
	}
}
