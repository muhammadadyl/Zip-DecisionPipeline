﻿using DecisionPipeline.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionPipeline.Handlers
{
    public class GetAgeBracketHandler(CreditCalculationDataOptions creditCalculationData, Customer customer, CustomerPoints points) : CustomerHandler(customer, points)
    {
        private readonly CreditCalculationDataOptions _creditCalculationData = creditCalculationData;

        public override CustomerPoints Handle()
        {
            _points.AgeBracketScorePoints = _creditCalculationData.AgeBrackets.FirstOrDefault(i => Input.AgeInYears >= i.Min && Input.AgeInYears <= i.Max)?.Points ?? -1;
            return _points;
        }
    }
}
