using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HabrLessonClassLibrary.Repository.Sql
{
    public class UserRepository : IUserRepository
    {
        //public string Hab { get; set; }
        public Domain.User GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public Domain.User GetUserByLogin(string login)
        {
            throw new NotImplementedException();
        }

        public Domain.User Save(Domain.User user)
        {
            throw new NotImplementedException();
        }
    }
}
