#pragma checksum "C:\Users\maike\Desktop\IF4101ProyectoFinal\Desarrollo\IF4101SupportApp\IF4101SupportApp\Views\Employee\Insert.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "35f7331c667701590410482bce170d2ce48aeb68"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Employee_Insert), @"mvc.1.0.view", @"/Views/Employee/Insert.cshtml")]
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
#line 1 "C:\Users\maike\Desktop\IF4101ProyectoFinal\Desarrollo\IF4101SupportApp\IF4101SupportApp\Views\_ViewImports.cshtml"
using IF4101SupportApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\maike\Desktop\IF4101ProyectoFinal\Desarrollo\IF4101SupportApp\IF4101SupportApp\Views\_ViewImports.cshtml"
using IF4101SupportApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"35f7331c667701590410482bce170d2ce48aeb68", @"/Views/Employee/Insert.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d58c53569a741ed263786808af6aaee47fbcb176", @"/Views/_ViewImports.cshtml")]
    public class Views_Employee_Insert : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("employee_form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("role", new global::Microsoft.AspNetCore.Html.HtmlString("form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n<h4>Employee</h4>\r\n<hr />\r\n<div class=\"row\">\r\n    <div class=\"col-md-6\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "35f7331c667701590410482bce170d2ce48aeb684564", async() => {
                WriteLiteral(@"
            <div class=""form-row"">
                <div class=""form-group col-md-6"">
                    <label class=""control-label"">DNI</label>
                    <input type=""text"" id=""DNI"" name=""DNI"" class=""form-control"" />
                </div>
                <div class=""form-group col-md-6"">
                    <label class=""control-label"">Name</label>
                    <input type=""text"" id=""Employee_Name"" name=""Employee_Name"" class=""form-control"" />
                </div>
            </div>
            <div class=""form-row"">
                <div class=""form-group col-md-6"">
                    <label class=""control-label"">First Surname</label>
                    <input type=""text"" id=""First_Surname"" name=""First_Surname"" class=""form-control"" />
                </div>
                <div class=""form-group col-md-6"">
                    <label class=""control-label"">Secord Surname</label>
                    <input type=""text"" id=""Second_Surname"" name=""Second_Surname"" class=""form");
                WriteLiteral(@"-control"" />
                </div>
            </div>
            <div class=""form-row"">
                <div class=""form-group col-md-6"">
                    <label class=""control-label"">Email</label>
                    <input type=""email"" id=""Email"" name=""Email"" class=""form-control"" />
                </div>
                <div class=""form-group col-md-6"">
                    <label class=""control-label"">Password</label>
                    <input type=""password"" id=""Password"" name=""Password"" class=""form-control"" />
                </div>
            </div>
            <div class=""form-row"">
                <div class=""form-group col-md-12"">
                    <label class=""control-label"">Supervised By</label>
                    <select id=""Supervised"" name=""Supervised"" class=""form-control"">
                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "35f7331c667701590410482bce170d2ce48aeb686820", async() => {
                    WriteLiteral("Yerlin Leal");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                    </select>\r\n                </div>\r\n            </div>\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
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

        <div class=""row"">
            <button type=""submit"" form=""employee_form"" class=""btn btn-primary"">Create</button>
            <button type=""reset"" form=""employee_form"" class=""btn btn-danger"">Cancel</button>
        </div>
    </div>

</div>

<div class=""container"">
    <div class=""row py-5"">
        <div class=""col-12"">
            <table id=""example"" class=""table table-hover responsive nowrap"" style=""width:100%"">
                <thead>
                    <tr>
                        <th>Client Name</th>
                        <th>Phone Number</th>
                        <th>Profession</th>
                        <th>Date of Birth</th>
                        <th>App Access</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>
                            <a href=""#"">
                                <div class=""d-flex align-items-center"">
          ");
            WriteLiteral("                          <div class=\"avatar avatar-blue mr-3\">EB</div>\r\n\r\n                                    <div");
            BeginWriteAttribute("class", " class=\"", 3267, "\"", 3275, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                                        <p class=""font-weight-bold mb-0"">Ethan Black</p>
                                        <p class=""text-muted mb-0"">ethan-black@example.com</p>
                                    </div>
                                </div>
                            </a>
                        </td>
                        <td>(784) 667 8768</td>
                        <td>Designer</td>
                        <td>09/04/1996</td>
                        <td>
                            <div class=""badge badge-success badge-success-alt"">Enabled</div>
                        </td>
                        <td>
                            <div class=""dropdown"">
                                <button class=""btn btn-sm btn-icon"" type=""button"" id=""dropdownMenuButton2"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
                                    <i class=""fas fa-ellipsis-h"" data-toggle=""tooltip"" data-placement=""top""
                            ");
            WriteLiteral(@"           title=""Actions""></i>
                                </button>
                                <div class=""dropdown-menu"" aria-labelledby=""dropdownMenuButton2"">
                                    <a class=""dropdown-item"" href=""#""><i class=""fas fa-pencil mr-2""></i> Edit Profile</a>
                                    <a class=""dropdown-item text-danger"" href=""#""><i class=""fas fa-trash mr-2""></i> Remove</a>
                                </div>
                            </div>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <a href=""#"">
                                <div class=""d-flex align-items-center"">
                                    <div class=""avatar avatar-pink mr-3"">JR</div>

                                    <div");
            BeginWriteAttribute("class", " class=\"", 5158, "\"", 5166, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                                        <p class=""font-weight-bold mb-0"">Julie Richards</p>
                                        <p class=""text-muted mb-0"">julie_89@example.com</p>
                                    </div>
                                </div>
                            </a>
                        </td>
                        <td> (937) 874 6878</td>
                        <td>Investment Banker</td>
                        <td>13/01/1989</td>
                        <td>
                            <div class=""badge badge-success badge-success-alt"">Enabled</div>
                        </td>
                        <td>
                            <div class=""dropdown"">
                                <button class=""btn btn-sm btn-icon"" type=""button"" id=""dropdownMenuButton2"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
                                    <i class=""bx bx-dots-horizontal-rounded"" data-toggle=""tooltip"" data-placement=""top""
      ");
            WriteLiteral(@"                                 title=""Actions""></i>
                                </button>
                                <div class=""dropdown-menu"" aria-labelledby=""dropdownMenuButton2"">
                                    <a class=""dropdown-item"" href=""#""><i class=""bx bxs-pencil mr-2""></i> Edit Profile</a>
                                    <a class=""dropdown-item text-danger"" href=""#""><i class=""bx bxs-trash mr-2""></i> Remove</a>
                                </div>
                            </div>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</div>

<div class=""container text-center"">
    <div class=""row py-5"">
        <div class=""col-12"">
            <h6 class=""small text-danger"">Currently I'm just experimenting with this stuff, so there might be lots of redundant CSS.</h6>
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
