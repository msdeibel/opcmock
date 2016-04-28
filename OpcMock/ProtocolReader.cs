using System;
using System.IO;
namespace OpcMock
{
    public class ProtocolReader
    {
        public string FilePath { get; internal set; }
        public string[] LinesFromFile { get; internal set; }

        public ProtocolReader(string filePath)
        {
            FilePath = filePath;
        }

        public void Load()
        {
            LinesFromFile = File.ReadAllLines(FilePath);
        }
    }
}