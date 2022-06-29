using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketsRemoval.API.DTOs
{
    public class Request
    {
        public string OriginalText { get; set; }

        public DateTimeOffset Timestamp { get; set; }
    }
}
