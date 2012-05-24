using System;

namespace Apache_Project_Manager
{
    [Serializable]
    public class Project
    {
        public String Name { get; set; }
        public String Path { get; set; }
        public bool Loaded { get; set; }

        public Project()
        {
        }

        public Project(string name, string path, bool loaded)
        {
            Name = name;
            Path = path;
            Loaded = loaded;
        }

        public String LoadedString { get { return Loaded ? "Yes" : "No"; } }
    }
}
