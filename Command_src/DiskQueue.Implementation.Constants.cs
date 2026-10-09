using System;

namespace DiskQueue.Implementation;

public static class Constants
{
	public static int OperationSeparator;

	public static byte[] OperationSeparatorBytes;

	public static Guid StartTransactionSeparatorGuid;

	public static byte[] StartTransactionSeparator;

	public static Guid EndTransactionSeparatorGuid;

	public static byte[] EndTransactionSeparator;

	static Constants()
	{
		Class72.smethod_20();
		OperationSeparator = 1123990689;
		OperationSeparatorBytes = BitConverter.GetBytes(OperationSeparator);
		StartTransactionSeparatorGuid = new Guid("b75bfb12-93bb-42b6-acb1-a897239ea3a5");
		StartTransactionSeparator = StartTransactionSeparatorGuid.ToByteArray();
		EndTransactionSeparatorGuid = new Guid("866c9705-4456-4e9d-b452-3146b3bfa4ce");
		EndTransactionSeparator = EndTransactionSeparatorGuid.ToByteArray();
	}
}
