using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdvancedDataGridView;
using Command_Core;
using Command.My;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;

namespace Command;

[DesignerGenerated]
public sealed class CampaignPlayWindow : DarkSecondaryFormBase
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct VB$StateMachine_78_theButton_Click : IAsyncStateMachine
	{
		public int $State;

		public AsyncVoidMethodBuilder $Builder;

		internal object $VB$Local_sender;

		internal EventArgs $VB$Local_e;

		internal CampaignPlayWindow $VB$Me;

		internal string $VB$ResumableLocal_ContentTag$0;

		internal Campaign $VB$ResumableLocal_theCamp$1;

		internal TaskAwaiter<bool> $A0;

		[CompilerGenerated]
		internal void MoveNext()
		{
			//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			int num = $State;
			try
			{
				TaskAwaiter<bool> awaiter;
				if (num == 0)
				{
					num = -1;
					$State = -1;
					awaiter = $A0;
					$A0 = default(TaskAwaiter<bool>);
					goto IL_0183;
				}
				TaskAwaiter<bool> awaiter2;
				if (num == 1)
				{
					num = -1;
					$State = -1;
					awaiter2 = $A0;
					$A0 = default(TaskAwaiter<bool>);
					goto IL_02fd;
				}
				((Control)$VB$Me.WebBrowser1).Visible = true;
				$VB$Me.string_0 = Conversions.ToString(RuntimeHelpers.GetObjectValue(((Control)(Button)$VB$Local_sender).Tag));
				if (Operators.CompareString(Path.GetExtension($VB$Me.string_0), ".campaign", true) == 0)
				{
					((Control)$VB$Me.Label_SelectCampaign).Visible = false;
					$VB$ResumableLocal_theCamp$1 = Campaign.ReadFromFile($VB$Me.string_0);
					string firstScenarioFilename = $VB$ResumableLocal_theCamp$1.GetFirstScenarioFilename($VB$Me.string_0);
					ScenContainer scenContainer;
					try
					{
						scenContainer = ScenContainer.LoadFromFile(firstScenarioFilename);
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						DarkMessageBox.ShowError(ex2.Message, "Failed to loard Scenario");
						ProjectData.ClearProjectError();
						goto end_IL_0007;
					}
					$VB$ResumableLocal_ContentTag$0 = Scenario.QueryScenario_ScenXML(scenContainer.GetScenarioObject_AsXML(), "ContentTag");
					if (!Licensing.IsUserLicensedForThisContent($VB$ResumableLocal_ContentTag$0))
					{
						awaiter = Helper.smethod_1($VB$Me.WebBrowser1, "Scenarios\\LicenseMissingDisplay.html", Path.GetDirectoryName($VB$Me.string_0)).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = 0;
							$State = 0;
							$A0 = awaiter;
							$Builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
							return;
						}
						goto IL_0183;
					}
					((Control)$VB$Me.WebBrowser1).Visible = true;
					awaiter2 = Helper.smethod_1($VB$Me.WebBrowser1, $VB$ResumableLocal_theCamp$1.Description, Path.GetDirectoryName($VB$Me.string_0)).GetAwaiter();
					if (!awaiter2.IsCompleted)
					{
						num = 1;
						$State = 1;
						$A0 = awaiter2;
						$Builder.AwaitUnsafeOnCompleted(ref awaiter2, ref this);
						return;
					}
					goto IL_02fd;
				}
				goto end_IL_0007;
				IL_02fd:
				bool result = awaiter2.GetResult();
				awaiter2 = default(TaskAwaiter<bool>);
				if (!result)
				{
					Module1.RenderCustomHTML($VB$Me.WebBrowser1, $VB$ResumableLocal_theCamp$1.Description);
				}
				((Control)$VB$Me.Button1).Visible = true;
				goto end_IL_0007;
				IL_0183:
				bool result2 = awaiter.GetResult();
				awaiter = default(TaskAwaiter<bool>);
				if (!result2)
				{
					Licensing.ModuleLicenseRecord moduleLicenseRecord = Licensing.GetSelectedLicenseRecords(new List<Licensing.ModuleLicense> { Licensing.ModuleEnablingThisContent($VB$ResumableLocal_ContentTag$0) })[0];
					((Control)$VB$Me.WebBrowser1).Visible = true;
					string destinationURL_MG = moduleLicenseRecord.DestinationURL_MG;
					string path = Path.ChangeExtension($VB$Me.string_0, "png");
					string text;
					if (File.Exists("Scenarios\\LicenseMissingDisplay.html"))
					{
						text = File.ReadAllText("Scenarios\\LicenseMissingDisplay.html");
						string newValue = "data:image/png;base64," + Convert.ToBase64String(File.ReadAllBytes(path));
						text = text.Replace("YOUR_BUY_URL_HERE", destinationURL_MG);
						text = text.Replace("IMAGE_URL", newValue);
					}
					else
					{
						text = "<html><body>\r\n                                <h2>License Required</h2>\r\n                                <p>You need a license to play this campaign.</p>\r\n                                <a id='buyLink' href='#'>Get License</a>\r\n                                <script>document.getElementById('buyLink').addEventListener('click', function(e){e.preventDefault(); window.chrome.webview.postMessage('{{BUY_URL}}');});</script>\r\n                                </body></html>";
						text = text.Replace("{{BUY_URL}}", destinationURL_MG);
					}
					Module1.RenderCustomHTML($VB$Me.WebBrowser1, text);
				}
				end_IL_0007:;
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception exception = ex3;
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

		static VB$StateMachine_78_theButton_Click()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__72-0
	{
		public List<string> $VB$Local_theList;

		public int $VB$Local_SavesProcessed;

		public int $VB$Local_TotalSaves;

		public CampaignPlayWindow $VB$Me;

		public _Closure$__72-0(_Closure$__72-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theList = arg0.$VB$Local_theList;
				$VB$Local_SavesProcessed = arg0.$VB$Local_SavesProcessed;
				$VB$Local_TotalSaves = arg0.$VB$Local_TotalSaves;
			}
		}

		[SpecialName]
		internal void _Lambda$__0()
		{
			//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
			_Closure$__72-1 closure$__72- = default(_Closure$__72-1);
			_Closure$__72-3 closure$__72-2 = default(_Closure$__72-3);
			_Closure$__72-2 closure$__72-3 = default(_Closure$__72-2);
			string[] array = default(string[]);
			foreach (string item in $VB$Local_theList)
			{
				closure$__72- = new _Closure$__72-1(closure$__72-)
				{
					$VB$NonLocal_$VB$Closure_2 = this,
					$VB$Local_theCampaign = Campaign.ReadFromFile(item)
				};
				string? directoryName = Path.GetDirectoryName(item);
				closure$__72-.$VB$Local_CampaignNode = null;
				IEnumerable<string> enumerable = from theFN in Directory.GetFiles(directoryName, "*-*-*-*-*.save")
					orderby new FileInfo(theFN).CreationTime
					select theFN;
				if (enumerable.Count() <= 0)
				{
					continue;
				}
				if (!((Control)$VB$Me).Visible)
				{
					return;
				}
				((Control)$VB$Me.TGV_CampaignSaves).Invoke((Delegate)new VB$AnonymousDelegate_0(closure$__72-._Lambda$__2));
				((DataGridViewBand)closure$__72-.$VB$Local_CampaignNode).Tag = closure$__72-.$VB$Local_theCampaign;
				HashSet<string> hashSet = new HashSet<string>();
				using (IEnumerator<string> enumerator2 = enumerable.GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						closure$__72-2 = new _Closure$__72-3(closure$__72-2)
						{
							$VB$NonLocal_$VB$Closure_3 = closure$__72-,
							$VB$Local_theFileName = enumerator2.Current
						};
						if (Operators.CompareString(Path.GetExtension(closure$__72-2.$VB$Local_theFileName), ".save", true) != 0)
						{
							continue;
						}
						try
						{
							closure$__72-3 = new _Closure$__72-2(closure$__72-3)
							{
								$VB$NonLocal_$VB$Closure_4 = closure$__72-2
							};
							ScenContainer scenContainer = ScenContainer.LoadFromFile(closure$__72-3.$VB$NonLocal_$VB$Closure_4.$VB$Local_theFileName);
							string text;
							string text2;
							if (scenContainer.SaveCurrentTime == 0L)
							{
								List<string> queryKeys = new List<string> { "CampaignID", "CampaignSessionID", "Title", "Time" };
								try
								{
									array = Scenario.QueryScenario_ScenFileName(closure$__72-3.$VB$NonLocal_$VB$Closure_4.$VB$Local_theFileName, queryKeys);
								}
								catch (Exception ex)
								{
									ProjectData.SetProjectError(ex);
									Exception ex2 = ex;
									if (Debugger.IsAttached)
									{
										Debugger.Break();
									}
									DarkMessageBox.ShowError(ex2.Message, "Failed to loard Scenario");
									((Form)$VB$Me).Close();
									ProjectData.ClearProjectError();
								}
								text = array[0];
								closure$__72-3.$VB$Local_SaveFile_CampaignSessionID = array[1];
								closure$__72-3.$VB$Local_SaveFile_Title = array[2];
								text2 = array[3];
								scenContainer.CampaignID = text;
								scenContainer.CampaignSessionID = closure$__72-3.$VB$Local_SaveFile_CampaignSessionID;
								scenContainer.ScenTitle = closure$__72-3.$VB$Local_SaveFile_Title;
								scenContainer.SaveCurrentTime = Conversions.ToLong(text2);
								scenContainer.SaveToFile(closure$__72-3.$VB$NonLocal_$VB$Closure_4.$VB$Local_theFileName, PreserveOriginalTimestamps: true);
							}
							else
							{
								text = scenContainer.CampaignID;
								closure$__72-3.$VB$Local_SaveFile_CampaignSessionID = scenContainer.CampaignSessionID;
								closure$__72-3.$VB$Local_SaveFile_Title = scenContainer.ScenTitle;
								text2 = Conversions.ToString(scenContainer.SaveCurrentTime);
							}
							if (string.IsNullOrEmpty(text))
							{
								continue;
							}
							closure$__72-3.$VB$Local_SessionNode = null;
							if (hashSet.Contains(closure$__72-3.$VB$Local_SaveFile_CampaignSessionID))
							{
								closure$__72-3.$VB$Local_SessionNode = Module1.AllNodes((TreeGridView)$VB$Me.TGV_CampaignSaves).Where(closure$__72-3._Lambda$__3).ElementAtOrDefault(0);
							}
							else
							{
								hashSet.Add(closure$__72-3.$VB$Local_SaveFile_CampaignSessionID);
								if (!((Control)$VB$Me).Visible)
								{
									return;
								}
								((Control)$VB$Me.TGV_CampaignSaves).Invoke((Delegate)new VB$AnonymousDelegate_0(closure$__72-3._Lambda$__4));
								((DataGridViewBand)closure$__72-3.$VB$Local_SessionNode).Tag = "Session_" + closure$__72-3.$VB$Local_SaveFile_CampaignSessionID;
							}
							closure$__72-3.$VB$Local_ScenTime = DateTime.FromBinary(Conversions.ToLong(text2));
							if (scenContainer.IsCampaignCheckpoint)
							{
								closure$__72-3.$VB$Local_SaveFile_Title += " (Checkpoint)";
							}
							closure$__72-3.$VB$Local_SaveTime = File.GetLastWriteTime(closure$__72-3.$VB$NonLocal_$VB$Closure_4.$VB$Local_theFileName);
							closure$__72-3.$VB$Local_SaveNode = null;
							if (!((Control)$VB$Me).Visible)
							{
								return;
							}
							((Control)$VB$Me.TGV_CampaignSaves).Invoke((Delegate)new VB$AnonymousDelegate_0(closure$__72-3._Lambda$__5));
							((DataGridViewBand)closure$__72-3.$VB$Local_SaveNode).Tag = closure$__72-3.$VB$NonLocal_$VB$Closure_4.$VB$Local_theFileName;
						}
						catch (Exception ex3)
						{
							ProjectData.SetProjectError(ex3);
							Exception ex4 = ex3;
							ex4?.Data.Add("Error at 200374", ex4.Message);
							GameGeneral.WriteExceptionsToLog(ex4);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
					}
				}
				if (((Control)$VB$Me).Visible)
				{
					((Control)$VB$Me.TGV_CampaignSaves).Invoke((Delegate)new VB$AnonymousDelegate_0(closure$__72-._Lambda$__6));
					continue;
				}
				return;
			}
			if (((Control)$VB$Me).Visible)
			{
				((Control)$VB$Me.TGV_CampaignSaves).Invoke((Delegate)(VB$AnonymousDelegate_0)([SpecialName] () =>
				{
					((Control)$VB$Me.PB_CampaignSaves).Visible = false;
					Application.DoEvents();
				}));
			}
		}

		static _Closure$__72-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__72-1
	{
		public TreeGridNode $VB$Local_CampaignNode;

		public Campaign $VB$Local_theCampaign;

		public _Closure$__72-0 $VB$NonLocal_$VB$Closure_2;

		public _Closure$__72-1(_Closure$__72-1 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_CampaignNode = arg0.$VB$Local_CampaignNode;
				$VB$Local_theCampaign = arg0.$VB$Local_theCampaign;
			}
		}

		[SpecialName]
		internal void _Lambda$__2()
		{
			$VB$Local_CampaignNode = $VB$NonLocal_$VB$Closure_2.$VB$Me.TGV_CampaignSaves.Nodes.Add($VB$Local_theCampaign.Name);
			Application.DoEvents();
		}

		[SpecialName]
		internal void _Lambda$__6()
		{
			$VB$Local_CampaignNode.Expand();
			Application.DoEvents();
		}

		static _Closure$__72-1()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__72-2
	{
		public string $VB$Local_SaveFile_CampaignSessionID;

		public TreeGridNode $VB$Local_SessionNode;

		public TreeGridNode $VB$Local_SaveNode;

		public string $VB$Local_SaveFile_Title;

		public DateTime $VB$Local_ScenTime;

		public DateTime $VB$Local_SaveTime;

		public _Closure$__72-3 $VB$NonLocal_$VB$Closure_4;

		public _Closure$__72-2(_Closure$__72-2 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_SaveFile_CampaignSessionID = arg0.$VB$Local_SaveFile_CampaignSessionID;
				$VB$Local_SessionNode = arg0.$VB$Local_SessionNode;
				$VB$Local_SaveNode = arg0.$VB$Local_SaveNode;
				$VB$Local_SaveFile_Title = arg0.$VB$Local_SaveFile_Title;
				$VB$Local_ScenTime = arg0.$VB$Local_ScenTime;
				$VB$Local_SaveTime = arg0.$VB$Local_SaveTime;
			}
		}

		[SpecialName]
		internal bool _Lambda$__3(TreeGridNode theNode)
		{
			if ((object)((DataGridViewBand)theNode).Tag.GetType() == typeof(string))
			{
				return Operators.CompareString(Conversions.ToString(((DataGridViewBand)theNode).Tag), "Session_" + $VB$Local_SaveFile_CampaignSessionID, true) == 0;
			}
			return false;
		}

		[SpecialName]
		internal void _Lambda$__4()
		{
			$VB$Local_SessionNode = $VB$NonLocal_$VB$Closure_4.$VB$NonLocal_$VB$Closure_3.$VB$Local_CampaignNode.Nodes.Add("Session started at: " + new FileInfo($VB$NonLocal_$VB$Closure_4.$VB$Local_theFileName).CreationTime.ToShortDateString() + " " + new FileInfo($VB$NonLocal_$VB$Closure_4.$VB$Local_theFileName).CreationTime.ToShortTimeString());
			Application.DoEvents();
		}

		[SpecialName]
		internal void _Lambda$__5()
		{
			$VB$Local_SaveNode = $VB$Local_SessionNode.Nodes.Add($VB$Local_SaveFile_Title, $VB$Local_ScenTime, $VB$Local_SaveTime);
			$VB$NonLocal_$VB$Closure_4.$VB$NonLocal_$VB$Closure_3.$VB$NonLocal_$VB$Closure_2.$VB$Local_SavesProcessed = $VB$NonLocal_$VB$Closure_4.$VB$NonLocal_$VB$Closure_3.$VB$NonLocal_$VB$Closure_2.$VB$Local_SavesProcessed + 1;
			$VB$NonLocal_$VB$Closure_4.$VB$NonLocal_$VB$Closure_3.$VB$NonLocal_$VB$Closure_2.$VB$Me.PB_CampaignSaves.Value = (int)Math.Round(100.0 * ((double)$VB$NonLocal_$VB$Closure_4.$VB$NonLocal_$VB$Closure_3.$VB$NonLocal_$VB$Closure_2.$VB$Local_SavesProcessed / (double)$VB$NonLocal_$VB$Closure_4.$VB$NonLocal_$VB$Closure_3.$VB$NonLocal_$VB$Closure_2.$VB$Local_TotalSaves));
			Application.DoEvents();
		}

		static _Closure$__72-2()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__72-3
	{
		public string $VB$Local_theFileName;

		public _Closure$__72-1 $VB$NonLocal_$VB$Closure_3;

		public _Closure$__72-3(_Closure$__72-3 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theFileName = arg0.$VB$Local_theFileName;
			}
		}

		static _Closure$__72-3()
		{
			Class72.smethod_20();
		}
	}

	private IContainer icontainer_1;

	[AccessedThroughProperty("Button1")]
	[CompilerGenerated]
	private DarkUIButton YjjHxuXwSfp;

	[AccessedThroughProperty("TabControl1")]
	[CompilerGenerated]
	private DarkUITabControl mdaHxnaabct;

	[AccessedThroughProperty("TGV_CampaignSaves")]
	[CompilerGenerated]
	private DarkTreeGridView _TGV_CampaignSaves;

	[AccessedThroughProperty("Button4")]
	[CompilerGenerated]
	private DarkUIButton _Button4;

	[CompilerGenerated]
	[AccessedThroughProperty("Button3")]
	private DarkUIButton _Button3;

	[CompilerGenerated]
	[AccessedThroughProperty("Button2")]
	private DarkUIButton _Button2;

	private string string_0;

	[CompilerGenerated]
	[AccessedThroughProperty("theButton")]
	private Button button_0;

	private Queue<Tuple<string, string, string, string>> queue_0;

	[field: AccessedThroughProperty("WebBrowser1")]
	internal virtual WebView2 WebBrowser1 { get; set; }

	internal virtual DarkUIButton Button1
	{
		[CompilerGenerated]
		get
		{
			return YjjHxuXwSfp;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_4;
			DarkUIButton darkUIButton = YjjHxuXwSfp;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			YjjHxuXwSfp = value;
			darkUIButton = YjjHxuXwSfp;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUITabControl TabControl1
	{
		[CompilerGenerated]
		get
		{
			return mdaHxnaabct;
		}
		[CompilerGenerated]
		set
		{
			mdaHxnaabct = value;
		}
	}

	[field: AccessedThroughProperty("TabPage1")]
	internal virtual TabPage TabPage1 { get; set; }

	[field: AccessedThroughProperty("TabPage2")]
	internal virtual TabPage TabPage2 { get; set; }

	private virtual DarkTreeGridView TGV_CampaignSaves
	{
		[CompilerGenerated]
		get
		{
			return _TGV_CampaignSaves;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_6;
			DarkTreeGridView darkTreeGridView = _TGV_CampaignSaves;
			if (darkTreeGridView != null)
			{
				((DataGridView)darkTreeGridView).SelectionChanged -= eventHandler;
			}
			_TGV_CampaignSaves = value;
			darkTreeGridView = _TGV_CampaignSaves;
			if (darkTreeGridView != null)
			{
				((DataGridView)darkTreeGridView).SelectionChanged += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button4
	{
		[CompilerGenerated]
		get
		{
			return _Button4;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_7;
			DarkUIButton darkUIButton = _Button4;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button4 = value;
			darkUIButton = _Button4;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button3
	{
		[CompilerGenerated]
		get
		{
			return _Button3;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_5;
			DarkUIButton darkUIButton = _Button3;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button3 = value;
			darkUIButton = _Button3;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("FLP_CampaingSelect")]
	internal virtual FlowLayoutPanel FLP_CampaingSelect { get; set; }

	[field: AccessedThroughProperty("Label_SelectCampaign")]
	internal virtual DarkLabel Label_SelectCampaign { get; set; }

	internal virtual DarkUIButton Button2
	{
		[CompilerGenerated]
		get
		{
			return _Button2;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_12;
			DarkUIButton darkUIButton = _Button2;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button2 = value;
			darkUIButton = _Button2;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("PB_CampaignSaves")]
	internal virtual DarkUIProgressBar PB_CampaignSaves { get; set; }

	[field: AccessedThroughProperty("Column_Name")]
	internal virtual TreeGridColumn Column_Name { get; set; }

	[field: AccessedThroughProperty("Column_ScenTime")]
	internal virtual TreeGridColumn Column_ScenTime { get; set; }

	[field: AccessedThroughProperty("Column_SaveTime")]
	internal virtual TreeGridColumn Column_SaveTime { get; set; }

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
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Expected O, but got Unknown
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected O, but got Unknown
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Expected O, but got Unknown
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Expected O, but got Unknown
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02be: Expected O, but got Unknown
		//IL_03d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0445: Unknown result type (might be due to invalid IL or missing references)
		//IL_044f: Expected O, but got Unknown
		//IL_0490: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0507: Expected O, but got Unknown
		//IL_06b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0730: Unknown result type (might be due to invalid IL or missing references)
		//IL_073a: Expected O, but got Unknown
		//IL_07f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ff: Expected O, but got Unknown
		//IL_0840: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_08c3: Expected O, but got Unknown
		//IL_0900: Unknown result type (might be due to invalid IL or missing references)
		//IL_09d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e3: Expected O, but got Unknown
		//IL_0a8e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a98: Expected O, but got Unknown
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		Button1 = new DarkUIButton();
		WebBrowser1 = new WebView2();
		TabControl1 = new DarkUITabControl();
		TabPage1 = new TabPage();
		Button2 = new DarkUIButton();
		Label_SelectCampaign = new DarkLabel();
		FLP_CampaingSelect = new FlowLayoutPanel();
		TabPage2 = new TabPage();
		PB_CampaignSaves = new DarkUIProgressBar();
		Button4 = new DarkUIButton();
		Button3 = new DarkUIButton();
		TGV_CampaignSaves = new DarkTreeGridView();
		Column_Name = new TreeGridColumn();
		Column_ScenTime = new TreeGridColumn();
		Column_SaveTime = new TreeGridColumn();
		((ISupportInitialize)WebBrowser1).BeginInit();
		((Control)TabControl1).SuspendLayout();
		((Control)TabPage1).SuspendLayout();
		((Control)TabPage2).SuspendLayout();
		((ISupportInitialize)(object)TGV_CampaignSaves).BeginInit();
		((Control)this).SuspendLayout();
		((Control)Button1).Anchor = (AnchorStyles)6;
		((ButtonBase)Button1).BackColor = Color.Transparent;
		((Control)Button1).Font = new Font("Segoe UI", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)Button1).ForeColor = SystemColors.Control;
		((Control)Button1).Location = new Point(316, 508);
		((Control)Button1).Name = "Button1";
		((Control)Button1).Padding = new Padding(5);
		Button1.RoundRadius = 0;
		((Control)Button1).Size = new Size(253, 48);
		((Control)Button1).TabIndex = 17;
		Button1.Text = "START NEW CAMPAIGN";
		WebBrowser1.AllowExternalDrop = true;
		((Control)WebBrowser1).Anchor = (AnchorStyles)15;
		WebBrowser1.CreationProperties = null;
		WebBrowser1.DefaultBackgroundColor = Color.White;
		((Control)WebBrowser1).Location = new Point(316, 3);
		((Control)WebBrowser1).MinimumSize = new Size(20, 20);
		((Control)WebBrowser1).Name = "WebBrowser1";
		((Control)WebBrowser1).Size = new Size(687, 502);
		((Control)WebBrowser1).TabIndex = 16;
		WebBrowser1.ZoomFactor = 1.0;
		((Control)TabControl1).Controls.Add((Control)(object)TabPage1);
		((Control)TabControl1).Controls.Add((Control)(object)TabPage2);
		((Control)TabControl1).Cursor = Cursors.Hand;
		((Control)TabControl1).Dock = (DockStyle)5;
		((Control)TabControl1).Font = new Font("Segoe UI", 8f);
		((TabControl)TabControl1).ItemSize = new Size(80, 20);
		((Control)TabControl1).Location = new Point(0, 0);
		((Control)TabControl1).Name = "TabControl1";
		((TabControl)TabControl1).SelectedIndex = 0;
		((Control)TabControl1).Size = new Size(1014, 588);
		((Control)TabControl1).TabIndex = 19;
		TabPage1.BackColor = Color.FromArgb(60, 63, 65);
		((Control)TabPage1).Controls.Add((Control)(object)Button2);
		((Control)TabPage1).Controls.Add((Control)(object)Label_SelectCampaign);
		((Control)TabPage1).Controls.Add((Control)(object)FLP_CampaingSelect);
		((Control)TabPage1).Controls.Add((Control)(object)WebBrowser1);
		((Control)TabPage1).Controls.Add((Control)(object)Button1);
		TabPage1.Location = new Point(4, 24);
		((Control)TabPage1).Name = "TabPage1";
		((Control)TabPage1).Padding = new Padding(3);
		((Control)TabPage1).Size = new Size(1006, 560);
		TabPage1.TabIndex = 0;
		TabPage1.Text = "Start new campaign";
		((Control)Button2).Anchor = (AnchorStyles)10;
		((ButtonBase)Button2).BackColor = Color.Transparent;
		((Control)Button2).Font = new Font("Segoe UI", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Button2).ForeColor = SystemColors.Control;
		((Control)Button2).Location = new Point(750, 508);
		((Control)Button2).Name = "Button2";
		((Control)Button2).Padding = new Padding(5);
		Button2.RoundRadius = 0;
		((Control)Button2).Size = new Size(253, 48);
		((Control)Button2).TabIndex = 20;
		Button2.Text = "CANCEL";
		Label_SelectCampaign.AutoSize = true;
		((Control)Label_SelectCampaign).Font = new Font("Segoe UI", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)Label_SelectCampaign).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_SelectCampaign).Location = new Point(317, 4);
		((Control)Label_SelectCampaign).Name = "Label_SelectCampaign";
		((Control)Label_SelectCampaign).Size = new Size(666, 64);
		((Control)Label_SelectCampaign).TabIndex = 19;
		((Label)Label_SelectCampaign).Text = "Select one of the campaigns available to start a new session, \r\nor resume an existing campaign session from a save.";
		((Control)FLP_CampaingSelect).Anchor = (AnchorStyles)7;
		((ScrollableControl)FLP_CampaingSelect).AutoScroll = true;
		((Control)FLP_CampaingSelect).BackColor = Color.FromArgb(43, 43, 43);
		((Panel)FLP_CampaingSelect).BorderStyle = (BorderStyle)1;
		FLP_CampaingSelect.FlowDirection = (FlowDirection)1;
		((Control)FLP_CampaingSelect).Location = new Point(0, 0);
		((Control)FLP_CampaingSelect).Name = "FLP_CampaingSelect";
		((Control)FLP_CampaingSelect).Size = new Size(305, 562);
		((Control)FLP_CampaingSelect).TabIndex = 18;
		FLP_CampaingSelect.WrapContents = false;
		TabPage2.BackColor = Color.FromArgb(60, 63, 65);
		((Control)TabPage2).Controls.Add((Control)(object)PB_CampaignSaves);
		((Control)TabPage2).Controls.Add((Control)(object)Button4);
		((Control)TabPage2).Controls.Add((Control)(object)Button3);
		((Control)TabPage2).Controls.Add((Control)(object)TGV_CampaignSaves);
		TabPage2.Location = new Point(4, 24);
		((Control)TabPage2).Name = "TabPage2";
		((Control)TabPage2).Padding = new Padding(3);
		((Control)TabPage2).Size = new Size(1006, 560);
		TabPage2.TabIndex = 1;
		TabPage2.Text = "Resume from save";
		((Control)PB_CampaignSaves).Anchor = (AnchorStyles)12;
		((Control)PB_CampaignSaves).BackColor = Color.Transparent;
		PB_CampaignSaves.CustomForeColor = Color.Transparent;
		((Control)PB_CampaignSaves).Font = new Font("Segoe UI", 9f);
		((Control)PB_CampaignSaves).Location = new Point(346, 521);
		PB_CampaignSaves.Maximum = 100;
		((Control)PB_CampaignSaves).Name = "PB_CampaignSaves";
		PB_CampaignSaves.ShowProgressLines = true;
		PB_CampaignSaves.ShowProgressValue = true;
		PB_CampaignSaves.ShowText = false;
		((Control)PB_CampaignSaves).Size = new Size(340, 33);
		((Control)PB_CampaignSaves).TabIndex = 11;
		PB_CampaignSaves.Value = 0;
		((Control)Button4).Anchor = (AnchorStyles)10;
		((ButtonBase)Button4).BackColor = Color.Transparent;
		((Control)Button4).Font = new Font("Segoe UI", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Button4).ForeColor = SystemColors.Control;
		((Control)Button4).Location = new Point(773, 521);
		((Control)Button4).Name = "Button4";
		((Control)Button4).Padding = new Padding(5);
		Button4.RoundRadius = 0;
		((Control)Button4).Size = new Size(225, 33);
		((Control)Button4).TabIndex = 10;
		Button4.Text = "Delete selected save";
		((Control)Button3).Anchor = (AnchorStyles)6;
		((ButtonBase)Button3).BackColor = Color.Transparent;
		((Control)Button3).Font = new Font("Segoe UI", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Button3).ForeColor = SystemColors.Control;
		((Control)Button3).Location = new Point(3, 521);
		((Control)Button3).Name = "Button3";
		((Control)Button3).Padding = new Padding(5);
		Button3.RoundRadius = 0;
		((Control)Button3).Size = new Size(223, 33);
		((Control)Button3).TabIndex = 9;
		Button3.Text = "Resume from selected save";
		((DataGridView)TGV_CampaignSaves).AllowUserToAddRows = false;
		((DataGridView)TGV_CampaignSaves).AllowUserToDeleteRows = false;
		((DataGridView)TGV_CampaignSaves).AllowUserToOrderColumns = true;
		((Control)TGV_CampaignSaves).Anchor = (AnchorStyles)15;
		((DataGridView)TGV_CampaignSaves).BackgroundColor = Color.FromArgb(43, 43, 43);
		((DataGridView)TGV_CampaignSaves).BorderStyle = (BorderStyle)0;
		((DataGridView)TGV_CampaignSaves).CellBorderStyle = (DataGridViewCellBorderStyle)4;
		((DataGridView)TGV_CampaignSaves).ColumnHeadersBorderStyle = (DataGridViewHeaderBorderStyle)4;
		val.Alignment = (DataGridViewContentAlignment)16;
		val.BackColor = Color.FromArgb(66, 77, 95);
		val.Font = new Font("Segoe UI", 8f);
		val.ForeColor = Color.LightGray;
		val.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val.SelectionForeColor = Color.FromArgb(122, 128, 132);
		val.WrapMode = (DataGridViewTriState)1;
		((DataGridView)TGV_CampaignSaves).ColumnHeadersDefaultCellStyle = val;
		((DataGridView)TGV_CampaignSaves).ColumnHeadersHeight = 34;
		((DataGridView)TGV_CampaignSaves).Columns.AddRange((DataGridViewColumn[])(object)new DataGridViewColumn[3]
		{
			(DataGridViewColumn)Column_Name,
			(DataGridViewColumn)Column_ScenTime,
			(DataGridViewColumn)Column_SaveTime
		});
		val2.Alignment = (DataGridViewContentAlignment)16;
		val2.BackColor = Color.FromArgb(60, 63, 65);
		val2.Font = new Font("Segoe UI", 8f);
		val2.ForeColor = Color.LightGray;
		val2.SelectionBackColor = SystemColors.Highlight;
		val2.SelectionForeColor = SystemColors.HighlightText;
		val2.WrapMode = (DataGridViewTriState)2;
		((DataGridView)TGV_CampaignSaves).DefaultCellStyle = val2;
		((DataGridView)TGV_CampaignSaves).EditMode = (DataGridViewEditMode)4;
		((DataGridView)TGV_CampaignSaves).EnableHeadersVisualStyles = false;
		TGV_CampaignSaves.ImageList = null;
		((Control)TGV_CampaignSaves).Location = new Point(3, 3);
		((DataGridView)TGV_CampaignSaves).MultiSelect = false;
		((Control)TGV_CampaignSaves).Name = "TGV_CampaignSaves";
		((DataGridView)TGV_CampaignSaves).RowHeadersVisible = false;
		((DataGridView)TGV_CampaignSaves).RowHeadersWidth = 20;
		((DataGridView)TGV_CampaignSaves).SelectionMode = (DataGridViewSelectionMode)1;
		TGV_CampaignSaves.ShowLines = false;
		((Control)TGV_CampaignSaves).Size = new Size(997, 500);
		((Control)TGV_CampaignSaves).TabIndex = 8;
		((DataGridViewColumn)Column_Name).AutoSizeMode = (DataGridViewAutoSizeColumnMode)16;
		Column_Name.DefaultNodeImage = null;
		((DataGridViewColumn)Column_Name).HeaderText = "Name";
		((DataGridViewColumn)Column_Name).MinimumWidth = 8;
		((DataGridViewColumn)Column_Name).Name = "Column_Name";
		((DataGridViewColumn)Column_Name).ReadOnly = true;
		((DataGridViewColumn)Column_Name).Resizable = (DataGridViewTriState)1;
		((DataGridViewTextBoxColumn)Column_Name).SortMode = (DataGridViewColumnSortMode)0;
		((DataGridViewColumn)Column_ScenTime).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		Column_ScenTime.DefaultNodeImage = null;
		((DataGridViewColumn)Column_ScenTime).HeaderText = "Scenario Time";
		((DataGridViewColumn)Column_ScenTime).MinimumWidth = 8;
		((DataGridViewColumn)Column_ScenTime).Name = "Column_ScenTime";
		((DataGridViewColumn)Column_ScenTime).ReadOnly = true;
		((DataGridViewColumn)Column_ScenTime).Resizable = (DataGridViewTriState)1;
		((DataGridViewTextBoxColumn)Column_ScenTime).SortMode = (DataGridViewColumnSortMode)0;
		((DataGridViewColumn)Column_ScenTime).Width = 112;
		((DataGridViewColumn)Column_SaveTime).AutoSizeMode = (DataGridViewAutoSizeColumnMode)6;
		Column_SaveTime.DefaultNodeImage = null;
		((DataGridViewColumn)Column_SaveTime).HeaderText = "Save Actual Time";
		((DataGridViewColumn)Column_SaveTime).MinimumWidth = 8;
		((DataGridViewColumn)Column_SaveTime).Name = "Column_SaveTime";
		((DataGridViewColumn)Column_SaveTime).ReadOnly = true;
		((DataGridViewColumn)Column_SaveTime).Resizable = (DataGridViewTriState)1;
		((DataGridViewTextBoxColumn)Column_SaveTime).SortMode = (DataGridViewColumnSortMode)0;
		((DataGridViewColumn)Column_SaveTime).Width = 132;
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(1014, 588);
		((Control)this).Controls.Add((Control)(object)TabControl1);
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "CampaignPlayWindow";
		((Form)this).ShowIcon = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Campaigns";
		((ISupportInitialize)WebBrowser1).EndInit();
		((Control)TabControl1).ResumeLayout(false);
		((Control)TabPage1).ResumeLayout(false);
		((Control)TabPage1).PerformLayout();
		((Control)TabPage2).ResumeLayout(false);
		((ISupportInitialize)(object)TGV_CampaignSaves).EndInit();
		((Control)this).ResumeLayout(false);
	}

	[SpecialName]
	[CompilerGenerated]
	private virtual Button vmethod_0()
	{
		return button_0;
	}

	[SpecialName]
	[CompilerGenerated]
	private virtual void vmethod_1(Button WithEventsValue)
	{
		button_0 = WithEventsValue;
	}

	public CampaignPlayWindow()
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		((Form)this).FormClosed += new FormClosedEventHandler(CampaignPlayWindow_FormClosed);
		((Form)this).Load += CampaignPlayWindow_Load;
		((Form)this).Shown += CampaignPlayWindow_Shown;
		queue_0 = new Queue<Tuple<string, string, string, string>>();
		InitializeComponent_1();
		Module1.ShowScrollBar(((Control)FLP_CampaingSelect).Handle, 1, bShow: true);
	}

	private void method_2()
	{
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected O, but got Unknown
		((Control)FLP_CampaingSelect).Controls.Clear();
		List<string> list = new List<string>();
		Campaign.GetCampaignsInFolder(GameGeneral.ScenariosRootPath, list);
		list = list.OrderByDescending([SpecialName] (string theFilename) => new FileInfo(theFilename).CreationTimeUtc).ToList();
		foreach (string item in list)
		{
			Campaign.ReadFromFile(item);
			vmethod_1(new Button());
			((Control)vmethod_0()).Height = 135;
			((Control)vmethod_0()).Width = 280;
			if (FileExistsNative.FileExistsFast(Path.ChangeExtension(item, "png")))
			{
				((ButtonBase)vmethod_0()).Image = Image.FromFile(Path.ChangeExtension(item, "png"));
			}
			else
			{
				((ButtonBase)vmethod_0()).Image = Image.FromFile(Path.Combine(Application.StartupPath, "Command.ico"));
			}
			((Control)vmethod_0()).Tag = item;
			((Control)FLP_CampaingSelect).Controls.Add((Control)(object)vmethod_0());
			((Control)vmethod_0()).Click += method_8;
			((Control)vmethod_0()).MouseEnter += method_10;
			((Control)vmethod_0()).MouseLeave += method_11;
		}
	}

	private void CampaignPlayWindow_FormClosed(object sender, FormClosedEventArgs e)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		foreach (object control in ((Control)FLP_CampaingSelect).Controls)
		{
			object objectValue = RuntimeHelpers.GetObjectValue(control);
			vmethod_1((Button)objectValue);
			((Control)vmethod_0()).Click -= method_8;
			((Control)vmethod_0()).MouseEnter -= method_10;
			((Control)vmethod_0()).MouseLeave -= method_11;
		}
	}

	private void method_3()
	{
		_Closure$__72-0 arg = default(_Closure$__72-0);
		_Closure$__72-0 CS$<>8__locals22 = new _Closure$__72-0(arg);
		CS$<>8__locals22.$VB$Me = this;
		TGV_CampaignSaves.Nodes.Clear();
		CS$<>8__locals22.$VB$Local_theList = new List<string>();
		Campaign.GetCampaignsInFolder(GameGeneral.ScenariosRootPath, CS$<>8__locals22.$VB$Local_theList);
		CS$<>8__locals22.$VB$Local_TotalSaves = 0;
		foreach (string item in CS$<>8__locals22.$VB$Local_theList)
		{
			string directoryName = Path.GetDirectoryName(item);
			CS$<>8__locals22.$VB$Local_TotalSaves += Directory.GetFiles(directoryName, "*-*-*-*-*.save").Count();
		}
		((Control)PB_CampaignSaves).Visible = true;
		CS$<>8__locals22.$VB$Local_SavesProcessed = 0;
		Application.DoEvents();
		Task.Factory.StartNew([SpecialName] () =>
		{
			//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
			_Closure$__72-1 closure$__72- = default(_Closure$__72-1);
			_Closure$__72-3 closure$__72-2 = default(_Closure$__72-3);
			_Closure$__72-2 closure$__72-3 = default(_Closure$__72-2);
			string[] array = default(string[]);
			foreach (string item2 in CS$<>8__locals22.$VB$Local_theList)
			{
				closure$__72- = new _Closure$__72-1(closure$__72-);
				closure$__72-.$VB$NonLocal_$VB$Closure_2 = CS$<>8__locals22;
				closure$__72-.$VB$Local_theCampaign = Campaign.ReadFromFile(item2);
				string? directoryName2 = Path.GetDirectoryName(item2);
				closure$__72-.$VB$Local_CampaignNode = null;
				IEnumerable<string> enumerable = from theFN in Directory.GetFiles(directoryName2, "*-*-*-*-*.save")
					orderby new FileInfo(theFN).CreationTime
					select theFN;
				if (enumerable.Count() > 0)
				{
					if (!((Control)CS$<>8__locals22.$VB$Me).Visible)
					{
						return;
					}
					((Control)CS$<>8__locals22.$VB$Me.TGV_CampaignSaves).Invoke((Delegate)new VB$AnonymousDelegate_0(closure$__72-._Lambda$__2));
					((DataGridViewBand)closure$__72-.$VB$Local_CampaignNode).Tag = closure$__72-.$VB$Local_theCampaign;
					HashSet<string> hashSet = new HashSet<string>();
					using (IEnumerator<string> enumerator3 = enumerable.GetEnumerator())
					{
						while (enumerator3.MoveNext())
						{
							closure$__72-2 = new _Closure$__72-3(closure$__72-2);
							closure$__72-2.$VB$NonLocal_$VB$Closure_3 = closure$__72-;
							closure$__72-2.$VB$Local_theFileName = enumerator3.Current;
							if (Operators.CompareString(Path.GetExtension(closure$__72-2.$VB$Local_theFileName), ".save", true) == 0)
							{
								try
								{
									closure$__72-3 = new _Closure$__72-2(closure$__72-3);
									closure$__72-3.$VB$NonLocal_$VB$Closure_4 = closure$__72-2;
									ScenContainer scenContainer = ScenContainer.LoadFromFile(closure$__72-3.$VB$NonLocal_$VB$Closure_4.$VB$Local_theFileName);
									string text;
									string text2;
									if (scenContainer.SaveCurrentTime == 0L)
									{
										List<string> queryKeys = new List<string> { "CampaignID", "CampaignSessionID", "Title", "Time" };
										try
										{
											array = Scenario.QueryScenario_ScenFileName(closure$__72-3.$VB$NonLocal_$VB$Closure_4.$VB$Local_theFileName, queryKeys);
										}
										catch (Exception ex)
										{
											ProjectData.SetProjectError(ex);
											Exception ex2 = ex;
											if (Debugger.IsAttached)
											{
												Debugger.Break();
											}
											DarkMessageBox.ShowError(ex2.Message, "Failed to loard Scenario");
											((Form)CS$<>8__locals22.$VB$Me).Close();
											ProjectData.ClearProjectError();
										}
										text = array[0];
										closure$__72-3.$VB$Local_SaveFile_CampaignSessionID = array[1];
										closure$__72-3.$VB$Local_SaveFile_Title = array[2];
										text2 = array[3];
										scenContainer.CampaignID = text;
										scenContainer.CampaignSessionID = closure$__72-3.$VB$Local_SaveFile_CampaignSessionID;
										scenContainer.ScenTitle = closure$__72-3.$VB$Local_SaveFile_Title;
										scenContainer.SaveCurrentTime = Conversions.ToLong(text2);
										scenContainer.SaveToFile(closure$__72-3.$VB$NonLocal_$VB$Closure_4.$VB$Local_theFileName, PreserveOriginalTimestamps: true);
									}
									else
									{
										text = scenContainer.CampaignID;
										closure$__72-3.$VB$Local_SaveFile_CampaignSessionID = scenContainer.CampaignSessionID;
										closure$__72-3.$VB$Local_SaveFile_Title = scenContainer.ScenTitle;
										text2 = Conversions.ToString(scenContainer.SaveCurrentTime);
									}
									if (!string.IsNullOrEmpty(text))
									{
										closure$__72-3.$VB$Local_SessionNode = null;
										if (hashSet.Contains(closure$__72-3.$VB$Local_SaveFile_CampaignSessionID))
										{
											closure$__72-3.$VB$Local_SessionNode = Module1.AllNodes((TreeGridView)CS$<>8__locals22.$VB$Me.TGV_CampaignSaves).Where(closure$__72-3._Lambda$__3).ElementAtOrDefault(0);
										}
										else
										{
											hashSet.Add(closure$__72-3.$VB$Local_SaveFile_CampaignSessionID);
											if (!((Control)CS$<>8__locals22.$VB$Me).Visible)
											{
												return;
											}
											((Control)CS$<>8__locals22.$VB$Me.TGV_CampaignSaves).Invoke((Delegate)new VB$AnonymousDelegate_0(closure$__72-3._Lambda$__4));
											((DataGridViewBand)closure$__72-3.$VB$Local_SessionNode).Tag = "Session_" + closure$__72-3.$VB$Local_SaveFile_CampaignSessionID;
										}
										closure$__72-3.$VB$Local_ScenTime = DateTime.FromBinary(Conversions.ToLong(text2));
										if (scenContainer.IsCampaignCheckpoint)
										{
											closure$__72-3.$VB$Local_SaveFile_Title += " (Checkpoint)";
										}
										closure$__72-3.$VB$Local_SaveTime = File.GetLastWriteTime(closure$__72-3.$VB$NonLocal_$VB$Closure_4.$VB$Local_theFileName);
										closure$__72-3.$VB$Local_SaveNode = null;
										if (!((Control)CS$<>8__locals22.$VB$Me).Visible)
										{
											return;
										}
										((Control)CS$<>8__locals22.$VB$Me.TGV_CampaignSaves).Invoke((Delegate)new VB$AnonymousDelegate_0(closure$__72-3._Lambda$__5));
										((DataGridViewBand)closure$__72-3.$VB$Local_SaveNode).Tag = closure$__72-3.$VB$NonLocal_$VB$Closure_4.$VB$Local_theFileName;
									}
								}
								catch (Exception ex3)
								{
									ProjectData.SetProjectError(ex3);
									Exception ex4 = ex3;
									ex4?.Data.Add("Error at 200374", ex4.Message);
									GameGeneral.WriteExceptionsToLog(ex4);
									if (Debugger.IsAttached)
									{
										Debugger.Break();
									}
									ProjectData.ClearProjectError();
								}
							}
						}
					}
					if (!((Control)CS$<>8__locals22.$VB$Me).Visible)
					{
						return;
					}
					((Control)CS$<>8__locals22.$VB$Me.TGV_CampaignSaves).Invoke((Delegate)new VB$AnonymousDelegate_0(closure$__72-._Lambda$__6));
				}
			}
			if (((Control)CS$<>8__locals22.$VB$Me).Visible)
			{
				((Control)CS$<>8__locals22.$VB$Me.TGV_CampaignSaves).Invoke((Delegate)(VB$AnonymousDelegate_0)([SpecialName] () =>
				{
					((Control)CS$<>8__locals22.$VB$Me.PB_CampaignSaves).Visible = false;
					Application.DoEvents();
				}));
			}
		});
	}

	private void CampaignPlayWindow_Load(object sender, EventArgs e)
	{
		WebBrowserHelper.InitialiseWebview2Browser(WebBrowser1);
		((Control)WebBrowser1).Visible = false;
		WebBrowser1.CoreWebView2InitializationCompleted += [SpecialName] (object obj, CoreWebView2InitializationCompletedEventArgs e2) =>
		{
			WebBrowser1.CoreWebView2.WebMessageReceived += [SpecialName] (object obj2, CoreWebView2WebMessageReceivedEventArgs e3) =>
			{
				string string_ = e3.TryGetWebMessageAsString();
				method_9(string_);
			};
		};
		((ScrollProperties)((ScrollableControl)FLP_CampaingSelect).VerticalScroll).Visible = true;
		method_2();
		((Control)Button1).Visible = false;
		Application.DoEvents();
	}

	private void method_4(object sender, EventArgs e)
	{
		if (string.IsNullOrEmpty(string_0) || Operators.CompareString(Path.GetExtension(string_0), ".campaign", true) != 0)
		{
			return;
		}
		Campaign campaign = Campaign.ReadFromFile(string_0);
		AttachmentRepoManager.MoveAttachmentsToLocalRepo(Path.GetDirectoryName(string_0));
		using List<Campaign.CampaignItem>.Enumerator enumerator = campaign.CampaignItems.GetEnumerator();
		Campaign.CampaignItem current;
		while (true)
		{
			if (enumerator.MoveNext())
			{
				current = enumerator.Current;
				Type type = current.GetType();
				if (type == typeof(Campaign.ScenarioRecord))
				{
					break;
				}
				if (type == typeof(Campaign.AttachmentRecord))
				{
					LuaSAO.ScenEdit_UseAttachment(((Campaign.AttachmentRecord)current).ID, null);
				}
				continue;
			}
			return;
		}
		string scenFileName = Path.GetDirectoryName(string_0) + "\\" + ((Campaign.ScenarioRecord)current).FileName;
		MyProject.Forms.CampaignScenarioWindow.SelectedCampaign = campaign;
		MyProject.Forms.CampaignScenarioWindow.ScenFileName = scenFileName;
		MyProject.Forms.CampaignScenarioWindow.CampaignSessionID = Guid.NewGuid().ToString();
		MyProject.Forms.CampaignScenarioWindow.CampaignScore = 0;
		MyProject.Forms.CampaignScenarioWindow.LuaXml = "";
		((Control)MyProject.Forms.CampaignScenarioWindow).Show();
		((Form)this).Close();
	}

	private void method_5(object sender, EventArgs e)
	{
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		if (TGV_CampaignSaves.CurrentNode == null || Operators.CompareString(Path.GetExtension(string_0), ".save", true) != 0)
		{
			return;
		}
		Client.CurrentGame.GameMode = Game._GameMode.SinglePlayer;
		ScenContainer scenContainer;
		try
		{
			scenContainer = ScenContainer.LoadFromFile(string_0);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			DarkMessageBox.ShowError(ex2.Message, "Failed to load Scenario");
			ProjectData.ClearProjectError();
			return;
		}
		if (scenContainer.IsCampaignCheckpoint)
		{
			string directoryName = Path.GetDirectoryName(string_0);
			try
			{
				string text = scenContainer.CampaignID;
				if (string.IsNullOrEmpty(text))
				{
					text = Scenario.QueryScenario_ScenFileName(string_0, "CampaignID");
				}
				string text2 = scenContainer.CampaignSessionID;
				if (string.IsNullOrEmpty(text2))
				{
					text2 = Scenario.QueryScenario_ScenFileName(string_0, "CampaignSessionID");
				}
				if (!string.IsNullOrEmpty(text))
				{
					Campaign campaignByID = Campaign.GetCampaignByID(GameGeneral.ScenariosRootPath, text);
					if (campaignByID != null)
					{
						string text3 = Scenario.QueryScenario_ScenFileName(string_0, "ObjectID");
						if (!string.IsNullOrEmpty(text3))
						{
							Campaign.ScenarioRecord scenarioRecord = campaignByID.GetScenarioRecord(text3);
							if (scenarioRecord != null)
							{
								string_0 = Path.Combine(directoryName, scenarioRecord.FileName);
								MyProject.Forms.ResumeFromSave.CampaignSessionID = text2;
							}
						}
					}
				}
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				DarkMessageBox.ShowError(ex4.Message, "Failed to load campaign information");
				ProjectData.ClearProjectError();
				return;
			}
		}
		MyProject.Forms.ResumeFromSave.SelectedFilename = string_0;
		((Control)MyProject.Forms.ResumeFromSave).Show();
		if (Client.CurrentGame.GameMode != Game._GameMode.SinglePlayer)
		{
			Client.CurrentGame.GameMode = Game._GameMode.SinglePlayer;
		}
		((Form)this).Close();
	}

	private void method_6(object sender, EventArgs e)
	{
		if (Information.IsNothing((object)TGV_CampaignSaves.CurrentNode))
		{
			Button3.Enabled = false;
		}
		else if ((object)((DataGridViewBand)TGV_CampaignSaves.CurrentNode).Tag.GetType() == typeof(string) && !Conversions.ToString(((DataGridViewBand)TGV_CampaignSaves.CurrentNode).Tag).StartsWith("Session_"))
		{
			string_0 = Conversions.ToString(((DataGridViewBand)TGV_CampaignSaves.CurrentNode).Tag);
			Button3.Enabled = true;
		}
		else
		{
			Button3.Enabled = false;
		}
	}

	private void method_7(object sender, EventArgs e)
	{
		if (TGV_CampaignSaves.CurrentNode != null && !string.IsNullOrEmpty(string_0) && Operators.CompareString(Path.GetExtension(string_0), ".save", true) == 0)
		{
			File.Delete(string_0);
			TGV_CampaignSaves.CurrentNode.Parent.Nodes.Remove(TGV_CampaignSaves.CurrentNode);
			string_0 = null;
		}
	}

	[AsyncStateMachine(typeof(VB$StateMachine_78_theButton_Click))]
	private void method_8(object sender, EventArgs e)
	{
		VB$StateMachine_78_theButton_Click stateMachine = default(VB$StateMachine_78_theButton_Click);
		stateMachine.$VB$Me = this;
		stateMachine.$VB$Local_sender = sender;
		stateMachine.$VB$Local_e = e;
		stateMachine.$State = -1;
		stateMachine.$Builder = AsyncVoidMethodBuilder.Create();
		stateMachine.$Builder.Start(ref stateMachine);
	}

	private void method_9(string string_1)
	{
		if (!string.IsNullOrWhiteSpace(string_1))
		{
			Process.Start(new ProcessStartInfo(string_1)
			{
				UseShellExecute = true
			});
		}
	}

	private void method_10(object sender, EventArgs e)
	{
		((Control)this).Cursor = Cursors.Hand;
	}

	private void method_11(object sender, EventArgs e)
	{
		((Control)this).Cursor = Cursors.Arrow;
	}

	private void method_12(object sender, EventArgs e)
	{
		StartGameMenuWindow.ShowStartWindow();
		((Form)this).Close();
	}

	private void CampaignPlayWindow_Shown(object sender, EventArgs e)
	{
		Application.DoEvents();
		method_3();
	}

	static CampaignPlayWindow()
	{
		Class72.smethod_20();
	}
}
