﻿// Copyright (c) Microsoft Corporation. All Rights Reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Net.Http.Headers;

namespace Microsoft.AspNetCore.Datasync.Extensions
{
    internal static class ITableDataExtensions
    {
        /// <summary>
        /// Returns the ETag header value for the entity.
        /// </summary>
        /// <param name="entity">The entity</param>
        /// <returns>The ETag</returns>
        internal static string GetETag<TVersion>(this ITableData<TVersion> entity)
            => HasValidVersion(entity) ? $"\"{Convert.ToBase64String(entity.Version)}\"" : null;

        /// <summary>
        /// Determines if the entity has a valid version.
        /// </summary>
        /// <param name="entity">The entity</param>
        /// <returns>True if the entities version is valid</returns>
        internal static bool HasValidVersion<TVersion>(this ITableData<TVersion> entity)
            => entity?.Version?.Length > 0;

        /// <summary>
        /// Returns the <see cref="EntityTagHeaderValue"/> for this entity, or null if invalid.
        /// </summary>
        /// <param name="entity">The entity</param>
        /// <returns>The <see cref="EntityTagHeaderValue"/></returns>
        internal static EntityTagHeaderValue ToEntityTagHeaderValue<TVersion>(this ITableData<TVersion> entity)
            => HasValidVersion(entity) ? new EntityTagHeaderValue(GetETag(entity)) : null;
    }
}
