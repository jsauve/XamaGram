using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Instagram.Models {
    public class Likes {
        public int Count { get; set; }
        public List<UserInfo> Data { get; set; }
    }
}
