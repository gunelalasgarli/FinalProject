#pragma checksum "C:\Users\ASUS\Desktop\finalproject\FinalProject\backend\dominospizza\Views\Shared\Components\Copyright\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "47a93fc716909f68c24c43ff51a9f378f78242c7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Copyright_Default), @"mvc.1.0.view", @"/Views/Shared/Components/Copyright/Default.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"47a93fc716909f68c24c43ff51a9f378f78242c7", @"/Views/Shared/Components/Copyright/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6cc8b79e042fc46f9ad7bd70a09bbd4fc50e9e7f", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_Copyright_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Settings>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\ASUS\Desktop\finalproject\FinalProject\backend\dominospizza\Views\Shared\Components\Copyright\Default.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"row \">\r\n    <div class=\"col-lg-12 \">\r\n        <ul class=\"copyrights \">\r\n            <li>\r\n                <p>Copyright © ");
#nullable restore
#line 10 "C:\Users\ASUS\Desktop\finalproject\FinalProject\backend\dominospizza\Views\Shared\Components\Copyright\Default.cshtml"
                          Write(Model.Copyright);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n\r\n            </li>\r\n            <li><span class=\"right-line \"></span></li>\r\n            <li>\r\n                <p>Developed by <a>Gunel Alasgarli</a> </p>\r\n            </li>\r\n        </ul>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Settings> Html { get; private set; }
    }
}
#pragma warning restore 1591
