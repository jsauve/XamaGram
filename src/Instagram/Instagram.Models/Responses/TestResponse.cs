using System.Collections.Generic;

namespace Instagram.Models.Responses {
    public class TestResponse {
        public Pagination Pagination { get; set; }
        public Meta Meta { get; set; }
        public List<Media> Data { get; set; }   
    }
}
