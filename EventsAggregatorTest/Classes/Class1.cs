using System;
using EventsAggregator.Classes.Interfaces;
using EventsAggregator.Core.Services.Interfaces;
using Ninject;

namespace EventsAggregator.Classes
{
	public class Class1: Interface1
	{
		[Inject]
		public virtual Interface2 Class2 { get; set; }

	    [Inject]
	    public virtual IEventAggregator<EventArgs> EventAggregator { get; set; }

	    public Class1()
		{
			Console.WriteLine("Class1");
		}

		public void Log()
		{
            Console.WriteLine("Sending Event");
		    EventAggregator.Publish(this, EventArgs.Empty);
		}
	
	}
}
