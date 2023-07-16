﻿using System;
using System.Collections.Generic;

namespace BusinessObject.Model.Entities
{
    public partial class BookAuthor
    {
        public int AuthorId { get; set; }
        public int BookId { get; set; }
        public string? AuthorOrder { get; set; }
        public string? RoyalityPerentage { get; set; }

        public virtual Author Author { get; set; } = null!;
        public virtual Book Book { get; set; } = null!;
    }
}