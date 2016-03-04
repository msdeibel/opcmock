using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

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

        public ProjectFileWriter(string projectFilePath, string projectName) : this(projectFilePath + Path.DirectorySeparatorChar + projectName + FileExtensionContants.FileExtensionProject)
        {
            this.projectName = projectName;
        }

        private void SaveProjectFile()
        {
            File.WriteAllText(projectFilePath, content);
        }

        public void SaveProjectFileContent()
        {
            StringBuilder stringBuilder = new StringBuilder();

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "    ";
            settings.OmitXmlDeclaration = true;

            XmlWriter xmlWriter = XmlWriter.Create(stringBuilder, settings);

            xmlWriter.WriteStartDocument(true);

            xmlWriter.WriteStartElement("project");

            xmlWriter.WriteElementString("project_name", projectName);
            xmlWriter.WriteElementString("project_data_file", projectName + OpcMockConstants.FileExtensionData);

            if (0 == protocolNames.Count)
            {
                xmlWriter.WriteElementString("protocol_list", string.Empty);
            }
            else
            {
                xmlWriter.WriteStartElement("protocol_list");

                foreach (string protocolName in protocolNames)
                {
                    xmlWriter.WriteElementString("protocol", protocolName);
                }

                xmlWriter.WriteEndElement();
            }

            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();

            xmlWriter.Flush();

            content = stringBuilder.ToString();

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

        public string FolderPath
        {
            get { return Path.GetDirectoryName(projectFilePath); }
        }

        ///TODO: Add wrapper methods for ProtocolNames; at least Add and Remove
    }
}
