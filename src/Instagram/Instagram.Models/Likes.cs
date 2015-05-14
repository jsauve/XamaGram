using System.Collections.Generic;

namespace Instagram.Models {
    public class Likes {
        public int Count { get; set; }
        public List<UserInfo> Data { get; set; }
    }
}
