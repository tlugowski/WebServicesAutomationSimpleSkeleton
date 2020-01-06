using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceTests.Models
{
    class PageServiceResponse
    {
        public string Location { get; set; }

        public float Degree { get; set; }

        public DateTime DateTime { get; set; }

        public bool Success { get; set; } = true;

        public string ErrorCode { get; set; }

        public string Message { get; set; }
    }
}
