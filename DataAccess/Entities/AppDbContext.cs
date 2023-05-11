namespace DataAccess.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

//Here AppDbcontext class is a context class and  derive from the DbContext base class

    public partial class AppDbContext : DbContext
    {

        //The  AppDbContex class  has a constructor which accepts the DbContextOptions as its argument.The dbContextOptions carries the configuration information needed to configure the DbContext.
        public AppDbContext()
            : base("name=AppDbContext")
        {
        }

        //In C#, a virtual method is a method that can be overridden in a derived class.
        //When a method is declared as virtual in a base class, it allows a derived class to provide its own implementation of the method.
        
       //A DbSet represents the collection of all entities in the context, or that can be queried from the database, of a given type.DbSet objects are created from a DbContext using the DbContext.Set method.
        public virtual DbSet<Tbl_City> Tbl_City { get; set; }
        public virtual DbSet<Tbl_Country> Tbl_Country { get; set; }
        public virtual DbSet<Tbl_State> Tbl_State { get; set; }

        //use this to configure the model
        //The OnModelCreating is the method where you can configure the model.The instance of the ModelBuilder is passed as the argument to the onModelCreating method. 
        //The ModelBuilder provides the API, which is used to configure the shape, data type, relationships between the models etc.
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
