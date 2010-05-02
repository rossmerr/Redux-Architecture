using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReduxArch.Core.DomainModel;
using ReduxArch.Data.Interface;

namespace ReduxArch.Data
{
    public abstract class Role<TId> : Entity, IRole<TId>
    {
        public new abstract TId Id
        {
            get;
            protected set;
        }

        public string Name
        {
            get;
            protected set;
        }

        public abstract IEnumerable<IUser> Users
        {
            get;
            protected set;
        }
    }
}
