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
            using (var context = new Persistent.HabrLessonDatabaseEntities())
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

            using (var context = new Persistent.HabrLessonDatabaseEntities())
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

            using (var context = new Persistent.HabrLessonDatabaseEntities())
            {
                return context.User.ToList().Select(x => this.ConvertUserToDomain(x));
            }
        }

        private Domain.User ConvertUserToDomain(Persistent.User persistentUser)
        {
            return new Domain.User
            {
                 Id = persistentUser.Id,
                 GivenName = persistentUser.GivenName,
                 FamilyName = persistentUser.FamilyName,
                 LinkToAvatar = persistentUser.LinkToAvatar,
                 Email = persistentUser.Email
            };
        }

        private Persistent.User ConvertUserToPersistent(Domain.User domainUser)
        {
            return new Persistent.User
            {
                Id = domainUser.Id,
                GivenName = domainUser.GivenName,
                FamilyName = domainUser.FamilyName,
                LinkToAvatar = domainUser.LinkToAvatar,
                Email = domainUser.Email
            };
        }
    }
}
