using System;
using System.Collections.Generic;
using System.Text;

namespace LeVanDinh12.Common.Req
{
    [Serializable]
    public class CreateCategoryReq
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
