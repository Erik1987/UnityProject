using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using UnityEngine;

public class TwitterApiProvider : MonoBehaviour
{
    // Start is called before the first frame update
    private string ApiKey = "nZJFcdO72uchXDap5ColyQh5m";

    // apie keys deleted
    private HttpClient client;
    public static List<Tweets> publicTweets;
    public static bool canNextTweetBeShown = true;

    private void Start()
    {
        //publicTweets = GetTweets();
    }

    private List<Tweets> GetTweets()
    {
        DateTime date = DateTime.Now;
        client = new HttpClient();
        client.BaseAddress = new Uri($"https://api.twitter.com/1.1/statuses/user_timeline.json?screen_name=Dadsaysjokes&count=1000");
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        var response = client.GetAsync("").Result;
        var responseJson = response.Content.ReadAsStringAsync().Result;
        var tweets = JsonConvert.DeserializeObject<List<Tweets>>(responseJson).Where(s => !s.text.Contains("https:") && s.text.Length < 100);

        return tweets.ToList();
    }

    [Serializable]
    public class Tweets
    {
        public string created_at;
        public long id;
        public string id_str;
        public string text;
        public bool truncated;
        public Entities entities;
        public string source;
        public long? in_reply_to_status_id;
        public string in_reply_to_status_id_str;
        public float? in_reply_to_user_id;
        public string in_reply_to_user_id_str;
        public string in_reply_to_screen_name;
        public User user;
        public object geo;
        public object coordinates;
        public object place;
        public object contributors;
        public bool is_quote_status;
        public long quoted_status_id;
        public string quoted_status_id_str;
        public Quoted_Status quoted_status;
        public float retweet_count;
        public float favorite_count;
        public bool favorited;
        public bool retweeted;
        public bool possibly_sensitive;
        public string lang;
    }

    [Serializable]
    public class Entities
    {
        public object[] hashtags;
        public object[] symbols;
        public object[] user_mentions;
        public Url[] urls;
    }

    [Serializable]
    public class Url
    {
        public string url;
        public string expanded_url;
        public string display_url;
        public float[] indices;
    }

    [Serializable]
    public class User
    {
        public float id;
        public string id_str;
        public string name;
        public string screen_name;
        public string location;
        public string description;
        public string url;
        public Entities1 entities;
        public bool _protected;
        public float followers_count;
        public float friends_count;
        public float listed_count;
        public string created_at;
        public float favourites_count;
        public object utc_offset;
        public object time_zone;
        public bool geo_enabled;
        public bool verified;
        public float statuses_count;
        public object lang;
        public bool contributors_enabled;
        public bool is_translator;
        public bool is_translation_enabled;
        public string profile_background_color;
        public string profile_background_image_url;
        public string profile_background_image_url_https;
        public bool profile_background_tile;
        public string profile_image_url;
        public string profile_image_url_https;
        public string profile_banner_url;
        public string profile_link_color;
        public string profile_sidebar_border_color;
        public string profile_sidebar_fill_color;
        public string profile_text_color;
        public bool profile_use_background_image;
        public bool has_extended_profile;
        public bool default_profile;
        public bool default_profile_image;
        public object following;
        public object follow_request_sent;
        public object notifications;
        public string translator_type;
    }

    [Serializable]
    public class Entities1
    {
        public Url1 url;
        public Description description;
    }

    [Serializable]
    public class Url1
    {
        public Url2[] urls;
    }

    [Serializable]
    public class Url2
    {
        public string url;
        public string expanded_url;
        public string display_url;
        public float[] indices;
    }

    [Serializable]
    public class Description
    {
        public object[] urls;
    }

    [Serializable]
    public class Quoted_Status
    {
        public string created_at;
        public long id;
        public string id_str;
        public string text;
        public bool truncated;
        public Entities2 entities;
        public string source;
        public object in_reply_to_status_id;
        public object in_reply_to_status_id_str;
        public object in_reply_to_user_id;
        public object in_reply_to_user_id_str;
        public object in_reply_to_screen_name;
        public User1 user;
        public object geo;
        public object coordinates;
        public object place;
        public object contributors;
        public bool is_quote_status;
        public float retweet_count;
        public float favorite_count;
        public bool favorited;
        public bool retweeted;
        public bool possibly_sensitive;
        public string lang;
    }

    [Serializable]
    public class Entities2
    {
        public object[] hashtags;
        public object[] symbols;
        public object[] user_mentions;
        public Url3[] urls;
    }

    [Serializable]
    public class Url3
    {
        public string url;
        public string expanded_url;
        public string display_url;
        public float[] indices;
    }

    [Serializable]
    public class User1
    {
        public long id;
        public string id_str;
        public string name;
        public string screen_name;
        public string location;
        public string description;
        public string url;
        public Entities3 entities;
        public bool _protected;
        public float followers_count;
        public float friends_count;
        public float listed_count;
        public string created_at;
        public float favourites_count;
        public object utc_offset;
        public object time_zone;
        public bool geo_enabled;
        public bool verified;
        public float statuses_count;
        public object lang;
        public bool contributors_enabled;
        public bool is_translator;
        public bool is_translation_enabled;
        public string profile_background_color;
        public string profile_background_image_url;
        public string profile_background_image_url_https;
        public bool profile_background_tile;
        public string profile_image_url;
        public string profile_image_url_https;
        public string profile_banner_url;
        public string profile_link_color;
        public string profile_sidebar_border_color;
        public string profile_sidebar_fill_color;
        public string profile_text_color;
        public bool profile_use_background_image;
        public bool has_extended_profile;
        public bool default_profile;
        public bool default_profile_image;
        public object following;
        public object follow_request_sent;
        public object notifications;
        public string translator_type;
    }

    [Serializable]
    public class Entities3
    {
        public Url4 url;
        public Description1 description;
    }

    [Serializable]
    public class Url4
    {
        public Url5[] urls;
    }

    [Serializable]
    public class Url5
    {
        public string url;
        public string expanded_url;
        public string display_url;
        public float[] indices;
    }

    [Serializable]
    public class Description1
    {
        public object[] urls;
    }
}
