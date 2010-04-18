using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReduxArch.Core.PersistenceSupport;

namespace ReduxArch.Core.Service
{
    public interface IBaseService<TModel, TViewModel, TId, TRepository> where TRepository : IRepository<TModel, TId>
    {
        TViewModel Create();

        TViewModel Get(TId id);

        IEnumerable<TViewModel> GetAll();

        TViewModel SaveOrUpdate(TViewModel viewModel);

        void Delete(TViewModel viewModel);

        TId Delete(TId id);

        IEnumerable<TViewModel> MapToViewModel(IEnumerable<TModel> entity);

        TViewModel MapToViewModel(TModel entity);

        TModel MapToModel(TViewModel viewModel);
    }
}
