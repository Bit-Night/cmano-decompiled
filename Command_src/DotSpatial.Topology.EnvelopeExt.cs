using System;

namespace DotSpatial.Topology;

public static class EnvelopeExt
{
	public static double Area(this IEnvelope self)
	{
		if (self == null)
		{
			return -1.0;
		}
		return self.Width * self.Height;
	}

	public static ILinearRing Border(this IEnvelope self)
	{
		return self?.ToLinearRing();
	}

	public static ILineSegment[] BorderSegments(this IEnvelope self)
	{
		return new ILineSegment[4]
		{
			self.TopBorder(),
			self.RightBorder(),
			self.BottomBorder(),
			self.LeftBorder()
		};
	}

	public static double Bottom(this IEnvelope self)
	{
		return self.Y - self.Height;
	}

	public static ILineSegment BottomBorder(this IEnvelope self)
	{
		return new LineSegment(self.BottomRight(), self.BottomLeft());
	}

	public static Coordinate BottomLeft(this IEnvelope self)
	{
		return new Coordinate(self.X, self.Bottom());
	}

	public static Coordinate BottomRight(this IEnvelope self)
	{
		return new Coordinate(self.Right(), self.Bottom());
	}

	public static Coordinate Center(this IEnvelope self)
	{
		if (self == null)
		{
			return null;
		}
		if (self.IsNull)
		{
			return null;
		}
		Coordinate coordinate = new Coordinate();
		for (int i = 0; i < self.NumOrdinates; i++)
		{
			coordinate[i] = (self.Minimum[i] + self.Maximum[i]) / 2.0;
		}
		return coordinate;
	}

	public static ILineSegment LeftBorder(this IEnvelope self)
	{
		return new LineSegment(self.BottomLeft(), self.TopLeft());
	}

	public static double Right(this IEnvelope self)
	{
		return self.X + self.Width;
	}

	public static ILineSegment RightBorder(this IEnvelope self)
	{
		if (self == null)
		{
			return null;
		}
		return new LineSegment(self.TopRight(), self.BottomRight());
	}

	public static ILinearRing ToLinearRing(this IEnvelope self)
	{
		return new LinearRing(new CoordinateListSequence
		{
			self.TopLeft(),
			self.TopRight(),
			self.BottomRight(),
			self.BottomLeft(),
			self.TopLeft()
		});
	}

	public static ILineSegment TopBorder(this IEnvelope self)
	{
		return new LineSegment(self.TopLeft(), self.TopRight());
	}

	public static Coordinate TopLeft(this IEnvelope self)
	{
		return new Coordinate(self.Minimum.X, self.Maximum.Y);
	}

	public static IPolygon ToPolygon(this IEnvelope self)
	{
		return new Polygon(self.ToLinearRing());
	}

	public static Coordinate TopRight(this IEnvelope self)
	{
		return new Coordinate(self.Maximum.X, self.Maximum.Y);
	}

	public static void Zoom(this IEnvelope self, double percent)
	{
		if (self != null && !self.IsNull)
		{
			double num = percent / 100.0;
			Coordinate coordinate = new Coordinate();
			for (int i = 0; i < self.NumOrdinates; i++)
			{
				double num2 = self.Maximum[i] - self.Minimum[i];
				coordinate[i] = num2 + num * num2;
			}
			self.SetCenter(self.Center(), coordinate);
		}
	}

	public static IEnvelope Union(this IEnvelope self, Coordinate coord)
	{
		IEnvelope envelope = self.Copy();
		envelope.ExpandToInclude(coord);
		return envelope;
	}

	public static IEnvelope Union(this IEnvelope self, IEnvelope box)
	{
		if (box != null)
		{
			if (!box.IsNull)
			{
				if (self == null)
				{
					return box.Copy();
				}
				if (self.IsNull)
				{
					return box.Copy();
				}
				IEnvelope envelope = self.Copy();
				envelope.ExpandToInclude(box);
				return envelope;
			}
			return self.Copy();
		}
		return self.Copy();
	}

	public static void SetCenter(this IEnvelope self, Coordinate center)
	{
		self.SetCenter(center, null);
	}

	public static void SetCenter(this IEnvelope self, double width, double height)
	{
		self.SetCenter(null, new Coordinate(width, height));
	}

	public static void SetCenter(this IEnvelope self, Coordinate center, double width, double height)
	{
		Coordinate size = new Coordinate(width, height);
		self.SetCenter(center, size);
	}

	public static void SetCenter(this IEnvelope self, Coordinate center, Coordinate size)
	{
		int num = 0;
		int num2 = 0;
		if (self == null)
		{
			return;
		}
		if (center != null)
		{
			num = center.NumOrdinates;
		}
		if (size != null)
		{
			num2 = size.NumOrdinates;
		}
		int val = Math.Min(num, num2);
		int num3 = Math.Max(self.NumOrdinates, val);
		Coordinate coordinate = new Coordinate();
		Coordinate coordinate2 = new Coordinate();
		for (int i = 0; i < num3; i++)
		{
			if (num > i && num2 > i && center != null && size != null)
			{
				coordinate[i] = center[i] - size[i] / 2.0;
				coordinate2[i] = center[i] + size[i] / 2.0;
			}
			if (num <= i && num2 <= i)
			{
				coordinate[i] = self.Minimum[i];
				coordinate2[i] = self.Maximum[i];
			}
			if (num > i && num2 <= i)
			{
				double num4 = self.Maximum[i] - self.Minimum[i];
				if (center != null)
				{
					coordinate[i] = center[i] - num4 / 2.0;
					coordinate2[i] = center[i] + num4 / 2.0;
				}
			}
			if (num <= i && num2 > i)
			{
				double num5 = (self.Minimum[i] + self.Maximum[i]) / 2.0;
				if (size != null)
				{
					coordinate[i] = num5 - size[i];
					coordinate2[i] = num5 + size[i];
				}
			}
		}
		self.Init(coordinate, coordinate2);
	}

	public static void SetExtents(this IEnvelope self, double minX, double minY, double minZ, double maxX, double maxY, double maxZ)
	{
		if (self != null)
		{
			Coordinate p = new Coordinate(minX, minY, minZ);
			Coordinate p2 = new Coordinate(maxX, maxY, maxZ);
			self.Init(p, p2);
		}
	}

	public static void SetExtents(this IEnvelope self, double minX, double minY, double maxX, double maxY)
	{
		if (self != null)
		{
			Coordinate p = new Coordinate(minX, minY);
			Coordinate p2 = new Coordinate(maxX, maxY);
			self.Init(p, p2);
		}
	}

	public static double Top(this IEnvelope self)
	{
		return self.Y;
	}

	public static void Translate(this IEnvelope self, double shiftX, double shiftY)
	{
		self.Translate(new Coordinate(shiftX, shiftY));
	}

	public static void Translate(this IEnvelope self, Coordinate shift)
	{
		if (self != null && !self.IsNull && !(shift == null))
		{
			Coordinate minimum = self.Minimum;
			Coordinate maximum = self.Maximum;
			int num = Math.Min(self.NumOrdinates, shift.NumOrdinates);
			for (int i = 0; i < num; i++)
			{
				minimum[i] += shift[i];
				maximum[i] += shift[i];
			}
			self.Init(minimum, maximum);
		}
	}

	public static bool Overlaps(this IEnvelope self, IEnvelope other)
	{
		if (self.Intersects(other))
		{
			if (self.Contains(other))
			{
				return false;
			}
			if (other.Contains(self))
			{
				return false;
			}
			return true;
		}
		return false;
	}

	public static bool Overlaps(this IEnvelope self, Coordinate p)
	{
		return self.Intersects(p);
	}

	public static bool Overlaps(this IEnvelope self, double x, double y)
	{
		return self.Intersects(new Coordinate(x, y));
	}

	public static bool Contains(this IEnvelope self, Coordinate p)
	{
		if (self != null)
		{
			if (!self.IsNull)
			{
				int num = Math.Min(self.NumOrdinates, p.NumOrdinates);
				int num2 = 0;
				int result;
				while (true)
				{
					if (num2 < num)
					{
						if (p[num2] >= self.Minimum[num2])
						{
							if (!(p[num2] > self.Maximum[num2]))
							{
								num2++;
								continue;
							}
							result = 0;
							break;
						}
						result = 0;
						break;
					}
					return true;
				}
				return (byte)result != 0;
			}
			return false;
		}
		return false;
	}

	public static bool Contains(this IEnvelope self, double x, double y)
	{
		return self.Contains(new Coordinate(x, y));
	}

	public static bool Contains(this IEnvelope envelope, IEnvelope other)
	{
		int result;
		if (envelope == null)
		{
			result = 0;
		}
		else
		{
			if (other != null)
			{
				int result3;
				if (!envelope.IsNull)
				{
					if (!other.IsNull)
					{
						int num = Math.Min(envelope.NumOrdinates, other.NumOrdinates);
						int num2 = 0;
						int result2;
						while (true)
						{
							if (num2 < num)
							{
								if (!(other.Minimum[num2] < envelope.Minimum[num2]))
								{
									if (other.Maximum[num2] <= envelope.Maximum[num2])
									{
										num2++;
										continue;
									}
									result2 = 0;
									break;
								}
								result2 = 0;
								break;
							}
							return true;
						}
						return (byte)result2 != 0;
					}
					result3 = 0;
				}
				else
				{
					result3 = 0;
				}
				return (byte)result3 != 0;
			}
			result = 0;
		}
		return (byte)result != 0;
	}

	public static double Distance(this IEnvelope self, IEnvelope other)
	{
		if (self == null)
		{
			return -1.0;
		}
		if (other == null)
		{
			return -1.0;
		}
		return smethod_2(self, other, Math.Min(self.NumOrdinates, other.NumOrdinates));
	}

	public static double smethod_0(this IEnvelope self, IEnvelope other)
	{
		return smethod_2(self, other, 2);
	}

	public static double smethod_1(this IEnvelope self, IEnvelope other)
	{
		return smethod_2(self, other, 3);
	}

	private static double smethod_2(IEnvelope ienvelope_0, IEnvelope ienvelope_1, int int_0)
	{
		if (ienvelope_0 != null && ienvelope_1 != null)
		{
			if (!ienvelope_0.IsNull && !ienvelope_1.IsNull)
			{
				if (ienvelope_0.NumOrdinates < int_0 && ienvelope_1.NumOrdinates < int_0)
				{
					throw new InsufficientDimensionsException("both envelopes");
				}
				if (ienvelope_0.NumOrdinates < int_0)
				{
					throw new InsufficientDimensionsException("this envelope");
				}
				if (ienvelope_0.NumOrdinates < int_0)
				{
					throw new InsufficientDimensionsException("the other envelope");
				}
				if (!ienvelope_0.Intersects(ienvelope_1))
				{
					Coordinate coordinate = new Coordinate();
					for (int i = 0; i < coordinate.NumOrdinates; i++)
					{
						if (ienvelope_0.Maximum[i] < ienvelope_1.Minimum[i])
						{
							coordinate[i] = ienvelope_1.Minimum.X - ienvelope_0.Maximum.X;
						}
						if (ienvelope_0.Minimum[i] > ienvelope_1.Maximum[i])
						{
							coordinate[i] = ienvelope_0.Minimum[i] - ienvelope_1.Minimum[i];
						}
					}
					double num = 0.0;
					int num2 = 0;
					while (true)
					{
						if (num2 < int_0)
						{
							num += coordinate[num2] * coordinate[num2];
							if (coordinate[num2] == 0.0)
							{
								break;
							}
							num2++;
							continue;
						}
						return Math.Sqrt(num);
					}
					return 0.0;
				}
				return 0.0;
			}
			return -1.0;
		}
		return -1.0;
	}

	public static void ExpandBy(this IEnvelope self, double distance)
	{
		if (self != null)
		{
			int numOrdinates = self.NumOrdinates;
			Coordinate minimum = self.Minimum;
			Coordinate maximum = self.Maximum;
			for (int i = 0; i < numOrdinates; i++)
			{
				minimum[i] -= distance;
				maximum[i] += distance;
			}
			self.Init(minimum, maximum);
		}
	}

	public static void ExpandBy(this IEnvelope self, Coordinate distances)
	{
		if (self != null)
		{
			int num = Math.Min(self.NumOrdinates, distances.NumOrdinates);
			Coordinate minimum = self.Minimum;
			Coordinate maximum = self.Maximum;
			for (int i = 0; i < num; i++)
			{
				minimum[i] -= distances[i];
				maximum[i] += distances[i];
			}
			self.Init(minimum, maximum);
		}
	}

	public static void ExpandBy(this IEnvelope self, double deltaX, double deltaY)
	{
		if (self != null)
		{
			Coordinate distances = new Coordinate(deltaX, deltaY);
			self.ExpandBy(distances);
		}
	}

	public static void ExpandToInclude(this IEnvelope self, Coordinate p)
	{
		if (self == null)
		{
			return;
		}
		if (!self.IsNull)
		{
			int num = Math.Min(self.NumOrdinates, p.NumOrdinates);
			Coordinate minimum = self.Minimum;
			Coordinate maximum = self.Maximum;
			for (int i = 0; i < num; i++)
			{
				if (p[i] < minimum[i])
				{
					minimum[i] = p[i];
				}
				if (p[i] > maximum[i])
				{
					maximum[i] = p[i];
				}
			}
			self.Init(minimum, maximum);
		}
		else
		{
			self.Init(p, p);
		}
	}

	public static void ExpandToInclude(this IEnvelope self, double x, double y)
	{
		self.ExpandToInclude(new Coordinate(x, y));
	}

	public static void ExpandToInclude(this IEnvelope self, IEnvelope other)
	{
		if (self == null || other == null || other.IsNull)
		{
			return;
		}
		if (!self.IsNull)
		{
			int num = Math.Min(self.NumOrdinates, other.NumOrdinates);
			Coordinate minimum = self.Minimum;
			Coordinate maximum = self.Maximum;
			for (int i = 0; i < num; i++)
			{
				if (other.Minimum[i] < minimum[i])
				{
					minimum[i] = other.Minimum[i];
				}
				if (other.Maximum[i] > maximum[i])
				{
					maximum[i] = other.Maximum[i];
				}
			}
			self.Init(minimum, maximum);
		}
		else
		{
			self.Init(other.Minimum, other.Maximum);
		}
	}

	public static ILineSegment Intersection(this IEnvelope self, ILineSegment segment)
	{
		if (self == null)
		{
			return null;
		}
		if (self.IsNull)
		{
			return null;
		}
		if (segment == null)
		{
			return null;
		}
		int num;
		if (!self.Contains(segment.P0))
		{
			num = 0;
		}
		else
		{
			if (self.Contains(segment.P1))
			{
				return segment;
			}
			num = 0;
		}
		int num2 = num;
		Coordinate[] array = new Coordinate[2];
		ILineSegment[] array2 = self.BorderSegments();
		for (int i = 0; i < 4; i++)
		{
			array[num2] = array2[i].Intersection(segment);
			if (array[num2] != null)
			{
				num2++;
				if (num2 > 1)
				{
					break;
				}
			}
		}
		switch (num2)
		{
		case 2:
		{
			Vector v = new Vector(segment.P0, segment.P1);
			if (!(new Vector(array[0], array[1]).Dot(v) < 0.0))
			{
				return new LineSegment(array[0], array[1]);
			}
			return new LineSegment(array[1], array[0]);
		}
		case 1:
			if (!self.Contains(segment.P0))
			{
				if (!self.Contains(segment.P1))
				{
					return new LineSegment(array[0], array[0]);
				}
				return new LineSegment(array[0], segment.P1);
			}
			return new LineSegment(segment.P0, array[0]);
		default:
			return null;
		}
	}

	public static IEnvelope Intersection(this IEnvelope self, IEnvelope env)
	{
		if (!self.IsNull && !env.IsNull && self.Intersects(env))
		{
			IEnvelope envelope;
			IEnvelope envelope2;
			if (env.NumOrdinates > self.NumOrdinates)
			{
				envelope = env;
				envelope2 = self;
			}
			else
			{
				envelope = self;
				envelope2 = env;
			}
			Coordinate coordinate = CloneableEM.Copy(envelope.Minimum);
			Coordinate coordinate2 = CloneableEM.Copy(envelope.Maximum);
			for (int i = 0; i < envelope2.NumOrdinates; i++)
			{
				if (envelope2.Minimum[i] > coordinate[i])
				{
					coordinate[i] = envelope2.Minimum[i];
				}
				if (envelope2.Maximum[i] < coordinate2[i])
				{
					coordinate2[i] = envelope2.Maximum[i];
				}
			}
			return new Envelope(coordinate, coordinate2);
		}
		return new Envelope();
	}

	public static IBasicGeometry Intersection(this IEnvelope self, IBasicGeometry geom)
	{
		if (self != null && geom != null)
		{
			if (self.IsNull)
			{
				return null;
			}
			IEnvelope envelope = geom.Envelope;
			if (!envelope.Intersects(self))
			{
				return null;
			}
			if (self.Contains(envelope))
			{
				return geom;
			}
			return Geometry.FromBasicGeometry(geom).Intersection(self.ToPolygon());
		}
		return null;
	}

	public static bool Intersects(this IEnvelope self, Coordinate p)
	{
		int result;
		if (self == null)
		{
			result = 0;
		}
		else
		{
			if (!(p == null))
			{
				if (!self.IsNull)
				{
					int num = Math.Min(self.NumOrdinates, p.NumOrdinates);
					int num2 = 0;
					int result2;
					while (true)
					{
						if (num2 < num)
						{
							if (!(p[num2] < self.Minimum[num2]))
							{
								if (p[num2] <= self.Maximum[num2])
								{
									num2++;
									continue;
								}
								result2 = 0;
								break;
							}
							result2 = 0;
							break;
						}
						return true;
					}
					return (byte)result2 != 0;
				}
				return false;
			}
			result = 0;
		}
		return (byte)result != 0;
	}

	public static bool Intersects(this IEnvelope self, double x, double y)
	{
		return self.Intersects(new Coordinate(x, y));
	}

	public static bool Intersects(this IEnvelope self, ILineSegment segment)
	{
		if (self.Intersection(segment) == null)
		{
			return false;
		}
		return true;
	}

	public static bool Intersects(this IEnvelope self, IEnvelope other)
	{
		int result;
		if (self == null)
		{
			result = 0;
		}
		else
		{
			if (other != null)
			{
				int result2;
				if (self.IsNull)
				{
					result2 = 0;
				}
				else
				{
					if (!other.IsNull)
					{
						int num = Math.Min(self.NumOrdinates, other.NumOrdinates);
						int num2 = 0;
						int result3;
						while (true)
						{
							if (num2 < num)
							{
								if (!(other.Minimum[num2] > self.Maximum[num2]))
								{
									if (other.Maximum[num2] >= self.Minimum[num2])
									{
										num2++;
										continue;
									}
									result3 = 0;
									break;
								}
								result3 = 0;
								break;
							}
							return true;
						}
						return (byte)result3 != 0;
					}
					result2 = 0;
				}
				return (byte)result2 != 0;
			}
			result = 0;
		}
		return (byte)result != 0;
	}

	static EnvelopeExt()
	{
		Class72.smethod_20();
	}
}
