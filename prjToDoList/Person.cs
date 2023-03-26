﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjToDoList
{
    internal class Person
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Person(string name)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
        }

        public Person SetName (string name)
        {
            this.Name = name;
            return this;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
