using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Posting
{
    public class JsonPrettyLookingGood
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("supplierId")]
        public int SupplierId { get; set; }

        [JsonProperty("categoryId")]
        public int CategoryId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("quantityPerUnit")]
        public string QuantityPerUnit { get; set; }

        [JsonProperty("unitPrice")]
        public int UnitPrice { get; set; }
    }
}
