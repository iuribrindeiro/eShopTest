using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShopTest.Presentation.ObjectResponses
{
    public class UnprocessableErrorResponse
    {
        public Dictionary<string, string[]> Errors { get; set; }
    }
}
