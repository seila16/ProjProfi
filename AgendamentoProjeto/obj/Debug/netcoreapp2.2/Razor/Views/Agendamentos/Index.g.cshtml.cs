#pragma checksum "C:\Users\thigg\source\repos\ProjProfi\AgendamentoProjeto\Views\Agendamentos\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "de1315b1d052c0e10f0449a52d0c416fd0bedbfd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Agendamentos_Index), @"mvc.1.0.view", @"/Views/Agendamentos/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Agendamentos/Index.cshtml", typeof(AspNetCore.Views_Agendamentos_Index))]
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
#line 1 "C:\Users\thigg\source\repos\ProjProfi\AgendamentoProjeto\Views\_ViewImports.cshtml"
using AgendamentoProjeto;

#line default
#line hidden
#line 2 "C:\Users\thigg\source\repos\ProjProfi\AgendamentoProjeto\Views\_ViewImports.cshtml"
using AgendamentoProjeto.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"de1315b1d052c0e10f0449a52d0c416fd0bedbfd", @"/Views/Agendamentos/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"641cfe44d48d57df3d54e8628572e65cafa6db78", @"/Views/_ViewImports.cshtml")]
    public class Views_Agendamentos_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<AgendamentoProjeto.Models.Agendamento>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-white btn btn-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn ml-4 btn-sm btn-warning  font-weight-bold"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Avisos", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn ml-4 btn-sm btn-success font-weight-bold"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(59, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\thigg\source\repos\ProjProfi\AgendamentoProjeto\Views\Agendamentos\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(102, 156, true);
            WriteLiteral("\r\n<h1 style=\"text-align:center;font-weight:bold;font-size:30px;\" class=\"mt-3 text-primary\">Agendamentos</h1>\r\n\r\n<br />\r\n<br />\r\n\r\n<div class=\"d-flex\">\r\n    ");
            EndContext();
            BeginContext(258, 454, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "de1315b1d052c0e10f0449a52d0c416fd0bedbfd6655", async() => {
                BeginContext(297, 408, true);
                WriteLiteral(@"
        <div class=""input-group"">
            <input class=""form-control py-2"" type=""date"" name=""Procurar"" placeholder=""Pesquisar por Data..."" id=""example-search-input"">
            <span class=""input-group-append"">
                <button class=""btn btn-outline-info"" type=""submit"">
                    <i class=""fa fa-search""></i>
                </button>
            </span>
        </div>
    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(712, 36, true);
            WriteLiteral("\r\n\r\n    <div class=\"ml-2\">\r\n        ");
            EndContext();
            BeginContext(748, 96, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "de1315b1d052c0e10f0449a52d0c416fd0bedbfd8968", async() => {
                BeginContext(806, 34, true);
                WriteLiteral(" <i class=\"fa fa-plus fa-1x\"></i> ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(844, 48, true);
            WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n<div class=\"row mt-5\">\r\n");
            EndContext();
#line 30 "C:\Users\thigg\source\repos\ProjProfi\AgendamentoProjeto\Views\Agendamentos\Index.cshtml"
     foreach (var nomeC in Model)
    {

#line default
#line hidden
            BeginContext(934, 374, true);
            WriteLiteral(@"        <div class=""col-sm-4 mt-3 "">
            <div class=""card bg-light"">
                <div class=""card-body border rounded border-primary"">
                    <div class=""d-flex"">
                        <p class=""font-weight-bold"" style=""font-size:14px;"">Data: </p>
                        <p class=""text-primary font-weight-bold ml-2"" style=""font-size:14px;"">");
            EndContext();
            BeginContext(1309, 41, false);
#line 37 "C:\Users\thigg\source\repos\ProjProfi\AgendamentoProjeto\Views\Agendamentos\Index.cshtml"
                                                                                         Write(nomeC.DataAgendamento.ToShortDateString());

#line default
#line hidden
            EndContext();
            BeginContext(1350, 265, true);
            WriteLiteral(@"</p>
                    </div>
                    <div class=""d-flex"">
                        <p class=""font-weight-bold"" style=""font-size:14px;"">Laboratório: </p>
                        <p class=""text-primary font-weight-bold ml-2"" style=""font-size:14px;"">");
            EndContext();
            BeginContext(1616, 33, false);
#line 41 "C:\Users\thigg\source\repos\ProjProfi\AgendamentoProjeto\Views\Agendamentos\Index.cshtml"
                                                                                         Write(nomeC.Laboratorio.NomeLaboratorio);

#line default
#line hidden
            EndContext();
            BeginContext(1649, 263, true);
            WriteLiteral(@"</p>
                    </div>
                    <div class=""d-flex"">
                        <p class=""font-weight-bold"" style=""font-size:14px;"">Professor: </p>
                        <p class=""text-primary font-weight-bold ml-2"" style=""font-size:14px;"">");
            EndContext();
            BeginContext(1913, 29, false);
#line 45 "C:\Users\thigg\source\repos\ProjProfi\AgendamentoProjeto\Views\Agendamentos\Index.cshtml"
                                                                                         Write(nomeC.Professor.NomeProfessor);

#line default
#line hidden
            EndContext();
            BeginContext(1942, 264, true);
            WriteLiteral(@"</p>
                    </div>
                    <div class=""d-flex"">
                        <p class=""font-weight-bold"" style=""font-size:14px;"">Disciplina: </p>
                        <p class=""text-primary font-weight-bold ml-2"" style=""font-size:14px;"">");
            EndContext();
            BeginContext(2207, 31, false);
#line 49 "C:\Users\thigg\source\repos\ProjProfi\AgendamentoProjeto\Views\Agendamentos\Index.cshtml"
                                                                                         Write(nomeC.Disciplina.NomeDisciplina);

#line default
#line hidden
            EndContext();
            BeginContext(2238, 34, true);
            WriteLiteral("</p>\r\n                    </div>\r\n");
            EndContext();
#line 51 "C:\Users\thigg\source\repos\ProjProfi\AgendamentoProjeto\Views\Agendamentos\Index.cshtml"
                     if (nomeC.Avisos != null)
                    {

#line default
#line hidden
            BeginContext(2343, 237, true);
            WriteLiteral("                        <div class=\"d-flex\">\r\n                            <p class=\"font-weight-bold\" style=\"font-size:14px;\">Aviso: </p>\r\n                            <p class=\"text-primary font-weight-bold ml-2\" style=\"font-size:14px;\">");
            EndContext();
            BeginContext(2581, 12, false);
#line 55 "C:\Users\thigg\source\repos\ProjProfi\AgendamentoProjeto\Views\Agendamentos\Index.cshtml"
                                                                                             Write(nomeC.Avisos);

#line default
#line hidden
            EndContext();
            BeginContext(2593, 38, true);
            WriteLiteral("</p>\r\n                        </div>\r\n");
            EndContext();
#line 57 "C:\Users\thigg\source\repos\ProjProfi\AgendamentoProjeto\Views\Agendamentos\Index.cshtml"
                    }

#line default
#line hidden
            BeginContext(2654, 67, true);
            WriteLiteral("                    <div class=\"d-flex \">\r\n                        ");
            EndContext();
            BeginContext(2721, 121, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "de1315b1d052c0e10f0449a52d0c416fd0bedbfd15132", async() => {
                BeginContext(2832, 6, true);
                WriteLiteral("Editar");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 59 "C:\Users\thigg\source\repos\ProjProfi\AgendamentoProjeto\Views\Agendamentos\Index.cshtml"
                                               WriteLiteral(nomeC.AgendamentoId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2842, 100, true);
            WriteLiteral("\r\n                        <a class=\"btn btn-sm btn-danger ml-4 text-white font-weight-bold\" href=\"#\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 2942, "\"", 2985, 3);
            WriteAttributeValue("", 2952, "ExibirModal(", 2952, 12, true);
#line 60 "C:\Users\thigg\source\repos\ProjProfi\AgendamentoProjeto\Views\Agendamentos\Index.cshtml"
WriteAttributeValue("", 2964, nomeC.AgendamentoId, 2964, 20, false);

#line default
#line hidden
            WriteAttributeValue("", 2984, ")", 2984, 1, true);
            EndWriteAttribute();
            BeginContext(2986, 38, true);
            WriteLiteral(">Excluir</a>\r\n                        ");
            EndContext();
            BeginContext(3024, 153, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "de1315b1d052c0e10f0449a52d0c416fd0bedbfd18276", async() => {
                BeginContext(3161, 12, true);
                WriteLiteral("Anexar aviso");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 61 "C:\Users\thigg\source\repos\ProjProfi\AgendamentoProjeto\Views\Agendamentos\Index.cshtml"
                                                 WriteLiteral(nomeC.AgendamentoId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3177, 92, true);
            WriteLiteral("\r\n                    </div>\r\n\r\n                </div>\r\n            </div>\r\n        </div>\r\n");
            EndContext();
#line 67 "C:\Users\thigg\source\repos\ProjProfi\AgendamentoProjeto\Views\Agendamentos\Index.cshtml"
    }

#line default
#line hidden
            BeginContext(3276, 873, true);
            WriteLiteral(@"</div>

<div class=""modal"" tabindex=""-1"" role=""dialog"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"">Excluir</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
                <p>Deseja prosseguir com a exclusão desse agendamento?</p>
            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-outline-primary btnExcluir"">Sim</button>
                <button type=""button"" class=""btn btn-outline-danger"" data-dismiss=""modal"">Não</button>
            </div>
        </div>
    </div>
</div>


");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(4166, 535, true);
                WriteLiteral(@"


    <script>
        function ExibirModal(id) {
            $("".modal"").modal();
            $("".btnExcluir"").on('click', function () {
                $.ajax({
                    url: ""/Agendamentos/Delete"",
                    method: ""POST"",
                    data: { id: id },
                    success: function (data) {
                        $("".modal"").modal('hide');
                        location.reload(true);
                    }
                });
            });
        }
    </script>

");
                EndContext();
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<AgendamentoProjeto.Models.Agendamento>> Html { get; private set; }
    }
}
#pragma warning restore 1591
