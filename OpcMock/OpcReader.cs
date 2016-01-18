using System.Collections.Generic;

namespace OpcMock
{
    public interface OpcReader
    {
        List<OpcTag> ReadAllTags();
    }
}
