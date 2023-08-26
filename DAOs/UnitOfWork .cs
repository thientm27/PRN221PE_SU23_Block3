using DAOs.DAOs;
using DAOs.Models;
using DataAccessObject.DAOs;



namespace DataAccessObject
{
    public class UnitOfWork
    {
        private CartoonFilm2023DBContext context = new CartoonFilm2023DBContext();
        private GenericDAO<MemberAccount> memberAccoutDao;
        private GenericDAO<CartoonFilmInformation> cartoonfilmInforDao;
        private GenericDAO<Producer> producerDao;

        public GenericDAO<MemberAccount> MemberAccoutDao => memberAccoutDao ??= new MemberAccountDao(context);
        public GenericDAO<CartoonFilmInformation> CartoonfilmInforDao => cartoonfilmInforDao ??= new CartoonFilmDao(context);
        public GenericDAO<Producer> ProducerDao => producerDao ??= new ProducerDao(context);
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
