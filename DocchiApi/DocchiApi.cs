using DocchiApi.Model;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace DocchiApi
{
    public static class DocchiApi
    {
        public static class Setttings
        {
            /// <summary>
            ///  1 = Minute
            /// </summary>
            public static int RefreshCechePreSeriesList = 60;
        }

        static List<PreSeries> CachePreSeriesList;
        static DateTime DateTimeCachePreSeriesList;

        public async static Task<List<PreSeries>> GetCechePreSeriesList()
        {
            if (CachePreSeriesList == null)
            {
                CachePreSeriesList = new List<PreSeries>();
            }
            if (CachePreSeriesList.Count <= 0)
            {
                CachePreSeriesList = await GetsAllSeries();
            }

            if (DateTime.UtcNow > DateTimeCachePreSeriesList.AddMinutes(Setttings.RefreshCechePreSeriesList))
            {
                CachePreSeriesList = await GetsAllSeries();
            }

            return CachePreSeriesList;
        }


        public async static Task<Model.SeriesRandomRespone> GetSeriesRandom(bool IgnoreAdult = true)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");
                    httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
                    httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/85.0.4183.102 Safari/537.36");
                    if(IgnoreAdult)
                    {
                        httpClient.BaseAddress = new Uri("https://api.docchi.pl/v1/series/random?ignore=adult");
                        var response = await httpClient.GetAsync("https://api.docchi.pl/v1/series/random?ignore=adult");
                        response.EnsureSuccessStatusCode();
                        var html = await response.Content.ReadAsStringAsync();
                        var r = System.Text.Json.JsonSerializer.Deserialize<Model.SeriesRandomRespone>(html);
                        return r;
                    }
                    else
                    {
                        httpClient.BaseAddress = new Uri("https://api.docchi.pl/v1/series/random");
                        var response = await httpClient.GetAsync("https://api.docchi.pl/v1/series/random");
                        response.EnsureSuccessStatusCode();
                        var html = await response.Content.ReadAsStringAsync();
                        var r = System.Text.Json.JsonSerializer.Deserialize<Model.SeriesRandomRespone>(html);
                        return r;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                Console.WriteLine(ex.ToString());
            }
            return null;
        }

        public async static Task<Model.ScheduleRespone> GetSchedule()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://docchi.pl/_next/data/-IxF8zpPracN4qj0bsIJn/pl/schedule.json");
                httpClient.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/85.0.4183.102 Safari/537.36");

                try
                {
                    var response = await httpClient.GetAsync("https://docchi.pl/_next/data/-IxF8zpPracN4qj0bsIJn/pl/schedule.json");
                    response.EnsureSuccessStatusCode();
                    var html = await response.Content.ReadAsStringAsync();
                    var r = System.Text.Json.JsonSerializer.Deserialize<Model.ScheduleRespone>(html);
                    return r;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    Console.WriteLine(ex.ToString());
                    var rEx = await GetScheduleEx();
                    return rEx;
                }
            }
        }

        public async static Task<Model.ScheduleRespone> GetScheduleEx()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/85.0.4183.102 Safari/537.36");

                string url = await httpClient.GetStringAsync("https://raw.githubusercontent.com/ProGraMajster/DocchiApi/refs/heads/master/DocchiApi/UrlSchedule.txt");
                if(string.IsNullOrEmpty(url))
                {
                    return null;
                }


                try
                {
                    var response = await httpClient.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    var html = await response.Content.ReadAsStringAsync();
                    var r = System.Text.Json.JsonSerializer.Deserialize<Model.ScheduleRespone>(html);
                    return r;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    Console.WriteLine(ex.ToString());
                }
            }
            return null;
        }

        //https://docchi.pl/_next/data/-IxF8zpPracN4qj0bsIJn/pl/subs/group/Okami%20Subs.json?id=Okami+Subs

        public async static Task GetSubsGroup(string group_id)
        {

        }

        //https://docchi.pl/api/search/search?string=dar

        public async static Task<SearchRespone> GetSearchAsync(string search)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    AddHeaders(httpClient);
                    var response = await httpClient.GetAsync($"https://docchi.pl/api/search/search?string={search}");
                    response.EnsureSuccessStatusCode();
                    var html = await response.Content.ReadAsStringAsync();

                    var r = Newtonsoft.Json.JsonConvert.DeserializeObject<SearchRespone>(html);

                    return r;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Debug.WriteLine(ex.ToString());
            }
            return null;
        }

        public async static Task<List<PreSeries>> GetsAllSeries()
        {
            using (var httpClient = new HttpClient())
            {
                List<PreSeries> list = new List<PreSeries>();
                httpClient.BaseAddress = new Uri("https://api.docchi.pl/v1/series/list");

                //httpClient.DefaultRequestHeaders.Add("Referer", $"https://ebd.cda.pl/620x395/{id}");
                httpClient.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/85.0.4183.102 Safari/537.36");

                try
                {
                    var response = await httpClient.GetAsync("https://api.docchi.pl/v1/series/list");
                    response.EnsureSuccessStatusCode();
                    var html = await response.Content.ReadAsStringAsync();

                    list = System.Text.Json.JsonSerializer.Deserialize<List<PreSeries>>(html);
                    CachePreSeriesList = list;
                    DateTimeCachePreSeriesList = DateTime.UtcNow;
                    return list;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    Console.WriteLine(ex.ToString());
                }
            }
            return null;
        }
        public async static Task<List<PreSeries>> GetsAllSeries(int limit, int before)
        {
            using (var httpClient = new HttpClient())
            {
                List<PreSeries> list = new List<PreSeries>();
                httpClient.BaseAddress = new Uri("https://api.docchi.pl/v1/series/list");
                httpClient.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/85.0.4183.102 Safari/537.36");

                try
                {
                    var response = await httpClient.GetAsync($"https://api.docchi.pl/v1/series/list?limit={limit}&before={before}");
                    response.EnsureSuccessStatusCode();
                    var html = await response.Content.ReadAsStringAsync();
                    list = System.Text.Json.JsonSerializer.Deserialize<List<PreSeries>>(html);
                    return list;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    Console.WriteLine(ex.ToString());
                }
            }
            return null;
        }

        private static void AddHeaders(HttpClient httpClient)
        {
            httpClient.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/85.0.4183.102 Safari/537.36");
        }

        public async static Task<Series> GetSeriesAsync(string slug)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    AddHeaders(httpClient);
                    var response = await httpClient.GetAsync($"https://api.docchi.pl/v1/series/find/{slug}");
                    response.EnsureSuccessStatusCode();
                    var html = await response.Content.ReadAsStringAsync();

                    var r = System.Text.Json.JsonSerializer.Deserialize<Series>(html);

                    return r;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Debug.WriteLine(ex.ToString());
            }
            return null;
        }

        public async static Task<List<SeriesRelated>> GetSeriesRelatedAsync(string title)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    AddHeaders(httpClient);
                    var response = await httpClient.GetAsync($"https://api.docchi.pl/v1/series/related/{title}");
                    response.EnsureSuccessStatusCode();
                    var html = await response.Content.ReadAsStringAsync();

                    var r = System.Text.Json.JsonSerializer.Deserialize<List<SeriesRelated>>(html);

                    return r;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Debug.WriteLine(ex.ToString());
            }
            return null;
        }

        public async static Task<List<EpisodesSeries>> GetsListOfHowMuchEpisodesSeriesContains(string slug)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    AddHeaders(httpClient);
                    var response = await httpClient.GetAsync($"https://api.docchi.pl/v1/episodes/count/{slug}");
                    response.EnsureSuccessStatusCode();
                    var html = await response.Content.ReadAsStringAsync();

                    var r = System.Text.Json.JsonSerializer.Deserialize<List<EpisodesSeries>>(html);

                    return r;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Debug.WriteLine(ex.ToString());
            }
            return null;
        }

        public async static Task<List<PlayersForEpisode>> GetsListOfPlayersForEpisode(string slug, int number)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    AddHeaders(httpClient);
                    var response = await httpClient.GetAsync($"https://api.docchi.pl/v1/episodes/find/{slug}/{number}");
                    response.EnsureSuccessStatusCode();
                    var html = await response.Content.ReadAsStringAsync();

                    var r = System.Text.Json.JsonSerializer.Deserialize<List<PlayersForEpisode>>(html);

                    return r;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Debug.WriteLine(ex.ToString());
            }
            return null;
        }

        //https://api.docchi.pl/v1/series/category?name=Action&sort=undefine

        public async static Task<List<SeriesCategoryRespone>> GetSeriesFromCategoryAsync(string category)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    AddHeaders(httpClient);
                    var response = await httpClient.GetAsync($"https://api.docchi.pl/v1/series/category?name={category}");
                    response.EnsureSuccessStatusCode();
                    var html = await response.Content.ReadAsStringAsync();

                    List<SeriesCategoryRespone> r = Newtonsoft.Json.JsonConvert.DeserializeObject<List<SeriesCategoryRespone>>(html);

                    return r;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Debug.WriteLine(ex.ToString());
            }
            return null;
        }
            

        public async static Task<List<Stats>> GetStatsAsync(string slug)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    AddHeaders(httpClient);
                    var response = await httpClient.GetAsync($"https://api.docchi.pl/v1/series/animelist/stats/{slug}");
                    response.EnsureSuccessStatusCode();
                    var html = await response.Content.ReadAsStringAsync();

                    List<Stats> stat = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Stats>>(html);

                    return stat;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Debug.WriteLine(ex.ToString());
            }
            return null;
        }



        public async static Task<string> GetMainSite()
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    AddHeaders(httpClient);
                    var response = await httpClient.GetAsync($"https://docchi.pl");
                    response.EnsureSuccessStatusCode();
                    var html = await response.Content.ReadAsStringAsync();
                    return html;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Debug.WriteLine(ex.ToString());
            }
            return null;
        }

        public async static Task<PLMainSiteRespone> GetPLMainSite()
        {
            try
            {
            //
                using (var httpClient = new HttpClient())
                {
                    AddHeaders(httpClient);
                    var respone = await httpClient.GetAsync("https://docchi.pl/_next/data/kRFLVp6cgUjS1Asr_PHWb/pl.json");
                    respone.EnsureSuccessStatusCode();
                    var html = await respone.Content.ReadAsStringAsync();

                    var plmainsiterespone = Newtonsoft.Json.JsonConvert.DeserializeObject<PLMainSiteRespone>(html);
                    return plmainsiterespone;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Debug.WriteLine(ex.ToString());
            }
            return null;
        }

    }
}
