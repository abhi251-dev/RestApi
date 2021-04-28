using System;
using System.Collections.Generic;

#nullable disable

namespace libraryrestapi.Models
{
    public partial class LibraryBranch
    {
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public string Address { get; set; }
    }
}
