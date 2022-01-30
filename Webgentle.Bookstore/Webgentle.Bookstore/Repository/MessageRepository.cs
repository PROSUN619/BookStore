using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webgentle.Bookstore.Models;

namespace Webgentle.Bookstore.Repository
{
  public class MessageRepository : IMessageRepository
  {


    //private readonly IOptions<NewBookAlertConfig> _options;

    ////private readonly IOptionsSnapshot<NewBookAlertConfig> _options; // we cannot use scope service inside singleton,
    ////use Ioptionmonitor

    //public MessageRepository(IOptions<NewBookAlertConfig> options)
    //{
    //  _options = options;
    //}
    //public string GetName()
    //{
    //  return _options.Value.BookName;
    //}


    //implement Ioptionmonitor to get value from singleton

   // private NewBookAlertConfig _options; // option 1 
    private readonly IOptionsMonitor<NewBookAlertConfig> _options; // option 2 
    public MessageRepository(IOptionsMonitor<NewBookAlertConfig> options)
    {
      //option 1
      //options.OnChange(listener => {
      //  _options = listener;
      //});

      //option 2
      _options = options;


    }
    public string GetName()
    {
      //return _options.Value.BookName;
      return _options.CurrentValue.BookName;
    }

  }
}
