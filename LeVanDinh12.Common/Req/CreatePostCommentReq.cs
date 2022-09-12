using System;
using System.Collections.Generic;
using System.Text;

namespace LeVanDinh12.Common.Req
{
    public class CreatePostCommentReq
    {
        public string Content { get; set; }
        public long PostID { get; set; }

        public long AnonymousID { get; set; }



    }
}
