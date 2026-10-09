namespace DiskQueue.Implementation;

public enum OperationType : byte
{
	Enqueue = 1,
	Dequeue,
	Reinstate
}
