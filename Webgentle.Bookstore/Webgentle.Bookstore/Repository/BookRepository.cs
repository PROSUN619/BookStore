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

    public List<BookModel> SearchBook(string name, string author)
    {
      return BookStore().Where(x => x.Name == name && x.Author == author).ToList();
    }


    private List<BookModel> BookStore()
    {
      return new List<BookModel>() { 
          new BookModel{Id = 1,Name="java", Author= "Ben"},
          new BookModel(){Id = 1,Name="c sharp", Author= "John"},
          new BookModel(){Id = 1,Name="python", Author= "Sara"},
          new BookModel(){Id = 1,Name="angular", Author= "Steve"},
          new BookModel(){Id = 1,Name="react", Author= "Pam"},
          new BookModel(){Id = 1,Name="vue", Author= "Rita"},
      }; 
    }
  }
}
