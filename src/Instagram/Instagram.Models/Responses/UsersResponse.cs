using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Instagram.Models.Responses {
    public class UsersResponse : IResponse {
        public Meta Meta { get; set; }
        public List<User> Data { get; set; }
    }
}
