using System.Collections.Generic;

namespace Instagram.Models.Responses {
    public class TagsResponse : IInstagramResponse {
        public Meta Meta { get; set; }
        public List<Tag> Data { get; set; }
    }
}
