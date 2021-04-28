using System;
using System.Collections.Generic;

#nullable disable

namespace libraryrestapi.Models
{
    public partial class BookLending
    {
        public int? BookId { get; set; }
        public int? BranchId { get; set; }
        public int? CardNo { get; set; }
        public DateTime? DateOut { get; set; }
        public DateTime? DueDate { get; set; }

        public virtual Book Book { get; set; }
        public virtual LibraryBranch Branch { get; set; }
        public virtual Card1 CardNoNavigation { get; set; }
    }
}
