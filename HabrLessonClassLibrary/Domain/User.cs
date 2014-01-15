using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HabrLessonClassLibrary.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LinkToAvatar { get; set; }
    }
}
