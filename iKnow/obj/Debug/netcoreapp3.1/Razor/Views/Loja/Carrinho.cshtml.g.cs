#pragma checksum "C:\Users\Lorenzo Messias\Documents\iKnow\iKnow\iKnow\Views\Loja\Carrinho.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "402d352d2dc751b0b2f03aa98b422580c8e47a1a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Loja_Carrinho), @"mvc.1.0.view", @"/Views/Loja/Carrinho.cshtml")]
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
#line 1 "C:\Users\Lorenzo Messias\Documents\iKnow\iKnow\iKnow\Views\_ViewImports.cshtml"
using iKnow;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Lorenzo Messias\Documents\iKnow\iKnow\iKnow\Views\_ViewImports.cshtml"
using iKnow.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"402d352d2dc751b0b2f03aa98b422580c8e47a1a", @"/Views/Loja/Carrinho.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a8f8e0ca8df97f86c68e9d4b47ce6461adca4047", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Loja_Carrinho : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<CarrinhoViewModel>>
    #nullable disable
    {
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "402d352d2dc751b0b2f03aa98b422580c8e47a1a3240", async() => {
                WriteLiteral("\r\n");
                WriteLiteral("    <table class=\"listadocarrinho table-responsive\">\r\n        <input type=\"hidden\" id=\"operacao\"");
                BeginWriteAttribute("value", " value=\"", 208, "\"", 233, 1);
#nullable restore
#line 5 "C:\Users\Lorenzo Messias\Documents\iKnow\iKnow\iKnow\Views\Loja\Carrinho.cshtml"
WriteAttributeValue("", 216, ViewBag.Operacao, 216, 17, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n        <thead>\r\n        <tr>\r\n            <th>Prévia</th>\r\n            <th>Nome</th>\r\n            <th>Gênero</th>\r\n            <th>Valor</th>\r\n            <th>Quantidade</th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 16 "C:\Users\Lorenzo Messias\Documents\iKnow\iKnow\iKnow\Views\Loja\Carrinho.cshtml"
          foreach (var p in Model)
        {

#line default
#line hidden
#nullable disable
                WriteLiteral("            <tr>\r\n                <td>\r\n                    <img");
                BeginWriteAttribute("src", " src=\"", 581, "\"", 627, 2);
                WriteAttributeValue("", 587, "data:image/jpeg;base64,", 587, 23, true);
#nullable restore
#line 20 "C:\Users\Lorenzo Messias\Documents\iKnow\iKnow\iKnow\Views\Loja\Carrinho.cshtml"
WriteAttributeValue("", 610, p.ImagemEmBase64, 610, 17, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" style=\"width: 90px; height: auto; object-fit:contain\">\r\n                </td>\r\n                <td>");
#nullable restore
#line 22 "C:\Users\Lorenzo Messias\Documents\iKnow\iKnow\iKnow\Views\Loja\Carrinho.cshtml"
               Write(p.Nome);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 23 "C:\Users\Lorenzo Messias\Documents\iKnow\iKnow\iKnow\Views\Loja\Carrinho.cshtml"
               Write(p.Categoria);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 24 "C:\Users\Lorenzo Messias\Documents\iKnow\iKnow\iKnow\Views\Loja\Carrinho.cshtml"
               Write(p.Preco.ToString("0.00"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 25 "C:\Users\Lorenzo Messias\Documents\iKnow\iKnow\iKnow\Views\Loja\Carrinho.cshtml"
               Write(p.QtdProduto);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 27 "C:\Users\Lorenzo Messias\Documents\iKnow\iKnow\iKnow\Views\Loja\Carrinho.cshtml"
        }

#line default
#line hidden
#nullable disable
                WriteLiteral("        </tbody>\r\n    </table>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 32 "C:\Users\Lorenzo Messias\Documents\iKnow\iKnow\iKnow\Views\Loja\Carrinho.cshtml"
 if (ViewBag.Erro != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p style=\"color:red\">");
#nullable restore
#line 34 "C:\Users\Lorenzo Messias\Documents\iKnow\iKnow\iKnow\Views\Loja\Carrinho.cshtml"
                    Write(ViewBag.Erro);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 35 "C:\Users\Lorenzo Messias\Documents\iKnow\iKnow\iKnow\Views\Loja\Carrinho.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<CarrinhoViewModel>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
