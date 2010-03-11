using ReduxArch.Core.DomainModel;

namespace ReduxArch.Core.PersistenceSupport
{
    public interface IEntityDuplicateChecker
    {
        bool DoesDuplicateExistWithTypedIdOf<IdT>(IEntityWithTypedId<IdT> entity);
    }
}