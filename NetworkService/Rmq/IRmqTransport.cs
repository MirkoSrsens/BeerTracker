namespace NetworkService.Rmq
{
    public interface IRmqTransport
    {
        void SendMessage<I, T>(T message);

        void Subscribe<T>(object instance);
    }
}
