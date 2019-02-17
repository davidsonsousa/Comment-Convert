using Newtonsoft.Json;
using System.Collections.Generic;

namespace CommentConvert.Ui.Models
{
    public sealed class Comment
    {
        [JsonProperty(PropertyName = "data")]
        public IEnumerable<CommentData> CommentList { get; set; }

        //TODO: Implement paging if necessary
    }
}
