
namespace Instagram.Models.Responses {
	public class CommentResponse : IInstagramResponse {
        public Meta Meta { get; set; }
        public string Data { get; set; }
    }
}
