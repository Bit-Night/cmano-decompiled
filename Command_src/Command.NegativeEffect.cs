using System;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media.Effects;
using Command_Core.SmartAssembly.Attributes;

namespace Command;

[DoNotPruneType]
[DoNotObfuscate]
[DoNotPrune]
public sealed class NegativeEffect : ShaderEffect
{
	public static readonly DependencyProperty InputProperty;

	private static PixelShader pixelShader_0;

	public Brush Input
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			return (Brush)((DependencyObject)this).GetValue(InputProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(InputProperty, (object)value);
		}
	}

	static NegativeEffect()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		Class72.smethod_20();
		InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(NegativeEffect), 0);
		pixelShader_0 = new PixelShader();
		pixelShader_0.UriSource = new Uri(Application.StartupPath + "/Shaders/Negative.ps");
	}

	public NegativeEffect()
	{
		((ShaderEffect)this).PixelShader = pixelShader_0;
		((ShaderEffect)this).UpdateShaderValue(InputProperty);
	}
}
