using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpcMock
{
    public interface OpcReader
    {
        List<OpcTag> ReadAllTags();

        OpcTag ReadTag(string tagPath);
    }
}
