﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bziland.Business.Exceptions.TeamMemberExceptions
{
    public class TeamMemberInvalidImageFileException:Exception
    {
        public string PropertyName { get; set; }

        public TeamMemberInvalidImageFileException()
        {
        }

        public TeamMemberInvalidImageFileException(string? message) : base(message)
        {
        }

        public TeamMemberInvalidImageFileException(string propertyName, string? message) : base(message)
        {
            PropertyName = propertyName;
        }
    }
}
