using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;

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

        public Domain.User GetUserByLogin(string login)
        {
            //Contract.Reauires
            throw new NotImplementedException();
        }

        public void Save(Domain.User user)
        {
            Contract.Requires(user != null);

            using (var context = new Persistent.HabrLessonDB())
            {
                var persistentUser = this.ConvertUserToPersistent(user);
                context.User.Add(persistentUser);
                context.SaveChanges();
            }
        }

        public void CreateUser(Domain.User user)
        {
            throw new NotImplementedException();
        }

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

        private Persistent.User ConvertUserToPersistent(Domain.User domainUser)
        {
            return new Persistent.User
            {
                Id = (int)domainUser.Id,
                FirstName = domainUser.FirstName,
                LastName = domainUser.LastName,
                LinkToAvatar = domainUser.LinkToAvatar,
                Login = domainUser.LoginName
            };
        }
    }
}
