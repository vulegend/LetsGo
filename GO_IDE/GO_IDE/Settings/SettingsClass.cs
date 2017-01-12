using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace GO_IDE.Settings
{
    [System.Serializable]
    public class SettingsClass
    {
        [System.NonSerialized]
        private static SettingsClass _instance;

        public static SettingsClass Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SettingsClass();

                return _instance;
            }
        }

        public GOSetup setupSettings;
        public CodeEditorSettings codeSettings;

        public SettingsClass()
        {
            setupSettings = new GOSetup();
            codeSettings = new CodeEditorSettings();
        }

        public void LoadSettings()
        {
            if(File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"\Settings\IDESettings.dat"))
            {
                FileStream fs = new FileStream(AppDomain.CurrentDomain.BaseDirectory + @"\Settings\IDESettings.dat", FileMode.Open, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();
                SettingsClass loaded = (SettingsClass)bf.Deserialize(fs);

                setupSettings = loaded.setupSettings;
                setupSettings.LoadGOSetup(loaded.setupSettings);

                codeSettings = loaded.codeSettings;
                codeSettings.LoadEditorSettings(loaded.codeSettings);

                fs.Close();
            }
            else
            {
                SaveSettings();
            }
        }

        public void SaveSettings()
        {
            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "/Settings"))
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "/Settings");

            FileStream fs = new FileStream(AppDomain.CurrentDomain.BaseDirectory + @"\Settings\IDESettings.dat", FileMode.Create, FileAccess.Write);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, this);
            fs.Close();
        }
    }
}
