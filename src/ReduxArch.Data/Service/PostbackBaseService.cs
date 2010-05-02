using ReduxArch.Core.PersistenceSupport;
using ReduxArch.Core.Service;

namespace ReduxArch.Data.Service
{
    public abstract class PostbackBaseService<TModel, TViewModel, TPostbackViewModel, TId, TRepository>
        : BaseService<TModel, TViewModel, TId, TRepository>
        , IPostbackBaseService<TModel, TViewModel, TPostbackViewModel, TId, TRepository>
        where TRepository : IRepository<TModel, TId>
        where TPostbackViewModel : TViewModel
        where TViewModel : class
    {
        public abstract TViewModel Postback(TPostbackViewModel postbackViewModel);

        public abstract TViewModel Save(TPostbackViewModel viewModel);

        public abstract TViewModel Update(TPostbackViewModel viewModel);
    }
}
