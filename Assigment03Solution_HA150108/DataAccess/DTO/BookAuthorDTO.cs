using System;
using System.Collections.Generic;

namespace BusinessObject.Model.Entities
{
    public  class BookAuthorDTO
    {
        public int? AuthorId { get; set; }
        public int? BookId { get; set; }
        public string? AuthorOrder { get; set; }
        public string? RoyalityPerentage { get; set; }

    }
}
