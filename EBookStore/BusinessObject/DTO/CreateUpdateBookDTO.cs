using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO
{
    public class CreateUpdateBookDTO
    {
        public string? BookId { get; set; }
        public string Title { get; set; } = null!;
        public string? Type { get; set; }
        public string PubId { get; set; } = null!;
        public decimal? Price { get; set; }
        public decimal? Advance { get; set; }
        public decimal? Royalty { get; set; }
        public int? YtdSales { get; set; }
        public string? Notes { get; set; }
        public DateTime? PublishedDate { get; set; }
    }
}
