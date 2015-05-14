
namespace Instagram.Models.Responses {
    public class RelationshipResponse : IInstagramResponse {
        public Meta Meta { get; set; }
        public Relationship Data { get; set; }
    }
}
