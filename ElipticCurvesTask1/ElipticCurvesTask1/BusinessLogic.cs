using ElipticCurvesTask1.EncryptDecrypt;
using ElipticCurvesTask1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElipticCurvesTask1
{
	public class BusinessLogic : IBusinessLogic
	{
		IShowInConsole _showInConsole;
		IEDShowInConsole _encryptDecryptConsole;

		
		public BusinessLogic(IShowInConsole showInConsole, IEncrypt encrypt, IEDShowInConsole encryptDecryptConsole)
		{
			_showInConsole = showInConsole;
			_encryptDecryptConsole = encryptDecryptConsole;
		}
		public void Run()
		{
			_showInConsole.Run();
			_encryptDecryptConsole.Run();
		}
		
	}
}
