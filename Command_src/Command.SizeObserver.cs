using System.Windows;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[StandardModule]
[DoNotObfuscate]
[DoNotPruneType]
[DoNotPrune]
[DoNotObfuscateType]
internal sealed class SizeObserver
{
	[DoNotPrune]
	public static readonly DependencyProperty ObserveProperty;

	[DoNotPrune]
	public static readonly DependencyProperty ObservedWidthProperty;

	[DoNotPrune]
	public static readonly DependencyProperty ObservedHeightProperty;

	static SizeObserver()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected O, but got Unknown
		Class72.smethod_20();
		ObserveProperty = DependencyProperty.RegisterAttached("Observe", typeof(bool), typeof(SizeObserver), (PropertyMetadata)new FrameworkPropertyMetadata(new PropertyChangedCallback(smethod_0)));
		ObservedWidthProperty = DependencyProperty.RegisterAttached("ObservedWidth", typeof(double), typeof(SizeObserver));
		ObservedHeightProperty = DependencyProperty.RegisterAttached("ObservedHeight", typeof(double), typeof(SizeObserver));
	}

	[DoNotPrune]
	public static bool GetObserve(FrameworkElement frameworkElement)
	{
		return Conversions.ToBoolean(((DependencyObject)frameworkElement).GetValue(ObserveProperty));
	}

	[DoNotPrune]
	public static void SetObserve(FrameworkElement frameworkElement, bool observe)
	{
		((DependencyObject)frameworkElement).SetValue(ObserveProperty, (object)observe);
	}

	[DoNotPrune]
	public static double GetObservedWidth(FrameworkElement frameworkElement)
	{
		return Conversions.ToDouble(((DependencyObject)frameworkElement).GetValue(ObservedWidthProperty));
	}

	[DoNotPrune]
	public static void SetObservedWidth(FrameworkElement frameworkElement, double observedWidth)
	{
		((DependencyObject)frameworkElement).SetValue(ObservedWidthProperty, (object)observedWidth);
	}

	[DoNotPrune]
	public static double GetObservedHeight(FrameworkElement frameworkElement)
	{
		return Conversions.ToDouble(((DependencyObject)frameworkElement).GetValue(ObservedHeightProperty));
	}

	[DoNotPrune]
	public static void SetObservedHeight(FrameworkElement frameworkElement, double observedHeight)
	{
		((DependencyObject)frameworkElement).SetValue(ObservedHeightProperty, (object)observedHeight);
	}

	[DoNotPrune]
	private static void smethod_0(FrameworkElement frameworkElement_0, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs_0)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		FrameworkElement val = frameworkElement_0;
		if (!Conversions.ToBoolean(((DependencyPropertyChangedEventArgs)(ref dependencyPropertyChangedEventArgs_0)).NewValue))
		{
			val.SizeChanged += new SizeChangedEventHandler(smethod_1);
			return;
		}
		val.SizeChanged += new SizeChangedEventHandler(smethod_1);
		smethod_2(val);
	}

	[DoNotPrune]
	private static void smethod_1(FrameworkElement frameworkElement_0, object object_0)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		smethod_2(frameworkElement_0);
	}

	[DoNotPrune]
	private static void smethod_2(object object_0)
	{
		((DependencyObject)object_0).SetCurrentValue(ObservedWidthProperty, (object)((FrameworkElement)object_0).ActualWidth);
		((DependencyObject)object_0).SetCurrentValue(ObservedHeightProperty, (object)((FrameworkElement)object_0).ActualHeight);
	}
}
