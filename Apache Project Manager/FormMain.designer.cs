namespace Apache_Project_Manager
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.labelHttpConf = new System.Windows.Forms.Label();
            this.buttonAddProject = new System.Windows.Forms.Button();
            this.buttonRemoveProject = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.buttonBrowseFile = new System.Windows.Forms.Button();
            this.listViewProjects = new System.Windows.Forms.ListView();
            this.columnProjectName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnProjectLocation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnProjectLoaded = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonLoadProject = new System.Windows.Forms.Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelTop = new System.Windows.Forms.Panel();
            this.textBoxHttpConfPath = new System.Windows.Forms.TextBox();
            this.panelMiddle = new System.Windows.Forms.Panel();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.panelMiddle.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelHttpConf
            // 
            this.labelHttpConf.AutoSize = true;
            this.labelHttpConf.Location = new System.Drawing.Point(9, 9);
            this.labelHttpConf.Name = "labelHttpConf";
            this.labelHttpConf.Size = new System.Drawing.Size(135, 17);
            this.labelHttpConf.TabIndex = 1;
            this.labelHttpConf.Text = "Httpd.conf Location:";
            // 
            // buttonAddProject
            // 
            this.buttonAddProject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddProject.Location = new System.Drawing.Point(327, 8);
            this.buttonAddProject.Name = "buttonAddProject";
            this.buttonAddProject.Size = new System.Drawing.Size(100, 25);
            this.buttonAddProject.TabIndex = 3;
            this.buttonAddProject.Text = "Add Project";
            this.buttonAddProject.UseVisualStyleBackColor = true;
            this.buttonAddProject.Click += new System.EventHandler(this.ButtonAddProjectClick);
            // 
            // buttonRemoveProject
            // 
            this.buttonRemoveProject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRemoveProject.Location = new System.Drawing.Point(433, 8);
            this.buttonRemoveProject.Name = "buttonRemoveProject";
            this.buttonRemoveProject.Size = new System.Drawing.Size(126, 25);
            this.buttonRemoveProject.TabIndex = 4;
            this.buttonRemoveProject.Text = "Remove Project";
            this.buttonRemoveProject.UseVisualStyleBackColor = true;
            this.buttonRemoveProject.Click += new System.EventHandler(this.ButtonRemoveProjectClick);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "http.conf";
            // 
            // buttonBrowseFile
            // 
            this.buttonBrowseFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowseFile.Location = new System.Drawing.Point(459, 5);
            this.buttonBrowseFile.Name = "buttonBrowseFile";
            this.buttonBrowseFile.Size = new System.Drawing.Size(100, 24);
            this.buttonBrowseFile.TabIndex = 6;
            this.buttonBrowseFile.Text = "Browse...";
            this.buttonBrowseFile.UseVisualStyleBackColor = true;
            this.buttonBrowseFile.Click += new System.EventHandler(this.ButtonBrowseFileClick);
            // 
            // listViewProjects
            // 
            this.listViewProjects.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnProjectName,
            this.columnProjectLocation,
            this.columnProjectLoaded});
            this.listViewProjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewProjects.FullRowSelect = true;
            this.listViewProjects.Location = new System.Drawing.Point(10, 10);
            this.listViewProjects.Margin = new System.Windows.Forms.Padding(10);
            this.listViewProjects.MultiSelect = false;
            this.listViewProjects.Name = "listViewProjects";
            this.listViewProjects.Size = new System.Drawing.Size(549, 178);
            this.listViewProjects.TabIndex = 7;
            this.listViewProjects.UseCompatibleStateImageBehavior = false;
            this.listViewProjects.View = System.Windows.Forms.View.Details;
            // 
            // columnProjectName
            // 
            this.columnProjectName.Text = "Name";
            this.columnProjectName.Width = 180;
            // 
            // columnProjectLocation
            // 
            this.columnProjectLocation.Text = "Location";
            this.columnProjectLocation.Width = 271;
            // 
            // columnProjectLoaded
            // 
            this.columnProjectLoaded.Text = "Loaded?";
            // 
            // buttonLoadProject
            // 
            this.buttonLoadProject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonLoadProject.Location = new System.Drawing.Point(12, 8);
            this.buttonLoadProject.Name = "buttonLoadProject";
            this.buttonLoadProject.Size = new System.Drawing.Size(100, 25);
            this.buttonLoadProject.TabIndex = 9;
            this.buttonLoadProject.Text = "Load Project";
            this.buttonLoadProject.UseVisualStyleBackColor = true;
            this.buttonLoadProject.Click += new System.EventHandler(this.ButtonLoadProjectClick);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Apache Project Manager: No Project Loaded";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIconMouseDoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(61, 4);
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.SelectedPath = "C:\\";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(569, 28);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(102, 24);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(119, 24);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItemClick);
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.textBoxHttpConfPath);
            this.panelTop.Controls.Add(this.buttonBrowseFile);
            this.panelTop.Controls.Add(this.labelHttpConf);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 28);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(569, 28);
            this.panelTop.TabIndex = 11;
            // 
            // textBoxHttpConfPath
            // 
            this.textBoxHttpConfPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxHttpConfPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxHttpConfPath.Location = new System.Drawing.Point(150, 5);
            this.textBoxHttpConfPath.Name = "textBoxHttpConfPath";
            this.textBoxHttpConfPath.ReadOnly = true;
            this.textBoxHttpConfPath.Size = new System.Drawing.Size(300, 23);
            this.textBoxHttpConfPath.TabIndex = 7;
            // 
            // panelMiddle
            // 
            this.panelMiddle.Controls.Add(this.listViewProjects);
            this.panelMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMiddle.Location = new System.Drawing.Point(0, 56);
            this.panelMiddle.Name = "panelMiddle";
            this.panelMiddle.Padding = new System.Windows.Forms.Padding(10);
            this.panelMiddle.Size = new System.Drawing.Size(569, 198);
            this.panelMiddle.TabIndex = 12;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.buttonLoadProject);
            this.panelBottom.Controls.Add(this.buttonAddProject);
            this.panelBottom.Controls.Add(this.buttonRemoveProject);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 254);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(569, 45);
            this.panelBottom.TabIndex = 13;
            // 
            // FormMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(569, 299);
            this.Controls.Add(this.panelMiddle);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Apache Project Manager";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMainFormClosed);
            this.Load += new System.EventHandler(this.FormMainLoad);
            this.Resize += new System.EventHandler(this.FormMainResize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelMiddle.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelHttpConf;
        private System.Windows.Forms.Button buttonAddProject;
        private System.Windows.Forms.Button buttonRemoveProject;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button buttonBrowseFile;
        private System.Windows.Forms.ListView listViewProjects;
        private System.Windows.Forms.ColumnHeader columnProjectName;
        private System.Windows.Forms.ColumnHeader columnProjectLocation;
        private System.Windows.Forms.ColumnHeader columnProjectLoaded;
        private System.Windows.Forms.Button buttonLoadProject;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelMiddle;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TextBox textBoxHttpConfPath;
    }
}

