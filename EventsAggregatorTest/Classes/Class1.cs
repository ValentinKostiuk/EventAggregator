using System;
using EventsAggregator.Classes.Interfaces;
using Ninject;

namespace EventsAggregator.Classes
{
	public class Class1: Interface1
	{
		[Inject]
		public virtual Interface2 Class2 { get; set; }

		public Class1()
		{
			Console.WriteLine("Class1");
		}

		public void Log()
		{
			Console.WriteLine("Class1 Loaded. Class2 referance: " + Class2.ToString());
		}
	
	}
}
