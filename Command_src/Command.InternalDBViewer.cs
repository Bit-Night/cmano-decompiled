using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Windows.Forms;
using Command_Core;
using Command_Core.DAL;
using Command.My;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;

namespace Command;

[DesignerGenerated]
public sealed class InternalDBViewer : DarkSecondaryFormBase
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct VB$StateMachine_101_ScrollToSpecificElement : IAsyncStateMachine
	{
		public int $State;

		public AsyncVoidMethodBuilder $Builder;

		internal string $VB$Local_DesiredElementName;

		internal InternalDBViewer $VB$Me;

		internal TaskAwaiter<string> $A0;

		[CompilerGenerated]
		internal void MoveNext()
		{
			int num = $State;
			try
			{
				TaskAwaiter<string> awaiter;
				if (num == 0)
				{
					num = -1;
					$State = -1;
					awaiter = $A0;
					$A0 = default(TaskAwaiter<string>);
					goto IL_009c;
				}
				if ($VB$Me.WebBrowser1.CoreWebView2 != null && $VB$Local_DesiredElementName != null)
				{
					string javaScript = $"var element = document.getElementsByName('{$VB$Local_DesiredElementName}')[0]; element.scrollIntoView();";
					awaiter = $VB$Me.WebBrowser1.CoreWebView2.ExecuteScriptAsync(javaScript).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = 0;
						$State = 0;
						$A0 = awaiter;
						$Builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
						return;
					}
					goto IL_009c;
				}
				goto end_IL_0008;
				IL_009c:
				awaiter.GetResult();
				awaiter = default(TaskAwaiter<string>);
				end_IL_0008:;
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

		static VB$StateMachine_101_ScrollToSpecificElement()
		{
			Class72.smethod_20();
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _Closure$__
	{
		public static readonly _Closure$__ $I;

		public static Func<Sensor, int> $I140-0;

		public static Func<Sensor.RadioElectronicFrequency, string> $I140-1;

		public static Func<Sensor.RadioElectronicFrequency, string> $I140-2;

		public static Func<Sensor.RadioElectronicFrequency, string> $I140-3;

		public static Func<Sensor, int> $I141-0;

		public static Func<Mount, int> $I142-0;

		public static Func<Sensor, string> $I142-1;

		public static Func<Sensor, int> $I142-3;

		public static Func<Sensor.RadioElectronicFrequency, string> $I145-0;

		public static Func<Sensor.RadioElectronicFrequency, string> $I145-1;

		public static Func<Sensor.RadioElectronicFrequency, string> $I145-2;

		public static Func<Sensor.RadioElectronicFrequency, string> $I145-3;

		public static Func<Sensor.RadioElectronicFrequency, string> $I145-4;

		public static Func<Sensor.RadioElectronicFrequency, string> $I145-5;

		public static Func<WeaponRec, string> $I147-0;

		public static Func<CommDevice, int> $I148-0;

		public static Func<AirFacility, int> $I149-0;

		public static Func<DockFacility, int> $I150-0;

		public static Func<Warhead, string> $I157-0;

		public static Func<Engine, int> $I158-0;

		public static Func<AltBand, int> $I158-1;

		public static Func<AltBand, int> $I158-2;

		public static Func<Warhead, string> $I163-0;

		public static Func<Sensor, int> $I163-2;

		public static Func<string, string> $I165-0;

		public static Func<string, string> $I166-0;

		static _Closure$__()
		{
			Class72.smethod_20();
			$I = new _Closure$__();
		}

		[SpecialName]
		internal int _Lambda$__140-0(Sensor theS)
		{
			return theS.DBID;
		}

		[SpecialName]
		internal string _Lambda$__140-1(Sensor.RadioElectronicFrequency theF)
		{
			return theF.ToString_Short;
		}

		[SpecialName]
		internal string _Lambda$__140-2(Sensor.RadioElectronicFrequency theF)
		{
			return theF.ToString_Short;
		}

		[SpecialName]
		internal string _Lambda$__140-3(Sensor.RadioElectronicFrequency theF)
		{
			return theF.ToString_Short;
		}

		[SpecialName]
		internal int _Lambda$__141-0(Sensor theS)
		{
			return theS.DBID;
		}

		[SpecialName]
		internal int _Lambda$__142-0(Mount theM)
		{
			return theM.DBID;
		}

		[SpecialName]
		internal string _Lambda$__142-1(Sensor theS)
		{
			return theS.Name;
		}

		[SpecialName]
		internal int _Lambda$__142-3(Sensor theS)
		{
			return theS.DBID;
		}

		[SpecialName]
		internal string _Lambda$__145-0(Sensor.RadioElectronicFrequency theF)
		{
			return theF.ToString_Short;
		}

		[SpecialName]
		internal string _Lambda$__145-1(Sensor.RadioElectronicFrequency theF)
		{
			return theF.ToString_Short;
		}

		[SpecialName]
		internal string _Lambda$__145-2(Sensor.RadioElectronicFrequency theF)
		{
			return theF.ToString_Short;
		}

		[SpecialName]
		internal string _Lambda$__145-3(Sensor.RadioElectronicFrequency theF)
		{
			return theF.ToString_Short;
		}

		[SpecialName]
		internal string _Lambda$__145-4(Sensor.RadioElectronicFrequency theF)
		{
			return theF.ToString_Short;
		}

		[SpecialName]
		internal string _Lambda$__145-5(Sensor.RadioElectronicFrequency theF)
		{
			return theF.ToString_Short;
		}

		[SpecialName]
		internal string _Lambda$__147-0(WeaponRec theWR)
		{
			return ((theWR.CurrentLoad != 0) ? "" : "<i style='color:gray'>") + Conversions.ToString(theWR.CurrentLoad) + " x " + theWR.get_ReferenceWeapon(Client.CurrentScenario).Name + " (max " + Conversions.ToString(theWR.MaxLoad) + ")" + ((theWR.CurrentLoad != 0) ? "" : "</i>");
		}

		[SpecialName]
		internal int _Lambda$__148-0(CommDevice theC)
		{
			return theC.DBID;
		}

		[SpecialName]
		internal int _Lambda$__149-0(AirFacility theAF)
		{
			return theAF.DBID;
		}

		[SpecialName]
		internal int _Lambda$__150-0(DockFacility theAF)
		{
			return theAF.DBID;
		}

		[SpecialName]
		internal string _Lambda$__157-0(Warhead theWH)
		{
			return theWH.Name;
		}

		[SpecialName]
		internal int _Lambda$__158-0(Engine theE)
		{
			return theE.DBID;
		}

		[SpecialName]
		internal int _Lambda$__158-1(AltBand theAltBand)
		{
			return theAltBand.MaxSpeed.Value;
		}

		[SpecialName]
		internal int _Lambda$__158-2(AltBand theAltBand)
		{
			return theAltBand.MaxSpeed.Value;
		}

		[SpecialName]
		internal string _Lambda$__163-0(Warhead theWH)
		{
			return theWH.Name;
		}

		[SpecialName]
		internal int _Lambda$__163-2(Sensor theS)
		{
			return theS.DBID;
		}

		[SpecialName]
		internal string _Lambda$__165-0(string theStr)
		{
			return theStr.Split(new char[1] { '_' })[2] + " " + theStr.Split(new char[1] { '_' })[3] + " " + theStr.Split(new char[1] { '_' })[4];
		}

		[SpecialName]
		internal string _Lambda$__166-0(string theStr)
		{
			return theStr.Split(new char[1] { '_' })[0] + " " + theStr.Split(new char[1] { '_' })[2] + " " + theStr.Split(new char[1] { '_' })[3] + " " + theStr.Split(new char[1] { '_' })[4];
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__142-0
	{
		public Mount $VB$Local_theM;

		public _Closure$__142-0(_Closure$__142-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theM = arg0.$VB$Local_theM;
			}
		}

		[SpecialName]
		internal bool _Lambda$__2(Sensor theS)
		{
			return $VB$Local_theM.CompatibleDirectors.Contains(theS.DBID);
		}

		static _Closure$__142-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__163-0
	{
		public Weapon $VB$Local_theW;

		public _Closure$__163-0(_Closure$__163-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theW = arg0.$VB$Local_theW;
			}
		}

		[SpecialName]
		internal bool _Lambda$__1(Sensor theS)
		{
			return $VB$Local_theW.Directors.Contains(theS.DBID);
		}

		static _Closure$__163-0()
		{
			Class72.smethod_20();
		}
	}

	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("ListBox1")]
	private DarkListView _ListBox1;

	[AccessedThroughProperty("CB_Country")]
	[CompilerGenerated]
	private DarkUIComboBox _CB_Country;

	[CompilerGenerated]
	[AccessedThroughProperty("TB_Class")]
	private DarkUITextBox _TB_Class;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_ObjectType")]
	private DarkUIComboBox _CB_ObjectType;

	[CompilerGenerated]
	[AccessedThroughProperty("WebBrowser1")]
	private WebView2 _WebBrowser1;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_Hypothetical")]
	private DarkUIComboBox _CB_Hypothetical;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_SubType")]
	private DarkUIComboBox _CB_SubType;

	[CompilerGenerated]
	[AccessedThroughProperty("DuplicateWindowButton")]
	private DarkUIButton _DuplicateWindowButton;

	[AccessedThroughProperty("SearchDBIDButton")]
	[CompilerGenerated]
	private DarkUIButton _SearchDBIDButton;

	[AccessedThroughProperty("DBIDGOTO")]
	[CompilerGenerated]
	private DarkUITextBox _DBIDGOTO;

	[AccessedThroughProperty("NextButton")]
	[CompilerGenerated]
	private DarkUIButton _NextButton;

	[AccessedThroughProperty("PreviousButton")]
	[CompilerGenerated]
	private DarkUIButton _PreviousButton;

	public int SelectedObjectID;

	public int selectedSubType;

	public string HighlightTarget;

	public string string_0;

	public string SelectedObjectName;

	public string DatabaseObjectName;

	private DataTable dataTable_0;

	private bool bool_2;

	private int int_0;

	private int int_1;

	private bool bool_3;

	public List<DBViewerNavigationHistoryItem> DBViewerNavigationHistory;

	public int NavigationHistoryPosition;

	private string string_1;

	private string string_2;

	[CompilerGenerated]
	private bool bool_4;

	private bool bool_5;

	private DBOps.DBFileCheckResult dbfileCheckResult_0;

	public Dictionary<XSection._SignatureType, (float, float, float, float)> BaseSignatures;

	internal virtual DarkListView ListBox1
	{
		[CompilerGenerated]
		get
		{
			return _ListBox1;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_15;
			EventHandler eventHandler2 = method_16;
			EventHandler value2 = method_22;
			DarkListView darkListView = _ListBox1;
			if (darkListView != null)
			{
				((Control)darkListView).MouseEnter -= eventHandler;
				((Control)darkListView).MouseLeave -= eventHandler2;
				darkListView.SelectedIndicesChanged -= value2;
			}
			_ListBox1 = value;
			darkListView = _ListBox1;
			if (darkListView != null)
			{
				((Control)darkListView).MouseEnter += eventHandler;
				((Control)darkListView).MouseLeave += eventHandler2;
				darkListView.SelectedIndicesChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("GroupBox1")]
	internal virtual DarkGroupBox GroupBox1 { get; set; }

	internal virtual DarkUIComboBox CB_Country
	{
		[CompilerGenerated]
		get
		{
			return _CB_Country;
		}
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = method_6;
			MouseEventHandler val = new MouseEventHandler(method_7);
			DarkUIComboBox darkUIComboBox = _CB_Country;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).DropDownClosed -= eventHandler;
				((Control)darkUIComboBox).MouseWheel -= val;
			}
			_CB_Country = value;
			darkUIComboBox = _CB_Country;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).DropDownClosed += eventHandler;
				((Control)darkUIComboBox).MouseWheel += val;
			}
		}
	}

	[field: AccessedThroughProperty("Label5")]
	internal virtual DarkLabel Label5 { get; set; }

	[field: AccessedThroughProperty("Label4")]
	internal virtual DarkLabel Label4 { get; set; }

	internal virtual DarkUITextBox TB_Class
	{
		[CompilerGenerated]
		get
		{
			return _TB_Class;
		}
		[CompilerGenerated]
		set
		{
			DarkUITextBox.TextChangedEventHandler value2 = method_2;
			DarkUITextBox darkUITextBox = _TB_Class;
			if (darkUITextBox != null)
			{
				darkUITextBox.TextChanged -= value2;
			}
			_TB_Class = value;
			darkUITextBox = _TB_Class;
			if (darkUITextBox != null)
			{
				darkUITextBox.TextChanged += value2;
			}
		}
	}

	internal virtual DarkUIComboBox CB_ObjectType
	{
		[CompilerGenerated]
		get
		{
			return _CB_ObjectType;
		}
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = method_4;
			MouseEventHandler val = new MouseEventHandler(method_5);
			EventHandler eventHandler2 = method_26;
			DarkUIComboBox darkUIComboBox = _CB_ObjectType;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).DropDownClosed -= eventHandler;
				((Control)darkUIComboBox).MouseWheel -= val;
				((ComboBox)darkUIComboBox).SelectedIndexChanged -= eventHandler2;
			}
			_CB_ObjectType = value;
			darkUIComboBox = _CB_ObjectType;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).DropDownClosed += eventHandler;
				((Control)darkUIComboBox).MouseWheel += val;
				((ComboBox)darkUIComboBox).SelectedIndexChanged += eventHandler2;
			}
		}
	}

	[field: AccessedThroughProperty("Label1")]
	internal virtual DarkLabel Label1 { get; set; }

	internal virtual WebView2 WebBrowser1
	{
		[CompilerGenerated]
		get
		{
			return _WebBrowser1;
		}
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler<CoreWebView2NavigationCompletedEventArgs> value2 = method_8;
			PreviewKeyDownEventHandler val = new PreviewKeyDownEventHandler(method_19);
			EventHandler<CoreWebView2NavigationStartingEventArgs> value3 = method_20;
			EventHandler<CoreWebView2InitializationCompletedEventArgs> value4 = method_21;
			WebView2 webView = _WebBrowser1;
			if (webView != null)
			{
				webView.NavigationCompleted -= value2;
				((Control)webView).PreviewKeyDown -= val;
				webView.NavigationStarting -= value3;
				webView.CoreWebView2InitializationCompleted -= value4;
			}
			_WebBrowser1 = value;
			webView = _WebBrowser1;
			if (webView != null)
			{
				webView.NavigationCompleted += value2;
				((Control)webView).PreviewKeyDown += val;
				webView.NavigationStarting += value3;
				webView.CoreWebView2InitializationCompleted += value4;
			}
		}
	}

	internal virtual DarkUIComboBox CB_Hypothetical
	{
		[CompilerGenerated]
		get
		{
			return _CB_Hypothetical;
		}
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = method_17;
			MouseEventHandler val = new MouseEventHandler(method_18);
			DarkUIComboBox darkUIComboBox = _CB_Hypothetical;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).DropDownClosed -= eventHandler;
				((Control)darkUIComboBox).MouseWheel -= val;
			}
			_CB_Hypothetical = value;
			darkUIComboBox = _CB_Hypothetical;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).DropDownClosed += eventHandler;
				((Control)darkUIComboBox).MouseWheel += val;
			}
		}
	}

	[field: AccessedThroughProperty("Label7")]
	internal virtual DarkLabel Label7 { get; set; }

	internal virtual DarkUIComboBox CB_SubType
	{
		[CompilerGenerated]
		get
		{
			return _CB_SubType;
		}
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = method_31;
			MouseEventHandler val = new MouseEventHandler(method_32);
			DarkUIComboBox darkUIComboBox = _CB_SubType;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).DropDownClosed -= eventHandler;
				((Control)darkUIComboBox).MouseWheel -= val;
			}
			_CB_SubType = value;
			darkUIComboBox = _CB_SubType;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).DropDownClosed += eventHandler;
				((Control)darkUIComboBox).MouseWheel += val;
			}
		}
	}

	[field: AccessedThroughProperty("TypeLabel")]
	internal virtual DarkLabel TypeLabel { get; set; }

	internal virtual DarkUIButton DuplicateWindowButton
	{
		[CompilerGenerated]
		get
		{
			return _DuplicateWindowButton;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_30;
			DarkUIButton darkUIButton = _DuplicateWindowButton;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_DuplicateWindowButton = value;
			darkUIButton = _DuplicateWindowButton;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton SearchDBIDButton
	{
		[CompilerGenerated]
		get
		{
			return _SearchDBIDButton;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_28;
			DarkUIButton darkUIButton = _SearchDBIDButton;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_SearchDBIDButton = value;
			darkUIButton = _SearchDBIDButton;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUITextBox DBIDGOTO
	{
		[CompilerGenerated]
		get
		{
			return _DBIDGOTO;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_29;
			DarkUITextBox darkUITextBox = _DBIDGOTO;
			if (darkUITextBox != null)
			{
				((Control)darkUITextBox).GotFocus -= eventHandler;
			}
			_DBIDGOTO = value;
			darkUITextBox = _DBIDGOTO;
			if (darkUITextBox != null)
			{
				((Control)darkUITextBox).GotFocus += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton NextButton
	{
		[CompilerGenerated]
		get
		{
			return _NextButton;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_25;
			DarkUIButton darkUIButton = _NextButton;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_NextButton = value;
			darkUIButton = _NextButton;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton PreviousButton
	{
		[CompilerGenerated]
		get
		{
			return _PreviousButton;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_24;
			DarkUIButton darkUIButton = _PreviousButton;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_PreviousButton = value;
			darkUIButton = _PreviousButton;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	public string SelectedObjectType
	{
		get
		{
			if (Operators.CompareString(string_2, "GroundUnit", true) == 0)
			{
				string_2 = "Ground Unit";
			}
			return string_2;
		}
		set
		{
			string_2 = value;
		}
	}

	protected override bool RTMPEnabled
	{
		[CompilerGenerated]
		get
		{
			return bool_4;
		}
		[CompilerGenerated]
		set
		{
			bool_4 = value;
		}
	}

	public InternalDBViewer()
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected O, but got Unknown
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Expected O, but got Unknown
		((Form)this).FormClosing += new FormClosingEventHandler(InternalDBViewer_FormClosing);
		((Form)this).Load += InternalDBViewer_Load;
		((Form)this).Load += InternalDBViewer_Load_1;
		((Form)this).Shown += InternalDBViewer_Shown;
		((Control)this).KeyDown += new KeyEventHandler(InternalDBViewer_KeyDown);
		((Control)this).MouseWheel += new MouseEventHandler(InternalDBViewer_MouseWheel);
		((Control)this).KeyDown += new KeyEventHandler(InternalDBViewer_KeyDown_1);
		dataTable_0 = new DataTable();
		DBViewerNavigationHistory = new List<DBViewerNavigationHistoryItem>();
		NavigationHistoryPosition = -1;
		string_1 = "https://Root/";
		RTMPEnabled = true;
		bool_5 = false;
		BaseSignatures = new Dictionary<XSection._SignatureType, (float, float, float, float)>();
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
		//IL_0251: Unknown result type (might be due to invalid IL or missing references)
		//IL_025b: Expected O, but got Unknown
		//IL_0373: Unknown result type (might be due to invalid IL or missing references)
		//IL_037d: Expected O, but got Unknown
		//IL_047c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0486: Expected O, but got Unknown
		//IL_061a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0624: Expected O, but got Unknown
		//IL_0743: Unknown result type (might be due to invalid IL or missing references)
		//IL_074d: Expected O, but got Unknown
		//IL_096f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0979: Expected O, but got Unknown
		//IL_0a1e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a28: Expected O, but got Unknown
		//IL_0ae6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0af0: Expected O, but got Unknown
		//IL_0c08: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c12: Expected O, but got Unknown
		//IL_0cb1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cbb: Expected O, but got Unknown
		GroupBox1 = new DarkGroupBox();
		CB_SubType = new DarkUIComboBox();
		TypeLabel = new DarkLabel();
		CB_Hypothetical = new DarkUIComboBox();
		Label7 = new DarkLabel();
		CB_Country = new DarkUIComboBox();
		Label5 = new DarkLabel();
		Label4 = new DarkLabel();
		TB_Class = new DarkUITextBox();
		CB_ObjectType = new DarkUIComboBox();
		ListBox1 = new DarkListView();
		Label1 = new DarkLabel();
		WebBrowser1 = new WebView2();
		DuplicateWindowButton = new DarkUIButton();
		SearchDBIDButton = new DarkUIButton();
		DBIDGOTO = new DarkUITextBox();
		NextButton = new DarkUIButton();
		PreviousButton = new DarkUIButton();
		((Control)GroupBox1).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)GroupBox1).Controls.Add((Control)(object)CB_SubType);
		((Control)GroupBox1).Controls.Add((Control)(object)TypeLabel);
		((Control)GroupBox1).Controls.Add((Control)(object)CB_Hypothetical);
		((Control)GroupBox1).Controls.Add((Control)(object)Label7);
		((Control)GroupBox1).Controls.Add((Control)(object)CB_Country);
		((Control)GroupBox1).Controls.Add((Control)(object)Label5);
		((Control)GroupBox1).Controls.Add((Control)(object)Label4);
		((Control)GroupBox1).Controls.Add((Control)(object)TB_Class);
		((Control)GroupBox1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)GroupBox1).Location = new Point(4, 39);
		((Control)GroupBox1).Name = "GroupBox1";
		((Control)GroupBox1).Size = new Size(281, 129);
		((Control)GroupBox1).TabIndex = 21;
		((GroupBox)GroupBox1).TabStop = false;
		((GroupBox)GroupBox1).Text = "Filter by...";
		((Control)CB_SubType).Anchor = (AnchorStyles)13;
		((ComboBox)CB_SubType).BackColor = Color.Transparent;
		((ComboBox)CB_SubType).DrawMode = (DrawMode)1;
		((ComboBox)CB_SubType).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_SubType).Font = new Font("Segoe UI", 7f);
		((Control)CB_SubType).Location = new Point(92, 93);
		((ComboBox)CB_SubType).MaxDropDownItems = 4;
		((Control)CB_SubType).Name = "CB_SubType";
		((Control)CB_SubType).Size = new Size(184, 21);
		((Control)CB_SubType).TabIndex = 20;
		TypeLabel.AutoSize = true;
		((Control)TypeLabel).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)TypeLabel).Location = new Point(8, 97);
		((Control)TypeLabel).Name = "TypeLabel";
		((Control)TypeLabel).Size = new Size(54, 15);
		((Control)TypeLabel).TabIndex = 19;
		((Label)TypeLabel).Text = "SubType:";
		((Control)CB_Hypothetical).Anchor = (AnchorStyles)13;
		((ComboBox)CB_Hypothetical).BackColor = Color.Transparent;
		((ComboBox)CB_Hypothetical).DrawMode = (DrawMode)1;
		((ComboBox)CB_Hypothetical).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_Hypothetical).Font = new Font("Segoe UI", 7f);
		((Control)CB_Hypothetical).Location = new Point(91, 66);
		((Control)CB_Hypothetical).Name = "CB_Hypothetical";
		((Control)CB_Hypothetical).Size = new Size(184, 21);
		((Control)CB_Hypothetical).TabIndex = 18;
		Label7.AutoSize = true;
		((Control)Label7).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label7).Location = new Point(7, 70);
		((Control)Label7).Name = "Label7";
		((Control)Label7).Size = new Size(78, 15);
		((Control)Label7).TabIndex = 17;
		((Label)Label7).Text = "Hypothetical:";
		((ComboBox)CB_Country).BackColor = Color.Transparent;
		((ComboBox)CB_Country).DrawMode = (DrawMode)1;
		((ComboBox)CB_Country).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_Country).Font = new Font("Segoe UI", 7f);
		((Control)CB_Country).Location = new Point(91, 41);
		((Control)CB_Country).Name = "CB_Country";
		((Control)CB_Country).Size = new Size(184, 21);
		((Control)CB_Country).TabIndex = 13;
		Label5.AutoSize = true;
		((Control)Label5).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label5).Location = new Point(7, 45);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(53, 15);
		((Control)Label5).TabIndex = 12;
		((Label)Label5).Text = "Country:";
		Label4.AutoSize = true;
		((Control)Label4).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label4).Location = new Point(7, 21);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(37, 15);
		((Control)Label4).TabIndex = 11;
		((Label)Label4).Text = "Class:";
		TB_Class.AutoCompleteCustomSource = null;
		TB_Class.AutoCompleteMode = (AutoCompleteMode)0;
		TB_Class.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TB_Class).BackColor = Color.FromArgb(69, 73, 74);
		TB_Class.Font = new Font("Segoe UI", 8f);
		((Control)TB_Class).ForeColor = Color.FromArgb(220, 220, 220);
		TB_Class.Image = null;
		TB_Class.Lines = null;
		((Control)TB_Class).Location = new Point(91, 17);
		TB_Class.MaxLength = 32767;
		TB_Class.Multiline = false;
		((Control)TB_Class).Name = "TB_Class";
		TB_Class.ReadOnly = false;
		TB_Class.ScrollBars = (ScrollBars)0;
		TB_Class.SelectionStart = 0;
		((Control)TB_Class).Size = new Size(184, 20);
		((Control)TB_Class).TabIndex = 10;
		TB_Class.TextAlign = (HorizontalAlignment)0;
		TB_Class.UseSystemPasswordChar = false;
		TB_Class.WatermarkText = "";
		((ComboBox)CB_ObjectType).BackColor = Color.Transparent;
		((ComboBox)CB_ObjectType).DrawMode = (DrawMode)1;
		((ComboBox)CB_ObjectType).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_ObjectType).Font = new Font("Segoe UI", 7f);
		((ComboBox)CB_ObjectType).Items.AddRange(new object[7] { "Aircraft", "Ship", "Submarine", "Facility", "Ground Unit", "Satellite", "Weapon" });
		((Control)CB_ObjectType).Location = new Point(59, 12);
		((Control)CB_ObjectType).Name = "CB_ObjectType";
		((Control)CB_ObjectType).Size = new Size(226, 21);
		((Control)CB_ObjectType).TabIndex = 14;
		((Control)ListBox1).Anchor = (AnchorStyles)13;
		ListBox1.AutoResizeOnItemChange = false;
		((Control)ListBox1).Location = new Point(291, 12);
		((Control)ListBox1).Name = "ListBox1";
		((Control)ListBox1).Size = new Size(712, 156);
		((Control)ListBox1).TabIndex = 0;
		Label1.AutoSize = true;
		((Control)Label1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label1).Location = new Point(7, 15);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(31, 15);
		((Control)Label1).TabIndex = 22;
		((Label)Label1).Text = "Type";
		((Control)WebBrowser1).Anchor = (AnchorStyles)15;
		((Control)WebBrowser1).Location = new Point(4, 210);
		((Control)WebBrowser1).MinimumSize = new Size(20, 20);
		((Control)WebBrowser1).Name = "WebBrowser1";
		((Control)WebBrowser1).Size = new Size(999, 512);
		((Control)WebBrowser1).TabIndex = 23;
		((Control)DuplicateWindowButton).Anchor = (AnchorStyles)9;
		((ButtonBase)DuplicateWindowButton).BackColor = Color.Transparent;
		((Button)DuplicateWindowButton).DialogResult = (DialogResult)0;
		((Control)DuplicateWindowButton).Font = new Font("Segoe UI", 10f);
		((Control)DuplicateWindowButton).ForeColor = SystemColors.Control;
		((Control)DuplicateWindowButton).Location = new Point(863, 174);
		((Control)DuplicateWindowButton).Name = "DuplicateWindowButton";
		DuplicateWindowButton.RoundRadius = 0;
		((Control)DuplicateWindowButton).Size = new Size(140, 28);
		((Control)DuplicateWindowButton).TabIndex = 4;
		DuplicateWindowButton.Text = "Duplicate Window";
		((ButtonBase)SearchDBIDButton).BackColor = Color.Transparent;
		((Button)SearchDBIDButton).DialogResult = (DialogResult)0;
		((Control)SearchDBIDButton).Font = new Font("Segoe UI", 10f);
		((Control)SearchDBIDButton).ForeColor = SystemColors.Control;
		((Control)SearchDBIDButton).Location = new Point(473, 176);
		((Control)SearchDBIDButton).Name = "SearchDBIDButton";
		SearchDBIDButton.RoundRadius = 0;
		((Control)SearchDBIDButton).Size = new Size(43, 29);
		((Control)SearchDBIDButton).TabIndex = 3;
		SearchDBIDButton.Text = "Go";
		DBIDGOTO.AutoCompleteCustomSource = null;
		DBIDGOTO.AutoCompleteMode = (AutoCompleteMode)0;
		DBIDGOTO.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)DBIDGOTO).BackColor = Color.Transparent;
		DBIDGOTO.Font = new Font("Segoe UI", 11f);
		((Control)DBIDGOTO).ForeColor = Color.FromArgb(189, 189, 189);
		DBIDGOTO.Image = null;
		DBIDGOTO.Lines = null;
		((Control)DBIDGOTO).Location = new Point(202, 176);
		DBIDGOTO.MaxLength = 32767;
		DBIDGOTO.Multiline = false;
		((Control)DBIDGOTO).Name = "DBIDGOTO";
		DBIDGOTO.ReadOnly = false;
		DBIDGOTO.ScrollBars = (ScrollBars)0;
		DBIDGOTO.SelectionStart = 0;
		((Control)DBIDGOTO).Size = new Size(265, 29);
		((Control)DBIDGOTO).TabIndex = 2;
		DBIDGOTO.TextAlign = (HorizontalAlignment)2;
		DBIDGOTO.UseSystemPasswordChar = false;
		DBIDGOTO.WatermarkText = "";
		((ButtonBase)NextButton).BackColor = Color.Transparent;
		((Button)NextButton).DialogResult = (DialogResult)0;
		((Control)NextButton).Font = new Font("Segoe UI", 10f);
		((Control)NextButton).ForeColor = SystemColors.Control;
		((Control)NextButton).Location = new Point(103, 176);
		((Control)NextButton).Name = "NextButton";
		NextButton.RoundRadius = 0;
		((Control)NextButton).Size = new Size(93, 28);
		((Control)NextButton).TabIndex = 1;
		NextButton.Text = "Next";
		((ButtonBase)PreviousButton).BackColor = Color.Transparent;
		((Button)PreviousButton).DialogResult = (DialogResult)0;
		((Control)PreviousButton).Font = new Font("Segoe UI", 10f);
		((Control)PreviousButton).ForeColor = SystemColors.Control;
		((Control)PreviousButton).Location = new Point(4, 176);
		((Control)PreviousButton).Name = "PreviousButton";
		PreviousButton.RoundRadius = 0;
		((Control)PreviousButton).Size = new Size(93, 28);
		((Control)PreviousButton).TabIndex = 0;
		PreviousButton.Text = "Previous";
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(1008, 727);
		((Control)this).Controls.Add((Control)(object)DuplicateWindowButton);
		((Control)this).Controls.Add((Control)(object)SearchDBIDButton);
		((Control)this).Controls.Add((Control)(object)WebBrowser1);
		((Control)this).Controls.Add((Control)(object)DBIDGOTO);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)NextButton);
		((Control)this).Controls.Add((Control)(object)GroupBox1);
		((Control)this).Controls.Add((Control)(object)PreviousButton);
		((Control)this).Controls.Add((Control)(object)CB_ObjectType);
		((Control)this).Controls.Add((Control)(object)ListBox1);
		((Form)this).FormBorderStyle = (FormBorderStyle)6;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "InternalDBViewer";
		((Form)this).ShowIcon = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Database Viewer";
		((Control)GroupBox1).ResumeLayout(false);
		((Control)GroupBox1).PerformLayout();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	public void Show(string[] argsArray)
	{
		((Control)new InternalDBViewer
		{
			SelectedObjectType = argsArray[0],
			selectedSubType = -1,
			SelectedObjectID = Conversions.ToInteger(argsArray[1])
		}).Show();
	}

	private void InternalDBViewer_FormClosing(object sender, FormClosingEventArgs e)
	{
		((Control)MyProject.Forms.MainForm).BringToFront();
	}

	private void InternalDBViewer_Load(object sender, EventArgs e)
	{
		WebBrowserHelper.InitialiseWebview2Browser(WebBrowser1);
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
		if (Client.CurrentGame.Status == Game._GameStatus.Running && SimConfiguration.DefaultGamePreferences.PauseOnDBView == SimConfiguration.WindowPauseBehaviour.Pause)
		{
			Client.CurrentGame.Pause();
		}
		else if (Client.CurrentGame.Status == Game._GameStatus.Running && SimConfiguration.DefaultGamePreferences.PauseOnDBView == SimConfiguration.WindowPauseBehaviour.SlowToRealTime)
		{
			Client.CurrentScenario.TimeCompression_Set(Scenario.enumTimeCompression.OneSec);
		}
		((Form)this).WindowState = (FormWindowState)0;
		int_0 = -1;
		((Form)this).Text = "Database Viewer";
		int? num = Client.CurrentScenario?.DBConnection?.DataSource?.Length;
		if (((!num.HasValue) ? ((bool?)null) : new bool?(num.GetValueOrDefault() > 0)) == true)
		{
			((Form)this).Text = ((Form)this).Text + " (" + Client.CurrentScenario.DBConnection.DataSource + ")";
		}
	}

	[AsyncStateMachine(typeof(VB$StateMachine_101_ScrollToSpecificElement))]
	public void ScrollToSpecificElement(string DesiredElementName)
	{
		VB$StateMachine_101_ScrollToSpecificElement stateMachine = default(VB$StateMachine_101_ScrollToSpecificElement);
		stateMachine.$VB$Me = this;
		stateMachine.$VB$Local_DesiredElementName = DesiredElementName;
		stateMachine.$State = -1;
		stateMachine.$Builder = AsyncVoidMethodBuilder.Create();
		stateMachine.$Builder.Start(ref stateMachine);
	}

	public bool DisplayNavigationHistoryIndex(int Index)
	{
		if (Index > -1 && Index < DBViewerNavigationHistory.Count)
		{
			DisplayInfoInDetailsPanel(DBViewerNavigationHistory[Index].DBID, DBViewerNavigationHistory[Index].ItemType);
			NavigationHistoryPosition = Index;
			RefreshNavigationHistoryButtons();
			return true;
		}
		return false;
	}

	public bool DisplayInfoInDetailsPanel(int _SelectedObjectID, string _SelectedObjectType)
	{
		string text = "";
		bool result = true;
		string text2 = "<style>\r\n                    body\r\n                        {\r\n                        background:#333333;\r\n                        color:Lightgrey;\r\n                        scrollbar-face-color: #696969;\r\n                        scrollbar-highlight-color: #696969;\r\n                        scrollbar-3dlight-color: #696969;\r\n                        scrollbar-darkshadow-color: #696969;\r\n                        scrollbar-shadow-color: #696969;\r\n                        scrollbar-arrow-color: #696969;\r\n                        scrollbar-track-color: #333333;\r\n                        }\r\n                    hr\r\n                        {\r\n                        border-color:Lightgrey; \r\n                        background-color:Lightgrey\r\n                        }\r\n                    .collapsible {\r\n                      background:#333333;\r\n                      cursor: pointer;\r\n                      outline: none;\r\n                      color: white;\r\n                    }\r\n\r\n                    </style>";
		SelectedObjectID = _SelectedObjectID;
		SelectedObjectType = _SelectedObjectType;
		string selectedObjectType = SelectedObjectType;
		if (Operators.CompareString(selectedObjectType, "Aircraft", true) == 0)
		{
			Scenario theScen = Client.CurrentScenario;
			Aircraft theAircraft = new Aircraft(ref theScen, "");
			theScen = Client.CurrentScenario;
			DBFunctions.GetAircraft(ref theScen, ref theAircraft, SelectedObjectID);
			DatabaseObjectName = theAircraft.UnitClass;
			text = DisplayAircraft(theAircraft);
		}
		else if (Operators.CompareString(selectedObjectType, "Ship", true) != 0)
		{
			if (Operators.CompareString(selectedObjectType, "Submarine", true) != 0)
			{
				if (Operators.CompareString(selectedObjectType, "Facility", true) == 0)
				{
					Scenario theScen = Client.CurrentScenario;
					Facility theFac = new Facility(ref theScen, "");
					theScen = Client.CurrentScenario;
					DBFunctions.GetFacility(ref theScen, ref theFac, SelectedObjectID);
					DatabaseObjectName = theFac.UnitClass;
					text = DisplayFacility(theFac);
				}
				else if (Operators.CompareString(selectedObjectType, "Ground Unit", true) != 0 && Operators.CompareString(selectedObjectType, "GroundUnit", true) != 0)
				{
					if (Operators.CompareString(selectedObjectType, "Satellite", true) == 0)
					{
						Scenario theScen = Client.CurrentScenario;
						Satellite theSatellite = new Satellite(ref theScen);
						theScen = Client.CurrentScenario;
						DBFunctions.GetSatellite(ref theScen, ref theSatellite, SelectedObjectID);
						DatabaseObjectName = theSatellite.UnitClass;
						text = DisplaySatellite(theSatellite);
					}
					else if (Operators.CompareString(selectedObjectType, "Weapon", true) != 0)
					{
						if (Operators.CompareString(selectedObjectType, "Sensor", true) == 0)
						{
							text = DisplaySensor(SelectedObjectID);
						}
						else
						{
							result = false;
						}
					}
					else
					{
						Weapon weapon = Client.CurrentScenario.Cache_GetWeapon(SelectedObjectID);
						DatabaseObjectName = weapon.UnitClass;
						text = DisplayWeapon(weapon);
					}
				}
				else
				{
					Scenario theScen = Client.CurrentScenario;
					Vehicle theVehicle = new Vehicle(ref theScen, "");
					theScen = Client.CurrentScenario;
					DBFunctions.GetVehicle(ref theScen, ref theVehicle, SelectedObjectID);
					DatabaseObjectName = theVehicle.UnitClass;
					text = DisplayGroundUnit(theVehicle);
				}
			}
			else
			{
				Scenario theScen = Client.CurrentScenario;
				Submarine theSub = new Submarine(ref theScen, "");
				theScen = Client.CurrentScenario;
				DBFunctions.GetSubmarine(ref theScen, ref theSub, SelectedObjectID);
				DatabaseObjectName = theSub.UnitClass;
				text = DisplaySubmarine(theSub);
			}
		}
		else
		{
			Scenario theScen = Client.CurrentScenario;
			Ship theShip = new Ship(ref theScen, "");
			theScen = Client.CurrentScenario;
			DBFunctions.GetShip(ref theScen, ref theShip, SelectedObjectID);
			DatabaseObjectName = theShip.UnitClass;
			text = DisplayShip(theShip);
		}
		text = text2 + "<FONT face=Calibri>" + text + "<FONT>";
		text += "<script>var coll = document.getElementsByClassName('collapsible');var i;for (i = 0; i < coll.length; i++) {coll[i].addEventListener('click', function() {    this.classList.toggle('active');    var content = this.nextElementSibling;    if (content.style.display === 'block') {      content.style.display = 'none'; var text = this.textContent; this.textContent = text.replace('-','+');   } else {      content.style.display = 'block'; this.textContent = this.textContent.replace('+','-');   }  });}</script>";
		Module1.RenderCustomHTML(WebBrowser1, "", text);
		string_0 = text;
		return result;
	}

	public void RefreshNavigationHistoryButtons()
	{
		DBIDGOTO.WatermarkText = "Enter Database ID for this " + ((ComboBox)CB_ObjectType).Text + " ...";
		if (DBViewerNavigationHistory.Count == 0)
		{
			PreviousButton.Enabled = false;
			NextButton.Enabled = false;
		}
		if (NavigationHistoryPosition - 1 > -1 && NavigationHistoryPosition - 1 < DBViewerNavigationHistory.Count)
		{
			PreviousButton.Enabled = true;
		}
		else
		{
			PreviousButton.Enabled = false;
		}
		if (NavigationHistoryPosition + 1 > -1 && NavigationHistoryPosition + 1 < DBViewerNavigationHistory.Count)
		{
			NextButton.Enabled = true;
		}
		else
		{
			NextButton.Enabled = false;
		}
	}

	public void DisplaySelection(bool ApplyKeywordFilter, bool RetainPlatform = false)
	{
		if (string.IsNullOrEmpty(SelectedObjectType) || SelectedObjectID == 0)
		{
			return;
		}
		bool flag;
		if (flag = !SelectedObjectType.Equals(RuntimeHelpers.GetObjectValue(((ComboBox)CB_ObjectType).SelectedItem)))
		{
			((ComboBox)CB_ObjectType).SelectedItem = SelectedObjectType;
			BindCombobox_SubType(0);
		}
		if (!RetainPlatform)
		{
			((ComboBox)CB_ObjectType).SelectedItem = SelectedObjectType;
		}
		if (selectedSubType == -1)
		{
			string selectedObjectType = SelectedObjectType;
			if (Operators.CompareString(selectedObjectType, "Aircraft", true) == 0)
			{
				Scenario theScen = Client.CurrentScenario;
				selectedSubType = DBFunctions.GetAircraftType_Int(ref theScen, SelectedObjectID);
			}
			else if (Operators.CompareString(selectedObjectType, "Ship", true) == 0)
			{
				Scenario theScen = Client.CurrentScenario;
				selectedSubType = DBFunctions.GetShipType_Int(ref theScen, SelectedObjectID);
			}
			else if (Operators.CompareString(selectedObjectType, "Submarine", true) == 0)
			{
				Scenario theScen = Client.CurrentScenario;
				selectedSubType = DBFunctions.GetSubmarineType_Int(ref theScen, SelectedObjectID);
			}
			else if (Operators.CompareString(selectedObjectType, "Facility", true) == 0)
			{
				Scenario theScen = Client.CurrentScenario;
				selectedSubType = DBFunctions.GetFacilityCategory_Int(ref theScen, SelectedObjectID);
			}
			else if (Operators.CompareString(selectedObjectType, "Satellite", true) == 0)
			{
				Scenario theScen = Client.CurrentScenario;
				selectedSubType = DBFunctions.GetSatelliteType_Int(ref theScen, SelectedObjectID);
			}
			else if (Operators.CompareString(selectedObjectType, "Weapon", true) != 0)
			{
				if (Operators.CompareString(selectedObjectType, "Ground Unit", true) == 0 || Operators.CompareString(selectedObjectType, "GroundUnit", true) == 0)
				{
					Scenario theScen = Client.CurrentScenario;
					selectedSubType = DBFunctions.GetVehicleType_Int(ref theScen, SelectedObjectID);
				}
			}
			else
			{
				Scenario theScen = Client.CurrentScenario;
				selectedSubType = DBFunctions.GetWeaponType_Int(ref theScen, SelectedObjectID);
			}
		}
		else if (flag)
		{
			selectedSubType = 0;
		}
		if (ApplyKeywordFilter || !RetainPlatform)
		{
			method_3();
		}
		if (!RetainPlatform)
		{
			bool_2 = true;
			DarkListItem darkListItem = ListBox1.Items.Where([SpecialName] (DarkListItem theI) => Conversions.ToInteger(theI.Tag) == SelectedObjectID).FirstOrDefault();
			if (darkListItem != null)
			{
				ListBox1.SelectItem(ListBox1.Items.IndexOf(darkListItem));
			}
			bool_2 = false;
			ListBox1.EnsureVisible();
		}
		SelectedObjectName = ((Control)ListBox1).Text;
		if (DisplayInfoInDetailsPanel(SelectedObjectID, SelectedObjectType))
		{
			if (DBViewerNavigationHistory.Count <= 0 || DBViewerNavigationHistory[DBViewerNavigationHistory.Count - 1].DBID != SelectedObjectID)
			{
				DBViewerNavigationHistory.Add(new DBViewerNavigationHistoryItem(SelectedObjectID, SelectedObjectType));
				NavigationHistoryPosition = DBViewerNavigationHistory.Count - 1;
			}
		}
		else
		{
			string text = "<style>\r\n                    body\r\n                        {\r\n                        background:#333333;\r\n                        color:Lightgrey;\r\n                        scrollbar-face-color: #696969;\r\n                        scrollbar-highlight-color: #696969;\r\n                        scrollbar-3dlight-color: #696969;\r\n                        scrollbar-darkshadow-color: #696969;\r\n                        scrollbar-shadow-color: #696969;\r\n                        scrollbar-arrow-color: #696969;\r\n                        scrollbar-track-color: #333333;\r\n                        }\r\n                    hr\r\n                        {\r\n                        border-color:Lightgrey; \r\n                        background-color:Lightgrey\r\n                        }\r\n                    .collapsible {\r\n                      background:#333333;\r\n                      cursor: pointer;\r\n                      outline: none;\r\n                      color: white;\r\n                    }\r\n                    </style>";
			string text2 = "";
			string selectedObjectType2 = SelectedObjectType;
			if (Operators.CompareString(selectedObjectType2, "Aircraft", true) != 0)
			{
				if (Operators.CompareString(selectedObjectType2, "Ship", true) == 0)
				{
					Scenario theScen = Client.CurrentScenario;
					Ship theShip = new Ship(ref theScen, "");
					theScen = Client.CurrentScenario;
					DBFunctions.GetShip(ref theScen, ref theShip, SelectedObjectID);
					DatabaseObjectName = theShip.UnitClass;
					text2 = DisplayShip(theShip);
				}
				else if (Operators.CompareString(selectedObjectType2, "Submarine", true) != 0)
				{
					if (Operators.CompareString(selectedObjectType2, "Facility", true) == 0)
					{
						Scenario theScen = Client.CurrentScenario;
						Facility theFac = new Facility(ref theScen, "");
						theScen = Client.CurrentScenario;
						DBFunctions.GetFacility(ref theScen, ref theFac, SelectedObjectID);
						DatabaseObjectName = theFac.UnitClass;
						text2 = DisplayFacility(theFac);
					}
					else if (Operators.CompareString(selectedObjectType2, "Satellite", true) != 0)
					{
						if (Operators.CompareString(selectedObjectType2, "Weapon", true) == 0)
						{
							Weapon weapon = Client.CurrentScenario.Cache_GetWeapon(SelectedObjectID);
							DatabaseObjectName = weapon.UnitClass;
							text2 = DisplayWeapon(weapon);
						}
						else if (Operators.CompareString(selectedObjectType2, "Ground Unit", true) != 0 && Operators.CompareString(selectedObjectType2, "GroundUnit", true) != 0)
						{
							if (Operators.CompareString(selectedObjectType2, "Sensor", true) == 0)
							{
								text2 = DisplaySensor(SelectedObjectID);
							}
						}
						else
						{
							Scenario theScen = Client.CurrentScenario;
							Vehicle theVehicle = new Vehicle(ref theScen, "");
							theScen = Client.CurrentScenario;
							DBFunctions.GetVehicle(ref theScen, ref theVehicle, SelectedObjectID);
							DatabaseObjectName = theVehicle.UnitClass;
							text2 = DisplayGroundUnit(theVehicle);
						}
					}
					else
					{
						Scenario theScen = Client.CurrentScenario;
						Satellite theSatellite = new Satellite(ref theScen);
						theScen = Client.CurrentScenario;
						DBFunctions.GetSatellite(ref theScen, ref theSatellite, SelectedObjectID);
						DatabaseObjectName = theSatellite.UnitClass;
						text2 = DisplaySatellite(theSatellite);
					}
				}
				else
				{
					Scenario theScen = Client.CurrentScenario;
					Submarine theSub = new Submarine(ref theScen, "");
					theScen = Client.CurrentScenario;
					DBFunctions.GetSubmarine(ref theScen, ref theSub, SelectedObjectID);
					DatabaseObjectName = theSub.UnitClass;
					text2 = DisplaySubmarine(theSub);
				}
			}
			else
			{
				Scenario theScen = Client.CurrentScenario;
				Aircraft theAircraft = new Aircraft(ref theScen, "");
				theScen = Client.CurrentScenario;
				DBFunctions.GetAircraft(ref theScen, ref theAircraft, SelectedObjectID);
				DatabaseObjectName = theAircraft.UnitClass;
				text2 = DisplayAircraft(theAircraft);
			}
			text2 = text + "<FONT face=Calibri>" + text2 + "<FONT>";
			text2 += "<script>var coll = document.getElementsByClassName('collapsible');var i;for (i = 0; i < coll.length; i++) {coll[i].addEventListener('click', function() {    this.classList.toggle('active');    var content = this.nextElementSibling;    if (content.style.display === 'block') {      content.style.display = 'none'; var text = this.textContent; this.textContent = text.replace('-','+');   } else {      content.style.display = 'block'; this.textContent = this.textContent.replace('+','-');   }  });}</script>";
			Module1.RenderCustomHTML(WebBrowser1, "", text2);
			string_0 = text2;
		}
		RefreshNavigationHistoryButtons();
		if ((ListBox1.SelectedIndices != null) & (ListBox1.SelectedIndices.Count > 0))
		{
			int_0 = ListBox1.SelectedIndices[0] * ListBox1.ItemHeight;
		}
	}

	private void InternalDBViewer_Load_1(object sender, EventArgs e)
	{
		((ComboBox)CB_ObjectType).SelectedIndex = 0;
		BindCombobox_SubType(0);
		string text = ColorTranslator.ToHtml(((Form)this).BackColor);
		Module1.RenderCustomHTML(WebBrowser1, "<html><body style='background-color:" + text + "'></body></html>");
	}

	private void method_2(object object_0)
	{
		if (Operators.CompareString(TB_Class.Text, "", true) != 0)
		{
			method_3();
		}
	}

	private void method_3()
	{
		int selectedIndex = ((ComboBox)CB_ObjectType).SelectedIndex;
		DataView dataView;
		ObservableCollection<DarkListItem> observableCollection;
		switch (selectedIndex)
		{
		case 1:
			dataTable_0 = Client.CurrentScenario.Cache_Ships_DT;
			goto IL_00dc;
		case 2:
			dataTable_0 = Client.CurrentScenario.Cache_Subs_DT;
			goto IL_00dc;
		case 3:
			dataTable_0 = Client.CurrentScenario.Cache_Facilities_DT;
			goto IL_00dc;
		case 4:
			dataTable_0 = Client.CurrentScenario.Cache_GroundUnits_DT;
			goto IL_00dc;
		case 5:
			dataTable_0 = Client.CurrentScenario.Cache_Satellites_DT;
			goto IL_00dc;
		case 6:
			dataTable_0 = Client.CurrentScenario.Cache_Weapons_DT;
			goto IL_00dc;
		default:
			if (selectedIndex == int_1)
			{
				SQLiteConnection sqliteConnection_ = Client.CurrentScenario.DBConnection;
				dataTable_0 = DBFunctions.GetAllSensors(ref sqliteConnection_);
				goto IL_00dc;
			}
			break;
		case 0:
			{
				dataTable_0 = Client.CurrentScenario.Cache_Aircraft_DT;
				goto IL_00dc;
			}
			IL_00dc:
			if (dataTable_0.Rows.Count == 0)
			{
				break;
			}
			dataView = new DataView(dataTable_0);
			dataView.Sort = "LongName ASC";
			if (Operators.CompareString(TB_Class.Text, "", true) != 0 || ((ComboBox)CB_Country).SelectedIndex != 0 || ((ComboBox)CB_Hypothetical).SelectedIndex != 0 || ((ComboBox)CB_SubType).SelectedIndex != 0)
			{
				string text = "1=1 ";
				if (Operators.CompareString(TB_Class.Text, "", true) != 0)
				{
					string text2 = TB_Class.Text.Replace("'", "''");
					text2 = text2.Replace("%", "");
					text2 = text2.Replace("*", "");
					text2 = text2.Replace("?", "");
					TB_Class.Text = TB_Class.Text.Replace("%", "");
					TB_Class.Text = TB_Class.Text.Replace("*", "");
					TB_Class.Text = TB_Class.Text.Replace("?", "");
					text = text + " AND LongName LIKE '%" + text2 + "%' ";
				}
				if (((Control)CB_Country).Enabled && dataTable_0.Columns.Contains("OperatorCountry") && ((ComboBox)CB_Country).SelectedIndex > 0)
				{
					text = text + " AND OperatorCountry=" + ((ListControl)CB_Country).SelectedValue.ToString();
				}
				if (dataTable_0.Columns.Contains("Hypothetical"))
				{
					if (((ComboBox)CB_Hypothetical).SelectedIndex == 1)
					{
						text += " AND Hypothetical=FALSE";
					}
					else if (((ComboBox)CB_Hypothetical).SelectedIndex == 2)
					{
						text += " AND Hypothetical=TRUE";
					}
				}
				if (((ComboBox)CB_SubType).SelectedIndex > 0)
				{
					text = ((((ComboBox)CB_ObjectType).SelectedIndex == 3) ? (text + " AND category=" + ((ListControl)CB_SubType).SelectedValue.ToString()) : ((((ComboBox)CB_ObjectType).SelectedIndex != 4) ? (text + " AND type=" + ((ListControl)CB_SubType).SelectedValue.ToString()) : (text + " AND category=" + ((ListControl)CB_SubType).SelectedValue.ToString())));
				}
				text = text.Replace("[", "[[");
				text = text.Replace("]", "]]");
				text = text.Replace("[[", "[[]");
				text = text.Replace("]]", "[]]");
				dataView.RowFilter = text;
			}
			bool_2 = true;
			ListBox1.Items.Clear();
			observableCollection = new ObservableCollection<DarkListItem>();
			foreach (DataRowView item in dataView)
			{
				DataRow row = item.Row;
				string text3 = row["LongName"].ToString().Replace("\r\n", "^");
				DarkListItem darkListItem = new DarkListItem(text3);
				darkListItem.Tag = RuntimeHelpers.GetObjectValue(row["ID"]);
				observableCollection.Add(darkListItem);
			}
			ListBox1.Items = observableCollection;
			ListBox1.UpdateContentSize();
			bool_2 = false;
			int_0 = -1;
			break;
		}
	}

	private void method_4(object sender, EventArgs e)
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		if (((ComboBox)CB_ObjectType).SelectedIndex == 4 && Client.CurrentScenario.Cache_GroundUnits_DT.Rows.Count == 0)
		{
			DarkMessageBox.ShowWarning("Ground units are not present in this database", "Internal Database Viewer");
			((ComboBox)CB_ObjectType).SelectedIndex = 0;
		}
		SelectedObjectType = Conversions.ToString(((ComboBox)CB_ObjectType).SelectedItem);
		selectedSubType = 0;
		TB_Class.Clear();
		if (Operators.CompareString(SelectedObjectType, "Weapon", true) != 0 && Operators.CompareString(SelectedObjectType, "Sensor", true) != 0)
		{
			((Control)CB_Country).Enabled = true;
			((Control)CB_Country).Visible = true;
		}
		else
		{
			((Control)CB_Country).Enabled = false;
			((Control)CB_Country).Visible = false;
		}
		BindCombobox_SubType((short)selectedSubType);
		method_3();
	}

	private void method_5(object sender, EventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		((HandledMouseEventArgs)e).Handled = true;
	}

	private void method_6(object sender, EventArgs e)
	{
		method_3();
	}

	private void method_7(object sender, EventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		((HandledMouseEventArgs)e).Handled = true;
	}

	private void InternalDBViewer_Shown(object sender, EventArgs e)
	{
		GlobalSingleton.GetInstance().method_0(this);
		((Control)this).SuspendLayout();
		if (string.IsNullOrEmpty(SelectedObjectType))
		{
			SelectedObjectType = "Aircraft";
		}
		if (!((ComboBox)CB_ObjectType).Items.Contains((object)"Sensor"))
		{
			int_1 = ((ComboBox)CB_ObjectType).Items.Add((object)"Sensor");
		}
		if (Operators.CompareString(SelectedObjectType, "Weapon", true) != 0 && Operators.CompareString(SelectedObjectType, "Sensor", true) != 0)
		{
			((Control)CB_Country).Enabled = true;
			((Control)CB_Country).Visible = true;
		}
		else
		{
			((Control)CB_Country).Enabled = false;
			((Control)CB_Country).Visible = false;
		}
		DataTable cache_OperatorCountries_DT = Client.CurrentScenario.Cache_OperatorCountries_DT;
		((ComboBox)CB_Country).DataSource = cache_OperatorCountries_DT;
		((ListControl)CB_Country).DisplayMember = "Description";
		((ListControl)CB_Country).ValueMember = "ID";
		((ComboBox)CB_Country).SelectedIndex = 0;
		((ComboBox)CB_Hypothetical).Items.Clear();
		((ComboBox)CB_Hypothetical).Items.AddRange(new object[3] { "Show all platforms, both real-life and hypothetical", "Show real-life platforms only", "Show hypothetical platforms only" });
		((ComboBox)CB_Hypothetical).SelectedIndex = 0;
		BindCombobox_SubType(0);
		if (SelectedObjectID > 0)
		{
			bool_5 = true;
			DisplaySelection(ApplyKeywordFilter: true);
		}
		else
		{
			HighlightTarget = null;
			method_3();
		}
		((Control)WebBrowser1).Focus();
		((Control)this).ResumeLayout();
	}

	private void method_8(object sender, CoreWebView2NavigationCompletedEventArgs e)
	{
		if (bool_5)
		{
			bool_5 = false;
			if (!string.IsNullOrEmpty(SelectedObjectType))
			{
				DisplayInfoInDetailsPanel(SelectedObjectID, SelectedObjectType);
			}
		}
		ScrollToSpecificElement(HighlightTarget);
	}

	public string DisplayAircraft(Aircraft AC)
	{
		StreamReader streamReader = new StreamReader(Path.Combine(GameGeneral.DBFolderPath, "Templates\\Platform.html"));
		string text;
		using (streamReader)
		{
			text = streamReader.ReadToEnd();
		}
		string text2 = "";
		int theType;
		if (AC.Hypothetical)
		{
			text2 = " -- HYPOTHETICAL UNIT";
			theType = 1;
		}
		else
		{
			theType = 1;
		}
		(string, string, string) operatorCountryAndYears = DBFunctions.GetOperatorCountryAndYears((GlobalVariables.ActiveUnitType)theType, AC.DBID, Client.CurrentScenario);
		text = text.Replace("<%PlatformName%>", "#" + Conversions.ToString(SelectedObjectID) + " - " + AC.UnitClass + " (" + operatorCountryAndYears.Item1 + " - " + operatorCountryAndYears.Item2 + ")" + text2);
		text = text.Replace("<%Image%>", DisplayImage(AC));
		text = text.Replace("<%Description%>", DisplayDescription(AC));
		text = text.Replace("<%General%>", Aircraft_General(AC));
		text = text.Replace("<%Sensors%>", DisplaySensors(AC));
		text = text.Replace("<%MineCountermeasures%>", "");
		text = text.Replace("<%Mounts%>", DisplayMounts(AC));
		text = text.Replace("<%Stores%>", DisplayStores(AC));
		text = text.Replace("<%Loadouts%>", DisplayLoadouts(AC));
		text = text.Replace("<%Magazines%>", "");
		text = text.Replace("<%Comms%>", DisplayComms(AC));
		text = text.Replace("<%AirFacilities%>", "");
		text = text.Replace("<%DockingFacilities%>", "");
		text = text.Replace("<%Signatures%>", DisplaySignatures(AC));
		text = text.Replace("<%Flags%>", DisplayFlags(AC));
		text = text.Replace("<%Warheads%>", "");
		text = text.Replace("<%ValidTargets%>", "");
		text = text.Replace("<%WRA%>", "");
		text = text.Replace("<%Propulsion%>", DisplayPropulsion(AC));
		return text.Replace("<%Fuel%>", DisplayFuel(AC));
	}

	public string DisplayShip(Ship theShip)
	{
		StreamReader streamReader = new StreamReader(Path.Combine(GameGeneral.DBFolderPath, "Templates\\Platform.html"));
		string text;
		using (streamReader)
		{
			text = streamReader.ReadToEnd();
		}
		string text2 = "";
		int theType;
		if (!theShip.Hypothetical)
		{
			theType = 2;
		}
		else
		{
			text2 = " -- HYPOTHETICAL UNIT";
			theType = 2;
		}
		(string, string, string) operatorCountryAndYears = DBFunctions.GetOperatorCountryAndYears((GlobalVariables.ActiveUnitType)theType, theShip.DBID, Client.CurrentScenario);
		text = text.Replace("<%PlatformName%>", "#" + Conversions.ToString(SelectedObjectID) + " - " + theShip.UnitClass + " (" + operatorCountryAndYears.Item1 + " - " + operatorCountryAndYears.Item2 + ")" + text2);
		text = text.Replace("<%Image%>", DisplayImage(theShip));
		text = text.Replace("<%Description%>", DisplayDescription(theShip));
		text = text.Replace("<%General%>", Ship_General(theShip));
		text = text.Replace("<%Sensors%>", DisplaySensors(theShip));
		text = text.Replace("<%MineCountermeasures%>", DisplayMineCountermeasuresGear(theShip));
		text = text.Replace("<%Mounts%>", DisplayMounts(theShip));
		text = text.Replace("<%Stores%>", "");
		text = text.Replace("<%Loadouts%>", "");
		text = text.Replace("<%Magazines%>", DisplayMags(theShip));
		text = text.Replace("<%Comms%>", DisplayComms(theShip));
		text = text.Replace("<%AirFacilities%>", DisplayAirFacilities(theShip));
		text = text.Replace("<%DockingFacilities%>", DisplayDockingFacilities(theShip));
		text = text.Replace("<%Signatures%>", DisplaySignatures(theShip));
		text = text.Replace("<%Flags%>", DisplayFlags(theShip));
		text = text.Replace("<%Warheads%>", "");
		text = text.Replace("<%ValidTargets%>", "");
		text = text.Replace("<%WRA%>", "");
		text = text.Replace("<%Propulsion%>", DisplayPropulsion(theShip));
		return text.Replace("<%Fuel%>", DisplayFuel(theShip));
	}

	public string DisplaySubmarine(Submarine theSub)
	{
		StreamReader streamReader = new StreamReader(Path.Combine(GameGeneral.DBFolderPath, "Templates\\Platform.html"));
		string text;
		using (streamReader)
		{
			text = streamReader.ReadToEnd();
		}
		string text2 = "";
		int theType;
		if (!theSub.Hypothetical)
		{
			theType = 3;
		}
		else
		{
			text2 = " -- HYPOTHETICAL UNIT";
			theType = 3;
		}
		(string, string, string) operatorCountryAndYears = DBFunctions.GetOperatorCountryAndYears((GlobalVariables.ActiveUnitType)theType, theSub.DBID, Client.CurrentScenario);
		text = text.Replace("<%PlatformName%>", "#" + Conversions.ToString(SelectedObjectID) + " - " + theSub.UnitClass + " (" + operatorCountryAndYears.Item1 + " - " + operatorCountryAndYears.Item2 + ")" + text2);
		text = text.Replace("<%Image%>", DisplayImage(theSub));
		text = text.Replace("<%Description%>", DisplayDescription(theSub));
		text = text.Replace("<%General%>", Submarine_General(theSub));
		text = text.Replace("<%Sensors%>", DisplaySensors(theSub));
		text = text.Replace("<%MineCountermeasures%>", DisplayMineCountermeasuresGear(theSub));
		text = text.Replace("<%Mounts%>", DisplayMounts(theSub));
		text = text.Replace("<%Stores%>", "");
		text = text.Replace("<%Loadouts%>", "");
		text = text.Replace("<%Magazines%>", DisplayMags(theSub));
		text = text.Replace("<%Comms%>", DisplayComms(theSub));
		text = text.Replace("<%AirFacilities%>", "");
		text = text.Replace("<%DockingFacilities%>", DisplayDockingFacilities(theSub));
		text = text.Replace("<%Signatures%>", DisplaySignatures(theSub));
		text = text.Replace("<%Flags%>", DisplayFlags(theSub));
		text = text.Replace("<%Warheads%>", "");
		text = text.Replace("<%ValidTargets%>", "");
		text = text.Replace("<%WRA%>", "");
		text = text.Replace("<%Propulsion%>", DisplayPropulsion(theSub));
		return text.Replace("<%Fuel%>", DisplayFuel(theSub));
	}

	public string DisplayFacility(Facility theFac)
	{
		StreamReader streamReader = new StreamReader(Path.Combine(GameGeneral.DBFolderPath, "Templates\\Platform.html"));
		string text;
		using (streamReader)
		{
			text = streamReader.ReadToEnd();
		}
		string text2 = "";
		int theType;
		if (!theFac.Hypothetical)
		{
			theType = 4;
		}
		else
		{
			text2 = " -- HYPOTHETICAL UNIT";
			theType = 4;
		}
		(string, string, string) operatorCountryAndYears = DBFunctions.GetOperatorCountryAndYears((GlobalVariables.ActiveUnitType)theType, theFac.DBID, Client.CurrentScenario);
		text = text.Replace("<%PlatformName%>", "#" + Conversions.ToString(SelectedObjectID) + " - " + theFac.UnitClass + " (" + operatorCountryAndYears.Item1 + " - " + operatorCountryAndYears.Item2 + ")" + text2);
		text = text.Replace("<%Image%>", DisplayImage(theFac));
		text = text.Replace("<%Description%>", DisplayDescription(theFac));
		text = text.Replace("<%General%>", Facility_General(theFac));
		text = text.Replace("<%Sensors%>", DisplaySensors(theFac));
		text = text.Replace("<%MineCountermeasures%>", "");
		text = text.Replace("<%Mounts%>", DisplayMounts(theFac));
		text = text.Replace("<%Stores%>", "");
		text = text.Replace("<%Loadouts%>", "");
		text = text.Replace("<%Magazines%>", DisplayMags(theFac));
		text = text.Replace("<%Comms%>", DisplayComms(theFac));
		text = text.Replace("<%AirFacilities%>", DisplayAirFacilities(theFac));
		text = text.Replace("<%DockingFacilities%>", DisplayDockingFacilities(theFac));
		text = text.Replace("<%Signatures%>", DisplaySignatures(theFac));
		text = text.Replace("<%Flags%>", "");
		text = text.Replace("<%Warheads%>", "");
		text = text.Replace("<%ValidTargets%>", "");
		text = text.Replace("<%WRA%>", "");
		text = text.Replace("<%Propulsion%>", DisplayPropulsion(theFac));
		return text.Replace("<%Fuel%>", DisplayFuel(theFac));
	}

	public string DisplayGroundUnit(IMobileGroundUnit theUnit)
	{
		StreamReader streamReader = new StreamReader(Path.Combine(GameGeneral.DBFolderPath, "Templates\\Platform.html"));
		string text;
		using (streamReader)
		{
			text = streamReader.ReadToEnd();
		}
		string text2 = "";
		int theType;
		if (!((Platform)theUnit).Hypothetical)
		{
			theType = 8;
		}
		else
		{
			text2 = " -- HYPOTHETICAL UNIT";
			theType = 8;
		}
		(string, string, string) operatorCountryAndYears = DBFunctions.GetOperatorCountryAndYears((GlobalVariables.ActiveUnitType)theType, ((Platform)theUnit).DBID, Client.CurrentScenario);
		text = text.Replace("<%PlatformName%>", "#" + Conversions.ToString(SelectedObjectID) + " - " + ((Platform)theUnit).UnitClass + " (" + operatorCountryAndYears.Item1 + " - " + operatorCountryAndYears.Item2 + ")" + text2);
		text = text.Replace("<%Image%>", DisplayImage((Platform)theUnit));
		text = text.Replace("<%Description%>", DisplayDescription((Platform)theUnit));
		text = text.Replace("<%General%>", GroundUnit_General(theUnit));
		text = text.Replace("<%Sensors%>", DisplaySensors((Platform)theUnit));
		text = text.Replace("<%MineCountermeasures%>", "");
		text = text.Replace("<%Mounts%>", DisplayMounts((Platform)theUnit));
		text = text.Replace("<%Stores%>", "");
		text = text.Replace("<%Loadouts%>", "");
		text = text.Replace("<%Magazines%>", DisplayMags((Platform)theUnit));
		text = text.Replace("<%Comms%>", DisplayComms((Platform)theUnit));
		text = text.Replace("<%AirFacilities%>", DisplayAirFacilities((Platform)theUnit));
		text = text.Replace("<%DockingFacilities%>", DisplayDockingFacilities((Platform)theUnit));
		text = text.Replace("<%Signatures%>", DisplaySignatures((Platform)theUnit));
		text = text.Replace("<%Flags%>", "");
		text = text.Replace("<%Warheads%>", "");
		text = text.Replace("<%ValidTargets%>", "");
		text = text.Replace("<%WRA%>", "");
		text = text.Replace("<%Propulsion%>", DisplayPropulsion((ActiveUnit)theUnit));
		return text.Replace("<%Fuel%>", DisplayFuel((ActiveUnit)theUnit));
	}

	public string DisplaySatellite(Satellite theSat)
	{
		StreamReader streamReader = new StreamReader(Path.Combine(GameGeneral.DBFolderPath, "Templates\\Platform.html"));
		string text;
		using (streamReader)
		{
			text = streamReader.ReadToEnd();
		}
		string text2 = "";
		int theType;
		if (theSat.Hypothetical)
		{
			text2 = " -- HYPOTHETICAL UNIT";
			theType = 7;
		}
		else
		{
			theType = 7;
		}
		(string, string, string) operatorCountryAndYears = DBFunctions.GetOperatorCountryAndYears((GlobalVariables.ActiveUnitType)theType, theSat.DBID, Client.CurrentScenario);
		text = text.Replace("<%PlatformName%>", "#" + Conversions.ToString(SelectedObjectID) + " - " + theSat.UnitClass + " (" + operatorCountryAndYears.Item1 + " - " + operatorCountryAndYears.Item2 + ")" + text2);
		text = text.Replace("<%Image%>", DisplayImage(theSat));
		text = text.Replace("<%Description%>", DisplayDescription(theSat));
		text = text.Replace("<%General%>", Satellite_General(theSat));
		text = text.Replace("<%Sensors%>", DisplaySensors(theSat));
		text = text.Replace("<%MineCountermeasures%>", "");
		text = text.Replace("<%Mounts%>", DisplayMounts(theSat));
		text = text.Replace("<%Stores%>", "");
		text = text.Replace("<%Loadouts%>", "");
		text = text.Replace("<%Magazines%>", "");
		text = text.Replace("<%Comms%>", DisplayComms(theSat));
		text = text.Replace("<%AirFacilities%>", "");
		text = text.Replace("<%DockingFacilities%>", "");
		text = text.Replace("<%Signatures%>", DisplaySignatures(theSat));
		text = text.Replace("<%Flags%>", DisplayFlags(theSat));
		text = text.Replace("<%Warheads%>", "");
		text = text.Replace("<%ValidTargets%>", "");
		text = text.Replace("<%WRA%>", "");
		text = text.Replace("<%Propulsion%>", DisplayOrbitDetails(theSat));
		return text.Replace("<%Fuel%>", "");
	}

	public string Aircraft_General(Aircraft AC)
	{
		string text = "<div style='border-bottom: black 1px solid'><span style='font-family: Arial; color: dodgerblue;'><strong>GENERAL DATA</strong></span></div>";
		StreamReader streamReader = new StreamReader(Path.Combine(GameGeneral.DBFolderPath, "Templates\\Aircraft.html"));
		using (streamReader)
		{
			text += streamReader.ReadToEnd();
		}
		text += "<br/>";
		Contact theTarget = Contact.Instantiate(AC);
		string text2 = "";
		if (theTarget.ActualUnit != null)
		{
			theTarget.IDStatusBypassIdentification = Contact_Base.IdentificationStatus.KnownClass;
			GlobalVariables.BooleanObject EmitterClassificable = null;
			text2 = " (WRA: " + Doctrine.WRA_TargetType_String(theTarget, Contact.WRA_DetermineTargetType(ref theTarget, null, ref EmitterClassificable), EmitterClassificable.ToBoolean()) + ")";
		}
		text = text.Replace("<%Category%>", Misc.Description(AC.Category, Client.CurrentScenario.DBConnection));
		text = text.Replace("<%Type%>", Misc.Description(AC.Type, Client.CurrentScenario.DBConnection) + text2);
		text = text.Replace("<%Length%>", Conversions.ToString(AC.Length));
		text = text.Replace("<%ClimbRate%>", $"{AC.Kinematics.get_ClimbRate_Nominal(LimitByTrueAirspeed: false):0.0}");
		text = text.Replace("<%InstantaneousClimbRate%>", $"{AC.Kinematics.get_ClimbRate_Nominal(LimitByTrueAirspeed: false) * 3f:0.0}");
		text = text.Replace("<%ClimbRateFeetPrMin%>", Conversions.ToString(Conversions.ToInteger($"{(double)AC.Kinematics.get_ClimbRate_Nominal(LimitByTrueAirspeed: false) / 0.3048 * 60.0 / 10.0:0.0}") * 10));
		text = text.Replace("<%InstantaneousClimbRateFeetPrMin%>", Conversions.ToString(Conversions.ToInteger($"{(double)(AC.Kinematics.get_ClimbRate_Nominal(LimitByTrueAirspeed: false) * 3f) / 0.3048 * 60.0 / 10.0:0.0}") * 10));
		text = text.Replace("<%Span%>", Conversions.ToString(AC.Span));
		text = text.Replace("<%Height%>", Conversions.ToString(AC.Height));
		text = text.Replace("<%Agility%>", Conversions.ToString(AC.Agility_Nominal));
		text = text.Replace("<%EmptyWeight%>", Conversions.ToString(AC.EmptyWeight));
		text = text.Replace("<%MaxWeight%>", Conversions.ToString(AC.MaxWeight));
		text = text.Replace("<%MaxPayloadWeight%>", Conversions.ToString(AC.MaxPayloadWeight));
		string newValue = ((AC.Crew <= 0) ? ("0 (Autonomy Level: " + AC.AutonomyLevel.ToString() + ")") : Conversions.ToString(AC.Crew));
		text = text.Replace("<%Crew%>", newValue);
		text = text.Replace("<%Visibility%>", method_9(AC));
		text = text.Replace("<%Armor%>", method_10(AC));
		text = text.Replace("<%RunwayLengthNeeded%>", Misc.Description(AC.RunwayLengthNeeded, Client.CurrentScenario.DBConnection));
		text = text.Replace("<%PhysicalSize%>", Misc.Description(AC.Size, Client.CurrentScenario.DBConnection));
		text = text.Replace("<%CockpitGeneration%>", CombatSystem_Description(AC.UnitType, AC.CockpitGen));
		text = text.Replace("<%OODA%>", OODA_Description(AC.UnitType, AC.DBID, AC.CockpitGen));
		return text.Replace("<%DamagePoints%>", Conversions.ToString(AC.get_DamagePts(ScenEditAction: false, (Weapon)null)));
	}

	public string GroundUnit_General(IMobileGroundUnit theUnit)
	{
		string text = "<div style='border-bottom: black 1px solid'><span style='font-family: Arial; color: dodgerblue;'><strong>GENERAL DATA</strong></span></div>";
		StreamReader streamReader = new StreamReader(Path.Combine(GameGeneral.DBFolderPath, "Templates\\GroundUnit.html"));
		using (streamReader)
		{
			text += streamReader.ReadToEnd();
		}
		text += "<br/>";
		Contact theTarget = Contact.Instantiate((ActiveUnit)theUnit);
		string text2 = "";
		if (theTarget.ActualUnit != null)
		{
			theTarget.IDStatusBypassIdentification = Contact_Base.IdentificationStatus.KnownClass;
			GlobalVariables.BooleanObject EmitterClassificable = null;
			text2 = " (WRA: " + Doctrine.WRA_TargetType_String(theTarget, Contact.WRA_DetermineTargetType(ref theTarget, null, ref EmitterClassificable), EmitterClassificable.ToBoolean()) + ")";
		}
		text = text.Replace("<%Category%>", Misc.ToEnglishString(theUnit.MobileUnitCategory) + text2);
		text = text.Replace("<%DamagePts%>", Conversions.ToString(((ActiveUnit)(Platform)theUnit).get_DamagePts(ScenEditAction: false, (Weapon)null)));
		if (((Platform)theUnit).IsVehicle)
		{
			Vehicle vehicle = (Vehicle)theUnit;
			text = text.Replace("<%TroopCapacity%>", CargoHostHelper.TroopCapacityString(vehicle));
			text = text.Replace("<%CargoCapacity%>", CargoHostHelper.CargoCapacityString(vehicle));
			text = text.Replace("<%Length%>", Conversions.ToString(vehicle.Length));
			text = text.Replace("<%Width%>", Conversions.ToString(vehicle.Width));
			text = text.Replace("<%Area%>", Conversions.ToString(vehicle.Area));
			string newValue = ((vehicle.Crew <= 0) ? ("0 (Autonomy Level: " + vehicle.AutonomyLevel.ToString() + ")") : Conversions.ToString(vehicle.Crew));
			text = text.Replace("<%Crew%>", newValue);
			text = text.Replace("<%Armor_General%>", Misc.Description(vehicle.Armor_General, Client.CurrentScenario.DBConnection));
			text = text.Replace("<%MastHeight%>", Conversions.ToString(vehicle.MastHeight));
			text = text.Replace("<%CombatSystem%>", CombatSystem_Description(vehicle.UnitType, vehicle.CombatSystemGen));
			text = text.Replace("<%OODA%>", OODA_Description(((Platform)theUnit).UnitType, ((Platform)theUnit).DBID, 0));
			text = text.Replace("<%MissileDefence%>", Conversions.ToString(vehicle.MissileDefense) + " Harpoon / SLAM / Maverick equivalents");
			text = text.Replace("<%FireOnTheMove%>", vehicle.CanFireOnTheMove ? "Unit Can Fire on the Move" : "Unit Must Halt to Fire");
		}
		return text;
	}

	private string method_9(Aircraft aircraft_0)
	{
		if (Client.CurrentScenario.FeatureCompatibility.CockpitVisibility)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Forward: ").Append(Misc.ToEnglishString(aircraft_0.VisibilityForward)).Append("<br>");
			stringBuilder.Append("Sideways: ").Append(Misc.ToEnglishString(aircraft_0.VisibilitySideways)).Append("<br>");
			stringBuilder.Append("Aft: ").Append(Misc.ToEnglishString(aircraft_0.VisibilityAft));
			return stringBuilder.ToString();
		}
		return "Not supported by this database.";
	}

	private string method_10(Aircraft aircraft_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Fuselage: ").Append(Misc.Description(aircraft_0.Armor_Fuselage, Client.CurrentScenario.DBConnection)).Append("<br>");
		stringBuilder.Append("Cockpit: ").Append(Misc.Description(aircraft_0.Armor_Cockpit, Client.CurrentScenario.DBConnection)).Append("<br>");
		stringBuilder.Append("Powerplant: ").Append(Misc.Description(aircraft_0.Armor_Powerplant, Client.CurrentScenario.DBConnection));
		return stringBuilder.ToString();
	}

	public string CombatSystem_Description(GlobalVariables.ActiveUnitType UnitType, int CSGenID)
	{
		switch (UnitType)
		{
		case GlobalVariables.ActiveUnitType.Aircraft:
		{
			Scenario theScen = Client.CurrentScenario;
			(string, string, short, short, short) aircraftCockpitOODAValues = DBFunctions.GetAircraftCockpitOODAValues(ref theScen, CSGenID, CheckIfTableExists: true);
			return aircraftCockpitOODAValues.Item1 + " (ex: " + aircraftCockpitOODAValues.Item2 + ")";
		}
		case GlobalVariables.ActiveUnitType.Ship:
		{
			Scenario theScen = Client.CurrentScenario;
			(string, string, short, short, short) shipCombatSystemOODAValues = DBFunctions.GetShipCombatSystemOODAValues(ref theScen, CSGenID, CheckIfTableExists: true);
			return shipCombatSystemOODAValues.Item1 + " (ex: " + shipCombatSystemOODAValues.Item2 + ")";
		}
		case GlobalVariables.ActiveUnitType.Submarine:
		{
			Scenario theScen = Client.CurrentScenario;
			(string, string, string, short, short, short) submarineCombatSystemOODAValues = DBFunctions.GetSubmarineCombatSystemOODAValues(ref theScen, CSGenID, CheckIfTableExists: true);
			return submarineCombatSystemOODAValues.Item1 + " (ex: " + submarineCombatSystemOODAValues.Item2 + " - " + submarineCombatSystemOODAValues.Item3 + ")";
		}
		case GlobalVariables.ActiveUnitType.Facility:
		{
			Scenario theScen = Client.CurrentScenario;
			(string, string, short, short, short) facilityCombatSystemOODAValues = DBFunctions.GetFacilityCombatSystemOODAValues(ref theScen, CSGenID, CheckIfTableExists: true);
			return facilityCombatSystemOODAValues.Item1 + " (ex: " + facilityCombatSystemOODAValues.Item2 + ")";
		}
		default:
			return string.Empty;
		case GlobalVariables.ActiveUnitType.Vehicle:
		case GlobalVariables.ActiveUnitType.Personnel:
		{
			Scenario theScen = Client.CurrentScenario;
			(string, string, short, short, short) groundUnitCombatSystemOODAValues = DBFunctions.GetGroundUnitCombatSystemOODAValues(ref theScen, CSGenID, CheckIfTableExists: true);
			return groundUnitCombatSystemOODAValues.Item1 + " (ex: " + groundUnitCombatSystemOODAValues.Item2 + ")";
		}
		}
	}

	public string OODA_Description(GlobalVariables.ActiveUnitType UnitType, int UnitDBID, int CombatSystemGenID)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (CombatSystemGenID > 0)
		{
			switch (UnitType)
			{
			case GlobalVariables.ActiveUnitType.Aircraft:
			{
				Scenario theScen = Client.CurrentScenario;
				(string, string, short, short, short) aircraftCockpitOODAValues = DBFunctions.GetAircraftCockpitOODAValues(ref theScen, CombatSystemGenID, CheckIfTableExists: false);
				stringBuilder.Append("<table style='font-family:Verdana;font-size:8pt'>");
				stringBuilder.Append("<tr>");
				stringBuilder.Append("<td>Detection:</td><td>" + Conversions.ToString((int)aircraftCockpitOODAValues.Item3) + " seconds Observe, Orient, Decide, and Act (reaction time)<td>");
				stringBuilder.Append("</tr>");
				stringBuilder.Append("<tr>");
				stringBuilder.Append("<td valign=top>Targeting:</td><td>" + $"{aircraftCockpitOODAValues.Item4 * 2:0}" + " seconds (Novice Proficiency Level)<br>" + $"{(double)aircraftCockpitOODAValues.Item4 * 1.5:0}" + " seconds (Cadet)<br>" + $"{(double)aircraftCockpitOODAValues.Item4 * 1.2:0}" + " seconds (Regular)<br>" + $"{aircraftCockpitOODAValues.Item4:0}" + " seconds (Veteran)<br>" + $"{(double)aircraftCockpitOODAValues.Item4 * 0.8:0}" + " seconds (Ace)</td>");
				stringBuilder.Append("</tr>");
				stringBuilder.Append("<tr>");
				stringBuilder.Append("<td>Evasion:</td><td>" + $"{aircraftCockpitOODAValues.Item5:0}" + " seconds</td>");
				stringBuilder.Append("</tr>");
				stringBuilder.Append("</table>");
				return stringBuilder.ToString();
			}
			case GlobalVariables.ActiveUnitType.Ship:
			{
				Scenario theScen = Client.CurrentScenario;
				(string, string, short, short, short) shipCombatSystemOODAValues = DBFunctions.GetShipCombatSystemOODAValues(ref theScen, CombatSystemGenID, CheckIfTableExists: false);
				stringBuilder.Append("<table style='font-family:Verdana;font-size:8pt'>");
				stringBuilder.Append("<tr>");
				stringBuilder.Append("<td>Detection:</td><td>" + Conversions.ToString((int)shipCombatSystemOODAValues.Item3) + " seconds Observe, Orient, Decide, and Act (reaction time)<td>");
				stringBuilder.Append("</tr>");
				stringBuilder.Append("<tr>");
				stringBuilder.Append("<td valign=top>Targeting:</td><td>" + $"{shipCombatSystemOODAValues.Item4 * 2:0}" + " seconds (Novice Proficiency Level)<br>" + $"{(double)shipCombatSystemOODAValues.Item4 * 1.5:0}" + " seconds (Cadet)<br>" + $"{(double)shipCombatSystemOODAValues.Item4 * 1.2:0}" + " seconds (Regular)<br>" + $"{shipCombatSystemOODAValues.Item4:0}" + " seconds (Veteran)<br>" + $"{(double)shipCombatSystemOODAValues.Item4 * 0.8:0}" + " seconds (Ace)</td>");
				stringBuilder.Append("</tr>");
				stringBuilder.Append("<tr>");
				stringBuilder.Append("<td>Evasion:</td><td>" + $"{shipCombatSystemOODAValues.Item5:0}" + " seconds</td>");
				stringBuilder.Append("</tr>");
				stringBuilder.Append("</table>");
				return stringBuilder.ToString();
			}
			case GlobalVariables.ActiveUnitType.Submarine:
			{
				Scenario theScen = Client.CurrentScenario;
				(string, string, string, short, short, short) submarineCombatSystemOODAValues = DBFunctions.GetSubmarineCombatSystemOODAValues(ref theScen, CombatSystemGenID, CheckIfTableExists: false);
				stringBuilder.Append("<table style='font-family:Verdana;font-size:8pt'>");
				stringBuilder.Append("<tr>");
				stringBuilder.Append("<td>Detection:</td><td>" + Conversions.ToString((int)submarineCombatSystemOODAValues.Item4) + " seconds Observe, Orient, Decide, and Act (reaction time)<td>");
				stringBuilder.Append("</tr>");
				stringBuilder.Append("<tr>");
				stringBuilder.Append("<td valign=top>Targeting:</td><td>" + $"{submarineCombatSystemOODAValues.Item5 * 2:0}" + " seconds (Novice Proficiency Level)<br>" + $"{(double)submarineCombatSystemOODAValues.Item5 * 1.5:0}" + " seconds (Cadet)<br>" + $"{(double)submarineCombatSystemOODAValues.Item5 * 1.2:0}" + " seconds (Regular)<br>" + $"{submarineCombatSystemOODAValues.Item5:0}" + " seconds (Veteran)<br>" + $"{(double)submarineCombatSystemOODAValues.Item5 * 0.8:0}" + " seconds (Ace)</td>");
				stringBuilder.Append("</tr>");
				stringBuilder.Append("<tr>");
				stringBuilder.Append("<td>Evasion:</td><td>" + $"{submarineCombatSystemOODAValues.Item6:0}" + " seconds</td>");
				stringBuilder.Append("</tr>");
				stringBuilder.Append("</table>");
				return stringBuilder.ToString();
			}
			case GlobalVariables.ActiveUnitType.Facility:
			{
				Scenario theScen = Client.CurrentScenario;
				(string, string, short, short, short) facilityCombatSystemOODAValues = DBFunctions.GetFacilityCombatSystemOODAValues(ref theScen, CombatSystemGenID, CheckIfTableExists: false);
				stringBuilder.Append("<table style='font-family:Verdana;font-size:8pt'>");
				stringBuilder.Append("<tr>");
				stringBuilder.Append("<td>Detection:</td><td>" + Conversions.ToString((int)facilityCombatSystemOODAValues.Item3) + " seconds Observe, Orient, Decide, and Act (reaction time)<td>");
				stringBuilder.Append("</tr>");
				stringBuilder.Append("<tr>");
				stringBuilder.Append("<td valign=top>Targeting:</td><td>" + $"{facilityCombatSystemOODAValues.Item4 * 2:0}" + " seconds (Novice Proficiency Level)<br>" + $"{(double)facilityCombatSystemOODAValues.Item4 * 1.5:0}" + " seconds (Cadet)<br>" + $"{(double)facilityCombatSystemOODAValues.Item4 * 1.2:0}" + " seconds (Regular)<br>" + $"{facilityCombatSystemOODAValues.Item4:0}" + " seconds (Veteran)<br>" + $"{(double)facilityCombatSystemOODAValues.Item4 * 0.8:0}" + " seconds (Ace)</td>");
				stringBuilder.Append("</tr>");
				stringBuilder.Append("<tr>");
				stringBuilder.Append("<td>Evasion:</td><td>" + $"{facilityCombatSystemOODAValues.Item5:0}" + " seconds</td>");
				stringBuilder.Append("</tr>");
				stringBuilder.Append("</table>");
				return stringBuilder.ToString();
			}
			case GlobalVariables.ActiveUnitType.Vehicle:
			case GlobalVariables.ActiveUnitType.Personnel:
			{
				Scenario theScen = Client.CurrentScenario;
				(string, string, short, short, short) groundUnitCombatSystemOODAValues = DBFunctions.GetGroundUnitCombatSystemOODAValues(ref theScen, CombatSystemGenID, CheckIfTableExists: false);
				stringBuilder.Append("<table style='font-family:Verdana;font-size:8pt'>");
				stringBuilder.Append("<tr>");
				stringBuilder.Append("<td>Detection:</td><td>" + Conversions.ToString((int)groundUnitCombatSystemOODAValues.Item3) + " seconds Observe, Orient, Decide, and Act (reaction time)<td>");
				stringBuilder.Append("</tr>");
				stringBuilder.Append("<tr>");
				stringBuilder.Append("<td valign=top>Targeting:</td><td>" + $"{groundUnitCombatSystemOODAValues.Item4 * 2:0}" + " seconds (Novice Proficiency Level)<br>" + $"{(double)groundUnitCombatSystemOODAValues.Item4 * 1.5:0}" + " seconds (Cadet)<br>" + $"{(double)groundUnitCombatSystemOODAValues.Item4 * 1.2:0}" + " seconds (Regular)<br>" + $"{groundUnitCombatSystemOODAValues.Item4:0}" + " seconds (Veteran)<br>" + $"{(double)groundUnitCombatSystemOODAValues.Item4 * 0.8:0}" + " seconds (Ace)</td>");
				stringBuilder.Append("</tr>");
				stringBuilder.Append("<tr>");
				stringBuilder.Append("<td>Evasion:</td><td>" + $"{groundUnitCombatSystemOODAValues.Item5:0}" + " seconds</td>");
				stringBuilder.Append("</tr>");
				stringBuilder.Append("</table>");
				return stringBuilder.ToString();
			}
			}
		}
		int OODA_Detect = default(int);
		int OODA_Targeting = default(int);
		int OODA_Evasive = default(int);
		DBFunctions.smethod_0(UnitType, UnitDBID, Client.CurrentScenario.DBConnection, ref OODA_Detect, ref OODA_Targeting, ref OODA_Evasive);
		stringBuilder.Append("<table style='font-family:Verdana;font-size:8pt'>");
		stringBuilder.Append("<tr>");
		stringBuilder.Append("<td>Detection:</td><td>" + Conversions.ToString(OODA_Detect) + " seconds Observe, Orient, Decide, and Act (reaction time)<td>");
		stringBuilder.Append("</tr>");
		stringBuilder.Append("<tr>");
		stringBuilder.Append("<td valign=top>Targeting:</td><td>" + $"{OODA_Targeting * 2:0}" + " seconds (Novice Proficiency Level)<br>" + $"{(double)OODA_Targeting * 1.5:0}" + " seconds (Cadet)<br>" + $"{(double)OODA_Targeting * 1.2:0}" + " seconds (Regular)<br>" + $"{OODA_Targeting:0}" + " seconds (Veteran)<br>" + $"{(double)OODA_Targeting * 0.8:0}" + " seconds (Ace)</td>");
		stringBuilder.Append("</tr>");
		stringBuilder.Append("<tr>");
		stringBuilder.Append("<td>Evasion:</td><td>" + $"{OODA_Evasive:0}" + " seconds</td>");
		stringBuilder.Append("</tr>");
		stringBuilder.Append("</table>");
		return stringBuilder.ToString();
	}

	public string Weapon_General(Weapon theW)
	{
		string text = "<div style='border-bottom: black 1px solid'><span style='font-family: Arial; color: dodgerblue;'><strong>GENERAL DATA</strong></span></div>";
		StreamReader streamReader = new StreamReader(Path.Combine(GameGeneral.DBFolderPath, "Templates\\Weapon.html"));
		using (streamReader)
		{
			text += streamReader.ReadToEnd();
		}
		text += "<br/>";
		text = text.Replace("<%Type%>", Misc.ToEnglishString(theW.Type));
		text = ((!(theW.Span > 0f)) ? text.Replace("<%Span%>", "-") : text.Replace("<%Span%>", Conversions.ToString(theW.Span) + " m"));
		text = ((!(theW.Length > 0f)) ? text.Replace("<%Length%>", "-") : text.Replace("<%Length%>", Conversions.ToString(theW.Length) + " m"));
		text = ((!(theW.Diameter > 0f)) ? text.Replace("<%Diameter%>", "-") : text.Replace("<%Diameter%>", Conversions.ToString(theW.Diameter) + " m"));
		text = ((theW.EmptyWeight <= 0) ? text.Replace("<%Weight%>", "-") : text.Replace("<%Weight%>", Conversions.ToString(theW.EmptyWeight) + " kg"));
		text = ((theW.BurnoutWeight() <= 0) ? text.Replace("<%BurnoutWeight%>", "-") : text.Replace("<%BurnoutWeight%>", Conversions.ToString(theW.BurnoutWeight()) + " kg"));
		if (theW.CruiseAltitude_AGL > 0f)
		{
			text = text.Replace("<%CruiseAlt%>", $"{theW.CruiseAltitude_AGL:0.0}" + " m AGL");
			text = text.Replace("<%CruiseAltFeet%>", $"{theW.CruiseAltitude_AGL * 3.28084f:0}" + " ft AGL, ");
		}
		else if (theW.CruiseAltitude_ASL > 0f)
		{
			text = text.Replace("<%CruiseAlt%>", $"{theW.CruiseAltitude_ASL:0.0}" + " m ASL");
			text = text.Replace("<%CruiseAltFeet%>", $"{theW.CruiseAltitude_ASL * 3.28084f:0}" + " ft ASL, ");
		}
		else
		{
			text = text.Replace("<%CruiseAlt%>", "");
			text = text.Replace("<%CruiseAltFeet%>", "-");
		}
		if (theW.MaxAirRange > 0f)
		{
			text = ((!(theW.MinAirRange > 0f)) ? text.Replace("<%RangeAAW%>", Conversions.ToString(theW.MaxAirRange) + " nm") : text.Replace("<%RangeAAW%>", Conversions.ToString(theW.MinAirRange) + " - " + Conversions.ToString(theW.MaxAirRange) + " nm"));
			text = text.Replace("<%AirPOK%>", Conversions.ToString(theW.AirPOK) + " %");
		}
		else
		{
			text = text.Replace("<%RangeAAW%>", "-");
			text = text.Replace("<%AirPOK%>", "-");
		}
		if (theW.MaxSurfaceRange > 0f)
		{
			text = ((!(theW.MinSurfaceRange > 0f)) ? text.Replace("<%RangeASUW%>", Conversions.ToString(theW.MaxSurfaceRange) + " nm") : text.Replace("<%RangeASUW%>", Conversions.ToString(theW.MinSurfaceRange) + " - " + Conversions.ToString(theW.MaxSurfaceRange) + " nm"));
			text = text.Replace("<%SurfPOK%>", Conversions.ToString(theW.SurfPOK) + " %");
		}
		else
		{
			text = text.Replace("<%RangeASUW%>", "-");
			text = text.Replace("<%SurfPOK%>", "-");
		}
		if (theW.MaxLandRange > 0f)
		{
			text = ((!(theW.MinLandRange > 0f)) ? text.Replace("<%RangeLand%>", Conversions.ToString(theW.MaxLandRange) + " nm") : text.Replace("<%RangeLand%>", Conversions.ToString(theW.MinLandRange) + " - " + Conversions.ToString(theW.MaxLandRange) + " nm"));
			text = text.Replace("<%LandPOK%>", Conversions.ToString(theW.LandPOK) + " %");
		}
		else
		{
			text = text.Replace("<%RangeLand%>", "-");
			text = text.Replace("<%LandPOK%>", "-");
		}
		if (theW.MaxSubsurfaceRange > 0f)
		{
			text = ((!(theW.MinSubsurfaceRange > 0f)) ? text.Replace("<%RangeASW%>", Conversions.ToString(theW.MaxSubsurfaceRange) + " nm") : text.Replace("<%RangeASW%>", Conversions.ToString(theW.MinSubsurfaceRange) + " - " + Conversions.ToString(theW.MaxSubsurfaceRange) + " nm"));
			text = text.Replace("<%SubPOK%>", Conversions.ToString(theW.SubPOK) + " %");
		}
		else
		{
			text = text.Replace("<%RangeASW%>", "-");
			text = text.Replace("<%SubPOK%>", "-");
		}
		text = ((!(theW.MaxSurfaceRange > 0f) || theW.CEP_Surface <= 0) ? text.Replace("<%CEP_Surface%>", "-") : text.Replace("<%CEP_Surface%>", Conversions.ToString(theW.CEP_Surface) + " m"));
		text = ((!(theW.MaxLandRange > 0f) || theW.CEP_Land <= 0) ? text.Replace("<%CEP_Land%>", "-") : text.Replace("<%CEP_Land%>", Conversions.ToString(theW.CEP_Land) + " m"));
		if (theW.MinLaunchAlt_AGL > 0f && theW.MinLaunchAlt_ASL > 0f)
		{
			if (!(theW.MaxLaunchAlt_AGL > 0f) && theW.MaxLaunchAlt_ASL <= 0f)
			{
				text = text.Replace("<%LaunchAltMin%>", $"{theW.MinLaunchAlt_ASL:0.0}" + " m ASL and " + $"{theW.MinLaunchAlt_AGL:0.0}" + " m AGL ");
				text = text.Replace("<%LaunchAltFeetMin%>", $"{theW.MinLaunchAlt_ASL * 3.28084f:0}" + " ft ASL and " + $"{theW.MinLaunchAlt_AGL * 3.28084f:0}" + " ft AGL, ");
			}
			else
			{
				text = text.Replace("<%LaunchAltMin%>", $"{theW.MinLaunchAlt_ASL:0.0}" + " m ASL and " + $"{theW.MinLaunchAlt_AGL:0.0}" + " m AGL - ");
				text = text.Replace("<%LaunchAltFeetMin%>", $"{theW.MinLaunchAlt_ASL * 3.28084f:0}" + " ft ASL and " + $"{theW.MinLaunchAlt_AGL * 3.28084f:0}" + " ft AGL - ");
			}
		}
		else if (theW.MinLaunchAlt_ASL > 0f)
		{
			if (!(theW.MaxLaunchAlt_AGL > 0f) && theW.MaxLaunchAlt_ASL <= 0f)
			{
				text = text.Replace("<%LaunchAltMin%>", $"{theW.MinLaunchAlt_ASL:0.0}" + " m ASL");
				text = text.Replace("<%LaunchAltFeetMin%>", $"{theW.MinLaunchAlt_ASL * 3.28084f:0}" + " ft ASL, ");
			}
			else
			{
				text = text.Replace("<%LaunchAltMin%>", $"{theW.MinLaunchAlt_ASL:0.0}" + " m ASL - ");
				text = text.Replace("<%LaunchAltFeetMin%>", $"{theW.MinLaunchAlt_ASL * 3.28084f:0}" + " ft ASL - ");
			}
		}
		else if (theW.MinLaunchAlt_AGL > 0f)
		{
			if (!(theW.MaxLaunchAlt_AGL > 0f) && theW.MaxLaunchAlt_ASL <= 0f)
			{
				text = text.Replace("<%LaunchAltMin%>", $"{theW.MinLaunchAlt_AGL:0.0}" + " m AGL");
				text = text.Replace("<%LaunchAltFeetMin%>", $"{theW.MinLaunchAlt_AGL * 3.28084f:0}" + " ft AGL, ");
			}
			else
			{
				text = text.Replace("<%LaunchAltMin%>", $"{theW.MinLaunchAlt_AGL:0.0}" + " m AGL -");
				text = text.Replace("<%LaunchAltFeetMin%>", $"{theW.MinLaunchAlt_AGL * 3.28084f:0}" + " ft AGL - ");
			}
		}
		else if (theW.MinLaunchAlt_ASL > 0f && (theW.MaxLaunchAlt_AGL <= 0f || theW.MaxLaunchAlt_ASL <= 0f))
		{
			text = text.Replace("<%LaunchAltMin%>", $"{theW.MinLaunchAlt_ASL:0.0}" + " m ASL");
			text = text.Replace("<%LaunchAltFeetMin%>", $"{theW.MinLaunchAlt_ASL * 3.28084f:0}" + " ft ASL, ");
		}
		else if (theW.Type != Weapon._WeaponType.Torpedo && !theW.IsMine)
		{
			if (theW.Type == Weapon._WeaponType.GuidedWeapon && theW.MinLaunchAlt_AGL < 0f)
			{
				text = text.Replace("<%LaunchAltMin%>", $"{theW.MinLaunchAlt_ASL:0.0}" + " m - ");
				text = text.Replace("<%LaunchAltFeetMin%>", $"{theW.MinLaunchAlt_ASL * 3.28084f:0}" + " ft - ");
			}
			else if (theW.Type == Weapon._WeaponType.GuidedWeapon && theW.MinLaunchAlt_ASL < 0f)
			{
				text = text.Replace("<%LaunchAltMin%>", $"{theW.MinLaunchAlt_ASL:0.0}" + " m - ");
				text = text.Replace("<%LaunchAltFeetMin%>", $"{theW.MinLaunchAlt_ASL * 3.28084f:0}" + " ft - ");
			}
			else if (theW.MaxLaunchAlt_AGL == 0f && theW.MaxLaunchAlt_ASL == 0f && theW.MinLaunchAlt_AGL == 0f && theW.MinLaunchAlt_ASL == 0f)
			{
				text = text.Replace("<%LaunchAltMin%>", "-");
				text = text.Replace("<%LaunchAltFeetMin%>", "");
			}
			else if (!((theW.Type == Weapon._WeaponType.RV) | (theW.Type == Weapon._WeaponType.HGV)))
			{
				text = text.Replace("<%LaunchAltMin%>", "");
				text = text.Replace("<%LaunchAltFeetMin%>", "");
			}
			else
			{
				text = text.Replace("<%LaunchAltMin%>", "-");
				text = text.Replace("<%LaunchAltFeetMin%>", "");
			}
		}
		else if (theW.ParentScen.FeatureCompatibility.get_WeaponAGL_ASL(theW.ParentScen.DBConnection))
		{
			text = text.Replace("<%LaunchAltMin%>", $"{theW.MinLaunchAlt_ASL:0.0}" + " m - ");
			text = text.Replace("<%LaunchAltFeetMin%>", $"{theW.MinLaunchAlt_ASL * 3.28084f:0}" + " ft - ");
		}
		else
		{
			text = text.Replace("<%LaunchAltMin%>", $"{theW.MinLaunchAlt_AGL:0.0}" + " m - ");
			text = text.Replace("<%LaunchAltFeetMin%>", $"{theW.MinLaunchAlt_AGL * 3.28084f:0}" + " ft, ");
		}
		if (theW.MaxLaunchAlt_AGL > 0f && theW.MaxLaunchAlt_ASL > 0f)
		{
			text = text.Replace("<%LaunchAltMax%>", string.Format("{0:0.0}", theW.MaxLaunchAlt_ASL, 0) + " m ASL and " + string.Format("{0:0.0}", theW.MaxLaunchAlt_AGL, 0) + " m AGL");
			text = text.Replace("<%LaunchAltFeetMax%>", $"{theW.MaxLaunchAlt_ASL * 3.28084f:0}" + " ft ASL and " + Conversions.ToString(Conversions.ToInteger($"{(double)theW.MaxLaunchAlt_AGL / 0.3048 / 10.0:0.0}") * 10) + " ft AGL, ");
		}
		else if (theW.MaxLaunchAlt_AGL > 0f)
		{
			text = text.Replace("<%LaunchAltMax%>", string.Format("{0:0.0}", theW.MaxLaunchAlt_AGL, 0) + " m AGL");
			text = text.Replace("<%LaunchAltFeetMax%>", $"{theW.MaxLaunchAlt_AGL * 3.28084f:0}" + " ft AGL, ");
		}
		else if (theW.MaxLaunchAlt_ASL > 0f)
		{
			text = text.Replace("<%LaunchAltMax%>", string.Format("{0:0.0}", theW.MaxLaunchAlt_ASL, 0) + " m ASL");
			text = text.Replace("<%LaunchAltFeetMax%>", $"{theW.MaxLaunchAlt_ASL * 3.28084f:0}" + " ft ASL, ");
		}
		else if (theW.Type != Weapon._WeaponType.Torpedo && !theW.IsMine)
		{
			if (theW.Type == Weapon._WeaponType.GuidedWeapon && theW.MinLaunchAlt_AGL < 0f)
			{
				text = text.Replace("<%LaunchAltMax%>", string.Format("{0:0.0}", theW.MaxLaunchAlt_AGL, 0) + " m AGL");
				text = text.Replace("<%LaunchAltFeetMax%>", $"{theW.MaxLaunchAlt_AGL * 3.28084f:0}" + " ft AGL, ");
			}
			else if (theW.Type == Weapon._WeaponType.GuidedWeapon && theW.MinLaunchAlt_ASL < 0f)
			{
				text = text.Replace("<%LaunchAltMax%>", string.Format("{0:0.0}", theW.MaxLaunchAlt_ASL, 0) + " m ASL");
				text = text.Replace("<%LaunchAltFeetMax%>", $"{theW.MaxLaunchAlt_ASL * 3.28084f:0}" + " ft ASL, ");
			}
			else
			{
				text = text.Replace("<%LaunchAltMax%>", "");
				text = text.Replace("<%LaunchAltFeetMax%>", "");
			}
		}
		else if (theW.ParentScen.FeatureCompatibility.get_WeaponAGL_ASL(theW.ParentScen.DBConnection))
		{
			text = text.Replace("<%LaunchAltMax%>", string.Format("{0:0.0}", theW.MaxLaunchAlt_ASL, 0) + " m");
			text = text.Replace("<%LaunchAltFeetMax%>", $"{theW.MaxLaunchAlt_ASL * 3.28084f:0}" + " ft, ");
		}
		else
		{
			text = text.Replace("<%LaunchAltMax%>", string.Format("{0:0.0}", theW.MaxLaunchAlt_AGL, 0) + " m");
			text = text.Replace("<%LaunchAltFeetMax%>", $"{theW.MaxLaunchAlt_AGL * 3.28084f:0}" + " ft, ");
		}
		text = ((theW.MinLaunchSpeed >= 0 && theW.MaxLaunchSpeed > 0) ? text.Replace("<%LaunchSpdMin%>", Conversions.ToString(theW.MinLaunchSpeed) + " - ") : ((theW.MinLaunchSpeed <= 0 || theW.MaxLaunchSpeed > 0) ? text.Replace("<%LaunchSpdMin%>", "-") : text.Replace("<%LaunchSpdMin%>", Conversions.ToString(theW.MinLaunchSpeed) + " kt")));
		text = ((theW.MaxLaunchSpeed <= 0) ? text.Replace("<%LaunchSpdMax%>", "") : text.Replace("<%LaunchSpdMax%>", Conversions.ToString(theW.MaxLaunchSpeed) + " kt"));
		text = ((theW.MinTargetSpeed >= 0 && theW.MaxTargetSpeed > 0) ? text.Replace("<%TargetSpdMin%>", Conversions.ToString(theW.MinTargetSpeed) + " - ") : ((theW.MinTargetSpeed > 0 && theW.MaxTargetSpeed <= 0) ? text.Replace("<%TargetSpdMin%>", Conversions.ToString(theW.MinTargetSpeed) + " kt") : ((theW.MinTargetSpeed > 0 || theW.MaxTargetSpeed <= 0) ? text.Replace("<%TargetSpdMin%>", "-") : text.Replace("<%TargetSpdMin%>", "n/a"))));
		text = ((theW.MaxTargetSpeed <= 0) ? text.Replace("<%TargetSpdMax%>", "") : text.Replace("<%TargetSpdMax%>", Conversions.ToString(theW.MaxTargetSpeed) + " kt"));
		if (theW.MinTargetAlt_AGL > 0f && (theW.MaxTargetAlt_AGL > 0f || theW.MaxTargetAlt_ASL > 0f))
		{
			text = text.Replace("<%TargetAltMin%>", string.Format("{0:0.0}", theW.MinTargetAlt_AGL, 0) + " m AGL - ");
			text = text.Replace("<%TargetAltFeetMin%>", $"{theW.MinTargetAlt_AGL * 3.28084f:0}" + " ft AGL - ");
		}
		else if (theW.MinTargetAlt_ASL > 0f && (theW.MaxTargetAlt_AGL > 0f || theW.MaxTargetAlt_ASL > 0f))
		{
			text = text.Replace("<%TargetAltMin%>", string.Format("{0:0.0}", theW.MinTargetAlt_ASL, 0) + " m ASL - ");
			text = text.Replace("<%TargetAltFeetMin%>", $"{theW.MinTargetAlt_ASL * 3.28084f:0}" + " ft ASL - ");
		}
		else if (theW.MinTargetAlt_AGL > 0f && (theW.MaxTargetAlt_AGL <= 0f || theW.MaxTargetAlt_ASL <= 0f))
		{
			text = text.Replace("<%TargetAltMin%>", string.Format("{0:0.0}", theW.MinTargetAlt_AGL, 0) + " m AGL - ");
			text = text.Replace("<%TargetAltFeetMin%>", $"{theW.MinTargetAlt_AGL * 3.28084f:0}" + " ft AGL - ");
		}
		else if (theW.MinTargetAlt_ASL > 0f && (theW.MaxTargetAlt_AGL <= 0f || theW.MaxTargetAlt_ASL <= 0f))
		{
			text = text.Replace("<%TargetAltMin%>", string.Format("{0:0.0}", theW.MinTargetAlt_ASL, 0) + " m ASL - ");
			text = text.Replace("<%TargetAltFeetMin%>", $"{theW.MinTargetAlt_ASL * 3.28084f:0}" + " ft ASL - ");
		}
		else if (theW.MinTargetAlt_AGL <= 0f && (theW.MaxTargetAlt_AGL > 0f || theW.MaxTargetAlt_ASL > 0f))
		{
			text = text.Replace("<%TargetAltMin%>", "n/a");
			text = text.Replace("<%TargetAltFeetMin%>", "n/a");
		}
		else if (theW.MinTargetAlt_ASL <= 0f && (theW.MaxTargetAlt_AGL > 0f || theW.MaxTargetAlt_ASL > 0f))
		{
			text = text.Replace("<%TargetAltMin%>", "n/a");
			text = text.Replace("<%TargetAltFeetMin%>", "n/a");
		}
		else if (theW.Type != Weapon._WeaponType.Torpedo && !theW.IsMine)
		{
			text = text.Replace("<%TargetAltMin%>", "-");
			text = text.Replace("<%TargetAltFeetMin%>", "");
		}
		else if (!theW.ParentScen.FeatureCompatibility.get_WeaponAGL_ASL(theW.ParentScen.DBConnection))
		{
			text = text.Replace("<%TargetAltMin%>", string.Format("{0:0.0}", theW.MinTargetAlt_AGL, 0) + " m - ");
			text = text.Replace("<%TargetAltFeetMin%>", $"{theW.MinTargetAlt_AGL * 3.28084f:0}" + " ft - ");
		}
		else
		{
			text = text.Replace("<%TargetAltMin%>", string.Format("{0:0.0}", theW.MinTargetAlt_ASL, 0) + " m - ");
			text = text.Replace("<%TargetAltFeetMin%>", $"{theW.MinTargetAlt_ASL * 3.28084f:0}" + " ft - ");
		}
		if (theW.MaxTargetAlt_AGL > 0f)
		{
			text = text.Replace("<%TargetAltMax%>", string.Format("{0:0.0}", theW.MaxTargetAlt_AGL, 0) + " m AGL");
			text = text.Replace("<%TargetAltFeetMax%>", $"{theW.MaxTargetAlt_AGL * 3.28084f:0}" + " ft AGL, ");
		}
		else if (theW.MaxTargetAlt_ASL > 0f)
		{
			text = text.Replace("<%TargetAltMax%>", string.Format("{0:0.0}", theW.MaxTargetAlt_ASL, 0) + " m ASL");
			text = text.Replace("<%TargetAltFeetMax%>", $"{theW.MaxTargetAlt_ASL * 3.28084f:0}" + " ft ASL, ");
		}
		else if (theW.Type != Weapon._WeaponType.Torpedo && !theW.IsMine)
		{
			text = text.Replace("<%TargetAltMax%>", "");
			text = text.Replace("<%TargetAltFeetMax%>", "");
		}
		else if (theW.ParentScen.FeatureCompatibility.get_WeaponAGL_ASL(theW.ParentScen.DBConnection))
		{
			text = text.Replace("<%TargetAltMax%>", string.Format("{0:0.0}", theW.MaxTargetAlt_ASL, 0) + " m");
			text = text.Replace("<%TargetAltFeetMax%>", $"{theW.MaxTargetAlt_ASL * 3.28084f:0}" + " ft, ");
		}
		else
		{
			text = text.Replace("<%TargetAltMax%>", string.Format("{0:0.0}", theW.MaxTargetAlt_AGL, 0) + " m");
			text = text.Replace("<%TargetAltFeetMax%>", $"{theW.MaxTargetAlt_AGL * 3.28084f:0}" + " ft, ");
		}
		if (((ActiveUnit_Kinematics)theW.Kinematics).get_ClimbRate_Nominal(LimitByTrueAirspeed: true) > 0f)
		{
			text = text.Replace("<%ClimbRate%>", $"{((ActiveUnit_Kinematics)theW.Kinematics).get_ClimbRate_Nominal(LimitByTrueAirspeed: true):0.0}" + " m/sec");
			text = text.Replace("<%ClimbRateFeetPrMin%>", $"{((ActiveUnit_Kinematics)theW.Kinematics).get_ClimbRate_Nominal(LimitByTrueAirspeed: true) * 3.28084f:0}" + " ft/min, ");
		}
		else
		{
			text = text.Replace("<%ClimbRate%>", "");
			text = text.Replace("<%ClimbRateFeetPrMin%>", "-");
		}
		if (theW.Type == Weapon._WeaponType.GuidedWeapon && theW.IsAAWCapable)
		{
			text = ((!(theW.SnapUpDown > 0f)) ? text.Replace("<%SnapUpDownAltitude%>", "") : text.Replace("<%SnapUpDownAltitude%>", "<td>Snap Up / Down Altitude:</td><td colspan = 9>" + $"{theW.SnapUpDown * 3.28084f:0}" + " ft, " + $"{theW.SnapUpDown:0.0}" + " m</td>"));
		}
		text = ((theW.Type == Weapon._WeaponType.GuidedWeapon || theW.Type == Weapon._WeaponType.Torpedo) ? text.Replace("<%GuidanceType%>", "<td>Guidance Type:</td><td colspan = 9>" + theW.WeaponGuidanceTypeString + (theW.Flags.ReAttack_Capability ? " - Capable of re-attack" : "") + "</td>") : text.Replace("<%GuidanceType%>", ""));
		List<float> list = new List<float>();
		try
		{
			list = DBFunctions.GetTorpedoKinematicRange(theW.DBID, Client.CurrentScenario.DBConnection);
			if (list.Count > 0)
			{
				text = ((!(list[0] > 0f)) ? text.Replace("<%TorpedoKinematicRangeCruise%>", "<td></td><td></td>") : text.Replace("<%TorpedoKinematicRangeCruise%>", "<td>Kinematic Range:</td><td>" + Conversions.ToString(list[1]) + " nm at " + Conversions.ToString(list[0]) + " kt</td>"));
				text = ((!(list[3] > 0f)) ? text.Replace("<%TorpedoKinematicRangeFull%>", "<td></td><td></td>") : text.Replace("<%TorpedoKinematicRangeFull%>", "<td></td><td>" + Conversions.ToString(list[3]) + " nm at " + Conversions.ToString(list[2]) + " kt</td>"));
			}
			else
			{
				text = text.Replace("<%TorpedoKinematicRangeCruise%>", "<td></td><td></td>");
				text = text.Replace("<%TorpedoKinematicRangeFull%>", "<td></td><td></td>");
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			text = text.Replace("<%TorpedoKinematicRangeCruise%>", "<td></td><td></td>");
			text = text.Replace("<%TorpedoKinematicRangeFull%>", "<td></td><td></td>");
			ex2?.Data.Add("Error at 200375", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return text;
	}

	public string Ship_General(Ship theShip)
	{
		string text = "<div style='border-bottom: black 1px solid'><span style='font-family: Arial; color: dodgerblue;'><strong>GENERAL DATA</strong></span></div>";
		StreamReader streamReader = new StreamReader(Path.Combine(GameGeneral.DBFolderPath, "Templates\\Ship.html"));
		using (streamReader)
		{
			text += streamReader.ReadToEnd();
		}
		text += "<br/>";
		Contact theTarget = Contact.Instantiate(theShip);
		string text2 = "";
		if (theTarget.ActualUnit != null)
		{
			theTarget.IDStatusBypassIdentification = Contact_Base.IdentificationStatus.KnownClass;
			GlobalVariables.BooleanObject EmitterClassificable = null;
			text2 = " (WRA: " + Doctrine.WRA_TargetType_String(theTarget, Contact.WRA_DetermineTargetType(ref theTarget, null, ref EmitterClassificable), EmitterClassificable.ToBoolean()) + ")";
		}
		text = text.Replace("<%Category%>", Misc.Description(theShip.Category, Client.CurrentScenario.DBConnection));
		text = text.Replace("<%Type%>", Misc.Description(theShip.Type, Client.CurrentScenario.DBConnection) + text2);
		text = text.Replace("<%DamagePts%>", Conversions.ToString(theShip.InitialDP));
		text = text.Replace("<%Length%>", Conversions.ToString(theShip.Length));
		text = text.Replace("<%Beam%>", Conversions.ToString(theShip.Beam));
		text = text.Replace("<%Draft%>", Conversions.ToString(theShip.Draft));
		text = text.Replace("<%Height%>", Conversions.ToString(theShip.Height));
		string newValue = ((theShip.Crew <= 0) ? ("0 (Autonomy Level: " + theShip.AutonomyLevel.ToString() + ")") : Conversions.ToString(theShip.Crew));
		text = text.Replace("<%Crew%>", newValue);
		text = ((!(theShip.Displacement_Empty > 0f)) ? text.Replace("<%Displacement_Empty%>", "-") : text.Replace("<%Displacement_Empty%>", Conversions.ToString(theShip.Displacement_Empty) + " tons"));
		text = text.Replace("<%Displacement_Standard%>", Conversions.ToString(theShip.Displacement_Standard) + " tons");
		text = ((!(theShip.Displacement_Full > 0f)) ? text.Replace("<%Displacement_Full%>", "-") : text.Replace("<%Displacement_Full%>", Conversions.ToString(theShip.Displacement_Full) + " tons"));
		text = text.Replace("<%DockingPhysicalSize%>", Misc.Description(theShip.DockingPhysicalSize, Client.CurrentScenario.DBConnection));
		text = text.Replace("<%MaxSeaState%>", Conversions.ToString(theShip.MaxSeaState));
		text = text.Replace("<%TroopCapacity%>", CargoHostHelper.TroopCapacityString(theShip));
		text = text.Replace("<%CargoCapacity%>", CargoHostHelper.CargoCapacityString(theShip));
		text = text.Replace("<%Armor_Belt%>", Misc.Description(theShip.Armor_Belt, Client.CurrentScenario.DBConnection));
		text = text.Replace("<%Armor_Bulkhead%>", Misc.Description(theShip.Armor_Bulkhead, Client.CurrentScenario.DBConnection));
		text = text.Replace("<%Armor_Deck%>", Misc.Description(theShip.Armor_Deck, Client.CurrentScenario.DBConnection));
		text = text.Replace("<%Armor_Engineering%>", Misc.Description(theShip.Armor_Engineering, Client.CurrentScenario.DBConnection));
		text = text.Replace("<%Armor_Bridge%>", Misc.Description(theShip.Armor_Bridge, Client.CurrentScenario.DBConnection));
		text = text.Replace("<%Armor_CIC%>", Misc.Description(theShip.Armor_CIC, Client.CurrentScenario.DBConnection));
		text = text.Replace("<%Armor_Rudder%>", Misc.Description(theShip.Armor_Rudder, Client.CurrentScenario.DBConnection));
		text = text.Replace("<%CombatSystem%>", CombatSystem_Description(theShip.UnitType, theShip.CombatSystemGen));
		text = text.Replace("<%OODA%>", OODA_Description(theShip.UnitType, theShip.DBID, theShip.CombatSystemGen));
		return text.Replace("<%MissileDefence%>", Conversions.ToString((int)theShip.MissileDefense) + " Harpoon / SLAM / Maverick equivalents");
	}

	public string Submarine_General(Submarine theSubmarine)
	{
		string text = "<div style='border-bottom: black 1px solid'><span style='font-family: Arial; color: dodgerblue;'><strong>GENERAL DATA</strong></span></div>";
		StreamReader streamReader = new StreamReader(Path.Combine(GameGeneral.DBFolderPath, "Templates\\Submarine.html"));
		using (streamReader)
		{
			text += streamReader.ReadToEnd();
		}
		text += "<br/>";
		Contact theTarget = Contact.Instantiate(theSubmarine);
		string text2 = "";
		if (theTarget.ActualUnit != null)
		{
			theTarget.IDStatusBypassIdentification = Contact_Base.IdentificationStatus.KnownClass;
			GlobalVariables.BooleanObject EmitterClassificable = null;
			text2 = " (WRA: " + Doctrine.WRA_TargetType_String(theTarget, Contact.WRA_DetermineTargetType(ref theTarget, null, ref EmitterClassificable), EmitterClassificable.ToBoolean()) + ")";
		}
		text = text.Replace("<%Category%>", Misc.Description(theSubmarine.Category, Client.CurrentScenario.DBConnection));
		text = text.Replace("<%Type%>", Misc.Description(theSubmarine.Type, Client.CurrentScenario.DBConnection) + text2);
		text = text.Replace("<%DamagePts%>", Conversions.ToString(theSubmarine.InitialDP));
		text = text.Replace("<%Length%>", Conversions.ToString(theSubmarine.Length));
		text = text.Replace("<%Beam%>", Conversions.ToString(theSubmarine.Beam));
		text = text.Replace("<%Draft%>", Conversions.ToString(theSubmarine.Draft));
		text = text.Replace("<%Height%>", Conversions.ToString(theSubmarine.Height));
		string newValue = ((theSubmarine.Crew > 0) ? Conversions.ToString(theSubmarine.Crew) : ("0 (Autonomy Level: " + theSubmarine.AutonomyLevel.ToString() + ")"));
		text = text.Replace("<%Crew%>", newValue);
		text = ((!(theSubmarine.Displacement_Empty <= 0f)) ? text.Replace("<%Displacement_Empty%>", Conversions.ToString(theSubmarine.Displacement_Empty) + " tons") : text.Replace("<%Displacement_Empty%>", "-"));
		text = text.Replace("<%Displacement_Standard%>", Conversions.ToString(theSubmarine.Displacement_Standard) + " tons");
		text = ((!(theSubmarine.Displacement_Full > 0f)) ? text.Replace("<%Displacement_Full%>", "-") : text.Replace("<%Displacement_Full%>", Conversions.ToString(theSubmarine.Displacement_Full) + " tons"));
		text = text.Replace("<%DockingPhysicalSize%>", Misc.Description(theSubmarine.DockingPhysicalSize, Client.CurrentScenario.DBConnection));
		text = text.Replace("<%ROVRadius%>", Conversions.ToString((int)theSubmarine.ROVControlRadius_m));
		text = text.Replace("<%MaxDepth%>", Conversions.ToString(theSubmarine.MaxDepth));
		text = text.Replace("<%OODA%>", OODA_Description(theSubmarine.UnitType, theSubmarine.DBID, 0));
		return text.Replace("<%CombatSystem%>", CombatSystem_Description(theSubmarine.UnitType, theSubmarine.CombatSystemGen));
	}

	public string Facility_General(Facility theFacility)
	{
		string text = "<div style='border-bottom: black 1px solid'><span style='font-family: Arial; color: dodgerblue;'><strong>GENERAL DATA</strong></span></div>";
		StreamReader streamReader = new StreamReader(Path.Combine(GameGeneral.DBFolderPath, "Templates\\Facility.html"));
		using (streamReader)
		{
			text += streamReader.ReadToEnd();
		}
		text += "<br/>";
		Contact theTarget = Contact.Instantiate(theFacility);
		string text2 = "";
		if (theTarget.ActualUnit != null)
		{
			theTarget.IDStatusBypassIdentification = Contact_Base.IdentificationStatus.KnownClass;
			GlobalVariables.BooleanObject EmitterClassificable = null;
			text2 = " (WRA: " + Doctrine.WRA_TargetType_String(theTarget, Contact.WRA_DetermineTargetType(ref theTarget, null, ref EmitterClassificable), EmitterClassificable.ToBoolean()) + ")";
		}
		text = text.Replace("<%Category%>", Misc.Description(theFacility.Category, Client.CurrentScenario.DBConnection) + text2);
		text = text.Replace("<%DamagePts%>", Conversions.ToString(((ActiveUnit)theFacility).get_DamagePts(ScenEditAction: false, (Weapon)null)));
		text = text.Replace("<%Length%>", Conversions.ToString(theFacility.Length));
		text = text.Replace("<%Width%>", Conversions.ToString(theFacility.Width));
		text = text.Replace("<%Area%>", Conversions.ToString(theFacility.Area));
		string newValue = ((theFacility.Crew <= 0) ? ("0 (Autonomy Level: " + theFacility.AutonomyLevel.ToString() + ")") : Conversions.ToString(theFacility.Crew));
		text = text.Replace("<%Crew%>", newValue);
		text = text.Replace("<%Armor_General%>", Misc.Description(theFacility.Armor_General, Client.CurrentScenario.DBConnection));
		text = text.Replace("<%MastHeight%>", Conversions.ToString(theFacility.MastHeight));
		text = text.Replace("<%AimpointDispersalRadius%>", Conversions.ToString(theFacility.AimpointDispersalRadius));
		text = text.Replace("<%OODA%>", OODA_Description(theFacility.UnitType, theFacility.DBID, 0));
		text = text.Replace("<%CombatSystem%>", CombatSystem_Description(theFacility.UnitType, theFacility.CombatSystemGen));
		text = text.Replace("<%MissileDefence%>", Conversions.ToString(theFacility.MissileDefense) + " Harpoon / SLAM / Maverick equivalents");
		if (theFacility.RepresentsMobileGroundUnit)
		{
			text = text.Replace("<%FireOnTheMove%>", theFacility.CanFireOnTheMove ? "Unit Can Fire on the Move" : "Unit Must Halt to Fire");
		}
		return text;
	}

	public string Satellite_General(Satellite theSatellite)
	{
		string text = "<div style='border-bottom: black 1px solid'><span style='font-family: Arial; color: dodgerblue;'><strong>GENERAL DATA</strong></span></div>";
		StreamReader streamReader = new StreamReader(Path.Combine(GameGeneral.DBFolderPath, "Templates\\Satellite.html"));
		using (streamReader)
		{
			text += streamReader.ReadToEnd();
		}
		text += "<br/>";
		Contact theTarget = Contact.Instantiate(theSatellite);
		string text2 = "";
		if (theTarget.ActualUnit != null)
		{
			theTarget.IDStatusBypassIdentification = Contact_Base.IdentificationStatus.KnownClass;
			GlobalVariables.BooleanObject EmitterClassificable = null;
			text2 = " (WRA: " + Doctrine.WRA_TargetType_String(theTarget, Contact.WRA_DetermineTargetType(ref theTarget, null, ref EmitterClassificable), EmitterClassificable.ToBoolean()) + ")";
		}
		text = text.Replace("<%Category%>", Misc.Description(theSatellite.Category, Client.CurrentScenario.DBConnection));
		text = text.Replace("<%Type%>", Misc.Description(theSatellite.Type, Client.CurrentScenario.DBConnection) + text2);
		text = text.Replace("<%DamagePts%>", Conversions.ToString(theSatellite.InitialDP));
		text = text.Replace("<%Length%>", Conversions.ToString(theSatellite.Length));
		text = text.Replace("<%Span%>", Conversions.ToString(theSatellite.Span));
		text = text.Replace("<%Height%>", Conversions.ToString(theSatellite.Height));
		text = text.Replace("<%WeightEmpty%>", Conversions.ToString(theSatellite.WeightEmpty));
		text = text.Replace("<%WeightMax%>", Conversions.ToString(theSatellite.WeightMax));
		text = text.Replace("<%WeightPayload%>", Conversions.ToString(theSatellite.WeightPayload));
		text = text.Replace("<%Armor%>", Misc.Description(theSatellite.Armor, Client.CurrentScenario.DBConnection));
		text = text.Replace("<%OODA%>", "-");
		return text.Replace("<%Crew%>", "-");
	}

	public string DisplayImage(ActiveUnit AU)
	{
		string mainImageFileString = UnitImageCaching.getMainImageFileString(AU);
		List<string> thumbnailImageFileStrings = UnitImageCaching.getThumbnailImageFileStrings(AU);
		List<string> thumbnailImageFileStrings2 = UnitImageCaching.getThumbnailImageFileStrings(AU, UseVirtualFolderMapping: true);
		return DisplayImage(mainImageFileString, thumbnailImageFileStrings, thumbnailImageFileStrings2, UnitImageCaching.getMainImageFileString(AU, UseVirtualFolderMapping: true));
	}

	public string DisplaySensorImage(int theDBID)
	{
		if (Client.CurrentScenario == null)
		{
			return string.Empty;
		}
		string sensorMainImageFileString = UnitImageCaching.GetSensorMainImageFileString(Client.CurrentScenario.DBUsed, theDBID);
		List<string> sensorThumbnailImageFileStrings = UnitImageCaching.getSensorThumbnailImageFileStrings(Client.CurrentScenario.DBUsed, theDBID);
		List<string> sensorThumbnailImageFileStrings2 = UnitImageCaching.getSensorThumbnailImageFileStrings(Client.CurrentScenario.DBUsed, theDBID, UseVirtualFolderMapping: true);
		return DisplayImage(sensorMainImageFileString, sensorThumbnailImageFileStrings, sensorThumbnailImageFileStrings2, UnitImageCaching.GetSensorMainImageFileString(Client.CurrentScenario.DBUsed, theDBID, UseVirtualFolderMapping: true));
	}

	public string DisplayImage(string ImageFileString, List<string> Thumbnails, List<string> Thumbnails_VirtualMapping = null, string ImageFileString_Virtual = "")
	{
		if (Thumbnails.Count == 0)
		{
			return string.Empty;
		}
		List<string> list = Thumbnails;
		if (Thumbnails_VirtualMapping != null)
		{
			list = Thumbnails_VirtualMapping;
		}
		string theFileName = Thumbnails[0];
		string theFileName2 = Thumbnails[1];
		string theFileName3 = Thumbnails[2];
		string theFileName4 = Thumbnails[3];
		string theFileName5 = Thumbnails[4];
		string theFileName6 = Thumbnails[5];
		if (FileExistsNative.FileExistsFast(ImageFileString) && new FileInfo(ImageFileString).Length == 0L)
		{
			try
			{
				File.Delete(ImageFileString);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				_ = Debugger.IsAttached;
				ProjectData.ClearProjectError();
			}
		}
		foreach (string Thumbnail in Thumbnails)
		{
			if (FileExistsNative.FileExistsFast(Thumbnail) && new FileInfo(Thumbnail).Length == 0L)
			{
				try
				{
					File.Delete(Thumbnail);
				}
				catch (Exception projectError2)
				{
					ProjectData.SetProjectError(projectError2);
					_ = Debugger.IsAttached;
					ProjectData.ClearProjectError();
				}
			}
		}
		if (SimConfiguration.DefaultGamePreferences.AllowInGameDownloads)
		{
			if (!FileExistsNative.FileExistsFast(ImageFileString))
			{
				UnitImageCaching.FetchImageFromRemoteServers(ImageFileString);
			}
			foreach (string Thumbnail2 in Thumbnails)
			{
				if (!FileExistsNative.FileExistsFast(Thumbnail2))
				{
					UnitImageCaching.FetchImageFromRemoteServers(Thumbnail2);
				}
			}
		}
		string text;
		if (FileExistsNative.FileExistsFast(ImageFileString))
		{
			text = "<div><table width='100%'><tr><td width='10%'><td><td width='80%' align='center'><img src='" + ImageFileString_Virtual + "' width='900px'  style='float:middle;margin:0 5px 5px 0;' /></td><td width='10%'></td></tr></table></div><br/>";
			if (FileExistsNative.FileExistsFast(theFileName) || FileExistsNative.FileExistsFast(theFileName2) || FileExistsNative.FileExistsFast(theFileName3))
			{
				text += "<div align = 'center'>";
				if (FileExistsNative.FileExistsFast(theFileName))
				{
					text = text + "<img src='" + list[0] + "' width='250px' style='float:middle;margin:0 5px 5px 0;'/>";
				}
				if (FileExistsNative.FileExistsFast(theFileName2))
				{
					text = text + "<img src='" + list[1] + "' width='250px' style='float:middle;margin:0 5px 5px 0;' />";
				}
				if (FileExistsNative.FileExistsFast(theFileName3))
				{
					text = text + "<img src='" + list[2] + "' width='250px' style='float:middle;margin:0 5px 5px 0;' />";
				}
				text += "</div><br/>";
			}
			if (FileExistsNative.FileExistsFast(theFileName4) || FileExistsNative.FileExistsFast(theFileName5) || FileExistsNative.FileExistsFast(theFileName6))
			{
				text += "<div align = 'center'>";
				if (FileExistsNative.FileExistsFast(theFileName4))
				{
					text = text + "<img src='" + list[3] + "' width='250px' style='float:middle;margin:0 5px 5px 0;' />";
				}
				if (FileExistsNative.FileExistsFast(theFileName5))
				{
					text = text + "<img src='" + list[4] + "' width='250px' style='float:middle;margin:0 5px 5px 0;' />";
				}
				if (FileExistsNative.FileExistsFast(theFileName6))
				{
					text = text + "<img src='" + list[5] + "' width='250px' style='float:middle;margin:0 5px 5px 0;' />";
				}
				text += "</div><br/>";
			}
		}
		else
		{
			text = "";
		}
		return text;
	}

	public string DisplayIndentedImage(ActiveUnit AU)
	{
		string text;
		if (!AU.IsAircraft)
		{
			if (AU.IsShip)
			{
				text = "Ship";
			}
			else if (AU.IsSubmarine)
			{
				text = "Submarine";
			}
			else if (AU.IsFacility)
			{
				text = "Facility";
			}
			else if (!AU.IsMobileGroundUnit)
			{
				if (AU.IsSatellite)
				{
					text = "Satellite";
				}
				else
				{
					if (!AU.IsWeapon)
					{
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						return string.Empty;
					}
					text = "Weapon";
				}
			}
			else
			{
				text = "GroundUnit";
			}
		}
		else
		{
			text = "Aircraft";
		}
		string text2 = "";
		switch (DBOps.GetDBRecordByHash(Client.CurrentScenario.DBUsed, ref dbfileCheckResult_0, CheckLocalFileExists: false, CheckForTampering: false).DBID)
		{
		case 1:
			text2 = "DB3000";
			break;
		case 2:
			text2 = "CWDB";
			break;
		case 3:
			text2 = "WW2DB";
			break;
		}
		string text3 = Path.Combine(GameGeneral.DBFolderPath, "Images\\" + text2);
		if (!Directory.Exists(text3))
		{
			Directory.CreateDirectory(text3);
		}
		string text4 = Path.Combine(text3, text + "_" + Conversions.ToString(AU.DBID) + "_i1.webp");
		string text5 = Path.Combine(text3, text + "_" + Conversions.ToString(AU.DBID) + "_i2.webp");
		string text6 = Path.Combine(text3, text + "_" + Conversions.ToString(AU.DBID) + "_i3.webp");
		string text7 = Path.Combine(text3, text + "_" + Conversions.ToString(AU.DBID) + "_i4.webp");
		string text8;
		if (FileExistsNative.FileExistsFast(text4))
		{
			text8 = "<img src='" + text4 + "' width='200'/>";
			if (FileExistsNative.FileExistsFast(text5))
			{
				text8 = text8 + "<br><br><img src='" + text5 + "' width='200'/>";
			}
			if (FileExistsNative.FileExistsFast(text6))
			{
				text8 = text8 + "<br><br><img src='" + text6 + "' width='200'/>";
			}
			if (FileExistsNative.FileExistsFast(text7))
			{
				text8 = text8 + "<br><br><img src='" + text7 + "' width='200'/>";
			}
		}
		else
		{
			text8 = "";
		}
		return text8;
	}

	public string DisplaySensorDescription(string DBUsed, int theDBID)
	{
		string text = "Sensor";
		string text2 = UnitImageCaching.smethod_0(DBUsed);
		string text3 = Path.Combine(GameGeneral.DBFolderPath, "Descriptions\\" + text2);
		if (!Directory.Exists(text3))
		{
			Directory.CreateDirectory(text3);
		}
		string text4 = Path.Combine(text3, text + "_" + Conversions.ToString(theDBID) + ".txt");
		if (FileExistsNative.FileExistsFast(text4))
		{
			StreamReader streamReader = new StreamReader(text4);
			string text5 = "";
			using (streamReader)
			{
				text5 += streamReader.ReadToEnd();
			}
			text5 = HttpUtility.HtmlEncode(text5);
			string text6 = "<div style='border-bottom: black 1px solid'><span style='font-family: Arial; color: dodgerblue;'><strong>GENERAL DESCRIPTION</strong></span></div>";
			return text6 + "<div><span><table><tr><td valign='top'></td><td valign='top' style='font-family:Verdana;font-size:8pt;'>" + text5.Replace(Environment.NewLine, "<br/>") + "</td><tr></table></span></div> <br/>";
		}
		return "";
	}

	public string DisplayDescription(ActiveUnit AU)
	{
		string text;
		if (AU.IsAircraft)
		{
			text = "Aircraft";
		}
		else if (AU.IsShip)
		{
			text = "Ship";
		}
		else if (AU.IsSubmarine)
		{
			text = "Submarine";
		}
		else if (!AU.IsFacility)
		{
			if (!AU.IsMobileGroundUnit)
			{
				if (AU.IsSatellite)
				{
					text = "Satellite";
				}
				else
				{
					if (!AU.IsWeapon)
					{
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						return string.Empty;
					}
					text = "Weapon";
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
		string text2 = "";
		switch (DBOps.GetDBRecordByHash(Client.CurrentScenario.DBUsed, ref dbfileCheckResult_0, CheckLocalFileExists: false, CheckForTampering: false).DBID)
		{
		case 1:
			text2 = "DB3000";
			break;
		case 2:
			text2 = "CWDB";
			break;
		case 3:
			text2 = "WW2DB";
			break;
		}
		string text3 = Path.Combine(GameGeneral.DBFolderPath, "Descriptions\\" + text2);
		if (!Directory.Exists(text3))
		{
			Directory.CreateDirectory(text3);
		}
		string text4 = Path.Combine(text3, text + "_" + Conversions.ToString(AU.DBID) + ".txt");
		string text6;
		if (FileExistsNative.FileExistsFast(text4))
		{
			StreamReader streamReader = new StreamReader(text4);
			string text5 = "";
			using (streamReader)
			{
				text5 += streamReader.ReadToEnd();
			}
			text5 = HttpUtility.HtmlEncode(text5);
			text6 = "<div style='border-bottom: black 1px solid'><span style='font-family: Arial; color: dodgerblue;'><strong>GENERAL DESCRIPTION</strong></span></div>";
			text6 = text6 + "<div><span><table><tr><td valign='top'>" + DisplayIndentedImage(AU) + "</td><td valign='top' style='font-family:Verdana;font-size:8pt;'>" + text5.Replace(Environment.NewLine, "<br/>") + "</td><tr></table></span></div> <br/>";
		}
		else
		{
			text6 = "";
		}
		return text6;
	}

	public string DisplaySensors(ActiveUnit AU)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (AU.Sensors_Cached.Length > 0)
		{
			stringBuilder.Append("<div style='border-bottom: black 1px solid'><span style='color: dodgerblue; font-family: Arial'><strong>SENSORS / EW</strong></span></div>");
			stringBuilder.Append("<table width='100%' align='Center'  cellpadding='2' cellspacing='0' rules='rows' style=' font-size: medium;  font-weight: normal;  text-align: left;   height: 10px; '>");
			stringBuilder.Append("<tr style='font-family:Verdana;font-size:10pt;font-weight:bold;background-color:DimGrey'>");
			stringBuilder.Append("<td>Model</td><td align='center'>Max Range</td><td>Notes</td><td>Abilities</td>");
			stringBuilder.Append("<td width=75>Arcs</td>");
			stringBuilder.Append("</tr>");
			IEnumerable<IGrouping<int, Sensor>> enumerable = from theS in AU.Sensors_Cached
				group theS by theS.DBID;
			foreach (IGrouping<int, Sensor> item in enumerable)
			{
				Sensor sensor = item.ElementAtOrDefault(0);
				string text = "";
				if (Operators.CompareString("Sensor" + Conversions.ToString(sensor.DBID), HighlightTarget, true) == 0)
				{
					text = "background-color:DarkGreen;";
				}
				stringBuilder.Append("<tr Name='Sensor" + Conversions.ToString(sensor.DBID) + "' style='" + text + "font-family:Verdana;font-size:8pt;'>");
				stringBuilder.Append(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("<td valign='top'>" + Conversions.ToString(item.Count()) + "x <a href="), (object)string_1), (object)"Sensor_"), (object)sensor.DBID), (object)">"), (object)sensor.Name), (object)"</a"), (object)"</td>"));
				if (sensor.maxRange > 0f)
				{
					switch (sensor.Type)
					{
					case Sensor.Sensor_Type.Infrared:
						stringBuilder.Append("<td align='center' valign='top'>" + Conversions.ToString(Sensor.VolumeSearchRange_IR(sensor)) + " / " + Conversions.ToString(sensor.maxRange) + " nm</td>");
						break;
					default:
						stringBuilder.Append("<td align='center' valign='top'>" + Conversions.ToString(sensor.maxRange) + " nm</td>");
						break;
					case Sensor.Sensor_Type.Visual:
						stringBuilder.Append("<td align='center' valign='top'>" + Conversions.ToString(Sensor.VolumeSearchRange_Visual(sensor)) + " / " + Conversions.ToString(sensor.maxRange) + " nm</td>");
						break;
					}
				}
				else
				{
					stringBuilder.Append("<td align='center' valign='top'>-</td>");
				}
				stringBuilder.Append("<td valign='top'>" + sensor.RoleDescription + "</td>");
				stringBuilder.Append("<td valign='top'>");
				List<string> list = new List<string>();
				if ((sensor.Type == Sensor.Sensor_Type.Radar || sensor.Type == Sensor.Sensor_Type.ESM || sensor.Type == Sensor.Sensor_Type.ECM || sensor.Type == Sensor.Sensor_Type.Visual || sensor.Type == Sensor.Sensor_Type.Infrared || sensor.Type == Sensor.Sensor_Type.BottomFixedSonar_PassiveOnly || sensor.Type == Sensor.Sensor_Type.DippingSonar_ActiveOnly || sensor.Type == Sensor.Sensor_Type.DippingSonar_ActivePassive || sensor.Type == Sensor.Sensor_Type.DippingSonar_PassiveOnly || sensor.Type == Sensor.Sensor_Type.HullSonar_ActiveOnly || sensor.Type == Sensor.Sensor_Type.HullSonar_ActivePassive || sensor.Type == Sensor.Sensor_Type.HullSonar_PassiveOnly || sensor.Type == Sensor.Sensor_Type.PingIntercept || sensor.Type == Sensor.Sensor_Type.TowedArray_ActiveOnly || sensor.Type == Sensor.Sensor_Type.TowedArray_ActivePassive || sensor.Type == Sensor.Sensor_Type.TowedArray_PassiveOnly || sensor.Type == Sensor.Sensor_Type.VDS_ActiveOnly || sensor.Type == Sensor.Sensor_Type.VDS_ActivePassive || sensor.Type == Sensor.Sensor_Type.VDS_PassiveOnly) && !sensor.IsMk1Eyeball)
				{
					Scenario theScen = Client.CurrentScenario;
					list.Add(DBFunctions.Get_Sensor_Generation_String(ref theScen, (int)sensor.TechGeneration) + " Technology");
				}
				if (sensor.Capabilities.AirSearch)
				{
					list.Add("Air Search");
				}
				if (sensor.Capabilities.SurfaceSearch)
				{
					list.Add("Surface Search");
				}
				if (sensor.Capabilities.SubSearch)
				{
					list.Add("Underwater Search");
				}
				if (sensor.Capabilities.Mine_Obstacle_Search)
				{
					list.Add("Mine & Obstacle Search");
				}
				if (sensor.Capabilities.LandSearch_Fixed)
				{
					list.Add("Ground Search (Fixed)");
				}
				if (sensor.Capabilities.LandSearch_Mobile)
				{
					list.Add("Ground Search (Mobile)");
				}
				if (sensor.Capabilities.GroundMappingOnly)
				{
					list.Add("Ground-mapping only");
				}
				if (sensor.Capabilities.NavigationOnly)
				{
					list.Add("Navigation Only");
				}
				if (sensor.Capabilities.SpaceSearch_ABM)
				{
					list.Add("ABM & Space Search");
				}
				if (sensor.Capabilities.OTH_Backscatter)
				{
					list.Add("OTH (Backscatter)");
				}
				if (sensor.Capabilities.OTH_SurfaceWave)
				{
					list.Add("OTH (Surface Wave)");
				}
				if (sensor.Capabilities.TerrainAvoidanceFollowingOnly)
				{
					list.Add("Terrain Avoidance/Following");
				}
				if (sensor.Capabilities.WeatherAndNavigationOnly)
				{
					list.Add("Weather & Navigation");
				}
				if (sensor.Capabilities.WeatherOnly)
				{
					list.Add("Weather Only");
				}
				if (sensor.Codes.NCTR_JEM)
				{
					list.Add("NCTR - JEM");
				}
				if (sensor.Codes.NCTR_NBILST)
				{
					list.Add("NCTR - NBILST");
				}
				if (sensor.Type == Sensor.Sensor_Type.ESM && sensor.ESM_PreciseEmitterID)
				{
					list.Add("Specific Emitter ID");
				}
				if (sensor.Capabilities.RangeInfo)
				{
					list.Add("Range Information");
				}
				if (sensor.Capabilities.AltitudeInfo)
				{
					list.Add("Altitude Info");
				}
				if (sensor.Capabilities.SpeedInfo)
				{
					list.Add("Speed Information");
				}
				if (sensor.Capabilities.HeadingInfo)
				{
					list.Add("Heading Info");
				}
				stringBuilder.Append(string.Join(", ", list));
				if (sensor.IsSensorInGroup > 0)
				{
					stringBuilder.Append("<br/>[Part of Sensor Group " + Conversions.ToString(sensor.IsSensorInGroup) + "]");
				}
				if (sensor.Type == Sensor.Sensor_Type.Radar)
				{
					if (sensor.SearchFreqs.Length > 0)
					{
						stringBuilder.Append("<br/>Operating bands (search & track): ").Append(string.Join(" / ", sensor.SearchFreqs.Select([SpecialName] (Sensor.RadioElectronicFrequency theF) => theF.ToString_Short)));
					}
					if (sensor.IlluminationFreqs.Length > 0)
					{
						stringBuilder.Append("<br/>Operating bands (FC / illumination): ").Append(string.Join(" / ", sensor.IlluminationFreqs.Select([SpecialName] (Sensor.RadioElectronicFrequency theF) => theF.ToString_Short)));
					}
				}
				if ((sensor.IsOECM || sensor.IsDECM || sensor.IsSonar || sensor.Type == Sensor.Sensor_Type.ESM) && sensor.SearchFreqs.Length > 0)
				{
					stringBuilder.Append("<br/>Operating bands: ").Append(string.Join(" / ", sensor.SearchFreqs.Select([SpecialName] (Sensor.RadioElectronicFrequency theF) => theF.ToString_Short)));
				}
				stringBuilder.Append("</td>");
				stringBuilder.Append("<td valign='top'>");
				bool flag = true;
				if (item.Count() > 1)
				{
					PlatformComponent._Coverage coverage = null;
					PlatformComponent._Coverage coverage2 = null;
					foreach (Sensor item2 in item)
					{
						if (item2.Coverage.HasDefinedArcs && coverage == null)
						{
							coverage = item2.Coverage;
							coverage2 = item2.Coverage_Illuminate;
							continue;
						}
						if (!item2.Coverage.HasDefinedArcs || Operators.CompareString(item2.Coverage.ToXML(IsIlluminate: false), coverage.ToXML(IsIlluminate: false), true) == 0)
						{
							if (item2.Coverage_Illuminate.HasDefinedArcs && Operators.CompareString(item2.Coverage_Illuminate.ToXML(IsIlluminate: true), coverage2.ToXML(IsIlluminate: true), true) != 0)
							{
								flag = false;
								break;
							}
							continue;
						}
						flag = false;
						break;
					}
				}
				int num = 0;
				foreach (Sensor item3 in item)
				{
					if (flag && item.Count() > 1)
					{
						stringBuilder.Append("All sensors<br/>");
					}
					else if (!flag || (item.Count() > 1 && num < item.Count()))
					{
						num++;
						stringBuilder.Append("Sensor #" + Conversions.ToString(num) + "<br/>");
					}
					List<string> theArcList = new List<string>();
					PlatformComponent._Coverage coverage3 = item3.Coverage;
					PlatformComponent theSensor = item3;
					coverage3.ComponentArcString(ref theSensor, ref theArcList);
					Sensor current3 = (Sensor)theSensor;
					if (theArcList.Count > 0)
					{
						stringBuilder.Append(ShowArcImage(theArcList));
					}
					if (current3.Coverage_Illuminate != null && current3.Coverage_Illuminate.HasDefinedArcs)
					{
						List<string> theArcList2 = new List<string>();
						PlatformComponent._Coverage coverage_Illuminate = current3.Coverage_Illuminate;
						theSensor = current3;
						coverage_Illuminate.ComponentArcString(ref theSensor, ref theArcList2);
						current3 = (Sensor)theSensor;
						if (theArcList2.Count > 0 && !theArcList.SequenceEqual(theArcList2))
						{
							stringBuilder.Append("<br/>Illuminates: ");
							stringBuilder.Append(ShowArcImage(theArcList2));
						}
					}
					if (!flag)
					{
						if (num < item.Count())
						{
							stringBuilder.Append("<br/>");
						}
						continue;
					}
					break;
				}
				stringBuilder.Append("</td></tr>");
			}
			stringBuilder.Append("</table>");
			stringBuilder.Append("<br/>");
		}
		return stringBuilder.ToString();
	}

	public string DisplayMineCountermeasuresGear(ActiveUnit AU)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (AU.MineCountermeasures.Count > 0)
		{
			stringBuilder.Append("<div style='border-bottom: black 1px solid'><span style='color: dodgerblue; font-family: Arial'><strong>MINE COUNTERMEASURES GEAR</strong></span></div>");
			stringBuilder.Append("<table width='100%' align='Center'  cellpadding='2' cellspacing='0' rules='rows' style=' font-size: medium;  font-weight: normal;  text-align: left;   height: 10px; '>");
			stringBuilder.Append("<tr style='font-family:Verdana;font-size:10pt;font-weight:bold;background-color:DimGrey'>");
			stringBuilder.Append("<td>Model</td><td>Notes</td>");
			stringBuilder.Append("</tr>");
			IEnumerable<IGrouping<int, Sensor>> enumerable = from theS in AU.MineCountermeasures
				group theS by theS.DBID;
			foreach (IGrouping<int, Sensor> item in enumerable)
			{
				Sensor sensor = item.ElementAtOrDefault(0);
				stringBuilder.Append("<tr style=';font-family:Verdana;font-size:8pt;'>");
				stringBuilder.Append("<td valign='top'>" + Conversions.ToString(item.Count()) + "x " + sensor.Name + "</td>");
				stringBuilder.Append("<td valign='top'>" + sensor.RoleDescription + "</td>");
				stringBuilder.Append("</tr>");
			}
			stringBuilder.Append("</table>");
			stringBuilder.Append("<br/>");
		}
		return stringBuilder.ToString();
	}

	public string DisplayMounts(ActiveUnit AU)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (AU.Mounts.Count > 0)
		{
			stringBuilder.Append("<div style='border-bottom: black 1px solid'><span style='color: dodgerblue; font-family: Arial'><strong>MOUNTS / STORES / WEAPONS</strong></span></div>");
			stringBuilder.Append("<span style='text-align: left; font-family: Arial; font-size: small; font-weight: bold;'>Mounts (Guns/Launchers/Ejectors/etc.)</span>");
			stringBuilder.Append("<table width='100%' align='Center'  cellpadding='2' cellspacing='0' rules='rows' style=' font-size: medium;  font-weight: normal;  text-align: left;   height: 10px; '>");
			stringBuilder.Append("<tr style='font-family:Verdana;font-size:10pt;font-weight:bold;background-color:DimGrey'>");
			stringBuilder.Append("<td>Mount</td><td align='center'>Capacity</td><td align='center'>Launch Interval</td><td align='center'>Armor</td><td align='center'>Onboard Sensors</td><td>Weapons (per mount)</td>");
			stringBuilder.Append("<td>Notes</td><td width=75>Arcs</td>");
			stringBuilder.Append("</tr>");
			IEnumerable<IGrouping<int, Mount>> enumerable = from theM in AU.Mounts
				group theM by theM.DBID;
			_Closure$__142-0 closure$__142- = default(_Closure$__142-0);
			foreach (IGrouping<int, Mount> item in enumerable)
			{
				closure$__142- = new _Closure$__142-0(closure$__142-);
				closure$__142-.$VB$Local_theM = item.ElementAtOrDefault(0);
				stringBuilder.Append("<tr style=';font-family:Verdana;font-size:8pt;'>");
				stringBuilder.Append("<td valign='top'>" + Conversions.ToString(item.Count()) + "x " + closure$__142-.$VB$Local_theM.Name + "</td>");
				if (!((closure$__142-.$VB$Local_theM.MountMagazine.Capacity > 0) & (Strings.InStr(closure$__142-.$VB$Local_theM.Name, "Rail", (CompareMethod)1) > 0)))
				{
					stringBuilder.Append("<td align='center' valign='top'>" + Conversions.ToString(closure$__142-.$VB$Local_theM.MaxCapacity + closure$__142-.$VB$Local_theM.MountMagazine.Capacity) + "</td>");
				}
				else
				{
					stringBuilder.Append("<td align='center' valign='top'>" + Conversions.ToString(closure$__142-.$VB$Local_theM.MountMagazine.Capacity) + "</td>");
				}
				if ((closure$__142-.$VB$Local_theM.MountMagazine.Capacity > 0) & (Strings.InStr(closure$__142-.$VB$Local_theM.Name, "Rail", (CompareMethod)1) > 0))
				{
					Mount mount = closure$__142-.$VB$Local_theM;
					int theQty_FullyLoadedCells = 0;
					int theQty_PartiallyLoadedCells = 0;
					if (mount.CurrentCapacity(ref theQty_FullyLoadedCells, ref theQty_PartiallyLoadedCells) > 1)
					{
						string[] obj = new string[5]
						{
							"<td align='center' valign='top'>On-rail: ",
							Conversions.ToString(closure$__142-.$VB$Local_theM.ROF),
							"<br>Salvo: ",
							null,
							null
						};
						int rOF = closure$__142-.$VB$Local_theM.ROF;
						int rOF2 = closure$__142-.$VB$Local_theM.MountMagazine.ROF;
						Mount mount2 = closure$__142-.$VB$Local_theM;
						theQty_PartiallyLoadedCells = 0;
						theQty_FullyLoadedCells = 0;
						obj[3] = Conversions.ToString(rOF + rOF2 * mount2.CurrentCapacity(ref theQty_PartiallyLoadedCells, ref theQty_FullyLoadedCells));
						obj[4] = "</td>";
						stringBuilder.Append(string.Concat(obj));
					}
					else
					{
						stringBuilder.Append("<td align='center' valign='top'>" + Conversions.ToString(closure$__142-.$VB$Local_theM.MountMagazine.ROF) + "</td>");
					}
				}
				else
				{
					stringBuilder.Append("<td align='center' valign='top'>" + Conversions.ToString(closure$__142-.$VB$Local_theM.ROF) + "</td>");
				}
				stringBuilder.Append("<td align='center' valign='top'>" + closure$__142-.$VB$Local_theM.ArmorRating.ToString() + "</td>");
				stringBuilder.Append("<td valign='top'>" + string.Join("<br/>", closure$__142-.$VB$Local_theM.Sensors_ReadOnly.Select([SpecialName] (Sensor theS) => theS.Name).ToArray()) + "</td>");
				stringBuilder.Append("<td valign='top'>");
				foreach (WeaponRec mountWeapon in closure$__142-.$VB$Local_theM.MountWeapons)
				{
					Weapon weapon = mountWeapon.get_ReferenceWeapon(Client.CurrentScenario);
					stringBuilder.Append((mountWeapon.CurrentLoad != 0) ? "" : "<i>");
					stringBuilder.Append(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)(Conversions.ToString(mountWeapon.CurrentLoad) + "x <a href="), (object)string_1), (object)"Weapon_"), (object)weapon.DBID), (object)">"), (object)((mountWeapon.Multiple > 1) ? ("(" + Conversions.ToString(mountWeapon.Multiple) + "/cell) ") : "")), (object)weapon.Name), (object)"</a>"));
					foreach (WeaponRec weapon2 in closure$__142-.$VB$Local_theM.MountMagazine.Weapons)
					{
						if (weapon2.int_3 == mountWeapon.int_3)
						{
							stringBuilder.Append("(+" + Conversions.ToString(weapon2.CurrentLoad) + " On mount magazine)");
						}
					}
					stringBuilder.Append((mountWeapon.CurrentLoad == 0) ? "</i>" : "");
					if (!weapon.IsDecoy)
					{
						stringBuilder.Append("<br/><font style='color:gray'>" + WeaponSummary(AU, weapon) + "</font>");
					}
					stringBuilder.Append("<br/>");
				}
				stringBuilder.Append("</td>");
				stringBuilder.Append("<td valign='top'>");
				if (closure$__142-.$VB$Local_theM.CompatibleDirectors.Count > 0)
				{
					IEnumerable<IGrouping<int, Sensor>> enumerable2 = from theS in AU.Sensors_Cached.Where(closure$__142-._Lambda$__2)
						group theS by theS.DBID;
					if (enumerable2.Count() > 0)
					{
						List<string> list = new List<string>();
						foreach (IGrouping<int, Sensor> item2 in enumerable2)
						{
							list.Add(item2.ElementAtOrDefault(0).Name);
						}
						stringBuilder.Append("Can be directed by: " + string.Join(", ", list) + ". ");
					}
				}
				if (closure$__142-.$VB$Local_theM.LocalControl)
				{
					stringBuilder.Append("Local control possible. ");
				}
				if (closure$__142-.$VB$Local_theM.IsAutonomous)
				{
					stringBuilder.Append("Operates autonomously (no OODA delay). ");
				}
				stringBuilder.Append("</td>");
				stringBuilder.Append("<td valign='top'>");
				bool flag = true;
				int num;
				if (item.Count() <= 1)
				{
					num = 0;
				}
				else
				{
					PlatformComponent._Coverage coverage = null;
					foreach (Mount item3 in item)
					{
						if (item3.Coverage.HasDefinedArcs && coverage == null)
						{
							coverage = item3.Coverage;
						}
						else if (item3.Coverage.HasDefinedArcs && Operators.CompareString(item3.Coverage.ToXML(IsIlluminate: false), coverage.ToXML(IsIlluminate: false), true) != 0)
						{
							flag = false;
							break;
						}
					}
					num = 0;
				}
				int num2 = num;
				foreach (Mount item4 in item)
				{
					if (flag && item.Count() > 1)
					{
						stringBuilder.Append("All mounts<br/>");
					}
					else if (!flag || (item.Count() > 1 && num2 < item.Count()))
					{
						num2++;
						stringBuilder.Append("Mount #" + Conversions.ToString(num2) + "<br/>");
					}
					List<string> theArcList = new List<string>();
					PlatformComponent._Coverage coverage2 = item4.Coverage;
					PlatformComponent theSensor = item4;
					coverage2.ComponentArcString(ref theSensor, ref theArcList);
					Mount current6 = (Mount)theSensor;
					if (theArcList.Count > 0)
					{
						stringBuilder.Append(ShowArcImage(theArcList));
					}
					if (!flag)
					{
						if (num2 < item.Count())
						{
							stringBuilder.Append("<br/>");
						}
						continue;
					}
					break;
				}
				stringBuilder.Append("</td></tr>");
			}
			stringBuilder.Append("</table>");
			stringBuilder.Append("<br/>");
		}
		return stringBuilder.ToString();
	}

	public string DisplayStores(Aircraft AU)
	{
		StringBuilder stringBuilder = new StringBuilder();
		int dBID = AU.DBID;
		SQLiteConnection sqliteConnection_ = Client.CurrentScenario.DBConnection;
		if (DBFunctions.WeaponsCarriedByThisAircraft(dBID, ref sqliteConnection_).Count > 0)
		{
			if (AU.Mounts.Count == 0)
			{
				stringBuilder.Append("<div style='border-bottom: black 1px solid'><span style='color: dodgerblue; font-family: Arial'><strong>MOUNTS / STORES / WEAPONS</strong></span></div>");
			}
			stringBuilder.Append("<button type='button' class='collapsible' style='text-align: left; font-family: Arial; font-size: small; font-weight: bold;'>- Aircraft Stores</button>");
			stringBuilder.Append("<div style='display: block'>");
			stringBuilder.Append("<table width='100%' align='Center'  cellpadding='2' cellspacing='0' rules='rows' style=' font-size: medium;  font-weight: normal;  text-align: left;   height: 10px; '>");
			stringBuilder.Append("<tr style='font-family:Verdana;font-size:10pt;font-weight:bold;background-color:DimGrey'>");
			stringBuilder.Append("<td>Store</td><td align='center'>Speed Release Envelope</td><td align='center'>Altitude Release Envelope</td><td>Description</td>");
			stringBuilder.Append("</tr>");
			List<int>.Enumerator enumerator = default(List<int>.Enumerator);
			try
			{
				int dBID2 = AU.DBID;
				sqliteConnection_ = Client.CurrentScenario.DBConnection;
				enumerator = DBFunctions.WeaponsCarriedByThisAircraft(dBID2, ref sqliteConnection_).GetEnumerator();
				while (enumerator.MoveNext())
				{
					int current = enumerator.Current;
					Weapon weapon = Client.CurrentScenario.Cache_GetWeapon(current);
					stringBuilder.Append("<tr style=';font-family:Verdana;font-size:8pt;'>");
					stringBuilder.Append(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"<td valign='top'><a href=", (object)string_1), (object)"Weapon_"), (object)weapon.DBID), (object)">"), (object)weapon.Name), (object)"</a>"), (object)"</td>"));
					string text = ((weapon.MinLaunchSpeed > 0 || weapon.MaxLaunchSpeed > 0) ? (Conversions.ToString(weapon.MinLaunchSpeed) + " - " + Conversions.ToString(weapon.MaxLaunchSpeed) + "kt") : "");
					string text2;
					if (!(weapon.MinLaunchAlt_AGL > 0f) && !(weapon.MaxLaunchAlt_AGL > 0f) && !(weapon.MinLaunchAlt_ASL > 0f) && weapon.MaxLaunchAlt_ASL <= 0f)
					{
						text2 = "";
					}
					else
					{
						string text3 = "";
						string text4 = "";
						float num;
						if (weapon.MinLaunchAlt_AGL != 0f)
						{
							num = weapon.MinLaunchAlt_AGL;
							text3 = " AGL";
						}
						else
						{
							num = weapon.MinLaunchAlt_ASL;
							text3 = " ASL";
						}
						float num2;
						int num3;
						if (weapon.MaxLaunchAlt_AGL != 0f)
						{
							num2 = weapon.MaxLaunchAlt_AGL;
							text4 = " AGL";
							num3 = 15;
						}
						else
						{
							num2 = weapon.MaxLaunchAlt_ASL;
							text4 = " ASL";
							num3 = 15;
						}
						string[] array = new string[num3];
						array[0] = $"{num * 3.28084f:0}";
						array[1] = " ft";
						array[2] = text3;
						array[3] = " - ";
						array[4] = $"{num2 * 3.28084f:0}";
						array[5] = " ft";
						array[6] = text4;
						array[7] = "<br>";
						array[8] = $"{num:0.0}";
						array[9] = " m";
						array[10] = text3;
						array[11] = " - ";
						array[12] = $"{num2:0.0}";
						array[13] = " m";
						array[14] = text4;
						text2 = string.Concat(array);
					}
					stringBuilder.Append("<td valign='top' align='center'>" + text + "</td>");
					stringBuilder.Append("<td valign='top' align='center'>" + text2 + "</td>");
					if (!weapon.IsDecoy && !weapon.IsFuelTank && weapon.Type != Weapon._WeaponType.SensorPod)
					{
						stringBuilder.Append("<td valign='top' align='left'>" + WeaponSummary(AU, weapon) + "</td>");
					}
					else
					{
						stringBuilder.Append("<td valign='top' align='left'>" + Misc.ToEnglishString(weapon.Type) + "</td>");
					}
					stringBuilder.Append("</tr>");
				}
			}
			finally
			{
				((IDisposable)enumerator/*cast due to .constrained prefix*/).Dispose();
			}
			stringBuilder.Append("</table>");
		}
		stringBuilder.Append("</div><br/>");
		stringBuilder.Append("<br/>");
		return stringBuilder.ToString();
	}

	public string DisplayLoadouts(Aircraft AU)
	{
		StringBuilder stringBuilder = new StringBuilder();
		int dBID = AU.DBID;
		SQLiteConnection sqliteConnection_ = Client.CurrentScenario.DBConnection;
		Scenario currentScenario = Client.CurrentScenario;
		bool UnlimitedAirWeapons = false;
		Scenario CurrentScenario = null;
		Aircraft SelectedAircraft = null;
		int num = 0;
		bool ExcludeOptionalWeapons = false;
		DataTable dataTable = DBFunctions.LoadoutsForThisAircraft_DT(dBID, null, ref sqliteConnection_, currentScenario, ref UnlimitedAirWeapons, ref CurrentScenario, ref SelectedAircraft, ref num, ref ExcludeOptionalWeapons);
		if (dataTable.Rows.Count > 0)
		{
			stringBuilder.Append("<style>\r\n/* Tooltip container */\r\n.tooltip {\r\n  position: relative;\r\n  display: inline-block;\r\n}\r\n\r\n/* Tooltip text */\r\n.tooltip .tooltiptext {\r\n  visibility: hidden;\r\n  width: 180px;\r\n  background-color: #555;\r\n  color: #fff;\r\n  text-align: center;\r\n  padding: 5px 0;\r\n  border-radius: 6px;\r\n\r\n  /* Position the tooltip text */\r\n  position: absolute;\r\n  z-index: 1;\r\n  bottom: 125%;\r\n  left: 50%;\r\n  margin-left: -60px;\r\n\r\n  /* Fade in tooltip */\r\n  opacity: 0;\r\n  transition: opacity 0.3s;\r\n}\r\n\r\n/* Tooltip arrow */\r\n.tooltip .tooltiptext::after {\r\n  content: \";\r\n  position: absolute;\r\n  top: 100%;\r\n  left: 50%;\r\n  margin-left: -5px;\r\n  border-width: 5px;\r\n  border-style: solid;\r\n  border-color: #555 transparent transparent transparent;\r\n}\r\n\r\n/* Show the tooltip text when you mouse over the tooltip container */\r\n.tooltip:hover .tooltiptext {\r\n  visibility: visible;\r\n  opacity: 1;\r\n}</style>");
			bool num2 = AU.Mounts.Count == 0;
			int dBID2 = AU.DBID;
			sqliteConnection_ = Client.CurrentScenario.DBConnection;
			if (num2 & (DBFunctions.WeaponsCarriedByThisAircraft(dBID2, ref sqliteConnection_).Count == 0))
			{
				stringBuilder.Append("<div style='border-bottom: black 1px solid'><span style='color: dodgerblue; font-family: Arial'><strong>MOUNTS / STORES / WEAPONS</strong></span></div>");
			}
			stringBuilder.Append("<button type='button' class='collapsible' style='text-align: left; font-family: Arial; font-size: small; font-weight: bold;'>- Aircraft Loadouts</button>");
			stringBuilder.Append("<div style='display: block'>");
			stringBuilder.Append("<table width='100%' align='Center'  cellpadding='2' cellspacing='0' rules='rows' style=' font-size: medium;  font-weight: normal;  text-align: left;   height: 10px; '>");
			stringBuilder.Append("<tr style='font-family:Verdana;font-size:10pt;font-weight:bold;background-color:DimGrey'>");
			stringBuilder.Append("<td>Name</td><td>Stores</td><td>Range and Profile</td><td align='center'>Ready Time</td><td align='center'>Day/Night & Weather</td><td align='center'>Pre-Briefed Weapon State</td><td>DB ID#</td></td>");
			stringBuilder.Append("</tr>");
			foreach (DataRow row in dataTable.Rows)
			{
				DBFunctions.GetLoadout(ref AU, Conversions.ToInteger(row["ID"]), ExcludeOptionalWeapons: false);
				Loadout loadout = AU.Loadout;
				if (loadout == null)
				{
					stringBuilder.Append("<td> </td><td></td><td align='center' valign='middle'> ** MISSING DATA ON LOADOUT **</td>");
					stringBuilder.Append("<td align='center' valign='middle'>-</td><td align='center' valign='middle'>-</td><td align='center' valign='middle'>-</td>");
					stringBuilder.Append("<td>" + Conversions.ToString(Conversions.ToInteger(row["ID"])) + "</td>");
					stringBuilder.Append("</tr>");
					continue;
				}
				string text = "";
				if (!string.IsNullOrEmpty(HighlightTarget) && Operators.CompareString("Loadout" + Conversions.ToString(loadout.DBID), HighlightTarget, true) == 0)
				{
					text = "background-color:DarkGreen;";
				}
				stringBuilder.Append("<tr name='Loadout" + Conversions.ToString(loadout.DBID) + "' style='" + text + "font-family:Verdana;font-size:8pt;'>");
				stringBuilder.Append("<td valign='middle'>" + loadout.Name);
				if (loadout.Role != Loadout.LoadoutRole.Ferry && loadout.Role != Loadout.LoadoutRole.Reserve && loadout.Role != Loadout.LoadoutRole.Unavailable && loadout.Role != Loadout.LoadoutRole.PackedForCargo)
				{
					stringBuilder.Append("<br>(" + Misc.Description(loadout.Role, Client.CurrentScenario.DBConnection) + ")");
				}
				stringBuilder.Append("</td>");
				stringBuilder.Append("<td valign='middle'>");
				WeaponRec[] weapons = loadout.Weapons;
				foreach (WeaponRec weaponRec in weapons)
				{
					stringBuilder.Append(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)(Conversions.ToString(weaponRec.CurrentLoad) + "x <a href="), (object)string_1), (object)"Weapon_"), (object)weaponRec.get_ReferenceWeapon(Client.CurrentScenario).DBID), (object)">"), (object)weaponRec.get_ReferenceWeapon(Client.CurrentScenario).Name), (object)"</a><br/>"));
				}
				stringBuilder.Append(loadout.RequiresBuddyIllumination ? "<br/></br>Requires External Illumination." : "");
				stringBuilder.Append("</td>");
				stringBuilder.Append("<td valign='middle'>");
				string text2 = "";
				string text3;
				if (Information.IsNothing((object)loadout.get_MissionProfile(Client.CurrentScenario)))
				{
					text3 = "n/a";
				}
				else
				{
					text3 = loadout.get_MissionProfile(Client.CurrentScenario).Description;
					text2 = ((loadout.get_MissionProfile(Client.CurrentScenario).DBID == 1001) ? "" : ((loadout.TimeOnStation_Minutes <= 0) ? (Conversions.ToString(loadout.CombatRadius) + " nm ") : (Conversions.ToString((int)loadout.TimeOnStation_Minutes) + " minutes at " + Conversions.ToString(loadout.CombatRadius) + " nm ")));
				}
				text3 = text2 + text3;
				stringBuilder.Append(text3);
				if (loadout.Cargo_Type != CargoType.NoCargo)
				{
					stringBuilder.Append("<br/>");
					switch (loadout.Cargo_Type)
					{
					case CargoType.const_5:
						stringBuilder.Append("Cargo: Very Large");
						break;
					case CargoType.LargeCargo:
						stringBuilder.Append("Cargo: Large");
						break;
					case CargoType.MediumCargo:
						stringBuilder.Append("Cargo: Medium");
						break;
					case CargoType.SmallCargo:
						stringBuilder.Append("Cargo: Small");
						break;
					case CargoType.Personnel:
						stringBuilder.Append("Cargo: Personnel");
						break;
					}
				}
				if (loadout.Cargo_ParadropCapable)
				{
					stringBuilder.Append(" &amp; ");
					stringBuilder.Append("Paradop Capable");
				}
				stringBuilder.Append("</td>");
				string text4 = ((loadout.ReadyTime > 0) ? Misc.TimeString(loadout.ReadyTime * 60) : "");
				string text5 = null;
				if (loadout.QuickTurnaround)
				{
					text5 = "Quick turnaround<br/>";
					text5 = text5 + loadout.QuickTurnaround_TimeofDay.ToString() + "<br/>";
					text5 = text5 + "Ready time = " + Misc.TimeString(loadout.QuickTurnaround_ReadyTime * 60) + "<br/>";
					if (loadout.QuickTurnaround_AdditionalTimePenalty != 0)
					{
						text5 = text5 + "Additional time = " + Misc.TimeString(loadout.QuickTurnaround_AdditionalTimePenalty * 60) + "<br/>";
					}
					text5 = text5 + "Max sorties = " + Conversions.ToString(loadout.QuickTurnaround_MaxSorties) + "<br/>";
				}
				if (text5 == null)
				{
					stringBuilder.Append("<td align='center' valign='middle'>" + text4 + "</td>");
				}
				else
				{
					stringBuilder.Append("<td align='center' valign='middle'><div class='tooltip' style=background-color:darkblue;>" + text4 + "<span class='tooltiptext'>" + text5 + "</span></div></td>");
				}
				stringBuilder.Append("<td align='center' valign='middle'>" + Misc.Description(loadout.TimeOfDay) + "<br/>" + Misc.Description(loadout.Weather) + "</td>");
				string text6;
				if (Client.CurrentScenario.FeatureCompatibility.get_WeaponAGL_ASL(Client.CurrentScenario.DBConnection))
				{
					int dBID3 = loadout.DBID;
					Doctrine._WeaponState winchesterShotgun = loadout.WinchesterShotgun;
					sqliteConnection_ = Client.CurrentScenario.DBConnection;
					text6 = DBFunctions.GetLoadoutWeaponStateDescription(dBID3, (int)winchesterShotgun, ref sqliteConnection_, Client.CurrentScenario, DescriptionFromDatabase: false, loadout.Role);
				}
				else
				{
					text6 = "Winchester: Mission-specific weapons have been expended. Disengage immediately.";
				}
				stringBuilder.Append("<td align='center' valign='middle'>" + text6 + "</td>");
				stringBuilder.Append("<td>" + Conversions.ToString(loadout.DBID) + "</td>");
				stringBuilder.Append("</tr>");
			}
			stringBuilder.Append("</table>");
		}
		stringBuilder.Append("</div><br/>");
		stringBuilder.Append("<br/>");
		return stringBuilder.ToString();
	}

	public string DisplaySensors(Sensor theSensor)
	{
		StringBuilder stringBuilder = new StringBuilder();
		Sensor sensor = theSensor;
		List<string> list = new List<string>();
		float myDetectionV = -1f;
		float myClasssificationV = -1f;
		float myDetectionIR = -1f;
		float myClasssificationIR = -1f;
		stringBuilder.Append("<div style='border-bottom: black 1px solid'><span style='font-family: Arial; color: dodgerblue;'><strong>GENERAL DATA</strong></span></div>");
		stringBuilder.Append("<table border='0'><tr style='font-family: Verdana;font-size:10pt;'>");
		SQLiteConnection sqliteConnection_ = Client.CurrentScenario.DBConnection;
		stringBuilder.Append("<td>Category : </td><td>" + DBFunctions.Get_Sensor_Type_String(ref sqliteConnection_, (int)sensor.Type) + "</td>");
		stringBuilder.Append("</table><br/>");
		stringBuilder.Append("<div style='border-bottom: black 1px solid'><span style='color: dodgerblue; font-family: Arial'><strong>SENSORS / EW</strong></span></div>");
		stringBuilder.Append("<table width='100%' align='Center'  cellpadding='2' cellspacing='0' rules='rows' style=' font-size: medium;  font-weight: normal;  text-align: left;   height: 10px; '>");
		stringBuilder.Append("<tr style='font-family:Verdana;font-size:10pt;font-weight:bold;background-color:DimGrey'>");
		stringBuilder.Append("<td align='center'>Min/Max Range</td><td>Role</td><td>Abilities</td><td>Scan Interval</td>");
		stringBuilder.Append("</tr>");
		if (sensor.Type == Sensor.Sensor_Type.SensorGroup)
		{
			SQLiteHelper theHelper = new SQLiteHelper(Client.CurrentScenario.DBConnection);
			string theQuery = "Select ComponentID from DataSensorSensorGroups where ID = " + Conversions.ToString(sensor.DBID);
			DataTable datatable = DBCache.GetDatatable(theHelper, theQuery);
			foreach (DataRow row in datatable.Rows)
			{
				int num = Conversions.ToInteger(row["ComponentID"]);
				sqliteConnection_ = Client.CurrentScenario.DBConnection;
				sensor = DBFunctions.GetSensor(num, ref sqliteConnection_);
				sensor.VisualIRZoom(ref myDetectionV, ref myClasssificationV, ref myDetectionIR, ref myClasssificationIR);
				stringBuilder.Append("<tr Name='Sensor" + Conversions.ToString(sensor.DBID) + "' style='font-family:Verdana;font-size:8pt;'>");
				stringBuilder.Append("<td align='center' valign='top'>");
				if (!(sensor.minRange > 0f) && sensor.maxRange <= 0f)
				{
					stringBuilder.Append("</td>");
				}
				else
				{
					if (sensor.minRange > 0f)
					{
						stringBuilder.Append(Conversions.ToString(sensor.minRange) + " / ");
					}
					else
					{
						stringBuilder.Append("- / ");
					}
					if (sensor.maxRange > 0f)
					{
						stringBuilder.Append(sensor.maxRange);
					}
					else
					{
						stringBuilder.Append("-");
					}
					stringBuilder.Append(" nm</td>");
				}
				stringBuilder.Append("<td valign='top'>" + sensor.RoleDescription + "</td>");
				stringBuilder.Append("<td valign='top'>");
				list.Clear();
				if ((sensor.Type == Sensor.Sensor_Type.Radar || sensor.Type == Sensor.Sensor_Type.ESM || sensor.Type == Sensor.Sensor_Type.ECM || sensor.Type == Sensor.Sensor_Type.Visual || sensor.Type == Sensor.Sensor_Type.Infrared || sensor.Type == Sensor.Sensor_Type.BottomFixedSonar_PassiveOnly || sensor.Type == Sensor.Sensor_Type.DippingSonar_ActiveOnly || sensor.Type == Sensor.Sensor_Type.DippingSonar_ActivePassive || sensor.Type == Sensor.Sensor_Type.DippingSonar_PassiveOnly || sensor.Type == Sensor.Sensor_Type.HullSonar_ActiveOnly || sensor.Type == Sensor.Sensor_Type.HullSonar_ActivePassive || sensor.Type == Sensor.Sensor_Type.HullSonar_PassiveOnly || sensor.Type == Sensor.Sensor_Type.PingIntercept || sensor.Type == Sensor.Sensor_Type.TowedArray_ActiveOnly || sensor.Type == Sensor.Sensor_Type.TowedArray_ActivePassive || sensor.Type == Sensor.Sensor_Type.TowedArray_PassiveOnly || sensor.Type == Sensor.Sensor_Type.VDS_ActiveOnly || sensor.Type == Sensor.Sensor_Type.VDS_ActivePassive || sensor.Type == Sensor.Sensor_Type.VDS_PassiveOnly) && !sensor.IsMk1Eyeball)
				{
					Scenario theScen = Client.CurrentScenario;
					list.Add(DBFunctions.Get_Sensor_Generation_String(ref theScen, (int)sensor.TechGeneration) + " Technology");
				}
				if (sensor.Capabilities.AirSearch)
				{
					list.Add("Air Search");
				}
				if (sensor.Capabilities.SurfaceSearch)
				{
					list.Add("Surface Search");
				}
				if (sensor.Capabilities.SubSearch)
				{
					list.Add("Underwater Search");
				}
				if (sensor.Capabilities.Mine_Obstacle_Search)
				{
					list.Add("Mine & Obstacle Search");
				}
				if (sensor.Capabilities.LandSearch_Fixed)
				{
					list.Add("Ground Search (Fixed)");
				}
				if (sensor.Capabilities.LandSearch_Mobile)
				{
					list.Add("Ground Search (Mobile)");
				}
				if (sensor.Capabilities.GroundMappingOnly)
				{
					list.Add("Ground-mapping only");
				}
				if (sensor.Capabilities.NavigationOnly)
				{
					list.Add("Navigation Only");
				}
				if (sensor.Capabilities.SpaceSearch_ABM)
				{
					list.Add("ABM & Space Search");
				}
				if (sensor.Capabilities.OTH_Backscatter)
				{
					list.Add("OTH (Backscatter)");
				}
				if (sensor.Capabilities.OTH_SurfaceWave)
				{
					list.Add("OTH (Surface Wave)");
				}
				if (sensor.Capabilities.TerrainAvoidanceFollowingOnly)
				{
					list.Add("Terrain Avoidance/Following");
				}
				if (sensor.Capabilities.WeatherAndNavigationOnly)
				{
					list.Add("Weather & Navigation");
				}
				if (sensor.Capabilities.WeatherOnly)
				{
					list.Add("Weather Only");
				}
				if (sensor.Codes.NCTR_JEM)
				{
					list.Add("NCTR - JEM");
				}
				if (sensor.Codes.NCTR_NBILST)
				{
					list.Add("NCTR - NBILST");
				}
				if (sensor.Type == Sensor.Sensor_Type.ESM && sensor.ESM_PreciseEmitterID)
				{
					list.Add("Specific Emitter ID");
				}
				if (sensor.Capabilities.RangeInfo)
				{
					list.Add("Range Information");
				}
				if (sensor.Capabilities.AltitudeInfo)
				{
					list.Add("Altitude Info");
				}
				if (sensor.Capabilities.SpeedInfo)
				{
					list.Add("Speed Information");
				}
				if (sensor.Capabilities.HeadingInfo)
				{
					list.Add("Heading Info");
				}
				stringBuilder.Append(string.Join(", ", list));
				if (sensor.Type == Sensor.Sensor_Type.Radar)
				{
					if (sensor.SearchFreqs.Length > 0)
					{
						stringBuilder.Append("<br/>Operating bands (search & track): ").Append(string.Join(" / ", sensor.SearchFreqs.Select([SpecialName] (Sensor.RadioElectronicFrequency theF) => theF.ToString_Short)));
					}
					if (sensor.IlluminationFreqs.Length > 0)
					{
						stringBuilder.Append("<br/>Operating bands (FC / illumination): ").Append(string.Join(" / ", sensor.IlluminationFreqs.Select([SpecialName] (Sensor.RadioElectronicFrequency theF) => theF.ToString_Short)));
					}
				}
				else if (sensor.Codes.GeneratesAAWFireControl)
				{
					stringBuilder.Append("<br/>Generates AAW fire-control data");
				}
				if ((sensor.IsOECM || sensor.IsDECM || sensor.IsSonar || sensor.Type == Sensor.Sensor_Type.ESM) && sensor.SearchFreqs.Length > 0)
				{
					stringBuilder.Append("<br/>Operating bands: ").Append(string.Join(" / ", sensor.SearchFreqs.Select([SpecialName] (Sensor.RadioElectronicFrequency theF) => theF.ToString_Short)));
				}
				if (sensor.CanPerformIllumination)
				{
					stringBuilder.Append("<br/>Max Target Illumination: ").Append(sensor.MaxIlluminate);
				}
				switch (sensor.Type)
				{
				case Sensor.Sensor_Type.Infrared:
					if (myClasssificationIR >= myDetectionIR)
					{
						stringBuilder.Append("<br/>InfraRed Zoom Detection/Classification: ").AppendFormat("{0}", myClasssificationIR);
					}
					else
					{
						stringBuilder.Append("<br/>InfraRed Zoom Detection/Classification: ").AppendFormat("{0} / {1}", myDetectionIR, myClasssificationIR);
					}
					break;
				case Sensor.Sensor_Type.Visual:
					if (myClasssificationV >= myDetectionV)
					{
						stringBuilder.Append("<br/>Visual Zoom Detection/Classification: ").AppendFormat("{0}", myClasssificationV);
					}
					else
					{
						stringBuilder.Append("<br/>Visual Zoom Detection/Classification: ").AppendFormat("{0} / {1}", myDetectionV, myClasssificationV);
					}
					break;
				}
				stringBuilder.Append("</td>");
				if (sensor.ScanInterval != 0)
				{
					stringBuilder.Append("<td valign='top'>" + Conversions.ToString(sensor.ScanInterval) + "</td>");
				}
				else
				{
					stringBuilder.Append("<td/>");
				}
			}
		}
		else
		{
			sensor.VisualIRZoom(ref myDetectionV, ref myClasssificationV, ref myDetectionIR, ref myClasssificationIR);
			stringBuilder.Append("<tr Name='Sensor" + Conversions.ToString(sensor.DBID) + "' style='font-family:Verdana;font-size:8pt;'>");
			stringBuilder.Append("<td align='center' valign='top'>");
			if (!(sensor.minRange > 0f) && sensor.maxRange <= 0f)
			{
				stringBuilder.Append("</td>");
			}
			else
			{
				if (sensor.minRange > 0f)
				{
					stringBuilder.Append(Conversions.ToString(sensor.minRange) + " / ");
				}
				else
				{
					stringBuilder.Append("- / ");
				}
				if (sensor.maxRange > 0f)
				{
					stringBuilder.Append(sensor.maxRange);
				}
				else
				{
					stringBuilder.Append("-");
				}
				stringBuilder.Append(" nm</td>");
			}
			stringBuilder.Append("<td valign='top'>" + sensor.RoleDescription + "</td>");
			stringBuilder.Append("<td valign='top'>");
			if ((sensor.Type == Sensor.Sensor_Type.Radar || sensor.Type == Sensor.Sensor_Type.ESM || sensor.Type == Sensor.Sensor_Type.ECM || sensor.Type == Sensor.Sensor_Type.Visual || sensor.Type == Sensor.Sensor_Type.Infrared || sensor.Type == Sensor.Sensor_Type.BottomFixedSonar_PassiveOnly || sensor.Type == Sensor.Sensor_Type.DippingSonar_ActiveOnly || sensor.Type == Sensor.Sensor_Type.DippingSonar_ActivePassive || sensor.Type == Sensor.Sensor_Type.DippingSonar_PassiveOnly || sensor.Type == Sensor.Sensor_Type.HullSonar_ActiveOnly || sensor.Type == Sensor.Sensor_Type.HullSonar_ActivePassive || sensor.Type == Sensor.Sensor_Type.HullSonar_PassiveOnly || sensor.Type == Sensor.Sensor_Type.PingIntercept || sensor.Type == Sensor.Sensor_Type.TowedArray_ActiveOnly || sensor.Type == Sensor.Sensor_Type.TowedArray_ActivePassive || sensor.Type == Sensor.Sensor_Type.TowedArray_PassiveOnly || sensor.Type == Sensor.Sensor_Type.VDS_ActiveOnly || sensor.Type == Sensor.Sensor_Type.VDS_ActivePassive || sensor.Type == Sensor.Sensor_Type.VDS_PassiveOnly) && !sensor.IsMk1Eyeball)
			{
				Scenario theScen = Client.CurrentScenario;
				list.Add(DBFunctions.Get_Sensor_Generation_String(ref theScen, (int)sensor.TechGeneration) + " Technology");
			}
			if (sensor.Capabilities.AirSearch)
			{
				list.Add("Air Search");
			}
			if (sensor.Capabilities.SurfaceSearch)
			{
				list.Add("Surface Search");
			}
			if (sensor.Capabilities.SubSearch)
			{
				list.Add("Underwater Search");
			}
			if (sensor.Capabilities.Mine_Obstacle_Search)
			{
				list.Add("Mine & Obstacle Search");
			}
			if (sensor.Capabilities.LandSearch_Fixed)
			{
				list.Add("Ground Search (Fixed)");
			}
			if (sensor.Capabilities.LandSearch_Mobile)
			{
				list.Add("Ground Search (Mobile)");
			}
			if (sensor.Capabilities.GroundMappingOnly)
			{
				list.Add("Ground-mapping only");
			}
			if (sensor.Capabilities.NavigationOnly)
			{
				list.Add("Navigation Only");
			}
			if (sensor.Capabilities.SpaceSearch_ABM)
			{
				list.Add("ABM & Space Search");
			}
			if (sensor.Capabilities.OTH_Backscatter)
			{
				list.Add("OTH (Backscatter)");
			}
			if (sensor.Capabilities.OTH_SurfaceWave)
			{
				list.Add("OTH (Surface Wave)");
			}
			if (sensor.Capabilities.TerrainAvoidanceFollowingOnly)
			{
				list.Add("Terrain Avoidance/Following");
			}
			if (sensor.Capabilities.WeatherAndNavigationOnly)
			{
				list.Add("Weather & Navigation");
			}
			if (sensor.Capabilities.WeatherOnly)
			{
				list.Add("Weather Only");
			}
			if (sensor.Codes.NCTR_JEM)
			{
				list.Add("NCTR - JEM");
			}
			if (sensor.Codes.NCTR_NBILST)
			{
				list.Add("NCTR - NBILST");
			}
			if (sensor.Type == Sensor.Sensor_Type.ESM && sensor.ESM_PreciseEmitterID)
			{
				list.Add("Specific Emitter ID");
			}
			if (sensor.Capabilities.RangeInfo)
			{
				list.Add("Range Information");
			}
			if (sensor.Capabilities.AltitudeInfo)
			{
				list.Add("Altitude Info");
			}
			if (sensor.Capabilities.SpeedInfo)
			{
				list.Add("Speed Information");
			}
			if (sensor.Capabilities.HeadingInfo)
			{
				list.Add("Heading Info");
			}
			stringBuilder.Append(string.Join(", ", list));
			if (sensor.Type == Sensor.Sensor_Type.Radar)
			{
				if (sensor.SearchFreqs.Length > 0)
				{
					stringBuilder.Append("<br/>Operating bands (search & track): ").Append(string.Join(" / ", sensor.SearchFreqs.Select([SpecialName] (Sensor.RadioElectronicFrequency theF) => theF.ToString_Short)));
				}
				if (sensor.IlluminationFreqs.Length > 0)
				{
					stringBuilder.Append("<br/>Operating bands (FC / illumination): ").Append(string.Join(" / ", sensor.IlluminationFreqs.Select([SpecialName] (Sensor.RadioElectronicFrequency theF) => theF.ToString_Short)));
				}
			}
			else if (sensor.Codes.GeneratesAAWFireControl)
			{
				stringBuilder.Append("<br/>Generates AAW fire-control data");
			}
			if ((sensor.IsOECM || sensor.IsDECM || sensor.IsSonar || sensor.Type == Sensor.Sensor_Type.ESM) && sensor.SearchFreqs.Length > 0)
			{
				stringBuilder.Append("<br/>Operating bands: ").Append(string.Join(" / ", sensor.SearchFreqs.Select([SpecialName] (Sensor.RadioElectronicFrequency theF) => theF.ToString_Short)));
			}
			if (sensor.CanPerformIllumination)
			{
				stringBuilder.Append("<br/>Max Target Illumination: ").Append(sensor.MaxIlluminate);
			}
			switch (sensor.Type)
			{
			case Sensor.Sensor_Type.Infrared:
				if (myClasssificationIR >= myDetectionIR)
				{
					stringBuilder.Append("<br/>InfraRed Zoom Detection/Classification: ").AppendFormat("{0}", myClasssificationIR);
				}
				else
				{
					stringBuilder.Append("<br/>InfraRed Zoom Detection/Classification: ").AppendFormat("{0} / {1}", myDetectionIR, myClasssificationIR);
				}
				break;
			case Sensor.Sensor_Type.Visual:
				if (myClasssificationV >= myDetectionV)
				{
					stringBuilder.Append("<br/>Visual Zoom Detection/Classification: ").AppendFormat("{0}", myClasssificationV);
				}
				else
				{
					stringBuilder.Append("<br/>Visual Zoom Detection/Classification: ").AppendFormat("{0} / {1}", myDetectionV, myClasssificationV);
				}
				break;
			}
			stringBuilder.Append("</td>");
			if (sensor.ScanInterval != 0)
			{
				stringBuilder.Append("<td valign='top'>" + Conversions.ToString(sensor.ScanInterval) + "</td>");
			}
			else
			{
				stringBuilder.Append("<td/>");
			}
		}
		stringBuilder.Append("</tr>");
		stringBuilder.Append("</table>");
		stringBuilder.Append("<br/>");
		return stringBuilder.ToString();
	}

	private string method_11(ref Aircraft aircraft_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (aircraft_0.XSections_ReadOnly.Count() > 0)
		{
			stringBuilder.Append("<table width='100%' align='Center'  cellpadding='2' cellspacing='0' rules='rows' style=' font-size: medium;  font-weight: normal;  text-align: left;   height: 10px; '>");
			stringBuilder.Append("<tr style='font-family:Verdana;font-size:10pt;font-weight:bold;background-color:DimGrey'>");
			stringBuilder.Append("<td>Type</td><td align='center'>Front</td><td align='center'>Side</td><td align='center'>Rear</td>");
			stringBuilder.Append("</tr>");
		}
		XSection[] xSections_ReadOnly = aircraft_0.XSections_ReadOnly;
		foreach (XSection xSection in xSections_ReadOnly)
		{
			if ((xSection.get_Front((ActiveUnit)aircraft_0) == 0f && xSection.get_Side((ActiveUnit)aircraft_0) == 0f && xSection.get_Rear((ActiveUnit)aircraft_0) == 0f) || xSection.get_Front((ActiveUnit)aircraft_0) == -10000f || xSection.get_Side((ActiveUnit)aircraft_0) == -10000f || xSection.get_Rear((ActiveUnit)aircraft_0) == -10000f || (xSection.SignatureType != XSection._SignatureType.Radar_A_D && xSection.SignatureType != XSection._SignatureType.Radar_E_M))
			{
				continue;
			}
			(float, float, float, float) value = default((float, float, float, float));
			BaseSignatures.TryGetValue(xSection.SignatureType, out value);
			(float, float, float, float) tuple = ((float)Math.Round(xSection.get_Front((ActiveUnit)aircraft_0), 2), (float)Math.Round(xSection.get_Side((ActiveUnit)aircraft_0), 2), (float)Math.Round(xSection.get_Rear((ActiveUnit)aircraft_0), 2), (float)Math.Round(xSection.get_Top((ActiveUnit)aircraft_0), 2));
			string text = "";
			if (tuple.Equals(value))
			{
				text = "background-color:DarkGreen;";
			}
			stringBuilder.Append("<tr style='" + text + "font-family: Verdana;font-size:8pt;'>");
			stringBuilder.Append("<td>" + DBFunctions.Description(xSection.SignatureType, Client.CurrentScenario) + "</td>");
			double num = Math.Pow(10.0, tuple.Item1 / 10f);
			double num2 = Math.Pow(10.0, tuple.Item2 / 10f);
			double num3 = Math.Pow(10.0, tuple.Item3 / 10f);
			string text2;
			string text3;
			string text4;
			if (!(num < 1.0 && num >= 0.1))
			{
				if (num < 0.1 && num >= 0.01)
				{
					text2 = " dBsm, " + $"{num:0.000}" + " sq.m.";
					text3 = " dBsm, " + $"{num2:0.000}" + " sq.m.";
					text4 = " dBsm, " + $"{num3:0.000}" + " sq.m.";
				}
				else if (!(num < 0.01 && num >= 0.001))
				{
					if (!(num < 0.001 && num >= 0.0001))
					{
						if (!(num < 0.0001 && num >= 1E-05))
						{
							text2 = " dBsm, " + $"{num:0.0}" + " sq.m.";
							text3 = " dBsm, " + $"{num2:0.0}" + " sq.m.";
							text4 = " dBsm, " + $"{num3:0.0}" + " sq.m.";
						}
						else
						{
							text2 = " dBsm, " + $"{num:0.000000}" + " sq.m.";
							text3 = " dBsm, " + $"{num2:0.000000}" + " sq.m.";
							text4 = " dBsm, " + $"{num3:0.000000}" + " sq.m.";
						}
					}
					else
					{
						text2 = " dBsm, " + $"{num:0.00000}" + " sq.m.";
						text3 = " dBsm, " + $"{num2:0.00000}" + " sq.m.";
						text4 = " dBsm, " + $"{num3:0.00000}" + " sq.m.";
					}
				}
				else
				{
					text2 = " dBsm, " + $"{num:0.0000}" + " sq.m.";
					text3 = " dBsm, " + $"{num2:0.0000}" + " sq.m.";
					text4 = " dBsm, " + $"{num3:0.0000}" + " sq.m.";
				}
			}
			else
			{
				text2 = " dBsm, " + $"{num:0.00}" + " sq.m.";
				text3 = " dBsm, " + $"{num2:0.00}" + " sq.m.";
				text4 = " dBsm, " + $"{num3:0.00}" + " sq.m.";
			}
			stringBuilder.Append("<td align='center'>" + $"{tuple.Item1:0.00}" + text2 + "</td>");
			stringBuilder.Append("<td align='center'>" + $"{tuple.Item2:0.00}" + text3 + "</td>");
			stringBuilder.Append("<td align='center'>" + $"{tuple.Item3:0.00}" + text4 + "</td>");
			stringBuilder.Append("</tr>");
		}
		stringBuilder.Append("</table>");
		return stringBuilder.ToString();
	}

	public string DisplayMags(ActiveUnit AU)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (AU.SharedMagazines.Length > 0)
		{
			stringBuilder.Append("<span style='text-align: left; font-family: Arial; font-size: small; font-weight: bold;'>Magazines</span>");
			stringBuilder.Append("<table width='100%' align='Center'  cellpadding='2' cellspacing='0' rules='rows' style=' font-size: medium;  font-weight: normal;  text-align: left;   height: 10px; '>");
			stringBuilder.Append("<tr style='font-family:Verdana;font-size:10pt;font-weight:bold;background-color:DimGrey'>");
			stringBuilder.Append("<td>Magazine</td><td align='center'>Capacity</td><td align='center'>Reload Rate</td><td align='center'>Armor</td><td>Stores</td>");
			stringBuilder.Append("</tr>");
			Magazine[] sharedMagazines = AU.SharedMagazines;
			foreach (Magazine magazine in sharedMagazines)
			{
				stringBuilder.Append("<tr style=';font-family:Verdana;font-size:8pt;'>");
				stringBuilder.Append("<td valign='top'>" + magazine.Name + "</td>");
				stringBuilder.Append("<td align='center' valign='top'>" + Conversions.ToString(magazine.Capacity) + "</td>");
				stringBuilder.Append("<td align='center' valign='top'>" + Conversions.ToString(magazine.ROF) + "</td>");
				stringBuilder.Append("<td align='center' valign='top'>" + magazine.Armor.ToString() + "</td>");
				stringBuilder.Append("<td valign='top'>" + string.Join("<br/>", magazine.Weapons.Select((_Closure$__.$I147-0 == null) ? (_Closure$__.$I147-0 = [SpecialName] (WeaponRec theWR) => ((theWR.CurrentLoad != 0) ? "" : "<i style='color:gray'>") + Conversions.ToString(theWR.CurrentLoad) + " x " + theWR.get_ReferenceWeapon(Client.CurrentScenario).Name + " (max " + Conversions.ToString(theWR.MaxLoad) + ")" + ((theWR.CurrentLoad != 0) ? "" : "</i>")) : _Closure$__.$I147-0).ToArray()) + "</td>");
				stringBuilder.Append("</tr>");
			}
			stringBuilder.Append("</table>");
			stringBuilder.Append("<br/>");
		}
		return stringBuilder.ToString();
	}

	public string DisplayComms(ActiveUnit AU)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (AU.Comms_ReadOnly.Count() > 0)
		{
			stringBuilder.Append("<div style='border-bottom: black 1px solid'><span style='color: dodgerblue; font-family: Arial'><strong>COMMS / DATALINKS</strong></span></div>");
			stringBuilder.Append("<table width='100%' align='Center'  cellpadding='2' cellspacing='0' rules='rows' style=' font-size: medium;  font-weight: normal;  text-align: left;   height: 10px; '>");
			stringBuilder.Append("<tr style='font-family:Verdana;font-size:10pt;font-weight:bold;background-color:DimGrey'>");
			stringBuilder.Append("<td>Name</td><td align='center'>Type</td><td align='center'>Max Range</td><td align='center'>Channels</td><td>Properties</td>");
			stringBuilder.Append("</tr>");
			IEnumerable<IGrouping<int, CommDevice>> enumerable = from theC in AU.Comms_ReadOnly
				group theC by theC.DBID;
			foreach (IGrouping<int, CommDevice> item in enumerable)
			{
				CommDevice commDevice = item.ElementAtOrDefault(0);
				stringBuilder.Append("<tr style=';font-family:Verdana;font-size:8pt;'>");
				stringBuilder.Append("<td>" + commDevice.Name + "</td>");
				stringBuilder.Append("<td align='center'>" + DBFunctions.Description(commDevice.Type, Client.CurrentScenario) + "</td>");
				if (commDevice.Range > 0f)
				{
					stringBuilder.Append("<td align='center'>" + Conversions.ToString(commDevice.Range) + " nm</td>");
				}
				else
				{
					stringBuilder.Append("<td align='center'>-</td>");
				}
				if (commDevice.MaxChannels > 0)
				{
					stringBuilder.Append("<td align='center'>" + Conversions.ToString(commDevice.MaxChannels) + "</td>");
				}
				else
				{
					stringBuilder.Append("<td align='center'>-</td>");
				}
				stringBuilder.Append("<td>");
				List<string> list = new List<string>();
				if (!commDevice.ParentSpecific)
				{
					list.Add("Supports CEC");
				}
				if (commDevice.Flags.Broadcast)
				{
					list.Add("Broadcast");
				}
				if (commDevice.Flags.ELF_Radio)
				{
					list.Add("ELF Radio");
				}
				if (commDevice.Flags.HF_Radio)
				{
					list.Add("HF Radio");
				}
				if (commDevice.Flags.LF_Radio)
				{
					list.Add("LF Radio");
				}
				if (commDevice.Flags.LOS_Limited)
				{
					list.Add("LOS-limited");
				}
				if (commDevice.Flags.MF_Radio)
				{
					list.Add("MF Radio");
				}
				if (commDevice.IsReceiveOnly())
				{
					list.Add("Receive-only");
				}
				if (commDevice.Flags.Secure)
				{
					list.Add("Secure");
				}
				if (commDevice.IsSendOnly())
				{
					list.Add("Send-only");
				}
				if (commDevice.Flags.SHF_Radio)
				{
					list.Add("SHF Radio");
				}
				if (commDevice.Flags.UHF_Radio)
				{
					list.Add("UHF Radio");
				}
				if (commDevice.Flags.VHF_Radio)
				{
					list.Add("VHF Radio");
				}
				if (commDevice.Flags.VLF_Radio)
				{
					list.Add("VLF Radio");
				}
				if (commDevice.Flags.DegradesWithRange)
				{
					list.Add("Degrades With Range (Analog)");
				}
				if (commDevice.Flags.Acoustic_0_1kHz)
				{
					list.Add("Acoustic (0-1 kHz)");
				}
				if (commDevice.Flags.Acoustic_1_10kHz)
				{
					list.Add("Acoustic (1-10 kHz)");
				}
				if (commDevice.Flags.Acoustic_10_100kHz)
				{
					list.Add("Acoustic (10-100 kHz)");
				}
				stringBuilder.Append(string.Join(", ", list) + "</td>");
				stringBuilder.Append("</tr>");
			}
			stringBuilder.Append("</table>");
			stringBuilder.Append("<br/>");
		}
		return stringBuilder.ToString();
	}

	public string DisplayAirFacilities(ActiveUnit AU)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (AU.AirFacilities_ReadOnly.Length > 0)
		{
			stringBuilder.Append("<div style='border-bottom: black 1px solid'><span style='color: dodgerblue; font-family: Arial'><strong>AIRCRAFT FACILITIES</strong></span></div>");
			stringBuilder.Append("<table width='100%' align='Center'  cellpadding='2' cellspacing='0' rules='rows' style=' font-size: medium;  font-weight: normal;  text-align: left;   height: 10px; '>");
			stringBuilder.Append("<tr style='font-family:Verdana;font-size:10pt;font-weight:bold;background-color:DimGrey'>");
			stringBuilder.Append("<td>Type</td>");
			stringBuilder.Append("</tr>");
			IEnumerable<IGrouping<int, AirFacility>> enumerable = from theAF in AU.AirFacilities_ReadOnly
				group theAF by theAF.DBID;
			foreach (IGrouping<int, AirFacility> item in enumerable)
			{
				AirFacility airFacility = item.ElementAtOrDefault(0);
				stringBuilder.Append("<tr style=';font-family:Verdana;font-size:8pt;'>");
				stringBuilder.Append("<td>" + Conversions.ToString(item.Count()) + "x " + airFacility.Name + "</td>");
				stringBuilder.Append("</tr>");
			}
			stringBuilder.Append("</table>");
			stringBuilder.Append("<br/>");
		}
		return stringBuilder.ToString();
	}

	public string DisplayDockingFacilities(ActiveUnit AU)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (AU.DockFacilities_ReadOnly.Length > 0)
		{
			stringBuilder.Append("<div style='border-bottom: black 1px solid'><span style='color: dodgerblue; font-family: Arial'><strong>DOCKING FACILITIES</strong></span></div>");
			stringBuilder.Append("<table width='100%' align='Center'  cellpadding='2' cellspacing='0' rules='rows' style=' font-size: medium;  font-weight: normal;  text-align: left;   height: 10px; '>");
			stringBuilder.Append("<tr style='font-family:Verdana;font-size:10pt;font-weight:bold;background-color:DimGrey'>");
			stringBuilder.Append("<td>Type</td>");
			stringBuilder.Append("</tr>");
			IEnumerable<IGrouping<int, DockFacility>> enumerable = from theAF in AU.DockFacilities_ReadOnly
				group theAF by theAF.DBID;
			foreach (IGrouping<int, DockFacility> item in enumerable)
			{
				DockFacility dockFacility = item.ElementAtOrDefault(0);
				stringBuilder.Append("<tr style=';font-family:Verdana;font-size:8pt;'>");
				stringBuilder.Append("<td>" + Conversions.ToString(item.Count()) + "x " + dockFacility.Name + "</td>");
				stringBuilder.Append("</tr>");
			}
			stringBuilder.Append("</table>");
			stringBuilder.Append("<br/>");
		}
		return stringBuilder.ToString();
	}

	public string DisplayValidTargets(Weapon theW)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (theW.Type != Weapon._WeaponType.BuddyStore && theW.Type != Weapon._WeaponType.Cargo && theW.Type != Weapon._WeaponType.DropTank && theW.Type != Weapon._WeaponType.FerryTank && theW.Type != Weapon._WeaponType.HeliTowedPackage && theW.Type != Weapon._WeaponType.None && theW.Type != Weapon._WeaponType.Paratroops && theW.Type != Weapon._WeaponType.SensorPod && theW.Type != Weapon._WeaponType.TrainingRound && theW.Type != Weapon._WeaponType.Troops && theW.Type != Weapon._WeaponType.Sonobuoy)
		{
			List<string> validTargets_Description = theW.ValidTargets_Description;
			string value = ((validTargets_Description.Count > 0) ? string.Join("<br/>", validTargets_Description) : "");
			if (validTargets_Description.Count >= 1)
			{
				stringBuilder.Append("<div style='border-bottom: black 1px solid'><span style='color: dodgerblue; font-family: Arial'><strong>VALID TARGETS</strong></span></div>");
				stringBuilder.Append("<div style='color:Black;font-family:Verdana;font-size:8pt;'>");
				stringBuilder.Append("<table width='100%' align='Center'  cellpadding='2' cellspacing='0' rules='rows' style=' font-size: medium;  font-weight: normal;  text-align: left;   height: 10px; '>");
				stringBuilder.Append("<tr style=';font-family:Verdana;font-size:8pt;'>");
				stringBuilder.Append("<td>");
				stringBuilder.Append(value);
				stringBuilder.Append("</td>");
				stringBuilder.Append("</tr>");
				stringBuilder.Append("</table>");
				stringBuilder.Append("</div>");
				stringBuilder.Append("<br/>");
				return stringBuilder.ToString();
			}
			return stringBuilder.ToString();
		}
		return stringBuilder.ToString();
	}

	public string method_12(Weapon theW)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (theW.Doctrine.WRA != null && theW.Doctrine.WRA.Count != 0)
		{
			string[] restrictionValues = new string[4] { null, null, "EnumWeaponWRA", null };
			if (theW.ParentScen.DBConnection.GetSchema("Tables", restrictionValues).Rows.Count == 0)
			{
				return stringBuilder.ToString();
			}
			stringBuilder.Append("<div style='border-bottom: black 1px solid'><span style='color: dodgerblue; font-family: Arial'><strong>WEAPON RELEASE AUTHORIZATION (WRA) [DEFAULT]</strong></span></div>");
			stringBuilder.Append("<div style='color:Black;font-family:Verdana;font-size:8pt;'>");
			stringBuilder.Append("<table width='100%' align='Center'  cellpadding='2' cellspacing='0' rules='rows' style=' font-size: medium;  font-weight: normal;  text-align: left;   height: 10px; '>");
			stringBuilder.Append("<tr style='font-family:Verdana;font-size:10pt;font-weight:bold;background-color:DimGrey'>");
			stringBuilder.Append("<td>Target type</td><td align='left'>Number of weapons per salvo</td><td align='left'>Maximum number of shooters per salvo</td><td align='left'>Self-defence range</td>");
			stringBuilder.Append("</tr>");
			foreach (KeyValuePair<int, Doctrine.WRA_Weapon> item in theW.Doctrine.WRA)
			{
				foreach (Doctrine.WRA_FiringDoctrineEntry value in item.Value.WRA_WeaponTargets.Values)
				{
					int? weaponQty = value.WeaponQty;
					if ((weaponQty.HasValue ? new bool?(weaponQty.GetValueOrDefault() == 0) : ((bool?)null)) != true)
					{
						stringBuilder.Append("<tr style=';font-family:Verdana;font-size:8pt;'>");
						stringBuilder.Append("<td>");
						stringBuilder.Append(Doctrine.WRA_TargetType_String(null, value.TargetType, EmitterClassifiable: false));
						stringBuilder.Append("</td>");
						stringBuilder.Append("<td>");
						Scenario theScen = Client.CurrentScenario;
						stringBuilder.Append(DBFunctions.Get_WRA_WeaponTargetType_WeaponQty_String(ref theScen, value.WeaponQty.Value));
						stringBuilder.Append("</td>");
						stringBuilder.Append("<td>");
						theScen = Client.CurrentScenario;
						stringBuilder.Append(DBFunctions.Get_WRA_WeaponTargetType_ShooterQty_String(ref theScen, value.ShooterQty.Value));
						stringBuilder.Append("</td>");
						stringBuilder.Append("<td>");
						theScen = Client.CurrentScenario;
						stringBuilder.Append(DBFunctions.Get_WRA_WeaponTargetType_SelfDefenceRange_String(ref theScen, (int)Math.Round(value.SelfDefenceRange.Value)));
						stringBuilder.Append("</td>");
						stringBuilder.Append("</tr>");
					}
				}
			}
			stringBuilder.Append("</table>");
			stringBuilder.Append("</div>");
			stringBuilder.Append("<br/>");
			return stringBuilder.ToString();
		}
		return stringBuilder.ToString();
	}

	public string DisplaySignatures(ActiveUnit AU)
	{
		StringBuilder stringBuilder = new StringBuilder();
		BaseSignatures.Clear();
		if (AU.IsWeapon)
		{
			switch (((Weapon)AU).Type)
			{
			case Weapon._WeaponType.None:
			case Weapon._WeaponType.Rocket:
			case Weapon._WeaponType.IronBomb:
			case Weapon._WeaponType.Gun:
			case Weapon._WeaponType.TrainingRound:
			case Weapon._WeaponType.Dispenser:
			case Weapon._WeaponType.SensorPod:
			case Weapon._WeaponType.DropTank:
			case Weapon._WeaponType.BuddyStore:
			case Weapon._WeaponType.FerryTank:
			case Weapon._WeaponType.DepthCharge:
			case Weapon._WeaponType.Sonobuoy:
			case Weapon._WeaponType.HeliTowedPackage:
			case Weapon._WeaponType.Laser:
			case Weapon._WeaponType.Microwave:
			case Weapon._WeaponType.LaserDazzler:
			case Weapon._WeaponType.Cargo:
			case Weapon._WeaponType.Troops:
			case Weapon._WeaponType.Paratroops:
				return stringBuilder.ToString();
			}
		}
		if (AU.IsAircraft && ((Aircraft)AU).Loadout != null)
		{
			((Aircraft)AU).Loadout = null;
		}
		if (AU.XSections_ReadOnly.Count() > 0)
		{
			stringBuilder.Append("<div style='border-bottom: black 1px solid'><span style='color: dodgerblue; font-family: Arial'><strong>SIGNATURES</strong></span></div>");
			stringBuilder.Append("<table width='100%' align='Center'  cellpadding='2' cellspacing='0' rules='rows' style=' font-size: medium;  font-weight: normal;  text-align: left;   height: 10px; '>");
			stringBuilder.Append("<tr style='font-family:Verdana;font-size:10pt;font-weight:bold;background-color:DimGrey'>");
			stringBuilder.Append("<td>Signature Type</td><td align='center'>Front</td><td align='center'>Side</td><td align='center'>Rear</td>");
			stringBuilder.Append("</tr>");
		}
		XSection[] xSections_ReadOnly = AU.XSections_ReadOnly;
		foreach (XSection xSection in xSections_ReadOnly)
		{
			(double, double, double, double) tuple = (Math.Round(xSection.get_Front(AU), 2), Math.Round(xSection.get_Side(AU), 2), Math.Round(xSection.get_Rear(AU), 2), Math.Round(xSection.get_Top(AU), 2));
			Dictionary<XSection._SignatureType, (float, float, float, float)> baseSignatures = BaseSignatures;
			XSection._SignatureType signatureType = xSection.SignatureType;
			(double, double, double, double) tuple2 = tuple;
			baseSignatures.Add(signatureType, ((float)tuple2.Item1, (float)tuple2.Item2, (float)tuple2.Item3, (float)tuple2.Item4));
			if ((xSection.get_Front(AU) == 0f && xSection.get_Side(AU) == 0f && xSection.get_Rear(AU) == 0f) || xSection.get_Front(AU) == -10000f || xSection.get_Side(AU) == -10000f || xSection.get_Rear(AU) == -10000f)
			{
				continue;
			}
			stringBuilder.Append("<tr style=';font-family:Verdana;font-size:8pt;'>");
			stringBuilder.Append("<td>" + DBFunctions.Description(xSection.SignatureType, Client.CurrentScenario) + "</td>");
			string text;
			string text2;
			string text3;
			if (xSection.SignatureType != XSection._SignatureType.HullSonar_PassiveOnly_VLF && xSection.SignatureType != XSection._SignatureType.HullSonar_PassiveOnly_LF && xSection.SignatureType != XSection._SignatureType.HullSonar_PassiveOnly_MF && xSection.SignatureType != XSection._SignatureType.HullSonar_PassiveOnly_HF && xSection.SignatureType != XSection._SignatureType.ActiveSonar)
			{
				if (xSection.SignatureType != XSection._SignatureType.Visual_Detect && xSection.SignatureType != XSection._SignatureType.Visual_ID && xSection.SignatureType != XSection._SignatureType.IR_Detect && xSection.SignatureType != XSection._SignatureType.IR_ID)
				{
					if (xSection.SignatureType != XSection._SignatureType.Radar_A_D && xSection.SignatureType != XSection._SignatureType.Radar_E_M)
					{
						text = "";
						text2 = "";
						text3 = "";
					}
					else
					{
						double num = Math.Pow(10.0, xSection.get_Front(AU) / 10f);
						if (!(num < 1.0 && num >= 0.1))
						{
							if (!(num < 0.1 && num >= 0.01))
							{
								if (num < 0.01 && num >= 0.001)
								{
									text = " dBsm, " + $"{Math.Pow(10.0, xSection.get_Front(AU) / 10f):0.0000}" + " sq.m.";
									text2 = " dBsm, " + $"{Math.Pow(10.0, xSection.get_Side(AU) / 10f):0.0000}" + " sq.m.";
									text3 = " dBsm, " + $"{Math.Pow(10.0, xSection.get_Rear(AU) / 10f):0.0000}" + " sq.m.";
								}
								else if (!(num < 0.001 && num >= 0.0001))
								{
									if (!(num < 0.0001 && num >= 1E-05))
									{
										text = " dBsm, " + $"{Math.Pow(10.0, xSection.get_Front(AU) / 10f):0.0}" + " sq.m.";
										text2 = " dBsm, " + $"{Math.Pow(10.0, xSection.get_Side(AU) / 10f):0.0}" + " sq.m.";
										text3 = " dBsm, " + $"{Math.Pow(10.0, xSection.get_Rear(AU) / 10f):0.0}" + " sq.m.";
									}
									else
									{
										text = " dBsm, " + $"{Math.Pow(10.0, xSection.get_Front(AU) / 10f):0.000000}" + " sq.m.";
										text2 = " dBsm, " + $"{Math.Pow(10.0, xSection.get_Side(AU) / 10f):0.000000}" + " sq.m.";
										text3 = " dBsm, " + $"{Math.Pow(10.0, xSection.get_Rear(AU) / 10f):0.000000}" + " sq.m.";
									}
								}
								else
								{
									text = " dBsm, " + $"{Math.Pow(10.0, xSection.get_Front(AU) / 10f):0.00000}" + " sq.m.";
									text2 = " dBsm, " + $"{Math.Pow(10.0, xSection.get_Side(AU) / 10f):0.00000}" + " sq.m.";
									text3 = " dBsm, " + $"{Math.Pow(10.0, xSection.get_Rear(AU) / 10f):0.00000}" + " sq.m.";
								}
							}
							else
							{
								text = " dBsm, " + $"{Math.Pow(10.0, xSection.get_Front(AU) / 10f):0.000}" + " sq.m.";
								text2 = " dBsm, " + $"{Math.Pow(10.0, xSection.get_Side(AU) / 10f):0.000}" + " sq.m.";
								text3 = " dBsm, " + $"{Math.Pow(10.0, xSection.get_Rear(AU) / 10f):0.000}" + " sq.m.";
							}
						}
						else
						{
							text = " dBsm, " + $"{Math.Pow(10.0, xSection.get_Front(AU) / 10f):0.00}" + " sq.m.";
							text2 = " dBsm, " + $"{Math.Pow(10.0, xSection.get_Side(AU) / 10f):0.00}" + " sq.m.";
							text3 = " dBsm, " + $"{Math.Pow(10.0, xSection.get_Rear(AU) / 10f):0.00}" + " sq.m.";
						}
					}
				}
				else
				{
					text = " nm";
					text2 = " nm";
					text3 = " nm";
				}
			}
			else
			{
				text = " dB";
				text2 = " dB";
				text3 = " dB";
			}
			stringBuilder.Append("<td align='center'>" + $"{xSection.get_Front(AU):0.00}" + text + "</td>");
			stringBuilder.Append("<td align='center'>" + $"{xSection.get_Side(AU):0.00}" + text2 + "</td>");
			stringBuilder.Append("<td align='center'>" + $"{xSection.get_Rear(AU):0.00}" + text3 + "</td>");
			stringBuilder.Append("</tr>");
		}
		stringBuilder.Append("</table>");
		stringBuilder.Append("<br/>");
		if (AU.IsAircraft)
		{
			stringBuilder.Append(DisplaySignatureLoadouts(AU));
			((Aircraft)AU).Loadout = null;
		}
		return stringBuilder.ToString();
	}

	public string DisplaySignatureLoadouts(ActiveUnit AU)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (AU.IsWeapon && (((Weapon)AU).Type == Weapon._WeaponType.BuddyStore || ((Weapon)AU).Type == Weapon._WeaponType.Cargo || ((Weapon)AU).Type == Weapon._WeaponType.Dispenser || ((Weapon)AU).Type == Weapon._WeaponType.DropTank || ((Weapon)AU).Type == Weapon._WeaponType.FerryTank || ((Weapon)AU).Type == Weapon._WeaponType.Gun || ((Weapon)AU).Type == Weapon._WeaponType.HeliTowedPackage || ((Weapon)AU).Type == Weapon._WeaponType.IronBomb || ((Weapon)AU).Type == Weapon._WeaponType.Laser || ((Weapon)AU).Type == Weapon._WeaponType.None || ((Weapon)AU).Type == Weapon._WeaponType.Paratroops || ((Weapon)AU).Type == Weapon._WeaponType.Rocket || ((Weapon)AU).Type == Weapon._WeaponType.SensorPod || ((Weapon)AU).Type == Weapon._WeaponType.TrainingRound || ((Weapon)AU).Type == Weapon._WeaponType.Troops || ((Weapon)AU).Type == Weapon._WeaponType.DepthCharge || ((Weapon)AU).Type == Weapon._WeaponType.Sonobuoy))
		{
			return stringBuilder.ToString();
		}
		int dBID = AU.DBID;
		SQLiteConnection sqliteConnection_ = Client.CurrentScenario.DBConnection;
		Scenario currentScenario = Client.CurrentScenario;
		bool UnlimitedAirWeapons = false;
		Scenario CurrentScenario = null;
		Aircraft SelectedAircraft = null;
		int num = 0;
		bool ExcludeOptionalWeapons = false;
		DataTable dataTable = DBFunctions.LoadoutsForThisAircraft_DT(dBID, null, ref sqliteConnection_, currentScenario, ref UnlimitedAirWeapons, ref CurrentScenario, ref SelectedAircraft, ref num, ref ExcludeOptionalWeapons);
		if (dataTable.Rows.Count > 0)
		{
			stringBuilder.Append("<button type='button' class='collapsible' style='text-align: left; font-family: Arial; font-size: small; font-weight: bold;'>- By Aircraft Loadout</button>");
			stringBuilder.Append("<div style='display: block'>");
			stringBuilder.Append("<table width='100%' align='Center'  cellpadding='2' cellspacing='0' rules='rows' style=' font-size: medium;  font-weight: normal;  text-align: left;   height: 10px; '>");
			stringBuilder.Append("<tr style='font-family:Verdana;font-size:10pt;font-weight:bold;background-color:DimGrey'>");
			stringBuilder.Append("<td>Name</td><td>Stores</td><td align='center'>Signatures</td><td>DB ID#</td></td>");
			stringBuilder.Append("</tr>");
			foreach (DataRow row in dataTable.Rows)
			{
				stringBuilder.Append("<tr style=';font-family:Verdana;font-size:8pt;'>");
				SelectedAircraft = (Aircraft)AU;
				DBFunctions.GetLoadout(ref SelectedAircraft, Conversions.ToInteger(row["ID"]), ExcludeOptionalWeapons: false);
				AU = SelectedAircraft;
				Loadout loadout = ((Aircraft)AU).Loadout;
				if (loadout != null && loadout.Role != Loadout.LoadoutRole.Reserve && loadout.Role != Loadout.LoadoutRole.Unavailable && loadout.Role != Loadout.LoadoutRole.PackedForCargo)
				{
					stringBuilder.Append("<td valign='middle'>" + loadout.Name);
					stringBuilder.Append("<br>(" + Misc.Description(loadout.Role, Client.CurrentScenario.DBConnection) + ")");
					stringBuilder.Append("</td>");
					stringBuilder.Append("<td valign='middle'>");
					WeaponRec[] weapons = loadout.Weapons;
					foreach (WeaponRec weaponRec in weapons)
					{
						stringBuilder.Append(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)(Conversions.ToString(weaponRec.CurrentLoad) + "x <a href="), (object)string_1), (object)"Weapon_"), (object)weaponRec.get_ReferenceWeapon(Client.CurrentScenario).DBID), (object)">"), (object)weaponRec.get_ReferenceWeapon(Client.CurrentScenario).Name), (object)"</a><br/>"));
					}
					SelectedAircraft = (Aircraft)AU;
					string text = method_11(ref SelectedAircraft);
					AU = SelectedAircraft;
					stringBuilder.Append("<td align='center' valign='middle'>" + text + "</td>");
					stringBuilder.Append("<td>" + Conversions.ToString(loadout.DBID) + "</td>");
					stringBuilder.Append("</tr>");
				}
			}
			stringBuilder.Append("</table>");
		}
		stringBuilder.Append("</div><br/>");
		stringBuilder.Append("<br/>");
		return stringBuilder.ToString();
	}

	public string DisplayFlags(ActiveUnit AU)
	{
		StringBuilder stringBuilder = new StringBuilder();
		List<string> list = new List<string>();
		list = DBFunctions.GetUnitFlagDescriptions(AU.UnitType, AU.DBID, Client.CurrentScenario.DBConnection);
		if (AU.IsWeapon && ((Weapon)AU).IsABMCapable())
		{
			list.Add("ABM Capable");
		}
		if (AU.IsWeapon && ((Weapon)AU).SupportsWaypoints)
		{
			list.Add("Supports WayPoints");
		}
		if (list.Count > 0)
		{
			stringBuilder.Append("<div style='border-bottom: black 1px solid'><span style='color: dodgerblue; font-family: Arial'><strong>PROPERTIES</strong></span></div>");
			stringBuilder.Append("<div style='color:Black;font-family:Verdana;font-size:8pt;'>");
			stringBuilder.Append("<table width='100%' align='Center'  cellpadding='2' cellspacing='0' rules='rows' style=' font-size: medium;  font-weight: normal;  text-align: left;   height: 10px; '>");
			stringBuilder.Append("<tr style=';font-family:Verdana;font-size:8pt;'>");
			stringBuilder.Append("<td>");
			stringBuilder.Append(string.Join("<br/>", list));
			stringBuilder.Append("</td>");
			stringBuilder.Append("</tr>");
			stringBuilder.Append("</table>");
			stringBuilder.Append("</div>");
			stringBuilder.Append("<br/>");
		}
		return stringBuilder.ToString();
	}

	public string DisplayWarheads(Weapon theW)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (theW.Warheads.Length > 0)
		{
			StringBuilder stringBuilder2 = new StringBuilder();
			IEnumerable<IGrouping<string, Warhead>> enumerable = from theWH in theW.Warheads
				group theWH by theWH.Name;
			new List<string>();
			bool flag = false;
			bool flag2 = false;
			foreach (IGrouping<string, Warhead> item in enumerable)
			{
				string text = "";
				if (item.Count() > 1)
				{
					text = Conversions.ToString(item.Count()) + "x ";
				}
				Warhead warhead = item.ElementAtOrDefault(0);
				string text2;
				string text3;
				if (warhead.get_IsNuclear(Client.CurrentScenario) & (warhead.Type != Warhead.WarheadType.Weapon))
				{
					if (warhead.DP >= 1E+09f)
					{
						text2 = Conversions.ToString(Math.Round(warhead.DP / 1E+09f, 1));
						text3 = " mT";
					}
					else
					{
						text2 = Conversions.ToString(Math.Round(warhead.DP / 1000000f, 1));
						text3 = " kT";
					}
				}
				else if (warhead.ExplosivesType == Warhead.WarheadExplosivesType.WeaponPayload)
				{
					text2 = Convert.ToString(warhead.DP);
					text3 = warhead.Type switch
					{
						Warhead.WarheadType.Weapon => "Weapon", 
						Warhead.WarheadType.Aircraft => "Aircraft", 
						Warhead.WarheadType.Ship => "Ship", 
						Warhead.WarheadType.Submarine => "Submarine", 
						Warhead.WarheadType.GroundUnit => "GroundUnit", 
						Warhead.WarheadType.Satellite => "Satellite", 
						_ => " " + warhead.Type, 
					};
				}
				else if (warhead.Type == Warhead.WarheadType.Weapon)
				{
					text2 = "";
					text3 = "";
				}
				else
				{
					text2 = Convert.ToString(warhead.DP);
					text3 = " DP";
				}
				if (warhead.ExplosivesType == Warhead.WarheadExplosivesType.WeaponPayload)
				{
					stringBuilder2.Append(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("<tr >" + text + "<a href="), (object)string_1), (object)text3), (object)"_"), (object)text2), (object)">"), (object)warhead.Name), (object)"</a></tr>"));
					flag = true;
					continue;
				}
				flag2 = true;
				stringBuilder2.Append("<td>" + text + "#" + Conversions.ToString(warhead.DBID) + " - " + warhead.Name + " ( " + text2 + text3 + " )<br/>");
			}
			if (flag2 && !flag)
			{
				stringBuilder.Append("<div style='border-bottom: black 1px solid'><span style='color: dodgerblue; font-family: Arial'><strong>WARHEADS</strong></span></div>");
			}
			else if (!flag2 && flag)
			{
				stringBuilder.Append("<div style='border-bottom: black 1px solid'><span style='color: dodgerblue; font-family: Arial'><strong>PAYLOAD</strong></span></div>");
			}
			else
			{
				stringBuilder.Append("<div style='border-bottom: black 1px solid'><span style='color: dodgerblue; font-family: Arial'><strong>WARHEADS AND PAYLOAD</strong></span></div>");
			}
			stringBuilder.Append("<div style='font-family:Verdana;font-size:8pt;'>");
			stringBuilder.Append("<table width='100%' align='Center'  cellpadding='2' cellspacing='0' rules='rows' style=' font-size: medium;  font-weight: normal;  text-align: left;   height: 10px; '>");
			stringBuilder.Append("<tr style='color:White;font-family:Verdana;font-size:8pt;'>");
			stringBuilder.Append("<td>");
			stringBuilder.Append((object?)stringBuilder2);
			stringBuilder.Append("</td>");
			stringBuilder.Append("</tr>");
			stringBuilder.Append("</table>");
			stringBuilder.Append("</div>");
			stringBuilder.Append("<br/>");
		}
		return stringBuilder.ToString();
	}

	public string DisplayPropulsion(ActiveUnit AU)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (AU.Propulsion.Count > 0)
		{
			stringBuilder.Append("<div style='border-bottom: black 1px solid'><span style='color: dodgerblue; font-family: Arial'><strong>PROPULSION</strong></span></div>");
			stringBuilder.Append("<table width='100%' align='Center'  cellpadding='2' cellspacing='0' rules='rows' style=' font-size: medium;  font-weight: normal;  text-align: left;   height: 10px; '>");
			stringBuilder.Append("<tr style='font-family:Verdana;font-size:10pt;font-weight:bold;background-color:DimGrey'>");
			stringBuilder.Append("<td>Engines</td><td>Type</td><td>Max Speed</td>");
			stringBuilder.Append("</tr>");
			IEnumerable<IGrouping<int, Engine>> enumerable = from theE in AU.Propulsion
				group theE by theE.DBID;
			foreach (IGrouping<int, Engine> item in enumerable)
			{
				string text = ((item.Count() <= 1) ? "" : (Conversions.ToString(item.Count()) + "x "));
				Engine engine = item.ElementAtOrDefault(0);
				stringBuilder.Append("<tr style=';font-family:Verdana;font-size:8pt;'>");
				try
				{
					if (engine.AltBands.Select([SpecialName] (AltBand theAltBand) => theAltBand.MaxSpeed.Value).Max() > 0)
					{
						stringBuilder.Append("<td>" + text + engine.Name + "</td>");
						stringBuilder.Append("<td valign='top'>" + Misc.Description(engine.Type, Client.CurrentScenario.DBConnection) + "</td>");
						stringBuilder.Append("<td valign='top'>" + Conversions.ToString(engine.AltBands.Select([SpecialName] (AltBand theAltBand) => theAltBand.MaxSpeed.Value).Max()) + " kts</td>");
					}
					else
					{
						stringBuilder.Append("<td>None</td>");
						stringBuilder.Append("<td></td>");
						stringBuilder.Append("<td></td>");
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					stringBuilder.Append("<td>None</td>");
					stringBuilder.Append("<td></td>");
					stringBuilder.Append("<td></td>");
					ex2?.Data.Add("Error at 200376", ex2.Message);
					GameGeneral.WriteExceptionsToLog(ex2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				stringBuilder.Append("</tr>");
			}
			stringBuilder.Append("</table>");
			stringBuilder.Append("<br/>");
			if (AU.IsAircraft)
			{
				foreach (IGrouping<int, Engine> item2 in enumerable)
				{
					Engine engine = item2.ElementAtOrDefault(0);
					List<float> list = new List<float>();
					try
					{
						list = DBFunctions.GetEngineDetails(engine.DBID, Client.CurrentScenario.DBConnection);
						if (list.Count <= 0)
						{
							continue;
						}
						stringBuilder.Append("<span style='text-align: left; font-family: Arial; font-size: small; font-weight: bold;'>Technical Details</span>");
						stringBuilder.Append("<table width='100%' align='Center'  cellpadding='2' cellspacing='0' rules='rows' style=' font-size: medium;  font-weight: normal;  text-align: left;   height: 10px; '>");
						stringBuilder.Append("<tr style='font-family:Verdana;font-size:10pt;font-weight:bold;background-color:DimGrey'>");
						stringBuilder.Append("<td>Military Static Thrust at S/L</td><td>Afterburner Static Thrust at S/L</td><td>Military Static SFC at S/L</td><td>Afterburner Static SFC at S/L</td>");
						stringBuilder.Append("</tr>");
						stringBuilder.Append("<tr style=';font-family:Verdana;font-size:8pt;'>");
						if (list[0] == 1f)
						{
							stringBuilder.Append("<td>" + Conversions.ToString(list[1]) + " kg</td>");
							if (list[2] > 0f)
							{
								stringBuilder.Append("<td>" + Conversions.ToString(list[2]) + " kg</td>");
							}
							else
							{
								stringBuilder.Append("<td>-</td>");
							}
						}
						else
						{
							stringBuilder.Append("<td>" + Conversions.ToString(list[1]) + " kg per engine</td>");
							if (list[2] <= 0f)
							{
								stringBuilder.Append("<td>-</td>");
							}
							else
							{
								stringBuilder.Append("<td>" + Conversions.ToString(list[2]) + " kg per engine</td>");
							}
						}
						stringBuilder.Append("<td>" + Conversions.ToString(list[3]) + " kg/h/kg</td>");
						if (list[4] > 0f)
						{
							stringBuilder.Append("<td>" + Conversions.ToString(list[4]) + " kg/h/kg</td>");
						}
						else
						{
							stringBuilder.Append("<td>-</td>");
						}
						stringBuilder.Append("</tr>");
						stringBuilder.Append("</table>");
						stringBuilder.Append("<br/>");
					}
					catch (Exception ex3)
					{
						ProjectData.SetProjectError(ex3);
						Exception ex4 = ex3;
						ex4?.Data.Add("Error at 200377", ex4.Message);
						GameGeneral.WriteExceptionsToLog(ex4);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
				}
			}
			foreach (IGrouping<int, Engine> item3 in enumerable)
			{
				Engine engine = item3.ElementAtOrDefault(0);
				int num = 1;
				if (engine.AltBands.Length <= 0)
				{
					continue;
				}
				if (AU.Propulsion.Count > 1)
				{
					stringBuilder.Append("<span style='text-align: left; font-family: Arial; font-size: small; font-weight: bold;'>Performance Details for " + DBFunctions.GetEngine(engine.DBID, ref AU).Name + "</span>");
				}
				else
				{
					stringBuilder.Append("<span style='text-align: left; font-family: Arial; font-size: small; font-weight: bold;'>Performance Details</span>");
				}
				stringBuilder.Append("<table width='100%' align='Center'  cellpadding='2' cellspacing='0' rules='rows' style=' font-size: medium;  font-weight: normal;  text-align: left;   height: 10px; '>");
				stringBuilder.Append("<tr style='font-family:Verdana;font-size:10pt;font-weight:bold;background-color:DimGrey'>");
				if (engine.Type == Engine.EngineType.Nuclear)
				{
					if (AU.IsSubmarine)
					{
						stringBuilder.Append("<td>Altitude Band & Throttle</td><td>Altitude</td><td>Speed</td>");
					}
					else
					{
						stringBuilder.Append("<td>Altitude Band & Throttle</td><td>Speed</td>");
					}
				}
				else if (!AU.IsAircraft && !AU.IsMissile)
				{
					if (!AU.IsSubmarine && !AU.IsTorpedo)
					{
						if (AU.IsVehicle && ((Vehicle)AU).IsAmphibiousSeaworthy)
						{
							stringBuilder.Append("<td>Land/Water & Throttle</td><td></td><td>Speed</td><td>Fuel Consumption</td>");
						}
						else
						{
							stringBuilder.Append("<td>Altitude Band & Throttle</td><td>Speed</td><td>Fuel Consumption</td>");
						}
					}
					else
					{
						stringBuilder.Append("<td>Altitude Band & Throttle</td><td>Depth</td><td>Speed</td><td>Fuel Consumption</td>");
					}
				}
				else
				{
					stringBuilder.Append("<td>Altitude Band & Throttle</td><td>Altitude</td><td>Speed</td><td>Fuel Consumption</td>");
				}
				stringBuilder.Append("</tr>");
				AltBand[] altBands = engine.AltBands;
				foreach (AltBand altBand in altBands)
				{
					try
					{
						if (altBand.Speed_Loiter > 0)
						{
							stringBuilder.Append("<tr style=';font-family:Verdana;font-size:8pt;'>");
							if (AU.IsVehicle && ((Vehicle)AU).IsAmphibious)
							{
								if (engine.CanBeUsedOnWater() && altBand == engine.AltBands.Last())
								{
									stringBuilder.Append("<td rowspan='4' valign='middle'>On water</td>");
								}
								else
								{
									stringBuilder.Append("<td rowspan='4' valign='middle'>On land</td>");
								}
							}
							if (!AU.IsAircraft && !AU.IsMissile)
							{
								if (!AU.IsSubmarine && !AU.IsTorpedo)
								{
									stringBuilder.Append("<td valign='top'>Creep Throttle</td>");
								}
								else
								{
									stringBuilder.Append("<td valign='top'>Band " + Conversions.ToString(num) + ", Creep Throttle</td>");
								}
							}
							else
							{
								stringBuilder.Append("<td valign='top'>Band " + Conversions.ToString(num) + ", Loiter Speed</td>");
							}
							if (AU.IsAircraft || AU.IsMissile)
							{
								stringBuilder.Append("<td>" + $"{altBand.MinAlt * 3.28084f:0}" + " - " + $"{altBand.MaxAlt * 3.28084f:0}" + " ft<br>" + $"{altBand.MinAlt:0.0}" + " - " + $"{altBand.MaxAlt:0.0}" + " m</td>");
							}
							if (AU.IsSubmarine || AU.IsTorpedo)
							{
								stringBuilder.Append("<td>" + $"{altBand.MaxAlt * 3.28084f * -1f:0}" + " - " + $"{altBand.MinAlt * 3.28084f * -1f:0}" + " ft<br>" + $"{altBand.MaxAlt * -1f:0.0}" + " - " + $"{altBand.MinAlt * -1f:0.0}" + " m</td>");
							}
							stringBuilder.Append("<td>" + Conversions.ToString(altBand.Speed_Loiter) + " kt");
							if (AU.IsAircraft || AU.IsMissile)
							{
								stringBuilder.Append("<br>" + $"{Physics.ComputeMach(altBand.MinAlt, altBand.Speed_Loiter):0.00}" + " Mach");
							}
							stringBuilder.Append("</td>");
							if (engine.Type != Engine.EngineType.Nuclear)
							{
								if (engine.Type != Engine.EngineType.Electric && engine.Type != Engine.EngineType.AIP)
								{
									if (AU.IsWeapon)
									{
										if (altBand.Consumption_Loiter == 1f)
										{
											stringBuilder.Append("<td valign='top'>" + Conversions.ToString(altBand.Consumption_Loiter) + " fuel point per second</td>");
										}
										else
										{
											stringBuilder.Append("<td valign='top'>" + Conversions.ToString(altBand.Consumption_Loiter) + " fuel points per second</td>");
										}
									}
									else
									{
										stringBuilder.Append("<td valign='top'>" + Conversions.ToString(altBand.Consumption_Loiter) + " kg per minute</td>");
									}
								}
								else if (altBand.Consumption_Loiter == 1f)
								{
									stringBuilder.Append("<td valign='top'>" + Conversions.ToString(altBand.Consumption_Loiter) + " battery unit per minute</td>");
								}
								else
								{
									stringBuilder.Append("<td valign='top'>" + Conversions.ToString(altBand.Consumption_Loiter) + " battery units per minute</td>");
								}
							}
							stringBuilder.Append("</tr>");
						}
						if (altBand.Speed_Cruise > 0)
						{
							stringBuilder.Append("<tr style=';font-family:Verdana;font-size:8pt;'>");
							if (!AU.IsAircraft && !AU.IsMissile)
							{
								if (!AU.IsSubmarine && !AU.IsTorpedo)
								{
									stringBuilder.Append("<td valign='top'>Cruise Throttle</td>");
								}
								else
								{
									stringBuilder.Append("<td valign='top'>Band " + Conversions.ToString(num) + ", Cruise Throttle</td>");
								}
							}
							else
							{
								stringBuilder.Append("<td valign='top'>Band " + Conversions.ToString(num) + ", Cruise Speed</td>");
							}
							if (AU.IsAircraft || AU.IsMissile)
							{
								stringBuilder.Append("<td>" + $"{altBand.MinAlt * 3.28084f:0}" + " - " + $"{altBand.MaxAlt * 3.28084f:0}" + " ft<br>" + $"{altBand.MinAlt:0.0}" + " - " + $"{altBand.MaxAlt:0.0}" + " m</td>");
							}
							if (AU.IsSubmarine || AU.IsTorpedo)
							{
								stringBuilder.Append("<td>" + Conversions.ToString(Conversions.ToDouble($"{altBand.MaxAlt * 3.28084f:0}") * -1.0) + " - " + Conversions.ToString(Conversions.ToDouble($"{altBand.MinAlt * 3.28084f:0}") * -1.0) + " ft<br>" + $"{altBand.MaxAlt * -1f:0.0}" + " - " + $"{altBand.MinAlt * -1f:0.0}" + " m</td>");
							}
							stringBuilder.Append("<td>" + Conversions.ToString(altBand.Speed_Cruise) + " kt");
							if (AU.IsAircraft || AU.IsMissile)
							{
								stringBuilder.Append("<br>" + $"{Physics.ComputeMach(altBand.MinAlt, altBand.Speed_Cruise):0.00}" + " Mach");
							}
							stringBuilder.Append("</td>");
							if (engine.Type != Engine.EngineType.Nuclear)
							{
								if (engine.Type != Engine.EngineType.Electric && engine.Type != Engine.EngineType.AIP)
								{
									if (!AU.IsWeapon)
									{
										stringBuilder.Append("<td valign='top'>" + Conversions.ToString(altBand.Consumption_Cruise) + " kg per minute</td>");
									}
									else if (altBand.Consumption_Cruise == 1f)
									{
										stringBuilder.Append("<td valign='top'>" + Conversions.ToString(altBand.Consumption_Cruise) + " fuel point per second</td>");
									}
									else
									{
										stringBuilder.Append("<td valign='top'>" + Conversions.ToString(altBand.Consumption_Cruise) + " fuel points per second</td>");
									}
								}
								else if (altBand.Consumption_Cruise == 1f)
								{
									stringBuilder.Append("<td valign='top'>" + Conversions.ToString(altBand.Consumption_Cruise) + " battery unit per minute</td>");
								}
								else
								{
									stringBuilder.Append("<td valign='top'>" + Conversions.ToString(altBand.Consumption_Cruise) + " battery units per minute</td>");
								}
							}
							stringBuilder.Append("</tr>");
						}
						if (altBand.Speed_Full.HasValue)
						{
							stringBuilder.Append("<tr style=';font-family:Verdana;font-size:8pt;'>");
							if (!AU.IsAircraft && !AU.IsMissile)
							{
								if (!AU.IsSubmarine && !AU.IsTorpedo)
								{
									stringBuilder.Append("<td valign='top'>Full Throttle</td>");
								}
								else
								{
									stringBuilder.Append("<td valign='top'>Band " + Conversions.ToString(num) + ", Full Throttle</td>");
								}
							}
							else
							{
								stringBuilder.Append("<td valign='top'>Band " + Conversions.ToString(num) + ", Military Speed</td>");
							}
							if (AU.IsAircraft || AU.IsMissile)
							{
								stringBuilder.Append("<td>" + $"{altBand.MinAlt * 3.28084f:0}" + " - " + $"{altBand.MaxAlt * 3.28084f:0}" + " ft<br>" + $"{altBand.MinAlt:0.0}" + " - " + $"{altBand.MaxAlt:0.0}" + " m</td>");
							}
							if (AU.IsSubmarine || AU.IsTorpedo)
							{
								stringBuilder.Append("<td>" + Conversions.ToString(Conversions.ToDouble($"{altBand.MaxAlt * 3.28084f:0}") * -1.0) + " - " + Conversions.ToString(Conversions.ToDouble($"{altBand.MinAlt * 3.28084f:0}") * -1.0) + " ft<br>" + $"{altBand.MaxAlt * -1f:0.0}" + " - " + $"{altBand.MinAlt * -1f:0.0}" + " m</td>");
							}
							int? speed_Full;
							int? num3 = (speed_Full = altBand.Speed_Full);
							stringBuilder.Append("<td>" + (num3.HasValue ? Conversions.ToString(speed_Full.GetValueOrDefault()) : null) + " kt");
							if (AU.IsAircraft || AU.IsMissile)
							{
								stringBuilder.Append("<br>" + $"{Physics.ComputeMach(altBand.MinAlt, altBand.Speed_Full.Value):0.00}" + " Mach");
							}
							stringBuilder.Append("</td>");
							if (engine.Type != Engine.EngineType.Nuclear)
							{
								if (engine.Type != Engine.EngineType.Electric && engine.Type != Engine.EngineType.AIP)
								{
									if (AU.IsWeapon)
									{
										float? consumption_Full = altBand.Consumption_Full;
										if ((consumption_Full.HasValue ? new bool?(consumption_Full.GetValueOrDefault() == 1f) : ((bool?)null)) == true)
										{
											float? num4 = (consumption_Full = altBand.Consumption_Full);
											stringBuilder.Append("<td valign='top'>" + ((!num4.HasValue) ? null : Conversions.ToString(consumption_Full.GetValueOrDefault())) + " fuel point per second</td>");
										}
										else
										{
											float? num4 = (consumption_Full = altBand.Consumption_Full);
											stringBuilder.Append("<td valign='top'>" + (num4.HasValue ? Conversions.ToString(consumption_Full.GetValueOrDefault()) : null) + " fuel points per second</td>");
										}
									}
									else
									{
										float? consumption_Full;
										float? num4 = (consumption_Full = altBand.Consumption_Full);
										stringBuilder.Append("<td valign='top'>" + (num4.HasValue ? Conversions.ToString(consumption_Full.GetValueOrDefault()) : null) + " kg per minute</td>");
									}
								}
								else
								{
									float? consumption_Full = altBand.Consumption_Full;
									if (((!consumption_Full.HasValue) ? ((bool?)null) : new bool?(consumption_Full.GetValueOrDefault() == 1f)) == true)
									{
										float? num4 = (consumption_Full = altBand.Consumption_Full);
										stringBuilder.Append("<td valign='top'>" + (num4.HasValue ? Conversions.ToString(consumption_Full.GetValueOrDefault()) : null) + " battery unit per minute</td>");
									}
									else
									{
										float? num4 = (consumption_Full = altBand.Consumption_Full);
										stringBuilder.Append("<td valign='top'>" + (num4.HasValue ? Conversions.ToString(consumption_Full.GetValueOrDefault()) : null) + " battery units per minute</td>");
									}
								}
							}
							stringBuilder.Append("</tr>");
						}
						if (altBand.Speed_Flank.HasValue)
						{
							stringBuilder.Append("<tr style=';font-family:Verdana;font-size:8pt;'>");
							if (!AU.IsAircraft && !AU.IsMissile)
							{
								if (!AU.IsSubmarine && !AU.IsTorpedo)
								{
									stringBuilder.Append("<td valign='top'>Flank Throttle</td>");
								}
								else
								{
									stringBuilder.Append("<td valign='top'>Band " + Conversions.ToString(num) + ", Flank Throttle</td>");
								}
							}
							else
							{
								stringBuilder.Append("<td valign='top'>Band " + Conversions.ToString(num) + ", Afterburner Speed</td>");
							}
							if (AU.IsAircraft || AU.IsMissile)
							{
								stringBuilder.Append("<td>" + $"{altBand.MinAlt * 3.28084f:0}" + " - " + $"{altBand.MaxAlt * 3.28084f:0}" + " ft<br>" + Conversions.ToString(altBand.MinAlt) + " - " + Conversions.ToString(altBand.MaxAlt) + " m</td>");
							}
							if (AU.IsSubmarine || AU.IsTorpedo)
							{
								stringBuilder.Append("<td>" + Conversions.ToString(Conversions.ToDouble($"{altBand.MaxAlt * 3.28084f:0}") * -1.0) + " - " + Conversions.ToString(Conversions.ToDouble($"{altBand.MinAlt * 3.28084f:0}") * -1.0) + " ft<br>" + Conversions.ToString(altBand.MaxAlt * -1f) + " - " + Conversions.ToString(altBand.MinAlt * -1f) + " m</td>");
							}
							int? speed_Full;
							int? num3 = (speed_Full = altBand.Speed_Flank);
							stringBuilder.Append("<td>" + (num3.HasValue ? Conversions.ToString(speed_Full.GetValueOrDefault()) : null) + " kt");
							if (AU.IsAircraft || AU.IsMissile)
							{
								stringBuilder.Append("<br>" + $"{Physics.ComputeMach(altBand.MinAlt, altBand.Speed_Flank.Value):0.00}" + " Mach");
							}
							stringBuilder.Append("</td>");
							if (engine.Type != Engine.EngineType.Nuclear)
							{
								if (engine.Type != Engine.EngineType.Electric && engine.Type != Engine.EngineType.AIP)
								{
									if (!AU.IsWeapon)
									{
										float? consumption_Full;
										float? num4 = (consumption_Full = altBand.Consumption_Flank);
										stringBuilder.Append("<td valign='top'>" + ((!num4.HasValue) ? null : Conversions.ToString(consumption_Full.GetValueOrDefault())) + " kg per minute</td>");
									}
									else
									{
										float? consumption_Full = altBand.Consumption_Flank;
										if (((!consumption_Full.HasValue) ? ((bool?)null) : new bool?(consumption_Full.GetValueOrDefault() == 1f)) == true)
										{
											float? num4 = (consumption_Full = altBand.Consumption_Flank);
											stringBuilder.Append("<td valign='top'>" + ((!num4.HasValue) ? null : Conversions.ToString(consumption_Full.GetValueOrDefault())) + " fuel point per second</td>");
										}
										else
										{
											float? num4 = (consumption_Full = altBand.Consumption_Flank);
											stringBuilder.Append("<td valign='top'>" + ((!num4.HasValue) ? null : Conversions.ToString(consumption_Full.GetValueOrDefault())) + " fuel points per second</td>");
										}
									}
								}
								else
								{
									float? consumption_Full = altBand.Consumption_Flank;
									if (((!consumption_Full.HasValue) ? ((bool?)null) : new bool?(consumption_Full.GetValueOrDefault() == 1f)) == true)
									{
										float? num4 = (consumption_Full = altBand.Consumption_Flank);
										stringBuilder.Append("<td valign='top'>" + ((!num4.HasValue) ? null : Conversions.ToString(consumption_Full.GetValueOrDefault())) + " battery unit per minute</td>");
									}
									else
									{
										float? num4 = (consumption_Full = altBand.Consumption_Flank);
										stringBuilder.Append("<td valign='top'>" + ((!num4.HasValue) ? null : Conversions.ToString(consumption_Full.GetValueOrDefault())) + " battery units per minute</td>");
									}
								}
							}
							stringBuilder.Append("</tr>");
						}
					}
					catch (Exception ex5)
					{
						ProjectData.SetProjectError(ex5);
						Exception ex6 = ex5;
						ex6?.Data.Add("Error at 200378", ex6.Message);
						GameGeneral.WriteExceptionsToLog(ex6);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
					num++;
				}
				stringBuilder.Append("</table>");
				stringBuilder.Append("<br/>");
			}
		}
		return stringBuilder.ToString();
	}

	public string DisplayFuel(ActiveUnit AU)
	{
		StringBuilder stringBuilder = new StringBuilder();
		string text = "";
		if (AU.Fuel_ReadOnly.Count > 0)
		{
			stringBuilder.Append("<div style='border-bottom: black 1px solid'><span style='color: dodgerblue; font-family: Arial'><strong>FUEL</strong></span></div>");
			stringBuilder.Append("<table width='100%' align='Center'  cellpadding='2' cellspacing='0' rules='rows' style=' font-size: medium;  font-weight: normal;  text-align: left;   height: 10px; '>");
			stringBuilder.Append("<tr style='font-family:Verdana;font-size:10pt;font-weight:bold;background-color:DimGrey'>");
			stringBuilder.Append("<td>Fuel Type</td><td>Quantity</td>");
			stringBuilder.Append("</tr>");
			bool flag = false;
			foreach (FuelRec item in AU.Fuel_ReadOnly)
			{
				stringBuilder.Append("<tr style=';font-family:Verdana;font-size:8pt;'>");
				double num = item.MaxQuantity;
				if (!(!AU.IsAircraft & !AU.IsWeapon))
				{
					if (!AU.IsWeapon)
					{
						text = ((!AU.IsAircraft || !((Aircraft)AU).isUAVSizeClass1AndHasDBProvidedEndurance()) ? " kg" : (" " + Aircraft.UAVSizeClass1FuelUnitOfMeasurementString));
					}
					else
					{
						Weapon weapon = (Weapon)AU;
						if (weapon.UsesBoostCoastModel.Value)
						{
							bool assumeAirLaunch = DBFunctions.CheckWeaponIsInAircraftLoadouts(Client.CurrentScenario.DBConnection, AU.DBID) || weapon.MinLaunchAlt_AGL > 0f || weapon.MinLaunchAlt_ASL > 0f;
							Weapon.RecalculateWeaponFlightEnergyIfNecessary(weapon, Client.CurrentScenario, assumeAirLaunch, null);
							num = weapon.TotalBurnTime;
						}
						if (num > 120.0)
						{
							num /= 60.0;
							text = " minutes";
						}
						else
						{
							text = " seconds";
						}
						if (weapon.UsesBoostCoastModel.Value)
						{
							string text2 = text;
							int? flightEndurance;
							int? num2 = (flightEndurance = weapon.FlightEndurance);
							text = text2 + " (Flight Endurance: " + ((!num2.HasValue) ? null : Conversions.ToString(flightEndurance.GetValueOrDefault())) + " sec)";
						}
					}
				}
				else if (item.FuelType != FuelRec._FuelType.Battery && item.FuelType != FuelRec._FuelType.AirIndepedent)
				{
					num /= 1000.0;
					text = " tons";
				}
				else if (num > 120.0)
				{
					num /= 60.0;
					text = " hours at creep throttle";
				}
				else
				{
					text = " minutes at creep throttle";
				}
				string text3 = "";
				int num3;
				if (flag)
				{
					text3 = " (Secondary fuel tank)";
					num3 = 1;
				}
				else
				{
					num3 = 1;
				}
				flag = (byte)num3 != 0;
				stringBuilder.Append("<td>" + Misc.Description(item.FuelType, Client.CurrentScenario.DBConnection) + text3 + "</td>");
				stringBuilder.Append("<td>" + $"{num:0.0}" + text + "</td>");
				stringBuilder.Append("</tr>");
			}
			stringBuilder.Append("</table>");
			if (AU.IsWeapon)
			{
				if (((Weapon)AU).UsesBoostCoastModel.Value)
				{
					stringBuilder.Append("<i>NOTE: Weapon uses boost-coast kinematic model</i>");
				}
				else
				{
					stringBuilder.Append("<i>NOTE: Weapon assumes constant propulsion</i>");
				}
			}
			stringBuilder.Append("<br/>");
		}
		return stringBuilder.ToString();
	}

	public string DisplayCommQualityLimitations(Weapon theWeapon)
	{
		StringBuilder stringBuilder = new StringBuilder();
		WeaponCommMatrix.WeaponCommEntry wMatrixEntry = WeaponCommMatrix.GetWMatrixEntry(theWeapon.Type);
		stringBuilder.Append("<div style='border-bottom: black 1px solid'><span style='color: dodgerblue; font-family: Arial'><strong>COMM LIMITATIONS</strong></span></div>");
		stringBuilder.Append("<table width='100%' align='Center' cellpadding='2' cellspacing='0' rules='rows' style='font-size: medium; font-weight: normal; text-align: left; height: 10px;'>");
		stringBuilder.Append("<tr style='font-family:Verdana;font-size:10pt;font-weight:bold;background-color:DimGrey'>");
		stringBuilder.Append("<td>Parameter</td><td>Required</td>");
		stringBuilder.Append("</tr>");
		if (wMatrixEntry != null)
		{
			stringBuilder.Append("<tr style='font-family:Verdana;font-size:8pt;'>");
			stringBuilder.Append("<td>Weapon type</td>");
			stringBuilder.Append("<td>" + wMatrixEntry.Category.ToString() + "</td>");
			stringBuilder.Append("</tr>");
			stringBuilder.Append("<tr style='font-family:Verdana;font-size:8pt;'>");
			stringBuilder.Append("<td>Min bandwidth</td>");
			stringBuilder.Append("<td>" + EnumCommExtensions.GetDescriptionAsSlide(wMatrixEntry.MinBandwidth) + "</td>");
			stringBuilder.Append("</tr>");
			stringBuilder.Append("<tr style='font-family:Verdana;font-size:8pt;'>");
			stringBuilder.Append("<td>Min latency grade</td>");
			stringBuilder.Append("<td>" + EnumCommExtensions.GetDescriptionAsSlide(wMatrixEntry.MinLatency) + "</td>");
			stringBuilder.Append("</tr>");
			List<string> list = new List<string>();
			foreach (WeaponCommMatrix.IFCVariant item in wMatrixEntry.SupportedIFC)
			{
				list.Add(method_14(item));
			}
			string text = ((list.Count > 0) ? string.Join(", ", list) : "Local fire only");
			stringBuilder.Append("<tr style='font-family:Verdana;font-size:8pt;'>");
			stringBuilder.Append("<td>  WIP: Supported IFC</td>");
			stringBuilder.Append("<td colspan='2'>" + text + "</td>");
			stringBuilder.Append("</tr>");
		}
		else
		{
			stringBuilder.Append("<tr style='font-family:Verdana;font-size:8pt;'>");
			stringBuilder.Append("<td colspan='3'>No comm data available for this weapon type.</td>");
			stringBuilder.Append("</tr>");
		}
		stringBuilder.Append("</table>");
		stringBuilder.Append("<br/>");
		return stringBuilder.ToString();
	}

	private void method_13(StringBuilder stringBuilder_0, string string_3, string string_4, string string_5, bool bool_6, string string_6 = "")
	{
		string arg = (bool_6 ? "#f0f0f0" : "#ffffff");
		string arg2 = ((Operators.CompareString(string_6, "", true) == 0) ? "" : $"color:{string_6};font-weight:bold");
		stringBuilder_0.Append($"<tr style='background-color:{arg};'>");
		stringBuilder_0.Append($"<td style='padding:3px 6px'>{string_3}</td>");
		stringBuilder_0.Append($"<td style='padding:3px 6px;{arg2}'>{string_4}</td>");
		stringBuilder_0.Append($"<td style='padding:3px 6px;color:#888'>{string_5}</td>");
		stringBuilder_0.Append("</tr>");
	}

	private string method_14(WeaponCommMatrix.IFCVariant ifcvariant_0)
	{
		return ifcvariant_0 switch
		{
			WeaponCommMatrix.IFCVariant.PrecisionCue => "Precision Cue", 
			WeaponCommMatrix.IFCVariant.LaunchOnRemote => "Launch on Remote", 
			WeaponCommMatrix.IFCVariant.EngageOnRemote => "Engage on Remote", 
			WeaponCommMatrix.IFCVariant.ForwardPass => "Forward Pass", 
			WeaponCommMatrix.IFCVariant.RemoteFire => "Remote Fire", 
			WeaponCommMatrix.IFCVariant.PreferredShooterDetermination => "PSD", 
			_ => ifcvariant_0.ToString(), 
		};
	}

	public string WeaponSummary(ActiveUnit theAU, Weapon theW)
	{
		_Closure$__163-0 arg = default(_Closure$__163-0);
		_Closure$__163-0 CS$<>8__locals17 = new _Closure$__163-0(arg);
		CS$<>8__locals17.$VB$Local_theW = theW;
		string text = Misc.ToEnglishString(CS$<>8__locals17.$VB$Local_theW.Type) + ". ";
		string text2 = "Targets: " + string.Join(", ", CS$<>8__locals17.$VB$Local_theW.ValidTargets_Description) + ". ";
		string text3 = ((CS$<>8__locals17.$VB$Local_theW.Kinematics.GetMaximumSpeed() > 0) ? ("Max Speed: " + Conversions.ToString(CS$<>8__locals17.$VB$Local_theW.Kinematics.GetMaximumSpeed()) + " kts. ") : "");
		string text4 = ((CS$<>8__locals17.$VB$Local_theW.MaxRange_NoTargetType <= 0f) ? "" : ("Max Range: " + Conversions.ToString(CS$<>8__locals17.$VB$Local_theW.MaxRange_NoTargetType) + " nm. "));
		IEnumerable<IGrouping<string, Warhead>> enumerable = from theWH in CS$<>8__locals17.$VB$Local_theW.Warheads
			group theWH by theWH.Name;
		List<string> list = new List<string>();
		foreach (IGrouping<string, Warhead> item in enumerable)
		{
			string text5 = "";
			if (item.Count() > 1)
			{
				text5 = Conversions.ToString(item.Count()) + "x ";
			}
			if (!item.ElementAtOrDefault(0).get_IsNuclear(Client.CurrentScenario))
			{
				if (item.ElementAtOrDefault(0).DP >= 0f)
				{
					list.Add(text5 + item.ElementAtOrDefault(0).Name);
					continue;
				}
				list.Add(text5 + item.ElementAtOrDefault(0).Name + " (" + Conversions.ToString(item.ElementAtOrDefault(0).DP) + " DPs)");
			}
			else
			{
				list.Add(text5 + item.ElementAtOrDefault(0).Name);
			}
		}
		string text6 = ((list.Count <= 0) ? "" : ((CS$<>8__locals17.$VB$Local_theW.Warheads.Length > 1) ? ("Warheads: " + string.Join(" - ", list)) : ("Warhead: " + string.Join(" - ", list)))) + ". ";
		string text7 = default(string);
		if (CS$<>8__locals17.$VB$Local_theW.IsGuidedWeapon() && CS$<>8__locals17.$VB$Local_theW.Directors.Count > 0)
		{
			IEnumerable<IGrouping<int, Sensor>> enumerable2 = from theS in theAU.Sensors_Cached
				where CS$<>8__locals17.$VB$Local_theW.Directors.Contains(theS.DBID)
				group theS by theS.DBID;
			if (enumerable2.Count() > 0)
			{
				List<string> list2 = new List<string>();
				foreach (IGrouping<int, Sensor> item2 in enumerable2)
				{
					list2.Add(item2.ElementAtOrDefault(0).Name);
				}
				text7 = "Can be guided by: " + string.Join(", ", list2) + ". ";
			}
		}
		string text8 = "";
		int num;
		if (!CS$<>8__locals17.$VB$Local_theW.IsMine)
		{
			num = 7;
		}
		else
		{
			text8 = "Deployment depth: " + $"{CS$<>8__locals17.$VB$Local_theW.MinTargetAlt_ASL * 3.28084f:0}" + " ft - " + $"{CS$<>8__locals17.$VB$Local_theW.MaxTargetAlt_ASL * 3.28084f:0}" + " ft, " + Conversions.ToString(CS$<>8__locals17.$VB$Local_theW.MinTargetAlt_ASL) + " m - " + Conversions.ToString(CS$<>8__locals17.$VB$Local_theW.MaxTargetAlt_ASL) + " m. ";
			num = 7;
		}
		string[] array = new string[num];
		array[0] = text;
		array[1] = text2;
		array[2] = text3;
		array[3] = text4;
		array[4] = text6;
		array[5] = text8;
		array[6] = text7;
		return string.Concat(array);
	}

	public string DisplayOrbitDetails(Satellite AU)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("<div style='border-bottom: black 1px solid'><span style='color: dodgerblue; font-family: Arial'><strong>ORBITAL DATA</strong></span></div>");
		stringBuilder.Append("<table width='100%' align='Center'  cellpadding='2' cellspacing='0' rules='rows' style=' font-size: medium;  font-weight: normal;  text-align: left;   height: 10px; '>");
		stringBuilder.Append("<tr style='font-family:Verdana;font-size:10pt;font-weight:bold;background-color:DimGrey'>");
		stringBuilder.Append("<td>Orbit Index</td><td align='center'>Launch date</td><td align='center'>De-orbit date</td><td>Mission</td>");
		stringBuilder.Append("</tr>");
		DataTable orbitsForThisSatellite = DBFunctions.GetOrbitsForThisSatellite(AU.DBID, Client.CurrentScenario.DBConnection);
		foreach (DataRow row in orbitsForThisSatellite.Rows)
		{
			string text = row["ComponentNumber"].ToString();
			DateTime dateTime = Conversions.ToDate(row["LaunchDate"]);
			DateTime t = Conversions.ToDate(row["DeOrbitingDate"]);
			string text2 = Conversions.ToString(row["MissonName"]);
			stringBuilder.Append("<tr style=';font-family:Verdana;font-size:8pt;'>");
			stringBuilder.Append("<td valign='top' align='center'>" + text + "</td>");
			stringBuilder.Append("<td valign='top' align='center'>" + dateTime.ToLongDateString() + "</td>");
			if (DateTime.Compare(t, new DateTime(1900, 1, 1)) > 0)
			{
				stringBuilder.Append("<td valign='top' align='center'>" + t.ToLongDateString() + "</td>");
			}
			else
			{
				stringBuilder.Append("<td valign='top' align='center'>-</td>");
			}
			stringBuilder.Append("<td valign='top' align='center'>" + text2 + "</td>");
			stringBuilder.Append("</tr>");
		}
		stringBuilder.Append("</table>");
		stringBuilder.Append("<br/>");
		return stringBuilder.ToString();
	}

	public string DisplayWeapon(Weapon theW)
	{
		StreamReader streamReader = new StreamReader(Path.Combine(GameGeneral.DBFolderPath, "Templates\\Platform.html"));
		string text;
		using (streamReader)
		{
			text = streamReader.ReadToEnd();
		}
		text = text.Replace("<%PlatformName%>", "#" + Conversions.ToString(SelectedObjectID) + " - " + theW.UnitClass);
		text = text.Replace("<%Image%>", DisplayImage(theW));
		text = text.Replace("<%Description%>", DisplayDescription(theW));
		text = text.Replace("<%General%>", Weapon_General(theW));
		text = text.Replace("<%Sensors%>", DisplaySensors(theW));
		text = text.Replace("<%MineCountermeasures%>", "");
		text = text.Replace("<%Mounts%>", "");
		text = text.Replace("<%Stores%>", "");
		text = text.Replace("<%Loadouts%>", "");
		text = text.Replace("<%Magazines%>", "");
		text = text.Replace("<%Comms%>", DisplayComms(theW));
		text = text.Replace("<%AirFacilities%>", "");
		text = text.Replace("<%DockingFacilities%>", "");
		text = text.Replace("<%Signatures%>", DisplaySignatures(theW));
		text = text.Replace("<%Flags%>", DisplayFlags(theW));
		text = text.Replace("<%Warheads%>", DisplayWarheads(theW));
		text = text.Replace("<%ValidTargets%>", DisplayValidTargets(theW));
		text = text.Replace("<%WRA%>", method_12(theW));
		text = text.Replace("<%Propulsion%>", DisplayPropulsion(theW));
		text = text.Replace("<%Fuel%>", DisplayFuel(theW));
		text = ((!(GameGeneral.Beta_PlatformComms & Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.PointToPointComm))) ? text.Replace("<%CommQualityLimitation%>", "") : text.Replace("<%CommQualityLimitation%>", DisplayCommQualityLimitations(theW)));
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("<div style='border-bottom: black 1px solid'><span style='font-family: Arial; color: dodgerblue;'><strong>DEFAULT WEAPON CARRIER PLATFORMS</strong></span></div>");
		stringBuilder.Append("<div style='color:Black;font-family:Verdana;font-size:8pt;'>");
		List<string> list = DBFunctions.GetPlatformsThatCarryThisWeapon(theW.DBID, Client.CurrentScenario).OrderBy([SpecialName] (string theStr) => theStr.Split(new char[1] { '_' })[2] + " " + theStr.Split(new char[1] { '_' })[3] + " " + theStr.Split(new char[1] { '_' })[4], new NaturalSortComparer<string[]>()).ToList();
		foreach (string item in list)
		{
			string text2 = item.Split(new char[1] { '_' })[0];
			string text3 = item.Split(new char[1] { '_' })[1];
			string text4 = item.Split(new char[1] { '_' })[2];
			string text5 = item.Split(new char[1] { '_' })[3];
			string text6 = item.Split(new char[1] { '_' })[4];
			stringBuilder.Append(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"<a href=", (object)string_1), (object)text2), (object)"_"), (object)text3), (object)">"), (object)text4), (object)" ("), (object)text5), (object)" - "), (object)text6), (object)")</a><br/>"));
		}
		stringBuilder.Append("</div>");
		return text + stringBuilder.ToString();
	}

	public string DisplaySensor(int theSensorDBID)
	{
		SQLiteConnection sqliteConnection_ = Client.CurrentScenario.DBConnection;
		Sensor sensor = DBFunctions.GetSensor(theSensorDBID, ref sqliteConnection_);
		StreamReader streamReader = new StreamReader(Path.Combine(GameGeneral.DBFolderPath, "Templates\\Platform.html"));
		string text;
		using (streamReader)
		{
			text = streamReader.ReadToEnd();
		}
		text = text.Replace("<%PlatformName%>", "#" + Conversions.ToString(SelectedObjectID) + " - " + sensor.Name);
		text = text.Replace("<%Image%>", DisplaySensorImage(sensor.DBID));
		text = text.Replace("<%Description%>", DisplaySensorDescription(Client.CurrentScenario.DBUsed, sensor.DBID));
		text = text.Replace("<%General%>", "");
		text = text.Replace("<%Sensors%>", DisplaySensors(sensor));
		text = text.Replace("<%MineCountermeasures%>", "");
		text = text.Replace("<%Mounts%>", "");
		text = text.Replace("<%Stores%>", "");
		text = text.Replace("<%Loadouts%>", "");
		text = text.Replace("<%Magazines%>", "");
		text = text.Replace("<%Comms%>", "");
		text = text.Replace("<%AirFacilities%>", "");
		text = text.Replace("<%DockingFacilities%>", "");
		text = text.Replace("<%Signatures%>", "");
		text = text.Replace("<%Flags%>", DisplaySensorFlags(sensor));
		text = text.Replace("<%Warheads%>", "");
		text = text.Replace("<%ValidTargets%>", "");
		text = text.Replace("<%WRA%>", "");
		text = text.Replace("<%Propulsion%>", "");
		text = text.Replace("<%Fuel%>", "");
		StringBuilder stringBuilder = new StringBuilder();
		string[] platformsThatCarryThisSensor = DBFunctions.GetPlatformsThatCarryThisSensor(sensor.DBID, Client.CurrentScenario);
		if (platformsThatCarryThisSensor.Count() > 0)
		{
			stringBuilder.Append("<div style='border-bottom: black 1px solid'><span style='font-family: Arial; color: dodgerblue;'><strong>DEFAULT SENSOR CARRIER PLATFORMS</strong></span></div>");
			stringBuilder.Append("<div style='color:Black;font-family:Verdana;font-size:8pt;'>");
			List<string> list = platformsThatCarryThisSensor.OrderBy([SpecialName] (string theStr) => theStr.Split(new char[1] { '_' })[0] + " " + theStr.Split(new char[1] { '_' })[2] + " " + theStr.Split(new char[1] { '_' })[3] + " " + theStr.Split(new char[1] { '_' })[4], new NaturalSortComparer<string[]>()).ToList();
			string text2 = null;
			foreach (string item in list)
			{
				string text3 = item.Split(new char[1] { '_' })[0];
				string text4 = item.Split(new char[1] { '_' })[1];
				string text5 = item.Split(new char[1] { '_' })[2];
				string text6 = item.Split(new char[1] { '_' })[3];
				string text7 = item.Split(new char[1] { '_' })[4];
				if (text2 == null || !text2.Equals(text3))
				{
					stringBuilder.Append("<span style='font-family: Arial; color: lightblue;font-size:10pt;'><strong>" + text3.ToUpperInvariant() + "</strong></span><br/>");
				}
				text2 = text3;
				stringBuilder.Append(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"<a href=", (object)string_1), (object)text3), (object)"_"), (object)text4), (object)">"), (object)text5), (object)" ("), (object)text6), (object)" - "), (object)text7), (object)")</a><br/>"));
			}
			stringBuilder.Append("</div>");
			text += stringBuilder.ToString();
		}
		return text;
	}

	public string DisplaySensorFlags(Sensor Sensor)
	{
		StringBuilder stringBuilder = new StringBuilder();
		new List<string>();
		if (DBFunctions.GetSensorFlagDescriptions(Sensor.DBID, Client.CurrentScenario.DBConnection).Count > 0)
		{
			stringBuilder.Append("<div style='border-bottom: black 1px solid'><span style='color: dodgerblue; font-family: Arial'><strong>PROPERTIES</strong></span></div>");
			stringBuilder.Append("<div style='color:Black;font-family:Verdana;font-size:8pt;'>");
			stringBuilder.Append("<table width='100%' align='Center'  cellpadding='2' cellspacing='0' rules='rows' style=' font-size: medium;  font-weight: normal;  text-align: left;   height: 10px; '>");
			stringBuilder.Append("<tr style=';font-family:Verdana;font-size:8pt;'>");
			stringBuilder.Append("<td>");
			stringBuilder.Append(string.Join("<br/>", DBFunctions.GetSensorFlagDescriptions(Sensor.DBID, Client.CurrentScenario.DBConnection)));
			stringBuilder.Append("</td>");
			stringBuilder.Append("</tr>");
			stringBuilder.Append("</table>");
			stringBuilder.Append("</div>");
			stringBuilder.Append("<br/>");
		}
		return stringBuilder.ToString();
	}

	private void InternalDBViewer_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Invalid comparison between Unknown and I4
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Invalid comparison between Unknown and I4
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Invalid comparison between Unknown and I4
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Invalid comparison between Unknown and I4
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Invalid comparison between Unknown and I4
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Invalid comparison between Unknown and I4
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Invalid comparison between Unknown and I4
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Invalid comparison between Unknown and I4
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27 && ((Control)this).Visible)
		{
			((Form)this).Close();
			return;
		}
		if (DBIDGOTO.Focused && (int)e.KeyCode == 13)
		{
			method_27();
		}
		if (!((ComboBox)CB_ObjectType).Focused && !TB_Class.Focused && !DBIDGOTO.Focused && !((ComboBox)CB_Country).Focused && !((ComboBox)CB_Hypothetical).Focused && !((Control)ListBox1).Focused && !((Control)WebBrowser1).Focused && ((Control)this).Visible && (int)e.KeyCode != 33 && (int)e.KeyCode != 34 && (int)e.KeyCode != 38 && (int)e.KeyCode != 40 && (int)e.KeyCode != 37 && (int)e.KeyCode != 39 && (int)e.KeyCode != 35 && (int)e.KeyCode != 36)
		{
			((Control)MyProject.Forms.MainForm).Focus();
			MyProject.Forms.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void InternalDBViewer_MouseWheel(object sender, MouseEventArgs e)
	{
		int mouseWheelScrollLines = SystemInformation.MouseWheelScrollLines;
		if (bool_3)
		{
			((Control)ListBox1).Focus();
			int num = ((ListBox1.SelectedIndices.Count != 0) ? ListBox1.SelectedIndices[0] : 0);
			if (int_0 < 0)
			{
				int_0 = num * ListBox1.ItemHeight;
			}
			if (e.Delta <= 0)
			{
				int_0 += mouseWheelScrollLines * ListBox1.ItemHeight;
				if (int_0 >= ListBox1.Items.Count * ListBox1.ItemHeight)
				{
					int_0 = (ListBox1.Items.Count - 1) * ListBox1.ItemHeight;
				}
			}
			else
			{
				int_0 -= mouseWheelScrollLines * ListBox1.ItemHeight;
				if (int_0 < 0)
				{
					int_0 = 0;
				}
			}
			ListBox1.method_4(int_0);
		}
		else
		{
			((Control)WebBrowser1).Focus();
		}
	}

	private void method_15(object sender, EventArgs e)
	{
		if (!((Control)ListBox1).Focused)
		{
			((Control)ListBox1).Focus();
		}
		bool_3 = true;
	}

	private void method_16(object sender, EventArgs e)
	{
		bool_3 = false;
		((Control)WebBrowser1).Focus();
	}

	private void method_17(object sender, EventArgs e)
	{
		method_3();
	}

	private void method_18(object sender, EventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		((HandledMouseEventArgs)e).Handled = true;
	}

	private void method_19(object sender, PreviewKeyDownEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Invalid comparison between Unknown and I4
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Invalid comparison between Unknown and I4
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Invalid comparison between Unknown and I4
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Invalid comparison between Unknown and I4
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Invalid comparison between Unknown and I4
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Invalid comparison between Unknown and I4
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Invalid comparison between Unknown and I4
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Invalid comparison between Unknown and I4
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Expected O, but got Unknown
		if ((int)e.KeyCode == 27 && ((Control)this).Visible)
		{
			((Form)this).Close();
		}
		else if (!((ComboBox)CB_ObjectType).Focused && !TB_Class.Focused && !((ComboBox)CB_Country).Focused && !((ComboBox)CB_Hypothetical).Focused && !((Control)ListBox1).Focused && !((Control)WebBrowser1).Focused && ((Control)this).Visible && (int)e.KeyCode != 33 && (int)e.KeyCode != 34 && (int)e.KeyCode != 38 && (int)e.KeyCode != 40 && (int)e.KeyCode != 37 && (int)e.KeyCode != 39 && (int)e.KeyCode != 35 && (int)e.KeyCode != 36)
		{
			((Control)MyProject.Forms.MainForm).Focus();
			KeyEventArgs e2 = new KeyEventArgs(e.KeyData);
			MyProject.Forms.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e2);
			e2 = null;
		}
	}

	private void method_20(object sender, CoreWebView2NavigationStartingEventArgs e)
	{
		Uri uri = new Uri(e.Uri);
		if (uri.AbsolutePath.Contains("_"))
		{
			e.Cancel = true;
			string text = uri.AbsolutePath.Split(new char[1] { '_' })[0];
			text = text.Replace("/", "");
			int selectedObjectID = Conversions.ToInteger(uri.AbsolutePath.Split(new char[1] { '_' })[1]);
			bool retainPlatform = Operators.CompareString(SelectedObjectType, "Weapon", true) != 0 && Operators.CompareString(SelectedObjectType, "Sensor", true) != 0;
			SelectedObjectType = text;
			SelectedObjectID = selectedObjectID;
			DisplaySelection(ApplyKeywordFilter: false, retainPlatform);
		}
	}

	private void method_21(object sender, CoreWebView2InitializationCompletedEventArgs e)
	{
		if (e.IsSuccess)
		{
			WebBrowser1.CoreWebView2.Settings.AreDefaultContextMenusEnabled = false;
			WebBrowser1.CoreWebView2.Settings.IsReputationCheckingRequired = false;
		}
	}

	private void method_22(object sender, EventArgs e)
	{
		if (!bool_2)
		{
			SelectedObjectID = Conversions.ToInteger(ListBox1.SelectedItems[0].Tag);
			if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(((ComboBox)CB_ObjectType).SelectedItem)))
			{
				SelectedObjectType = Conversions.ToString(((ComboBox)CB_ObjectType).SelectedItem);
			}
			if (!string.IsNullOrEmpty(SelectedObjectType))
			{
				DisplaySelection(ApplyKeywordFilter: false);
			}
		}
	}

	private void method_23(object sender, PreviewKeyDownEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Invalid comparison between Unknown and I4
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Invalid comparison between Unknown and I4
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Invalid comparison between Unknown and I4
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Invalid comparison between Unknown and I4
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Invalid comparison between Unknown and I4
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Invalid comparison between Unknown and I4
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Expected O, but got Unknown
		if ((int)e.KeyCode == 27 && ((Control)this).Visible)
		{
			((Form)this).Close();
		}
		else if ((int)e.KeyCode != 33 && (int)e.KeyCode != 34 && (int)e.KeyCode != 38 && (int)e.KeyCode != 40 && (int)e.KeyCode != 35 && (int)e.KeyCode != 36)
		{
			((Control)MyProject.Forms.MainForm).Focus();
			KeyEventArgs e2 = new KeyEventArgs(e.KeyData);
			MyProject.Forms.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e2);
			e2 = null;
		}
	}

	private void InternalDBViewer_KeyDown_1(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Expected I4, but got Unknown
		try
		{
			if ((int)e.KeyCode == 27 && ((Control)this).Visible)
			{
				((Form)this).Close();
				return;
			}
			Keys keyCode = e.KeyCode;
			switch (keyCode - 33)
			{
			case 0:
			{
				int num2 = ListBox1.SelectedIndices[0];
				num2 -= 5;
				if (num2 < 0)
				{
					num2 = 0;
				}
				ListBox1.SelectItem(num2);
				ListBox1.EnsureVisible();
				break;
			}
			case 1:
			{
				int num = ListBox1.SelectedIndices[0];
				num += 5;
				if (num >= ListBox1.Items.Count)
				{
					num = ListBox1.Items.Count - 1;
				}
				ListBox1.SelectItem(num);
				ListBox1.EnsureVisible();
				break;
			}
			case 2:
				ListBox1.SelectItem(ListBox1.Items.Count - 1);
				ListBox1.EnsureVisible();
				break;
			case 3:
				ListBox1.SelectItem(0);
				ListBox1.EnsureVisible();
				break;
			case 4:
			case 6:
				break;
			case 5:
			case 7:
				break;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			if (ex2 != null)
			{
				ex2.Data.Add("Error at 098678748764", ex2.Message);
				GameGeneral.WriteExceptionsToLog(ex2);
			}
			ProjectData.ClearProjectError();
		}
	}

	public string ShowArcImage(List<string> listOfArcs)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (Directory.Exists(Application.StartupPath + "/Symbols/arcs"))
		{
			if (FileExistsNative.FileExistsFast(Application.StartupPath + "/Symbols/arcs/arc_base.png") && FileExistsNative.FileExistsFast(Application.StartupPath + "/Symbols/arcs/arc_360.png"))
			{
				stringBuilder.Append("<style>\r\n.containerdiv {position: relative; } \r\n.cornerimage {position: absolute; top: 0; left: 0; width:50; height:50} \r\n</style>");
				stringBuilder.Append("<div Class=\"containerdiv\" >");
				bool flag = true;
				foreach (string listOfArc in listOfArcs)
				{
					string text = "https://Root/Symbols/arcs/";
					if (Operators.CompareString(listOfArc, "360", true) != 0)
					{
						if (flag)
						{
							stringBuilder.Append("<img width='50' height='50' src='" + text + "arc_base.png'>");
						}
						if (Operators.CompareString(listOfArc, "SB1", true) == 0)
						{
							stringBuilder.Append("<img class=\"cornerimage\" src='" + text + "arc_sb1.png'>");
						}
						if (Operators.CompareString(listOfArc, "SB2", true) == 0)
						{
							stringBuilder.Append("<img class=\"cornerimage\" src='" + text + "arc_sb2.png'>");
						}
						if (Operators.CompareString(listOfArc, "SMF1", true) == 0)
						{
							stringBuilder.Append("<img class=\"cornerimage\" src='" + text + "arc_smf1.png'>");
						}
						if (Operators.CompareString(listOfArc, "SMF2", true) == 0)
						{
							stringBuilder.Append("<img class=\"cornerimage\" src='" + text + "arc_smf2.png'>");
						}
						if (Operators.CompareString(listOfArc, "SMA1", true) == 0)
						{
							stringBuilder.Append("<img class=\"cornerimage\" src='" + text + "arc_sma1.png'>");
						}
						if (Operators.CompareString(listOfArc, "SMA2", true) == 0)
						{
							stringBuilder.Append("<img class=\"cornerimage\" src='" + text + "arc_sma2.png'>");
						}
						if (Operators.CompareString(listOfArc, "SS1", true) == 0)
						{
							stringBuilder.Append("<img class=\"cornerimage\" src='" + text + "arc_ss1.png'>");
						}
						if (Operators.CompareString(listOfArc, "SS2", true) == 0)
						{
							stringBuilder.Append("<img class=\"cornerimage\" src='" + text + "arc_ss2.png'>");
						}
						if (Operators.CompareString(listOfArc, "PS1", true) == 0)
						{
							stringBuilder.Append("<img class=\"cornerimage\" src='" + text + "arc_ps1.png'>");
						}
						if (Operators.CompareString(listOfArc, "PS2", true) == 0)
						{
							stringBuilder.Append("<img class=\"cornerimage\" src='" + text + "arc_ps2.png'>");
						}
						if (Operators.CompareString(listOfArc, "PMA1", true) == 0)
						{
							stringBuilder.Append("<img class=\"cornerimage\" src='" + text + "arc_pma1.png'>");
						}
						if (Operators.CompareString(listOfArc, "PMA2", true) == 0)
						{
							stringBuilder.Append("<img class=\"cornerimage\" src='" + text + "arc_pma2.png'>");
						}
						if (Operators.CompareString(listOfArc, "PMF1", true) == 0)
						{
							stringBuilder.Append("<img class=\"cornerimage\" src='" + text + "arc_pmf1.png'>");
						}
						if (Operators.CompareString(listOfArc, "PMF2", true) == 0)
						{
							stringBuilder.Append("<img class=\"cornerimage\" src='" + text + "arc_pmf2.png'>");
						}
						if (Operators.CompareString(listOfArc, "PB1", true) == 0)
						{
							stringBuilder.Append("<img class=\"cornerimage\" src='" + text + "arc_pb1.png'>");
						}
						int num;
						if (Operators.CompareString(listOfArc, "PB2", true) == 0)
						{
							stringBuilder.Append("<img class=\"cornerimage\" src='" + text + "arc_pb2.png'>");
							num = 0;
						}
						else
						{
							num = 0;
						}
						flag = (byte)num != 0;
						continue;
					}
					stringBuilder.Append("<img width='50' height='50' src='" + text + "arc_360.png' >");
					break;
				}
				stringBuilder.Append("<br/></div>");
				return stringBuilder.ToString();
			}
			return "";
		}
		return "";
	}

	private void method_24(object sender, EventArgs e)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Invalid comparison between Unknown and I4
		if ((int)Control.ModifierKeys == 65536)
		{
			DisplayNavigationHistoryIndex(0);
		}
		else
		{
			DisplayNavigationHistoryIndex(NavigationHistoryPosition - 1);
		}
	}

	private void method_25(object sender, EventArgs e)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Invalid comparison between Unknown and I4
		if ((int)Control.ModifierKeys == 65536)
		{
			DisplayNavigationHistoryIndex(DBViewerNavigationHistory.Count - 1);
		}
		else
		{
			DisplayNavigationHistoryIndex(NavigationHistoryPosition + 1);
		}
	}

	private void method_26(object sender, EventArgs e)
	{
		DBIDGOTO.WatermarkText = "Enter Database ID for this " + ((ComboBox)CB_ObjectType).Text + " ...";
	}

	private void method_27()
	{
		SQLiteHelper theHelper = new SQLiteHelper(Client.CurrentScenario.DBConnection);
		if (!Regex.IsMatch(DBIDGOTO.Text, "^[0-9 ]+$"))
		{
			return;
		}
		string text = ((ComboBox)CB_ObjectType).Text;
		DataTable datatable = default(DataTable);
		if (Operators.CompareString(text, "Aircraft", true) == 0)
		{
			string theQuery = "Select * from DataAircraft where ID = " + DBIDGOTO.Text;
			datatable = DBCache.GetDatatable(theHelper, theQuery);
		}
		else if (Operators.CompareString(text, "Ship", true) != 0)
		{
			if (Operators.CompareString(text, "Submarine", true) == 0)
			{
				string theQuery = "Select * from DataSubmarine where ID = " + DBIDGOTO.Text;
				datatable = DBCache.GetDatatable(theHelper, theQuery);
			}
			else if (Operators.CompareString(text, "Facility", true) != 0)
			{
				if (Operators.CompareString(text, "Satellite", true) == 0)
				{
					string theQuery = "Select * from DataSatellite where ID = " + DBIDGOTO.Text;
					datatable = DBCache.GetDatatable(theHelper, theQuery);
				}
				else if (Operators.CompareString(text, "Weapon", true) == 0)
				{
					string theQuery = "Select * from DataWeapon where ID = " + DBIDGOTO.Text;
					datatable = DBCache.GetDatatable(theHelper, theQuery);
				}
				else if (Operators.CompareString(text, "Sensor", true) == 0)
				{
					string theQuery = "Select * from DataSensor where ID = " + DBIDGOTO.Text;
					datatable = DBCache.GetDatatable(theHelper, theQuery);
				}
			}
			else
			{
				string theQuery = "Select * from DataFacility where ID = " + DBIDGOTO.Text;
				datatable = DBCache.GetDatatable(theHelper, theQuery);
			}
		}
		else
		{
			string theQuery = "Select * from DataShip where ID = " + DBIDGOTO.Text;
			datatable = DBCache.GetDatatable(theHelper, theQuery);
		}
		if (datatable != null && datatable.Rows.Count > 0)
		{
			DisplayDataBaseEntry(Conversions.ToInteger(DBIDGOTO.Text), ((ComboBox)CB_ObjectType).Text);
			DBIDGOTO.Text = "";
		}
	}

	public void DisplayDataBaseEntry(int DBID, string Type)
	{
		if (DisplayInfoInDetailsPanel(DBID, Type))
		{
			if (DBViewerNavigationHistory.Count <= 0 || DBViewerNavigationHistory[DBViewerNavigationHistory.Count - 1].DBID != SelectedObjectID)
			{
				DBViewerNavigationHistory.Add(new DBViewerNavigationHistoryItem(SelectedObjectID, SelectedObjectType));
				NavigationHistoryPosition = DBViewerNavigationHistory.Count - 1;
			}
			RefreshNavigationHistoryButtons();
			if (!string.IsNullOrEmpty(HighlightTarget))
			{
				ScrollToSpecificElement(HighlightTarget);
			}
		}
	}

	private void method_28(object sender, EventArgs e)
	{
		method_27();
	}

	private void method_29(object sender, EventArgs e)
	{
		((TextBoxBase)DBIDGOTO._T).SelectAll();
	}

	private void method_30(object sender, EventArgs e)
	{
		DBViewer.OpenNewDatabaseWindow(SelectedObjectType, SelectedObjectID);
	}

	public void BindCombobox_SubType(short index)
	{
		DataTable dataTable = new DataTable();
		if (!dataTable.Columns.Contains("ID"))
		{
			dataTable.Columns.Add("ID", typeof(int));
		}
		if (!dataTable.Columns.Contains("Description"))
		{
			dataTable.Columns.Add("Description", typeof(string));
		}
		dataTable.Rows.Clear();
		int selectedIndex = ((ComboBox)CB_ObjectType).SelectedIndex;
		switch (selectedIndex)
		{
		case 0:
		{
			int num2 = 0;
			foreach (object value in Enum.GetValues(typeof(Aircraft._AircraftType)))
			{
				Aircraft._AircraftType aircraftType = (Aircraft._AircraftType)Conversions.ToInteger(value);
				string text = Misc.Description(aircraftType, Client.CurrentScenario.DBConnection);
				if (string.IsNullOrEmpty(Misc.Description(aircraftType, Client.CurrentScenario.DBConnection)))
				{
					dataTable.Rows.Add((int)aircraftType, aircraftType.ToString());
				}
				else
				{
					dataTable.Rows.Add((int)aircraftType, text);
				}
				if (selectedSubType > 0 && aircraftType == (Aircraft._AircraftType)selectedSubType)
				{
					index = (short)num2;
				}
				num2++;
			}
			break;
		}
		case 1:
		{
			int num8 = 0;
			foreach (object value2 in Enum.GetValues(typeof(Ship._ShipType)))
			{
				Ship._ShipType shipType = (Ship._ShipType)Conversions.ToInteger(value2);
				string text6 = Misc.Description(shipType, Client.CurrentScenario.DBConnection);
				Misc.Description(shipType, Client.CurrentScenario.DBConnection);
				if (!string.IsNullOrEmpty(Misc.Description(shipType, Client.CurrentScenario.DBConnection)))
				{
					dataTable.Rows.Add((int)shipType, text6);
				}
				else
				{
					dataTable.Rows.Add((int)shipType, shipType.ToString());
				}
				if (selectedSubType > 0 && shipType == (Ship._ShipType)selectedSubType)
				{
					index = (short)num8;
				}
				num8++;
			}
			break;
		}
		case 2:
		{
			int num7 = 0;
			foreach (object value3 in Enum.GetValues(typeof(Submarine._SubmarineType)))
			{
				Submarine._SubmarineType submarineType = (Submarine._SubmarineType)Conversions.ToInteger(value3);
				string text5 = Misc.Description(submarineType, Client.CurrentScenario.DBConnection);
				if (string.IsNullOrEmpty(Misc.Description(submarineType, Client.CurrentScenario.DBConnection)))
				{
					dataTable.Rows.Add((int)submarineType, submarineType.ToString());
				}
				else
				{
					dataTable.Rows.Add((int)submarineType, text5);
				}
				if (selectedSubType > 0 && submarineType == (Submarine._SubmarineType)selectedSubType)
				{
					index = (short)num7;
				}
				num7++;
			}
			break;
		}
		case 3:
		{
			int num6 = 0;
			foreach (object value4 in Enum.GetValues(typeof(Facility._FacilityCategory)))
			{
				Facility._FacilityCategory facilityCategory = (Facility._FacilityCategory)Conversions.ToShort(value4);
				string text4 = Misc.Description(facilityCategory, Client.CurrentScenario.DBConnection);
				if (string.IsNullOrEmpty(Misc.Description(facilityCategory, Client.CurrentScenario.DBConnection)))
				{
					dataTable.Rows.Add((int)facilityCategory, facilityCategory.ToString());
				}
				else
				{
					dataTable.Rows.Add((int)facilityCategory, text4);
				}
				if (selectedSubType > 0 && (int)facilityCategory == selectedSubType)
				{
					index = (short)num6;
				}
				num6++;
			}
			break;
		}
		case 4:
		{
			int num5 = 0;
			foreach (object value5 in Enum.GetValues(typeof(IMobileGroundUnit._MobileUnitCategory)))
			{
				IMobileGroundUnit._MobileUnitCategory mobileUnitCategory = (IMobileGroundUnit._MobileUnitCategory)Conversions.ToInteger(value5);
				string text3 = Misc.ToEnglishString(mobileUnitCategory);
				if (string.IsNullOrEmpty(text3))
				{
					dataTable.Rows.Add((int)mobileUnitCategory, mobileUnitCategory.ToString());
				}
				else
				{
					dataTable.Rows.Add((int)mobileUnitCategory, text3);
				}
				if (selectedSubType > 0 && mobileUnitCategory == (IMobileGroundUnit._MobileUnitCategory)selectedSubType)
				{
					index = (short)num5;
				}
				num5++;
			}
			break;
		}
		case 5:
		{
			int num4 = 0;
			foreach (object value6 in Enum.GetValues(typeof(Satellite._SatelliteType)))
			{
				Satellite._SatelliteType satelliteType = (Satellite._SatelliteType)Conversions.ToInteger(value6);
				string text2 = Misc.Description(satelliteType, Client.CurrentScenario.DBConnection);
				if (string.IsNullOrEmpty(Misc.Description(satelliteType, Client.CurrentScenario.DBConnection)))
				{
					dataTable.Rows.Add((int)satelliteType, satelliteType.ToString());
				}
				else
				{
					dataTable.Rows.Add((int)satelliteType, text2);
				}
				if (selectedSubType > 0 && satelliteType == (Satellite._SatelliteType)selectedSubType)
				{
					index = (short)num4;
				}
				num4++;
			}
			break;
		}
		case 6:
		{
			int num3 = 0;
			foreach (object value7 in Enum.GetValues(typeof(Weapon._WeaponType)))
			{
				Weapon._WeaponType weaponType = (Weapon._WeaponType)Conversions.ToShort(value7);
				dataTable.Rows.Add((int)weaponType, weaponType.ToString());
				if (selectedSubType > 0 && (int)weaponType == selectedSubType)
				{
					index = (short)num3;
				}
				num3++;
			}
			break;
		}
		default:
		{
			if (selectedIndex != int_1)
			{
				break;
			}
			int num = 0;
			foreach (object value8 in Enum.GetValues(typeof(Sensor.Sensor_Type)))
			{
				Sensor.Sensor_Type sensor_Type = (Sensor.Sensor_Type)Conversions.ToShort(value8);
				dataTable.Rows.Add((int)sensor_Type, sensor_Type.ToString());
				if (selectedSubType > 0 && (int)sensor_Type == selectedSubType)
				{
					index = (short)num;
				}
				num++;
			}
			break;
		}
		}
		dataTable = new DataView(dataTable)
		{
			Sort = "Description ASC"
		}.ToTable();
		DataRow dataRow = dataTable.NewRow();
		dataRow["ID"] = 0;
		dataRow["Description"] = "Not selected";
		dataTable.Rows.InsertAt(dataRow, 0);
		if (selectedSubType <= 0)
		{
			index = 0;
		}
		else
		{
			int num9 = dataTable.Rows.Count - 1;
			for (int i = 0; i <= num9; i++)
			{
				if (Conversions.ToInteger(dataTable.Rows[i]["ID"]) == selectedSubType)
				{
					index = (short)i;
					break;
				}
			}
		}
		int num10;
		if (index < 0)
		{
			num10 = 0;
		}
		else
		{
			if (index < dataTable.Rows.Count)
			{
				goto IL_0816;
			}
			num10 = 0;
		}
		index = (short)num10;
		goto IL_0816;
		IL_0816:
		if (dataTable.Rows.Count > 0)
		{
			DarkUIComboBox cB_SubType = CB_SubType;
			((ComboBox)cB_SubType).DataSource = dataTable;
			((ListControl)cB_SubType).DisplayMember = "Description";
			((ListControl)cB_SubType).ValueMember = "ID";
			((ComboBox)cB_SubType).SelectedIndex = index;
			((Control)cB_SubType).Enabled = true;
			((Control)cB_SubType).Visible = true;
		}
		else
		{
			dataTable.Rows.Add(0, "None");
			DarkUIComboBox cB_SubType2 = CB_SubType;
			((ComboBox)cB_SubType2).DataSource = dataTable;
			((ListControl)cB_SubType2).DisplayMember = "Description";
			((ListControl)cB_SubType2).ValueMember = "ID";
			((ComboBox)cB_SubType2).SelectedIndex = 0;
			((Control)cB_SubType2).Enabled = false;
			((Control)cB_SubType2).Visible = false;
		}
	}

	private void method_31(object sender, EventArgs e)
	{
		selectedSubType = Conversions.ToInteger(((ListControl)(DarkUIComboBox)sender).SelectedValue);
		method_3();
	}

	private void method_32(object sender, EventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		((HandledMouseEventArgs)e).Handled = true;
	}

	static InternalDBViewer()
	{
		Class72.smethod_20();
	}
}
