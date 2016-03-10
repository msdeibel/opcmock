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
            XmlDocument doc = new XmlDocument();
            doc.Load(projectFilePath);

            string projectName = doc.GetElementsByTagName("project_name")[0].InnerText;

            return new OpcMockProject(projectName);
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
