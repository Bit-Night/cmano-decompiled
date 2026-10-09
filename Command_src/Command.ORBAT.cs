using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using AdvancedDataGridView;
using Command_Core;
using Command.My;
using DarkUI.Controls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class ORBAT : DarkSecondaryFormBase
{
	[CompilerGenerated]
	internal sealed class _Closure$__102-0
	{
		public TreeGridNode $VB$Local_theNode;

		public ORBAT $VB$Me;

		public _Closure$__102-0(_Closure$__102-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theNode = arg0.$VB$Local_theNode;
			}
		}

		[SpecialName]
		internal void _Lambda$__0()
		{
			$VB$Me.TGV_Contacts.Nodes.Remove($VB$Local_theNode);
		}

		static _Closure$__102-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__106-0
	{
		public DarkFilterTreeNode $VB$Local_theNode;

		public _Closure$__106-1 $VB$NonLocal_$VB$Closure_2;

		public _Closure$__106-0(_Closure$__106-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theNode = arg0.$VB$Local_theNode;
			}
		}

		[SpecialName]
		internal void _Lambda$__0()
		{
			$VB$Local_theNode.Text = $VB$NonLocal_$VB$Closure_2.$VB$Me.method_20($VB$NonLocal_$VB$Closure_2.$VB$Local_theAU);
		}

		static _Closure$__106-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__106-1
	{
		public ActiveUnit $VB$Local_theAU;

		public ORBAT $VB$Me;

		public _Closure$__106-1(_Closure$__106-1 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theAU = arg0.$VB$Local_theAU;
			}
		}

		static _Closure$__106-1()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__110-0
	{
		public ActiveUnit $VB$Local_theAU;

		public ORBAT $VB$Me;

		public Func<DarkFilterTreeNode, bool> $I2;

		public _Closure$__110-0(_Closure$__110-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theAU = arg0.$VB$Local_theAU;
			}
		}

		[SpecialName]
		internal bool _Lambda$__2(DarkFilterTreeNode theNode)
		{
			return theNode.Tag == $VB$Local_theAU.get_ParentGroup(UsingMissionPlanner: false);
		}

		static _Closure$__110-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__110-1
	{
		public DarkFilterTreeNode $VB$Local_NewNode;

		public ActiveUnit $VB$Local_UnitCurrentHost;

		public _Closure$__110-0 $VB$NonLocal_$VB$Closure_2;

		public Func<DarkFilterTreeNode, bool> $I4;

		public _Closure$__110-1(_Closure$__110-1 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_NewNode = arg0.$VB$Local_NewNode;
				$VB$Local_UnitCurrentHost = arg0.$VB$Local_UnitCurrentHost;
			}
		}

		[SpecialName]
		internal void _Lambda$__0()
		{
			//IL_0078: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Expected O, but got Unknown
			//IL_017a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0184: Expected O, but got Unknown
			string text = $VB$NonLocal_$VB$Closure_2.$VB$Me.method_20($VB$NonLocal_$VB$Closure_2.$VB$Local_theAU);
			if ($VB$NonLocal_$VB$Closure_2.$VB$Me.TV_ByGroup.Nodes.Count != 0)
			{
				foreach (DarkFilterTreeNode node in $VB$NonLocal_$VB$Closure_2.$VB$Me.TV_ByGroup.Nodes)
				{
					try
					{
						if (node.Text.CompareTo(text) > 0)
						{
							$VB$Local_NewNode = new DarkFilterTreeNode();
							$VB$Local_NewNode.Tag = $VB$NonLocal_$VB$Closure_2.$VB$Local_theAU;
							$VB$Local_NewNode.Font = new Font(((Control)$VB$NonLocal_$VB$Closure_2.$VB$Me.TV_ByGroup).Font, (FontStyle)0);
							$VB$Local_NewNode.ForeColor = $VB$NonLocal_$VB$Closure_2.$VB$Me.GetUnitProficiencyColor($VB$NonLocal_$VB$Closure_2.$VB$Local_theAU);
							$VB$Local_NewNode.Text = text;
							$VB$Local_NewNode.ParentTree = $VB$NonLocal_$VB$Closure_2.$VB$Me.TV_ByGroup;
							$VB$NonLocal_$VB$Closure_2.$VB$Me.TV_ByGroup.Nodes.Insert($VB$NonLocal_$VB$Closure_2.$VB$Me.TV_ByGroup.Nodes.IndexOf(node), $VB$Local_NewNode);
							$VB$Local_NewNode.EnsureVisible();
							break;
						}
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						ex2?.Data.Add("Error at 523253955t751", "");
						GameGeneral.WriteExceptionsToLog(ex2);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
				}
			}
			else
			{
				$VB$Local_NewNode = new DarkFilterTreeNode();
				$VB$Local_NewNode.Tag = $VB$NonLocal_$VB$Closure_2.$VB$Local_theAU;
				$VB$Local_NewNode.Font = new Font(((Control)$VB$NonLocal_$VB$Closure_2.$VB$Me.TV_ByGroup).Font, (FontStyle)0);
				$VB$Local_NewNode.ForeColor = $VB$NonLocal_$VB$Closure_2.$VB$Me.GetUnitProficiencyColor($VB$NonLocal_$VB$Closure_2.$VB$Local_theAU);
				$VB$Local_NewNode.Text = text;
				$VB$Local_NewNode.ParentTree = $VB$NonLocal_$VB$Closure_2.$VB$Me.TV_ByGroup;
				$VB$NonLocal_$VB$Closure_2.$VB$Me.TV_ByGroup.Nodes.Add($VB$Local_NewNode);
				$VB$Local_NewNode.EnsureVisible();
			}
			$VB$NonLocal_$VB$Closure_2.$VB$Me.TV_ByGroup.UpdateNodes();
		}

		[SpecialName]
		internal void _Lambda$__1()
		{
			//IL_0292: Unknown result type (might be due to invalid IL or missing references)
			//IL_029c: Expected O, but got Unknown
			//IL_01dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e7: Expected O, but got Unknown
			//IL_0104: Unknown result type (might be due to invalid IL or missing references)
			//IL_010e: Expected O, but got Unknown
			string text = $VB$NonLocal_$VB$Closure_2.$VB$Me.method_20($VB$NonLocal_$VB$Closure_2.$VB$Local_theAU);
			DarkFilterTreeNode darkFilterTreeNode = Module1.AllNodes($VB$NonLocal_$VB$Closure_2.$VB$Me.TV_ByGroup).Where(($VB$NonLocal_$VB$Closure_2.$I2 != null) ? $VB$NonLocal_$VB$Closure_2.$I2 : ($VB$NonLocal_$VB$Closure_2.$I2 = [SpecialName] (DarkFilterTreeNode theNode) => theNode.Tag == $VB$NonLocal_$VB$Closure_2.$VB$Local_theAU.get_ParentGroup(UsingMissionPlanner: false))).FirstOrDefault();
			if (darkFilterTreeNode == null)
			{
				return;
			}
			if (darkFilterTreeNode.Nodes.Count != 0)
			{
				bool flag = false;
				foreach (DarkFilterTreeNode node in darkFilterTreeNode.Nodes)
				{
					if (node.Text.CompareTo(text) > 0)
					{
						$VB$Local_NewNode = new DarkFilterTreeNode();
						$VB$Local_NewNode.Tag = $VB$NonLocal_$VB$Closure_2.$VB$Local_theAU;
						$VB$Local_NewNode.Font = new Font(((Control)$VB$NonLocal_$VB$Closure_2.$VB$Me.TV_ByGroup).Font, (FontStyle)0);
						$VB$Local_NewNode.ForeColor = $VB$NonLocal_$VB$Closure_2.$VB$Me.GetUnitProficiencyColor($VB$NonLocal_$VB$Closure_2.$VB$Local_theAU);
						$VB$Local_NewNode.Text = text;
						$VB$Local_NewNode.ParentTree = $VB$NonLocal_$VB$Closure_2.$VB$Me.TV_ByGroup;
						darkFilterTreeNode.Nodes.Insert(darkFilterTreeNode.Nodes.IndexOf(node), $VB$Local_NewNode);
						$VB$Local_NewNode.EnsureVisible();
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					$VB$Local_NewNode = new DarkFilterTreeNode();
					$VB$Local_NewNode.Tag = $VB$NonLocal_$VB$Closure_2.$VB$Local_theAU;
					$VB$Local_NewNode.Font = new Font(((Control)$VB$NonLocal_$VB$Closure_2.$VB$Me.TV_ByGroup).Font, (FontStyle)0);
					$VB$Local_NewNode.ForeColor = $VB$NonLocal_$VB$Closure_2.$VB$Me.GetUnitProficiencyColor($VB$NonLocal_$VB$Closure_2.$VB$Local_theAU);
					$VB$Local_NewNode.Text = text;
					$VB$Local_NewNode.ParentTree = $VB$NonLocal_$VB$Closure_2.$VB$Me.TV_ByGroup;
					darkFilterTreeNode.Nodes.Add($VB$Local_NewNode);
					$VB$Local_NewNode.EnsureVisible();
				}
			}
			else
			{
				$VB$Local_NewNode = new DarkFilterTreeNode();
				$VB$Local_NewNode.Tag = $VB$NonLocal_$VB$Closure_2.$VB$Local_theAU;
				$VB$Local_NewNode.Font = new Font(((Control)$VB$NonLocal_$VB$Closure_2.$VB$Me.TV_ByGroup).Font, (FontStyle)0);
				$VB$Local_NewNode.ForeColor = $VB$NonLocal_$VB$Closure_2.$VB$Me.GetUnitProficiencyColor($VB$NonLocal_$VB$Closure_2.$VB$Local_theAU);
				$VB$Local_NewNode.Text = text;
				$VB$Local_NewNode.ParentTree = $VB$NonLocal_$VB$Closure_2.$VB$Me.TV_ByGroup;
				darkFilterTreeNode.Nodes.Add($VB$Local_NewNode);
			}
			$VB$NonLocal_$VB$Closure_2.$VB$Me.TV_ByGroup.UpdateNodes();
		}

		[SpecialName]
		internal void _Lambda$__3()
		{
			//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c3: Expected O, but got Unknown
			//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b3: Expected O, but got Unknown
			//IL_0282: Unknown result type (might be due to invalid IL or missing references)
			//IL_028c: Expected O, but got Unknown
			string text = $VB$NonLocal_$VB$Closure_2.$VB$Me.method_20($VB$NonLocal_$VB$Closure_2.$VB$Local_theAU);
			DarkFilterTreeNode darkFilterTreeNode = Module1.AllNodes($VB$NonLocal_$VB$Closure_2.$VB$Me.TV_ByGroup).Where(($I4 != null) ? $I4 : ($I4 = [SpecialName] (DarkFilterTreeNode theNode) => theNode.Tag == $VB$Local_UnitCurrentHost)).FirstOrDefault();
			if (darkFilterTreeNode == null)
			{
				return;
			}
			if (darkFilterTreeNode.Nodes.Count == 0)
			{
				$VB$Local_NewNode = new DarkFilterTreeNode();
				$VB$Local_NewNode.Tag = $VB$NonLocal_$VB$Closure_2.$VB$Local_theAU;
				$VB$Local_NewNode.Font = new Font(((Control)$VB$NonLocal_$VB$Closure_2.$VB$Me.TV_ByGroup).Font, (FontStyle)0);
				$VB$Local_NewNode.ForeColor = $VB$NonLocal_$VB$Closure_2.$VB$Me.GetUnitProficiencyColor($VB$NonLocal_$VB$Closure_2.$VB$Local_theAU);
				$VB$Local_NewNode.Text = text;
				$VB$Local_NewNode.ParentTree = $VB$NonLocal_$VB$Closure_2.$VB$Me.TV_ByGroup;
				darkFilterTreeNode.Nodes.Add($VB$Local_NewNode);
				$VB$Local_NewNode.EnsureVisible();
			}
			else
			{
				bool flag = false;
				foreach (DarkFilterTreeNode node in darkFilterTreeNode.Nodes)
				{
					if (node.Text.CompareTo(text) > 0)
					{
						$VB$Local_NewNode = new DarkFilterTreeNode();
						$VB$Local_NewNode.Tag = $VB$NonLocal_$VB$Closure_2.$VB$Local_theAU;
						$VB$Local_NewNode.Font = new Font(((Control)$VB$NonLocal_$VB$Closure_2.$VB$Me.TV_ByGroup).Font, (FontStyle)0);
						$VB$Local_NewNode.ForeColor = $VB$NonLocal_$VB$Closure_2.$VB$Me.GetUnitProficiencyColor($VB$NonLocal_$VB$Closure_2.$VB$Local_theAU);
						$VB$Local_NewNode.Text = text;
						$VB$Local_NewNode.ParentTree = $VB$NonLocal_$VB$Closure_2.$VB$Me.TV_ByGroup;
						darkFilterTreeNode.Nodes.Insert(darkFilterTreeNode.Nodes.IndexOf(node), $VB$Local_NewNode);
						$VB$Local_NewNode.EnsureVisible();
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					$VB$Local_NewNode = new DarkFilterTreeNode();
					$VB$Local_NewNode.Tag = $VB$NonLocal_$VB$Closure_2.$VB$Local_theAU;
					$VB$Local_NewNode.Font = new Font(((Control)$VB$NonLocal_$VB$Closure_2.$VB$Me.TV_ByGroup).Font, (FontStyle)0);
					$VB$Local_NewNode.ForeColor = $VB$NonLocal_$VB$Closure_2.$VB$Me.GetUnitProficiencyColor($VB$NonLocal_$VB$Closure_2.$VB$Local_theAU);
					$VB$Local_NewNode.Text = text;
					$VB$Local_NewNode.ParentTree = $VB$NonLocal_$VB$Closure_2.$VB$Me.TV_ByGroup;
					darkFilterTreeNode.Nodes.Add($VB$Local_NewNode);
					$VB$Local_NewNode.EnsureVisible();
				}
			}
			$VB$NonLocal_$VB$Closure_2.$VB$Me.TV_ByGroup.UpdateNodes();
		}

		[SpecialName]
		internal bool _Lambda$__4(DarkFilterTreeNode theNode)
		{
			return theNode.Tag == $VB$Local_UnitCurrentHost;
		}

		[SpecialName]
		internal void _Lambda$__5()
		{
			$VB$Local_NewNode.Expanded = true;
			$VB$NonLocal_$VB$Closure_2.$VB$Me.TV_ByGroup.UpdateNodes();
		}

		static _Closure$__110-1()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__111-0
	{
		public DarkFilterTreeNode $VB$Local_NodeToRemove;

		public ORBAT $VB$Me;

		public _Closure$__111-0(_Closure$__111-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_NodeToRemove = arg0.$VB$Local_NodeToRemove;
			}
		}

		[SpecialName]
		internal void _Lambda$__0()
		{
			if (Information.IsNothing((object)$VB$Local_NodeToRemove.ParentNode))
			{
				$VB$Me.TV_ByGroup.Nodes.Remove($VB$Local_NodeToRemove);
			}
			else
			{
				$VB$Local_NodeToRemove.ParentNode.Nodes.Remove($VB$Local_NodeToRemove);
			}
			$VB$Me.TV_ByGroup.UpdateNodes();
		}

		static _Closure$__111-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__112-0
	{
		public DarkFilterTreeNode $VB$Local_NodeToRemove;

		public ORBAT $VB$Me;

		public _Closure$__112-0(_Closure$__112-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_NodeToRemove = arg0.$VB$Local_NodeToRemove;
			}
		}

		[SpecialName]
		internal void _Lambda$__0()
		{
			if (!Information.IsNothing((object)$VB$Local_NodeToRemove.ParentNode))
			{
				$VB$Local_NodeToRemove.ParentNode.Nodes.Remove($VB$Local_NodeToRemove);
			}
			else
			{
				$VB$Me.TV_ByMission.Nodes.Remove($VB$Local_NodeToRemove);
			}
			$VB$Me.TV_ByMission.UpdateNodes();
		}

		static _Closure$__112-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__114-0
	{
		public ActiveUnit $VB$Local_theAU;

		public ORBAT $VB$Me;

		public Func<DarkFilterTreeNode, bool> $I1;

		public Func<DarkFilterTreeNode, bool> $I2;

		public _Closure$__114-0(_Closure$__114-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theAU = arg0.$VB$Local_theAU;
			}
		}

		[SpecialName]
		internal void _Lambda$__0()
		{
			//IL_0089: Unknown result type (might be due to invalid IL or missing references)
			//IL_0093: Expected O, but got Unknown
			//IL_019b: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a5: Expected O, but got Unknown
			//IL_0130: Unknown result type (might be due to invalid IL or missing references)
			//IL_013a: Expected O, but got Unknown
			DarkFilterTreeNode darkFilterTreeNode = null;
			string text = $VB$Me.method_20($VB$Local_theAU);
			bool flag = false;
			DarkFilterTreeNode darkFilterTreeNode2 = Module1.AllNodes($VB$Me.TV_ByType).Where(($I1 != null) ? $I1 : ($I1 = [SpecialName] (DarkFilterTreeNode theNode) => theNode.Tag.GetType().IsPrimitive && Conversions.ToInteger(theNode.Tag) == (int)$VB$Local_theAU.UnitType)).FirstOrDefault();
			if (darkFilterTreeNode2 == null)
			{
				darkFilterTreeNode2 = new DarkFilterTreeNode
				{
					Tag = (int)$VB$Local_theAU.UnitType,
					Font = new Font(((Control)$VB$Me.TV_ByType).Font, (FontStyle)0),
					ForeColor = Color.White,
					Text = $VB$Local_theAU.UnitType_String,
					ParentTree = $VB$Me.TV_ByType
				};
				flag = true;
			}
			DarkFilterTreeNode darkFilterTreeNode3 = darkFilterTreeNode2.Nodes.Where([SpecialName] (DarkFilterTreeNode theNode) => theNode.Tag.GetType().IsPrimitive && Conversions.ToInteger(theNode.Tag) == $VB$Local_theAU.SubType).FirstOrDefault();
			if (darkFilterTreeNode3 == null)
			{
				darkFilterTreeNode3 = new DarkFilterTreeNode
				{
					Tag = $VB$Local_theAU.SubType,
					Font = new Font(((Control)$VB$Me.TV_ByType).Font, (FontStyle)0),
					ForeColor = Color.White,
					Text = $VB$Local_theAU.SubTypeDescription,
					ParentTree = $VB$Me.TV_ByType
				};
				darkFilterTreeNode2.Nodes.Add(darkFilterTreeNode3);
			}
			darkFilterTreeNode = new DarkFilterTreeNode
			{
				Tag = $VB$Local_theAU,
				Font = new Font(((Control)$VB$Me.TV_ByType).Font, (FontStyle)0),
				ForeColor = $VB$Me.GetUnitProficiencyColor($VB$Local_theAU),
				Text = text,
				ParentTree = $VB$Me.TV_ByType
			};
			darkFilterTreeNode3.Nodes.Add(darkFilterTreeNode);
			if (flag)
			{
				$VB$Me.TV_ByType.Nodes.Add(darkFilterTreeNode2);
				darkFilterTreeNode2.EnsureVisible();
			}
		}

		[SpecialName]
		internal bool _Lambda$__1(DarkFilterTreeNode theNode)
		{
			if (!theNode.Tag.GetType().IsPrimitive)
			{
				return false;
			}
			return Conversions.ToInteger(theNode.Tag) == (int)$VB$Local_theAU.UnitType;
		}

		[SpecialName]
		internal bool _Lambda$__2(DarkFilterTreeNode theNode)
		{
			if (!theNode.Tag.GetType().IsPrimitive)
			{
				return false;
			}
			return Conversions.ToInteger(theNode.Tag) == $VB$Local_theAU.SubType;
		}

		static _Closure$__114-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__115-0
	{
		public DarkFilterTreeNode $VB$Local_NodeToRemove;

		public ORBAT $VB$Me;

		public _Closure$__115-0(_Closure$__115-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_NodeToRemove = arg0.$VB$Local_NodeToRemove;
			}
		}

		[SpecialName]
		internal void _Lambda$__0()
		{
			if (Information.IsNothing((object)$VB$Local_NodeToRemove.ParentNode))
			{
				$VB$Me.TV_ByType.Nodes.Remove($VB$Local_NodeToRemove);
			}
			else
			{
				$VB$Local_NodeToRemove.ParentNode.Nodes.Remove($VB$Local_NodeToRemove);
			}
			$VB$Me.TV_ByType.UpdateNodes();
		}

		static _Closure$__115-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__129-0
	{
		public ActiveUnit $VB$Local_theAU;

		public _Closure$__129-0(_Closure$__129-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theAU = arg0.$VB$Local_theAU;
			}
		}

		[SpecialName]
		internal bool _Lambda$__1(DarkFilterTreeNode theNode)
		{
			return Conversions.ToInteger(theNode.Tag) == (int)$VB$Local_theAU.UnitType;
		}

		[SpecialName]
		internal bool _Lambda$__2(DarkFilterTreeNode theNode)
		{
			return Conversions.ToInteger(theNode.Tag) == $VB$Local_theAU.SubType;
		}

		static _Closure$__129-0()
		{
			Class72.smethod_20();
		}
	}

	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("TabControl1")]
	private DarkUITabControl _TabControl1;

	[AccessedThroughProperty("CB_Proficiency")]
	[CompilerGenerated]
	private DarkUIComboBox _CB_Proficiency;

	[CompilerGenerated]
	[AccessedThroughProperty("TV_ByGroup")]
	private DarkFilterTreeView _TV_ByGroup;

	[CompilerGenerated]
	[AccessedThroughProperty("TV_ByMission")]
	private DarkFilterTreeView _TV_ByMission;

	[AccessedThroughProperty("TB_SearchOOB")]
	[CompilerGenerated]
	private DarkTextBox _TB_SearchOOB;

	[CompilerGenerated]
	[AccessedThroughProperty("TV_ByType")]
	private DarkFilterTreeView _TV_ByType;

	[CompilerGenerated]
	[AccessedThroughProperty("TGV_Contacts")]
	private DarkTreeGridView _TGV_Contacts;

	[AccessedThroughProperty("ContactBDA")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

	[CompilerGenerated]
	[AccessedThroughProperty("Timer1")]
	private Timer timer_0;

	[CompilerGenerated]
	[AccessedThroughProperty("btnEXPCOL")]
	private DarkUIButton darkUIButton_0;

	[CompilerGenerated]
	private bool bool_2;

	private bool bool_3;

	private bool bool_4;

	private bool bool_5;

	private bool bool_6;

	private bool bool_7;

	private bool bool_8;

	private bool bool_9;

	private bool bool_10;

	private LockObject lockObject_0;

	private LockObject lockObject_1;

	internal virtual DarkUITabControl TabControl1
	{
		[CompilerGenerated]
		get
		{
			return _TabControl1;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_41;
			DarkUITabControl darkUITabControl = _TabControl1;
			if (darkUITabControl != null)
			{
				((TabControl)darkUITabControl).SelectedIndexChanged -= eventHandler;
			}
			_TabControl1 = value;
			darkUITabControl = _TabControl1;
			if (darkUITabControl != null)
			{
				((TabControl)darkUITabControl).SelectedIndexChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("TabPage1")]
	internal virtual TabPage TabPage1 { get; set; }

	[field: AccessedThroughProperty("TabPage2")]
	internal virtual TabPage TabPage2 { get; set; }

	[field: AccessedThroughProperty("Label_Proficiency")]
	internal virtual DarkLabel Label_Proficiency { get; set; }

	[field: AccessedThroughProperty("Label_SetUnitProficiency")]
	internal virtual DarkLabel Label_SetUnitProficiency { get; set; }

	internal virtual DarkUIComboBox CB_Proficiency
	{
		[CompilerGenerated]
		get
		{
			return _CB_Proficiency;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_28;
			DarkUIComboBox darkUIComboBox = _CB_Proficiency;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			_CB_Proficiency = value;
			darkUIComboBox = _CB_Proficiency;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
			}
		}
	}

	internal virtual DarkFilterTreeView TV_ByGroup
	{
		[CompilerGenerated]
		get
		{
			return _TV_ByGroup;
		}
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_29;
			DarkFilterTreeView darkFilterTreeView = _TV_ByGroup;
			if (darkFilterTreeView != null)
			{
				darkFilterTreeView.SelectedNodesChanged -= value2;
			}
			_TV_ByGroup = value;
			darkFilterTreeView = _TV_ByGroup;
			if (darkFilterTreeView != null)
			{
				darkFilterTreeView.SelectedNodesChanged += value2;
			}
		}
	}

	internal virtual DarkFilterTreeView TV_ByMission
	{
		[CompilerGenerated]
		get
		{
			return _TV_ByMission;
		}
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler value2 = method_30;
			MouseEventHandler val = new MouseEventHandler(method_31);
			DarkFilterTreeView darkFilterTreeView = _TV_ByMission;
			if (darkFilterTreeView != null)
			{
				darkFilterTreeView.SelectedNodesChanged -= value2;
				((Control)darkFilterTreeView).MouseDoubleClick -= val;
			}
			_TV_ByMission = value;
			darkFilterTreeView = _TV_ByMission;
			if (darkFilterTreeView != null)
			{
				darkFilterTreeView.SelectedNodesChanged += value2;
				((Control)darkFilterTreeView).MouseDoubleClick += val;
			}
		}
	}

	[field: AccessedThroughProperty("DarkLabel1")]
	internal virtual DarkLabel DarkLabel1 { get; set; }

	internal virtual DarkTextBox TB_SearchOOB
	{
		[CompilerGenerated]
		get
		{
			return _TB_SearchOOB;
		}
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = method_34;
			KeyPressEventHandler val = new KeyPressEventHandler(method_35);
			DarkTextBox darkTextBox = _TB_SearchOOB;
			if (darkTextBox != null)
			{
				((Control)darkTextBox).TextChanged -= eventHandler;
				((Control)darkTextBox).KeyPress -= val;
			}
			_TB_SearchOOB = value;
			darkTextBox = _TB_SearchOOB;
			if (darkTextBox != null)
			{
				((Control)darkTextBox).TextChanged += eventHandler;
				((Control)darkTextBox).KeyPress += val;
			}
		}
	}

	[field: AccessedThroughProperty("TabPage3")]
	internal virtual TabPage TabPage3 { get; set; }

	internal virtual DarkFilterTreeView TV_ByType
	{
		[CompilerGenerated]
		get
		{
			return _TV_ByType;
		}
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler value2 = method_32;
			MouseEventHandler val = new MouseEventHandler(method_33);
			DarkFilterTreeView darkFilterTreeView = _TV_ByType;
			if (darkFilterTreeView != null)
			{
				darkFilterTreeView.SelectedNodesChanged -= value2;
				((Control)darkFilterTreeView).MouseDoubleClick -= val;
			}
			_TV_ByType = value;
			darkFilterTreeView = _TV_ByType;
			if (darkFilterTreeView != null)
			{
				darkFilterTreeView.SelectedNodesChanged += value2;
				((Control)darkFilterTreeView).MouseDoubleClick += val;
			}
		}
	}

	[field: AccessedThroughProperty("TabPage4")]
	internal virtual TabPage TabPage4 { get; set; }

	private virtual DarkTreeGridView TGV_Contacts
	{
		[CompilerGenerated]
		get
		{
			return _TGV_Contacts;
		}
		[CompilerGenerated]
		set
		{
			ExpandingEventHandler value2 = method_37;
			EventHandler eventHandler = method_38;
			DarkTreeGridView darkTreeGridView = _TGV_Contacts;
			if (darkTreeGridView != null)
			{
				darkTreeGridView.NodeExpanding -= value2;
				((DataGridView)darkTreeGridView).SelectionChanged -= eventHandler;
			}
			_TGV_Contacts = value;
			darkTreeGridView = _TGV_Contacts;
			if (darkTreeGridView != null)
			{
				darkTreeGridView.NodeExpanding += value2;
				((DataGridView)darkTreeGridView).SelectionChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("ContactName")]
	internal virtual TreeGridColumn ContactName { get; set; }

	[field: AccessedThroughProperty("ContactType")]
	internal virtual DataGridViewTextBoxColumn ContactType { get; set; }

	[field: AccessedThroughProperty("ContactPosture")]
	internal virtual DataGridViewTextBoxColumn ContactPosture { get; set; }

	internal virtual DataGridViewTextBoxColumn ContactBDA
	{
		[CompilerGenerated]
		get
		{
			return dataGridViewTextBoxColumn_0;
		}
		[CompilerGenerated]
		set
		{
			dataGridViewTextBoxColumn_0 = value;
		}
	}

	[field: AccessedThroughProperty("ContactHostedUnits")]
	internal virtual DataGridViewTextBoxColumn ContactHostedUnits { get; set; }

	internal virtual Timer Timer1
	{
		[CompilerGenerated]
		get
		{
			return timer_0;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_40;
			Timer val = timer_0;
			if (val != null)
			{
				val.Tick -= eventHandler;
			}
			timer_0 = value;
			val = timer_0;
			if (val != null)
			{
				val.Tick += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton btnEXPCOL
	{
		[CompilerGenerated]
		get
		{
			return darkUIButton_0;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_44;
			DarkUIButton darkUIButton = darkUIButton_0;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			darkUIButton_0 = value;
			darkUIButton = darkUIButton_0;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	protected override bool RTMPEnabled
	{
		[CompilerGenerated]
		get
		{
			return bool_2;
		}
		[CompilerGenerated]
		set
		{
			bool_2 = value;
		}
	}

	public ORBAT()
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Expected O, but got Unknown
		((Form)this).Load += ORBAT_Load;
		((Form)this).Closing += ORBAT_Closing;
		((Control)this).KeyDown += new KeyEventHandler(ORBAT_KeyDown);
		((Form)this).FormClosing += new FormClosingEventHandler(ORBAT_FormClosing);
		((Form)this).Shown += ORBAT_Shown;
		RTMPEnabled = true;
		bool_3 = true;
		bool_4 = true;
		bool_5 = true;
		bool_6 = false;
		bool_7 = true;
		bool_8 = true;
		bool_9 = true;
		bool_10 = false;
		lockObject_0 = new LockObject();
		lockObject_1 = new LockObject();
		InitializeComponent_1();
	}

	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && icontainer_1 != null)
			{
				icontainer_1.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	private void InitializeComponent_1()
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected O, but got Unknown
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected O, but got Unknown
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected O, but got Unknown
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected O, but got Unknown
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Expected O, but got Unknown
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Expected O, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Expected O, but got Unknown
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Expected O, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ee: Expected O, but got Unknown
		//IL_02ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_049a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0591: Unknown result type (might be due to invalid IL or missing references)
		//IL_0653: Unknown result type (might be due to invalid IL or missing references)
		//IL_065d: Expected O, but got Unknown
		//IL_071a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0724: Expected O, but got Unknown
		//IL_0a47: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a51: Expected O, but got Unknown
		//IL_0ba0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0baa: Expected O, but got Unknown
		//IL_0ded: Unknown result type (might be due to invalid IL or missing references)
		icontainer_1 = new Container();
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		DataGridViewCellStyle val3 = new DataGridViewCellStyle();
		DataGridViewCellStyle val4 = new DataGridViewCellStyle();
		DataGridViewCellStyle val5 = new DataGridViewCellStyle();
		TabControl1 = new DarkUITabControl();
		TabPage1 = new TabPage();
		TV_ByGroup = new DarkFilterTreeView();
		TabPage2 = new TabPage();
		TV_ByMission = new DarkFilterTreeView();
		TabPage3 = new TabPage();
		TV_ByType = new DarkFilterTreeView();
		TabPage4 = new TabPage();
		TGV_Contacts = new DarkTreeGridView();
		ContactName = new TreeGridColumn();
		ContactType = new DataGridViewTextBoxColumn();
		ContactPosture = new DataGridViewTextBoxColumn();
		ContactBDA = new DataGridViewTextBoxColumn();
		ContactHostedUnits = new DataGridViewTextBoxColumn();
		Label_Proficiency = new DarkLabel();
		Label_SetUnitProficiency = new DarkLabel();
		CB_Proficiency = new DarkUIComboBox();
		DarkLabel1 = new DarkLabel();
		TB_SearchOOB = new DarkTextBox();
		Timer1 = new Timer(icontainer_1);
		btnEXPCOL = new DarkUIButton();
		((Control)TabControl1).SuspendLayout();
		((Control)TabPage1).SuspendLayout();
		((Control)TabPage2).SuspendLayout();
		((Control)TabPage3).SuspendLayout();
		((Control)TabPage4).SuspendLayout();
		((ISupportInitialize)(object)TGV_Contacts).BeginInit();
		((Control)this).SuspendLayout();
		((Control)TabControl1).Anchor = (AnchorStyles)15;
		((Control)TabControl1).Controls.Add((Control)(object)TabPage1);
		((Control)TabControl1).Controls.Add((Control)(object)TabPage2);
		((Control)TabControl1).Controls.Add((Control)(object)TabPage3);
		((Control)TabControl1).Controls.Add((Control)(object)TabPage4);
		((Control)TabControl1).Cursor = Cursors.Hand;
		((Control)TabControl1).Font = new Font("Segoe UI", 8f);
		((TabControl)TabControl1).ItemSize = new Size(80, 20);
		((Control)TabControl1).Location = new Point(0, 1);
		((Control)TabControl1).Name = "TabControl1";
		((TabControl)TabControl1).SelectedIndex = 0;
		((Control)TabControl1).Size = new Size(592, 374);
		((Control)TabControl1).TabIndex = 0;
		TabPage1.BackColor = Color.FromArgb(60, 63, 65);
		((Control)TabPage1).Controls.Add((Control)(object)TV_ByGroup);
		TabPage1.Location = new Point(4, 24);
		((Control)TabPage1).Name = "TabPage1";
		((Control)TabPage1).Padding = new Padding(3);
		((Control)TabPage1).Size = new Size(584, 346);
		TabPage1.TabIndex = 0;
		TabPage1.Text = "Units By Group";
		((Control)TV_ByGroup).Dock = (DockStyle)5;
		((Control)TV_ByGroup).Location = new Point(3, 3);
		TV_ByGroup.MaxDragChange = 20;
		((Control)TV_ByGroup).Name = "TV_ByGroup";
		((Control)TV_ByGroup).Size = new Size(578, 340);
		((Control)TV_ByGroup).TabIndex = 0;
		TabPage2.BackColor = Color.FromArgb(60, 63, 65);
		((Control)TabPage2).Controls.Add((Control)(object)TV_ByMission);
		TabPage2.Location = new Point(4, 24);
		((Control)TabPage2).Name = "TabPage2";
		((Control)TabPage2).Padding = new Padding(3);
		((Control)TabPage2).Size = new Size(584, 346);
		TabPage2.TabIndex = 1;
		TabPage2.Text = "Units By Mission / Task";
		((Control)TV_ByMission).Dock = (DockStyle)5;
		((Control)TV_ByMission).Location = new Point(3, 3);
		TV_ByMission.MaxDragChange = 20;
		((Control)TV_ByMission).Name = "TV_ByMission";
		((Control)TV_ByMission).Size = new Size(578, 340);
		((Control)TV_ByMission).TabIndex = 0;
		TabPage3.BackColor = Color.FromArgb(60, 63, 65);
		((Control)TabPage3).Controls.Add((Control)(object)TV_ByType);
		TabPage3.Location = new Point(4, 24);
		((Control)TabPage3).Name = "TabPage3";
		((Control)TabPage3).Padding = new Padding(3);
		((Control)TabPage3).Size = new Size(584, 346);
		TabPage3.TabIndex = 2;
		TabPage3.Text = "Units By Type";
		((Control)TV_ByType).Dock = (DockStyle)5;
		((Control)TV_ByType).Location = new Point(3, 3);
		TV_ByType.MaxDragChange = 20;
		((Control)TV_ByType).Name = "TV_ByType";
		((Control)TV_ByType).Size = new Size(578, 340);
		((Control)TV_ByType).TabIndex = 0;
		TabPage4.BackColor = Color.FromArgb(60, 63, 65);
		((Control)TabPage4).Controls.Add((Control)(object)TGV_Contacts);
		TabPage4.Location = new Point(4, 24);
		((Control)TabPage4).Name = "ComNetworkLog";
		((Control)TabPage4).Padding = new Padding(3);
		((Control)TabPage4).Size = new Size(584, 346);
		TabPage4.TabIndex = 3;
		TabPage4.Text = "Contacts";
		((DataGridView)TGV_Contacts).AllowUserToAddRows = false;
		((DataGridView)TGV_Contacts).AllowUserToDeleteRows = false;
		((DataGridView)TGV_Contacts).AllowUserToOrderColumns = true;
		((DataGridView)TGV_Contacts).BackgroundColor = Color.FromArgb(51, 51, 51);
		((DataGridView)TGV_Contacts).BorderStyle = (BorderStyle)2;
		((DataGridView)TGV_Contacts).CellBorderStyle = (DataGridViewCellBorderStyle)4;
		((DataGridView)TGV_Contacts).ColumnHeadersBorderStyle = (DataGridViewHeaderBorderStyle)4;
		val.Alignment = (DataGridViewContentAlignment)16;
		val.BackColor = Color.FromArgb(66, 77, 95);
		val.Font = new Font("Segoe UI", 8f);
		val.ForeColor = Color.LightGray;
		val.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val.SelectionForeColor = Color.FromArgb(122, 128, 132);
		val.WrapMode = (DataGridViewTriState)1;
		((DataGridView)TGV_Contacts).ColumnHeadersDefaultCellStyle = val;
		((DataGridView)TGV_Contacts).ColumnHeadersHeight = 34;
		((DataGridView)TGV_Contacts).Columns.AddRange((DataGridViewColumn[])(object)new DataGridViewColumn[5]
		{
			(DataGridViewColumn)ContactName,
			(DataGridViewColumn)ContactType,
			(DataGridViewColumn)ContactPosture,
			(DataGridViewColumn)ContactBDA,
			(DataGridViewColumn)ContactHostedUnits
		});
		val2.Alignment = (DataGridViewContentAlignment)16;
		val2.BackColor = Color.FromArgb(51, 51, 51);
		val2.Font = new Font("Segoe UI", 8f);
		val2.ForeColor = Color.LightGray;
		val2.SelectionBackColor = SystemColors.Highlight;
		val2.SelectionForeColor = SystemColors.HighlightText;
		val2.WrapMode = (DataGridViewTriState)2;
		((DataGridView)TGV_Contacts).DefaultCellStyle = val2;
		((Control)TGV_Contacts).Dock = (DockStyle)5;
		((DataGridView)TGV_Contacts).EditMode = (DataGridViewEditMode)4;
		((DataGridView)TGV_Contacts).EnableHeadersVisualStyles = false;
		TGV_Contacts.ImageList = null;
		((Control)TGV_Contacts).Location = new Point(3, 3);
		((Control)TGV_Contacts).Name = "TGV_Contacts";
		((DataGridView)TGV_Contacts).RowHeadersVisible = false;
		((DataGridView)TGV_Contacts).RowHeadersWidth = 20;
		((DataGridView)TGV_Contacts).SelectionMode = (DataGridViewSelectionMode)1;
		TGV_Contacts.ShowLines = false;
		((Control)TGV_Contacts).Size = new Size(578, 340);
		((Control)TGV_Contacts).TabIndex = 8;
		((DataGridViewColumn)ContactName).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		ContactName.DefaultNodeImage = null;
		((DataGridViewColumn)ContactName).HeaderText = "Name";
		((DataGridViewColumn)ContactName).MinimumWidth = 8;
		((DataGridViewColumn)ContactName).Name = "ContactName";
		((DataGridViewColumn)ContactName).ReadOnly = true;
		((DataGridViewColumn)ContactName).Resizable = (DataGridViewTriState)1;
		((DataGridViewTextBoxColumn)ContactName).SortMode = (DataGridViewColumnSortMode)0;
		((DataGridViewColumn)ContactType).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		((DataGridViewColumn)ContactType).HeaderText = "Type/Class";
		((DataGridViewColumn)ContactType).MinimumWidth = 8;
		((DataGridViewColumn)ContactType).Name = "ContactType";
		((DataGridViewColumn)ContactType).ReadOnly = true;
		ContactType.SortMode = (DataGridViewColumnSortMode)0;
		((DataGridViewColumn)ContactType).Width = 88;
		((DataGridViewColumn)ContactPosture).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		val3.Alignment = (DataGridViewContentAlignment)32;
		((DataGridViewColumn)ContactPosture).DefaultCellStyle = val3;
		((DataGridViewColumn)ContactPosture).HeaderText = "Posture";
		((DataGridViewColumn)ContactPosture).MinimumWidth = 8;
		((DataGridViewColumn)ContactPosture).Name = "ContactPosture";
		((DataGridViewColumn)ContactPosture).ReadOnly = true;
		ContactPosture.SortMode = (DataGridViewColumnSortMode)0;
		((DataGridViewColumn)ContactPosture).Width = 66;
		((DataGridViewColumn)ContactBDA).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		val4.Alignment = (DataGridViewContentAlignment)32;
		((DataGridViewColumn)ContactBDA).DefaultCellStyle = val4;
		((DataGridViewColumn)ContactBDA).HeaderText = "BDA";
		((DataGridViewColumn)ContactBDA).MinimumWidth = 8;
		((DataGridViewColumn)ContactBDA).Name = "ContactBDA";
		((DataGridViewColumn)ContactBDA).ReadOnly = true;
		ContactBDA.SortMode = (DataGridViewColumnSortMode)0;
		((DataGridViewColumn)ContactBDA).Width = 44;
		((DataGridViewColumn)ContactHostedUnits).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		val5.Alignment = (DataGridViewContentAlignment)32;
		((DataGridViewColumn)ContactHostedUnits).DefaultCellStyle = val5;
		((DataGridViewColumn)ContactHostedUnits).HeaderText = "Spotted hosted";
		((DataGridViewColumn)ContactHostedUnits).MinimumWidth = 8;
		((DataGridViewColumn)ContactHostedUnits).Name = "ContactHostedUnits";
		((DataGridViewColumn)ContactHostedUnits).ReadOnly = true;
		ContactHostedUnits.SortMode = (DataGridViewColumnSortMode)0;
		((DataGridViewColumn)ContactHostedUnits).Width = 119;
		((Control)Label_Proficiency).Anchor = (AnchorStyles)6;
		Label_Proficiency.AutoSize = true;
		((Control)Label_Proficiency).Font = new Font("Segoe UI", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)Label_Proficiency).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_Proficiency).Location = new Point(4, 416);
		((Control)Label_Proficiency).Name = "Label_Proficiency";
		((Control)Label_Proficiency).Size = new Size(72, 23);
		((Control)Label_Proficiency).TabIndex = 4;
		((Label)Label_Proficiency).Text = "Regular";
		((Control)Label_SetUnitProficiency).Anchor = (AnchorStyles)10;
		Label_SetUnitProficiency.AutoSize = true;
		((Control)Label_SetUnitProficiency).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_SetUnitProficiency).Location = new Point(265, 415);
		((Control)Label_SetUnitProficiency).Name = "Label_SetUnitProficiency";
		((Control)Label_SetUnitProficiency).Size = new Size(223, 25);
		((Control)Label_SetUnitProficiency).TabIndex = 5;
		((Label)Label_SetUnitProficiency).Text = "Set unit/group proficiency:";
		((Control)CB_Proficiency).Anchor = (AnchorStyles)10;
		((ComboBox)CB_Proficiency).BackColor = Color.Transparent;
		((ComboBox)CB_Proficiency).DrawMode = (DrawMode)1;
		((ComboBox)CB_Proficiency).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_Proficiency).Font = new Font("Segoe UI", 7f);
		((ListControl)CB_Proficiency).FormattingEnabled = true;
		((ComboBox)CB_Proficiency).Items.AddRange(new object[6] { "Novice", "Cadet", "Regular", "Veteran", "Ace", "Inherited from Side" });
		((Control)CB_Proficiency).Location = new Point(420, 414);
		((Control)CB_Proficiency).Name = "CB_Proficiency";
		((Control)CB_Proficiency).Size = new Size(165, 27);
		((Control)CB_Proficiency).TabIndex = 6;
		((Control)DarkLabel1).Anchor = (AnchorStyles)6;
		DarkLabel1.AutoSize = true;
		((Control)DarkLabel1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel1).Location = new Point(4, 386);
		((Control)DarkLabel1).Name = "DarkLabel1";
		((Control)DarkLabel1).Size = new Size(68, 25);
		((Control)DarkLabel1).TabIndex = 8;
		((Label)DarkLabel1).Text = "Search:";
		((Control)TB_SearchOOB).Anchor = (AnchorStyles)14;
		((TextBoxBase)TB_SearchOOB).BackColor = Color.FromArgb(69, 73, 74);
		((TextBoxBase)TB_SearchOOB).BorderStyle = (BorderStyle)1;
		((TextBoxBase)TB_SearchOOB).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)TB_SearchOOB).Location = new Point(52, 382);
		((Control)TB_SearchOOB).Name = "TB_SearchOOB";
		TB_SearchOOB.PlaceholderText = "";
		((Control)TB_SearchOOB).Size = new Size(391, 31);
		((Control)TB_SearchOOB).TabIndex = 9;
		Timer1.Interval = 500;
		((Control)btnEXPCOL).Anchor = (AnchorStyles)10;
		((ButtonBase)btnEXPCOL).BackColor = Color.Transparent;
		((Control)btnEXPCOL).ForeColor = SystemColors.Control;
		((Control)btnEXPCOL).Location = new Point(449, 382);
		((Control)btnEXPCOL).Name = "btnEXPCOL";
		((Control)btnEXPCOL).Padding = new Padding(5);
		btnEXPCOL.RoundRadius = 0;
		((Control)btnEXPCOL).Size = new Size(136, 23);
		((Control)btnEXPCOL).TabIndex = 10;
		btnEXPCOL.Text = "Collapse List";
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(592, 442);
		((Control)this).Controls.Add((Control)(object)btnEXPCOL);
		((Control)this).Controls.Add((Control)(object)TB_SearchOOB);
		((Control)this).Controls.Add((Control)(object)DarkLabel1);
		((Control)this).Controls.Add((Control)(object)CB_Proficiency);
		((Control)this).Controls.Add((Control)(object)Label_SetUnitProficiency);
		((Control)this).Controls.Add((Control)(object)Label_Proficiency);
		((Control)this).Controls.Add((Control)(object)TabControl1);
		((Form)this).FormBorderStyle = (FormBorderStyle)6;
		((Form)this).KeyPreview = true;
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "ORBAT";
		((Form)this).ShowIcon = false;
		((Form)this).SizeGripStyle = (SizeGripStyle)1;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Order of Battle + Contacts";
		((Control)TabControl1).ResumeLayout(false);
		((Control)TabPage1).ResumeLayout(false);
		((Control)TabPage2).ResumeLayout(false);
		((Control)TabPage3).ResumeLayout(false);
		((Control)TabPage4).ResumeLayout(false);
		((ISupportInitialize)(object)TGV_Contacts).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void ORBAT_Load(object sender, EventArgs e)
	{
		try
		{
			Scenario.UnitAdded += method_14;
			Scenario.UnitRemoved += method_15;
			Scenario.UnitSideChanged += method_5;
			ActiveUnit_DockingOps.HostDockFacilityChanged += method_8;
			Aircraft_AirOps.HostAirFacilityChanged += method_8;
			ActiveUnit.ParentGroupChanged += method_7;
			ActiveUnit.NameChanged += method_6;
			Side.ContactAdded += method_3;
			Side.ContactRemoved += method_2;
			Side.BaseContactAdded += method_4;
			Side.BaseContactRemoved += method_2;
			Timer1.Start();
			((Control)this).Refresh();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 523253955t67", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void ORBAT_Closing(object sender, CancelEventArgs e)
	{
		try
		{
			Scenario.UnitAdded -= method_14;
			Scenario.UnitRemoved -= method_15;
			Scenario.UnitSideChanged -= method_5;
			ActiveUnit_DockingOps.HostDockFacilityChanged -= method_8;
			Aircraft_AirOps.HostAirFacilityChanged -= method_8;
			ActiveUnit.ParentGroupChanged -= method_7;
			ActiveUnit.NameChanged -= method_6;
			Side.ContactAdded -= method_3;
			Side.ContactRemoved -= method_2;
			Side.BaseContactAdded -= method_4;
			Side.BaseContactRemoved -= method_2;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 523253955t68", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_2(string string_0, string string_1)
	{
		try
		{
			if (Client.CurrentSide == null || Operators.CompareString(string_0, Client.CurrentSide.ObjectID, true) != 0)
			{
				return;
			}
			using IEnumerator<TreeGridNode> enumerator = TGV_Contacts.Nodes.GetEnumerator();
			_Closure$__102-0 closure$__102- = default(_Closure$__102-0);
			do
			{
				if (enumerator.MoveNext())
				{
					closure$__102- = new _Closure$__102-0(closure$__102-);
					closure$__102-.$VB$Me = this;
					closure$__102-.$VB$Local_theNode = enumerator.Current;
					continue;
				}
				return;
			}
			while (((DataGridViewBand)closure$__102-.$VB$Local_theNode).Tag == null || Operators.CompareString(((DataGridViewBand)closure$__102-.$VB$Local_theNode).Tag.ToString(), string_1, true) != 0);
			((Control)this).BeginInvoke((Delegate)new VB$AnonymousDelegate_0(closure$__102-._Lambda$__0));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 523253955t69", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_3(string string_0, string string_1)
	{
		try
		{
			if (Client.CurrentSide == null || Operators.CompareString(string_0, Client.CurrentSide.ObjectID, true) != 0)
			{
				return;
			}
			Contact contact = Client.CurrentSide.Contacts[string_1];
			if (contact != null)
			{
				if (contact.ActualUnit.IsGroupMember() && contact.ActualUnit.get_ParentGroup(UsingMissionPlanner: false).IsLandInstallation)
				{
					return;
				}
				((Control)this).BeginInvoke((Delegate)(VB$AnonymousDelegate_0)([SpecialName] () =>
				{
					TreeGridNode treeGridNode = TGV_Contacts.Nodes.Add();
					method_25(treeGridNode, contact);
					if (contact.ActualUnit.IsGroup && ((Group)contact.ActualUnit).IsLandInstallation)
					{
						treeGridNode.Nodes.Add("temp");
					}
				}));
			}
			else if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 523253955t70", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_4(string string_0, string string_1)
	{
		try
		{
			if (Client.CurrentSide == null || Operators.CompareString(string_0, Client.CurrentSide.ObjectID, true) != 0)
			{
				return;
			}
			Contact contact = Client.CurrentSide.BaseContacts[string_1];
			if (contact == null)
			{
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				return;
			}
			((Control)this).BeginInvoke((Delegate)(VB$AnonymousDelegate_0)([SpecialName] () =>
			{
				TreeGridNode treeGridNode = TGV_Contacts.Nodes.Add();
				method_25(treeGridNode, contact);
				treeGridNode.Nodes.Add("temp");
			}));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 523253955t71", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_5(Scenario scenario_0, string string_0, string string_1)
	{
		if (!((Control)this).InvokeRequired)
		{
			bool flag = false;
			if (scenario_0.ActiveUnits.TryGetValue(string_0, out var value))
			{
				flag = value.get_UnitSide(SetSideOnly: false) == Client.CurrentSide || scenario_0.Sides_ReadOnly.Where([SpecialName] (Side s) => Operators.CompareString(s.ObjectID, string_1, true) == 0).First() == Client.CurrentSide;
			}
			if (flag)
			{
				method_41(((TabControl)TabControl1).SelectedIndex, null);
				((Control)this).Refresh();
			}
		}
		else
		{
			((Control)this).BeginInvoke((Delegate)(VB$AnonymousDelegate_0)([SpecialName] () =>
			{
				method_5(scenario_0, string_0, string_1);
			}));
		}
	}

	private void method_6(string string_0)
	{
		try
		{
			_Closure$__106-1 closure$__106- = new _Closure$__106-1(closure$__106-);
			closure$__106-.$VB$Me = this;
			if (!((Control)this).Visible || !Client.CurrentScenario.ActiveUnits.ContainsKey(string_0))
			{
				return;
			}
			closure$__106-.$VB$Local_theAU = Client.CurrentScenario.ActiveUnits[string_0];
			if (Operators.CompareString(closure$__106-.$VB$Local_theAU.get_UnitSide(SetSideOnly: false).ObjectID, Client.CurrentSide.ObjectID, true) != 0)
			{
				return;
			}
			using IEnumerator<DarkFilterTreeNode> enumerator = Module1.AllNodes(TV_ByGroup).GetEnumerator();
			_Closure$__106-0 closure$__106-2 = default(_Closure$__106-0);
			do
			{
				if (enumerator.MoveNext())
				{
					closure$__106-2 = new _Closure$__106-0(closure$__106-2);
					closure$__106-2.$VB$NonLocal_$VB$Closure_2 = closure$__106-;
					closure$__106-2.$VB$Local_theNode = enumerator.Current;
					continue;
				}
				return;
			}
			while (closure$__106-2.$VB$Local_theNode.Tag != closure$__106-2.$VB$NonLocal_$VB$Closure_2.$VB$Local_theAU);
			((Control)this).BeginInvoke((Delegate)new VB$AnonymousDelegate_0(closure$__106-2._Lambda$__0));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 523253955t72", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_7(string string_0)
	{
		try
		{
			if (((Control)this).Visible && Client.CurrentScenario.ActiveUnits.ContainsKey(string_0))
			{
				ActiveUnit activeUnit = Client.CurrentScenario.ActiveUnits[string_0];
				if (Operators.CompareString(activeUnit.get_UnitSide(SetSideOnly: false).ObjectID, Client.CurrentSide.ObjectID, true) == 0)
				{
					method_10(activeUnit);
					method_9(activeUnit);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 523253955t73", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_8(string string_0)
	{
		ActiveUnit activeUnit = default(ActiveUnit);
		try
		{
			if (!((Control)this).Visible || !Client.CurrentScenario.ActiveUnits.ContainsKey(string_0))
			{
				return;
			}
			activeUnit = Client.CurrentScenario.ActiveUnits[string_0];
			if (Operators.CompareString(activeUnit.get_UnitSide(SetSideOnly: false).ObjectID, Client.CurrentSide.ObjectID, true) != 0)
			{
				return;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 523253955t74", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			DarkFilterTreeNode darkFilterTreeNode = null;
			foreach (DarkFilterTreeNode item in Module1.AllNodes(TV_ByGroup))
			{
				foreach (DarkFilterTreeNode node in item.Nodes)
				{
					try
					{
						if (Operators.CompareString(((ActiveUnit)node.Tag).ObjectID, string_0, true) != 0)
						{
							continue;
						}
						darkFilterTreeNode = item;
						break;
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						ProjectData.ClearProjectError();
					}
				}
			}
			ActiveUnit activeUnit2 = ((!activeUnit.IsAircraft) ? activeUnit.DockingOps.CurrentHostUnit : ((Aircraft)activeUnit).AirOps.CurrentHostUnit);
			if (!Information.IsNothing((object)darkFilterTreeNode))
			{
				string text = (Information.IsNothing((object)activeUnit2) ? string.Empty : activeUnit2.ObjectID);
				if (Operators.CompareString(((ActiveUnit)darkFilterTreeNode.Tag).ObjectID, text, true) == 0)
				{
					return;
				}
			}
			method_10(activeUnit);
			method_9(activeUnit);
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			ex4?.Data.Add("Error at 523253955t75", "");
			GameGeneral.WriteExceptionsToLog(ex4);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_9(ActiveUnit activeUnit_0)
	{
		_Closure$__110-0 closure$__110- = new _Closure$__110-0(closure$__110-);
		closure$__110-.$VB$Me = this;
		closure$__110-.$VB$Local_theAU = activeUnit_0;
		lock (lockObject_0)
		{
			_Closure$__110-1 arg = default(_Closure$__110-1);
			_Closure$__110-1 CS$<>8__locals141 = new _Closure$__110-1(arg);
			CS$<>8__locals141.$VB$NonLocal_$VB$Closure_2 = closure$__110-;
			try
			{
				CS$<>8__locals141.$VB$Local_UnitCurrentHost = (CS$<>8__locals141.$VB$NonLocal_$VB$Closure_2.$VB$Local_theAU.IsAircraft ? ((Aircraft)CS$<>8__locals141.$VB$NonLocal_$VB$Closure_2.$VB$Local_theAU).AirOps.CurrentHostUnit : CS$<>8__locals141.$VB$NonLocal_$VB$Closure_2.$VB$Local_theAU.DockingOps.CurrentHostUnit);
				foreach (DarkFilterTreeNode item in Module1.AllNodes(TV_ByGroup))
				{
					if (item.Tag != null && item.Tag == CS$<>8__locals141.$VB$NonLocal_$VB$Closure_2.$VB$Local_theAU)
					{
						return;
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 523253955t75", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			CS$<>8__locals141.$VB$Local_NewNode = null;
			if (CS$<>8__locals141.$VB$Local_UnitCurrentHost == null)
			{
				if (CS$<>8__locals141.$VB$NonLocal_$VB$Closure_2.$VB$Local_theAU.get_ParentGroup(UsingMissionPlanner: false) == null)
				{
					try
					{
						((Control)this).BeginInvoke((Delegate)(VB$AnonymousDelegate_0)([SpecialName] () =>
						{
							//IL_0078: Unknown result type (might be due to invalid IL or missing references)
							//IL_0082: Expected O, but got Unknown
							//IL_017a: Unknown result type (might be due to invalid IL or missing references)
							//IL_0184: Expected O, but got Unknown
							string text = CS$<>8__locals141.$VB$NonLocal_$VB$Closure_2.$VB$Me.method_20(CS$<>8__locals141.$VB$NonLocal_$VB$Closure_2.$VB$Local_theAU);
							if (CS$<>8__locals141.$VB$NonLocal_$VB$Closure_2.$VB$Me.TV_ByGroup.Nodes.Count != 0)
							{
								foreach (DarkFilterTreeNode node in CS$<>8__locals141.$VB$NonLocal_$VB$Closure_2.$VB$Me.TV_ByGroup.Nodes)
								{
									try
									{
										if (node.Text.CompareTo(text) > 0)
										{
											CS$<>8__locals141.$VB$Local_NewNode = new DarkFilterTreeNode();
											CS$<>8__locals141.$VB$Local_NewNode.Tag = CS$<>8__locals141.$VB$NonLocal_$VB$Closure_2.$VB$Local_theAU;
											CS$<>8__locals141.$VB$Local_NewNode.Font = new Font(((Control)CS$<>8__locals141.$VB$NonLocal_$VB$Closure_2.$VB$Me.TV_ByGroup).Font, (FontStyle)0);
											CS$<>8__locals141.$VB$Local_NewNode.ForeColor = CS$<>8__locals141.$VB$NonLocal_$VB$Closure_2.$VB$Me.GetUnitProficiencyColor(CS$<>8__locals141.$VB$NonLocal_$VB$Closure_2.$VB$Local_theAU);
											CS$<>8__locals141.$VB$Local_NewNode.Text = text;
											CS$<>8__locals141.$VB$Local_NewNode.ParentTree = CS$<>8__locals141.$VB$NonLocal_$VB$Closure_2.$VB$Me.TV_ByGroup;
											CS$<>8__locals141.$VB$NonLocal_$VB$Closure_2.$VB$Me.TV_ByGroup.Nodes.Insert(CS$<>8__locals141.$VB$NonLocal_$VB$Closure_2.$VB$Me.TV_ByGroup.Nodes.IndexOf(node), CS$<>8__locals141.$VB$Local_NewNode);
											CS$<>8__locals141.$VB$Local_NewNode.EnsureVisible();
											break;
										}
									}
									catch (Exception ex11)
									{
										ProjectData.SetProjectError(ex11);
										Exception ex12 = ex11;
										ex12?.Data.Add("Error at 523253955t751", "");
										GameGeneral.WriteExceptionsToLog(ex12);
										if (Debugger.IsAttached)
										{
											Debugger.Break();
										}
										ProjectData.ClearProjectError();
									}
								}
							}
							else
							{
								CS$<>8__locals141.$VB$Local_NewNode = new DarkFilterTreeNode();
								CS$<>8__locals141.$VB$Local_NewNode.Tag = CS$<>8__locals141.$VB$NonLocal_$VB$Closure_2.$VB$Local_theAU;
								CS$<>8__locals141.$VB$Local_NewNode.Font = new Font(((Control)CS$<>8__locals141.$VB$NonLocal_$VB$Closure_2.$VB$Me.TV_ByGroup).Font, (FontStyle)0);
								CS$<>8__locals141.$VB$Local_NewNode.ForeColor = CS$<>8__locals141.$VB$NonLocal_$VB$Closure_2.$VB$Me.GetUnitProficiencyColor(CS$<>8__locals141.$VB$NonLocal_$VB$Closure_2.$VB$Local_theAU);
								CS$<>8__locals141.$VB$Local_NewNode.Text = text;
								CS$<>8__locals141.$VB$Local_NewNode.ParentTree = CS$<>8__locals141.$VB$NonLocal_$VB$Closure_2.$VB$Me.TV_ByGroup;
								CS$<>8__locals141.$VB$NonLocal_$VB$Closure_2.$VB$Me.TV_ByGroup.Nodes.Add(CS$<>8__locals141.$VB$Local_NewNode);
								CS$<>8__locals141.$VB$Local_NewNode.EnsureVisible();
							}
							CS$<>8__locals141.$VB$NonLocal_$VB$Closure_2.$VB$Me.TV_ByGroup.UpdateNodes();
						}));
					}
					catch (Exception ex3)
					{
						ProjectData.SetProjectError(ex3);
						Exception ex4 = ex3;
						ex4?.Data.Add("Error at 523253955t76", "");
						GameGeneral.WriteExceptionsToLog(ex4);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
				}
				else
				{
					try
					{
						((Control)this).BeginInvoke((Delegate)(VB$AnonymousDelegate_0)([SpecialName] () =>
						{
							//IL_0292: Unknown result type (might be due to invalid IL or missing references)
							//IL_029c: Expected O, but got Unknown
							//IL_01dd: Unknown result type (might be due to invalid IL or missing references)
							//IL_01e7: Expected O, but got Unknown
							//IL_0104: Unknown result type (might be due to invalid IL or missing references)
							//IL_010e: Expected O, but got Unknown
							string text = CS$<>8__locals141.$VB$NonLocal_$VB$Closure_2.$VB$Me.method_20(CS$<>8__locals141.$VB$NonLocal_$VB$Closure_2.$VB$Local_theAU);
							DarkFilterTreeNode darkFilterTreeNode = Module1.AllNodes(CS$<>8__locals141.$VB$NonLocal_$VB$Closure_2.$VB$Me.TV_ByGroup).Where((CS$<>8__locals141.$VB$NonLocal_$VB$Closure_2.$I2 != null) ? CS$<>8__locals141.$VB$NonLocal_$VB$Closure_2.$I2 : (CS$<>8__locals141.$VB$NonLocal_$VB$Closure_2.$I2 = [SpecialName] (DarkFilterTreeNode theNode) => theNode.Tag == CS$<>8__locals141.$VB$NonLocal_$VB$Closure_2.$VB$Local_theAU.get_ParentGroup(UsingMissionPlanner: false))).FirstOrDefault();
							if (darkFilterTreeNode != null)
							{
								if (darkFilterTreeNode.Nodes.Count != 0)
								{
									bool flag2 = false;
									foreach (DarkFilterTreeNode node2 in darkFilterTreeNode.Nodes)
									{
										if (node2.Text.CompareTo(text) > 0)
										{
											CS$<>8__locals141.$VB$Local_NewNode = new DarkFilterTreeNode();
											CS$<>8__locals141.$VB$Local_NewNode.Tag = CS$<>8__locals141.$VB$NonLocal_$VB$Closure_2.$VB$Local_theAU;
											CS$<>8__locals141.$VB$Local_NewNode.Font = new Font(((Control)CS$<>8__locals141.$VB$NonLocal_$VB$Closure_2.$VB$Me.TV_ByGroup).Font, (FontStyle)0);
											CS$<>8__locals141.$VB$Local_NewNode.ForeColor = CS$<>8__locals141.$VB$NonLocal_$VB$Closure_2.$VB$Me.GetUnitProficiencyColor(CS$<>8__locals141.$VB$NonLocal_$VB$Closure_2.$VB$Local_theAU);
											CS$<>8__locals141.$VB$Local_NewNode.Text = text;
											CS$<>8__locals141.$VB$Local_NewNode.ParentTree = CS$<>8__locals141.$VB$NonLocal_$VB$Closure_2.$VB$Me.TV_ByGroup;
											darkFilterTreeNode.Nodes.Insert(darkFilterTreeNode.Nodes.IndexOf(node2), CS$<>8__locals141.$VB$Local_NewNode);
											CS$<>8__locals141.$VB$Local_NewNode.EnsureVisible();
											flag2 = true;
											break;
										}
									}
									if (!flag2)
									{
										CS$<>8__locals141.$VB$Local_NewNode = new DarkFilterTreeNode();
										CS$<>8__locals141.$VB$Local_NewNode.Tag = CS$<>8__locals141.$VB$NonLocal_$VB$Closure_2.$VB$Local_theAU;
										CS$<>8__locals141.$VB$Local_NewNode.Font = new Font(((Control)CS$<>8__locals141.$VB$NonLocal_$VB$Closure_2.$VB$Me.TV_ByGroup).Font, (FontStyle)0);
										CS$<>8__locals141.$VB$Local_NewNode.ForeColor = CS$<>8__locals141.$VB$NonLocal_$VB$Closure_2.$VB$Me.GetUnitProficiencyColor(CS$<>8__locals141.$VB$NonLocal_$VB$Closure_2.$VB$Local_theAU);
										CS$<>8__locals141.$VB$Local_NewNode.Text = text;
										CS$<>8__locals141.$VB$Local_NewNode.ParentTree = CS$<>8__locals141.$VB$NonLocal_$VB$Closure_2.$VB$Me.TV_ByGroup;
										darkFilterTreeNode.Nodes.Add(CS$<>8__locals141.$VB$Local_NewNode);
										CS$<>8__locals141.$VB$Local_NewNode.EnsureVisible();
									}
								}
								else
								{
									CS$<>8__locals141.$VB$Local_NewNode = new DarkFilterTreeNode();
									CS$<>8__locals141.$VB$Local_NewNode.Tag = CS$<>8__locals141.$VB$NonLocal_$VB$Closure_2.$VB$Local_theAU;
									CS$<>8__locals141.$VB$Local_NewNode.Font = new Font(((Control)CS$<>8__locals141.$VB$NonLocal_$VB$Closure_2.$VB$Me.TV_ByGroup).Font, (FontStyle)0);
									CS$<>8__locals141.$VB$Local_NewNode.ForeColor = CS$<>8__locals141.$VB$NonLocal_$VB$Closure_2.$VB$Me.GetUnitProficiencyColor(CS$<>8__locals141.$VB$NonLocal_$VB$Closure_2.$VB$Local_theAU);
									CS$<>8__locals141.$VB$Local_NewNode.Text = text;
									CS$<>8__locals141.$VB$Local_NewNode.ParentTree = CS$<>8__locals141.$VB$NonLocal_$VB$Closure_2.$VB$Me.TV_ByGroup;
									darkFilterTreeNode.Nodes.Add(CS$<>8__locals141.$VB$Local_NewNode);
								}
								CS$<>8__locals141.$VB$NonLocal_$VB$Closure_2.$VB$Me.TV_ByGroup.UpdateNodes();
							}
						}));
					}
					catch (Exception ex5)
					{
						ProjectData.SetProjectError(ex5);
						Exception ex6 = ex5;
						ex6?.Data.Add("Error at 523253955t77", "");
						GameGeneral.WriteExceptionsToLog(ex6);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
				}
			}
			else
			{
				try
				{
					((Control)this).BeginInvoke((Delegate)(VB$AnonymousDelegate_0)([SpecialName] () =>
					{
						//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
						//IL_00c3: Expected O, but got Unknown
						//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
						//IL_01b3: Expected O, but got Unknown
						//IL_0282: Unknown result type (might be due to invalid IL or missing references)
						//IL_028c: Expected O, but got Unknown
						string text = CS$<>8__locals141.$VB$NonLocal_$VB$Closure_2.$VB$Me.method_20(CS$<>8__locals141.$VB$NonLocal_$VB$Closure_2.$VB$Local_theAU);
						DarkFilterTreeNode darkFilterTreeNode = Module1.AllNodes(CS$<>8__locals141.$VB$NonLocal_$VB$Closure_2.$VB$Me.TV_ByGroup).Where((CS$<>8__locals141.$I4 != null) ? CS$<>8__locals141.$I4 : (CS$<>8__locals141.$I4 = [SpecialName] (DarkFilterTreeNode theNode) => theNode.Tag == CS$<>8__locals141.$VB$Local_UnitCurrentHost)).FirstOrDefault();
						if (darkFilterTreeNode != null)
						{
							if (darkFilterTreeNode.Nodes.Count == 0)
							{
								CS$<>8__locals141.$VB$Local_NewNode = new DarkFilterTreeNode();
								CS$<>8__locals141.$VB$Local_NewNode.Tag = CS$<>8__locals141.$VB$NonLocal_$VB$Closure_2.$VB$Local_theAU;
								CS$<>8__locals141.$VB$Local_NewNode.Font = new Font(((Control)CS$<>8__locals141.$VB$NonLocal_$VB$Closure_2.$VB$Me.TV_ByGroup).Font, (FontStyle)0);
								CS$<>8__locals141.$VB$Local_NewNode.ForeColor = CS$<>8__locals141.$VB$NonLocal_$VB$Closure_2.$VB$Me.GetUnitProficiencyColor(CS$<>8__locals141.$VB$NonLocal_$VB$Closure_2.$VB$Local_theAU);
								CS$<>8__locals141.$VB$Local_NewNode.Text = text;
								CS$<>8__locals141.$VB$Local_NewNode.ParentTree = CS$<>8__locals141.$VB$NonLocal_$VB$Closure_2.$VB$Me.TV_ByGroup;
								darkFilterTreeNode.Nodes.Add(CS$<>8__locals141.$VB$Local_NewNode);
								CS$<>8__locals141.$VB$Local_NewNode.EnsureVisible();
							}
							else
							{
								bool flag2 = false;
								foreach (DarkFilterTreeNode node3 in darkFilterTreeNode.Nodes)
								{
									if (node3.Text.CompareTo(text) > 0)
									{
										CS$<>8__locals141.$VB$Local_NewNode = new DarkFilterTreeNode();
										CS$<>8__locals141.$VB$Local_NewNode.Tag = CS$<>8__locals141.$VB$NonLocal_$VB$Closure_2.$VB$Local_theAU;
										CS$<>8__locals141.$VB$Local_NewNode.Font = new Font(((Control)CS$<>8__locals141.$VB$NonLocal_$VB$Closure_2.$VB$Me.TV_ByGroup).Font, (FontStyle)0);
										CS$<>8__locals141.$VB$Local_NewNode.ForeColor = CS$<>8__locals141.$VB$NonLocal_$VB$Closure_2.$VB$Me.GetUnitProficiencyColor(CS$<>8__locals141.$VB$NonLocal_$VB$Closure_2.$VB$Local_theAU);
										CS$<>8__locals141.$VB$Local_NewNode.Text = text;
										CS$<>8__locals141.$VB$Local_NewNode.ParentTree = CS$<>8__locals141.$VB$NonLocal_$VB$Closure_2.$VB$Me.TV_ByGroup;
										darkFilterTreeNode.Nodes.Insert(darkFilterTreeNode.Nodes.IndexOf(node3), CS$<>8__locals141.$VB$Local_NewNode);
										CS$<>8__locals141.$VB$Local_NewNode.EnsureVisible();
										flag2 = true;
										break;
									}
								}
								if (!flag2)
								{
									CS$<>8__locals141.$VB$Local_NewNode = new DarkFilterTreeNode();
									CS$<>8__locals141.$VB$Local_NewNode.Tag = CS$<>8__locals141.$VB$NonLocal_$VB$Closure_2.$VB$Local_theAU;
									CS$<>8__locals141.$VB$Local_NewNode.Font = new Font(((Control)CS$<>8__locals141.$VB$NonLocal_$VB$Closure_2.$VB$Me.TV_ByGroup).Font, (FontStyle)0);
									CS$<>8__locals141.$VB$Local_NewNode.ForeColor = CS$<>8__locals141.$VB$NonLocal_$VB$Closure_2.$VB$Me.GetUnitProficiencyColor(CS$<>8__locals141.$VB$NonLocal_$VB$Closure_2.$VB$Local_theAU);
									CS$<>8__locals141.$VB$Local_NewNode.Text = text;
									CS$<>8__locals141.$VB$Local_NewNode.ParentTree = CS$<>8__locals141.$VB$NonLocal_$VB$Closure_2.$VB$Me.TV_ByGroup;
									darkFilterTreeNode.Nodes.Add(CS$<>8__locals141.$VB$Local_NewNode);
									CS$<>8__locals141.$VB$Local_NewNode.EnsureVisible();
								}
							}
							CS$<>8__locals141.$VB$NonLocal_$VB$Closure_2.$VB$Me.TV_ByGroup.UpdateNodes();
						}
					}));
				}
				catch (Exception ex7)
				{
					ProjectData.SetProjectError(ex7);
					Exception ex8 = ex7;
					ex8?.Data.Add("Error at 523253955t78", "");
					GameGeneral.WriteExceptionsToLog(ex8);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
			try
			{
				if (CS$<>8__locals141.$VB$Local_NewNode == null || !CS$<>8__locals141.$VB$NonLocal_$VB$Closure_2.$VB$Local_theAU.IsGroup)
				{
					return;
				}
				foreach (ActiveUnit value in ((Group)CS$<>8__locals141.$VB$NonLocal_$VB$Closure_2.$VB$Local_theAU).Units.Values)
				{
					bool flag = false;
					foreach (DarkFilterTreeNode item2 in Module1.AllNodes(TV_ByGroup))
					{
						try
						{
							if (Operators.CompareString(((ActiveUnit)item2.Tag).ObjectID, value.ObjectID, true) == 0)
							{
								flag = true;
								break;
							}
						}
						catch (Exception projectError)
						{
							ProjectData.SetProjectError(projectError);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
					}
					if (!flag)
					{
						method_10(value);
						method_9(value);
					}
				}
				((Control)this).BeginInvoke((Delegate)(VB$AnonymousDelegate_0)([SpecialName] () =>
				{
					CS$<>8__locals141.$VB$Local_NewNode.Expanded = true;
					CS$<>8__locals141.$VB$NonLocal_$VB$Closure_2.$VB$Me.TV_ByGroup.UpdateNodes();
				}));
			}
			catch (Exception ex9)
			{
				ProjectData.SetProjectError(ex9);
				Exception ex10 = ex9;
				ex10?.Data.Add("Error at 523253955t79", "");
				GameGeneral.WriteExceptionsToLog(ex10);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	private void method_10(ActiveUnit activeUnit_0)
	{
		try
		{
			_Closure$__111-0 arg = default(_Closure$__111-0);
			_Closure$__111-0 CS$<>8__locals9 = new _Closure$__111-0(arg);
			CS$<>8__locals9.$VB$Me = this;
			foreach (DarkFilterTreeNode item in Module1.AllNodes(TV_ByGroup))
			{
				if (item.Tag == activeUnit_0)
				{
					CS$<>8__locals9.$VB$Local_NodeToRemove = item;
					break;
				}
			}
			if (Information.IsNothing((object)CS$<>8__locals9.$VB$Local_NodeToRemove))
			{
				return;
			}
			((Control)this).BeginInvoke((Delegate)(VB$AnonymousDelegate_0)([SpecialName] () =>
			{
				if (Information.IsNothing((object)CS$<>8__locals9.$VB$Local_NodeToRemove.ParentNode))
				{
					CS$<>8__locals9.$VB$Me.TV_ByGroup.Nodes.Remove(CS$<>8__locals9.$VB$Local_NodeToRemove);
				}
				else
				{
					CS$<>8__locals9.$VB$Local_NodeToRemove.ParentNode.Nodes.Remove(CS$<>8__locals9.$VB$Local_NodeToRemove);
				}
				CS$<>8__locals9.$VB$Me.TV_ByGroup.UpdateNodes();
			}));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 523253955t80", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_11(ActiveUnit activeUnit_0)
	{
		_Closure$__112-0 arg = default(_Closure$__112-0);
		_Closure$__112-0 CS$<>8__locals9 = new _Closure$__112-0(arg);
		CS$<>8__locals9.$VB$Me = this;
		try
		{
			foreach (DarkFilterTreeNode item in Module1.AllNodes(TV_ByMission))
			{
				if (item.Tag == activeUnit_0)
				{
					CS$<>8__locals9.$VB$Local_NodeToRemove = item;
					break;
				}
			}
			if (Information.IsNothing((object)CS$<>8__locals9.$VB$Local_NodeToRemove))
			{
				return;
			}
			((Control)this).BeginInvoke((Delegate)(VB$AnonymousDelegate_0)([SpecialName] () =>
			{
				if (!Information.IsNothing((object)CS$<>8__locals9.$VB$Local_NodeToRemove.ParentNode))
				{
					CS$<>8__locals9.$VB$Local_NodeToRemove.ParentNode.Nodes.Remove(CS$<>8__locals9.$VB$Local_NodeToRemove);
				}
				else
				{
					CS$<>8__locals9.$VB$Me.TV_ByMission.Nodes.Remove(CS$<>8__locals9.$VB$Local_NodeToRemove);
				}
				CS$<>8__locals9.$VB$Me.TV_ByMission.UpdateNodes();
			}));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 523253955t81", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_12(ActiveUnit activeUnit_0)
	{
		_Closure$__114-0 arg = default(_Closure$__114-0);
		_Closure$__114-0 CS$<>8__locals25 = new _Closure$__114-0(arg);
		CS$<>8__locals25.$VB$Me = this;
		CS$<>8__locals25.$VB$Local_theAU = activeUnit_0;
		lock (lockObject_1)
		{
			try
			{
				foreach (DarkFilterTreeNode item in Module1.AllNodes(TV_ByType))
				{
					if (item.Tag != null && item.Tag == CS$<>8__locals25.$VB$Local_theAU)
					{
						return;
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 523253955t81", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			try
			{
				((Control)this).BeginInvoke((Delegate)(VB$AnonymousDelegate_0)([SpecialName] () =>
				{
					//IL_0089: Unknown result type (might be due to invalid IL or missing references)
					//IL_0093: Expected O, but got Unknown
					//IL_019b: Unknown result type (might be due to invalid IL or missing references)
					//IL_01a5: Expected O, but got Unknown
					//IL_0130: Unknown result type (might be due to invalid IL or missing references)
					//IL_013a: Expected O, but got Unknown
					DarkFilterTreeNode darkFilterTreeNode = null;
					string text = CS$<>8__locals25.$VB$Me.method_20(CS$<>8__locals25.$VB$Local_theAU);
					bool flag = false;
					DarkFilterTreeNode darkFilterTreeNode2 = Module1.AllNodes(CS$<>8__locals25.$VB$Me.TV_ByType).Where((CS$<>8__locals25.$I1 != null) ? CS$<>8__locals25.$I1 : (CS$<>8__locals25.$I1 = [SpecialName] (DarkFilterTreeNode theNode) => theNode.Tag.GetType().IsPrimitive && Conversions.ToInteger(theNode.Tag) == (int)CS$<>8__locals25.$VB$Local_theAU.UnitType)).FirstOrDefault();
					if (darkFilterTreeNode2 == null)
					{
						darkFilterTreeNode2 = new DarkFilterTreeNode
						{
							Tag = (int)CS$<>8__locals25.$VB$Local_theAU.UnitType,
							Font = new Font(((Control)CS$<>8__locals25.$VB$Me.TV_ByType).Font, (FontStyle)0),
							ForeColor = Color.White,
							Text = CS$<>8__locals25.$VB$Local_theAU.UnitType_String,
							ParentTree = CS$<>8__locals25.$VB$Me.TV_ByType
						};
						flag = true;
					}
					DarkFilterTreeNode darkFilterTreeNode3 = darkFilterTreeNode2.Nodes.Where([SpecialName] (DarkFilterTreeNode theNode) => theNode.Tag.GetType().IsPrimitive && Conversions.ToInteger(theNode.Tag) == CS$<>8__locals25.$VB$Local_theAU.SubType).FirstOrDefault();
					if (darkFilterTreeNode3 == null)
					{
						darkFilterTreeNode3 = new DarkFilterTreeNode
						{
							Tag = CS$<>8__locals25.$VB$Local_theAU.SubType,
							Font = new Font(((Control)CS$<>8__locals25.$VB$Me.TV_ByType).Font, (FontStyle)0),
							ForeColor = Color.White,
							Text = CS$<>8__locals25.$VB$Local_theAU.SubTypeDescription,
							ParentTree = CS$<>8__locals25.$VB$Me.TV_ByType
						};
						darkFilterTreeNode2.Nodes.Add(darkFilterTreeNode3);
					}
					darkFilterTreeNode = new DarkFilterTreeNode
					{
						Tag = CS$<>8__locals25.$VB$Local_theAU,
						Font = new Font(((Control)CS$<>8__locals25.$VB$Me.TV_ByType).Font, (FontStyle)0),
						ForeColor = CS$<>8__locals25.$VB$Me.GetUnitProficiencyColor(CS$<>8__locals25.$VB$Local_theAU),
						Text = text,
						ParentTree = CS$<>8__locals25.$VB$Me.TV_ByType
					};
					darkFilterTreeNode3.Nodes.Add(darkFilterTreeNode);
					if (flag)
					{
						CS$<>8__locals25.$VB$Me.TV_ByType.Nodes.Add(darkFilterTreeNode2);
						darkFilterTreeNode2.EnsureVisible();
					}
				}));
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				ex4?.Data.Add("Error at 523253955t82", "");
				GameGeneral.WriteExceptionsToLog(ex4);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	private void method_13(ActiveUnit activeUnit_0)
	{
		lock (lockObject_1)
		{
			_Closure$__115-0 arg = default(_Closure$__115-0);
			_Closure$__115-0 CS$<>8__locals9 = new _Closure$__115-0(arg);
			CS$<>8__locals9.$VB$Me = this;
			try
			{
				foreach (DarkFilterTreeNode item in Module1.AllNodes(TV_ByType))
				{
					if (item.Tag == activeUnit_0)
					{
						CS$<>8__locals9.$VB$Local_NodeToRemove = item;
						break;
					}
				}
				if (Information.IsNothing((object)CS$<>8__locals9.$VB$Local_NodeToRemove))
				{
					return;
				}
				((Control)this).BeginInvoke((Delegate)(VB$AnonymousDelegate_0)([SpecialName] () =>
				{
					if (Information.IsNothing((object)CS$<>8__locals9.$VB$Local_NodeToRemove.ParentNode))
					{
						CS$<>8__locals9.$VB$Me.TV_ByType.Nodes.Remove(CS$<>8__locals9.$VB$Local_NodeToRemove);
					}
					else
					{
						CS$<>8__locals9.$VB$Local_NodeToRemove.ParentNode.Nodes.Remove(CS$<>8__locals9.$VB$Local_NodeToRemove);
					}
					CS$<>8__locals9.$VB$Me.TV_ByType.UpdateNodes();
				}));
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 523253955t83", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	private void method_14(Scenario scenario_0, string string_0)
	{
		try
		{
			if (((Control)this).InvokeRequired)
			{
				((Control)this).BeginInvoke((Delegate)(VB$AnonymousDelegate_0)([SpecialName] () =>
				{
					method_14(scenario_0, string_0);
				}));
			}
			else
			{
				if (!((Control)this).Visible || !Client.CurrentScenario.ActiveUnits.ContainsKey(string_0))
				{
					return;
				}
				ActiveUnit activeUnit = Client.CurrentScenario.ActiveUnits[string_0];
				if (Operators.CompareString(activeUnit.get_UnitSide(SetSideOnly: false).ObjectID, Client.CurrentSide.ObjectID, true) == 0)
				{
					if (!activeUnit.IsAircraft)
					{
						_ = activeUnit.DockingOps.CurrentHostUnit;
					}
					else
					{
						_ = ((Aircraft)activeUnit).AirOps.CurrentHostUnit;
					}
					method_9(activeUnit);
					method_12(activeUnit);
					((Control)this).Refresh();
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 523253955t84", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_15(Scenario scenario_0, ActiveUnit activeUnit_0)
	{
		try
		{
			if (!((Control)this).InvokeRequired)
			{
				if (((Control)this).Visible)
				{
					method_10(activeUnit_0);
					method_11(activeUnit_0);
					method_13(activeUnit_0);
					((Control)this).Refresh();
				}
			}
			else
			{
				((Control)this).BeginInvoke((Delegate)(VB$AnonymousDelegate_0)([SpecialName] () =>
				{
					method_15(scenario_0, activeUnit_0);
				}));
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 523253955t85", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void ReleaseReferences()
	{
		try
		{
			((Form)this).Close();
			TV_ByGroup.Nodes.Clear();
			TV_ByMission.Nodes.Clear();
			TV_ByType.Nodes.Clear();
			TGV_Contacts.Nodes.Clear();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 523253955t86", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void BuildWindow()
	{
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		try
		{
			switch (((TabControl)TabControl1).SelectedIndex)
			{
			case 0:
				method_21();
				((Control)TV_ByGroup).MouseDoubleClick += new MouseEventHandler(method_16);
				break;
			case 1:
				method_22();
				break;
			case 2:
				method_23();
				break;
			case 3:
				method_24();
				break;
			}
			if (Client.CurrentSide != null)
			{
				((Label)Label_Proficiency).Text = Misc.ToEnglishString(Client.CurrentSide.Proficiency);
			}
			((Control)Label_SetUnitProficiency).Visible = Client.AllowEditModeActions;
			((Control)CB_Proficiency).Visible = Client.AllowEditModeActions;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 523253955t87", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_16(object sender, MouseEventArgs e)
	{
		ActiveUnit theAU = null;
		try
		{
			sender.ToString();
			if (sender.GetType() == typeof(DarkFilterTreeView))
			{
				theAU = (ActiveUnit)((DarkFilterTreeView)sender).SelectedNodes[0].Tag;
			}
			if (sender.GetType() == typeof(DarkTreeGridView))
			{
				theAU = (ActiveUnit)((DataGridViewBand)((DarkTreeGridView)sender).CurrentNode).Tag;
			}
			if (Client.SelectedUnit != null)
			{
				if (Client.SelectedUnit.IsActiveUnit)
				{
					theAU = (ActiveUnit)Client.SelectedUnit;
				}
				if (Client.SelectedUnit.IsContact())
				{
					theAU = ((Contact)Client.SelectedUnit).ActualUnit;
				}
				if (Client.SelectedUnit.IsGroup && ((Group)Client.SelectedUnit).Type == Group.GroupType.AirGroup)
				{
					theAU = ((Group)Client.SelectedUnit).Units.Values.ElementAtOrDefault(0);
				}
				Client.smethod_18(theAU);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 523253955t88", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	[SpecialName]
	private ReadOnlyCollection<DarkFilterTreeNode> method_17()
	{
		List<DarkFilterTreeNode> list = new List<DarkFilterTreeNode>();
		foreach (DarkFilterTreeNode node in TV_ByGroup.Nodes)
		{
			if (!list.Contains(node))
			{
				list.Add(node);
			}
			method_18(node, list);
		}
		return list.AsReadOnly();
	}

	private void method_18(DarkFilterTreeNode darkFilterTreeNode_0, List<DarkFilterTreeNode> list_0)
	{
		try
		{
			foreach (DarkFilterTreeNode node in darkFilterTreeNode_0.Nodes)
			{
				if (!list_0.Contains(node))
				{
					list_0.Add(node);
				}
				method_18(node, list_0);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 523253955t89", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_19(ActiveUnit activeUnit_0, bool bool_11)
	{
		try
		{
			if (activeUnit_0.get_UnitSide(SetSideOnly: false) != Client.CurrentSide)
			{
				return;
			}
			using IEnumerator<DarkFilterTreeNode> enumerator = method_17().GetEnumerator();
			DarkFilterTreeNode current;
			do
			{
				if (enumerator.MoveNext())
				{
					current = enumerator.Current;
					continue;
				}
				return;
			}
			while (current.Tag != activeUnit_0);
			if (!Information.IsNothing((object)current.ParentNode))
			{
				current.ParentNode.Nodes.Remove(current);
			}
			else
			{
				TV_ByGroup.Nodes.Remove(current);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 523253955t90", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public Color GetUnitProficiencyColor(ActiveUnit theAU)
	{
		Color result = default(Color);
		try
		{
			if (theAU.IsGroup)
			{
				result = Color.LightGray;
				return result;
			}
			GlobalVariables.ProficiencyLevel? proficiency = theAU.Proficiency;
			int? num = (int?)proficiency;
			if (((!num.HasValue) ? ((bool?)null) : new bool?(num.GetValueOrDefault() == 0)) == true)
			{
				result = Color.Cyan;
				return result;
			}
			num = (int?)proficiency;
			if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 1)) == true)
			{
				result = Color.Lime;
				return result;
			}
			num = (int?)proficiency;
			if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 2)) == true)
			{
				result = Color.Yellow;
				return result;
			}
			num = (int?)proficiency;
			if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 3)) == true)
			{
				result = Color.Orange;
				return result;
			}
			num = (int?)proficiency;
			if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 4)) == true)
			{
				result = Color.IndianRed;
				return result;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 523253955t91", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private string method_20(ActiveUnit activeUnit_0)
	{
		string result = default(string);
		try
		{
			string text;
			if (!activeUnit_0.IsAircraft)
			{
				text = "";
			}
			else
			{
				Aircraft aircraft = (Aircraft)activeUnit_0;
				text = ((!Information.IsNothing((object)aircraft.Loadout)) ? (" , " + aircraft.Loadout.Name) : "");
			}
			string text2 = activeUnit_0.Name;
			if (!activeUnit_0.IsGroup)
			{
				text2 = text2 + " (" + Misc.RemoveHiddenString(activeUnit_0.UnitClass) + text + ")";
			}
			result = text2;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 523253955t92", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private void method_21()
	{
		//IL_03bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c7: Expected O, but got Unknown
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_016c: Expected O, but got Unknown
		//IL_0481: Unknown result type (might be due to invalid IL or missing references)
		//IL_048b: Expected O, but got Unknown
		//IL_0226: Unknown result type (might be due to invalid IL or missing references)
		//IL_0230: Expected O, but got Unknown
		//IL_0558: Unknown result type (might be due to invalid IL or missing references)
		//IL_0562: Expected O, but got Unknown
		//IL_02fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0307: Expected O, but got Unknown
		TV_ByGroup.Nodes.Clear();
		List<ActiveUnit> list = Client.CurrentSide.Units.Select([SpecialName] (ActiveUnit theAU) => theAU).OrderBy([SpecialName] (ActiveUnit theActU) => theActU.Name, new NaturalSortComparer<string[]>()).ToList();
		foreach (ActiveUnit item in list)
		{
			try
			{
				DarkFilterTreeNode darkFilterTreeNode2;
				IEnumerable<ActiveUnit> enumerable;
				IEnumerable<Aircraft> enumerable2;
				if (item.IsGroup)
				{
					DarkFilterTreeNode darkFilterTreeNode = new DarkFilterTreeNode(item.Name);
					darkFilterTreeNode.Tag = item;
					List<ActiveUnit> list2 = ((Group)item).Units.Values.Select([SpecialName] (ActiveUnit theAU) => theAU).OrderBy([SpecialName] (ActiveUnit theActU) => theActU.Name, new NaturalSortComparer<string[]>()).ToList();
					foreach (ActiveUnit item2 in list2)
					{
						darkFilterTreeNode2 = new DarkFilterTreeNode(method_20(item2));
						darkFilterTreeNode.Nodes.Add(darkFilterTreeNode2);
						darkFilterTreeNode2.Font = new Font(((Control)TV_ByGroup).Font, (FontStyle)0);
						darkFilterTreeNode2.ForeColor = GetUnitProficiencyColor(item2);
						darkFilterTreeNode2.Tag = item2;
						enumerable = from theAU in item2.DockingOps.EmbarkedBoats_ReadOnly.OrderBy([SpecialName] (ActiveUnit theActU) => theActU.Name, new NaturalSortComparer<string[]>())
							select (theAU);
						foreach (ActiveUnit item3 in enumerable)
						{
							DarkFilterTreeNode darkFilterTreeNode3 = new DarkFilterTreeNode(method_20(item3));
							darkFilterTreeNode2.Nodes.Add(darkFilterTreeNode3);
							darkFilterTreeNode3.Font = new Font(((Control)TV_ByGroup).Font, (FontStyle)0);
							darkFilterTreeNode3.ForeColor = GetUnitProficiencyColor(item3);
							darkFilterTreeNode3.Tag = item3;
						}
						enumerable2 = from theAC in item2.AirOps.EmbarkedAircraft_ReadOnly.OrderBy([SpecialName] (Aircraft theActU) => theActU.Name, new NaturalSortComparer<string[]>())
							select (theAC);
						foreach (Aircraft item4 in enumerable2)
						{
							DarkFilterTreeNode darkFilterTreeNode3 = new DarkFilterTreeNode(method_20(item4));
							darkFilterTreeNode2.Nodes.Add(darkFilterTreeNode3);
							darkFilterTreeNode3.Font = new Font(((Control)TV_ByGroup).Font, (FontStyle)0);
							darkFilterTreeNode3.ForeColor = GetUnitProficiencyColor(item4);
							darkFilterTreeNode3.Tag = item4;
						}
						darkFilterTreeNode2.Expanded = true;
					}
					darkFilterTreeNode.Expanded = true;
					TV_ByGroup.Nodes.Add(darkFilterTreeNode);
				}
				if (!item.IsOperating() || !item.IsPlatform || item.IsGroup || item.IsGroupMember())
				{
					continue;
				}
				darkFilterTreeNode2 = new DarkFilterTreeNode(method_20(item));
				darkFilterTreeNode2.Font = new Font(((Control)TV_ByGroup).Font, (FontStyle)0);
				darkFilterTreeNode2.ForeColor = GetUnitProficiencyColor(item);
				darkFilterTreeNode2.Tag = item;
				enumerable = from theAU in item.DockingOps.EmbarkedBoats_ReadOnly.OrderBy([SpecialName] (ActiveUnit theActU) => theActU.Name, new NaturalSortComparer<string[]>())
					select (theAU);
				foreach (ActiveUnit item5 in enumerable)
				{
					DarkFilterTreeNode darkFilterTreeNode3 = new DarkFilterTreeNode(method_20(item5));
					darkFilterTreeNode2.Nodes.Add(darkFilterTreeNode3);
					darkFilterTreeNode3.Font = new Font(((Control)TV_ByGroup).Font, (FontStyle)0);
					darkFilterTreeNode3.ForeColor = GetUnitProficiencyColor(item5);
					darkFilterTreeNode3.Tag = item5;
				}
				enumerable2 = from theAC in item.AirOps.EmbarkedAircraft_ReadOnly.OrderBy([SpecialName] (Aircraft theActU) => theActU.Name, new NaturalSortComparer<string[]>())
					select (theAC);
				foreach (Aircraft item6 in enumerable2)
				{
					DarkFilterTreeNode darkFilterTreeNode3 = new DarkFilterTreeNode(method_20(item6));
					darkFilterTreeNode2.Nodes.Add(darkFilterTreeNode3);
					darkFilterTreeNode3.Font = new Font(((Control)TV_ByGroup).Font, (FontStyle)0);
					darkFilterTreeNode3.ForeColor = GetUnitProficiencyColor(item6);
					darkFilterTreeNode3.Tag = item6;
				}
				darkFilterTreeNode2.Expanded = true;
				TV_ByGroup.Nodes.Add(darkFilterTreeNode2);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 523253955t93", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	private void method_22()
	{
		//IL_0d22: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d2c: Expected O, but got Unknown
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Expected O, but got Unknown
		TV_ByMission.Nodes.Clear();
		if (Information.IsNothing((object)Client.CurrentSide))
		{
			return;
		}
		IEnumerable<Mission> enumerable = from theM in Client.CurrentSide.get_MissionsTotal(Client.CurrentScenario)
			orderby theM.Name
			select theM;
		foreach (Mission item in enumerable)
		{
			if (item.Category != Mission.MissionCategory.Mission)
			{
				if (item.Category != Mission.MissionCategory.TaskPool)
				{
					continue;
				}
				DarkFilterTreeNode darkFilterTreeNode = new DarkFilterTreeNode(item.Name);
				TV_ByMission.Nodes.Add(darkFilterTreeNode);
				darkFilterTreeNode.ForeColor = Color.LightGreen;
				darkFilterTreeNode.Tag = item;
				List<Aircraft> list = new List<Aircraft>();
				List<ActiveUnit> list2 = new List<ActiveUnit>();
				foreach (ActiveUnit unit in Client.CurrentSide.Units)
				{
					try
					{
						if (!(unit.IsGroupMember() | (unit.IsWeapon && ((Weapon)unit).Type == Weapon._WeaponType.Sonobuoy)) && Information.IsNothing((object)unit.ActiveMissionOrPackage()) && unit.AssignedTaskPool == item)
						{
							if (unit.IsAircraft)
							{
								list.Add((Aircraft)unit);
							}
							else if (!unit.IsSubmarine || !((Submarine)unit).IsTetheredROV)
							{
								list2.Add(unit);
							}
						}
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						ex2?.Data.Add("Error at 523253955t99", "");
						GameGeneral.WriteExceptionsToLog(ex2);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
				}
				TaskPool taskPool = (TaskPool)item;
				foreach (Mission package in taskPool.PackageList)
				{
					DarkFilterTreeNode darkFilterTreeNode2 = new DarkFilterTreeNode(package.Name);
					try
					{
						darkFilterTreeNode.Nodes.Add(darkFilterTreeNode2);
						if (package.IsActive)
						{
							darkFilterTreeNode2.ForeColor = Color.LightGreen;
						}
						else
						{
							darkFilterTreeNode2.ForeColor = Color.IndianRed;
							darkFilterTreeNode2.Font = new Font(((Control)this).Font, (FontStyle)2);
						}
						darkFilterTreeNode2.Tag = package;
					}
					catch (Exception ex3)
					{
						ProjectData.SetProjectError(ex3);
						Exception ex4 = ex3;
						ex4?.Data.Add("Error at 523253955y00", "");
						GameGeneral.WriteExceptionsToLog(ex4);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
					List<Aircraft> list3 = new List<Aircraft>();
					List<Aircraft> list4 = new List<Aircraft>();
					List<ActiveUnit> list5 = new List<ActiveUnit>();
					foreach (ActiveUnit unit2 in Client.CurrentSide.Units)
					{
						try
						{
							if ((unit2.IsGroupMember() | (unit2.IsWeapon && ((Weapon)unit2).Type == Weapon._WeaponType.Sonobuoy)) || unit2.ActiveMissionOrPackage() != package)
							{
								continue;
							}
							if (unit2.IsAircraft)
							{
								if (!Information.IsNothing((object)unit2.Navigator.get_Flight(HierarchySearch: true)))
								{
									if (unit2.IsGroupMember())
									{
										if (!Information.IsNothing((object)unit2.get_ParentGroup(UsingMissionPlanner: false)) && !list5.Contains(unit2.get_ParentGroup(UsingMissionPlanner: false)))
										{
											list5.Add(unit2.get_ParentGroup(UsingMissionPlanner: false));
										}
									}
									else
									{
										list4.Add((Aircraft)unit2);
									}
								}
								else if (!unit2.IsGroupMember())
								{
									list3.Add((Aircraft)unit2);
								}
								else if (!Information.IsNothing((object)unit2.get_ParentGroup(UsingMissionPlanner: false)) && !list5.Contains(unit2.get_ParentGroup(UsingMissionPlanner: false)))
								{
									list5.Add(unit2.get_ParentGroup(UsingMissionPlanner: false));
								}
							}
							else if (!unit2.IsSubmarine || !((Submarine)unit2).IsTetheredROV)
							{
								list5.Add(unit2);
							}
						}
						catch (Exception ex5)
						{
							ProjectData.SetProjectError(ex5);
							Exception ex6 = ex5;
							ex6?.Data.Add("Error at 523253955y01", "");
							GameGeneral.WriteExceptionsToLog(ex6);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
					}
					IEnumerable<Aircraft> enumerable2 = from theAC in list3
						orderby theAC.UnitClass, method_26(theAC)
						select theAC;
					List<Aircraft> list6 = list4.Select([SpecialName] (Aircraft theAC) => theAC).OrderBy([SpecialName] (Aircraft theAirc) => ((ActiveUnit_Navigator)theAirc.Navigator).get_Flight(HierarchySearch: true).Callsign, new NaturalSortComparer<string[]>()).ToList();
					IEnumerable<ActiveUnit> enumerable3 = list5.OrderBy([SpecialName] (ActiveUnit theAU) => theAU.Name);
					foreach (Aircraft item2 in enumerable2)
					{
						try
						{
							DarkFilterTreeNode darkFilterTreeNode3 = null;
							string unitClass = item2.UnitClass;
							foreach (DarkFilterTreeNode node in darkFilterTreeNode2.Nodes)
							{
								if (Operators.CompareString(node.Tag.ToString(), unitClass, true) == 0)
								{
									darkFilterTreeNode3 = node;
								}
							}
							if (Information.IsNothing((object)darkFilterTreeNode3))
							{
								darkFilterTreeNode3 = new DarkFilterTreeNode(item2.UnitClass);
								darkFilterTreeNode2.Nodes.Add(darkFilterTreeNode3);
								darkFilterTreeNode3.Tag = unitClass;
							}
							string text = method_27(item2);
							DarkFilterTreeNode darkFilterTreeNode4 = new DarkFilterTreeNode(text);
							darkFilterTreeNode3.Nodes.Add(darkFilterTreeNode4);
							darkFilterTreeNode4.Tag = item2;
							darkFilterTreeNode4.ForeColor = GetUnitProficiencyColor(item2);
							darkFilterTreeNode3.Text = Conversions.ToString(darkFilterTreeNode3.Nodes.Count) + "x " + Misc.RemoveHiddenString(Conversions.ToString(darkFilterTreeNode3.Tag));
							darkFilterTreeNode3 = null;
						}
						catch (Exception ex7)
						{
							ProjectData.SetProjectError(ex7);
							Exception ex8 = ex7;
							ex8?.Data.Add("Error at 523253955y02", "");
							GameGeneral.WriteExceptionsToLog(ex8);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
					}
					foreach (ActiveUnit item3 in enumerable3)
					{
						string name = item3.Name;
						try
						{
							string text2 = ((!string.IsNullOrEmpty(item3.UnitClass)) ? (name + " (" + Misc.RemoveHiddenString(item3.UnitClass) + ")") : name);
							DarkFilterTreeNode darkFilterTreeNode5 = new DarkFilterTreeNode(text2);
							darkFilterTreeNode2.Nodes.Add(darkFilterTreeNode5);
							darkFilterTreeNode5.Tag = item3;
							if (item3.IsGroup)
							{
								foreach (ActiveUnit value in ((Group)item3).Units.Values)
								{
									DarkFilterTreeNode darkFilterTreeNode6 = new DarkFilterTreeNode(value.Name + " (" + Misc.RemoveHiddenString(value.UnitClass) + ")");
									darkFilterTreeNode5.Nodes.Add(darkFilterTreeNode6);
									darkFilterTreeNode6.ForeColor = GetUnitProficiencyColor(value);
									darkFilterTreeNode6.Tag = value;
								}
							}
							else
							{
								darkFilterTreeNode5.ForeColor = GetUnitProficiencyColor(item3);
							}
						}
						catch (Exception ex9)
						{
							ProjectData.SetProjectError(ex9);
							Exception ex10 = ex9;
							ex10?.Data.Add("Error at 523253955y02", "");
							GameGeneral.WriteExceptionsToLog(ex10);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
					}
					foreach (Aircraft item4 in list6)
					{
						try
						{
							DarkFilterTreeNode darkFilterTreeNode7 = null;
							string callsign = ((ActiveUnit_Navigator)item4.Navigator).get_Flight(HierarchySearch: true).Callsign;
							foreach (DarkFilterTreeNode node2 in darkFilterTreeNode2.Nodes)
							{
								if (Operators.CompareString(node2.Tag.ToString(), callsign, true) == 0)
								{
									darkFilterTreeNode7 = node2;
								}
							}
							if (Information.IsNothing((object)darkFilterTreeNode7))
							{
								darkFilterTreeNode7 = new DarkFilterTreeNode(item4.UnitClass);
								darkFilterTreeNode2.Nodes.Add(darkFilterTreeNode7);
								darkFilterTreeNode7.Tag = callsign;
							}
							string text3 = method_27(item4);
							DarkFilterTreeNode darkFilterTreeNode8 = new DarkFilterTreeNode(text3);
							darkFilterTreeNode7.Nodes.Add(darkFilterTreeNode8);
							darkFilterTreeNode8.Tag = item4;
							darkFilterTreeNode8.ForeColor = GetUnitProficiencyColor(item4);
							darkFilterTreeNode7.Text = "Flight " + callsign + " (" + Conversions.ToString(darkFilterTreeNode7.Nodes.Count) + "x " + Misc.RemoveHiddenString(item4.UnitClass) + ")";
							darkFilterTreeNode7 = null;
						}
						catch (Exception ex11)
						{
							ProjectData.SetProjectError(ex11);
							Exception ex12 = ex11;
							ex12?.Data.Add("Error at 523253955y03", "");
							GameGeneral.WriteExceptionsToLog(ex12);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
					}
					darkFilterTreeNode2.Expanded = true;
				}
				IEnumerable<Aircraft> enumerable4 = from theAC in list
					orderby theAC.UnitClass, method_26(theAC)
					select theAC;
				IEnumerable<ActiveUnit> enumerable5 = list2.OrderBy([SpecialName] (ActiveUnit theAU) => theAU.Name);
				foreach (Aircraft item5 in enumerable4)
				{
					try
					{
						DarkFilterTreeNode darkFilterTreeNode9 = null;
						string unitClass2 = item5.UnitClass;
						foreach (DarkFilterTreeNode node3 in darkFilterTreeNode.Nodes)
						{
							if (Operators.CompareString(node3.Tag.ToString(), unitClass2, true) == 0)
							{
								darkFilterTreeNode9 = node3;
							}
						}
						if (Information.IsNothing((object)darkFilterTreeNode9))
						{
							darkFilterTreeNode9 = new DarkFilterTreeNode(item5.UnitClass);
							darkFilterTreeNode.Nodes.Add(darkFilterTreeNode9);
							darkFilterTreeNode9.Tag = unitClass2;
						}
						string text4 = method_27(item5);
						DarkFilterTreeNode darkFilterTreeNode10 = new DarkFilterTreeNode(text4);
						darkFilterTreeNode9.Nodes.Add(darkFilterTreeNode10);
						darkFilterTreeNode10.Tag = item5;
						darkFilterTreeNode10.ForeColor = GetUnitProficiencyColor(item5);
						darkFilterTreeNode9.Text = Conversions.ToString(darkFilterTreeNode9.Nodes.Count) + "x " + Misc.RemoveHiddenString(Conversions.ToString(darkFilterTreeNode9.Tag));
						darkFilterTreeNode9 = null;
					}
					catch (Exception ex13)
					{
						ProjectData.SetProjectError(ex13);
						Exception ex14 = ex13;
						ex14?.Data.Add("Error at 523253955y04", "");
						GameGeneral.WriteExceptionsToLog(ex14);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
				}
				foreach (ActiveUnit item6 in enumerable5)
				{
					try
					{
						string name2 = item6.Name;
						string text5 = ((!string.IsNullOrEmpty(item6.UnitClass)) ? (name2 + " (" + Misc.RemoveHiddenString(item6.UnitClass) + ")") : name2);
						DarkFilterTreeNode darkFilterTreeNode11 = new DarkFilterTreeNode(text5);
						darkFilterTreeNode.Nodes.Add(darkFilterTreeNode11);
						darkFilterTreeNode11.ForeColor = GetUnitProficiencyColor(item6);
						darkFilterTreeNode11.Tag = item6;
						if (!item6.IsGroup)
						{
							continue;
						}
						foreach (ActiveUnit value2 in ((Group)item6).Units.Values)
						{
							DarkFilterTreeNode darkFilterTreeNode12 = new DarkFilterTreeNode(method_20(value2));
							darkFilterTreeNode11.Nodes.Add(darkFilterTreeNode12);
							darkFilterTreeNode12.ForeColor = GetUnitProficiencyColor(value2);
							darkFilterTreeNode12.Tag = value2;
						}
					}
					catch (Exception ex15)
					{
						ProjectData.SetProjectError(ex15);
						Exception ex16 = ex15;
						ex16?.Data.Add("Error at 523253955y05", "");
						GameGeneral.WriteExceptionsToLog(ex16);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
				}
				darkFilterTreeNode.Expanded = true;
				continue;
			}
			DarkFilterTreeNode darkFilterTreeNode13 = new DarkFilterTreeNode(item.Name);
			try
			{
				TV_ByMission.Nodes.Add(darkFilterTreeNode13);
				if (item.IsActive)
				{
					darkFilterTreeNode13.ForeColor = Color.LightGreen;
				}
				else
				{
					darkFilterTreeNode13.ForeColor = Color.IndianRed;
					darkFilterTreeNode13.Font = new Font(((Control)this).Font, (FontStyle)2);
				}
				darkFilterTreeNode13.Tag = item;
			}
			catch (Exception ex17)
			{
				ProjectData.SetProjectError(ex17);
				Exception ex18 = ex17;
				ex18?.Data.Add("Error at 523253955t94", "");
				GameGeneral.WriteExceptionsToLog(ex18);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			List<Aircraft> list7 = new List<Aircraft>();
			List<Aircraft> list8 = new List<Aircraft>();
			List<ActiveUnit> list9 = new List<ActiveUnit>();
			foreach (ActiveUnit unit3 in Client.CurrentSide.Units)
			{
				try
				{
					if ((unit3.IsGroupMember() | (unit3.IsWeapon && ((Weapon)unit3).Type == Weapon._WeaponType.Sonobuoy)) || unit3.ActiveMissionOrPackage() != item)
					{
						continue;
					}
					if (!unit3.IsAircraft)
					{
						if (!unit3.IsSubmarine || !((Submarine)unit3).IsTetheredROV)
						{
							list9.Add(unit3);
						}
					}
					else if (!Information.IsNothing((object)unit3.Navigator.get_Flight(HierarchySearch: true)))
					{
						if (unit3.IsGroupMember())
						{
							if (!Information.IsNothing((object)unit3.get_ParentGroup(UsingMissionPlanner: false)) && !list9.Contains(unit3.get_ParentGroup(UsingMissionPlanner: false)))
							{
								list9.Add(unit3.get_ParentGroup(UsingMissionPlanner: false));
							}
						}
						else
						{
							list8.Add((Aircraft)unit3);
						}
					}
					else if (!unit3.IsGroupMember())
					{
						list7.Add((Aircraft)unit3);
					}
					else if (!Information.IsNothing((object)unit3.get_ParentGroup(UsingMissionPlanner: false)) && !list9.Contains(unit3.get_ParentGroup(UsingMissionPlanner: false)))
					{
						list9.Add(unit3.get_ParentGroup(UsingMissionPlanner: false));
					}
				}
				catch (Exception ex19)
				{
					ProjectData.SetProjectError(ex19);
					Exception ex20 = ex19;
					ex20?.Data.Add("Error at 523253955t95", "");
					GameGeneral.WriteExceptionsToLog(ex20);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
			IEnumerable<Aircraft> enumerable6 = from theAC in list7
				orderby theAC.UnitClass, method_26(theAC)
				select theAC;
			List<Aircraft> list10 = list8.Select([SpecialName] (Aircraft theAC) => theAC).OrderBy([SpecialName] (Aircraft theAirc) => ((ActiveUnit_Navigator)theAirc.Navigator).get_Flight(HierarchySearch: true).Callsign, new NaturalSortComparer<string[]>()).ToList();
			IEnumerable<ActiveUnit> enumerable7 = list9.OrderBy([SpecialName] (ActiveUnit theAU) => theAU.Name);
			foreach (Aircraft item7 in enumerable6)
			{
				try
				{
					DarkFilterTreeNode darkFilterTreeNode14 = null;
					string unitClass3 = item7.UnitClass;
					foreach (DarkFilterTreeNode node4 in darkFilterTreeNode13.Nodes)
					{
						if (Operators.CompareString(node4.Tag.ToString(), unitClass3, true) == 0)
						{
							darkFilterTreeNode14 = node4;
						}
					}
					if (Information.IsNothing((object)darkFilterTreeNode14))
					{
						darkFilterTreeNode14 = new DarkFilterTreeNode(item7.UnitClass);
						darkFilterTreeNode13.Nodes.Add(darkFilterTreeNode14);
						darkFilterTreeNode14.Tag = unitClass3;
					}
					string text6 = method_27(item7);
					DarkFilterTreeNode darkFilterTreeNode15 = new DarkFilterTreeNode(text6);
					darkFilterTreeNode14.Nodes.Add(darkFilterTreeNode15);
					darkFilterTreeNode15.Tag = item7;
					darkFilterTreeNode15.ForeColor = GetUnitProficiencyColor(item7);
					darkFilterTreeNode14.Text = Conversions.ToString(darkFilterTreeNode14.Nodes.Count) + "x " + Misc.RemoveHiddenString(Conversions.ToString(darkFilterTreeNode14.Tag));
					darkFilterTreeNode14 = null;
				}
				catch (Exception ex21)
				{
					ProjectData.SetProjectError(ex21);
					Exception ex22 = ex21;
					ex22?.Data.Add("Error at 523253955t96", "");
					GameGeneral.WriteExceptionsToLog(ex22);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
			foreach (ActiveUnit item8 in enumerable7)
			{
				try
				{
					string text7 = item8.Name;
					if (item8.IsGroup)
					{
						Group obj = (Group)item8;
						if (obj.Type == Group.GroupType.AirGroup && obj.Units.Values.Count > 0)
						{
							string text8;
							int num;
							if (!string.IsNullOrEmpty(obj.Units.Values.ElementAtOrDefault(0).UnitClass))
							{
								text8 = " " + obj.Units.Values.ElementAtOrDefault(0).UnitClass;
								num = 6;
							}
							else
							{
								text8 = "";
								num = 6;
							}
							string[] array = new string[num];
							array[0] = text7;
							array[1] = " (";
							array[2] = Conversions.ToString(obj.Units.Count);
							array[3] = "x";
							array[4] = text8;
							array[5] = ")";
							text7 = string.Concat(array);
						}
					}
					DarkFilterTreeNode darkFilterTreeNode16 = new DarkFilterTreeNode(text7);
					darkFilterTreeNode13.Nodes.Add(darkFilterTreeNode16);
					darkFilterTreeNode16.Tag = item8;
					if (item8.IsGroup)
					{
						foreach (ActiveUnit value3 in ((Group)item8).Units.Values)
						{
							text7 = ((!value3.IsAircraft) ? value3.Name : method_27((Aircraft)value3));
							DarkFilterTreeNode darkFilterTreeNode17 = new DarkFilterTreeNode(text7);
							darkFilterTreeNode16.Nodes.Add(darkFilterTreeNode17);
							darkFilterTreeNode17.ForeColor = GetUnitProficiencyColor(item8);
							darkFilterTreeNode17.Tag = value3;
						}
					}
					else
					{
						darkFilterTreeNode16.ForeColor = GetUnitProficiencyColor(item8);
					}
				}
				catch (Exception ex23)
				{
					ProjectData.SetProjectError(ex23);
					Exception ex24 = ex23;
					ex24?.Data.Add("Error at 523253955t97", "");
					GameGeneral.WriteExceptionsToLog(ex24);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
			foreach (Aircraft item9 in list10)
			{
				try
				{
					DarkFilterTreeNode darkFilterTreeNode18 = null;
					string callsign2 = ((ActiveUnit_Navigator)item9.Navigator).get_Flight(HierarchySearch: true).Callsign;
					foreach (DarkFilterTreeNode node5 in darkFilterTreeNode13.Nodes)
					{
						if (Operators.CompareString(node5.Tag.ToString(), callsign2, true) == 0)
						{
							darkFilterTreeNode18 = node5;
						}
					}
					if (Information.IsNothing((object)darkFilterTreeNode18))
					{
						darkFilterTreeNode18 = new DarkFilterTreeNode(item9.UnitClass);
						darkFilterTreeNode13.Nodes.Add(darkFilterTreeNode18);
						darkFilterTreeNode18.Tag = callsign2;
					}
					string text9 = method_27(item9);
					DarkFilterTreeNode darkFilterTreeNode19 = new DarkFilterTreeNode(text9);
					darkFilterTreeNode18.Nodes.Add(darkFilterTreeNode19);
					darkFilterTreeNode19.Tag = item9;
					darkFilterTreeNode19.ForeColor = GetUnitProficiencyColor(item9);
					darkFilterTreeNode18.Text = "Flight " + callsign2 + " (" + Conversions.ToString(darkFilterTreeNode18.Nodes.Count) + "x " + Misc.RemoveHiddenString(item9.UnitClass) + ")";
					darkFilterTreeNode18 = null;
				}
				catch (Exception ex25)
				{
					ProjectData.SetProjectError(ex25);
					Exception ex26 = ex25;
					ex26?.Data.Add("Error at 523253955t98", "");
					GameGeneral.WriteExceptionsToLog(ex26);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
			darkFilterTreeNode13.Expanded = true;
		}
	}

	private void method_23()
	{
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_0218: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Expected O, but got Unknown
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Expected O, but got Unknown
		TV_ByType.Nodes.Clear();
		if (Information.IsNothing((object)Client.CurrentSide))
		{
			return;
		}
		List<ActiveUnit> list = new List<ActiveUnit>();
		list.AddRange(Client.CurrentSide.Units);
		list = list.OrderBy([SpecialName] (ActiveUnit theU) => theU.Name).ToList();
		List<DarkFilterTreeNode> list2 = new List<DarkFilterTreeNode>();
		using (List<ActiveUnit>.Enumerator enumerator = list.GetEnumerator())
		{
			_Closure$__129-0 closure$__129- = default(_Closure$__129-0);
			while (enumerator.MoveNext())
			{
				closure$__129- = new _Closure$__129-0(closure$__129-);
				closure$__129-.$VB$Local_theAU = enumerator.Current;
				try
				{
					if (closure$__129-.$VB$Local_theAU.UnitType == GlobalVariables.ActiveUnitType.None)
					{
						continue;
					}
					DarkFilterTreeNode darkFilterTreeNode = null;
					string text = method_20(closure$__129-.$VB$Local_theAU);
					DarkFilterTreeNode darkFilterTreeNode2 = list2.Where(closure$__129-._Lambda$__1).FirstOrDefault();
					if (darkFilterTreeNode2 == null)
					{
						darkFilterTreeNode2 = new DarkFilterTreeNode();
						darkFilterTreeNode2.Tag = (int)closure$__129-.$VB$Local_theAU.UnitType;
						darkFilterTreeNode2.Font = new Font(((Control)TV_ByType).Font, (FontStyle)0);
						darkFilterTreeNode2.ForeColor = Color.White;
						darkFilterTreeNode2.Text = closure$__129-.$VB$Local_theAU.UnitType_String;
						darkFilterTreeNode2.ParentTree = TV_ByType;
						list2.Add(darkFilterTreeNode2);
					}
					DarkFilterTreeNode darkFilterTreeNode3 = darkFilterTreeNode2.Nodes.Where(closure$__129-._Lambda$__2).FirstOrDefault();
					if (darkFilterTreeNode3 == null)
					{
						darkFilterTreeNode3 = new DarkFilterTreeNode();
						darkFilterTreeNode3.Tag = closure$__129-.$VB$Local_theAU.SubType;
						darkFilterTreeNode3.Font = new Font(((Control)TV_ByType).Font, (FontStyle)0);
						darkFilterTreeNode3.ForeColor = Color.White;
						if (closure$__129-.$VB$Local_theAU.UnitType == GlobalVariables.ActiveUnitType.Facility)
						{
							Facility facility = (Facility)closure$__129-.$VB$Local_theAU;
							darkFilterTreeNode3.Text = facility.Type_Description;
						}
						else
						{
							darkFilterTreeNode3.Text = closure$__129-.$VB$Local_theAU.SubTypeDescription;
						}
						darkFilterTreeNode3.ParentTree = TV_ByType;
						darkFilterTreeNode2.Nodes.Add(darkFilterTreeNode3);
					}
					darkFilterTreeNode = new DarkFilterTreeNode();
					darkFilterTreeNode.Tag = closure$__129-.$VB$Local_theAU;
					darkFilterTreeNode.Font = new Font(((Control)TV_ByType).Font, (FontStyle)0);
					darkFilterTreeNode.ForeColor = GetUnitProficiencyColor(closure$__129-.$VB$Local_theAU);
					darkFilterTreeNode.Text = text;
					darkFilterTreeNode.ParentTree = TV_ByType;
					darkFilterTreeNode3.Nodes.Add(darkFilterTreeNode);
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error at 523253955y06", "");
					GameGeneral.WriteExceptionsToLog(ex2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
		}
		try
		{
			foreach (DarkFilterTreeNode item in list2)
			{
				TV_ByType.Nodes.Add(item);
				item.EnsureVisible();
			}
			Module1.ExpandAll(TV_ByType);
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			ex4?.Data.Add("Error at 523253955y07", "");
			GameGeneral.WriteExceptionsToLog(ex4);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_24()
	{
		if (TGV_Contacts.Nodes.Count > 0)
		{
			TGV_Contacts.Nodes.Clear();
		}
		List<Contact> list = new List<Contact>(Client.CurrentSide.Contacts.Count + Client.CurrentSide.BaseContacts.Count);
		try
		{
			list.AddRange(Client.CurrentSide.Contacts_List);
			list.AddRange(Client.CurrentSide.BaseContacts_List);
			list = list.OrderBy([SpecialName] (Contact theC) => theC.Name).ToList();
			foreach (Contact item in list)
			{
				if (!item.ActualUnit.IsGroupMember() || !item.ActualUnit.get_ParentGroup(UsingMissionPlanner: false).IsLandInstallation)
				{
					TreeGridNode treeGridNode = TGV_Contacts.Nodes.Add();
					method_25(treeGridNode, item);
					if (item.ActualUnit.IsGroup)
					{
						treeGridNode.Nodes.Add("temp");
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 523253955y08", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_25(TreeGridNode treeGridNode_0, Contact contact_0)
	{
		try
		{
			if (!contact_0.ActualUnit.IsGroup)
			{
				((DataGridViewRow)treeGridNode_0).SetValues(new object[5]
				{
					contact_0.Name,
					Contact.GeneralClassificationString(contact_0),
					contact_0.get_Stance(Client.CurrentSide).ToString(),
					(!contact_0.BDA_StructuralIntegrity.HasValue) ? "---" : (Misc.ToEnglishString(contact_0.BDA_StructuralIntegrity) + " (" + (((long)Math.Round(contact_0.TimeSinceBDA) == 0L) ? "0 sec" : Misc.TimeString((long)Math.Round(contact_0.TimeSinceBDA))) + " ago)"),
					method_39(contact_0)
				});
			}
			else
			{
				((DataGridViewRow)treeGridNode_0).SetValues(new object[3]
				{
					contact_0.Name,
					Contact.GeneralClassificationString(contact_0),
					contact_0.get_Stance(Client.CurrentSide).ToString()
				});
			}
			((DataGridViewBand)treeGridNode_0).Tag = contact_0.ActualUnit.ObjectID;
			((DataGridViewRow)treeGridNode_0).DefaultCellStyle.ForeColor = Client.get_ColorFromStance(contact_0.get_Stance(Client.CurrentSide));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 523253955y09", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private string method_26(Aircraft aircraft_0)
	{
		string result = default(string);
		try
		{
			ActiveUnit currentHostUnit = aircraft_0.AirOps.CurrentHostUnit;
			if (Information.IsNothing((object)currentHostUnit))
			{
				result = "Airborne";
				return result;
			}
			result = currentHostUnit.Name;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 523253955y10", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private string method_27(Aircraft aircraft_0)
	{
		string result = default(string);
		try
		{
			string ReasonForNot = null;
			string text;
			if (aircraft_0.IsAvailableForOps(ref ReasonForNot) == 2)
			{
				text = "[UNAVAILABLE] " + aircraft_0.Name;
			}
			else
			{
				string text2 = ((!aircraft_0.IsOperating()) ? aircraft_0.AirOps.CurrentHostUnit.Name : "Airborne");
				string text3;
				int num;
				if (Information.IsNothing((object)aircraft_0.Loadout))
				{
					text3 = "";
					num = 5;
				}
				else
				{
					text3 = " (" + aircraft_0.Loadout.Name + ")";
					num = 5;
				}
				string[] array = new string[num];
				array[0] = aircraft_0.Name;
				array[1] = text3;
				array[2] = " (";
				array[3] = text2;
				array[4] = ")";
				text = string.Concat(array);
			}
			result = text;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 523253955y11", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private void ORBAT_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Invalid comparison between Unknown and I4
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Invalid comparison between Unknown and I4
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Invalid comparison between Unknown and I4
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Invalid comparison between Unknown and I4
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Invalid comparison between Unknown and I4
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Invalid comparison between Unknown and I4
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Invalid comparison between Unknown and I4
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Invalid comparison between Unknown and I4
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Invalid comparison between Unknown and I4
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Invalid comparison between Unknown and I4
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Invalid comparison between Unknown and I4
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b0: Invalid comparison between Unknown and I4
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Invalid comparison between Unknown and I4
		//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bd: Invalid comparison between Unknown and I4
		//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d6: Invalid comparison between Unknown and I4
		try
		{
			if ((int)e.KeyCode == 27 && ((Control)this).Visible)
			{
				((Form)this).Close();
				return;
			}
			if (((Control)this).Visible)
			{
				if ((int)e.KeyCode == 33 || (int)e.KeyCode == 34 || (int)e.KeyCode == 35 || (int)e.KeyCode == 36 || (int)e.KeyCode == 38 || (int)e.KeyCode == 40 || (int)e.KeyCode == 37 || (int)e.KeyCode == 39)
				{
					return;
				}
				if ((int)e.KeyCode == 107)
				{
					if (Operators.CompareString(((ContainerControl)sender).ActiveControl.Name, "TV_ByMission", true) != 0)
					{
						if (Operators.CompareString(((ContainerControl)sender).ActiveControl.Name, "TV_ByGroup", true) == 0)
						{
							Module1.ExpandAll(TV_ByGroup);
						}
						else
						{
							Module1.ExpandAll(TV_ByType);
						}
					}
					else
					{
						Module1.ExpandAll(TV_ByMission);
					}
					e.Handled = true;
					e.SuppressKeyPress = true;
					return;
				}
				if ((int)e.KeyCode == 109)
				{
					if (Operators.CompareString(((ContainerControl)sender).ActiveControl.Name, "TV_ByMission", true) != 0)
					{
						if (Operators.CompareString(((ContainerControl)sender).ActiveControl.Name, "TV_ByGroup", true) == 0)
						{
							Module1.CollapseAll(TV_ByGroup);
						}
						else
						{
							Module1.CollapseAll(TV_ByType);
						}
					}
					else
					{
						Module1.CollapseAll(TV_ByMission);
					}
					e.Handled = true;
					e.SuppressKeyPress = true;
					return;
				}
				if ((int)e.KeyCode == 109 || ((int)e.KeyCode == 67 && (int)e.Modifiers == 131072) || ((int)e.KeyCode == 88 && (int)e.Modifiers == 131072))
				{
					return;
				}
			}
			if (!((Control)TB_SearchOOB).Focused)
			{
				MyProject.Forms.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 523253955y12", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_28(object sender, EventArgs e)
	{
		try
		{
			GlobalVariables.ProficiencyLevel? proficiency = default(GlobalVariables.ProficiencyLevel?);
			switch (((ComboBox)CB_Proficiency).SelectedIndex)
			{
			case 0:
				proficiency = GlobalVariables.ProficiencyLevel.Novice;
				break;
			case 1:
				proficiency = GlobalVariables.ProficiencyLevel.Cadet;
				break;
			case 2:
				proficiency = GlobalVariables.ProficiencyLevel.Regular;
				break;
			case 3:
				proficiency = GlobalVariables.ProficiencyLevel.Veteran;
				break;
			case 4:
				proficiency = GlobalVariables.ProficiencyLevel.Ace;
				break;
			case 5:
				proficiency = null;
				break;
			}
			switch (((TabControl)TabControl1).SelectedIndex)
			{
			case 0:
			{
				foreach (DarkFilterTreeNode selectedNode in TV_ByGroup.SelectedNodes)
				{
					((ActiveUnit)selectedNode.Tag).Proficiency = proficiency;
					selectedNode.ForeColor = GetUnitProficiencyColor((ActiveUnit)selectedNode.Tag);
					if (!((ActiveUnit)selectedNode.Tag).IsGroup)
					{
						continue;
					}
					foreach (DarkFilterTreeNode node in selectedNode.Nodes)
					{
						node.ForeColor = GetUnitProficiencyColor((ActiveUnit)node.Tag);
					}
				}
				break;
			}
			case 1:
			{
				foreach (DarkFilterTreeNode selectedNode2 in TV_ByMission.SelectedNodes)
				{
					try
					{
						if (!((Module_Unit.Unit)selectedNode2.Tag).IsActiveUnit)
						{
							continue;
						}
						((ActiveUnit)selectedNode2.Tag).Proficiency = proficiency;
						selectedNode2.ForeColor = GetUnitProficiencyColor((ActiveUnit)selectedNode2.Tag);
						if (!((ActiveUnit)selectedNode2.Tag).IsGroup)
						{
							continue;
						}
						foreach (DarkFilterTreeNode node2 in selectedNode2.Nodes)
						{
							node2.ForeColor = GetUnitProficiencyColor((ActiveUnit)node2.Tag);
						}
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						ex2?.Data.Add("Error at 200402", ex2.Message);
						GameGeneral.WriteExceptionsToLog(ex2);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
				}
				break;
			}
			case 2:
			{
				foreach (DarkFilterTreeNode selectedNode3 in TV_ByType.SelectedNodes)
				{
					if (!selectedNode3.Tag.GetType().IsPrimitive)
					{
						((ActiveUnit)selectedNode3.Tag).Proficiency = proficiency;
						selectedNode3.ForeColor = GetUnitProficiencyColor((ActiveUnit)selectedNode3.Tag);
					}
				}
				break;
			}
			}
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			ex4?.Data.Add("Error at 523253955y13", "");
			GameGeneral.WriteExceptionsToLog(ex4);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void ORBAT_FormClosing(object sender, FormClosingEventArgs e)
	{
		((Control)MyProject.Forms.MainForm).BringToFront();
	}

	private void method_29(object sender, EventArgs e)
	{
		try
		{
			if (TV_ByGroup.SelectedNodes.Count != 1)
			{
				return;
			}
			ActiveUnit activeUnit = (ActiveUnit)TV_ByGroup.SelectedNodes[0].Tag;
			if (!activeUnit.IsOperating())
			{
				Client.SelectThisUnit(activeUnit, ThisUnitOnly: true);
			}
			else
			{
				MyProject.Forms.MainForm.set_MapCenter(MustRender: true, new GeoPoint(activeUnit.get_Longitude((GlobalVariables.BooleanObject)null), activeUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
				Client.SelectThisUnit(activeUnit, ThisUnitOnly: true);
			}
			GlobalVariables.ProficiencyLevel? proficiency = activeUnit.Proficiency;
			int? num = (int?)proficiency;
			if (((!num.HasValue) ? ((bool?)null) : new bool?(num.GetValueOrDefault() == 0)) != true)
			{
				num = (int?)proficiency;
				if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 1)) != true)
				{
					num = (int?)proficiency;
					if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 2)) != true)
					{
						num = (int?)proficiency;
						if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 3)) != true)
						{
							num = (int?)proficiency;
							if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 4)) == true)
							{
								((ComboBox)CB_Proficiency).SelectedIndex = 4;
							}
						}
						else
						{
							((ComboBox)CB_Proficiency).SelectedIndex = 3;
						}
					}
					else
					{
						((ComboBox)CB_Proficiency).SelectedIndex = 2;
					}
				}
				else
				{
					((ComboBox)CB_Proficiency).SelectedIndex = 1;
				}
			}
			else
			{
				((ComboBox)CB_Proficiency).SelectedIndex = 0;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 523253955y14", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_30(object sender, EventArgs e)
	{
		try
		{
			if (TV_ByMission.SelectedNodes.Count != 1)
			{
				return;
			}
			try
			{
				if ((object)TV_ByMission.SelectedNodes[0].Tag.GetType().BaseType == typeof(Mission) || (object)TV_ByMission.SelectedNodes[0].Tag.GetType() == typeof(string) || !((Module_Unit.Unit)TV_ByMission.SelectedNodes[0].Tag).IsActiveUnit)
				{
					return;
				}
				ActiveUnit activeUnit = (ActiveUnit)TV_ByMission.SelectedNodes[0].Tag;
				MyProject.Forms.MainForm.set_MapCenter(MustRender: true, new GeoPoint(activeUnit.get_Longitude((GlobalVariables.BooleanObject)null), activeUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
				Client.SelectThisUnit(activeUnit, ThisUnitOnly: true);
				GlobalVariables.ProficiencyLevel? proficiency = activeUnit.Proficiency;
				int? num = (int?)proficiency;
				if (((!num.HasValue) ? ((bool?)null) : new bool?(num.GetValueOrDefault() == 0)) != true)
				{
					num = (int?)proficiency;
					if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 1)) == true)
					{
						((ComboBox)CB_Proficiency).SelectedIndex = 1;
						return;
					}
					num = (int?)proficiency;
					if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 2)) == true)
					{
						((ComboBox)CB_Proficiency).SelectedIndex = 2;
						return;
					}
					num = (int?)proficiency;
					if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 3)) != true)
					{
						num = (int?)proficiency;
						if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 4)) == true)
						{
							((ComboBox)CB_Proficiency).SelectedIndex = 4;
						}
					}
					else
					{
						((ComboBox)CB_Proficiency).SelectedIndex = 3;
					}
				}
				else
				{
					((ComboBox)CB_Proficiency).SelectedIndex = 0;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 200401", ex2.Message);
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			ex4?.Data.Add("Error at 523253955y15", "");
			GameGeneral.WriteExceptionsToLog(ex4);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_31(object sender, MouseEventArgs e)
	{
		try
		{
			ActiveUnit theAU = null;
			sender.ToString();
			if ((object)((DarkFilterTreeView)sender).SelectedNodes[0].Tag.GetType().BaseType == typeof(Mission) || (object)((DarkFilterTreeView)sender).SelectedNodes[0].Tag.GetType() == typeof(string))
			{
				return;
			}
			if (sender.GetType() == typeof(DarkFilterTreeView))
			{
				theAU = (ActiveUnit)((DarkFilterTreeView)sender).SelectedNodes[0].Tag;
			}
			if (sender.GetType() == typeof(DarkTreeGridView))
			{
				theAU = (ActiveUnit)((DataGridViewBand)((DarkTreeGridView)sender).CurrentNode).Tag;
			}
			if (Client.SelectedUnit != null)
			{
				if (Client.SelectedUnit.IsActiveUnit)
				{
					theAU = (ActiveUnit)Client.SelectedUnit;
				}
				if (Client.SelectedUnit.IsContact())
				{
					theAU = ((Contact)Client.SelectedUnit).ActualUnit;
				}
				if (Client.SelectedUnit.IsGroup && ((Group)Client.SelectedUnit).Type == Group.GroupType.AirGroup)
				{
					theAU = ((Group)Client.SelectedUnit).Units.Values.ElementAtOrDefault(0);
				}
				Client.smethod_18(theAU);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 523253955y16", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_32(object sender, EventArgs e)
	{
		try
		{
			if (TV_ByType.SelectedNodes.Count != 1 || TV_ByType.SelectedNodes[0].Tag.GetType().IsPrimitive)
			{
				return;
			}
			ActiveUnit activeUnit = (ActiveUnit)TV_ByType.SelectedNodes[0].Tag;
			if (activeUnit.IsOperating())
			{
				MyProject.Forms.MainForm.set_MapCenter(MustRender: true, new GeoPoint(activeUnit.get_Longitude((GlobalVariables.BooleanObject)null), activeUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
				Client.SelectThisUnit(activeUnit, ThisUnitOnly: true);
				GlobalVariables.ProficiencyLevel? proficiency = activeUnit.Proficiency;
				int? num = (int?)proficiency;
				if (((!num.HasValue) ? ((bool?)null) : new bool?(num.GetValueOrDefault() == 0)) == true)
				{
					((ComboBox)CB_Proficiency).SelectedIndex = 0;
					return;
				}
				num = (int?)proficiency;
				if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 1)) == true)
				{
					((ComboBox)CB_Proficiency).SelectedIndex = 1;
					return;
				}
				num = (int?)proficiency;
				if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 2)) != true)
				{
					num = (int?)proficiency;
					if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 3)) != true)
					{
						num = (int?)proficiency;
						if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 4)) == true)
						{
							((ComboBox)CB_Proficiency).SelectedIndex = 4;
						}
					}
					else
					{
						((ComboBox)CB_Proficiency).SelectedIndex = 3;
					}
				}
				else
				{
					((ComboBox)CB_Proficiency).SelectedIndex = 2;
				}
			}
			else
			{
				Client.SelectThisUnit(activeUnit, ThisUnitOnly: true);
				ActiveUnit activeUnit2 = null;
				activeUnit2 = ((activeUnit.UnitType != GlobalVariables.ActiveUnitType.Aircraft) ? activeUnit.DockingOps.CurrentHostUnit : ((Aircraft)activeUnit).AirOps.CurrentHostUnit);
				if (activeUnit2 != null)
				{
					MyProject.Forms.MainForm.set_MapCenter(MustRender: true, new GeoPoint(activeUnit2.get_Longitude((GlobalVariables.BooleanObject)null), activeUnit2.get_Latitude((GlobalVariables.BooleanObject)null)));
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 523253955y17", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_33(object sender, MouseEventArgs e)
	{
		try
		{
			ActiveUnit theAU = null;
			sender.ToString();
			if ((object)((DarkFilterTreeView)sender).SelectedNodes[0].Tag.GetType() == typeof(string) || (object)((DarkFilterTreeView)sender).SelectedNodes[0].Tag.GetType() == typeof(int))
			{
				return;
			}
			if (sender.GetType() == typeof(DarkFilterTreeView))
			{
				theAU = (ActiveUnit)((DarkFilterTreeView)sender).SelectedNodes[0].Tag;
			}
			if (sender.GetType() == typeof(DarkTreeGridView))
			{
				theAU = (ActiveUnit)((DataGridViewBand)((DarkTreeGridView)sender).CurrentNode).Tag;
			}
			if (Client.SelectedUnit != null)
			{
				if (Client.SelectedUnit.IsActiveUnit)
				{
					theAU = (ActiveUnit)Client.SelectedUnit;
				}
				if (Client.SelectedUnit.IsContact())
				{
					theAU = ((Contact)Client.SelectedUnit).ActualUnit;
				}
				if (Client.SelectedUnit.IsGroup && ((Group)Client.SelectedUnit).Type == Group.GroupType.AirGroup)
				{
					theAU = ((Group)Client.SelectedUnit).Units.Values.ElementAtOrDefault(0);
				}
				Client.smethod_18(theAU);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 523253955y18", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void ORBAT_Shown(object sender, EventArgs e)
	{
		BuildWindow();
		((Control)TV_ByGroup).Focus();
	}

	private void method_34(object sender, EventArgs e)
	{
		method_36();
	}

	private void method_35(object sender, KeyPressEventArgs e)
	{
		method_36();
	}

	private void method_36()
	{
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			TV_ByGroup.SetFilterString(((TextBox)TB_SearchOOB).Text);
			TV_ByMission.SetFilterString(((TextBox)TB_SearchOOB).Text);
			TV_ByType.SetFilterString(((TextBox)TB_SearchOOB).Text);
			foreach (TreeGridNode node in TGV_Contacts.Nodes)
			{
				if (((DataGridViewRow)node).Visible)
				{
					if (!Conversions.ToString(((DataGridViewCell)(DataGridViewTextBoxCell)node.Cells[0]).Value).ToLower().Contains(((TextBox)TB_SearchOOB).Text.ToLower()))
					{
						((DataGridViewRow)node).DefaultCellStyle.BackColor = ((DataGridView)TGV_Contacts).DefaultCellStyle.BackColor;
					}
					else
					{
						((DataGridViewRow)node).DefaultCellStyle.BackColor = Color.DarkGreen;
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 523253955y19", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_37(object sender, ExpandingEventArgs e)
	{
		try
		{
			Contact contact = Client.CurrentSide.BaseContacts[Conversions.ToString(((DataGridViewBand)e.Node).Tag)];
			if (contact == null)
			{
				return;
			}
			Group obj = (Group)contact.ActualUnit;
			e.Node.Nodes.Clear();
			foreach (Contact contacts_ in Client.CurrentSide.Contacts_List)
			{
				if (contacts_.ActualUnit.IsGroupMember() && contacts_.ActualUnit.get_ParentGroup(UsingMissionPlanner: false) == obj)
				{
					TreeGridNode treeGridNode = e.Node.Nodes.Add(contacts_.Name, contacts_.ContactType_String, contacts_.get_Stance(Client.CurrentSide).ToString(), (!contacts_.BDA_StructuralIntegrity.HasValue) ? "---" : (Misc.ToEnglishString(contacts_.BDA_StructuralIntegrity) + " (" + Misc.TimeString((long)Math.Round(contacts_.TimeSinceBDA)) + " ago)"), method_39(contacts_));
					((DataGridViewBand)treeGridNode).Tag = contacts_.ActualUnit.ObjectID;
					((DataGridViewRow)treeGridNode).DefaultCellStyle.ForeColor = Client.get_ColorFromStance(contacts_.get_Stance(Client.CurrentSide));
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 523253955y20", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_38(object sender, EventArgs e)
	{
		try
		{
			if (TGV_Contacts.CurrentNode == null)
			{
				return;
			}
			string key = Conversions.ToString(((DataGridViewBand)TGV_Contacts.CurrentNode).Tag);
			if (Client.CurrentSide.Contacts.ContainsKey(key))
			{
				Contact contact = Client.CurrentSide.Contacts[key];
				MyProject.Forms.MainForm.set_MapCenter(MustRender: true, new GeoPoint(((Module_Unit.Unit)contact).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)contact).get_Latitude((GlobalVariables.BooleanObject)null)));
				Client.SelectThisUnit(contact, ThisUnitOnly: true);
				if (contact.ActualUnit.IsGroupMember() && Client.CurrentMapProfile.ViewMode == MapProfile.MapViewMode.GroupView)
				{
					MyProject.Forms.MainForm.SwitchView();
				}
			}
			else if (Client.CurrentSide.BaseContacts.ContainsKey(key))
			{
				Contact contact = Client.CurrentSide.BaseContacts[key];
				MyProject.Forms.MainForm.set_MapCenter(MustRender: true, new GeoPoint(((Module_Unit.Unit)contact).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)contact).get_Latitude((GlobalVariables.BooleanObject)null)));
				Client.SelectThisUnit(contact, ThisUnitOnly: true);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 523253955y21", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private string method_39(Contact contact_0)
	{
		string result = default(string);
		try
		{
			if (contact_0.Recon_HostedUnits(Client.CurrentSide).Count > 0)
			{
				Dictionary<string, int> dictionary = new Dictionary<string, int>();
				string text = default(string);
				foreach (Contact.HostedUnitReconRecord item in contact_0.Recon_HostedUnits(Client.CurrentSide))
				{
					switch (item.IDStatus)
					{
					case Contact_Base.IdentificationStatus.Unknown:
						text = "Unknown unit";
						break;
					case Contact_Base.IdentificationStatus.KnownDomain:
						try
						{
							ActiveUnit activeUnit2 = Client.CurrentScenario.ActiveUnits[item.UnitID];
							text = Misc.ToEnglishString(activeUnit2.VisualSizeClass) + " " + activeUnit2.UnitType_String;
						}
						catch (Exception ex7)
						{
							ProjectData.SetProjectError(ex7);
							Exception ex8 = ex7;
							ex8?.Data.Add("Error at 999999", ex8.Message);
							GameGeneral.WriteExceptionsToLog(ex8);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							text = "Unknown unit";
							ProjectData.ClearProjectError();
						}
						break;
					case Contact_Base.IdentificationStatus.KnownType:
						try
						{
							ActiveUnit activeUnit = Client.CurrentScenario.ActiveUnits[item.UnitID];
							text = Misc.ToEnglishString(activeUnit.VisualSizeClass) + " " + activeUnit.SubTypeDescription;
						}
						catch (Exception ex5)
						{
							ProjectData.SetProjectError(ex5);
							Exception ex6 = ex5;
							ex6?.Data.Add("Error at 200409", ex6.Message);
							GameGeneral.WriteExceptionsToLog(ex6);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							text = "Unknown unit";
							ProjectData.ClearProjectError();
						}
						break;
					case Contact_Base.IdentificationStatus.KnownClass:
						try
						{
							text = Client.CurrentScenario.ActiveUnits[item.UnitID].UnitClass;
						}
						catch (Exception ex3)
						{
							ProjectData.SetProjectError(ex3);
							Exception ex4 = ex3;
							ex4?.Data.Add("Error at 200410", ex4.Message);
							GameGeneral.WriteExceptionsToLog(ex4);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							text = "Unknown unit";
							ProjectData.ClearProjectError();
						}
						break;
					case Contact_Base.IdentificationStatus.PreciseID:
						try
						{
							text = Client.CurrentScenario.ActiveUnits[item.UnitID].Name;
						}
						catch (Exception ex)
						{
							ProjectData.SetProjectError(ex);
							Exception ex2 = ex;
							ex2?.Data.Add("Error at 200411", ex2.Message);
							GameGeneral.WriteExceptionsToLog(ex2);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							text = "Unknown unit";
							ProjectData.ClearProjectError();
						}
						break;
					}
					text = text + " (Last Recon: " + ((item.ReconAge > 0f) ? (Misc.TimeString((long)Math.Round(item.ReconAge), 0, ReturnNo: false, ReturnZero: true) + " ago)") : "Now)");
					if (dictionary.ContainsKey(text))
					{
						dictionary[text]++;
					}
					else
					{
						dictionary.Add(text, 1);
					}
				}
				List<string> list = new List<string>();
				foreach (KeyValuePair<string, int> item2 in dictionary)
				{
					list.Add(Conversions.ToString(item2.Value) + "x " + item2.Key);
				}
				result = string.Join("\r\n", list);
				return result;
			}
			result = "---";
			return result;
		}
		catch (Exception ex9)
		{
			ProjectData.SetProjectError(ex9);
			Exception ex10 = ex9;
			ex10?.Data.Add("Error at 523253955y22", "");
			GameGeneral.WriteExceptionsToLog(ex10);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private void method_40(object sender, EventArgs e)
	{
		try
		{
			if (Client.CurrentGame.Status != Game._GameStatus.Running)
			{
				return;
			}
			int num = TGV_Contacts.Nodes.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				try
				{
					TreeGridNode treeGridNode = TGV_Contacts.Nodes[i];
					Contact contact = null;
					if (Client.CurrentSide.Contacts.ContainsKey(((DataGridViewBand)treeGridNode).Tag.ToString()))
					{
						contact = Client.CurrentSide.Contacts[((DataGridViewBand)treeGridNode).Tag.ToString()];
					}
					else if (Client.CurrentSide.BaseContacts.ContainsKey(((DataGridViewBand)treeGridNode).Tag.ToString()))
					{
						contact = Client.CurrentSide.BaseContacts[((DataGridViewBand)treeGridNode).Tag.ToString()];
					}
					if (contact != null)
					{
						method_25(treeGridNode, contact);
					}
					else if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 523253955y23", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_41(object sender, EventArgs e)
	{
		try
		{
			switch (((TabControl)TabControl1).SelectedIndex)
			{
			case 0:
				method_21();
				break;
			case 1:
				method_22();
				break;
			case 2:
				method_23();
				break;
			case 3:
				method_24();
				break;
			}
			method_42();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 523253955y24", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_42()
	{
		try
		{
			switch (((TabControl)TabControl1).SelectedIndex)
			{
			case 0:
				method_43(bool_3);
				break;
			case 1:
				method_43(bool_4);
				break;
			case 2:
				method_43(bool_5);
				break;
			case 3:
				method_43(bool_6);
				break;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 523253955y25", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_43(bool bool_11)
	{
		try
		{
			if (!bool_11)
			{
				btnEXPCOL.Text = "Expand List";
			}
			else
			{
				btnEXPCOL.Text = "Collapse List";
			}
			((Control)btnEXPCOL).Refresh();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 523253955y26", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_44(object sender, EventArgs e)
	{
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c4: Expected O, but got Unknown
		//IL_0271: Unknown result type (might be due to invalid IL or missing references)
		//IL_0278: Expected O, but got Unknown
		try
		{
			switch (((TabControl)TabControl1).SelectedIndex)
			{
			case 0:
				bool_7 = !bool_7;
				{
					foreach (Control control in ((Control)((TabControl)TabControl1).SelectedTab).Controls)
					{
						Control val4 = control;
						if (((object)val4).GetType() == typeof(DarkFilterTreeView))
						{
							if (bool_7)
							{
								((DarkFilterTreeView)(object)val4).ExpandAllItems();
								btnEXPCOL.Text = "Collapse List";
							}
							else
							{
								((DarkFilterTreeView)(object)val4).CollapseAllItem();
								btnEXPCOL.Text = "Expand List";
							}
						}
					}
					break;
				}
			case 1:
				bool_8 = !bool_8;
				{
					foreach (Control control2 in ((Control)((TabControl)TabControl1).SelectedTab).Controls)
					{
						Control val3 = control2;
						if (((object)val3).GetType() == typeof(DarkFilterTreeView))
						{
							if (bool_8)
							{
								((DarkFilterTreeView)(object)val3).ExpandAllItems();
								btnEXPCOL.Text = "Collapse List";
							}
							else
							{
								((DarkFilterTreeView)(object)val3).CollapseAllItem();
								btnEXPCOL.Text = "Expand List";
							}
						}
					}
					break;
				}
			case 2:
				bool_9 = !bool_9;
				{
					foreach (Control control3 in ((Control)((TabControl)TabControl1).SelectedTab).Controls)
					{
						Control val2 = control3;
						if (((object)val2).GetType() == typeof(DarkFilterTreeView))
						{
							if (!bool_9)
							{
								((DarkFilterTreeView)(object)val2).CollapseAllItem();
								btnEXPCOL.Text = "Expand List";
							}
							else
							{
								((DarkFilterTreeView)(object)val2).ExpandAllItems();
								btnEXPCOL.Text = "Collapse List";
							}
						}
					}
					break;
				}
			case 3:
				bool_10 = !bool_10;
				{
					foreach (Control control4 in ((Control)((TabControl)TabControl1).SelectedTab).Controls)
					{
						Control val = control4;
						if (((object)val).GetType() == typeof(DarkTreeGridView))
						{
							if (!bool_10)
							{
								((DarkTreeGridView)(object)val).CollapseAllItem();
								btnEXPCOL.Text = "Expand List";
							}
							else
							{
								((DarkTreeGridView)(object)val).ExpandAllItems();
								btnEXPCOL.Text = "Collapse List";
							}
						}
					}
					break;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 523253955y27", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	static ORBAT()
	{
		Class72.smethod_20();
	}
}
