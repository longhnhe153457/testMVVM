using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO
{
    public class CreateUpdateBookAuthorDTO
    {
        public string AuthorId { get; set; } = null!;
        public string BookId { get; set; } = null!;
        public byte? AuthorOrder { get; set; }
        public byte? RoyalityPercentage { get; set; }
    }
}
