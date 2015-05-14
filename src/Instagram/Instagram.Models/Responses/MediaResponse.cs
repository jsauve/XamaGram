
namespace Instagram.Models.Responses {
	public class MediaResponse : IInstagramResponse {
        public Pagination Pagination { get; set; }
        public Meta Meta { get; set; }
        public Media Data { get; set; }
    }
}
