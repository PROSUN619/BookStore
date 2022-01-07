using System.Collections.Generic;
using System.Threading.Tasks;
using Webgentle.Bookstore.Models;

namespace Webgentle.Bookstore.Repository
{
  public interface ILanguageRepository
  {
    Task<List<LanguageModel>> GetLanguages();
  }
}