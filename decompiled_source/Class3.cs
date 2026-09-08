using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;
using XXTCC;

[StandardModule]
[HideModuleName]
[GeneratedCode("MyTemplate", "11.0.0.0")]
internal sealed class Class3
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MyGroupCollection("System.Windows.Forms.Form", "Create__Instance__", "Dispose__Instance__", "My.MyProject.Forms")]
	internal sealed class Class4
	{
		[ThreadStatic]
		private static Hashtable hashtable_0;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public AboutBox aboutBox_0;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Form_ChangeName form_ChangeName_0;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Form_Config form_Config_0;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Form_Declare form_Declare_0;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Form_EditDB form_EditDB_0;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Form_Key form_Key_0;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Form_Main_t form_Main_t_0;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Form_Push form_Push_0;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Form_Scan form_Scan_0;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Form_ScriptInfo form_ScriptInfo_0;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Form_synchronous form_synchronous_0;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Frm_Auth frm_Auth_0;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Frm_Back_SHSH2 frm_Back_SHSH2_0;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Frm_Edit frm_Edit_0;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Frm_Level frm_Level_0;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Frm_MadeUI frm_MadeUI_0;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Frm_SSH frm_SSH_0;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Frm_User_cfg frm_User_cfg_0;

		public AboutBox AboutBox
		{
			get
			{
				aboutBox_0 = smethod_0(aboutBox_0);
				return aboutBox_0;
			}
			set
			{
				if (value != aboutBox_0)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref aboutBox_0);
				}
			}
		}

		public Form_ChangeName Form_ChangeName
		{
			get
			{
				form_ChangeName_0 = smethod_0(form_ChangeName_0);
				return form_ChangeName_0;
			}
			set
			{
				if (value != form_ChangeName_0)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref form_ChangeName_0);
				}
			}
		}

		public Form_Config Form_Config
		{
			get
			{
				form_Config_0 = smethod_0(form_Config_0);
				return form_Config_0;
			}
			set
			{
				if (value != form_Config_0)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref form_Config_0);
				}
			}
		}

		public Form_Declare Form_Declare
		{
			get
			{
				form_Declare_0 = smethod_0(form_Declare_0);
				return form_Declare_0;
			}
			set
			{
				if (value != form_Declare_0)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref form_Declare_0);
				}
			}
		}

		public Form_EditDB Form_EditDB
		{
			get
			{
				form_EditDB_0 = smethod_0(form_EditDB_0);
				return form_EditDB_0;
			}
			set
			{
				if (value != form_EditDB_0)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref form_EditDB_0);
				}
			}
		}

		public Form_Key Form_Key
		{
			get
			{
				form_Key_0 = smethod_0(form_Key_0);
				return form_Key_0;
			}
			set
			{
				if (value != form_Key_0)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref form_Key_0);
				}
			}
		}

		public Form_Main_t Form_Main_t
		{
			get
			{
				form_Main_t_0 = smethod_0(form_Main_t_0);
				return form_Main_t_0;
			}
			set
			{
				if (value != form_Main_t_0)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref form_Main_t_0);
				}
			}
		}

		public Form_Push Form_Push
		{
			get
			{
				form_Push_0 = smethod_0(form_Push_0);
				return form_Push_0;
			}
			set
			{
				if (value != form_Push_0)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref form_Push_0);
				}
			}
		}

		public Form_Scan Form_Scan
		{
			get
			{
				form_Scan_0 = smethod_0(form_Scan_0);
				return form_Scan_0;
			}
			set
			{
				if (value != form_Scan_0)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref form_Scan_0);
				}
			}
		}

		public Form_ScriptInfo Form_ScriptInfo
		{
			get
			{
				form_ScriptInfo_0 = smethod_0(form_ScriptInfo_0);
				return form_ScriptInfo_0;
			}
			set
			{
				if (value != form_ScriptInfo_0)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref form_ScriptInfo_0);
				}
			}
		}

		public Form_synchronous Form_synchronous
		{
			get
			{
				form_synchronous_0 = smethod_0(form_synchronous_0);
				return form_synchronous_0;
			}
			set
			{
				if (value != form_synchronous_0)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref form_synchronous_0);
				}
			}
		}

		public Frm_Auth Frm_Auth
		{
			get
			{
				frm_Auth_0 = smethod_0(frm_Auth_0);
				return frm_Auth_0;
			}
			set
			{
				if (value != frm_Auth_0)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref frm_Auth_0);
				}
			}
		}

		public Frm_Back_SHSH2 Frm_Back_SHSH2
		{
			get
			{
				frm_Back_SHSH2_0 = smethod_0(frm_Back_SHSH2_0);
				return frm_Back_SHSH2_0;
			}
			set
			{
				if (value != frm_Back_SHSH2_0)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref frm_Back_SHSH2_0);
				}
			}
		}

		public Frm_Edit Frm_Edit
		{
			get
			{
				frm_Edit_0 = smethod_0(frm_Edit_0);
				return frm_Edit_0;
			}
			set
			{
				if (value != frm_Edit_0)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref frm_Edit_0);
				}
			}
		}

		public Frm_Level Frm_Level
		{
			get
			{
				frm_Level_0 = smethod_0(frm_Level_0);
				return frm_Level_0;
			}
			set
			{
				if (value != frm_Level_0)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref frm_Level_0);
				}
			}
		}

		public Frm_MadeUI Frm_MadeUI
		{
			get
			{
				frm_MadeUI_0 = smethod_0(frm_MadeUI_0);
				return frm_MadeUI_0;
			}
			set
			{
				if (value != frm_MadeUI_0)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref frm_MadeUI_0);
				}
			}
		}

		public Frm_SSH Frm_SSH
		{
			get
			{
				frm_SSH_0 = smethod_0(frm_SSH_0);
				return frm_SSH_0;
			}
			set
			{
				if (value != frm_SSH_0)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref frm_SSH_0);
				}
			}
		}

		public Frm_User_cfg Frm_User_cfg
		{
			get
			{
				frm_User_cfg_0 = smethod_0(frm_User_cfg_0);
				return frm_User_cfg_0;
			}
			set
			{
				if (value != frm_User_cfg_0)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					method_0(ref frm_User_cfg_0);
				}
			}
		}

		[DebuggerHidden]
		private static AyxNrmh9GGTLFWbfjB smethod_0<AyxNrmh9GGTLFWbfjB>(AyxNrmh9GGTLFWbfjB jL7oA6p4JreC9cv62o) where AyxNrmh9GGTLFWbfjB : Form, new()
		{
			if (jL7oA6p4JreC9cv62o != null && !jL7oA6p4JreC9cv62o.IsDisposed)
			{
				return jL7oA6p4JreC9cv62o;
			}
			if (hashtable_0 != null)
			{
				if (hashtable_0.ContainsKey(typeof(AyxNrmh9GGTLFWbfjB)))
				{
					throw new InvalidOperationException(Utils.GetResourceString("WinForms_RecursiveFormCreate"));
				}
			}
			else
			{
				hashtable_0 = new Hashtable();
			}
			hashtable_0.Add(typeof(AyxNrmh9GGTLFWbfjB), null);
			try
			{
				return new AyxNrmh9GGTLFWbfjB();
			}
			catch (TargetInvocationException ex) when (((Func<bool>)delegate
			{
				// Could not convert BlockContainer to single expression
				ProjectData.SetProjectError(ex);
				return ex.InnerException != null;
			}).Invoke())
			{
				throw new InvalidOperationException(Utils.GetResourceString("WinForms_SeeInnerException", ex.InnerException.Message), ex.InnerException);
			}
			finally
			{
				hashtable_0.Remove(typeof(AyxNrmh9GGTLFWbfjB));
			}
		}

		[DebuggerHidden]
		private void method_0<SPcLkQ3Rmrcc9aXZZt>(ref SPcLkQ3Rmrcc9aXZZt gparam_0) where SPcLkQ3Rmrcc9aXZZt : Form
		{
			gparam_0.Dispose();
			gparam_0 = null;
		}

		[DebuggerHidden]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public Class4()
		{
			Class14.QwnfEIbzxvDCI();
			base._002Ector();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override bool Equals(object obj)
		{
			return base.Equals(RuntimeHelpers.GetObjectValue(obj));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		internal Type method_1()
		{
			return typeof(Class4);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override string ToString()
		{
			return base.ToString();
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MyGroupCollection("System.Web.Services.Protocols.SoapHttpClientProtocol", "Create__Instance__", "Dispose__Instance__", "")]
	internal sealed class Class5
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerHidden]
		public override bool Equals(object obj)
		{
			return base.Equals(RuntimeHelpers.GetObjectValue(obj));
		}

		[DebuggerHidden]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		[DebuggerHidden]
		[EditorBrowsable(EditorBrowsableState.Never)]
		internal Type method_0()
		{
			return typeof(Class5);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerHidden]
		public override string ToString()
		{
			return base.ToString();
		}

		[DebuggerHidden]
		private static Aa4H3k1S0x1QI5x0D6 smethod_0<Aa4H3k1S0x1QI5x0D6>(Aa4H3k1S0x1QI5x0D6 kTZDKewfYgUpYWa4yi) where Aa4H3k1S0x1QI5x0D6 : new()
		{
			if (kTZDKewfYgUpYWa4yi == null)
			{
				return new Aa4H3k1S0x1QI5x0D6();
			}
			return kTZDKewfYgUpYWa4yi;
		}

		[DebuggerHidden]
		private void method_1<Hh3keWykLqgStPlPmT>(ref Hh3keWykLqgStPlPmT gparam_0)
		{
			gparam_0 = default(Hh3keWykLqgStPlPmT);
		}

		[DebuggerHidden]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public Class5()
		{
			Class14.QwnfEIbzxvDCI();
			base._002Ector();
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[ComVisible(false)]
	internal sealed class Class6<HssqD7uAs4FFtYbkEL> where HssqD7uAs4FFtYbkEL : new()
	{
		[CompilerGenerated]
		[ThreadStatic]
		private static HssqD7uAs4FFtYbkEL gparam_0;

		[SpecialName]
		[DebuggerHidden]
		internal HssqD7uAs4FFtYbkEL method_0()
		{
			if (gparam_0 == null)
			{
				gparam_0 = new HssqD7uAs4FFtYbkEL();
			}
			return gparam_0;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerHidden]
		public Class6()
		{
			Class14.QwnfEIbzxvDCI();
			base._002Ector();
		}
	}

	private static readonly Class6<Class2> KmuUhgsay;

	private static readonly Class6<Class1> class6_0;

	private static readonly Class6<User> class6_1;

	private static Class6<Class4> class6_2;

	private static readonly Class6<Class5> class6_3;

	[HelpKeyword("My.Computer")]
	internal static Class2 Class2_0
	{
		[DebuggerHidden]
		get
		{
			return KmuUhgsay.method_0();
		}
	}

	[HelpKeyword("My.Application")]
	internal static Class1 Class1_0
	{
		[DebuggerHidden]
		get
		{
			return class6_0.method_0();
		}
	}

	[HelpKeyword("My.User")]
	internal static User paFacHeqY
	{
		[DebuggerHidden]
		get
		{
			return class6_1.method_0();
		}
	}

	[HelpKeyword("My.Forms")]
	internal static Class4 Class4_0
	{
		[DebuggerHidden]
		get
		{
			return class6_2.method_0();
		}
	}

	[HelpKeyword("My.WebServices")]
	internal static Class5 Class5_0
	{
		[DebuggerHidden]
		get
		{
			return class6_3.method_0();
		}
	}

	static Class3()
	{
		Class14.QwnfEIbzxvDCI();
		KmuUhgsay = new Class6<Class2>();
		class6_0 = new Class6<Class1>();
		class6_1 = new Class6<User>();
		class6_2 = new Class6<Class4>();
		class6_3 = new Class6<Class5>();
	}
}
