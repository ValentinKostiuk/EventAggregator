using System;
using EventsAggregator.Classes;
using EventsAggregator.Classes.Interfaces;
using EventsAggregator.Core.Services;
using EventsAggregator.Core.Services.Interfaces;
using Ninject.Modules;

namespace EventsAggregator.Core
{
	public class NinjectBindings: NinjectModule
	{
		public override void Load()
		{
			Console.WriteLine("Pony!!!");
		    Bind<IEventAggregator<EventArgs>>().To<EventAggregator<EventArgs>>().InSingletonScope();
			Bind<Interface1>().To<Class1>().InSingletonScope();
			Bind<Interface2>().To<Class2>().InSingletonScope();
			Console.WriteLine("No pony (((");
		}
	}
}
