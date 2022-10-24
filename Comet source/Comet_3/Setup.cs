using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Win32;
using Newtonsoft.Json;

namespace Comet_3
{
	public class Setup : Window, IComponentConnector
	{
		public class jsonstrings
		{
			public class ThemeSystem
			{
				public string ThemeManufacturer
				{
					get;
					set;
				}

				public string Color1
				{
					get;
					set;
				}

				public string Color2
				{
					get;
					set;
				}

				public string TextboxImage
				{
					get;
					set;
				}
			}

			public List<ThemeSystem> Theme;
		}

		private RegistryKey RegistrySettings = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Supercomet3");

		private dynamic CometTheme = JsonConvert.DeserializeObject(File.ReadAllText("./bin/theme.COMET主题系统"));

		private string color1 = "#FF0080FF";

		private string color2 = "#FF50E7FF";

		internal BeginStoryboard Bootup_BeginStoryboard;

		internal BeginStoryboard Pg1ToPg2_BeginStoryboard;

		internal BeginStoryboard Pg1ToPg2_BeginStoryboard1;

		internal BeginStoryboard Pg3ToPg4_BeginStoryboard;

		internal BeginStoryboard Pg4ToPg5_BeginStoryboard;

		internal Grid TopBar;

		internal Button ExitB;

		internal Button MinimizeB;

		internal Ellipse ellipse;

		internal Ellipse ellipse1;

		internal Ellipse ellipse2;

		internal Ellipse ellipse3;

		internal Ellipse ellipse4;

		internal Grid Page1;

		internal Label label;

		internal Label label1;

		internal Button SPG1B;

		internal Grid Page2;

		internal ImageBrush ProfileImage;

		internal TextBox Username;

		internal TextBox UserPFP;

		internal Button UploadImageB;

		internal Button ClearImageB;

		internal Button SPG2B;

		internal Grid Page3;

		internal GradientStop GEP1;

		internal GradientStop GEP2;

		internal Button PC1B;

		internal Button PC2B;

		internal Button SPG3B;

		internal Grid Page4;

		internal Button SPG4B;

		internal Grid Page5;

		internal Button SPG5B;

		private bool _contentLoaded;

		public Setup()
			: this()
		{
			InitializeComponent();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
		}

		private void SPG2B_Click(object sender, RoutedEventArgs e)
		{
			RegistrySettings.SetValue("ProfileName", (object)Username.get_Text());
		}

		private void UploadImageB_Click(object sender, RoutedEventArgs e)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0007: Expected O, but got Unknown
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Invalid comparison between Unknown and I4
			//IL_005f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0069: Expected O, but got Unknown
			//IL_0064: Unknown result type (might be due to invalid IL or missing references)
			//IL_006e: Expected O, but got Unknown
			//IL_0090: Unknown result type (might be due to invalid IL or missing references)
			OpenFileDialog val = new OpenFileDialog();
			((FileDialog)val).set_Filter("Image Files(*.png;*.jpg;*.webp)|*.png;*.jpg;*.webp|All files (*.*)|*.*");
			((FileDialog)val).set_Title("Comet 3 | Choose Profile Image");
			((FileDialog)val).set_InitialDirectory(Application.get_StartupPath());
			if ((int)((CommonDialog)val).ShowDialog() == 1)
			{
				try
				{
					RegistrySettings.SetValue("ProfilePicture", (object)((FileDialog)val).get_FileName());
					ProfileImage.set_ImageSource((ImageSource)new BitmapImage(new Uri(((FileDialog)val).get_FileName())));
					UserPFP.set_Text(((FileDialog)val).get_FileName());
				}
				catch
				{
					MessageBox.Show("Hi, I'm sorry but this image is suspicious, please remove it.", "Comet Error");
				}
			}
		}

		private void ClearImageB_Click(object sender, RoutedEventArgs e)
		{
			//IL_0022: Unknown result type (might be due to invalid IL or missing references)
			//IL_002c: Expected O, but got Unknown
			//IL_0027: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			RegistrySettings.SetValue("ProfilePicture", (object)"");
			ProfileImage.set_ImageSource((ImageSource)new BitmapImage(new Uri("https://cometrbx.xyz/external-files/CometDefaultPFP.png")));
			UserPFP.set_Text("CometDefaultPFP.png");
		}

		private void PC1B_Click(object sender, RoutedEventArgs e)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0007: Expected O, but got Unknown
			//IL_0008: Unknown result type (might be due to invalid IL or missing references)
			//IL_000e: Invalid comparison between Unknown and I4
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			//IL_002d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0036: Unknown result type (might be due to invalid IL or missing references)
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0044: Unknown result type (might be due to invalid IL or missing references)
			//IL_0049: Unknown result type (might be due to invalid IL or missing references)
			//IL_0051: Unknown result type (might be due to invalid IL or missing references)
			//IL_0056: Unknown result type (might be due to invalid IL or missing references)
			//IL_0060: Expected O, but got Unknown
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_006b: Expected O, but got Unknown
			//IL_007d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Expected O, but got Unknown
			//IL_0099: Unknown result type (might be due to invalid IL or missing references)
			ColorDialog val = new ColorDialog();
			if ((int)((CommonDialog)val).ShowDialog() == 1)
			{
				Color color = val.get_Color();
				byte a = ((Color)(ref color)).get_A();
				color = val.get_Color();
				byte r = ((Color)(ref color)).get_R();
				color = val.get_Color();
				byte g = ((Color)(ref color)).get_G();
				color = val.get_Color();
				color1 = ((object)new SolidColorBrush(Color.FromArgb(a, r, g, ((Color)(ref color)).get_B()))).ToString();
				BrushConverter val2 = new BrushConverter();
				((Control)PC1B).set_Background((Brush)((TypeConverter)val2).ConvertFromString(color1));
				GEP1.set_Color((Color)ColorConverter.ConvertFromString(color1));
			}
		}

		private void PC2B_Click(object sender, RoutedEventArgs e)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0007: Expected O, but got Unknown
			//IL_0008: Unknown result type (might be due to invalid IL or missing references)
			//IL_000e: Invalid comparison between Unknown and I4
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			//IL_002d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0036: Unknown result type (might be due to invalid IL or missing references)
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0044: Unknown result type (might be due to invalid IL or missing references)
			//IL_0049: Unknown result type (might be due to invalid IL or missing references)
			//IL_0051: Unknown result type (might be due to invalid IL or missing references)
			//IL_0056: Unknown result type (might be due to invalid IL or missing references)
			//IL_0060: Expected O, but got Unknown
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_006b: Expected O, but got Unknown
			//IL_007d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Expected O, but got Unknown
			//IL_0099: Unknown result type (might be due to invalid IL or missing references)
			ColorDialog val = new ColorDialog();
			if ((int)((CommonDialog)val).ShowDialog() == 1)
			{
				Color color = val.get_Color();
				byte a = ((Color)(ref color)).get_A();
				color = val.get_Color();
				byte r = ((Color)(ref color)).get_R();
				color = val.get_Color();
				byte g = ((Color)(ref color)).get_G();
				color = val.get_Color();
				color2 = ((object)new SolidColorBrush(Color.FromArgb(a, r, g, ((Color)(ref color)).get_B()))).ToString();
				BrushConverter val2 = new BrushConverter();
				((Control)PC2B).set_Background((Brush)((TypeConverter)val2).ConvertFromString(color2));
				GEP2.set_Color((Color)ColorConverter.ConvertFromString(color2));
			}
		}

		private void SPG3B_Click(object sender, RoutedEventArgs e)
		{
			jsonstrings jsonstrings = new jsonstrings
			{
				Theme = new List<jsonstrings.ThemeSystem>
				{
					new jsonstrings.ThemeSystem
					{
						ThemeManufacturer = "超级彗星技术",
						Color1 = color1,
						Color2 = color2,
						TextboxImage = ""
					}
				}
			};
			try
			{
				File.WriteAllText("./bin/theme.COMET主题系统", JsonConvert.SerializeObject((object)jsonstrings, (Formatting)1));
			}
			catch
			{
			}
		}

		private void SPG5B_Click(object sender, RoutedEventArgs e)
		{
			RegistrySettings.SetValue("SetupCompletion", (object)"true");
			((Window)new Startup()).Show();
			((Window)this).Close();
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
				Uri val = new Uri("/Comet 3;component/setup.xaml", (UriKind)2);
				Application.LoadComponent((object)this, val);
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b5: Expected O, but got Unknown
			//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c7: Expected O, but got Unknown
			//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d8: Expected O, but got Unknown
			//IL_00df: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e9: Expected O, but got Unknown
			//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fa: Expected O, but got Unknown
			//IL_0101: Unknown result type (might be due to invalid IL or missing references)
			//IL_010b: Expected O, but got Unknown
			//IL_0112: Unknown result type (might be due to invalid IL or missing references)
			//IL_011c: Expected O, but got Unknown
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_012d: Expected O, but got Unknown
			//IL_0134: Unknown result type (might be due to invalid IL or missing references)
			//IL_013e: Expected O, but got Unknown
			//IL_0145: Unknown result type (might be due to invalid IL or missing references)
			//IL_014f: Expected O, but got Unknown
			//IL_0156: Unknown result type (might be due to invalid IL or missing references)
			//IL_0160: Expected O, but got Unknown
			//IL_0167: Unknown result type (might be due to invalid IL or missing references)
			//IL_0171: Expected O, but got Unknown
			//IL_0178: Unknown result type (might be due to invalid IL or missing references)
			//IL_0182: Expected O, but got Unknown
			//IL_0189: Unknown result type (might be due to invalid IL or missing references)
			//IL_0193: Expected O, but got Unknown
			//IL_019a: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a4: Expected O, but got Unknown
			//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b5: Expected O, but got Unknown
			//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c6: Expected O, but got Unknown
			//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d7: Expected O, but got Unknown
			//IL_01de: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e8: Expected O, but got Unknown
			//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f9: Expected O, but got Unknown
			//IL_0200: Unknown result type (might be due to invalid IL or missing references)
			//IL_020a: Expected O, but got Unknown
			//IL_0211: Unknown result type (might be due to invalid IL or missing references)
			//IL_021b: Expected O, but got Unknown
			//IL_0222: Unknown result type (might be due to invalid IL or missing references)
			//IL_022c: Expected O, but got Unknown
			//IL_0239: Unknown result type (might be due to invalid IL or missing references)
			//IL_0243: Expected O, but got Unknown
			//IL_024b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0255: Expected O, but got Unknown
			//IL_0262: Unknown result type (might be due to invalid IL or missing references)
			//IL_026c: Expected O, but got Unknown
			//IL_0274: Unknown result type (might be due to invalid IL or missing references)
			//IL_027e: Expected O, but got Unknown
			//IL_028b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0295: Expected O, but got Unknown
			//IL_029d: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a7: Expected O, but got Unknown
			//IL_02ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b8: Expected O, but got Unknown
			//IL_02bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c9: Expected O, but got Unknown
			//IL_02d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_02da: Expected O, but got Unknown
			//IL_02e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f1: Expected O, but got Unknown
			//IL_02f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0303: Expected O, but got Unknown
			//IL_0310: Unknown result type (might be due to invalid IL or missing references)
			//IL_031a: Expected O, but got Unknown
			//IL_031f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0329: Expected O, but got Unknown
			//IL_0336: Unknown result type (might be due to invalid IL or missing references)
			//IL_0340: Expected O, but got Unknown
			//IL_0345: Unknown result type (might be due to invalid IL or missing references)
			//IL_034f: Expected O, but got Unknown
			//IL_0353: Unknown result type (might be due to invalid IL or missing references)
			//IL_035d: Expected O, but got Unknown
			//IL_0361: Unknown result type (might be due to invalid IL or missing references)
			//IL_036b: Expected O, but got Unknown
			//IL_036f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0379: Expected O, but got Unknown
			//IL_0386: Unknown result type (might be due to invalid IL or missing references)
			//IL_0390: Expected O, but got Unknown
			switch (connectionId)
			{
			case 1:
				((FrameworkElement)(Setup)target).add_Loaded(new RoutedEventHandler(Window_Loaded));
				break;
			case 2:
				Bootup_BeginStoryboard = (BeginStoryboard)target;
				break;
			case 3:
				Pg1ToPg2_BeginStoryboard = (BeginStoryboard)target;
				break;
			case 4:
				Pg1ToPg2_BeginStoryboard1 = (BeginStoryboard)target;
				break;
			case 5:
				Pg3ToPg4_BeginStoryboard = (BeginStoryboard)target;
				break;
			case 6:
				Pg4ToPg5_BeginStoryboard = (BeginStoryboard)target;
				break;
			case 7:
				TopBar = (Grid)target;
				break;
			case 8:
				ExitB = (Button)target;
				break;
			case 9:
				MinimizeB = (Button)target;
				break;
			case 10:
				ellipse = (Ellipse)target;
				break;
			case 11:
				ellipse1 = (Ellipse)target;
				break;
			case 12:
				ellipse2 = (Ellipse)target;
				break;
			case 13:
				ellipse3 = (Ellipse)target;
				break;
			case 14:
				ellipse4 = (Ellipse)target;
				break;
			case 15:
				Page1 = (Grid)target;
				break;
			case 16:
				label = (Label)target;
				break;
			case 17:
				label1 = (Label)target;
				break;
			case 18:
				SPG1B = (Button)target;
				break;
			case 19:
				Page2 = (Grid)target;
				break;
			case 20:
				ProfileImage = (ImageBrush)target;
				break;
			case 21:
				Username = (TextBox)target;
				break;
			case 22:
				UserPFP = (TextBox)target;
				break;
			case 23:
				UploadImageB = (Button)target;
				((ButtonBase)UploadImageB).add_Click(new RoutedEventHandler(UploadImageB_Click));
				break;
			case 24:
				ClearImageB = (Button)target;
				((ButtonBase)ClearImageB).add_Click(new RoutedEventHandler(ClearImageB_Click));
				break;
			case 25:
				SPG2B = (Button)target;
				((ButtonBase)SPG2B).add_Click(new RoutedEventHandler(SPG2B_Click));
				break;
			case 26:
				Page3 = (Grid)target;
				break;
			case 27:
				GEP1 = (GradientStop)target;
				break;
			case 28:
				GEP2 = (GradientStop)target;
				break;
			case 29:
				PC1B = (Button)target;
				((ButtonBase)PC1B).add_Click(new RoutedEventHandler(PC1B_Click));
				break;
			case 30:
				PC2B = (Button)target;
				((ButtonBase)PC2B).add_Click(new RoutedEventHandler(PC2B_Click));
				break;
			case 31:
				SPG3B = (Button)target;
				((ButtonBase)SPG3B).add_Click(new RoutedEventHandler(SPG3B_Click));
				break;
			case 32:
				Page4 = (Grid)target;
				break;
			case 33:
				SPG4B = (Button)target;
				break;
			case 34:
				Page5 = (Grid)target;
				break;
			case 35:
				SPG5B = (Button)target;
				((ButtonBase)SPG5B).add_Click(new RoutedEventHandler(SPG5B_Click));
				break;
			default:
				_contentLoaded = true;
				break;
			}
		}
	}
}
