using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReduxArch.Data.Interface
{
    public interface IRole<TId>
    {
        TId Id { get; }
        string Name { get; }
        IEnumerable<IUser> Users { get; }
    }
}
