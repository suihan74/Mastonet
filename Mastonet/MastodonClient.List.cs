using Mastonet.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Mastonet
{
    partial class MastodonClient
    {
        /// <summary>
        /// Retrieving lists
        /// </summary>
        /// <returns>Returns at most 50 Lists without pagination.</returns>
        public Task<MastodonList<List>> GetLists()
        {
            return this.GetList<List>("/api/v1/lists");
        }

        /// <summary>
        /// Retrieving lists by membership
        /// </summary>
        /// <param name="listId"></param>
        /// <returns>Returns at most 50 Lists without pagination</returns>
        public Task<MastodonList<List>> GetLists(long accountId)
        {
            return this.GetList<List>($"/api/v1/accounts/{accountId}/lists");
        }

        /// <summary>
        /// Retrieving accounts in a list
        /// </summary>
        /// <param name="listId"></param>
        /// <returns>Returns Accounts in the list. If you specify limit=0 in the query, all accounts will be returned without pagination. Otherwise, standard account pagination rules apply.</returns>
        public Task<MastodonList<Account>> GetListMembers(long listId, long? limit = null)
        {
            var url = $"/api/v1/lists/{listId}/accounts?limit=" + (limit ?? 0);
            return this.GetList<Account>(url);
        }

        /// <summary>
        /// Retrieving a list
        /// </summary>
        /// <param name="listId"></param>
        /// <returns>Returns the specified List</returns>
        public Task<List> GetList(long listId)
        {
            return this.Get<List>($"/api/v1/lists/{listId}");
        }

        /// <summary>
        /// Creating and updating a list
        /// </summary>
        /// <param name="title"></param>
        /// <returns>Returns a new or updated List</returns>
        public Task<List> CreateList(string title)
        {
            var data = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("title", title)
            };
            return this.Post<List>("/api/v1/lists", data);
        }

        /// <summary>
        /// Deleting a list
        /// </summary>
        /// <param name="listId"></param>
        public Task DeleteList(long listId)
        {
            return this.Delete($"/api/v1/lists/{listId}");
        }

        /// <summary>
        /// Adding accounts to a list
        /// </summary>
        /// <param name="listId">Only accounts already followed by the authenticated user can be added to a list</param>
        /// <param name="accountIds">Array of account IDs</param>
        public Task AddListMembers(long listId, IEnumerable<long> accountIds)
        {
            var data = new List<KeyValuePair<string, string>>();
            foreach (var accountId in accountIds)
            {
                data.Add(new KeyValuePair<string, string>("account_ids[]", accountId.ToString()));
            }
            return this.Post($"/api/v1/lists/{listId}/accounts", data);
        }

        /// <summary>
        /// Adding an account to a list
        /// </summary>
        /// <param name="listId">Only accounts already followed by the authenticated user can be added to a list</param>
        /// <param name="accountId">Array of account ID</param>
        public Task AddListMember(long listId, long accountId)
        {
            return AddListMembers(listId, new[] { accountId });
        }

        /// <summary>
        /// Removing accounts to a list
        /// </summary>
        /// <param name="listId">Only accounts already followed by the authenticated user can be removed from a list</param>
        /// <param name="accountIds">Array of account IDs</param>
        public Task RemoveListMembers(long listId, IEnumerable<long> accountIds)
        {
            var param = string.Join("&", accountIds.Select(id => $"account_ids[]={id}"));
            return this.Delete($"/api/v1/lists/{listId}/accounts?{param}");
        }

        /// <summary>
        /// Removing an account to a list
        /// </summary>
        /// <param name="listId">Only accounts already followed by the authenticated user can be removed from a list</param>
        /// <param name="accountId">Array of account ID</param>
        public Task RemoveListMember(long listId, long accountId)
        {
            return RemoveListMembers(listId, new[] { accountId });
        }
    }
}
