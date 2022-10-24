using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Microsoft.Win32;
using Newtonsoft.Json;

namespace Comet_3
{
	public class KeySystem : Window, IComponentConnector
	{
		private RegistryKey RegistrySettings = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Supercomet3");

		private dynamic CometTheme = JsonConvert.DeserializeObject(File.ReadAllText("./bin/theme.COMET主题系统"));

		private DispatcherTimer RGBTime;

		private int RGBSpinSpeed = 5;

		private Storyboard StoryBoard = new Storyboard();

		private TimeSpan duration = TimeSpan.FromMilliseconds(500.0);

		private TimeSpan duration2 = TimeSpan.FromMilliseconds(1000.0);

		internal Border MainBorder;

		internal Grid TopBar;

		internal Button ExitB;

		internal Button MinimizeB;

		internal RotateTransform rgbRotation;

		internal GradientStop SG1;

		internal GradientStop SG2;

		internal Label UsernameLabel;

		internal Label InformationText;

		internal ImageBrush ProfileImage;

		internal TextBox KeyBox;

		internal Button GetKeyB;

		internal Button ApproveKeyB;

		internal Button SupportB;

		internal Button TrashB;

		internal Label EULAText;

		internal Label DeveloperText;

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

		public void ObjectShift(DependencyObject Object, Thickness Get, Thickness Set)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_0013: Unknown result type (might be due to invalid IL or missing references)
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Unknown result type (might be due to invalid IL or missing references)
			//IL_0040: Expected O, but got Unknown
			//IL_004e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0058: Expected O, but got Unknown
			ThicknessAnimation val = new ThicknessAnimation();
			val.set_From((Thickness?)Get);
			val.set_To((Thickness?)Set);
			((Timeline)val).set_Duration(Duration.op_Implicit(duration2));
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

		public KeySystem()
		{
			//IL_0032: Unknown result type (might be due to invalid IL or missing references)
			//IL_003c: Expected O, but got Unknown
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0077: Expected O, but got Unknown
			//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b7: Expected O, but got Unknown
			//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0494: Unknown result type (might be due to invalid IL or missing references)
			//IL_050f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0519: Expected O, but got Unknown
			//IL_0514: Unknown result type (might be due to invalid IL or missing references)
			//IL_051e: Expected O, but got Unknown
			QuarticEase val = new QuarticEase();
			((EasingFunctionBase)val).set_EasingMode((EasingMode)2);
			Smooth = (IEasingFunction)val;
			((Window)this)._002Ector();
			InitializeComponent();
			RGBTime = new DispatcherTimer(TimeSpan.FromMilliseconds(10.0), (DispatcherPriority)9, (EventHandler)delegate
			{
				RotateTransform obj2 = rgbRotation;
				obj2.set_Angle(obj2.get_Angle() + (double)RGBSpinSpeed);
			}, ((DispatcherObject)Application.get_Current()).get_Dispatcher());
			RGBTime.Start();
			SG1.set_Color((Color)ColorConverter.ConvertFromString(CometTheme.Theme[0].Color1.ToString()));
			SG2.set_Color((Color)ColorConverter.ConvertFromString(CometTheme.Theme[0].Color2.ToString()));
			((ContentControl)UsernameLabel).set_Content((object)("Hello " + (string)RegistrySettings.GetValue("ProfileName") + "!"));
			if ((string)RegistrySettings.GetValue("ProfilePicture") != "")
			{
				try
				{
					ProfileImage.set_ImageSource((ImageSource)new BitmapImage(new Uri((string)RegistrySettings.GetValue("ProfilePicture"))));
				}
				catch
				{
				}
			}
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
		}

		private void ExitB_Click(object sender, RoutedEventArgs e)
		{
			Application.get_Current().Shutdown();
		}

		private void MinimizeB_Click(object sender, RoutedEventArgs e)
		{
			((Window)this).set_WindowState((WindowState)1);
		}

		private void MainBorder_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			try
			{
				((Window)this).DragMove();
			}
			catch
			{
			}
		}

		private void GetKeyB_Click(object sender, RoutedEventArgs e)
		{
			//IL_0088: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
			try
			{
				((ContentControl)InformationText).set_Content((object)"When you get the key, paste it in the box below.");
				Process.Start("https://cometrbx.xyz/ks/start.php?HWID=" + HWID());
			}
			catch (Exception ex)
			{
				((ContentControl)InformationText).set_Content((object)"Key System Error!");
				if (ex.ToString().Contains("An attempt was made to load a program with an incorrect") || ex.ToString().Contains("BadImageFormatException"))
				{
					Process.Start("https://aka.ms/vs/16/release/vc_redist.x86.exe");
					Process.Start("https://aka.ms/vs/16/release/vc_redist.x64.exe");
					MessageBox.Show("Your system is missing the C/C++ redistributions.\nThe link to both of them were started.\nPlease download both of them.\nIf there is an option for repair, select that. If not, continue with a normal installation.\nOnce both are installed, restart your computer.", "Error");
				}
				else
				{
					MessageBox.Show("Get key error!\n" + ex.ToString());
				}
			}
		}

		private async void ApproveKeyB_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				if (Verify(KeyBox.get_Text()))
				{
					((ContentControl)InformationText).set_Content((object)"Valid! (This Key will last a day)");
					await Task.Delay(2000);
					FadeOut((DependencyObject)(object)MainBorder);
					await Task.Delay(1000);
					((Window)new Executor()).Show();
					((Window)this).Close();
				}
				else
				{
					((ContentControl)InformationText).set_Content((object)"This key is invalid.");
					MessageBox.Show("Invalid Key, didn't mean this to be? Please ask people in our discord server.");
				}
			}
			catch (Exception ex)
			{
				Exception eb = ex;
				if (eb.ToString().Contains("An attempt was made to load a program with an incorrect") || eb.ToString().Contains("BadImageFormatException"))
				{
					Process.Start("https://aka.ms/vs/16/release/vc_redist.x86.exe");
					Process.Start("https://aka.ms/vs/16/release/vc_redist.x64.exe");
					MessageBox.Show("Your system is missing the C/C++ redistributions.\nThe link to both of them were started.\nPlease download both of them.\nIf there is an option for repair, select that. If not, continue with a normal installation.\nOnce both are installed, restart your computer.", "Error");
				}
				else
				{
					MessageBox.Show("Verify key error!\n" + eb.ToString());
				}
			}
		}

		private void SupportB_Click(object sender, RoutedEventArgs e)
		{
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			string text = HttpGet("https://cometrbx.xyz/external-files/discord.txt");
			try
			{
				Process.Start(text);
			}
			catch
			{
				Clipboard.SetText(text);
				MessageBox.Show("The link has been copied to your clipboard, go to your web browser search bar and do CTRL+V.", "Comet");
			}
		}

		private void TrashB_Click(object sender, RoutedEventArgs e)
		{
			KeyBox.set_Text("");
		}

		private void EULAText_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			Process.Start("https://cometrbx.xyz/eula.html");
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
				Uri val = new Uri("/Comet 3;component/keysystem.xaml", (UriKind)2);
				Application.LoadComponent((object)this, val);
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			//IL_0067: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Expected O, but got Unknown
			//IL_0079: Unknown result type (might be due to invalid IL or missing references)
			//IL_0083: Expected O, but got Unknown
			//IL_0090: Unknown result type (might be due to invalid IL or missing references)
			//IL_009a: Expected O, but got Unknown
			//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ac: Expected O, but got Unknown
			//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bd: Expected O, but got Unknown
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d4: Expected O, but got Unknown
			//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e6: Expected O, but got Unknown
			//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fd: Expected O, but got Unknown
			//IL_0105: Unknown result type (might be due to invalid IL or missing references)
			//IL_010f: Expected O, but got Unknown
			//IL_0116: Unknown result type (might be due to invalid IL or missing references)
			//IL_0120: Expected O, but got Unknown
			//IL_0127: Unknown result type (might be due to invalid IL or missing references)
			//IL_0131: Expected O, but got Unknown
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			//IL_0142: Expected O, but got Unknown
			//IL_0149: Unknown result type (might be due to invalid IL or missing references)
			//IL_0153: Expected O, but got Unknown
			//IL_015a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0164: Expected O, but got Unknown
			//IL_016b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0175: Expected O, but got Unknown
			//IL_017c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Expected O, but got Unknown
			//IL_0193: Unknown result type (might be due to invalid IL or missing references)
			//IL_019d: Expected O, but got Unknown
			//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01af: Expected O, but got Unknown
			//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c6: Expected O, but got Unknown
			//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d8: Expected O, but got Unknown
			//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ef: Expected O, but got Unknown
			//IL_01f4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fe: Expected O, but got Unknown
			//IL_020b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0215: Expected O, but got Unknown
			//IL_021a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0224: Expected O, but got Unknown
			//IL_0231: Unknown result type (might be due to invalid IL or missing references)
			//IL_023b: Expected O, but got Unknown
			//IL_0240: Unknown result type (might be due to invalid IL or missing references)
			//IL_024a: Expected O, but got Unknown
			switch (connectionId)
			{
			case 1:
				((FrameworkElement)(KeySystem)target).add_Loaded(new RoutedEventHandler(Window_Loaded));
				break;
			case 2:
				MainBorder = (Border)target;
				((UIElement)MainBorder).add_MouseLeftButtonDown(new MouseButtonEventHandler(MainBorder_MouseLeftButtonDown));
				break;
			case 3:
				TopBar = (Grid)target;
				break;
			case 4:
				ExitB = (Button)target;
				((ButtonBase)ExitB).add_Click(new RoutedEventHandler(ExitB_Click));
				break;
			case 5:
				MinimizeB = (Button)target;
				((ButtonBase)MinimizeB).add_Click(new RoutedEventHandler(MinimizeB_Click));
				break;
			case 6:
				rgbRotation = (RotateTransform)target;
				break;
			case 7:
				SG1 = (GradientStop)target;
				break;
			case 8:
				SG2 = (GradientStop)target;
				break;
			case 9:
				UsernameLabel = (Label)target;
				break;
			case 10:
				InformationText = (Label)target;
				break;
			case 11:
				ProfileImage = (ImageBrush)target;
				break;
			case 12:
				KeyBox = (TextBox)target;
				break;
			case 13:
				GetKeyB = (Button)target;
				((ButtonBase)GetKeyB).add_Click(new RoutedEventHandler(GetKeyB_Click));
				break;
			case 14:
				ApproveKeyB = (Button)target;
				((ButtonBase)ApproveKeyB).add_Click(new RoutedEventHandler(ApproveKeyB_Click));
				break;
			case 15:
				SupportB = (Button)target;
				((ButtonBase)SupportB).add_Click(new RoutedEventHandler(SupportB_Click));
				break;
			case 16:
				TrashB = (Button)target;
				((ButtonBase)TrashB).add_Click(new RoutedEventHandler(TrashB_Click));
				break;
			case 17:
				EULAText = (Label)target;
				((UIElement)EULAText).add_MouseLeftButtonDown(new MouseButtonEventHandler(EULAText_MouseLeftButtonDown));
				break;
			case 18:
				DeveloperText = (Label)target;
				break;
			default:
				_contentLoaded = true;
				break;
			}
		}
	}
}
