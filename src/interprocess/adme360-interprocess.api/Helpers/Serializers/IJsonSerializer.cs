namespace magic.button.collector.api.Helpers.Serializers
{
  public interface IJsonSerializer
  {
    T DeserializeObject<T>(string json);
    string SerializeObject(object item);
  }
}