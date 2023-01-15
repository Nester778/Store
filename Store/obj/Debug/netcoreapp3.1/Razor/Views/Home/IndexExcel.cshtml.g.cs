#pragma checksum "C:\Users\anest\source\repos\Store\Store\Views\Home\IndexExcel.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a6575197f2cae1835c1b6e3c5f1f79b6dfab855c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_IndexExcel), @"mvc.1.0.view", @"/Views/Home/IndexExcel.cshtml")]
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
#line 1 "C:\Users\anest\source\repos\Store\Store\Views\_ViewImports.cshtml"
using Store;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\anest\source\repos\Store\Store\Views\Home\IndexExcel.cshtml"
using Store.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a6575197f2cae1835c1b6e3c5f1f79b6dfab855c", @"/Views/Home/IndexExcel.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6bf4e815b3c664a1a42b413716bf96a575e49a98", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_IndexExcel : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IndexViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\anest\source\repos\Store\Store\Views\Home\IndexExcel.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"nav-link text-dark\">\r\n    <span>Sum =</span>\r\n    <span class=\"screen\">0</span>\r\n</div>\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>");
#nullable restore
#line 15 "C:\Users\anest\source\repos\Store\Store\Views\Home\IndexExcel.cshtml"
           Write(Html.ActionLink("Id", "IndexExcel", new { sortOrder = ViewBag.IdSortParam, page = Model.PageViewModel.PageNumber }));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n            <th>");
#nullable restore
#line 16 "C:\Users\anest\source\repos\Store\Store\Views\Home\IndexExcel.cshtml"
           Write(Html.ActionLink("ProviderName", "IndexExcel", new { sortOrder = ViewBag.ProviderNameSortParm, page = Model.PageViewModel.PageNumber }));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n            <th>");
#nullable restore
#line 17 "C:\Users\anest\source\repos\Store\Store\Views\Home\IndexExcel.cshtml"
           Write(Html.ActionLink("Description", "IndexExcel", new { sortOrder = ViewBag.DescriptionSortParm, page = Model.PageViewModel.PageNumber }));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n            <th>");
#nullable restore
#line 18 "C:\Users\anest\source\repos\Store\Store\Views\Home\IndexExcel.cshtml"
           Write(Html.ActionLink("CreationData", "IndexExcel", new { sortOrder = ViewBag.CreationDataSortParm, page = Model.PageViewModel.PageNumber }));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n            <th>");
#nullable restore
#line 19 "C:\Users\anest\source\repos\Store\Store\Views\Home\IndexExcel.cshtml"
           Write(Html.ActionLink("ModificationData", "IndexExcel", new { sortOrder = ViewBag.ModificationDataSortParm, page = Model.PageViewModel.PageNumber }));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n            <th>");
#nullable restore
#line 20 "C:\Users\anest\source\repos\Store\Store\Views\Home\IndexExcel.cshtml"
           Write(Html.ActionLink("Manager", "IndexExcel", new { sortOrder = ViewBag.ManagerSortParm, page = Model.PageViewModel.PageNumber }));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n            <th>");
#nullable restore
#line 21 "C:\Users\anest\source\repos\Store\Store\Views\Home\IndexExcel.cshtml"
           Write(Html.ActionLink("Quantity", "IndexExcel", new { sortOrder = ViewBag.QuantitySortParm, page = Model.PageViewModel.PageNumber }));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n            <th>");
#nullable restore
#line 22 "C:\Users\anest\source\repos\Store\Store\Views\Home\IndexExcel.cshtml"
           Write(Html.ActionLink("Amount", "IndexExcel", new { sortOrder = ViewBag.AmountSortParm, page = Model.PageViewModel.PageNumber }));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n            <th>");
#nullable restore
#line 23 "C:\Users\anest\source\repos\Store\Store\Views\Home\IndexExcel.cshtml"
           Write(Html.ActionLink("City", "IndexExcel", new { sortOrder = ViewBag.CitySortParm, page = Model.PageViewModel.PageNumber }));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n\r\n        </tr>\r\n    </thead>\r\n");
#nullable restore
#line 27 "C:\Users\anest\source\repos\Store\Store\Views\Home\IndexExcel.cshtml"
     foreach (var item in Model.Products)
    {

        var color = "";
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 31 "C:\Users\anest\source\repos\Store\Store\Views\Home\IndexExcel.cshtml"
         if (item.CreationData != item.ModificationData)
        {
            color = "background-color: green";
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr");
            BeginWriteAttribute("style", " style=\"", 1856, "\"", 1870, 1);
#nullable restore
#line 36 "C:\Users\anest\source\repos\Store\Store\Views\Home\IndexExcel.cshtml"
WriteAttributeValue("", 1864, color, 1864, 6, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n            <td>");
#nullable restore
#line 37 "C:\Users\anest\source\repos\Store\Store\Views\Home\IndexExcel.cshtml"
           Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 38 "C:\Users\anest\source\repos\Store\Store\Views\Home\IndexExcel.cshtml"
           Write(item.ProviderName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 39 "C:\Users\anest\source\repos\Store\Store\Views\Home\IndexExcel.cshtml"
           Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 40 "C:\Users\anest\source\repos\Store\Store\Views\Home\IndexExcel.cshtml"
           Write(item.CreationData);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 41 "C:\Users\anest\source\repos\Store\Store\Views\Home\IndexExcel.cshtml"
           Write(item.ModificationData);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 42 "C:\Users\anest\source\repos\Store\Store\Views\Home\IndexExcel.cshtml"
           Write(item.Manager);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 43 "C:\Users\anest\source\repos\Store\Store\Views\Home\IndexExcel.cshtml"
           Write(item.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 44 "C:\Users\anest\source\repos\Store\Store\Views\Home\IndexExcel.cshtml"
           Write(item.Amount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 45 "C:\Users\anest\source\repos\Store\Store\Views\Home\IndexExcel.cshtml"
           Write(item.City);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td><input type=\"checkbox\" class=\"checkbox\"");
            BeginWriteAttribute("value", " value=\"", 2268, "\"", 2306, 1);
#nullable restore
#line 46 "C:\Users\anest\source\repos\Store\Store\Views\Home\IndexExcel.cshtml"
WriteAttributeValue("", 2276, item.Amount * item.Quantity, 2276, 30, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("id", " id=\"", 2307, "\"", 2320, 1);
#nullable restore
#line 46 "C:\Users\anest\source\repos\Store\Store\Views\Home\IndexExcel.cshtml"
WriteAttributeValue("", 2312, item.Id, 2312, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" /></td>\r\n        </tr>\r\n");
#nullable restore
#line 48 "C:\Users\anest\source\repos\Store\Store\Views\Home\IndexExcel.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>\r\n\r\n\r\n\r\n\r\n");
#nullable restore
#line 54 "C:\Users\anest\source\repos\Store\Store\Views\Home\IndexExcel.cshtml"
 if (Model.PageViewModel.HasPreviousPage)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <span class=\"btn btn-outline-dark\">\r\n        ");
#nullable restore
#line 57 "C:\Users\anest\source\repos\Store\Store\Views\Home\IndexExcel.cshtml"
   Write(Html.ActionLink("Назад", "IndexExcel", new { page = Model.PageViewModel.PageNumber - 1 }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </span>\r\n");
#nullable restore
#line 59 "C:\Users\anest\source\repos\Store\Store\Views\Home\IndexExcel.cshtml"
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 60 "C:\Users\anest\source\repos\Store\Store\Views\Home\IndexExcel.cshtml"
 if (Model.PageViewModel.HasNextPage)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <span class=\"btn btn-outline-dark\">\r\n        ");
#nullable restore
#line 63 "C:\Users\anest\source\repos\Store\Store\Views\Home\IndexExcel.cshtml"
   Write(Html.ActionLink("Вперед", "IndexExcel", new { page = Model.PageViewModel.PageNumber + 1 }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </span>\r\n");
#nullable restore
#line 65 "C:\Users\anest\source\repos\Store\Store\Views\Home\IndexExcel.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IndexViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
