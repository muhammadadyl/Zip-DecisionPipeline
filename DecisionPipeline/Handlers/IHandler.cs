using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionPipeline.Handlers
{
    public interface IHandler<Tin, Tout>
    {
        Tout Output { get; }
        Tin Input { get; }
        Tout Handle();
    }
}
