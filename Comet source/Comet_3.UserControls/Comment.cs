using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Comet_3.UserControls
{
	public class Comment : UserControl, IComponentConnector
	{
		internal ImageBrush ProfileImage;

		internal Border LikeGroup;

		internal Label LikeCount;

		internal Border DislikeGroup;

		internal Label DislikeCount;

		internal Label VerifiedLabel;

		internal Label Username;

		internal Label Text;

		private bool _contentLoaded;

		public Comment(string pfp, string isverified, string name, string like, string dislike, string text)
			: this()
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_0021: Expected O, but got Unknown
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			InitializeComponent();
			try
			{
				ProfileImage.set_ImageSource((ImageSource)new BitmapImage(new Uri(pfp)));
				if (isverified == "True")
				{
					((ContentControl)VerifiedLabel).set_Content((object)"\uf058");
				}
				((ContentControl)Username).set_Content((object)name);
				((ContentControl)LikeCount).set_Content((object)like);
				((ContentControl)DislikeCount).set_Content((object)dislike);
				((ContentControl)Text).set_Content((object)text);
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
				Uri val = new Uri("/Comet 3;component/usercontrols/comment.xaml", (UriKind)2);
				Application.LoadComponent((object)this, val);
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			//IL_0031: Unknown result type (might be due to invalid IL or missing references)
			//IL_003b: Expected O, but got Unknown
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0049: Expected O, but got Unknown
			//IL_004d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0057: Expected O, but got Unknown
			//IL_005b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Expected O, but got Unknown
			//IL_0069: Unknown result type (might be due to invalid IL or missing references)
			//IL_0073: Expected O, but got Unknown
			//IL_0077: Unknown result type (might be due to invalid IL or missing references)
			//IL_0081: Expected O, but got Unknown
			//IL_0085: Unknown result type (might be due to invalid IL or missing references)
			//IL_008f: Expected O, but got Unknown
			//IL_0093: Unknown result type (might be due to invalid IL or missing references)
			//IL_009d: Expected O, but got Unknown
			switch (connectionId)
			{
			case 1:
				ProfileImage = (ImageBrush)target;
				break;
			case 2:
				LikeGroup = (Border)target;
				break;
			case 3:
				LikeCount = (Label)target;
				break;
			case 4:
				DislikeGroup = (Border)target;
				break;
			case 5:
				DislikeCount = (Label)target;
				break;
			case 6:
				VerifiedLabel = (Label)target;
				break;
			case 7:
				Username = (Label)target;
				break;
			case 8:
				Text = (Label)target;
				break;
			default:
				_contentLoaded = true;
				break;
			}
		}
	}
}
