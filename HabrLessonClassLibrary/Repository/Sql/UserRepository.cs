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

        public Domain.User GetUserByEmail(string email)
        {
            using (var context = new Persistent.HabrLessonDatabaseEntities())
            {
                var user = context.User.Where(x => x.Email.Equals(email)).First();
                return this.ConvertUserToDomain(user);
            }
        }

        public void Save(Domain.User user)
        {

            using (var context = new Persistent.HabrLessonDatabaseEntities())
            {
                if (!context.User.Any(x => x.Email.Equals(user.Email)))
                {
                    var persistentUser = this.ConvertUserToPersistent(user);
                    context.User.Add(persistentUser);
                    context.SaveChanges();
                }
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

        public int GetUserIdByEmail(string email)
        {
            throw new NotImplementedException();
        }

        private Domain.User ConvertUserToDomain(Persistent.User persistentUser)
        {
            return new Domain.User
            {
                 //Id = persistentUser.Id,
                 GivenName = persistentUser.GivenName,
                 FamilyName = persistentUser.FamilyName,
                 LinkToAvatar = persistentUser.LinkToAvatar,
                 Email = persistentUser.Email,
                 Name = persistentUser.Name
            };
        }

        private Persistent.User ConvertUserToPersistent(Domain.User domainUser)
        {
            return new Persistent.User
            {
                //Id = domainUser.Id,
                GivenName = domainUser.GivenName,
                FamilyName = domainUser.FamilyName,
                LinkToAvatar = domainUser.LinkToAvatar,
                Email = domainUser.Email,
                Password = domainUser.Password,
                GoogleId = domainUser.GoogleId,
                Name = domainUser.Name
            };
        }

       
    }
}
