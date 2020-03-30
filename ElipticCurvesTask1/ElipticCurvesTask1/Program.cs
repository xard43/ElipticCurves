using ElipticCurvesTask1.Container;
using System;
using System.Globalization;
using System.Numerics;
using Autofac;

namespace ElipticCurvesTask1
{
	class Program
	{
		static void Main(string[] args)
		{
			var container = ContainerConfig.Configure();

			using (var scope = container.BeginLifetimeScope())
			{
				var businessLogic = scope. Resolve<IBusinessLogic>();
				businessLogic.Run();
			}

			Console.ReadKey();
		}
	}
}
