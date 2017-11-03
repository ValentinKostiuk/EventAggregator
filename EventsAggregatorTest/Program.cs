using System;
using System.Reflection;
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

			var c1 = kernel.Get<IClass1>();
			var c2 = kernel.Get<IClass2>();

			c1.EmmitEvent();

			Console.ReadLine();
		}
	}
}
