using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Markup;
using Comet_3.UserControls;
using Microsoft.Win32;

namespace Comet_3
{
	public class Settings : Window, IComponentConnector
	{
		private RegistryKey RegistrySettings = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Supercomet3");

		internal Grid TopBar;

		internal Button ExitB;

		internal Button MinimizeB;

		internal WrapPanel SettingsWrapper;

		private bool _contentLoaded;

		private void InsertSwitch(string TitleName, string RegistryName)
		{
			SettingsSwitch settingsSwitch = new SettingsSwitch(TitleName, RegistryName);
			((Panel)SettingsWrapper).get_Children().Add((UIElement)(object)settingsSwitch);
		}

		public Settings()
			: this()
		{
			InitializeComponent();
			InsertSwitch("TopMost", "topmost");
			InsertSwitch("Guess if Comet is Patched", "PatchCheck");
		}

		private void ExitB_Click(object sender, RoutedEventArgs e)
		{
			RegistrySettings.SetValue("IfSettingsClosed", (object)"true");
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

		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0021: Expected O, but got Unknown
			if (!_contentLoaded)
			{
				_contentLoaded = true;
				Uri val = new Uri("/Comet 3;component/settings.xaml", (UriKind)2);
				Application.LoadComponent((object)this, val);
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			//IL_0027: Unknown result type (might be due to invalid IL or missing references)
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			//IL_003d: Expected O, but got Unknown
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_004c: Expected O, but got Unknown
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			//IL_005a: Expected O, but got Unknown
			//IL_0067: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Expected O, but got Unknown
			//IL_0076: Unknown result type (might be due to invalid IL or missing references)
			//IL_0080: Expected O, but got Unknown
			//IL_008d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0097: Expected O, but got Unknown
			//IL_009c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a6: Expected O, but got Unknown
			switch (connectionId)
			{
			case 1:
				((UIElement)(Border)target).add_MouseLeftButtonDown(new MouseButtonEventHandler(Border_MouseLeftButtonDown));
				break;
			case 2:
				TopBar = (Grid)target;
				break;
			case 3:
				ExitB = (Button)target;
				((ButtonBase)ExitB).add_Click(new RoutedEventHandler(ExitB_Click));
				break;
			case 4:
				MinimizeB = (Button)target;
				((ButtonBase)MinimizeB).add_Click(new RoutedEventHandler(MinimizeB_Click));
				break;
			case 5:
				SettingsWrapper = (WrapPanel)target;
				break;
			default:
				_contentLoaded = true;
				break;
			}
		}
	}
}
