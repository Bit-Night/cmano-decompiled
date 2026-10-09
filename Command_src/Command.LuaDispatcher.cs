using System;
using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[StandardModule]
public sealed class LuaDispatcher
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct VB$StateMachine_4_RunLuaAndReturnString : IAsyncStateMachine
	{
		public int $State;

		public AsyncTaskMethodBuilder<string> $Builder;

		internal string $VB$Local_code;

		internal TaskAwaiter<string> $A0;

		[CompilerGenerated]
		internal void MoveNext()
		{
			int num = $State;
			string result2;
			try
			{
				TaskAwaiter<string> awaiter;
				if (num != 0)
				{
					awaiter = EnqueueAsync((Func<string>)new _Closure$__4-0
					{
						$VB$Local_code = $VB$Local_code
					}._Lambda$__0).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = 0;
						$State = 0;
						$A0 = awaiter;
						$Builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
						return;
					}
				}
				else
				{
					num = -1;
					$State = -1;
					awaiter = $A0;
					$A0 = default(TaskAwaiter<string>);
				}
				string result = awaiter.GetResult();
				awaiter = default(TaskAwaiter<string>);
				result2 = result;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception = ex;
				$State = -2;
				$Builder.SetException(exception);
				ProjectData.ClearProjectError();
				return;
			}
			num = -2;
			$State = -2;
			$Builder.SetResult(result2);
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			$Builder.SetStateMachine(stateMachine);
		}

		static VB$StateMachine_4_RunLuaAndReturnString()
		{
			Class72.smethod_20();
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct VB$StateMachine_5_EnqueueAsync<SM$T> : IAsyncStateMachine
	{
		public int $State;

		public AsyncTaskMethodBuilder<SM$T> $Builder;

		internal Func<SM$T> $VB$Local_job;

		internal TaskAwaiter<SM$T> $A0;

		[CompilerGenerated]
		internal void MoveNext()
		{
			int num = $State;
			SM$T result2;
			try
			{
				TaskAwaiter<SM$T> awaiter;
				if (num != 0)
				{
					_Closure$__5-0<SM$T> obj = new _Closure$__5-0<SM$T>
					{
						$VB$Local_job = $VB$Local_job,
						$VB$Local_tcs = new TaskCompletionSource<SM$T>(TaskCreationOptions.RunContinuationsAsynchronously)
					};
					Enqueue([SpecialName] () =>
					{
						try
						{
							obj.$VB$Local_tcs.SetResult(obj.$VB$Local_job());
						}
						catch (Exception ex2)
						{
							ProjectData.SetProjectError(ex2);
							Exception exception2 = ex2;
							obj.$VB$Local_tcs.SetException(exception2);
							ProjectData.ClearProjectError();
						}
					});
					awaiter = obj.$VB$Local_tcs.Task.GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = 0;
						$State = 0;
						$A0 = awaiter;
						$Builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
						return;
					}
				}
				else
				{
					num = -1;
					$State = -1;
					awaiter = $A0;
					$A0 = default(TaskAwaiter<SM$T>);
				}
				SM$T result = awaiter.GetResult();
				awaiter = default(TaskAwaiter<SM$T>);
				result2 = result;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception = ex;
				$State = -2;
				$Builder.SetException(exception);
				ProjectData.ClearProjectError();
				return;
			}
			num = -2;
			$State = -2;
			$Builder.SetResult(result2);
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			$Builder.SetStateMachine(stateMachine);
		}

		static VB$StateMachine_5_EnqueueAsync()
		{
			Class72.smethod_20();
		}

		internal static bool smethod_0()
		{
			return true;
		}

		internal static object smethod_1()
		{
			return null;
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct VB$StateMachine_6_EnqueueAsync : IAsyncStateMachine
	{
		public int $State;

		public AsyncTaskMethodBuilder $Builder;

		internal Action $VB$Local_job;

		internal TaskAwaiter<bool> $A0;

		[CompilerGenerated]
		internal void MoveNext()
		{
			int num = $State;
			try
			{
				TaskAwaiter<bool> awaiter;
				if (num != 0)
				{
					_Closure$__6-0 obj = new _Closure$__6-0
					{
						$VB$Local_job = $VB$Local_job,
						$VB$Local_tcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously)
					};
					Enqueue([SpecialName] () =>
					{
						try
						{
							obj.$VB$Local_job();
							obj.$VB$Local_tcs.SetResult(result: true);
						}
						catch (Exception ex2)
						{
							ProjectData.SetProjectError(ex2);
							Exception exception2 = ex2;
							obj.$VB$Local_tcs.SetException(exception2);
							ProjectData.ClearProjectError();
						}
					});
					awaiter = obj.$VB$Local_tcs.Task.GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = 0;
						$State = 0;
						$A0 = awaiter;
						$Builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
						return;
					}
				}
				else
				{
					num = -1;
					$State = -1;
					awaiter = $A0;
					$A0 = default(TaskAwaiter<bool>);
				}
				awaiter.GetResult();
				awaiter = default(TaskAwaiter<bool>);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception = ex;
				$State = -2;
				$Builder.SetException(exception);
				ProjectData.ClearProjectError();
				return;
			}
			num = -2;
			$State = -2;
			$Builder.SetResult();
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			$Builder.SetStateMachine(stateMachine);
		}

		static VB$StateMachine_6_EnqueueAsync()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__4-0
	{
		public string $VB$Local_code;

		[SpecialName]
		internal string _Lambda$__0()
		{
			return Client.CurrentScenario.Scenario_LuaSandbox.RunScript($VB$Local_code, RunInteractively: true)[0].ToString();
		}

		static _Closure$__4-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__5-0<$CLS0>
	{
		public TaskCompletionSource<$CLS0> $VB$Local_tcs;

		public Func<$CLS0> $VB$Local_job;

		internal static object object_0;

		[SpecialName]
		internal void _Lambda$__0()
		{
			try
			{
				$VB$Local_tcs.SetResult($VB$Local_job());
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception = ex;
				$VB$Local_tcs.SetException(exception);
				ProjectData.ClearProjectError();
			}
		}

		static _Closure$__5-0()
		{
			Class72.smethod_20();
		}

		internal static bool smethod_0()
		{
			return object_0 == null;
		}

		internal static object smethod_1()
		{
			return object_0;
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__6-0
	{
		public Action $VB$Local_job;

		public TaskCompletionSource<bool> $VB$Local_tcs;

		[SpecialName]
		internal void _Lambda$__0()
		{
			try
			{
				$VB$Local_job();
				$VB$Local_tcs.SetResult(result: true);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception = ex;
				$VB$Local_tcs.SetException(exception);
				ProjectData.ClearProjectError();
			}
		}

		static _Closure$__6-0()
		{
			Class72.smethod_20();
		}
	}

	public static readonly ConcurrentQueue<Action> LuaJobQueue;

	public static readonly AutoResetEvent JobSignal;

	static LuaDispatcher()
	{
		Class72.smethod_20();
		LuaJobQueue = new ConcurrentQueue<Action>();
		JobSignal = new AutoResetEvent(initialState: false);
	}

	public static void ProcessLuaQueue()
	{
		Action result;
		while (!LuaJobQueue.IsEmpty && LuaJobQueue.TryDequeue(out result))
		{
			try
			{
				result();
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	[AsyncStateMachine(typeof(VB$StateMachine_4_RunLuaAndReturnString))]
	public static Task<string> RunLuaAndReturnString(string code)
	{
		VB$StateMachine_4_RunLuaAndReturnString stateMachine = default(VB$StateMachine_4_RunLuaAndReturnString);
		stateMachine.$VB$Local_code = code;
		stateMachine.$State = -1;
		stateMachine.$Builder = AsyncTaskMethodBuilder<string>.Create();
		stateMachine.$Builder.Start(ref stateMachine);
		return stateMachine.$Builder.Task;
	}

	[AsyncStateMachine(typeof(VB$StateMachine_5_EnqueueAsync<>))]
	public static Task<T> EnqueueAsync<T>(Func<T> job)
	{
		VB$StateMachine_5_EnqueueAsync<T> stateMachine = default(VB$StateMachine_5_EnqueueAsync<T>);
		stateMachine.$VB$Local_job = job;
		stateMachine.$State = -1;
		stateMachine.$Builder = AsyncTaskMethodBuilder<T>.Create();
		stateMachine.$Builder.Start(ref stateMachine);
		return stateMachine.$Builder.Task;
	}

	[AsyncStateMachine(typeof(VB$StateMachine_6_EnqueueAsync))]
	public static Task EnqueueAsync(Action job)
	{
		VB$StateMachine_6_EnqueueAsync stateMachine = default(VB$StateMachine_6_EnqueueAsync);
		stateMachine.$VB$Local_job = job;
		stateMachine.$State = -1;
		stateMachine.$Builder = AsyncTaskMethodBuilder.Create();
		stateMachine.$Builder.Start(ref stateMachine);
		return stateMachine.$Builder.Task;
	}

	public static void Enqueue(Action job)
	{
		LuaJobQueue.Enqueue(job);
	}
}
