using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTutorial.Pages
{
    public class TwoWayDataBindingBase : ComponentBase
    {
        protected string Description { get; set; } = string.Empty;
        protected string Message { get; set; } = string.Empty;
        protected string Value { get; set; } = string.Empty;
    }
}
