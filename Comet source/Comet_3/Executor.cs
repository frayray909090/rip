using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml;
using Comet_3.Classes.DLL;
using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;
using ICSharpCode.AvalonEdit.Rendering;
using Microsoft.Win32;
using Newtonsoft.Json;

namespace Comet_3
{
	public class Executor : Window, IComponentConnector
	{
		private DispatcherTimer clock;

		private RegistryKey RegistrySettings = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Supercomet3");

		private dynamic CometTheme = JsonConvert.DeserializeObject(File.ReadAllText("./bin/theme.COMET主题系统"));

		private Storyboard StoryBoard = new Storyboard();

		private TimeSpan duration = TimeSpan.FromMilliseconds(500.0);

		private TimeSpan duration2 = TimeSpan.FromMilliseconds(1000.0);

		private Tools tools = new Tools();

		private readonly TabEdit tabEdit;

		private bool togglehome;

		internal Grid grid;

		internal Button Inject;

		internal Button Execute;

		internal Button Erase;

		internal Border ScriptSearchBorder;

		internal Button ToggleScriptList;

		internal Grid ExecutionBox;

		internal TabControl TabCtrl;

		internal Grid ScriptListBox;

		internal ListBox ScriptList;

		internal TextBox ListBoxSearch;

		internal Ellipse ellipse;

		internal GradientStop SunColor;

		internal Grid TopBar;

		internal MenuItem Menu1;

		internal MenuItem Menu2;

		internal MenuItem Menu3;

		internal Button ExitB;

		internal Button MinimizeB;

		internal Button HomeToggle;

		internal Label WebsiteLabel;

		internal Grid FilePopup;

		internal Button OpenFileMB;

		internal Button SaveFileMB;

		internal Grid EditPopup;

		internal Button CopyTBMB;

		internal Button PasteTBMB;

		internal Grid HomeGrid;

		internal Label TopTime;

		internal Label BottomTime;

		internal Label UsernameLabel;

		internal Button GameB;

		internal ImageBrush ProfileImage;

		internal Button SettingsB;

		internal Button KillROBLOXB;

		internal Button ReInstallROBLOXB;

		internal Button RefreshB;

		internal Button ThemeB;

		private bool _contentLoaded;

		private IEasingFunction Smooth
		{
			get;
			set;
		}

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

		public Executor()
		{
			//IL_002b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Expected O, but got Unknown
			//IL_0069: Unknown result type (might be due to invalid IL or missing references)
			//IL_006e: Unknown result type (might be due to invalid IL or missing references)
			//IL_007b: Expected O, but got Unknown
			//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bb: Expected O, but got Unknown
			//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cd: Expected O, but got Unknown
			//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f3: Expected O, but got Unknown
			//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0106: Expected O, but got Unknown
			//IL_010f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0119: Expected O, but got Unknown
			//IL_0140: Unknown result type (might be due to invalid IL or missing references)
			//IL_014a: Expected O, but got Unknown
			//IL_0164: Unknown result type (might be due to invalid IL or missing references)
			//IL_016e: Expected O, but got Unknown
			QuarticEase val = new QuarticEase();
			((EasingFunctionBase)val).set_EasingMode((EasingMode)2);
			Smooth = (IEasingFunction)val;
			((Window)this)._002Ector();
			InitializeComponent();
			clock = new DispatcherTimer(TimeSpan.FromSeconds(1.0), (DispatcherPriority)9, (EventHandler)delegate
			{
				((ContentControl)TopTime).set_Content((object)DateTime.Now.Hour);
				((ContentControl)BottomTime).set_Content((object)DateTime.Now.Minute);
			}, ((DispatcherObject)Application.get_Current()).get_Dispatcher());
			clock.Start();
			FileSystemWatcher val2 = new FileSystemWatcher();
			val2.set_IncludeSubdirectories(false);
			val2.set_Path(".\\scripts\\");
			val2.add_Created(new FileSystemEventHandler(FileSystemWatcher_Created));
			val2.add_Renamed(new RenamedEventHandler(FileSystemWatcher_Renamed));
			val2.add_Deleted(new FileSystemEventHandler(FileSystemWatcher_Deleted));
			val2.set_EnableRaisingEvents(true);
			tabEdit = new TabEdit(TabCtrl);
			((FrameworkElement)TabCtrl).add_Loaded((RoutedEventHandler)delegate
			{
				//IL_0018: Unknown result type (might be due to invalid IL or missing references)
				//IL_0022: Expected O, but got Unknown
				((ButtonBase)((Control)(object)TabCtrl).GetTemplateChild<Button>("AddTabButton")).add_Click((RoutedEventHandler)delegate
				{
					MakeTab();
				});
			});
			MakeTab("", "Gen Tab");
			((Window)this).add_Closing((CancelEventHandler)delegate
			{
				CloseWindows();
			});
			ApplySettingsChanges();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
		}

		private static T FindVisualChild<T>(DependencyObject parent) where T : DependencyObject
		{
			int num = 0;
			while (num < VisualTreeHelper.GetChildrenCount(parent))
			{
				DependencyObject child = VisualTreeHelper.GetChild(parent, num);
				T result;
				if (child != null && child is T)
				{
					result = (T)(object)child;
				}
				else
				{
					T val = FindVisualChild<T>(child);
					if (val == null)
					{
						num++;
						continue;
					}
					result = val;
				}
				return result;
			}
			return default(T);
		}

		private void CloseWindows()
		{
			((Window)tabEdit).Close();
		}

		private TabItem MakeTab(string text = "", string title = "New Tab")
		{
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Expected O, but got Unknown
			//IL_0063: Unknown result type (might be due to invalid IL or missing references)
			//IL_006a: Expected O, but got Unknown
			//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b5: Expected O, but got Unknown
			//IL_0101: Unknown result type (might be due to invalid IL or missing references)
			//IL_010b: Expected O, but got Unknown
			//IL_0119: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Expected O, but got Unknown
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			//IL_0142: Expected O, but got Unknown
			//IL_0150: Unknown result type (might be due to invalid IL or missing references)
			//IL_015a: Expected O, but got Unknown
			//IL_0168: Unknown result type (might be due to invalid IL or missing references)
			//IL_0172: Expected O, but got Unknown
			bool loaded = false;
			TextEditor val = MakeEditor();
			val.set_Text(text);
			Stream stream = File.OpenRead("./bin/highlighter.xshd");
			XmlTextReader val2 = new XmlTextReader(stream);
			val.set_SyntaxHighlighting(HighlightingLoader.Load((XmlReader)(object)val2, (IHighlightingDefinitionReferenceResolver)(object)HighlightingManager.get_Instance()));
			val.get_TextArea().get_TextView().get_ElementGenerators()
				.Add((VisualLineElementGenerator)(object)new NoShittyTextLag());
			TextBox val3 = new TextBox();
			val3.set_Text(title);
			((UIElement)val3).set_IsHitTestVisible(false);
			((UIElement)val3).set_IsEnabled(false);
			val3.set_TextWrapping((TextWrapping)1);
			_003F val4 = val3;
			object obj = ((FrameworkElement)this).TryFindResource((object)"InvisibleTextBox");
			((FrameworkElement)val4).set_Style(obj as Style);
			TextBox textBox = val3;
			TabItem val5 = new TabItem();
			((ContentControl)val5).set_Content((object)val);
			((UIElement)val5).set_AllowDrop(true);
			_003F val6 = val5;
			object obj2 = ((FrameworkElement)this).TryFindResource((object)"Tab");
			((FrameworkElement)val6).set_Style(obj2 as Style);
			((HeaderedContentControl)val5).set_Header((object)textBox);
			TabItem tab = val5;
			((FrameworkElement)tab).add_Loaded((RoutedEventHandler)delegate
			{
				//IL_0024: Unknown result type (might be due to invalid IL or missing references)
				//IL_002e: Expected O, but got Unknown
				if (!loaded)
				{
					((ButtonBase)((Control)(object)tab).GetTemplateChild<Button>("CloseButton")).add_Click((RoutedEventHandler)delegate
					{
						((ItemsControl)TabCtrl).get_Items().Remove((object)tab);
					});
					loaded = true;
				}
			});
			((UIElement)tab).add_MouseDown((MouseButtonEventHandler)delegate(object sender, MouseButtonEventArgs e)
			{
				//IL_0018: Unknown result type (might be due to invalid IL or missing references)
				//IL_001e: Invalid comparison between Unknown and I4
				//IL_0047: Unknown result type (might be due to invalid IL or missing references)
				//IL_004d: Invalid comparison between Unknown and I4
				//IL_0064: Unknown result type (might be due to invalid IL or missing references)
				//IL_0069: Unknown result type (might be due to invalid IL or missing references)
				//IL_009a: Unknown result type (might be due to invalid IL or missing references)
				//IL_009f: Unknown result type (might be due to invalid IL or missing references)
				if (((RoutedEventArgs)e).get_OriginalSource() is Border)
				{
					if ((int)((MouseEventArgs)e).get_MiddleButton() == 1)
					{
						((ItemsControl)TabCtrl).get_Items().Remove((object)tab);
					}
					else if ((int)((MouseEventArgs)e).get_RightButton() == 1)
					{
						TabEdit obj3 = tabEdit;
						Point position = ((MouseEventArgs)e).GetPosition((IInputElement)null);
						((Window)obj3).set_Left(((Point)(ref position)).get_X() - 12.0 + ((Window)this).get_Left());
						TabEdit obj4 = tabEdit;
						position = ((MouseEventArgs)e).GetPosition((IInputElement)null);
						((Window)obj4).set_Top(((Point)(ref position)).get_Y() - 12.0 + ((Window)this).get_Top());
						tabEdit.Show(tab);
					}
				}
			});
			string oldHeader = title;
			((UIElement)textBox).add_GotFocus((RoutedEventHandler)delegate
			{
				oldHeader = textBox.get_Text();
				textBox.set_CaretIndex(textBox.get_Text().Length - 1);
			});
			((UIElement)textBox).add_KeyDown((KeyEventHandler)delegate(object s, KeyEventArgs e)
			{
				//IL_001c: Unknown result type (might be due to invalid IL or missing references)
				//IL_0021: Unknown result type (might be due to invalid IL or missing references)
				//IL_0022: Unknown result type (might be due to invalid IL or missing references)
				//IL_0024: Invalid comparison between Unknown and I4
				//IL_002e: Unknown result type (might be due to invalid IL or missing references)
				//IL_0031: Invalid comparison between Unknown and I4
				//IL_006d: Unknown result type (might be due to invalid IL or missing references)
				//IL_0085: Unknown result type (might be due to invalid IL or missing references)
				//IL_008a: Unknown result type (might be due to invalid IL or missing references)
				//IL_008c: Unknown result type (might be due to invalid IL or missing references)
				//IL_008f: Invalid comparison between Unknown and I4
				//IL_009b: Unknown result type (might be due to invalid IL or missing references)
				//IL_009f: Invalid comparison between Unknown and I4
				if (textBox.get_Text() == "")
				{
					Key key = e.get_Key();
					if ((int)key != 6)
					{
						if ((int)key != 13)
						{
							return;
						}
						textBox.set_Text(oldHeader);
					}
					textBox.set_Text("New Tab");
					MessageBox.Show("The Tab Name cannot be blank, sorry for inconvince.", "Comet Error");
					((UIElement)textBox).set_IsEnabled(false);
				}
				else
				{
					Key key2 = e.get_Key();
					if ((int)key2 != 6)
					{
						if ((int)key2 != 13)
						{
							return;
						}
						textBox.set_Text(oldHeader);
					}
					((UIElement)textBox).set_IsEnabled(false);
				}
			});
			((UIElement)textBox).add_LostFocus((RoutedEventHandler)delegate
			{
				((UIElement)textBox).set_IsEnabled(false);
			});
			((Selector)TabCtrl).set_SelectedIndex(((ItemsControl)TabCtrl).get_Items().Add((object)tab));
			return tab;
		}

		public static TextEditor MakeEditor()
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Expected O, but got Unknown
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Unknown result type (might be due to invalid IL or missing references)
			//IL_0036: Unknown result type (might be due to invalid IL or missing references)
			//IL_0040: Expected O, but got Unknown
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			//IL_0051: Unknown result type (might be due to invalid IL or missing references)
			//IL_0056: Unknown result type (might be due to invalid IL or missing references)
			//IL_0060: Expected O, but got Unknown
			//IL_0061: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Unknown result type (might be due to invalid IL or missing references)
			//IL_0076: Unknown result type (might be due to invalid IL or missing references)
			//IL_0080: Expected O, but got Unknown
			//IL_0081: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c1: Expected O, but got Unknown
			//IL_00c3: Expected O, but got Unknown
			//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_0104: Expected O, but got Unknown
			TextEditor val = new TextEditor();
			val.set_ShowLineNumbers(true);
			((Control)val).set_Background((Brush)new SolidColorBrush(Color.FromArgb(byte.MaxValue, (byte)25, (byte)25, (byte)25)));
			((Control)val).set_BorderBrush((Brush)new SolidColorBrush(Color.FromRgb((byte)40, (byte)40, (byte)40)));
			((Control)val).set_Foreground((Brush)new SolidColorBrush(Color.FromRgb((byte)235, (byte)235, (byte)235)));
			val.set_LineNumbersForeground((Brush)new SolidColorBrush(Color.FromRgb((byte)150, (byte)150, (byte)150)));
			((FrameworkElement)val).set_Margin(new Thickness(0.0, 4.0, 0.0, 0.0));
			((Control)val).set_FontFamily(new FontFamily("Consolas"));
			TextEditor val2 = val;
			val2.get_Options().set_EnableEmailHyperlinks(false);
			val2.get_Options().set_EnableHyperlinks(false);
			val2.get_Options().set_AllowScrollBelowDocument(true);
			val2.set_ShowLineNumbers(true);
			Stream stream = File.OpenRead("./bin/highlighter.xshd");
			XmlTextReader val3 = new XmlTextReader(stream);
			val2.set_SyntaxHighlighting(HighlightingLoader.Load((XmlReader)(object)val3, (IHighlightingDefinitionReferenceResolver)(object)HighlightingManager.get_Instance()));
			return val2;
		}

		private void ExitB_Click(object sender, RoutedEventArgs e)
		{
			Application.get_Current().Shutdown();
		}

		private void MinimizeB_Click(object sender, RoutedEventArgs e)
		{
			((Window)this).set_WindowState((WindowState)1);
		}

		private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			((Window)this).DragMove();
		}

		private void HomeToggle_Click(object sender, RoutedEventArgs e)
		{
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			togglehome = !togglehome;
			((Storyboard)((FrameworkElement)this).TryFindResource((object)(togglehome ? "Comet2SlideDown" : "Comet2SlideUp"))).Begin();
		}

		private void ToggleScriptList_Click(object sender, RoutedEventArgs e)
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0078: Unknown result type (might be due to invalid IL or missing references)
			//IL_0090: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_0119: Unknown result type (might be due to invalid IL or missing references)
			//IL_0142: Unknown result type (might be due to invalid IL or missing references)
			//IL_015a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0183: Unknown result type (might be due to invalid IL or missing references)
			//IL_019b: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
			if (((FrameworkElement)ScriptListBox).get_Margin() == new Thickness(0.0, 0.0, -165.0, 0.0))
			{
				ObjectShift((DependencyObject)(object)ScriptListBox, ((FrameworkElement)ScriptListBox).get_Margin(), new Thickness(0.0, 0.0, 0.0, 0.0));
				ObjectShift((DependencyObject)(object)ScriptSearchBorder, ((FrameworkElement)ScriptSearchBorder).get_Margin(), new Thickness(0.0, 0.0, 0.0, 0.0));
				ObjectShift((DependencyObject)(object)ExecutionBox, ((FrameworkElement)ExecutionBox).get_Margin(), new Thickness(0.0, 35.0, 142.0, 0.0));
			}
			else
			{
				ObjectShift((DependencyObject)(object)ScriptListBox, ((FrameworkElement)ScriptListBox).get_Margin(), new Thickness(0.0, 0.0, -165.0, 0.0));
				ObjectShift((DependencyObject)(object)ScriptSearchBorder, ((FrameworkElement)ScriptSearchBorder).get_Margin(), new Thickness(107.0, 0.0, 0.0, 0.0));
				ObjectShift((DependencyObject)(object)ExecutionBox, ((FrameworkElement)ExecutionBox).get_Margin(), new Thickness(0.0, 35.0, 0.0, 0.0));
			}
		}

		public void RefreshScriptList()
		{
			((ItemsControl)ScriptList).get_Items().Clear();
			string[] files = Directory.GetFiles(".\\scripts\\");
			foreach (string path in files)
			{
				if (Path.GetFileName(path)!.ToString().ToLower().Contains(ListBoxSearch.get_Text().ToString().ToLower()))
				{
					((ItemsControl)ScriptList).get_Items().Add((object)Path.GetFileName(path));
				}
			}
		}

		public void FileSystemWatcher_Created(object sender, FileSystemEventArgs e)
		{
			((DispatcherObject)this).get_Dispatcher().Invoke((Action)delegate
			{
				RefreshScriptList();
			});
		}

		public void FileSystemWatcher_Renamed(object sender, FileSystemEventArgs e)
		{
			((DispatcherObject)this).get_Dispatcher().Invoke((Action)delegate
			{
				RefreshScriptList();
			});
		}

		public void FileSystemWatcher_Deleted(object sender, FileSystemEventArgs e)
		{
			((DispatcherObject)this).get_Dispatcher().Invoke((Action)delegate
			{
				RefreshScriptList();
			});
		}

		private void ListBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
		{
			RefreshScriptList();
		}

		private void ScriptList_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			try
			{
				if (((Selector)ScriptList).get_SelectedIndex() != -1)
				{
					string str = ".\\scripts\\";
					object selectedItem = ((Selector)ScriptList).get_SelectedItem();
					((DispatcherObject)TabCtrl).get_Dispatcher().BeginInvoke((Delegate)(Action)delegate
					{
						TextEditor val = Executor.FindVisualChild<TextEditor>((DependencyObject)(object)TabCtrl);
						val.set_Text(File.ReadAllText(str + ((selectedItem != null) ? selectedItem.ToString() : null)));
					}, Array.Empty<object>());
				}
			}
			catch
			{
			}
		}

		private void Inject_Click(object sender, RoutedEventArgs e)
		{
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_0056: Unknown result type (might be due to invalid IL or missing references)
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			//IL_0098: Unknown result type (might be due to invalid IL or missing references)
			switch (tools.inject(DLLFileSystem.DLLPath))
			{
			case Tools.Result.DLLNotFound:
				MessageBox.Show("Injection Failed! DLL not found!", "Injection", (MessageBoxButton)0, (MessageBoxImage)16);
				break;
			case Tools.Result.OpenProcFail:
				MessageBox.Show("Injection Failed - OpenProcFail failed!", "Injection", (MessageBoxButton)0, (MessageBoxImage)16);
				break;
			case Tools.Result.AllocFail:
				MessageBox.Show("Injection Failed - AllocFail failed!", "Injection", (MessageBoxButton)0, (MessageBoxImage)16);
				break;
			case Tools.Result.LoadLibFail:
				MessageBox.Show("Injection Failed - LoadLibFail failed!", "Injection", (MessageBoxButton)0, (MessageBoxImage)16);
				break;
			case Tools.Result.Unknown:
				MessageBox.Show("Injection Failed - Unknown!", "Injection", (MessageBoxButton)0, (MessageBoxImage)16);
				break;
			}
		}

		private void Execute_Click(object sender, RoutedEventArgs e)
		{
			//IL_003d: Unknown result type (might be due to invalid IL or missing references)
			TextEditor val = Executor.FindVisualChild<TextEditor>((DependencyObject)(object)TabCtrl);
			if (tools.Injected())
			{
				tools.Run(val.get_Text());
			}
			else
			{
				MessageBox.Show("I'm sorry, but ROBLOX is not injected, sorry for the inconvince.", "Comet Error");
			}
		}

		private void Erase_Click(object sender, RoutedEventArgs e)
		{
			TextEditor val = Executor.FindVisualChild<TextEditor>((DependencyObject)(object)TabCtrl);
			val.set_Text("");
		}

		private void Menu2_Click(object sender, RoutedEventArgs e)
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0078: Unknown result type (might be due to invalid IL or missing references)
			//IL_0090: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
			if (((FrameworkElement)FilePopup).get_Margin() == new Thickness(107.0, -70.0, 0.0, 0.0))
			{
				ObjectShift((DependencyObject)(object)FilePopup, ((FrameworkElement)FilePopup).get_Margin(), new Thickness(107.0, 45.0, 0.0, 0.0));
				ObjectShift((DependencyObject)(object)EditPopup, ((FrameworkElement)EditPopup).get_Margin(), new Thickness(155.0, -70.0, 0.0, 0.0));
			}
			else
			{
				ObjectShift((DependencyObject)(object)FilePopup, ((FrameworkElement)FilePopup).get_Margin(), new Thickness(107.0, -70.0, 0.0, 0.0));
			}
		}

		private void OpenFileMB_Click(object sender, RoutedEventArgs e)
		{
			//IL_000f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Expected O, but got Unknown
			//IL_0052: Unknown result type (might be due to invalid IL or missing references)
			//IL_0058: Invalid comparison between Unknown and I4
			//IL_0093: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
			OpenFileDialog ofd = new OpenFileDialog();
			((FileDialog)ofd).set_Filter("All files (*.*)|*.*");
			((FileDialog)ofd).set_Title("Comet | Open File");
			((FileDialog)ofd).set_InitialDirectory(Application.get_StartupPath());
			if ((int)((CommonDialog)ofd).ShowDialog() == 1)
			{
				((DispatcherObject)TabCtrl).get_Dispatcher().BeginInvoke((Delegate)(Action)delegate
				{
					TextEditor val = Executor.FindVisualChild<TextEditor>((DependencyObject)(object)TabCtrl);
					val.set_Text(File.ReadAllText(((FileDialog)ofd).get_FileName()));
				}, Array.Empty<object>());
			}
			ObjectShift((DependencyObject)(object)FilePopup, ((FrameworkElement)FilePopup).get_Margin(), new Thickness(107.0, -70.0, 0.0, 0.0));
		}

		private void SaveFileMB_Click(object sender, RoutedEventArgs e)
		{
			//IL_000f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Expected O, but got Unknown
			//IL_007b: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
			SaveFileDialog ofd = new SaveFileDialog();
			((FileDialog)ofd).set_Filter("Text File (*.txt)|*.txt|Lua Scripts (*.lua)|*.lua");
			((FileDialog)ofd).set_Title("Comet | Save File");
			((FileDialog)ofd).set_InitialDirectory(Application.get_StartupPath());
			((DispatcherObject)TabCtrl).get_Dispatcher().BeginInvoke((Delegate)(Action)delegate
			{
				//IL_0019: Unknown result type (might be due to invalid IL or missing references)
				//IL_001f: Invalid comparison between Unknown and I4
				TextEditor val = Executor.FindVisualChild<TextEditor>((DependencyObject)(object)TabCtrl);
				if ((int)((CommonDialog)ofd).ShowDialog() == 1)
				{
					File.WriteAllText(((FileDialog)ofd).get_FileName(), val.get_Text());
				}
			}, Array.Empty<object>());
			ObjectShift((DependencyObject)(object)FilePopup, ((FrameworkElement)FilePopup).get_Margin(), new Thickness(107.0, -70.0, 0.0, 0.0));
		}

		private void Menu3_Click(object sender, RoutedEventArgs e)
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0078: Unknown result type (might be due to invalid IL or missing references)
			//IL_0090: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
			if (((FrameworkElement)EditPopup).get_Margin() == new Thickness(155.0, -70.0, 0.0, 0.0))
			{
				ObjectShift((DependencyObject)(object)EditPopup, ((FrameworkElement)EditPopup).get_Margin(), new Thickness(155.0, 45.0, 0.0, 0.0));
				ObjectShift((DependencyObject)(object)FilePopup, ((FrameworkElement)FilePopup).get_Margin(), new Thickness(107.0, -70.0, 0.0, 0.0));
			}
			else
			{
				ObjectShift((DependencyObject)(object)EditPopup, ((FrameworkElement)EditPopup).get_Margin(), new Thickness(155.0, -70.0, 0.0, 0.0));
			}
		}

		private void CopyTBMB_Click(object sender, RoutedEventArgs e)
		{
			//IL_0026: Unknown result type (might be due to invalid IL or missing references)
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			TextEditor val = Executor.FindVisualChild<TextEditor>((DependencyObject)(object)TabCtrl);
			Clipboard.SetText(val.get_Text());
			ObjectShift((DependencyObject)(object)EditPopup, ((FrameworkElement)EditPopup).get_Margin(), new Thickness(155.0, -70.0, 0.0, 0.0));
		}

		private void PasteTBMB_Click(object sender, RoutedEventArgs e)
		{
			//IL_0026: Unknown result type (might be due to invalid IL or missing references)
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			TextEditor val = Executor.FindVisualChild<TextEditor>((DependencyObject)(object)TabCtrl);
			val.set_Text(Clipboard.GetText());
			ObjectShift((DependencyObject)(object)EditPopup, ((FrameworkElement)EditPopup).get_Margin(), new Thickness(155.0, -70.0, 0.0, 0.0));
		}

		private void GameB_Click(object sender, RoutedEventArgs e)
		{
			((Window)new Scripts()).Show();
		}

		private void SettingsB_Click(object sender, RoutedEventArgs e)
		{
			((Window)new Settings()).Show();
		}

		private void ApplySettingsChanges()
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0007: Expected O, but got Unknown
			//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_0dbd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0dc7: Expected O, but got Unknown
			//IL_0dc2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0dcc: Expected O, but got Unknown
			BrushConverter val = new BrushConverter();
			SunColor.set_Color((Color)ColorConverter.ConvertFromString(CometTheme.Theme[0].Color2.ToString()));
			((Control)GameB).set_Background((Brush)val.ConvertFromString(CometTheme.Theme[0].Color1.ToString()));
			((Control)SettingsB).set_Background((Brush)val.ConvertFromString(CometTheme.Theme[0].Color1.ToString()));
			((Control)KillROBLOXB).set_Background((Brush)val.ConvertFromString(CometTheme.Theme[0].Color1.ToString()));
			((Control)ReInstallROBLOXB).set_Background((Brush)val.ConvertFromString(CometTheme.Theme[0].Color1.ToString()));
			((Control)RefreshB).set_Background((Brush)val.ConvertFromString(CometTheme.Theme[0].Color1.ToString()));
			((Control)ThemeB).set_Background((Brush)val.ConvertFromString(CometTheme.Theme[0].Color1.ToString()));
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
			if ((string)RegistrySettings.GetValue("topmost") != "true")
			{
				((Window)this).set_Topmost(false);
			}
			else
			{
				((Window)this).set_Topmost(true);
			}
		}

		private void WebsiteLabel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			try
			{
				Process.Start("https://wearedevs.net");
			}
			catch
			{
			}
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
				Uri val = new Uri("/Comet 3;component/executor.xaml", (UriKind)2);
				Application.LoadComponent((object)this, val);
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c9: Expected O, but got Unknown
			//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e6: Expected O, but got Unknown
			//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f8: Expected O, but got Unknown
			//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_0109: Expected O, but got Unknown
			//IL_0116: Unknown result type (might be due to invalid IL or missing references)
			//IL_0120: Expected O, but got Unknown
			//IL_0128: Unknown result type (might be due to invalid IL or missing references)
			//IL_0132: Expected O, but got Unknown
			//IL_013f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0149: Expected O, but got Unknown
			//IL_0151: Unknown result type (might be due to invalid IL or missing references)
			//IL_015b: Expected O, but got Unknown
			//IL_0168: Unknown result type (might be due to invalid IL or missing references)
			//IL_0172: Expected O, but got Unknown
			//IL_017a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0184: Expected O, but got Unknown
			//IL_018b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0195: Expected O, but got Unknown
			//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ac: Expected O, but got Unknown
			//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01be: Expected O, but got Unknown
			//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cf: Expected O, but got Unknown
			//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e0: Expected O, but got Unknown
			//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f1: Expected O, but got Unknown
			//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_0208: Expected O, but got Unknown
			//IL_0210: Unknown result type (might be due to invalid IL or missing references)
			//IL_021a: Expected O, but got Unknown
			//IL_0227: Unknown result type (might be due to invalid IL or missing references)
			//IL_0231: Expected O, but got Unknown
			//IL_0239: Unknown result type (might be due to invalid IL or missing references)
			//IL_0243: Expected O, but got Unknown
			//IL_024a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0254: Expected O, but got Unknown
			//IL_025b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0265: Expected O, but got Unknown
			//IL_026c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0276: Expected O, but got Unknown
			//IL_027d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0287: Expected O, but got Unknown
			//IL_0294: Unknown result type (might be due to invalid IL or missing references)
			//IL_029e: Expected O, but got Unknown
			//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b0: Expected O, but got Unknown
			//IL_02bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c7: Expected O, but got Unknown
			//IL_02cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d9: Expected O, but got Unknown
			//IL_02e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f0: Expected O, but got Unknown
			//IL_02f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0302: Expected O, but got Unknown
			//IL_030f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0319: Expected O, but got Unknown
			//IL_0321: Unknown result type (might be due to invalid IL or missing references)
			//IL_032b: Expected O, but got Unknown
			//IL_0338: Unknown result type (might be due to invalid IL or missing references)
			//IL_0342: Expected O, but got Unknown
			//IL_034a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0354: Expected O, but got Unknown
			//IL_0361: Unknown result type (might be due to invalid IL or missing references)
			//IL_036b: Expected O, but got Unknown
			//IL_0373: Unknown result type (might be due to invalid IL or missing references)
			//IL_037d: Expected O, but got Unknown
			//IL_0384: Unknown result type (might be due to invalid IL or missing references)
			//IL_038e: Expected O, but got Unknown
			//IL_039b: Unknown result type (might be due to invalid IL or missing references)
			//IL_03a5: Expected O, but got Unknown
			//IL_03ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_03b7: Expected O, but got Unknown
			//IL_03c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ce: Expected O, but got Unknown
			//IL_03d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_03e0: Expected O, but got Unknown
			//IL_03e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_03f1: Expected O, but got Unknown
			//IL_03fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_0408: Expected O, but got Unknown
			//IL_0410: Unknown result type (might be due to invalid IL or missing references)
			//IL_041a: Expected O, but got Unknown
			//IL_0427: Unknown result type (might be due to invalid IL or missing references)
			//IL_0431: Expected O, but got Unknown
			//IL_0439: Unknown result type (might be due to invalid IL or missing references)
			//IL_0443: Expected O, but got Unknown
			//IL_044a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0454: Expected O, but got Unknown
			//IL_045b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0465: Expected O, but got Unknown
			//IL_046c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0476: Expected O, but got Unknown
			//IL_047d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0487: Expected O, but got Unknown
			//IL_0494: Unknown result type (might be due to invalid IL or missing references)
			//IL_049e: Expected O, but got Unknown
			//IL_04a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_04ad: Expected O, but got Unknown
			//IL_04b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_04bb: Expected O, but got Unknown
			//IL_04c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_04d2: Expected O, but got Unknown
			//IL_04d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_04e1: Expected O, but got Unknown
			//IL_04e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_04ef: Expected O, but got Unknown
			//IL_04f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_04fd: Expected O, but got Unknown
			//IL_0501: Unknown result type (might be due to invalid IL or missing references)
			//IL_050b: Expected O, but got Unknown
			switch (connectionId)
			{
			case 1:
				((FrameworkElement)(Executor)target).add_Loaded(new RoutedEventHandler(Window_Loaded));
				break;
			case 2:
				((UIElement)(Border)target).add_MouseLeftButtonDown(new MouseButtonEventHandler(Border_MouseLeftButtonDown));
				break;
			case 3:
				grid = (Grid)target;
				break;
			case 4:
				Inject = (Button)target;
				((ButtonBase)Inject).add_Click(new RoutedEventHandler(Inject_Click));
				break;
			case 5:
				Execute = (Button)target;
				((ButtonBase)Execute).add_Click(new RoutedEventHandler(Execute_Click));
				break;
			case 6:
				Erase = (Button)target;
				((ButtonBase)Erase).add_Click(new RoutedEventHandler(Erase_Click));
				break;
			case 7:
				ScriptSearchBorder = (Border)target;
				break;
			case 8:
				ToggleScriptList = (Button)target;
				((ButtonBase)ToggleScriptList).add_Click(new RoutedEventHandler(ToggleScriptList_Click));
				break;
			case 9:
				ExecutionBox = (Grid)target;
				break;
			case 10:
				TabCtrl = (TabControl)target;
				break;
			case 11:
				ScriptListBox = (Grid)target;
				break;
			case 12:
				ScriptList = (ListBox)target;
				((Selector)ScriptList).add_SelectionChanged(new SelectionChangedEventHandler(ScriptList_SelectionChanged));
				break;
			case 13:
				ListBoxSearch = (TextBox)target;
				((TextBoxBase)ListBoxSearch).add_TextChanged(new TextChangedEventHandler(ListBoxSearch_TextChanged));
				break;
			case 14:
				ellipse = (Ellipse)target;
				break;
			case 15:
				SunColor = (GradientStop)target;
				break;
			case 16:
				TopBar = (Grid)target;
				break;
			case 17:
				Menu1 = (MenuItem)target;
				break;
			case 18:
				Menu2 = (MenuItem)target;
				Menu2.add_Click(new RoutedEventHandler(Menu2_Click));
				break;
			case 19:
				Menu3 = (MenuItem)target;
				Menu3.add_Click(new RoutedEventHandler(Menu3_Click));
				break;
			case 20:
				ExitB = (Button)target;
				((ButtonBase)ExitB).add_Click(new RoutedEventHandler(ExitB_Click));
				break;
			case 21:
				MinimizeB = (Button)target;
				((ButtonBase)MinimizeB).add_Click(new RoutedEventHandler(MinimizeB_Click));
				break;
			case 22:
				HomeToggle = (Button)target;
				((ButtonBase)HomeToggle).add_Click(new RoutedEventHandler(HomeToggle_Click));
				break;
			case 23:
				WebsiteLabel = (Label)target;
				((UIElement)WebsiteLabel).add_MouseLeftButtonDown(new MouseButtonEventHandler(WebsiteLabel_MouseLeftButtonDown));
				break;
			case 24:
				FilePopup = (Grid)target;
				break;
			case 25:
				OpenFileMB = (Button)target;
				((ButtonBase)OpenFileMB).add_Click(new RoutedEventHandler(OpenFileMB_Click));
				break;
			case 26:
				SaveFileMB = (Button)target;
				((ButtonBase)SaveFileMB).add_Click(new RoutedEventHandler(SaveFileMB_Click));
				break;
			case 27:
				EditPopup = (Grid)target;
				break;
			case 28:
				CopyTBMB = (Button)target;
				((ButtonBase)CopyTBMB).add_Click(new RoutedEventHandler(CopyTBMB_Click));
				break;
			case 29:
				PasteTBMB = (Button)target;
				((ButtonBase)PasteTBMB).add_Click(new RoutedEventHandler(PasteTBMB_Click));
				break;
			case 30:
				HomeGrid = (Grid)target;
				break;
			case 31:
				TopTime = (Label)target;
				break;
			case 32:
				BottomTime = (Label)target;
				break;
			case 33:
				UsernameLabel = (Label)target;
				break;
			case 34:
				GameB = (Button)target;
				((ButtonBase)GameB).add_Click(new RoutedEventHandler(GameB_Click));
				break;
			case 35:
				ProfileImage = (ImageBrush)target;
				break;
			case 36:
				SettingsB = (Button)target;
				((ButtonBase)SettingsB).add_Click(new RoutedEventHandler(SettingsB_Click));
				break;
			case 37:
				KillROBLOXB = (Button)target;
				break;
			case 38:
				ReInstallROBLOXB = (Button)target;
				break;
			case 39:
				RefreshB = (Button)target;
				break;
			case 40:
				ThemeB = (Button)target;
				break;
			default:
				_contentLoaded = true;
				break;
			}
		}
	}
}
