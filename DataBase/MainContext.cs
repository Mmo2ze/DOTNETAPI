using Microsoft.EntityFrameworkCore;
using ZOPE.Global;
using ZOPE.Models;

namespace ZOPE.DataBase
{
    public class MainContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql(connectionString: $@"datasource={Config.DB_Host};username={Config.DB_Username};password={Config.DB_Password};database={Config.DB_Name};SslMode=none", new MySqlServerVersion(Config.DB_Version));
        }
        public DbSet<Student>students { get; set; }
        public DbSet<Group>Groups { get; set; }
    }
}   
