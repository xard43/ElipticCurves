using ElipticCurvesTask1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElipticCurvesTask1
{
	public class BusinessLogic : IBusinessLogic
	{
		ICurveEquation _curveEquation;
		IPointBelongsToCurves _pointBelongsToCurves;
		private char numberOfTask;

		public BusinessLogic(ICurveEquation curveEquation, IPointBelongsToCurves pointBelongsToCurves)
		{
			_curveEquation = curveEquation;
			_pointBelongsToCurves = pointBelongsToCurves;
		}
		public void Run()
		{
			ShowCurveDataInConsole();
			ShowMenuOptions();
			GetNumberFromUser();
			UserChoose();
		}
		private void ShowCurveDataInConsole()
		{
			Console.WriteLine("Witaj !");
			Console.WriteLine();
			Console.WriteLine("Dane do zadania:");
			Console.WriteLine("E: Y^2 = X^3 - 3X + B");
			Console.WriteLine("A = " + _curveEquation.A);
			Console.WriteLine("B = " + _curveEquation.B);
			Console.WriteLine("Modulo = " + _curveEquation.Modulo);
			_pointBelongsToCurves.Run();
			Console.WriteLine();
			Console.WriteLine("Co chcesz obliczyć ?");
		}
		private Dictionary<int, string> menuOptions = new Dictionary<int, string>()
		{
		
		};

		private void ShowMenuOptions()
		{
			Console.WriteLine("1. Dla punktów P,Q oblicz P + Q");
			Console.WriteLine("2. Dla punktów P,Q oblicz 2P");
			Console.WriteLine("2. Dla punktów P,Q oblicz P - P");
			Console.WriteLine("2. Dla punktów P,Q oblicz P + 0");
		}
		private void GetNumberFromUser()
		{
			Console.WriteLine();
			Console.WriteLine("Podaj numer");
			numberOfTask = Console.ReadKey().KeyChar;
		}
		private void UserChoose()
		{
			switch (numberOfTask)
			{
				case '1':
					Console.Clear();
					_pointBelongsToCurves.Run();
					//numberOfTask = '-';
					break;
				default:
					Console.Clear();
					Run();
					break;
			}
		}
	}
}
