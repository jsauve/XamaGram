using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Instagram.Models.Responses {
    public class LocationResponse : IResponse {
        public Meta Meta { get; set; }
        public Location Data { get; set; }
    }
}
