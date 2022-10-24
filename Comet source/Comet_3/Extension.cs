using System.Windows;
using System.Windows.Controls;

namespace Comet_3
{
	public static class Extension
	{
		public static T GetTemplateChild<T>(this Control e, string name) where T : FrameworkElement
		{
			object obj = ((FrameworkTemplate)e.get_Template()).FindName(name, (FrameworkElement)(object)e);
			return (T)(obj as T);
		}
	}
}
