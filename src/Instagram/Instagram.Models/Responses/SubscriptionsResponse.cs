using System.Collections.Generic;

namespace Instagram.Models.Responses {
    public class SubscriptionsResponse : IInstagramResponse {

        public Meta Meta { get; set; }
        public List<Subscription> Data { get; set; }
    }
}
