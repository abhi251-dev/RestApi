using System;
using System.Collections.Generic;

#nullable disable

namespace libraryrestapi.Models
{
    public partial class BookAuthor
    {
        public string AuthorName { get; set; }
        public int? BookId { get; set; }

        public virtual Book Book { get; set; }
    }
}
