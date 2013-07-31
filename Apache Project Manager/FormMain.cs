using System;
using System.IO;
using System.Windows.Forms;
using Apache_Project_Manager.Serialization;

namespace Apache_Project_Manager
{
    public partial class FormMain : Form
    {
        private const String ConfigFile = "config.xml";
        private const String DocumentRootTag = "DocumentRoot ";
        private Configuration _configuration;

        #region Interface Handlers

        /// <summary>
        /// Form constructor. 
        /// Initializes main components.
        /// </summary>
        public FormMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// After loading the main form, there's the need to center it, and 
        /// to load the information from the xml configuration file.
        /// </summary>
        private void FormMainLoad(object sender, EventArgs e)
        {
            CreateContextToolStrip();

            LoadConfiguration();
        }

        /// <summary>
        /// Adds a close button to the system tray icon
        /// </summary>
        private void CreateContextToolStrip()
        {
            contextMenuStrip.Items.Add(new ToolStripSeparator());
            contextMenuStrip.Items.Add(new ToolStripMenuItem("Close", null,ExitToolStripMenuItemClick));
        }

        /// <summary>
        /// Handler for the Resize event. 
        /// Puts a notify Icon on the tray when the window is minimized.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMainResize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
                Hide();
        }

        /// <summary>
        /// When the notify Icon on the tray is double-clicked, the
        /// window is restored
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NotifyIconMouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        /// <summary>
        /// Shows the file browser to look for the http.conf file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonBrowseFileClick(object sender, EventArgs e)
        {
            DialogResult dialogResult = openFileDialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                textBoxHttpConfPath.Text = openFileDialog.FileName;
                _configuration.ConfigFileName = openFileDialog.FileName;
                SaveConfiguration();
            }
        }

        /// <summary>
        /// Adds a project to the list. Asks first for the name and the location
        /// of the project, and if the user does cancel the operation, the project
        /// is added.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAddProjectClick(object sender, EventArgs e)
        {
            //ask for a name for the project
            FormInput inputDialog = new FormInput("Please indicate the new project's name:", "Add Project", "Project");

            if (inputDialog.ShowDialog() == DialogResult.OK)
            {
                //check if the name does not yet exist
                if (!_configuration.Projects.Exists(va => va.Name == inputDialog.InputText))
                {
                    //if it doesn't, ask for the path
                    DialogResult dialogResult = folderBrowserDialog.ShowDialog();

                    if (dialogResult == DialogResult.OK)
                    {
                        Project project = new Project(inputDialog.InputText, folderBrowserDialog.SelectedPath, false);
                        _configuration.Projects.Add(project);
                        AddProjectToList(project);
                        SaveConfiguration();
                    }
                }
                else
                {
                    MessageBox.Show("A project with that name has already been defined.", "Repeated Project Name", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }

        /// <summary>
        /// Removes the projects selected on the list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonRemoveProjectClick(object sender, EventArgs e)
        {
            if (listViewProjects.SelectedItems.Count > 0)
            {
                //find out the name of the project
                String selectedProjectName = listViewProjects.SelectedItems[0].SubItems[0].Text;

                //remove from the list of projects
                _configuration.Projects.RemoveAll(val => val.Name == selectedProjectName);

                //remove from the context menu
                ToolStripMenuItem selectedStripItem = GetToolStripMenuItemByName(selectedProjectName);
                contextMenuStrip.Items.Remove(selectedStripItem);

                //remove from the list
                listViewProjects.Items.Remove(listViewProjects.SelectedItems[0]);
            }

            //saves changes to the file
            SaveConfiguration();
        }

        /// <summary>
        /// Loads the selected project of the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonLoadProjectClick(object sender, EventArgs e)
        {
            if (listViewProjects.SelectedItems.Count > 0)
            {
                ListViewItem item = listViewProjects.SelectedItems[0];

                ChangeProject(item);
            }
        }

        /// <summary>
        /// Handler for the buttons of the contextMenu of the tray icon
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripItemClick(object sender, EventArgs e)
        {
            ListViewItem item = GetListViewItemByName(sender.ToString());

            if (item != null)
                ChangeProject(item);
        }

        #endregion
        
        #region Load and Save

        private void LoadConfiguration()
        {
            _configuration = File.Exists(ConfigFile) ? FileSerialization.ReadFromXmlFile<Configuration>(ConfigFile) : new Configuration();

            textBoxHttpConfPath.Text = _configuration.ConfigFileName;

            foreach (Project project in _configuration.Projects)
            {
                AddProjectToList(project);
            }
        }


        private void SaveConfiguration()
        {
            FileSerialization.WriteToXmlFile(_configuration, ConfigFile);
        }

        private void RefreshContextMenu()
        {


            foreach (Project project in _configuration.Projects)
            {
                AddProjectToList(project);
            }
        }


        /*
        /// <summary>
        /// Loads configuration information from a XML file
        /// </summary>
        private void LoadXml()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(ConfigFile);

            try
            {
                XmlElement root = doc.DocumentElement;

                //loads the Http_Conf_Location file location
                textBoxHttpLocation.Text = root["Http_Conf_Location"].InnerText;

                XmlNodeList nodes = root.SelectNodes("//Project");

                foreach (XmlNode node in nodes)
                {

                    string name = node["Name"].InnerText;
                    string location = node["Location"].InnerText;
                    string loaded = node["Loaded"].InnerText;

                    AddProjectToList(name, location, loaded);

                    //change the notify icon text of the tray
                    if (loaded == "Yes")
                    {
                        notifyIcon.Text = "Apache Project Manager: " + name + " loaded.";

                        ToolStripMenuItem selectedStripItem = GetToolStripMenuItemByName(name);
                        selectedStripItem.Checked = true;
                    }
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Could not load configurations. Configuration file may be corrupt.",
                                "Error loading Configuration File", MessageBoxButtons.OK, MessageBoxIcon.Error,
                                MessageBoxDefaultButton.Button1);
            }
        }


        /// <summary>
        /// Saves all the information to a XML File
        /// </summary>
        private void SavetoXml()
        {
            //creates the file in the same directory as the executable file
            var xmlWriter = new XmlTextWriter(ConfigFile, null) { Formatting = Formatting.Indented, Indentation = 4 };

            // Opens the document and adds the main "Configuration" tag
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Configuration");

            //adds the location of the http.conf file
            xmlWriter.WriteStartElement("Http_Conf_Location");
            xmlWriter.WriteString(textBoxHttpLocation.Text);
            xmlWriter.WriteEndElement();

            //adds information about each project
            foreach (ListViewItem item in listViewProjects.Items)
            {
                //begins the project tag
                xmlWriter.WriteStartElement("Project");

                //saves the name of the project
                xmlWriter.WriteStartElement("Name");
                xmlWriter.WriteString(item.Text);
                xmlWriter.WriteEndElement();

                //saves the location of the project
                xmlWriter.WriteStartElement("Location");
                xmlWriter.WriteString(item.SubItems[1].Text);
                xmlWriter.WriteEndElement();

                //saves the status of the project
                xmlWriter.WriteStartElement("Loaded");
                xmlWriter.WriteString(item.SubItems[2].Text);
                xmlWriter.WriteEndElement();

                //closes the project tag
                xmlWriter.WriteEndElement();
            }

            //ends the configuration tag
            xmlWriter.WriteEndElement();

            // Ends the document and the writer
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
        }*/

        #endregion

        #region Getters and Setters

        /// <summary>
        /// Searches for a project from the list through it's name
        /// </summary>
        /// <param name="name">Name of the project (first Column)</param>
        /// <returns>Item of the list that contains that name</returns>
        private ListViewItem GetListViewItemByName(String name)
        {
            foreach(ListViewItem item in listViewProjects.Items)
            {
                if (item.Text == name)
                    return item;
            }
            return null;
        }

        /// <summary>
        /// Searches for a project from the context menu list through it's name
        /// </summary>
        /// <param name="name">Name of the project (first Column)</param>
        /// <returns>Item of the menu that contains that name</returns>
        private ToolStripMenuItem GetToolStripMenuItemByName(String name)
        {
            foreach (ToolStripMenuItem item in contextMenuStrip.Items)
            {
                if (item.Text == name)
                    return item;
            }
            return null;
        }

        #endregion


        /// <summary>
        /// Adds a project to the list
        /// </summary>
        /// <param name="project">Project object.</param>
        private void AddProjectToList(Project project)
        {
            listViewProjects.Items.Add(new ListViewItem(new[] { project.Name, project.Path, project.LoadedString }));


            int listedProjectCount = contextMenuStrip.Items.Count - 2;


            //adds also an entry to the right-button menu of the tray icon
            ToolStripMenuItem item = new ToolStripMenuItem(project.Name, null, ToolStripItemClick);
            //contextMenuStrip.Items.Insert(_configuration.Projects.Count, item);// Add(item);
            //contextMenuStrip.Items.Add(item);
            contextMenuStrip.Items.Insert(listedProjectCount, item);

            if(project.Loaded)
                item.Checked = true;
        }


        /// <summary>
        /// Replaces the document root line in the http.conf file. Checks and warns about possible
        /// errors while acessing the file.
        /// </summary>
        /// <param name="filePath">Path of the http.conf file</param>
        /// <param name="projectPath">Path of the new DocumentRoot</param>
        /// <returns></returns>
        public static bool ReplaceDocumentRoot(String filePath, String projectPath)
        {
            //if the path is empty, do not advance
            if (filePath == "")
            {
                MessageBox.Show("Please choose a path for the http.conf file.", "Empty Path", MessageBoxButtons.OK,
                                MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }

            //if the path is invalid, do not advance
            if (!File.Exists(filePath))
            {
                MessageBox.Show("Please choose a valid path for the http.conf file.", "Invalid Path",
                                MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }

            //otherwise, try to change the file
            try
            {
                String oldProjectPath = "";

                //first, find the loaded project (might not be the one that we think it is)
                StreamReader reader = new StreamReader(filePath);

                while (!reader.EndOfStream)
                {
                    String line = reader.ReadLine();

                    //if the line is found, replaces it
                    if (line != null && line.StartsWith(DocumentRootTag))
                        oldProjectPath = line.Substring(DocumentRootTag.Length);
                }
                reader.Close();

                //if the old value wasn't found, the file is invalid
                if (oldProjectPath == "")
                {
                    MessageBox.Show(
                        "Could not change the project. Please check if the chosen file is a valid http.conf file.",
                        "Invalid http.conf File", MessageBoxButtons.OK, MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1);
                    return false;
                }

                //if the file is valid, replace the oldProjectPath with the new one 
                ReplaceInFile(filePath, oldProjectPath, "\"" + projectPath + "\"");
            }
            catch (IOException)
            {
                //in case the file is in use or write-protected
                MessageBox.Show(
                    "An IO Error ocurred while attempting to access the file. Please check if the file is not write-protected or currently in use.",
                    "Error Acessing File", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Replaces text in a file.
        /// </summary>
        /// <param name="filePath">Path of the text file.</param>
        /// <param name="searchText">Text to search for.</param>
        /// <param name="replaceText">Text to replace the search text.</param>
        static public void ReplaceInFile(string filePath, string searchText, string replaceText)
        {
            StreamReader reader = new StreamReader(filePath);
            string content = reader.ReadToEnd();
            reader.Close();
            
            content = content.Replace(searchText, replaceText);

            StreamWriter writer = new StreamWriter(filePath);
            writer.Write(content);
            writer.Close();
        }




        /// <summary>
        /// Changes the selected project.
        /// </summary>
        /// <param name="item"></param>
        private void ChangeProject(ListViewItem item)
        {
            //attemps to replace the string
            if (ReplaceDocumentRoot(textBoxHttpConfPath.Text, item.SubItems[1].Text))
            {
                foreach (Project project in _configuration.Projects)
                {
                    project.Loaded = project.Name == item.SubItems[0].Text;
                }
                    
                //if it succeds
                //deselect all items first
                foreach (ListViewItem otherItem in listViewProjects.Items)
                    otherItem.SubItems[2].Text = "No";

                //says the the item is selected
                item.SubItems[2].Text = "Yes";
                item.Checked = false;

                //change the notify icon text of the tray
                notifyIcon.Text = "Apache Project Manager: " + item.Text + " loaded.";

                //unchecks all the choices of the contextmenu
                for (int i = 0; i < contextMenuStrip.Items.Count-2; i++)
                {
                    ((ToolStripMenuItem) contextMenuStrip.Items[i]).Checked = false;
                }
                //foreach (ToolStripMenuItem stripItem in contextMenuStrip.Items)
                //    stripItem.Checked = false;

                ToolStripMenuItem selectedStripItem = GetToolStripMenuItemByName(item.Text);
                selectedStripItem.Checked = true;

                //saves the selected item
                SaveConfiguration();
            }
        }

        private void ExitToolStripMenuItemClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormMainFormClosed(object sender, FormClosedEventArgs e)
        {
            SaveConfiguration();
        }

        private void AboutToolStripMenuItemClick(object sender, EventArgs e)
        {
            FormAbout formAbout = new FormAbout();
            formAbout.ShowDialog();
        }


    }
}