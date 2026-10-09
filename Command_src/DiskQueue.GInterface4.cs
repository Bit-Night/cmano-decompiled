using System;
using System.Collections.Generic;
using System.IO;
using DiskQueue.Implementation;

namespace DiskQueue;

public interface GInterface4 : IDisposable
{
	int CurrentFileNumber { get; }

	bool TrimTransactionLogOnDispose { get; set; }

	bool ParanoidFlushing { get; set; }

	void AcquireWriter(Stream stream, Func<Stream, long> action, Action<Stream> onReplaceStream);

	void CommitTransaction(ICollection<Operation> operations);

	Entry Dequeue();

	void Reinstate(IEnumerable<Operation> reinstatedOperations);
}
