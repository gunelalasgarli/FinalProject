#pragma checksum "C:\Users\ASUS\Desktop\finalproject\FinalProject\backend\dominospizza\Views\Location\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "163b6c1d1f1f93414c38ab08b9e93e5c41844f17"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Location_Index), @"mvc.1.0.view", @"/Views/Location/Index.cshtml")]
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
#line 1 "C:\Users\ASUS\Desktop\finalproject\FinalProject\backend\dominospizza\Views\_ViewImports.cshtml"
using dominospizza;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ASUS\Desktop\finalproject\FinalProject\backend\dominospizza\Views\_ViewImports.cshtml"
using dominospizza.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\ASUS\Desktop\finalproject\FinalProject\backend\dominospizza\Views\_ViewImports.cshtml"
using dominospizza.ViewModels.Basket;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\ASUS\Desktop\finalproject\FinalProject\backend\dominospizza\Views\_ViewImports.cshtml"
using dominospizza.ViewModels.Home;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\ASUS\Desktop\finalproject\FinalProject\backend\dominospizza\Views\_ViewImports.cshtml"
using dominospizza.ViewModels.AccountViewModel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\ASUS\Desktop\finalproject\FinalProject\backend\dominospizza\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"163b6c1d1f1f93414c38ab08b9e93e5c41844f17", @"/Views/Location/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6cc8b79e042fc46f9ad7bd70a09bbd4fc50e9e7f", @"/Views/_ViewImports.cshtml")]
    public class Views_Location_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Location>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\ASUS\Desktop\finalproject\FinalProject\backend\dominospizza\Views\Location\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container\">\r\n    <div class=\"row\">\r\n");
            WriteLiteral(@"        <div class=""col-lg-12"">
            <iframe src=""https://my.atlistmaps.com/map/f46825a5-6280-427e-8d0e-55d6847d1ce5?share=true"" allow=""geolocation"" width=""100%"" height=""400px"" frameborder=""0"" scrolling=""no"" allowfullscreen></iframe>
        </div>

    </div>
    
        <ul class=""row loc-list mt-2"">
");
#nullable restore
#line 34 "C:\Users\ASUS\Desktop\finalproject\FinalProject\backend\dominospizza\Views\Location\Index.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li class=\"col-lg-3 col-md-4 col-sm-6 col-xs-12 loc-list-item\">\r\n                    <a>\r\n                        <h5 class=\"item-title\">");
#nullable restore
#line 38 "C:\Users\ASUS\Desktop\finalproject\FinalProject\backend\dominospizza\Views\Location\Index.cshtml"
                                          Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                        <p class=\"item-address\">");
#nullable restore
#line 39 "C:\Users\ASUS\Desktop\finalproject\FinalProject\backend\dominospizza\Views\Location\Index.cshtml"
                                           Write(item.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        <p class=\"item-whour\"><i class=\"fas fa-clock\"></i> Açılır ");
#nullable restore
#line 40 "C:\Users\ASUS\Desktop\finalproject\FinalProject\backend\dominospizza\Views\Location\Index.cshtml"
                                                                             Write(item.OpeningTime);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - Bağlanır ");
#nullable restore
#line 40 "C:\Users\ASUS\Desktop\finalproject\FinalProject\backend\dominospizza\Views\Location\Index.cshtml"
                                                                                                          Write(item.ClosingTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    </a>\r\n                </li>\r\n");
#nullable restore
#line 43 "C:\Users\ASUS\Desktop\finalproject\FinalProject\backend\dominospizza\Views\Location\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </ul>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Location>> Html { get; private set; }
    }
}
#pragma warning restore 1591
