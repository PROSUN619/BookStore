using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Webgentle.Bookstore.Data;

namespace Webgentle.Bookstore
{
  public class Startup
  {
    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDbContext<BookStoreContext>(option =>
        option.UseSqlServer("Server=.;database=BookStore;Integrated Security=True")
      );
      //add entity framework service

      services.AddControllersWithViews();

      // this pre processor code enable runtime application only for debug stage
#if DEBUG
      services.AddRazorPages().AddRazorRuntimeCompilation();
#endif

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

      //this is a end point
      app.UseEndpoints(endpoints =>
      {
        endpoints.MapDefaultControllerRoute();
      });
    }
  }
}
