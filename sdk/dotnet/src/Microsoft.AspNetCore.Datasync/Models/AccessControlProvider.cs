// Copyright (c) Microsoft Corporation. All Rights Reserved.
// Licensed under the MIT License.

using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Datasync
{
    /// <summary>
    /// The default <see cref="IAccessControlProvider{TEntity}"/> implementation that allows the connecting
    /// client to do anything, but doesn't do anything extra.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity being processed.</typeparam>
    public class AccessControlProvider<TEntity> : AccessControlProvider<TEntity, byte[]> where TEntity : ITableData<byte[]>
    {
    }
}
