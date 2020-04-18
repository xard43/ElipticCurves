using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace ElipticCurvesTask1.EncryptDecrypt
{
	public class EDShowInConsole : IEDShowInConsole
	{
		IEncrypt _encrypt;
		IDecrypt _decrypt;

		public EDShowInConsole(IEncrypt encrypt, IDecrypt decrypt)
		{
			_encrypt = encrypt;
			_decrypt = decrypt;
		}

		public void Run()
		{
			
			string message = "Marek";
			BigInteger ni = _encrypt.GetRandomNi();
			
			var encryptedMessage = _encrypt.EncryptMessage(message, ni);

			Console.WriteLine("KODOWANIE START: ");
			foreach(var point in encryptedMessage)
			{
				Console.WriteLine("P( " + point.x.ToString() + "," + point.y.ToString() + ")");
			}

			Console.WriteLine("KODOWANIE KONIEC: ");


			var decryptedMessage = _decrypt.DescryptMessage(encryptedMessage, ni);
			//string bitString = Encoding.ASCII.GetString(decMes, 0, decMes.Length);
			Console.WriteLine("Wiadomośc po odszyfrownaiu: " + decryptedMessage);
		}
	}
}
