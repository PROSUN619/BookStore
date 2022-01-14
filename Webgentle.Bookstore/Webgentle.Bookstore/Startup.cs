using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Webgentle.Bookstore.Data;
using Webgentle.Bookstore.Helper;
using Webgentle.Bookstore.Models;
using Webgentle.Bookstore.Repository;
using Webgentle.Bookstore.Services;

namespace Webgentle.Bookstore
{
  public class Startup
  {
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
      _configuration = configuration;
    }

    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDbContext<BookStoreContext>(option =>
        option.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"))
      );
      //add entity framework service

      // add setup with identity core 2 
      services.AddIdentity<LoginUser, IdentityRole>().AddEntityFrameworkStores<BookStoreContext>().AddDefaultTokenProviders();
      // end add setup with identity core 2 

      services.AddControllersWithViews();

      // this pre processor code enable runtime application only for debug/development stage
#if DEBUG
      services.AddRazorPages().AddRazorRuntimeCompilation();

      //use this to prevent client side validation
      //  .AddViewOptions(option => {
      //  option.HtmlHelperOptions.ClientValidationEnabled = false;
      //});

#endif

      //add configure password strength
      services.Configure<IdentityOptions>(option =>
        {
          option.Password.RequiredLength = 5;
          option.Password.RequiredUniqueChars = 0;
          option.Password.RequireDigit = false;
          option.Password.RequireLowercase = false;
          option.Password.RequireNonAlphanumeric = false;
          option.Password.RequireUppercase = false;
          option.SignIn.RequireConfirmedEmail = true;
        }
      );
      // end configure password strength

      // this code help us to redirect to login page
      services.ConfigureApplicationCookie(option => {
        option.LoginPath = _configuration["Application:DefaultURL"];        
      });
      // end this code help us to redirect to login page

      services.AddScoped<IBookRepository, BookRepository>();
      services.AddScoped<ILanguageRepository, LanguageRepository>();
      services.AddScoped<IAccountRepository, AccountRepository>();
      services.AddScoped<IUserService, UserService>();
      services.AddScoped<IEmailService, EmailService>();
      services.AddScoped<IUserClaimsPrincipalFactory<LoginUser>, LoginUserClaimsPrincipalFactory>();
      //add this dependancy injection to create new instance of book repository when controller called

      services.Configure<SMTPConfigModel>(_configuration.GetSection("SMTPConfig")); //email config
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseStaticFiles();

      // below mediator used to map static file path other than wwwroot
      //app.UseStaticFiles(new StaticFileOptions() { 
        
      //  FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "StaticFiles")),
      //  RequestPath = "/StaticFiles"

      //});
      
      app.UseRouting();

      app.UseAuthentication(); // add setup with identity core 1
      app.UseAuthorization(); // then use authorize atrribute on controller/action method
      //this is a end point
      app.UseEndpoints(endpoints =>
      {
       // endpoints.MapDefaultControllerRoute();

        endpoints.MapControllerRoute(
           name: "Default",
           pattern: "{controller=Home}/{action=Index}/{id?}"
          );

        endpoints.MapControllerRoute(
           name: "Area",
           pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
          );
      });
    }
  }
}
