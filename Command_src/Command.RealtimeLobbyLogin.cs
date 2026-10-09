using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using Command.My;
using Command.SlitherinePBEM3;
using Command.SlitherinePBEM3.Models;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class RealtimeLobbyLogin : DarkSecondaryFormBase
{
	[CompilerGenerated]
	internal sealed class _Closure$__81-0
	{
		public Task<GeneralResponseModel<LoginModel>> $VB$Local_t1;

		public RealtimeLobbyLogin $VB$Me;

		[SpecialName]
		internal void _Lambda$__R1(Task a0)
		{
			_Lambda$__0();
		}

		[SpecialName]
		internal void _Lambda$__0()
		{
			if ($VB$Local_t1 != null && !$VB$Local_t1.IsFaulted)
			{
				$VB$Me.method_6($VB$Local_t1.Result, 1);
			}
			else
			{
				$VB$Me.method_6(null, 1);
			}
		}

		static _Closure$__81-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__81-1
	{
		public Task<GeneralResponseModel<LoginModel>> $VB$Local_t1;

		public RealtimeLobbyLogin $VB$Me;

		[SpecialName]
		internal void _Lambda$__R2(Task a0)
		{
			_Lambda$__1();
		}

		[SpecialName]
		internal void _Lambda$__1()
		{
			if ($VB$Local_t1 != null && !$VB$Local_t1.IsFaulted)
			{
				$VB$Me.method_6($VB$Local_t1.Result, 1);
			}
			else
			{
				$VB$Me.method_6(null, 1);
			}
		}

		static _Closure$__81-1()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__82-0
	{
		public Task<GeneralResponseModel<int>> $VB$Local_t1;

		public RealtimeLobbyLogin $VB$Me;

		[SpecialName]
		internal void _Lambda$__R3(Task a0)
		{
			_Lambda$__0();
		}

		[SpecialName]
		internal void _Lambda$__0()
		{
			if ($VB$Local_t1 != null && !$VB$Local_t1.IsFaulted)
			{
				$VB$Me.method_6($VB$Local_t1.Result, 3);
			}
			else
			{
				$VB$Me.method_6(null, 3);
			}
		}

		static _Closure$__82-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__83-0
	{
		public Task<GeneralResponseModel<List<RoutingServerModel>>> $VB$Local_t1;

		public RealtimeLobbyLogin $VB$Me;

		[SpecialName]
		internal void _Lambda$__R4(Task a0)
		{
			_Lambda$__0();
		}

		[SpecialName]
		internal void _Lambda$__0()
		{
			if ($VB$Local_t1 != null && !$VB$Local_t1.IsFaulted)
			{
				$VB$Me.method_6($VB$Local_t1.Result, 4);
			}
			else
			{
				$VB$Me.method_6(null, 4);
			}
		}

		static _Closure$__83-0()
		{
			Class72.smethod_20();
		}
	}

	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_Ok")]
	private DarkUIButton _Button_Ok;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_Cancel")]
	private DarkUIButton _Button_Cancel;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_NewAccount")]
	private DarkUIButton _Button_NewAccount;

	[CompilerGenerated]
	private bool bool_2;

	private int int_0;

	private bool bool_3;

	internal virtual DarkUIButton Button_Ok
	{
		[CompilerGenerated]
		get
		{
			return _Button_Ok;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_8;
			DarkUIButton darkUIButton = _Button_Ok;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_Ok = value;
			darkUIButton = _Button_Ok;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_Cancel
	{
		[CompilerGenerated]
		get
		{
			return _Button_Cancel;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = aDaHakbOwrx;
			DarkUIButton darkUIButton = _Button_Cancel;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_Cancel = value;
			darkUIButton = _Button_Cancel;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("DarkLabel1")]
	internal virtual DarkLabel DarkLabel1 { get; set; }

	[field: AccessedThroughProperty("Label_SerialHeader")]
	internal virtual DarkLabel Label_SerialHeader { get; set; }

	[field: AccessedThroughProperty("Label_SerialNumber")]
	internal virtual DarkLabel Label_SerialNumber { get; set; }

	[field: AccessedThroughProperty("DarkLabel4")]
	internal virtual DarkLabel DarkLabel4 { get; set; }

	[field: AccessedThroughProperty("DarkLabel5")]
	internal virtual DarkLabel DarkLabel5 { get; set; }

	[field: AccessedThroughProperty("Text_Username")]
	internal virtual DarkUITextBox Text_Username { get; set; }

	[field: AccessedThroughProperty("Text_Password")]
	internal virtual DarkUITextBox Text_Password { get; set; }

	[field: AccessedThroughProperty("Label_NoAccount")]
	internal virtual DarkLabel Label_NoAccount { get; set; }

	internal virtual DarkUIButton Button_NewAccount
	{
		[CompilerGenerated]
		get
		{
			return _Button_NewAccount;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = xleHaBsBmpR;
			DarkUIButton darkUIButton = _Button_NewAccount;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_NewAccount = value;
			darkUIButton = _Button_NewAccount;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Text_ConfirmPassword")]
	internal virtual DarkUITextBox Text_ConfirmPassword { get; set; }

	[field: AccessedThroughProperty("Label_ConfirmPassword")]
	internal virtual DarkLabel Label_ConfirmPassword { get; set; }

	[field: AccessedThroughProperty("Text_EmailAddress")]
	internal virtual DarkUITextBox Text_EmailAddress { get; set; }

	[field: AccessedThroughProperty("Label_Email")]
	internal virtual DarkLabel Label_Email { get; set; }

	[field: AccessedThroughProperty("Label_CreateAccount")]
	internal virtual DarkLabel Label_CreateAccount { get; set; }

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

	public RealtimeLobbyLogin()
	{
		((Form)this).Load += RealtimeLobbyLogin_Load;
		((Form)this).Shown += RealtimeLobbyLogin_Shown;
		((Form)this).Closed += RealtimeLobbyLogin_Closed;
		RTMPEnabled = true;
		bool_3 = false;
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
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b4: Unknown result type (might be due to invalid IL or missing references)
		Button_Ok = new DarkUIButton();
		Button_Cancel = new DarkUIButton();
		DarkLabel1 = new DarkLabel();
		Label_SerialHeader = new DarkLabel();
		Label_SerialNumber = new DarkLabel();
		DarkLabel4 = new DarkLabel();
		DarkLabel5 = new DarkLabel();
		Text_Username = new DarkUITextBox();
		Text_Password = new DarkUITextBox();
		Label_NoAccount = new DarkLabel();
		Button_NewAccount = new DarkUIButton();
		Text_ConfirmPassword = new DarkUITextBox();
		Label_ConfirmPassword = new DarkLabel();
		Text_EmailAddress = new DarkUITextBox();
		Label_Email = new DarkLabel();
		Label_CreateAccount = new DarkLabel();
		((Control)this).SuspendLayout();
		((Control)Button_Ok).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Button_Ok).Location = new Point(182, 310);
		((Control)Button_Ok).Name = "Button_Ok";
		((Control)Button_Ok).Padding = new Padding(5);
		Button_Ok.RoundRadius = 0;
		((Control)Button_Ok).Size = new Size(75, 23);
		((Control)Button_Ok).TabIndex = 0;
		Button_Ok.Text = "Ok";
		((Control)Button_Cancel).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Button_Cancel).Location = new Point(281, 310);
		((Control)Button_Cancel).Name = "Button_Cancel";
		((Control)Button_Cancel).Padding = new Padding(5);
		Button_Cancel.RoundRadius = 0;
		((Control)Button_Cancel).Size = new Size(75, 23);
		((Control)Button_Cancel).TabIndex = 1;
		Button_Cancel.Text = "Cancel";
		DarkLabel1.AutoSize = true;
		((Control)DarkLabel1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel1).Location = new Point(12, 53);
		((Control)DarkLabel1).Name = "DarkLabel1";
		((Control)DarkLabel1).Size = new Size(480, 15);
		((Control)DarkLabel1).TabIndex = 2;
		((Label)DarkLabel1).Text = "Enter your Slitherine Account user name and password to log in to the multi-player lobby.";
		Label_SerialHeader.AutoSize = true;
		((Control)Label_SerialHeader).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_SerialHeader).Location = new Point(122, 9);
		((Control)Label_SerialHeader).Name = "Label_SerialHeader";
		((Control)Label_SerialHeader).Size = new Size(85, 15);
		((Control)Label_SerialHeader).TabIndex = 3;
		((Label)Label_SerialHeader).Text = "Serial Number:";
		Label_SerialNumber.AutoSize = true;
		((Control)Label_SerialNumber).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_SerialNumber).Location = new Point(215, 9);
		((Control)Label_SerialNumber).Name = "Label_SerialNumber";
		((Control)Label_SerialNumber).Size = new Size(167, 15);
		((Control)Label_SerialNumber).TabIndex = 4;
		((Label)Label_SerialNumber).Text = "XXXX-XXXX-XXXX-XXXX-XXXX";
		DarkLabel4.AutoSize = true;
		((Control)DarkLabel4).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel4).Location = new Point(86, 88);
		((Control)DarkLabel4).Name = "DarkLabel4";
		((Control)DarkLabel4).Size = new Size(66, 15);
		((Control)DarkLabel4).TabIndex = 5;
		((Label)DarkLabel4).Text = "User name:";
		((Label)DarkLabel4).TextAlign = (ContentAlignment)4;
		DarkLabel5.AutoSize = true;
		((Control)DarkLabel5).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel5).Location = new Point(92, 126);
		((Control)DarkLabel5).Name = "DarkLabel5";
		((Control)DarkLabel5).Size = new Size(60, 15);
		((Control)DarkLabel5).TabIndex = 6;
		((Label)DarkLabel5).Text = "Password:";
		((Label)DarkLabel5).TextAlign = (ContentAlignment)4;
		Text_Username.AutoCompleteCustomSource = null;
		Text_Username.AutoCompleteMode = (AutoCompleteMode)0;
		Text_Username.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)Text_Username).BackColor = Color.FromArgb(49, 51, 53);
		((Control)Text_Username).ForeColor = Color.FromArgb(220, 220, 220);
		Text_Username.Image = null;
		Text_Username.Lines = null;
		((Control)Text_Username).Location = new Point(159, 83);
		Text_Username.MaxLength = 64;
		Text_Username.Multiline = false;
		((Control)Text_Username).Name = "Text_Username";
		Text_Username.ReadOnly = false;
		Text_Username.ScrollBars = (ScrollBars)0;
		Text_Username.SelectionStart = 0;
		((Control)Text_Username).Size = new Size(257, 24);
		((Control)Text_Username).TabIndex = 7;
		Text_Username.TextAlign = (HorizontalAlignment)0;
		Text_Username.UseSystemPasswordChar = false;
		Text_Username.WatermarkText = "";
		Text_Username.WordWrap = false;
		Text_Password.AutoCompleteCustomSource = null;
		Text_Password.AutoCompleteMode = (AutoCompleteMode)0;
		Text_Password.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)Text_Password).BackColor = Color.FromArgb(49, 51, 53);
		((Control)Text_Password).ForeColor = Color.FromArgb(220, 220, 220);
		Text_Password.Image = null;
		Text_Password.Lines = null;
		((Control)Text_Password).Location = new Point(159, 121);
		Text_Password.MaxLength = 32;
		Text_Password.Multiline = false;
		((Control)Text_Password).Name = "Text_Password";
		Text_Password.ReadOnly = false;
		Text_Password.ScrollBars = (ScrollBars)0;
		Text_Password.SelectionStart = 0;
		((Control)Text_Password).Size = new Size(257, 24);
		((Control)Text_Password).TabIndex = 8;
		Text_Password.TextAlign = (HorizontalAlignment)0;
		Text_Password.UseSystemPasswordChar = false;
		Text_Password.WatermarkText = "";
		Text_Password.WordWrap = false;
		Label_NoAccount.AutoUpdateHeight = true;
		((Control)Label_NoAccount).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_NoAccount).Location = new Point(13, 180);
		((Control)Label_NoAccount).Name = "Label_NoAccount";
		((Control)Label_NoAccount).Size = new Size(479, 30);
		((Control)Label_NoAccount).TabIndex = 9;
		((Label)Label_NoAccount).Text = "Don't have a Slitherine Account? Just click the 'New Account' button to create one instantly from inside the game!";
		((Control)Button_NewAccount).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Button_NewAccount).Location = new Point(214, 213);
		((Control)Button_NewAccount).Name = "Button_NewAccount";
		((Control)Button_NewAccount).Padding = new Padding(5);
		Button_NewAccount.RoundRadius = 0;
		((Control)Button_NewAccount).Size = new Size(96, 23);
		((Control)Button_NewAccount).TabIndex = 10;
		Button_NewAccount.Text = "New Account";
		Text_ConfirmPassword.AutoCompleteCustomSource = null;
		Text_ConfirmPassword.AutoCompleteMode = (AutoCompleteMode)0;
		Text_ConfirmPassword.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)Text_ConfirmPassword).BackColor = Color.FromArgb(49, 51, 53);
		((Control)Text_ConfirmPassword).ForeColor = Color.FromArgb(220, 220, 220);
		Text_ConfirmPassword.Image = null;
		Text_ConfirmPassword.Lines = null;
		((Control)Text_ConfirmPassword).Location = new Point(159, 164);
		Text_ConfirmPassword.MaxLength = 32;
		Text_ConfirmPassword.Multiline = false;
		((Control)Text_ConfirmPassword).Name = "Text_ConfirmPassword";
		Text_ConfirmPassword.ReadOnly = false;
		Text_ConfirmPassword.ScrollBars = (ScrollBars)0;
		Text_ConfirmPassword.SelectionStart = 0;
		((Control)Text_ConfirmPassword).Size = new Size(257, 24);
		((Control)Text_ConfirmPassword).TabIndex = 12;
		Text_ConfirmPassword.TextAlign = (HorizontalAlignment)0;
		Text_ConfirmPassword.UseSystemPasswordChar = false;
		((Control)Text_ConfirmPassword).Visible = false;
		Text_ConfirmPassword.WatermarkText = "";
		Text_ConfirmPassword.WordWrap = false;
		Label_ConfirmPassword.AutoSize = true;
		((Control)Label_ConfirmPassword).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_ConfirmPassword).Location = new Point(45, 169);
		((Control)Label_ConfirmPassword).Name = "Label_ConfirmPassword";
		((Control)Label_ConfirmPassword).Size = new Size(107, 15);
		((Control)Label_ConfirmPassword).TabIndex = 11;
		((Label)Label_ConfirmPassword).Text = "Confirm Password:";
		((Label)Label_ConfirmPassword).TextAlign = (ContentAlignment)4;
		((Control)Label_ConfirmPassword).Visible = false;
		Text_EmailAddress.AutoCompleteCustomSource = null;
		Text_EmailAddress.AutoCompleteMode = (AutoCompleteMode)0;
		Text_EmailAddress.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)Text_EmailAddress).BackColor = Color.FromArgb(49, 51, 53);
		((Control)Text_EmailAddress).ForeColor = Color.FromArgb(220, 220, 220);
		Text_EmailAddress.Image = null;
		Text_EmailAddress.Lines = null;
		((Control)Text_EmailAddress).Location = new Point(161, 199);
		Text_EmailAddress.MaxLength = 255;
		Text_EmailAddress.Multiline = false;
		((Control)Text_EmailAddress).Name = "Text_EmailAddress";
		Text_EmailAddress.ReadOnly = false;
		Text_EmailAddress.ScrollBars = (ScrollBars)0;
		Text_EmailAddress.SelectionStart = 0;
		((Control)Text_EmailAddress).Size = new Size(257, 24);
		((Control)Text_EmailAddress).TabIndex = 14;
		Text_EmailAddress.TextAlign = (HorizontalAlignment)0;
		Text_EmailAddress.UseSystemPasswordChar = false;
		((Control)Text_EmailAddress).Visible = false;
		Text_EmailAddress.WatermarkText = "";
		Text_EmailAddress.WordWrap = false;
		Label_Email.AutoSize = true;
		((Control)Label_Email).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_Email).Location = new Point(56, 204);
		((Control)Label_Email).Name = "Label_Email";
		((Control)Label_Email).Size = new Size(96, 15);
		((Control)Label_Email).TabIndex = 13;
		((Label)Label_Email).Text = "Activation Email:";
		((Label)Label_Email).TextAlign = (ContentAlignment)4;
		((Control)Label_Email).Visible = false;
		Label_CreateAccount.AutoUpdateHeight = true;
		((Control)Label_CreateAccount).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_CreateAccount).Location = new Point(23, 232);
		((Control)Label_CreateAccount).Name = "Label_CreateAccount";
		((Control)Label_CreateAccount).Size = new Size(479, 30);
		((Control)Label_CreateAccount).TabIndex = 15;
		((Label)Label_CreateAccount).Text = "Enter a user name and password for your new Slitherine Account. An email will be sent to help you finalize and acivate your account.";
		((Control)Label_CreateAccount).Visible = false;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(7f, 15f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(525, 352);
		((Control)this).Controls.Add((Control)(object)Label_CreateAccount);
		((Control)this).Controls.Add((Control)(object)Text_EmailAddress);
		((Control)this).Controls.Add((Control)(object)Label_Email);
		((Control)this).Controls.Add((Control)(object)Text_ConfirmPassword);
		((Control)this).Controls.Add((Control)(object)Label_ConfirmPassword);
		((Control)this).Controls.Add((Control)(object)Button_NewAccount);
		((Control)this).Controls.Add((Control)(object)Label_NoAccount);
		((Control)this).Controls.Add((Control)(object)Text_Password);
		((Control)this).Controls.Add((Control)(object)Text_Username);
		((Control)this).Controls.Add((Control)(object)DarkLabel5);
		((Control)this).Controls.Add((Control)(object)DarkLabel4);
		((Control)this).Controls.Add((Control)(object)Label_SerialNumber);
		((Control)this).Controls.Add((Control)(object)Label_SerialHeader);
		((Control)this).Controls.Add((Control)(object)DarkLabel1);
		((Control)this).Controls.Add((Control)(object)Button_Cancel);
		((Control)this).Controls.Add((Control)(object)Button_Ok);
		((Form)this).FormBorderStyle = (FormBorderStyle)3;
		((Form)this).StartPosition = (FormStartPosition)4;
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "RealtimeLobbyLogin";
		((Form)this).ShowInTaskbar = false;
		((Form)this).Text = "Lobby Login";
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void method_2(int int_1, string string_0)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		DarkMessageBox.ShowError(string_0 + " (" + int_1 + ")", "Login Error");
	}

	public void NotifyWaitCancel()
	{
		aDaHakbOwrx(null, null);
	}

	private void method_3()
	{
		if (!Client.RunningInSteamMode)
		{
			_Closure$__81-1 CS$<>8__locals8 = new _Closure$__81-1();
			CS$<>8__locals8.$VB$Me = this;
			CS$<>8__locals8.$VB$Local_t1 = ApiMethods.LoginAsync(SlitherineLobby.string_0, MyProject.Forms.RealtimeLobby.SerialNumber, Text_Username.Text, Text_Password.Text);
			CS$<>8__locals8.$VB$Local_t1.ContinueWith([SpecialName] (Task a0) =>
			{
				CS$<>8__locals8._Lambda$__1();
			});
		}
		else
		{
			_Closure$__81-0 CS$<>8__locals9 = new _Closure$__81-0();
			CS$<>8__locals9.$VB$Me = this;
			CS$<>8__locals9.$VB$Local_t1 = ApiMethods.LoginSteamAsync(SlitherineLobby.string_0, MyProject.Forms.RealtimeLobby.SteamToken, Text_Username.Text, Text_Password.Text);
			CS$<>8__locals9.$VB$Local_t1.ContinueWith([SpecialName] (Task a0) =>
			{
				CS$<>8__locals9._Lambda$__0();
			});
		}
	}

	private void method_4()
	{
		_Closure$__82-0 CS$<>8__locals4 = new _Closure$__82-0();
		CS$<>8__locals4.$VB$Me = this;
		CS$<>8__locals4.$VB$Local_t1 = ApiMethods.RegisterAsync(SlitherineLobby.string_0, Text_Username.Text, Text_Password.Text, Text_EmailAddress.Text);
		CS$<>8__locals4.$VB$Local_t1.ContinueWith([SpecialName] (Task a0) =>
		{
			CS$<>8__locals4._Lambda$__0();
		});
	}

	private void method_5()
	{
		_Closure$__83-0 CS$<>8__locals4 = new _Closure$__83-0();
		CS$<>8__locals4.$VB$Me = this;
		CS$<>8__locals4.$VB$Local_t1 = ApiMethods.ListTCPRoutingServers(SlitherineLobby.string_0, SlitherineLobby.UserLoginInfo);
		CS$<>8__locals4.$VB$Local_t1.ContinueWith([SpecialName] (Task a0) =>
		{
			CS$<>8__locals4._Lambda$__0();
		});
	}

	private void method_6(object object_0, object object_1)
	{
		int num = -99;
		if (object_1 is int)
		{
			num = -99;
			num = -99;
			switch (Conversions.ToInteger(object_1))
			{
			case 1:
			{
				if (object_0 == null)
				{
					Client.Dispatcher.Invoke((Action)([SpecialName] () =>
					{
						((Form)MyProject.Forms.RealtimeLobbyLoginWait).Close();
						method_2(0, "An unknown error occcurred. Please review your login information and try again.");
					}));
					break;
				}
				GeneralResponseModel<LoginModel> generalResponseModel3 = (GeneralResponseModel<LoginModel>)object_0;
				if (generalResponseModel3.Message.ErrorCode != 0)
				{
					Client.Dispatcher.Invoke((Action)([SpecialName] () =>
					{
						((Form)MyProject.Forms.RealtimeLobbyLoginWait).Close();
						method_2(generalResponseModel3.Message.ErrorCode, "User name and/or password not recognized. " + generalResponseModel3.Message.ErrorComment);
					}));
					break;
				}
				SlitherineLobby.UserLoginInfo = generalResponseModel3.Result;
				Client.Dispatcher.Invoke((Action)([SpecialName] () =>
				{
					((Label)MyProject.Forms.RealtimeLobbyLoginWait.Label_WaitStatus).Text = "Login successful. Connecting to lobby...";
					method_5();
				}));
				break;
			}
			case 3:
			{
				if (object_0 == null)
				{
					Client.Dispatcher.Invoke((Action)([SpecialName] () =>
					{
						((Form)MyProject.Forms.RealtimeLobbyLoginWait).Close();
						method_2(0, "An unknown error occcurred. Please review your registration information and try again.");
					}));
					break;
				}
				GeneralResponseModel<int> generalResponseModel2 = (GeneralResponseModel<int>)object_0;
				if (generalResponseModel2.Message.ErrorCode == 0)
				{
					MyProject.Forms.RealtimeLobby.UserName = Text_Username.Text;
					MyProject.Forms.RealtimeLobby.Password = Text_Password.Text;
					MyProject.Forms.RealtimeLobby.UserID = generalResponseModel2.Result;
					Client.Dispatcher.Invoke((Action)([SpecialName] () =>
					{
						((Label)MyProject.Forms.RealtimeLobbyLoginWait.Label_WaitStatus).Text = "Registration successful. Logging in...";
						method_3();
					}));
				}
				else
				{
					Client.Dispatcher.Invoke((Action)([SpecialName] () =>
					{
						((Form)MyProject.Forms.RealtimeLobbyLoginWait).Close();
						method_2(generalResponseModel2.Message.ErrorCode, "Registration failed. " + generalResponseModel2.Message.ErrorComment);
					}));
				}
				break;
			}
			case 4:
			{
				if (object_0 == null)
				{
					Client.Dispatcher.Invoke((Action)([SpecialName] () =>
					{
						((Form)MyProject.Forms.RealtimeLobbyLoginWait).Close();
						method_2(0, "An unknown error occcurred. Please try again.");
					}));
					break;
				}
				GeneralResponseModel<List<RoutingServerModel>> generalResponseModel = (GeneralResponseModel<List<RoutingServerModel>>)object_0;
				if (generalResponseModel.Message.ErrorCode != 0)
				{
					Client.Dispatcher.Invoke((Action)([SpecialName] () =>
					{
						((Form)MyProject.Forms.RealtimeLobbyLoginWait).Close();
						method_2(generalResponseModel.Message.ErrorCode, generalResponseModel.Message.ErrorComment);
					}));
					break;
				}
				SlitherineLobby.RoutingServerInfo = generalResponseModel.Result;
				Client.Dispatcher.Invoke((Action)([SpecialName] () =>
				{
					((Form)MyProject.Forms.RealtimeLobbyLoginWait).Close();
					((Form)this).DialogResult = (DialogResult)1;
					((Form)this).Close();
				}));
				break;
			}
			case 2:
				break;
			}
		}
		else
		{
			num = -99;
			num = -99;
		}
	}

	private void RealtimeLobbyLogin_Load(object sender, EventArgs e)
	{
		Text_Username.Text = MyProject.Forms.RealtimeLobby.UserName;
		Text_Password.Text = MyProject.Forms.RealtimeLobby.Password;
		Text_Password.UseSystemPasswordChar = true;
		((Label)Label_SerialNumber).Text = MyProject.Forms.RealtimeLobby.SerialNumber;
		if (Client.RunningInSteamMode)
		{
			((Control)Label_SerialHeader).Visible = false;
			((Control)Label_SerialNumber).Visible = false;
		}
	}

	private void RealtimeLobbyLogin_Shown(object sender, EventArgs e)
	{
	}

	private void xleHaBsBmpR(object sender, EventArgs e)
	{
		((Control)Button_NewAccount).Visible = false;
		((Control)Label_NoAccount).Visible = false;
		Text_Password.UseSystemPasswordChar = false;
		((Control)Label_CreateAccount).Visible = true;
		((Control)Label_ConfirmPassword).Visible = true;
		((Control)Text_ConfirmPassword).Visible = true;
		((Control)Label_Email).Visible = true;
		((Control)Text_EmailAddress).Visible = true;
		bool_3 = true;
	}

	private void method_7()
	{
		((Form)this).Close();
	}

	private void aDaHakbOwrx(object sender, EventArgs e)
	{
		((Form)this).DialogResult = (DialogResult)2;
		method_7();
	}

	private void method_8(object sender, EventArgs e)
	{
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		if (!string.IsNullOrEmpty(Text_Username.Text) && !string.IsNullOrEmpty(Text_Password.Text))
		{
			if (bool_3)
			{
				if (!string.IsNullOrEmpty(Text_EmailAddress.Text))
				{
					if (Operators.CompareString(Text_Password.Text, Text_ConfirmPassword.Text, true) == 0)
					{
						((Label)MyProject.Forms.RealtimeLobbyLoginWait.Label_WaitStatus).Text = "Registering user and logging in...";
						((Form)MyProject.Forms.RealtimeLobbyLoginWait).Show((IWin32Window)(object)this);
						method_4();
					}
					else
					{
						DarkMessageBox.ShowError("Password and Confirm Password do not match.", "Error");
					}
				}
				else
				{
					DarkMessageBox.ShowError("Please enter an email address for your new Slitherine account.", "Error");
				}
			}
			else
			{
				((Label)MyProject.Forms.RealtimeLobbyLoginWait.Label_WaitStatus).Text = "Logging in...";
				((Form)MyProject.Forms.RealtimeLobbyLoginWait).Show((IWin32Window)(object)this);
				method_3();
			}
		}
		else
		{
			DarkMessageBox.ShowError("Please enter your Slitherine account user name and password.", "Error");
		}
	}

	private void RealtimeLobbyLogin_Closed(object sender, EventArgs e)
	{
		((Control)Button_NewAccount).Visible = true;
		((Control)Label_NoAccount).Visible = true;
		Text_Password.UseSystemPasswordChar = true;
		((Control)Label_CreateAccount).Visible = false;
		((Control)Label_ConfirmPassword).Visible = false;
		((Control)Text_ConfirmPassword).Visible = false;
		((Control)Label_Email).Visible = false;
		((Control)Text_EmailAddress).Visible = false;
		bool_3 = false;
	}

	static RealtimeLobbyLogin()
	{
		Class72.smethod_20();
	}
}
