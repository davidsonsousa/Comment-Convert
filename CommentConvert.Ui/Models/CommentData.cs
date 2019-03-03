using Newtonsoft.Json;

namespace CommentConvert.Ui.Models
{
    public sealed class CommentData : BaseObject
    {
        [JsonProperty(PropertyName = "created_time")]
        public string CreatedTime { get; set; }

        public Commenter From { get; set; }
        public string Message { get; set; }
    }
}
