using System;
using System.Collections.Generic;

namespace DAOs.Models
{
    public partial class Producer
    {
        public Producer()
        {
            CartoonFilmInformations = new HashSet<CartoonFilmInformation>();
        }

        public string ProducerId { get; set; } = null!;
        public string ProducerName { get; set; } = null!;
        public string ProducerDescription { get; set; } = null!;
        public string? Country { get; set; }

        public virtual ICollection<CartoonFilmInformation> CartoonFilmInformations { get; set; }
    }
}
