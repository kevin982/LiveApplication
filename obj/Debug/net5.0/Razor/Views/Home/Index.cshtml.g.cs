#pragma checksum "C:\Users\admin\Desktop\BookStorePrueba\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bdbb059f589fe2cf032f6a1c7e3365f00c231187"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#nullable restore
#line 1 "C:\Users\admin\Desktop\BookStorePrueba\Views\Home\Index.cshtml"
using BookStorePrueba.Models.Tables;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bdbb059f589fe2cf032f6a1c7e3365f00c231187", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"352788feff91f44f362d0671af1298e5a77ce188", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 4 "C:\Users\admin\Desktop\BookStorePrueba\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home";



#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<section class=\"jumbotron text-center\">\r\n\r\n    <div class=\"container\">\r\n\r\n        <h1 class=\"h1\">Welcome to Bookstore</h1>\r\n        <h5 class=\"h5\">");
#nullable restore
#line 15 "C:\Users\admin\Desktop\BookStorePrueba\Views\Home\Index.cshtml"
                   Write(ViewBag.IsAuthenticated?ViewBag.Id: "Unknow");

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h5>

        <p class=""lead text-muted"">

            lorem lksjflksdjf sdlkfjsdlkfjsakl flsjdflksdf jskdlfbbbjewrhe  bcbsbdfbdf bwkjrhewr
            skjfsldkfj nwnqner loremndskfj jdsfsdkfj adfdsf

        </p>

        <p>
            <a href=""#"" class=""btn btn-primary my-2"">Search Books</a>
        </p>

    </div>

</section>


");
#nullable restore
#line 33 "C:\Users\admin\Desktop\BookStorePrueba\Views\Home\Index.cshtml"
Write(await Component.InvokeAsync("TopBooks", 2));

#line default
#line hidden
#nullable disable
            WriteLiteral(";\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
