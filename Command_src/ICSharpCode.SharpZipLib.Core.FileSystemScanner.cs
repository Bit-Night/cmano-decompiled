using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;

namespace ICSharpCode.SharpZipLib.Core;

public class FileSystemScanner
{
	[CompilerGenerated]
	private EventHandler<DirectoryEventArgs> eventHandler_0;

	public ProcessFileHandler ProcessFile;

	public CompletedFileHandler CompletedFile;

	public DirectoryFailureHandler DirectoryFailure;

	public FileFailureHandler FileFailure;

	private IScanFilter iscanFilter_0;

	private IScanFilter iscanFilter_1;

	private bool bool_0;

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

	public FileSystemScanner(string filter)
	{
		iscanFilter_0 = new PathFilter(filter);
	}

	public FileSystemScanner(string fileFilter, string directoryFilter)
	{
		iscanFilter_0 = new PathFilter(fileFilter);
		iscanFilter_1 = new PathFilter(directoryFilter);
	}

	public FileSystemScanner(IScanFilter fileFilter)
	{
		iscanFilter_0 = fileFilter;
	}

	public FileSystemScanner(IScanFilter fileFilter, IScanFilter directoryFilter)
	{
		iscanFilter_0 = fileFilter;
		iscanFilter_1 = directoryFilter;
	}

	private bool method_0(string string_0, Exception exception_0)
	{
		DirectoryFailureHandler directoryFailure = DirectoryFailure;
		bool num = directoryFailure != null;
		if (num)
		{
			ScanFailureEventArgs e = new ScanFailureEventArgs(string_0, exception_0);
			directoryFailure(this, e);
			bool_0 = e.ContinueRunning;
		}
		return num;
	}

	private bool method_1(string string_0, Exception exception_0)
	{
		bool num = FileFailure != null;
		if (num)
		{
			ScanFailureEventArgs e = new ScanFailureEventArgs(string_0, exception_0);
			FileFailure(this, e);
			bool_0 = e.ContinueRunning;
		}
		return num;
	}

	private void method_2(string string_0)
	{
		ProcessFileHandler processFile = ProcessFile;
		if (processFile != null)
		{
			ScanEventArgs e = new ScanEventArgs(string_0);
			processFile(this, e);
			bool_0 = e.ContinueRunning;
		}
	}

	private void method_3(string string_0)
	{
		CompletedFileHandler completedFile = CompletedFile;
		if (completedFile != null)
		{
			ScanEventArgs e = new ScanEventArgs(string_0);
			completedFile(this, e);
			bool_0 = e.ContinueRunning;
		}
	}

	private void method_4(string string_0, bool bool_1)
	{
		EventHandler<DirectoryEventArgs> eventHandler = eventHandler_0;
		if (eventHandler != null)
		{
			DirectoryEventArgs e = new DirectoryEventArgs(string_0, bool_1);
			eventHandler(this, e);
			bool_0 = e.ContinueRunning;
		}
	}

	public void Scan(string directory, bool recurse)
	{
		bool_0 = true;
		method_5(directory, recurse);
	}

	private void method_5(string string_0, bool bool_1)
	{
		try
		{
			string[] files = Directory.GetFiles(string_0);
			bool flag = false;
			for (int i = 0; i < files.Length; i++)
			{
				if (!iscanFilter_0.IsMatch(files[i]))
				{
					files[i] = null;
				}
				else
				{
					flag = true;
				}
			}
			method_4(string_0, flag);
			if (bool_0 && flag)
			{
				string[] array = files;
				foreach (string text in array)
				{
					try
					{
						if (text != null)
						{
							method_2(text);
							if (!bool_0)
							{
								break;
							}
						}
					}
					catch (Exception exception_)
					{
						if (!method_1(text, exception_))
						{
							throw;
						}
					}
				}
			}
		}
		catch (Exception exception_2)
		{
			if (!method_0(string_0, exception_2))
			{
				throw;
			}
		}
		if (!(bool_0 && bool_1))
		{
			return;
		}
		try
		{
			string[] array = Directory.GetDirectories(string_0);
			foreach (string text2 in array)
			{
				if (iscanFilter_1 == null || iscanFilter_1.IsMatch(text2))
				{
					method_5(text2, bool_1: true);
					if (!bool_0)
					{
						break;
					}
				}
			}
		}
		catch (Exception exception_3)
		{
			if (!method_0(string_0, exception_3))
			{
				throw;
			}
		}
	}

	static FileSystemScanner()
	{
		Class72.smethod_20();
	}
}
