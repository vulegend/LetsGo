using GO_IDE.IDE_Main;
using GO_IDE.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScintillaNET;
using System.IO;
using GO_IDE.Settings;
using GO_IDE.Project_Manager;

namespace GO_IDE
{
    public partial class MainForm : Form
    {
        public RichTextBox OutputConsole { get; set; }
        public TreeView ProjectControl { get; set; }

        public SplitContainer editorCanvas;

        private Session _ses;

        public MainForm()
        {
            InitializeComponent();
            InitMainForm();
        }    

        public void InitMainForm()
        {
            OutputConsole = richTextBox1;
            editorCanvas = splitContainer2;
            ProjectControl = projectControl;
            _ses = new Session(this);
        }

        private void goProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ses.StartNewProject();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ses.StartSettingsMenu();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SettingsClass.Instance.SaveSettings();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _ses.RunGoScript();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

            folderBrowserDialog1.SelectedPath = SettingsClass.Instance.setupSettings.goPath+"src";
            if(folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                DirectoryInfo checkIfProject = new DirectoryInfo(folderBrowserDialog1.SelectedPath);

                foreach(var file in checkIfProject.GetFiles())
                {
                    if(file.Extension == ".lgp")
                    {
                        string mainCommand = checkIfProject.GetDirectories()[0].Name;
                        Project prj = new Project { MainCommandName = mainCommand, ProjectName = checkIfProject.Name, ProjectPath = checkIfProject.FullName };
                        _ses.OpenNewProject(prj);
                    }
                }
            }
        }
    }
}
