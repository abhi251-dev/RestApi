using System;
using System.Collections.Generic;

#nullable disable

namespace libraryrestapi.Models
{
    public partial class VBook
    {
        public string Title { get; set; }
        public int BookId { get; set; }
        public int? Sum { get; set; }
    }
}
