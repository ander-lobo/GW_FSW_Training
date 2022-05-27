using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gcsb.Connect.Training.Tests.Builders
{
    public class HttpContextBuilder
    {
        public DefaultHttpContext HttpContext { get; set; }

        public static HttpContextBuilder New()
        {
            return new HttpContextBuilder
            {
                HttpContext = new DefaultHttpContext()
            };
        }

        public DefaultHttpContext Build()
        {
            return HttpContext;
        }
    }
}
