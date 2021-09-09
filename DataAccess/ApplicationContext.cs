using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
   public  class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions opts): base(opts)
        {

         }
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);

        //}
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Todo> Todos { get; set; }

        
    }
}
