using System;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;
using DiskQueue.Implementation.CrossPlatform.Unix;

namespace DiskQueue;

public static class SetPermissions
{
	public static bool RunningUnderPosix
	{
		get
		{
			int platform = (int)Environment.OSVersion.Platform;
			if (platform != 4 && platform != 6)
			{
				return platform == 128;
			}
			return true;
		}
	}

	public static void AllowReadWriteForAll(string path)
	{
		if (Directory.Exists(path))
		{
			smethod_1(path);
			return;
		}
		if (!FileExistsNative.FileExistsFast(path))
		{
			throw new UnauthorizedAccessException("Can't access the path \"" + path + "\"");
		}
		smethod_0(path);
	}

	public static void TryAllowReadWriteForAll(string path)
	{
		try
		{
			if (Directory.Exists(path))
			{
				smethod_1(path);
			}
			else if (FileExistsNative.FileExistsFast(path))
			{
				smethod_0(path);
			}
		}
		catch
		{
			Ignore();
		}
	}

	private static void Ignore()
	{
	}

	private static void smethod_0(string string_0)
	{
		if (!RunningUnderPosix)
		{
			FileSecurity accessControl = File.GetAccessControl(string_0);
			SecurityIdentifier identity = new SecurityIdentifier(WellKnownSidType.WorldSid, null);
			accessControl.AddAccessRule(new FileSystemAccessRule(identity, FileSystemRights.Modify | FileSystemRights.Synchronize, InheritanceFlags.None, PropagationFlags.None, AccessControlType.Allow));
			File.SetAccessControl(string_0, accessControl);
		}
		else
		{
			UnsafeNativeMethods.chmod(string_0, UnixFilePermissions.ACCESSPERMS);
		}
	}

	private static void smethod_1(string string_0)
	{
		if (!RunningUnderPosix)
		{
			DirectorySecurity accessControl = Directory.GetAccessControl(string_0);
			SecurityIdentifier identity = new SecurityIdentifier(WellKnownSidType.WorldSid, null);
			accessControl.AddAccessRule(new FileSystemAccessRule(identity, FileSystemRights.Modify | FileSystemRights.Synchronize, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow));
			Directory.SetAccessControl(string_0, accessControl);
		}
		else
		{
			UnsafeNativeMethods.chmod(string_0, UnixFilePermissions.ACCESSPERMS);
		}
	}

	static SetPermissions()
	{
		Class72.smethod_20();
	}
}
