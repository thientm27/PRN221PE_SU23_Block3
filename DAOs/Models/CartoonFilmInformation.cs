using System;
using System.Collections.Generic;

namespace DAOs.Models
{
    public partial class CartoonFilmInformation
    {
        public int CartoonFilmId { get; set; }
        public string CartoonFilmName { get; set; } = null!;
        public string? CartoonFilmDescription { get; set; }
        public int? Duration { get; set; }
        public int? ReleaseYear { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ProducerId { get; set; }

        public virtual Producer? Producer { get; set; }
    }
}
