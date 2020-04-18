using ElipticCurvesTask1.Models;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Linq;

namespace ElipticCurvesTask1
{
	public class Decrypt : IDecrypt
	{
		BigInteger _ni;
		public string DescryptMessage(List<Point> encryptMessage, BigInteger ni)
		{
			_ni = ni;
			string decryptedMessage = "";
			foreach (Point point in encryptMessage)
			{
				var decryptedInt = DescryptPoint(point);
				var decryptedBytes = decryptedInt.ToByteArray();
				string byteString = Encoding.ASCII.GetString(decryptedBytes, 0, decryptedBytes.Length);
				decryptedMessage += byteString;
			}
			return decryptedMessage;
		}

		private BigInteger DescryptPoint(Point point)
		{
			return (point.x - 1) / _ni;
		}
	}
}
