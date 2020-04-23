using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace ElipticCurvesTask1.EncryptDecrypt
{
	public class EncryptDecryptShowInConsole : IEDShowInConsole
	{
		IEncrypt _encrypt;
		IDecrypt _decrypt;

		public EncryptDecryptShowInConsole(IEncrypt encrypt, IDecrypt decrypt)
		{
			_encrypt = encrypt;
			_decrypt = decrypt;
		}

		public void Run()
		{
			Console.WriteLine();
			Console.WriteLine("Zadanie 2");



			string message = "Szyfowanie zadanie drugie";
			BigInteger ni = _encrypt.GetRandomNi();
			Console.WriteLine("Wiadomośc do zaszyfrowania: " + message);
			Console.WriteLine();
			var encryptedMessage = _encrypt.EncryptMessage(message, ni);
			Console.WriteLine("Po Szyfrowaniu: ");
			Console.WriteLine("Punkt: P( " + encryptedMessage.x +"," + encryptedMessage.y + " )");



			var decryptedMessage = _decrypt.DescryptMessage(encryptedMessage, ni);
			//string bitString = Encoding.ASCII.GetString(decMes, 0, decMes.Length);
			Console.WriteLine("Wiadomośc po odszyfrownaiu: " + decryptedMessage);
		}
	}
}
