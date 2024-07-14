namespace DecisionPipeline.Handlers
{
    public interface IHandler<Tin, Tout>
    {
        Tout Output { get; }
        Tin Input { get; }
        Tout Handle();
    }
}
