#pragma checksum "C:\Users\J130075\Desktop\TesteDoGit\ProjProfi\AgendamentoProjeto\Views\Laboratorios\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1128aacd085b7fcaed5b9574c98b450ba036aa96"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Laboratorios_Details), @"mvc.1.0.view", @"/Views/Laboratorios/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Laboratorios/Details.cshtml", typeof(AspNetCore.Views_Laboratorios_Details))]
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
#line 1 "C:\Users\J130075\Desktop\TesteDoGit\ProjProfi\AgendamentoProjeto\Views\_ViewImports.cshtml"
using AgendamentoProjeto;

#line default
#line hidden
#line 2 "C:\Users\J130075\Desktop\TesteDoGit\ProjProfi\AgendamentoProjeto\Views\_ViewImports.cshtml"
using AgendamentoProjeto.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1128aacd085b7fcaed5b9574c98b450ba036aa96", @"/Views/Laboratorios/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"641cfe44d48d57df3d54e8628572e65cafa6db78", @"/Views/_ViewImports.cshtml")]
    public class Views_Laboratorios_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AgendamentoProjeto.Models.Laboratorio>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
            BeginContext(46, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\J130075\Desktop\TesteDoGit\ProjProfi\AgendamentoProjeto\Views\Laboratorios\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
            BeginContext(91, 134, true);
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div>\r\n    <h4>Laboratorio</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(226, 51, false);
#line 14 "C:\Users\J130075\Desktop\TesteDoGit\ProjProfi\AgendamentoProjeto\Views\Laboratorios\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.NomeLaboratorio));

#line default
#line hidden
            EndContext();
            BeginContext(277, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(341, 47, false);
#line 17 "C:\Users\J130075\Desktop\TesteDoGit\ProjProfi\AgendamentoProjeto\Views\Laboratorios\Details.cshtml"
       Write(Html.DisplayFor(model => model.NomeLaboratorio));

#line default
#line hidden
            EndContext();
            BeginContext(388, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(451, 44, false);
#line 20 "C:\Users\J130075\Desktop\TesteDoGit\ProjProfi\AgendamentoProjeto\Views\Laboratorios\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Hardware));

#line default
#line hidden
            EndContext();
            BeginContext(495, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(559, 40, false);
#line 23 "C:\Users\J130075\Desktop\TesteDoGit\ProjProfi\AgendamentoProjeto\Views\Laboratorios\Details.cshtml"
       Write(Html.DisplayFor(model => model.Hardware));

#line default
#line hidden
            EndContext();
            BeginContext(599, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(662, 44, false);
#line 26 "C:\Users\J130075\Desktop\TesteDoGit\ProjProfi\AgendamentoProjeto\Views\Laboratorios\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Software));

#line default
#line hidden
            EndContext();
            BeginContext(706, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(770, 40, false);
#line 29 "C:\Users\J130075\Desktop\TesteDoGit\ProjProfi\AgendamentoProjeto\Views\Laboratorios\Details.cshtml"
       Write(Html.DisplayFor(model => model.Software));

#line default
#line hidden
            EndContext();
            BeginContext(810, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(873, 49, false);
#line 32 "C:\Users\J130075\Desktop\TesteDoGit\ProjProfi\AgendamentoProjeto\Views\Laboratorios\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.QuantidadePcs));

#line default
#line hidden
            EndContext();
            BeginContext(922, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(986, 45, false);
#line 35 "C:\Users\J130075\Desktop\TesteDoGit\ProjProfi\AgendamentoProjeto\Views\Laboratorios\Details.cshtml"
       Write(Html.DisplayFor(model => model.QuantidadePcs));

#line default
#line hidden
            EndContext();
            BeginContext(1031, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1094, 44, false);
#line 38 "C:\Users\J130075\Desktop\TesteDoGit\ProjProfi\AgendamentoProjeto\Views\Laboratorios\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Projetor));

#line default
#line hidden
            EndContext();
            BeginContext(1138, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1202, 40, false);
#line 41 "C:\Users\J130075\Desktop\TesteDoGit\ProjProfi\AgendamentoProjeto\Views\Laboratorios\Details.cshtml"
       Write(Html.DisplayFor(model => model.Projetor));

#line default
#line hidden
            EndContext();
            BeginContext(1242, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1305, 44, false);
#line 44 "C:\Users\J130075\Desktop\TesteDoGit\ProjProfi\AgendamentoProjeto\Views\Laboratorios\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.StatusId));

#line default
#line hidden
            EndContext();
            BeginContext(1349, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1413, 40, false);
#line 47 "C:\Users\J130075\Desktop\TesteDoGit\ProjProfi\AgendamentoProjeto\Views\Laboratorios\Details.cshtml"
       Write(Html.DisplayFor(model => model.StatusId));

#line default
#line hidden
            EndContext();
            BeginContext(1453, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1516, 42, false);
#line 50 "C:\Users\J130075\Desktop\TesteDoGit\ProjProfi\AgendamentoProjeto\Views\Laboratorios\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Status));

#line default
#line hidden
            EndContext();
            BeginContext(1558, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1622, 49, false);
#line 53 "C:\Users\J130075\Desktop\TesteDoGit\ProjProfi\AgendamentoProjeto\Views\Laboratorios\Details.cshtml"
       Write(Html.DisplayFor(model => model.Status.NomeStatus));

#line default
#line hidden
            EndContext();
            BeginContext(1671, 47, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            EndContext();
            BeginContext(1718, 65, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1128aacd085b7fcaed5b9574c98b450ba036aa9610563", async() => {
                BeginContext(1775, 4, true);
                WriteLiteral("Edit");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 58 "C:\Users\J130075\Desktop\TesteDoGit\ProjProfi\AgendamentoProjeto\Views\Laboratorios\Details.cshtml"
                           WriteLiteral(Model.LaboratorioId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1783, 8, true);
            WriteLiteral(" |\r\n    ");
            EndContext();
            BeginContext(1791, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1128aacd085b7fcaed5b9574c98b450ba036aa9612915", async() => {
                BeginContext(1813, 12, true);
                WriteLiteral("Back to List");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1829, 10, true);
            WriteLiteral("\r\n</div>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AgendamentoProjeto.Models.Laboratorio> Html { get; private set; }
    }
}
#pragma warning restore 1591
