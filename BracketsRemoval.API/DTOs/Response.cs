using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketsRemoval.API.DTOs
{
    public class Response
    {
        public Request Request { get; set; }

        public string FixedText { get; set; }

        public int Status { get; set; }

        public string ErrorMessage  { get; set; }

        public DateTimeOffset Timestamp => DateTimeOffset.Now;
    }
}
