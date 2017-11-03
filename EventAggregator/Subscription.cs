using System;
using EventAggregator.Interfaces;

namespace EventAggregator
{
	public delegate void AggregatorEventHandler<TEventArgs>(object sender, TEventArgs eventArgs)
		where TEventArgs : EventArgs;
	public class Subscription<TEventArgs> : ISubscription<TEventArgs> where TEventArgs : EventArgs
	{
		public AggregatorEventHandler<TEventArgs> Handler { get; private set; }
		private readonly global::EventAggregator.EventAggregator _eventAggregator;
		private bool _isDisposed;

		public Subscription(AggregatorEventHandler<TEventArgs> handler, global::EventAggregator.EventAggregator eventAggregator)
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
