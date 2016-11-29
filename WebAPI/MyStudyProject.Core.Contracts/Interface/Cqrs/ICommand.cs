namespace MyStudyProject.Core.Contracts.Interface.Cqrs
{
    /// <summary>
    /// Marker interface to mark a command
    /// </summary>
    public interface ICommand
    {
        long Id { get; set; }
    }
}
