using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyStudyProject.Shared.Contracts.Enums;

namespace MyStudyProject.ViewModels
{
    public class MessageViewModel
    {
        public long Id { get; set; }

        public string Body { get; set; }

        public string HashTag { get; set; }
        public SocialMediaType Media { get; set; }

        public DateTime? PostDate { get; set; }
    }
}
