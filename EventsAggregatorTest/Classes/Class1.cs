using System;
using EventsAggregator.Classes.Interfaces;
using EventAggregator.Interfaces;

namespace EventsAggregator.Classes
{
	public class Class1: IClass1
	{
	    private readonly IEventAggregator _eventAggregator;
		public Class1(IEventAggregator eventAggregator)
		{
			Console.WriteLine("Class1 constructor");
		    _eventAggregator = eventAggregator;
		}

		public void EmmitEvent()
		{
			Console.WriteLine("Sending event");
		    _eventAggregator.Subscribe<Class3>(HandleClass3Event);
            _eventAggregator.Publish(this, EventArgs.Empty);
		}

	    private void HandleClass3Event(object sender, Class3 eventArgs)
	    {
	        Console.WriteLine("Received event from: " + sender.GetType() + ". With message: " + eventArgs.Message);
        }
	}
}
