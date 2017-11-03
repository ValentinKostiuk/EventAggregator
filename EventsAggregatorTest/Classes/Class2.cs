using System;
using EventsAggregator.Classes.Interfaces;
using EventsAggregator.Core.Services.Interfaces;
using Ninject;

namespace EventsAggregator.Classes
{
	public class Class2: Interface2
	{
        [Inject]
        public virtual IEventAggregator<EventArgs> EventsAggregator { get; set; }
		public Class2()
		{
			Console.WriteLine("Class2");
		}

	    public void HandledEventArgs(object c, EventArgs args)
	    {
            Console.WriteLine("Axcepted Event" + c.GetType());
	    }

	    public void SubscribeEvents()
	    {
	        EventsAggregator.Subscribe(HandledEventArgs);
        }
	}
}
