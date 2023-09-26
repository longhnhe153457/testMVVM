using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO
{
    public class AuthenDTO
    {
        public string? EmailAddress { get; set; } = null!;
        public string? Password { get; set; } = null!;
    }
}
