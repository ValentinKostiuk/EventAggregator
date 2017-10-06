using System;

namespace EventsAggregatorTest.Core.Services
{
	public delegate void AggregatorEventHandler<in TEventArgs>(object sender, TEventArgs eventArgs)
		where TEventArgs : EventArgs;
	public class Subscription<TEventArgs> : IDisposable where TEventArgs : EventArgs
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
