using System;
using System.Collections;
using System.Collections.Generic;

namespace Collections.Pooled;

public interface GInterface11<T> : IReadOnlyList<T>, IReadOnlyCollection<T>, IEnumerable<T>, IEnumerable
{
	ReadOnlySpan<T> Span { get; }
}
