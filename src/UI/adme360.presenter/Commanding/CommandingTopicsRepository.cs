namespace dl.wm.presenter.Commanding
{
    public sealed class CommandingTopicsRepository
    {
        private CommandingTopicsRepository()
        {

        }
        public static CommandingTopicsRepository GetTopicRepository { get; } = new CommandingTopicsRepository();


        public string ContainerPost => "container/post";
        public string ContainerPut => "container/put";
        public string ContainerDelete => "container/delete";
    }
}
