﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStudyProject.Core.Models.Commands
{
    public class UserCreateCommand
    {
        public long Id { get; set; }

        public string NetworkId { get; set; }

        public string UserName { get; set; }

        public string ProfileId { get; set; }

        public string Url { get; set; }
    }
}
