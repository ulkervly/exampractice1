using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bizland.Core.Entities
{
    public class TeamMember:BaseEntity
    {
        [Required]
        [StringLength(maximumLength:100)]
        public string FullName {  get; set; }
        [Required]
        [StringLength(maximumLength: 100)]
        public string Profession { get; set; }
        public string MediaUrls { get; set; }
        public string? ImageUrl { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set;
        }
    }
}
