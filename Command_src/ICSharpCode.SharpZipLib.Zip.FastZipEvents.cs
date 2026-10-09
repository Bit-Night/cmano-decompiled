using System;
using System.Runtime.CompilerServices;
using System.Threading;
using ICSharpCode.SharpZipLib.Core;

namespace ICSharpCode.SharpZipLib.Zip;

public class FastZipEvents
{
	[CompilerGenerated]
	private EventHandler<DirectoryEventArgs> eventHandler_0;

	public ProcessFileHandler ProcessFile;

	public ProgressHandler Progress;

	public CompletedFileHandler CompletedFile;

	public DirectoryFailureHandler DirectoryFailure;

	public FileFailureHandler FileFailure;

	private TimeSpan timeSpan_0 = TimeSpan.FromSeconds(3.0);

	public TimeSpan ProgressInterval
	{
		get
		{
			return timeSpan_0;
		}
		set
		{
			timeSpan_0 = value;
		}
	}

	public event EventHandler<DirectoryEventArgs> ProcessDirectory
	{
		[CompilerGenerated]
		add
		{
			EventHandler<DirectoryEventArgs> eventHandler = eventHandler_0;
			EventHandler<DirectoryEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<DirectoryEventArgs> value2 = (EventHandler<DirectoryEventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<DirectoryEventArgs> eventHandler = eventHandler_0;
			EventHandler<DirectoryEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<DirectoryEventArgs> value2 = (EventHandler<DirectoryEventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public bool OnDirectoryFailure(string directory, Exception e)
	{
		bool result = false;
		DirectoryFailureHandler directoryFailure = DirectoryFailure;
		if (directoryFailure != null)
		{
			ScanFailureEventArgs e2 = new ScanFailureEventArgs(directory, e);
			directoryFailure(this, e2);
			result = e2.ContinueRunning;
		}
		return result;
	}

	public bool OnFileFailure(string file, Exception e)
	{
		FileFailureHandler fileFailure = FileFailure;
		bool result;
		if (result = fileFailure != null)
		{
			ScanFailureEventArgs e2 = new ScanFailureEventArgs(file, e);
			fileFailure(this, e2);
			result = e2.ContinueRunning;
		}
		return result;
	}

	public bool OnProcessFile(string file)
	{
		bool result = true;
		ProcessFileHandler processFile = ProcessFile;
		if (processFile != null)
		{
			ScanEventArgs e = new ScanEventArgs(file);
			processFile(this, e);
			result = e.ContinueRunning;
		}
		return result;
	}

	public bool OnCompletedFile(string file)
	{
		bool result = true;
		CompletedFileHandler completedFile = CompletedFile;
		if (completedFile != null)
		{
			ScanEventArgs e = new ScanEventArgs(file);
			completedFile(this, e);
			result = e.ContinueRunning;
		}
		return result;
	}

	public bool OnProcessDirectory(string directory, bool hasMatchingFiles)
	{
		bool result = true;
		EventHandler<DirectoryEventArgs> eventHandler = eventHandler_0;
		if (eventHandler != null)
		{
			DirectoryEventArgs e = new DirectoryEventArgs(directory, hasMatchingFiles);
			eventHandler(this, e);
			result = e.ContinueRunning;
		}
		return result;
	}

	static FastZipEvents()
	{
		Class72.smethod_20();
	}
}
