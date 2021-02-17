using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 
namespace BookStore.Helpers
{
    public class CustomEmailTagHelper : TagHelper
    {

        public string MyEmail { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "custom-email";

            output.Content.SetHtmlContent($"<a href = {MyEmail}> {MyEmail} </a>");
            
        }
    }
}
