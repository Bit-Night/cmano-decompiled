using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using DotSpatial.Serialization;

namespace DotSpatial.Topology;

[Serializable]
[TypeConverter(typeof(ExpandableObjectConverter))]
public class Envelope : IEnvelope, ICloneable, IRectangle
{
	[Serialize("Max")]
	private Coordinate coordinate_0;

	[Serialize("Min")]
	private Coordinate coordinate_1;

	[CompilerGenerated]
	private EventHandler eventHandler_0;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public virtual GeometryType GeometryType => GeometryType.Envelope;

	[Description("Gets the Horizontal boundaries in geographic coordinates")]
	[Category("Range")]
	public string BoundsX => coordinate_1.X + " - " + coordinate_0.X;

	[Category("Range")]
	[Description("Gets the Horizontal boundaries in geographic coordinates")]
	public string BoundsY => coordinate_1.Y + " - " + coordinate_0.Y;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Coordinate Minimum => coordinate_1;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public Coordinate Maximum => coordinate_0;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public int NumOrdinates => coordinate_1.NumOrdinates;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public virtual bool IsNull
	{
		get
		{
			if (!(coordinate_0 == null) && !(coordinate_1 == null))
			{
				return coordinate_0.X < coordinate_1.X;
			}
			return true;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public virtual double Height
	{
		get
		{
			if (!IsNull)
			{
				return Maximum.Y - Minimum.Y;
			}
			return 0.0;
		}
		set
		{
			double num = Math.Abs(value);
			coordinate_0.Y = coordinate_1.Y + num;
			OnEnvelopeChanged();
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public virtual double Width
	{
		get
		{
			if (IsNull)
			{
				return 0.0;
			}
			return coordinate_0.X - coordinate_1.X;
		}
		set
		{
			coordinate_0.X = value + coordinate_1.X;
			OnEnvelopeChanged();
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public virtual double X
	{
		get
		{
			return coordinate_1.X;
		}
		set
		{
			double width = Width;
			coordinate_1.X = value;
			coordinate_0.X = value + width;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public virtual double Y
	{
		get
		{
			return coordinate_0.Y;
		}
		set
		{
			double height = Height;
			coordinate_0.Y = value;
			coordinate_1.Y = value - height;
		}
	}

	public event EventHandler EnvelopeChanged
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = eventHandler_0;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = eventHandler_0;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public Envelope()
	{
		method_0();
	}

	public Envelope(double x1, double x2, double y1, double y2)
	{
		Coordinate coordinate_ = new Coordinate(Math.Min(x1, x2), Math.Min(y1, y2));
		Coordinate coordinate_2 = new Coordinate(Math.Max(x1, x2), Math.Max(y1, y2));
		method_1(coordinate_, coordinate_2);
	}

	public Envelope(double x1, double x2, double y1, double y2, double z1, double z2)
	{
		Coordinate coordinate_ = new Coordinate(Math.Min(x1, x2), Math.Min(y1, y2), Math.Min(z1, z2));
		Coordinate coordinate_2 = new Coordinate(Math.Max(x1, x2), Math.Max(y1, y2), Math.Max(z1, z2));
		method_1(coordinate_, coordinate_2);
	}

	public Envelope(IEnvelope inEnvelope)
	{
		Coordinate coordinate_ = CloneableEM.Copy(inEnvelope.Minimum);
		Coordinate coordinate_2 = CloneableEM.Copy(inEnvelope.Maximum);
		method_1(coordinate_, coordinate_2);
	}

	public Envelope(Coordinate p1, Coordinate p2)
	{
		if (!(p1 == null) && !(p2 == null))
		{
			int numOrdinates = p1.NumOrdinates;
			int numOrdinates2 = p2.NumOrdinates;
			int num = ((numOrdinates <= numOrdinates2) ? numOrdinates : numOrdinates2);
			coordinate_1 = new Coordinate();
			coordinate_0 = new Coordinate();
			for (int i = 0; i < num; i++)
			{
				double val = p1[i];
				double val2 = p2[i];
				coordinate_1[i] = Math.Min(val, val2);
				coordinate_0[i] = Math.Max(val, val2);
			}
			coordinate_1.M = Math.Min(p1.M, p2.M);
			coordinate_0.M = Math.Max(p1.M, p2.M);
		}
	}

	public Envelope(Coordinate p)
	{
		method_1(CloneableEM.Copy(p), CloneableEM.Copy(p));
	}

	public Envelope(double[] extents, double mMin, double mMax)
	{
		coordinate_1 = new Coordinate();
		coordinate_0 = new Coordinate();
		for (int i = 0; i < extents.Length / 2; i++)
		{
			coordinate_1[i] = extents[i * 2];
			coordinate_0[i] = extents[i * 2 + 1];
		}
		coordinate_1.M = mMin;
		coordinate_0.M = mMax;
	}

	public Envelope(double[] extents)
		: this(extents, 0.0, 0.0)
	{
	}

	public virtual void Init(Coordinate p1, Coordinate p2)
	{
		bool flag = p1 == null;
		bool flag2 = p2 == null;
		if (!(flag && flag2))
		{
			if (!flag)
			{
				if (flag2)
				{
					Init(p1, p1);
					return;
				}
				int num = ((p1.NumOrdinates < p2.NumOrdinates) ? p1.NumOrdinates : p2.NumOrdinates);
				coordinate_1 = new Coordinate();
				coordinate_0 = new Coordinate();
				for (int i = 0; i < num; i++)
				{
					double num2 = p1[i];
					double num3 = p2[i];
					coordinate_1[i] = ((num2 < num3) ? num2 : num3);
					coordinate_0[i] = ((num2 > num3) ? num2 : num3);
				}
				coordinate_1.M = ((p1.M < p2.M) ? p1.M : p2.M);
				coordinate_0.M = ((p1.M > p2.M) ? p1.M : p2.M);
				OnEnvelopeChanged();
			}
			else
			{
				Init(p2, p2);
			}
		}
		else
		{
			Init();
		}
	}

	private void method_0()
	{
		coordinate_1 = new Coordinate(0.0, 0.0);
		coordinate_0 = new Coordinate(-1.0, -1.0);
	}

	private void method_1(Coordinate coordinate_2, Coordinate coordinate_3)
	{
		coordinate_1 = coordinate_2;
		coordinate_0 = coordinate_3;
	}

	public virtual void Init()
	{
		SetToNull();
	}

	public virtual void Init(double x1, double x2, double y1, double y2)
	{
		coordinate_1 = new Coordinate();
		coordinate_0 = new Coordinate();
		coordinate_1.X = Math.Min(x1, x2);
		coordinate_0.X = Math.Max(x1, x2);
		coordinate_1.Y = Math.Min(y1, y2);
		coordinate_0.Y = Math.Max(y1, y2);
		OnEnvelopeChanged();
	}

	public virtual void Init(double x1, double x2, double y1, double y2, double z1, double z2)
	{
		coordinate_1 = new Coordinate();
		coordinate_0 = new Coordinate();
		coordinate_1.X = Math.Min(x1, x2);
		coordinate_0.X = Math.Max(x1, x2);
		coordinate_1.Y = Math.Min(y1, y2);
		coordinate_0.Y = Math.Max(y1, y2);
		coordinate_0.Z = Math.Max(z1, z2);
		coordinate_1.Z = Math.Min(z1, z2);
		OnEnvelopeChanged();
	}

	public virtual void Init(Coordinate p)
	{
		if (p == null)
		{
			Init();
			return;
		}
		coordinate_1 = CloneableEM.Copy(p);
		coordinate_0 = CloneableEM.Copy(p);
		OnEnvelopeChanged();
	}

	public virtual void Init(IEnvelope env)
	{
		if (env.Maximum == null || env.Minimum == null)
		{
			Init();
		}
		if (env.Maximum != null)
		{
			coordinate_0 = CloneableEM.Copy(env.Maximum);
		}
		if (env.Minimum != null)
		{
			coordinate_1 = CloneableEM.Copy(env.Minimum);
		}
		OnEnvelopeChanged();
	}

	public bool HasM()
	{
		int result;
		if (double.IsNaN(Minimum.M))
		{
			result = 0;
		}
		else
		{
			if (!double.IsNaN(Maximum.M))
			{
				if (Minimum.M > Maximum.M)
				{
					return false;
				}
				return true;
			}
			result = 0;
		}
		return (byte)result != 0;
	}

	public bool HasZ()
	{
		int result;
		if (double.IsNaN(Minimum.Z))
		{
			result = 0;
		}
		else
		{
			if (!double.IsNaN(Maximum.Z))
			{
				if (Minimum.Z > Maximum.Z)
				{
					return false;
				}
				return true;
			}
			result = 0;
		}
		return (byte)result != 0;
	}

	public virtual object Clone()
	{
		return Copy();
	}

	IEnvelope IEnvelope.Copy()
	{
		return Copy();
	}

	public virtual void SetToNull()
	{
		coordinate_1 = new Coordinate();
		coordinate_0 = new Coordinate();
		for (int i = 0; i < NumOrdinates; i++)
		{
			coordinate_1[i] = 0.0;
			coordinate_0[i] = -1.0;
		}
		OnEnvelopeChanged();
	}

	public virtual Envelope Copy()
	{
		if (IsNull)
		{
			return new Envelope();
		}
		return new Envelope(coordinate_1, coordinate_0);
	}

	public static bool Intersects(Coordinate p1, Coordinate p2, Coordinate q)
	{
		return new Envelope(p1, p2).Intersects(q);
	}

	public static bool Intersects(Coordinate p1, Coordinate p2, Coordinate q1, Coordinate q2)
	{
		Envelope self = new Envelope(p1, p2);
		Envelope other = new Envelope(q1, q2);
		return self.Intersects(other);
	}

	public override string ToString()
	{
		string text = "Env[";
		for (int i = 0; i < NumOrdinates; i++)
		{
			if (i > 0)
			{
				text += ", ";
			}
			text = text + Minimum[i] + " : " + Maximum[i];
		}
		return text;
	}

	protected void OnEnvelopeChanged()
	{
		if (eventHandler_0 != null)
		{
			eventHandler_0(this, EventArgs.Empty);
		}
	}

	static Envelope()
	{
		Class72.smethod_20();
	}
}
