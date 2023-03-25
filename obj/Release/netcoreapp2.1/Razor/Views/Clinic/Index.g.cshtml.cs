#pragma checksum "F:\project code\ERPMedicalCenter\Views\Clinic\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5e69691f185e6990ac7975b1fcbe2234f3ddd70a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Clinic_Index), @"mvc.1.0.view", @"/Views/Clinic/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Clinic/Index.cshtml", typeof(AspNetCore.Views_Clinic_Index))]
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
#line 1 "F:\project code\ERPMedicalCenter\Views\_ViewImports.cshtml"
using ERPMedicalCenter;

#line default
#line hidden
#line 2 "F:\project code\ERPMedicalCenter\Views\_ViewImports.cshtml"
using ERPMedicalCenter.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5e69691f185e6990ac7975b1fcbe2234f3ddd70a", @"/Views/Clinic/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"30b76a8959bf67681d92ca3541a89ba8a720c084", @"/Views/_ViewImports.cshtml")]
    public class Views_Clinic_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<entClinic>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "F:\project code\ERPMedicalCenter\Views\Clinic\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
            BeginContext(117, 1601, true);
            WriteLiteral(@"
<div class=""modal fade"" id=""exampleModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModal"" aria-hidden=""true"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""exampleModalLabel"">Add Clinic</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">


                <div class=""form-group"">
                    <label> Name</label>
                    <input type=""tel"" class=""form-control"" id=""ClinicName"" placeholder=""Clinic Name"">
                </div>
                <input type=""hidden"" id=""Type"" />
                <input type=""hidden"" id=""ClinicID"" />
            </div>
            <div class=""modal-footer"">
                <button type=""button"" id=""btnSaveClinic"" class=""btn btn-pr");
            WriteLiteral(@"imary"" data-dismiss=""modal"">Add</button>
            </div>
        </div>
    </div>
</div>


<div class=""d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-3 border-bottom"">
    <h1 class=""h2"">Manage Clinic</h1>
</div>

<div>
    <button type=""button"" id=""btnAdd"" class=""btn btn-primary"" data-toggle=""modal"" data-target=""#exampleModal"">
        create
    </button>
</div>


<table id=""example"">
    <thead>
        <tr>
            <th>Name</th>
            <th></th>

        </tr>

    </thead>
    <tbody>
");
            EndContext();
#line 55 "F:\project code\ERPMedicalCenter\Views\Clinic\Index.cshtml"
         foreach (entClinic item in Model)
        {

#line default
#line hidden
            BeginContext(1773, 38, true);
            WriteLiteral("            <tr>\r\n                <td>");
            EndContext();
            BeginContext(1812, 14, false);
#line 58 "F:\project code\ERPMedicalCenter\Views\Clinic\Index.cshtml"
               Write(item.Specialty);

#line default
#line hidden
            EndContext();
            BeginContext(1826, 69, true);
            WriteLiteral("</td>\r\n                <td> <button class=\" btn btn-primary btnEdite\"");
            EndContext();
            BeginWriteAttribute("itemID", " itemID=\"", 1895, "\"", 1918, 1);
#line 59 "F:\project code\ERPMedicalCenter\Views\Clinic\Index.cshtml"
WriteAttributeValue("", 1904, item.ClinicId, 1904, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1919, 55, true);
            WriteLiteral(">Edit</button><button class=\" btn btn-danger btnDelete\"");
            EndContext();
            BeginWriteAttribute("itemID", " itemID=\"", 1974, "\"", 1997, 1);
#line 59 "F:\project code\ERPMedicalCenter\Views\Clinic\Index.cshtml"
WriteAttributeValue("", 1983, item.ClinicId, 1983, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1998, 42, true);
            WriteLiteral(">Delete</button></td>\r\n            </tr>\r\n");
            EndContext();
#line 61 "F:\project code\ERPMedicalCenter\Views\Clinic\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(2051, 30, true);
            WriteLiteral("\r\n\r\n    </tbody>\r\n</table>\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(2099, 227, true);
                WriteLiteral("\r\n\r\n    <script>\r\n        $(\'#example\').DataTable();\r\n\r\n\r\n\r\n         $(\".btnDelete\").click(function () {\r\n            var id = $(this).attr(\"itemid\");\r\n            $.ajax({\r\n                type: \"POST\",\r\n                url: \"");
                EndContext();
                BeginContext(2327, 30, false);
#line 78 "F:\project code\ERPMedicalCenter\Views\Clinic\Index.cshtml"
                 Write(Url.Action("Delete", "Clinic"));

#line default
#line hidden
                EndContext();
                BeginContext(2357, 930, true);
                WriteLiteral(@""",
                content: ""application/json; charset=utf-8"",
                dataType: ""json"",
                data: ({
                    ID : id
                }),
                success: function (d) {
                    var resultData = $.parseJSON(d);
                    if (resultData[""ErrorCode""] == 0) {

                        window.location.reload();
                    } else {
                        alert(resultData[""Message""]);
                    }
                },
                error: function () {
                    alert(""error"");
                }
            });

        });

        $(""#btnSaveClinic"").click(function () {
            var ClinicName = $(""#ClinicName"").val();
            var type = $(""#Type"").val();
            if (type == 1) {
                // Create New
                $.ajax({
                    type: ""POST"",
                    url: """);
                EndContext();
                BeginContext(3288, 30, false);
#line 107 "F:\project code\ERPMedicalCenter\Views\Clinic\Index.cshtml"
                     Write(Url.Action("Create", "Clinic"));

#line default
#line hidden
                EndContext();
                BeginContext(3318, 861, true);
                WriteLiteral(@""",
                    content: ""application/json; charset=utf-8"",
                    dataType: ""json"",
                    data: {
                        Specialty: ClinicName
                    },
                    success: function (d) {
                        var resultData = $.parseJSON(d);
                        if (resultData[""ErrorCode""] == 0) {
                            window.location.reload();
                        } else {
                            alert(resultData[""Message""]);
                        }
                    },
                    error: function () {
                        alert(""error"");
                    }
                });
            } else {
                var ClinicID = $(""#ClinicID"").val();
                $.ajax({
                    type: ""POST"",
                    url: """);
                EndContext();
                BeginContext(4180, 28, false);
#line 129 "F:\project code\ERPMedicalCenter\Views\Clinic\Index.cshtml"
                     Write(Url.Action("Edit", "Clinic"));

#line default
#line hidden
                EndContext();
                BeginContext(4208, 1146, true);
                WriteLiteral(@""",
                    content: ""application/json; charset=utf-8"",
                    dataType: ""json"",
                    data: {
                        Specialty: ClinicName,
                        ClinicId: ClinicID
                    },
                    success: function (d) {
                        var resultData = $.parseJSON(d);
                        if (resultData[""ErrorCode""] == 0) {
                            window.location.reload();
                        } else {
                            alert(resultData[""Message""]);
                        }
                    },
                    error: function () {
                        alert(""error"");
                    }
                });
            }
        });

        $(""#btnAdd"").click(function () {
            $(""#Type"").val(""1"");
        });
        $("".btnEdite"").click(function () {
            var itemID = $(this).attr(""itemID"");
            $(""#Type"").val(""0"");
            $(""#ClinicName"").val(""");
                WriteLiteral("\");\r\n            $(\"#ClinicID\").val(itemID);\r\n             $.ajax({\r\n                type: \"POST\",\r\n                url: \"");
                EndContext();
                BeginContext(5355, 31, false);
#line 161 "F:\project code\ERPMedicalCenter\Views\Clinic\Index.cshtml"
                 Write(Url.Action("GetData", "Clinic"));

#line default
#line hidden
                EndContext();
                BeginContext(5386, 730, true);
                WriteLiteral(@""",
                content: ""application/json; charset=utf-8"",
                dataType: ""json"",
                data: ({
                    id: itemID
                }),
                success: function (d) {
                    var resultData = $.parseJSON(d);
                    if (resultData[""ErrorCode""] == 0) {
                        $(""#ClinicName"").val(resultData[""Data""].Specialty);
                    } else {
                        alert(resultData[""Message""]);
                    }
                },
                error: function () {
                    alert(""error"");
                }
            });
            $('#exampleModal').modal('show');

        });

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<entClinic>> Html { get; private set; }
    }
}
#pragma warning restore 1591
