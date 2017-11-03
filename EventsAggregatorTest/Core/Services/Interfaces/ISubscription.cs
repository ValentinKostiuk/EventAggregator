using System;

namespace EventsAggregator.Core.Services
{
    public interface ISubscription<TEventArgs> : IDisposable where TEventArgs : EventArgs
    {
        AggregatorEventHandler<TEventArgs> Handler { get; }
    }
}