using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace Gameloop.Vdf.Utilities;

internal sealed class DynamicProxyMetaObject<T> : DynamicMetaObject
{
	private delegate DynamicMetaObject Delegate3(DynamicMetaObject errorSuggestion);

	private sealed class Class28 : GetMemberBinder
	{
		internal static object object_0;

		internal Class28(InvokeMemberBinder invokeMemberBinder_0)
			: base(invokeMemberBinder_0.Name, invokeMemberBinder_0.IgnoreCase)
		{
		}

		public override DynamicMetaObject FallbackGetMember(DynamicMetaObject target, DynamicMetaObject errorSuggestion)
		{
			throw new NotSupportedException();
		}

		static Class28()
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

	private readonly DynamicProxy<T> dynamicProxy_0;

	private static object object_0;

	internal DynamicProxyMetaObject(Expression expression, T value, DynamicProxy<T> proxy)
		: base(expression, BindingRestrictions.Empty, value)
	{
		dynamicProxy_0 = proxy;
	}

	private bool method_0(string string_0)
	{
		return ReflectionUtils.IsMethodOverridden(dynamicProxy_0.GetType(), typeof(DynamicProxy<T>), string_0);
	}

	public override DynamicMetaObject BindGetMember(GetMemberBinder binder)
	{
		if (!method_0("TryGetMember"))
		{
			return base.BindGetMember(binder);
		}
		return method_1("TryGetMember", binder, smethod_0(), (DynamicMetaObject e) => binder.FallbackGetMember(this, e));
	}

	public override DynamicMetaObject BindSetMember(SetMemberBinder binder, DynamicMetaObject value)
	{
		if (method_0("TrySetMember"))
		{
			return method_3("TrySetMember", binder, smethod_1(value), (DynamicMetaObject e) => binder.FallbackSetMember(this, value, e));
		}
		return base.BindSetMember(binder, value);
	}

	public override DynamicMetaObject BindDeleteMember(DeleteMemberBinder binder)
	{
		if (method_0("TryDeleteMember"))
		{
			return method_4("TryDeleteMember", binder, smethod_0(), (DynamicMetaObject e) => binder.FallbackDeleteMember(this, e));
		}
		return base.BindDeleteMember(binder);
	}

	public override DynamicMetaObject BindConvert(ConvertBinder binder)
	{
		if (!method_0("TryConvert"))
		{
			return base.BindConvert(binder);
		}
		return method_1("TryConvert", binder, smethod_0(), (DynamicMetaObject e) => binder.FallbackConvert(this, e));
	}

	public override DynamicMetaObject BindInvokeMember(InvokeMemberBinder binder, DynamicMetaObject[] args)
	{
		if (!method_0("TryInvokeMember"))
		{
			return base.BindInvokeMember(binder, args);
		}
		Delegate3 @delegate = (DynamicMetaObject e) => binder.FallbackInvokeMember(this, args, e);
		return method_2("TryInvokeMember", binder, smethod_2(args), method_2("TryGetMember", new Class28(binder), smethod_0(), @delegate(null), (DynamicMetaObject e) => binder.FallbackInvoke(e, args, null)), null);
	}

	public override DynamicMetaObject BindCreateInstance(CreateInstanceBinder binder, DynamicMetaObject[] args)
	{
		if (!method_0("TryCreateInstance"))
		{
			return base.BindCreateInstance(binder, args);
		}
		return method_1("TryCreateInstance", binder, smethod_2(args), (DynamicMetaObject e) => binder.FallbackCreateInstance(this, args, e));
	}

	public override DynamicMetaObject BindInvoke(InvokeBinder binder, DynamicMetaObject[] args)
	{
		if (method_0("TryInvoke"))
		{
			return method_1("TryInvoke", binder, smethod_2(args), (DynamicMetaObject e) => binder.FallbackInvoke(this, args, e));
		}
		return base.BindInvoke(binder, args);
	}

	public override DynamicMetaObject BindBinaryOperation(BinaryOperationBinder binder, DynamicMetaObject arg)
	{
		if (method_0("TryBinaryOperation"))
		{
			return method_1("TryBinaryOperation", binder, smethod_1(arg), (DynamicMetaObject e) => binder.FallbackBinaryOperation(this, arg, e));
		}
		return base.BindBinaryOperation(binder, arg);
	}

	public override DynamicMetaObject BindUnaryOperation(UnaryOperationBinder binder)
	{
		if (!method_0("TryUnaryOperation"))
		{
			return base.BindUnaryOperation(binder);
		}
		return method_1("TryUnaryOperation", binder, smethod_0(), (DynamicMetaObject e) => binder.FallbackUnaryOperation(this, e));
	}

	public override DynamicMetaObject BindGetIndex(GetIndexBinder binder, DynamicMetaObject[] indexes)
	{
		if (method_0("TryGetIndex"))
		{
			return method_1("TryGetIndex", binder, smethod_2(indexes), (DynamicMetaObject e) => binder.FallbackGetIndex(this, indexes, e));
		}
		return base.BindGetIndex(binder, indexes);
	}

	public override DynamicMetaObject BindSetIndex(SetIndexBinder binder, DynamicMetaObject[] indexes, DynamicMetaObject value)
	{
		if (!method_0("TrySetIndex"))
		{
			return base.BindSetIndex(binder, indexes, value);
		}
		return method_3("TrySetIndex", binder, smethod_3(indexes, value), (DynamicMetaObject e) => binder.FallbackSetIndex(this, indexes, value, e));
	}

	public override DynamicMetaObject BindDeleteIndex(DeleteIndexBinder binder, DynamicMetaObject[] indexes)
	{
		if (!method_0("TryDeleteIndex"))
		{
			return base.BindDeleteIndex(binder, indexes);
		}
		return method_4("TryDeleteIndex", binder, smethod_2(indexes), (DynamicMetaObject e) => binder.FallbackDeleteIndex(this, indexes, e));
	}

	[SpecialName]
	private static Expression[] smethod_0()
	{
		return CollectionUtils.ArrayEmpty<Expression>();
	}

	private static IEnumerable<Expression> smethod_1(params DynamicMetaObject[] args)
	{
		return args.Select(delegate(DynamicMetaObject arg)
		{
			Expression expression = arg.Expression;
			return (!TypeExtensions.IsValueType(expression.Type)) ? expression : System.Linq.Expressions.Expression.Convert(expression, typeof(object));
		});
	}

	private static Expression[] smethod_2(DynamicMetaObject[] dynamicMetaObject_0)
	{
		return new NewArrayExpression[1] { System.Linq.Expressions.Expression.NewArrayInit(typeof(object), smethod_1(dynamicMetaObject_0)) };
	}

	private static Expression[] smethod_3(DynamicMetaObject[] dynamicMetaObject_0, DynamicMetaObject dynamicMetaObject_1)
	{
		Expression expression = dynamicMetaObject_1.Expression;
		return new Expression[2]
		{
			System.Linq.Expressions.Expression.NewArrayInit(typeof(object), smethod_1(dynamicMetaObject_0)),
			(!TypeExtensions.IsValueType(expression.Type)) ? expression : System.Linq.Expressions.Expression.Convert(expression, typeof(object))
		};
	}

	private static ConstantExpression smethod_4(DynamicMetaObjectBinder dynamicMetaObjectBinder_0)
	{
		Type type = dynamicMetaObjectBinder_0.GetType();
		while (!TypeExtensions.IsVisible(type))
		{
			type = TypeExtensions.BaseType(type);
		}
		return System.Linq.Expressions.Expression.Constant(dynamicMetaObjectBinder_0, type);
	}

	private DynamicMetaObject method_1(string string_0, DynamicMetaObjectBinder dynamicMetaObjectBinder_0, IEnumerable<Expression> ienumerable_0, Delegate3 delegate3_0, Delegate3 delegate3_1 = null)
	{
		DynamicMetaObject dynamicMetaObject_ = delegate3_0(null);
		return method_2(string_0, dynamicMetaObjectBinder_0, ienumerable_0, dynamicMetaObject_, delegate3_1);
	}

	private DynamicMetaObject method_2(string string_0, DynamicMetaObjectBinder dynamicMetaObjectBinder_0, IEnumerable<Expression> ienumerable_0, DynamicMetaObject dynamicMetaObject_0, Delegate3 delegate3_0)
	{
		ParameterExpression parameterExpression = System.Linq.Expressions.Expression.Parameter(typeof(object), null);
		IList<Expression> list = new List<Expression>();
		list.Add(System.Linq.Expressions.Expression.Convert(base.Expression, typeof(T)));
		list.Add(smethod_4(dynamicMetaObjectBinder_0));
		CollectionUtils.AddRange(list, ienumerable_0);
		list.Add(parameterExpression);
		DynamicMetaObject dynamicMetaObject = new DynamicMetaObject(parameterExpression, BindingRestrictions.Empty);
		if (dynamicMetaObjectBinder_0.ReturnType != typeof(object))
		{
			dynamicMetaObject = new DynamicMetaObject(System.Linq.Expressions.Expression.Convert(dynamicMetaObject.Expression, dynamicMetaObjectBinder_0.ReturnType), dynamicMetaObject.Restrictions);
		}
		int num;
		if (delegate3_0 == null)
		{
			num = 1;
		}
		else
		{
			dynamicMetaObject = delegate3_0(dynamicMetaObject);
			num = 1;
		}
		ParameterExpression[] array = new ParameterExpression[num];
		array[0] = parameterExpression;
		return new DynamicMetaObject(System.Linq.Expressions.Expression.Block(array, System.Linq.Expressions.Expression.Condition(System.Linq.Expressions.Expression.Call(System.Linq.Expressions.Expression.Constant(dynamicProxy_0), typeof(DynamicProxy<T>).GetMethod(string_0), list), dynamicMetaObject.Expression, dynamicMetaObject_0.Expression, dynamicMetaObjectBinder_0.ReturnType)), method_5().Merge(dynamicMetaObject.Restrictions).Merge(dynamicMetaObject_0.Restrictions));
	}

	private DynamicMetaObject method_3(string string_0, DynamicMetaObjectBinder dynamicMetaObjectBinder_0, IEnumerable<Expression> ienumerable_0, Delegate3 delegate3_0)
	{
		DynamicMetaObject dynamicMetaObject = delegate3_0(null);
		ParameterExpression parameterExpression = System.Linq.Expressions.Expression.Parameter(typeof(object), null);
		IList<Expression> list = new List<Expression>();
		list.Add(System.Linq.Expressions.Expression.Convert(base.Expression, typeof(T)));
		list.Add(smethod_4(dynamicMetaObjectBinder_0));
		CollectionUtils.AddRange(list, ienumerable_0);
		list[list.Count - 1] = System.Linq.Expressions.Expression.Assign(parameterExpression, list[list.Count - 1]);
		return new DynamicMetaObject(System.Linq.Expressions.Expression.Block(new ParameterExpression[1] { parameterExpression }, System.Linq.Expressions.Expression.Condition(System.Linq.Expressions.Expression.Call(System.Linq.Expressions.Expression.Constant(dynamicProxy_0), typeof(DynamicProxy<T>).GetMethod(string_0), list), parameterExpression, dynamicMetaObject.Expression, typeof(object))), method_5().Merge(dynamicMetaObject.Restrictions));
	}

	private DynamicMetaObject method_4(string string_0, DynamicMetaObjectBinder dynamicMetaObjectBinder_0, Expression[] expression_0, Delegate3 delegate3_0)
	{
		DynamicMetaObject dynamicMetaObject = delegate3_0(null);
		IList<Expression> list = new List<Expression>();
		list.Add(System.Linq.Expressions.Expression.Convert(base.Expression, typeof(T)));
		list.Add(smethod_4(dynamicMetaObjectBinder_0));
		CollectionUtils.AddRange(list, expression_0);
		return new DynamicMetaObject(System.Linq.Expressions.Expression.Condition(System.Linq.Expressions.Expression.Call(System.Linq.Expressions.Expression.Constant(dynamicProxy_0), typeof(DynamicProxy<T>).GetMethod(string_0), list), System.Linq.Expressions.Expression.Empty(), dynamicMetaObject.Expression, typeof(void)), method_5().Merge(dynamicMetaObject.Restrictions));
	}

	private BindingRestrictions method_5()
	{
		if (base.Value == null && base.HasValue)
		{
			return BindingRestrictions.GetInstanceRestriction(base.Expression, null);
		}
		return BindingRestrictions.GetTypeRestriction(base.Expression, base.LimitType);
	}

	public override IEnumerable<string> GetDynamicMemberNames()
	{
		return dynamicProxy_0.GetDynamicMemberNames((T)base.Value);
	}

	static DynamicProxyMetaObject()
	{
		Class72.smethod_20();
	}

	internal static bool smethod_5()
	{
		return object_0 == null;
	}

	internal static object smethod_6()
	{
		return object_0;
	}
}
