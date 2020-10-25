// Copyright (c) DDD.CQRS. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq;
using DDD.CQRS.Abstract;

namespace DDD.CQRS.Infrastructure
{
    public class CommandFactory : ICommandFactory
    {
        private readonly Func<Type, object> resolveCallback;

        public CommandFactory(Func<Type, object> resolveCallback)
        {
            this.resolveCallback = resolveCallback;
        }

        public void Execute<TCommand>(TCommand command)
            where TCommand : class, ICommand
        {
            var commandHandlers = Resolve<TCommand>().ToArray();
            if ((commandHandlers == null) || !commandHandlers.Any())
            {
                throw new ArgumentException("Unknown command: \"" + typeof(TCommand).FullName + "\"");
            }

            foreach (var commandHandler in commandHandlers)
            {
                commandHandler.Execute(command);
                commandHandler.Dispose();
            }
        }

        private IEnumerable<ICommandHandler<T>> Resolve<T>()
            where T : class, ICommand
        {
            return this.resolveCallback(typeof(IEnumerable<ICommandHandler<T>>))
                as IEnumerable<ICommandHandler<T>>;
        }
    }
}