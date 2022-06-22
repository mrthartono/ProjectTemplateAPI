using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MrtProjectTemplate.Models.Shared
{
    public class HttpCommonResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } 
        private int _code { get; set; }
        public int Code
        {
            get
            {
                if (IsSuccess)
                    return (int)HttpStatusCode.OK;
                else
                    return _code;
            }
            set { _code = value; }
        }
    }
}
