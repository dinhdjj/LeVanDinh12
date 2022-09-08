using System;
using System.Collections.Generic;
using System.Text;

namespace LeVanDinh12.Common.Req
{
    public class UpdateFlowerCommentReq
    {
        public long Id { get; set; }
        public string Content { get; set; }
        public long FlowerId { get; set; }
        public long AnonymousId { get; set; }
    }
}
