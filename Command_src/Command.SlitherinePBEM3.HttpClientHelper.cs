using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;

namespace Command.SlitherinePBEM3;

internal class HttpClientHelper
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct VB$StateMachine_3_SendRequestAsync : IAsyncStateMachine
	{
		public int $State;

		public AsyncTaskMethodBuilder<string> $Builder;

		internal string $VB$Local_method;

		internal string $VB$Local_url;

		internal string $VB$Local_body;

		internal string $VB$Local_AuthToken;

		internal TaskAwaiter<HttpResponseMessage> $A0;

		internal TaskAwaiter<string> $A1;

		[CompilerGenerated]
		internal void MoveNext()
		{
			//IL_0039: Unknown result type (might be due to invalid IL or missing references)
			//IL_0049: Expected O, but got Unknown
			//IL_0044: Unknown result type (might be due to invalid IL or missing references)
			//IL_004a: Expected O, but got Unknown
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0095: Expected O, but got Unknown
			int num = $State;
			string result3;
			try
			{
				TaskAwaiter<HttpResponseMessage> awaiter;
				TaskAwaiter<string> awaiter2;
				if (num == 0)
				{
					num = -1;
					$State = -1;
					awaiter = $A0;
					$A0 = default(TaskAwaiter<HttpResponseMessage>);
				}
				else
				{
					if (num == 1)
					{
						num = -1;
						$State = -1;
						awaiter2 = $A1;
						$A1 = default(TaskAwaiter<string>);
						goto IL_0142;
					}
					HttpRequestMessage val = new HttpRequestMessage(new HttpMethod($VB$Local_method), $VB$Local_url);
					if (!string.IsNullOrEmpty($VB$Local_AuthToken))
					{
						((HttpHeaders)val.Headers).Add("X-AUTH-TOKEN", $VB$Local_AuthToken);
					}
					if (!string.IsNullOrEmpty($VB$Local_body))
					{
						val.Content = (HttpContent)new StringContent($VB$Local_body, Encoding.UTF8, "application/json");
					}
					awaiter = client.SendAsync(val).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = 0;
						$State = 0;
						$A0 = awaiter;
						$Builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
						return;
					}
				}
				HttpResponseMessage result = awaiter.GetResult();
				awaiter = default(TaskAwaiter<HttpResponseMessage>);
				result.EnsureSuccessStatusCode();
				awaiter2 = result.Content.ReadAsStringAsync().GetAwaiter();
				if (!awaiter2.IsCompleted)
				{
					num = 1;
					$State = 1;
					$A1 = awaiter2;
					$Builder.AwaitUnsafeOnCompleted(ref awaiter2, ref this);
					return;
				}
				goto IL_0142;
				IL_0142:
				string result2 = awaiter2.GetResult();
				awaiter2 = default(TaskAwaiter<string>);
				result3 = result2;
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
			$Builder.SetResult(result3);
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

		static VB$StateMachine_3_SendRequestAsync()
		{
			Class72.smethod_20();
		}
	}

	private static readonly HttpClient client;

	static HttpClientHelper()
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		Class72.smethod_20();
		client = new HttpClient();
	}

	[AsyncStateMachine(typeof(VB$StateMachine_3_SendRequestAsync))]
	public static Task<string> SendRequestAsync(string method, string url, string body = "", string AuthToken = "")
	{
		VB$StateMachine_3_SendRequestAsync stateMachine = default(VB$StateMachine_3_SendRequestAsync);
		stateMachine.$VB$Local_method = method;
		stateMachine.$VB$Local_url = url;
		stateMachine.$VB$Local_body = body;
		stateMachine.$VB$Local_AuthToken = AuthToken;
		stateMachine.$State = -1;
		stateMachine.$Builder = AsyncTaskMethodBuilder<string>.Create();
		stateMachine.$Builder.Start(ref stateMachine);
		return stateMachine.$Builder.Task;
	}
}
