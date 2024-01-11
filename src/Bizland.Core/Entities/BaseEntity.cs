using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bizland.Core.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public bool Isdeleted { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set;}

    }
}
