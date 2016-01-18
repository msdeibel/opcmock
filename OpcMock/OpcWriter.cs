using System.Collections.Generic;


namespace OpcMock
{
    public interface OpcWriter
    {
        void WriteAllTags(List<OpcTag> opcTags);

        void WriteSingleTag(OpcTag opcTag);
    }
}
