using ElipticCurvesTask1.Models;
using System.Collections.Generic;
using System.Numerics;

namespace ElipticCurvesTask1
{
	public interface IDecrypt
	{
		string DescryptMessage(Point encryptMessagePoint, BigInteger ni);
	}
}