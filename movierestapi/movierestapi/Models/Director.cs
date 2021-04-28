using System;
using System.Collections.Generic;

#nullable disable

namespace movierestapi.Models
{
    public partial class Director
    {
        public Director()
        {
            Movies = new HashSet<Movie>();
        }

        public decimal DirId { get; set; }
        public string DirName { get; set; }
        public decimal? DirPhone { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
