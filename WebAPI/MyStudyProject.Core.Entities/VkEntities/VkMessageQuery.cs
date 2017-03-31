﻿using System;
using System.Text;

namespace MyStudyProject.Core.Entities.VkEntities
{
    public class VkMessageQuery : VkQuery
    {
        public VkMessageQuery(string baseUrl, string version) : base(baseUrl, version)
        {
        }

        public string Query { get; set; }

        public bool Extended { get; set; } = true;

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(base.ToString());
            builder.Append("&q=");
            builder.Append(Encode(Query));
            builder.Append("&extended=");
            builder.Append(Encode(Convert.ToInt32(Extended).ToString()));
            return builder.ToString();
        }
    }
}
