using System;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Text;

namespace ElipticCurvesTask1.Models
{
	public class CurveEquation : ICurveEquation
	{
		private BigInteger valueB = BigInteger.Parse("5ac635d8aa3a93e7b3ebbd55769886bc651d06b0cc53b0f63bce3c3e27d2604b", NumberStyles.HexNumber);
		private BigInteger valueA = -3;
		private BigInteger modulo = (BigInteger)Math.Pow(2,256) - (BigInteger)Math.Pow(2, 224) + (BigInteger)Math.Pow(2, 192) + (BigInteger)Math.Pow(2, 96) -1;

		public BigInteger A
		{
			get
			{
				return valueA;
			}
		}
		public BigInteger B
		{
			get
			{
				return valueB % modulo;
			}
		}
		public BigInteger Modulo
		{
			get
			{
				return modulo;
			}
		}
		//private bool IsEqualCurveEquation()
		//{
		//	BigInteger moduloA = A % modulo;
		//	BigInteger moduloB = B % modulo;
		//	BigInteger value = 4*A*A*A + 27*B*B;
		//}
	}
}
