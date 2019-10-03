using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ijobs.client.Models
{
    public class Jobs
    {
        public string id { get; set; }
        public string title { get; set; }
        public string company_name { get; set; }
        public string location { get; set; }
        public string created_date { get; set; }
        public string description { get; set; }
        public string redirect_url { get; set; }
    }
}
