using System.Text.Json;
using System.Text.Json.Serialization;

namespace ContosoCrafts.WebSite.Models
{
    /// <summary>产品</summary>
    public class Product
    {
        /// <summary>ID</summary>
        public string Id { get; set; }

        /// <summary>制造者</summary>
        public string Maker { get; set; }

        /// <summary>图片</summary>
        [JsonPropertyName("img")]
        public string Image { get; set; }

        /// <summary>URL</summary>
        public string Url { get; set; }

        /// <summary>标题</summary>
        public string Title { get; set; }

        /// <summary>描述</summary>
        public string Description { get; set; }

        /// <summary>评级</summary>
        public int[] Ratings { get; set; }

        public override string ToString() => JsonSerializer.Serialize(this);
    }
}
