using Newtonsoft.Json;
using System;

namespace Instagram.Models {
    public class UserInfo {
        public string Id { get; set; }
        public string Username { get; set; }
		[JsonProperty("last_name")]
		public string LastName { get; set; }
		[JsonProperty("first_name")]
		public string FirstName { get; set; }
        [JsonProperty("profile_picture")]
        public string ProfilePicture { get; set; }
    }
}
