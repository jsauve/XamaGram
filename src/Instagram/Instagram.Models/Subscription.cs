
namespace Instagram.Models {
    public class Subscription {

        public int Id { get; set; }
        public string Type { get; set; }
        public string Object { get; set; }
        public string Aspect { get; set; }
        public string Callback_Url { get; set; }

    }
}
