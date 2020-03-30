using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using ElipticCurvesTask1.Models;

namespace ElipticCurvesTask1.Container
{
	public static class ContainerConfig
	{
		public static IContainer Configure()
		{
			ContainerBuilder builder = new ContainerBuilder();
			builder.RegisterType<CurveEquation>().As<ICurveEquation>();
			builder.RegisterType<BusinessLogic>().As<IBusinessLogic>();
			builder.RegisterType<PointBelongsToCurves>().As<IPointBelongsToCurves>();

			return builder.Build();
		}
	}
}
