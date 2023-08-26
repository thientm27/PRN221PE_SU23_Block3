using DAOs.Models;
using DataAccessObject;
using DataAccessObject.Utils;

namespace Repo.Imple
{
    public class CartoonFirmRepo : ICartoonFirmRepo
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        public CartoonFilmInformation AddNewFilm(CartoonFilmInformation cartoonFilmInformation)
        {
            cartoonFilmInformation.CartoonFilmId = unitOfWork.CartoonfilmInforDao.Get().Max(o => o.CartoonFilmId)+ 1;
            unitOfWork.CartoonfilmInforDao.Create(cartoonFilmInformation);
            unitOfWork.Save();
            return unitOfWork.CartoonfilmInforDao.GetById(cartoonFilmInformation.CartoonFilmId);
        }

        public MemberAccount? CheckLogin(string memberId)
        {
            return unitOfWork.MemberAccoutDao.Get(filter: o => o.MemberId.ToString() == memberId).FirstOrDefault();
        }

        public void DeleteFilm(object id)
        {
            unitOfWork.CartoonfilmInforDao.DeleteById(id);
            unitOfWork.Save();
        }

        public Pagination<CartoonFilmInformation> GetAuthorPaginationSpecialEntity(int pageIndex, int pageSize, string keyId)
        {
            var entities = unitOfWork.CartoonfilmInforDao.Get(includeProperties: "Producer", orderBy: q => q.OrderBy(author => author.CartoonFilmId.ToString() != keyId));
            return unitOfWork.CartoonfilmInforDao.ToPagination(entities, pageIndex, pageSize);
        }

        public Pagination<CartoonFilmInformation> GetCartoonPagination(int pageIndex, int pageSize)
        {
            var entities = unitOfWork.CartoonfilmInforDao.Get(includeProperties: nameof(CartoonFilmInformation.Producer));
            return unitOfWork.CartoonfilmInforDao.ToPagination(entities, pageIndex, pageSize);
        }

        public Pagination<CartoonFilmInformation> GetCartoonPaginationSearch(int pageIndex, int pageSize, string key, int type = 0)
        {
            // 1 = duration
            // 2 = year
            switch (type)
            {

                case 1:
                    {
                        var entities = unitOfWork.CartoonfilmInforDao.Get(filter: o => o.Duration.ToString().Contains(key.ToLower()), includeProperties: "Producer");
                        return unitOfWork.CartoonfilmInforDao.ToPagination(entities, pageIndex, pageSize);

                    }
                case 2:
                    {
                        var entities = unitOfWork.CartoonfilmInforDao.Get(filter: o => o.ReleaseYear.ToString().ToLower().Contains(key.ToLower()), includeProperties: "Producer");
                        return unitOfWork.CartoonfilmInforDao.ToPagination(entities, pageIndex, pageSize);

                    }
            }

            return new Pagination<CartoonFilmInformation>();
        }

        public CartoonFilmInformation GetFilmById(object id)
        {
            return unitOfWork.CartoonfilmInforDao.GetById(id);
        }

        public List<Producer> GetProducers()
        {
            return unitOfWork.ProducerDao.Get();

        }

        public MemberAccount? Login(string memberId, string password)
        {
            return unitOfWork.MemberAccoutDao.Get(filter: o => o.Email.ToLower().Equals(memberId.ToLower()) && o.Password.Equals(password)).FirstOrDefault();

        }

        public CartoonFilmInformation UpdateFilm(CartoonFilmInformation cartoonFilmInformation)
        {
            unitOfWork.CartoonfilmInforDao.Update(cartoonFilmInformation);
            unitOfWork.Save();
            return unitOfWork.CartoonfilmInforDao.GetById(cartoonFilmInformation.CartoonFilmId);
        }
    }
}
