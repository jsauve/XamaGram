﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Instagram.Models.Responses {
    public class TagResponse : IResponse {
        public Meta Meta { get; set; }
        public Tag Data { get; set; }
    }
}