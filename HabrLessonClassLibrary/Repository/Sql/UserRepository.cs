using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HabrLessonClassLibrary.Repository.Sql
{
    public class UserRepository : IUserRepository
    {
        //public Persistent.HabrLessonDb Context { get; set; }
        //public Domain.User GetUserById(int id)
        //{
        //    using (var context = new Persistent.HabrLessonDb())
        //    { 
        //      throw new NotImplementedException(); 
        //    }
        //}

        //public Domain.User GetUserByLogin(string login)
        //{
        //    throw new NotImplementedException();
        //}

        //public Domain.User Save(Domain.User user)
        //{
        //    throw new NotImplementedException();
        //}

        //public void CreateUser(Domain.User user)
        //{
        //    throw new NotImplementedException();
        //}

        public IEnumerable<Persistent.User> GetAllPersistentUsers()
        {

            using (var context = new Persistent.HabrLessonDB())
            {
                return context.User.ToList();
            }
        }
    }
}
