// Copyright (c) Microsoft Corporation. All Rights Reserved.
// Licensed under the MIT License.

using System;

namespace Microsoft.AspNetCore.Datasync
{
    /// <summary>
    /// The <see cref="ITableData"/> interface provides an abstraction for the system properties
    /// for a given table data model.
    /// </summary>
    public interface ITableData : ITableData<byte[]>
    {
    }
}
