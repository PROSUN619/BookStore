using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webgentle.Bookstore.Data;
using Webgentle.Bookstore.Models;

namespace Webgentle.Bookstore.Repository
{
  public class BookRepository
  {
    private readonly BookStoreContext _context;
    public BookRepository(BookStoreContext context)
    {
      _context = context;
    }

    public async Task<int> AddNewBooks(BookModel model)
    {
      var newModel = new Book {
        Author = model.Author,
        CreatedOn = DateTime.Now,
        Description = model.Description,
        LanguageId = model.LanguageId,
        Title = model.Title,
        TotalPages = model.TotalPages.HasValue ? model.TotalPages.Value : 0 ,
        ModifiedOn = DateTime.Now
      };

      await _context.AddAsync(newModel);
      await  _context.SaveChangesAsync();
      return newModel.Id;
    }

    public async Task<List<BookModel>> GetAllBooks()
    {
      List<BookModel> modelList = new List<BookModel>();
      var bookList = await  _context.Books.ToListAsync();
      //return BookStore();
      if (bookList?.Any() == true){
        foreach (var item in bookList)
        {
          modelList.Add(
             new BookModel { Id = item.Id, Title = item.Title, Author = item.Author, Category = item.Category,
               LanguageId = item.LanguageId, Language = item.Language.Name, TotalPages = item.TotalPages, Description = item.Description }
            );
        }
      }

      return modelList;
    }


    public async Task<BookModel> GetBook(int id)
    {
      //var book = await _context.Books.FindAsync(id); // this method returnning null ref error when joining with other table

      return await _context.Books.Where(x => x.Id == id)
        .Select(s => new BookModel() 
        {
          Id = s.Id,
          Title = s.Title,
          Author = s.Author,
          Category = s.Category,
          LanguageId = s.LanguageId,
          Language = s.Language.Name,
          TotalPages = s.TotalPages,
          Description = s.Description
        }).FirstOrDefaultAsync();


      //if (book != null)
      //{
      //  return new BookModel()
      //  {
      //    Id = book.Id,
      //    Title = book.Title,
      //    Author = book.Author,
      //    Category = book.Category,
      //    LanguageId = book.LanguageId,
      //    Language = book.Language.Name,
      //    TotalPages = book.TotalPages,
      //    Description = book.Description
      //  };
      //}
      //else return null;

     // return BookStore().Find(x => x.Id.Equals(id));
    }

    //public List<BookModel> SearchBook(string title, string author)
    //{
    //  return BookStore().Where(x => x.Title == title && x.Author == author).ToList();
    //}


    //private List<BookModel> BookStore()
    //{
    //  return new List<BookModel>() { 
    //      new BookModel{Id = 1,Title="java", Author= "Ben",Category="Programming",Language="English",TotalPages=500, Description="Java is a programming language"},
    //      new BookModel(){Id = 2,Title="c sharp", Author= "John",Category="Programming",Language="English",TotalPages=400, Description="Java is a programming language"},
    //      new BookModel(){Id = 3,Title="python", Author= "Sara",Category="Programming",Language="English",TotalPages=320, Description="Java is a programming language"},
    //      new BookModel(){Id = 4,Title="angular", Author= "Steve",Category="Programming",Language="English",TotalPages=612, Description="Java is a programming language"},
    //      new BookModel(){Id = 5,Title="react", Author= "Pam",Category="Programming",Language="English",TotalPages=421, Description="Java is a programming language"},
    //      new BookModel(){Id = 6,Title="vue", Author= "Rita",Category="Programming",Language="English",TotalPages=350, Description="Java is a programming language"},
    //  }; 
    //}
  }
}
