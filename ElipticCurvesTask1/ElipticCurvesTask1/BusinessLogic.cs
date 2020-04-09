using ElipticCurvesTask1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElipticCurvesTask1
{
	public class BusinessLogic : IBusinessLogic
	{
		IShowInConsole _showInConsole;
		
		public BusinessLogic(IShowInConsole showInConsole)
		{
			_showInConsole = showInConsole;
		}
		public void Run()
		{
			_showInConsole.Run();
		}
		
	}
}
