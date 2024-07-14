using DecisionPipeline.Model;

namespace DecisionPipeline.Handlers
{
    public abstract class CustomerHandler(Customer customer, CustomerPoints points) : IHandler<Customer, CustomerPoints>
    {
        protected readonly Customer _customer = customer;
        protected readonly CustomerPoints _points = points ?? new CustomerPoints();

        public CustomerPoints Output { get => _points; }
        public Customer Input { get => _customer; }

        public abstract CustomerPoints Handle();
    }
}
