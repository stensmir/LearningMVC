using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HabrLessonClassLibrary.Repository
{
    public interface IUserRepository 
    {
        Domain.User GetUserById(int id);
        Domain.User GetUserByLogin(string login);
        void Save(Domain.User user);
        void CreateUser(Domain.User user);
        IEnumerable<Domain.User> GetAllDomainUsers();
    }
}
