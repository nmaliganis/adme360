using System.Collections.Generic;
using adme360.presenter.Commanding.Commands.Inbounds.Containers;
using adme360.presenter.Exceptions;

namespace adme360.presenter.Commanding.Commands
{
    public sealed class InboundCommandBuilderRepository
    {
        private readonly Dictionary<string, IInboundCommandBuilder> _cmdBuilders;


        private InboundCommandBuilderRepository()
        {
            _cmdBuilders = new Dictionary<string, IInboundCommandBuilder>()
            {
                {CommandingTopicsRepository.GetTopicRepository.ContainerPost,
                    new ContainerPostDetectedInboundCommandBuilder()},
            };
        }

        public static InboundCommandBuilderRepository GetCommandBuilderRepository { get; } = new InboundCommandBuilderRepository();

        public IInboundCommandBuilder this
            [string index]
        {
            get
            {
                try
                {
                    return _cmdBuilders[index];
                }
                catch (KeyNotFoundException)
                {
                    throw new CommandNotFoundException();
                }
            }
        }
    }
}