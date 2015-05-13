using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Instagram.Models.Responses {
    public class UserResponse : IResponse {
        public Meta Meta { get; set; }
        public User Data { get; set; }
    }
}
