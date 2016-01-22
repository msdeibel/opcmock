using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpcMock
{
    class ProtocolLine
    {
        public enum Actions { Set, Wait, Dummy }

        private Actions action;

        private string tagPath;
        private string tagValue;
        private string tagQualityInt;

        public ProtocolLine(string protocolLine)
        {
            if (string.IsNullOrWhiteSpace(protocolLine))
            {
                throw new ArgumentException("Parameter must not be empty or null", nameof(protocolLine));
            }

            ParseProtocolLine(protocolLine);
        }

        private void ParseProtocolLine(string protocolLine)
        {
            string[] lineParts = new string[0];

            try
            {
                lineParts = protocolLine.Split(';');

                action = (Actions) Enum.Parse(typeof (Actions), lineParts[0]);

                if (action.Equals(Actions.Dummy)) return;

                tagPath = lineParts[1];
                tagValue = lineParts[2];
                tagQualityInt = lineParts[3];
            }
            catch (ArgumentException exIa)
            {
                throw new ProtocolActionException("Illegal protocol action: " + lineParts[0], exIa);
            }

        }

        public Actions Action => action;

        public string TagPath => tagPath;

        public string TagValue => tagValue;

        public string TagQualityInt => tagQualityInt;

        
    }
}
