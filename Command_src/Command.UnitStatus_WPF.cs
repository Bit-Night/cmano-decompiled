using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Command_Core;
using Command.My;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class UnitStatus_WPF : UserControl, IComponentConnector
{
	public delegate void PanelSizeChangedEventHandler();

	public delegate void DamageDetailsFormRequestedEventHandler();

	public delegate void MagazinesFormRequestedEventHandler();

	public delegate void WeaponsFormRequestedEventHandler();

	public delegate void SensorsFormRequestedEventHandler();

	public delegate void CommsFormRequestedEventHandler();

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct VB$StateMachine_41_LoadImage : IAsyncStateMachine
	{
		public int $State;

		public AsyncVoidMethodBuilder $Builder;

		internal Image $VB$Local_imageControl;

		internal string $VB$Local_localPath;

		internal UnitStatus_WPF $VB$Me;

		internal TaskAwaiter<byte[]> $A0;

		[CompilerGenerated]
		internal void MoveNext()
		{
			//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Unknown result type (might be due to invalid IL or missing references)
			//IL_002f: Expected O, but got Unknown
			//IL_018d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0194: Expected O, but got Unknown
			int num = $State;
			try
			{
				if (num == -3 || num == 0)
				{
					goto IL_00d9;
				}
				if (File.Exists($VB$Local_localPath))
				{
					try
					{
						BitmapImage val = new BitmapImage();
						val.BeginInit();
						val.UriSource = new Uri($VB$Local_localPath, UriKind.Absolute);
						val.CacheOption = (BitmapCacheOption)1;
						val.EndInit();
						((UIElement)$VB$Local_imageControl).Visibility = (Visibility)0;
						$VB$Local_imageControl.Source = (ImageSource)(object)val;
						$VB$Me.string_0 = $VB$Me.string_1;
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						$VB$Me.Image_UnitImage.Source = null;
						((UIElement)$VB$Me.Image_UnitImage).Visibility = (Visibility)2;
						ProjectData.ClearProjectError();
					}
				}
				else if (SimConfiguration.DefaultGamePreferences.AllowInGameDownloads)
				{
					goto IL_00d9;
				}
				goto end_IL_0007;
				IL_00d9:
				try
				{
					if (num == -3)
					{
						num = -1;
						$State = -1;
						return;
					}
					TaskAwaiter<byte[]> awaiter;
					if (num != 0)
					{
						HttpClient val2 = new HttpClient();
						string fileName = Path.GetFileName(Path.GetDirectoryName($VB$Local_localPath));
						string fileName2 = Path.GetFileName($VB$Local_localPath);
						string text = "http://warfaresims.slitherine.com/DBImages/" + fileName + "/" + fileName2;
						awaiter = val2.GetByteArrayAsync(text).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = 0;
							$State = 0;
							$A0 = awaiter;
							$Builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
							return;
						}
					}
					else
					{
						num = -1;
						$State = -1;
						awaiter = $A0;
						$A0 = default(TaskAwaiter<byte[]>);
					}
					byte[] result = awaiter.GetResult();
					awaiter = default(TaskAwaiter<byte[]>);
					byte[] array = result;
					MemoryStream memoryStream = new MemoryStream(array);
					try
					{
						BitmapImage val3 = new BitmapImage();
						val3.BeginInit();
						val3.CacheOption = (BitmapCacheOption)1;
						val3.StreamSource = memoryStream;
						val3.EndInit();
						((Freezable)val3).Freeze();
						$VB$Local_imageControl.Source = (ImageSource)(object)val3;
						((UIElement)$VB$Local_imageControl).Visibility = (Visibility)0;
					}
					finally
					{
						if (num < 0)
						{
							((IDisposable)memoryStream)?.Dispose();
						}
					}
					File.WriteAllBytes($VB$Local_localPath, array);
					$VB$Me.string_0 = $VB$Me.string_1;
				}
				catch (Exception projectError2)
				{
					ProjectData.SetProjectError(projectError2);
					$VB$Me.Image_UnitImage.Source = null;
					((UIElement)$VB$Me.Image_UnitImage).Visibility = (Visibility)2;
					ProjectData.ClearProjectError();
				}
				end_IL_0007:;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception = ex;
				$State = -2;
				$Builder.SetException(exception);
				ProjectData.ClearProjectError();
				return;
			}
			num = -2;
			$State = -2;
			$Builder.SetResult();
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			$Builder.SetStateMachine(stateMachine);
		}

		static VB$StateMachine_41_LoadImage()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__55-0
	{
		public string $VB$Local_UCString;

		public _Closure$__55-0(_Closure$__55-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_UCString = arg0.$VB$Local_UCString;
			}
		}

		[SpecialName]
		internal bool _Lambda$__5(ActiveUnit theAU)
		{
			return string.CompareOrdinal(Misc.RemoveHiddenString(theAU.UnitClass), $VB$Local_UCString) == 0;
		}

		static _Closure$__55-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	private static PanelSizeChangedEventHandler panelSizeChangedEventHandler_0;

	[CompilerGenerated]
	private static DamageDetailsFormRequestedEventHandler damageDetailsFormRequestedEventHandler_0;

	[CompilerGenerated]
	private static MagazinesFormRequestedEventHandler magazinesFormRequestedEventHandler_0;

	[CompilerGenerated]
	private static WeaponsFormRequestedEventHandler weaponsFormRequestedEventHandler_0;

	[CompilerGenerated]
	private static SensorsFormRequestedEventHandler sensorsFormRequestedEventHandler_0;

	[CompilerGenerated]
	private static CommsFormRequestedEventHandler commsFormRequestedEventHandler_0;

	private Group group_0;

	private ActiveUnit activeUnit_0;

	private Contact contact_0;

	private string string_0;

	private int int_0;

	private DBOps.DBFileCheckResult dbfileCheckResult_0;

	private BitmapImage bitmapImage_0;

	private string string_1;

	private BitmapImage bitmapImage_1;

	[CompilerGenerated]
	[AccessedThroughProperty("MasterGrid")]
	private Grid grid_0;

	[AccessedThroughProperty("Label_UnitName")]
	[CompilerGenerated]
	private Label label_0;

	[AccessedThroughProperty("Image_UnitImage")]
	[CompilerGenerated]
	private Image image_0;

	[AccessedThroughProperty("OuterTextBlock_UnitClass")]
	[CompilerGenerated]
	private TextBlock textBlock_0;

	[AccessedThroughProperty("Hyperlink_UnitClass")]
	[CompilerGenerated]
	private Hyperlink hyperlink_0;

	[AccessedThroughProperty("TextBlock_UnitClass")]
	[CompilerGenerated]
	private Run run_0;

	[AccessedThroughProperty("OuterTextBlock_UnitCategory")]
	[CompilerGenerated]
	private TextBlock textBlock_1;

	[CompilerGenerated]
	[AccessedThroughProperty("TextBlock_UnitCategory")]
	private Run run_1;

	[CompilerGenerated]
	[AccessedThroughProperty("OuterTextBlock_UnitType")]
	private TextBlock textBlock_2;

	[CompilerGenerated]
	[AccessedThroughProperty("TextBlock_UnitType")]
	private Run run_2;

	[AccessedThroughProperty("OuterTextBlock_FiringParent")]
	[CompilerGenerated]
	private TextBlock textBlock_3;

	[CompilerGenerated]
	[AccessedThroughProperty("TextBlock_FiringParent")]
	private Run run_3;

	[CompilerGenerated]
	[AccessedThroughProperty("Label_UnitProficiency")]
	private Label label_1;

	[CompilerGenerated]
	[AccessedThroughProperty("Label_UnitKills")]
	private Label label_2;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_ContactReport")]
	private Button button_0;

	[AccessedThroughProperty("Button_UnitMessageLog")]
	[CompilerGenerated]
	private Button button_1;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_UnitAIDebug")]
	private Button button_2;

	[AccessedThroughProperty("Expander_GroupMembers")]
	[CompilerGenerated]
	private Expander expander_0;

	[AccessedThroughProperty("ListView_GroupMembers")]
	[CompilerGenerated]
	private ListView listView_0;

	[CompilerGenerated]
	[AccessedThroughProperty("TextBlock_Loadout")]
	private TextBlock textBlock_4;

	[AccessedThroughProperty("Hyperlink_Loadout")]
	[CompilerGenerated]
	private Hyperlink hyperlink_1;

	[AccessedThroughProperty("TextBlock_LoadoutName")]
	[CompilerGenerated]
	private Run run_4;

	[CompilerGenerated]
	[AccessedThroughProperty("Label_UnitSide")]
	private Label label_3;

	[CompilerGenerated]
	[AccessedThroughProperty("Label_UnitCourse")]
	private Label label_4;

	[CompilerGenerated]
	[AccessedThroughProperty("Label_UnitSpeed")]
	private Label label_5;

	[CompilerGenerated]
	[AccessedThroughProperty("Label_UnitAlt")]
	private Label label_6;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_GroupLeadSlowDown")]
	private CheckBox checkBox_0;

	[CompilerGenerated]
	[AccessedThroughProperty("Label_DamageLabel")]
	private Label label_7;

	[AccessedThroughProperty("Label_UnitDamage")]
	[CompilerGenerated]
	private TextBlock textBlock_5;

	[AccessedThroughProperty("Button_Damage")]
	[CompilerGenerated]
	private Button button_3;

	[CompilerGenerated]
	[AccessedThroughProperty("ComponentStatusLabel")]
	private Label label_8;

	[CompilerGenerated]
	[AccessedThroughProperty("ComponentStatusDockPanel")]
	private DockPanel dockPanel_0;

	[CompilerGenerated]
	[AccessedThroughProperty("PB_ComponentsDestroyed")]
	private ProgressBar progressBar_0;

	[AccessedThroughProperty("PB_ComponentsHeavyDamage")]
	[CompilerGenerated]
	private ProgressBar progressBar_1;

	[CompilerGenerated]
	[AccessedThroughProperty("PB_ComponentsMediumDamage")]
	private ProgressBar progressBar_2;

	[CompilerGenerated]
	[AccessedThroughProperty("PB_ComponentsLightDamage")]
	private ProgressBar progressBar_3;

	[CompilerGenerated]
	[AccessedThroughProperty("PB_ComponentsOK")]
	private ProgressBar progressBar_4;

	[CompilerGenerated]
	[AccessedThroughProperty("Label_FireDamage")]
	private Label label_9;

	[CompilerGenerated]
	[AccessedThroughProperty("PB_FireDamage")]
	private ProgressBar progressBar_5;

	[AccessedThroughProperty("Label_FloodDamage")]
	[CompilerGenerated]
	private Label label_10;

	[CompilerGenerated]
	[AccessedThroughProperty("PB_FloodDamage")]
	private ProgressBar progressBar_6;

	[CompilerGenerated]
	[AccessedThroughProperty("Label_GTolerance")]
	private Label label_11;

	[AccessedThroughProperty("PB_GTolerance")]
	[CompilerGenerated]
	private ProgressBar progressBar_7;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_MCM")]
	private Button button_4;

	[AccessedThroughProperty("Button_CargoOps")]
	[CompilerGenerated]
	private Button button_5;

	[AccessedThroughProperty("Button_Magazines")]
	[CompilerGenerated]
	private Button button_6;

	[AccessedThroughProperty("Button_DockOps")]
	[CompilerGenerated]
	private Button button_7;

	[AccessedThroughProperty("Button_AirOps")]
	[CompilerGenerated]
	private Button button_8;

	[AccessedThroughProperty("Label_Supply")]
	[CompilerGenerated]
	private Label label_12;

	[CompilerGenerated]
	[AccessedThroughProperty("Combo_Supplier")]
	private ComboBox comboBox_0;

	[CompilerGenerated]
	[AccessedThroughProperty("Dockpanel_EditHosted")]
	private DockPanel dockPanel_1;

	[AccessedThroughProperty("Button_EditHostCargo")]
	[CompilerGenerated]
	private Button button_9;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_EditHostedBoats")]
	private Button button_10;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_EditHostedAC")]
	private Button button_11;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_EditAGU")]
	private Button button_12;

	[CompilerGenerated]
	[AccessedThroughProperty("TextBlock_AssignedHost")]
	private TextBlock textBlock_6;

	[CompilerGenerated]
	[AccessedThroughProperty("TextBlock_Mission")]
	private TextBlock textBlock_7;

	[AccessedThroughProperty("Hyperlink_Mission")]
	[CompilerGenerated]
	private Hyperlink hyperlink_2;

	[CompilerGenerated]
	[AccessedThroughProperty("TextBlock_MissionName")]
	private Run run_5;

	[CompilerGenerated]
	[AccessedThroughProperty("TextBlock_QueuedMission")]
	private TextBlock textBlock_8;

	[CompilerGenerated]
	[AccessedThroughProperty("tip1")]
	private ToolTip toolTip_0;

	[AccessedThroughProperty("TextBlock_UnitStatus")]
	[CompilerGenerated]
	private TextBlock textBlock_9;

	[CompilerGenerated]
	[AccessedThroughProperty("TextBlock_PrimaryTarget")]
	private TextBlock textBlock_10;

	[AccessedThroughProperty("Run_PrimaryTargetName")]
	[CompilerGenerated]
	private Run run_6;

	[AccessedThroughProperty("TextBlock_TimeUnderway")]
	[CompilerGenerated]
	private TextBlock textBlock_11;

	[CompilerGenerated]
	[AccessedThroughProperty("Expander_TankerClients")]
	private Expander expander_1;

	[AccessedThroughProperty("ListView_TankerClients")]
	[CompilerGenerated]
	private ListView listView_1;

	[AccessedThroughProperty("Button_Sensors")]
	[CompilerGenerated]
	private Button button_13;

	[AccessedThroughProperty("Button_Comms")]
	[CompilerGenerated]
	private Button button_14;

	[AccessedThroughProperty("Button_Weapons")]
	[CompilerGenerated]
	private Button button_15;

	[CompilerGenerated]
	[AccessedThroughProperty("Label_ContactWRAType")]
	private Label label_13;

	private bool bool_0;

	internal virtual Grid MasterGrid
	{
		[CompilerGenerated]
		get
		{
			return grid_0;
		}
		[CompilerGenerated]
		set
		{
			grid_0 = value;
		}
	}

	internal virtual Label Label_UnitName
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

	internal virtual Image Image_UnitImage
	{
		[CompilerGenerated]
		get
		{
			return image_0;
		}
		[CompilerGenerated]
		set
		{
			image_0 = value;
		}
	}

	internal virtual TextBlock OuterTextBlock_UnitClass
	{
		[CompilerGenerated]
		get
		{
			return textBlock_0;
		}
		[CompilerGenerated]
		set
		{
			textBlock_0 = value;
		}
	}

	internal virtual Hyperlink Hyperlink_UnitClass
	{
		[CompilerGenerated]
		get
		{
			return hyperlink_0;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			RoutedEventHandler val = new RoutedEventHandler(method_26);
			Hyperlink val2 = hyperlink_0;
			if (val2 != null)
			{
				val2.Click -= val;
			}
			hyperlink_0 = value;
			val2 = hyperlink_0;
			if (val2 != null)
			{
				val2.Click += val;
			}
		}
	}

	internal virtual Run TextBlock_UnitClass
	{
		[CompilerGenerated]
		get
		{
			return run_0;
		}
		[CompilerGenerated]
		set
		{
			run_0 = value;
		}
	}

	internal virtual TextBlock OuterTextBlock_UnitCategory
	{
		[CompilerGenerated]
		get
		{
			return textBlock_1;
		}
		[CompilerGenerated]
		set
		{
			textBlock_1 = value;
		}
	}

	internal virtual Run TextBlock_UnitCategory
	{
		[CompilerGenerated]
		get
		{
			return run_1;
		}
		[CompilerGenerated]
		set
		{
			run_1 = value;
		}
	}

	internal virtual TextBlock OuterTextBlock_UnitType
	{
		[CompilerGenerated]
		get
		{
			return textBlock_2;
		}
		[CompilerGenerated]
		set
		{
			textBlock_2 = value;
		}
	}

	internal virtual Run TextBlock_UnitType
	{
		[CompilerGenerated]
		get
		{
			return run_2;
		}
		[CompilerGenerated]
		set
		{
			run_2 = value;
		}
	}

	internal virtual TextBlock OuterTextBlock_FiringParent
	{
		[CompilerGenerated]
		get
		{
			return textBlock_3;
		}
		[CompilerGenerated]
		set
		{
			textBlock_3 = value;
		}
	}

	internal virtual Run TextBlock_FiringParent
	{
		[CompilerGenerated]
		get
		{
			return run_3;
		}
		[CompilerGenerated]
		set
		{
			run_3 = value;
		}
	}

	internal virtual Label Label_UnitProficiency
	{
		[CompilerGenerated]
		get
		{
			return label_1;
		}
		[CompilerGenerated]
		set
		{
			label_1 = value;
		}
	}

	internal virtual Label Label_UnitKills
	{
		[CompilerGenerated]
		get
		{
			return label_2;
		}
		[CompilerGenerated]
		set
		{
			label_2 = value;
		}
	}

	internal virtual Button Button_ContactReport
	{
		[CompilerGenerated]
		get
		{
			return button_0;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			RoutedEventHandler val = new RoutedEventHandler(method_19);
			Button val2 = button_0;
			if (val2 != null)
			{
				((ButtonBase)val2).Click -= val;
			}
			button_0 = value;
			val2 = button_0;
			if (val2 != null)
			{
				((ButtonBase)val2).Click += val;
			}
		}
	}

	internal virtual Button Button_UnitMessageLog
	{
		[CompilerGenerated]
		get
		{
			return button_1;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			RoutedEventHandler val = new RoutedEventHandler(method_28);
			Button val2 = button_1;
			if (val2 != null)
			{
				((ButtonBase)val2).Click -= val;
			}
			button_1 = value;
			val2 = button_1;
			if (val2 != null)
			{
				((ButtonBase)val2).Click += val;
			}
		}
	}

	internal virtual Button Button_UnitAIDebug
	{
		[CompilerGenerated]
		get
		{
			return button_2;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			RoutedEventHandler val = new RoutedEventHandler(method_29);
			Button val2 = button_2;
			if (val2 != null)
			{
				((ButtonBase)val2).Click -= val;
			}
			button_2 = value;
			val2 = button_2;
			if (val2 != null)
			{
				((ButtonBase)val2).Click += val;
			}
		}
	}

	internal virtual Expander Expander_GroupMembers
	{
		[CompilerGenerated]
		get
		{
			return expander_0;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			RoutedEventHandler val = new RoutedEventHandler(method_14);
			RoutedEventHandler val2 = new RoutedEventHandler(method_15);
			Expander val3 = expander_0;
			if (val3 != null)
			{
				val3.Collapsed -= val;
				val3.Expanded -= val2;
			}
			expander_0 = value;
			val3 = expander_0;
			if (val3 != null)
			{
				val3.Collapsed += val;
				val3.Expanded += val2;
			}
		}
	}

	internal virtual ListView ListView_GroupMembers
	{
		[CompilerGenerated]
		get
		{
			return listView_0;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			SelectionChangedEventHandler val = new SelectionChangedEventHandler(method_23);
			ListView val2 = listView_0;
			if (val2 != null)
			{
				((Selector)val2).SelectionChanged -= val;
			}
			listView_0 = value;
			val2 = listView_0;
			if (val2 != null)
			{
				((Selector)val2).SelectionChanged += val;
			}
		}
	}

	public virtual TextBlock TextBlock_Loadout
	{
		[CompilerGenerated]
		get
		{
			return textBlock_4;
		}
		[CompilerGenerated]
		set
		{
			textBlock_4 = value;
		}
	}

	internal virtual Hyperlink Hyperlink_Loadout
	{
		[CompilerGenerated]
		get
		{
			return hyperlink_1;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			RoutedEventHandler val = new RoutedEventHandler(method_27);
			Hyperlink val2 = hyperlink_1;
			if (val2 != null)
			{
				val2.Click -= val;
			}
			hyperlink_1 = value;
			val2 = hyperlink_1;
			if (val2 != null)
			{
				val2.Click += val;
			}
		}
	}

	internal virtual Run TextBlock_LoadoutName
	{
		[CompilerGenerated]
		get
		{
			return run_4;
		}
		[CompilerGenerated]
		set
		{
			run_4 = value;
		}
	}

	internal virtual Label Label_UnitSide
	{
		[CompilerGenerated]
		get
		{
			return label_3;
		}
		[CompilerGenerated]
		set
		{
			label_3 = value;
		}
	}

	internal virtual Label Label_UnitCourse
	{
		[CompilerGenerated]
		get
		{
			return label_4;
		}
		[CompilerGenerated]
		set
		{
			label_4 = value;
		}
	}

	internal virtual Label Label_UnitSpeed
	{
		[CompilerGenerated]
		get
		{
			return label_5;
		}
		[CompilerGenerated]
		set
		{
			label_5 = value;
		}
	}

	internal virtual Label Label_UnitAlt
	{
		[CompilerGenerated]
		get
		{
			return label_6;
		}
		[CompilerGenerated]
		set
		{
			label_6 = value;
		}
	}

	internal virtual CheckBox CB_GroupLeadSlowDown
	{
		[CompilerGenerated]
		get
		{
			return checkBox_0;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			RoutedEventHandler val = new RoutedEventHandler(method_24);
			CheckBox val2 = checkBox_0;
			if (val2 != null)
			{
				((ButtonBase)val2).Click -= val;
			}
			checkBox_0 = value;
			val2 = checkBox_0;
			if (val2 != null)
			{
				((ButtonBase)val2).Click += val;
			}
		}
	}

	internal virtual Label Label_DamageLabel
	{
		[CompilerGenerated]
		get
		{
			return label_7;
		}
		[CompilerGenerated]
		set
		{
			label_7 = value;
		}
	}

	internal virtual TextBlock Label_UnitDamage
	{
		[CompilerGenerated]
		get
		{
			return textBlock_5;
		}
		[CompilerGenerated]
		set
		{
			textBlock_5 = value;
		}
	}

	internal virtual Button Button_Damage
	{
		[CompilerGenerated]
		get
		{
			return button_3;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			RoutedEventHandler val = new RoutedEventHandler(method_7);
			Button val2 = button_3;
			if (val2 != null)
			{
				((ButtonBase)val2).Click -= val;
			}
			button_3 = value;
			val2 = button_3;
			if (val2 != null)
			{
				((ButtonBase)val2).Click += val;
			}
		}
	}

	internal virtual Label ComponentStatusLabel
	{
		[CompilerGenerated]
		get
		{
			return label_8;
		}
		[CompilerGenerated]
		set
		{
			label_8 = value;
		}
	}

	internal virtual DockPanel ComponentStatusDockPanel
	{
		[CompilerGenerated]
		get
		{
			return dockPanel_0;
		}
		[CompilerGenerated]
		set
		{
			dockPanel_0 = value;
		}
	}

	internal virtual ProgressBar PB_ComponentsDestroyed
	{
		[CompilerGenerated]
		get
		{
			return progressBar_0;
		}
		[CompilerGenerated]
		set
		{
			progressBar_0 = value;
		}
	}

	internal virtual ProgressBar PB_ComponentsHeavyDamage
	{
		[CompilerGenerated]
		get
		{
			return progressBar_1;
		}
		[CompilerGenerated]
		set
		{
			progressBar_1 = value;
		}
	}

	internal virtual ProgressBar PB_ComponentsMediumDamage
	{
		[CompilerGenerated]
		get
		{
			return progressBar_2;
		}
		[CompilerGenerated]
		set
		{
			progressBar_2 = value;
		}
	}

	internal virtual ProgressBar PB_ComponentsLightDamage
	{
		[CompilerGenerated]
		get
		{
			return progressBar_3;
		}
		[CompilerGenerated]
		set
		{
			progressBar_3 = value;
		}
	}

	internal virtual ProgressBar PB_ComponentsOK
	{
		[CompilerGenerated]
		get
		{
			return progressBar_4;
		}
		[CompilerGenerated]
		set
		{
			progressBar_4 = value;
		}
	}

	internal virtual Label Label_FireDamage
	{
		[CompilerGenerated]
		get
		{
			return label_9;
		}
		[CompilerGenerated]
		set
		{
			label_9 = value;
		}
	}

	internal virtual ProgressBar PB_FireDamage
	{
		[CompilerGenerated]
		get
		{
			return progressBar_5;
		}
		[CompilerGenerated]
		set
		{
			progressBar_5 = value;
		}
	}

	internal virtual Label Label_FloodDamage
	{
		[CompilerGenerated]
		get
		{
			return label_10;
		}
		[CompilerGenerated]
		set
		{
			label_10 = value;
		}
	}

	internal virtual ProgressBar PB_FloodDamage
	{
		[CompilerGenerated]
		get
		{
			return progressBar_6;
		}
		[CompilerGenerated]
		set
		{
			progressBar_6 = value;
		}
	}

	internal virtual Label Label_GTolerance
	{
		[CompilerGenerated]
		get
		{
			return label_11;
		}
		[CompilerGenerated]
		set
		{
			label_11 = value;
		}
	}

	internal virtual ProgressBar PB_GTolerance
	{
		[CompilerGenerated]
		get
		{
			return progressBar_7;
		}
		[CompilerGenerated]
		set
		{
			progressBar_7 = value;
		}
	}

	internal virtual Button Button_MCM
	{
		[CompilerGenerated]
		get
		{
			return button_4;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			RoutedEventHandler val = new RoutedEventHandler(method_22);
			Button val2 = button_4;
			if (val2 != null)
			{
				((ButtonBase)val2).Click -= val;
			}
			button_4 = value;
			val2 = button_4;
			if (val2 != null)
			{
				((ButtonBase)val2).Click += val;
			}
		}
	}

	internal virtual Button Button_CargoOps
	{
		[CompilerGenerated]
		get
		{
			return button_5;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			RoutedEventHandler val = new RoutedEventHandler(method_20);
			Button val2 = button_5;
			if (val2 != null)
			{
				((ButtonBase)val2).Click -= val;
			}
			button_5 = value;
			val2 = button_5;
			if (val2 != null)
			{
				((ButtonBase)val2).Click += val;
			}
		}
	}

	internal virtual Button Button_Magazines
	{
		[CompilerGenerated]
		get
		{
			return button_6;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			RoutedEventHandler val = new RoutedEventHandler(method_9);
			Button val2 = button_6;
			if (val2 != null)
			{
				((ButtonBase)val2).Click -= val;
			}
			button_6 = value;
			val2 = button_6;
			if (val2 != null)
			{
				((ButtonBase)val2).Click += val;
			}
		}
	}

	internal virtual Button Button_DockOps
	{
		[CompilerGenerated]
		get
		{
			return button_7;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			RoutedEventHandler val = new RoutedEventHandler(method_21);
			Button val2 = button_7;
			if (val2 != null)
			{
				((ButtonBase)val2).Click -= val;
			}
			button_7 = value;
			val2 = button_7;
			if (val2 != null)
			{
				((ButtonBase)val2).Click += val;
			}
		}
	}

	internal virtual Button Button_AirOps
	{
		[CompilerGenerated]
		get
		{
			return button_8;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			RoutedEventHandler val = new RoutedEventHandler(method_8);
			Button val2 = button_8;
			if (val2 != null)
			{
				((ButtonBase)val2).Click -= val;
			}
			button_8 = value;
			val2 = button_8;
			if (val2 != null)
			{
				((ButtonBase)val2).Click += val;
			}
		}
	}

	internal virtual Label Label_Supply
	{
		[CompilerGenerated]
		get
		{
			return label_12;
		}
		[CompilerGenerated]
		set
		{
			label_12 = value;
		}
	}

	internal virtual ComboBox Combo_Supplier
	{
		[CompilerGenerated]
		get
		{
			return comboBox_0;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			SelectionChangedEventHandler val = new SelectionChangedEventHandler(method_44);
			ComboBox val2 = comboBox_0;
			if (val2 != null)
			{
				((Selector)val2).SelectionChanged -= val;
			}
			comboBox_0 = value;
			val2 = comboBox_0;
			if (val2 != null)
			{
				((Selector)val2).SelectionChanged += val;
			}
		}
	}

	internal virtual DockPanel Dockpanel_EditHosted
	{
		[CompilerGenerated]
		get
		{
			return dockPanel_1;
		}
		[CompilerGenerated]
		set
		{
			dockPanel_1 = value;
		}
	}

	internal virtual Button Button_EditHostCargo
	{
		[CompilerGenerated]
		get
		{
			return button_9;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			RoutedEventHandler val = new RoutedEventHandler(method_43);
			Button val2 = button_9;
			if (val2 != null)
			{
				((ButtonBase)val2).Click -= val;
			}
			button_9 = value;
			val2 = button_9;
			if (val2 != null)
			{
				((ButtonBase)val2).Click += val;
			}
		}
	}

	internal virtual Button Button_EditHostedBoats
	{
		[CompilerGenerated]
		get
		{
			return button_10;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			RoutedEventHandler val = new RoutedEventHandler(method_40);
			Button val2 = button_10;
			if (val2 != null)
			{
				((ButtonBase)val2).Click -= val;
			}
			button_10 = value;
			val2 = button_10;
			if (val2 != null)
			{
				((ButtonBase)val2).Click += val;
			}
		}
	}

	internal virtual Button Button_EditHostedAC
	{
		[CompilerGenerated]
		get
		{
			return button_11;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			RoutedEventHandler val = new RoutedEventHandler(method_41);
			Button val2 = button_11;
			if (val2 != null)
			{
				((ButtonBase)val2).Click -= val;
			}
			button_11 = value;
			val2 = button_11;
			if (val2 != null)
			{
				((ButtonBase)val2).Click += val;
			}
		}
	}

	internal virtual Button Button_EditAGU
	{
		[CompilerGenerated]
		get
		{
			return button_12;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			RoutedEventHandler val = new RoutedEventHandler(method_42);
			Button val2 = button_12;
			if (val2 != null)
			{
				((ButtonBase)val2).Click -= val;
			}
			button_12 = value;
			val2 = button_12;
			if (val2 != null)
			{
				((ButtonBase)val2).Click += val;
			}
		}
	}

	internal virtual TextBlock TextBlock_AssignedHost
	{
		[CompilerGenerated]
		get
		{
			return textBlock_6;
		}
		[CompilerGenerated]
		set
		{
			textBlock_6 = value;
		}
	}

	internal virtual TextBlock TextBlock_Mission
	{
		[CompilerGenerated]
		get
		{
			return textBlock_7;
		}
		[CompilerGenerated]
		set
		{
			textBlock_7 = value;
		}
	}

	internal virtual Hyperlink Hyperlink_Mission
	{
		[CompilerGenerated]
		get
		{
			return hyperlink_2;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			RoutedEventHandler val = new RoutedEventHandler(method_25);
			Hyperlink val2 = hyperlink_2;
			if (val2 != null)
			{
				val2.Click -= val;
			}
			hyperlink_2 = value;
			val2 = hyperlink_2;
			if (val2 != null)
			{
				val2.Click += val;
			}
		}
	}

	internal virtual Run TextBlock_MissionName
	{
		[CompilerGenerated]
		get
		{
			return run_5;
		}
		[CompilerGenerated]
		set
		{
			run_5 = value;
		}
	}

	internal virtual TextBlock TextBlock_QueuedMission
	{
		[CompilerGenerated]
		get
		{
			return textBlock_8;
		}
		[CompilerGenerated]
		set
		{
			textBlock_8 = value;
		}
	}

	internal virtual ToolTip tip1
	{
		[CompilerGenerated]
		get
		{
			return toolTip_0;
		}
		[CompilerGenerated]
		set
		{
			toolTip_0 = value;
		}
	}

	internal virtual TextBlock TextBlock_UnitStatus
	{
		[CompilerGenerated]
		get
		{
			return textBlock_9;
		}
		[CompilerGenerated]
		set
		{
			textBlock_9 = value;
		}
	}

	internal virtual TextBlock TextBlock_PrimaryTarget
	{
		[CompilerGenerated]
		get
		{
			return textBlock_10;
		}
		[CompilerGenerated]
		set
		{
			textBlock_10 = value;
		}
	}

	internal virtual Run Run_PrimaryTargetName
	{
		[CompilerGenerated]
		get
		{
			return run_6;
		}
		[CompilerGenerated]
		set
		{
			run_6 = value;
		}
	}

	internal virtual TextBlock TextBlock_TimeUnderway
	{
		[CompilerGenerated]
		get
		{
			return textBlock_11;
		}
		[CompilerGenerated]
		set
		{
			textBlock_11 = value;
		}
	}

	internal virtual Expander Expander_TankerClients
	{
		[CompilerGenerated]
		get
		{
			return expander_1;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			RoutedEventHandler val = new RoutedEventHandler(method_16);
			RoutedEventHandler val2 = new RoutedEventHandler(method_17);
			Expander val3 = expander_1;
			if (val3 != null)
			{
				val3.Collapsed -= val;
				val3.Expanded -= val2;
			}
			expander_1 = value;
			val3 = expander_1;
			if (val3 != null)
			{
				val3.Collapsed += val;
				val3.Expanded += val2;
			}
		}
	}

	internal virtual ListView ListView_TankerClients
	{
		[CompilerGenerated]
		get
		{
			return listView_1;
		}
		[CompilerGenerated]
		set
		{
			listView_1 = value;
		}
	}

	internal virtual Button Button_Sensors
	{
		[CompilerGenerated]
		get
		{
			return button_13;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			RoutedEventHandler val = new RoutedEventHandler(method_10);
			Button val2 = button_13;
			if (val2 != null)
			{
				((ButtonBase)val2).Click -= val;
			}
			button_13 = value;
			val2 = button_13;
			if (val2 != null)
			{
				((ButtonBase)val2).Click += val;
			}
		}
	}

	internal virtual Button Button_Comms
	{
		[CompilerGenerated]
		get
		{
			return button_14;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			RoutedEventHandler val = new RoutedEventHandler(method_12);
			Button val2 = button_14;
			if (val2 != null)
			{
				((ButtonBase)val2).Click -= val;
			}
			button_14 = value;
			val2 = button_14;
			if (val2 != null)
			{
				((ButtonBase)val2).Click += val;
			}
		}
	}

	internal virtual Button Button_Weapons
	{
		[CompilerGenerated]
		get
		{
			return button_15;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			RoutedEventHandler val = new RoutedEventHandler(method_11);
			Button val2 = button_15;
			if (val2 != null)
			{
				((ButtonBase)val2).Click -= val;
			}
			button_15 = value;
			val2 = button_15;
			if (val2 != null)
			{
				((ButtonBase)val2).Click += val;
			}
		}
	}

	internal virtual Label Label_ContactWRAType
	{
		[CompilerGenerated]
		get
		{
			return label_13;
		}
		[CompilerGenerated]
		set
		{
			label_13 = value;
		}
	}

	public static event PanelSizeChangedEventHandler PanelSizeChanged
	{
		[CompilerGenerated]
		add
		{
			PanelSizeChangedEventHandler panelSizeChangedEventHandler = panelSizeChangedEventHandler_0;
			PanelSizeChangedEventHandler panelSizeChangedEventHandler2;
			do
			{
				panelSizeChangedEventHandler2 = panelSizeChangedEventHandler;
				PanelSizeChangedEventHandler value2 = (PanelSizeChangedEventHandler)Delegate.Combine(panelSizeChangedEventHandler2, value);
				panelSizeChangedEventHandler = Interlocked.CompareExchange(ref panelSizeChangedEventHandler_0, value2, panelSizeChangedEventHandler2);
			}
			while ((object)panelSizeChangedEventHandler != panelSizeChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			PanelSizeChangedEventHandler panelSizeChangedEventHandler = panelSizeChangedEventHandler_0;
			PanelSizeChangedEventHandler panelSizeChangedEventHandler2;
			do
			{
				panelSizeChangedEventHandler2 = panelSizeChangedEventHandler;
				PanelSizeChangedEventHandler value2 = (PanelSizeChangedEventHandler)Delegate.Remove(panelSizeChangedEventHandler2, value);
				panelSizeChangedEventHandler = Interlocked.CompareExchange(ref panelSizeChangedEventHandler_0, value2, panelSizeChangedEventHandler2);
			}
			while ((object)panelSizeChangedEventHandler != panelSizeChangedEventHandler2);
		}
	}

	public static event DamageDetailsFormRequestedEventHandler DamageDetailsFormRequested
	{
		[CompilerGenerated]
		add
		{
			DamageDetailsFormRequestedEventHandler damageDetailsFormRequestedEventHandler = damageDetailsFormRequestedEventHandler_0;
			DamageDetailsFormRequestedEventHandler damageDetailsFormRequestedEventHandler2;
			do
			{
				damageDetailsFormRequestedEventHandler2 = damageDetailsFormRequestedEventHandler;
				DamageDetailsFormRequestedEventHandler value2 = (DamageDetailsFormRequestedEventHandler)Delegate.Combine(damageDetailsFormRequestedEventHandler2, value);
				damageDetailsFormRequestedEventHandler = Interlocked.CompareExchange(ref damageDetailsFormRequestedEventHandler_0, value2, damageDetailsFormRequestedEventHandler2);
			}
			while ((object)damageDetailsFormRequestedEventHandler != damageDetailsFormRequestedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			DamageDetailsFormRequestedEventHandler damageDetailsFormRequestedEventHandler = damageDetailsFormRequestedEventHandler_0;
			DamageDetailsFormRequestedEventHandler damageDetailsFormRequestedEventHandler2;
			do
			{
				damageDetailsFormRequestedEventHandler2 = damageDetailsFormRequestedEventHandler;
				DamageDetailsFormRequestedEventHandler value2 = (DamageDetailsFormRequestedEventHandler)Delegate.Remove(damageDetailsFormRequestedEventHandler2, value);
				damageDetailsFormRequestedEventHandler = Interlocked.CompareExchange(ref damageDetailsFormRequestedEventHandler_0, value2, damageDetailsFormRequestedEventHandler2);
			}
			while ((object)damageDetailsFormRequestedEventHandler != damageDetailsFormRequestedEventHandler2);
		}
	}

	public static event MagazinesFormRequestedEventHandler MagazinesFormRequested
	{
		[CompilerGenerated]
		add
		{
			MagazinesFormRequestedEventHandler magazinesFormRequestedEventHandler = magazinesFormRequestedEventHandler_0;
			MagazinesFormRequestedEventHandler magazinesFormRequestedEventHandler2;
			do
			{
				magazinesFormRequestedEventHandler2 = magazinesFormRequestedEventHandler;
				MagazinesFormRequestedEventHandler value2 = (MagazinesFormRequestedEventHandler)Delegate.Combine(magazinesFormRequestedEventHandler2, value);
				magazinesFormRequestedEventHandler = Interlocked.CompareExchange(ref magazinesFormRequestedEventHandler_0, value2, magazinesFormRequestedEventHandler2);
			}
			while ((object)magazinesFormRequestedEventHandler != magazinesFormRequestedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			MagazinesFormRequestedEventHandler magazinesFormRequestedEventHandler = magazinesFormRequestedEventHandler_0;
			MagazinesFormRequestedEventHandler magazinesFormRequestedEventHandler2;
			do
			{
				magazinesFormRequestedEventHandler2 = magazinesFormRequestedEventHandler;
				MagazinesFormRequestedEventHandler value2 = (MagazinesFormRequestedEventHandler)Delegate.Remove(magazinesFormRequestedEventHandler2, value);
				magazinesFormRequestedEventHandler = Interlocked.CompareExchange(ref magazinesFormRequestedEventHandler_0, value2, magazinesFormRequestedEventHandler2);
			}
			while ((object)magazinesFormRequestedEventHandler != magazinesFormRequestedEventHandler2);
		}
	}

	public static event WeaponsFormRequestedEventHandler WeaponsFormRequested
	{
		[CompilerGenerated]
		add
		{
			WeaponsFormRequestedEventHandler weaponsFormRequestedEventHandler = weaponsFormRequestedEventHandler_0;
			WeaponsFormRequestedEventHandler weaponsFormRequestedEventHandler2;
			do
			{
				weaponsFormRequestedEventHandler2 = weaponsFormRequestedEventHandler;
				WeaponsFormRequestedEventHandler value2 = (WeaponsFormRequestedEventHandler)Delegate.Combine(weaponsFormRequestedEventHandler2, value);
				weaponsFormRequestedEventHandler = Interlocked.CompareExchange(ref weaponsFormRequestedEventHandler_0, value2, weaponsFormRequestedEventHandler2);
			}
			while ((object)weaponsFormRequestedEventHandler != weaponsFormRequestedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			WeaponsFormRequestedEventHandler weaponsFormRequestedEventHandler = weaponsFormRequestedEventHandler_0;
			WeaponsFormRequestedEventHandler weaponsFormRequestedEventHandler2;
			do
			{
				weaponsFormRequestedEventHandler2 = weaponsFormRequestedEventHandler;
				WeaponsFormRequestedEventHandler value2 = (WeaponsFormRequestedEventHandler)Delegate.Remove(weaponsFormRequestedEventHandler2, value);
				weaponsFormRequestedEventHandler = Interlocked.CompareExchange(ref weaponsFormRequestedEventHandler_0, value2, weaponsFormRequestedEventHandler2);
			}
			while ((object)weaponsFormRequestedEventHandler != weaponsFormRequestedEventHandler2);
		}
	}

	public static event SensorsFormRequestedEventHandler SensorsFormRequested
	{
		[CompilerGenerated]
		add
		{
			SensorsFormRequestedEventHandler sensorsFormRequestedEventHandler = sensorsFormRequestedEventHandler_0;
			SensorsFormRequestedEventHandler sensorsFormRequestedEventHandler2;
			do
			{
				sensorsFormRequestedEventHandler2 = sensorsFormRequestedEventHandler;
				SensorsFormRequestedEventHandler value2 = (SensorsFormRequestedEventHandler)Delegate.Combine(sensorsFormRequestedEventHandler2, value);
				sensorsFormRequestedEventHandler = Interlocked.CompareExchange(ref sensorsFormRequestedEventHandler_0, value2, sensorsFormRequestedEventHandler2);
			}
			while ((object)sensorsFormRequestedEventHandler != sensorsFormRequestedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			SensorsFormRequestedEventHandler sensorsFormRequestedEventHandler = sensorsFormRequestedEventHandler_0;
			SensorsFormRequestedEventHandler sensorsFormRequestedEventHandler2;
			do
			{
				sensorsFormRequestedEventHandler2 = sensorsFormRequestedEventHandler;
				SensorsFormRequestedEventHandler value2 = (SensorsFormRequestedEventHandler)Delegate.Remove(sensorsFormRequestedEventHandler2, value);
				sensorsFormRequestedEventHandler = Interlocked.CompareExchange(ref sensorsFormRequestedEventHandler_0, value2, sensorsFormRequestedEventHandler2);
			}
			while ((object)sensorsFormRequestedEventHandler != sensorsFormRequestedEventHandler2);
		}
	}

	public static event CommsFormRequestedEventHandler CommsFormRequested
	{
		[CompilerGenerated]
		add
		{
			CommsFormRequestedEventHandler commsFormRequestedEventHandler = commsFormRequestedEventHandler_0;
			CommsFormRequestedEventHandler commsFormRequestedEventHandler2;
			do
			{
				commsFormRequestedEventHandler2 = commsFormRequestedEventHandler;
				CommsFormRequestedEventHandler value2 = (CommsFormRequestedEventHandler)Delegate.Combine(commsFormRequestedEventHandler2, value);
				commsFormRequestedEventHandler = Interlocked.CompareExchange(ref commsFormRequestedEventHandler_0, value2, commsFormRequestedEventHandler2);
			}
			while ((object)commsFormRequestedEventHandler != commsFormRequestedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			CommsFormRequestedEventHandler commsFormRequestedEventHandler = commsFormRequestedEventHandler_0;
			CommsFormRequestedEventHandler commsFormRequestedEventHandler2;
			do
			{
				commsFormRequestedEventHandler2 = commsFormRequestedEventHandler;
				CommsFormRequestedEventHandler value2 = (CommsFormRequestedEventHandler)Delegate.Remove(commsFormRequestedEventHandler2, value);
				commsFormRequestedEventHandler = Interlocked.CompareExchange(ref commsFormRequestedEventHandler_0, value2, commsFormRequestedEventHandler2);
			}
			while ((object)commsFormRequestedEventHandler != commsFormRequestedEventHandler2);
		}
	}

	public UnitStatus_WPF()
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		((FrameworkElement)this).SizeChanged += new SizeChangedEventHandler(UnitStatus_WPF_SizeChanged);
		((FrameworkElement)this).Loaded += new RoutedEventHandler(UnitStatus_WPF_Loaded);
		group_0 = null;
		activeUnit_0 = null;
		contact_0 = null;
		string_0 = null;
		InitializeComponent();
		((Panel)MasterGrid).Children.Remove((UIElement)(object)Button_UnitAIDebug);
		Grid.SetColumnSpan((UIElement)(object)Button_UnitMessageLog, 3);
	}

	private void method_0(ActiveUnit activeUnit_1)
	{
		if (activeUnit_1.Components().Count == 0)
		{
			((FrameworkElement)PB_ComponentsDestroyed).Width = 0.0;
			((FrameworkElement)PB_ComponentsHeavyDamage).Width = 0.0;
			((FrameworkElement)PB_ComponentsMediumDamage).Width = 0.0;
			((FrameworkElement)PB_ComponentsLightDamage).Width = 0.0;
			((FrameworkElement)PB_ComponentsOK).Width = 0.0;
			return;
		}
		int num = (int)Math.Round(((FrameworkElement)this).ActualWidth * (2.0 / 3.0));
		int num4 = default(int);
		int num3 = default(int);
		int num2 = default(int);
		int num5 = default(int);
		int num6 = default(int);
		foreach (PlatformComponent item in activeUnit_1.Components())
		{
			PlatformComponent._ComponentStatus? componentStatus = item?.Status;
			byte? b = (byte?)componentStatus;
			if (((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0)) != true)
			{
				b = (byte?)componentStatus;
				if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)) == true)
				{
					switch (item.DamageSeverity)
					{
					case PlatformComponent._DamageSeverityFactor.Light:
						num4++;
						break;
					case PlatformComponent._DamageSeverityFactor.Medium:
						num3++;
						break;
					case PlatformComponent._DamageSeverityFactor.Heavy:
						num2++;
						break;
					}
				}
				else
				{
					b = (byte?)componentStatus;
					if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 2)) == true)
					{
						num5++;
					}
				}
			}
			else
			{
				num6++;
			}
		}
		try
		{
			if (num5 > 0)
			{
				((FrameworkElement)PB_ComponentsDestroyed).Width = (int)Math.Round((double)(num * num5) / (double)activeUnit_1.Components().Count);
			}
			else
			{
				((FrameworkElement)PB_ComponentsDestroyed).Width = 0.0;
			}
			if (num2 > 0)
			{
				((FrameworkElement)PB_ComponentsHeavyDamage).Width = (int)Math.Round((double)(num * num2) / (double)activeUnit_1.Components().Count);
			}
			else
			{
				((FrameworkElement)PB_ComponentsHeavyDamage).Width = 0.0;
			}
			if (num3 > 0)
			{
				((FrameworkElement)PB_ComponentsMediumDamage).Width = (int)Math.Round((double)(num * num3) / (double)activeUnit_1.Components().Count);
			}
			else
			{
				((FrameworkElement)PB_ComponentsMediumDamage).Width = 0.0;
			}
			if (num4 > 0)
			{
				((FrameworkElement)PB_ComponentsLightDamage).Width = (int)Math.Round((double)(num * num4) / (double)activeUnit_1.Components().Count);
			}
			else
			{
				((FrameworkElement)PB_ComponentsLightDamage).Width = 0.0;
			}
			if (num6 > 0)
			{
				((FrameworkElement)PB_ComponentsOK).Width = (int)Math.Round((double)(num * num6) / (double)activeUnit_1.Components().Count);
			}
			else
			{
				((FrameworkElement)PB_ComponentsOK).Width = 0.0;
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

	[AsyncStateMachine(typeof(VB$StateMachine_41_LoadImage))]
	private void method_1(Image image_1, string string_2)
	{
		VB$StateMachine_41_LoadImage stateMachine = default(VB$StateMachine_41_LoadImage);
		stateMachine.$VB$Me = this;
		stateMachine.$VB$Local_imageControl = image_1;
		stateMachine.$VB$Local_localPath = string_2;
		stateMachine.$State = -1;
		stateMachine.$Builder = AsyncVoidMethodBuilder.Create();
		stateMachine.$Builder.Start(ref stateMachine);
	}

	private void method_2(ActiveUnit activeUnit_1)
	{
		try
		{
			string_1 = UnitImageCaching.getMainImageFileString(activeUnit_1);
			if (Operators.CompareString(string_0, string_1, true) != 0 || Image_UnitImage.Source == null)
			{
				method_1(Image_UnitImage, string_1);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			if (Image_UnitImage.Source != null)
			{
				Image_UnitImage.Source = null;
				((UIElement)Image_UnitImage).Visibility = (Visibility)2;
			}
			ex2.Data.Add("Error at 200371", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_3(Scenario scenario_0, Side side_0, Module_Unit.Unit unit_0)
	{
		((UIElement)OuterTextBlock_FiringParent).Visibility = (Visibility)2;
		method_30((Visibility)2);
		((UIElement)TextBlock_Loadout).Visibility = (Visibility)2;
		((UIElement)Expander_GroupMembers).Visibility = (Visibility)2;
		((UIElement)Expander_TankerClients).Visibility = (Visibility)2;
		((UIElement)TextBlock_UnitStatus).Visibility = (Visibility)2;
		((UIElement)TextBlock_PrimaryTarget).Visibility = (Visibility)2;
		((UIElement)Button_ContactReport).Visibility = (Visibility)0;
		((UIElement)Button_Weapons).Visibility = (Visibility)2;
		((UIElement)Button_MCM).Visibility = (Visibility)2;
		method_31((Visibility)2);
		((UIElement)Label_UnitProficiency).Visibility = (Visibility)2;
		((UIElement)Label_UnitKills).Visibility = (Visibility)2;
		((UIElement)Button_Damage).Visibility = (Visibility)2;
		method_32((Visibility)2);
		method_33((Visibility)2);
		((UIElement)Button_UnitMessageLog).Visibility = (Visibility)2;
		((UIElement)Label_GTolerance).Visibility = (Visibility)2;
		((UIElement)PB_GTolerance).Visibility = (Visibility)2;
		((UIElement)Dockpanel_EditHosted).Visibility = (Visibility)2;
		((UIElement)TextBlock_TimeUnderway).Visibility = (Visibility)2;
		((UIElement)Label_Supply).Visibility = (Visibility)2;
		((UIElement)Combo_Supplier).Visibility = (Visibility)2;
		((UIElement)Button_Magazines).Visibility = (Visibility)2;
		((UIElement)Button_AirOps).Visibility = (Visibility)2;
		((UIElement)Button_DockOps).Visibility = (Visibility)2;
		((UIElement)Button_EditHostedAC).Visibility = (Visibility)2;
		((UIElement)Button_EditHostedBoats).Visibility = (Visibility)2;
		((UIElement)Button_CargoOps).Visibility = (Visibility)2;
		if (unit_0 == null || !unit_0.IsContact())
		{
			return;
		}
		contact_0 = (Contact)unit_0;
		if (contact_0.ActualUnit == null || (!side_0.Contacts.ContainsKey(contact_0.ActualUnit.ObjectID) && !side_0.BaseContacts.ContainsKey(contact_0.ActualUnit.ObjectID)))
		{
			return;
		}
		((ContentControl)Label_UnitName).Content = contact_0.Name;
		switch (contact_0.IDStatus)
		{
		case Contact_Base.IdentificationStatus.Unknown:
			((UIElement)OuterTextBlock_UnitCategory).Visibility = (Visibility)2;
			((UIElement)OuterTextBlock_UnitClass).Visibility = (Visibility)2;
			((ContentElement)Hyperlink_UnitClass).IsEnabled = false;
			Image_UnitImage.Source = null;
			((UIElement)Image_UnitImage).Visibility = (Visibility)2;
			break;
		case Contact_Base.IdentificationStatus.KnownDomain:
			((UIElement)OuterTextBlock_UnitCategory).Visibility = (Visibility)0;
			TextBlock_UnitCategory.Text = contact_0.DescriptionString;
			((UIElement)OuterTextBlock_UnitClass).Visibility = (Visibility)2;
			((ContentElement)Hyperlink_UnitClass).IsEnabled = false;
			Image_UnitImage.Source = null;
			((UIElement)Image_UnitImage).Visibility = (Visibility)2;
			break;
		case Contact_Base.IdentificationStatus.KnownType:
			((UIElement)OuterTextBlock_UnitCategory).Visibility = (Visibility)0;
			if (!contact_0.ActualUnit.IsFacility)
			{
				TextBlock_UnitCategory.Text = contact_0.ActualUnit.SubTypeDescription;
			}
			else
			{
				Facility facility2 = (Facility)contact_0.ActualUnit;
				TextBlock_UnitCategory.Text = facility2.Type_Description;
			}
			((UIElement)OuterTextBlock_UnitClass).Visibility = (Visibility)2;
			((ContentElement)Hyperlink_UnitClass).IsEnabled = false;
			Image_UnitImage.Source = null;
			((UIElement)Image_UnitImage).Visibility = (Visibility)2;
			break;
		case Contact_Base.IdentificationStatus.KnownClass:
		case Contact_Base.IdentificationStatus.PreciseID:
			((UIElement)OuterTextBlock_UnitCategory).Visibility = (Visibility)0;
			if (contact_0.ActualUnit.IsFacility)
			{
				Facility facility = (Facility)contact_0.ActualUnit;
				TextBlock_UnitCategory.Text = facility.Type_Description;
			}
			else
			{
				TextBlock_UnitCategory.Text = contact_0.ActualUnit.SubTypeDescription;
			}
			((UIElement)OuterTextBlock_UnitClass).Visibility = (Visibility)0;
			TextBlock_UnitClass.Text = Misc.RemoveHiddenString(contact_0.ActualUnit.UnitClass);
			((ContentElement)Hyperlink_UnitClass).IsEnabled = true;
			if (contact_0.Type != Contact_Base.ContactType.Installation && contact_0.Type != Contact_Base.ContactType.MobileGroup && contact_0.Type != Contact_Base.ContactType.AirBase && contact_0.Type != Contact_Base.ContactType.NavalBase)
			{
				method_2(contact_0.ActualUnit);
				break;
			}
			Image_UnitImage.Source = null;
			((UIElement)Image_UnitImage).Visibility = (Visibility)2;
			break;
		}
		((ContentControl)Label_UnitCourse).Content = "Course: " + contact_0.HeadingString();
		if ((contact_0.Type != Contact_Base.ContactType.Air && contact_0.Type != Contact_Base.ContactType.Missile) || !contact_0.AltitudeIsKnown)
		{
			((ContentControl)Label_UnitSpeed).Content = "Speed: " + contact_0.SpeedString(SimConfiguration.DefaultGamePreferences.GroundUnitsSpeedUnit, "Unknown");
		}
		else
		{
			((ContentControl)Label_UnitSpeed).Content = "Speed: " + Conversions.ToString((int)Math.Round(contact_0.CurrentSpeed)) + " kts (M " + $"{Physics.ComputeMach(((Module_Unit.Unit)contact_0).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), contact_0.CurrentSpeed):0.00}" + ")";
		}
		if (contact_0.SideIsKnown)
		{
			if (contact_0.ActualUnit.get_UnitSide(SetSideOnly: false) != null)
			{
				((ContentControl)Label_UnitSide).Content = "Side: " + contact_0.ActualUnit.get_UnitSide(SetSideOnly: false).Name;
			}
		}
		else
		{
			((ContentControl)Label_UnitSide).Content = "Side: Unknown";
		}
		if (!contact_0.ActualUnit.IsShip && !contact_0.ActualUnit.IsFacility)
		{
			((ContentControl)Label_UnitAlt).Content = "Altitude: " + contact_0.AltitudeString(SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet);
		}
		else
		{
			((ContentControl)Label_UnitAlt).Content = "";
		}
		method_34((Visibility)2);
		if (!contact_0.ActualUnit.IsAircraft && !contact_0.ActualUnit.IsWeapon)
		{
			method_37((Visibility)0);
			method_36((Visibility)0);
			if (!contact_0.ActualUnit.IsShip && !contact_0.ActualUnit.IsSubmarine)
			{
				method_35((Visibility)2);
			}
			else
			{
				method_35((Visibility)0);
			}
			Label_UnitDamage.Text = "BDA: " + Misc.ToEnglishString(contact_0.BDA_StructuralIntegrity);
			if (!contact_0.ActualUnit.IsShip && !contact_0.ActualUnit.IsSubmarine)
			{
				((UIElement)Label_FloodDamage).Visibility = (Visibility)2;
				((UIElement)PB_FloodDamage).Visibility = (Visibility)2;
			}
			else
			{
				((UIElement)Label_FloodDamage).Visibility = (Visibility)0;
				((UIElement)PB_FloodDamage).Visibility = (Visibility)0;
				if (!contact_0.BDA_FloodLevel.HasValue)
				{
					((UIElement)PB_FloodDamage).Visibility = (Visibility)2;
					((ContentControl)Label_FloodDamage).Content = "Flood: UNKNOWN";
				}
				else
				{
					((ContentControl)Label_FloodDamage).Content = "Flood:";
					ActiveUnit_Damage.FloodingIntensityLevel? bDA_FloodLevel = contact_0.BDA_FloodLevel;
					byte? b = (byte?)bDA_FloodLevel;
					if (((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0)) != true)
					{
						b = (byte?)bDA_FloodLevel;
						if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)) == true)
						{
							((RangeBase)PB_FloodDamage).Value = 25.0;
						}
						else
						{
							b = (byte?)bDA_FloodLevel;
							if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 2)) != true)
							{
								b = (byte?)bDA_FloodLevel;
								if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 3)) != true)
								{
									b = (byte?)bDA_FloodLevel;
									if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 4)) == true)
									{
										((RangeBase)PB_FloodDamage).Value = 100.0;
									}
								}
								else
								{
									((RangeBase)PB_FloodDamage).Value = 75.0;
								}
							}
							else
							{
								((RangeBase)PB_FloodDamage).Value = 50.0;
							}
						}
					}
					else
					{
						((RangeBase)PB_FloodDamage).Value = 0.0;
					}
				}
			}
			((UIElement)Label_FireDamage).Visibility = (Visibility)0;
			((UIElement)PB_FireDamage).Visibility = (Visibility)0;
			if (contact_0.BDA_FireLevel.HasValue)
			{
				((ContentControl)Label_FireDamage).Content = "Fire:";
				ActiveUnit_Damage.FireIntensityLevel? bDA_FireLevel = contact_0.BDA_FireLevel;
				byte? b = (byte?)bDA_FireLevel;
				if (((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0)) != true)
				{
					b = (byte?)bDA_FireLevel;
					if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)) != true)
					{
						b = (byte?)bDA_FireLevel;
						if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 2)) != true)
						{
							b = (byte?)bDA_FireLevel;
							if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 3)) == true)
							{
								((RangeBase)PB_FireDamage).Value = 75.0;
							}
							else
							{
								b = (byte?)bDA_FireLevel;
								if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 4)) == true)
								{
									((RangeBase)PB_FireDamage).Value = 100.0;
								}
							}
						}
						else
						{
							((RangeBase)PB_FireDamage).Value = 50.0;
						}
					}
					else
					{
						((RangeBase)PB_FireDamage).Value = 25.0;
					}
				}
				else
				{
					((RangeBase)PB_FireDamage).Value = 0.0;
				}
			}
			else
			{
				((UIElement)PB_FireDamage).Visibility = (Visibility)2;
				((ContentControl)Label_FireDamage).Content = "Fire: UNKNOWN";
			}
		}
		else
		{
			method_37((Visibility)2);
			method_36((Visibility)2);
			method_35((Visibility)2);
		}
		if (!contact_0.ActualUnit.IsGroup)
		{
			((UIElement)Label_ContactWRAType).Visibility = (Visibility)0;
			Doctrine._WRA_WeaponTargetType targetType = Contact.WRA_DetermineTargetType(ref contact_0, null, ref GlobalVariables.ObjectFalse);
			GlobalVariables.BooleanObject EmitterClassificable = null;
			Contact.WRA_DetermineTargetType(ref contact_0, null, ref EmitterClassificable);
			((ContentControl)Label_ContactWRAType).Content = "WRA: " + Doctrine.WRA_TargetType_String(contact_0, targetType, EmitterClassificable.ToBoolean());
		}
		else
		{
			((UIElement)Label_ContactWRAType).Visibility = (Visibility)1;
		}
		((UIElement)Button_Magazines).Visibility = (Visibility)2;
		method_38((Visibility)2);
		if (contact_0.ActualUnit != null && contact_0.ActualUnit.get_isTaggedAsDecoyByThisSide(Client.CurrentSide.ObjectID))
		{
			string text = "[DECOY] ";
			((ContentControl)Label_UnitName).Content = text + Conversions.ToString(((ContentControl)Label_UnitName).Content);
			TextBlock_UnitCategory.Text = text + TextBlock_UnitCategory.Text;
			TextBlock_UnitType.Text = text + TextBlock_UnitType.Text;
			TextBlock_UnitClass.Text = text + TextBlock_UnitClass.Text;
		}
	}

	private void method_4(Scenario scenario_0, Side side_0, Module_Unit.Unit unit_0)
	{
		((UIElement)OuterTextBlock_FiringParent).Visibility = (Visibility)2;
		((UIElement)Label_ContactWRAType).Visibility = (Visibility)2;
		((UIElement)Label_Supply).Visibility = (Visibility)2;
		((UIElement)Combo_Supplier).Visibility = (Visibility)2;
		group_0 = (Group)unit_0;
		if (group_0 == null || group_0.GroupLead == null)
		{
			return;
		}
		method_2(group_0.GroupLead);
		method_39((Visibility)0);
		if (Client.AllowEditModeActions)
		{
			((UIElement)Dockpanel_EditHosted).Visibility = (Visibility)0;
		}
		else
		{
			((UIElement)Dockpanel_EditHosted).Visibility = (Visibility)2;
		}
		((UIElement)TextBlock_UnitStatus).Visibility = (Visibility)0;
		((UIElement)TextBlock_PrimaryTarget).Visibility = (Visibility)0;
		((UIElement)Button_ContactReport).Visibility = (Visibility)2;
		((UIElement)Button_Weapons).Visibility = (Visibility)1;
		((UIElement)Button_MCM).Visibility = (Visibility)2;
		((UIElement)Button_CargoOps).Visibility = (Visibility)2;
		((UIElement)Button_Magazines).Visibility = (Visibility)2;
		method_37((Visibility)2);
		method_36((Visibility)2);
		method_35((Visibility)2);
		((UIElement)Expander_GroupMembers).Visibility = (Visibility)0;
		((UIElement)Expander_TankerClients).Visibility = (Visibility)2;
		method_31((Visibility)2);
		((UIElement)Label_UnitProficiency).Visibility = (Visibility)2;
		((UIElement)Label_UnitKills).Visibility = (Visibility)2;
		((UIElement)OuterTextBlock_UnitClass).Visibility = (Visibility)0;
		((UIElement)TextBlock_UnitStatus).Visibility = (Visibility)0;
		((UIElement)TextBlock_PrimaryTarget).Visibility = (Visibility)0;
		method_32((Visibility)2);
		((ContentElement)Hyperlink_UnitClass).IsEnabled = true;
		((UIElement)Button_UnitMessageLog).Visibility = (Visibility)2;
		((UIElement)Label_GTolerance).Visibility = (Visibility)2;
		((UIElement)PB_GTolerance).Visibility = (Visibility)2;
		((UIElement)TextBlock_TimeUnderway).Visibility = (Visibility)2;
		switch (group_0.Type)
		{
		default:
			method_33((Visibility)0);
			((ToggleButton)CB_GroupLeadSlowDown).IsChecked = group_0.Kinematics.LeadAllowedToSlowDown;
			break;
		case Group.GroupType.AirGroup:
		case Group.GroupType.Installation:
		case Group.GroupType.AirBase:
		case Group.GroupType.NavalBase:
			method_33((Visibility)2);
			break;
		}
		if (Expander_GroupMembers.IsExpanded)
		{
			method_13();
		}
		((UIElement)OuterTextBlock_UnitClass).Visibility = (Visibility)0;
		if (group_0.Type != Group.GroupType.AirGroup)
		{
			TextBlock_UnitClass.Text = group_0.TypeDescription + " (" + Conversions.ToString(group_0.Units.Count) + " units)";
			((UIElement)TextBlock_Loadout).Visibility = (Visibility)2;
		}
		else
		{
			if (group_0.Units.Count > 0)
			{
				if (group_0.CompositionType != Group.E_CompositionType.Homogenous_DBID && group_0.CompositionType != Group.E_CompositionType.Homogenous_DBIDandLoadout)
				{
					TextBlock_UnitClass.Text = "(" + Conversions.ToString(group_0.Units.Count) + "x mixed aircrafts)";
				}
				else
				{
					TextBlock_UnitClass.Text = "(" + Conversions.ToString(group_0.Units.Count) + "x " + Misc.RemoveHiddenString(group_0.Units.Values.ElementAtOrDefault(0).UnitClass) + ")";
				}
			}
			((UIElement)TextBlock_Loadout).Visibility = (Visibility)0;
			if (group_0.Units.Count > 0)
			{
				TextBlock_LoadoutName.Text = Misc.RemoveHiddenString(((Aircraft)group_0.Units.Values.ElementAtOrDefault(0)).LoadoutName);
				((FrameworkContentElement)Hyperlink_Loadout).Tag = ((Aircraft)group_0.Units.Values.ElementAtOrDefault(0)).LoadoutDBID;
			}
		}
		((UIElement)OuterTextBlock_UnitCategory).Visibility = (Visibility)0;
		TextBlock_UnitCategory.Text = group_0.TypeDescription;
		if (!group_0.HasAirFacilities && !group_0.HasDockFacilities)
		{
			method_38((Visibility)2);
		}
		else
		{
			method_38((Visibility)0);
			if (group_0.HasAirFacilities)
			{
				((UIElement)Button_AirOps).Visibility = (Visibility)0;
				if (!Client.Realtime)
				{
					((ContentControl)Button_AirOps).Content = "Aircraft: " + Conversions.ToString(group_0.AirOps.ReadyAircraft.Count()) + "/" + Conversions.ToString(group_0.AirOps.EmbarkedAircraft_ReadOnly.Count);
				}
				else
				{
					((ContentControl)Button_AirOps).Content = "Aircraft: " + Conversions.ToString(Client.RealtimeTerminal.EmbarkedOps_GetReadyAircraftCount(group_0)) + "/" + Conversions.ToString(Client.RealtimeTerminal.EmbarkedOps_GetEmbarkedAircraft(group_0).Count);
				}
				((UIElement)Button_EditHostedAC).Visibility = (Visibility)0;
			}
			else
			{
				((UIElement)Button_AirOps).Visibility = (Visibility)1;
				((UIElement)Button_EditHostedAC).Visibility = (Visibility)1;
			}
			int num;
			if (group_0.HasDockFacilities)
			{
				((UIElement)Button_DockOps).Visibility = (Visibility)0;
				if (!Client.Realtime)
				{
					((ContentControl)Button_DockOps).Content = "Boats: " + Conversions.ToString(ActiveUnit_DockingOps.ReadyBoats(group_0.DockingOps).Count()) + "/" + Conversions.ToString(group_0.DockingOps.EmbarkedBoats_ReadOnly.Count);
				}
				else
				{
					((ContentControl)Button_DockOps).Content = "Boats: " + Conversions.ToString(Client.RealtimeTerminal.EmbarkedOps_GetReadyBoatCount(group_0)) + "/" + Conversions.ToString(Client.RealtimeTerminal.EmbarkedOps_GetEmbarkedBoats(group_0).Count);
				}
				((UIElement)Button_EditHostedBoats).Visibility = (Visibility)0;
				num = 0;
			}
			else
			{
				((UIElement)Button_DockOps).Visibility = (Visibility)1;
				((UIElement)Button_EditHostedBoats).Visibility = (Visibility)1;
				num = 0;
			}
			int num2 = num;
			bool flag = false;
			foreach (ActiveUnit value in group_0.Units.Values)
			{
				if (value.CanCarryCargo())
				{
					flag = true;
					if (value.OnboardCargo.Count() > 0)
					{
						num2 += value.OnboardCargo.Count();
					}
				}
			}
			if (!flag)
			{
				((UIElement)Button_EditHostCargo).Visibility = (Visibility)1;
				((UIElement)Button_CargoOps).Visibility = (Visibility)2;
			}
			else
			{
				((UIElement)Button_EditHostCargo).Visibility = (Visibility)0;
				((UIElement)Button_CargoOps).Visibility = (Visibility)0;
				if (num2 > 0)
				{
					((ContentControl)Button_CargoOps).Content = "Cargo: " + Conversions.ToString(num2);
				}
				else
				{
					((ContentControl)Button_CargoOps).Content = "Cargo: Empty";
				}
			}
		}
		((ContentControl)Label_UnitName).Content = unit_0.Name;
		((ContentControl)Label_UnitCourse).Content = "Course: " + Misc.BearingToString(unit_0.CurrentHeading).ToString() + " deg";
		if (group_0.Type == Group.GroupType.AirGroup)
		{
			if (group_0.GroupLead != null)
			{
				((ContentControl)Label_UnitSpeed).Content = "Speed: " + string.Format("{0:0.0}", unit_0.CurrentSpeed, 0).ToString() + " kts (M " + $"{Physics.ComputeMach(group_0.GroupLead.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), group_0.GroupLead.CurrentSpeed):0.00}" + ") (" + Misc.AsString(group_0.GroupLead.ThrottleSetting, group_0.GroupLead) + ")";
			}
		}
		else if (group_0.GroupLead != null)
		{
			((ContentControl)Label_UnitSpeed).Content = "Speed: " + string.Format("{0:0.0}", unit_0.CurrentSpeed, 0).ToString() + " kts (" + Misc.AsString(group_0.GroupLead.ThrottleSetting, group_0.GroupLead) + ")";
		}
		if (group_0.GroupLead != null && group_0.GroupLead.AI.MustSlowDownToAllowGroupFormUp())
		{
			((ContentControl)Label_UnitSpeed).Content = ((ContentControl)Label_UnitSpeed).Content.ToString() + "\r\n(Reducing speed to regroup)";
		}
		if (unit_0.get_UnitSide(SetSideOnly: false) == null)
		{
			((ContentControl)Label_UnitSide).Content = "None";
		}
		else
		{
			((ContentControl)Label_UnitSide).Content = unit_0.get_UnitSide(SetSideOnly: false).Name;
		}
		if (unit_0.get_UnitSide(SetSideOnly: false) == side_0)
		{
			method_34((Visibility)0);
		}
		else
		{
			method_34((Visibility)2);
		}
		if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
		{
			if (unit_0.CurrentAltitude_AGL > 3048f)
			{
				if (group_0.Type != Group.GroupType.AirGroup)
				{
					((ContentControl)Label_UnitAlt).Content = "Altitude: " + $"{unit_0.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) * 3.28084f:0}".ToString() + " ft";
				}
				else
				{
					((ContentControl)Label_UnitAlt).Content = "Altitude: " + $"{unit_0.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) * 3.28084f:0}".ToString() + " ft ASL";
				}
			}
			else if (group_0.Type != Group.GroupType.AirGroup)
			{
				((ContentControl)Label_UnitAlt).Content = "Altitude: " + $"{unit_0.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) * 3.28084f:0}".ToString() + " ft";
			}
			else if (!Module_Unit.IsOverLand(unit_0))
			{
				((ContentControl)Label_UnitAlt).Content = "Altitude: " + $"{unit_0.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) * 3.28084f:0}" + " ft ASL";
			}
			else
			{
				((ContentControl)Label_UnitAlt).Content = "Altitude: " + $"{unit_0.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) * 3.28084f:0}" + " ft ASL (" + $"{unit_0.CurrentAltitude_AGL * 3.28084f:0}" + " ft AGL)";
			}
		}
		else if (unit_0.CurrentAltitude_AGL > 3048f)
		{
			if (group_0.Type == Group.GroupType.AirGroup)
			{
				((ContentControl)Label_UnitAlt).Content = "Altitude: " + string.Format("{0:0.0}", unit_0.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), 0).ToString() + " m ASL";
			}
			else
			{
				((ContentControl)Label_UnitAlt).Content = "Altitude: " + string.Format("{0:0.0}", unit_0.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), 0).ToString() + " m";
			}
		}
		else if (group_0.Type == Group.GroupType.AirGroup)
		{
			if (Module_Unit.IsOverLand(unit_0))
			{
				((ContentControl)Label_UnitAlt).Content = "Altitude: " + string.Format("{0:0.0}", unit_0.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), 0) + " m ASL (" + string.Format("{0:0.0}", unit_0.CurrentAltitude_AGL, 0) + " m AGL)";
			}
			else
			{
				((ContentControl)Label_UnitAlt).Content = "Altitude: " + string.Format("{0:0.0}", unit_0.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), 0) + " m ASL";
			}
		}
		else
		{
			((ContentControl)Label_UnitAlt).Content = "Altitude: " + string.Format("{0:0.0}", unit_0.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), 0).ToString() + " m";
		}
		method_37((Visibility)2);
		if (group_0.IsLandInstallation)
		{
			if (unit_0.get_UnitSide(SetSideOnly: false) == side_0)
			{
				((UIElement)Button_Magazines).Visibility = (Visibility)0;
			}
			else
			{
				((UIElement)Button_Magazines).Visibility = (Visibility)2;
			}
		}
		else
		{
			((UIElement)Button_Magazines).Visibility = (Visibility)2;
		}
		TextBlock_UnitStatus.Text = "Status: " + Misc.ToEnglishString(group_0.Status, group_0);
		if (group_0.AI.PrimaryTarget == null)
		{
			((UIElement)TextBlock_PrimaryTarget).Visibility = (Visibility)2;
		}
		else
		{
			((UIElement)TextBlock_PrimaryTarget).Visibility = (Visibility)0;
			Run_PrimaryTargetName.Text = group_0.AI.PrimaryTarget.Name;
		}
		if (group_0.GroupLead != null && group_0.GroupLead.Status == ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint)
		{
			GlobalVariables.ActiveUnitType unitType = group_0.GroupLead.UnitType;
			if (unitType == GlobalVariables.ActiveUnitType.Aircraft && ((Aircraft)group_0.GroupLead).AirOps.A2AR_Destination != null)
			{
				TextBlock_UnitStatus.Text = TextBlock_UnitStatus.Text + " (Dest: " + ((Aircraft)group_0.GroupLead).AirOps.A2AR_Destination.Name + ")";
			}
		}
		if (group_0.Status == ActiveUnit._ActiveUnitStatus.FormingUp)
		{
			int num3 = group_0.Units.Values.Where([SpecialName] (ActiveUnit AU) => AU.IsOperating()).Count();
			TextBlock_UnitStatus.Text = "Forming up: " + Conversions.ToString(num3) + "/" + Conversions.ToString(group_0.Units.Count);
		}
		if (group_0.ActiveMissionOrPackage() != null && group_0.get_UnitSide(SetSideOnly: false) == Client.CurrentSide)
		{
			method_30((Visibility)0);
			((FrameworkContentElement)Hyperlink_Mission).Tag = group_0.ActiveMissionOrPackage();
			string text = "";
			int num4;
			if (group_0.GroupLead != null)
			{
				if (!group_0.GroupLead.AI.IsEscort)
				{
					num4 = 5;
				}
				else
				{
					text = "(Escort) ";
					num4 = 5;
				}
			}
			else
			{
				num4 = 5;
			}
			string[] array = new string[num4];
			array[0] = text;
			array[1] = group_0.ActiveMissionOrPackage().Name;
			array[2] = " (";
			array[3] = group_0.ActiveMissionOrPackage().get_DescriptionString(Client.CurrentScenario);
			array[4] = ")";
			text = string.Concat(array);
			TextBlock_MissionName.Text = text;
		}
		else
		{
			method_30((Visibility)2);
		}
		if (group_0.AssignedMissionsQueue.Count > 0 && group_0.get_UnitSide(SetSideOnly: false) == Client.CurrentSide)
		{
			((UIElement)TextBlock_QueuedMission).Visibility = (Visibility)0;
			((UIElement)tip1).IsEnabled = false;
			string text2 = "";
			if (group_0.AssignedMissionsQueue.Count > 0)
			{
				TextBlock_QueuedMission.Text = group_0.AssignedMissionsQueue.Count + " queued missions";
				foreach (KeyValuePair<Mission, Mission> item in group_0.AssignedMissionsQueue.OrderBy([SpecialName] (KeyValuePair<Mission, Mission> x) => x.Key.PriorityWeight).ToList())
				{
					text2 = text2 + item.Value.Name + " priority " + item.Value.PriorityWeight;
					text2 += Environment.NewLine;
				}
			}
			else
			{
				TextBlock_QueuedMission.Text = "";
			}
			((ContentControl)tip1).Content = text2;
		}
		else
		{
			((UIElement)TextBlock_QueuedMission).Visibility = (Visibility)2;
			((UIElement)tip1).IsEnabled = false;
			((ContentControl)tip1).Content = "";
			TextBlock_QueuedMission.Text = "";
		}
	}

	private void method_5(Scenario scenario_0, Side side_0, Module_Unit.Unit unit_0)
	{
		//IL_02d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d6: Invalid comparison between Unknown and I4
		//IL_0508: Unknown result type (might be due to invalid IL or missing references)
		//IL_050e: Invalid comparison between Unknown and I4
		//IL_0522: Unknown result type (might be due to invalid IL or missing references)
		//IL_053b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0541: Invalid comparison between Unknown and I4
		try
		{
			((UIElement)Label_ContactWRAType).Visibility = (Visibility)2;
			activeUnit_0 = (ActiveUnit)unit_0;
			if (activeUnit_0 == null)
			{
				((UIElement)Image_UnitImage).Visibility = (Visibility)2;
				((UIElement)Dockpanel_EditHosted).Visibility = (Visibility)2;
				((UIElement)OuterTextBlock_UnitType).Visibility = (Visibility)2;
				((UIElement)TextBlock_TimeUnderway).Visibility = (Visibility)2;
				((UIElement)Button_CargoOps).Visibility = (Visibility)2;
				((UIElement)Expander_GroupMembers).Visibility = (Visibility)2;
				((UIElement)Expander_TankerClients).Visibility = (Visibility)2;
				((UIElement)TextBlock_UnitStatus).Visibility = (Visibility)2;
				((UIElement)Button_Weapons).Visibility = (Visibility)2;
				((UIElement)OuterTextBlock_FiringParent).Visibility = (Visibility)2;
				((UIElement)Button_ContactReport).Visibility = (Visibility)2;
				method_37((Visibility)2);
				method_36((Visibility)2);
				method_35((Visibility)2);
				method_34((Visibility)2);
				((UIElement)TextBlock_Loadout).Visibility = (Visibility)2;
				((UIElement)OuterTextBlock_UnitClass).Visibility = (Visibility)2;
				((ContentControl)Label_UnitName).Content = "";
				((ContentControl)Label_UnitSide).Content = "";
				((ContentControl)Label_UnitCourse).Content = "";
				((ContentControl)Label_UnitSpeed).Content = "";
				((ContentControl)Label_UnitAlt).Content = "";
				((ContentControl)Label_DamageLabel).Content = "";
				((ContentControl)Label_FireDamage).Content = "";
				((ContentControl)Label_FloodDamage).Content = "";
				((ContentControl)Label_GTolerance).Content = "";
				((ContentControl)Label_Supply).Content = "";
				((ContentControl)Label_UnitAlt).Content = "";
				return;
			}
			if (SimConfiguration.DefaultGamePreferences.UnitStatusImage)
			{
				method_2(activeUnit_0);
			}
			else
			{
				((UIElement)Image_UnitImage).Visibility = (Visibility)2;
				Image_UnitImage.Source = null;
			}
			((UIElement)Button_UnitMessageLog).Visibility = (Visibility)0;
			if (Client.CurrentGame.GameMode == Game._GameMode.ScenEdit)
			{
				((UIElement)Dockpanel_EditHosted).Visibility = (Visibility)0;
			}
			else
			{
				((UIElement)Dockpanel_EditHosted).Visibility = (Visibility)2;
			}
			((UIElement)OuterTextBlock_UnitCategory).Visibility = (Visibility)0;
			((UIElement)OuterTextBlock_UnitType).Visibility = (Visibility)2;
			if (activeUnit_0.IsSubmarine | activeUnit_0.IsShip | activeUnit_0.IsVehicle)
			{
				((UIElement)TextBlock_TimeUnderway).Visibility = (Visibility)0;
				TextBlock_TimeUnderway.Text = Misc.TimeString((long)Math.Round(activeUnit_0.TimeUnderway), 0, ReturnNo: false, ReturnZero: true) + " Time Underway";
			}
			else
			{
				((UIElement)TextBlock_TimeUnderway).Visibility = (Visibility)2;
			}
			if (!activeUnit_0.IsFacility)
			{
				TextBlock_UnitCategory.Text = activeUnit_0.SubTypeDescription;
			}
			else
			{
				Facility facility = (Facility)activeUnit_0;
				TextBlock_UnitCategory.Text = facility.Type_Description;
			}
			((UIElement)Button_CargoOps).Visibility = (Visibility)2;
			if ((int)((UIElement)Expander_GroupMembers).Visibility != 2)
			{
				((UIElement)Expander_GroupMembers).Visibility = (Visibility)2;
			}
			if (activeUnit_0.IsAircraft && ((Aircraft)activeUnit_0).IsTanker)
			{
				((UIElement)Expander_TankerClients).Visibility = (Visibility)0;
				Aircraft_AirOps airOps = ((Aircraft)activeUnit_0).AirOps;
				((HeaderedContentControl)Expander_TankerClients).Header = "Refueling queue: " + Conversions.ToString(airOps.RefuellingQueue.Count + airOps.A2AR_Connections.Count) + " [Served: " + Conversions.ToString(airOps.A2AR_NumberOfReceiverHookups.Where([SpecialName] (ActiveUnit.ActiveUnit_Struct x) => x.DBID != 0).Count()) + "]";
				if (Expander_TankerClients.IsExpanded)
				{
					method_18(ref activeUnit_0);
				}
			}
			else if (activeUnit_0.IsShip && ((Ship)activeUnit_0).get_CanPhysicallyReplenishThisUnit(activeUnit_0))
			{
				((UIElement)Expander_TankerClients).Visibility = (Visibility)0;
				ActiveUnit_DockingOps dockingOps = ((Ship)activeUnit_0).DockingOps;
				int num = 0;
				if (dockingOps.UNREP_Queue.Count > 0 || !string.IsNullOrEmpty(dockingOps.UNREP_Starboard_ReceiverUnitID) || !string.IsNullOrEmpty(dockingOps.UNREP_Port_ReceiverUnitID) || !string.IsNullOrEmpty(dockingOps.UNREP_Astern_ReceiverUnitID))
				{
					if (!string.IsNullOrEmpty(dockingOps.UNREP_Starboard_ReceiverUnitID))
					{
						num++;
					}
					if (!string.IsNullOrEmpty(dockingOps.UNREP_Port_ReceiverUnitID))
					{
						num++;
					}
					if (!string.IsNullOrEmpty(dockingOps.UNREP_Astern_ReceiverUnitID))
					{
						num++;
					}
					foreach (string item in dockingOps.UNREP_Queue)
					{
						_ = item;
						num++;
					}
				}
				((HeaderedContentControl)Expander_TankerClients).Header = "UNREP queue:" + Conversions.ToString(num);
				if (Expander_TankerClients.IsExpanded)
				{
					method_18(ref activeUnit_0);
				}
			}
			else if ((int)((UIElement)Expander_TankerClients).Visibility != 2)
			{
				((UIElement)Expander_TankerClients).Visibility = (Visibility)2;
			}
			if ((int)((UIElement)TextBlock_UnitStatus).Visibility != 0)
			{
				((UIElement)TextBlock_UnitStatus).Visibility = (Visibility)0;
			}
			if ((int)((UIElement)Button_ContactReport).Visibility != 2)
			{
				((UIElement)Button_ContactReport).Visibility = (Visibility)2;
			}
			if (unit_0.IsWeapon)
			{
				((UIElement)Button_Weapons).Visibility = (Visibility)2;
				((UIElement)OuterTextBlock_FiringParent).Visibility = (Visibility)0;
				try
				{
					if (unit_0.get_UnitSide(SetSideOnly: false) != null && (Operators.CompareString(unit_0.get_UnitSide(SetSideOnly: false).ObjectID, Client.CurrentSide.ObjectID, true) == 0 || Module_Side.IsAlliedWithThisSide(unit_0.get_UnitSide(SetSideOnly: false), Client.CurrentSide)) && ((Weapon)unit_0).FiringParent != null)
					{
						TextBlock_FiringParent.Text = "Fired From: " + ((Weapon)unit_0).FiringParent.Name;
					}
					else
					{
						((UIElement)OuterTextBlock_FiringParent).Visibility = (Visibility)2;
					}
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					((UIElement)OuterTextBlock_FiringParent).Visibility = (Visibility)2;
					ProjectData.ClearProjectError();
				}
			}
			else
			{
				((UIElement)Button_Weapons).Visibility = (Visibility)0;
				((UIElement)OuterTextBlock_FiringParent).Visibility = (Visibility)2;
			}
			method_33((Visibility)2);
			if (!unit_0.IsWeapon)
			{
				method_31((Visibility)0);
			}
			else
			{
				method_31((Visibility)2);
			}
			((UIElement)OuterTextBlock_UnitClass).Visibility = (Visibility)0;
			if (!activeUnit_0.IsWeapon)
			{
				((UIElement)Label_UnitProficiency).Visibility = (Visibility)0;
				if (activeUnit_0.Kills.Count > 0)
				{
					((UIElement)Label_UnitKills).Visibility = (Visibility)0;
				}
				else
				{
					((UIElement)Label_UnitKills).Visibility = (Visibility)2;
				}
				((ContentControl)Label_UnitProficiency).Content = Misc.ToEnglishString(activeUnit_0.Proficiency.Value);
				((ContentControl)Label_UnitKills).Content = "Kills " + activeUnit_0.Kills.Count;
				((FrameworkElement)Label_UnitKills).ToolTip = Side._AAR.GetKillsString(activeUnit_0);
				((UIElement)Label_Supply).Visibility = (Visibility)0;
				((UIElement)Combo_Supplier).Visibility = (Visibility)0;
				((Selector)Combo_Supplier).SelectedIndex = (int)activeUnit_0.DesignatedSupplier;
			}
			else
			{
				((UIElement)Label_UnitProficiency).Visibility = (Visibility)2;
				((UIElement)Label_UnitKills).Visibility = (Visibility)2;
				((UIElement)Label_Supply).Visibility = (Visibility)2;
				((UIElement)Combo_Supplier).Visibility = (Visibility)2;
			}
			((ContentElement)Hyperlink_UnitClass).IsEnabled = true;
			if (unit_0.IsAircraft)
			{
				((UIElement)TextBlock_Loadout).Visibility = (Visibility)0;
				Loadout loadout = ((Aircraft)unit_0).Loadout;
				Aircraft_AirOps airOps2 = ((Aircraft)unit_0).AirOps;
				if (loadout != null)
				{
					if (!airOps2.QuickTurnaround_Enabled)
					{
						TextBlock_LoadoutName.Text = Misc.RemoveHiddenString(loadout.Name);
					}
					else
					{
						TextBlock_LoadoutName.Text = Misc.RemoveHiddenString(loadout.Name) + ", Quick Turnaround Enabled, " + Conversions.ToString(airOps2.QuickTurnaround_SortiesFlown) + " / " + Conversions.ToString(airOps2.QuickTurnaround_SortiesTotal) + " sorties";
					}
					((FrameworkContentElement)Hyperlink_Loadout).Tag = loadout.DBID;
				}
				else
				{
					TextBlock_LoadoutName.Text = "Nothing";
					((FrameworkContentElement)Hyperlink_Loadout).Tag = null;
				}
			}
			else
			{
				((UIElement)TextBlock_Loadout).Visibility = (Visibility)2;
			}
			ActiveUnit activeUnit = null;
			string text = "";
			activeUnit = ((!activeUnit_0.IsAircraft) ? activeUnit_0.DockingOps.get_AssignedHostUnit(PickNewAssignedHost: false) : ((Aircraft)activeUnit_0).AirOps.get_AssignedHostUnit(PickNewAssignedHost: false));
			if (activeUnit == null)
			{
				TextBlock_AssignedHost.Text = "Assigned base: None";
			}
			else
			{
				text = ((!activeUnit.IsFacility || !activeUnit.IsGroupMember()) ? activeUnit.Name : activeUnit.get_ParentGroup(UsingMissionPlanner: false).Name);
				TextBlock_AssignedHost.Text = "Assigned base: " + text;
			}
			if ((!activeUnit_0.HasAirFacilities && !activeUnit_0.HasDockFacilities && !(activeUnit_0 is ICargoHost)) || (!activeUnit_0.CommStuff.IsConnectedToSideNetwork && !Module1.IsSelectedForIsolatedPOV(activeUnit_0) && !Client.CurrentMapProfile.GodsEye && Client.CurrentSide.AwarenessLevel != Side.AwarenessLevel_Enum.Omniscient))
			{
				method_38((Visibility)2);
				((UIElement)Button_EditHostedAC).Visibility = (Visibility)2;
				((UIElement)Button_EditHostedBoats).Visibility = (Visibility)2;
				((UIElement)Button_EditHostCargo).Visibility = (Visibility)2;
			}
			else
			{
				method_38((Visibility)0);
				if (!activeUnit_0.HasAirFacilities)
				{
					((UIElement)Button_AirOps).Visibility = (Visibility)2;
					((UIElement)Button_EditHostedAC).Visibility = (Visibility)2;
				}
				else
				{
					((UIElement)Button_AirOps).Visibility = (Visibility)0;
					if (!Client.Realtime)
					{
						((ContentControl)Button_AirOps).Content = "Aircraft: " + Conversions.ToString(activeUnit_0.AirOps.ReadyAircraft.Count()) + "/" + Conversions.ToString(activeUnit_0.AirOps.EmbarkedAircraft_ReadOnly.Count);
					}
					else
					{
						((ContentControl)Button_AirOps).Content = "Aircraft: " + Conversions.ToString(Client.RealtimeTerminal.EmbarkedOps_GetReadyAircraftCount(activeUnit_0)) + "/" + Conversions.ToString(Client.RealtimeTerminal.EmbarkedOps_GetEmbarkedAircraft(activeUnit_0).Count);
					}
					((UIElement)Button_EditHostedAC).Visibility = (Visibility)0;
				}
				if (activeUnit_0.HasDockFacilities)
				{
					((UIElement)Button_DockOps).Visibility = (Visibility)0;
					if (Client.Realtime)
					{
						((ContentControl)Button_DockOps).Content = "Boats: " + Conversions.ToString(Client.RealtimeTerminal.EmbarkedOps_GetReadyBoatCount(activeUnit_0)) + "/" + Conversions.ToString(Client.RealtimeTerminal.EmbarkedOps_GetEmbarkedBoats(activeUnit_0).Count);
					}
					else
					{
						((ContentControl)Button_DockOps).Content = "Boats: " + Conversions.ToString(ActiveUnit_DockingOps.ReadyBoats(activeUnit_0.DockingOps).Count()) + "/" + Conversions.ToString(activeUnit_0.DockingOps.EmbarkedBoats_ReadOnly.Count);
					}
					((UIElement)Button_EditHostedBoats).Visibility = (Visibility)0;
				}
				else
				{
					((UIElement)Button_DockOps).Visibility = (Visibility)2;
					((UIElement)Button_EditHostedBoats).Visibility = (Visibility)2;
				}
				if (activeUnit_0.CanCarryCargo())
				{
					((UIElement)Button_EditHostCargo).Visibility = (Visibility)0;
					((UIElement)Button_CargoOps).Visibility = (Visibility)0;
					if (!activeUnit_0.HasCargo)
					{
						((ContentControl)Button_CargoOps).Content = "Cargo: Empty";
					}
					else
					{
						((ContentControl)Button_CargoOps).Content = "Cargo: " + Conversions.ToString(activeUnit_0.OnboardCargo.Count());
					}
				}
				else
				{
					((UIElement)Button_EditHostCargo).Visibility = (Visibility)2;
					((UIElement)Button_CargoOps).Visibility = (Visibility)2;
				}
			}
			if (!activeUnit_0.IsGroupLead())
			{
				if (!activeUnit_0.Navigator.HasFlight)
				{
					((ContentControl)Label_UnitName).Content = unit_0.Name;
				}
				else
				{
					((ContentControl)Label_UnitName).Content = unit_0.Name + " (Flight " + activeUnit_0.Navigator.get_Flight(HierarchySearch: true).Callsign + ")";
				}
			}
			else if (activeUnit_0.Navigator.HasFlight)
			{
				((ContentControl)Label_UnitName).Content = "[LEAD] " + activeUnit_0.Name + " (Flight " + activeUnit_0.Navigator.get_Flight(HierarchySearch: true).Callsign + ")";
			}
			else
			{
				((ContentControl)Label_UnitName).Content = unit_0.Name;
			}
			((UIElement)OuterTextBlock_UnitClass).Visibility = (Visibility)0;
			TextBlock_UnitClass.Text = Misc.RemoveHiddenString(unit_0.UnitClass);
			if (!activeUnit_0.CommStuff.IsConnectedToSideNetwork && !Module1.IsSelectedForIsolatedPOV(activeUnit_0) && !Client.CurrentMapProfile.GodsEye && Client.CurrentSide.AwarenessLevel != Side.AwarenessLevel_Enum.Omniscient)
			{
				((ContentControl)Label_UnitCourse).Content = "Course: XXX";
			}
			else
			{
				if (activeUnit_0.IsDumbAU)
				{
					((ContentControl)Label_UnitCourse).Content = null;
					((ContentControl)Label_UnitSpeed).Content = null;
				}
				else if (!activeUnit_0.IsFixedFacility)
				{
					((ContentControl)Label_UnitCourse).Content = "Course: " + Conversions.ToString(Math.Round(unit_0.CurrentHeading, 0)) + " deg";
				}
				else
				{
					((ContentControl)Label_UnitCourse).Content = null;
					((ContentControl)Label_UnitSpeed).Content = null;
				}
				if (activeUnit_0.Navigator.PathFindingInProgress)
				{
					((ContentControl)Label_UnitCourse).Content = Conversions.ToString(((ContentControl)Label_UnitCourse).Content) + " (Plotting..." + Conversions.ToString((int)Math.Round(activeUnit_0.Navigator.Pathfinding_PercentComplete * 100f)) + "%)";
				}
			}
			if (!activeUnit_0.CommStuff.IsConnectedToSideNetwork && !Module1.IsSelectedForIsolatedPOV(activeUnit_0) && !Client.CurrentMapProfile.GodsEye && Client.CurrentSide.AwarenessLevel != Side.AwarenessLevel_Enum.Omniscient)
			{
				((ContentControl)Label_UnitSpeed).Content = "Speed: XXX";
			}
			else if (!((unit_0.IsAircraft || unit_0.IsMissile) | (unit_0.IsWeapon && ((Weapon)unit_0).IsWeaponPallet)))
			{
				if (unit_0.IsSatellite)
				{
					((ContentControl)Label_UnitSpeed).Content = "Speed: " + Conversions.ToString((int)Math.Round(unit_0.CurrentSpeed)) + " kts";
				}
				else
				{
					((Control)Label_UnitSpeed).Foreground = (Brush)(object)Brushes.White;
					if (!activeUnit_0.IsShip)
					{
						if (activeUnit_0.ActualSpeedReducedByTerrain)
						{
							((ContentControl)Label_UnitSpeed).Content = "MAX Speed reduced due to terrain" + Environment.NewLine + "Speed: " + unit_0.SpeedString(SimConfiguration.DefaultGamePreferences.GroundUnitsSpeedUnit) + " (" + Misc.AsString(activeUnit_0.ThrottleSetting, activeUnit_0) + ")";
						}
						else
						{
							((ContentControl)Label_UnitSpeed).Content = "Speed: " + unit_0.SpeedString(SimConfiguration.DefaultGamePreferences.GroundUnitsSpeedUnit) + " (" + Misc.AsString(activeUnit_0.ThrottleSetting, activeUnit_0) + ")";
						}
					}
					else
					{
						Ship ship = (Ship)activeUnit_0;
						Weather.WeatherProfile weatherProfile = Weather.get_WeatherAtThisTimeAndPlace(ship.ParentScen, ((ActiveUnit)ship).get_Latitude((GlobalVariables.BooleanObject)null), ((ActiveUnit)ship).get_Longitude((GlobalVariables.BooleanObject)null), 0);
						if (ship.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.WeatherAffectsShipSpeed) && ship.Kinematics.GetMaximumSpeed() > Ship_Kinematics.GetMaximumSpeedForThisSeaState(ship, weatherProfile.SeaState))
						{
							((ContentControl)Label_UnitSpeed).Content = "MAX Speed reduced due to Sea State " + weatherProfile.SeaState + Environment.NewLine + "Speed: " + unit_0.SpeedString(SimConfiguration.DefaultGamePreferences.GroundUnitsSpeedUnit) + " (" + Misc.AsString(activeUnit_0.ThrottleSetting, ship) + ")";
							((Control)Label_UnitSpeed).Foreground = (Brush)(object)Brushes.Orange;
						}
						else
						{
							((ContentControl)Label_UnitSpeed).Content = "Speed: " + unit_0.SpeedString(SimConfiguration.DefaultGamePreferences.GroundUnitsSpeedUnit) + " (" + Misc.AsString(activeUnit_0.ThrottleSetting, ship) + ")";
						}
					}
				}
			}
			else if (unit_0.SupportsAttitude_Pitch && !double.IsNaN(unit_0.Attitude_Pitch))
			{
				bool flag = activeUnit_0.Kinematics.DesiredSpeedOverride.HasValue || (activeUnit_0.get_ParentGroup(UsingMissionPlanner: false) != null && activeUnit_0.get_ParentGroup(UsingMissionPlanner: false).Kinematics.DesiredSpeedOverride.HasValue);
				((ContentControl)Label_UnitSpeed).Content = "Speed:\r\nTAS " + Conversions.ToString((int)Math.Round(unit_0.CurrentSpeed)) + " kts (M " + $"{Physics.ComputeMach(unit_0.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), unit_0.CurrentSpeed):0.00}" + ") - Pitch: " + Conversions.ToString(Math.Round(unit_0.Attitude_Pitch, 1)) + "\r\nGnd " + Conversions.ToString((int)Math.Round((double)unit_0.CurrentSpeed * Math2.Cosd(unit_0.Attitude_Pitch))) + " kts (" + ((!flag) ? "Auto: " : "Manual: ") + Misc.AsString(activeUnit_0.ThrottleSetting, activeUnit_0) + ")";
			}
			else
			{
				((ContentControl)Label_UnitSpeed).Content = "Speed: " + Conversions.ToString((int)Math.Round(unit_0.CurrentSpeed)) + " kts (M " + $"{Physics.ComputeMach(unit_0.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), unit_0.CurrentSpeed):0.00}" + ") (" + Misc.AsString(activeUnit_0.ThrottleSetting, activeUnit_0) + ")";
			}
			if (unit_0.get_UnitSide(SetSideOnly: false) != null)
			{
				((ContentControl)Label_UnitSide).Content = "Side: " + unit_0.get_UnitSide(SetSideOnly: false).Name;
			}
			else
			{
				((ContentControl)Label_UnitSide).Content = "Side: None";
			}
			if (unit_0.get_UnitSide(SetSideOnly: false) == side_0 && (activeUnit_0.CommStuff.IsConnectedToSideNetwork || Module1.IsSelectedForIsolatedPOV(activeUnit_0) || Client.CurrentMapProfile.GodsEye || Client.CurrentSide.AwarenessLevel == Side.AwarenessLevel_Enum.Omniscient))
			{
				method_34((Visibility)0);
			}
			else
			{
				method_34((Visibility)2);
			}
			if (!unit_0.IsWeapon && (activeUnit_0.CommStuff.IsConnectedToSideNetwork || Module1.IsSelectedForIsolatedPOV(activeUnit_0) || Client.CurrentMapProfile.GodsEye || Client.CurrentSide.AwarenessLevel == Side.AwarenessLevel_Enum.Omniscient))
			{
				method_37((Visibility)0);
				method_36((Visibility)0);
				if (!unit_0.IsShip && !unit_0.IsSubmarine)
				{
					method_35((Visibility)2);
				}
				else
				{
					method_35((Visibility)0);
				}
				((UIElement)Button_Damage).Visibility = (Visibility)0;
				if (unit_0.IsShip && ((Ship)unit_0).IsSinking)
				{
					Label_UnitDamage.Text = "SINKING";
				}
				else
				{
					Label_UnitDamage.Text = string.Format("{0:0.0}", activeUnit_0.Damage.DamagePercent, 1) + "%";
				}
				if (!unit_0.IsShip && !unit_0.IsSubmarine)
				{
					((UIElement)Label_FloodDamage).Visibility = (Visibility)2;
					((UIElement)PB_FloodDamage).Visibility = (Visibility)2;
				}
				else
				{
					((UIElement)Label_FloodDamage).Visibility = (Visibility)0;
					((UIElement)PB_FloodDamage).Visibility = (Visibility)0;
					((ContentControl)Label_FloodDamage).Content = "Flood:";
					switch (activeUnit_0.Damage.FloodIntensity)
					{
					case ActiveUnit_Damage.FloodingIntensityLevel.NoFlooding:
						((RangeBase)PB_FloodDamage).Value = 0.0;
						((UIElement)Label_FloodDamage).Visibility = (Visibility)2;
						((UIElement)PB_FloodDamage).Visibility = (Visibility)2;
						break;
					case ActiveUnit_Damage.FloodingIntensityLevel.Minor:
						((RangeBase)PB_FloodDamage).Value = 25.0;
						break;
					case ActiveUnit_Damage.FloodingIntensityLevel.Major:
						((RangeBase)PB_FloodDamage).Value = 50.0;
						break;
					case ActiveUnit_Damage.FloodingIntensityLevel.Severe:
						((RangeBase)PB_FloodDamage).Value = 75.0;
						break;
					case ActiveUnit_Damage.FloodingIntensityLevel.Capsizing:
						((RangeBase)PB_FloodDamage).Value = 100.0;
						break;
					}
				}
				if (unit_0.IsAircraft && ((Aircraft)unit_0).Kinematics.IsInCombatManouvers && !((Aircraft)unit_0).IsHelicopter)
				{
					((UIElement)Label_GTolerance).Visibility = (Visibility)0;
					((UIElement)PB_GTolerance).Visibility = (Visibility)0;
					Aircraft aircraft = (Aircraft)unit_0;
					((RangeBase)PB_GTolerance).Value = 100f * (aircraft.G_StrainAccumulated / aircraft.G_Tolerance);
					float num2 = aircraft.G_StrainAccumulated / aircraft.G_Tolerance;
					if (num2 < 0.5f)
					{
						((Control)PB_GTolerance).Foreground = (Brush)(object)Brushes.Green;
					}
					else if (num2 < 0.75f)
					{
						((Control)PB_GTolerance).Foreground = (Brush)(object)Brushes.Yellow;
					}
					else
					{
						((Control)PB_GTolerance).Foreground = (Brush)(object)Brushes.Red;
					}
				}
				else
				{
					((UIElement)Label_GTolerance).Visibility = (Visibility)2;
					((UIElement)PB_GTolerance).Visibility = (Visibility)2;
				}
				((UIElement)Label_FireDamage).Visibility = (Visibility)0;
				((UIElement)PB_FireDamage).Visibility = (Visibility)0;
				((ContentControl)Label_FireDamage).Content = "Fire:";
				switch (activeUnit_0.Damage.FireIntensity)
				{
				case ActiveUnit_Damage.FireIntensityLevel.NoFire:
					((RangeBase)PB_FireDamage).Value = 0.0;
					((UIElement)Label_FireDamage).Visibility = (Visibility)2;
					((UIElement)PB_FireDamage).Visibility = (Visibility)2;
					break;
				case ActiveUnit_Damage.FireIntensityLevel.Minor:
					((RangeBase)PB_FireDamage).Value = 25.0;
					break;
				case ActiveUnit_Damage.FireIntensityLevel.Major:
					((RangeBase)PB_FireDamage).Value = 50.0;
					break;
				case ActiveUnit_Damage.FireIntensityLevel.Severe:
					((RangeBase)PB_FireDamage).Value = 75.0;
					break;
				case ActiveUnit_Damage.FireIntensityLevel.Conflagration:
					((RangeBase)PB_FireDamage).Value = 100.0;
					break;
				}
			}
			else
			{
				method_37((Visibility)2);
				method_36((Visibility)2);
				method_35((Visibility)2);
			}
			GlobalVariables.ActiveUnitType unitType = ((ActiveUnit)unit_0).UnitType;
			if (unitType != GlobalVariables.ActiveUnitType.Ship && unitType != GlobalVariables.ActiveUnitType.Facility)
			{
				if (!activeUnit_0.CommStuff.IsConnectedToSideNetwork && !Module1.IsSelectedForIsolatedPOV(activeUnit_0) && !Client.CurrentMapProfile.GodsEye && Client.CurrentSide.AwarenessLevel != Side.AwarenessLevel_Enum.Omniscient)
				{
					((ContentControl)Label_UnitAlt).Content = "Altitude: XXX";
				}
				else if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
				{
					if (unit_0.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > 45720f)
					{
						((ContentControl)Label_UnitAlt).Content = "Altitude: " + $"{unit_0.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) / 1000f:0.0}" + " km ASL (" + (activeUnit_0.Kinematics.DesiredAltitudeOverride ? "Manual)" : "Auto)");
					}
					else if (unit_0.CurrentAltitude_AGL > 3048f)
					{
						if (!unit_0.IsAircraft && !unit_0.IsWeapon)
						{
							((ContentControl)Label_UnitAlt).Content = "Altitude: " + $"{unit_0.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) * 3.28084f:0}" + " ft (" + (activeUnit_0.Kinematics.DesiredAltitudeOverride ? "Manual)" : "Auto)");
						}
						else
						{
							((ContentControl)Label_UnitAlt).Content = "Altitude: " + $"{unit_0.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) * 3.28084f:0}" + " ft ASL (" + ((!activeUnit_0.Kinematics.DesiredAltitudeOverride) ? "Auto)" : "Manual)");
						}
					}
					else if (!unit_0.IsAircraft && !unit_0.IsWeapon)
					{
						((ContentControl)Label_UnitAlt).Content = "Altitude: " + $"{unit_0.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) * 3.28084f:0}" + " ft (" + ((!activeUnit_0.Kinematics.DesiredAltitudeOverride) ? "Auto)" : "Manual)");
					}
					else if (!Module_Unit.IsOverLand(unit_0))
					{
						((ContentControl)Label_UnitAlt).Content = "Altitude: " + $"{unit_0.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) * 3.28084f:0}" + " ft ASL (" + (activeUnit_0.Kinematics.DesiredAltitudeOverride ? "Manual)" : "Auto)");
					}
					else
					{
						((ContentControl)Label_UnitAlt).Content = "Altitude: " + $"{unit_0.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) * 3.28084f:0}" + " ft ASL (" + $"{unit_0.CurrentAltitude_AGL * 3.28084f:0}" + " ft AGL) (" + (activeUnit_0.Kinematics.DesiredAltitudeOverride ? "Manual)" : "Auto)");
					}
				}
				else if (unit_0.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > 45720f)
				{
					((ContentControl)Label_UnitAlt).Content = "Altitude: " + $"{unit_0.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) / 1000f:0.0}" + " km ASL (" + (activeUnit_0.Kinematics.DesiredAltitudeOverride ? "Manual)" : "Auto)");
				}
				else if (unit_0.CurrentAltitude_AGL > 3048f)
				{
					if (!unit_0.IsAircraft && !unit_0.IsWeapon)
					{
						((ContentControl)Label_UnitAlt).Content = "Altitude: " + $"{unit_0.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null):0.0}" + " m (" + (activeUnit_0.Kinematics.DesiredAltitudeOverride ? "Manual)" : "Auto)");
					}
					else
					{
						((ContentControl)Label_UnitAlt).Content = "Altitude: " + $"{unit_0.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null):0.0}" + " m ASL (" + (activeUnit_0.Kinematics.DesiredAltitudeOverride ? "Manual)" : "Auto)");
					}
				}
				else if (!unit_0.IsAircraft && !unit_0.IsWeapon)
				{
					((ContentControl)Label_UnitAlt).Content = "Altitude: " + $"{unit_0.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null):0.0}" + " m (" + ((!activeUnit_0.Kinematics.DesiredAltitudeOverride) ? "Auto)" : "Manual)");
				}
				else if (!Module_Unit.IsOverLand(unit_0))
				{
					((ContentControl)Label_UnitAlt).Content = "Altitude: " + $"{unit_0.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null):0.0}" + " m ASL (" + ((!activeUnit_0.Kinematics.DesiredAltitudeOverride) ? "Auto)" : "Manual)");
				}
				else
				{
					((ContentControl)Label_UnitAlt).Content = "Altitude: " + $"{unit_0.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null):0.0}" + " m ASL (" + string.Format("{0:0.0}", unit_0.CurrentAltitude_AGL, 0) + " m AGL) (" + (activeUnit_0.Kinematics.DesiredAltitudeOverride ? "Manual)" : "Auto)");
				}
			}
			else
			{
				((ContentControl)Label_UnitAlt).Content = "";
			}
			if (unit_0.IsPlatform && Client.CanSeeAllPrivateInformationOnThisUnit(activeUnit_0))
			{
				if (Client.CurrentGame.GameMode != Game._GameMode.ScenEdit && ((Platform)unit_0).Magazines.Count() <= 0)
				{
					bool flag2 = default(bool);
					if ((unit_0.IsShip || unit_0.IsFacility) && ((Platform)unit_0).Mounts.Count > 0)
					{
						foreach (Mount mount in ((Platform)unit_0).Mounts)
						{
							if (mount.MountMagazine.Weapons.Count > 0)
							{
								flag2 = true;
								break;
							}
						}
					}
					if (!flag2)
					{
						((UIElement)Button_Magazines).Visibility = (Visibility)2;
					}
					else
					{
						((UIElement)Button_Magazines).Visibility = (Visibility)0;
					}
				}
				else if (activeUnit_0.IsAircraft)
				{
					((UIElement)Button_Magazines).Visibility = (Visibility)2;
				}
				else if (unit_0.get_UnitSide(SetSideOnly: false) == side_0)
				{
					((UIElement)Button_Magazines).Visibility = (Visibility)0;
				}
				else
				{
					((UIElement)Button_Magazines).Visibility = (Visibility)2;
				}
			}
			else
			{
				((UIElement)Button_Magazines).Visibility = (Visibility)2;
			}
			if (activeUnit_0.HasMineCountermeasures() && Client.CanSeeAllPrivateInformationOnThisUnit(activeUnit_0))
			{
				((UIElement)Button_MCM).Visibility = (Visibility)0;
			}
			else
			{
				((UIElement)Button_MCM).Visibility = (Visibility)2;
			}
			if (unit_0.IsShip && ((Ship)unit_0).IsSinking)
			{
				TextBlock_UnitStatus.Text = "Status: SINKING";
			}
			else if (!activeUnit_0.CommStuff.IsConnectedToSideNetwork && !Module1.IsSelectedForIsolatedPOV(activeUnit_0) && !Client.CurrentMapProfile.GodsEye && Client.CurrentSide.AwarenessLevel != Side.AwarenessLevel_Enum.Omniscient)
			{
				long num3 = (long)Math.Round((Client.CurrentScenario.Time - activeUnit_0.LastReportedInfo_MostRecentUpdateTime.Value).TotalSeconds);
				string text2 = Environment.NewLine + "Last location reported ";
				text2 = ((num3 <= 0L) ? (text2 + "<1 sec ago") : (text2 + Misc.TimeString(num3) + " ago"));
				string newLine = Environment.NewLine;
				if (Operators.CompareString(activeUnit_0.LastReportedInfo_MostRecentReportingUnitObjectID, activeUnit_0.ObjectID, true) != 0)
				{
					newLine += "Identified by ";
					newLine = (Client.CurrentScenario.ActiveUnits.TryGetValue(activeUnit_0.LastReportedInfo_MostRecentReportingUnitObjectID, out var value) ? (newLine + value.Name) : (newLine + "unkown unit"));
				}
				else
				{
					newLine += "Self reported when last in comms";
				}
				TextBlock_UnitStatus.Text = "Status: UNKNOWN (Out of comms)" + text2 + newLine;
			}
			else if (activeUnit_0.IsWeapon && ((Weapon)activeUnit_0).Type == Weapon._WeaponType.Sonobuoy)
			{
				TextBlock_UnitStatus.Text = "Time To Live: " + Misc.TimeString((long)Math.Round(activeUnit_0.Fuel_ReadOnly[0].CurrentQuantity));
			}
			else
			{
				TextBlock_UnitStatus.Text = "Status: " + Misc.ToEnglishString(activeUnit_0.Status, activeUnit_0);
				if (activeUnit_0.AI.PrimaryTarget != null)
				{
					((UIElement)TextBlock_PrimaryTarget).Visibility = (Visibility)0;
					Run_PrimaryTargetName.Text = activeUnit_0.AI.PrimaryTarget.Name;
				}
				else
				{
					((UIElement)TextBlock_PrimaryTarget).Visibility = (Visibility)2;
				}
				if ((unit_0.IsShip || unit_0.IsSubmarine) && activeUnit_0.Navigator.SprintDrift)
				{
					TextBlock textBlock_UnitStatus;
					switch (activeUnit_0.Kinematics.SprintAndDriftCadence)
					{
					case ActiveUnit_Kinematics._SprintAndDriftCadence.Drift:
						(textBlock_UnitStatus = TextBlock_UnitStatus).Text = textBlock_UnitStatus.Text + " (Drifting";
						break;
					case ActiveUnit_Kinematics._SprintAndDriftCadence.Sprint:
						(textBlock_UnitStatus = TextBlock_UnitStatus).Text = textBlock_UnitStatus.Text + " (Sprinting";
						break;
					}
					float sprintDriftDistance = activeUnit_0.Navigator.GetSprintDriftDistance();
					if (sprintDriftDistance > 0f)
					{
						(textBlock_UnitStatus = TextBlock_UnitStatus).Text = textBlock_UnitStatus.Text + " for ";
						if (sprintDriftDistance < 1f)
						{
							(textBlock_UnitStatus = TextBlock_UnitStatus).Text = textBlock_UnitStatus.Text + sprintDriftDistance.ToString("F1");
						}
						else
						{
							(textBlock_UnitStatus = TextBlock_UnitStatus).Text = textBlock_UnitStatus.Text + sprintDriftDistance.ToString("F0");
						}
						(textBlock_UnitStatus = TextBlock_UnitStatus).Text = textBlock_UnitStatus.Text + "nm";
					}
					(textBlock_UnitStatus = TextBlock_UnitStatus).Text = textBlock_UnitStatus.Text + ")";
				}
				if (activeUnit_0.Status == ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint)
				{
					GlobalVariables.ActiveUnitType unitType2 = activeUnit_0.UnitType;
					if (unitType2 == GlobalVariables.ActiveUnitType.Aircraft)
					{
						if (((Aircraft)activeUnit_0).AirOps.A2AR_Destination == null)
						{
							if (activeUnit_0.IsGroupWingman() && !activeUnit_0.IsGroupLead())
							{
								ActiveUnit groupLead = activeUnit_0.get_ParentGroup(UsingMissionPlanner: false).GroupLead;
								if (((Aircraft)groupLead).AirOps.A2AR_Destination != null)
								{
									TextBlock_UnitStatus.Text = TextBlock_UnitStatus.Text + " (Dest: " + ((Aircraft)groupLead).AirOps.A2AR_Destination.Name + ")";
								}
							}
						}
						else
						{
							TextBlock_UnitStatus.Text = TextBlock_UnitStatus.Text + " (Dest: " + ((Aircraft)activeUnit_0).AirOps.A2AR_Destination.Name + ")";
						}
					}
					else if (activeUnit_0.DockingOps.UNREP_Destination != null)
					{
						TextBlock_UnitStatus.Text = TextBlock_UnitStatus.Text + " (Dest: " + activeUnit_0.DockingOps.UNREP_Destination.Name + ")";
					}
				}
				if (unit_0.IsAircraft)
				{
					if (((Aircraft)unit_0).AirOps.Condition != Aircraft_AirOps._AirOpsCondition.RTB)
					{
						string text3 = " (" + ((Aircraft)unit_0).AirOps.ConditionString;
						Aircraft_AirOps._AirOpsCondition condition = ((Aircraft)activeUnit_0).AirOps.Condition;
						if (condition == Aircraft_AirOps._AirOpsCondition.DeployingDippingSonar || condition == Aircraft_AirOps._AirOpsCondition.TransferringCargo)
						{
							text3 = ((!(activeUnit_0.CurrentAltitude_AGL > (float)Aircraft_AirOps.HelicopterDippingSonarAltitude)) ? (text3 + " (" + Misc.TimeString((long)Math.Round(((Aircraft)activeUnit_0).AirOps.ConditionTimer), 0, ReturnNo: false, ReturnZero: true) + ")") : (text3 + ", Adjusting Altitude"));
						}
						text3 += ")";
						TextBlock_UnitStatus.Text += text3;
					}
				}
				else
				{
					if (activeUnit_0.Status == ActiveUnit._ActiveUnitStatus.Refuelling)
					{
						string text4 = string.Empty;
						int num4 = activeUnit_0.DockingOps.UNREP_Destination.DockingOps.get_FuelWeCanSupplyToThisUnit(activeUnit_0, 0f);
						int num5 = activeUnit_0.DockingOps.UNREP_Destination.DockingOps.get_MaterialWeCanSupplyToThisUnit(activeUnit_0, (Dictionary<int, Weapon>)null);
						if (num4 > 0)
						{
							text4 = text4 + "Refuelling (" + Conversions.ToString(num4) + "kg to go)";
						}
						if (num5 > 0)
						{
							if (num4 > 0)
							{
								text4 += " - ";
							}
							text4 = text4 + "Replenishing (" + Conversions.ToString(num5) + " items to go)";
						}
						TextBlock_UnitStatus.Text = "Status: " + text4;
					}
					if (!activeUnit_0.DockingOps.IsCurrentlyProvidingUNREP)
					{
						if (activeUnit_0.DockingOps.Condition != ActiveUnit_DockingOps._DockingOpsCondition.TransferringCargo && activeUnit_0.DockingOps.Condition != ActiveUnit_DockingOps._DockingOpsCondition.TransferringMissionCargo)
						{
							if (!activeUnit_0.IsFixedFacility || activeUnit_0.DockingOps.Condition != ActiveUnit_DockingOps._DockingOpsCondition.Underway)
							{
								TextBlock textBlock_UnitStatus;
								(textBlock_UnitStatus = TextBlock_UnitStatus).Text = textBlock_UnitStatus.Text + " (" + activeUnit_0.DockingOps.ConditionString + ")";
							}
						}
						else
						{
							TextBlock_UnitStatus.Text = TextBlock_UnitStatus.Text + " (" + activeUnit_0.DockingOps.ConditionString + " (" + Misc.TimeString((long)Math.Round(activeUnit_0.DockingOps.ConditionTimer), 0, ReturnNo: false, ReturnZero: true) + "))";
						}
					}
					else
					{
						string text5 = "\r\nProviding UNREP: ";
						ActiveUnit activeUnit2 = null;
						if (!string.IsNullOrEmpty(activeUnit_0.DockingOps.UNREP_Port_ReceiverUnitID))
						{
							activeUnit2 = Client.CurrentScenario.ActiveUnits[activeUnit_0.DockingOps.UNREP_Port_ReceiverUnitID];
						}
						if (activeUnit2 != null)
						{
							text5 = text5 + "\r\nPort: " + activeUnit2.Name;
						}
						activeUnit2 = null;
						if (!string.IsNullOrEmpty(activeUnit_0.DockingOps.UNREP_Starboard_ReceiverUnitID))
						{
							activeUnit2 = Client.CurrentScenario.ActiveUnits[activeUnit_0.DockingOps.UNREP_Starboard_ReceiverUnitID];
						}
						if (activeUnit2 != null)
						{
							text5 = text5 + "\r\nStarboard: " + activeUnit2.Name;
						}
						activeUnit2 = null;
						if (!string.IsNullOrEmpty(activeUnit_0.DockingOps.UNREP_Astern_ReceiverUnitID))
						{
							activeUnit2 = Client.CurrentScenario.ActiveUnits[activeUnit_0.DockingOps.UNREP_Astern_ReceiverUnitID];
						}
						if (activeUnit2 != null)
						{
							text5 = text5 + "\r\nAstern: " + activeUnit2.Name;
						}
						activeUnit2 = null;
						TextBlock textBlock_UnitStatus;
						(textBlock_UnitStatus = TextBlock_UnitStatus).Text = textBlock_UnitStatus.Text + text5;
					}
				}
			}
			if (activeUnit_0.ActiveMissionOrPackage() != null && activeUnit_0.get_UnitSide(SetSideOnly: false) == Client.CurrentSide)
			{
				method_30((Visibility)0);
				((FrameworkContentElement)Hyperlink_Mission).Tag = activeUnit_0.ActiveMissionOrPackage();
				string text6 = "";
				if (activeUnit_0.AI.IsEscort)
				{
					text6 = "(Escort) ";
				}
				text6 += activeUnit_0.ActiveMissionOrPackage().Name;
				if (!string.IsNullOrEmpty(activeUnit_0.ActiveMissionOrPackage().get_DescriptionString(Client.CurrentScenario)))
				{
					text6 = text6 + " (" + activeUnit_0.ActiveMissionOrPackage().get_DescriptionString(Client.CurrentScenario) + ")";
				}
				TextBlock_MissionName.Text = text6;
				if (!activeUnit_0.ActiveMissionOrPackage().IsActive)
				{
					Run textBlock_MissionName;
					(textBlock_MissionName = TextBlock_MissionName).Text = textBlock_MissionName.Text + " - Inactive";
				}
			}
			else
			{
				method_30((Visibility)2);
			}
			if (!activeUnit_0.CommStuff.IsConnectedToSideNetwork)
			{
				method_32((Visibility)2);
			}
			else
			{
				method_32((Visibility)0);
				method_0(activeUnit_0);
			}
			if (activeUnit_0.AssignedMissionsQueue.Count > 0 && activeUnit_0.get_UnitSide(SetSideOnly: false) == Client.CurrentSide)
			{
				((UIElement)TextBlock_QueuedMission).Visibility = (Visibility)0;
				string text7 = "";
				if (activeUnit_0.AssignedMissionsQueue.Count > 0)
				{
					TextBlock_QueuedMission.Text = activeUnit_0.AssignedMissionsQueue.Count + " queued missions";
					foreach (KeyValuePair<Mission, Mission> item2 in activeUnit_0.AssignedMissionsQueue.OrderBy([SpecialName] (KeyValuePair<Mission, Mission> x) => x.Key.PriorityWeight).ToList())
					{
						text7 = text7 + item2.Value.Name + " priority " + item2.Value.PriorityWeight;
						text7 += Environment.NewLine;
					}
				}
				else
				{
					TextBlock_QueuedMission.Text = "";
				}
				((ContentControl)tip1).Content = text7;
			}
			else
			{
				((UIElement)TextBlock_QueuedMission).Visibility = (Visibility)2;
				((UIElement)tip1).IsEnabled = false;
				((ContentControl)tip1).Content = "";
				TextBlock_QueuedMission.Text = "";
			}
			if (activeUnit_0.IsDecoy)
			{
				string text8 = "[DECOY] ";
				((ContentControl)Label_UnitName).Content = text8 + Conversions.ToString(((ContentControl)Label_UnitName).Content);
				TextBlock_UnitCategory.Text = text8 + TextBlock_UnitCategory.Text;
				TextBlock_UnitType.Text = text8 + TextBlock_UnitType.Text;
				TextBlock_UnitClass.Text = text8 + TextBlock_UnitClass.Text;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2.Data.Add("Error at 32165474243245", ex2.Message);
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
			group_0 = null;
			activeUnit_0 = null;
			contact_0 = null;
			((FrameworkContentElement)Hyperlink_Mission).Tag = null;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	public void RefreshPanel(Scenario theScen, Side theSide, Module_Unit.Unit theUnit)
	{
		TextBlock_UnitCategory.Text = "";
		TextBlock_UnitType.Text = "";
		try
		{
			Image_UnitImage.Source = null;
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
		if (theUnit == null)
		{
			method_3(theScen, theSide, null);
			method_4(theScen, theSide, null);
			method_5(theScen, theSide, null);
			return;
		}
		group_0 = null;
		activeUnit_0 = null;
		contact_0 = null;
		if (theUnit.IsContact())
		{
			method_3(theScen, theSide, theUnit);
		}
		else if (!theUnit.IsGroup)
		{
			if (!theUnit.IsActiveUnit)
			{
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
			}
			else
			{
				method_5(theScen, theSide, theUnit);
			}
		}
		else
		{
			method_4(theScen, theSide, theUnit);
		}
	}

	private void method_6(object sender, RoutedEventArgs e)
	{
		Contact contact = null;
		if (activeUnit_0 == null)
		{
			if (group_0 != null)
			{
				contact = group_0.AI.PrimaryTarget;
			}
		}
		else
		{
			contact = activeUnit_0.AI.PrimaryTarget;
		}
		if (contact != null)
		{
			Client.SelectThisUnit(contact, ThisUnitOnly: true);
			MyProject.Forms.MainForm.SetCameraView(((Module_Unit.Unit)contact).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)contact).get_Longitude((GlobalVariables.BooleanObject)null));
		}
	}

	private void method_7(object sender, RoutedEventArgs e)
	{
		damageDetailsFormRequestedEventHandler_0?.Invoke();
	}

	private void method_8(object sender, RoutedEventArgs e)
	{
		Client.ShowAirOps();
	}

	private void method_9(object sender, RoutedEventArgs e)
	{
		magazinesFormRequestedEventHandler_0?.Invoke();
	}

	private void method_10(object sender, RoutedEventArgs e)
	{
		sensorsFormRequestedEventHandler_0?.Invoke();
	}

	private void method_11(object sender, RoutedEventArgs e)
	{
		weaponsFormRequestedEventHandler_0?.Invoke();
	}

	private void method_12(object sender, RoutedEventArgs e)
	{
		commsFormRequestedEventHandler_0?.Invoke();
	}

	private void method_13()
	{
		//IL_02e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e6: Expected O, but got Unknown
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected O, but got Unknown
		if (group_0 == null)
		{
			return;
		}
		((ItemsControl)ListView_GroupMembers).Items.Clear();
		if (group_0.Type != Group.GroupType.AirGroup && group_0.Type != Group.GroupType.SurfaceGroup && group_0.Type != Group.GroupType.SubGroup)
		{
			IEnumerable<string> enumerable = (from theAU in group_0.Units.Values
				select Misc.RemoveHiddenString(theAU.UnitClass) into UC
				orderby UC
				select UC).Distinct();
			{
				_Closure$__55-0 closure$__55- = default(_Closure$__55-0);
				foreach (string item in enumerable)
				{
					closure$__55- = new _Closure$__55-0(closure$__55-);
					closure$__55-.$VB$Local_UCString = item;
					IEnumerable<ActiveUnit> source = group_0.Units.Values.Select([SpecialName] (ActiveUnit theAU) => theAU).Where(closure$__55-._Lambda$__5);
					int num = source.Count();
					ListViewItem val = new ListViewItem();
					val.Text = Conversions.ToString(num) + "x " + closure$__55-.$VB$Local_UCString;
					string text;
					if (source.ElementAtOrDefault(0).IsAircraft)
					{
						text = "Aircraft";
					}
					else if (!source.ElementAtOrDefault(0).IsShip)
					{
						if (!source.ElementAtOrDefault(0).IsSubmarine)
						{
							if (!source.ElementAtOrDefault(0).IsFacility)
							{
								if (!source.ElementAtOrDefault(0).IsMobileGroundUnit)
								{
									if (!source.ElementAtOrDefault(0).IsSatellite)
									{
										if (!source.ElementAtOrDefault(0).IsSatellite)
										{
											if (Debugger.IsAttached)
											{
												Debugger.Break();
											}
											continue;
										}
										text = "Weapon";
									}
									else
									{
										text = "Satellite";
									}
								}
								else
								{
									text = "GroundUnit";
								}
							}
							else
							{
								text = "Facility";
							}
						}
						else
						{
							text = "Submarine";
						}
					}
					else
					{
						text = "Ship";
					}
					val.Tag = text + "_" + Conversions.ToString(source.ElementAtOrDefault(0).DBID);
					((ItemsControl)ListView_GroupMembers).Items.Add((object)val);
				}
				return;
			}
		}
		IEnumerable<ActiveUnit> enumerable2 = from theAU in group_0.Units.Values
			select (theAU) into theAU
			orderby theAU.Name
			select theAU;
		foreach (ActiveUnit item2 in enumerable2)
		{
			ListViewItem val2 = new ListViewItem();
			val2.Text = ((!item2.IsGroupLead()) ? "" : "[LEAD] ") + item2.Name + " (" + item2.UnitClass + ")";
			val2.Tag = item2.ObjectID;
			((ItemsControl)ListView_GroupMembers).Items.Add((object)val2);
		}
	}

	private void method_14(object sender, RoutedEventArgs e)
	{
		((HeaderedContentControl)Expander_GroupMembers).Header = "Group Composition:";
	}

	private void method_15(object sender, RoutedEventArgs e)
	{
		((HeaderedContentControl)Expander_GroupMembers).Header = "Group Composition:";
		method_13();
	}

	private void method_16(object sender, RoutedEventArgs e)
	{
	}

	private void method_17(object sender, RoutedEventArgs e)
	{
		if (Client.SelectedUnit != null)
		{
			ActiveUnit activeUnit_ = (ActiveUnit)Client.SelectedUnit;
			method_18(ref activeUnit_);
		}
	}

	private void method_18(ref ActiveUnit activeUnit_1)
	{
		//IL_02e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02eb: Expected O, but got Unknown
		//IL_039f: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a6: Expected O, but got Unknown
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Expected O, but got Unknown
		//IL_045d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0464: Expected O, but got Unknown
		//IL_0512: Unknown result type (might be due to invalid IL or missing references)
		//IL_0519: Expected O, but got Unknown
		//IL_01f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fc: Expected O, but got Unknown
		if (activeUnit_1 == null)
		{
			return;
		}
		((ItemsControl)ListView_TankerClients).Items.Clear();
		if (activeUnit_1.IsAircraft)
		{
			Aircraft aircraft = (Aircraft)activeUnit_1;
			List<KeyValuePair<string, Aircraft_AirOps.GEnum0>> list = new List<KeyValuePair<string, Aircraft_AirOps.GEnum0>>();
			list.AddRange(aircraft.AirOps.A2AR_Connections);
			Aircraft aircraft2 = default(Aircraft);
			foreach (KeyValuePair<string, Aircraft_AirOps.GEnum0> item in list)
			{
				if (Client.CurrentScenario.ActiveUnits.ContainsKey(item.Key))
				{
					aircraft2 = (Aircraft)Client.CurrentScenario.ActiveUnits[item.Key];
					ListViewItem val = new ListViewItem();
					val.Text = "Refuelling: " + aircraft2.Name + " (" + aircraft2.UnitClass + ")";
					val.Tag = "Aircraft_" + Conversions.ToString(aircraft2.DBID);
					((ItemsControl)ListView_TankerClients).Items.Add((object)val);
				}
				else
				{
					aircraft.AirOps.A2AR_Connections.Remove(item.Key);
					aircraft.AirOps.A2AR_NumberOfReceiverHookups.Add(new ActiveUnit.ActiveUnit_Struct(((ActiveUnit)aircraft2).get_UnitSide(SetSideOnly: false), aircraft2.ObjectID, aircraft2.Name, aircraft2.DBID));
				}
			}
			List<KeyValuePair<string, byte>> list2 = new List<KeyValuePair<string, byte>>();
			list2.AddRange(aircraft.AirOps.RefuellingQueue);
			{
				foreach (KeyValuePair<string, byte> item2 in list2)
				{
					if (!Client.CurrentScenario.ActiveUnits.ContainsKey(item2.Key))
					{
						aircraft.AirOps.RefuellingQueue.Remove(item2.Key);
						continue;
					}
					aircraft2 = (Aircraft)Client.CurrentScenario.ActiveUnits[item2.Key];
					ListViewItem val2 = new ListViewItem();
					val2.Text = "In queue: " + aircraft2.Name + " (" + aircraft2.UnitClass + ")";
					val2.Tag = "Aircraft_" + Conversions.ToString(aircraft2.DBID);
					((ItemsControl)ListView_TankerClients).Items.Add((object)val2);
				}
				return;
			}
		}
		if (!activeUnit_1.IsShip)
		{
			return;
		}
		Ship ship = (Ship)activeUnit_1;
		if (!string.IsNullOrEmpty(((Ship)activeUnit_1).DockingOps.UNREP_Starboard_ReceiverUnitID))
		{
			Ship ship2 = (Ship)Client.CurrentScenario.ActiveUnits[((Ship)activeUnit_1).DockingOps.UNREP_Starboard_ReceiverUnitID];
			if (ship2 != null)
			{
				ListViewItem val3 = new ListViewItem();
				val3.Text = "UNREP, Starboard: " + ship2.Name + " (" + ship2.UnitClass + ")";
				val3.Tag = "Ship_" + Conversions.ToString(ship2.DBID);
				((ItemsControl)ListView_TankerClients).Items.Add((object)val3);
			}
		}
		if (!string.IsNullOrEmpty(((Ship)activeUnit_1).DockingOps.UNREP_Port_ReceiverUnitID))
		{
			Ship ship3 = (Ship)Client.CurrentScenario.ActiveUnits[((Ship)activeUnit_1).DockingOps.UNREP_Port_ReceiverUnitID];
			if (ship3 != null)
			{
				ListViewItem val4 = new ListViewItem();
				val4.Text = "UNREP, Port: " + ship3.Name + " (" + ship3.UnitClass + ")";
				val4.Tag = "Ship_" + Conversions.ToString(ship3.DBID);
				((ItemsControl)ListView_TankerClients).Items.Add((object)val4);
			}
		}
		if (!string.IsNullOrEmpty(((Ship)activeUnit_1).DockingOps.UNREP_Astern_ReceiverUnitID))
		{
			Ship ship4 = (Ship)Client.CurrentScenario.ActiveUnits[((Ship)activeUnit_1).DockingOps.UNREP_Astern_ReceiverUnitID];
			if (ship4 != null)
			{
				ListViewItem val5 = new ListViewItem();
				val5.Text = "UNREP, Astern: " + ship4.Name + " (" + ship4.UnitClass + ")";
				val5.Tag = "Ship_" + Conversions.ToString(ship4.DBID);
				((ItemsControl)ListView_TankerClients).Items.Add((object)val5);
			}
		}
		foreach (string item3 in ship.DockingOps.UNREP_Queue)
		{
			Ship ship5 = (Ship)Client.CurrentScenario.ActiveUnits[item3];
			if (ship5 != null)
			{
				ListViewItem val6 = new ListViewItem();
				val6.Text = "In queue: " + ship5.Name + " (" + ship5.UnitClass + ")";
				val6.Tag = "Ship_" + Conversions.ToString(ship5.DBID);
				((ItemsControl)ListView_TankerClients).Items.Add((object)val6);
			}
		}
	}

	private void UnitStatus_WPF_SizeChanged(object sender, SizeChangedEventArgs e)
	{
		panelSizeChangedEventHandler_0?.Invoke();
	}

	private void method_19(object sender, RoutedEventArgs e)
	{
		if (Client.SelectedUnit != null)
		{
			if (!Client.SelectedUnit.IsContact())
			{
				return;
			}
			MyProject.Forms.ContactReport.theContact = (Contact)Client.SelectedUnit;
		}
		else
		{
			if (contact_0 == null)
			{
				return;
			}
			MyProject.Forms.ContactReport.theContact = contact_0;
		}
		((Control)MyProject.Forms.ContactReport).Show();
	}

	private void method_20(object sender, RoutedEventArgs e)
	{
		MyProject.Forms.MainForm.ShowCargoOps();
	}

	private void method_21(object sender, RoutedEventArgs e)
	{
		Client.ShowDockingOps();
	}

	private void method_22(object sender, RoutedEventArgs e)
	{
		if (Client.SelectedUnit != null)
		{
			((Control)MyProject.Forms.MCMWindow).Show();
		}
	}

	private void method_23(object sender, SelectionChangedEventArgs e)
	{
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		if (((Selector)ListView_GroupMembers).SelectedItem == null)
		{
			return;
		}
		Group.GroupType type = group_0.Type;
		if (type > Group.GroupType.SubGroup)
		{
			string text = Conversions.ToString(((ListViewItem)((ListBox)ListView_GroupMembers).SelectedItems[0]).Tag);
			string selectedObjectType = text.ToString().Split(new char[1] { '_' })[0];
			int selectedObjectID = Conversions.ToInteger(text.ToString().Split(new char[1] { '_' })[1]);
			Client.smethod_17(selectedObjectType, selectedObjectID);
			return;
		}
		string key = Conversions.ToString(((ListViewItem)((ListBox)ListView_GroupMembers).SelectedItems[0]).Tag);
		if (Client.CurrentScenario.ActiveUnits.ContainsKey(key))
		{
			Client.SelectThisUnit(Client.CurrentScenario.ActiveUnits[key], ThisUnitOnly: true);
			if (Client.CurrentMapProfile.ViewMode == MapProfile.MapViewMode.GroupView)
			{
				MyProject.Forms.MainForm.SwitchView();
			}
		}
	}

	private void method_24(object sender, RoutedEventArgs e)
	{
		if (Client.SelectedUnit != null && Client.SelectedUnit.IsGroup)
		{
			if (((ToggleButton)CB_GroupLeadSlowDown).IsChecked != true)
			{
				Client.DispatchSimpleUnitAction(Client.SelectedUnit, Client.SimpleUnitAction.LeadAllowedToSlowDownOff);
			}
			else
			{
				Client.DispatchSimpleUnitAction(Client.SelectedUnit, Client.SimpleUnitAction.LeadAllowedToSlowDownOn);
			}
		}
	}

	private void method_25(object sender, RoutedEventArgs e)
	{
		if (((FrameworkContentElement)Hyperlink_Mission).Tag != null)
		{
			Client.MissionEditorWindow.SelectedMissionLink = (Mission)((FrameworkContentElement)Hyperlink_Mission).Tag;
			Module_Unit.Unit selectedUnit = Client.SelectedUnit;
			if (selectedUnit != null && selectedUnit.IsActiveUnit)
			{
				Client.MissionEditorWindow.theSelectedUnit = (ActiveUnit)Client.SelectedUnit;
			}
			if (!((Control)Client.MissionEditorWindow).Visible)
			{
				((Control)Client.MissionEditorWindow).Show();
			}
			else
			{
				Client.MissionEditorWindow.RefreshAll();
			}
		}
	}

	private void method_26(object sender, RoutedEventArgs e)
	{
		if (Client.SelectedUnit != null)
		{
			activeUnit_0 = null;
			if (Client.SelectedUnit.IsActiveUnit)
			{
				activeUnit_0 = (ActiveUnit)Client.SelectedUnit;
			}
			if (Client.SelectedUnit.IsContact())
			{
				activeUnit_0 = ((Contact)Client.SelectedUnit).ActualUnit;
			}
			if (Client.SelectedUnit.IsGroup && ((Group)Client.SelectedUnit).Type == Group.GroupType.AirGroup)
			{
				activeUnit_0 = ((Group)Client.SelectedUnit).Units.Values.ElementAtOrDefault(0);
			}
			if (activeUnit_0 == null)
			{
				return;
			}
		}
		else if (activeUnit_0 == null)
		{
			return;
		}
		Client.smethod_18(activeUnit_0);
	}

	private void method_27(object sender, RoutedEventArgs e)
	{
		if (Client.SelectedUnit != null)
		{
			activeUnit_0 = null;
			if (Client.SelectedUnit.IsGroup && ((Group)Client.SelectedUnit).Type == Group.GroupType.AirGroup)
			{
				activeUnit_0 = ((Group)Client.SelectedUnit).Units.Values.ElementAtOrDefault(0);
			}
			else
			{
				if (!Client.SelectedUnit.IsAircraft)
				{
					return;
				}
				activeUnit_0 = (Aircraft)Client.SelectedUnit;
			}
			if (activeUnit_0 == null)
			{
				return;
			}
		}
		else if (activeUnit_0 == null)
		{
			return;
		}
		Client.smethod_18(activeUnit_0, "Loadout" + Conversions.ToString(((Aircraft)activeUnit_0).LoadoutDBID));
	}

	private void method_28(object sender, RoutedEventArgs e)
	{
		if (Client.SelectedUnit == null)
		{
			if (activeUnit_0 == null)
			{
				return;
			}
			MyProject.Forms.UnitMessageLog.SelectedUnitID = activeUnit_0.ObjectID;
		}
		else
		{
			MyProject.Forms.UnitMessageLog.SelectedUnitID = Client.SelectedUnit.ObjectID;
		}
		((Control)MyProject.Forms.UnitMessageLog).Show();
	}

	private void method_29(object sender, RoutedEventArgs e)
	{
		if (Client.SelectedUnit == null)
		{
			if (activeUnit_0 == null)
			{
				return;
			}
			MyProject.Forms.UnitDecisionChecklistWindow.SelectedUnitID = activeUnit_0.ObjectID;
		}
		else
		{
			MyProject.Forms.UnitDecisionChecklistWindow.SelectedUnitID = Client.SelectedUnit.ObjectID;
		}
		((Control)MyProject.Forms.UnitDecisionChecklistWindow).Show();
	}

	private void UnitStatus_WPF_Loaded(object sender, RoutedEventArgs e)
	{
		MasterGrid.ShowGridLines = GameGeneral.Beta_UIGridLines;
		if (AGU_CONFIG.Instance.Enabled)
		{
			((UIElement)Button_EditAGU).Visibility = (Visibility)0;
		}
		else
		{
			((UIElement)Button_EditAGU).Visibility = (Visibility)2;
		}
	}

	[SpecialName]
	private void method_30(Visibility visibility_0)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((UIElement)TextBlock_Mission).Visibility = visibility_0;
	}

	[SpecialName]
	private void method_31(Visibility visibility_0)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((UIElement)TextBlock_AssignedHost).Visibility = visibility_0;
	}

	[SpecialName]
	private void method_32(Visibility visibility_0)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		((UIElement)ComponentStatusLabel).Visibility = visibility_0;
		((UIElement)ComponentStatusDockPanel).Visibility = visibility_0;
	}

	[SpecialName]
	private void method_33(Visibility visibility_0)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((UIElement)CB_GroupLeadSlowDown).Visibility = visibility_0;
	}

	[SpecialName]
	private void method_34(Visibility visibility_0)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		((UIElement)Button_Sensors).Visibility = visibility_0;
		((UIElement)Button_Weapons).Visibility = visibility_0;
		((UIElement)Button_Comms).Visibility = visibility_0;
	}

	[SpecialName]
	private void method_35(Visibility visibility_0)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		((UIElement)Label_FloodDamage).Visibility = visibility_0;
		((UIElement)PB_FloodDamage).Visibility = visibility_0;
	}

	[SpecialName]
	private void method_36(Visibility visibility_0)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		((UIElement)Label_FireDamage).Visibility = visibility_0;
		((UIElement)PB_FireDamage).Visibility = visibility_0;
	}

	[SpecialName]
	private void method_37(Visibility visibility_0)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		((UIElement)Label_DamageLabel).Visibility = visibility_0;
		((UIElement)Label_UnitDamage).Visibility = visibility_0;
		((UIElement)Button_Damage).Visibility = visibility_0;
	}

	[SpecialName]
	private void method_38(Visibility visibility_0)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		((UIElement)Button_DockOps).Visibility = visibility_0;
		((UIElement)Button_AirOps).Visibility = visibility_0;
	}

	[SpecialName]
	private void method_39(Visibility visibility_0)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((UIElement)TextBlock_UnitStatus).Visibility = visibility_0;
	}

	private void method_40(object sender, RoutedEventArgs e)
	{
		MyProject.Forms.MainForm.AddRemoveDockedBoats();
	}

	private void method_41(object sender, RoutedEventArgs e)
	{
		MyProject.Forms.MainForm.AddRemoveAircraft();
	}

	private void method_42(object sender, RoutedEventArgs e)
	{
		if (Client.SelectedUnit != null && Client.SelectedUnit.IsActiveUnit && ((ActiveUnit)Client.SelectedUnit).UnitType == GlobalVariables.ActiveUnitType.AggregateGroundUnit)
		{
			Client.CurrentUserAction = Client.UserAction.EditingAggregateUnit;
			AggregateGroundUnit aggregateGroundUnit = (AggregateGroundUnit)Client.SelectedUnit;
			aggregateGroundUnit.ParentScen = Client.CurrentScenario;
			((Control)MyProject.Forms.AggregateUnitEditor).Show();
			MyProject.Forms.AggregateUnitEditor.myUnit = aggregateGroundUnit;
		}
	}

	private void method_43(object sender, RoutedEventArgs e)
	{
		MyProject.Forms.MainForm.AddRemoveCargo();
	}

	private void method_44(object sender, SelectionChangedEventArgs e)
	{
		if (Client.SelectedUnit != null && Client.SelectedUnit.IsActiveUnit)
		{
			((ActiveUnit)Client.SelectedUnit).DesignatedSupplier = (ActiveUnit_DockingOps.ResupplyCapacity)((Selector)Combo_Supplier).SelectedIndex;
		}
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		if (!bool_0)
		{
			bool_0 = true;
			Uri uri = new Uri("/Command;component/customcontrols/rightcolumn/unitstatus_wpf.xaml", UriKind.Relative);
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
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Expected O, but got Unknown
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Expected O, but got Unknown
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Expected O, but got Unknown
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Expected O, but got Unknown
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Expected O, but got Unknown
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Expected O, but got Unknown
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Expected O, but got Unknown
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Expected O, but got Unknown
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Expected O, but got Unknown
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Expected O, but got Unknown
		//IL_0179: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Expected O, but got Unknown
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Expected O, but got Unknown
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Expected O, but got Unknown
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Expected O, but got Unknown
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cb: Expected O, but got Unknown
		//IL_01d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dd: Expected O, but got Unknown
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Expected O, but got Unknown
		//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0201: Expected O, but got Unknown
		//IL_0209: Unknown result type (might be due to invalid IL or missing references)
		//IL_0213: Expected O, but got Unknown
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0225: Expected O, but got Unknown
		//IL_022d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0237: Expected O, but got Unknown
		//IL_023f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0249: Expected O, but got Unknown
		//IL_0251: Unknown result type (might be due to invalid IL or missing references)
		//IL_025b: Expected O, but got Unknown
		//IL_0263: Unknown result type (might be due to invalid IL or missing references)
		//IL_026d: Expected O, but got Unknown
		//IL_0275: Unknown result type (might be due to invalid IL or missing references)
		//IL_027f: Expected O, but got Unknown
		//IL_0287: Unknown result type (might be due to invalid IL or missing references)
		//IL_0291: Expected O, but got Unknown
		//IL_0299: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a3: Expected O, but got Unknown
		//IL_02ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b5: Expected O, but got Unknown
		//IL_02bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c7: Expected O, but got Unknown
		//IL_02cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d9: Expected O, but got Unknown
		//IL_02e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02eb: Expected O, but got Unknown
		//IL_02f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fd: Expected O, but got Unknown
		//IL_0305: Unknown result type (might be due to invalid IL or missing references)
		//IL_030f: Expected O, but got Unknown
		//IL_0317: Unknown result type (might be due to invalid IL or missing references)
		//IL_0321: Expected O, but got Unknown
		//IL_0329: Unknown result type (might be due to invalid IL or missing references)
		//IL_0333: Expected O, but got Unknown
		//IL_033b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0345: Expected O, but got Unknown
		//IL_034d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0357: Expected O, but got Unknown
		//IL_035f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0369: Expected O, but got Unknown
		//IL_0371: Unknown result type (might be due to invalid IL or missing references)
		//IL_037b: Expected O, but got Unknown
		//IL_0383: Unknown result type (might be due to invalid IL or missing references)
		//IL_038d: Expected O, but got Unknown
		//IL_0395: Unknown result type (might be due to invalid IL or missing references)
		//IL_039f: Expected O, but got Unknown
		//IL_03a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b1: Expected O, but got Unknown
		//IL_03b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c3: Expected O, but got Unknown
		//IL_03cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d5: Expected O, but got Unknown
		//IL_03dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e7: Expected O, but got Unknown
		//IL_03ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f9: Expected O, but got Unknown
		//IL_0401: Unknown result type (might be due to invalid IL or missing references)
		//IL_040b: Expected O, but got Unknown
		//IL_0413: Unknown result type (might be due to invalid IL or missing references)
		//IL_041d: Expected O, but got Unknown
		//IL_0425: Unknown result type (might be due to invalid IL or missing references)
		//IL_042f: Expected O, but got Unknown
		//IL_0437: Unknown result type (might be due to invalid IL or missing references)
		//IL_0441: Expected O, but got Unknown
		//IL_0449: Unknown result type (might be due to invalid IL or missing references)
		//IL_0453: Expected O, but got Unknown
		//IL_045b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0465: Expected O, but got Unknown
		//IL_046c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0478: Unknown result type (might be due to invalid IL or missing references)
		//IL_0482: Expected O, but got Unknown
		//IL_048a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0494: Expected O, but got Unknown
		//IL_049c: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a6: Expected O, but got Unknown
		//IL_04ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b8: Expected O, but got Unknown
		//IL_04c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ca: Expected O, but got Unknown
		//IL_04d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04dc: Expected O, but got Unknown
		//IL_04e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ee: Expected O, but got Unknown
		//IL_04f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0500: Expected O, but got Unknown
		//IL_0508: Unknown result type (might be due to invalid IL or missing references)
		//IL_0512: Expected O, but got Unknown
		switch (connectionId)
		{
		case 1:
			MasterGrid = (Grid)target;
			break;
		case 2:
			Label_UnitName = (Label)target;
			break;
		case 3:
			Image_UnitImage = (Image)target;
			break;
		case 4:
			OuterTextBlock_UnitClass = (TextBlock)target;
			break;
		case 5:
			Hyperlink_UnitClass = (Hyperlink)target;
			break;
		case 6:
			TextBlock_UnitClass = (Run)target;
			break;
		case 7:
			OuterTextBlock_UnitCategory = (TextBlock)target;
			break;
		case 8:
			TextBlock_UnitCategory = (Run)target;
			break;
		case 9:
			OuterTextBlock_UnitType = (TextBlock)target;
			break;
		case 10:
			TextBlock_UnitType = (Run)target;
			break;
		case 11:
			OuterTextBlock_FiringParent = (TextBlock)target;
			break;
		case 12:
			TextBlock_FiringParent = (Run)target;
			break;
		case 13:
			Label_UnitProficiency = (Label)target;
			break;
		case 14:
			Label_UnitKills = (Label)target;
			break;
		case 15:
			Button_ContactReport = (Button)target;
			break;
		case 16:
			Button_UnitMessageLog = (Button)target;
			break;
		case 17:
			Button_UnitAIDebug = (Button)target;
			break;
		case 18:
			Expander_GroupMembers = (Expander)target;
			break;
		case 19:
			ListView_GroupMembers = (ListView)target;
			break;
		case 20:
			TextBlock_Loadout = (TextBlock)target;
			break;
		case 21:
			Hyperlink_Loadout = (Hyperlink)target;
			break;
		case 22:
			TextBlock_LoadoutName = (Run)target;
			break;
		case 23:
			Label_UnitSide = (Label)target;
			break;
		case 24:
			Label_UnitCourse = (Label)target;
			break;
		case 25:
			Label_UnitSpeed = (Label)target;
			break;
		case 26:
			Label_UnitAlt = (Label)target;
			break;
		case 27:
			CB_GroupLeadSlowDown = (CheckBox)target;
			break;
		case 28:
			Label_DamageLabel = (Label)target;
			break;
		case 29:
			Label_UnitDamage = (TextBlock)target;
			break;
		case 30:
			Button_Damage = (Button)target;
			break;
		case 31:
			ComponentStatusLabel = (Label)target;
			break;
		case 32:
			ComponentStatusDockPanel = (DockPanel)target;
			break;
		case 33:
			PB_ComponentsDestroyed = (ProgressBar)target;
			break;
		case 34:
			PB_ComponentsHeavyDamage = (ProgressBar)target;
			break;
		case 35:
			PB_ComponentsMediumDamage = (ProgressBar)target;
			break;
		case 36:
			PB_ComponentsLightDamage = (ProgressBar)target;
			break;
		case 37:
			PB_ComponentsOK = (ProgressBar)target;
			break;
		case 38:
			Label_FireDamage = (Label)target;
			break;
		case 39:
			PB_FireDamage = (ProgressBar)target;
			break;
		case 40:
			Label_FloodDamage = (Label)target;
			break;
		case 41:
			PB_FloodDamage = (ProgressBar)target;
			break;
		case 42:
			Label_GTolerance = (Label)target;
			break;
		case 43:
			PB_GTolerance = (ProgressBar)target;
			break;
		case 44:
			Button_MCM = (Button)target;
			break;
		case 45:
			Button_CargoOps = (Button)target;
			break;
		case 46:
			Button_Magazines = (Button)target;
			break;
		case 47:
			Button_DockOps = (Button)target;
			break;
		case 48:
			Button_AirOps = (Button)target;
			break;
		case 49:
			Label_Supply = (Label)target;
			break;
		case 50:
			Combo_Supplier = (ComboBox)target;
			break;
		case 51:
			Dockpanel_EditHosted = (DockPanel)target;
			break;
		case 52:
			Button_EditHostCargo = (Button)target;
			break;
		case 53:
			Button_EditHostedBoats = (Button)target;
			break;
		case 54:
			Button_EditHostedAC = (Button)target;
			break;
		case 55:
			Button_EditAGU = (Button)target;
			break;
		case 56:
			TextBlock_AssignedHost = (TextBlock)target;
			break;
		case 57:
			TextBlock_Mission = (TextBlock)target;
			break;
		case 58:
			Hyperlink_Mission = (Hyperlink)target;
			break;
		case 59:
			TextBlock_MissionName = (Run)target;
			break;
		case 60:
			TextBlock_QueuedMission = (TextBlock)target;
			break;
		case 61:
			tip1 = (ToolTip)target;
			break;
		case 62:
			TextBlock_UnitStatus = (TextBlock)target;
			break;
		case 63:
			TextBlock_PrimaryTarget = (TextBlock)target;
			break;
		case 64:
			((Hyperlink)target).Click += new RoutedEventHandler(method_6);
			break;
		case 65:
			Run_PrimaryTargetName = (Run)target;
			break;
		case 66:
			TextBlock_TimeUnderway = (TextBlock)target;
			break;
		case 67:
			Expander_TankerClients = (Expander)target;
			break;
		case 68:
			ListView_TankerClients = (ListView)target;
			break;
		case 69:
			Button_Sensors = (Button)target;
			break;
		case 70:
			Button_Comms = (Button)target;
			break;
		case 71:
			Button_Weapons = (Button)target;
			break;
		case 72:
			Label_ContactWRAType = (Label)target;
			break;
		default:
			bool_0 = true;
			break;
		}
	}

	static UnitStatus_WPF()
	{
		Class72.smethod_20();
	}
}
