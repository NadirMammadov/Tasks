﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7Task.Model
{
    public class User
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string WriteEmail(string firstName, string lastName)
        {
            return $"{firstName}{lastName}@gmail.com".ToLower();
        }
    }

}
