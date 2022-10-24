using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Threading;
using Comet_3.Classes.DLL;
using Comet_3.UserControls;
using Newtonsoft.Json;

namespace Comet_3
{
	public class Scripts : Window, IComponentConnector
	{
		private WebClient webclient = new WebClient();

		private string searchstring = "";

		private int pagenum = 1;

		private Tools tools = new Tools();

		internal Grid TopBar;

		internal Button ExitB;

		internal Button MinimizeB;

		internal Grid MenuSystem;

		internal Label PageLabel;

		internal Button InjectB;

		internal Button RefreshB;

		internal Button SearchButton;

		internal TextBox GameSearchBox;

		internal WrapPanel ScriptsHolder;

		internal Label ScriptBloxLabel;

		internal Button PageLeftB;

		internal Button PageRightB;

		private bool _contentLoaded;

		private void SendJSONGamePanel(string image, string title, string script, string scriptbloxid)
		{
			GameSquare gameSquare = new GameSquare(image, title, script, scriptbloxid);
			((Panel)ScriptsHolder).get_Children().Add((UIElement)(object)gameSquare);
		}

		public Scripts()
			: this()
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Expected O, but got Unknown
			InitializeComponent();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			pagenum = 1;
			SetGamePanel();
		}

		private void SetGamePanel()
		{
			new Thread((ThreadStart)delegate
			{
				//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
				if (searchstring == "")
				{
					searchstring = "a";
				}
				((DispatcherObject)this).get_Dispatcher().Invoke((Action)delegate
				{
					((Panel)ScriptsHolder).get_Children().Clear();
				});
				object obj = JsonConvert.DeserializeObject(webclient.DownloadString("https://scriptblox.com/api/script/search?q=" + searchstring + "&mode=free&max=18&page=" + pagenum));
				try
				{
					foreach (dynamic item in ((dynamic)obj).result.scripts)
					{
						((DispatcherObject)this).get_Dispatcher().Invoke((Action)delegate
						{
							this.SendJSONGamePanel(item.game.imageUrl.ToString(), item.title.ToString(), item.script.ToString(), item._id.ToString());
						});
					}
				}
				catch
				{
					MessageBox.Show("The Page Limit has been reached.", "Comet");
					pagenum--;
				}
				((DispatcherObject)this).get_Dispatcher().Invoke((Action)delegate
				{
					((ContentControl)PageLabel).set_Content((object)("Page: " + pagenum));
				});
				GC.Collect(2, GCCollectionMode.Forced);
			}).Start();
		}

		private void ExitB_Click(object sender, RoutedEventArgs e)
		{
			((Window)this).Close();
		}

		private void MinimizeB_Click(object sender, RoutedEventArgs e)
		{
			((Window)this).set_WindowState((WindowState)1);
		}

		private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			((Window)this).DragMove();
		}

		private void SearchButton_Click(object sender, RoutedEventArgs e)
		{
			searchstring = GameSearchBox.get_Text();
			pagenum = 1;
			SetGamePanel();
		}

		private void GameSearchBox_KeyDown(object sender, KeyEventArgs e)
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0008: Invalid comparison between Unknown and I4
			if ((int)e.get_Key() == 6)
			{
				searchstring = GameSearchBox.get_Text();
				pagenum = 1;
				SetGamePanel();
			}
		}

		private void PageLeftB_Click(object sender, RoutedEventArgs e)
		{
			//IL_0013: Unknown result type (might be due to invalid IL or missing references)
			if (pagenum < 1)
			{
				MessageBox.Show("You cannot go back any further.");
				return;
			}
			pagenum--;
			SetGamePanel();
		}

		private void PageRightB_Click(object sender, RoutedEventArgs e)
		{
			pagenum++;
			SetGamePanel();
		}

		private void ScriptBloxLabel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			Process.Start("https://scriptblox.com/");
		}

		private void InjectB_Click(object sender, RoutedEventArgs e)
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

		private void RefreshB_Click(object sender, RoutedEventArgs e)
		{
			GameSearchBox.set_Text("");
			searchstring = "a";
			pagenum = 1;
			SetGamePanel();
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
				Uri val = new Uri("/Comet 3;component/scripts.xaml", (UriKind)2);
				Application.LoadComponent((object)this, val);
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			//IL_005b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Expected O, but got Unknown
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0078: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Expected O, but got Unknown
			//IL_008a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0094: Expected O, but got Unknown
			//IL_009b: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a5: Expected O, but got Unknown
			//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bc: Expected O, but got Unknown
			//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ce: Expected O, but got Unknown
			//IL_00db: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e5: Expected O, but got Unknown
			//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f7: Expected O, but got Unknown
			//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_0108: Expected O, but got Unknown
			//IL_010f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0119: Expected O, but got Unknown
			//IL_0126: Unknown result type (might be due to invalid IL or missing references)
			//IL_0130: Expected O, but got Unknown
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			//IL_0142: Expected O, but got Unknown
			//IL_014f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0159: Expected O, but got Unknown
			//IL_0161: Unknown result type (might be due to invalid IL or missing references)
			//IL_016b: Expected O, but got Unknown
			//IL_0178: Unknown result type (might be due to invalid IL or missing references)
			//IL_0182: Expected O, but got Unknown
			//IL_018a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0194: Expected O, but got Unknown
			//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ab: Expected O, but got Unknown
			//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bd: Expected O, but got Unknown
			//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cb: Expected O, but got Unknown
			//IL_01d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e2: Expected O, but got Unknown
			//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f1: Expected O, but got Unknown
			//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_0208: Expected O, but got Unknown
			//IL_020d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0217: Expected O, but got Unknown
			//IL_0224: Unknown result type (might be due to invalid IL or missing references)
			//IL_022e: Expected O, but got Unknown
			switch (connectionId)
			{
			case 1:
				((FrameworkElement)(Scripts)target).add_Loaded(new RoutedEventHandler(Window_Loaded));
				break;
			case 2:
				((UIElement)(Border)target).add_MouseLeftButtonDown(new MouseButtonEventHandler(Border_MouseLeftButtonDown));
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
				MenuSystem = (Grid)target;
				break;
			case 7:
				PageLabel = (Label)target;
				break;
			case 8:
				InjectB = (Button)target;
				((ButtonBase)InjectB).add_Click(new RoutedEventHandler(InjectB_Click));
				break;
			case 9:
				RefreshB = (Button)target;
				((ButtonBase)RefreshB).add_Click(new RoutedEventHandler(RefreshB_Click));
				break;
			case 10:
				SearchButton = (Button)target;
				((ButtonBase)SearchButton).add_Click(new RoutedEventHandler(SearchButton_Click));
				break;
			case 11:
				GameSearchBox = (TextBox)target;
				((UIElement)GameSearchBox).add_KeyDown(new KeyEventHandler(GameSearchBox_KeyDown));
				break;
			case 12:
				ScriptsHolder = (WrapPanel)target;
				break;
			case 13:
				ScriptBloxLabel = (Label)target;
				((UIElement)ScriptBloxLabel).add_MouseLeftButtonDown(new MouseButtonEventHandler(ScriptBloxLabel_MouseLeftButtonDown));
				break;
			case 14:
				PageLeftB = (Button)target;
				((ButtonBase)PageLeftB).add_Click(new RoutedEventHandler(PageLeftB_Click));
				break;
			case 15:
				PageRightB = (Button)target;
				((ButtonBase)PageRightB).add_Click(new RoutedEventHandler(PageRightB_Click));
				break;
			default:
				_contentLoaded = true;
				break;
			}
		}
	}
}
