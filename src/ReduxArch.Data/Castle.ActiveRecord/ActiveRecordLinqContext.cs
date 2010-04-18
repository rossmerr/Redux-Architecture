using System;
using Castle.ActiveRecord;
using Castle.ActiveRecord.Framework;
using NHibernate.Linq;
using NHibernate;

namespace ReduxArch.Data.Castle.ActiveRecord
{
    public class ActiveRecordLinqContext : NHibernateContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ActiveRecordLinqContext"/> class.
        /// </summary>
        public ActiveRecordLinqContext()
            : base(GetSession())
        {
        }

        /// <summary>
        /// The get session.
        /// </summary>
        /// <returns>
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// </exception>
        private static ISession GetSession()
        {
            ISessionScope scope = SessionScope.Current;
            if (scope == null)
            {
                throw new InvalidOperationException("You must have an active SessionScope object to use this class.");
            }

            ISessionFactoryHolder holder = ActiveRecordMediator.GetSessionFactoryHolder();

            return holder.CreateSession(typeof(ActiveRecordBase));
        }
    }

}
