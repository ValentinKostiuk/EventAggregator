using System;
using EventsAggregator.Core.Services.Interfaces;

namespace EventsAggregator.Core.Services
{
	public delegate void AggregatorEventHandler<in TEventArgs>(object sender, TEventArgs eventArgs)
		where TEventArgs : EventArgs;
	public class Subscription<TEventArgs> : IDisposable, ISubscription<TEventArgs> where TEventArgs : EventArgs
	{
		public AggregatorEventHandler<TEventArgs> Handler { get; private set; }
		private readonly IEventAggregator<TEventArgs> _eventAggregator;
		private bool _isDisposed;

		public Subscription(AggregatorEventHandler<TEventArgs> handler, IEventAggregator<TEventArgs> eventAggregator)
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
