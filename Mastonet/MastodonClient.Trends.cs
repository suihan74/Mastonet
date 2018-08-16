using Mastonet.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mastonet
{
    partial class MastodonClient
    {
        /// <summary>
        /// Retrieving trending hashtags
        /// </summary>
        /// <param name="statusId"></param>
        /// <returns>Returns a Status</returns>
        public Task<MastodonList<Tag>> GetTrends()
        {
            return GetList<Tag>($"/api/v1/trends");
        }
    }
}
