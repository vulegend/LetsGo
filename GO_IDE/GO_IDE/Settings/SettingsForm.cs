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

namespace GO_IDE.Settings
{
    public partial class SettingsForm : Form
    {
        public Dictionary<SettingPanelsEnum, Panel> settingsPanels = new Dictionary<SettingPanelsEnum, Panel>();
        private Panel _lastOpenedPanel;

        public SettingsForm()
        {
            InitializeComponent();
            LoadDictionary();
        }

        private void LoadDictionary()
        {
            globalSettingsPanel.Visible = false;
            settingsPanels.Add(SettingPanelsEnum.GlobalSettings, globalSettingsPanel);
            editorSettingsGlobalPanel.Visible = false;
            settingsPanels.Add(SettingPanelsEnum.EditorSettingsGlobal, editorSettingsGlobalPanel);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                SettingsClass.Instance.setupSettings.SetGoPath(new System.IO.DirectoryInfo(folderBrowserDialog1.SelectedPath));
            }
        }

        public void PanelInitialised(SettingPanelsEnum panelInit)
        {
            if(_lastOpenedPanel != null)
                _lastOpenedPanel.Visible = false;
            switch(panelInit)
            {
                case SettingPanelsEnum.GlobalSettings:
                    settingsPanels[SettingPanelsEnum.GlobalSettings].Visible = true;
                    _lastOpenedPanel = settingsPanels[SettingPanelsEnum.GlobalSettings];
                    InitGlobalSettings();
                    break;
                case SettingPanelsEnum.EditorSettingsGlobal:
                    settingsPanels[SettingPanelsEnum.EditorSettingsGlobal].Visible = true;
                    _lastOpenedPanel = settingsPanels[SettingPanelsEnum.EditorSettingsGlobal];
                    InitEditorSettingsGlobal();
                    break;
            }
        }

        public void NodeSwitched(string nodeName)
        {
            string query = nodeName.Replace(" ", "");
            SettingPanelsEnum panel = (SettingPanelsEnum)Enum.Parse(typeof(SettingPanelsEnum), query);
            PanelInitialised(panel);
        }

        private void InitGlobalSettings()
        {
            goPathTextbox.Text = SettingsClass.Instance.setupSettings.goPath;
            githubUsername.Text = SettingsClass.Instance.setupSettings.githubUsername;
        }

        private void InitEditorSettingsGlobal()
        {
            backgroundColorText.Text = SettingsClass.Instance.codeSettings.backColor.ToString();
            backColorPicker.BackColor = UtilsClass.IntToColor(SettingsClass.Instance.codeSettings.backColor);
        }

        private void setUsernameGithub_Click(object sender, EventArgs e)
        {
            string checkValid = githubUsername.Text;

            if(checkValid.Contains("\\") || checkValid.Contains("/"))
            {
                Output.OutputToConsole("Name contains invalid characters, try again");
                return;
            }

            SettingsClass.Instance.setupSettings.githubUsername = checkValid;
        }

        private void resetGithub_Click(object sender, EventArgs e)
        {
            SettingsClass.Instance.setupSettings.githubUsername = Environment.UserName;
            githubUsername.Text = Environment.UserName;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Nodes.Count == 0)
            {
                // NodeSwitched(e.Node.Text);
                if (e.Node.Parent != null)
                    NodeSwitched(e.Node.Parent.Text + " " + e.Node.Text);
                else
                    NodeSwitched(e.Node.Text);
            }
        }

        private void backColorPicker_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                backColorPicker.BackColor = colorDialog1.Color;
                backgroundColorText.Text = SettingsClass.Instance.codeSettings.backColor.ToString();
            }
        }

        private void setColorButton_Click(object sender, EventArgs e)
        {
            SettingsClass.Instance.codeSettings.backColor = backColorPicker.BackColor.ToArgb();
        }
    }

    public enum SettingPanelsEnum
    {
        GlobalSettings,
        EditorSettingsGlobal,
        EditorSettingsSyntaxHighlighting
    }
}
