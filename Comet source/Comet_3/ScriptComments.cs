using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Net;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Markup;
using Comet_3.UserControls;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;

namespace Comet_3
{
	public class ScriptComments : Window, IComponentConnector
	{
		private WebClient webclient = new WebClient();

		private string scriptbloxid = "";

		internal Grid TopBar;

		internal Button ExitB;

		internal WrapPanel ScriptCommentsHolder;

		private bool _contentLoaded;

		private void SendCommentPanel(string pfp, string isverified, string name, string like, string dislike, string text)
		{
			Comment comment = new Comment(pfp, isverified, name, like, dislike, text);
			((Panel)ScriptCommentsHolder).get_Children().Add((UIElement)(object)comment);
		}

		public ScriptComments(string id)
			: this()
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Expected O, but got Unknown
			InitializeComponent();
			scriptbloxid = id;
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			((Panel)ScriptCommentsHolder).get_Children().Clear();
			dynamic val = JsonConvert.DeserializeObject(webclient.DownloadString("https://scriptblox.com/api/comment/" + scriptbloxid + "?page=1&max=100"));
			try
			{
				foreach (dynamic item in val.result.comments)
				{
					if (_003C_003Eo__4._003C_003Ep__5 == null)
					{
						_003C_003Eo__4._003C_003Ep__5 = CallSite<Func<CallSite, string, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, (ExpressionType)0, typeof(ScriptComments), new CSharpArgumentInfo[2]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
						}));
					}
					this.SendCommentPanel((dynamic)_003C_003Eo__4._003C_003Ep__5.Target((CallSite)(object)_003C_003Eo__4._003C_003Ep__5, "https://scriptblox.com", (object)item.commentBy.profilePicture.ToString()), item.commentBy.verified.ToString(), item.commentBy.username.ToString(), item.likeCount.ToString(), item.dislikeCount.ToString(), item.text.ToString());
				}
			}
			catch
			{
			}
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

		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0021: Expected O, but got Unknown
			if (!_contentLoaded)
			{
				_contentLoaded = true;
				Uri val = new Uri("/Comet 3;component/scriptcomments.xaml", (UriKind)2);
				Application.LoadComponent((object)this, val);
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			//IL_003a: Expected O, but got Unknown
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			//IL_004a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0054: Expected O, but got Unknown
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
			//IL_0063: Expected O, but got Unknown
			//IL_0067: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Expected O, but got Unknown
			//IL_007e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0088: Expected O, but got Unknown
			//IL_008d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0097: Expected O, but got Unknown
			switch (connectionId)
			{
			case 1:
				((FrameworkElement)(ScriptComments)target).add_Loaded(new RoutedEventHandler(Window_Loaded));
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
				ScriptCommentsHolder = (WrapPanel)target;
				break;
			default:
				_contentLoaded = true;
				break;
			}
		}
	}
}
