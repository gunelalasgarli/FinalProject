#pragma checksum "C:\Users\ASUS\Desktop\finalproject\FinalProject\backend\dominospizza\Views\Pizza\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a4352d2c82d597cf16efb93c4328293b95beb999"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Pizza_Index), @"mvc.1.0.view", @"/Views/Pizza/Index.cshtml")]
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
using dominospizza.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\ASUS\Desktop\finalproject\FinalProject\backend\dominospizza\Views\_ViewImports.cshtml"
using dominospizza.ViewModels.Home;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a4352d2c82d597cf16efb93c4328293b95beb999", @"/Views/Pizza/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d0e87af4a27aa815c5f6ffde3e9c31f918b11953", @"/Views/_ViewImports.cshtml")]
    public class Views_Pizza_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\ASUS\Desktop\finalproject\FinalProject\backend\dominospizza\Views\Pizza\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"container\">\r\n    <div class=\"row\" id=\"scrollspyHeading1\">\r\n        <div class=\"col-lg-3 col-md-4 col-sm-6 col-xs-12\">\r\n            <a");
            BeginWriteAttribute("href", " href=\"", 188, "\"", 195, 0);
            EndWriteAttribute();
            WriteLiteral(" data-bs-toggle=\"modal\" data-bs-target=\"#exampleModal\">\r\n                <div class=\"pizza-item\">\r\n                    <div class=\"pizza-item-img\">\r\n                        <img src=\"img/pizza/pizza1.jpg\"");
            BeginWriteAttribute("alt", " alt=\"", 400, "\"", 406, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                    </div>
                    <div class=""pizza-item-text"">
                        <div class=""text-head"">
                            <h4>Italiano</h4>
                        </div>
                        <div class=""text-description"">
                            <p>Kub Sucuk, Göbələk, Közlənmiş Bibər</p>
                        </div>
                        <div class=""price d-grid"">
                            <h6>10.90$</h6>
                            <span>-dan başlayaraq</span>
                        </div>
                    </div>
                </div>
            </a>
            <div class=""modal fade"" id=""exampleModal"" tabindex=""-1"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
                <div class=""modal-dialog modal-lg"">
                    <div class=""modal-content"">
                        <div class=""modal-header"">
                            <button type=""button"" class=""btn-close"" data-bs-dismiss=""modal"" aria-label=""Close""></butto");
            WriteLiteral(@"n>
                        </div>
                        <div class=""modal-body"">
                            <div class=""container"">
                                <div class=""row"">
                                    <div class=""img-modal col-xs-12 col-sm-4 col-md-4 col-lg-5"">
                                        <img src=""img/pizza/pizza1.jpg""");
            BeginWriteAttribute("alt", " alt=\"", 1790, "\"", 1796, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                                    </div>
                                    <div class=""info-modal col-xs-12 col-sm-7 col-md-7 col-lg-6"">
                                        <h4 class=""pizza-name"">Italiano</h4>
                                        <p class=""ingridients"">Kub Sucuk, Göbələk, Közlənmiş Bibər, Qara Zeytun, Kəklikotu, Pizza Sousu, Mozzarella Pendiri</p>
                                        <hr>
                                        <div class=""row"">
                                            <div class=""count"">

                                                <div class=""input-group"">
                                                    <span class=""input-group-btn"">
                                                        <button type=""button"" class=""quantity-left-minus btn btn-danger btn-number"" data-type=""minus"" data-field="""">
                                                            <span><i class=""fa fa-minus"" aria-hidden=""true""></i></span>
                     ");
            WriteLiteral(@"                                   </button>
                                                    </span>
                                                    <input type=""text"" id=""quantity"" name=""quantity"" class=""form-control input-number"" value=""1"" min=""1"" max=""100"">
                                                    <span class=""input-group-btn"">
                                                        <button type=""button"" class=""quantity-right-plus btn btn-danger btn-number"" data-type=""plus"" data-field="""">
                                                            <span><i class=""fa fa-plus"" aria-hidden=""true""></i></span>
                                                        </button>
                                                    </span>
                                                </div>

                                            </div>
                                            <div class=""total-price text-center"">
                                                <h6 id=""total-");
            WriteLiteral(@"price"">10.90$</h6>
                                            </div>
                                            <div data-id=""1"" class=""btn btn-lg btn-outline-danger addToCart"">
                                                SƏBƏTƏ ƏLAVƏ ET
                                            </div>
                                        </div>
                                        <hr>
                                        <div class=""scrollable row"">
                                            <h6 class=""title"">Ölçü seçin</h6>
                                            <div class=""btn-group"" role=""group"" aria-label=""Basic radio toggle button group"">
                                                <input type=""radio"" class=""btn-check"" name=""btnradio"" id=""btnradio1"" autocomplete=""off"" checked>
                                                <label class=""btn btn-outline-primary"" for=""btnradio1""><img src=""img/pizza//small.png""");
            BeginWriteAttribute("alt", " alt=\"", 4795, "\"", 4801, 0);
            EndWriteAttribute();
            WriteLiteral(@"><br>Kiçik<br> <span>10.90$</span></label>

                                                <input type=""radio"" class=""btn-check"" name=""btnradio"" id=""btnradio2"" autocomplete=""off"">
                                                <label class=""btn btn-outline-primary"" for=""btnradio2""><img src=""img/pizza/medium.png""");
            BeginWriteAttribute("alt", " alt=\"", 5120, "\"", 5126, 0);
            EndWriteAttribute();
            WriteLiteral(@"><br>Orta<br> <span>17.90$</span></label>

                                                <input type=""radio"" class=""btn-check"" name=""btnradio"" id=""btnradio3"" autocomplete=""off"">
                                                <label class=""btn btn-outline-primary"" for=""btnradio3""><img src=""img/pizza/extra.png""");
            BeginWriteAttribute("alt", " alt=\"", 5443, "\"", 5449, 0);
            EndWriteAttribute();
            WriteLiteral(@"><br>Böyük<br> <span>23.90$</span></label>
                                            </div>
                                            <hr>
                                            <h6 class=""title"">Standart İngridientlər</h6>
                                            <div class=""form-check"">
                                                <input class=""form-check-input"" type=""checkbox""");
            BeginWriteAttribute("value", " value=\"", 5852, "\"", 5860, 0);
            EndWriteAttribute();
            WriteLiteral(@" id=""flexCheckChecked"" checked>
                                                <label class=""form-check-label"" for=""flexCheckChecked"">Kub sucuk</label>
                                            </div>
                                            <div class=""form-check"">
                                                <input class=""form-check-input"" type=""checkbox""");
            BeginWriteAttribute("value", " value=\"", 6233, "\"", 6241, 0);
            EndWriteAttribute();
            WriteLiteral(@" id=""flexCheckChecked"" checked>
                                                <label class=""form-check-label"" for=""flexCheckChecked"">Göbələk</label>
                                            </div>
                                            <div class=""form-check"">
                                                <input class=""form-check-input"" type=""checkbox""");
            BeginWriteAttribute("value", " value=\"", 6612, "\"", 6620, 0);
            EndWriteAttribute();
            WriteLiteral(@" id=""flexCheckChecked"" checked>
                                                <label class=""form-check-label"" for=""flexCheckChecked"">Közlənmiş Bibər</label>
                                            </div>
                                            <div class=""form-check"">
                                                <input class=""form-check-input"" type=""checkbox""");
            BeginWriteAttribute("value", " value=\"", 6999, "\"", 7007, 0);
            EndWriteAttribute();
            WriteLiteral(@" id=""flexCheckChecked"" checked>
                                                <label class=""form-check-label"" for=""flexCheckChecked"">Qara Zeytun</label>
                                            </div>
                                            <hr>
                                            <h6 class=""title"">Əlavə İngridientlər</h6>
                                            <div class=""form-check"">
                                                <input class=""form-check-input"" type=""checkbox""");
            BeginWriteAttribute("value", " value=\"", 7520, "\"", 7528, 0);
            EndWriteAttribute();
            WriteLiteral(@" id=""flexCheckDefault"">
                                                <label class=""form-check-label"" for=""flexCheckDefault"">
                                                    Mozzarella Pendiri
                                                    <br><span class=""price"">+2$</span>
                                                </label>
                                            </div>
                                            <div class=""form-check"">
                                                <input class=""form-check-input"" type=""checkbox""");
            BeginWriteAttribute("value", " value=\"", 8094, "\"", 8102, 0);
            EndWriteAttribute();
            WriteLiteral(@" id=""flexCheckDefault"">
                                                <label class=""form-check-label"" for=""flexCheckDefault"">
                                                    Çeddar Pendiri
                                                    <br><span class=""price"">+2$</span>
                                                </label>
                                            </div>
                                            <div class=""form-check"">
                                                <input class=""form-check-input"" type=""checkbox""");
            BeginWriteAttribute("value", " value=\"", 8664, "\"", 8672, 0);
            EndWriteAttribute();
            WriteLiteral(@" id=""flexCheckDefault"">
                                                <label class=""form-check-label"" for=""flexCheckDefault"">
                                                    Pepperonni
                                                    <br><span class=""price"">+2$</span>
                                                </label>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
        <div class=""col-lg-3 col-md-4 col-sm-6 col-xs-12"">
            <a");
            BeginWriteAttribute("href", " href=\"", 9431, "\"", 9438, 0);
            EndWriteAttribute();
            WriteLiteral(" data-bs-toggle=\"modal\" data-bs-target=\"#exampleModal\">\r\n                <div class=\"pizza-item\">\r\n                    <div class=\"pizza-item-img\">\r\n                        <img src=\"img/pizza/pizza2.jpg\"");
            BeginWriteAttribute("alt", " alt=\"", 9643, "\"", 9649, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                    </div>
                    <div class=""pizza-item-text"">
                        <div class=""text-head"">
                            <h4>Steyk</h4>
                        </div>
                        <div class=""text-description"">
                            <p>Kub Sucuk, Göbələk, Közlənmiş Bibər</p>
                        </div>
                        <div class=""price d-grid"">
                            <h6>10.90$</h6>
                            <span>-dan başlayaraq</span>
                        </div>
                    </div>
                </div>
            </a>
            <div class=""modal fade"" id=""exampleModal"" tabindex=""-1"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
                <div class=""modal-dialog modal-lg"">
                    <div class=""modal-content"">
                        <div class=""modal-header"">
                            <button type=""button"" class=""btn-close"" data-bs-dismiss=""modal"" aria-label=""Close""></button>");
            WriteLiteral(@"
                        </div>
                        <div class=""modal-body"">
                            <div class=""container"">
                                <div class=""row"">
                                    <div class=""img-modal col-xs-12 col-sm-5 col-md-5 col-lg-7"">
                                        <img src=""img/pizza/pizza2.jpg""");
            BeginWriteAttribute("alt", " alt=\"", 11030, "\"", 11036, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                                    </div>
                                    <div class=""pizza-modal col-xs-12 col-sm-5 col-md-5 col-lg-7""></div>
                                </div>
                            </div>
                        </div>
                        <div class=""modal-footer"">
                            <button type=""button"" class=""btn btn-secondary"" data-bs-dismiss=""modal"">Close</button>
                            <button type=""button"" class=""btn btn-primary"">Save changes</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class=""col-lg-3 col-md-4 col-sm-6 col-xs-12"">

            <a");
            BeginWriteAttribute("href", " href=\"", 11759, "\"", 11766, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                <div class=\"pizza-item\">\r\n                    <div class=\"pizza-item-img\">\r\n                        <img src=\"img/pizza/pizza3.jpg\"");
            BeginWriteAttribute("alt", " alt=\"", 11917, "\"", 11923, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                    </div>
                    <div class=""pizza-item-text"">
                        <div class=""text-head"">
                            <h4>Mexicano</h4>
                        </div>
                        <div class=""text-description"">
                            <p>Kub Sucuk, Göbələk, Közlənmiş Bibər</p>
                        </div>
                        <div class=""price d-grid"">
                            <h6>10.90$</h6>
                            <span>-dan başlayaraq</span>
                        </div>
                    </div>
                </div>
            </a>
        </div>
        <div class=""col-lg-3 col-md-4 col-sm-6 col-xs-12"">
            <a");
            BeginWriteAttribute("href", " href=\"", 12641, "\"", 12648, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                <div class=\"pizza-item\">\r\n                    <div class=\"pizza-item-img\">\r\n                        <img src=\"img/pizza/pizza4.jpg\"");
            BeginWriteAttribute("alt", " alt=\"", 12799, "\"", 12805, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                    </div>
                    <div class=""pizza-item-text"">
                        <div class=""text-head"">
                            <h4>Qril toyuq</h4>
                        </div>
                        <div class=""text-description"">
                            <p>Kub Sucuk, Göbələk, Közlənmiş Bibər</p>
                        </div>
                        <div class=""price d-grid"">
                            <h6>10.90$</h6>
                            <span>-dan başlayaraq</span>
                        </div>
                    </div>
                </div>
            </a>
        </div>
    </div>
    <div class=""row"" id=""scrollspyHeading2"">
        <div class=""col-lg-3 col-md-4 col-sm-6 col-xs-12"">
            <a");
            BeginWriteAttribute("href", " href=\"", 13583, "\"", 13590, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                <div class=\"pizza-item\">\r\n                    <div class=\"pizza-item-img\">\r\n                        <img src=\"img/pizza/pizza5.jpg\"");
            BeginWriteAttribute("alt", " alt=\"", 13741, "\"", 13747, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                    </div>
                    <div class=""pizza-item-text"">
                        <div class=""text-head"">
                            <h4>Marqerita</h4>
                        </div>
                        <div class=""text-description"">
                            <p>Kub Sucuk, Göbələk, Közlənmiş Bibər</p>
                        </div>
                        <div class=""price d-grid"">
                            <h6>10.90$</h6>
                            <span>-dan başlayaraq</span>
                        </div>
                    </div>
                </div>
            </a>
        </div>
        <div class=""col-lg-3 col-md-4 col-sm-6 col-xs-12"">
            <a");
            BeginWriteAttribute("href", " href=\"", 14466, "\"", 14473, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                <div class=\"pizza-item\">\r\n                    <div class=\"pizza-item-img\">\r\n                        <img src=\"img/pizza/pizza6.jpg\"");
            BeginWriteAttribute("alt", " alt=\"", 14624, "\"", 14630, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                    </div>
                    <div class=""pizza-item-text"">
                        <div class=""text-head"">
                            <h4>Bol 5-li</h4>
                        </div>
                        <div class=""text-description"">
                            <p>Kub Sucuk, Göbələk, Közlənmiş Bibər</p>
                        </div>
                        <div class=""price d-grid"">
                            <h6>10.90$</h6>
                            <span>-dan başlayaraq</span>
                        </div>
                    </div>
                </div>
            </a>
        </div>
        <div class=""col-lg-3 col-md-4 col-sm-6 col-xs-12"">
            <a");
            BeginWriteAttribute("href", " href=\"", 15348, "\"", 15355, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                <div class=\"pizza-item\">\r\n                    <div class=\"pizza-item-img\">\r\n                        <img src=\"img/pizza/pizza7.jpg\"");
            BeginWriteAttribute("alt", " alt=\"", 15506, "\"", 15512, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                    </div>
                    <div class=""pizza-item-text"">
                        <div class=""text-head"">
                            <h4>Pepperoni</h4>
                        </div>
                        <div class=""text-description"">
                            <p>Kub Sucuk, Göbələk, Közlənmiş Bibər</p>
                        </div>
                        <div class=""price d-grid"">
                            <h6>10.90$</h6>
                            <span>-dan başlayaraq</span>
                        </div>
                    </div>
                </div>
            </a>
        </div>
        <div class=""col-lg-3 col-md-4 col-sm-6 col-xs-12"">
            <a");
            BeginWriteAttribute("href", " href=\"", 16231, "\"", 16238, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                <div class=\"pizza-item\">\r\n                    <div class=\"pizza-item-img\">\r\n                        <img src=\"img/pizza/pizza8.jpg\"");
            BeginWriteAttribute("alt", " alt=\"", 16389, "\"", 16395, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                    </div>
                    <div class=""pizza-item-text"">
                        <div class=""text-head"">
                            <h4>Fit&Freş</h4>
                        </div>
                        <div class=""text-description"">
                            <p>Kub Sucuk, Göbələk, Közlənmiş Bibər</p>
                        </div>
                        <div class=""price d-grid"">
                            <h6>10.90$</h6>
                            <span>-dan başlayaraq</span>
                        </div>
                    </div>
                </div>
            </a>
        </div>
    </div>
    <div class=""row"" id=""scrollspyHeading3"">
        <div class=""col-lg-3 col-md-4 col-sm-6 col-xs-12"">
            <a");
            BeginWriteAttribute("href", " href=\"", 17171, "\"", 17178, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                <div class=\"pizza-item\">\r\n                    <div class=\"pizza-item-img\">\r\n                        <img src=\"img/pizza/pizza9.jpg\"");
            BeginWriteAttribute("alt", " alt=\"", 17329, "\"", 17335, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                    </div>
                    <div class=""pizza-item-text"">
                        <div class=""text-head"">
                            <h4>Vegi</h4>
                        </div>
                        <div class=""text-description"">
                            <p>Kub Sucuk, Göbələk, Közlənmiş Bibər</p>
                        </div>
                        <div class=""price d-grid"">
                            <h6>10.90$</h6>
                            <span>-dan başlayaraq</span>
                        </div>
                    </div>
                </div>
            </a>
        </div>
        <div class=""col-lg-3 col-md-4 col-sm-6 col-xs-12"">
            <a");
            BeginWriteAttribute("href", " href=\"", 18049, "\"", 18056, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                <div class=\"pizza-item\">\r\n                    <div class=\"pizza-item-img\">\r\n                        <img src=\"img/pizza/pizza10.jpg\"");
            BeginWriteAttribute("alt", " alt=\"", 18208, "\"", 18214, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                    </div>
                    <div class=""pizza-item-text"">
                        <div class=""text-head"">
                            <h4>Sosial</h4>
                        </div>
                        <div class=""text-description"">
                            <p>Kub Sucuk, Göbələk, Közlənmiş Bibər</p>
                        </div>
                        <div class=""price d-grid"">
                            <h6>10.90$</h6>
                            <span>-dan başlayaraq</span>
                        </div>
                    </div>
                </div>
            </a>
        </div>
        <div class=""col-lg-3 col-md-4 col-sm-6 col-xs-12"">
            <a");
            BeginWriteAttribute("href", " href=\"", 18930, "\"", 18937, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                <div class=\"pizza-item\">\r\n                    <div class=\"pizza-item-img\">\r\n                        <img src=\"img/pizza/pizza11.jpg\"");
            BeginWriteAttribute("alt", " alt=\"", 19089, "\"", 19095, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                    </div>
                    <div class=""pizza-item-text"">
                        <div class=""text-head"">
                            <h4>Portofino</h4>
                        </div>
                        <div class=""text-description"">
                            <p>Kub Sucuk, Göbələk, Közlənmiş Bibər</p>
                        </div>
                        <div class=""price d-grid"">
                            <h6>10.90$</h6>
                            <span>-dan başlayaraq</span>
                        </div>
                    </div>
                </div>
            </a>
        </div>
        <div class=""col-lg-3 col-md-4 col-sm-6 col-xs-12"">
            <a");
            BeginWriteAttribute("href", " href=\"", 19814, "\"", 19821, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                <div class=\"pizza-item\">\r\n                    <div class=\"pizza-item-img\">\r\n                        <img src=\"img/pizza/pizza12.jpg\"");
            BeginWriteAttribute("alt", " alt=\"", 19973, "\"", 19979, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                    </div>
                    <div class=""pizza-item-text"">
                        <div class=""text-head"">
                            <h4>Kalipso</h4>
                        </div>
                        <div class=""text-description"">
                            <p>Kub Sucuk, Göbələk, Közlənmiş Bibər</p>
                        </div>
                        <div class=""price d-grid"">
                            <h6>10.90$</h6>
                            <span>-dan başlayaraq</span>
                        </div>
                    </div>
                </div>
            </a>
        </div>
    </div>
    <div class=""row"" id=""scrollspyHeading4"">
        <div class=""col-lg-3 col-md-4 col-sm-6 col-xs-12"">
            <a");
            BeginWriteAttribute("href", " href=\"", 20754, "\"", 20761, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                <div class=\"pizza-item\">\r\n                    <div class=\"pizza-item-img\">\r\n                        <img src=\"img/pizza/yari-yariya.png\"");
            BeginWriteAttribute("alt", " alt=\"", 20917, "\"", 20923, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                    </div>
                    <div class=""pizza-item-text"">
                        <div class=""text-head"">
                            <h4>Yarı-yarıya</h4>
                        </div>
                        <div class=""text-description"">
                            <p>Seçə bilmirsiz? Onda bir pizzada iki ləzzət..</p>
                        </div>
                        <div class=""price d-grid"">
                            <h6>8.90$</h6>
                            <span>-dan başlayaraq</span>
                        </div>
                    </div>
                </div>
            </a>
        </div>
    </div>
    <div class=""row"" id=""scrollspyHeading5"">
        <div class=""col-lg-3 col-md-4 col-sm-6 col-xs-12"">
            <a");
            BeginWriteAttribute("href", " href=\"", 21711, "\"", 21718, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                <div class=\"pizza-item\">\r\n                    <div class=\"pizza-item-img\">\r\n                        <img src=\"img/pizza/create-own-pizza.png\"");
            BeginWriteAttribute("alt", " alt=\"", 21879, "\"", 21885, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                    </div>
                    <div class=""pizza-item-text"">
                        <div class=""text-head"">
                            <h4>öz pizzanı yarat</h4>
                        </div>
                        <div class=""text-description"">
                            <p>Seçmək olmur? Onda öz pizzanı yarat!</p>
                        </div>
                        <div class=""price d-grid"">
                            <h6>7.50$</h6>
                            <span>-dan başlayaraq</span>
                        </div>
                    </div>
                </div>
            </a>
        </div>
    </div>
</div>");
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
