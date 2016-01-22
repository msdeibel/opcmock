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

        //Equals override based on: https://msdn.microsoft.com/en-us/library/336aedhh%28v=vs.85%29.aspx

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            return obj is OpcTag && this == (OpcTag)obj;
        }

        public override int GetHashCode()
        {
            return MD5.Create(Path + Value + Quality).GetHashCode();
        }

        public static bool operator ==(OpcTag opcTag1, OpcTag opcTag2)
        {
            return opcTag1.Path == opcTag2.Path 
                    && opcTag1.Value == opcTag2.Value 
                    && opcTag1.Quality == opcTag2.Quality;
        }

        public static bool operator !=(OpcTag opcTag1, OpcTag opcTag2)
        {
            return !(opcTag1 == opcTag2);
        }
    }
}
