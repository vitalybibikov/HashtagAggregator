namespace MyStudyProject.Core.Contracts.Interface
{
    public interface IAssembler<in TEntity, out TModel>
    {
        TModel CreateModel(TEntity entity);
    }
}
