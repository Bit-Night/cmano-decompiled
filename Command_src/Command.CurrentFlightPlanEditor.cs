using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using DarkUI.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class CurrentFlightPlanEditor : DarkSecondaryFormBase
{
	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("Timer1")]
	private Timer timer_0;

	public Aircraft SelectedAircraft;

	public List<Waypoint> waypoints;

	internal virtual Timer Timer1
	{
		[CompilerGenerated]
		get
		{
			return timer_0;
		}
		[CompilerGenerated]
		set
		{
			timer_0 = value;
		}
	}

	public CurrentFlightPlanEditor()
	{
		((Form)this).Load += CurrentFlightPlanEditor_Load;
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
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Expected O, but got Unknown
		icontainer_1 = new Container();
		Timer1 = new Timer(icontainer_1);
		((Control)this).SuspendLayout();
		Timer1.Interval = 1000;
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(198, 670);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Form)this).Location = new Point(0, 0);
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Form)this).MinimumSize = new Size(220, 150);
		((Control)this).Name = "CurrentFlightPlanEditor";
		((Form)this).ShowIcon = false;
		((Form)this).SizeGripStyle = (SizeGripStyle)1;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "CurrentFlightPlanEditor";
		((Control)this).ResumeLayout(false);
		((Form)this).Size = new Size(220, 150);
	}

	private void CurrentFlightPlanEditor_Load(object sender, EventArgs e)
	{
		method_2();
	}

	private void method_2()
	{
		waypoints = SelectedAircraft.ActiveMissionOrPackage().FlightList.Where([SpecialName] (Mission.Flight theF) => Operators.CompareString(theF.Callsign, ((ActiveUnit_Navigator)SelectedAircraft.Navigator).get_Flight(HierarchySearch: true).Callsign, true) == 0).First().FlightPlan.ToList();
		List<Waypoint> list = new List<Waypoint>();
		List<string> list2 = new List<string>();
		foreach (Waypoint item in SelectedAircraft.ActiveMissionOrPackage().FlightList.Where([SpecialName] (Mission.Flight theF) => Operators.CompareString(theF.Callsign, ((ActiveUnit_Navigator)SelectedAircraft.Navigator).get_Flight(HierarchySearch: true).Callsign, true) == 0).First().FlightPlan.ToList())
		{
			if (list2.Contains(item.Description))
			{
				list.Add(item);
			}
			else
			{
				list2.Add(item.Description);
			}
		}
		foreach (Waypoint item2 in list)
		{
			if (waypoints.Contains(item2))
			{
				waypoints.Remove(item2);
			}
		}
		((Control)this).Controls.Clear();
		int num = 10;
		int left = 10;
		int num2 = 30;
		int num3 = 10;
		int num4 = waypoints.Count - 1;
		for (int num5 = 0; num5 <= num4; num5++)
		{
			DarkUIButton darkUIButton = new DarkUIButton();
			darkUIButton.Text = waypoints[num5].Description + " " + waypoints[num5].Name;
			((Control)darkUIButton).Top = num + (num2 + num3) * num5;
			((Control)darkUIButton).Left = left;
			((Control)darkUIButton).Height = num2;
			((Control)darkUIButton).Width = 200;
			((Control)darkUIButton).Tag = waypoints[num5];
			((Control)darkUIButton).Click += method_3;
			((Control)this).Controls.Add((Control)(object)darkUIButton);
		}
		((Control)this).Width = 220;
	}

	private void method_3(object sender, EventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Invalid comparison between Unknown and I4
		Waypoint waypoint = (Waypoint)((Control)(Button)sender).Tag;
		List<Aircraft> list = new List<Aircraft>();
		if (!SelectedAircraft.IsGroupMember())
		{
			list.Add(SelectedAircraft);
		}
		else if ((int)DarkMessageBox.ShowInformation("Do you want to update the Next Wp for all the ACs in the group?", "Ac is part of a group", DarkDialogButton.YesNo) == 6)
		{
			IEnumerator<KeyValuePair<string, ActiveUnit>> enumerator = ((ActiveUnit)SelectedAircraft).get_ParentGroup(UsingMissionPlanner: false).Units.GetEnumerator();
			while (enumerator.MoveNext())
			{
				list.Add((Aircraft)enumerator.Current.Value);
			}
		}
		else
		{
			list.Add(SelectedAircraft);
		}
		List<Aircraft>.Enumerator enumerator2 = list.GetEnumerator();
		while (enumerator2.MoveNext())
		{
			Aircraft current = enumerator2.Current;
			SelectedAircraft = current;
			Mission.Flight flight = ((ActiveUnit_Navigator)SelectedAircraft.Navigator).get_Flight(HierarchySearch: true);
			Waypoint[] theArray = flight.FlightPlan;
			ArrayExtensions.Clear(ref theArray);
			flight.FlightPlan = theArray;
			bool flag = false;
			List<Waypoint>.Enumerator enumerator3 = waypoints.GetEnumerator();
			while (enumerator3.MoveNext())
			{
				Waypoint current2 = enumerator3.Current;
				if (Operators.CompareString(current2.Description, waypoint.Description, true) == 0)
				{
					SelectedAircraft.Teleport(ref SelectedAircraft.ParentScen, waypoint.Longitude, waypoint.Latitude);
					int num;
					if (!((ActiveUnit_Navigator)SelectedAircraft.Navigator).get_Flight(HierarchySearch: true).FlightPlan.Contains(current2))
					{
						Mission.Flight flight2 = ((ActiveUnit_Navigator)SelectedAircraft.Navigator).get_Flight(HierarchySearch: true);
						theArray = flight2.FlightPlan;
						ArrayExtensions.Add(ref theArray, current2);
						flight2.FlightPlan = theArray;
						num = 1;
					}
					else
					{
						num = 1;
					}
					flag = (byte)num != 0;
				}
				if (flag)
				{
					Mission.Flight flight3 = ((ActiveUnit_Navigator)SelectedAircraft.Navigator).get_Flight(HierarchySearch: true);
					theArray = flight3.FlightPlan;
					ArrayExtensions.Add(ref theArray, current2);
					flight3.FlightPlan = theArray;
				}
			}
			if (flag)
			{
				SelectedAircraft.Navigator.WP_reach_cache_memory.Clear();
				Aircraft_Navigator navigator = SelectedAircraft.Navigator;
				theArray = navigator.PlottedCourse;
				ArrayExtensions.Clear(ref theArray);
				navigator.PlottedCourse = theArray;
			}
		}
	}

	static CurrentFlightPlanEditor()
	{
		Class72.smethod_20();
	}
}
