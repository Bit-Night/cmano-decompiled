using System.Collections.Generic;
using System.IO;
using System.Linq;
using Command_Core.LoadSave;
using Microsoft.VisualBasic.CompilerServices;
using SevenZip;

namespace Command_Core;

[StandardModule]
public sealed class AttachmentRepoManager
{
	private static SevenZipCompressor sevenZipCompressor_0;

	public static void PackageScenarioForDistribution(Scenario theScen, Side theCurrentSide, string TargetFileName)
	{
		if (theScen.ScenAttachments.Count == 0)
		{
			return;
		}
		if (Directory.Exists(Path.Combine(GameGeneral.TempPath, "package")))
		{
			Directory.Delete(Path.Combine(GameGeneral.TempPath, "package"), recursive: true);
		}
		Directory.CreateDirectory(Path.Combine(GameGeneral.TempPath, "package"));
		Command_Core.LoadSave.LoadSave.SaveScenario(theScen, theCurrentSide, Path.Combine(GameGeneral.TempPath, "package", Path.GetFileNameWithoutExtension(TargetFileName) + ".scen"), SBR: false);
		Directory.CreateDirectory(Path.Combine(GameGeneral.TempPath, "package\\attachments"));
		foreach (KeyValuePair<string, ScenAttachmentObject> scenAttachment in theScen.ScenAttachments)
		{
			if (Directory.Exists(Path.Combine(GameGeneral.AttachmentRepoPath, scenAttachment.Key)))
			{
				Misc.CopyDirectory(Path.Combine(GameGeneral.AttachmentRepoPath, scenAttachment.Key), Path.Combine(GameGeneral.TempPath, "package\\attachments", scenAttachment.Key), copySubDirs: true);
			}
		}
		sevenZipCompressor_0 = new SevenZipCompressor();
		sevenZipCompressor_0.ArchiveFormat = OutArchiveFormat.Zip;
		sevenZipCompressor_0.CompressionLevel = CompressionLevel.Fast;
		sevenZipCompressor_0.CompressDirectory(Path.Combine(GameGeneral.TempPath, "package"), TargetFileName, recursion: true);
		Directory.Delete(Path.Combine(GameGeneral.TempPath, "package"), recursive: true);
		sevenZipCompressor_0 = null;
	}

	public static void MoveAttachmentsToLocalRepo(Scenario theScen, string ScenFileFullPath)
	{
		string text = Path.Combine(Path.GetDirectoryName(ScenFileFullPath), "attachments");
		if (!Directory.Exists(text))
		{
			return;
		}
		foreach (KeyValuePair<string, ScenAttachmentObject> scenAttachment in theScen.ScenAttachments)
		{
			if (Directory.Exists(Path.Combine(text, scenAttachment.Key)))
			{
				if (Directory.Exists(Path.Combine(GameGeneral.AttachmentRepoPath, scenAttachment.Key)))
				{
					Directory.Delete(Path.Combine(GameGeneral.AttachmentRepoPath, scenAttachment.Key), recursive: true);
				}
				Directory.Move(Path.Combine(text, scenAttachment.Key), Path.Combine(GameGeneral.AttachmentRepoPath, scenAttachment.Key));
			}
		}
		if (Directory.Exists(text) && Directory.EnumerateFileSystemEntries(text).Count() == 0)
		{
			Directory.Delete(text);
		}
	}

	public static void MoveAttachmentsToLocalRepo(string theFolder)
	{
		string text = Path.Combine(theFolder, "attachments");
		if (!Directory.Exists(text))
		{
			return;
		}
		string[] directories = Directory.GetDirectories(text);
		foreach (string path in directories)
		{
			if (Directory.Exists(Path.Combine(GameGeneral.AttachmentRepoPath, Path.GetFileName(path))))
			{
				Directory.Delete(Path.Combine(GameGeneral.AttachmentRepoPath, Path.GetFileName(path)), recursive: true);
			}
			Directory.Move(Path.Combine(text, Path.GetFileName(path)), Path.Combine(GameGeneral.AttachmentRepoPath, Path.GetFileName(path)));
		}
		if (Directory.Exists(text) && Directory.EnumerateFileSystemEntries(text).Count() == 0)
		{
			Directory.Delete(text);
		}
	}

	static AttachmentRepoManager()
	{
		Class72.smethod_20();
	}
}
