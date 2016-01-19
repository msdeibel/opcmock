using System.Security.Cryptography;

namespace OpcMock
{
    public class OpcTag
    {
        /// <summary>
        /// Tag quality representation as string and corresponding integer value
        /// </summary>
        public enum OpcTagQuality
        {
            Bad = 0,
            Unknown = 8,
            Good = 192
        }

        /// <summary>
        /// Initialize tag with Unknown quality
        /// </summary>
        /// <param name="path">Full path of the tag on the server</param>
        /// <param name="tagValue">Initial value</param>
        public OpcTag(string path, string tagValue)
        {
            Path = path;
            Value = tagValue;

            Quality = OpcTagQuality.Unknown;
        }

        /// <summary>
        /// Initialize Tag
        /// </summary>
        /// <param name="path">Full path of the tag on the server</param>
        /// <param name="tagValue">Initial value</param>
        /// <param name="tagQuality">Initial quality</param>
        public OpcTag(string path, string tagValue, OpcTagQuality tagQuality)
        {
            Path = path;
            Value = tagValue;
            Quality = tagQuality;
        }

        #region Getters and setters

        /// <summary>
        /// Full path of the tag on the server
        /// </summary>
        public string Path { get; }

        /// <summary>
        /// Gets or sets the string representation of the tag value
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets the tag quality
        /// </summary>
        public OpcTagQuality Quality { get; set; }

        #endregion

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            OpcTag objAsOpcTag = obj as OpcTag;
            if (objAsOpcTag == null) return false;
            else return Equals(objAsOpcTag);
        }

        public override int GetHashCode()
        {
            return MD5.Create(Path + Value + Quality).GetHashCode();
        }

        public bool Equals(OpcTag other)
        {
            if (other == null) return false;

            return Path.Equals(other.Path) && Value.Equals(other.Value) && Quality.Equals(other.Quality);
        }

        public static bool operator ==(OpcTag opcTag1, OpcTag opcTag2)
        {
            return !(null == opcTag1) && opcTag1.Equals(opcTag2);
        }

        public static bool operator !=(OpcTag opcTag1, OpcTag opcTag2)
        {
            return !(opcTag1 == opcTag2);
        }
    }
}
