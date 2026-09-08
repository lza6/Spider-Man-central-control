using System;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

internal class Class11
{
	internal class Attribute0 : Attribute
	{
		internal class Class12<limtNW0bPSF2ICv6cK>
		{
			public Class12()
			{
				Class14.QwnfEIbzxvDCI();
				base._002Ector();
			}
		}

		[Attribute0(typeof(Class12<object>[]))]
		public Attribute0(object object_0)
		{
			Class14.QwnfEIbzxvDCI();
			base._002Ector();
		}
	}

	internal class Class13
	{
		[Attribute0(typeof(Attribute0.Class12<object>[]))]
		internal static void ce4DmfsmSrOT856tDgfrkMb()
		{
			if (smethod_0(Convert.ToBase64String(assembly_0.GetName().GetPublicKeyToken()), " ") != "  ")
			{
				while (true)
				{
					ce4DmfsmSrOT856tDgfrkMb();
				}
			}
		}

		[Attribute0(typeof(Attribute0.Class12<object>[]))]
		internal static string smethod_0(string string_0, string string_1)
		{
			byte[] bytes = Encoding.Unicode.GetBytes(string_0);
			byte[] array = bytes;
			byte[] key = new byte[32]
			{
				82, 102, 104, 110, 32, 77, 24, 34, 118, 181,
				51, 17, 18, 51, 12, 109, 10, 32, 77, 24,
				34, 158, 161, 41, 97, 28, 118, 181, 5, 25,
				1, 88
			};
			byte[] iV = smethod_9(Encoding.Unicode.GetBytes(string_1));
			MemoryStream memoryStream = new MemoryStream();
			SymmetricAlgorithm symmetricAlgorithm = smethod_7();
			symmetricAlgorithm.Key = key;
			symmetricAlgorithm.IV = iV;
			CryptoStream cryptoStream = new CryptoStream(memoryStream, symmetricAlgorithm.CreateEncryptor(), CryptoStreamMode.Write);
			cryptoStream.Write(array, 0, array.Length);
			cryptoStream.Close();
			return Convert.ToBase64String(memoryStream.ToArray());
		}

		public Class13()
		{
			Class14.QwnfEIbzxvDCI();
			base._002Ector();
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	internal delegate uint Delegate8(IntPtr classthis, IntPtr comp, IntPtr info, [MarshalAs(UnmanagedType.U4)] uint flags, IntPtr nativeEntry, ref uint nativeSizeOfCode);

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private delegate IntPtr Delegate9();

	internal struct Struct1
	{
		internal bool bool_0;

		internal byte[] byte_0;
	}

	[Flags]
	private enum Enum0
	{

	}

	private static byte[] byte_0;

	private static byte[] byte_1;

	private static bool bool_0;

	private static int int_0;

	private static long long_0;

	internal static Delegate8 delegate8_0;

	[Attribute0(typeof(Attribute0.Class12<object>[]))]
	private static bool bool_1;

	private static uint[] uint_0;

	private static string[] string_0;

	private static IntPtr intptr_0;

	private static bool bool_2;

	private static int int_1;

	private static IntPtr intptr_1;

	private static SortedList sortedList_0;

	private static bool bool_3;

	private static bool bool_4;

	private static bool bool_5;

	private static int int_2;

	private static byte[] byte_2;

	private static Assembly assembly_0;

	private static byte[] byte_3;

	private static IntPtr intptr_2;

	private static int int_3;

	internal static Hashtable hashtable_0;

	internal static Delegate8 delegate8_1;

	private static int[] int_4;

	private static bool bool_6;

	private static long long_1;

	static Class11()
	{
		bool_6 = false;
		assembly_0 = typeof(Class11).Assembly;
		uint_0 = new uint[64]
		{
			3614090360u, 3905402710u, 606105819u, 3250441966u, 4118548399u, 1200080426u, 2821735955u, 4249261313u, 1770035416u, 2336552879u,
			4294925233u, 2304563134u, 1804603682u, 4254626195u, 2792965006u, 1236535329u, 4129170786u, 3225465664u, 643717713u, 3921069994u,
			3593408605u, 38016083u, 3634488961u, 3889429448u, 568446438u, 3275163606u, 4107603335u, 1163531501u, 2850285829u, 4243563512u,
			1735328473u, 2368359562u, 4294588738u, 2272392833u, 1839030562u, 4259657740u, 2763975236u, 1272893353u, 4139469664u, 3200236656u,
			681279174u, 3936430074u, 3572445317u, 76029189u, 3654602809u, 3873151461u, 530742520u, 3299628645u, 4096336452u, 1126891415u,
			2878612391u, 4237533241u, 1700485571u, 2399980690u, 4293915773u, 2240044497u, 1873313359u, 4264355552u, 2734768916u, 1309151649u,
			4149444226u, 3174756917u, 718787259u, 3951481745u
		};
		bool_4 = false;
		bool_3 = false;
		byte_0 = new byte[0];
		byte_2 = new byte[0];
		byte_1 = new byte[0];
		byte_3 = new byte[0];
		intptr_1 = IntPtr.Zero;
		intptr_2 = IntPtr.Zero;
		string_0 = new string[0];
		int_4 = new int[0];
		int_3 = 1;
		bool_0 = false;
		sortedList_0 = new SortedList();
		int_0 = 0;
		long_0 = 0L;
		delegate8_0 = null;
		delegate8_1 = null;
		long_1 = 0L;
		int_1 = 0;
		bool_5 = false;
		bool_2 = false;
		int_2 = 0;
		intptr_0 = IntPtr.Zero;
		bool_1 = false;
		hashtable_0 = new Hashtable();
		try
		{
			RSACryptoServiceProvider.UseMachineKeyStore = true;
		}
		catch
		{
		}
	}

	private void DGUfEIbwCECj1()
	{
	}

	internal static byte[] smethod_0(byte[] byte_4)
	{
		uint[] array = new uint[16];
		int num = 448 - byte_4.Length * 8 % 512;
		uint num2 = (uint)((num + 512) % 512);
		if (num2 == 0)
		{
			num2 = 512u;
		}
		uint num3 = (uint)(byte_4.Length + num2 / 8 + 8L);
		ulong num4 = (ulong)(byte_4.Length * 8L);
		byte[] array2 = new byte[num3];
		for (int i = 0; i < byte_4.Length; i++)
		{
			array2[i] = byte_4[i];
		}
		array2[byte_4.Length] |= 128;
		for (int num5 = 8; num5 > 0; num5--)
		{
			array2[num3 - num5] = (byte)((num4 >> (8 - num5) * 8) & 0xFFL);
		}
		uint num6 = (uint)(array2.Length * 8) / 32u;
		uint uint_ = 1732584193u;
		uint uint_2 = 4023233417u;
		uint uint_3 = 2562383102u;
		uint uint_4 = 271733878u;
		for (uint num7 = 0u; num7 < num6 / 16; num7++)
		{
			uint num8 = num7 << 6;
			for (uint num9 = 0u; num9 < 61; num9 += 4)
			{
				array[num9 >> 2] = (uint)((array2[num8 + (num9 + 3)] << 24) | (array2[num8 + (num9 + 2)] << 16) | (array2[num8 + (num9 + 1)] << 8) | array2[num8 + num9]);
			}
			uint num10 = uint_;
			uint num11 = uint_2;
			uint num12 = uint_3;
			uint num13 = uint_4;
			smethod_1(ref uint_, uint_2, uint_3, uint_4, 0u, 7, 1u, array);
			smethod_1(ref uint_4, uint_, uint_2, uint_3, 1u, 12, 2u, array);
			smethod_1(ref uint_3, uint_4, uint_, uint_2, 2u, 17, 3u, array);
			smethod_1(ref uint_2, uint_3, uint_4, uint_, 3u, 22, 4u, array);
			smethod_1(ref uint_, uint_2, uint_3, uint_4, 4u, 7, 5u, array);
			smethod_1(ref uint_4, uint_, uint_2, uint_3, 5u, 12, 6u, array);
			smethod_1(ref uint_3, uint_4, uint_, uint_2, 6u, 17, 7u, array);
			smethod_1(ref uint_2, uint_3, uint_4, uint_, 7u, 22, 8u, array);
			smethod_1(ref uint_, uint_2, uint_3, uint_4, 8u, 7, 9u, array);
			smethod_1(ref uint_4, uint_, uint_2, uint_3, 9u, 12, 10u, array);
			smethod_1(ref uint_3, uint_4, uint_, uint_2, 10u, 17, 11u, array);
			smethod_1(ref uint_2, uint_3, uint_4, uint_, 11u, 22, 12u, array);
			smethod_1(ref uint_, uint_2, uint_3, uint_4, 12u, 7, 13u, array);
			smethod_1(ref uint_4, uint_, uint_2, uint_3, 13u, 12, 14u, array);
			smethod_1(ref uint_3, uint_4, uint_, uint_2, 14u, 17, 15u, array);
			smethod_1(ref uint_2, uint_3, uint_4, uint_, 15u, 22, 16u, array);
			smethod_2(ref uint_, uint_2, uint_3, uint_4, 1u, 5, 17u, array);
			smethod_2(ref uint_4, uint_, uint_2, uint_3, 6u, 9, 18u, array);
			smethod_2(ref uint_3, uint_4, uint_, uint_2, 11u, 14, 19u, array);
			smethod_2(ref uint_2, uint_3, uint_4, uint_, 0u, 20, 20u, array);
			smethod_2(ref uint_, uint_2, uint_3, uint_4, 5u, 5, 21u, array);
			smethod_2(ref uint_4, uint_, uint_2, uint_3, 10u, 9, 22u, array);
			smethod_2(ref uint_3, uint_4, uint_, uint_2, 15u, 14, 23u, array);
			smethod_2(ref uint_2, uint_3, uint_4, uint_, 4u, 20, 24u, array);
			smethod_2(ref uint_, uint_2, uint_3, uint_4, 9u, 5, 25u, array);
			smethod_2(ref uint_4, uint_, uint_2, uint_3, 14u, 9, 26u, array);
			smethod_2(ref uint_3, uint_4, uint_, uint_2, 3u, 14, 27u, array);
			smethod_2(ref uint_2, uint_3, uint_4, uint_, 8u, 20, 28u, array);
			smethod_2(ref uint_, uint_2, uint_3, uint_4, 13u, 5, 29u, array);
			smethod_2(ref uint_4, uint_, uint_2, uint_3, 2u, 9, 30u, array);
			smethod_2(ref uint_3, uint_4, uint_, uint_2, 7u, 14, 31u, array);
			smethod_2(ref uint_2, uint_3, uint_4, uint_, 12u, 20, 32u, array);
			smethod_3(ref uint_, uint_2, uint_3, uint_4, 5u, 4, 33u, array);
			smethod_3(ref uint_4, uint_, uint_2, uint_3, 8u, 11, 34u, array);
			smethod_3(ref uint_3, uint_4, uint_, uint_2, 11u, 16, 35u, array);
			smethod_3(ref uint_2, uint_3, uint_4, uint_, 14u, 23, 36u, array);
			smethod_3(ref uint_, uint_2, uint_3, uint_4, 1u, 4, 37u, array);
			smethod_3(ref uint_4, uint_, uint_2, uint_3, 4u, 11, 38u, array);
			smethod_3(ref uint_3, uint_4, uint_, uint_2, 7u, 16, 39u, array);
			smethod_3(ref uint_2, uint_3, uint_4, uint_, 10u, 23, 40u, array);
			smethod_3(ref uint_, uint_2, uint_3, uint_4, 13u, 4, 41u, array);
			smethod_3(ref uint_4, uint_, uint_2, uint_3, 0u, 11, 42u, array);
			smethod_3(ref uint_3, uint_4, uint_, uint_2, 3u, 16, 43u, array);
			smethod_3(ref uint_2, uint_3, uint_4, uint_, 6u, 23, 44u, array);
			smethod_3(ref uint_, uint_2, uint_3, uint_4, 9u, 4, 45u, array);
			smethod_3(ref uint_4, uint_, uint_2, uint_3, 12u, 11, 46u, array);
			smethod_3(ref uint_3, uint_4, uint_, uint_2, 15u, 16, 47u, array);
			smethod_3(ref uint_2, uint_3, uint_4, uint_, 2u, 23, 48u, array);
			smethod_4(ref uint_, uint_2, uint_3, uint_4, 0u, 6, 49u, array);
			smethod_4(ref uint_4, uint_, uint_2, uint_3, 7u, 10, 50u, array);
			smethod_4(ref uint_3, uint_4, uint_, uint_2, 14u, 15, 51u, array);
			smethod_4(ref uint_2, uint_3, uint_4, uint_, 5u, 21, 52u, array);
			smethod_4(ref uint_, uint_2, uint_3, uint_4, 12u, 6, 53u, array);
			smethod_4(ref uint_4, uint_, uint_2, uint_3, 3u, 10, 54u, array);
			smethod_4(ref uint_3, uint_4, uint_, uint_2, 10u, 15, 55u, array);
			smethod_4(ref uint_2, uint_3, uint_4, uint_, 1u, 21, 56u, array);
			smethod_4(ref uint_, uint_2, uint_3, uint_4, 8u, 6, 57u, array);
			smethod_4(ref uint_4, uint_, uint_2, uint_3, 15u, 10, 58u, array);
			smethod_4(ref uint_3, uint_4, uint_, uint_2, 6u, 15, 59u, array);
			smethod_4(ref uint_2, uint_3, uint_4, uint_, 13u, 21, 60u, array);
			smethod_4(ref uint_, uint_2, uint_3, uint_4, 4u, 6, 61u, array);
			smethod_4(ref uint_4, uint_, uint_2, uint_3, 11u, 10, 62u, array);
			smethod_4(ref uint_3, uint_4, uint_, uint_2, 2u, 15, 63u, array);
			smethod_4(ref uint_2, uint_3, uint_4, uint_, 9u, 21, 64u, array);
			uint_ += num10;
			uint_2 += num11;
			uint_3 += num12;
			uint_4 += num13;
		}
		byte[] array3 = new byte[16];
		Array.Copy(BitConverter.GetBytes(uint_), 0, array3, 0, 4);
		Array.Copy(BitConverter.GetBytes(uint_2), 0, array3, 4, 4);
		Array.Copy(BitConverter.GetBytes(uint_3), 0, array3, 8, 4);
		Array.Copy(BitConverter.GetBytes(uint_4), 0, array3, 12, 4);
		return array3;
	}

	private static void smethod_1(ref uint uint_1, uint uint_2, uint uint_3, uint uint_4, uint uint_5, ushort ushort_0, uint uint_6, uint[] uint_7)
	{
		uint_1 = uint_2 + smethod_5(uint_1 + ((uint_2 & uint_3) | (~uint_2 & uint_4)) + uint_7[uint_5] + uint_0[uint_6 - 1], ushort_0);
	}

	private static void smethod_2(ref uint uint_1, uint uint_2, uint uint_3, uint uint_4, uint uint_5, ushort ushort_0, uint uint_6, uint[] uint_7)
	{
		uint_1 = uint_2 + smethod_5(uint_1 + ((uint_2 & uint_4) | (uint_3 & ~uint_4)) + uint_7[uint_5] + uint_0[uint_6 - 1], ushort_0);
	}

	private static void smethod_3(ref uint uint_1, uint uint_2, uint uint_3, uint uint_4, uint uint_5, ushort ushort_0, uint uint_6, uint[] uint_7)
	{
		uint_1 = uint_2 + smethod_5(uint_1 + (uint_2 ^ uint_3 ^ uint_4) + uint_7[uint_5] + uint_0[uint_6 - 1], ushort_0);
	}

	private static void smethod_4(ref uint uint_1, uint uint_2, uint uint_3, uint uint_4, uint uint_5, ushort ushort_0, uint uint_6, uint[] uint_7)
	{
		uint_1 = uint_2 + smethod_5(uint_1 + (uint_3 ^ (uint_2 | ~uint_4)) + uint_7[uint_5] + uint_0[uint_6 - 1], ushort_0);
	}

	private static uint smethod_5(uint uint_1, ushort ushort_0)
	{
		return (uint_1 >> 32 - ushort_0) | (uint_1 << (int)ushort_0);
	}

	internal static bool smethod_6()
	{
		if (!bool_4)
		{
			smethod_8();
			bool_4 = true;
		}
		return bool_3;
	}

	internal static SymmetricAlgorithm smethod_7()
	{
		SymmetricAlgorithm symmetricAlgorithm = null;
		if (smethod_6())
		{
			return new AesCryptoServiceProvider();
		}
		try
		{
			return new RijndaelManaged();
		}
		catch
		{
			return (SymmetricAlgorithm)Activator.CreateInstance("System.Core, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Security.Cryptography.AesCryptoServiceProvider").Unwrap();
		}
	}

	internal static void smethod_8()
	{
		try
		{
			bool_3 = CryptoConfig.AllowOnlyFipsAlgorithms;
		}
		catch
		{
		}
	}

	internal static byte[] smethod_9(byte[] byte_4)
	{
		if (!smethod_6())
		{
			return new MD5CryptoServiceProvider().ComputeHash(byte_4);
		}
		return smethod_0(byte_4);
	}

	private static uint smethod_10(uint uint_1)
	{
		return (uint)"{11111-22222-10009-11112}".Length;
	}

	[Attribute0(typeof(Attribute0.Class12<object>[]))]
	internal static string smethod_11(int int_5)
	{
		if (byte_1.Length == 0)
		{
			BinaryReader binaryReader = new BinaryReader(assembly_0.GetManifestResourceStream("kBofxSUZwPFVAZOrxx.Vmg9jNA8J5vZ4nfKNT"));
			binaryReader.BaseStream.Position = 0L;
			byte[] array = binaryReader.ReadBytes((int)binaryReader.BaseStream.Length);
			binaryReader.Close();
			byte[] array2 = new byte[32];
			array2[0] = 130;
			array2[0] = 88;
			array2[0] = 184;
			array2[1] = 212;
			array2[1] = 87;
			array2[1] = 116;
			array2[1] = 69;
			array2[1] = 77;
			array2[2] = 84;
			array2[2] = 213;
			array2[2] = 142;
			array2[2] = 162;
			array2[2] = 61;
			array2[2] = 42;
			array2[3] = 100;
			array2[3] = 150;
			array2[3] = 152;
			array2[3] = 94;
			array2[4] = 107;
			array2[4] = 100;
			array2[4] = 150;
			array2[4] = 99;
			array2[4] = 114;
			array2[4] = 92;
			array2[5] = 98;
			array2[5] = 103;
			array2[5] = 102;
			array2[5] = 156;
			array2[5] = 169;
			array2[6] = 50;
			array2[6] = 107;
			array2[6] = 200;
			array2[7] = 200;
			array2[7] = 106;
			array2[7] = 40;
			array2[8] = 96;
			array2[8] = 94;
			array2[8] = 156;
			array2[8] = 161;
			array2[8] = 118;
			array2[9] = 197;
			array2[9] = 96;
			array2[9] = 40;
			array2[10] = 110;
			array2[10] = 129;
			array2[10] = 130;
			array2[11] = 164;
			array2[11] = 48;
			array2[11] = 206;
			array2[12] = 145;
			array2[12] = 115;
			array2[12] = 96;
			array2[12] = 16;
			array2[13] = 105;
			array2[13] = 183;
			array2[13] = 139;
			array2[13] = 123;
			array2[13] = 126;
			array2[14] = 146;
			array2[14] = 167;
			array2[14] = 130;
			array2[14] = 97;
			array2[14] = 142;
			array2[14] = 98;
			array2[15] = 127;
			array2[15] = 122;
			array2[15] = 171;
			array2[15] = 35;
			array2[15] = 154;
			array2[15] = 47;
			array2[16] = 74;
			array2[16] = 221;
			array2[16] = 114;
			array2[17] = 126;
			array2[17] = 87;
			array2[17] = 162;
			array2[17] = 148;
			array2[17] = 85;
			array2[17] = 107;
			array2[18] = 166;
			array2[18] = 97;
			array2[18] = 120;
			array2[18] = 138;
			array2[18] = 194;
			array2[19] = 99;
			array2[19] = 134;
			array2[19] = 92;
			array2[19] = 170;
			array2[19] = 153;
			array2[19] = 230;
			array2[20] = 100;
			array2[20] = 209;
			array2[20] = 122;
			array2[21] = 167;
			array2[21] = 112;
			array2[21] = 114;
			array2[21] = 112;
			array2[22] = 108;
			array2[22] = 158;
			array2[22] = 176;
			array2[22] = 115;
			array2[22] = 8;
			array2[23] = 116;
			array2[23] = 113;
			array2[23] = 45;
			array2[23] = 61;
			array2[24] = 117;
			array2[24] = 156;
			array2[24] = 150;
			array2[24] = 89;
			array2[24] = 148;
			array2[24] = 216;
			array2[25] = 118;
			array2[25] = 130;
			array2[25] = 207;
			array2[25] = 37;
			array2[25] = 191;
			array2[26] = 141;
			array2[26] = 150;
			array2[26] = 127;
			array2[26] = 195;
			array2[27] = 126;
			array2[27] = 136;
			array2[27] = 119;
			array2[27] = 115;
			array2[27] = 167;
			array2[28] = 91;
			array2[28] = 153;
			array2[28] = 239;
			array2[29] = 160;
			array2[29] = 132;
			array2[29] = 152;
			array2[29] = 202;
			array2[29] = 25;
			array2[30] = 165;
			array2[30] = 227;
			array2[30] = 117;
			array2[30] = 46;
			array2[31] = 31;
			array2[31] = 160;
			array2[31] = 197;
			array2[31] = 49;
			byte[] array3 = array2;
			byte[] array4 = new byte[16];
			array4[0] = 67;
			array4[0] = 156;
			array4[0] = 157;
			array4[0] = 152;
			array4[0] = 123;
			array4[0] = 201;
			array4[1] = 179;
			array4[1] = 110;
			array4[1] = 90;
			array4[1] = 170;
			array4[1] = 148;
			array4[1] = 140;
			array4[2] = 134;
			array4[2] = 165;
			array4[2] = 140;
			array4[3] = 160;
			array4[3] = 140;
			array4[3] = 11;
			array4[4] = 160;
			array4[4] = 99;
			array4[4] = 89;
			array4[5] = 205;
			array4[5] = 114;
			array4[5] = 89;
			array4[5] = 125;
			array4[5] = 146;
			array4[6] = 104;
			array4[6] = 44;
			array4[6] = 106;
			array4[6] = 191;
			array4[7] = 136;
			array4[7] = 106;
			array4[7] = 137;
			array4[7] = 42;
			array4[7] = 104;
			array4[7] = 13;
			array4[8] = 161;
			array4[8] = 193;
			array4[8] = 231;
			array4[9] = 144;
			array4[9] = 124;
			array4[9] = 46;
			array4[9] = 84;
			array4[9] = 115;
			array4[10] = 30;
			array4[10] = 162;
			array4[10] = 136;
			array4[10] = 146;
			array4[10] = 29;
			array4[10] = 33;
			array4[11] = 85;
			array4[11] = 92;
			array4[11] = 183;
			array4[11] = 130;
			array4[11] = 160;
			array4[11] = 144;
			array4[12] = 115;
			array4[12] = 96;
			array4[12] = 174;
			array4[13] = 97;
			array4[13] = 173;
			array4[13] = 155;
			array4[13] = 89;
			array4[14] = 171;
			array4[14] = 35;
			array4[14] = 51;
			array4[15] = 116;
			array4[15] = 131;
			array4[15] = 165;
			byte[] array5 = array4;
			Array.Reverse(array5);
			byte[] publicKeyToken = assembly_0.GetName().GetPublicKeyToken();
			if (publicKeyToken != null && publicKeyToken.Length > 0)
			{
				array5[1] = publicKeyToken[0];
				array5[3] = publicKeyToken[1];
				array5[5] = publicKeyToken[2];
				array5[7] = publicKeyToken[3];
				array5[9] = publicKeyToken[4];
				array5[11] = publicKeyToken[5];
				array5[13] = publicKeyToken[6];
				array5[15] = publicKeyToken[7];
			}
			for (int i = 0; i < array5.Length; i++)
			{
				array3[i] ^= array5[i];
			}
			if (int_5 == -1)
			{
				SymmetricAlgorithm symmetricAlgorithm = smethod_7();
				symmetricAlgorithm.Mode = CipherMode.CBC;
				ICryptoTransform transform = symmetricAlgorithm.CreateDecryptor(array3, array5);
				MemoryStream memoryStream = new MemoryStream();
				CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
				cryptoStream.Write(array, 0, array.Length);
				cryptoStream.FlushFinalBlock();
				byte_1 = memoryStream.ToArray();
				memoryStream.Close();
				cryptoStream.Close();
				array = byte_1;
			}
			int num = array.Length % 4;
			int num2 = array.Length / 4;
			byte[] array6 = new byte[array.Length];
			int num3 = array3.Length / 4;
			uint num4 = 0u;
			uint num5 = 0u;
			uint num6 = 0u;
			if (num > 0)
			{
				num2++;
			}
			uint num7 = 0u;
			for (int j = 0; j < num2; j++)
			{
				int num8 = j % num3;
				int num9 = j * 4;
				num7 = (uint)(num8 * 4);
				num5 = (uint)((array3[num7 + 3] << 24) | (array3[num7 + 2] << 16) | (array3[num7 + 1] << 8) | array3[num7]);
				uint num10 = 255u;
				int num11 = 0;
				if (j == num2 - 1 && num > 0)
				{
					num6 = 0u;
					num4 += num5;
					for (int k = 0; k < num; k++)
					{
						if (k > 0)
						{
							num6 <<= 8;
						}
						num6 |= array[array.Length - (1 + k)];
					}
				}
				else
				{
					num4 += num5;
					num7 = (uint)num9;
					num6 = (uint)((array[num7 + 3] << 24) | (array[num7 + 2] << 16) | (array[num7 + 1] << 8) | array[num7]);
				}
				uint num12 = num4;
				num4 = 0u;
				uint num13 = num12;
				uint num14 = num12;
				num14 ^= num14 >> 17;
				num14 += 1903853314;
				num14 ^= num14 << 3;
				num14 += 42255;
				num14 ^= num14 >> 4;
				num14 += 3727276609u;
				num14 = 776381937 - num14;
				num12 = num13 + (uint)(double)num14;
				num4 = num12;
				if (j == num2 - 1 && num > 0)
				{
					uint num15 = num4 ^ num6;
					for (int l = 0; l < num; l++)
					{
						if (l > 0)
						{
							num10 <<= 8;
							num11 += 8;
						}
						array6[num9 + l] = (byte)((num15 & num10) >> num11);
					}
				}
				else
				{
					uint num16 = num4 ^ num6;
					array6[num9] = (byte)(num16 & 0xFF);
					array6[num9 + 1] = (byte)((num16 & 0xFF00) >> 8);
					array6[num9 + 2] = (byte)((num16 & 0xFF0000) >> 16);
					array6[num9 + 3] = (byte)((num16 & 0xFF000000u) >> 24);
				}
			}
			byte_1 = array6;
		}
		int count = BitConverter.ToInt32(byte_1, int_5);
		try
		{
			return Encoding.Unicode.GetString(byte_1, int_5 + 4, count);
		}
		catch
		{
		}
		return "";
	}

	[Attribute0(typeof(Attribute0.Class12<object>[]))]
	internal static string smethod_12(string string_1)
	{
		"{11111-22222-50001-00000}".Trim();
		byte[] array = Convert.FromBase64String(string_1);
		return Encoding.Unicode.GetString(array, 0, array.Length);
	}

	private static void smethod_13()
	{
		try
		{
			RSACryptoServiceProvider.UseMachineKeyStore = true;
		}
		catch
		{
		}
	}

	private static Delegate smethod_14(IntPtr intptr_3, Type type_0)
	{
		return (Delegate)typeof(Marshal).GetMethod("GetDelegateForFunctionPointer", new Type[2]
		{
			typeof(IntPtr),
			typeof(Type)
		}).Invoke(null, new object[2] { intptr_3, type_0 });
	}

	internal static object smethod_15(Assembly assembly_1)
	{
		try
		{
			if (File.Exists(assembly_1.Location))
			{
				return assembly_1.Location;
			}
		}
		catch
		{
		}
		try
		{
			if (File.Exists(assembly_1.GetName().CodeBase.ToString().Replace("file:///", "")))
			{
				return assembly_1.GetName().CodeBase.ToString().Replace("file:///", "");
			}
		}
		catch
		{
		}
		try
		{
			if (File.Exists(assembly_1.GetType().GetProperty("Location").GetValue(assembly_1, new object[0])
				.ToString()))
			{
				return assembly_1.GetType().GetProperty("Location").GetValue(assembly_1, new object[0])
					.ToString();
			}
		}
		catch
		{
		}
		return "";
	}

	[Attribute0(typeof(Attribute0.Class12<object>[]))]
	private static byte[] smethod_16(string string_1)
	{
		using FileStream fileStream = new FileStream(string_1, FileMode.Open, FileAccess.Read, FileShare.Read);
		int num = 0;
		long length = fileStream.Length;
		int num2 = (int)length;
		byte[] array = new byte[num2];
		while (num2 > 0)
		{
			int num3 = fileStream.Read(array, num, num2);
			num += num3;
			num2 -= num3;
		}
		return array;
	}

	[Attribute0(typeof(Attribute0.Class12<object>[]))]
	private static byte[] dkxfimXnwB(byte[] byte_4)
	{
		MemoryStream memoryStream = new MemoryStream();
		SymmetricAlgorithm symmetricAlgorithm = smethod_7();
		symmetricAlgorithm.Key = new byte[32]
		{
			237, 42, 103, 227, 91, 16, 128, 127, 6, 206,
			212, 36, 79, 44, 141, 237, 2, 132, 215, 247,
			209, 247, 199, 172, 52, 64, 132, 69, 89, 151,
			109, 5
		};
		symmetricAlgorithm.IV = new byte[16]
		{
			154, 134, 212, 95, 36, 60, 169, 159, 29, 203,
			190, 95, 82, 61, 244, 49
		};
		CryptoStream cryptoStream = new CryptoStream(memoryStream, symmetricAlgorithm.CreateDecryptor(), CryptoStreamMode.Write);
		cryptoStream.Write(byte_4, 0, byte_4.Length);
		cryptoStream.Close();
		return memoryStream.ToArray();
	}

	private byte[] method_0()
	{
		return null;
	}

	private byte[] method_1()
	{
		return null;
	}

	private byte[] method_2()
	{
		string text = "{11111-22222-20001-00001}";
		if (text.Length > 0)
		{
			return new byte[2] { 1, 2 };
		}
		return new byte[2] { 1, 2 };
	}

	private byte[] method_3()
	{
		string text = "{11111-22222-20001-00002}";
		if (text.Length > 0)
		{
			return new byte[2] { 1, 2 };
		}
		return new byte[2] { 1, 2 };
	}

	private byte[] method_4()
	{
		string text = "{11111-22222-30001-00001}";
		if (text.Length > 0)
		{
			return new byte[2] { 1, 2 };
		}
		return new byte[2] { 1, 2 };
	}

	private byte[] method_5()
	{
		string text = "{11111-22222-30001-00002}";
		if (text.Length > 0)
		{
			return new byte[2] { 1, 2 };
		}
		return new byte[2] { 1, 2 };
	}

	internal byte[] wiMfmdVjas()
	{
		string text = "{11111-22222-40001-00001}";
		if (text.Length > 0)
		{
			return new byte[2] { 1, 2 };
		}
		return new byte[2] { 1, 2 };
	}

	internal byte[] method_6()
	{
		string text = "{11111-22222-40001-00002}";
		if (text.Length > 0)
		{
			return new byte[2] { 1, 2 };
		}
		return new byte[2] { 1, 2 };
	}

	internal byte[] method_7()
	{
		string text = "{11111-22222-50001-00001}";
		if (text.Length > 0)
		{
			return new byte[2] { 1, 2 };
		}
		return new byte[2] { 1, 2 };
	}

	internal byte[] method_8()
	{
		string text = "{11111-22222-50001-00002}";
		if (text.Length > 0)
		{
			return new byte[2] { 1, 2 };
		}
		return new byte[2] { 1, 2 };
	}
}
