using System;

namespace EventsAggregator.Core.Services.Interfaces
{
    public interface IEventAggregator
    {
        void Publish<TEventArgs>(object sender, TEventArgs eventArgs) where TEventArgs : EventArgs;
        Subscription<TEventArgs> Subscribe<TEventArgs>(AggregatorEventHandler<TEventArgs> handler) where TEventArgs : EventArgs;
        void UnSbscribe<TEventArgs>(ISubscription<TEventArgs> subscription) where TEventArgs : EventArgs;
    }
}