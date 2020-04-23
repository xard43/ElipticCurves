using ElipticCurvesTask1.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Linq;

namespace ElipticCurvesTask1
{
	public class Encrypt : IEncrypt
	{
		
		private BigInteger A;
		private BigInteger B;
		private BigInteger modulo;
		

		public Encrypt(ICurveEquation curveEquation)
		{
			A = curveEquation.A;
			B = curveEquation.B;
			modulo = curveEquation.Modulo;
		}
		
		public Point EncryptMessage(string massage, BigInteger ni)
		{
			byte[] bytes = System.Text.Encoding.UTF8.GetBytes(massage);

			BigInteger M = new BigInteger(bytes);

			for (int i = 1; i <= ni; i++)
			{
				BigInteger x = (M * ni + i) % modulo;
				BigInteger ySquare = (BigInteger.ModPow(x, 3, modulo) + x * A + B) % modulo;

				if (SquareRest.IsSquareRest(modulo, ySquare))
				{
					BigInteger y = BigIntigerMath.SqrtModEuler(ySquare, modulo);

					return new Point(x, y);
				}
			}
			return new Point(-1);
		}
		
		public BigInteger GetRandomNi()
		{
			Random rand = new Random();
			BigInteger x = rand.Next(30, 50);
			return x;
		}

		public void podzielWiadomosc()
		{
			string message = "";
			byte[] bytes = System.Text.Encoding.UTF8.GetBytes(message);
			
		}
	}
}
