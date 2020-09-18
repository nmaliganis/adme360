using System;
using System.Collections;
using System.IO.Ports;
using System.Threading;
using magic.button.collector.api.Helpers.Exceptions;
using magic.button.collector.api.Messaging.Checkers;
using magic.button.collector.api.Messaging.Commands.Inbounds;
using magic.button.collector.api.Messaging.Commands.Servers;
using magic.button.collector.api.Messaging.PackageRepositories;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace magic.button.collector.api.Messaging.PortHandlers
{
  public sealed class PortHandler : IPortHandler
  {
    private static readonly PortHandler Instance = new PortHandler();
    private SerialPort _comPort;
    private ArrayList _inputBuffer;

    private PortHandler()
    {
      InitializeComControl();
    }

    private void InitializeComControl()
    {
      _comPort = new SerialPort();
      _comPort.DataReceived += new SerialDataReceivedEventHandler(ComPortDataReceived);
      _inputBuffer = new ArrayList();
    }

    private void ComPortDataReceived(object sender, SerialDataReceivedEventArgs e)
    {
      AppendComPortData();

      byte[] package = (byte[])_inputBuffer.ToArray(typeof(byte));
     //byte[] packageCommander = BuildFakePackage();
      
      if (PackageChecker.Checker.IsEndOfReceivedPackage(package))
      {
        _inputBuffer.Clear();

        if (package.Length < 20)
          return;

        InboundCommandBuilderRepository.GetCommandBuilderRepository
            [(char)package[PackageRepository.PackageRepositoryInstance.CommandOffset]]
            .Build(package).RaiseEvent(InboundServer.GetInboundServer);
      }
    }

    private byte[] BuildFakePackage()
    {
      byte[] package = new byte[32];

      package[0] = 0x7B;
      package[1] = 0x7B;
      package[2] = 0x00;
      package[3] = 0x01;
      package[4] = 0x54;

      for (int i = 5; i < 29; i++)
      {
        package[i] = (byte)(i - 5);
      }

      package[29] = 0xF3;
      package[30] = 0x7D;
      package[31] = 0x7D;

      return package;
    }

    private void AppendComPortData()
    {
      Thread.Sleep(100);
      var bytes = _comPort.BytesToRead;
      var buffer = new byte[bytes];

      _comPort.Read(buffer, 0, bytes);
      _inputBuffer.AddRange(buffer);
    }


    public static IPortHandler PortHandlerInsance => Instance;

    public IConfiguration Configuration { get; }
    public bool IsComPortOpen => _comPort.IsOpen;

    public void ToggleComPort(string comPort)
    {
      try
      {
        if (_comPort.IsOpen)
        {
          Log.Information($"For:{comPort} _comPort.IsOpen at:{DateTime.UtcNow}");
          _comPort.Close();
          Log.Information($"For:{comPort} _comPort.Close() at:{DateTime.UtcNow}");
          _inputBuffer?.Clear();
        }
        else
        {
          Log.Information($"For:{comPort} Just Before Opened at:{DateTime.UtcNow}");
          _comPort.PortName = comPort;
          _comPort.BaudRate = 115200;
          _comPort.DataBits = 8;
          _comPort.Parity = Parity.None;
          _comPort.StopBits = StopBits.One;
          _comPort.Open();
          Log.Information($"For:{comPort} Just After Opened at:{DateTime.UtcNow}");
        }
      }
      catch (Exception e)
      {
        Log.Error($"For:{comPort} ToggleComPort at:{DateTime.UtcNow} error was caught. Details: {e.Message}");
        throw new PortHandlerOpenPortFailedException();
      }
    }

    public void SendPackage(byte[] package)
    {
      try
      {
        _comPort.Write(package, 0, package.Length);
      }
      catch (ArgumentNullException e)
      {
        new NullPackageException();
      }
      catch (Exception e)
      {
        Log.Error($"For:{_comPort.PortName} SendPackage at:{DateTime.UtcNow} error was caught. Details: {e.Message}");
        throw new OutboundPackageWriteFailedException();
      }

    }
  }
}
