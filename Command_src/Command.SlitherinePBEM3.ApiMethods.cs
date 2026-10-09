using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Command.SlitherinePBEM3.Models;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;

namespace Command.SlitherinePBEM3;

internal class ApiMethods
{
	private class SerialPayload
	{
		public string SerialNum;

		public int GameID;

		static SerialPayload()
		{
			Class72.smethod_20();
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct VB$StateMachine_10_LoginNoSerialAsync : IAsyncStateMachine
	{
		public int $State;

		public AsyncTaskMethodBuilder<GeneralResponseModel<LoginModel>> $Builder;

		internal string $VB$Local_baseUrl;

		internal string $VB$Local_username;

		internal string $VB$Local_password;

		internal TaskAwaiter<string> $A0;

		[CompilerGenerated]
		internal void MoveNext()
		{
			int num = $State;
			GeneralResponseModel<LoginModel> result2;
			try
			{
				TaskAwaiter<string> awaiter;
				if (num != 0)
				{
					string url = $VB$Local_baseUrl + "/ws/authentication/login/noserial";
					VB$AnonymousType_4<string, string, int, int> value = new VB$AnonymousType_4<string, string, int, int>($VB$Local_username, $VB$Local_password, 353, 0);
					awaiter = HttpClientHelper.SendRequestAsync("POST", url, JsonConvert.SerializeObject(value)).GetAwaiter();
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
				GeneralResponseModel<LoginModel> generalResponseModel = JsonConvert.DeserializeObject<GeneralResponseModel<LoginModel>>(result);
				if (generalResponseModel != null)
				{
					generalResponseModel.Result.Password = $VB$Local_password;
				}
				result2 = generalResponseModel;
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

		static VB$StateMachine_10_LoginNoSerialAsync()
		{
			Class72.smethod_20();
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct VB$StateMachine_11_CreateChallengeAsync : IAsyncStateMachine
	{
		public int $State;

		public AsyncTaskMethodBuilder<GeneralResponseModel<int>> $Builder;

		internal string $VB$Local_baseUrl;

		internal LoginModel $VB$Local_creator;

		internal TaskAwaiter<GeneralResponseModel<LoginModel>> $A0;

		internal TaskAwaiter<string> $A1;

		[CompilerGenerated]
		internal void MoveNext()
		{
			int num = $State;
			GeneralResponseModel<int> result3;
			try
			{
				TaskAwaiter<GeneralResponseModel<LoginModel>> awaiter2;
				TaskAwaiter<string> awaiter;
				if (num != 0)
				{
					if (num == 1)
					{
						num = -1;
						$State = -1;
						awaiter = $A1;
						$A1 = default(TaskAwaiter<string>);
						goto IL_012d;
					}
					if (!$VB$Local_creator.HasTokenExpired())
					{
						goto IL_00cf;
					}
					awaiter2 = LoginNoSerialAsync($VB$Local_baseUrl, $VB$Local_creator.Username, $VB$Local_creator.Password).GetAwaiter();
					if (!awaiter2.IsCompleted)
					{
						num = 0;
						$State = 0;
						$A0 = awaiter2;
						$Builder.AwaitUnsafeOnCompleted(ref awaiter2, ref this);
						return;
					}
				}
				else
				{
					num = -1;
					$State = -1;
					awaiter2 = $A0;
					$A0 = default(TaskAwaiter<GeneralResponseModel<LoginModel>>);
				}
				GeneralResponseModel<LoginModel> result = awaiter2.GetResult();
				awaiter2 = default(TaskAwaiter<GeneralResponseModel<LoginModel>>);
				$VB$Local_creator = result.Result;
				goto IL_00cf;
				IL_012d:
				string result2 = awaiter.GetResult();
				awaiter = default(TaskAwaiter<string>);
				result3 = JsonConvert.DeserializeObject<GeneralResponseModel<int>>(result2);
				goto end_IL_0007;
				IL_00cf:
				string url = $VB$Local_baseUrl + "/ws/challenges/create";
				VB$AnonymousType_5<string, string, bool, int, int, int, int, int, int, string, bool> value = new VB$AnonymousType_5<string, string, bool, int, int, int, int, int, int, string, bool>("PBEM3_TEST_PASSWORD", "TestChallenge", Paired: false, 0, 353, 2, 2, 0, 0, "QQ==", Ranked: false);
				awaiter = HttpClientHelper.SendRequestAsync("POST", url, JsonConvert.SerializeObject(value), $VB$Local_creator.Token).GetAwaiter();
				if (!awaiter.IsCompleted)
				{
					num = 1;
					$State = 1;
					$A1 = awaiter;
					$Builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
					return;
				}
				goto IL_012d;
				end_IL_0007:;
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

		static VB$StateMachine_11_CreateChallengeAsync()
		{
			Class72.smethod_20();
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct VB$StateMachine_12_JoinChallengeAsync : IAsyncStateMachine
	{
		public int $State;

		public AsyncTaskMethodBuilder<GeneralResponseModel<bool>> $Builder;

		internal string $VB$Local_baseUrl;

		internal LoginModel $VB$Local_joiner;

		internal int $VB$Local_challengeId;

		internal TaskAwaiter<GeneralResponseModel<LoginModel>> $A0;

		internal TaskAwaiter<string> $A1;

		[CompilerGenerated]
		internal void MoveNext()
		{
			int num = $State;
			GeneralResponseModel<bool> result3;
			try
			{
				TaskAwaiter<GeneralResponseModel<LoginModel>> awaiter2;
				TaskAwaiter<string> awaiter;
				if (num != 0)
				{
					if (num == 1)
					{
						num = -1;
						$State = -1;
						awaiter = $A1;
						$A1 = default(TaskAwaiter<string>);
						goto IL_012e;
					}
					if (!$VB$Local_joiner.HasTokenExpired())
					{
						goto IL_00d5;
					}
					awaiter2 = LoginNoSerialAsync($VB$Local_baseUrl, $VB$Local_joiner.Username, $VB$Local_joiner.Password).GetAwaiter();
					if (!awaiter2.IsCompleted)
					{
						num = 0;
						$State = 0;
						$A0 = awaiter2;
						$Builder.AwaitUnsafeOnCompleted(ref awaiter2, ref this);
						return;
					}
				}
				else
				{
					num = -1;
					$State = -1;
					awaiter2 = $A0;
					$A0 = default(TaskAwaiter<GeneralResponseModel<LoginModel>>);
				}
				GeneralResponseModel<LoginModel> result = awaiter2.GetResult();
				awaiter2 = default(TaskAwaiter<GeneralResponseModel<LoginModel>>);
				$VB$Local_joiner = result.Result;
				goto IL_00d5;
				IL_012e:
				string result2 = awaiter.GetResult();
				awaiter = default(TaskAwaiter<string>);
				result3 = JsonConvert.DeserializeObject<GeneralResponseModel<bool>>(result2);
				goto end_IL_0008;
				IL_00d5:
				string url = $VB$Local_baseUrl + "/ws/challenges/accept";
				VB$AnonymousType_6<int, int, string, string, string> value = new VB$AnonymousType_6<int, int, string, string, string>($VB$Local_challengeId, 1, "PBEM3_TEST_PASSWORD", "", "");
				awaiter = HttpClientHelper.SendRequestAsync("POST", url, JsonConvert.SerializeObject(value), $VB$Local_joiner.Token).GetAwaiter();
				if (!awaiter.IsCompleted)
				{
					num = 1;
					$State = 1;
					$A1 = awaiter;
					$Builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
					return;
				}
				goto IL_012e;
				end_IL_0008:;
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

		static VB$StateMachine_12_JoinChallengeAsync()
		{
			Class72.smethod_20();
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct VB$StateMachine_13_ListInstancesAsync : IAsyncStateMachine
	{
		public int $State;

		public AsyncTaskMethodBuilder<GeneralResponseModel<List<InstanceModel>>> $Builder;

		internal string $VB$Local_baseUrl;

		internal LoginModel $VB$Local_lister;

		internal TaskAwaiter<GeneralResponseModel<LoginModel>> $A0;

		internal TaskAwaiter<string> $A1;

		[CompilerGenerated]
		internal void MoveNext()
		{
			int num = $State;
			GeneralResponseModel<List<InstanceModel>> result3;
			try
			{
				TaskAwaiter<GeneralResponseModel<LoginModel>> awaiter;
				TaskAwaiter<string> awaiter2;
				if (num == 0)
				{
					num = -1;
					$State = -1;
					awaiter = $A0;
					$A0 = default(TaskAwaiter<GeneralResponseModel<LoginModel>>);
				}
				else
				{
					if (num == 1)
					{
						num = -1;
						$State = -1;
						awaiter2 = $A1;
						$A1 = default(TaskAwaiter<string>);
						goto IL_0125;
					}
					if (!$VB$Local_lister.HasTokenExpired())
					{
						goto IL_00ab;
					}
					awaiter = LoginNoSerialAsync($VB$Local_baseUrl, $VB$Local_lister.Username, $VB$Local_lister.Password).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = 0;
						$State = 0;
						$A0 = awaiter;
						$Builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
						return;
					}
				}
				GeneralResponseModel<LoginModel> result = awaiter.GetResult();
				awaiter = default(TaskAwaiter<GeneralResponseModel<LoginModel>>);
				$VB$Local_lister = result.Result;
				goto IL_00ab;
				IL_0125:
				string result2 = awaiter2.GetResult();
				awaiter2 = default(TaskAwaiter<string>);
				result3 = JsonConvert.DeserializeObject<GeneralResponseModel<List<InstanceModel>>>(result2);
				goto end_IL_0007;
				IL_00ab:
				string url = $VB$Local_baseUrl + "/ws/instances/list";
				awaiter2 = HttpClientHelper.SendRequestAsync("GET", url, "", $VB$Local_lister.Token).GetAwaiter();
				if (!awaiter2.IsCompleted)
				{
					num = 1;
					$State = 1;
					$A1 = awaiter2;
					$Builder.AwaitUnsafeOnCompleted(ref awaiter2, ref this);
					return;
				}
				goto IL_0125;
				end_IL_0007:;
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

		static VB$StateMachine_13_ListInstancesAsync()
		{
			Class72.smethod_20();
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct VB$StateMachine_14_ListChallengesAsync : IAsyncStateMachine
	{
		public int $State;

		public AsyncTaskMethodBuilder<GeneralResponseModel<List<ChallengeModel>>> $Builder;

		internal string $VB$Local_baseUrl;

		internal LoginModel $VB$Local_lister;

		internal TaskAwaiter<GeneralResponseModel<LoginModel>> $A0;

		internal TaskAwaiter<string> $A1;

		[CompilerGenerated]
		internal void MoveNext()
		{
			int num = $State;
			GeneralResponseModel<List<ChallengeModel>> result3;
			try
			{
				TaskAwaiter<GeneralResponseModel<LoginModel>> awaiter2;
				TaskAwaiter<string> awaiter;
				if (num != 0)
				{
					if (num == 1)
					{
						num = -1;
						$State = -1;
						awaiter = $A1;
						$A1 = default(TaskAwaiter<string>);
						goto IL_0105;
					}
					if (!$VB$Local_lister.HasTokenExpired())
					{
						goto IL_00c9;
					}
					awaiter2 = LoginNoSerialAsync($VB$Local_baseUrl, $VB$Local_lister.Username, $VB$Local_lister.Password).GetAwaiter();
					if (!awaiter2.IsCompleted)
					{
						num = 0;
						$State = 0;
						$A0 = awaiter2;
						$Builder.AwaitUnsafeOnCompleted(ref awaiter2, ref this);
						return;
					}
				}
				else
				{
					num = -1;
					$State = -1;
					awaiter2 = $A0;
					$A0 = default(TaskAwaiter<GeneralResponseModel<LoginModel>>);
				}
				GeneralResponseModel<LoginModel> result = awaiter2.GetResult();
				awaiter2 = default(TaskAwaiter<GeneralResponseModel<LoginModel>>);
				$VB$Local_lister = result.Result;
				goto IL_00c9;
				IL_0105:
				string result2 = awaiter.GetResult();
				awaiter = default(TaskAwaiter<string>);
				result3 = JsonConvert.DeserializeObject<GeneralResponseModel<List<ChallengeModel>>>(result2);
				goto end_IL_0007;
				IL_00c9:
				string url = $VB$Local_baseUrl + "/ws/challenges/list";
				awaiter = HttpClientHelper.SendRequestAsync("GET", url, "", $VB$Local_lister.Token).GetAwaiter();
				if (!awaiter.IsCompleted)
				{
					num = 1;
					$State = 1;
					$A1 = awaiter;
					$Builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
					return;
				}
				goto IL_0105;
				end_IL_0007:;
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

		static VB$StateMachine_14_ListChallengesAsync()
		{
			Class72.smethod_20();
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct VB$StateMachine_15_ListTCPRoutingServers : IAsyncStateMachine
	{
		public int $State;

		public AsyncTaskMethodBuilder<GeneralResponseModel<List<RoutingServerModel>>> $Builder;

		internal string $VB$Local_baseUrl;

		internal LoginModel $VB$Local_lister;

		internal TaskAwaiter<GeneralResponseModel<LoginModel>> $A0;

		internal TaskAwaiter<string> $A1;

		[CompilerGenerated]
		internal void MoveNext()
		{
			int num = $State;
			GeneralResponseModel<List<RoutingServerModel>> result3;
			try
			{
				TaskAwaiter<GeneralResponseModel<LoginModel>> awaiter2;
				TaskAwaiter<string> awaiter;
				if (num != 0)
				{
					if (num == 1)
					{
						num = -1;
						$State = -1;
						awaiter = $A1;
						$A1 = default(TaskAwaiter<string>);
						goto IL_0105;
					}
					if (!$VB$Local_lister.HasTokenExpired())
					{
						goto IL_00c9;
					}
					awaiter2 = LoginNoSerialAsync($VB$Local_baseUrl, $VB$Local_lister.Username, $VB$Local_lister.Password).GetAwaiter();
					if (!awaiter2.IsCompleted)
					{
						num = 0;
						$State = 0;
						$A0 = awaiter2;
						$Builder.AwaitUnsafeOnCompleted(ref awaiter2, ref this);
						return;
					}
				}
				else
				{
					num = -1;
					$State = -1;
					awaiter2 = $A0;
					$A0 = default(TaskAwaiter<GeneralResponseModel<LoginModel>>);
				}
				GeneralResponseModel<LoginModel> result = awaiter2.GetResult();
				awaiter2 = default(TaskAwaiter<GeneralResponseModel<LoginModel>>);
				$VB$Local_lister = result.Result;
				goto IL_00c9;
				IL_0105:
				string result2 = awaiter.GetResult();
				awaiter = default(TaskAwaiter<string>);
				result3 = JsonConvert.DeserializeObject<GeneralResponseModel<List<RoutingServerModel>>>(result2);
				goto end_IL_0007;
				IL_00c9:
				string url = $VB$Local_baseUrl + "/ws/tcpservers/list";
				awaiter = HttpClientHelper.SendRequestAsync("GET", url, "", $VB$Local_lister.Token).GetAwaiter();
				if (!awaiter.IsCompleted)
				{
					num = 1;
					$State = 1;
					$A1 = awaiter;
					$Builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
					return;
				}
				goto IL_0105;
				end_IL_0007:;
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

		static VB$StateMachine_15_ListTCPRoutingServers()
		{
			Class72.smethod_20();
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct VB$StateMachine_2_GetFQDNAddressAsync : IAsyncStateMachine
	{
		public int $State;

		public AsyncTaskMethodBuilder<string> $Builder;

		internal TaskAwaiter<string> $A0;

		[CompilerGenerated]
		internal void MoveNext()
		{
			int num = $State;
			string fQDN;
			try
			{
				TaskAwaiter<string> awaiter;
				if (num == 0)
				{
					num = -1;
					$State = -1;
					awaiter = $A0;
					$A0 = default(TaskAwaiter<string>);
				}
				else
				{
					string url = "https://pbemregistry.slitherine.com/ws/domains/list/2/" + 353;
					awaiter = HttpClientHelper.SendRequestAsync("GET", url).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = 0;
						$State = 0;
						$A0 = awaiter;
						$Builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
						return;
					}
				}
				string result = awaiter.GetResult();
				awaiter = default(TaskAwaiter<string>);
				fQDN = JsonConvert.DeserializeObject<GeneralResponseModel<List<PBEMAddressModel>>>(result).Result[0].FQDN;
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
			$Builder.SetResult(fQDN);
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

		static VB$StateMachine_2_GetFQDNAddressAsync()
		{
			Class72.smethod_20();
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct VB$StateMachine_3_CheckGameVersionAsync : IAsyncStateMachine
	{
		public int $State;

		public AsyncTaskMethodBuilder<GeneralResponseModel<GameVersionModel>> $Builder;

		internal string $VB$Local_baseUrl;

		internal TaskAwaiter<string> $A0;

		[CompilerGenerated]
		internal void MoveNext()
		{
			int num = $State;
			GeneralResponseModel<GameVersionModel> result2;
			try
			{
				TaskAwaiter<string> awaiter;
				if (num == 0)
				{
					num = -1;
					$State = -1;
					awaiter = $A0;
					$A0 = default(TaskAwaiter<string>);
				}
				else
				{
					string url = $VB$Local_baseUrl + "/ws/about/gameversion/" + 353;
					awaiter = HttpClientHelper.SendRequestAsync("GET", url).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = 0;
						$State = 0;
						$A0 = awaiter;
						$Builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
						return;
					}
				}
				string result = awaiter.GetResult();
				awaiter = default(TaskAwaiter<string>);
				result2 = JsonConvert.DeserializeObject<GeneralResponseModel<GameVersionModel>>(result);
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

		static VB$StateMachine_3_CheckGameVersionAsync()
		{
			Class72.smethod_20();
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct VB$StateMachine_5_VerifySerialAsync : IAsyncStateMachine
	{
		public int $State;

		public AsyncTaskMethodBuilder<GeneralResponseModel<List<SerialVerificationModel>>> $Builder;

		internal string $VB$Local_baseUrl;

		internal string $VB$Local_serial;

		internal TaskAwaiter<string> $A0;

		[CompilerGenerated]
		internal void MoveNext()
		{
			int num = $State;
			GeneralResponseModel<List<SerialVerificationModel>> result2;
			try
			{
				TaskAwaiter<string> awaiter;
				if (num == 0)
				{
					num = -1;
					$State = -1;
					awaiter = $A0;
					$A0 = default(TaskAwaiter<string>);
				}
				else
				{
					string url = $VB$Local_baseUrl + "/ws/authentication/serials";
					SerialPayload item = new SerialPayload
					{
						SerialNum = $VB$Local_serial,
						GameID = 353
					};
					awaiter = HttpClientHelper.SendRequestAsync("POST", url, JsonConvert.SerializeObject(new List<SerialPayload> { item })).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = 0;
						$State = 0;
						$A0 = awaiter;
						$Builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
						return;
					}
				}
				string result = awaiter.GetResult();
				awaiter = default(TaskAwaiter<string>);
				result2 = JsonConvert.DeserializeObject<GeneralResponseModel<List<SerialVerificationModel>>>(result);
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

		static VB$StateMachine_5_VerifySerialAsync()
		{
			Class72.smethod_20();
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct VB$StateMachine_6_RegisterAsync : IAsyncStateMachine
	{
		public int $State;

		public AsyncTaskMethodBuilder<GeneralResponseModel<int>> $Builder;

		internal string $VB$Local_baseUrl;

		internal string $VB$Local_username;

		internal string $VB$Local_password;

		internal string $VB$Local_email;

		internal TaskAwaiter<string> $A0;

		[CompilerGenerated]
		internal void MoveNext()
		{
			int num = $State;
			GeneralResponseModel<int> result2;
			try
			{
				TaskAwaiter<string> awaiter;
				if (num != 0)
				{
					string url = $VB$Local_baseUrl + "/ws/authentication/register";
					VB$AnonymousType_0<string, string, string> value = new VB$AnonymousType_0<string, string, string>($VB$Local_username, $VB$Local_password, $VB$Local_email);
					awaiter = HttpClientHelper.SendRequestAsync("POST", url, JsonConvert.SerializeObject(value)).GetAwaiter();
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
				result2 = JsonConvert.DeserializeObject<GeneralResponseModel<int>>(result);
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

		static VB$StateMachine_6_RegisterAsync()
		{
			Class72.smethod_20();
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct VB$StateMachine_7_LoginAsync : IAsyncStateMachine
	{
		public int $State;

		public AsyncTaskMethodBuilder<GeneralResponseModel<LoginModel>> $Builder;

		internal string $VB$Local_baseUrl;

		internal string $VB$Local_serial;

		internal string $VB$Local_username;

		internal string $VB$Local_password;

		internal TaskAwaiter<string> $A0;

		[CompilerGenerated]
		internal void MoveNext()
		{
			int num = $State;
			GeneralResponseModel<LoginModel> result2;
			try
			{
				TaskAwaiter<string> awaiter;
				if (num != 0)
				{
					string url = $VB$Local_baseUrl + "/ws/authentication/login";
					VB$AnonymousType_1<string, string, string, int, int> value = new VB$AnonymousType_1<string, string, string, int, int>($VB$Local_username, $VB$Local_password, $VB$Local_serial, 353, 0);
					awaiter = HttpClientHelper.SendRequestAsync("POST", url, JsonConvert.SerializeObject(value)).GetAwaiter();
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
				GeneralResponseModel<LoginModel> generalResponseModel = JsonConvert.DeserializeObject<GeneralResponseModel<LoginModel>>(result);
				if (generalResponseModel != null && generalResponseModel.Result != null)
				{
					generalResponseModel.Result.Password = $VB$Local_password;
				}
				result2 = generalResponseModel;
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

		static VB$StateMachine_7_LoginAsync()
		{
			Class72.smethod_20();
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct VB$StateMachine_8_RegisterSteamAsync : IAsyncStateMachine
	{
		public int $State;

		public AsyncTaskMethodBuilder<GeneralResponseModel<int>> $Builder;

		internal string $VB$Local_baseUrl;

		internal string $VB$Local_username;

		internal string $VB$Local_password;

		internal string $VB$Local_email;

		internal string $VB$Local_steamToken;

		internal TaskAwaiter<string> $A0;

		[CompilerGenerated]
		internal void MoveNext()
		{
			int num = $State;
			GeneralResponseModel<int> result2;
			try
			{
				TaskAwaiter<string> awaiter;
				if (num != 0)
				{
					string url = $VB$Local_baseUrl + "/ws/authentication/steam/register";
					VB$AnonymousType_2<string, string, string, string, int, int> value = new VB$AnonymousType_2<string, string, string, string, int, int>($VB$Local_username, $VB$Local_password, $VB$Local_email, $VB$Local_steamToken, 353, 0);
					awaiter = HttpClientHelper.SendRequestAsync("POST", url, JsonConvert.SerializeObject(value)).GetAwaiter();
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
				result2 = JsonConvert.DeserializeObject<GeneralResponseModel<int>>(result);
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

		static VB$StateMachine_8_RegisterSteamAsync()
		{
			Class72.smethod_20();
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct VB$StateMachine_9_LoginSteamAsync : IAsyncStateMachine
	{
		public int $State;

		public AsyncTaskMethodBuilder<GeneralResponseModel<LoginModel>> $Builder;

		internal string $VB$Local_baseUrl;

		internal string $VB$Local_steamToken;

		internal string $VB$Local_username;

		internal string $VB$Local_password;

		internal TaskAwaiter<string> $A0;

		[CompilerGenerated]
		internal void MoveNext()
		{
			int num = $State;
			GeneralResponseModel<LoginModel> result2;
			try
			{
				TaskAwaiter<string> awaiter;
				if (num == 0)
				{
					num = -1;
					$State = -1;
					awaiter = $A0;
					$A0 = default(TaskAwaiter<string>);
				}
				else
				{
					string url = $VB$Local_baseUrl + "/ws/authentication/steam/login";
					VB$AnonymousType_3<string, string, string, int, int> value = new VB$AnonymousType_3<string, string, string, int, int>($VB$Local_username, $VB$Local_password, $VB$Local_steamToken, 353, 0);
					awaiter = HttpClientHelper.SendRequestAsync("POST", url, JsonConvert.SerializeObject(value)).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = 0;
						$State = 0;
						$A0 = awaiter;
						$Builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
						return;
					}
				}
				string result = awaiter.GetResult();
				awaiter = default(TaskAwaiter<string>);
				GeneralResponseModel<LoginModel> generalResponseModel = JsonConvert.DeserializeObject<GeneralResponseModel<LoginModel>>(result);
				if (generalResponseModel != null)
				{
					generalResponseModel.Result.Password = $VB$Local_password;
				}
				result2 = generalResponseModel;
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

		static VB$StateMachine_9_LoginSteamAsync()
		{
			Class72.smethod_20();
		}
	}

	public const int ProductId = 353;

	[AsyncStateMachine(typeof(VB$StateMachine_2_GetFQDNAddressAsync))]
	public static Task<string> smethod_0()
	{
		VB$StateMachine_2_GetFQDNAddressAsync stateMachine = default(VB$StateMachine_2_GetFQDNAddressAsync);
		stateMachine.$State = -1;
		stateMachine.$Builder = AsyncTaskMethodBuilder<string>.Create();
		stateMachine.$Builder.Start(ref stateMachine);
		return stateMachine.$Builder.Task;
	}

	[AsyncStateMachine(typeof(VB$StateMachine_3_CheckGameVersionAsync))]
	public static Task<GeneralResponseModel<GameVersionModel>> CheckGameVersionAsync(string baseUrl)
	{
		VB$StateMachine_3_CheckGameVersionAsync stateMachine = default(VB$StateMachine_3_CheckGameVersionAsync);
		stateMachine.$VB$Local_baseUrl = baseUrl;
		stateMachine.$State = -1;
		stateMachine.$Builder = AsyncTaskMethodBuilder<GeneralResponseModel<GameVersionModel>>.Create();
		stateMachine.$Builder.Start(ref stateMachine);
		return stateMachine.$Builder.Task;
	}

	[AsyncStateMachine(typeof(VB$StateMachine_5_VerifySerialAsync))]
	public static Task<GeneralResponseModel<List<SerialVerificationModel>>> VerifySerialAsync(string baseUrl, string serial)
	{
		VB$StateMachine_5_VerifySerialAsync stateMachine = default(VB$StateMachine_5_VerifySerialAsync);
		stateMachine.$VB$Local_baseUrl = baseUrl;
		stateMachine.$VB$Local_serial = serial;
		stateMachine.$State = -1;
		stateMachine.$Builder = AsyncTaskMethodBuilder<GeneralResponseModel<List<SerialVerificationModel>>>.Create();
		stateMachine.$Builder.Start(ref stateMachine);
		return stateMachine.$Builder.Task;
	}

	[AsyncStateMachine(typeof(VB$StateMachine_6_RegisterAsync))]
	public static Task<GeneralResponseModel<int>> RegisterAsync(string baseUrl, string username, string password, string email)
	{
		VB$StateMachine_6_RegisterAsync stateMachine = default(VB$StateMachine_6_RegisterAsync);
		stateMachine.$VB$Local_baseUrl = baseUrl;
		stateMachine.$VB$Local_username = username;
		stateMachine.$VB$Local_password = password;
		stateMachine.$VB$Local_email = email;
		stateMachine.$State = -1;
		stateMachine.$Builder = AsyncTaskMethodBuilder<GeneralResponseModel<int>>.Create();
		stateMachine.$Builder.Start(ref stateMachine);
		return stateMachine.$Builder.Task;
	}

	[AsyncStateMachine(typeof(VB$StateMachine_7_LoginAsync))]
	public static Task<GeneralResponseModel<LoginModel>> LoginAsync(string baseUrl, string serial, string username, string password)
	{
		VB$StateMachine_7_LoginAsync stateMachine = default(VB$StateMachine_7_LoginAsync);
		stateMachine.$VB$Local_baseUrl = baseUrl;
		stateMachine.$VB$Local_serial = serial;
		stateMachine.$VB$Local_username = username;
		stateMachine.$VB$Local_password = password;
		stateMachine.$State = -1;
		stateMachine.$Builder = AsyncTaskMethodBuilder<GeneralResponseModel<LoginModel>>.Create();
		stateMachine.$Builder.Start(ref stateMachine);
		return stateMachine.$Builder.Task;
	}

	[AsyncStateMachine(typeof(VB$StateMachine_8_RegisterSteamAsync))]
	public static Task<GeneralResponseModel<int>> RegisterSteamAsync(string baseUrl, string username, string password, string email, string steamToken)
	{
		VB$StateMachine_8_RegisterSteamAsync stateMachine = default(VB$StateMachine_8_RegisterSteamAsync);
		stateMachine.$VB$Local_baseUrl = baseUrl;
		stateMachine.$VB$Local_username = username;
		stateMachine.$VB$Local_password = password;
		stateMachine.$VB$Local_email = email;
		stateMachine.$VB$Local_steamToken = steamToken;
		stateMachine.$State = -1;
		stateMachine.$Builder = AsyncTaskMethodBuilder<GeneralResponseModel<int>>.Create();
		stateMachine.$Builder.Start(ref stateMachine);
		return stateMachine.$Builder.Task;
	}

	[AsyncStateMachine(typeof(VB$StateMachine_9_LoginSteamAsync))]
	public static Task<GeneralResponseModel<LoginModel>> LoginSteamAsync(string baseUrl, string steamToken, string username, string password)
	{
		VB$StateMachine_9_LoginSteamAsync stateMachine = default(VB$StateMachine_9_LoginSteamAsync);
		stateMachine.$VB$Local_baseUrl = baseUrl;
		stateMachine.$VB$Local_steamToken = steamToken;
		stateMachine.$VB$Local_username = username;
		stateMachine.$VB$Local_password = password;
		stateMachine.$State = -1;
		stateMachine.$Builder = AsyncTaskMethodBuilder<GeneralResponseModel<LoginModel>>.Create();
		stateMachine.$Builder.Start(ref stateMachine);
		return stateMachine.$Builder.Task;
	}

	[AsyncStateMachine(typeof(VB$StateMachine_10_LoginNoSerialAsync))]
	public static Task<GeneralResponseModel<LoginModel>> LoginNoSerialAsync(string baseUrl, string username, string password)
	{
		VB$StateMachine_10_LoginNoSerialAsync stateMachine = default(VB$StateMachine_10_LoginNoSerialAsync);
		stateMachine.$VB$Local_baseUrl = baseUrl;
		stateMachine.$VB$Local_username = username;
		stateMachine.$VB$Local_password = password;
		stateMachine.$State = -1;
		stateMachine.$Builder = AsyncTaskMethodBuilder<GeneralResponseModel<LoginModel>>.Create();
		stateMachine.$Builder.Start(ref stateMachine);
		return stateMachine.$Builder.Task;
	}

	[AsyncStateMachine(typeof(VB$StateMachine_11_CreateChallengeAsync))]
	public static Task<GeneralResponseModel<int>> CreateChallengeAsync(string baseUrl, LoginModel creator)
	{
		VB$StateMachine_11_CreateChallengeAsync stateMachine = default(VB$StateMachine_11_CreateChallengeAsync);
		stateMachine.$VB$Local_baseUrl = baseUrl;
		stateMachine.$VB$Local_creator = creator;
		stateMachine.$State = -1;
		stateMachine.$Builder = AsyncTaskMethodBuilder<GeneralResponseModel<int>>.Create();
		stateMachine.$Builder.Start(ref stateMachine);
		return stateMachine.$Builder.Task;
	}

	[AsyncStateMachine(typeof(VB$StateMachine_12_JoinChallengeAsync))]
	public static Task<GeneralResponseModel<bool>> JoinChallengeAsync(string baseUrl, LoginModel joiner, int challengeId)
	{
		VB$StateMachine_12_JoinChallengeAsync stateMachine = default(VB$StateMachine_12_JoinChallengeAsync);
		stateMachine.$VB$Local_baseUrl = baseUrl;
		stateMachine.$VB$Local_joiner = joiner;
		stateMachine.$VB$Local_challengeId = challengeId;
		stateMachine.$State = -1;
		stateMachine.$Builder = AsyncTaskMethodBuilder<GeneralResponseModel<bool>>.Create();
		stateMachine.$Builder.Start(ref stateMachine);
		return stateMachine.$Builder.Task;
	}

	[AsyncStateMachine(typeof(VB$StateMachine_13_ListInstancesAsync))]
	public static Task<GeneralResponseModel<List<InstanceModel>>> ListInstancesAsync(string baseUrl, LoginModel lister)
	{
		VB$StateMachine_13_ListInstancesAsync stateMachine = default(VB$StateMachine_13_ListInstancesAsync);
		stateMachine.$VB$Local_baseUrl = baseUrl;
		stateMachine.$VB$Local_lister = lister;
		stateMachine.$State = -1;
		stateMachine.$Builder = AsyncTaskMethodBuilder<GeneralResponseModel<List<InstanceModel>>>.Create();
		stateMachine.$Builder.Start(ref stateMachine);
		return stateMachine.$Builder.Task;
	}

	[AsyncStateMachine(typeof(VB$StateMachine_14_ListChallengesAsync))]
	public static Task<GeneralResponseModel<List<ChallengeModel>>> ListChallengesAsync(string baseUrl, LoginModel lister)
	{
		VB$StateMachine_14_ListChallengesAsync stateMachine = default(VB$StateMachine_14_ListChallengesAsync);
		stateMachine.$VB$Local_baseUrl = baseUrl;
		stateMachine.$VB$Local_lister = lister;
		stateMachine.$State = -1;
		stateMachine.$Builder = AsyncTaskMethodBuilder<GeneralResponseModel<List<ChallengeModel>>>.Create();
		stateMachine.$Builder.Start(ref stateMachine);
		return stateMachine.$Builder.Task;
	}

	[AsyncStateMachine(typeof(VB$StateMachine_15_ListTCPRoutingServers))]
	public static Task<GeneralResponseModel<List<RoutingServerModel>>> ListTCPRoutingServers(string baseUrl, LoginModel lister)
	{
		VB$StateMachine_15_ListTCPRoutingServers stateMachine = default(VB$StateMachine_15_ListTCPRoutingServers);
		stateMachine.$VB$Local_baseUrl = baseUrl;
		stateMachine.$VB$Local_lister = lister;
		stateMachine.$State = -1;
		stateMachine.$Builder = AsyncTaskMethodBuilder<GeneralResponseModel<List<RoutingServerModel>>>.Create();
		stateMachine.$Builder.Start(ref stateMachine);
		return stateMachine.$Builder.Task;
	}

	static ApiMethods()
	{
		Class72.smethod_20();
	}
}
