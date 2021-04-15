using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace src
{
  public class ApplicationDbContext : DbContext
  {

    private IConfiguration _configuration;
    private string _adapterType;
    private string[] _supportedAdapters = { "sqlite", "psql" };
    public DbSet<User> Users { get; set; }
    public DbSet<Person> People { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Actor> Actors { get; set; }
    public DbSet<Director> Directors { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<MovieList> MovieLists { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Rating> Ratings { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<VoteAction> VoteActions { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Product> Products { get; set; }

    public ApplicationDbContext(
      DbContextOptions<ApplicationDbContext> options,
      IConfiguration configuration)
          : base(options)
    {
      this._configuration = configuration;
      this._adapterType = this._configuration["DataAdapter:Dialect"];
      if (!this._supportedAdapters.Contains(this._adapterType))
      {
        throw new Exception($"{this._adapterType} is not supported data adapter");
      }
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (this._adapterType == "sqlite")
      {
        optionsBuilder.UseSqlite($@"Data Source={this._configuration["DataAdapter:Options:Location"]};");
      }
      else
      {
        var host = this._configuration["DataAdapter:Options:Host"];
        var port = this._configuration["DataAdapter:Options:Port"];
        var user = this._configuration["DataAdapter:Options:User"];
        var password = this._configuration["DataAdapter:Options:Password"];
        var database = this._configuration["DataAdapter:Options:Database"];

        if (this._adapterType == "mysql")
        { // Mysql is not allowed
          var connectionString = $@"server={host}:{port};userid={user};passsword={password};database={database}";
          // optionsBuilder.UseMySQL(connectionString);
        }
        else if (this._adapterType == "psql")
        {
          var connectionString = $@"Host={host};Database={database};Username={user};Password={password}";
          optionsBuilder.UseNpgsql(connectionString);
        }
      }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

      modelBuilder.Entity<User>()
        .HasIndex(u => u.username)
        .IsUnique();

      modelBuilder.Entity<Person>().HasData(new Person { Id = 1, familyName = "Root", givenName = "Admin" });
      modelBuilder.Entity<User>().HasData(new User
      {
        Id = 1,
        personId = 1,
        username = "admin01",
        isAdmin = true,
        isActive = true,
        isDeleted = false,
        isDisabled = false
      });

      modelBuilder.Entity<Account>().HasData(new Account
      {
        Id = 1,
        userId = 1,
        email = "admin01@example.com",
        additionalType = "local",
        password = "admin01"
      });
    }

    public interface IDataAdapterOptions
    {

    }

    public interface IDataAdapterConfiguration
    {
      public string Dialect { get; set; }
    }

    public interface IDataAdapterExternalOptions : IDataAdapterOptions
    {
      public string Host { get; set; }
      public string Port { get; set; }

      public string Database { get; set; }

      public string User { get; set; }
      public string Password { get; set; }
    }

    public interface IDataAdapterSqliteOptions : IDataAdapterOptions
    {
      public string Location { get; set; }
    }

    public interface IDataAdapterConfigurationMysql : IDataAdapterConfiguration
    {
      public IDataAdapterExternalOptions Options { get; set; }
    }
  }
}
