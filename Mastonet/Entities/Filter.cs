using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mastonet.Entities
{
    public class Filter
    {
        /// <summary>
        /// ID of the filter
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        /// Keyword or phrase
        /// </summary>
        [JsonProperty("phrase")]
        public string Phrase { get; set; }

        /// <summary>
        /// Array of strings that indicate filter context. each string is ont of 'home', 'notifications', 'public', 'thread'
        /// </summary>
        [JsonProperty("context")]
        public IEnumerable<string> Context { get; set; }

        /// <summary>
        /// String such as "2018-07-06T00:59:13.161Z" that indicates when this filter is expired.
        /// </summary>
        [JsonProperty("expires_at")]
        public DateTime ExpiresAt { get; set; }

        /// <summary>
        /// Boolean that indicates irreversible server side filtering.
        /// </summary>
        [JsonProperty("irreversible")]
        public bool Irreversible { get; set; }

        /// <summary>
        /// Boolean that indicates word match.
        /// <para>If whole_word is true , client app should do:</para>
        /// <para><list>
        /// <item>
        /// <term>></term>
        /// <description>
        /// Define 'Word constituent character' for your app.In official implementation, it's [A-Za-z0-9_] for JavaScript, it's[[:word:]] for Ruby.In Ruby case it's POSIX character class (Letter | Mark | Decimal_Number | Connector_Punctuation).
        /// </description>
        /// </item>
        /// <para>
        /// <item>
        /// <term>></term>
        /// <description>
        /// If the phrase starts with word character, and if the previous character before matched range is word character, its matched range should treat to not match.
        /// </description>
        /// </item>
        /// </para>
        /// <para>
        /// <item>
        /// <term>></term>
        /// <description>
        /// If the phrase ends with word character, and if the next character after matched range is word character, its matched range should treat to not match.
        /// </description>
        /// </item>
        /// </para>
        /// </list></para>
        /// </summary>
        [JsonProperty("whole_word")]
        public bool WholeWord { get; set; }
    }
}
