using ElipticCurvesTask1.Models;

namespace ElipticCurvesTask1
{
	public interface IPointBelongsToCurves
	{
		Point GetPointCurvesContain();
		bool IsPointContainToCurves(Point point);
	}
}