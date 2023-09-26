using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO
{
    public class BookAuthorDTO
    {
        public string Author { get; set; } = null!;
        public string Book { get; set; } = null!;
        public byte? AuthorOrder { get; set; }
        public byte? RoyalityPercentage { get; set; }
        public string AuthorId { get; set; } = null!;
        public string BookId { get; set; } = null!;

    }
}
