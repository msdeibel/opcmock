using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpcMock
{
    public class ProtocolWriter
    {
        public string FolderPath { get; internal set; }
        public string ProjectName { get; internal set; }

        public ProtocolWriter(string folderPath, string projectName)
        {
            FolderPath = folderPath;
            ProjectName = projectName;
        }

        public void Save(OpcMockProtocol opcMockProtocol)
        {
            string protocolFilePath = FolderPath + Path.DirectorySeparatorChar + opcMockProtocol.Name + FileExtensionContants.FileExtensionProtocol;

            File.Create(protocolFilePath).Close();

            StringBuilder fileContentBuilder = new StringBuilder();

            foreach (ProtocolLine pl in opcMockProtocol.Lines)
            {
                fileContentBuilder.Append(pl.ToString() + Environment.NewLine);
            }

            File.WriteAllText(protocolFilePath, fileContentBuilder.ToString());
        }
    }
}
