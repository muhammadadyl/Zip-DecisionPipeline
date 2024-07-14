// See https://aka.ms/new-console-template for more information
using DecisionPipeline;
using DecisionPipeline.Handlers;
using DecisionPipeline.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

var startup = new Startup();

if (startup.CreditCalculationDataOptions == null)
{
    throw new NullReferenceException(nameof(startup.CreditCalculationDataOptions));
}

Assert.AreEqual(200, GetCreditAmout(startup.CreditCalculationDataOptions, new Customer(451, 2, 3, 18))?.CreditAmount);

Assert.AreEqual(0, GetCreditAmout(startup.CreditCalculationDataOptions, new Customer(451, 3, 2, 18))?.CreditAmount);

Assert.ThrowsException<ArgumentException>(() => GetCreditAmout(startup.CreditCalculationDataOptions, new Customer(451, 2, 3, 17)));

Assert.ThrowsException<ArgumentException>(() => GetCreditAmout(startup.CreditCalculationDataOptions, new Customer(450, 2, 3, 89)));


static CustomerPoints? GetCreditAmout(CreditCalculationDataOptions creditCalculationData, Customer customer)
{
    var pipe = new Pipe<Customer, CustomerPoints>(
    creditCalculationData,
    customer,
    [
        typeof(GetAgeBracketHandler),
        typeof(GetBureauScorePointsHandler),
        typeof(GetEligibilityHandler),
        typeof(GetMissedPaymentsPoints),
        typeof(GetCompletedPaymentsPoints),
        typeof(GetAvailableCredit)
    ]);

    Console.WriteLine("Result of pipeline is: {0}", pipe.result?.CreditAmount);

    return pipe.result;
}