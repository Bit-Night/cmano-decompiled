using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;
using System.Windows.Media;
using Command_Core;
using Command.My;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class FuelPanel_WPF : UserControl, IComponentConnector
{
	private ActiveUnit activeUnit_0;

	[CompilerGenerated]
	[AccessedThroughProperty("LblAirborneTime")]
	private Label label_0;

	[AccessedThroughProperty("JettisonButton")]
	[CompilerGenerated]
	private Button button_0;

	[AccessedThroughProperty("DropHeavyOnlyMenu")]
	[CompilerGenerated]
	private MenuItem cgbYdHdilo;

	[CompilerGenerated]
	[AccessedThroughProperty("DropWeaponsOnlyMenu")]
	private MenuItem menuItem_0;

	[CompilerGenerated]
	[AccessedThroughProperty("DropAllExternalMenu")]
	private MenuItem menuItem_1;

	[CompilerGenerated]
	[AccessedThroughProperty("DropAllMenu")]
	private MenuItem menuItem_2;

	private bool bool_0;

	internal virtual Label LblAirborneTime
	{
		[CompilerGenerated]
		get
		{
			return label_0;
		}
		[CompilerGenerated]
		set
		{
			label_0 = value;
		}
	}

	internal virtual Button JettisonButton
	{
		[CompilerGenerated]
		get
		{
			return button_0;
		}
		[CompilerGenerated]
		set
		{
			button_0 = value;
		}
	}

	internal virtual MenuItem DropHeavyOnlyMenu
	{
		[CompilerGenerated]
		get
		{
			return cgbYdHdilo;
		}
		[CompilerGenerated]
		set
		{
			cgbYdHdilo = value;
		}
	}

	internal virtual MenuItem DropWeaponsOnlyMenu
	{
		[CompilerGenerated]
		get
		{
			return menuItem_0;
		}
		[CompilerGenerated]
		set
		{
			menuItem_0 = value;
		}
	}

	internal virtual MenuItem DropAllExternalMenu
	{
		[CompilerGenerated]
		get
		{
			return menuItem_1;
		}
		[CompilerGenerated]
		set
		{
			menuItem_1 = value;
		}
	}

	internal virtual MenuItem DropAllMenu
	{
		[CompilerGenerated]
		get
		{
			return menuItem_2;
		}
		[CompilerGenerated]
		set
		{
			menuItem_2 = value;
		}
	}

	public FuelPanel_WPF()
	{
		InitializeComponent();
	}

	public void Refresh(ActiveUnit theUnit)
	{
		((UIElement)JettisonButton).Visibility = (Visibility)2;
		try
		{
			activeUnit_0 = theUnit;
			if (theUnit != null)
			{
				if (theUnit.IsAircraft)
				{
					Aircraft aircraft = (Aircraft)activeUnit_0;
					bool flag = false;
					bool flag2 = false;
					bool flag3 = false;
					bool flag4 = false;
					if (!Information.IsNothing((object)aircraft.Loadout))
					{
						WeaponRec[] weapons = aircraft.Loadout.Weapons;
						foreach (WeaponRec weaponRec in weapons)
						{
							if (weaponRec.CurrentLoad == 0 || weaponRec.InternalWeapons)
							{
								continue;
							}
							Weapon weapon = weaponRec.get_ReferenceWeapon(aircraft.ParentScen);
							if (weapon.Type == Weapon._WeaponType.FerryTank)
							{
								continue;
							}
							flag4 = true;
							if (weapon.Type == Weapon._WeaponType.DropTank)
							{
								flag = true;
							}
							if (weapon.IsUnguidedBallisticWeapon || weapon.IsGuidedWeapon())
							{
								if (!weapon.IsAAWCapable)
								{
									flag = true;
								}
								else
								{
									flag2 = true;
								}
							}
							if (weapon.Type == Weapon._WeaponType.SensorPod)
							{
								flag3 = true;
							}
						}
					}
					((UIElement)JettisonButton).Visibility = (Visibility)((!flag4) ? 2 : 0);
					((UIElement)DropHeavyOnlyMenu).IsEnabled = flag;
					((UIElement)DropWeaponsOnlyMenu).IsEnabled = flag2;
					((UIElement)DropAllExternalMenu).IsEnabled = flag || flag2 || flag3;
					((UIElement)DropAllMenu).IsEnabled = flag4;
					Aircraft aircraft2 = (Aircraft)theUnit;
					if (aircraft2.AirborneTime <= 0f)
					{
						string text = "";
						((UIElement)LblAirborneTime).Visibility = (Visibility)2;
					}
					else
					{
						((UIElement)LblAirborneTime).Visibility = (Visibility)0;
						string text = Misc.TimeString((long)Math.Round(aircraft2.AirborneTime), 0, ReturnNo: false, ReturnZero: true);
						if (aircraft2.MAX_Exhaustion != float.MaxValue)
						{
							float current_Exhaustion = ((Aircraft)theUnit).Current_Exhaustion;
							float mAX_Exhaustion = ((Aircraft)theUnit).MAX_Exhaustion;
							float num = current_Exhaustion / mAX_Exhaustion * 100f;
							if (num >= 70f && num <= 100f)
							{
								((Control)LblAirborneTime).Foreground = (Brush)(object)Brushes.Red;
							}
							else if (num >= 50f && num <= 70f)
							{
								((Control)LblAirborneTime).Foreground = (Brush)(object)Brushes.Orange;
							}
							else if (num >= 30f && num <= 50f)
							{
								((Control)LblAirborneTime).Foreground = (Brush)(object)Brushes.Yellow;
							}
							else if (num >= 10f && num <= 30f)
							{
								((Control)LblAirborneTime).Foreground = (Brush)(object)Brushes.Lime;
							}
							else if (num >= 0f && num <= 10f)
							{
								((Control)LblAirborneTime).Foreground = (Brush)(object)Brushes.LightGreen;
							}
							((ContentControl)LblAirborneTime).Content = "Flying Time:" + text + " / " + Misc.TimeString((long)Math.Round(mAX_Exhaustion));
						}
						else
						{
							((Control)LblAirborneTime).Foreground = (Brush)(object)Brushes.White;
							((ContentControl)LblAirborneTime).Content = text + " Flying time";
						}
					}
				}
				else
				{
					((UIElement)LblAirborneTime).Visibility = (Visibility)2;
				}
				if ((!theUnit.CommStuff.IsConnectedToSideNetwork && !Module1.IsSelectedForIsolatedPOV(theUnit) && !Client.CurrentMapProfile.GodsEye) || Client.CurrentSide.AwarenessLevel == Side.AwarenessLevel_Enum.Omniscient)
				{
					((UIElement)this).Visibility = (Visibility)2;
					return;
				}
				((UIElement)this).Visibility = (Visibility)0;
				if (((FrameworkElement)this).DataContext == null)
				{
					((FrameworkElement)this).DataContext = new FuelViewModel(theUnit);
					return;
				}
				FuelViewModel fuelViewModel = (FuelViewModel)((FrameworkElement)this).DataContext;
				if (fuelViewModel.theUnit == theUnit)
				{
					fuelViewModel.Refresh();
				}
				else
				{
					((FrameworkElement)this).DataContext = new FuelViewModel(theUnit);
				}
			}
			else
			{
				((UIElement)this).Visibility = (Visibility)2;
				((FrameworkElement)this).DataContext = null;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_0(object sender, RoutedEventArgs e)
	{
		((FrameworkElement)JettisonButton).ContextMenu.IsOpen = true;
	}

	private void method_1(object sender, RoutedEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		string text = ((HeaderedItemsControl)(MenuItem)sender).Header.ToString();
		if (Operators.CompareString(text, "Drop Heavy Only", true) == 0)
		{
			((Aircraft)activeUnit_0).Weaponry.JettisonOrdnance(ExecuteImmediately: true, JettisonDropTanks: true, JettisonUnguidedAG: true, JettisonGuidedAG: true, bool_12: false, JettisonPod: false, JettisonInternalWeapons: false);
		}
		else if (Operators.CompareString(text, "Drop Weapons Only", true) != 0)
		{
			if (Operators.CompareString(text, "Drop All External", true) != 0)
			{
				if (Operators.CompareString(text, "Drop All", true) == 0)
				{
					((Aircraft)activeUnit_0).Weaponry.JettisonOrdnance(ExecuteImmediately: true, JettisonDropTanks: true, JettisonUnguidedAG: true, JettisonGuidedAG: true, bool_12: true, JettisonPod: true, JettisonInternalWeapons: true);
				}
			}
			else
			{
				((Aircraft)activeUnit_0).Weaponry.JettisonOrdnance(ExecuteImmediately: true, JettisonDropTanks: true, JettisonUnguidedAG: true, JettisonGuidedAG: true, bool_12: true, JettisonPod: true, JettisonInternalWeapons: false);
			}
		}
		else
		{
			((Aircraft)activeUnit_0).Weaponry.JettisonOrdnance(ExecuteImmediately: true, JettisonDropTanks: false, JettisonUnguidedAG: true, JettisonGuidedAG: true, bool_12: true, JettisonPod: false, JettisonInternalWeapons: false);
		}
		MyProject.Forms.MainForm.RightColumnWPF1.ResumeRefresh();
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		if (!bool_0)
		{
			bool_0 = true;
			Uri uri = new Uri("/Command;component/customcontrols/rightcolumn/fuelpanel_wpf.xaml", UriKind.Relative);
			Application.LoadComponent((object)this, uri);
		}
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public void System_Windows_Markup_IComponentConnector_Connect(int connectionId, object target)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Expected O, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected O, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Expected O, but got Unknown
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Expected O, but got Unknown
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Expected O, but got Unknown
		switch (connectionId)
		{
		case 1:
			LblAirborneTime = (Label)target;
			break;
		case 2:
			JettisonButton = (Button)target;
			((ButtonBase)JettisonButton).Click += new RoutedEventHandler(method_0);
			break;
		case 3:
			DropHeavyOnlyMenu = (MenuItem)target;
			DropHeavyOnlyMenu.Click += new RoutedEventHandler(method_1);
			break;
		case 4:
			DropWeaponsOnlyMenu = (MenuItem)target;
			DropWeaponsOnlyMenu.Click += new RoutedEventHandler(method_1);
			break;
		case 5:
			DropAllExternalMenu = (MenuItem)target;
			DropAllExternalMenu.Click += new RoutedEventHandler(method_1);
			break;
		case 6:
			DropAllMenu = (MenuItem)target;
			DropAllMenu.Click += new RoutedEventHandler(method_1);
			break;
		default:
			bool_0 = true;
			break;
		}
	}

	static FuelPanel_WPF()
	{
		Class72.smethod_20();
	}
}
