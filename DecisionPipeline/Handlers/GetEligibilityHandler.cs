using DecisionPipeline.Model;

namespace DecisionPipeline.Handlers
{
    public class GetEligibilityHandler(CreditCalculationDataOptions _, Customer customer, CustomerPoints points) : CustomerHandler(customer, points)
    {
        public override CustomerPoints Handle()
        {
            if (!_points.Eligible)
            {
                throw new ArgumentException("Not eligible for credit");
            }
            return _points;
        }
    }
}
