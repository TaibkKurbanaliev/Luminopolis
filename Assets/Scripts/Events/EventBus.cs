using System.Collections.Generic;
using UnityEngine;

public static class EventBus<T> where T : IEvent 
{
    private static readonly HashSet<IEventBinding<T>> _bingings = new();

    public static void Register(IEventBinding<T> binding) => _bingings.Add(binding);
    public static void Unregister(IEventBinding<T> binding) => _bingings.Remove(binding);

    public static void Raise(T @event)
    {
        foreach (var binding in _bingings)
        {
            binding.OnEvent.Invoke(@event);
            binding.OnEventNoArgs.Invoke();
        }
    }
}
