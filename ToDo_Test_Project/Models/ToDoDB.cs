using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ToDo_Test_Project.Models
{
    public class ToDoDB
    {
        
        public int ID { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public DateTime DueDate { get; set; }
    }

    public class ToDoDBContext : DbContext
    {
        public DbSet<ToDoDB> ToDo { get; set; }
    }
}