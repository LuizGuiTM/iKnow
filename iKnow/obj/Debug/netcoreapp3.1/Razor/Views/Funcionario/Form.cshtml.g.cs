#pragma checksum "C:\Users\Lorenzo Messias\Documents\0iKnow\iKnow\iKnow\Views\Funcionario\Form.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0550e95f0b6d60572b2469373814dfa2c8fb3c75"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Funcionario_Form), @"mvc.1.0.view", @"/Views/Funcionario/Form.cshtml")]
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
#line 1 "C:\Users\Lorenzo Messias\Documents\0iKnow\iKnow\iKnow\Views\_ViewImports.cshtml"
using iKnow;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Lorenzo Messias\Documents\0iKnow\iKnow\iKnow\Views\_ViewImports.cshtml"
using iKnow.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0550e95f0b6d60572b2469373814dfa2c8fb3c75", @"/Views/Funcionario/Form.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a8f8e0ca8df97f86c68e9d4b47ce6461adca4047", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Funcionario_Form : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FuncionarioViewModel>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("SaveFunc"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("cadastrocampo"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("cadastro "), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Lorenzo Messias\Documents\0iKnow\iKnow\iKnow\Views\Funcionario\Form.cshtml"
  
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<header>\r\n    <link");
            BeginWriteAttribute("href", " href=\"", 104, "\"", 141, 1);
#nullable restore
#line 7 "C:\Users\Lorenzo Messias\Documents\0iKnow\iKnow\iKnow\Views\Funcionario\Form.cshtml"
WriteAttributeValue("", 111, Url.Content("~/css/home.css"), 111, 30, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" rel=\"stylesheet\" type=\"text/css\" />\r\n</header>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0550e95f0b6d60572b2469373814dfa2c8fb3c756319", async() => {
                WriteLiteral("\r\n    <div class=\"container\">\r\n    <br />\r\n");
                WriteLiteral("        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0550e95f0b6d60572b2469373814dfa2c8fb3c756667", async() => {
                    WriteLiteral("\r\n        <h2 class=\"titulocadastro\">Cadastro de Funcionário</h2>\r\n        <input type=\"hidden\" name=\"Operacao\"");
                    BeginWriteAttribute("value", " value=\"", 604, "\"", 629, 1);
#nullable restore
#line 16 "C:\Users\Lorenzo Messias\Documents\0iKnow\iKnow\iKnow\Views\Funcionario\Form.cshtml"
WriteAttributeValue("", 612, ViewBag.Operacao, 612, 17, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(" />\r\n        <input type=\"hidden\" name=\"FuncionarioRH\"");
                    BeginWriteAttribute("value", " value=\"", 684, "\"", 714, 1);
#nullable restore
#line 17 "C:\Users\Lorenzo Messias\Documents\0iKnow\iKnow\iKnow\Views\Funcionario\Form.cshtml"
WriteAttributeValue("", 692, ViewBag.FuncionarioRH, 692, 22, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(" />\r\n");
                    WriteLiteral("        <input type=\"hidden\" Name=\"Id\"");
                    BeginWriteAttribute("value", " value=\"", 838, "\"", 855, 1);
#nullable restore
#line 19 "C:\Users\Lorenzo Messias\Documents\0iKnow\iKnow\iKnow\Views\Funcionario\Form.cshtml"
WriteAttributeValue("", 846, Model.Id, 846, 9, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(" class=\"form-control\" />\r\n\r\n");
#nullable restore
#line 21 "C:\Users\Lorenzo Messias\Documents\0iKnow\iKnow\iKnow\Views\Funcionario\Form.cshtml"
         if (!@ViewBag.FuncionarioRH == true)
        {

#line default
#line hidden
#nullable disable
                    WriteLiteral("            <div class=\"row\">\r\n                <div class=\"col-md-6\">\r\n                    <div class=\"form-group\">\r\n                        <label for=\"Cpf\" class=\"control-label\">CPF</label>\r\n                        <input type=\"text\" name=\"Cpf\"");
                    BeginWriteAttribute("value", " value=\"", 1188, "\"", 1206, 1);
#nullable restore
#line 27 "C:\Users\Lorenzo Messias\Documents\0iKnow\iKnow\iKnow\Views\Funcionario\Form.cshtml"
WriteAttributeValue("", 1196, Model.Cpf, 1196, 10, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(" class=\"form-control\" />\r\n                        ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("span", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0550e95f0b6d60572b2469373814dfa2c8fb3c759385", async() => {
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper);
#nullable restore
#line 28 "C:\Users\Lorenzo Messias\Documents\0iKnow\iKnow\iKnow\Views\Funcionario\Form.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Cpf);

#line default
#line hidden
#nullable disable
                    __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-for", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n                    </div>\r\n                    <div class=\"form-group\">\r\n                        <label for=\"Senha\" class=\"control-label\">Senha</label>\r\n                        <input type=\"password\" name=\"Senha\"");
                    BeginWriteAttribute("value", " value=\"", 1530, "\"", 1550, 1);
#nullable restore
#line 32 "C:\Users\Lorenzo Messias\Documents\0iKnow\iKnow\iKnow\Views\Funcionario\Form.cshtml"
WriteAttributeValue("", 1538, Model.Senha, 1538, 12, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(" class=\"form-control\" />\r\n                        ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("span", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0550e95f0b6d60572b2469373814dfa2c8fb3c7511770", async() => {
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper);
#nullable restore
#line 33 "C:\Users\Lorenzo Messias\Documents\0iKnow\iKnow\iKnow\Views\Funcionario\Form.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Senha);

#line default
#line hidden
#nullable disable
                    __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-for", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
                    WriteLiteral("            <br />\r\n                <input type=\"submit\" value=\"Salvar\" class=\"botaologin\" style=\"background-color:#ec673a\" >\r\n            <br />\r\n");
#nullable restore
#line 41 "C:\Users\Lorenzo Messias\Documents\0iKnow\iKnow\iKnow\Views\Funcionario\Form.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
                    WriteLiteral("            <div class=\"row\">\r\n                <div class=\"col-md-6\">\r\n");
#nullable restore
#line 46 "C:\Users\Lorenzo Messias\Documents\0iKnow\iKnow\iKnow\Views\Funcionario\Form.cshtml"
                     if (ViewBag.Operacao == "I")
                    {

#line default
#line hidden
#nullable disable
                    WriteLiteral("                        <div class=\"form-group\">\r\n                            <label for=\"Cpf\" class=\"control-label\">CPF</label>\r\n                            <input type=\"text\" Name=\"Cpf\"");
                    BeginWriteAttribute("value", " value=\"", 2252, "\"", 2270, 1);
#nullable restore
#line 50 "C:\Users\Lorenzo Messias\Documents\0iKnow\iKnow\iKnow\Views\Funcionario\Form.cshtml"
WriteAttributeValue("", 2260, Model.Cpf, 2260, 10, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(" class=\"form-control\" />\r\n                        </div>\r\n");
#nullable restore
#line 52 "C:\Users\Lorenzo Messias\Documents\0iKnow\iKnow\iKnow\Views\Funcionario\Form.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
                    WriteLiteral("                        <div class=\"form-group\">\r\n                            <label for=\"Cpf\" class=\"control-label\">CPF</label>\r\n                            <input type=\"text\" Name=\"Cpf\"");
                    BeginWriteAttribute("value", " value=\"", 2588, "\"", 2606, 1);
#nullable restore
#line 57 "C:\Users\Lorenzo Messias\Documents\0iKnow\iKnow\iKnow\Views\Funcionario\Form.cshtml"
WriteAttributeValue("", 2596, Model.Cpf, 2596, 10, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(" class=\"form-control disabled\" readonly />\r\n                        </div>\r\n");
#nullable restore
#line 59 "C:\Users\Lorenzo Messias\Documents\0iKnow\iKnow\iKnow\Views\Funcionario\Form.cshtml"
                    }

#line default
#line hidden
#nullable disable
                    WriteLiteral("                    ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("span", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0550e95f0b6d60572b2469373814dfa2c8fb3c7516210", async() => {
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper);
#nullable restore
#line 60 "C:\Users\Lorenzo Messias\Documents\0iKnow\iKnow\iKnow\Views\Funcionario\Form.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Cpf);

#line default
#line hidden
#nullable disable
                    __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-for", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n\r\n                    <div class=\"form-group\">\r\n                        <label for=\"Nome\" class=\"control-label\">Nome</label>\r\n                        <input type=\"text\" Name=\"Nome\"");
                    BeginWriteAttribute("value", " value=\"", 2966, "\"", 2985, 1);
#nullable restore
#line 64 "C:\Users\Lorenzo Messias\Documents\0iKnow\iKnow\iKnow\Views\Funcionario\Form.cshtml"
WriteAttributeValue("", 2974, Model.Nome, 2974, 11, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(" class=\"form-control\" />\r\n                        ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("span", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0550e95f0b6d60572b2469373814dfa2c8fb3c7518562", async() => {
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper);
#nullable restore
#line 65 "C:\Users\Lorenzo Messias\Documents\0iKnow\iKnow\iKnow\Views\Funcionario\Form.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Nome);

#line default
#line hidden
#nullable disable
                    __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-for", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n                    </div>\r\n                    <div class=\"form-group\">\r\n                        <label for=\"Salario\" class=\"control-label\">Salário</label>\r\n                        <input type=\"number\" Name=\"Salario\"");
                    BeginWriteAttribute("value", " value=\"", 3314, "\"", 3336, 1);
#nullable restore
#line 69 "C:\Users\Lorenzo Messias\Documents\0iKnow\iKnow\iKnow\Views\Funcionario\Form.cshtml"
WriteAttributeValue("", 3322, Model.Salario, 3322, 14, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(" class=\"form-control\" />\r\n                        ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("span", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0550e95f0b6d60572b2469373814dfa2c8fb3c7520955", async() => {
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper);
#nullable restore
#line 70 "C:\Users\Lorenzo Messias\Documents\0iKnow\iKnow\iKnow\Views\Funcionario\Form.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Salario);

#line default
#line hidden
#nullable disable
                    __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-for", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n                    </div>\r\n                    <div class=\"form-group\">\r\n                        <label for=\"Cargo\" class=\"control-label\">Cargo</label>\r\n                        <input type=\"text\" Name=\"Cargo\"");
                    BeginWriteAttribute("value", " value=\"", 3660, "\"", 3680, 1);
#nullable restore
#line 74 "C:\Users\Lorenzo Messias\Documents\0iKnow\iKnow\iKnow\Views\Funcionario\Form.cshtml"
WriteAttributeValue("", 3668, Model.Cargo, 3668, 12, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(" class=\"form-control\" />\r\n                        ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("span", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0550e95f0b6d60572b2469373814dfa2c8fb3c7523341", async() => {
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper);
#nullable restore
#line 75 "C:\Users\Lorenzo Messias\Documents\0iKnow\iKnow\iKnow\Views\Funcionario\Form.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Cargo);

#line default
#line hidden
#nullable disable
                    __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-for", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral(@"
                    </div>
                </div>

                <div class=""col-md-6"">
                    <div class=""form-group"">
                        <label for=""DataNasc"" class=""control-label"">Data de Nascimento</label>
                            <input type=""date"" Name=""DataNasc""");
                    BeginWriteAttribute("value", " value=\"", 4091, "\"", 4143, 1);
#nullable restore
#line 82 "C:\Users\Lorenzo Messias\Documents\0iKnow\iKnow\iKnow\Views\Funcionario\Form.cshtml"
WriteAttributeValue("", 4099, Model.DataNasc.Value.ToString("yyyy-MM-dd"), 4099, 44, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(" class=\"form-control\" />\r\n                        ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("span", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0550e95f0b6d60572b2469373814dfa2c8fb3c7525841", async() => {
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper);
#nullable restore
#line 83 "C:\Users\Lorenzo Messias\Documents\0iKnow\iKnow\iKnow\Views\Funcionario\Form.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.DataNasc);

#line default
#line hidden
#nullable disable
                    __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-for", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n                    </div>\r\n                    <div class=\"form-group\">\r\n                        <label for=\"Cidade\" class=\"control-label\">Cidade</label>\r\n                        <input type=\"text\" Name=\"Cidade\"");
                    BeginWriteAttribute("value", " value=\"", 4471, "\"", 4492, 1);
#nullable restore
#line 87 "C:\Users\Lorenzo Messias\Documents\0iKnow\iKnow\iKnow\Views\Funcionario\Form.cshtml"
WriteAttributeValue("", 4479, Model.Cidade, 4479, 13, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(" class=\"form-control\" />\r\n                        ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("span", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0550e95f0b6d60572b2469373814dfa2c8fb3c7528232", async() => {
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper);
#nullable restore
#line 88 "C:\Users\Lorenzo Messias\Documents\0iKnow\iKnow\iKnow\Views\Funcionario\Form.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Cidade);

#line default
#line hidden
#nullable disable
                    __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-for", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n                    </div>\r\n                    <div class=\"form-group\">\r\n                        <label for=\"Estado\" class=\"control-label\">Estado</label>\r\n                        <input type=\"text\" Name=\"Estado\"");
                    BeginWriteAttribute("value", " value=\"", 4818, "\"", 4839, 1);
#nullable restore
#line 92 "C:\Users\Lorenzo Messias\Documents\0iKnow\iKnow\iKnow\Views\Funcionario\Form.cshtml"
WriteAttributeValue("", 4826, Model.Estado, 4826, 13, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(" class=\"form-control\" />\r\n                        ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("span", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0550e95f0b6d60572b2469373814dfa2c8fb3c7530621", async() => {
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper);
#nullable restore
#line 93 "C:\Users\Lorenzo Messias\Documents\0iKnow\iKnow\iKnow\Views\Funcionario\Form.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Estado);

#line default
#line hidden
#nullable disable
                    __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-for", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n                    </div>\r\n");
#nullable restore
#line 95 "C:\Users\Lorenzo Messias\Documents\0iKnow\iKnow\iKnow\Views\Funcionario\Form.cshtml"
                     if (ViewBag.Operacao == "I")
                    {

#line default
#line hidden
#nullable disable
                    WriteLiteral("                        <div class=\"form-group\">\r\n                            <label for=\"Senha\" class=\"control-label\">Senha</label>\r\n                            <input type=\"password\" Name=\"Senha\"");
                    BeginWriteAttribute("value", " value=\"", 5252, "\"", 5272, 1);
#nullable restore
#line 99 "C:\Users\Lorenzo Messias\Documents\0iKnow\iKnow\iKnow\Views\Funcionario\Form.cshtml"
WriteAttributeValue("", 5260, Model.Senha, 5260, 12, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(" class=\"form-control\" />\r\n                        </div>\r\n");
#nullable restore
#line 101 "C:\Users\Lorenzo Messias\Documents\0iKnow\iKnow\iKnow\Views\Funcionario\Form.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
                    WriteLiteral("                        <div class=\"form-group\">\r\n                            <label for=\"Senha\" class=\"control-label\">Senha</label>\r\n                            <input type=\"password\" Name=\"Senha\"");
                    BeginWriteAttribute("value", " value=\"", 5600, "\"", 5620, 1);
#nullable restore
#line 106 "C:\Users\Lorenzo Messias\Documents\0iKnow\iKnow\iKnow\Views\Funcionario\Form.cshtml"
WriteAttributeValue("", 5608, Model.Senha, 5608, 12, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(" class=\"form-control disabled\" readonly />\r\n                        </div>\r\n");
#nullable restore
#line 108 "C:\Users\Lorenzo Messias\Documents\0iKnow\iKnow\iKnow\Views\Funcionario\Form.cshtml"
                    }

#line default
#line hidden
#nullable disable
                    WriteLiteral("                    ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("span", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0550e95f0b6d60572b2469373814dfa2c8fb3c7534522", async() => {
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper);
#nullable restore
#line 109 "C:\Users\Lorenzo Messias\Documents\0iKnow\iKnow\iKnow\Views\Funcionario\Form.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Senha);

#line default
#line hidden
#nullable disable
                    __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-for", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n                </div>\r\n            </div>\r\n                <input type=\"submit\" value=\"Salvar\" class=\"botaologin\" style=\"background-color:#ec673a\">\r\n            <br />\r\n");
#nullable restore
#line 114 "C:\Users\Lorenzo Messias\Documents\0iKnow\iKnow\iKnow\Views\Funcionario\Form.cshtml"
        }

#line default
#line hidden
#nullable disable
                    WriteLiteral("    ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    </div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FuncionarioViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
