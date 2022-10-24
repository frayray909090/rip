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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using Comet_3.Classes.DLL;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;

namespace Comet_3.UserControls
{
	public class GameSquare : UserControl, IComponentConnector
	{
		internal BeginStoryboard CloseInfoWindow_BeginStoryboard;

		internal BeginStoryboard CloseInfoWindow_BeginStoryboard1;

		internal ImageBrush GameSquareImage;

		internal Button InfoB;

		internal Button FavoriteB;

		internal Button PlayB;

		internal Label GameTitle;

		internal Label ScriptsTitle;

		internal Border PatchedLabel;

		internal Border border;

		internal ImageBrush SCScriptImage;

		internal Label SCScriptLabel;

		internal ImageBrush SCProfileImage;

		internal Label SCProfileName;

		internal Border LikeGroup;

		internal Label SCLikeCount;

		internal Border DislikeGroup;

		internal Label SCDislikeCount;

		internal Label SCVerifiedLabel;

		internal Button SCVCButton;

		internal Button SCPGButton;

		internal Button SCESButton;

		internal Button SCCSButton;

		internal Button SCVOSButton;

		internal Button CloseScriptViewerB;

		private bool _contentLoaded;

		public GameSquare(string image, string title, string script, string scriptbloxid)
			: this()
		{
			//IL_0046: Unknown result type (might be due to invalid IL or missing references)
			//IL_004c: Expected O, but got Unknown
			//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ce: Expected O, but got Unknown
			//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d3: Expected O, but got Unknown
			//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0105: Expected O, but got Unknown
			//IL_0100: Unknown result type (might be due to invalid IL or missing references)
			//IL_010a: Expected O, but got Unknown
			//IL_0423: Unknown result type (might be due to invalid IL or missing references)
			//IL_042d: Expected O, but got Unknown
			//IL_043b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0445: Expected O, but got Unknown
			//IL_0458: Unknown result type (might be due to invalid IL or missing references)
			//IL_0462: Expected O, but got Unknown
			//IL_0470: Unknown result type (might be due to invalid IL or missing references)
			//IL_047a: Expected O, but got Unknown
			//IL_0488: Unknown result type (might be due to invalid IL or missing references)
			//IL_0492: Expected O, but got Unknown
			//IL_04a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_04af: Expected O, but got Unknown
			//IL_04c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_04cc: Expected O, but got Unknown
			GameSquare gameSquare = this;
			InitializeComponent();
			WebClient val = new WebClient();
			Tools tools = new Tools();
			bool ShowImageNormally = false;
			dynamic ScriptIDJson = JsonConvert.DeserializeObject(val.DownloadString("https://scriptblox.com/api/script/" + scriptbloxid));
			if (image.Contains("rbxcdn.com"))
			{
				ShowImageNormally = true;
			}
			if (ShowImageNormally)
			{
				try
				{
					GameSquareImage.set_ImageSource((ImageSource)new BitmapImage(new Uri(image)));
				}
				catch
				{
				}
			}
			else
			{
				try
				{
					GameSquareImage.set_ImageSource((ImageSource)new BitmapImage(new Uri("https://scriptblox.com" + image)));
				}
				catch
				{
				}
			}
			((ContentControl)ScriptsTitle).set_Content((object)title);
			((ContentControl)GameTitle).set_Content((object)ScriptIDJson.script.game.name.ToString());
			if (_003C_003Eo__0._003C_003Ep__8 == null)
			{
				_003C_003Eo__0._003C_003Ep__8 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, (ExpressionType)83, typeof(GameSquare), new CSharpArgumentInfo[1]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			Func<CallSite, object, bool> target = _003C_003Eo__0._003C_003Ep__8.Target;
			CallSite<Func<CallSite, object, bool>> _003C_003Ep__ = _003C_003Eo__0._003C_003Ep__8;
			if (_003C_003Eo__0._003C_003Ep__7 == null)
			{
				_003C_003Eo__0._003C_003Ep__7 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, (ExpressionType)13, typeof(GameSquare), new CSharpArgumentInfo[2]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
				}));
			}
			if (target((CallSite)(object)_003C_003Ep__, _003C_003Eo__0._003C_003Ep__7.Target((CallSite)(object)_003C_003Eo__0._003C_003Ep__7, (object)ScriptIDJson.script.isPatched.ToString(), "True")))
			{
				((UIElement)PatchedLabel).set_Opacity(1.0);
			}
			((ButtonBase)PlayB).add_Click((RoutedEventHandler)delegate
			{
				//IL_0036: Unknown result type (might be due to invalid IL or missing references)
				if (tools.Injected())
				{
					tools.Run(script);
				}
				else
				{
					MessageBox.Show("I'm sorry, but ROBLOX is not injected, sorry for the inconvince.", "Comet Error");
				}
			});
			((ButtonBase)InfoB).add_Click((RoutedEventHandler)delegate
			{
				//IL_0719: Unknown result type (might be due to invalid IL or missing references)
				//IL_0723: Expected O, but got Unknown
				//IL_0753: Unknown result type (might be due to invalid IL or missing references)
				//IL_075d: Expected O, but got Unknown
				//IL_0758: Unknown result type (might be due to invalid IL or missing references)
				//IL_0762: Expected O, but got Unknown
				//IL_078a: Unknown result type (might be due to invalid IL or missing references)
				//IL_0794: Expected O, but got Unknown
				//IL_078f: Unknown result type (might be due to invalid IL or missing references)
				//IL_0799: Expected O, but got Unknown
				try
				{
					((ContentControl)gameSquare.SCScriptLabel).set_Content((object)title);
					if (_003C_003Eo__0._003C_003Ep__13 == null)
					{
						_003C_003Eo__0._003C_003Ep__13 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, (ExpressionType)83, typeof(GameSquare), new CSharpArgumentInfo[1]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
						}));
					}
					Func<CallSite, object, bool> target2 = _003C_003Eo__0._003C_003Ep__13.Target;
					CallSite<Func<CallSite, object, bool>> _003C_003Ep__2 = _003C_003Eo__0._003C_003Ep__13;
					if (_003C_003Eo__0._003C_003Ep__12 == null)
					{
						_003C_003Eo__0._003C_003Ep__12 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, (ExpressionType)13, typeof(GameSquare), new CSharpArgumentInfo[2]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
						}));
					}
					if (target2((CallSite)(object)_003C_003Ep__2, _003C_003Eo__0._003C_003Ep__12.Target((CallSite)(object)_003C_003Eo__0._003C_003Ep__12, (object)ScriptIDJson.script.verified.ToString(), "True")))
					{
						((ContentControl)gameSquare.SCVerifiedLabel).set_Content((object)"\uf058");
					}
					((ContentControl)gameSquare.SCLikeCount).set_Content((object)ScriptIDJson.script.likeCount.ToString());
					((ContentControl)gameSquare.SCDislikeCount).set_Content((object)ScriptIDJson.script.dislikeCount.ToString());
					((ContentControl)gameSquare.SCProfileName).set_Content((object)ScriptIDJson.script.owner.username.ToString());
					ImageBrush sCProfileImage = gameSquare.SCProfileImage;
					Type typeFromHandle2 = typeof(Uri);
					if (_003C_003Eo__0._003C_003Ep__28 == null)
					{
						_003C_003Eo__0._003C_003Ep__28 = CallSite<Func<CallSite, string, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, (ExpressionType)0, typeof(GameSquare), new CSharpArgumentInfo[2]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
						}));
					}
					sCProfileImage.set_ImageSource((ImageSource)new BitmapImage((Uri)/*Could not detect static type for DynamicInvokeConstructorInstruction*/));
					if (ShowImageNormally)
					{
						gameSquare.GameSquareImage.set_ImageSource((ImageSource)new BitmapImage(new Uri("https://scriptblox.com" + image)));
					}
					else
					{
						gameSquare.GameSquareImage.set_ImageSource((ImageSource)new BitmapImage(new Uri("https://scriptblox.com" + image)));
					}
				}
				catch
				{
				}
			});
			((ButtonBase)SCVCButton).add_Click((RoutedEventHandler)delegate
			{
				ScriptComments scriptComments = new ScriptComments(scriptbloxid);
				((Window)scriptComments).ShowDialog();
			});
			((ButtonBase)SCPGButton).add_Click((RoutedEventHandler)delegate
			{
				try
				{
					Type typeFromHandle = typeof(Process);
					if (_003C_003Eo__0._003C_003Ep__34 == null)
					{
						_003C_003Eo__0._003C_003Ep__34 = CallSite<Func<CallSite, string, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, (ExpressionType)0, typeof(GameSquare), new CSharpArgumentInfo[2]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
						}));
					}
					typeFromHandle.Start((dynamic)_003C_003Eo__0._003C_003Ep__34.Target((CallSite)(object)_003C_003Eo__0._003C_003Ep__34, "https://www.roblox.com/games/", (object)ScriptIDJson.script.game.gameId.ToString()));
				}
				catch
				{
				}
			});
			((ButtonBase)SCESButton).add_Click((RoutedEventHandler)delegate
			{
				//IL_0036: Unknown result type (might be due to invalid IL or missing references)
				if (tools.Injected())
				{
					tools.Run(script);
				}
				else
				{
					MessageBox.Show("I'm sorry, but ROBLOX is not injected, sorry for the inconvince.", "Comet Error");
				}
			});
			((ButtonBase)SCCSButton).add_Click((RoutedEventHandler)delegate
			{
				Clipboard.SetText(script);
			});
			((ButtonBase)SCVOSButton).add_Click((RoutedEventHandler)delegate
			{
				try
				{
					Process.Start("https://scriptblox.com/script/" + scriptbloxid);
				}
				catch
				{
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
				Uri val = new Uri("/Comet 3;component/usercontrols/gamesquare.xaml", (UriKind)2);
				Application.LoadComponent((object)this, val);
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			//IL_0078: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Expected O, but got Unknown
			//IL_0089: Unknown result type (might be due to invalid IL or missing references)
			//IL_0093: Expected O, but got Unknown
			//IL_009a: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a4: Expected O, but got Unknown
			//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b5: Expected O, but got Unknown
			//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c6: Expected O, but got Unknown
			//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Expected O, but got Unknown
			//IL_00de: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e8: Expected O, but got Unknown
			//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f9: Expected O, but got Unknown
			//IL_0100: Unknown result type (might be due to invalid IL or missing references)
			//IL_010a: Expected O, but got Unknown
			//IL_0111: Unknown result type (might be due to invalid IL or missing references)
			//IL_011b: Expected O, but got Unknown
			//IL_0122: Unknown result type (might be due to invalid IL or missing references)
			//IL_012c: Expected O, but got Unknown
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_013d: Expected O, but got Unknown
			//IL_0144: Unknown result type (might be due to invalid IL or missing references)
			//IL_014e: Expected O, but got Unknown
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_015f: Expected O, but got Unknown
			//IL_0166: Unknown result type (might be due to invalid IL or missing references)
			//IL_0170: Expected O, but got Unknown
			//IL_0177: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Expected O, but got Unknown
			//IL_0188: Unknown result type (might be due to invalid IL or missing references)
			//IL_0192: Expected O, but got Unknown
			//IL_0196: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a0: Expected O, but got Unknown
			//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ae: Expected O, but got Unknown
			//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bc: Expected O, but got Unknown
			//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ca: Expected O, but got Unknown
			//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d8: Expected O, but got Unknown
			//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e6: Expected O, but got Unknown
			//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f4: Expected O, but got Unknown
			//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0202: Expected O, but got Unknown
			switch (connectionId)
			{
			case 1:
				CloseInfoWindow_BeginStoryboard = (BeginStoryboard)target;
				break;
			case 2:
				CloseInfoWindow_BeginStoryboard1 = (BeginStoryboard)target;
				break;
			case 3:
				GameSquareImage = (ImageBrush)target;
				break;
			case 4:
				InfoB = (Button)target;
				break;
			case 5:
				FavoriteB = (Button)target;
				break;
			case 6:
				PlayB = (Button)target;
				break;
			case 7:
				GameTitle = (Label)target;
				break;
			case 8:
				ScriptsTitle = (Label)target;
				break;
			case 9:
				PatchedLabel = (Border)target;
				break;
			case 10:
				border = (Border)target;
				break;
			case 11:
				SCScriptImage = (ImageBrush)target;
				break;
			case 12:
				SCScriptLabel = (Label)target;
				break;
			case 13:
				SCProfileImage = (ImageBrush)target;
				break;
			case 14:
				SCProfileName = (Label)target;
				break;
			case 15:
				LikeGroup = (Border)target;
				break;
			case 16:
				SCLikeCount = (Label)target;
				break;
			case 17:
				DislikeGroup = (Border)target;
				break;
			case 18:
				SCDislikeCount = (Label)target;
				break;
			case 19:
				SCVerifiedLabel = (Label)target;
				break;
			case 20:
				SCVCButton = (Button)target;
				break;
			case 21:
				SCPGButton = (Button)target;
				break;
			case 22:
				SCESButton = (Button)target;
				break;
			case 23:
				SCCSButton = (Button)target;
				break;
			case 24:
				SCVOSButton = (Button)target;
				break;
			case 25:
				CloseScriptViewerB = (Button)target;
				break;
			default:
				_contentLoaded = true;
				break;
			}
		}
	}
}
