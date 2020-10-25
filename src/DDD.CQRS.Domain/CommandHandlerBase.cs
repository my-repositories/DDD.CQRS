// Copyright (c) DDD.CQRS. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using DDD.CQRS.Abstract;

namespace DDD.CQRS.Domain
{
    public abstract class CommandHandlerBase<TCommand, TUnitOfWork>
        : ICommandHandler<TCommand>
        where TCommand : ICommand
        where TUnitOfWork : IUnitOfWork
    {
        protected CommandHandlerBase(TUnitOfWork uow)
        {
            Uow = uow;
        }

        protected TUnitOfWork Uow { get; private set; }

        public abstract void Execute(TCommand command);

        public void Dispose()
        {
            Uow.Dispose();
        }
    }
}