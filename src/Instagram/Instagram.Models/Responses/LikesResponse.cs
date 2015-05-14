
namespace Instagram.Models.Responses {
    public class LikesResponse : IInstagramResponse {
        public Meta Meta { get; set; }
        public string Data { get; set; }
    }
}
