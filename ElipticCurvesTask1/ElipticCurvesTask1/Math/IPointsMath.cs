using ElipticCurvesTask1.Models;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace ElipticCurvesTask1
{
	public interface IPointsMath
	{
		Point AddPoints(Point pointP, Point pointQ);
	}
}
