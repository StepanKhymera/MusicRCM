#pragma checksum "C:\Users\Admin\source\repos\MusicRCM\MusicRCM\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bf2e4a78aad7a7fac42513e28f4ceb6f05d244cd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\Admin\source\repos\MusicRCM\MusicRCM\Views\_ViewImports.cshtml"
using MusicRCM;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Admin\source\repos\MusicRCM\MusicRCM\Views\_ViewImports.cshtml"
using MusicRCM.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bf2e4a78aad7a7fac42513e28f4ceb6f05d244cd", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"864f0ef0bcd6dfa6fd9b86c3e0a260e4490f826e", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/home.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Admin\source\repos\MusicRCM\MusicRCM\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "bf2e4a78aad7a7fac42513e28f4ceb6f05d244cd3917", async() => {
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
            WriteLiteral(@"

<div class=""text-center"">
    <h1 style=""    border-bottom: 1px solid #eb9f22;
    padding-left: 0px;
    margin-left: 20px;
    margin-right: 20px;
    padding-bottom: 10px;"">Welcome to MusicRCM</h1>
    <div id=""general"">
        <div id=""intro_text"">
            <p id=""t2"">To get recommendations open <strong>Source</strong> tab to create a playlist of songs that best reflect your music tastes.</p>
            <p id=""t3"">With the seed playlist in place, open <strong>Recommended</strong> tab and launch the algorythm. You can also listen to the songs by saving the recommended playlist to Spotify. <br /> Enjoy! </p> 

        </div>
        <div>
            <svg id=""master_plan"" width=""387"" height=""565"" viewBox=""0 0 387 565"" fill=""none"" xmlns=""http://www.w3.org/2000/svg"">
                <path d=""M44.9999 43.8734C45.0026 43.6063 44.9473 43.3418 44.8379 43.098C44.7285 42.8541 44.5676 42.6367 44.3661 42.4605C44.1647 42.2844 43.9274 42.1537 43.6706 42.0773C43.4138 42.001 43.1434 41.9809 42.8781");
            WriteLiteral(@" 42.0183C15.4618 45.9327 15.5177 45.3947 15.2199 47.3426V68.5099C8.296 66.1353 0.497344 76.1717 5.69024 81.3476C10.0828 85.7628 18.9424 80.6611 18.9424 73.9269V58.4735L41.2774 55.2826V64.7996C39.794 64.3895 38.2249 64.4015 36.748 64.8343C35.271 65.267 33.9451 66.1033 32.9204 67.2484C27.8205 72.313 30.1099 79.2883 35.8984 79.2883C37.0825 79.2594 38.249 78.9951 39.3292 78.5108C40.4095 78.0266 41.3819 77.3323 42.1894 76.4685C43.0658 75.6765 43.768 74.712 44.2517 73.636C44.7354 72.56 44.9902 71.3957 44.9999 70.2166V43.8734ZM9.85945 79.2883C7.36537 79.4367 6.97451 76.0975 9.4872 73.5745C10.9017 72.1831 13.4517 71.1999 14.6801 72.4057C16.56 74.2794 13.3586 79.2883 9.85945 79.2883ZM18.9424 54.7261V49.1606L41.2774 46.0069V51.5723L18.9424 54.7261ZM39.5464 73.8527C38.0574 75.3183 35.582 76.2273 34.3722 75.0215C32.5109 73.1663 35.582 68.1574 39.2114 68.1574C42.0219 68.1574 41.7986 71.7007 39.5464 73.8527Z"" fill=""black"" />
                <rect x=""1"" y=""35"" width=""48"" height=""55"" rx=""2"" stroke=""black"" stroke-width=""2"" /");
            WriteLiteral(@">
                <rect x=""60"" y=""47"" width=""71"" height=""6"" rx=""3"" fill=""black"" />
                <rect x=""60"" y=""71"" width=""71"" height=""6"" rx=""3"" fill=""black"" />
                <path d=""M44.9999 199.919C45.0026 199.646 44.9473 199.375 44.8379 199.125C44.7285 198.875 44.5676 198.652 44.3661 198.472C44.1647 198.291 43.9274 198.157 43.6706 198.079C43.4138 198.001 43.1434 197.98 42.8781 198.019C15.4618 202.029 15.5177 201.477 15.2199 203.473V225.156C8.296 222.724 0.497344 233.005 5.69024 238.307C10.0828 242.83 18.9424 237.604 18.9424 230.706V214.875L41.2774 211.607V221.356C39.794 220.936 38.2249 220.948 36.748 221.391C35.271 221.835 33.9451 222.691 32.9204 223.864C27.8205 229.052 30.1099 236.198 35.8984 236.198C37.0825 236.168 38.249 235.897 39.3292 235.401C40.4095 234.905 41.3819 234.194 42.1894 233.309C43.0658 232.498 43.768 231.51 44.2517 230.408C44.7354 229.305 44.9902 228.113 44.9999 226.905V199.919ZM9.85945 236.198C7.36537 236.35 6.97451 232.929 9.4872 230.345C10.9017 228.919 13.4517 227.912 14.6801 2");
            WriteLiteral(@"29.147C16.56 231.067 13.3586 236.198 9.85945 236.198ZM18.9424 211.036V205.335L41.2774 202.105V207.806L18.9424 211.036ZM39.5464 230.63C38.0574 232.131 35.582 233.062 34.3722 231.827C32.5109 229.926 35.582 224.795 39.2114 224.795C42.0219 224.795 41.7986 228.425 39.5464 230.63Z"" fill=""black"" />
                <rect x=""1"" y=""192"" width=""48"" height=""53"" rx=""2"" stroke=""black"" stroke-width=""2"" />
                <rect x=""60"" y=""204"" width=""71"" height=""6"" rx=""3"" fill=""black"" />
                <rect x=""60"" y=""228"" width=""71"" height=""6"" rx=""3"" fill=""black"" />
                <path d=""M44.9999 117.873C45.0026 117.606 44.9473 117.342 44.8379 117.098C44.7285 116.854 44.5676 116.637 44.3661 116.461C44.1647 116.284 43.9274 116.154 43.6706 116.077C43.4138 116.001 43.1434 115.981 42.8781 116.018C15.4618 119.933 15.5177 119.395 15.2199 121.343V142.51C8.296 140.135 0.497344 150.172 5.69024 155.348C10.0828 159.763 18.9424 154.661 18.9424 147.927V132.474L41.2774 129.283V138.8C39.794 138.389 38.2249 138.401 36.748 138.834C35");
            WriteLiteral(@".271 139.267 33.9451 140.103 32.9204 141.248C27.8205 146.313 30.1099 153.288 35.8984 153.288C37.0825 153.259 38.249 152.995 39.3292 152.511C40.4095 152.027 41.3819 151.332 42.1894 150.468C43.0658 149.676 43.768 148.712 44.2517 147.636C44.7354 146.56 44.9902 145.396 44.9999 144.217V117.873ZM9.85945 153.288C7.36537 153.437 6.97451 150.097 9.4872 147.574C10.9017 146.183 13.4517 145.2 14.6801 146.406C16.56 148.279 13.3586 153.288 9.85945 153.288ZM18.9424 128.726V123.161L41.2774 120.007V125.572L18.9424 128.726ZM39.5464 147.853C38.0574 149.318 35.582 150.227 34.3722 149.021C32.5109 147.166 35.582 142.157 39.2114 142.157C42.0219 142.157 41.7986 145.701 39.5464 147.853Z"" fill=""black"" />
                <rect x=""1"" y=""110"" width=""48"" height=""54"" rx=""2"" stroke=""black"" stroke-width=""2"" />
                <rect x=""60"" y=""122"" width=""71"" height=""6"" rx=""3"" fill=""black"" />
                <rect x=""60"" y=""146"" width=""71"" height=""6"" rx=""3"" fill=""black"" />
                <path d=""M277 361.873C277.003 361.606 276.947 361.3");
            WriteLiteral(@"42 276.838 361.098C276.729 360.854 276.568 360.637 276.366 360.461C276.165 360.284 275.927 360.154 275.671 360.077C275.414 360.001 275.143 359.981 274.878 360.018C247.462 363.933 247.518 363.395 247.22 365.343V386.51C240.296 384.135 232.497 394.172 237.69 399.348C242.083 403.763 250.942 398.661 250.942 391.927V376.474L273.277 373.283V382.8C271.794 382.389 270.225 382.401 268.748 382.834C267.271 383.267 265.945 384.103 264.92 385.248C259.821 390.313 262.11 397.288 267.898 397.288C269.083 397.259 270.249 396.995 271.329 396.511C272.41 396.027 273.382 395.332 274.189 394.468C275.066 393.676 275.768 392.712 276.252 391.636C276.735 390.56 276.99 389.396 277 388.217V361.873ZM241.859 397.288C239.365 397.437 238.975 394.097 241.487 391.574C242.902 390.183 245.452 389.2 246.68 390.406C248.56 392.279 245.359 397.288 241.859 397.288ZM250.942 372.726V367.161L273.277 364.007V369.572L250.942 372.726ZM271.546 391.853C270.057 393.318 267.582 394.227 266.372 393.021C264.511 391.166 267.582 386.157 271.211 386.157C274.022 386.");
            WriteLiteral(@"157 273.799 389.701 271.546 391.853Z"" fill=""#EB9F22"" />
                <rect x=""234"" y=""354"" width=""48"" height=""53"" rx=""2"" stroke=""#EB9F22"" stroke-width=""2"" />
                <rect x=""293"" y=""366"" width=""70"" height=""5"" rx=""2.5"" fill=""#EB9F22"" />
                <rect x=""293"" y=""390"" width=""70"" height=""5"" rx=""2.5"" fill=""#EB9F22"" />
                <path d=""M277 517.873C277.003 517.606 276.947 517.342 276.838 517.098C276.729 516.854 276.568 516.637 276.366 516.461C276.165 516.284 275.927 516.154 275.671 516.077C275.414 516.001 275.143 515.981 274.878 516.018C247.462 519.933 247.518 519.395 247.22 521.343V542.51C240.296 540.135 232.497 550.172 237.69 555.348C242.083 559.763 250.942 554.661 250.942 547.927V532.474L273.277 529.283V538.8C271.794 538.389 270.225 538.401 268.748 538.834C267.271 539.267 265.945 540.103 264.92 541.248C259.821 546.313 262.11 553.288 267.898 553.288C269.083 553.259 270.249 552.995 271.329 552.511C272.41 552.027 273.382 551.332 274.189 550.468C275.066 549.676 275.768 548.712 276.252");
            WriteLiteral(@" 547.636C276.735 546.56 276.99 545.396 277 544.217V517.873ZM241.859 553.288C239.365 553.437 238.975 550.097 241.487 547.574C242.902 546.183 245.452 545.2 246.68 546.406C248.56 548.279 245.359 553.288 241.859 553.288ZM250.942 528.726V523.161L273.277 520.007V525.572L250.942 528.726ZM271.546 547.853C270.057 549.318 267.582 550.227 266.372 549.021C264.511 547.166 267.582 542.157 271.211 542.157C274.022 542.157 273.799 545.701 271.546 547.853Z"" fill=""#EB9F22"" />
                <rect x=""234"" y=""509"" width=""48"" height=""55"" rx=""2"" stroke=""#EB9F22"" stroke-width=""2"" />
                <rect x=""293"" y=""521"" width=""70"" height=""7"" rx=""3.5"" fill=""#EB9F22"" />
                <rect x=""293"" y=""547"" width=""70"" height=""5"" rx=""2.5"" fill=""#EB9F22"" />
                <path d=""M277 435.919C277.003 435.646 276.947 435.375 276.838 435.125C276.729 434.875 276.568 434.652 276.366 434.472C276.165 434.291 275.927 434.157 275.671 434.079C275.414 434.001 275.143 433.98 274.878 434.019C247.462 438.029 247.518 437.477 247.22 439.473V461");
            WriteLiteral(@".156C240.296 458.724 232.497 469.005 237.69 474.307C242.083 478.83 250.942 473.604 250.942 466.706V450.875L273.277 447.607V457.356C271.794 456.936 270.225 456.948 268.748 457.391C267.271 457.835 265.945 458.691 264.92 459.864C259.821 465.052 262.11 472.198 267.898 472.198C269.083 472.168 270.249 471.897 271.329 471.401C272.41 470.905 273.382 470.194 274.189 469.309C275.066 468.498 275.768 467.51 276.252 466.408C276.735 465.305 276.99 464.113 277 462.905V435.919ZM241.859 472.198C239.365 472.35 238.975 468.929 241.487 466.345C242.902 464.919 245.452 463.912 246.68 465.147C248.56 467.067 245.359 472.198 241.859 472.198ZM250.942 447.036V441.335L273.277 438.105V443.806L250.942 447.036ZM271.546 466.63C270.057 468.131 267.582 469.062 266.372 467.827C264.511 465.926 267.582 460.795 271.211 460.795C274.022 460.795 273.799 464.425 271.546 466.63Z"" fill=""#EB9F22"" />
                <rect x=""234"" y=""428"" width=""48"" height=""54"" rx=""2"" stroke=""#EB9F22"" stroke-width=""2"" />
                <rect x=""293"" y=""440"" width=""70"" ");
            WriteLiteral(@"height=""5"" rx=""2.5"" fill=""#EB9F22"" />
                <rect x=""293"" y=""464"" width=""70"" height=""6"" rx=""3"" fill=""#EB9F22"" />
                <path d=""M32.061 17.138C30.865 17.138 29.715 16.9463 28.611 16.563C27.5223 16.1643 26.679 15.6583 26.081 15.045L26.748 13.734C27.3153 14.286 28.0743 14.7537 29.025 15.137C29.991 15.505 31.003 15.689 32.061 15.689C33.073 15.689 33.8933 15.5663 34.522 15.321C35.166 15.0603 35.6337 14.7153 35.925 14.286C36.2317 13.8567 36.385 13.3813 36.385 12.86C36.385 12.2313 36.201 11.7253 35.833 11.342C35.4803 10.9587 35.0127 10.6597 34.43 10.445C33.8473 10.215 33.2033 10.0157 32.498 9.847C31.7927 9.67833 31.0873 9.502 30.382 9.318C29.6767 9.11867 29.025 8.858 28.427 8.536C27.8443 8.214 27.369 7.79233 27.001 7.271C26.6483 6.73433 26.472 6.03667 26.472 5.178C26.472 4.38067 26.679 3.65233 27.093 2.993C27.5223 2.31833 28.174 1.78167 29.048 1.383C29.922 0.968999 31.0413 0.761999 32.406 0.761999C33.3107 0.761999 34.2077 0.892333 35.097 1.153C35.9863 1.39833 36.753 1.74333 37.397 2.188L36.822");
            WriteLiteral(@" 3.545C36.132 3.085 35.396 2.74767 34.614 2.533C33.8473 2.31833 33.1037 2.211 32.383 2.211C31.417 2.211 30.6197 2.34133 29.991 2.602C29.3623 2.86267 28.8947 3.21533 28.588 3.66C28.2967 4.08933 28.151 4.58 28.151 5.132C28.151 5.76067 28.3273 6.26667 28.68 6.65C29.048 7.03333 29.5233 7.33233 30.106 7.547C30.704 7.76167 31.3557 7.95333 32.061 8.122C32.7663 8.29067 33.464 8.47467 34.154 8.674C34.8593 8.87333 35.5033 9.134 36.086 9.456C36.684 9.76267 37.1593 10.1767 37.512 10.698C37.88 11.2193 38.064 11.9017 38.064 12.745C38.064 13.527 37.8493 14.2553 37.42 14.93C36.9907 15.5893 36.3313 16.126 35.442 16.54C34.568 16.9387 33.441 17.138 32.061 17.138ZM46.8494 17.115C45.6841 17.115 44.6337 16.8543 43.6984 16.333C42.7784 15.7963 42.0501 15.068 41.5134 14.148C40.9767 13.2127 40.7084 12.147 40.7084 10.951C40.7084 9.73967 40.9767 8.674 41.5134 7.754C42.0501 6.834 42.7784 6.11333 43.6984 5.592C44.6184 5.07067 45.6687 4.81 46.8494 4.81C48.0454 4.81 49.1034 5.07067 50.0234 5.592C50.9587 6.11333 51.6871 6.834 52.2084 7.754C5");
            WriteLiteral(@"2.7451 8.674 53.0134 9.73967 53.0134 10.951C53.0134 12.147 52.7451 13.2127 52.2084 14.148C51.6871 15.068 50.9587 15.7963 50.0234 16.333C49.0881 16.8543 48.0301 17.115 46.8494 17.115ZM46.8494 15.666C47.7234 15.666 48.4977 15.4743 49.1724 15.091C49.8471 14.6923 50.3761 14.1403 50.7594 13.435C51.1581 12.7143 51.3574 11.8863 51.3574 10.951C51.3574 10.0003 51.1581 9.17233 50.7594 8.467C50.3761 7.76167 49.8471 7.21733 49.1724 6.834C48.4977 6.43533 47.7311 6.236 46.8724 6.236C46.0137 6.236 45.2471 6.43533 44.5724 6.834C43.8977 7.21733 43.3611 7.76167 42.9624 8.467C42.5637 9.17233 42.3644 10.0003 42.3644 10.951C42.3644 11.8863 42.5637 12.7143 42.9624 13.435C43.3611 14.1403 43.8977 14.6923 44.5724 15.091C45.2471 15.4743 46.0061 15.666 46.8494 15.666ZM61.8383 17.115C60.811 17.115 59.914 16.9233 59.1473 16.54C58.3806 16.1567 57.7826 15.5817 57.3533 14.815C56.9393 14.0483 56.7323 13.09 56.7323 11.94V4.925H58.3653V11.756C58.3653 13.044 58.6796 14.0177 59.3083 14.677C59.9523 15.321 60.8493 15.643 61.9993 15.643C62.8426 15.");
            WriteLiteral(@"643 63.571 15.4743 64.1843 15.137C64.813 14.7843 65.2883 14.2783 65.6103 13.619C65.9476 12.9597 66.1163 12.17 66.1163 11.25V4.925H67.7493V17H66.1853V13.688L66.4383 14.286C66.055 15.1753 65.457 15.873 64.6443 16.379C63.847 16.8697 62.9116 17.115 61.8383 17.115ZM72.8004 17V4.925H74.3644V8.214L74.2034 7.639C74.5408 6.719 75.1081 6.02133 75.9054 5.546C76.7028 5.05533 77.6918 4.81 78.8724 4.81V6.397C78.8111 6.397 78.7498 6.397 78.6884 6.397C78.6271 6.38167 78.5658 6.374 78.5044 6.374C77.2318 6.374 76.2351 6.765 75.5144 7.547C74.7938 8.31367 74.4334 9.41 74.4334 10.836V17H72.8004ZM87.2539 17.115C86.0579 17.115 84.9846 16.8543 84.0339 16.333C83.0986 15.7963 82.3626 15.068 81.8259 14.148C81.2892 13.2127 81.0209 12.147 81.0209 10.951C81.0209 9.73967 81.2892 8.674 81.8259 7.754C82.3626 6.834 83.0986 6.11333 84.0339 5.592C84.9846 5.07067 86.0579 4.81 87.2539 4.81C88.2812 4.81 89.2089 5.00933 90.0369 5.408C90.8649 5.80667 91.5166 6.40467 91.9919 7.202L90.7729 8.03C90.3589 7.41667 89.8452 6.96433 89.2319 6.673C88.6186 6.3");
            WriteLiteral(@"8167 87.9516 6.236 87.2309 6.236C86.3722 6.236 85.5979 6.43533 84.9079 6.834C84.2179 7.21733 83.6736 7.76167 83.2749 8.467C82.8762 9.17233 82.6769 10.0003 82.6769 10.951C82.6769 11.9017 82.8762 12.7297 83.2749 13.435C83.6736 14.1403 84.2179 14.6923 84.9079 15.091C85.5979 15.4743 86.3722 15.666 87.2309 15.666C87.9516 15.666 88.6186 15.5203 89.2319 15.229C89.8452 14.9377 90.3589 14.493 90.7729 13.895L91.9919 14.723C91.5166 15.505 90.8649 16.103 90.0369 16.517C89.2089 16.9157 88.2812 17.115 87.2539 17.115ZM100.627 17.115C99.3694 17.115 98.2654 16.8543 97.3147 16.333C96.364 15.7963 95.6204 15.068 95.0837 14.148C94.547 13.2127 94.2787 12.147 94.2787 10.951C94.2787 9.755 94.5317 8.697 95.0377 7.777C95.559 6.857 96.2644 6.13633 97.1537 5.615C98.0584 5.07833 99.0704 4.81 100.19 4.81C101.324 4.81 102.329 5.07067 103.203 5.592C104.092 6.098 104.79 6.81867 105.296 7.754C105.802 8.674 106.055 9.73967 106.055 10.951C106.055 11.0277 106.047 11.112 106.032 11.204C106.032 11.2807 106.032 11.365 106.032 11.457H95.5207V10.238H");
            WriteLiteral(@"105.158L104.514 10.721C104.514 9.847 104.322 9.07267 103.939 8.398C103.571 7.708 103.065 7.17133 102.421 6.788C101.777 6.40467 101.033 6.213 100.19 6.213C99.3617 6.213 98.618 6.40467 97.9587 6.788C97.2994 7.17133 96.7857 7.708 96.4177 8.398C96.0497 9.088 95.8657 9.87767 95.8657 10.767V11.02C95.8657 11.94 96.065 12.7527 96.4637 13.458C96.8777 14.148 97.445 14.6923 98.1657 15.091C98.9017 15.4743 99.7374 15.666 100.673 15.666C101.409 15.666 102.091 15.5357 102.72 15.275C103.364 15.0143 103.916 14.6157 104.376 14.079L105.296 15.137C104.759 15.781 104.084 16.2717 103.272 16.609C102.474 16.9463 101.593 17.115 100.627 17.115Z"" fill=""black"" />
                <path d=""M205.622 336V319.9H211.648C213.013 319.9 214.186 320.122 215.167 320.567C216.148 320.996 216.9 321.625 217.421 322.453C217.958 323.266 218.226 324.255 218.226 325.42C218.226 326.555 217.958 327.536 217.421 328.364C216.9 329.177 216.148 329.805 215.167 330.25C214.186 330.679 213.013 330.894 211.648 330.894H206.565L207.324 330.112V336H205.622ZM216.616 33");
            WriteLiteral(@"6L212.476 330.158H214.316L218.479 336H216.616ZM207.324 330.25L206.565 329.445H211.602C213.212 329.445 214.431 329.092 215.259 328.387C216.102 327.682 216.524 326.693 216.524 325.42C216.524 324.132 216.102 323.135 215.259 322.43C214.431 321.725 213.212 321.372 211.602 321.372H206.565L207.324 320.567V330.25ZM227.527 336.115C226.27 336.115 225.166 335.854 224.215 335.333C223.264 334.796 222.521 334.068 221.984 333.148C221.447 332.213 221.179 331.147 221.179 329.951C221.179 328.755 221.432 327.697 221.938 326.777C222.459 325.857 223.165 325.136 224.054 324.615C224.959 324.078 225.971 323.81 227.09 323.81C228.225 323.81 229.229 324.071 230.103 324.592C230.992 325.098 231.69 325.819 232.196 326.754C232.702 327.674 232.955 328.74 232.955 329.951C232.955 330.028 232.947 330.112 232.932 330.204C232.932 330.281 232.932 330.365 232.932 330.457H222.421V329.238H232.058L231.414 329.721C231.414 328.847 231.222 328.073 230.839 327.398C230.471 326.708 229.965 326.171 229.321 325.788C228.677 325.405 227.933 325.213 227.09 325.");
            WriteLiteral(@"213C226.262 325.213 225.518 325.405 224.859 325.788C224.2 326.171 223.686 326.708 223.318 327.398C222.95 328.088 222.766 328.878 222.766 329.767V330.02C222.766 330.94 222.965 331.753 223.364 332.458C223.778 333.148 224.345 333.692 225.066 334.091C225.802 334.474 226.638 334.666 227.573 334.666C228.309 334.666 228.991 334.536 229.62 334.275C230.264 334.014 230.816 333.616 231.276 333.079L232.196 334.137C231.659 334.781 230.985 335.272 230.172 335.609C229.375 335.946 228.493 336.115 227.527 336.115ZM241.793 336.115C240.597 336.115 239.524 335.854 238.573 335.333C237.638 334.796 236.902 334.068 236.365 333.148C235.828 332.213 235.56 331.147 235.56 329.951C235.56 328.74 235.828 327.674 236.365 326.754C236.902 325.834 237.638 325.113 238.573 324.592C239.524 324.071 240.597 323.81 241.793 323.81C242.82 323.81 243.748 324.009 244.576 324.408C245.404 324.807 246.056 325.405 246.531 326.202L245.312 327.03C244.898 326.417 244.384 325.964 243.771 325.673C243.158 325.382 242.491 325.236 241.77 325.236C240.911 325.236 240");
            WriteLiteral(@".137 325.435 239.447 325.834C238.757 326.217 238.213 326.762 237.814 327.467C237.415 328.172 237.216 329 237.216 329.951C237.216 330.902 237.415 331.73 237.814 332.435C238.213 333.14 238.757 333.692 239.447 334.091C240.137 334.474 240.911 334.666 241.77 334.666C242.491 334.666 243.158 334.52 243.771 334.229C244.384 333.938 244.898 333.493 245.312 332.895L246.531 333.723C246.056 334.505 245.404 335.103 244.576 335.517C243.748 335.916 242.82 336.115 241.793 336.115ZM254.959 336.115C253.793 336.115 252.743 335.854 251.808 335.333C250.888 334.796 250.159 334.068 249.623 333.148C249.086 332.213 248.818 331.147 248.818 329.951C248.818 328.74 249.086 327.674 249.623 326.754C250.159 325.834 250.888 325.113 251.808 324.592C252.728 324.071 253.778 323.81 254.959 323.81C256.155 323.81 257.213 324.071 258.133 324.592C259.068 325.113 259.796 325.834 260.318 326.754C260.854 327.674 261.123 328.74 261.123 329.951C261.123 331.147 260.854 332.213 260.318 333.148C259.796 334.068 259.068 334.796 258.133 335.333C257.197 335.854 ");
            WriteLiteral(@"256.139 336.115 254.959 336.115ZM254.959 334.666C255.833 334.666 256.607 334.474 257.282 334.091C257.956 333.692 258.485 333.14 258.869 332.435C259.267 331.714 259.467 330.886 259.467 329.951C259.467 329 259.267 328.172 258.869 327.467C258.485 326.762 257.956 326.217 257.282 325.834C256.607 325.435 255.84 325.236 254.982 325.236C254.123 325.236 253.356 325.435 252.682 325.834C252.007 326.217 251.47 326.762 251.072 327.467C250.673 328.172 250.474 329 250.474 329.951C250.474 330.886 250.673 331.714 251.072 332.435C251.47 333.14 252.007 333.692 252.682 334.091C253.356 334.474 254.115 334.666 254.959 334.666ZM280.045 323.81C281.026 323.81 281.877 324.002 282.598 324.385C283.334 324.753 283.901 325.32 284.3 326.087C284.714 326.854 284.921 327.82 284.921 328.985V336H283.288V329.146C283.288 327.873 282.981 326.915 282.368 326.271C281.77 325.612 280.919 325.282 279.815 325.282C278.987 325.282 278.266 325.458 277.653 325.811C277.055 326.148 276.587 326.647 276.25 327.306C275.928 327.95 275.767 328.732 275.767 329.652V");
            WriteLiteral(@"336H274.134V329.146C274.134 327.873 273.827 326.915 273.214 326.271C272.6 325.612 271.742 325.282 270.638 325.282C269.825 325.282 269.112 325.458 268.499 325.811C267.885 326.148 267.41 326.647 267.073 327.306C266.751 327.95 266.59 328.732 266.59 329.652V336H264.957V323.925H266.521V327.191L266.268 326.616C266.636 325.742 267.226 325.06 268.039 324.569C268.867 324.063 269.84 323.81 270.96 323.81C272.14 323.81 273.145 324.109 273.973 324.707C274.801 325.29 275.337 326.171 275.583 327.352L274.939 327.099C275.291 326.118 275.912 325.328 276.802 324.73C277.706 324.117 278.787 323.81 280.045 323.81ZM304.937 323.81C305.919 323.81 306.77 324.002 307.49 324.385C308.226 324.753 308.794 325.32 309.192 326.087C309.606 326.854 309.813 327.82 309.813 328.985V336H308.18V329.146C308.18 327.873 307.874 326.915 307.26 326.271C306.662 325.612 305.811 325.282 304.707 325.282C303.879 325.282 303.159 325.458 302.545 325.811C301.947 326.148 301.48 326.647 301.142 327.306C300.82 327.95 300.659 328.732 300.659 329.652V336H299.026V329.");
            WriteLiteral(@"146C299.026 327.873 298.72 326.915 298.106 326.271C297.493 325.612 296.634 325.282 295.53 325.282C294.718 325.282 294.005 325.458 293.391 325.811C292.778 326.148 292.303 326.647 291.965 327.306C291.643 327.95 291.482 328.732 291.482 329.652V336H289.849V323.925H291.413V327.191L291.16 326.616C291.528 325.742 292.119 325.06 292.931 324.569C293.759 324.063 294.733 323.81 295.852 323.81C297.033 323.81 298.037 324.109 298.865 324.707C299.693 325.29 300.23 326.171 300.475 327.352L299.831 327.099C300.184 326.118 300.805 325.328 301.694 324.73C302.599 324.117 303.68 323.81 304.937 323.81ZM319.871 336.115C318.614 336.115 317.51 335.854 316.559 335.333C315.608 334.796 314.865 334.068 314.328 333.148C313.791 332.213 313.523 331.147 313.523 329.951C313.523 328.755 313.776 327.697 314.282 326.777C314.803 325.857 315.509 325.136 316.398 324.615C317.303 324.078 318.315 323.81 319.434 323.81C320.569 323.81 321.573 324.071 322.447 324.592C323.336 325.098 324.034 325.819 324.54 326.754C325.046 327.674 325.299 328.74 325.299 329");
            WriteLiteral(@".951C325.299 330.028 325.291 330.112 325.276 330.204C325.276 330.281 325.276 330.365 325.276 330.457H314.765V329.238H324.402L323.758 329.721C323.758 328.847 323.566 328.073 323.183 327.398C322.815 326.708 322.309 326.171 321.665 325.788C321.021 325.405 320.277 325.213 319.434 325.213C318.606 325.213 317.862 325.405 317.203 325.788C316.544 326.171 316.03 326.708 315.662 327.398C315.294 328.088 315.11 328.878 315.11 329.767V330.02C315.11 330.94 315.309 331.753 315.708 332.458C316.122 333.148 316.689 333.692 317.41 334.091C318.146 334.474 318.982 334.666 319.917 334.666C320.653 334.666 321.335 334.536 321.964 334.275C322.608 334.014 323.16 333.616 323.62 333.079L324.54 334.137C324.003 334.781 323.329 335.272 322.516 335.609C321.719 335.946 320.837 336.115 319.871 336.115ZM335.287 323.81C336.268 323.81 337.127 324.002 337.863 324.385C338.614 324.753 339.197 325.32 339.611 326.087C340.04 326.854 340.255 327.82 340.255 328.985V336H338.622V329.146C338.622 327.873 338.3 326.915 337.656 326.271C337.027 325.612 336.138");
            WriteLiteral(@" 325.282 334.988 325.282C334.129 325.282 333.378 325.458 332.734 325.811C332.105 326.148 331.614 326.647 331.262 327.306C330.924 327.95 330.756 328.732 330.756 329.652V336H329.123V323.925H330.687V327.237L330.434 326.616C330.817 325.742 331.43 325.06 332.274 324.569C333.117 324.063 334.121 323.81 335.287 323.81ZM349.973 336.115C348.823 336.115 347.788 335.854 346.868 335.333C345.963 334.812 345.25 334.091 344.729 333.171C344.207 332.236 343.947 331.162 343.947 329.951C343.947 328.724 344.207 327.651 344.729 326.731C345.25 325.811 345.963 325.098 346.868 324.592C347.788 324.071 348.823 323.81 349.973 323.81C351.031 323.81 351.974 324.048 352.802 324.523C353.645 324.998 354.312 325.696 354.803 326.616C355.309 327.521 355.562 328.632 355.562 329.951C355.562 331.254 355.316 332.366 354.826 333.286C354.335 334.206 353.668 334.911 352.825 335.402C351.997 335.877 351.046 336.115 349.973 336.115ZM350.088 334.666C350.946 334.666 351.713 334.474 352.388 334.091C353.078 333.692 353.614 333.14 353.998 332.435C354.396 331.");
            WriteLiteral(@"714 354.596 330.886 354.596 329.951C354.596 329 354.396 328.172 353.998 327.467C353.614 326.762 353.078 326.217 352.388 325.834C351.713 325.435 350.946 325.236 350.088 325.236C349.244 325.236 348.485 325.435 347.811 325.834C347.136 326.217 346.599 326.762 346.201 327.467C345.802 328.172 345.603 329 345.603 329.951C345.603 330.886 345.802 331.714 346.201 332.435C346.599 333.14 347.136 333.692 347.811 334.091C348.485 334.474 349.244 334.666 350.088 334.666ZM354.642 336V332.366L354.803 329.928L354.573 327.49V318.934H356.206V336H354.642ZM366.383 336.115C365.125 336.115 364.021 335.854 363.071 335.333C362.12 334.796 361.376 334.068 360.84 333.148C360.303 332.213 360.035 331.147 360.035 329.951C360.035 328.755 360.288 327.697 360.794 326.777C361.315 325.857 362.02 325.136 362.91 324.615C363.814 324.078 364.826 323.81 365.946 323.81C367.08 323.81 368.085 324.071 368.959 324.592C369.848 325.098 370.546 325.819 371.052 326.754C371.558 327.674 371.811 328.74 371.811 329.951C371.811 330.028 371.803 330.112 371.788 330.2");
            WriteLiteral(@"04C371.788 330.281 371.788 330.365 371.788 330.457H361.277V329.238H370.914L370.27 329.721C370.27 328.847 370.078 328.073 369.695 327.398C369.327 326.708 368.821 326.171 368.177 325.788C367.533 325.405 366.789 325.213 365.946 325.213C365.118 325.213 364.374 325.405 363.715 325.788C363.055 326.171 362.542 326.708 362.174 327.398C361.806 328.088 361.622 328.878 361.622 329.767V330.02C361.622 330.94 361.821 331.753 362.22 332.458C362.634 333.148 363.201 333.692 363.922 334.091C364.658 334.474 365.493 334.666 366.429 334.666C367.165 334.666 367.847 334.536 368.476 334.275C369.12 334.014 369.672 333.616 370.132 333.079L371.052 334.137C370.515 334.781 369.84 335.272 369.028 335.609C368.23 335.946 367.349 336.115 366.383 336.115ZM380.441 336.115C379.291 336.115 378.256 335.854 377.336 335.333C376.432 334.812 375.719 334.091 375.197 333.171C374.676 332.236 374.415 331.162 374.415 329.951C374.415 328.724 374.676 327.651 375.197 326.731C375.719 325.811 376.432 325.098 377.336 324.592C378.256 324.071 379.291 323.81 380.4");
            WriteLiteral(@"41 323.81C381.499 323.81 382.442 324.048 383.27 324.523C384.114 324.998 384.781 325.696 385.271 326.616C385.777 327.521 386.03 328.632 386.03 329.951C386.03 331.254 385.785 332.366 385.294 333.286C384.804 334.206 384.137 334.911 383.293 335.402C382.465 335.877 381.515 336.115 380.441 336.115ZM380.556 334.666C381.415 334.666 382.182 334.474 382.856 334.091C383.546 333.692 384.083 333.14 384.466 332.435C384.865 331.714 385.064 330.886 385.064 329.951C385.064 329 384.865 328.172 384.466 327.467C384.083 326.762 383.546 326.217 382.856 325.834C382.182 325.435 381.415 325.236 380.556 325.236C379.713 325.236 378.954 325.435 378.279 325.834C377.605 326.217 377.068 326.762 376.669 327.467C376.271 328.172 376.071 329 376.071 329.951C376.071 330.886 376.271 331.714 376.669 332.435C377.068 333.14 377.605 333.692 378.279 334.091C378.954 334.474 379.713 334.666 380.556 334.666ZM385.11 336V332.366L385.271 329.928L385.041 327.49V318.934H386.674V336H385.11Z"" fill=""#EB9F22"" />
                <path d=""M119 305.022C117.21 318.");
            WriteLiteral(@"232 118.149 331.667 121.76 344.499L122.925 348.719L124.248 352.716L127.016 360.379L130.034 367.478C130.926 369.762 131.948 371.992 133.096 374.158C135.27 378.448 137.237 382.517 139.491 386.132L142.688 391.556L145.978 396.507C152.924 406.879 160.739 416.64 169.34 425.686C174.514 431.156 180.002 436.322 185.774 441.158C188.638 443.62 191.65 445.904 194.793 447.997L194.032 447.993C190.39 447.853 186.781 447.59 183.375 447.314L165.125 445.776C154.663 445.115 148.028 445.14 147.69 446.409C147.353 447.679 153.548 450.055 163.766 452.507C168.843 453.856 175.002 454.997 181.917 456.04C185.389 456.566 189.041 457.04 192.945 457.315C193.923 457.376 194.901 457.438 195.926 457.445L197.511 457.469L198.342 457.458L199.524 457.374C200.5 457.368 201.464 457.164 202.359 456.776C203.254 456.387 204.061 455.822 204.732 455.113C206.072 453.479 206.902 451.487 207.117 449.384L207.315 448.642L207.446 448.146L207.693 447.218C207.858 446.599 207.82 445.992 207.884 445.379C207.972 444.176 208.012 443.027 208.061 441.847C208.172 439");
            WriteLiteral(@".557 208.167 437.335 208.159 435.245C208.123 430.894 207.998 426.751 207.816 422.825C207.42 414.965 206.841 407.917 206.175 402.073C204.889 390.331 203.341 383.191 202.165 383.376C200.989 383.56 200.404 390.994 200.322 402.771C200.273 408.69 200.191 415.727 200.137 423.534C200.103 427.403 200.05 431.465 199.987 435.69C199.925 437.795 199.862 439.899 199.761 442.026L199.661 443.524C198.017 441.729 195.284 439.046 190.937 434.577C187.165 430.69 182.121 425.604 175.896 418.481C167.943 409.459 160.682 399.851 154.174 389.738L150.756 385.018L147.804 379.792C145.712 376.32 143.867 372.415 141.916 368.284C140.863 366.246 139.927 364.149 139.112 362.004L136.353 355.305L134.006 348.053C133.604 346.819 133.203 345.586 132.755 344.406C132.306 343.226 132.078 341.84 131.764 340.53C128.596 329.383 127.731 317.708 129.222 306.216C130.118 300.145 132.274 294.329 135.551 289.141C138.873 284.031 143.517 279.918 148.99 277.237C152.894 283.999 157.575 290.282 162.936 295.958C169.263 302.885 176.947 308.436 185.511 312.267C189.9");
            WriteLiteral(@"12 314.061 194.599 315.049 199.35 315.185C204.743 315.446 210.072 313.929 214.517 310.866C217.293 308.867 219.463 306.141 220.788 302.988C222.15 299.724 222.585 296.147 222.045 292.651C221.065 287.25 218.403 282.297 214.44 278.499C208.155 272.633 200.632 268.254 192.427 265.686C184.922 262.979 177.022 261.528 169.045 261.392C163.767 261.333 158.507 262.021 153.422 263.435C150.025 256.188 147.821 248.44 146.896 240.49C146.453 235.841 146.521 231.158 147.096 226.524C147.722 221.926 148.919 217.423 150.66 213.121C154.291 204.473 159.747 196.71 166.653 190.363C169.939 187.258 173.583 184.555 177.51 182.313C179.414 181.221 181.379 180.239 183.396 179.371C185.41 178.581 187.469 177.911 189.563 177.365C191.729 176.766 193.938 176.334 196.17 176.073C199.697 182.282 203.65 188.239 208.001 193.9C213.529 201.269 220.045 207.841 227.366 213.432C231.245 216.467 235.742 218.613 240.541 219.72C243.664 220.392 246.925 219.849 249.661 218.201C250.444 217.702 251.167 217.116 251.816 216.454C252.385 215.809 252.954 215.165 253.");
            WriteLiteral(@"461 214.505C254.008 213.797 254.478 213.033 254.862 212.226C255.327 211.432 255.677 210.577 255.902 209.686C256.954 206.39 257.017 202.858 256.085 199.526C255.74 198.077 255.262 196.663 254.656 195.302C254.075 194.055 253.424 192.842 252.706 191.668C249.948 187.338 246.489 183.495 242.473 180.298C235.011 174.183 226.272 169.821 216.901 167.533C212.217 166.342 207.404 165.73 202.571 165.711C201.352 165.686 200.116 165.722 198.872 165.788C194.97 158.514 190.473 148.149 185.5 139.906C180.128 131 170.5 117.278 166.802 114.406C150.877 102.035 160 118 160 118C160 118 166.088 125.811 175.794 139.906C185.5 154 188.44 160.312 191.705 167.065C190.622 167.274 189.562 167.522 188.494 167.801C183.381 168.958 178.461 170.842 173.882 173.395C169.258 175.975 164.965 179.106 161.096 182.721C152.955 190.161 146.511 199.264 142.2 209.414C140.068 214.69 138.6 220.211 137.83 225.85C137.105 231.375 137.008 236.964 137.543 242.51C138.462 251.119 140.695 259.537 144.163 267.469C137.398 271.139 131.665 276.453 127.494 282.922C123.198");
            WriteLiteral(@" 289.7 120.375 297.304 119.206 305.243L119 305.022ZM204.796 175.914C208.114 176.049 211.412 176.504 214.643 177.273C222.941 179.211 230.703 182.973 237.366 188.286C240.668 190.863 243.527 193.963 245.829 197.463C246.408 198.279 246.759 199.201 247.259 200.063C247.637 200.93 247.953 201.823 248.206 202.734C248.691 204.223 248.716 205.824 248.277 207.327C248.268 207.673 248.178 208.012 248.014 208.317C247.932 208.627 247.841 208.967 247.472 209.234L246.693 209.921C246.521 210.12 246.319 210.29 246.095 210.425C244.908 211.064 243.527 211.24 242.218 210.919C238.447 210.02 234.909 208.333 231.835 205.971C225.007 200.875 218.897 194.881 213.673 188.15C210.531 184.178 207.578 180.078 204.813 175.852L204.796 175.914ZM159.326 273.887C169.23 272.334 179.367 273.352 188.765 276.843C195.628 278.981 201.94 282.594 207.261 287.427C209.521 289.53 211.103 292.258 211.805 295.264C212.031 296.395 211.912 297.567 211.464 298.63C211.016 299.692 210.259 300.596 209.293 301.224C206.559 302.97 203.344 303.809 200.105 303.62C196.432");
            WriteLiteral(" 303.521 192.805 302.77 189.394 301.402C182.029 298.079 175.408 293.31 169.924 287.376C165.948 283.187 162.377 278.631 159.258 273.769\" fill=\"#072333\" />\r\n            </svg>\r\n        </div>\r\n    </div>\r\n   \r\n\r\n\r\n</div>\r\n");
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
