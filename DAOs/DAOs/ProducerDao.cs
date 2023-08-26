using DAOs.Models;
using DataAccessObject.DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOs.DAOs
{
    public class ProducerDao : GenericDAO<Producer>
    {
        public ProducerDao(CartoonFilm2023DBContext context) : base(context)
        {
        }

        public override Producer? GetById(object? id)
        {
            throw new NotImplementedException();
        }
    }
}
