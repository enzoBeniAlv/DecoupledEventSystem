
public static class EventBus
{
    private static readonly Dictionary<Type, Delegate> _subscribers = new ();

    public static void Subscribe<T>(Action<T> handler)
    {
        var eventType = typeof(T);
        if (_subscribers.TryGetValue(eventType, out var existing))
            _subscribers[eventType] = Delegate.Combine(existing, handler);
        else
            _subscribers[eventType] = handler;
    }

    public static void Unsubscribe<T>(Action<T> handler)
    {
        var eventType = typeof(T);

        if (!_subscribers.TryGetValue(eventType, out var existing))
        {
            Console.WriteLine($"EventBus: No subscribers found for event type {eventType.Name}.");
            return;
        }

        var updated = Delegate.Remove(existing, handler);

        if (updated is null)
        {
            _subscribers.Remove(eventType);
            return;
        }

        _subscribers[eventType] = updated;
    }

    public static void Publish<T>(T eventData) where T : IGameEvent
    {
        if (_subscribers.ContainsKey(typeof(T)))
        {
            var handlers = _subscribers[typeof(T)] as Action<T>;
            handlers?.Invoke(eventData);
        }
        else
        {
            Console.WriteLine($"EventBus: No subscribers for event type {typeof(T).Name}");
        }
    }
}