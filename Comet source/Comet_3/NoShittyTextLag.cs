using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Rendering;

namespace Comet_3
{
	public class NoShittyTextLag : VisualLineElementGenerator
	{
		private const int maxLength = 2000;

		private const string ellipsis = "< Expand >";

		private const int charactersAfterEllipsis = 100;

		public override int GetFirstInterestedOffset(int startOffset)
		{
			DocumentLine lastDocumentLine = ((VisualLineElementGenerator)this).get_CurrentContext().get_VisualLine().get_LastDocumentLine();
			if (lastDocumentLine.get_Length() > 2000)
			{
				int num = lastDocumentLine.get_Offset() + 2000 - 100 - "< Expand >".Length;
				if (startOffset <= num)
				{
					return num;
				}
			}
			return -1;
		}

		public override VisualLineElement ConstructElement(int offset)
		{
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			return (VisualLineElement)new FormattedTextElement("< Expand >", ((VisualLineElementGenerator)this).get_CurrentContext().get_VisualLine().get_LastDocumentLine()
				.get_EndOffset() - offset - 100);
		}

		public NoShittyTextLag()
			: this()
		{
		}
	}
}
