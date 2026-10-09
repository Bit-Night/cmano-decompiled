using System.Collections.Generic;

namespace CSMaterial.ClipperLib;

public sealed class PolyTree : PolyNode
{
	internal List<PolyNode> m_AllPolys = new List<PolyNode>();

	public int Total => m_AllPolys.Count;

	~PolyTree()
	{
		Clear();
	}

	public void Clear()
	{
		for (int i = 0; i < m_AllPolys.Count; i++)
		{
			m_AllPolys[i] = null;
		}
		m_AllPolys.Clear();
		m_Childs.Clear();
	}

	public PolyNode GetFirst()
	{
		if (m_Childs.Count <= 0)
		{
			return null;
		}
		return m_Childs[0];
	}

	static PolyTree()
	{
		Class72.smethod_20();
	}
}
