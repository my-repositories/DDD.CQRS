// Copyright (c) DDD.CQRS. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using DDD.CQRS.Abstract;

namespace DDD.CQRS.Domain
{
    public abstract class QueryBase<TUnitOfWork> : IQuery
        where TUnitOfWork : IUnitOfWork
    {
        protected QueryBase(TUnitOfWork uow)
        {
            Uow = uow;
        }

        protected TUnitOfWork Uow { get; private set; }
    }
}