using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace OpcMock
{
    public class ProjectFileWriter
    {
        private string projectFilePath;
        private string content;

        public ProjectFileWriter(string projectFilePath)
        {
            this.projectFilePath = projectFilePath;
            this.content = string.Empty;
        }

        private void SaveProjectFile()
        {
            File.WriteAllText(projectFilePath, content);
        }

        public void SaveProjectFileContent(string content)
        {
            this.content = content;

            SaveProjectFile();
        }

        public string ProjectFilePath
        {
            get { return projectFilePath; }
        }
    }
}
