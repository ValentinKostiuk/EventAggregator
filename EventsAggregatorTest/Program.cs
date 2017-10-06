using System;
using System.Reflection;
using EventsAggregatorTest.Classes;
using EventsAggregatorTest.Classes.Interfaces;
using EventsAggregatorTest.Core;
using Ninject;

namespace EventsAggregatorTest
{
	class Program
	{
		static void Main(string[] args)
		{
			StandardKernel kernel = new StandardKernel();
			kernel.Load(Assembly.GetExecutingAssembly());

			var c1 = kernel.Get<Interface1>();
			//var c1 = new Class1();
			c1.Log();

			Console.ReadLine();
		}
	}
}
