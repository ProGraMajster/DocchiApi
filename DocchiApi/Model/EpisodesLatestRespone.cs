using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocchiApi.Model
{
    [Serializable]
    public class EpisodesLatestRespone
    {
        public int anime_episode_number { get; set; }
        public string translator_title { get; set; }
        public string anime_id { get; set; }
        public string cover { get; set; }
        public string title_en { get; set; }
        public string title { get; set; }
        public string adult_content { get; set; }
    }
}
