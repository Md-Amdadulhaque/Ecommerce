namespace E_commerce.Interface
{
    public interface IEventPublisher
    {
        void Publish<T>(T @event) where T : class;
    }
}
