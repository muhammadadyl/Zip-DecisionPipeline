using DecisionPipeline.Model;

namespace DecisionPipeline.Handlers
{
    public class GetAvailableCredit(CreditCalculationDataOptions creditCalculationData, Customer customer, CustomerPoints points) : CustomerHandler(customer, points)
    {
        private readonly CreditCalculationDataOptions _creditCalculationData = creditCalculationData;

        public override CustomerPoints Handle()
        {
            var creditObject = _creditCalculationData.AvailableCredits.First(i => i.MinDefault);
            if (_points.MaxCreditPoints > 0)
            {
                creditObject = _creditCalculationData.AvailableCredits.FirstOrDefault(i => i.Points == _points.MaxCreditPoints) ?? _creditCalculationData.AvailableCredits.First(i => i.MaxDefault);
            }
            _points.CreditAmount = creditObject.Credit;
            return _points;
        }
    }
}
