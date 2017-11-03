using System;

namespace EventsAggregator.Core.Services.Interfaces
{
    public interface ISubscription<TEventArgs> where TEventArgs : EventArgs
    {
        AggregatorEventHandler<TEventArgs> Handler { get; }
        void Dispose();
    }
}