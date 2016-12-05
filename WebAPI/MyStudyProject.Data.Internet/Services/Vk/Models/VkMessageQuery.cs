using System.Text;

namespace MyStudyProject.Data.Internet.Services.Vk.Models
{
    public class VkMessageQuery : VkQuery
    {
        public VkMessageQuery(string baseUrl, string version) : base(baseUrl, version)
        {
        }

        public string Query { get; set; }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(base.ToString());
            builder.Append("&q=");
            builder.Append(Encode(Query));
            return builder.ToString();
        }
    }
}
