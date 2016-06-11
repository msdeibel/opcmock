using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace OpcMock
{
    public class ProjectFileWriter
    {
        private OpcMockProject opcMockProject;
        private string projectFolderPath;
        private string content;

        public ProjectFileWriter(OpcMockProject opcMockProject, string projectFolderPath)
        {
            this.projectFolderPath = projectFolderPath;
            this.opcMockProject = opcMockProject;
            this.content = string.Empty;
        }

        private string GetProjectFilePath()
        {
            return projectFolderPath + Path.DirectorySeparatorChar + opcMockProject.Name + OpcMockConstants.FileExtensionProject;
        }

        public void Save()
        {
            StringBuilder stringBuilder = new StringBuilder();
            string twoSpaces = "  ";

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = twoSpaces;
            settings.OmitXmlDeclaration = true;

            XmlWriter xmlWriter = XmlWriter.Create(stringBuilder, settings);

            xmlWriter.WriteStartDocument(true);

            xmlWriter.WriteStartElement("project");

            xmlWriter.WriteElementString("project_name", opcMockProject.Name);

            if (0 == opcMockProject.Protocols.Count)
            {
                xmlWriter.WriteElementString("protocol_list", string.Empty);
            }
            else
            {
                xmlWriter.WriteStartElement("protocol_list");

                foreach (OpcMockProtocol omp in opcMockProject.Protocols)
                {
                    xmlWriter.WriteElementString("protocol", omp.Name);
                }

                xmlWriter.WriteEndElement();
            }

            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();

            xmlWriter.Flush();

            content = stringBuilder.ToString();

            File.WriteAllText(GetProjectFilePath(), content);
        }

        public string FilePath
        {
            get { return GetProjectFilePath(); }
        }

        public string FolderPath
        {
            get { return projectFolderPath; }
        }

        ///TODO: Add wrapper methods for ProtocolNames; at least Add and Remove
    }
}
