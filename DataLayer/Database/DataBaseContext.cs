using DataLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Others;

namespace DataLayer.Database
{
    
    public class DataBaseContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            string solutionFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string databaseFile = "Welcome.db";
            string databasePath = Path.Combine(solutionFolder, databaseFile);
            optionsBuilder.UseSqlite($"Data Source= {databasePath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<DataBaseUser>().Property(e => e.ID).ValueGeneratedOnAdd();

            var user = new DataBaseUser()
            {
                ID = 1,
                Name = "John Wick",
                Password = "1234",
                Role = UserRolesEnum.ADMIN,
                Expires = DateTime.Now.AddYears(10)
            };

            var user2 = new DataBaseUser()
            {
                ID = 2,
                Name = "Chuck Norris",
                Password = "123",
                Role = UserRolesEnum.INSPECTOR,
                Expires = DateTime.Now.AddYears(100)
            };
            modelBuilder.Entity<DataBaseUser>().HasData(user);
            modelBuilder.Entity<DataBaseUser>().HasData(user2);
        }
        public DbSet<DataBaseUser> Users { get; set; }

    }
}
