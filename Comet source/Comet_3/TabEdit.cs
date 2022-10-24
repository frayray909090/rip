using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;

namespace Comet_3
{
	public class TabEdit : Window, IComponentConnector
	{
		private TabControl tabs;

		private TabItem tab;

		internal Button Rename;

		internal Button Close;

		private bool _contentLoaded;

		public TabEdit(TabControl tabs)
			: this()
		{
			InitializeComponent();
			this.tabs = tabs;
			((Window)this).set_Topmost(true);
			((Window)this).add_Deactivated((EventHandler)delegate
			{
				((Window)this).Hide();
			});
		}

		public void Show(TabItem tab)
		{
			this.tab = tab;
			((Window)this).Show();
		}

		private void Rename_Click(object sender, RoutedEventArgs e)
		{
			((Window)this).Hide();
			object header = ((HeaderedContentControl)tab).get_Header();
			TextBox val = header as TextBox;
			((UIElement)val).set_IsEnabled(true);
			((UIElement)val).Focus();
			((TextBoxBase)val).SelectAll();
		}

		private void Close_Click(object sender, RoutedEventArgs e)
		{
			((Window)this).Hide();
			((ItemsControl)tabs).get_Items().Remove((object)tab);
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
				Uri val = new Uri("/Comet 3;component/tabedit.xaml", (UriKind)2);
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
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Expected O, but got Unknown
			//IL_0039: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Expected O, but got Unknown
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			//IL_005a: Expected O, but got Unknown
			switch (connectionId)
			{
			case 1:
				Rename = (Button)target;
				((ButtonBase)Rename).add_Click(new RoutedEventHandler(Rename_Click));
				break;
			case 2:
				Close = (Button)target;
				((ButtonBase)Close).add_Click(new RoutedEventHandler(Close_Click));
				break;
			default:
				_contentLoaded = true;
				break;
			}
		}
	}
}
