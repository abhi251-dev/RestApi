using System;
using System.Collections.Generic;

#nullable disable

namespace movierestapi.Models
{
    public partial class Movie
    {
        public Movie()
        {
            MovieCasts = new HashSet<MovieCast>();
        }

        public decimal MovId { get; set; }
        public string MovTitle { get; set; }
        public decimal? MovYear { get; set; }
        public string MovLang { get; set; }
        public decimal? DirId { get; set; }

        public virtual Director Dir { get; set; }
        public virtual Rating Rating { get; set; }
        public virtual ICollection<MovieCast> MovieCasts { get; set; }
    }
}
