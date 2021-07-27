using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTutorial.Pages
{
    public class ParentComponentBase : ComponentBase
    {
        protected string Color { get; set; } = "green";
        protected string Border { get; set; } = "border: 2px solid green;";
        public int Age { get; set; } = 100;
        protected long Counter { get; set; } = 0;
    }
}
