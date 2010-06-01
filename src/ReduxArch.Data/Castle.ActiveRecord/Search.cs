using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.ActiveRecord;
using Castle.ActiveRecord.Framework;
using NHibernate.Event;
using NHibernate.Search.Event;

namespace ReduxArch.Data.Castle.ActiveRecord
{
    public class Search
    {
        public static void Initialize()
        {
            if (ActiveRecordStarter.IsInitialized)
            {
                var holder = ActiveRecordMediator.GetSessionFactoryHolder();
                var configuration = holder.GetConfiguration(typeof(ActiveRecordBase));

                configuration.SetListener(ListenerType.PostUpdate, new FullTextIndexEventListener());
                configuration.SetListener(ListenerType.PostInsert, new FullTextIndexEventListener());
                configuration.SetListener(ListenerType.PostDelete, new FullTextIndexEventListener());
            }
        }
    }
}
