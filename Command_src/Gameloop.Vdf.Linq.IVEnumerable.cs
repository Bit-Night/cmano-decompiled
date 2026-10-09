using System.Collections;
using System.Collections.Generic;

namespace Gameloop.Vdf.Linq;

public interface IVEnumerable<T> : IEnumerable<T>, IEnumerable where T : VToken
{
	IVEnumerable<VToken> this[object key] { get; }
}
