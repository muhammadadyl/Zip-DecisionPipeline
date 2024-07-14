using DecisionPipeline.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionPipeline.Handlers
{
    public class GetCompletedPaymentsPoints(CreditCalculationDataOptions creditCalculationDataOptions, Customer customer, CustomerPoints points) : CustomerHandler(customer, points)
    {
        private readonly CreditCalculationDataOptions _creditCalculationData = creditCalculationDataOptions;

        public override CustomerPoints Handle()
        {
            _points.CompletedPaymentsPoints = (_creditCalculationData.CompletedPayments.FirstOrDefault(i => i.Number == Input.CompletedPaymentCount) ?? _creditCalculationData.CompletedPayments.First(i => i.MaxDefault)).Points;
            return _points;
        }
    }
}
