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
		public PointBelongsToCurves(ICurveEquation curveEquation)
		{
			_curveEquation = curveEquation;
		}

		public void Run()
		{
			ShowPointsInConsole();
		}

		private void ShowPointsInConsole()
		{
			Point pointP = GetPointCurvesContain();
			Point pointQ = GetPointCurvesContain();
			Console.WriteLine();
			Console.WriteLine("Punkt P: (" + pointP.x + "," + pointP.y + ")");
			Console.WriteLine();
			Console.WriteLine("Punkt Q: (" + pointQ.x +", "+ pointQ.y+")");
		}

		private Point GetPointCurvesContain()
		{
			BigInteger x = GetSquareRest();
			BigInteger y = GetValueY(x);

			return new Point(x, y);
		}

		private BigInteger GetSquareRest()
		{
			bool isSquareRest = false;
			BigInteger a = _curveEquation.A;
			BigInteger b = _curveEquation.B;
			BigInteger modulo = _curveEquation.Modulo;
			BigInteger value = 0; ;
			BigInteger x ;
			while(!isSquareRest)
			{
				x = GetRandomValue();
				value = (BigInteger.Pow(x, 3) + a * x + b) % modulo;
				isSquareRest = SquareRest.IsSquareRest(modulo, value);
			}
			return value;
		}

		private BigInteger GetValueY(BigInteger x)
		{
			BigInteger y = BigIntigerMath.SqrtModEuler(x, _curveEquation.Modulo);
			return y;
			//BigInteger squareY = BigInteger.Pow(y, 2);
			//BigInteger squareY2 = BigInteger.ModPow(y, 2, _curveEquation.Modulo);
			//if (squareY2 != x)
			//{
			//	Console.WriteLine("Błąd: y*y= " + squareY.ToString() + "\n x = " + y.ToString());
			//}
			//else
		}
		public BigInteger GetRandomValue()
		{
			Random rand = new Random();
			BigInteger x = rand.Next(3, int.MaxValue);
			return x;
		}
	}
}
