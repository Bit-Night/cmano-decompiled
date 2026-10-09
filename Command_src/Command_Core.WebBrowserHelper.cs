using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using Newtonsoft.Json;

namespace Command_Core;

public class WebBrowserHelper
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct VB$StateMachine_5_InitialiseWebview2Browser : IAsyncStateMachine
	{
		public int $State;

		public AsyncTaskMethodBuilder $Builder;

		internal WebView2 $VB$Local_Browser;

		internal TaskAwaiter<CoreWebView2Environment> $A0;

		internal TaskAwaiter $A1;

		[CompilerGenerated]
		internal void MoveNext()
		{
			int num = $State;
			try
			{
				if (num != -3)
				{
				}
				try
				{
					CoreWebView2Environment result;
					TaskAwaiter<CoreWebView2Environment> awaiter2;
					TaskAwaiter awaiter;
					switch (num)
					{
					case -3:
						num = -1;
						$State = -1;
						return;
					default:
						if (!Directory.Exists(GameGeneral.WebViewTempPath))
						{
							Directory.CreateDirectory(GameGeneral.WebViewTempPath);
						}
						if (env == null)
						{
							awaiter2 = CoreWebView2Environment.CreateAsync(null, GameGeneral.WebViewTempPath).GetAwaiter();
							if (!awaiter2.IsCompleted)
							{
								num = 0;
								$State = 0;
								$A0 = awaiter2;
								$Builder.AwaitUnsafeOnCompleted(ref awaiter2, ref this);
								return;
							}
							goto IL_00bc;
						}
						goto IL_00d0;
					case 0:
						num = -1;
						$State = -1;
						awaiter2 = $A0;
						$A0 = default(TaskAwaiter<CoreWebView2Environment>);
						goto IL_00bc;
					case 1:
						{
							num = -1;
							$State = -1;
							awaiter = $A1;
							$A1 = default(TaskAwaiter);
							break;
						}
						IL_00bc:
						result = awaiter2.GetResult();
						awaiter2 = default(TaskAwaiter<CoreWebView2Environment>);
						env = result;
						goto IL_00d0;
						IL_00d0:
						awaiter = $VB$Local_Browser.EnsureCoreWebView2Async(env).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = 1;
							$State = 1;
							$A1 = awaiter;
							$Builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
							return;
						}
						break;
					}
					awaiter.GetResult();
					awaiter = default(TaskAwaiter);
					string text = Path.Combine(GameGeneral.DBFolderPath, "Images");
					if (Directory.Exists(text))
					{
						$VB$Local_Browser.CoreWebView2.SetVirtualHostNameToFolderMapping("dbimages.invalid", text, CoreWebView2HostResourceAccessKind.Allow);
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

		static VB$StateMachine_5_InitialiseWebview2Browser()
		{
			Class72.smethod_20();
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct VB$StateMachine_6_FetchHTMLUserInputs : IAsyncStateMachine
	{
		public int $State;

		public AsyncTaskMethodBuilder<Dictionary<string, string>> $Builder;

		internal WebView2 $VB$Local_theBrowser;

		internal List<KeyValuePair<string, string>>.Enumerator $S0;

		internal Dictionary<string, string> $VB$ResumableLocal_Result$1;

		internal TaskAwaiter $A0;

		[CompilerGenerated]
		internal void MoveNext()
		{
			int num = $State;
			Dictionary<string, string> result;
			try
			{
				if (num != -3 && num != 0)
				{
					$VB$ResumableLocal_Result$1 = new Dictionary<string, string>();
				}
				try
				{
					if (num == -3)
					{
						num = -1;
						$State = -1;
						return;
					}
					TaskAwaiter awaiter;
					if (num == 0)
					{
						num = -1;
						$State = -1;
						awaiter = $A0;
						$A0 = default(TaskAwaiter);
					}
					else
					{
						awaiter = InitialiseWebview2Browser($VB$Local_theBrowser).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = 0;
							$State = 0;
							$A0 = awaiter;
							$Builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
							return;
						}
					}
					awaiter.GetResult();
					awaiter = default(TaskAwaiter);
					string script = "var formData = {};var inputs = document.querySelectorAll('input');inputs.forEach(function(input) { if( input.type != 'checkbox' && input.type != 'radio') formData[input.name] = input.value; });var selects = document.querySelectorAll('select');selects.forEach(function(select) { formData[select.name] = select.value; });var radios = document.querySelectorAll('input[type=radio]:checked');radios.forEach(function(radio) { formData[radio.name] = radio.value; });var checkboxs = document.querySelectorAll('input[type=checkbox]:checked');checkboxs.forEach(function(checkbox) { formData[checkbox.name] = checkbox.value; });formData;";
					string value = "";
					int num2 = 200;
					Task<string> task = $VB$Local_theBrowser.ExecuteScriptAsync(script);
					while (!task.IsCompleted && -(-num2) > 0)
					{
						Application.DoEvents();
						Thread.Sleep(10);
					}
					if (num2 > 0)
					{
						value = task.Result;
					}
					$VB$ResumableLocal_Result$1 = JsonConvert.DeserializeObject<Dictionary<string, string>>(value);
					try
					{
						$S0 = $VB$ResumableLocal_Result$1.ToList().GetEnumerator();
						while ($S0.MoveNext())
						{
							KeyValuePair<string, string> current = $S0.Current;
							if (!Versioned.IsNumeric((object)current.Value))
							{
								$VB$ResumableLocal_Result$1[current.Key] = "'" + current.Value + "'";
							}
						}
					}
					finally
					{
						if (num < 0)
						{
							((IDisposable)$S0/*cast due to .constrained prefix*/).Dispose();
						}
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
				result = $VB$ResumableLocal_Result$1;
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

		static VB$StateMachine_6_FetchHTMLUserInputs()
		{
			Class72.smethod_20();
		}
	}

	public const string DBImagesVirtualHostName = "dbimages.invalid";

	public const string string_0 = "https://dbimages.invalid/";

	public static CoreWebView2Environment env;

	static WebBrowserHelper()
	{
		Class72.smethod_20();
		env = null;
	}

	[AsyncStateMachine(typeof(VB$StateMachine_5_InitialiseWebview2Browser))]
	public static Task InitialiseWebview2Browser(WebView2 Browser)
	{
		VB$StateMachine_5_InitialiseWebview2Browser stateMachine = default(VB$StateMachine_5_InitialiseWebview2Browser);
		stateMachine.$VB$Local_Browser = Browser;
		stateMachine.$State = -1;
		stateMachine.$Builder = AsyncTaskMethodBuilder.Create();
		stateMachine.$Builder.Start(ref stateMachine);
		return stateMachine.$Builder.Task;
	}

	[AsyncStateMachine(typeof(VB$StateMachine_6_FetchHTMLUserInputs))]
	public static Task<Dictionary<string, string>> smethod_0(WebView2 theBrowser)
	{
		VB$StateMachine_6_FetchHTMLUserInputs stateMachine = default(VB$StateMachine_6_FetchHTMLUserInputs);
		stateMachine.$VB$Local_theBrowser = theBrowser;
		stateMachine.$State = -1;
		stateMachine.$Builder = AsyncTaskMethodBuilder<Dictionary<string, string>>.Create();
		stateMachine.$Builder.Start(ref stateMachine);
		return stateMachine.$Builder.Task;
	}

	public static string CheckHTMLSecurity(string HTML)
	{
		List<string> list = new List<string> { "download\\s*\\(" };
		foreach (string item in list)
		{
			if (Regex.IsMatch(HTML, item, RegexOptions.IgnoreCase))
			{
				return "<html><body><h1>Unauthorized Script</h1></body></html>";
			}
		}
		return HTML;
	}
}
