
namespace Instagram.Models.Responses {
    public class LocationResponse : IInstagramResponse {
        public Meta Meta { get; set; }
        public Location Data { get; set; }
    }
}
