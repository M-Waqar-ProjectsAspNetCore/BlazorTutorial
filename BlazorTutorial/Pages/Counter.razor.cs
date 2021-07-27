using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTutorial.Pages
{
    public partial class Counter
    {
        private int currentCount { get; set; } = 0;
        private void IncrementCount()
        {
            currentCount++;
        }
        private void DecrementCount()
        {
            currentCount--;
        }
        private void Reset()
        {
            currentCount = 0;
        }
    }
}
