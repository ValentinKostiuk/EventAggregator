using System;
using System.Collections;
using System.Collections.Generic;
using EventsAggregator.Core.Services.Interfaces;

namespace EventsAggregator.Core.Services
{
	public class EventAggregator<TEventArgs> : IEventAggregator<TEventArgs> where TEventArgs: EventArgs
	{
		private readonly Dictionary<Type, IList<ISubscription<TEventArgs>>> _allSubscribtions;

		public EventAggregator()
		{
			_allSubscribtions = new Dictionary<Type, IList<ISubscription<TEventArgs>>>();
		}

		public void Publish(object sender, TEventArgs eventArgs)
		{
			Type argumentsType = typeof(TEventArgs);
			if (_allSubscribtions.ContainsKey(argumentsType))
			{
				IList subscriptions = new List<ISubscription<TEventArgs>>(_allSubscribtions[argumentsType]);

				foreach (ISubscription<TEventArgs> subscription in subscriptions)
				{
					subscription.Handler(sender, eventArgs);
				}
			}
		}

		public Subscription<TEventArgs> Subscribe(AggregatorEventHandler<TEventArgs> handler)
		{
			Type argumentsType = typeof(TEventArgs);
			IList<ISubscription<TEventArgs>> subscriptionsOfType;
			var actionDetail = new Subscription<TEventArgs>(handler, this);

			if (!_allSubscribtions.TryGetValue(argumentsType, out subscriptionsOfType))
			{
				subscriptionsOfType = new List<ISubscription<TEventArgs>> {actionDetail};
				_allSubscribtions.Add(argumentsType, subscriptionsOfType);
			}
			else
			{
				subscriptionsOfType.Add(actionDetail);
			}

			return actionDetail;
		}

		public void UnSbscribe(ISubscription<TEventArgs> subscription)
		{
			Type argumentsType = typeof(TEventArgs);
			if (_allSubscribtions.ContainsKey(argumentsType))
			{
				_allSubscribtions[argumentsType].Remove(subscription);
			}
		}

	}
}
