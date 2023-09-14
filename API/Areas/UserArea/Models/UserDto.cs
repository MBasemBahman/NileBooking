using Entities.CoreServicesModels.UserModels;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace API.Areas.UserArea.Models
{
    public class UserDto : UserModel
    {
        public int AccountCheckerEnum { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public new int Id { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public new string LastModifiedAt { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public new string LastModifiedBy { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public new string CreatedBy { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public new string CreatedAt { get; set; }
    }
}
