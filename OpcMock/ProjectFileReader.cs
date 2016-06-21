using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace OpcMock
{
    public class ProjectFileReader
    {
        private OpcMockProject opcMockProject;
        private string projectFileContent;
        private string projectFilePath;

        public ProjectFileReader(string projectFilePath)
        {
            this.projectFilePath = projectFilePath;
            this.projectFileContent = File.ReadAllText(projectFilePath);

            this.opcMockProject = ParseFileContent();
        }

        private OpcMockProject ParseFileContent()
        {
            OpcMockProject omp; 

            XmlDocument doc = new XmlDocument();
            doc.Load(projectFilePath);

            string projectName = doc.GetElementsByTagName("project_name")[0].InnerText;

            omp = new OpcMockProject(projectName);

            List<string> protocolNames = new List<string>();

            XmlNodeList protocolTags = doc.GetElementsByTagName("protocol");

            foreach (XmlNode protocolTag in protocolTags)
            {
                omp.AddProtocol(new OpcMockProtocol(protocolTag.InnerText));
            }

            return omp;
        }

        public string ProjectFileContent
        {
            get { return projectFileContent; }
        }

        public OpcMockProject OpcMockProject
        {
            get { return opcMockProject; }
        }
    }
}
