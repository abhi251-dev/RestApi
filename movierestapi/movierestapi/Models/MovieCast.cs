using System;
using System.Collections.Generic;

#nullable disable

namespace movierestapi.Models
{
    public partial class MovieCast
    {
        public decimal ActId { get; set; }
        public decimal MovId { get; set; }
        public string Role { get; set; }

        public virtual Actor Act { get; set; }
        public virtual Movie Mov { get; set; }
    }
}
