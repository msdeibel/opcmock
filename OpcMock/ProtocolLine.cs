using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpcMock
{
    public class ProtocolLine
    {
        public enum Actions { Set, Wait, Dummy }

        private Actions action;

        private string tagPath;
        private string tagValue;
        private string tagQualityInt;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="protocolLine">Format: "Set;tagPath;tagValue;192"</param>
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

                action = ParseAction(lineParts[0].Trim());

                if (IsDummyAction()) return;

                tagPath = lineParts[1].Trim();
                tagValue = lineParts[2].Trim();
                tagQualityInt = lineParts[3].Trim();
            }
            catch (ArgumentException exIa)
            {
                throw new ProtocolActionException("Illegal protocol action: " + lineParts[0], exIa);
            }

        }

        private static Actions ParseAction(string actionLinePart)
        {
            return (Actions)Enum.Parse(typeof(Actions), actionLinePart);
        }

        private bool IsDummyAction()
        {
            return action.Equals(Actions.Dummy);
        }

        public Actions Action => action;

        public string TagPath => tagPath;

        public string TagValue => tagValue;

        public string TagQualityInt => tagQualityInt;

        
    }
}
