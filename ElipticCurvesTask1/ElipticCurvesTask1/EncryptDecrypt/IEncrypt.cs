using ElipticCurvesTask1.Models;
using System.Collections.Generic;
using System.Numerics;

namespace ElipticCurvesTask1
{
	public interface IEncrypt
	{
		Point EncryptMessage(string massage, BigInteger ni);
		BigInteger GetRandomNi();
	}
}