using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HabrLessonClassLibrary.Repository.Sql
{
    public class UserRepository : IUserRepository
    {
        //public Persistent.HabrLessonDb Context { get; set; }
        public Domain.User GetUserById(int id)
        {
            using (var context = new Persistent.HabrLessonDB())
            {
                return context.User
                              .Where(x => x.Id == id)
                              .ToList()
                              .Select(x => this.ConvertUserToDomain(x))
                              .SingleOrDefault();
            }
        }

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

        public IEnumerable<Domain.User> GetAllDomainUsers()
        {

            using (var context = new Persistent.HabrLessonDB())
            {
                return context.User.ToList().Select(x => this.ConvertUserToDomain(x));
            }
        }

        private Domain.User ConvertUserToDomain(Persistent.User persistentUser)
        {
            return new Domain.User
            {
                 Id = persistentUser.Id,
                 FirstName = persistentUser.FirstName,
                 LastName = persistentUser.LastName,
                 LinkToAvatar = persistentUser.LinkToAvatar,
                 LoginName = persistentUser.Login
            };
        }
    }
}
