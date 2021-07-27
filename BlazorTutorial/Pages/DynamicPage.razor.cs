using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTutorial.Pages
{
    public partial class DynamicPage
    {
        private string Heading { get; set; } = string.Empty;
        private string Description { get; set; } = string.Empty;

        private void BlazorServerClick()
        {
            Heading = "Blazor Server";
            Description = "Blazor Server Generates Dynamic Content on the server and Send to the User browser via signal R connection establisted between web page and Server.";
        }

        private void BlazorWebAssemblyClick()
        {
            Heading = "Blazor Web Assembly";
            Description = "Blazor Web Assembly run in the client site and generate all the dynamic content in the web browser i.e. Front End.";
        }

        private void ResetClick()
        {
            Heading = string.Empty;
            Description = string.Empty;
        }
    }
}
