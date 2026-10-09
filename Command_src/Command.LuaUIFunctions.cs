using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using Command_Core;
using Command_Core.Lua;
using Command.My;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using NLua;

namespace Command;

[StandardModule]
internal sealed class LuaUIFunctions
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct VB$StateMachine_14_UI_CallAdvancedHTMLDialog : IAsyncStateMachine
	{
		public int $State;

		public AsyncTaskMethodBuilder<object> $Builder;

		internal string $VB$Local_Title;

		internal string $VB$Local_Html;

		internal LuaTable $VB$Local_Interactions;

		internal TaskAwaiter<Dictionary<string, string>> $A0;

		[CompilerGenerated]
		internal void MoveNext()
		{
			int num = $State;
			object obj;
			try
			{
				TaskAwaiter<Dictionary<string, string>> awaiter;
				if (num == 0)
				{
					num = -1;
					$State = -1;
					awaiter = $A0;
					$A0 = default(TaskAwaiter<Dictionary<string, string>>);
				}
				else
				{
					_Closure$__14-0 arg = default(_Closure$__14-0);
					_Closure$__14-0 CS$<>8__locals5 = new _Closure$__14-0(arg)
					{
						$VB$Local_Title = $VB$Local_Title,
						$VB$Local_Html = $VB$Local_Html,
						$VB$Local_TheList = new List<string>()
					};
					if ($VB$Local_Interactions.Values.Count > 0)
					{
						int num2 = $VB$Local_Interactions.Values.Count - 1;
						for (int i = 0; i <= num2; i++)
						{
							CS$<>8__locals5.$VB$Local_TheList.Add($VB$Local_Interactions.Values.Cast<object>().ElementAtOrDefault(i).ToString());
						}
					}
					Form val = smethod_1();
					if (val != null)
					{
						((Control)val).Invoke((Delegate)(VB$AnonymousDelegate_0)([SpecialName] [AsyncStateMachine(typeof(_Closure$__14-0.VB$StateMachine___Lambda$__0))] () =>
						{
							_Closure$__14-0.VB$StateMachine___Lambda$__0 stateMachine = default(_Closure$__14-0.VB$StateMachine___Lambda$__0);
							stateMachine.$VB$NonLocal__Closure$__14-0 = CS$<>8__locals5;
							stateMachine.$State = -1;
							stateMachine.$Builder = AsyncVoidMethodBuilder.Create();
							stateMachine.$Builder.Start(ref stateMachine);
						}));
						goto IL_0134;
					}
					awaiter = AdvancedDialog.CallHTMLDialog(CS$<>8__locals5.$VB$Local_Title, CS$<>8__locals5.$VB$Local_Html, CS$<>8__locals5.$VB$Local_TheList.ToArray()).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = 0;
						$State = 0;
						$A0 = awaiter;
						$Builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
						return;
					}
				}
				Dictionary<string, string> result = awaiter.GetResult();
				awaiter = default(TaskAwaiter<Dictionary<string, string>>);
				PrivateMethods.ReturnTable = result;
				goto IL_0134;
				IL_0134:
				obj = null;
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
			$Builder.SetResult(RuntimeHelpers.GetObjectValue(obj));
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

		static VB$StateMachine_14_UI_CallAdvancedHTMLDialog()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__14-0
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct VB$StateMachine___Lambda$__0 : IAsyncStateMachine
		{
			public int $State;

			public AsyncVoidMethodBuilder $Builder;

			internal _Closure$__14-0 $VB$NonLocal__Closure$__14-0;

			internal TaskAwaiter<Dictionary<string, string>> $A0;

			[CompilerGenerated]
			internal void MoveNext()
			{
				int num = $State;
				try
				{
					TaskAwaiter<Dictionary<string, string>> awaiter;
					if (num == 0)
					{
						num = -1;
						$State = -1;
						awaiter = $A0;
						$A0 = default(TaskAwaiter<Dictionary<string, string>>);
					}
					else
					{
						awaiter = AdvancedDialog.CallHTMLDialog($VB$NonLocal__Closure$__14-0.$VB$Local_Title, $VB$NonLocal__Closure$__14-0.$VB$Local_Html, $VB$NonLocal__Closure$__14-0.$VB$Local_TheList.ToArray()).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = 0;
							$State = 0;
							$A0 = awaiter;
							$Builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
							return;
						}
					}
					Dictionary<string, string> result = awaiter.GetResult();
					awaiter = default(TaskAwaiter<Dictionary<string, string>>);
					PrivateMethods.ReturnTable = result;
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

			static VB$StateMachine___Lambda$__0()
			{
				Class72.smethod_20();
			}
		}

		public string $VB$Local_Title;

		public string $VB$Local_Html;

		public List<string> $VB$Local_TheList;

		public _Closure$__14-0(_Closure$__14-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_Title = arg0.$VB$Local_Title;
				$VB$Local_Html = arg0.$VB$Local_Html;
				$VB$Local_TheList = arg0.$VB$Local_TheList;
			}
		}

		[SpecialName]
		[AsyncStateMachine(typeof(VB$StateMachine___Lambda$__0))]
		internal void _Lambda$__0()
		{
			VB$StateMachine___Lambda$__0 stateMachine = default(VB$StateMachine___Lambda$__0);
			stateMachine.$VB$NonLocal__Closure$__14-0 = this;
			stateMachine.$State = -1;
			stateMachine.$Builder = AsyncVoidMethodBuilder.Create();
			stateMachine.$Builder.Start(ref stateMachine);
		}

		static _Closure$__14-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__17-0
	{
		public string $VB$Local_result;

		public string $VB$Local_Title;

		public string $VB$Local_Description;

		public List<string> $VB$Local_TheList;

		public _Closure$__17-0(_Closure$__17-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_result = arg0.$VB$Local_result;
				$VB$Local_Title = arg0.$VB$Local_Title;
				$VB$Local_Description = arg0.$VB$Local_Description;
				$VB$Local_TheList = arg0.$VB$Local_TheList;
			}
		}

		[SpecialName]
		internal void _Lambda$__0()
		{
			$VB$Local_result = AdvancedDialog.CallDialog($VB$Local_Title, $VB$Local_Description, $VB$Local_TheList.ToArray());
		}

		static _Closure$__17-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__18-0
	{
		public bool $VB$Local_MultipleSelect;

		public List<ActiveUnit> $VB$Local_TheResult;

		public UnitSelection.UnitSelectionConfig $VB$Local_TheConfig;

		public _Closure$__18-0(_Closure$__18-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_MultipleSelect = arg0.$VB$Local_MultipleSelect;
				$VB$Local_TheResult = arg0.$VB$Local_TheResult;
				$VB$Local_TheConfig = arg0.$VB$Local_TheConfig;
			}
		}

		[SpecialName]
		internal void _Lambda$__0()
		{
			Side currentSide = Client.CurrentSide;
			bool multipleSelection = $VB$Local_MultipleSelect;
			ref List<ActiveUnit> selectedUnits = ref $VB$Local_TheResult;
			List<ReferencePoint> list_ = null;
			List<Zone> SelectedStandardZones = null;
			UnitSelection.CallDialog(currentSide, multipleSelection, ref selectedUnits, ref list_, ref SelectedStandardZones, $VB$Local_TheConfig);
		}

		static _Closure$__18-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__19-0
	{
		public List<Side> $VB$Local_AllSides;

		public bool $VB$Local_MultipleSelect;

		public List<ActiveUnit> $VB$Local_TheResult;

		public _Closure$__19-0(_Closure$__19-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_AllSides = arg0.$VB$Local_AllSides;
				$VB$Local_MultipleSelect = arg0.$VB$Local_MultipleSelect;
				$VB$Local_TheResult = arg0.$VB$Local_TheResult;
			}
		}

		[SpecialName]
		internal void _Lambda$__0()
		{
			List<Side> side = $VB$Local_AllSides;
			bool multipleSelection = $VB$Local_MultipleSelect;
			ref List<ActiveUnit> selectedUnits = ref $VB$Local_TheResult;
			List<ReferencePoint> list_ = null;
			List<Zone> SelectedStandardZones = null;
			UnitSelection.CallDialog(side, multipleSelection, ref selectedUnits, ref list_, ref SelectedStandardZones);
		}

		static _Closure$__19-0()
		{
			Class72.smethod_20();
		}
	}

	private static ConcurrentQueue<Tuple<string, bool, int>> concurrentQueue_0;

	[AccessedThroughProperty("TheTimer")]
	[CompilerGenerated]
	private static Timer timer_0;

	static LuaUIFunctions()
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Expected O, but got Unknown
		Class72.smethod_20();
		concurrentQueue_0 = new ConcurrentQueue<Tuple<string, bool, int>>();
		smethod_0(new Timer());
	}

	[SpecialName]
	[CompilerGenerated]
	private static void smethod_0(Timer timer_1)
	{
		EventHandler eventHandler = smethod_5;
		Timer val = timer_0;
		if (val != null)
		{
			val.Tick -= eventHandler;
		}
		timer_0 = timer_1;
		val = timer_0;
		if (val != null)
		{
			val.Tick += eventHandler;
		}
	}

	public static void RegisterLuaUIHandlers()
	{
		PrivateMethods.LuaMessageBox += smethod_2;
		PrivateMethods.LuaLocalVideo += smethod_4;
		PrivateMethods.LuaInputBox += smethod_3;
		PrivateMethods.LuaGame += smethod_6;
		PrivateMethods.LuaSelectUnitsPrompt_OwnSide += [SpecialName] (ref LuaTable a0, bool a1) =>
		{
			UI_SelectUnitsPrompt_OwnSide(ref a0, a1);
		};
		PrivateMethods.LuaSelectUnitsPrompt_FromSides += [SpecialName] (ref LuaTable a0, LuaTable a1, bool a2) =>
		{
			UI_SelectUnitsPrompt_FromSides(ref a0, a1, a2);
		};
		PrivateMethods.LuaCallAdvancedDialog += [SpecialName] (string a0, string a1, LuaTable a2, ref string a3) =>
		{
			UI_CallAdvancedDialog(a0, a1, a2, ref a3);
		};
		PrivateMethods.LuaOpenNewDatabaseWindow += UI_OpenNewDatabaseWindow;
		PrivateMethods.LuaUI_ShowWindow += UI_ShowWindow;
		PrivateMethods.LuaCallSetCameraView += UI_SetCameraView;
		PrivateMethods.LuaCallSelectThisUnit += UI_SelectThisUnit;
		PrivateMethods.LuaCallAdvancedHTMLDialog += [SpecialName] (string a0, string a1, LuaTable a2) =>
		{
			UI_CallAdvancedHTMLDialog(a0, a1, a2);
		};
		PrivateMethods.LuaNewBlankScenario += [SpecialName] (string a0) =>
		{
			smethod_7(a0);
		};
		PrivateMethods.LuaResetMessageLog += [SpecialName] (Scenario a0, bool a1) =>
		{
			smethod_8(a0, a1);
		};
		timer_0.Interval = 100;
		timer_0.Start();
	}

	private static Form smethod_1()
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected O, but got Unknown
		Form result = null;
		if (MyProject.Forms.m_MainForm == null)
		{
			foreach (Form item in (ReadOnlyCollectionBase)(object)Application.OpenForms)
			{
				Form val = item;
				if (val != null && val is MainForm)
				{
					result = val;
					break;
				}
			}
		}
		else
		{
			result = (Form)(object)MyProject.Forms.MainForm;
		}
		return result;
	}

	private static void smethod_2(string string_0, int int_0, bool bool_0, ref string string_1)
	{
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		if (bool_0)
		{
			return;
		}
		bool flag;
		if (flag = Client.CurrentGame.Status == Game._GameStatus.Running)
		{
			Client.CurrentGame.Pause();
		}
		DarkDialogButton buttons;
		switch (int_0)
		{
		default:
			buttons = DarkDialogButton.Ok;
			break;
		case 1:
			buttons = DarkDialogButton.OkCancel;
			break;
		case 2:
			buttons = DarkDialogButton.AbortRetryIgnore;
			break;
		case 3:
			buttons = DarkDialogButton.YesNoCancel;
			break;
		case 4:
			buttons = DarkDialogButton.YesNo;
			break;
		case 5:
			buttons = DarkDialogButton.RetryCancel;
			break;
		}
		DialogResult val = (DialogResult)2;
		Form val2 = smethod_1();
		if (val2 != null)
		{
			((Control)val2).Invoke((Delegate)(VB$AnonymousDelegate_0)([SpecialName] () =>
			{
				//IL_0012: Unknown result type (might be due to invalid IL or missing references)
				//IL_0017: Unknown result type (might be due to invalid IL or missing references)
				val = DarkMessageBox.ShowInformation(string_0, "Incoming message", buttons);
			}));
		}
		else
		{
			val = DarkMessageBox.ShowInformation(string_0, "Incoming message", buttons);
		}
		string_1 = ((Enum)Unsafe.As<DialogResult, DialogResult>(ref val)/*cast due to .constrained prefix*/).ToString();
		if (flag)
		{
			Client.CurrentGame.Run();
		}
	}

	private static void smethod_3(string string_0, bool bool_0, ref string string_1)
	{
		if (bool_0)
		{
			return;
		}
		bool num = Client.CurrentGame.Status == Game._GameStatus.Running;
		if (num)
		{
			Client.CurrentGame.Pause();
		}
		string text = "";
		Form val = smethod_1();
		if (val == null)
		{
			text = Interaction.InputBox(string_0, "", "", -1, -1).ToString();
		}
		else
		{
			((Control)val).Invoke((Delegate)(VB$AnonymousDelegate_0)([SpecialName] () =>
			{
				text = Interaction.InputBox(string_0, "", "", -1, -1).ToString();
			}));
		}
		string_1 = text;
		if (num)
		{
			Client.CurrentGame.Run();
		}
	}

	private static void smethod_4(object object_0, bool bool_0, bool bool_1, int int_0)
	{
		if (!bool_0)
		{
			concurrentQueue_0.Enqueue(new Tuple<string, bool, int>((string)object_0, bool_1, int_0));
		}
	}

	private static void smethod_5(object object_0, object object_1)
	{
	}

	public static void UI_SetCameraView(double latitude, double longitude, int zoom)
	{
		MainForm obj = (MainForm)(object)smethod_1();
		int? altitude = null;
		if (zoom != -99999)
		{
			altitude = zoom;
		}
		obj.SetCameraView(latitude, longitude, altitude);
	}

	public static void UI_SelectThisUnit(string string_0, bool ThisUnitOnly, bool clearWaypointSelection = true)
	{
		ActiveUnit activeUnitByNameOrID = Misc.GetActiveUnitByNameOrID(string_0, Client.CurrentScenario);
		Form val = smethod_1();
		if (val != null)
		{
			((Control)val).Invoke((Delegate)(VB$AnonymousDelegate_0)([SpecialName] () =>
			{
				Client.SelectThisUnit(activeUnitByNameOrID, ThisUnitOnly, clearWaypointSelection);
			}));
		}
		else
		{
			Client.SelectThisUnit(activeUnitByNameOrID, ThisUnitOnly, clearWaypointSelection);
		}
	}

	[AsyncStateMachine(typeof(VB$StateMachine_14_UI_CallAdvancedHTMLDialog))]
	public static Task<object> UI_CallAdvancedHTMLDialog(string Title, string Html, LuaTable Interactions)
	{
		VB$StateMachine_14_UI_CallAdvancedHTMLDialog stateMachine = default(VB$StateMachine_14_UI_CallAdvancedHTMLDialog);
		stateMachine.$VB$Local_Title = Title;
		stateMachine.$VB$Local_Html = Html;
		stateMachine.$VB$Local_Interactions = Interactions;
		stateMachine.$State = -1;
		stateMachine.$Builder = AsyncTaskMethodBuilder<object>.Create();
		stateMachine.$Builder.Start(ref stateMachine);
		return stateMachine.$Builder.Task;
	}

	public static void UI_OpenNewDatabaseWindow(string SelectedObjectType, int selectedObjectID)
	{
		Form val = smethod_1();
		if (val == null)
		{
			DBViewer.OpenNewDatabaseWindow(SelectedObjectType, selectedObjectID);
			return;
		}
		((Control)val).Invoke((Delegate)(VB$AnonymousDelegate_0)([SpecialName] () =>
		{
			DBViewer.OpenNewDatabaseWindow(SelectedObjectType, selectedObjectID);
		}));
	}

	public static void UI_ShowWindow(string Window, LuaTable Args)
	{
		try
		{
			string[] argsArray = (from object o in Args.Values
				select o.ToString()).ToArray();
			Form val = smethod_1();
			if (val != null)
			{
				((Control)val).Invoke((Delegate)(VB$AnonymousDelegate_0)([SpecialName] () =>
				{
					string text2 = Window.ToLowerInvariant();
					if (Operators.CompareString(text2, "database", true) == 0)
					{
						MyProject.Forms.InternalDBViewer.Show(argsArray);
					}
					else if (Operators.CompareString(text2, "doctrine", true) == 0)
					{
						MyProject.Forms.DoctrineForm.Show(argsArray);
					}
					else if (Operators.CompareString(text2, "mission", true) == 0)
					{
						MyProject.Forms.MissionEditor.Show(argsArray);
					}
					else if (Operators.CompareString(text2, "readyaircraft", true) == 0)
					{
						MyProject.Forms.ReadyAircraft.Show(argsArray);
					}
				}));
				return;
			}
			string text = Window.ToLowerInvariant();
			if (Operators.CompareString(text, "database", true) == 0)
			{
				MyProject.Forms.InternalDBViewer.Show(argsArray);
			}
			else if (Operators.CompareString(text, "doctrine", true) != 0)
			{
				if (Operators.CompareString(text, "mission", true) != 0)
				{
					if (Operators.CompareString(text, "readyaircraft", true) == 0)
					{
						MyProject.Forms.ReadyAircraft.Show(argsArray);
					}
				}
				else
				{
					MyProject.Forms.MissionEditor.Show(argsArray);
				}
			}
			else
			{
				MyProject.Forms.DoctrineForm.Show(argsArray);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at UI_ShowWindow call when calling window " + Window, "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static string UI_CallAdvancedDialog(string Title, string Description, LuaTable Interactions, ref string returnvalue)
	{
		_Closure$__17-0 arg = default(_Closure$__17-0);
		_Closure$__17-0 CS$<>8__locals14 = new _Closure$__17-0(arg);
		CS$<>8__locals14.$VB$Local_Title = Title;
		CS$<>8__locals14.$VB$Local_Description = Description;
		CS$<>8__locals14.$VB$Local_TheList = new List<string>();
		if (Interactions.Values.Count > 0)
		{
			int num = Interactions.Values.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				CS$<>8__locals14.$VB$Local_TheList.Add(Interactions.Values.Cast<object>().ElementAtOrDefault(i).ToString());
			}
		}
		CS$<>8__locals14.$VB$Local_result = null;
		Form val = smethod_1();
		if (val == null)
		{
			CS$<>8__locals14.$VB$Local_result = AdvancedDialog.CallDialog(CS$<>8__locals14.$VB$Local_Title, CS$<>8__locals14.$VB$Local_Description, CS$<>8__locals14.$VB$Local_TheList.ToArray());
		}
		else
		{
			((Control)val).Invoke((Delegate)(VB$AnonymousDelegate_0)([SpecialName] () =>
			{
				CS$<>8__locals14.$VB$Local_result = AdvancedDialog.CallDialog(CS$<>8__locals14.$VB$Local_Title, CS$<>8__locals14.$VB$Local_Description, CS$<>8__locals14.$VB$Local_TheList.ToArray());
			}));
		}
		returnvalue = CS$<>8__locals14.$VB$Local_result;
		return returnvalue;
	}

	public static LuaTable UI_SelectUnitsPrompt_OwnSide(ref LuaTable result, bool MultipleSelect)
	{
		_Closure$__18-0 arg = default(_Closure$__18-0);
		_Closure$__18-0 CS$<>8__locals12 = new _Closure$__18-0(arg);
		CS$<>8__locals12.$VB$Local_MultipleSelect = MultipleSelect;
		CS$<>8__locals12.$VB$Local_TheConfig = null;
		CS$<>8__locals12.$VB$Local_TheResult = new List<ActiveUnit>();
		Form val = smethod_1();
		if (val != null)
		{
			((Control)val).Invoke((Delegate)(VB$AnonymousDelegate_0)([SpecialName] () =>
			{
				Side currentSide2 = Client.CurrentSide;
				bool multipleSelection2 = CS$<>8__locals12.$VB$Local_MultipleSelect;
				ref List<ActiveUnit> selectedUnits2 = ref CS$<>8__locals12.$VB$Local_TheResult;
				List<ReferencePoint> list_2 = null;
				List<Zone> SelectedStandardZones2 = null;
				UnitSelection.CallDialog(currentSide2, multipleSelection2, ref selectedUnits2, ref list_2, ref SelectedStandardZones2, CS$<>8__locals12.$VB$Local_TheConfig);
			}));
		}
		else
		{
			Side currentSide = Client.CurrentSide;
			bool multipleSelection = CS$<>8__locals12.$VB$Local_MultipleSelect;
			ref List<ActiveUnit> selectedUnits = ref CS$<>8__locals12.$VB$Local_TheResult;
			List<ReferencePoint> list_ = null;
			List<Zone> SelectedStandardZones = null;
			UnitSelection.CallDialog(currentSide, multipleSelection, ref selectedUnits, ref list_, ref SelectedStandardZones, CS$<>8__locals12.$VB$Local_TheConfig);
		}
		result = LuaSandBox.Singleton().CreateTable();
		if (CS$<>8__locals12.$VB$Local_TheResult.Count > 0)
		{
			int num = CS$<>8__locals12.$VB$Local_TheResult.Count - 1;
			for (int num2 = 0; num2 <= num; num2++)
			{
				result[num2] = CS$<>8__locals12.$VB$Local_TheResult[num2].ObjectID;
			}
		}
		return result;
	}

	public static LuaTable UI_SelectUnitsPrompt_FromSides(ref LuaTable result, LuaTable SidesNameOrID, bool MultipleSelect)
	{
		_Closure$__19-0 arg = default(_Closure$__19-0);
		_Closure$__19-0 CS$<>8__locals13 = new _Closure$__19-0(arg);
		CS$<>8__locals13.$VB$Local_MultipleSelect = MultipleSelect;
		CS$<>8__locals13.$VB$Local_AllSides = new List<Side>();
		foreach (object value in SidesNameOrID.Values)
		{
			Side side = LuaUtility.QuerySideObject(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(value)), Client.CurrentScenario);
			if (side != null)
			{
				CS$<>8__locals13.$VB$Local_AllSides.Add(side);
			}
		}
		CS$<>8__locals13.$VB$Local_TheResult = new List<ActiveUnit>();
		Form val = smethod_1();
		if (val != null)
		{
			((Control)val).Invoke((Delegate)(VB$AnonymousDelegate_0)([SpecialName] () =>
			{
				List<Side> side3 = CS$<>8__locals13.$VB$Local_AllSides;
				bool multipleSelection2 = CS$<>8__locals13.$VB$Local_MultipleSelect;
				ref List<ActiveUnit> selectedUnits2 = ref CS$<>8__locals13.$VB$Local_TheResult;
				List<ReferencePoint> list_2 = null;
				List<Zone> SelectedStandardZones2 = null;
				UnitSelection.CallDialog(side3, multipleSelection2, ref selectedUnits2, ref list_2, ref SelectedStandardZones2);
			}));
		}
		else
		{
			List<Side> side2 = CS$<>8__locals13.$VB$Local_AllSides;
			bool multipleSelection = CS$<>8__locals13.$VB$Local_MultipleSelect;
			ref List<ActiveUnit> selectedUnits = ref CS$<>8__locals13.$VB$Local_TheResult;
			List<ReferencePoint> list_ = null;
			List<Zone> SelectedStandardZones = null;
			UnitSelection.CallDialog(side2, multipleSelection, ref selectedUnits, ref list_, ref SelectedStandardZones);
		}
		result = LuaSandBox.Singleton().CreateTable();
		if (CS$<>8__locals13.$VB$Local_TheResult.Count > 0)
		{
			int num = CS$<>8__locals13.$VB$Local_TheResult.Count - 1;
			for (int num2 = 0; num2 <= num; num2++)
			{
				result[num2] = CS$<>8__locals13.$VB$Local_TheResult[num2].ObjectID;
			}
		}
		return result;
	}

	private static void smethod_6(ref byte byte_0, ref byte byte_1)
	{
		byte_0 = (byte)Client.CurrentGame.Status;
		byte_1 = (byte)Client.CurrentGame.GameMode;
	}

	private static object smethod_7(string string_0)
	{
		Form val = smethod_1();
		if (val != null)
		{
			lock (GameGeneral.MainGameLoopLockObj)
			{
				((Control)val).Invoke((Delegate)(VB$AnonymousDelegate_0)([SpecialName] () =>
				{
					Scenario.enumTimeCompression timeCompression2 = Client.CurrentScenario.TimeCompression;
					Client.CurrentGame.Pause();
					Client.CloseAllOpenWindows(Exclude3DView: true);
					int mustRefreshMainForm2;
					if (string_0 == null)
					{
						Client.CreateNewScenario();
						mustRefreshMainForm2 = 1;
					}
					else
					{
						Client.CreateNewScenario(string_0);
						mustRefreshMainForm2 = 1;
					}
					Client.MustRefreshMainForm = (byte)mustRefreshMainForm2 != 0;
					Client.CurrentGame.GameMode = Game._GameMode.ScenEdit;
					Client.MustRefreshMainForm = true;
					Client.CurrentScenario.TimeCompression_Set(timeCompression2);
					Client.CurrentGame.Run();
				}));
			}
		}
		else
		{
			Scenario.enumTimeCompression timeCompression = Client.CurrentScenario.TimeCompression;
			Client.CurrentGame.Pause();
			Client.CloseAllOpenWindows(Exclude3DView: true);
			int mustRefreshMainForm;
			if (string_0 != null)
			{
				Client.CreateNewScenario(string_0);
				mustRefreshMainForm = 1;
			}
			else
			{
				Client.CreateNewScenario();
				mustRefreshMainForm = 1;
			}
			Client.MustRefreshMainForm = (byte)mustRefreshMainForm != 0;
			Client.CurrentGame.GameMode = Game._GameMode.ScenEdit;
			Client.MustRefreshMainForm = true;
			Client.CurrentScenario.TimeCompression_Set(timeCompression);
			Client.CurrentGame.Run();
		}
		return Client.CurrentScenario;
	}

	private static object smethod_8(object object_0, bool bool_0)
	{
		bool flag = false;
		try
		{
			if (bool_0)
			{
				Client.smethod_37(bool_0);
			}
			Client.ClearMessageLog();
			flag = true;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		return flag;
	}
}
