using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace ElipticCurvesTask1.Models
{
	public static class BigIntigerMath
	{
		
		public static BigInteger SqrtModEuler(BigInteger value, BigInteger modulo)
		{
			bool canSqrtModEuler = CanSqrtModEuler(modulo);
			bool isSquareRest = SquareRest.IsSquareRest(modulo, value);
			if (canSqrtModEuler && isSquareRest)
			{
				BigInteger exponent = (modulo + 1) / 4;
				BigInteger result = BigInteger.ModPow(value, exponent, modulo);
				return result;
			}
			else
			{
				if (!isSquareRest)
					throw new Exception("Liczba " + value.ToString() + " nie jest liczbą kwadratową liczby " + modulo.ToString());
				return -1;
			}
		}
		public static bool CanSqrtModEuler(BigInteger modulo)
		{
			int value = (int)(modulo % 4);
			if (value == 3)
				return true;
			else
				throw new Exception("modulo % 4 have to be equal 3. Now this is equal " + value.ToString());
		}

		public static BigInteger InverseNumberMod(BigInteger value, BigInteger modulo)
		{
			BigInteger exponent = modulo-2;
			BigInteger result = BigInteger.ModPow(value, exponent, modulo);
			return result;
		}
	}
}
