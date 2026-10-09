using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Command_Core;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Web.WebView2.WinForms;
using MSDN.Html.Editor;
using Newtonsoft.Json;

namespace Command;

[StandardModule]
public sealed class Helper
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct VB$StateMachine_4_CheckForExternalHTML : IAsyncStateMachine
	{
		public int $State;

		public AsyncTaskMethodBuilder<bool> $Builder;

		internal WebView2 $VB$Local_theBrowser;

		internal string $VB$Local_theText;

		internal string $VB$Local_CurrentFolderPath;

		internal Scenario $VB$Local_Scen;

		internal ScenContainer $VB$Local_ScenContainer;

		internal HtmlEditorControl $VB$Local_theEditor;

		internal string $VB$ResumableLocal_FilePath$0;

		internal TaskAwaiter $A0;

		[CompilerGenerated]
		internal void MoveNext()
		{
			int num = $State;
			bool result;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					num = -1;
					$State = -1;
					awaiter = $A0;
					$A0 = default(TaskAwaiter);
					goto IL_0098;
				}
				if (!string.IsNullOrEmpty($VB$Local_theText))
				{
					$VB$ResumableLocal_FilePath$0 = smethod_0($VB$Local_theText);
					if ($VB$Local_theBrowser != null)
					{
						awaiter = WebBrowserHelper.InitialiseWebview2Browser($VB$Local_theBrowser).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = 0;
							$State = 0;
							$A0 = awaiter;
							$Builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
							return;
						}
						goto IL_0098;
					}
					goto IL_00bc;
				}
				result = false;
				goto end_IL_0008;
				IL_00bc:
				if (!string.IsNullOrEmpty($VB$ResumableLocal_FilePath$0))
				{
					if (File.Exists(Path.Combine($VB$Local_CurrentFolderPath, $VB$ResumableLocal_FilePath$0)))
					{
						int num2;
						if ($VB$Local_theEditor != null)
						{
							$VB$Local_theEditor.NavigateToUrl(Path.Combine($VB$Local_CurrentFolderPath, $VB$ResumableLocal_FilePath$0));
							num2 = 1;
						}
						else
						{
							$VB$Local_theBrowser.CoreWebView2.Navigate(Path.Combine($VB$Local_CurrentFolderPath, $VB$ResumableLocal_FilePath$0));
							num2 = 1;
						}
						result = (byte)num2 != 0;
					}
					else
					{
						string text = "";
						Campaign campaign = null;
						if ($VB$Local_Scen != null)
						{
							text = $VB$Local_Scen.CampaignID;
							campaign = Campaign.GetCampaignByID(GameGeneral.ScenariosRootPath, text);
						}
						else if ($VB$Local_ScenContainer != null)
						{
							text = $VB$Local_ScenContainer.CampaignID;
							if (string.IsNullOrEmpty(text))
							{
								text = Scenario.QueryScenario_ScenXML($VB$Local_ScenContainer.GetScenarioObject_AsXML(), "CampaignID");
							}
							campaign = Campaign.GetCampaignByID(GameGeneral.ScenariosRootPath, text);
						}
						if (Information.IsNothing((object)campaign))
						{
							string scenariosRoot = FindScenariosRoot($VB$Local_CurrentFolderPath);
							string text2 = SearchFileInScenarios($VB$ResumableLocal_FilePath$0, scenariosRoot);
							if (!string.IsNullOrEmpty(text2))
							{
								int num3;
								if ($VB$Local_theEditor != null)
								{
									$VB$Local_theEditor.NavigateToUrl(text2);
									num3 = 1;
								}
								else
								{
									$VB$Local_theBrowser.CoreWebView2.Navigate(text2);
									num3 = 1;
								}
								result = (byte)num3 != 0;
							}
							else
							{
								result = false;
							}
						}
						else
						{
							string text3 = Path.Combine(campaign.FolderPath, $VB$ResumableLocal_FilePath$0);
							if (!File.Exists(text3))
							{
								if (File.Exists(Path.Combine(Path.Combine($VB$Local_CurrentFolderPath, $VB$ResumableLocal_FilePath$0))))
								{
									int num4;
									if ($VB$Local_theEditor == null)
									{
										$VB$Local_theBrowser.CoreWebView2.Navigate(Path.Combine($VB$Local_CurrentFolderPath, $VB$ResumableLocal_FilePath$0));
										num4 = 1;
									}
									else
									{
										$VB$Local_theEditor.NavigateToUrl(Path.Combine($VB$Local_CurrentFolderPath, $VB$ResumableLocal_FilePath$0));
										num4 = 1;
									}
									result = (byte)num4 != 0;
								}
								else
								{
									result = false;
								}
							}
							else
							{
								int num5;
								if ($VB$Local_theEditor == null)
								{
									$VB$Local_theBrowser.CoreWebView2.Navigate(Path.Combine(text3));
									num5 = 1;
								}
								else
								{
									$VB$Local_theEditor.NavigateToUrl(Path.Combine(text3));
									num5 = 1;
								}
								result = (byte)num5 != 0;
							}
						}
					}
				}
				else
				{
					result = false;
				}
				goto end_IL_0008;
				IL_0098:
				awaiter.GetResult();
				awaiter = default(TaskAwaiter);
				if ($VB$Local_theBrowser.CoreWebView2 != null)
				{
					goto IL_00bc;
				}
				result = false;
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

		static VB$StateMachine_4_CheckForExternalHTML()
		{
			Class72.smethod_20();
		}
	}

	public static Dictionary<string, string> AllStrings;

	static Helper()
	{
		Class72.smethod_20();
		AllStrings = new Dictionary<string, string>();
	}

	public static string smethod_0(string theText)
	{
		string pattern = "\\[LOADDOC\\](.*?)\\[/LOADDOC\\]";
		Match match = Regex.Match(theText, pattern, RegexOptions.Singleline);
		if (!match.Success)
		{
			return "";
		}
		return match.Groups[1].Value;
	}

	public static string GetReadableEnum(Doctrine.DoctrineCategory e)
	{
		return e.ToString().Replace("_", " ");
	}

	public static string GetReadableEnum_Description(Doctrine.DoctrineCategory e)
	{
		return e switch
		{
			Doctrine.DoctrineCategory.RoE => "Rules of Engagement (RoE)", 
			Doctrine.DoctrineCategory.EMCON => "Emission Control (EMCON)", 
			Doctrine.DoctrineCategory.Air_Ops => "Anti-Air Warfare (AAW)", 
			Doctrine.DoctrineCategory.ASuW => "Anti-Surface Warfare (ASuW)", 
			Doctrine.DoctrineCategory.ASW => "Anti-Submarine Warfare (ASW)", 
			Doctrine.DoctrineCategory.Land => "Land Warfare", 
			Doctrine.DoctrineCategory.AGU => "Aggregate Ground Unit (AGU)", 
			_ => e.ToString(), 
		};
	}

	[AsyncStateMachine(typeof(VB$StateMachine_4_CheckForExternalHTML))]
	public static Task<bool> smethod_1(WebView2 theBrowser, string theText, string CurrentFolderPath, Scenario Scen = null, ScenContainer ScenContainer = null, HtmlEditorControl theEditor = null)
	{
		VB$StateMachine_4_CheckForExternalHTML stateMachine = default(VB$StateMachine_4_CheckForExternalHTML);
		stateMachine.$VB$Local_theBrowser = theBrowser;
		stateMachine.$VB$Local_theText = theText;
		stateMachine.$VB$Local_CurrentFolderPath = CurrentFolderPath;
		stateMachine.$VB$Local_Scen = Scen;
		stateMachine.$VB$Local_ScenContainer = ScenContainer;
		stateMachine.$VB$Local_theEditor = theEditor;
		stateMachine.$State = -1;
		stateMachine.$Builder = AsyncTaskMethodBuilder<bool>.Create();
		stateMachine.$Builder.Start(ref stateMachine);
		return stateMachine.$Builder.Task;
	}

	public static string FindScenariosRoot(string startPath)
	{
		DirectoryInfo directoryInfo = new DirectoryInfo(Path.GetFullPath(startPath));
		while (true)
		{
			if (directoryInfo != null)
			{
				if (string.Equals(directoryInfo.Name, "Scenarios", StringComparison.OrdinalIgnoreCase))
				{
					break;
				}
				directoryInfo = directoryInfo.Parent;
				continue;
			}
			return null;
		}
		return directoryInfo.FullName;
	}

	public static string SearchFileInScenarios(string filePath, string scenariosRoot)
	{
		if (!string.IsNullOrWhiteSpace(scenariosRoot) && Directory.Exists(scenariosRoot))
		{
			string path = filePath.TrimStart(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
			string text = Path.Combine(scenariosRoot, path);
			if (File.Exists(text))
			{
				return text;
			}
			string fileName = Path.GetFileName(filePath);
			if (string.IsNullOrEmpty(fileName))
			{
				return null;
			}
			using (IEnumerator<string> enumerator = Directory.EnumerateFiles(scenariosRoot, fileName, SearchOption.AllDirectories).GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					return enumerator.Current;
				}
			}
			return null;
		}
		return null;
	}

	public static List<ISortable> GetSortedCollection(List<ISortable> ToOrder, SortOrder Order = (SortOrder)1, CollectionSortingMethod SortingMethod = CollectionSortingMethod.ByName)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Invalid comparison between Unknown and I4
		if (SortingMethod == CollectionSortingMethod.ByName)
		{
			if ((int)Order == 1)
			{
				return ToOrder.OrderBy([SpecialName] (ISortable item) => item.SortByName, new NaturalSortComparer<string[]>()).ToList();
			}
			return ToOrder.OrderByDescending([SpecialName] (ISortable item) => item.SortByName, new NaturalSortComparer<string[]>()).ToList();
		}
		return ToOrder;
	}

	public static string GetReadableEnum(Enum anyEnum)
	{
		return HANNIBAL_GetString(anyEnum.ToString());
	}

	public static void HANNIBAL_LoadStrings()
	{
		string path = Path.Combine(AGU_CONFIG.HannibalDataPath, "Lang.json");
		if (File.Exists(path))
		{
			AllStrings = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(path));
		}
	}

	public static string HANNIBAL_GetString(string Key)
	{
		string value = null;
		AllStrings.TryGetValue(Key, out value);
		if (string.IsNullOrEmpty(value))
		{
			return Key;
		}
		return value;
	}
}
