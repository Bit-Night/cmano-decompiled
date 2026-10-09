using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class InteractiveManual : Form
{
	public class ManualNode
	{
		public bool IsFolder;

		public string Name;

		public string iPath;

		public Dictionary<ManualNode, ManualNode> ChildNodes;

		private InteractiveManual interactiveManual_0;

		public ManualNode ParentNode;

		public void AddChildNode(ManualNode node)
		{
			ChildNodes.Add(node, node);
			node.ParentNode = this;
		}

		public void RemoveChildNode(ManualNode node)
		{
			node.ParentNode = null;
			ChildNodes.Remove(node);
		}

		public void GenerateNode(string CurrentLayer, ManualNode ParentNode)
		{
			string[] files = Directory.GetFiles(CurrentLayer);
			foreach (string path in files)
			{
				ManualNode manualNode = new ManualNode(IsFolder: false, Path.GetFileName(path), CurrentLayer, interactiveManual_0);
				interactiveManual_0.Nodes.Add(manualNode, manualNode);
				ParentNode.AddChildNode(manualNode);
			}
			string[] directories = Directory.GetDirectories(CurrentLayer);
			foreach (string path2 in directories)
			{
				ManualNode manualNode2 = new ManualNode(IsFolder: true, Path.GetFileName(path2), CurrentLayer, interactiveManual_0);
				interactiveManual_0.Nodes.Add(manualNode2, manualNode2);
				ParentNode.AddChildNode(manualNode2);
			}
		}

		public ManualNode(bool IsFolder, string Name, string _Path, InteractiveManual Manual)
		{
			ChildNodes = new Dictionary<ManualNode, ManualNode>();
			this.IsFolder = IsFolder;
			this.Name = Name;
			iPath = _Path;
			interactiveManual_0 = Manual;
			string text = Path.Combine(_Path, Name);
			string key = Strings.Replace(Name, ".mht", "", 1, -1, (CompareMethod)1);
			if (!IsFolder && !Manual.FilesByFullPath.ContainsKey(key))
			{
				Manual.FilesByFullPath.Add(key, text);
			}
			if (IsFolder)
			{
				GenerateNode(text, this);
			}
		}

		static ManualNode()
		{
			Class72.smethod_20();
		}
	}

	private IContainer vKrUcqvQvu;

	[CompilerGenerated]
	[AccessedThroughProperty("TV_ManualPages")]
	private TreeView _TV_ManualPages;

	public Dictionary<ManualNode, ManualNode> Nodes;

	public Dictionary<string, string> FilesByFullPath;

	public Dictionary<string, TreeNode> FilesByTreeNode;

	public string _Rootpath;

	[field: AccessedThroughProperty("WebBrowser")]
	internal virtual WebBrowser WebBrowser { get; set; }

	internal virtual TreeView TV_ManualPages
	{
		[CompilerGenerated]
		get
		{
			return _TV_ManualPages;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			TreeViewEventHandler val = new TreeViewEventHandler(method_0);
			TreeView val2 = _TV_ManualPages;
			if (val2 != null)
			{
				val2.AfterSelect -= val;
			}
			_TV_ManualPages = value;
			val2 = _TV_ManualPages;
			if (val2 != null)
			{
				val2.AfterSelect += val;
			}
		}
	}

	public string Rootpath
	{
		get
		{
			if (string.IsNullOrEmpty(_Rootpath))
			{
				_Rootpath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Manuals\\InteractiveManual");
			}
			return _Rootpath;
		}
	}

	public InteractiveManual()
	{
		Nodes = new Dictionary<ManualNode, ManualNode>();
		FilesByFullPath = new Dictionary<string, string>();
		FilesByTreeNode = new Dictionary<string, TreeNode>();
		_Rootpath = "";
		InitializeComponent();
	}

	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && vKrUcqvQvu != null)
			{
				vKrUcqvQvu.Dispose();
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
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected O, but got Unknown
		WebBrowser = new WebBrowser();
		TV_ManualPages = new TreeView();
		((Control)this).SuspendLayout();
		WebBrowser.AllowWebBrowserDrop = false;
		((Control)WebBrowser).Anchor = (AnchorStyles)15;
		WebBrowser.IsWebBrowserContextMenuEnabled = false;
		((Control)WebBrowser).Location = new Point(202, 12);
		((Control)WebBrowser).MinimumSize = new Size(20, 20);
		((Control)WebBrowser).Name = "WebBrowser";
		((Control)WebBrowser).Size = new Size(713, 439);
		((Control)WebBrowser).TabIndex = 24;
		WebBrowser.WebBrowserShortcutsEnabled = false;
		((Control)TV_ManualPages).Anchor = (AnchorStyles)7;
		((Control)TV_ManualPages).Location = new Point(4, 12);
		((Control)TV_ManualPages).Name = "TV_ManualPages";
		((Control)TV_ManualPages).Size = new Size(192, 439);
		((Control)TV_ManualPages).TabIndex = 25;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(927, 463);
		((Control)this).Controls.Add((Control)(object)WebBrowser);
		((Control)this).Controls.Add((Control)(object)TV_ManualPages);
		((Control)this).Name = "InteractiveManual";
		((Form)this).Text = "Interactive Manual";
		((Control)this).ResumeLayout(false);
	}

	public void Show()
	{
		Show("Main");
	}

	public void Show(string page)
	{
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			PopulateTV();
			LoadPage(page);
			((Control)this).Show();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 2007377", ex2.Message);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			MessageBox.Show("Impossible to load the interactive manual, the Interactive manual may be missing.", "Error : interactive manual");
			ProjectData.ClearProjectError();
		}
	}

	public void LoadPage(string thePage)
	{
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		if (FilesByFullPath.ContainsKey(thePage))
		{
			WebBrowser.Url = new Uri("file:///" + FilesByFullPath[thePage]);
			TV_ManualPages.SelectedNode = FilesByTreeNode[thePage];
		}
		else
		{
			MessageBox.Show("File not found", "Error : File not found");
		}
	}

	public void PopulateTV()
	{
		string rootpath = Rootpath;
		ManualNode manualNode = new ManualNode(IsFolder: true, "", rootpath, this);
		Nodes.Add(manualNode, manualNode);
		TVNode(manualNode, null);
	}

	public void TVNode(ManualNode Node, TreeNode parentTVnode)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected O, but got Unknown
		string text = Strings.Replace(Node.Name, ".mht", "", 1, -1, (CompareMethod)1);
		TreeNode val = new TreeNode(text);
		if (!Node.IsFolder && !FilesByTreeNode.ContainsKey(text))
		{
			FilesByTreeNode.Add(text, val);
		}
		val.Tag = Node;
		if (parentTVnode != null)
		{
			parentTVnode.Nodes.Add(val);
		}
		else
		{
			TV_ManualPages.Nodes.Add(val);
		}
		foreach (KeyValuePair<ManualNode, ManualNode> childNode in Node.ChildNodes)
		{
			TVNode(childNode.Key, val);
		}
	}

	private void method_0(object sender, TreeViewEventArgs e)
	{
		ManualNode manualNode = (ManualNode)TV_ManualPages.SelectedNode.Tag;
		if (!manualNode.IsFolder)
		{
			LoadPage(Strings.Replace(manualNode.Name, ".mht", "", 1, -1, (CompareMethod)1));
		}
	}

	static InteractiveManual()
	{
		Class72.smethod_20();
	}
}
