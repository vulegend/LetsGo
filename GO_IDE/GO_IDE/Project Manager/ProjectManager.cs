using GO_IDE.IDE_Main;
using GO_IDE.Settings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GO_IDE.Project_Manager
{
    public class ProjectManager
    {
        private Project _curProject;
        private Session _session;

        public void StartNewProject(Project prj,Session sessRef)
        {
            _curProject = prj;
            _session = sessRef;

            //Enable editor
            _session.codeEditor.codeEditorControl.Enabled = true;

            //Create project root first if not created
            CheckForProjectRoot();

            //Create a main file
            CreateCommand();

        }

        private void CheckForProjectRoot()
        {
            if (!Directory.Exists(SettingsClass.Instance.setupSettings.goPath + "/src/github.com"))
                Directory.CreateDirectory(SettingsClass.Instance.setupSettings.goPath + "/github.com");

            if (!Directory.Exists(SettingsClass.Instance.setupSettings.GetProjectRootPath()))
                Directory.CreateDirectory(SettingsClass.Instance.setupSettings.GetProjectRootPath());

            if (!Directory.Exists(SettingsClass.Instance.setupSettings.GetProjectRootPath() + "/" + _curProject.ProjectName))
                Directory.CreateDirectory(SettingsClass.Instance.setupSettings.GetProjectRootPath() + "/" + _curProject.ProjectName);
        }

        private void CreateCommand()
        {
            if (!Directory.Exists(_curProject.ProjectPath + "/" + _curProject.MainCommandName))
                Directory.CreateDirectory(_curProject.ProjectPath + "/" + _curProject.MainCommandName);

            if (!File.Exists(_curProject.ProjectPath + "/" + _curProject.MainCommandName + "/"+ _curProject.MainCommandName+ ".go"))
                File.Create(_curProject.ProjectPath + "/" + _curProject.MainCommandName + "/" + _curProject.MainCommandName + ".go").Close();

            File.Create(_curProject.ProjectPath + "/" + _curProject.ProjectName + ".lgp").Close();

            string[] readAllLines = File.ReadAllLines(Environment.CurrentDirectory + "/Snippets/main.txt");
            _session.AddLinesToCode(readAllLines);
        }
    }
}
