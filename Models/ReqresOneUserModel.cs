using Newtonsoft.Json;

namespace ReqresDataPlayground.Models
{
    public partial class ReqresOneUserModel
    {

        public UserModel Data { get; set; }
        public SupportModel Support { get; set; }
    }


    public partial class UserModel {

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("email")]
        public string? Email { get; set; }

        [JsonProperty("first_name")]
        public string? FirstName { get; set; }

        [JsonProperty("last_name")]
        public string? LastName { get; set; }

        [JsonProperty("avatar")]
        public Uri? Avatar { get; set; }


        }

    public partial class SupportModel
    {
        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }



}

