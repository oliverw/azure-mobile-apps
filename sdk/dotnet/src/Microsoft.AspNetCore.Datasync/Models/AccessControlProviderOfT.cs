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
    /// <typeparam name="TVersion">The type of the entity version property</typeparam>
    public class AccessControlProvider<TEntity, TVersion> : IAccessControlProvider<TEntity, TVersion> where TEntity : ITableData<TVersion>
    {
        /// <summary>
        /// Returns a LINQ <see cref="Where{T}"/> predicate to limit the data that the client can
        /// see.  Return null if you wish the client to see all data.
        /// </summary>
        /// <returns>A LINQ predicate.</returns>
        public virtual Expression<Func<TEntity, bool>> GetDataView()
            => null;

        /// <summary>
        /// Determines if the client is allowed to perform the <see cref="TableOperation"/> on
        /// the provided entity.
        /// </summary>
        /// <param name="operation">The <see cref="TableOperation"/> being requested.</param>
        /// <param name="entity">The entity being used.</param>
        /// <param name="token">A cancellation token</param>
        /// <returns>True if the operation is authorized.</returns>
        public virtual Task<bool> IsAuthorizedAsync(TableOperation operation, TEntity entity, CancellationToken token = default)
            => Task.FromResult(true);

        /// <summary>
        /// Updates the entity immediately prior to write operations with the data store to
        /// support the chosen access control rules.
        /// </summary>
        /// <param name="operation">The <see cref="TableOperation"/> being requested.</param>
        /// <param name="entity">The entity being used.</param>
        /// <param name="token">A cancellation token</param>
        public virtual Task PreCommitHookAsync(TableOperation operation, TEntity entity, CancellationToken token = default)
            => Task.CompletedTask;
    }
}
