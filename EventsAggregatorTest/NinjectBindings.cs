using System;
using EventAggregator.Interfaces;
using EventsAggregator.Classes;
using EventsAggregator.Classes.Interfaces;
using Ninject.Modules;

namespace EventsAggregator
{
	public class NinjectBindings: NinjectModule
	{
		public override void Load()
		{
			Console.WriteLine("Start Injection initialization");
		    Bind<IEventAggregator>().To<EventAggregator.EventAggregator>().InSingletonScope();
			Bind<IClass1>().To<Class1>();
			Bind<IClass2>().To<Class2>();
			Console.WriteLine("Injection initialization done");
		}
	}
}
