// Copyright (c) DDD.CQRS. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using DDD.CQRS.Abstract;

namespace DDD.CQRS.Infrastructure
{
    public class QueryFactory : IQueryFactory
    {
        private readonly Func<Type, object> resolveCallback;

        public QueryFactory(Func<Type, object> resolveCallback)
        {
            this.resolveCallback = resolveCallback;
        }

        public T ResolveQuery<T>()
            where T : class, IQuery
        {
            return resolveCallback(typeof(T)) as T;
        }
    }
}
