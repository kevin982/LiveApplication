#pragma checksum "C:\Users\admin\Desktop\BookStorePrueba\Views\Account\ConfirmEmail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e93fb76b138342a1dfef61bdbe86d720a7c0c467"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_ConfirmEmail), @"mvc.1.0.view", @"/Views/Account/ConfirmEmail.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e93fb76b138342a1dfef61bdbe86d720a7c0c467", @"/Views/Account/ConfirmEmail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"352788feff91f44f362d0671af1298e5a77ce188", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_ConfirmEmail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\admin\Desktop\BookStorePrueba\Views\Account\ConfirmEmail.cshtml"
   
    ViewData["Title"] = "ConfirmEmail";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container\">\r\n    <div class=\"row text-center\">\r\n        <div class=\"col-md-4\">\r\n\r\n");
#nullable restore
#line 9 "C:\Users\admin\Desktop\BookStorePrueba\Views\Account\ConfirmEmail.cshtml"
               if (ViewBag.Errors.Count == 0)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"alert alert-success\" role=\"alert\">\r\n                        <p class=\"p-1\">Your email has been verified successfully</p>\r\n                    </div>\r\n");
#nullable restore
#line 14 "C:\Users\admin\Desktop\BookStorePrueba\Views\Account\ConfirmEmail.cshtml"
                }
                else
                {


#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"alert alert-success\" role=\"alert\">\r\n");
#nullable restore
#line 19 "C:\Users\admin\Desktop\BookStorePrueba\Views\Account\ConfirmEmail.cshtml"
                         foreach (var error in ViewBag.Errors)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <p>");
#nullable restore
#line 21 "C:\Users\admin\Desktop\BookStorePrueba\Views\Account\ConfirmEmail.cshtml"
                          Write(error);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 22 "C:\Users\admin\Desktop\BookStorePrueba\Views\Account\ConfirmEmail.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </div>\r\n");
#nullable restore
#line 24 "C:\Users\admin\Desktop\BookStorePrueba\Views\Account\ConfirmEmail.cshtml"

                }
            

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
