using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ReqresDataPlayground.Models
{
    public class ReqresAllUsersModel
    {

        [JsonProperty("page")]
        public long Page { get; set; }

        [JsonProperty("per_page")]
        public long PerPage { get; set; }

        [JsonProperty("total")]
        public long Total { get; set; }

        [JsonProperty("total_pages")]
        public long TotalPages { get; set; }

        [JsonProperty("data")]
        public List<UserModel>  Data { get; set; }

        [JsonProperty("support")]
        public SupportModel Support { get; set; }

    }
}
