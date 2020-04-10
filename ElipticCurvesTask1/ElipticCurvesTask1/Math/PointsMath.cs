using ElipticCurvesTask1.DataModels;
using ElipticCurvesTask1.Models;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace ElipticCurvesTask1
{
	public class PointsMath : IPointsMath
	{
		private ICurveEquation _curveEquation;
		private BigInteger modulo;
		private BigInteger a;
		private Point pointP;
		private Point pointQ;

		public PointsMath(ICurveEquation curveEquation)
		{
			_curveEquation = curveEquation;
			modulo = curveEquation.Modulo;
			a = curveEquation.A;
		}
		public Point AddPoints(Point pointP, Point pointQ)
		{
			this.pointP = pointP;
			this.pointQ = pointQ;

			if(!IsPossibleToAddSamePoints(pointP, pointQ))
			{
				//P-P = 0
				return new Point(0);
			}
			else if(IsPointSpecialZero(pointP))
			{
				//P+0 = P
				return pointQ;
			}
			else if (IsPointSpecialZero(pointQ))
			{
				//Q+0 = Q
				return pointP;
			}
			else if (pointP == pointQ)
			{
				return MultipySamePoints();
			}
			else
			{
				return AddDifferentPointsPAndQ();
			}
		}
		private Point AddDifferentPointsPAndQ()
		{
			BigInteger x1 = pointP.x;
			BigInteger y1 = pointP.y;
			BigInteger x2 = pointQ.x;
			BigInteger y2 = pointQ.y;

			BigInteger lambda = ((y2 - y1) * BigIntigerMath.InverseNumberMod(x2 - x1, modulo)) % modulo;
			BigInteger x3 = (BigInteger.ModPow(lambda, 2, modulo) - x1 - x2) % modulo;
			BigInteger y3 = (lambda * (x1 - x3) - y1) % modulo;
			return new Point(x3, y3);
		}

		private Point MultipySamePoints()
		{
			BigInteger x1 = pointP.x;
			BigInteger y1 = pointP.y;
			BigInteger x2 = pointQ.x;
			BigInteger y2 = pointQ.y;

			BigInteger lambda = ((3 * BigInteger.ModPow(x1, 2, modulo) + a) * BigIntigerMath.InverseNumberMod(2 * y1, modulo)) % modulo;
			BigInteger x3 = (BigInteger.ModPow(lambda, 2, modulo) - 2 * x1) % modulo;
			BigInteger y3 = (lambda * (x1 - x3) - y1) % modulo;
			return new Point(x3, y3);

		}

		private bool IsPointSpecialZero(Point point)
		{
			if (point.specialZero == 0)
			{
				Console.WriteLine("Punkt wynosi 0 (SpecialZero)");
				return true;
			}
			return false;
		}

		private bool IsPossibleToAddSamePoints(Point pointP, Point pointQ)
		{
			BigInteger x1 = pointP.x;
			BigInteger y1 = pointP.y;
			BigInteger x2 = pointQ.x;
			BigInteger y2 = pointQ.y;
			if (x1 == x2 && y1 == y2 *(-1) || x1 == x2 && y1 * (-1) == y2)
			{
				Console.WriteLine("Nastąpiło odejmowanie P - P. Równanie równe 0 (SpecialZero)");
				return false;
			}
			return true;
		}

	}
}
