
namespace Instagram.Models.Responses {
	public class UserResponse : IInstagramResponse {
        public Meta Meta { get; set; }
        public User Data { get; set; }
    }
}
