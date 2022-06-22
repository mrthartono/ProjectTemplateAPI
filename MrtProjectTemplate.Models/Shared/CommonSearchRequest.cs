using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrtProjectTemplate.Models.Shared
{
    public class CommonSearchRequest
    {
        public string search { get; set; }
        public string orderBy { get; set; }
        public string direction { get; set; }
        public int skip { get; set; }
        public int take { get; set; }

  
    }
}
