using System;
using System.Collections.Generic;
using System.Text;

namespace LeVanDinh12.Common.Req
{
    [Serializable]
    public class CreatePostReq
    {
        public string Title { get; set; }
        public string Body { get; set; }

        public string MainImageURL { get; set; }

        public string UserToken { get; set; }

        public long[] CategoryIds  { get; set; }



    }
}
