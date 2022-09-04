using System;
using System.Collections.Generic;
using System.Text;

namespace LeVanDinh12.Common.Req
{
    public class UpdateCategoryReq
    {
        public string oldName { get; set; }
        public string newName { get; set; }
        public string Description { get; set; }
    }
}
