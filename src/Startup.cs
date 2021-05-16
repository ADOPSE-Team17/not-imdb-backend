using System;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
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

      services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
      services.AddControllers();
      services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
      services.AddDbContext<ApplicationDbContext>();
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "src", Version = "v1" });
      });
      services.AddCors();
      int jwtTTL = 8;
      try
      {
        jwtTTL = int.Parse(Configuration["Jwt:TTL"]);
      }
      catch
      {
        Console.WriteLine("Error parsing jwt ttl");
      }
      services.AddSingleton<AuthenticationService>(new AuthenticationService(Configuration["Jwt:Key"], Configuration["Jwt:Issuer"], jwtTTL));
      services.AddSingleton<IAuthorizationPolicyProvider, MyLocalAuthenticationPolicyProvider>();
      services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
          options.TokenValidationParameters = new TokenValidationParameters
          {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
          };
        });
      services.AddScoped<IAuthorizationHandler, UserRoleHandler>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {

      app.UseMiddleware<JwtMiddleware>();
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

      app.UseCors(options =>
        options.AllowAnyMethod()
          .AllowAnyHeader()
          .SetIsOriginAllowed(origin => true) // allow any origin);
      );

      app.UseStaticFiles(new StaticFileOptions
        {
          FileProvider = new PhysicalFileProvider(
            Path.Combine(env.ContentRootPath, "./assets")
          ),
          RequestPath = "/assets",
          OnPrepareResponse = ctx =>
          {
              // using Microsoft.AspNetCore.Http;
              ctx.Context.Response.Headers.Append(
                  "Access-Control-Allow-Origin", $"*");
          }
        }
      );
      app.UseRouting();
      app.UseAuthentication();
      app.UseAuthorization();
      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
