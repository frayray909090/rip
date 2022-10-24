using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq.Expressions;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using Comet_3.Classes.DLL;
using Microsoft.CSharp.RuntimeBinder;
using Microsoft.Win32;
using Newtonsoft.Json;
using WMPLib;

namespace Comet_3
{
	public class Startup : Window, IComponentConnector
	{
		private WebClient webClient = new WebClient();

		private DispatcherTimer RGBTime;

		private int RGBSpinSpeed = 4;

		private RegistryKey RegistrySettings = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Supercomet3");

		private dynamic CometJSON = JsonConvert.DeserializeObject(HttpGet("https://cometrbx.xyz/external-files/CometJSONAPI.json"));

		private dynamic RBJSON = JsonConvert.DeserializeObject(HttpGet("https://clientsettingscdn.roblox.com/v2/client-version/WindowsPlayer"));

		private Storyboard StoryBoard = new Storyboard();

		private TimeSpan duration = TimeSpan.FromMilliseconds(500.0);

		private TimeSpan duration2 = TimeSpan.FromMilliseconds(1000.0);

		internal Border MainBorder;

		internal Border SpinningBorder;

		internal RotateTransform rgbRotation;

		internal GradientStop BSG1;

		internal GradientStop BSG2;

		internal Border SpinningBorder2;

		internal RotateTransform rgbRotation2;

		internal GradientStop FSG1;

		internal GradientStop FSG2;

		internal Grid LogoGrid;

		internal Image I1;

		internal Image I2;

		internal Image I3;

		private bool _contentLoaded;

		private IEasingFunction Smooth
		{
			get;
			set;
		}

		[DllImport("bin/CometAuth.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool Verify([MarshalAs(UnmanagedType.LPStr)] string key);

		[DllImport("bin/CometAuth.dll", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.BStr)]
		public static extern string HWID();

		public static string HttpGet(string url)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0007: Expected O, but got Unknown
			WebClient val = new WebClient();
			try
			{
				val.get_Headers().Add((HttpRequestHeader)40, "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
				return val.DownloadString(url);
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}

		public void Fade(DependencyObject Object)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			//IL_0037: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Expected O, but got Unknown
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_006a: Expected O, but got Unknown
			DoubleAnimation val = new DoubleAnimation();
			val.set_From((double?)0.0);
			val.set_To((double?)1.0);
			((Timeline)val).set_Duration(new Duration(duration));
			DoubleAnimation val2 = val;
			Storyboard.SetTarget((DependencyObject)(object)val2, Object);
			Storyboard.SetTargetProperty((DependencyObject)(object)val2, new PropertyPath("Opacity", new object[1]
			{
				1
			}));
			((TimelineGroup)StoryBoard).get_Children().Add((Timeline)(object)val2);
			StoryBoard.Begin();
			((TimelineGroup)StoryBoard).get_Children().Remove((Timeline)(object)val2);
		}

		public void FadeOut(DependencyObject Object)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			//IL_0037: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Expected O, but got Unknown
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_006a: Expected O, but got Unknown
			DoubleAnimation val = new DoubleAnimation();
			val.set_From((double?)1.0);
			val.set_To((double?)0.0);
			((Timeline)val).set_Duration(new Duration(duration));
			DoubleAnimation val2 = val;
			Storyboard.SetTarget((DependencyObject)(object)val2, Object);
			Storyboard.SetTargetProperty((DependencyObject)(object)val2, new PropertyPath("Opacity", new object[1]
			{
				1
			}));
			((TimelineGroup)StoryBoard).get_Children().Add((Timeline)(object)val2);
			StoryBoard.Begin();
			((TimelineGroup)StoryBoard).get_Children().Remove((Timeline)(object)val2);
		}

		public void ObjectShift(Duration speed, DependencyObject Object, Thickness Get, Thickness Set)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_0013: Unknown result type (might be due to invalid IL or missing references)
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0022: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Unknown result type (might be due to invalid IL or missing references)
			//IL_0037: Expected O, but got Unknown
			//IL_0045: Unknown result type (might be due to invalid IL or missing references)
			//IL_004f: Expected O, but got Unknown
			ThicknessAnimation val = new ThicknessAnimation();
			val.set_From((Thickness?)Get);
			val.set_To((Thickness?)Set);
			((Timeline)val).set_Duration(speed);
			val.set_EasingFunction(Smooth);
			ThicknessAnimation val2 = val;
			Storyboard.SetTarget((DependencyObject)(object)val2, Object);
			Storyboard.SetTargetProperty((DependencyObject)(object)val2, new PropertyPath((object)FrameworkElement.MarginProperty));
			((TimelineGroup)StoryBoard).get_Children().Add((Timeline)(object)val2);
			StoryBoard.Begin();
			((TimelineGroup)StoryBoard).get_Children().Remove((Timeline)(object)val2);
		}

		public void FasterObjectShift(DependencyObject Object, Thickness Get, Thickness Set)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_0013: Unknown result type (might be due to invalid IL or missing references)
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			//IL_003a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0048: Expected O, but got Unknown
			//IL_0056: Unknown result type (might be due to invalid IL or missing references)
			//IL_0060: Expected O, but got Unknown
			ThicknessAnimation val = new ThicknessAnimation();
			val.set_From((Thickness?)Get);
			val.set_To((Thickness?)Set);
			((Timeline)val).set_Duration(Duration.op_Implicit(TimeSpan.FromMilliseconds(750.0)));
			val.set_EasingFunction(Smooth);
			ThicknessAnimation val2 = val;
			Storyboard.SetTarget((DependencyObject)(object)val2, Object);
			Storyboard.SetTargetProperty((DependencyObject)(object)val2, new PropertyPath((object)FrameworkElement.MarginProperty));
			((TimelineGroup)StoryBoard).get_Children().Add((Timeline)(object)val2);
			StoryBoard.Begin();
			((TimelineGroup)StoryBoard).get_Children().Remove((Timeline)(object)val2);
		}

		public Startup()
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Expected O, but got Unknown
			//IL_0052: Unknown result type (might be due to invalid IL or missing references)
			//IL_005c: Expected O, but got Unknown
			//IL_0085: Unknown result type (might be due to invalid IL or missing references)
			//IL_008a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0097: Expected O, but got Unknown
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00dd: Expected O, but got Unknown
			//IL_047a: Unknown result type (might be due to invalid IL or missing references)
			//IL_04c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_04f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_050e: Unknown result type (might be due to invalid IL or missing references)
			QuarticEase val = new QuarticEase();
			((EasingFunctionBase)val).set_EasingMode((EasingMode)2);
			Smooth = (IEasingFunction)val;
			((Window)this)._002Ector();
			InitializeComponent();
			DLLFileSystem.CreateDLLFolder();
			RGBTime = new DispatcherTimer(TimeSpan.FromMilliseconds(10.0), (DispatcherPriority)9, (EventHandler)delegate
			{
				RotateTransform obj = rgbRotation;
				obj.set_Angle(obj.get_Angle() + (double)RGBSpinSpeed);
				RotateTransform obj2 = rgbRotation2;
				obj2.set_Angle(obj2.get_Angle() + (double)RGBSpinSpeed);
			}, ((DispatcherObject)Application.get_Current()).get_Dispatcher());
			RGBTime.Start();
			string text = "HKEY_CURRENT_USER\\Software\\Supercomet3";
			if (Registry.GetValue(text, "SetupCompletion", (object)null) == null)
			{
				RegistrySettings.SetValue("SetupCompletion", (object)"false");
			}
			if (Registry.GetValue(text, "ProfilePicture", (object)null) == null)
			{
				RegistrySettings.SetValue("ProfilePicture", (object)"");
			}
			if (Registry.GetValue(text, "ProfileName", (object)null) == null)
			{
				RegistrySettings.SetValue("ProfileName", (object)"CometUser");
			}
			if (Registry.GetValue(text, "topmost", (object)null) == null)
			{
				RegistrySettings.SetValue("topmost", (object)"true");
			}
			if (Registry.GetValue(text, "PatchCheck", (object)null) == null)
			{
				RegistrySettings.SetValue("PatchCheck", (object)"false");
			}
			if (Registry.GetValue(text, "RBVersion", (object)null) == null)
			{
				RegistrySettings.SetValue("RBVersion", RBJSON.clientVersionUpload.ToString());
			}
			if (Registry.GetValue(text, "DLLVersion", (object)null) == null)
			{
				RegistrySettings.SetValue("DLLVersion", CometJSON.DLLVer.ToString());
			}
			if (Registry.GetValue(text, "IsPatched", (object)null) == null)
			{
				RegistrySettings.SetValue("IsPatched", (object)"false");
			}
			((UIElement)MainBorder).set_Opacity(0.0);
			((FrameworkElement)MainBorder).set_Margin(new Thickness(250.0, 300.0, 250.0, 300.0));
			((UIElement)LogoGrid).set_Opacity(0.0);
			((FrameworkElement)I1).set_Margin(new Thickness(50.0, -50.0, -50.0, 50.0));
			((FrameworkElement)I3).set_Margin(new Thickness(-50.0, 50.0, 50.0, -50.0));
			MessageBox.Show("Hi, this is an ALPHA Version of Comet 3 meaning that this version of Comet 3 is very incomplete. We will provide more updates in the future. \n- Supercomet Technology", "彗星3");
		}

		private async void Window_Loaded(object sender, RoutedEventArgs e)
		{
			if (!File.Exists("./bin/theme.COMET主题系统"))
			{
				webClient.DownloadFileAsync(new Uri("https://cometrbx.xyz/external-files/theme.COMET%E4%B8%BB%E9%A2%98%E7%B3%BB%E7%BB%9F"), "./bin/theme.COMET主题系统");
				while (webClient.get_IsBusy())
				{
					await Task.Delay(1000);
				}
			}
			dynamic CometTheme = JsonConvert.DeserializeObject(File.ReadAllText("./bin/theme.COMET主题系统"));
			BSG1.set_Color((Color)ColorConverter.ConvertFromString(CometTheme.Theme[0].Color1.ToString()));
			FSG1.set_Color((Color)ColorConverter.ConvertFromString(CometTheme.Theme[0].Color1.ToString()));
			BSG2.set_Color((Color)ColorConverter.ConvertFromString(CometTheme.Theme[0].Color2.ToString()));
			FSG2.set_Color((Color)ColorConverter.ConvertFromString(CometTheme.Theme[0].Color2.ToString()));
			RGBSpinSpeed = 10;
			try
			{
				if (_003C_003Eo__21._003C_003Ep__28 == null)
				{
					_003C_003Eo__21._003C_003Ep__28 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, (ExpressionType)83, typeof(Startup), new CSharpArgumentInfo[1]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
					}));
				}
				Func<CallSite, object, bool> target = _003C_003Eo__21._003C_003Ep__28.Target;
				CallSite<Func<CallSite, object, bool>> _003C_003Ep__ = _003C_003Eo__21._003C_003Ep__28;
				if (_003C_003Eo__21._003C_003Ep__27 == null)
				{
					_003C_003Eo__21._003C_003Ep__27 = CallSite<Func<CallSite, object, object>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, (ExpressionType)34, typeof(Startup), new CSharpArgumentInfo[1]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
					}));
				}
				if (target((CallSite)(object)_003C_003Ep__, _003C_003Eo__21._003C_003Ep__27.Target((CallSite)(object)_003C_003Eo__21._003C_003Ep__27, (object)CometJSON.UIVer.ToString().Contains("3.0.0.0.7 Alpha"))))
				{
					MessageBox.Show("I'm sorry, this version of Comet 3 Alpha is outdated, please download the new one on WeAreDevs.");
					Process.Start("https://wearedevs.net/d/Comet");
					Process.GetCurrentProcess().Kill();
				}
				if (!File.Exists("./bin/CometAuth.dll"))
				{
					webClient.DownloadFileAsync(new Uri(CometJSON.CometAuthDLLInstall.ToString()), "./bin/CometAuth.dll");
					while (webClient.get_IsBusy())
					{
						await Task.Delay(1000);
					}
				}
				if (!Directory.Exists("./scripts"))
				{
					Directory.CreateDirectory("./scripts");
				}
				webClient.DownloadFileAsync(new Uri(CometJSON.DLLInstall.ToString()), DLLFileSystem.DLLPath);
				while (webClient.get_IsBusy())
				{
					await Task.Delay(1000);
				}
			}
			catch (Exception ex2)
			{
				MessageBox.Show(ex2.ToString());
			}
			try
			{
				if (_003C_003Eo__21._003C_003Ep__38 == null)
				{
					_003C_003Eo__21._003C_003Ep__38 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, (ExpressionType)83, typeof(Startup), new CSharpArgumentInfo[1]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
					}));
				}
				Func<CallSite, object, bool> target2 = _003C_003Eo__21._003C_003Ep__38.Target;
				CallSite<Func<CallSite, object, bool>> _003C_003Ep__2 = _003C_003Eo__21._003C_003Ep__38;
				if (_003C_003Eo__21._003C_003Ep__37 == null)
				{
					_003C_003Eo__21._003C_003Ep__37 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, (ExpressionType)35, typeof(Startup), new CSharpArgumentInfo[2]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
					}));
				}
				if (target2((CallSite)(object)_003C_003Ep__2, _003C_003Eo__21._003C_003Ep__37.Target((CallSite)(object)_003C_003Eo__21._003C_003Ep__37, (object)RBJSON.clientVersionUpload.ToString(), (string)RegistrySettings.GetValue("RBVersion"))))
				{
					RegistrySettings.SetValue("IsPatched", (object)"true");
					RegistrySettings.SetValue("RBVersion", RBJSON.clientVersionUpload.ToString());
				}
				if ((string)RegistrySettings.GetValue("IsPatched") == "true")
				{
					if (_003C_003Eo__21._003C_003Ep__45 == null)
					{
						_003C_003Eo__21._003C_003Ep__45 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, (ExpressionType)83, typeof(Startup), new CSharpArgumentInfo[1]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
						}));
					}
					Func<CallSite, object, bool> target3 = _003C_003Eo__21._003C_003Ep__45.Target;
					CallSite<Func<CallSite, object, bool>> _003C_003Ep__3 = _003C_003Eo__21._003C_003Ep__45;
					if (_003C_003Eo__21._003C_003Ep__44 == null)
					{
						_003C_003Eo__21._003C_003Ep__44 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, (ExpressionType)35, typeof(Startup), new CSharpArgumentInfo[2]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
						}));
					}
					if (target3((CallSite)(object)_003C_003Ep__3, _003C_003Eo__21._003C_003Ep__44.Target((CallSite)(object)_003C_003Eo__21._003C_003Ep__44, (object)CometJSON.DLLVer.ToString(), (string)RegistrySettings.GetValue("DLLVersion"))))
					{
						RegistrySettings.SetValue("DLLVersion", CometJSON.DLLVer.ToString());
						RegistrySettings.SetValue("IsPatched", (object)"false");
					}
					else if ((string)RegistrySettings.GetValue("PatchCheck") == "true")
					{
						MessageBox.Show("Hello, we are sorry to infrom you that Comet 3 may not work, as it may be PATCHED. Please do not complain if Comet 3 cannot Inject properly. (this is a guess from an Automated Guess-Check System)", "Comet 3 - Patch Guess Check");
					}
				}
			}
			catch
			{
			}
			Fade((DependencyObject)(object)MainBorder);
			try
			{
				WindowsMediaPlayer wplayer = (WindowsMediaPlayer)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("6BF52A52-394A-11D3-B153-00C04F79FAA6")));
				wplayer.URL = "./bin/intro.mp3";
				wplayer.settings.volume = 35;
				wplayer.controls.play();
			}
			catch
			{
			}
			await Task.Delay(2000);
			RGBSpinSpeed = 5;
			ObjectShift(Duration.op_Implicit(TimeSpan.FromMilliseconds(1200.0)), (DependencyObject)(object)MainBorder, ((FrameworkElement)MainBorder).get_Margin(), new Thickness(100.0));
			await Task.Delay(500);
			Fade((DependencyObject)(object)LogoGrid);
			ObjectShift(Duration.op_Implicit(TimeSpan.FromMilliseconds(1200.0)), (DependencyObject)(object)I1, ((FrameworkElement)I1).get_Margin(), new Thickness(0.0, 0.0, 0.0, 0.0));
			ObjectShift(Duration.op_Implicit(TimeSpan.FromMilliseconds(1200.0)), (DependencyObject)(object)I3, ((FrameworkElement)I3).get_Margin(), new Thickness(0.0, 0.0, 0.0, 0.0));
			File.WriteAllText(DLLFileSystem.DLLFolder + "ui.txt", Directory.GetCurrentDirectory());
			await Task.Delay(2000);
			FadeOut((DependencyObject)(object)MainBorder);
			await Task.Delay(1000);
			if ((string)RegistrySettings.GetValue("SetupCompletion") == "true")
			{
				if (Verify(HWID()))
				{
					((Window)new Executor()).Show();
				}
				else
				{
					((Window)new KeySystem()).Show();
				}
				((Window)this).Close();
			}
			else
			{
				((Window)new Setup()).Show();
				((Window)this).Close();
			}
		}

		private void MainBorder_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			((Window)this).DragMove();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0021: Expected O, but got Unknown
			if (!_contentLoaded)
			{
				_contentLoaded = true;
				Uri val = new Uri("/Comet 3;component/startup.xaml", (UriKind)2);
				Application.LoadComponent((object)this, val);
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			//IL_0057: Unknown result type (might be due to invalid IL or missing references)
			//IL_0061: Expected O, but got Unknown
			//IL_0069: Unknown result type (might be due to invalid IL or missing references)
			//IL_0073: Expected O, but got Unknown
			//IL_0080: Unknown result type (might be due to invalid IL or missing references)
			//IL_008a: Expected O, but got Unknown
			//IL_0092: Unknown result type (might be due to invalid IL or missing references)
			//IL_009c: Expected O, but got Unknown
			//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ad: Expected O, but got Unknown
			//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00be: Expected O, but got Unknown
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cf: Expected O, but got Unknown
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00dd: Expected O, but got Unknown
			//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00eb: Expected O, but got Unknown
			//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f9: Expected O, but got Unknown
			//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Expected O, but got Unknown
			//IL_010b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Expected O, but got Unknown
			//IL_0119: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Expected O, but got Unknown
			//IL_0127: Unknown result type (might be due to invalid IL or missing references)
			//IL_0131: Expected O, but got Unknown
			//IL_0135: Unknown result type (might be due to invalid IL or missing references)
			//IL_013f: Expected O, but got Unknown
			switch (connectionId)
			{
			case 1:
				((FrameworkElement)(Startup)target).add_Loaded(new RoutedEventHandler(Window_Loaded));
				break;
			case 2:
				MainBorder = (Border)target;
				((UIElement)MainBorder).add_MouseLeftButtonDown(new MouseButtonEventHandler(MainBorder_MouseLeftButtonDown));
				break;
			case 3:
				SpinningBorder = (Border)target;
				break;
			case 4:
				rgbRotation = (RotateTransform)target;
				break;
			case 5:
				BSG1 = (GradientStop)target;
				break;
			case 6:
				BSG2 = (GradientStop)target;
				break;
			case 7:
				SpinningBorder2 = (Border)target;
				break;
			case 8:
				rgbRotation2 = (RotateTransform)target;
				break;
			case 9:
				FSG1 = (GradientStop)target;
				break;
			case 10:
				FSG2 = (GradientStop)target;
				break;
			case 11:
				LogoGrid = (Grid)target;
				break;
			case 12:
				I1 = (Image)target;
				break;
			case 13:
				I2 = (Image)target;
				break;
			case 14:
				I3 = (Image)target;
				break;
			default:
				_contentLoaded = true;
				break;
			}
		}
	}
}
