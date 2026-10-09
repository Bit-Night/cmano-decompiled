using System;

namespace DotSpatial.Topology.Algorithm;

public class RobustDeterminant
{
	public static int SignOfDet2X2(double x1, double y1, double x2, double y2)
	{
		long num = 0L;
		int num2 = 1;
		if (x1 != 0.0 && y2 != 0.0)
		{
			if (y1 != 0.0 && x2 != 0.0)
			{
				if (0.0 < y1)
				{
					if (0.0 >= y2)
					{
						if (y1 <= 0.0 - y2)
						{
							num2 = -num2;
							x2 = 0.0 - x2;
							y2 = 0.0 - y2;
						}
						else
						{
							double num3 = x1;
							x1 = 0.0 - x2;
							x2 = num3;
							double num4 = y1;
							y1 = 0.0 - y2;
							y2 = num4;
						}
					}
					else if (!(y1 <= y2))
					{
						num2 = -num2;
						double num5 = x1;
						x1 = x2;
						x2 = num5;
						double num6 = y1;
						y1 = y2;
						y2 = num6;
					}
				}
				else if (0.0 < y2)
				{
					if (0.0 - y1 <= y2)
					{
						num2 = -num2;
						x1 = 0.0 - x1;
						y1 = 0.0 - y1;
					}
					else
					{
						double num7 = 0.0 - x1;
						x1 = x2;
						x2 = num7;
						double num8 = 0.0 - y1;
						y1 = y2;
						y2 = num8;
					}
				}
				else if (y1 >= y2)
				{
					x1 = 0.0 - x1;
					y1 = 0.0 - y1;
					x2 = 0.0 - x2;
					y2 = 0.0 - y2;
				}
				else
				{
					num2 = -num2;
					double num9 = 0.0 - x1;
					x1 = 0.0 - x2;
					x2 = num9;
					double num10 = 0.0 - y1;
					y1 = 0.0 - y2;
					y2 = num10;
				}
				if (0.0 < x1)
				{
					if (!(0.0 < x2))
					{
						return num2;
					}
					if (!(x1 <= x2))
					{
						return num2;
					}
				}
				else
				{
					if (0.0 < x2)
					{
						return -num2;
					}
					if (!(x1 >= x2))
					{
						return -num2;
					}
					num2 = -num2;
					x1 = 0.0 - x1;
					x2 = 0.0 - x2;
				}
				while (true)
				{
					num++;
					double num11 = Math.Floor(x2 / x1);
					x2 -= num11 * x1;
					y2 -= num11 * y1;
					if (!(y2 < 0.0))
					{
						if (!(y2 <= y1))
						{
							break;
						}
						if (x1 > x2 + x2)
						{
							if (y1 < y2 + y2)
							{
								return num2;
							}
						}
						else
						{
							if (!(y1 <= y2 + y2))
							{
								return -num2;
							}
							x2 = x1 - x2;
							y2 = y1 - y2;
							num2 = -num2;
						}
						if (y2 != 0.0)
						{
							if (x2 != 0.0)
							{
								num11 = Math.Floor(x1 / x2);
								x1 -= num11 * x2;
								y1 -= num11 * y2;
								if (y1 >= 0.0)
								{
									if (y1 <= y2)
									{
										if (x2 > x1 + x1)
										{
											if (y2 < y1 + y1)
											{
												return -num2;
											}
										}
										else
										{
											if (!(y2 <= y1 + y1))
											{
												return num2;
											}
											x1 = x2 - x1;
											y1 = y2 - y1;
											num2 = -num2;
										}
										if (y1 != 0.0)
										{
											if (x1 == 0.0)
											{
												return -num2;
											}
											continue;
										}
										if (x1 != 0.0)
										{
											return num2;
										}
										return 0;
									}
									return -num2;
								}
								return num2;
							}
							return num2;
						}
						if (x2 == 0.0)
						{
							return 0;
						}
						return -num2;
					}
					return -num2;
				}
				return num2;
			}
			if (y2 > 0.0)
			{
				if (x1 > 0.0)
				{
					return num2;
				}
				return -num2;
			}
			if (x1 > 0.0)
			{
				return -num2;
			}
			return num2;
		}
		int result;
		if (y1 != 0.0)
		{
			if (x2 != 0.0)
			{
				if (y1 > 0.0)
				{
					if (x2 > 0.0)
					{
						return -num2;
					}
					return num2;
				}
				if (x2 > 0.0)
				{
					return num2;
				}
				return -num2;
			}
			result = 0;
		}
		else
		{
			result = 0;
		}
		return result;
	}

	static RobustDeterminant()
	{
		Class72.smethod_20();
	}
}
