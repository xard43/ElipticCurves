using ElipticCurvesTask1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElipticCurvesTask1
{
	public class ShowInConsole : IShowInConsole
	{
		ICurveEquation _curveEquation;
		IPointBelongsToCurves _pointBelongsToCurves;
		IPointsMath _pointMath;

		private Point pointP;
		private Point pointQ;

		public ShowInConsole(ICurveEquation curveEquation,
			IPointBelongsToCurves pointBelongsToCurves, IPointsMath pointMath)
		{
			_curveEquation = curveEquation;
			_pointBelongsToCurves = pointBelongsToCurves;
			_pointMath = pointMath;

			pointP = pointBelongsToCurves.GetPointCurvesContain();
			pointQ = pointBelongsToCurves.GetPointCurvesContain();
		}
		public void Run()
		{
			ShowCurveDataInConsole();
			ShowRandomPointsInConsole();
			ShowAddedPointPAndQInConsole();
			ShowMultiplySamePointsInConsole();
			ShowSubstractionSamePointsInConsole();
			ShowAddPointPToZero();
			ShowPointBelongToCurvesInConsole();
		}
		private void ShowCurveDataInConsole()
		{
			Console.WriteLine("Dane do zadania:");
			Console.WriteLine("E: Y^2 = X^3 - 3X + B");
			Console.WriteLine("A = " + _curveEquation.A);
			Console.WriteLine("B = " + _curveEquation.B);
			Console.WriteLine("Modulo = " + _curveEquation.Modulo);
			Console.WriteLine();
		}
		private void ShowRandomPointsInConsole()
		{
			Console.WriteLine("1. Wylosuj punkty P i Q:");
			Console.WriteLine("Punkt P: (" + pointP.x + ", " + pointP.y + ")");
			Console.WriteLine("Punkt Q: (" + pointQ.x + ", " + pointQ.y + ")");
			Console.WriteLine();
		}
		private void ShowAddedPointPAndQInConsole()
		{
			Point pointR = _pointMath.AddPoints(pointP, pointQ);
			Console.WriteLine("2. Oblicz R = P+Q");
			Console.WriteLine("R = (" + pointR.x + "," + pointR.y + ")");
			Console.WriteLine();
		}
		private void ShowMultiplySamePointsInConsole()
		{
			Point point2P = _pointMath.AddPoints(pointP, pointP);
			Console.WriteLine("3. Oblicz 2P");
			Console.WriteLine("2P = (" + point2P.x + "," + point2P.y + ")");
			Console.WriteLine();
		}
		private void ShowSubstractionSamePointsInConsole()
		{
			Console.WriteLine("4. Oblicz R = P - P");
			Console.WriteLine();
			Point pointMinusP = new Point(pointP.x, pointP.y * -1);
			Point pointR = _pointMath.AddPoints(pointP, pointMinusP);
			
			Console.WriteLine();
		}
		private void ShowAddPointPToZero()
		{
			Console.WriteLine("5. Oblicz R = P + 0");
			Point pointZero = new Point(0);
			Point pointR = _pointMath.AddPoints(pointP, pointZero);
			Console.WriteLine("R = (" + pointR.x + "," + pointR.y + ")");
			Console.WriteLine();
		}
		public void ShowPointBelongToCurvesInConsole()
		{
			bool isContainToCurves = _pointBelongsToCurves.IsPointContainToCurves(pointP);
			Console.WriteLine("6. Czu punkt P należy do krzywej ?");
			if (isContainToCurves)
			{
				Console.WriteLine("Punkt P należy do prostej");
			}
			else
			{
				Console.WriteLine("Punkt P nie należy do prostej");
			}
		}

	}
}
