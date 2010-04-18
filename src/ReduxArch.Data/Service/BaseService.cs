using System.Collections.Generic;
using Ninject;
using ReduxArch.Core.PersistenceSupport;
using ReduxArch.Core.Service;
using ReduxArch.Data.AutoMapper;

namespace ReduxArch.Data.Service
{
    public abstract class BaseService<TModel, TViewModel, TId, TRepository> : IBaseService<TModel, TViewModel, TId, TRepository> where TRepository : IRepository<TModel, TId>
    {
        [Inject]
        public TRepository Repository
        {
            get;
            set;
        }

        public abstract TViewModel Create();

        public virtual TViewModel Get(TId id)
        {
            var entity = Repository.Get(id);
            return MapToViewModel(entity);
        }

        public virtual IEnumerable<TViewModel> GetAll()
        {
            var entity = Repository.GetAll();
            return MapToViewModel(entity);
        }

        public virtual TViewModel SaveOrUpdate(TViewModel viewModel)
        {
            var entity = MapToModel(viewModel);
            entity = Repository.SaveOrUpdate(entity);
            return MapToViewModel(entity);
        }

        public virtual void Delete(TViewModel viewModel)
        {
            var entity = MapToModel(viewModel);
            Repository.Delete(entity);
        }

        public virtual TId Delete(TId id)
        {
            var entity = Repository.Get(id);
            Repository.Delete(entity);
            return id;
        }

        public IEnumerable<TViewModel> MapToViewModel(IEnumerable<TModel> entity)
        {
            return entity.Map<TModel, TViewModel>();
        }

        public TViewModel MapToViewModel(TModel entity)
        {
            return entity.Map<TModel, TViewModel>();
        }

        public TModel MapToModel(TViewModel viewModel)
        {

            return viewModel.Map<TViewModel, TModel>();
        }
    }
}
