using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;


namespace HabrLessonClassLibrary.Domain
{
    public class User
    {
        public BigInteger Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LinkToAvatar { get; set; }
        public string LoginName { get; set; }
    }
}
