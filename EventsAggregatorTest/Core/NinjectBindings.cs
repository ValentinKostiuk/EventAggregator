using System;
using EventsAggregator.Classes;
using EventsAggregator.Classes.Interfaces;
using Ninject.Modules;

namespace EventsAggregatorTest.Core
{
	public class NinjectBindings: NinjectModule
	{
		public override void Load()
		{
			Console.WriteLine("Pony!!!");
			Bind<Interface1>().To<Class1>().InSingletonScope();
			Bind<Interface2>().To<Class2>().InSingletonScope();
			Console.WriteLine("No pony (((");
		}
	}
}
