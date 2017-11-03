using System;
using EventsAggregator.Core.Services.Interfaces;

namespace EventsAggregator.Core.Services
{
	public delegate void AggregatorEventHandler<TEventArgs>(object sender, TEventArgs eventArgs)
		where TEventArgs : EventArgs;
	public class Subscription<TEventArgs> : ISubscription<TEventArgs> where TEventArgs : EventArgs
	{
		public AggregatorEventHandler<TEventArgs> Handler { get; private set; }
		private readonly EventAggregator _eventAggregator;
		private bool _isDisposed;

		public Subscription(AggregatorEventHandler<TEventArgs> handler, EventAggregator eventAggregator)
		{
			Handler = handler;
			_eventAggregator = eventAggregator;
		}

		~Subscription()
		{
			if (!_isDisposed)
				Dispose();
		}

		public void Dispose()
		{
			_eventAggregator.UnSbscribe(this);
			_isDisposed = true;
		}
	}
}
