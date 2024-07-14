using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionPipeline.Model
{
    public class Customer
    {
        public uint BureauScore { get; }

        public uint MissedPaymentCount { get; }

        public uint CompletedPaymentCount { get; }

        public uint AgeInYears { get; }

        public Customer(uint bureauScore, uint missedPaymentCount,
            uint completedPaymentCount, uint ageInYears)
        {
            BureauScore = bureauScore;
            MissedPaymentCount = missedPaymentCount;
            CompletedPaymentCount = completedPaymentCount;
            AgeInYears = ageInYears;
        }

        
    }
}
