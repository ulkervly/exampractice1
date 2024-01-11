using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bizland.Core.Entities
{
    public class TeamMember:BaseEntity
    {
        public string FullName {  get; set; }
        public string Profession { get; set; }
        public string MediaUrls { get; set; }
        public string ImageUrl { get; set; }
    }
}
