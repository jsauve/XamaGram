using System.Collections.Generic;

namespace Instagram.Models.Responses {
    public class UsersResponse : IInstagramResponse {
        public Meta Meta { get; set; }
        public List<User> Data { get; set; }
    }
}
