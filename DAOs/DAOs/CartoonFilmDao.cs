using DAOs.Models;
using DataAccessObject.DAOs;


namespace DAOs.DAOs
{
    public class CartoonFilmDao : GenericDAO<CartoonFilmInformation>
    {
        public CartoonFilmDao(CartoonFilm2023DBContext context) : base(context)
        {
        }

        public override CartoonFilmInformation? GetById(object? id)
        {
            if (id == null)
            {
                return null;
            }

            return Get(filter: o => o.CartoonFilmId.Equals(id),includeProperties: "Producer").FirstOrDefault();
        }
    }
}
