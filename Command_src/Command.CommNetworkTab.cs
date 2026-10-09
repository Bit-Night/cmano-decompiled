using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using Command.My;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

public class CommNetworkTab : UserControl
{
	private struct Struct1
	{
		public NetworkGraphPanel.GraphNode graphNode_0;

		public int int_0;

		public int int_1;

		public string string_0;

		public string LatencyLabel;

		public CommDevice commDevice_0;

		public CommDevice commDevice_1;
	}

	[CompilerGenerated]
	internal sealed class _Closure$__78-0
	{
		public CommNetwork $VB$Local_network;

		public Func<(string NetworkID, Color NetworkColor), bool> $I0;

		public _Closure$__78-0(_Closure$__78-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_network = arg0.$VB$Local_network;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0((string NetworkID, Color NetworkColor) m)
		{
			return Operators.CompareString(m.NetworkID, $VB$Local_network.ID, true) == 0;
		}

		static _Closure$__78-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__78-1
	{
		public Dictionary<string, NetworkGraphPanel.GraphNode> $VB$Local_unitNodeMap;

		public Func<Module_Unit.Unit, bool> $I1;

		public _Closure$__78-1(_Closure$__78-1 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_unitNodeMap = arg0.$VB$Local_unitNodeMap;
			}
		}

		[SpecialName]
		internal bool _Lambda$__1(Module_Unit.Unit u)
		{
			if (u == null)
			{
				return false;
			}
			return $VB$Local_unitNodeMap.ContainsKey(u.ObjectID);
		}

		static _Closure$__78-1()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__78-2
	{
		public NetworkGraphPanel.GraphNode $VB$Local_unit1;

		public NetworkGraphPanel.GraphNode $VB$Local_unit2;

		public _Closure$__78-2(_Closure$__78-2 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_unit1 = arg0.$VB$Local_unit1;
				$VB$Local_unit2 = arg0.$VB$Local_unit2;
			}
		}

		[SpecialName]
		internal bool _Lambda$__2(NetworkGraphPanel.GraphLink e)
		{
			if (e.Source == $VB$Local_unit1 && e.Target == $VB$Local_unit2)
			{
				return true;
			}
			if (e.Source == $VB$Local_unit2)
			{
				return e.Target == $VB$Local_unit1;
			}
			return false;
		}

		static _Closure$__78-2()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__81-0
	{
		public (string NetworkID, Color NetworkColor) $VB$Local_membership;

		public _Closure$__81-0(_Closure$__81-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_membership = arg0.$VB$Local_membership;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(CommNetwork c)
		{
			return Operators.CompareString(c.ID, $VB$Local_membership.NetworkID, true) == 0;
		}

		static _Closure$__81-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__87-0
	{
		public NetworkGraphPanel.GraphNode $VB$Local_toNode;

		public _Closure$__87-0(_Closure$__87-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_toNode = arg0.$VB$Local_toNode;
			}
		}

		[SpecialName]
		internal bool _Lambda$__3(Struct1 h)
		{
			return h.graphNode_0 == $VB$Local_toNode;
		}

		static _Closure$__87-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__88-0
	{
		public List<NetworkGraphPanel.GraphNode> $VB$Local_path;

		public _Closure$__88-0(_Closure$__88-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_path = arg0.$VB$Local_path;
			}
		}

		static _Closure$__88-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__88-1
	{
		public int $VB$Local_hi;

		public _Closure$__88-0 $VB$NonLocal_$VB$Closure_2;

		public _Closure$__88-1(_Closure$__88-1 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_hi = arg0.$VB$Local_hi;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(Struct1 h)
		{
			return h.graphNode_0 == $VB$NonLocal_$VB$Closure_2.$VB$Local_path[$VB$Local_hi + 1];
		}

		static _Closure$__88-1()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__89-0
	{
		public List<NetworkGraphPanel.GraphNode> $VB$Local_path;

		public _Closure$__89-0(_Closure$__89-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_path = arg0.$VB$Local_path;
			}
		}

		static _Closure$__89-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__89-1
	{
		public int $VB$Local_hi;

		public _Closure$__89-0 $VB$NonLocal_$VB$Closure_2;

		public _Closure$__89-1(_Closure$__89-1 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_hi = arg0.$VB$Local_hi;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(Struct1 h)
		{
			return h.graphNode_0 == $VB$NonLocal_$VB$Closure_2.$VB$Local_path[$VB$Local_hi + 1];
		}

		static _Closure$__89-1()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__92-0
	{
		public List<NetworkGraphPanel.GraphNode> $VB$Local_path;

		public _Closure$__92-0(_Closure$__92-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_path = arg0.$VB$Local_path;
			}
		}

		static _Closure$__92-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__92-1
	{
		public int $VB$Local_hi;

		public _Closure$__92-0 $VB$NonLocal_$VB$Closure_2;

		public _Closure$__92-1(_Closure$__92-1 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_hi = arg0.$VB$Local_hi;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(Struct1 h)
		{
			return h.graphNode_0 == $VB$NonLocal_$VB$Closure_2.$VB$Local_path[$VB$Local_hi + 1];
		}

		static _Closure$__92-1()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	[AccessedThroughProperty("_checkShowBestPathOnly")]
	private DarkUICheckBox darkUICheckBox_0;

	private static readonly Color color_0;

	private static readonly Color color_1;

	private static readonly Color color_2;

	private bool bool_0;

	private readonly Color[] color_3;

	private List<NetworkGraphPanel.GraphNode> list_0;

	private List<NetworkGraphPanel.GraphLink> list_1;

	private NetworkGraphPanel.GraphNode graphNode_0;

	private Side side_0;

	private Dictionary<string, List<Struct1>> dictionary_0;

	private bool bool_1;

	private NetworkGraphPanel.GraphNode graphNode_1;

	private NetworkGraphPanel.GraphNode graphNode_2;

	[field: AccessedThroughProperty("_graph")]
	private virtual NetworkGraphPanel _graph { get; set; }

	[field: AccessedThroughProperty("_toolbar")]
	private virtual Panel _toolbar { get; set; }

	[field: AccessedThroughProperty("_infoHeader")]
	private virtual Panel _infoHeader { get; set; }

	[field: AccessedThroughProperty("_infoHeaderLbl")]
	private virtual DarkLabel _infoHeaderLbl { get; set; }

	[field: AccessedThroughProperty("_infoTree")]
	private virtual DarkTreeView _infoTree { get; set; }

	[field: AccessedThroughProperty("_btnRefresh")]
	private virtual DarkUIButton _btnRefresh { get; set; }

	[field: AccessedThroughProperty("_chkShowLinks")]
	private virtual DarkUICheckBox _chkShowLinks { get; set; }

	[field: AccessedThroughProperty("_chkShowFails")]
	private virtual DarkUICheckBox _chkShowFails { get; set; }

	[field: AccessedThroughProperty("_txtFilter")]
	private virtual TextBox _txtFilter { get; set; }

	[field: AccessedThroughProperty("_lblFilter")]
	private virtual DarkLabel _lblFilter { get; set; }

	[field: AccessedThroughProperty("TableLayoutPanel1")]
	internal virtual TableLayoutPanel TableLayoutPanel1 { get; set; }

	[field: AccessedThroughProperty("_infoNetworkLbl")]
	private virtual DarkLabel _infoNetworkLbl { get; set; }

	[field: AccessedThroughProperty("_chkShowbestPathOnly")]
	private virtual DarkUICheckBox _chkShowbestPathOnly { get; set; }

	[field: AccessedThroughProperty("_btnSelectOnMap")]
	private virtual DarkUIButton _btnSelectOnMap { get; set; }

	static CommNetworkTab()
	{
		Class72.smethod_20();
		color_0 = Color.FromArgb(60, 120, 220);
		color_1 = Color.FromArgb(80, 220, 140);
		color_2 = Color.FromArgb(220, 80, 80);
	}

	[SpecialName]
	[CompilerGenerated]
	private virtual DarkUICheckBox vmethod_0()
	{
		return darkUICheckBox_0;
	}

	[SpecialName]
	[CompilerGenerated]
	private virtual void vmethod_1(DarkUICheckBox WithEventsValue)
	{
		darkUICheckBox_0 = WithEventsValue;
	}

	public CommNetworkTab()
	{
		//IL_0239: Unknown result type (might be due to invalid IL or missing references)
		bool_0 = false;
		color_3 = new Color[10]
		{
			Color.FromArgb(80, 150, 230),
			Color.FromArgb(80, 210, 130),
			Color.FromArgb(230, 130, 55),
			Color.FromArgb(180, 85, 210),
			Color.FromArgb(210, 65, 80),
			Color.FromArgb(55, 190, 210),
			Color.FromArgb(210, 210, 55),
			Color.FromArgb(210, 125, 170),
			Color.FromArgb(130, 200, 100),
			Color.FromArgb(200, 100, 130)
		};
		list_0 = new List<NetworkGraphPanel.GraphNode>();
		list_1 = new List<NetworkGraphPanel.GraphLink>();
		dictionary_0 = new Dictionary<string, List<Struct1>>();
		bool_1 = true;
		graphNode_1 = null;
		graphNode_2 = null;
		try
		{
			InitializeComponent();
			((Control)_btnRefresh).Click += [SpecialName] (object sender, EventArgs e) =>
			{
				LoadFromCurrentSide();
			};
			((CheckBox)_chkShowLinks).CheckedChanged += method_15;
			((CheckBox)_chkShowFails).CheckedChanged += method_15;
			_graph.NodeSelected += method_13;
			_graph.NodeDeselected += method_14;
			_graph.PathRequested += method_7;
			((CheckBox)_chkShowbestPathOnly).CheckedChanged += [SpecialName] (object sender, EventArgs e) =>
			{
				method_8();
			};
			((Control)_txtFilter).TextChanged += method_16;
			((Control)_btnSelectOnMap).Click += [SpecialName] (object sender, EventArgs e) =>
			{
				method_0();
			};
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occurred while initializing the network view." + Environment.NewLine + ex2.Message, "Error 3211010000020");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_0()
	{
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (graphNode_0 != null && graphNode_0.LinkedUnit != null)
			{
				Client.SelectThisUnit(graphNode_0.LinkedUnit, ThisUnitOnly: true);
				MyProject.Forms.MainForm.CenterMapToUnit(graphNode_0.LinkedUnit);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occurred while selecting the unit on the map." + Environment.NewLine + ex2.Message, "Error 3211010000021");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void LoadFromCurrentSide()
	{
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (Client.CurrentSide != null)
			{
				side_0 = Client.CurrentSide;
				method_1();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occurred while loading the network view." + Environment.NewLine + ex2.Message, "Error 3211010000022");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_1()
	{
		//IL_0445: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			_Closure$__78-1 arg = default(_Closure$__78-1);
			_Closure$__78-1 CS$<>8__locals10 = new _Closure$__78-1(arg);
			list_0.Clear();
			list_1.Clear();
			graphNode_0 = null;
			CommNetwork[] array;
			lock (side_0.CommNetworks)
			{
				array = side_0.CommNetworks.Values.ToArray();
			}
			CS$<>8__locals10.$VB$Local_unitNodeMap = new Dictionary<string, NetworkGraphPanel.GraphNode>();
			int num = array.Length - 1;
			_Closure$__78-0 closure$__78- = default(_Closure$__78-0);
			for (int i = 0; i <= num; i++)
			{
				closure$__78- = new _Closure$__78-0(closure$__78-);
				closure$__78-.$VB$Local_network = array[i];
				Color item = color_3[i % color_3.Length];
				foreach (Module_Unit.Unit member in closure$__78-.$VB$Local_network.Members)
				{
					if (member == null || string.IsNullOrEmpty(member.ObjectID))
					{
						continue;
					}
					if (!CS$<>8__locals10.$VB$Local_unitNodeMap.ContainsKey(member.ObjectID))
					{
						NetworkGraphPanel.GraphNode obj = new NetworkGraphPanel.GraphNode
						{
							ID = member.ObjectID,
							Label = member.Name,
							Position = new PointF(0f, 0f),
							LinkedUnit = (ActiveUnit)member
						};
						MainForm mainForm = MyProject.Forms.MainForm;
						MainForm mainForm2 = MyProject.Forms.MainForm;
						bool IconIsDirectional = true;
						bool IsCustomIcon = false;
						int CustomSize = -1;
						bool Rotatable = false;
						obj.IconPath = mainForm.GetIconPath(mainForm2.CL_GetUnitIcon(member, ref IconIsDirectional, ref IsCustomIcon, ref CustomSize, ref Rotatable));
						NetworkGraphPanel.GraphNode graphNode = obj;
						graphNode.NetworkMemberships.Add((closure$__78-.$VB$Local_network.ID, item));
						CS$<>8__locals10.$VB$Local_unitNodeMap[member.ObjectID] = graphNode;
						list_0.Add(graphNode);
					}
					else
					{
						NetworkGraphPanel.GraphNode graphNode2 = CS$<>8__locals10.$VB$Local_unitNodeMap[member.ObjectID];
						if (!graphNode2.NetworkMemberships.Any((closure$__78-.$I0 != null) ? closure$__78-.$I0 : (closure$__78-.$I0 = closure$__78-._Lambda$__0)))
						{
							graphNode2.NetworkMemberships.Add((closure$__78-.$VB$Local_network.ID, item));
						}
					}
				}
			}
			CommNetwork[] array2 = array;
			_Closure$__78-2 closure$__78-2 = default(_Closure$__78-2);
			for (int CustomSize = 0; CustomSize < array2.Length; CustomSize = checked(CustomSize + 1))
			{
				List<Module_Unit.Unit> list = array2[CustomSize].Members.Where((CS$<>8__locals10.$I1 != null) ? CS$<>8__locals10.$I1 : (CS$<>8__locals10.$I1 = [SpecialName] (Module_Unit.Unit u) => u != null && CS$<>8__locals10.$VB$Local_unitNodeMap.ContainsKey(u.ObjectID))).ToList();
				int num2 = list.Count - 2;
				for (int num3 = 0; num3 <= num2; num3++)
				{
					int num4 = num3 + 1;
					int num5 = list.Count - 1;
					for (int num6 = num4; num6 <= num5; num6++)
					{
						closure$__78-2 = new _Closure$__78-2(closure$__78-2);
						closure$__78-2.$VB$Local_unit1 = CS$<>8__locals10.$VB$Local_unitNodeMap[list[num3].ObjectID];
						closure$__78-2.$VB$Local_unit2 = CS$<>8__locals10.$VB$Local_unitNodeMap[list[num6].ObjectID];
						if (!list_1.Any(closure$__78-2._Lambda$__2))
						{
							list_1.Add(new NetworkGraphPanel.GraphLink
							{
								Source = closure$__78-2.$VB$Local_unit1,
								Target = closure$__78-2.$VB$Local_unit2,
								IsSuccess = false,
								Label = "",
								Thickness = 1f,
								Color = color_0,
								SourceDevice = new CommDevice(closure$__78-2.$VB$Local_unit1.LinkedUnit),
								TargetDevice = new CommDevice(closure$__78-2.$VB$Local_unit2.LinkedUnit)
							});
						}
					}
				}
			}
			List<NetworkGraphPanel.GraphLink> links = ((!((CheckBox)_chkShowLinks).Checked) ? new List<NetworkGraphPanel.GraphLink>() : list_1);
			_graph.SetGraph(list_0, links);
			zmcundEcew(null);
			_infoTree.Nodes.Clear();
			bool_1 = true;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occurred while rebuilding the network graph." + Environment.NewLine + ex2.Message, "Error 3211010000023");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_2(NetworkGraphPanel.GraphNode graphNode_3)
	{
		//IL_0253: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			ActiveUnit linkedUnit = graphNode_3.LinkedUnit;
			List<NetworkGraphPanel.GraphLink> list = new List<NetworkGraphPanel.GraphLink>();
			if (((CheckBox)_chkShowLinks).Checked)
			{
				list.AddRange(list_1);
			}
			if (linkedUnit != null)
			{
				foreach (NetworkGraphPanel.GraphNode item in list_0)
				{
					if (item == graphNode_3)
					{
						continue;
					}
					ActiveUnit linkedUnit2 = item.LinkedUnit;
					if (linkedUnit2 == null)
					{
						continue;
					}
					NetworkGraphPanel.GraphLink graphLink = null;
					int num = 0;
					CommDevice[] comms_ReadOnly = linkedUnit.Comms_ReadOnly;
					foreach (CommDevice commDevice in comms_ReadOnly)
					{
						CommDevice[] comms_ReadOnly2 = linkedUnit2.Comms_ReadOnly;
						foreach (CommDevice commDevice2 in comms_ReadOnly2)
						{
							try
							{
								(CommDevice, ActiveUnit_CommStuff.CommConnectionChecklistEvaluation) tuple = ActiveUnit_CommStuff.CommDeviceToConnectToThisUnit(linkedUnit, linkedUnit.Comms_ReadOnly, linkedUnit2, IgnoreChannelCount: false, commDevice, commDevice2, onlyOneRequired: true);
								bool flag;
								if (!(flag = tuple.Item2 == ActiveUnit_CommStuff.CommConnectionChecklistEvaluation.OK) && !((CheckBox)_chkShowFails).Checked)
								{
									continue;
								}
								int num2 = 0;
								bool flag2 = flag;
								string label;
								if (!flag)
								{
									label = ActiveUnit_CommStuff.GetCommConnectionChecklistEvaluationToHumanString(tuple.Item2);
									num2 = 0;
								}
								else
								{
									label = $"{EnumCommExtensions.GetDescriptionAsSlide(commDevice.QualityGrade)} / {commDevice.LatencyGradenfo.GetDescriptionASSlide()}";
									num2 = (int)commDevice.QualityGrade;
								}
								NetworkGraphPanel.GraphLink graphLink2 = new NetworkGraphPanel.GraphLink
								{
									Source = graphNode_3,
									Target = item,
									IsSuccess = flag2,
									Label = label,
									Thickness = 1f,
									Color = (flag2 ? color_1 : color_2),
									SourceDevice = commDevice,
									TargetDevice = commDevice2
								};
								if (graphLink == null || (flag && !graphLink.IsSuccess) || (flag && graphLink.IsSuccess && num2 > num))
								{
									if (graphLink == null || graphLink.SourceDevice.QualityGrade < graphLink2.SourceDevice.QualityGrade)
									{
										graphLink = graphLink2;
									}
									num = num2;
								}
							}
							catch (Exception projectError)
							{
								ProjectData.SetProjectError(projectError);
								ProjectData.ClearProjectError();
							}
						}
					}
					if (graphLink != null)
					{
						list.Add(graphLink);
					}
				}
				_graph.SetLinks(list);
			}
			else
			{
				_graph.SetLinks(list);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occurred while running the comm check for the selected node." + Environment.NewLine + ex2.Message, "Error 3211010000024");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_3(NetworkGraphPanel.GraphNode graphNode_3)
	{
		//IL_040d: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			_infoTree.Nodes.Clear();
			ActiveUnit linkedUnit = graphNode_3.LinkedUnit;
			if (linkedUnit == null)
			{
				return;
			}
			DarkTreeNode darkTreeNode = new DarkTreeNode("Own Comm Devices  ( " + Conversions.ToString(linkedUnit.Comms_ReadOnly.Count()) + ")");
			CommDevice[] comms_ReadOnly = linkedUnit.Comms_ReadOnly;
			foreach (CommDevice commDevice in comms_ReadOnly)
			{
				DarkTreeNode item = new DarkTreeNode(commDevice.Name + "  Quality:  " + commDevice.QualityGradeinfo.GetDescriptionASSlide() + "   Latency: " + commDevice.LatencyGradenfo.GetDescriptionASSlide());
				darkTreeNode.Nodes.Add(item);
			}
			_infoTree.Nodes.Add(darkTreeNode);
			DarkTreeNode darkTreeNode2 = new DarkTreeNode("Connections to other units  ( " + Conversions.ToString(list_0.Count - 1) + ")");
			foreach (NetworkGraphPanel.GraphNode item2 in list_0)
			{
				if (item2 == graphNode_3)
				{
					continue;
				}
				ActiveUnit linkedUnit2 = item2.LinkedUnit;
				if (linkedUnit2 == null)
				{
					continue;
				}
				DarkTreeNode darkTreeNode3 = new DarkTreeNode(item2.Label);
				darkTreeNode3.ForeColor = Color.FromArgb(150, 150, 165);
				bool flag = false;
				bool flag2 = false;
				CommDevice[] comms_ReadOnly2 = linkedUnit.Comms_ReadOnly;
				foreach (CommDevice commDevice2 in comms_ReadOnly2)
				{
					CommDevice[] comms_ReadOnly3 = linkedUnit2.Comms_ReadOnly;
					foreach (CommDevice commDevice3 in comms_ReadOnly3)
					{
						try
						{
							(CommDevice, ActiveUnit_CommStuff.CommConnectionChecklistEvaluation) tuple = ActiveUnit_CommStuff.CommDeviceToConnectToThisUnit(linkedUnit, linkedUnit.Comms_ReadOnly, linkedUnit2, IgnoreChannelCount: false, commDevice2, commDevice3, onlyOneRequired: true);
							bool flag3 = tuple.Item2 == ActiveUnit_CommStuff.CommConnectionChecklistEvaluation.OK;
							flag2 = true;
							string text;
							if (!flag3)
							{
								text = commDevice2.Name + " --> " + commDevice3.Name + "   " + ActiveUnit_CommStuff.GetCommConnectionChecklistEvaluationToHumanString(tuple.Item2);
							}
							else
							{
								CommDevice.QualityGradeDetail qualityGradeDetail = new CommDevice.QualityGradeDetail[2] { commDevice2.QualityGradeinfo, commDevice3.QualityGradeinfo }.OrderBy([SpecialName] (CommDevice.QualityGradeDetail q) => q.ID).First();
								CommDevice.LatencyGradeDetail latencyGradeDetail = new CommDevice.LatencyGradeDetail[2] { commDevice2.LatencyGradenfo, commDevice3.LatencyGradenfo }.OrderByDescending([SpecialName] (CommDevice.LatencyGradeDetail l) => l.ID).First();
								text = commDevice2.Name + " --> " + commDevice3.Name + "   Quality: " + qualityGradeDetail.GetDescriptionASSlide() + "   Latency: " + latencyGradeDetail.GetDescriptionASSlide();
								flag = true;
							}
							DarkTreeNode darkTreeNode4 = new DarkTreeNode(text);
							if (flag3)
							{
								darkTreeNode4.ForeColor = color_1;
							}
							else
							{
								darkTreeNode4.ForeColor = color_2;
							}
							darkTreeNode3.Nodes.Add(darkTreeNode4);
						}
						catch (Exception projectError)
						{
							ProjectData.SetProjectError(projectError);
							ProjectData.ClearProjectError();
						}
					}
				}
				if (flag)
				{
					darkTreeNode3.ForeColor = color_1;
				}
				else if (flag2)
				{
					darkTreeNode3.ForeColor = color_2;
				}
				darkTreeNode2.Nodes.Add(darkTreeNode3);
			}
			_infoTree.Nodes.Add(darkTreeNode2);
			Module1.ExpandAll(_infoTree);
			foreach (DarkTreeNode node in darkTreeNode2.Nodes)
			{
				node.Expanded = false;
			}
			darkTreeNode.Expanded = true;
			darkTreeNode2.Expanded = true;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occurred while populating the info tree." + Environment.NewLine + ex2.Message, "Error 3211010000025");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void zmcundEcew(NetworkGraphPanel.GraphNode graphNode_3)
	{
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (graphNode_3 != null)
			{
				((Label)_infoHeaderLbl).Text = graphNode_3.Label;
				Color primaryNetworkColor = graphNode_3.PrimaryNetworkColor;
				((Control)_infoHeaderLbl).ForeColor = primaryNetworkColor;
				List<string> list = new List<string>();
				using (List<(string, Color)>.Enumerator enumerator = graphNode_3.NetworkMemberships.GetEnumerator())
				{
					_Closure$__81-0 closure$__81- = default(_Closure$__81-0);
					while (enumerator.MoveNext())
					{
						closure$__81- = new _Closure$__81-0(closure$__81-);
						closure$__81-.$VB$Local_membership = enumerator.Current;
						CommNetwork commNetwork = side_0?.CommNetworks.Values.FirstOrDefault(closure$__81-._Lambda$__0);
						list.Add((commNetwork == null) ? ("Network " + closure$__81-.$VB$Local_membership.NetworkID) : commNetwork.Name);
					}
				}
				((Label)_infoNetworkLbl).Text = "Networks: " + string.Join(", ", list);
				((Control)_infoNetworkLbl).ForeColor = Color.FromArgb(primaryNetworkColor.R / 2 + 90, primaryNetworkColor.G / 2 + 90, primaryNetworkColor.B / 2 + 90);
			}
			else
			{
				((Label)_infoHeaderLbl).Text = "No unit selected";
				((Control)_infoHeaderLbl).ForeColor = Color.FromArgb(160, 160, 175);
				((Label)_infoNetworkLbl).Text = "Click any node to run a comm-check against all others";
				((Control)_infoNetworkLbl).ForeColor = Color.FromArgb(110, 110, 125);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occurred while updating the info header." + Environment.NewLine + ex2.Message, "Error 3211010000026");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_4()
	{
		//IL_0253: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			dictionary_0.Clear();
			Struct1 item = default(Struct1);
			foreach (NetworkGraphPanel.GraphNode item2 in list_0)
			{
				List<Struct1> list = new List<Struct1>();
				if (item2.LinkedUnit != null)
				{
					foreach (NetworkGraphPanel.GraphNode item3 in list_0)
					{
						if (item3 == item2 || item3.LinkedUnit == null)
						{
							continue;
						}
						bool flag = false;
						foreach (var networkMembership in item2.NetworkMemberships)
						{
							foreach (var networkMembership2 in item3.NetworkMemberships)
							{
								if (Operators.CompareString(networkMembership.NetworkID, networkMembership2.NetworkID, true) == 0)
								{
									flag = true;
									break;
								}
							}
							if (flag)
							{
								break;
							}
						}
						if (!flag)
						{
							continue;
						}
						try
						{
							(CommDevice, ActiveUnit_CommStuff.CommConnectionChecklistEvaluation) tuple = ActiveUnit_CommStuff.CommDeviceToConnectToThisUnit(item2.LinkedUnit, item2.LinkedUnit.Comms_ReadOnly, item3.LinkedUnit, IgnoreChannelCount: false, null, null, onlyOneRequired: true);
							if (tuple.Item1 != null && tuple.Item2 == ActiveUnit_CommStuff.CommConnectionChecklistEvaluation.OK)
							{
								item.graphNode_0 = item3;
								item.int_0 = (int)tuple.Item1.QualityGrade;
								item.int_1 = tuple.Item1.LatencyGradenfo.ID;
								item.string_0 = tuple.Item1.QualityGradeinfo.GetDescriptionASSlide();
								item.LatencyLabel = tuple.Item1.LatencyGradenfo.GetDescriptionASSlide();
								(item.commDevice_0, _) = tuple;
								(item.commDevice_1, _) = tuple;
								list.Add(item);
							}
						}
						catch (Exception projectError)
						{
							ProjectData.SetProjectError(projectError);
							ProjectData.ClearProjectError();
						}
					}
					dictionary_0[item2.ID] = list;
				}
				else
				{
					dictionary_0[item2.ID] = list;
				}
			}
			bool_1 = false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occurred while building the adjacency cache." + Environment.NewLine + ex2.Message, "Error 3211010000027");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private List<List<NetworkGraphPanel.GraphNode>> method_5(NetworkGraphPanel.GraphNode graphNode_3, NetworkGraphPanel.GraphNode graphNode_4)
	{
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		List<List<NetworkGraphPanel.GraphNode>> result;
		try
		{
			if (bool_1)
			{
				method_4();
			}
			List<List<NetworkGraphPanel.GraphNode>> list = new List<List<NetworkGraphPanel.GraphNode>>();
			HashSet<string> hashSet_ = new HashSet<string>();
			List<NetworkGraphPanel.GraphNode> list_ = new List<NetworkGraphPanel.GraphNode>();
			method_6(graphNode_3, graphNode_4, hashSet_, list_, list, 6);
			list.Sort([SpecialName] (List<NetworkGraphPanel.GraphNode> a, List<NetworkGraphPanel.GraphNode> b) => a.Count.CompareTo(b.Count));
			result = list;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occurred while finding paths." + Environment.NewLine + ex2.Message, "Error 3211010000028");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new List<List<NetworkGraphPanel.GraphNode>>();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private void method_6(NetworkGraphPanel.GraphNode graphNode_3, NetworkGraphPanel.GraphNode graphNode_4, HashSet<string> hashSet_0, List<NetworkGraphPanel.GraphNode> list_2, List<List<NetworkGraphPanel.GraphNode>> list_3, int int_0)
	{
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		if (int_0 == 0)
		{
			return;
		}
		try
		{
			hashSet_0.Add(graphNode_3.ID);
			list_2.Add(graphNode_3);
			if (graphNode_3 == graphNode_4)
			{
				list_3.Add(new List<NetworkGraphPanel.GraphNode>(list_2));
			}
			else
			{
				if (!dictionary_0.ContainsKey(graphNode_3.ID))
				{
					return;
				}
				{
					foreach (Struct1 item in dictionary_0[graphNode_3.ID])
					{
						if (!hashSet_0.Contains(item.graphNode_0.ID))
						{
							method_6(item.graphNode_0, graphNode_4, hashSet_0, list_2, list_3, int_0 - 1);
						}
					}
					return;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occurred while traversing paths." + Environment.NewLine + ex2.Message, "Error 3211010000029");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		finally
		{
			if (list_2.Count > 0)
			{
				list_2.RemoveAt(list_2.Count - 1);
			}
			hashSet_0.Remove(graphNode_3.ID);
		}
	}

	private void method_7(object object_0, NetworkGraphPanel.GraphNode graphNode_3, NetworkGraphPanel.GraphNode graphNode_4)
	{
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			bool_0 = true;
			graphNode_1 = graphNode_3;
			graphNode_2 = graphNode_4;
			method_9(graphNode_3, graphNode_4);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occurred while handling the path request." + Environment.NewLine + ex2.Message, "Error 3211010000030");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_8()
	{
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (graphNode_1 != null && graphNode_2 != null)
			{
				bool_0 = true;
				method_9(graphNode_1, graphNode_2);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occurred while rerunning the last path request." + Environment.NewLine + ex2.Message, "Error 3211010000031");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_9(NetworkGraphPanel.GraphNode graphNode_3, NetworkGraphPanel.GraphNode graphNode_4)
	{
		//IL_032b: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			List<List<NetworkGraphPanel.GraphNode>> list = (from p in method_5(graphNode_3, graphNode_4)
				orderby WoyuJithkx(p) descending, method_10(p) descending, p.Count
				select p).ToList();
			List<List<NetworkGraphPanel.GraphNode>> list2 = ((!((CheckBox)_chkShowbestPathOnly).Checked) ? list : ((list.Count > 0) ? new List<List<NetworkGraphPanel.GraphNode>> { list[0] } : list));
			List<NetworkGraphPanel.GraphLink> list3 = new List<NetworkGraphPanel.GraphLink>();
			if (list2.Count == 0)
			{
				list3.Add(new NetworkGraphPanel.GraphLink
				{
					Source = graphNode_3,
					Target = graphNode_4,
					IsSuccess = false,
					IsPathLink = true,
					Label = "no path",
					Thickness = 1.5f,
					Color = Color.FromArgb(200, 80, 80)
				});
				method_12(graphNode_3, graphNode_4, list2);
				_graph.SetLinks(list3);
				return;
			}
			int num = list2.Count - 1;
			_Closure$__87-0 closure$__87- = default(_Closure$__87-0);
			Struct1 @struct = default(Struct1);
			for (int num2 = 0; num2 <= num; num2++)
			{
				List<NetworkGraphPanel.GraphNode> list4 = list2[num2];
				int int_ = WoyuJithkx(list4);
				int int_2 = method_10(list4);
				string text = method_11(int_);
				string text2 = XfsuToqvkb(int_2);
				string text3 = "Path " + Conversions.ToString(num2 + 1) + ": " + text + "/" + text2;
				int num3 = list4.Count - 2;
				for (int num4 = 0; num4 <= num3; num4++)
				{
					closure$__87- = new _Closure$__87-0(closure$__87-);
					NetworkGraphPanel.GraphNode graphNode = list4[num4];
					closure$__87-.$VB$Local_toNode = list4[num4 + 1];
					bool flag = num4 == list4.Count - 2;
					if (dictionary_0.ContainsKey(graphNode.ID))
					{
						@struct = dictionary_0[graphNode.ID].FirstOrDefault(closure$__87-._Lambda$__3);
					}
					string text4 = ((@struct.graphNode_0 != null) ? (@struct.string_0 + "/" + @struct.LatencyLabel) : "?");
					list3.Add(new NetworkGraphPanel.GraphLink
					{
						Source = graphNode,
						Target = closure$__87-.$VB$Local_toNode,
						IsSuccess = true,
						IsPathLink = true,
						PathIndex = num2,
						TotalPaths = list2.Count,
						JumpLabel = text4,
						PathSummaryLabel = ((!flag) ? "" : text3),
						Label = text4,
						Thickness = 2.5f,
						SourceDevice = ((@struct.graphNode_0 != null) ? @struct.commDevice_0 : null),
						TargetDevice = ((@struct.graphNode_0 != null) ? @struct.commDevice_1 : null)
					});
				}
			}
			_graph.SetLinks(list3);
			method_12(graphNode_3, graphNode_4, list2);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occurred while executing the path request." + Environment.NewLine + ex2.Message, "Error 3211010000032");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private int WoyuJithkx(List<NetworkGraphPanel.GraphNode> list_2)
	{
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		_Closure$__88-0 closure$__88- = new _Closure$__88-0(closure$__88-);
		closure$__88-.$VB$Local_path = list_2;
		int result;
		try
		{
			int num = int.MaxValue;
			_Closure$__88-1 arg = default(_Closure$__88-1);
			_Closure$__88-1 CS$<>8__locals9 = new _Closure$__88-1(arg);
			CS$<>8__locals9.$VB$NonLocal_$VB$Closure_2 = closure$__88-;
			_Closure$__88-1 closure$__88-2 = CS$<>8__locals9;
			int num2 = CS$<>8__locals9.$VB$NonLocal_$VB$Closure_2.$VB$Local_path.Count - 2;
			closure$__88-2.$VB$Local_hi = 0;
			while (CS$<>8__locals9.$VB$Local_hi <= num2)
			{
				string iD = CS$<>8__locals9.$VB$NonLocal_$VB$Closure_2.$VB$Local_path[CS$<>8__locals9.$VB$Local_hi].ID;
				if (dictionary_0.ContainsKey(iD))
				{
					Struct1 @struct = dictionary_0[iD].FirstOrDefault([SpecialName] (Struct1 h) => h.graphNode_0 == CS$<>8__locals9.$VB$NonLocal_$VB$Closure_2.$VB$Local_path[CS$<>8__locals9.$VB$Local_hi + 1]);
					if (@struct.graphNode_0 != null && @struct.int_0 < num)
					{
						num = @struct.int_0;
					}
				}
				CS$<>8__locals9.$VB$Local_hi++;
			}
			result = ((num != int.MaxValue) ? num : 0);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occurred while computing the weakest bandwidth." + Environment.NewLine + ex2.Message, "Error 3211010000033");
			int num3;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num3 = 0;
			}
			else
			{
				num3 = 0;
			}
			result = num3;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private int method_10(List<NetworkGraphPanel.GraphNode> list_2)
	{
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		_Closure$__89-0 closure$__89- = new _Closure$__89-0(closure$__89-);
		closure$__89-.$VB$Local_path = list_2;
		int result;
		try
		{
			int num = int.MaxValue;
			_Closure$__89-1 arg = default(_Closure$__89-1);
			_Closure$__89-1 CS$<>8__locals9 = new _Closure$__89-1(arg);
			CS$<>8__locals9.$VB$NonLocal_$VB$Closure_2 = closure$__89-;
			_Closure$__89-1 closure$__89-2 = CS$<>8__locals9;
			int num2 = CS$<>8__locals9.$VB$NonLocal_$VB$Closure_2.$VB$Local_path.Count - 2;
			closure$__89-2.$VB$Local_hi = 0;
			while (CS$<>8__locals9.$VB$Local_hi <= num2)
			{
				string iD = CS$<>8__locals9.$VB$NonLocal_$VB$Closure_2.$VB$Local_path[CS$<>8__locals9.$VB$Local_hi].ID;
				if (dictionary_0.ContainsKey(iD))
				{
					Struct1 @struct = dictionary_0[iD].FirstOrDefault([SpecialName] (Struct1 h) => h.graphNode_0 == CS$<>8__locals9.$VB$NonLocal_$VB$Closure_2.$VB$Local_path[CS$<>8__locals9.$VB$Local_hi + 1]);
					if (@struct.graphNode_0 != null && @struct.int_1 < num)
					{
						num = @struct.int_1;
					}
				}
				CS$<>8__locals9.$VB$Local_hi++;
			}
			result = ((num != int.MaxValue) ? num : 0);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occurred while computing the weakest latency." + Environment.NewLine + ex2.Message, "Error 3211010000034");
			int num3;
			if (!Debugger.IsAttached)
			{
				num3 = 0;
			}
			else
			{
				Debugger.Break();
				num3 = 0;
			}
			result = num3;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private string method_11(int int_0)
	{
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		string result;
		try
		{
			foreach (Struct1 item in dictionary_0.Values.SelectMany([SpecialName] (List<Struct1> x) => x))
			{
				if (item.int_0 != int_0)
				{
					continue;
				}
				result = item.string_0;
				goto end_IL_0001;
			}
			result = "B:" + Conversions.ToString(int_0);
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occurred while resolving the bandwidth label." + Environment.NewLine + ex2.Message, "Error 3211010000035");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = "B:" + Conversions.ToString(int_0);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private string XfsuToqvkb(int int_0)
	{
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		string result;
		try
		{
			foreach (Struct1 item in dictionary_0.Values.SelectMany([SpecialName] (List<Struct1> x) => x))
			{
				if (item.int_1 != int_0)
				{
					continue;
				}
				result = item.LatencyLabel;
				goto end_IL_0001;
			}
			result = "L:" + Conversions.ToString(int_0);
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occurred while resolving the latency label." + Environment.NewLine + ex2.Message, "Error 3211010000036");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = "L:" + Conversions.ToString(int_0);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private void method_12(NetworkGraphPanel.GraphNode graphNode_3, NetworkGraphPanel.GraphNode graphNode_4, List<List<NetworkGraphPanel.GraphNode>> list_2)
	{
		//IL_0378: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			((Label)_infoHeaderLbl).Text = graphNode_3.Label + " → " + graphNode_4.Label;
			((Control)_infoHeaderLbl).ForeColor = Color.FromArgb(220, 210, 120);
			if (list_2.Count != 0)
			{
				((Label)_infoNetworkLbl).Text = Conversions.ToString(list_2.Count) + " path(s) found ";
				((Control)_infoNetworkLbl).ForeColor = Color.FromArgb(160, 200, 120);
				_infoTree.Nodes.Clear();
				int num = list_2.Count - 1;
				_Closure$__92-0 closure$__92- = default(_Closure$__92-0);
				_Closure$__92-1 closure$__92-2 = default(_Closure$__92-1);
				Struct1 @struct = default(Struct1);
				for (int i = 0; i <= num; i++)
				{
					closure$__92- = new _Closure$__92-0(closure$__92-);
					closure$__92-.$VB$Local_path = list_2[i];
					int num2 = int.MaxValue;
					int num3 = int.MaxValue;
					string text = "";
					string text2 = "";
					DarkTreeNode darkTreeNode = new DarkTreeNode("Path " + Conversions.ToString(i + 1) + "  (" + Conversions.ToString(closure$__92-.$VB$Local_path.Count - 1) + " Jumps)");
					closure$__92-2 = new _Closure$__92-1(closure$__92-2);
					closure$__92-2.$VB$NonLocal_$VB$Closure_2 = closure$__92-;
					_Closure$__92-1 closure$__92-3 = closure$__92-2;
					int num4 = closure$__92-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_path.Count - 2;
					closure$__92-3.$VB$Local_hi = 0;
					while (closure$__92-2.$VB$Local_hi <= num4)
					{
						string iD = closure$__92-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_path[closure$__92-2.$VB$Local_hi].ID;
						if (dictionary_0.ContainsKey(iD))
						{
							@struct = dictionary_0[iD].FirstOrDefault(closure$__92-2._Lambda$__0);
						}
						string text3;
						if (@struct.graphNode_0 == null)
						{
							text3 = "?";
						}
						else
						{
							text3 = @struct.string_0 + "/" + @struct.LatencyLabel;
							if (@struct.int_0 < num2)
							{
								num2 = @struct.int_0;
								text = @struct.string_0;
							}
							if (@struct.int_1 < num3)
							{
								num3 = @struct.int_1;
								text2 = @struct.LatencyLabel;
							}
						}
						darkTreeNode.Nodes.Add(new DarkTreeNode(closure$__92-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_path[closure$__92-2.$VB$Local_hi].Label + " → " + closure$__92-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_path[closure$__92-2.$VB$Local_hi + 1].Label + "   " + text3));
						closure$__92-2.$VB$Local_hi++;
					}
					DarkTreeNode darkTreeNode2 = new DarkTreeNode("Result: " + text + "/" + text2);
					darkTreeNode2.ForeColor = Color.FromArgb(200, 210, 100);
					darkTreeNode.Nodes.Add(darkTreeNode2);
					darkTreeNode.Expanded = true;
					_infoTree.Nodes.Add(darkTreeNode);
				}
			}
			else
			{
				((Label)_infoNetworkLbl).Text = "No communication path found";
				((Control)_infoNetworkLbl).ForeColor = Color.FromArgb(200, 80, 80);
				_infoTree.Nodes.Clear();
				_infoTree.Nodes.Add(new DarkTreeNode("No path between these units through the network network"));
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occurred while updating the path info header." + Environment.NewLine + ex2.Message, "Error 3211010000037");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_13(object object_0, NetworkGraphPanel.GraphNode graphNode_3)
	{
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			graphNode_0 = graphNode_3;
			zmcundEcew(graphNode_3);
			if (bool_0)
			{
				bool_0 = false;
				return;
			}
			method_2(graphNode_3);
			method_3(graphNode_3);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occurred while handling node selection." + Environment.NewLine + ex2.Message, "Error 3211010000038");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_14(object object_0)
	{
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			graphNode_0 = null;
			zmcundEcew(null);
			_infoTree.Nodes.Clear();
			List<NetworkGraphPanel.GraphLink> links = (((CheckBox)_chkShowLinks).Checked ? list_1 : new List<NetworkGraphPanel.GraphLink>());
			_graph.SetLinks(links);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occurred while handling node deselection." + Environment.NewLine + ex2.Message, "Error 3211010000039");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_15(object sender, EventArgs e)
	{
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (graphNode_0 != null)
			{
				method_2(graphNode_0);
				return;
			}
			List<NetworkGraphPanel.GraphLink> links = ((!((CheckBox)_chkShowLinks).Checked) ? new List<NetworkGraphPanel.GraphLink>() : list_1);
			_graph.SetLinks(links);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occurred while updating link visibility." + Environment.NewLine + ex2.Message, "Error 3211010000040");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_16(object sender, EventArgs e)
	{
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			_graph.FilterText = _txtFilter.Text;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("An error occurred while applying the filter." + Environment.NewLine + ex2.Message, "Error 3211010000041");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void InitializeComponent()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected O, but got Unknown
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected O, but got Unknown
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_021f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0331: Unknown result type (might be due to invalid IL or missing references)
		//IL_0686: Unknown result type (might be due to invalid IL or missing references)
		//IL_06cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d9: Expected O, but got Unknown
		//IL_075f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0769: Expected O, but got Unknown
		//IL_07f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0802: Expected O, but got Unknown
		//IL_0814: Unknown result type (might be due to invalid IL or missing references)
		//IL_081e: Expected O, but got Unknown
		//IL_08ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_08d4: Expected O, but got Unknown
		//IL_08e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_08f0: Expected O, but got Unknown
		_toolbar = new Panel();
		_btnSelectOnMap = new DarkUIButton();
		_chkShowbestPathOnly = new DarkUICheckBox();
		_btnRefresh = new DarkUIButton();
		_chkShowLinks = new DarkUICheckBox();
		_chkShowFails = new DarkUICheckBox();
		_lblFilter = new DarkLabel();
		_txtFilter = new TextBox();
		_infoTree = new DarkTreeView();
		_infoHeader = new Panel();
		_infoNetworkLbl = new DarkLabel();
		_infoHeaderLbl = new DarkLabel();
		TableLayoutPanel1 = new TableLayoutPanel();
		_graph = new NetworkGraphPanel();
		((Control)_toolbar).SuspendLayout();
		((Control)_infoHeader).SuspendLayout();
		((Control)TableLayoutPanel1).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)_toolbar).BackColor = Color.FromArgb(30, 30, 34);
		((Control)_toolbar).Controls.Add((Control)(object)_btnSelectOnMap);
		((Control)_toolbar).Controls.Add((Control)(object)_chkShowbestPathOnly);
		((Control)_toolbar).Controls.Add((Control)(object)_btnRefresh);
		((Control)_toolbar).Controls.Add((Control)(object)_chkShowLinks);
		((Control)_toolbar).Controls.Add((Control)(object)_chkShowFails);
		((Control)_toolbar).Controls.Add((Control)(object)_lblFilter);
		((Control)_toolbar).Controls.Add((Control)(object)_txtFilter);
		((Control)_toolbar).Dock = (DockStyle)5;
		((Control)_toolbar).Location = new Point(3, 3);
		((Control)_toolbar).Name = "_toolbar";
		((Control)_toolbar).Padding = new Padding(6);
		((Control)_toolbar).Size = new Size(1102, 40);
		((Control)_toolbar).TabIndex = 1;
		((Control)_btnSelectOnMap).ForeColor = Color.FromArgb(220, 220, 225);
		((Control)_btnSelectOnMap).Location = new Point(836, 4);
		((Control)_btnSelectOnMap).Name = "_btnSelectOnMap";
		((Control)_btnSelectOnMap).Padding = new Padding(4);
		_btnSelectOnMap.RoundRadius = 0;
		((Control)_btnSelectOnMap).Size = new Size(120, 30);
		((Control)_btnSelectOnMap).TabIndex = 8;
		_btnSelectOnMap.Text = "Select on Map";
		((ButtonBase)_chkShowbestPathOnly).AutoSize = true;
		((Control)_chkShowbestPathOnly).ForeColor = Color.FromArgb(190, 190, 200);
		((Control)_chkShowbestPathOnly).Location = new Point(459, 8);
		((Control)_chkShowbestPathOnly).Name = "_chkShowbestPathOnly";
		((Control)_chkShowbestPathOnly).Size = new Size(178, 24);
		((Control)_chkShowbestPathOnly).TabIndex = 3;
		((ButtonBase)_chkShowbestPathOnly).Text = "Show best path only";
		((Control)_btnRefresh).ForeColor = Color.FromArgb(220, 220, 225);
		((Control)_btnRefresh).Location = new Point(6, 4);
		((Control)_btnRefresh).Name = "_btnRefresh";
		((Control)_btnRefresh).Padding = new Padding(4);
		_btnRefresh.RoundRadius = 0;
		((Control)_btnRefresh).Size = new Size(120, 30);
		((Control)_btnRefresh).TabIndex = 0;
		_btnRefresh.Text = "Refresh";
		((ButtonBase)_chkShowLinks).AutoSize = true;
		((Control)_chkShowLinks).ForeColor = Color.FromArgb(190, 190, 200);
		((Control)_chkShowLinks).Location = new Point(132, 8);
		((Control)_chkShowLinks).Name = "_chkShowLinks";
		((Control)_chkShowLinks).Size = new Size(180, 24);
		((Control)_chkShowLinks).TabIndex = 1;
		((ButtonBase)_chkShowLinks).Text = "Show all network links";
		((ButtonBase)_chkShowFails).AutoSize = true;
		((Control)_chkShowFails).ForeColor = Color.FromArgb(190, 190, 200);
		((Control)_chkShowFails).Location = new Point(313, 8);
		((Control)_chkShowFails).Name = "_chkShowFails";
		((Control)_chkShowFails).Size = new Size(152, 24);
		((Control)_chkShowFails).TabIndex = 2;
		((ButtonBase)_chkShowFails).Text = "Show failed links";
		_lblFilter.AutoSize = true;
		((Control)_lblFilter).ForeColor = Color.FromArgb(150, 150, 165);
		((Control)_lblFilter).Location = new Point(636, 10);
		((Control)_lblFilter).Name = "_lblFilter";
		((Control)_lblFilter).Size = new Size(43, 20);
		((Control)_lblFilter).TabIndex = 4;
		((Label)_lblFilter).Text = "filter:";
		((TextBoxBase)_txtFilter).BackColor = Color.FromArgb(50, 50, 55);
		((TextBoxBase)_txtFilter).BorderStyle = (BorderStyle)1;
		((TextBoxBase)_txtFilter).ForeColor = Color.FromArgb(210, 210, 220);
		((Control)_txtFilter).Location = new Point(687, 7);
		((Control)_txtFilter).Name = "_txtFilter";
		((Control)_txtFilter).Size = new Size(130, 26);
		((Control)_txtFilter).TabIndex = 7;
		((Control)_infoTree).BackColor = Color.FromArgb(35, 35, 40);
		((Control)_infoTree).Dock = (DockStyle)5;
		((Control)_infoTree).Location = new Point(1111, 49);
		_infoTree.MaxDragChange = 20;
		((Control)_infoTree).Name = "_infoTree";
		((Control)_infoTree).Size = new Size(470, 783);
		((Control)_infoTree).TabIndex = 0;
		((Control)_infoHeader).BackColor = Color.FromArgb(30, 30, 34);
		((Control)_infoHeader).Controls.Add((Control)(object)_infoNetworkLbl);
		((Control)_infoHeader).Controls.Add((Control)(object)_infoHeaderLbl);
		((Control)_infoHeader).Dock = (DockStyle)5;
		((Control)_infoHeader).Location = new Point(1111, 3);
		((Control)_infoHeader).Name = "_infoHeader";
		((Control)_infoHeader).Padding = new Padding(10, 6, 8, 6);
		((Control)_infoHeader).Size = new Size(470, 40);
		((Control)_infoHeader).TabIndex = 1;
		((Control)_infoNetworkLbl).Dock = (DockStyle)1;
		((Control)_infoNetworkLbl).Font = new Font("Segoe UI", 8f);
		((Control)_infoNetworkLbl).ForeColor = Color.FromArgb(130, 130, 145);
		((Control)_infoNetworkLbl).Location = new Point(10, 6);
		((Control)_infoNetworkLbl).Name = "_infoNetworkLbl";
		((Control)_infoNetworkLbl).Size = new Size(452, 20);
		((Control)_infoNetworkLbl).TabIndex = 0;
		((Label)_infoNetworkLbl).Text = "Click a node to run comm-check";
		((Control)_infoHeaderLbl).Font = new Font("Segoe UI", 11f, (FontStyle)1);
		((Control)_infoHeaderLbl).ForeColor = Color.FromArgb(200, 200, 210);
		((Control)_infoHeaderLbl).Location = new Point(10, 6);
		((Control)_infoHeaderLbl).Name = "_infoHeaderLbl";
		((Control)_infoHeaderLbl).Size = new Size(76, 28);
		((Control)_infoHeaderLbl).TabIndex = 1;
		((Label)_infoHeaderLbl).Text = "No unit selected";
		TableLayoutPanel1.ColumnCount = 2;
		TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle((SizeType)2, 70f));
		TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle((SizeType)2, 30f));
		TableLayoutPanel1.Controls.Add((Control)(object)_infoTree, 1, 1);
		TableLayoutPanel1.Controls.Add((Control)(object)_toolbar, 0, 0);
		TableLayoutPanel1.Controls.Add((Control)(object)_graph, 0, 1);
		TableLayoutPanel1.Controls.Add((Control)(object)_infoHeader, 1, 0);
		((Control)TableLayoutPanel1).Dock = (DockStyle)5;
		((Control)TableLayoutPanel1).Location = new Point(0, 0);
		((Control)TableLayoutPanel1).Name = "TableLayoutPanel1";
		TableLayoutPanel1.RowCount = 2;
		TableLayoutPanel1.RowStyles.Add(new RowStyle((SizeType)1, 46f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle((SizeType)2, 100f));
		((Control)TableLayoutPanel1).Size = new Size(1584, 835);
		((Control)TableLayoutPanel1).TabIndex = 2;
		((Control)_graph).BackColor = Color.FromArgb(38, 38, 42);
		((Control)_graph).Dock = (DockStyle)5;
		_graph.FilterText = "";
		((Control)_graph).Location = new Point(3, 49);
		((Control)_graph).Name = "_graph";
		((Control)_graph).Size = new Size(1102, 783);
		((Control)_graph).TabIndex = 0;
		((Control)this).BackColor = Color.FromArgb(38, 38, 42);
		((Control)this).Controls.Add((Control)(object)TableLayoutPanel1);
		((Control)this).Name = "CommNetworkTab";
		((Control)this).Size = new Size(1584, 835);
		((Control)_toolbar).ResumeLayout(false);
		((Control)_toolbar).PerformLayout();
		((Control)_infoHeader).ResumeLayout(false);
		((Control)TableLayoutPanel1).ResumeLayout(false);
		((Control)this).ResumeLayout(false);
	}
}
