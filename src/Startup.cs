using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace src
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {

      services.AddControllers();
      services.AddDbContext<ApplicationDbContext>();
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "src", Version = "v1" });
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    { 

      // // Redirect calls to the root path at the client application 
      app.UseRewriter(new RewriteOptions()
        .AddRedirect("^\\/?$", "/client")
      );

      app.Map(new PathString("/client"), client =>
      {       
        var clientPath = Path.Combine(Directory.GetCurrentDirectory(), "./../dist");
        StaticFileOptions clientAppDist = new StaticFileOptions()
        {
            FileProvider = new PhysicalFileProvider(clientPath)
        };            
        client.UseSpaStaticFiles(clientAppDist);
        client.UseSpa(spa =>
        {
            spa.Options.DefaultPageStaticFileOptions = clientAppDist;
        });                                       
    });

      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "src v1"));
      }

      app.UseRouting();
      app.UseAuthorization();
      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
