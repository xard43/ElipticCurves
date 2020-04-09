using ElipticCurvesTask1.DataModels;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace ElipticCurvesTask1.Models
{
	public class Point
	{
		public Point(BigInteger x, BigInteger y)
		{
			this.x = x;
			this.y = y;
			this.specialZero = -1;
		}

		public Point(int zero)
		{
		}

		public BigInteger x { get; set; }
		public BigInteger y { get; set; }
		public int specialZero { get; set; }
	}
}
