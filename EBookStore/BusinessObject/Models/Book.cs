using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BusinessObject.Models
{
    public partial class Book
    {
        public Book()
        {
            BookAuthors = new HashSet<BookAuthor>();
        }

        public string BookId { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string? Type { get; set; }
        public string PubId { get; set; } = null!;
        public decimal? Price { get; set; }
        public decimal? Advance { get; set; }
        public decimal? Royalty { get; set; }
        public int? YtdSales { get; set; }
        public string? Notes { get; set; }
        public DateTime? PublishedDate { get; set; }
        public virtual Publisher Pub { get; set; } = null!;
        
        [JsonIgnore]
        public virtual ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
