using System;
using System.Collections.Generic;

namespace Apache_Project_Manager
{
    [Serializable]
    public class Configuration
    {
        public String ConfigFileName { get; set; }
        public List<Project> Projects { get; set; }

        public Configuration()
        {
            ConfigFileName = String.Empty;
            Projects = new List<Project>();
        }

        public Configuration(string configFileName)
        {
            ConfigFileName = configFileName;
            Projects = new List<Project>();
        }
    }
}
