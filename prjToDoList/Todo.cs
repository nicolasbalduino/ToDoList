using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjToDoList
{
    internal class Todo
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public Person? Owner { get; set; }
        public DateTime Created { get; set; }
        public DateTime? DueDate { get; set; }
        public bool Status { get; set; }

        public Todo(string description, string category, Person? owner, DateTime? dueDate)
        {
            this.Id = Guid.NewGuid();
            this.Description = description;
            this.Category = category;
            this.Owner = owner;
            this.Created = DateTime.Now;
            this.DueDate = dueDate;
            this.Status = false;
        }

        public override string ToString()
        {
            return $"{Id}";
        }

        public string ToFile()
        {
            return $"{Id}";
        }

        public bool SetStatus()
        {
            return Status;
        }

        public Person SetPerson()
        {
            return Owner;
        }
    }
}
