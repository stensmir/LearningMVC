using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HabrLessonClassLibrary.Repository
{
    public interface IUserRepository 
    {
        Domain.User GetUserById(int id);
        Domain.User GetUserByEmail(string email);
        void Save(Domain.User user);
        Domain.User GetUserIdByEmailAndPassword(string email, string password);
       
    }
}
