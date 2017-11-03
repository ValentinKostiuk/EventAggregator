using System;
using EventAggregator.Interfaces;
using EventsAggregator.Classes.Interfaces;

namespace EventsAggregator.Classes
{
	public class Class2: IClass2
	{
	    private readonly IEventAggregator _eventAggregator;

	    public Class2(IEventAggregator eventAggregator)
		{
			Console.WriteLine("Class2 constructor");
		    _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe<EventArgs>(HandleEventArgs);
		}

	    private void HandleEventArgs(object sender, EventArgs eventargs)
	    {
	        Console.WriteLine("Handled event from: " + sender.GetType());
            Console.WriteLine("Sending Message");
            _eventAggregator.Publish(this, new Class3{Message = "Some message from Class2"});
        }
	}
}
