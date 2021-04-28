using System;
using System.Collections.Generic;

#nullable disable

namespace movierestapi.Models
{
    public partial class Actor
    {
        public Actor()
        {
            MovieCasts = new HashSet<MovieCast>();
        }

        public decimal ActId { get; set; }
        public string ActName { get; set; }
        public string ActGender { get; set; }

        public virtual ICollection<MovieCast> MovieCasts { get; set; }
    }
}
