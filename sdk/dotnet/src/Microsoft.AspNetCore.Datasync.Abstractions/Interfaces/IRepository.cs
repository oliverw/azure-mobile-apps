// Copyright (c) Microsoft Corporation. All Rights Reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Datasync
{
    /// <summary>
    /// A definition of the backend data store operations that the <see cref="TableController{TEntity}"/>
    /// will perform in response to client operations.  This equates to a basic CRUDL repository
    /// pattern.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity stored in the repository.</typeparam>
    public interface IRepository<TEntity> : IRepository<TEntity, byte[]> where TEntity : ITableData<byte[]>
    {
    }
}
