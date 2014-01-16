using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HabrLessonClassLibrary.Repository.Sql
{
    public class UserRepository : IUserRepository
    {
        public Persistent.HabrLessonDb Context { get; set; }
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

        public void CreateUser(Domain.User user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Persistent.User> GetAllPersistentUsers()
        {
             return Context.User.ToList();
        }
    }
}
