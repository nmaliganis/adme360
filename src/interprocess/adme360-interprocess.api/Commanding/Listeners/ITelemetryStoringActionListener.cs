using magic.button.collector.api.Commanding.Args;

namespace magic.button.collector.api.Commanding.Listeners
{
  public interface ITelemetryStoringActionListener
  {
    void Update(object sender, TelemetryStoringEventArgs e);
  }
}