using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
[DebuggerNonUserCode]
[HideModuleName]
[CompilerGenerated]
[StandardModule]
internal sealed class Class7
{
	private static ResourceManager resourceManager_0;

	private static CultureInfo cultureInfo_0;

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static ResourceManager ResourceManager_0
	{
		get
		{
			if (object.ReferenceEquals(resourceManager_0, null))
			{
				resourceManager_0 = new ResourceManager("XXTCC.Resources", typeof(Class7).Assembly);
			}
			return resourceManager_0;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static CultureInfo CultureInfo_0
	{
		set
		{
			cultureInfo_0 = value;
		}
	}

	[SpecialName]
	internal static byte[] smethod_0()
	{
		return (byte[])RuntimeHelpers.GetObjectValue(ResourceManager_0.GetObject("_1nstaller", cultureInfo_0));
	}

	[SpecialName]
	internal static byte[] smethod_1()
	{
		return (byte[])RuntimeHelpers.GetObjectValue(ResourceManager_0.GetObject("Data", cultureInfo_0));
	}
}
