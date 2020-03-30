using ElipticCurvesTask1.Models;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace ElipticCurvesTask1
{
	public static class SquareRest
	{
		public static bool IsSquareRest(BigInteger modulo, BigInteger value)
		{
			//IsRest = value^((modulo-1)/2)
			BigInteger expontent = (modulo - 1) / 2;
			BigInteger result = BigInteger.ModPow(value, expontent, modulo);
			if (result == 1)
				return true;
			else
				return false;
		}
	}
}
