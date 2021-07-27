using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTutorial.Pages
{
    public class DataBindingBase : ComponentBase
    {
        protected string Name { get; set; } = "Tom";

        protected string Color { get; set; } = "color: Red;";
    }
}
