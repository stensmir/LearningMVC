﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;


namespace HabrLessonClassLibrary.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string Name { get; set; }
        public string LinkToAvatar { get; set; }
        public string Email { get; set; }
        public string GoogleId { get; set; }
    }
}
