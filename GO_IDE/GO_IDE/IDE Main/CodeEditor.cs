using GO_IDE.Settings;
using GO_IDE.Utils;
using ScintillaNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GO_IDE.IDE_Main
{
    public class CodeEditor
    {
        private SplitContainer _parentContainer;
        public Scintilla codeEditorControl;

        public CodeEditor(SplitContainer parentContainer)
        {
            _parentContainer = parentContainer;
            InitEditor();
        }

        private void InitEditor()
        {
            codeEditorControl = new Scintilla();
            _parentContainer.Panel1.Controls.Add(codeEditorControl);
            codeEditorControl.Dock = DockStyle.Fill;

            codeEditorControl.TextChanged += (this.OnTextChanged);

            codeEditorControl.WrapMode = WrapMode.None;
            codeEditorControl.IndentationGuides = IndentView.LookBoth;

            InitColors();
            InitSyntaxColoring();

            // NUMBER MARGIN
            InitNumberMargin();

            // BOOKMARK MARGIN
            InitBookmarkMargin();

            // CODE FOLDING MARGIN
            InitCodeFolding();

            SettingsClass.Instance.codeSettings.EditorRef = this;
        }

        private void InitColors()
        {

            codeEditorControl.SetSelectionBackColor(true, UtilsClass.IntToColor(0x114D9C));

        }


        private void InitSyntaxColoring()
        {

            // Configure the default style
            codeEditorControl.StyleResetDefault();
            codeEditorControl.Styles[Style.Default].Font = "Consolas";
            codeEditorControl.Styles[Style.Default].Size = 10;
            codeEditorControl.Styles[Style.Default].BackColor = UtilsClass.IntToColor(0x212121);
            codeEditorControl.Styles[Style.Default].ForeColor = UtilsClass.IntToColor(0xFFFFFF);
            codeEditorControl.StyleClearAll();

            // Configure the CPP (C#) lexer styles
            codeEditorControl.Styles[Style.Cpp.Identifier].ForeColor = UtilsClass.IntToColor(0xD0DAE2);
            codeEditorControl.Styles[Style.Cpp.Comment].ForeColor = UtilsClass.IntToColor(0xBD758B);
            codeEditorControl.Styles[Style.Cpp.CommentLine].ForeColor = UtilsClass.IntToColor(0x40BF57);
            codeEditorControl.Styles[Style.Cpp.CommentDoc].ForeColor = UtilsClass.IntToColor(0x2FAE35);
            codeEditorControl.Styles[Style.Cpp.Number].ForeColor = UtilsClass.IntToColor(0xFFFF00);
            codeEditorControl.Styles[Style.Cpp.String].ForeColor = UtilsClass.IntToColor(0xFFFF00);
            codeEditorControl.Styles[Style.Cpp.Character].ForeColor = UtilsClass.IntToColor(0xE95454);
            codeEditorControl.Styles[Style.Cpp.Preprocessor].ForeColor = UtilsClass.IntToColor(0x8AAFEE);
            codeEditorControl.Styles[Style.Cpp.Operator].ForeColor = UtilsClass.IntToColor(0xE0E0E0);
            codeEditorControl.Styles[Style.Cpp.Regex].ForeColor = UtilsClass.IntToColor(0xff00ff);
            codeEditorControl.Styles[Style.Cpp.CommentLineDoc].ForeColor = UtilsClass.IntToColor(0x77A7DB);
            codeEditorControl.Styles[Style.Cpp.Word].ForeColor = UtilsClass.IntToColor(0x48A8EE);
            codeEditorControl.Styles[Style.Cpp.Word2].ForeColor = UtilsClass.IntToColor(0xF98906);
            codeEditorControl.Styles[Style.Cpp.CommentDocKeyword].ForeColor = UtilsClass.IntToColor(0xB3D991);
            codeEditorControl.Styles[Style.Cpp.CommentDocKeywordError].ForeColor = UtilsClass.IntToColor(0xFF0000);
            codeEditorControl.Styles[Style.Cpp.GlobalClass].ForeColor = UtilsClass.IntToColor(0x48A8EE);

            codeEditorControl.Lexer = Lexer.Cpp;

            codeEditorControl.SetKeywords(0, "func");
            codeEditorControl.SetKeywords(1, "import package");

        }

        private void OnTextChanged(object sender, EventArgs e)
        {

        }


        #region Numbers, Bookmarks, Code Folding

        /// <summary>
        /// the background color of the text area
        /// </summary>
        private const int BACK_COLOR = 0x2A211C;

        /// <summary>
        /// default text color of the text area
        /// </summary>
        private const int FORE_COLOR = 0xB7B7B7;

        /// <summary>
        /// change this to whatever margin you want the line numbers to show in
        /// </summary>
        private const int NUMBER_MARGIN = 1;

        /// <summary>
        /// change this to whatever margin you want the bookmarks/breakpoints to show in
        /// </summary>
        private const int BOOKMARK_MARGIN = 2;
        private const int BOOKMARK_MARKER = 2;

        /// <summary>
        /// change this to whatever margin you want the code folding tree (+/-) to show in
        /// </summary>
        private const int FOLDING_MARGIN = 3;

        /// <summary>
        /// set this true to show circular buttons for code folding (the [+] and [-] buttons on the margin)
        /// </summary>
        private const bool CODEFOLDING_CIRCULAR = true;

        private void InitNumberMargin()
        {

            codeEditorControl.Styles[Style.LineNumber].BackColor = UtilsClass.IntToColor(BACK_COLOR);
            codeEditorControl.Styles[Style.LineNumber].ForeColor = UtilsClass.IntToColor(FORE_COLOR);
            codeEditorControl.Styles[Style.IndentGuide].ForeColor = UtilsClass.IntToColor(FORE_COLOR);
            codeEditorControl.Styles[Style.IndentGuide].BackColor = UtilsClass.IntToColor(BACK_COLOR);

            var nums = codeEditorControl.Margins[NUMBER_MARGIN];
            nums.Width = 30;
            nums.Type = MarginType.Number;
            nums.Sensitive = true;
            nums.Mask = 0;

            codeEditorControl.MarginClick += CodeEditorControl_MarginClick;
        }

        private void InitBookmarkMargin()
        {

            //CodeEditorControl.SetFoldMarginColor(true, IntToColor(BACK_COLOR));

            var margin = codeEditorControl.Margins[BOOKMARK_MARGIN];
            margin.Width = 20;
            margin.Sensitive = true;
            margin.Type = MarginType.Symbol;
            margin.Mask = (1 << BOOKMARK_MARKER);
            //margin.Cursor = MarginCursor.Arrow;

            var marker = codeEditorControl.Markers[BOOKMARK_MARKER];
            marker.Symbol = MarkerSymbol.Circle;
            marker.SetBackColor(UtilsClass.IntToColor(0xFF003B));
            marker.SetForeColor(UtilsClass.IntToColor(0x000000));
            marker.SetAlpha(100);

        }

        private void InitCodeFolding()
        {
            codeEditorControl.SetFoldMarginColor(true, UtilsClass.IntToColor(BACK_COLOR));
            codeEditorControl.SetFoldMarginHighlightColor(true, UtilsClass.IntToColor(BACK_COLOR));

            // Enable code folding
            codeEditorControl.SetProperty("fold", "1");
            codeEditorControl.SetProperty("fold.compact", "1");

            // Configure a margin to display folding symbols
            codeEditorControl.Margins[FOLDING_MARGIN].Type = MarginType.Symbol;
            codeEditorControl.Margins[FOLDING_MARGIN].Mask = Marker.MaskFolders;
            codeEditorControl.Margins[FOLDING_MARGIN].Sensitive = true;
            codeEditorControl.Margins[FOLDING_MARGIN].Width = 20;

            // Set colors for all folding markers
            for (int i = 25; i <= 31; i++)
            {
                codeEditorControl.Markers[i].SetForeColor(UtilsClass.IntToColor(BACK_COLOR)); // styles for [+] and [-]
                codeEditorControl.Markers[i].SetBackColor(UtilsClass.IntToColor(FORE_COLOR)); // styles for [+] and [-]
            }

            // Configure folding markers with respective symbols
            codeEditorControl.Markers[Marker.Folder].Symbol = CODEFOLDING_CIRCULAR ? MarkerSymbol.CirclePlus : MarkerSymbol.BoxPlus;
            codeEditorControl.Markers[Marker.FolderOpen].Symbol = CODEFOLDING_CIRCULAR ? MarkerSymbol.CircleMinus : MarkerSymbol.BoxMinus;
            codeEditorControl.Markers[Marker.FolderEnd].Symbol = CODEFOLDING_CIRCULAR ? MarkerSymbol.CirclePlusConnected : MarkerSymbol.BoxPlusConnected;
            codeEditorControl.Markers[Marker.FolderMidTail].Symbol = MarkerSymbol.TCorner;
            codeEditorControl.Markers[Marker.FolderOpenMid].Symbol = CODEFOLDING_CIRCULAR ? MarkerSymbol.CircleMinusConnected : MarkerSymbol.BoxMinusConnected;
            codeEditorControl.Markers[Marker.FolderSub].Symbol = MarkerSymbol.VLine;
            codeEditorControl.Markers[Marker.FolderTail].Symbol = MarkerSymbol.LCorner;

            // Enable automatic folding
            codeEditorControl.AutomaticFold = (AutomaticFold.Show | AutomaticFold.Click | AutomaticFold.Change);

        }

        private void CodeEditorControl_MarginClick(object sender, MarginClickEventArgs e)
        {
            if (e.Margin == BOOKMARK_MARGIN)
            {
                // Do we have a marker for this line?
                const uint mask = (1 << BOOKMARK_MARKER);
                var line = codeEditorControl.Lines[codeEditorControl.LineFromPosition(e.Position)];
                if ((line.MarkerGet() & mask) > 0)
                {
                    // Remove existing bookmark
                    line.MarkerDelete(BOOKMARK_MARKER);
                }
                else
                {
                    // Add bookmark
                    line.MarkerAdd(BOOKMARK_MARKER);
                }
            }
        }

        #endregion

        #region Main Menu Commands

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            codeEditorControl.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            codeEditorControl.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            codeEditorControl.Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            codeEditorControl.SelectAll();
        }

        private void selectLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Line line = codeEditorControl.Lines[codeEditorControl.CurrentLine];
            codeEditorControl.SetSelection(line.Position + line.Length, line.Position);
        }

        private void clearSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            codeEditorControl.SetEmptySelection(0);
        }


        private void uppercaseSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Uppercase();
        }

        private void lowercaseSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Lowercase();
        }


        private void collapseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            codeEditorControl.FoldAll(FoldAction.Contract);
        }

        private void expandAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            codeEditorControl.FoldAll(FoldAction.Expand);
        }


        #endregion

        #region Uppercase / Lowercase

        private void Lowercase()
        {

            // save the selection
            int start = codeEditorControl.SelectionStart;
            int end = codeEditorControl.SelectionEnd;

            // modify the selected text
            codeEditorControl.ReplaceSelection(codeEditorControl.GetTextRange(start, end - start).ToLower());

            // preserve the original selection
            codeEditorControl.SetSelection(start, end);
        }

        private void Uppercase()
        {

            // save the selection
            int start = codeEditorControl.SelectionStart;
            int end = codeEditorControl.SelectionEnd;

            // modify the selected text
            codeEditorControl.ReplaceSelection(codeEditorControl.GetTextRange(start, end - start).ToUpper());

            // preserve the original selection
            codeEditorControl.SetSelection(start, end);
        }

        #endregion


        #region Utils


        public void InvokeIfNeeded(Action action)
        {
            if (codeEditorControl.InvokeRequired)
            {
                codeEditorControl.BeginInvoke(action);
            }
            else
            {
                action.Invoke();
            }
        }

        #endregion
    }
}
