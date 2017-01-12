using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GO_IDE.IDE_Main
{
    public class Output
    {
        private static MainForm _outputConsole;
        private static int _currentIndex = 0;

        /// <summary>
        /// Initializes output with the reference to the output window
        /// </summary>
        public Output(MainForm outputConsole)
        {
            _outputConsole = outputConsole;
        }

        private static void OffsetTextbox()
        {
            if (_currentIndex == 0)
            {
                _outputConsole.OutputConsole.AppendText("\n\n");
                _currentIndex += 2;
            }

        }

        private static void AppendTextAsync(string text)
        {

        }

        private static string FormatOutputString(string msg)
        {
            string timeFormat = DateTime.Now.ToLongTimeString();
            string toReturn = $"\n[{timeFormat}] : {msg}";
            return toReturn;
        }

        public static void ResetOutput()
        {
            _currentIndex = 0;
            _outputConsole.OutputConsole.Clear();
        }

        public static void OutputToConsole(string msg)
        {
            if(_outputConsole.InvokeRequired)
            {
                _outputConsole.BeginInvoke(new Action<string>(OutputToConsole), msg);
            }
            else
                _outputConsole.OutputConsole.AppendText(FormatOutputString(msg));
        }

    }
}
