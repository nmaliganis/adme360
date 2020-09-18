using System;
using System.Net;
using System.Threading.Tasks;
using magic.button.collector.api.Helpers.Contracts;
using magic.button.collector.api.Helpers.Models;
using magic.button.collector.api.Helpers.Serializers;
using magic.button.collector.api.Messaging.PortHandlers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace magic.button.collector.api.Controllers
{
  [Produces("application/json")]
  [Route("api/[controller]")]
  [ApiController]
  public class CommandController : ControllerBase
  {

    public IConfiguration Configuration { get; }

    private readonly IHostingEnvironment _environment;
    private readonly IAwsIoTProcessor _awsIoTProcessor;
    private readonly IJsonSerializer _jsonSerializer;
    private readonly IActionContextAccessor _accessor;
    private readonly IPortHandlerFactory _portHandlerFactory;

    public CommandController(IHostingEnvironment environment, IConfiguration configuration, IActionContextAccessor accessor,
      IAwsIoTProcessor awsIoTProcessor, IJsonSerializer jsonSerializer, IPortHandlerFactory portHandlerFactory)
    {
      Configuration = configuration;
      _environment = environment;
      _accessor = accessor;

      _portHandlerFactory = portHandlerFactory;

      _awsIoTProcessor = awsIoTProcessor;
      _jsonSerializer = jsonSerializer;
    }

    [HttpPost("on-demand", Name = "PostMqttOnDemandRoot")]
    public async Task<IActionResult> PostMqttOnDemandAsync()
    {
      IPHostEntry hostInfo = Dns.Resolve(Dns.GetHostName());

      TelemetryModel model = new TelemetryModel()
      {
        deviceid = Guid.NewGuid().ToString(),
        timestamp = DateTime.Now,
        tempValue = 23.7,
        rssi = "100",
        snr = "5",
      };

      var onDemandMessageWasSent = await _awsIoTProcessor.OnDemandMessageAsync(_environment.WebRootPath, _jsonSerializer.SerializeObject(model));

      return Ok(onDemandMessageWasSent);
    }

    
    [HttpGet("tty-status", Name = "GetTtyStatusLogRoot")]
    public async Task<IActionResult> GetTtyStatusLogAsync()
    {
      var ttyStatus = _portHandlerFactory.CreatePortHandler().IsComPortOpen;

      return Ok(ttyStatus);
    }

    [HttpPost("tty-toggle", Name = "PostTtyToggleRoot")]
    public async Task<IActionResult> PostTtyToggleAsync()
    {
      string ttyPort = Configuration.GetSection("TTY:Port").Value;

      _portHandlerFactory.CreatePortHandler().ToggleComPort(ttyPort);
      var ttyStatus = _portHandlerFactory.CreatePortHandler().IsComPortOpen;

      return Ok(ttyStatus ? $"{ttyPort}: Opened" : $"{ttyPort}: Closed");
    }
  }
}
