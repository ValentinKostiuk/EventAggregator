using System;

namespace EventsAggregator.Core.Services
{
    public interface IEventAggregator
    {
        void Publish<TEventArgs>(object sender, TEventArgs eventArgs) where TEventArgs : EventArgs;
        Subscription<TEventArgs> Subscribe<TEventArgs>(AggregatorEventHandler<TEventArgs> handler) where TEventArgs : EventArgs;
        void UnSbscribe<TEventArgs>(Subscription<TEventArgs> subscription) where TEventArgs : EventArgs;
    }
}