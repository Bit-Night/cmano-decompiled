using System.Collections.Generic;
using System.Drawing;

namespace Worldwind.Component;

public class PolygonTriangulator
{
	public static List<List<PointF>> Triangulate(List<PointF> Polygon, bool triangulate = true)
	{
		List<List<PointF>> list = new List<List<PointF>>();
		List<PointF> list2 = new List<PointF>(Polygon);
		List<PointF> list3 = new List<PointF>();
		int num = 0;
		int count = Polygon.Count;
		int num2;
		if (Square(list2) < 0f)
		{
			list2.Reverse();
			num2 = 10000;
		}
		else
		{
			num2 = 10000;
		}
		int num3 = num2;
		while (count >= 3)
		{
			list3 = new List<PointF>();
			while (smethod_2(list2[num], list2[(num + 1) % count], list2[(num + 2) % count]) < 0f || smethod_0(list2, num, (num + 1) % count, (num + 2) % count))
			{
				num++;
				num %= count;
				num3--;
				if (num3 <= 0)
				{
					return new List<List<PointF>>();
				}
			}
			int num4 = (num + 1) % count;
			list3.Add(list2[num]);
			list3.Add(list2[num4]);
			list3.Add(list2[(num + 2) % count]);
			if (!triangulate)
			{
				while (!(smethod_2(list2[num4], list2[(num4 + 1) % count], list2[(num4 + 2) % count]) <= 0f) && (num4 + 2) % count != num && !smethod_0(list2, num, (num4 + 1) % count, (num4 + 2) % count) && !(smethod_2(list2[num], list2[(num + 1) % count], list2[(num4 + 2) % count]) < 0f))
				{
					list3.Add(list2[(num4 + 2) % count]);
					num4++;
					num4 %= count;
				}
			}
			int num5 = num4 - num;
			if (num5 > 0)
			{
				list2.RemoveRange(num + 1, num5);
			}
			else
			{
				list2.RemoveRange(num + 1, count - num - 1);
				list2.RemoveRange(0, num4 + 1);
			}
			count = list2.Count;
			num++;
			num %= count;
			list.Add(list3);
		}
		return list;
	}

	public static int SelfIntersection(List<PointF> polygon)
	{
		if (polygon.Count >= 3)
		{
			int num = polygon.Count - 1;
			PointF pointF_ = default(PointF);
			int i;
			for (i = 0; i < num; i++)
			{
				for (int j = i + 2; j < num; j++)
				{
					if (smethod_3(polygon[i], polygon[i + 1], polygon[j], polygon[j + 1], ref pointF_) == 1)
					{
						return 1;
					}
				}
			}
			i = 1;
			while (true)
			{
				if (i < num - 1)
				{
					if (smethod_3(polygon[i], polygon[i + 1], polygon[num], polygon[0], ref pointF_) == 1)
					{
						break;
					}
					i++;
					continue;
				}
				return -1;
			}
			return 1;
		}
		return 0;
	}

	public static float Square(List<PointF> polygon)
	{
		float num = 0f;
		if (polygon.Count >= 3)
		{
			for (int i = 0; i < polygon.Count - 1; i++)
			{
				num += smethod_1(polygon[i], polygon[i + 1]);
			}
			num += smethod_1(polygon[polygon.Count - 1], polygon[0]);
		}
		return num;
	}

	public int IsConvex(List<PointF> Polygon)
	{
		if (Polygon.Count >= 3)
		{
			if (Square(Polygon) > 0f)
			{
				for (int i = 0; i < Polygon.Count - 2; i++)
				{
					if (!(smethod_2(Polygon[i], Polygon[i + 1], Polygon[i + 2]) >= 0f))
					{
						return -1;
					}
				}
				if (smethod_2(Polygon[Polygon.Count - 2], Polygon[Polygon.Count - 1], Polygon[0]) < 0f)
				{
					return -1;
				}
				if (smethod_2(Polygon[Polygon.Count - 1], Polygon[0], Polygon[1]) < 0f)
				{
					return -1;
				}
			}
			else
			{
				for (int j = 0; j < Polygon.Count - 2; j++)
				{
					if (!(smethod_2(Polygon[j], Polygon[j + 1], Polygon[j + 2]) <= 0f))
					{
						return -1;
					}
				}
				if (smethod_2(Polygon[Polygon.Count - 2], Polygon[Polygon.Count - 1], Polygon[0]) > 0f)
				{
					return -1;
				}
				if (smethod_2(Polygon[Polygon.Count - 1], Polygon[0], Polygon[1]) > 0f)
				{
					return -1;
				}
			}
			return 1;
		}
		return 0;
	}

	private static bool smethod_0(List<PointF> list_0, int int_0, int int_1, int int_2)
	{
		int num = 0;
		int result;
		while (true)
		{
			if (num < list_0.Count)
			{
				if (num != int_0 && num != int_1 && num != int_2)
				{
					float num2 = smethod_2(list_0[int_0], list_0[int_1], list_0[num]);
					float num3 = smethod_2(list_0[int_1], list_0[int_2], list_0[num]);
					if ((!(num2 < 0f) || !(num3 > 0f)) && (!(num2 > 0f) || !(num3 < 0f)))
					{
						float num4 = smethod_2(list_0[int_2], list_0[int_0], list_0[num]);
						if (num4 >= 0f && num3 >= 0f)
						{
							result = 1;
							break;
						}
						if (num4 <= 0f && !(num3 > 0f))
						{
							result = 1;
							break;
						}
					}
				}
				num++;
				continue;
			}
			return false;
		}
		return (byte)result != 0;
	}

	private static float smethod_1(PointF pointF_0, PointF pointF_1)
	{
		return pointF_1.X * pointF_0.Y - pointF_0.X * pointF_1.Y;
	}

	private static float smethod_2(PointF pointF_0, PointF pointF_1, PointF pointF_2)
	{
		return (pointF_2.X - pointF_0.X) * (pointF_1.Y - pointF_0.Y) - (pointF_1.X - pointF_0.X) * (pointF_2.Y - pointF_0.Y);
	}

	private static int smethod_3(PointF pointF_0, PointF pointF_1, PointF pointF_2, PointF pointF_3, ref PointF pointF_4)
	{
		float num = pointF_1.Y - pointF_0.Y;
		float num2 = pointF_0.X - pointF_1.X;
		float num3 = (0f - num) * pointF_0.X - num2 * pointF_0.Y;
		float num4 = pointF_3.Y - pointF_2.Y;
		float num5 = pointF_2.X - pointF_3.X;
		float num6 = (0f - num4) * pointF_2.X - num5 * pointF_2.Y;
		float num7 = num4 * num2 - num * num5;
		if (num7 == 0f)
		{
			return -1;
		}
		pointF_4.Y = (num * num6 - num4 * num3) / num7;
		pointF_4.X = (num5 * num3 - num2 * num6) / num7;
		if (pointF_0.X > pointF_1.X)
		{
			int result;
			if (!(pointF_4.X < pointF_1.X))
			{
				if (!(pointF_4.X > pointF_0.X))
				{
					goto IL_0108;
				}
				result = 0;
			}
			else
			{
				result = 0;
			}
			return result;
		}
		int result2;
		if (!(pointF_4.X < pointF_0.X))
		{
			if (!(pointF_4.X > pointF_1.X))
			{
				goto IL_0108;
			}
			result2 = 0;
		}
		else
		{
			result2 = 0;
		}
		return result2;
		IL_0166:
		if (pointF_2.X > pointF_3.X)
		{
			int result3;
			if (!(pointF_4.X < pointF_3.X))
			{
				if (!(pointF_4.X > pointF_2.X))
				{
					goto IL_01be;
				}
				result3 = 0;
			}
			else
			{
				result3 = 0;
			}
			return result3;
		}
		int result4;
		if (!(pointF_4.X < pointF_2.X))
		{
			if (!(pointF_4.X > pointF_3.X))
			{
				goto IL_01be;
			}
			result4 = 0;
		}
		else
		{
			result4 = 0;
		}
		return result4;
		IL_01be:
		if (pointF_2.Y > pointF_3.Y)
		{
			int result5;
			if (!(pointF_4.Y < pointF_3.Y))
			{
				if (!(pointF_4.Y > pointF_2.Y))
				{
					goto IL_0216;
				}
				result5 = 0;
			}
			else
			{
				result5 = 0;
			}
			return result5;
		}
		int result6;
		if (!(pointF_4.Y < pointF_2.Y))
		{
			if (!(pointF_4.Y > pointF_3.Y))
			{
				goto IL_0216;
			}
			result6 = 0;
		}
		else
		{
			result6 = 0;
		}
		return result6;
		IL_0216:
		return 1;
		IL_0108:
		if (pointF_0.Y > pointF_1.Y)
		{
			int result7;
			if (!(pointF_4.Y < pointF_1.Y))
			{
				if (!(pointF_4.Y > pointF_0.Y))
				{
					goto IL_0166;
				}
				result7 = 0;
			}
			else
			{
				result7 = 0;
			}
			return result7;
		}
		int result8;
		if (!(pointF_4.Y < pointF_0.Y))
		{
			if (!(pointF_4.Y > pointF_1.Y))
			{
				goto IL_0166;
			}
			result8 = 0;
		}
		else
		{
			result8 = 0;
		}
		return result8;
	}

	static PolygonTriangulator()
	{
		Class72.smethod_20();
	}
}
