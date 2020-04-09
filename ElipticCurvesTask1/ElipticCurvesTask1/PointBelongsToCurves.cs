//using ElipticCurvesTask1.Models;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

using ElipticCurvesTask1.Models;

namespace ElipticCurvesTask1
{
	public class PointBelongsToCurves : IPointBelongsToCurves
	{
		private ICurveEquation _curveEquation;
		private BigInteger a;
		private BigInteger b;
		private BigInteger modulo;

		public PointBelongsToCurves(ICurveEquation curveEquation)
		{
			_curveEquation = curveEquation;
			a = curveEquation.A;
			b = curveEquation.B;
			modulo = curveEquation.Modulo;
		}
		
		public Point GetPointCurvesContain()
		{
			BigInteger x = GetSquareRestForPoints();
			BigInteger y = GetValueY(x);

			return new Point(x, y);
		}

		private BigInteger GetSquareRestForPoints()
		{
			bool isSquareRest = false;
			BigInteger value; 
			BigInteger x;
			while (!isSquareRest)
			{
				x = GetRandomValue();
				value = GetYSquare(x);
				isSquareRest = SquareRest.IsSquareRest(modulo, value);
			}
			return x;
		}

		private BigInteger GetYSquare(BigInteger x)
		{
			BigInteger value =  (BigInteger.Pow(x, 3) + a * x + b) % modulo;
			return value;
		}
		private BigInteger GetValueY(BigInteger x)
		{
			BigInteger value = GetYSquare(x);
			BigInteger y = BigIntigerMath.SqrtModEuler(value, modulo);
			return y;
		}
		
		public bool IsPointContainToCurves(Point point)
		{
			BigInteger y2 = BigInteger.ModPow(point.y, 2, modulo);
			BigInteger x3 = BigInteger.ModPow(point.x, 3, modulo);
			BigInteger ax = (a * point.x) % modulo;
			BigInteger result = (x3 + ax + _curveEquation.B) % modulo;
			BigInteger result2 = result % modulo;
			if (y2 == result)
				return true;
			else
				return false;
		}
		
		public BigInteger GetRandomValue()
		{
			Random rand = new Random();
			BigInteger x = rand.Next(3, int.MaxValue);
			return x;
		}
	}
}
