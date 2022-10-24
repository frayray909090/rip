using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;

namespace Comet_3
{
	public class App : Application
	{
		private bool _contentLoaded;

		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_002d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0033: Expected O, but got Unknown
			if (!_contentLoaded)
			{
				_contentLoaded = true;
				((Application)this).set_StartupUri(new Uri("Startup.xaml", (UriKind)2));
				Uri val = new Uri("/Comet 3;component/app.xaml", (UriKind)2);
				Application.LoadComponent((object)this, val);
			}
		}

		[STAThread]
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public static void Main()
		{
			App app = new App();
			app.InitializeComponent();
			((Application)app).Run();
		}

		public App()
			: this()
		{
		}
	}
}
