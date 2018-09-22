namespace Business
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Business.Models;

    public partial class BusinessModel : DbContext
    {
        public BusinessModel()
            : base("name=BusinessContext")
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
