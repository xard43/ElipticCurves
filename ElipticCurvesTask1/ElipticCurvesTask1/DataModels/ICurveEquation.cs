using System.Numerics;

namespace ElipticCurvesTask1.Models
{
	public interface ICurveEquation
	{
		BigInteger A { get; }
		BigInteger B { get; }
		BigInteger Modulo { get; }
	}
}