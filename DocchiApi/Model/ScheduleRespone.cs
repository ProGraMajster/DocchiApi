using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DocchiApi.Model.PLMainSiteRespone;

namespace DocchiApi.Model
{
    [Serializable]
    public class ScheduleRespone
    {
        [JsonProperty("pageProps")]
        public PageProps pageProps { get; set; }

        [JsonProperty("__N_SSP")]
        public bool __N_SSP { get; set; }
        [Serializable]
        public class PageProps
        {
            [JsonProperty("season")]
            public List<Season> season { get; set; }

            [JsonProperty("device")]
            public bool device { get; set; }
        }
        [Serializable]
        public class Season
        {
            [JsonProperty("mal_id")]
            public int mal_id { get; set; }

            [JsonProperty("ani_id")]
            public object ani_id { get; set; }

            [JsonProperty("title")]
            public string title { get; set; }

            [JsonProperty("title_en")]
            public string title_en { get; set; }

            [JsonProperty("slug")]
            public string slug { get; set; }

            [JsonProperty("cover")]
            public string cover { get; set; }

            [JsonProperty("broadcast_day")]
            public string broadcast_day { get; set; }

            [JsonProperty("aired_from")]
            public DateTime? aired_from { get; set; }

            [JsonProperty("episodes")]
            public int episodes { get; set; }

            [JsonProperty("season")]
            public string season { get; set; }

            [JsonProperty("season_year")]
            public int season_year { get; set; }
        }
    }
}
