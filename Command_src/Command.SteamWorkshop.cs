using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using Command_Core;
using Command.My;
using DarkUI.Forms;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.Devices;
using Steamworks;

namespace Command;

[StandardModule]
public sealed class SteamWorkshop
{
	public sealed class WorkshopItem
	{
		[CompilerGenerated]
		private bool bool_0;

		[CompilerGenerated]
		private bool bool_1;

		[CompilerGenerated]
		private bool bool_2;

		[CompilerGenerated]
		private bool bool_3;

		[CompilerGenerated]
		private bool bool_4;

		[CompilerGenerated]
		private PublishedFileId_t publishedFileId_t_0;

		[CompilerGenerated]
		private bool bool_5;

		[CompilerGenerated]
		private ulong ulong_0;

		[CompilerGenerated]
		private ulong ulong_1;

		[CompilerGenerated]
		private bool bool_6;

		[CompilerGenerated]
		private ulong ulong_2;

		[CompilerGenerated]
		private string string_0;

		[CompilerGenerated]
		private uint uint_0;

		[CompilerGenerated]
		private bool bool_7;

		public bool Subscribed
		{
			[CompilerGenerated]
			get
			{
				return bool_0;
			}
			[CompilerGenerated]
			set
			{
				bool_0 = value;
			}
		}

		public bool Installed
		{
			[CompilerGenerated]
			get
			{
				return bool_1;
			}
			[CompilerGenerated]
			set
			{
				bool_1 = value;
			}
		}

		public bool NeedsUpdate
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

		public bool Downloading
		{
			[CompilerGenerated]
			get
			{
				return bool_3;
			}
			[CompilerGenerated]
			set
			{
				bool_3 = value;
			}
		}

		public bool DownloadPending
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

		public PublishedFileId_t FileId
		{
			[CompilerGenerated]
			get
			{
				return publishedFileId_t_0;
			}
			[CompilerGenerated]
			set
			{
				publishedFileId_t_0 = value;
			}
		}

		public bool DownloadInfoAvailable
		{
			[CompilerGenerated]
			get
			{
				return bool_5;
			}
			[CompilerGenerated]
			set
			{
				bool_5 = value;
			}
		}

		public ulong BytesDownloaded
		{
			[CompilerGenerated]
			get
			{
				return ulong_0;
			}
			[CompilerGenerated]
			set
			{
				ulong_0 = value;
			}
		}

		public ulong BytesTotal
		{
			[CompilerGenerated]
			get
			{
				return ulong_1;
			}
			[CompilerGenerated]
			set
			{
				ulong_1 = value;
			}
		}

		public bool GoodToGo
		{
			[CompilerGenerated]
			get
			{
				return bool_6;
			}
			[CompilerGenerated]
			set
			{
				bool_6 = value;
			}
		}

		public ulong punSizeOnDisk
		{
			[CompilerGenerated]
			get
			{
				return ulong_2;
			}
			[CompilerGenerated]
			set
			{
				ulong_2 = value;
			}
		}

		public string pchFolder
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

		public uint punTimeStamp
		{
			[CompilerGenerated]
			get
			{
				return uint_0;
			}
			[CompilerGenerated]
			set
			{
				uint_0 = value;
			}
		}

		public bool AlreadyInstalled
		{
			[CompilerGenerated]
			get
			{
				return bool_7;
			}
			[CompilerGenerated]
			set
			{
				bool_7 = value;
			}
		}

		public WorkshopItem(PublishedFileId_t FileId)
		{
			this.FileId = FileId;
			uint itemState = SteamUGC.GetItemState(FileId);
			Subscribed = ((ulong)itemState & 1uL) > 0L;
			Installed = ((ulong)itemState & 4uL) > 0L;
			NeedsUpdate = ((ulong)itemState & 8uL) > 0L;
			Downloading = ((ulong)itemState & 0x10uL) > 0L;
			DownloadPending = ((ulong)itemState & 0x20uL) > 0L;
			ulong punBytesDownloaded = BytesDownloaded;
			ulong punBytesTotal = BytesTotal;
			bool itemDownloadInfo = SteamUGC.GetItemDownloadInfo(FileId, out punBytesDownloaded, out punBytesTotal);
			BytesTotal = punBytesTotal;
			BytesDownloaded = punBytesDownloaded;
			DownloadInfoAvailable = itemDownloadInfo;
			GoodToGo = true;
			if ((NeedsUpdate | !Installed) && SteamUGC.DownloadItem(FileId, bHighPriority: false))
			{
				GoodToGo = false;
			}
			if (GoodToGo)
			{
				punBytesTotal = punSizeOnDisk;
				string text = pchFolder;
				uint num = punTimeStamp;
				bool itemInstallInfo = SteamUGC.GetItemInstallInfo(FileId, out punBytesTotal, out text, 1024u, out num);
				punTimeStamp = num;
				pchFolder = text;
				punSizeOnDisk = punBytesTotal;
				AlreadyInstalled = itemInstallInfo;
			}
		}

		public void CopyDataToScenarioFolder()
		{
			if (!Installed)
			{
				return;
			}
			try
			{
				if (Directory.Exists(pchFolder))
				{
					CopyDirectoryLazy(pchFolder, Client.SteamWorkshopFolder, copySubDirs: true);
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}

		public void CopyDirectoryLazy(string sourceDirName, string destDirName, bool copySubDirs)
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(sourceDirName);
			DirectoryInfo[] directories = directoryInfo.GetDirectories();
			if (!directoryInfo.Exists)
			{
				throw new DirectoryNotFoundException(Convert.ToString("Source directory does not exist or could not be found: ") + sourceDirName);
			}
			if (!Directory.Exists(destDirName))
			{
				Directory.CreateDirectory(destDirName);
			}
			FileInfo[] files = directoryInfo.GetFiles();
			foreach (FileInfo fileInfo in files)
			{
				string text = Path.Combine(destDirName, fileInfo.Name);
				if (FileExistsNative.FileExistsFast(text))
				{
					FileInfo fileInfo2 = ((ServerComputer)MyProject.Computer).FileSystem.GetFileInfo(text);
					FileInfo fileInfo3 = ((ServerComputer)MyProject.Computer).FileSystem.GetFileInfo(fileInfo.FullName);
					if ((DateTime.Compare(fileInfo2.LastWriteTimeUtc, fileInfo3.LastWriteTimeUtc) == 0) & (fileInfo2.Length == fileInfo3.Length))
					{
						continue;
					}
				}
				fileInfo.CopyTo(text, overwrite: true);
				Thread.Sleep(100);
			}
			if (copySubDirs)
			{
				DirectoryInfo[] array = directories;
				foreach (DirectoryInfo directoryInfo2 in array)
				{
					string destDirName2 = Path.Combine(destDirName, directoryInfo2.Name);
					CopyDirectoryLazy(directoryInfo2.FullName, destDirName2, copySubDirs);
				}
			}
		}

		static WorkshopItem()
		{
			Class72.smethod_20();
		}
	}

	public sealed class SteamWorkshopScenario
	{
		public string Name;

		public string Description;

		public List<string> Tags;

		public string ScenFileName;

		public string PreviewFilePath;

		public string WorkingDirectory;

		static SteamWorkshopScenario()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__37-0
	{
		public SteamUGCDetails_t $VB$Local_pDetails;

		public _Closure$__37-0(_Closure$__37-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_pDetails = arg0.$VB$Local_pDetails;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(SteamUGCDetails_t f)
		{
			return f.m_nPublishedFileId.m_PublishedFileId == $VB$Local_pDetails.m_nPublishedFileId.m_PublishedFileId;
		}

		static _Closure$__37-0()
		{
			Class72.smethod_20();
		}
	}

	public static SteamWorkshopScenario workshopScenarioUploadInformation;

	private static List<PublishedFileId_t> list_0;

	public static List<WorkshopItem> SubscribedWorkshopItems;

	public static ERemoteStoragePublishedFileVisibility visibiltyWorkshopItem;

	private static CallResult<CreateItemResult_t> callResult_0;

	private static CreateItemResult_t createItemResult_t_0;

	private static CallResult<SubmitItemUpdateResult_t> callResult_1;

	private static SubmitItemUpdateResult_t submitItemUpdateResult_t_0;

	private static CallResult<RemoteStoragePublishedFileSubscribed_t> callResult_2;

	private static RemoteStoragePublishedFileSubscribed_t remoteStoragePublishedFileSubscribed_t_0;

	private static CallResult<RemoteStoragePublishedFileUnsubscribed_t> callResult_3;

	private static RemoteStoragePublishedFileUnsubscribed_t remoteStoragePublishedFileUnsubscribed_t_0;

	private static CallResult<ItemInstalled_t> callResult_4;

	private static ItemInstalled_t itemInstalled_t_0;

	private static CallResult<DownloadItemResult_t> callResult_5;

	private static DownloadItemResult_t downloadItemResult_t_0;

	private static CallResult<SteamUGCQueryCompleted_t> callResult_6;

	private static SteamUGCQueryCompleted_t steamUGCQueryCompleted_t_0;

	public static bool ReEnableUIForms;

	public static bool CloseUIForms;

	private static LockObject lockObject_0;

	private static bool bool_0;

	private static UGCQueryHandle_t ugcqueryHandle_t_0;

	public static List<SteamUGCDetails_t> UserScens;

	private static uint uint_0;

	private static uint uint_1;

	static SteamWorkshop()
	{
		Class72.smethod_20();
		SubscribedWorkshopItems = new List<WorkshopItem>();
		visibiltyWorkshopItem = ERemoteStoragePublishedFileVisibility.k_ERemoteStoragePublishedFileVisibilityPublic;
		ReEnableUIForms = false;
		CloseUIForms = false;
		lockObject_0 = new LockObject();
		bool_0 = false;
		UserScens = new List<SteamUGCDetails_t>();
		uint_0 = 0u;
		uint_1 = 0u;
	}

	public static void Update(SteamWorkshopScenario a, SteamUGCDetails_t existing)
	{
		if (CommandSteam.steamOnline)
		{
			((Control)MyProject.Forms.SteamUpdateScenarioForm).Enabled = false;
			workshopScenarioUploadInformation = a;
			if (workshopScenarioUploadInformation.Name.Length > 120)
			{
				workshopScenarioUploadInformation.Name = workshopScenarioUploadInformation.Name.Substring(0, 100);
			}
			if (workshopScenarioUploadInformation.Description.Length > 7500)
			{
				workshopScenarioUploadInformation.Description = workshopScenarioUploadInformation.Description.Substring(0, 7500);
			}
			workshopScenarioUploadInformation.Tags = new List<string>();
			workshopScenarioUploadInformation.Tags.Add("Scenario");
			if (!string.IsNullOrEmpty(workshopScenarioUploadInformation.Name))
			{
				if (!string.IsNullOrEmpty(workshopScenarioUploadInformation.Description))
				{
					if (!string.IsNullOrEmpty(workshopScenarioUploadInformation.ScenFileName))
					{
						if (string.IsNullOrEmpty(workshopScenarioUploadInformation.PreviewFilePath))
						{
							throw new ArgumentNullException();
						}
						workshopScenarioUploadInformation.WorkingDirectory = Path.Combine(Path.GetTempPath() + workshopScenarioUploadInformation.ScenFileName);
						Directory.CreateDirectory(workshopScenarioUploadInformation.WorkingDirectory);
						Directory.CreateDirectory(Path.Combine(workshopScenarioUploadInformation.WorkingDirectory, "attachments"));
						Client.SaveCurrentScenario(SBR: false, Path.Combine(workshopScenarioUploadInformation.WorkingDirectory, workshopScenarioUploadInformation.ScenFileName + ".scen"));
						workshopScenarioUploadInformation.PreviewFilePath = Path.GetFullPath(workshopScenarioUploadInformation.PreviewFilePath);
						foreach (KeyValuePair<string, ScenAttachmentObject> scenAttachment in Client.CurrentScenario.ScenAttachments)
						{
							if (Directory.Exists(Path.Combine(GameGeneral.AttachmentRepoPath, scenAttachment.Key)))
							{
								Misc.CopyDirectory(Path.Combine(GameGeneral.AttachmentRepoPath, scenAttachment.Key), Path.Combine(workshopScenarioUploadInformation.WorkingDirectory, "attachments", scenAttachment.Key), copySubDirs: true);
							}
						}
						UGCUpdateHandle_t uGCUpdateHandle_t = SteamUGC.StartItemUpdate(Licensing.appID_FullBaseVersion, existing.m_nPublishedFileId);
						SteamUGC.SetItemTitle(uGCUpdateHandle_t, workshopScenarioUploadInformation.Name);
						SteamUGC.SetItemDescription(uGCUpdateHandle_t, workshopScenarioUploadInformation.Description);
						SteamUGC.SetItemVisibility(uGCUpdateHandle_t, visibiltyWorkshopItem);
						SteamUGC.SetItemTags(uGCUpdateHandle_t, workshopScenarioUploadInformation.Tags);
						SteamUGC.SetItemContent(uGCUpdateHandle_t, workshopScenarioUploadInformation.WorkingDirectory);
						SteamUGC.SetItemPreview(uGCUpdateHandle_t, workshopScenarioUploadInformation.PreviewFilePath);
						SteamAPICall_t hAPICall = SteamUGC.SubmitItemUpdate(uGCUpdateHandle_t, "Update");
						callResult_1.Set(hAPICall);
						return;
					}
					throw new ArgumentNullException();
				}
				throw new ArgumentNullException();
			}
			throw new ArgumentNullException();
		}
		throw new WorkshopNotSupportedException();
	}

	public static void Publish(SteamWorkshopScenario a)
	{
		if (CommandSteam.steamOnline)
		{
			((Control)MyProject.Forms.SteamPublishScenarioForm).Enabled = false;
			workshopScenarioUploadInformation = a;
			if (workshopScenarioUploadInformation.Name.Length > 120)
			{
				workshopScenarioUploadInformation.Name = workshopScenarioUploadInformation.Name.Take(127).ToString();
			}
			if (workshopScenarioUploadInformation.Description.Length > 7500)
			{
				workshopScenarioUploadInformation.Description = workshopScenarioUploadInformation.Description.Take(7999).ToString();
			}
			workshopScenarioUploadInformation.Tags = new List<string>();
			workshopScenarioUploadInformation.Tags.Add("Scenario");
			if (string.IsNullOrEmpty(workshopScenarioUploadInformation.Name))
			{
				throw new ArgumentNullException();
			}
			if (!string.IsNullOrEmpty(workshopScenarioUploadInformation.Description))
			{
				if (!string.IsNullOrEmpty(workshopScenarioUploadInformation.ScenFileName))
				{
					if (string.IsNullOrEmpty(workshopScenarioUploadInformation.PreviewFilePath))
					{
						throw new ArgumentNullException();
					}
					workshopScenarioUploadInformation.WorkingDirectory = Path.Combine(Path.GetTempPath() + workshopScenarioUploadInformation.ScenFileName);
					Directory.CreateDirectory(workshopScenarioUploadInformation.WorkingDirectory);
					Directory.CreateDirectory(Path.Combine(workshopScenarioUploadInformation.WorkingDirectory, "attachments"));
					Client.SaveCurrentScenario(SBR: false, Path.Combine(workshopScenarioUploadInformation.WorkingDirectory, workshopScenarioUploadInformation.ScenFileName + ".scen"));
					workshopScenarioUploadInformation.PreviewFilePath = Path.GetFullPath(workshopScenarioUploadInformation.PreviewFilePath);
					foreach (KeyValuePair<string, ScenAttachmentObject> scenAttachment in Client.CurrentScenario.ScenAttachments)
					{
						if (Directory.Exists(Path.Combine(GameGeneral.AttachmentRepoPath, scenAttachment.Key)))
						{
							Misc.CopyDirectory(Path.Combine(GameGeneral.AttachmentRepoPath, scenAttachment.Key), Path.Combine(workshopScenarioUploadInformation.WorkingDirectory, "attachments", scenAttachment.Key), copySubDirs: true);
						}
					}
					SteamAPICall_t hAPICall = SteamUGC.CreateItem(Licensing.appID_FullBaseVersion, EWorkshopFileType.k_EWorkshopFileTypeFirst);
					callResult_0.Set(hAPICall);
					return;
				}
				throw new ArgumentNullException();
			}
			throw new ArgumentNullException();
		}
		throw new WorkshopNotSupportedException();
	}

	public static void Open()
	{
		if (CommandSteam.steamOnline)
		{
			callResult_0 = new CallResult<CreateItemResult_t>(smethod_5);
			callResult_1 = new CallResult<SubmitItemUpdateResult_t>(smethod_4);
			callResult_2 = new CallResult<RemoteStoragePublishedFileSubscribed_t>(smethod_6);
			callResult_3 = new CallResult<RemoteStoragePublishedFileUnsubscribed_t>(smethod_7);
			callResult_4 = new CallResult<ItemInstalled_t>(smethod_8);
			callResult_5 = new CallResult<DownloadItemResult_t>(smethod_3);
			callResult_6 = new CallResult<SteamUGCQueryCompleted_t>(smethod_2);
			UpdateSubscribedItems();
			QueryUserUGC();
		}
	}

	public static void UpdateSubscribedItems()
	{
		if (bool_0)
		{
			return;
		}
		lock (lockObject_0)
		{
			bool_0 = true;
			if (!CommandSteam.steamOnline)
			{
				return;
			}
			uint numSubscribedItems = SteamUGC.GetNumSubscribedItems();
			PublishedFileId_t[] array = new PublishedFileId_t[numSubscribedItems + 1];
			SteamUGC.GetSubscribedItems(array, numSubscribedItems);
			list_0 = array.ToList();
			List<WorkshopItem> list = new List<WorkshopItem>();
			foreach (PublishedFileId_t item in list_0)
			{
				list.Add(new WorkshopItem(item));
			}
			SubscribedWorkshopItems = list;
			QueryUserUGC();
			bool_0 = false;
		}
	}

	private static void smethod_0(PublishedFileId_t publishedFileId_t_0)
	{
		WorkshopItem workshopItem = new WorkshopItem(publishedFileId_t_0);
		if (workshopItem.GoodToGo)
		{
			workshopItem.CopyDataToScenarioFolder();
		}
	}

	public static void RunCallbacks()
	{
		if (CommandSteam.steamOnline)
		{
			SteamAPI.RunCallbacks();
		}
	}

	private static void smethod_1(object object_0, bool bool_1)
	{
		if (CommandSteam.steamOnline)
		{
			if (!bool_1)
			{
				if (object_0 == null)
				{
					throw new WorkshopException("Null callback object");
				}
				return;
			}
			throw new WorkshopException("IO Failure");
		}
		throw new WorkshopNotSupportedException();
	}

	public static void QueryUserUGC()
	{
		AccountID_t accountID = SteamUser.GetSteamID().GetAccountID();
		UserScens = new List<SteamUGCDetails_t>();
		ugcqueryHandle_t_0 = SteamUGC.CreateQueryUserUGCRequest(accountID, EUserUGCList.k_EUserUGCList_Published, EUGCMatchingUGCType.k_EUGCMatchingUGCType_Items_ReadyToUse, EUserUGCListSortOrder.k_EUserUGCListSortOrder_TitleAsc, Licensing.appID_FullBaseVersion, Licensing.appID_FullBaseVersion, 1u);
		uint_0 = 0u;
		uint_1 = 1u;
		SteamAPICall_t hAPICall = SteamUGC.SendQueryUGCRequest(ugcqueryHandle_t_0);
		callResult_6.Set(hAPICall);
	}

	private static void smethod_2(SteamUGCQueryCompleted_t steamUGCQueryCompleted_t_1, bool bool_1)
	{
		smethod_1(steamUGCQueryCompleted_t_1, bool_1);
		if ((long)steamUGCQueryCompleted_t_1.m_unNumResultsReturned > 0L)
		{
			uint num = (uint)((ulong)steamUGCQueryCompleted_t_1.m_unNumResultsReturned - 1uL);
			_Closure$__37-0 closure$__37- = default(_Closure$__37-0);
			for (uint num2 = 0u; num2 <= num; num2++)
			{
				closure$__37- = new _Closure$__37-0(closure$__37-);
				if (SteamUGC.GetQueryUGCResult(steamUGCQueryCompleted_t_1.m_handle, num2, out closure$__37-.$VB$Local_pDetails) && !UserScens.Any(closure$__37-._Lambda$__0))
				{
					UserScens.Add(closure$__37-.$VB$Local_pDetails);
				}
			}
		}
		uint_0 += steamUGCQueryCompleted_t_1.m_unNumResultsReturned;
		SteamUGC.ReleaseQueryUGCRequest(steamUGCQueryCompleted_t_1.m_handle);
		if (uint_0 >= steamUGCQueryCompleted_t_1.m_unTotalMatchingResults)
		{
			if (SteamUpdateScenarioForm.CurrentForm != null && !((Control)SteamUpdateScenarioForm.CurrentForm).IsDisposed)
			{
				((Control)SteamUpdateScenarioForm.CurrentForm).BeginInvoke((Delegate)(VB$AnonymousDelegate_0)([SpecialName] () =>
				{
					SteamUpdateScenarioForm.CurrentForm.ReloadWorkshopItems();
				}));
			}
		}
		else
		{
			uint_1 = (uint)((ulong)uint_1 + 1uL);
			ugcqueryHandle_t_0 = SteamUGC.CreateQueryUserUGCRequest(SteamUser.GetSteamID().GetAccountID(), EUserUGCList.k_EUserUGCList_Published, EUGCMatchingUGCType.k_EUGCMatchingUGCType_Items_ReadyToUse, EUserUGCListSortOrder.k_EUserUGCListSortOrder_TitleAsc, Licensing.appID_FullBaseVersion, Licensing.appID_FullBaseVersion, uint_1);
			SteamAPICall_t hAPICall = SteamUGC.SendQueryUGCRequest(ugcqueryHandle_t_0);
			callResult_6.Set(hAPICall);
		}
	}

	private static void smethod_3(DownloadItemResult_t downloadItemResult_t_1, bool bool_1)
	{
		smethod_1(downloadItemResult_t_1, bool_1);
		if (downloadItemResult_t_1.m_unAppID.m_AppId == Licensing.appID_FullBaseVersion.m_AppId)
		{
			downloadItemResult_t_0 = downloadItemResult_t_1;
			smethod_0(downloadItemResult_t_1.m_nPublishedFileId);
		}
	}

	private static void smethod_4(SubmitItemUpdateResult_t submitItemUpdateResult_t_1, bool bool_1)
	{
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		smethod_1(submitItemUpdateResult_t_1, bool_1);
		submitItemUpdateResult_t_0 = submitItemUpdateResult_t_1;
		ReEnableUIForms = true;
		if (submitItemUpdateResult_t_0.m_eResult == EResult.k_EResultOK)
		{
			DarkMessageBox.ShowInformation("The scenario has been successfully uploaded to Steam!", "Success");
			CloseUIForms = true;
		}
		else
		{
			DarkMessageBox.ShowError("There was a problem in uploading the scenario to Steam. The error code was: " + submitItemUpdateResult_t_0.m_eResult, "Error");
		}
		if (submitItemUpdateResult_t_0.m_bUserNeedsToAcceptWorkshopLegalAgreement)
		{
			Process.Start("http: //steamcommunity.com/sharedfiles/workshoplegalagreement");
			DarkMessageBox.ShowInformation("Please accept Steam Workshop Legal Agreement.", "");
		}
		if (!Directory.Exists(workshopScenarioUploadInformation.WorkingDirectory))
		{
			return;
		}
		try
		{
			Directory.Delete(workshopScenarioUploadInformation.WorkingDirectory, recursive: true);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200423", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static void smethod_5(CreateItemResult_t createItemResult_t_1, bool bool_1)
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		smethod_1(createItemResult_t_1, bool_1);
		createItemResult_t_0 = createItemResult_t_1;
		if (createItemResult_t_0.m_bUserNeedsToAcceptWorkshopLegalAgreement)
		{
			Process.Start("http://steamcommunity.com/sharedfiles/workshoplegalagreement");
			DarkMessageBox.ShowInformation("Please accept Steam Workshop Legal Agreement.", "");
		}
		UGCUpdateHandle_t uGCUpdateHandle_t = SteamUGC.StartItemUpdate(Licensing.appID_FullBaseVersion, createItemResult_t_0.m_nPublishedFileId);
		SteamUGC.SetItemTitle(uGCUpdateHandle_t, workshopScenarioUploadInformation.Name);
		SteamUGC.SetItemDescription(uGCUpdateHandle_t, workshopScenarioUploadInformation.Description);
		SteamUGC.SetItemVisibility(uGCUpdateHandle_t, visibiltyWorkshopItem);
		SteamUGC.SetItemTags(uGCUpdateHandle_t, workshopScenarioUploadInformation.Tags);
		SteamUGC.SetItemContent(uGCUpdateHandle_t, workshopScenarioUploadInformation.WorkingDirectory);
		SteamUGC.SetItemPreview(uGCUpdateHandle_t, workshopScenarioUploadInformation.PreviewFilePath);
		SteamAPICall_t hAPICall = SteamUGC.SubmitItemUpdate(uGCUpdateHandle_t, "Initial Upload");
		callResult_1.Set(hAPICall);
	}

	private static void smethod_6(RemoteStoragePublishedFileSubscribed_t remoteStoragePublishedFileSubscribed_t_1, bool bool_1)
	{
		smethod_1(remoteStoragePublishedFileSubscribed_t_1, bool_1);
		remoteStoragePublishedFileSubscribed_t_0 = remoteStoragePublishedFileSubscribed_t_1;
		smethod_0(remoteStoragePublishedFileSubscribed_t_1.m_nPublishedFileId);
	}

	private static void smethod_7(RemoteStoragePublishedFileUnsubscribed_t remoteStoragePublishedFileUnsubscribed_t_1, bool bool_1)
	{
		smethod_1(remoteStoragePublishedFileUnsubscribed_t_1, bool_1);
		remoteStoragePublishedFileUnsubscribed_t_0 = remoteStoragePublishedFileUnsubscribed_t_1;
		smethod_0(remoteStoragePublishedFileUnsubscribed_t_1.m_nPublishedFileId);
	}

	private static void smethod_8(ItemInstalled_t itemInstalled_t_1, bool bool_1)
	{
		smethod_1(itemInstalled_t_1, bool_1);
		if (itemInstalled_t_1.m_unAppID.m_AppId == Licensing.appID_FullBaseVersion.m_AppId)
		{
			itemInstalled_t_0 = itemInstalled_t_1;
			smethod_0(itemInstalled_t_1.m_nPublishedFileId);
		}
	}
}
