using GO_IDE.IDE_Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GO_IDE.Settings
{
    [System.Serializable]
    public class CodeEditorSettings
    {
        /// <summary>
        /// the background color of the text area
        /// </summary>
        public int backColor = 0x2A211C;

        /// <summary>
        /// default text color of the text area
        /// </summary>
        public int foreColor = 0xB7B7B7;

        public int backColorLines = 0x2A211C;
        public int foreColorLines = 0xB7B7B7;

        [System.NonSerialized]
        public CodeEditor EditorRef;

        public CodeEditorSettings()
        {
            DefaultValues();
        }

        private void DefaultValues()
        {
            foreColor = 0xB7B7B7;
            backColor = 0x2A211C;
        }

        public void LoadEditorSettings(CodeEditorSettings settings)
        {
            backColor = settings.backColor;
            foreColor = settings.foreColor;
        }
    }
}
