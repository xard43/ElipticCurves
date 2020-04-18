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
		private string _message;
		private BigInteger _ni;
		private BigInteger A;
		private BigInteger B;
		private BigInteger modulo;
		ICurveEquation _curveEquation;

		public Encrypt(ICurveEquation curveEquation)
		{
			_curveEquation = curveEquation;
		}

		public List<Point> EncryptMessage(string massage, BigInteger ni)
		{
			_message = massage;
			_ni = ni;

			A = _curveEquation.A;
			B = _curveEquation.B;
			modulo = _curveEquation.Modulo;

			List<Point> encryptMessagePoints = new List<Point>();

			byte[] messsageBytes = GetASCIIBytesValue();

			for (int i = 0; i < messsageBytes.Length; i ++)
			{
				encryptMessagePoints.Add(EncryptCharacter(messsageBytes[i]).First());
			}
			return encryptMessagePoints;
		}


		private List<Point> EncryptCharacter(byte massageByte)
		{
			
			List<Point> encryptPoints = new List<Point>();
			
			int M = massageByte;
			BigInteger ni = _ni;
			BigInteger N = GetRandomN(massageByte);

			for (int i = 1; i <= ni; i++)
			{
				BigInteger x = (M * ni + i) % modulo;
				BigInteger ySquare = (BigInteger.ModPow(x, 3, modulo) + x * A + B) % modulo;

				if (SquareRest.IsSquareRest(modulo, ySquare))
				{
					BigInteger y = BigIntigerMath.SqrtModEuler(ySquare, modulo);

					encryptPoints.Add(new Point(x, y));
					return encryptPoints;
				}
			}
			return encryptPoints;
		}

		private byte[] GetASCIIBytesValue()
		{
			byte[] bytes = Encoding.ASCII.GetBytes(_message);
			return bytes;
		}

		private BigInteger GetRandomN(byte messageByte)
		{
			Random rand = new Random();
			BigInteger x = rand.Next(messageByte, int.MaxValue);
			return x;
		}

		public BigInteger GetRandomNi()
		{
			Random rand = new Random();
			BigInteger x = rand.Next(30, 50);
			return x;
		}
	}
}
