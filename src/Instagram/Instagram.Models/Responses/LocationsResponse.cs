using System.Collections.Generic;

namespace Instagram.Models.Responses {
    public class LocationsResponse : IInstagramResponse {
        public Meta Meta { get; set; }
        public List<Location> Data { get; set; }
    }
}
