using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.ActiveRecord;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;
using ReduxArch.Core.PagedList;
using ReduxArch.Core.PersistenceSupport;

namespace ReduxArch.Data.Castle.ActiveRecord
{
    public class CastleRepository<T, IdT> : IRepository<T, IdT> where T : class
    {        
        public T Get(IdT id)
        {
            return ActiveRecordMediator<T>.FindByPrimaryKey(id);
        }

        public IEnumerable<T> GetAll()
        {
            return ActiveRecordMediator<T>.FindAll();
        }

        public IPagedList<T> GetPaged(int pageIndex, int pageSize)
        {
            return PagedListExtensions.ToPagedList(GetAll(), pageIndex, pageSize);
        }

        public IEnumerable<T> FindAll(IDictionary<string, object> propertyValuePairs)
        {
            var session = CastleSession.GetSession().GetSession(typeof(T));
            var criteria = session.CreateCriteria(typeof(T));

            foreach (var key in propertyValuePairs.Keys)
            {
                if (propertyValuePairs[key] != null)
                {
                    criteria.Add(Expression.Eq(key, propertyValuePairs[key]));
                }
                else
                {
                    criteria.Add(Expression.IsNull(key));
                }
            }

            return criteria.List<T>();
        }

        public T FindOne(IDictionary<string, object> propertyValuePairs)
        {
            IEnumerable<T> foundList = FindAll(propertyValuePairs);
            if (foundList.Count() > 1)
            {
                throw new NonUniqueResultException(foundList.Count());
            }
            else if (foundList.Count() == 1)
            {
                return foundList.ElementAt(0);
            }

            return default(T);
        }

        public T SaveOrUpdate(T entity)
        {
            ActiveRecordMediator<T>.Save(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            ActiveRecordMediator<T>.Delete(entity);
        }
    }
}