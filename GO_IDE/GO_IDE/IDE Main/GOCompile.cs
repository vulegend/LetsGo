using GO_IDE.Project_Manager;
using GO_IDE.Settings;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GO_IDE.IDE_Main
{
    public class GOCompile
    {
        private Session _sess;
        private int _skipLines = 0;

        public GOCompile(Session sess)
        {
            _sess = sess;
        }

        public void CopyFromRunning(Project prj)
        {
            string lines = _sess.codeEditor.codeEditorControl.Text;
            File.Create(prj.ProjectPath + @"\" + prj.MainCommandName + @"\" + prj.MainCommandName + ".go").Close();
            File.WriteAllText(prj.ProjectPath + @"\" + prj.MainCommandName+@"\"+prj.MainCommandName+".go", lines);
        }

        public void RunCompiler(Project prj)
        {
            if (File.Exists(SettingsClass.Instance.setupSettings.goPath + @"\bin\" + prj.MainCommandName + ".exe"))
            {
                File.Delete(SettingsClass.Instance.setupSettings.goPath + @"\bin\" + prj.MainCommandName + ".exe");
            }

            CopyFromRunning(prj);
            _skipLines = 0;
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            process.StartInfo = startInfo;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardError = true;

            process.ErrorDataReceived += cmd_Error;
            process.OutputDataReceived += cmd_DataReceived;
            process.EnableRaisingEvents = true;

            startInfo.Verb = "runas";

            process.Start();

            //Command input
            using (StreamWriter sw = process.StandardInput)
            {
                if (sw.BaseStream.CanWrite)
                {
                    sw.WriteLine("cd /d " + prj.ProjectPath + @"\" + prj.MainCommandName);
                    sw.WriteLine("go install");
                }
            }

            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            process.WaitForExit();

            if(CheckIfCompiled(prj))
            {
                RunGoScript(prj);
            }
        }

        public bool CheckIfCompiled(Project prj)
        {
            if(File.Exists(SettingsClass.Instance.setupSettings.goPath+@"\bin\"+prj.MainCommandName+".exe"))
            {
                Output.ResetOutput();
                Output.OutputToConsole("Compiled successfully");
                return true;         
            }

            return false;
        }

        public void RunGoScript(Project prj)
        {
            Output.OutputToConsole("Running the script");
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = $"/K {SettingsClass.Instance.setupSettings.goPath}/bin/{prj.MainCommandName}";
            process.StartInfo = startInfo;
            process.StartInfo.UseShellExecute = false;
            startInfo.Verb = "runas";
            process.Start();
        }

        private void cmd_DataReceived(object sender, DataReceivedEventArgs e)
        {
            if (_skipLines > 7)
                Output.OutputToConsole(e.Data);
            else
                _skipLines++;
        }

        private void cmd_Error(object sender, DataReceivedEventArgs e)
        {
            Output.OutputToConsole(e.Data);
        }
    }
}
