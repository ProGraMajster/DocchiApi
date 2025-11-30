using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocchiApi.Model
{
    [Serializable]
    public class PLMainSiteRespone
    {
        public PageProps pageProps { get; set; }
        public bool __N_SSP { get; set; }

        [Serializable]
        public class Comment
        {
            public string nickname { get; set; }
            public string avatar { get; set; }
            public List<string> badges { get; set; }
            public int? id { get; set; }
            public int? xid { get; set; }
            public Sender sender { get; set; }
            public string message { get; set; }
            public string location { get; set; }
            public string location_type { get; set; }
            public string sub_location { get; set; }
            public string spoiler { get; set; }
            public DateTime created_at { get; set; }
        }

        [Serializable]
        public class Community
        {
            public int id { get; set; }
            public int xid { get; set; }
            public string title { get; set; }
            public string message { get; set; }
            public string hashtag { get; set; }
            public string slug { get; set; }
            public object image { get; set; }
            public DateTime created_at { get; set; }
            public string nickname { get; set; }
            public string avatar { get; set; }
            public List<string> badges { get; set; }
            public int? comments_number { get; set; }
        }

        [Serializable]
        public class Emitted
        {
            public int? anime_episode_number { get; set; }
            public string translator_title { get; set; }
            public string anime_id { get; set; }
            public string cover { get; set; }
            public string title_en { get; set; }
            public string title { get; set; }
            public string adult_content { get; set; }
        }

        [Serializable]
        public class Group
        {
            public string subs_name { get; set; }
            public string subs_avatar { get; set; }
        }

        [Serializable]
        public class PageProps
        {
            [JsonProperty("trending")]
            public List<Trending> trending { get; set; }

            [JsonProperty("season")]
            public List<Season> season { get; set; }

            [JsonProperty("emitted")]
            public List<Emitted> emitted { get; set; }

            [JsonProperty("groups")]
            public List<Group> groups { get; set; }

            [JsonProperty("comments")]
            public List<Comment> comments { get; set; }

            [JsonProperty("series")]
            public List<Series> series { get; set; }

            [JsonProperty("community")]
            public List<Community> community { get; set; }

            [JsonProperty("device")]
            public bool device { get; set; }
        }
        [Serializable]
        public class Season
        {
            public int? mal_id { get; set; }
            public object ani_id { get; set; }
            public string title { get; set; }
            public string title_en { get; set; }
            public string slug { get; set; }
            public string cover { get; set; }
            public string broadcast_day { get; set; }
            public DateTime? aired_from { get; set; }
            public int? episodes { get; set; }
            public string season { get; set; }
            public int? season_year { get; set; }
        }
        [Serializable]
        public class Sender
        {
            public string nickname { get; set; }
            public string avatar { get; set; }
        }
        [Serializable]
        public class Series
        {
            public int? mal_id { get; set; }
            public object ani_id { get; set; }
            public string title { get; set; }
            public string title_en { get; set; }
            public string slug { get; set; }
            public string cover { get; set; }
            public string adult_content { get; set; }
        }
        [Serializable]
        public class Trending
        {
            public int? id { get; set; }
            public string title { get; set; }
            public string title_en { get; set; }
            public string slug { get; set; }
            public string cover { get; set; }
        }
    }
}
