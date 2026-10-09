using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Management;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using AdvancedDataGridView;
using Command_Core;
using Command.My;
using DarkUI.Controls;
using Efundies;
using ExWorldWind;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using Microsoft.Win32;

namespace Command;

[StandardModule]
internal sealed class Module1
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct VB$StateMachine_23_RenderCustomHTML : IAsyncStateMachine
	{
		public int $State;

		public AsyncVoidMethodBuilder $Builder;

		internal WebView2 $VB$Local_theBrowser;

		internal string $VB$Local_theHTML;

		internal string $VB$Local_TheCSS;

		internal AdvancedDialog $VB$Local_AdvancedDialog;

		internal TaskAwaiter $A0;

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
						goto IL_00a1;
					}
					if (!((Control)$VB$Local_theBrowser).IsDisposed)
					{
						if (!string.IsNullOrEmpty($VB$Local_TheCSS))
						{
							$VB$Local_theHTML = $VB$Local_TheCSS;
						}
						else
						{
							$VB$Local_theHTML = "<style>\r\n                    body\r\n                        {\r\n                        background:#333333;\r\n                        color:Lightgrey;\r\n                        scrollbar-face-color: #696969;\r\n                        scrollbar-highlight-color: #696969;\r\n                        scrollbar-3dlight-color: #696969;\r\n                        scrollbar-darkshadow-color: #696969;\r\n                        scrollbar-shadow-color: #696969;\r\n                        scrollbar-arrow-color: #696969;\r\n                        scrollbar-track-color: #333333;\r\n                        }\r\n                    hr\r\n                        {\r\n                        border-color:Lightgrey; \r\n                        background-color:Lightgrey\r\n                        }\r\n                    </style><FONT face=Calibri>" + $VB$Local_theHTML + "<FONT>";
						}
						awaiter = WebBrowserHelper.InitialiseWebview2Browser($VB$Local_theBrowser).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = 0;
							$State = 0;
							$A0 = awaiter;
							$Builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
							return;
						}
						goto IL_00a1;
					}
					goto end_IL_0012;
					IL_00a1:
					awaiter.GetResult();
					awaiter = default(TaskAwaiter);
					if ($VB$Local_AdvancedDialog != null)
					{
						$VB$Local_AdvancedDialog.WebBrowser1.CoreWebView2.Settings.IsScriptEnabled = true;
						$VB$Local_AdvancedDialog.WebBrowser1.WebMessageReceived += $VB$Local_AdvancedDialog.WebView_WebMessageReceived;
					}
					$VB$Local_theBrowser.CoreWebView2.SetVirtualHostNameToFolderMapping("Root", "", CoreWebView2HostResourceAccessKind.Allow);
					$VB$Local_theBrowser.CoreWebView2.SetVirtualHostNameToFolderMapping("TopWritable", GameGeneral.TopLevelWritablePath, CoreWebView2HostResourceAccessKind.Allow);
					if (!string.IsNullOrEmpty(SimConfiguration.DefaultGamePreferences.WebviewPathCustomRoot))
					{
						$VB$Local_theBrowser.CoreWebView2.SetVirtualHostNameToFolderMapping("UserPath", SimConfiguration.DefaultGamePreferences.WebviewPathCustomRoot, CoreWebView2HostResourceAccessKind.Allow);
					}
					$VB$Local_theBrowser.CoreWebView2.NavigateToString(WebBrowserHelper.CheckHTMLSecurity($VB$Local_theHTML));
					end_IL_0012:;
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error at 200101", ex2.Message);
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

		static VB$StateMachine_23_RenderCustomHTML()
		{
			Class72.smethod_20();
		}
	}

	public static DrawArgs WW_DrawArgs;

	public static bool FlightPlanner_Visibility;

	public static bool Time_Visibility;

	public static bool ATO_Visibility;

	public static bool AttackMode_Visibility;

	public static bool PoolsPackages_Visibility;

	public const int Const_SB_VERT = 1;

	public static Bitmap SplashImage;

	static Module1()
	{
		Class72.smethod_20();
		FlightPlanner_Visibility = true;
		Time_Visibility = true;
		ATO_Visibility = true;
		AttackMode_Visibility = true;
		PoolsPackages_Visibility = true;
	}

	[DllImport("user32.dll")]
	public static extern bool ShowScrollBar(IntPtr hWnd, int wBar, bool bShow);

	public static Bitmap GhostedImage(Image original, float opacity)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected O, but got Unknown
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		if (opacity == 1f)
		{
			return (Bitmap)original;
		}
		if (Client.Cache_GhostedBitmaps.TryGetValue(original, out var value))
		{
			return (Bitmap)value;
		}
		Bitmap val = new Bitmap(original.Width, original.Height);
		Graphics obj = Graphics.FromImage((Image)(object)val);
		ColorMatrix val2 = new ColorMatrix();
		val2.Matrix33 = opacity;
		ImageAttributes val3 = new ImageAttributes();
		val3.SetColorMatrix(val2, (ColorMatrixFlag)0, (ColorAdjustType)1);
		obj.DrawImage(original, new Rectangle(0, 0, ((Image)val).Width, ((Image)val).Height), 0, 0, original.Width, original.Height, (GraphicsUnit)2, val3);
		obj.Dispose();
		Client.Cache_GhostedBitmaps.Add(original, (Image)(object)val);
		return val;
	}

	public static string ConvertScenTitleToFileName(string ScenTitle)
	{
		return Misc.RemoveIllegalFilepathCharacters(ScenTitle);
	}

	public static Bitmap RotatedImage(string ImageName, Bitmap SourceImage, float theAngle)
	{
		return smethod_0(ImageName, SourceImage, theAngle);
	}

	private static Bitmap smethod_0(string string_0, object object_0, float float_0)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected O, but got Unknown
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Expected O, but got Unknown
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Expected O, but got Unknown
		//IL_00ca: Expected O, but got Unknown
		if ((int)Math.Round(float_0) == 0)
		{
			return (Bitmap)object_0;
		}
		if (object_0 == null)
		{
			return null;
		}
		Image value = null;
		Client.Cache_RotatedImages.TryGetValue(string_0 + Conversions.ToString((int)Math.Round(float_0)), out value);
		if (Information.IsNothing((object)value))
		{
			Bitmap val = new Bitmap(((Image)object_0).Width, ((Image)object_0).Height);
			Graphics obj = Graphics.FromImage((Image)val);
			obj.TranslateTransform((float)((Image)object_0).Width / 2f, (float)((Image)object_0).Height / 2f);
			obj.RotateTransform((float)(int)Math.Round(float_0));
			obj.TranslateTransform((0f - (float)((Image)object_0).Width) / 2f, (0f - (float)((Image)object_0).Height) / 2f);
			obj.SmoothingMode = (SmoothingMode)4;
			obj.DrawImage((Image)object_0, new Point(0, 0));
			value = (Image)val;
			Client.Cache_RotatedImages.Add(string_0 + Conversions.ToString((int)Math.Round(float_0)), value);
		}
		return (Bitmap)value;
	}

	public static void CenterMouseOverControl(Control ctl)
	{
		Point point = new Point((int)Math.Round((double)(ctl.Left + ctl.Right) / 2.0), (int)Math.Round((double)(ctl.Top + ctl.Bottom) / 2.0));
		MyProject.Forms.MainForm.CurrentMousePosition.X = point.X;
		MyProject.Forms.MainForm.CurrentMousePosition.Y = point.Y;
		Cursor.Position = ctl.Parent.PointToScreen(point);
	}

	public static Bitmap ResizeImage(Bitmap image, Size size, bool preserveAspectRatio = true)
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Expected O, but got Unknown
		int num = default(int);
		if (0 == ((Image)image).Width && num == ((Image)image).Height)
		{
			return image;
		}
		if (Client.Cache_ScaledBitmaps.TryGetValue((Image)(object)image, out var value))
		{
			return (Bitmap)value;
		}
		int num5;
		if (preserveAspectRatio)
		{
			int width = ((Image)image).Width;
			int height = ((Image)image).Height;
			float num2 = (float)size.Width / (float)width;
			float num3 = (float)size.Height / (float)height;
			float num4 = ((num3 < num2) ? num3 : num2);
			num5 = (int)Math.Round((float)width * num4);
			num = (int)Math.Round((float)height * num4);
		}
		else
		{
			num5 = size.Width;
			num = size.Height;
		}
		Bitmap val = new Bitmap(num5, num);
		Graphics val2 = Graphics.FromImage((Image)(object)val);
		try
		{
			val2.InterpolationMode = (InterpolationMode)7;
			val2.DrawImage((Image)(object)image, 0, 0, num5, num);
		}
		finally
		{
			((IDisposable)val2)?.Dispose();
		}
		Client.Cache_ScaledBitmaps.Add((Image)(object)image, (Image)(object)val);
		return val;
	}

	public static ReadOnlyCollection<TreeNode> AllNodes(this TreeView theTV)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		List<TreeNode> list = new List<TreeNode>();
		foreach (TreeNode node in theTV.Nodes)
		{
			TreeNode val = node;
			if (!list.Contains(val))
			{
				list.Add(val);
			}
			smethod_1(val, list);
		}
		return list.AsReadOnly();
	}

	public static void ExpandAll(this DarkTreeView theTV)
	{
		ReadOnlyCollection<DarkTreeNode> readOnlyCollection = AllNodes(theTV);
		foreach (DarkTreeNode item in readOnlyCollection)
		{
			item.Expanded = true;
		}
	}

	public static void ExpandAll(this DarkFilterTreeView theTV)
	{
		ReadOnlyCollection<DarkFilterTreeNode> readOnlyCollection = AllNodes(theTV);
		foreach (DarkFilterTreeNode item in readOnlyCollection)
		{
			item.Expanded = true;
		}
	}

	public static void CollapseAll(this DarkTreeView theTV)
	{
		ReadOnlyCollection<DarkTreeNode> readOnlyCollection = AllNodes(theTV);
		foreach (DarkTreeNode item in readOnlyCollection)
		{
			item.Expanded = false;
		}
	}

	public static void CollapseAll(this DarkFilterTreeView theTV)
	{
		ReadOnlyCollection<DarkFilterTreeNode> readOnlyCollection = AllNodes(theTV);
		foreach (DarkFilterTreeNode item in readOnlyCollection)
		{
			item.Expanded = false;
		}
	}

	public static ReadOnlyCollection<DarkTreeNode> AllNodes(this DarkTreeView theTV)
	{
		List<DarkTreeNode> list = new List<DarkTreeNode>();
		foreach (DarkTreeNode node in theTV.Nodes)
		{
			if (!list.Contains(node))
			{
				list.Add(node);
			}
			smethod_2(node, list);
		}
		return list.AsReadOnly();
	}

	public static ReadOnlyCollection<DarkFilterTreeNode> AllNodes(this DarkFilterTreeView theTV)
	{
		List<DarkFilterTreeNode> list = new List<DarkFilterTreeNode>();
		foreach (DarkFilterTreeNode node in theTV.Nodes)
		{
			if (!list.Contains(node))
			{
				list.Add(node);
			}
			smethod_3(node, list);
		}
		return list.AsReadOnly();
	}

	[AsyncStateMachine(typeof(VB$StateMachine_23_RenderCustomHTML))]
	public static void RenderCustomHTML(this WebView2 theBrowser, string theHTML, string TheCSS = "", AdvancedDialog AdvancedDialog = null)
	{
		VB$StateMachine_23_RenderCustomHTML stateMachine = default(VB$StateMachine_23_RenderCustomHTML);
		stateMachine.$VB$Local_theBrowser = theBrowser;
		stateMachine.$VB$Local_theHTML = theHTML;
		stateMachine.$VB$Local_TheCSS = TheCSS;
		stateMachine.$VB$Local_AdvancedDialog = AdvancedDialog;
		stateMachine.$State = -1;
		stateMachine.$Builder = AsyncVoidMethodBuilder.Create();
		stateMachine.$Builder.Start(ref stateMachine);
	}

	[DllImport("kernel32.dll")]
	private static extern int GetCurrentThreadId();

	public static void SetCurrentThreadAffinity(IntPtr affinityMask)
	{
		int currentThreadId = GetCurrentThreadId();
		foreach (ProcessThread thread in Process.GetCurrentProcess().Threads)
		{
			if (thread.Id == currentThreadId)
			{
				thread.ProcessorAffinity = affinityMask;
				break;
			}
		}
	}

	public static ActiveUnit AssignmentFiringPlatform(this WeaponAssignment theWA, List<ActiveUnit> AttackersList)
	{
		return null;
	}

	public static string ScenDescription_InsertImagePath(string DescriptionText, string ScenFilePath)
	{
		string directoryName = Path.GetDirectoryName(ScenFilePath);
		DescriptionText = DescriptionText.Replace("src=\\\"", "src=\\\"" + directoryName + Conversions.ToString(Path.PathSeparator));
		return DescriptionText;
	}

	private static void smethod_1(TreeNode treeNode_0, List<TreeNode> list_0)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Expected O, but got Unknown
		foreach (TreeNode node in treeNode_0.Nodes)
		{
			TreeNode val = node;
			if (!list_0.Contains(val))
			{
				list_0.Add(val);
			}
			smethod_1(val, list_0);
		}
	}

	private static void smethod_2(DarkTreeNode darkTreeNode_0, List<DarkTreeNode> list_0)
	{
		foreach (DarkTreeNode node in darkTreeNode_0.Nodes)
		{
			if (!list_0.Contains(node))
			{
				list_0.Add(node);
			}
			smethod_2(node, list_0);
		}
	}

	private static void smethod_3(DarkFilterTreeNode darkFilterTreeNode_0, List<DarkFilterTreeNode> list_0)
	{
		foreach (DarkFilterTreeNode node in darkFilterTreeNode_0.Nodes)
		{
			if (!list_0.Contains(node))
			{
				list_0.Add(node);
			}
			smethod_3(node, list_0);
		}
	}

	public static ReadOnlyCollection<TreeGridNode> AllNodes(this TreeGridView theTGV)
	{
		List<TreeGridNode> list = new List<TreeGridNode>();
		foreach (TreeGridNode node in theTGV.Nodes)
		{
			if (!list.Contains(node))
			{
				list.Add(node);
			}
			smethod_4(node, list);
		}
		return list.AsReadOnly();
	}

	private static void smethod_4(TreeGridNode treeGridNode_0, List<TreeGridNode> list_0)
	{
		foreach (TreeGridNode node in treeGridNode_0.Nodes)
		{
			if (!list_0.Contains(node))
			{
				list_0.Add(node);
			}
			smethod_4(node, list_0);
		}
	}

	public static bool IsSelectedForIsolatedPOV(this ActiveUnit theUnit)
	{
		bool result;
		try
		{
			result = !string.IsNullOrEmpty(Client.CurrentMapProfile.IsolatedPOVObjectID) && Operators.CompareString(theUnit.ObjectID, Client.CurrentMapProfile.IsolatedPOVObjectID, true) == 0;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			int num;
			if (!Debugger.IsAttached)
			{
				num = 0;
			}
			else
			{
				Debugger.Break();
				num = 0;
			}
			result = (byte)num != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static void EnterFullScreenMode(Form targetForm, bool SlideRC = true)
	{
		((Control)targetForm).SuspendLayout();
		targetForm.WindowState = (FormWindowState)0;
		targetForm.FormBorderStyle = (FormBorderStyle)0;
		targetForm.WindowState = (FormWindowState)2;
		if ((object)targetForm == MyProject.Forms.m_MainForm && SlideRC)
		{
			MyProject.Forms.MainForm.Slide_RC_In();
		}
		((Control)targetForm).ResumeLayout();
	}

	public static void LeaveFullScreenMode(Form targetForm)
	{
		((Control)targetForm).SuspendLayout();
		targetForm.FormBorderStyle = (FormBorderStyle)4;
		targetForm.WindowState = (FormWindowState)2;
		((Control)targetForm).ResumeLayout();
	}

	public static string GetOSVersion()
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected O, but got Unknown
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		string result = "";
		ManagementClass val = new ManagementClass("Win32_OperatingSystem");
		ManagementObjectEnumerator enumerator = default(ManagementObjectEnumerator);
		try
		{
			enumerator = val.GetInstances().GetEnumerator();
			while (enumerator.MoveNext())
			{
				result = (string)((ManagementBaseObject)(ManagementObject)enumerator.Current).GetPropertyValue("Version");
			}
			return result;
		}
		finally
		{
			((IDisposable)enumerator)?.Dispose();
		}
	}

	public static void ReplaceColor(ref Bitmap bmp, Color oldColor, Color newColor)
	{
		LockBitmap lockBitmap = new LockBitmap(bmp);
		lockBitmap.LockBits();
		int depth = lockBitmap.Depth;
		byte[] pixels = lockBitmap.Pixels;
		int num = lockBitmap.Height - 1;
		for (int i = 0; i <= num; i++)
		{
			int num2 = lockBitmap.Width - 1;
			for (int j = 0; j <= num2; j++)
			{
				Color pixel = lockBitmap.GetPixel(j, i, depth, pixels);
				if (pixel.A == oldColor.A && pixel.R == oldColor.R && pixel.G == oldColor.G && pixel.B == oldColor.B)
				{
					lockBitmap.SetPixel(j, i, newColor);
				}
			}
		}
		lockBitmap.UnlockBits();
	}

	public static void DiscoverDPISetting_UsingBitmap()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Expected O, but got Unknown
		Bitmap val = new Bitmap(1, 1);
		float dpiX;
		try
		{
			Graphics val2 = Graphics.FromImage((Image)(object)val);
			try
			{
				dpiX = val2.DpiX;
				_ = val2.DpiY;
			}
			finally
			{
				((IDisposable)val2)?.Dispose();
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
		Client.DPI_scale = dpiX / 96f;
	}

	public static void smethod_5(Form theForm)
	{
		try
		{
			int num = Conversions.ToInteger(Registry.GetValue("HKEY_CURRENT_USER\\Control Panel\\Desktop", "LogPixels", (object)null));
			if (num > 0)
			{
				Client.DPI_scale = (float)((double)num / 96.0);
				if (SimConfiguration.DefaultGamePreferences.LogDebugInfoToFile)
				{
					GameGeneral.WriteLogDebugInfoToFile("DPI registry setting, HKEY_CURRENT_USER\\Control Panel\\Desktop\\LogPixels:" + Conversions.ToString(num) + ".");
				}
				return;
			}
			if (Client.DPI_scale == 0f)
			{
				num = Conversions.ToInteger(Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\FontDPI", "LogPixels", (object)null));
				if (num > 0)
				{
					Client.DPI_scale = (float)((double)num / 96.0);
					if (SimConfiguration.DefaultGamePreferences.LogDebugInfoToFile)
					{
						GameGeneral.WriteLogDebugInfoToFile("DPI registry setting, HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\FontDPI\\LogPixels:" + Conversions.ToString(num) + ".");
					}
					return;
				}
			}
			if (Client.DPI_scale == 0f)
			{
				num = Conversions.ToInteger(Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Wow6432Node\\Microsoft\\Windows NT\\CurrentVersion\\FontDPI", "LogPixels", (object)null));
				if (num > 0)
				{
					Client.DPI_scale = (float)((double)num / 96.0);
					if (SimConfiguration.DefaultGamePreferences.LogDebugInfoToFile)
					{
						GameGeneral.WriteLogDebugInfoToFile("DPI registry setting, HKEY_LOCAL_MACHINE\\SOFTWARE\\Wow6432Node\\Microsoft\\Windows NT\\CurrentVersion\\FontDPI\\LogPixels:" + Conversions.ToString(num) + ".");
					}
					return;
				}
			}
			if (Client.DPI_scale == 0f)
			{
				Graphics val = ((Control)theForm).CreateGraphics();
				try
				{
					Client.DPI_scale = val.DpiX / 96f;
				}
				finally
				{
					((IDisposable)val)?.Dispose();
				}
				if (SimConfiguration.DefaultGamePreferences.LogDebugInfoToFile)
				{
					GameGeneral.WriteLogDebugInfoToFile("DPI scale: " + Conversions.ToString(Client.DPI_scale) + ".");
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 219354783495687", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static string WithUpdatedTimestamp(string originalPath)
	{
		string? directoryName = Path.GetDirectoryName(originalPath);
		string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(originalPath);
		string extension = Path.GetExtension(originalPath);
		string pattern = "_\\d{8}_\\d{6}$";
		string text = "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
		string text2 = ((!Regex.IsMatch(fileNameWithoutExtension, pattern)) ? (fileNameWithoutExtension + text) : Regex.Replace(fileNameWithoutExtension, pattern, text));
		return Path.Combine(directoryName, text2 + extension);
	}

	public static void SortTreeViewTopLevelNodes(DarkTreeView treeView)
	{
		DarkTreeNode[] array = new DarkTreeNode[treeView.Nodes.Count - 1 + 1];
		treeView.Nodes.CopyTo(array, 0);
		array = array.OrderBy([SpecialName] (DarkTreeNode theItem) => smethod_6(theItem), new NaturalSortComparer<string[]>()).ToArray();
		treeView.Nodes.Clear();
		treeView.Nodes.AddRange(array);
	}

	private static string smethod_6(DarkTreeNode darkTreeNode_0)
	{
		if (darkTreeNode_0.Tag is string)
		{
			return Conversions.ToString(darkTreeNode_0.Tag);
		}
		return ((ActiveUnit)darkTreeNode_0.Tag).Name;
	}

	public static bool IsValidXml(string path)
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		bool result;
		try
		{
			XmlReader val = XmlReader.Create(path);
			try
			{
				while (val.Read())
				{
				}
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
			result = true;
		}
		catch (XmlException ex)
		{
			ProjectData.SetProjectError((Exception)ex);
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}
}
