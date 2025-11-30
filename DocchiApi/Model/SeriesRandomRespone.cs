using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocchiApi.Model
{
    [Serializable]
    public class SeriesRandomRespone
    {
        [JsonProperty("adult_content")]
        public string adult_content { get; set; }

        [JsonProperty("slug")]
        public string slug { get; set; }
    }
}
