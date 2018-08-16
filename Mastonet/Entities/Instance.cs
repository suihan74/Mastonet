using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mastonet.Entities
{
    public class Instance
    {
        /// <summary>
        /// URI of the current instance
        /// </summary>
        [JsonProperty("uri")]
        public string Uri { get; set; }

        /// <summary>
        /// The instance's title
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// A description for the instance
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// An email address which can be used to contact the instance administrator
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// The Mastodon version used by instance.
        /// </summary>
        [JsonProperty("version")]
        public string Version { get; set; }

        /// <summary>
        /// streaming_api
        /// </summary>
        [JsonProperty("urls")]
        public Dictionary<string, string> Urls { get; set; }

        /// <summary>
        /// Array of ISO 6391 language codes the instance has chosen to advertise
        /// </summary>
        [JsonProperty("languages")]
        public IEnumerable<string> Languages { get; set; }

        /// <summary>
        /// Account of the admin or another contact person
        /// </summary>
        [JsonProperty("contact_account")]
        public Account ContactAccount { get; set; }
    }
}
