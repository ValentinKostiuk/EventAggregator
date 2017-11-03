using System;

namespace EventsAggregator.Core.Services.Interfaces
{
    public interface ISubscription<TEventArgs> : IDisposable where TEventArgs : EventArgs
    {
        AggregatorEventHandler<TEventArgs> Handler { get; }
    }
}