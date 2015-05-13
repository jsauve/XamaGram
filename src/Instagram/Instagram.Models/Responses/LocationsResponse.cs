using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Instagram.Models.Responses {
    public class LocationsResponse : IResponse {
        public Meta Meta { get; set; }
        public List<Location> Data { get; set; }
    }
}
