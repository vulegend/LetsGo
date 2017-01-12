using GO_IDE.IDE_Main;
using GO_IDE.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GO_IDE.Project_Manager
{
    public partial class NewProjectForm : Form
    {
        private Session _sess;

        public NewProjectForm(Session sess)
        {
            InitializeComponent();
            _sess = sess;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Project prj = new Project { ProjectName = textBox1.Text,
                ProjectPath = SettingsClass.Instance.setupSettings.GetProjectRootPath() + "/" + textBox1.Text,
                MainCommandName = textBox2.Text };
            _sess.OpenNewProject(prj);
            this.Close();
        }
    }
}
