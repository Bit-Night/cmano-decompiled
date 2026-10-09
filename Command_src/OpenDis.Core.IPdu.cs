using System;
using System.Text;

namespace OpenDis.Core;

public interface IPdu
{
	event EventHandler<PduExceptionEventArgs> ExceptionOccured;

	void Marshal(DataOutputStream dos);

	void Reflection(StringBuilder sb);

	void Unmarshal(DataInputStream dis);
}
