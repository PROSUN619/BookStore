using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webgentle.Bookstore.Models;

namespace Webgentle.Bookstore.Data
{
  public class BookStoreContext : IdentityDbContext<LoginUser> /*:DbContext*/  // setup with identity core 3 
  {
    public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<BookGallary> BookGallary { get; set; }
    public DbSet<Language> Languages { get; set; }
  }
}
