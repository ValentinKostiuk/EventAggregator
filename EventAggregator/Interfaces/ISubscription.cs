using System;

namespace EventAggregator.Interfaces
{
    public interface ISubscription<TEventArgs> : IDisposable where TEventArgs : EventArgs
    {
        AggregatorEventHandler<TEventArgs> Handler { get; }
    }
}