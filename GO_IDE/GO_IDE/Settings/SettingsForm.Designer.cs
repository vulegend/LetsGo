namespace GO_IDE.Settings
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Global Settings");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Global");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Syntax Highlighting");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Editor Settings", new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode3});
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.editorSettingsGlobalPanel = new System.Windows.Forms.Panel();
            this.setColorButton = new System.Windows.Forms.Button();
            this.backgroundColorText = new System.Windows.Forms.TextBox();
            this.backColorPicker = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.globalSettingsPanel = new System.Windows.Forms.Panel();
            this.resetGithub = new System.Windows.Forms.Button();
            this.setUsernameGithub = new System.Windows.Forms.Button();
            this.githubUsername = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.goPathTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.editorSettingsGlobalPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.backColorPicker)).BeginInit();
            this.globalSettingsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.editorSettingsGlobalPanel);
            this.splitContainer1.Panel2.Controls.Add(this.globalSettingsPanel);
            this.splitContainer1.Size = new System.Drawing.Size(516, 530);
            this.splitContainer1.SplitterDistance = 145;
            this.splitContainer1.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Node0";
            treeNode1.Text = "Global Settings";
            treeNode2.Name = "Node1";
            treeNode2.Text = "Global";
            treeNode3.Name = "Node2";
            treeNode3.Text = "Syntax Highlighting";
            treeNode4.Name = "Node0";
            treeNode4.Text = "Editor Settings";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode4});
            this.treeView1.Size = new System.Drawing.Size(145, 530);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // editorSettingsGlobalPanel
            // 
            this.editorSettingsGlobalPanel.Controls.Add(this.setColorButton);
            this.editorSettingsGlobalPanel.Controls.Add(this.backgroundColorText);
            this.editorSettingsGlobalPanel.Controls.Add(this.backColorPicker);
            this.editorSettingsGlobalPanel.Controls.Add(this.label3);
            this.editorSettingsGlobalPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editorSettingsGlobalPanel.Location = new System.Drawing.Point(0, 0);
            this.editorSettingsGlobalPanel.Name = "editorSettingsGlobalPanel";
            this.editorSettingsGlobalPanel.Size = new System.Drawing.Size(367, 530);
            this.editorSettingsGlobalPanel.TabIndex = 7;
            // 
            // setColorButton
            // 
            this.setColorButton.Location = new System.Drawing.Point(17, 51);
            this.setColorButton.Name = "setColorButton";
            this.setColorButton.Size = new System.Drawing.Size(75, 23);
            this.setColorButton.TabIndex = 3;
            this.setColorButton.Text = "Set Color";
            this.setColorButton.UseVisualStyleBackColor = true;
            this.setColorButton.Click += new System.EventHandler(this.setColorButton_Click);
            // 
            // backgroundColorText
            // 
            this.backgroundColorText.Location = new System.Drawing.Point(6, 25);
            this.backgroundColorText.Name = "backgroundColorText";
            this.backgroundColorText.Size = new System.Drawing.Size(100, 20);
            this.backgroundColorText.TabIndex = 2;
            // 
            // backColorPicker
            // 
            this.backColorPicker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.backColorPicker.Location = new System.Drawing.Point(112, 25);
            this.backColorPicker.Name = "backColorPicker";
            this.backColorPicker.Size = new System.Drawing.Size(27, 20);
            this.backColorPicker.TabIndex = 1;
            this.backColorPicker.TabStop = false;
            this.backColorPicker.Click += new System.EventHandler(this.backColorPicker_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Editor Background Color";
            // 
            // globalSettingsPanel
            // 
            this.globalSettingsPanel.Controls.Add(this.resetGithub);
            this.globalSettingsPanel.Controls.Add(this.setUsernameGithub);
            this.globalSettingsPanel.Controls.Add(this.githubUsername);
            this.globalSettingsPanel.Controls.Add(this.label2);
            this.globalSettingsPanel.Controls.Add(this.button1);
            this.globalSettingsPanel.Controls.Add(this.goPathTextbox);
            this.globalSettingsPanel.Controls.Add(this.label1);
            this.globalSettingsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.globalSettingsPanel.Location = new System.Drawing.Point(0, 0);
            this.globalSettingsPanel.Name = "globalSettingsPanel";
            this.globalSettingsPanel.Size = new System.Drawing.Size(367, 530);
            this.globalSettingsPanel.TabIndex = 0;
            // 
            // resetGithub
            // 
            this.resetGithub.Location = new System.Drawing.Point(180, 152);
            this.resetGithub.Name = "resetGithub";
            this.resetGithub.Size = new System.Drawing.Size(92, 23);
            this.resetGithub.TabIndex = 6;
            this.resetGithub.Text = "Reset";
            this.resetGithub.UseVisualStyleBackColor = true;
            this.resetGithub.Click += new System.EventHandler(this.resetGithub_Click);
            // 
            // setUsernameGithub
            // 
            this.setUsernameGithub.Location = new System.Drawing.Point(71, 152);
            this.setUsernameGithub.Name = "setUsernameGithub";
            this.setUsernameGithub.Size = new System.Drawing.Size(92, 23);
            this.setUsernameGithub.TabIndex = 5;
            this.setUsernameGithub.Text = "Set Username";
            this.setUsernameGithub.UseVisualStyleBackColor = true;
            this.setUsernameGithub.Click += new System.EventHandler(this.setUsernameGithub_Click);
            // 
            // githubUsername
            // 
            this.githubUsername.Location = new System.Drawing.Point(6, 126);
            this.githubUsername.Name = "githubUsername";
            this.githubUsername.Size = new System.Drawing.Size(349, 20);
            this.githubUsername.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Github Username";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(133, 60);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Set Path";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // goPathTextbox
            // 
            this.goPathTextbox.Location = new System.Drawing.Point(3, 34);
            this.goPathTextbox.Name = "goPathTextbox";
            this.goPathTextbox.ReadOnly = true;
            this.goPathTextbox.Size = new System.Drawing.Size(352, 20);
            this.goPathTextbox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Go Path";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 530);
            this.Controls.Add(this.splitContainer1);
            this.Name = "SettingsForm";
            this.Text = "Setttings";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.editorSettingsGlobalPanel.ResumeLayout(false);
            this.editorSettingsGlobalPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.backColorPicker)).EndInit();
            this.globalSettingsPanel.ResumeLayout(false);
            this.globalSettingsPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Panel globalSettingsPanel;
        private System.Windows.Forms.TextBox goPathTextbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button resetGithub;
        private System.Windows.Forms.Button setUsernameGithub;
        private System.Windows.Forms.TextBox githubUsername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel editorSettingsGlobalPanel;
        private System.Windows.Forms.Button setColorButton;
        private System.Windows.Forms.TextBox backgroundColorText;
        private System.Windows.Forms.PictureBox backColorPicker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}