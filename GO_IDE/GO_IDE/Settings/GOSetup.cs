using GO_IDE.IDE_Main;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace GO_IDE.Settings
{
    [System.Serializable]
    public class GOSetup
    {
        public string goPath = null;
        public string githubUsername = Environment.UserName;

        public bool GOPathPresent
        {
            get
            {
                if (goPath != null)
                    return true;
                else
                    return false;
            }
        }

        public GOSetup()
        {
            DefaultValues();
        }

        public string GetProjectRootPath()
        {
            return goPath + @"src\github.com\" + githubUsername;
        }

        private void DefaultValues()
        {
            goPath = Environment.GetEnvironmentVariable("GOROOT", EnvironmentVariableTarget.Machine);
            githubUsername = Environment.UserName;
        }

        public void SetGoPath(DirectoryInfo selectedDir)
        {
            if(File.Exists(selectedDir+"/bin/go.exe"))
            {
                Output.OutputToConsole("Good Go path, setting to this");
                goPath = selectedDir.FullName;
            }
            else
            {
                Output.OutputToConsole("Not a valid Go path, please try again");
            }
        }

        public void LoadGOSetup(GOSetup loadedGOSetup)
        {
            if(loadedGOSetup == null)
            {
                Output.OutputToConsole("No GO Setup settings found");
                return;
            }

            if(loadedGOSetup.goPath == null)
            {
                try
                {
                    goPath = Environment.GetEnvironmentVariable("GOROOT", EnvironmentVariableTarget.Machine);
                }
                catch(Exception ex)
                {
                    Output.OutputToConsole("Error! " + ex.Message);
                }
            }

            goPath = loadedGOSetup.goPath;
            githubUsername = loadedGOSetup.githubUsername;

            SettingsClass.Instance.setupSettings = this;
        }
    
        private void SaveGOSetup()
        {
            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "/Settings"))
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "/Settings");

            FileStream fs = new FileStream(AppDomain.CurrentDomain.BaseDirectory + @"\Settings\GOSetup.dat", FileMode.Create, FileAccess.Write);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, this);
        }   

        public void StartSetupMenu()
        {
            SettingsForm sForm = new SettingsForm();
            sForm.Show();
        }
    }
}
