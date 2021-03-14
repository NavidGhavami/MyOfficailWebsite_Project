#pragma checksum "E:\Programming\Codes and projects\MyOfficialEshopWebsite\MyOfficialEshopWebsite\ServiceHost\Areas\Administration\Pages\Inventory\OperationLog.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3f4f6f049b3e8b9b391bd9fe739adf307dccf5b0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ServiceHost.Areas.Administration.Pages.Inventory.Areas_Administration_Pages_Inventory_OperationLog), @"mvc.1.0.view", @"/Areas/Administration/Pages/Inventory/OperationLog.cshtml")]
namespace ServiceHost.Areas.Administration.Pages.Inventory
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3f4f6f049b3e8b9b391bd9fe739adf307dccf5b0", @"/Areas/Administration/Pages/Inventory/OperationLog.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fb0e07ca471ffd6fceb9fb5a1272d30c7f92445d", @"/Areas/Administration/Pages/_ViewImports.cshtml")]
    public class Areas_Administration_Pages_Inventory_OperationLog : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<InventoryManagement.Application.Contract.InventoryOperationViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
            WriteLiteral(@"
<div class=""modal-header"">
    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-hidden=""true"">×</button>
    <h4 class=""modal-title"">سوابق گردش انبار</h4>
</div>

<div class=""modal-body"">

    <table class=""table table-bordered table-responsive"">

        <thead>

            <tr>

                <th>#</th>
                <th>تعداد</th>
                <th>عملیات</th>
                <th>تاریخ عملیات</th>
                <th>موجودی فعلی</th>
                <th>توسط</th>
                <th>توضیحات</th>

            </tr>


        </thead>

        <tbody>

");
#nullable restore
#line 35 "E:\Programming\Codes and projects\MyOfficialEshopWebsite\MyOfficialEshopWebsite\ServiceHost\Areas\Administration\Pages\Inventory\OperationLog.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr");
            BeginWriteAttribute("class", " class=\"", 776, "\"", 841, 2);
            WriteAttributeValue("", 784, "text-white", 784, 10, true);
#nullable restore
#line 37 "E:\Programming\Codes and projects\MyOfficialEshopWebsite\MyOfficialEshopWebsite\ServiceHost\Areas\Administration\Pages\Inventory\OperationLog.cshtml"
WriteAttributeValue(" ", 794, item.Operation ? "bg-success" : "bg-danger", 795, 46, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n\r\n                <td>");
#nullable restore
#line 39 "E:\Programming\Codes and projects\MyOfficialEshopWebsite\MyOfficialEshopWebsite\ServiceHost\Areas\Administration\Pages\Inventory\OperationLog.cshtml"
               Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 40 "E:\Programming\Codes and projects\MyOfficialEshopWebsite\MyOfficialEshopWebsite\ServiceHost\Areas\Administration\Pages\Inventory\OperationLog.cshtml"
               Write(item.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>\r\n");
#nullable restore
#line 42 "E:\Programming\Codes and projects\MyOfficialEshopWebsite\MyOfficialEshopWebsite\ServiceHost\Areas\Administration\Pages\Inventory\OperationLog.cshtml"
                     if (item.Operation)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span>افزایش</span>\r\n");
#nullable restore
#line 45 "E:\Programming\Codes and projects\MyOfficialEshopWebsite\MyOfficialEshopWebsite\ServiceHost\Areas\Administration\Pages\Inventory\OperationLog.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span>کاهش</span>\r\n");
#nullable restore
#line 49 "E:\Programming\Codes and projects\MyOfficialEshopWebsite\MyOfficialEshopWebsite\ServiceHost\Areas\Administration\Pages\Inventory\OperationLog.cshtml"

                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\r\n                <td>");
#nullable restore
#line 52 "E:\Programming\Codes and projects\MyOfficialEshopWebsite\MyOfficialEshopWebsite\ServiceHost\Areas\Administration\Pages\Inventory\OperationLog.cshtml"
               Write(item.OperationDate);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                <td>");
#nullable restore
#line 53 "E:\Programming\Codes and projects\MyOfficialEshopWebsite\MyOfficialEshopWebsite\ServiceHost\Areas\Administration\Pages\Inventory\OperationLog.cshtml"
               Write(item.CurrentCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 54 "E:\Programming\Codes and projects\MyOfficialEshopWebsite\MyOfficialEshopWebsite\ServiceHost\Areas\Administration\Pages\Inventory\OperationLog.cshtml"
               Write(item.Operator);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 55 "E:\Programming\Codes and projects\MyOfficialEshopWebsite\MyOfficialEshopWebsite\ServiceHost\Areas\Administration\Pages\Inventory\OperationLog.cshtml"
               Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n            </tr>\r\n");
#nullable restore
#line 58 "E:\Programming\Codes and projects\MyOfficialEshopWebsite\MyOfficialEshopWebsite\ServiceHost\Areas\Administration\Pages\Inventory\OperationLog.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n        </tbody>\r\n\r\n\r\n    </table>\r\n\r\n</div>\r\n<div class=\"modal-footer\">\r\n    <button type=\"button\" class=\"btn btn-default waves-effect\" data-dismiss=\"modal\">بستن</button>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<InventoryManagement.Application.Contract.InventoryOperationViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
