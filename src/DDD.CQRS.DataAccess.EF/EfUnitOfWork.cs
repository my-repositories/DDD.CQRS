// Copyright (c) DDD.CQRS. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using DDD.CQRS.Abstract;

namespace DDD.CQRS.DataAccess.EF
{
    public class EfUnitOfWork<TContext> : IUnitOfWork
        where TContext : DbContext
    {
        private bool disposed;

        public EfUnitOfWork(TContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        protected virtual TContext Context { get; private set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual int SaveChanges()
        {
            return Context.SaveChanges();
        }

        public virtual Task<int> SaveChangesAsync()
        {
            return Context.SaveChangesAsync();
        }

        public virtual Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return Context.SaveChangesAsync(cancellationToken);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                if (Context != null)
                {
                    Context.Dispose();
                    Context = null;
                }
            }

            disposed = true;
        }
    }
}
