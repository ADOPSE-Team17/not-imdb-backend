using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace src
{
  public class ApplicationDbContext : DbContext
  {

    private IConfiguration _configuration;
    private string _adapterType;
    private string[] _supportedAdapters = {"sqlite", "psql"};
    public DbSet<User> Users {get; set;}
    

    public ApplicationDbContext(
      DbContextOptions<ApplicationDbContext> options, 
      IConfiguration configuration)
          : base(options)
    {
      this._configuration = configuration;
      this._adapterType = this._configuration["DataAdapter:Dialect"];
      if (!this._supportedAdapters.Contains(this._adapterType)) {
        throw new Exception($"{this._adapterType} is not supported data adapter");
      }
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (this._adapterType == "sqlite") {
        optionsBuilder.UseSqlite($@"Data Source={this._configuration["DataAdapter:Options:Location"]};");
      } else {
        var host = this._configuration["DataAdapter:Options:Host"];
        var port = this._configuration["DataAdapter:Options:Port"];
        var user = this._configuration["DataAdapter:Options:User"];
        var password = this._configuration["DataAdapter:Options:Password"];
        var database = this._configuration["DataAdapter:Options:Database"];

        if (this._adapterType == "mysql") { // Mysql is not allowed
          var connectionString = $@"server={host}:{port};userid={user};passsword={password};database={database}";
          // optionsBuilder.UseMySQL(connectionString);
        } else if (this._adapterType == "psql") {
          var connectionString = $@"Host={host};Database={database};Username={user};Password={password}";
          optionsBuilder.UseNpgsql(connectionString);
        }
      } 
    }
  }

  public interface IDataAdapterOptions {

  }

  public interface IDataAdapterConfiguration {
    public string Dialect {get; set;}
  }

  public interface IDataAdapterExternalOptions : IDataAdapterOptions {
    public string Host {get; set;}
    public string Port {get; set;}
    
    public string Database {get; set;}

    public string User { get; set; }
    public string Password { get; set; }
  }

  public interface IDataAdapterSqliteOptions : IDataAdapterOptions {
    public string Location { get; set; }
  }

  public interface IDataAdapterConfigurationMysql : IDataAdapterConfiguration {
    public IDataAdapterExternalOptions Options {get; set;}
  }
}
