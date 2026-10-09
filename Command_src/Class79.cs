using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;

internal class Class79
{
	[StructLayout(LayoutKind.Explicit)]
	public struct Struct74
	{
		[FieldOffset(0)]
		public byte byte_0;

		[FieldOffset(0)]
		public sbyte sbyte_0;

		[FieldOffset(0)]
		public ushort ushort_0;

		[FieldOffset(0)]
		public short short_0;

		[FieldOffset(0)]
		public uint uint_0;

		[FieldOffset(0)]
		public int int_0;
	}

	private class Class92 : Class91
	{
		public Struct74 struct74_0;

		public Enum23 enum23_0;

		internal override void vmethod_10(Class90 class90_0)
		{
			struct74_0 = ((Class92)class90_0).struct74_0;
			enum23_0 = ((Class92)class90_0).enum23_0;
		}

		internal override void vmethod_2(Class90 class90_0)
		{
			vmethod_10(class90_0);
		}

		public Class92(bool bool_0)
		{
			enum26_0 = (Enum26)1;
			if (!bool_0)
			{
				struct74_0.int_0 = 0;
			}
			else
			{
				struct74_0.int_0 = 1;
			}
			enum23_0 = (Enum23)11;
		}

		public Class92(Class92 class92_0)
		{
			enum26_0 = class92_0.enum26_0;
			struct74_0.int_0 = class92_0.struct74_0.int_0;
			enum23_0 = class92_0.enum23_0;
		}

		public override Class91 vmethod_73()
		{
			return new Class92(this);
		}

		public Class92(int int_0)
		{
			enum26_0 = (Enum26)1;
			struct74_0.int_0 = int_0;
			enum23_0 = (Enum23)5;
		}

		public Class92(uint uint_0)
		{
			enum26_0 = (Enum26)1;
			struct74_0.uint_0 = uint_0;
			enum23_0 = (Enum23)6;
		}

		public Class92(int int_0, Enum23 enum23_1)
		{
			enum26_0 = (Enum26)1;
			struct74_0.int_0 = int_0;
			enum23_0 = enum23_1;
		}

		public Class92(uint uint_0, Enum23 enum23_1)
		{
			enum26_0 = (Enum26)1;
			struct74_0.uint_0 = uint_0;
			enum23_0 = enum23_1;
		}

		public override bool vmethod_11()
		{
			switch (enum23_0)
			{
			default:
				return struct74_0.uint_0 == 0;
			case (Enum23)1:
			case (Enum23)3:
			case (Enum23)5:
			case (Enum23)7:
			case (Enum23)11:
			case (Enum23)15:
				return struct74_0.int_0 == 0;
			}
		}

		public override bool vmethod_12()
		{
			return !vmethod_11();
		}

		public override Class90 vmethod_13(Enum23 enum23_1)
		{
			int num;
			Enum27 @enum;
			switch (enum23_1)
			{
			default:
				num = 4;
				goto IL_007d;
			case (Enum23)1:
				return vmethod_15();
			case (Enum23)2:
				return vmethod_16();
			case (Enum23)3:
				return vmethod_17();
			case (Enum23)4:
				return vmethod_18();
			case (Enum23)5:
				return vmethod_19();
			case (Enum23)6:
				return vmethod_20();
			case (Enum23)11:
				return vmethod_14();
			case (Enum23)7:
			case (Enum23)8:
			case (Enum23)9:
			case (Enum23)10:
			case (Enum23)12:
			case (Enum23)13:
			case (Enum23)14:
				num = 4;
				goto IL_007d;
			case (Enum23)15:
				return method_6();
			case (Enum23)16:
				{
					return vmethod_73();
				}
				IL_007d:
				@enum = (Enum27)num;
				throw new Exception(@enum.ToString());
			}
		}

		internal override object vmethod_4(Type type_0)
		{
			if (type_0 != null && type_0.IsByRef)
			{
				type_0 = type_0.GetElementType();
			}
			if (type_0 != null && Nullable.GetUnderlyingType(type_0) != null)
			{
				type_0 = Nullable.GetUnderlyingType(type_0);
			}
			if (!(type_0 == null) && !(type_0 == typeof(object)))
			{
				if (!(type_0 == typeof(int)))
				{
					if (!(type_0 == typeof(uint)))
					{
						if (!(type_0 == typeof(short)))
						{
							if (type_0 == typeof(ushort))
							{
								return struct74_0.ushort_0;
							}
							if (type_0 == typeof(byte))
							{
								return struct74_0.byte_0;
							}
							if (type_0 == typeof(sbyte))
							{
								return struct74_0.sbyte_0;
							}
							if (!(type_0 == typeof(bool)))
							{
								if (!(type_0 == typeof(long)))
								{
									if (type_0 == typeof(ulong))
									{
										return (ulong)struct74_0.uint_0;
									}
									if (!(type_0 == typeof(char)))
									{
										if (!(type_0 == typeof(IntPtr)))
										{
											if (!(type_0 == typeof(UIntPtr)))
											{
												if (!type_0.IsEnum)
												{
													throw new Exception1();
												}
												return method_5(type_0);
											}
											return new UIntPtr(struct74_0.uint_0);
										}
										return new IntPtr(struct74_0.int_0);
									}
									return (char)struct74_0.int_0;
								}
								return (long)struct74_0.int_0;
							}
							return !vmethod_11();
						}
						return struct74_0.short_0;
					}
					return struct74_0.uint_0;
				}
				return struct74_0.int_0;
			}
			return enum23_0 switch
			{
				(Enum23)1 => struct74_0.sbyte_0, 
				(Enum23)2 => struct74_0.byte_0, 
				(Enum23)3 => struct74_0.short_0, 
				(Enum23)4 => struct74_0.ushort_0, 
				(Enum23)5 => struct74_0.int_0, 
				(Enum23)6 => struct74_0.uint_0, 
				(Enum23)7 => (long)struct74_0.int_0, 
				(Enum23)8 => (ulong)struct74_0.uint_0, 
				(Enum23)11 => vmethod_12(), 
				(Enum23)15 => (char)struct74_0.int_0, 
				_ => struct74_0.int_0, 
			};
		}

		internal object method_5(Type type_0)
		{
			Type underlyingType = Enum.GetUnderlyingType(type_0);
			if (underlyingType == typeof(int))
			{
				return Enum.ToObject(type_0, struct74_0.int_0);
			}
			if (underlyingType == typeof(uint))
			{
				return Enum.ToObject(type_0, struct74_0.uint_0);
			}
			if (!(underlyingType == typeof(short)))
			{
				if (underlyingType == typeof(ushort))
				{
					return Enum.ToObject(type_0, struct74_0.ushort_0);
				}
				if (underlyingType == typeof(byte))
				{
					return Enum.ToObject(type_0, struct74_0.byte_0);
				}
				if (!(underlyingType == typeof(sbyte)))
				{
					if (!(underlyingType == typeof(long)))
					{
						if (!(underlyingType == typeof(ulong)))
						{
							if (underlyingType == typeof(char))
							{
								return Enum.ToObject(type_0, (ushort)struct74_0.int_0);
							}
							return Enum.ToObject(type_0, struct74_0.int_0);
						}
						return Enum.ToObject(type_0, (ulong)struct74_0.uint_0);
					}
					return Enum.ToObject(type_0, (long)struct74_0.int_0);
				}
				return Enum.ToObject(type_0, struct74_0.sbyte_0);
			}
			return Enum.ToObject(type_0, struct74_0.short_0);
		}

		public override Class92 vmethod_14()
		{
			return new Class92((!vmethod_11()) ? 1 : 0);
		}

		internal override bool vmethod_7()
		{
			return vmethod_12();
		}

		public override Class92 vmethod_15()
		{
			return new Class92(struct74_0.sbyte_0, (Enum23)1);
		}

		public Class92 method_6()
		{
			return new Class92(struct74_0.int_0, (Enum23)15);
		}

		public override Class92 vmethod_16()
		{
			return new Class92((uint)struct74_0.byte_0, (Enum23)2);
		}

		public override Class92 vmethod_17()
		{
			return new Class92(struct74_0.short_0, (Enum23)3);
		}

		public override Class92 vmethod_18()
		{
			return new Class92((uint)struct74_0.ushort_0, (Enum23)4);
		}

		public override Class92 vmethod_19()
		{
			return new Class92(struct74_0.int_0, (Enum23)5);
		}

		public override Class92 vmethod_20()
		{
			return new Class92(struct74_0.uint_0, (Enum23)6);
		}

		public override Class93 vmethod_21()
		{
			return new Class93(struct74_0.int_0, (Enum23)7);
		}

		public override Class93 vmethod_22()
		{
			return new Class93((ulong)struct74_0.uint_0, (Enum23)8);
		}

		public override Class92 vmethod_23()
		{
			return vmethod_15();
		}

		public override Class92 vmethod_24()
		{
			return vmethod_17();
		}

		public override Class92 vmethod_25()
		{
			return vmethod_19();
		}

		public override Class93 vmethod_26()
		{
			return vmethod_21();
		}

		public override Class92 vmethod_27()
		{
			return vmethod_16();
		}

		public override Class92 vmethod_28()
		{
			return vmethod_18();
		}

		public override Class92 vmethod_29()
		{
			return vmethod_20();
		}

		public override Class93 vmethod_30()
		{
			return vmethod_22();
		}

		public override Class92 vmethod_31()
		{
			return new Class92(checked((sbyte)struct74_0.int_0), (Enum23)1);
		}

		public override Class92 vmethod_32()
		{
			return new Class92(checked((sbyte)struct74_0.uint_0), (Enum23)1);
		}

		public override Class92 vmethod_33()
		{
			return new Class92(checked((short)struct74_0.int_0), (Enum23)3);
		}

		public override Class92 vmethod_34()
		{
			return new Class92(checked((short)struct74_0.uint_0), (Enum23)3);
		}

		public override Class92 vmethod_35()
		{
			return new Class92(struct74_0.int_0, (Enum23)5);
		}

		public override Class92 vmethod_36()
		{
			return new Class92(checked((int)struct74_0.uint_0), (Enum23)5);
		}

		public override Class93 vmethod_37()
		{
			return new Class93(struct74_0.int_0, (Enum23)7);
		}

		public override Class93 vmethod_38()
		{
			return new Class93(struct74_0.uint_0, (Enum23)7);
		}

		public override Class92 vmethod_39()
		{
			return new Class92(checked((byte)struct74_0.int_0), (Enum23)2);
		}

		public override Class92 vmethod_40()
		{
			return new Class92(checked((byte)struct74_0.uint_0), (Enum23)2);
		}

		public override Class92 vmethod_41()
		{
			return new Class92(checked((ushort)struct74_0.int_0), (Enum23)4);
		}

		public override Class92 vmethod_42()
		{
			return new Class92(checked((ushort)struct74_0.uint_0), (Enum23)4);
		}

		public override Class92 vmethod_43()
		{
			return new Class92(checked((uint)struct74_0.int_0), (Enum23)6);
		}

		public override Class92 vmethod_44()
		{
			return new Class92(struct74_0.uint_0, (Enum23)6);
		}

		public override Class93 vmethod_45()
		{
			return new Class93(checked((ulong)struct74_0.int_0), (Enum23)8);
		}

		public override Class93 vmethod_46()
		{
			return new Class93((ulong)struct74_0.uint_0, (Enum23)8);
		}

		public override Class95 vmethod_47()
		{
			return new Class95(struct74_0.int_0);
		}

		public override Class95 vmethod_48()
		{
			return new Class95((double)struct74_0.int_0);
		}

		public override Class95 vmethod_49()
		{
			return new Class95((double)struct74_0.uint_0);
		}

		public override Class94 vmethod_50()
		{
			if (IntPtr.Size == 8)
			{
				return new Class94(vmethod_26().struct75_0.long_0);
			}
			return new Class94(vmethod_25().struct74_0.int_0);
		}

		public override Class94 vmethod_51()
		{
			if (IntPtr.Size == 8)
			{
				return new Class94(vmethod_30().struct75_0.ulong_0);
			}
			return new Class94((ulong)vmethod_29().struct74_0.uint_0);
		}

		public override Class94 vmethod_52()
		{
			if (IntPtr.Size == 8)
			{
				return new Class94(vmethod_37().struct75_0.long_0);
			}
			return new Class94(vmethod_35().struct74_0.int_0);
		}

		public override Class94 vmethod_53()
		{
			if (IntPtr.Size == 8)
			{
				return new Class94(vmethod_45().struct75_0.ulong_0);
			}
			return new Class94((ulong)vmethod_43().struct74_0.uint_0);
		}

		public override Class94 vmethod_54()
		{
			if (IntPtr.Size == 8)
			{
				return new Class94(vmethod_38().struct75_0.long_0);
			}
			return new Class94(vmethod_36().struct74_0.int_0);
		}

		public override Class94 vmethod_55()
		{
			if (IntPtr.Size == 8)
			{
				return new Class94(vmethod_46().struct75_0.ulong_0);
			}
			return new Class94((ulong)vmethod_44().struct74_0.uint_0);
		}

		public override Class90 vmethod_56()
		{
			int num = 2;
			while (true)
			{
				Enum23 @enum = enum23_0;
				while (true)
				{
					switch (@enum)
					{
					default:
						num = 10;
						while (true)
						{
							if (num != 10)
							{
								if (num == 991)
								{
									switch (num)
									{
									case 1:
										goto end_IL_002a;
									case 2:
										goto end_IL_0035;
									case 3:
										goto IL_005f;
									case 0:
										goto IL_007b;
									}
									continue;
								}
							}
							else if (@enum == (Enum23)11)
							{
								goto IL_007b;
							}
							goto IL_005f;
							IL_005f:
							if (@enum != (Enum23)15)
							{
								goto case (Enum23)2;
							}
							goto IL_007b;
							continue;
							end_IL_002a:
							break;
						}
						continue;
					case (Enum23)2:
					case (Enum23)4:
						return new Class92((int)(0L - (long)struct74_0.uint_0));
					case (Enum23)1:
					case (Enum23)3:
					case (Enum23)5:
						goto IL_007b;
						IL_007b:
						return new Class92(-struct74_0.int_0);
						end_IL_0035:
						break;
					}
					break;
				}
			}
		}

		public override Class90 Add(Class90 class90_0)
		{
			int num = 1;
			while (true)
			{
				IL_003a:
				if (class90_0.vmethod_0())
				{
					goto IL_0042;
				}
				num = 12;
				while (num != 12)
				{
					if (num != 993)
					{
						goto end_IL_003a;
					}
					switch (num)
					{
					case 1:
						goto IL_003a;
					case 5:
						goto IL_0042;
					case 4:
						goto end_IL_0032;
					case 0:
						goto IL_0052;
					case 2:
						goto IL_005a;
					case 3:
						goto end_IL_003a;
					}
					continue;
					end_IL_0032:
					break;
				}
				goto IL_004a;
				IL_0052:
				if (!class90_0.pgqjrkspy1())
				{
					throw new Exception1();
				}
				goto IL_005a;
				IL_005a:
				return ((Class94)class90_0).Add(this);
				IL_0042:
				class90_0 = class90_0.vmethod_8();
				goto IL_004a;
				IL_004a:
				if (class90_0.method_1())
				{
					break;
				}
				goto IL_0052;
				continue;
				end_IL_003a:
				break;
			}
			return new Class92(struct74_0.int_0 + ((Class92)class90_0).struct74_0.int_0);
		}

		public override Class90 vmethod_57(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (class90_0.method_1())
			{
				return new Class92(checked(struct74_0.int_0 + ((Class92)class90_0).struct74_0.int_0));
			}
			if (!class90_0.pgqjrkspy1())
			{
				throw new Exception1();
			}
			return ((Class94)class90_0).vmethod_57(this);
		}

		public override Class90 vmethod_58(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (!class90_0.method_1())
			{
				if (!class90_0.pgqjrkspy1())
				{
					throw new Exception1();
				}
				return ((Class94)class90_0).vmethod_58(this);
			}
			return new Class92(checked(struct74_0.uint_0 + ((Class92)class90_0).struct74_0.uint_0));
		}

		public override Class90 vmethod_59(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (!class90_0.method_1())
			{
				if (class90_0.pgqjrkspy1())
				{
					return ((Class94)class90_0).method_7(this);
				}
				throw new Exception1();
			}
			return new Class92(struct74_0.int_0 - ((Class92)class90_0).struct74_0.int_0);
		}

		public override Class90 vmethod_60(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (!class90_0.method_1())
			{
				if (!class90_0.pgqjrkspy1())
				{
					throw new Exception1();
				}
				return ((Class94)class90_0).method_8(this);
			}
			return new Class92(checked(struct74_0.int_0 - ((Class92)class90_0).struct74_0.int_0));
		}

		public override Class90 vmethod_61(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (!class90_0.method_1())
			{
				if (!class90_0.pgqjrkspy1())
				{
					throw new Exception1();
				}
				return ((Class94)class90_0).method_9(this);
			}
			return new Class92(checked(struct74_0.uint_0 - ((Class92)class90_0).struct74_0.uint_0));
		}

		public override Class90 vmethod_62(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (!class90_0.method_1())
			{
				if (class90_0.pgqjrkspy1())
				{
					return ((Class94)class90_0).vmethod_62(this);
				}
				throw new Exception1();
			}
			return new Class92(struct74_0.int_0 * ((Class92)class90_0).struct74_0.int_0);
		}

		public override Class90 vmethod_63(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (!class90_0.method_1())
			{
				if (!class90_0.pgqjrkspy1())
				{
					throw new Exception1();
				}
				return ((Class94)class90_0).vmethod_63(this);
			}
			return new Class92(checked(struct74_0.int_0 * ((Class92)class90_0).struct74_0.int_0));
		}

		public override Class90 vmethod_64(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (!class90_0.method_1())
			{
				if (!class90_0.pgqjrkspy1())
				{
					throw new Exception1();
				}
				return ((Class94)class90_0).vmethod_64(this);
			}
			return new Class92(checked(struct74_0.uint_0 * ((Class92)class90_0).struct74_0.uint_0));
		}

		public override Class90 vmethod_65(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (class90_0.method_1())
			{
				return new Class92(struct74_0.int_0 / ((Class92)class90_0).struct74_0.int_0);
			}
			if (!class90_0.pgqjrkspy1())
			{
				throw new Exception1();
			}
			return ((Class94)class90_0).method_10(this);
		}

		public override Class90 vmethod_66(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (!class90_0.method_1())
			{
				if (!class90_0.pgqjrkspy1())
				{
					throw new Exception1();
				}
				return ((Class94)class90_0).method_11(this);
			}
			return new Class92(struct74_0.uint_0 / ((Class92)class90_0).struct74_0.uint_0);
		}

		public override Class90 vmethod_67(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (class90_0.method_1())
			{
				return new Class92(struct74_0.int_0 % ((Class92)class90_0).struct74_0.int_0);
			}
			if (!class90_0.pgqjrkspy1())
			{
				throw new Exception1();
			}
			return ((Class94)class90_0).method_12(this);
		}

		public override Class90 vmethod_68(Class90 class90_0)
		{
			int num = 2;
			while (true)
			{
				IL_005e:
				if (!class90_0.vmethod_0())
				{
					goto IL_0049;
				}
				goto IL_0054;
				IL_0054:
				class90_0 = class90_0.vmethod_8();
				goto IL_0049;
				IL_0049:
				while (true)
				{
					IL_0049_2:
					if (!class90_0.method_1())
					{
						while (true)
						{
							IL_003e:
							if (!class90_0.pgqjrkspy1())
							{
								num = 13;
								while (true)
								{
									if (num != 13)
									{
										if (num != 994)
										{
											break;
										}
										switch (num)
										{
										case 6:
											goto IL_003e;
										case 0:
										case 1:
											goto IL_0049_2;
										case 4:
											goto end_IL_0049;
										case 2:
											goto IL_005e;
										case 3:
											goto IL_0069;
										case 5:
											goto end_IL_0036;
										}
										continue;
									}
									throw new Exception1();
									continue;
									end_IL_0036:
									break;
								}
								break;
							}
							goto IL_0069;
							IL_0069:
							return ((Class94)class90_0).method_13(this);
						}
					}
					return new Class92(struct74_0.uint_0 % ((Class92)class90_0).struct74_0.uint_0);
					continue;
					end_IL_0049:
					break;
				}
				goto IL_0054;
			}
		}

		public override Class90 vmethod_69(Class90 class90_0)
		{
			int num = 4;
			while (true)
			{
				IL_0053:
				if (!class90_0.vmethod_0())
				{
					goto IL_003e;
				}
				goto IL_0049;
				IL_0049:
				class90_0 = class90_0.vmethod_8();
				goto IL_003e;
				IL_003e:
				while (true)
				{
					IL_003e_2:
					if (!class90_0.method_1())
					{
						num = 13;
						while (true)
						{
							if (num != 13)
							{
								if (num != 994)
								{
									break;
								}
								switch (num)
								{
								case 3:
								case 5:
									goto IL_003e_2;
								case 6:
									goto end_IL_0036;
								case 4:
									goto IL_0053;
								case 2:
									goto IL_0066;
								case 0:
									goto IL_006c;
								case 1:
									goto IL_0079;
								}
								continue;
							}
							if (!class90_0.pgqjrkspy1())
							{
								goto IL_0066;
							}
							goto IL_006c;
							IL_0066:
							throw new Exception1();
							IL_006c:
							return ((Class94)class90_0).vmethod_69(this);
							continue;
							end_IL_0036:
							break;
						}
						break;
					}
					goto IL_0079;
					IL_0079:
					return new Class92(struct74_0.int_0 & ((Class92)class90_0).struct74_0.int_0);
				}
				goto IL_0049;
			}
		}

		public override Class90 vmethod_70(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (class90_0.method_1())
			{
				return new Class92(struct74_0.int_0 | ((Class92)class90_0).struct74_0.int_0);
			}
			if (!class90_0.pgqjrkspy1())
			{
				throw new Exception1();
			}
			return ((Class94)class90_0).vmethod_70(this);
		}

		public override Class90 vmethod_71()
		{
			return new Class92(~struct74_0.int_0);
		}

		public override Class90 vmethod_72(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (!class90_0.method_1())
			{
				if (!class90_0.pgqjrkspy1())
				{
					throw new Exception1();
				}
				return ((Class94)class90_0).vmethod_72(this);
			}
			return new Class92(struct74_0.int_0 ^ ((Class92)class90_0).struct74_0.int_0);
		}

		public override Class90 vmethod_74(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (!class90_0.method_1())
			{
				if (!class90_0.pgqjrkspy1())
				{
					throw new Exception1();
				}
				return ((Class94)class90_0).method_16(this);
			}
			return new Class92(struct74_0.int_0 << ((Class92)class90_0).struct74_0.int_0);
		}

		public override Class90 vmethod_75(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (!class90_0.method_1())
			{
				if (!class90_0.pgqjrkspy1())
				{
					throw new Exception1();
				}
				return ((Class94)class90_0).method_15(this);
			}
			return new Class92(struct74_0.int_0 >> ((Class92)class90_0).struct74_0.int_0);
		}

		public override Class90 vmethod_76(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (class90_0.method_1())
			{
				return new Class92(struct74_0.uint_0 >> ((Class92)class90_0).struct74_0.int_0);
			}
			if (!class90_0.pgqjrkspy1())
			{
				throw new Exception1();
			}
			return ((Class94)class90_0).method_14(this);
		}

		public override string ToString()
		{
			switch (enum23_0)
			{
			default:
				return struct74_0.uint_0.ToString();
			case (Enum23)1:
			case (Enum23)3:
			case (Enum23)5:
			case (Enum23)11:
				return struct74_0.int_0.ToString();
			}
		}

		internal override Class90 vmethod_8()
		{
			return this;
		}

		internal override bool vmethod_9()
		{
			return true;
		}

		internal override bool vmethod_5(Class90 class90_0)
		{
			int num = 5;
			while (!class90_0.method_0())
			{
				while (true)
				{
					IL_0054:
					Class90 @class;
					if (!class90_0.vmethod_0())
					{
						@class = class90_0.vmethod_8();
						num = 3;
						while (true)
						{
							IL_0049:
							if (!@class.vmethod_9())
							{
								num = 13;
								while (true)
								{
									if (num != 13)
									{
										if (num != 994)
										{
											break;
										}
										switch (num)
										{
										case 3:
											goto IL_0049;
										case 4:
											goto IL_0054;
										case 5:
											goto end_IL_0054;
										case 1:
											goto IL_006a;
										case 2:
											goto end_IL_0041;
										case 0:
											goto IL_008e;
										case 6:
											goto end_IL_005f;
										}
										continue;
									}
									return false;
									continue;
									end_IL_0041:
									break;
								}
								break;
							}
							int result;
							if (@class.method_3())
							{
								result = 0;
								goto IL_0085;
							}
							if (!@class.method_1())
							{
								return ((Class94)@class).vmethod_5(this);
							}
							goto IL_008e;
							IL_006a:
							result = 0;
							goto IL_0085;
							IL_0085:
							return (byte)result != 0;
						}
					}
					return ((Class96)class90_0).vmethod_5(this);
					IL_008e:
					return struct74_0.int_0 == ((Class92)@class).struct74_0.int_0;
					continue;
					end_IL_0054:
					break;
				}
				continue;
				end_IL_005f:
				break;
			}
			return ((Class102)class90_0).vmethod_5(this);
		}

		private static Class91 smethod_4(Class90 class90_0)
		{
			Class91 @class = class90_0 as Class91;
			if (@class == null && class90_0.vmethod_0())
			{
				@class = class90_0.vmethod_8() as Class91;
			}
			return @class;
		}

		internal override bool vmethod_6(Class90 class90_0)
		{
			int num = 7;
			while (true)
			{
				if (!class90_0.method_0())
				{
					if (class90_0.vmethod_0())
					{
						break;
					}
					while (true)
					{
						Class90 @class = class90_0.vmethod_8();
						while (true)
						{
							if (@class.vmethod_9())
							{
								if (!@class.method_3())
								{
									while (true)
									{
										IL_0068:
										if (!@class.method_1())
										{
											num = 15;
											while (true)
											{
												if (num != 15)
												{
													if (num != 996)
													{
														break;
													}
													switch (num)
													{
													case 4:
														goto IL_0068;
													case 2:
														goto end_IL_0068;
													case 0:
														goto end_IL_0073;
													case 7:
														goto end_IL_007e;
													case 3:
														goto IL_0098;
													case 6:
														goto IL_009a;
													case 5:
														goto IL_00a9;
													case 8:
														goto IL_00ca;
													case 1:
														goto end_IL_0087;
													}
													continue;
												}
												return ((Class94)@class).vmethod_6(this);
											}
											goto end_IL_0087;
										}
										goto IL_00a9;
										IL_00a9:
										return struct74_0.uint_0 != ((Class92)@class).struct74_0.uint_0;
										continue;
										end_IL_0068:
										break;
									}
									continue;
								}
								goto IL_00ca;
							}
							int result = 0;
							goto IL_0099;
							IL_0098:
							result = 0;
							goto IL_0099;
							IL_0099:
							return (byte)result != 0;
							IL_00ca:
							return false;
							continue;
							end_IL_0073:
							break;
						}
						continue;
						end_IL_007e:
						break;
					}
					continue;
				}
				int result2 = 0;
				goto IL_009b;
				IL_009b:
				return (byte)result2 != 0;
				IL_009a:
				result2 = 0;
				goto IL_009b;
				continue;
				end_IL_0087:
				break;
			}
			return ((Class96)class90_0).vmethod_6(this);
		}

		public override bool vmethod_77(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (!class90_0.method_1())
			{
				if (!class90_0.pgqjrkspy1())
				{
					throw new Exception1();
				}
				return ((Class94)class90_0).vmethod_81(this);
			}
			return struct74_0.int_0 >= ((Class92)class90_0).struct74_0.int_0;
		}

		public override bool vmethod_78(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (class90_0.method_1())
			{
				return struct74_0.uint_0 >= ((Class92)class90_0).struct74_0.uint_0;
			}
			if (!class90_0.pgqjrkspy1())
			{
				throw new Exception1();
			}
			return ((Class94)class90_0).vmethod_82(this);
		}

		public override bool vmethod_79(Class90 class90_0)
		{
			int num = 2;
			while (true)
			{
				IL_0049:
				if (class90_0.vmethod_0())
				{
					goto IL_0036;
				}
				goto IL_003e;
				IL_003e:
				while (true)
				{
					IL_003e_2:
					if (!class90_0.method_1())
					{
						num = 11;
						while (true)
						{
							if (num != 11)
							{
								if (num != 992)
								{
									break;
								}
								switch (num)
								{
								case 1:
									goto end_IL_003e;
								case 4:
									goto IL_003e_2;
								case 2:
									goto IL_0049;
								case 0:
									goto IL_005c;
								case 3:
									goto end_IL_002e;
								}
								continue;
							}
							if (!class90_0.pgqjrkspy1())
							{
								throw new Exception1();
							}
							goto IL_005c;
							IL_005c:
							return ((Class94)class90_0).vmethod_83(this);
							continue;
							end_IL_002e:
							break;
						}
					}
					return struct74_0.int_0 > ((Class92)class90_0).struct74_0.int_0;
					continue;
					end_IL_003e:
					break;
				}
				goto IL_0036;
				IL_0036:
				class90_0 = class90_0.vmethod_8();
				goto IL_003e;
			}
		}

		public override bool vmethod_80(Class90 class90_0)
		{
			int num = 3;
			while (true)
			{
				IL_0032:
				if (class90_0.vmethod_0())
				{
					num = 10;
					while (true)
					{
						if (num != 10)
						{
							if (num != 991)
							{
								break;
							}
							switch (num)
							{
							case 3:
								goto IL_0032;
							case 2:
								goto end_IL_002a;
							case 0:
								goto IL_004d;
							case 1:
								goto end_IL_0032;
							}
							continue;
						}
						class90_0 = class90_0.vmethod_8();
						break;
						continue;
						end_IL_002a:
						break;
					}
				}
				if (!class90_0.method_1())
				{
					if (class90_0.pgqjrkspy1())
					{
						break;
					}
					throw new Exception1();
				}
				goto IL_004d;
				IL_004d:
				return struct74_0.uint_0 > ((Class92)class90_0).struct74_0.uint_0;
				continue;
				end_IL_0032:
				break;
			}
			return ((Class94)class90_0).vmethod_84(this);
		}

		public override bool vmethod_81(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (!class90_0.method_1())
			{
				if (!class90_0.pgqjrkspy1())
				{
					throw new Exception1();
				}
				return ((Class94)class90_0).vmethod_77(this);
			}
			return struct74_0.int_0 <= ((Class92)class90_0).struct74_0.int_0;
		}

		public override bool vmethod_82(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (class90_0.method_1())
			{
				return struct74_0.uint_0 <= ((Class92)class90_0).struct74_0.uint_0;
			}
			if (!class90_0.pgqjrkspy1())
			{
				throw new Exception1();
			}
			return ((Class94)class90_0).vmethod_78(this);
		}

		public override bool vmethod_83(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (class90_0.method_1())
			{
				return struct74_0.int_0 < ((Class92)class90_0).struct74_0.int_0;
			}
			if (!class90_0.pgqjrkspy1())
			{
				throw new Exception1();
			}
			return ((Class94)class90_0).vmethod_79(this);
		}

		public override bool vmethod_84(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (!class90_0.method_1())
			{
				if (class90_0.pgqjrkspy1())
				{
					return ((Class94)class90_0).vmethod_80(this);
				}
				throw new Exception1();
			}
			return struct74_0.uint_0 < ((Class92)class90_0).struct74_0.uint_0;
		}

		static Class92()
		{
			Class72.smethod_20();
		}
	}

	[StructLayout(LayoutKind.Explicit)]
	private struct Struct75
	{
		[FieldOffset(0)]
		public byte byte_0;

		[FieldOffset(0)]
		public sbyte sbyte_0;

		[FieldOffset(0)]
		public ushort ushort_0;

		[FieldOffset(0)]
		public short short_0;

		[FieldOffset(0)]
		public uint uint_0;

		[FieldOffset(0)]
		public int int_0;

		[FieldOffset(0)]
		public ulong ulong_0;

		[FieldOffset(0)]
		public long long_0;
	}

	private class Class93 : Class91
	{
		public Struct75 struct75_0;

		public Enum23 enum23_0;

		internal override void vmethod_10(Class90 class90_0)
		{
			struct75_0 = ((Class93)class90_0).struct75_0;
			enum23_0 = ((Class93)class90_0).enum23_0;
		}

		internal override void vmethod_2(Class90 class90_0)
		{
			vmethod_10(class90_0);
		}

		public Class93(long long_0)
		{
			enum26_0 = (Enum26)2;
			struct75_0.long_0 = long_0;
			enum23_0 = (Enum23)7;
		}

		public Class93(Class93 class93_0)
		{
			enum26_0 = class93_0.enum26_0;
			struct75_0.long_0 = class93_0.struct75_0.long_0;
			enum23_0 = class93_0.enum23_0;
		}

		public override Class91 vmethod_73()
		{
			return new Class93(this);
		}

		public Class93(long long_0, Enum23 enum23_1)
		{
			enum26_0 = (Enum26)2;
			struct75_0.long_0 = long_0;
			enum23_0 = enum23_1;
		}

		public Class93(ulong ulong_0)
		{
			enum26_0 = (Enum26)2;
			struct75_0.ulong_0 = ulong_0;
			enum23_0 = (Enum23)8;
		}

		public Class93(ulong ulong_0, Enum23 enum23_1)
		{
			enum26_0 = (Enum26)2;
			struct75_0.ulong_0 = ulong_0;
			enum23_0 = enum23_1;
		}

		public override bool vmethod_11()
		{
			if (enum23_0 == (Enum23)7)
			{
				return struct75_0.long_0 == 0L;
			}
			return struct75_0.ulong_0 == 0L;
		}

		public override bool vmethod_12()
		{
			return !vmethod_11();
		}

		public override Class90 vmethod_13(Enum23 enum23_1)
		{
			int num;
			Enum27 @enum;
			switch (enum23_1)
			{
			default:
				num = 4;
				goto IL_008b;
			case (Enum23)1:
				return vmethod_15();
			case (Enum23)2:
				return vmethod_16();
			case (Enum23)3:
				return vmethod_17();
			case (Enum23)4:
				return vmethod_18();
			case (Enum23)5:
				return vmethod_19();
			case (Enum23)6:
				return vmethod_20();
			case (Enum23)7:
				return vmethod_21();
			case (Enum23)8:
				return vmethod_22();
			case (Enum23)11:
				return vmethod_14();
			case (Enum23)9:
			case (Enum23)10:
			case (Enum23)12:
			case (Enum23)13:
			case (Enum23)14:
				num = 4;
				goto IL_008b;
			case (Enum23)15:
				return method_6();
			case (Enum23)16:
				{
					return vmethod_73();
				}
				IL_008b:
				@enum = (Enum27)num;
				throw new Exception(@enum.ToString());
			}
		}

		internal override object vmethod_4(Type type_0)
		{
			int num = 25;
			Enum23 @enum = default(Enum23);
			while (true)
			{
				if (type_0 != null)
				{
					goto IL_0160;
				}
				goto IL_0173;
				IL_0173:
				while (true)
				{
					IL_0173_2:
					if (!(type_0 == null))
					{
						while (!(type_0 == typeof(object)))
						{
							if (!(type_0 == typeof(int)))
							{
								while (true)
								{
									IL_0130:
									if (!(type_0 == typeof(uint)))
									{
										if (!(type_0 == typeof(short)))
										{
											if (!(type_0 == typeof(ushort)))
											{
												while (true)
												{
													IL_0118:
													if (!(type_0 == typeof(byte)))
													{
														if (!(type_0 == typeof(sbyte)))
														{
															while (true)
															{
																IL_00fd:
																if (type_0 == typeof(bool))
																{
																	num = 32;
																	while (true)
																	{
																		if (num != 32)
																		{
																			if (num != 1013)
																			{
																				break;
																			}
																			switch (num)
																			{
																			case 9:
																				goto IL_00fd;
																			case 7:
																				goto IL_0118;
																			case 0:
																				goto IL_0130;
																			case 13:
																				goto IL_0148;
																			case 24:
																				goto IL_0160;
																			case 3:
																				goto IL_0168;
																			case 15:
																			case 16:
																				goto IL_0173_2;
																			case 25:
																				goto end_IL_00ef;
																			case 5:
																				goto IL_018b;
																			case 6:
																				goto IL_019c;
																			case 10:
																			case 17:
																				goto end_IL_0148;
																			case 18:
																				goto IL_01b4;
																			case 12:
																				goto IL_0281;
																			case 23:
																				goto end_IL_017f;
																			case 21:
																				goto IL_02d6;
																			case 11:
																				goto IL_02f9;
																			case 14:
																				goto IL_030b;
																			case 8:
																				goto IL_0325;
																			case 1:
																				goto IL_032b;
																			case 4:
																				goto IL_0333;
																			case 2:
																				goto IL_0344;
																			case 19:
																				goto IL_0355;
																			case 22:
																				goto IL_0366;
																			case 20:
																				goto IL_0377;
																			}
																			continue;
																		}
																		return !vmethod_11();
																		continue;
																		end_IL_00ef:
																		break;
																	}
																	break;
																}
																if (type_0 == typeof(long))
																{
																	goto IL_02d6;
																}
																if (!(type_0 == typeof(ulong)))
																{
																	goto IL_02f9;
																}
																goto IL_0333;
																IL_030b:
																return (char)struct75_0.long_0;
																IL_0325:
																throw new Exception1();
																IL_0333:
																return struct75_0.ulong_0;
																IL_02d6:
																return struct75_0.long_0;
																IL_032b:
																return method_5(type_0);
																IL_02f9:
																if (type_0 == typeof(char))
																{
																	goto IL_030b;
																}
																if (!type_0.IsEnum)
																{
																	goto IL_0325;
																}
																goto IL_032b;
															}
															break;
														}
														goto IL_0344;
													}
													goto IL_018b;
													IL_018b:
													return struct75_0.byte_0;
													IL_0344:
													return struct75_0.sbyte_0;
												}
												break;
											}
											goto IL_0355;
										}
										goto IL_0366;
									}
									goto IL_019c;
									IL_019c:
									return struct75_0.uint_0;
									IL_0355:
									return struct75_0.ushort_0;
									IL_0366:
									return struct75_0.short_0;
								}
								goto end_IL_0173;
							}
							goto IL_0377;
							IL_0377:
							return struct75_0.int_0;
							continue;
							end_IL_0148:
							break;
							IL_0148:;
						}
					}
					@enum = enum23_0;
					goto IL_01b4;
					continue;
					end_IL_0173:
					break;
				}
				continue;
				IL_01b4:
				switch (@enum)
				{
				case (Enum23)1:
					return struct75_0.sbyte_0;
				case (Enum23)2:
					return struct75_0.byte_0;
				case (Enum23)3:
					return struct75_0.short_0;
				case (Enum23)4:
					return struct75_0.ushort_0;
				case (Enum23)5:
					return struct75_0.int_0;
				case (Enum23)6:
					return struct75_0.uint_0;
				case (Enum23)8:
					return struct75_0.ulong_0;
				case (Enum23)11:
					return vmethod_12();
				case (Enum23)15:
					return (char)struct75_0.int_0;
				case (Enum23)7:
					goto end_IL_017f;
				}
				goto IL_0281;
				IL_0281:
				return struct75_0.long_0;
				IL_0160:
				if (type_0.IsByRef)
				{
					goto IL_0168;
				}
				goto IL_0173;
				IL_0168:
				type_0 = type_0.GetElementType();
				num = 15;
				goto IL_0173;
				continue;
				end_IL_017f:
				break;
			}
			return struct75_0.long_0;
		}

		internal object method_5(Type type_0)
		{
			Type underlyingType = Enum.GetUnderlyingType(type_0);
			if (underlyingType == typeof(int))
			{
				return Enum.ToObject(type_0, struct75_0.int_0);
			}
			if (!(underlyingType == typeof(uint)))
			{
				if (!(underlyingType == typeof(short)))
				{
					if (!(underlyingType == typeof(ushort)))
					{
						if (!(underlyingType == typeof(byte)))
						{
							if (!(underlyingType == typeof(sbyte)))
							{
								if (!(underlyingType == typeof(long)))
								{
									if (underlyingType == typeof(ulong))
									{
										return Enum.ToObject(type_0, struct75_0.ulong_0);
									}
									if (underlyingType == typeof(char))
									{
										return Enum.ToObject(type_0, (ushort)struct75_0.int_0);
									}
									return Enum.ToObject(type_0, struct75_0.long_0);
								}
								return Enum.ToObject(type_0, struct75_0.long_0);
							}
							return Enum.ToObject(type_0, struct75_0.sbyte_0);
						}
						return Enum.ToObject(type_0, struct75_0.byte_0);
					}
					return Enum.ToObject(type_0, struct75_0.ushort_0);
				}
				return Enum.ToObject(type_0, struct75_0.short_0);
			}
			return Enum.ToObject(type_0, struct75_0.uint_0);
		}

		public override Class92 vmethod_14()
		{
			return new Class92((!vmethod_11()) ? 1 : 0);
		}

		internal override bool vmethod_7()
		{
			return vmethod_12();
		}

		public Class92 method_6()
		{
			return new Class92(struct75_0.sbyte_0, (Enum23)15);
		}

		public override Class92 vmethod_15()
		{
			return new Class92(struct75_0.sbyte_0, (Enum23)1);
		}

		public override Class92 vmethod_16()
		{
			return new Class92((uint)struct75_0.byte_0, (Enum23)2);
		}

		public override Class92 vmethod_17()
		{
			return new Class92(struct75_0.short_0, (Enum23)3);
		}

		public override Class92 vmethod_18()
		{
			return new Class92((uint)struct75_0.ushort_0, (Enum23)4);
		}

		public override Class92 vmethod_19()
		{
			return new Class92(struct75_0.int_0, (Enum23)5);
		}

		public override Class92 vmethod_20()
		{
			return new Class92(struct75_0.uint_0, (Enum23)6);
		}

		public override Class93 vmethod_21()
		{
			return new Class93(struct75_0.long_0, (Enum23)7);
		}

		public override Class93 vmethod_22()
		{
			return new Class93(struct75_0.ulong_0, (Enum23)8);
		}

		public override Class92 vmethod_23()
		{
			return vmethod_15();
		}

		public override Class92 vmethod_24()
		{
			return vmethod_17();
		}

		public override Class92 vmethod_25()
		{
			return vmethod_19();
		}

		public override Class93 vmethod_26()
		{
			return vmethod_21();
		}

		public override Class92 vmethod_27()
		{
			return vmethod_16();
		}

		public override Class92 vmethod_28()
		{
			return vmethod_18();
		}

		public override Class92 vmethod_29()
		{
			return vmethod_20();
		}

		public override Class93 vmethod_30()
		{
			return vmethod_22();
		}

		public override Class92 vmethod_31()
		{
			return new Class92(checked((sbyte)struct75_0.long_0), (Enum23)1);
		}

		public override Class92 vmethod_32()
		{
			return new Class92(checked((sbyte)struct75_0.ulong_0), (Enum23)1);
		}

		public override Class92 vmethod_33()
		{
			return new Class92(checked((short)struct75_0.long_0), (Enum23)3);
		}

		public override Class92 vmethod_34()
		{
			return new Class92(checked((short)struct75_0.ulong_0), (Enum23)3);
		}

		public override Class92 vmethod_35()
		{
			return new Class92(checked((int)struct75_0.long_0), (Enum23)5);
		}

		public override Class92 vmethod_36()
		{
			return new Class92(checked((int)struct75_0.ulong_0), (Enum23)5);
		}

		public override Class93 vmethod_37()
		{
			return new Class93(struct75_0.long_0, (Enum23)7);
		}

		public override Class93 vmethod_38()
		{
			return new Class93(checked((long)struct75_0.ulong_0), (Enum23)7);
		}

		public override Class92 vmethod_39()
		{
			return new Class92(checked((byte)struct75_0.long_0), (Enum23)2);
		}

		public override Class92 vmethod_40()
		{
			return new Class92(checked((byte)struct75_0.ulong_0), (Enum23)2);
		}

		public override Class92 vmethod_41()
		{
			return new Class92(checked((ushort)struct75_0.long_0), (Enum23)4);
		}

		public override Class92 vmethod_42()
		{
			return new Class92(checked((ushort)struct75_0.ulong_0), (Enum23)4);
		}

		public override Class92 vmethod_43()
		{
			return new Class92(checked((uint)struct75_0.long_0), (Enum23)6);
		}

		public override Class92 vmethod_44()
		{
			return new Class92(checked((uint)struct75_0.ulong_0), (Enum23)6);
		}

		public override Class93 vmethod_45()
		{
			return new Class93(checked((ulong)struct75_0.long_0), (Enum23)8);
		}

		public override Class93 vmethod_46()
		{
			return new Class93(struct75_0.ulong_0, (Enum23)8);
		}

		public override Class95 vmethod_47()
		{
			return new Class95(struct75_0.long_0);
		}

		public override Class95 vmethod_48()
		{
			return new Class95((double)struct75_0.long_0);
		}

		public override Class95 vmethod_49()
		{
			return new Class95((double)struct75_0.ulong_0);
		}

		public override Class94 vmethod_50()
		{
			if (IntPtr.Size == 8)
			{
				return new Class94(vmethod_26().struct75_0.long_0);
			}
			return new Class94(vmethod_25().struct74_0.int_0);
		}

		public override Class94 vmethod_51()
		{
			if (IntPtr.Size == 8)
			{
				return new Class94(vmethod_30().struct75_0.ulong_0);
			}
			return new Class94((ulong)vmethod_29().struct74_0.uint_0);
		}

		public override Class94 vmethod_52()
		{
			if (IntPtr.Size == 8)
			{
				return new Class94(vmethod_37().struct75_0.long_0);
			}
			return new Class94(vmethod_35().struct74_0.int_0);
		}

		public override Class94 vmethod_53()
		{
			if (IntPtr.Size == 8)
			{
				return new Class94(vmethod_45().struct75_0.ulong_0);
			}
			return new Class94((ulong)vmethod_43().struct74_0.uint_0);
		}

		public override Class94 vmethod_54()
		{
			if (IntPtr.Size == 8)
			{
				return new Class94(vmethod_38().struct75_0.long_0);
			}
			return new Class94(vmethod_36().struct74_0.int_0);
		}

		public override Class94 vmethod_55()
		{
			if (IntPtr.Size == 8)
			{
				return new Class94(struct75_0.ulong_0);
			}
			return new Class94((ulong)checked((uint)struct75_0.ulong_0));
		}

		public override Class90 vmethod_56()
		{
			return new Class93(-struct75_0.long_0);
		}

		public override Class90 Add(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (!class90_0.method_3())
			{
				throw new Exception1();
			}
			return new Class93(struct75_0.long_0 + ((Class93)class90_0).struct75_0.long_0);
		}

		public override Class90 vmethod_57(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (!class90_0.method_3())
			{
				throw new Exception1();
			}
			return new Class93(checked(struct75_0.long_0 + ((Class93)class90_0).struct75_0.long_0));
		}

		public override Class90 vmethod_58(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (!class90_0.method_3())
			{
				throw new Exception1();
			}
			return new Class93(checked(struct75_0.ulong_0 + ((Class93)class90_0).struct75_0.ulong_0));
		}

		public override Class90 vmethod_59(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (!class90_0.method_3())
			{
				throw new Exception1();
			}
			return new Class93(struct75_0.long_0 - ((Class93)class90_0).struct75_0.long_0);
		}

		public override Class90 vmethod_60(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (!class90_0.method_3())
			{
				throw new Exception1();
			}
			return new Class93(checked(struct75_0.long_0 - ((Class93)class90_0).struct75_0.long_0));
		}

		public override Class90 vmethod_61(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (!class90_0.method_3())
			{
				throw new Exception1();
			}
			return new Class93(checked(struct75_0.ulong_0 - ((Class93)class90_0).struct75_0.ulong_0));
		}

		public override Class90 vmethod_62(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (!class90_0.method_3())
			{
				throw new Exception1();
			}
			return new Class93(struct75_0.long_0 * ((Class93)class90_0).struct75_0.long_0);
		}

		public override Class90 vmethod_63(Class90 class90_0)
		{
			int num = 1;
			while (true)
			{
				IL_003a:
				if (class90_0.vmethod_0())
				{
					while (true)
					{
						IL_002d:
						class90_0 = class90_0.vmethod_8();
						num = 10;
						while (num != 10)
						{
							if (num != 991)
							{
								goto IL_003a;
							}
							switch (num)
							{
							case 0:
								goto IL_002d;
							case 1:
								goto IL_003a;
							case 3:
								goto IL_004a;
							case 2:
								goto end_IL_003a;
							}
						}
						break;
					}
				}
				if (class90_0.method_3())
				{
					break;
				}
				goto IL_004a;
				IL_004a:
				throw new Exception1();
				continue;
				end_IL_003a:
				break;
			}
			return new Class93(checked(struct75_0.long_0 * ((Class93)class90_0).struct75_0.long_0));
		}

		public override Class90 vmethod_64(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (!class90_0.method_3())
			{
				throw new Exception1();
			}
			return new Class93(checked(struct75_0.ulong_0 * ((Class93)class90_0).struct75_0.ulong_0));
		}

		public override Class90 vmethod_65(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (!class90_0.method_3())
			{
				throw new Exception1();
			}
			return new Class93(struct75_0.long_0 / ((Class93)class90_0).struct75_0.long_0);
		}

		public override Class90 vmethod_66(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (!class90_0.method_3())
			{
				throw new Exception1();
			}
			return new Class93(struct75_0.ulong_0 / ((Class93)class90_0).struct75_0.ulong_0);
		}

		public override Class90 vmethod_67(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (!class90_0.method_3())
			{
				throw new Exception1();
			}
			return new Class93(struct75_0.long_0 % ((Class93)class90_0).struct75_0.long_0);
		}

		public override Class90 vmethod_68(Class90 class90_0)
		{
			int num = 1;
			while (true)
			{
				IL_003a:
				if (class90_0.vmethod_0())
				{
					while (true)
					{
						IL_002d:
						class90_0 = class90_0.vmethod_8();
						num = 10;
						while (num != 10)
						{
							if (num != 991)
							{
								goto IL_004a;
							}
							switch (num)
							{
							case 0:
								goto IL_002d;
							case 1:
								goto IL_003a;
							case 3:
								goto IL_004a;
							case 2:
								goto end_IL_003a;
							}
						}
						break;
					}
				}
				if (class90_0.method_3())
				{
					break;
				}
				goto IL_004a;
				IL_004a:
				throw new Exception1();
				continue;
				end_IL_003a:
				break;
			}
			return new Class93(struct75_0.ulong_0 % ((Class93)class90_0).struct75_0.ulong_0);
		}

		public override Class90 vmethod_69(Class90 class90_0)
		{
			int num = 3;
			while (true)
			{
				if (!class90_0.vmethod_0())
				{
					num = 2;
					goto IL_0032;
				}
				goto IL_003d;
				IL_0032:
				while (true)
				{
					IL_0032_2:
					if (class90_0.method_3())
					{
						num = 10;
						while (true)
						{
							if (num != 10)
							{
								if (num != 991)
								{
									break;
								}
								switch (num)
								{
								case 0:
								case 2:
									goto IL_0032_2;
								case 1:
									goto IL_003d;
								case 3:
									goto end_IL_002a;
								}
								continue;
							}
							return new Class93(struct75_0.long_0 & ((Class93)class90_0).struct75_0.long_0);
							continue;
							end_IL_002a:
							break;
						}
						break;
					}
					throw new Exception1();
				}
				continue;
				IL_003d:
				class90_0 = class90_0.vmethod_8();
				goto IL_0032;
			}
		}

		public override Class90 vmethod_70(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (!class90_0.method_3())
			{
				throw new Exception1();
			}
			return new Class93(struct75_0.long_0 | ((Class93)class90_0).struct75_0.long_0);
		}

		public override Class90 vmethod_71()
		{
			return new Class93(~struct75_0.long_0);
		}

		public override Class90 vmethod_72(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (!class90_0.method_3())
			{
				throw new Exception1();
			}
			return new Class93(struct75_0.long_0 ^ ((Class93)class90_0).struct75_0.long_0);
		}

		public override Class90 vmethod_74(Class90 class90_0)
		{
			int num = 4;
			while (true)
			{
				IL_0036:
				if (class90_0.vmethod_0())
				{
					num = 11;
					while (true)
					{
						if (num != 11)
						{
							if (num != 992)
							{
								break;
							}
							switch (num)
							{
							case 4:
								goto IL_0036;
							case 1:
								goto end_IL_002e;
							case 0:
								goto IL_0051;
							case 2:
								goto IL_0059;
							case 3:
								goto end_IL_0036;
							}
							continue;
						}
						class90_0 = class90_0.vmethod_8();
						break;
						continue;
						end_IL_002e:
						break;
					}
				}
				if (class90_0.method_3())
				{
					break;
				}
				goto IL_0051;
				IL_0051:
				if (!class90_0.vmethod_3())
				{
					throw new Exception1();
				}
				goto IL_0059;
				IL_0059:
				return new Class93(struct75_0.long_0 << ((Class91)class90_0).vmethod_19().struct74_0.int_0);
				continue;
				end_IL_0036:
				break;
			}
			return new Class93(struct75_0.long_0 << ((Class93)class90_0).struct75_0.int_0);
		}

		public override Class90 vmethod_75(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (!class90_0.method_3())
			{
				if (class90_0.vmethod_3())
				{
					return new Class93(struct75_0.long_0 >> ((Class91)class90_0).vmethod_19().struct74_0.int_0);
				}
				throw new Exception1();
			}
			return new Class93(struct75_0.long_0 >> ((Class93)class90_0).struct75_0.int_0);
		}

		public override Class90 vmethod_76(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (!class90_0.method_3())
			{
				if (class90_0.vmethod_3())
				{
					return new Class93(struct75_0.ulong_0 >> ((Class91)class90_0).vmethod_19().struct74_0.int_0);
				}
				throw new Exception1();
			}
			return new Class93(struct75_0.ulong_0 >> ((Class93)class90_0).struct75_0.int_0);
		}

		public override string ToString()
		{
			if (enum23_0 == (Enum23)7)
			{
				return struct75_0.long_0.ToString();
			}
			return struct75_0.ulong_0.ToString();
		}

		internal override Class90 vmethod_8()
		{
			return this;
		}

		internal override bool vmethod_9()
		{
			return true;
		}

		internal override bool vmethod_5(Class90 class90_0)
		{
			int num = 3;
			Class90 @class = default(Class90);
			while (true)
			{
				if (class90_0.method_0())
				{
					goto IL_0042;
				}
				if (class90_0.vmethod_0())
				{
					num = 10;
					while (true)
					{
						if (num != 10)
						{
							if (num != 991)
							{
								break;
							}
							switch (num)
							{
							case 3:
								goto end_IL_0032;
							case 2:
								goto IL_0042;
							case 1:
								goto IL_0063;
							case 0:
								goto IL_006b;
							}
							continue;
						}
						return ((Class96)class90_0).vmethod_5(this);
						continue;
						end_IL_0032:
						break;
					}
					continue;
				}
				@class = class90_0.vmethod_8();
				goto IL_0063;
				IL_0042:
				return ((Class102)class90_0).vmethod_5(this);
				IL_0063:
				if (@class.method_3())
				{
					break;
				}
				goto IL_006b;
				IL_006b:
				return false;
			}
			return struct75_0.long_0 == ((Class93)@class).struct75_0.long_0;
		}

		private static Class91 smethod_4(Class90 class90_0)
		{
			Class91 @class = class90_0 as Class91;
			if (@class == null && class90_0.vmethod_0())
			{
				@class = class90_0.vmethod_8() as Class91;
			}
			return @class;
		}

		internal override bool vmethod_6(Class90 class90_0)
		{
			if (!class90_0.method_0())
			{
				if (class90_0.vmethod_0())
				{
					return ((Class96)class90_0).vmethod_6(this);
				}
				Class90 @class = class90_0.vmethod_8();
				if (@class.method_3())
				{
					return struct75_0.ulong_0 != ((Class93)@class).struct75_0.ulong_0;
				}
				return false;
			}
			return false;
		}

		public override bool vmethod_77(Class90 class90_0)
		{
			int num = 1;
			while (true)
			{
				IL_003e:
				if (class90_0.vmethod_0())
				{
					while (true)
					{
						IL_0031:
						class90_0 = class90_0.vmethod_8();
						num = 11;
						while (num != 11)
						{
							if (num != 992)
							{
								goto end_IL_003e;
							}
							switch (num)
							{
							case 2:
								goto IL_0031;
							case 1:
								goto IL_003e;
							case 0:
								goto end_IL_0029;
							case 3:
								goto IL_004e;
							case 4:
								goto end_IL_003e;
							}
							continue;
							end_IL_0029:
							break;
						}
						break;
					}
				}
				if (class90_0.method_3())
				{
					break;
				}
				goto IL_004e;
				IL_004e:
				throw new Exception1();
				continue;
				end_IL_003e:
				break;
			}
			return struct75_0.long_0 >= ((Class93)class90_0).struct75_0.long_0;
		}

		public override bool vmethod_78(Class90 class90_0)
		{
			int num = 3;
			while (true)
			{
				IL_003e:
				if (class90_0.vmethod_0())
				{
					while (true)
					{
						IL_0031:
						class90_0 = class90_0.vmethod_8();
						num = 11;
						while (num != 11 && num == 992)
						{
							switch (num)
							{
							case 1:
								goto IL_0031;
							case 3:
								goto IL_003e;
							case 2:
								goto end_IL_0029;
							case 0:
								goto IL_004e;
							case 4:
								goto end_IL_003e;
							}
							continue;
							end_IL_0029:
							break;
						}
						break;
					}
				}
				if (class90_0.method_3())
				{
					break;
				}
				goto IL_004e;
				IL_004e:
				throw new Exception1();
				continue;
				end_IL_003e:
				break;
			}
			return struct75_0.ulong_0 >= ((Class93)class90_0).struct75_0.ulong_0;
		}

		public override bool vmethod_79(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (!class90_0.method_3())
			{
				throw new Exception1();
			}
			return struct75_0.long_0 > ((Class93)class90_0).struct75_0.long_0;
		}

		public override bool vmethod_80(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (!class90_0.method_3())
			{
				throw new Exception1();
			}
			return struct75_0.ulong_0 > ((Class93)class90_0).struct75_0.ulong_0;
		}

		public override bool vmethod_81(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (!class90_0.method_3())
			{
				throw new Exception1();
			}
			return struct75_0.long_0 <= ((Class93)class90_0).struct75_0.long_0;
		}

		public override bool vmethod_82(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (!class90_0.method_3())
			{
				throw new Exception1();
			}
			return struct75_0.ulong_0 <= ((Class93)class90_0).struct75_0.ulong_0;
		}

		public override bool vmethod_83(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (!class90_0.method_3())
			{
				throw new Exception1();
			}
			return struct75_0.long_0 < ((Class93)class90_0).struct75_0.long_0;
		}

		public override bool vmethod_84(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (!class90_0.method_3())
			{
				throw new Exception1();
			}
			return struct75_0.ulong_0 < ((Class93)class90_0).struct75_0.ulong_0;
		}

		static Class93()
		{
			Class72.smethod_20();
		}
	}

	private class Class94 : Class91
	{
		public object object_0;

		public Enum23 enum23_0;

		internal void method_5(Class90 class90_0)
		{
			int num = 3;
			while (true)
			{
				if (!class90_0.pgqjrkspy1())
				{
					vmethod_10(class90_0);
					num = 10;
					while (true)
					{
						if (num != 10)
						{
							if (num != 991)
							{
								break;
							}
							switch (num)
							{
							case 3:
								goto end_IL_0031;
							case 2:
								goto IL_0041;
							case 1:
								goto end_IL_0039;
							case 0:
								return;
							}
							continue;
						}
						return;
						continue;
						end_IL_0031:
						break;
					}
					continue;
				}
				goto IL_0041;
				IL_0041:
				object_0 = ((Class94)class90_0).object_0;
				break;
				continue;
				end_IL_0039:
				break;
			}
			enum23_0 = ((Class94)class90_0).enum23_0;
		}

		internal unsafe override void vmethod_10(Class90 class90_0)
		{
			if (!class90_0.pgqjrkspy1())
			{
				object obj = class90_0.vmethod_4(null);
				if (obj == null)
				{
					return;
				}
				IntPtr intPtr = ((IntPtr.Size != 8) ? new IntPtr(((Class92)object_0).struct74_0.int_0) : new IntPtr(((Class93)object_0).struct75_0.long_0));
				Type type = obj.GetType();
				if (type == typeof(string))
				{
					return;
				}
				if (!(type == typeof(byte)))
				{
					if (type == typeof(sbyte))
					{
						*(sbyte*)(void*)intPtr = (sbyte)obj;
					}
					else if (type == typeof(short))
					{
						*(short*)(void*)intPtr = (short)obj;
					}
					else if (!(type == typeof(ushort)))
					{
						if (!(type == typeof(int)))
						{
							if (type == typeof(uint))
							{
								*(uint*)(void*)intPtr = (uint)obj;
							}
							else if (type == typeof(long))
							{
								*(long*)(void*)intPtr = (long)obj;
							}
							else if (!(type == typeof(ulong)))
							{
								if (!(type == typeof(float)))
								{
									if (!(type == typeof(double)))
									{
										if (type == typeof(bool))
										{
											*(bool*)(void*)intPtr = (bool)obj;
										}
										else if (!(type == typeof(IntPtr)))
										{
											if (type == typeof(UIntPtr))
											{
												*(UIntPtr*)(void*)intPtr = (UIntPtr)obj;
												return;
											}
											if (!(type == typeof(char)))
											{
												throw new Exception1();
											}
											*(char*)(void*)intPtr = (char)obj;
										}
										else
										{
											*(IntPtr*)(void*)intPtr = (IntPtr)obj;
										}
									}
									else
									{
										*(double*)(void*)intPtr = (double)obj;
									}
								}
								else
								{
									*(float*)(void*)intPtr = (float)obj;
								}
							}
							else
							{
								*(ulong*)(void*)intPtr = (ulong)obj;
							}
						}
						else
						{
							*(int*)(void*)intPtr = (int)obj;
						}
					}
					else
					{
						*(ushort*)(void*)intPtr = (ushort)obj;
					}
				}
				else
				{
					*(byte*)(void*)intPtr = (byte)obj;
				}
			}
			else if (IntPtr.Size == 8)
			{
				IntPtr intPtr2 = new IntPtr(((Class93)object_0).struct75_0.long_0);
				IntPtr intPtr3 = new IntPtr(((Class93)((Class94)class90_0).object_0).struct75_0.long_0);
				*(long*)(void*)intPtr2 = intPtr3.ToInt64();
			}
			else
			{
				IntPtr intPtr4 = new IntPtr(((Class92)object_0).struct74_0.int_0);
				IntPtr intPtr5 = new IntPtr(((Class92)((Class94)class90_0).object_0).struct74_0.int_0);
				*(int*)(void*)intPtr4 = intPtr5.ToInt32();
			}
		}

		internal override void vmethod_2(Class90 class90_0)
		{
			vmethod_10(class90_0);
		}

		public Class94(IntPtr intptr_0)
		{
			enum26_0 = (Enum26)3;
			if (IntPtr.Size == 8)
			{
				object_0 = new Class93(intptr_0.ToInt64());
				enum23_0 = (Enum23)12;
			}
			else
			{
				object_0 = new Class92(intptr_0.ToInt32());
				enum23_0 = (Enum23)12;
			}
		}

		public Class94(UIntPtr uintptr_0)
		{
			enum26_0 = (Enum26)3;
			if (IntPtr.Size == 8)
			{
				object_0 = new Class93(uintptr_0.ToUInt64());
				enum23_0 = (Enum23)12;
			}
			else
			{
				object_0 = new Class92(uintptr_0.ToUInt32());
				enum23_0 = (Enum23)12;
			}
		}

		public Class94()
		{
			enum26_0 = (Enum26)3;
			if (IntPtr.Size == 8)
			{
				object_0 = new Class93(0L);
				enum23_0 = (Enum23)12;
			}
			else
			{
				object_0 = new Class92(0);
				enum23_0 = (Enum23)12;
			}
		}

		public override Class91 vmethod_73()
		{
			return new Class94
			{
				object_0 = ((Class91)object_0).vmethod_73(),
				enum23_0 = enum23_0
			};
		}

		public Class94(long long_0)
		{
			enum26_0 = (Enum26)3;
			if (IntPtr.Size == 8)
			{
				object_0 = new Class93(long_0);
				enum23_0 = (Enum23)12;
			}
			else
			{
				object_0 = new Class92((int)long_0);
				enum23_0 = (Enum23)12;
			}
		}

		public Class94(long long_0, Enum23 enum23_1)
		{
			enum26_0 = (Enum26)3;
			if (IntPtr.Size == 8)
			{
				object_0 = new Class93(long_0);
				enum23_0 = enum23_1;
			}
			else
			{
				object_0 = new Class92((int)long_0);
				enum23_0 = enum23_1;
			}
		}

		public Class94(ulong ulong_0)
		{
			enum26_0 = (Enum26)4;
			if (IntPtr.Size == 8)
			{
				object_0 = new Class93(ulong_0);
				enum23_0 = (Enum23)13;
			}
			else
			{
				object_0 = new Class92((uint)ulong_0);
				enum23_0 = (Enum23)13;
			}
		}

		public Class94(ulong ulong_0, Enum23 enum23_1)
		{
			enum26_0 = (Enum26)4;
			if (IntPtr.Size == 8)
			{
				object_0 = new Class93(ulong_0);
				enum23_0 = enum23_1;
			}
			else
			{
				object_0 = new Class92((uint)ulong_0);
				enum23_0 = enum23_1;
			}
		}

		public override bool vmethod_11()
		{
			return ((Class91)object_0).vmethod_11();
		}

		public override bool vmethod_12()
		{
			return !vmethod_11();
		}

		internal override bool vmethod_7()
		{
			return vmethod_12();
		}

		internal override bool vmethod_1()
		{
			return true;
		}

		public override Class90 vmethod_13(Enum23 enum23_1)
		{
			int num;
			Enum27 @enum;
			switch (enum23_1)
			{
			default:
				num = 4;
				goto IL_008f;
			case (Enum23)1:
				return vmethod_15();
			case (Enum23)2:
				return vmethod_16();
			case (Enum23)3:
				return vmethod_17();
			case (Enum23)4:
				return vmethod_18();
			case (Enum23)5:
				return vmethod_19();
			case (Enum23)6:
				return vmethod_20();
			case (Enum23)7:
				return vmethod_21();
			case (Enum23)8:
				return vmethod_22();
			case (Enum23)11:
				return vmethod_14();
			case (Enum23)12:
				return this;
			case (Enum23)13:
				return this;
			case (Enum23)9:
			case (Enum23)10:
			case (Enum23)14:
			case (Enum23)15:
				num = 4;
				goto IL_008f;
			case (Enum23)16:
				{
					return vmethod_73();
				}
				IL_008f:
				@enum = (Enum27)num;
				throw new Exception(@enum.ToString());
			}
		}

		internal IntPtr method_6()
		{
			if (IntPtr.Size == 8)
			{
				return new IntPtr(((Class93)object_0).struct75_0.long_0);
			}
			return new IntPtr(((Class92)object_0).struct74_0.int_0);
		}

		internal override object vmethod_4(Type type_0)
		{
			if (type_0 != null && type_0.IsByRef)
			{
				type_0 = type_0.GetElementType();
			}
			if (!(type_0 == typeof(IntPtr)))
			{
				if (!(type_0 == typeof(UIntPtr)))
				{
					if (!(type_0 == null) && !(type_0 == typeof(object)))
					{
						throw new Exception1();
					}
					if (IntPtr.Size == 8)
					{
						if (enum23_0 == (Enum23)12)
						{
							return new IntPtr(((Class93)object_0).struct75_0.long_0);
						}
						return new UIntPtr(((Class93)object_0).struct75_0.ulong_0);
					}
					if (enum23_0 == (Enum23)12)
					{
						return new IntPtr(((Class93)object_0).struct75_0.int_0);
					}
					return new UIntPtr(((Class92)object_0).struct74_0.uint_0);
				}
				if (IntPtr.Size == 8)
				{
					return new UIntPtr(((Class93)object_0).struct75_0.ulong_0);
				}
				return new UIntPtr(((Class92)object_0).struct74_0.uint_0);
			}
			if (IntPtr.Size == 8)
			{
				return new IntPtr(((Class93)object_0).struct75_0.long_0);
			}
			return new IntPtr(((Class92)object_0).struct74_0.int_0);
		}

		public override Class92 vmethod_14()
		{
			return ((Class91)object_0).vmethod_14();
		}

		public override Class92 vmethod_15()
		{
			return ((Class91)object_0).vmethod_15();
		}

		public override Class92 vmethod_16()
		{
			return ((Class91)object_0).vmethod_16();
		}

		public override Class92 vmethod_17()
		{
			return ((Class91)object_0).vmethod_17();
		}

		public override Class92 vmethod_18()
		{
			return ((Class91)object_0).vmethod_18();
		}

		public override Class92 vmethod_19()
		{
			return ((Class91)object_0).vmethod_19();
		}

		public override Class92 vmethod_20()
		{
			return ((Class91)object_0).vmethod_20();
		}

		public override Class93 vmethod_21()
		{
			return ((Class91)object_0).vmethod_21();
		}

		public override Class93 vmethod_22()
		{
			return ((Class91)object_0).vmethod_22();
		}

		public override Class92 vmethod_23()
		{
			return vmethod_15();
		}

		public override Class92 vmethod_24()
		{
			return vmethod_17();
		}

		public override Class92 vmethod_25()
		{
			return vmethod_19();
		}

		public override Class93 vmethod_26()
		{
			return vmethod_21();
		}

		public override Class92 vmethod_27()
		{
			return vmethod_16();
		}

		public override Class92 vmethod_28()
		{
			return vmethod_18();
		}

		public override Class92 vmethod_29()
		{
			return vmethod_20();
		}

		public override Class93 vmethod_30()
		{
			return vmethod_22();
		}

		public override Class92 vmethod_31()
		{
			return ((Class91)object_0).vmethod_31();
		}

		public override Class92 vmethod_32()
		{
			return ((Class91)object_0).vmethod_32();
		}

		public override Class92 vmethod_33()
		{
			return ((Class91)object_0).vmethod_33();
		}

		public override Class92 vmethod_34()
		{
			return ((Class91)object_0).vmethod_34();
		}

		public override Class92 vmethod_35()
		{
			return ((Class91)object_0).vmethod_35();
		}

		public override Class92 vmethod_36()
		{
			return ((Class91)object_0).vmethod_36();
		}

		public override Class93 vmethod_37()
		{
			return ((Class91)object_0).vmethod_37();
		}

		public override Class93 vmethod_38()
		{
			return ((Class91)object_0).vmethod_38();
		}

		public override Class92 vmethod_39()
		{
			return ((Class91)object_0).vmethod_39();
		}

		public override Class92 vmethod_40()
		{
			return ((Class91)object_0).vmethod_40();
		}

		public override Class92 vmethod_41()
		{
			return ((Class91)object_0).vmethod_41();
		}

		public override Class92 vmethod_42()
		{
			return ((Class91)object_0).vmethod_42();
		}

		public override Class92 vmethod_43()
		{
			return ((Class91)object_0).vmethod_43();
		}

		public override Class92 vmethod_44()
		{
			return ((Class91)object_0).vmethod_44();
		}

		public override Class93 vmethod_45()
		{
			return ((Class91)object_0).vmethod_45();
		}

		public override Class93 vmethod_46()
		{
			return ((Class91)object_0).vmethod_46();
		}

		public override Class95 vmethod_47()
		{
			return ((Class91)object_0).vmethod_47();
		}

		public override Class95 vmethod_48()
		{
			return ((Class91)object_0).vmethod_48();
		}

		public override Class95 vmethod_49()
		{
			return ((Class91)object_0).vmethod_49();
		}

		public override Class94 vmethod_50()
		{
			if (IntPtr.Size == 8)
			{
				return new Class94(vmethod_26().struct75_0.long_0);
			}
			return new Class94(vmethod_25().struct74_0.int_0);
		}

		public override Class94 vmethod_51()
		{
			if (IntPtr.Size == 8)
			{
				return new Class94(vmethod_30().struct75_0.ulong_0);
			}
			return new Class94((ulong)vmethod_29().struct74_0.uint_0);
		}

		public override Class94 vmethod_52()
		{
			if (IntPtr.Size == 8)
			{
				return new Class94(vmethod_37().struct75_0.long_0);
			}
			return new Class94(vmethod_35().struct74_0.int_0);
		}

		public override Class94 vmethod_53()
		{
			if (IntPtr.Size == 8)
			{
				return new Class94(vmethod_45().struct75_0.ulong_0);
			}
			return new Class94((ulong)vmethod_43().struct74_0.uint_0);
		}

		public override Class94 vmethod_54()
		{
			if (IntPtr.Size == 8)
			{
				return new Class94(vmethod_38().struct75_0.long_0);
			}
			return new Class94(vmethod_36().struct74_0.int_0);
		}

		public override Class94 vmethod_55()
		{
			if (IntPtr.Size == 8)
			{
				return new Class94(vmethod_46().struct75_0.ulong_0);
			}
			return new Class94((ulong)vmethod_44().struct74_0.uint_0);
		}

		public override Class90 vmethod_56()
		{
			if (IntPtr.Size == 8)
			{
				return new Class94(-((Class93)object_0).struct75_0.long_0);
			}
			return new Class94(-((Class92)object_0).struct74_0.int_0);
		}

		public override Class90 Add(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (class90_0.method_1())
			{
				if (IntPtr.Size == 8)
				{
					return new Class94(vmethod_21().struct75_0.long_0 + ((Class92)class90_0).vmethod_21().struct75_0.long_0);
				}
				return new Class94(vmethod_19().struct74_0.int_0 + ((Class92)class90_0).struct74_0.int_0);
			}
			if (class90_0.pgqjrkspy1())
			{
				if (IntPtr.Size == 8)
				{
					return new Class94(vmethod_21().struct75_0.long_0 + ((Class94)class90_0).vmethod_21().struct75_0.long_0);
				}
				return new Class94(vmethod_19().struct74_0.int_0 + ((Class94)class90_0).vmethod_19().struct74_0.int_0);
			}
			throw new Exception1();
		}

		public override Class90 vmethod_57(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			checked
			{
				if (!class90_0.method_1())
				{
					if (!class90_0.pgqjrkspy1())
					{
						throw new Exception1();
					}
					if (IntPtr.Size == 8)
					{
						return new Class94(vmethod_21().struct75_0.long_0 + ((Class94)class90_0).vmethod_21().struct75_0.long_0);
					}
					return new Class94(vmethod_19().struct74_0.int_0 + ((Class94)class90_0).vmethod_19().struct74_0.int_0);
				}
				if (IntPtr.Size == 8)
				{
					return new Class94(vmethod_21().struct75_0.long_0 + ((Class92)class90_0).vmethod_21().struct75_0.long_0);
				}
				return new Class94(vmethod_19().struct74_0.int_0 + ((Class92)class90_0).struct74_0.int_0);
			}
		}

		public override Class90 vmethod_58(Class90 class90_0)
		{
			int num = 4;
			while (true)
			{
				IL_005c:
				if (class90_0.vmethod_0())
				{
					goto IL_0049;
				}
				goto IL_0051;
				IL_0051:
				while (true)
				{
					IL_0051_2:
					checked
					{
						if (class90_0.method_1())
						{
							while (true)
							{
								IL_003e:
								if (IntPtr.Size == 8)
								{
									num = 13;
									while (true)
									{
										if (num != 13)
										{
											if (num != 994)
											{
												break;
											}
											switch (num)
											{
											case 6:
												goto IL_003e;
											case 3:
												goto end_IL_0036;
											case 2:
												goto IL_0051_2;
											case 4:
												goto IL_005c;
											case 0:
												goto IL_00bf;
											case 5:
												goto IL_00c5;
											case 1:
												goto IL_00cd;
											}
											continue;
										}
										return new Class94(vmethod_21().struct75_0.ulong_0 + ((Class92)class90_0).struct74_0.uint_0);
										continue;
										end_IL_0036:
										break;
									}
									break;
								}
								return new Class94(vmethod_19().struct74_0.uint_0 + ((Class92)class90_0).struct74_0.uint_0);
							}
							break;
						}
						if (!class90_0.pgqjrkspy1())
						{
							goto IL_00bf;
						}
						goto IL_00c5;
					}
					IL_00c5:
					if (IntPtr.Size != 8)
					{
						return new Class94((ulong)checked(vmethod_19().struct74_0.uint_0 + ((Class94)class90_0).vmethod_19().struct74_0.uint_0));
					}
					goto IL_00cd;
					IL_00cd:
					return new Class94(checked(vmethod_21().struct75_0.ulong_0 + ((Class94)class90_0).vmethod_21().struct75_0.ulong_0));
					IL_00bf:
					throw new Exception1();
				}
				goto IL_0049;
				IL_0049:
				class90_0 = class90_0.vmethod_8();
				goto IL_0051;
			}
		}

		public override Class90 vmethod_59(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (!class90_0.method_1())
			{
				if (class90_0.pgqjrkspy1())
				{
					if (IntPtr.Size == 8)
					{
						return new Class94(vmethod_21().struct75_0.long_0 - ((Class94)class90_0).vmethod_21().struct75_0.long_0);
					}
					return new Class94(vmethod_19().struct74_0.int_0 - ((Class94)class90_0).vmethod_19().struct74_0.int_0);
				}
				throw new Exception1();
			}
			if (IntPtr.Size == 8)
			{
				return new Class94(vmethod_21().struct75_0.long_0 - ((Class92)class90_0).vmethod_21().struct75_0.long_0);
			}
			return new Class94(vmethod_19().struct74_0.int_0 - ((Class92)class90_0).struct74_0.int_0);
		}

		public Class90 method_7(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (class90_0.method_1())
			{
				if (IntPtr.Size == 8)
				{
					return new Class94(((Class92)class90_0).vmethod_21().struct75_0.long_0 - vmethod_21().struct75_0.long_0);
				}
				return new Class94(((Class92)class90_0).struct74_0.int_0 - vmethod_19().struct74_0.int_0);
			}
			if (!class90_0.pgqjrkspy1())
			{
				throw new Exception1();
			}
			if (IntPtr.Size == 8)
			{
				return new Class94(((Class94)class90_0).vmethod_21().struct75_0.long_0 - vmethod_21().struct75_0.long_0);
			}
			return new Class94(((Class94)class90_0).vmethod_19().struct74_0.int_0 - vmethod_19().struct74_0.int_0);
		}

		public override Class90 vmethod_60(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			checked
			{
				if (!class90_0.method_1())
				{
					if (class90_0.pgqjrkspy1())
					{
						if (IntPtr.Size == 8)
						{
							return new Class94(vmethod_21().struct75_0.long_0 - ((Class94)class90_0).vmethod_21().struct75_0.long_0);
						}
						return new Class94(vmethod_19().struct74_0.int_0 - ((Class94)class90_0).vmethod_19().struct74_0.int_0);
					}
					throw new Exception1();
				}
				if (IntPtr.Size == 8)
				{
					return new Class94(vmethod_21().struct75_0.long_0 - ((Class92)class90_0).vmethod_21().struct75_0.long_0);
				}
				return new Class94(vmethod_19().struct74_0.int_0 - ((Class92)class90_0).struct74_0.int_0);
			}
		}

		public Class90 method_8(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			checked
			{
				if (!class90_0.method_1())
				{
					if (class90_0.pgqjrkspy1())
					{
						if (IntPtr.Size == 8)
						{
							return new Class94(((Class94)class90_0).vmethod_21().struct75_0.long_0 - vmethod_21().struct75_0.long_0);
						}
						return new Class94(((Class94)class90_0).vmethod_19().struct74_0.int_0 - vmethod_19().struct74_0.int_0);
					}
					throw new Exception1();
				}
				if (IntPtr.Size == 8)
				{
					return new Class94(((Class92)class90_0).vmethod_21().struct75_0.long_0 - vmethod_21().struct75_0.long_0);
				}
				return new Class94(((Class92)class90_0).struct74_0.int_0 - vmethod_19().struct74_0.int_0);
			}
		}

		public override Class90 vmethod_61(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			checked
			{
				if (class90_0.method_1())
				{
					if (IntPtr.Size == 8)
					{
						return new Class94(vmethod_21().struct75_0.ulong_0 - ((Class92)class90_0).struct74_0.uint_0);
					}
					return new Class94(vmethod_19().struct74_0.uint_0 - ((Class92)class90_0).struct74_0.uint_0);
				}
			}
			if (class90_0.pgqjrkspy1())
			{
				if (IntPtr.Size == 8)
				{
					return new Class94(checked(vmethod_21().struct75_0.ulong_0 - ((Class94)class90_0).vmethod_21().struct75_0.ulong_0));
				}
				return new Class94((ulong)checked(vmethod_19().struct74_0.uint_0 - ((Class94)class90_0).vmethod_19().struct74_0.uint_0));
			}
			throw new Exception1();
		}

		public Class90 method_9(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (!class90_0.method_1())
			{
				if (class90_0.pgqjrkspy1())
				{
					if (IntPtr.Size == 8)
					{
						return new Class94(checked(((Class94)class90_0).vmethod_21().struct75_0.ulong_0 - vmethod_21().struct75_0.ulong_0));
					}
					return new Class94((ulong)checked(((Class94)class90_0).vmethod_19().struct74_0.uint_0 - vmethod_19().struct74_0.uint_0));
				}
				throw new Exception1();
			}
			checked
			{
				if (IntPtr.Size == 8)
				{
					return new Class94(((Class92)class90_0).struct74_0.uint_0 - vmethod_21().struct75_0.ulong_0);
				}
				return new Class94(((Class92)class90_0).struct74_0.uint_0 - vmethod_19().struct74_0.uint_0);
			}
		}

		public override Class90 vmethod_62(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (!class90_0.method_1())
			{
				if (!class90_0.pgqjrkspy1())
				{
					throw new Exception1();
				}
				if (IntPtr.Size == 8)
				{
					return new Class94(vmethod_21().struct75_0.long_0 * ((Class94)class90_0).vmethod_21().struct75_0.long_0);
				}
				return new Class94(vmethod_19().struct74_0.int_0 * ((Class94)class90_0).vmethod_19().struct74_0.int_0);
			}
			if (IntPtr.Size == 8)
			{
				return new Class94(vmethod_21().struct75_0.long_0 * ((Class92)class90_0).vmethod_21().struct75_0.long_0);
			}
			return new Class94(vmethod_19().struct74_0.int_0 * ((Class92)class90_0).struct74_0.int_0);
		}

		public override Class90 vmethod_63(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			checked
			{
				if (!class90_0.method_1())
				{
					if (!class90_0.pgqjrkspy1())
					{
						throw new Exception1();
					}
					if (IntPtr.Size == 8)
					{
						return new Class94(vmethod_21().struct75_0.long_0 * ((Class94)class90_0).vmethod_21().struct75_0.long_0);
					}
					return new Class94(vmethod_19().struct74_0.int_0 * ((Class94)class90_0).vmethod_19().struct74_0.int_0);
				}
				if (IntPtr.Size == 8)
				{
					return new Class94(vmethod_21().struct75_0.long_0 * ((Class92)class90_0).vmethod_21().struct75_0.long_0);
				}
				return new Class94(vmethod_19().struct74_0.int_0 * ((Class92)class90_0).struct74_0.int_0);
			}
		}

		public override Class90 vmethod_64(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			checked
			{
				if (class90_0.method_1())
				{
					if (IntPtr.Size == 8)
					{
						return new Class94(vmethod_21().struct75_0.ulong_0 * ((Class92)class90_0).struct74_0.uint_0);
					}
					return new Class94(vmethod_19().struct74_0.uint_0 * ((Class92)class90_0).struct74_0.uint_0);
				}
				if (!class90_0.pgqjrkspy1())
				{
					throw new Exception1();
				}
				if (IntPtr.Size == 8)
				{
					return new Class94(vmethod_21().struct75_0.ulong_0 * ((Class94)class90_0).vmethod_21().struct75_0.ulong_0);
				}
			}
			return new Class94((ulong)checked(vmethod_19().struct74_0.uint_0 * ((Class94)class90_0).vmethod_19().struct74_0.uint_0));
		}

		public override Class90 vmethod_65(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (class90_0.method_1())
			{
				if (IntPtr.Size == 8)
				{
					return new Class94(vmethod_21().struct75_0.long_0 / ((Class92)class90_0).vmethod_21().struct75_0.long_0);
				}
				return new Class94(vmethod_19().struct74_0.int_0 / ((Class92)class90_0).struct74_0.int_0);
			}
			if (!class90_0.pgqjrkspy1())
			{
				throw new Exception1();
			}
			if (IntPtr.Size == 8)
			{
				return new Class94(vmethod_21().struct75_0.long_0 / ((Class94)class90_0).vmethod_21().struct75_0.long_0);
			}
			return new Class94(vmethod_19().struct74_0.int_0 / ((Class94)class90_0).vmethod_19().struct74_0.int_0);
		}

		public Class90 method_10(Class90 class90_0)
		{
			int num = 6;
			while (true)
			{
				IL_0077:
				if (!class90_0.vmethod_0())
				{
					num = 5;
					goto IL_005e;
				}
				goto IL_0069;
				IL_005e:
				while (true)
				{
					IL_005e_2:
					if (!class90_0.method_1())
					{
						while (true)
						{
							IL_0050:
							if (class90_0.pgqjrkspy1())
							{
								while (true)
								{
									IL_0045:
									if (IntPtr.Size == 8)
									{
										num = 14;
										while (true)
										{
											if (num != 14)
											{
												if (num != 995)
												{
													break;
												}
												switch (num)
												{
												case 4:
													goto IL_0045;
												case 2:
													goto IL_0050;
												case 5:
												case 7:
													goto IL_005e_2;
												case 1:
													goto end_IL_005e;
												case 6:
													goto IL_0077;
												case 0:
													goto end_IL_003d;
												case 3:
													goto IL_00e9;
												}
												continue;
											}
											return new Class94(((Class94)class90_0).vmethod_21().struct75_0.long_0 / vmethod_21().struct75_0.long_0);
											continue;
											end_IL_003d:
											break;
										}
										break;
									}
									return new Class94(((Class94)class90_0).vmethod_19().struct74_0.int_0 / vmethod_19().struct74_0.int_0);
								}
								break;
							}
							throw new Exception1();
						}
					}
					if (IntPtr.Size != 8)
					{
						return new Class94(((Class92)class90_0).struct74_0.int_0 / vmethod_19().struct74_0.int_0);
					}
					goto IL_00e9;
					IL_00e9:
					return new Class94(((Class92)class90_0).vmethod_21().struct75_0.long_0 / vmethod_21().struct75_0.long_0);
					continue;
					end_IL_005e:
					break;
				}
				goto IL_0069;
				IL_0069:
				class90_0 = class90_0.vmethod_8();
				goto IL_005e;
			}
		}

		public override Class90 vmethod_66(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (!class90_0.method_1())
			{
				if (!class90_0.pgqjrkspy1())
				{
					throw new Exception1();
				}
				if (IntPtr.Size == 8)
				{
					return new Class94(vmethod_21().struct75_0.ulong_0 / ((Class94)class90_0).vmethod_21().struct75_0.ulong_0);
				}
				return new Class94((ulong)(vmethod_19().struct74_0.uint_0 / ((Class94)class90_0).vmethod_19().struct74_0.uint_0));
			}
			if (IntPtr.Size == 8)
			{
				return new Class94(vmethod_21().struct75_0.ulong_0 / ((Class92)class90_0).vmethod_21().struct75_0.ulong_0);
			}
			return new Class94(vmethod_19().struct74_0.uint_0 / ((Class92)class90_0).struct74_0.uint_0);
		}

		public Class90 method_11(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (!class90_0.method_1())
			{
				if (class90_0.pgqjrkspy1())
				{
					if (IntPtr.Size == 8)
					{
						return new Class94(((Class94)class90_0).vmethod_21().struct75_0.ulong_0 / vmethod_21().struct75_0.ulong_0);
					}
					return new Class94((ulong)(((Class94)class90_0).vmethod_19().struct74_0.uint_0 / vmethod_19().struct74_0.uint_0));
				}
				throw new Exception1();
			}
			if (IntPtr.Size == 8)
			{
				return new Class94(((Class92)class90_0).vmethod_21().struct75_0.ulong_0 / vmethod_21().struct75_0.ulong_0);
			}
			return new Class94(((Class92)class90_0).struct74_0.uint_0 / vmethod_19().struct74_0.uint_0);
		}

		public override Class90 vmethod_67(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (!class90_0.method_1())
			{
				if (class90_0.pgqjrkspy1())
				{
					if (IntPtr.Size == 8)
					{
						return new Class94(vmethod_21().struct75_0.long_0 % ((Class94)class90_0).vmethod_21().struct75_0.long_0);
					}
					return new Class94(vmethod_19().struct74_0.int_0 % ((Class94)class90_0).vmethod_19().struct74_0.int_0);
				}
				throw new Exception1();
			}
			if (IntPtr.Size == 8)
			{
				return new Class94(vmethod_21().struct75_0.long_0 % ((Class92)class90_0).vmethod_21().struct75_0.long_0);
			}
			return new Class94(vmethod_19().struct74_0.int_0 % ((Class92)class90_0).struct74_0.int_0);
		}

		public Class90 method_12(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (class90_0.method_1())
			{
				if (IntPtr.Size == 8)
				{
					return new Class94(((Class92)class90_0).vmethod_21().struct75_0.long_0 % vmethod_21().struct75_0.long_0);
				}
				return new Class94(((Class92)class90_0).struct74_0.int_0 % vmethod_19().struct74_0.int_0);
			}
			if (class90_0.pgqjrkspy1())
			{
				if (IntPtr.Size == 8)
				{
					return new Class94(((Class94)class90_0).vmethod_21().struct75_0.long_0 % vmethod_21().struct75_0.long_0);
				}
				return new Class94(((Class94)class90_0).vmethod_19().struct74_0.int_0 % vmethod_19().struct74_0.int_0);
			}
			throw new Exception1();
		}

		public override Class90 vmethod_68(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (class90_0.method_1())
			{
				if (IntPtr.Size == 8)
				{
					return new Class94(vmethod_21().struct75_0.ulong_0 % ((Class92)class90_0).vmethod_21().struct75_0.ulong_0);
				}
				return new Class94(vmethod_19().struct74_0.uint_0 % ((Class92)class90_0).struct74_0.uint_0);
			}
			if (!class90_0.pgqjrkspy1())
			{
				throw new Exception1();
			}
			if (IntPtr.Size == 8)
			{
				return new Class94(vmethod_21().struct75_0.ulong_0 % ((Class94)class90_0).vmethod_21().struct75_0.ulong_0);
			}
			return new Class94((ulong)(vmethod_19().struct74_0.uint_0 % ((Class94)class90_0).vmethod_19().struct74_0.uint_0));
		}

		public Class90 method_13(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (class90_0.method_1())
			{
				if (IntPtr.Size == 8)
				{
					return new Class94(((Class92)class90_0).vmethod_21().struct75_0.ulong_0 % vmethod_21().struct75_0.ulong_0);
				}
				return new Class94(((Class92)class90_0).struct74_0.uint_0 % vmethod_19().struct74_0.uint_0);
			}
			if (!class90_0.pgqjrkspy1())
			{
				throw new Exception1();
			}
			if (IntPtr.Size == 8)
			{
				return new Class94(((Class94)class90_0).vmethod_21().struct75_0.ulong_0 % vmethod_21().struct75_0.ulong_0);
			}
			return new Class94((ulong)(((Class94)class90_0).vmethod_19().struct74_0.uint_0 % vmethod_19().struct74_0.uint_0));
		}

		public override Class90 vmethod_69(Class90 class90_0)
		{
			int num = 7;
			while (true)
			{
				IL_0066:
				if (class90_0.vmethod_0())
				{
					goto IL_0053;
				}
				goto IL_005b;
				IL_005b:
				while (true)
				{
					IL_005b_2:
					if (class90_0.method_1())
					{
						while (true)
						{
							if (IntPtr.Size == 8)
							{
								num = 14;
								while (true)
								{
									if (num != 14)
									{
										if (num != 995)
										{
											break;
										}
										switch (num)
										{
										case 0:
											goto end_IL_003a;
										case 6:
											goto end_IL_0045;
										case 1:
											goto IL_005b_2;
										case 7:
											goto IL_0066;
										case 4:
											goto IL_0071;
										case 3:
											goto IL_0079;
										case 5:
											goto IL_007f;
										case 2:
											goto IL_0087;
										}
										continue;
									}
									return new Class94(vmethod_21().struct75_0.long_0 & ((Class92)class90_0).vmethod_21().struct75_0.long_0);
									continue;
									end_IL_003a:
									break;
								}
								continue;
							}
							return new Class94(vmethod_19().struct74_0.int_0 & ((Class92)class90_0).struct74_0.int_0);
							continue;
							end_IL_0045:
							break;
						}
						break;
					}
					goto IL_0071;
					IL_0087:
					return new Class94(vmethod_21().struct75_0.long_0 & ((Class94)class90_0).vmethod_21().struct75_0.long_0);
					IL_0071:
					if (!class90_0.pgqjrkspy1())
					{
						goto IL_0079;
					}
					goto IL_007f;
					IL_0079:
					throw new Exception1();
					IL_007f:
					if (IntPtr.Size != 8)
					{
						return new Class94(vmethod_19().struct74_0.int_0 & ((Class94)class90_0).vmethod_19().struct74_0.int_0);
					}
					goto IL_0087;
				}
				goto IL_0053;
				IL_0053:
				class90_0 = class90_0.vmethod_8();
				goto IL_005b;
			}
		}

		public override Class90 vmethod_70(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (!class90_0.method_1())
			{
				if (class90_0.pgqjrkspy1())
				{
					if (IntPtr.Size == 8)
					{
						return new Class94(vmethod_21().struct75_0.long_0 | ((Class94)class90_0).vmethod_21().struct75_0.long_0);
					}
					return new Class94(vmethod_19().struct74_0.int_0 | ((Class94)class90_0).vmethod_19().struct74_0.int_0);
				}
				throw new Exception1();
			}
			if (IntPtr.Size == 8)
			{
				return new Class94(vmethod_21().struct75_0.long_0 | ((Class92)class90_0).vmethod_21().struct75_0.long_0);
			}
			return new Class94(vmethod_19().struct74_0.int_0 | ((Class92)class90_0).struct74_0.int_0);
		}

		public override Class90 vmethod_71()
		{
			if (IntPtr.Size == 8)
			{
				return new Class94(~vmethod_21().struct75_0.long_0);
			}
			return new Class94(~vmethod_19().struct74_0.int_0);
		}

		public override Class90 vmethod_72(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (class90_0.method_1())
			{
				if (IntPtr.Size == 8)
				{
					return new Class94(vmethod_21().struct75_0.long_0 ^ ((Class92)class90_0).vmethod_21().struct75_0.long_0);
				}
				return new Class94(vmethod_19().struct74_0.int_0 ^ ((Class92)class90_0).struct74_0.int_0);
			}
			if (!class90_0.pgqjrkspy1())
			{
				throw new Exception1();
			}
			if (IntPtr.Size == 8)
			{
				return new Class94(vmethod_21().struct75_0.long_0 ^ ((Class94)class90_0).vmethod_21().struct75_0.long_0);
			}
			return new Class94(vmethod_19().struct74_0.int_0 ^ ((Class94)class90_0).vmethod_19().struct74_0.int_0);
		}

		public override Class90 vmethod_74(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (!class90_0.method_1())
			{
				if (class90_0.pgqjrkspy1())
				{
					if (IntPtr.Size == 8)
					{
						return new Class94(vmethod_21().struct75_0.long_0 << ((Class94)class90_0).vmethod_21().struct75_0.int_0);
					}
					return new Class94(vmethod_19().struct74_0.int_0 << ((Class94)class90_0).vmethod_19().struct74_0.int_0);
				}
				throw new Exception1();
			}
			if (IntPtr.Size == 8)
			{
				return new Class94(vmethod_21().struct75_0.long_0 << ((Class92)class90_0).struct74_0.int_0);
			}
			return new Class94(vmethod_19().struct74_0.int_0 << ((Class92)class90_0).struct74_0.int_0);
		}

		public override Class90 vmethod_75(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (class90_0.method_1())
			{
				if (IntPtr.Size == 8)
				{
					return new Class94(vmethod_21().struct75_0.long_0 >> ((Class92)class90_0).struct74_0.int_0);
				}
				return new Class94(vmethod_19().struct74_0.int_0 >> ((Class92)class90_0).struct74_0.int_0);
			}
			if (!class90_0.pgqjrkspy1())
			{
				throw new Exception1();
			}
			if (IntPtr.Size == 8)
			{
				return new Class94(vmethod_21().struct75_0.long_0 >> ((Class94)class90_0).vmethod_21().struct75_0.int_0);
			}
			return new Class94(vmethod_19().struct74_0.int_0 >> ((Class94)class90_0).vmethod_19().struct74_0.int_0);
		}

		public override Class90 vmethod_76(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (!class90_0.method_1())
			{
				if (!class90_0.pgqjrkspy1())
				{
					throw new Exception1();
				}
				if (IntPtr.Size == 8)
				{
					return new Class94(vmethod_21().struct75_0.ulong_0 >> ((Class94)class90_0).vmethod_21().struct75_0.int_0);
				}
				return new Class94(vmethod_19().struct74_0.uint_0 >> ((Class94)class90_0).vmethod_19().struct74_0.int_0);
			}
			if (IntPtr.Size == 8)
			{
				return new Class94(vmethod_21().struct75_0.ulong_0 >> ((Class92)class90_0).struct74_0.int_0);
			}
			return new Class94(vmethod_19().struct74_0.uint_0 >> ((Class92)class90_0).struct74_0.int_0);
		}

		public Class90 method_14(Class92 class92_0)
		{
			return new Class94(class92_0.struct74_0.uint_0 >> vmethod_19().struct74_0.int_0);
		}

		public Class90 method_15(Class92 class92_0)
		{
			return new Class94(class92_0.struct74_0.int_0 >> vmethod_21().struct75_0.int_0);
		}

		public Class90 method_16(Class92 class92_0)
		{
			return new Class94(class92_0.struct74_0.int_0 << vmethod_21().struct75_0.int_0);
		}

		public override string ToString()
		{
			return object_0.ToString();
		}

		internal override Class90 vmethod_8()
		{
			return this;
		}

		internal override bool vmethod_9()
		{
			return true;
		}

		internal override bool vmethod_5(Class90 class90_0)
		{
			if (class90_0.method_0())
			{
				return false;
			}
			if (class90_0.vmethod_0())
			{
				return ((Class96)class90_0).vmethod_5(this);
			}
			Class90 @class = class90_0.vmethod_8();
			if (!@class.vmethod_9())
			{
				return false;
			}
			if (!@class.method_1())
			{
				if (@class.pgqjrkspy1())
				{
					_ = IntPtr.Size;
					return vmethod_21().struct75_0.long_0 == ((Class94)class90_0).vmethod_21().struct75_0.long_0;
				}
				return false;
			}
			if (IntPtr.Size == 8)
			{
				return vmethod_21().struct75_0.long_0 == ((Class92)class90_0).vmethod_21().struct75_0.long_0;
			}
			return vmethod_19().struct74_0.int_0 == ((Class92)class90_0).struct74_0.int_0;
		}

		internal override bool vmethod_6(Class90 class90_0)
		{
			if (!class90_0.method_0())
			{
				if (!class90_0.vmethod_0())
				{
					Class90 @class = class90_0.vmethod_8();
					if (!@class.vmethod_9())
					{
						return false;
					}
					if (@class.method_1())
					{
						if (IntPtr.Size == 8)
						{
							return vmethod_21().struct75_0.ulong_0 != ((Class92)class90_0).vmethod_21().struct75_0.ulong_0;
						}
						return vmethod_19().struct74_0.uint_0 != ((Class92)class90_0).struct74_0.uint_0;
					}
					if (!@class.pgqjrkspy1())
					{
						return false;
					}
					_ = IntPtr.Size;
					return vmethod_21().struct75_0.ulong_0 != ((Class94)class90_0).vmethod_21().struct75_0.ulong_0;
				}
				return ((Class96)class90_0).vmethod_6(this);
			}
			return false;
		}

		public override bool vmethod_77(Class90 class90_0)
		{
			int num = 1;
			while (true)
			{
				IL_0046:
				if (class90_0.vmethod_0())
				{
					while (true)
					{
						IL_0039:
						class90_0 = class90_0.vmethod_8();
						num = 13;
						while (num != 13)
						{
							if (num != 994)
							{
								goto IL_0039;
							}
							switch (num)
							{
							case 0:
								goto IL_0039;
							case 1:
								goto IL_0046;
							case 5:
								goto IL_0056;
							case 6:
								goto IL_005e;
							case 3:
								goto IL_00b7;
							case 2:
								goto IL_00bd;
							case 4:
								goto IL_00c5;
							}
						}
						break;
					}
				}
				if (class90_0.method_1())
				{
					goto IL_0056;
				}
				if (!class90_0.pgqjrkspy1())
				{
					goto IL_00b7;
				}
				goto IL_00bd;
				IL_00b7:
				throw new Exception1();
				IL_00bd:
				if (IntPtr.Size != 8)
				{
					break;
				}
				goto IL_00c5;
				IL_0056:
				if (IntPtr.Size != 8)
				{
					return vmethod_19().struct74_0.int_0 >= ((Class92)class90_0).struct74_0.int_0;
				}
				goto IL_005e;
				IL_005e:
				return vmethod_21().struct75_0.long_0 >= ((Class92)class90_0).vmethod_21().struct75_0.long_0;
				IL_00c5:
				return vmethod_21().struct75_0.long_0 >= ((Class94)class90_0).vmethod_21().struct75_0.long_0;
			}
			return vmethod_19().struct74_0.int_0 >= ((Class94)class90_0).vmethod_19().struct74_0.int_0;
		}

		public override bool vmethod_78(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (!class90_0.method_1())
			{
				if (class90_0.pgqjrkspy1())
				{
					if (IntPtr.Size == 8)
					{
						return vmethod_21().struct75_0.ulong_0 >= ((Class94)class90_0).vmethod_21().struct75_0.ulong_0;
					}
					return vmethod_19().struct74_0.uint_0 >= ((Class94)class90_0).vmethod_19().struct74_0.uint_0;
				}
				throw new Exception1();
			}
			if (IntPtr.Size == 8)
			{
				return vmethod_21().struct75_0.ulong_0 >= ((Class92)class90_0).vmethod_21().struct75_0.ulong_0;
			}
			return vmethod_19().struct74_0.uint_0 >= ((Class92)class90_0).struct74_0.uint_0;
		}

		public override bool vmethod_79(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (!class90_0.method_1())
			{
				if (class90_0.pgqjrkspy1())
				{
					if (IntPtr.Size == 8)
					{
						return vmethod_21().struct75_0.long_0 > ((Class94)class90_0).vmethod_21().struct75_0.long_0;
					}
					return vmethod_19().struct74_0.int_0 > ((Class94)class90_0).vmethod_19().struct74_0.int_0;
				}
				throw new Exception1();
			}
			if (IntPtr.Size == 8)
			{
				return vmethod_21().struct75_0.long_0 > ((Class92)class90_0).vmethod_21().struct75_0.long_0;
			}
			return vmethod_19().struct74_0.int_0 > ((Class92)class90_0).struct74_0.int_0;
		}

		public override bool vmethod_80(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (class90_0.method_1())
			{
				if (IntPtr.Size == 8)
				{
					return vmethod_21().struct75_0.ulong_0 > ((Class92)class90_0).vmethod_21().struct75_0.ulong_0;
				}
				return vmethod_19().struct74_0.uint_0 > ((Class92)class90_0).struct74_0.uint_0;
			}
			if (!class90_0.pgqjrkspy1())
			{
				throw new Exception1();
			}
			if (IntPtr.Size == 8)
			{
				return vmethod_21().struct75_0.ulong_0 > ((Class94)class90_0).vmethod_21().struct75_0.ulong_0;
			}
			return vmethod_19().struct74_0.uint_0 > ((Class94)class90_0).vmethod_19().struct74_0.uint_0;
		}

		public override bool vmethod_81(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (class90_0.method_1())
			{
				if (IntPtr.Size == 8)
				{
					return vmethod_21().struct75_0.long_0 <= ((Class92)class90_0).vmethod_21().struct75_0.long_0;
				}
				return vmethod_19().struct74_0.int_0 <= ((Class92)class90_0).struct74_0.int_0;
			}
			if (!class90_0.pgqjrkspy1())
			{
				throw new Exception1();
			}
			if (IntPtr.Size == 8)
			{
				return vmethod_21().struct75_0.long_0 <= ((Class94)class90_0).vmethod_21().struct75_0.long_0;
			}
			return vmethod_19().struct74_0.int_0 <= ((Class94)class90_0).vmethod_19().struct74_0.int_0;
		}

		public override bool vmethod_82(Class90 class90_0)
		{
			int num = 6;
			while (true)
			{
				if (!class90_0.vmethod_0())
				{
					goto IL_0050;
				}
				goto IL_005b;
				IL_005b:
				class90_0 = class90_0.vmethod_8();
				num = 2;
				goto IL_0050;
				IL_0050:
				while (true)
				{
					IL_0050_2:
					if (!class90_0.method_1())
					{
						while (true)
						{
							IL_0042:
							if (class90_0.pgqjrkspy1())
							{
								num = 14;
								while (true)
								{
									if (num != 14)
									{
										if (num != 995)
										{
											break;
										}
										switch (num)
										{
										case 1:
											goto IL_0042;
										case 2:
										case 5:
											goto IL_0050_2;
										case 4:
											goto IL_005b;
										case 6:
											goto end_IL_003a;
										case 3:
											goto IL_007a;
										case 7:
											goto IL_00d6;
										case 0:
											goto IL_00de;
										}
										continue;
									}
									if (IntPtr.Size != 8)
									{
										return vmethod_19().struct74_0.uint_0 <= ((Class94)class90_0).vmethod_19().struct74_0.uint_0;
									}
									goto IL_007a;
									IL_007a:
									return vmethod_21().struct75_0.ulong_0 <= ((Class94)class90_0).vmethod_21().struct75_0.ulong_0;
									continue;
									end_IL_003a:
									break;
								}
								break;
							}
							throw new Exception1();
						}
						break;
					}
					goto IL_00d6;
					IL_00de:
					return vmethod_21().struct75_0.ulong_0 <= ((Class92)class90_0).vmethod_21().struct75_0.ulong_0;
					IL_00d6:
					if (IntPtr.Size != 8)
					{
						return vmethod_19().struct74_0.uint_0 <= ((Class92)class90_0).struct74_0.uint_0;
					}
					goto IL_00de;
				}
			}
		}

		public override bool vmethod_83(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (!class90_0.method_1())
			{
				if (class90_0.pgqjrkspy1())
				{
					if (IntPtr.Size == 8)
					{
						return vmethod_21().struct75_0.long_0 < ((Class94)class90_0).vmethod_21().struct75_0.long_0;
					}
					return vmethod_19().struct74_0.int_0 < ((Class94)class90_0).vmethod_19().struct74_0.int_0;
				}
				throw new Exception1();
			}
			if (IntPtr.Size == 8)
			{
				return vmethod_21().struct75_0.long_0 < ((Class92)class90_0).vmethod_21().struct75_0.long_0;
			}
			return vmethod_19().struct74_0.int_0 < ((Class92)class90_0).struct74_0.int_0;
		}

		public override bool vmethod_84(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (class90_0.method_1())
			{
				if (IntPtr.Size == 8)
				{
					return vmethod_21().struct75_0.ulong_0 < ((Class92)class90_0).vmethod_21().struct75_0.ulong_0;
				}
				return vmethod_19().struct74_0.uint_0 < ((Class92)class90_0).struct74_0.uint_0;
			}
			if (!class90_0.pgqjrkspy1())
			{
				throw new Exception1();
			}
			if (IntPtr.Size == 8)
			{
				return vmethod_21().struct75_0.ulong_0 < ((Class94)class90_0).vmethod_21().struct75_0.ulong_0;
			}
			return vmethod_19().struct74_0.uint_0 < ((Class94)class90_0).vmethod_19().struct74_0.uint_0;
		}

		static Class94()
		{
			Class72.smethod_20();
		}
	}

	private abstract class Class91 : Class90
	{
		public abstract bool vmethod_11();

		public abstract bool vmethod_12();

		public abstract Class90 vmethod_13(Enum23 enum23_0);

		public abstract Class92 vmethod_14();

		public abstract Class92 vmethod_15();

		public abstract Class92 vmethod_16();

		public abstract Class92 vmethod_17();

		public abstract Class92 vmethod_18();

		public abstract Class92 vmethod_19();

		public abstract Class92 vmethod_20();

		public abstract Class93 vmethod_21();

		public abstract Class93 vmethod_22();

		public abstract Class92 vmethod_23();

		public abstract Class92 vmethod_24();

		public abstract Class92 vmethod_25();

		public abstract Class93 vmethod_26();

		public abstract Class92 vmethod_27();

		public abstract Class92 vmethod_28();

		public abstract Class92 vmethod_29();

		public abstract Class93 vmethod_30();

		public abstract Class92 vmethod_31();

		public abstract Class92 vmethod_32();

		public abstract Class92 vmethod_33();

		public abstract Class92 vmethod_34();

		public abstract Class92 vmethod_35();

		public abstract Class92 vmethod_36();

		public abstract Class93 vmethod_37();

		public abstract Class93 vmethod_38();

		public abstract Class92 vmethod_39();

		public abstract Class92 vmethod_40();

		public abstract Class92 vmethod_41();

		public abstract Class92 vmethod_42();

		public abstract Class92 vmethod_43();

		public abstract Class92 vmethod_44();

		public abstract Class93 vmethod_45();

		public abstract Class93 vmethod_46();

		public abstract Class95 vmethod_47();

		public abstract Class95 vmethod_48();

		public abstract Class95 vmethod_49();

		public abstract Class94 vmethod_50();

		public abstract Class94 vmethod_51();

		public abstract Class94 vmethod_52();

		public abstract Class94 vmethod_53();

		public abstract Class94 vmethod_54();

		public abstract Class94 vmethod_55();

		public abstract Class90 vmethod_56();

		public abstract Class90 Add(Class90 class90_0);

		public abstract Class90 vmethod_57(Class90 class90_0);

		public abstract Class90 vmethod_58(Class90 class90_0);

		public abstract Class90 vmethod_59(Class90 class90_0);

		public abstract Class90 vmethod_60(Class90 class90_0);

		public abstract Class90 vmethod_61(Class90 class90_0);

		public abstract Class90 vmethod_62(Class90 class90_0);

		public abstract Class90 vmethod_63(Class90 class90_0);

		public abstract Class90 vmethod_64(Class90 class90_0);

		public abstract Class90 vmethod_65(Class90 class90_0);

		public abstract Class90 vmethod_66(Class90 class90_0);

		public abstract Class90 vmethod_67(Class90 class90_0);

		public abstract Class90 vmethod_68(Class90 class90_0);

		public abstract Class90 vmethod_69(Class90 class90_0);

		public abstract Class90 vmethod_70(Class90 class90_0);

		public abstract Class90 vmethod_71();

		public abstract Class90 vmethod_72(Class90 class90_0);

		public abstract Class91 vmethod_73();

		public abstract Class90 vmethod_74(Class90 class90_0);

		public abstract Class90 vmethod_75(Class90 class90_0);

		public abstract Class90 vmethod_76(Class90 class90_0);

		public abstract bool vmethod_77(Class90 class90_0);

		public abstract bool vmethod_78(Class90 class90_0);

		public abstract bool vmethod_79(Class90 class90_0);

		public abstract bool vmethod_80(Class90 class90_0);

		public abstract bool vmethod_81(Class90 class90_0);

		public abstract bool vmethod_82(Class90 class90_0);

		public abstract bool vmethod_83(Class90 class90_0);

		public abstract bool vmethod_84(Class90 class90_0);

		internal override bool vmethod_3()
		{
			return true;
		}

		static Class91()
		{
			Class72.smethod_20();
		}
	}

	private class Class95 : Class91
	{
		public double double_0;

		public Enum23 enum23_0;

		internal override void vmethod_10(Class90 class90_0)
		{
			double_0 = ((Class95)class90_0).double_0;
			enum23_0 = ((Class95)class90_0).enum23_0;
		}

		internal override void vmethod_2(Class90 class90_0)
		{
			vmethod_10(class90_0);
		}

		public Class95(double double_1)
		{
			enum26_0 = (Enum26)5;
			enum23_0 = (Enum23)10;
			double_0 = double_1;
		}

		public Class95(Class95 class95_0)
		{
			enum26_0 = class95_0.enum26_0;
			enum23_0 = class95_0.enum23_0;
			double_0 = class95_0.double_0;
		}

		public override Class91 vmethod_73()
		{
			return new Class95(this);
		}

		public Class95(double double_1, Enum23 enum23_1)
		{
			enum26_0 = (Enum26)5;
			double_0 = double_1;
			enum23_0 = enum23_1;
		}

		public Class95(float float_0)
		{
			enum26_0 = (Enum26)5;
			double_0 = float_0;
			enum23_0 = (Enum23)9;
		}

		public Class95(float float_0, Enum23 enum23_1)
		{
			enum26_0 = (Enum26)5;
			double_0 = float_0;
			enum23_0 = enum23_1;
		}

		public override bool vmethod_11()
		{
			return double_0 == 0.0;
		}

		public override bool vmethod_12()
		{
			return !vmethod_11();
		}

		public override string ToString()
		{
			return double_0.ToString();
		}

		public override Class90 vmethod_13(Enum23 enum23_1)
		{
			return enum23_1 switch
			{
				(Enum23)1 => vmethod_15(), 
				(Enum23)2 => vmethod_16(), 
				(Enum23)3 => vmethod_17(), 
				(Enum23)4 => vmethod_18(), 
				(Enum23)5 => vmethod_19(), 
				(Enum23)6 => vmethod_20(), 
				(Enum23)7 => vmethod_21(), 
				(Enum23)8 => vmethod_22(), 
				(Enum23)9 => vmethod_47(), 
				(Enum23)10 => vmethod_48(), 
				(Enum23)11 => vmethod_14(), 
				_ => throw new Exception(((Enum27)4/*cast due to .constrained prefix*/).ToString()), 
			};
		}

		internal override object vmethod_4(Type type_0)
		{
			if (type_0 != null && type_0.IsByRef)
			{
				type_0 = type_0.GetElementType();
			}
			if (type_0 == typeof(float))
			{
				return (float)double_0;
			}
			if (type_0 == typeof(double))
			{
				return double_0;
			}
			if ((type_0 == null || type_0 == typeof(object)) && enum23_0 == (Enum23)9)
			{
				return (float)double_0;
			}
			return double_0;
		}

		public override Class92 vmethod_14()
		{
			return new Class92(vmethod_11() ? 1 : 0);
		}

		internal override bool vmethod_7()
		{
			return vmethod_12();
		}

		public override Class92 vmethod_15()
		{
			return new Class92((sbyte)double_0, (Enum23)1);
		}

		public override Class92 vmethod_16()
		{
			return new Class92((uint)(byte)double_0, (Enum23)2);
		}

		public override Class92 vmethod_17()
		{
			return new Class92((short)double_0, (Enum23)3);
		}

		public override Class92 vmethod_18()
		{
			return new Class92((uint)(ushort)double_0, (Enum23)4);
		}

		public override Class92 vmethod_19()
		{
			return new Class92((int)double_0, (Enum23)5);
		}

		public override Class92 vmethod_20()
		{
			return new Class92((uint)double_0, (Enum23)6);
		}

		public override Class93 vmethod_21()
		{
			return new Class93((long)double_0, (Enum23)7);
		}

		public override Class93 vmethod_22()
		{
			return new Class93((ulong)double_0, (Enum23)8);
		}

		public override Class92 vmethod_23()
		{
			return vmethod_15();
		}

		public override Class92 vmethod_24()
		{
			return vmethod_17();
		}

		public override Class92 vmethod_25()
		{
			return vmethod_19();
		}

		public override Class93 vmethod_26()
		{
			return vmethod_21();
		}

		public override Class92 vmethod_27()
		{
			return vmethod_16();
		}

		public override Class92 vmethod_28()
		{
			return vmethod_18();
		}

		public override Class92 vmethod_29()
		{
			return vmethod_20();
		}

		public override Class93 vmethod_30()
		{
			return vmethod_22();
		}

		public override Class92 vmethod_31()
		{
			return new Class92(checked((sbyte)double_0), (Enum23)1);
		}

		public override Class92 vmethod_32()
		{
			return new Class92(checked((sbyte)double_0), (Enum23)1);
		}

		public override Class92 vmethod_33()
		{
			return new Class92(checked((short)double_0), (Enum23)3);
		}

		public override Class92 vmethod_34()
		{
			return new Class92(checked((short)double_0), (Enum23)3);
		}

		public override Class92 vmethod_35()
		{
			return new Class92(checked((int)double_0), (Enum23)5);
		}

		public override Class92 vmethod_36()
		{
			return new Class92(checked((int)double_0), (Enum23)5);
		}

		public override Class93 vmethod_37()
		{
			return new Class93(checked((long)double_0), (Enum23)7);
		}

		public override Class93 vmethod_38()
		{
			return new Class93(checked((long)double_0), (Enum23)7);
		}

		public override Class92 vmethod_39()
		{
			return new Class92(checked((byte)double_0), (Enum23)2);
		}

		public override Class92 vmethod_40()
		{
			return new Class92(checked((byte)double_0), (Enum23)2);
		}

		public override Class92 vmethod_41()
		{
			return new Class92(checked((ushort)double_0), (Enum23)4);
		}

		public override Class92 vmethod_42()
		{
			return new Class92(checked((ushort)double_0), (Enum23)4);
		}

		public override Class92 vmethod_43()
		{
			return new Class92(checked((uint)double_0), (Enum23)6);
		}

		public override Class92 vmethod_44()
		{
			return new Class92(checked((uint)double_0), (Enum23)6);
		}

		public override Class93 vmethod_45()
		{
			return new Class93(checked((ulong)double_0), (Enum23)8);
		}

		public override Class93 vmethod_46()
		{
			return new Class93(checked((ulong)double_0), (Enum23)8);
		}

		public override Class95 vmethod_47()
		{
			return new Class95((float)double_0, (Enum23)9);
		}

		public override Class95 vmethod_48()
		{
			return new Class95(double_0, (Enum23)10);
		}

		public override Class95 vmethod_49()
		{
			return new Class95(double_0);
		}

		public override Class94 vmethod_50()
		{
			if (IntPtr.Size == 8)
			{
				return new Class94(vmethod_26().struct75_0.long_0);
			}
			return new Class94(vmethod_25().struct74_0.int_0);
		}

		public override Class94 vmethod_51()
		{
			if (IntPtr.Size == 8)
			{
				return new Class94(vmethod_30().struct75_0.ulong_0);
			}
			return new Class94((ulong)vmethod_29().struct74_0.uint_0);
		}

		public override Class94 vmethod_52()
		{
			if (IntPtr.Size == 8)
			{
				return new Class94(vmethod_37().struct75_0.long_0);
			}
			return new Class94(vmethod_35().struct74_0.int_0);
		}

		public override Class94 vmethod_53()
		{
			if (IntPtr.Size == 8)
			{
				return new Class94(vmethod_45().struct75_0.ulong_0);
			}
			return new Class94((ulong)vmethod_43().struct74_0.uint_0);
		}

		public override Class94 vmethod_54()
		{
			if (IntPtr.Size == 8)
			{
				return new Class94(vmethod_38().struct75_0.long_0);
			}
			return new Class94(vmethod_36().struct74_0.int_0);
		}

		public override Class94 vmethod_55()
		{
			if (IntPtr.Size == 8)
			{
				return new Class94(vmethod_46().struct75_0.ulong_0);
			}
			return new Class94((ulong)vmethod_44().struct74_0.uint_0);
		}

		public override Class90 vmethod_56()
		{
			if (enum23_0 == (Enum23)9)
			{
				return new Class95((float)(0.0 - double_0));
			}
			return new Class95(0.0 - double_0);
		}

		public override Class90 Add(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (!class90_0.MwVjiGosgX())
			{
				throw new Exception1();
			}
			return new Class95(double_0 + ((Class95)class90_0).double_0);
		}

		public override Class90 vmethod_57(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (!class90_0.MwVjiGosgX())
			{
				throw new Exception1();
			}
			return new Class95(double_0 + ((Class95)class90_0).double_0);
		}

		public override Class90 vmethod_58(Class90 class90_0)
		{
			int num = 2;
			while (true)
			{
				IL_004b:
				if (!class90_0.vmethod_0())
				{
					goto IL_0036;
				}
				goto IL_0041;
				IL_0041:
				class90_0 = class90_0.vmethod_8();
				goto IL_0036;
				IL_0036:
				while (true)
				{
					if (!class90_0.MwVjiGosgX())
					{
						num = 11;
						while (true)
						{
							if (num != 11)
							{
								if (num != 992)
								{
									break;
								}
								switch (num)
								{
								case 0:
								case 1:
									goto end_IL_002e;
								case 4:
									goto end_IL_0036;
								case 2:
									goto IL_004b;
								case 3:
									goto IL_005c;
								}
								continue;
							}
							throw new Exception1();
							continue;
							end_IL_002e:
							break;
						}
						continue;
					}
					goto IL_005c;
					IL_005c:
					return new Class95(double_0 + ((Class95)class90_0).double_0);
					continue;
					end_IL_0036:
					break;
				}
				goto IL_0041;
			}
		}

		public override Class90 vmethod_59(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (!class90_0.MwVjiGosgX())
			{
				throw new Exception1();
			}
			return new Class95(double_0 - ((Class95)class90_0).double_0);
		}

		public override Class90 vmethod_60(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (!class90_0.MwVjiGosgX())
			{
				throw new Exception1();
			}
			return new Class95(double_0 - ((Class95)class90_0).double_0);
		}

		public override Class90 vmethod_61(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (!class90_0.MwVjiGosgX())
			{
				throw new Exception1();
			}
			return new Class95(double_0 - ((Class95)class90_0).double_0);
		}

		public override Class90 vmethod_62(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (!class90_0.MwVjiGosgX() || !class90_0.MwVjiGosgX())
			{
				throw new Exception1();
			}
			return new Class95(double_0 * ((Class95)class90_0).double_0);
		}

		public override Class90 vmethod_63(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (!class90_0.MwVjiGosgX())
			{
				throw new Exception1();
			}
			return new Class95(double_0 * ((Class95)class90_0).double_0);
		}

		public override Class90 vmethod_64(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (!class90_0.MwVjiGosgX())
			{
				throw new Exception1();
			}
			return new Class95(double_0 * ((Class95)class90_0).double_0);
		}

		public override Class90 vmethod_65(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (!class90_0.MwVjiGosgX())
			{
				throw new Exception1();
			}
			return new Class95(double_0 / ((Class95)class90_0).double_0);
		}

		public override Class90 vmethod_66(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (!class90_0.MwVjiGosgX())
			{
				throw new Exception1();
			}
			return new Class95(double_0 / ((Class95)class90_0).double_0);
		}

		public override Class90 vmethod_67(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (!class90_0.MwVjiGosgX())
			{
				throw new Exception1();
			}
			return new Class95(double_0 % ((Class95)class90_0).double_0);
		}

		public override Class90 vmethod_68(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (!class90_0.MwVjiGosgX())
			{
				throw new Exception1();
			}
			return new Class95(double_0 % ((Class95)class90_0).double_0);
		}

		public override Class90 vmethod_69(Class90 class90_0)
		{
			throw new Exception1();
		}

		public override Class90 vmethod_70(Class90 class90_0)
		{
			throw new Exception1();
		}

		public override Class90 vmethod_71()
		{
			throw new Exception1();
		}

		public override Class90 vmethod_72(Class90 class90_0)
		{
			throw new Exception1();
		}

		public override Class90 vmethod_74(Class90 class90_0)
		{
			throw new Exception1();
		}

		public override Class90 vmethod_75(Class90 class90_0)
		{
			throw new Exception1();
		}

		public override Class90 vmethod_76(Class90 class90_0)
		{
			throw new Exception1();
		}

		internal override Class90 vmethod_8()
		{
			return this;
		}

		internal override bool vmethod_5(Class90 class90_0)
		{
			if (class90_0.method_0())
			{
				return false;
			}
			if (class90_0.vmethod_0())
			{
				return ((Class96)class90_0).vmethod_5(this);
			}
			Class90 @class = class90_0.vmethod_8();
			if (!@class.MwVjiGosgX())
			{
				return false;
			}
			return double_0 == ((Class95)@class).double_0;
		}

		internal override bool vmethod_6(Class90 class90_0)
		{
			int num = 3;
			Class90 @class = default(Class90);
			while (true)
			{
				if (!class90_0.method_0())
				{
					if (class90_0.vmethod_0())
					{
						num = 10;
						while (true)
						{
							if (num != 10)
							{
								if (num != 991)
								{
									break;
								}
								switch (num)
								{
								case 3:
									goto end_IL_0032;
								case 2:
									goto IL_0045;
								case 1:
									goto IL_005b;
								case 0:
									goto IL_0063;
								}
								continue;
							}
							return ((Class96)class90_0).vmethod_6(this);
							continue;
							end_IL_0032:
							break;
						}
						continue;
					}
					@class = class90_0.vmethod_8();
					goto IL_005b;
				}
				int result = 0;
				goto IL_0046;
				IL_0045:
				result = 0;
				goto IL_0046;
				IL_0046:
				return (byte)result != 0;
				IL_005b:
				if (@class.MwVjiGosgX())
				{
					break;
				}
				goto IL_0063;
				IL_0063:
				return false;
			}
			return double_0 != ((Class95)@class).double_0;
		}

		public override bool vmethod_77(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (!class90_0.MwVjiGosgX())
			{
				throw new Exception1();
			}
			return double_0 >= ((Class95)class90_0).double_0;
		}

		public override bool vmethod_78(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (!class90_0.MwVjiGosgX())
			{
				throw new Exception1();
			}
			return double_0 >= ((Class95)class90_0).double_0;
		}

		public override bool vmethod_79(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (!class90_0.MwVjiGosgX())
			{
				throw new Exception1();
			}
			return double_0 > ((Class95)class90_0).double_0;
		}

		public override bool vmethod_80(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (!class90_0.MwVjiGosgX())
			{
				throw new Exception1();
			}
			return double_0 > ((Class95)class90_0).double_0;
		}

		public override bool vmethod_81(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (!class90_0.MwVjiGosgX())
			{
				throw new Exception1();
			}
			return double_0 <= ((Class95)class90_0).double_0;
		}

		public override bool vmethod_82(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (!class90_0.MwVjiGosgX())
			{
				throw new Exception1();
			}
			return double_0 <= ((Class95)class90_0).double_0;
		}

		public override bool vmethod_83(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (!class90_0.MwVjiGosgX())
			{
				throw new Exception1();
			}
			return double_0 < ((Class95)class90_0).double_0;
		}

		public override bool vmethod_84(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				class90_0 = class90_0.vmethod_8();
			}
			if (!class90_0.MwVjiGosgX())
			{
				throw new Exception1();
			}
			return double_0 < ((Class95)class90_0).double_0;
		}

		static Class95()
		{
			Class72.smethod_20();
		}
	}

	internal enum Enum23 : byte
	{

	}

	internal enum Enum24 : byte
	{

	}

	private class Exception0 : Exception
	{
		public Exception0(string string_0)
			: base(string_0)
		{
		}

		static Exception0()
		{
			Class72.smethod_20();
		}
	}

	private class Exception1 : Exception
	{
		public Exception1()
		{
		}

		public Exception1(string string_0)
			: base(string_0)
		{
		}

		static Exception1()
		{
			Class72.smethod_20();
		}
	}

	internal class Class80
	{
		internal Enum25 enum25_0 = (Enum25)126;

		internal object object_0;

		public override string ToString()
		{
			object obj = enum25_0;
			if (object_0 != null)
			{
				return obj.ToString() + "H" + object_0.ToString();
			}
			return obj.ToString();
		}

		static Class80()
		{
			Class72.smethod_20();
		}
	}

	internal abstract class Class96 : Class90
	{
		public Class96()
		{
		}

		internal override bool vmethod_0()
		{
			return true;
		}

		internal abstract IntPtr vmethod_11();

		internal abstract void vmethod_12(Class90 class90_0);

		internal override bool vmethod_1()
		{
			return true;
		}

		static Class96()
		{
			Class72.smethod_20();
		}
	}

	internal class Class97 : Class96
	{
		private Class88 class88_0;

		internal int int_0;

		public Class97(int int_1, Class88 class88_1)
		{
			class88_0 = class88_1;
			int_0 = int_1;
			enum26_0 = (Enum26)7;
		}

		internal override void vmethod_10(Class90 class90_0)
		{
			if (class90_0 is Class97)
			{
				class88_0 = ((Class97)class90_0).class88_0;
				int_0 = ((Class97)class90_0).int_0;
				return;
			}
			Class82 @class = class88_0.class85_0.list_1[int_0];
			if (class90_0 is Class96 && (int)(@class.enum23_0 & (Enum23)226) > 0)
			{
				Class90 class90_1 = (class90_0 as Class96).vmethod_8();
				vmethod_12(class90_1);
			}
			else
			{
				vmethod_12(class90_0);
			}
		}

		internal override void vmethod_2(Class90 class90_0)
		{
			vmethod_12(class90_0);
		}

		internal override IntPtr vmethod_11()
		{
			throw new NotImplementedException();
		}

		internal override void vmethod_12(Class90 class90_0)
		{
			class88_0.class90_1[int_0] = class90_0;
		}

		internal override object vmethod_4(Type type_0)
		{
			if (class88_0.class90_1[int_0] == null)
			{
				return null;
			}
			return vmethod_8().vmethod_4(type_0);
		}

		internal override Class90 vmethod_8()
		{
			if (class88_0.class90_1[int_0] != null)
			{
				return class88_0.class90_1[int_0].vmethod_8();
			}
			return new Class102(null);
		}

		internal override bool vmethod_9()
		{
			return vmethod_8().vmethod_9();
		}

		internal override bool vmethod_5(Class90 class90_0)
		{
			int num = 3;
			while (class90_0.vmethod_0())
			{
				while (true)
				{
					IL_0032:
					if (!(class90_0 is Class97))
					{
						num = 10;
						while (true)
						{
							if (num != 10)
							{
								if (num != 991)
								{
									break;
								}
								switch (num)
								{
								case 2:
									goto IL_0032;
								case 3:
									goto end_IL_002a;
								case 0:
									goto IL_0048;
								case 1:
									goto IL_004d;
								}
								continue;
							}
							return false;
							continue;
							end_IL_002a:
							break;
						}
						break;
					}
					goto IL_004d;
					IL_004d:
					int result;
					if (((Class97)class90_0).int_0 == int_0)
					{
						result = 1;
						goto IL_0061;
					}
					return false;
					IL_0061:
					return (byte)result != 0;
					IL_0048:
					result = 1;
					goto IL_0061;
				}
			}
			return false;
		}

		internal override bool vmethod_6(Class90 class90_0)
		{
			if (!class90_0.vmethod_0())
			{
				return true;
			}
			if (!(class90_0 is Class97))
			{
				return true;
			}
			if (((Class97)class90_0).int_0 != int_0)
			{
				return true;
			}
			return false;
		}

		internal override bool vmethod_7()
		{
			return vmethod_8().vmethod_7();
		}

		static Class97()
		{
			Class72.smethod_20();
		}
	}

	internal class Class98 : Class96
	{
		private Array array_0;

		internal int int_0;

		public Class98(int int_1, Array array_1)
		{
			array_0 = array_1;
			int_0 = int_1;
			enum26_0 = (Enum26)7;
			if (array_1 != null)
			{
				array_0.GetType().GetElementType();
			}
		}

		internal override IntPtr vmethod_11()
		{
			throw new NotImplementedException();
		}

		internal override void vmethod_10(Class90 class90_0)
		{
			if (!(class90_0 is Class98))
			{
				vmethod_12(class90_0);
				return;
			}
			array_0 = ((Class98)class90_0).array_0;
			int_0 = ((Class98)class90_0).int_0;
		}

		internal override void vmethod_2(Class90 class90_0)
		{
			vmethod_12(class90_0);
		}

		internal override void vmethod_12(Class90 class90_0)
		{
			object value = class90_0.vmethod_4(null);
			array_0.SetValue(value, int_0);
		}

		internal override object vmethod_4(Type type_0)
		{
			return vmethod_8().vmethod_4(type_0);
		}

		internal override Class90 vmethod_8()
		{
			return Class90.smethod_1(array_0.GetType().GetElementType(), array_0.GetValue(int_0));
		}

		internal override bool vmethod_9()
		{
			return vmethod_8().vmethod_9();
		}

		internal override bool vmethod_5(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				if (!(class90_0 is Class98))
				{
					return false;
				}
				Class98 @class = (Class98)class90_0;
				if (@class.int_0 != int_0)
				{
					return false;
				}
				if (@class.array_0 != array_0)
				{
					return false;
				}
				return true;
			}
			return false;
		}

		internal override bool vmethod_6(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				if (class90_0 is Class98)
				{
					Class98 @class = (Class98)class90_0;
					if (@class.int_0 != int_0)
					{
						return true;
					}
					if (@class.array_0 != array_0)
					{
						return true;
					}
					return false;
				}
				return true;
			}
			return true;
		}

		internal override bool vmethod_7()
		{
			return vmethod_8().vmethod_7();
		}

		static Class98()
		{
			Class72.smethod_20();
		}
	}

	internal class Class99 : Class96
	{
		internal FieldInfo fieldInfo_0;

		internal object object_0;

		public Class99(FieldInfo fieldInfo_1, object object_1)
		{
			fieldInfo_0 = fieldInfo_1;
			object_0 = object_1;
			enum26_0 = (Enum26)7;
		}

		internal override IntPtr vmethod_11()
		{
			throw new NotImplementedException();
		}

		internal override void vmethod_12(Class90 class90_0)
		{
			if (object_0 != null && object_0 is Class90)
			{
				fieldInfo_0.SetValue(((Class90)object_0).vmethod_4(null), class90_0.vmethod_4(null));
			}
			else
			{
				fieldInfo_0.SetValue(object_0, class90_0.vmethod_4(null));
			}
		}

		internal override void vmethod_10(Class90 class90_0)
		{
			if (class90_0 is Class99)
			{
				fieldInfo_0 = ((Class99)class90_0).fieldInfo_0;
				object_0 = ((Class99)class90_0).object_0;
			}
			else
			{
				vmethod_12(class90_0);
			}
		}

		internal override void vmethod_2(Class90 class90_0)
		{
			vmethod_12(class90_0);
		}

		internal override object vmethod_4(Type type_0)
		{
			return vmethod_8().vmethod_4(type_0);
		}

		internal override Class90 vmethod_8()
		{
			if (object_0 != null && object_0 is Class90)
			{
				return Class90.smethod_1(fieldInfo_0.FieldType, fieldInfo_0.GetValue(((Class90)object_0).vmethod_4(null)));
			}
			return Class90.smethod_1(fieldInfo_0.FieldType, fieldInfo_0.GetValue(object_0));
		}

		internal override bool vmethod_9()
		{
			return vmethod_8().vmethod_9();
		}

		internal override bool vmethod_5(Class90 class90_0)
		{
			if (!class90_0.vmethod_0())
			{
				return false;
			}
			if (class90_0 is Class99)
			{
				Class99 @class = (Class99)class90_0;
				if (@class.fieldInfo_0 != fieldInfo_0)
				{
					return false;
				}
				if (@class.object_0 != object_0)
				{
					return false;
				}
				return true;
			}
			return false;
		}

		internal override bool vmethod_6(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				if (!(class90_0 is Class99))
				{
					return true;
				}
				Class99 @class = (Class99)class90_0;
				if (!(@class.fieldInfo_0 != fieldInfo_0))
				{
					if (@class.object_0 != object_0)
					{
						return true;
					}
					return false;
				}
				return true;
			}
			return true;
		}

		internal override bool vmethod_7()
		{
			return vmethod_8().vmethod_7();
		}

		static Class99()
		{
			Class72.smethod_20();
		}
	}

	internal class Class100 : Class96
	{
		private Class88 class88_0;

		internal int int_0;

		public Class100(int int_1, Class88 class88_1)
		{
			class88_0 = class88_1;
			int_0 = int_1;
			enum26_0 = (Enum26)7;
		}

		internal override IntPtr vmethod_11()
		{
			throw new NotImplementedException();
		}

		internal override void vmethod_10(Class90 class90_0)
		{
			if (class90_0 is Class100)
			{
				class88_0 = ((Class100)class90_0).class88_0;
				int_0 = ((Class100)class90_0).int_0;
			}
			else
			{
				vmethod_12(class90_0);
			}
		}

		internal override void vmethod_2(Class90 class90_0)
		{
			vmethod_12(class90_0);
		}

		internal override void vmethod_12(Class90 class90_0)
		{
			class88_0.class90_0[int_0] = class90_0;
		}

		internal override object vmethod_4(Type type_0)
		{
			if (class88_0.class90_0[int_0] != null)
			{
				return vmethod_8().vmethod_4(type_0);
			}
			return null;
		}

		internal override Class90 vmethod_8()
		{
			if (class88_0.class90_0[int_0] != null)
			{
				return class88_0.class90_0[int_0].vmethod_8();
			}
			return new Class102(null);
		}

		internal override bool vmethod_9()
		{
			return vmethod_8().vmethod_9();
		}

		internal override bool vmethod_5(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				if (!(class90_0 is Class100))
				{
					return false;
				}
				return ((Class100)class90_0).int_0 == int_0;
			}
			return false;
		}

		internal override bool vmethod_6(Class90 class90_0)
		{
			if (!class90_0.vmethod_0())
			{
				return true;
			}
			if (class90_0 is Class100)
			{
				return ((Class100)class90_0).int_0 != int_0;
			}
			return true;
		}

		internal override bool vmethod_7()
		{
			return vmethod_8().vmethod_7();
		}

		static Class100()
		{
			Class72.smethod_20();
		}
	}

	internal class Class101 : Class96
	{
		private Class90 class90_0;

		private Type type_0;

		public Class101(Class90 class90_1, Type type_1)
		{
			class90_0 = class90_1;
			type_0 = type_1;
			enum26_0 = (Enum26)7;
		}

		internal override IntPtr vmethod_11()
		{
			throw new NotImplementedException();
		}

		internal override void vmethod_10(Class90 class90_1)
		{
			int num = 1;
			while (true)
			{
				if (!(class90_1 is Class101))
				{
					while (true)
					{
						IL_0031:
						class90_0.vmethod_10(class90_1);
						num = 11;
						while (true)
						{
							if (num != 11)
							{
								if (num != 992)
								{
									break;
								}
								switch (num)
								{
								case 0:
									goto IL_0031;
								case 1:
									goto end_IL_0029;
								case 3:
									goto IL_004e;
								case 4:
									goto end_IL_0042;
								case 2:
									return;
								}
								continue;
							}
							return;
							continue;
							end_IL_0029:
							break;
						}
						break;
					}
					continue;
				}
				goto IL_004e;
				IL_004e:
				type_0 = ((Class101)class90_1).type_0;
				break;
				continue;
				end_IL_0042:
				break;
			}
			class90_0 = ((Class101)class90_1).class90_0;
		}

		internal override void vmethod_2(Class90 class90_1)
		{
			vmethod_12(class90_1);
		}

		internal override void vmethod_12(Class90 class90_1)
		{
			class90_0 = class90_1;
		}

		internal override object vmethod_4(Type type_1)
		{
			if (class90_0 != null)
			{
				if (!(type_1 == null) && !(type_1 == typeof(object)))
				{
					return class90_0.vmethod_4(type_1);
				}
				return class90_0.vmethod_4(type_0);
			}
			return new Class102(null);
		}

		internal override Class90 vmethod_8()
		{
			if (class90_0 == null)
			{
				return new Class102(null);
			}
			return class90_0.vmethod_8();
		}

		internal override bool vmethod_9()
		{
			return vmethod_8().vmethod_9();
		}

		internal override bool vmethod_5(Class90 class90_1)
		{
			if (class90_1.vmethod_0())
			{
				if (!(class90_1 is Class101))
				{
					return false;
				}
				Class101 @class = (Class101)class90_1;
				if (!(@class.type_0 != type_0))
				{
					if (class90_0 == null)
					{
						if (@class.class90_0 != null)
						{
							return false;
						}
						return true;
					}
					return class90_0.vmethod_5(@class.class90_0);
				}
				return false;
			}
			return false;
		}

		internal override bool vmethod_6(Class90 class90_1)
		{
			if (class90_1.vmethod_0())
			{
				if (!(class90_1 is Class101))
				{
					return true;
				}
				Class101 @class = (Class101)class90_1;
				if (@class.type_0 != type_0)
				{
					return true;
				}
				if (class90_0 != null)
				{
					return class90_0.vmethod_6(@class.class90_0);
				}
				if (@class.class90_0 == null)
				{
					return false;
				}
				return true;
			}
			return true;
		}

		internal override bool vmethod_7()
		{
			return vmethod_8().vmethod_7();
		}

		static Class101()
		{
			Class72.smethod_20();
		}
	}

	internal class Class81
	{
		public int int_0;

		public bool bool_0;

		public Enum23 enum23_0;

		static Class81()
		{
			Class72.smethod_20();
		}
	}

	internal class Class82
	{
		public int int_0;

		public Enum23 enum23_0;

		public bool bool_0;

		public Type type_0 = typeof(object);

		static Class82()
		{
			Class72.smethod_20();
		}
	}

	internal class Class83
	{
		public int int_0;

		public int int_1;

		public Class84 class84_0;

		static Class83()
		{
			Class72.smethod_20();
		}
	}

	internal class Class84
	{
		public int int_0;

		public int int_1;

		public byte byte_0;

		public Type type_0;

		public int int_2;

		public int int_3;

		static Class84()
		{
			Class72.smethod_20();
		}
	}

	internal class Class85
	{
		internal MethodBase methodBase_0;

		internal List<Class80> list_0;

		internal Class81[] leLxEnLbDa;

		internal List<Class82> list_1;

		internal List<Class83> list_2;

		static Class85()
		{
			Class72.smethod_20();
		}
	}

	private class Class86
	{
		internal object object_0;

		internal int int_0;

		public Class86(FieldInfo fieldInfo_0, int int_1)
		{
			object_0 = fieldInfo_0;
			int_0 = int_1;
		}

		static Class86()
		{
			Class72.smethod_20();
		}
	}

	private class Class87
	{
		private List<Class86> list_0 = new List<Class86>();

		private MethodBase methodBase_0;

		public Class87(MethodBase methodBase_1, List<Class86> list_1)
		{
			list_0 = list_1;
			methodBase_0 = methodBase_1;
		}

		public Class87(MethodBase methodBase_1, Class86[] class86_0)
		{
			list_0.AddRange(class86_0);
		}

		public override bool Equals(object obj)
		{
			Class87 @class = obj as Class87;
			if (obj != null)
			{
				if (methodBase_0 != @class.methodBase_0)
				{
					return false;
				}
				if (list_0.Count != @class.list_0.Count)
				{
					return false;
				}
				int num = 0;
				while (true)
				{
					if (num < list_0.Count)
					{
						if ((FieldInfo?)list_0[num].object_0 != (FieldInfo?)@class.list_0[num].object_0)
						{
							break;
						}
						if (list_0[num].int_0 == @class.list_0[num].int_0)
						{
							num++;
							continue;
						}
						return false;
					}
					return true;
				}
				return false;
			}
			return false;
		}

		public override int GetHashCode()
		{
			int num = methodBase_0.GetHashCode();
			foreach (Class86 item in list_0)
			{
				int num2 = item.object_0.GetHashCode() + item.int_0;
				num = (num ^ num2) + num2;
			}
			return num;
		}

		public Class86 method_0(int int_0)
		{
			foreach (Class86 item in list_0)
			{
				if (item.int_0 == int_0)
				{
					return item;
				}
			}
			return null;
		}

		public bool method_1(int int_0)
		{
			foreach (Class86 item in list_0)
			{
				if (item.int_0 == int_0)
				{
					return true;
				}
			}
			return false;
		}

		static Class87()
		{
			Class72.smethod_20();
		}
	}

	private delegate object Delegate16(object target, object[] paramters);

	private delegate object Delegate17(ref object target, object[] paramters);

	private delegate object Delegate18(object target);

	private delegate void Delegate19(IntPtr a, byte b, int c);

	private delegate void Delegate20(IntPtr s, IntPtr t, uint c);

	internal class Class88
	{
		private delegate object Delegate21(ref object target, object[] paramters);

		[Serializable]
		[CompilerGenerated]
		private sealed class Class89
		{
			public static readonly Class89 <>9;

			public static Comparison<Class83> <>9__12_0;

			static Class89()
			{
				Class72.smethod_20();
				<>9 = new Class89();
			}

			internal int method_0(Class83 x, Class83 y)
			{
				return x.class84_0.int_0.CompareTo(y.class84_0.int_0);
			}
		}

		internal Class85 class85_0;

		internal Class90[] class90_0 = new Class90[0];

		internal Class90[] class90_1 = new Class90[0];

		internal Class107 class107_0 = new Class107();

		internal Class90 class90_2;

		internal Exception exception_0;

		internal List<IntPtr> list_0;

		private int int_0;

		private int int_1;

		private int int_2 = -1;

		private object object_0;

		private bool bool_0;

		private bool bool_1;

		private bool bool_2;

		private bool bool_3;

		private static Dictionary<Type, int> dictionary_0;

		private static object object_1;

		private static Dictionary<object, Class90> dictionary_1;

		private static object object_2;

		private static string string_0;

		private static string string_1;

		private static string string_2;

		private static string string_3;

		private static string string_4;

		private static string string_5;

		private static Dictionary<MethodBase, Delegate16> dictionary_2;

		private static Dictionary<MethodBase, Delegate16> dictionary_3;

		private static object object_3;

		private static Dictionary<Class87, Delegate16> dictionary_4;

		private static Dictionary<Class87, Delegate16> dictionary_5;

		private static object object_4;

		private static Dictionary<Class87, Delegate16> dictionary_6;

		private static object object_5;

		private static object object_6;

		private static Dictionary<MethodBase, Delegate21> dictionary_7;

		private static Dictionary<MethodBase, Delegate21> dictionary_8;

		private static Dictionary<Type, Delegate18> dictionary_9;

		private static object object_7;

		private static Delegate19 yfwYzgkgfQF;

		private static Delegate20 AfaYzaSaGp5;

		internal void method_0()
		{
			bool bool_ = false;
			vjuxAdNiYK(ref bool_);
		}

		internal void method_1()
		{
			class107_0.method_1();
			class90_1 = null;
			if (list_0 == null)
			{
				return;
			}
			foreach (IntPtr item in list_0)
			{
				try
				{
					Marshal.FreeHGlobal(item);
				}
				catch
				{
				}
			}
			list_0.Clear();
			list_0 = null;
		}

		internal void vjuxAdNiYK(ref bool bool_4)
		{
			while (true)
			{
				if (int_0 > -2)
				{
					if (bool_0)
					{
						bool_0 = false;
						int num = int_1;
						int num2 = int_0;
						method_3(int_1, int_0);
						int_0 = num2;
						int_1 = num;
					}
					if (bool_2)
					{
						break;
					}
					if (!bool_1)
					{
						int_1 = int_0;
						Class80 @class = class85_0.list_0[int_0];
						object_0 = @class.object_0;
						try
						{
							method_6(@class);
						}
						catch (Exception innerException)
						{
							if (innerException is TargetInvocationException)
							{
								TargetInvocationException ex = (TargetInvocationException)innerException;
								if (ex.InnerException != null)
								{
									innerException = ex.InnerException;
								}
							}
							exception_0 = innerException;
							bool_4 = true;
							class107_0.method_1();
							int int_ = int_1;
							Class83 class2 = method_4(int_, innerException);
							List<Class83> list = method_5(int_, bool_4: false);
							List<Class83> list2 = new List<Class83>();
							if (class2 != null)
							{
								list2.Add(class2);
							}
							if (list != null && list.Count > 0)
							{
								list2.AddRange(list);
							}
							list2.Sort((Class83 x, Class83 y) => x.class84_0.int_0.CompareTo(y.class84_0.int_0));
							Class83 class3 = null;
							foreach (Class83 item in list2)
							{
								if (item.class84_0.int_3 != 0)
								{
									class107_0.method_2(new Class102(innerException));
									int_1 = item.class84_0.int_2;
									int_0 = int_1;
									method_0();
									if (bool_3)
									{
										bool_3 = false;
										class3 = item;
										break;
									}
									continue;
								}
								class3 = item;
								break;
							}
							if (class3 == null)
							{
								throw innerException;
							}
							int_2 = class3.class84_0.int_0;
							method_2(int_, class3.class84_0.int_0);
							if (int_2 >= 0)
							{
								class107_0.method_2(new Class102(innerException));
								int_1 = int_2;
								int_0 = int_1;
								int_2 = -1;
								method_0();
							}
							return;
						}
						int_0++;
						continue;
					}
					bool_1 = false;
					return;
				}
				class107_0.method_1();
				return;
			}
			bool_2 = false;
		}

		internal void method_2(int int_3, int int_4)
		{
			if (class85_0.list_2 == null)
			{
				return;
			}
			foreach (Class83 item in class85_0.list_2)
			{
				if ((item.class84_0.int_3 == 4 || item.class84_0.int_3 == 2) && item.class84_0.int_0 >= int_3 && item.class84_0.int_1 <= int_4)
				{
					int_1 = item.class84_0.int_0;
					int_0 = int_1;
					bool bool_ = false;
					vjuxAdNiYK(ref bool_);
					if (bool_)
					{
						break;
					}
				}
			}
		}

		internal void method_3(int int_3, int int_4)
		{
			if (class85_0.list_2 == null)
			{
				return;
			}
			foreach (Class83 item in class85_0.list_2)
			{
				if (item.class84_0.int_3 == 2 && item.class84_0.int_0 >= int_3 && item.class84_0.int_1 <= int_4)
				{
					int_1 = item.class84_0.int_0;
					int_0 = int_1;
					bool bool_ = false;
					vjuxAdNiYK(ref bool_);
					if (bool_)
					{
						break;
					}
				}
			}
		}

		internal Class83 method_4(int int_3, Exception exception_1)
		{
			int num = 4;
			List<Class83>.Enumerator enumerator = default(List<Class83>.Enumerator);
			while (true)
			{
				Class83 @class = null;
				num = 11;
				while (true)
				{
					if (num != 11)
					{
						if (num != 992)
						{
							break;
						}
						switch (num)
						{
						case 4:
							goto end_IL_0029;
						case 0:
							goto IL_004b;
						case 2:
							goto IL_005d;
						case 1:
						case 3:
							goto IL_0174;
						}
						continue;
					}
					if (class85_0.list_2 != null)
					{
						goto IL_004b;
					}
					goto IL_0174;
					IL_004b:
					enumerator = class85_0.list_2.GetEnumerator();
					goto IL_005d;
					IL_0174:
					return @class;
					IL_005d:
					try
					{
						while (enumerator.MoveNext())
						{
							Class83 current = enumerator.Current;
							if (current.class84_0 != null && current.class84_0.int_3 == 0 && (current.class84_0.type_0 == exception_1.GetType() || (current.class84_0.type_0 != null && (current.class84_0.type_0.FullName == exception_1.GetType().FullName || current.class84_0.type_0.FullName == typeof(object).FullName || current.class84_0.type_0.FullName == typeof(Exception).FullName))) && int_3 >= current.int_0 && int_3 <= current.int_1)
							{
								if (@class == null)
								{
									@class = current;
								}
								else if (current.class84_0.int_0 < @class.class84_0.int_0)
								{
									@class = current;
								}
							}
						}
					}
					finally
					{
						((IDisposable)enumerator/*cast due to .constrained prefix*/).Dispose();
					}
					goto IL_0174;
					continue;
					end_IL_0029:
					break;
				}
			}
		}

		internal List<Class83> method_5(int int_3, bool bool_4)
		{
			if (class85_0.list_2 != null)
			{
				List<Class83> list = new List<Class83>();
				using (List<Class83>.Enumerator enumerator = class85_0.list_2.GetEnumerator())
				{
					Class83 current = default(Class83);
					while (true)
					{
						IL_00a0:
						if (!enumerator.MoveNext())
						{
							int num = 15;
							while (num != 15)
							{
								if (num != 995)
								{
									goto IL_0033;
								}
								switch (num)
								{
								case 6:
									break;
								case 4:
									goto IL_0033;
								case 1:
									goto IL_0043;
								case 0:
									goto IL_004c;
								case 7:
									goto IL_0059;
								default:
									continue;
								case 2:
								case 3:
								case 5:
									goto IL_00a0;
								}
								goto IL_002b;
							}
							break;
						}
						goto IL_002b;
						IL_004c:
						if (int_3 > current.int_1)
						{
							int num = 2;
							continue;
						}
						goto IL_0059;
						IL_0059:
						list.Add(current);
						continue;
						IL_002b:
						current = enumerator.Current;
						goto IL_0033;
						IL_0033:
						if ((current.class84_0.int_3 & 1) != 1)
						{
							continue;
						}
						goto IL_0043;
						IL_0043:
						if (int_3 < current.int_0)
						{
							continue;
						}
						goto IL_004c;
					}
				}
				if (list.Count == 0)
				{
					return null;
				}
				return list;
			}
			return null;
		}

		private unsafe void method_6(Class80 class80_0)
		{
			int num = 454;
			IntPtr intPtr = default(IntPtr);
			FieldInfo fieldInfo = default(FieldInfo);
			Class95 class6 = default(Class95);
			int[] array2 = default(int[]);
			Array array = default(Array);
			int num2 = default(int);
			uint num3 = default(uint);
			ConstructorInfo constructorInfo = default(ConstructorInfo);
			MethodBase methodBase = default(MethodBase);
			Class91 class4 = default(Class91);
			Type type = default(Type);
			bool flag = default(bool);
			Enum27 @enum = default(Enum27);
			ParameterInfo[] parameters = default(ParameterInfo[]);
			object[] array3 = default(object[]);
			Class90[] array4 = default(Class90[]);
			List<Class86> list = default(List<Class86>);
			Class87 class8 = default(Class87);
			Class96 class9 = default(Class96);
			Class90 class90_ = default(Class90);
			long num8 = default(long);
			Class102 class10 = default(Class102);
			Delegate16 @delegate = default(Delegate16);
			object obj = default(object);
			Class99 class11 = default(Class99);
			Class90 @class = default(Class90);
			object key = default(object);
			int num11 = default(int);
			IntPtr intPtr2 = default(IntPtr);
			List<Type> list2 = default(List<Type>);
			MethodBase methodBase2 = default(MethodBase);
			List<Type>.Enumerator enumerator = default(List<Type>.Enumerator);
			Class92 class12 = default(Class92);
			byte byte_ = default(byte);
			while (true)
			{
				Enum25 enum25_ = class80_0.enum25_0;
				while (true)
				{
					IL_0ce2:
					Class91 class2;
					int num4;
					Class90 class7;
					Array obj2;
					int num5;
					bool num6;
					Array obj6;
					int num7;
					int num9;
					int num10;
					switch (enum25_)
					{
					case (Enum25)164:
						class2 = smethod_1(class107_0.method_4());
						num = 810;
						while (true)
						{
							if (num != 810)
							{
								if (num != 1791)
								{
									break;
								}
								switch (num)
								{
								case 453:
									goto IL_0ce2;
								case 454:
									goto end_IL_0ce4;
								case 3:
									goto IL_1cec;
								case 6:
									goto IL_1cf9;
								case 11:
									goto IL_1d29;
								case 26:
									goto IL_1d42;
								case 29:
									goto IL_1d64;
								case 31:
									goto IL_1d7a;
								case 37:
									goto IL_1d87;
								case 53:
									goto IL_1d9e;
								case 43:
									goto IL_1db0;
								case 54:
									return;
								case 55:
									goto IL_1dbe;
								case 56:
									goto IL_1dcb;
								case 57:
									goto IL_1de4;
								case 59:
									goto IL_1e02;
								case 60:
									goto IL_1e0f;
								case 71:
									goto IL_1e1c;
								case 74:
									goto IL_1e4f;
								case 77:
									goto IL_1e82;
								case 80:
									goto IL_1e94;
								case 94:
									goto IL_1eac;
								case 95:
									goto IL_1eba;
								case 97:
									goto IL_1ed9;
								case 102:
									goto IL_1f0a;
								case 103:
									goto IL_1f27;
								case 104:
									return;
								case 110:
									goto IL_1f3f;
								case 113:
									goto IL_1f4c;
								case 125:
									goto IL_1f6a;
								case 128:
									goto IL_1f76;
								case 121:
									goto IL_1fa4;
								case 131:
									goto IL_1fcc;
								case 135:
									goto IL_1fd6;
								case 139:
									goto IL_1fe3;
								case 151:
									goto IL_1ffb;
								case 153:
									goto IL_200d;
								case 155:
									goto IL_201a;
								case 158:
									return;
								case 161:
									goto IL_2028;
								case 133:
									goto IL_202f;
								case 164:
									goto IL_203c;
								case 75:
									goto IL_2040;
								case 165:
									goto IL_205a;
								case 167:
									return;
								case 174:
									return;
								case 175:
									goto IL_207a;
								case 82:
									goto IL_208c;
								case 180:
									goto IL_2099;
								case 190:
									goto IL_20b7;
								case 200:
									goto IL_20cc;
								case 202:
									goto IL_20d8;
								case 203:
									goto IL_20de;
								case 204:
									return;
								case 206:
									goto IL_20f3;
								case 207:
									goto IL_2100;
								case 199:
									goto IL_2109;
								case 209:
									goto IL_2116;
								case 211:
									goto IL_212d;
								case 215:
									goto IL_213a;
								case 51:
									goto IL_2141;
								case 221:
									goto IL_2158;
								case 223:
									goto IL_2165;
								case 232:
									goto IL_2178;
								case 233:
									goto IL_218f;
								case 235:
									goto IL_21a1;
								case 148:
									goto IL_21a8;
								case 237:
									goto IL_21ae;
								case 231:
									goto IL_21c0;
								case 17:
									goto IL_21c7;
								case 251:
									goto IL_21d4;
								case 256:
									goto IL_21eb;
								case 257:
									goto IL_21f8;
								case 262:
									goto IL_220a;
								case 269:
									goto IL_2210;
								case 275:
									goto IL_221e;
								case 65:
									goto IL_2225;
								case 277:
									return;
								case 118:
								case 278:
									goto IL_222c;
								case 137:
									goto IL_2230;
								case 280:
									goto IL_223f;
								case 281:
									goto IL_2256;
								case 282:
									return;
								case 288:
									goto IL_226e;
								case 290:
									return;
								case 291:
									goto IL_2289;
								case 194:
									return;
								case 292:
									return;
								case 293:
									goto IL_229d;
								case 160:
									goto IL_22b5;
								case 294:
									return;
								case 299:
									goto IL_22c2;
								case 301:
									goto IL_22d7;
								case 171:
									return;
								case 308:
									goto IL_22f1;
								case 312:
									goto IL_2302;
								case 316:
									goto IL_2319;
								case 186:
									return;
								case 318:
									goto IL_232c;
								case 320:
									return;
								case 322:
									goto IL_234e;
								case 295:
									goto IL_2367;
								case 178:
									return;
								case 324:
									goto IL_237b;
								case 181:
									goto IL_238b;
								case 255:
									return;
								case 325:
									goto IL_23a0;
								case 327:
									goto IL_23c2;
								case 18:
									return;
								case 159:
								case 334:
									goto IL_23f0;
								case 335:
									return;
								case 338:
									goto IL_23f7;
								case 342:
									goto IL_240e;
								case 345:
									goto IL_2425;
								case 349:
									goto IL_243d;
								case 350:
									goto IL_2454;
								case 355:
									goto IL_2461;
								case 64:
									goto IL_2465;
								case 259:
									goto IL_246b;
								case 264:
									return;
								case 357:
									goto IL_247e;
								case 363:
									goto IL_2496;
								case 364:
									goto IL_24c9;
								case 195:
									return;
								case 365:
									goto IL_24e3;
								case 304:
									goto IL_24e7;
								case 366:
									goto IL_2504;
								case 48:
									goto IL_2511;
								case 234:
									goto IL_251a;
								case 372:
									goto IL_2529;
								case 373:
									goto IL_2540;
								case 272:
									goto IL_2552;
								case 33:
									return;
								case 378:
									goto IL_25b6;
								case 380:
									goto IL_25be;
								case 383:
								case 393:
									goto IL_25ce;
								case 395:
									goto IL_25d4;
								case 359:
								case 400:
									goto IL_25e1;
								case 402:
									goto IL_25e7;
								case 210:
									goto IL_2600;
								case 403:
									goto IL_2633;
								case 168:
									goto IL_263a;
								case 405:
									goto IL_2642;
								case 15:
									goto IL_264f;
								case 339:
									return;
								case 192:
								case 406:
									goto IL_2664;
								case 409:
									goto IL_266a;
								case 411:
									goto IL_2681;
								case 416:
									goto IL_2687;
								case 398:
									goto IL_26b5;
								case 263:
									return;
								case 419:
									goto IL_26d2;
								case 300:
									goto IL_26d6;
								case 425:
									goto IL_26f3;
								case 222:
									goto IL_26ff;
								case 427:
									goto IL_2712;
								case 307:
									goto IL_2716;
								case 429:
									goto IL_2733;
								case 430:
									goto IL_2755;
								case 2:
									return;
								case 431:
									goto IL_2768;
								case 436:
									goto IL_2776;
								case 205:
									goto IL_2786;
								case 437:
									return;
								case 438:
									goto end_IL_0cd0;
								case 439:
									goto IL_27a8;
								case 442:
									goto IL_27c7;
								case 397:
									goto IL_27d9;
								case 286:
									goto IL_27e9;
								case 58:
									goto IL_27f0;
								case 407:
									return;
								case 444:
									goto IL_2805;
								case 449:
									return;
								case 451:
									goto IL_2818;
								case 458:
									return;
								case 462:
									return;
								case 463:
									goto IL_2831;
								case 253:
									goto IL_285f;
								case 467:
									return;
								case 468:
									return;
								case 471:
									goto IL_2883;
								case 472:
									goto IL_28c6;
								case 473:
									goto IL_28e8;
								case 108:
									goto IL_28f5;
								case 476:
									return;
								case 477:
									return;
								case 480:
									return;
								case 483:
									goto IL_2906;
								case 484:
									goto IL_2940;
								case 488:
									goto IL_294d;
								case 381:
									goto IL_2956;
								case 107:
									goto IL_2963;
								case 485:
									goto IL_296c;
								case 8:
									goto IL_2970;
								case 250:
								case 258:
									goto IL_2977;
								case 169:
									goto IL_2985;
								case 490:
									goto IL_299d;
								case 285:
									goto IL_29a1;
								case 84:
									return;
								case 494:
									return;
								case 495:
									goto IL_29bb;
								case 497:
									return;
								case 498:
									goto IL_29c2;
								case 499:
									goto IL_29ec;
								case 428:
									goto IL_29f9;
								case 144:
									goto IL_2a03;
								case 173:
									goto IL_2a0a;
								case 360:
									goto IL_2a1d;
								case 426:
									return;
								case 502:
									goto IL_2a36;
								case 162:
									return;
								case 505:
									goto IL_2a4b;
								case 506:
									goto IL_2a5b;
								case 479:
									goto IL_2a7b;
								case 507:
									return;
								case 511:
									goto IL_2aa8;
								case 123:
									goto IL_2aac;
								case 461:
									return;
								case 517:
									goto IL_2acb;
								case 389:
								case 435:
									goto IL_2ad4;
								case 306:
									goto IL_2ae9;
								case 52:
									return;
								case 518:
									return;
								case 521:
									return;
								case 524:
									goto IL_2af9;
								case 14:
									goto IL_2b0b;
								case 448:
									goto IL_2b0f;
								case 525:
									goto IL_2b1c;
								case 527:
									goto IL_2b29;
								case 530:
									goto IL_2b47;
								case 134:
									goto IL_2b59;
								case 531:
									goto IL_2b66;
								case 145:
									return;
								case 532:
									goto IL_2b79;
								case 417:
									goto IL_2b7d;
								case 536:
									goto IL_2b9a;
								case 487:
									goto IL_2bac;
								case 76:
									goto IL_2bb3;
								case 303:
									goto IL_2bba;
								case 230:
									return;
								case 538:
									goto IL_2bd6;
								case 361:
									goto IL_2bda;
								case 539:
									goto IL_2bf7;
								case 328:
									goto IL_2c00;
								case 540:
									goto IL_2c0d;
								case 445:
									goto IL_2c1f;
								case 201:
									goto IL_2c23;
								case 534:
									goto IL_2c27;
								case 548:
									goto IL_2c46;
								case 549:
									goto IL_2c59;
								case 382:
									goto IL_2c6b;
								case 551:
									goto IL_2c78;
								case 557:
									return;
								case 558:
									return;
								case 559:
									goto IL_2c80;
								case 124:
									return;
								case 562:
									goto IL_2ca4;
								case 79:
									return;
								case 564:
									return;
								case 567:
									goto IL_2cc2;
								case 573:
									goto IL_2cd9;
								case 576:
									return;
								case 580:
									goto IL_2cf7;
								case 420:
									goto IL_2cfb;
								case 583:
									goto IL_2d18;
								case 329:
									goto IL_2d29;
								case 585:
									goto IL_2d3f;
								case 99:
									goto IL_2d43;
								case 475:
									goto IL_2d4e;
								case 92:
									return;
								case 503:
									goto IL_2d60;
								case 379:
								case 565:
									goto IL_2d76;
								case 189:
									goto IL_2d84;
								case 242:
									return;
								case 587:
									goto IL_2d96;
								case 369:
									goto IL_2da8;
								case 225:
									goto IL_2dac;
								case 261:
									goto IL_2db0;
								case 552:
									return;
								case 106:
									goto IL_2dc5;
								case 404:
									goto IL_2dcb;
								case 370:
									goto IL_2dd4;
								case 39:
									goto IL_2dde;
								case 554:
								case 589:
									goto IL_2dee;
								case 156:
									goto IL_2df9;
								case 4:
									goto IL_2e00;
								case 590:
									goto IL_2e09;
								case 591:
									goto IL_2e0f;
								case 592:
									goto IL_2e21;
								case 265:
									goto IL_2e2a;
								case 105:
									goto IL_2e2e;
								case 582:
									goto IL_2e37;
								case 67:
									goto IL_2e3b;
								case 227:
									return;
								case 85:
									goto IL_2e5e;
								case 63:
									goto IL_2e6a;
								case 593:
									goto IL_2e84;
								case 348:
									return;
								case 595:
									goto IL_2e99;
								case 319:
									return;
								case 598:
									goto IL_2eab;
								case 601:
									return;
								case 602:
									goto IL_2eca;
								case 597:
									return;
								case 605:
									return;
								case 607:
									return;
								case 608:
									goto IL_2edf;
								case 569:
									goto IL_2ee8;
								case 154:
									goto IL_2efa;
								case 61:
									goto IL_2f09;
								case 541:
									goto IL_2f0c;
								case 611:
									goto IL_2f1e;
								case 515:
									return;
								case 615:
									goto IL_2f38;
								case 616:
									return;
								case 617:
									goto IL_2f46;
								case 575:
									goto IL_2f4f;
								case 578:
									goto IL_2fac;
								case 309:
									return;
								case 410:
								case 618:
									goto IL_2fcd;
								case 619:
									goto IL_2fd3;
								case 333:
									return;
								case 620:
									goto IL_2fed;
								case 187:
									goto IL_2ffc;
								case 623:
									goto IL_300e;
								case 586:
									goto IL_3049;
								case 142:
									return;
								case 443:
								case 626:
									goto IL_305e;
								case 627:
									goto IL_3064;
								case 628:
									goto IL_306a;
								case 610:
									goto IL_308c;
								case 229:
								case 374:
									return;
								case 630:
									goto IL_30a0;
								case 244:
								case 422:
									return;
								case 632:
									return;
								case 633:
									goto IL_30b5;
								case 140:
									goto IL_30c7;
								case 535:
									goto IL_30cb;
								case 566:
									goto IL_30cf;
								case 116:
									return;
								case 414:
									goto IL_30e8;
								case 634:
									goto IL_30ee;
								case 386:
									return;
								case 639:
									goto IL_30fc;
								case 179:
									return;
								case 641:
									return;
								case 643:
									goto IL_311a;
								case 240:
									return;
								case 644:
									return;
								case 647:
									return;
								case 649:
									return;
								case 650:
									goto IL_3132;
								case 651:
									goto IL_313f;
								case 652:
									goto IL_3145;
								case 362:
									goto IL_314c;
								case 655:
									goto IL_3152;
								case 238:
									goto IL_315b;
								case 512:
									goto IL_3162;
								case 35:
									goto IL_3177;
								case 656:
									goto IL_3184;
								case 73:
									goto IL_31cd;
								case 543:
								case 599:
									return;
								case 658:
									goto IL_31e1;
								case 465:
									goto IL_31e5;
								case 32:
									goto IL_31eb;
								case 659:
									goto IL_3202;
								case 662:
									goto IL_3210;
								case 570:
								case 663:
									goto IL_321d;
								case 664:
									goto IL_3223;
								case 170:
									goto IL_322f;
								case 86:
									goto IL_3236;
								case 584:
									return;
								case 665:
									goto IL_3249;
								case 326:
									return;
								case 344:
								case 667:
									return;
								case 668:
									goto IL_326b;
								case 434:
									return;
								case 669:
									goto IL_327f;
								case 636:
									goto IL_3288;
								case 249:
									goto IL_328f;
								case 577:
									goto IL_32a2;
								case 670:
									goto IL_32af;
								case 226:
									return;
								case 671:
									goto IL_32c4;
								case 553:
									goto IL_32c8;
								case 489:
									return;
								case 672:
									goto IL_32e1;
								case 146:
								case 482:
									goto IL_32e5;
								case 260:
									goto IL_32eb;
								case 197:
									return;
								case 673:
									goto IL_3300;
								case 212:
									goto IL_332e;
								case 28:
									return;
								case 674:
									goto IL_334f;
								case 331:
									goto IL_3353;
								case 675:
									goto IL_3370;
								case 16:
									goto IL_337d;
								case 352:
									goto IL_338f;
								case 296:
								case 579:
									goto IL_3393;
								case 115:
									goto IL_339c;
								case 172:
									goto IL_33a5;
								case 637:
									goto IL_33b5;
								case 391:
									goto IL_33c2;
								case 496:
									goto IL_33cb;
								case 469:
								case 481:
									goto IL_33d4;
								case 676:
									goto IL_33e4;
								case 441:
									goto IL_33ed;
								case 23:
								case 561:
									goto IL_33f6;
								case 284:
									goto IL_3402;
								case 243:
									goto IL_340a;
								case 529:
									goto IL_341f;
								case 677:
									goto IL_3438;
								case 678:
									goto IL_344f;
								case 653:
									goto IL_345a;
								case 239:
									goto IL_3467;
								case 30:
									return;
								case 544:
									goto IL_347c;
								case 679:
									return;
								case 680:
									return;
								case 682:
									goto IL_3484;
								case 7:
									return;
								case 684:
									goto IL_3497;
								case 45:
									goto IL_349f;
								case 460:
								case 550:
									goto IL_34a3;
								case 478:
									goto IL_34af;
								case 332:
									goto IL_34b8;
								case 276:
									goto IL_34c5;
								case 588:
								case 687:
									goto IL_34d8;
								case 689:
									goto IL_34e9;
								case 149:
									return;
								case 287:
								case 691:
									goto IL_34fd;
								case 93:
									goto IL_3504;
								case 49:
									goto IL_3519;
								case 500:
									goto IL_3527;
								case 421:
									return;
								case 692:
									return;
								case 693:
									return;
								case 694:
									goto IL_3544;
								case 423:
									goto IL_3548;
								case 130:
									goto IL_3551;
								case 695:
									goto IL_3565;
								case 408:
									return;
								case 697:
									goto IL_3578;
								case 228:
									goto IL_357c;
								case 666:
									return;
								case 698:
									goto IL_35d8;
								case 147:
								case 572:
									goto IL_35e6;
								case 685:
									return;
								case 699:
									goto IL_35f9;
								case 315:
									goto IL_35fd;
								case 274:
									return;
								case 700:
									goto IL_3616;
								case 218:
									return;
								case 701:
									goto IL_362b;
								case 224:
									return;
								case 702:
									goto IL_3636;
								case 629:
									goto IL_364e;
								case 69:
									return;
								case 703:
									goto IL_3672;
								case 114:
									goto IL_3676;
								case 127:
									return;
								case 346:
									goto IL_368f;
								case 705:
									goto IL_3695;
								case 62:
									goto IL_36a0;
								case 72:
								case 596:
									return;
								case 706:
									goto IL_36b4;
								case 516:
									goto IL_36b8;
								case 385:
									return;
								case 132:
								case 707:
									goto IL_36d1;
								case 708:
									goto IL_36d7;
								case 501:
									goto IL_36db;
								case 152:
									return;
								case 710:
									return;
								case 711:
									goto IL_36f5;
								case 712:
									goto IL_36fb;
								case 198:
									goto IL_3709;
								case 336:
									goto IL_3717;
								case 624:
									goto IL_372a;
								case 245:
								case 661:
									return;
								case 714:
									goto IL_3736;
								case 330:
									goto IL_373a;
								case 323:
									return;
								case 715:
									goto IL_3753;
								case 718:
									goto IL_376c;
								case 40:
									goto IL_3770;
								case 396:
									goto IL_3779;
								case 343:
									goto IL_377d;
								case 191:
									return;
								case 600:
									goto IL_3797;
								case 219:
									goto IL_37a9;
								case 509:
									goto IL_37b7;
								case 604:
									return;
								case 719:
									goto IL_37d1;
								case 337:
									return;
								case 371:
								case 721:
									goto IL_37ee;
								case 241:
									goto IL_37f2;
								case 387:
								case 683:
									return;
								case 722:
									goto IL_3806;
								case 248:
									return;
								case 724:
									goto IL_3822;
								case 38:
									return;
								case 727:
									goto IL_3837;
								case 574:
									goto IL_383b;
								case 394:
									return;
								case 603:
								case 730:
									return;
								case 732:
									goto IL_3855;
								case 523:
									goto IL_3859;
								case 642:
									return;
								case 733:
									goto IL_3874;
								case 508:
									goto IL_3878;
								case 367:
									goto IL_387c;
								case 648:
									goto IL_3885;
								case 526:
									goto IL_3893;
								case 283:
									return;
								case 89:
									goto IL_38ae;
								case 713:
									goto IL_38b4;
								case 236:
								case 310:
								case 734:
									goto IL_38cb;
								case 638:
									return;
								case 736:
									goto IL_38ec;
								case 537:
									goto IL_38fa;
								case 46:
									goto IL_390d;
								case 457:
									goto IL_3920;
								case 87:
								case 213:
									return;
								case 737:
									goto IL_392c;
								case 10:
									goto IL_393e;
								case 273:
									return;
								case 738:
									goto IL_3974;
								case 735:
									goto IL_3980;
								case 739:
									goto IL_3993;
								case 513:
									return;
								case 631:
								case 740:
									goto IL_39a7;
								case 208:
									goto IL_39ab;
								case 621:
									goto IL_39b4;
								case 741:
									goto IL_39ba;
								case 305:
									goto IL_39c8;
								case 81:
									goto IL_39d0;
								case 528:
									goto IL_39d9;
								case 270:
									goto IL_3a02;
								case 720:
									return;
								case 742:
									return;
								case 746:
									goto IL_3a19;
								case 100:
									return;
								case 747:
									goto IL_3a2b;
								case 138:
									goto IL_3a34;
								case 21:
									goto IL_3a38;
								case 176:
									goto IL_3a41;
								case 166:
									goto IL_3a45;
								case 622:
									return;
								case 136:
								case 399:
									goto IL_3a5f;
								case 34:
									goto IL_3a63;
								case 5:
									goto IL_3a6c;
								case 581:
									goto IL_3a7a;
								case 547:
									return;
								case 44:
									goto IL_3a94;
								case 750:
									goto IL_3a9a;
								case 545:
									return;
								case 751:
									goto IL_3aad;
								case 117:
									return;
								case 753:
									return;
								case 754:
									goto IL_3ac1;
								case 268:
								case 418:
									goto IL_3aca;
								case 731:
									goto IL_3ad0;
								case 744:
									goto IL_3ade;
								case 129:
									return;
								case 122:
								case 522:
								case 755:
									goto IL_3af8;
								case 756:
									goto IL_3b0b;
								case 279:
									goto IL_3b0f;
								case 688:
									goto IL_3b1e;
								case 289:
									return;
								case 88:
									goto IL_3b2c;
								case 22:
									goto IL_3b3b;
								case 412:
									return;
								case 546:
									goto IL_3b59;
								case 614:
									goto IL_3b64;
								case 401:
									return;
								case 609:
								case 758:
									goto IL_3b6e;
								case 759:
									return;
								case 762:
									return;
								case 764:
									return;
								case 765:
									goto IL_3b77;
								case 24:
									return;
								case 767:
									goto IL_3b8b;
								case 542:
									return;
								case 768:
									goto IL_3b9e;
								case 353:
									return;
								case 769:
									goto IL_3bb1;
								case 25:
									return;
								case 770:
									return;
								case 771:
									goto IL_3bc4;
								case 313:
									return;
								case 773:
									goto IL_3bd7;
								case 0:
									return;
								case 775:
									goto IL_3bea;
								case 752:
									return;
								case 358:
								case 776:
									goto IL_3bfd;
								case 183:
								case 777:
									goto IL_3c03;
								case 120:
									return;
								case 778:
									goto IL_3c1a;
								case 188:
									return;
								case 779:
									return;
								case 375:
								case 780:
									goto IL_3c2e;
								case 492:
									goto IL_3c3b;
								case 20:
									return;
								case 782:
									goto IL_3c52;
								case 214:
									goto IL_3c5d;
								case 452:
									return;
								case 783:
									return;
								case 785:
									goto IL_3c6c;
								case 70:
									goto IL_3c76;
								case 388:
									goto IL_3c7a;
								case 725:
									goto IL_3c8c;
								case 376:
								case 696:
									goto IL_3c94;
								case 96:
									return;
								case 787:
									return;
								case 788:
									return;
								case 789:
									return;
								case 790:
									goto IL_3ca9;
								case 432:
									goto IL_3cb0;
								case 514:
									goto IL_3cb3;
								case 12:
									goto IL_3ce6;
								case 533:
									return;
								case 150:
									goto IL_3cf9;
								case 791:
									return;
								case 792:
									return;
								case 13:
								case 793:
									goto IL_3d1b;
								case 794:
									goto IL_3d21;
								case 786:
									goto IL_3d25;
								case 447:
									return;
								case 795:
									return;
								case 36:
								case 520:
								case 796:
									goto IL_3d3f;
								case 347:
									return;
								case 247:
								case 797:
									goto IL_3d4a;
								case 640:
									goto IL_3d4e;
								case 709:
									goto IL_3d5e;
								case 42:
									goto IL_3d6c;
								case 83:
									return;
								case 799:
									goto IL_3d8c;
								case 646:
									goto IL_3d95;
								case 384:
									goto IL_3da3;
								case 704:
									return;
								case 493:
									goto IL_3dbd;
								case 800:
									goto IL_3dc3;
								case 456:
									goto IL_3dcb;
								case 716:
									goto IL_3dd7;
								case 466:
									return;
								case 801:
									goto IL_3de5;
								case 450:
									goto IL_3df6;
								case 351:
									goto IL_3e17;
								case 340:
									goto IL_3e1a;
								case 686:
									return;
								case 802:
									goto IL_3e2e;
								case 761:
									goto IL_3e3b;
								case 141:
									goto IL_3e49;
								case 654:
									goto IL_3e5d;
								case 748:
									goto IL_3e68;
								case 193:
									goto IL_3e75;
								case 314:
									goto IL_3e88;
								case 723:
									goto IL_3e8a;
								case 510:
									goto IL_3e94;
								case 111:
									goto IL_3ea7;
								case 446:
									goto IL_3eb2;
								case 246:
									goto IL_3ec3;
								case 41:
									goto IL_3ec9;
								case 356:
									goto IL_3ed2;
								case 766:
									goto IL_3edb;
								case 90:
									goto IL_3ee7;
								case 109:
									goto IL_3ef3;
								case 635:
									goto IL_3eff;
								case 19:
								case 612:
								case 781:
									goto IL_3f1f;
								case 504:
									goto IL_3f2c;
								case 760:
									goto IL_3f41;
								case 690:
									goto IL_3f45;
								case 184:
									goto IL_3f4c;
								case 216:
									goto IL_3f68;
								case 571:
									goto IL_3f70;
								case 47:
									goto IL_3f84;
								case 98:
								case 745:
									goto IL_3f8e;
								case 717:
									goto IL_3fa0;
								case 311:
									goto IL_3fa3;
								case 560:
									goto IL_3fa7;
								case 594:
									goto IL_3fb2;
								case 126:
								case 196:
									goto IL_3fbe;
								case 556:
									goto IL_3fc1;
								case 91:
									goto IL_3fc5;
								case 182:
									goto IL_3fd4;
								case 459:
									goto IL_3fe7;
								case 157:
									goto IL_3ffb;
								case 163:
									goto IL_3fff;
								case 68:
									goto IL_400d;
								case 743:
									goto IL_4019;
								case 220:
									goto IL_403e;
								case 271:
								case 645:
									goto IL_404a;
								case 464:
									goto IL_4071;
								case 433:
								case 568:
								case 784:
									goto IL_4094;
								case 341:
								case 681:
									goto IL_40a1;
								case 519:
									goto IL_40ac;
								case 613:
									return;
								case 803:
									goto IL_40c6;
								case 321:
									goto IL_40d8;
								case 555:
									goto IL_40dc;
								case 798:
									goto IL_40e0;
								case 763:
									return;
								case 101:
									goto IL_4129;
								case 749:
									return;
								case 729:
									goto IL_4158;
								case 217:
									goto IL_416a;
								case 772:
									goto IL_416e;
								case 390:
									goto IL_4172;
								case 298:
									return;
								case 413:
									goto IL_4187;
								case 317:
									goto IL_419a;
								case 774:
									goto IL_41ac;
								case 50:
									return;
								case 470:
									goto IL_41fc;
								case 563:
									goto IL_4200;
								case 27:
									goto IL_4209;
								case 185:
								case 440:
									return;
								case 354:
									goto IL_4230;
								case 177:
									goto IL_4252;
								case 78:
									goto IL_4256;
								case 455:
									goto IL_425f;
								case 254:
								case 606:
									goto IL_4268;
								case 415:
									goto IL_4275;
								case 302:
								case 726:
									goto IL_427e;
								case 252:
									goto IL_4288;
								case 486:
									goto IL_4298;
								case 9:
								case 66:
								case 474:
									goto IL_42a7;
								case 119:
									return;
								case 660:
									goto IL_42c7;
								case 757:
									goto IL_42f5;
								case 143:
									return;
								case 728:
									return;
								case 424:
									goto IL_4331;
								case 297:
									goto IL_4335;
								case 392:
									goto IL_433b;
								case 657:
									return;
								case 368:
									goto IL_435b;
								case 625:
									return;
								case 377:
									goto IL_43b1;
								case 112:
									return;
								case 1:
									goto IL_43d6;
								case 266:
									goto IL_43e8;
								case 267:
									goto IL_4416;
								case 491:
									return;
								}
								continue;
							}
							obj = ((Array)class107_0.method_4().vmethod_4(null)).GetValue(class2.vmethod_19().struct74_0.int_0);
							goto IL_4129;
							IL_4129:
							class107_0.method_2(Class90.smethod_1(typeof(uint), obj));
							return;
							continue;
							end_IL_0cd0:
							break;
						}
						goto IL_2791;
					default:
						return;
					case (Enum25)0:
						@class = class107_0.method_4();
						goto IL_234e;
					case (Enum25)1:
						class2 = smethod_1(class107_0.method_4());
						goto IL_2cf7;
					case (Enum25)2:
						class2 = smethod_1(class107_0.method_4());
						goto IL_2b9a;
					case (Enum25)3:
						return;
					case (Enum25)4:
						class2 = smethod_1(class107_0.method_4());
						goto IL_35f9;
					case (Enum25)5:
						class2 = smethod_1(class107_0.method_4());
						goto IL_3210;
					case (Enum25)6:
						intPtr = Marshal.AllocHGlobal((class107_0.method_4() as Class91).vmethod_19().struct74_0.int_0);
						goto IL_22f1;
					case (Enum25)7:
						@class = class107_0.method_4();
						goto IL_2210;
					case (Enum25)8:
						@class = class107_0.method_4();
						goto IL_3152;
					case (Enum25)9:
						class2 = smethod_1(class107_0.method_4());
						goto IL_2af9;
					case (Enum25)12:
						class2 = smethod_1(class107_0.method_4());
						goto IL_21ae;
					case (Enum25)13:
						class2 = smethod_1(class107_0.method_4());
						goto IL_299d;
					case (Enum25)14:
						class107_0.method_2(new Class95((float)object_0));
						return;
					case (Enum25)15:
						class2 = smethod_1(class107_0.method_4());
						goto IL_30b5;
					case (Enum25)17:
						type = Class79.smethod_2((int)object_0);
						goto IL_2099;
					case (Enum25)18:
						class2 = smethod_1(class107_0.method_4());
						goto IL_2aa8;
					case (Enum25)19:
						class2 = smethod_1(class107_0.method_4());
						goto IL_300e;
					case (Enum25)20:
						@class = class107_0.method_4();
						goto IL_2a5b;
					case (Enum25)21:
						class2 = smethod_1(class107_0.method_4());
						goto IL_2b1c;
					case (Enum25)22:
						@class = class107_0.method_4();
						goto IL_23a0;
					case (Enum25)23:
						fieldInfo = Class79.smethod_4((int)object_0);
						goto IL_2c80;
					case (Enum25)24:
						class2 = smethod_1(class107_0.method_4());
						goto IL_243d;
					case (Enum25)25:
						class2 = smethod_1(class107_0.method_4());
						goto IL_21a1;
					case (Enum25)26:
						class2 = smethod_1(class107_0.method_4());
						goto IL_1dbe;
					case (Enum25)27:
						class2 = smethod_1(class107_0.method_4());
						goto IL_26d2;
					case (Enum25)28:
						class6 = (smethod_1(class107_0.method_3()) ?? throw new ArithmeticException(((Enum27)0/*cast due to .constrained prefix*/).ToString())) as Class95;
						goto IL_3132;
					case (Enum25)29:
						class2 = smethod_1(class107_0.method_4());
						goto IL_1e0f;
					case (Enum25)30:
						class2 = smethod_1(class107_0.method_4());
						goto IL_36b4;
					case (Enum25)31:
						@class = class107_0.method_4();
						goto IL_25e7;
					case (Enum25)32:
						class2 = smethod_1(class107_0.method_4());
						goto IL_21eb;
					case (Enum25)33:
						class2 = smethod_1(class107_0.method_4());
						goto IL_1d9e;
					case (Enum25)34:
						class2 = smethod_1(class107_0.method_4());
						goto IL_3300;
					case (Enum25)35:
						Class79.smethod_2((int)object_0);
						goto IL_2529;
					case (Enum25)36:
						@class = class107_0.method_4();
						num = 738;
						goto IL_3974;
					case (Enum25)37:
						class2 = smethod_1(class107_0.method_4());
						goto IL_3736;
					case (Enum25)38:
						@class = class107_0.method_4();
						num = 436;
						goto IL_2776;
					case (Enum25)39:
						class107_0.method_2(((Class91)class107_0.method_4()).vmethod_56());
						return;
					case (Enum25)40:
						oXhYcskyWej(bool_4: true);
						return;
					case (Enum25)42:
						@class = class107_0.method_4();
						goto IL_1d42;
					case (Enum25)44:
						@class = class107_0.method_4();
						goto IL_3484;
					case (Enum25)45:
						class2 = smethod_1(class107_0.method_4());
						goto IL_2906;
					case (Enum25)46:
						array2 = (int[])object_0;
						goto IL_2256;
					case (Enum25)47:
						if (class107_0.method_4().vmethod_6(class107_0.method_4()))
						{
							num = 345;
							goto IL_2425;
						}
						return;
					case (Enum25)49:
						@class = class107_0.method_4();
						goto IL_3202;
					case (Enum25)50:
					{
						Type elementType = Class79.smethod_2((int)object_0);
						class2 = smethod_1(class107_0.method_4());
						array = Array.CreateInstance(elementType, class2.vmethod_19().struct74_0.int_0);
						goto IL_2cc2;
					}
					case (Enum25)51:
						@class = class107_0.method_4();
						goto IL_2bf7;
					case (Enum25)52:
						obj = object_2;
						goto IL_3578;
					case (Enum25)53:
						type = Class79.smethod_2((int)object_0);
						goto IL_218f;
					case (Enum25)54:
						@class = class107_0.method_4();
						num = 669;
						goto IL_327f;
					case (Enum25)55:
						num2 = (int)object_0;
						goto IL_1ed9;
					case (Enum25)56:
						class2 = smethod_1(class107_0.method_4());
						goto IL_207a;
					case (Enum25)57:
						class2 = smethod_1(class107_0.method_4());
						goto IL_1d7a;
					case (Enum25)58:
						class2 = smethod_1(class107_0.method_4());
						goto IL_2712;
					case (Enum25)59:
						fieldInfo = Class79.smethod_4((int)object_0);
						goto IL_1f4c;
					case (Enum25)60:
					{
						Class90 class5 = class107_0.method_4();
						@class = class107_0.method_4();
						if (class5.vmethod_5(@class))
						{
							goto IL_1e94;
						}
						return;
					}
					case (Enum25)61:
						class2 = smethod_1(class107_0.method_4());
						goto IL_20de;
					case (Enum25)63:
						fieldInfo = Class79.smethod_4((int)object_0);
						goto IL_1fe3;
					case (Enum25)65:
						class2 = smethod_1(class107_0.method_4());
						goto IL_2461;
					case (Enum25)66:
						class2 = smethod_1(class107_0.method_4());
						goto IL_1e1c;
					case (Enum25)67:
						throw (Exception)class107_0.method_4().vmethod_4(null);
					case (Enum25)69:
						oXhYcskyWej(bool_4: false);
						return;
					case (Enum25)70:
						class107_0.method_2(new Class93((long)object_0));
						num = 494;
						return;
					case (Enum25)71:
						class2 = smethod_1(class107_0.method_4());
						goto IL_2b47;
					case (Enum25)72:
						int_0 = (int)object_0 - 1;
						goto IL_20cc;
					case (Enum25)73:
						class2 = smethod_1(class107_0.method_4());
						goto IL_1e4f;
					case (Enum25)75:
						class2 = smethod_1(class107_0.method_4());
						goto IL_2454;
					case (Enum25)76:
						class2 = smethod_1(class107_0.method_4());
						goto IL_25d4;
					case (Enum25)77:
						class107_0.method_2(new Class92((int)object_0));
						return;
					case (Enum25)78:
						class2 = smethod_1(class107_0.method_4());
						goto IL_3837;
					case (Enum25)79:
						type = Class79.smethod_2((int)object_0);
						goto IL_2cd9;
					case (Enum25)81:
						class2 = smethod_1(class107_0.method_4());
						goto IL_2158;
					case (Enum25)82:
						array = (Array)class107_0.method_4().vmethod_4(null);
						goto IL_1f0a;
					case (Enum25)83:
						num2 = (int)object_0;
						goto IL_3ca9;
					case (Enum25)10:
					case (Enum25)84:
						type = Class79.smethod_2((int)object_0);
						num = 675;
						goto IL_3370;
					case (Enum25)85:
						class2 = class107_0.method_4() as Class91;
						goto IL_2302;
					case (Enum25)86:
						type = Class79.smethod_2((int)object_0);
						goto IL_1dcb;
					case (Enum25)87:
						class2 = smethod_1(class107_0.method_4());
						goto IL_1d87;
					case (Enum25)89:
						num2 = (int)object_0;
						goto IL_2540;
					case (Enum25)90:
						@class = class107_0.method_4();
						goto IL_28c6;
					case (Enum25)92:
						class2 = smethod_1(class107_0.method_4());
						goto IL_2d96;
					case (Enum25)93:
						class2 = smethod_1(class107_0.method_4());
						goto IL_203c;
					case (Enum25)94:
						class2 = smethod_1(class107_0.method_4());
						goto IL_40c6;
					case (Enum25)95:
						type = Class79.smethod_2((int)object_0);
						goto IL_29ec;
					case (Enum25)96:
						class2 = smethod_1(class107_0.method_4());
						goto IL_2c59;
					case (Enum25)97:
						class2 = smethod_1(class107_0.method_4());
						num = 3;
						goto IL_1cec;
					case (Enum25)98:
						class2 = smethod_1(class107_0.method_4());
						goto IL_2831;
					case (Enum25)99:
						class2 = class107_0.method_4() as Class91;
						goto IL_2178;
					case (Enum25)100:
						@class = class107_0.method_4();
						goto IL_22c2;
					case (Enum25)101:
						num2 = (int)object_0;
						goto IL_326b;
					case (Enum25)102:
						int_0 = (int)object_0 - 1;
						return;
					case (Enum25)103:
						@class = class107_0.method_4();
						goto IL_2100;
					case (Enum25)104:
						class2 = smethod_1(class107_0.method_4());
						goto IL_31e1;
					case (Enum25)106:
						fieldInfo = Class79.smethod_4((int)object_0);
						goto IL_1eba;
					case (Enum25)107:
						@class = class107_0.method_4();
						num = 767;
						goto IL_3b8b;
					case (Enum25)108:
						obj = object_2;
						num4 = 0;
						goto IL_25b7;
					case (Enum25)110:
						class2 = smethod_1(class107_0.method_4());
						num = 155;
						goto IL_201a;
					case (Enum25)111:
						class2 = smethod_1(class107_0.method_4());
						goto IL_36d7;
					case (Enum25)112:
						if (Class79.list_0.Count == 0)
						{
							goto IL_1cf9;
						}
						num = 498;
						goto IL_29c2;
					case (Enum25)113:
						class2 = smethod_1(class107_0.method_4());
						goto IL_334f;
					case (Enum25)114:
						num3 = (uint)smethod_0(Class79.smethod_2((int)object_0));
						goto IL_27a8;
					case (Enum25)115:
						@class = class107_0.method_4();
						goto IL_26f3;
					case (Enum25)116:
						constructorInfo = (ConstructorInfo)Class79.smethod_3((int)object_0);
						goto IL_2edf;
					case (Enum25)117:
						class2 = smethod_1(class107_0.method_4());
						goto IL_2496;
					case (Enum25)118:
						class2 = smethod_1(class107_0.method_4());
						goto IL_2bd6;
					case (Enum25)119:
						flag = false;
						goto IL_1e82;
					case (Enum25)120:
						@class = class107_0.method_4();
						goto IL_3184;
					case (Enum25)121:
						class107_0.method_2(class107_0.method_3());
						return;
					case (Enum25)122:
						@class = class107_0.method_4();
						goto IL_2733;
					case (Enum25)123:
						@class = class107_0.method_4();
						goto IL_22d7;
					case (Enum25)125:
						@class = class107_0.method_4();
						goto IL_21f8;
					case (Enum25)126:
						class2 = smethod_1(class107_0.method_4());
						goto IL_1de4;
					case (Enum25)127:
						class2 = smethod_1(class107_0.method_4());
						goto IL_23f7;
					case (Enum25)128:
						bool_3 = (bool)class107_0.method_4().vmethod_4(typeof(bool));
						goto IL_1f6a;
					case (Enum25)129:
						class2 = smethod_1(class107_0.method_4());
						num = 442;
						goto IL_27c7;
					case (Enum25)130:
						class107_0.method_2(class107_0.method_4().vmethod_8());
						num = 292;
						return;
					case (Enum25)131:
						fieldInfo = Class79.smethod_4((int)object_0);
						goto IL_205a;
					case (Enum25)132:
						num2 = (int)object_0;
						goto IL_25be;
					case (Enum25)133:
						@class = class107_0.method_4();
						goto IL_266a;
					case (Enum25)134:
						@class = class107_0.method_4();
						goto IL_3a2b;
					case (Enum25)135:
						class2 = smethod_1(class107_0.method_4());
						goto IL_2c0d;
					case (Enum25)136:
						@class = class107_0.method_4();
						goto IL_1ffb;
					case (Enum25)137:
						class2 = smethod_1(class107_0.method_4());
						goto IL_20f3;
					case (Enum25)138:
						class107_0.method_2(new Class95((double)object_0));
						return;
					case (Enum25)139:
						@class = class107_0.method_4();
						goto IL_1eac;
					case (Enum25)140:
						methodBase = Class79.smethod_3((int)object_0);
						num = 293;
						goto IL_229d;
					case (Enum25)141:
						bool_2 = true;
						return;
					case (Enum25)142:
						@class = class107_0.method_4();
						goto IL_2e21;
					case (Enum25)143:
						class2 = smethod_1(class107_0.method_4());
						goto IL_3d21;
					case (Enum25)144:
						num2 = (int)object_0;
						num = 11;
						goto IL_1d29;
					case (Enum25)146:
						@class = class107_0.method_4();
						goto IL_294d;
					case (Enum25)147:
						class2 = smethod_1(class107_0.method_4());
						goto IL_2687;
					case (Enum25)148:
						class2 = smethod_1(class107_0.method_4());
						goto IL_2b79;
					case (Enum25)150:
						class2 = smethod_1(class107_0.method_4());
						goto IL_1f76;
					case (Enum25)151:
						class2 = smethod_1(class107_0.method_4());
						goto IL_32c4;
					case (Enum25)11:
					case (Enum25)41:
					case (Enum25)62:
					case (Enum25)145:
					case (Enum25)149:
					case (Enum25)152:
						throw new Exception1();
					case (Enum25)153:
					{
						Class90 class3 = smethod_7(class107_0.method_4());
						@class = smethod_7(class107_0.method_4());
						if (class3.vmethod_5(@class))
						{
							num = 29;
							goto IL_1d64;
						}
						class107_0.method_2(new Class92(0));
						return;
					}
					case (Enum25)154:
						int_0 = -3;
						goto IL_2d18;
					case (Enum25)155:
						throw exception_0;
					case (Enum25)156:
						@class = class107_0.method_4();
						goto IL_306a;
					case (Enum25)158:
						class107_0.method_2(new Class102(null));
						return;
					case (Enum25)159:
						fieldInfo = Class79.smethod_4((int)object_0);
						goto IL_3993;
					case (Enum25)160:
						class2 = smethod_1(class107_0.method_4());
						goto IL_24e3;
					case (Enum25)161:
						@class = class107_0.method_4();
						goto IL_23c2;
					case (Enum25)162:
						class2 = smethod_1(class107_0.method_4());
						goto IL_1f27;
					case (Enum25)163:
						class2 = smethod_1(class107_0.method_4());
						goto IL_1e02;
					case (Enum25)124:
						goto IL_30fc;
					case (Enum25)165:
						class2 = smethod_1(class107_0.method_4());
						goto IL_4158;
					case (Enum25)16:
					case (Enum25)43:
					case (Enum25)64:
					case (Enum25)68:
					case (Enum25)74:
					case (Enum25)91:
					case (Enum25)157:
					case (Enum25)166:
						@class = class107_0.method_4();
						goto IL_419a;
					case (Enum25)167:
						@class = class107_0.method_4();
						goto IL_41fc;
					case (Enum25)48:
					case (Enum25)80:
					case (Enum25)88:
					case (Enum25)105:
					case (Enum25)109:
					case (Enum25)168:
						return;
					case (Enum25)169:
						type = Class79.smethod_2((int)object_0);
						goto IL_4230;
					case (Enum25)170:
						class2 = smethod_1(class107_0.method_4());
						goto IL_42c7;
					case (Enum25)171:
						class107_0.method_4();
						return;
					case (Enum25)172:
						class2 = smethod_1(class107_0.method_4());
						goto IL_4331;
					case (Enum25)173:
						num2 = (int)object_0;
						goto IL_435b;
					case (Enum25)174:
						@class = class107_0.method_4();
						goto IL_43b1;
					case (Enum25)175:
						{
							type = Class79.smethod_2((int)object_0);
							goto IL_43d6;
						}
						IL_2165:
						if (class4 != null)
						{
							goto IL_237b;
						}
						num = 393;
						goto IL_25ce;
						IL_1d42:
						if (smethod_1(class107_0.method_4()).vmethod_82(@class))
						{
							goto IL_3b77;
						}
						return;
						IL_237b:
						if (class2 != null)
						{
							goto IL_238b;
						}
						num = 383;
						goto IL_25ce;
						IL_3b77:
						int_0 = (int)object_0 - 1;
						return;
						IL_25ce:
						throw new Exception1();
						IL_238b:
						class107_0.method_2(class4.vmethod_75(class2));
						return;
						IL_1f0a:
						class107_0.method_2(new Class92(array.Length, (Enum23)5));
						return;
						IL_43d6:
						class2 = smethod_1(class107_0.method_4());
						goto IL_43e8;
						IL_43e8:
						obj = ((Array)class107_0.method_4().vmethod_4(null)).GetValue(class2.vmethod_19().struct74_0.int_0);
						goto IL_4416;
						IL_4416:
						class107_0.method_2(Class90.smethod_1(type, obj));
						return;
						IL_43b1:
						class107_0.method_4().vmethod_2(@class);
						return;
						IL_435b:
						class90_1[num2] = method_7(class107_0.method_4(), class85_0.list_1[num2].enum23_0, class85_0.list_1[num2].bool_0);
						return;
						IL_4331:
						if (class2 == null)
						{
							goto IL_4335;
						}
						goto IL_433b;
						IL_4335:
						throw new Exception1();
						IL_433b:
						class107_0.method_2(class2.vmethod_51());
						return;
						IL_42c7:
						obj = ((Array)class107_0.method_4().vmethod_4(null)).GetValue(class2.vmethod_19().struct74_0.int_0);
						goto IL_42f5;
						IL_42f5:
						class107_0.method_2(Class90.smethod_1(typeof(sbyte), obj));
						return;
						IL_4230:
						obj = ((class107_0.method_4() as Class96) ?? throw new Exception1()).vmethod_4(type);
						goto IL_4252;
						IL_1ed9:
						class107_0.method_2(new Class94(Class79.smethod_3(num2).MethodHandle.GetFunctionPointer()));
						num = 294;
						return;
						IL_1eba:
						class7 = class107_0.method_4();
						class7.vmethod_8();
						obj = class7.vmethod_4(null);
						goto IL_3753;
						IL_4252:
						if (obj != null)
						{
							goto IL_4256;
						}
						goto IL_4275;
						IL_4256:
						if (type.IsValueType)
						{
							goto IL_425f;
						}
						goto IL_4268;
						IL_425f:
						obj = smethod_10(obj);
						goto IL_4268;
						IL_4268:
						@class = Class90.smethod_1(type, obj);
						goto IL_42a7;
						IL_4275:
						if (!type.IsValueType)
						{
							goto IL_427e;
						}
						goto IL_4288;
						IL_427e:
						@class = new Class102(null);
						goto IL_42a7;
						IL_4288:
						obj = Activator.CreateInstance(type);
						num = 486;
						goto IL_4298;
						IL_4298:
						@class = Class90.smethod_1(type, obj);
						num = 66;
						goto IL_42a7;
						IL_42a7:
						class107_0.method_2(@class);
						return;
						IL_41fc:
						if (@class == null)
						{
							return;
						}
						goto IL_4200;
						IL_4200:
						if (!@class.vmethod_7())
						{
							return;
						}
						goto IL_4209;
						IL_4209:
						int_0 = (int)object_0 - 1;
						return;
						IL_419a:
						class2 = smethod_1(class107_0.method_4());
						goto IL_41ac;
						IL_41ac:
						obj2 = (Array)class107_0.method_4().vmethod_4(null);
						type = obj2.GetType().GetElementType();
						obj2.SetValue(@class.vmethod_4(type), class2.vmethod_19().struct74_0.int_0);
						return;
						IL_4158:
						class4 = smethod_1(class107_0.method_4());
						goto IL_416a;
						IL_416a:
						if (class4 != null)
						{
							goto IL_416e;
						}
						goto IL_4187;
						IL_416e:
						if (class2 != null)
						{
							goto IL_4172;
						}
						goto IL_4187;
						IL_4172:
						class107_0.method_2(class4.vmethod_64(class2));
						return;
						IL_4187:
						throw new Exception1();
						IL_40c6:
						class4 = smethod_1(class107_0.method_4());
						goto IL_40d8;
						IL_40d8:
						if (class4 != null)
						{
							goto IL_40dc;
						}
						goto IL_40f5;
						IL_40dc:
						if (class2 != null)
						{
							goto IL_40e0;
						}
						goto IL_40f5;
						IL_40e0:
						class107_0.method_2(class4.vmethod_57(class2));
						return;
						IL_40f5:
						throw new Exception1();
						IL_3d21:
						if (class2 == null)
						{
							throw new Exception1();
						}
						goto IL_3d25;
						IL_3d25:
						class107_0.method_2(class2.vmethod_38());
						return;
						IL_3753:
						class107_0.method_2(new Class99(fieldInfo, obj));
						return;
						IL_3ca9:
						if (Class79.bool_1)
						{
							goto IL_3cb0;
						}
						goto IL_3cf9;
						IL_3cb0:
						obj = null;
						goto IL_3cb3;
						IL_3cb3:
						try
						{
							obj = Class79.smethod_2(num2);
						}
						catch
						{
							try
							{
								obj = Class79.smethod_3(num2);
							}
							catch
							{
								try
								{
									obj = Class79.smethod_4(num2);
									goto end_IL_3cca;
								}
								catch
								{
									obj = Class79.smethod_5(num2);
									goto end_IL_3cca;
								}
								end_IL_3cca:;
							}
						}
						goto IL_3ce6;
						IL_3ce6:
						class107_0.method_2(new Class102(obj));
						return;
						IL_3cf9:
						class107_0.method_2(new Class102(Class79.smethod_5(num2)));
						num = 792;
						return;
						IL_3b8b:
						class107_0.method_4().vmethod_2(@class);
						return;
						IL_3a2b:
						class2 = smethod_1(@class);
						goto IL_3a34;
						IL_3a34:
						if (@class != null)
						{
							goto IL_3a38;
						}
						goto IL_3a5f;
						IL_3a38:
						if (@class.vmethod_0())
						{
							goto IL_3a41;
						}
						goto IL_3a5f;
						IL_3a41:
						if (class2 != null)
						{
							goto IL_3a45;
						}
						goto IL_3a5f;
						IL_3a45:
						class107_0.method_2(class2.vmethod_28());
						num = 622;
						return;
						IL_3a5f:
						if (class2 != null)
						{
							goto IL_3a63;
						}
						goto IL_3a94;
						IL_3a63:
						if (class2.pgqjrkspy1())
						{
							goto IL_3a6c;
						}
						goto IL_3a94;
						IL_3a6c:
						intPtr = ((Class94)class2).method_6();
						goto IL_3a7a;
						IL_3a7a:
						class107_0.method_2(new Class92(*(ushort*)(void*)intPtr, (Enum23)4));
						return;
						IL_3a94:
						throw new Exception1();
						IL_3993:
						class107_0.method_2(new Class99(fieldInfo, null));
						return;
						IL_3974:
						if (@class.vmethod_3())
						{
							goto IL_3980;
						}
						goto IL_3c03;
						IL_3980:
						@class = ((Class91)@class).vmethod_50();
						goto IL_3c03;
						IL_3c03:
						class107_0.method_4().vmethod_2(@class);
						num = 120;
						return;
						IL_3837:
						if (class2 == null)
						{
							throw new Exception1();
						}
						goto IL_383b;
						IL_383b:
						class107_0.method_2(class2.vmethod_30());
						return;
						IL_1eac:
						class2 = smethod_1(@class);
						goto IL_1fd6;
						IL_3736:
						if (class2 == null)
						{
							throw new Exception1();
						}
						goto IL_373a;
						IL_373a:
						class107_0.method_2(class2.vmethod_54());
						return;
						IL_1fd6:
						if (@class != null)
						{
							goto IL_20b7;
						}
						goto IL_222c;
						IL_36f5:
						num5 = 2;
						goto IL_3df4;
						IL_36d7:
						if (class2 == null)
						{
							throw new Exception1();
						}
						goto IL_36db;
						IL_36db:
						class107_0.method_2(class2.vmethod_55());
						return;
						IL_20b7:
						if (@class.vmethod_0())
						{
							num = 215;
							goto IL_213a;
						}
						goto IL_222c;
						IL_36b4:
						if (class2 == null)
						{
							throw new Exception1();
						}
						goto IL_36b8;
						IL_36b8:
						class107_0.method_2(class2.vmethod_48());
						return;
						IL_1d29:
						class107_0.method_2(class90_0[num2]);
						return;
						IL_35f9:
						if (class2 == null)
						{
							throw new Exception1();
						}
						goto IL_35fd;
						IL_35fd:
						class107_0.method_2(class2.vmethod_42());
						return;
						IL_213a:
						if (class2 != null)
						{
							goto IL_2141;
						}
						goto IL_222c;
						IL_3578:
						flag = false;
						goto IL_357c;
						IL_357c:
						try
						{
							Monitor.Enter(obj, ref flag);
							key = class107_0.method_4().vmethod_4(null);
							@class = null;
							if (!dictionary_1.TryGetValue(key, out @class))
							{
								class107_0.method_2(new Class102(null));
							}
							else
							{
								class107_0.method_2(@class);
							}
							return;
						}
						finally
						{
							if (flag)
							{
								Monitor.Exit(obj);
							}
						}
						IL_3484:
						class107_0.method_4().vmethod_2(@class);
						return;
						IL_3370:
						@class = class107_0.method_4();
						goto IL_337d;
						IL_337d:
						obj = @class.vmethod_4(type);
						num = 352;
						goto IL_338f;
						IL_338f:
						if (obj == null)
						{
							goto IL_3393;
						}
						goto IL_33c2;
						IL_3393:
						if (type.IsValueType)
						{
							goto IL_339c;
						}
						goto IL_33b5;
						IL_339c:
						obj = Activator.CreateInstance(type);
						goto IL_33a5;
						IL_33a5:
						@class = Class90.smethod_1(type, obj);
						goto IL_38cb;
						IL_33b5:
						@class = new Class102(null);
						goto IL_38cb;
						IL_33c2:
						if (type.IsValueType)
						{
							goto IL_33cb;
						}
						goto IL_33d4;
						IL_33cb:
						obj = smethod_10(obj);
						goto IL_33d4;
						IL_33d4:
						@class = Class90.smethod_1(type, obj);
						goto IL_38cb;
						IL_38cb:
						((class107_0.method_4() as Class96) ?? throw new Exception1()).vmethod_10(@class);
						return;
						IL_2141:
						class107_0.method_2(class2.vmethod_29());
						return;
						IL_222c:
						if (class2 != null)
						{
							goto IL_2230;
						}
						goto IL_2239;
						IL_334f:
						if (class2 == null)
						{
							throw new Exception1();
						}
						goto IL_3353;
						IL_3353:
						class107_0.method_2(class2.vmethod_31());
						return;
						IL_2230:
						if (!class2.pgqjrkspy1())
						{
							goto IL_2239;
						}
						goto IL_226e;
						IL_3300:
						obj = ((Array)class107_0.method_4().vmethod_4(null)).GetValue(class2.vmethod_19().struct74_0.int_0);
						goto IL_332e;
						IL_332e:
						class107_0.method_2(Class90.smethod_1(typeof(double), obj));
						num = 28;
						return;
						IL_32c4:
						if (class2 == null)
						{
							throw new Exception1();
						}
						goto IL_32c8;
						IL_32c8:
						class107_0.method_2(class2.vmethod_24());
						return;
						IL_226e:
						intPtr = ((Class94)class2).method_6();
						num = 364;
						goto IL_24c9;
						IL_327f:
						class2 = smethod_1(@class);
						goto IL_3288;
						IL_3288:
						if (@class != null)
						{
							goto IL_328f;
						}
						goto IL_34fd;
						IL_328f:
						if (@class.vmethod_0())
						{
							num = 577;
							goto IL_32a2;
						}
						goto IL_34fd;
						IL_24c9:
						class107_0.method_2(new Class92(*(uint*)(void*)intPtr, (Enum23)6));
						return;
						IL_32a2:
						if (class2 != null)
						{
							goto IL_3438;
						}
						goto IL_34fd;
						IL_3438:
						class107_0.method_2(class2.vmethod_47());
						return;
						IL_34fd:
						if (class2 != null)
						{
							goto IL_3504;
						}
						goto IL_3b6e;
						IL_3504:
						if (class2.pgqjrkspy1())
						{
							goto IL_3519;
						}
						num = 609;
						goto IL_3b6e;
						IL_2239:
						throw new Exception1();
						IL_3519:
						intPtr = ((Class94)class2).method_6();
						goto IL_3527;
						IL_3527:
						class107_0.method_2(new Class95(*(float*)(void*)intPtr, (Enum23)9));
						return;
						IL_3b6e:
						throw new Exception1();
						IL_326b:
						class107_0.method_2(new Class100(num2, this));
						return;
						IL_3210:
						if (class2 == null)
						{
							throw new Exception1();
						}
						goto IL_3aad;
						IL_1e94:
						int_0 = (int)object_0 - 1;
						return;
						IL_3aad:
						class107_0.method_2(class2.vmethod_26());
						return;
						IL_3202:
						class2 = smethod_1(@class);
						goto IL_3544;
						IL_3544:
						if (@class != null)
						{
							goto IL_3548;
						}
						goto IL_3558;
						IL_3548:
						if (@class.vmethod_0())
						{
							goto IL_3551;
						}
						goto IL_3558;
						IL_3551:
						if (class2 == null)
						{
							goto IL_3558;
						}
						goto IL_3bd7;
						IL_3bd7:
						class107_0.method_2(class2.vmethod_24());
						return;
						IL_3558:
						if (class2 != null)
						{
							goto IL_3ac1;
						}
						goto IL_3aca;
						IL_3ac1:
						if (!class2.pgqjrkspy1())
						{
							goto IL_3aca;
						}
						goto IL_3ad0;
						IL_3aca:
						throw new Exception1();
						IL_3ad0:
						intPtr = ((Class94)class2).method_6();
						goto IL_3ade;
						IL_3ade:
						class107_0.method_2(new Class92(*(short*)(void*)intPtr, (Enum23)3));
						return;
						IL_31e1:
						if (class2 == null)
						{
							goto IL_31e5;
						}
						goto IL_31eb;
						IL_31e5:
						throw new Exception1();
						IL_31eb:
						class107_0.method_2(class2.vmethod_33());
						return;
						IL_3184:
						num6 = smethod_1(class107_0.method_4()).vmethod_84(@class);
						if (num6)
						{
							class107_0.method_2(new Class92(1));
						}
						else
						{
							class107_0.method_2(new Class92(0));
						}
						if (!num6)
						{
							num = 599;
							return;
						}
						goto IL_31cd;
						IL_2633:
						if (@class == null)
						{
							goto IL_263a;
						}
						goto IL_34d8;
						IL_263a:
						flag = true;
						goto IL_37ee;
						IL_1e82:
						@class = class107_0.method_4();
						goto IL_2633;
						IL_34d8:
						flag = !@class.vmethod_7();
						goto IL_37ee;
						IL_31cd:
						int_0 = (int)object_0 - 1;
						return;
						IL_3152:
						class2 = smethod_1(@class);
						goto IL_315b;
						IL_315b:
						if (@class != null)
						{
							goto IL_3162;
						}
						goto IL_3af8;
						IL_3162:
						if (@class.vmethod_0())
						{
							goto IL_3177;
						}
						num = 522;
						goto IL_3af8;
						IL_37ee:
						if (!flag)
						{
							return;
						}
						goto IL_37f2;
						IL_3177:
						if (class2 != null)
						{
							goto IL_3a9a;
						}
						goto IL_3af8;
						IL_3a9a:
						class107_0.method_2(class2.vmethod_25());
						return;
						IL_3af8:
						if (class2 != null)
						{
							goto IL_3d8c;
						}
						num = 493;
						goto IL_3dbd;
						IL_37f2:
						int_0 = (int)object_0 - 1;
						return;
						IL_3d8c:
						if (class2.pgqjrkspy1())
						{
							goto IL_3d95;
						}
						goto IL_3dbd;
						IL_3d95:
						intPtr = ((Class94)class2).method_6();
						goto IL_3da3;
						IL_3da3:
						class107_0.method_2(new Class92(*(int*)(void*)intPtr, (Enum23)5));
						return;
						IL_3dbd:
						throw new Exception1();
						IL_3132:
						if (class6 == null)
						{
							return;
						}
						goto IL_3de5;
						IL_3de5:
						if (double.IsNaN(class6.double_0))
						{
							num5 = 2;
							goto IL_3df4;
						}
						if (!double.IsInfinity(class6.double_0))
						{
							return;
						}
						goto IL_3e17;
						IL_1e4f:
						obj = ((Array)class107_0.method_4().vmethod_4(null)).GetValue(class2.vmethod_19().struct74_0.int_0);
						goto IL_2ca4;
						IL_3df4:
						@enum = (Enum27)num5;
						goto IL_3df6;
						IL_3df6:
						throw new OverflowException(@enum.ToString());
						IL_2ca4:
						class107_0.method_2(Class90.smethod_1(typeof(byte), obj));
						return;
						IL_3e17:
						@enum = (Enum27)1;
						goto IL_3e1a;
						IL_3e1a:
						throw new OverflowException(@enum.ToString());
						IL_30fc:
						class107_0.method_2(new Class97((int)object_0, this));
						return;
						IL_30b5:
						class4 = smethod_1(class107_0.method_4());
						goto IL_30c7;
						IL_30c7:
						if (class2 != null)
						{
							goto IL_30cb;
						}
						goto IL_30e8;
						IL_30cb:
						if (class4 != null)
						{
							goto IL_30cf;
						}
						goto IL_30e8;
						IL_30cf:
						class107_0.method_2(class2.vmethod_70(class4));
						num = 116;
						return;
						IL_30e8:
						throw new Exception1();
						IL_306a:
						if (!smethod_1(class107_0.method_4()).vmethod_78(@class))
						{
							num = 229;
							return;
						}
						goto IL_308c;
						IL_1e1c:
						obj = ((Array)class107_0.method_4().vmethod_4(null)).GetValue(class2.vmethod_19().struct74_0.int_0);
						goto IL_232c;
						IL_308c:
						int_0 = (int)object_0 - 1;
						return;
						IL_300e:
						obj6 = (Array)class107_0.method_4().vmethod_4(null);
						obj = obj6.GetValue(class2.vmethod_19().struct74_0.int_0);
						type = obj6.GetType().GetElementType();
						goto IL_3049;
						IL_3049:
						class107_0.method_2(Class90.smethod_1(type, obj));
						return;
						IL_2edf:
						parameters = constructorInfo.GetParameters();
						goto IL_2ee8;
						IL_2ee8:
						array3 = new object[parameters.Length];
						num = 154;
						goto IL_2efa;
						IL_2efa:
						array4 = new Class90[parameters.Length];
						num = 61;
						goto IL_2f09;
						IL_2f09:
						list = null;
						goto IL_2f0c;
						IL_2f0c:
						class8 = null;
						num = 551;
						num7 = 0;
						goto IL_2f17;
						IL_2e21:
						class2 = smethod_1(@class);
						goto IL_2e2a;
						IL_2e2a:
						if (@class != null)
						{
							goto IL_2e2e;
						}
						goto IL_2e4e;
						IL_2e2e:
						if (@class.vmethod_0())
						{
							goto IL_2e37;
						}
						goto IL_2e4e;
						IL_2e37:
						if (class2 != null)
						{
							goto IL_2e3b;
						}
						goto IL_2e4e;
						IL_2e3b:
						class107_0.method_2(class2.vmethod_23());
						return;
						IL_2e4e:
						if (class2 != null)
						{
							goto IL_2e5e;
						}
						num = 358;
						goto IL_3bfd;
						IL_232c:
						class107_0.method_2(Class90.smethod_1(typeof(int), obj));
						return;
						IL_2e5e:
						if (class2.pgqjrkspy1())
						{
							goto IL_2e6a;
						}
						goto IL_3bfd;
						IL_2e6a:
						intPtr = ((Class94)class2).method_6();
						num = 619;
						goto IL_2fd3;
						IL_2fd3:
						class107_0.method_2(new Class92(*(sbyte*)(void*)intPtr, (Enum23)1));
						return;
						IL_3bfd:
						throw new Exception1();
						IL_2d96:
						class4 = smethod_1(class107_0.method_4());
						goto IL_2da8;
						IL_2da8:
						if (class2 != null)
						{
							goto IL_2dac;
						}
						goto IL_2dc5;
						IL_2dac:
						if (class4 != null)
						{
							goto IL_2db0;
						}
						goto IL_2dc5;
						IL_2db0:
						class107_0.method_2(class2.vmethod_69(class4));
						return;
						IL_2dc5:
						throw new Exception1();
						IL_2d18:
						if (class107_0.method_0() <= 0)
						{
							return;
						}
						goto IL_2d29;
						IL_2d29:
						class90_2 = class107_0.method_4();
						return;
						IL_2cf7:
						if (class2 == null)
						{
							throw new Exception1();
						}
						goto IL_2cfb;
						IL_2cfb:
						class107_0.method_2(class2.vmethod_28());
						return;
						IL_1e0f:
						if (class2 == null)
						{
							throw new Exception1();
						}
						goto IL_2116;
						IL_2cd9:
						class9 = class107_0.method_4() as Class96;
						goto IL_3b0b;
						IL_3b0b:
						if (class9 == null)
						{
							goto IL_3b0f;
						}
						if (!type.IsValueType)
						{
							goto IL_3b1e;
						}
						goto IL_3b2c;
						IL_3b0f:
						throw new Exception1();
						IL_1cf9:
						class107_0.method_2(new Class103(Class79.smethod_1().ResolveString((int)object_0 | 0x70000000)));
						return;
						IL_3b1e:
						class9.vmethod_12(new Class102(null));
						return;
						IL_3b2c:
						if (Nullable.GetUnderlyingType(type) != null)
						{
							goto IL_3b3b;
						}
						obj = Activator.CreateInstance(type);
						goto IL_3b59;
						IL_3b3b:
						class9.vmethod_12(new Class104(null, Nullable.GetUnderlyingType(type)));
						return;
						IL_2116:
						class107_0.method_2(class2.vmethod_36());
						return;
						IL_3b59:
						@class = Class90.smethod_1(type, obj);
						goto IL_3b64;
						IL_3b64:
						class9.vmethod_12(@class);
						return;
						IL_2cc2:
						class107_0.method_2(new Class102(array));
						return;
						IL_2c80:
						class107_0.method_2(Class90.smethod_1(fieldInfo.FieldType, fieldInfo.GetValue(null)));
						num = 124;
						return;
						IL_2c78:
						num7 = 0;
						goto IL_2f17;
						IL_2f17:
						num2 = num7;
						goto IL_3f8e;
						IL_2c59:
						class4 = smethod_1(class107_0.method_4());
						goto IL_2c6b;
						IL_2c6b:
						if (class4 != null)
						{
							goto IL_3145;
						}
						goto IL_314c;
						IL_3145:
						if (class2 == null)
						{
							goto IL_314c;
						}
						goto IL_3822;
						IL_3822:
						class107_0.method_2(class4.vmethod_61(class2));
						return;
						IL_314c:
						throw new Exception1();
						IL_2c0d:
						class4 = smethod_1(class107_0.method_4());
						goto IL_2c1f;
						IL_2c1f:
						if (class4 != null)
						{
							goto IL_2c23;
						}
						goto IL_2c40;
						IL_2c23:
						if (class2 != null)
						{
							goto IL_2c27;
						}
						goto IL_2c40;
						IL_2c27:
						class107_0.method_2(class4.vmethod_74(class2));
						return;
						IL_2c40:
						throw new Exception1();
						IL_2bf7:
						class2 = smethod_1(@class);
						goto IL_2c00;
						IL_2c00:
						if (@class != null)
						{
							goto IL_3223;
						}
						goto IL_3d4a;
						IL_3223:
						if (@class.vmethod_0())
						{
							goto IL_322f;
						}
						goto IL_3d4a;
						IL_322f:
						if (class2 != null)
						{
							goto IL_3236;
						}
						goto IL_3d4a;
						IL_3236:
						class107_0.method_2(class2.vmethod_27());
						return;
						IL_3d4a:
						if (class2 != null)
						{
							goto IL_3d4e;
						}
						goto IL_3d86;
						IL_3d4e:
						if (class2.pgqjrkspy1())
						{
							num = 709;
							goto IL_3d5e;
						}
						goto IL_3d86;
						IL_1e02:
						if (class2 == null)
						{
							goto IL_20d8;
						}
						goto IL_3565;
						IL_3d5e:
						intPtr = ((Class94)class2).method_6();
						goto IL_3d6c;
						IL_3d6c:
						class107_0.method_2(new Class92(*(byte*)(void*)intPtr, (Enum23)2));
						return;
						IL_3d86:
						throw new Exception1();
						IL_2bd6:
						if (class2 == null)
						{
							throw new Exception1();
						}
						goto IL_2bda;
						IL_2bda:
						class107_0.method_2(class2.vmethod_37());
						return;
						IL_20d8:
						throw new Exception1();
						IL_2b9a:
						class4 = smethod_1(class107_0.method_4());
						goto IL_2bac;
						IL_2bac:
						if (class2 != null)
						{
							goto IL_2bb3;
						}
						goto IL_313f;
						IL_2bb3:
						if (class4 != null)
						{
							goto IL_2bba;
						}
						goto IL_313f;
						IL_2bba:
						class107_0.method_2(class2.vmethod_72(class4));
						num = 230;
						return;
						IL_313f:
						throw new Exception1();
						IL_2b79:
						if (class2 == null)
						{
							throw new Exception1();
						}
						goto IL_2b7d;
						IL_2b7d:
						class107_0.method_2(class2.vmethod_47());
						return;
						IL_3565:
						class107_0.method_2(class2.vmethod_39());
						return;
						IL_2b47:
						class4 = smethod_1(class107_0.method_4());
						goto IL_2b59;
						IL_2b59:
						if (class4 != null)
						{
							goto IL_3855;
						}
						goto IL_386e;
						IL_3855:
						if (class2 != null)
						{
							goto IL_3859;
						}
						goto IL_386e;
						IL_3859:
						class107_0.method_2(class4.vmethod_59(class2));
						return;
						IL_386e:
						throw new Exception1();
						IL_2b1c:
						if (class2 == null)
						{
							throw new Exception1();
						}
						goto IL_2eca;
						IL_1de4:
						class4 = smethod_1(class107_0.method_4());
						num = 131;
						goto IL_1fcc;
						IL_2eca:
						class107_0.method_2(class2.vmethod_53());
						return;
						IL_2af9:
						class4 = smethod_1(class107_0.method_4());
						goto IL_2b0b;
						IL_2b0b:
						if (class4 != null)
						{
							goto IL_2b0f;
						}
						goto IL_2b16;
						IL_2b0f:
						if (class2 == null)
						{
							goto IL_2b16;
						}
						goto IL_2e84;
						IL_2e84:
						class107_0.method_2(class4.vmethod_76(class2));
						return;
						IL_2b16:
						throw new Exception1();
						IL_2aa8:
						if (class2 == null)
						{
							throw new Exception1();
						}
						goto IL_2aac;
						IL_2aac:
						class107_0.method_2(class2.vmethod_27());
						return;
						IL_1fcc:
						if (class4 != null)
						{
							goto IL_200d;
						}
						goto IL_2e09;
						IL_2a5b:
						if (smethod_1(class107_0.method_4()).vmethod_79(@class))
						{
							num = 479;
							goto IL_2a7b;
						}
						class107_0.method_2(new Class92(0));
						return;
						IL_200d:
						if (class2 != null)
						{
							goto IL_2a36;
						}
						goto IL_2e09;
						IL_2a7b:
						class107_0.method_2(new Class92(1));
						return;
						IL_2a36:
						class107_0.method_2(class4.vmethod_68(class2));
						return;
						IL_29ec:
						@class = class107_0.method_4();
						goto IL_29f9;
						IL_29f9:
						obj = @class.vmethod_4(null);
						goto IL_2a03;
						IL_2a03:
						if (obj != null)
						{
							goto IL_2a0a;
						}
						goto IL_2e99;
						IL_2a0a:
						if (!type.IsAssignableFrom(obj.GetType()))
						{
							goto IL_2a1d;
						}
						goto IL_30ee;
						IL_2a1d:
						class107_0.method_2(new Class102(null));
						num = 426;
						return;
						IL_30ee:
						class107_0.method_2(@class);
						return;
						IL_2e99:
						class107_0.method_2(new Class102(null));
						return;
						IL_29c2:
						class107_0.method_2(new Class103(Class79.list_0[(int)object_0]));
						return;
						IL_299d:
						if (class2 == null)
						{
							throw new Exception1();
						}
						goto IL_29a1;
						IL_29a1:
						class107_0.method_2(class2.vmethod_32());
						return;
						IL_2e09:
						throw new Exception1();
						IL_294d:
						class2 = smethod_1(@class);
						goto IL_2956;
						IL_2956:
						class90_ = class107_0.method_4();
						goto IL_2963;
						IL_2963:
						class4 = smethod_1(class90_);
						goto IL_296c;
						IL_296c:
						if (class4 != null)
						{
							goto IL_2970;
						}
						goto IL_2977;
						IL_2970:
						if (class2 == null)
						{
							goto IL_2977;
						}
						goto IL_3695;
						IL_3695:
						if (!class4.vmethod_80(@class))
						{
							return;
						}
						goto IL_36a0;
						IL_36a0:
						int_0 = (int)object_0 - 1;
						return;
						IL_2977:
						if (!@class.vmethod_6(class90_))
						{
							return;
						}
						goto IL_2985;
						IL_2985:
						int_0 = (int)object_0 - 1;
						return;
						IL_2906:
						obj = ((Array)class107_0.method_4().vmethod_4(null)).GetValue(class2.vmethod_19().struct74_0.int_0);
						num = 598;
						goto IL_2eab;
						IL_2eab:
						class107_0.method_2(Class90.smethod_1(typeof(long), obj));
						return;
						IL_28c6:
						if (!smethod_1(class107_0.method_4()).vmethod_79(@class))
						{
							return;
						}
						goto IL_30a0;
						IL_30a0:
						int_0 = (int)object_0 - 1;
						return;
						IL_2831:
						obj = ((Array)class107_0.method_4().vmethod_4(null)).GetValue(class2.vmethod_19().struct74_0.int_0);
						goto IL_285f;
						IL_285f:
						class107_0.method_2(Class90.smethod_1(typeof(short), obj));
						return;
						IL_27c7:
						class4 = smethod_1(class107_0.method_4());
						goto IL_27d9;
						IL_27d9:
						if (class4 != null)
						{
							goto IL_27e9;
						}
						num = 663;
						goto IL_321d;
						IL_1dcb:
						obj = class107_0.method_4().vmethod_4(type);
						goto IL_1f3f;
						IL_27e9:
						if (class2 != null)
						{
							goto IL_27f0;
						}
						goto IL_321d;
						IL_27f0:
						class107_0.method_2(class4.vmethod_65(class2));
						return;
						IL_321d:
						throw new Exception1();
						IL_27a8:
						class107_0.method_2(new Class92(num3, (Enum23)6));
						num = 576;
						return;
						IL_2776:
						class2 = smethod_1(@class);
						num = 205;
						goto IL_2786;
						IL_2786:
						if (@class != null)
						{
							goto IL_2805;
						}
						goto IL_39a7;
						IL_2805:
						if (@class.vmethod_0())
						{
							goto IL_2f38;
						}
						goto IL_39a7;
						IL_2f38:
						if (class2 == null)
						{
							goto IL_39a7;
						}
						goto IL_3b9e;
						IL_3b9e:
						class107_0.method_2(class2.vmethod_50());
						return;
						IL_39a7:
						if (class2 != null)
						{
							goto IL_39ab;
						}
						goto IL_39b4;
						IL_39ab:
						if (!class2.pgqjrkspy1())
						{
							goto IL_39b4;
						}
						goto IL_39ba;
						IL_39ba:
						intPtr = ((Class94)class2).method_6();
						goto IL_39c8;
						IL_39c8:
						if (IntPtr.Size == 8)
						{
							goto IL_39d0;
						}
						num2 = *(int*)(void*)intPtr;
						num = 270;
						goto IL_3a02;
						IL_39d0:
						num8 = *(long*)(void*)intPtr;
						goto IL_39d9;
						IL_39d9:
						class107_0.method_2(new Class94(num8, (Enum23)12));
						return;
						IL_1f3f:
						if (obj == null)
						{
							goto IL_2acb;
						}
						goto IL_2ad4;
						IL_3a02:
						class107_0.method_2(new Class94(num2, (Enum23)12));
						return;
						IL_39b4:
						throw new Exception1();
						IL_2733:
						if (smethod_1(class107_0.method_4()).vmethod_77(@class))
						{
							goto IL_34e9;
						}
						return;
						IL_34e9:
						int_0 = (int)object_0 - 1;
						return;
						IL_2712:
						if (class2 == null)
						{
							throw new Exception1();
						}
						goto IL_2716;
						IL_2716:
						class107_0.method_2(class2.vmethod_23());
						return;
						IL_2acb:
						obj = Activator.CreateInstance(type);
						goto IL_2ad4;
						IL_26f3:
						if (@class.vmethod_3())
						{
							goto IL_26ff;
						}
						goto IL_2b66;
						IL_26ff:
						@class = ((Class91)@class).vmethod_48();
						goto IL_2b66;
						IL_2b66:
						class107_0.method_4().vmethod_2(@class);
						return;
						IL_26d2:
						if (class2 == null)
						{
							throw new Exception1();
						}
						goto IL_26d6;
						IL_26d6:
						class107_0.method_2(class2.vmethod_44());
						return;
						IL_2ad4:
						class10 = new Class102(Class90.smethod_1(type, smethod_10(obj)));
						goto IL_2ae9;
						IL_2687:
						obj = ((Array)class107_0.method_4().vmethod_4(null)).GetValue(class2.vmethod_19().struct74_0.int_0);
						goto IL_26b5;
						IL_26b5:
						class107_0.method_2(Class90.smethod_1(typeof(ushort), obj));
						return;
						IL_266a:
						class107_0.method_4().vmethod_2(@class);
						return;
						IL_25e7:
						if (!smethod_1(class107_0.method_4()).vmethod_84(@class))
						{
							class107_0.method_2(new Class92(0));
							return;
						}
						goto IL_2600;
						IL_2600:
						class107_0.method_2(new Class92(1));
						num = 507;
						return;
						IL_2ae9:
						class107_0.method_2(class10);
						return;
						IL_25e1:
						num9 = 1;
						goto IL_3f80;
						IL_3f80:
						flag = (byte)num9 != 0;
						goto IL_3f1f;
						IL_3f1f:
						if (flag)
						{
							goto IL_3e3b;
						}
						num = 111;
						goto IL_3ea7;
						IL_1dbe:
						if (class2 == null)
						{
							throw new Exception1();
						}
						goto IL_223f;
						IL_3ea7:
						if (@class != null)
						{
							num = 446;
							goto IL_3eb2;
						}
						goto IL_3ec3;
						IL_1cec:
						if (class2 == null)
						{
							throw new Exception1();
						}
						goto IL_21d4;
						IL_3eb2:
						key = @class.vmethod_4(type);
						num = 246;
						goto IL_3ec3;
						IL_3ec3:
						if (key != null)
						{
							goto IL_3e3b;
						}
						goto IL_3ec9;
						IL_3ec9:
						if (type.IsByRef)
						{
							goto IL_3ed2;
						}
						goto IL_3edb;
						IL_3ed2:
						type = type.GetElementType();
						goto IL_3edb;
						IL_3edb:
						if (!type.IsValueType)
						{
							goto IL_3e3b;
						}
						goto IL_3ee7;
						IL_3ee7:
						key = Activator.CreateInstance(type);
						num = 109;
						goto IL_3ef3;
						IL_3ef3:
						if (!(@class is Class97))
						{
							goto IL_3e3b;
						}
						goto IL_3eff;
						IL_3eff:
						((Class96)@class).vmethod_12(Class90.smethod_1(type, key));
						num = 761;
						goto IL_3e3b;
						IL_3e3b:
						array4[array3.Length - 1 - num2] = @class;
						goto IL_3e49;
						IL_3e49:
						array3[array3.Length - 1 - num2] = key;
						num = 654;
						goto IL_3e5d;
						IL_3e5d:
						num2++;
						goto IL_3f8e;
						IL_3f8e:
						if (num2 < parameters.Length)
						{
							goto IL_3e68;
						}
						num = 717;
						goto IL_3fa0;
						IL_223f:
						class107_0.method_2(class2.vmethod_45());
						return;
						IL_3fa0:
						@delegate = null;
						goto IL_3fa3;
						IL_3fa3:
						if (list != null)
						{
							goto IL_3fa7;
						}
						goto IL_3fbe;
						IL_3fa7:
						class8 = new Class87(constructorInfo, list);
						goto IL_3fb2;
						IL_3fb2:
						@delegate = smethod_4(constructorInfo, bool_4: true, class8);
						goto IL_3fbe;
						IL_3fbe:
						obj = null;
						goto IL_3fc1;
						IL_3fc1:
						if (@delegate != null)
						{
							goto IL_3fc5;
						}
						goto IL_3fd4;
						IL_3fc5:
						obj = @delegate(null, array3);
						num10 = 0;
						goto IL_3fe0;
						IL_3fd4:
						obj = constructorInfo.Invoke(array3);
						num10 = 0;
						goto IL_3fe0;
						IL_3e68:
						@class = class107_0.method_4();
						goto IL_3e75;
						IL_3e75:
						type = parameters[parameters.Length - 1 - num2].ParameterType;
						goto IL_3e88;
						IL_3e88:
						key = null;
						goto IL_3e8a;
						IL_3e8a:
						flag = false;
						num = 510;
						goto IL_3e94;
						IL_3e94:
						if (!type.IsByRef)
						{
							goto IL_3f1f;
						}
						goto IL_3f2c;
						IL_3f2c:
						class11 = @class as Class99;
						num = 802;
						goto IL_3e2e;
						IL_3e2e:
						if (class11 == null)
						{
							goto IL_3f1f;
						}
						goto IL_3f41;
						IL_3f41:
						if (list == null)
						{
							goto IL_3f45;
						}
						goto IL_3f4c;
						IL_3f45:
						list = new List<Class86>();
						goto IL_3f4c;
						IL_3f4c:
						list.Add(new Class86(class11.fieldInfo_0, parameters.Length - 1 - num2));
						goto IL_3f68;
						IL_3f68:
						key = class11.object_0;
						goto IL_3f70;
						IL_3f70:
						if (!(key is Class90))
						{
							num = 359;
							num9 = 1;
							goto IL_3f80;
						}
						goto IL_3f84;
						IL_1d9e:
						class4 = (Class91)class107_0.method_4();
						goto IL_1db0;
						IL_3f84:
						@class = key as Class90;
						goto IL_3f1f;
						IL_25d4:
						if (class2 != null)
						{
							goto IL_2f1e;
						}
						goto IL_3064;
						IL_3064:
						throw new Exception1();
						IL_2f1e:
						class107_0.method_2(class2.vmethod_50());
						num = 515;
						return;
						IL_25be:
						@class = class90_1[num2];
						goto IL_32af;
						IL_32af:
						class107_0.method_2(@class);
						num = 226;
						return;
						IL_25b6:
						num4 = 0;
						goto IL_25b7;
						IL_25b7:
						flag = (byte)num4 != 0;
						goto IL_2883;
						IL_2883:
						try
						{
							Monitor.Enter(obj, ref flag);
							@class = class107_0.method_4();
							key = class107_0.method_4().vmethod_4(null);
							dictionary_1[key] = @class;
							return;
						}
						finally
						{
							if (flag)
							{
								Monitor.Exit(obj);
							}
						}
						IL_2540:
						if (!class85_0.methodBase_0.IsStatic)
						{
							class90_0[num2] = method_7(class107_0.method_4(), class85_0.leLxEnLbDa[num2 - 1].enum23_0);
							return;
						}
						goto IL_2552;
						IL_2552:
						class90_0[num2] = method_7(class107_0.method_4(), class85_0.leLxEnLbDa[num2].enum23_0);
						return;
						IL_1db0:
						if (class4 != null)
						{
							goto IL_2642;
						}
						goto IL_2664;
						IL_2529:
						class2 = smethod_1(class107_0.method_4());
						goto IL_3636;
						IL_3636:
						array = (Array)class107_0.method_4().vmethod_4(null);
						goto IL_364e;
						IL_364e:
						class107_0.method_2(new Class98(class2.vmethod_19().struct74_0.int_0, array));
						return;
						IL_24e3:
						if (class2 == null)
						{
							throw new Exception1();
						}
						goto IL_24e7;
						IL_24e7:
						class107_0.method_2(class2.vmethod_35());
						return;
						IL_2642:
						if (class2 != null)
						{
							goto IL_264f;
						}
						num = 406;
						goto IL_2664;
						IL_2496:
						obj = ((Array)class107_0.method_4().vmethod_4(null)).GetValue(class2.vmethod_19().struct74_0.int_0);
						goto IL_37d1;
						IL_37d1:
						class107_0.method_2(Class90.smethod_1(typeof(IntPtr), obj));
						return;
						IL_2461:
						if (class2 == null)
						{
							goto IL_2465;
						}
						goto IL_246b;
						IL_2465:
						throw new Exception1();
						IL_246b:
						class107_0.method_2(class2.vmethod_40());
						return;
						IL_2454:
						if (class2 != null)
						{
							goto IL_2755;
						}
						goto IL_29bb;
						IL_29bb:
						throw new Exception1();
						IL_2755:
						class107_0.method_2(class2.vmethod_49());
						return;
						IL_243d:
						class4 = smethod_1(class107_0.method_4());
						goto IL_344f;
						IL_344f:
						if (class4 != null)
						{
							num = 653;
							goto IL_345a;
						}
						goto IL_347c;
						IL_21d4:
						class107_0.method_2(class2.vmethod_46());
						return;
						IL_345a:
						if (class2 != null)
						{
							goto IL_3467;
						}
						num = 544;
						goto IL_347c;
						IL_2664:
						throw new Exception1();
						IL_3467:
						class107_0.method_2(class4.vmethod_62(class2));
						return;
						IL_347c:
						throw new Exception1();
						IL_2425:
						int_0 = (int)object_0 - 1;
						return;
						IL_23f7:
						class4 = smethod_1(class107_0.method_4());
						goto IL_2940;
						IL_2940:
						if (class4 != null)
						{
							goto IL_32e1;
						}
						goto IL_32e5;
						IL_32e1:
						if (class2 == null)
						{
							goto IL_32e5;
						}
						goto IL_32eb;
						IL_32e5:
						throw new Exception1();
						IL_32eb:
						class107_0.method_2(class4.vmethod_66(class2));
						return;
						IL_23f0:
						num10 = 0;
						goto IL_3fe0;
						IL_3fe0:
						num11 = num10;
						goto IL_40a1;
						IL_40a1:
						if (num11 < parameters.Length)
						{
							goto IL_3fe7;
						}
						goto IL_40ac;
						IL_40ac:
						class107_0.method_2(Class90.smethod_1(constructorInfo.DeclaringType, obj));
						return;
						IL_3fe7:
						if (parameters[num11].ParameterType.IsByRef)
						{
							goto IL_3ffb;
						}
						goto IL_4094;
						IL_3ffb:
						if (class8 != null)
						{
							goto IL_3fff;
						}
						goto IL_400d;
						IL_3fff:
						if (!class8.method_1(num11))
						{
							goto IL_400d;
						}
						goto IL_4094;
						IL_400d:
						if (array4[num11].pgqjrkspy1())
						{
							goto IL_4019;
						}
						goto IL_403e;
						IL_4019:
						((Class94)array4[num11]).method_5(Class90.smethod_1(parameters[num11].ParameterType, array3[num11]));
						goto IL_4094;
						IL_403e:
						if (!(array4[num11] is Class97))
						{
							goto IL_404a;
						}
						goto IL_4071;
						IL_404a:
						array4[num11].vmethod_10(Class90.smethod_1(parameters[num11].ParameterType, array3[num11]));
						num = 433;
						goto IL_4094;
						IL_4071:
						array4[num11].vmethod_10(Class90.smethod_1(parameters[num11].ParameterType.GetElementType(), array3[num11]));
						goto IL_4094;
						IL_4094:
						num11++;
						num = 341;
						goto IL_40a1;
						IL_23c2:
						if (!smethod_1(class107_0.method_4()).vmethod_83(@class))
						{
							class107_0.method_2(new Class92(0));
							return;
						}
						goto IL_3a19;
						IL_264f:
						class107_0.method_2(class4.vmethod_60(class2));
						return;
						IL_3a19:
						class107_0.method_2(new Class92(1));
						return;
						IL_23a0:
						if (!smethod_1(class107_0.method_4()).vmethod_83(@class))
						{
							return;
						}
						goto IL_247e;
						IL_247e:
						int_0 = (int)object_0 - 1;
						return;
						IL_234e:
						if (!smethod_1(class107_0.method_4()).vmethod_81(@class))
						{
							return;
						}
						goto IL_2367;
						IL_2367:
						int_0 = (int)object_0 - 1;
						return;
						IL_2302:
						intPtr = smethod_9(class107_0.method_4());
						goto IL_2791;
						IL_2791:
						intPtr2 = smethod_9(class107_0.method_4());
						goto IL_36fb;
						IL_36fb:
						if (!(intPtr != IntPtr.Zero))
						{
							return;
						}
						goto IL_3709;
						IL_3709:
						if (!(intPtr2 != IntPtr.Zero))
						{
							return;
						}
						goto IL_3717;
						IL_3717:
						num3 = class2.vmethod_20().struct74_0.uint_0;
						goto IL_372a;
						IL_372a:
						smethod_12(intPtr2, intPtr, num3);
						return;
						IL_22f1:
						if (list_0 == null)
						{
							goto IL_2a4b;
						}
						goto IL_3c2e;
						IL_2a4b:
						list_0 = new List<IntPtr>();
						goto IL_3c2e;
						IL_3c2e:
						list_0.Add(intPtr);
						goto IL_3c3b;
						IL_3c3b:
						class107_0.method_2(new Class94(intPtr));
						num = 20;
						return;
						IL_22d7:
						class107_0.method_4().vmethod_2(@class);
						num = 171;
						return;
						IL_22c2:
						class2 = smethod_1(@class);
						num = 473;
						goto IL_28e8;
						IL_28e8:
						class90_ = class107_0.method_4();
						goto IL_28f5;
						IL_28f5:
						class4 = smethod_1(class90_);
						goto IL_2c46;
						IL_2c46:
						if (class4 != null)
						{
							goto IL_2d3f;
						}
						num = 379;
						goto IL_2d76;
						IL_1d87:
						class4 = smethod_1(class107_0.method_4());
						goto IL_2028;
						IL_2d3f:
						if (class2 != null)
						{
							goto IL_2d43;
						}
						goto IL_2d76;
						IL_2d43:
						if (!class4.vmethod_80(@class))
						{
							goto IL_2d4e;
						}
						goto IL_2d60;
						IL_2d4e:
						class107_0.method_2(new Class92(0));
						return;
						IL_2d60:
						class107_0.method_2(new Class92(1));
						return;
						IL_2d76:
						if (!@class.vmethod_6(class90_))
						{
							goto IL_2d84;
						}
						goto IL_3bb1;
						IL_2d84:
						class107_0.method_2(new Class92(0));
						return;
						IL_3bb1:
						class107_0.method_2(new Class92(1));
						return;
						IL_229d:
						type = class107_0.method_4().vmethod_4(null).GetType();
						goto IL_22b5;
						IL_22b5:
						list2 = new List<Type>();
						goto IL_2dee;
						IL_2dee:
						list2.Add(type);
						goto IL_2dcb;
						IL_2dcb:
						type = type.BaseType;
						goto IL_2dd4;
						IL_2dd4:
						if (type != null)
						{
							goto IL_2dde;
						}
						goto IL_2df9;
						IL_2dde:
						if (type != methodBase.DeclaringType)
						{
							goto IL_2dee;
						}
						goto IL_2df9;
						IL_2df9:
						list2.Reverse();
						goto IL_2e00;
						IL_2e00:
						methodBase2 = methodBase;
						goto IL_2f46;
						IL_2f46:
						enumerator = list2.GetEnumerator();
						goto IL_2f4f;
						IL_2f4f:
						try
						{
							while (enumerator.MoveNext())
							{
								MethodInfo[] methods = enumerator.Current.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
								foreach (MethodInfo methodInfo in methods)
								{
									if (methodInfo.GetBaseDefinition() == methodBase2)
									{
										methodBase2 = methodInfo;
										break;
									}
								}
							}
						}
						finally
						{
							((IDisposable)enumerator/*cast due to .constrained prefix*/).Dispose();
						}
						goto IL_2fac;
						IL_2fac:
						class107_0.method_2(new Class94(methodBase2.MethodHandle.GetFunctionPointer()));
						return;
						IL_2256:
						class2 = smethod_1(class107_0.method_4());
						goto IL_2818;
						IL_2818:
						num8 = class2.vmethod_21().struct75_0.long_0;
						goto IL_2fed;
						IL_2fed:
						if (num8 >= 0L)
						{
							goto IL_2ffc;
						}
						goto IL_3497;
						IL_2ffc:
						if (class2.MwVjiGosgX())
						{
							goto IL_3497;
						}
						goto IL_34a3;
						IL_3497:
						if (IntPtr.Size == 4)
						{
							goto IL_349f;
						}
						goto IL_34a3;
						IL_349f:
						num8 = (int)num8;
						goto IL_34a3;
						IL_34a3:
						if (class2.method_1())
						{
							goto IL_34af;
						}
						goto IL_3dc3;
						IL_34af:
						class12 = (Class92)class2;
						goto IL_34b8;
						IL_34b8:
						if (class12.enum23_0 == (Enum23)6)
						{
							goto IL_34c5;
						}
						goto IL_3dc3;
						IL_34c5:
						num8 = class12.struct74_0.uint_0;
						goto IL_3dc3;
						IL_3dc3:
						if (num8 >= array2.Length)
						{
							return;
						}
						goto IL_3dcb;
						IL_3dcb:
						if (num8 < 0L)
						{
							return;
						}
						goto IL_3dd7;
						IL_3dd7:
						int_0 = array2[num8] - 1;
						return;
						IL_2210:
						class2 = smethod_1(@class);
						goto IL_376c;
						IL_376c:
						if (@class != null)
						{
							goto IL_3770;
						}
						goto IL_3790;
						IL_3770:
						if (@class.vmethod_0())
						{
							goto IL_3779;
						}
						goto IL_3790;
						IL_3779:
						if (class2 != null)
						{
							goto IL_377d;
						}
						goto IL_3790;
						IL_377d:
						class107_0.method_2(class2.vmethod_26());
						return;
						IL_3790:
						if (class2 != null)
						{
							goto IL_3797;
						}
						goto IL_3d1b;
						IL_3797:
						if (class2.pgqjrkspy1())
						{
							goto IL_37a9;
						}
						num = 13;
						goto IL_3d1b;
						IL_2028:
						if (class4 != null)
						{
							goto IL_202f;
						}
						goto IL_2fcd;
						IL_37a9:
						intPtr = ((Class94)class2).method_6();
						goto IL_37b7;
						IL_37b7:
						class107_0.method_2(new Class93(*(long*)(void*)intPtr, (Enum23)7));
						return;
						IL_3d1b:
						throw new Exception1();
						IL_21f8:
						if (@class.vmethod_3())
						{
							goto IL_35d8;
						}
						goto IL_35e6;
						IL_35d8:
						@class = ((Class91)@class).vmethod_47();
						goto IL_35e6;
						IL_35e6:
						class107_0.method_4().vmethod_2(@class);
						return;
						IL_21eb:
						if (class2 == null)
						{
							throw new Exception1();
						}
						goto IL_2319;
						IL_202f:
						if (class2 == null)
						{
							goto IL_2fcd;
						}
						goto IL_3616;
						IL_2319:
						class107_0.method_2(class2.vmethod_29());
						return;
						IL_21ae:
						class4 = smethod_1(class107_0.method_4());
						goto IL_21c0;
						IL_21c0:
						if (class4 != null)
						{
							goto IL_21c7;
						}
						goto IL_2681;
						IL_21c7:
						if (class2 == null)
						{
							goto IL_2681;
						}
						goto IL_3806;
						IL_3806:
						class107_0.method_2(class4.vmethod_58(class2));
						num = 248;
						return;
						IL_2681:
						throw new Exception1();
						IL_21a1:
						if (class2 == null)
						{
							goto IL_21a8;
						}
						goto IL_3bea;
						IL_21a8:
						throw new Exception1();
						IL_3bea:
						class107_0.method_2(class2.vmethod_41());
						return;
						IL_218f:
						@class = class107_0.method_4();
						goto IL_392c;
						IL_392c:
						class2 = smethod_1(class107_0.method_4());
						goto IL_393e;
						IL_393e:
						((Array)class107_0.method_4().vmethod_4(null)).SetValue(@class.vmethod_4(type), class2.vmethod_19().struct74_0.int_0);
						return;
						IL_2178:
						class4 = class107_0.method_4() as Class91;
						goto IL_2b29;
						IL_2b29:
						intPtr = smethod_9(class107_0.method_4());
						num = 736;
						goto IL_38ec;
						IL_38ec:
						if (!(intPtr != IntPtr.Zero))
						{
							return;
						}
						goto IL_38fa;
						IL_38fa:
						byte_ = class4.vmethod_16().struct74_0.byte_0;
						goto IL_390d;
						IL_390d:
						num3 = class2.vmethod_20().struct74_0.uint_0;
						goto IL_3920;
						IL_3920:
						smethod_11(intPtr, byte_, (int)num3);
						return;
						IL_2158:
						if (class2 == null)
						{
							throw new Exception1();
						}
						goto IL_240e;
						IL_3616:
						class107_0.method_2(class4.vmethod_67(class2));
						return;
						IL_240e:
						class107_0.method_2(class2.vmethod_34());
						return;
						IL_2100:
						class2 = smethod_1(@class);
						goto IL_2109;
						IL_2109:
						if (@class != null)
						{
							goto IL_2e0f;
						}
						goto IL_3878;
						IL_2e0f:
						if (@class.vmethod_0())
						{
							goto IL_3874;
						}
						goto IL_3878;
						IL_3874:
						if (class2 == null)
						{
							goto IL_3878;
						}
						goto IL_38b4;
						IL_38b4:
						class107_0.method_2(class2.vmethod_48());
						return;
						IL_3878:
						if (class2 != null)
						{
							goto IL_387c;
						}
						goto IL_38ae;
						IL_387c:
						if (class2.pgqjrkspy1())
						{
							goto IL_3885;
						}
						goto IL_38ae;
						IL_3885:
						intPtr = ((Class94)class2).method_6();
						goto IL_3893;
						IL_3893:
						class107_0.method_2(new Class95(*(double*)(void*)intPtr, (Enum23)10));
						return;
						IL_38ae:
						throw new Exception1();
						IL_20f3:
						if (class2 == null)
						{
							throw new Exception1();
						}
						goto IL_2289;
						IL_2fcd:
						throw new Exception1();
						IL_2289:
						class107_0.method_2(class2.vmethod_71());
						return;
						IL_20de:
						class4 = smethod_1(class107_0.method_4());
						goto IL_212d;
						IL_212d:
						if (class4 != null)
						{
							goto IL_221e;
						}
						goto IL_2225;
						IL_221e:
						if (class2 == null)
						{
							goto IL_2225;
						}
						goto IL_311a;
						IL_2225:
						throw new Exception1();
						IL_311a:
						class107_0.method_2(class4.Add(class2));
						return;
						IL_20cc:
						bool_0 = true;
						return;
						IL_2099:
						obj = class107_0.method_4().vmethod_8().vmethod_4(type);
						goto IL_3c52;
						IL_3c52:
						@class = Class90.smethod_1(type, obj);
						goto IL_3c5d;
						IL_3c5d:
						class107_0.method_2(@class);
						return;
						IL_207a:
						class4 = smethod_1(class107_0.method_4());
						goto IL_208c;
						IL_208c:
						if (class4 != null)
						{
							goto IL_3672;
						}
						goto IL_368f;
						IL_3672:
						if (class2 != null)
						{
							goto IL_3676;
						}
						goto IL_368f;
						IL_3676:
						class107_0.method_2(class4.vmethod_63(class2));
						num = 127;
						return;
						IL_368f:
						throw new Exception1();
						IL_205a:
						obj = class107_0.method_4().vmethod_4(fieldInfo.FieldType);
						goto IL_2504;
						IL_2504:
						@class = class107_0.method_4();
						goto IL_2511;
						IL_2511:
						key = @class.vmethod_4(null);
						goto IL_251a;
						IL_251a:
						if (key == null)
						{
							goto IL_2768;
						}
						num = 36;
						goto IL_3d3f;
						IL_1d7a:
						if (class2 == null)
						{
							goto IL_220a;
						}
						goto IL_3bc4;
						IL_2768:
						type = fieldInfo.DeclaringType;
						goto IL_33e4;
						IL_33e4:
						if (type.IsByRef)
						{
							goto IL_33ed;
						}
						goto IL_33f6;
						IL_33ed:
						type = type.GetElementType();
						goto IL_33f6;
						IL_33f6:
						if (type.IsValueType)
						{
							goto IL_3402;
						}
						goto IL_36d1;
						IL_3402:
						key = Activator.CreateInstance(type);
						goto IL_340a;
						IL_340a:
						if (@class is Class97)
						{
							goto IL_341f;
						}
						num = 796;
						goto IL_3d3f;
						IL_220a:
						throw new Exception1();
						IL_341f:
						((Class96)@class).vmethod_12(Class90.smethod_1(type, key));
						goto IL_3d3f;
						IL_3d3f:
						fieldInfo.SetValue(key, obj);
						return;
						IL_36d1:
						throw new NullReferenceException();
						IL_203c:
						if (class2 == null)
						{
							throw new Exception1();
						}
						goto IL_2040;
						IL_2040:
						class107_0.method_2(class2.vmethod_25());
						return;
						IL_3bc4:
						class107_0.method_2(class2.vmethod_52());
						return;
						IL_201a:
						if (class2 == null)
						{
							throw new Exception1();
						}
						goto IL_3c1a;
						IL_1d64:
						class107_0.method_2(new Class92(1));
						return;
						IL_3c1a:
						class107_0.method_2(class2.vmethod_43());
						return;
						IL_1ffb:
						if (!@class.vmethod_0())
						{
							goto IL_305e;
						}
						goto IL_3c6c;
						IL_305e:
						throw new Exception1();
						IL_3c6c:
						obj = @class.vmethod_4(null);
						goto IL_3c76;
						IL_3c76:
						if (obj != null)
						{
							goto IL_3c7a;
						}
						goto IL_3c8c;
						IL_3c7a:
						@class = Class90.smethod_1(obj.GetType(), obj);
						goto IL_3c94;
						IL_3c8c:
						@class = new Class102(null);
						goto IL_3c94;
						IL_3c94:
						class107_0.method_2(@class);
						num = 96;
						return;
						IL_1fe3:
						obj = class107_0.method_4().vmethod_4(null);
						goto IL_3249;
						IL_3249:
						class107_0.method_2(Class90.smethod_1(fieldInfo.FieldType, fieldInfo.GetValue(obj)));
						return;
						IL_1f76:
						obj = ((Array)class107_0.method_4().vmethod_4(null)).GetValue(class2.vmethod_19().struct74_0.int_0);
						goto IL_1fa4;
						IL_1fa4:
						class107_0.method_2(Class90.smethod_1(typeof(float), obj));
						num = 742;
						return;
						IL_1f6a:
						bool_1 = true;
						return;
						IL_1f4c:
						obj = class107_0.method_4().vmethod_4(fieldInfo.FieldType);
						goto IL_362b;
						IL_362b:
						fieldInfo.SetValue(null, obj);
						return;
						IL_1f27:
						class4 = smethod_1(class107_0.method_4());
						goto IL_2165;
						end_IL_0ce4:
						break;
					}
					break;
				}
			}
		}

		private Class90 method_7(Class90 class90_3, Enum23 enum23_0, bool bool_4 = false)
		{
			if (!bool_4 && class90_3.vmethod_0())
			{
				class90_3 = class90_3.vmethod_8();
			}
			if (class90_3.method_1())
			{
				return ((Class92)class90_3).vmethod_13(enum23_0);
			}
			if (class90_3.method_3())
			{
				return ((Class93)class90_3).vmethod_13(enum23_0);
			}
			if (class90_3.MwVjiGosgX())
			{
				return ((Class95)class90_3).vmethod_13(enum23_0);
			}
			if (class90_3.pgqjrkspy1())
			{
				return ((Class94)class90_3).vmethod_13(enum23_0);
			}
			return class90_3;
		}

		private Class90 method_8(int int_3)
		{
			return class90_1[int_3];
		}

		private void method_9(int int_3)
		{
			method_10(int_3, class107_0.method_4());
		}

		private static int smethod_0(Type type_0)
		{
			lock (object_1)
			{
				while (dictionary_0 == null)
				{
					while (true)
					{
						IL_003d:
						dictionary_0 = new Dictionary<Type, int>();
						int num = 10;
						while (num != 10)
						{
							if (num != 990)
							{
								goto IL_003d;
							}
							switch (num)
							{
							case 0:
								goto IL_003d;
							case 2:
								goto end_IL_003d;
							case 1:
								goto end_IL_004d;
							}
						}
						goto end_IL_004d;
						continue;
						end_IL_003d:
						break;
					}
					continue;
					end_IL_004d:
					break;
				}
				try
				{
					int value = 0;
					if (!dictionary_0.TryGetValue(type_0, out value))
					{
						DynamicMethod dynamicMethod = new DynamicMethod(string.Empty, typeof(int), Type.EmptyTypes, restrictedSkipVisibility: true);
						ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
						iLGenerator.Emit(OpCodes.Sizeof, type_0);
						iLGenerator.Emit(OpCodes.Ret);
						value = (int)dynamicMethod.Invoke(null, null);
						dictionary_0[type_0] = value;
						return value;
					}
					return value;
				}
				catch
				{
					return 0;
				}
			}
		}

		private void method_10(int int_3, Class90 class90_3)
		{
			class90_1[int_3] = method_7(class90_3, class85_0.list_1[int_3].enum23_0, class85_0.list_1[int_3].bool_0);
		}

		private static Class91 smethod_1(Class90 class90_3)
		{
			Class91 @class = class90_3 as Class91;
			if (@class == null && class90_3.vmethod_0())
			{
				@class = class90_3.vmethod_8() as Class91;
			}
			return @class;
		}

		private void oXhYcskyWej(bool bool_4)
		{
			int num = 66;
			ParameterInfo[] parameters = default(ParameterInfo[]);
			object obj = default(object);
			Class87 @class = default(Class87);
			int num5 = default(int);
			object[] array = default(object[]);
			Class90[] array2 = default(Class90[]);
			List<Class86> list = default(List<Class86>);
			int num6 = default(int);
			Class90 class2 = default(Class90);
			Type type = default(Type);
			object obj2 = default(object);
			bool flag = default(bool);
			Class99 class3 = default(Class99);
			Delegate16 @delegate = default(Delegate16);
			Delegate21 delegate2 = default(Delegate21);
			object target = default(object);
			Class90 class4 = default(Class90);
			bool flag2 = default(bool);
			Type type2 = default(Type);
			Type type3 = default(Type);
			Class105 class5 = default(Class105);
			while (true)
			{
				MethodBase methodBase = Class79.smethod_3((int)object_0);
				while (true)
				{
					MethodInfo methodInfo = methodBase as MethodInfo;
					num = 193;
					while (true)
					{
						if (num != 193)
						{
							if (num != 1174)
							{
								goto IL_05b9;
							}
							switch (num)
							{
							case 65:
								goto end_IL_030b;
							case 66:
								goto end_IL_031a;
							case 14:
								goto IL_033d;
							case 11:
							case 126:
								goto IL_0340;
							case 128:
								goto IL_0346;
							case 93:
								goto IL_0350;
							case 112:
								goto IL_0359;
							case 48:
								goto IL_0363;
							case 98:
								goto IL_036a;
							case 130:
							case 172:
								goto IL_0370;
							case 37:
							case 120:
								goto IL_037a;
							case 74:
								goto IL_0387;
							case 182:
								goto IL_0398;
							case 69:
								goto IL_039e;
							case 159:
								goto IL_03aa;
							case 46:
								goto IL_03b3;
							case 44:
								goto IL_03ba;
							case 90:
								goto IL_03be;
							case 152:
								goto IL_03c5;
							case 185:
								goto IL_03e0;
							case 67:
								goto IL_03e9;
							case 153:
								goto IL_03f2;
							case 105:
								goto IL_0400;
							case 176:
								goto IL_0403;
							case 149:
								goto IL_040a;
							case 81:
								goto IL_0413;
							case 28:
								goto IL_041c;
							case 22:
								goto IL_0428;
							case 49:
							case 150:
								goto IL_0436;
							case 35:
								goto IL_0441;
							case 101:
							case 114:
								goto IL_0450;
							case 61:
								goto IL_045c;
							case 138:
								goto IL_0473;
							case 108:
								goto IL_0477;
							case 173:
								goto IL_0482;
							case 103:
								goto IL_0486;
							case 184:
								goto IL_048f;
							case 186:
								goto IL_0498;
							case 55:
								goto IL_04a1;
							case 151:
								goto IL_04aa;
							case 34:
								goto IL_04b3;
							case 47:
							case 83:
								goto IL_04c8;
							case 86:
								goto IL_04d5;
							case 30:
								goto IL_04e1;
							case 92:
							case 95:
							case 102:
							case 124:
							case 131:
								goto IL_04ec;
							case 175:
								goto IL_04f3;
							case 180:
								goto IL_04f6;
							case 141:
								goto IL_04f9;
							case 177:
								goto IL_04fd;
							case 36:
								goto IL_0507;
							case 135:
								goto IL_0518;
							case 20:
								goto IL_0521;
							case 89:
								goto IL_052e;
							case 1:
							case 17:
								goto IL_0539;
							case 63:
								goto IL_053c;
							case 9:
								goto IL_054e;
							case 56:
								goto IL_0556;
							case 160:
								goto IL_0564;
							case 13:
							case 106:
							case 110:
							case 145:
							case 156:
								goto IL_056d;
							case 123:
								goto IL_0574;
							case 43:
								goto IL_0577;
							case 116:
								goto IL_058a;
							case 5:
								goto IL_0595;
							case 181:
								goto IL_05a2;
							case 166:
								goto IL_05a6;
							case 142:
								goto IL_05b5;
							case 7:
								goto IL_05b9;
							case 174:
								goto IL_05bd;
							case 64:
								goto IL_05c5;
							case 62:
								goto IL_05ce;
							case 155:
								goto IL_05de;
							case 82:
							case 99:
								goto IL_05eb;
							case 52:
								goto IL_05f1;
							case 32:
								goto IL_05fa;
							case 50:
								goto IL_05fe;
							case 38:
								goto IL_060d;
							case 2:
							case 6:
								goto IL_0616;
							case 146:
								goto IL_061f;
							case 51:
							case 121:
								goto IL_0634;
							case 70:
								goto IL_0637;
							case 3:
							case 148:
								goto IL_0644;
							case 117:
								goto IL_0655;
							case 78:
							case 133:
							case 171:
								goto IL_066b;
							case 27:
								goto IL_066f;
							case 127:
								goto IL_0681;
							case 33:
							case 162:
								goto IL_0685;
							case 59:
								goto IL_0695;
							case 107:
								goto IL_06a5;
							case 96:
								goto IL_06b5;
							case 111:
								goto IL_06c5;
							case 97:
								goto IL_06d0;
							case 79:
								goto IL_06dc;
							case 58:
								goto IL_06e9;
							case 16:
								goto IL_06f3;
							case 169:
								goto IL_06fb;
							case 54:
								goto IL_0716;
							case 100:
								goto IL_071b;
							case 122:
								goto IL_0722;
							case 136:
								goto IL_072e;
							case 85:
								goto IL_0752;
							case 140:
								goto IL_0760;
							case 139:
								goto IL_0773;
							case 104:
								goto IL_0778;
							case 87:
								goto IL_0783;
							case 132:
								goto IL_0792;
							case 40:
							case 57:
								goto IL_07b6;
							case 10:
							case 183:
								goto IL_07cb;
							case 29:
							case 80:
								goto IL_07e0;
							case 75:
								goto IL_07f2;
							case 88:
								goto IL_0801;
							case 125:
								goto IL_080f;
							case 21:
							case 118:
								goto IL_0821;
							case 18:
							case 73:
								goto IL_0833;
							case 91:
								goto IL_0845;
							case 0:
							case 8:
							case 15:
							case 60:
							case 68:
							case 76:
							case 94:
							case 113:
							case 119:
							case 134:
							case 144:
							case 154:
							case 157:
							case 170:
								goto IL_0853;
							case 71:
								goto IL_0856;
							case 41:
								goto IL_0868;
							case 143:
								goto IL_086b;
							case 53:
								goto IL_086f;
							case 77:
							case 167:
							case 178:
								goto IL_087e;
							case 72:
								goto IL_088a;
							case 84:
								goto IL_0895;
							case 45:
								goto IL_089b;
							case 23:
							case 26:
								goto IL_08a6;
							case 24:
							case 25:
								goto IL_08b4;
							case 39:
								goto IL_08c7;
							case 165:
								goto IL_08cb;
							case 179:
								goto IL_08d6;
							case 129:
							case 137:
								goto IL_08e2;
							case 4:
							case 12:
								goto IL_08ee;
							case 168:
								goto IL_090c;
							case 147:
								goto IL_092f;
							case 31:
							case 42:
							case 115:
							case 158:
								goto IL_0950;
							case 164:
								goto IL_095b;
							case 19:
								goto IL_0964;
							case 163:
								goto IL_097b;
							case 109:
							case 161:
								return;
							}
							continue;
						}
						parameters = methodBase.GetParameters();
						goto IL_0350;
						IL_097b:
						class107_0.method_2(Class90.smethod_1(methodInfo.ReturnType, obj));
						num = 109;
						return;
						IL_08c7:
						if (@class != null)
						{
							goto IL_08cb;
						}
						goto IL_08d6;
						IL_0346:
						int num2 = 0;
						goto IL_039c;
						IL_0340:
						int num3 = 0;
						goto IL_07f8;
						IL_033d:
						int num4 = 0;
						goto IL_036e;
						IL_08b4:
						if (parameters[num5].ParameterType.IsByRef)
						{
							goto IL_08c7;
						}
						goto IL_0950;
						IL_0350:
						array = new object[parameters.Length];
						goto IL_0359;
						IL_0359:
						array2 = new Class90[parameters.Length];
						goto IL_0363;
						IL_0363:
						list = null;
						num = 98;
						goto IL_036a;
						IL_036a:
						@class = null;
						num4 = 0;
						goto IL_036e;
						IL_036e:
						num6 = num4;
						goto IL_0370;
						IL_0370:
						if (num6 < parameters.Length)
						{
							goto IL_037a;
						}
						goto IL_04f3;
						IL_037a:
						class2 = class107_0.method_4();
						goto IL_0387;
						IL_0387:
						type = parameters[parameters.Length - 1 - num6].ParameterType;
						goto IL_0398;
						IL_0398:
						obj2 = null;
						num2 = 0;
						goto IL_039c;
						IL_039c:
						flag = (byte)num2 != 0;
						goto IL_039e;
						IL_039e:
						if (type.IsByRef)
						{
							goto IL_03aa;
						}
						goto IL_04ec;
						IL_03aa:
						class3 = class2 as Class99;
						goto IL_03b3;
						IL_03b3:
						if (class3 != null)
						{
							goto IL_03ba;
						}
						goto IL_04ec;
						IL_03ba:
						if (list == null)
						{
							goto IL_03be;
						}
						goto IL_03c5;
						IL_03be:
						list = new List<Class86>();
						goto IL_03c5;
						IL_03c5:
						list.Add(new Class86(class3.fieldInfo_0, parameters.Length - 1 - num6));
						goto IL_03e0;
						IL_03e0:
						obj2 = class3.object_0;
						goto IL_03e9;
						IL_03e9:
						if (obj2 is Class90)
						{
							goto IL_03f2;
						}
						goto IL_0400;
						IL_03f2:
						class2 = obj2 as Class90;
						goto IL_04ec;
						IL_0400:
						flag = true;
						goto IL_0403;
						IL_0403:
						if (obj2 == null)
						{
							goto IL_040a;
						}
						goto IL_04ec;
						IL_040a:
						if (type.IsByRef)
						{
							goto IL_0413;
						}
						goto IL_041c;
						IL_0413:
						type = type.GetElementType();
						goto IL_041c;
						IL_041c:
						if (type.IsValueType)
						{
							goto IL_0428;
						}
						goto IL_04ec;
						IL_0428:
						if (!class3.fieldInfo_0.IsStatic)
						{
							goto IL_0436;
						}
						goto IL_0441;
						IL_0436:
						obj2 = Activator.CreateInstance(type);
						goto IL_0450;
						IL_0441:
						obj2 = class3.fieldInfo_0.GetValue(null);
						goto IL_0450;
						IL_0450:
						if (class2 is Class97)
						{
							goto IL_045c;
						}
						goto IL_04ec;
						IL_045c:
						((Class96)class2).vmethod_12(Class90.smethod_1(type, obj2));
						goto IL_04ec;
						IL_04ec:
						if (!flag)
						{
							goto IL_0473;
						}
						goto IL_04c8;
						IL_0473:
						if (class2 != null)
						{
							goto IL_0477;
						}
						goto IL_0482;
						IL_0477:
						obj2 = class2.vmethod_4(type);
						goto IL_0482;
						IL_0482:
						if (obj2 == null)
						{
							goto IL_0486;
						}
						goto IL_04c8;
						IL_0486:
						if (type.IsByRef)
						{
							goto IL_048f;
						}
						goto IL_0498;
						IL_048f:
						type = type.GetElementType();
						goto IL_0498;
						IL_0498:
						if (type.IsValueType)
						{
							goto IL_04a1;
						}
						goto IL_04c8;
						IL_04a1:
						obj2 = Activator.CreateInstance(type);
						goto IL_04aa;
						IL_04aa:
						if (class2 is Class97)
						{
							goto IL_04b3;
						}
						goto IL_04c8;
						IL_04b3:
						((Class96)class2).vmethod_12(Class90.smethod_1(type, obj2));
						goto IL_04c8;
						IL_04c8:
						array2[array.Length - 1 - num6] = class2;
						goto IL_04d5;
						IL_04d5:
						array[array.Length - 1 - num6] = obj2;
						goto IL_04e1;
						IL_04e1:
						num6++;
						goto IL_0370;
						IL_04f3:
						@delegate = null;
						goto IL_04f6;
						IL_04f6:
						delegate2 = null;
						goto IL_04f9;
						IL_04f9:
						if (list != null)
						{
							goto IL_04fd;
						}
						goto IL_0518;
						IL_04fd:
						@class = new Class87(methodBase, list);
						goto IL_0507;
						IL_0507:
						@delegate = smethod_3(methodBase, bool_4, @class);
						num = 106;
						goto IL_056d;
						IL_0518:
						if (methodInfo != null)
						{
							goto IL_0521;
						}
						goto IL_0539;
						IL_0521:
						if (methodInfo.ReturnType.IsByRef)
						{
							goto IL_052e;
						}
						goto IL_0539;
						IL_052e:
						@delegate = smethod_2(methodBase, bool_4);
						goto IL_056d;
						IL_0539:
						if (bool_4)
						{
							goto IL_053c;
						}
						goto IL_056d;
						IL_053c:
						if (methodInfo != null)
						{
							goto IL_054e;
						}
						num = 145;
						goto IL_056d;
						IL_08cb:
						if (!@class.method_1(num5))
						{
							goto IL_08d6;
						}
						goto IL_0950;
						IL_054e:
						if (methodBase.IsVirtual)
						{
							goto IL_0556;
						}
						goto IL_056d;
						IL_0556:
						if (!Class79.bool_1)
						{
							num = 160;
							goto IL_0564;
						}
						goto IL_056d;
						IL_08d6:
						if (!array2[num5].pgqjrkspy1())
						{
							goto IL_08e2;
						}
						goto IL_092f;
						IL_0564:
						delegate2 = smethod_6(methodBase, bool_4);
						goto IL_056d;
						IL_056d:
						target = null;
						num = 123;
						goto IL_0574;
						IL_0574:
						class4 = null;
						goto IL_0577;
						IL_0577:
						flag2 = Nullable.GetUnderlyingType(methodBase.DeclaringType) != null;
						goto IL_058a;
						IL_058a:
						if (!methodBase.IsStatic)
						{
							goto IL_0595;
						}
						goto IL_0634;
						IL_0595:
						class4 = class107_0.method_4();
						goto IL_05a2;
						IL_05a2:
						if (class4 != null)
						{
							goto IL_05a6;
						}
						goto IL_05b5;
						IL_05a6:
						target = class4.vmethod_4(methodBase.DeclaringType);
						goto IL_05b5;
						IL_05b5:
						if (target == null)
						{
							goto IL_05b9;
						}
						goto IL_0634;
						IL_05b9:
						if (!flag2)
						{
							goto IL_05bd;
						}
						goto IL_0634;
						IL_05bd:
						type2 = methodBase.DeclaringType;
						goto IL_05c5;
						IL_05c5:
						if (type2.IsByRef)
						{
							goto IL_05ce;
						}
						goto IL_05de;
						IL_05ce:
						type2 = type2.GetElementType();
						num = 155;
						goto IL_05de;
						IL_05de:
						if (!type2.IsValueType)
						{
							num = 99;
							goto IL_05eb;
						}
						goto IL_05f1;
						IL_08e2:
						if (!(array2[num5] is Class97))
						{
							goto IL_08ee;
						}
						goto IL_090c;
						IL_05eb:
						throw new NullReferenceException();
						IL_05f1:
						target = Activator.CreateInstance(type2);
						goto IL_05fa;
						IL_05fa:
						if (target == null)
						{
							goto IL_05fe;
						}
						goto IL_0616;
						IL_05fe:
						if (Nullable.GetUnderlyingType(type2) != null)
						{
							goto IL_060d;
						}
						goto IL_0616;
						IL_060d:
						target = FormatterServices.GetUninitializedObject(type2);
						goto IL_0616;
						IL_0616:
						if (class4 is Class97)
						{
							goto IL_061f;
						}
						goto IL_0634;
						IL_061f:
						((Class96)class4).vmethod_12(Class90.smethod_1(type2, target));
						goto IL_0634;
						IL_0634:
						obj = null;
						goto IL_0637;
						IL_0637:
						if (!(target == null && flag2))
						{
							goto IL_0644;
						}
						goto IL_0752;
						IL_0644:
						if (methodBase is ConstructorInfo)
						{
							goto IL_0655;
						}
						num = 171;
						goto IL_066b;
						IL_08ee:
						array2[num5].vmethod_10(Class90.smethod_1(parameters[num5].ParameterType, array[num5]));
						goto IL_0950;
						IL_0655:
						if (!(Nullable.GetUnderlyingType(methodBase.DeclaringType) != null))
						{
							goto IL_066b;
						}
						goto IL_0716;
						IL_066b:
						if (@delegate != null)
						{
							goto IL_066f;
						}
						goto IL_0681;
						IL_066f:
						obj = @delegate(target, array);
						int num7 = 0;
						goto IL_08a4;
						IL_0681:
						if (delegate2 == null)
						{
							goto IL_0685;
						}
						goto IL_0695;
						IL_0685:
						obj = methodBase.Invoke(target, array);
						goto IL_0853;
						IL_0695:
						obj = delegate2(ref target, array);
						num = 107;
						goto IL_06a5;
						IL_06a5:
						if (!methodBase.DeclaringType.IsClass)
						{
							goto IL_06b5;
						}
						goto IL_0853;
						IL_06b5:
						if (!methodBase.DeclaringType.IsInterface)
						{
							goto IL_06c5;
						}
						goto IL_0853;
						IL_06c5:
						if (class4 != null)
						{
							num = 97;
							goto IL_06d0;
						}
						goto IL_0853;
						IL_090c:
						array2[num5].vmethod_10(Class90.smethod_1(parameters[num5].ParameterType.GetElementType(), array[num5]));
						goto IL_0950;
						IL_06d0:
						if (class4 is Class96)
						{
							goto IL_06dc;
						}
						goto IL_0853;
						IL_06dc:
						type3 = Nullable.GetUnderlyingType(methodBase.DeclaringType);
						goto IL_06e9;
						IL_06e9:
						if (type3 == null)
						{
							goto IL_06f3;
						}
						goto IL_06fb;
						IL_06f3:
						type3 = methodBase.DeclaringType;
						goto IL_06fb;
						IL_06fb:
						((Class96)class4).vmethod_12(Class90.smethod_1(type3, target));
						num7 = 0;
						goto IL_08a4;
						IL_0716:
						obj = array[0];
						goto IL_071b;
						IL_071b:
						if (class4 != null)
						{
							goto IL_0722;
						}
						goto IL_0853;
						IL_0722:
						if (class4 is Class97)
						{
							goto IL_072e;
						}
						goto IL_0853;
						IL_072e:
						((Class96)class4).vmethod_12(Class90.smethod_1(Nullable.GetUnderlyingType(methodBase.DeclaringType), obj));
						num7 = 0;
						goto IL_08a4;
						IL_0752:
						if (methodBase is ConstructorInfo)
						{
							goto IL_0760;
						}
						num = 57;
						goto IL_07b6;
						IL_092f:
						((Class94)array2[num5]).method_5(Class90.smethod_1(parameters[num5].ParameterType, array[num5]));
						goto IL_0950;
						IL_0760:
						if (Nullable.GetUnderlyingType(methodBase.DeclaringType) != null)
						{
							goto IL_0773;
						}
						goto IL_07b6;
						IL_0773:
						obj = array[0];
						goto IL_0778;
						IL_0778:
						if (class4 != null)
						{
							num = 87;
							goto IL_0783;
						}
						goto IL_0853;
						IL_0950:
						num5++;
						goto IL_08a6;
						IL_0783:
						if (class4 is Class97)
						{
							goto IL_0792;
						}
						num7 = 0;
						goto IL_08a4;
						IL_095b:
						if (!(methodInfo != null))
						{
							return;
						}
						goto IL_0964;
						IL_0792:
						((Class96)class4).vmethod_12(Class90.smethod_1(Nullable.GetUnderlyingType(methodBase.DeclaringType), obj));
						num7 = 0;
						goto IL_08a4;
						IL_07b6:
						if (!(methodBase.Name == string_0))
						{
							goto IL_07cb;
						}
						goto IL_089b;
						IL_07cb:
						if (!(methodBase.Name == string_1))
						{
							goto IL_07e0;
						}
						goto IL_0895;
						IL_07e0:
						if (methodBase.Name == string_4)
						{
							goto IL_07f2;
						}
						goto IL_080f;
						IL_07f2:
						if (array[0] != null)
						{
							num3 = 0;
							goto IL_07f8;
						}
						goto IL_0801;
						IL_0964:
						if (!(methodInfo.ReturnType != typeof(void)))
						{
							return;
						}
						goto IL_097b;
						IL_07f8:
						obj = (byte)num3 != 0;
						goto IL_0853;
						IL_0801:
						obj = true;
						num7 = 0;
						goto IL_08a4;
						IL_080f:
						if (!(methodBase.Name == string_3))
						{
							goto IL_0821;
						}
						goto IL_088a;
						IL_0821:
						if (!(methodBase.Name == string_2))
						{
							goto IL_0833;
						}
						goto IL_0856;
						IL_0833:
						if (methodBase.Name == string_5)
						{
							goto IL_0845;
						}
						goto IL_0853;
						IL_0845:
						obj = "";
						num = 76;
						num7 = 0;
						goto IL_08a4;
						IL_0853:
						num7 = 0;
						goto IL_08a4;
						IL_0856:
						class5 = Class105.smethod_0(Nullable.GetUnderlyingType(methodBase.DeclaringType));
						goto IL_0868;
						IL_0868:
						if (array != null)
						{
							goto IL_086b;
						}
						goto IL_087e;
						IL_086b:
						if (array.Length != 0)
						{
							goto IL_086f;
						}
						goto IL_087e;
						IL_086f:
						obj = class5.vmethod_3(array[0]);
						num7 = 0;
						goto IL_08a4;
						IL_087e:
						obj = class5.vmethod_2();
						num7 = 0;
						goto IL_08a4;
						IL_088a:
						obj = 0;
						num7 = 0;
						goto IL_08a4;
						IL_0895:
						obj = null;
						num7 = 0;
						goto IL_08a4;
						IL_089b:
						obj = false;
						num7 = 0;
						goto IL_08a4;
						IL_08a4:
						num5 = num7;
						goto IL_08a6;
						IL_08a6:
						if (num5 < parameters.Length)
						{
							num = 25;
							goto IL_08b4;
						}
						goto IL_095b;
						continue;
						end_IL_030b:
						break;
					}
					continue;
					end_IL_031a:
					break;
				}
			}
		}

		private static Delegate16 smethod_2(object object_8, bool bool_4)
		{
			lock (object_3)
			{
				Delegate16 value = null;
				if (bool_4)
				{
					if (dictionary_2.TryGetValue((MethodBase)object_8, out value))
					{
						return value;
					}
				}
				else if (dictionary_3.TryGetValue((MethodBase)object_8, out value))
				{
					return value;
				}
				MethodInfo methodInfo = object_8 as MethodInfo;
				DynamicMethod dynamicMethod = new DynamicMethod(string.Empty, typeof(object), new Type[2]
				{
					typeof(object),
					typeof(object[])
				}, restrictedSkipVisibility: true);
				ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
				ParameterInfo[] parameters = ((MethodBase)object_8).GetParameters();
				Type[] array = new Type[parameters.Length];
				for (int i = 0; i < array.Length; i++)
				{
					if (!parameters[i].ParameterType.IsByRef)
					{
						array[i] = parameters[i].ParameterType;
					}
					else
					{
						array[i] = parameters[i].ParameterType.GetElementType();
					}
				}
				int num = array.Length;
				if (((MemberInfo)object_8).DeclaringType.IsValueType)
				{
					num++;
				}
				LocalBuilder[] array2 = new LocalBuilder[num];
				for (int j = 0; j < array.Length; j++)
				{
					array2[j] = iLGenerator.DeclareLocal(array[j]);
				}
				int num2;
				if (!((MemberInfo)object_8).DeclaringType.IsValueType)
				{
					num2 = 0;
				}
				else
				{
					array2[^1] = iLGenerator.DeclareLocal(((MemberInfo)object_8).DeclaringType);
					num2 = 0;
				}
				for (int k = num2; k < array.Length; k++)
				{
					iLGenerator.Emit(OpCodes.Ldarg_1);
					smethod_5(iLGenerator, k);
					iLGenerator.Emit(OpCodes.Ldelem_Ref);
					if (array[k].IsValueType)
					{
						iLGenerator.Emit(OpCodes.Unbox_Any, array[k]);
					}
					else if (array[k] != typeof(object))
					{
						iLGenerator.Emit(OpCodes.Castclass, array[k]);
					}
					iLGenerator.Emit(OpCodes.Stloc, array2[k]);
				}
				int num3;
				if (!((MethodBase)object_8).IsStatic)
				{
					iLGenerator.Emit(OpCodes.Ldarg_0);
					if (!((MemberInfo)object_8).DeclaringType.IsValueType)
					{
						iLGenerator.Emit(OpCodes.Castclass, ((MemberInfo)object_8).DeclaringType);
						num3 = 0;
						goto IL_0256;
					}
					iLGenerator.Emit(OpCodes.Unbox_Any, ((MemberInfo)object_8).DeclaringType);
					iLGenerator.Emit(OpCodes.Stloc, array2[^1]);
					iLGenerator.Emit(OpCodes.Ldloca_S, array2[^1]);
				}
				num3 = 0;
				goto IL_0256;
				IL_03b5:
				int num4;
				for (int l = num4; l < array.Length; l++)
				{
					if (parameters[l].ParameterType.IsByRef)
					{
						iLGenerator.Emit(OpCodes.Ldarg_1);
						smethod_5(iLGenerator, l);
						iLGenerator.Emit(OpCodes.Ldloc, array2[l]);
						if (array2[l].LocalType.IsValueType)
						{
							iLGenerator.Emit(OpCodes.Box, array2[l].LocalType);
						}
						iLGenerator.Emit(OpCodes.Stelem_Ref);
					}
				}
				iLGenerator.Emit(OpCodes.Ret);
				Delegate16 @delegate = (Delegate16)dynamicMethod.CreateDelegate(typeof(Delegate16));
				if (!bool_4)
				{
					dictionary_3.Add((MethodBase)object_8, @delegate);
				}
				else
				{
					dictionary_2.Add((MethodBase)object_8, @delegate);
				}
				return @delegate;
				IL_0394:
				num4 = 0;
				goto IL_03b5;
				IL_0256:
				for (int m = num3; m < array.Length; m++)
				{
					if (!parameters[m].ParameterType.IsByRef)
					{
						iLGenerator.Emit(OpCodes.Ldloc, array2[m]);
					}
					else
					{
						iLGenerator.Emit(OpCodes.Ldloca_S, array2[m]);
					}
				}
				if (!bool_4)
				{
					if (methodInfo != null)
					{
						iLGenerator.EmitCall(OpCodes.Callvirt, methodInfo, null);
					}
					else
					{
						iLGenerator.Emit(OpCodes.Callvirt, object_8 as ConstructorInfo);
					}
				}
				else if (methodInfo != null)
				{
					iLGenerator.EmitCall(OpCodes.Call, methodInfo, null);
				}
				else
				{
					iLGenerator.Emit(OpCodes.Call, object_8 as ConstructorInfo);
				}
				if (!(methodInfo == null) && !(methodInfo.ReturnType == typeof(void)))
				{
					if (!methodInfo.ReturnType.IsByRef)
					{
						if (!methodInfo.ReturnType.IsValueType)
						{
							goto IL_0394;
						}
						iLGenerator.Emit(OpCodes.Box, methodInfo.ReturnType);
						num4 = 0;
					}
					else
					{
						Type elementType = methodInfo.ReturnType.GetElementType();
						if (!elementType.IsValueType)
						{
							iLGenerator.Emit(OpCodes.Ldind_Ref, elementType);
						}
						else
						{
							iLGenerator.Emit(OpCodes.Ldobj, elementType);
						}
						if (!elementType.IsValueType)
						{
							goto IL_0394;
						}
						iLGenerator.Emit(OpCodes.Box, elementType);
						num4 = 0;
					}
				}
				else
				{
					iLGenerator.Emit(OpCodes.Ldnull);
					num4 = 0;
				}
				goto IL_03b5;
			}
		}

		private static Delegate16 smethod_3(object object_8, bool bool_4, Class87 class87_0)
		{
			Delegate16 result = default(Delegate16);
			lock (object_4)
			{
				Class86 @class = default(Class86);
				Type elementType = default(Type);
				Class86 class2 = default(Class86);
				while (true)
				{
					Delegate16 value = null;
					while (true)
					{
						IL_095b:
						if (bool_4)
						{
							goto IL_0931;
						}
						goto IL_0949;
						IL_0949:
						if (!dictionary_5.TryGetValue(class87_0, out value))
						{
							goto IL_0940;
						}
						goto IL_097f;
						IL_0940:
						while (true)
						{
							IL_0940_2:
							MethodInfo methodInfo = object_8 as MethodInfo;
							while (true)
							{
								DynamicMethod dynamicMethod = new DynamicMethod(string.Empty, typeof(object), new Type[2]
								{
									typeof(object),
									typeof(object[])
								}, typeof(Class79), skipVisibility: true);
								while (true)
								{
									ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
									int num = 125;
									while (true)
									{
										ParameterInfo[] parameters = ((MethodBase)object_8).GetParameters();
										while (true)
										{
											Type[] array = new Type[parameters.Length];
											int num2 = 0;
											while (true)
											{
												int num3 = num2;
												while (true)
												{
													if (num3 >= array.Length)
													{
														while (true)
														{
															IL_0874:
															int num4 = array.Length;
															while (true)
															{
																IL_0864:
																if (((MemberInfo)object_8).DeclaringType.IsValueType)
																{
																	goto IL_084c;
																}
																goto IL_0855;
																IL_0855:
																while (true)
																{
																	IL_0855_2:
																	LocalBuilder[] array2 = new LocalBuilder[num4];
																	num = 127;
																	int num5 = 0;
																	while (true)
																	{
																		int num6 = num5;
																		while (true)
																		{
																			IL_0839:
																			if (num6 >= array.Length)
																			{
																				while (true)
																				{
																					IL_0829:
																					if (((MemberInfo)object_8).DeclaringType.IsValueType)
																					{
																						goto IL_0803;
																					}
																					goto IL_0826;
																					IL_0826:
																					int num7 = 0;
																					goto IL_081f;
																					IL_081f:
																					int num8 = num7;
																					num = 110;
																					while (true)
																					{
																						IL_07f2:
																						if (num8 >= array.Length)
																						{
																							while (true)
																							{
																								IL_0755:
																								if (!((MethodBase)object_8).IsStatic)
																								{
																									goto IL_06e3;
																								}
																								goto IL_0752;
																								IL_0752:
																								int num9 = 0;
																								goto IL_074e;
																								IL_074e:
																								int num10 = num9;
																								while (true)
																								{
																									IL_06d5:
																									if (num10 >= array.Length)
																									{
																										while (true)
																										{
																											IL_06cf:
																											if (bool_4)
																											{
																												goto IL_0675;
																											}
																											goto IL_06c3;
																											IL_06c3:
																											if (methodInfo != null)
																											{
																												goto IL_0665;
																											}
																											goto IL_06af;
																											IL_06af:
																											iLGenerator.Emit(OpCodes.Callvirt, object_8 as ConstructorInfo);
																											goto IL_06a0;
																											IL_06a0:
																											while (true)
																											{
																												IL_06a0_2:
																												if (!(methodInfo == null))
																												{
																													goto IL_05b1;
																												}
																												goto IL_0656;
																												IL_0656:
																												iLGenerator.Emit(OpCodes.Ldnull);
																												int num11 = 0;
																												goto IL_064f;
																												IL_064f:
																												while (true)
																												{
																													int num12 = num11;
																													while (true)
																													{
																														IL_05a0:
																														if (num12 >= array.Length)
																														{
																															while (true)
																															{
																																IL_0430:
																																iLGenerator.Emit(OpCodes.Ret);
																																num = 84;
																																while (true)
																																{
																																	IL_0416:
																																	Delegate16 @delegate = (Delegate16)dynamicMethod.CreateDelegate(typeof(Delegate16));
																																	while (true)
																																	{
																																		IL_040d:
																																		if (bool_4)
																																		{
																																			while (true)
																																			{
																																				IL_03f8:
																																				dictionary_4.Add(class87_0, @delegate);
																																				num = 163;
																																				while (num != 163)
																																				{
																																					if (num != 1143)
																																					{
																																						goto end_IL_040d;
																																					}
																																					switch (num)
																																					{
																																					case 122:
																																						break;
																																					case 111:
																																					case 135:
																																						goto IL_0020;
																																					case 95:
																																						goto IL_0033;
																																					case 56:
																																					case 106:
																																						goto IL_0049;
																																					case 119:
																																						goto IL_0054;
																																					case 118:
																																						goto IL_005e;
																																					case 113:
																																						goto IL_006f;
																																					case 142:
																																						goto IL_0085;
																																					case 5:
																																						goto IL_009b;
																																					case 10:
																																						goto IL_00a5;
																																					case 115:
																																						goto IL_00b3;
																																					case 70:
																																						goto IL_00cb;
																																					case 9:
																																					case 32:
																																						goto IL_00de;
																																					case 78:
																																						goto IL_00ef;
																																					case 43:
																																						goto IL_0107;
																																					case 90:
																																						goto IL_011c;
																																					case 108:
																																						goto IL_012d;
																																					case 148:
																																						goto IL_0145;
																																					case 1:
																																					case 12:
																																					case 89:
																																					case 114:
																																					case 133:
																																						goto IL_0158;
																																					default:
																																						continue;
																																					case 136:
																																						goto IL_03f8;
																																					case 23:
																																						goto IL_040d;
																																					case 84:
																																						goto IL_0416;
																																					case 116:
																																						goto IL_0430;
																																					case 104:
																																					case 152:
																																						goto IL_0441;
																																					case 59:
																																						goto IL_0455;
																																					case 26:
																																					case 86:
																																						goto IL_0465;
																																					case 39:
																																						goto IL_046f;
																																					case 55:
																																						goto IL_047d;
																																					case 76:
																																						goto IL_0489;
																																					case 27:
																																						goto IL_0492;
																																					case 49:
																																						goto IL_04a5;
																																					case 66:
																																						goto IL_04b8;
																																					case 22:
																																						goto IL_04d0;
																																					case 112:
																																						goto IL_04e1;
																																					case 37:
																																						goto IL_04ed;
																																					case 40:
																																						goto IL_04f6;
																																					case 33:
																																						goto IL_0507;
																																					case 100:
																																						goto IL_0518;
																																					case 44:
																																					case 101:
																																						goto IL_0530;
																																					case 102:
																																						goto IL_053e;
																																					case 123:
																																						goto IL_054a;
																																					case 36:
																																						goto IL_0556;
																																					case 73:
																																						goto IL_0567;
																																					case 46:
																																						goto IL_0578;
																																					case 62:
																																					case 150:
																																						goto IL_058e;
																																					case 21:
																																					case 74:
																																					case 147:
																																						goto IL_059a;
																																					case 8:
																																					case 134:
																																						goto IL_05a0;
																																					case 67:
																																						goto IL_05b1;
																																					case 65:
																																						goto IL_05cb;
																																					case 48:
																																						goto IL_05d8;
																																					case 31:
																																						goto IL_05e5;
																																					case 87:
																																						goto IL_05ee;
																																					case 96:
																																						goto IL_05fe;
																																					case 124:
																																					case 131:
																																						goto IL_060c;
																																					case 28:
																																						goto IL_0618;
																																					case 98:
																																					case 143:
																																						goto IL_0629;
																																					case 45:
																																						goto IL_0639;
																																					case 7:
																																					case 20:
																																					case 57:
																																					case 81:
																																					case 149:
																																						goto IL_064e;
																																					case 17:
																																						goto IL_0656;
																																					case 34:
																																						goto IL_0665;
																																					case 154:
																																						goto IL_0675;
																																					case 80:
																																						goto IL_067e;
																																					case 72:
																																						goto IL_068e;
																																					case 18:
																																					case 71:
																																					case 99:
																																					case 120:
																																						goto IL_06a0_2;
																																					case 25:
																																						goto IL_06af;
																																					case 139:
																																						goto IL_06c3;
																																					case 109:
																																						goto IL_06cf;
																																					case 29:
																																					case 58:
																																						goto IL_06d5;
																																					case 140:
																																						goto IL_06e3;
																																					case 14:
																																						goto IL_06ef;
																																					case 15:
																																						goto IL_06fc;
																																					case 103:
																																						goto IL_070e;
																																					case 51:
																																						goto IL_0723;
																																					case 50:
																																						goto IL_073b;
																																					case 35:
																																					case 68:
																																						goto IL_0752;
																																					case 128:
																																						goto IL_0755;
																																					case 129:
																																					case 141:
																																						goto IL_0760;
																																					case 60:
																																						goto IL_076c;
																																					case 155:
																																						goto IL_0775;
																																					case 105:
																																						goto IL_0781;
																																					case 52:
																																						goto IL_078b;
																																					case 38:
																																					case 79:
																																						goto IL_0797;
																																					case 3:
																																						goto IL_07b2;
																																					case 63:
																																						goto IL_07c8;
																																					case 53:
																																					case 82:
																																					case 83:
																																					case 85:
																																						goto IL_07d9;
																																					case 6:
																																						goto IL_07ec;
																																					case 61:
																																					case 110:
																																						goto IL_07f2;
																																					case 88:
																																						goto IL_0803;
																																					case 151:
																																						goto IL_0826;
																																					case 137:
																																						goto IL_0829;
																																					case 13:
																																					case 16:
																																						goto IL_0839;
																																					case 127:
																																						goto IL_0847;
																																					case 91:
																																						goto IL_084c;
																																					case 54:
																																						goto IL_0855_2;
																																					case 2:
																																						goto IL_0864;
																																					case 107:
																																						goto IL_0874;
																																					case 64:
																																					case 153:
																																						goto IL_087c;
																																					case 0:
																																					case 30:
																																						goto IL_088d;
																																					case 11:
																																						goto IL_089e;
																																					case 69:
																																					case 92:
																																						goto IL_08b2;
																																					case 93:
																																					case 146:
																																						goto end_IL_040d;
																																					case 130:
																																						goto end_IL_08b8;
																																					case 77:
																																						goto end_IL_08c4;
																																					case 125:
																																						goto end_IL_08c8;
																																					case 97:
																																						goto end_IL_08d6;
																																					case 94:
																																						goto end_IL_08e0;
																																					case 47:
																																						goto end_IL_08ee;
																																					case 24:
																																					case 41:
																																						goto IL_0940_2;
																																					case 121:
																																						goto IL_0949;
																																					case 132:
																																						goto IL_095b;
																																					case 145:
																																						goto end_IL_095b;
																																					case 4:
																																					case 75:
																																						goto IL_0965;
																																					case 144:
																																						goto IL_0974;
																																					case 126:
																																						goto end_IL_0961;
																																					case 19:
																																						goto end_IL_03e7;
																																					case 117:
																																						goto end_IL_0961;
																																					case 42:
																																						goto IL_097f;
																																					case 138:
																																						goto end_IL_0961;
																																					}
																																					goto IL_0016;
																																					continue;
																																					end_IL_03e7:
																																					break;
																																				}
																																				break;
																																			}
																																			goto IL_0979;
																																		}
																																		goto IL_0965;
																																		IL_0979:
																																		result = @delegate;
																																		return result;
																																		IL_0965:
																																		dictionary_5.Add(class87_0, @delegate);
																																		goto IL_0979;
																																		continue;
																																		end_IL_040d:
																																		break;
																																	}
																																	break;
																																}
																																break;
																															}
																															break;
																														}
																														goto IL_0441;
																														IL_058e:
																														iLGenerator.Emit(OpCodes.Stelem_Ref);
																														goto IL_059a;
																														IL_0441:
																														if (parameters[num12].ParameterType.IsByRef)
																														{
																															goto IL_0455;
																														}
																														goto IL_059a;
																														IL_0455:
																														if (class87_0.method_1(num12))
																														{
																															num = 26;
																															goto IL_0465;
																														}
																														goto IL_053e;
																														IL_059a:
																														num12++;
																														continue;
																														IL_0465:
																														@class = class87_0.method_0(num12);
																														goto IL_046f;
																														IL_046f:
																														if (((FieldInfo)@class.object_0).IsStatic)
																														{
																															goto IL_047d;
																														}
																														goto IL_04e1;
																														IL_047d:
																														iLGenerator.Emit(OpCodes.Ldarg_1);
																														goto IL_0489;
																														IL_0489:
																														smethod_5(iLGenerator, num12);
																														goto IL_0492;
																														IL_0492:
																														iLGenerator.Emit(OpCodes.Ldsfld, (FieldInfo)@class.object_0);
																														goto IL_04a5;
																														IL_04a5:
																														if (((FieldInfo)@class.object_0).FieldType.IsValueType)
																														{
																															goto IL_04b8;
																														}
																														goto IL_04d0;
																														IL_04b8:
																														iLGenerator.Emit(OpCodes.Box, ((FieldInfo)@class.object_0).FieldType);
																														goto IL_04d0;
																														IL_04d0:
																														iLGenerator.Emit(OpCodes.Stelem_Ref);
																														goto IL_059a;
																														IL_04e1:
																														iLGenerator.Emit(OpCodes.Ldarg_1);
																														goto IL_04ed;
																														IL_04ed:
																														smethod_5(iLGenerator, num12);
																														goto IL_04f6;
																														IL_04f6:
																														iLGenerator.Emit(OpCodes.Ldloc, array2[num12]);
																														goto IL_0507;
																														IL_0507:
																														if (array2[num12].LocalType.IsValueType)
																														{
																															goto IL_0518;
																														}
																														goto IL_0530;
																														IL_0518:
																														iLGenerator.Emit(OpCodes.Box, ((FieldInfo)@class.object_0).FieldType);
																														goto IL_0530;
																														IL_0530:
																														iLGenerator.Emit(OpCodes.Stelem_Ref);
																														goto IL_059a;
																														IL_053e:
																														iLGenerator.Emit(OpCodes.Ldarg_1);
																														goto IL_054a;
																														IL_054a:
																														smethod_5(iLGenerator, num12);
																														num = 36;
																														goto IL_0556;
																														IL_0556:
																														iLGenerator.Emit(OpCodes.Ldloc, array2[num12]);
																														goto IL_0567;
																														IL_0567:
																														if (array2[num12].LocalType.IsValueType)
																														{
																															goto IL_0578;
																														}
																														goto IL_058e;
																														IL_0578:
																														iLGenerator.Emit(OpCodes.Box, array2[num12].LocalType);
																														goto IL_058e;
																													}
																													break;
																													IL_064e:
																													num11 = 0;
																												}
																												break;
																												IL_05b1:
																												if (!(methodInfo.ReturnType == typeof(void)))
																												{
																													goto IL_05cb;
																												}
																												goto IL_0656;
																												IL_05cb:
																												if (methodInfo.ReturnType.IsByRef)
																												{
																													goto IL_05d8;
																												}
																												goto IL_0629;
																												IL_05d8:
																												elementType = methodInfo.ReturnType.GetElementType();
																												goto IL_05e5;
																												IL_05e5:
																												if (elementType.IsValueType)
																												{
																													goto IL_05ee;
																												}
																												goto IL_05fe;
																												IL_05ee:
																												iLGenerator.Emit(OpCodes.Ldobj, elementType);
																												goto IL_060c;
																												IL_05fe:
																												iLGenerator.Emit(OpCodes.Ldind_Ref, elementType);
																												goto IL_060c;
																												IL_060c:
																												if (elementType.IsValueType)
																												{
																													goto IL_0618;
																												}
																												num11 = 0;
																												goto IL_064f;
																												IL_0639:
																												iLGenerator.Emit(OpCodes.Box, methodInfo.ReturnType);
																												num11 = 0;
																												goto IL_064f;
																												IL_0618:
																												iLGenerator.Emit(OpCodes.Box, elementType);
																												num11 = 0;
																												goto IL_064f;
																												IL_0629:
																												if (methodInfo.ReturnType.IsValueType)
																												{
																													goto IL_0639;
																												}
																												num11 = 0;
																												goto IL_064f;
																											}
																											break;
																											IL_0675:
																											if (methodInfo != null)
																											{
																												goto IL_067e;
																											}
																											goto IL_068e;
																											IL_067e:
																											iLGenerator.EmitCall(OpCodes.Call, methodInfo, null);
																											goto IL_06a0;
																											IL_068e:
																											iLGenerator.Emit(OpCodes.Call, object_8 as ConstructorInfo);
																											goto IL_06a0;
																											IL_0665:
																											iLGenerator.EmitCall(OpCodes.Callvirt, methodInfo, null);
																											goto IL_06a0;
																										}
																										break;
																									}
																									goto IL_0054;
																									IL_0158:
																									num10++;
																									continue;
																									IL_0054:
																									if (!class87_0.method_1(num10))
																									{
																										goto IL_005e;
																									}
																									goto IL_009b;
																									IL_005e:
																									if (parameters[num10].ParameterType.IsByRef)
																									{
																										goto IL_006f;
																									}
																									goto IL_0085;
																									IL_006f:
																									iLGenerator.Emit(OpCodes.Ldloca_S, array2[num10]);
																									goto IL_0158;
																									IL_0085:
																									iLGenerator.Emit(OpCodes.Ldloc, array2[num10]);
																									goto IL_0158;
																									IL_009b:
																									class2 = class87_0.method_0(num10);
																									goto IL_00a5;
																									IL_00a5:
																									if (((FieldInfo)class2.object_0).IsStatic)
																									{
																										goto IL_00b3;
																									}
																									goto IL_00cb;
																									IL_00b3:
																									iLGenerator.Emit(OpCodes.Ldsflda, (FieldInfo)class2.object_0);
																									goto IL_0158;
																									IL_00cb:
																									if (!((MemberInfo)class2.object_0).DeclaringType.IsValueType)
																									{
																										goto IL_00de;
																									}
																									goto IL_011c;
																									IL_00de:
																									iLGenerator.Emit(OpCodes.Ldloc, array2[num10]);
																									goto IL_00ef;
																									IL_00ef:
																									iLGenerator.Emit(OpCodes.Castclass, ((MemberInfo)class2.object_0).DeclaringType);
																									goto IL_0107;
																									IL_0107:
																									iLGenerator.Emit(OpCodes.Ldflda, (FieldInfo)class2.object_0);
																									goto IL_0158;
																									IL_011c:
																									iLGenerator.Emit(OpCodes.Ldloc, array2[num10]);
																									goto IL_012d;
																									IL_012d:
																									iLGenerator.Emit(OpCodes.Unbox, ((MemberInfo)class2.object_0).DeclaringType);
																									goto IL_0145;
																									IL_0145:
																									iLGenerator.Emit(OpCodes.Ldflda, (FieldInfo)class2.object_0);
																									goto IL_0158;
																								}
																								break;
																								IL_073b:
																								iLGenerator.Emit(OpCodes.Castclass, ((MemberInfo)object_8).DeclaringType);
																								num9 = 0;
																								goto IL_074e;
																								IL_06e3:
																								iLGenerator.Emit(OpCodes.Ldarg_0);
																								goto IL_06ef;
																								IL_06ef:
																								if (((MemberInfo)object_8).DeclaringType.IsValueType)
																								{
																									goto IL_06fc;
																								}
																								goto IL_073b;
																								IL_06fc:
																								iLGenerator.Emit(OpCodes.Unbox, ((MemberInfo)object_8).DeclaringType);
																								goto IL_070e;
																								IL_070e:
																								iLGenerator.Emit(OpCodes.Stloc, array2[^1]);
																								goto IL_0723;
																								IL_0723:
																								iLGenerator.Emit(OpCodes.Ldloc_S, array2[^1]);
																								num9 = 0;
																								goto IL_074e;
																							}
																							break;
																						}
																						goto IL_0760;
																						IL_07d9:
																						iLGenerator.Emit(OpCodes.Stloc, array2[num8]);
																						num = 6;
																						goto IL_07ec;
																						IL_0760:
																						iLGenerator.Emit(OpCodes.Ldarg_1);
																						goto IL_076c;
																						IL_076c:
																						smethod_5(iLGenerator, num8);
																						goto IL_0775;
																						IL_0775:
																						iLGenerator.Emit(OpCodes.Ldelem_Ref);
																						goto IL_0781;
																						IL_0781:
																						if (!class87_0.method_1(num8))
																						{
																							goto IL_078b;
																						}
																						goto IL_07d9;
																						IL_078b:
																						if (!array[num8].IsValueType)
																						{
																							goto IL_0797;
																						}
																						goto IL_07c8;
																						IL_0797:
																						if (array[num8] != typeof(object))
																						{
																							goto IL_07b2;
																						}
																						num = 82;
																						goto IL_07d9;
																						IL_07ec:
																						num8++;
																						continue;
																						IL_07b2:
																						iLGenerator.Emit(OpCodes.Castclass, array[num8]);
																						num = 83;
																						goto IL_07d9;
																						IL_07c8:
																						iLGenerator.Emit(OpCodes.Unbox_Any, array[num8]);
																						goto IL_07d9;
																					}
																					break;
																					IL_0803:
																					array2[^1] = iLGenerator.DeclareLocal(((MemberInfo)object_8).DeclaringType.MakeByRefType());
																					num7 = 0;
																					goto IL_081f;
																				}
																				break;
																			}
																			goto IL_0016;
																			IL_0049:
																			num6++;
																			continue;
																			IL_0016:
																			if (!class87_0.method_1(num6))
																			{
																				goto IL_0020;
																			}
																			goto IL_0033;
																			IL_0020:
																			array2[num6] = iLGenerator.DeclareLocal(array[num6]);
																			goto IL_0049;
																			IL_0033:
																			array2[num6] = iLGenerator.DeclareLocal(typeof(object));
																			goto IL_0049;
																		}
																		break;
																		IL_0847:
																		num5 = 0;
																	}
																	break;
																}
																break;
																IL_084c:
																num4++;
																num = 54;
																goto IL_0855;
															}
															break;
														}
														continue;
													}
													goto IL_087c;
													IL_08b2:
													num3++;
													continue;
													IL_087c:
													if (!parameters[num3].ParameterType.IsByRef)
													{
														goto IL_088d;
													}
													goto IL_089e;
													IL_088d:
													array[num3] = parameters[num3].ParameterType;
													goto IL_08b2;
													IL_089e:
													array[num3] = parameters[num3].ParameterType.GetElementType();
													goto IL_08b2;
													continue;
													end_IL_08b8:
													break;
												}
												num2 = 0;
												continue;
												end_IL_08c4:
												break;
											}
											continue;
											end_IL_08c8:
											break;
										}
										continue;
										end_IL_08d6:
										break;
									}
									continue;
									end_IL_08e0:
									break;
								}
								continue;
								end_IL_08ee:
								break;
							}
							break;
						}
						goto IL_0931;
						IL_0931:
						if (!dictionary_4.TryGetValue(class87_0, out value))
						{
							goto IL_0940;
						}
						goto IL_0974;
						IL_0974:
						result = value;
						return result;
						IL_097f:
						result = value;
						return result;
						continue;
						end_IL_095b:
						break;
					}
					continue;
					end_IL_0961:
					break;
				}
			}
			return result;
		}

		private static Delegate16 smethod_4(object object_8, bool bool_4, Class87 class87_0)
		{
			lock (object_5)
			{
				Delegate16 value = null;
				if (!dictionary_6.TryGetValue(class87_0, out value))
				{
					ConstructorInfo constructorInfo = object_8 as ConstructorInfo;
					DynamicMethod dynamicMethod = new DynamicMethod(string.Empty, typeof(object), new Type[2]
					{
						typeof(object),
						typeof(object[])
					}, typeof(Class79), skipVisibility: true);
					ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
					ParameterInfo[] parameters = ((MethodBase)object_8).GetParameters();
					Type[] array = new Type[parameters.Length];
					for (int i = 0; i < array.Length; i++)
					{
						if (!parameters[i].ParameterType.IsByRef)
						{
							array[i] = parameters[i].ParameterType;
						}
						else
						{
							array[i] = parameters[i].ParameterType.GetElementType();
						}
					}
					int num = array.Length;
					if (((MemberInfo)object_8).DeclaringType.IsValueType)
					{
						num++;
					}
					LocalBuilder[] array2 = new LocalBuilder[num];
					for (int j = 0; j < array.Length; j++)
					{
						if (!class87_0.method_1(j))
						{
							array2[j] = iLGenerator.DeclareLocal(array[j]);
						}
						else
						{
							array2[j] = iLGenerator.DeclareLocal(typeof(object));
						}
					}
					int num2;
					if (((MemberInfo)object_8).DeclaringType.IsValueType)
					{
						array2[^1] = iLGenerator.DeclareLocal(((MemberInfo)object_8).DeclaringType.MakeByRefType());
						num2 = 0;
					}
					else
					{
						num2 = 0;
					}
					for (int k = num2; k < array.Length; k++)
					{
						iLGenerator.Emit(OpCodes.Ldarg_1);
						smethod_5(iLGenerator, k);
						iLGenerator.Emit(OpCodes.Ldelem_Ref);
						if (!class87_0.method_1(k))
						{
							if (!array[k].IsValueType)
							{
								if (array[k] != typeof(object))
								{
									iLGenerator.Emit(OpCodes.Castclass, array[k]);
								}
							}
							else
							{
								iLGenerator.Emit(OpCodes.Unbox_Any, array[k]);
							}
						}
						iLGenerator.Emit(OpCodes.Stloc, array2[k]);
					}
					for (int l = 0; l < array.Length; l++)
					{
						if (!class87_0.method_1(l))
						{
							if (parameters[l].ParameterType.IsByRef)
							{
								iLGenerator.Emit(OpCodes.Ldloca_S, array2[l]);
							}
							else
							{
								iLGenerator.Emit(OpCodes.Ldloc, array2[l]);
							}
							continue;
						}
						Class86 @class = class87_0.method_0(l);
						if (((FieldInfo)@class.object_0).IsStatic)
						{
							iLGenerator.Emit(OpCodes.Ldsflda, (FieldInfo)@class.object_0);
						}
						else if (((MemberInfo)@class.object_0).DeclaringType.IsValueType)
						{
							iLGenerator.Emit(OpCodes.Ldloc, array2[l]);
							iLGenerator.Emit(OpCodes.Unbox, ((MemberInfo)@class.object_0).DeclaringType);
							iLGenerator.Emit(OpCodes.Ldflda, (FieldInfo)@class.object_0);
						}
						else
						{
							iLGenerator.Emit(OpCodes.Ldloc, array2[l]);
							iLGenerator.Emit(OpCodes.Castclass, ((MemberInfo)@class.object_0).DeclaringType);
							iLGenerator.Emit(OpCodes.Ldflda, (FieldInfo)@class.object_0);
						}
					}
					iLGenerator.Emit(OpCodes.Newobj, object_8 as ConstructorInfo);
					if (constructorInfo.DeclaringType.IsValueType)
					{
						iLGenerator.Emit(OpCodes.Box, constructorInfo.DeclaringType);
					}
					for (int m = 0; m < array.Length; m++)
					{
						if (!parameters[m].ParameterType.IsByRef)
						{
							continue;
						}
						if (!class87_0.method_1(m))
						{
							iLGenerator.Emit(OpCodes.Ldarg_1);
							smethod_5(iLGenerator, m);
							iLGenerator.Emit(OpCodes.Ldloc, array2[m]);
							if (array2[m].LocalType.IsValueType)
							{
								iLGenerator.Emit(OpCodes.Box, array2[m].LocalType);
							}
							iLGenerator.Emit(OpCodes.Stelem_Ref);
							continue;
						}
						Class86 class2 = class87_0.method_0(m);
						if (((FieldInfo)class2.object_0).IsStatic)
						{
							iLGenerator.Emit(OpCodes.Ldarg_1);
							smethod_5(iLGenerator, m);
							iLGenerator.Emit(OpCodes.Ldsfld, (FieldInfo)class2.object_0);
							if (((FieldInfo)class2.object_0).FieldType.IsValueType)
							{
								iLGenerator.Emit(OpCodes.Box, array2[m].LocalType);
							}
							iLGenerator.Emit(OpCodes.Stelem_Ref);
						}
						else
						{
							iLGenerator.Emit(OpCodes.Ldarg_1);
							smethod_5(iLGenerator, m);
							iLGenerator.Emit(OpCodes.Ldloc, array2[m]);
							if (array2[m].LocalType.IsValueType)
							{
								iLGenerator.Emit(OpCodes.Box, array2[m].LocalType);
							}
							iLGenerator.Emit(OpCodes.Stelem_Ref);
						}
					}
					iLGenerator.Emit(OpCodes.Ret);
					Delegate16 @delegate = (Delegate16)dynamicMethod.CreateDelegate(typeof(Delegate16));
					dictionary_6.Add(class87_0, @delegate);
					return @delegate;
				}
				return value;
			}
		}

		private static void smethod_5(ILGenerator ilgenerator_0, int int_3)
		{
			switch (int_3)
			{
			case -1:
				ilgenerator_0.Emit(OpCodes.Ldc_I4_M1);
				return;
			case 0:
				ilgenerator_0.Emit(OpCodes.Ldc_I4_0);
				return;
			case 1:
				ilgenerator_0.Emit(OpCodes.Ldc_I4_1);
				return;
			case 2:
				ilgenerator_0.Emit(OpCodes.Ldc_I4_2);
				return;
			case 3:
				ilgenerator_0.Emit(OpCodes.Ldc_I4_3);
				return;
			case 4:
				ilgenerator_0.Emit(OpCodes.Ldc_I4_4);
				return;
			case 5:
				ilgenerator_0.Emit(OpCodes.Ldc_I4_5);
				return;
			case 6:
				ilgenerator_0.Emit(OpCodes.Ldc_I4_6);
				return;
			case 7:
				ilgenerator_0.Emit(OpCodes.Ldc_I4_7);
				return;
			case 8:
				ilgenerator_0.Emit(OpCodes.Ldc_I4_8);
				return;
			}
			if (int_3 > -129 && int_3 < 128)
			{
				ilgenerator_0.Emit(OpCodes.Ldc_I4_S, (sbyte)int_3);
			}
			else
			{
				ilgenerator_0.Emit(OpCodes.Ldc_I4, int_3);
			}
		}

		private static Delegate21 smethod_6(object object_8, bool bool_4)
		{
			lock (object_6)
			{
				Delegate21 value = null;
				if (!bool_4)
				{
					if (dictionary_8.TryGetValue((MethodBase)object_8, out value))
					{
						return value;
					}
				}
				else if (dictionary_7.TryGetValue((MethodBase)object_8, out value))
				{
					return value;
				}
				MethodInfo methodInfo = object_8 as MethodInfo;
				DynamicMethod dynamicMethod = new DynamicMethod(string.Empty, typeof(object), new Type[2]
				{
					typeof(object).MakeByRefType(),
					typeof(object[])
				}, restrictedSkipVisibility: true);
				ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
				ParameterInfo[] parameters = ((MethodBase)object_8).GetParameters();
				Type[] array = new Type[parameters.Length];
				for (int i = 0; i < array.Length; i++)
				{
					if (parameters[i].ParameterType.IsByRef)
					{
						array[i] = parameters[i].ParameterType.GetElementType();
					}
					else
					{
						array[i] = parameters[i].ParameterType;
					}
				}
				LocalBuilder[] array2 = new LocalBuilder[array.Length + 1];
				for (int j = 0; j < array.Length; j++)
				{
					array2[j] = iLGenerator.DeclareLocal(array[j]);
				}
				array2[^1] = iLGenerator.DeclareLocal(((MemberInfo)object_8).DeclaringType);
				for (int k = 0; k < array.Length; k++)
				{
					iLGenerator.Emit(OpCodes.Ldarg_1);
					smethod_5(iLGenerator, k);
					iLGenerator.Emit(OpCodes.Ldelem_Ref);
					if (!array[k].IsValueType)
					{
						if (array[k] != typeof(object))
						{
							iLGenerator.Emit(OpCodes.Castclass, array[k]);
						}
					}
					else
					{
						iLGenerator.Emit(OpCodes.Unbox_Any, array[k]);
					}
					iLGenerator.Emit(OpCodes.Stloc, array2[k]);
				}
				int num;
				if (!((MethodBase)object_8).IsStatic)
				{
					iLGenerator.Emit(OpCodes.Ldarg_0);
					iLGenerator.Emit(OpCodes.Ldind_Ref);
					if (!((MemberInfo)object_8).DeclaringType.IsValueType)
					{
						iLGenerator.Emit(OpCodes.Castclass, ((MemberInfo)object_8).DeclaringType);
						iLGenerator.Emit(OpCodes.Stloc, array2[^1]);
						iLGenerator.Emit(OpCodes.Ldloc_S, array2[^1]);
						num = 0;
						goto IL_026e;
					}
					iLGenerator.Emit(OpCodes.Unbox_Any, ((MemberInfo)object_8).DeclaringType);
					iLGenerator.Emit(OpCodes.Stloc, array2[^1]);
					iLGenerator.Emit(OpCodes.Ldloca_S, array2[^1]);
				}
				num = 0;
				goto IL_026e;
				IL_026e:
				for (int l = num; l < array.Length; l++)
				{
					if (parameters[l].ParameterType.IsByRef)
					{
						iLGenerator.Emit(OpCodes.Ldloca_S, array2[l]);
					}
					else
					{
						iLGenerator.Emit(OpCodes.Ldloc, array2[l]);
					}
				}
				if (bool_4)
				{
					if (!(methodInfo != null))
					{
						iLGenerator.Emit(OpCodes.Call, object_8 as ConstructorInfo);
					}
					else
					{
						iLGenerator.EmitCall(OpCodes.Call, methodInfo, null);
					}
				}
				else if (methodInfo != null)
				{
					iLGenerator.EmitCall(OpCodes.Callvirt, methodInfo, null);
				}
				else
				{
					iLGenerator.Emit(OpCodes.Callvirt, object_8 as ConstructorInfo);
				}
				if (!((MethodBase)object_8).IsStatic)
				{
					iLGenerator.Emit(OpCodes.Ldarg_0);
					iLGenerator.Emit(OpCodes.Ldloc, array2[^1]);
					if (((MemberInfo)object_8).DeclaringType.IsValueType)
					{
						iLGenerator.Emit(OpCodes.Box, ((MemberInfo)object_8).DeclaringType);
					}
					iLGenerator.Emit(OpCodes.Stind_Ref);
				}
				int num2;
				if (!(methodInfo == null) && !(methodInfo.ReturnType == typeof(void)))
				{
					if (methodInfo.ReturnType.IsByRef)
					{
						Type elementType = methodInfo.ReturnType.GetElementType();
						if (!elementType.IsValueType)
						{
							iLGenerator.Emit(OpCodes.Ldind_Ref, elementType);
						}
						else
						{
							iLGenerator.Emit(OpCodes.Ldobj, elementType);
						}
						if (!elementType.IsValueType)
						{
							num2 = 0;
						}
						else
						{
							iLGenerator.Emit(OpCodes.Box, elementType);
							num2 = 0;
						}
					}
					else if (!methodInfo.ReturnType.IsValueType)
					{
						num2 = 0;
					}
					else
					{
						iLGenerator.Emit(OpCodes.Box, methodInfo.ReturnType);
						num2 = 0;
					}
				}
				else
				{
					iLGenerator.Emit(OpCodes.Ldnull);
					num2 = 0;
				}
				for (int m = num2; m < array.Length; m++)
				{
					if (parameters[m].ParameterType.IsByRef)
					{
						iLGenerator.Emit(OpCodes.Ldarg_1);
						smethod_5(iLGenerator, m);
						iLGenerator.Emit(OpCodes.Ldloc, array2[m]);
						if (array2[m].LocalType.IsValueType)
						{
							iLGenerator.Emit(OpCodes.Box, array2[m].LocalType);
						}
						iLGenerator.Emit(OpCodes.Stelem_Ref);
					}
				}
				iLGenerator.Emit(OpCodes.Ret);
				Delegate21 @delegate = (Delegate21)dynamicMethod.CreateDelegate(typeof(Delegate21));
				if (!bool_4)
				{
					dictionary_8.Add((MethodBase)object_8, @delegate);
				}
				else
				{
					dictionary_7.Add((MethodBase)object_8, @delegate);
				}
				return @delegate;
			}
		}

		private static Class90 smethod_7(Class90 class90_3)
		{
			if (class90_3.vmethod_8().method_0())
			{
				object obj = class90_3.vmethod_4(null);
				if (obj != null && obj.GetType().IsEnum)
				{
					Type underlyingType = Enum.GetUnderlyingType(obj.GetType());
					object obj2 = Convert.ChangeType(obj, underlyingType);
					Class90 @class = smethod_8(Class90.smethod_1(underlyingType, obj2));
					if (@class != null)
					{
						return @class as Class91;
					}
				}
			}
			return class90_3;
		}

		private static Class91 smethod_8(Class90 class90_3)
		{
			Class91 @class = class90_3 as Class91;
			if (@class == null && class90_3.vmethod_0())
			{
				@class = class90_3.vmethod_8() as Class91;
			}
			return @class;
		}

		private static IntPtr smethod_9(object object_8)
		{
			if (object_8 == null)
			{
				return IntPtr.Zero;
			}
			if (((Class90)object_8).pgqjrkspy1())
			{
				return ((Class94)object_8).method_6();
			}
			if (((Class90)object_8).vmethod_0())
			{
				Class96 @class = (Class96)object_8;
				try
				{
					return @class.vmethod_11();
				}
				catch
				{
				}
			}
			object obj2 = ((Class90)object_8).vmethod_4(typeof(IntPtr));
			if (obj2 == null || !(obj2.GetType() == typeof(IntPtr)))
			{
				throw new Exception1();
			}
			return (IntPtr)obj2;
		}

		private static object smethod_10(object object_8)
		{
			object result = default(object);
			lock (object_7)
			{
				if (!Class79.bool_1)
				{
					if (dictionary_9 == null)
					{
						dictionary_9 = new Dictionary<Type, Delegate18>();
					}
					if (object_8 != null)
					{
						try
						{
							Type type = object_8.GetType();
							if (!dictionary_9.TryGetValue(type, out var value))
							{
								DynamicMethod dynamicMethod = new DynamicMethod(string.Empty, typeof(object), new Type[1] { typeof(object) }, restrictedSkipVisibility: true);
								ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
								iLGenerator.Emit(OpCodes.Ldarg_0);
								iLGenerator.Emit(OpCodes.Unbox_Any, type);
								iLGenerator.Emit(OpCodes.Box, type);
								iLGenerator.Emit(OpCodes.Ret);
								Delegate18 @delegate = (Delegate18)dynamicMethod.CreateDelegate(typeof(Delegate18));
								dictionary_9.Add(type, @delegate);
								result = @delegate(object_8);
								return result;
							}
							result = value(object_8);
							return result;
						}
						catch
						{
							result = null;
							return result;
						}
					}
					result = null;
					return result;
				}
				try
				{
					Type type2 = object_8.GetType();
					object obj2 = Activator.CreateInstance(type2);
					FieldInfo[] fields = type2.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
					int num = 0;
					while (true)
					{
						IL_00a4:
						int num2 = num;
						while (true)
						{
							if (num2 < fields.Length)
							{
								while (true)
								{
									IL_008f:
									FieldInfo fieldInfo = fields[num2];
									while (true)
									{
										IL_007c:
										fieldInfo.SetValue(obj2, fieldInfo.GetValue(object_8));
										while (true)
										{
											IL_0070:
											num2++;
											int num3 = 14;
											while (num3 != 14)
											{
												if (num3 != 994)
												{
													goto end_IL_0098;
												}
												switch (num3)
												{
												case 4:
													goto IL_0070;
												case 0:
													goto IL_007c;
												case 1:
													goto IL_008f;
												case 6:
													goto end_IL_0067;
												case 5:
													goto IL_00a3;
												case 3:
													goto IL_00a8;
												case 2:
													goto end_IL_0098;
												}
												continue;
												end_IL_0067:
												break;
											}
											break;
										}
										break;
									}
									break;
								}
								continue;
							}
							goto IL_00a8;
							IL_00a3:
							num = 0;
							goto IL_00a4;
							IL_00a8:
							result = obj2;
							return result;
							continue;
							end_IL_0098:
							break;
						}
						break;
					}
				}
				catch
				{
					result = null;
					return result;
				}
			}
			return result;
		}

		private static void smethod_11(IntPtr intptr_0, byte byte_0, int int_3)
		{
			// IL initblk instruction
			Unsafe.InitBlock(intptr_0, byte_0, int_3);
		}

		private static void smethod_12(IntPtr intptr_0, IntPtr intptr_1, uint uint_0)
		{
			// IL cpblk instruction
			Unsafe.CopyBlock(intptr_0, intptr_1, uint_0);
		}

		static Class88()
		{
			Class72.smethod_20();
			object_1 = new object();
			dictionary_1 = new Dictionary<object, Class90>();
			object_2 = new object();
			string_0 = Encoding.Unicode.GetString(new byte[24]
			{
				103, 0, 101, 0, 116, 0, 95, 0, 72, 0,
				97, 0, 115, 0, 86, 0, 97, 0, 108, 0,
				117, 0, 101, 0
			});
			string_1 = Encoding.Unicode.GetString(new byte[18]
			{
				103, 0, 101, 0, 116, 0, 95, 0, 86, 0,
				97, 0, 108, 0, 117, 0, 101, 0
			});
			string_2 = Encoding.Unicode.GetString(new byte[34]
			{
				71, 0, 101, 0, 116, 0, 86, 0, 97, 0,
				108, 0, 117, 0, 101, 0, 79, 0, 114, 0,
				68, 0, 101, 0, 102, 0, 97, 0, 117, 0,
				108, 0, 116, 0
			});
			string_3 = Encoding.Unicode.GetString(new byte[22]
			{
				71, 0, 101, 0, 116, 0, 72, 0, 97, 0,
				115, 0, 104, 0, 67, 0, 111, 0, 100, 0,
				101, 0
			});
			string_4 = Encoding.Unicode.GetString(new byte[12]
			{
				69, 0, 113, 0, 117, 0, 97, 0, 108, 0,
				115, 0
			});
			string_5 = Encoding.Unicode.GetString(new byte[16]
			{
				84, 0, 111, 0, 83, 0, 116, 0, 114, 0,
				105, 0, 110, 0, 103, 0
			});
			dictionary_2 = new Dictionary<MethodBase, Delegate16>();
			dictionary_3 = new Dictionary<MethodBase, Delegate16>();
			object_3 = new object();
			dictionary_4 = new Dictionary<Class87, Delegate16>();
			dictionary_5 = new Dictionary<Class87, Delegate16>();
			object_4 = new object();
			dictionary_6 = new Dictionary<Class87, Delegate16>();
			object_5 = new object();
			object_6 = new object();
			dictionary_7 = new Dictionary<MethodBase, Delegate21>();
			dictionary_8 = new Dictionary<MethodBase, Delegate21>();
			object_7 = new object();
		}
	}

	internal enum Enum25 : byte
	{

	}

	internal enum Enum26 : byte
	{

	}

	internal abstract class Class90
	{
		internal Enum26 enum26_0;

		public Class90()
		{
		}

		internal bool method_0()
		{
			return enum26_0 == (Enum26)0;
		}

		internal bool method_1()
		{
			return enum26_0 == (Enum26)1;
		}

		internal bool method_2()
		{
			return enum26_0 == (Enum26)8;
		}

		internal bool pgqjrkspy1()
		{
			if (enum26_0 != (Enum26)3)
			{
				return enum26_0 == (Enum26)4;
			}
			return true;
		}

		internal bool method_3()
		{
			return enum26_0 == (Enum26)2;
		}

		internal bool MwVjiGosgX()
		{
			return enum26_0 == (Enum26)5;
		}

		internal bool method_4()
		{
			return enum26_0 == (Enum26)6;
		}

		internal virtual bool vmethod_0()
		{
			return false;
		}

		internal virtual bool vmethod_1()
		{
			return false;
		}

		internal abstract void vmethod_2(Class90 class90_0);

		internal virtual bool vmethod_3()
		{
			return false;
		}

		internal Class90(Enum26 enum26_1)
		{
			enum26_0 = enum26_1;
		}

		internal abstract object vmethod_4(Type type_0);

		internal abstract bool vmethod_5(Class90 class90_0);

		internal abstract bool vmethod_6(Class90 class90_0);

		internal abstract bool vmethod_7();

		internal abstract Class90 vmethod_8();

		internal virtual bool vmethod_9()
		{
			return false;
		}

		internal abstract void vmethod_10(Class90 class90_0);

		internal static Enum24 smethod_0(Type type_0)
		{
			Type type = type_0;
			if (type != null)
			{
				if (type.IsByRef)
				{
					type = type.GetElementType();
				}
				if (type != null && Nullable.GetUnderlyingType(type) != null)
				{
					type = Nullable.GetUnderlyingType(type);
				}
				if (type == typeof(string))
				{
					return (Enum24)14;
				}
				if (!(type == typeof(byte)))
				{
					if (type == typeof(sbyte))
					{
						return (Enum24)1;
					}
					if (type == typeof(short))
					{
						return (Enum24)3;
					}
					if (!(type == typeof(ushort)))
					{
						if (!(type == typeof(int)))
						{
							if (!(type == typeof(uint)))
							{
								if (type == typeof(long))
								{
									return (Enum24)7;
								}
								if (type == typeof(ulong))
								{
									return (Enum24)8;
								}
								if (!(type == typeof(float)))
								{
									if (type == typeof(double))
									{
										return (Enum24)10;
									}
									if (type == typeof(bool))
									{
										return (Enum24)11;
									}
									if (!(type == typeof(IntPtr)))
									{
										if (type == typeof(UIntPtr))
										{
											return (Enum24)13;
										}
										if (!(type == typeof(char)))
										{
											if (type == typeof(object))
											{
												return (Enum24)0;
											}
											if (type.IsEnum)
											{
												return (Enum24)16;
											}
											return (Enum24)17;
										}
										return (Enum24)15;
									}
									return (Enum24)12;
								}
								return (Enum24)9;
							}
							return (Enum24)6;
						}
						return (Enum24)5;
					}
					return (Enum24)4;
				}
				return (Enum24)2;
			}
			return (Enum24)18;
		}

		internal static Class90 smethod_1(Type type_0, object object_0)
		{
			Type underlyingType = Nullable.GetUnderlyingType(type_0);
			if (!(underlyingType != null))
			{
				Enum24 @enum = smethod_0(type_0);
				Enum24 enum2 = (Enum24)18;
				if (object_0 != null)
				{
					enum2 = smethod_0(object_0.GetType());
				}
				Class90 @class = null;
				switch (@enum)
				{
				case (Enum24)0:
					@class = ((enum2 != (Enum24)15) ? smethod_2(object_0) : new Class102(object_0));
					goto default;
				case (Enum24)1:
					@class = enum2 switch
					{
						(Enum24)2 => new Class92((sbyte)(byte)object_0, (Enum23)1), 
						(Enum24)1 => new Class92((sbyte)object_0, (Enum23)1), 
						(Enum24)15 => new Class92((sbyte)(char)object_0, (Enum23)1), 
						(Enum24)11 => ((bool)object_0) ? new Class92(1, (Enum23)1) : new Class92(0, (Enum23)1), 
						_ => throw new InvalidCastException(), 
					};
					goto default;
				case (Enum24)2:
					@class = enum2 switch
					{
						(Enum24)2 => new Class92((byte)object_0, (Enum23)2), 
						(Enum24)1 => new Class92((byte)(sbyte)object_0, (Enum23)2), 
						(Enum24)15 => new Class92((byte)(char)object_0, (Enum23)2), 
						(Enum24)11 => ((bool)object_0) ? new Class92(1, (Enum23)2) : new Class92(0, (Enum23)2), 
						_ => throw new InvalidCastException(), 
					};
					goto default;
				case (Enum24)3:
					@class = enum2 switch
					{
						(Enum24)15 => new Class92((short)(char)object_0, (Enum23)3), 
						(Enum24)11 => ((bool)object_0) ? new Class92(1, (Enum23)3) : new Class92(0, (Enum23)3), 
						(Enum24)3 => new Class92((short)object_0, (Enum23)3), 
						_ => throw new InvalidCastException(), 
					};
					goto default;
				case (Enum24)4:
					@class = enum2 switch
					{
						(Enum24)15 => new Class92((char)object_0, (Enum23)4), 
						(Enum24)11 => (!(bool)object_0) ? new Class92(0, (Enum23)4) : new Class92(1, (Enum23)4), 
						(Enum24)4 => new Class92((ushort)object_0, (Enum23)4), 
						_ => throw new InvalidCastException(), 
					};
					goto default;
				case (Enum24)5:
					@class = enum2 switch
					{
						(Enum24)15 => new Class92((char)object_0, (Enum23)5), 
						(Enum24)11 => (!(bool)object_0) ? new Class92(0, (Enum23)5) : new Class92(1, (Enum23)5), 
						(Enum24)5 => new Class92((int)object_0, (Enum23)5), 
						_ => throw new InvalidCastException(), 
					};
					goto default;
				case (Enum24)6:
					@class = enum2 switch
					{
						(Enum24)15 => new Class92((uint)(char)object_0, (Enum23)6), 
						(Enum24)11 => ((bool)object_0) ? new Class92(1u, (Enum23)6) : new Class92(0u, (Enum23)6), 
						(Enum24)6 => new Class92((uint)object_0, (Enum23)6), 
						_ => throw new InvalidCastException(), 
					};
					goto default;
				case (Enum24)7:
					@class = enum2 switch
					{
						(Enum24)15 => new Class93((char)object_0, (Enum23)7), 
						(Enum24)11 => ((bool)object_0) ? new Class93(1L, (Enum23)7) : new Class93(0L, (Enum23)7), 
						(Enum24)7 => new Class93((long)object_0, (Enum23)7), 
						_ => throw new InvalidCastException(), 
					};
					goto default;
				case (Enum24)8:
					@class = enum2 switch
					{
						(Enum24)15 => new Class93((ulong)(char)object_0, (Enum23)8), 
						(Enum24)11 => ((bool)object_0) ? new Class93(1uL, (Enum23)8) : new Class93(0uL, (Enum23)8), 
						(Enum24)8 => new Class93((ulong)object_0, (Enum23)8), 
						_ => throw new InvalidCastException(), 
					};
					goto default;
				case (Enum24)9:
					if (enum2 == (Enum24)9)
					{
						@class = new Class95((float)object_0);
						goto default;
					}
					throw new InvalidCastException();
				case (Enum24)10:
					if (enum2 == (Enum24)10)
					{
						@class = new Class95((double)object_0);
						goto default;
					}
					throw new InvalidCastException();
				case (Enum24)11:
					switch (enum2)
					{
					case (Enum24)1:
						@class = new Class92((sbyte)object_0 != 0);
						break;
					case (Enum24)2:
						@class = new Class92((byte)object_0 != 0);
						break;
					case (Enum24)3:
						@class = new Class92((short)object_0 != 0);
						break;
					case (Enum24)4:
						@class = new Class92((ushort)object_0 != 0);
						break;
					case (Enum24)5:
						@class = new Class92((int)object_0 != 0);
						break;
					case (Enum24)6:
						@class = new Class92((uint)object_0 != 0);
						break;
					case (Enum24)7:
						@class = new Class92((ulong)(long)object_0 > 0uL);
						break;
					case (Enum24)8:
						@class = new Class92((ulong)object_0 > 0L);
						break;
					case (Enum24)11:
						@class = new Class92((bool)object_0);
						break;
					case (Enum24)9:
					case (Enum24)10:
					case (Enum24)12:
					case (Enum24)13:
					case (Enum24)14:
					case (Enum24)15:
					case (Enum24)16:
						throw new InvalidCastException();
					default:
						@class = new Class92(object_0 != null);
						break;
					case (Enum24)18:
						@class = new Class92(bool_0: false);
						break;
					}
					goto default;
				case (Enum24)12:
					if (enum2 == (Enum24)12)
					{
						@class = new Class94((IntPtr)object_0);
						goto default;
					}
					throw new InvalidCastException();
				case (Enum24)13:
					if (enum2 == (Enum24)13)
					{
						@class = new Class94((UIntPtr)object_0);
						goto default;
					}
					throw new InvalidCastException();
				case (Enum24)14:
					@class = new Class103(object_0 as string);
					goto default;
				case (Enum24)15:
					@class = enum2 switch
					{
						(Enum24)15 => new Class92((char)object_0, (Enum23)15), 
						(Enum24)1 => new Class92((sbyte)object_0, (Enum23)15), 
						(Enum24)2 => new Class92((byte)object_0, (Enum23)15), 
						(Enum24)3 => new Class92((short)object_0, (Enum23)15), 
						(Enum24)4 => new Class92((ushort)object_0, (Enum23)15), 
						(Enum24)5 => new Class92((int)object_0, (Enum23)15), 
						(Enum24)6 => new Class92((int)(uint)object_0, (Enum23)15), 
						_ => throw new InvalidCastException(), 
					};
					goto default;
				case (Enum24)16:
				case (Enum24)17:
					@class = smethod_2(object_0);
					goto default;
				default:
					if (type_0.IsByRef)
					{
						@class = new Class101(@class, type_0.GetElementType());
					}
					return @class;
				case (Enum24)18:
					throw new InvalidCastException();
				}
			}
			return new Class104(object_0, underlyingType);
		}

		private static Class90 smethod_2(object object_0)
		{
			if (object_0 != null && object_0.GetType().IsEnum)
			{
				Type underlyingType = Enum.GetUnderlyingType(object_0.GetType());
				object object_1 = Convert.ChangeType(object_0, underlyingType);
				Class90 @class = smethod_3(smethod_1(underlyingType, object_1));
				if (@class != null)
				{
					return @class as Class91;
				}
			}
			return new Class102(object_0);
		}

		private static Class91 smethod_3(Class90 class90_0)
		{
			Class91 @class = class90_0 as Class91;
			if (@class == null && class90_0.vmethod_0())
			{
				@class = class90_0.vmethod_8() as Class91;
			}
			return @class;
		}

		static Class90()
		{
			Class72.smethod_20();
		}
	}

	private class Class102 : Class90
	{
		public Class90 class90_0;

		public Type type_0;

		public Class102()
			: this(null)
		{
		}

		internal override void vmethod_10(Class90 class90_1)
		{
			if (class90_1 is Class102)
			{
				class90_0 = ((Class102)class90_1).class90_0;
				type_0 = ((Class102)class90_1).type_0;
			}
			else
			{
				class90_0 = class90_1.vmethod_8();
			}
		}

		internal override void vmethod_2(Class90 class90_1)
		{
			vmethod_10(class90_1);
		}

		public Class102(object object_0)
			: base((Enum26)0)
		{
			class90_0 = (Class90)object_0;
			type_0 = null;
		}

		public Class102(object object_0, Type type_1)
			: base((Enum26)0)
		{
			class90_0 = (Class90)object_0;
			type_0 = type_1;
		}

		public override string ToString()
		{
			if (class90_0 == null)
			{
				return ((Enum27)5/*cast due to .constrained prefix*/).ToString();
			}
			return class90_0.ToString();
		}

		internal override object vmethod_4(Type type_1)
		{
			int num = 26;
			object obj2 = default(object);
			while (class90_0 != null)
			{
				while (true)
				{
					IL_014c:
					if (type_1 != null)
					{
						goto IL_0126;
					}
					goto IL_0139;
					IL_0139:
					while (true)
					{
						IL_0139_2:
						if (!(class90_0 is Class90))
						{
							while (true)
							{
								IL_011d:
								object obj = class90_0;
								while (true)
								{
									IL_0114:
									if (obj != null)
									{
										while (type_1 != null)
										{
											num = 38;
											while (true)
											{
												IL_00ee:
												if (!(obj.GetType() != type_1))
												{
													num = 51;
													while (num != 51)
													{
														if (num != 1032)
														{
															goto end_IL_0114;
														}
														switch (num)
														{
														case 38:
															goto IL_00ee;
														case 36:
															goto IL_0102;
														case 6:
															goto IL_0114;
														case 23:
															goto IL_011d;
														case 18:
															goto end_IL_0139;
														case 37:
															goto IL_012e;
														case 22:
															goto IL_0139_2;
														case 25:
															goto IL_014c;
														case 26:
															goto end_IL_014c;
														case 4:
															goto IL_0166;
														case 29:
															goto IL_0178;
														case 42:
															goto IL_0180;
														case 1:
														case 32:
															goto IL_0193;
														case 20:
															goto IL_01a5;
														case 0:
															goto IL_01ad;
														case 8:
														case 17:
															goto IL_01c0;
														case 30:
															goto IL_01d2;
														case 14:
															goto IL_01dd;
														case 9:
														case 12:
														case 33:
															goto end_IL_00e0;
														case 40:
															goto IL_0201;
														case 16:
															goto IL_0213;
														case 28:
															goto IL_0219;
														case 7:
															goto IL_0227;
														case 2:
															goto IL_023d;
														case 41:
															goto IL_024f;
														case 10:
															goto IL_0257;
														case 3:
														case 5:
															goto IL_026d;
														case 13:
															goto IL_027f;
														case 21:
															goto IL_0287;
														case 35:
														case 44:
															goto end_IL_0114;
														case 39:
															goto IL_02ac;
														case 31:
															goto IL_02b4;
														case 11:
														case 15:
														case 19:
														case 24:
														case 34:
															goto IL_02c5;
														case 43:
															goto IL_02c7;
														case 27:
															goto end_IL_0158;
														}
														continue;
														end_IL_00e0:
														break;
													}
													break;
												}
												goto IL_0166;
												IL_01d2:
												if (!(obj is MethodBase))
												{
													break;
												}
												num = 14;
												goto IL_01dd;
												IL_01dd:
												obj = ((MethodBase)obj).MethodHandle;
												break;
												IL_0166:
												if (type_1 == typeof(RuntimeFieldHandle))
												{
													goto IL_0178;
												}
												goto IL_0193;
												IL_0178:
												if (obj is FieldInfo)
												{
													goto IL_0180;
												}
												goto IL_0193;
												IL_0180:
												obj = ((FieldInfo)obj).FieldHandle;
												break;
												IL_0193:
												if (type_1 == typeof(RuntimeTypeHandle))
												{
													goto IL_01a5;
												}
												goto IL_01c0;
												IL_01a5:
												if (obj is Type)
												{
													goto IL_01ad;
												}
												goto IL_01c0;
												IL_01ad:
												obj = ((Type)obj).TypeHandle;
												break;
												IL_01c0:
												if (!(type_1 == typeof(RuntimeMethodHandle)))
												{
													break;
												}
												goto IL_01d2;
											}
											break;
											IL_0102:;
										}
									}
									return obj;
									continue;
									end_IL_0114:
									break;
								}
								break;
							}
							goto IL_029a;
						}
						if (!(type_0 != null))
						{
							goto IL_0201;
						}
						goto IL_02c7;
						IL_02ac:
						if (obj2 is MethodBase)
						{
							goto IL_02b4;
						}
						goto IL_02c5;
						IL_02b4:
						obj2 = ((MethodBase)obj2).MethodHandle;
						goto IL_02c5;
						IL_0201:
						obj2 = class90_0.vmethod_4(type_1);
						goto IL_0213;
						IL_0213:
						if (obj2 != null)
						{
							goto IL_0219;
						}
						goto IL_02c5;
						IL_0219:
						if (type_1 != null)
						{
							num = 7;
							goto IL_0227;
						}
						goto IL_02c5;
						IL_02c5:
						return obj2;
						IL_0227:
						if (obj2.GetType() != type_1)
						{
							goto IL_023d;
						}
						num = 19;
						goto IL_02c5;
						IL_02c7:
						return class90_0.vmethod_4(type_0);
						IL_023d:
						if (type_1 == typeof(RuntimeFieldHandle))
						{
							goto IL_024f;
						}
						goto IL_026d;
						IL_024f:
						if (obj2 is FieldInfo)
						{
							goto IL_0257;
						}
						goto IL_026d;
						IL_0257:
						obj2 = ((FieldInfo)obj2).FieldHandle;
						num = 11;
						goto IL_02c5;
						IL_026d:
						if (type_1 == typeof(RuntimeTypeHandle))
						{
							goto IL_027f;
						}
						goto IL_029a;
						IL_027f:
						if (obj2 is Type)
						{
							goto IL_0287;
						}
						goto IL_029a;
						IL_0287:
						obj2 = ((Type)obj2).TypeHandle;
						goto IL_02c5;
						IL_029a:
						if (type_1 == typeof(RuntimeMethodHandle))
						{
							goto IL_02ac;
						}
						goto IL_02c5;
						continue;
						end_IL_0139:
						break;
					}
					goto IL_0126;
					IL_0126:
					if (type_1.IsByRef)
					{
						goto IL_012e;
					}
					goto IL_0139;
					IL_012e:
					type_1 = type_1.GetElementType();
					num = 22;
					goto IL_0139;
					continue;
					end_IL_014c:
					break;
				}
				continue;
				end_IL_0158:
				break;
			}
			return null;
		}

		internal override bool vmethod_5(Class90 class90_1)
		{
			if (class90_1.vmethod_0())
			{
				return ((Class96)class90_1).vmethod_5(this);
			}
			object obj = vmethod_4(null);
			object obj2 = class90_1.vmethod_4(null);
			return obj == obj2;
		}

		internal override bool vmethod_6(Class90 class90_1)
		{
			if (!class90_1.vmethod_0())
			{
				object obj = vmethod_4(null);
				object obj2 = class90_1.vmethod_4(null);
				return obj != obj2;
			}
			return ((Class96)class90_1).vmethod_6(this);
		}

		internal override Class90 vmethod_8()
		{
			if (!(class90_0 is Class90 @class))
			{
				return this;
			}
			return @class.vmethod_8();
		}

		internal override bool vmethod_7()
		{
			if (class90_0 != null)
			{
				if (class90_0 is bool)
				{
					return (bool)(object)class90_0;
				}
				if (class90_0 is Class90 @class)
				{
					object obj = @class.vmethod_4(null);
					if (obj != null)
					{
						if (!(obj is bool))
						{
							return true;
						}
						return (bool)obj;
					}
					return false;
				}
				return true;
			}
			return false;
		}

		static Class102()
		{
			Class72.smethod_20();
		}
	}

	private class Class103 : Class90
	{
		public string string_0;

		public Class103(string string_1)
			: base((Enum26)6)
		{
			string_0 = string_1;
		}

		internal override void vmethod_10(Class90 class90_0)
		{
			string_0 = ((Class103)class90_0).string_0;
		}

		internal override void vmethod_2(Class90 class90_0)
		{
			vmethod_10(class90_0);
		}

		public override string ToString()
		{
			if (string_0 != null)
			{
				return "*" + string_0 + "*";
			}
			return ((Enum27)5/*cast due to .constrained prefix*/).ToString();
		}

		internal override bool vmethod_7()
		{
			return string_0 != null;
		}

		internal override object vmethod_4(Type type_0)
		{
			return string_0;
		}

		internal override bool vmethod_5(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				return ((Class96)class90_0).vmethod_5(this);
			}
			string text = string_0;
			object obj = class90_0.vmethod_4(null);
			return text == obj;
		}

		internal override bool vmethod_6(Class90 class90_0)
		{
			if (class90_0.vmethod_0())
			{
				return ((Class96)class90_0).vmethod_6(this);
			}
			string text = string_0;
			object obj = class90_0.vmethod_4(null);
			return text != obj;
		}

		internal override Class90 vmethod_8()
		{
			return this;
		}

		static Class103()
		{
			Class72.smethod_20();
		}
	}

	private class Class104 : Class90
	{
		public Class90 class90_0;

		public Type type_0;

		public Class104(object object_0, Type type_1)
			: base((Enum26)8)
		{
			class90_0 = (Class90)object_0;
			type_0 = type_1;
		}

		internal override void vmethod_10(Class90 class90_1)
		{
			int num = 3;
			while (class90_1 is Class104)
			{
				while (true)
				{
					class90_0 = ((Class104)class90_1).class90_0;
					while (true)
					{
						type_0 = ((Class104)class90_1).type_0;
						num = 10;
						while (true)
						{
							if (num != 10)
							{
								if (num != 991)
								{
									break;
								}
								switch (num)
								{
								case 0:
									goto end_IL_0025;
								case 2:
									goto end_IL_002d;
								case 3:
									goto end_IL_0043;
								case 1:
									return;
								}
								continue;
							}
							return;
							continue;
							end_IL_0025:
							break;
						}
						continue;
						end_IL_002d:
						break;
					}
					continue;
					end_IL_0043:
					break;
				}
			}
			class90_0 = class90_1.vmethod_8();
		}

		internal override void vmethod_2(Class90 class90_1)
		{
			vmethod_10(class90_1);
		}

		public override string ToString()
		{
			if (class90_0 == null)
			{
				return ((Enum27)5/*cast due to .constrained prefix*/).ToString();
			}
			return "*" + class90_0?.ToString() + "*";
		}

		internal override bool vmethod_7()
		{
			if (class90_0 != null)
			{
				if (class90_0 is bool)
				{
					return (bool)(object)class90_0;
				}
				if (!(class90_0 is Class90 @class))
				{
					return true;
				}
				object obj = @class.vmethod_4(null);
				if (obj == null)
				{
					return false;
				}
				if (obj is bool)
				{
					return (bool)obj;
				}
				return true;
			}
			return false;
		}

		internal override object vmethod_4(Type type_1)
		{
			if (class90_0 != null)
			{
				if (type_1 != null && type_1.IsByRef)
				{
					type_1 = type_1.GetElementType();
				}
				if (class90_0 is Class90)
				{
					if (type_0 != null)
					{
						return class90_0.vmethod_4(type_0);
					}
					object obj = class90_0.vmethod_4(type_1);
					if (obj != null && type_1 != null && obj.GetType() != type_1)
					{
						if (type_1 == typeof(RuntimeFieldHandle) && obj is FieldInfo)
						{
							obj = ((FieldInfo)obj).FieldHandle;
						}
						else if (type_1 == typeof(RuntimeTypeHandle) && obj is Type)
						{
							obj = ((Type)obj).TypeHandle;
						}
						else if (type_1 == typeof(RuntimeMethodHandle) && obj is MethodBase)
						{
							obj = ((MethodBase)obj).MethodHandle;
						}
					}
					return obj;
				}
				object obj2 = class90_0;
				if (obj2 != null && type_1 != null && obj2.GetType() != type_1)
				{
					if (type_1 == typeof(RuntimeFieldHandle) && obj2 is FieldInfo)
					{
						obj2 = ((FieldInfo)obj2).FieldHandle;
					}
					else if (type_1 == typeof(RuntimeTypeHandle) && obj2 is Type)
					{
						obj2 = ((Type)obj2).TypeHandle;
					}
					else if (type_1 == typeof(RuntimeMethodHandle) && obj2 is MethodBase)
					{
						obj2 = ((MethodBase)obj2).MethodHandle;
					}
				}
				return obj2;
			}
			return null;
		}

		internal override bool vmethod_5(Class90 class90_1)
		{
			if (!class90_1.vmethod_0())
			{
				object obj = vmethod_4(null);
				object obj2 = class90_1.vmethod_4(null);
				return obj == obj2;
			}
			return ((Class96)class90_1).vmethod_5(this);
		}

		internal override bool vmethod_6(Class90 class90_1)
		{
			if (!class90_1.vmethod_0())
			{
				object obj = vmethod_4(null);
				object obj2 = class90_1.vmethod_4(null);
				return obj != obj2;
			}
			return ((Class96)class90_1).vmethod_6(this);
		}

		internal override Class90 vmethod_8()
		{
			if (!(class90_0 is Class90 @class))
			{
				return this;
			}
			return @class.vmethod_8();
		}

		static Class104()
		{
			Class72.smethod_20();
		}
	}

	private abstract class Class105
	{
		public abstract bool vmethod_0();

		public abstract object vmethod_1();

		public abstract object vmethod_2();

		public abstract object vmethod_3(object object_0);

		public abstract int vmethod_4();

		public abstract void vmethod_5();

		public abstract void vmethod_6(object object_0);

		internal static Class105 smethod_0(Type type_0)
		{
			Class105 obj = (Class105)Activator.CreateInstance(typeof(Class106<>).MakeGenericType(type_0));
			obj.vmethod_5();
			return obj;
		}

		static Class105()
		{
			Class72.smethod_20();
		}
	}

	private class Class106<T> : Class105 where T : struct
	{
		public T? nullable_0;

		internal static object object_0;

		public override bool vmethod_0()
		{
			return nullable_0.HasValue;
		}

		public override object vmethod_1()
		{
			return nullable_0.Value;
		}

		public override object vmethod_2()
		{
			return nullable_0.GetValueOrDefault();
		}

		public override object vmethod_3(object object_1)
		{
			return nullable_0.GetValueOrDefault((T)object_1);
		}

		public override int vmethod_4()
		{
			return nullable_0.GetHashCode();
		}

		public override void vmethod_5()
		{
			int num = 1;
			while (true)
			{
				nullable_0 = null;
				int num2 = 6;
				if (smethod_2() == null)
				{
					break;
				}
				while (true)
				{
					switch (num2)
					{
					default:
						if (num == 989)
						{
							goto IL_000f;
						}
						break;
					case 1:
						break;
					case 0:
						return;
					}
					break;
					IL_000f:
					num2 = num;
				}
			}
		}

		public override void vmethod_6(object object_1)
		{
			int num = 3;
			while (true)
			{
				if (object_1 != null)
				{
					goto IL_0004;
				}
				goto IL_0049;
				IL_0049:
				vmethod_5();
				int num2 = 0;
				if (smethod_2() != null)
				{
					goto IL_0021;
				}
				goto IL_0031;
				IL_0031:
				switch (num2)
				{
				case 2:
					break;
				default:
					goto IL_0021;
				case 1:
					goto IL_0049;
				case 3:
					continue;
				case 0:
					return;
				}
				goto IL_0004;
				IL_0021:
				switch (num)
				{
				case 991:
					break;
				default:
					continue;
				case 10:
					return;
				}
				goto IL_001e;
				IL_0004:
				nullable_0 = (T)object_1;
				if (smethod_2() == null)
				{
					break;
				}
				num = 6;
				goto IL_001e;
				IL_001e:
				num2 = num;
				goto IL_0031;
			}
			num = 10;
		}

		static Class106()
		{
			Class72.smethod_20();
		}

		internal static bool smethod_1()
		{
			return object_0 == null;
		}

		internal static object smethod_2()
		{
			return object_0;
		}
	}

	internal class Class107
	{
		private List<Class90> list_0 = new List<Class90>();

		[SpecialName]
		public int method_0()
		{
			return list_0.Count;
		}

		public void method_1()
		{
			list_0.Clear();
		}

		public void method_2(Class90 class90_0)
		{
			list_0.Add(class90_0);
		}

		public Class90 method_3()
		{
			return list_0[list_0.Count - 1];
		}

		public Class90 method_4()
		{
			Class90 result = method_3();
			if (list_0.Count != 0)
			{
				list_0.RemoveAt(list_0.Count - 1);
			}
			return result;
		}

		static Class107()
		{
			Class72.smethod_20();
		}
	}

	private struct Struct76
	{
		private StringBuilder stringBuilder_0;

		public Struct76(int int_0, int int_1)
		{
			stringBuilder_0 = new StringBuilder();
		}

		public Struct76(int int_0, int int_1, IFormatProvider iformatProvider_0)
		{
			stringBuilder_0 = new StringBuilder();
		}

		public void method_0(string string_0)
		{
			if (string_0 != null)
			{
				stringBuilder_0.Append(string_0);
			}
		}

		public void method_1<T>(T gparam_0)
		{
			if (gparam_0 != null)
			{
				stringBuilder_0.Append(gparam_0);
			}
		}

		public void method_2<T>(T gparam_0, string string_0)
		{
			if (string_0 != null)
			{
				stringBuilder_0.AppendFormat(string_0, gparam_0);
			}
			else
			{
				stringBuilder_0.Append(gparam_0);
			}
		}

		public void method_3<T>(T gparam_0, int int_0)
		{
			if (gparam_0 != null)
			{
				stringBuilder_0.Append(gparam_0);
			}
		}

		public void method_4<T>(T gparam_0, int int_0, string string_0)
		{
			if (string_0 != null)
			{
				stringBuilder_0.AppendFormat(string_0, gparam_0);
			}
			else
			{
				stringBuilder_0.Append(gparam_0);
			}
		}

		public void method_5(string string_0)
		{
			if (string_0 != null)
			{
				stringBuilder_0.Append(string_0);
			}
		}

		public void method_6(string string_0, int int_0 = 0, string string_1 = null)
		{
			if (string_1 != null)
			{
				stringBuilder_0.AppendFormat(string_1, string_0);
			}
			else
			{
				stringBuilder_0.Append(string_0);
			}
		}

		public void method_7(object object_0, int int_0 = 0, string string_0 = null)
		{
			if (string_0 != null)
			{
				stringBuilder_0.AppendFormat(string_0, object_0);
			}
			else
			{
				stringBuilder_0.Append(object_0);
			}
		}

		public string method_8()
		{
			string result = stringBuilder_0.ToString();
			stringBuilder_0.Clear();
			return result;
		}

		static Struct76()
		{
			Class72.smethod_20();
		}
	}

	internal enum Enum27
	{

	}

	[Serializable]
	[CompilerGenerated]
	private sealed class Class108<T>
	{
		public static readonly Class108<T> <>9;

		public static Comparison<Class83> <>9__71_0;

		internal static object object_0;

		static Class108()
		{
			Class72.smethod_20();
			<>9 = new Class108<T>();
		}

		internal int method_0(Class83 x, Class83 y)
		{
			return x.class84_0.int_0.CompareTo(y.class84_0.int_0);
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

	internal static Class85[] class85_0;

	internal static int[] int_0;

	internal static List<string> list_0;

	private static BinaryReader binaryReader_0;

	private static byte[] byte_0;

	private static bool bool_0;

	private static object object_0;

	private static Module module_0;

	private static RuntimeTypeHandle[] runtimeTypeHandle_0;

	private static object object_1;

	private static RuntimeMethodHandle[] runtimeMethodHandle_0;

	private static int[] int_1;

	private static int[] int_2;

	private static RuntimeFieldHandle[] runtimeFieldHandle_0;

	internal static bool bool_1;

	internal static object[] smethod_0()
	{
		return new object[1];
	}

	private static Module smethod_1()
	{
		if (module_0 == null)
		{
			module_0 = typeof(Class79).Module;
		}
		return module_0;
	}

	private static Type smethod_2(int int_3)
	{
		if (bool_1)
		{
			return smethod_6(int_3);
		}
		return smethod_1().ResolveType(int_3);
	}

	private static MethodBase smethod_3(int int_3)
	{
		if (bool_1)
		{
			return smethod_9(int_3);
		}
		return smethod_1().ResolveMethod(int_3);
	}

	private static FieldInfo smethod_4(int int_3)
	{
		if (bool_1)
		{
			return smethod_13(int_3);
		}
		return smethod_1().ResolveField(int_3);
	}

	private static MemberInfo smethod_5(int int_3)
	{
		if (!bool_1)
		{
			return smethod_1().ResolveMember(int_3);
		}
		return smethod_11(int_3);
	}

	private static Type smethod_6(int int_3)
	{
		Type typeFromHandle = default(Type);
		lock (object_1)
		{
			while (true)
			{
				IL_0046:
				if (runtimeTypeHandle_0.Length == 0)
				{
					while (true)
					{
						IL_003b:
						smethod_7();
						int num = 10;
						while (num != 10)
						{
							if (num != 990)
							{
								goto IL_0046;
							}
							switch (num)
							{
							case 0:
								goto IL_003b;
							case 2:
								goto IL_0046;
							case 1:
								goto end_IL_0046;
							}
						}
						break;
					}
				}
				typeFromHandle = Type.GetTypeFromHandle(runtimeTypeHandle_0[int_3 & 0xFFFFFFF]);
				return typeFromHandle;
				continue;
				end_IL_0046:
				break;
			}
		}
		return typeFromHandle;
	}

	private static void smethod_7()
	{
		int num = 2;
		int num2 = 2;
		while (true)
		{
			runtimeTypeHandle_0 = new RuntimeTypeHandle[num2];
			while (true)
			{
				runtimeTypeHandle_0[0] = default(RuntimeTypeHandle);
				while (true)
				{
					IL_002a:
					runtimeTypeHandle_0[1] = default(RuntimeTypeHandle);
					num = 9;
					while (true)
					{
						if (num != 9)
						{
							if (num != 990)
							{
								break;
							}
							switch (num)
							{
							case 0:
								goto IL_002a;
							case 1:
								goto end_IL_002a;
							case 2:
								goto end_IL_0040;
							}
							continue;
						}
						return;
					}
					goto end_IL_0040;
					continue;
					end_IL_002a:
					break;
				}
				continue;
				end_IL_0040:
				break;
			}
			num2 = 2;
		}
	}

	private static void smethod_8()
	{
		int_1 = new int[2];
		int_1[0] = 1;
		int_1[1] = 2;
	}

	private static MethodBase smethod_9(int int_3)
	{
		lock (object_1)
		{
			if (runtimeMethodHandle_0.Length == 0)
			{
				smethod_10();
				smethod_8();
			}
			int num = int_3 & 0xFFFFFFF;
			if (int_1[num] <= 0)
			{
				return MethodBase.GetMethodFromHandle(runtimeMethodHandle_0[num]);
			}
			if (runtimeTypeHandle_0.Length == 0)
			{
				smethod_7();
			}
			return MethodBase.GetMethodFromHandle(runtimeMethodHandle_0[num], runtimeTypeHandle_0[int_1[num] - 1]);
		}
	}

	private static void smethod_10()
	{
		runtimeMethodHandle_0 = new RuntimeMethodHandle[2];
		runtimeMethodHandle_0[0] = default(RuntimeMethodHandle);
		runtimeMethodHandle_0[1] = default(RuntimeMethodHandle);
	}

	private static MemberInfo smethod_11(int int_3)
	{
		return (int_3 >> 28) switch
		{
			1 => smethod_9(int_3), 
			2 => smethod_13(int_3), 
			3 => smethod_6(int_3), 
			_ => throw new NotSupportedException(), 
		};
	}

	private static void smethod_12()
	{
		int_2 = new int[2];
		int_2[0] = 1;
		int_2[1] = 2;
	}

	private static FieldInfo smethod_13(int int_3)
	{
		lock (object_1)
		{
			if (runtimeFieldHandle_0.Length == 0)
			{
				smethod_14();
				smethod_12();
			}
			int num = int_3 & 0xFFFFFFF;
			if (int_2[num] > 0)
			{
				if (runtimeTypeHandle_0.Length == 0)
				{
					smethod_7();
				}
				return FieldInfo.GetFieldFromHandle(runtimeFieldHandle_0[int_3 & 0xFFFFFFF], runtimeTypeHandle_0[int_2[num] - 1]);
			}
			return FieldInfo.GetFieldFromHandle(runtimeFieldHandle_0[int_3 & 0xFFFFFFF]);
		}
	}

	private static void smethod_14()
	{
		runtimeFieldHandle_0 = new RuntimeFieldHandle[2];
		runtimeFieldHandle_0[0] = default(RuntimeFieldHandle);
		runtimeFieldHandle_0[1] = default(RuntimeFieldHandle);
	}

	internal static object[] smethod_15<T>(int int_3, object[] object_2, object object_3, ref T gparam_0)
	{
		Class85 @class = null;
		lock (object_0)
		{
			if (!bool_0)
			{
				bool_0 = true;
				smethod_18();
			}
			if (class85_0[int_3] != null)
			{
				@class = class85_0[int_3];
			}
			else
			{
				binaryReader_0.BaseStream.Position = int_0[int_3];
				@class = new Class85();
				int int_4 = smethod_20(binaryReader_0);
				int num = smethod_20(binaryReader_0);
				int num2 = smethod_20(binaryReader_0);
				int num3 = smethod_20(binaryReader_0);
				@class.methodBase_0 = smethod_3(int_4);
				ParameterInfo[] parameters = @class.methodBase_0.GetParameters();
				@class.leLxEnLbDa = new Class81[parameters.Length];
				for (int i = 0; i < parameters.Length; i++)
				{
					Type type = parameters[i].ParameterType;
					Class81 class2 = new Class81();
					class2.bool_0 = type.IsByRef;
					class2.int_0 = i;
					@class.leLxEnLbDa[i] = class2;
					if (type.IsByRef)
					{
						type = type.GetElementType();
					}
					Enum23 @enum = (Enum23)0;
					@enum = ((!(type == typeof(string))) ? ((!(type == typeof(byte))) ? ((type == typeof(sbyte)) ? ((Enum23)1) : ((!(type == typeof(short))) ? ((!(type == typeof(ushort))) ? ((!(type == typeof(int))) ? ((!(type == typeof(uint))) ? ((!(type == typeof(long))) ? ((!(type == typeof(ulong))) ? ((!(type == typeof(float))) ? ((!(type == typeof(double))) ? ((!(type == typeof(bool))) ? ((!(type == typeof(IntPtr))) ? ((!(type == typeof(UIntPtr))) ? ((type == typeof(char)) ? ((Enum23)15) : ((Enum23)0)) : ((Enum23)13)) : ((Enum23)12)) : ((Enum23)11)) : ((Enum23)10)) : ((Enum23)9)) : ((Enum23)8)) : ((Enum23)7)) : ((Enum23)6)) : ((Enum23)5)) : ((Enum23)4)) : ((Enum23)3))) : ((Enum23)2)) : ((Enum23)14));
					class2.enum23_0 = @enum;
				}
				@class.list_1 = new List<Class82>(num);
				for (int j = 0; j < num; j++)
				{
					int num4 = smethod_20(binaryReader_0);
					Class82 class3 = new Class82();
					class3.type_0 = null;
					if (num4 >= 0 && num4 < 50)
					{
						class3.enum23_0 = (Enum23)(num4 & 0x1F);
						class3.bool_0 = (num4 & 0x20) > 0;
					}
					class3.int_0 = j;
					@class.list_1.Add(class3);
				}
				@class.list_2 = new List<Class83>(num2);
				for (int k = 0; k < num2; k++)
				{
					int num5 = smethod_20(binaryReader_0);
					int num6 = smethod_20(binaryReader_0);
					Class83 class4 = new Class83();
					class4.int_0 = num5;
					class4.int_1 = num6;
					Class84 class5 = (class4.class84_0 = new Class84());
					num5 = smethod_20(binaryReader_0);
					num6 = smethod_20(binaryReader_0);
					int num7 = smethod_20(binaryReader_0);
					class5.int_0 = num5;
					class5.int_1 = num6;
					class5.int_3 = num7;
					switch (num7)
					{
					case 0:
						class5.type_0 = smethod_2(smethod_20(binaryReader_0));
						break;
					case 1:
						class5.int_2 = smethod_20(binaryReader_0);
						break;
					default:
						smethod_20(binaryReader_0);
						break;
					}
					@class.list_2.Add(class4);
				}
				@class.list_2.Sort((Class83 x, Class83 y) => x.class84_0.int_0.CompareTo(y.class84_0.int_0));
				@class.list_0 = new List<Class80>(num3);
				for (int num8 = 0; num8 < num3; num8++)
				{
					Class80 class6 = new Class80();
					byte b = (byte)(class6.enum25_0 = (Enum25)binaryReader_0.ReadByte());
					if (b < 176)
					{
						int num9 = byte_0[b];
						if (num9 == 0)
						{
							class6.object_0 = null;
						}
						else
						{
							object obj = null;
							switch (num9)
							{
							case 1:
								obj = smethod_20(binaryReader_0);
								goto IL_0542;
							case 2:
								obj = binaryReader_0.ReadInt64();
								goto IL_0542;
							case 3:
								obj = binaryReader_0.ReadSingle();
								goto IL_0542;
							case 4:
								obj = binaryReader_0.ReadDouble();
								goto IL_0542;
							case 5:
							{
								int num10 = smethod_20(binaryReader_0);
								int[] array = new int[num10];
								for (int num11 = 0; num11 < num10; num11++)
								{
									array[num11] = smethod_20(binaryReader_0);
								}
								obj = array;
								goto IL_0542;
							}
							default:
								{
									throw new Exception();
								}
								IL_0542:
								class6.object_0 = obj;
								break;
							}
						}
						@class.list_0.Add(class6);
						continue;
					}
					throw new Exception();
				}
				class85_0[int_3] = @class;
			}
		}
		Class88 class7 = new Class88();
		class7.class85_0 = @class;
		ParameterInfo[] parameters2 = @class.methodBase_0.GetParameters();
		bool flag = false;
		int num12 = 0;
		if (@class.methodBase_0 is MethodInfo && ((MethodInfo)@class.methodBase_0).ReturnType != typeof(void))
		{
			flag = true;
		}
		if (@class.methodBase_0.IsStatic)
		{
			class7.class90_0 = new Class90[parameters2.Length];
			for (int num13 = 0; num13 < parameters2.Length; num13++)
			{
				Type parameterType = parameters2[num13].ParameterType;
				class7.class90_0[num13] = Class90.smethod_1(parameterType, object_2[num13]);
				if (parameterType.IsByRef)
				{
					num12++;
				}
			}
		}
		else
		{
			class7.class90_0 = new Class90[parameters2.Length + 1];
			if (@class.methodBase_0.DeclaringType.IsValueType)
			{
				class7.class90_0[0] = new Class101(new Class102(object_3), @class.methodBase_0.DeclaringType);
			}
			else
			{
				class7.class90_0[0] = new Class102(object_3);
			}
			for (int num14 = 0; num14 < parameters2.Length; num14++)
			{
				Type parameterType2 = parameters2[num14].ParameterType;
				if (parameterType2.IsByRef)
				{
					class7.class90_0[num14 + 1] = Class90.smethod_1(parameterType2, object_2[num14]);
					num12++;
				}
				else
				{
					class7.class90_0[num14 + 1] = Class90.smethod_1(parameterType2, object_2[num14]);
				}
			}
		}
		class7.class90_1 = new Class90[@class.list_1.Count];
		for (int num15 = 0; num15 < @class.list_1.Count; num15++)
		{
			Class82 class8 = @class.list_1[num15];
			switch (class8.enum23_0)
			{
			case (Enum23)0:
				class7.class90_1[num15] = null;
				break;
			case (Enum23)7:
			case (Enum23)8:
				class7.class90_1[num15] = new Class93(0L, class8.enum23_0);
				break;
			case (Enum23)9:
			case (Enum23)10:
				class7.class90_1[num15] = new Class95(0.0, class8.enum23_0);
				break;
			case (Enum23)12:
				class7.class90_1[num15] = new Class94(IntPtr.Zero);
				break;
			case (Enum23)13:
				class7.class90_1[num15] = new Class94(UIntPtr.Zero);
				break;
			case (Enum23)14:
				class7.class90_1[num15] = null;
				break;
			case (Enum23)1:
			case (Enum23)2:
			case (Enum23)3:
			case (Enum23)4:
			case (Enum23)5:
			case (Enum23)6:
			case (Enum23)11:
			case (Enum23)15:
				class7.class90_1[num15] = new Class92(0, class8.enum23_0);
				break;
			case (Enum23)16:
				class7.class90_1[num15] = new Class102(null);
				break;
			}
		}
		try
		{
			class7.method_0();
		}
		finally
		{
			class7.method_1();
		}
		int num16 = 0;
		if (flag)
		{
			num16 = 1;
		}
		num16 += num12;
		object[] array2 = new object[num16];
		if (flag)
		{
			array2[0] = null;
		}
		if (@class.methodBase_0 is MethodInfo)
		{
			MethodInfo methodInfo = (MethodInfo)@class.methodBase_0;
			if (methodInfo.ReturnType != typeof(void) && class7.class90_2 != null)
			{
				array2[0] = class7.class90_2.vmethod_4(methodInfo.ReturnType);
			}
		}
		if (num12 > 0)
		{
			int num17 = 0;
			if (flag)
			{
				num17++;
			}
			for (int num18 = 0; num18 < parameters2.Length; num18++)
			{
				Type parameterType3 = parameters2[num18].ParameterType;
				if (!parameterType3.IsByRef)
				{
					continue;
				}
				parameterType3 = parameterType3.GetElementType();
				if (class7.class90_0[num18] != null)
				{
					if (@class.methodBase_0.IsStatic)
					{
						array2[num17] = class7.class90_0[num18].vmethod_4(parameterType3);
					}
					else
					{
						array2[num17] = class7.class90_0[num18 + 1].vmethod_4(parameterType3);
					}
				}
				else
				{
					array2[num17] = null;
				}
				num17++;
			}
		}
		if (!@class.methodBase_0.IsStatic && @class.methodBase_0.DeclaringType.IsValueType)
		{
			gparam_0 = (T)class7.class90_0[0].vmethod_4(@class.methodBase_0.DeclaringType);
		}
		return array2;
	}

	internal static object[] smethod_16(int int_3, object[] object_2, object object_3)
	{
		int gparam_ = 0;
		return smethod_15(int_3, object_2, object_3, ref gparam_);
	}

	internal static object[] smethod_17<T>(int int_3, object[] object_2, ref T gparam_0)
	{
		return smethod_15(int_3, object_2, gparam_0, ref gparam_0);
	}

	internal static void smethod_18()
	{
		if (int_0 == null)
		{
			BinaryReader binaryReader = new BinaryReader(typeof(Class79).Assembly.GetManifestResourceStream("10WUWDd48qOWZi4m7V.NeQhZZjUk20Zd5av2v"));
			binaryReader.BaseStream.Position = 0L;
			byte[] byte_ = binaryReader.ReadBytes((int)binaryReader.BaseStream.Length);
			binaryReader.Close();
			smethod_19(byte_);
		}
	}

	internal static void smethod_19(byte[] byte_1)
	{
		binaryReader_0 = new BinaryReader(new MemoryStream(byte_1));
		byte_0 = new byte[255];
		bool_1 = binaryReader_0.ReadByte() != 0;
		int num = smethod_20(binaryReader_0);
		for (int i = 0; i < num; i++)
		{
			int num2 = binaryReader_0.ReadByte();
			byte_0[num2] = binaryReader_0.ReadByte();
		}
		num = smethod_20(binaryReader_0);
		list_0 = new List<string>(num);
		for (int j = 0; j < num; j++)
		{
			list_0.Add(Encoding.Unicode.GetString(binaryReader_0.ReadBytes(smethod_20(binaryReader_0))));
		}
		num = smethod_20(binaryReader_0);
		class85_0 = new Class85[num];
		int_0 = new int[num];
		for (int k = 0; k < num; k++)
		{
			class85_0[k] = null;
			int_0[k] = smethod_20(binaryReader_0);
		}
		int num3 = (int)binaryReader_0.BaseStream.Position;
		for (int l = 0; l < num; l++)
		{
			int num4 = int_0[l];
			int_0[l] = num3;
			num3 += num4;
		}
	}

	internal static int smethod_20(BinaryReader binaryReader_1)
	{
		int num = 6;
		int num2 = 0;
		while (true)
		{
			bool flag = (byte)num2 != 0;
			while (true)
			{
				uint num3 = 0u;
				while (true)
				{
					uint num4 = binaryReader_1.ReadByte();
					while (true)
					{
						num3 |= num4 & 0x3F;
						while (true)
						{
							IL_00b8:
							if ((num4 & 0x40) == 0)
							{
								goto IL_00a3;
							}
							goto IL_00b1;
							IL_00b1:
							flag = true;
							num = 7;
							goto IL_00a3;
							IL_00a3:
							while (true)
							{
								if (num4 >= 128)
								{
									int num5 = 0;
									while (true)
									{
										int num6 = num5;
										while (true)
										{
											uint num7 = binaryReader_1.ReadByte();
											num = 24;
											while (true)
											{
												if (num != 24)
												{
													if (num != 1005)
													{
														goto IL_008d;
													}
													switch (num)
													{
													case 13:
														goto IL_0084;
													case 11:
														goto IL_008d;
													case 2:
													case 14:
														goto end_IL_006a;
													case 16:
														goto end_IL_0091;
													case 3:
													case 7:
														goto end_IL_00a0;
													case 9:
														goto end_IL_00a3;
													case 15:
														goto IL_00b8;
													case 12:
														goto end_IL_00b8;
													case 0:
														goto end_IL_00c1;
													case 5:
														goto end_IL_00ca;
													case 6:
														goto end_IL_00d3;
													case 4:
														goto IL_00db;
													case 17:
														goto IL_00de;
													case 1:
														goto IL_00e0;
													case 8:
														goto IL_00e3;
													case 10:
														goto IL_00e6;
													}
													continue;
												}
												num3 |= (num7 & 0x7F) << 7 * num6 + 6;
												goto IL_0084;
												IL_00db:
												if (!flag)
												{
													goto IL_00de;
												}
												goto IL_00e0;
												IL_00e0:
												return (int)(~num3);
												IL_00de:
												return (int)num3;
												IL_0084:
												if (num7 >= 128)
												{
													goto IL_008d;
												}
												goto IL_00db;
												IL_008d:
												num6++;
												break;
												continue;
												end_IL_006a:
												break;
											}
											continue;
											end_IL_0091:
											break;
										}
										num5 = 0;
										continue;
										end_IL_00a0:
										break;
									}
									continue;
								}
								goto IL_00e3;
								IL_00e3:
								if (!flag)
								{
									return (int)num3;
								}
								goto IL_00e6;
								IL_00e6:
								return (int)(~num3);
								continue;
								end_IL_00a3:
								break;
							}
							goto IL_00b1;
							continue;
							end_IL_00b8:
							break;
						}
						continue;
						end_IL_00c1:
						break;
					}
					continue;
					end_IL_00ca:
					break;
				}
				continue;
				end_IL_00d3:
				break;
			}
			num2 = 0;
		}
	}

	static Class79()
	{
		Class72.smethod_20();
		class85_0 = null;
		int_0 = null;
		bool_0 = false;
		object_0 = new object();
		module_0 = null;
		runtimeTypeHandle_0 = new RuntimeTypeHandle[0];
		object_1 = new object();
		runtimeMethodHandle_0 = new RuntimeMethodHandle[0];
		int_1 = new int[0];
		int_2 = new int[0];
		runtimeFieldHandle_0 = new RuntimeFieldHandle[0];
		bool_1 = true;
	}
}
