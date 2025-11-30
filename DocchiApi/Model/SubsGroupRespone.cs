using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DocchiApi.Model.SubsGroupRespone;

namespace DocchiApi.Model
{
    [Serializable]
    public class SubsGroupRespone
    {

        [JsonProperty("pageProps")]
        public PageProps pageProps { get; set; }

        [JsonProperty("__N_SSP")]
        public bool __N_SSP { get; set; }
        [Serializable]
        public class AnimeDATA
        {
            [JsonProperty("title")]
            public string title { get; set; }

            [JsonProperty("title_en")]
            public string title_en { get; set; }

            [JsonProperty("slug")]
            public string slug { get; set; }

            [JsonProperty("adult_content")]
            public string adult_content { get; set; }

            [JsonProperty("cover")]
            public string cover { get; set; }
        }
        [Serializable]
        public class Datum
        {
            [JsonProperty("anime_ID")]
            public string anime_ID { get; set; }

            [JsonProperty("anime_DATA")]
            public AnimeDATA anime_DATA { get; set; }
        }

        public class Episode
        {
            [JsonProperty("id")]
            public int id { get; set; }

            [JsonProperty("anime_id")]
            public string anime_id { get; set; }

            [JsonProperty("anime_episode_number")]
            public int anime_episode_number { get; set; }

            [JsonProperty("player")]
            public string player { get; set; }

            [JsonProperty("player_hosting")]
            public string player_hosting { get; set; }

            [JsonProperty("created_at")]
            public DateTime created_at { get; set; }

            [JsonProperty("translator")]
            public string translator { get; set; }

            [JsonProperty("translator_title")]
            public string translator_title { get; set; }

            [JsonProperty("translator_url")]
            public string translator_url { get; set; }

            [JsonProperty("bg")]
            public object bg { get; set; }

            [JsonProperty("cover")]
            public string cover { get; set; }

            [JsonProperty("title_en")]
            public string title_en { get; set; }

            [JsonProperty("title")]
            public string title { get; set; }

            [JsonProperty("adult_content")]
            public string adult_content { get; set; }
        }
        [Serializable]
        public class GroupData
        {
            [JsonProperty("group_DATA")]
            public GroupDATA2 group_DATA { get; set; }

            [JsonProperty("data")]
            public List<Datum> data { get; set; }
        }
        [Serializable]
        public class GroupDATA2
        {
            [JsonProperty("name")]
            public string name { get; set; }

            [JsonProperty("avatar")]
            public string avatar { get; set; }

            [JsonProperty("banner")]
            public string banner { get; set; }

            [JsonProperty("description")]
            public string description { get; set; }

            [JsonProperty("media")]
            public List<Medium> media { get; set; }
        }
        [Serializable]
        public class Medium
        {
            [JsonProperty("name")]
            public string name { get; set; }

            [JsonProperty("url")]
            public string url { get; set; }
        }
        [Serializable]
        public class PageProps
        {
            [JsonProperty("group_id")]
            public string group_id { get; set; }

            [JsonProperty("group_data")]
            public GroupData group_data { get; set; }

            [JsonProperty("episodes")]
            public List<Episode> episodes { get; set; }

            [JsonProperty("device")]
            public bool device { get; set; }
        }
    }
}
