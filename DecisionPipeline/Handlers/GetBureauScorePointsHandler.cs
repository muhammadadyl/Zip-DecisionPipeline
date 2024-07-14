using DecisionPipeline.Model;

namespace DecisionPipeline.Handlers
{
    public class GetBureauScorePointsHandler(CreditCalculationDataOptions creditCalculationData, Customer customer, CustomerPoints points) : CustomerHandler(customer, points)
    {
        private readonly CreditCalculationDataOptions _creditCalculationData = creditCalculationData;

        public override CustomerPoints Handle()
        {
            _points.BureauScorePoints = _creditCalculationData.BureauScores.FirstOrDefault(i => Input.BureauScore >= i.Min && Input.BureauScore <= i.Max)?.Points ?? -1;
            return _points;
        }
    }
}
