﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        /// TODO: Add OpcTagType

        private string tagPath;
        private string value;
        private OpcTagQuality quality;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tagPath">Full path of the tag on the server</param>
        /// <param name="tagType">Type of the tag as on the server</param>
        public OpcTag(string tagPath, string tagValue)
        {
            this.tagPath = tagPath;
            this.value = tagValue;

            this.quality = OpcTagQuality.Unknown;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tagPath">Full path of the tag on the server</param>
        /// <param name="tagType">Type of the tag as on the server</param>
        public OpcTag(string tagPath, string tagValue, OpcTagQuality tagQuality)
        {
            this.tagPath = tagPath;
            this.value = tagValue;
            this.quality = tagQuality;
        }

        #region Getters and setters

        /// <summary>
        /// Full path of the tag on the server
        /// </summary>
        public string TagPath
        {
            get
            {
                return tagPath;
            }
        }

        /// <summary>
        /// Gets or sets the string representation of the tag value
        /// </summary>
        public string Value
        {
            get
            {
                return value;
            }

            set
            {
                this.value = value;
            }
        }

        public OpcTagQuality Quality
        {
            get
            {
                return quality;
            }

            set
            {
                quality = value;
            }
        }

        #endregion
    }
}