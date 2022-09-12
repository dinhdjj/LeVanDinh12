using System;
using System.Collections.Generic;
using System.Text;

namespace LeVanDinh12.Common.Req
{
    public class UpdatePostReq
    {
        public string oldTitle { get; set; }
        public string newTitle { get; set; }

        public string oldBody { get; set; }
        public string newBody { get; set; }
        public string oldMainImageURL { get; set; }
        public string newMainImageURL { get; set; }
       
    }
}