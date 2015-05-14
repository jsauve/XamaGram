
namespace Instagram.Models.Responses {
    public class TagResponse : IInstagramResponse {
        public Meta Meta { get; set; }
        public Tag Data { get; set; }
    }
}
