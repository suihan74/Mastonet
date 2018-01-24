﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mastonet.Entities
{
    public class Emoji
    {
        [JsonProperty("shortcode")]
        public string Shortcode { get; set; }

        [JsonProperty("static_url")]
        public string StaticUrl { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
