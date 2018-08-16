﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Mastonet.Entities
{
    public class Account
    {
        /// <summary>
        /// The ID of the account
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        /// The username of the account
        /// </summary>
        [JsonProperty("username")]
        public string UserName { get; set; }

        /// <summary>
        /// Equals username for local users, includes @domain for remote ones
        /// </summary>
        [JsonProperty("acct")]
        public string AccountName { get; set; }

        /// <summary>
        /// The account's display name
        /// </summary>
        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        /// <summary>
        /// Boolean for when the account cannot be followed without waiting for approval first
        /// </summary>
        [JsonProperty("locked")]
        public bool Locked { get; set; }

        /// <summary>
        /// The time the account was created
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// The number of followers for the account
        /// </summary>
        [JsonProperty("followers_count")]
        public int FollowersCount { get; set; }

        /// <summary>
        /// The number of accounts the given account is following
        /// </summary>
        [JsonProperty("following_count")]
        public int FollowingCount { get; set; }

        /// <summary>
        /// The number of statuses the account has made
        /// </summary>
        [JsonProperty("statuses_count")]
        public int StatusesCount { get; set; }
        
        /// <summary>
        /// Biography of user
        /// </summary>
        [JsonProperty("note")]
        public string Note { get; set; }

        /// <summary>
        /// URL of the user's profile page (can be remote)
        /// </summary>
        [JsonProperty("url")]
        public string ProfileUrl { get; set; }

        /// <summary>
        /// URL to the avatar image
        /// </summary>
        [JsonProperty("avatar")]
        public string AvatarUrl { get; set; }

        /// <summary>
        /// URL to the avatar static image (gif)
        /// </summary>
        [JsonProperty("avatar_static")]
        public string StaticAvatarUrl { get; set; }

        /// <summary>
        /// URL to the header image
        /// </summary>
        [JsonProperty("header")]
        public string HeaderUrl { get; set; }

        /// <summary>
        /// URL to the header image
        /// </summary>
        [JsonProperty("header_static")]
        public string StaticHeaderUrl { get; set; }

        /// <summary>
        /// Array of Emoji in account username and note
        /// </summary>
        [JsonProperty("emojis")]
        public IEnumerable<Emoji> Emojis { get; set; }

        /// <summary>
        /// If the owner decided to switch accounts, new account is in this attribute
        /// </summary>
        [JsonProperty("moved")]
        public Account Moved { get; set; }

        /// <summary>
        /// Array of profile metadata field, each element has 'name' and 'value'
        /// </summary>
        [JsonProperty("fields")]
        public IEnumerable<Field> Fields { get; set; }

        /// <summary>
        /// Boolean to indicate that the account performs automated actions
        /// </summary>
        [JsonProperty("bot")]
        public bool? Bot { get; set; }
    }

    /// <summary>
    /// profile metadata field
    /// </summary>
    public class Field
    {
        [JsonProperty("name")]
        string Name { get; set; }

        [JsonProperty("value")]
        string Value { get; set; }
    }
}
