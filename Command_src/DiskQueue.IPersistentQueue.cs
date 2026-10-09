using System;

namespace DiskQueue;

public interface IPersistentQueue : IDisposable
{
	int EstimatedCountOfItemsInQueue { get; }

	GInterface4 Internals { get; }

	int MaxFileSize { get; }

	IPersistentQueueSession OpenSession();
}
