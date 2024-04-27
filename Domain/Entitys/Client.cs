﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entitys
{
    public class Client : Entity
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }

        internal Client(string name, string email, string phone)
        {
            Name = name;
            Email = email;
            Phone = phone;
        }


    }
}
