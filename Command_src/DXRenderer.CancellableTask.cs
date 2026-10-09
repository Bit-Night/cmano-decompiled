using System.Threading;
using System.Threading.Tasks;

namespace DXRenderer;

internal struct CancellableTask
{
	internal string ID;

	internal Task Task;

	internal CancellationTokenSource TokenSource;
}
