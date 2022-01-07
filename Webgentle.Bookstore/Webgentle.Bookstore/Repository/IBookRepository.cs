using System.Collections.Generic;
using System.Threading.Tasks;
using Webgentle.Bookstore.Models;

namespace Webgentle.Bookstore.Repository
{
  public interface IBookRepository
  {
    Task<int> AddNewBooks(BookModel model);
    Task<List<BookModel>> GetAllBooks();
    Task<BookModel> GetBook(int id);
    Task<List<BookModel>> GetTopBooksAsync(int count);
    string GetAppName();
  }
}