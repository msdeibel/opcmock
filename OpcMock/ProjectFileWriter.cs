using System;
using System.Collections.Generic;
using System.IO;

namespace OpcMock
{
    public class ProjectFileWriter
    {
        private string projectFilePath;
        private string content;
        private string projectName;
        private List<String> protocolNames; 

        public ProjectFileWriter(string projectFilePath)
        {
            this.projectFilePath = projectFilePath;
            this.content = string.Empty;
            this.projectName = Path.GetFileNameWithoutExtension(projectFilePath);
            this.protocolNames = new List<string>();
        }

        public ProjectFileWriter(string projectFilePath, string projectName) : this(projectFilePath)
        {
            this.projectName = projectName;
        }

        private void SaveProjectFile()
        {
            File.WriteAllText(projectFilePath, content);
        }

        public void SaveProjectFileContent()
        {
            string content =   "<project>" + Environment.NewLine
                             + "    <project_name>" + projectName + "</project_name>" + Environment.NewLine
                             + "    <project_data_file>" + projectName + OpcMockConstants.FileExtensionData + "</project_data_file>" + Environment.NewLine;

            if (0 == protocolNames.Count)
            {
                content += "    <protocol_list/>" + Environment.NewLine;
            }
            else
            {
                content += "    <protocol_list>" + Environment.NewLine;

                foreach (string protocolName in protocolNames)
                {
                    content += "        <protocol>" + protocolName + "</protocol>" + Environment.NewLine;
                }

                content += "    </protocol_list>" + Environment.NewLine;
            }
            
            content += "</project>";

            this.content = content;

            SaveProjectFile();
        }

        public string ProjectFilePath
        {
            get { return projectFilePath; }
        }

        public string ProjectName
        {
            get { return projectName; }
        }

        public List<string> ProtocolNames
        {
            get { return protocolNames; }
        }

        public void AddProtocolName(string newProtocolName)
        {
            if (!protocolNames.Contains(newProtocolName))
            {
                protocolNames.Add(newProtocolName);
            }
        }

        ///TODO: Add wrapper methods for ProtocolNames; at least Add and Remove
    }
}
