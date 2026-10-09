using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Security;

namespace Collections.Pooled;

internal static class ThrowHelper
{
	internal static void ThrowArrayTypeMismatchException()
	{
		throw new ArrayTypeMismatchException();
	}

	internal static void ThrowIndexOutOfRangeException()
	{
		throw new IndexOutOfRangeException();
	}

	internal static void ThrowArgumentOutOfRangeException()
	{
		throw new ArgumentOutOfRangeException();
	}

	internal static void ThrowArgumentException_DestinationTooShort()
	{
		throw new ArgumentException("Destination too short.");
	}

	internal static void ThrowArgumentException_OverlapAlignmentMismatch()
	{
		throw new ArgumentException("Overlap alignment mismatch.");
	}

	internal static void ThrowArgumentOutOfRange_IndexException()
	{
		throw smethod_7(ExceptionArgument.index, ExceptionResource.ArgumentOutOfRange_Index);
	}

	internal static void ThrowIndexArgumentOutOfRange_NeedNonNegNumException()
	{
		throw smethod_7(ExceptionArgument.index, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
	}

	internal static void ThrowValueArgumentOutOfRange_NeedNonNegNumException()
	{
		throw smethod_7(ExceptionArgument.value, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
	}

	internal static void ThrowLengthArgumentOutOfRange_ArgumentOutOfRange_NeedNonNegNum()
	{
		throw smethod_7(ExceptionArgument.length, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
	}

	internal static void ThrowStartIndexArgumentOutOfRange_ArgumentOutOfRange_Index()
	{
		throw smethod_7(ExceptionArgument.startIndex, ExceptionResource.ArgumentOutOfRange_Index);
	}

	internal static void ThrowCountArgumentOutOfRange_ArgumentOutOfRange_Count()
	{
		throw smethod_7(ExceptionArgument.count, ExceptionResource.ArgumentOutOfRange_Count);
	}

	internal static void ThrowWrongKeyTypeArgumentException<T>(T key, Type targetType)
	{
		throw smethod_4(key, targetType);
	}

	internal static void ThrowWrongValueTypeArgumentException<T>(T value, Type targetType)
	{
		throw smethod_5(value, targetType);
	}

	private static ArgumentException smethod_0(object object_0)
	{
		return new ArgumentException($"Error adding duplicate with key: {object_0}.");
	}

	internal static void ThrowAddingDuplicateWithKeyArgumentException<T>(T key)
	{
		throw smethod_0(key);
	}

	internal static void ThrowKeyNotFoundException<T>(T key)
	{
		throw smethod_6(key);
	}

	internal static void ThrowArgumentException(ExceptionResource resource)
	{
		throw smethod_2(resource);
	}

	internal static void ThrowArgumentException(ExceptionResource resource, ExceptionArgument argument)
	{
		throw smethod_8(resource, argument);
	}

	private static ArgumentNullException smethod_1(ExceptionArgument exceptionArgument_0)
	{
		return new ArgumentNullException(smethod_11(exceptionArgument_0));
	}

	internal static void ThrowArgumentNullException(ExceptionArgument argument)
	{
		throw smethod_1(argument);
	}

	internal static void ThrowArgumentNullException(ExceptionResource resource)
	{
		throw new ArgumentNullException(smethod_12(resource));
	}

	internal static void ThrowArgumentNullException(ExceptionArgument argument, ExceptionResource resource)
	{
		throw new ArgumentNullException(smethod_11(argument), smethod_12(resource));
	}

	internal static void ThrowArgumentOutOfRangeException(ExceptionArgument argument)
	{
		throw new ArgumentOutOfRangeException(smethod_11(argument));
	}

	internal static void ThrowArgumentOutOfRangeException(ExceptionArgument argument, ExceptionResource resource)
	{
		throw smethod_7(argument, resource);
	}

	internal static void ThrowArgumentOutOfRangeException(ExceptionArgument argument, int paramNumber, ExceptionResource resource)
	{
		throw smethod_9(argument, paramNumber, resource);
	}

	internal static void ThrowInvalidOperationException(ExceptionResource resource)
	{
		throw smethod_3(resource);
	}

	internal static void ThrowInvalidOperationException(ExceptionResource resource, Exception e)
	{
		throw new InvalidOperationException(smethod_12(resource), e);
	}

	internal static void ThrowSerializationException(ExceptionResource resource)
	{
		throw new SerializationException(smethod_12(resource));
	}

	internal static void ThrowSecurityException(ExceptionResource resource)
	{
		throw new SecurityException(smethod_12(resource));
	}

	internal static void ThrowRankException(ExceptionResource resource)
	{
		throw new RankException(smethod_12(resource));
	}

	internal static void ThrowNotSupportedException(ExceptionResource resource)
	{
		throw new NotSupportedException(smethod_12(resource));
	}

	internal static void ThrowUnauthorizedAccessException(ExceptionResource resource)
	{
		throw new UnauthorizedAccessException(smethod_12(resource));
	}

	internal static void ThrowObjectDisposedException(string objectName, ExceptionResource resource)
	{
		throw new ObjectDisposedException(objectName, smethod_12(resource));
	}

	internal static void ThrowObjectDisposedException(ExceptionResource resource)
	{
		throw new ObjectDisposedException(null, smethod_12(resource));
	}

	internal static void ThrowNotSupportedException()
	{
		throw new NotSupportedException();
	}

	internal static void ThrowAggregateException(List<Exception> exceptions)
	{
		throw new AggregateException(exceptions);
	}

	internal static void ThrowOutOfMemoryException()
	{
		throw new OutOfMemoryException();
	}

	internal static void ThrowArgumentException_Argument_InvalidArrayType()
	{
		throw new ArgumentException("Invalid array type.");
	}

	internal static void ThrowInvalidOperationException_InvalidOperation_EnumNotStarted()
	{
		throw new InvalidOperationException("Enumeration has not started.");
	}

	internal static void ThrowInvalidOperationException_InvalidOperation_EnumEnded()
	{
		throw new InvalidOperationException("Enumeration has ended.");
	}

	internal static void ThrowInvalidOperationException_EnumCurrent(int index)
	{
		throw smethod_10(index);
	}

	internal static void ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion()
	{
		throw new InvalidOperationException("Collection was modified during enumeration.");
	}

	internal static void ThrowInvalidOperationException_InvalidOperation_EnumOpCantHappen()
	{
		throw new InvalidOperationException("Invalid enumerator state: enumeration cannot proceed.");
	}

	internal static void ThrowInvalidOperationException_InvalidOperation_NoValue()
	{
		throw new InvalidOperationException("No value provided.");
	}

	internal static void ThrowInvalidOperationException_ConcurrentOperationsNotSupported()
	{
		throw new InvalidOperationException("Concurrent operations are not supported.");
	}

	internal static void ThrowInvalidOperationException_HandleIsNotInitialized()
	{
		throw new InvalidOperationException("Handle is not initialized.");
	}

	internal static void ThrowFormatException_BadFormatSpecifier()
	{
		throw new FormatException("Bad format specifier.");
	}

	private static ArgumentException smethod_2(ExceptionResource exceptionResource_0)
	{
		return new ArgumentException(smethod_12(exceptionResource_0));
	}

	private static InvalidOperationException smethod_3(ExceptionResource exceptionResource_0)
	{
		return new InvalidOperationException(smethod_12(exceptionResource_0));
	}

	private static ArgumentException smethod_4(object object_0, Type type_0)
	{
		return new ArgumentException($"Wrong key type. Expected {type_0}, got: '{object_0}'.", "key");
	}

	private static ArgumentException smethod_5(object object_0, Type type_0)
	{
		return new ArgumentException($"Wrong value type. Expected {type_0}, got: '{object_0}'.", "value");
	}

	private static KeyNotFoundException smethod_6(object object_0)
	{
		return new KeyNotFoundException($"Key not found: {object_0}");
	}

	private static ArgumentOutOfRangeException smethod_7(ExceptionArgument exceptionArgument_0, ExceptionResource exceptionResource_0)
	{
		return new ArgumentOutOfRangeException(smethod_11(exceptionArgument_0), smethod_12(exceptionResource_0));
	}

	private static ArgumentException smethod_8(ExceptionResource exceptionResource_0, ExceptionArgument exceptionArgument_0)
	{
		return new ArgumentException(smethod_12(exceptionResource_0), smethod_11(exceptionArgument_0));
	}

	private static ArgumentOutOfRangeException smethod_9(ExceptionArgument exceptionArgument_0, int int_0, ExceptionResource exceptionResource_0)
	{
		return new ArgumentOutOfRangeException(smethod_11(exceptionArgument_0) + "[" + int_0 + "]", smethod_12(exceptionResource_0));
	}

	private static InvalidOperationException smethod_10(int int_0)
	{
		return new InvalidOperationException((int_0 >= 0) ? "Enumeration has ended" : "Enumeration has not started");
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static void IfNullAndNullsAreIllegalThenThrow<T>(object value, ExceptionArgument argName)
	{
		if (default(T) != null && value == null)
		{
			ThrowArgumentNullException(argName);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static void ThrowForUnsupportedVectorBaseType<T>() where T : struct
	{
		if (typeof(T) != typeof(byte) && typeof(T) != typeof(sbyte) && typeof(T) != typeof(short) && typeof(T) != typeof(ushort) && typeof(T) != typeof(int) && typeof(T) != typeof(uint) && typeof(T) != typeof(long) && typeof(T) != typeof(ulong) && typeof(T) != typeof(float) && typeof(T) != typeof(double))
		{
			ThrowNotSupportedException(ExceptionResource.Arg_TypeNotSupported);
		}
	}

	private static string smethod_11(ExceptionArgument exceptionArgument_0)
	{
		return exceptionArgument_0 switch
		{
			ExceptionArgument.obj => "obj", 
			ExceptionArgument.dictionary => "dictionary", 
			ExceptionArgument.array => "array", 
			ExceptionArgument.info => "info", 
			ExceptionArgument.key => "key", 
			ExceptionArgument.text => "text", 
			ExceptionArgument.values => "values", 
			ExceptionArgument.value => "value", 
			ExceptionArgument.startIndex => "startIndex", 
			ExceptionArgument.task => "task", 
			ExceptionArgument.ch => "ch", 
			ExceptionArgument.s => "s", 
			ExceptionArgument.input => "input", 
			ExceptionArgument.list => "list", 
			ExceptionArgument.index => "index", 
			ExceptionArgument.capacity => "capacity", 
			ExceptionArgument.collection => "collection", 
			ExceptionArgument.item => "item", 
			ExceptionArgument.converter => "converter", 
			ExceptionArgument.match => "match", 
			ExceptionArgument.count => "count", 
			ExceptionArgument.action => "action", 
			ExceptionArgument.comparison => "comparison", 
			ExceptionArgument.exceptions => "exceptions", 
			ExceptionArgument.exception => "exception", 
			ExceptionArgument.enumerable => "enumerable", 
			ExceptionArgument.start => "start", 
			ExceptionArgument.format => "format", 
			ExceptionArgument.culture => "culture", 
			ExceptionArgument.comparer => "comparer", 
			ExceptionArgument.comparable => "comparable", 
			ExceptionArgument.source => "source", 
			ExceptionArgument.state => "state", 
			ExceptionArgument.length => "length", 
			ExceptionArgument.comparisonType => "comparisonType", 
			ExceptionArgument.manager => "manager", 
			ExceptionArgument.sourceBytesToCopy => "sourceBytesToCopy", 
			ExceptionArgument.callBack => "callBack", 
			ExceptionArgument.creationOptions => "creationOptions", 
			ExceptionArgument.function => "function", 
			ExceptionArgument.delay => "delay", 
			ExceptionArgument.millisecondsDelay => "millisecondsDelay", 
			ExceptionArgument.millisecondsTimeout => "millisecondsTimeout", 
			ExceptionArgument.timeout => "timeout", 
			ExceptionArgument.type => "type", 
			ExceptionArgument.sourceIndex => "sourceIndex", 
			ExceptionArgument.sourceArray => "sourceArray", 
			ExceptionArgument.destinationIndex => "destinationIndex", 
			ExceptionArgument.destinationArray => "destinationArray", 
			ExceptionArgument.other => "other", 
			ExceptionArgument.newSize => "newSize", 
			ExceptionArgument.lowerBounds => "lowerBounds", 
			ExceptionArgument.lengths => "lengths", 
			ExceptionArgument.len => "len", 
			ExceptionArgument.keys => "keys", 
			ExceptionArgument.indices => "indices", 
			ExceptionArgument.endIndex => "endIndex", 
			ExceptionArgument.elementType => "elementType", 
			ExceptionArgument.arrayIndex => "arrayIndex", 
			_ => exceptionArgument_0.ToString(), 
		};
	}

	private static string smethod_12(ExceptionResource exceptionResource_0)
	{
		return exceptionResource_0 switch
		{
			ExceptionResource.ArgumentOutOfRange_Index => "Argument 'index' was out of the range of valid values.", 
			ExceptionResource.ArgumentOutOfRange_Count => "Argument 'count' was out of the range of valid values.", 
			ExceptionResource.Arg_ArrayPlusOffTooSmall => "Array plus offset too small.", 
			ExceptionResource.NotSupported_ReadOnlyCollection => "This operation is not supported on a read-only collection.", 
			ExceptionResource.Arg_RankMultiDimNotSupported => "Multi-dimensional arrays are not supported.", 
			ExceptionResource.Arg_NonZeroLowerBound => "Arrays with a non-zero lower bound are not supported.", 
			ExceptionResource.ArgumentOutOfRange_ListInsert => "Insertion index was out of the range of valid values.", 
			ExceptionResource.ArgumentOutOfRange_NeedNonNegNum => "The number must be non-negative.", 
			ExceptionResource.ArgumentOutOfRange_SmallCapacity => "The capacity cannot be set below the current Count.", 
			ExceptionResource.Argument_InvalidOffLen => "Invalid offset length.", 
			ExceptionResource.ArgumentOutOfRange_BiggerThanCollection => "The given value was larger than the size of the collection.", 
			ExceptionResource.Serialization_MissingKeys => "Serialization error: missing keys.", 
			ExceptionResource.Serialization_NullKey => "Serialization error: null key.", 
			ExceptionResource.NotSupported_KeyCollectionSet => "The KeyCollection does not support modification.", 
			ExceptionResource.NotSupported_ValueCollectionSet => "The ValueCollection does not support modification.", 
			ExceptionResource.InvalidOperation_NullArray => "Null arrays are not supported.", 
			ExceptionResource.InvalidOperation_HSCapacityOverflow => "Set hash capacity overflow. Cannot increase size.", 
			ExceptionResource.NotSupported_StringComparison => "String comparison not supported.", 
			ExceptionResource.ConcurrentCollection_SyncRoot_NotSupported => "SyncRoot not supported.", 
			ExceptionResource.ArgumentException_OtherNotArrayOfCorrectLength => "The other array is not of the correct length.", 
			ExceptionResource.ArgumentOutOfRange_EndIndexStartIndex => "The end index does not come after the start index.", 
			ExceptionResource.ArgumentOutOfRange_HugeArrayNotSupported => "Huge arrays are not supported.", 
			ExceptionResource.Argument_AddingDuplicate => "Duplicate item added.", 
			ExceptionResource.Argument_InvalidArgumentForComparison => "Invalid argument for comparison.", 
			ExceptionResource.Arg_LowerBoundsMustMatch => "Array lower bounds must match.", 
			ExceptionResource.Arg_MustBeType => "Argument must be of type: ", 
			ExceptionResource.InvalidOperation_IComparerFailed => "IComparer failed.", 
			ExceptionResource.NotSupported_FixedSizeCollection => "This operation is not suppored on a fixed-size collection.", 
			ExceptionResource.Rank_MultiDimNotSupported => "Multi-dimensional arrays are not supported.", 
			ExceptionResource.Arg_TypeNotSupported => "Type not supported.", 
			_ => exceptionResource_0.ToString(), 
		};
	}

	static ThrowHelper()
	{
		Class72.smethod_20();
	}
}
