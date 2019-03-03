using Newtonsoft.Json;

namespace CommentConvert.Ui.Models
{
    public sealed class FbComment : BaseObject
    {
        [JsonProperty(PropertyName = "og_object")]
        public OgObject OgObject { get; set; }
    }
}
