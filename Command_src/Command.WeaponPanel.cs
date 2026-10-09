using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class WeaponPanel : UserControl
{
	private sealed class Class4
	{
		[CompilerGenerated]
		private int int_0;

		[CompilerGenerated]
		private string string_0;

		[CompilerGenerated]
		private int int_1;

		[CompilerGenerated]
		private int int_2;

		[CompilerGenerated]
		private string string_1;

		public int WeaponDBID
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

		public string WeaponName
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

		public int Qty
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

		public int Type
		{
			[CompilerGenerated]
			get
			{
				return int_2;
			}
			[CompilerGenerated]
			set
			{
				int_2 = value;
			}
		}

		public string WeaponsQuickView
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

		static Class4()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__34-0
	{
		public WeaponRec $VB$Local_theWeaponWeaponRec;

		public _Closure$__34-0(_Closure$__34-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theWeaponWeaponRec = arg0.$VB$Local_theWeaponWeaponRec;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(Class4 theRec)
		{
			return theRec.WeaponDBID == $VB$Local_theWeaponWeaponRec.int_3;
		}

		static _Closure$__34-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__34-1
	{
		public WeaponRec $VB$Local_theWeaponRec;

		public _Closure$__34-1(_Closure$__34-1 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theWeaponRec = arg0.$VB$Local_theWeaponRec;
			}
		}

		[SpecialName]
		internal bool _Lambda$__1(Class4 theRec)
		{
			return theRec.WeaponDBID == $VB$Local_theWeaponRec.int_3;
		}

		static _Closure$__34-1()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__35-0
	{
		public WeaponRec $VB$Local_theWeaponRec;

		public _Closure$__35-0(_Closure$__35-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theWeaponRec = arg0.$VB$Local_theWeaponRec;
			}
		}

		[SpecialName]
		internal bool _Lambda$__1(Class4 theRec)
		{
			return theRec.WeaponDBID == $VB$Local_theWeaponRec.int_3;
		}

		static _Closure$__35-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__36-0
	{
		public WeaponRec $VB$Local_theWeaponRec;

		public _Closure$__36-0(_Closure$__36-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theWeaponRec = arg0.$VB$Local_theWeaponRec;
			}
		}

		[SpecialName]
		internal bool _Lambda$__1(Class4 theRec)
		{
			return theRec.WeaponDBID == $VB$Local_theWeaponRec.int_3;
		}

		static _Closure$__36-0()
		{
			Class72.smethod_20();
		}
	}

	private IContainer icontainer_0;

	[AccessedThroughProperty("TGV_WeaponsQuickView")]
	[CompilerGenerated]
	private DoubleBufferedDataGridView _TGV_WeaponsQuickView;

	[CompilerGenerated]
	[AccessedThroughProperty("WeaponDBID")]
	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

	private List<Class4> list_0;

	private List<Class4> list_1;

	private int ActualWidth;

	public bool UpdateData;

	public virtual DoubleBufferedDataGridView TGV_WeaponsQuickView
	{
		[CompilerGenerated]
		get
		{
			return _TGV_WeaponsQuickView;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000e: Expected O, but got Unknown
			DataGridViewCellEventHandler val = new DataGridViewCellEventHandler(method_0);
			EventHandler eventHandler = method_1;
			EventHandler eventHandler2 = method_2;
			DoubleBufferedDataGridView doubleBufferedDataGridView = _TGV_WeaponsQuickView;
			if (doubleBufferedDataGridView != null)
			{
				((DataGridView)doubleBufferedDataGridView).CellContentClick -= val;
				((Control)doubleBufferedDataGridView).MouseEnter -= eventHandler;
				((Control)doubleBufferedDataGridView).MouseLeave -= eventHandler2;
			}
			_TGV_WeaponsQuickView = value;
			doubleBufferedDataGridView = _TGV_WeaponsQuickView;
			if (doubleBufferedDataGridView != null)
			{
				((DataGridView)doubleBufferedDataGridView).CellContentClick += val;
				((Control)doubleBufferedDataGridView).MouseEnter += eventHandler;
				((Control)doubleBufferedDataGridView).MouseLeave += eventHandler2;
			}
		}
	}

	[field: AccessedThroughProperty("WeaponsQuickView")]
	internal virtual DataGridViewLinkColumn WeaponsQuickView { get; set; }

	[field: AccessedThroughProperty("WeaponName")]
	internal virtual DataGridViewTextBoxColumn WeaponName { get; set; }

	[field: AccessedThroughProperty("Type")]
	internal virtual DataGridViewTextBoxColumn Type { get; set; }

	[field: AccessedThroughProperty("Qty")]
	internal virtual DataGridViewTextBoxColumn Qty { get; set; }

	internal virtual DataGridViewTextBoxColumn WeaponDBID
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

	public WeaponPanel()
	{
		((UserControl)this).Load += WeaponPanel_Load;
		list_0 = new List<Class4>();
		InitializeComponent();
	}

	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && icontainer_0 != null)
			{
				icontainer_0.Dispose();
			}
		}
		finally
		{
			((ContainerControl)this).Dispose(disposing);
		}
	}

	private void InitializeComponent()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Expected O, but got Unknown
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Expected O, but got Unknown
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Expected O, but got Unknown
		//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		TGV_WeaponsQuickView = new DoubleBufferedDataGridView();
		WeaponsQuickView = new DataGridViewLinkColumn();
		WeaponName = new DataGridViewTextBoxColumn();
		Type = new DataGridViewTextBoxColumn();
		Qty = new DataGridViewTextBoxColumn();
		WeaponDBID = new DataGridViewTextBoxColumn();
		((ISupportInitialize)(object)TGV_WeaponsQuickView).BeginInit();
		((Control)this).SuspendLayout();
		((DataGridView)TGV_WeaponsQuickView).AllowUserToAddRows = false;
		((DataGridView)TGV_WeaponsQuickView).AllowUserToDeleteRows = false;
		((DataGridView)TGV_WeaponsQuickView).AllowUserToResizeColumns = false;
		((DataGridView)TGV_WeaponsQuickView).AllowUserToResizeRows = false;
		((Control)TGV_WeaponsQuickView).Anchor = (AnchorStyles)15;
		((DataGridView)TGV_WeaponsQuickView).AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)1;
		((DataGridView)TGV_WeaponsQuickView).AutoSizeRowsMode = (DataGridViewAutoSizeRowsMode)0;
		((DataGridView)TGV_WeaponsQuickView).BackgroundColor = SystemColors.Control;
		((DataGridView)TGV_WeaponsQuickView).BorderStyle = (BorderStyle)0;
		((DataGridView)TGV_WeaponsQuickView).CellBorderStyle = (DataGridViewCellBorderStyle)4;
		((DataGridView)TGV_WeaponsQuickView).ClipboardCopyMode = (DataGridViewClipboardCopyMode)0;
		((DataGridView)TGV_WeaponsQuickView).ColumnHeadersBorderStyle = (DataGridViewHeaderBorderStyle)4;
		((DataGridView)TGV_WeaponsQuickView).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)1;
		((DataGridView)TGV_WeaponsQuickView).ColumnHeadersVisible = false;
		((DataGridView)TGV_WeaponsQuickView).Columns.AddRange((DataGridViewColumn[])(object)new DataGridViewColumn[5]
		{
			(DataGridViewColumn)WeaponsQuickView,
			(DataGridViewColumn)WeaponName,
			(DataGridViewColumn)Type,
			(DataGridViewColumn)Qty,
			(DataGridViewColumn)WeaponDBID
		});
		val.Alignment = (DataGridViewContentAlignment)16;
		val.BackColor = SystemColors.Window;
		val.Font = new Font("Tahoma", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val.ForeColor = SystemColors.ControlText;
		val.SelectionBackColor = SystemColors.Highlight;
		val.SelectionForeColor = SystemColors.HighlightText;
		val.WrapMode = (DataGridViewTriState)2;
		((DataGridView)TGV_WeaponsQuickView).DefaultCellStyle = val;
		((DataGridView)TGV_WeaponsQuickView).EditMode = (DataGridViewEditMode)4;
		((DataGridView)TGV_WeaponsQuickView).GridColor = Color.Gray;
		((Control)TGV_WeaponsQuickView).Location = new Point(0, 0);
		((Control)TGV_WeaponsQuickView).Margin = new Padding(0);
		((DataGridView)TGV_WeaponsQuickView).MultiSelect = false;
		((Control)TGV_WeaponsQuickView).Name = "TGV_WeaponsQuickView";
		((DataGridView)TGV_WeaponsQuickView).RowHeadersVisible = false;
		((DataGridView)TGV_WeaponsQuickView).RowHeadersWidthSizeMode = (DataGridViewRowHeadersWidthSizeMode)1;
		val2.BackColor = SystemColors.Control;
		val2.ForeColor = SystemColors.Control;
		val2.SelectionBackColor = SystemColors.Control;
		val2.SelectionForeColor = SystemColors.Control;
		((DataGridView)TGV_WeaponsQuickView).RowsDefaultCellStyle = val2;
		((DataGridView)TGV_WeaponsQuickView).ScrollBars = (ScrollBars)2;
		((DataGridView)TGV_WeaponsQuickView).SelectionMode = (DataGridViewSelectionMode)1;
		((Control)TGV_WeaponsQuickView).Size = new Size(232, 142);
		((Control)TGV_WeaponsQuickView).TabIndex = 5;
		((Control)TGV_WeaponsQuickView).TabStop = false;
		WeaponsQuickView.ActiveLinkColor = Color.Blue;
		((DataGridViewColumn)WeaponsQuickView).DataPropertyName = "WeaponsQuickView";
		((DataGridViewColumn)WeaponsQuickView).HeaderText = "Weapons (click for detailed info)";
		((DataGridViewColumn)WeaponsQuickView).Name = "WeaponsQuickView";
		((DataGridViewColumn)WeaponsQuickView).ReadOnly = true;
		WeaponsQuickView.LinkColor = Color.LightBlue;
		((DataGridViewColumn)WeaponsQuickView).Resizable = (DataGridViewTriState)1;
		((DataGridViewColumn)WeaponsQuickView).ToolTipText = "Click for weapon details.";
		WeaponsQuickView.VisitedLinkColor = Color.Blue;
		((DataGridViewColumn)WeaponName).DataPropertyName = "WeaponName";
		((DataGridViewColumn)WeaponName).HeaderText = "WeaponName";
		((DataGridViewColumn)WeaponName).Name = "WeaponName";
		((DataGridViewColumn)WeaponName).Visible = false;
		((DataGridViewColumn)Type).DataPropertyName = "Type";
		((DataGridViewColumn)Type).HeaderText = "Type";
		((DataGridViewColumn)Type).Name = "Type";
		((DataGridViewColumn)Type).Resizable = (DataGridViewTriState)1;
		Type.SortMode = (DataGridViewColumnSortMode)0;
		((DataGridViewColumn)Type).Visible = false;
		((DataGridViewColumn)Qty).DataPropertyName = "Qty";
		((DataGridViewColumn)Qty).HeaderText = "Qty";
		((DataGridViewColumn)Qty).Name = "Qty";
		((DataGridViewColumn)Qty).Visible = false;
		((DataGridViewColumn)WeaponDBID).DataPropertyName = "WeaponDBID";
		((DataGridViewColumn)WeaponDBID).HeaderText = "WeaponDBID";
		((DataGridViewColumn)WeaponDBID).Name = "WeaponDBID";
		((DataGridViewColumn)WeaponDBID).Visible = false;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Control)this).Controls.Add((Control)(object)TGV_WeaponsQuickView);
		((Control)this).Name = "WeaponPanel";
		((Control)this).Size = new Size(234, 142);
		((ISupportInitialize)(object)TGV_WeaponsQuickView).EndInit();
		((Control)this).ResumeLayout(false);
	}

	public void RetreiveWeaponDetails(ActiveUnit theUnit, bool ReloadData, ref bool HasWeapons)
	{
		if (Information.IsNothing((object)theUnit) || (theUnit.IsShip && ((Ship)theUnit).IsSinking))
		{
			return;
		}
		if (theUnit.IsActiveUnit)
		{
			if (!theUnit.IsAircraft && !theUnit.IsShip && !theUnit.IsSubmarine && !theUnit.IsFacility && !theUnit.IsSingleUnitAirbase && !theUnit.IsGroup)
			{
				list_0.Clear();
			}
			else
			{
				if (!ReloadData)
				{
					foreach (Class4 item in list_0)
					{
						item.Qty = 0;
						item.WeaponsQuickView = "0x " + item.WeaponName;
					}
				}
				else
				{
					UpdateData = true;
					list_0.Clear();
				}
				if (!theUnit.IsAircraft)
				{
					if (!theUnit.IsShip && !theUnit.IsSubmarine && !theUnit.IsFacility)
					{
						if (theUnit.IsGroup && ((Group)theUnit).Type == Group.GroupType.AirGroup)
						{
							foreach (ActiveUnit value in ((Group)theUnit).Units.Values)
							{
								AddMountWeapons(value);
								AddLoadoutWeapons(value);
							}
						}
						else if (theUnit.IsGroup)
						{
							foreach (ActiveUnit value2 in ((Group)theUnit).Units.Values)
							{
								AddMountWeapons(value2);
								AddMagazineWeapons(value2);
							}
						}
					}
					else
					{
						AddMountWeapons(theUnit);
						AddMagazineWeapons(theUnit);
					}
				}
				else
				{
					AddMountWeapons(theUnit);
					AddLoadoutWeapons(theUnit);
				}
				list_1 = (from theRec in list_0
					orderby theRec.Type, theRec.WeaponName
					select theRec).ToList();
			}
			if (list_0.Count > 10)
			{
				if (Client.DPI_scale == 1f)
				{
					((Control)this).Height = 190;
				}
				else
				{
					((Control)this).Height = (int)Math.Round(220f * Client.DPI_scale);
				}
			}
			else if (list_0.Count == 0)
			{
				((Control)this).Height = 0;
			}
			else if (Client.DPI_scale == 1f)
			{
				((Control)this).Height = list_0.Count * 19;
			}
			else
			{
				((Control)this).Height = Math.Max(60, (int)Math.Round((float)(list_0.Count * 22) * Client.DPI_scale));
			}
			((Control)this).Visible = true;
		}
		else
		{
			((Control)this).Height = 0;
		}
		if (list_0.Count > 0)
		{
			HasWeapons = true;
		}
		else
		{
			HasWeapons = false;
		}
	}

	public void AddLoadoutWeapons(ActiveUnit theUnit)
	{
		if (Information.IsNothing((object)((Aircraft)theUnit).Loadout))
		{
			return;
		}
		WeaponRec[] weapons = ((Aircraft)theUnit).Loadout.Weapons;
		_Closure$__34-1 closure$__34- = default(_Closure$__34-1);
		_Closure$__34-0 closure$__34-2 = default(_Closure$__34-0);
		for (int i = 0; i < weapons.Length; i = checked(i + 1))
		{
			closure$__34- = new _Closure$__34-1(closure$__34-);
			closure$__34-.$VB$Local_theWeaponRec = weapons[i];
			if (closure$__34-.$VB$Local_theWeaponRec.CurrentLoad <= 0)
			{
				continue;
			}
			Weapon weapon = closure$__34-.$VB$Local_theWeaponRec.get_ReferenceWeapon(Client.CurrentScenario);
			switch (weapon.Type)
			{
			case Weapon._WeaponType.SensorPod:
			{
				using (List<WeaponRec>.Enumerator enumerator = weapon.WeaponWeapons.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						closure$__34-2 = new _Closure$__34-0(closure$__34-2);
						closure$__34-2.$VB$Local_theWeaponWeaponRec = enumerator.Current;
						if (closure$__34-2.$VB$Local_theWeaponWeaponRec.CurrentLoad > 0)
						{
							IEnumerable<Class4> source2 = list_0.Where(closure$__34-2._Lambda$__0);
							if (source2.Count() > 0)
							{
								Class4? class3 = source2.ElementAtOrDefault(0);
								class3.Qty += closure$__34-2.$VB$Local_theWeaponWeaponRec.CurrentLoad;
								class3.WeaponsQuickView = Conversions.ToString(class3.Qty) + "x " + closure$__34-2.$VB$Local_theWeaponWeaponRec.get_ReferenceWeapon(Client.CurrentScenario).Name;
								continue;
							}
							Class4 class4 = new Class4();
							Weapon weapon3 = closure$__34-2.$VB$Local_theWeaponWeaponRec.get_ReferenceWeapon(Client.CurrentScenario);
							class4.WeaponDBID = closure$__34-2.$VB$Local_theWeaponWeaponRec.int_3;
							class4.WeaponName = weapon3.Name;
							class4.Qty = closure$__34-2.$VB$Local_theWeaponWeaponRec.CurrentLoad;
							class4.Type = (int)weapon3.Type;
							class4.WeaponsQuickView = Conversions.ToString(closure$__34-2.$VB$Local_theWeaponWeaponRec.CurrentLoad) + "x " + weapon3.Name;
							list_0.Add(class4);
						}
					}
				}
				break;
			}
			default:
			{
				IEnumerable<Class4> source = list_0.Where(closure$__34-._Lambda$__1);
				if (source.Count() > 0)
				{
					Class4? @class = source.ElementAtOrDefault(0);
					@class.Qty += closure$__34-.$VB$Local_theWeaponRec.CurrentLoad;
					@class.WeaponsQuickView = Conversions.ToString(@class.Qty) + "x " + closure$__34-.$VB$Local_theWeaponRec.get_ReferenceWeapon(Client.CurrentScenario).Name;
					break;
				}
				Class4 class2 = new Class4();
				Weapon weapon2 = closure$__34-.$VB$Local_theWeaponRec.get_ReferenceWeapon(Client.CurrentScenario);
				class2.WeaponDBID = closure$__34-.$VB$Local_theWeaponRec.int_3;
				class2.WeaponName = weapon2.Name;
				class2.Qty = closure$__34-.$VB$Local_theWeaponRec.CurrentLoad;
				class2.Type = (int)weapon2.Type;
				class2.WeaponsQuickView = Conversions.ToString(closure$__34-.$VB$Local_theWeaponRec.CurrentLoad) + "x " + weapon2.Name;
				list_0.Add(class2);
				break;
			}
			case Weapon._WeaponType.TrainingRound:
			case Weapon._WeaponType.DropTank:
			case Weapon._WeaponType.BuddyStore:
			case Weapon._WeaponType.FerryTank:
			case Weapon._WeaponType.HeliTowedPackage:
				break;
			}
		}
	}

	public void AddMagazineWeapons(ActiveUnit theUnit)
	{
		IEnumerable<Magazine> enumerable = theUnit.SharedMagazines.OrderBy([SpecialName] (Magazine theM) => theM.Name);
		_Closure$__35-0 closure$__35- = default(_Closure$__35-0);
		foreach (Magazine item in enumerable)
		{
			if (item.IsAviationMag || item.Status != PlatformComponent._ComponentStatus.Operational)
			{
				continue;
			}
			using List<WeaponRec>.Enumerator enumerator2 = item.Weapons.GetEnumerator();
			while (enumerator2.MoveNext())
			{
				closure$__35- = new _Closure$__35-0(closure$__35-);
				closure$__35-.$VB$Local_theWeaponRec = enumerator2.Current;
				if (closure$__35-.$VB$Local_theWeaponRec.CurrentLoad > 0 && closure$__35-.$VB$Local_theWeaponRec.get_ReferenceWeapon(Client.CurrentScenario).Type != Weapon._WeaponType.TrainingRound)
				{
					int currentLoad = closure$__35-.$VB$Local_theWeaponRec.CurrentLoad;
					IEnumerable<Class4> source = list_0.Where(closure$__35-._Lambda$__1);
					if (source.Count() > 0)
					{
						Class4? @class = source.ElementAtOrDefault(0);
						@class.Qty += currentLoad;
						@class.WeaponsQuickView = Conversions.ToString(@class.Qty) + "x " + closure$__35-.$VB$Local_theWeaponRec.get_ReferenceWeapon(Client.CurrentScenario).Name;
						continue;
					}
					Class4 class2 = new Class4();
					Weapon weapon = closure$__35-.$VB$Local_theWeaponRec.get_ReferenceWeapon(Client.CurrentScenario);
					class2.WeaponDBID = closure$__35-.$VB$Local_theWeaponRec.int_3;
					class2.WeaponName = weapon.Name;
					class2.Qty = currentLoad;
					class2.Type = (int)weapon.Type;
					class2.WeaponsQuickView = Conversions.ToString(currentLoad) + "x " + weapon.Name;
					list_0.Add(class2);
				}
			}
		}
	}

	public void AddMountWeapons(ActiveUnit theUnit)
	{
		IEnumerable<Mount> enumerable = theUnit.Mounts.OrderBy([SpecialName] (Mount theM) => theM.Name);
		_Closure$__36-0 closure$__36- = default(_Closure$__36-0);
		foreach (Mount item in enumerable)
		{
			if (item.Status != PlatformComponent._ComponentStatus.Operational)
			{
				continue;
			}
			using List<WeaponRec>.Enumerator enumerator2 = item.MountWeapons.GetEnumerator();
			while (enumerator2.MoveNext())
			{
				closure$__36- = new _Closure$__36-0(closure$__36-);
				closure$__36-.$VB$Local_theWeaponRec = enumerator2.Current;
				if (closure$__36-.$VB$Local_theWeaponRec.get_ReferenceWeapon(Client.CurrentScenario).Type == Weapon._WeaponType.TrainingRound)
				{
					continue;
				}
				int num = theUnit.Weaponry.HowManyOfThisWeaponOnMountMagazine(item, closure$__36-.$VB$Local_theWeaponRec.int_3);
				int currentLoad = closure$__36-.$VB$Local_theWeaponRec.CurrentLoad;
				if (num > 0 || currentLoad > 0)
				{
					IEnumerable<Class4> source = list_0.Where(closure$__36-._Lambda$__1);
					if (source.Count() > 0)
					{
						Class4? @class = source.ElementAtOrDefault(0);
						@class.Qty = @class.Qty + currentLoad + num;
						@class.WeaponsQuickView = Conversions.ToString(@class.Qty) + "x " + closure$__36-.$VB$Local_theWeaponRec.get_ReferenceWeapon(Client.CurrentScenario).Name;
						continue;
					}
					Class4 class2 = new Class4();
					Weapon weapon = closure$__36-.$VB$Local_theWeaponRec.get_ReferenceWeapon(Client.CurrentScenario);
					class2.WeaponDBID = closure$__36-.$VB$Local_theWeaponRec.int_3;
					class2.WeaponName = weapon.Name;
					class2.Qty = currentLoad + num;
					class2.Type = (int)weapon.Type;
					class2.WeaponsQuickView = Conversions.ToString(currentLoad + num) + "x " + weapon.Name;
					list_0.Add(class2);
				}
			}
		}
	}

	private void method_0(object sender, DataGridViewCellEventArgs e)
	{
		if (e.RowIndex != -1)
		{
			int num = Conversions.ToInteger(((DataGridView)TGV_WeaponsQuickView).Rows[e.RowIndex].Cells["WeaponDBID"].Value);
			int selectedObjectID = num;
			Client.smethod_17("Weapon", selectedObjectID);
		}
	}

	private void method_1(object sender, EventArgs e)
	{
		UpdateData = false;
	}

	private void method_2(object sender, EventArgs e)
	{
		UpdateData = true;
	}

	private void method_3()
	{
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected O, but got Unknown
		((DataGridView)TGV_WeaponsQuickView).Rows.Clear();
		if (Information.IsNothing((object)list_1))
		{
			return;
		}
		foreach (Class4 item in list_1)
		{
			DataGridViewRow val = new DataGridViewRow();
			val.CreateCells((DataGridView)(object)TGV_WeaponsQuickView);
			val.Cells[0].Value = item.WeaponsQuickView;
			val.Cells[1].Value = item.WeaponName;
			val.Cells[2].Value = item.Type;
			val.Cells[3].Value = item.Qty;
			val.Cells[4].Value = item.WeaponDBID;
			((DataGridView)TGV_WeaponsQuickView).Rows.Add(val);
		}
	}

	private void WeaponPanel_Load(object sender, EventArgs e)
	{
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
	}

	static WeaponPanel()
	{
		Class72.smethod_20();
	}
}
