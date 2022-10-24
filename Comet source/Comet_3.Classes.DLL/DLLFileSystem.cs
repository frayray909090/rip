using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Comet_3.Classes.DLL
{
	internal class DLLFileSystem
	{
		public static string DLLFolder = "C:\\Users\\" + Environment.UserName + "\\AppData\\Local\\" + HWID() + "\\";

		public static string DLLPath = DLLFolder + HWID() + ".dll";

		[DllImport("bin/CometAuth.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool Verify([MarshalAs(UnmanagedType.LPStr)] string key);

		[DllImport("bin/CometAuth.dll", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.BStr)]
		public static extern string HWID();

		public static void CreateDLLFolder()
		{
			if (!Directory.Exists(DLLFolder))
			{
				Directory.CreateDirectory(DLLFolder);
			}
		}
	}
}
