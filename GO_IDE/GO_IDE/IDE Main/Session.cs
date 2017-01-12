using GO_IDE.Project_Manager;
using GO_IDE.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GO_IDE.IDE_Main
{
    public class Session
    {
        public MainForm mainForm;
        public Output output;
        public ProjectExplorer projectExplorer;
        public CodeEditor codeEditor;
        public ProjectManager projectManager;
        public GOCompile goCompiler;

        public Project OpenedProject { get; set; } = null;

        public Session(MainForm form)
        {
            mainForm = form;
            goCompiler = new GOCompile(this);
            output = new Output(mainForm);
            projectManager = new ProjectManager();
            SettingsClass.Instance.LoadSettings();
            projectExplorer = new ProjectExplorer(mainForm.ProjectControl,this);
            ScanProjectManagment();
            StartCodeEditor();
        }

        public void OpenNewProject(Project prj)
        {
            OpenedProject = prj;
            ResetCodeEditor();
            projectManager.StartNewProject(prj,this);
            ScanProjectManagment();
        }

        public void ResetCodeEditor()
        {
            codeEditor.codeEditorControl.ClearAll();
        }

        public void StartCodeEditor()
        {
            codeEditor = new CodeEditor(mainForm.editorCanvas);

            if (OpenedProject == null)
                codeEditor.codeEditorControl.Enabled = false;
        }

        public void AddLinesToCode(string[] lines)
        {
            foreach (var v in lines)
            {
                string toAdd = v;

                if (toAdd == string.Empty)
                    toAdd += "\n";

                codeEditor.codeEditorControl.AddText(toAdd+"\n");
            }
        }

        public void ScanProjectManagment()
        {
            if (OpenedProject != null)
            {
                projectExplorer.UpdateProjectManager(OpenedProject);
            }
            else
            {
               projectExplorer.InitProjectManager();         
            }
        }

        public void StartNewProject()
        {
            if(SettingsClass.Instance.setupSettings.GOPathPresent)
            {
                NewProjectForm nForm = new NewProjectForm(this);
                nForm.Show();
            }
            else
            {
                Output.OutputToConsole("Go path is not set, please set path under Edit > Settings > Global Settings");
            }
        }

        public void StartSettingsMenu()
        {
            SettingsClass.Instance.setupSettings.StartSetupMenu();
        }

        public void RunGoScript()
        {
            if (OpenedProject != null)
                goCompiler.RunCompiler(OpenedProject);
            else
                Output.OutputToConsole("Error! No opened project to run");
        }

    }
}
