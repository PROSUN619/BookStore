using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webgentle.Bookstore.Models;

namespace Webgentle.Bookstore.Repository
{
  public class BookRepository
  {


    public List<BookModel> GetAllBooks()
    {
      return BookStore();
    }


    public BookModel GetBook(int id)
    {
      return BookStore().Find(x => x.Id.Equals(id));
    }

    public List<BookModel> SearchBook(string title, string author)
    {
      return BookStore().Where(x => x.Title == title && x.Author == author).ToList();
    }


    private List<BookModel> BookStore()
    {
      return new List<BookModel>() { 
          new BookModel{Id = 1,Title="java", Author= "Ben",Category="Programming",Language="English",TotalPages=500, Description="Java is a programming language"},
          new BookModel(){Id = 2,Title="c sharp", Author= "John",Category="Programming",Language="English",TotalPages=400, Description="Java is a programming language"},
          new BookModel(){Id = 3,Title="python", Author= "Sara",Category="Programming",Language="English",TotalPages=320, Description="Java is a programming language"},
          new BookModel(){Id = 4,Title="angular", Author= "Steve",Category="Programming",Language="English",TotalPages=612, Description="Java is a programming language"},
          new BookModel(){Id = 5,Title="react", Author= "Pam",Category="Programming",Language="English",TotalPages=421, Description="Java is a programming language"},
          new BookModel(){Id = 6,Title="vue", Author= "Rita",Category="Programming",Language="English",TotalPages=350, Description="Java is a programming language"},
      }; 
    }
  }
}
