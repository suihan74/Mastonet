using Mastonet.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Mastonet
{
    partial class MastodonClient
    {
        /// <summary>
        /// Fetching a list of filters
        /// </summary>
        /// <returns>Returns an array of Filters</returns>
        public Task<MastodonList<Filter>> GetFilters()
        {
            return GetList<Filter>("/api/v1/filters");
        }

        /// <summary>
        /// Making parameters for updating filters
        /// </summary>
        /// <param name="phrase"></param>
        /// <param name="context"></param>
        /// <param name="irreversible"></param>
        /// <param name="wholeWord"></param>
        /// <param name="expiresIn"></param>
        private IEnumerable<KeyValuePair<string, string>> MakeParams(string phrase, IEnumerable<string> context, bool? irreversible = null, bool? wholeWord = null, TimeSpan? expiresIn = null)
        {
            var data = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("phrase", phrase),
            };
            foreach (var c in context)
            {
                data.Add(new KeyValuePair<string, string>("context[]", c));
            }

            if (irreversible is bool ir) data.Add(new KeyValuePair<string, string>("irreversible", ir.ToString().ToLower()));
            if (wholeWord is bool ww) data.Add(new KeyValuePair<string, string>("whole_words", ww.ToString().ToLower()));
            if (expiresIn is TimeSpan ei) data.Add(new KeyValuePair<string, string>("expires_in", ei.TotalSeconds.ToString()));

            return data;
        }

        /// <summary>
        /// Creating a filter
        /// </summary>
        /// <param name="phrase"></param>
        /// <param name="context"></param>
        /// <param name="irreversible"></param>
        /// <param name="wholeWord"></param>
        /// <param name="expiresIn"></param>
        /// <returns>Returns a Filter</returns>
        public Task<Filter> CreateFilter(string phrase, IEnumerable<string> context, bool? irreversible = null, bool? wholeWord = null, TimeSpan? expiresIn = null)
        {
            var data = MakeParams(phrase, context, irreversible, wholeWord, expiresIn);
            return Post<Filter>("/api/v1/filters", data);
        }

        /// <summary>
        /// Get a filter
        /// </summary>
        /// <returns>Returns a Filter</returns>
        public Task<Filter> GetFilter(long id)
        {
            return Get<Filter>($"/api/v1/filters/{id}");
        }

        /// <summary>
        /// Update a filter
        /// </summary>
        /// <param name="phrase"></param>
        /// <param name="context"></param>
        /// <param name="irreversible"></param>
        /// <param name="wholeWord"></param>
        /// <param name="expiresIn"></param>
        /// <returns>Returns a Filter</returns>
        public Task<Filter> UpdateFilter(long id, string phrase, IEnumerable<string> context, bool? irreversible = null, bool? wholeWord = null, TimeSpan? expiresIn = null)
        {
            var data = MakeParams(phrase, context, irreversible, wholeWord, expiresIn);
            return Put<Filter>($"api/v1/filters/{id}", data);
        }

        /// <summary>
        /// Update a filter
        /// </summary>
        /// <param name="filter"></param>
        /// <returns>Returns a Filter</returns>
        public Task<Filter> UpdateFilter(Filter filter)
        {
            TimeSpan? expiresIn = null;
            if (filter.ExpiresAt > DateTime.Now)
            {
                expiresIn = filter.ExpiresAt - DateTime.Now;
            }

            return UpdateFilter(filter.Id, filter.Phrase, filter.Context, filter.Irreversible, filter.WholeWord, expiresIn);
        }

        /// <summary>
        /// Delete a filter
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task DeleteFilter(long id)
        {
            return Delete($"/api/v1/filters/{id}");
        }

        public Task DeleteFilter(Filter filter)
        {
            return DeleteFilter(filter.Id);
        }
    }
}
