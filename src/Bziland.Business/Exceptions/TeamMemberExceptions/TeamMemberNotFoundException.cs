using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bziland.Business.Exceptions.TeamMemberExceptions
{
    public class TeamMemberNotFoundException : Exception
    {
        public  string PropertyName {  get; set; }

        public TeamMemberNotFoundException()
        {
        }

        public TeamMemberNotFoundException(string? message) : base(message)
        {
        }

        public TeamMemberNotFoundException(string propertyName,string? message) : base(message)
        {
            PropertyName = propertyName;
        }
    }
}
