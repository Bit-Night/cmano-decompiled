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
using Command_Core;
using Command_Core.Lua;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using NLua;

namespace Command;

[DesignerGenerated]
public class AdvancedDialog : Form
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct VB$StateMachine_34_CallHTMLDialog : IAsyncStateMachine
	{
		public int $State;

		public AsyncTaskMethodBuilder<Dictionary<string, string>> $Builder;

		internal string $VB$Local_Title;

		internal string $VB$Local_Html;

		internal string[] $VB$Local__Interactions;

		internal TaskAwaiter<Dictionary<string, string>> $A0;

		[CompilerGenerated]
		internal void MoveNext()
		{
			//IL_0116: Unknown result type (might be due to invalid IL or missing references)
			//IL_0119: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_012d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0130: Invalid comparison between Unknown and I4
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_0126: Unknown result type (might be due to invalid IL or missing references)
			//IL_012b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0132: Unknown result type (might be due to invalid IL or missing references)
			//IL_0135: Invalid comparison between Unknown and I4
			int num = $State;
			Dictionary<string, string> result = default(Dictionary<string, string>);
			try
			{
				if (num != -3)
				{
				}
				try
				{
					if (num == -3)
					{
						num = -1;
						$State = -1;
						return;
					}
					TaskAwaiter<Dictionary<string, string>> awaiter;
					if (num == 0)
					{
						num = -1;
						$State = -1;
						awaiter = $A0;
						$A0 = default(TaskAwaiter<Dictionary<string, string>>);
						goto IL_017c;
					}
					new Dictionary<string, string>();
					if (!string.IsNullOrEmpty($VB$Local_Title))
					{
						string text = GameGeneral.TopLevelWritablePath + "/" + $VB$Local_Title;
						if (FileExistsNative.FileExistsFast(text))
						{
							StreamReader streamReader = new StreamReader(text);
							StreamReader streamReader2 = streamReader;
							try
							{
								$VB$Local_Html = streamReader.ReadToEnd();
							}
							finally
							{
								if (num < 0)
								{
									((IDisposable)streamReader2)?.Dispose();
								}
							}
						}
					}
					AdvancedDialog advancedDialog = new AdvancedDialog();
					advancedDialog.PopulateButtons($VB$Local__Interactions);
					((Control)advancedDialog.TB_Main).Enabled = false;
					((Control)advancedDialog.TB_Main).Visible = false;
					((Control)advancedDialog.WebBrowser1).Visible = true;
					int num2;
					if ($VB$Local_Html.StartsWith("<!DOCTYPE"))
					{
						Module1.RenderCustomHTML(advancedDialog.WebBrowser1, "", $VB$Local_Html, advancedDialog);
						num2 = 0;
					}
					else
					{
						Module1.RenderCustomHTML(advancedDialog.WebBrowser1, $VB$Local_Html, "", advancedDialog);
						num2 = 0;
					}
					DialogResult val = (DialogResult)num2;
					val = ((Form)advancedDialog).ShowDialog();
					while ((int)val == 4)
					{
						val = (DialogResult)0;
						val = ((Form)advancedDialog).ShowDialog();
					}
					if ((int)val == 1)
					{
						new Dictionary<string, string>();
						awaiter = WebBrowserHelper.smethod_0(advancedDialog.WebBrowser1).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = 0;
							$State = 0;
							$A0 = awaiter;
							$Builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
							return;
						}
						goto IL_017c;
					}
					result = new Dictionary<string, string>();
					goto end_IL_0010;
					IL_017c:
					Dictionary<string, string> result2 = awaiter.GetResult();
					awaiter = default(TaskAwaiter<Dictionary<string, string>>);
					result2["pressed"] = LastInteraction;
					PrivateMethods.ReturnTable = result2;
					result = result2;
					end_IL_0010:;
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
			$Builder.SetResult(result);
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

		static VB$StateMachine_34_CallHTMLDialog()
		{
			Class72.smethod_20();
		}
	}

	private IContainer icontainer_0;

	public static string LastInteraction;

	public HashSet<string> Interactions;

	private Dictionary<string, string> dictionary_0;

	public LuaTable CachedInputs;

	[field: AccessedThroughProperty("InteractionButtonContainer")]
	internal virtual FlowLayoutPanel InteractionButtonContainer { get; set; }

	[field: AccessedThroughProperty("DarkUIButton1")]
	internal virtual DarkUIButton DarkUIButton1 { get; set; }

	[field: AccessedThroughProperty("DarkUIButton2")]
	internal virtual DarkUIButton DarkUIButton2 { get; set; }

	[field: AccessedThroughProperty("DarkUIButton3")]
	internal virtual DarkUIButton DarkUIButton3 { get; set; }

	[field: AccessedThroughProperty("TB_Main")]
	internal virtual DarkRichTextBox TB_Main { get; set; }

	[field: AccessedThroughProperty("WebBrowser1")]
	internal virtual WebView2 WebBrowser1 { get; set; }

	static AdvancedDialog()
	{
		Class72.smethod_20();
		LastInteraction = "none";
	}

	public AdvancedDialog()
	{
		((Form)this).Load += AdvancedDialog_Load;
		Interactions = new HashSet<string>();
		dictionary_0 = new Dictionary<string, string>();
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
			((Form)this).Dispose(disposing);
		}
	}

	private void InitializeComponent()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		InteractionButtonContainer = new FlowLayoutPanel();
		DarkUIButton1 = new DarkUIButton();
		DarkUIButton2 = new DarkUIButton();
		DarkUIButton3 = new DarkUIButton();
		TB_Main = new DarkRichTextBox();
		WebBrowser1 = new WebView2();
		((Control)InteractionButtonContainer).SuspendLayout();
		((ISupportInitialize)WebBrowser1).BeginInit();
		((Control)this).SuspendLayout();
		((Control)InteractionButtonContainer).Anchor = (AnchorStyles)14;
		((ScrollableControl)InteractionButtonContainer).AutoScroll = true;
		((Control)InteractionButtonContainer).Controls.Add((Control)(object)DarkUIButton1);
		((Control)InteractionButtonContainer).Controls.Add((Control)(object)DarkUIButton2);
		((Control)InteractionButtonContainer).Controls.Add((Control)(object)DarkUIButton3);
		InteractionButtonContainer.FlowDirection = (FlowDirection)1;
		((Control)InteractionButtonContainer).Location = new Point(12, 310);
		((Control)InteractionButtonContainer).Name = "InteractionButtonContainer";
		((Control)InteractionButtonContainer).Size = new Size(529, 50);
		((Control)InteractionButtonContainer).TabIndex = 1;
		((ButtonBase)DarkUIButton1).BackColor = Color.Transparent;
		((Button)DarkUIButton1).DialogResult = (DialogResult)0;
		((Control)DarkUIButton1).ForeColor = SystemColors.Control;
		((Control)DarkUIButton1).Location = new Point(3, 3);
		((Control)DarkUIButton1).Name = "DarkUIButton1";
		DarkUIButton1.RoundRadius = 0;
		((Control)DarkUIButton1).Size = new Size(236, 25);
		((Control)DarkUIButton1).TabIndex = 0;
		DarkUIButton1.Text = "Ceci est un texte normal pour mesurer la taille";
		((ButtonBase)DarkUIButton2).BackColor = Color.Transparent;
		((Button)DarkUIButton2).DialogResult = (DialogResult)0;
		((Control)DarkUIButton2).ForeColor = SystemColors.Control;
		((Control)DarkUIButton2).Location = new Point(245, 3);
		((Control)DarkUIButton2).Name = "DarkUIButton2";
		DarkUIButton2.RoundRadius = 0;
		((Control)DarkUIButton2).Size = new Size(112, 26);
		((Control)DarkUIButton2).TabIndex = 1;
		DarkUIButton2.Text = "DarkUIButton2";
		((ButtonBase)DarkUIButton3).BackColor = Color.Transparent;
		((Button)DarkUIButton3).DialogResult = (DialogResult)0;
		((Control)DarkUIButton3).ForeColor = SystemColors.Control;
		((Control)DarkUIButton3).Location = new Point(363, 3);
		((Control)DarkUIButton3).Name = "DarkUIButton3";
		DarkUIButton3.RoundRadius = 0;
		((Control)DarkUIButton3).Size = new Size(112, 26);
		((Control)DarkUIButton3).TabIndex = 2;
		DarkUIButton3.Text = "DarkUIButton3";
		((Control)TB_Main).Anchor = (AnchorStyles)15;
		((TextBoxBase)TB_Main).BackColor = Color.FromArgb(50, 53, 55);
		((Control)TB_Main).Enabled = false;
		((RichTextBox)TB_Main).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)TB_Main).Location = new Point(12, 12);
		((Control)TB_Main).Name = "TB_Main";
		((TextBoxBase)TB_Main).ReadOnly = true;
		((Control)TB_Main).Size = new Size(528, 292);
		((Control)TB_Main).TabIndex = 2;
		((RichTextBox)TB_Main).Text = "";
		WebBrowser1.AllowExternalDrop = true;
		((Control)WebBrowser1).Anchor = (AnchorStyles)15;
		WebBrowser1.CreationProperties = null;
		WebBrowser1.DefaultBackgroundColor = Color.White;
		((Control)WebBrowser1).Location = new Point(12, 12);
		((Control)WebBrowser1).MinimumSize = new Size(20, 20);
		((Control)WebBrowser1).Name = "WebBrowser1";
		((Control)WebBrowser1).Size = new Size(529, 292);
		((Control)WebBrowser1).TabIndex = 23;
		WebBrowser1.ZoomFactor = 1.0;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).BackColor = Color.FromArgb(60, 63, 65);
		((Form)this).ClientSize = new Size(553, 366);
		((Control)this).Controls.Add((Control)(object)WebBrowser1);
		((Control)this).Controls.Add((Control)(object)InteractionButtonContainer);
		((Control)this).Controls.Add((Control)(object)TB_Main);
		((Control)this).Name = "AdvancedDialog";
		((Form)this).Text = "Advanced Dialog";
		((Control)InteractionButtonContainer).ResumeLayout(false);
		((ISupportInitialize)WebBrowser1).EndInit();
		((Control)this).ResumeLayout(false);
	}

	public static string CallDialog(string Title, string Description, string[] _Interactions)
	{
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Invalid comparison between Unknown and I4
		AdvancedDialog advancedDialog = new AdvancedDialog();
		advancedDialog.PopulateButtons(_Interactions);
		((Form)advancedDialog).Text = Title;
		((RichTextBox)advancedDialog.TB_Main).Text = Description;
		((Control)advancedDialog.TB_Main).Enabled = true;
		((Control)advancedDialog.TB_Main).Visible = true;
		((Control)advancedDialog.WebBrowser1).Visible = false;
		if ((int)((Form)advancedDialog).ShowDialog() == 1)
		{
			return LastInteraction;
		}
		return "";
	}

	[AsyncStateMachine(typeof(VB$StateMachine_34_CallHTMLDialog))]
	public static Task<Dictionary<string, string>> CallHTMLDialog(string Title, string Html, string[] _Interactions)
	{
		VB$StateMachine_34_CallHTMLDialog stateMachine = default(VB$StateMachine_34_CallHTMLDialog);
		stateMachine.$VB$Local_Title = Title;
		stateMachine.$VB$Local_Html = Html;
		stateMachine.$VB$Local__Interactions = _Interactions;
		stateMachine.$State = -1;
		stateMachine.$Builder = AsyncTaskMethodBuilder<Dictionary<string, string>>.Create();
		stateMachine.$Builder.Start(ref stateMachine);
		return stateMachine.$Builder.Task;
	}

	private void method_0(WebBrowser webBrowser_0)
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		dictionary_0.Clear();
		HtmlDocument document = webBrowser_0.Document;
		foreach (HtmlElement item in document.All)
		{
			HtmlElement val = item;
			if (string.IsNullOrEmpty(val.Name))
			{
				continue;
			}
			string attribute = val.GetAttribute("type");
			string attribute2 = val.GetAttribute("value");
			string value = ((!Versioned.IsNumeric((object)attribute2)) ? ("'" + attribute2 + "'") : attribute2);
			if (Operators.CompareString(attribute, "radio", true) == 0)
			{
				if (Conversions.ToBoolean(val.GetAttribute("checked")))
				{
					dictionary_0.Add(val.Name, value);
				}
			}
			else if (Operators.CompareString(attribute, "checkbox", true) == 0)
			{
				if (Conversions.ToBoolean(val.GetAttribute("checked")))
				{
					dictionary_0.Add(val.Name, value);
				}
			}
			else if (Operators.CompareString(attribute, "select-one", true) == 0 || Operators.CompareString(attribute, "text", true) == 0)
			{
				dictionary_0.Add(val.Name, value);
			}
		}
	}

	public void PopulateButtons(string[] _Interactions)
	{
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected O, but got Unknown
		Interactions = _Interactions.ToHashSet();
		((Control)InteractionButtonContainer).Controls.Clear();
		foreach (string interaction in Interactions)
		{
			DarkUIButton darkUIButton = new DarkUIButton();
			((Control)darkUIButton).Size = new Size(Math.Max((int)Math.Round(12f * (float)interaction.Length + 15f), 10), 29);
			((Control)darkUIButton).Font = new Font("Segoe UI", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)161);
			darkUIButton.Text = interaction;
			((Button)darkUIButton).DialogResult = (DialogResult)1;
			((Control)darkUIButton).Click += method_1;
			((Control)InteractionButtonContainer).Controls.Add((Control)(object)darkUIButton);
		}
	}

	public void WebView_WebMessageReceived(object sender, CoreWebView2WebMessageReceivedEventArgs e)
	{
		string text = e.TryGetWebMessageAsString();
		if (text.Contains("DIALOG_OK"))
		{
			((Form)this).DialogResult = (DialogResult)4;
		}
		string text2 = text.Replace("DIALOG_OK", "");
		if (!string.IsNullOrEmpty(text2))
		{
			Client.CurrentScenario.Scenario_LuaSandbox.RunScript2(text2, RunInteractively: false);
		}
	}

	private void method_1(object sender, EventArgs e)
	{
		((Form)this).DialogResult = (DialogResult)1;
		LastInteraction = ((DarkUIButton)sender).Text;
	}

	private void method_2(object sender, EventArgs e)
	{
	}

	private void AdvancedDialog_Load(object sender, EventArgs e)
	{
	}

	public void WebView_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
	{
	}
}
