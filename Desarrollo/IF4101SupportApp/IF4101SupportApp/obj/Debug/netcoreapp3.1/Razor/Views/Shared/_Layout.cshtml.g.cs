#pragma checksum "C:\Users\yerya\Desktop\IF4101ProyectoFinal\Desarrollo\IF4101SupportApp\IF4101SupportApp\Views\Shared\_Layout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5c9efea259f609c1630b7334b7bb0c34ae1cb34c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Layout), @"mvc.1.0.view", @"/Views/Shared/_Layout.cshtml")]
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
#line 1 "C:\Users\yerya\Desktop\IF4101ProyectoFinal\Desarrollo\IF4101SupportApp\IF4101SupportApp\Views\_ViewImports.cshtml"
using IF4101SupportApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\yerya\Desktop\IF4101ProyectoFinal\Desarrollo\IF4101SupportApp\IF4101SupportApp\Views\_ViewImports.cshtml"
using IF4101SupportApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5c9efea259f609c1630b7334b7bb0c34ae1cb34c", @"/Views/Shared/_Layout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"be5ea176e9250f3a2c1fd94a1dfdefcdc30d5d74", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Layout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("icon"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("image/x-icon"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/img/logos/logo_tele_atlantico_ico.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("page-top"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!DOCTYPE html>\r\n<html lang=\"en\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5c9efea259f609c1630b7334b7bb0c34ae1cb34c4961", async() => {
                WriteLiteral("\r\n    <meta charset=\"utf-8\" />\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1, shrink-to-fit=no\" />\r\n    <meta name=\"description\"");
                BeginWriteAttribute("content", " content=\"", 195, "\"", 205, 0);
                EndWriteAttribute();
                WriteLiteral(" />\r\n    <meta name=\"author\"");
                BeginWriteAttribute("content", " content=\"", 234, "\"", 244, 0);
                EndWriteAttribute();
                WriteLiteral(" />\r\n\r\n    <title>Tele Atlántico</title>\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "5c9efea259f609c1630b7334b7bb0c34ae1cb34c5779", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"

    <!-- Font Awesome icons (free version)-->
    <script src=""https://use.fontawesome.com/releases/v5.15.1/js/all.js"" crossorigin=""anonymous""></script>

    <!-- Google fonts-->
    <link href=""https://fonts.googleapis.com/css?family=Montserrat:400,700"" rel=""stylesheet"" type=""text/css"" />
    <link href=""https://fonts.googleapis.com/css?family=Droid+Serif:400,700,400italic,700italic"" rel=""stylesheet"" type=""text/css"" />
    <link href=""https://fonts.googleapis.com/css?family=Roboto+Slab:400,100,300,700"" rel=""stylesheet"" type=""text/css"" />

    <!-- Core theme CSS (includes Bootstrap)-->
    <link href=""https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.5.2/css/bootstrap.css"" rel=""stylesheet"" type=""text/css"" />
    <link href=""https://cdn.datatables.net/1.10.23/css/dataTables.bootstrap4.min.css"" rel=""stylesheet"" type=""text/css"" />

    <link href=""css/styles.css"" rel=""stylesheet"" />
    <link href=""css/site.css"" rel=""stylesheet"" />

");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5c9efea259f609c1630b7334b7bb0c34ae1cb34c8764", async() => {
                WriteLiteral(@"

    <!-- Menu bar-->
    <nav class=""navbar navbar-expand-lg navbar-dark fixed-top"" id=""mainNav"">
        <div class=""container"">
            <a class=""navbar-brand js-scroll-trigger"" href=""#page-top""><img src=""assets/img/logos/logo_tele_atlantico.png""");
                BeginWriteAttribute("alt", " alt=\"", 1647, "\"", 1653, 0);
                EndWriteAttribute();
                WriteLiteral(@" /></a>
            <button class=""navbar-toggler navbar-toggler-right"" type=""button"" data-toggle=""collapse"" data-target=""#navbarResponsive"" aria-controls=""navbarResponsive"" aria-expanded=""false"" aria-label=""Toggle navigation"">
                Menu
                <i class=""fas fa-bars ml-1""></i>
            </button>
            <div class=""collapse navbar-collapse"" id=""navbarResponsive"">
                <ul class=""navbar-nav text-uppercase ml-auto"">
                    <li class=""nav-item""><a class=""nav-link js-scroll-trigger"" href=""#recordedIssues"">Recorded Issues</a></li>
                    <li class=""nav-item""><a class=""nav-link js-scroll-trigger"" href=""#section2"">section2</a></li>
                    <li class=""nav-item""><a class=""nav-link js-scroll-trigger"" href=""#section3"">section3</a></li>
                    <li class=""nav-item""><a class=""nav-link js-scroll-trigger"" href=""#section4"">section4</a></li>
                </ul>
            </div>
        </div>
    </nav>

    <!-- Masthe");
                WriteLiteral(@"ad-->
    <header class=""masthead"">
        <div class=""container"">
            <div class=""masthead-subheading"">Tele Atlántico</div>
            <div class=""masthead-heading text-uppercase"">Welcome!</div>
        </div>
    </header>

    <!-- Recorded issues-->
    <section class=""page-section"" id=""recordedIssues"">
        ");
#nullable restore
#line 60 "C:\Users\yerya\Desktop\IF4101ProyectoFinal\Desarrollo\IF4101SupportApp\IF4101SupportApp\Views\Shared\_Layout.cshtml"
   Write(Html.Partial("~/Views/Employee/ViewRecordedIssues.cshtml"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"

        <!-- Modal -->
        <div class=""modal fade"" id=""IssueDetailsModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
            <div class=""modal-dialog modal-lg"" role=""document"">
                <div class=""modal-content"">
                    <div class=""modal-header"">
                        <h5 class=""modal-title"">Issue Details</h5>
                        <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                            <span aria-hidden=""true"">&times;</span>
                        </button>
                    </div>
                    <div class=""modal-body"">
                        ");
#nullable restore
#line 73 "C:\Users\yerya\Desktop\IF4101ProyectoFinal\Desarrollo\IF4101SupportApp\IF4101SupportApp\Views\Shared\_Layout.cshtml"
                   Write(Html.Partial("~/Views/Employee/ViewIssueDetails.cshtml"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                    </div>
                    <div class=""modal-footer"">
                        
                        <!--BT CLOSE-->
                        <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Close</button>

                        <!--BT SAVE-->
                        <button type=""button"" class=""btn btn-primary"" id=""btn-save"">Save changes</button>

                        <!--BT CANCEL-->
                        <button type=""reset"" form=""#form-issue-details"" class=""btn btn-success btn-sm"">Cancel</button>

                    </div>
                </div>
            </div>
        </div>
    </section>

    <!-- section2-->
        <section class=""page-section bg-light"" id=""section2"">
            <div class=""container"">
                <div class=""text-center"">
                    <h2 class=""section-heading text-uppercase"">section2</h2>
                    <h3 class=""section-subheading text-muted"">Lorem ipsum dolor sit amet consectetur.</h3>");
                WriteLiteral(@"
                </div>
            </div>
        </section>

        <!-- section3-->
        <section class=""page-section"" id=""section3"">
            <div class=""container"">
                <div class=""text-center"">
                    <h2 class=""section-heading text-uppercase"">section3</h2>
                    <h3 class=""section-subheading text-muted"">Lorem ipsum dolor sit amet consectetur.</h3>
                </div>
            </div>
        </section>

        <!-- section4-->
        <section class=""page-section bg-light"" id=""section4"">
            <div class=""container"">
                <div class=""text-center"">
                    <h2 class=""section-heading text-uppercase"">section4</h2>
                    <h3 class=""section-subheading text-muted"">Lorem ipsum dolor sit amet consectetur.</h3>
                </div>
            </div>
        </section>

        <!-- Footer-->
        <footer class=""footer py-4"">
            <div class=""container"">
                <div cla");
                WriteLiteral(@"ss=""row align-items-center"">
                    <div class=""col-lg-4 text-lg-left"">Copyright © Tele Atlántico 2021</div>
                    <div class=""col-lg-4 text-lg-right"">
                        <a class=""mr-3"" href=""#!"">Privacy Policy</a>
                        <a href=""#!"">Terms of Use</a>
                    </div>
                </div>
            </div>
        </footer>

        <!-- Bootstrap core JS-->
        <script src=""https://cdnjs.cloudflare.com/ajax/libs/jquery/3.5.1/jquery.min.js""></script>
        <script src=""https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/js/bootstrap.bundle.min.js""></script>
        <!-- Third party plugin JS-->
        <script src=""https://cdnjs.cloudflare.com/ajax/libs/jquery-easing/1.4.1/jquery.easing.min.js""></script>

        <script src=""https://cdn.datatables.net/1.10.23/js/jquery.dataTables.min.js""></script>
        <script src=""https://cdn.datatables.net/1.10.23/js/dataTables.bootstrap4.min.js""></script>
        <!-- Core theme JS-->");
                WriteLiteral("\n        <script src=\"js/scripts.js\"></script>\r\n        <script src=\"js/site.js\"></script>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n    <div class=\"container\">\r\n        <main role=\"main\" class=\"pb-3\">\r\n            ");
#nullable restore
#line 150 "C:\Users\yerya\Desktop\IF4101ProyectoFinal\Desarrollo\IF4101SupportApp\IF4101SupportApp\Views\Shared\_Layout.cshtml"
       Write(RenderBody());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </main>\r\n    </div>\r\n\r\n</html>\r\n");
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
