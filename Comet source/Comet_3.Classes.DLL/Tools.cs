using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;

namespace Comet_3.Classes.DLL
{
	public class Tools
	{
		public enum Result : uint
		{
			Success,
			DLLNotFound,
			OpenProcFail,
			AllocFail,
			LoadLibFail,
			Unknown
		}

		private string pipe = "CometPipe";

		private static readonly IntPtr NULL = (IntPtr)0;

		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern IntPtr OpenProcess(uint access, bool inhert_handle, int pid);

		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, IntPtr dwSize, uint flAllocationType, uint flProtect);

		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern int WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int nSize, int lpNumberOfBytesWritten);

		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern IntPtr GetModuleHandle(string lpModuleName);

		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttribute, IntPtr dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern int CloseHandle(IntPtr hObject);

		[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern bool WaitNamedPipe(string pipe, int timeout = 10);

		public bool Injected()
		{
			return WaitNamedPipe("\\\\.\\pipe\\" + pipe);
		}

		public void Run(string Content)
		{
			//IL_0026: Unknown result type (might be due to invalid IL or missing references)
			//IL_002c: Expected O, but got Unknown
			if (string.IsNullOrWhiteSpace(Content) && string.IsNullOrEmpty(Content))
			{
				return;
			}
			NamedPipeClientStream val = new NamedPipeClientStream(".", pipe, (PipeDirection)3);
			try
			{
				val.Connect();
				using StreamWriter streamWriter = new StreamWriter((Stream)(object)val);
				streamWriter.Write(Content ?? "");
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}

		public bool is_ghost_proc(ProcessModuleCollection a1)
		{
			//IL_0011: Unknown result type (might be due to invalid IL or missing references)
			//IL_0017: Expected O, but got Unknown
			foreach (ProcessModule item in (ReadOnlyCollectionBase)a1)
			{
				ProcessModule val = item;
				string text = val.get_FileName().ToString();
				if (text.Contains("cryptnet") || text.Contains("mswsock") || text.Contains("urlmon") || text.Contains("XInput1_4") || text.Contains("CoreUIComponents"))
				{
					return false;
				}
			}
			return true;
		}

		private Result r_inject(string dll_path)
		{
			Process[] processesByName = Process.GetProcessesByName("RobloxPlayerBeta");
			for (uint num = 0u; num < processesByName.Length; num++)
			{
				Process val = processesByName[num];
				if (!Injected() && !is_ghost_proc(val.get_Modules()))
				{
					IntPtr intPtr = OpenProcess(2035711u, inhert_handle: false, val.get_Id());
					if (intPtr == NULL)
					{
						return Result.OpenProcFail;
					}
					IntPtr intPtr2 = VirtualAllocEx(intPtr, NULL, (IntPtr)(dll_path.Length + 1), 12288u, 64u);
					if (intPtr2 == NULL)
					{
						return Result.AllocFail;
					}
					byte[] bytes = Encoding.ASCII.GetBytes(dll_path);
					int num2 = WriteProcessMemory(intPtr, intPtr2, bytes, dll_path.Length + 1, 0);
					if (num2 == 0 || (long)num2 == 6)
					{
						return Result.Unknown;
					}
					if (CreateRemoteThread(intPtr, NULL, NULL, GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA"), intPtr2, 0u, NULL) == NULL)
					{
						return Result.LoadLibFail;
					}
					CloseHandle(intPtr);
				}
			}
			return Result.Success;
		}

		public Result inject(string path)
		{
			//IL_0037: Unknown result type (might be due to invalid IL or missing references)
			try
			{
				if (!File.Exists(path))
				{
					return Result.DLLNotFound;
				}
				return r_inject(path);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Injection Error\n" + ex.ToString(), "Injection", (MessageBoxButton)0, (MessageBoxImage)16);
			}
			return Result.Unknown;
		}
	}
}
