using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insta.Application.Models.DTOs
{
    public class InstaDto
    {
        public String UserName { get; set; } = null!;
        public string? FullName { get; set; } = null!;
        public string? ImageUrl { get; set; } = null!;
    }
}
