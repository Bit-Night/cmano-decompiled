using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Threading;
using Collections.Pooled;
using Command_Core;
using Command_Core.SmartAssembly.Attributes;
using Command.My;
using MapReduce.NET.CollectionsB;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DoNotPrune]
[DoNotObfuscate]
[DoNotPruneType]
public sealed class MessageLogControlViewModel : CommandViewModel
{
	[CompilerGenerated]
	internal sealed class _Closure$__60-0
	{
		public LoggedMessage $VB$Local_theM;

		public _Closure$__60-0(_Closure$__60-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theM = arg0.$VB$Local_theM;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(GClass4 MLSVM)
		{
			return Operators.CompareString(MLSVM.Summary, MessageTypeToBalloonText($VB$Local_theM.Type), true) == 0;
		}

		static _Closure$__60-0()
		{
			Class72.smethod_20();
		}
	}

	private List<GClass4> list_0;

	private ObservableCollection<GClass4> observableCollection_0;

	private ObservableCollection<MLDetailViewModel> vfuHbreLkkD;

	private ObservableCollection<GClass4> observableCollection_1;

	private ObservableCollection<GClass5> observableCollection_2;

	private bool bool_0;

	private double double_0;

	private int int_0;

	public long HighestIncrement;

	private DispatcherTimer dispatcherTimer_0;

	private int int_1;

	public Dictionary<string, bool> HeaderToShow;

	public bool ShowAll;

	private bool bool_1;

	private string string_0;

	public bool InteractiveMode;

	public bool MustRefresh;

	internal Queue<MLDetailViewModel> _ItemsRemovalQueue;

	private HashSet<long> hashSet_0;

	private HashSet<long> hashSet_1;

	private DateTime dateTime_0;

	private FastDictionary<int, SolidColorBrush> fastDictionary_0;

	private readonly LockRandom lockRandom_0;

	public List<GClass4> SummaryItemsOriginal
	{
		get
		{
			return list_0;
		}
		set
		{
			SetProperty(ref list_0, value, "SummaryItemsOriginal");
		}
	}

	public ObservableCollection<GClass4> SummaryItems
	{
		get
		{
			return observableCollection_0;
		}
		set
		{
			SetProperty(ref observableCollection_0, value, "SummaryItems");
		}
	}

	public ObservableCollection<MLDetailViewModel> FilteredSummaryDetailItems
	{
		get
		{
			return vfuHbreLkkD;
		}
		set
		{
			SetProperty(ref vfuHbreLkkD, value, "FilteredSummaryDetailItems");
		}
	}

	public ObservableCollection<GClass4> UniqueHeader
	{
		get
		{
			return observableCollection_1;
		}
		set
		{
			SetProperty(ref observableCollection_1, value, "UniqueHeader");
		}
	}

	public ObservableCollection<GClass5> Balloons
	{
		get
		{
			return observableCollection_2;
		}
		set
		{
			SetProperty(ref observableCollection_2, value, "Balloons");
		}
	}

	public bool LogCollapsed
	{
		get
		{
			return bool_0;
		}
		set
		{
			SetProperty(ref bool_0, value, "LogCollapsed");
		}
	}

	public double LogCollapseButtonRotation
	{
		get
		{
			return double_0;
		}
		set
		{
			SetProperty(ref double_0, value, "LogCollapseButtonRotation");
		}
	}

	public int MainFormLogWidth
	{
		get
		{
			return int_0;
		}
		set
		{
			SetProperty(ref int_0, value, "MainFormLogWidth");
		}
	}

	public string DisplayModeString
	{
		get
		{
			if (Operators.CompareString(string_0, "", true) != 0)
			{
				return string_0;
			}
			RawMode = false;
			string text = ">Raw";
			return ">Raw";
		}
		set
		{
			string_0 = value;
		}
	}

	public bool RawMode
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
			if (!bool_1)
			{
				DisplayModeString = ">Raw";
			}
			else
			{
				DisplayModeString = ">Inter.";
			}
			RefreshLoggedMessages();
		}
	}

	public void Update()
	{
		if (((Control)MyProject.Forms.MainForm.WorldWindow1).Width != int_1)
		{
			int_1 = ((Control)MyProject.Forms.MainForm.WorldWindow1).Width;
			MainFormLogWidth = (int)Math.Round((double)((Control)MyProject.Forms.MainForm.WorldWindow1).Width / 3.0);
			MyProject.Forms.MainForm.MainFormLogWidth = (int)Math.Round((double)((Control)MyProject.Forms.MainForm.WorldWindow1).Width / 3.0);
			int mainFormLogWidth = MainFormLogWidth;
			int height = ((Control)MyProject.Forms.MainForm.MessageLogControlElementHost1).Height;
			((Control)MyProject.Forms.MainForm.MessageLogControlElementHost1).MaximumSize = new Size(mainFormLogWidth, height);
			((Control)MyProject.Forms.MainForm.MessageLogControlElementHost1).MinimumSize = new Size(mainFormLogWidth, height);
			((Control)MyProject.Forms.MainForm.MessageLogControlElementHost1).Size = new Size(mainFormLogWidth, height);
		}
		RefreshLog();
	}

	public void ClearLog()
	{
		MustRefresh = true;
		SummaryItemsOriginal.Clear();
		UniqueHeader.Clear();
		Balloons.Clear();
	}

	public void ResetLog()
	{
		MustRefresh = true;
		HighestIncrement = 0L;
		SummaryItemsOriginal.Clear();
		Balloons.Clear();
	}

	public void RefreshLog()
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		if (dispatcherTimer_0 == null)
		{
			dispatcherTimer_0 = new DispatcherTimer();
			dispatcherTimer_0.Tick += dispatcherTimer_0_Tick;
			dispatcherTimer_0.Interval = new TimeSpan(0, 0, 0, 0, 100);
			dispatcherTimer_0.Start();
		}
		if (Client.CurrentSide == null)
		{
			return;
		}
		(PooledList<LoggedMessage>, PooledList<LoggedMessage>) tuple = Client.CurrentSide.get_MessageLog_Hybrid_Separated(Client.CurrentScenario);
		PooledList<LoggedMessage> item = tuple.Item1;
		PooledList<LoggedMessage> item2 = tuple.Item2;
		long num = ((item.Count == 0) ? 0L : item.Min([SpecialName] (LoggedMessage theM) => theM.Increment));
		long num2 = ((item2.Count == 0) ? 0L : item2.Min([SpecialName] (LoggedMessage theM) => theM.Increment));
		List<MLDetailViewModel> list = new List<MLDetailViewModel>();
		foreach (GClass4 item3 in SummaryItemsOriginal)
		{
			list.Clear();
			foreach (MLDetailViewModel detail in item3.Details)
			{
				if (!detail.IsSideMessage)
				{
					if (detail.Increment < num)
					{
						list.Add(detail);
					}
				}
				else if (detail.Increment < num2)
				{
					list.Add(detail);
				}
			}
			if (list.Count > 0)
			{
				MustRefresh = true;
				item3.Details.RemoveItems(list);
			}
		}
		LoggedMessage[] array;
		LoggedMessage[] array2;
		if (Client.CurrentMapProfile.IsolatedPOVObjectID == null)
		{
			array = item.Where([SpecialName] (LoggedMessage theM) => theM.Increment > HighestIncrement).ToArray();
			array2 = item2.Where([SpecialName] (LoggedMessage theM) => theM.Increment > HighestIncrement).ToArray();
		}
		else
		{
			array = item.Where([SpecialName] (LoggedMessage theM) => (theM.Increment > HighestIncrement) & (Operators.CompareString(theM.ReporterID, Client.CurrentMapProfile.IsolatedPOVObjectID, true) == 0)).ToArray();
			array2 = item2.Where([SpecialName] (LoggedMessage theM) => (theM.Increment > HighestIncrement) & (Operators.CompareString(theM.ReporterID, Client.CurrentMapProfile.IsolatedPOVObjectID, true) == 0)).ToArray();
		}
		if (array.Length > 0 || array2.Length > 0)
		{
			MustRefresh = true;
			HighestIncrement = Math.Max((array.Length != 0) ? array.Max([SpecialName] (LoggedMessage theM) => theM.Increment) : 0L, (array2.Length != 0) ? array2.Max([SpecialName] (LoggedMessage theM) => theM.Increment) : 0L);
			method_0(array);
			method_0(array2);
		}
		if (MustRefresh)
		{
			RefreshLoggedMessages();
		}
		item.Dispose();
		item2.Dispose();
	}

	public void RefreshLoggedMessages()
	{
		MustRefresh = false;
		Misc.SyncLists(SummaryItemsOriginal, SummaryItems);
		PooledList<MLDetailViewModel> pooledList = new PooledList<MLDetailViewModel>();
		foreach (GClass4 summaryItem in SummaryItems)
		{
			if (!HeaderToShow.ContainsKey(summaryItem.Summary) || !HeaderToShow[summaryItem.Summary])
			{
				continue;
			}
			foreach (MLDetailViewModel detail in summaryItem.Details)
			{
				pooledList.Add(detail);
			}
		}
		hashSet_0.Clear();
		foreach (MLDetailViewModel filteredSummaryDetailItem in FilteredSummaryDetailItems)
		{
			hashSet_0.Add(filteredSummaryDetailItem.LoggedMessage.Increment);
		}
		hashSet_1.Clear();
		foreach (MLDetailViewModel item in pooledList)
		{
			hashSet_1.Add(item.LoggedMessage.Increment);
		}
		PooledList<MLDetailViewModel> pooledList2 = new PooledList<MLDetailViewModel>(FilteredSummaryDetailItems);
		foreach (MLDetailViewModel item2 in pooledList2)
		{
			if (!hashSet_1.Contains(item2.LoggedMessage.Increment))
			{
				_ItemsRemovalQueue.Enqueue(item2);
			}
		}
		foreach (MLDetailViewModel item3 in pooledList)
		{
			if (!hashSet_0.Contains(item3.LoggedMessage.Increment))
			{
				FilteredSummaryDetailItems.Add(item3);
			}
		}
		pooledList.Dispose();
		pooledList2.Dispose();
		Misc.Sort(FilteredSummaryDetailItems, [SpecialName] (MLDetailViewModel theVM) => theVM.LoggedMessage.Increment, SortByDescending: true);
	}

	private void dispatcherTimer_0_Tick(object sender, EventArgs e)
	{
		GClass5[] array = Balloons.ToArray();
		foreach (GClass5 gClass in array)
		{
			if (!gClass.Hover)
			{
				gClass.Opacity -= (DateTime.Now - dateTime_0).TotalSeconds;
			}
			if (gClass.Opacity < 0.0)
			{
				Balloons.Remove(gClass);
			}
		}
		foreach (GClass4 summaryItem in SummaryItems)
		{
			if (summaryItem.Expanded || HeaderToShow[summaryItem.Summary])
			{
				foreach (MLDetailViewModel detail in summaryItem.Details)
				{
					detail.Read = true;
				}
				summaryItem.Header = summaryItem.Summary;
				continue;
			}
			int num = 0;
			foreach (MLDetailViewModel detail2 in summaryItem.Details)
			{
				if (!detail2.Read && !HeaderToShow[summaryItem.Summary])
				{
					num++;
				}
			}
			summaryItem.Header = summaryItem.Summary;
			summaryItem.Header = summaryItem.Summary + $" ({num})";
		}
		dateTime_0 = DateTime.Now;
	}

	public MessageLogControlViewModel()
	{
		list_0 = new List<GClass4>();
		observableCollection_0 = new ObservableCollection<GClass4>();
		vfuHbreLkkD = new ObservableCollection<MLDetailViewModel>();
		observableCollection_1 = new ObservableCollection<GClass4>();
		observableCollection_2 = new ObservableCollection<GClass5>();
		bool_0 = false;
		double_0 = 0.0;
		int_0 = 400;
		HighestIncrement = 0L;
		dispatcherTimer_0 = null;
		int_1 = -1;
		HeaderToShow = new Dictionary<string, bool>();
		ShowAll = true;
		InteractiveMode = true;
		MustRefresh = false;
		_ItemsRemovalQueue = new Queue<MLDetailViewModel>();
		hashSet_0 = new HashSet<long>();
		hashSet_1 = new HashSet<long>();
		dateTime_0 = DateTime.Now;
		fastDictionary_0 = new FastDictionary<int, SolidColorBrush>();
		lockRandom_0 = new LockRandom();
	}

	public static string MessageTypeToBalloonText(LoggedMessage.MessageType theMessageType)
	{
		return theMessageType switch
		{
			LoggedMessage.MessageType.NewContact => "New Contact", 
			LoggedMessage.MessageType.ContactChange => "Contact Change", 
			LoggedMessage.MessageType.WeaponEndgame => "Weapon Endgame", 
			LoggedMessage.MessageType.WeaponDamage => "Weapon Damage", 
			LoggedMessage.MessageType.AirOps => "Air Ops", 
			LoggedMessage.MessageType.UnitLost => "UNIT LOST", 
			LoggedMessage.MessageType.UnitDamage => "Damage", 
			LoggedMessage.MessageType.PointDefence => "Point Defence", 
			LoggedMessage.MessageType.WeaponLogic => "Weapon Logic", 
			LoggedMessage.MessageType.UnitAI => "Crew AI", 
			LoggedMessage.MessageType.EventEngine => "Event", 
			LoggedMessage.MessageType.NewWeaponContact => "New Weapon Contact", 
			LoggedMessage.MessageType.DockingOps => "Docking Ops", 
			LoggedMessage.MessageType.NewMineContact => "New Mine Contact", 
			LoggedMessage.MessageType.CommsIsolatedMessage => "Isolated-POV message", 
			LoggedMessage.MessageType.NewAirContact => "New Air Contact", 
			LoggedMessage.MessageType.NewSurfaceContact => "New Surface Contact", 
			LoggedMessage.MessageType.NewUnderwaterContact => "New Underwater Contact", 
			LoggedMessage.MessageType.NewGroundContact => "New Ground Contact", 
			LoggedMessage.MessageType.UnguidedWeaponModifiers => "Unguided Weapon", 
			LoggedMessage.MessageType.const_23 => "Doctrine/ROE Change", 
			LoggedMessage.MessageType.Debug => "Debug", 
			LoggedMessage.MessageType.UnitAIEmergency => "Crew AI Emergency", 
			LoggedMessage.MessageType.CommsRelatedMessage => "Comms-related message", 
			_ => "Event", 
		};
	}

	private void method_0(LoggedMessage[] loggedMessage_0)
	{
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Expected O, but got Unknown
		try
		{
			_Closure$__60-0 closure$__60- = default(_Closure$__60-0);
			for (int i = 0; i < loggedMessage_0.Length; i = checked(i + 1))
			{
				closure$__60- = new _Closure$__60-0(closure$__60-);
				closure$__60-.$VB$Local_theM = loggedMessage_0[i];
				if (string.IsNullOrEmpty(closure$__60-.$VB$Local_theM.Summary))
				{
					closure$__60-.$VB$Local_theM.Summary = "Log element lacking summary!";
				}
				GClass4 gClass = SummaryItemsOriginal.FirstOrDefault(closure$__60-._Lambda$__0);
				Color messageColor = closure$__60-.$VB$Local_theM.MessageColor;
				MLDetailViewModel mLDetailViewModel = new MLDetailViewModel();
				MLDetailViewModel mLDetailViewModel2 = mLDetailViewModel;
				mLDetailViewModel2.Increment = closure$__60-.$VB$Local_theM.Increment;
				mLDetailViewModel2.IsSideMessage = closure$__60-.$VB$Local_theM.Side != null;
				mLDetailViewModel2.LongText = StripHTML.StripTagsRegexCompiled(closure$__60-.$VB$Local_theM.Text);
				mLDetailViewModel2.Summary = StripHTML.StripTagsRegexCompiled(closure$__60-.$VB$Local_theM.Summary);
				mLDetailViewModel2.Text = StripHTML.StripTagsRegexCompiled(closure$__60-.$VB$Local_theM.Summary);
				mLDetailViewModel2.PlusVisibility = (Visibility)0;
				mLDetailViewModel2.Expanded = false;
				mLDetailViewModel2.Timestamp = closure$__60-.$VB$Local_theM.Timestamp;
				if (closure$__60-.$VB$Local_theM.Location.HasValue)
				{
					mLDetailViewModel2.Lat = closure$__60-.$VB$Local_theM.Location.Value.Latitude;
					mLDetailViewModel2.Lon = closure$__60-.$VB$Local_theM.Location.Value.Longitude;
				}
				mLDetailViewModel2.LoggedMessage = closure$__60-.$VB$Local_theM;
				int key = messageColor.ToArgb();
				if (!fastDictionary_0.TryGetValue(key, out var value))
				{
					value = new SolidColorBrush(Color.FromArgb(messageColor.A, messageColor.R, messageColor.G, messageColor.B));
					fastDictionary_0[key] = value;
				}
				mLDetailViewModel2.Brush = (Brush)(object)value;
				mLDetailViewModel2.Read = false;
				mLDetailViewModel2 = null;
				if (gClass == null)
				{
					gClass = new GClass4
					{
						Header = MessageTypeToBalloonText(closure$__60-.$VB$Local_theM.Type),
						Summary = MessageTypeToBalloonText(closure$__60-.$VB$Local_theM.Type)
					};
					SummaryItemsOriginal.Add(gClass);
					SummaryItemsOriginal.Sort(new TimestampComparer_DescendingOrder());
				}
				gClass.Details.Add(mLDetailViewModel);
				gClass.Timestamp = mLDetailViewModel.Timestamp;
				if (!string.IsNullOrEmpty(closure$__60-.$VB$Local_theM.Summary) && SimConfiguration.DefaultGamePreferences.MessageLogSettings[closure$__60-.$VB$Local_theM.Type].ShowBaloon)
				{
					GenerateBalloon(mLDetailViewModel);
				}
			}
			foreach (GClass4 item in SummaryItemsOriginal)
			{
				List<MLDetailViewModel> list = new List<MLDetailViewModel>(item.Details);
				list.Sort(new DetailTimestampComparer_DescendingOrder());
				item.Details = new FastObservableCollection<MLDetailViewModel>();
				item.Details.AddItems(list);
				item.MessageLogVM = this;
				if (!HeaderToShow.ContainsKey(item.Summary))
				{
					HeaderToShow.Add(item.Summary, value: true);
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
	}

	private void method_1(LoggedMessage loggedMessage_0)
	{
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_016e: Expected O, but got Unknown
		try
		{
			if (string.IsNullOrEmpty(loggedMessage_0.Summary))
			{
				loggedMessage_0.Summary = "Log element lacking summary!";
			}
			GClass4 gClass = SummaryItemsOriginal.FirstOrDefault([SpecialName] (GClass4 MLSVM) => Operators.CompareString(MLSVM.Summary, MessageTypeToBalloonText(loggedMessage_0.Type), true) == 0);
			Color messageColor = loggedMessage_0.MessageColor;
			MLDetailViewModel mLDetailViewModel = new MLDetailViewModel();
			MLDetailViewModel mLDetailViewModel2 = mLDetailViewModel;
			mLDetailViewModel2.Increment = loggedMessage_0.Increment;
			mLDetailViewModel2.IsSideMessage = loggedMessage_0.Side != null;
			mLDetailViewModel2.LongText = StripHTML.StripTagsRegexCompiled(loggedMessage_0.Text);
			mLDetailViewModel2.Summary = StripHTML.StripTagsRegexCompiled(loggedMessage_0.Summary);
			mLDetailViewModel2.Text = StripHTML.StripTagsRegexCompiled(loggedMessage_0.Summary);
			mLDetailViewModel2.PlusVisibility = (Visibility)0;
			mLDetailViewModel2.Expanded = false;
			mLDetailViewModel2.Timestamp = loggedMessage_0.Timestamp;
			if (loggedMessage_0.Location.HasValue)
			{
				mLDetailViewModel2.Lat = loggedMessage_0.Location.Value.Latitude;
				mLDetailViewModel2.Lon = loggedMessage_0.Location.Value.Longitude;
			}
			mLDetailViewModel2.LoggedMessage = loggedMessage_0;
			mLDetailViewModel2.Brush = (Brush)new SolidColorBrush(Color.FromArgb(messageColor.A, messageColor.R, messageColor.G, messageColor.B));
			mLDetailViewModel2.Read = false;
			mLDetailViewModel2 = null;
			if (gClass == null)
			{
				gClass = new GClass4
				{
					Header = MessageTypeToBalloonText(loggedMessage_0.Type),
					Summary = MessageTypeToBalloonText(loggedMessage_0.Type)
				};
				SummaryItemsOriginal.Add(gClass);
			}
			SummaryItemsOriginal.Sort(new TimestampComparer_DescendingOrder());
			gClass.Details.Add(mLDetailViewModel);
			List<MLDetailViewModel> list = new List<MLDetailViewModel>(gClass.Details);
			list.Sort(new DetailTimestampComparer_DescendingOrder());
			gClass.Details = new FastObservableCollection<MLDetailViewModel>();
			gClass.Details.AddItems(list);
			gClass.Timestamp = mLDetailViewModel.Timestamp;
			gClass.MessageLogVM = this;
			if (!string.IsNullOrEmpty(loggedMessage_0.Summary) && SimConfiguration.DefaultGamePreferences.MessageLogSettings[loggedMessage_0.Type].ShowBaloon)
			{
				GenerateBalloon(mLDetailViewModel);
			}
			if (!HeaderToShow.ContainsKey(gClass.Summary))
			{
				HeaderToShow.Add(gClass.Summary, value: true);
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

	public GClass5 GenerateBalloon(MLDetailViewModel theDetails)
	{
		if (Balloons.Any([SpecialName] (GClass5 F) => ((MLDetailViewModel)F.Tag).LoggedMessage == theDetails.LoggedMessage))
		{
			return null;
		}
		Color messageColor = theDetails.LoggedMessage.MessageColor;
		GClass5 gClass = new GClass5();
		gClass.Text = MessageTypeToBalloonText(theDetails.LoggedMessage.Type);
		gClass.Lon = theDetails.Lon;
		WWC.WWC_WorldToScreen(MyProject.Forms.MainForm.WorldWindow1, theDetails.Lat, theDetails.Lon);
		gClass.Lat = theDetails.Lat;
		gClass.Tag = theDetails;
		gClass.Opacity = 5.0;
		gClass.Summary = StripHTML.StripTagsRegexCompiled(theDetails.Summary);
		gClass.Color = messageColor;
		gClass.Radius = 100.0 + lockRandom_0.NextDouble() * 50.0;
		gClass.Theta = lockRandom_0.NextDouble() * Math.PI * 2.0;
		Balloons.Add(gClass);
		Dispatcher.CurrentDispatcher.Invoke((Action)([SpecialName] () =>
		{
			Balloon balloon = new Balloon();
			balloon.CanvasLeft = (int)Math.Round(gClass.CanvasLeft);
			balloon.CanvasTop = (int)Math.Round(gClass.CanvasTop);
			balloon.StemCanvasLeft = (int)Math.Round(gClass.StemCanvasLeft);
			balloon.StemCanvasTop = (int)Math.Round(gClass.StemCanvasTop);
			balloon.ObservedHeight = (int)Math.Round(gClass.ObservedHeight);
			balloon.ObservedWidth = (int)Math.Round(gClass.ObservedWidth);
			balloon.Text = gClass.Text;
			balloon.Summary = gClass.Summary;
			balloon.Tag = RuntimeHelpers.GetObjectValue(gClass.Tag);
			balloon.Lat = gClass.Lat;
			balloon.Lon = gClass.Lon;
			balloon.Opacity = gClass.Opacity;
			balloon.Hover = gClass.Hover;
			balloon.Color = gClass.Color;
			balloon.X1 = gClass.X1;
			balloon.X2 = gClass.X2;
			balloon.Y1 = gClass.Y1;
			balloon.Y2 = gClass.Y2;
			balloon.Radius = gClass.Radius;
			balloon.Theta = gClass.Theta;
			MyProject.Forms.MainForm.BalloonsRenderingList.Add(balloon);
			MyProject.Forms.MainForm.SetRenderCountdown(5.0);
		}));
		return gClass;
	}

	internal void HandleCurrentSideChanged()
	{
		ClearLog();
		HighestIncrement = 0L;
		RefreshLog();
	}

	internal void HandleCurrentScenarioChanged()
	{
		ResetLog();
	}

	static MessageLogControlViewModel()
	{
		Class72.smethod_20();
	}
}
