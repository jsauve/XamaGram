using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Instagram.Models.Responses {
    public class TagsResponse : IResponse {
        public Meta Meta { get; set; }
        public List<Tag> Data { get; set; }
    }
}
