using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webgentle.Bookstore.Helper
{
  public class CustomEmailTagHelper : TagHelper
  {
    public string Email { get; set; }
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
      output.TagName = "a";
      output.Attributes.SetAttribute("href", $"mailto:{Email}");
      output.Attributes.Add("id", "my-email-id");
      output.Content.SetContent("my-email");
    }

  }
}
