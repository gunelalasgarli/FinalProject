#pragma checksum "C:\Users\ASUS\Desktop\finalproject\FinalProject\backend\dominospizza\Views\Shared\_ModalPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "75c48a02450205a6088e0a8b5201893acf58d717"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__ModalPartial), @"mvc.1.0.view", @"/Views/Shared/_ModalPartial.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"75c48a02450205a6088e0a8b5201893acf58d717", @"/Views/Shared/_ModalPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6cc8b79e042fc46f9ad7bd70a09bbd4fc50e9e7f", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__ModalPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Product>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Cart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "addtocart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-route-count", "1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-route-size", "1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-lg btn-outline-danger addToCart"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"

<div class=""modal-dialog modal-lg"">
    <div class=""modal-content"">
        <div class=""modal-header"">
            <button type=""button"" class=""btn-close"" data-bs-dismiss=""modal"" aria-label=""Close""></button>
        </div>
        <div class=""modal-body"">
            <div class=""container"">
                <div class=""row"">
                    <div class=""img-modal col-xs-12 col-sm-4 col-md-4 col-lg-5"">
                        <img");
            BeginWriteAttribute("src", " src=\"", 464, "\"", 492, 2);
            WriteAttributeValue("", 470, "img/pizza/", 470, 10, true);
#nullable restore
#line 13 "C:\Users\ASUS\Desktop\finalproject\FinalProject\backend\dominospizza\Views\Shared\_ModalPartial.cshtml"
WriteAttributeValue("", 480, Model.Image, 480, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 493, "\"", 499, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                    </div>\r\n                    <div class=\"info-modal col-xs-12 col-sm-7 col-md-7 col-lg-6\">\r\n                        <h4 class=\"pizza-name\">");
#nullable restore
#line 16 "C:\Users\ASUS\Desktop\finalproject\FinalProject\backend\dominospizza\Views\Shared\_ModalPartial.cshtml"
                                          Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                        <p class=\"ingridients\">");
#nullable restore
#line 17 "C:\Users\ASUS\Desktop\finalproject\FinalProject\backend\dominospizza\Views\Shared\_ModalPartial.cshtml"
                                          Write(Model.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                        <hr>
                        <div class=""row"">
                            <div class=""count"">

                                <div class=""input-group"">
                                    <span class=""input-group-btn"">
                                        <button type=""button"" class=""quantity-left-minus btn btn-danger btn-number"" data-type=""minus"" data-field="""">
                                            <span><i class=""fa fa-minus"" aria-hidden=""true""></i></span>
                                        </button>
                                    </span>
                                    <input type=""text"" id=""quantity"" name=""quantity"" class=""form-control input-number"" value=""1"" min=""1"" max=""100"">
                                    <span class=""input-group-btn"">
                                        <button type=""button"" class=""quantity-right-plus btn btn-danger btn-number"" data-type=""plus"" data-field="""">
                                            <span>");
            WriteLiteral(@"<i class=""fa fa-plus"" aria-hidden=""true""></i></span>
                                        </button>
                                    </span>
                                </div>

                            </div>
                            <div class=""total-price text-center"">
                                <h6><span id=""total-price"">");
#nullable restore
#line 38 "C:\Users\ASUS\Desktop\finalproject\FinalProject\backend\dominospizza\Views\Shared\_ModalPartial.cshtml"
                                                      Write(Model.Price.ToString("F2"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>AZN</h6>\r\n                            </div>\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "75c48a02450205a6088e0a8b5201893acf58d7179277", async() => {
                WriteLiteral("\r\n                                SƏBƏTƏ ƏLAVƏ ET\r\n                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-Id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 40 "C:\Users\ASUS\Desktop\finalproject\FinalProject\backend\dominospizza\Views\Shared\_ModalPartial.cshtml"
                                                                              WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-Id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-count", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["count"] = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["size"] = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 41 "C:\Users\ASUS\Desktop\finalproject\FinalProject\backend\dominospizza\Views\Shared\_ModalPartial.cshtml"
                                   Write(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("data-id", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                        </div>
                        <hr>
                        <div class=""scrollable row"">
                            <h6 class=""title"">Ölçü seçin</h6>
                            <div class=""btn-group"" role=""group"" aria-label=""Basic radio toggle button group"">
                                <input type=""radio"" class=""btn-check"" name=""btnradio"" id=""btnradio1"" autocomplete=""off"" checked>
                                <label class=""btn btn-outline-primary"" for=""btnradio1""><img src=""img/pizza/small.png""");
            BeginWriteAttribute("alt", " alt=\"", 3064, "\"", 3070, 0);
            EndWriteAttribute();
            WriteLiteral("><br><span class=\"size\">Kiçik</span><br> <span class=\"price-size\">");
#nullable restore
#line 50 "C:\Users\ASUS\Desktop\finalproject\FinalProject\backend\dominospizza\Views\Shared\_ModalPartial.cshtml"
                                                                                                                                                                                         Write(Model.Price.ToString("F2"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>AZN</label>

                                <input type=""radio"" class=""btn-check"" name=""btnradio"" id=""btnradio2"" autocomplete=""off"">
                                <label class=""btn btn-outline-primary"" for=""btnradio2""><img src=""img/pizza/medium.png""");
            BeginWriteAttribute("alt", " alt=\"", 3426, "\"", 3432, 0);
            EndWriteAttribute();
            WriteLiteral("><br><span class=\"size\">Orta</span><br> <span class=\"price-size\">");
#nullable restore
#line 53 "C:\Users\ASUS\Desktop\finalproject\FinalProject\backend\dominospizza\Views\Shared\_ModalPartial.cshtml"
                                                                                                                                                                                          Write((Model.Price*1.6).ToString("F2"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>AZN</label>

                                <input type=""radio"" class=""btn-check"" name=""btnradio"" id=""btnradio3"" autocomplete=""off"">
                                <label class=""btn btn-outline-primary"" for=""btnradio3""><img src=""img/pizza/extra.png""");
            BeginWriteAttribute("alt", " alt=\"", 3794, "\"", 3800, 0);
            EndWriteAttribute();
            WriteLiteral("><br><span class=\"size\">Böyük</span><br> <span class=\"price-size\">");
#nullable restore
#line 56 "C:\Users\ASUS\Desktop\finalproject\FinalProject\backend\dominospizza\Views\Shared\_ModalPartial.cshtml"
                                                                                                                                                                                          Write((Model.Price*2).ToString("F2"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>AZN</label>
                            </div>
                            <hr>
                        </div>
                    </div>

                </div>
            </div>
        </div>

    </div>
</div>
<script src=""https://cdnjs.cloudflare.com/ajax/libs/jquery/3.6.0/jquery.min.js "" integrity=""sha512-894YE6QWD5I59HgZOGReFYm4dnWc1Qt5NtvYSaNcOP+u1T9qYdvdihz0PPSiiqn/+/3e7Jo4EaG7TubfWGUrMQ=="" crossorigin="" anonymous "" referrerpolicy=""no-referrer ""></script>
<script>
    var price = $('#total-price').text().slice(0, -1);
    var quantitiy = 1;
    $('.quantity-right-plus').click(function (e) {
        e.preventDefault();
        quantitiy++;
        $('#quantity').val(quantitiy);
        $('#total-price').text(`${(+quantitiy * +price).toFixed(2)}`);
        let url = document.querySelectorAll('.addToCart')[1].getAttribute('href');
        let urlPart = url.slice(url.indexOf('count'), url.indexOf('count') + 7);
        url = url.replace(urlPart, `count=${quantitiy}`);
    ");
            WriteLiteral(@"    document.querySelectorAll('.addToCart')[1].setAttribute('href', url);
    });


    $('.quantity-left-minus').click(function (e) {
        e.preventDefault();
        if (quantitiy > 1) {
            quantitiy--;
            $('#quantity').val(quantitiy);
            $('#total-price').text(`${(+quantitiy * +price).toFixed(2)}`);
            let url = document.querySelectorAll('.addToCart')[1].getAttribute('href');
            let urlPart = url.slice(url.indexOf('count'), url.indexOf('count') + 7);
            url = url.replace(urlPart, `count=${quantitiy}`);
            document.querySelectorAll('.addToCart')[1].setAttribute('href', url);
        }
    });

    document.querySelectorAll('.scrollable label').forEach((elem, index) => {
        elem.addEventListener('click', function () {
            document.querySelector('#total-price').innerText = elem.querySelector('.price-size').innerText;
            let url = document.querySelector('.addToCart').getAttribute('href');
            l");
            WriteLiteral(@"et urlPart = url.slice(url.indexOf('size'), url.indexOf('size') + 6);
            url = url.replace(urlPart, `size=${index+1}`);
            price = elem.querySelector('.price-size').innerText.slice(0, -1);
            console.log(url)
        });

    })

</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Product> Html { get; private set; }
    }
}
#pragma warning restore 1591
