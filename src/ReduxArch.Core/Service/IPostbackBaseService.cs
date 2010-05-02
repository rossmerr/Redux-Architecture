using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReduxArch.Core.PersistenceSupport;

namespace ReduxArch.Core.Service
{
    public interface IPostbackBaseService<TModel, TViewModel, TPostbackViewModel, TId, TRepository>
        : IBaseService<TModel, TViewModel, TId, TRepository>
        where TRepository : IRepository<TModel, TId>
        where TPostbackViewModel : TViewModel
        where TViewModel : class

    {
        TViewModel Postback(TPostbackViewModel postbackViewModel);

        TViewModel Save(TPostbackViewModel viewModel);

        TViewModel Update(TPostbackViewModel viewModel);
    }
}
