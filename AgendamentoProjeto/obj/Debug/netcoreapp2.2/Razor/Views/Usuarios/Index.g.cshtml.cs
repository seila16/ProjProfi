#pragma checksum "C:\Users\J130075\Desktop\TesteDoGit\ProjProfi\AgendamentoProjeto\Views\Usuarios\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f27c35c83693f4d5ff6f9b0cce266d0209ce2439"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Usuarios_Index), @"mvc.1.0.view", @"/Views/Usuarios/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Usuarios/Index.cshtml", typeof(AspNetCore.Views_Usuarios_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f27c35c83693f4d5ff6f9b0cce266d0209ce2439", @"/Views/Usuarios/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"641cfe44d48d57df3d54e8628572e65cafa6db78", @"/Views/_ViewImports.cshtml")]
    public class Views_Usuarios_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<AgendamentoProjeto.Models.Usuario>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("height:10px;width:10px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/search.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Users", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("d-flex w-75"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("font-size:15px;background-color:dodgerblue"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn text-white"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("background-color:dodgerblue;margin-left:2px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn  text-white"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(55, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\J130075\Desktop\TesteDoGit\ProjProfi\AgendamentoProjeto\Views\Usuarios\Index.cshtml"
  

    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(100, 251, true);
            WriteLiteral("<h1 style=\"text-align:center;font-weight:bold;font-size:30px;color:gray\">Usuários</h1>\r\n<br />\r\n<br />\r\n\r\n<ul class=\"navbar-nav  flex-row mt-4\">\r\n\r\n\r\n    <li class=\"nav-item\">\r\n\r\n        <div style=\"width:400px\" class=\"input-group mb-3\">\r\n            ");
            EndContext();
            BeginContext(351, 480, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f27c35c83693f4d5ff6f9b0cce266d0209ce24398320", async() => {
                BeginContext(433, 144, true);
                WriteLiteral("\r\n                <div class=\"input-group-prepend\">\r\n                    <button class=\"btn btn-outline-secondary\" type=\"submit\" method=\"post\"> ");
                EndContext();
                BeginContext(577, 57, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "f27c35c83693f4d5ff6f9b0cce266d0209ce24398855", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(634, 190, true);
                WriteLiteral(" </button>\r\n                </div>\r\n                <input type=\"text\" class=\"form-control\" name=\"Procurar\" placeholder=\"Pesquisar por Nome...\" aria-describedby=\"basic-addon1\">\r\n            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(831, 94, true);
            WriteLiteral("\r\n        </div>\r\n    </li>\r\n\r\n\r\n\r\n\r\n    <li>\r\n        <div class=\"text-center\">\r\n            ");
            EndContext();
            BeginContext(925, 112, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f27c35c83693f4d5ff6f9b0cce266d0209ce243912249", async() => {
                BeginContext(1022, 11, true);
                WriteLiteral(" Adicionar ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1037, 48, true);
            WriteLiteral("\r\n        </div>\r\n    </li>\r\n\r\n\r\n\r\n</ul>\r\n\r\n\r\n\r\n");
            EndContext();
#line 41 "C:\Users\J130075\Desktop\TesteDoGit\ProjProfi\AgendamentoProjeto\Views\Usuarios\Index.cshtml"
 if (ViewBag.NotDelete == true)
{

#line default
#line hidden
            BeginContext(1121, 156, true);
            WriteLiteral("    <div class=\"alert alert-danger mt-3\">\r\n        <p>Usuário está vinculado a um agendamento, por tanto não é possível excluir o usuário.</p>\r\n    </div>\r\n");
            EndContext();
#line 46 "C:\Users\J130075\Desktop\TesteDoGit\ProjProfi\AgendamentoProjeto\Views\Usuarios\Index.cshtml"
}

#line default
#line hidden
            BeginContext(1280, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 48 "C:\Users\J130075\Desktop\TesteDoGit\ProjProfi\AgendamentoProjeto\Views\Usuarios\Index.cshtml"
 if (ViewBag.Contagem != 0)
{

#line default
#line hidden
            BeginContext(1314, 163, true);
            WriteLiteral("    <h6 class=\"mt-2\">Usuários pendentens</h6>\r\n    <table class=\"table table-hover\">\r\n        <thead>\r\n            <tr>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(1478, 47, false);
#line 55 "C:\Users\J130075\Desktop\TesteDoGit\ProjProfi\AgendamentoProjeto\Views\Usuarios\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.NomeUsuario));

#line default
#line hidden
            EndContext();
            BeginContext(1525, 69, true);
            WriteLiteral("\r\n                </th>\r\n\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(1595, 41, false);
#line 59 "C:\Users\J130075\Desktop\TesteDoGit\ProjProfi\AgendamentoProjeto\Views\Usuarios\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
            EndContext();
            BeginContext(1636, 154, true);
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    Status\r\n                </th>\r\n            </tr>\r\n        </thead>\r\n\r\n        <tbody>\r\n");
            EndContext();
#line 68 "C:\Users\J130075\Desktop\TesteDoGit\ProjProfi\AgendamentoProjeto\Views\Usuarios\Index.cshtml"
             foreach (var usu in ViewBag.UsuariosPendentes)
            {
                

#line default
#line hidden
            BeginContext(1884, 84, true);
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(1969, 15, false);
#line 73 "C:\Users\J130075\Desktop\TesteDoGit\ProjProfi\AgendamentoProjeto\Views\Usuarios\Index.cshtml"
                       Write(usu.NomeUsuario);

#line default
#line hidden
            EndContext();
            BeginContext(1984, 93, true);
            WriteLiteral("\r\n                        </td>\r\n\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(2078, 9, false);
#line 77 "C:\Users\J130075\Desktop\TesteDoGit\ProjProfi\AgendamentoProjeto\Views\Usuarios\Index.cshtml"
                       Write(usu.Email);

#line default
#line hidden
            EndContext();
            BeginContext(2087, 252, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            Pendente\r\n                        </td>\r\n                        <td>\r\n                            <div class=\"d-flex w-100\">\r\n                                <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2339, "\"", 2408, 1);
#line 84 "C:\Users\J130075\Desktop\TesteDoGit\ProjProfi\AgendamentoProjeto\Views\Usuarios\Index.cshtml"
WriteAttributeValue("", 2346, Url.Action("TrocarStatus", "Usuarios", new { usu.UsuarioId }), 2346, 62, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2409, 106, true);
            WriteLiteral(" style=\"background-color:darkblue\" class=\"btn  text-white\">Aprovar</a>\r\n                                <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2515, "\"", 2576, 1);
#line 85 "C:\Users\J130075\Desktop\TesteDoGit\ProjProfi\AgendamentoProjeto\Views\Usuarios\Index.cshtml"
WriteAttributeValue("", 2522, Url.Action("Reprovar", "Usuarios", new { usu.Login }), 2522, 54, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2577, 256, true);
            WriteLiteral(@" style=""background-color:dodgerblue;margin-left:2px;"" class=""btn  text-white"">Reprovar</a>
                            </div>
                        </td>
                        <td></td>
                        <td></td>
                    </tr>
");
            EndContext();
#line 91 "C:\Users\J130075\Desktop\TesteDoGit\ProjProfi\AgendamentoProjeto\Views\Usuarios\Index.cshtml"
                    }

#line default
#line hidden
            BeginContext(2856, 36, true);
            WriteLiteral("            </tbody>\r\n    </table>\r\n");
            EndContext();
#line 94 "C:\Users\J130075\Desktop\TesteDoGit\ProjProfi\AgendamentoProjeto\Views\Usuarios\Index.cshtml"
}

#line default
#line hidden
            BeginContext(2895, 122, true);
            WriteLiteral("<h6 class=\"mt-4\">Usuário Ativos</h6>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(3018, 47, false);
#line 100 "C:\Users\J130075\Desktop\TesteDoGit\ProjProfi\AgendamentoProjeto\Views\Usuarios\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.NomeUsuario));

#line default
#line hidden
            EndContext();
            BeginContext(3065, 57, true);
            WriteLiteral("\r\n            </th>\r\n\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(3123, 41, false);
#line 104 "C:\Users\J130075\Desktop\TesteDoGit\ProjProfi\AgendamentoProjeto\Views\Usuarios\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
            EndContext();
            BeginContext(3164, 57, true);
            WriteLiteral("\r\n            </th>\r\n\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(3222, 41, false);
#line 108 "C:\Users\J130075\Desktop\TesteDoGit\ProjProfi\AgendamentoProjeto\Views\Usuarios\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Cargo));

#line default
#line hidden
            EndContext();
            BeginContext(3263, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(3319, 41, false);
#line 111 "C:\Users\J130075\Desktop\TesteDoGit\ProjProfi\AgendamentoProjeto\Views\Usuarios\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Curso));

#line default
#line hidden
            EndContext();
            BeginContext(3360, 86, true);
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 117 "C:\Users\J130075\Desktop\TesteDoGit\ProjProfi\AgendamentoProjeto\Views\Usuarios\Index.cshtml"
         foreach (var item in Model)
        {
            

#line default
#line hidden
#line 119 "C:\Users\J130075\Desktop\TesteDoGit\ProjProfi\AgendamentoProjeto\Views\Usuarios\Index.cshtml"
             if (item.StatusId == 1)
            {

#line default
#line hidden
            BeginContext(3548, 72, true);
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(3621, 46, false);
#line 123 "C:\Users\J130075\Desktop\TesteDoGit\ProjProfi\AgendamentoProjeto\Views\Usuarios\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.NomeUsuario));

#line default
#line hidden
            EndContext();
            BeginContext(3667, 81, true);
            WriteLiteral("\r\n                    </td>\r\n\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(3749, 40, false);
#line 127 "C:\Users\J130075\Desktop\TesteDoGit\ProjProfi\AgendamentoProjeto\Views\Usuarios\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Email));

#line default
#line hidden
            EndContext();
            BeginContext(3789, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(3869, 50, false);
#line 130 "C:\Users\J130075\Desktop\TesteDoGit\ProjProfi\AgendamentoProjeto\Views\Usuarios\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Cargo.NomeCargo));

#line default
#line hidden
            EndContext();
            BeginContext(3919, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(3999, 45, false);
#line 133 "C:\Users\J130075\Desktop\TesteDoGit\ProjProfi\AgendamentoProjeto\Views\Usuarios\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Curso.Nome));

#line default
#line hidden
            EndContext();
            BeginContext(4044, 146, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        <div class=\"d-flex w-100\">\r\n                            <a href=\"#\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 4190, "\"", 4228, 3);
            WriteAttributeValue("", 4200, "ExibirModal(", 4200, 12, true);
#line 137 "C:\Users\J130075\Desktop\TesteDoGit\ProjProfi\AgendamentoProjeto\Views\Usuarios\Index.cshtml"
WriteAttributeValue("", 4212, item.UsuarioId, 4212, 15, false);

#line default
#line hidden
            WriteAttributeValue("", 4227, ")", 4227, 1, true);
            EndWriteAttribute();
            BeginContext(4229, 100, true);
            WriteLiteral(" style=\"background-color:darkblue\" class=\"btn  text-white\">Excluir</a>\r\n                            ");
            EndContext();
            BeginContext(4329, 139, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f27c35c83693f4d5ff6f9b0cce266d0209ce243924408", async() => {
                BeginContext(4458, 6, true);
                WriteLiteral("Editar");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_9.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 138 "C:\Users\J130075\Desktop\TesteDoGit\ProjProfi\AgendamentoProjeto\Views\Usuarios\Index.cshtml"
                                                   WriteLiteral(item.UsuarioId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_11);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4468, 84, true);
            WriteLiteral("\r\n                        </div>\r\n                    </td>\r\n                </tr>\r\n");
            EndContext();
#line 142 "C:\Users\J130075\Desktop\TesteDoGit\ProjProfi\AgendamentoProjeto\Views\Usuarios\Index.cshtml"
            }

#line default
#line hidden
#line 142 "C:\Users\J130075\Desktop\TesteDoGit\ProjProfi\AgendamentoProjeto\Views\Usuarios\Index.cshtml"
             
        }

#line default
#line hidden
            BeginContext(4578, 885, true);
            WriteLiteral(@"    </tbody>
</table>

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
                <p>Deseja prosseguir com a exclusão desse usuário?</p>
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
                BeginContext(5480, 531, true);
                WriteLiteral(@"


    <script>
        function ExibirModal(id) {
            $("".modal"").modal();
            $("".btnExcluir"").on('click', function () {
                $.ajax({
                    url: ""/Usuarios/Delete"",
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<AgendamentoProjeto.Models.Usuario>> Html { get; private set; }
    }
}
#pragma warning restore 1591
