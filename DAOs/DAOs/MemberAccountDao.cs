using DAOs.Models;
using DataAccessObject.DAOs;


namespace DAOs.DAOs
{

    public class MemberAccountDao : GenericDAO<MemberAccount>
    {
        public MemberAccountDao(CartoonFilm2023DBContext context) : base(context)
        {
        }

        public override MemberAccount? GetById(object? id)
        {
            if (id == null)
            {
                return null;
            }

            return Get(filter: o => o.MemberId.Equals(id)).FirstOrDefault();
        }
    }
}
