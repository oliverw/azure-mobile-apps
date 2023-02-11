// Copyright (c) Microsoft Corporation. All Rights Reserved.
// Licensed under the MIT License.

using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Datasync
{
    /// <summary>
    /// <para>
    /// An <see cref="IAccessControlProvider{TEntity}"/> object defines the access permissions
    /// for a client to access one or more entities within the table.  It is comprised of three
    /// elements - a view of the data, a boolean check for authorization, and a pre-commit hook.
    /// </para>
    /// <para>
    /// Between the three methods, you can decide what items can be operated on, what operations
    /// are allowed, and how to store any additional information to provide for authorization.</para>
    /// </summary>
    /// <typeparam name="TEntity">The type of entity within the table.</typeparam>
    public interface IAccessControlProvider<TEntity> : IAccessControlProvider<TEntity, byte[]>
        where TEntity : ITableData<byte[]>
    {
    }
}
