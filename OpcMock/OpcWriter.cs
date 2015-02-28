using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpcMock
{
    public interface OpcWriter
    {
        void WriteAllTags(List<OpcTag> opcTags);
    }
}
