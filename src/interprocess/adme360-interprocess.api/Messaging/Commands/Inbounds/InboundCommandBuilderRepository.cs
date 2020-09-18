using System.Collections.Generic;
using magic.button.collector.api.Helpers.Exceptions;
using magic.button.collector.api.Messaging.Commands.Inbounds.Builders;
using magic.button.collector.api.Messaging.Commands.Inbounds.Cmds;
using magic.button.collector.api.Messaging.PackageRepositories;

namespace magic.button.collector.api.Messaging.Commands.Inbounds
{
  public sealed class InboundCommandBuilderRepository
  {
    private readonly Dictionary<char, IInboundCommandBuilder> _cmdBuilders;


    private InboundCommandBuilderRepository()
    {
      _cmdBuilders = new Dictionary<char, IInboundCommandBuilder>()
      {
        {PackageRepository.PackageRepositoryInstance.TelemetryCmdCode,
          new TelemetryPackageDetectedInboundCommandBuilder()}};
    }

    public static InboundCommandBuilderRepository GetCommandBuilderRepository { get; } = new InboundCommandBuilderRepository();

    public IInboundCommandBuilder this
      [char index]
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