using System;
using System.Reflection;
using EventsAggregator.Classes;
using EventsAggregator.Classes.Interfaces;
using Ninject;

namespace EventsAggregator
{
	class Program
	{
		static void Main(string[] args)
		{
			StandardKernel kernel = new StandardKernel();
			kernel.Load(Assembly.GetExecutingAssembly());

			var c1 = kernel.Get<Interface1>();
			var c2 = kernel.Get<Interface2>();

            c2.SubscribeEvents();
            c1.Log();

			Console.ReadLine();
		}
	}
}
