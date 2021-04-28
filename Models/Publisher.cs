using System;
using System.Collections.Generic;

#nullable disable

namespace libraryrestapi.Models
{
    public partial class Publisher
    {
        public Publisher()
        {
            Books = new HashSet<Book>();
        }

        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
