using DecisionPipeline.Model;

namespace DecisionPipeline.Handlers
{
    public class GetMissedPaymentsPoints(CreditCalculationDataOptions creditCalculationData, Customer customer, CustomerPoints points) : CustomerHandler(customer, points)
    {
        private readonly CreditCalculationDataOptions _creditCalculationData = creditCalculationData;
        public override CustomerPoints Handle()
        {
            _points.MissedPaymentsPoints = (_creditCalculationData.MissedPayments.FirstOrDefault(i => i.Number == Input.MissedPaymentCount) ?? _creditCalculationData.MissedPayments.First(i => i.MaxDefault)).Points;
            return _points;
        }
    }
}
