namespace NetworkService.Rmq
{
    public interface IHandle<T>
    {
        void Handle(T message);
    }
}
