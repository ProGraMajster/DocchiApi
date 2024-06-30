﻿namespace DocchiApi.Model
{
    [Serializable]
    public class Series
    {
        public int id { get; set; }
        public int mal_id { get; set; }
        public object ani_id { get; set; }
        public string adult_content { get; set; }
        public string title { get; set; }
        public string title_en { get; set; }
        public string slug { get; set; }
        public string description { get; set; }
        public string cover { get; set; }
        public object bg { get; set; }
        public List<string> genres { get; set; }
        public string broadcast_day { get; set; }
        public DateTime aired_from { get; set; }
        public int episodes { get; set; }
        public string season { get; set; }
        public int season_year { get; set; }
        public string series_type { get; set; }
        public object ads { get; set; }
        public object modified { get; set; }
    }
}
