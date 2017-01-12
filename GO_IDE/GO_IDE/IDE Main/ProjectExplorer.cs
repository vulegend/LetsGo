using GO_IDE.Project_Manager;
using GO_IDE.Settings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GO_IDE.IDE_Main
{
    public class ProjectExplorer
    {
        public TreeView projectExplorerTree;
        public Session sessRef;

        public ProjectExplorer(TreeView viewNode,Session sessRef)
        {
            projectExplorerTree = viewNode;
            this.sessRef = sessRef;
        }

        public void UpdateProjectManager(Project openedProject)
        {
            projectExplorerTree.Nodes.Clear();
            projectExplorerTree.Nodes.Add(TraverseDirectory(openedProject.ProjectPath));
        }

        public void InitProjectManager()
        {
            projectExplorerTree.Nodes.Add("No project loaded!");
            /*
            //get the go path first
            string rootPath = SettingsClass.Instance.setupSettings.goPath + @"src\github.com\" + SettingsClass.Instance.setupSettings.githubUsername + @"\";

            if (!Directory.Exists(rootPath))
            {
                Output.OutputToConsole("No projects with current username");
                projectExplorerTree.Nodes.Add("No projects");
                return;
            }

            projectExplorerTree.Nodes.Add(TraverseDirectory(rootPath));
            */
        }

        private TreeNode TraverseDirectory(string path)
        {
            DirectoryInfo inf = new DirectoryInfo(path);
            TreeNode result = new TreeNode(inf.Name);

            foreach(var file in inf.GetFiles())
            {
                result.Nodes.Add(file.Name);
            }

            foreach (var subdirectory in inf.GetDirectories())
            {
                result.Nodes.Add(TraverseDirectory(subdirectory.FullName));
            }

            return result;
        }
    }
}
