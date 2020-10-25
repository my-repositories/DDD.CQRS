// Copyright (c) DDD.CQRS. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;

using Microsoft.EntityFrameworkCore;
using DDD.CQRS.Domain;

namespace DDD.CQRS.DataAccess.EF
{
    public class EfRepository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class
        where TContext : DbContext
    {
        public EfRepository(TContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            Set = Context.Set<TEntity>();
        }

        protected TContext Context { get; }

        public DbSet<TEntity> Set { get; }

        public virtual void Add(TEntity entity)
        {
            Set.Add(entity);
        }

        public virtual void Remove(TEntity entity)
        {
            Set.Remove(entity);
        }
    }
}
