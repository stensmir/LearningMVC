using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;


namespace HabrLessonClassLibrary.Domain
{
    public class User
    {
        public virtual string GivenName { get; set; }
        public virtual string FamilyName { get; set; }
        public virtual string Name { get; set; }
        public virtual string LinkToAvatar { get; set; }
        public virtual string Email { get; set; }
        public virtual string GoogleId { get; set; }
        public virtual string Password { get; set; }
    }
}
