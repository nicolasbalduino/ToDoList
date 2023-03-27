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
            return  $"ID: {this.Id}" +
                    $"\nDescrição: {this.Description}" +
                    $"\nCategoria: {this.Category}" +
                    $"\nDono: {this.Owner}" +
                    $"\nData de criação: {this.Created}" +
                    $"\nData de vencimento: {this.DueDate}" +
                    $"\nStatus: {this.Status}";
        }

        public string ToFile()
        {
            return  $"{Id}|{this.Description}|{this.Category}|{this.Owner}|" +
                    $"{this.Created}|{this.DueDate}|{this.Status}";
        }

        public bool SetStatus()
        {
            return Status == false ? true : false;
        }

        public Person SetPerson()
        {
            return Owner;
        }
    }
}
