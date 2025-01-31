﻿// Copyright (c) Microsoft Corporation. All Rights Reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Http;

namespace Microsoft.AspNetCore.Datasync.Extensions
{
    internal static class IQueryableExtensions
    {
        private const string IncludeDeletedParameter = "__includedeleted";
        private const string IncludeDeletedOption = "include:deleted";
        private const string ZumoOptionsHeader = "X-ZUMO-Options";

        /// <summary>
        /// Applies an optional data view to the query.
        /// </summary>
        /// <typeparam name="T">The type of entity</typeparam>
        /// <typeparam name="TVersion"></typeparam>
        /// <param name="query">The current query</param>
        /// <param name="predicate"></param>
        /// <returns>The modified query</returns>
        internal static IQueryable<T> ApplyDataView<T, TVersion>(this IQueryable<T> query, Expression<Func<T, bool>> predicate) where T : ITableData<TVersion>
            => predicate != null ? query.Where(predicate) : query;

        /// <summary>
        /// Applies the Deleted filter if soft delete is enabled and the request does not include a request to include
        /// deleted items.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TVersion"></typeparam>
        /// <param name="query"></param>
        /// <param name="request"></param>
        /// <param name="softDelete"></param>
        /// <returns></returns>
        internal static IQueryable<T> ApplyDeletedView<T, TVersion>(this IQueryable<T> query, HttpRequest request, bool softDelete) where T : ITableData<TVersion>
        {
            if (!softDelete)
            {
                return query;
            }

            // Query string options: __includedeleted=true
            if (request.Query.ContainsKey(IncludeDeletedParameter) && request.Query[IncludeDeletedParameter][0].Equals("true", StringComparison.InvariantCultureIgnoreCase))
            {
                return query;
            }

            // Header option: X-ZUMO-Options: __includedeleted
            if (request.Headers.ContainsKey(ZumoOptionsHeader) && request.Headers[ZumoOptionsHeader].Contains(IncludeDeletedOption, StringComparer.InvariantCultureIgnoreCase))
            {
                return query;
            }

            return query.Where(m => !m.Deleted);
        }
    }
}
