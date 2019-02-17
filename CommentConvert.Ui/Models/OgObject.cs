using Newtonsoft.Json;

namespace CommentConvert.Ui.Models
{
    public sealed class OgObject : BaseObject
    {
        [JsonProperty(PropertyName = "comments")]
        public Comment Comment { get; set; }
    }
}
