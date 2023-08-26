using DAOs.Models;
using DataAccessObject.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo
{
    public interface ICartoonFirmRepo
    {
        public MemberAccount? Login(string memberId, string password);
        public MemberAccount? CheckLogin(string memberId);
        public Pagination<CartoonFilmInformation> GetCartoonPagination(int pageIndex, int pageSize);
        public Pagination<CartoonFilmInformation> GetAuthorPaginationSpecialEntity(int pageIndex, int pageSize, string keyId);
        public Pagination<CartoonFilmInformation> GetCartoonPaginationSearch(int pageIndex, int pageSize, string key, int type = 0);
        public void DeleteFilm(object id);
        public CartoonFilmInformation GetFilmById(object id);
        public CartoonFilmInformation AddNewFilm(CartoonFilmInformation cartoonFilmInformation);
        public CartoonFilmInformation UpdateFilm(CartoonFilmInformation cartoonFilmInformation);
        public List<Producer> GetProducers();
    }
}
