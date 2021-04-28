using System;
using System.Collections.Generic;

#nullable disable

namespace libraryrestapi.Models
{
    public partial class Book
    {
        //internal bool book_id;

        public int BookId { get; set; }
        public string Title { get; set; }
        public string PublisherName { get; set; }
        public int? PubYear { get; set; }

        public virtual Publisher PublisherNameNavigation { get; set; }
    }
}
