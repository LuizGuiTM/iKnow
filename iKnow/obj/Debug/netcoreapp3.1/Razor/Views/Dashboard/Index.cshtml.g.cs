#pragma checksum "C:\Users\Lorenzo Messias\Documents\iKnow\iKnow\iKnow\Views\Dashboard\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5424e5b307f25432ff2dbff184d21a13d0c1eeeb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Dashboard_Index), @"mvc.1.0.view", @"/Views/Dashboard/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5424e5b307f25432ff2dbff184d21a13d0c1eeeb", @"/Views/Dashboard/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a8f8e0ca8df97f86c68e9d4b47ce6461adca4047", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Dashboard_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Lorenzo Messias\Documents\iKnow\iKnow\iKnow\Views\Dashboard\Index.cshtml"
  
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<header>\r\n    <link");
            BeginWriteAttribute("href", " href=\"", 75, "\"", 112, 1);
#nullable restore
#line 6 "C:\Users\Lorenzo Messias\Documents\iKnow\iKnow\iKnow\Views\Dashboard\Index.cshtml"
WriteAttributeValue("", 82, Url.Content("~/css/home.css"), 82, 30, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" rel=""stylesheet"" type=""text/css"" />
</header>

<br />

<input id=""Graph"" class=""btn btn-primary"" value=""Exibir Dashboard"" type=""button"" onclick=""ColetaDadosDashboard()"" />

<br />
<br />

<div class=""graficos-container"">

    <div class=""grafico"">
        <canvas id=""PieGraph"" class=""TamanhoGraficos""></canvas>
    </div>

    <div class=""grafico"">
        <canvas id=""DonutGraph"" class=""TamanhoGraficos""></canvas>
    </div>

    <div class=""grafico grafico-centralizado"">
        <canvas id=""BarGraph"" class=""TamanhoGraficos"" style=""max-height: 280px;""></canvas>
    </div>

</div>

<script src=""https://cdn.jsdelivr.net/npm/chart.js""></script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
