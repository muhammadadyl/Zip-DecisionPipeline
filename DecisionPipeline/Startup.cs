using DecisionPipeline.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionPipeline
{
    public class Startup
    {
        public Startup()
        {
            var builder = new ConfigurationBuilder()
                      .SetBasePath(Directory.GetCurrentDirectory())
                      .AddJsonFile("AppSettings.json", optional: false);

            IConfiguration config = builder.Build();

            if (!config.GetSection("CreditCalculationData").Exists())
            {
                throw new FileNotFoundException("AppSettings.json file doesn't exist");
            }

            CreditCalculationDataOptions = config.GetSection("CreditCalculationData").Get<CreditCalculationDataOptions>();
        }

        public CreditCalculationDataOptions? CreditCalculationDataOptions { get; private set; }
    }
}
