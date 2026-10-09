using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core.SmartAssembly.Attributes;

namespace Command;

[DoNotPrune]
[DoNotPruneType]
[DoNotObfuscate]
public abstract class ScenarioViewModel : CommandViewModel
{
	private string string_0;

	private string string_1;

	private string string_2;

	private string string_3;

	private string string_4;

	public ScenarioSelectControlViewModel ScenarioSelectControlViewModel;

	[CompilerGenerated]
	private RelayCommand relayCommand_0;

	public string ScenarioDate
	{
		get
		{
			return string_0;
		}
		set
		{
			SetProperty(ref string_0, value, "ScenarioDate");
		}
	}

	public string ScenarioComplexity
	{
		get
		{
			return string_1;
		}
		set
		{
			SetProperty(ref string_1, value, "ScenarioComplexity");
		}
	}

	public string ScenarioDifficulty
	{
		get
		{
			return string_2;
		}
		set
		{
			SetProperty(ref string_2, value, "ScenarioDifficulty");
		}
	}

	public string ScenarioName
	{
		get
		{
			return string_3;
		}
		set
		{
			SetProperty(ref string_3, value, "ScenarioName");
		}
	}

	public string ScenarioPath
	{
		get
		{
			return string_4;
		}
		set
		{
			SetProperty(ref string_4, value, "ScenarioPath");
		}
	}

	public RelayCommand SelectCommand
	{
		[CompilerGenerated]
		get
		{
			return relayCommand_0;
		}
		[CompilerGenerated]
		set
		{
			relayCommand_0 = value;
		}
	}

	protected ScenarioViewModel()
	{
		SelectCommand = new RelayCommand([SpecialName] (object a0) =>
		{
			SelectSubroutine();
		});
	}

	public void SelectSubroutine()
	{
		((Control)ScenarioSelectControlViewModel.LoadScenarioForm.Label_Title).Visible = true;
		((Control)ScenarioSelectControlViewModel.LoadScenarioForm.Label1).Visible = true;
		((Control)ScenarioSelectControlViewModel.LoadScenarioForm.PB_Difficulty).Visible = true;
		((Control)ScenarioSelectControlViewModel.LoadScenarioForm.Label2).Visible = true;
		((Control)ScenarioSelectControlViewModel.LoadScenarioForm.PB_Complexity).Visible = true;
		((Control)ScenarioSelectControlViewModel.LoadScenarioForm.Label4).Visible = true;
		ScenarioSelectControlViewModel.LoadScenarioForm.LoadFromPath(ScenarioPath, ScenarioPath);
	}

	static ScenarioViewModel()
	{
		Class72.smethod_20();
	}
}
