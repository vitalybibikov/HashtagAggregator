namespace MyStudyProject.Core.Contracts.Interface.Cqrs.Command
{
    public interface ICompositeCommandHandler<TParameter> : ICommandHandler<TParameter>
        where TParameter : ICommand
    {
        void Add(ICommandHandler<TParameter> queryHandler);

        bool Remove(ICommandHandler<TParameter> queryHandler);
    }
}
