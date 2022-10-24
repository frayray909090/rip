using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;
using System.Windows.Media.Animation;
using Microsoft.Win32;

namespace Comet_3.UserControls
{
	public class SettingsSwitch : UserControl, IComponentConnector
	{
		private RegistryKey RegistrySettings = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Supercomet3");

		internal Label SettingsName;

		internal Button SwitchButton;

		private bool _contentLoaded;

		public SettingsSwitch(string TitleName, string RegistryName)
			: this()
		{
			//IL_0075: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d6: Expected O, but got Unknown
			SettingsSwitch settingsSwitch = this;
			InitializeComponent();
			((ContentControl)SettingsName).set_Content((object)TitleName);
			if ((string)RegistrySettings.GetValue(RegistryName) == "false")
			{
				((Storyboard)((FrameworkElement)this).TryFindResource((object)"ToRed")).Begin();
			}
			else if ((string)RegistrySettings.GetValue(RegistryName) == "true")
			{
				((Storyboard)((FrameworkElement)this).TryFindResource((object)"ToGreen")).Begin();
			}
			((ButtonBase)SwitchButton).add_Click((RoutedEventHandler)delegate
			{
				//IL_0057: Unknown result type (might be due to invalid IL or missing references)
				//IL_0092: Unknown result type (might be due to invalid IL or missing references)
				if ((string)settingsSwitch.RegistrySettings.GetValue(RegistryName) == "false")
				{
					settingsSwitch.RegistrySettings.SetValue(RegistryName, (object)"true");
					((Storyboard)((FrameworkElement)settingsSwitch).TryFindResource((object)"ToGreen")).Begin();
				}
				else
				{
					settingsSwitch.RegistrySettings.SetValue(RegistryName, (object)"false");
					((Storyboard)((FrameworkElement)settingsSwitch).TryFindResource((object)"ToRed")).Begin();
				}
			});
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
				Uri val = new Uri("/Comet 3;component/usercontrols/settingsswitch.xaml", (UriKind)2);
				Application.LoadComponent((object)this, val);
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			//IL_0013: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Expected O, but got Unknown
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_002b: Expected O, but got Unknown
			switch (connectionId)
			{
			case 1:
				SettingsName = (Label)target;
				break;
			case 2:
				SwitchButton = (Button)target;
				break;
			default:
				_contentLoaded = true;
				break;
			}
		}
	}
}
