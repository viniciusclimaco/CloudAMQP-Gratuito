namespace Publisher.Rabbit
{
    public interface IMessage
    {
        void SendMessage<T>(T message);
    }
}
