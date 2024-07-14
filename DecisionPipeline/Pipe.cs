using DecisionPipeline.Handlers;
using DecisionPipeline.Model;

namespace DecisionPipeline
{
    public class Pipe<Tin, Tout>
    {
        private readonly List<IHandler<Tin, Tout>> _handlers;
        private Tout? _out;
        public Pipe(CreditCalculationDataOptions creditCalculationData, Tin input, Type[] handlerTypes)
        {
            if (handlerTypes == null || handlerTypes.Length == 0)
            {
                throw new ArgumentNullException(nameof(handlerTypes), "Handler types cannot be null or empty.");
            }

            _handlers = new List<IHandler<Tin, Tout>>();

            foreach (var handlerType in handlerTypes)
            {
                if (!typeof(IHandler<Tin, Tout>).IsAssignableFrom(handlerType))
                {
                    throw new ArgumentException($"{handlerType.Name} does not implement IHandler interface.");
                }

                var handlerInstance = Activator.CreateInstance(handlerType, creditCalculationData, input, _out) as IHandler<Tin, Tout>;

                if (handlerInstance != null)
                {
                    _out = handlerInstance.Handle();
                    _handlers.Add(handlerInstance);
                }
                    
            }
        }

        public Tout? result { get => _out; }
    }
}
