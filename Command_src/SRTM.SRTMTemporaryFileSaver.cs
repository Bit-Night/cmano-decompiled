using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace SRTM;

public sealed class SRTMTemporaryFileSaver
{
	private class Class30
	{
		public string string_0;

		public ISRTMDataCell isrtmdataCell_0;

		static Class30()
		{
			Class72.smethod_20();
		}
	}

	private List<Class30> list_0;

	private Thread thread_0;

	private object object_0;

	public bool _shutdown;

	private DriveInfo driveInfo_0;

	public SRTMTemporaryFileSaver(string dir)
	{
		driveInfo_0 = new DriveInfo(Path.GetPathRoot(dir));
		object_0 = new object();
		list_0 = new List<Class30>();
		thread_0 = new Thread(method_0);
		thread_0.Start();
	}

	public void Save(string FileName, ISRTMDataCell Cell)
	{
		if (!_shutdown)
		{
			if (driveInfo_0 == null || driveInfo_0.AvailableFreeSpace >= 10737418240L)
			{
				Class30 @class = new Class30();
				@class.string_0 = FileName;
				@class.isrtmdataCell_0 = Cell;
				lock (object_0)
				{
					list_0.Add(@class);
					return;
				}
			}
			ShutDown();
		}
		else
		{
			list_0.Clear();
		}
	}

	public void ShutDown()
	{
		_shutdown = true;
		while (thread_0 != null && thread_0.IsAlive)
		{
			Thread.Sleep(0);
		}
	}

	private void method_0()
	{
		while (!_shutdown)
		{
			Thread.Sleep(1050);
			if (list_0.Count <= 0)
			{
				continue;
			}
			lock (object_0)
			{
				try
				{
					for (int i = 0; i < list_0.Count; i++)
					{
						if (!FileExistsNative.FileExistsFast(list_0[i].string_0))
						{
							FileStream fileStream = File.Create(list_0[i].string_0);
							if (fileStream != null)
							{
								list_0[i].isrtmdataCell_0.WriteBytesToFile(fileStream);
								fileStream.Flush();
								fileStream.Close();
							}
						}
					}
					list_0.Clear();
				}
				catch (Exception)
				{
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					_shutdown = true;
				}
			}
		}
	}

	public SRTMTemporaryFileSaver()
	{
	}

	~SRTMTemporaryFileSaver()
	{
		if (!_shutdown)
		{
			ShutDown();
		}
	}

	static SRTMTemporaryFileSaver()
	{
		Class72.smethod_20();
	}
}
