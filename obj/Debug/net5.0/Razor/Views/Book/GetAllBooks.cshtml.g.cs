#pragma checksum "C:\Users\admin\Desktop\BookStorePrueba\Views\Book\GetAllBooks.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "be51c83c76982618012235160cf312fe0ce61d9a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Book_GetAllBooks), @"mvc.1.0.view", @"/Views/Book/GetAllBooks.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\admin\Desktop\BookStorePrueba\Views\_ViewImports.cshtml"
using BookStorePrueba.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"be51c83c76982618012235160cf312fe0ce61d9a", @"/Views/Book/GetAllBooks.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"352788feff91f44f362d0671af1298e5a77ce188", @"/Views/_ViewImports.cshtml")]
    public class Views_Book_GetAllBooks : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<BookModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\admin\Desktop\BookStorePrueba\Views\Book\GetAllBooks.cshtml"
  
    ViewData["Title"] = "All Books";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("\r\n<div class=\"container\">\r\n    <h3 class=\"display-4\">All books</h3>\r\n    <div class=\"row\">\r\n\r\n");
#nullable restore
#line 11 "C:\Users\admin\Desktop\BookStorePrueba\Views\Book\GetAllBooks.cshtml"
          
            foreach (var book in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"col-md-4\">\r\n");
#nullable restore
#line 15 "C:\Users\admin\Desktop\BookStorePrueba\Views\Book\GetAllBooks.cshtml"
                      
                        await Html.RenderPartialAsync("_bookThumbnail", book);
                    

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n");
#nullable restore
#line 19 "C:\Users\admin\Desktop\BookStorePrueba\Views\Book\GetAllBooks.cshtml"
            }
        

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<BookModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
