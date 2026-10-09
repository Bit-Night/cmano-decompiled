using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using Command_Core;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

public class NetworkGraphPanel : Control
{
	public class GraphNode
	{
		[CompilerGenerated]
		private string string_0;

		[CompilerGenerated]
		private string string_1;

		[CompilerGenerated]
		private List<(string, Color)> list_0;

		[CompilerGenerated]
		private PointF pointF_0;

		[CompilerGenerated]
		private ActiveUnit activeUnit_0;

		[CompilerGenerated]
		private string string_2;

		public const float Radius = 30f;

		public string ID
		{
			[CompilerGenerated]
			get
			{
				return string_0;
			}
			[CompilerGenerated]
			set
			{
				string_0 = value;
			}
		}

		public string Label
		{
			[CompilerGenerated]
			get
			{
				return string_1;
			}
			[CompilerGenerated]
			set
			{
				string_1 = value;
			}
		}

		public List<(string NetworkID, Color NetworkColor)> NetworkMemberships
		{
			[CompilerGenerated]
			get
			{
				return list_0;
			}
			[CompilerGenerated]
			set
			{
				list_0 = value;
			}
		}

		public PointF Position
		{
			[CompilerGenerated]
			get
			{
				return pointF_0;
			}
			[CompilerGenerated]
			set
			{
				pointF_0 = value;
			}
		}

		public ActiveUnit LinkedUnit
		{
			[CompilerGenerated]
			get
			{
				return activeUnit_0;
			}
			[CompilerGenerated]
			set
			{
				activeUnit_0 = value;
			}
		}

		public string IconPath
		{
			[CompilerGenerated]
			get
			{
				return string_2;
			}
			[CompilerGenerated]
			set
			{
				string_2 = value;
			}
		}

		public Color PrimaryNetworkColor
		{
			get
			{
				if (NetworkMemberships.Count == 0)
				{
					return Color.Gray;
				}
				return NetworkMemberships[0].NetworkColor;
			}
		}

		public string PrimaryNetworkID
		{
			get
			{
				if (NetworkMemberships.Count == 0)
				{
					return "";
				}
				return NetworkMemberships[0].NetworkID;
			}
		}

		public GraphNode()
		{
			NetworkMemberships = new List<(string, Color)>();
		}

		static GraphNode()
		{
			Class72.smethod_20();
		}
	}

	public delegate void PathRequestedEventHandler(object sender, GraphNode source, GraphNode dest);

	public class GraphLink
	{
		[CompilerGenerated]
		private GraphNode graphNode_0;

		[CompilerGenerated]
		private GraphNode graphNode_1;

		[CompilerGenerated]
		private bool bool_0;

		[CompilerGenerated]
		private string string_0;

		[CompilerGenerated]
		private float float_0;

		[CompilerGenerated]
		private CommDevice commDevice_0;

		[CompilerGenerated]
		private CommDevice commDevice_1;

		[CompilerGenerated]
		private Color color_0;

		[CompilerGenerated]
		private bool bool_1;

		[CompilerGenerated]
		private int int_0;

		[CompilerGenerated]
		private string string_1;

		[CompilerGenerated]
		private string string_2;

		[CompilerGenerated]
		private int int_1;

		public GraphNode Source
		{
			[CompilerGenerated]
			get
			{
				return graphNode_0;
			}
			[CompilerGenerated]
			set
			{
				graphNode_0 = value;
			}
		}

		public GraphNode Target
		{
			[CompilerGenerated]
			get
			{
				return graphNode_1;
			}
			[CompilerGenerated]
			set
			{
				graphNode_1 = value;
			}
		}

		public bool IsSuccess
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

		public string Label
		{
			[CompilerGenerated]
			get
			{
				return string_0;
			}
			[CompilerGenerated]
			set
			{
				string_0 = value;
			}
		}

		public float Thickness
		{
			[CompilerGenerated]
			get
			{
				return float_0;
			}
			[CompilerGenerated]
			set
			{
				float_0 = value;
			}
		}

		public CommDevice SourceDevice
		{
			[CompilerGenerated]
			get
			{
				return commDevice_0;
			}
			[CompilerGenerated]
			set
			{
				commDevice_0 = value;
			}
		}

		public CommDevice TargetDevice
		{
			[CompilerGenerated]
			get
			{
				return commDevice_1;
			}
			[CompilerGenerated]
			set
			{
				commDevice_1 = value;
			}
		}

		public Color Color
		{
			[CompilerGenerated]
			get
			{
				return color_0;
			}
			[CompilerGenerated]
			set
			{
				color_0 = value;
			}
		}

		public bool IsPathLink
		{
			[CompilerGenerated]
			get
			{
				return bool_1;
			}
			[CompilerGenerated]
			set
			{
				bool_1 = value;
			}
		}

		public int PathIndex
		{
			[CompilerGenerated]
			get
			{
				return int_0;
			}
			[CompilerGenerated]
			set
			{
				int_0 = value;
			}
		}

		public string JumpLabel
		{
			[CompilerGenerated]
			get
			{
				return string_1;
			}
			[CompilerGenerated]
			set
			{
				string_1 = value;
			}
		}

		public string PathSummaryLabel
		{
			[CompilerGenerated]
			get
			{
				return string_2;
			}
			[CompilerGenerated]
			set
			{
				string_2 = value;
			}
		}

		public int TotalPaths
		{
			[CompilerGenerated]
			get
			{
				return int_1;
			}
			[CompilerGenerated]
			set
			{
				int_1 = value;
			}
		}

		public GraphLink()
		{
			IsPathLink = false;
			PathIndex = 0;
			JumpLabel = "";
			PathSummaryLabel = "";
			TotalPaths = 1;
		}

		static GraphLink()
		{
			Class72.smethod_20();
		}
	}

	public delegate void NodeSelectedEventHandler(object sender, GraphNode node);

	public delegate void NodeDeselectedEventHandler(object sender);

	private struct Struct2
	{
		public GraphicsPath Path;

		public Color color_0;

		public Color color_1;
	}

	private GraphNode graphNode_0;

	private readonly Color[] color_0;

	[CompilerGenerated]
	private PathRequestedEventHandler pathRequestedEventHandler_0;

	[CompilerGenerated]
	private NodeSelectedEventHandler nodeSelectedEventHandler_0;

	[CompilerGenerated]
	private NodeDeselectedEventHandler nodeDeselectedEventHandler_0;

	private List<GraphNode> list_0;

	private List<GraphLink> list_1;

	private GraphNode graphNode_1;

	private GraphNode graphNode_2;

	private GraphNode graphNode_3;

	private PointF pointF_0;

	private float float_0;

	private float float_1;

	private float float_2;

	private Point point_0;

	private bool bool_0;

	private Dictionary<string, Bitmap> dictionary_0;

	private string string_0;

	private List<Struct2> list_2;

	private bool bool_1;

	private readonly Color color_1;

	private readonly Color color_2;

	private readonly Color color_3;

	private readonly Color color_4;

	private readonly Color color_5;

	private readonly Color color_6;

	private readonly Color color_7;

	private readonly Color color_8;

	private readonly Color color_9;

	private readonly Color color_10;

	private readonly Color color_11;

	public string FilterText
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = ((value == null) ? "" : value.Trim().ToLower());
			((Control)this).Invalidate();
		}
	}

	public event PathRequestedEventHandler PathRequested
	{
		[CompilerGenerated]
		add
		{
			PathRequestedEventHandler pathRequestedEventHandler = pathRequestedEventHandler_0;
			PathRequestedEventHandler pathRequestedEventHandler2;
			do
			{
				pathRequestedEventHandler2 = pathRequestedEventHandler;
				PathRequestedEventHandler value2 = (PathRequestedEventHandler)Delegate.Combine(pathRequestedEventHandler2, value);
				pathRequestedEventHandler = Interlocked.CompareExchange(ref pathRequestedEventHandler_0, value2, pathRequestedEventHandler2);
			}
			while ((object)pathRequestedEventHandler != pathRequestedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			PathRequestedEventHandler pathRequestedEventHandler = pathRequestedEventHandler_0;
			PathRequestedEventHandler pathRequestedEventHandler2;
			do
			{
				pathRequestedEventHandler2 = pathRequestedEventHandler;
				PathRequestedEventHandler value2 = (PathRequestedEventHandler)Delegate.Remove(pathRequestedEventHandler2, value);
				pathRequestedEventHandler = Interlocked.CompareExchange(ref pathRequestedEventHandler_0, value2, pathRequestedEventHandler2);
			}
			while ((object)pathRequestedEventHandler != pathRequestedEventHandler2);
		}
	}

	public event NodeSelectedEventHandler NodeSelected
	{
		[CompilerGenerated]
		add
		{
			NodeSelectedEventHandler nodeSelectedEventHandler = nodeSelectedEventHandler_0;
			NodeSelectedEventHandler nodeSelectedEventHandler2;
			do
			{
				nodeSelectedEventHandler2 = nodeSelectedEventHandler;
				NodeSelectedEventHandler value2 = (NodeSelectedEventHandler)Delegate.Combine(nodeSelectedEventHandler2, value);
				nodeSelectedEventHandler = Interlocked.CompareExchange(ref nodeSelectedEventHandler_0, value2, nodeSelectedEventHandler2);
			}
			while ((object)nodeSelectedEventHandler != nodeSelectedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			NodeSelectedEventHandler nodeSelectedEventHandler = nodeSelectedEventHandler_0;
			NodeSelectedEventHandler nodeSelectedEventHandler2;
			do
			{
				nodeSelectedEventHandler2 = nodeSelectedEventHandler;
				NodeSelectedEventHandler value2 = (NodeSelectedEventHandler)Delegate.Remove(nodeSelectedEventHandler2, value);
				nodeSelectedEventHandler = Interlocked.CompareExchange(ref nodeSelectedEventHandler_0, value2, nodeSelectedEventHandler2);
			}
			while ((object)nodeSelectedEventHandler != nodeSelectedEventHandler2);
		}
	}

	public event NodeDeselectedEventHandler NodeDeselected
	{
		[CompilerGenerated]
		add
		{
			NodeDeselectedEventHandler nodeDeselectedEventHandler = nodeDeselectedEventHandler_0;
			NodeDeselectedEventHandler nodeDeselectedEventHandler2;
			do
			{
				nodeDeselectedEventHandler2 = nodeDeselectedEventHandler;
				NodeDeselectedEventHandler value2 = (NodeDeselectedEventHandler)Delegate.Combine(nodeDeselectedEventHandler2, value);
				nodeDeselectedEventHandler = Interlocked.CompareExchange(ref nodeDeselectedEventHandler_0, value2, nodeDeselectedEventHandler2);
			}
			while ((object)nodeDeselectedEventHandler != nodeDeselectedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			NodeDeselectedEventHandler nodeDeselectedEventHandler = nodeDeselectedEventHandler_0;
			NodeDeselectedEventHandler nodeDeselectedEventHandler2;
			do
			{
				nodeDeselectedEventHandler2 = nodeDeselectedEventHandler;
				NodeDeselectedEventHandler value2 = (NodeDeselectedEventHandler)Delegate.Remove(nodeDeselectedEventHandler2, value);
				nodeDeselectedEventHandler = Interlocked.CompareExchange(ref nodeDeselectedEventHandler_0, value2, nodeDeselectedEventHandler2);
			}
			while ((object)nodeDeselectedEventHandler != nodeDeselectedEventHandler2);
		}
	}

	public NetworkGraphPanel()
	{
		graphNode_0 = null;
		color_0 = new Color[5]
		{
			Color.FromArgb(255, 210, 0),
			Color.FromArgb(0, 200, 255),
			Color.FromArgb(255, 130, 30),
			Color.FromArgb(185, 90, 255),
			Color.FromArgb(60, 230, 170)
		};
		list_0 = new List<GraphNode>();
		list_1 = new List<GraphLink>();
		float_0 = 0.7f;
		float_1 = 0f;
		float_2 = 0f;
		dictionary_0 = new Dictionary<string, Bitmap>();
		string_0 = "";
		list_2 = new List<Struct2>();
		bool_1 = true;
		color_1 = Color.FromArgb(38, 38, 42);
		color_2 = Color.FromArgb(50, 50, 55);
		color_3 = Color.FromArgb(60, 60, 66);
		color_4 = Color.FromArgb(180, 180, 190);
		color_5 = Color.FromArgb(100, 170, 255);
		color_6 = Color.FromArgb(225, 225, 230);
		color_7 = Color.FromArgb(80, 220, 140);
		color_8 = Color.FromArgb(220, 70, 70);
		color_9 = Color.FromArgb(225, 110, 130);
		color_10 = Color.FromArgb(90, 150, 150, 160);
		color_11 = Color.FromArgb(255, 235, 100);
		((Control)this).SetStyle((ControlStyles)8192, true);
		((Control)this).SetStyle((ControlStyles)2, true);
		((Control)this).SetStyle((ControlStyles)65536, true);
		((Control)this).SetStyle((ControlStyles)16, true);
		((Control)this).BackColor = color_1;
	}

	private Bitmap method_0(string string_1)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Expected O, but got Unknown
		Bitmap result;
		if (!string.IsNullOrEmpty(string_1))
		{
			if (!dictionary_0.ContainsKey(string_1))
			{
				try
				{
					Bitmap val = new Bitmap(string_1);
					dictionary_0[string_1] = val;
					result = val;
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					dictionary_0[string_1] = null;
					result = null;
					ProjectData.ClearProjectError();
				}
			}
			else
			{
				result = dictionary_0[string_1];
			}
		}
		else
		{
			result = null;
		}
		return result;
	}

	private void method_1()
	{
		foreach (Bitmap value in dictionary_0.Values)
		{
			if (value != null)
			{
				((Image)value).Dispose();
			}
		}
		dictionary_0.Clear();
	}

	private void method_2()
	{
		foreach (Struct2 item in list_2)
		{
			GraphicsPath path = item.Path;
			if (path != null)
			{
				path.Dispose();
			}
		}
		list_2.Clear();
		bool_1 = true;
	}

	private void method_3()
	{
		//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fa: Expected O, but got Unknown
		//IL_02f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fd: Expected O, but got Unknown
		foreach (Struct2 item2 in list_2)
		{
			GraphicsPath path = item2.Path;
			if (path != null)
			{
				path.Dispose();
			}
		}
		list_2.Clear();
		List<string> list = new List<string>();
		foreach (GraphNode item3 in list_0)
		{
			foreach (var networkMembership in item3.NetworkMemberships)
			{
				if (!list.Contains(networkMembership.NetworkID))
				{
					list.Add(networkMembership.NetworkID);
				}
			}
		}
		Struct2 item = default(Struct2);
		foreach (string item4 in list)
		{
			List<GraphNode> list2 = new List<GraphNode>();
			foreach (GraphNode item5 in list_0)
			{
				foreach (var networkMembership2 in item5.NetworkMemberships)
				{
					if (Operators.CompareString(networkMembership2.NetworkID, item4, true) == 0)
					{
						list2.Add(item5);
						break;
					}
				}
			}
			if (list2.Count == 0)
			{
				continue;
			}
			Color baseColor = Color.Gray;
			foreach (var networkMembership3 in list2[0].NetworkMemberships)
			{
				if (Operators.CompareString(networkMembership3.NetworkID, item4, true) == 0)
				{
					baseColor = networkMembership3.NetworkColor;
					break;
				}
			}
			float num = 48f;
			item.color_0 = Color.FromArgb(25, baseColor);
			item.color_1 = Color.FromArgb(65, baseColor);
			if (list2.Count == 1)
			{
				PointF position = list2[0].Position;
				GraphicsPath val = new GraphicsPath();
				val.AddEllipse(position.X - num, position.Y - num, num * 2f, num * 2f);
				item.Path = val;
				list_2.Add(item);
				continue;
			}
			List<PointF> list3 = new List<PointF>();
			foreach (GraphNode item6 in list2)
			{
				int num2 = 0;
				do
				{
					double num3 = Math.PI * 2.0 * (double)num2 / 16.0;
					list3.Add(new PointF(item6.Position.X + (float)Math.Cos(num3) * num, item6.Position.Y + (float)Math.Sin(num3) * num));
					num2++;
				}
				while (num2 <= 15);
			}
			List<PointF> list4 = smethod_4(list3);
			if (list4.Count < 3)
			{
				continue;
			}
			GraphicsPath val2 = new GraphicsPath();
			int count = list4.Count;
			int num4 = count - 1;
			for (int i = 0; i <= num4; i++)
			{
				PointF pointF = list4[(i + count - 1) % count];
				PointF pointF2 = list4[i];
				PointF pointF_ = list4[(i + 1) % count];
				float num5 = Math.Min(smethod_2(pointF, pointF2) * 0.35f, Math.Min(smethod_2(pointF2, pointF_) * 0.35f, 22f));
				PointF pointF3 = smethod_3(pointF2, pointF, num5 / Math.Max(smethod_2(pointF2, pointF), 1f));
				PointF pointF4 = smethod_3(pointF2, pointF_, num5 / Math.Max(smethod_2(pointF2, pointF_), 1f));
				if (i == 0)
				{
					val2.StartFigure();
					val2.AddLine(pointF3, pointF3);
				}
				val2.AddBezier(pointF3, pointF2, pointF2, pointF4);
			}
			val2.CloseFigure();
			item.Path = val2;
			list_2.Add(item);
		}
		bool_1 = false;
	}

	public void SetGraph(IEnumerable<GraphNode> nodes, IEnumerable<GraphLink> Links)
	{
		method_1();
		method_2();
		list_0 = new List<GraphNode>(nodes);
		list_1 = new List<GraphLink>(Links);
		graphNode_1 = null;
		graphNode_2 = null;
		graphNode_3 = null;
		method_4();
		ResetView();
	}

	public void SetLinks(IEnumerable<GraphLink> Links)
	{
		list_1 = new List<GraphLink>(Links);
		((Control)this).Invalidate();
	}

	public void StartLayout()
	{
	}

	public void ResetView()
	{
		float_0 = 0.7f;
		float_1 = (float)((Control)this).Width / 2f;
		float_2 = (float)((Control)this).Height / 2f;
		((Control)this).Invalidate();
	}

	private void method_4()
	{
		if (list_0.Count == 0)
		{
			return;
		}
		float num = Math.Max(150, list_0.Count * 25);
		List<IGrouping<string, GraphNode>> list = (from n in list_0
			group n by n.PrimaryNetworkID).ToList();
		int num2 = list.Count - 1;
		for (int num3 = 0; num3 <= num2; num3++)
		{
			double num4 = Math.PI * 2.0 * (double)num3 / (double)list.Count;
			float num5 = (float)(Math.Cos(num4) * (double)num);
			float num6 = (float)(Math.Sin(num4) * (double)num);
			List<GraphNode> list2 = list[num3].ToList();
			float num7 = Math.Max(50, list2.Count * 18);
			int num8 = list2.Count - 1;
			for (int num9 = 0; num9 <= num8; num9++)
			{
				double num10 = Math.PI * 2.0 * (double)num9 / (double)Math.Max(1, list2.Count);
				list2[num9].Position = new PointF(num5 + (float)(Math.Cos(num10) * (double)num7), num6 + (float)(Math.Sin(num10) * (double)num7));
			}
		}
	}

	private PointF method_5(Point point_1)
	{
		return new PointF(((float)point_1.X - float_1) / float_0, ((float)point_1.Y - float_2) / float_0);
	}

	private GraphNode method_6(Point point_1)
	{
		PointF pointF = method_5(point_1);
		foreach (GraphNode item in list_0)
		{
			float num = item.Position.X - pointF.X;
			float num2 = item.Position.Y - pointF.Y;
			if (!(Math.Sqrt(num * num + num2 * num2) > 32.0))
			{
				return item;
			}
		}
		return null;
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Invalid comparison between Unknown and I4
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Invalid comparison between Unknown and I4
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Invalid comparison between Unknown and I4
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Invalid comparison between Unknown and I4
		((Control)this).OnMouseDown(e);
		((Control)this).Focus();
		point_0 = e.Location;
		if ((int)e.Button == 1048576)
		{
			GraphNode graphNode = method_6(e.Location);
			if (graphNode != null)
			{
				if ((Control.ModifierKeys & 0x10000) == 65536 && graphNode_1 != null && graphNode != graphNode_1)
				{
					GraphNode source = graphNode_1;
					graphNode_1 = null;
					list_1.Clear();
					((Control)this).Invalidate();
					pathRequestedEventHandler_0?.Invoke(this, source, graphNode);
				}
				else
				{
					graphNode_0 = null;
					graphNode_3 = graphNode;
					PointF pointF = method_5(e.Location);
					pointF_0 = new PointF(pointF.X - graphNode.Position.X, pointF.Y - graphNode.Position.Y);
					graphNode_1 = graphNode;
					nodeSelectedEventHandler_0?.Invoke(this, graphNode);
				}
			}
			else
			{
				graphNode_1 = null;
				graphNode_0 = null;
				graphNode_3 = null;
				nodeDeselectedEventHandler_0?.Invoke(this);
			}
			((Control)this).Invalidate();
		}
		else if ((int)e.Button == 2097152 || (int)e.Button == 4194304)
		{
			bool_0 = true;
			((Control)this).Cursor = Cursors.SizeAll;
		}
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Invalid comparison between Unknown and I4
		((Control)this).OnMouseMove(e);
		if (!bool_0)
		{
			if (graphNode_3 != null && (int)e.Button == 1048576)
			{
				PointF pointF = method_5(e.Location);
				graphNode_3.Position = new PointF(pointF.X - pointF_0.X, pointF.Y - pointF_0.Y);
				((Control)this).Invalidate();
				return;
			}
			GraphNode graphNode = graphNode_2;
			graphNode_2 = method_6(e.Location);
			if (graphNode != graphNode_2)
			{
				((Control)this).Cursor = ((graphNode_2 != null) ? Cursors.Hand : Cursors.Default);
				((Control)this).Invalidate();
			}
			point_0 = e.Location;
		}
		else
		{
			float_1 += e.X - point_0.X;
			float_2 += e.Y - point_0.Y;
			point_0 = e.Location;
			((Control)this).Invalidate();
		}
	}

	protected override void OnMouseUp(MouseEventArgs e)
	{
		((Control)this).OnMouseUp(e);
		if (graphNode_3 != null)
		{
			bool_1 = true;
			((Control)this).Invalidate();
		}
		graphNode_3 = null;
		if (bool_0)
		{
			bool_0 = false;
			((Control)this).Cursor = Cursors.Default;
		}
	}

	protected override void OnMouseWheel(MouseEventArgs e)
	{
		((Control)this).OnMouseWheel(e);
		float num = ((e.Delta > 0) ? 1.12f : (25f / 28f));
		float_1 = (float)e.X - ((float)e.X - float_1) * num;
		float_2 = (float)e.Y - ((float)e.Y - float_2) * num;
		float_0 = (float)Math.Max(0.08, Math.Min(5.0, float_0 * num));
		((Control)this).Invalidate();
	}

	protected override void OnMouseDoubleClick(MouseEventArgs e)
	{
		((Control)this).OnMouseDoubleClick(e);
		ResetView();
	}

	protected override void OnKeyDown(KeyEventArgs e)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Invalid comparison between Unknown and I4
		((Control)this).OnKeyDown(e);
		if ((int)e.KeyCode == 27)
		{
			graphNode_1 = null;
			nodeDeselectedEventHandler_0?.Invoke(this);
			((Control)this).Invalidate();
		}
	}

	protected override bool IsInputKey(Keys keyData)
	{
		return true;
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		Graphics graphics = e.Graphics;
		bool bool_;
		if (!(bool_ = graphNode_3 != null))
		{
			graphics.SmoothingMode = (SmoothingMode)4;
			graphics.TextRenderingHint = (TextRenderingHint)5;
			graphics.InterpolationMode = (InterpolationMode)7;
		}
		else
		{
			graphics.SmoothingMode = (SmoothingMode)1;
			graphics.TextRenderingHint = (TextRenderingHint)2;
			graphics.InterpolationMode = (InterpolationMode)1;
		}
		graphics.Clear(color_1);
		method_7(graphics);
		graphics.TranslateTransform(float_1, float_2);
		graphics.ScaleTransform(float_0, float_0);
		method_8(graphics, bool_);
		method_9(graphics, bool_);
		method_11(graphics, bool_);
		graphics.ResetTransform();
		method_12(graphics);
	}

	private void method_7(Graphics graphics_0)
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Expected O, but got Unknown
		float num = 40f * float_0;
		float num2 = 200f * float_0;
		if (num < 8f)
		{
			return;
		}
		float num3 = float_1 % num;
		float num4 = float_2 % num;
		float num5 = float_1 % num2;
		float num6 = float_2 % num2;
		Pen val = new Pen(color_2, 1f);
		try
		{
			for (float num7 = num3; num7 < (float)((Control)this).Width; num7 += num)
			{
				graphics_0.DrawLine(val, num7, 0f, num7, (float)((Control)this).Height);
			}
			for (float num8 = num4; num8 < (float)((Control)this).Height; num8 += num)
			{
				graphics_0.DrawLine(val, 0f, num8, (float)((Control)this).Width, num8);
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
		Pen val2 = new Pen(color_3, 1f);
		try
		{
			for (float num9 = num5; num9 < (float)((Control)this).Width; num9 += num2)
			{
				graphics_0.DrawLine(val2, num9, 0f, num9, (float)((Control)this).Height);
			}
			for (float num10 = num6; num10 < (float)((Control)this).Height; num10 += num2)
			{
				graphics_0.DrawLine(val2, 0f, num10, (float)((Control)this).Width, num10);
			}
		}
		finally
		{
			((IDisposable)val2)?.Dispose();
		}
	}

	private void method_8(Graphics graphics_0, bool bool_2)
	{
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Expected O, but got Unknown
		if (list_0.Count == 0)
		{
			return;
		}
		if (bool_1 && !bool_2)
		{
			method_3();
		}
		foreach (Struct2 item in list_2)
		{
			if (item.Path != null)
			{
				SolidBrush val = new SolidBrush(item.color_0);
				try
				{
					graphics_0.FillPath((Brush)(object)val, item.Path);
				}
				finally
				{
					((IDisposable)val)?.Dispose();
				}
				Pen val2 = new Pen(item.color_1, 1.5f);
				try
				{
					val2.DashStyle = (DashStyle)1;
					graphics_0.DrawPath(val2, item.Path);
				}
				finally
				{
					((IDisposable)val2)?.Dispose();
				}
			}
		}
	}

	private void method_9(Graphics graphics_0, bool bool_2)
	{
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_019a: Expected O, but got Unknown
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d0: Expected O, but got Unknown
		//IL_01da: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e1: Expected O, but got Unknown
		//IL_03ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b2: Expected O, but got Unknown
		//IL_0496: Unknown result type (might be due to invalid IL or missing references)
		//IL_049d: Expected O, but got Unknown
		//IL_0471: Unknown result type (might be due to invalid IL or missing references)
		//IL_0478: Expected O, but got Unknown
		//IL_04b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04be: Expected O, but got Unknown
		//IL_0558: Unknown result type (might be due to invalid IL or missing references)
		//IL_055f: Expected O, but got Unknown
		//IL_0580: Unknown result type (might be due to invalid IL or missing references)
		//IL_0587: Expected O, but got Unknown
		//IL_05e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ec: Expected O, but got Unknown
		bool flag = list_1.Any([SpecialName] (GraphLink e) => e.IsPathLink);
		foreach (GraphLink item in list_1)
		{
			if (!item.IsPathLink || item.Source == null || item.Target == null)
			{
				continue;
			}
			Color color = color_0[item.PathIndex % color_0.Length];
			PointF position = item.Source.Position;
			PointF position2 = item.Target.Position;
			float num = position2.X - position.X;
			float num2 = position2.Y - position.Y;
			float num3 = (float)Math.Max(1.0, Math.Sqrt(num * num + num2 * num2));
			float num4 = (0f - num2) / num3;
			float num5 = num / num3;
			float num6 = ((float)item.PathIndex - (float)(item.TotalPaths - 1) / 2f) * 64f;
			PointF pointF = new PointF(position.X + num / 3f + num4 * num6, position.Y + num2 / 3f + num5 * num6);
			PointF pointF2 = new PointF(position.X + num * 2f / 3f + num4 * num6, position.Y + num2 * 2f / 3f + num5 * num6);
			Pen val = new Pen(Color.FromArgb(45, color), 8f);
			try
			{
				graphics_0.DrawBezier(val, position, pointF, pointF2, position2);
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
			Pen val2 = new Pen(Color.FromArgb(210, color), 2.8f);
			try
			{
				AdjustableArrowCap customEndCap = new AdjustableArrowCap(4f, 5f);
				val2.CustomEndCap = (CustomLineCap)(object)customEndCap;
				graphics_0.DrawBezier(val2, position, pointF, pointF2, position2);
			}
			finally
			{
				((IDisposable)val2)?.Dispose();
			}
			if (!bool_2)
			{
				float num7 = (position.X + 3f * pointF.X + 3f * pointF2.X + position2.X) / 8f;
				float num8 = (position.Y + 3f * pointF.Y + 3f * pointF2.Y + position2.Y) / 8f;
				if (!string.IsNullOrEmpty(item.JumpLabel))
				{
					method_10(graphics_0, item.JumpLabel, num7, num8, color);
				}
				if (!string.IsNullOrEmpty(item.PathSummaryLabel))
				{
					float float_ = (position2.X + num7) / 2f;
					float float_2 = (position2.Y + num8) / 2f - 18f;
					method_10(graphics_0, item.PathSummaryLabel, float_, float_2, color);
				}
			}
		}
		foreach (GraphLink item2 in list_1)
		{
			if (item2.IsPathLink || flag)
			{
				continue;
			}
			bool flag2 = graphNode_1 != null && (item2.Source == graphNode_1 || item2.Target == graphNode_1);
			if (!item2.IsSuccess && string.IsNullOrEmpty(item2.Label) && item2.Source != null && item2.Target != null && !flag2)
			{
				int alpha = ((graphNode_1 == null) ? 80 : 25);
				Pen val3 = new Pen(Color.FromArgb(alpha, color_9), 2f);
				try
				{
					graphics_0.DrawLine(val3, item2.Source.Position, item2.Target.Position);
				}
				finally
				{
					((IDisposable)val3)?.Dispose();
				}
				continue;
			}
			int alpha2 = ((graphNode_1 == null) ? 220 : (flag2 ? 220 : 35));
			Color baseColor = ((!item2.IsSuccess) ? color_8 : color_7);
			Color color2 = Color.FromArgb(alpha2, baseColor);
			float num9 = ((!flag2) ? item2.Thickness : (item2.Thickness * 1.5f));
			PointF position3 = item2.Source.Position;
			PointF position4 = item2.Target.Position;
			if (flag2 && !bool_2)
			{
				Pen val4 = new Pen(Color.FromArgb(40, color2), num9 + 6f);
				try
				{
					graphics_0.DrawLine(val4, position3, position4);
				}
				finally
				{
					((IDisposable)val4)?.Dispose();
				}
			}
			Pen val5 = new Pen(color2, num9);
			try
			{
				if (item2.IsSuccess && flag2 && !bool_2)
				{
					AdjustableArrowCap customEndCap2 = new AdjustableArrowCap(4f, 5f);
					val5.CustomEndCap = (CustomLineCap)(object)customEndCap2;
				}
				graphics_0.DrawLine(val5, position3, position4);
			}
			finally
			{
				((IDisposable)val5)?.Dispose();
			}
			if (!flag2 || bool_2 || string.IsNullOrEmpty(item2.Label))
			{
				continue;
			}
			float num10 = (position3.X + position4.X) / 2f;
			float num11 = (position3.Y + position4.Y) / 2f;
			float val6 = Math.Max(5f, 7.5f / float_0);
			Font val7 = new Font("Segoe UI", Math.Min(val6, 8.5f), (FontStyle)1);
			try
			{
				SizeF sizeF = graphics_0.MeasureString(item2.Label, val7);
				SolidBrush val8 = new SolidBrush(Color.FromArgb(185, color_1));
				try
				{
					graphics_0.FillRectangle((Brush)(object)val8, num10 - sizeF.Width / 2f - 3f, num11 - sizeF.Height / 2f - 1f, sizeF.Width + 6f, sizeF.Height + 2f);
				}
				finally
				{
					((IDisposable)val8)?.Dispose();
				}
				SolidBrush val9 = new SolidBrush(color2);
				try
				{
					graphics_0.DrawString(item2.Label, val7, (Brush)(object)val9, num10 - sizeF.Width / 2f, num11 - sizeF.Height / 2f);
				}
				finally
				{
					((IDisposable)val9)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)val7)?.Dispose();
			}
		}
	}

	private void method_10(Graphics graphics_0, string string_1, float float_3, float float_4, Color color_12)
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Expected O, but got Unknown
		float val = Math.Max(5.5f, 7f / float_0);
		Font val2 = new Font("Segoe UI", Math.Min(val, 8f), (FontStyle)1);
		try
		{
			SizeF sizeF = graphics_0.MeasureString(string_1, val2);
			SolidBrush val3 = new SolidBrush(Color.FromArgb(200, color_1));
			try
			{
				graphics_0.FillRectangle((Brush)(object)val3, float_3 - sizeF.Width / 2f - 3f, float_4 - sizeF.Height / 2f - 1f, sizeF.Width + 6f, sizeF.Height + 2f);
			}
			finally
			{
				((IDisposable)val3)?.Dispose();
			}
			SolidBrush val4 = new SolidBrush(color_12);
			try
			{
				graphics_0.DrawString(string_1, val2, (Brush)(object)val4, float_3 - sizeF.Width / 2f, float_4 - sizeF.Height / 2f);
			}
			finally
			{
				((IDisposable)val4)?.Dispose();
			}
		}
		finally
		{
			((IDisposable)val2)?.Dispose();
		}
	}

	private void method_11(Graphics graphics_0, bool bool_2)
	{
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Expected O, but got Unknown
		//IL_0223: Unknown result type (might be due to invalid IL or missing references)
		//IL_022a: Expected O, but got Unknown
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_020b: Expected O, but got Unknown
		//IL_0304: Unknown result type (might be due to invalid IL or missing references)
		//IL_030b: Expected O, but got Unknown
		//IL_05d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d7: Expected O, but got Unknown
		//IL_0519: Unknown result type (might be due to invalid IL or missing references)
		//IL_0520: Expected O, but got Unknown
		//IL_029c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a3: Expected O, but got Unknown
		//IL_054d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0554: Expected O, but got Unknown
		//IL_03af: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b6: Expected O, but got Unknown
		//IL_03c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cd: Expected O, but got Unknown
		//IL_0658: Unknown result type (might be due to invalid IL or missing references)
		//IL_065f: Expected O, but got Unknown
		//IL_074e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0755: Expected O, but got Unknown
		//IL_07b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_07bf: Expected O, but got Unknown
		//IL_04aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b1: Expected O, but got Unknown
		//IL_080c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0813: Expected O, but got Unknown
		//IL_06b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_06bc: Expected O, but got Unknown
		bool flag = !string.IsNullOrEmpty(string_0);
		foreach (GraphNode item in list_0)
		{
			float num = 30f;
			PointF position = item.Position;
			bool flag2 = item == graphNode_1;
			bool flag3 = item == graphNode_2;
			bool flag4 = false;
			foreach (GraphLink item2 in list_1)
			{
				if ((item2.Source == item || item2.Target == item) && !string.IsNullOrEmpty(item2.Label))
				{
					flag4 = true;
					break;
				}
			}
			bool flag5 = !flag || item.Label.ToLower().Contains(string_0);
			bool flag6 = ((!flag) ? (graphNode_1 != null && !flag2 && !flag4) : (!flag5));
			int num2 = (flag6 ? 50 : 220);
			int alpha = ((!flag6) ? 255 : 70);
			Bitmap val = method_0(item.IconPath);
			bool flag7;
			if (!(flag7 = val != null))
			{
				SolidBrush val2 = new SolidBrush(Color.FromArgb(70, 0, 0, 0));
				try
				{
					graphics_0.FillEllipse((Brush)(object)val2, position.X - num + 4f, position.Y - num + 4f, num * 2f, num * 2f);
				}
				finally
				{
					((IDisposable)val2)?.Dispose();
				}
			}
			if (flag2 && !bool_2)
			{
				int num3 = 3;
				int num4 = 30;
				while (true)
				{
					Pen val3 = new Pen(Color.FromArgb(num4 * num3, color_5), (float)(num3 * 3));
					try
					{
						graphics_0.DrawEllipse(val3, position.X - num - (float)(num3 * 3), position.Y - num - (float)(num3 * 3), (num + (float)(num3 * 3)) * 2f, (num + (float)(num3 * 3)) * 2f);
					}
					finally
					{
						((IDisposable)val3)?.Dispose();
					}
					num3 += -1;
					if (num3 < 1)
					{
						break;
					}
					num4 = 30;
				}
			}
			else if (flag2)
			{
				Pen val4 = new Pen(Color.FromArgb(120, color_5), 3f);
				try
				{
					graphics_0.DrawEllipse(val4, position.X - num - 4f, position.Y - num - 4f, (num + 4f) * 2f, (num + 4f) * 2f);
				}
				finally
				{
					((IDisposable)val4)?.Dispose();
				}
			}
			if (flag && flag5 && !bool_2)
			{
				Pen val5 = new Pen(Color.FromArgb(180, color_11), 2.5f);
				try
				{
					graphics_0.DrawEllipse(val5, position.X - num - 5f, position.Y - num - 5f, (num + 5f) * 2f, (num + 5f) * 2f);
				}
				finally
				{
					((IDisposable)val5)?.Dispose();
				}
			}
			if (flag7)
			{
				GraphicsState val6 = graphics_0.Save();
				GraphicsPath val7 = new GraphicsPath();
				try
				{
					val7.AddEllipse(position.X - num + 1f, position.Y - num + 1f, num * 2f - 2f, num * 2f - 2f);
					graphics_0.SetClip(val7);
				}
				finally
				{
					((IDisposable)val7)?.Dispose();
				}
				float num5 = 3f;
				RectangleF rectangleF = new RectangleF(position.X - num + num5, position.Y - num + num5, num * 2f - 6f, num * 2f - 6f);
				if (flag6)
				{
					ColorMatrix val8 = new ColorMatrix();
					val8.Matrix33 = (float)num2 / 255f;
					ImageAttributes val9 = new ImageAttributes();
					val9.SetColorMatrix(val8);
					PointF[] array = new PointF[3]
					{
						new PointF(rectangleF.Left, rectangleF.Top),
						new PointF(rectangleF.Right, rectangleF.Top),
						new PointF(rectangleF.Left, rectangleF.Bottom)
					};
					graphics_0.DrawImage((Image)(object)val, array, new RectangleF(0f, 0f, ((Image)val).Width, ((Image)val).Height), (GraphicsUnit)2, val9);
					val9.Dispose();
				}
				else
				{
					graphics_0.DrawImage((Image)(object)val, rectangleF);
				}
				graphics_0.Restore(val6);
				if (flag2 || flag3)
				{
					Color baseColor = ((!flag2) ? Color.White : color_5);
					Pen val10 = new Pen(Color.FromArgb(alpha, baseColor), (!flag2) ? 1.8f : 2.5f);
					try
					{
						graphics_0.DrawEllipse(val10, position.X - num, position.Y - num, num * 2f, num * 2f);
					}
					finally
					{
						((IDisposable)val10)?.Dispose();
					}
				}
			}
			else
			{
				if (!bool_2)
				{
					Color color = Color.FromArgb(num2, item.PrimaryNetworkColor);
					Color centerColor = Color.FromArgb(num2, smethod_0(item.PrimaryNetworkColor, 55));
					GraphicsPath val11 = new GraphicsPath();
					try
					{
						val11.AddEllipse(position.X - num, position.Y - num, num * 2f, num * 2f);
						PathGradientBrush val12 = new PathGradientBrush(val11);
						try
						{
							val12.CenterPoint = new PointF(position.X - num * 0.25f, position.Y - num * 0.25f);
							val12.CenterColor = centerColor;
							val12.SurroundColors = new Color[1] { color };
							graphics_0.FillPath((Brush)(object)val12, val11);
						}
						finally
						{
							((IDisposable)val12)?.Dispose();
						}
					}
					finally
					{
						((IDisposable)val11)?.Dispose();
					}
				}
				else
				{
					SolidBrush val13 = new SolidBrush(Color.FromArgb(num2, item.PrimaryNetworkColor));
					try
					{
						graphics_0.FillEllipse((Brush)(object)val13, position.X - num, position.Y - num, num * 2f, num * 2f);
					}
					finally
					{
						((IDisposable)val13)?.Dispose();
					}
				}
				Color color2 = (flag2 ? color_5 : ((!flag3) ? Color.FromArgb(alpha, color_4) : Color.White));
				Pen val14 = new Pen(color2, flag2 ? 2.5f : (flag3 ? 2f : 1.4f));
				try
				{
					graphics_0.DrawEllipse(val14, position.X - num, position.Y - num, num * 2f, num * 2f);
				}
				finally
				{
					((IDisposable)val14)?.Dispose();
				}
				if (!bool_2)
				{
					Pen val15 = new Pen(Color.FromArgb(flag6 ? 20 : 80, Color.White), 2f);
					try
					{
						graphics_0.DrawArc(val15, position.X - num + 4f, position.Y - num + 4f, num - 4f, num - 4f, 200f, 120f);
					}
					finally
					{
						((IDisposable)val15)?.Dispose();
					}
				}
			}
			if (bool_2 && !flag2)
			{
				continue;
			}
			float num6 = (float)Math.Max(6.0, Math.Min(9.5, 9.0 / (double)float_0));
			Font val16 = new Font("Segoe UI", num6, (FontStyle)1);
			try
			{
				string text = smethod_1(item.Label, graphics_0, val16, num * 2f + 20f);
				SizeF sizeF = graphics_0.MeasureString(text, val16);
				float num7 = position.X - sizeF.Width / 2f;
				float num8 = position.Y + num + 5f;
				SolidBrush val17 = new SolidBrush(Color.FromArgb(180, 20, 20, 24));
				try
				{
					graphics_0.FillRectangle((Brush)(object)val17, num7 - 4f, num8 - 1f, sizeF.Width + 8f, sizeF.Height + 2f);
				}
				finally
				{
					((IDisposable)val17)?.Dispose();
				}
				SolidBrush val18 = new SolidBrush(Color.FromArgb(alpha, color_6));
				try
				{
					graphics_0.DrawString(text, val16, (Brush)(object)val18, num7, num8);
				}
				finally
				{
					((IDisposable)val18)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)val16)?.Dispose();
			}
		}
	}

	private void method_12(Graphics graphics_0)
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected O, but got Unknown
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		Font val = new Font("Segoe UI", 7.5f);
		try
		{
			SolidBrush val2 = new SolidBrush(color_10);
			try
			{
				graphics_0.DrawString($"Zoom {float_0:F1}x  ·  {list_0.Count} nodes  ·  {list_1.Count} Links", val, (Brush)(object)val2, 8f, (float)(((Control)this).Height - 20));
				if (list_0.Count > 0)
				{
					graphics_0.DrawString("Drag nodes  ·  Right/middle drag to pan  ·  Scroll to zoom  ·  Double-click to reset  ·  Esc to deselect  ·  Shift+click second node to find paths", val, (Brush)(object)val2, 8f, 6f);
				}
			}
			finally
			{
				((IDisposable)val2)?.Dispose();
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	private static Color smethod_0(Color color_12, int int_0)
	{
		return Color.FromArgb(Math.Min(255, color_12.R + int_0), Math.Min(255, color_12.G + int_0), Math.Min(255, color_12.B + int_0));
	}

	private static string smethod_1(string string_1, Graphics graphics_0, Font font_0, float float_3)
	{
		if (graphics_0.MeasureString(string_1, font_0).Width <= float_3)
		{
			return string_1;
		}
		string text = string_1;
		while (text.Length > 1 && !(graphics_0.MeasureString(text + "…", font_0).Width <= float_3))
		{
			text = text.Substring(0, text.Length - 1);
		}
		return text + "…";
	}

	private static float smethod_2(PointF pointF_1, PointF pointF_2)
	{
		float num = pointF_2.X - pointF_1.X;
		float num2 = pointF_2.Y - pointF_1.Y;
		return (float)Math.Sqrt(num * num + num2 * num2);
	}

	private static PointF smethod_3(PointF pointF_1, PointF pointF_2, float float_3)
	{
		return new PointF(pointF_1.X + (pointF_2.X - pointF_1.X) * float_3, pointF_1.Y + (pointF_2.Y - pointF_1.Y) * float_3);
	}

	private static List<PointF> smethod_4(List<PointF> list_3)
	{
		if (list_3.Count < 3)
		{
			return list_3;
		}
		int count = list_3.Count;
		int num = 0;
		int num2 = count - 1;
		for (int i = 1; i <= num2; i++)
		{
			if (list_3[i].X < list_3[num].X)
			{
				num = i;
			}
		}
		List<PointF> list = new List<PointF>();
		int num3 = num;
		do
		{
			list.Add(list_3[num3]);
			int num4 = (num3 + 1) % count;
			int num5 = count - 1;
			for (int j = 0; j <= num5; j++)
			{
				float num6 = list_3[num4].X - list_3[num3].X;
				float num7 = list_3[num4].Y - list_3[num3].Y;
				float num8 = list_3[j].X - list_3[num3].X;
				float num9 = list_3[j].Y - list_3[num3].Y;
				if (num6 * num9 - num7 * num8 < 0f)
				{
					num4 = j;
				}
			}
			num3 = num4;
		}
		while (num3 != num && list.Count <= count);
		return list;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			method_1();
			method_2();
		}
		((Control)this).Dispose(disposing);
	}

	static NetworkGraphPanel()
	{
		Class72.smethod_20();
	}
}
