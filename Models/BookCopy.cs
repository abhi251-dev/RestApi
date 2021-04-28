using System;
using System.Collections.Generic;

#nullable disable

namespace libraryrestapi.Models
{
    public partial class BookCopy
    {
        public int? BookId { get; set; }
        public int? BranchId { get; set; }
        public int? NoofCopies { get; set; }

        public virtual Book Book { get; set; }
        public virtual LibraryBranch Branch { get; set; }
    }
}
