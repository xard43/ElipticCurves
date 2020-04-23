using ElipticCurvesTask1.Models;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Linq;
using System.Collections;

namespace ElipticCurvesTask1
{
	public class Decrypt : IDecrypt
	{
		BigInteger _ni;
		public string DescryptMessage(Point encryptMessagePoint, BigInteger ni)
		{
			_ni = ni;
			string decryptedMessage = "";

			var decryptedInt = DescryptPoint(encryptMessagePoint);
			var decryptedBytes = decryptedInt.ToByteArray();
			decryptedMessage = Encoding.UTF8.GetString(decryptedBytes);// GetString(decryptedBytes, 0, decryptedBytes.Length);

			return decryptedMessage;
		}

		private BigInteger DescryptPoint(Point point)
		{
			return (point.x - 1) / _ni;
		}
	}
}
