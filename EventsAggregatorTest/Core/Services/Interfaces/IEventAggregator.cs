using System;

namespace EventsAggregator.Core.Services.Interfaces
{
    public interface IEventAggregator<TEventArgs> where TEventArgs : EventArgs
    {
        void Publish(object sender, TEventArgs eventArgs);
        Subscription<TEventArgs> Subscribe(AggregatorEventHandler<TEventArgs> handler);
        void UnSbscribe(ISubscription<TEventArgs> subscription);
    }
}